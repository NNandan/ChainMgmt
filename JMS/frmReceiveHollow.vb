Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmReceiveHollow
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim GridDoubleClick As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim iItemId As Int16 = 0
    Dim iOpTypeId As Int16 = 0

    Dim dblGoldIssued As Double = 0
    Dim dblCoreIssu As Double = 0
    Dim dblCoreRece As Double = 0
    Dim dblCoreRemain As Double = 0

    Dim dblTotalSum As Double = 0

    Dim dSkinPr As Double = 75.1
    Private Property Fr_Mode() As FormState
        Get
            Return mFr_State
        End Get
        Set(ByVal value As FormState)
            mFr_State = value
            Select Case mFr_State
                Case FormState.AStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "&New"
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "&Save"
                    Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "&Edit"
                    Me.btnSave.Text = "&Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub frmReceiveHollow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLabour()
        Me.fillLotNo()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

        Try
            If Fr_Mode = FormState.AStateMode Then
                Me.SaveData()
                Me.btnCancel_Click(sender, e)
            Else
                Me.UpdateData()
                Me.btnCancel_Click(sender, e)
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.SelectedIndex > -1 Then
            bindReceiveHeaderView()
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub fillLabour()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillLabour", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = dt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            dt.Rows.InsertAt(trow, 0)

            cmbtKarigar.DataSource = dt
            cmbtKarigar.DisplayMember = "LabourName"
            cmbtKarigar.ValueMember = "LabourId"

            cmbtKarigar.AutoCompleteMode = AutoCompleteMode.SuggestAppend ' This is necessary
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillLotNo()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_HollowReceive_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbLotNo.DataSource = dt
            cmbLotNo.DisplayMember = "LotNo"
            cmbLotNo.ValueMember = "HollowIssueId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub txtSample_TextChanged(sender As Object, e As EventArgs) Handles txtSample.TextChanged
        Try
            txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text), "0.00")

            dblCoreRece = Format(Val(dblTotalSum) - Val(txtTotal.Text), "0.00")

            'If Not String.IsNullOrEmpty(txtReceivePr.Text) Then
            '    txtReceiveFine.Text = Format(Val(txtReceiveTotalGross.Text) * Val(txtReceivePr.Text) / 100, "0.00")
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtChain_TextChanged(sender As Object, e As EventArgs) Handles txtChain.TextChanged
        Try
            txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text), "0.00")

            dblCoreRece = Format(Val(dblTotalSum) - Val(txtTotal.Text), "0.00")

            'If Not String.IsNullOrEmpty(txtReceivePr.Text) Then
            '    txtReceiveFine.Text = Format(Val(txtReceiveTotalGross.Text) * Val(txtReceivePr.Text) / 100, "0.00")
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtBhuka_TextChanged(sender As Object, e As EventArgs) Handles txtBhuka.TextChanged
        Try
            txtTotal.Text = Format(Val(txtChain.Text) + Val(txtBhuka.Text) + Val(txtSample.Text), "0.00")

            dblCoreRece = Format(Val(dblTotalSum) - Val(txtTotal.Text), "0.00")

            'If Not String.IsNullOrEmpty(txtReceivePr.Text) Then
            '    txtReceiveFine.Text = Format(Val(txtReceiveTotalGross.Text) * Val(txtReceivePr.Text) / 100, "0.00")
            'End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub bindReceiveHeaderView()
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoDetails", DbType.String))
                .Add(dbManager.CreateParameter("@HollowNo", Convert.ToString(cmbLotNo.Text.Trim), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_HollowReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

            txtTransNo.Text = dtData.Rows(0).Item(0)
            TransDt.Text = dtData.Rows(0).Item(1)
            iOpTypeId = dtData.Rows(0).Item(2)
            txtLotNo.Text = dtData.Rows(0).Item(3)
            txtCoreAddNo.Text = dtData.Rows(0).Item(4)
            iItemId = dtData.Rows(0).Item(5)
            txtIssueWt.Text = dtData.Rows(0).Item(7)
            txtIssuePr.Text = dtData.Rows(0).Item(8)
            txtIssueFw.Text = dtData.Rows(0).Item(9)
            txtFrKarigar.Tag = dtData.Rows(0).Item(10)
            txtFrKarigar.Text = dtData.Rows(0).Item(11)
            cmbtKarigar.Tag = dtData.Rows(0).Item(12)
            cmbtKarigar.Text = dtData.Rows(0).Item(13)

            SumOfGoldIssued()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub SaveData()
        Dim iOperationTypeId As Integer = 15 ''Operation Id for Hollow Issue

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                .Add(dbManager.CreateParameter("@HollowIssueDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@HOperationTypeId", iOperationTypeId, DbType.Int16))
                '.Add(dbManager.CreateParameter("@HItemType", cmbItemType.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@HSlipBagNo", cmbLotNo.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@HCoreAddNo", txtCoreAddNo.Text.Trim, DbType.String))
                '.Add(dbManager.CreateParameter("@HItemBagId", txtItemName.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIssueWt", txtIssueWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@HIssuePr", txtIssuePr.Text, DbType.String))
                .Add(dbManager.CreateParameter("@HFineWt", txtIssueFw.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@HFrKarigar", txtFrKarigar.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@HToKarigar", cmbtKarigar.SelectedValue, DbType.String))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_HollowReceive_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtChain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChain.KeyPress
        numdotkeypress(e, txtChain, Me)
    End Sub
    Private Sub txtBhuka_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBhuka.KeyPress
        numdotkeypress(e, txtBhuka, Me)
    End Sub
    Private Sub txtSample_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSample.KeyPress
        numdotkeypress(e, txtSample, Me)
    End Sub
    Private Sub SumOfGoldIssued()
        Try
            dblGoldIssued = Format((CDbl(txtIssueFw.Text) / CDbl(dSkinPr)) * 100, "0.00")
            txtTgtGoldWt.Text = dblGoldIssued

            dblCoreIssu = Format(CDbl(txtIssueWt.Text) - CDbl(dblGoldIssued), "0.00")

            dblTotalSum = Format(CDbl(dblGoldIssued) + CDbl(dblCoreIssu), "0.00")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SumOfGoldIssueMinusTotalRec()
        Dim dblLoss As Double = 0

        Try
            dblCoreRemain = Format(CDbl(dblTotalSum) - CDbl(txtTotal.Text), "0.00")
            dblLoss = dblCoreIssu - dblCoreRemain

            If (dblLoss < 0) Then
                txtCoreRemains.Text = Format(0.00, "0.00")
                txtLoss.Text = Format(dblLoss, "0.00")
            Else
                txtLoss.Text = Format(0.00, "0.00")
                txtCoreRemains.Text = Format(dblLoss, "0.00")
            End If

        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtSample_LostFocus(sender As Object, e As EventArgs) Handles txtSample.LostFocus
        Try
            SumOfGoldIssueMinusTotalRec()

        Catch ex As Exception

        End Try
    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If Val(txtChain.Text) <= 0 Then
                MessageBox.Show("Enter Chain Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtChain.Focus()
                Return False
            ElseIf Val(txtBhuka.Text) <= 0 Then
                MessageBox.Show("Enter Bhuka Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtBhuka.Focus()
                Return False
            ElseIf Val(txtSample.Text) <= 0 Then
                MessageBox.Show("Enter Sample Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtSample.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub Clear_Form()
        Try
            txtTransNo.Tag = ""
            txtTransNo.Clear()

            TransDt.Value = DateTime.Now

            cmbLotNo.SelectedIndex = -1
            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()

            cmbtKarigar.SelectedIndex = -1

            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()

            txtCoreAddNo.Clear()
            txtLotNo.Clear()

            txtChain.Clear()
            txtBhuka.Clear()
            txtSample.Clear()
            txtTotal.Clear()

            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtIssueFw.Clear()

            txtLoss.Clear()
            txtMeltingPr.Clear()

            txtTgtGoldWt.Clear()
            txtCoreRemains.Clear()

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub UpdateData()

        Dim iOperationTypeId As Integer = 15 ''Operation Id for Core Addition Issue

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            'With parameters
            '    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
            '    .Add(dbManager.CreateParameter("@CoreRemovalDt", TransDt.Value.ToString(), DbType.DateTime))
            '    .Add(dbManager.CreateParameter("@ItemId", Val(txtTransNo.Tag), DbType.Int16))
            '    .Add(dbManager.CreateParameter("@OperationTypeId", iOperationTypeId, DbType.Int16))
            '    .Add(dbManager.CreateParameter("@IssueWt", txtIssueWeight.Text.Trim(), DbType.String))
            '    .Add(dbManager.CreateParameter("@IssuePr", txtIssuePercent.Text.Trim(), DbType.String))
            '    .Add(dbManager.CreateParameter("@ReceiveWt", txtChainReceiveWt.Text.Trim(), DbType.String))
            '    .Add(dbManager.CreateParameter("@ReceivePr", txtReceivePr.Text.Trim(), DbType.String))
            '    .Add(dbManager.CreateParameter("@LotNumber", cmbLotNo.SelectedItem.ToString(), DbType.String))
            '    .Add(dbManager.CreateParameter("@MeltingPr", txtMeltingPr.Text.Trim, DbType.String))
            '    .Add(dbManager.CreateParameter("@BhukaWt", txtBhukaReceiveWt.Text.Trim(), DbType.String))
            '    .Add(dbManager.CreateParameter("@SampleWt", txtSampleReceiveWt.Text.Trim(), DbType.String))
            '    .Add(dbManager.CreateParameter("@CoreRemainsWt", txtCoreRemains.Text.Trim(), DbType.String))
            '    .Add(dbManager.CreateParameter("@LossWt", txtLossWt.Text.Trim(), DbType.String))
            '    .Add(dbManager.CreateParameter("@FrKarigar", txtFrKarigar.Tag.Trim(), DbType.Int16))
            '    .Add(dbManager.CreateParameter("@ToKarigar", cmbTLabour.SelectedIndex, DbType.String))
            '    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
            'End With

            dbManager.Insert("SP_CoreAdditionRemoval_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
End Class