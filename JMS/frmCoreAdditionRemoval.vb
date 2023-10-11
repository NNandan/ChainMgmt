Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmCoreAdditionRemoval
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
                    CType(Me.ParentForm, frmMain).FormMode.Text = "New"
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "Save"
                    Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit"
                    Me.btnSave.Text = "Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub frmCoreAdditionRemoval_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()

        Me.fillLabour()
        Me.fillLotNo()
    End Sub
    Private Sub fillLabour()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            parameters.Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
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

            cmbTLabour.DataSource = dt
            cmbTLabour.DisplayMember = "LabourName"
            cmbTLabour.ValueMember = "LabourId"

            cmbTLabour.AutoCompleteMode = AutoCompleteMode.SuggestAppend ' This is necessary
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillLotNo()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_CoreAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)

        Try
            While dr.Read
                cmbLotNo.Items.Add(dr(0).ToString())
            End While

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub txtIssueWeight_TextChanged(sender As Object, e As EventArgs) Handles txtIssueWeight.TextChanged
        Try
            txtIssueFine.Text = Format((Val(txtIssueWeight.Text) * Val(txtIssuePercent.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtIssuePercent_TextChanged(sender As Object, e As EventArgs) Handles txtIssuePercent.TextChanged
        Try
            txtIssueFine.Text = Format((Val(txtIssueWeight.Text) * Val(txtIssuePercent.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceivePercent_TextChanged(sender As Object, e As EventArgs) Handles txtReceivePr.TextChanged
        Try
            txtReceiveFine.Text = Format((Val(txtChainReceiveWt.Text) * Val(txtReceivePr.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceiveBhukaPercent_TextChanged(sender As Object, e As EventArgs) Handles txtReceiveBhukaPr.TextChanged
        Try
            txtReceiveBhukaFine.Text = Format((Val(txtBhukaReceiveWt.Text) * Val(txtReceiveBhukaPr.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveData()

        Dim iOperationTypeId As Integer = 15 ''Operation Id for Core Addition Issue

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                .Add(dbManager.CreateParameter("@CoreRemovalDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@ItemId", Val(txtTransNo.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@OperationTypeId", iOperationTypeId, DbType.Int16))
                .Add(dbManager.CreateParameter("@IssueWt", txtIssueWeight.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@IssuePr", txtIssuePercent.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@ReceiveWt", txtChainReceiveWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@ReceivePr", txtReceivePr.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@LotNumber", cmbLotNo.SelectedItem.ToString(), DbType.String))
                .Add(dbManager.CreateParameter("@MeltingPr", txtMeltingPr.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@BhukaWt", txtBhukaReceiveWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@SampleWt", txtSampleReceiveWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@CoreRemainsWt", txtCoreRemains.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@LossWt", txtLossWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@FrKarigar", txtFrKarigar.Tag.Trim(), DbType.Int16))
                .Add(dbManager.CreateParameter("@ToKarigar", cmbTLabour.SelectedIndex, DbType.String))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_CoreAdditionRemoval_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not Validate_Fields() Then Exit Sub

        Try
            If Fr_Mode = FormState.AStateMode Then
                Me.SaveData()
                Me.btnCancel_Click(sender, e)
            Else

            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub getLastLotNoAmt()
        Dim connection As SqlConnection = Nothing

        strSQL = Nothing
        strSQL = "SELECT * FROM udf_GetMaxLotTransNo('" & cmbLotNo.Text.Trim() & "') ORDER BY MaxTransId"

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim(), DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader(strSQL, CommandType.Text, Objcn, parameters.ToArray())

        Try
            If dr.Read = False Then
                Exit Sub
            Else
                txtTransNo.Tag = Val(dr.Item("ItemId"))
                txtIssueWeight.Text = Format(Val(dr.Item("ReceiveWt")), "0.000")
                txtIssuePercent.Text = Format(Val(dr.Item("ReceivePr")), "0.000")
                txtFrKarigar.Tag = dr.Item("ToLabourId").ToString()
                txtFrKarigar.Text = dr.Item("toKarigarName").ToString()
                cmbTLabour.SelectedIndex = dr("FrLabourId").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try

    End Sub
    Private Function GetLotNoInLotTransfer() As String
        Dim strReceiveNo As String = String.Empty

        Dim dtData As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "CheckLotNo", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", cmbLotNo.Text.Trim(), DbType.String))
        End With

        strReceiveNo = Convert.ToString(dbManager.GetScalarValue("SP_CoreAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray()))

        If Not String.IsNullOrWhiteSpace(strReceiveNo) Then
            Dim lparameters = New List(Of SqlParameter)()
            lparameters.Clear()

            With lparameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoWisePr", DbType.String))
                .Add(dbManager.CreateParameter("@MLotNo", strReceiveNo, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Melting_Select", CommandType.StoredProcedure, lparameters.ToArray())

            txtMeltingPr.Clear()
            GetLotNoInLotTransfer = Convert.ToString(dtData.Rows(0).Item("RequirePr"))
        Else
            Dim mparameters = New List(Of SqlParameter)()
            mparameters.Clear()

            With mparameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoWisePr", DbType.String))
                .Add(dbManager.CreateParameter("@MLotNo", cmbLotNo.Text.Trim(), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Melting_Select", CommandType.StoredProcedure, mparameters.ToArray())

            txtMeltingPr.Clear()
            GetLotNoInLotTransfer = Convert.ToString(dtData.Rows(0).Item("RequirePr"))
        End If

    End Function
    Private Sub frmCoreAdditionRemoval_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
                e.Handled = True
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                ' When Alt + S is pressed, the Click event for the print
                ' button is raised.
                btnSave().PerformClick()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtChainReceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtChainReceiveWt.TextChanged
        Try
            txtReceiveTotalGross.Text = Format(Val(txtChainReceiveWt.Text) + Val(txtBhukaReceiveWt.Text) + Val(txtSampleReceiveWt.Text), "0.00")

            If Not String.IsNullOrEmpty(txtReceivePr.Text) Then
                txtReceiveFine.Text = Format(Val(txtReceiveTotalGross.Text) * Val(txtReceivePr.Text) / 100, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtBhukaReceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtBhukaReceiveWt.TextChanged
        Try
            txtReceiveTotalGross.Text = Format(Val(txtChainReceiveWt.Text) + Val(txtBhukaReceiveWt.Text) + Val(txtSampleReceiveWt.Text), "0.00")

            If Not String.IsNullOrEmpty(txtReceiveBhukaPr.Text) Then
                txtReceiveBhukaFine.Text = Format(Val(txtBhukaReceiveWt.Text) * Val(txtReceiveBhukaPr.Text) / 100, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtSampleReceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtSampleReceiveWt.TextChanged
        Try
            txtReceiveTotalGross.Text = Format(Val(txtChainReceiveWt.Text) + Val(txtBhukaReceiveWt.Text) + Val(txtSampleReceiveWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceiveTotalGross_TextChanged(sender As Object, e As EventArgs) Handles txtReceiveTotalGross.TextChanged
        Dim decCoreRemains As Double = 0
        Dim decLossWt As Double = 0

        Try
            txtReceiveTotalPr.Text = Format(Val(txtReceiveTotalFine.Text) / Val(txtReceiveTotalGross.Text) * 100, "0.00")

            txtReceiveSamplePr.Text = Format(Val(txtReceiveTotalPr.Text), "0.00")
            txtReceiveBhukaPr.Text = Format(Val(txtReceiveTotalPr.Text), "0.00")
            txtReceivePr.Text = Format(Val(txtReceiveTotalPr.Text), "0.00")

            txtCoreRemains.Text = Format((Val(txtReceiveTotalGross.Text) - Val(txtTargetGoldWeight.Text)), "0.00")

            If Decimal.TryParse(txtCoreRemains.Text, decCoreRemains) Then
                If decCoreRemains <= 0 Then
                    txtCoreRemains.Text = Format(0.00, "0.00")
                End If
            End If

            txtLossWt.Text = Format((Val(txtTargetGoldWeight.Text) - Val(txtReceiveTotalGross.Text)), "0.00")

            If Decimal.TryParse(txtLossWt.Text, decLossWt) Then
                If decLossWt <= 0 Then
                    txtLossWt.Text = Format(0.00, "0.00")
                End If
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtSampleReceiveWt_Leave(sender As Object, e As EventArgs) Handles txtSampleReceiveWt.Leave
        txtSampleReceiveWt.Text = Format(Val(txtSampleReceiveWt.Text), "0.00")
    End Sub
    Private Sub txtBhukaReceiveWt_Leave(sender As Object, e As EventArgs) Handles txtBhukaReceiveWt.Leave
        txtBhukaReceiveWt.Text = Format(Val(txtBhukaReceiveWt.Text), "0.00")
    End Sub
    Private Sub txtChainReceiveWt_Leave(sender As Object, e As EventArgs) Handles txtChainReceiveWt.Leave
        txtChainReceiveWt.Text = Format(Val(txtChainReceiveWt.Text), "0.00")
    End Sub
    Private Sub txtIssueFine_TextChanged(sender As Object, e As EventArgs) Handles txtIssueFine.TextChanged
        txtReceiveTotalFine.Text = Format(Val(txtIssueFine.Text), "0.00")
    End Sub
    Private Sub txtReceiveSamplePr_TextChanged(sender As Object, e As EventArgs) Handles txtReceiveSamplePr.TextChanged
        Try
            txtReceiveSampleFine.Text = Format((Val(txtSampleReceiveWt.Text) * Val(txtReceiveSamplePr.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbTLabour_Enter(sender As Object, e As EventArgs) Handles cmbTLabour.Enter
        cmbTLabour.ShowDropDown()
    End Sub
    Private Sub cmbLotNo_Enter(sender As Object, e As EventArgs) Handles cmbLotNo.Enter
        cmbLotNo.ShowDropDown()
    End Sub
    Private Sub txtMeltingPercent_TextChanged(sender As Object, e As EventArgs) Handles txtMeltingPr.TextChanged
        Try
            txtTargetGoldWeight.Text = Format((Val(txtIssueFine.Text) / Val(txtMeltingPr.Text)) * 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.Text.Trim <> "" Then
            Me.getLastLotNoAmt()
        End If

        txtMeltingPr.Text = GetLotNoInLotTransfer()
    End Sub

    Private Sub Clear_Form()
        Try
            txtTransNo.Tag = ""
            txtTransNo.Clear()

            TransDt.Value = DateTime.Now

            cmbLotNo.SelectedIndex = -1
            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()

            cmbTLabour.SelectedIndex = -1

            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()

            cmbLotNo.SelectedIndex = -1

            txtIssueWeight.Clear()
            txtIssuePercent.Clear()
            txtIssueFine.Clear()

            txtChainReceiveWt.Clear()
            txtReceivePr.Clear()
            txtReceiveFine.Clear()

            txtBhukaReceiveWt.Clear()
            txtReceiveBhukaPr.Clear()
            txtReceiveBhukaFine.Clear()

            txtSampleReceiveWt.Clear()
            txtReceiveSamplePr.Clear()
            txtReceiveSampleFine.Clear()

            txtReceiveTotalGross.Clear()
            txtReceiveTotalPr.Clear()
            txtReceiveTotalFine.Clear()

            txtMeltingPr.Clear()
            txtTargetGoldWeight.Clear()
            txtCoreRemains.Clear()
            txtLossWt.Clear()

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If String.IsNullOrWhiteSpace(cmbTLabour.Text.Trim()) Or Convert.ToInt32(cmbTLabour.SelectedIndex) = -1 Then
                MessageBox.Show("Select Labour !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbTLabour.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub UpdateData()

        Dim iOperationTypeId As Integer = 15 ''Operation Id for Core Addition Issue

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                .Add(dbManager.CreateParameter("@CoreRemovalDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@ItemId", Val(txtTransNo.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@OperationTypeId", iOperationTypeId, DbType.Int16))
                .Add(dbManager.CreateParameter("@IssueWt", txtIssueWeight.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@IssuePr", txtIssuePercent.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@ReceiveWt", txtChainReceiveWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@ReceivePr", txtReceivePr.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@LotNumber", cmbLotNo.SelectedItem.ToString(), DbType.String))
                .Add(dbManager.CreateParameter("@MeltingPr", txtMeltingPr.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@BhukaWt", txtBhukaReceiveWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@SampleWt", txtSampleReceiveWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@CoreRemainsWt", txtCoreRemains.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@LossWt", txtLossWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@FrKarigar", txtFrKarigar.Tag.Trim(), DbType.Int16))
                .Add(dbManager.CreateParameter("@ToKarigar", cmbTLabour.SelectedIndex, DbType.String))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_CoreAdditionRemoval_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
End Class