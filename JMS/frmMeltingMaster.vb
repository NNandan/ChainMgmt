Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmMeltingMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Objerr As New ErrorProvider()
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
    Private Sub frmAccountMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Clear_Form()

        If dtUserRights.Rows.Count > 0 Then
            Dim DTROW() As DataRow = dtUserRights.Select("FormName = 'ACCOUNT MASTER'")
            USERADD = DTROW(0).Item(3)
            USEREDIT = DTROW(0).Item(4)
            USERVIEW = DTROW(0).Item(5)
            USERDELETE = DTROW(0).Item(6)

            If USEREDIT = False And USERDELETE = False Then
                MsgBox("Insufficient Rights")
                btnDelete.Enabled = False
                Exit Sub
            End If
        End If

        ''Telerik Datagrid
        dgvAccountList.AutoGenerateColumns = False
        dgvAccountList.DataSource = FetchAllFancys()
        dgvAccountList.EnableFiltering = True
        dgvAccountList.MasterTemplate.ShowHeaderCellButtons = True
        dgvAccountList.MasterTemplate.ShowFilteringRow = False
        dgvAccountList.CurrentRow = Nothing

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not Validate_Fields() Then Exit Sub

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If Fr_Mode = FormState.AStateMode Then

                If IsExists() = False Then
                    MessageBox.Show(String.Format("Melting Value {0} already exists.", Me.txtMeltingValue.Text))
                    Me.txtMeltingValue.Focus()
                    Exit Sub
                End If

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@MValue", CStr(txtMeltingValue.Text.Trim), DbType.String))
                    .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                End With
            Else
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@MId", txtMeltingValue.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@MValue", CStr(txtMeltingValue.Text.Trim), DbType.String))
                    .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                End With
            End If

            dbManager.Insert("SP_MeltingMaster_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtMeltingValue.Tag) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
                        .Add(dbManager.CreateParameter("@MId", txtMeltingValue.Tag, DbType.Int16))
                    End With

                    dbManager.Delete("SP_MeltingMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Clear_Form()

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Function FetchAllFancys() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function FetchAllFancys(ByVal iAccountId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@MId", txtMeltingValue.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchFancy", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function FetchAllFancys(ByVal sAccountName As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SearchFancy", DbType.String))
                .Add(dbManager.CreateParameter("@MValue", CStr(sAccountName), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub txtAccountName_KeyPress(sender As Object, e As KeyPressEventArgs)
        ''The code below allows only numbers, letters, backspace And Space.
        e.Handled = e.KeyChar <> ChrW(Keys.Back) And Not Char.IsSeparator(e.KeyChar) And Not Char.IsLetter(e.KeyChar) And Not Char.IsDigit(e.KeyChar)
    End Sub
    Private Sub txtAccountName_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub frmAccountMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

            If e.Modifiers = Keys.Alt AndAlso e.KeyCode = Keys.S Then
                btnSave().PerformClick()
            End If

            If e.Modifiers = Keys.Alt AndAlso e.KeyCode = Keys.D Then
                btnDelete().PerformClick()
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvAccountList_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvAccountList.CellDoubleClick
        If e.RowIndex >= 0 Then
            Fr_Mode = FormState.EStateMode
            txtMeltingValue.Tag = dgvAccountList.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtMeltingValue.Text = dgvAccountList.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtMeltingValue.Focus()
            txtMeltingValue.Select()
        Else
            Me.Clear_Form()
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtAccountName_Leave(sender As Object, e As EventArgs) Handles txtMeltingValue.Leave
        txtMeltingValue.Text = ToProper(txtMeltingValue.Text)
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each row As GridViewRowInfo In dgvAccountList.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtMeltingValue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMeltingValue.KeyPress
        numdotkeypress(e, txtMeltingValue, Me)
    End Sub
    Private Sub txtAccountName_Validating(sender As Object, e As CancelEventArgs) Handles txtMeltingValue.Validating
        If Val(txtMeltingValue.Text) > 100 Then
            e.Cancel = True
            Objerr.SetError(txtMeltingValue, "Value should not be between 0 And 100 !")
        Else
            Objerr.Clear()
        End If
    End Sub
    Private Sub Clear_Form()
        Try
            txtMeltingValue.Clear()
            txtMeltingValue.Tag = ""

            dgvAccountList.DataSource = FetchAllFancys()

            Fr_Mode = FormState.AStateMode

            txtMeltingValue.Focus()
            txtMeltingValue.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If Fr_Mode <> FormState.AStateMode Then
                If txtMeltingValue.Tag.Trim = "" Then
                    MessageBox.Show("Select Melting ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtMeltingValue.Focus()
                    Return False
                End If
            End If

            'Assigning Default values
            If txtMeltingValue.Text.Trim = "" Then
                MessageBox.Show("Enter Melting Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtMeltingValue.Focus()
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
                .Add(dbManager.CreateParameter("@MValue", CStr(txtMeltingValue.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
            End With

            Dim strName As Object = dbManager.GetScalarValue("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

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