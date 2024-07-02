Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmYearDetails
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim strSQL As String = Nothing
    Dim GridDoubleClick As Boolean
    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Try
            frmCompanyDetails.Show()
            Me.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            Dim TEMPMSG As Integer
            TEMPMSG = MsgBox("Delete Accounting Year and all its Data?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub

            TEMPMSG = MsgBox("Are you sure Delete Accounting Year and all its Data?", MsgBoxStyle.YesNo)
            If TEMPMSG = vbNo Then Exit Sub

            Dim ALPARAVAL As New ArrayList
            'Dim OBJCMP As New ClsYearMaster

            'ALPARAVAL.Add(gridcmp.SelectedRows(0).Cells(3).Value)
            'OBJCMP.alParaval = ALPARAVAL
            'Dim INTRES As Integer = OBJCMP.YEARDELETE
            MsgBox("Accounting Year Deleted Successfully")
            fillYear()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Try
            If dgvYear.RowCount > 0 Then
                Dim ObjMain As New frmMain()
                ObjMain.UserName.Text = UserName
                ObjMain.UserType.Text = UserType
                ObjMain.Show()
                ObjMain.Refresh()
                Me.Close()

                'Getting UserRights In DataTable
                dtUserRights = FetchAllRecords(UserId)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Try
            Dim obj As New frmYearMaster
            obj.cmdback.Visible = False
            'obj.EDIT = False
            'obj.FRMSTRING = "ADDYEAR"
            obj.Show()
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Sub fillYear()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_YearMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            dgvYear.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                dgvYear.DataSource = dt
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub frmYearDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            'If UserType <> "SUPER" Then
            '    cmddelete.Enabled = False
            '    cmdcreate.Enabled = False
            'End If
            fillYear()
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Private Function FetchAllRecords(ByVal iUserId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@UId", CInt(iUserId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchUserRights", DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_UserRights_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub dgvYear_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvYear.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then
                If dgvYear.SelectedRows.Count > 0 Then
                    Call btnOpen_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class