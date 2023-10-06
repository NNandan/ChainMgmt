Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Public Class frmFKarigarwiseLossRpt
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmKarigarwiseLossRpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        rdgvLossRpt.AutoGenerateColumns = False
        rdgvLossRpt.EnableFiltering = True
        rdgvLossRpt.MasterTemplate.ShowHeaderCellButtons = True
        rdgvLossRpt.MasterTemplate.ShowFilteringRow = False
        rdgvLossRpt.CurrentRow = Nothing

        rdgvLossRpt.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill

        Me.rdgvLossRpt.MasterTemplate.SummaryRowGroupHeaders.Add(New GridViewSummaryRowItem(New GridViewSummaryItem() {New GridViewSummaryItem("colIssueWt", "Total = {0}", GridAggregateFunction.Sum)}))
        Me.rdgvLossRpt.MasterTemplate.SummaryRowGroupHeaders.Add(New GridViewSummaryRowItem(New GridViewSummaryItem() {New GridViewSummaryItem("colReceiveWt", "Total = {0}", GridAggregateFunction.Sum)}))
        Me.rdgvLossRpt.GroupDescriptors.Add(New GroupDescriptor("colLabourName"))

        Dim totalMelting As GridViewSummaryItem = New GridViewSummaryItem("colMeltingValue", "Total", GridAggregateFunction.Count)
        Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
        Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalBalanceWt As GridViewSummaryItem = New GridViewSummaryItem("colBalanceWt", "{0}", GridAggregateFunction.Sum)
        Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalMelting, totalIssueWt, totalReceiveWt, totalBalanceWt, totalFineWt})
        Me.rdgvLossRpt.SummaryRowsBottom.Add(totalRow)

        rdgvLossRpt.DataSource = FetchAllRecords()

    End Sub
    Private Function FetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchKarigarWiseLoss", DbType.String))
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
    Private Sub frmKarigarwiseLossRpt_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If rdgvLossRpt.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Me.rdgvLossRpt.PrintPreview()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub rdgvKarigarwiseLoss_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles rdgvLossRpt.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colMeltingValue" Then
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