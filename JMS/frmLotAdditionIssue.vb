Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Public Class frmLotAdditionIssue
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer
    Dim GridDoubleClick As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim dttable As DataTable = New DataTable()
    Private Objerr As New ErrorProvider()

    Dim iReceiptId As Int16
    Dim iReceiptDetailId As Int16
    Dim iIssueId As Int16
    Dim iTransId As Int16

    Dim dBalanceWt As Double
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
    Private Sub fillVoucher()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetStockData", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_Receipt_Select", CommandType.StoredProcedure, parameters.ToArray())

        'Assign DataTable as DataSource.
        Rmccmb.DataSource = Nothing
        Rmccmb.DataSource = dt
        Rmccmb.DisplayMember = "VoucherNo"
        Rmccmb.ValueMember = "IssueId"

        Rmccmb.Columns(1).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(5).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(7).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(8).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(9).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(10).TextAlignment = ContentAlignment.MiddleRight

        Rmccmb.Columns(0).IsVisible = False
        Rmccmb.Columns(2).IsVisible = False
        Rmccmb.Columns(3).IsVisible = False
        Rmccmb.Columns(4).IsVisible = False
        Rmccmb.Columns(6).IsVisible = False
        Rmccmb.Columns(11).IsVisible = False

        Me.Rmccmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.Rmccmb.AutoSizeDropDownToBestFit = True

        Me.Rmccmb.AutoFilter = True
        Dim filter As New FilterDescriptor()
        filter.PropertyName = Me.Rmccmb.DisplayMember
        filter.Operator = FilterOperator.Contains
        Me.Rmccmb.EditorControl.MasterTemplate.FilterDescriptors.Add(filter)
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
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtLotIssueNo.Tag) Then

            Try
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@LId", txtLotIssueNo.Tag, DbType.Int16))
                End With

                dbManager.Delete("SP_LotAdditionIssue_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Clear_Form()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()

            LotADt.Focus()
            LotADt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub Rmccmb_GotFocus(sender As Object, e As EventArgs) Handles Rmccmb.GotFocus
        Me.Rmccmb.MultiColumnComboBoxElement.ShowPopup()
    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start

            txtLotIssueNo.Tag = ""
            txtLotIssueNo.Clear()
            LotADt.Value = DateTime.Now()

            cmbLotNo.Items.Clear()

            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()
            cmbToLabour.SelectedIndex = 0

            'cmbGridItem.SelectedIndex = 0
            cmbItem.SelectedIndex = 0
            cmbItem.Text = ""

            txtBalanceWt.Clear()
            txtBalancePr.Clear()
            txtFineWt.Clear()
            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1

            cmbItemType.Text = ""
            cmbItem.Enabled = True
            'cmbGridItem.SelectedIndex = 0
            'cmbGridItem.Enabled = True

            txtItemName.Tag = ""
            txtItemName.Clear()

            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtRemark.Clear()

            lblTotalIssuePr.Text = "0.00"
            lblTotalIssueWt.Text = "0.00"
            lblTotalFineWt.Text = "0.00"

            dgvLotAddition.RowCount = 0
            dgvIssue.RowCount = 0
            dgvReceive.RowCount = 0

            '' For Detail Field End

            GridDoubleClick = False

            Me.bindDataGridView()

            lblFineWt.Text = "0.00"
            lblGTotalIssuePr.Text = "0.00"
            lblGTotalIssueWt.Text = "0.00"
            lbGTotalFineWt.Text = "0.00"

            Fr_Mode = FormState.AStateMode

            dttable = GetLotAdditionNo()

            LotADt.Focus()
            LotADt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmNewLotAdditionIssue_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()

        Me.fillLotNo()
        Me.fillLabour()
        Me.fillGridItemName()

        Me.bindDataGridView()
    End Sub
    Private Sub fillLotNo()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)

        Try
            cmbLotNo.DataSource = Nothing
            cmbLotNo.Items.Clear()

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
    Private Sub fillGridItemName()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillOnlyItemName", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbItem.DataSource = dt
            cmbItem.DisplayMember = "ItemName"
            cmbItem.ValueMember = "ItemId"

            cmbItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillLabour()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillLabour", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbToLabour.DataSource = dt
            cmbToLabour.DisplayMember = "LabourName"
            cmbToLabour.ValueMember = "LabourId"

            cmbToLabour.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbToLabour.AutoCompleteDataSource = AutoCompleteSource.ListItems

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
            ''cmbToLabour.Enabled = False
        End Try
    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If Not dgvLotAddition.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLotNo.Focus()
                Return False
            End If

            If cmbLotNo.Text.Trim() = "" Then
                MessageBox.Show("Enter Lot Number !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbLotNo.Focus()
                Return False
            ElseIf cmbToLabour.SelectedIndex = -1 Or cmbToLabour.SelectedIndex = 0 Then
                MessageBox.Show("Select To Employee !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbToLabour.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim iOperationId As Integer = 22    ''Operation Id for Lot Addition Issue
        Dim iOperationTypeId As Integer = 9 ''Operation Type Id for Lot Addition Issue

        Dim GridSrNo As String = Nothing
        Dim ItemType As String = Nothing
        Dim SlipBagNo As String = Nothing
        Dim ItemId As String = Nothing
        Dim IssuePr As String = Nothing
        Dim IssueWt As String = Nothing
        Dim FineWt As String = Nothing
        Dim Remarks As String = Nothing

        Dim ReceiptId As String = Nothing
        Dim ReceiptDetailId As String = Nothing
        Dim IssueId As String = Nothing
        Dim TransId As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(LotADt.Value.ToString())
        alParaval.Add(iOperationId)
        alParaval.Add(iOperationTypeId)
        alParaval.Add(cmbLotNo.Text.Trim)
        alParaval.Add(cmbItem.SelectedValue)
        alParaval.Add(txtLotIssueNo.Text.Trim())
        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(cmbToLabour.SelectedValue)

        For Each row As GridViewRowInfo In dgvLotAddition.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemType = Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = Convert.ToString(row.Cells(2).Value)
                    ItemId = Val(row.Cells(3).Value)
                    IssueWt = Val(row.Cells(5).Value)
                    IssuePr = CDbl(row.Cells(6).Value)
                    FineWt = Val(row.Cells(7).Value)
                    Remarks = (row.Cells(8).Value)
                    ReceiptId = Val(row.Cells(9).Value)
                    ReceiptDetailId = Val(row.Cells(10).Value)
                    IssueId = Val(row.Cells(11).Value)
                    TransId = Val(row.Cells(12).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemType = ItemType & "|" & Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = SlipBagNo & "|" & Convert.ToString(row.Cells(2).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(3).Value)
                    IssueWt = IssueWt & "|" & Val(row.Cells(5).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(6).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(7).Value)
                    Remarks = Remarks & "|" & (row.Cells(8).Value)
                    ReceiptId = ReceiptId & "|" & Val(row.Cells(9).Value)
                    ReceiptDetailId = ReceiptDetailId & "|" & Val(row.Cells(10).Value)
                    IssueId = IssueId & "|" & Val(row.Cells(11).Value)
                    TransId = TransId & "|" & Val(row.Cells(12).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemType)
        alParaval.Add(SlipBagNo)
        alParaval.Add(ItemId)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)
        alParaval.Add(FineWt)
        alParaval.Add(Remarks)
        alParaval.Add(ReceiptId)
        alParaval.Add(ReceiptDetailId)
        alParaval.Add(IssueId)
        alParaval.Add(TransId)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HLotAdditionDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1

                .Add(dbManager.CreateParameter("@HOperationId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationTypeId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HLotNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotAdditionNo", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@FrKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@ToKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIsOpening", 1, DbType.Boolean))

                ''For Transaction
                .Add(dbManager.CreateParameter("@TReceiveWt", lblGTotalIssueWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@TReceivePr", lblGTotalIssuePr.Text.Trim(), DbType.String))

                .Add(dbManager.CreateParameter("@TIssueWt", txtBalanceWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@TIssuePr", txtBalancePr.Text.Trim, DbType.String))
                ''For Transaction

                .Add(dbManager.CreateParameter("@DItemType", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DSlipBagNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRemarks", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiptId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiptDetailsId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DTransId", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_LotAdditionIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.Items.Count > 0 Then
            fillHeaderFromListViewI(cmbLotNo.Text.Trim())
        End If

        ''Fill Issue, Receive Data Start
        Me.fillReceiveData(cmbLotNo.Text.Trim())
        GridReceiveTotal()

        Me.fillIssueData(cmbLotNo.Text.Trim())
        GridIssueTotal()
        ''Fill Issue, Receive Data End

        Me.CalculateBalanceTotal()
    End Sub
    Private Sub UpdateData()
        Dim alParaval As New ArrayList

        Dim iOperationId As Integer = 6 ''Operation Id for Lot Addition Issue
        Dim iOperationTypeId As Integer = 9 ''Operation Type Id for Lot Addition Issue

        Dim GridSrNo As String = Nothing

        Dim ReceiptId As String = Nothing
        Dim ReceiptDetailId As String = Nothing

        Dim ItemType As String = Nothing
        Dim SlipBagNo As String = Nothing
        Dim ItemId As String = Nothing
        Dim IssuePr As String = Nothing
        Dim IssueWt As String = Nothing
        Dim FineWt As String = Nothing
        Dim Remarks As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(LotADt.Value.ToString())
        alParaval.Add(iOperationId)
        alParaval.Add(iOperationTypeId)
        alParaval.Add(cmbLotNo.Text.Trim)
        alParaval.Add(cmbItem.SelectedValue)
        alParaval.Add(txtLotIssueNo.Text.Trim())
        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(cmbToLabour.SelectedValue)

        For Each row As GridViewRowInfo In dgvLotAddition.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemType = Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = Convert.ToString(row.Cells(2).Value)
                    ItemId = Val(row.Cells(3).Value)
                    IssueWt = Val(row.Cells(5).Value)
                    IssuePr = CDbl(row.Cells(6).Value)
                    FineWt = Val(row.Cells(7).Value)
                    Remarks = (row.Cells(8).Value)
                    ReceiptId = Val(row.Cells(9).Value)
                    ReceiptDetailId = Val(row.Cells(10).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemType = ItemType & "|" & Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = SlipBagNo & "|" & Convert.ToString(row.Cells(2).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(3).Value)
                    IssueWt = IssueWt & "|" & Val(row.Cells(5).Value)
                    IssuePr = IssuePr & "|" & Val(row.Cells(6).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(7).Value)
                    Remarks = Remarks & "|" & (row.Cells(8).Value)
                    ReceiptId = ReceiptId & "|" & Val(row.Cells(9).Value)
                    ReceiptDetailId = ReceiptDetailId & "|" & Val(row.Cells(10).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemType)
        alParaval.Add(SlipBagNo)
        alParaval.Add(ItemId)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)
        alParaval.Add(FineWt)
        alParaval.Add(Remarks)
        alParaval.Add(ReceiptId)
        alParaval.Add(ReceiptDetailId)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HLotAdditionDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1

                .Add(dbManager.CreateParameter("@HOperationId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationTypeId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HLotNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotAdditionNo", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@FrKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@ToKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@RId", Val(txtId.Tag), DbType.Int16))

                .Add(dbManager.CreateParameter("@DItemType", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DSlipBagNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DRemarks", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiptId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiptDetailsId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DIssueId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DTransId", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Update("SP_LotAdditionIssue_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Function GetLotAdditionNo() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchLotAdditionNo", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function fetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchDataForI", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub fillHeaderFromListViewI(ByVal sLotNo As String)

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecordForI", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", CStr(sLotNo), DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = True Then
            dr.Read()
            txtId.Tag = dr.Item("LotAdditionId").ToString
            txtLotIssueNo.Tag = dr.Item("ItemId").ToString
            txtLotIssueNo.Text = dr.Item("LotAdditionNo").ToString
            'cmbItem.SelectedIndex = dr.Item("ItemId").ToString
            cmbItem.Text = dr.Item("ItemName").ToString
            txtBalanceWt.Text = dr.Item("IssueWt").ToString
            txtBalancePr.Text = dr.Item("IssuePr").ToString
            lblFineWt.Text = dr.Item("FineWt").ToString
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            cmbToLabour.SelectedIndex = dr.Item("ToKarigarId").ToString
            cmbLotNo.Text = dr.Item("LotNo").ToString
            'cmbLotNo.Enabled = False
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillHeaderFromListViewU(ByVal iLotAddId As Integer)

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecordForU", DbType.String))
            .Add(dbManager.CreateParameter("@LId", CInt(iLotAddId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = True Then
            dr.Read()
            txtId.Tag = dr.Item("LotAdditionId").ToString
            txtLotIssueNo.Tag = dr.Item("ItemId").ToString
            txtLotIssueNo.Text = dr.Item("LotAdditionNo").ToString
            cmbItem.SelectedIndex = dr.Item("ItemId").ToString
            txtBalanceWt.Text = dr.Item("IssueWt").ToString
            txtBalancePr.Text = dr.Item("IssuePr").ToString
            lblFineWt.Text = dr.Item("FineWt").ToString
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            cmbToLabour.SelectedIndex = dr.Item("ToKarigarId").ToString
            cmbLotNo.Text = dr.Item("LotNo").ToString
            cmbLotNo.Enabled = False
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillReceiveData(ByVal sLotNo As String)
        Dim dttable As New DataTable
        dttable = FetchReceiveData(CStr(sLotNo))

        For Each Row As DataRow In dttable.Rows
            dgvReceive.Rows.Add(1, CStr(Row("ItemName")), Format(Val(Row("ReceiveWt")), "0.00"), Format(Val(Row("ReceivePr")), "0.00"), Format(Val(Row("FineWt")), "0.00"))
        Next

        Me.GetSrNo(dgvReceive)

        dgvLotAddition.ReadOnly = True

    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each row As GridViewRowInfo In dgvLotAddition.Rows
                row.Cells(0).Value = row.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function FetchReceiveData(ByVal strLotNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchReceiveData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", CStr(strLotNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub GridReceiveTotal()
        Try
            Dim dSumOfTotalReceivePr As Double = 0
            Dim dSumOfTotalReceiveWt As Double = 0
            Dim dSumOfTotalFineWt As Double = 0

            For Each row As GridViewRowInfo In dgvReceive.Rows
                dSumOfTotalReceiveWt += Convert.ToDecimal(row.Cells(2).Value)
                dSumOfTotalFineWt += Convert.ToDecimal(row.Cells(4).Value)
            Next

            If dgvReceive.RowCount > 0 Then
                lblGridRTotal.Text = Format(dSumOfTotalReceiveWt, "0.00")
                lblGridRFine.Text = Format(dSumOfTotalFineWt, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillIssueData(ByVal sLotNo As String)
        Dim dttable As New DataTable
        dttable = FetchIssueData(CStr(sLotNo))

        For Each Row As DataRow In dttable.Rows
            dgvIssue.Rows.Add(CStr(Row("SrNo")), CStr(Row("ItemName")), Format(Val(Row("IssueWt")), "0.00"), Format(Val(Row("IssuePr")), "0.00"), Format(Val(Row("FineWt")), "0.00"))
        Next

        Me.GetSrNo(dgvReceive)

        dgvLotAddition.ReadOnly = True
    End Sub
    Private Sub txtRemark_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRemark.Validating
        Try
            If cmbItem.Text.Trim <> "" And Val(txtIssueWt.Text.Trim) > 0 And Val(txtIssuePr.Text.Trim) > 0 And txtRemark.Text.Trim <> "" Then

                If dgvLotAddition.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
                    MessageBox.Show("Duplicate Data !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Else
                    Me.fillGrid()
                    Me.Total()
                End If
            Else
                MessageBox.Show("Enter Proper Details !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GridIssueTotal()
        Try
            Dim dSumOfTotalIssuePr As Double = 0
            Dim dSumOfTotalIssueWt As Double = 0
            Dim dSumOfTotalFineWt As Double = 0

            For Each row As GridViewRowInfo In dgvIssue.Rows
                dSumOfTotalIssueWt += Convert.ToDecimal(row.Cells(2).Value)
                dSumOfTotalFineWt += Convert.ToDecimal(row.Cells(4).Value)
            Next

            If dgvIssue.RowCount > 0 Then
                lblGridITotal.Text = Format(dSumOfTotalIssueWt, "0.00")
                lblGridIFine.Text = Format(dSumOfTotalFineWt, "0.00")
                lblGridIPr.Text = Format(Val(lblGridIFine.Text) / Val(lblGridITotal.Text) * 100, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function FetchIssueData(ByVal strLotNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchIssueData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", CStr(strLotNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub CalculateBalanceTotal()
        Try
            Dim dSumOfTotalWt As Double = 0
            Dim dSumOfTotalFineWt As Double = 0

            If dgvIssue.RowCount > 0 OrElse dgvReceive.RowCount > 0 Then
                dSumOfTotalWt = Val(lblGridITotal.Text.Trim) - Val(lblGridRTotal.Text.Trim)
                dSumOfTotalFineWt = Val(lblGridIFine.Text.Trim) - Val(lblGridRFine.Text.Trim)

                txtBalanceWt.Text = Format(dSumOfTotalWt, "0.00")
                txtBalancePr.Text = Format((Val(dSumOfTotalFineWt) / Val(dSumOfTotalWt)) * 100, "0.00")
            Else
                txtBalanceWt.Text = Format(lblGridITotal.Text.Trim, "0.00")
                txtBalancePr.Text = Format((Val(dSumOfTotalFineWt) / Val(dSumOfTotalWt)) * 100, "0.00")
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtIssueWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtIssuePr.Text) * Val(txtIssueWt.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillGrid()
        If GridDoubleClick = False Then
            dgvLotAddition.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbItemType.Text.Trim(),
                                    CStr(Rmccmb.Text.Trim),
                                    Convert.ToInt32(txtItemName.Tag),
                                    txtItemName.Text.Trim(),
                                    Format(Val(txtIssueWt.Text.Trim), "0.00"),
                                    Format(Val(txtIssuePr.Text.Trim), "0.00"),
                                    Format(Val(txtFineWt.Text.Trim), "0.000"),
                                    txtRemark.Text.Trim(),
                                    Val(iReceiptId),
                                    Val(iReceiptDetailId),
                                    Val(iIssueId),
                                    Val(iTransId))

            GetSrNo(dgvLotAddition)
        Else
            dgvLotAddition.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvLotAddition.Rows(TempRow).Cells(1).Value = cmbItemType.Text.Trim
            dgvLotAddition.Rows(TempRow).Cells(2).Value = CStr(Rmccmb.Text.Trim)
            dgvLotAddition.Rows(TempRow).Cells(3).Value = Val(cmbItemType.SelectedIndex)
            dgvLotAddition.Rows(TempRow).Cells(4).Value = cmbItemType.Text.Trim
            dgvLotAddition.Rows(TempRow).Cells(5).Value = Format(Val(txtIssueWt.Text.Trim), "0.00")
            dgvLotAddition.Rows(TempRow).Cells(6).Value = Format(Val(txtIssuePr.Text.Trim), "0.00")
            dgvLotAddition.Rows(TempRow).Cells(7).Value = Format(Val(txtFineWt.Text.Trim), "0.000")
            dgvLotAddition.Rows(TempRow).Cells(8).Value = CStr(txtRemark.Text.Trim)
            dgvIssue.Rows(TempRow).Cells(10).Value = Val(iReceiptId)
            dgvIssue.Rows(TempRow).Cells(11).Value = Val(iReceiptDetailId)
            dgvIssue.Rows(TempRow).Cells(13).Value = Val(iIssueId)
            dgvIssue.Rows(TempRow).Cells(14).Value = Val(iTransId)
            GridDoubleClick = False
        End If

        dgvLotAddition.TableElement.ScrollToRow(dgvLotAddition.Rows.Last)

        txtSrNo.Text = dgvLotAddition.RowCount + 1
        cmbItemType.Text = ""
        Rmccmb.Text = ""

        txtItemName.Tag = ""
        txtItemName.Clear()

        txtIssueWt.Tag = ""
        txtIssueWt.Clear()

        txtIssuePr.Tag = ""
        txtIssuePr.Clear()

        txtFineWt.Clear()
        txtFineWt.Tag = ""

        txtRemark.Clear()
        txtRemark.Tag = ""
        cmbItemType.Focus()

    End Sub
    Private Sub Total()
        Try

            Dim dSumOfTotalIssuePr As Double = 0
            Dim dSumOfTotalIssueWt As Double = 0
            Dim dSumOfTotalFineWt As Double = 0

            Dim gGiTotalIssueWt As Double = 0
            Dim gGiTotalFineWt As Double = 0

            For Each row As GridViewRowInfo In dgvIssue.Rows
                gGiTotalIssueWt += Convert.ToDecimal(row.Cells(2).Value)
                gGiTotalFineWt += Convert.ToDecimal(row.Cells(4).Value)
            Next

            For Each row As GridViewRowInfo In dgvLotAddition.Rows
                dSumOfTotalIssueWt += Convert.ToDecimal(row.Cells(5).Value)
                dSumOfTotalIssuePr += Convert.ToDecimal(row.Cells(6).Value)
                dSumOfTotalFineWt += Convert.ToDecimal(row.Cells(7).Value)
            Next

            If dgvLotAddition.RowCount > 0 Then
                lblTotalIssueWt.Text = Format(dSumOfTotalIssueWt, "0.00")
                lblTotalFineWt.Text = Format(dSumOfTotalFineWt, "0.000")

                lblTotalIssuePr.Text = Format((Val(lblTotalFineWt.Text.Trim) / Val(lblTotalIssueWt.Text.Trim)) * 100, "0.00")

                lblGTotalIssueWt.Text = Format(Val(dSumOfTotalIssueWt) + Val(gGiTotalIssueWt), "0.00")
                lbGTotalFineWt.Text = Format(Val(dSumOfTotalFineWt) + Val(gGiTotalFineWt), "0.000")

                lblGTotalIssuePr.Text = Format((Val(lbGTotalFineWt.Text) / Val(lblGTotalIssueWt.Text)) * 100, "0.00")
            Else
                lblTotalIssueWt.Text = Format(dSumOfTotalIssueWt, "0.000")
                lblTotalFineWt.Text = Format(dSumOfTotalFineWt, "0.000")

                lblTotalIssuePr.Text = "0.000"

                lblGTotalIssueWt.Text = Format(Val(lblTotalIssueWt.Text) + Val(txtBalancePr.Text), "0.000")
                lbGTotalFineWt.Text = Format(Val(lblTotalFineWt.Text) + Val(lblFineWt.Text), "0.000")

                lblGTotalIssuePr.Text = Format(Val(lbGTotalFineWt.Text) / Val(lblGTotalIssueWt.Text) * 100, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmNewLotAdditionIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

            If e.KeyCode = Keys.F2 Then
                cmbItemType.Text = ""
                Rmccmb.Text = ""
                txtItemName.Tag = ""
                txtItemName.Clear()
                txtIssueWt.Clear()
                txtIssuePr.Clear()
                txtFineWt.Tag = ""
                txtFineWt.Clear()
                txtRemark.Clear()
                cmbItemType.Focus()
            End If

            With dgvLotAddition
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
                Me.Total()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbLotNo_GotFocus(sender As Object, e As EventArgs) Handles cmbLotNo.GotFocus
        cmbLotNo.ShowDropDown()
    End Sub
    Private Sub cmbToLabour_GotFocus(sender As Object, e As EventArgs) Handles cmbToLabour.GotFocus
        cmbToLabour.ShowDropDown()
    End Sub
    Private Sub txtIssueWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssueWt.KeyPress
        numdotkeypress(e, txtIssueWt, Me)
    End Sub
    Private Sub txtIssueWt_Leave(sender As Object, e As EventArgs) Handles txtIssueWt.Leave
        txtIssueWt.Text = Format(Val(txtIssueWt.Text), "0.00")
    End Sub
    Private Sub cmbItemType_GotFocus(sender As Object, e As EventArgs) Handles cmbItemType.GotFocus
        cmbItemType.ShowDropDown()
    End Sub
    Private Sub fillDetailsFromListView(ByVal iLotAddId As Integer)
        Dim dttable As New DataTable
        dttable = FetchAllRecords(CInt(iLotAddId))

        For Each Row As DataRow In dttable.Rows
            dgvLotAddition.Rows.Add(1, CStr(Row("ItemType")), CStr(Row("LotNo")), Val(Row("ItemId")), CStr(Row("ItemName")), Format(Val(Row("IssueWt")), "0.00"), Format(Val(Row("IssuePr")), "0.00"), Format(Val(Row("FineWt")), "0.00"), Row("Remarks"), Row("IsChecked"), Val(Row("FineWt")), Val(Row("ReceiptDetailsId")))
        Next

        Me.GetSrNo(dgvLotAddition)
        Me.GetSrNo(dgvIssue)

        dgvLotAddition.ReadOnly = True
    End Sub
    Private Function FetchAllRecords(ByVal iLotAddId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchIsDetailRecord", DbType.String))
                .Add(dbManager.CreateParameter("@LId", CInt(iLotAddId), DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_LotAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub lblTotalIssueWt_TextChanged(sender As Object, e As EventArgs) Handles lblTotalIssueWt.TextChanged
        If lblTotalIssueWt.Text.Trim <> 0 Then
            lblTotalFineWt.Text = Format(Val(lblTotalIssueWt.Text * lblTotalIssuePr.Text) / 100, "0.000")
        End If
    End Sub
    Private Sub lblTotalIssuePr_TextChanged(sender As Object, e As EventArgs) Handles lblTotalIssuePr.TextChanged
        If lblTotalIssuePr.Text.Trim <> 0 Then
            lblTotalFineWt.Text = Format(Val(lblTotalIssueWt.Text * lblTotalIssuePr.Text) / 100, "0.000")
        End If
    End Sub
    Private Sub dgvLotAddition_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvLotAddition.KeyDown
        Try
            If e.KeyCode = Keys.Delete And dgvLotAddition.RowCount > 0 Then
                'dont allow user if any of the grid line is in edit mode.....
                If GridDoubleClick = True Then
                    MessageBox.Show("Row is in Edited Mode, You Cannot Delete This Row")
                    Exit Sub
                End If
                'end of block

                dgvLotAddition.Rows.RemoveAt(dgvLotAddition.CurrentRow.Index)

                Me.GetSrNo(dgvLotAddition)
                Me.Total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtSrNo_GotFocus(sender As Object, e As EventArgs) Handles txtSrNo.GotFocus
        If GridDoubleClick = False Then
            If dgvLotAddition.RowCount > 0 Then
                txtSrNo.Text = Val(dgvLotAddition.Rows(dgvLotAddition.RowCount - 1).Cells(0).Value) + 1
            Else
                txtSrNo.Text = 1
            End If
        End If
    End Sub
    Private Sub txtIssueWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtIssueWt.Validating
        'If Val(txtIssueWt.Text) > Val(txtIssueWt.Tag) Then
        '    e.Cancel = True
        '    Objerr.SetError(txtIssueWt, "Wt should not be greather than Balance Wt. !")
        'Else
        '    Objerr.Clear()
        'End If
    End Sub
    Private Sub dgvLotAddition_CellFormatting(sender As Object, e As CellFormattingEventArgs) Handles dgvLotAddition.CellFormatting
        If Me.dgvLotAddition.Columns(e.ColumnIndex).Name.Equals("GFineWt") Then
            Try
                Me.dgvLotAddition.Rows(e.RowIndex).Cells(5).Value = Format(Val(Me.dgvLotAddition.Rows(e.RowIndex).Cells(3).Value * Val(Me.dgvLotAddition.Rows(e.RowIndex).Cells(4).Value) / 100), "0.000")
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub dgvLotAddition_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvLotAddition.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 Then
                GridDoubleClick = True
                txtSrNo.Text = dgvLotAddition.Rows(e.RowIndex).Cells(0).Value.ToString()
                cmbItemType.Text = dgvLotAddition.Rows(e.RowIndex).Cells(1).Value.ToString()
                Rmccmb.Text = dgvLotAddition.Rows(e.RowIndex).Cells(2).Value.ToString()
                txtItemName.Tag = dgvLotAddition.Rows(e.RowIndex).Cells(3).Value.ToString()
                txtItemName.Text = dgvLotAddition.Rows(e.RowIndex).Cells(4).Value.ToString()
                txtIssueWt.Text = dgvLotAddition.Rows(e.RowIndex).Cells(5).Value.ToString()
                txtIssuePr.Text = dgvLotAddition.Rows(e.RowIndex).Cells(6).Value.ToString()
                txtFineWt.Text = dgvLotAddition.Rows(e.RowIndex).Cells(7).Value.ToString()
                txtRemark.Text = dgvLotAddition.Rows(e.RowIndex).Cells(8).Value.ToString()

                iReceiptId = dgvIssue.Rows(e.RowIndex).Cells(9).Value.ToString()
                iReceiptDetailId = dgvIssue.Rows(e.RowIndex).Cells(10).Value.ToString()
                iIssueId = dgvIssue.Rows(e.RowIndex).Cells(11).Value.ToString()
                iTransId = dgvIssue.Rows(e.RowIndex).Cells(12).Value.ToString()

                TempRow = e.RowIndex
                cmbItemType.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvLotIssue_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvLotIssue.CellDoubleClick
        If dgvLotIssue.SelectedRows.Count = 0 Then Exit Sub

        If dgvLotIssue.Rows.Count > 0 Then
            Dim iLotAddId As Int16 = Me.dgvLotIssue.SelectedRows(0).Cells(0).Value

            Me.Clear_Form()

            Fr_Mode = FormState.EStateMode

            Me.fillHeaderFromListViewU(iLotAddId)

            Me.fillDetailsFromListView(iLotAddId)

            Me.TbLotAdditionIssue.SelectedIndex = 0
        End If
    End Sub
    Private Sub Rmccmb_DropDownClosed(sender As Object, args As RadPopupClosedEventArgs) Handles Rmccmb.DropDownClosed
        If Me.Rmccmb.SelectedIndex > -1 And cmbItemType.SelectedIndex = 0 Then  ''Voucher
            txtItemName.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemId").Value.ToString
            txtItemName.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemName").Value.ToString

            dBalanceWt = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString
            txtIssueWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString

            iReceiptId = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiptId").Value.ToString
            txtIssuePr.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceivePr").Value.ToString

            iReceiptDetailId = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiptDetaild").Value.ToString
            ''txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalFineWt").Value.ToString
        ElseIf Me.Rmccmb.SelectedIndex > -1 And cmbItemType.SelectedIndex = 1 Then  ''Finished Lots
            txtItemName.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemId").Value.ToString
            txtItemName.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemName").Value.ToString

            txtIssueWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiveWt").Value.ToString

            txtIssuePr.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceivePr").Value.ToString

            iTransId = Me.Rmccmb.EditorControl.CurrentRow.Cells("TransId").Value.ToString
            txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("FineWt").Value.ToString
        ElseIf Me.Rmccmb.SelectedIndex > -1 And cmbItemType.SelectedIndex = 2 Then      ''Lot Add. Stock
            txtItemName.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemId").Value.ToString
            txtItemName.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemName").Value.ToString

            iIssueId = Me.Rmccmb.EditorControl.CurrentRow.Cells("IssueId").Value.ToString
            txtIssueWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString

            txtIssuePr.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceivePr").Value.ToString

            txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("FineWt").Value.ToString
        End If
    End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvLotAddition.Rows
                If itm.Cells(2).Value = CStr(Rmccmb.Text.Trim) Or itm.Cells(4).Value = CStr(txtItemName.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists
    End Function
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()

        Try
            dgvLotIssue.DataSource = dtdata
            dgvLotIssue.EnableFiltering = True
            dgvLotIssue.MasterTemplate.ShowFilteringRow = False
            dgvLotIssue.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
End Class