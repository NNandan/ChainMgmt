Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmEditBags
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub frmEditBags_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If rbBhuka.Checked = True Then
            Me.fillBhukaBagType()
        ElseIf rbLotFail.Checked = True Then
            cmbBagtype.Enabled = False

        ElseIf rbLotFail.Checked = True Then

        ElseIf rbVacuum.Checked = True Then

        Else

        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If String.IsNullOrWhiteSpace(cmbBagtype.Text.Trim()) Or Convert.ToInt32(cmbBagtype.SelectedIndex) = -1 Then
            MessageBox.Show("Select Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbBagtype.Focus()
        ElseIf String.IsNullOrWhiteSpace(cmbBagNo.Text.Trim()) Then
            MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbBagNo.Focus()
        Else
            Try

                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                If btnSave.Text = "Save" Then

                    With parameters
                        .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))

                        .Add(dbManager.CreateParameter("@UBagDt", TransDt.Value.ToString(), DbType.DateTime))
                        .Add(dbManager.CreateParameter("@UItemId", Val(cmbBagtype.SelectedValue), DbType.Int16))
                        .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbBagNo.SelectedItem), DbType.String))

                        .Add(dbManager.CreateParameter("@UIssueWt", Val(txtIssueWt.Text.Trim), DbType.String))
                        .Add(dbManager.CreateParameter("@UIssuePr", Val(txtIssuePr.Text.Trim), DbType.String))

                        .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtWtOnScale.Text.Trim), DbType.String))
                        .Add(dbManager.CreateParameter("@URecieveWt", Val(txtReceiveWt.Text.Trim), DbType.String))

                        .Add(dbManager.CreateParameter("@UReportPr", Val(txtReceivePr.Text.Trim), DbType.String))
                        .Add(dbManager.CreateParameter("@UTFSample", Val(txtWtOnScale.Text.Trim), DbType.String))
                        .Add(dbManager.CreateParameter("@UCarbonRecieve", Val(txtCarbon.Text.Trim), DbType.String))
                    End With

                    dbManager.Insert("SP_UsedBags_Save", CommandType.StoredProcedure, parameters.ToArray())

                End If

                MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        End If

    End Sub
    Private Sub cmbBagNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbBagNo.SelectedIndexChanged
        If cmbBagNo.SelectedIndex >= 0 Then
            Me.fetchBagData()
        End If
    End Sub
    Private Sub Clear_Form()
        Try
            cmbBagtype.SelectedIndex = 0
            cmbBagNo.SelectedIndex = 0

            txtReceivePr.Clear()
            txtReceiveWt.Clear()
            txtWtOnScale.Clear()
            txtCarbon.Clear()
            txtSample.Clear()

            txtIssuePr.Clear()
            txtIssueWt.Clear()
            txtIssueFineWt.Clear()
            txtReceiveFineWt.Clear()
            txtGrossLoss.Clear()
            txtLossFine.Clear()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbBagtype.SelectedIndexChanged
        Me.fillReceiveBhukaSrNo()
    End Sub
    Private Sub fetchBagData()

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbBagNo.SelectedItem.Text), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtTransId.Text = dtData.Rows(0).Item("UsedBagId").ToString()
                TransDt.Text = dtData.Rows(0).Item("UsedBagDt").ToString()

                txtReceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
                txtReceiveWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()

                txtSample.Text = dtData.Rows(0).Item("TFSampleWt").ToString()
                txtWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtCarbon.Text = dtData.Rows(0).Item("CarbonReceive").ToString()

                txtIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()

                txtIssueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()
                'txtReceiveFineWt.Text = dtData.Rows(0).Item("RecieveFineWt").ToString()
            Else
                MessageBox.Show("No Data Found !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub cmbBagtype_Enter(sender As Object, e As EventArgs) Handles cmbBagtype.Enter
        cmbBagtype.ShowDropDown()
    End Sub
    Private Sub cmbBagNo_Enter(sender As Object, e As EventArgs) Handles cmbBagNo.Enter
        cmbBagNo.ShowDropDown()
    End Sub
    Private Sub rbLotFail_Click(sender As Object, e As EventArgs) Handles rbLotFail.Click
        If rbLotFail.Checked = True Then
            cmbBagtype.Enabled = True
            Me.fillLotFailBagType()
            ''Me.fillLotFailBagNo()
        End If
    End Sub
    Private Sub rbBhuka_Click(sender As Object, e As EventArgs) Handles rbBhuka.Click
        If rbBhuka.Checked = True Then
            cmbBagtype.Enabled = True
            Me.fillBhukaBagType()
        End If
    End Sub
    Private Sub ReceivelistViewTotal()
        Dim dSumOfGrossWt As Decimal = 0
        Dim dSumOfReceivePr As Decimal = 0
        Dim dSumOfFineWt As Decimal = 0

        Try
            'For Each row As GridViewRowInfo In dgvReceiveBhuka.Rows
            '    dSumOfGrossWt += CDec(Val(row.Cells(3).Value))
            '    dSumOfFineWt += CDec(Val(row.Cells(5).Value))
            'Next

            dSumOfReceivePr = (dSumOfFineWt / dSumOfGrossWt) * 100

            txtIssueWt.Text = dSumOfGrossWt.ToString("N2")
            txtIssuePr.Text = dSumOfReceivePr.ToString("N2")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillBhukaBagType()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillBhukaBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        If tbBhukaBag.SelectedIndex = 0 Then

            Try
                cmbBagtype.DataSource = Nothing
                cmbBagtype.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbBagtype.DataSource = dt
                cmbBagtype.DisplayMember = "ItemName"
                cmbBagtype.ValueMember = "ItemId"
                cmbBagtype.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Sub fillLotFailBagType()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillLotFailBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        If tbBhukaBag.SelectedIndex = 0 Then

            Try
                cmbBagtype.DataSource = Nothing
                cmbBagtype.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbBagtype.DataSource = dt
                cmbBagtype.DisplayMember = "ItemName"
                cmbBagtype.ValueMember = "ItemId"
                cmbBagtype.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Sub FillVacuumBagType()

        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            parameters.Add(dbManager.CreateParameter("@ActionType", "FillVacuumBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        dt.Load(dr)

        Try
            cmbBagtype.DataSource = Nothing
            cmbBagtype.Items.Clear()

            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbBagtype.DataSource = dt
            cmbBagtype.DisplayMember = "ItemName"
            cmbBagtype.ValueMember = "ItemId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillSampleBagType()

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
            cmbBagtype.DataSource = Nothing
            cmbBagtype.Items.Clear()

            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbBagtype.DataSource = dt
            cmbBagtype.DisplayMember = "ItemName"
            cmbBagtype.ValueMember = "ItemId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try

    End Sub
    Private Sub fillReceiveBhukaSrNo()

        If cmbBagtype.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagId", DbType.String))
                .Add(dbManager.CreateParameter("@BId", Val(cmbBagtype.SelectedValue), DbType.Int16))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_UsedBags_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

            cmbBagNo.Items.Clear()
            cmbBagNo.ResetText()

            Try
                While dr.Read
                    If Not IsDBNull(dr.Item("BagSrNo")) Then
                        cmbBagNo.Items.Add(dr.Item("BagSrNo"))
                    End If
                End While

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                Objcn.Close()
            End Try
        End If
    End Sub
    Private Sub fillReceiveLotFailSrNo()

        If cmbBagtype.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetReceiveBhukaSrNo", DbType.String))
                .Add(dbManager.CreateParameter("@BId", Val(cmbBagtype.SelectedValue), DbType.Int16))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

            cmbBagNo.Items.Clear()
            cmbBagNo.ResetText()

            Try
                While dr.Read
                    If Not IsDBNull(dr.Item("BhukaBagNo")) Then
                        cmbBagNo.Items.Add(dr.Item("BhukaBagNo"))
                    End If
                End While

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                Objcn.Close()
            End Try
        End If
    End Sub
    Private Sub rbVacuum_Click(sender As Object, e As EventArgs) Handles rbVacuum.Click
        If rbVacuum.Checked = True Then
            cmbBagtype.Enabled = True
            Me.FillVacuumBagType()
        End If
    End Sub
    Private Sub rbSample_Click(sender As Object, e As EventArgs) Handles rbSample.Click
        If rbSample.Checked = True Then
            cmbBagtype.Enabled = True
            Me.fillSampleBagType()
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub fillReceiveVacuumSrNo()

        If cmbBagtype.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetReceiveBhukaSrNo", DbType.String))
                .Add(dbManager.CreateParameter("@BId", Val(cmbBagtype.SelectedValue), DbType.Int16))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

            cmbBagNo.Items.Clear()
            cmbBagNo.ResetText()

            Try
                While dr.Read
                    If Not IsDBNull(dr.Item("BhukaBagNo")) Then
                        cmbBagNo.Items.Add(dr.Item("BhukaBagNo"))
                    End If
                End While

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                Objcn.Close()
            End Try
        End If
    End Sub
    Private Sub fillReceiveSampleSrNo()

        If cmbBagtype.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetReceiveBhukaSrNo", DbType.String))
                .Add(dbManager.CreateParameter("@BId", Val(cmbBagtype.SelectedValue), DbType.Int16))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

            cmbBagNo.Items.Clear()
            cmbBagNo.ResetText()

            Try
                While dr.Read
                    If Not IsDBNull(dr.Item("BhukaBagNo")) Then
                        cmbBagNo.Items.Add(dr.Item("BhukaBagNo"))
                    End If
                End While

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                Objcn.Close()
            End Try
        End If
    End Sub
    Private Sub fillLotFailBagNo()
        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim dr As DataRow

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotFailBag", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_LotFail_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No LotFail Bags Avilable !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        dr = dt.NewRow()

        Try

            cmbBagNo.DataSource = Nothing
            cmbBagNo.Items.Clear()

            'Insert the Default Item to DataTable.
            'Dim row As DataRow = dt.NewRow()
            'row(0) = 0
            'row(1) = "---Select---"
            'dt.Rows.InsertAt(row, 0)

            dr.ItemArray = New Object() {0, "---Select---"}
            dt.Rows.InsertAt(dr, 0)

            'Assign DataTable as DataSource.
            cmbBagNo.DisplayMember = "LotFailBagNo"
            cmbBagNo.ValueMember = "LotFailId"
            cmbBagNo.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
End Class