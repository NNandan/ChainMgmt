Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmRptReceiveDept
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Sub frmRptReceiveDept_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvDeptReceive.AutoGenerateColumns = False

        dgvDeptReceive.EnableFiltering = True
        dgvDeptReceive.MasterTemplate.ShowHeaderCellButtons = True
        dgvDeptReceive.MasterTemplate.ShowFilteringRow = False
        dgvDeptReceive.CurrentRow = Nothing

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colItemName", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colReceiveWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colReceivePr", "{0: 0.00}", GridAggregateFunction.None)
        totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(colReceiveWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt, totalItemGPr})
        Me.dgvDeptReceive.SummaryRowsBottom.Add(totalRow)

        dgvDeptReceive.DataSource = FetchAllRecords()

        'Me.CalculateTotal()
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        dgvDeptReceive.PrintPreview()
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            parameters.Add(dbManager.CreateParameter("@ActionType", "GetStockData", DbType.String))
            dtData = dbManager.GetDataTable("SP_Receipt_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub frmRptReceiveDept_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CalculateTotal()
        Try

            Dim sRWtTotal As Single = 0
            Dim sRPrTotal As Single = 0
            Dim sFWtTotal As Single = 0

            For Each row As GridViewRowInfo In dgvDeptReceive.ChildRows
                sRWtTotal += Single.Parse(row.Cells(4).Value)
                sFWtTotal += Single.Parse(row.Cells(6).Value)
            Next

            If Not sFWtTotal = 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            lblReceiveWt.Text = Format(sRWtTotal, "0.00")
            lblReceivePr.Text = Format(sRPrTotal, "0.00")
            lblFineWt.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvDeptReceive_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvDeptReceive.ViewCellFormatting
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