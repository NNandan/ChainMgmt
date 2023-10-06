Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Public Class frmFReceiveGoldOthers
    Dim strLotNo As String
    Dim TempRow As Integer
    Dim GridDoubleClick As Boolean
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Public Sub New(sLotNo As String)
        InitializeComponent()
        ''For Center
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)
        strLotNo = Convert.ToString(sLotNo)
        RadGridView1.Visible = False
        RadGridView2.Visible = False
        dgvReceive.Visible = True
        dgvIssue.Visible = True
        BtnUpdate.Enabled = False
        'BtnDelete.Enabled = False
        'Me.SetupGridForReceive()
        'Me.SetupGridForIssue()
        'Me.CopyColumnSchema(Me.dgvReceive, Me.dgvIssue)
    End Sub
    Public Sub New(sLotNo As String, MaterialId As String, ReceiveId As String)
        ' This call is required by the designer.
        InitializeComponent()
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)
        strLotNo = Convert.ToString(sLotNo)
        ' Add any initialization after the InitializeComponent() call.
        Me.dgvReceive.Visible = False
        Me.RadGridView1.Visible = True
        Me.RadGridView2.Visible = False
        Me.SetupGridForReceive()
        Me.SetupGridForIssue()
        'For Receive Other Item Update No Need Of This Buttons
        btnSave.Enabled = False
        BtnReceiveOther.Enabled = False
        BtnIssueOther.Enabled = False
        BtnRGoldPlusOther.Enabled = False
        ChkIROther.Enabled = False
        ' For Each row As GridViewRowInfo In dgvReceive.Rows
        FillGridR(sLotNo, MaterialId, ReceiveId)
        ' Next
        'For Each row As GridViewRowInfo In dgvReceive.Rows
        ' FillGridI()
        ' Next
    End Sub
    Public Sub New(sLotNo As String, MaterialId As String, IssueId As String, ItemId As String)
        ' This call is required by the designer.
        InitializeComponent()
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)
        strLotNo = Convert.ToString(sLotNo)
        ' Add any initialization after the InitializeComponent() call.
        Me.dgvIssue.Visible = False
        Me.RadGridView1.Visible = False
        Me.RadGridView2.Visible = True
        Me.SetupGridForReceive()
        Me.SetupGridForIssue()
        'For Issue Other Item Update No Need Of This Buttons
        btnSave.Enabled = False
        BtnReceiveOther.Enabled = False
        BtnIssueOther.Enabled = False
        BtnRGoldPlusOther.Enabled = False
        ChkIROther.Enabled = False
        ' For Each row As GridViewRowInfo In dgvReceive.Rows
        FillGridI(sLotNo, MaterialId, IssueId, ItemId)
        ' Next
        'For Each row As GridViewRowInfo In dgvReceive.Rows
        ' FillGridI()
        ' Next
    End Sub
    Private Sub FillGridI(sLotNo As String, MaterialId As String, IssueId As String, ItemId As String)
        Dim dtdata As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchIOData", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", sLotNo, DbType.String))
            .Add(dbManager.CreateParameter("@MaterialId", MaterialId, DbType.String))
            .Add(dbManager.CreateParameter("@IssueId", IssueId, DbType.String))
        End With

        dtdata = dbManager.GetDataTable("SP_IssueDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        RadGridView2.DataSource = Nothing

        Try
            If dtdata.Rows.Count > 0 Then
                RadGridView2.DataSource = dtdata
                RadGridView2.EnableFiltering = True
                RadGridView2.MasterTemplate.ShowFilteringRow = False
                RadGridView2.MasterTemplate.ShowHeaderCellButtons = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub FillGridR(sLotNo As String, MaterialId As String, ReceiveId As String)
        Dim dtdata As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchROData", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", sLotNo, DbType.String))
            .Add(dbManager.CreateParameter("@MaterialId", MaterialId, DbType.String))
            .Add(dbManager.CreateParameter("@ReceiveId", ReceiveId, DbType.String))
        End With
        dtdata = dbManager.GetDataTable("SP_ReceiveDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        RadGridView1.DataSource = Nothing
        Try
            If dtdata.Rows.Count > 0 Then
                RadGridView1.DataSource = dtdata
                RadGridView1.EnableFiltering = True
                RadGridView1.MasterTemplate.ShowFilteringRow = False
                RadGridView1.MasterTemplate.ShowHeaderCellButtons = True
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub frmReceiveGoldOthers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LoadVisibility()
        Me.fillMaterial()
        Me.fillItemNameOther()
        Me.fillItemName()
        dgvIssue.AutoGenerateColumns = False
        Me.Clear_Form()
    End Sub
    Private Sub LoadVisibility()
        ChkIROther.Visible = False
        Label1.Visible = False
        txtMMaterial.Visible = False
        Label2.Visible = False
        cmbROtherItem.Visible = False
        Label4.Visible = False
        txtRQty.Visible = False
        Label3.Visible = False
        txtRWt.Visible = False
        cmbMaterial.Enabled = False
        cmbOtherItem.Enabled = False
        txtWtPerThousand.Enabled = False
        txtQty.Enabled = False
        txtWt.Enabled = False
        GBoxReceive.Visible = True
        dgvReceive.Visible = True
        'lblTotal.Visible = False
        'lblTotalPcs.Visible = False
        'lblTotalWt.Visible = False
        cmbIMaterial.Enabled = False
        cmbIOtherItem.Enabled = False
        txtIWtPerThousand.Enabled = False
        txtIQty.Enabled = False
        txtIWt.Enabled = False
        dgvIssue.Visible = True
        GBoxIssue.Visible = True
        Label11.Visible = False
        txtRMaterial.Visible = False
        Label12.Visible = False
        txtMItem.Visible = False
        Label14.Visible = False
        txtMQty.Visible = False
        Label13.Visible = False
        txtMWt.Visible = False
        lblMWrkDone.Visible = False
        ChkRWrkDone.Visible = False
    End Sub
    Sub fillGrid()

        If GridDoubleClick = False Then
            dgvIssue.Rows.Add(Val(cmbIMaterial.SelectedValue),
                                    CStr(cmbIMaterial.Text.Trim()),
                                    Val(cmbIOtherItem.SelectedValue),
                                    CStr(cmbIOtherItem.Text.Trim),
                                    Format(Val(txtIWtPerThousand.Text.Trim), "0.00"),
                                    Format(Val(txtIQty.Text.Trim), "0.00"),
                                    Format(Val(txtIWt.Text.Trim), "0.000"))
        Else
            dgvIssue.Rows(TempRow).Cells(0).Value = cmbIOtherItem.SelectedIndex
            dgvIssue.Rows(TempRow).Cells(1).Value = cmbIOtherItem.Text.Trim
            dgvIssue.Rows(TempRow).Cells(2).Value = cmbIOtherItem.SelectedIndex
            dgvIssue.Rows(TempRow).Cells(3).Value = cmbIOtherItem.Text.Trim
            dgvIssue.Rows(TempRow).Cells(4).Value = Format(CDbl(txtIWtPerThousand.Text.Trim), "0.00")
            dgvIssue.Rows(TempRow).Cells(5).Value = Format(CDbl(txtIQty.Text.Trim), "0.00")
            dgvIssue.Rows(TempRow).Cells(6).Value = Format(CDbl(txtIWt.Text.Trim), "0.00")
            GridDoubleClick = False
        End If
        Me.Total()
        dgvIssue.TableElement.ScrollToRow(dgvIssue.Rows.Last)
        cmbIMaterial.SelectedIndex = 0
        cmbIOtherItem.SelectedIndex = 0
        txtIWtPerThousand.Clear()
        txtIQty.Clear()
        txtIWt.Clear()
        cmbIMaterial.Focus()
    End Sub
    Sub fillGridReceive()
        If dgvReceive.Visible = True Then
            With dgvReceive
                ChkIROther.Visible = True
                ChkIROther.Enabled = True
                ChkIROther.Checked = False
                ChkRWrkDone.Checked = True
                If GridDoubleClick = False Then
                    dgvReceive.Rows.Add(Val(cmbMaterial.SelectedValue),
                                        CStr(cmbMaterial.Text.Trim()),
                                        Val(cmbOtherItem.SelectedValue),
                                        CStr(cmbOtherItem.Text.Trim),
                                        Format(Val(txtWtPerThousand.Text.Trim), "0.00"),
                                        Format(Val(txtQty.Text.Trim), "0.00"),
                                        Format(Val(txtWt.Text.Trim), "0.000"))
                Else
                    dgvReceive.Rows(TempRow).Cells(0).Value = cmbOtherItem.SelectedIndex
                    dgvReceive.Rows(TempRow).Cells(1).Value = cmbOtherItem.Text.Trim
                    dgvReceive.Rows(TempRow).Cells(2).Value = cmbOtherItem.SelectedIndex
                    dgvReceive.Rows(TempRow).Cells(3).Value = cmbOtherItem.Text.Trim
                    dgvReceive.Rows(TempRow).Cells(4).Value = Format(CDbl(txtWtPerThousand.Text.Trim), "0.00")
                    dgvReceive.Rows(TempRow).Cells(5).Value = Format(CDbl(txtQty.Text.Trim), "0.00")
                    dgvReceive.Rows(TempRow).Cells(6).Value = Format(CDbl(txtWt.Text.Trim), "0.00")
                    GridDoubleClick = False
                End If
                Me.Total()
                dgvReceive.TableElement.ScrollToRow(dgvReceive.Rows.Last)
                cmbMaterial.SelectedIndex = 0
                cmbOtherItem.SelectedIndex = 0
                txtWtPerThousand.Clear()
                txtQty.Clear()
                txtWt.Clear()
                cmbMaterial.Focus()
            End With
        End If
        If RadGridView1.Visible = True Then
            With RadGridView1
                ChkIROther.Visible = True
                ChkIROther.Enabled = True
                ChkIROther.Checked = False
                ChkRWrkDone.Checked = True
                If GridDoubleClick = False Then
                    RadGridView1.Rows.Add(Val(cmbMaterial.SelectedValue),
                                        CStr(cmbMaterial.Text.Trim()),
                                        Val(cmbOtherItem.SelectedValue),
                                        CStr(cmbOtherItem.Text.Trim),
                                        Format(Val(txtWtPerThousand.Text.Trim), "0.00"),
                                        Format(Val(txtQty.Text.Trim), "0.00"),
                                        Format(Val(txtWt.Text.Trim), "0.000"))
                Else
                    RadGridView1.Rows(TempRow).Cells(0).Value = cmbOtherItem.SelectedIndex
                    RadGridView1.Rows(TempRow).Cells(1).Value = cmbOtherItem.Text.Trim
                    RadGridView1.Rows(TempRow).Cells(2).Value = cmbOtherItem.SelectedIndex
                    RadGridView1.Rows(TempRow).Cells(3).Value = cmbOtherItem.Text.Trim
                    RadGridView1.Rows(TempRow).Cells(4).Value = Format(CDbl(txtWtPerThousand.Text.Trim), "0.00")
                    RadGridView1.Rows(TempRow).Cells(5).Value = Format(CDbl(txtQty.Text.Trim), "0.00")
                    RadGridView1.Rows(TempRow).Cells(6).Value = Format(CDbl(txtWt.Text.Trim), "0.00")
                    GridDoubleClick = False
                End If
                Me.Total()
                dgvReceive.TableElement.ScrollToRow(dgvReceive.Rows.Last)
                cmbMaterial.SelectedIndex = 0
                cmbOtherItem.SelectedIndex = 0
                txtWtPerThousand.Clear()
                txtQty.Clear()
                txtWt.Clear()
                cmbMaterial.Focus()
            End With
        End If
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvReceive.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtWtPerThous_TextChanged(sender As Object, e As EventArgs) Handles txtWtPerThousand.TextChanged
        Try
            With RadGridView1
                If GridDoubleClick = False Then
                    If txtWtPerThousand.Text.Trim.Length > 0 Then
                        txtWt.Text = Val((txtWtPerThousand.Text) / 1000) * Val(txtQty.Text)
                    End If
                Else
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtQty_TextChanged(sender As Object, e As EventArgs) Handles txtQty.TextChanged
        Try
            With RadGridView1
                If GridDoubleClick = False Then
                    If txtQty.Text.Trim.Length > 0 Then
                        txtWt.Text = Val((txtWtPerThousand.Text) / 1000) * Val(txtQty.Text)
                    End If
                Else
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub
        Try
            Me.SaveData()
            Me.btnCancel_Click(sender, e)
            Me.Close()
            Dim ObjFrm As New frmFIssueReceive
            ObjFrm.ShowDialog()
            ObjFrm.BringToFront()
            ObjFrm.Focus()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub fillMaterial()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillNoGoldMaterialCmb", DbType.String))
        End With
        Dim dr = dbManager.GetDataReader("SP_MaterialMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()
        dt.Load(dr)
        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            'row(0) = 0
            'row(1) = "---Select---"
            'dt.Rows.InsertAt(row, 0)
            'Assign DataTable as DataSource.
            cmbMaterial.Enabled = False
            cmbMaterial.DataSource = dt
            cmbMaterial.DisplayMember = "MaterialName"
            cmbMaterial.ValueMember = "MaterialId"
            cmbIMaterial.Enabled = False
            cmbIMaterial.DataSource = dt
            cmbIMaterial.DisplayMember = "MaterialName"
            cmbIMaterial.ValueMember = "MaterialId"
            cmbIMaterial.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbIMaterial.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillItemName()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillfItemCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim Odt As DataTable = New DataTable()
        Odt.Load(dr)
        Dim Cdt As DataTable = Odt.Copy()
        Try
            Dim frow As DataRow = Odt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            Odt.Rows.InsertAt(frow, 0)
            ''Assign DataTable as DataSource.
            cmbROtherItem.DataSource = Odt
            cmbROtherItem.DisplayMember = "ItemName"
            cmbROtherItem.ValueMember = "ItemId"
            cmbROtherItem.Refresh()
            'Set AutoCompleteMode.
            cmbROtherItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbROtherItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = Cdt.NewRow()
            trow(0) = 0
            cmbROtherItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbROtherItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillItemNameOther()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillItemCmbOther", DbType.String))
        End With
        Dim dr = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim Odt As DataTable = New DataTable()
        Odt.Load(dr)
        Dim Cdt As DataTable = Odt.Copy()
        Try
            Dim frow As DataRow = Odt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            Odt.Rows.InsertAt(frow, 0)
            ''Assign DataTable as DataSource.
            cmbOtherItem.DataSource = Odt
            cmbOtherItem.DisplayMember = "ItemName"
            cmbOtherItem.ValueMember = "ItemId"
            cmbOtherItem.Refresh()
            'Set AutoCompleteMode.
            cmbOtherItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbOtherItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = Cdt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            Cdt.Rows.InsertAt(trow, 0)
            cmbIOtherItem.DataSource = Cdt
            cmbIOtherItem.DisplayMember = "ItemName"
            cmbIOtherItem.ValueMember = "ItemId"
            cmbIOtherItem.Refresh()
            'Set AutoCompleteMode.
            cmbIOtherItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbIOtherItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub Total()
        lblITotalPcs.Text = 0.00
        lblITotalWt.Text = 0.00
        Try
            For Each row As GridViewRowInfo In dgvIssue.Rows
                lblITotalPcs.Text = Format(Val(lblITotalPcs.Text) + Val(row.Cells(5).Value), "0.00")
                lblITotalWt.Text = Format(Val(lblITotalWt.Text) + Val(row.Cells(6).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TotalReceive()
        lblTotalPcs.Text = 0.00
        lblTotalWt.Text = 0.00
        Try
            For Each row As GridViewRowInfo In dgvReceive.Rows
                lblTotalPcs.Text = Format(Val(lblTotalPcs.Text) + Val(row.Cells(5).Value), "0.00")
                lblTotalWt.Text = Format(Val(lblTotalWt.Text) + Val(row.Cells(6).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtRQty_TextChanged(sender As Object, e As EventArgs) Handles txtRQty.TextChanged
        txtMQty.Text = txtRQty.Text
    End Sub
    Private Sub lblTotalOtherPcs_TextChanged(sender As Object, e As EventArgs)
        txtMQty.Text = Val(txtRQty.Text) - Val(lblTotalPcs.Text)
    End Sub
    Private Sub txtRWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRWt.KeyPress
        numdotkeypress(e, txtRWt, Me)
    End Sub
    Private Sub txtRQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRQty.KeyPress
        numdotkeypress(e, txtRQty, Me)
    End Sub
    Private Sub txtWtPerThous_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtWtPerThousand, Me)
    End Sub
    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs)
        numdotkeypress(e, txtQty, Me)
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            'Me.Controls.Clear()
            'InitializeComponent()
            'Me.frmReceiveGoldOthers_Load(e, e)
            Clear_Form()
            RadGridView1.Visible = False
            RadGridView2.Visible = False
            dgvReceive.Visible = True
            dgvIssue.Visible = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtWt_Validating(sender As Object, e As CancelEventArgs) Handles txtWt.Validating
        Try
            If cmbMaterial.Text.Trim <> "" And cmbOtherItem.Text.Trim <> "" And Val(txtWtPerThousand.Text.Trim) > 0 And Val(txtQty.Text.Trim) > 0 Then
                Me.fillGridReceive()
                Me.TotalReceive()
            Else
                'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            cmbROtherItem.SelectedIndex = 0
            txtRWt.Clear()
            txtRQty.Clear()
            '' For Header Field End
            '' For Detail Field Start
            cmbMaterial.SelectedIndex = 0
            cmbOtherItem.SelectedIndex = 0
            txtWtPerThousand.Clear()
            txtQty.Clear()
            txtWt.Clear()
            dgvReceive.RowCount = 0
            dgvIssue.RowCount = 0
            '' For Detail Field End
            txtMItem.Clear()
            txtMWt.Clear()
            txtMQty.Clear()
            GridDoubleClick = False
            lblTotalPcs.Text = 0.00
            lblTotalWt.Text = 0.00
            'chkIssue.CheckState = False
            ChkRWrkDone.CheckState = False
            btnSave.Text = "&Save"
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub cmbROtherItem_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbROtherItem.SelectedIndexChanged
        txtMItem.Tag = cmbROtherItem.SelectedValue
        txtMItem.Text = cmbROtherItem.Text
    End Sub
    Private Sub txtWtPerThous_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            txtQty.Focus()
            e.Handled = True
        End If
    End Sub
    Private Sub SetupGridForReceive()
        RadGridView1.AutoGenerateColumns = False
        RadGridView1.AllowDragToGroup = False
        RadGridView1.ShowFilteringRow = False
        RadGridView1.ShowHeaderCellButtons = True
        RadGridView1.ReadOnly = True
        RadGridView1.Columns.Clear()
        Dim ColReceiveId As New GridViewTextBoxColumn()
        ColReceiveId.Name = "ColReceiveId"
        ColReceiveId.HeaderText = "Receive Id."
        ColReceiveId.FieldName = "ReceiveId"
        ColReceiveId.IsVisible = False
        ColReceiveId.TextAlignment = ContentAlignment.MiddleRight
        RadGridView1.MasterTemplate.Columns.Add(ColReceiveId)
        Dim ColMaterialId As New GridViewTextBoxColumn()
        ColMaterialId.Name = "ColMaterialId"
        ColMaterialId.HeaderText = "Material Id."
        ColMaterialId.FieldName = "MaterialId"
        ColMaterialId.IsVisible = False
        ColMaterialId.TextAlignment = ContentAlignment.MiddleRight
        RadGridView1.MasterTemplate.Columns.Add(ColMaterialId)
        Dim ColMaterialName As New GridViewTextBoxColumn()
        ColMaterialName.Name = "ColMaterialName"
        ColMaterialName.HeaderText = "Material Name"
        ColMaterialName.FieldName = "MaterialName"
        ColMaterialName.Width = 113
        RadGridView1.MasterTemplate.Columns.Add(ColMaterialName)
        Dim ColItemId As New GridViewTextBoxColumn()
        ColItemId.Name = "ColItemId"
        ColItemId.HeaderText = "Item Id."
        ColItemId.FieldName = "ItemId"
        ColItemId.IsVisible = False
        ColItemId.TextAlignment = ContentAlignment.MiddleRight
        RadGridView1.MasterTemplate.Columns.Add(ColItemId)
        Dim ColItemName As New GridViewTextBoxColumn()
        ColItemName.Name = "ColItemName"
        ColItemName.HeaderText = "Item Name."
        ColItemName.FieldName = "ItemName"
        ColItemName.Width = 150
        RadGridView1.MasterTemplate.Columns.Add(ColItemName)
        Dim ColReceiveQty As New GridViewDecimalColumn()
        ColReceiveQty.Name = "ColReceiveQty"
        ColReceiveQty.HeaderText = "Qty."
        ColReceiveQty.FieldName = "ReceiveQty"
        ColReceiveQty.TextAlignment = ContentAlignment.MiddleRight
        ColReceiveQty.Width = 100
        RadGridView1.MasterTemplate.Columns.Add(ColReceiveQty)
        Dim ColReceiveWt As New GridViewDecimalColumn()
        ColReceiveWt.Name = "ColReceiveWt"
        ColReceiveWt.HeaderText = "Wt."
        ColReceiveWt.FieldName = "ReceiveWt"
        ColReceiveWt.TextAlignment = ContentAlignment.MiddleRight
        ColReceiveWt.Width = 75
        RadGridView1.MasterTemplate.Columns.Add(ColReceiveWt)
        Dim ColWorkDone As New GridViewCheckBoxColumn()
        ColWorkDone.Name = "ColWorkDone"
        ColWorkDone.HeaderText = "W.D."
        ColWorkDone.FieldName = "WorkDone"
        ColWorkDone.TextAlignment = ContentAlignment.MiddleRight
        ColWorkDone.Width = 45
        RadGridView1.MasterTemplate.Columns.Add(ColWorkDone)
    End Sub
    Private Sub SetupGridForIssue()
        RadGridView2.AutoGenerateColumns = False
        RadGridView2.AllowDragToGroup = False
        RadGridView2.ShowFilteringRow = False
        RadGridView2.ShowHeaderCellButtons = True
        RadGridView2.ReadOnly = True
        RadGridView2.Columns.Clear()
        Dim ColIssueId As New GridViewTextBoxColumn()
        ColIssueId.Name = "ColReceiveId"
        ColIssueId.HeaderText = "Receive Id."
        ColIssueId.FieldName = "IssueId"
        ColIssueId.IsVisible = False
        ColIssueId.TextAlignment = ContentAlignment.MiddleRight
        RadGridView2.MasterTemplate.Columns.Add(ColIssueId)
        Dim ColMaterialId As New GridViewTextBoxColumn()
        ColMaterialId.Name = "ColMaterialId"
        ColMaterialId.HeaderText = "Material Id."
        ColMaterialId.FieldName = "MaterialId"
        ColMaterialId.IsVisible = False
        ColMaterialId.TextAlignment = ContentAlignment.MiddleRight
        RadGridView2.MasterTemplate.Columns.Add(ColMaterialId)
        Dim ColMaterialName As New GridViewTextBoxColumn()
        ColMaterialName.Name = "ColMaterialName"
        ColMaterialName.HeaderText = "Material Name"
        ColMaterialName.FieldName = "MaterialName"
        ColMaterialName.Width = 125
        RadGridView2.MasterTemplate.Columns.Add(ColMaterialName)
        Dim ColItemId As New GridViewTextBoxColumn()
        ColItemId.Name = "ColItemId"
        ColItemId.HeaderText = "Item Id."
        ColItemId.FieldName = "ItemId"
        ColItemId.IsVisible = False
        ColItemId.TextAlignment = ContentAlignment.MiddleRight
        RadGridView2.MasterTemplate.Columns.Add(ColItemId)
        Dim ColItemName As New GridViewTextBoxColumn()
        ColItemName.Name = "ColItemName"
        ColItemName.HeaderText = "Item Name."
        ColItemName.FieldName = "ItemName"
        ColItemName.Width = 135
        RadGridView2.MasterTemplate.Columns.Add(ColItemName)
        Dim ColIssueQty As New GridViewDecimalColumn()
        ColIssueQty.Name = "ColIssueQty"
        ColIssueQty.HeaderText = "Qty."
        ColIssueQty.FieldName = "IssueQty"
        ColIssueQty.TextAlignment = ContentAlignment.MiddleRight
        ColIssueQty.Width = 60
        RadGridView2.MasterTemplate.Columns.Add(ColIssueQty)
        Dim ColIssueWt As New GridViewDecimalColumn()
        ColIssueWt.Name = "ColIssueWt"
        ColIssueWt.HeaderText = "Wt."
        ColIssueWt.FieldName = "IssueWt"
        ColIssueWt.TextAlignment = ContentAlignment.MiddleRight
        ColIssueWt.Width = 75
        RadGridView2.MasterTemplate.Columns.Add(ColIssueWt)
        Dim ColWorkDone As New GridViewCheckBoxColumn()
        ColWorkDone.Name = "ColWorkDone"
        ColWorkDone.HeaderText = "W.D."
        ColWorkDone.FieldName = "WorkDone"
        ColWorkDone.TextAlignment = ContentAlignment.MiddleRight
        ColWorkDone.Width = 45
        RadGridView2.MasterTemplate.Columns.Add(ColWorkDone)
    End Sub
    Private Sub lblTotalWt_TextChanged(sender As Object, e As EventArgs) Handles lblTotalWt.TextChanged
        Try
            txtMWt.Text = Format((Val(txtRWt.Text) - Val(lblTotalWt.Text)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtRWt_TextChanged(sender As Object, e As EventArgs) Handles txtRWt.TextChanged
        Try
            txtMWt.Text = Format((Val(txtRWt.Text) - Val(lblTotalWt.Text)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CopyGridRows(ByVal sourceGrid As RadGridView, ByVal destinationGrid As RadGridView)
        For i As Integer = 0 To sourceGrid.Rows.Count - 1
            Dim values As Object() = New Object(sourceGrid.ColumnCount - 1) {}
            For c As Integer = 0 To sourceGrid.Rows(i).Cells.Count - 1
                values(c) = sourceGrid.Rows(i).Cells(c).Value
            Next
            destinationGrid.Rows.Add(values)
        Next
    End Sub
    Private Sub CopyColumnSchema(ByVal sourceGrid As RadGridView, ByVal destinationGrid As RadGridView)
        For i As Integer = 0 To sourceGrid.ColumnCount - 1
            If sourceGrid.Columns(i).HeaderText <> "" Then
                Dim col As GridViewDataColumn = Me.ParseColumnFromProperty(sourceGrid.Columns(i).DataType)
                col.HeaderText = sourceGrid.Columns(i).HeaderText
                col.DataType = sourceGrid.Columns(i).DataType
                col.Width = sourceGrid.Columns(i).Width
                destinationGrid.Columns.Add(col)
            End If
        Next
    End Sub
    Private Function ParseColumnFromProperty(ByVal type As Type) As GridViewDataColumn
        If type = GetType(Int32) OrElse type = GetType(Decimal) OrElse type = GetType(Single) Then
            Return New GridViewDecimalColumn()
        ElseIf type = GetType(Boolean) Then
            Return New GridViewCheckBoxColumn()
        ElseIf type = GetType(Color) Then
            Return New GridViewColorColumn()
        ElseIf type = GetType(IEnumerable) OrElse type = GetType(ICollection) OrElse type = GetType(IList) Then
            Return New GridViewComboBoxColumn()
        ElseIf type = GetType(DateTime) Then
            Return New GridViewDateTimeColumn()
        ElseIf type = GetType(Image) Then
            Return New GridViewImageColumn()
        Else
            Return New GridViewTextBoxColumn()
        End If
    End Function
    Private Function Validate_Fields() As Boolean
        Try
            'If cmbROtherItem.SelectedIndex = 0 Then
            '    MessageBox.Show("Select Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            '    cmbOtherItem.Focus()
            '    Return False
            'If txtRQty.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Enter Total Gold Pcs. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            '    txtRQty.Focus()
            '    Return False
            'If txtRWt.Text.Trim.Length = 0 Then
            '    MessageBox.Show("Enter Total Gold Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            '    txtRWt.Focus()
            '    Return False
            'If Not dgvReceive.RowCount > 0 Or dgvIssue.RowCount > 0 Then
            '    MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            '    Return False
            'End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub SaveData()
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            'For Issue Other Items
            If dgvIssue.RowCount > 0 Then
                Hparameters.Clear()
                For Each row As GridViewRowInfo In dgvIssue.Rows
                    With Hparameters
                        .Add(dbManager.CreateParameter("@DMaterialId", Val(row.Cells(0).Value), DbType.Int16))
                        .Add(dbManager.CreateParameter("@DItemId", Val(row.Cells(2).Value), DbType.Int16))
                        .Add(dbManager.CreateParameter("@DLotNo", strLotNo, DbType.String))
                        .Add(dbManager.CreateParameter("@DIssueWt", row.Cells(6).Value, DbType.String))
                        .Add(dbManager.CreateParameter("@DIssueQty", row.Cells(5).Value, DbType.String))
                        .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))
                    End With
                    dbManager.Insert("SP_FIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())
                    MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Hparameters.Clear()
                Next
            End If
        Catch
        End Try
        'For ReceiveGold Items
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            If cmbROtherItem.SelectedIndex > 0 And txtMItem.Visible And txtMItem.Text <> "" And txtRWt.Text.Trim() > 0 And txtMQty.Text.Trim() <> "" Then
                With Hparameters
                    .Add(dbManager.CreateParameter("@DMaterialId", (txtRMaterial.Tag), DbType.Int16))
                    .Add(dbManager.CreateParameter("@DItemId", Val(txtMItem.Tag), DbType.Int16))
                    .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(strLotNo), DbType.String))
                    .Add(dbManager.CreateParameter("@DReceiveWt", (txtMWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@DReceiveQty", (txtMQty.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))
                    If ChkRWrkDone.Checked = True Then
                        .Add(dbManager.CreateParameter("@IsWorkDone", 1, DbType.Boolean))
                    End If
                End With
                dbManager.Insert("SP_FReceive_Save", CommandType.StoredProcedure, Hparameters.ToArray())
                MessageBox.Show("Data Saved For Gold Item !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Hparameters.Clear()
            End If
        Catch
        End Try
        'For Receive Other Items
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            If dgvReceive.RowCount > 0 Then
                For Each row As GridViewRowInfo In dgvReceive.Rows
                    With Hparameters
                        .Add(dbManager.CreateParameter("@DMaterialId", Val(row.Cells(0).Value), DbType.Int16))
                        .Add(dbManager.CreateParameter("@DItemId", Val(row.Cells(2).Value), DbType.Int16))
                        .Add(dbManager.CreateParameter("@DLotNo", strLotNo, DbType.String))
                        .Add(dbManager.CreateParameter("@DReceiveWt", row.Cells(6).Value, DbType.String))
                        .Add(dbManager.CreateParameter("@DReceiveQty", row.Cells(5).Value, DbType.String))
                        .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))
                        Dim isSelected As Boolean = Convert.ToBoolean(row.Cells(7).Value)
                        If isSelected Then
                            .Add(dbManager.CreateParameter("@IsWorkDone ", 1, DbType.Boolean))
                        End If
                    End With
                    dbManager.Insert("SP_FReceive_Save", CommandType.StoredProcedure, Hparameters.ToArray())
                    MessageBox.Show("Data Saved For Other Material Items !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Hparameters.Clear()
                Next
            End If
        Catch ex As Exception
            If txtMItem.Visible Then
                MessageBox.Show("Please Select Gold Item And Wt. With Pcs.")
            End If
        End Try
    End Sub
    Private Sub dgvReceive_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvReceive.CellDoubleClick
        Try
            With dgvReceive
                GridDoubleClick = True
            End With
            If dgvReceive.RowCount > -1 Then
                If e.RowIndex = -1 Then Exit Sub
                If e.RowIndex >= 0 And dgvReceive.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                    If dgvReceive.Rows(e.RowIndex).Cells(0).Value.ToString() = "2" Then
                        cmbMaterial.SelectedIndex = dgvReceive.Rows(e.RowIndex).Cells(0).Value.ToString()
                        cmbOtherItem.SelectedValue = dgvReceive.Rows(e.RowIndex).Cells(2).Value.ToString()
                        txtWt.Tag = ""
                        txtWt.Tag = dgvReceive.Rows(e.RowIndex).Cells(2).Value.ToString()
                        cmbOtherItem.Text = ""
                        cmbOtherItem.SelectedText = dgvReceive.Rows(e.RowIndex).Cells(3).Value.ToString()
                        Dim Qty As String
                        Dim Wt As String
                        Dim WtPerThousand As String
                        Qty = CDbl(dgvReceive.Rows(e.RowIndex).Cells(5).Value)
                        Wt = CDbl(dgvReceive.Rows(e.RowIndex).Cells(6).Value)
                        WtPerThousand = Wt * 1000 / Qty
                        txtWtPerThousand.Text = WtPerThousand.ToString
                        txtWt.Text = CStr(dgvReceive.Rows(e.RowIndex).Cells(6).Value)
                        txtQty.Text = CStr(dgvReceive.Rows(e.RowIndex).Cells(5).Value)
                        txtQty.Tag = Val(dgvReceive.Rows(e.RowIndex).Cells(6).Value)
                        TempRow = e.RowIndex
                        With dgvReceive
                            .Rows.Remove(.CurrentRow)
                            GridDoubleClick = False
                        End With
                    End If
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub BtnIssueOther_Click(sender As Object, e As EventArgs) Handles BtnIssueOther.Click
        cmbOtherItem.SelectedIndex = 0
        txtWtPerThousand.Clear()
        txtQty.Clear()
        txtWt.Clear()
        If dgvReceive.Rows.Count > 0 Then
            MsgBox("Please Save Receive Details First")
        Else
            ChkIROther.Visible = False
            'Issue side textboxes visible true
            cmbIMaterial.Visible = True
            cmbIOtherItem.Visible = True
            txtIWtPerThousand.Visible = True
            txtIQty.Visible = True
            txtIWt.Visible = True
            dgvIssue.Visible = True
            GBoxIssue.Visible = True
            'Issue side textboxes Enabled true
            'cmbIMaterial.Enabled = True
            cmbIOtherItem.Enabled = True
            txtIWtPerThousand.Enabled = True
            txtIQty.Enabled = True
            txtIWt.Enabled = True
            dgvIssue.Enabled = True
            GBoxIssue.Enabled = True
            'Receive Side Textboxes Enabled false
            cmbMaterial.Enabled = False
            cmbOtherItem.Enabled = False
            txtWtPerThousand.Enabled = False
            txtQty.Enabled = False
            txtWt.Enabled = False
            dgvReceive.Enabled = False
            GBoxReceive.Enabled = False
            'Receive Gold+Other Visible False
            Label1.Visible = False
            txtMMaterial.Visible = False
            Label2.Visible = False
            cmbROtherItem.Visible = False
            Label4.Visible = False
            txtRQty.Visible = False
            Label3.Visible = False
            txtRWt.Visible = False
            'Issue Side Total Labels Visible true
            lblITotal.Visible = True
            lblITotalPcs.Visible = True
            lblITotalWt.Visible = True
            'Receive Gold Bottom TextBoxes And Label Visible False
            Label11.Visible = False
            txtRMaterial.Visible = False
            Label12.Visible = False
            txtMItem.Visible = False
            Label14.Visible = False
            txtMQty.Visible = False
            Label13.Visible = False
            txtMWt.Visible = False
            lblMWrkDone.Visible = False
            ChkRWrkDone.Visible = False
            'Receive Gold Bottom TextBoxes And Label Enabled False
            Label11.Enabled = False
            txtRMaterial.Enabled = False
            Label12.Enabled = False
            txtMItem.Enabled = False
            Label14.Enabled = False
            txtMQty.Enabled = False
            Label13.Enabled = False
            txtMWt.Enabled = False
            lblMWrkDone.Enabled = False
            ChkRWrkDone.Enabled = False
        End If
    End Sub
    Private Sub BtnRecceiveOther_Click(sender As Object, e As EventArgs) Handles BtnReceiveOther.Click
        cmbIOtherItem.SelectedIndex = 0
        txtIWtPerThousand.Clear()
        txtIQty.Clear()
        txtIWt.Clear()
        If dgvIssue.Rows.Count > 0 Then
            MsgBox("Please Save Issue Details First")
        Else
            ChkIROther.Visible = False
            'Receive Side Textboxes Visible True
            cmbMaterial.Visible = True
            cmbOtherItem.Visible = True
            txtWtPerThousand.Visible = True
            txtQty.Visible = True
            txtWt.Visible = True
            dgvReceive.Visible = True
            GBoxReceive.Visible = True
            'Receive Side Textboxes Enabled True
            'cmbMaterial.Enabled = True
            cmbOtherItem.Enabled = True
            txtWtPerThousand.Enabled = True
            txtQty.Enabled = True
            txtWt.Enabled = True
            dgvReceive.Enabled = True
            GBoxReceive.Enabled = True
            'Issue side textboxes Enabled false
            'cmbIMaterial.Enabled = False
            cmbIOtherItem.Enabled = False
            txtIWtPerThousand.Enabled = False
            txtIQty.Enabled = False
            txtIWt.Enabled = False
            dgvIssue.Enabled = False
            GBoxIssue.Enabled = False
            'Receive Gold Bottom TextBoxes And Label Visible False
            Label11.Visible = False
            txtRMaterial.Visible = False
            Label12.Visible = False
            txtMItem.Visible = False
            Label14.Visible = False
            txtMQty.Visible = False
            Label13.Visible = False
            txtMWt.Visible = False
            lblMWrkDone.Visible = False
            ChkRWrkDone.Visible = False
            'Receive Gold Bottom TextBoxes And Label Enabled False
            Label11.Enabled = False
            txtRMaterial.Enabled = False
            Label12.Enabled = False
            txtMItem.Enabled = False
            Label14.Enabled = False
            txtMQty.Enabled = False
            Label13.Enabled = False
            txtMWt.Enabled = False
            lblMWrkDone.Enabled = False
            ChkRWrkDone.Enabled = False
            'Receive Gold+Other Visible False
            Label1.Visible = False
            txtMMaterial.Visible = False
            Label2.Visible = False
            cmbROtherItem.Visible = False
            Label4.Visible = False
            txtRQty.Visible = False
            Label3.Visible = False
            txtRWt.Visible = False
        End If
    End Sub
    Private Sub BtnRGoldPlusOther_Click(sender As Object, e As EventArgs) Handles BtnRGoldPlusOther.Click
        If dgvIssue.Rows.Count > 0 Then
            MsgBox("Please Save Issue Details First")
        End If
        If dgvReceive.Rows.Count > 0 Then
            MsgBox("Please Save Receive Details First")
        Else
            cmbROtherItem.Refresh()
            cmbROtherItem.Focus()
            If cmbROtherItem.Items.Count > 0 Then
                cmbROtherItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                cmbROtherItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
            End If
            If ChkIROther.Checked Then
                'Issue side textboxes Enabled false
                'cmbIMaterial.Enabled = False
                cmbIOtherItem.Enabled = False
                txtIWtPerThousand.Enabled = False
                txtIQty.Enabled = False
                txtIWt.Enabled = False
                'dgvIssue.Enabled = False
                'GBoxIssue.Enabled = False
                'Receive Gold+Other TextBoxes Visible True
                Label1.Visible = True
                txtMMaterial.Visible = True
                Label2.Visible = True
                cmbROtherItem.Visible = True
                Label4.Visible = True
                txtRQty.Visible = True
                Label3.Visible = True
                txtRWt.Visible = True
                'Receive Gold+Other TextBoxes Enabled True
                Label1.Enabled = True
                txtMMaterial.Enabled = True
                Label2.Enabled = True
                cmbROtherItem.Enabled = True
                Label4.Enabled = True
                txtRQty.Enabled = True
                Label3.Enabled = True
                txtRWt.Enabled = True
                'Receive Gold Bottom TextBoxes Visible True
                Label11.Visible = True
                txtRMaterial.Visible = True
                Label12.Visible = True
                txtMItem.Visible = True
                Label14.Visible = True
                txtMQty.Visible = True
                Label13.Visible = True
                txtMWt.Visible = True
                lblMWrkDone.Visible = True
                ChkRWrkDone.Visible = True
                'Receive Gold Bottom TextBoxes Enabled True
                Label11.Enabled = True
                txtRMaterial.Enabled = True
                Label12.Enabled = True
                txtMItem.Enabled = True
                Label14.Enabled = True
                txtMQty.Enabled = True
                Label13.Enabled = True
                txtMWt.Enabled = True
                lblMWrkDone.Enabled = True
                ChkRWrkDone.Enabled = True
                'Receive Side Textboxes Visible True
                cmbMaterial.Visible = True
                cmbOtherItem.Visible = True
                txtWtPerThousand.Visible = True
                txtQty.Visible = True
                txtWt.Visible = True
                dgvReceive.Visible = True
                GBoxReceive.Visible = True
                'Receive Side Textboxes Enabled True
                'cmbMaterial.Enabled = True
                cmbOtherItem.Enabled = True
                txtWtPerThousand.Enabled = True
                txtQty.Enabled = True
                txtWt.Enabled = True
                dgvReceive.Enabled = True
                GBoxReceive.Enabled = True
                'Issue side textboxes Enabled false
                'cmbIMaterial.Enabled = False
                cmbIOtherItem.Enabled = False
                txtIWtPerThousand.Enabled = False
                txtIQty.Enabled = False
                txtIWt.Enabled = False
                'dgvIssue.Enabled = False
                ' GBoxIssue.Enabled = False
                cmbROtherItem.Focus()
                If cmbROtherItem.Items.Count > 0 Then
                    cmbROtherItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    cmbROtherItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
                End If
            Else
                'Issue side textboxes visible true
                cmbIMaterial.Visible = True
                cmbIOtherItem.Visible = True
                txtIWtPerThousand.Visible = True
                txtIQty.Visible = True
                txtIWt.Visible = True
                dgvIssue.Visible = True
                GBoxIssue.Visible = True
                'Issue side textboxes Enabled False
                'cmbIMaterial.Enabled = True
                cmbIOtherItem.Enabled = False
                txtIWtPerThousand.Enabled = False
                txtIQty.Enabled = False
                txtIWt.Enabled = False
                'dgvIssue.Enabled = False
                'GBoxIssue.Enabled = False
                'Receive Gold+Other TextBoxes Visible True
                Label1.Visible = True
                txtMMaterial.Visible = True
                Label2.Visible = True
                cmbROtherItem.Visible = True
                Label4.Visible = True
                txtRQty.Visible = True
                Label3.Visible = True
                txtRWt.Visible = True
                'Receive Gold+Other TextBoxes Enabled True
                Label1.Enabled = True
                txtMMaterial.Enabled = True
                Label2.Enabled = True
                cmbROtherItem.Enabled = True
                Label4.Enabled = True
                txtRQty.Enabled = True
                Label3.Enabled = True
                txtRWt.Enabled = True
                'Receive Gold Bottom TextBoxes Visible True
                Label11.Visible = True
                txtRMaterial.Visible = True
                Label12.Visible = True
                txtMItem.Visible = True
                Label14.Visible = True
                txtMQty.Visible = True
                Label13.Visible = True
                txtMWt.Visible = True
                lblMWrkDone.Visible = True
                ChkRWrkDone.Visible = True
                'Receive Gold Bottom TextBoxes Enabled True
                Label11.Enabled = True
                txtRMaterial.Enabled = True
                Label12.Enabled = True
                txtMItem.Enabled = True
                Label14.Enabled = True
                txtMQty.Enabled = True
                Label13.Enabled = True
                txtMWt.Enabled = True
                lblMWrkDone.Enabled = True
                ChkRWrkDone.Enabled = True
                'Receive Side Textboxes Visible True
                cmbMaterial.Visible = True
                cmbOtherItem.Visible = True
                txtWtPerThousand.Visible = True
                txtQty.Visible = True
                txtWt.Visible = True
                dgvReceive.Visible = True
                GBoxReceive.Visible = True
                'Receive Side Textboxes Enabled True
                'cmbMaterial.Enabled = True
                cmbOtherItem.Enabled = True
                txtWtPerThousand.Enabled = True
                txtQty.Enabled = True
                txtWt.Enabled = True
                dgvReceive.Enabled = True
                GBoxReceive.Enabled = True
                cmbROtherItem.Focus()
                If cmbROtherItem.Items.Count > 0 Then
                    cmbROtherItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    cmbROtherItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
                End If
            End If
        End If
    End Sub
    Private Sub ChkIROther_CheckedChanged(sender As Object, e As EventArgs) Handles ChkIROther.CheckedChanged
        If ChkIROther.Checked Then
            If ChkIROther.Checked = True Then
                Me.CopyGridRows(Me.dgvReceive, Me.dgvIssue)
            Else
                dgvIssue.Rows.Clear()
            End If
            cmbIOtherItem.Enabled = False
            txtIWtPerThousand.Enabled = False
            txtIQty.Enabled = False
            txtIWt.Enabled = False
        Else
            dgvIssue.Rows.Clear()
        End If
    End Sub
    Private Sub txtIWt_Validating(sender As Object, e As CancelEventArgs) Handles txtIWt.Validating
        Try
            If cmbIMaterial.Text.Trim <> "" And cmbIOtherItem.Text.Trim <> "" And Val(txtIWtPerThousand.Text.Trim) > 0 And Val(txtIQty.Text.Trim) > 0 Then
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
    Private Sub txtIQty_TextChanged(sender As Object, e As EventArgs) Handles txtIQty.TextChanged
        Try
            With RadGridView2
                If GridDoubleClick = False Then
                    If txtIQty.Text.Trim.Length > 0 Then
                        txtIWt.Text = Val((txtIWtPerThousand.Text) / 1000) * Val(txtIQty.Text)
                    End If
                Else
                End If
            End With
            With dgvIssue
                If GridDoubleClick = False Then
                    If txtIQty.Text.Trim.Length > 0 Then
                        txtIWt.Text = Val((txtIWtPerThousand.Text) / 1000) * Val(txtIQty.Text)
                    End If
                Else
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RadGridView1_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridView1.CellDoubleClick
        Try
            With RadGridView1
                GridDoubleClick = True
            End With
            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And RadGridView1.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                cmbMaterial.Text = (RadGridView1.Rows(e.RowIndex).Cells(2).Value)
                cmbOtherItem.Text = (RadGridView1.Rows(e.RowIndex).Cells(4).Value)
                Dim Qty As String
                Dim Wt As String
                Dim WtPerThousand As String
                Qty = CDbl(RadGridView1.Rows(e.RowIndex).Cells(5).Value)
                Wt = CDbl(RadGridView1.Rows(e.RowIndex).Cells(6).Value)
                WtPerThousand = Wt * 1000 / Qty
                txtWtPerThousand.Text = WtPerThousand.ToString
                txtQty.Text = CDbl(RadGridView1.Rows(e.RowIndex).Cells(5).Value)
                txtWt.Text = CDbl(RadGridView1.Rows(e.RowIndex).Cells(6).Value)
                If Convert.ToBoolean(RadGridView1.Rows(e.RowIndex).Cells(7).Value) Then
                    ChkRWrkDone.Checked = True
                Else
                    ChkRWrkDone.Checked = False
                End If
                'If We Want ReceiveId Refer This txtQty.Tag
                txtQty.Tag = RadGridView1.Rows(e.RowIndex).Cells(0).Value
            End If
            EnableBtnR()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub EnableBtnR()
        cmbOtherItem.Enabled = True
        txtWtPerThousand.Enabled = True
        txtQty.Enabled = True
        txtWt.Enabled = True
        With RadGridView1
            GridDoubleClick = False
        End With
        btnSave.Enabled = False
        BtnDelete.Enabled = False
        With RadGridView1
            .Rows.Remove(.CurrentRow)
        End With
        'dgvReceive.Visible = False
        RadGridView1.Visible = False
    End Sub
    Private Sub EnableBtnI()
        cmbIOtherItem.Enabled = True
        txtIWtPerThousand.Enabled = True
        txtIQty.Enabled = True
        txtIWt.Enabled = True
        With RadGridView2
            GridDoubleClick = False
        End With
        btnSave.Enabled = False
        BtnDelete.Enabled = False
        With RadGridView2
            .Rows.Remove(.CurrentRow)
        End With
        'dgvReceive.Visible = False
        RadGridView2.Visible = False
    End Sub
    Private Sub RadGridView2_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles RadGridView2.CellDoubleClick
        Try
            With RadGridView2
                GridDoubleClick = True
            End With
            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And RadGridView2.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                cmbIMaterial.Text = (RadGridView2.Rows(e.RowIndex).Cells(2).Value)
                cmbIOtherItem.Text = (RadGridView2.Rows(e.RowIndex).Cells(4).Value)
                Dim IQty As String
                Dim IWt As String
                Dim IWtPerThousand As String
                IQty = CDbl(RadGridView2.Rows(e.RowIndex).Cells(5).Value)
                IWt = CDbl(RadGridView2.Rows(e.RowIndex).Cells(6).Value)
                IWtPerThousand = IWt * 1000 / IQty
                txtIWtPerThousand.Text = IWtPerThousand.ToString
                txtIQty.Text = CDbl(RadGridView2.Rows(e.RowIndex).Cells(5).Value)
                txtIWt.Text = CDbl(RadGridView2.Rows(e.RowIndex).Cells(6).Value)
                If Convert.ToBoolean(RadGridView2.Rows(e.RowIndex).Cells(7).Value) Then
                    ChkRWrkDone.Checked = True
                Else
                    ChkRWrkDone.Checked = False
                End If
                'If We Want ReceiveId Refer This txtQty.Tag
                txtIQty.Tag = RadGridView2.Rows(e.RowIndex).Cells(0).Value
            End If
            EnableBtnI()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles BtnUpdate.Click
        Try
            If txtWt.Text.Trim() = Nothing And txtQty.Text.Trim() = Nothing Then
                If dgvReceive.Rows.Count > 0 Then
                    Me.UpdateRData()
                    Me.Close()
                    'Dim Value As String
                    Dim LotNo = strLotNo
                    Dim ObjFrm As New frmFIssueReceive
                    ObjFrm.ShowDialog()
                    ObjFrm.BringToFront()
                    ObjFrm.Focus()
                End If
            Else
                MessageBox.Show("Please Save Record In Table Then Click To Update")
            End If
            If txtIWt.Text.Trim() = Nothing And txtIQty.Text.Trim() = Nothing Then
                If dgvIssue.Rows.Count > 0 Then
                    Me.UpdateIData()
                    Me.Close()
                    Dim ObjFrm As New frmFIssueReceive
                    ObjFrm.ShowDialog()
                    ObjFrm.BringToFront()
                    ObjFrm.Focus()
                End If
            Else
                MessageBox.Show("Please Save Record In Table Then Click To Update")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UpdateRData()
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            If dgvReceive.RowCount > 0 Then
                For Each row As GridViewRowInfo In dgvReceive.Rows
                    With Hparameters
                        .Add(dbManager.CreateParameter("@DReceiveId", txtQty.Tag, DbType.Int16))
                        .Add(dbManager.CreateParameter("@DItemId", Val(row.Cells(2).Value), DbType.Int16))
                        .Add(dbManager.CreateParameter("@DReceiveWt", row.Cells(6).Value, DbType.String))
                        .Add(dbManager.CreateParameter("@DReceiveQty", row.Cells(5).Value, DbType.String))
                        Dim isSelected As Boolean = Convert.ToBoolean(row.Cells(7).Value)
                        If isSelected Then
                            .Add(dbManager.CreateParameter("@IsWorkDone ", 1, DbType.Boolean))
                        End If
                        .Add(dbManager.CreateParameter("@LotNo", strLotNo, DbType.String))
                        .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))
                    End With
                    dbManager.Update("SP_FReceiveOther_Update", CommandType.StoredProcedure, Hparameters.ToArray())
                    MessageBox.Show("Data Updated For Other Material Receive Items !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Hparameters.Clear()
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UpdateIData()
        Try
            If dgvIssue.Rows.Count > 0 Then
                Dim Hparameters = New List(Of SqlParameter)()
                Hparameters.Clear()
                'For Issue Other Items
                If dgvIssue.RowCount > 0 Then
                    Hparameters.Clear()
                    For Each row As GridViewRowInfo In dgvIssue.Rows
                        With Hparameters
                            .Add(dbManager.CreateParameter("@DIssueId", txtIQty.Tag, DbType.Int16))
                            .Add(dbManager.CreateParameter("@DItemId", Val(row.Cells(2).Value), DbType.Int16))
                            .Add(dbManager.CreateParameter("@DIssueWt", row.Cells(6).Value, DbType.String))
                            .Add(dbManager.CreateParameter("@DIssueQty", row.Cells(5).Value, DbType.String))
                            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells(7).Value)
                            If isSelected Then
                                .Add(dbManager.CreateParameter("@IsWorkDone ", 1, DbType.Boolean))
                            End If
                            .Add(dbManager.CreateParameter("@LotNo", strLotNo, DbType.String))
                            .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))
                        End With
                        dbManager.Insert("SP_FIssueOther_Update", CommandType.StoredProcedure, Hparameters.ToArray())
                        MessageBox.Show("Data Updated For Other Material Issue Item !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Hparameters.Clear()
                    Next
                End If
            End If
        Catch
        End Try
    End Sub
    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Try
            If txtWt.Text.Trim() = Nothing And txtQty.Text.Trim() = Nothing Then
                If dgvReceive.Rows.Count > -1 And RadGridView1.RowCount > 0 Then
                    DeleteRData()
                    TotalReceive()
                    Me.Close()
                End If
            End If
            If txtIWt.Text.Trim() = Nothing And txtIQty.Text.Trim() = Nothing Then
                If dgvIssue.Rows.Count > -1 And RadGridView2.RowCount > 0 Then
                    DeleteIData()
                    Total()
                    Me.Close()
                End If
            End If
        Catch
        End Try
        Try
            If dgvIssue.Rows.Count > 0 Then
                With dgvIssue
                    .Rows.Remove(.CurrentRow)
                    Total()
                End With
            End If
            cmbIOtherItem.SelectedIndex = 0
            txtIWtPerThousand.Clear()
            txtIQty.Clear()
            txtIWt.Clear()
            If dgvReceive.Rows.Count > 0 Then
                With dgvReceive
                    .Rows.Remove(.CurrentRow)
                    TotalReceive()
                End With
            End If
            cmbOtherItem.SelectedIndex = 0
            txtWtPerThousand.Clear()
            txtQty.Clear()
            txtWt.Clear()
        Catch ex As Exception
        End Try
        'Me.Close()
    End Sub
    Private Sub DeleteRData()
        Try
            If RadGridView1.RowCount > 0 Then
                Dim Hparameters = New List(Of SqlParameter)()
                Hparameters.Clear()
                For Each row As GridViewRowInfo In RadGridView1.Rows
                    With Hparameters
                        .Add(dbManager.CreateParameter("@DReceiveId", Val(row.Cells(0).Value), DbType.Int16))
                    End With
                    dbManager.Delete("SP_FReceiveOther_Delete", CommandType.StoredProcedure, Hparameters.ToArray())
                    MessageBox.Show("Data Deleted For Other Material Receive Item !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Hparameters.Clear()
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DeleteIData()
        Try
            If RadGridView2.Rows.Count > 0 Then
                Dim Hparameters = New List(Of SqlParameter)()
                Hparameters.Clear()
                'For Issue Other Items
                If RadGridView2.RowCount > 0 Then
                    Hparameters.Clear()
                    For Each row As GridViewRowInfo In RadGridView2.Rows
                        With Hparameters
                            .Add(dbManager.CreateParameter("@DIssueId", Val(row.Cells(0).Value), DbType.Int16))
                        End With
                        dbManager.Delete("SP_FIssueOther_Delete", CommandType.StoredProcedure, Hparameters.ToArray())
                        MessageBox.Show("Data Deleted For Other Material Issue Item !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Hparameters.Clear()
                    Next
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub dgvIssue_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvIssue.CellDoubleClick
        Try
            With dgvIssue
                GridDoubleClick = True
            End With
            If dgvIssue.RowCount > -1 Then
                If e.RowIndex = -1 Then Exit Sub
                If e.RowIndex >= 0 And dgvIssue.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                    If dgvIssue.Rows(e.RowIndex).Cells(0).Value.ToString() = "2" Then
                        cmbIMaterial.SelectedIndex = dgvIssue.Rows(e.RowIndex).Cells(0).Value.ToString()
                        cmbIOtherItem.SelectedValue = dgvIssue.Rows(e.RowIndex).Cells(2).Value.ToString()
                        txtIWt.Tag = ""
                        txtIWt.Tag = dgvIssue.Rows(e.RowIndex).Cells(2).Value.ToString()
                        cmbIOtherItem.Text = ""
                        cmbIOtherItem.SelectedText = dgvIssue.Rows(e.RowIndex).Cells(3).Value.ToString()
                        Dim IQty As String
                        Dim IWt As String
                        Dim IWtPerThousand As String
                        IQty = CDbl(dgvIssue.Rows(e.RowIndex).Cells(5).Value)
                        IWt = CDbl(dgvIssue.Rows(e.RowIndex).Cells(6).Value)
                        IWtPerThousand = IWt * 1000 / IQty
                        txtIWtPerThousand.Text = IWtPerThousand.ToString
                        txtIWt.Text = CStr(dgvIssue.Rows(e.RowIndex).Cells(6).Value)
                        txtIQty.Text = CStr(dgvIssue.Rows(e.RowIndex).Cells(5).Value)
                        txtIQty.Tag = Val(dgvIssue.Rows(e.RowIndex).Cells(6).Value)
                        TempRow = e.RowIndex
                        With dgvIssue
                            .Rows.Remove(.CurrentRow)
                            GridDoubleClick = False
                        End With
                    End If
                End If
            End If
        Catch
        End Try
    End Sub
End Class