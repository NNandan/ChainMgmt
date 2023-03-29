Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmPartyMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
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
    Private Sub frmPartyMaster_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Clear_Form()

        'If dtUserRights.Rows.Count > 0 Then
        '    Dim DTROW() As DataRow = dtUserRights.Select("FormName = 'PARTY MASTER'")
        '    USERADD = DTROW(0).Item(3)
        '    USEREDIT = DTROW(0).Item(4)
        '    USERVIEW = DTROW(0).Item(5)
        '    USERDELETE = DTROW(0).Item(6)

        '    If USEREDIT = False And USERDELETE = False Then
        '        MsgBox("Insufficient Rights")
        '        btnDelete.Enabled = False
        '    End If
        'End If

        ''Telerik Datagrid
        dgvPartyList.AutoGenerateColumns = False
        dgvPartyList.DataSource = FetchAllRecords()
        dgvPartyList.EnableFiltering = True
        dgvPartyList.MasterTemplate.ShowHeaderCellButtons = True
        dgvPartyList.MasterTemplate.ShowFilteringRow = False
        dgvPartyList.CurrentRow = Nothing
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                If Fr_Mode = FormState.AStateMode Then

                    If IsExists() = False Then
                        MessageBox.Show(String.Format("Party Name {0} already exists.", Me.txtPartyName.Text.Trim))
                        Me.txtPartyName.Focus()
                        Exit Sub
                    End If

                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@PName", txtPartyName.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                Else
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@PId", txtPartyName.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@PName", txtPartyName.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                End If
            End With

            dbManager.Insert("SP_PartyMaster_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtPartyName.Tag) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try

                    Dim parameters = New List(Of SqlParameter)()

                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@PId", txtPartyName.Tag, DbType.Int16))
                    End With

                    dbManager.Delete("SP_PartyMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Clear_Form()

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            Else
                MessageBox.Show("Please Select A Record !!!")
            End If
        End If
    End Sub
    Private Sub frmPartyMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                ' When Alt + S is pressed, the Click event for the print
                ' button is raised.
                btnSave().PerformClick()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_PartyMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub dgvPartyList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvPartyList.CellDoubleClick
        If e.RowIndex >= 0 Then
            Fr_Mode = FormState.EStateMode
            txtPartyName.Tag = dgvPartyList.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtPartyName.Text = dgvPartyList.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtPartyName.Focus()
            txtPartyName.Select()
        Else
            Me.Clear_Form()
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtPartyName_Leave(sender As Object, e As EventArgs) Handles txtPartyName.Leave
        txtPartyName.Text = ToProper(txtPartyName.Text)
    End Sub
    Private Sub txtPartyName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPartyName.KeyPress
        e.Handled = e.KeyChar <> ChrW(Keys.Back) And Not Char.IsSeparator(e.KeyChar) And Not Char.IsLetter(e.KeyChar)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_Form()
        Try
            txtPartyName.Tag = ""
            txtPartyName.Clear()

            txtPartyName.Focus()

            dgvPartyList.DataSource = FetchAllRecords()

            Fr_Mode = FormState.AStateMode

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(txtPartyName.Text) Then
                MessageBox.Show("Enter Party Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtPartyName.Focus()
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

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@PName", CStr(txtPartyName.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
            End With

            Dim strName As Object = dbManager.GetScalarValue("SP_PartyMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            If Not IsNothing(strName) Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
End Class