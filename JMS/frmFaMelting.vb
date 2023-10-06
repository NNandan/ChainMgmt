Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Public Class frmFaMelting
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer

    Dim GridDoubleClick As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

    Private Objerr As New ErrorProvider()
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
    Private Sub Clear_Form()
        Try

            '' For Header Field Start
            TransDt.Value = DateTime.Now
            txtMeltingNo.Text = ""
            txtMeltingNo.Clear()

            txtMelting.Clear()
            txtGrossPr.Clear()
            txtItem.Clear()

            txtFrKarigar.Tag = ""
            'txtFrKarigar.Clear()

            txtToKarigar.Tag = ""
            txtToKarigar.Clear()

            txtFineAdd.Clear()

            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1

            cmbItemType.Text = ""

            Rmccmb.Text = ""

            txtItemName.Tag = ""
            txtItemName.Clear()
            txtGrossWt.Tag = ""
            txtGrossWt.Clear()
            txtGrossPr.Clear()
            txtConvertToMelting.Tag = ""
            txtConvertToMelting.Clear()

            'dgvMelting.RowCount = 0

            '' For Detail Field End

            GridDoubleClick = False

            lblTotal.Text = 0.0
            lblAlloyTotal.Text = 0.0
            lblGrossTotal.Text = 0.0

            lblTotalFineWt.Text = 0.00

            txtSilverPr.Clear()
            lblTotalSilverWt.Text = 0.0

            Me.bindDataGridView()

            btnSave.Text = "&Save"

            'Fr_Mode = FormState.AStateMode

            btnSave.Enabled = True
            btnDelete.Enabled = False

            txtFrKarigar.Tag = CInt(UserId)
            txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)

            cmbLotNo.Focus()
            cmbLotNo.Select()
            'cmbLotNo.SelectedValue = 0
            Me.TreeDetailsVisibleFalse()
            ''Me.fillLotNo()
            lblMeltingStockAdd.Visible = True
            txtStockAdd.Visible = True
            lblFineAdd.Visible = True
            txtFineAdd.Visible = True
            lblSilverPr.Visible = True
            txtSilverPr.Visible = True
            lblSilverWt.Visible = True
            lblTotalSilverWt.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmMelting_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLotNo()

        Me.bindDataGridView()

        Me.Clear_Form()

        txtFrKarigar.Tag = CInt(UserId)
        txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)
        Me.TreeDetailsVisibleFalse()
    End Sub
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()

        Try
            dgvMeltingData.DataSource = dtdata
            dgvMeltingData.EnableFiltering = True
            dgvMeltingData.MasterTemplate.ShowFilteringRow = False
            dgvMeltingData.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try

    End Sub
    Private Function fetchAllRecords() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fMelting_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Function fetchAllRecords(ByVal intMeltingId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@MId", CInt(intMeltingId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Melting_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function GetMaxNo() As String
        Dim result As String

        Dim strDateSeq As String = Nothing

        strDateSeq = DateTime.Now.ToString("yyMM")

        strSQL = Nothing
        strSQL = "SELECT MAX(MaxLotNo) AS MaxId FROM vwGetMaxLotNo"

        result = Convert.ToString(dbManager.GetScalarValue(strSQL, CommandType.Text))

        If String.IsNullOrEmpty(result) Then
            GetMaxNo = strDateSeq & "001"
        Else
            GetMaxNo = strDateSeq & Format(Val(result.Substring(5, 2)) + 1, "000")
        End If

    End Function
    Sub fillGrid()

        If GridDoubleClick = False Then
            dgvMelting.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbItemType.Text.Trim(),
                                    CStr(Rmccmb.Text.Trim),
                                    txtItemName.Tag,
                                    txtItemName.Text.Trim,
                                    Format(Val(txtGrossWt.Text.Trim), "0.00"),
                                    Format(Val(txtGrossPr.Text.Trim), "0.00"),
                                    Format(Val(txtFineWt.Text.Trim), "0.000"),
                                    Val(txtGrossPr.Tag),
                                    Val(txtFineWt.Tag),
                                    Val(txtSrNo.Tag))
            GetSrNo(dgvMelting)
        Else
            dgvMelting.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvMelting.Rows(TempRow).Cells(1).Value = cmbItemType.Text.Trim
            dgvMelting.Rows(TempRow).Cells(2).Value = CStr(Rmccmb.Text.Trim)
            dgvMelting.Rows(TempRow).Cells(3).Value = txtItemName.Tag
            dgvMelting.Rows(TempRow).Cells(4).Value = txtItemName.Text.Trim
            dgvMelting.Rows(TempRow).Cells(5).Value = Format(Val(txtGrossWt.Text.Trim), "0.00")
            dgvMelting.Rows(TempRow).Cells(6).Value = Format(Val(txtGrossPr.Text.Trim), "0.00")
            dgvMelting.Rows(TempRow).Cells(7).Value = Format(Val(txtFineWt.Text.Trim), "0.000")
            dgvMelting.Rows(TempRow).Cells(8).Value = Val(txtGrossPr.Tag)
            dgvMelting.Rows(TempRow).Cells(9).Value = Val(txtFineWt.Tag)
            dgvMelting.Rows(TempRow).Cells(10).Value = Val(txtSrNo.Tag)
            GridDoubleClick = False
        End If

        Me.Total()

        dgvMelting.TableElement.ScrollToRow(dgvMelting.Rows.Last)

        txtSrNo.Text = dgvMelting.RowCount + 1
        cmbItemType.Text = ""
        Rmccmb.Text = ""

        txtItemName.Tag = ""
        txtGrossPr.Tag = ""
        txtFineWt.Tag = ""
        txtSrNo.Tag = ""

        txtItemName.Clear()
        txtGrossWt.Clear()
        txtGrossPr.Clear()
        txtFineWt.Clear()

        cmbItemType.Focus()
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvMelting.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvMelting.Rows
                If itm.Cells(4).Value = CStr(txtItemName.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists

    End Function
    Sub Total()
        Dim dblTempTotal As Double = 0

        Try
            lblTotal.Text = 0.00
            lblAlloyTotal.Text = 0.00
            lblGrossTotal.Text = 0.00

            lblTotalFineWt.Text = 0.000

            For Each row As GridViewRowInfo In dgvMelting.Rows
                lblTotal.Text = Format(Val(lblTotal.Text) + Val(row.Cells(5).Value), "0.00")
                lblTotalFineWt.Text = Format(Val(lblTotalFineWt.Text) + Val(row.Cells(7).Value), "0.000")
                lblGrossTotal.Text = Format(Val(lblTotalFineWt.Text * 100) / Val(txtMelting.Text.Trim), "0.00")

                lblAlloyTotal.Text = Format(Val(lblGrossTotal.Text) - Val(lblTotal.Text), "0.00")
            Next

            lblTmpTotal.Text = Val(lblGrossTotal.Text * Val(txtConvertToMelting.Text)) / 100

            txtFineAdd.Text = Format(Val(lblTmpTotal.Text) - Val(lblTotalFineWt.Text), "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbItemType_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbItemType.SelectedIndexChanged
        If cmbItemType.Items.Count > 0 Then
            If cmbItemType.SelectedIndex = 0 Then
                Me.fillBags()
            ElseIf cmbItemType.SelectedIndex = 1 Then
                Me.fillVoucher()
            End If
        End If
    End Sub
    Private Sub fillBags()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetStockData", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        'Assign DataTable as DataSource.
        Rmccmb.DataSource = Nothing
        Rmccmb.DataSource = dt
        Rmccmb.DisplayMember = "BagSrNo"
        Rmccmb.ValueMember = "IssueId"

        Rmccmb.Columns(1).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(3).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(4).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(5).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(6).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(7).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(8).TextAlignment = ContentAlignment.MiddleRight

        Rmccmb.Columns(0).IsVisible = False
        Rmccmb.Columns(3).IsVisible = False
        Rmccmb.Columns(9).IsVisible = False
        Rmccmb.Columns(10).IsVisible = False

        Me.Rmccmb.AutoCompleteMode = AutoCompleteMode.Append
        Me.Rmccmb.AutoSizeDropDownToBestFit = True

        Me.Rmccmb.AutoFilter = True
        Dim filter As New FilterDescriptor()
        filter.PropertyName = Me.Rmccmb.DisplayMember
        filter.Operator = FilterOperator.Contains
        Me.Rmccmb.EditorControl.MasterTemplate.FilterDescriptors.Add(filter)
    End Sub
    Private Sub fillVoucher()
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "GetStockData", DbType.String))
        End With

        dt = dbManager.GetDataTable("SP_fReceipt_Select", CommandType.StoredProcedure, parameters.ToArray())

        'Assign DataTable as DataSource.
        Rmccmb.DataSource = Nothing
        Rmccmb.DataSource = dt
        Rmccmb.DisplayMember = "VoucherNo"
        Rmccmb.ValueMember = "IssueId"

        Rmccmb.Columns(1).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(5).TextAlignment = ContentAlignment.MiddleLeft
        Rmccmb.Columns(6).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(7).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(8).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(9).TextAlignment = ContentAlignment.MiddleRight
        Rmccmb.Columns(11).TextAlignment = ContentAlignment.MiddleRight

        Rmccmb.Columns(0).IsVisible = False
        Rmccmb.Columns(2).IsVisible = False
        Rmccmb.Columns(3).IsVisible = False
        Rmccmb.Columns(4).IsVisible = False
        Rmccmb.Columns(9).IsVisible = False
        Rmccmb.Columns(10).IsVisible = False
        ' Rmccmb.Columns(12).IsVisible = False

        Me.Rmccmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        Me.Rmccmb.AutoSizeDropDownToBestFit = True

        Me.Rmccmb.AutoFilter = True
        Dim filter As New FilterDescriptor()
        filter.PropertyName = Me.Rmccmb.DisplayMember
        filter.Operator = FilterOperator.Contains
        Me.Rmccmb.EditorControl.MasterTemplate.FilterDescriptors.Add(filter)
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

        Dim trans As SqlTransaction = Nothing

        If Objcn.State = ConnectionState.Open Then Objcn.Close()
        Objcn.Open()
        trans = Objcn.BeginTransaction(System.Data.IsolationLevel.Serializable)

        Try
            If btnSave.Text = "&Save" Then
                Me.SaveData()
                Me.SaveIData()
                Me.fillLotNo()
                Me.fillVoucher()
                Me.bindDataGridView()
            End If
            If btnSave.Text = "&Update" Then
                Me.UpdateIData()
                Me.UpdateData()
                Me.fillLotNo()
                Me.bindDataGridView()
                trans.Commit()
            End If
            Me.btnCancel_Click(sender, e)
            Me.fillLotNo()
            Me.bindDataGridView()
        Catch ex As Exception
            trans.Rollback()
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()
            cmbLotNo.SelectedValue = 0
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim GridSrNo As String = Nothing

        Dim ReceiptId As String = Nothing
        Dim ReceiptDetailId As String = Nothing
        Dim UsedBagId As String = Nothing

        Dim ItemType As String = Nothing
        Dim SlipBagNo As String = Nothing
        Dim LotNumber As String = Nothing
        Dim ItemId As String = Nothing
        Dim GrossWt As String = Nothing
        Dim ReceivePr As String = Nothing
        Dim FineWt As String = Nothing

        Dim SilverPr As String = Nothing
        Dim SilverWt As String = Nothing
        Dim AlloyWt As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbLotNo.Text.Trim)
        alParaval.Add(txtItem.Tag)
        alParaval.Add(txtMelting.Text)

        'alParaval.Add(lblTotal.Text)
        alParaval.Add(lblGrossTotal.Text)
        alParaval.Add(txtConvertToMelting.Text)

        alParaval.Add(txtSilverPr.Text)
        alParaval.Add(lblTotalSilverWt.Text)
        alParaval.Add(lblAlloyTotal.Text)

        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(txtToKarigar.Tag)

        ''For Details
        For Each row As GridViewRowInfo In dgvMelting.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemType = Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = Convert.ToString(row.Cells(2).Value)
                    ItemId = Val(row.Cells(3).Value)
                    GrossWt = Val(row.Cells(5).Value)
                    ReceivePr = Val(row.Cells(6).Value)
                    FineWt = Val(row.Cells(7).Value)
                    ReceiptId = Val(row.Cells(8).Value)
                    ReceiptDetailId = Val(row.Cells(9).Value)
                    UsedBagId = Val(row.Cells(10).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemType = ItemType & "|" & Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = SlipBagNo & "|" & Convert.ToString(row.Cells(2).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(3).Value)
                    GrossWt = GrossWt & "|" & Val(row.Cells(5).Value)
                    ReceivePr = ReceivePr & "|" & Val(row.Cells(6).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(7).Value)
                    ReceiptId = ReceiptId & "|" & Val(row.Cells(8).Value)
                    ReceiptDetailId = ReceiptDetailId & "|" & Val(row.Cells(9).Value)
                    UsedBagId = UsedBagId & "|" & Val(row.Cells(10).Value)
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemType)
        alParaval.Add(SlipBagNo)
        alParaval.Add(ItemId)
        alParaval.Add(GrossWt)
        alParaval.Add(ReceivePr)
        alParaval.Add(FineWt)
        alParaval.Add(ReceiptId)
        alParaval.Add(ReceiptDetailId)
        alParaval.Add(UsedBagId)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HMeltingDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HMeltingLot", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HPercent", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HGrossWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HMeltingConvert", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HSilverPercent", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HSilverWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HAlloyWt", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@HIsOpening", 1, DbType.Boolean))

                ''Details Start
                .Add(dbManager.CreateParameter("@DItemType", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DSlipBagNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemBagId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DGrossWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DGrossPr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@DReceiptId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiptDetailsId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DUsedBagId", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_fMelting_Save", CommandType.StoredProcedure, Hparameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtGrossWt_TextChanged(sender As Object, e As EventArgs) Handles txtGrossWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(txtGrossPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGrossWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrossWt.KeyPress
        numdotkeypress(e, txtGrossWt, Me)
    End Sub
    Private Sub lstMelting_ColumnWidthChanging(sender As Object, e As ColumnWidthChangingEventArgs)
        Dim DisableColumns As Integer() = {0, 1, 2, 3, 4, 5}

        For Each DCol As Integer In DisableColumns
            If e.ColumnIndex = DCol Then
                e.Cancel = True
                e.NewWidth = dgvMeltingData.Columns(DCol).Width
            End If
        Next DCol
    End Sub
    Private Sub txtGrossWt_Leave(sender As Object, e As EventArgs) Handles txtGrossWt.Leave
        txtGrossWt.Text = Format(Val(txtGrossWt.Text), "0.00")
    End Sub
    Private Sub txtRequirePr_TextChanged(sender As Object, e As EventArgs)
        Me.Total()
    End Sub
    Private Sub UpdateData()
        Dim alParaval As New ArrayList

        Dim GridSrNo As String = Nothing

        Dim ReceiptId As String = Nothing
        Dim ReceiptDetailId As String = Nothing
        Dim UsedBagId As String = Nothing

        Dim ItemType As String = Nothing
        Dim SlipBagNo As String = Nothing
        Dim LotNumber As String = Nothing
        Dim ItemId As String = Nothing
        Dim GrossWt As String = Nothing
        Dim ReceivePr As String = Nothing
        Dim FineWt As String = Nothing

        Dim SilverPr As String = Nothing
        Dim SilverWt As String = Nothing
        Dim AlloyWt As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbLotNo.Text.Trim)
        alParaval.Add(txtItem.Tag)
        alParaval.Add(txtMelting.Text)
        'alParaval.Add(txtSilverPr.Text)
        'alParaval.Add(lblTotalSilverWt.Text)
        'alParaval.Add(lblAlloyTotal.Text)
        alParaval.Add(lblGrossTotal.Text)
        alParaval.Add(txtConvertToMelting.Text)
        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(txtToKarigar.Tag)
        For Each row As GridViewRowInfo In dgvMelting.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    ItemType = Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = Convert.ToString(row.Cells(2).Value)
                    ItemId = Val(row.Cells(3).Value)
                    GrossWt = Val(row.Cells(5).Value)
                    ReceivePr = Val(row.Cells(6).Value)
                    FineWt = Val(row.Cells(7).Value)
                    ReceiptId = Val(row.Cells(8).Value)
                    ReceiptDetailId = Val(row.Cells(9).Value)
                    UsedBagId = Val(row.Cells(10).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemType = ItemType & "|" & Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = SlipBagNo & "|" & Convert.ToString(row.Cells(2).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(3).Value)
                    GrossWt = GrossWt & "|" & Val(row.Cells(5).Value)
                    ReceivePr = ReceivePr & "|" & Val(row.Cells(6).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(7).Value)
                    ReceiptId = ReceiptId & "|" & Val(row.Cells(8).Value)
                    ReceiptDetailId = ReceiptDetailId & "|" & Val(row.Cells(9).Value)
                    UsedBagId = UsedBagId & "|" & Val(row.Cells(10).Value)
                End If
            End If
            IRowCount += 1
        Next
        alParaval.Add(ItemType)
        alParaval.Add(SlipBagNo)
        alParaval.Add(ItemId)
        alParaval.Add(GrossWt)
        alParaval.Add(ReceivePr)
        alParaval.Add(FineWt)
        alParaval.Add(ReceiptId)
        alParaval.Add(ReceiptDetailId)
        alParaval.Add(UsedBagId)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@HMeltingDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HMeltingLot", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HPercent", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HGrossWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HSilverPercent", Val(txtSilverPr.Text), DbType.String))
                .Add(dbManager.CreateParameter("@HSilverWt", Val(lblTotalSilverWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@HAlloyWt", Val(lblAlloyTotal.Text), DbType.String))
                .Add(dbManager.CreateParameter("@HMeltingConvert", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@MId", Val(txtMeltingNo.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@HIsOpening", 1, DbType.Boolean))

                .Add(dbManager.CreateParameter("@DItemType", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DSlipBagNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DItemBagId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DGrossWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DGrossPr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@DReceiptId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiptDetailsId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@DUsedBagId", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_Melting_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Function Validate_Fields() As Boolean
        Dim decParts As Double = 0

        Try
            If Not dgvMelting.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            If lblGrossTotal.Text.Contains("-") Then
                MessageBox.Show("Negative Cannot be Save !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            ElseIf lblAlloyTotal.Text.Contains("-") Then
                MessageBox.Show("Alloy Wt. Cannot be Negative !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            'If Decimal.TryParse(lblAlloyTotal.Text, decParts) Then
            '    If decParts <= 0 Then
            '        MessageBox.Show("ERROR: Value must be a positive number!")
            '        Return False
            '    End If
            'Else
            '    MessageBox.Show("ERROR: Value must be numeric!")
            '    Return False
            'End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub Rmccmb_GotFocus(sender As Object, e As EventArgs) Handles Rmccmb.GotFocus
        Me.Rmccmb.MultiColumnComboBoxElement.ShowPopup()
    End Sub
    Private Sub dgvMelting_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvMelting.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And dgvMelting.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvMelting.Rows(e.RowIndex).Cells(0).Value.ToString()
                cmbItemType.Text = dgvMelting.Rows(e.RowIndex).Cells(1).Value.ToString()
                Rmccmb.Text = CStr(dgvMelting.Rows(e.RowIndex).Cells(2).Value)

                txtItemName.Tag = CInt(dgvMelting.Rows(e.RowIndex).Cells(3).Value)
                txtItemName.Text = dgvMelting.Rows(e.RowIndex).Cells(4).Value.ToString()

                txtGrossWt.Tag = dgvMelting.Rows(e.RowIndex).Cells(5).Value.ToString()
                txtGrossWt.Text = dgvMelting.Rows(e.RowIndex).Cells(5).Value.ToString()

                txtGrossPr.Text = dgvMelting.Rows(e.RowIndex).Cells(6).Value.ToString()
                txtFineWt.Text = dgvMelting.Rows(e.RowIndex).Cells(7).Value.ToString()

                txtGrossPr.Tag = dgvMelting.Rows(e.RowIndex).Cells(8).Value.ToString()
                txtFineWt.Tag = dgvMelting.Rows(e.RowIndex).Cells(9).Value.ToString()
                txtSrNo.Tag = dgvMelting.Rows(e.RowIndex).Cells(10).Value.ToString()
                TempRow = e.RowIndex
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillHeaderFromListView(ByVal intMeltingId As Integer)

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@MId", CInt(intMeltingId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Melting_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            lblMeltingStockAdd.Visible = True
            txtStockAdd.Visible = True
            lblFineAdd.Visible = True
            txtFineAdd.Visible = True
            lblSilverPr.Visible = True
            txtSilverPr.Visible = True
            lblSilverWt.Visible = True
            lblTotalSilverWt.Visible = True
            TransDt.Text = dr.Item("MeltingDt").ToString
            txtMeltingNo.Tag = dr.Item("MeltingId").ToString
            cmbLotNo.Text = dr.Item("LotNo").ToString()
            txtItem.Tag = dr.Item("ItemId").ToString
            txtItem.Text = dr.Item("ItemName").ToString
            txtMelting.Text = dr.Item("RequirePr").ToString()
            txtConvertToMelting.Text = dr.Item("ConvertToMelting").ToString()
            lblAlloyTotal.Text = dr.Item("GrossWt").ToString
            txtSilverPr.Text = dr.Item("SilverPr").ToString
            lblTotalSilverWt.Text = dr.Item("SilverWt").ToString
            txtToKarigar.Tag = dr.Item("ToKarigarId").ToString
            txtToKarigar.Text = dr.Item("ToKarigar").ToString
            txtTreeNo.Tag = dr.Item("NewLotId").ToString
            Dim TransId As Integer
            TransId = dr.Item("NewLotId").ToString
            Dim dtable As DataTable = CheckEditTransNoExist(TransId)
            If dtable.Rows.Count > 0 Then
                txtTreeNo.Text = dtable.Rows(0).Item("TreeNo").ToString
                txtTotGoldNeed.Text = dtable.Rows(0).Item("TotalGoldNeed").ToString
                txtScrapPer.Text = dtable.Rows(0).Item("ScrapPer").ToString & "%"
                txtFinePer.Text = dtable.Rows(0).Item("FinePerToAdd").ToString & "%"
                txtScrapWtGm.Text = dtable.Rows(0).Item("ScrapWtGm").ToString
                txtFineWtGm.Text = Format(Val(txtTotGoldNeed.Text) * Val(txtMelting.Text) / 100, "0.00")
            Else
                MsgBox("Something went Wrong Vaibhavi PLease Check")
            End If
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillDetailsFromListView(ByVal MeltingId As Integer)
        Dim dttable As New DataTable
        dttable = fetchAllRecords(CInt(MeltingId))

        For Each ROW As DataRow In dttable.Rows
            dgvMelting.Rows.Add(1, CStr(ROW("ItemType")), CStr(ROW("SlipBagNo")), Val(ROW("ItemBagId")), CStr(ROW("ItemName")), Format(Val(ROW("GrossWt")), "0.00"), Format(Val(ROW("GrossPr")), "0.00"), Format(Val(ROW("FineWt")), "0.000"), Val(ROW("ReceiptId")), Val(ROW("ReceiptDetailsId")), Val(ROW("UsedBagId")))
        Next

        Me.GetSrNo(dgvMelting)
        Me.Total()

        dgvMelting.ReadOnly = True
    End Sub
    'Private Sub cmbItemType_GotFocus(sender As Object, e As EventArgs) Handles cmbItemType.GotFocus
    '    cmbItemType.ShowDropDown()
    'End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtRequirePr_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtItem.Focus()
        End If
    End Sub
    Private Sub txtGrossWt_Validating(sender As Object, e As CancelEventArgs) Handles txtGrossWt.Validating
        Dim dsumOfWt As Double = 0

        If GridDoubleClick = True Then
            dsumOfWt = CDbl(Val(txtGrossWt.Tag) + Val(lblTotal.Text))

            If Val(txtGrossWt.Text) > Val(dsumOfWt) Then
                e.Cancel = True
                Objerr.SetError(txtGrossWt, "Wt should Not be greather than Balance Wt. !")
            Else
                Objerr.Clear()
            End If
        Else
            If Val(txtGrossWt.Text) > Val(txtGrossWt.Tag) Then
                e.Cancel = True
                Objerr.SetError(txtGrossWt, "Wt should Not be greather than Balance Wt. !")
            Else
                Objerr.Clear()
            End If
        End If
    End Sub
    Private Sub Rmccmb_DropDownClosed(sender As Object, args As RadPopupClosedEventArgs) Handles Rmccmb.DropDownClosed

        If Me.Rmccmb.SelectedIndex > -1 And cmbItemType.SelectedIndex = 0 Then
            txtItemName.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemId").Value.ToString
            txtItemName.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemName").Value.ToString

            txtGrossWt.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString
            txtGrossWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString

            txtGrossPr.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiptDetaild").Value.ToString
            txtGrossPr.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReportPr").Value.ToString

            txtFineWt.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiptId").Value.ToString
            'Today Get Fine Wt On Balance Wt Not On Receive Wt
            txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("FineWt").Value.ToString
            'txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalFineWt").Value.ToString

            txtSrNo.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("UsedBagId").Value.ToString
        ElseIf Me.Rmccmb.SelectedIndex > -1 And cmbItemType.SelectedIndex = 1 Then
            txtItemName.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemId").Value.ToString
            txtItemName.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemName").Value.ToString

            txtGrossWt.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString
            txtGrossWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString

            txtGrossPr.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiptDetaild").Value.ToString
            txtGrossPr.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceivePr").Value.ToString

            txtFineWt.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiptId").Value.ToString
            'txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("FineWt").Value.ToString
            txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalFineWt").Value.ToString
            txtSrNo.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("UsedBagId").Value.ToString
        End If

    End Sub
    Private Sub frmMelting_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                Me.SelectNextControl(Me.ActiveControl, True, True, True, False) 'for Select Next Control
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                ' When Alt + S is pressed, the Click event for the print
                ' button is raised.
                btnSave().PerformClick()
            End If

            If e.KeyCode = Keys.F2 Then
                cmbItemType.Text = ""
                Rmccmb.Text = ""
                txtItemName.Tag = ""
                txtItemName.Clear()
                txtGrossWt.Clear()
                txtGrossPr.Clear()
                txtFineWt.Tag = ""
                txtFineWt.Clear()
                cmbItemType.Focus()
            End If

            With dgvMelting
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
                Me.Total()
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmMelting_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
        Me.Parent = Nothing
        e.Cancel = True
    End Sub
    Private Sub fillLotNo()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillMeltingLotNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
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
            cmbLotNo.ValueMember = "NewLotId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub txtMelting_TextChanged(sender As Object, e As EventArgs) Handles txtMelting.TextChanged
        txtStockAdd.Text = Format(Val(txtConvertToMelting.Text) - Val(txtMelting.Text), "0.00")
        If txtFineWtGm.Visible = True Then
            txtFineWtGm.Text = Format(Val(txtTotGoldNeed.Text) * Val(txtMelting.Text) / 100, "0.00")
        End If
    End Sub
    Private Sub txtConvertToMelting_TextChanged(sender As Object, e As EventArgs) Handles txtConvertToMelting.TextChanged
        txtStockAdd.Text = Format(Val(txtConvertToMelting.Text) - Val(txtMelting.Text), "0.00")
    End Sub
    Private Sub txtFineWt_Validating(sender As Object, e As CancelEventArgs) Handles txtFineWt.Validating
        Try
            If cmbItemType.Text.Trim <> "" And txtItemName.Text.Trim <> "" And Val(txtGrossWt.Text.Trim) > 0 And Val(txtGrossPr.Text.Trim) > 0 Then

                Me.fillGrid()
                Me.Total()
            Else
                'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtMelting_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMelting.KeyPress
        numdotkeypress(e, txtMelting, Me)
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        Me.Clear_Form()
        If cmbLotNo.SelectedIndex > 0 Then
            Dim iLotId As Integer = Val(cmbLotNo.SelectedValue)
            Me.fillHeaderFromNewLotNo(iLotId)
        End If
    End Sub
    Private Sub txtGrossWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrossWt.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtGrossPr.Focus()
        End If
    End Sub
    Private Sub txtGrossPr_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGrossPr.KeyDown
        If e.KeyCode = Keys.Tab Then
            txtFineWt.Focus()
        End If
    End Sub
    Private Sub txtMelting_Leave(sender As Object, e As EventArgs) Handles txtMelting.Leave
        txtMelting.Text = Format(Val(txtMelting.Text), "0.00")
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtMeltingNo.Tag) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()

                    With parameters
                        .Add(dbManager.CreateParameter("@MId", Val(txtMeltingNo.Tag), DbType.Int16))
                    End With

                    dbManager.Delete("SP_Melting_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.btnCancel_Click(sender, e)

                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            Else
                MessageBox.Show("Please Select A Record !!!")
            End If
        End If
    End Sub
    Private Sub txtSilverPr_TextChanged(sender As Object, e As EventArgs) Handles txtSilverPr.TextChanged
        Try
            lblTotalSilverWt.Text = Format((Val(lblAlloyTotal.Text) * Val(txtSilverPr.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtSilverPr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSilverPr.KeyPress
        numdotkeypress(e, txtMelting, Me)
    End Sub

    Private Sub lstMelting_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvMeltingData.CellDoubleClick
        Try
            dgvMelting.RowCount = 0
            If dgvMeltingData.Rows.Count > 0 Then
                Dim MeltingId As Integer = Me.dgvMeltingData.SelectedRows(0).Cells(0).Value
                Fr_Mode = FormState.EStateMode
                Me.fillHeaderFromListView(MeltingId)
                Me.fillDetailsFromListView(MeltingId)
                Me.TbMelting.SelectedIndex = 0
            End If
        Catch
        End Try
    End Sub
    Private Sub clear()
        cmbLotNo.SelectedValue = 0
        txtMelting.Clear()
        txtFrKarigar.Tag = CInt(UserId)
        txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)
        cmbLotNo.Focus()
        cmbLotNo.Select()
        txtItem.Clear()
        lblTotal.Text = 0.0
        lblAlloyTotal.Text = 0.0
        lblGrossTotal.Text = 0.0
        lblTotalFineWt.Text = 0.00
        txtSilverPr.Clear()
        lblTotalSilverWt.Text = 0.0
        'dgvMelting.RowCount = 0

    End Sub

    Private Sub Rmccmb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Rmccmb.SelectedIndexChanged
        If Me.Rmccmb.SelectedIndex > -1 And cmbItemType.SelectedIndex = 0 Then
            txtItemName.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemId").Value.ToString
            txtItemName.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemName").Value.ToString

            txtGrossWt.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString
            txtGrossWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString

            txtGrossPr.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiptDetaild").Value.ToString
            txtGrossPr.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReportPr").Value.ToString

            txtFineWt.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiptId").Value.ToString
            'Today Get Fine Wt On Balance Wt Not On Receive Wt
            txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("FineWt").Value.ToString
            'txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalFineWt").Value.ToString

            txtSrNo.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("UsedBagId").Value.ToString
        ElseIf Me.Rmccmb.SelectedIndex > -1 And cmbItemType.SelectedIndex = 1 Then
            txtItemName.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemId").Value.ToString
            txtItemName.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ItemName").Value.ToString

            txtGrossWt.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString
            txtGrossWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalanceWt").Value.ToString

            txtGrossPr.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiptDetaild").Value.ToString
            txtGrossPr.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceivePr").Value.ToString

            txtFineWt.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("ReceiptId").Value.ToString
            'txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("FineWt").Value.ToString
            txtFineWt.Text = Me.Rmccmb.EditorControl.CurrentRow.Cells("BalFineWt").Value.ToString
            txtSrNo.Tag = Me.Rmccmb.EditorControl.CurrentRow.Cells("UsedBagId").Value.ToString
        End If

    End Sub



    Private Sub fillHeaderFromNewLotNo(ByVal intNewLotId As Integer)

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@NId", CInt(intNewLotId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            TransDt.Text = dr.Item("NewLotDt").ToString
            txtConvertToMelting.Tag = dr.Item("ItemId").ToString
            txtConvertToMelting.Text = dr.Item("MeltingValue").ToString
            txtItem.Tag = dr.Item("ItemId").ToString
            txtItem.Text = dr.Item("ItemName").ToString
            txtToKarigar.Tag = dr.Item("LabourId").ToString
            txtToKarigar.Text = dr.Item("LabourName").ToString
            txtTreeNo.Tag = dr.Item("OperationTypeId").ToString
            Dim TransId As Integer
            TransId = dr.Item("NewLotId").ToString
            If txtTreeNo.Tag = "7" Or txtTreeNo.Tag = "9" Then
                If Not CheckTransNoExist() Then Exit Sub
                Me.ClearTreeDetails()
                Me.TreeDetailsVisibleTrue()
                Me.FetchTreeDetails(TransId)
            Else
                Me.ClearTreeDetails()
                Me.TreeDetailsVisibleFalse()
            End If
        End If
        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub FetchTreeDetails(ByVal TransId As Integer)
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchTreeDetailsByTransId", DbType.String))
                .Add(dbManager.CreateParameter("@NId", CInt(TransId), DbType.Int16))
            End With

            Dim dr As SqlDataReader = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

            If dr.HasRows = False Then
                Exit Sub
            Else
                dr.Read()
                txtTreeNo.Text = dr.Item("TreeNo").ToString
                txtTotGoldNeed.Text = dr.Item("TotalGoldNeed").ToString
                txtScrapPer.Text = dr.Item("ScrapPer").ToString & "%"
                txtFinePer.Text = dr.Item("FinePerToAdd").ToString & "%"
                txtScrapWtGm.Text = dr.Item("ScrapWtGm").ToString

            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Function CheckTransNoExist() As Boolean
        Try
            Dim dt As DataTable = New DataTable()
            If cmbLotNo.SelectedIndex > 0 Then
                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "CheckTransIdExist", DbType.String))
                End With
                Dim dr As SqlDataReader = dbManager.GetDataReader("SP_NewLotNo_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

                If dr.HasRows = True Then
                    Return True
                Else
                    cmbLotNo.Text = ""
                    cmbLotNo.Text = ""
                    cmbLotNo.SelectedIndex = 0
                    MsgBox("'Data Not Found..!'")
                    Return False
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Private Function CheckEditTransNoExist(ByVal TransId As Integer) As DataTable
        Dim dt As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchEditTreeDetails", DbType.String))
                .Add(dbManager.CreateParameter("@NId", CInt(TransId), DbType.Int16))
            End With
            ' Dim dt As DataTable = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())
            dt = dbManager.GetDataTable("SP_NewLotNo_Select", CommandType.StoredProcedure, parameters.ToArray())
            If dt.Rows.Count > 0 Then
                Me.ClearTreeDetails()
                Me.TreeDetailsVisibleTrue()
            Else
                Me.ClearTreeDetails()
                Me.TreeDetailsVisibleFalse()
            End If

        Catch ex As Exception
        End Try

        Return dt
    End Function
    Private Sub ClearTreeDetails()
        txtScrapPer.Text = ""
        txtFinePer.Text = ""
        txtScrapWtGm.Text = ""
        txtFineWtGm.Text = ""
        txtTreeNo.Text = ""
        txtTotGoldNeed.Text = ""
    End Sub
    Private Sub TreeDetailsVisibleTrue()
        GrpTreeDetails.Visible = True
        lblScrapPer.Visible = True
        txtScrapPer.Visible = True
        lblFinePer.Visible = True
        txtFinePer.Visible = True
        lblValue.Visible = True
        txtScrapWtGm.Visible = True
        txtFineWtGm.Visible = True
        lblTreeNo.Visible = True
        txtTreeNo.Visible = True
        lblTotGoldNeed.Visible = True
        txtTotGoldNeed.Visible = True
    End Sub

    Private Sub TbMelting_TabIndexChanged(sender As Object, e As EventArgs) Handles TbMelting.TabIndexChanged
        If TbMelting.SelectedIndex = 1 Then
            lblMeltingStockAdd.Visible = False
            txtStockAdd.Visible = False
            lblFineAdd.Visible = False
            txtFineAdd.Visible = False
            lblSilverPr.Visible = False
            txtSilverPr.Visible = False
            lblSilverWt.Visible = False
            lblTotalSilverWt.Visible = False
        Else
            lblMeltingStockAdd.Visible = True
            txtStockAdd.Visible = True
            lblFineAdd.Visible = True
            txtFineAdd.Visible = True
            lblSilverPr.Visible = True
            txtSilverPr.Visible = True
            lblSilverWt.Visible = True
            lblTotalSilverWt.Visible = True
        End If
    End Sub

    Private Sub TbMelting_Click(sender As Object, e As EventArgs) Handles TbMelting.Click
        If TbMelting.SelectedIndex = 1 Then
            lblMeltingStockAdd.Visible = False
            txtStockAdd.Visible = False
            lblFineAdd.Visible = False
            txtFineAdd.Visible = False
            lblSilverPr.Visible = False
            txtSilverPr.Visible = False
            lblSilverWt.Visible = False
            lblTotalSilverWt.Visible = False
        Else
            lblMeltingStockAdd.Visible = True
            txtStockAdd.Visible = True
            lblFineAdd.Visible = True
            txtFineAdd.Visible = True
            lblSilverPr.Visible = True
            txtSilverPr.Visible = True
            lblSilverWt.Visible = True
            lblTotalSilverWt.Visible = True
        End If
    End Sub

    Private Sub TreeDetailsVisibleFalse()
        GrpTreeDetails.Visible = False
        lblScrapPer.Visible = False
        txtScrapPer.Visible = False
        lblFinePer.Visible = False
        txtFinePer.Visible = False
        lblValue.Visible = False
        txtScrapWtGm.Visible = False
        txtFineWtGm.Visible = False
        lblTreeNo.Visible = False
        txtTreeNo.Visible = False
        lblTotGoldNeed.Visible = False
        txtTotGoldNeed.Visible = False
    End Sub
    Private Sub SaveIData()

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@DMaterialId", 1, DbType.Int16))
                .Add(dbManager.CreateParameter("@DItemId", Val(txtItem.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(cmbLotNo.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@DIssueWt", (lblGrossTotal.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DIssueQty", 1, DbType.String))
                .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))
            End With

            dbManager.Insert("SP_FIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateIData()
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@ActionType", "UpdateMelting", DbType.String))
                .Add(dbManager.CreateParameter("@NewLotNo", Convert.ToString(cmbLotNo.Text), DbType.String))
                .Add(dbManager.CreateParameter("@NCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_NewLotNo_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            'MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
End Class