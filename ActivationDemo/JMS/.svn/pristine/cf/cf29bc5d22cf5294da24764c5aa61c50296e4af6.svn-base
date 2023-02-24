Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmRptIssueDept
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Sub frmRptIssueDept_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvDeptIssue.AutoGenerateColumns = False

        dgvDeptIssue.EnableFiltering = True
        dgvDeptIssue.MasterTemplate.ShowHeaderCellButtons = True
        dgvDeptIssue.MasterTemplate.ShowFilteringRow = False
        dgvDeptIssue.CurrentRow = Nothing

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colItemName", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colIssuePr", "{0: 0.00}", GridAggregateFunction.None)
        totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(colIssueWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt, totalItemGPr})
        Me.dgvDeptIssue.SummaryRowsBottom.Add(totalRow)

        dgvDeptIssue.DataSource = FetchAllRecords()

        'Me.CalculateTotal()
    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim strFileSavePath As String = Nothing
        Dim strFileName As String = "InterDeptIssue_Data.xlsx"

        If strFileName.Length > 31 Then
            MessageBox.Show("FileName Should not be greater than 31 Characters" & vbTab & strFileName)
            Exit Sub
        End If

        strFileName = strFileName.Replace(".xlsx", "_" & System.DateTime.Now.ToString("yyyyMMdd") & ".xlsx")

        'Dim obj As ExcelUtlity = New ExcelUtlity
        'obj.WriteDataTableToExcel(FetchAllRecords(), strFileName, "D:\" & strFileName & ".xlsx", "Details")

        MessageBox.Show("Excel created D:" & vbTab & strFileName)

    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                parameters.Add(dbManager.CreateParameter("@ActionType", "GetStockData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Issue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub frmRptIssueDept_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvDeptIssue_FilterChanged(sender As Object, e As GridViewCollectionChangedEventArgs) Handles dgvDeptIssue.FilterChanged
        'Try
        '    Me.CalculateTotal()

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub CalculateTotal()
        Try

            Dim sRWtTotal As Single = 0
            Dim sRPrTotal As Single = 0
            Dim sFWtTotal As Single = 0

            For Each row As GridViewRowInfo In dgvDeptIssue.ChildRows
                sRWtTotal += Single.Parse(row.Cells(5).Value)
                sFWtTotal += Single.Parse(row.Cells(7).Value)
            Next

            If Not sFWtTotal = 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            lblIssueWt.Text = Format(sRWtTotal, "0.00")
            lblIssuePr.Text = Format(sRPrTotal, "0.00")
            lblFineWt.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvDeptIssue_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvDeptIssue.ViewCellFormatting
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