Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmAllBhukaBagRpt
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmNewAllBhukaBagReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvBhukaBagList.AutoGenerateColumns = False
        dgvBhukaBagList.EnableFiltering = True
        dgvBhukaBagList.MasterTemplate.ShowHeaderCellButtons = True
        dgvBhukaBagList.MasterTemplate.ShowFilteringRow = False
        dgvBhukaBagList.CurrentRow = Nothing

        dgvBhukaBagList.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colBhukaBagNo", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colBhukaWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)
        totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(colBhukaWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt, totalItemGPr})
        Me.dgvBhukaBagList.SummaryRowsBottom.Add(totalRow)

        dgvBhukaBagList.DataSource = FetchAllRecords()
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "AllScrapBagDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub dgvBhukaBagList_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvBhukaBagList.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colBhukaBagNo" Then
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
    Private Sub frmNewAllBhukaBagReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
                SendKeys.Send("{HOME}+{END}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim doc As New RadPrintDocument()
            doc.AssociatedObject = Me.dgvBhukaBagList

            doc.LeftFooter = "Page [Page #] of [Total Pages]"
            doc.LeftHeader = "[Time Printed]"
            doc.MiddleFooter = "***"
            doc.MiddleHeader = "Report Name"
            doc.RightHeader = "[Date Printed]"

            Dim dialog As New RadPrintPreviewDialog(doc)
            dialog.WindowState = FormWindowState.Maximized

            dialog.ThemeName = Me.dgvBhukaBagList.ThemeName
            dialog.ShowDialog()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class