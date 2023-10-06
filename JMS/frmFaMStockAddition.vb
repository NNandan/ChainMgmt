Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFaMStockAddition
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmMStockAddition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgvMStockAdd.AutoGenerateColumns = False
        dgvMStockAdd.EnableFiltering = True
        dgvMStockAdd.MasterTemplate.ShowHeaderCellButtons = True
        dgvMStockAdd.MasterTemplate.ShowFilteringRow = False
        dgvMStockAdd.CurrentRow = Nothing

        dgvMStockAdd.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colLotNo", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colStockAddGross", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colStockAddFine", "{0}", GridAggregateFunction.Sum)

        Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)

        totalItemGPr.AggregateExpression = "(Sum(colStockAddFine) / Sum(colStockAddGross)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt, totalItemGPr})
        Me.dgvMStockAdd.SummaryRowsBottom.Add(totalRow)

        dgvMStockAdd.DataSource = FetchAllFancys()
    End Sub
    Private Function FetchAllFancys() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchStockAdditionMelting", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockAdditionReport_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Try
            If dgvMStockAdd.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                dgvMStockAdd.PrintPreview()
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