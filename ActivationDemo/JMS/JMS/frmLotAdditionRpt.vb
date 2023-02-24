Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmLotAdditionRpt
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim strSQL As String = Nothing
    Private Sub frmLotAdditionRpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLotNo()
    End Sub
    Private Sub frmLotAdditionRpt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillLotNo()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))

        Dim dr = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Try

            cmbLotNo.DataSource = Nothing
            cmbLotNo.Items.Clear()

            While dr.Read
                cmbLotNo.Items.Add(dr(0).ToString())
            End While

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged

        If Not (String.IsNullOrEmpty(cmbLotNo.Text)) Or (cmbLotNo.SelectedIndex = -1) Then
            bindReceiveDetails()

            If dgvReceive.RowCount > 0 Then
                GridReceiveTotal()
            End If

            bindIssueDetails()

            If dgvIssue.RowCount > 0 Then
                GridIssueTotal()
            End If
        End If

    End Sub
    Private Sub bindIssueDetails()
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            parameters.Add(dbManager.CreateParameter("@ActionType", "FetchIssueData", DbType.String))
            parameters.Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim(), DbType.String))

            dtData = dbManager.GetDataTable("SP_LotAdditionFinal_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                dgvIssue.DataSource = dtData
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Function bindReceiveDetails() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            parameters.Add(dbManager.CreateParameter("@ActionType", "FetchReceiveData", DbType.String))
            parameters.Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim(), DbType.String))

            dtData = dbManager.GetDataTable("SP_LotAdditionFinal_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                dgvReceive.DataSource = dtData
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub GridIssueTotal()
        Try
            Dim dSumOfTotalIssuePr As Double = 0
            Dim dSumOfTotalIssueWt As Double = 0
            Dim dSumOfTotalFineWt As Double = 0

            For Each row As GridViewRowInfo In dgvIssue.Rows
                dSumOfTotalIssueWt += Convert.ToDecimal(row.Cells(3).Value)
                dSumOfTotalIssuePr += Convert.ToDecimal(row.Cells(4).Value)
                dSumOfTotalFineWt += Convert.ToDecimal(row.Cells(5).Value)
            Next

            If dgvIssue.RowCount > 0 Then
                lblGridIWt.Text = Format(dSumOfTotalIssueWt, "0.00")
                lblGridIFine.Text = Format(dSumOfTotalFineWt, "0.00")
                lblGridIPr.Text = Format(Val(lblGridIFine.Text) / Val(lblGridIWt.Text) * 100, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GridReceiveTotal()
        Try
            Dim dSumOfTotalReceivePr As Double = 0
            Dim dSumOfTotalReceiveWt As Double = 0
            Dim dSumOfTotalFineWt As Double = 0

            For Each row As GridViewRowInfo In dgvReceive.Rows
                dSumOfTotalReceiveWt += Convert.ToDecimal(row.Cells(3).Value)
                dSumOfTotalReceivePr += Convert.ToDecimal(row.Cells(4).Value)
                dSumOfTotalFineWt += Convert.ToDecimal(row.Cells(5).Value)
            Next

            If dgvReceive.RowCount > 0 Then
                lblGridRWt.Text = Format(dSumOfTotalReceiveWt, "0.00")
                lblGridRFine.Text = Format(dSumOfTotalFineWt, "0.00")
                lblGridRPr.Text = Format(Val(lblGridRFine.Text) / Val(lblGridRWt.Text) * 100, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class