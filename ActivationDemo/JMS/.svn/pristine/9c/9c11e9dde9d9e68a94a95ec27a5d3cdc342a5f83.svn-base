Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmCoreAdditionReceive
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

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
    Private Sub frmCoreAdditionReceive_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Clear_Form()

        Me.fillLabour()
        Me.fillLotNo()
        Me.bindListView()
    End Sub
    Private Sub fillLabour()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
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

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FetchLotNoForCoreAdditionReceive", DbType.String))

        Dim dr = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim frow As DataRow = dt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            dt.Rows.InsertAt(frow, 0)

            cmbLotNo.DataSource = dt
            cmbLotNo.DisplayMember = "LotNo"
            cmbLotNo.ValueMember = "TransactionId"

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub bindListView()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        lstCoreAddition.Items.Clear()

        Try

            While dr.Read
                Dim lvi As ListViewItem = New ListViewItem(dr("CoreAdditionId").ToString())
                lvi.SubItems.Add(dr("CoreAdditionDt").ToString())
                lvi.SubItems.Add(dr("LotNo").ToString())
                lvi.SubItems.Add(dr("IssueWt").ToString())
                lvi.SubItems.Add(dr("IssuePr").ToString())
                lvi.SubItems.Add(dr("CoreIssueWt").ToString())
                lvi.SubItems.Add(dr("FrKarigarId").ToString())
                lvi.SubItems.Add(dr("frKarigarName").ToString())
                lvi.SubItems.Add(dr("ToKarigarId").ToString())
                lvi.SubItems.Add(dr("toKarigarName").ToString())
                lvi.SubItems.Add(dr("CreatedBy").ToString())
                lstCoreAddition.Items.Add(lvi)
            End While

            If lstCoreAddition.Items.Count > 0 Then
                lstCoreAddition.Items(0).Selected = True
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try

    End Sub
    Private Sub fillHeaderFromListView(ByVal intCoreIssueId As Integer)

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Add(dbManager.CreateParameter("@CId", Val(intCoreIssueId), DbType.Int16))
            .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.Read = False Then
            Exit Sub
        Else
            txtTransNo.Text = dr.Item("CoreAdditionId").ToString()
            TransDt.Text = dr.Item("CoreAdditionDt").ToString
            cmbLotNo.Text = dr.Item("LotNo").ToString

            txtGoldIssueGross.Text = dr.Item("IssueWt").ToString()
            txtGoldIssuePercent.Text = dr.Item("IssuePr").ToString()
            txtCIssueWt.Text = dr.Item("CoreIssueWt").ToString()

            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString()
            txtFrKarigar.Text = dr.Item("frKarigarName").ToString()
            cmbTLabour.SelectedIndex = dr.Item("ToKarigarId").ToString()
            ''txtFrKarigar.Tag = dr.Item().ToString()
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub bindIssueListview()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
            .Add(dbManager.CreateParameter("@CId", cmbLotNo.SelectedIndex, DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        lstCoreAddition.Items.Clear()

        Try
            If dr.Read = False Then
                Exit Sub
            Else
                txtGoldIssueGross.Text = Format(Val(dr("IssueWt")), "0.00")
                txtGoldIssuePercent.Text = Format(Val(dr("IssuePr")), "0.00")
                txtGoldIssueFine.Text = Format(Val(dr("FineWt")), "0.000")
                txtCIssueWt.Text = Format(Val(dr("CoreIssueWt")), "0.00")
                txtFrKarigar.Tag = Val(dr("FrKarigarId"))
                txtFrKarigar.Text = Convert.ToString(dr("frKarigarName"))
                cmbTLabour.SelectedIndex = Val(dr("ToKarigarId"))

                txtGoldBhukaPercent.Text = Format(Val(dr("IssuePr")), "0.00")
                txtGoldLossPercent.Text = Format(Val(dr("IssuePr")), "0.00")

                txtTransNo.Tag = Val(dr("ItemId"))

                txtCIssuePr.Text = "0.00"
                txtCFineWt.Text = "0.00"
                txtCoreBhukaPercent.Text = "0.00"
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try

    End Sub
    Private Sub SaveData()
        Dim iOperationTypeId As Integer = 14 ''Operation Id for Core Addition Receive

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                .Add(dbManager.CreateParameter("@CoreAdditionDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@GoldBhukaRecWt", txtGoldPlusCoreWireGross.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@CoreRecWt", txtGoldPlusCoreBhukaGross.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GoldCoreBhukaWt", txtGoldBhukaGross.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GoldCoreWireWt", txtCoreBhukaGross.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@LotNumber", cmbLotNo.SelectedItem.ToString(), DbType.String))
                .Add(dbManager.CreateParameter("@FrKarigar", txtFrKarigar.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@ToKarigar", cmbTLabour.SelectedIndex, DbType.Int16))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))

                .Add(dbManager.CreateParameter("@IssueWt", txtGoldIssueGross.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@IssuePr", txtGoldIssuePercent.Text.Trim(), DbType.String))

                .Add(dbManager.CreateParameter("@ReceiveWt", txtFinalGoldIssuedGross.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@ReceivePr", txtGoldIssuePercent.Text.Trim(), DbType.String))

                .Add(dbManager.CreateParameter("@FReceivePr", txtFinalPercent.Text.Trim(), DbType.String))

                .Add(dbManager.CreateParameter("@ItemId", txtTransNo.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@OperationTypeId", iOperationTypeId, DbType.Int16))
            End With

            dbManager.Insert("SP_CoreAdditionReceive_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateData()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                .Add(dbManager.CreateParameter("@CoreAdditionDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@GoldBhukaRecWt", txtGoldPlusCoreWireGross.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@CoreRecWt", txtGoldPlusCoreBhukaGross.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GoldCoreBhukaWt", txtGoldBhukaGross.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GoldCoreWireWt", txtCoreBhukaGross.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@LotNumber", cmbLotNo.SelectedItem.ToString(), DbType.String))
                .Add(dbManager.CreateParameter("@FrKarigar", txtFrKarigar.Text.Trim(), DbType.Int16))
                .Add(dbManager.CreateParameter("@ToKarigar", cmbTLabour.SelectedIndex, DbType.String))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@CId", txtTransNo.Text, DbType.Int16))
            End With

            dbManager.Insert("SP_CoreAdditionReceive_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As EventArgs)
        Me.bindIssueListview()
    End Sub
    Private Sub txtCoreWt_TextChanged(sender As Object, e As EventArgs) Handles txtCIssueWt.TextChanged
        Try
            txtTotalIssueWt.Text = Format((Val(txtGoldIssueGross.Text) + Val(txtCIssueWt.Text)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldIssueGross_TextChanged(sender As Object, e As EventArgs) Handles txtGoldIssueGross.TextChanged
        Try
            txtFinalGoldIssuedGross.Text = Format(Val(txtGoldIssueGross.Text) - Val(txtGoldBhukaGross.Text) - Val(txtGoldLossGross.Text), "0.00")
            txtTotalIssueWt.Text = Format((Val(txtGoldIssueGross.Text) + Val(txtCIssueWt.Text)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtTotalIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtTotalIssueWt.TextChanged
        Try
            txtTotalFineWt.Text = Format((Val(txtGoldIssueFine.Text) + Val(txtCFineWt.Text)), "0.00")
            txtTotalIssuePr.Text = Format((Val(txtTotalFineWt.Text) / Val(txtTotalIssueWt.Text)) * 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldPlusCoreBhukaGross_TextChanged(sender As Object, e As EventArgs) Handles txtGoldPlusCoreWireGross.TextChanged
        Try
            txtGoldPlusCoreWireFine.Text = Format((Val(txtGoldPlusCoreWireGross.Text) * Val(txtGoldPlusCoreWirePercent.Text)) / 100, "0.00")

            txtFinalReceivedGoldPlusCoreGross.Text = Format(Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text), "0.00")
            txtGoldLossGross.Text = Format(Val(txtTotalIssueWt.Text) - (Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text)), "0.00")
            'txtGoldLossGross.Text = Format(Val(txtGoldLossGross.Text), "0.00")
            txtTotalReceiveGross.Text = Format(Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text) + Val(txtGoldLossGross.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldPlusCoreWirePercent_TextChanged(sender As Object, e As EventArgs) Handles txtGoldPlusCoreWirePercent.TextChanged
        Try
            txtGoldPlusCoreWireFine.Text = Format(Val(txtGoldPlusCoreWireGross.Text) * Val(txtGoldPlusCoreWirePercent.Text) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldPlusCoreWireGross_TextChanged(sender As Object, e As EventArgs) Handles txtGoldPlusCoreBhukaGross.TextChanged
        Try
            txtGoldPlusCoreBhukaFine.Text = Format((Val(txtGoldPlusCoreBhukaGross.Text) * Val(txtGoldPlusCoreBhukaPercent.Text)) / 100, "0.00")

            txtFinalReceivedGoldPlusCoreGross.Text = Format(Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text), "0.00")

            txtGoldLossGross.Text = Format(Val(txtTotalIssueWt.Text) - (Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text)), "0.00")

            txtTotalReceiveGross.Text = Format(Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text) + Val(txtGoldLossGross.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldBhukaGross_TextChanged(sender As Object, e As EventArgs) Handles txtGoldBhukaGross.TextChanged
        Try
            txtGoldBhukaFine.Text = Format((Val(txtGoldBhukaGross.Text) * Val(txtGoldBhukaPercent.Text)) / 100, "0.00")

            txtFinalGoldIssuedGross.Text = Format(Val(txtGoldIssueGross.Text) - Val(txtGoldBhukaGross.Text) - Val(txtGoldLossGross.Text), "0.00")

            txtGoldLossGross.Text = Format(Val(txtTotalIssueWt.Text) - (Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text)), "0.00")

            txtTotalReceiveGross.Text = Format(Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text) + Val(txtGoldLossGross.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtCoreBhukaGross_TextChanged(sender As Object, e As EventArgs) Handles txtCoreBhukaGross.TextChanged
        Try
            txtCoreBhukaFine.Text = Format((Val(txtCoreBhukaGross.Text) * Val(txtCoreBhukaPercent.Text)) / 100, "0.00")
            txtGoldLossGross.Text = Format(Val(txtTotalIssueWt.Text) - (Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text)), "0.00")
            txtTotalReceiveGross.Text = Format(Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text) + Val(txtGoldLossGross.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldPlusCoreBhukaPercent_TextChanged(sender As Object, e As EventArgs) Handles txtGoldPlusCoreBhukaPercent.TextChanged
        Try
            txtGoldPlusCoreBhukaFine.Text = Format(Val(txtGoldPlusCoreBhukaGross.Text) * Val(txtGoldPlusCoreBhukaPercent.Text) / 100, "0.00")
            txtTotalReceiveGross.Text = Format(Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text) + Val(txtGoldLossGross.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldLossGross_TextChanged(sender As Object, e As EventArgs) Handles txtGoldLossGross.TextChanged
        Try
            txtGoldLossFine.Text = Format((Val(txtGoldLossGross.Text) * Val(txtGoldLossPercent.Text)) / 100, "0.00")

            txtFinalGoldIssuedGross.Text = Format(Val(txtGoldIssueGross.Text) - Val(txtGoldBhukaGross.Text) - Val(txtGoldLossGross.Text), "0.00")
            txtGoldLossGross.Text = Format(Val(txtTotalIssueWt.Text) - (Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text)), "0.00")
            txtTotalReceiveGross.Text = Format(Val(txtGoldPlusCoreWireGross.Text) + Val(txtGoldPlusCoreBhukaGross.Text) + Val(txtGoldBhukaGross.Text) + Val(txtCoreBhukaGross.Text) + Val(txtGoldLossGross.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtFinalGoldIssuedGross_TextChanged(sender As Object, e As EventArgs) Handles txtFinalGoldIssuedGross.TextChanged
        Try
            txtFinalGoldIssuedFine.Text = Format((Val(txtFinalGoldIssuedGross.Text) * Val(txtGoldIssuePercent.Text)) / 100, "0.00")
            txtFinalGoldIssuedGross.Text = Format(Val(txtGoldIssueGross.Text) - Val(txtGoldBhukaGross.Text) - Val(txtGoldLossGross.Text), "0.00")

            If Not String.IsNullOrEmpty(txtFinalGoldIssuedFine.Text) And Not String.IsNullOrEmpty(txtFinalGoldIssuedGross.Text) Then
                txtFinalGoldIssuedPr.Text = Format((Val(txtFinalGoldIssuedFine.Text) / Val(txtFinalGoldIssuedGross.Text)) * 100, "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGIssuePr_TextChanged(sender As Object, e As EventArgs) Handles txtGoldIssuePercent.TextChanged
        Try
            txtFinalGoldIssuedFine.Text = Format((Val(txtFinalGoldIssuedGross.Text) * Val(txtGoldIssuePercent.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtFinalGoldIssuedFine_TextChanged(sender As Object, e As EventArgs) Handles txtFinalGoldIssuedFine.TextChanged
        Dim dFinalGoldIssuedFine As Double = 0
        Dim dFinalReceivedGoldPlusCoreGross As Double = 0
        Dim dFinalPercent As Double = 0

        Try

            If Not String.IsNullOrEmpty(txtFinalGoldIssuedFine.Text) Or String.IsNullOrEmpty(txtFinalReceivedGoldPlusCoreGross.Text) Then
                dFinalGoldIssuedFine = Val(txtFinalGoldIssuedFine.Text)
                dFinalReceivedGoldPlusCoreGross = Val(txtFinalReceivedGoldPlusCoreGross.Text)

                If dFinalGoldIssuedFine > 0 And dFinalReceivedGoldPlusCoreGross > 0 Then
                    txtFinalPercent.Text = Format((Val(dFinalGoldIssuedFine) / Val(dFinalReceivedGoldPlusCoreGross)) * 100, "0.00")
                    txtGoldPlusCoreWirePercent.Text = Val(txtFinalPercent.Text)
                    txtGoldPlusCoreBhukaPercent.Text = Val(txtFinalPercent.Text)
                End If

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtFinalReceivedGoldPlusCoreGross_TextChanged(sender As Object, e As EventArgs) Handles txtFinalReceivedGoldPlusCoreGross.TextChanged
        Try
            If Not String.IsNullOrEmpty(txtFinalGoldIssuedFine.Text) Or String.IsNullOrEmpty(txtFinalReceivedGoldPlusCoreGross.Text) Then
                txtFinalPercent.Text = Format((Val(txtFinalGoldIssuedFine.Text) / Val(txtFinalReceivedGoldPlusCoreGross.Text)) * 100, "0.00")
                txtFinalFw.Text = Format((Val(txtFinalReceivedGoldPlusCoreGross.Text) * Val(txtFinalPercent.Text)) / 100, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
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
    Private Sub frmCoreAdditionReceive_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
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
    Private Sub txtGoldPlusCoreWireFine_TextChanged(sender As Object, e As EventArgs) Handles txtGoldPlusCoreWireFine.TextChanged
        Try
            txtTotalReceiveFine.Text = Format(Val(txtGoldPlusCoreWireFine.Text) + Val(txtGoldPlusCoreBhukaFine.Text) + Val(txtGoldBhukaFine.Text) + Val(txtCoreBhukaFine.Text) + Val(txtGoldLossFine.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldPlusCoreBhukaFine_TextChanged(sender As Object, e As EventArgs) Handles txtGoldPlusCoreBhukaFine.TextChanged
        Try
            txtTotalReceiveFine.Text = Format(Val(txtGoldPlusCoreWireFine.Text) + Val(txtGoldPlusCoreBhukaFine.Text) + Val(txtGoldBhukaFine.Text) + Val(txtCoreBhukaFine.Text) + Val(txtGoldLossFine.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldBhukaFine_TextChanged(sender As Object, e As EventArgs) Handles txtGoldBhukaFine.TextChanged
        Try
            txtTotalReceiveFine.Text = Format(Val(txtGoldPlusCoreWireFine.Text) + Val(txtGoldPlusCoreBhukaFine.Text) + Val(txtGoldBhukaFine.Text) + Val(txtCoreBhukaFine.Text) + Val(txtGoldLossFine.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtCoreBhukaFine_TextChanged(sender As Object, e As EventArgs) Handles txtCoreBhukaFine.TextChanged
        Try
            txtTotalReceiveFine.Text = Format(Val(txtGoldPlusCoreWireFine.Text) + Val(txtGoldPlusCoreBhukaFine.Text) + Val(txtGoldBhukaFine.Text) + Val(txtCoreBhukaFine.Text) + Val(txtGoldLossFine.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldLossFine_TextChanged(sender As Object, e As EventArgs) Handles txtGoldLossFine.TextChanged
        Try
            txtTotalReceiveFine.Text = Format(Val(txtGoldPlusCoreWireFine.Text) + Val(txtGoldPlusCoreBhukaFine.Text) + Val(txtGoldBhukaFine.Text) + Val(txtCoreBhukaFine.Text) + Val(txtGoldLossFine.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldPlusCoreWireGross_Leave(sender As Object, e As EventArgs) Handles txtGoldPlusCoreWireGross.Leave
        txtGoldPlusCoreWireGross.Text = Format(Val(txtGoldPlusCoreWireGross.Text), "0.00")
    End Sub
    Private Sub txtGoldBhukaGross_Leave(sender As Object, e As EventArgs) Handles txtGoldBhukaGross.Leave
        txtGoldBhukaGross.Text = Format(Val(txtGoldBhukaGross.Text), "0.00")
    End Sub
    Private Sub txtCoreBhukaGross_Leave(sender As Object, e As EventArgs) Handles txtCoreBhukaGross.Leave
        txtCoreBhukaGross.Text = Format(Val(txtCoreBhukaGross.Text), "0.00")
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbLotNo_Enter(sender As Object, e As EventArgs) Handles cmbLotNo.Enter
        cmbLotNo.ShowDropDown()
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtTransNo.Text) Then
            Try
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Add(dbManager.CreateParameter("@CId", Val(txtTransNo.Text), DbType.Int16))
                End With

                dbManager.Delete("SP_CoreAdditionIssue_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Clear_Form()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        Me.bindIssueListview()
    End Sub
    Private Sub txtGoldPlusCoreBhukaGross_Leave(sender As Object, e As EventArgs) Handles txtGoldPlusCoreBhukaGross.Leave
        txtGoldPlusCoreBhukaGross.Text = Format(Val(txtGoldPlusCoreBhukaGross.Text), "0.00")
    End Sub
    Private Sub txtTotalReceiveGross_TextChanged(sender As Object, e As EventArgs) Handles txtTotalReceiveGross.TextChanged
        Try
            If Not String.IsNullOrEmpty(txtTotalReceiveGross.Text) And Not String.IsNullOrEmpty(txtTotalReceiveFine.Text) Then
                txtTotalReceivePercent.Text = Format((Val(txtTotalReceiveFine.Text) / Val(txtTotalReceiveGross.Text)) * 100, "0.00")
            Else
                txtTotalReceivePercent.Text = Format(txtTotalReceivePercent.Text, "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtTotalReceiveFine_TextChanged(sender As Object, e As EventArgs) Handles txtTotalReceiveFine.TextChanged
        Try
            If Not String.IsNullOrEmpty(txtTotalReceiveGross.Text) And Not String.IsNullOrEmpty(txtTotalReceiveFine.Text) Then
                txtTotalReceivePercent.Text = Format((Val(txtTotalReceiveFine.Text) / Val(txtTotalReceiveGross.Text)) * 100, "0.00")
            Else
                txtTotalReceivePercent.Text = Format(txtTotalReceivePercent.Text, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldPlusCoreWireGross_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGoldPlusCoreWireGross.KeyPress
        numdotkeypress(e, txtGoldPlusCoreWireGross, Me)
    End Sub
    Private Sub txtGoldPlusCoreBhukaGross_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGoldPlusCoreBhukaGross.KeyPress
        numdotkeypress(e, txtGoldPlusCoreBhukaGross, Me)
    End Sub
    Private Sub txtGoldBhukaGross_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGoldBhukaGross.KeyPress
        numdotkeypress(e, txtGoldBhukaGross, Me)
    End Sub
    Private Sub txtCoreBhukaGross_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCoreBhukaGross.KeyPress
        numdotkeypress(e, txtCoreBhukaGross, Me)
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub cmbTLabour_Enter(sender As Object, e As EventArgs) Handles cmbTLabour.Enter
        cmbTLabour.ShowDropDown()
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

            txtGoldIssueGross.Clear()
            txtCIssueWt.Clear()
            txtTotalIssueWt.Clear()

            txtGoldIssuePercent.Clear()
            txtCIssuePr.Clear()
            txtTotalIssuePr.Clear()

            txtGoldIssueFine.Clear()
            txtCFineWt.Clear()
            txtTotalFineWt.Clear()

            txtFinalGoldIssuedGross.Clear()
            txtFinalGoldIssuedFine.Clear()
            txtFinalGoldIssuedPr.Clear()

            txtGoldPlusCoreWireGross.Clear()
            txtGoldPlusCoreBhukaGross.Clear()
            txtGoldBhukaGross.Clear()
            txtCoreBhukaGross.Clear()
            txtGoldLossGross.Clear()
            txtTotalReceiveGross.Clear()

            txtGoldPlusCoreWirePercent.Clear()
            txtGoldPlusCoreBhukaPercent.Clear()
            txtGoldBhukaPercent.Clear()
            txtCoreBhukaPercent.Clear()
            txtGoldLossPercent.Clear()
            txtTotalReceivePercent.Clear()

            txtGoldPlusCoreWireFine.Clear()
            txtGoldPlusCoreBhukaFine.Clear()
            txtGoldBhukaFine.Clear()
            txtCoreBhukaFine.Clear()
            txtGoldLossFine.Clear()
            txtTotalReceiveFine.Clear()

            txtFinalReceivedGoldPlusCoreGross.Clear()
            txtFinalPercent.Clear()

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

End Class