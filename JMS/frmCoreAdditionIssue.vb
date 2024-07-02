Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Public Class frmCoreAdditionIssue
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim GridDoubleClick As Boolean

    Dim TempRow As Integer

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim iItemId As Int16 = 0
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
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
                    Me.btnSave.Text = "&Save"
                    Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit"
                    Me.btnSave.Text = "&Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub frmCoreAdditionIssueNew_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()
        Me.fillLabour()
        Me.fillLotNo()
        Me.bindDataGridView()
    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            Me.TransDt.CustomFormat = "dd/MM/yyyy"
            Me.TransDt.Value = DateTime.Now

            cmbLotNo.SelectedIndex = 0
            Rmccmb.Text = ""

            txtFrKarigar.Tag = ""
            txtFrKarigar.Text = ""
            cmbTLabour.SelectedIndex = 0
            ''For Header Field End

            ''For Detail Field Start
            txtSrNo.Text = 1
            cmbItemType.Text = ""

            txtItemName.Clear()
            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtFineWt.Clear()
            txtRemarks.Clear()

            dgvCore.RowCount = 0

            '' For Detail Field End

            GridDoubleClick = False

            txtGoldWt.Clear()
            txtKDMWt.Clear()
            txtCoreWt.Clear()
            txtTotalWt.Clear()

            txtGoldPr.Clear()
            txtKDMPr.Clear()
            txtCorePr.Clear()
            txtTotalPr.Clear()

            txtGoldFt.Clear()
            txtKDMFt.Clear()
            txtCoreFt.Clear()
            txtTotalFt.Clear()

            Me.bindDataGridView()

            btnSave.Text = "&Save"

            Fr_Mode = FormState.AStateMode

            btnSave.Enabled = True
            btnDelete.Enabled = False

            txtFrKarigar.Tag = CInt(UserId)
            txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub fillLotNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoForLotAddition", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbLotNo.DataSource = dt
            cmbLotNo.DisplayMember = "LotNo"
            cmbLotNo.ValueMember = "TransId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtTransNo.Text) Then

            Try
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@CId", Val(txtTransNo.Text), DbType.Int16))
                End With

                dbManager.Delete("SP_CoreAdditionIssue_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Clear_Form()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub SaveData()
        Dim iOperationTypeId As Integer = 13 ''Operation Id for Core Addition Issue

        Dim alParaval As New ArrayList

        Dim GridSrNo As String = Nothing
        Dim ItemType As String = Nothing
        Dim SlipBagNo As String = Nothing
        Dim ItemName As String = Nothing
        Dim IssueWt As String = Nothing
        Dim IssuePr As String = Nothing
        Dim FineWt As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(iOperationTypeId)
        alParaval.Add(cmbLotNo.Text)
        alParaval.Add(txtGoldWt.Text)
        alParaval.Add(txtGoldPr.Text)
        alParaval.Add(txtGoldFt.Text)

        alParaval.Add(iItemId)
        alParaval.Add(txtTotalWt.Text)
        alParaval.Add(txtTotalPr.Text)

        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(cmbTLabour.SelectedValue)

        ''For Details
        For Each row As GridViewRowInfo In dgvCore.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemType = Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = Convert.ToString(row.Cells(2).Value)
                    ItemName = row.Cells(3).Value.ToString()
                    IssueWt = Val(row.Cells(4).Value)
                    IssuePr = Val(row.Cells(5).Value)
                    FineWt = Val(row.Cells(6).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemType = ItemType & "|" & Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = SlipBagNo & "|" & Convert.ToString(row.Cells(2).Value)
                    ItemName = ItemName & "|" & row.Cells(3).Value.ToString()
                    IssueWt = IssueWt & "|" & Val(row.Cells(4).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(5).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(6).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemType)
        alParaval.Add(SlipBagNo)
        alParaval.Add(ItemName)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)
        alParaval.Add(FineWt)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HCoreIDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationTypeId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotNo", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HGrossWt", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HGrossPr", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HGrossFw", alParaval.Item(iValue), DbType.String))
                iValue += 1

                ''For Transaction Receive Start
                .Add(dbManager.CreateParameter("@TItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@TRecWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@TRecPr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                ''For Transaction Receive End

                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))

                ''Details Start
                .Add(dbManager.CreateParameter("@DItemType", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DSlipBagNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemName", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_CoreAdditionIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Sub cmbItemType_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbItemType.SelectedIndexChanged
        If cmbItemType.Items.Count > 0 Then
            If cmbItemType.SelectedIndex = 0 Then
                Me.fillVoucher()
            ElseIf cmbItemType.SelectedIndex = 1 Then
                Me.fillFinishedLots()
            ElseIf cmbItemType.SelectedIndex = 2 Then
                Me.fillLotAddition()
            End If
        End If
    End Sub
    Private Sub txtRemarks_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRemarks.Validating
        Try
            If cmbItemType.Text.Trim <> "" And Val(txtIssueWt.Text.Trim) > 0 Then
                Me.ChkDuplicate()
                Me.Total()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UpdateData()
        Dim iOperationTypeId As Integer = 13 ''Operation Id for Core Addition Issue

        Dim alParaval As New ArrayList

        Dim GridSrNo As String = Nothing
        Dim ItemType As String = Nothing
        Dim SlipBagNo As String = Nothing
        Dim ItemName As String = Nothing
        Dim IssueWt As String = Nothing
        Dim IssuePr As String = Nothing
        Dim FineWt As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(iOperationTypeId)
        alParaval.Add(cmbLotNo.Text)
        alParaval.Add(txtGoldWt.Text)
        alParaval.Add(txtGoldPr.Text)
        alParaval.Add(txtGoldFt.Text)

        alParaval.Add(iItemId)
        alParaval.Add(txtTotalWt.Text)
        alParaval.Add(txtTotalPr.Text)

        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(cmbTLabour.SelectedValue)

        ''For Details
        For Each row As GridViewRowInfo In dgvCore.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemType = Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = Convert.ToString(row.Cells(2).Value)
                    ItemName = row.Cells(3).Value.ToString()
                    IssueWt = Val(row.Cells(4).Value)
                    IssuePr = Val(row.Cells(5).Value)
                    FineWt = Val(row.Cells(6).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemType = ItemType & "|" & Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = SlipBagNo & "|" & Convert.ToString(row.Cells(2).Value)
                    ItemName = ItemName & "|" & row.Cells(3).Value.ToString()
                    IssueWt = IssueWt & "|" & Val(row.Cells(4).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(5).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(6).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemType)
        alParaval.Add(SlipBagNo)
        alParaval.Add(ItemName)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)
        alParaval.Add(FineWt)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HCoreIDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationTypeId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotNo", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HGrossWt", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HGrossPr", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HGrossFw", alParaval.Item(iValue), DbType.String))
                iValue += 1

                ''For Transaction Receive Start
                .Add(dbManager.CreateParameter("@TItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@TRecWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@TRecPr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                ''For Transaction Receive End

                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))

                ''Details Start
                .Add(dbManager.CreateParameter("@DItemType", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DSlipBagNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemName", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_CoreAdditionIssue_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If String.IsNullOrWhiteSpace(cmbTLabour.Text.Trim()) Or Convert.ToInt32(cmbTLabour.SelectedIndex) = -1 Then
                MessageBox.Show("Select Labour !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbTLabour.Focus()
                Return False
            End If

            If FormState.EStateMode AndAlso String.IsNullOrEmpty(txtTransNo.Text.Trim()) Then
                MessageBox.Show("Select Id !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function fetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Sub fillGrid()

        If GridDoubleClick = False Then
            dgvCore.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbItemType.Text.Trim(),
                                    CStr(Rmccmb.Text.Trim),
                                    txtItemName.Text.Trim(),
                                    Format(Val(txtIssueWt.Text.Trim), "0.00"),
                                    Format(Val(txtIssuePr.Text.Trim), "0.00"),
                                    Format(Val(txtFineWt.Text.Trim), "0.000"),
                                    txtRemarks.Text.Trim)
            GetSrNo(dgvCore)
        Else
            dgvCore.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbItemType.Text.Trim(),
                                    CStr(Rmccmb.Text.Trim),
                                    txtItemName.Tag,
                                    txtItemName.Text.Trim(),
                                    txtIssueWt.Text,
                                    Format(Val(txtIssuePr.Text.Trim), "0.00"),
                                    Format(Val(txtFineWt.Text.Trim), "0.000"),
                                    txtRemarks.Text.Trim())
            GridDoubleClick = False
        End If

        dgvCore.TableElement.ScrollToRow(dgvCore.Rows.Last)

        txtSrNo.Text = dgvCoreIssue.RowCount + 1
        cmbItemType.Text = ""
        Rmccmb.Text = ""

        txtItemName.Clear()
        txtIssueWt.Clear()
        txtIssuePr.Clear()
        txtFineWt.Clear()
        txtRemarks.Clear()

        cmbItemType.Focus()
    End Sub
    Sub Total()
        Dim i As Int16 = 0

        Try
            Dim sKWt As Single = 0
            Dim sKPr As Single = 0
            Dim sKFt As Single = 0

            Dim sCWt As Single = 0
            Dim sCPr As Single = 0
            Dim sCFt As Single = 0

            For Each row As GridViewRowInfo In dgvCore.Rows
                If row.Cells(3).Value.ToString.ToUpper.Contains("KDM") Then
                    sKWt = sKWt + Val(row.Cells(4).Value)
                    sKPr = sKPr + Val(row.Cells(5).Value)
                End If

                If row.Cells(3).Value.ToString.ToUpper.Contains("CORE") Then
                    i = i + 1
                    If i > 1 Then
                        Exit For
                    End If

                    sCWt = sCWt + Val(row.Cells(4).Value)
                    sCPr = sCPr + Val(row.Cells(5).Value)
                End If
            Next

            ''For KDM Wt. Start
            sKFt = (sKWt * sKPr) / 100

            txtKDMWt.Text = Format(Val(sKWt), "0.00")
            txtKDMPr.Text = Format(Val(sKPr), "0.00")
            txtKDMFt.Text = Format(Val(sKFt), "0.000")
            ''For KDM Wt. End

            ''For Cor Wt. Start
            sCFt = (sCWt * sCPr) / 100

            txtCoreWt.Text = Format(Val(sCWt), "0.00")
            txtCorePr.Text = Format(Val(sCPr), "0.00")
            txtCoreFt.Text = Format(Val(sCFt), "0.000")
            'For Cor Wt. End
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvCore.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.Text.Trim <> "" Then
            Me.getLastLotNoVAmt()
        End If
    End Sub
    Private Sub fillVoucher()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetStockData", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        'Assign DataTable as DataSource.
        Rmccmb.DataSource = Nothing
        Rmccmb.DataSource = dt
        Rmccmb.DisplayMember = "VoucherNo"
        Rmccmb.ValueMember = "ReceiptId"

        Rmccmb.Columns(1).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(4).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(5).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(6).TextAlignment = ContentAlignment.MiddleRight

        Rmccmb.Columns(0).IsVisible = False
        Rmccmb.Columns(2).IsVisible = False
        Rmccmb.Columns(3).IsVisible = False

        Rmccmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Rmccmb.AutoSizeDropDownToBestFit = True

        Me.Rmccmb.AutoFilter = True
        Dim filter As New FilterDescriptor()
        filter.PropertyName = Me.Rmccmb.DisplayMember
        filter.Operator = FilterOperator.Contains
        Me.Rmccmb.EditorControl.MasterTemplate.FilterDescriptors.Add(filter)
    End Sub
    Private Sub txtGoldPr_TextChanged(sender As Object, e As EventArgs) Handles txtGoldPr.TextChanged
        Try
            If Not String.IsNullOrWhiteSpace(txtGoldPr.Text.Trim) Then
                txtGoldFt.Text = Format(Val(txtGoldWt.Text) * Val(txtGoldPr.Text) / 100, "0.000")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldWt_TextChanged(sender As Object, e As EventArgs) Handles txtGoldWt.TextChanged
        Try

            If Not String.IsNullOrWhiteSpace(txtGoldWt.Text) Or Not IsNumeric(txtCoreWt.Text) Then
                txtTotalWt.Text = Format((Val(txtGoldWt.Text) + Val(txtKDMWt.Text) + Val(txtCoreWt.Text)), "0.00")
            End If

            If Not String.IsNullOrEmpty(txtIssuePr.Text) Then
                txtGoldFt.Text = Format((Val(txtIssueWt.Text) * Val(txtIssuePr.Text)) / 100, "0.000")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillFinishedLots()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetFinishedLots", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray())

        'Assign DataTable as DataSource.
        Rmccmb.DataSource = Nothing

        Rmccmb.DataSource = dt
        Rmccmb.DisplayMember = "LotNo"
        Rmccmb.ValueMember = "ItemId"

        Rmccmb.Columns(2).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(4).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(5).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(6).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(7).TextAlignment = ContentAlignment.MiddleRight

        Rmccmb.Columns(0).IsVisible = False
        Rmccmb.Columns(1).IsVisible = False
        Rmccmb.Columns(3).IsVisible = False

        Me.Rmccmb.AutoCompleteMode = AutoCompleteMode.Append
        Me.Rmccmb.AutoSizeDropDownToBestFit = True

        Me.Rmccmb.AutoFilter = True
        Dim filter As New FilterDescriptor()
        filter.PropertyName = Me.Rmccmb.DisplayMember
        filter.Operator = FilterOperator.Contains
        Me.Rmccmb.EditorControl.MasterTemplate.FilterDescriptors.Add(filter)
    End Sub
    Private Sub Rmccmb_DropDownClosed(sender As Object, args As RadPopupClosedEventArgs) Handles Rmccmb.DropDownClosed
        If Me.Rmccmb.SelectedIndex > -1 And cmbItemType.SelectedIndex = 0 Then                   ''Voucher
            txtItemName.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemId").Value.ToString
            txtItemName.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemName").Value.ToString

            txtIssueWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiveWt").Value.ToString

            If txtItemName.Text.ToString.Contains("Core") Then
                txtIssuePr.Clear()
                txtFineWt.Text = ("0.000")
            Else
                txtIssuePr.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceivePr").Value.ToString
                txtFineWt.Text = Format(CDbl(txtIssueWt.Text) * CDbl(txtIssuePr.Text) / 100, "0.000")
            End If

        ElseIf Me.Rmccmb.SelectedIndex > -1 And cmbItemType.SelectedIndex = 1 Then             ''Voucher
            txtItemName.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemId").Value.ToString
            txtItemName.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemName").Value.ToString

            txtFineWt.Text = Format(CDbl(txtIssueWt.Text) * CDbl(txtIssuePr.Text) / 100, "0.00")
        ElseIf Me.Rmccmb.SelectedIndex > -1 And cmbItemType.SelectedIndex = 2 Then          ''Lot Addition Stock
            txtItemName.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemId").Value.ToString
            txtItemName.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemName").Value.ToString
            txtIssueWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString
            txtIssuePr.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceivePr").Value.ToString

            txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("FineWt").Value.ToString
            txtFineWt.Text = Format(CDbl(txtIssueWt.Text) * CDbl(txtIssuePr.Text) / 100, "0.00")
        End If
    End Sub
    Private Sub txtKDMPr_TextChanged(sender As Object, e As EventArgs) Handles txtKDMPr.TextChanged
        Try
            If btnSave.Text = "&Save" Then
                If txtKDMPr.Text.Trim <> "" Then
                    txtKDMFt.Text = Format((Val(txtKDMWt.Text) * Val(txtKDMPr.Text)) / 100, "0.000")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvCoreIssue_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvCoreIssue.CellDoubleClick
        If dgvCoreIssue.SelectedRows.Count = 0 Then Exit Sub

        If dgvCoreIssue.Rows.Count > 0 Then

            Dim CoreIssueId As Int16 = Me.dgvCoreIssue.SelectedRows(0).Cells(0).Value

            Me.Clear_Form()

            Fr_Mode = FormState.EStateMode

            Me.fillHeaderFromGridView(CoreIssueId)

            Me.fillDetailsFromGridView(CoreIssueId)

            Me.tbCoreIssue.SelectedIndex = 0
        End If
    End Sub
    Private Sub fillLotAddition()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetStockData", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        'Assign DataTable as DataSource.
        Rmccmb.DataSource = Nothing

        Rmccmb.DataSource = dt
        Rmccmb.DisplayMember = "LotAdditionNo"
        Rmccmb.ValueMember = "ItemId"

        Rmccmb.Columns(1).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(3).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(4).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(5).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(6).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(7).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(8).TextAlignment = ContentAlignment.MiddleRight

        Rmccmb.Columns(0).IsVisible = False
        Rmccmb.Columns(2).IsVisible = False
        Rmccmb.Columns(3).IsVisible = False

        Me.Rmccmb.AutoCompleteMode = AutoCompleteMode.Append
        Me.Rmccmb.AutoSizeDropDownToBestFit = True

        Me.Rmccmb.AutoFilter = True
        Dim filter As New FilterDescriptor()
        filter.PropertyName = Me.Rmccmb.DisplayMember
        filter.Operator = FilterOperator.Contains
        Me.Rmccmb.EditorControl.MasterTemplate.FilterDescriptors.Add(filter)
    End Sub
    Private Sub getLastLotNoVAmt()
        Dim connection As SqlConnection = Nothing

        strSQL = Nothing
        strSQL = "SELECT * FROM  udf_GetMaxLotTransNo('" & cmbLotNo.Text.Trim() & "') ORDER BY MaxTransId"

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@TLotNo", cmbLotNo.Text.Trim(), DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader(strSQL, CommandType.Text, Objcn, parameters.ToArray())

        Try
            If dr.Read = False Then
                Exit Sub
            Else
                txtTransNo.Text = dr.Item("MaxTransId").ToString()
                iItemId = dr.Item("ItemId").ToString()
                'txtOperation.Tag = dr("OperationId").ToString()
                'txtOperation.Text = dr("OperationName").ToString()
                txtGoldWt.Text = Format(Val(dr.Item("ReceiveWt")), "0.00")
                txtGoldPr.Text = Format(Val(dr.Item("ReceivePr")), "0.00")
                txtFrKarigar.Tag = dr.Item("FrLabourId").ToString()
                txtFrKarigar.Text = dr.Item("frKarigarName").ToString()
                cmbTLabour.SelectedIndex = dr.Item("ToLabourId").ToString()

                'txtTotalPr.Text = Format(Val(dr.Item("ReceivePr")), "0.00")
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillHeaderFromGridView(ByVal intCoreIssueId As Integer)
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@CId", CInt(intCoreIssueId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtTransNo.Text = dr.Item("CoreAdditionId").ToString
            cmbLotNo.Text = dr.Item("LotNo").ToString()
            TransDt.Text = dr.Item("CoreAdditionDt").ToString
            txtGoldWt.Text = dr.Item("GrossWt").ToString()
            txtGoldPr.Text = dr.Item("GrossPr").ToString()
            txtGoldFt.Text = dr.Item("GrossFw").ToString()
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            cmbTLabour.SelectedIndex = dr.Item("ToKarigarId").ToString
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub txtCorePr_TextChanged(sender As Object, e As EventArgs) Handles txtCorePr.TextChanged
        Try
            If btnSave.Text = "&Save" Then
                If txtCoreFt.Text.Trim <> "" Then
                    txtCoreFt.Text = Format((Val(txtCoreWt.Text) * Val(txtCorePr.Text)) / 100, "0.000")
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtKDMWt_TextChanged(sender As Object, e As EventArgs) Handles txtKDMWt.TextChanged
        Try

            If Not String.IsNullOrWhiteSpace(txtGoldWt.Text) Or Not IsNumeric(txtCoreWt.Text) Then
                txtTotalWt.Text = Format((Val(txtGoldWt.Text) + Val(txtKDMWt.Text) + Val(txtCoreWt.Text)), "0.00")
            End If

            If Not String.IsNullOrEmpty(txtKDMPr.Text) Then
                txtKDMFt.Text = Format((Val(txtKDMWt.Text) * Val(txtKDMPr.Text)) / 100, "0.000")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtCoreWt_TextChanged(sender As Object, e As EventArgs) Handles txtCoreWt.TextChanged
        Try

            If Not String.IsNullOrWhiteSpace(txtGoldWt.Text) Or Not IsNumeric(txtCoreWt.Text) Then
                txtTotalWt.Text = Format((Val(txtGoldWt.Text) + Val(txtKDMWt.Text) + Val(txtCoreWt.Text)), "0.00")
            End If

            If Not String.IsNullOrEmpty(txtCorePr.Text) Then
                txtCoreFt.Text = Format((Val(txtCoreWt.Text) * Val(txtCorePr.Text)) / 100, "0.000")
            End If

            txtTotalPr.Text = Format((Val(txtTotalFt.Text) / Val(txtTotalWt.Text)) * 100, "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGoldFt_TextChanged(sender As Object, e As EventArgs) Handles txtGoldFt.TextChanged
        Try
            If Not String.IsNullOrWhiteSpace(txtGoldFt.Text) Or Not IsNumeric(txtKDMFt.Text) Then
                txtTotalFt.Text = Format((Val(txtGoldFt.Text) + Val(txtKDMFt.Text) + Val(txtCoreFt.Text)), "0.000")
            End If

            If Not String.IsNullOrEmpty(txtIssuePr.Text) Then
                txtGoldFt.Text = Format((Val(txtIssueWt.Text) * Val(txtIssuePr.Text)) / 100, "0.000")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtCoreFt_TextChanged(sender As Object, e As EventArgs) Handles txtCoreFt.TextChanged
        Try

            If Not String.IsNullOrWhiteSpace(txtGoldFt.Text) Or Not IsNumeric(txtKDMFt.Text) Then
                txtTotalFt.Text = Format((Val(txtGoldFt.Text) + Val(txtKDMFt.Text) + Val(txtCoreFt.Text)), "0.000")
            End If

            If Not String.IsNullOrEmpty(txtCorePr.Text) Then
                txtCoreFt.Text = Format((Val(txtCoreFt.Text) * Val(txtCorePr.Text)) / 100, "0.000")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtKDMFt_TextChanged(sender As Object, e As EventArgs) Handles txtKDMFt.TextChanged
        If Not String.IsNullOrWhiteSpace(txtGoldFt.Text) Or Not IsNumeric(txtKDMFt.Text) Then
            txtTotalFt.Text = Format((Val(txtGoldFt.Text) + Val(txtKDMFt.Text) + Val(txtCoreFt.Text)), "0.000")
        End If
    End Sub
    Private Sub dgvCore_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvCore.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And dgvCore.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvCore.Rows(e.RowIndex).Cells(0).Value.ToString()
                cmbItemType.Text = dgvCore.Rows(e.RowIndex).Cells(1).Value.ToString()
                Rmccmb.Text = CStr(dgvCore.Rows(e.RowIndex).Cells(2).Value)
                txtItemName.Text = dgvCore.Rows(e.RowIndex).Cells(3).Value.ToString()
                txtIssueWt.Text = dgvCore.Rows(e.RowIndex).Cells(4).Value.ToString()
                txtIssuePr.Text = dgvCore.Rows(e.RowIndex).Cells(5).Value.ToString()
                txtFineWt.Text = dgvCore.Rows(e.RowIndex).Cells(6).Value.ToString()
                TempRow = e.RowIndex
            End If

            With dgvCore
                .Rows.Remove(.CurrentRow)
            End With
            Me.Total()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillDetailsFromGridView(ByVal CoreIssueId As Integer)
        Dim dttable As New DataTable

        dttable = fetchAllRecords(CInt(CoreIssueId))

        For Each ROW As DataRow In dttable.Rows
            dgvCore.Rows.Add(1, CStr(ROW("ItemType")), CStr(ROW("SlipBagNo")), CStr(ROW("ItemName")), Format(Val(ROW("IssueWt")), "0.00"), Format(Val(ROW("IssuePr")), "0.00"), Format(Val(ROW("FineWt"))))
        Next

        Me.GetSrNo(dgvCore)
        Me.Total()

        dgvCore.ReadOnly = True
    End Sub
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()
        Try
            dgvCoreIssue.DataSource = dtdata
            dgvCoreIssue.EnableFiltering = True
            dgvCoreIssue.MasterTemplate.ShowFilteringRow = False
            dgvCoreIssue.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Function fetchAllRecords(ByVal iCoreIssueId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
                .Add(dbManager.CreateParameter("@CId", CInt(iCoreIssueId), DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub ChkDuplicate()
        Dim IsDuplicate As Boolean = False

        For i As Integer = 0 To dgvCore.Rows.Count - 1

            If txtItemName.Text = dgvCore.Rows(i).Cells(3).Value.ToString() Then
                IsDuplicate = True
                MessageBox.Show("duple")
                Exit For
            End If
        Next

        If Not IsDuplicate Then
            fillGrid()
        End If

    End Sub
End Class