Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmKarigarMaster

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
                    ChkInHouse.Checked = True
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub frmKarigarMaster_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Clear_Form()

        'If dtUserRights.Rows.Count > 0 Then
        '    Dim DTROW() As DataRow = dtUserRights.Select("FormName = 'KARIGAR MASTER'")
        '    USERADD = DTROW(0).Item(3)
        '    USEREDIT = DTROW(0).Item(4)
        '    USERVIEW = DTROW(0).Item(5)
        '    USERDELETE = DTROW(0).Item(6)

        '    If USEREDIT = False And USERDELETE = False Then
        '        MsgBox("Insufficient Rights")
        '        btnDelete.Enabled = False
        '    End If
        'End If

        dgvKarigarList.DataSource = FetchAllRecords()
        dgvKarigarList.CurrentRow = Nothing

        dgvKarigarList.EnableFiltering = True
        dgvKarigarList.MasterTemplate.ShowHeaderCellButtons = True
        dgvKarigarList.MasterTemplate.ShowFilteringRow = False
        dgvKarigarList.CurrentRow = Nothing

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not Validate_Fields() Then Exit Sub

        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If Fr_Mode = FormState.AStateMode Then

                If IsExists() = False Then
                    MessageBox.Show(String.Format("Employee Name. {0} already exists.", Me.txtKarigarName.Text))
                    Me.txtKarigarName.Focus()
                    Exit Sub
                End If

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@LName", txtKarigarName.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@LBoxWeight", txtBoxWt.Text, DbType.Decimal))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                    If ChkInHouse.Checked = True Then
                        .Add(dbManager.CreateParameter("@IsInHouse", 0, DbType.Boolean))
                    End If

                End With
            Else
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@LName", txtKarigarName.Text.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@LBoxWeight", txtBoxWt.Text, DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LId", txtKarigarName.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                    If ChkInHouse.Checked = True Then
                        .Add(dbManager.CreateParameter("@IsInHouse", 0, DbType.Boolean))
                    End If

                End With
            End If

            dbManager.Insert("SP_LabourMaster_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            dtData = dbManager.GetDataTable("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function FetchAllRecords(ByVal iKarigarId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@LId", CInt(iKarigarId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchFancy", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function FetchAllRecords(ByVal sKarigarName As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SearchFancy", DbType.String))
                .Add(dbManager.CreateParameter("@LName", CStr(sKarigarName), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub txtKarigarName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKarigarName.KeyPress
        e.Handled = e.KeyChar <> ChrW(Keys.Back) And Not Char.IsSeparator(e.KeyChar) And Not Char.IsLetter(e.KeyChar)
    End Sub
    Private Sub txtKarigarName_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSave.Select()
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvKarigarList_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvKarigarList.CellDoubleClick
        If e.RowIndex >= 0 Then
            Fr_Mode = FormState.EStateMode
            txtKarigarName.Tag = dgvKarigarList.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtKarigarName.Text = dgvKarigarList.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtBoxWt.Text = Convert.ToString(dgvKarigarList.Rows(e.RowIndex).Cells(2).Value)

            If IsNothing(dgvKarigarList.Rows(e.RowIndex).Cells(3).Value) OrElse String.IsNullOrEmpty(dgvKarigarList.Rows(e.RowIndex).Cells(3).Value) Then
                ChkInHouse.Checked = True
            Else
                ChkInHouse.Checked = False
            End If

            txtKarigarName.Focus()
            txtKarigarName.Select()
            ChkInHouse.Checked = True
        Else
            Me.Clear_Form()
        End If
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtKarigarName.Tag) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
                        .Add(dbManager.CreateParameter("@LId", txtKarigarName.Tag, DbType.Int16))
                    End With

                    dbManager.Delete("SP_LabourMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ChkInHouse.Checked = True
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
    Private Sub txtKarigarName_Leave(sender As Object, e As EventArgs) Handles txtKarigarName.Leave
        txtKarigarName.Text = ToProper(txtKarigarName.Text)
    End Sub
    Private Sub frmKarigarMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            ElseIf e.KeyCode = Keys.Enter Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, False) 'for Select Next Control
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            If (e.Control AndAlso (e.KeyCode = Keys.S)) Then
                ' When Alt + S is pressed, the Click event for the print
                ' button is raised.
                btnSave().PerformClick()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtBoxWt_Leave(sender As Object, e As EventArgs) Handles txtBoxWt.Leave
        txtBoxWt.Text = Format(Val(txtBoxWt.Text), "0.00")
    End Sub
    Private Sub txtBoxWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBoxWt.KeyPress
        numdotkeypress(e, txtBoxWt, Me)
    End Sub
    Private Sub Clear_Form()
        Try
            btnSave.Text = "&Save"
            txtKarigarName.Tag = ""
            txtKarigarName.Clear()
            txtKarigarName.Focus()
            txtBoxWt.Clear()
            txtKarigarName.Select()

            dgvKarigarList.DataSource = FetchAllRecords()

            Fr_Mode = FormState.AStateMode

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If Fr_Mode <> FormState.AStateMode Then
                If txtKarigarName.Tag.Trim = "" Then
                    MessageBox.Show("Select Labour ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtKarigarName.Focus()
                    Return False
                End If
            End If
            'Assigning Default values
            If txtKarigarName.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Labour Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtKarigarName.Focus()
                Return False
            ElseIf txtBoxWt.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Box Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtBoxWt.Focus()
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
                .Add(dbManager.CreateParameter("@LName", CStr(txtKarigarName.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
            End With

            Dim strName As Object = dbManager.GetScalarValue("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

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