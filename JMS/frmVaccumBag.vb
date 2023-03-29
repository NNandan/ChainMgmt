Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmVaccumBag
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
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
    Private Sub frmVaccumeBag_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.EnbledBtn()
        Me.FillBagType()
    End Sub
    Private Sub bindVacuumBag()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetVaccumData", DbType.String))
            .Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.SelectedValue), DbType.Int16))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            dgvVacuumBag.DataSource = dt
            dgvVacuumBag.EnableFiltering = True
            dgvVacuumBag.MasterTemplate.ShowFilteringRow = False
            dgvVacuumBag.MasterTemplate.ShowHeaderCellButtons = True

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub EnbledBtn()
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub DisableBtn()
        'btnShow.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub FillBagType()

        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillVacuumBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        dt.Load(dr)

        If tbVaccumeBag.SelectedIndex = 0 Then
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
        ElseIf tbVaccumeBag.SelectedIndex = 1 Then
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
                cmbRBagtype.AutoCompleteMode = AutoCompleteMode.Suggest
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        Else
            Try
                cmbUpdBagtype.DataSource = Nothing
                cmbUpdBagtype.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbUpdBagtype.DataSource = dt
                cmbUpdBagtype.DisplayMember = "ItemName"
                cmbUpdBagtype.ValueMember = "ItemId"
                cmbUpdBagtype.AutoCompleteMode = AutoCompleteMode.Suggest
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        End If
    End Sub
    Private Sub clearCreateData()
        'txtMaxNo.Clear()
        'cmbCBagtype.SelectedIndex = 0
        cmbCBagtype_SelectedIndexChanged(cmbCBagtype, EventArgs.Empty)
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Me.ClearUpdateData()
    End Sub
    Private Sub clearReceiveData()
        txtRTransId.Tag = ""
        txtRTransId.Clear()

        cmbRBagNo.SelectedItem.Text = ""

        txtRIssueWt.Clear()
        txtRIssuePr.Clear()

        txtRWtOnScale.Clear()
        txtRRecieveWt.Clear()
        txtRSample.Clear()
        txtRTotalWt.Clear()
        txtRCarbon.Clear()
        txtRGrossLoss.Clear()

    End Sub
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Me.ClearUpdateData()
    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        If Not UpdateValidate_Fields() Then Exit Sub

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
            Me.ClearUpdateData()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.UpdateVacuumSrNo()
            Me.clearCreateData()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.clearCreateData()
    End Sub
    Private Sub ClearUpdateData()
        txtUTransId.Clear()
        txtUTransId.Tag = ""

        cmbUBagNo.SelectedItem.Text = ""

        txtUreceivePr.Clear()
        txtUreceiveWt.Clear()
        txtUreceiveFineWt.Clear()

        txtUissuePr.Clear()
        txtUissueWt.Clear()
        txtUissueFineWt.Clear()

        txtUWtOnScale.Clear()
        txtUcarbonReceive.Clear()

        txtUGrossLoss.Clear()
        txtULossFine.Clear()
    End Sub
    Private Sub frmVaccumeBag_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
                SendKeys.Send("{HOME}+{END}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbCBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbCBagtype.SelectedIndexChanged
        If Convert.ToInt32(cmbCBagtype.SelectedIndex) > 0 Then
            Me.bindVacuumBag()

            If dgvVacuumBag.Rows.Count > 0 Then
                Me.DisableBtn()
            End If
        End If
    End Sub
    Private Sub fetchUpdateVacuumBag()

        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbUBagNo.SelectedItem.Text), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dt.Rows.Count > 0 Then
                txtUTransId.Text = dt.Rows(0).Item("UsedBagId").ToString()
                ULFailTransDt.Text = dt.Rows(0).Item("UsedBagDt").ToString()

                ''txtUreceiveWt.Text = dt.Rows(0).Item("RecieveWt").ToString()
                txtUreceiveWt.Text = dt.Rows(0).Item("IssueWt").ToString()

                txtUreceivePr.Text = dt.Rows(0).Item("ReportPr").ToString()
                txtUreceiveFineWt.Text = dt.Rows(0).Item("RecieveFineWt").ToString()

                txtUissueWt.Text = dt.Rows(0).Item("IssueWt").ToString()
                txtUissuePr.Text = dt.Rows(0).Item("IssuePr").ToString()
                txtUissueFineWt.Text = dt.Rows(0).Item("IssueFineWt").ToString()

                txtUWtOnScale.Text = dt.Rows(0).Item("WtOnScale").ToString()
                txtUcarbonReceive.Text = dt.Rows(0).Item("CarbonReceive").ToString()

                'txtUGrossLoss.Text = dt.Rows(0).Item("GrossLossWt").ToString()
            Else
                MessageBox.Show("No Data Found !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

    End Sub
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click

        If Not ReceiveValidate_Fields() Then Exit Sub

        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If btnRSave.Text = "&Save" Then

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UItemId", Val(cmbRBagtype.SelectedValue), DbType.Int16))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.SelectedItem.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRIssueWt.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRIssuePr.Text), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UReceiveWt", Val(txtRRecieveWt.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UCarbonRecieve", Val(txtRCarbon.Text), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_UsedBags_Save", CommandType.StoredProcedure, parameters.ToArray())

                Dim tparameters = New List(Of SqlParameter)()

                With tparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateVacuumSt", DbType.String))
                    .Add(dbManager.CreateParameter("@BId", Val(cmbRBagtype.SelectedValue), DbType.Int16))
                    .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbRBagNo.SelectedItem), DbType.String))
                End With

                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, tparameters.ToArray())
            End If

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clearReceiveData()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateVacuumSrNo()

        Dim alParaval As New ArrayList

        Dim BagId As Int16 = 0
        Dim TranId As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(cmbCBagtype.SelectedValue)

        If dgvVacuumBag.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvVacuumBag.Rows
                If row.Cells(0).Value = True Then
                    If TranId = "" Then
                        TranId = Val(row.Cells(7).Value)
                    Else
                        TranId = TranId & "|" & Val(row.Cells(7).Value)
                    End If
                End If
                IRowCount += 1
            Next

            alParaval.Add(TranId)

            Try

                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                With Dparameters
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateVacuumNo", DbType.String))
                    .Add(dbManager.CreateParameter("@BId", alParaval.Item(iValue), DbType.Int16))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@TId", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                    .Add(dbManager.CreateParameter("@BagType", "V", DbType.String))
                End With

                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())

                MessageBox.Show("Vaccum Bag Updated !!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try

        End If
    End Sub
    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbRBagNo.SelectedIndexChanged
        If cmbRBagNo.SelectedIndex >= 0 Then
            Me.bindReceiveListview()
        End If
    End Sub
    Private Sub BindCreateVacuumBag()
        Dim dtdata As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetBhukaData", DbType.String))
            .Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.SelectedValue), DbType.Int16))
        End With

        dtdata = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        'Try
        '    dgvfVacuumBag.DataSource = dtdata
        '    dgvfVacuumBag.EnableFiltering = True
        '    dgvfVacuumBag.MasterTemplate.ShowFilteringRow = False
        '    dgvfVacuumBag.MasterTemplate.ShowHeaderCellButtons = True
        'Catch ex As Exception
        '    MessageBox.Show("Error:- " & ex.Message)
        'Finally
        'End Try

    End Sub
    Private Sub tbVaccumeBag_Click(sender As Object, e As EventArgs) Handles tbVaccumeBag.Click
        If tbVaccumeBag.SelectedIndex = 0 Then  ''for Create Vaccum Bag
            Me.FillBagType()
        ElseIf tbVaccumeBag.SelectedIndex = 1 Then ''for Receive Vaccum Bag
            Me.FillBagType()
        ElseIf tbVaccumeBag.SelectedIndex = 2 Then ''for Update Vaccum Bag
            Me.FillBagType()
        End If
    End Sub
    Private Sub CalculateTotal()
        Dim sVaccumTotal As Single = 0
        Dim sVaccumFineTotal As Single = 0

        For Each row As GridViewRowInfo In dgvVacuumBag.Rows
            If CBool(row.Cells()(0).Value) = True And Not String.IsNullOrEmpty(row.Cells(4).Value) Then
                sVaccumTotal += Single.Parse(row.Cells(4).Value)
                sVaccumFineTotal += Single.Parse(row.Cells(6).Value)
            End If
        Next

        lblVacuumTotal.Text = Format(sVaccumTotal, "0.00")
        lblFineTotal.Text = Format(sVaccumFineTotal, "0.00")

    End Sub
    Private Sub cmbUBagNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbUBagNo.SelectedIndexChanged
        Me.fetchUpdateVacuumBag()
    End Sub
    Private Sub bindReceiveListview()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetVaccumBagDetails", DbType.String))
            .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbRBagNo.SelectedItem.Text.Trim()), DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        Try

            dgvReceiveVacuum.DataSource = dt
            dgvReceiveVacuum.EnableFiltering = True
            dgvReceiveVacuum.MasterTemplate.ShowFilteringRow = False
            dgvReceiveVacuum.MasterTemplate.ShowHeaderCellButtons = True

            Me.ReceivelistViewTotal()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub lstVaccumBag_ItemChecked(sender As Object, e As ItemCheckedEventArgs)
        'Me.fillMaxsrno()
    End Sub
    Private Sub txtRRecieveWt_TextChanged(sender As Object, e As EventArgs) Handles txtRRecieveWt.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRRecieveWt.Text) + Val(txtRSample.Text), "0.00")
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
    Private Sub txtRIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtRIssueWt.TextChanged
        Try
            'txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRRecieveWt.Text) - Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceivePr_Leave(sender As Object, e As EventArgs) Handles txtUreceivePr.Leave
        txtUreceivePr.Text = Format(Val(txtUreceivePr.Text), "0.00")
    End Sub
    Private Sub txtUreceivePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUreceivePr.KeyPress
        numdotkeypress(e, txtUreceivePr, Me)
    End Sub
    Private Sub dgvFVacuumBag_ValueChanged(sender As Object, e As EventArgs) Handles dgvVacuumBag.ValueChanged
        If dgvVacuumBag.CurrentColumn.Name = "colChkBox" Then
            dgvVacuumBag.EndEdit()
        End If

        Me.CalculateTotal()
    End Sub
    Private Sub txtRWtOnScale_Leave(sender As Object, e As EventArgs) Handles txtRWtOnScale.Leave
        txtRWtOnScale.Text = Format(Val(txtRWtOnScale.Text), "0.00")
    End Sub
    Private Sub txtRRecieveWt_Leave(sender As Object, e As EventArgs)
        txtRWtOnScale.Text = Format(Val(txtRWtOnScale.Text), "0.00")
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
            txtULossFine.Text = Format(Val(txtUreceiveFineWt.Text) - Val(txtUissueFineWt.Text), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUissueFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUissueFineWt.TextChanged
        Try
            txtULossFine.Text = Format(Val(txtUreceiveFineWt.Text) - Val(txtUissueFineWt.Text), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbRBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbRBagtype.SelectedIndexChanged
        Me.fillReceiveVacuumSrNo()
    End Sub
    Private Sub cmbUpdBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbUpdBagtype.SelectedIndexChanged
        Me.fillUpdateVacuumSrNo()
    End Sub
    Private Sub ReceivelistViewTotal()
        Dim dSumOfGrossWt As Decimal = 0
        Dim dSumOfReceivePr As Decimal = 0
        Dim dSumOfFineWt As Decimal = 0

        Try
            For Each row As GridViewRowInfo In dgvReceiveVacuum.Rows
                dSumOfGrossWt += CDec(Val(row.Cells(5).Value))
                dSumOfFineWt += CDec(Val(row.Cells(7).Value))
            Next

            dSumOfReceivePr = (dSumOfFineWt / dSumOfGrossWt) * 100

            txtRIssueWt.Text = dSumOfGrossWt.ToString("N2")
            txtRIssuePr.Text = dSumOfReceivePr.ToString("N2")
        Catch ex As Exception
            Throw ex
        End Try
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
    Private Sub txtRRecieveWt_Leave_1(sender As Object, e As EventArgs) Handles txtRRecieveWt.Leave
        txtRRecieveWt.Text = Format(Val(txtRRecieveWt.Text), "0.00")
    End Sub
    Private Sub btnCExit_Click(sender As Object, e As EventArgs) Handles btnCExit.Click
        Me.Close()
    End Sub
    Private Sub btnRExit_Click(sender As Object, e As EventArgs) Handles btnRExit.Click
        Me.Close()
    End Sub
    Private Sub btnUExit_Click(sender As Object, e As EventArgs) Handles btnUExit.Click
        Me.Close()
    End Sub
    Private Sub fillReceiveVacuumSrNo()
        If cmbRBagtype.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetReceiveVaccumSrNo", DbType.String))
                .Add(dbManager.CreateParameter("@BId", Val(cmbRBagtype.SelectedValue), DbType.Int16))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

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
                Objcn.Close()
            End Try

        End If
    End Sub
    Private Sub CalculateVacuumWt()
        Dim sIssueTotal As Single = 0
        Dim sReceiveTotal As Single = 0
        Dim sBhukaTotal As Single = 0
        Dim sSampleTotal As Single = 0
        Dim sVaccumeTotal As Single = 0

        'For i As Integer = 0 To lstVaccumBag.Items.Count - 1
        '    If (lstVaccumBag.Items(i).Checked And Not String.IsNullOrEmpty(lstVaccumBag.Items(i).SubItems(4).Text)) Then
        '        sIssueTotal += Single.Parse(lstVaccumBag.Items(i).SubItems(4).Text.Trim())
        '    End If
        '    If (lstVaccumBag.Items(i).Checked And Not String.IsNullOrEmpty(lstVaccumBag.Items(i).SubItems(5).Text)) Then
        '        sReceiveTotal += Single.Parse(lstVaccumBag.Items(i).SubItems(5).Text.Trim())
        '    End If
        '    If (lstVaccumBag.Items(i).Checked And Not String.IsNullOrEmpty(lstVaccumBag.Items(i).SubItems(6).Text)) Then
        '        sBhukaTotal += Single.Parse(lstVaccumBag.Items(i).SubItems(6).Text.Trim())
        '    End If
        '    'If (lstVaccumBag.Items(i).Checked And Not String.IsNullOrEmpty(lstVaccumBag.Items(i).SubItems(7).Text)) Then
        '    '    sSampleTotal += Single.Parse(lstVaccumBag.Items(i).SubItems(7).Text.Trim())
        '    'End If
        '    'If (lstVaccumBag.Items(i).Checked And Not String.IsNullOrEmpty(lstVaccumBag.Items(i).SubItems(8).Text)) Then
        '    '    sVaccumeTotal += Single.Parse(lstVaccumBag.Items(i).SubItems(8).Text.Trim())
        '    'End If
        'Next

        'txtIssueTotal.Text = Format(sIssueTotal, "0.00")
        'txtReceiveTotal.Text = Format(sReceiveTotal, "0.00")
        'txtBhukaTotal.Text = Format(sBhukaTotal, "0.00")
        'txtVaccumeTotal.Text = Format(sVaccumeTotal, "0.00")
    End Sub
    Private Sub fillUpdateVacuumSrNo()

        If cmbUpdBagtype.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@BId", Val(cmbUpdBagtype.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "GetUpdateVaccumSrNo", DbType.String))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

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
                Objcn.Close()
            End Try
        End If
    End Sub
    Private Function ReceiveValidate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Then
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
    Private Function UpdateValidate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbUBagNo.Text.Trim()) Then
                MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbUBagNo.Focus()
            ElseIf txtUreceivePr.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Receive % !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUreceivePr.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
End Class