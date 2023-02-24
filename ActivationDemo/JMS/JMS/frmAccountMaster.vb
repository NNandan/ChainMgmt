Imports System.ComponentModel
Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmAccountMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
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

        'Telerik DataGrid 
        dgvAccountList.AutoGenerateColumns = False
        dgvAccountList.DataSource = FetchAllRecords()
        dgvAccountList.EnableFiltering = True
        dgvAccountList.MasterTemplate.ShowHeaderCellButtons = True
        dgvAccountList.MasterTemplate.ShowFilteringRow = False
        dgvAccountList.CurrentRow = Nothing

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Objerr.Clear()
        If Not Validate_Fields() Then Exit Sub

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If Fr_Mode = FormState.AStateMode Then
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@AName", txtAccountName.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@AAmt", txtAccountCalculate.Text, DbType.Decimal))
                    .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                End With
            Else
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@AId", txtAccountName.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@AName", txtAccountName.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@AAmt", txtAccountCalculate.Text, DbType.Decimal))
                    .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                End With
            End If

            dbManager.Insert("SP_AccountMaster_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtAccountName.Tag) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
                        .Add(dbManager.CreateParameter("@AId", txtAccountName.Tag, DbType.Int16))
                    End With

                    dbManager.Delete("SP_AccountMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Clear_Form()

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            Else
                MessageBox.Show("Please Select A Record !!!")
            End If
        End If
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_AccountMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function FetchAllRecords(ByVal iAccountId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@AId", txtAccountName.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_AccountMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function FetchAllRecords(ByVal sAccountName As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SearchRecord", DbType.String))
                .Add(dbManager.CreateParameter("@AName", CStr(sAccountName), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_AccountMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

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
            txtAccountCalculate.Select()
        End If
    End Sub
    Private Sub txtAccountCalculate_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSave.Select()
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtAccountCalculate_Leave(sender As Object, e As EventArgs)
        txtAccountCalculate.Text = Format(Val(txtAccountCalculate.Text), "0.00")
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

            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                ' When Alt + S is pressed, the Click event for the print
                ' button is raised.
                btnSave().PerformClick()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvAccountList_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvAccountList.CellDoubleClick
        If e.RowIndex >= 0 Then
            Fr_Mode = FormState.EStateMode
            txtAccountName.Tag = dgvAccountList.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtAccountName.Text = dgvAccountList.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtAccountCalculate.Text = dgvAccountList.Rows(e.RowIndex).Cells(2).Value.ToString()
            txtAccountName.Focus()
            txtAccountName.Select()
        Else
            Me.Clear_Form()
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtAccountName_Leave(sender As Object, e As EventArgs) Handles txtAccountName.Leave
        txtAccountName.Text = ToProper(txtAccountName.Text)
    End Sub
    Private Sub txtAccountCalculate_Validating(sender As Object, e As CancelEventArgs) Handles txtAccountCalculate.Validating
        If Val(txtAccountCalculate.Text) > 100 Then
            e.Cancel = True
            Objerr.SetError(txtAccountCalculate, "Value should not be greather than 100 !")
        Else
            Objerr.Clear()
        End If
    End Sub
    Private Sub txtAccountCalculate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAccountCalculate.KeyPress
        numdotkeypress(e, txtAccountCalculate, Me)
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
    Private Sub Clear_Form()
        Try
            Objerr.Clear()
            txtAccountName.Tag = ""
            txtAccountName.Clear()

            txtAccountCalculate.Clear()
            txtAccountCalculate.Tag = ""

            dgvAccountList.DataSource = FetchAllRecords()

            Fr_Mode = FormState.AStateMode

            txtAccountName.Focus()
            txtAccountName.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If Fr_Mode <> FormState.AStateMode Then
                If txtAccountName.Tag.Trim = "" Then
                    MessageBox.Show("Select Account ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtAccountName.Focus()
                    Return False
                End If
                End If

            'Assigning Default values
            If txtAccountName.Text.Trim.Length = 0 Then
                Objerr.SetError(txtAccountName, "Enter Account Name !!!")
                txtAccountName.Focus()
                Return False
            End If

            If txtAccountCalculate.Text.Trim = "" Then
                MessageBox.Show("Enter Account Amount !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtAccountCalculate.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub txtAccountCalculate_Validated(sender As Object, e As EventArgs) Handles txtAccountCalculate.Validated
        Try
            Objerr.SetError(txtAccountCalculate, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class