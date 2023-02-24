Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmLabMaster
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
    Private Sub frmLabMaster_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Clear_Form()

        'If dtUserRights.Rows.Count > 0 Then
        '    Dim DTROW() As DataRow = dtUserRights.Select("FormName = 'Family Master'")
        '    USERADD = DTROW(0).Item(3)
        '    USEREDIT = DTROW(0).Item(4)
        '    USERVIEW = DTROW(0).Item(5)
        '    USERDELETE = DTROW(0).Item(6)

        '    If USEREDIT = False And USERDELETE = False Then
        '        MsgBox("Insufficient Rights")
        '        btnDelete.Enabled = False
        '    End If
        'End If

        dgvLabList.DataSource = FetchAllRecords()
        dgvLabList.CurrentRow = Nothing
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                .Add(dbManager.CreateParameter("@LId", txtLabName.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function FetchAllRecords(ByVal sAccountName As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SearchRecord", DbType.String))
                .Add(dbManager.CreateParameter("@AName", CStr(sAccountName), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtLabName.Tag) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
                        .Add(dbManager.CreateParameter("@LId", txtLabName.Tag, DbType.Int16))
                    End With

                    dbManager.Delete("SP_LabMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.btnCancel_Click(sender, e)

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not Validate_Fields() Then Exit Sub

        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If Fr_Mode = FormState.AStateMode Then

                If IsExists() = False Then
                    MessageBox.Show(String.Format("Lab Name {0} already exists.", Me.txtLabName.Text.Trim))
                    Me.txtLabName.Focus()
                    Exit Sub
                End If

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@LabName", txtLabName.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@LabRt", txtLabRate.Text.Trim, DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LossWt", txtLossWt.Text.Trim, DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LCreatedBy", UserName.Trim(), DbType.String))
                End With
            Else
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@LId", txtLabName.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@LabName", txtLabName.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@LabRt", txtLabRate.Text.Trim, DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LossWt", txtLossWt.Text.Trim, DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LCreatedBy", UserName.Trim(), DbType.String))
                End With
            End If

            dbManager.Insert("SP_LabMaster_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtLabName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLabName.KeyPress
        e.Handled = e.KeyChar <> ChrW(Keys.Back) And Not Char.IsSeparator(e.KeyChar) And Not Char.IsLetter(e.KeyChar)
    End Sub
    Private Sub txtLabRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLabRate.KeyPress
        numdotkeypress(e, txtLabRate, Me)
    End Sub
    Private Sub dgvLabList_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvLabList.CellDoubleClick
        If e.RowIndex >= 0 Then
            Fr_Mode = FormState.EStateMode
            txtLabName.Tag = dgvLabList.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtLabName.Text = dgvLabList.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtLabRate.Text = dgvLabList.Rows(e.RowIndex).Cells(2).Value.ToString()
            txtLossWt.Text = dgvLabList.Rows(e.RowIndex).Cells(3).Value.ToString()
        Else
            Me.Clear_Form()
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtLabName_Leave(sender As Object, e As EventArgs) Handles txtLabName.Leave
        txtLabName.Text = ToProper(txtLabName.Text)
    End Sub
    Private Sub frmLabMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub txtLossWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLossWt.KeyPress
        numdotkeypress(e, txtLossWt, Me)
    End Sub
    Private Sub Clear_Form()
        Try
            txtLabName.Clear()
            txtLabName.Tag = ""
            txtLabName.ReadOnly = False

            txtLabRate.Clear()
            txtLabRate.Tag = ""
            txtLabRate.ReadOnly = False

            txtLossWt.Clear()
            txtLossWt.Tag = ""
            txtLossWt.ReadOnly = False

            txtLabName.Focus()
            txtLabName.Select()

            dgvLabList.DataSource = FetchAllRecords()

            Fr_Mode = FormState.AStateMode

            btnSave.Enabled = True
            btnDelete.Enabled = False

            txtLabName.Focus()
            txtLabName.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If Fr_Mode <> FormState.AStateMode Then
                If txtLabName.Tag.Trim = "" Then
                    MessageBox.Show("Select Lab ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtLabName.Focus()
                    Return False
                End If
            End If

            'Assigning Default values
            If txtLabName.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Lab Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtLabName.Focus()
                Return False
            ElseIf txtLabRate.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Lab Amount !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtLabRate.Focus()
                Return False
            ElseIf txtLossWt.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Loss Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtLossWt.Focus()
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
                .Add(dbManager.CreateParameter("@LName", CStr(txtLabName.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
            End With

            Dim strName As Object = dbManager.GetScalarValue("SP_LabMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

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