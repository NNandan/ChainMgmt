Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmBhukaBag
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
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
    Private Sub frmCBhukaBagvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.fillBagType()
    End Sub
    Private Sub fillBagType()

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
                cmbCBagtype.AutoCompleteMode = AutoCompleteMode.Suggest
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try

        ElseIf tbBhukaBag.SelectedIndex = 1 Then

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
    Private Sub tbBhukaBag_Click(sender As Object, e As EventArgs) Handles tbBhukaBag.Click
        If tbBhukaBag.SelectedIndex = 0 Then     ''for Create Bhuka Bag
            Me.fillBagType()
        ElseIf tbBhukaBag.SelectedIndex = 1 Then ''for Receive Bhuka Bag
            Me.fillBagType()
        ElseIf tbBhukaBag.SelectedIndex = 2 Then ''for Update Bhuka Bag
            Me.fillBagType()
        End If
    End Sub
    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.bindReceiveListview()
    End Sub
    Private Sub cmbRBagtype_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.fillReceiveBhukaSrNo()
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
        'txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRRecieveWt.Text) - Val(txtRSample.Text), "0.00")
    End Sub

#Region "CreateBhukaBag"
    Private Sub BindCreateBhukaBag()
        Dim dtdata As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetBhukaData", DbType.String))
            .Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.SelectedValue), DbType.Int16))
        End With

        dtdata = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        Try
            dgvCBhukaBag.DataSource = dtdata
            dgvCBhukaBag.EnableFiltering = True
            dgvCBhukaBag.MasterTemplate.ShowFilteringRow = False
            dgvCBhukaBag.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub UpdateBhukaSrNo()

        If dgvCBhukaBag.Rows.Count > 0 Then

            Try

                Dim Dparameters = New List(Of SqlParameter)()
                Dparameters.Clear()

                For i As Integer = 0 To dgvCBhukaBag.RowCount - 1
                    If dgvCBhukaBag.Rows(i).Cells(0).Value = True Then
                        Dparameters.Add(dbManager.CreateParameter("@ActionType", "UpdateBhukaNo", DbType.String))
                        Dparameters.Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.SelectedValue), DbType.Int16))
                        Dparameters.Add(dbManager.CreateParameter("@TId", Val(dgvCBhukaBag.Rows(i).Cells(7).Value), DbType.Int16))
                        Dparameters.Add(dbManager.CreateParameter("@BagType", "B", DbType.String))

                        dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                    End If
                    Dparameters.Clear()
                Next

                MessageBox.Show("Bhuka Bag Updated !!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try

        End If
    End Sub
    Private Sub clearCreateAllData()
        'btnShow.Text = "Show"
        'txtMaxNo.Clear()

        'dgvBhukaBag.DataSource = Nothing

        cmbCBagtype.SelectedIndex = 0
        cmbCBagtype_SelectedIndexChanged(cmbCBagtype, EventArgs.Empty)
    End Sub

#End Region

#Region "ReceiveBhukaBag"
    Private Sub bindReceiveListview()

        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "GetRecordByBhukaSrNo", DbType.String))
                .Add(dbManager.CreateParameter("@BId", cmbRBagtype.SelectedValue, DbType.Int16))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbRBagNo.SelectedItem.Text.Trim), DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

            dgvRBhukaBag.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                dgvRBhukaBag.DataSource = dt
            End If

            Me.ReceivelistViewTotal()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub fillReceiveBhukaSrNo()

        If cmbRBagtype.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            parameters.Add(dbManager.CreateParameter("@ActionType", "GetReceiveBhukaSrNo", DbType.String))
            parameters.Add(dbManager.CreateParameter("@BId", Val(cmbRBagtype.SelectedValue), DbType.Int16))

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

            cmbRBagNo.Items.Clear()
            cmbRBagNo.ResetText()

            Try
                While dr.Read
                    If Not IsDBNull(dr.Item("BhukaBagNo")) Then
                        cmbRBagNo.Items.Add(dr.Item("BhukaBagNo"))
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
    Private Sub fillUpdateBhukaSrNo()
        If cmbUpdBagtype.SelectedIndex > 0 Then

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@BId", Val(cmbUpdBagtype.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "GetUpdateBhukaSrNo", DbType.String))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Exit Sub
            End If

            cmbUpdBagNo.Items.Clear()
            cmbUpdBagNo.ResetText()

            Try
                While dr.Read
                    If Not IsDBNull(dr.Item("BhukaBagNo")) Then
                        cmbUpdBagNo.Items.Add(dr.Item("BhukaBagNo"))
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
    Private Sub ReceivelistViewTotal()
        Dim dSumOfGrossWt As Decimal = 0
        Dim dSumOfReceivePr As Decimal = 0
        Dim dSumOfFineWt As Decimal = 0

        Try
            For Each row As GridViewRowInfo In dgvRBhukaBag.Rows
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
    Private Sub clearReceiveAllData()
        cmbRBagtype.SelectedIndex = 0
        cmbRBagNo.SelectedItem.Text = ""

        txtRIssueWt.Clear()
        txtRIssuePr.Clear()

        txtRWtOnScale.Clear()
        txtRRecieveWt.Clear()

        txtRSample.Clear()
        txtRTotalWt.Clear()

        txtRCarbon.Clear()
        txtRGrossLoss.Clear()

        dgvRBhukaBag.DataSource = Nothing
    End Sub

