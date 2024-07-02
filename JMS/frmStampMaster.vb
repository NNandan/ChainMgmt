Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmStampMaster
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
                    CType(Me.ParentForm, frmMain).FormMode.Text = "New"
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "&Save"
                    Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit"
                    Me.btnSave.Text = "&Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If Fr_Mode = FormState.AStateMode Then

                If IsExists() = False Then
                    MessageBox.Show(String.Format("Stamp Name {0} already exists.", Me.txtStampName.Text.Trim))
                    Me.txtStampName.Focus()
                    Exit Sub
                End If

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@SName", txtStampName.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With
            Else
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@SId", txtStampName.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@SName", txtStampName.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With
            End If

            dbManager.Insert("SP_StampMaster_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtStampName.Tag) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then
                Try

                    Dim parameters = New List(Of SqlParameter)()

                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@SId", txtStampName.Tag, DbType.Int16))
                    End With

                    dbManager.Delete("SP_StampMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.btnCancel_Click(sender, e)

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmStampMaster_Load(sender As Object, e As EventArgs) Handles Me.Load
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

        txtStampName.Select()

        dgvStampList.DataSource = FetchAllFancys()
        dgvStampList.EnableFiltering = True
        dgvStampList.MasterTemplate.ShowHeaderCellButtons = True
        dgvStampList.MasterTemplate.ShowFilteringRow = False
        dgvStampList.CurrentRow = Nothing
    End Sub

    Private Sub dgvStampList_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvStampList.CellDoubleClick
        If e.RowIndex >= 0 Then
            Fr_Mode = FormState.EStateMode
            txtStampName.Tag = dgvStampList.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtStampName.Text = dgvStampList.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtStampName.Focus()
            txtStampName.Select()
        Else
            Me.Clear_Form()
        End If
    End Sub
    Private Sub Clear_Form()
        Try
            txtStampName.Tag = ""
            txtStampName.Clear()
            txtStampName.Focus()

            dgvStampList.DataSource = FetchAllFancys()

            Fr_Mode = FormState.AStateMode

            txtStampName.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(txtStampName.Text.Trim) Then
                MessageBox.Show("Enter Stamp Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtStampName.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function FetchAllFancys() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StampMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function IsExists() As Boolean
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@SName", CStr(txtStampName.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
            End With

            Dim strName As Object = dbManager.GetScalarValue("SP_StampMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            If Not IsNothing(strName) Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    Private Sub frmStampMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            If (e.Control AndAlso (e.KeyCode = Keys.S)) Then
                btnSave().PerformClick()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class