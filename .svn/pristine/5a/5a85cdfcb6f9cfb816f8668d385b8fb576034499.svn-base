Imports System.Collections.Specialized
Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmStockBagsNotUsed
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Sub frmStockBagsNotUsed_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.dgvWipLotNo.AutoGenerateColumns = False

        Me.dgvWipLotNo.EnableFiltering = True
        Me.dgvWipLotNo.MasterTemplate.EnableFiltering = True

        Me.dgvWipLotNo.MasterTemplate.ShowHeaderCellButtons = True
        Me.dgvWipLotNo.MasterTemplate.ShowFilteringRow = False
        Me.dgvWipLotNo.CurrentRow = Nothing

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colBagsType", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)
        totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(colIssueWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt})
        Me.dgvWipLotNo.SummaryRowsBottom.Add(totalRow)

        Me.dgvWipLotNo.DataSource = FetchAllRecords()
    End Sub
    Private Function FetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "BagsNotUsedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub frmStockBagsNotUsed_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If dgvWipLotNo.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Me.dgvWipLotNo.PrintPreview()
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