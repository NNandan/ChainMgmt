Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmRptLotFail
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Sub btnShow_Click(sender As Object, e As EventArgs)
        dgvLotFailList.PrintPreview()
    End Sub
    Private Sub frmRptLotFail_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvLotFailList.AutoGenerateColumns = False

        dgvLotFailList.EnableFiltering = True
        dgvLotFailList.MasterTemplate.ShowHeaderCellButtons = True
        dgvLotFailList.MasterTemplate.ShowFilteringRow = False
        dgvLotFailList.CurrentRow = Nothing

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("colLotNumber", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("colLotFailWt", "{0}", GridAggregateFunction.Sum)

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt})
        Me.dgvLotFailList.SummaryRowsBottom.Add(totalRow)

        dgvLotFailList.DataSource = FetchAllRecords()
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchLotFailRpt", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub frmRptLotFail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
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
    Private Sub CalculateTotal()
        Try

            Dim sRWtTotal As Single = 0
            Dim sRPrTotal As Single = 0
            Dim sFWtTotal As Single = 0

            For Each row As GridViewRowInfo In dgvLotFailList.ChildRows
                sRWtTotal += Single.Parse(row.Cells(3).Value)
                sFWtTotal += Single.Parse(row.Cells(4).Value)
            Next

            If Not sFWtTotal = 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If dgvLotFailList.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor

                Dim doc As New RadPrintDocument()
                doc.AssociatedObject = Me.dgvLotFailList

                doc.LeftFooter = "Page [Page #] of [Total Pages]"
                doc.LeftHeader = "[Time Printed]"
                doc.MiddleFooter = "***"
                doc.MiddleHeader = "Report Name"
                doc.RightHeader = "[Date Printed]"

                Dim dialog As New RadPrintPreviewDialog(doc)
                dialog.WindowState = FormWindowState.Maximized

                dialog.ThemeName = Me.dgvLotFailList.ThemeName
                dialog.ShowDialog()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub dgvLotFailList_ViewCellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvLotFailList.ViewCellFormatting
        If TypeOf e.Row Is GridViewSummaryRowInfo Then

            If e.Column.Name = "colLotNumber" Then
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