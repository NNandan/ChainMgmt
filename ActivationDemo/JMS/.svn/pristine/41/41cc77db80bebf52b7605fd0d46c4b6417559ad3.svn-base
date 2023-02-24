Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmPendingVoucher
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim strSQL As String = Nothing
    Private Sub frmPendingBagRpt_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmPendingBagRpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvMeltingBagList.AutoGenerateColumns = False
        dgvMeltingBagList.EnableFiltering = True
        dgvMeltingBagList.MasterTemplate.ShowHeaderCellButtons = True
        dgvMeltingBagList.MasterTemplate.ShowFilteringRow = False
        dgvMeltingBagList.CurrentRow = Nothing

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colItemName", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemBWt As GridViewSummaryItem = New GridViewSummaryItem("colBalanceWt", "{0}", GridAggregateFunction.Sum)

        Dim totalPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)

        totalPr.AggregateExpression = "(Sum(colFineWt) / Sum(colBalanceWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt, totalPr, totalItemBWt})
        Me.dgvMeltingBagList.SummaryRowsBottom.Add(totalRow)

        dgvMeltingBagList.DataSource = FetchAllRecords()

    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetStockData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Receipt_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If dgvMeltingBagList.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Me.dgvMeltingBagList.PrintPreview()
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
    Private Sub dgvMeltingBagList_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvMeltingBagList.ViewCellFormatting
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
End Class