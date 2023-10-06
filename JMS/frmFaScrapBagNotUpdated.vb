Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFaScrapBagNotUpdated
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmScrapBagNotUpdated_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DgvScrapNotUBag.AutoGenerateColumns = False
        DgvScrapNotUBag.EnableFiltering = True
        DgvScrapNotUBag.MasterTemplate.ShowHeaderCellButtons = True
        DgvScrapNotUBag.MasterTemplate.ShowFilteringRow = False
        DgvScrapNotUBag.CurrentRow = Nothing

        Dim totalItemName As GridViewSummaryItem = New GridViewSummaryItem("colItemName", "Total", GridAggregateFunction.Count)
        Dim totalReceiveTWt As GridViewSummaryItem = New GridViewSummaryItem("colScrapWt", "{0}", GridAggregateFunction.Sum)
        Dim totalReceiveFWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalReceivePr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)
        totalReceivePr.AggregateExpression = "(Sum(colFineWt) / Sum(colScrapWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalItemName, totalReceiveTWt, totalReceiveFWt, totalReceivePr})
        Me.DgvScrapNotUBag.SummaryRowsBottom.Add(totalRow)

        DgvScrapNotUBag.DataSource = FetchAllFancys()
    End Sub
    Private Function FetchAllFancys() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "ScrapBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub BtnPrnt_Click(sender As Object, e As EventArgs) Handles BtnPrnt.Click
        Try
            If DgvScrapNotUBag.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                DgvScrapNotUBag.PrintPreview()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class