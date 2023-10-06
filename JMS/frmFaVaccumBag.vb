Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.Data
Imports Telerik.WinControls.UI
Public Class frmFaVaccumBag
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
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "&Save"
                Case FormState.EStateMode
                    Me.btnSave.Text = "&Update"
            End Select
        End Set
    End Property
    Private Sub frmVaccumeBag_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.EnbledBtn()
        Me.fillBagType()
        Me.FillItemVaccumeBag()
        Me.FillRBagSrNoAll()
        Me.FillUpdateBagNo()
        Me.FillUpdatedData()
    End Sub

    Private Sub FillUpdatedData()
        Dim dtable As DataTable = fetchAllDetails()
        'RadGridView1.Rows.Clear()
        For i As Integer = 0 To dtable.Rows.Count - 1
            dgvFinalUpdate.DataSource = dtable
            dgvFinalUpdate.ReadOnly = True
        Next
    End Sub
    'Calling Function To List Updated Data
    Private Function fetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchVUsedUBagData", DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub EnbledBtn()
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub fillBagType()

        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillVaccumCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        dt.Load(dr)

        If tbVaccumeBag.SelectedIndex = 0 Then
            Try
                cmbCOperation.DataSource = Nothing
                cmbCOperation.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbCOperation.DataSource = dt
                cmbCOperation.DisplayMember = "OperationName"
                cmbCOperation.ValueMember = "OperationId"
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        ElseIf tbVaccumeBag.SelectedIndex = 1 Then
            ' FillRVaccumBagNo()
        Else

        End If
    End Sub
    Private Sub FillItemVaccumeBag()
        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillVaccumBagItem", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        dt.Load(dr)

        If tbVaccumeBag.SelectedIndex = 0 Then
            Try
                cmbItemVaccumeBag.DataSource = Nothing
                cmbItemVaccumeBag.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbItemVaccumeBag.DataSource = dt
                cmbItemVaccumeBag.DisplayMember = "ItemName"
                cmbItemVaccumeBag.ValueMember = "ItemId"
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        ElseIf tbVaccumeBag.SelectedIndex = 1 Then
            ' FillRVaccumBagNo()
        Else

        End If
    End Sub
    Private Sub FillRBagSrNoAll()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "fillcmbRBagNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)
        Try
            'Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            'Assign DataTable as DataSource.
            cmbRBagNo.DataSource = dt
            Me.cmbRBagNo.AutoFilter = True
            cmbRBagNo.DisplayMember = "VaccumeBagNo"
            cmbRBagNo.ValueMember = "BagId"
            cmbRBagNo.Text = ""
            cmbRBagNo.Refresh()
            cmbRBagNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbRBagNo.BestFitColumns(True, False)
            'cmbRBagNo.Columns(0).IsVisible = False
            cmbRBagNo.Columns(2).Width = 300
            cmbRBagNo.Columns(2).TextAlignment = ContentAlignment.MiddleRight

            Me.cmbRBagNo.MultiColumnComboBoxElement.DropDownWidth = 300
            Me.BackColor = Color.White
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub cmbLabour_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbLabour.SelectedIndexChanged
        If Convert.ToInt32(cmbLabour.SelectedIndex) > 0 Then
            Me.bindVacuumBag()
            If dgvVacuumBag.Rows.Count > 0 Then
                Me.DisableBtn()
            End If
        End If
    End Sub
    Private Sub DisableBtn()
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub btnCExit_Click(sender As Object, e As EventArgs) Handles btnCExit.Click
        Me.Close()
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Try
            Me.clearAllUpdateData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub fillLabour()

        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchOpWiseLabour", DbType.String))
            .Add(dbManager.CreateParameter("@NId", cmbCOperation.SelectedValue, DbType.Int16))
        End With

        Dim dr = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        dt.Load(dr)

        If tbVaccumeBag.SelectedIndex = 0 Then
            Try
                cmbLabour.DataSource = Nothing
                cmbLabour.Items.Clear()

                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbLabour.DataSource = dt
                cmbLabour.DisplayMember = "LabourName"
                cmbLabour.ValueMember = "LabourId"
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                dr.Close()
                dbManager.CloseConnection(connection)
            End Try
        ElseIf tbVaccumeBag.SelectedIndex = 1 Then
        Else
        End If
    End Sub
    Private Function Validate_RFields() As Boolean
        Try
            If String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Then
                MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagNo.Focus()
                Return False
            ElseIf txtRWtOnScale.Text <= 0 Then
                MessageBox.Show("Enter Wt On Scale...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            ElseIf txtRRecieveWt.Text <= 0 Then
                MessageBox.Show("Enter Lagdi Receive Wt...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
                'ElseIf txtRTotalWt.Text <= 0 Then
                '    MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                '    Return False
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'If Not Validate_RFields() Then Exit Sub
        btnRCancel_Click(sender, e)
        Try
            If btnSave.Text = "&Save" Then
                If dgvVacuumBag.Rows.Count > 0 Then
                    Me.UpdateVaccumSrNo()
                    Me.FillRBagSrNoAll()
                    Me.btnCancel_Click(sender, e)
                    Me.FillUpdateBagNo()
                Else
                    MessageBox.Show(" To Create VaccumeBag Select Labour")
                End If
            Else
                If (MsgBox("Are You Sure To Update This Vaccume Bag ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                    Try
                        If dgvVacuumBag.RowCount > 0 Then
                            Dim parameters = New List(Of SqlParameter)()
                            parameters.Clear()

                            With parameters
                                .Add(dbManager.CreateParameter("@ActionType", "SetVaccumeBagNoToNULL", DbType.String))
                                .Add(dbManager.CreateParameter("@SBagSrNo", txtVacBagNo.Text, DbType.String))
                            End With

                            dbManager.Delete("SP_VaccumeBag_Update", CommandType.StoredProcedure, parameters.ToArray())
                            Me.UpdateSameVaccumeBag()
                            Me.FillRBagSrNoAll()
                            Me.btnCancel_Click(sender, e)
                            Me.FillUpdateBagNo()
                            lblVacBagNo.Visible = False
                            txtVacBagNo.Visible = False
                            btnSave.Text = "&Save"
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error:- " & ex.Message)
                    End Try
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Sub UpdateSameVaccumeBag()
        Dim alParaval As New ArrayList
        Dim BagId As Int16 = 0
        Dim TranId As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0
        alParaval.Add(cmbItemVaccumeBag.Tag)
        If dgvVacuumBag.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvVacuumBag.Rows
                If row.Cells(0).Value = True Then
                    If TranId = "" Then
                        TranId = Val(row.Cells(8).Value)
                    Else
                        TranId = TranId & "|" & Val(row.Cells(8).Value)
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
                    .Add(dbManager.CreateParameter("@BagSrNo", txtVacBagNo.Text, DbType.String))
                    '.Add(dbManager.CreateParameter("@BagType", "V", DbType.String))
                End With
                dbManager.Update("SP_VaccumeSameBag_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                Dim BagNo As String = Nothing
                BagNo = txtVacBagNo.Text

                MessageBox.Show("Vaccume  Bag " + BagNo + " Update Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Try
                '    Dim icurValue As Integer = 0
                '    Dim sresult As String = String.Empty
                '    strSQL = Nothing
                '    Dim ItemId As String
                '    ItemId = cmbItemVaccumeBag.SelectedValue
                '    strSQL = "Select Max(VaccumeBagNo) from tblfNewLotNo where BagID=(select Distinct ItemCode from tblfItemMaster where ItemId=" + ItemId + ")"
                '    Try
                '        sresult = Convert.ToString(dbManager.GetScalarValue(strSQL, CommandType.Text))
                '        Int32.TryParse(sresult, icurValue)
                '        Dim VaccumeBagNo = sresult
                '        MessageBox.Show("VaccumeBag " + VaccumeBagNo + " Created !!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Catch ex As Exception
                '        MessageBox.Show("Error:- " & ex.Message)
                '    End Try
                'Catch ex As Exception
                'End Try
            Catch
            End Try
        End If
    End Sub
    Private Sub bindVacuumBag()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchVacuumData", DbType.String))
            .Add(dbManager.CreateParameter("@NId", Val(cmbLabour.SelectedValue), DbType.Int16))
            .Add(dbManager.CreateParameter("@OId", Val(cmbCOperation.SelectedValue), DbType.Int16))
        End With

        dt = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray())

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
    Private Sub tbVaccumeBag_Click(sender As Object, e As EventArgs) Handles tbVaccumeBag.Click
        'If tbVaccumeBag.SelectedIndex = 0 Then     ''for Create Bhuka Bag
        '    Me.fillBagType()
        'ElseIf tbVaccumeBag.SelectedIndex = 1 Then ''for Receive Bhuka Bag
        '    ' Me.fillVaccumBag()
        'ElseIf tbVaccumeBag.SelectedIndex = 2 Then ''for Update Bhuka Bag
        '    'Me.fillVaccumBag()
        'End If
        If tbVaccumeBag.SelectedIndex = 0 Then
            btnCancel_Click(sender, e)
        ElseIf tbVaccumeBag.SelectedIndex = 1 Then
            btnRCancel_Click(sender, e)
        ElseIf tbVaccumeBag.SelectedIndex = 2 Then
            btnUCancel_Click(sender, e)
        ElseIf tbVaccumeBag.SelectedIndex = 3 Then
            Me.FillUpdatedData()
        End If
    End Sub
    Private Sub UpdateVaccumSrNo()
        Dim alParaval As New ArrayList
        Dim BagId As Int16 = 0
        Dim TranId As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0
        alParaval.Add(cmbItemVaccumeBag.SelectedValue)
        If dgvVacuumBag.Rows.Count > 0 Then
            For Each row As GridViewRowInfo In dgvVacuumBag.Rows
                If row.Cells(0).Value = True Then
                    If TranId = "" Then
                        TranId = Val(row.Cells(8).Value)
                    Else
                        TranId = TranId & "|" & Val(row.Cells(8).Value)
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
                dbManager.Update("SP_fUsedBagNo_Update", CommandType.StoredProcedure, Dparameters.ToArray())
                Try
                    Dim icurValue As Integer = 0
                    Dim sresult As String = String.Empty
                    strSQL = Nothing
                    Dim ItemId As String
                    ItemId = cmbItemVaccumeBag.SelectedValue
                    strSQL = "Select Max(VaccumeBagNo) from tblfNewLotNo where BagID=(select Distinct ItemCode from tblfItemMaster where ItemId=" + ItemId + ")"
                    Try
                        sresult = Convert.ToString(dbManager.GetScalarValue(strSQL, CommandType.Text))
                        Int32.TryParse(sresult, icurValue)
                        Dim VaccumeBagNo = sresult
                        MessageBox.Show("VaccumeBag " + VaccumeBagNo + " Created !!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Catch ex As Exception
                        MessageBox.Show("Error:- " & ex.Message)
                    End Try
                Catch ex As Exception
                End Try
            Catch
            End Try
        End If
    End Sub
    Private Sub dgvVacuumBag_ValueChanged(sender As Object, e As EventArgs) Handles dgvVacuumBag.ValueChanged
        If dgvVacuumBag.CurrentColumn.Name = "colChkBox" Then
            dgvVacuumBag.EndEdit()
        End If
        Me.CreateTotal()
    End Sub
    Sub CreateTotal()
        Dim sBhukaTotal As Single = 0
        Dim sBhukaFineTotal As Single = 0

        For Each row As GridViewRowInfo In dgvVacuumBag.Rows
            If CBool(row.Cells()(0).Value) = True And Not String.IsNullOrEmpty(row.Cells(4).Value) Then
                sBhukaTotal += Single.Parse(row.Cells(4).Value)
                sBhukaFineTotal += Single.Parse(row.Cells(6).Value)
            End If
        Next

        lblCVaccumWt.Text = Format(sBhukaTotal, "0.00")
        lblCVaccumFt.Text = Format(sBhukaFineTotal, "0.00")
    End Sub
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click
        If Not ReceiveValidate_Fields() Then Exit Sub

        Try

            Dim parameters = New List(Of SqlParameter)()

            If btnRSave.Text = "&Save" And cmbRBagNo.Text.Trim.Length > 0 Then

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "SaveVaccumeBagData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))
                    '.Add(dbManager.CreateParameter("@UItemId", Val(cmbRBagtype.SelectedValue), DbType.Int16))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UIssueWt", Val(txtRIssueWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UIssuePr", Val(txtRIssuePr.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@URecieveWt", Val(txtRRecieveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonRecieve", Val(txtRCarbon.Text), DbType.String))

                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With

                dbManager.Insert("SP_fUsedBags_Save", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Please Select The Vaccume Bag No.")
            End If
            Me.btnRCancel_Click(sender, e)

            Me.FillRBagSrNoAll()
            Me.FillUpdateBagNo()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtRWtOnScale_Leave(sender As Object, e As EventArgs) Handles txtRWtOnScale.Leave
        txtRWtOnScale.Text = Format(Val(txtRWtOnScale.Text), "0.00")
    End Sub
    Private Sub txtRRecieveWt_Leave(sender As Object, e As EventArgs) Handles txtRRecieveWt.Leave
        txtRRecieveWt.Text = Format(Val(txtRRecieveWt.Text), "0.00")
    End Sub
    Private Sub txtRSample_TextChanged(sender As Object, e As EventArgs) Handles txtRSample.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRRecieveWt.Text) + Val(txtRSample.Text), "0.00")
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
    Private Sub txtRCarbon_Leave(sender As Object, e As EventArgs) Handles txtRCarbon.Leave
        txtRCarbon.Text = Format(Val(txtRCarbon.Text), "0.00")
    End Sub
    Private Sub FillRVaccumBagNo()

        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillVacuumLotNo", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        If dr.HasRows = False Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'cmbRBagNo.Items.Clear()
        'cmbRBagNo.ResetText()

        Try
            While dr.Read
                If Not IsDBNull(dr.Item("VaccumeBagNo")) Then
                    'cmbRBagNo.Items.Add(dr.Item("VaccumeBagNo"))
                End If
            End While

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try

    End Sub
    Private Sub CalculateTotal()
        Dim sVaccumTotal As Single = 0
        Dim ssVaccumFineTotal As Single = 0

        For Each row As GridViewRowInfo In dgvVacuumBag.Rows
            If CBool(row.Cells()(0).Value) = True And Not String.IsNullOrEmpty(row.Cells(4).Value) Then
                sVaccumTotal += Single.Parse(row.Cells(4).Value)
                ssVaccumFineTotal += Single.Parse(row.Cells(6).Value)
            End If
        Next

        lblCVaccumWt.Text = Format(sVaccumTotal, "0.00")
        lblCVaccumFt.Text = Format(ssVaccumFineTotal, "0.00")
    End Sub

    Private Sub bindVacuumBagWt()
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchVacuumWtDetails", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbRBagNo.Text), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                dgvReceiveVacuum.DataSource = Nothing
                dgvReceiveVacuum.DataSource = dtData
                Try
                    Dim sresult As String = String.Empty
                    strSQL = Nothing
                    strSQL = "select tblfItemMaster.ItemName from tblfNewLotNo inner join tblfItemMaster ON tblfItemMaster.ItemCode=tblfNewLotNo.BagId where tblfNewLotNo.VaccumeBagNo='" + Convert.ToString(cmbRBagNo.Text) + "'"
                    sresult = Convert.ToString(dbManager.GetScalarValue(strSQL, CommandType.Text))
                    Dim VaccumeBagName = sresult
                    txtRBagName.Text = VaccumeBagName
                Catch ex As Exception

                End Try

                Me.Total()
            Else
                'MessageBox.Show("No Data Found !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click
        If Not UpdateValidate_Fields() Then Exit Sub
        Try
            Dim parameters = New List(Of SqlParameter)()
            If btnUSave.Text = "&Save" And cmbUBagNo.Text.Trim.Length > 0 Then
                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                    .Add(dbManager.CreateParameter("@TId", Val(txtUTransId.Text.Trim()), DbType.Int16))
                    .Add(dbManager.CreateParameter("@ReportPr", Val(txtUreceivePr.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbUBagNo.Text), DbType.String))
                End With

                dbManager.Update("SP_fUsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.btnUCancel_Click(sender, e)
                Me.FillRBagSrNoAll()
                Me.FillUpdateBagNo()
                Me.FillUpdatedData()
            Else
                Try
                    Dim parameters1 = New List(Of SqlParameter)()
                    parameters1.Clear()
                    With parameters
                        .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                        .Add(dbManager.CreateParameter("@TId", Val(txtUTransId.Text.Trim()), DbType.Int16))
                        .Add(dbManager.CreateParameter("@ReportPr", Convert.ToDecimal(txtUreceivePr.Text.Trim()), DbType.Decimal))
                        .Add(dbManager.CreateParameter("@LossWt", Convert.ToDecimal(txtULossFine.Text.Trim()), DbType.Decimal))
                        .Add(dbManager.CreateParameter("@BagSrNo", (cmbUBagNo.Text), DbType.String))
                    End With
                    dbManager.Update("SP_fUsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())
                    MessageBox.Show("Data Updated..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.btnUCancel_Click(sender, e)
                    Me.FillRBagSrNoAll()
                    Me.FillUpdateBagNo()
                    Me.FillUpdatedData()
                    btnUSave.Text = "&Save"
                    BtnUUpdate.Enabled = True
                Catch ex As Exception

                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
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
    Private Sub txtUreceivePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUreceivePr.KeyPress
        numdotkeypress(e, txtUreceivePr, Me)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.clearAllCreateData()
            btnRCancel_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Try
            Me.clearAllReceiveData()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub Total()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0
        Dim sBagName As String = Nothing

        Try
            For Each row As GridViewRowInfo In dgvReceiveVacuum.Rows
                sRWtTotal = Format(Val(sRWtTotal) + Val(row.Cells(5).Value), "0.00")
                sFWtTotal = Format(Val(sFWtTotal) + Val(row.Cells(7).Value), "0.00")
            Next
            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If
            txtRIssueWt.Text = Format(sRWtTotal, "0.00")
            txtRIssuePr.Text = Format(sRPrTotal, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FillUpdateBagNo()

        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "fillUVaccumBagNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)
        Try
            'Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            'Assign DataTable as DataSource.
            cmbUBagNo.DataSource = dt
            Me.cmbUBagNo.AutoFilter = True
            cmbUBagNo.DisplayMember = "BagSrNo"
            cmbUBagNo.ValueMember = "BagSrNo"
            cmbUBagNo.Text = ""
            cmbUBagNo.Refresh()
            cmbUBagNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbUBagNo.BestFitColumns(True, False)
            'cmbUBagNo.Columns(0).IsVisible = False
            cmbUBagNo.Columns(2).Width = 300
            cmbUBagNo.Columns(2).TextAlignment = ContentAlignment.MiddleRight

            Me.cmbUBagNo.MultiColumnComboBoxElement.DropDownWidth = 300
            Me.BackColor = Color.White
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fetchUpdateVaccumBag()

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbUBagNo.Text.Trim), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then

                txtUTransId.Text = dtData.Rows(0).Item("UsedBagId").ToString()
                txtUBagName.Text = dtData.Rows(0).Item("ItemName").ToString()
                ULFailTransDt.Text = dtData.Rows(0).Item("UsedBagDt").ToString()
                txtUreceiveWt.Tag = dtData.Rows(0).Item("GrossReceive").ToString()
                txtUreceiveWt.Text = dtData.Rows(0).Item("RecieveWt").ToString()
                txtUreceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
                txtUreceiveFineWt.Text = dtData.Rows(0).Item("RecieveFineWt").ToString()
                txtUissueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtUissuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtUissueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()
                txtUWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtUcarbonReceive.Text = dtData.Rows(0).Item("CarbonRecieve").ToString()
                'txtUGrossLoss.Text = dtData.Rows(0).Item("GrossLossWt").ToString()
            Else
                'MessageBox.Show("No Data Found !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

    End Sub
    Private Sub cmbRBagNo_SelectionChangeCommitted(sender As Object, e As EventArgs)
        Me.bindVacuumBagWt()
    End Sub
    Private Sub txtRSample_Leave(sender As Object, e As EventArgs) Handles txtRSample.Leave
        txtRSample.Text = Format(Val(txtRSample.Text), "0.00")
    End Sub
    Private Sub txtUreceivePr_Leave(sender As Object, e As EventArgs) Handles txtUreceivePr.Leave
        txtUreceivePr.Text = Format(Val(txtUreceivePr.Text), "0.00")
    End Sub
    Private Sub txtULossFine_Leave(sender As Object, e As EventArgs) Handles txtULossFine.Leave
        txtULossFine.Text = Format(Val(txtULossFine.Text), "0.00")
    End Sub
    Private Sub txtUreceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtUreceivePr.TextChanged
        Try
            txtUreceiveFineWt.Text = Format((Val(txtUreceiveWt.Text) * Val(txtUreceivePr.Text)) / 100, "0.00")
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
            txtULossFine.Text = Format(Val(txtUissueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub clearAllCreateData()
        Try
            lblCVaccumWt.Text = "0.00"
            lblCVaccumPr.Text = "0.00"
            lblCVaccumFt.Text = "0.00"
            lblVacBagNo.Visible = False
            txtVacBagNo.Visible = False
            cmbCOperation.Text = ""
            cmbItemVaccumeBag.Text = ""
            cmbLabour.Text = ""

            If btnSave.Text = "&Save" Then
                dgvVacuumBag.DataSource = Nothing
            Else
                dgvVacuumBag.RowCount = 0
            End If

            dgvReceiveVacuum.DataSource = Nothing
            txtRBagName.Clear()
            txtRIssueWt.Clear()
            txtRIssuePr.Clear()
            cmbCOperation.SelectedIndex = 0
            cmbLabour.SelectedIndex = 0
            cmbItemVaccumeBag.SelectedIndex = 0
            'lblCVaccumWt.Text = 0
            'lblCVaccumPr.Text = 0
            'lblCVaccumFt.Text = 0
            cmbCOperation.Focus()
            cmbCOperation.Select()
            cmbItemVaccumeBag.Select()
            cmbLabour.Select()
            Fr_Mode = FormState.AStateMode
            btnSave.Enabled = True

            Me.fillBagType()
            Me.FillItemVaccumeBag()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnRExit_Click(sender As Object, e As EventArgs) Handles btnRExit.Click
        Me.Close()
    End Sub
    Private Sub btnUExit_Click(sender As Object, e As EventArgs) Handles btnUExit.Click
        Me.Close()
    End Sub
    Private Sub txtUreceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtUreceiveWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUissueWt.Text) - Val(txtUreceiveWt.Tag), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUissueWt_TextChanged(sender As Object, e As EventArgs) Handles txtUissueWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUissueWt.Text) - Val(txtUreceiveWt.Tag), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub clearAllReceiveData()
        Try
            'cmbRBagtype.SelectedIndex = 0
            cmbRBagNo.Text = ""

            txtRIssueWt.Clear()
            txtRIssuePr.Clear()

            txtRWtOnScale.Clear()
            txtRRecieveWt.Clear()

            txtRSample.Clear()
            txtRTotalWt.Clear()

            txtRCarbon.Clear()
            txtRGrossLoss.Clear()
            txtRBagName.Clear()

            dgvReceiveVacuum.DataSource = Nothing
            Me.FillRBagSrNoAll()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub clearAllUpdateData()
        Try
            cmbUBagNo.Text = ""
            txtUBagName.Clear()
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
            Me.FillUpdateBagNo()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRBagNo.SelectedIndexChanged
        If cmbRBagNo.SelectedIndex = -1 Then
            txtRIssueWt.Text = ""
            txtRIssuePr.Text = ""
            With dgvReceiveVacuum
                dgvReceiveVacuum.DataSource = Nothing
            End With
        End If
        If cmbRBagNo.SelectedIndex >= 0 Then
            Me.bindVacuumBagWt()
        End If
    End Sub
    Private Sub cmbCOperation_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbCOperation.SelectedIndexChanged
        If Convert.ToInt32(cmbCOperation.SelectedIndex) > 0 Then
            Me.fillLabour()
        End If
    End Sub

    Private Sub frmVaccumBag_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            ElseIf e.KeyCode = Keys.Enter Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, False) 'for Select Next Control
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
            If (e.Control AndAlso (e.KeyCode = Keys.S)) Then
                ' When Alt + S is pressed, the Click event for the print
                ' button is raised.
                btnSave().PerformClick()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BtnREdit_Click(sender As Object, e As EventArgs) Handles BtnREdit.Click
        If cmbRBagNo.Text = "" Then
            MessageBox.Show("Please Select Bag To Edit")
        Else
            If BtnREdit.Text = "Edit" Then
                ' Me.bindVacuumBagEdit()
                lblVacBagNo.Visible = True
                txtVacBagNo.Visible = True
                btnSave.Text = "Update"
                txtVacBagNo.Tag = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value
                txtVacBagNo.Text = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(1).Value
                Me.FillGridR(cmbRBagNo.Text.Trim)
                tbVaccumeBag.SelectedIndex = 0
            Else
                If Not ReceiveValidate_Fields() Then Exit Sub
                UpdateRecieveVaccumeBag()
                Me.btnRCancel_Click(sender, e)
                BtnREdit.Text = "Edit"
                btnRSave.Enabled = True
                Me.btnUCancel_Click(sender, e)
                Me.FillRBagSrNoAll()
                Me.FillUpdateBagNo()
            End If
        End If
    End Sub
    Private Sub UpdateRecieveVaccumeBag()
        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If BtnREdit.Text = "Update" Then
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateRScrapBagData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@URecieveWt", Val(txtRRecieveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonRecieve", Val(txtRCarbon.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With
                dbManager.Update("SP_UsedBags_UPDATE", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Vaccume Bag Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    'Private Sub bindVacuumBagEdit()
    '    Dim dt As DataTable = New DataTable()

    '    Dim parameters = New List(Of SqlParameter)()
    '    parameters.Clear()

    '    With parameters
    '        .Add(dbManager.CreateParameter("@ActionType", "FetchVacuumData", DbType.String))
    '        .Add(dbManager.CreateParameter("@NId", Val(cmbLabour.SelectedValue), DbType.Int16))
    '        .Add(dbManager.CreateParameter("@OId", Val(cmbCOperation.SelectedValue), DbType.Int16))
    '    End With

    '    dt = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray())

    '    If dt.Rows.Count = 0 Then
    '        MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        Exit Sub
    '    End If

    '    Try
    '        dgvVacuumBag.DataSource = dt
    '        dgvVacuumBag.EnableFiltering = True
    '        dgvVacuumBag.MasterTemplate.ShowFilteringRow = False
    '        dgvVacuumBag.MasterTemplate.ShowHeaderCellButtons = True

    '    Catch ex As Exception
    '        MessageBox.Show("Error:- " & ex.Message)
    '    Finally

    '    End Try
    'End Sub
    Private Sub FillGridR(ByVal sRBagNo As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetails(CStr(sRBagNo))
        If dttable.Rows.Count > 0 Then
            txtVacBagNo.Text = dttable.Rows(0).Item("VaccumeBagNo").ToString()
            cmbCOperation.Tag = dttable.Rows(0).Item("OperationId").ToString()
            cmbCOperation.Text = dttable.Rows(0).Item("OperationName").ToString()
            cmbItemVaccumeBag.Tag = dttable.Rows(0).Item("ItemId").ToString()
            cmbItemVaccumeBag.Text = dttable.Rows(0).Item("ItemName").ToString()
            cmbLabour.Tag = dttable.Rows(0).Item("LabourId").ToString()
            cmbLabour.Text = dttable.Rows(0).Item("LabourName").ToString()
        End If
        FetchGridData()
        'dgvVacuumBag.DataSource = dttable        'For Each ROW As DataRow In dttable.Rows
        '    dgvVacuumBag.Rows.Add(1, Val(ROW("ItemId")), CStr(ROW("ItemName")), Format(Val(ROW("GrossWt")), "0.00"), Format(Val(ROW("GrossPr")), "0.00"), Format(Val(ROW("FineWt")), "0.000"), Val(ROW("ScrapDetailsId")))
        'Next
    End Sub
    Private Function fetchAllDetails(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumeHeaderSelect", DbType.String))
                .Add(dbManager.CreateParameter("@VaccumeBagNo", Trim(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_VaccumeBagSave_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function fetchAllDetailsById(ByVal UsedDetailsId As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchUpdatedBagDataById", DbType.String))
                .Add(dbManager.CreateParameter("@BId", UsedDetailsId, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub FetchGridData()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchVacuumGridData", DbType.String))
            .Add(dbManager.CreateParameter("@NId", Val(cmbLabour.Tag), DbType.Int16))
            .Add(dbManager.CreateParameter("@OId", Val(cmbCOperation.Tag), DbType.Int16))
            .Add(dbManager.CreateParameter("@BagSrNo", Val(txtVacBagNo.Text), DbType.Int16))
        End With

        dt = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Try

            For Each ROW As DataRow In dt.Rows
                dgvVacuumBag.DataSource = Nothing
                dgvVacuumBag.Rows.Add(Convert.ToBoolean(ROW("lotNoBoolean")), CStr(ROW("TransactionDt")), CStr(ROW("OperationName")), CStr(ROW("LotNo")), Format(Val(ROW("VaccumWt")), "0.00"), Format(Val(ROW("MeltingPr")), "0.00"), Format(Val(ROW("FineWt")), "0.00"), 0, CStr(ROW("NewLotId")))
            Next
            'dgvVacuumBag.DataSource = dt
            dgvVacuumBag.EnableFiltering = True
            dgvVacuumBag.MasterTemplate.ShowFilteringRow = False
            dgvVacuumBag.MasterTemplate.ShowHeaderCellButtons = True

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try
    End Sub
    Private Sub Clear_Form()
        Try
            dgvVacuumBag.RowCount = 0
            txtRBagName.Text = ""
            txtRIssueWt.Text = ""
            txtRIssuePr.Text = ""
            btnSave.Text = "&Save"
            Fr_Mode = FormState.AStateMode
            btnSave.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnUUpdate_Click(sender As Object, e As EventArgs) Handles BtnUUpdate.Click
        Me.Clear_Form()
        If cmbUBagNo.SelectedIndex <= 0 Then
            MessageBox.Show("Please Select Bag No To Edit Records")
        Else
            'cmbItemScrapBag.SelectedIndex = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value
            cmbRBagNo.Text = Me.cmbUBagNo.EditorControl.CurrentRow.Cells(0).Value
            cmbRBagNo.Tag = Me.cmbUBagNo.EditorControl.CurrentRow.Cells(1).Value
            BtnREdit.Text = "Update"
            btnRSave.Enabled = False
            Me.FillGridU(cmbUBagNo.Text.Trim)
            'btnRSave.Enabled = True
            'BtnREdit.Text = "Edit"
            tbVaccumeBag.SelectedIndex = 1
        End If
    End Sub
    Private Sub FillGridU(ByVal sUBagNo As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetailsRUpdate(CStr(sUBagNo))
        dgvReceiveVacuum.DataSource = Nothing
        dgvReceiveVacuum.DataSource = dttable
        Me.Total()
        Me.FetchUsedBagsDetails(sUBagNo)
        Me.GetSrNo(dgvReceiveVacuum)
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvReceiveVacuum.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function fetchAllDetailsRUpdate(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchVacuumWtDetails", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Trim(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub FetchUsedBagsDetails(sUBagNo)
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchReceivedVaccume", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", sUBagNo, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtRBagName.Text = dtData.Rows(0).Item("BagName").ToString()
                txtRIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtRIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtRWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtRRecieveWt.Text = dtData.Rows(0).Item("RecieveWt").ToString()
                'txtRTotalWt.Text =dtData.Rows(0).Item("RecieveWt").ToString()
                txtRSample.Text = dtData.Rows(0).Item("TFSampleWt").ToString()
                txtRCarbon.Text = dtData.Rows(0).Item("CarbonRecieve").ToString()
                'txtUGrossLoss.Text = dtData.Rows(0).Item("GrossLossWt").ToString()
            Else
                'MessageBox.Show("No Data Found !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

    End Sub

    Private Sub dgvFinalUpdate_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvFinalUpdate.CellDoubleClick
        If dgvFinalUpdate.Rows.Count > 0 Then
            Dim UsedDetailsId As Integer = dgvFinalUpdate.Rows(e.RowIndex).Cells(0).Value.ToString()
            Me.Clear_Form()
            fillDetailsFromListView(UsedDetailsId)
            btnUSave.Text = "Update"
            BtnUUpdate.Enabled = False
            tbVaccumeBag.SelectedIndex = 2
        End If
    End Sub
    Private Sub fillDetailsFromListView(ByVal UsedDetailsId As Integer)
        Dim dtData As New DataTable
        dtData = fetchAllDetailsById(CInt(UsedDetailsId))
        If dtData.Rows.Count > 0 Then
            cmbUBagNo.Text = dtData.Rows(0).Item("BagSrNo").ToString()
            txtUTransId.Text = dtData.Rows(0).Item("UsedBagId").ToString()
            txtUBagName.Text = dtData.Rows(0).Item("BagName").ToString()
            ULFailTransDt.Text = dtData.Rows(0).Item("UsedBagDt").ToString()
            txtUreceiveWt.Text = dtData.Rows(0).Item("RecieveWt").ToString()
            txtUreceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
            txtUreceiveFineWt.Text = dtData.Rows(0).Item("RecieveFineWt").ToString()

            txtUissueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
            txtUissuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
            txtUissueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()

            txtUWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
            txtUcarbonReceive.Text = dtData.Rows(0).Item("CarbonRecieve").ToString()
        End If
        dgvFinalUpdate.ReadOnly = True
        tbVaccumeBag.SelectedIndex = 2
    End Sub

    Private Sub tbVaccumeBag_TabIndexChanged(sender As Object, e As EventArgs) Handles tbVaccumeBag.TabIndexChanged
        If tbVaccumeBag.TabIndex = 0 Then
            btnCancel_Click(sender, e)
        ElseIf tbVaccumeBag.TabIndex = 1 Then
            btnRCancel_Click(sender, e)
        ElseIf tbVaccumeBag.TabIndex = 2 Then
            btnUCancel_Click(sender, e)
        ElseIf tbVaccumeBag.TabIndex = 3 Then
            Me.FillUpdatedData()
        End If
    End Sub

    Private Sub tbVaccumeBag_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbVaccumeBag.SelectedIndexChanged
        If tbVaccumeBag.TabIndex = 0 Then
            btnCancel_Click(sender, e)
        ElseIf tbVaccumeBag.TabIndex = 1 Then
            btnRCancel_Click(sender, e)
        ElseIf tbVaccumeBag.TabIndex = 2 Then
            btnUCancel_Click(sender, e)
        ElseIf tbVaccumeBag.TabIndex = 3 Then
            Me.FillUpdatedData()
        End If
    End Sub

    Private Function ReceiveValidate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbRBagNo.Text.Trim()) Then
                MessageBox.Show("Select Bag No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
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
                'ElseIf cmbRBagNo.Text.Trim.Length > 0 Then
                '    MessageBox.Show("Select VaccumeBag No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                '    cmbRBagNo.Focus()
                Return False
            ElseIf txtRWtOnScale.Text <= 0 Then
                MessageBox.Show("Enter Wt On Scale Zero Not Allow...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            ElseIf txtRRecieveWt.Text <= 0 Then
                MessageBox.Show("Enter Lagdi Received Zero Not Allow...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
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
                'ElseIf cmbUBagNo.Text.Trim.Length > 0 Then
                '    MessageBox.Show("Select VaccumeBag No. To Update...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                '    cmbUBagNo.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub cmbUBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUBagNo.SelectedIndexChanged
        If cmbUBagNo.SelectedIndex >= 0 Then
            Me.fetchUpdateVaccumBag()
        End If
    End Sub
End Class