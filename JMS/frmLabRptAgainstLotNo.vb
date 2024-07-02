Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmLabRptAgainstLotNo
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmLabRptAgainstLotNo_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvLabReport.AutoGenerateColumns = False

        dgvLabReport.EnableFiltering = True
        dgvLabReport.MasterTemplate.ShowHeaderCellButtons = True
        dgvLabReport.MasterTemplate.ShowFilteringRow = False
        dgvLabReport.CurrentRow = Nothing

        'Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colItemName", "Total", GridAggregateFunction.Count)
        'Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colIssueWt", "{0}", GridAggregateFunction.Sum)
        'Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("colFineWt", "{0}", GridAggregateFunction.Sum)

        'Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("colIssuePr", "{0: 0.00}", GridAggregateFunction.None)
        'totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(colIssueWt)  * 100)"

        'Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt, totalItemGPr})
        'Me.dgvLabReport.SummaryRowsBottom.Add(totalRow)

        dgvLabReport.DataSource = FetchAllRecords()
    End Sub

    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                parameters.Add(dbManager.CreateParameter("@ActionType", "FetchLabReportAgainstLotNo", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub frmLabRptAgainstLotNo_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
End Class