#End Region

#Region "UpdateBhukaBag"
    Private Sub bindUpdateListview()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
        parameters.Add(dbManager.CreateParameter("@BId", cmbRBagtype.SelectedIndex, DbType.Int16))
        parameters.Add(dbManager.CreateParameter("@BhukaSrNo", Trim(cmbRBagNo.SelectedItem.Text), DbType.String))

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_UsedBags_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        dgvRBhukaBag.Rows.Clear()

        Try
            While dr.Read
                dgvRBhukaBag.DataSource = dr
            End While
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try

    End Sub
    Private Sub fetchUpdateBhukaBag()

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            parameters.Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbUpdBagNo.SelectedItem), DbType.String))
            parameters.Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtUpdTransId.Text = dtData.Rows(0).Item("UsedBagId").ToString()
                UTransDt.Text = dtData.Rows(0).Item("UsedBagDt").ToString()

                txtUreceiveWt.Text = dtData.Rows(0).Item("IssueWt").ToString()

                txtUreceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
                txtUreceiveFineWt.Text = dtData.Rows(0).Item("RecieveFineWt").ToString()

                txtUIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtUIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtUIssueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()

                txtUWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtUcarbonReceive.Text = dtData.Rows(0).Item("CarbonRecieve").ToString()

                'txtUGrossLoss.Text = dtData.Rows(0).Item("GrossLossWt").ToString()
            Else
                MessageBox.Show("No Data Found !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

    End Sub
    Private Sub clearUpdateAllData()
        txtUpdTransId.Tag = ""
        txtUpdTransId.Clear()

        cmbUpdBagtype.SelectedIndex = 0
        cmbUpdBagNo.SelectedItem.Text = ""

        txtUreceivePr.Clear()
        txtUreceiveWt.Clear()
        txtUreceiveFineWt.Clear()

        txtUIssuePr.Clear()
        txtUIssueWt.Clear()
        txtUIssueFineWt.Clear()

        txtUWtOnScale.Clear()
        txtUcarbonReceive.Clear()

        txtUGrossLoss.Clear()
        txtUpdLossFine.Clear()
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
#End Region
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click
        If Not ReceiveValidate_Fields() Then Exit Sub

        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If btnRSave.Text = "&Save" Then

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RBhukaTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UItemId", Val(cmbRBagtype.SelectedValue), DbType.Int16))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.SelectedItem), DbType.String))

                    .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRIssueWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRIssuePr.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@URecieveWt", Val(txtRRecieveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonRecieve", Val(txtRCarbon.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_UsedBags_Save", CommandType.StoredProcedure, parameters.ToArray())

                Dim tparameters = New List(Of SqlParameter)()
                tparameters.Clear()

                With tparameters
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateBhukaSt", DbType.String))
                    .Add(dbManager.CreateParameter("@BId", Val(cmbRBagtype.SelectedValue), DbType.Int16))
                    .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbRBagNo.SelectedItem), DbType.String))
                End With

                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, tparameters.ToArray())
            End If

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clearReceiveAllData()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        If Not UpdateValidate_Fields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If btnUSave.Text = "&Save" Then

                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                    .Add(dbManager.CreateParameter("@TId", Val(txtUpdTransId.Text.Trim()), DbType.Int16))
                    .Add(dbManager.CreateParameter("@ReportPr", Convert.ToDecimal(txtUreceivePr.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LossWt", Convert.ToDecimal(txtUpdLossFine.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbUpdBagNo.SelectedItem), DbType.String))
                End With

                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())
            End If

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            clearUpdateAllData()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub txtRWtOnScale_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtRWtOnScale, Me)
    End Sub
    Private Sub txtRRecieveWt_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtRRecieveWt, Me)
    End Sub
    Private Sub txtRSample_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtRSample, Me)
    End Sub
    Private Sub txtRCarbon_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtRCarbon, Me)
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.UpdateBhukaSrNo()
            Me.clearCreateAllData()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.clearCreateAllData()
    End Sub
    Private Sub frmBhukaBag_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
                SendKeys.Send("{HOME}+{END}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbCBagtype_SelectedIndexChanged(sender As Object, e As EventArgs)
        If Convert.ToInt32(cmbCBagtype.SelectedIndex) > 0 Then
            Me.BindCreateBhukaBag()
        End If
    End Sub
    Private Sub cmbCBagtype_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbCBagtype.SelectedIndexChanged
        If Convert.ToInt32(cmbCBagtype.SelectedIndex) > 0 Then
            Me.BindCreateBhukaBag()
        End If
    End Sub
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Me.clearReceiveAllData()
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Me.clearUpdateAllData()
    End Sub
    Private Sub dgvBhukaBag_ValueChanged(sender As Object, e As EventArgs) Handles dgvCBhukaBag.ValueChanged
        If dgvCBhukaBag.CurrentColumn.Name = "colChkBox" Then
            dgvCBhukaBag.EndEdit()
        End If

        Me.CalculateTotal()
    End Sub
    Private Sub CalculateTotal()
        Dim sBhukaTotal As Single = 0
        Dim sBhukaFineTotal As Single = 0

        For Each row As GridViewRowInfo In dgvCBhukaBag.Rows
            If CBool(row.Cells()(0).Value) = True And Not String.IsNullOrEmpty(row.Cells(4).Value) Then
                sBhukaTotal += Single.Parse(row.Cells(4).Value)
                sBhukaFineTotal += Single.Parse(row.Cells(6).Value)
            End If
        Next

        lblBhukaTotal.Text = Format(sBhukaTotal, "0.00")
        lblFineTotal.Text = Format(sBhukaFineTotal, "0.00")
    End Sub
    Private Sub cmbRBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbRBagtype.SelectedIndexChanged
        Me.fillReceiveBhukaSrNo()
    End Sub
    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbRBagNo.SelectedIndexChanged
        If cmbRBagNo.SelectedIndex >= 0 Then
            Me.bindReceiveListview()
        End If
    End Sub
    Private Sub cmbUpdBagtype_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbUpdBagtype.SelectedIndexChanged
        Me.fillUpdateBhukaSrNo()
    End Sub
    Private Sub cmbUpdBagNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbUpdBagNo.SelectedIndexChanged
        Me.fetchUpdateBhukaBag()
    End Sub
    Private Sub txtUreceiveFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUreceiveFineWt.TextChanged
        Try
            txtUpdLossFine.Text = Format(Val(txtUIssueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUIssueFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUIssueFineWt.TextChanged
        Try
            txtUpdLossFine.Text = Format(Val(txtUIssueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbRBagtype_Enter(sender As Object, e As EventArgs) Handles cmbRBagtype.Enter
        cmbRBagtype.ShowDropDown()
    End Sub
    Private Sub cmbRBagNo_Enter(sender As Object, e As EventArgs) Handles cmbRBagNo.Enter
        cmbRBagNo.ShowDropDown()
    End Sub
    Private Sub txtRTotalWt_TextChanged(sender As Object, e As EventArgs) Handles txtRTotalWt.TextChanged
        Try
            txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRTotalWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceivePr_Leave(sender As Object, e As EventArgs) Handles txtUreceivePr.Leave
        txtUreceivePr.Text = Format(Val(txtUreceivePr.Text), "0.00")
    End Sub
    Private Sub txtUreceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtUreceivePr.TextChanged
        Try
            txtUreceiveFineWt.Text = Format((Val(txtUreceiveWt.Text) * Val(txtUreceivePr.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbCBagtype_Enter(sender As Object, e As EventArgs) Handles cmbCBagtype.Enter
        cmbCBagtype.ShowDropDown()
    End Sub
    Private Sub btnRExit_Click(sender As Object, e As EventArgs) Handles btnRExit.Click
        Me.Close()
    End Sub
    Private Sub btnUExit_Click(sender As Object, e As EventArgs) Handles btnUExit.Click
        Me.Close()
    End Sub
    Private Sub txtUreceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtUreceiveWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUIssueWt.Text) - Val(txtUreceiveWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtUIssueWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUIssueWt.Text) - Val(txtUreceiveWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnCExit_Click(sender As Object, e As EventArgs) Handles btnCExit.Click
        Me.Close()
    End Sub

    Private Sub Clear_Form()
        Try
            ''Create Bhuka Data

            cmbCBagtype.SelectedIndex = 0
            dgvCBhukaBag.DataSource = Nothing

            btnSave.Enabled = True
            btnCancel.Enabled = True

            ''Receive Bhuka Data
            cmbRBagtype.SelectedIndex = 0
            cmbRBagNo.SelectedItem.Text = ""

            txtRIssueWt.Clear()
            txtRIssuePr.Clear()

            txtRWtOnScale.Clear()
            txtRRecieveWt.Clear()

            txtRSample.Clear()
            txtRTotalWt.Clear()

            txtRCarbon.Clear()
            txtRGrossLoss.Clear()

            btnRSave.Enabled = True
            btnRCancel.Enabled = True

            'Updata Bhuka Data
            txtUpdTransId.Tag = ""
            txtUpdTransId.Clear()

            cmbUpdBagtype.SelectedIndex = 0
            cmbUpdBagNo.SelectedItem.Text = ""

            txtUreceivePr.Clear()
            txtUreceiveWt.Clear()
            txtUreceiveFineWt.Clear()

            txtUIssuePr.Clear()
            txtUIssueWt.Clear()
            txtUIssueFineWt.Clear()

            txtUWtOnScale.Clear()
            txtUcarbonReceive.Clear()

            txtUGrossLoss.Clear()
            txtUpdLossFine.Clear()

            btnUSave.Enabled = True
            btnUCancel.Enabled = True


            Fr_Mode = FormState.AStateMode

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
    Private Function UpdateValidate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbUpdBagtype.Text.Trim()) Or Convert.ToInt32(cmbUpdBagtype.SelectedIndex) = -1 Then
                MessageBox.Show("Select Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbUBagtype.Focus()
            ElseIf String.IsNullOrWhiteSpace(cmbUpdBagNo.Text.Trim()) Then
                MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbUpdBagNo.Focus()
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