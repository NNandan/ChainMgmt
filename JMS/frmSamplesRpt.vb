Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmSamplesRpt
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()

    Dim iNTScancel As Boolean = False
    Dim iTScancel As Boolean = False
    Dim iNTLcancel As Boolean = False
    Dim iTLcancel As Boolean = False
    Private Function FetchAllRecords(ByVal sStoredProc As String, ByVal sReportType As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", CStr(sReportType), DbType.String))
            End With

            dtData = dbManager.GetDataTable(sStoredProc, CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

        Return dtData
    End Function
    Private Sub tbSampleReport_Click(sender As Object, e As EventArgs) Handles tbSampleReport.Click
        If tbSampleReport.SelectedIndex = 0 Then     ''for Not Tested Sample (Bags)
            Me.fillGetNonTestedSampleBags()
            iNTScancel = True
        ElseIf tbSampleReport.SelectedIndex = 1 Then ''for Tested Sample (Bags)
            Me.fillGetTestedSampleBags()
            iTScancel = True
        ElseIf tbSampleReport.SelectedIndex = 2 Then ''for Not Tested Sample (Lots)
            Me.fillGetNonTestedSampleLots()
            iNTLcancel = True
        ElseIf tbSampleReport.SelectedIndex = 3 Then ''for Tested Sample (Lots)
            Me.fillGetTestedSampleLots()
            iTLcancel = True
        End If
    End Sub
    Private Sub dgvNTBSampleReport_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvNtSampleBags.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colOperationName" Then
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft
            Else
                e.CellElement.TextAlignment = ContentAlignment.MiddleRight
            End If
        End If

        If TypeOf e.CellElement Is GridSummaryCellElement Then
            Dim summaryFont As Font = New Font("Tahoma", 9, FontStyle.Bold)
            e.CellElement.Font = summaryFont
        End If
    End Sub
    Private Sub dgvNTLSampleReport_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvNtSampleLots.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colOperationName" Then
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft
            Else
                e.CellElement.TextAlignment = ContentAlignment.MiddleRight
            End If
        End If

        If TypeOf e.CellElement Is GridSummaryCellElement Then
            Dim summaryFont As Font = New Font("Tahoma", 9, FontStyle.Bold)
            e.CellElement.Font = summaryFont
        End If
    End Sub
    Private Sub dgvNTLSampleReport_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles dgvNtSampleLots.CellValueChanged
        If e.Column.Name = "colSampleWt" Then
            Me.dgvNtSampleLots.MasterView.SummaryRows(0).InvalidateRow()
        End If
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If tbSampleReport.SelectedIndex = 0 Then
            Try
                If dgvNtSampleBags.RowCount > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.dgvNtSampleBags.PrintPreview()
                Else
                    MessageBox.Show("No Data to Print")
                End If
            Catch ex As Exception

            Finally
                Me.Cursor = Cursors.Default
            End Try
        ElseIf tbSampleReport.SelectedIndex = 1 Then
            Try
                If dgvTSampleBags.RowCount > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.dgvTSampleBags.PrintPreview()
                Else
                    MessageBox.Show("No Data to Print")
                End If
            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        ElseIf tbSampleReport.SelectedIndex = 2 Then
            Try
                If dgvNtSampleLots.RowCount > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.dgvNtSampleLots.PrintPreview()
                Else
                    MessageBox.Show("No Data to Print")
                End If
            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            Try
                If dgvTSampleLots.RowCount > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.dgvTSampleLots.PrintPreview()
                Else
                    MessageBox.Show("No Data to Print")
                End If
            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If

    End Sub
    Private Sub fillGetNonTestedSampleBags()
        dgvNtSampleBags.DataSource = Nothing

        dgvNtSampleBags.AutoGenerateColumns = False
        dgvNtSampleBags.EnableFiltering = True
        dgvNtSampleBags.MasterTemplate.ShowHeaderCellButtons = True
        dgvNtSampleBags.MasterTemplate.ShowFilteringRow = False
        dgvNtSampleBags.CurrentRow = Nothing

        If iNTScancel = False Then
            Dim totalOpName As GridViewSummaryItem = New GridViewSummaryItem("colOperationName", "Total", GridAggregateFunction.Count)

            Dim totalSampleWt As GridViewSummaryItem = New GridViewSummaryItem("colSampleWt", "{0}", GridAggregateFunction.Sum)
            Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

            Dim totalPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)

            totalPr.AggregateExpression = "(Sum(colFineWt) / Sum(colSampleWt)  * 100)"

            Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalOpName, totalSampleWt, totalFineWt, totalPr})
            Me.dgvNtSampleBags.SummaryRowsBottom.Add(totalRow)
        End If

        dgvNtSampleBags.DataSource = FetchNonTestedSampleBags()
    End Sub
    Private Function FetchNonTestedSampleBags() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetNonTestedSampleBag", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub fillGetTestedSampleBags()

        dgvTSampleBags.DataSource = Nothing

        dgvTSampleBags.AutoGenerateColumns = False
        dgvTSampleBags.EnableFiltering = True
        dgvTSampleBags.MasterTemplate.ShowHeaderCellButtons = True
        dgvTSampleBags.MasterTemplate.ShowFilteringRow = False
        dgvTSampleBags.CurrentRow = Nothing

        If iTScancel = False Then
            Dim totalOpName As GridViewSummaryItem = New GridViewSummaryItem("colOperationName", "Total", GridAggregateFunction.Count)

            Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
            Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

            Dim totalPr As GridViewSummaryItem = New GridViewSummaryItem("colIssuePr", "{0: 0.00}", GridAggregateFunction.None)

            totalPr.AggregateExpression = "(Sum(colFineWt) / Sum(colIssueWt)  * 100)"

            Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalOpName, totalIssueWt, totalFineWt, totalPr})
            Me.dgvTSampleBags.SummaryRowsBottom.Add(totalRow)
        End If

        dgvTSampleBags.DataSource = FetchTestedSampleBags()
    End Sub
    Private Function FetchTestedSampleBags() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchTestedSampleBag", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub fillGetNonTestedSampleLots()
        dgvNtSampleLots.DataSource = Nothing

        dgvNtSampleLots.AutoGenerateColumns = False
        dgvNtSampleLots.EnableFiltering = True
        dgvNtSampleLots.MasterTemplate.ShowHeaderCellButtons = True
        dgvNtSampleLots.MasterTemplate.ShowFilteringRow = False
        dgvNtSampleLots.CurrentRow = Nothing

        If iNTLcancel = False Then
            Dim totalOpName As GridViewSummaryItem = New GridViewSummaryItem("colOperationName", "Total", GridAggregateFunction.Count)

            Dim totalSampleWt As GridViewSummaryItem = New GridViewSummaryItem("colSampleWt", "{0}", GridAggregateFunction.Sum)
            Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

            Dim totalPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)

            totalPr.AggregateExpression = "(Sum(colFineWt) / Sum(colReceivePr)  * 100)"

            Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalOpName, totalSampleWt, totalFineWt, totalPr})
            Me.dgvNtSampleLots.SummaryRowsBottom.Add(totalRow)
        End If

        dgvNtSampleLots.DataSource = FetchNonTestedSampleLots()
    End Sub
    Private Function FetchNonTestedSampleLots() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchNonTestedSampleLot", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub fillGetTestedSampleLots()

        dgvTSampleLots.DataSource = Nothing

        dgvTSampleLots.AutoGenerateColumns = False
        dgvTSampleLots.EnableFiltering = True
        dgvTSampleLots.MasterTemplate.ShowHeaderCellButtons = True
        dgvTSampleLots.MasterTemplate.ShowFilteringRow = False
        dgvTSampleLots.CurrentRow = Nothing

        If iTLcancel = False Then
            Dim totalLotNo As GridViewSummaryItem = New GridViewSummaryItem("colLotNo", "Total", GridAggregateFunction.Count)

            Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
            Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

            Dim totalPr As GridViewSummaryItem = New GridViewSummaryItem("colIssuePr", "{0: 0.00}", GridAggregateFunction.None)

            totalPr.AggregateExpression = "(Sum(colFineWt) / Sum(colIssueWt)  * 100)"

            Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalLotNo, totalIssueWt, totalFineWt, totalPr})
            Me.dgvTSampleLots.SummaryRowsBottom.Add(totalRow)
        End If

        dgvTSampleLots.DataSource = FetchTestedSampleLots()
    End Sub
    Private Function FetchTestedSampleLots() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchTestedSampleLot", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub dgvTSampleBags_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvTSampleBags.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colOperationName" Then
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft
            Else
                e.CellElement.TextAlignment = ContentAlignment.MiddleRight
            End If
        End If

        If TypeOf e.CellElement Is GridSummaryCellElement Then
            Dim summaryFont As Font = New Font("Tahoma", 9, FontStyle.Bold)
            e.CellElement.Font = summaryFont
        End If
    End Sub
    Private Sub dgvTSampleLots_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvTSampleLots.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colLotNo" Then
                e.CellElement.TextAlignment = ContentAlignment.MiddleLeft
            Else
                e.CellElement.TextAlignment = ContentAlignment.MiddleRight
            End If
        End If

        If TypeOf e.CellElement Is GridSummaryCellElement Then
            Dim summaryFont As Font = New Font("Tahoma", 9, FontStyle.Bold)
            e.CellElement.Font = summaryFont
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub frmSamplesReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmSamplesReport_Load(sender As Object, e As EventArgs) Handles Me.Load

        AddHandler tbSampleReport.Click, AddressOf Me.tbSampleReport_Click

        tbSampleReport.SelectedIndex = 0
    End Sub
End Class