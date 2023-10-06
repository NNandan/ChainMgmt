Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Public Class frmFaAllLotsRpt
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmAllLotsRpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvAllLots.AutoGenerateColumns = False
        dgvAllLots.EnableFiltering = True
        dgvAllLots.MasterTemplate.ShowHeaderCellButtons = True
        dgvAllLots.MasterTemplate.ShowFilteringRow = False
        dgvAllLots.CurrentRow = Nothing

        Dim totalOpName As GridViewSummaryItem = New GridViewSummaryItem("colOperationName", "Total", GridAggregateFunction.Count)
        Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
        Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalBalanceWt As GridViewSummaryItem = New GridViewSummaryItem("colBalanceWt", "{0}", GridAggregateFunction.Sum)

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalOpName, totalIssueWt, totalReceiveWt, totalBalanceWt})
        Me.dgvAllLots.SummaryRowsBottom.Add(totalRow)

        dgvAllLots.DataSource = FetchAllRecords()
    End Sub
    Private Function FetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchAllLots", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub frmAllLotsRpt_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
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
            doc.AssociatedObject = Me.dgvAllLots

            doc.LeftFooter = "Page [Page #] of [Total Pages]"
            doc.LeftHeader = "[Time Printed]"
            doc.MiddleFooter = "***"
            doc.MiddleHeader = "Report Name"
            doc.RightHeader = "[Date Printed]"

            Dim dialog As New RadPrintPreviewDialog(doc)
            dialog.WindowState = FormWindowState.Maximized

            dialog.ThemeName = Me.dgvAllLots.ThemeName
            dialog.ShowDialog()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        Finally

        End Try
    End Sub
    Private Sub dgvAllLots_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvAllLots.ViewCellFormatting
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
End Class