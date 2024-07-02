Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFIStockAddition
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmIStockAddition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvIStockAdd.AutoGenerateColumns = False
        dgvIStockAdd.EnableFiltering = True
        dgvIStockAdd.MasterTemplate.ShowHeaderCellButtons = True
        dgvIStockAdd.MasterTemplate.ShowFilteringRow = False
        dgvIStockAdd.CurrentRow = Nothing

        Dim totalItemName As GridViewSummaryItem = New GridViewSummaryItem("colVoucherNo", "Total", GridAggregateFunction.Count)
        Dim totalReceiveTWt As GridViewSummaryItem = New GridViewSummaryItem("colStockAddGross", "{0}", GridAggregateFunction.Sum)
        Dim totalReceiveFWt As GridViewSummaryItem = New GridViewSummaryItem("colStockAddFine", "{0}", GridAggregateFunction.Sum)

        Dim totalReceivePr As GridViewSummaryItem = New GridViewSummaryItem("colConvPr", "{0: 0.00}", GridAggregateFunction.None)
        totalReceivePr.AggregateExpression = "(Sum(colStockAddFine) / Sum(colStockAddGross)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalItemName, totalReceiveTWt, totalReceiveFWt, totalReceivePr})
        Me.dgvIStockAdd.SummaryRowsBottom.Add(totalRow)

        dgvIStockAdd.DataSource = FetchAllFancys()
    End Sub
    Private Function FetchAllFancys() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchStockAdditionIssueReceive", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockAdditionReport_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Try
            If dgvIStockAdd.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                dgvIStockAdd.PrintPreview()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
End Class