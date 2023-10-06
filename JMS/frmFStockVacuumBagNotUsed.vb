Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFStockVacuumBagNotUsed
    Dim dbManager As New SqlHelper()
    Private Sub frmStockVacuumBagNotUsed_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvStock.AutoGenerateColumns = False
        dgvStock.EnableFiltering = True
        dgvStock.MasterTemplate.ShowHeaderCellButtons = True
        dgvStock.MasterTemplate.ShowFilteringRow = False
        dgvStock.CurrentRow = Nothing

        Dim totalItemName As GridViewSummaryItem = New GridViewSummaryItem("colItemName", "Total", GridAggregateFunction.Count)
        Dim totalReceiveTWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalReceiveFWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalReceivePr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)
        totalReceivePr.AggregateExpression = "(Sum(colFineWt) / Sum(colReceiveWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalItemName, totalReceiveTWt, totalReceiveFWt, totalReceivePr})
        Me.dgvStock.SummaryRowsBottom.Add(totalRow)

        dgvStock.DataSource = FetchAllFancys()
    End Sub
    Private Function FetchAllFancys() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "VacuumBagsNotUsedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub frmStockVacuumBagNotUsed_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
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
            If dgvStock.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                dgvStock.PrintPreview()
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
    Private Sub dgvStock_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvStock.ViewCellFormatting
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