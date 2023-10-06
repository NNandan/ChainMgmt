Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFSilverMeltingRpt
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmSilverMeltingRpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvSilverRpt.AutoGenerateColumns = False
        dgvSilverRpt.EnableFiltering = True
        dgvSilverRpt.MasterTemplate.ShowHeaderCellButtons = True
        dgvSilverRpt.MasterTemplate.ShowFilteringRow = False
        dgvSilverRpt.CurrentRow = Nothing

        Dim totalLotNo As GridViewSummaryItem = New GridViewSummaryItem("colLotNo", "Total", GridAggregateFunction.Count)
        Dim totalGrossWt As GridViewSummaryItem = New GridViewSummaryItem("colGrossWt", "{0}", GridAggregateFunction.Sum)
        Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalAlloyWt As GridViewSummaryItem = New GridViewSummaryItem("colAlloyWt", "{0}", GridAggregateFunction.Sum)
        Dim totalSilverWt As GridViewSummaryItem = New GridViewSummaryItem("colSilverWt", "{0}", GridAggregateFunction.Sum)

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalLotNo, totalGrossWt, totalFineWt, totalAlloyWt, totalSilverWt})
        Me.dgvSilverRpt.SummaryRowsBottom.Add(totalRow)

        dgvSilverRpt.DataSource = FetchAllRecords()
    End Sub
    Private Function FetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchSilverPrReport", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fMelting_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim doc As New RadPrintDocument()
            doc.AssociatedObject = Me.dgvSilverRpt

            doc.LeftFooter = "Page [Page #] of [Total Pages]"
            doc.LeftHeader = "[Time Printed]"
            doc.MiddleFooter = "***"
            doc.MiddleHeader = "Report Name"
            doc.RightHeader = "[Date Printed]"

            Dim dialog As New RadPrintPreviewDialog(doc)
            dialog.WindowState = FormWindowState.Maximized

            dialog.ThemeName = Me.dgvSilverRpt.ThemeName
            dialog.ShowDialog()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub dgvSilverRpt_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvSilverRpt.ViewCellFormatting
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
End Class