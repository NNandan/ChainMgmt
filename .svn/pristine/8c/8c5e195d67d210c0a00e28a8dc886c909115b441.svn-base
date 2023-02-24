Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmMeltingStockRpt
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())

    Private Sub frmMeltingStockRpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvMeltingStock.AutoGenerateColumns = False
        dgvMeltingStock.DataSource = FetchAllRecords()
        dgvMeltingStock.EnableFiltering = True
        dgvMeltingStock.MasterTemplate.ShowHeaderCellButtons = True
        dgvMeltingStock.MasterTemplate.ShowFilteringRow = False
        dgvMeltingStock.CurrentRow = Nothing
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "MeltingStock", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockReport_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function

    Private Sub frmMeltingStockRpt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
End Class