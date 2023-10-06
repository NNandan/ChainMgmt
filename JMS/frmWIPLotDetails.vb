Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmWIPLotDetails
    Dim dbManager As New SqlHelper()
    Dim iGcancel As Boolean = False
    Dim iOcancel As Boolean = False
    Dim iAcancel As Boolean = False
    Private Sub fillAllStocksDetails()
        dgvStockAll.AutoGenerateColumns = False
        dgvStockAll.EnableFiltering = True
        dgvStockAll.MasterTemplate.ShowHeaderCellButtons = True
        dgvStockAll.MasterTemplate.ShowFilteringRow = False
        dgvStockAll.CurrentRow = Nothing

        If iAcancel = False Then
            Dim totalOpName As GridViewSummaryItem = New GridViewSummaryItem("colOperationName", "Total", GridAggregateFunction.Count)

            Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
            Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
            Dim totalBalanceWt As GridViewSummaryItem = New GridViewSummaryItem("colBalanceWt", "{0}", GridAggregateFunction.Sum)
            Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

            Dim totalPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)

            totalPr.AggregateExpression = "(Sum(colFineWt) / Sum(colBalanceWt)  * 100)"

            Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalOpName, totalIssueWt, totalReceiveWt, totalBalanceWt, totalFineWt, totalPr})
            Me.dgvStockAll.SummaryRowsBottom.Add(totalRow)
        End If

        dgvStockAll.DataSource = FetchAllRecords()

    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "WIPLotsAllDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            Dim barcode As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum

            Dim OldDt As DataTable = New DataTable()
            Dim NewDt As DataTable = New DataTable()

            For Each sourcerow As DataRow In OldDt.Rows
                Dim destRow As DataRow = NewDt.NewRow()
                destRow("Item Name") = sourcerow("Item Name")
                destRow("Iwt") = sourcerow("Iwt")
                destRow("LotNo") = barcode.Draw(sourcerow("LotNo"), 50)
                NewDt.Rows.Add(destRow)
            Next

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub fillGoldStocksDetails()
        dgvStockGold.AutoGenerateColumns = False
        dgvStockGold.EnableFiltering = True
        dgvStockGold.MasterTemplate.ShowHeaderCellButtons = True
        dgvStockGold.MasterTemplate.ShowFilteringRow = False
        dgvStockGold.CurrentRow = Nothing

        If iGcancel = False Then
            Dim totalOpName As GridViewSummaryItem = New GridViewSummaryItem("colOperationName", "Total", GridAggregateFunction.Count)

            Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
            Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
            Dim totalBalanceWt As GridViewSummaryItem = New GridViewSummaryItem("colBalanceWt", "{0}", GridAggregateFunction.Sum)
            Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

            Dim totalPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)

            totalPr.AggregateExpression = "(Sum(colFineWt) / Sum(colBalanceWt)  * 100)"

            Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalOpName, totalIssueWt, totalReceiveWt, totalBalanceWt, totalFineWt, totalPr})
            Me.dgvStockGold.SummaryRowsBottom.Add(totalRow)
        End If

        dgvStockGold.DataSource = FetchGoldFancys()
    End Sub
    Private Function FetchGoldFancys() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "WIPLotsGoldDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub fillOtherStocksDetails()
        dgvStockOther.AutoGenerateColumns = False
        dgvStockOther.EnableFiltering = True
        dgvStockOther.MasterTemplate.ShowHeaderCellButtons = True
        dgvStockOther.MasterTemplate.ShowFilteringRow = False
        dgvStockOther.CurrentRow = Nothing

        If iOcancel = False Then
            Dim totalOpName As GridViewSummaryItem = New GridViewSummaryItem("colOperationName", "Total", GridAggregateFunction.Count)

            Dim totalIssueWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
            Dim totalReceiveWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
            Dim totalBalanceWt As GridViewSummaryItem = New GridViewSummaryItem("colBalanceWt", "{0}", GridAggregateFunction.Sum)
            Dim totalFineWt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

            Dim totalPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)

            totalPr.AggregateExpression = "(Sum(colFineWt) / Sum(colBalanceWt)  * 100)"

            Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalOpName, totalIssueWt, totalReceiveWt, totalBalanceWt, totalFineWt, totalPr})
            Me.dgvStockOther.SummaryRowsBottom.Add(totalRow)
        End If

        dgvStockOther.DataSource = FetchOtherFancys()

    End Sub
    Private Function FetchOtherFancys() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "WIPLotsOtherDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub frmWIPLotDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            If dgvStockAll.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                dgvStockAll.PrintPreview()
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
    Private Sub tbWIPLotDetails_TabIndexChanged(sender As Object, e As EventArgs) Handles tbWIPLotDetails.TabIndexChanged
        If tbWIPLotDetails.SelectedIndex = 0 Then     ''for Gold Details
            Me.fillGoldStocksDetails()
            iGcancel = True
        ElseIf tbWIPLotDetails.SelectedIndex = 1 Then ''for Other Details
            Me.fillOtherStocksDetails()
            iOcancel = True
        ElseIf tbWIPLotDetails.SelectedIndex = 2 Then ''for All Details
            Me.fillAllStocksDetails()
            iAcancel = True
        End If
    End Sub
    Private Sub frmWIPLotDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        'tbWIPLotDetails.TabIndex = 2
    End Sub
    Private Sub dgvStockGold_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvStockGold.ViewCellFormatting
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
    Private Sub tbWIPLotDetails_Click(sender As Object, e As EventArgs) Handles tbWIPLotDetails.Click
        If tbWIPLotDetails.SelectedIndex = 0 Then     ''for Gold Details
            Me.fillGoldStocksDetails()
            iGcancel = True
        ElseIf tbWIPLotDetails.SelectedIndex = 1 Then ''for Other Details
            Me.fillOtherStocksDetails()
            iOcancel = True
        ElseIf tbWIPLotDetails.SelectedIndex = 2 Then ''for All Details
            Me.fillAllStocksDetails()
            iAcancel = True
        End If
    End Sub
    Private Sub dgvStockAll_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvStockAll.ViewCellFormatting
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
    Private Sub CopyDatable()
        Dim barcode As Zen.Barcode.Code128BarcodeDraw = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum

        Dim OldDt As DataTable = New DataTable()
        Dim NewDt As DataTable = New DataTable()

        For Each sourcerow As DataRow In OldDt.Rows
            Dim destRow As DataRow = NewDt.NewRow()
            destRow("Item Name") = sourcerow("Item Name")
            destRow("Iwt") = sourcerow("Iwt")
            destRow("LotNo") = barcode.Draw(sourcerow("LotNo"), 50)
            NewDt.Rows.Add(destRow)
        Next
    End Sub
End Class