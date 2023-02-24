Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmRptLotTransfer
    Dim dbManager As New SqlHelper()
    Private Sub frmRptLotTransfer_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvLotTransfer.AutoGenerateColumns = False
        dgvLotTransfer.EnableFiltering = True
        dgvLotTransfer.MasterTemplate.ShowHeaderCellButtons = True
        dgvLotTransfer.MasterTemplate.ShowFilteringRow = False
        dgvLotTransfer.CurrentRow = Nothing

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colOperationName", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colTransferWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colIssuePr", "{0}", GridAggregateFunction.Sum)

        'Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colIssuePr", "{0: 0.00}", GridAggregateFunction.None)
        'totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(colIssueWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt})
        Me.dgvLotTransfer.SummaryRowsBottom.Add(totalRow)

        dgvLotTransfer.DataSource = FetchAllRecords()

        'Me.CalculateTotal()
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs)
        dgvLotTransfer.PrintPreview()
    End Sub
    Private Sub dgvLotTransfer_FilterChanged(sender As Object, e As GridViewCollectionChangedEventArgs) Handles dgvLotTransfer.FilterChanged
        Try
            Me.CalculateTotal()
        Catch ex As Exception
        End Try
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoTransferReport", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotTransfer_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub CalculateTotal()
        Try

            Dim sRWtTotal As Single = 0
            Dim sRPrTotal As Single = 0
            Dim sFWtTotal As Single = 0

            For Each row As GridViewRowInfo In dgvLotTransfer.ChildRows
                sRWtTotal += Single.Parse(row.Cells(3).Value)
                sFWtTotal += Single.Parse(row.Cells(4).Value)
            Next

            If Not sFWtTotal = 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            lblTransferWt.Text = Format(sRWtTotal, "0.00")
            lblIssuePr.Text = Format(sRPrTotal, "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmRptLotTransfer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            If dgvLotTransfer.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Me.dgvLotTransfer.PrintPreview()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dgvLotTransfer_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvLotTransfer.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colOperationName" Then
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