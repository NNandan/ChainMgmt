Imports System.IO
Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmFaAccountClosing
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Dim strSQL As String = Nothing

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub frmAccountClosing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If dtUserRights.Rows.Count > 0 Then
            Dim DtRow() As DataRow = dtUserRights.Select("FormName = 'ACCOUNT MASTER'")
            USERADD = DtRow(0).Item(3)
            USEREDIT = DtRow(0).Item(4)
            USERVIEW = DtRow(0).Item(5)
            USERDELETE = DtRow(0).Item(6)
            DeptId = DtRow(0).Item(7)

            If USEREDIT = False And USERDELETE = False Then
                MsgBox("Insufficient Rights")
            End If

        End If

        txtClosedBy.Tag = CInt(UserId)
        txtClosedBy.Text = Convert.ToString(KarigarName.Trim)
        txtClosedDt.Text = DateTime.Now.ToString("dd/MM/yyyy")
        txtToDt.Text = DateTime.Now.ToString("dd/MM/yyyy")

        Me.fillClosedDtPeriodNo()
    End Sub
    Private Sub btnClosedAcc_Click(sender As Object, e As EventArgs) Handles btnClosedAcc.Click
        If txtRemark.Text.Trim = "" Then
            MessageBox.Show("Remark Is Compulsary !!!", "Give Valid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtRemark.Focus()
        Else
            If (MsgBox("Are You Sure To Close This Account ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
                        .Add(dbManager.CreateParameter("@DPeriodNo", txtPeriodNo.Text.Trim, DbType.String))
                    End With

                    dbManager.Insert("SP_PeriodDetails_Save", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data In Table DetailsPeriod Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try

                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
                        .Add(dbManager.CreateParameter("@DClosedBy", txtClosedBy.Text.Trim.Trim(), DbType.String))
                        .Add(dbManager.CreateParameter("@DRemark", txtRemark.Text.Trim(), DbType.String))
                    End With

                    dbManager.Insert("SP_ClosedDtPeriod_Save", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Account Has Been Closed !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try

                Me.ExportXmlFile()

                MessageBox.Show("Data Exported Successfully !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Close This Account Only When You Sure !!!")
            End If
        End If
    End Sub
    Protected Sub ExportXmlFile()
        Dim dsRW As New DataSet

        ''Check if folder Exist
        Dim strPath As String = "D:\ExportedData"

        If Not Directory.Exists(strPath) Then
            Directory.CreateDirectory(strPath)
        End If

        Dim strFileName As String = Path.Combine(strPath, DateTime.Now.ToString("ddMMyyyy") & "_" & txtPeriodNo.Text.Trim & ".xml")

        If Not File.Exists(strFileName) Then
            Dim f As FileStream = File.Create(strFileName)
            f.Close()
        End If

        Dim ObjDs As DataSet = FetchAllDetails()

        If ObjDs.Tables.Count > 0 Then
            If ObjDs.Tables(0).Rows.Count > 0 Then

                dsRW.Tables.Add()
                dsRW.Tables(0).TableName = ObjDs.Tables(0).TableName
                For j As Integer = 0 To ObjDs.Tables(0).Columns.Count - 1
                    Dim dc As New DataColumn
                    dc.ColumnName = fnEnCryptDeCrypt(ObjDs.Tables(0).Columns(j).ColumnName)
                    dc.DataType = "String".GetType()
                    dsRW.Tables(0).Columns.Add(dc)
                Next

                'Now Encrypt all the Original Value and put it in New dataset which keeps all the encrypted data.
                For i As Integer = 0 To ObjDs.Tables(0).Rows.Count - 1
                    dsRW.Tables(0).Rows.Add()
                    For j As Integer = 0 To ObjDs.Tables(0).Columns.Count - 1
                        dsRW.Tables(0).Rows(i).Item(j) = fnEnCryptDeCrypt(ObjDs.Tables(0).Rows(i).Item(j))
                    Next
                Next
            End If
        End If

        'Write the Encrypted Dataset in XML
        dsRW.WriteXml(strFileName)

        'To Check the Output (Encrypted Value) at the RunTime
        Process.Start(strFileName)
    End Sub
    Private Sub fillClosedDtPeriodNo()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_ClosedDtPeriod_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())
            dr.Read()

            txtFromDt.Text = dr.Item("ClosedDt").ToString()
            txtPeriodNo.Text = dr.Item("PERIODNo").ToString()

            lblFancy.Text = dr.Item("SWName").ToString()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Objcn.Close()
        End Try
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Clear_Form()
    End Sub
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
    Private Function FetchAllDetails() As DataSet
        Dim dsData As DataSet = New DataSet()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@PeriodNo", txtPeriodNo.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dsData = dbManager.GetDataSet("SP_PeriodDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dsData

    End Function
    Private Sub Clear_Form()
        Try
            txtRemark.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub DeletePeriodDetails()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            dbManager.Delete("SP_TmpPeriodDetails_Delete", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Deleted !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub

End Class