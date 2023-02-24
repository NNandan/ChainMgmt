Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmLotFailBagNotUsed
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())

    Private Sub frmLotFailBagUsed_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvLotFailBagNo.AutoGenerateColumns = False
        dgvLotFailBagNo.EnableFiltering = True
        dgvLotFailBagNo.MasterTemplate.ShowHeaderCellButtons = True
        dgvLotFailBagNo.MasterTemplate.ShowFilteringRow = False
        dgvLotFailBagNo.CurrentRow = Nothing

        dgvLotFailBagNo.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colItemName", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)
        totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(colReceiveWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt, totalItemGPr})
        Me.dgvLotFailBagNo.SummaryRowsBottom.Add(totalRow)

        dgvLotFailBagNo.DataSource = FetchAllRecords()
    End Sub
    Private Function FetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "LotFailBagNotUsed", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If dgvLotFailBagNo.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                dgvLotFailBagNo.PrintPreview()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dgvLotFailBagNo_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvLotFailBagNo.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colItemName" Then
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