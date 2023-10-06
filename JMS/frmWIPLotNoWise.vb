Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI

Public Class frmWIPLotNoWise
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmWIPLotNoWise_Load(sender As Object, e As EventArgs) Handles Me.Load

        With dgvWipLotNo
            .AutoGenerateColumns = False
            .DataSource = FetchAllRecords()
            .EnableFiltering = True
            .MasterTemplate.ShowHeaderCellButtons = True
            .MasterTemplate.ShowFilteringRow = False
            .CurrentRow = Nothing
        End With

        Dim totalOperationName As GridViewSummaryItem = New GridViewSummaryItem("colOperationName", "Total", GridAggregateFunction.Count)

        ''Issue Wt 
        Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
        Dim totalIssueFt As GridViewSummaryItem = New GridViewSummaryItem("colIssueFine", "{0}", GridAggregateFunction.Sum)

        Dim totalIssuePr As GridViewSummaryItem = New GridViewSummaryItem("colIssuePr", "{0: 0.00}", GridAggregateFunction.None)
        totalIssuePr.AggregateExpression = "(Sum(colIssueFine) / Sum(colIssueWt)  * 100)"
        ''Issue Wt 

        ''Receive Wt
        Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalReceiveFt As GridViewSummaryItem = New GridViewSummaryItem("colRecieveFine", "{0}", GridAggregateFunction.Sum)
        ''Receive Wt

        Dim totalReceivePr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)
        totalReceivePr.AggregateExpression = "(Sum(colRecieveFine) / Sum(colReceiveWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalOperationName, totalIssueWt, totalIssueFt, totalIssuePr, totalReceiveWt, totalReceiveFt, totalReceivePr})
        Me.dgvWipLotNo.SummaryRowsBottom.Add(totalRow)

        dgvWipLotNo.DataSource = FetchAllRecords()

    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetAllWIPLots", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub frmWIPLotNoWise_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
                SendKeys.Send("{HOME}+{END}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvWipLotNo_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvWipLotNo.ViewCellFormatting
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
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If dgvWipLotNo.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor

                Dim doc As New RadPrintDocument()
                doc.AssociatedObject = Me.dgvWipLotNo

                doc.LeftFooter = "Page [Page #] of [Total Pages]"
                doc.LeftHeader = "[Time Printed]"
                doc.MiddleFooter = "***"
                doc.MiddleHeader = "Report Name"
                doc.RightHeader = "[Date Printed]"

                Dim dialog As New RadPrintPreviewDialog(doc)
                dialog.WindowState = FormWindowState.Maximized

                dialog.ThemeName = Me.dgvWipLotNo.ThemeName
                dialog.ShowDialog()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class