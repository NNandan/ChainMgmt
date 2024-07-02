Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmBhukaBag
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

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
    Private Sub frmCBhukaBagvb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.fillBagType()
        Me.fillRecBagNo()
        Me.fillUpdBagNo()
        Me.FillUpdatedGridView()
    End Sub
    Private Sub fillBagType()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillBhukaBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        If tbBhukaBag.SelectedIndex = 0 Then

            Try
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

            End Try

        End If
    End Sub
    Private Sub tbBhukaBag_Click(sender As Object, e As EventArgs) Handles tbBhukaBag.Click
        If tbBhukaBag.SelectedIndex = 0 Then     ''for Create Bhuka Bag
            Me.fillBagType()
            Me.Clear_CForm()
        ElseIf tbBhukaBag.SelectedIndex = 1 Then ''for Receive Bhuka Bag
            Me.fillRecBagNo()
            Me.Clear_RForm()
        ElseIf tbBhukaBag.SelectedIndex = 2 Then ''for Update Bhuka Bag
            Me.fillUpdBagNo()
            Me.Clear_UForm()
        ElseIf tbBhukaBag.SelectedIndex = 3 Then ''for Grid Fill
            Me.FillUpdatedData()
        End If
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

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetBhukaData", DbType.String))
            .Add(dbManager.CreateParameter("@BId", (cmbCBagtype.SelectedValue), DbType.String))
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
    Private Function UpdateBhukaSrNo() As DataTable

        Dim Dt As DataTable = Nothing

        Dim alParaval As New ArrayList

        Dim BagId As Int16 = 0
        Dim TranId As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(cmbCBagtype.SelectedValue)

        If dgvCBhukaBag.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvCBhukaBag.Rows
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

                With Dparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateBhukaNo", DbType.String))
                    .Add(dbManager.CreateParameter("@BId", alParaval.Item(iValue), DbType.Int16))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@TId", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                    .Add(dbManager.CreateParameter("@BagType", "B", DbType.String))
                End With

                Dt = dbManager.GetDataTable("SP_UsedBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try

        End If

        Return Dt

    End Function


#End Region

#Region "ReceiveBhukaBag"
    Private Sub bindReceiveGridView()

        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetRecordByBhukaSrNo", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbRBagNo.Text.Trim), DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

            dgvRBhukaBag.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                dgvRBhukaBag.DataSource = dt
            End If

            Me.ReceiveGridViewTotal()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub bindReceiveListview(ByVal strBagNo As String)

        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetRecordByBhukaSrNo", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(strBagNo), DbType.String))
            End With

            dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

            dgvRBhukaBag.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                dgvRBhukaBag.DataSource = dt
            End If

            Me.ReceiveGridViewTotal()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub ReceiveGridViewTotal()
        Dim dSumOfGrossWt As Decimal = 0
        Dim dSumOfReceivePr As Decimal = 0
        Dim dSumOfFineWt As Decimal = 0

        Try
            For Each row As GridViewRowInfo In dgvRBhukaBag.Rows
                dSumOfGrossWt += CDec(Val(row.Cells(3).Value))
                dSumOfFineWt += CDec(Val(row.Cells(5).Value))
            Next

            dSumOfReceivePr = (dSumOfFineWt / dSumOfGrossWt) * 100

            txtRBagName.Text = cmbRBagNo.EditorControl.CurrentRow.Cells(1).Value.ToString()
            txtRIssueWt.Text = dSumOfGrossWt.ToString("N2")
            txtRIssuePr.Text = dSumOfReceivePr.ToString("N2")

            txtRWtOnScale.Focus()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region

#Region "UpdateBhukaBag"
    Private Sub bindUpdateListview()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
            .Add(dbManager.CreateParameter("@BId", cmbRBagNo.SelectedIndex, DbType.Int16))
            .Add(dbManager.CreateParameter("@BhukaSrNo", Trim(cmbRBagNo.SelectedItem.Text), DbType.String))
        End With

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
    Private Sub fetchUpdateBhukaBag(ByVal sBagNo As String, Optional sMode As String = Nothing)
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtUpdTransId.Text = dtData.Rows(0).Item("UsedBagId").ToString()
                UTransDt.Text = dtData.Rows(0).Item("UsedBagDt").ToString()
                cmbUpdBagNo.Text = dtData.Rows(0).Item("BagSrNo").ToString()
                txtUBagName.Text = dtData.Rows(0).Item("ItemName").ToString()
                txtUIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtUIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtUIssueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()
                txtUReceiveWt.Tag = dtData.Rows(0).Item("GrossReceive").ToString()
                txtUReceiveWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()
                txtUReceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
                txtUreceiveFineWt.Text = dtData.Rows(0).Item("ReceiveFineWt").ToString()
                txtUWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtUcarbonReceive.Text = dtData.Rows(0).Item("CarbonReceive").ToString()
            End If

            txtUReceivePr.Focus()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
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
#End Region
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click
        If Not ReceiveValidate_Fields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()

            If btnRSave.Text = "&Save" Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))

                    .Add(dbManager.CreateParameter("@UItemName", Convert.ToString(txtRBagName.Text.Trim), DbType.String))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value), DbType.String))

                    .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRIssueWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRIssuePr.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UReceiveWt", Val(txtRRecieveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonReceive", Val(txtRCarbon.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@ULossWt", Val(txtRGrossLoss.Text), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_UsedBags_Save", CommandType.StoredProcedure, parameters.ToArray())

                Dim tparameters = New List(Of SqlParameter)()

                With tparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateBhukaSt", DbType.String))

                    If btnRSave.Text = "&Save" Then
                        .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value), DbType.String))
                    Else
                        .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbRBagNo.Text.Trim()), DbType.String))
                    End If
                End With

                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, tparameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            End If

            If btnRSave.Text = "&Update" Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "EditData", DbType.String))

                    .Add(dbManager.CreateParameter("@UItemName", Convert.ToString(txtRBagName.Text.Trim), DbType.String))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.Text.Trim()), DbType.String))

                    .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRIssueWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRIssuePr.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UReceiveWt", Val(txtRRecieveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonReceive", Val(txtRCarbon.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@ULossWt", Val(txtRGrossLoss.Text), DbType.Decimal))

                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_UsedBags_Edit", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Update !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            Me.btnRCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        If Not UpdateValidate_Fields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()

            If btnUSave.Text = "&Save" Or btnUSave.Text = "&Update" Then

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                    .Add(dbManager.CreateParameter("@TId", Val(txtUpdTransId.Text.Trim()), DbType.Int16))
                    .Add(dbManager.CreateParameter("@ReportPr", Convert.ToDecimal(txtUReceivePr.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LossWt", Convert.ToDecimal(txtUpdLossFine.Text.Trim()), DbType.Decimal))

                    If btnUSave.Text = "&Save" Then
                        .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbUpdBagNo.EditorControl.CurrentRow.Cells(0).Value), DbType.String))
                    Else
                        .Add(dbManager.CreateParameter("@BagNo", Convert.ToString(cmbUpdBagNo.Text.Trim()), DbType.String))
                    End If
                End With

                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.btnUCancel_Click(sender, e)
                Me.FillUpdatedGridView()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If btnSave.Text = "&Save" Then
                If Not cmbCBagtype.Text.Trim = "" Then
                    Dim TmpLotNo As String = Nothing
                    Dim Dt As DataTable = Me.UpdateBhukaSrNo()
                    TmpLotNo = Dt.Rows(0).Item(0)
                    MessageBoxTimer(TmpLotNo)
                    Me.btnCancel_Click(sender, e)
                Else
                    MessageBox.Show("Please Select Bag Type")
                    Me.btnCancel_Click(sender, e)
                End If
            Else
                Try
                    If Not cmbCBagtype.Text.Trim = "" Then
                        If (MsgBox("Are You Sure To Update This Scrap Bag ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                            If dgvCBhukaBag.RowCount > 0 Then

                                Dim parameters = New List(Of SqlParameter)()

                                With parameters
                                    .Clear()
                                    .Add(dbManager.CreateParameter("@ActionType", "SetScrapBagNoToNULL", DbType.String))
                                    .Add(dbManager.CreateParameter("@BagSrNo", txtMaxNo.Text, DbType.String))
                                End With

                                dbManager.Delete("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

                                Me.UpdateSameScrapBag()
                                Me.fillBagType()
                                Me.fillRecBagNo()
                                Me.fillUpdBagNo()
                                btnSave.Text = "&Save"
                                Me.btnCancel_Click(sender, e)
                            End If
                        End If
                    Else
                        Me.btnCancel_Click(sender, e)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
                Me.fillRecBagNo()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UpdateSameScrapBag()
        Dim alParaval As New ArrayList
        Dim BagId As Int16 = 0
        Dim TranId As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(cmbCBagtype.Tag)

        If dgvCBhukaBag.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvCBhukaBag.Rows
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

                With Dparameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateSameBhukaNo", DbType.String))
                    .Add(dbManager.CreateParameter("@BId", alParaval.Item(iValue), DbType.Int16))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@TId", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                    .Add(dbManager.CreateParameter("@SameBagSrNo", txtMaxNo.Text.Trim, DbType.String))
                End With

                dbManager.Update("SP_UsedBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())

                MessageBox.Show("Scrap  Bag " + txtMaxNo.Text.Trim() + " Update Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_CForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_CForm()
        Try
            Me.RTransDt.CustomFormat = "dd/MM/yyyy"
            Me.RTransDt.Value = DateTime.Now

            cmbCBagtype.Enabled = True
            cmbCBagtype.SelectedIndex = 0

            lblMaxNo.Visible = False
            txtMaxNo.Visible = False

            lblBhukaTotal.Text = "0.00"
            lblReceivePrTotal.Text = "0.00"
            lblFineTotal.Text = "0.00"

            If btnSave.Text = "&Save" Then
                dgvCBhukaBag.DataSource = Nothing
            Else
                dgvCBhukaBag.RowCount = 0
                cmbCBagtype.Text = ""
            End If

            btnSave.Text = "&Save"
            btnREdit.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_RForm()
        Try
            Me.RTransDt.CustomFormat = "dd/MM/yyyy"
            Me.RTransDt.Value = DateTime.Now

            cmbRBagNo.Enabled = True
            cmbRBagNo.Text = ""
            txtRIssueWt.Clear()
            txtRIssuePr.Clear()
            txtRBagName.Clear()
            txtRWtOnScale.Clear()
            txtRRecieveWt.Clear()

            txtRSample.Clear()
            txtRTotalWt.Clear()

            txtRCarbon.Clear()
            txtRGrossLoss.Clear()
            txtRBagName.Clear()

            dgvRBhukaBag.DataSource = Nothing

            btnRSave.Text = "&Save"
            btnREdit.Enabled = True

            Me.fillRecBagNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_UForm()
        Try
            Me.UTransDt.CustomFormat = "dd/MM/yyyy"
            Me.UTransDt.Value = DateTime.Now

            cmbUpdBagNo.Enabled = True
            cmbUpdBagNo.SelectedIndex = 0

            txtUBagName.Clear()
            txtUReceivePr.Clear()
            txtUReceiveWt.Clear()
            txtUreceiveFineWt.Clear()
            txtUGrossLoss.Clear()
            txtUpdLossFine.Clear()
            txtUIssuePr.Clear()
            txtUIssueWt.Clear()
            txtUIssueFineWt.Clear()
            txtUWtOnScale.Clear()
            txtUcarbonReceive.Clear()
            txtUGrossLoss.Text = ""
            txtUpdLossFine.Text = ""

            btnUSave.Text = "&Save"
            btnUpdEdit.Enabled = True

            fillUpdBagNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Try
            Call Clear_RForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Try
            Call Clear_UForm()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub txtRTotalWt_TextChanged(sender As Object, e As EventArgs) Handles txtRTotalWt.TextChanged
        Try
            txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRTotalWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceivePr_Leave(sender As Object, e As EventArgs) Handles txtUReceivePr.Leave
        txtUReceivePr.Text = Format(Val(txtUReceivePr.Text), "0.00")
    End Sub
    Private Sub txtUreceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtUReceivePr.TextChanged
        Try
            txtUreceiveFineWt.Text = Format((Val(txtUReceiveWt.Text) * Val(txtUReceivePr.Text)) / 100, "0.00")
            txtUpdLossFine.Text = Format(Val(txtUIssueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
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
    Private Sub txtUreceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtUReceiveWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUIssueWt.Text) - Val(txtUReceiveWt.Tag), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnREdit_Click(sender As Object, e As EventArgs) Handles btnREdit.Click
        If cmbRBagNo.Text = "" Then
            MessageBox.Show("Please Select Bag To Edit")
        Else
            If btnREdit.Text = "&Edit" Then
                If dgvRBhukaBag.Rows.Count <= 0 And cmbRBagNo.SelectedIndex <= 0 Then
                    MessageBox.Show("Please Select Bag No To Edit Records")
                Else
                    lblMaxNo.Visible = True
                    txtMaxNo.Visible = True
                    btnSave.Text = "&Update"

                    Dim dttable As New DataTable

                    dttable = fetchItemId(CStr(cmbRBagNo.Text.Trim))

                    If dttable.Rows.Count > 0 Then
                        cmbCBagtype.Tag = dttable.Rows(0).Item("ItemId").ToString()
                        cmbCBagtype.Text = dttable.Rows(0).Item("ItemName").ToString()
                        txtMaxNo.Text = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value
                    End If

                    Me.FillGridR(cmbRBagNo.Text.Trim)
                    Me.btnRCancel_Click(sender, e)
                    Me.btnUCancel_Click(sender, e)
                    tbBhukaBag.SelectedIndex = 0
                End If
            Else
                Me.UpdateReceiveData()

                Me.btnUCancel_Click(sender, e)

                btnREdit.Text = "&Edit"
                btnRSave.Enabled = True

                Me.btnRCancel_Click(sender, e)
                Me.btnUCancel_Click(sender, e)

                Me.fillRecBagNo()
                Me.fillUpdBagNo()
            End If
        End If
    End Sub
    Private Function fetchItemId(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetItemId", DbType.String))
                .Add(dbManager.CreateParameter("@ItemName", cmbRBagNo.EditorControl.CurrentRow.Cells(1).Value, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ScrapBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function

    'Public Function GetItemId(ByVal sItemName As String) As Integer
    '    Dim connection As EntityConnection = CType(connection, EntityConnection)
    '    Dim com As DbCommand = connection.StoreConnection.CreateCommand()
    '    com.CommandText = "select dbo.fn_GetUserId_Username(@Username)"
    '    com.CommandType = CommandType.Text
    '    com.Parameters.Add(New SqlParameter("@Username", UserName))
    '    If com.Connection.State = ConnectionState.Closed Then com.Connection.Open()

    '    Try
    '        Dim result = com.ExecuteScalar()
    '        Return CInt(result)
    '    Catch e As Exception
    '    End Try
    'End Function
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        If lblMaxNo.Visible = False And txtMaxNo.Visible = False And btnSave.Text = "&Save" Then
            With dgvCBhukaBag
                .Rows.Remove(.CurrentRow)
            End With
        Else
            If (MsgBox("Are You Sure To Delete This ScrapBag ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                Try
                    If dgvCBhukaBag.RowCount > 0 Then
                        Dim parameters = New List(Of SqlParameter)()

                        With parameters
                            .Clear()
                            .Add(dbManager.CreateParameter("@ActionType", "DeleteBhukaBagSrNo", DbType.String))
                            .Add(dbManager.CreateParameter("@BagSrNo", txtMaxNo.Text, DbType.String))
                        End With

                        dbManager.Delete("SP_Transaction_Delete", CommandType.StoredProcedure, parameters.ToArray())

                        MessageBox.Show("Vaccume Bag Delete Succesfully..!!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        lblMaxNo.Visible = False
                        txtMaxNo.Visible = False
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        End If

    End Sub
    Private Sub FillGridU(ByVal sUBagNo As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetailsRUpdate(CStr(sUBagNo))
        dgvRBhukaBag.DataSource = Nothing
        dgvRBhukaBag.DataSource = dttable
        Me.ReceiveTotal()
        Me.FetchUsedBagsDetails(sUBagNo)
        Me.GetSrNo(dgvRBhukaBag)
    End Sub
    Private Sub txtUIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtUIssueWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUIssueWt.Text) - Val(txtUReceiveWt.Tag), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function ReceiveValidate_Fields() As Boolean
        Try
            If String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Then
                MessageBox.Show("Select Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagNo.Focus()
                Return False
            ElseIf Val(txtRWtOnScale.Text) <= 0 Then
                MessageBox.Show("Enter Wt. On Scale !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRWtOnScale.Focus()
                Return False
            ElseIf Val(txtRRecieveWt.Text) <= 0 Then
                MessageBox.Show("Enter Lagdi Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRRecieveWt.Focus()
                Return False
            ElseIf Val(txtRSample.Text) <= 0 Then
                MessageBox.Show("Enter Sample Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtRSample.Focus()
                Return False
            ElseIf Val(txtRCarbon.Text) <= 0 Then
                MessageBox.Show("Enter Carbon Received !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
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
            If String.IsNullOrWhiteSpace(cmbUpdBagNo.Text.Trim()) Then
                MessageBox.Show("Select Bag Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbUpdBagNo.Focus()
            ElseIf Val(txtUReceivePr.Text) <= 0 Then
                MessageBox.Show("Enter Receive % !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtUReceivePr.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub FillGridR(ByVal sRBagNo As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetails(CStr(sRBagNo))

        If dttable.Rows.Count > 0 Then
            txtMaxNo.Text = dttable.Rows(0).Item("BhukaBagNo").ToString()
            cmbCBagtype.Enabled = False
        End If

        FetchGridData(CStr(sRBagNo))
    End Sub
    Private Sub FetchGridData(ByVal sBagNo As String)
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchScrapGridData", DbType.String))
            .Add(dbManager.CreateParameter("@BId", Val(cmbCBagtype.Tag), DbType.Int16))
            .Add(dbManager.CreateParameter("@BagSrNo", sBagNo, DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try
            If Me.btnSave.Text = "&Update" Then
                dgvCBhukaBag.RowCount = 0
            End If

            For Each ROW As DataRow In dt.Rows
                dgvCBhukaBag.Rows.Add(Convert.ToBoolean(ROW("lotNoBoolean")), CStr(ROW("TransDt")), CStr(ROW("OperationName")), CStr(ROW("LotNo")), Format(Val(ROW("BhukaWt")), "0.00"), Format(Val(ROW("ReceivePr")), "0.00"), Format(Val(ROW("FineWt")), "0.00"), CStr(ROW("TransId")), 0)
            Next

            With dgvCBhukaBag
                .EnableFiltering = True
                .MasterTemplate.ShowFilteringRow = False
                .MasterTemplate.ShowHeaderCellButtons = True
            End With

            Me.CalculateTotal()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub fillRecBagNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillRScrapCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_ScrapBags_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            'Assign DataTable as DataSource.
            cmbRBagNo.DataSource = dt
            cmbRBagNo.AutoFilter = True
            cmbRBagNo.DisplayMember = "BagSrNo"
            cmbRBagNo.ValueMember = "BagSrNo"
            cmbRBagNo.Text = ""
            cmbRBagNo.Refresh()

            cmbRBagNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbRBagNo.BestFitColumns(True, False)

            cmbRBagNo.Columns(0).IsVisible = True
            cmbRBagNo.Columns(1).Width = 200
            cmbRBagNo.Columns(1).TextAlignment = ContentAlignment.MiddleLeft

            Me.cmbRBagNo.MultiColumnComboBoxElement.DropDownWidth = 250
            Me.BackColor = Color.White
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRBagNo.SelectedIndexChanged
        If cmbRBagNo.SelectedIndex = -1 Then
            With dgvRBhukaBag
                dgvRBhukaBag.DataSource = Nothing
            End With
        ElseIf cmbRBagNo.SelectedIndex > 0 Then
            Me.bindReceiveGridView()
            Me.DisableBtn()
        End If
    End Sub
    Private Sub fillUpdBagNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "fillUBhukaBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            ''Assign DataTable as DataSource.
            cmbUpdBagNo.DataSource = dt
            cmbUpdBagNo.AutoFilter = True
            cmbUpdBagNo.DisplayMember = "BagSrNo"
            cmbUpdBagNo.ValueMember = "BagSrNo"
            cmbUpdBagNo.Text = ""
            cmbUpdBagNo.Refresh()

            cmbUpdBagNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbUpdBagNo.BestFitColumns(True, False)

            cmbUpdBagNo.Columns(0).IsVisible = True
            cmbUpdBagNo.Columns(1).Width = 125
            cmbUpdBagNo.Columns(1).TextAlignment = ContentAlignment.MiddleLeft

            Me.cmbUpdBagNo.MultiColumnComboBoxElement.DropDownWidth = 250
            Me.BackColor = Color.White
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Function fetchAllDetailsRUpdate(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FillRScrapDetails", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Trim(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ScrapBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub dgvFinalUpdate_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles MasterTemplate.CellDoubleClick, dgvFinalUpdate.CellDoubleClick
        If dgvFinalUpdate.Rows.Count > 0 Then
            Dim sScrapBagNo As String = dgvFinalUpdate.Rows(e.RowIndex).Cells(2).Value.ToString()

            Me.btnUCancel_Click(sender, e)
            fetchUpdateBhukaBag(sScrapBagNo)

            btnUSave.Text = "&Update"
            btnUpdEdit.Enabled = False

            cmbUpdBagNo.Enabled = False

            tbBhukaBag.SelectedIndex = 2
        End If
    End Sub
    Private Sub fillDetailsFromListView(ByVal UsedDetailsId As Integer)
        Dim dttable As New DataTable

        dttable = fetchAllDetailsById(CInt(UsedDetailsId))

        If dttable.Rows.Count > 0 Then
            cmbUpdBagNo.Text = dttable.Rows(0).Item("BagSrNo").ToString()
            txtUBagName.Text = dttable.Rows(0).Item("BagName").ToString()
            txtUpdTransId.Text = dttable.Rows(0).Item("UsedBagId").ToString()
            UTransDt.Text = dttable.Rows(0).Item("UsedBagDt").ToString()
            txtUIssueWt.Text = dttable.Rows(0).Item("IssueWt").ToString()
            txtUIssuePr.Text = dttable.Rows(0).Item("IssuePr").ToString()
            txtUIssueFineWt.Text = dttable.Rows(0).Item("IssueFineWt").ToString()
            txtUReceiveWt.Tag = dttable.Rows(0).Item("GrossReceive").ToString()
            txtUReceiveWt.Text = dttable.Rows(0).Item("ReceiveWt").ToString()
            txtUReceivePr.Text = dttable.Rows(0).Item("ReportPr").ToString()
            txtUreceiveFineWt.Text = dttable.Rows(0).Item("ReceiveFineWt").ToString()
            txtUWtOnScale.Text = dttable.Rows(0).Item("WtOnScale").ToString()
            txtUcarbonReceive.Text = dttable.Rows(0).Item("CarbonReceive").ToString()
        End If

        dgvFinalUpdate.ReadOnly = True
        tbBhukaBag.SelectedIndex = 2
    End Sub
    Sub ReceiveTotal()

        Dim dReceiveWTotal As Double = 0
        Dim dReceivePTotal As Double = 0
        Dim dReceiveFTotal As Double = 0

        Try

            For Each row As GridViewRowInfo In dgvRBhukaBag.Rows
                dReceiveWTotal += Double.Parse(row.Cells(3).Value)
                dReceiveFTotal += Double.Parse(row.Cells(5).Value)
            Next

            dReceivePTotal = Format((Val(dReceiveFTotal) / Val(dReceiveWTotal)) * 100, "0.00")

            If dReceivePTotal > 0 Then
                txtRIssueWt.Text = Format(dReceiveWTotal, "0.00")
                txtRIssuePr.Text = Format(dReceivePTotal, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function fetchAllDetailsById(ByVal UsedDetailsId As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchUpdatedBagDataById", DbType.String))
                .Add(dbManager.CreateParameter("@BId", CInt(UsedDetailsId), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub FetchUsedBagsDetails(ByVal sBagNo As String)
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchReceivedScrap", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", sBagNo, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtRBagName.Text = dtData.Rows(0).Item("BagName").ToString()
                txtRIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtRIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtRWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtRRecieveWt.Text = dtData.Rows(0).Item("ReceiveWt").ToString()
                txtRSample.Text = dtData.Rows(0).Item("TFSampleWt").ToString()
                txtRCarbon.Text = dtData.Rows(0).Item("CarbonReceive").ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvCBhukaBag.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function fetchAllDetails(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "ScrapHeaderSelect", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Trim(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub UpdateReceiveData()
        Try
            Dim parameters = New List(Of SqlParameter)()

            If btnREdit.Text = "&Update" Then

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateRScrapBagData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UReceiveWt", Val(txtRRecieveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonReceive", Val(txtRCarbon.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Update("SP_UsedBags_Update", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Scrap Bag Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Sub MessageBoxTimer(ByVal strMsg As String)
        Dim AckTime As Integer, InfoBox As Object
        InfoBox = CreateObject("WScript.Shell")
        'Set the message box to close after 1 seconds
        AckTime = 1
        Select Case InfoBox.Popup("Click OK (Chain Saved Successfully With New Lot Number = " & strMsg.ToString(),
        AckTime, "Newly Created Lot Number", 0)
            Case 1, -1
                Exit Sub
        End Select
    End Sub
    Private Sub cmbUpdBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUpdBagNo.SelectedIndexChanged
        If cmbUpdBagNo.SelectedIndex > 0 Then
            Me.fetchUpdateBhukaBag(cmbUpdBagNo.Text.Trim)
        End If
    End Sub
    Private Sub btnUpdEdit_Click(sender As Object, e As EventArgs) Handles btnUpdEdit.Click
        If cmbUpdBagNo.SelectedIndex <= 0 Then
            MessageBox.Show("Please Select Bag No To Edit Records")
        Else
            cmbRBagNo.Text = Me.cmbUpdBagNo.EditorControl.CurrentRow.Cells(0).Value
            cmbRBagNo.Enabled = False

            btnREdit.Enabled = False
            btnRSave.Text = "&Update"

            Me.bindReceiveGridView()
            Me.GetSrNo(dgvRBhukaBag)
            Me.FetchUsedBagsDetails(cmbRBagNo.Text.Trim)

            tbBhukaBag.SelectedIndex = 1
        End If
    End Sub
    Private Sub FillUpdatedGridView()
        Dim dtdata As DataTable = fetchAllDetails()

        Try
            dgvFinalUpdate.DataSource = dtdata
            dgvFinalUpdate.EnableFiltering = True
            dgvFinalUpdate.MasterTemplate.ShowFilteringRow = False
            dgvFinalUpdate.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Function fetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchBUsedUBagData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub txtRWtOnScale_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRWtOnScale.KeyPress
        numdotkeypress(e, txtRWtOnScale, Me)
    End Sub
    Private Sub txtRRecieveWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRRecieveWt.KeyPress
        numdotkeypress(e, txtRRecieveWt, Me)
    End Sub
    Private Sub txtRSample_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRSample.KeyPress
        numdotkeypress(e, txtRSample, Me)
    End Sub
    Private Sub txtRCarbon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRCarbon.KeyPress
        numdotkeypress(e, txtRCarbon, Me)
    End Sub

    Private Sub txtRGrossLoss_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRGrossLoss.KeyDown
        If e.KeyCode = Keys.Tab Then
            btnSave.Focus()
        End If
    End Sub
    Private Sub txtUReceivePr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUReceivePr.KeyDown
        If e.KeyCode = Keys.Tab Then
            btnUSave.Focus()
        End If
    End Sub
    Private Sub txtUReceivePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUReceivePr.KeyPress
        numdotkeypress(e, txtUReceivePr, Me)
    End Sub
    Private Sub DisableBtn()
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub FillUpdatedData()
        Dim dtable As DataTable = fetchAllDetails()

        For i As Integer = 0 To dtable.Rows.Count - 1
            If dtable.Rows.Count > 0 Then
                dgvFinalUpdate.DataSource = dtable
                dgvFinalUpdate.ReadOnly = True
            Else
                MessageBox.Show("Data Not Available To Update")
            End If
        Next
    End Sub
End Class