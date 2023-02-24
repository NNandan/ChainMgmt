Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmOperationMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
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
    Private Sub frmOperationMaster_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Clear_Form()

        Me.fillBagType()
        Me.fillOperationType()

        dgvOperationList.AutoGenerateColumns = False
        dgvOperationList.DataSource = fetchAllRecords()
        dgvOperationList.EnableFiltering = True
        dgvOperationList.MasterTemplate.ShowHeaderCellButtons = True
        dgvOperationList.MasterTemplate.ShowFilteringRow = False
        dgvOperationList.CurrentRow = Nothing
    End Sub
    Private Sub frmOperationMaster_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Me.fillBagType()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Objerr.Clear()

        If Not Validate_Fields() Then Exit Sub

        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If Fr_Mode = FormState.AStateMode Then

                If IsExists() = False Then
                    MessageBox.Show(String.Format("Operation Name {0} already exists.", Me.txtOperationName.Text))
                    Me.txtOperationName.Focus()
                    Exit Sub
                End If

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@OName", txtOperationName.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@BId", cmbBagType.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@OTId", cmbOperationType.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@OMaxValueAllowed", txtMaxLossWt.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With
            Else
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@OId", txtOperationName.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@OName", txtOperationName.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@BId", cmbBagType.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@OTId", cmbOperationType.SelectedValue.ToString(), DbType.Int16))
                    .Add(dbManager.CreateParameter("@OMaxValueAllowed", txtMaxLossWt.Text.Trim, DbType.String))
                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End With
            End If

            dbManager.Insert("SP_OperationMaster_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCancel_Click(sender, e)

            Me.fillBagType()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtOperationName.Tag) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then
                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
                        .Add(dbManager.CreateParameter("@OId", txtOperationName.Tag, DbType.Int16))
                    End With

                    dbManager.Delete("SP_OperationMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.btnCancel_Click(sender, e)

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            Else
                MessageBox.Show("Please Select A Record !!!")
            End If

        End If
    End Sub
    Private Sub fillBagType()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchBagData", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbBagType.DataSource = dt
            cmbBagType.DisplayMember = "ItemName"
            cmbBagType.ValueMember = "ItemId"

            'Newly Added
            cmbBagType.Refresh()
            If cmbBagType.Items.Count > 0 Then cmbBagType.SelectedIndex = 0

            cmbBagType.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbBagType.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillOperationType()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_OperationType_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbOperationType.DataSource = dt
            cmbOperationType.DisplayMember = "OperationType"
            cmbOperationType.ValueMember = "OperationTypeId"

            'Newly Added
            cmbOperationType.Refresh()
            If cmbOperationType.Items.Count > 0 Then cmbOperationType.SelectedIndex = 0

            cmbOperationType.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbOperationType.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Function fetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function fetchAllRecords(ByVal OperationId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@OId", OperationId, DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function fetchAllRecords(ByVal strOperationName As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SearchRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub txtOperationName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOperationName.KeyPress
        e.Handled = e.KeyChar <> ChrW(Keys.Back) And Not Char.IsSeparator(e.KeyChar) And Not Char.IsLetter(e.KeyChar)
    End Sub
    Private Sub txtOperationName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOperationName.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
                CType(Me.ParentForm, frmMain).FormMode.Text = ""
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbBagType_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbBagType.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbOperationType.Focus()
        End If
    End Sub
    Private Sub cmbOperationType_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbOperationType.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMaxLossWt.Focus()
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvOperationList_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvOperationList.CellDoubleClick
        If e.RowIndex >= 0 Then
            Fr_Mode = FormState.EStateMode
            txtOperationName.Tag = dgvOperationList.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtOperationName.Text = dgvOperationList.Rows(e.RowIndex).Cells(1).Value.ToString()
            cmbBagType.SelectedIndex = dgvOperationList.Rows(e.RowIndex).Cells(2).Value.ToString()
            cmbOperationType.SelectedIndex = dgvOperationList.Rows(e.RowIndex).Cells(4).Value.ToString()
            txtMaxLossWt.Text = dgvOperationList.Rows(e.RowIndex).Cells(6).Value.ToString()
            txtOperationName.Focus()
            txtOperationName.Select()
        Else
            Me.Clear_Form()
        End If
    End Sub
    Private Sub txtMaxLossWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMaxLossWt.KeyPress
        numdotkeypress(e, txtMaxLossWt, Me)
    End Sub
    Private Sub txtMaxLossWt_Leave(sender As Object, e As EventArgs) Handles txtMaxLossWt.Leave
        txtMaxLossWt.Text = Format(Val(txtMaxLossWt.Text), "0.000")
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtOperationName_Leave(sender As Object, e As EventArgs) Handles txtOperationName.Leave
        txtOperationName.Text = ToProper(txtOperationName.Text)
    End Sub
    Private Sub frmOperationMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
    Private Sub Clear_Form()
        Try

            btnSave.Text = "&Save"
            txtOperationName.Tag = ""
            txtOperationName.Clear()

            cmbBagType.SelectedIndex = 0
            cmbOperationType.SelectedIndex = 0
            txtMaxLossWt.Clear()

            dgvOperationList.DataSource = fetchAllRecords()

            Fr_Mode = FormState.AStateMode

            btnSave.Enabled = True
            btnDelete.Enabled = False

            txtOperationName.Focus()
            txtOperationName.Select()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If Fr_Mode <> FormState.AStateMode Then
                If txtOperationName.Tag.Trim = "" Then
                    MessageBox.Show("Select Operation ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtOperationName.Focus()
                    Return False
                End If
            End If

            'Assigning Default values
            If txtOperationName.Text.Trim.Length = 0 Then
                Objerr.SetError(txtOperationName, "Enter Operation Name !!!")
                txtOperationName.Focus()
                Return False
            ElseIf cmbBagType.SelectedIndex = -1 Or cmbBagType.SelectedIndex = 0 Then
                MessageBox.Show("Enter Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbBagType.Focus()
                Return False
            ElseIf cmbOperationType.SelectedIndex = -1 Or cmbOperationType.SelectedIndex = 0 Then
                MessageBox.Show("Enter Operation Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbOperationType.Focus()
                Return False
            ElseIf txtMaxLossWt.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Max Value !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtMaxLossWt.Focus()
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
                .Add(dbManager.CreateParameter("@OName", CStr(txtOperationName.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
            End With

            Dim strName As Object = dbManager.GetScalarValue("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

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




