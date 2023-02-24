Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports System.Windows
Public Class frmLogin
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles UsernameTextBox.Click, btnLogin.Click
        Dim dtData As DataTable = New DataTable()

        'Me.CheckVersion()

        If Not Validate_Fields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetLogin", DbType.String))
                .Add(dbManager.CreateParameter("@Uname", UsernameTextBox.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@UPass", PasswordTextBox.Text.Trim(), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UserMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                Me.Hide()

                Dim ObjMain As New frmMain()
                ObjMain.UserName.Text = dtData.Rows(0).Item("UserName").ToString()
                UserName = dtData.Rows(0).Item("UserName").ToString()
                UserId = dtData.Rows(0).Item("UserId").ToString()
                KarigarName = dtData.Rows(0).Item("LabourName").ToString()
                DeptId = dtData.Rows(0).Item("DeptId").ToString()
                UserType = dtData.Rows(0).Item("UserType").ToString()
                ObjMain.Show()

                'Getting UserRights In DataTable
                dtUserRights = FetchAllRecords(UserId)
            Else
                MessageBox.Show("Login Failed...Try again !", "Login Denied", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                UsernameTextBox.Clear()
                PasswordTextBox.Clear()
                UsernameTextBox.Focus()
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub
    Private Sub UsernameTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles UsernameTextBox.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            PasswordTextBox.Focus()
        End If
    End Sub
    Private Sub PasswordTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles PasswordTextBox.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            btnLogin.Focus()
        End If
    End Sub
    Private Sub frmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.Alt = True And e.KeyCode = System.Windows.Forms.Keys.L Then       'for Login
                Call btnLogin_Click(sender, e)
            ElseIf (e.Alt = True And e.KeyCode = System.Windows.Forms.Keys.X) Or (e.KeyCode = System.Windows.Forms.Keys.Escape) Then   'for Exit
                End
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            End
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_Form()
        Try
            UsernameTextBox.Clear()
            PasswordTextBox.Clear()

            UsernameTextBox.Focus()
            UsernameTextBox.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If String.IsNullOrWhiteSpace(PasswordTextBox.Text()) Then
                MessageBox.Show("Enter User Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                PasswordTextBox.Focus()
                Return False
            ElseIf String.IsNullOrWhiteSpace(PasswordTextBox.Text.Trim()) = True Then
                MessageBox.Show("Enter password !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                PasswordTextBox.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function FetchAllRecords(ByVal iUserId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            parameters.Add(dbManager.CreateParameter("@UId", CInt(iUserId), DbType.Int16))
            parameters.Add(dbManager.CreateParameter("@ActionType", "FetchUserRights", DbType.String))

            dtData = dbManager.GetDataTable("SP_UserRights_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Sub CheckVersion()
        Try
            Dim dtData As DataTable

            dtData = FetchAllRecords()

            If dtData.Rows.Count > 0 Then
                If Now.Date > DateTime.Parse("11.03.2022 00:00") Then
                    dbManager.Update("UPDATE tblVersion SET Version_No='1.0.0000'", CommandType.Text)
                    GoTo LINE1
                End If
            End If

            If dtData.Rows(0).Item("Version_No") <> "1.0.0001" Then
LINE1:
                MsgBox(" Version Expired Please Contact Chain Experts ON +91 9821210759", MsgBoxStyle.Critical)
                End
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function FetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Version_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class
