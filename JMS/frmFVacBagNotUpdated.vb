Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFVacBagNotUpdated
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()

    Private Sub frmVacBagNotUpdated_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DgvVacNotUBag.AutoGenerateColumns = False
        DgvVacNotUBag.EnableFiltering = True
        DgvVacNotUBag.MasterTemplate.ShowHeaderCellButtons = True
        DgvVacNotUBag.MasterTemplate.ShowFilteringRow = False
        DgvVacNotUBag.CurrentRow = Nothing

        Dim totalItemName As GridViewSummaryItem = New GridViewSummaryItem("colItemName", "Total", GridAggregateFunction.Count)
        Dim totalReceiveTWt As GridViewSummaryItem = New GridViewSummaryItem("colScrapWt", "{0}", GridAggregateFunction.Sum)
        Dim totalReceiveFWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalReceivePr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)
        totalReceivePr.AggregateExpression = "(Sum(colFineWt) / Sum(colScrapWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalItemName, totalReceiveTWt, totalReceiveFWt, totalReceivePr})
        Me.DgvVacNotUBag.SummaryRowsBottom.Add(totalRow)

        DgvVacNotUBag.DataSource = FetchAllFancys()
    End Sub
    Private Function FetchAllFancys() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumeBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If DgvVacNotUBag.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                DgvVacNotUBag.PrintPreview()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class