Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports System.ComponentModel
Public Class frmOLabIssue
    Private mFr_State As FormState
    Dim TempRow As Integer
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim strSQL As String = Nothing
    Dim GridDoubleClick As Boolean
    Private Property Fr_Mode() As FormState
        Get
            Return mFr_State
        End Get
        Set(ByVal value As FormState)
            mFr_State = value
            Select Case mFr_State
                Case FormState.AStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "New"
                    'Me.btnSave.Enabled = True
                    'Me.btnSave.Text = "Save"
                    'Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    'CType(Me.ParentForm, frmMain).FormMode.Text = "Edit Fancy"
                    'Me.btnSave.Text = "Update"
                    'Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub frmOLabIssue_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLab()
        Me.fillGridCmbItemName()
        'Me.SetupListView()
        Me.bindListView()
        Me.Clear_Form()
        Me.GetMaxOtherBagNo()
    End Sub

    Private Sub bindListView()
        Dim dtable As DataTable = fetchAllDetails()
        'RadGridView1.Rows.Clear()
        For i As Integer = 0 To dtable.Rows.Count - 1
            If dtable.Rows.Count > 0 Then
                DgvOtherLabList.DataSource = dtable
                DgvOtherLabList.ReadOnly = True
            Else
                MessageBox.Show("Data Not Available To Update")
            End If
        Next
    End Sub
    Private Function fetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchListOtherLab", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fLabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub rbOtherSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbOtherSample.CheckedChanged
        If rbOtherSample.Checked = True Then
            Me.GetMaxOtherBagNo()
        End If
    End Sub
    Private Sub GetMaxOtherBagNo()
        Dim IssueId As String = String.Empty
        Dim icurValue As Integer = 0
        Dim sresult As String = String.Empty
        strSQL = Nothing
        strSQL = "SELECT MAX(LotNo) AS MaxId FROM tblLabIssueDetails WHERE LotNo LIKE 'O%'"
        Try
            sresult = Convert.ToString(dbManager.GetScalarValue(strSQL, CommandType.Text))
            If String.IsNullOrEmpty(sresult) Then
                sresult = "OTH000"
            End If
            sresult = sresult.Substring(3)
            Int32.TryParse(sresult, icurValue)
            icurValue = icurValue + 1
            sresult = "OTH" + icurValue.ToString("D3")
            txtOtherBagNo.Text = sresult
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub fillLab()
        Dim connection As SqlConnection = Nothing

        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
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
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            TransDt.Value = DateTime.Now
            cmbLab.SelectedIndex = 0
            '' For Header Field End
            '' For Detail Field Start
            txtSrNo.Text = 1
            txtOtherBagNo.Clear()
            cmbItem.SelectedIndex = 0
            txtGrossWt.Tag = ""
            txtGrossWt.Clear()
            txtGrossPr.Tag = ""
            txtGrossPr.Clear()
            dgvMelting.RowCount = 0
            '' For Detail Field End
            GridDoubleClick = False
            btnISave.Text = "&Save"
            Fr_Mode = FormState.AStateMode
            btnISave.Enabled = True
            dgvLabReceipt.DataSource = Nothing
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub fillGridCmbItemName()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillOnlyItemName", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)
            'Assign DataTable as DataSource.
            cmbItem.DataSource = dt
            cmbItem.DisplayMember = "ItemName"
            cmbItem.ValueMember = "ItemId"
            cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub txtGrossPr_TextChanged(sender As Object, e As EventArgs) Handles txtGrossPr.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(txtGrossPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGrossWt_TextChanged(sender As Object, e As EventArgs) Handles txtGrossWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(txtGrossPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillGrid()
        If GridDoubleClick = False Then
            dgvMelting.Rows.Add(Val(txtSrNo.Text.Trim),
                                    txtOtherBagNo.Text.Trim,
                                    cmbItem.SelectedValue,
                                    cmbItem.Text.Trim,
                                    Format(CDbl(txtGrossWt.Text.Trim), "0.00"),
                                    Format(CDbl(txtGrossPr.Text.Trim), "0.00"),
                                    Format(CDbl(txtFineWt.Text.Trim), "0.000"),
                                    CStr(txtNarration.Text.Trim()))
            GetSrNo(dgvMelting)
        Else
            dgvMelting.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvMelting.Rows(TempRow).Cells(1).Value = txtOtherBagNo.Text.Trim
            dgvMelting.Rows(TempRow).Cells(2).Value = cmbItem.SelectedIndex
            dgvMelting.Rows(TempRow).Cells(3).Value = cmbItem.Text.Trim
            dgvMelting.Rows(TempRow).Cells(4).Value = Format(CDbl(txtGrossWt.Text.Trim), "0.00")
            dgvMelting.Rows(TempRow).Cells(5).Value = Format(CDbl(txtGrossPr.Text.Trim), "0.00")
            dgvMelting.Rows(TempRow).Cells(6).Value = Format(CDbl(txtFineWt.Text.Trim), "0.000")
            dgvMelting.Rows(TempRow).Cells(7).Value = CStr(txtNarration.Text.Trim)
            GridDoubleClick = False
        End If

        dgvMelting.TableElement.ScrollToRow(dgvMelting.Rows.Last)
        txtSrNo.Text = dgvMelting.RowCount + 1
        cmbItem.SelectedIndex = 0
        txtGrossWt.Clear()
        txtGrossPr.Clear()
        txtFineWt.Clear()
        txtNarration.Clear()
        cmbItem.Focus()
    End Sub
    Private Sub txtNarration_Validating(sender As Object, e As CancelEventArgs) Handles txtNarration.Validating
        Try
            If cmbItem.SelectedIndex > 0 And Val(txtGrossWt.Text.Trim) > 0 And Val(txtFineWt.Text.Trim) > 0 Then
                Me.fillGrid()

            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvMelting.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnISave_Click(sender As Object, e As EventArgs) Handles btnISave.Click
        If Not Validate_Fields() Then Exit Sub
        Me.SaveIssueDataUsed()
        Me.btnICancel_Click(sender, e)
    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If Not cmbLab.SelectedIndex > 0 Then
                MessageBox.Show("Select Lab Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLab.Focus()
                Return False
            ElseIf Not dgvMelting.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub SaveIssueDataUsed()
        Dim alParaval As New ArrayList
        Dim GridSrNo As String = ""
        Dim LotNumber As String = ""
        Dim ItemId As String = ""
        Dim TableType As String = ""
        Dim IssueWt As String = ""
        Dim IssuePr As String = ""
        Dim Narration As String = ""
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbLab.SelectedValue)

        For Each row As GridViewRowInfo In dgvMelting.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    LotNumber = Convert.ToString(row.Cells(1).Value)
                    ItemId = Val(row.Cells(2).Value)
                    TableType = "O"
                    IssueWt = Val(row.Cells(4).Value)
                    IssuePr = Val(row.Cells(5).Value)
                    Narration = Convert.ToString(row.Cells(7).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    LotNumber = LotNumber & "|" & Convert.ToString((row.Cells(1).Value))
                    ItemId = ItemId & "|" & Val(row.Cells(2).Value)
                    TableType = TableType & "|" & "O"
                    IssueWt = IssueWt & "|" & Val(row.Cells(4).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(5).Value)
                    Narration = Narration & "|" & Convert.ToString(row.Cells(7).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(LotNumber)
        alParaval.Add(ItemId)
        alParaval.Add(TableType)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)
        alParaval.Add(Narration)

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
                .Add(dbManager.CreateParameter("@DNarration", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_fLabIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub txtGrossWt_Enter(sender As Object, e As EventArgs) Handles txtGrossWt.Enter
        If Not String.IsNullOrEmpty(txtGrossWt.Text) Then
            txtGrossWt.Select(txtGrossWt.Text.Length, 0)
        End If
    End Sub
    Private Sub txtGrossWt_Leave(sender As Object, e As EventArgs) Handles txtGrossWt.Leave
        txtGrossWt.Text = Format(Val(txtGrossWt.Text), "0.00")
        txtGrossWt.Select(0, 0)
    End Sub
    Private Sub frmOLabIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                btnISave().PerformClick()
            End If

            With dgvMelting
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub msktxtDate_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtOtherBagNo.Focus()
        End If
    End Sub
    Private Sub txtOtherBagNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOtherBagNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbItem.Focus()
        End If
    End Sub
    Private Sub txtGrossWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrossWt.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFineWt.Focus()
        End If
    End Sub
    Private Sub txtGrossPr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrossPr.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtGrossPr.Focus()
        End If
    End Sub
    Private Sub txtGrossWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrossWt.KeyPress
        numdotkeypress(e, txtGrossWt, Me)
    End Sub
    Private Sub txtGrossPr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrossPr.KeyPress
        numdotkeypress(e, txtGrossPr, Me)
    End Sub
    Private Sub txtGrossPr_Leave(sender As Object, e As EventArgs) Handles txtGrossPr.Leave
        txtGrossPr.Text = Format(Val(txtGrossPr.Text), "0.00")
    End Sub
    Private Sub txtFineWt_Leave(sender As Object, e As EventArgs) Handles txtFineWt.Leave
        txtFineWt.Text = Format(Val(txtFineWt.Text), "0.00")
    End Sub
    Private Sub rbRLotSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbRLotSample.CheckedChanged
        If rbRLotSample.Checked = True Then
            Me.bindReceiptListviewforTran()
        Else
            Me.bindListView()
        End If
    End Sub
    Private Sub bindReceiptListviewforTran()
        Dim dt As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchReceiptForTran", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_fLabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

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
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click
        If rbRLotSample.Checked = True Then
            Me.SaveReceiptDataForTran()
            Me.btnRCancel_Click(sender, e)
        End If
    End Sub
    Private Sub SaveReceiptDataForTran()
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
                        Dparameters.Add(dbManager.CreateParameter("@ActionType", "LabReceiptForTran", DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@DTransactionId", Val(dgvLabReceipt.Rows(i).Cells(1).Value), DbType.Int16))
                        Dparameters.Add(dbManager.CreateParameter("@DUpdateDt", ReceiptDt.Value.ToString(), DbType.DateTime))
                        Dparameters.Add(dbManager.CreateParameter("@ReceivedBy", UserName.Trim(), DbType.String))
                        dbManager.Update("SP_fLabIssue_Update", CommandType.StoredProcedure, Dparameters.ToArray())
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
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Try
            Me.bindReceiptListviewforTran()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ClearAllData()
        ''For Issue
        GBoxRptUpdate.Visible = True
        dgvLabReport.MasterTemplate.FilterDescriptors.Clear()
        dgvLabReport.MasterTemplate.FilterDescriptors.Clear()
        cmbLab.SelectedIndex = 0
        ''For Receipt
        ReceiptDt.Value = DateTime.Now()
        txtDiff.Clear()
        'chkReAll.Checked = False
        txtIssueWt.Clear()
        txtIssuePr.Clear()
        txtFineRptWt.Clear()
        txtDiff.Clear()
        txtLabRptPr.Clear()
        txtSampleFineRec.Clear()
        txtSampleGrossRec.Clear()
    End Sub
    Private Sub rbReLotSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbReLotSample.CheckedChanged
        If rbReLotSample.Checked = True Then
            Me.bindReportListviewForTran()
        End If
    End Sub
    Private Sub bindReportListviewForTran()
        Dim dt As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchReportForUsedOBags", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_fLabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            ' MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        dgvLabReport.DataSource = Nothing

        Try
            dgvLabReport.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
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
        Me.CalculateTotal()
    End Sub
    Private Sub dgvLabReport_ValueChanged(sender As Object, e As EventArgs) Handles dgvLabReport.ValueChanged
        If dgvLabReport.CurrentColumn.Name = "colChkBox" Then
            dgvLabReport.EndEdit()
        End If
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
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        Try
            If btnUSave.Text = "&Save" Then
                Me.SaveReportDataForTran()
                Me.bindReportListviewForTran()
                Me.btnUCancel_Click(sender, e)
            Else
                For i As Integer = 0 To dgvLabReport.RowCount - 1
                    If dgvLabReport.Rows(I).Cells(0).Value = False Then
                        MessageBox.Show("Please Select Record")
                    Else
                        Me.UpdateReportDataForTran()
                        btnUSave.Text = "&Save"
                        Me.bindReportListviewForTran()
                        Me.btnUCancel_Click(sender, e)
                    End If
                Next
            End If
        Catch
        End Try
    End Sub
    Private Sub UpdateReportDataForTran()
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
                        Dparameters.Add(dbManager.CreateParameter("@ActionType", "LabReportForTran", DbType.String))
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
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        dgvLabReport.DataSource = Nothing
        Me.ClearAllData()
        Me.bindReportListviewForTran()

    End Sub
    Private Sub SaveReportDataForTran()
        Dim trans As SqlTransaction = Nothing
        If ValidateReportData() = False Then
            MessageBox.Show("No Report Data Available !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLab.Focus()
        ElseIf String.IsNullOrWhiteSpace(txtLabRptPr.Text.Trim) Then
            MessageBox.Show("Enter Lab Percent !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtLabRptPr.Focus()
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
                        Dparameters.Add(dbManager.CreateParameter("@ActionType", "LabReportForTran", DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@DTransactionId", Val(dgvLabReport.Rows(i).Cells(1).Value), DbType.Int16))
                        Dparameters.Add(dbManager.CreateParameter("@FineWt", Val(txtFineRptWt.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@LabReport", Val(txtLabRptPr.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@FSampleReceive", Val(txtSampleFineRec.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@GSampleReceive", Val(txtSampleGrossRec.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@ReceiveFineWt", Val(txtTotalRecTotal.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@RGLossWt", Val(txtTotalLossWt.Text), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@RFLossWt", Val(txtTotalLossFine.Text), DbType.String))

                        Dparameters.Add(dbManager.CreateParameter("@ReceivedBy", Val(UserId), DbType.Int16))

                        dbManager.Update("SP_fLabIssue_Update", CommandType.StoredProcedure, Dparameters.ToArray())
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
    Private Sub txtLabRptPr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLabRptPr.KeyPress
        numdotkeypress(e, txtLabRptPr, Me)
    End Sub
    Private Sub txtSampleFineRec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSampleFineRec.KeyPress
        numdotkeypress(e, txtSampleFineRec, Me)
    End Sub
    Private Sub txtSampleGrossRec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSampleGrossRec.KeyPress
        numdotkeypress(e, txtSampleGrossRec, Me)
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
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub dgvMelting_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvMelting.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And dgvMelting.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvMelting.Rows(e.RowIndex).Cells(0).Value.ToString()
                txtOtherBagNo.Text = dgvMelting.Rows(e.RowIndex).Cells(1).Value.ToString()
                cmbItem.SelectedIndex = dgvMelting.Rows(e.RowIndex).Cells(2).Value.ToString()
                cmbItem.Text = dgvMelting.Rows(e.RowIndex).Cells(3).Value.ToString()
                txtGrossWt.Text = dgvMelting.Rows(e.RowIndex).Cells(4).Value.ToString()
                txtGrossPr.Text = dgvMelting.Rows(e.RowIndex).Cells(5).Value.ToString()
                txtFineWt.Text = dgvMelting.Rows(e.RowIndex).Cells(6).Value.ToString()
                txtNarration.Text = dgvMelting.Rows(e.RowIndex).Cells(7).Value.ToString()
                TempRow = e.RowIndex
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function fetchAllFancys() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub fillHeaderFromListView(ByVal intMeltingId As Integer)
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@MId", CInt(intMeltingId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Melting_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtLabId.Text = dr.Item("LabIssueId")
            TransDt.Text = dr.Item("MeltingDt").ToString
            cmbLab.SelectedIndex = dr.Item("LabId").ToString
        End If

        dr.Close()
        Objcn.Close()
        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillDetailsFromListView(ByVal MeltingId As Integer)
        Dim dttable As New DataTable

        For Each ROW As DataRow In dttable.Rows
            dgvMelting.Rows.Add(1, CStr(ROW("ItemType")), CStr(ROW("SlipBagNo")), Val(ROW("ItemBagId")), CStr(ROW("ItemName")), Format(Val(ROW("GrossWt")), "0.00"), Format(Val(ROW("GrossPr")), "0.00"), Format(Val(ROW("FineWt")), "0.000"), Val(ROW("ReceiptId")), Val(ROW("ReceiptDetailsId")), Val(ROW("UsedBagId")))
        Next

        Me.GetSrNo(dgvMelting)

        dgvMelting.ReadOnly = True
    End Sub
    Private Sub btnICancel_Click(sender As Object, e As EventArgs) Handles btnICancel.Click
        Me.ClearCreateData()
    End Sub
    Private Sub ClearCreateData()
        cmbLab.SelectedIndex = 0
        rbOtherSample.Checked = False
        txtSrNo.Clear()
        cmbItem.SelectedIndex = 0
        txtGrossWt.Clear()
        txtGrossPr.Clear()
        txtFineWt.Clear()
        txtNarration.Clear()
        dgvMelting.DataSource = Nothing
        dgvMelting.RowCount = 0
    End Sub
    Private Sub DgvOtherLabList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles DgvOtherLabList.CellDoubleClick
        If DgvOtherLabList.Rows.Count > 0 Then
            Dim OtherLabIssueId As Integer = DgvOtherLabList.Rows(e.RowIndex).Cells(0).Value.ToString()
            Me.ClearAllData()
            btnUSave.Text = "Update"
            btnRSave.Enabled = False
            Me.FillGridU(OtherLabIssueId)
            Me.TabControl1.SelectedIndex = 2
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
    Private Function fetchAllDetailsRUpdate(ByVal OtherLabIssueId As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailsListOtherLab", DbType.String))
                .Add(dbManager.CreateParameter("@LabIssueId", Trim(OtherLabIssueId), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fLabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub FetchUsedBagsDetails(OtherLabIssueId)
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailsDataOtherLab", DbType.String))
                .Add(dbManager.CreateParameter("@LabIssueId", OtherLabIssueId, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fLabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

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
    Private Sub txtLabRptPr_TextChanged(sender As Object, e As EventArgs) Handles txtLabRptPr.TextChanged
        Try
            txtDiff.Text = Format((Val(txtLabRptPr.Text) - Val(txtIssuePr.Text)), "0.00")
            txtSampleGrossPr.Text = Format(Val(txtLabRptPr.Text.Trim()), "0.00")

            txtTotalLossFine.Text = Format((Val(txtSampleGrossRec.Text) * Val(txtSampleGrossPr.Text)) / 100 - (Val(txtTotalRecTotal.Text)), "0.00")
        Catch ex As Exception

        End Try
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
    Private Sub txtTotalRecWt_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRecWt.TextChanged
        Try
            txtTotalLossWt.Text = Format((Val(txtIssueWt.Text) - Val(txtTotalRecWt.Text)), "0.00")
        Catch
        End Try
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
    Private Sub txtTotalRecTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRecTotal.TextChanged
        Try
            txtTotalLossFine.Text = Format((Val(txtFineRptWt.Text) - Val(txtTotalRecTotal.Text)), "0.00")
        Catch
        End Try
    End Sub
    Private Sub txtIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtIssueWt.TextChanged
        Try
            txtTotalLossWt.Text = Format(Val(txtIssueWt.Text) - Val(txtTotalRecWt.Text), "0.00")
        Catch
        End Try
    End Sub
    Private Sub txtIssuePr_TextChanged(sender As Object, e As EventArgs) Handles txtIssuePr.TextChanged
        Try
            txtDiff.Text = Format((Val(txtLabRptPr.Text) - Val(txtIssuePr.Text)), "0.00")
        Catch
        End Try
    End Sub
    Private Sub txtSampleFinePr_TextChanged(sender As Object, e As EventArgs) Handles txtSampleFinePr.TextChanged
        Try
            txtSampleFineTotal.Text = Format((Val(txtSampleFineRec.Text) * Val(txtSampleFinePr.Text)) / 100, "0.00")
        Catch
        End Try
    End Sub
    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        If TabControl1.SelectedIndex = 0 Then     ''for Gold Details
            rbRLotSample.Checked = False
            Me.Clear_Form()
            Me.GetMaxOtherBagNo()
        ElseIf TabControl1.SelectedIndex = 1 Then ''for Other Details
            'Me.bindReceiptListviewforTran()
            Me.bindListView()
            Me.Clear_Form()
            Me.GetMaxOtherBagNo()
        ElseIf TabControl1.SelectedIndex = 2 Then ''for All Details
            rbRLotSample.Checked = False
            Me.Clear_Form()
            Me.bindReceiptListviewforTran()
            Me.bindListView()
        ElseIf TabControl1.SelectedIndex = 3 Then ''for All Details
            rbRLotSample.Checked = False
            Me.Clear_Form()
            Me.bindReceiptListviewforTran()
            Me.bindListView()
        End If
    End Sub


End Class