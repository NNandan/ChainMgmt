Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmScrapReceiveRpt
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper()
    Private Sub frmScrapReceiveReport_Load(sender As Object, e As EventArgs) Handles Me.Load
        tbScrapReport.SelectedIndex = 0
    End Sub
    Private Function FetchAllRecords(ByVal sReportType As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", CStr(sReportType), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ExtraScrap_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

        Return dtData
    End Function
    Private Sub tbScrapReport_Click(sender As Object, e As EventArgs) Handles tbScrapReport.Click
        If tbScrapReport.SelectedIndex = 0 Then     ''for 
            dgvAll.DataSource = Nothing
            dgvAll.DataSource = FetchAllRecords("FetchData")
        ElseIf tbScrapReport.SelectedIndex = 1 Then ''for 
            dgvAgainstSpecificLot.DataSource = Nothing
            dgvAgainstSpecificLot.DataSource = FetchAllRecords("fetchAgainstSpecificLots")
        ElseIf tbScrapReport.SelectedIndex = 2 Then ''for 
            dgvAgainstSpecificOpMLot.DataSource = Nothing
            dgvAgainstSpecificOpMLot.DataSource = FetchAllRecords("fetchAgainstSpecificOpMLot")
        ElseIf tbScrapReport.SelectedIndex = 3 Then ''for 
            dgvAgainstMOp.DataSource = Nothing
            dgvAgainstMOp.DataSource = FetchAllRecords("fetchAgainstMOp")
        End If
    End Sub
    Private Sub tbScrapReport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbScrapReport.SelectedIndexChanged
        If tbScrapReport.SelectedIndex = 0 Then     ''for 
            dgvAll.DataSource = Nothing
            dgvAll.DataSource = FetchAllRecords("FetchData")
        ElseIf tbScrapReport.SelectedIndex = 1 Then ''for 
            dgvAgainstSpecificLot.DataSource = Nothing
            dgvAgainstSpecificLot.DataSource = FetchAllRecords("fetchAgainstSpecificLots")
        ElseIf tbScrapReport.SelectedIndex = 2 Then ''for 
            dgvAgainstSpecificOpMLot.DataSource = Nothing
            dgvAgainstSpecificOpMLot.DataSource = FetchAllRecords("fetchAgainstSpecificOpMLot")
        ElseIf tbScrapReport.SelectedIndex = 3 Then ''for 
            dgvAgainstMOp.DataSource = Nothing
            dgvAgainstMOp.DataSource = FetchAllRecords("fetchAgainstMOp")
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If tbScrapReport.SelectedIndex = 0 Then
            Try
                If dgvAll.RowCount > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.dgvAll.PrintPreview()
                Else
                    MessageBox.Show("No Data to Print")
                End If
            Catch ex As Exception

            Finally
                Me.Cursor = Cursors.Default
            End Try
        ElseIf tbScrapReport.SelectedIndex = 1 Then
            Try
                If dgvAgainstSpecificLot.RowCount > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.dgvAgainstSpecificLot.PrintPreview()
                Else
                    MessageBox.Show("No Data to Print")
                End If
            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        ElseIf tbScrapReport.SelectedIndex = 2 Then
            Try
                If dgvAgainstSpecificOpMLot.RowCount > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.dgvAgainstSpecificOpMLot.PrintPreview()
                Else
                    MessageBox.Show("No Data to Print")
                End If
            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        Else
            Try
                If dgvAgainstMOp.RowCount > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.dgvAgainstMOp.PrintPreview()
                Else
                    MessageBox.Show("No Data to Print")
                End If
            Catch ex As Exception
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub frmScrapReceiveReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
End Class