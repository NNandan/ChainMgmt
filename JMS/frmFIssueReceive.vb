Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports System.ComponentModel
Imports Telerik.WinControls.Data
Public Class frmFIssueReceive
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT
    Dim iclicked As Boolean = False   ''Used for Checking cmbLotNo Index changed
    Dim intOpId As Int16
    Dim strLotNo As String
    Private mFr_State As FormState
    Dim strSQL As String = Nothing
    Dim TempRow As Integer
    Dim IGridDoubleClick As Boolean
    Dim RGridDoubleClick As Boolean
    Dim blnRecieveStatus As Boolean
    Dim blnIssueStatus As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

    Private clicked As Boolean = False
    Private Objerr As New ErrorProvider()
    Dim dblMaxLossAllow As Double = 0
    Private Sub frmIssueReceive_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLotNo()
        Me.fillMaterial()
        Me.Clear_Form()
        btnDelete.Enabled = False
    End Sub
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
    Private Sub btnReceive_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        Me.ClearInputs()
        btnSave.Text = "&Save"

        If cmbLotNo.SelectedIndex > -1 And dgvIssue.RowCount > 0 Then
            Me.EnbledRBtn()
        Else
            MessageBox.Show("Select Lot No. Or No Issue Detals found")
        End If
    End Sub
    Private Sub fillLotNo()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillNewLotNoCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()
        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            'Assign DataTable as DataSource.
            cmbLotNo.DataSource = dt
            Me.cmbLotNo.AutoFilter = True
            cmbLotNo.DisplayMember = "LotNo"
            cmbLotNo.ValueMember = "NewLotId"
            cmbLotNo.Text = ""
            cmbLotNo.Refresh()
            cmbLotNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbLotNo.BestFitColumns(True, False)
            cmbLotNo.Columns(0).IsVisible = False
            cmbLotNo.Columns(3).Width = 150
            cmbLotNo.Columns(3).TextAlignment = ContentAlignment.MiddleRight
            Me.cmbLotNo.MultiColumnComboBoxElement.DropDownWidth = 250
            Me.BackColor = Color.White

            Dim filter As New FilterDescriptor()
            filter.PropertyName = Me.cmbLotNo.DisplayMember
            filter.Operator = FilterOperator.Contains

            Me.cmbLotNo.EditorControl.MasterTemplate.FilterDescriptors.Add(filter)

            AddHandler cmbLotNo.MultiColumnComboBoxElement.EditorControl.CustomFiltering, AddressOf cmbLotNo_EditorControl_CustomFiltering
            AddHandler cmbLotNo.KeyDown, AddressOf cmbLotNo_KeyDown
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
            Me.Controls.Clear()
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub btnIssue_Click(sender As Object, e As EventArgs) Handles btnIssue.Click
        Me.ClearInputs()
        btnSave.Text = "&Save"
        If cmbLotNo.SelectedIndex > -1 Then
            Me.EnbledIBtn()
        Else
            MessageBox.Show("Select Lot No...")
        End If
    End Sub
    Private Sub txtRQty_Validating(sender As Object, e As CancelEventArgs) Handles txtRQty.Validating
        Try
            If cmbRMaterial.Text.Trim <> "" And cmbRItem.Text.Trim <> "" And Val(txtRWt.Text.Trim) > 0 And Val(txtRQty.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                'If dgvReceive.Rows.Count > 0 AndAlso ChkRDuplicate() = True Then
                '    MsgBox("Duplicate Data")
                'Else
                '    'Me.fillRGrid()
                '    'Me.RTotal()
                'End If
            Else
                'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillMaterial()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillMaterialCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_MaterialMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim Odt As DataTable = New DataTable()
        Odt.Load(dr)
        Dim Cdt As DataTable = Odt.Copy()
        Try
            ''Insert the Default Item to DataTable.
            Dim frow As DataRow = Odt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            Odt.Rows.InsertAt(frow, 0)
            ''Assign DataTable as DataSource.
            cmbRMaterial.DataSource = Odt
            cmbRMaterial.DisplayMember = "MaterialName"
            cmbRMaterial.ValueMember = "MaterialId"
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = Cdt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            Cdt.Rows.InsertAt(trow, 0)
            cmbIMaterial.DataSource = Cdt
            cmbIMaterial.DisplayMember = "MaterialName"
            cmbIMaterial.ValueMember = "MaterialId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub EnbledIBtn()
        If IGridDoubleClick = False Then
            blnIssueStatus = True
            blnRecieveStatus = False
            GBoxIssue.Enabled = True
            cmbIMaterial.Enabled = True
            cmbIItem.Enabled = True
            txtIWt.Enabled = True
            txtIQty.Enabled = True
            If Val(txtOpreationType.Tag) = 3 Or Val(txtOpreationType.Tag) = 4 Or Val(txtOpreationType.Tag) = 6 Then
                cmbIMaterial.Enabled = True
            Else
                cmbIMaterial.SelectedIndex = 1
                cmbIMaterial.Enabled = False
            End If
            cmbIItem.SelectedIndex = 0
            txtIWt.Clear()
            txtIQty.Text = 1.0
            cmbRMaterial.SelectedIndex = 0
            cmbRItem.SelectedIndex = 0
            txtRWt.Clear()
            txtRQty.Clear()
            cmbRMaterial.Enabled = False
            cmbRItem.Enabled = False
            txtRWt.Enabled = False
            txtRQty.Enabled = False
            btnIssue.Enabled = True
            cmbIMaterial.Focus()
        Else
            blnIssueStatus = True
            blnRecieveStatus = False
            GBoxIssue.Enabled = True
            cmbIMaterial.Enabled = True
            cmbIItem.Enabled = True
            txtIWt.Enabled = True
            txtIQty.Enabled = True
            If Val(txtOpreationType.Tag) = 3 Or Val(txtOpreationType.Tag) = 4 Or Val(txtOpreationType.Tag) = 6 Then
                cmbIMaterial.Enabled = True
            Else
                cmbIMaterial.SelectedIndex = 1
                cmbIMaterial.Enabled = False
            End If
            cmbRItem.Enabled = False
            txtRWt.Enabled = False
            txtRQty.Enabled = False
            cmbIMaterial.Focus()
        End If
    End Sub
    Private Sub EnbledRBtn()
        If RGridDoubleClick = False Then
            blnRecieveStatus = True
            blnIssueStatus = False
            GBoxReceive.Enabled = True
            cmbRMaterial.Enabled = True
            cmbRItem.Enabled = True
            txtRWt.Enabled = True
            txtRQty.Enabled = True
            If Val(txtOpreationType.Tag) = 3 Or Val(txtOpreationType.Tag) = 4 Or Val(txtOpreationType.Tag) = 6 Then
                cmbRMaterial.Enabled = True
            Else
                cmbRMaterial.SelectedIndex = 1
                cmbRMaterial.Enabled = False
            End If
            cmbRItem.SelectedIndex = 0
            txtRWt.Clear()
            txtRQty.Text = 1.0
            cmbIMaterial.SelectedIndex = 0
            cmbIItem.SelectedIndex = 0
            txtIWt.Clear()
            txtIQty.Clear()
            cmbIMaterial.Enabled = False
            cmbIItem.Enabled = False
            txtIWt.Enabled = False
            txtIQty.Enabled = False
            btnReceive.Enabled = True
            cmbRMaterial.Focus()
        Else
            blnRecieveStatus = True
            blnIssueStatus = False
            GBoxReceive.Enabled = True
            cmbIMaterial.Enabled = False
            cmbIItem.Enabled = False
            txtIWt.Enabled = False
            txtIQty.Enabled = False
            If Val(txtOpreationType.Tag) = 3 Or Val(txtOpreationType.Tag) = 4 Or Val(txtOpreationType.Tag) = 6 Then
                cmbRMaterial.Enabled = True
            Else
                cmbRMaterial.SelectedIndex = 1
                cmbRMaterial.Enabled = False
            End If
            cmbRItem.Enabled = True
            txtRWt.Enabled = True
            txtRQty.Enabled = True
            cmbRMaterial.Focus()
        End If
    End Sub
    Sub fillRGrid()
        If RGridDoubleClick = False Then
            dgvReceive.Rows.Add(Val(cmbRMaterial.SelectedValue),
                                    CStr(cmbRMaterial.Text.Trim),
                                    Val(cmbRItem.SelectedValue),
                                    CStr(cmbRItem.Text.Trim),
                                    Format(Val(txtRWt.Text.Trim), "0.00"),
                                    Format(Val(txtRQty.Text.Trim), "0.00"))
            GetRSrNo(dgvReceive)
        Else
            dgvReceive.Rows(TempRow).Cells(0).Value = Val(cmbRMaterial.SelectedValue)
            dgvReceive.Rows(TempRow).Cells(1).Value = CStr(cmbRMaterial.Text.Trim)
            dgvReceive.Rows(TempRow).Cells(2).Value = Val(cmbRMaterial.SelectedValue)
            dgvReceive.Rows(TempRow).Cells(3).Value = CStr(cmbRMaterial.Text.Trim)
            dgvReceive.Rows(TempRow).Cells(4).Value = txtRWt.Text.Trim
            dgvReceive.Rows(TempRow).Cells(5).Value = txtRQty.Text.Trim
            RGridDoubleClick = False
        End If
        Me.RTotal()
        dgvReceive.TableElement.ScrollToRow(dgvReceive.Rows.Last)
        cmbRMaterial.SelectedIndex = 0
        cmbRItem.SelectedIndex = 0
        txtRWt.Clear()
        txtRQty.Clear()
        cmbRMaterial.Focus()
    End Sub
    Sub fillIGrid()
        If IGridDoubleClick = False Then
            dgvIssue.Rows.Add(Val(cmbIMaterial.SelectedValue),
                                    CStr(cmbIMaterial.Text.Trim),
                                    Val(cmbIItem.SelectedValue),
                                    CStr(cmbIItem.Text.Trim),
                                    Format(Val(txtIWt.Text.Trim), "0.00"),
                                    Format(Val(txtIQty.Text.Trim), "0.00"))
            GetISrNo(dgvIssue)
        Else
            dgvIssue.Rows(TempRow).Cells(0).Value = Val(cmbIMaterial.SelectedValue)
            dgvIssue.Rows(TempRow).Cells(1).Value = CStr(cmbIMaterial.Text.Trim)
            dgvIssue.Rows(TempRow).Cells(2).Value = Val(cmbRItem.SelectedValue)
            dgvIssue.Rows(TempRow).Cells(3).Value = CStr(cmbRItem.Text.Trim)
            dgvIssue.Rows(TempRow).Cells(4).Value = txtIWt.Text.Trim
            dgvIssue.Rows(TempRow).Cells(5).Value = txtIQty.Text.Trim
            IGridDoubleClick = False
        End If
        Me.RTotal()
        dgvIssue.TableElement.ScrollToRow(dgvIssue.Rows.Last)
        cmbIMaterial.SelectedIndex = 0
        cmbIItem.SelectedIndex = 0
        txtIWt.Clear()
        txtIQty.Clear()
        cmbIMaterial.Focus()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub
        Try
            If Fr_Mode = FormState.AStateMode And btnSave.Text = "&Save" Then
                If blnRecieveStatus = True Then
                    Me.SaveRData()
                    'Me.btnCancel_Click(sender, e)
                    Me.ClearInputs()
                Else
                    Me.SaveIData()
                    'Me.btnCancel_Click(sender, e)
                    Me.ClearInputs()
                End If
            Else
                If blnRecieveStatus = True Then
                    Me.UpdateRData()
                    'Me.btnCancel_Click(sender, e)
                    Me.ClearInputs()
                Else
                    Me.UpdateIData()
                    'Me.btnCancel_Click(sender, e)
                    Me.ClearInputs()
                End If
            End If
            'Me.Controls.Clear()
            'InitializeComponent()
            'Me.frmIssueReceive_Load(e, e)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.BindReceiveDetails()
            Me.BindIssueDetails()
        End Try
    End Sub
    Private Sub ClearInputs()
        btnDelete.Enabled = False
        btnSave.Text = "&Save"
        GBoxReceive.Enabled = True
        cmbRMaterial.SelectedIndex = 0
        cmbRItem.SelectedIndex = 0
        txtRWt.Clear()
        txtRQty.Clear()
        cmbRMaterial.Enabled = False
        cmbRItem.Enabled = False
        txtRWt.Enabled = False
        txtRQty.Enabled = False
        ChkRWrkDone.Checked = False
        ChkIWrkDone.Checked = False
        GBoxIssue.Enabled = True
        cmbIMaterial.SelectedIndex = 0
        cmbIItem.SelectedIndex = 0
        txtIWt.Clear()
        txtIQty.Clear()
        cmbIMaterial.Enabled = False
        cmbIItem.Enabled = False
        txtIWt.Enabled = False
        txtIQty.Enabled = False
        IGridDoubleClick = False
        RGridDoubleClick = False
        lblRTotalWt.Text = 0.0
        lblRTotalQty.Text = 0.0
        lblITotalWt.Text = 0.00
        lblITotalQty.Text = 0.00
    End Sub
    Sub GetRSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvReceive.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub GetISrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvIssue.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function ChkRDuplicate() As Boolean
        Dim exists As Boolean = False
        If RGridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvReceive.Rows
                If itm.Cells(3).Value = CStr(cmbRItem.Text.Trim) Then
                    exists = True
                End If
            Next
        End If
        Return exists
    End Function
    Private Function ChkIDuplicate() As Boolean
        Dim exists As Boolean = False
        If IGridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvIssue.Rows
                If itm.Cells(3).Value = CStr(cmbIItem.Text.Trim) Then
                    exists = True
                End If
            Next
        End If
        Return exists
    End Function
    Private Function Validate_Fields() As Boolean
        Try
            If cmbRMaterial.Enabled = True And cmbIMaterial.Enabled = True Then
                MessageBox.Show("Cannot Save Receive and Issue Detail Information at Same Time!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If
            'If cmbLotNo.SelectedIndex = -1 Or cmbLotNo.SelectedIndex = 0 Then
            If cmbLotNo.SelectedIndex = -1 Then
                MessageBox.Show("Select Lot No. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            ElseIf txtMelting.Text.Trim.Length = 0 Then
                MessageBox.Show("Select Melting Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtMelting.Focus()
                Return False
            End If
            If blnRecieveStatus = True Then
                If cmbRMaterial.SelectedIndex = -1 Or cmbRMaterial.SelectedIndex = 0 Then
                    MessageBox.Show("Select Material Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    cmbRMaterial.Focus()
                    Return False
                    'ElseIf cmbRItem.SelectedIndex = -1 Or cmbRItem.SelectedIndex = 0 Then
                    '    MessageBox.Show("Select Receive Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    '    cmbRItem.Focus()
                    '    Return False
                    'ElseIf cmbRItem.SelectedItem.Text.Trim.Length = 0 Then
                    '    MessageBox.Show("Select Receive Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    '    cmbRItem.Focus()
                    '    Return False
                ElseIf txtRQty.Text.Trim.Length = 0 Then
                    MessageBox.Show("Enter Receive Qty !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    txtRQty.Focus()
                    Return False
                End If
            Else
                If cmbIMaterial.SelectedIndex = -1 Or cmbIMaterial.SelectedIndex = 0 Then
                    MessageBox.Show("Select Material Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    cmbIMaterial.Focus()
                    Return False
                    'ElseIf cmbIItem.SelectedIndex = -1 Or cmbIItem.SelectedIndex = 0 Then
                    '    MessageBox.Show("Select Issue Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    '    cmbIItem.Focus()
                    '    Return False
                    'ElseIf cmbIItem.SelectedItem.Text.Trim.Length = 0 Then
                    '    MessageBox.Show("Select Issue Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    '    cmbIItem.Focus()
                    '    Return False
                ElseIf txtIQty.Text.Trim.Length = 0 Then
                    MessageBox.Show("Enter Issue Qty !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                    txtIQty.Focus()
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub txtIQty_Validating(sender As Object, e As CancelEventArgs) Handles txtIQty.Validating
        Try
            If cmbIMaterial.Text.Trim <> "" And cmbIItem.Text.Trim <> "" And Val(txtIWt.Text.Trim) > 0 And Val(txtIQty.Text.Trim) > 0 Then
                'ErrorProvider1.SetError(txtRequirePr, "")
                'If dgvIssue.Rows.Count > 0 AndAlso ChkIDuplicate() = True Then
                '    MsgBox("Duplicate Data")
                'Else
                '    'Me.fillIGrid()
                '    'Me.ITotal()
                'End If
            Else
                'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveRData()
        Try
            Dim Hparameters = New List(Of SqlParameter)()

            With Hparameters
                .Clear()
                .Add(dbManager.CreateParameter("@DMaterialId", Val(cmbRMaterial.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@DItemId", Val(cmbRItem.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(cmbLotNo.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DReceiveWt", (txtRWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DReceiveQty", (txtRQty.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))

                If ChkRWrkDone.Checked = True Then
                    .Add(dbManager.CreateParameter("@IsWorkDone", 1, DbType.Boolean))
                Else
                    .Add(dbManager.CreateParameter("@IsWorkDone", 0, DbType.Boolean))
                End If

            End With
            dbManager.Insert("SP_FReceive_Save", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.BindReceiveDetails()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateRData()
        Dim strLotNo As String = Nothing
        Dim strItemId As String = Nothing
        If cmbLotNo.SelectedIndex >= 0 Then
            Dim value As Object = cmbLotNo.EditorControl.Rows(cmbLotNo.SelectedIndex).Cells("LotNo").Value
            If Not value Is Nothing Then
                strLotNo = Convert.ToString(value)
            End If
        End If
        If cmbRItem.SelectedIndex = -1 Then
            Dim value As Object = cmbRItem.ValueMember(cmbRItem.SelectedValue)
            If Not value Is Nothing Then
                strItemId = Convert.ToString(value)
            End If
        End If

        Try
            Dim Hparameters = New List(Of SqlParameter)()

            With Hparameters
                .Clear()
                .Add(dbManager.CreateParameter("@DMaterialId", (cmbRMaterial.SelectedValue), DbType.Int16))
                If cmbRItem.SelectedIndex = -1 Then
                    .Add(dbManager.CreateParameter("@DItemId", Val(txtRWt.Tag), DbType.Int16))
                Else
                    .Add(dbManager.CreateParameter("@DItemId", Val(cmbRItem.SelectedValue), DbType.Int16))
                End If
                .Add(dbManager.CreateParameter("@ReceiveId", Val(txtRQty.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(strLotNo), DbType.String))
                .Add(dbManager.CreateParameter("@DReceiveWt", (txtRWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DReceiveQty", (txtRQty.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))
                If ChkRWrkDone.Checked = True Then
                    .Add(dbManager.CreateParameter("@IsWorkDone", 1, DbType.Boolean))
                Else
                    .Add(dbManager.CreateParameter("@IsWorkDone", 0, DbType.Boolean))
                End If
            End With
            dbManager.Insert("SP_FReceive_Update", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.BindReceiveDetails()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateIData()
        Dim strLotNo As String = Nothing
        Dim strItemId As String = Nothing
        If cmbLotNo.SelectedIndex >= 0 Then
            Dim value As Object = cmbLotNo.EditorControl.Rows(cmbLotNo.SelectedIndex).Cells("LotNo").Value
            If Not value Is Nothing Then
                strLotNo = Convert.ToString(value)
            End If
        End If
        If cmbIItem.SelectedIndex = -1 Then
            Dim value As Object = cmbIItem.ValueMember(cmbIItem.SelectedValue)
            If Not value Is Nothing Then
                strItemId = Convert.ToString(value)
            End If
        End If
        Try
            Dim Hparameters = New List(Of SqlParameter)()

            With Hparameters
                .Clear()
                .Add(dbManager.CreateParameter("@DMaterialId", (cmbIMaterial.SelectedValue), DbType.Int16))
                If cmbIItem.SelectedIndex = -1 Then
                    .Add(dbManager.CreateParameter("@DItemId", Val(txtIWt.Tag), DbType.Int16))
                Else
                    .Add(dbManager.CreateParameter("@DItemId", Val(cmbIItem.SelectedValue), DbType.Int16))
                End If

                .Add(dbManager.CreateParameter("@IssueId", Val(txtIQty.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(strLotNo), DbType.String))
                .Add(dbManager.CreateParameter("@DIssueWt", (txtIWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DIssueQty", (txtIQty.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))

                If ChkIWrkDone.Checked = True Then
                    .Add(dbManager.CreateParameter("@IsWorkDone", 1, DbType.Boolean))
                Else
                    .Add(dbManager.CreateParameter("@IsWorkDone", 0, DbType.Boolean))
                End If
            End With

            dbManager.Insert("SP_FIssue_Update", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Sub RTotal()
        lblRTotalWt.Text = 0.00
        lblRTotalQty.Text = 0.00
        Try
            For Each row As GridViewRowInfo In dgvReceive.Rows
                lblRTotalWt.Text = Format(Val(lblRTotalWt.Text) + Val(row.Cells(4).Value), "0.00")
                lblRTotalQty.Text = Format(Val(lblRTotalQty.Text) + Val(row.Cells(5).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveIData()
        Try
            Dim Hparameters = New List(Of SqlParameter)()

            With Hparameters
                .Clear()
                .Add(dbManager.CreateParameter("@DMaterialId", Val(cmbIMaterial.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@DItemId", Val(cmbIItem.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(cmbLotNo.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DIssueWt", (txtIWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DIssueQty", (txtIQty.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))

                If ChkIWrkDone.Checked = True Then
                    .Add(dbManager.CreateParameter("@IsWorkDone", 1, DbType.Boolean))
                Else
                    .Add(dbManager.CreateParameter("@IsWorkDone", 0, DbType.Boolean))
                End If
            End With
            dbManager.Insert("SP_FIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnFinalize_Click(sender As Object, e As EventArgs) Handles btnFinalize.Click

        Dim dRtotalWt As Double
        Dim dItotalWt As Double
        Dim sLotNo As String = Nothing
        Dim iOpId As Int16
        Dim dLossAllowed As Double = 0
        ''If cmbLotNo.SelectedIndex = -1 Or cmbLotNo.SelectedIndex = 0 Then
        If cmbLotNo.SelectedIndex = -1 Then
            MessageBox.Show("Select Lot No. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLotNo.Focus()
            Exit Sub
        End If
        Try
            ''Show_ChildForm("frmFinalizeLot", Me.MdiParent, Me.Tag)
            dRtotalWt = lblRTotalWt.Text
            dItotalWt = lblITotalWt.Text
            sLotNo = cmbLotNo.Text.Trim
            iOpId = txtOperation.Tag
            dLossAllowed = dblMaxLossAllow
            Dim frm As New frmFFinalizeLot(sLotNo, iOpId, dLossAllowed)
            frm.ShowDialog()
            frm.BringToFront()
            frm.Focus()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Sub ITotal()
        lblITotalWt.Text = 0.00
        lblITotalQty.Text = 0.00
        Try
            For Each row As GridViewRowInfo In dgvIssue.Rows
                lblITotalWt.Text = Format(Val(lblITotalWt.Text) + Val(row.Cells(4).Value), "0.00")
                lblITotalQty.Text = Format(Val(lblITotalQty.Text) + Val(row.Cells(5).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbRMaterial_GotFocus(sender As Object, e As EventArgs) Handles cmbRMaterial.GotFocus
        cmbRMaterial.ShowDropDown()
    End Sub
    Private Sub cmbIMaterial_GotFocus(sender As Object, e As EventArgs) Handles cmbIMaterial.GotFocus
        cmbIMaterial.ShowDropDown()
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        If cmbLotNo.SelectedIndex > -1 Then
            Me.BindReceiveDetails()
            Me.BindIssueDetails()
        End If
    End Sub
    Private Sub btnDetails_Click(sender As Object, e As EventArgs) Handles btnDetails.Click
        Try
            Dim frm As New frmFDetails()
            frm.ShowDialog()
            frm.BringToFront()
            frm.Focus()
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Private Sub txtIWt_Leave(sender As Object, e As EventArgs) Handles txtIWt.Leave
        txtIWt.Text = Format(Val(txtIWt.Text), "0.00")
    End Sub
    Private Sub txtIQty_Leave(sender As Object, e As EventArgs) Handles txtIQty.Leave
        txtIQty.Text = Format(Val(txtIQty.Text), "0.00")
    End Sub
    Private Sub txtRWt_Leave(sender As Object, e As EventArgs) Handles txtRWt.Leave
        txtRWt.Text = Format(Val(txtRWt.Text), "0.00")
    End Sub
    Private Sub txtRQty_Leave(sender As Object, e As EventArgs) Handles txtRQty.Leave
        txtRQty.Text = Format(Val(txtRQty.Text), "0.00")
    End Sub
    Private Sub btnNewLot_Click(sender As Object, e As EventArgs) Handles btnNewLot.Click
        Dim frm As New frmNewLotNo
        frm.ShowDialog()
        frm.BringToFront()
        frm.Focus()
    End Sub
    Private Sub WtLotClear()
        btnDelete.Enabled = False
        '' For Receive Detail Field Start
        GBoxReceive.Enabled = True
        cmbRMaterial.SelectedIndex = 0
        cmbRItem.SelectedIndex = 0
        txtRWt.Clear()
        txtRQty.Clear()
        cmbRMaterial.Enabled = False
        cmbRItem.Enabled = False
        txtRWt.Enabled = False
        txtRQty.Enabled = False
        ChkRWrkDone.Checked = False
        ChkIWrkDone.Checked = False
        GBoxIssue.Enabled = True
        cmbIMaterial.SelectedIndex = 0
        cmbIItem.SelectedIndex = 0
        txtIWt.Clear()
        txtIQty.Clear()
        cmbIMaterial.Enabled = False
        cmbIItem.Enabled = False
        txtIWt.Enabled = False
        txtIQty.Enabled = False
        IGridDoubleClick = False
        RGridDoubleClick = False
        lblRTotalWt.Text = 0.0
        lblRTotalQty.Text = 0.0
        lblITotalWt.Text = 0.00
        lblITotalQty.Text = 0.00
        'Fr_Mode = FormState.AStateMode
        txtOrderNo.Text = ""
        txtItem.Text = ""
        txtOperation.Text = ""
        txtMelting.Text = ""
        txtLabour.Text = ""
        txtOpreationType.Text = ""
        txtMelting.Text = ""
    End Sub
    Private Sub Clear_Form()
        Try
            btnDelete.Enabled = False
            '' For Receive Detail Field Start
            GBoxReceive.Enabled = True
            cmbRMaterial.SelectedIndex = 0
            cmbRItem.SelectedIndex = 0
            txtRWt.Clear()
            txtRQty.Clear()
            cmbRMaterial.Enabled = False
            cmbRItem.Enabled = False
            txtRWt.Enabled = False
            txtRQty.Enabled = False
            ChkRWrkDone.Checked = False
            ChkIWrkDone.Checked = False
            GBoxIssue.Enabled = True
            cmbIMaterial.SelectedIndex = 0
            cmbIItem.SelectedIndex = 0
            txtIWt.Clear()
            txtIQty.Clear()
            cmbIMaterial.Enabled = False
            cmbIItem.Enabled = False
            txtIWt.Enabled = False
            txtIQty.Enabled = False
            IGridDoubleClick = False
            RGridDoubleClick = False
            lblRTotalWt.Text = 0.0
            lblRTotalQty.Text = 0.0
            lblITotalWt.Text = 0.00
            lblITotalQty.Text = 0.00
            'Fr_Mode = FormState.AStateMode
            txtOrderNo.Text = ""
            txtItem.Text = ""
            txtOperation.Text = ""
            txtMelting.Text = ""
            txtLabour.Text = ""
            txtOpreationType.Text = ""
            txtMelting.Text = ""
            cmbLotNo.SelectedIndex = 0
            cmbLotNo.Refresh()
            cmbLotNo.Focus()
            cmbLotNo.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BindReceiveDetails()
        Dim dtdata As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchRData", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", cmbLotNo.Text.ToString, DbType.String))
        End With
        dtdata = dbManager.GetDataTable("SP_ReceiveDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        dgvReceive.DataSource = Nothing
        Try
            If dtdata.Rows.Count > 0 Then
                dgvReceive.DataSource = dtdata
                dgvReceive.EnableFiltering = True
                dgvReceive.MasterTemplate.ShowFilteringRow = False
                dgvReceive.MasterTemplate.ShowHeaderCellButtons = True
                Me.RTotal()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub BindIssueDetails()
        Dim dtdata As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchIData", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", cmbLotNo.Text.ToString, DbType.String))
        End With
        dtdata = dbManager.GetDataTable("SP_IssueDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        dgvIssue.DataSource = Nothing
        Try
            If dtdata.Rows.Count > 0 Then
                dgvIssue.DataSource = dtdata
                dgvIssue.EnableFiltering = True
                dgvIssue.MasterTemplate.ShowFilteringRow = False
                dgvIssue.MasterTemplate.ShowHeaderCellButtons = True
                Me.ITotal()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub txtRWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRWt.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    Private Sub dgvIssue_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvIssue.CellDoubleClick
        Try
            btnDelete.Enabled = True
            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And dgvIssue.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                IGridDoubleClick = True
                If dgvIssue.Rows(e.RowIndex).Cells(0).Value.ToString() = "1" Then
                    cmbIMaterial.SelectedIndex = dgvIssue.Rows(e.RowIndex).Cells(0).Value.ToString()
                    cmbIItem.SelectedValue = dgvIssue.Rows(e.RowIndex).Cells(2).Value.ToString()
                    txtIWt.Tag = ""
                    txtIWt.Tag = dgvIssue.Rows(e.RowIndex).Cells(2).Value.ToString()
                    cmbIItem.Text = ""
                    cmbIItem.SelectedText = dgvIssue.Rows(e.RowIndex).Cells(3).Value.ToString()
                    txtIWt.Text = CStr(dgvIssue.Rows(e.RowIndex).Cells(4).Value)
                    txtIQty.Text = CStr(dgvIssue.Rows(e.RowIndex).Cells(5).Value)
                    txtIQty.Tag = Val(dgvIssue.Rows(e.RowIndex).Cells(6).Value)
                    TempRow = e.RowIndex
                    Fr_Mode = FormState.EStateMode
                    Me.EnbledIBtn()
                Else
                    Dim sLotNo As String = Nothing
                    Dim MaterialId As String = Nothing
                    Dim IssueId As String = Nothing
                    Dim ItemId As String = Nothing

                    If cmbLotNo.SelectedIndex = -1 Then
                        MessageBox.Show("Select Lot No. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        cmbLotNo.Focus()
                        Exit Sub
                    End If
                    Try
                        sLotNo = cmbLotNo.Text.Trim
                        ' For Each row As GridViewRowInfo In dgvReceive.Rows
                        MaterialId = dgvIssue.Rows(e.RowIndex).Cells(0).Value.ToString()
                        IssueId = dgvIssue.Rows(e.RowIndex).Cells(6).Value.ToString()
                        ' Next
                        Me.Close()
                        Dim Objfrm As New frmFReceiveGoldOthers(sLotNo, MaterialId, IssueId, ItemId)
                        Objfrm.ShowDialog()
                        Objfrm.BringToFront()
                        Objfrm.Focus()
                    Catch ex As Exception
                        MessageBox.Show("Error:- " & ex.Message)
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLotNo.SelectedIndexChanged
        Me.WtLotClear()
        Me.ClearInputs()
        If cmbLotNo.SelectedIndex > 0 Then
            Dim cWorkDone As Char = Nothing
            Dim dt As DataTable = New DataTable()
            If cmbLotNo.SelectedIndex > -1 Then
                iclicked = False
                btnDetails.Enabled = True
                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderForTrans", DbType.String))
                    .Add(dbManager.CreateParameter("@NLotNo", cmbLotNo.EditorControl.Rows(cmbLotNo.SelectedIndex).Cells(1).Value, DbType.String))
                End With
                Dim dr As SqlDataReader = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())
                If dr.HasRows = True Then
                    dr.Read()
                    txtMelting.Tag = dr.Item("MeltingId").ToString
                    txtMelting.Text = dr.Item("MeltingValue").ToString
                    txtItem.Tag = dr.Item("ItemId").ToString
                    txtItem.Text = dr.Item("ItemName").ToString
                    txtOperation.Tag = dr.Item("OperationTypeId").ToString
                    txtOperation.Text = dr.Item("OperationName").ToString
                    txtLabour.Tag = dr.Item("LabourId").ToString
                    txtLabour.Text = dr.Item("LabourName").ToString
                    txtOrderNo.Text = dr.Item("orderNo").ToString
                    txtOpreationType.Tag = dr.Item("OperationTypeId").ToString
                    txtOpreationType.Text = dr.Item("OperationType").ToString
                    'To Form Simplicity Avoiding User Confusion when receive Gold Button click on which OperationId
                    If txtOpreationType.Text = "Metal Setting" Or txtOpreationType.Text = "Stock Addition" Then
                        'btnRecGold.Enabled = True
                        btnRecGold.Visible = True
                    Else
                        'btnRecGold.Enabled = False
                        btnRecGold.Visible = False
                    End If
                    dblMaxLossAllow = dr.Item("MaxValueAllowed")
                    cWorkDone = dr.Item("WorkDoneAllowed")

                    If cWorkDone = "I" Then
                        ChkIWrkDone.Enabled = True
                        ChkRWrkDone.Enabled = False
                    Else
                        ChkRWrkDone.Enabled = True
                        ChkIWrkDone.Enabled = False
                    End If
                End If
                Me.btnShow.PerformClick()
                dr.Close()
                Objcn.Close()
                Exit Sub
ErrHandler:
                MsgBox(Err.Description, MsgBoxStyle.Critical)
            End If
        End If
    End Sub
    Private Sub dgvReceive_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvReceive.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And dgvReceive.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                RGridDoubleClick = True
                If dgvReceive.Rows(e.RowIndex).Cells(0).Value.ToString() = "1" Then
                    cmbRMaterial.SelectedIndex = dgvReceive.Rows(e.RowIndex).Cells(0).Value.ToString()
                    cmbRItem.SelectedValue = dgvReceive.Rows(e.RowIndex).Cells(2).Value.ToString()
                    txtRWt.Tag = ""
                    txtRWt.Tag = dgvReceive.Rows(e.RowIndex).Cells(2).Value.ToString()
                    cmbRItem.Text = ""
                    cmbRItem.SelectedText = dgvReceive.Rows(e.RowIndex).Cells(3).Value.ToString()
                    txtIWt.Tag = dgvReceive.Rows(e.RowIndex).Cells(2).Value.ToString()
                    txtRWt.Text = CDbl(dgvReceive.Rows(e.RowIndex).Cells(4).Value)
                    txtRQty.Text = CDbl(dgvReceive.Rows(e.RowIndex).Cells(5).Value)
                    txtRQty.Tag = Val(dgvReceive.Rows(e.RowIndex).Cells(6).Value)
                    If Convert.ToBoolean(dgvReceive.Rows(e.RowIndex).Cells(7).Value) Then
                        ChkRWrkDone.Checked = True
                    Else
                        ChkRWrkDone.Checked = False
                    End If
                    TempRow = e.RowIndex
                    Fr_Mode = FormState.EStateMode
                    Me.EnbledRBtn()
                Else
                    Dim sLotNo As String = Nothing
                    Dim MaterialId As String = Nothing
                    Dim ReceiveId As String = Nothing
                    If cmbLotNo.SelectedIndex = -1 Then
                        MessageBox.Show("Select Lot No. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                        cmbLotNo.Focus()
                        Exit Sub
                    End If
                    Try
                        sLotNo = cmbLotNo.Text.Trim
                        ' For Each row As GridViewRowInfo In dgvReceive.Rows
                        MaterialId = dgvReceive.Rows(e.RowIndex).Cells(0).Value.ToString()
                        ReceiveId = dgvReceive.Rows(e.RowIndex).Cells(6).Value.ToString()
                        Dim Objfrm As New frmFReceiveGoldOthers(sLotNo, MaterialId, ReceiveId)
                        Objfrm.ShowDialog()
                        Objfrm.BringToFront()
                        Objfrm.Focus()
                        Me.Close()
                    Catch ex As Exception
                        MessageBox.Show("Error:- " & ex.Message)
                    End Try
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Refresh_Form()
        Try
            txtOrderNo.Clear()
            txtItem.Clear()
            txtOpreationType.Clear()
            txtOperation.Clear()
            txtLabour.Clear()
            txtMelting.Clear()
            dgvIssue.DataSource = Nothing
            dgvReceive.DataSource = Nothing
            lblRTotalWt.Text = 0.0
            lblRTotalQty.Text = 0.0
            lblITotalWt.Text = 0.00
            lblITotalQty.Text = 0.00
            Fr_Mode = FormState.AStateMode
            cmbLotNo.Focus()
            cmbLotNo.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtIWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIWt.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    Private Sub cmbRMaterial_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbRMaterial.SelectedIndexChanged
        cmbRItem.DataSource = Nothing
        cmbRItem.Enabled = False
        If cmbRMaterial.SelectedValue.ToString() <> "0" Then
            fillMaterialWiseItem(cmbRMaterial.SelectedIndex)
            cmbRItem.Enabled = True
        End If
    End Sub
    Private Sub cmbIMaterial_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbIMaterial.SelectedIndexChanged
        cmbIItem.DataSource = Nothing
        cmbIItem.Enabled = False
        If cmbIMaterial.SelectedValue.ToString() <> "0" Then
            fillMaterialWiseItem(cmbIMaterial.SelectedIndex)
            cmbIItem.Enabled = True
        End If
    End Sub
    Private Sub cmbIMaterial_PopupClosed(sender As Object, args As RadPopupClosedEventArgs) Handles cmbIMaterial.PopupClosed
        clicked = args.CloseReason = RadPopupCloseReason.Mouse
    End Sub
    Private Sub cmbRMaterial_PopupClosed(sender As Object, args As RadPopupClosedEventArgs) Handles cmbRMaterial.PopupClosed
        clicked = args.CloseReason = RadPopupCloseReason.Mouse
    End Sub
    Private Sub txtIWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIWt.KeyPress
        numdotkeypress(e, txtIWt, Me)
    End Sub
    Private Sub txtRWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRWt.KeyPress
        numdotkeypress(e, txtRWt, Me)
    End Sub
    Private Sub txtIQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIQty.KeyPress
        numdotkeypress(e, txtRWt, Me)
    End Sub
    Private Sub txtRQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRQty.KeyPress
        numdotkeypress(e, txtRQty, Me)
    End Sub
    Private Sub cmbIItem_Enter(sender As Object, e As EventArgs) Handles cmbIItem.Enter
        If cmbIMaterial.SelectedIndex = 1 Then
            fillMaterialWiseItem(cmbIMaterial.SelectedIndex)
        End If
    End Sub
    Private Sub cmbRItem_Enter(sender As Object, e As EventArgs) Handles cmbRItem.Enter
        If cmbRItem.SelectedIndex = 1 Then
            fillMaterialWiseItem(cmbRItem.SelectedIndex)
        End If
    End Sub
    Private Sub frmIssueReceive_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, False) 'for Select Next Control
            End If
            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                btnSave().PerformClick()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbLotNo_EditorControl_CustomFiltering(sender As Object, e As GridViewCustomFilteringEventArgs) Handles cmbLotNo.EditorControl.CustomFiltering
        Dim element As RadMultiColumnComboBoxElement = cmbLotNo.MultiColumnComboBoxElement
        Dim textToSearch As String = cmbLotNo.Text
        If AutoCompleteMode.Append = (element.AutoCompleteMode And AutoCompleteMode.Append) Then
            If element.SelectionLength > 0 AndAlso element.SelectionStart > 0 Then
                textToSearch = cmbLotNo.Text.Substring(0, element.SelectionStart)
            End If
        End If
        If String.IsNullOrEmpty(textToSearch) Then
            e.Visible = True
            For i As Integer = 0 To element.EditorControl.ColumnCount - 1
                e.Row.Cells(i).Style.Reset()
            Next
            e.Row.InvalidateRow()
            Return
        End If
        e.Visible = False
        For i As Integer = 0 To element.EditorControl.ColumnCount - 1
            Dim text As String = e.Row.Cells(i).Value.ToString()
            If text.IndexOf(textToSearch, 0, StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                e.Visible = True
                e.Row.Cells(i).Style.CustomizeFill = True
                e.Row.Cells(i).Style.DrawFill = True
                e.Row.Cells(i).Style.BackColor = Color.FromArgb(201, 252, 254)
            Else
                e.Row.Cells(i).Style.Reset()
            End If
        Next
        e.Row.InvalidateRow()
    End Sub
    Private Sub fillMaterialWiseItem(ByVal MaterialId As Integer)
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FethItemName", DbType.String))
            .Add(dbManager.CreateParameter("@MId", Convert.ToInt16(MaterialId), DbType.Int16))
        End With

        Dim dr = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim Odt As DataTable = New DataTable()
        Odt.Load(dr)

        Dim Cdt As DataTable = Odt.Copy()

        Try
            ''Insert the Default Item to DataTable.
            Dim frow As DataRow = Odt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            Odt.Rows.InsertAt(frow, 0)
            ''Assign DataTable as DataSource.
            cmbRItem.DataSource = Odt
            cmbRItem.DisplayMember = "ItemName"
            cmbRItem.ValueMember = "ItemId"
            cmbRItem.Refresh()
            'Set AutoCompleteMode.
            cmbRItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbRItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = Cdt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            Cdt.Rows.InsertAt(trow, 0)
            cmbIItem.DataSource = Cdt
            cmbIItem.DisplayMember = "ItemName"
            cmbIItem.ValueMember = "ItemId"
            cmbIItem.Refresh()
            'Set AutoCompleteMode.
            cmbIItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbIItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub btnRecGold_Click(sender As Object, e As EventArgs) Handles btnRecGold.Click
        Dim sLotNo As String = Nothing
        If cmbLotNo.SelectedIndex = -1 Then
            MessageBox.Show("Select Lot No. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLotNo.Focus()
            Exit Sub
        End If
        Try
            sLotNo = cmbLotNo.Text.Trim
            Dim Objfrm As New frmFReceiveGoldOthers(sLotNo)
            Objfrm.ShowDialog()
            Objfrm.BringToFront()
            Objfrm.Focus()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim strLotNo As String = Nothing
            If cmbLotNo.SelectedIndex >= 0 Then
                Dim value As Object = cmbLotNo.EditorControl.Rows(cmbLotNo.SelectedIndex).Cells("LotNo").Value
                If Not value Is Nothing Then
                    strLotNo = Convert.ToString(value)
                End If
            End If
            If blnRecieveStatus = True Then
                Dim HParameters = New List(Of SqlParameter)()
                HParameters.Clear()
                With HParameters
                    .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(strLotNo), DbType.String))
                    .Add(dbManager.CreateParameter("@ReceiveId", Val(txtRQty.Tag), DbType.Int16))
                End With
                dbManager.Delete("SP_FReceive_Delete", CommandType.StoredProcedure, HParameters.ToArray())
                MessageBox.Show("Data Deleted !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim HParameters = New List(Of SqlParameter)()
                HParameters.Clear()
                With HParameters
                    .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(strLotNo), DbType.String))
                    .Add(dbManager.CreateParameter("@IssueId", Val(txtIQty.Tag), DbType.Int16))
                End With
                dbManager.Delete("SP_FIssue_Delete", CommandType.StoredProcedure, HParameters.ToArray())
                MessageBox.Show("Data Deleted !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
        Finally
            Me.ClearInputs()
            Me.BindReceiveDetails()
            Me.BindIssueDetails()
        End Try
    End Sub
    Private Sub cmbLotNo_MouseHover(sender As Object, e As EventArgs) Handles cmbLotNo.MouseHover
        cmbLotNo.AutoCompleteMode = False
    End Sub
    Private Sub BtnPrintBarcd_Click(sender As Object, e As EventArgs) Handles BtnPrintBarcd.Click
        If cmbLotNo.SelectedIndex > 0 Then
            Dim sLotNo As String = Nothing
            sLotNo = cmbLotNo.Text.Trim
            Dim frm As New frmRptViewer(sLotNo)
            frm.ShowDialog()
            frm.BringToFront()
            frm.Focus()
        Else
            MessageBox.Show("To Print Please Select Lot No.")
        End If
    End Sub
    Private Sub cmbLotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbLotNo.KeyPress
        If cmbLotNo.Text.Trim = "" Then
            btnCancel_Click(sender, e)
        End If
    End Sub
    Private Sub cmbLotNo_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbLotNo.KeyDown
        If e.KeyCode = System.Windows.Forms.Keys.Enter Then
            If Me.cmbLotNo.ValueMember <> "" Then
                cmbLotNo.SelectedValue = cmbLotNo.EditorControl.CurrentRow.Cells(cmbLotNo.ValueMember).Value
            Else
                cmbLotNo.SelectedValue = cmbLotNo.EditorControl.CurrentRow.Cells(cmbLotNo.DisplayMember).Value
            End If
            cmbLotNo.Text = cmbLotNo.EditorControl.CurrentRow.Cells(cmbLotNo.DisplayMember).Value.ToString()
            cmbLotNo.MultiColumnComboBoxElement.ClosePopup()
            cmbLotNo.MultiColumnComboBoxElement.TextBoxElement.TextBoxItem.SelectAll()
        End If

    End Sub
    Private Sub cmbLotNo_DropDownClosed(sender As Object, args As RadPopupClosedEventArgs) Handles cmbLotNo.DropDownClosed
        iclicked = args.CloseReason = RadPopupCloseReason.Mouse
    End Sub
    Private Sub ChkWorkDone_LostFocus(sender As Object, e As EventArgs) Handles ChkRWrkDone.LostFocus
        btnSave.Focus()
    End Sub
End Class