Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmCompanyDetails
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim strSQL As String = Nothing
    Dim GridDoubleClick As Boolean
    Private Sub DgvCompany_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs)
        Try
            OpenCompany()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub OpenCompany()
        Try
            'CmpName = gridcmp.SelectedCells(0).Value
            'CmpId = gridcmp.SelectedRows(0).Cells(1).Value
            frmYearDetails.Show()
            Me.Close()

            'GET USEREMPNAME FROM USEREMPTAG
            'Dim OBJCMN As New ClsCommon
            'Dim DT As DataTable = OBJCMN.search("ISNULL(EMP_NAME,'') AS EMPNAME", "", " USEREMPTAG INNER JOIN EMPLOYEEMASTER ON EMP_ID = USER_EMPID", " AND USER_ID = " & UserId & " AND USER_CMPID = " & CmpId)
            'If DT.Rows.Count > 0 Then
            '    USEREMPNAME = DT.Rows(0).Item("EMPNAME")
            'Else
            '    USEREMPNAME = ""
            'End If
            'Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Try
            If dgvCompany.RowCount > 0 Then
                Me.OpenCompany()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmCompanyDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillCompany()
    End Sub
    Private Sub fillCompany()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            parameters.Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            dt = dbManager.GetDataTable("SP_CompanyMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            DgvCompany.DataSource = Nothing


            If dt.Rows.Count > 0 Then
                DgvCompany.DataSource = dt
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        'Try
        '    Dim obj As New CompanyMaster
        '    obj.Show()
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try
            'CompanyMaster.edit = True
            'CompanyMaster.TEMPCMPNAME = gridcmp.CurrentRow.Cells(0).Value
            'CompanyMaster.ShowDialog()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnBackup_Click(sender As Object, e As EventArgs) Handles btnBackup.Click
        'Try
        '    'TAKE(backup)
        '    Dim TEMPMSG As Integer = MsgBox("Create Backup?", MsgBoxStyle.YesNo)
        '    If TEMPMSG = vbYes Then

        '        'CHECKING FOR BACKUP FOLDER
        '        If FileIO.FileSystem.DirectoryExists("C:\JEWELPRO BACKUP") = False Then FileIO.FileSystem.CreateDirectory("C:\JEWELPRO BACKUP")

        '        'IF SAME DATE'S BACKUP EXIST THEN DELETE IT THEN RECREATE IT
        '        If FileIO.FileSystem.FileExists("C:\JEWELPRO BACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak") Then FileIO.FileSystem.DeleteFile("C:\JEWELPRO BACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak")

        '        Dim OBJCMN As New ClsCommon
        '        Dim DT As DataTable = OBJCMN.Execute_Any_String(" backup database jewelpro to disk='C:\JEWELPRO BACKUP\BACKUP " & Now.Day & "-" & Now.Month & "-" & Now.Year & ".bak'", "", "")
        '        MsgBox("Backup Completed")
        '    End If

        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
    Private Sub dgvCompany_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvCompany.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If dgvCompany.SelectedRows.Count > 0 Then
                    Call btnOpen_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class