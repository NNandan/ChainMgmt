Imports DataAccessHandler
Imports System.Data.SqlClient

Public Class frmBackup
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub fillServer()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchServerName", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_GetServerInfo_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            CmbServer.DataSource = Nothing
            CmbServer.Items.Clear()

            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            CmbServer.DataSource = dt
            CmbServer.DisplayMember = "SvrName"
            CmbServer.ValueMember = "srvid"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Sub fillDatbase()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchDBName", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_GetServerInfo_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            CmbDatabase.DataSource = Nothing
            CmbDatabase.Items.Clear()

            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            CmbDatabase.DataSource = dt
            CmbDatabase.DisplayMember = "SvrName"
            CmbDatabase.ValueMember = "dbid"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try

    End Sub
    Private Sub cmbserver_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbServer.SelectedIndexChanged
        fillDatbase()
    End Sub
    Sub query(ByVal que As String)
        On Error Resume Next
        'Objcmd = New SqlCommand(que, Objcn)
        'Objcmd.ExecuteNonQuery()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = 100 Then
            Timer1.Enabled = False
            ProgressBar1.Visible = False
            MsgBox("Successfully Done")
        Else
            ProgressBar1.Value = ProgressBar1.Value + 5
        End If
    End Sub
    Sub Blank(ByVal str As String)
        If CmbServer.Text = "" Or CmbDatabase.Text = "" Then
            MsgBox("Server Name & Database Blank Field")
            Exit Sub
        Else
            If str = "Backup" Then
                SaveFileDialog1.FileName = CmbDatabase.Text
                SaveFileDialog1.ShowDialog()
                Timer1.Enabled = True
                ProgressBar1.Visible = True
                Dim s As String
                s = SaveFileDialog1.FileName
                query("BACKUP DATABASE " & CmbDatabase.Text.Trim() & " TO DISK='" & s & "'")
            ElseIf str = "Restore" Then
                OpenFileDialog1.ShowDialog()
                Timer1.Enabled = True
                ProgressBar1.Visible = True
                query("RESTORE DATABASE " & CmbDatabase.Text.Trim() & " FROM DISK='" & OpenFileDialog1.FileName & "'")
            End If
        End If
    End Sub
    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        Blank("Backup")
    End Sub
    Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
        Blank("Restore")
    End Sub
    Private Sub frmBakcup_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillServer()
        Me.fillDatbase()
    End Sub
End Class
