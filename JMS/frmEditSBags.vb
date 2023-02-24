Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmEditSBags
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())

    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Sub rbLabNotSent_CheckedChanged(sender As Object, e As EventArgs) Handles rbLabNotSent.CheckedChanged
        Me.bindLabNotSendData()
    End Sub
    Private Sub rbLabSent_CheckedChanged(sender As Object, e As EventArgs) Handles rbLabSent.CheckedChanged
        Me.bindLabSendData()
    End Sub
    Private Sub frmEditSBags_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.fillBagType()
        Me.bindSampleDataGridView()
    End Sub
    Private Sub fillBagType()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillSampleBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            cmbEBagtype.DataSource = Nothing
            cmbEBagtype.Items.Clear()

            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbEBagtype.DataSource = dt
            cmbEBagtype.DisplayMember = "ItemName"
            cmbEBagtype.ValueMember = "ItemId"
            cmbEBagtype.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bindSampleDataGridView()

        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetNonTestedAllSampleData", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                dgvSampleBag.DataSource = dt
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub bindLabNotSendData()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetNotSentSampleBag", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                dgvSampleBag.DataSource = dt
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub bindLabSendData()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetSentSampleBag", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                dgvSampleBag.DataSource = dt
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub

    Private Sub Clear_Form()
        Try

            '' For Header Field Start

            cmbEBagtype.SelectedIndex = 0
            cmbRBagNo.SelectedIndex = -1
            '' For Header Field End

            '' For Detail Field Start

            dgvSampleBag.DataSource = Nothing

            '' For Detail Field End

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class