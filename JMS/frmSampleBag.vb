Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmSampleBag
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState
    Dim strSQL As String = Nothing

    Dim dbManager As New SqlHelper()
    Private Property Fr_Mode() As FormState
        Get
            Return mFr_State
        End Get
        Set(ByVal value As FormState)
            mFr_State = value
            Select Case mFr_State
                Case FormState.AStateMode
                    '    Me.Lbl_Tran_Mode.Text = "NEW MODE"
                    '    Me.txtAccountName.BackColor = Color.LemonChiffon
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "&Save"
                Case FormState.EStateMode
                    'Me.Lbl_Tran_Mode.Text = "EDIT MODE"
                    'Me.txtAccountName.BackColor = Color.LemonChiffon
                    Me.btnSave.Text = "&Update"
            End Select
        End Set
    End Property
    Private Sub frmSampleBag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        rbLotSample.Checked = True
        rbLabNotSent.Checked = True

        Me.fillBagType()
    End Sub
    Private Sub CalculateSampleWt()
        Dim sSampleTotal As Single = 0
        Dim sFineTotal As Single = 0

        'For i As Integer = 0 To lstSampleBag.Items.Count - 1
        '    If (lstSampleBag.Items(i).Checked And Not String.IsNullOrEmpty(lstSampleBag.Items(i).SubItems(3).Text)) Then
        '        sSampleTotal += Single.Parse(lstSampleBag.Items(i).SubItems(3).Text.Trim())
        '    End If

        '    If (lstSampleBag.Items(i).Checked And Not String.IsNullOrEmpty(lstSampleBag.Items(i).SubItems(5).Text)) Then
        '        sFineTotal += Single.Parse(lstSampleBag.Items(i).SubItems(5).Text.Trim())
        '    End If
        'Next

        'txtSampleTotal.Text = Format(sSampleTotal, "0.00")
        'txtFineTotal.Text = Format(sFineTotal, "0.00")
    End Sub
    Private Sub fillBagType()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillSampleBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        If tbSampleBag.SelectedIndex = 0 And dt.Rows.Count > 0 Then

            Try
                cmbCBagtype.DataSource = Nothing
                cmbCBagtype.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbCBagtype.DataSource = dt
                cmbCBagtype.DisplayMember = "ItemName"
                cmbCBagtype.ValueMember = "ItemId"
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try

        ElseIf tbSampleBag.SelectedIndex = 1 Then
            Try
                cmbRBagtype.DataSource = Nothing
                cmbRBagtype.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbRBagtype.DataSource = dt
                cmbRBagtype.DisplayMember = "ItemName"
                cmbRBagtype.ValueMember = "ItemId"
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        Else
            Try
                cmbUBagtype.DataSource = Nothing
                cmbUBagtype.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbUBagtype.DataSource = dt
                cmbUBagtype.DisplayMember = "ItemName"
                cmbUBagtype.ValueMember = "ItemId"
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Sub fillReceiveVacuumSrNo()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetReceiveVaccumeSrNo", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        If dr.HasRows = False Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        If tbSampleBag.SelectedIndex = 1 Then
            cmbRBagNo.Items.Clear()
            cmbRBagNo.ResetText()

            Try
                While dr.Read
                    If Not IsDBNull(dr.Item("VaccumeBagNo")) Then
                        cmbRBagNo.Items.Add(dr.Item("VaccumeBagNo"))
                    End If
                End While

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try

        ElseIf tbSampleBag.SelectedIndex = 2 Then

            cmbUBagNo.Items.Clear()
            cmbUBagNo.ResetText()

            Try
                While dr.Read
                    If Not IsDBNull(dr.Item("VaccumeBagNo")) Then
                        cmbUBagNo.Items.Add(dr.Item("VaccumeBagNo"))
                    End If
                End While

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If

    End Sub
    Private Sub bindReceiveListview()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetSampleBagDetails", DbType.String))
            .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbRBagNo.SelectedItem.Text), DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        dgvReceiveSample.DataSource = Nothing

        Try
            dgvReceiveSample.DataSource = dt
            dgvReceiveSample.EnableFiltering = True
            dgvReceiveSample.MasterTemplate.ShowFilteringRow = False
            dgvReceiveSample.MasterTemplate.ShowHeaderCellButtons = True

            Me.ReceivelistViewTotal()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try

    End Sub
    Private Sub ReceivelistViewTotal()
        Dim dSumOfGrossWt As Decimal = 0
        Dim dSumOfReceivePr As Decimal = 0
        Dim dSumOfFineWt As Decimal = 0

        Try
            For Each row As GridViewRowInfo In dgvReceiveSample.Rows
                dSumOfGrossWt += CDec(Val(row.Cells(3).Value))
                dSumOfFineWt += CDec(Val(row.Cells(5).Value))
            Next

            dSumOfReceivePr = (dSumOfFineWt / dSumOfGrossWt) * 100

            txtRIssueWt.Text = dSumOfGrossWt.ToString("N2")
            txtRIssuePr.Text = dSumOfReceivePr.ToString("N2")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fetchUpdateSampleBag()
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbUBagNo.SelectedItem.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then

                txtUTransId.Text = dtData.Rows(0).Item("UsedBagId").ToString()
                ULFailTransDt.Text = dtData.Rows(0).Item("UsedBagDt").ToString()

                txtUreceiveWt.Text = dtData.Rows(0).Item("RecieveWt").ToString()
                txtUreceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
                txtUreceiveFineWt.Text = dtData.Rows(0).Item("RecieveFineWt").ToString()

                txtUissueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtUissuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtUissueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()

                txtUWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtUcarbonReceive.Text = dtData.Rows(0).Item("CarbonReceive").ToString()
                txtUGrossLoss.Text = dtData.Rows(0).Item("GrossLossWt").ToString()
            Else
                MessageBox.Show("No Data Found !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

    End Sub
    Private Sub clearCreateData()
        txtCTransId.Clear()
        'txtSampleTotal.Clear()

        'cmbLotNo.SelectedIndex = 0
        'lstSampleBag.Items.Clear()
    End Sub
    Private Sub clearReceiveData()

        txtRTransId.Tag = ""
        txtRTransId.Clear()

        cmbRBagNo.Items.Clear()

        txtRIssueWt.Clear()
        txtRIssuePr.Clear()

        txtRWtOnScale.Clear()
        txtRRecieveWt.Clear()
        txtRSample.Clear()
        txtRTotalWt.Clear()
        txtRCarbon.Clear()
        txtRGrossLoss.Clear()
    End Sub
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click

        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If btnRSave.Text = "&Save" Then
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))

                    .Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UItemId", Val(cmbRBagtype.SelectedValue), DbType.Int16))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.SelectedItem.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRIssueWt.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRIssuePr.Text), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@URecieveWt", Val(txtRRecieveWt.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UCarbonRecieve", Val(txtRCarbon.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_UsedBags_Save", CommandType.StoredProcedure, parameters.ToArray())

                Dim tparameters = New List(Of SqlParameter)()
                tparameters.Clear()

                With tparameters
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateSampleSt", DbType.String))
                    .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbRBagNo.SelectedItem.Text), DbType.String))
                End With

                dbManager.Update("SP_SampleBagNo_Update", CommandType.StoredProcedure, tparameters.ToArray())

            End If

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ''clearReceiveAllData()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        If String.IsNullOrWhiteSpace(cmbUBagtype.Text.Trim()) Or Convert.ToInt32(cmbUBagtype.SelectedIndex) = -1 Then
            MessageBox.Show("Select Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbUBagtype.Focus()
        ElseIf String.IsNullOrWhiteSpace(cmbUBagNo.Text.Trim()) Then
            MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbUBagNo.Focus()
        Else
            Try

                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                If btnUSave.Text = "&Save" Then

                    With parameters
                        .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                        .Add(dbManager.CreateParameter("@TId", Val(txtUTransId.Text.Trim()), DbType.Int16))
                        .Add(dbManager.CreateParameter("@ReportPr", Val(txtUreceivePr.Text.Trim()), DbType.Decimal))
                        .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbUBagNo.SelectedItem.Text), DbType.String))
                    End With

                    dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())
                End If

                MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)


            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        End If

    End Sub
    Private Sub lstSampleBag_ItemChecked(sender As Object, e As ItemCheckedEventArgs)
        Me.CalculateSampleWt()
    End Sub
    Private Sub frmSampleBag_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub rbLotSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbLotSample.CheckedChanged
        If rbLotSample.Checked = True Then
            Me.bindSampleGridViewFrmTransaction()
        End If
    End Sub
    Private Sub rbBagSample_CheckedChanged(sender As Object, e As EventArgs) Handles rbBagSample.CheckedChanged
        If rbBagSample.Checked = True Then
            Me.bindSampleGridViewFrmUsedBags()
        End If
    End Sub
    Private Sub bindSampleGridViewFrmTransaction()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetNonTestedSampleData", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                dgvFSampleBag.DataSource = dt
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub bindSampleGridViewFrmUsedBags()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetNotSentSampleBag", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                dgvFSampleBag.DataSource = Nothing
                dgvFSampleBag.DataSource = dt
            End If

            If dgvFSampleBag.Rows.Count > 0 Then
                'Me.CalculateWt()
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub lstFSampleBag_KeyDown(sender As Object, e As KeyEventArgs)
        Try
            If (e.KeyCode = Keys.Delete) Then
                For Each listViewItem As ListViewItem In (CType(sender, ListView)).SelectedItems
                    listViewItem.Remove()
                Next
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub EnbledBtn()

        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not Validate_Fields() Then Exit Sub

        Try
            If rbLotSample.Checked = True Then
                Me.UpdateSampleSrNoForTran()

                AddHandler rbLotSample.CheckedChanged, AddressOf rbLotSample_CheckedChanged
            Else
                Me.UpdateSampleSrNoForUsed()
            End If

            ''Me.clearCreateAllData()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DisableBtn()
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub dtto_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles dtto.Validating
        If ((dtfrom.Value.Date) > (dtto.Value.Date)) Then
            MessageBox.Show("Invalid Selection", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            dtto.Focus()
        End If
    End Sub
    Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Dim dt As New DataTable

        If Not dgvFSampleBag.Rows.Count > 0 Then
            MessageBox.Show("No Data. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        dt = (CType(dgvFSampleBag.DataSource, DataTable)).Clone()

        For Each row As GridViewRowInfo In dgvFSampleBag.Rows
            If CBool(row.Cells()(0).Value) = True Then
                dt.ImportRow((CType(dgvFSampleBag.DataSource, DataTable)).Rows(row.Index))
            End If
        Next

        dt.AcceptChanges()
        dgvTSampleBag.DataSource = dt

        Me.CalculateTotal()
    End Sub
    Private Sub CalculateTotal()

        Dim sSampleTotal As Single = 0
        Dim sReceivePr As Single = 0
        Dim sFineTotal As Single = 0

        For Each row As GridViewRowInfo In dgvTSampleBag.Rows
            sSampleTotal += Single.Parse(row.Cells(4).Value)
            sReceivePr += Single.Parse(row.Cells(5).Value)
            sFineTotal += Single.Parse(row.Cells(6).Value)
        Next

        lblSampleTotal.Text = Format(sSampleTotal, "0.00")
        lblReceivePr.Text = Format(sReceivePr, "0.00")
        lblFineTotal.Text = Format(sFineTotal, "0.00")

    End Sub
    Private Sub UpdateSampleSrNoForTran()

        If dgvTSampleBag.Rows.Count > 0 Then

            Try
                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvTSampleBag.Rows.Count - 1
                    Dparameters.Add(dbManager.CreateParameter("@ActionType", "UpdateSampleNoForLot", DbType.String))
                    Dparameters.Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.SelectedValue), DbType.Int16))
                    Dparameters.Add(dbManager.CreateParameter("@TId", Val(dgvTSampleBag.Rows(i).Cells(0).Value), DbType.Int16))
                    Dparameters.Add(dbManager.CreateParameter("@BagType", "S", DbType.String))

                    dbManager.Update("SP_SampleBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())

                    Dparameters.Clear()
                Next

                MessageBox.Show("Sample Bag Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                AddHandler rbLotSample.CheckedChanged, AddressOf rbLotSample_CheckedChanged

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try

        End If
    End Sub
    Private Sub UpdateSampleSrNoForUsed()

        If dgvTSampleBag.Rows.Count > 0 Then

            Try

                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvTSampleBag.Rows.Count - 1
                    Dparameters.Add(dbManager.CreateParameter("@ActionType", "UpdateSampleNoForBag", DbType.String))
                    Dparameters.Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.SelectedValue), DbType.Int16))
                    Dparameters.Add(dbManager.CreateParameter("@TId", Val(dgvTSampleBag.Rows(i).Cells(0).Value), DbType.Int16))
                    Dparameters.Add(dbManager.CreateParameter("@BagType", "SB", DbType.String))

                    dbManager.Update("SP_SampleBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                    Dparameters.Clear()
                Next

                MessageBox.Show("Sample Bag Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try

        End If
    End Sub
    Private Sub cmbCBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbCBagtype.SelectedIndexChanged
        If Convert.ToInt32(cmbCBagtype.SelectedIndex) > 0 Then
            'Me.getBagPrefix()
            ''txtMaxNo.Text = CStr(GetMaxSampleNo())
            ''Me.bindSampleBag()
        End If
    End Sub
    Private Sub dgvFSampleBag_ValueChanged(sender As Object, e As EventArgs) Handles dgvFSampleBag.ValueChanged
        If dgvFSampleBag.CurrentColumn.Name = "colChkBox" Then
            dgvFSampleBag.EndEdit()
        End If
    End Sub
    Private Sub bindSampleBag()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetSampleData", DbType.String))
            .Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.SelectedValue), DbType.Int16))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            dgvFSampleBag.DataSource = dt
            dgvFSampleBag.EnableFiltering = True
            dgvFSampleBag.MasterTemplate.ShowFilteringRow = False
            dgvFSampleBag.MasterTemplate.ShowHeaderCellButtons = True

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

    End Sub
    Private Sub tbSampleBag_Click(sender As Object, e As EventArgs) Handles tbSampleBag.Click
        If tbSampleBag.SelectedIndex = 0 Then       ''for Create Bhuka Bag
            Me.fillBagType()
        ElseIf tbSampleBag.SelectedIndex = 1 Then   ''for Receive Bhuka Bag
            Me.fillBagType()
        ElseIf tbSampleBag.SelectedIndex = 2 Then   ''for Update Bhuka Bag
            Me.fillBagType()
        End If
    End Sub
    Private Sub cmbRBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbRBagtype.SelectedIndexChanged
        Me.fillReceiveSampleSrNo()
    End Sub
    Private Sub rbLabNotSent_CheckedChanged(sender As Object, e As EventArgs) Handles rbLabNotSent.CheckedChanged
        If rbLotSample.Checked = True And rbLabNotSent.Checked = True Then
            Me.bindIssueListviewTrans()
        End If
    End Sub
    Private Sub txtRIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtRIssueWt.TextChanged
        Try
            'txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRRecieveWt.Text) - Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtRRecieveWt_TextChanged(sender As Object, e As EventArgs) Handles txtRRecieveWt.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRRecieveWt.Text) + Val(txtRSample.Text), "0.00")
            'txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRRecieveWt.Text) - Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtRSample_TextChanged(sender As Object, e As EventArgs) Handles txtRSample.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRRecieveWt.Text) + Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtRWtOnScale_Leave(sender As Object, e As EventArgs) Handles txtRWtOnScale.Leave
        txtRWtOnScale.Text = Format(Val(txtRWtOnScale.Text), "0.00")
    End Sub
    Private Sub txtRRecieveWt_Leave(sender As Object, e As EventArgs) Handles txtRRecieveWt.Leave
        txtRRecieveWt.Text = Format(Val(txtRRecieveWt.Text), "0.00")
    End Sub
    Private Sub txtRSample_Leave(sender As Object, e As EventArgs) Handles txtRSample.Leave
        txtRSample.Text = Format(Val(txtRSample.Text), "0.00")
    End Sub
    Private Sub txtRCarbon_Leave(sender As Object, e As EventArgs) Handles txtRCarbon.Leave
        txtRCarbon.Text = Format(Val(txtRCarbon.Text), "0.00")
    End Sub
    Private Sub txtRTotalWt_TextChanged(sender As Object, e As EventArgs) Handles txtRTotalWt.TextChanged
        Try
            txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRTotalWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceiveFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUreceiveFineWt.TextChanged
        Try
            txtULossFine.Text = Format(Val(txtUissueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUissueFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUissueFineWt.TextChanged
        Try
            txtULossFine.Text = Format(Val(txtUissueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbUBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbUBagtype.SelectedIndexChanged
        Me.fillUpdateSampleSrNo()
    End Sub
    Private Sub bindIssueListviewTrans()
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetNotSentSampleBag", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                dgvFSampleBag.DataSource = dt
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbRBagNo.SelectedIndexChanged
        If cmbRBagNo.SelectedIndex >= 0 Then
            Me.bindReceiveListview()
        End If
    End Sub
    Private Sub cmbUBagNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbUBagNo.SelectedIndexChanged
        If cmbUBagNo.SelectedIndex >= 0 Then
            Me.fetchUpdateSampleBag()
        End If
    End Sub
    Private Sub txtUreceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtUreceivePr.TextChanged
        Try
            txtUreceiveFineWt.Text = Format((Val(txtUreceiveWt.Text) * Val(txtUreceivePr.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUissueWt_TextChanged(sender As Object, e As EventArgs) Handles txtUissueWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUissueWt.Text) - Val(txtUreceiveWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtUreceiveWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUissueWt.Text) - Val(txtUreceiveWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnUExit_Click(sender As Object, e As EventArgs) Handles btnUExit.Click
        Me.Close()
    End Sub
    Private Sub btnCExit_Click(sender As Object, e As EventArgs) Handles btnCExit.Click
        Me.Close()
    End Sub
    Private Sub btnRExit_Click(sender As Object, e As EventArgs) Handles btnRExit.Click
        Me.Close()
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Try
            Call UClear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UClear_Form()
        Try
            cmbUBagtype.SelectedIndex = 0
            cmbUBagNo.Text = ""

            txtUreceivePr.Clear()
            txtUreceiveWt.Clear()
            txtUreceiveFineWt.Clear()
            txtUGrossLoss.Clear()
            txtULossFine.Clear()
            txtUissuePr.Clear()
            txtUissueWt.Clear()
            txtUissueFineWt.Clear()
            txtUWtOnScale.Clear()
            txtUcarbonReceive.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Try
            'Call RClear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub fillReceiveSampleSrNo()

        If cmbRBagtype.SelectedIndex > 0 Then

            Dim connection As SqlConnection = Nothing

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If cmbRBagtype.SelectedIndex = 1 Then
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "GetNotTestedSampleSrNo", DbType.String))
                End With
            End If

            If cmbRBagtype.SelectedIndex = 2 Then
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "GetTestedSampleSrNo", DbType.String))
                End With
            End If

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

            cmbRBagNo.Items.Clear()
            cmbRBagNo.ResetText()

            Try
                While dr.Read
                    If Not IsDBNull(dr.Item("SampleBagNo")) Then
                        cmbRBagNo.Items.Add(dr.Item("SampleBagNo"))
                    End If
                End While

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Sub fillUpdateSampleSrNo()

        If cmbUBagtype.SelectedIndex > 0 Then
            Dim connection As SqlConnection = Nothing

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@BId", Val(cmbUBagtype.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "GetUpdateSampleSrNo", DbType.String))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

            cmbUBagNo.Items.Clear()
            cmbUBagNo.ResetText()

            Try
                While dr.Read
                    If Not IsDBNull(dr.Item("SampleBagNo")) Then
                        cmbUBagNo.Items.Add(dr.Item("SampleBagNo"))
                    End If
                End While

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Function ReceiveValidate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbRBagtype.Text.Trim()) Or Convert.ToInt32(cmbRBagtype.SelectedIndex) = -1 Then
                MessageBox.Show("Select Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagtype.Focus()
            ElseIf String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Then
                MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagNo.Focus()
            ElseIf txtRWtOnScale.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Wt. On Scale !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRWtOnScale.Focus()
                Return False
            ElseIf txtRRecieveWt.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Lagdi Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRRecieveWt.Focus()
                Return False
            ElseIf txtRSample.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Sample Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRSample.Focus()
                Return False
            ElseIf txtRCarbon.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Carbon Recived !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRCarbon.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Function Validate_Fields() As Boolean
        Try

            'Assigning Default values
            If Val(cmbCBagtype.SelectedIndex) = -1 Or Val(cmbCBagtype.SelectedIndex) = 0 Then
                MessageBox.Show("Select Item Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbCBagtype.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class


