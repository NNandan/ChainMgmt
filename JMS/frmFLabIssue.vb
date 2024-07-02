Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFLabIssue
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim strSQL As String = Nothing
    Dim GridDoubleClick As Boolean
    Private Sub frmLabIssue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.fillLab()

        Me.SetupGridViewForUsedBags(dgvLabIssue)
        Me.SetupGridViewForUsedBags(dgvDataSave)
        Me.bindIssueGridviewBags()
        Me.bindListView()
    End Sub
    Private Sub bindListView()
        Dim dtable As DataTable = fetchAllDetails()
        'RadGridView1.Rows.Clear()
        For i As Integer = 0 To dtable.Rows.Count - 1
            If dtable.Rows.Count > 0 Then
                DgvLabList.DataSource = dtable
                DgvLabList.ReadOnly = True
            Else
                MessageBox.Show("Data Not Available To Update")
            End If
        Next
    End Sub
    Private Function fetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchListLab", DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub fillLab()
        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillCombo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbLab.DataSource = dt
            cmbLab.DisplayMember = "LabName"
            cmbLab.ValueMember = "LabId"

            'Set AutoCompleteMode.
            cmbLab.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbLab.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub bindIssueGridViewTrans()
        Dim dt As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchLabIssuedDataByTrans", DbType.String))
            End With
            dt = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())
            dgvLabIssue.DataSource = Nothing
            dgvDataSave.DataSource = Nothing
            If dt.Rows.Count > 0 Then
                dgvLabIssue.DataSource = dt
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub bindIssueGridviewBags()
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchLabIssuedDataByBags", DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_fLabData_Select", CommandType.StoredProcedure, parameters.ToArray())
            dgvLabIssue.DataSource = Nothing
            dgvDataSave.DataSource = Nothing
            If dtData.Rows.Count > 0 Then
                dgvLabIssue.DataSource = dtData
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub bindReceiptListviewforUsed()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchReceiptForUsed", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            'MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        dgvLabReceipt.DataSource = Nothing

        Try
            dgvLabReceipt.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub bindReportListviewForUsed()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchReportForUsedBBags", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            'MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        dgvLabReport.DataSource = Nothing

        Try
            dgvLabReport.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click

        Dim dt As New DataTable

        If Not dgvLabIssue.Rows.Count > 0 Then
            MessageBox.Show("No Data. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        dt = (CType(dgvLabIssue.DataSource, DataTable)).Clone()

        For Each row As GridViewRowInfo In dgvLabIssue.Rows
            If CBool(row.Cells()(0).Value) = True Then
                dt.ImportRow((CType(dgvLabIssue.DataSource, DataTable)).Rows(row.Index))
            End If
        Next

        dt.AcceptChanges()
        dgvDataSave.DataSource = dt

    End Sub

    Private Sub btnLabReceipt_Click(sender As Object, e As EventArgs)
        Me.SaveReceiptDataForUsed()
    End Sub
    Private Sub SaveReceiptDataForUsed()
        Dim trans As SqlTransaction = Nothing

        If ValidateReceiptData() = False Then
            MessageBox.Show("No Receipt Data Available !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLab.Focus()
        Else
            'If Objcn.State = ConnectionState.Open Then Objcn.Close()
            'Objcn.Open()

            'trans = Objcn.BeginTransaction(System.Data.IsolationLevel.Serializable)

            Try
                ''Create Parameters for Update
                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvLabReceipt.RowCount - 1
                    If dgvLabReceipt.Rows(i).Cells(0).Value = True Then
                        ''If dgvLabReport.Rows(i).IsSelected = True Then
                        Dparameters.Add(dbManager.CreateParameter("@ActionType", "LabReceiptForUsed", DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@DTransactionId", Val(dgvLabReceipt.Rows(i).Cells(1).Value), DbType.Int16))
                        Dparameters.Add(dbManager.CreateParameter("@DUpdateDt", ReceiptDt.Value.ToString(), DbType.DateTime))
                        Dparameters.Add(dbManager.CreateParameter("@ReceivedBy", UserName.Trim(), DbType.String))
                        dbManager.Update("SP_LabIssue_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                    End If
                    Dparameters.Clear()
                Next

                'trans.Commit()

                MessageBox.Show("Receipt Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                'trans.Rollback()
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                Objcn.Close()
            End Try
        End If
    End Sub
    Private Function ValidateReceiptData() As Boolean
        Dim blnCount As Boolean = False

        If dgvLabReceipt.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvLabReceipt.Rows
                If CBool(row.Cells()(0).Value) = True Then
                    blnCount = True
                End If
            Next
        End If

        Return blnCount
    End Function
    Private Function ValidateReportData() As Boolean
        Dim blnCount As Boolean = False

        If dgvLabReport.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvLabReport.Rows
                If CBool(row.Cells()(0).Value) = True Then
                    blnCount = True
                End If
            Next
        End If

        Return blnCount
    End Function
    Private Sub SaveReportDataForUsed()
        Dim trans As SqlTransaction = Nothing

        If ValidateReportData() = False Then
            MessageBox.Show("No Report Data Available !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLab.Focus()
        ElseIf String.IsNullOrWhiteSpace(txtLabRptPr.Text.Trim) Then
            MessageBox.Show("Enter Lab Percent !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtLabPr.Focus()
        Else
            'If Objcn.State = ConnectionState.Open Then Objcn.Close()
            'Objcn.Open()

            'trans = Objcn.BeginTransaction(System.Data.IsolationLevel.Serializable)

            Try

                ''Create Parameters for Update
                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvLabReport.RowCount - 1
                    If dgvLabReport.Rows(i).Cells(0).Value = True Then
                        'If dgvLabReport.Rows(i).IsSelected = True Then
                        Dparameters.Add(dbManager.CreateParameter("@ActionType", "LabReportForUsed", DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@DTransactionId", Val(dgvLabReport.Rows(i).Cells(1).Value), DbType.Int16))
                        Dparameters.Add(dbManager.CreateParameter("@FineWt", Val(txtFineRptWt.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@LabReport", Val(txtLabRptPr.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@FSampleReceive", Val(txtSampleFineRec.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@GSampleReceive", Val(txtSampleGrossRec.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@ReceiveFineWt", Val(txtTotalRecTotal.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@RGLossWt", Val(txtTotalLossWt.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@RFLossWt", Val(txtTotalLossFine.Text), DbType.String))

                        Dparameters.Add(dbManager.CreateParameter("@ReceivedBy", Val(UserId), DbType.Int16))

                        dbManager.Update("SP_LabIssue_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                    End If
                    Dparameters.Clear()
                Next

                'trans.Commit()

                MessageBox.Show("Report Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ''ClearAllData()

            Catch ex As Exception
                'trans.Rollback()
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                ''Me.bindReportListview()
                'Objcn.Close()
            End Try
        End If
    End Sub
    Private Sub ClearAllData()
        GBoxFilter.Visible = True
        dgvLabIssue.MasterTemplate.FilterDescriptors.Clear()
        dgvDataSave.MasterTemplate.FilterDescriptors.Clear()
        cmbLab.SelectedIndex = 0
        ReceiptDt.Value = DateTime.Now()
        dgvLabReport.DataSource = Nothing
        txtDiff.Clear()
        txtLabRptPr.Clear()
        txtIssueWt.Clear()
        txtIssuePr.Clear()
        txtFineRptWt.Clear()
        txtDiff.Clear()
        txtSampleFineRec.Clear()
        txtSampleGrossRec.Clear()
        If tbLabIssue.SelectedIndex = 0 Then
            dgvLabIssue.DataSource = Nothing
            dgvDataSave.DataSource = Nothing
        ElseIf tbLabIssue.SelectedIndex = 1 Then
            dgvLabReceipt.DataSource = Nothing
        ElseIf tbLabIssue.SelectedIndex = 1 Then
            dgvLabReport.DataSource = Nothing
        End If
    End Sub
    Private Sub SaveIssueDataTran()
        Dim alParaval As New ArrayList
        Dim GridSrNo As String = ""
        Dim TransId As String = ""
        Dim LotNumber As String = ""
        Dim OperationId As String = ""
        Dim TableType As String = ""
        Dim IssueWt As String = ""
        Dim IssuePr As String = ""
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbLab.SelectedValue)
        For Each row As GridViewRowInfo In dgvDataSave.Rows
            If row.Cells(1).Value <> Nothing Then
                If TransId = "" Then
                    TransId = Val(row.Cells(1).Value)
                    LotNumber = Convert.ToString(row.Cells(3).Value)
                    OperationId = Val(row.Cells(4).Value)
                    TableType = "T"
                    IssueWt = Val(row.Cells(6).Value)
                    IssuePr = Val(row.Cells(7).Value)
                Else
                    TransId = TransId & "|" & Val(row.Cells(1).Value)
                    LotNumber = LotNumber & "|" & Convert.ToString((row.Cells(3).Value).ToString())
                    OperationId = OperationId & "|" & Val(row.Cells(4).Value)
                    TableType = TableType & "|" & "T"
                    IssueWt = IssueWt & "|" & Val(row.Cells(6).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(7).Value)
                End If
            End If
            IRowCount += 1
        Next
        alParaval.Add(TransId)
        alParaval.Add(LotNumber)
        alParaval.Add(OperationId)
        alParaval.Add(TableType)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@HLabIssueDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLabId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@DTransactionId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DLotNumber", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DOperationId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DTableType", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With
            dbManager.Insert("SP_LabIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.ClearAllData()
        End Try
    End Sub
    Private Sub SaveIssueDataUsed()
        Dim alParaval As New ArrayList
        Dim GridSrNo As String = ""
        Dim TransId As String = ""
        Dim LotNumber As String = ""
        Dim ItemId As String = ""
        Dim TableType As String = ""
        Dim IssueWt As String = ""
        Dim IssuePr As String = ""
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(dtFr.Value.ToString())
        alParaval.Add(cmbLab.SelectedValue)

        For Each row As GridViewRowInfo In dgvDataSave.Rows
            If row.Cells(1).Value <> Nothing Then
                If TransId = "" Then
                    TransId = Val(row.Cells(1).Value)
                    LotNumber = Convert.ToString(row.Cells(3).Value)
                    ItemId = Val(row.Cells(4).Value)
                    TableType = "B"
                    IssueWt = Val(row.Cells(6).Value)
                    IssuePr = Val(row.Cells(7).Value)
                Else
                    TransId = TransId & "|" & Val(row.Cells(1).Value)
                    LotNumber = LotNumber & "|" & Convert.ToString((row.Cells(3).Value).ToString())
                    ItemId = ItemId & "|" & Val(row.Cells(4).Value)
                    TableType = TableType & "|" & "B"
                    IssueWt = IssueWt & "|" & Val(row.Cells(6).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(7).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(TransId)
        alParaval.Add(LotNumber)
        alParaval.Add(ItemId)
        alParaval.Add(TableType)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@HLabIssueDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLabId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@DTransactionId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DLotNumber", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DTableType", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With
            dbManager.Insert("SP_LabIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.bindIssueGridviewBags()
            'Me.ClearAllData()
        End Try
    End Sub
    Private Sub txtLabPr_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtLabPr, Me)
    End Sub
    Private Sub txtGrossWt_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtReceivePr, Me)
    End Sub
    Private Sub txtFineWt_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtFineWt, Me)
    End Sub
    Private Sub txtReceivePr_TextChanged(sender As Object, e As EventArgs)
        Try
            txtDiff.Text = Format((Val(txtLabPr.Text) - Val(txtReceivePr.Text)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub lstLabReport_ItemChecked(sender As Object, e As ItemCheckedEventArgs)
        Me.CalculateTotal()
    End Sub
    Private Sub CalculateTotal()
        Dim sReceiveWt As Single = 0
        Dim sReceivePr As Single = 0
        Dim sFinePr As Single = 0
        For Each row As GridViewRowInfo In dgvLabReport.Rows
            If CBool(row.Cells()(0).Value) = True Then
                sReceiveWt += Single.Parse(row.Cells(5).Value)
                sReceivePr += Single.Parse(row.Cells(6).Value)
                sFinePr += Single.Parse(row.Cells(7).Value)
            End If
        Next
        txtIssueWt.Text = Format(sReceiveWt, "0.00")
        txtIssuePr.Text = Format(sReceivePr, "0.00")
        txtFineRptWt.Text = Format(sFinePr, "0.00")
    End Sub
    Private Sub frmLabIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SetupGridViewForTransaction(ByRef ObjGrdView As Telerik.WinControls.UI.RadGridView)
        ObjGrdView.AutoGenerateColumns = False
        ObjGrdView.AllowDragToGroup = False
        ObjGrdView.EnableFiltering = True
        ObjGrdView.ShowFilteringRow = False
        ObjGrdView.ShowHeaderCellButtons = True
        ObjGrdView.Columns.Clear()

        Dim chkBoxCol As New GridViewCheckBoxColumn()
        chkBoxCol.Name = "Select"
        chkBoxCol.BestFit()
        ObjGrdView.MasterTemplate.Columns.Add(chkBoxCol)
        chkBoxCol.EnableHeaderCheckBox = True
        chkBoxCol.AllowFiltering = False

        Dim ColtransId As New GridViewTextBoxColumn()
        ColtransId.Name = "ColtransId"
        ColtransId.HeaderText = "Tran. Id"
        ColtransId.FieldName = "TransactionId"
        ColtransId.IsVisible = False
        ColtransId.TextAlignment = ContentAlignment.MiddleRight
        ObjGrdView.MasterTemplate.Columns.Add(ColtransId)

        Dim ColtransDt As New GridViewDateTimeColumn()
        ColtransDt.Name = "ColtransDt"
        ColtransDt.HeaderText = "Trans. Dt"
        ColtransDt.FieldName = "TransactionDt"
        ColtransDt.TextAlignment = ContentAlignment.MiddleRight
        ColtransDt.Width = 100
        ColtransDt.FormatString = "{0:dd/MM/yyyy}"
        ColtransDt.ReadOnly = True
        ColtransDt.AllowFiltering = True
        ObjGrdView.MasterTemplate.Columns.Add(ColtransDt)

        Dim ColLotNo As New GridViewTextBoxColumn()
        ColLotNo.Name = "ColLotNo"
        ColLotNo.HeaderText = "Lot No."
        ColLotNo.FieldName = "LotNumber"
        ColLotNo.TextAlignment = ContentAlignment.MiddleRight
        ColLotNo.Width = 100
        ColLotNo.AllowFiltering = True
        ColLotNo.ReadOnly = True
        ObjGrdView.MasterTemplate.Columns.Add(ColLotNo)

        Dim ColOperationId As New GridViewTextBoxColumn()
        ColOperationId.Name = "ColOperationId"
        ColOperationId.HeaderText = "Operation Id"
        ColOperationId.FieldName = "OperationId"
        ColOperationId.TextAlignment = ContentAlignment.MiddleRight
        ColOperationId.IsVisible = False
        ObjGrdView.MasterTemplate.Columns.Add(ColOperationId)

        Dim ColOperationName As New GridViewTextBoxColumn()
        ColOperationName.Name = "ColOperationName"
        ColOperationName.HeaderText = "Operation Name"
        ColOperationName.FieldName = "OperationName"
        ColOperationName.TextAlignment = ContentAlignment.MiddleRight
        ColOperationName.Width = 125
        ColOperationName.ReadOnly = True
        ColOperationName.AllowFiltering = True
        ObjGrdView.MasterTemplate.Columns.Add(ColOperationName)

        Dim ColSampleWt As New GridViewTextBoxColumn()
        ColSampleWt.Name = "ColSampleWt"
        ColSampleWt.HeaderText = "Sample Wt."
        ColSampleWt.FieldName = "SampleWt"
        ColSampleWt.TextAlignment = ContentAlignment.MiddleRight
        ColSampleWt.Width = 100
        ColSampleWt.FormatString = "{0: F2}"
        ColSampleWt.ReadOnly = True
        ColSampleWt.AllowFiltering = False
        ObjGrdView.MasterTemplate.Columns.Add(ColSampleWt)

        Dim ColReceivePr As New GridViewTextBoxColumn()
        ColReceivePr.Name = "ColReceivePr"
        ColReceivePr.HeaderText = "Receive %"
        ColReceivePr.FieldName = "ReceivePr"
        ColReceivePr.TextAlignment = ContentAlignment.MiddleRight
        ColReceivePr.Width = 100
        ColReceivePr.FormatString = "{0: F2}"
        ColReceivePr.ReadOnly = True
        ColReceivePr.AllowFiltering = False
        ObjGrdView.MasterTemplate.Columns.Add(ColReceivePr)

        Dim ColFineWt As New GridViewTextBoxColumn()
        ColFineWt.Name = "ColFineWt"
        ColFineWt.HeaderText = "Fine Wt"
        ColFineWt.FieldName = "FineWt"
        ColFineWt.TextAlignment = ContentAlignment.MiddleRight
        ColFineWt.Width = 100
        ColFineWt.FormatString = "{0: F2}"
        ColFineWt.ReadOnly = True
        ColFineWt.AllowFiltering = False
        ObjGrdView.MasterTemplate.Columns.Add(ColFineWt)
    End Sub
    Private Sub SetupGridViewForUsedBags(ByRef ObjGrdView As Telerik.WinControls.UI.RadGridView)
        ObjGrdView.AutoGenerateColumns = False
        ObjGrdView.AllowDragToGroup = False
        ObjGrdView.EnableFiltering = True
        ObjGrdView.ShowFilteringRow = False
        ObjGrdView.ShowHeaderCellButtons = True
        ObjGrdView.Columns.Clear()

        Dim chkBoxCol As New GridViewCheckBoxColumn()
        chkBoxCol.Name = "Select"
        chkBoxCol.BestFit()
        ObjGrdView.MasterTemplate.Columns.Add(chkBoxCol)
        chkBoxCol.EnableHeaderCheckBox = True
        chkBoxCol.AllowFiltering = False

        Dim ColUsedBagId As New GridViewTextBoxColumn()
        ColUsedBagId.Name = "ColUsedBagId"
        ColUsedBagId.HeaderText = "UsedBag Id."
        ColUsedBagId.FieldName = "UsedBagId"
        ColUsedBagId.IsVisible = False
        ColUsedBagId.TextAlignment = ContentAlignment.MiddleRight
        ObjGrdView.MasterTemplate.Columns.Add(ColUsedBagId)

        Dim ColUsedBagDt As New GridViewDateTimeColumn()
        ColUsedBagDt.Name = "ColUsedBagDt"
        ColUsedBagDt.HeaderText = "Date"
        ColUsedBagDt.FieldName = "UsedBagDt"
        ColUsedBagDt.TextAlignment = ContentAlignment.MiddleRight
        ColUsedBagDt.Width = 100
        ColUsedBagDt.FormatString = "{0:dd/MM/yyyy}"
        ColUsedBagDt.ReadOnly = True
        ColUsedBagDt.AllowFiltering = True
        ObjGrdView.MasterTemplate.Columns.Add(ColUsedBagDt)

        Dim ColBagSrNo As New GridViewTextBoxColumn()
        ColBagSrNo.Name = "ColBagSrNo"
        ColBagSrNo.HeaderText = "Bag Number"
        ColBagSrNo.FieldName = "BagSrNo"
        ColBagSrNo.TextAlignment = ContentAlignment.MiddleLeft
        ColBagSrNo.Width = 100
        ColBagSrNo.ReadOnly = True
        ColBagSrNo.AllowFiltering = True
        ObjGrdView.MasterTemplate.Columns.Add(ColBagSrNo)

        Dim ColBagId As New GridViewTextBoxColumn()
        ColBagId.Name = "ColItemId"
        ColBagId.HeaderText = "Item Id."
        ColBagId.FieldName = "ItemId"
        ColBagId.IsVisible = False
        ColBagId.TextAlignment = ContentAlignment.MiddleRight
        ObjGrdView.MasterTemplate.Columns.Add(ColBagId)

        Dim ColBagName As New GridViewTextBoxColumn()
        ColBagName.Name = "ColItemName"
        ColBagName.HeaderText = "Item Name"
        ColBagName.FieldName = "ItemName"
        ColBagName.TextAlignment = ContentAlignment.MiddleLeft
        ColBagName.Width = 125
        ColBagName.ReadOnly = True
        ColBagName.AllowFiltering = True
        ObjGrdView.MasterTemplate.Columns.Add(ColBagName)

        Dim ColSampleWt As New GridViewTextBoxColumn()
        ColSampleWt.Name = "ColSampleWt"
        ColSampleWt.HeaderText = "Sample Wt."
        ColSampleWt.FieldName = "SampleWt"
        ColSampleWt.TextAlignment = ContentAlignment.MiddleRight
        ColSampleWt.Width = 100
        ColSampleWt.FormatString = "{0: F2}"
        ColSampleWt.ReadOnly = True
        ColSampleWt.AllowFiltering = False
        ObjGrdView.MasterTemplate.Columns.Add(ColSampleWt)

        Dim ColReceivePr As New GridViewTextBoxColumn()
        ColReceivePr.Name = "ColReceivePr"
        ColReceivePr.HeaderText = "Receive %"
        ColReceivePr.FieldName = "ReceivePr"
        ColReceivePr.TextAlignment = ContentAlignment.MiddleRight
        ColReceivePr.Width = 100
        ColReceivePr.FormatString = "{0: F2}"
        ColReceivePr.ReadOnly = True
        ColReceivePr.AllowFiltering = False
        ObjGrdView.MasterTemplate.Columns.Add(ColReceivePr)

        Dim ColFineWt As New GridViewTextBoxColumn()
        ColFineWt.Name = "ColFineWt"
        ColFineWt.HeaderText = "Fine Wt."
        ColFineWt.FieldName = "FineWt"
        ColFineWt.TextAlignment = ContentAlignment.MiddleRight
        ColFineWt.Width = 100
        ColFineWt.FormatString = "{0: F2}"
        ColFineWt.ReadOnly = True
        ColFineWt.AllowFiltering = False
        ObjGrdView.MasterTemplate.Columns.Add(ColFineWt)
    End Sub
    Private Sub chkRAll_CheckStateChanged(sender As Object, e As EventArgs)
    End Sub
    Private Sub btnLabReport_Click(sender As Object, e As EventArgs)
    End Sub
    Private Sub btnISave_Click(sender As Object, e As EventArgs) Handles btnISave.Click
        If Not Validate_Fields() Then Exit Sub
        Me.SaveIssueDataUsed()
    End Sub
    Private Sub dgvDataSave_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDataSave.KeyDown
        Try
            If e.KeyCode = Keys.Delete And dgvDataSave.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block
                If TypeOf dgvDataSave.CurrentRow Is Telerik.WinControls.UI.GridViewNewRowInfo Then
                    Exit Sub
                End If
                Me.dgvDataSave.Rows.RemoveAt(dgvDataSave.CurrentRow.Index)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click
        Me.SaveReceiptDataForUsed()
        Me.btnRCancel_Click(sender, e)
    End Sub
    Private Sub dgvLabReport_ValueChanged(sender As Object, e As EventArgs) Handles dgvLabReport.ValueChanged
        If dgvLabReport.CurrentColumn.Name = "colChkBox" Then
            dgvLabReport.EndEdit()
        End If
        Me.CalculateTotal()
    End Sub
    Private Sub txtLabRptPr_TextChanged(sender As Object, e As EventArgs) Handles txtLabRptPr.TextChanged
        Try
            txtDiff.Text = Format((Val(txtLabRptPr.Text) - Val(txtIssuePr.Text)), "0.00")
            txtSampleGrossPr.Text = Format(Val(txtLabRptPr.Text.Trim()), "0.00")
            txtTotalLossFine.Text = Format((Val(txtSampleGrossRec.Text) * Val(txtSampleGrossPr.Text)) / 100 - (Val(txtTotalRecTotal.Text)), "0.00")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        Try
            If btnUSave.Text = "&Save" Then
                Me.SaveReportDataForUsed()
                bindListView()
                Me.bindReportListviewForUsed()
                Me.btnUCancel_Click(sender, e)
            Else
                For i As Integer = 0 To dgvLabReport.RowCount - 1
                    If dgvLabReport.Rows(i).Cells(0).Value = False Then
                        MessageBox.Show("Please Select Record")
                    Else
                        Me.UpdateReportDataForUsed()
                        btnUSave.Text = "&Save"
                        Me.bindReportListviewForUsed()
                        Me.btnUCancel_Click(sender, e)
                    End If
                Next
            End If
        Catch
        End Try
    End Sub
    Private Sub UpdateReportDataForUsed()
        Dim trans As SqlTransaction = Nothing
        If String.IsNullOrWhiteSpace(txtLabRptPr.Text.Trim) Then
            MessageBox.Show("Enter Lab Percent !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtLabRptPr.Focus()
        ElseIf String.IsNullOrWhiteSpace(txtSampleFineRec.Text.Trim) Then
            MessageBox.Show("Enter Fine Sample Receive !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtSampleFineRec.Focus()
        ElseIf String.IsNullOrWhiteSpace(txtSampleGrossRec.Text.Trim) Then
            MessageBox.Show("Enter Gross Sample Receive !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtSampleGrossRec.Focus()
        Else
            Try
                ''Create Parameters for Update
                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()
                For i As Integer = 0 To dgvLabReport.RowCount - 1
                    If dgvLabReport.Rows(i).Cells(0).Value = True Then
                        Dparameters.Add(dbManager.CreateParameter("@ActionType", "LabReportForUsed", DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@DTransactionId", Val(dgvLabReport.Rows(i).Cells(1).Value), DbType.Int16))
                        Dparameters.Add(dbManager.CreateParameter("@FineWt", Val(txtFineRptWt.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@LabReport", Val(txtLabRptPr.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@FSampleReceive", Val(txtSampleFineRec.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@GSampleReceive", Val(txtSampleGrossRec.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@ReceiveFineWt", Val(txtTotalRecTotal.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@RGLossWt", Val(txtTotalLossWt.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@RFLossWt", Val(txtTotalLossFine.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@ReceivedBy", Val(UserId), DbType.Int16))
                        dbManager.Update("SP_LabIssue_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                        MessageBox.Show("Report Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    Dparameters.Clear()
                Next
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
            End Try
        End If
    End Sub
    Private Sub txtLabRptPr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLabRptPr.KeyPress
        numdotkeypress(e, txtLabRptPr, Me)
    End Sub
    Private Sub txtSampleFineRec_TextChanged(sender As Object, e As EventArgs) Handles txtSampleFineRec.TextChanged
        Try
            txtTotalRecWt.Text = Format(Val(txtSampleFineRec.Text) + Val(txtSampleGrossRec.Text), "0.00")

            txtSampleFineTotal.Text = Format((Val(txtSampleFineRec.Text) * Val(txtSampleFinePr.Text)) / 100, "0.00")
            txtRecvFine.Text = Format((Val(txtTotalRecWt.Text) * Val(txtLabRptPr.Text)) / 100, "0.00")
        Catch
        End Try
    End Sub
    Private Sub txtSampleGrossRec_TextChanged(sender As Object, e As EventArgs) Handles txtSampleGrossRec.TextChanged
        Try
            txtTotalRecWt.Text = Format(Val(txtSampleFineRec.Text) + Val(txtSampleGrossRec.Text), "0.00")
            txtSampleGrossTotal.Text = Format((Val(txtSampleGrossRec.Text) * Val(txtSampleGrossPr.Text)) / 100, "0.000")
            txtRecvFine.Text = Format((Val(txtTotalRecWt.Text) * Val(txtLabRptPr.Text)) / 100, "0.00")
        Catch
        End Try
    End Sub
    Private Sub txtSampleFineRec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSampleFineRec.KeyPress
        numdotkeypress(e, txtSampleFineRec, Me)
    End Sub
    Private Sub txtSampleGrossRec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSampleGrossRec.KeyPress
        numdotkeypress(e, txtSampleGrossRec, Me)
    End Sub
    Private Sub txtSampleFineTotal_TextChanged(sender As Object, e As EventArgs) Handles txtSampleFineTotal.TextChanged
        Try
            txtTotalRecTotal.Text = Format(Val(txtSampleFineTotal.Text) + Val(txtSampleGrossTotal.Text), "0.000")
        Catch
        End Try
    End Sub
    Private Sub txtSampleGrossTotal_TextChanged(sender As Object, e As EventArgs) Handles txtSampleGrossTotal.TextChanged
        Try
            txtTotalRecTotal.Text = Format(Val(txtSampleFineTotal.Text) + Val(txtSampleGrossTotal.Text), "0.000")
        Catch
        End Try
    End Sub
    Private Sub dgvLabReport_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles dgvLabReport.CellValueChanged
        Dim columnIndex = 0
        If e.ColumnIndex = columnIndex Then
            Dim isChecked = CBool(dgvLabReport.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
            If isChecked Then
                For Each row As GridViewRowInfo In dgvLabReport.Rows
                    If row.Index <> e.RowIndex Then
                        row.Cells(columnIndex).Value = Not isChecked
                    End If
                Next
            End If
        End If
    End Sub
    Private Sub dgvLabReport_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvLabReport.KeyDown
        If dgvLabReceipt.Rows.Count > 0 Then
            Me.dgvLabReport.Rows.RemoveAt(dgvLabReport.CurrentRow.Index)
        End If
    End Sub
    Private Sub txtReceivedWt_TextChanged(sender As Object, e As EventArgs) Handles txtIssueWt.TextChanged
        Try
            txtTotalLossWt.Text = Format(Val(txtIssueWt.Text) - Val(txtTotalRecWt.Text), "0.00")
        Catch
        End Try
    End Sub
    Private Sub txtReceivedPr_TextChanged(sender As Object, e As EventArgs) Handles txtIssuePr.TextChanged
        Try
            txtDiff.Text = Format((Val(txtLabRptPr.Text) - Val(txtIssuePr.Text)), "0.00")
        Catch
        End Try
    End Sub
    Private Sub cmbLab_Enter(sender As Object, e As EventArgs) Handles cmbLab.Enter
        cmbLab.ShowDropDown()
    End Sub
    Private Sub txtLabRptPr_Leave(sender As Object, e As EventArgs) Handles txtLabRptPr.Leave
        txtLabRptPr.Text = Format(Val(txtLabRptPr.Text), "0.00")
    End Sub
    Private Sub txtSampleFineRec_Leave(sender As Object, e As EventArgs) Handles txtSampleFineRec.Leave
        txtSampleFineRec.Text = Format(Val(txtSampleFineRec.Text), "0.00")
    End Sub
    Private Sub txtSampleGrossRec_Leave(sender As Object, e As EventArgs) Handles txtSampleGrossRec.Leave
        txtSampleGrossRec.Text = Format(Val(txtSampleGrossRec.Text), "0.00")
    End Sub
    Private Sub txtSampleFinePr_TextChanged(sender As Object, e As EventArgs) Handles txtSampleFinePr.TextChanged
        Try
            txtSampleFineTotal.Text = Format((Val(txtSampleFineRec.Text) * Val(txtSampleFinePr.Text)) / 100, "0.00")
        Catch
        End Try
    End Sub
    Private Sub txtTotalRecWt_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRecWt.TextChanged
        Try
            txtTotalLossWt.Text = Format((Val(txtIssueWt.Text) - Val(txtTotalRecWt.Text)), "0.00")
        Catch
        End Try
    End Sub
    Private Sub txtTotalRecTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRecTotal.TextChanged
        Try
            txtTotalLossFine.Text = Format((Val(txtFineRptWt.Text) - Val(txtTotalRecTotal.Text)), "0.00")
        Catch
        End Try
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        dgvLabReport.DataSource = Nothing
        Me.ClearAllData()
        Me.bindReportListviewForUsed()
        txtLabRptPr.Clear()
        txtSampleFineRec.Clear()
        txtSampleGrossRec.Clear()
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If Not cmbLab.SelectedIndex > 0 Then
                MessageBox.Show("Select Lab Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLab.Focus()
                Return False
            ElseIf Not dgvDataSave.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        dgvLabReceipt.DataSource = Nothing
        Me.bindReceiptListviewforUsed()
    End Sub
    Private Sub tbLabIssue_Click(sender As Object, e As EventArgs) Handles tbLabIssue.Click
        Try
            If tbLabIssue.SelectedIndex = 0 Then     ''for Gold Details
            ElseIf tbLabIssue.SelectedIndex = 1 Then ''for Other Details
                Me.bindReceiptListviewforUsed()
            ElseIf tbLabIssue.SelectedIndex = 2 Then ''for All Details
                Me.bindReportListviewForUsed()
            End If
        Catch
        End Try
    End Sub
    Private Sub txtTotalLossWt_TextChanged(sender As Object, e As EventArgs) Handles txtTotalLossWt.TextChanged
    End Sub
    Private Sub txtDiff_TextChanged(sender As Object, e As EventArgs) Handles txtDiff.TextChanged
    End Sub
    Private Sub txtTotalLossFine_TextChanged(sender As Object, e As EventArgs) Handles txtTotalLossFine.TextChanged
    End Sub
    Private Sub txtFineRptWt_TextChanged(sender As Object, e As EventArgs) Handles txtFineRptWt.TextChanged
    End Sub
    Private Sub txtSampleGrossPr_TextChanged(sender As Object, e As EventArgs) Handles txtSampleGrossPr.TextChanged
    End Sub
    Private Sub DgvLabList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles DgvLabList.CellDoubleClick
        If DgvLabList.Rows.Count > 0 Then
            Dim OtherLabIssueId As Integer = DgvLabList.Rows(e.RowIndex).Cells(0).Value.ToString()
            Me.ClearAllData()
            btnUSave.Text = "Update"
            btnRSave.Enabled = False
            Me.FillGridU(OtherLabIssueId)
            Me.tbLabIssue.SelectedIndex = 2
        End If
    End Sub
    Private Sub FillGridU(ByVal OtherLabIssueId As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetailsRUpdate(CStr(OtherLabIssueId))
        dgvLabReport.DataSource = Nothing
        dgvLabReport.DataSource = dttable
        CalculateTotal()
        Me.FetchUsedBagsDetails(OtherLabIssueId)
        Me.GetSrNo(dgvLabReport)
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvLabIssue.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function fetchAllDetailsRUpdate(ByVal OtherLabIssueId As String) As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailsListLab", DbType.String))
                .Add(dbManager.CreateParameter("@LabIssueId", Trim(OtherLabIssueId), DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub FetchUsedBagsDetails(OtherLabIssueId)
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailsDataLab", DbType.String))
                .Add(dbManager.CreateParameter("@LabIssueId", OtherLabIssueId, DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())
            If dtData.Rows.Count > 0 Then
                txtIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtFineRptWt.Text = dtData.Rows(0).Item("FineWt").ToString()
                txtLabRptPr.Text = dtData.Rows(0).Item("LabReport").ToString
                txtSampleFineRec.Text = dtData.Rows(0).Item("FSampleReceive").ToString
                txtSampleGrossRec.Text = dtData.Rows(0).Item("GSampleReceive").ToString
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub btnICancel_Click(sender As Object, e As EventArgs) Handles btnICancel.Click
    End Sub
End Class