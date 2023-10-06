Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Imports System.ComponentModel
Public Class RdfrmEditMelting
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer

    Dim RGridDoubleClick As Boolean
    Dim blnRecieveStatus As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

    Private Objerr As New ErrorProvider()
    Private Sub RdfrmEditMelting_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLotNo()
        Me.fillItem()
        Me.fillMaterial()
        Me.ListNtFinalReceived()
        Me.Clear_Form()
    End Sub
    Private Sub ListNtFinalReceived()
        Dim dtable As DataTable = fetchAllFancys()
        DgvLstNotFinalReceived.DataSource = dtable
    End Sub

    Private Function fetchAllFancys() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "ListNotFinaliseReceived", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_FReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
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
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit"
                    Me.btnSave.Text = "&Update"
            End Select
        End Set
    End Property
    Private Sub fillLotNo()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_fMelting_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
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
            cmbLotNo.ValueMember = "MeltingId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            'cmbLotNo.SelectedIndex = 0
            TransDt.Value = DateTime.Now

            'btnSave.Text = "Save"

            txtMelting.Clear()
            txtItem.Tag = ""
            txtItem.Clear()

            txtConvertToMelting.Clear()

            txtFrKarigar.Clear()
            txtToKarigar.Clear()
            '' For Header Field End

            '' For Receive Detail Field Start
            GBoxReceive.Enabled = True

            cmbRMaterial.SelectedIndex = 1
            cmbRMaterial.Enabled = False
            cmbRItem.SelectedIndex = 0
            txtRWt.Clear()
            txtRQty.Clear()
            ChkWorkDone.Checked = False
            '' For Receive Detail Field End

            '' For Detail Field Start
            dgvIssue.DataSource = Nothing
            dgvReceive.DataSource = Nothing

            lblITotalWt.Text = "0.00"
            lblITotalQty.Text = "0.00"

            lblRTotalWt.Text = "0.00"
            lblRTotalQty.Text = "0.00"
            '' For Detail Field End

            Fr_Mode = FormState.AStateMode

            cmbLotNo.Focus()
            cmbLotNo.Select()
            Me.TreeDetailsVisibleFalse()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub FetchTreeDetails(ByVal TransId As Integer)
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
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
                txtFineWtGm.Text = Format(Val(txtTotGoldNeed.Text) * Val(txtMelting.Text) / 100, "0.00")
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub fillHeader(ByVal intMeltingId As Integer)

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@MId", CInt(intMeltingId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_fMelting_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            TransDt.Text = dr.Item("MeltingDt").ToString
            TransDt.Tag = dr.Item("NewLotId").ToString()
            cmbLotNo.Text = dr.Item("LotNo").ToString()
            txtItem.Tag = dr.Item("ItemId").ToString
            txtItem.Text = dr.Item("ItemName").ToString
            txtMelting.Text = dr.Item("RequirePr").ToString()
            txtConvertToMelting.Text = dr.Item("ConvertToMelting").ToString()
            'lblAlloyTotal.Text = dr.Item("GrossWt").ToString
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            txtToKarigar.Tag = dr.Item("ToKarigarId").ToString
            txtToKarigar.Text = dr.Item("ToKarigar").ToString
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
    Private Function CheckTransNoExist() As Boolean
        Try
            Dim dt As DataTable = New DataTable()
            If cmbLotNo.SelectedIndex > 0 Then
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
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
    Private Sub fillDetails(ByVal MeltingId As Integer)
        Dim dttable As New DataTable
        dttable = fetchAllFancys(CInt(MeltingId))

        dgvIssue.DataSource = Nothing

        For Each ROW As DataRow In dttable.Rows
            dgvIssue.Rows.Add(CStr(ROW("MaterialId")), CStr(ROW("MaterialName")), Val(ROW("ItemBagId")), CStr(ROW("ItemName")), Format(Val(ROW("GrossWt")), "0.00"), Format(Val(ROW("Pcs")), "0.00"))
        Next

        'Me.GetSrNo(dgvIssue)
        Me.ITotal()

        dgvIssue.ReadOnly = True
    End Sub
    Private Function fetchAllFancys(ByVal intMeltingId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@MId", CInt(intMeltingId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailForIssue", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_Melting_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub txtRWt_Leave(sender As Object, e As EventArgs) Handles txtRWt.Leave
        txtRWt.Text = Format(Val(txtRWt.Text), "0.00")
    End Sub
    Private Sub txtRQty_Leave(sender As Object, e As EventArgs) Handles txtRQty.Leave
        txtRQty.Text = Format(Val(txtRQty.Text), "0.00")
    End Sub
    Private Sub txtRQty_Validating(sender As Object, e As CancelEventArgs) Handles txtRQty.Validating
        Try
            If cmbRMaterial.Text.Trim <> "" And cmbRItem.Text.Trim <> "" And Val(txtRWt.Text.Trim) > 0 And Val(txtRQty.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvReceive.Rows.Count > 0 AndAlso ChkRDuplicate() = True Then
                    MsgBox("Duplicate Data")
                Else

                    Me.RTotal()
                End If
            Else
                'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub ITotal()
        lblITotalWt.Text = 0.00
        lblITotalQty.Text = 0.00

        Try
            For Each row As GridViewRowInfo In dgvIssue.Rows
                lblITotalWt.Text = Format(Val(lblITotalWt.Text) + Val(row.Cells(4).Value), "0.00")
                lblITotalQty.Text = Format(Val(lblITotalQty.Text) + Val(row.Cells(5).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillItem()

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
            ''Insert the Default Item to DataTable.
            Dim frow As DataRow = Odt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            Odt.Rows.InsertAt(frow, 0)

            ''Assign DataTable as DataSource.
            cmbRItem.DataSource = Odt
            cmbRItem.DisplayMember = "ItemName"
            cmbRItem.ValueMember = "ItemId"

            cmbRItem.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbRItem.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillMaterial()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillMaterialCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_MaterialMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim Odt As DataTable = New DataTable()

        Odt.Load(dr)

        Dim Cdt As DataTable = Odt.Copy()

        Try
            ''Insert the Default Item to DataTable.
            Dim frow As DataRow = Odt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            Odt.Rows.InsertAt(frow, 0)

            ''Assign DataTable as DataSource.
            cmbRMaterial.DataSource = Odt
            cmbRMaterial.DisplayMember = "MaterialName"
            cmbRMaterial.ValueMember = "MaterialId"

            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = Cdt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            Cdt.Rows.InsertAt(trow, 0)

            cmbIMaterial.DataSource = Cdt
            cmbIMaterial.DisplayMember = "MaterialName"
            cmbIMaterial.ValueMember = "MaterialId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Sub fillRGrid()

        If RGridDoubleClick = False Then
            dgvReceive.Rows.Add(Val(cmbRMaterial.SelectedValue),
                                    CStr(cmbRMaterial.Text.Trim),
                                    Val(cmbRItem.SelectedValue),
                                    CStr(cmbRItem.Text.Trim),
                                    Format(Val(txtRWt.Text.Trim), "0.00"),
                                    Format(Val(txtRQty.Text.Trim), "0.00"))

            GetRSrNo(dgvReceive)
        Else
            dgvReceive.Rows(TempRow).Cells(0).Value = Val(cmbRMaterial.SelectedValue)
            dgvReceive.Rows(TempRow).Cells(1).Value = CStr(cmbRMaterial.Text.Trim)
            dgvReceive.Rows(TempRow).Cells(2).Value = Val(cmbRMaterial.SelectedValue)
            dgvReceive.Rows(TempRow).Cells(3).Value = CStr(cmbRMaterial.Text.Trim)
            dgvReceive.Rows(TempRow).Cells(4).Value = txtRWt.Text.Trim
            dgvReceive.Rows(TempRow).Cells(5).Value = txtRQty.Text.Trim
            RGridDoubleClick = False
        End If

        Me.RTotal()

        dgvReceive.TableElement.ScrollToRow(dgvReceive.Rows.Last)
        cmbRMaterial.SelectedIndex = 0
        cmbRItem.SelectedIndex = 0
        txtRWt.Clear()
        txtRQty.Clear()

        cmbRMaterial.Focus()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            If Fr_Mode = FormState.AStateMode Then
                If Not Validate_Fields() Then Exit Sub
                Me.SaveRData()
                Me.btnCancel_Click(sender, e)
            Else
                Me.UpdateRData()
                Me.btnCancel_Click(sender, e)
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.BindReceiveDetails()
            Me.BindIssueDetails()
        End Try
    End Sub
    Private Function ChkRDuplicate() As Boolean
        Dim exists As Boolean = False

        If RGridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvReceive.Rows
                If itm.Cells(3).Value = CStr(cmbRItem.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists

    End Function
    Sub GetRSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvReceive.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.ListNtFinalReceived()
            Me.Clear_Form()
            cmbLotNo.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Sub RTotal()
        lblRTotalWt.Text = 0.00
        lblRTotalQty.Text = 0.00
        Try
            For Each row As GridViewRowInfo In dgvReceive.Rows
                lblRTotalWt.Text = Format(Val(lblRTotalWt.Text) + Val(row.Cells(4).Value), "0.00")
                lblRTotalQty.Text = Format(Val(lblRTotalQty.Text) + Val(row.Cells(5).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function Validate_Fields() As Boolean

        Dim dblRWt As Double = Convert.ToDouble(lblRTotalWt.Text)
        Dim dblCWt As Double = Convert.ToDouble(txtRWt.Text)
        Dim dblIWt As Double = Convert.ToDouble(lblITotalWt.Text)

        Dim dblTmpTotalWt As Double = Convert.ToDouble(dblRWt + dblCWt)

        Try

            If cmbRMaterial.Enabled = True And cmbIMaterial.Enabled = True Then
                MessageBox.Show("Cannot Save Receive and Issue Detail Information at Same Time!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            'If Not dgvReceive.RowCount > 0 Then
            '    MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            '    Return False
            'End If

            If cmbLotNo.SelectedIndex = -1 Or cmbLotNo.SelectedIndex = 0 Then
                MessageBox.Show("Select Lot No. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            ElseIf txtMelting.Text.Trim.Length = 0 Then
                MessageBox.Show("Select Melting Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtMelting.Focus()
                Return False
                'ElseIf dblTmpTotalWt > dblIWt Then
                '    MessageBox.Show("Receive Wt. Should Be Less than Issue Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                '    Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        Me.Clear_Form()
        If cmbLotNo.SelectedIndex > 0 Then
            'Fr_Mode = FormState.EStateMode
            Dim MeltingId As Integer = Val(cmbLotNo.SelectedValue)

            Me.fillHeader(MeltingId)

            Me.BindReceiveDetails()
            Me.BindIssueDetails()
        End If
    End Sub
    Private Sub btnFinalize_Click(sender As Object, e As EventArgs) Handles btnFinalize.Click
        Dim dRtotalWt As Double
        Dim dItotalWt As Double
        Dim sLotNo As String = Nothing

        If cmbLotNo.SelectedIndex = -1 Or cmbLotNo.SelectedIndex = 0 Then
            MessageBox.Show("Select Lot No. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLotNo.Focus()
            Exit Sub
        End If

        Try
            ''Show_ChildForm("frmFinalizeLot", Me.MdiParent, Me.Tag)

            dRtotalWt = lblRTotalWt.Text
            dItotalWt = lblITotalWt.Text
            sLotNo = cmbLotNo.Text.Trim

            'Dim frm As New frmMeltingFinalizeLot(sLotNo)
            'frm.ShowDialog()
            'frm.BringToFront()
            'frm.Focus()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub SaveRData()

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@DMaterialId", (cmbRMaterial.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@DItemId", Val(cmbRItem.SelectedValue), DbType.Int16))

                .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(cmbLotNo.SelectedItem), DbType.String))
                .Add(dbManager.CreateParameter("@DReceiveWt", (txtRWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DReceiveQty", (txtRQty.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))

                If ChkWorkDone.Checked = True Then
                    .Add(dbManager.CreateParameter("@IsWorkDone", 1, DbType.Boolean))
                Else
                    .Add(dbManager.CreateParameter("@IsWorkDone", 0, DbType.Boolean))
                End If

            End With

            dbManager.Insert("SP_FReceive_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtRWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRWt.KeyPress
        numdotkeypress(e, txtRWt, Me)
    End Sub
    Private Sub txtRQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRQty.KeyPress
        numdotkeypress(e, txtRQty, Me)
    End Sub
    Private Sub dgvReceive_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvReceive.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And dgvReceive.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                RGridDoubleClick = True
                cmbRMaterial.SelectedIndex = dgvReceive.Rows(e.RowIndex).Cells(0).Value.ToString()
                cmbRItem.SelectedIndex = dgvReceive.Rows(e.RowIndex).Cells(2).Value.ToString()
                txtRWt.Text = CDbl(dgvReceive.Rows(e.RowIndex).Cells(4).Value)
                txtRQty.Text = CDbl(dgvReceive.Rows(e.RowIndex).Cells(5).Value)
                txtRQty.Tag = Val(dgvReceive.Rows(e.RowIndex).Cells(6).Value)

                If Convert.ToBoolean(dgvReceive.Rows(e.RowIndex).Cells(7).Value) Then
                    ChkWorkDone.Checked = True
                Else
                    ChkWorkDone.Checked = False
                End If

                TempRow = e.RowIndex
                Fr_Mode = FormState.EStateMode
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub BindReceiveDetails()
        Dim dtdata As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchRData", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", Convert.ToString(cmbLotNo.SelectedItem), DbType.String))
        End With

        dtdata = dbManager.GetDataTable("SP_ReceiveDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Try
            dgvReceive.DataSource = Nothing
            If dtdata.Rows.Count > 0 Then
                dgvReceive.DataSource = dtdata
                dgvReceive.EnableFiltering = True
                dgvReceive.MasterTemplate.ShowFilteringRow = False
                dgvReceive.MasterTemplate.ShowHeaderCellButtons = True
                Me.RTotal()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub BindReceiveDetailsByReceiveId()
        Dim dtdata As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchRData", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", Convert.ToString(cmbLotNo.Text), DbType.String))
        End With

        dtdata = dbManager.GetDataTable("SP_ReceiveDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Try
            dgvReceive.DataSource = Nothing
            If dtdata.Rows.Count > 0 Then
                dgvReceive.DataSource = dtdata
                dgvReceive.EnableFiltering = True
                dgvReceive.MasterTemplate.ShowFilteringRow = False
                dgvReceive.MasterTemplate.ShowHeaderCellButtons = True
                Me.RTotal()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub



    Private Sub DgvLstNotFinalReceived_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles DgvLstNotFinalReceived.CellDoubleClick
        If DgvLstNotFinalReceived.RowCount > 0 Then
            Dim ReivedId As Integer = Me.DgvLstNotFinalReceived.SelectedRows(0).Cells(0).Value
            Me.GetReceiveId(ReivedId)
            Dim MeltingId As Integer = txtMelting.Tag
            Me.fillHeader(MeltingId)
            Me.BindReceiveDetailsByReceiveId()
            Me.BindIssueDetailsByReceiveId()
            Me.TbMelting.SelectedIndex = 0
            'btnSave.Text = "&Update"
        Else
            MsgBox("Data Not Found")
        End If
        'Try
        '    'DgvLstNotFinalReceived.RowCount = 0
        '    If DgvLstNotFinalReceived.Rows.Count > 0 Then
        '        Dim ReivedId As Integer = Me.DgvLstNotFinalReceived.SelectedRows(0).Cells(0).Value
        '        Fr_Mode = FormState.EStateMode
        '        Me.fillHeaderFromListView(ReivedId)
        '        Me.fillDetailsFromListView(ReivedId)
        '        Me.TbMelting.SelectedIndex = 0
        '    End If
        'Catch
        'End Try
    End Sub
    Private Sub GetReceiveId(ByVal ReivedId As Integer)
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchAllReceiveMeltingData", DbType.String))
            .Add(dbManager.CreateParameter("@MId", CInt(ReivedId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Melting_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtMelting.Tag = dr.Item("MeltingId").ToString
            TransDt.Tag = dr.Item("NewLotId").ToString()
        End If
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
            TransDt.Text = dr.Item("MeltingDt").ToString
            txtMelting.Tag = dr.Item("MeltingId").ToString
            txtMelting.Text = dr.Item("MeltingValue").ToString
            cmbLotNo.Text = dr.Item("LotNo").ToString()
            txtItem.Tag = dr.Item("ItemId").ToString
            txtItem.Text = dr.Item("ItemName").ToString
            txtMelting.Text = dr.Item("RequirePr").ToString()
            txtConvertToMelting.Text = dr.Item("ConvertToMelting").ToString()
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
    Private Sub fillDetailsFromListView(ByVal MeltingId As Integer)
        Dim dttable As New DataTable
        dttable = fetchAllFancys(CInt(MeltingId))

        For Each ROW As DataRow In dttable.Rows
            dgvReceive.Rows.Add(1, CStr(ROW("ItemType")), CStr(ROW("SlipBagNo")), Val(ROW("ItemBagId")), CStr(ROW("ItemName")), Format(Val(ROW("GrossWt")), "0.00"), Format(Val(ROW("GrossPr")), "0.00"), Format(Val(ROW("FineWt")), "0.000"), Val(ROW("ReceiptId")), Val(ROW("ReceiptDetailsId")), Val(ROW("UsedBagId")))
        Next

        Me.GetSrNo(dgvReceive)
        Me.ITotal()
        Me.RTotal()

        dgvReceive.ReadOnly = True
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
    Private Sub BindIssueDetailsByReceiveId()
        Dim dtdata As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchIData", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", Convert.ToString(cmbLotNo.Text), DbType.String))
        End With

        dtdata = dbManager.GetDataTable("SP_IssueDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Try
            dgvIssue.DataSource = Nothing
            If dtdata.Rows.Count > 0 Then
                dgvIssue.DataSource = dtdata
                dgvIssue.EnableFiltering = True
                dgvIssue.MasterTemplate.ShowFilteringRow = False
                dgvIssue.MasterTemplate.ShowHeaderCellButtons = True

                Me.ITotal()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub BindIssueDetails()
        Dim dtdata As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchIData", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", Convert.ToString(cmbLotNo.SelectedItem), DbType.String))
        End With

        dtdata = dbManager.GetDataTable("SP_IssueDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Try
            dgvIssue.DataSource = Nothing
            If dtdata.Rows.Count > 0 Then
                dgvIssue.DataSource = dtdata
                dgvIssue.EnableFiltering = True
                dgvIssue.MasterTemplate.ShowFilteringRow = False
                dgvIssue.MasterTemplate.ShowHeaderCellButtons = True

                Me.ITotal()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub RdfrmEditMelting_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

            If (e.Alt AndAlso (e.KeyCode = Keys.S)) Then
                ' When Alt + S is pressed, the Click event for the print
                ' button is raised.
                btnSave().PerformClick()
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UpdateRData()
        Dim strLotNo As String = Nothing

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@DMaterialId", (cmbRMaterial.SelectedValue), DbType.Int16))
                .Add(dbManager.CreateParameter("@DItemId", Val(cmbRItem.SelectedValue), DbType.Int16))

                .Add(dbManager.CreateParameter("@ReceiveId", Val(txtRQty.Tag), DbType.Int16))
                .Add(dbManager.CreateParameter("@DLotNo", Convert.ToString(cmbLotNo.SelectedItem.Text.Trim), DbType.String))

                .Add(dbManager.CreateParameter("@DReceiveWt", (txtRWt.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DReceiveQty", (txtRQty.Text), DbType.String))
                .Add(dbManager.CreateParameter("@DMachineName", (Environment.MachineName), DbType.String))

                If ChkWorkDone.Checked = True Then
                    .Add(dbManager.CreateParameter("@IsWorkDone", 1, DbType.Boolean))
                Else
                    .Add(dbManager.CreateParameter("@IsWorkDone", 0, DbType.Boolean))
                End If

            End With

            dbManager.Insert("SP_FReceive_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
End Class
