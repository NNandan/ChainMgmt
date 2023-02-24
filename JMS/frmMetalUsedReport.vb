Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Public Class frmMetalUsedReport
    Dim dbManager As New SqlHelper()
    Dim strSQL As String = Nothing
    Private Sub frmMetalUsedReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvMeltingBagList.AutoGenerateColumns = False
        dgvMeltingBagList.EnableFiltering = True
        dgvMeltingBagList.MasterTemplate.ShowHeaderCellButtons = True
        dgvMeltingBagList.MasterTemplate.ShowFilteringRow = False
        dgvMeltingBagList.CurrentRow = Nothing

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colUsedInLotNo", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colIssuePr", "{0: 0.00}", GridAggregateFunction.None)
        totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(colIssueWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt, totalItemGPr})
        Me.dgvMeltingBagList.SummaryRowsBottom.Add(totalRow)

        dgvMeltingBagList.DataSource = FetchAllRecords()
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchReportBagNoWise", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Melting_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor


            Dim doc As New RadPrintDocument()
            doc.AssociatedObject = Me.dgvMeltingBagList

            doc.LeftFooter = "Page [Page #] of [Total Pages]"
            doc.LeftHeader = "[Time Printed]"
            doc.MiddleFooter = "***"
            doc.MiddleHeader = "Report Name"
            doc.RightHeader = "[Date Printed]"

            Dim dialog As New RadPrintPreviewDialog(doc)
            dialog.WindowState = FormWindowState.Maximized

            dialog.ThemeName = Me.dgvMeltingBagList.ThemeName
            dialog.ShowDialog()

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub frmMetalUsedReport_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim doc As New RadPrintDocument()
            doc.AssociatedObject = Me.dgvMeltingBagList

            doc.LeftFooter = "Page [Page #] of [Total Pages]"
            doc.LeftHeader = "[Time Printed]"
            doc.MiddleFooter = "***"
            doc.MiddleHeader = "Report Name"
            doc.RightHeader = "[Date Printed]"

            Dim dialog As New RadPrintPreviewDialog(doc)
            dialog.WindowState = FormWindowState.Maximized

            dialog.ThemeName = Me.dgvMeltingBagList.ThemeName
            dialog.ShowDialog()

        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dgvMeltingBagList_ViewCellFormatting(sender As Object, e As UI.CellFormattingEventArgs) Handles dgvMeltingBagList.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colUsedInLotNo" Then
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
End Class