Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports System.Linq
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Public Class frmRptLotAdditionOpStock
    Dim dbManager As New SqlHelper()
    Private Sub frmRptLotAdditionOpStock_Load(sender As Object, e As EventArgs) Handles Me.Load

        With dgvLotAdditionStock
            .AutoGenerateColumns = False
            .EnableFiltering = True
            .MasterTemplate.AutoExpandGroups = True
            .MasterTemplate.ShowHeaderCellButtons = True
            .MasterTemplate.ShowFilteringRow = False
            .CurrentRow = Nothing
        End With

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colItemName", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colGrossWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colGrossPr", "{0: 0.00}", GridAggregateFunction.None)
        totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(colGrossWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt, totalItemGPr})
        Me.dgvLotAdditionStock.SummaryRowsBottom.Add(totalRow)

        dgvLotAdditionStock.DataSource = FetchAllRecords()

    End Sub
    Private Function FetchAllRecords() As DataTable
        Dim new_Table As DataTable = New DataTable()

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchLotAdditionStock", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub dgvLotAdditionStock_GroupSummaryEvaluate(sender As Object, e As GroupSummaryEvaluationEventArgs) Handles dgvLotAdditionStock.GroupSummaryEvaluate
        'If e.SummaryItem.Name = "colLotNumber" Then
        '    e.FormatString = String.Format("There are {0} Gross total.", e.Value)
        'End If

        If e.SummaryItem.Name = "colLotNumber" Then
            Dim iLotNoCount As Integer = e.Group.ItemCount
            Dim dSumOfWt As Double = 0

            For Each row As GridViewRowInfo In e.Group
                dSumOfWt += 1
            Next

            e.FormatString = [String].Format("There are {0} {1} and {2} of them is(are) from France.", iLotNoCount, e.Value, dSumOfWt)
        End If
    End Sub
    Private Sub dgvLotAdditionStock_DataBindingComplete(sender As Object, e As GridViewBindingCompleteEventArgs) Handles dgvLotAdditionStock.DataBindingComplete
        'Dim dGrossPr As Double = 0

        'Dim summaryRowItem As GridViewSummaryRowItem = New GridViewSummaryRowItem()

        'For i As Integer = 3 To dgvLotAdditionStock.Columns.Count - 1
        '    Dim summaryItem As GridViewSummaryItem = New GridViewSummaryItem()
        '    summaryItem.Name = dgvLotAdditionStock.Columns(i).Name

        '    If TypeOf dgvLotAdditionStock.Columns(0) Is GridViewDecimalColumn Then
        '        summaryItem.Aggregate = GridAggregateFunction.Count
        '    Else
        '        summaryItem.Aggregate = GridAggregateFunction.Sum
        '    End If

        '    summaryRowItem.Add(summaryItem)
        'Next

        'dgvLotAdditionStock.SummaryRowsBottom.Add(summaryRowItem)
    End Sub
    Private Sub dgvLotAdditionStock_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvLotAdditionStock.ViewCellFormatting
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
    Private Sub frmRptLotAdditionOpStock_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            Me.Cursor = Cursors.WaitCursor
            Me.dgvLotAdditionStock.PrintPreview()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class