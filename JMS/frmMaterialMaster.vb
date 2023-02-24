Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmMaterialMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim dbManager As New SqlHelper()
    Private Property Fr_Mode() As FormState
        Get
            Return mFr_State
        End Get
        Set(ByVal value As FormState)
            mFr_State = value
            Select Case mFr_State
                Case FormState.AStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "New Fancy"
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "&Save"
                    Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit Fancy"
                    Me.btnSave.Text = "&Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If Fr_Mode = FormState.AStateMode Then

                If IsExists() = False Then
                    MessageBox.Show(String.Format("Material Name {0} already exists.", Me.txtMaterialName.Text.Trim))
                    Me.txtMaterialName.Focus()
                    Exit Sub
                End If

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@MName", txtMaterialName.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@IType", Val(cmbType.SelectedIndex), DbType.Int16))
                    .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                End With
            Else
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@MId", txtMaterialName.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@MName", txtMaterialName.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@IType", Val(cmbType.SelectedIndex), DbType.Int16))
                    .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                End With
            End If

            dbManager.Insert("SP_MaterialMaster_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub frmMaterialMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()

        If dtUserRights.Rows.Count > 0 Then
            Dim DTROW() As DataRow = dtUserRights.Select("FormName = 'Category Master'")
            USERADD = DTROW(0).Item(3)
            USEREDIT = DTROW(0).Item(4)
            USERVIEW = DTROW(0).Item(5)
            USERDELETE = DTROW(0).Item(6)

            If USEREDIT = False And USERDELETE = False Then
                MsgBox("Insufficient Rights")
                btnDelete.Enabled = False
            End If
        End If

        txtMaterialName.Select()

        dgvMaterialList.DataSource = FetchAllFancys()
        dgvMaterialList.EnableFiltering = True
        dgvMaterialList.MasterTemplate.ShowHeaderCellButtons = True
        dgvMaterialList.MasterTemplate.ShowFilteringRow = False
        dgvMaterialList.CurrentRow = Nothing

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtMaterialName.Tag) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try

                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
                        .Add(dbManager.CreateParameter("@MId", txtMaterialName.Tag, DbType.Int16))
                    End With

                    dbManager.Delete("SP_MaterialMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Clear_Form()

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            Else
                MessageBox.Show("Please Select A Fancy !!!")
            End If
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvMaterialList_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvMaterialList.CellDoubleClick
        If e.RowIndex >= 0 Then
            Fr_Mode = FormState.EStateMode
            txtMaterialName.Tag = dgvMaterialList.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtMaterialName.Text = dgvMaterialList.Rows(e.RowIndex).Cells(1).Value.ToString()
            cmbType.SelectedIndex = dgvMaterialList.Rows(e.RowIndex).Cells(2).Value.ToString()
            txtMaterialName.Focus()
            txtMaterialName.Select()
        Else
            Me.Clear_Form()
        End If
    End Sub
    Private Sub Clear_Form()
        Try
            txtMaterialName.Tag = ""
            txtMaterialName.Clear()
            txtMaterialName.Focus()
            cmbType.SelectedIndex = -1

            dgvMaterialList.DataSource = FetchAllFancys()

            Fr_Mode = FormState.AStateMode

            txtMaterialName.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub cmbType_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbType.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbType.Focus()
        End If
    End Sub
    Private Function FetchAllFancys() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_MaterialMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function Validate_Fields() As Boolean
        Try

            If Fr_Mode <> FormState.AStateMode Then
                If txtMaterialName.Tag.Trim = "" Then
                    MessageBox.Show("Select Material ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtMaterialName.Focus()
                    Return False
                End If
            End If

            'Assigning Default values
            If txtMaterialName.Text.Trim = "" Then
                MessageBox.Show("Enter Material Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtMaterialName.Focus()
                Return False
            End If

            If Val(cmbType.SelectedIndex) = -1 Then
                MessageBox.Show("Select Material Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbType.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function IsExists() As Boolean
        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@MName", CStr(txtMaterialName.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
            End With

            Dim strName As Object = dbManager.GetScalarValue("SP_MaterialMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            If Not IsNothing(strName) Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    Private Sub cmbType_GotFocus(sender As Object, e As EventArgs) Handles cmbType.GotFocus
        cmbType.ShowDropDown()
    End Sub
    Private Sub frmMaterialMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, False) 'for Select Next Control
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                btnSave().PerformClick()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class