Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmStockLotAddition
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Sub frmStockLotAddition_Load(sender As Object, e As EventArgs) Handles Me.Load
        dgvWipLotNo.AutoGenerateColumns = False
        dgvWipLotNo.DataSource = FetchAllRecords()
        dgvWipLotNo.EnableFiltering = True
        dgvWipLotNo.MasterTemplate.ShowHeaderCellButtons = True
        dgvWipLotNo.MasterTemplate.ShowFilteringRow = False
        dgvWipLotNo.CurrentRow = Nothing

        Me.CalculateTotal()
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            parameters.Add(dbManager.CreateParameter("@ActionType", "LotAdditionStockDetails", DbType.String))
            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub CalculateTotal()
        Dim sReceiveWTotal As Single = 0
        Dim sReceivePTotal As Single = 0
        Dim sReceiveFTotal As Single = 0

        For Each row As GridViewRowInfo In dgvWipLotNo.Rows
            sReceiveWTotal += Single.Parse(row.Cells(4).Value)
            sReceiveFTotal += Single.Parse(row.Cells(6).Value)
        Next

        sReceivePTotal = Format((Val(sReceiveFTotal) / Val(sReceiveWTotal)) * 100, "0.00")

        lblReceiveWt.Text = Format(sReceiveWTotal, "0.00")
        lblReceivePr.Text = Format(sReceivePTotal, "0.00")
        lblReceiveFw.Text = Format(sReceiveFTotal, "0.00")
    End Sub
    Private Sub frmStockLotAddition_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
End Class