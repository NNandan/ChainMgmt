Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmCStockLogin
    Dim strSQL As String = Nothing
    Dim iRowCnt As Integer = 0
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub BtnStockLogin_Click(sender As Object, e As EventArgs) Handles BtnStockLogin.Click
        Dim dtData As DataTable = New DataTable()
        Dim objDt As DataTable = New DataTable

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetStockLogin", DbType.String))
                .Add(dbManager.CreateParameter("@Uname", txtUsername.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@StkPass", txtPassword.Text.Trim(), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UserMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                Me.Hide()
                Dim ObjScrapBagNotUpdate As New frmCDailyStockDetails
                ObjScrapBagNotUpdate.ShowDialog()
            Else
                MessageBox.Show("Incorrect Password...!")
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
End Class