Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmMetalUsedInBag
    Dim dbManager As New SqlHelper()
    Dim strSQL As String = Nothing
    Private Sub frmMetalUsedInBag_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub frmMetalUsedInBag_Load(sender As Object, e As EventArgs) Handles Me.Load

        With dgvMeltingBagList
            .AutoGenerateColumns = False
            .EnableFiltering = True
            .MasterTemplate.ShowHeaderCellButtons = True
            .MasterTemplate.ShowFilteringRow = False
            .CurrentRow = Nothing
        End With

        dgvMeltingBagList.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colUsedIn", "Total", GridAggregateFunction.Count)
        Dim totalRecieveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
        Dim totalIssuePr As GridViewSummaryItem = New GridViewSummaryItem("colIssuePr", "{0}", GridAggregateFunction.Sum)
        Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)
        totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(colBhukaWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalRecieveWt, totalIssueWt, totalIssuePr, totalFineWt})
        Me.dgvMeltingBagList.SummaryRowsBottom.Add(totalRow)

        dgvMeltingBagList.DataSource = FetchAllRecords()

    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetStockDataByBag", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim doc As New RadPrintDocument()
            doc.AssociatedObject = Me.dgvMeltingBagList

            doc.LeftFooter = "Page [Page #] of [Total Pages]"
            doc.LeftHeader = "[Time Printed]"
            doc.MiddleFooter = "***"
            doc.MiddleHeader = "Report Name"
            doc.RightHeader = "[Date Printed]"

            Dim dialog As New RadPrintPreviewDialog(doc)
            dialog.WindowState = FormWindowState.Maximized

            dialog.ThemeName = Me.dgvMeltingBagList.ThemeName
            dialog.ShowDialog()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
        Finally

        End Try
    End Sub
    Private Sub dgvMeltingBagList_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvMeltingBagList.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then
            If e.Column.Name = "colUsedIn" Then
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