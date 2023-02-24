Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI

Public Class frmEditLBags
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

    Private Sub frmEditLBags_Load(sender As Object, e As EventArgs) Handles Me.Load
        TransDt.Focus()
        TransDt.Value = DateTime.Now
    End Sub

End Class