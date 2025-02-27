﻿Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmLabIssue
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim strSQL As String = Nothing
    Dim GridDoubleClick As Boolean
    Private Sub frmLabIssue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.fillLab()
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

            With parameters
                .Clear()
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
            cmbLab.AutoCompleteMode = AutoCompleteMode.Suggest
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

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetNotSentSampleLot", DbType.String))
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

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetNotSentSampleBag", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

            dgvLabIssue.DataSource = Nothing
            dgvDataSave.DataSource = Nothing

            If dtData.Rows.Count > 0 Then
                dgvLabIssue.DataSource = dtData
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub bindReceiptListviewforTran()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchReceiptForTran", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        dgvLabReceipt.DataSource = Nothing

        Try
            dgvLabReceipt.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub bindReceiptListviewforUsed()
        Dim dt As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchReceiptForUsed", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        dgvLabReceipt.DataSource = Nothing

        Try
            dgvLabReceipt.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub bindReportListviewForTran()
        Dim dt As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchReportForTran", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        dgvLabReport.DataSource = Nothing

        Try
            dgvLabReport.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub bindReportListviewForUsed()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchReportForUsed", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
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
    Private Sub TabControl1_Click(sender As Object, e As EventArgs) Handles TabControl1.Click
        If TabControl1.SelectedIndex = 0 Then
            ' Do Something       
        ElseIf TabControl1.SelectedIndex = 1 Then
            ' Do Something 
        End If
    End Sub
    Private Sub btnLabReceipt_Click(sender As Object, e As EventArgs)
        If rbRLotSample.Checked = True Then
            Me.SaveReceiptDataForTran()
        Else
            Me.SaveReceiptDataForUsed()
        End If
    End Sub
    Private Sub SaveReceiptDataForTran()
        Dim trans As SqlTransaction = Nothing

        If ValidateReceiptData() = False Then
            MessageBox.Show("No Receipt Data Available !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLab.Focus()
        Else

            Try
                Dim Dparameters = New List(Of SqlParameter)()

                For i As Integer = 0 To dgvLabReceipt.RowCount - 1
                    If dgvLabReceipt.Rows(i).IsSelected = True Then
                        'If dgvLabReceipt.Rows(i).Cells(0).Value = True Then
                        With Dparameters
                            .Clear()
                            .Add(dbManager.CreateParameter("@ActionType", "LabReceiptForTran", DbType.String))
                            .Add(dbManager.CreateParameter("@DLabIssueId", Val(dgvLabReceipt.Rows(i).Cells(1).Value), DbType.Int16))
                            .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(dgvLabReceipt.Rows(i).Cells(2).Value), DbType.String))
                            .Add(dbManager.CreateParameter("@DUpdateDt", ReceiptDt.Value.ToString(), DbType.DateTime))
                            .Add(dbManager.CreateParameter("@ReceivedBy", UserName.Trim(), DbType.String))
                            dbManager.Update("SP_LabIssue_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                        End With
                        'End If
                    End If
                    Dparameters.Clear()
                Next

                MessageBox.Show("Receipt Data Updated !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally

            End Try
        End If
    End Sub
    Private Sub SaveReceiptDataForUsed()
        Dim trans As SqlTransaction = Nothing

        If ValidateReceiptData() = False Then
            MessageBox.Show("No Receipt Data Available !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLab.Focus()
        Else

            Try
                ''Create Parameters for Update
                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvLabReceipt.RowCount - 1
                    If dgvLabReceipt.Rows(i).Cells(0).Value = True Then
                        'If dgvLabReport.Rows(i).IsSelected = True Then
                        Dparameters.Add(dbManager.CreateParameter("@ActionType", "LabReceiptForUsed", DbType.String))
                            Dparameters.Add(dbManager.CreateParameter("@DLabIssueId", Val(dgvLabReceipt.Rows(i).Cells(1).Value), DbType.Int16))
                            Dparameters.Add(dbManager.CreateParameter("@DUpdateDt", ReceiptDt.Value.ToString(), DbType.DateTime))
                            Dparameters.Add(dbManager.CreateParameter("@ReceivedBy", UserName.Trim(), DbType.String))
                            dbManager.Update("SP_LabIssue_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                            MessageBox.Show("Receipt Data Updated !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        'End If
                    End If
                    Dparameters.Clear()
                Next
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
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
    'Private Function ValidateReportData() As Boolean
    '    Dim blnCount As Boolean = False

    '    If dgvLabReport.Rows.Count > 0 Then
    '        For Each row As GridViewRowInfo In dgvLabReport.Rows
    '            If CBool(row.Cells()(0).Value) = True Then
    '                blnCount = True
    '            End If
    '        Next
    '    End If

    '    Return blnCount
    'End Function
    Private Sub SaveReportDataForTran()
        Dim trans As SqlTransaction = Nothing

        If ValidateReportData() = False Then
            MessageBox.Show("No Report Data Available !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLab.Focus()
        ElseIf String.IsNullOrWhiteSpace(txtLabRptPr.Text.Trim) Then
            MessageBox.Show("Enter Lab Percent !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtLabRptPr.Focus()
        Else

            Try
                ''Create Parameters for Update
                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvLabReport.RowCount - 1
                    If dgvLabReport.Rows(i).IsSelected = True Then
                        'If dgvLabReceipt.Rows(i).Cells(0).Value = True Then
                        Dparameters.Add(dbManager.CreateParameter("@ActionType", "LabReportForTran", DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@DLabIssueId", Val(dgvLabReport.Rows(i).Cells(1).Value), DbType.Int16))
                        Dparameters.Add(dbManager.CreateParameter("@DIOId", Val(dgvLabReport.Rows(i).Cells(3).Value), DbType.Int16))
                        Dparameters.Add(dbManager.CreateParameter("@LabReport", Val(txtLabRptPr.Text.Trim), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@GSampleReceive", Val(txtSampleGrossRec.Text.Trim), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@FSampleReceive", Val(txtSampleFineRec.Text.Trim), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@ReceiveFineWt", Val(txtTotalRecTotal.Text.Trim), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@RGLossWt", Val(txtTotalLossWt.Text.Trim), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@RFLossWt", Val(txtTotalLossFine.Text.Trim), DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@ReceivedBy", Val(UserId), DbType.Int16))
                        dbManager.Update("SP_LabIssue_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                    End If
                    'End If
                    Dparameters.Clear()
                Next

                MessageBox.Show("Report Data Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
            End Try
        End If
    End Sub
    Private Sub SaveReportDataForUsed()
        Dim trans As SqlTransaction = Nothing

        If ValidateReportData() = False Then
            MessageBox.Show("No Report Data Available !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLab.Focus()
        ElseIf String.IsNullOrWhiteSpace(txtLabRptPr.Text.Trim) Then
            MessageBox.Show("Enter Lab Percent !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            txtLabPr.Focus()
        Else

            Try
                ''Create Parameters for Update
                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvLabReport.RowCount - 1
                    If dgvLabReport.Rows(i).Cells(0).Value = True Then
                        If dgvLabReport.Rows(i).IsSelected = True Then
                            Dparameters.Add(dbManager.CreateParameter("@ActionType", "LabReportForUsed", DbType.String))
                            Dparameters.Add(dbManager.CreateParameter("@DLabIssueId", Val(dgvLabReport.Rows(i).Cells(1).Value), DbType.Int16))
                            Dparameters.Add(dbManager.CreateParameter("@DIOId", Val(dgvLabReport.Rows(i).Cells(3).Value), DbType.Int16))
                            Dparameters.Add(dbManager.CreateParameter("@LabReport", Val(txtLabRptPr.Text), DbType.String))
                            Dparameters.Add(dbManager.CreateParameter("@GSampleReceive", Val(txtSampleGrossRec.Text.Trim), DbType.String))
                            Dparameters.Add(dbManager.CreateParameter("@FSampleReceive", Val(txtSampleFineRec.Text.Trim), DbType.String))
                            Dparameters.Add(dbManager.CreateParameter("@ReceiveFineWt", Val(txtTotalRecTotal.Text.Trim), DbType.String))
                            Dparameters.Add(dbManager.CreateParameter("@RGLossWt", Val(txtTotalLossWt.Text), DbType.String))
                            Dparameters.Add(dbManager.CreateParameter("@RFLossWt", Val(txtTotalLossFine.Text), DbType.String))
                            Dparameters.Add(dbManager.CreateParameter("@ReceivedBy", Val(UserId), DbType.Int16))

                            dbManager.Update("SP_LabIssue_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                        End If
                    End If
                    Dparameters.Clear()
                Next

                MessageBox.Show("Report Data Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
            End Try
        End If
    End Sub
    Private Sub ClearAllData()
        ''For Issue
        GBoxFilter.Visible = True

        dgvLabIssue.MasterTemplate.FilterDescriptors.Clear()
        dgvDataSave.MasterTemplate.FilterDescriptors.Clear()

        cmbLab.SelectedIndex = 0

        ''For Receipt
        ReceiptDt.Value = DateTime.Now()
        chkRAll.Checked = False

        ''For Report
        ''lstLabReport.Items.Clear()
        dgvLabReport.DataSource = Nothing
        'chkReAll.Checked = False

        txtLabRptPr.Clear()
        txtIssueWt.Clear()
        txtIssuePr.Clear()
        txtFineRptWt.Clear()
        txtDiff.Clear()
        txtTotalLossWt.Clear()
        txtTotalLossFine.Clear()

        If TabControl1.SelectedIndex = 0 Then
            dgvLabIssue.DataSource = Nothing
            dgvDataSave.DataSource = Nothing
        ElseIf TabControl1.SelectedIndex = 1 Then
            dgvLabReceipt.DataSource = Nothing
            Me.bindReceiptListviewforTran()
        ElseIf TabControl1.SelectedIndex = 1 Then
            dgvLabReport.DataSource = Nothing
        End If

    End Sub
    Private Sub SaveIssueDataTran()
        Dim alParaval As New ArrayList
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

            With Hparameters
                .Clear()
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

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.bindIssueGridViewTrans()
            'Me.ClearAllData()
        End Try
    End Sub
    Private Sub SaveIssueDataUsed()
        Dim alParaval As New ArrayList
        Dim TransId As String = ""
        Dim LotNumber As String = ""
        Dim OperationId As String = ""
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
                    OperationId = Val(row.Cells(4).Value)
                    TableType = "B"
                    IssueWt = Val(row.Cells(6).Value)
                    IssuePr = Val(row.Cells(7).Value)
                Else
                    TransId = TransId & "|" & Val(row.Cells(1).Value)
                    LotNumber = LotNumber & "|" & Convert.ToString((row.Cells(3).Value).ToString())
                    OperationId = OperationId & "|" & Val(row.Cells(4).Value)
                    TableType = TableType & "|" & "B"
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

            With Hparameters
                .Clear()
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

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.ClearAllData()
            Me.bindIssueGridviewBags()
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
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub rbLotSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbLotSample.CheckedChanged
        If rbLotSample.Checked = True Then
            Me.SetupGridViewForTransaction(dgvLabIssue)
            Me.SetupGridViewForTransaction(dgvDataSave)
            Me.bindIssueGridViewTrans()
        End If
    End Sub
    Private Sub rbBagSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbBagSample.CheckedChanged
        If rbBagSample.Checked = True Then
            Me.SetupGridViewForUsedBags(dgvLabIssue)
            Me.SetupGridViewForUsedBags(dgvDataSave)
            Me.bindIssueGridviewBags()
        End If
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
        ColtransId.FieldName = "TransId"
        ColtransId.IsVisible = False
        ColtransId.TextAlignment = ContentAlignment.MiddleRight
        ObjGrdView.MasterTemplate.Columns.Add(ColtransId)

        Dim ColtransDt As New GridViewDateTimeColumn()
        ColtransDt.Name = "ColtransDt"
        ColtransDt.HeaderText = "Trans. Dt"
        ColtransDt.FieldName = "TransDt"
        ColtransDt.TextAlignment = ContentAlignment.MiddleRight
        ColtransDt.Width = 100
        ColtransDt.FormatString = "{0:dd/MM/yyyy}"
        ColtransDt.ReadOnly = True
        ColtransDt.AllowFiltering = True
        ObjGrdView.MasterTemplate.Columns.Add(ColtransDt)

        Dim ColLotNo As New GridViewTextBoxColumn()
        ColLotNo.Name = "ColLotNo"
        ColLotNo.HeaderText = "Lot No."
        ColLotNo.FieldName = "LotNo"
        ColLotNo.TextAlignment = ContentAlignment.MiddleLeft
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
        ColOperationName.TextAlignment = ContentAlignment.MiddleLeft
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
        ColUsedBagId.FieldName = "TransId"
        ColUsedBagId.IsVisible = False
        ColUsedBagId.TextAlignment = ContentAlignment.MiddleRight
        ObjGrdView.MasterTemplate.Columns.Add(ColUsedBagId)

        Dim ColUsedBagDt As New GridViewDateTimeColumn()
        ColUsedBagDt.Name = "ColUsedBagDt"
        ColUsedBagDt.HeaderText = "UsedBag Dt."
        ColUsedBagDt.FieldName = "TransDt"
        ColUsedBagDt.TextAlignment = ContentAlignment.MiddleLeft
        ColUsedBagDt.Width = 100
        ColUsedBagDt.FormatString = "{0:dd/MM/yyyy}"
        ColUsedBagDt.ReadOnly = True
        ColUsedBagDt.AllowFiltering = True
        ObjGrdView.MasterTemplate.Columns.Add(ColUsedBagDt)

        Dim ColBagSrNo As New GridViewTextBoxColumn()
        ColBagSrNo.Name = "ColBagSrNo"
        ColBagSrNo.HeaderText = "Bag Number"
        ColBagSrNo.FieldName = "LotNo"
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
        ColBagName.HeaderText = "Bag Name"
        ColBagName.FieldName = "OperationName"
        ColBagName.TextAlignment = ContentAlignment.MiddleLeft
        ColBagName.Width = 145
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
    Private Sub rbRLotSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbRLotSample.CheckedChanged
        If rbRLotSample.Checked = True Then
            dgvLabReceipt.DataSource = Nothing
            Me.bindReceiptListviewforTran()
        End If
    End Sub
    Private Sub rbRBagSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbRBagSample.CheckedChanged
        If rbRBagSample.Checked = True Then
            dgvLabReceipt.DataSource = Nothing
            Me.bindReceiptListviewforUsed()
        End If
    End Sub
    Private Sub chkRAll_CheckStateChanged(sender As Object, e As EventArgs) Handles chkRAll.CheckStateChanged
        If dgvLabReceipt.Rows.Count > 0 Then
            If chkRAll.Checked = True Then
                For i = 0 To dgvLabReceipt.RowCount - 1
                    dgvLabReceipt.Rows(i).Cells(0).Value = True
                Next
                chkRAll.Text = "Un-Check All"
            Else
                For i = 0 To dgvLabReceipt.RowCount - 1
                    dgvLabReceipt.Rows(i).Cells(0).Value = False
                Next
                chkRAll.Text = "Check All"
            End If
        End If
    End Sub
    Private Sub rbReLotSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbReLotSample.CheckedChanged
        If rbReLotSample.Checked = True Then
            Me.bindReportListviewForTran()
        End If
    End Sub
    Private Sub rbReBagSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbReBagSample.CheckedChanged
        If rbReBagSample.Checked = True Then
            Me.bindReportListviewForUsed()
        End If
    End Sub
    Private Sub btnLabReport_Click(sender As Object, e As EventArgs)
        'If rbReLotSample.Checked = True Then
        '    Me.SaveReportDataForTran()
        'Else
        '    Me.SaveReportDataForUsed()
        'End If
    End Sub
    Private Sub btnISave_Click(sender As Object, e As EventArgs) Handles btnISave.Click
        If Not Validate_Fields() Then Exit Sub

        If rbLotSample.Checked = True Then
            Me.SaveIssueDataTran()
            'Me.UpdateStockLab1()
            dgvDataSave.DataSource = Nothing

        Else
            Me.SaveIssueDataUsed()
            'Me.UpdateStockLab1()
            dgvDataSave.DataSource = Nothing
        End If
    End Sub
    'Private Function UpdateStockLab1() As DataTable
    '    Dim Dt As DataTable = Nothing
    '    Dim alParaval As New ArrayList
    '    Dim BagId As Int16 = 0
    '    Dim TranId As String = Nothing
    '    Dim IRowCount As Integer = 0
    '    Dim iValue As Integer = 0
    '    alParaval.Add(cmbCBagtype.SelectedValue)
    '    If dgvFSampleBag.Rows.Count > 0 Then
    '        For Each row As GridViewRowInfo In dgvFSampleBag.Rows
    '            'If row.Cells(0).Value = True Then
    '            If TranId = "" Then
    '                TranId = Val(row.Cells(8).Value)
    '            Else
    '                TranId = TranId & "|" & Val(row.Cells(8).Value)
    '            End If
    '            'End If
    '            IRowCount += 1
    '        Next
    '        alParaval.Add(TranId)
    '        Try
    '            Dim Dparameters = New List(Of SqlParameter)()
    '            Dparameters.Clear()
    '            With Dparameters
    '                .Add(dbManager.CreateParameter("@ActionType", "UpdateSampleNo", DbType.String))
    '                .Add(dbManager.CreateParameter("@BId", alParaval.Item(iValue), DbType.Int16))
    '                iValue += 1
    '                .Add(dbManager.CreateParameter("@TId", alParaval.Item(iValue), DbType.String))
    '                iValue += 1
    '                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
    '                .Add(dbManager.CreateParameter("@BagType", "S", DbType.String))
    '            End With
    '            Dt = dbManager.GetDataTable("SP_UsedBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())
    '            'MessageBox.Show("Bhuka Bag Updated !!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '        Catch ex As Exception
    '            MessageBox.Show("Error:- " & ex.Message)
    '        End Try
    '    End If
    '    Return Dt
    'End Function

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
        If rbRLotSample.Checked = True Then
            Me.SaveReceiptDataForTran()
            Me.btnRCancel_Click(sender, e)
            Me.bindIssueGridViewTrans()
        Else
            Me.SaveReceiptDataForUsed()
            Me.btnRCancel_Click(sender, e)
            Me.bindIssueGridviewBags()
        End If
    End Sub
    Private Sub dgvLabReport_ValueChanged(sender As Object, e As EventArgs) Handles dgvLabReport.ValueChanged
        'Dim editor As RadCheckBoxEditor = TryCast(sender, RadCheckBoxEditor)
        'If Not editor Is Nothing AndAlso CBool(editor.Value) = True Then
        '    For Each row As GridViewDataRowInfo In Me.dgvLabReport.Rows
        '        If Not row Is Me.dgvLabReport.CurrentRow Then
        '            row.Cells(0).Value = False
        '        End If
        '    Next row
        'End If
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
            Throw ex
        End Try
    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        If btnUSave.Text = "&Save" Then
            If rbReLotSample.Checked = True Then
                Me.SaveReportDataForTran()
                Me.btnUCancel_Click(sender, e)
                Me.bindReportListviewForTran()
            Else
                Me.SaveReportDataForUsed()
                Me.btnUCancel_Click(sender, e)
                Me.bindReportListviewForUsed()
            End If
        Else
            For i As Integer = 0 To dgvLabReport.RowCount - 1
                'If dgvLabReport.Rows(i).Cells(0).Value = False Then
                '    MessageBox.Show("Please Select Record")
                'Else
                Me.UpdateReportDataForUsed()
                    btnUSave.Text = "&Save"
                    Me.bindReportListviewForUsed()
                    Me.btnUCancel_Click(sender, e)
                'End If
            Next
        End If
    End Sub
    Private Sub UpdateReportDataForUsed()
        Dim trans As SqlTransaction = Nothing

        'If ValidateReportData() = False Then
        '    MessageBox.Show("No Report Data Available !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '    cmbLab.Focus()
        'ElseIf String.IsNullOrWhiteSpace(txtLabRptPr.Text.Trim) Then
        '    MessageBox.Show("Enter Lab Percent !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        '    txtLabRptPr.Focus()
        'Else

        Try
                ''Create Parameters for Update
                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvLabReport.RowCount - 1
                If dgvLabReport.Rows(i).IsSelected = True Then
                    'If dgvLabReceipt.Rows(i).Cells(0).Value = True Then
                    Dparameters.Add(dbManager.CreateParameter("@ActionType", "LabReportForTran", DbType.String))
                    Dparameters.Add(dbManager.CreateParameter("@DLabIssueId", Val(dgvLabReport.Rows(i).Cells(1).Value), DbType.Int16))
                    Dparameters.Add(dbManager.CreateParameter("@DIOId", Val(dgvLabReport.Rows(i).Cells(3).Value), DbType.Int16))
                    Dparameters.Add(dbManager.CreateParameter("@LabReport", Val(txtLabRptPr.Text.Trim), DbType.String))
                    Dparameters.Add(dbManager.CreateParameter("@GSampleReceive", Val(txtSampleGrossRec.Text.Trim), DbType.String))
                    Dparameters.Add(dbManager.CreateParameter("@FSampleReceive", Val(txtSampleFineRec.Text.Trim), DbType.String))
                    Dparameters.Add(dbManager.CreateParameter("@ReceiveFineWt", Val(txtTotalRecTotal.Text.Trim), DbType.String))
                    Dparameters.Add(dbManager.CreateParameter("@RGLossWt", Val(txtTotalLossWt.Text.Trim), DbType.String))
                    Dparameters.Add(dbManager.CreateParameter("@RFLossWt", Val(txtTotalLossFine.Text.Trim), DbType.String))
                    Dparameters.Add(dbManager.CreateParameter("@ReceivedBy", Val(UserId), DbType.Int16))
                    dbManager.Update("SP_LabIssue_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                    'End If
                End If
                Dparameters.Clear()
            Next

                MessageBox.Show("Report Data Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
            End Try
        ' End If
    End Sub
    Private Sub txtLabRptPr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLabRptPr.KeyPress
        numdotkeypress(e, txtLabRptPr, Me)
    End Sub
    Private Sub txtSampleFineRec_TextChanged(sender As Object, e As EventArgs) Handles txtSampleFineRec.TextChanged
        txtTotalRecWt.Text = Format(Val(txtSampleFineRec.Text) + Val(txtSampleGrossRec.Text), "0.00")

        txtSampleFineTotal.Text = Format((Val(txtSampleFineRec.Text) * Val(txtSampleFinePr.Text)) / 100, "0.00")
    End Sub
    Private Sub txtSampleGrossRec_TextChanged(sender As Object, e As EventArgs) Handles txtSampleGrossRec.TextChanged
        txtTotalRecWt.Text = Format(Val(txtSampleFineRec.Text) + Val(txtSampleGrossRec.Text), "0.00")

        txtSampleGrossTotal.Text = Format((Val(txtSampleGrossRec.Text) * Val(txtSampleGrossPr.Text)) / 100, "0.000")
    End Sub
    Private Sub txtSampleFineRec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSampleFineRec.KeyPress
        numdotkeypress(e, txtSampleFineRec, Me)
    End Sub
    Private Sub txtSampleGrossRec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSampleGrossRec.KeyPress
        numdotkeypress(e, txtSampleGrossRec, Me)
    End Sub
    Private Sub txtSampleFineTotal_TextChanged(sender As Object, e As EventArgs) Handles txtSampleFineTotal.TextChanged
        txtTotalRecTotal.Text = Format(Val(txtSampleFineTotal.Text) + Val(txtSampleGrossTotal.Text), "0.000")
    End Sub
    Private Sub txtSampleGrossTotal_TextChanged(sender As Object, e As EventArgs) Handles txtSampleGrossTotal.TextChanged
        txtTotalRecTotal.Text = Format(Val(txtSampleFineTotal.Text) + Val(txtSampleGrossTotal.Text), "0.000")
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
        txtTotalLossWt.Text = Format(Val(txtIssueWt.Text) - Val(txtTotalRecWt.Text), "0.00")
    End Sub
    Private Sub txtReceivedPr_TextChanged(sender As Object, e As EventArgs) Handles txtIssuePr.TextChanged
        txtDiff.Text = Format((Val(txtLabRptPr.Text) - Val(txtIssuePr.Text)), "0.00")
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
        txtSampleFineTotal.Text = Format((Val(txtSampleFineRec.Text) * Val(txtSampleFinePr.Text)) / 100, "0.00")
    End Sub
    Private Sub txtTotalRecWt_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRecWt.TextChanged
        txtTotalLossWt.Text = Format((Val(txtIssueWt.Text) - Val(txtTotalRecWt.Text)), "0.00")
    End Sub
    Private Sub txtTotalRecTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRecTotal.TextChanged
        txtTotalLossFine.Text = Format((Val(txtFineRptWt.Text) - Val(txtTotalRecTotal.Text)), "0.00")
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Try
            Call Clear_UForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        Try
            Me.ClearAllData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Call Clear_RForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub DgvLabList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles DgvLabList.CellDoubleClick
        If DgvLabList.Rows.Count > 0 Then
            Dim OtherLabIssueId As Integer = DgvLabList.Rows(e.RowIndex).Cells(0).Value.ToString()
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
    Private Sub Clear_UForm()
        Try
            Me.RptUpdateDt.CustomFormat = "dd/MM/yyyy"
            Me.RptUpdateDt.Value = DateTime.Now

            txtLabRptPr.Clear()
            txtSampleFineRec.Clear()
            txtSampleGrossRec.Clear()
            txtTotalRecWt.Clear()
            txtTotalLossWt.Clear()
            txtSampleGrossPr.Clear()
            txtDiff.Clear()
            txtSampleFineTotal.Clear()
            txtSampleGrossTotal.Clear()
            txtTotalRecTotal.Clear()
            txtTotalLossFine.Clear()

            txtIssueWt.Clear()
            txtIssuePr.Clear
            txtFineRptWt.Clear()

            btnUSave.Text = "&Save"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub dgvLabReceipt_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles dgvLabReceipt.CellValueChanged
        'Dim columnIndex = 0

        'If e.ColumnIndex = columnIndex Then
        '    Dim isChecked = CBool(dgvLabReceipt.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

        '    If isChecked Then
        '        For Each row As GridViewRowInfo In dgvLabReceipt.Rows
        '            If row.Index <> e.RowIndex Then
        '                row.Cells(columnIndex).Value = Not isChecked
        '            End If
        '        Next
        '    End If
        'End If
    End Sub
    Private Sub dgvLabReceipt_ValueChanged(sender As Object, e As EventArgs) Handles dgvLabReceipt.ValueChanged
        If dgvLabReceipt.CurrentColumn.Name = "colChkBox" Then
            dgvLabReceipt.EndEdit()
        End If
        Me.CalculateTotal()
    End Sub
    Private Sub btnICancel_Click(sender As Object, e As EventArgs) Handles btnICancel.Click
        Try
            Call Clear_CForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_CForm()
        Try
            Me.TransDt.CustomFormat = "dd/MM/yyyy"
            Me.TransDt.Value = DateTime.Now

            cmbLab.SelectedIndex = 0

            rbLotSample.Checked = False
            rbBagSample.Checked = False

            dgvLabIssue.DataSource = Nothing
            dgvDataSave.DataSource = Nothing

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_RForm()
        Try
            'Me.RTransDt.CustomFormat = "dd/MM/yyyy"
            'Me.RTransDt.Value = DateTime.Now

            'cmbRBagNo.Enabled = True
            'cmbRBagNo.Text = ""
            'txtRIssueWt.Clear()
            'txtRIssuePr.Clear()
            'txtRBagName.Clear()
            'txtRWtOnScale.Clear()
            'txtRRecieveWt.Clear()

            'txtRSample.Clear()
            'txtRTotalWt.Clear()

            'txtRCarbon.Clear()
            'txtRGrossLoss.Clear()
            'txtRBagName.Clear()

            'dgvRBhukaBag.DataSource = Nothing

            'btnRSave.Text = "&Save"
            'btnREdit.Enabled = True

            'Me.fillRecBagNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class