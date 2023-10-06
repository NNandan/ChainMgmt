Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Public Class frmFVaccumBagRpt
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmVaccumBagRpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        rdgvVaccumBag.AutoGenerateColumns = False
        rdgvVaccumBag.EnableFiltering = True
        rdgvVaccumBag.MasterTemplate.ShowHeaderCellButtons = True
        rdgvVaccumBag.MasterTemplate.ShowFilteringRow = False
        rdgvVaccumBag.CurrentRow = Nothing

        Dim totalLabourName As GridViewSummaryItem = New GridViewSummaryItem("colLabourName", "Total", GridAggregateFunction.Count)
        Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
        Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalVaccumWt As GridViewSummaryItem = New GridViewSummaryItem("colVaccumWt", "{0}", GridAggregateFunction.Sum)

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalLabourName, totalIssueWt, totalReceiveWt, totalVaccumWt})
        Me.rdgvVaccumBag.SummaryRowsBottom.Add(totalRow)

        rdgvVaccumBag.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill
        rdgvVaccumBag.DataSource = FetchAllRecords()
    End Sub
    Private Function FetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchVaccumBags", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray())

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
            If rdgvVaccumBag.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Me.rdgvVaccumBag.PrintPreview()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class