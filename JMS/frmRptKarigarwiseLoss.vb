Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmRptKarigarwiseLoss
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmRptKarigarwiseLoss_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvWipLotNo.AutoGenerateColumns = False

        dgvWipLotNo.EnableFiltering = True
        dgvWipLotNo.MasterTemplate.ShowHeaderCellButtons = True
        dgvWipLotNo.MasterTemplate.ShowFilteringRow = False
        dgvWipLotNo.CurrentRow = Nothing
        '
        Dim totalOpType As GridViewSummaryItem = New GridViewSummaryItem("colOperationType", "Total", GridAggregateFunction.Count)

        Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
        Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalLossWt As GridViewSummaryItem = New GridViewSummaryItem("colLossWt", "{0}", GridAggregateFunction.Sum)
        Dim totalLossFineWt As GridViewSummaryItem = New GridViewSummaryItem("colLossFine", "{0}", GridAggregateFunction.Sum)
        Dim totalBhukaWt As GridViewSummaryItem = New GridViewSummaryItem("colBhukaWt", "{0}", GridAggregateFunction.Sum)
        Dim totalSampleWt As GridViewSummaryItem = New GridViewSummaryItem("colSampleWt", "{0}", GridAggregateFunction.Sum)
        Dim totalRecWt As GridViewSummaryItem = New GridViewSummaryItem("colRecWt", "{0}", GridAggregateFunction.Sum)

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalOpType, totalIssueWt, totalReceiveWt, totalLossWt, totalLossFineWt, totalBhukaWt, totalSampleWt, totalRecWt})
        Me.dgvWipLotNo.SummaryRowsBottom.Add(totalRow)

        dgvWipLotNo.DataSource = FetchAllRecords()
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetKarigarWiseLossReport", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub frmRptKarigarwiseLoss_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            Me.dgvWipLotNo.PrintPreview()
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub dgvWipLotNo_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvWipLotNo.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colOperationType" Then
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