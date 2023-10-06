Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFStockAdditionVReport
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmStockAdditionVoucherReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fetchStockAdditionDetails()
    End Sub
    Private Sub fetchStockAdditionDetails()
        rdgvVoucher.AutoGenerateColumns = False
        rdgvVoucher.EnableFiltering = True
        rdgvVoucher.MasterTemplate.ShowHeaderCellButtons = True
        rdgvVoucher.MasterTemplate.ShowFilteringRow = False
        rdgvVoucher.CurrentRow = Nothing

        Dim totalConverted As GridViewSummaryItem = New GridViewSummaryItem("colConvertToMelting", "Total", GridAggregateFunction.Count)
        Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalRecFineWt As GridViewSummaryItem = New GridViewSummaryItem("colRecFineWt", "{0}", GridAggregateFunction.Sum)
        Dim totalStockAddGross As GridViewSummaryItem = New GridViewSummaryItem("colStockAddGross", "{0}", GridAggregateFunction.Sum)
        Dim totalStockAddFine As GridViewSummaryItem = New GridViewSummaryItem("colStockAddFine", "{0}", GridAggregateFunction.Sum)

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalConverted, totalReceiveWt, totalRecFineWt, totalStockAddGross, totalStockAddFine})
        Me.rdgvVoucher.SummaryRowsBottom.Add(totalRow)

        rdgvVoucher.DataSource = FetchStockAdditionReport()
    End Sub
    Private Function FetchStockAdditionReport() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchStockAdditionVoucher", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockAdditionReport_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If rdgvVoucher.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                rdgvVoucher.PrintPreview()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub frmStockAdditionVReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub rdgvVoucher_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles rdgvVoucher.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "totalConverted" Then
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