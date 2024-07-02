Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI

Public Class frmFDailyStockDetails
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer

    Dim GridDoubleClick As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub frmDailyStockDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If dtUserRights.Rows.Count > 0 Then
            Dim DtRow() As DataRow = dtUserRights.Select("FormName = 'ACCOUNT MASTER'")
            USERADD = DtRow(0).Item(3)
            USEREDIT = DtRow(0).Item(4)
            USERVIEW = DtRow(0).Item(5)
            USERDELETE = DtRow(0).Item(6)
            DeptId = DtRow(0).Item(7)
            If USEREDIT = False And USERDELETE = False Then
                MsgBox("Insufficient Rights")
            End If
        End If

        cmbTLabour.Tag = CInt(UserId)
        cmbTLabour.Text = Convert.ToString(KarigarName.Trim)
        cmbTLabour.Enabled = False
        txtActualMetal.Enabled = False
        txtWtAsPerSystem.Enabled = False
        txtActualFineWt.Enabled = False
        txtFineWtSys.Enabled = False
        txtFineDiff.Enabled = False
        txtSrNo.Enabled = False
        txtFineWtSys.Visible = False
        txtFineDiff.Visible = False
        lblTotFineWtSys.Visible = False
        lblTotFineDiff.Visible = False

        Me.ClearTotalByCategory()
        Me.fillStockCategoryName()
        Me.fillMelting()
        Me.fillBoxName()
        Me.FillStockList()
        Me.Clear()
        Me.TextBoxesReadOnly()
    End Sub
    Private Sub TextBoxesReadOnly()
        txtWIPGrossWt.Enabled = False
        txtWIPPr.Enabled = False
        txtWIPFWt.Enabled = False

        txtVMUGrossWt.Enabled = False
        txtVMUPr.Enabled = False
        txtVMUFWt.Enabled = False

        txtBNCGrossWt.Enabled = False
        txtBNCPr.Enabled = False
        txtBNCFWt.Enabled = False

        txtSBNRGrossWt.Enabled = False
        txtSBNRPr.Enabled = False
        txtSBNRFWt.Enabled = False

        txtVBNRGrossWt.Enabled = False
        txtVBNRPr.Enabled = False
        txtVBNRFWt.Enabled = False

        txtSBNUGrossWt.Enabled = False
        txtSBNUpdPr.Enabled = False
        txtSBNUpdFWt.Enabled = False

        txtVBNUpdGrossWt.Enabled = False
        txtVBNUpdtPr.Enabled = False
        txtVBNUpdtFWt.Enabled = False

        txtSBNUsedGrossWt.Enabled = False
        txtSBNUsedPr.Enabled = False
        txtSBNUsedFWt.Enabled = False

        txtVBNUsedGrossWt.Enabled = False
        txtVBNUsedPr.Enabled = False
        txtVBNUsedFWt.Enabled = False

        txtSIHGrossWt.Enabled = False
        txtSIHPr.Enabled = False
        txtSIHFWt.Enabled = False
    End Sub
    Private Sub FillStockList()
        Dim dtable As DataTable = fetchAllDetails()
        'RadGridView1.Rows.Clear()
        'For i As Integer = 0 To dtable.Rows.Count - 1
        If dtable.Rows.Count > 0 Then
            dgvStockList.DataSource = dtable
            dgvStockList.ReadOnly = True
        Else
            dgvStockList.DataSource = dtable
            dgvStockList.ReadOnly = True
        End If
        'Next
    End Sub
    Private Function fetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "GetUnFinalizeStockDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub Clear()
        cmbTLabour.SelectedIndex = 0
        'txtHRemark.Clear()
        'cmbCategoryName.Text = ""
        cmbCategoryName.SelectedIndex = 0
        cmbMelting.Text = ""
        cmbMelting.SelectedIndex = 0
        cmbMelting.Text = ""
        cmbBoxName.Text = ""
        cmbBoxName.SelectedIndex = 0
        txtWtWithBox.Clear()
        txtActualMetal.Clear()
        txtActualFineWt.Clear()
        txtWtAsPerSystem.Clear()
        txtFineWtSys.Clear()
        txtFineDiff.Clear()
        txtGRemark.Clear()
        txtSrNo.Text = 1
        dgvStockDetails.DataSource = Nothing
    End Sub
    Private Sub fillTakenByEmp()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillCombo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)
            ''Insert the Default Item to DataTable.
            'Dim trow As DataRow = dt.NewRow()
            'trow(0) = 0
            'trow(1) = "---Select---"
            'dt.Rows.InsertAt(trow, 0)

            cmbTLabour.DataSource = dt
            cmbTLabour.DisplayMember = "LabourName"
            cmbTLabour.ValueMember = "LabourId"

            cmbTLabour.Refresh()
            If cmbTLabour.Items.Count > 0 Then cmbTLabour.SelectedIndex = 0


            'Set AutoCompleteMode.
            cmbTLabour.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbTLabour.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
        End Try
    End Sub

    Private Sub frmDailyStockDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
            If e.KeyCode = Keys.F2 Then
                txtSrNo.Clear()
                cmbTLabour.SelectedIndex = 0
                cmbCategoryName.SelectedIndex = 0
                cmbMelting.SelectedIndex = 0
                cmbMelting.Text = ""
                cmbBoxName.SelectedIndex = 0
                txtWtWithBox.Clear()
                txtActualMetal.Clear()
                txtWtAsPerSystem.Clear()
                txtActualFineWt.Clear()
                cmbCategoryName.Focus()
            End If
            With dgvStockDetails
                If e.KeyCode = Keys.F12 Then
                    If btnSave.Text = "&Save" Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        Dim ScrapDetailedId As Int16 = dgvStockDetails.SelectedRows(0).Cells(6).Value
                        If (MsgBox("Are You Sure To Delete This Record ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                            Try
                                If dgvStockDetails.RowCount > 0 Then
                                    Dim StockId As Int16 = dgvStockDetails.SelectedRows(0).Cells(12).Value
                                    If (MsgBox("Are You Sure To Delete This Record ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                                        Try
                                            If dgvStockDetails.RowCount > 0 Then
                                                Dim parameters = New List(Of SqlParameter)()
                                                parameters.Clear()
                                                With parameters
                                                    .Add(dbManager.CreateParameter("@StockId", StockId, DbType.Int16))
                                                End With
                                                dbManager.Delete("SP_fDailyStock_Delete", CommandType.StoredProcedure, parameters.ToArray())
                                                MessageBox.Show("Stock Delete Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                dgvStockDetails.RowCount = 0
                                            End If
                                        Catch ex As Exception
                                            MessageBox.Show("Error:- " & ex.Message)
                                        End Try
                                    End If
                                    .Rows.Remove(.CurrentRow)
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Error:- " & ex.Message)
                            End Try
                        End If
                    End If
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub cmbCategoryName_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbCategoryName.SelectedIndexChanged
        If cmbCategoryName.SelectedIndex = 1 Then
            Me.GetStockForWIP()
        ElseIf cmbCategoryName.SelectedIndex = 2 Then
            Me.GetStockForVoucherMetalUnUsed()
        ElseIf cmbCategoryName.SelectedIndex = 3 Then
            Me.GetStockForBagsNotCreated()
        ElseIf cmbCategoryName.SelectedIndex = 4 Then
            Me.GetStockForScrapBagsNotReceived()
        ElseIf cmbCategoryName.SelectedIndex = 5 Then
            Me.GetStockForVacBagsNotReceived()
        ElseIf cmbCategoryName.SelectedIndex = 6 Then
            Me.GetStockForScrapBagsNotUpdated()
        ElseIf cmbCategoryName.SelectedIndex = 7 Then
            Me.GetStockForVacBagsNotUpdated()
        ElseIf cmbCategoryName.SelectedIndex = 8 Then
            Me.GetStockForScrapBagsNotUsed()
        ElseIf cmbCategoryName.SelectedIndex = 9 Then
            Me.GetStockForVacBagsNotUsed()
        ElseIf cmbCategoryName.SelectedIndex = 10 Then
            Me.GetStockForInHand()
        End If
    End Sub
    Private Sub GetStockForWIP()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "StockDetailsForWIP", DbType.String))

        End With
        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                txtWtAsPerSystem.Text = dtData.Rows(0).Item("WIP").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub GetStockForVoucherMetalUnUsed()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "StockDetailsForVoucherMetalUnUsed", DbType.String))

        End With
        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                txtWtAsPerSystem.Text = dtData.Rows(0).Item("VoucherMetalUnUsed").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub GetStockForBagsNotCreated()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "StockDetailsForBagsNotCreated", DbType.String))

        End With
        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                txtWtAsPerSystem.Text = dtData.Rows(0).Item("BagsNotCreated").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub GetStockForScrapBagsNotReceived()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "StockDetailsForScrapBagsNotReceived", DbType.String))

        End With
        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                txtWtAsPerSystem.Text = dtData.Rows(0).Item("ScrapBagNotReceived").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub GetStockForVacBagsNotReceived()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "StockDetailsForVacBagsNotReceived", DbType.String))

        End With
        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                txtWtAsPerSystem.Text = dtData.Rows(0).Item("VacBagNotReceived").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub GetStockForScrapBagsNotUpdated()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "StockDetailsForScrapBagsNotUpdated", DbType.String))

        End With
        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                txtWtAsPerSystem.Text = dtData.Rows(0).Item("ScrapBagNotUpdated").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub GetStockForVacBagsNotUpdated()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "StockDetailsForVacBagsNotUpdated", DbType.String))

        End With
        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                txtWtAsPerSystem.Text = dtData.Rows(0).Item("VacBagNotUpdated").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub GetStockForScrapBagsNotUsed()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "StockDetailsForScrapBagsNotUsed", DbType.String))

        End With
        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                txtWtAsPerSystem.Text = dtData.Rows(0).Item("ScrapBagNotUsed").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub GetStockForVacBagsNotUsed()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "StockDetailsForVacBagsNotUsed", DbType.String))

        End With
        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                txtWtAsPerSystem.Text = dtData.Rows(0).Item("VacBagNotUsed").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub GetStockForInHand()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "StockInHand", DbType.String))

        End With
        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                txtWtAsPerSystem.Text = dtData.Rows(0).Item("StockInHand").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub cmbBoxName_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbBoxName.SelectedIndexChanged
        If cmbBoxName.SelectedIndex > 0 Then
            If txtWtWithBox.Text > 0 Then
                Me.BoxActualMetal()
            Else
                txtActualMetal.Text = "0.00"
                txtActualFineWt.Text = "0.00"
            End If
        End If
    End Sub

    Private Sub BoxActualMetal()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        Dim BoxWt As Double
        Dim BoxWithMetal As Double
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetBoxWeight", DbType.String))
            .Add(dbManager.CreateParameter("@BoxId", cmbBoxName.SelectedIndex, DbType.String))
        End With
        dtData = dbManager.GetDataTable("SP_BoxMaster_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                BoxWt = dtData.Rows(0).Item("BoxWt").ToString()
                BoxWithMetal = txtWtWithBox.Text.ToString()
                txtActualMetal.Text = Format(CDbl(BoxWithMetal) - CDbl(BoxWt), "0.00")
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub ByBoxActualMetal()
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        Dim BoxWt As Double
        Dim BoxWithMetal As Double
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetBoxWeightByName", DbType.String))
            .Add(dbManager.CreateParameter("@BoxName", cmbBoxName.Text.Trim, DbType.String))
        End With
        dtData = dbManager.GetDataTable("SP_BoxMaster_Select", CommandType.StoredProcedure, parameters.ToArray())
        Try
            If dtData.Rows.Count > 0 Then
                BoxWt = dtData.Rows(0).Item("BoxWt").ToString()
                BoxWithMetal = txtWtWithBox.Text.ToString()
                txtActualMetal.Text = Format(CDbl(BoxWithMetal) - CDbl(BoxWt), "0.00")
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub

    Private Sub txtActualMetal_TextChanged(sender As Object, e As EventArgs) Handles txtActualMetal.TextChanged
        'If Not cmbMelting.Text = "" Then
        '    txtActualFineWt.Text = Format(CDbl(Convert.ToDouble((txtActualMetal.Text) * Convert.ToDouble(cmbMelting.Text) / 100)), "0.00")
        '    txtFineDiff.Text = Format(CDbl(Convert.ToDouble((txtFineWtSys.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
        'End If
        If Not cmbMelting.Text.Trim = "" Then
            If Not txtWtWithBox.Text.Trim = "" Then
                If Not cmbBoxName.Text = "" Then
                    If Not txtActualMetal.Text = "" Then
                        txtActualFineWt.Text = Format(CDbl(Convert.ToDouble((txtActualMetal.Text) * Convert.ToDouble(cmbMelting.Text) / 100)), "0.00")
                        If Not txtActualFineWt.Text = "" Then
                            If Not txtFineWtSys.Text = "" Then
                                txtFineDiff.Text = Format(CDbl(Convert.ToDouble((txtFineWtSys.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    'Private Sub txtActualFineWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtActualFineWt.Validating
    '    Try
    '        If cmbCategoryName.Text.Trim <> "" And cmbBoxName.Text.Trim <> "" And txtWtAsPerSystem.Text.Trim <> "" And txtActualMetal.Text.Trim <> "" And Val(cmbMelting.Text.Trim) > 0 And Val(txtActualFineWt.Text.Trim) > 0 Then

    '            'ErrorProvider1.SetError(txtRequirePr, "")

    '            If dgvStockDetails.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
    '                MsgBox("Duplicate Data")
    '            Else
    '                Me.fillGrid()
    '                'Me.CreateTotal()
    '            End If
    '        Else
    '            'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
    '            MsgBox("Enter Proper Details")
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvStockDetails.Rows
                If itm.Cells(2).Value = CStr(cmbCategoryName.Text.Trim) And itm.Cells(4).Value = CStr(cmbMelting.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists

    End Function
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvStockDetails.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TotalByCategory()
        If btnSave.Text = "Update" Then
            If cmbCategoryName.SelectedIndex = 1 Then
                If cmbCategoryName.Text = "WIP" Then
                    txtWIPGrossWt.Text = Format(Val(txtWIPGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                    txtWIPFWt.Text = Format(Val(txtWIPFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                    txtWIPPr.Text = Format(CDbl(Convert.ToDouble((txtWIPFWt.Text) / Convert.ToDouble(txtWIPGrossWt.Text) * 100)), "0.00")
                    If txtWIPPr.Text = "NaN" Then
                        txtWIPPr.Text = "0.00"
                    End If
                End If
            ElseIf cmbCategoryName.SelectedIndex = 2 Then
                If cmbCategoryName.Text = "Voucher Metal Unused" Then
                    txtVMUGrossWt.Text = Format(Val(txtVMUGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                    txtVMUFWt.Text = Format(Val(txtVMUFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                    txtVMUPr.Text = Format(CDbl(Convert.ToDouble((txtVMUFWt.Text) / Convert.ToDouble(txtVMUGrossWt.Text) * 100)), "0.00")
                    If txtVMUPr.Text = "NaN" Then
                        txtVMUPr.Text = "0.00"
                    End If
                End If
            ElseIf cmbCategoryName.SelectedIndex = 3 Then
                If cmbCategoryName.Text = "Bags Not Created" Then
                    txtBNCGrossWt.Text = Format(Val(txtBNCGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                    txtBNCFWt.Text = Format(Val(txtBNCFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                    txtBNCPr.Text = Format(CDbl(Convert.ToDouble((txtBNCFWt.Text) / Convert.ToDouble(txtBNCGrossWt.Text) * 100)), "0.00")
                    If txtBNCPr.Text = "NaN" Then
                        txtBNCPr.Text = "0.00"
                    End If
                End If
            ElseIf cmbCategoryName.SelectedIndex = 4 Then
                If cmbCategoryName.Text = "ScrapBagNotReceived" Then
                    txtSBNRGrossWt.Text = Format(Val(txtSBNRGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                    txtSBNRFWt.Text = Format(Val(txtSBNRFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                    txtSBNRPr.Text = Format(CDbl(Convert.ToDouble((txtSBNRFWt.Text) / Convert.ToDouble(txtSBNRGrossWt.Text) * 100)), "0.00")
                    If txtSBNRPr.Text = "NaN" Then
                        txtSBNRPr.Text = "0.00"
                    End If
                End If
            ElseIf cmbCategoryName.SelectedIndex = 5 Then
                If cmbCategoryName.Text = "VacBagNotReceived" Then
                    txtVBNRGrossWt.Text = Format(Val(txtVBNRGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                    txtVBNRFWt.Text = Format(Val(txtVBNRFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                    txtVBNRPr.Text = Format(CDbl(Convert.ToDouble((txtVBNRFWt.Text) / Convert.ToDouble(txtVBNRGrossWt.Text) * 100)), "0.00")
                    If txtVBNRPr.Text = "NaN" Then
                        txtVBNRPr.Text = "0.00"
                    End If
                End If
            ElseIf cmbCategoryName.SelectedIndex = 6 Then
                If cmbCategoryName.Text = "ScrapBagNotUpdated" Then
                    txtSBNUGrossWt.Text = Format(Val(txtSBNUGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                    txtSBNUpdFWt.Text = Format(Val(txtSBNUsedFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                    txtSBNUpdPr.Text = Format(CDbl(Convert.ToDouble((txtSBNUpdFWt.Text) / Convert.ToDouble(txtSBNUGrossWt.Text) * 100)), "0.00")
                    If txtSBNUpdPr.Text = "NaN" Then
                        txtSBNUpdPr.Text = "0.00"
                    End If
                End If
            ElseIf cmbCategoryName.SelectedIndex = 7 Then
                If cmbCategoryName.Text = "VacBagNotUpdated" Then
                    txtVBNUpdGrossWt.Text = Format(Val(txtVBNUpdGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                    txtVBNUpdtFWt.Text = Format(Val(txtVBNUpdtFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                    txtVBNUpdtPr.Text = Format(CDbl(Convert.ToDouble((txtVBNUpdtFWt.Text) / Convert.ToDouble(txtVBNUpdGrossWt.Text) * 100)), "0.00")
                    If txtVBNUpdtPr.Text = "NaN" Then
                        txtVBNUpdtPr.Text = "0.00"
                    End If
                End If
            ElseIf cmbCategoryName.SelectedIndex = 8 Then
                If cmbCategoryName.Text = "ScrapBagNotUsed" Then
                    txtSBNUsedGrossWt.Text = Format(Val(txtSBNUsedGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                    txtSBNUsedFWt.Text = Format(Val(txtSBNUsedFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                    txtSBNUsedPr.Text = Format(CDbl(Convert.ToDouble((txtSBNUsedFWt.Text) / Convert.ToDouble(txtSBNUsedGrossWt.Text) * 100)), "0.00")
                    If txtSBNUsedPr.Text = "NaN" Then
                        txtSBNUsedPr.Text = "0.00"
                    End If
                End If
            ElseIf cmbCategoryName.SelectedIndex = 9 Then
                If cmbCategoryName.Text = "VacBagNotUsed" Then
                    txtVBNUsedGrossWt.Text = Format(Val(txtVBNUsedGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                    txtVBNUsedFWt.Text = Format(Val(txtVBNUsedFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                    txtVBNUsedPr.Text = Format(CDbl(Convert.ToDouble((txtVBNUsedFWt.Text) / Convert.ToDouble(txtVBNUsedGrossWt.Text) * 100)), "0.00")
                    If txtVBNUsedPr.Text = "NaN" Then
                        txtVBNUsedPr.Text = "0.00"
                    End If
                End If
            ElseIf cmbCategoryName.SelectedIndex = 10 Then
                If cmbCategoryName.Text = "StockInHand" Then
                    txtSIHGrossWt.Text = Format(Val(txtSIHGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                    txtSIHFWt.Text = Format(Val(txtSIHFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                    txtSIHPr.Text = Format(CDbl(Convert.ToDouble((txtSIHFWt.Text) / Convert.ToDouble(txtSIHGrossWt.Text) * 100)), "0.00")
                    If txtSIHPr.Text = "NaN" Then
                        txtSIHPr.Text = "0.00"
                    End If
                End If
            End If
        Else
            If cmbCategoryName.SelectedIndex = 0 Then

            ElseIf cmbCategoryName.SelectedIndex = 1 Then
                txtWIPGrossWt.Text = Format(Val(txtWIPGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                txtWIPFWt.Text = Format(Val(txtWIPFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                txtWIPPr.Text = Format(CDbl(Convert.ToDouble((txtWIPFWt.Text) / Convert.ToDouble(txtWIPGrossWt.Text) * 100)), "0.00")
                If txtWIPPr.Text = "NaN" Then
                    txtWIPPr.Text = "0.00"
                End If

            ElseIf cmbCategoryName.SelectedIndex = 2 Then
                txtVMUGrossWt.Text = Format(Val(txtVMUGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                txtVMUFWt.Text = Format(Val(txtVMUFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                txtVMUPr.Text = Format(CDbl(Convert.ToDouble((txtVMUFWt.Text) / Convert.ToDouble(txtVMUGrossWt.Text) * 100)), "0.00")
                If txtVMUPr.Text = "NaN" Then
                    txtVMUPr.Text = "0.00"
                End If

            ElseIf cmbCategoryName.SelectedIndex = 3 Then
                txtBNCGrossWt.Text = Format(Val(txtBNCGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                txtBNCFWt.Text = Format(Val(txtBNCFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                txtBNCPr.Text = Format(CDbl(Convert.ToDouble((txtBNCFWt.Text) / Convert.ToDouble(txtBNCGrossWt.Text) * 100)), "0.00")
                If txtBNCPr.Text = "NaN" Then
                    txtBNCPr.Text = "0.00"
                End If

            ElseIf cmbCategoryName.SelectedIndex = 4 Then
                txtSBNRGrossWt.Text = Format(Val(txtSBNRGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                txtSBNRFWt.Text = Format(Val(txtSBNRFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                txtSBNRPr.Text = Format(CDbl(Convert.ToDouble((txtSBNRFWt.Text) / Convert.ToDouble(txtSBNRGrossWt.Text) * 100)), "0.00")
                If txtSBNRPr.Text = "NaN" Then
                    txtSBNRPr.Text = "0.00"
                End If

            ElseIf cmbCategoryName.SelectedIndex = 5 Then
                txtVBNRGrossWt.Text = Format(Val(txtVBNRGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                txtVBNRFWt.Text = Format(Val(txtVBNRFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                txtVBNRPr.Text = Format(CDbl(Convert.ToDouble((txtVBNRFWt.Text) / Convert.ToDouble(txtVBNRGrossWt.Text) * 100)), "0.00")
                If txtVBNRPr.Text = "NaN" Then
                    txtVBNRPr.Text = "0.00"
                End If

            ElseIf cmbCategoryName.SelectedIndex = 6 Then
                txtSBNUGrossWt.Text = Format(Val(txtSBNUGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                txtSBNUpdFWt.Text = Format(Val(txtSBNUsedFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                txtSBNUpdPr.Text = Format(CDbl(Convert.ToDouble((txtSBNUpdFWt.Text) / Convert.ToDouble(txtSBNUGrossWt.Text) * 100)), "0.00")
                If txtSBNUpdPr.Text = "NaN" Then
                    txtSBNUpdPr.Text = "0.00"
                End If

            ElseIf cmbCategoryName.SelectedIndex = 7 Then
                txtVBNUpdGrossWt.Text = Format(Val(txtVBNUpdGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                txtVBNUpdtFWt.Text = Format(Val(txtVBNUpdtFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                txtVBNUpdtPr.Text = Format(CDbl(Convert.ToDouble((txtVBNUpdtFWt.Text) / Convert.ToDouble(txtVBNUpdGrossWt.Text) * 100)), "0.00")
                If txtVBNUpdtPr.Text = "NaN" Then
                    txtVBNUpdtPr.Text = "0.00"
                End If

            ElseIf cmbCategoryName.SelectedIndex = 8 Then
                txtSBNUsedGrossWt.Text = Format(Val(txtSBNUsedGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                txtSBNUsedFWt.Text = Format(Val(txtSBNUsedFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                txtSBNUsedPr.Text = Format(CDbl(Convert.ToDouble((txtSBNUsedFWt.Text) / Convert.ToDouble(txtSBNUsedGrossWt.Text) * 100)), "0.00")
                If txtSBNUsedPr.Text = "NaN" Then
                    txtSBNUsedPr.Text = "0.00"
                End If

            ElseIf cmbCategoryName.SelectedIndex = 9 Then
                txtVBNUsedGrossWt.Text = Format(Val(txtVBNUsedGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                txtVBNUsedFWt.Text = Format(Val(txtVBNUsedFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                txtVBNUsedPr.Text = Format(CDbl(Convert.ToDouble((txtVBNUsedFWt.Text) / Convert.ToDouble(txtVBNUsedGrossWt.Text) * 100)), "0.00")
                If txtVBNUsedPr.Text = "NaN" Then
                    txtVBNUsedPr.Text = "0.00"
                End If

            ElseIf cmbCategoryName.SelectedIndex = 10 Then
                txtSIHGrossWt.Text = Format(Val(txtSIHGrossWt.Text) + Val(txtActualMetal.Text), "0.00")
                txtSIHFWt.Text = Format(Val(txtSIHFWt.Text) + Val(txtActualFineWt.Text), "0.00")
                txtSIHPr.Text = Format(CDbl(Convert.ToDouble((txtSIHFWt.Text) / Convert.ToDouble(txtSIHGrossWt.Text) * 100)), "0.00")
                If txtSIHPr.Text = "NaN" Then
                    txtSIHPr.Text = "0.00"
                End If
            End If
        End If
    End Sub
    Sub fillGrid()

        If btnSave.Text = "&Save" Then
            If GridDoubleClick = False Then
                dgvStockDetails.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbCategoryName.SelectedValue,
                                    CStr(cmbCategoryName.Text.Trim),
                                    Format(Val(cmbMelting.Text.Trim), "0.00"),
                                    Format(Val(txtWtWithBox.Text.Trim), "0.00"),
                                    cmbBoxName.SelectedValue,
                                    CStr(cmbBoxName.Text.Trim),
                                    Format(Val(txtActualMetal.Text.Trim), "0.000"),
                                    Format(Val(txtWtAsPerSystem.Text.Trim), "0.000"),
                                    Format(Val(txtActualFineWt.Text.Trim), "0.000"),
                                    Format(Val(txtFineWtSys.Text.Trim), "0.000"),
                                    Format(Val(txtFineDiff.Text.Trim), "0.000"),
                                    1,
                                    CStr(txtGRemark.Text.Trim()))
                GetSrNo(dgvStockDetails)

            Else
                dgvStockDetails.Rows.Add(Val(txtSrNo.Text.Trim),
                                  cmbCategoryName.SelectedValue,
                                    CStr(cmbCategoryName.Text.Trim),
                                    Format(Val(cmbMelting.Text.Trim), "0.00"),
                                    Format(Val(txtWtWithBox.Text.Trim), "0.00"),
                                    cmbBoxName.Tag,
                                    CStr(cmbBoxName.Text.Trim),
                                    Format(Val(txtActualMetal.Text.Trim), "0.000"),
                                    Format(Val(txtWtAsPerSystem.Text.Trim), "0.000"),
                                    Format(Val(txtActualFineWt.Text.Trim), "0.000"),
                                    Format(Val(txtFineWtSys.Text.Trim), "0.000"),
                                    Format(Val(txtFineDiff.Text.Trim), "0.000"),
                                     1,
                                    CStr(txtGRemark.Text.Trim()))
                GetSrNo(dgvStockDetails)
            End If
            Me.Total()
            'txtSrNo.Text = dgvStockDetails.RowCount + 1
            'cmbCategoryName.SelectedIndex = 0
            'cmbMelting.SelectedIndex = 0
            'txtWtWithBox.Clear()
            'cmbBoxName.SelectedIndex = 0
            'txtActualMetal.Clear()
            'txtWtAsPerSystem.Clear()
            'txtActualFineWt.Clear()
        Else
            'If cmbItem.SelectedIndex > 0 Then
            If GridDoubleClick = False Then
                dgvStockDetails.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbCategoryName.SelectedValue,
                                    CStr(cmbCategoryName.Text.Trim),
                                    Format(Val(cmbMelting.Text.Trim), "0.00"),
                                    Format(Val(txtWtWithBox.Text.Trim), "0.00"),
                                    cmbBoxName.SelectedValue,
                                    CStr(cmbBoxName.Text.Trim),
                                    Format(Val(txtActualMetal.Text.Trim), "0.000"),
                                    Format(Val(txtWtAsPerSystem.Text.Trim), "0.000"),
                                    Format(Val(txtActualFineWt.Text.Trim), "0.000"),
                                    Format(Val(txtFineWtSys.Text.Trim), "0.000"),
                                    Format(Val(txtFineDiff.Text.Trim), "0.000"),
                                    1,
                                    CStr(txtGRemark.Text.Trim()))
                GetSrNo(dgvStockDetails)
            Else
                dgvStockDetails.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbCategoryName.SelectedValue,
                                    CStr(cmbCategoryName.Text.Trim),
                                    Format(Val(cmbMelting.Text.Trim), "0.00"),
                                    Format(Val(txtWtWithBox.Text.Trim), "0.00"),
                                    cmbBoxName.Tag,
                                    CStr(cmbBoxName.Text.Trim),
                                    Format(Val(txtActualMetal.Text.Trim), "0.000"),
                                    Format(Val(txtWtAsPerSystem.Text.Trim), "0.000"),
                                    Format(Val(txtActualFineWt.Text.Trim), "0.000"),
                                    Format(Val(txtFineWtSys.Text.Trim), "0.000"),
                                    Format(Val(txtFineDiff.Text.Trim), "0.000"),
                                    CStr(txtGRemark.Tag.Trim()),
                                    CStr(txtGRemark.Text.Trim()))
                'CStr(txtFineDiff.Tag.Trim()))
                'dgvStockDetails.Rows.Add(Val(txtSrNo.Text.Trim), cmbCategoryName.Tag, cmbCategoryName.Text, cmbMelting.Text, txtWtWithBox.Text.Trim(), cmbBoxName.Tag, cmbBoxName.Text, Format(Val(txtActualMetal.Text.Trim), "0.00"), Format(Val(txtWtAsPerSystem.Text.Trim), "0.00"), Format(Val(txtActualFineWt.Text.Trim), "0.00"), Format(Val(txtFineWtSys.Text.Trim), "0.00"), Format(Val(txtFineDiff.Text.Trim), "0.00"), txtGRemark.Text, txtGRemark.Text, txtGRemark.Text, txtGRemark.Text, txtGRemark.Text)
                GetSrNo(dgvStockDetails)
            End If
            Me.Total()
            'txtSrNo.Text = dgvStockDetails.RowCount + 1
            'cmbCategoryName.Text = ""
            'cmbCategoryName.SelectedIndex = 0
            'cmbMelting.Text = ""
            'cmbMelting.SelectedIndex = 0
            'txtWtWithBox.Clear()
            'cmbBoxName.Text = ""
            'cmbBoxName.SelectedIndex = 0
            'txtActualMetal.Clear()
            'txtWtAsPerSystem.Clear()
            'txtActualFineWt.Clear()
            'txtFineWtSys.Clear()
            'txtFineDiff.Clear()
            'txtGRemark.Clear()
        End If
    End Sub
    Sub Total()
        Dim sRPrTotal As Single = 0
        Try
            lblTotMeltPr.Text = 0.00
            lblTotWtWithBox.Text = 0.00
            lblTotActualMetal.Text = 0.00
            lblTotWtAsPerSys.Text = 0.00
            lblTotFineWtScale.Text = 0.00
            lblTotFineWtSys.Text = 0.00
            lblTotFineDiff.Text = 0.00

            For Each row As GridViewRowInfo In dgvStockDetails.Rows
                lblTotWtWithBox.Text = Format(Val(lblTotWtWithBox.Text) + Val(row.Cells(4).Value), "0.00")
                lblTotActualMetal.Text = Format(Val(lblTotActualMetal.Text) + Val(row.Cells(7).Value), "0.00")
                lblTotWtAsPerSys.Text = Format(Val(lblTotWtAsPerSys.Text) + Val(row.Cells(8).Value), "0.00")
                lblTotFineWtScale.Text = Format(Val(lblTotFineWtScale.Text) + Val(row.Cells(9).Value), "0.00")
                lblTotFineWtSys.Text = Format(Val(lblTotFineWtSys.Text) + Val(row.Cells(10).Value), "0.00")
                lblTotFineDiff.Text = Format(Val(lblTotFineDiff.Text) + Val(row.Cells(11).Value), "0.000")
            Next

            If lblTotFineWtScale.Text > 0 Then
                sRPrTotal = Format((Val(lblTotFineWtScale.Text) / Val(lblTotActualMetal.Text)) * 100, "0.000")
            End If
            lblTotMeltPr.Text = Format(sRPrTotal, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbMelting_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMelting.SelectedValueChanged
        'If cmbCategoryName.SelectedIndex > 0 And Val(txtActualFineWt.Text.Trim) > 0 Then
        '    txtFineWtSys.Text = Format(CDbl(Convert.ToDouble((txtWtAsPerSystem.Text) * Convert.ToDouble(cmbMelting.Text) / 100)), "0.00")
        'End If
    End Sub

    Private Sub txtActualFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtActualFineWt.TextChanged
        If Not cmbCategoryName.Text.Trim = "" Then
            If Not cmbBoxName.Text.Trim = "" Then
                If Not cmbMelting.Text = "" Then
                    If Not txtWtAsPerSystem.Text = "" Then
                        txtFineWtSys.Text = Format(CDbl(Convert.ToDouble((txtWtAsPerSystem.Text) * Convert.ToDouble(cmbMelting.Text) / 100)), "0.00")
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If dgvStockDetails.RowCount > 0 Then
            If btnSave.Text = "&Save" Then
                If txtHRemark.Text.Trim <> "" Then
                    Me.SaveData()
                Else
                    MsgBox("Please Give Remark")
                End If
            Else

                If dgvStockDetails.RowCount > 0 Then
                    Dim StockId = txtHRemark.Tag
                    Me.DeleteByStockId(StockId)
                    Me.UpdateData()
                    btnSave.Text = "&Save"
                    ' dgvStockDetails.DataSource = Nothing
                Else
                    MessageBox.Show("Please Enter Proper details")
                End If
            End If
        End If
        Me.FillStockList()
        Me.Clear()
    End Sub
    Private Sub DeleteByStockId(StockId)
        'If (MsgBox("Are You Sure To Delete This Record ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
        Try
            If dgvStockDetails.RowCount > 0 Then
                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()
                With parameters
                    .Add(dbManager.CreateParameter("@StockId", txtHRemark.Tag, DbType.Int16))
                End With
                dbManager.Delete("SP_fDailyStock_Delete", CommandType.StoredProcedure, parameters.ToArray())
                'MessageBox.Show("Stock Delete Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'dgvStockDetails.RowCount = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        ' End If

    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim LabourId As String = Nothing
        Dim StockCategoryId As String = Nothing
        Dim MeltingId As String = Nothing
        Dim WtWithBox As String = ""
        Dim BoxId As String = Nothing
        Dim ActualMetalWt As String = ""
        Dim WtAsPerSystem As String = ""
        Dim FineWtAsPerScale As String = ""
        Dim FineWtAsPerSystem As String = ""
        Dim FineDiff As String = ""
        Dim Remark As String = ""

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(cmbTLabour.Tag)
        alParaval.Add(txtHRemark.Text)

        For Each row As GridViewRowInfo In dgvStockDetails.Rows
            If row.Cells(1).Value <> Nothing Then
                If StockCategoryId = Nothing Then
                    StockCategoryId = Convert.ToString(row.Cells(1).Value)
                    MeltingId = Convert.ToString(row.Cells(3).Value)
                    WtWithBox = Val(row.Cells(4).Value)
                    BoxId = Val(row.Cells(5).Value)
                    ActualMetalWt = Val(row.Cells(7).Value)
                    WtAsPerSystem = Val(row.Cells(8).Value)
                    FineWtAsPerScale = Val(row.Cells(9).Value)
                    FineWtAsPerSystem = Val(row.Cells(10).Value)
                    FineDiff = Val(row.Cells(11).Value)
                    Remark = Convert.ToString(row.Cells(13).Value)
                Else
                    StockCategoryId = StockCategoryId & "|" & Convert.ToString(row.Cells(1).Value)
                    MeltingId = MeltingId & "|" & Convert.ToString(row.Cells(3).Value)
                    WtWithBox = WtWithBox & "|" & Val(row.Cells(4).Value)
                    BoxId = BoxId & "|" & row.Cells(5).Value
                    ActualMetalWt = ActualMetalWt & "|" & row.Cells(7).Value
                    WtAsPerSystem = WtAsPerSystem & "|" & row.Cells(8).Value
                    FineWtAsPerScale = FineWtAsPerScale & "|" & Val(row.Cells(9).Value)
                    FineWtAsPerSystem = FineWtAsPerSystem & "|" & Val(row.Cells(10).Value)
                    FineDiff = FineDiff & "|" & Val(row.Cells(11).Value)
                    Remark = Remark & "|" & Convert.ToString(row.Cells(13).Value)
                End If
            End If
            IRowCount += 1
        Next

        'alParaval.Add(LabourId)

        alParaval.Add(StockCategoryId)
        alParaval.Add(MeltingId)
        alParaval.Add(WtWithBox)
        alParaval.Add(BoxId)
        alParaval.Add(ActualMetalWt)
        alParaval.Add(WtAsPerSystem)
        alParaval.Add(FineWtAsPerScale)
        alParaval.Add(FineWtAsPerSystem)
        alParaval.Add(FineDiff)
        alParaval.Add(Remark)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HLabourId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HRemarks", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DStockCategoryId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DMeltingId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DWtWithBox", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DBoxId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DActualMetalWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DWtAsPerSystem", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWtAsPerScale", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWtAsPerSystem", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineDiff", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DGRemark", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
            End With

            dbManager.Insert("SP_fStockDetails_Select", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateData()
        Dim alParaval As New ArrayList

        Dim LabourId As String = Nothing
        Dim StockCategoryId As String = Nothing
        Dim MeltingId As String = Nothing
        Dim WtWithBox As String = ""
        Dim BoxId As String = Nothing
        Dim ActualMetalWt As String = ""
        Dim WtAsPerSystem As String = ""
        Dim FineWtAsPerScale As String = ""
        Dim FineWtAsPerSystem As String = ""
        Dim FineDiff As String = ""
        Dim Remark As String = ""

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(txtHRemark.Tag)
        alParaval.Add(cmbTLabour.Tag)
        alParaval.Add(txtHRemark.Text)

        For Each row As GridViewRowInfo In dgvStockDetails.Rows
            If row.Cells(1).Value <> Nothing Then
                If StockCategoryId = Nothing Then
                    StockCategoryId = Convert.ToString(row.Cells(1).Value)
                    MeltingId = Convert.ToString(row.Cells(3).Value)
                    WtWithBox = Val(row.Cells(4).Value)
                    BoxId = Val(row.Cells(5).Value)
                    ActualMetalWt = Val(row.Cells(7).Value)
                    WtAsPerSystem = Val(row.Cells(8).Value)
                    FineWtAsPerScale = Val(row.Cells(9).Value)
                    FineWtAsPerSystem = Val(row.Cells(10).Value)
                    FineDiff = Val(row.Cells(11).Value)
                    Remark = Convert.ToString(row.Cells(13).Value)
                Else
                    StockCategoryId = StockCategoryId & "|" & Convert.ToString(row.Cells(1).Value)
                    MeltingId = MeltingId & "|" & Convert.ToString(row.Cells(3).Value)
                    WtWithBox = WtWithBox & "|" & Val(row.Cells(4).Value)
                    BoxId = BoxId & "|" & row.Cells(5).Value
                    ActualMetalWt = ActualMetalWt & "|" & row.Cells(7).Value
                    WtAsPerSystem = WtAsPerSystem & "|" & row.Cells(8).Value
                    FineWtAsPerScale = FineWtAsPerScale & "|" & Val(row.Cells(9).Value)
                    FineWtAsPerSystem = FineWtAsPerSystem & "|" & Val(row.Cells(10).Value)
                    FineDiff = FineDiff & "|" & Val(row.Cells(11).Value)
                    Remark = Remark & "|" & Convert.ToString(row.Cells(13).Value)
                End If
            End If
            IRowCount += 1
        Next

        'alParaval.Add(LabourId)

        alParaval.Add(StockCategoryId)
        alParaval.Add(MeltingId)
        alParaval.Add(WtWithBox)
        alParaval.Add(BoxId)
        alParaval.Add(ActualMetalWt)
        alParaval.Add(WtAsPerSystem)
        alParaval.Add(FineWtAsPerScale)
        alParaval.Add(FineWtAsPerSystem)
        alParaval.Add(FineDiff)
        alParaval.Add(Remark)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@StockId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLabourId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HRemarks", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DStockCategoryId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DMeltingId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DWtWithBox", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DBoxId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DActualMetalWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DWtAsPerSystem", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWtAsPerScale", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWtAsPerSystem", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineDiff", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DGRemark", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
            End With
            dbManager.Insert("SP_DailyStockDetails_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub

    Private Sub dgvStockDetails_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvStockDetails.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            If btnSave.Text = "Update" Then
                If e.RowIndex >= 0 And dgvStockDetails.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                    GridDoubleClick = True
                    txtSrNo.Text = dgvStockDetails.Rows(e.RowIndex).Cells(0).Value.ToString()
                    cmbCategoryName.Tag = dgvStockDetails.Rows(e.RowIndex).Cells(1).Value.ToString()
                    cmbCategoryName.Text = dgvStockDetails.Rows(e.RowIndex).Cells(2).Value.ToString()
                    cmbMelting.Text = dgvStockDetails.Rows(e.RowIndex).Cells(3).Value.ToString()
                    txtWtWithBox.Text = dgvStockDetails.Rows(e.RowIndex).Cells(4).Value.ToString()
                    cmbBoxName.Tag = dgvStockDetails.Rows(e.RowIndex).Cells(5).Value.ToString()
                    cmbBoxName.Text = CStr(dgvStockDetails.Rows(e.RowIndex).Cells(6).Value)
                    txtActualMetal.Text = CStr(dgvStockDetails.Rows(e.RowIndex).Cells(7).Value)
                    txtWtAsPerSystem.Text = dgvStockDetails.Rows(e.RowIndex).Cells(8).Value.ToString()
                    txtActualFineWt.Text = dgvStockDetails.Rows(e.RowIndex).Cells(9).Value.ToString()
                    txtFineWtSys.Text = dgvStockDetails.Rows(e.RowIndex).Cells(10).Value.ToString()
                    txtFineDiff.Text = dgvStockDetails.Rows(e.RowIndex).Cells(11).Value.ToString()
                    txtGRemark.Tag = dgvStockDetails.Rows(e.RowIndex).Cells(12).Value.ToString()
                    txtGRemark.Text = dgvStockDetails.Rows(e.RowIndex).Cells(13).Value.ToString()
                    'txtFineDiff.Tag = dgvStockDetails.Rows(e.RowIndex).Cells(14).Value.ToString()
                    TempRow = e.RowIndex
                    cmbCategoryName.Focus()
                End If
                Dim StockCategoryId1 As Integer = cmbCategoryName.Tag
                If StockCategoryId1 = 1 Then
                    txtWIPGrossWt.Text = Format(CDbl(Convert.ToDouble((txtWIPGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtWIPFWt.Text = Format(CDbl(Convert.ToDouble((txtWIPFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtWIPPr.Text = Format(CDbl(Convert.ToDouble((txtWIPFWt.Text) / Convert.ToDouble(txtWIPGrossWt.Text) * 100)), "0.00")
                    If txtWIPPr.Text = "NaN" Then
                        txtWIPPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 2 Then
                    txtVMUGrossWt.Text = Format(CDbl(Convert.ToDouble((txtVMUGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtVMUFWt.Text = Format(CDbl(Convert.ToDouble((txtVMUFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtVMUPr.Text = Format(CDbl(Convert.ToDouble((txtVMUFWt.Text) / Convert.ToDouble(txtVMUGrossWt.Text) * 100)), "0.00")
                    If txtVMUPr.Text = "NaN" Then
                        txtVMUPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 3 Then
                    txtBNCGrossWt.Text = Format(CDbl(Convert.ToDouble((txtBNCGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtBNCFWt.Text = Format(CDbl(Convert.ToDouble((txtBNCFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtBNCPr.Text = Format(CDbl(Convert.ToDouble((txtBNCFWt.Text) / Convert.ToDouble(txtBNCGrossWt.Text) * 100)), "0.00")
                    If txtBNCPr.Text = "NaN" Then
                        txtBNCPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 4 Then
                    txtSBNRGrossWt.Text = Format(CDbl(Convert.ToDouble((txtSBNRGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtSBNRFWt.Text = Format(CDbl(Convert.ToDouble((txtSBNRFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtSBNRPr.Text = Format(CDbl(Convert.ToDouble((txtSBNRFWt.Text) / Convert.ToDouble(txtSBNRGrossWt.Text) * 100)), "0.00")
                    If txtSBNRPr.Text = "NaN" Then
                        txtSBNRPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 5 Then
                    txtVBNRGrossWt.Text = Format(CDbl(Convert.ToDouble((txtVBNRGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtVBNRFWt.Text = Format(CDbl(Convert.ToDouble((txtVBNRFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtVBNRPr.Text = Format(CDbl(Convert.ToDouble((txtVBNRFWt.Text) / Convert.ToDouble(txtVBNRGrossWt.Text) * 100)), "0.00")
                    If txtVBNRPr.Text = "NaN" Then
                        txtVBNRPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 6 Then
                    txtSBNUGrossWt.Text = Format(CDbl(Convert.ToDouble((txtSBNUGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtSBNUpdFWt.Text = Format(CDbl(Convert.ToDouble((txtSBNUpdFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtSBNUpdPr.Text = Format(CDbl(Convert.ToDouble((txtSBNUpdFWt.Text) / Convert.ToDouble(txtSBNUGrossWt.Text) * 100)), "0.00")
                    If txtSBNUpdPr.Text = "NaN" Then
                        txtSBNUpdPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 7 Then
                    txtVBNUpdGrossWt.Text = Format(CDbl(Convert.ToDouble((txtVBNUpdGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtVBNUpdtFWt.Text = Format(CDbl(Convert.ToDouble((txtVBNUpdtFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtVBNUpdtPr.Text = Format(CDbl(Convert.ToDouble((txtVBNUpdtFWt.Text) / Convert.ToDouble(txtVBNUpdGrossWt.Text) * 100)), "0.00")
                    If txtVBNUpdtPr.Text = "NaN" Then
                        txtVBNUpdtPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 8 Then
                    txtSBNUsedGrossWt.Text = Format(CDbl(Convert.ToDouble((txtSBNUsedGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtSBNUsedFWt.Text = Format(CDbl(Convert.ToDouble((txtSBNUsedFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtSBNUsedPr.Text = Format(CDbl(Convert.ToDouble((txtSBNUsedFWt.Text) / Convert.ToDouble(txtWIPGrossWt.Text) * 100)), "0.00")
                    If txtSBNUsedPr.Text = "NaN" Then
                        txtSBNUsedPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 9 Then
                    txtVBNUsedGrossWt.Text = Format(CDbl(Convert.ToDouble((txtVBNUsedGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtVBNUsedFWt.Text = Format(CDbl(Convert.ToDouble((txtVBNUsedFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtVBNUsedPr.Text = Format(CDbl(Convert.ToDouble((txtVBNUsedFWt.Text) / Convert.ToDouble(txtVBNUsedGrossWt.Text) * 100)), "0.00")
                    If txtVBNUsedPr.Text = "NaN" Then
                        txtVBNUsedPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 10 Then
                    txtSIHGrossWt.Text = Format(CDbl(Convert.ToDouble((txtSIHGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtSIHFWt.Text = Format(CDbl(Convert.ToDouble((txtSIHFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtSIHPr.Text = Format(CDbl(Convert.ToDouble((txtSIHFWt.Text) / Convert.ToDouble(txtSIHGrossWt.Text) * 100)), "0.00")
                    If txtSIHPr.Text = "NaN" Then
                        txtSIHPr.Text = "0.00"
                    End If
                End If

            Else
                If e.RowIndex >= 0 And dgvStockDetails.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                    GridDoubleClick = True
                    txtSrNo.Text = dgvStockDetails.Rows(e.RowIndex).Cells(0).Value.ToString()
                    cmbCategoryName.Tag = dgvStockDetails.Rows(e.RowIndex).Cells(1).Value.ToString()
                    cmbCategoryName.Text = dgvStockDetails.Rows(e.RowIndex).Cells(2).Value.ToString()
                    cmbMelting.Text = dgvStockDetails.Rows(e.RowIndex).Cells(3).Value.ToString()
                    txtWtWithBox.Text = dgvStockDetails.Rows(e.RowIndex).Cells(4).Value.ToString()
                    cmbBoxName.Tag = dgvStockDetails.Rows(e.RowIndex).Cells(5).Value.ToString()
                    cmbBoxName.Text = CStr(dgvStockDetails.Rows(e.RowIndex).Cells(6).Value)
                    txtActualMetal.Text = CStr(dgvStockDetails.Rows(e.RowIndex).Cells(7).Value)
                    txtWtAsPerSystem.Text = dgvStockDetails.Rows(e.RowIndex).Cells(8).Value.ToString()
                    txtActualFineWt.Text = dgvStockDetails.Rows(e.RowIndex).Cells(9).Value.ToString()
                    txtFineWtSys.Text = dgvStockDetails.Rows(e.RowIndex).Cells(10).Value.ToString()
                    txtFineDiff.Text = dgvStockDetails.Rows(e.RowIndex).Cells(11).Value.ToString()
                    ' txtGRemark.Tag = dgvStockDetails.Rows(e.RowIndex).Cells(12).Value.ToString()
                    txtGRemark.Text = dgvStockDetails.Rows(e.RowIndex).Cells(13).Value.ToString()
                    'txtFineDiff.Tag = dgvStockDetails.Rows(e.RowIndex).Cells(14).Value.ToString()
                    TempRow = e.RowIndex
                    cmbCategoryName.Focus()
                End If
                Dim StockCategoryId1 As Integer = cmbCategoryName.Tag
                If StockCategoryId1 = 1 Then
                    txtWIPGrossWt.Text = Format(CDbl(Convert.ToDouble((txtWIPGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtWIPFWt.Text = Format(CDbl(Convert.ToDouble((txtWIPFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtWIPPr.Text = Format(CDbl(Convert.ToDouble((txtWIPFWt.Text) / Convert.ToDouble(txtWIPGrossWt.Text) * 100)), "0.00")
                    If txtWIPPr.Text = "NaN" Then
                        txtWIPPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 2 Then
                    txtVMUGrossWt.Text = Format(CDbl(Convert.ToDouble((txtVMUGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtVMUFWt.Text = Format(CDbl(Convert.ToDouble((txtVMUFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtVMUPr.Text = Format(CDbl(Convert.ToDouble((txtVMUFWt.Text) / Convert.ToDouble(txtVMUGrossWt.Text) * 100)), "0.00")
                    If txtVMUPr.Text = "NaN" Then
                        txtVMUPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 3 Then
                    txtBNCGrossWt.Text = Format(CDbl(Convert.ToDouble((txtBNCGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtBNCFWt.Text = Format(CDbl(Convert.ToDouble((txtBNCFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtBNCPr.Text = Format(CDbl(Convert.ToDouble((txtBNCFWt.Text) / Convert.ToDouble(txtBNCGrossWt.Text) * 100)), "0.00")
                    If txtBNCPr.Text = "NaN" Then
                        txtBNCPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 4 Then
                    txtSBNRGrossWt.Text = Format(CDbl(Convert.ToDouble((txtSBNRGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtSBNRFWt.Text = Format(CDbl(Convert.ToDouble((txtSBNRFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtSBNRPr.Text = Format(CDbl(Convert.ToDouble((txtSBNRFWt.Text) / Convert.ToDouble(txtSBNRGrossWt.Text) * 100)), "0.00")
                    If txtSBNRPr.Text = "NaN" Then
                        txtSBNRPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 5 Then
                    txtVBNRGrossWt.Text = Format(CDbl(Convert.ToDouble((txtVBNRGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtVBNRFWt.Text = Format(CDbl(Convert.ToDouble((txtVBNRFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtVBNRPr.Text = Format(CDbl(Convert.ToDouble((txtVBNRFWt.Text) / Convert.ToDouble(txtVBNRGrossWt.Text) * 100)), "0.00")
                    If txtVBNRPr.Text = "NaN" Then
                        txtVBNRPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 6 Then
                    txtSBNUGrossWt.Text = Format(CDbl(Convert.ToDouble((txtSBNUGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtSBNUpdFWt.Text = Format(CDbl(Convert.ToDouble((txtSBNUpdFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtSBNUpdPr.Text = Format(CDbl(Convert.ToDouble((txtSBNUpdFWt.Text) / Convert.ToDouble(txtSBNUGrossWt.Text) * 100)), "0.00")
                    If txtSBNUpdPr.Text = "NaN" Then
                        txtSBNUpdPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 7 Then
                    txtVBNUpdGrossWt.Text = Format(CDbl(Convert.ToDouble((txtVBNUpdGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtVBNUpdtFWt.Text = Format(CDbl(Convert.ToDouble((txtVBNUpdtFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtVBNUpdtPr.Text = Format(CDbl(Convert.ToDouble((txtVBNUpdtFWt.Text) / Convert.ToDouble(txtVBNUpdGrossWt.Text) * 100)), "0.00")
                    If txtVBNUpdtPr.Text = "NaN" Then
                        txtVBNUpdtPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 8 Then
                    txtSBNUsedGrossWt.Text = Format(CDbl(Convert.ToDouble((txtSBNUsedGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtSBNUsedFWt.Text = Format(CDbl(Convert.ToDouble((txtSBNUsedFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtSBNUsedPr.Text = Format(CDbl(Convert.ToDouble((txtSBNUsedFWt.Text) / Convert.ToDouble(txtWIPGrossWt.Text) * 100)), "0.00")
                    If txtSBNUsedPr.Text = "NaN" Then
                        txtSBNUsedPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 9 Then
                    txtVBNUsedGrossWt.Text = Format(CDbl(Convert.ToDouble((txtVBNUsedGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtVBNUsedFWt.Text = Format(CDbl(Convert.ToDouble((txtVBNUsedFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtVBNUsedPr.Text = Format(CDbl(Convert.ToDouble((txtVBNUsedFWt.Text) / Convert.ToDouble(txtVBNUsedGrossWt.Text) * 100)), "0.00")
                    If txtVBNUsedPr.Text = "NaN" Then
                        txtVBNUsedPr.Text = "0.00"
                    End If
                End If
                If StockCategoryId1 = 10 Then
                    txtSIHGrossWt.Text = Format(CDbl(Convert.ToDouble((txtSIHGrossWt.Text) - Convert.ToDouble(txtActualMetal.Text))), "0.00")
                    txtSIHFWt.Text = Format(CDbl(Convert.ToDouble((txtSIHFWt.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
                    txtSIHPr.Text = Format(CDbl(Convert.ToDouble((txtSIHFWt.Text) / Convert.ToDouble(txtSIHGrossWt.Text) * 100)), "0.00")
                    If txtSIHPr.Text = "NaN" Then
                        txtSIHPr.Text = "0.00"
                    End If
                End If
            End If

            With dgvStockDetails
                GridDoubleClick = True
            End With
            With dgvStockDetails
                .Rows.Remove(.CurrentRow)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    Private Sub dgvStockList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvStockList.CellDoubleClick
        If dgvStockList.Rows.Count > 0 Then
            Dim StockId As Integer = dgvStockList.Rows(e.RowIndex).Cells(0).Value.ToString()
            Me.ClearTotalByCategory()
            btnSave.Text = "Update"
            Me.FillHeader(StockId)
            Me.FillGrid(StockId)
            Me.TbInformation.SelectedIndex = 0
            Total()
        End If
    End Sub
    Private Sub FillHeader(ByVal StockId As String)
        Dim dttable As New DataTable
        dttable = fetchAllHeaderUpdate(CStr(StockId))
        Me.GetSrNo(dgvStockDetails)
    End Sub
    Private Function fetchAllHeaderUpdate(ByVal StockId As String) As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "TransHeaderStock", DbType.String))
                .Add(dbManager.CreateParameter("@StockId", Trim(StockId), DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
            cmbTLabour.Text = dtData.Rows(0).Item("LabourName").ToString()
            txtHRemark.Text = dtData.Rows(0).Item("Remarks").ToString()
            txtHRemark.Tag = StockId
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub FillGrid(ByVal StockId As String)
        Dim dttable As New DataTable
        Dim dtData As New DataTable
        dttable = fetchAllDetailsUpdate(CStr(StockId))
        dgvStockDetails.DataSource = Nothing
        dgvStockDetails.DataSource = dttable
        Dim i As Integer
        If dttable.Rows.Count > 0 Then
            For i = 0 To dttable.Rows.Count - 1
                Dim StockCategoryId1 As Integer = Convert.ToInt32(dttable.Rows(i)("StockCategoryId"))
                If StockCategoryId1 = 1 Then
                    dtData = TotalCalculateStockByCategoryId(StockId, StockCategoryId1)
                    txtWIPGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                    txtWIPPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                    txtWIPFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                End If
                If StockCategoryId1 = 2 Then
                    dtData = TotalCalculateStockByCategoryId(StockId, StockCategoryId1)
                    txtVMUGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                    txtVMUPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                    txtVMUFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                End If
                If StockCategoryId1 = 3 Then
                    dtData = TotalCalculateStockByCategoryId(StockId, StockCategoryId1)
                    txtBNCGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                    txtBNCPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                    txtBNCFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                End If
                If StockCategoryId1 = 4 Then
                    dtData = TotalCalculateStockByCategoryId(StockId, StockCategoryId1)
                    txtSBNRGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                    txtSBNRPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                    txtSBNRFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                End If
                If StockCategoryId1 = 5 Then
                    dtData = TotalCalculateStockByCategoryId(StockId, StockCategoryId1)
                    txtVBNRGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                    txtVBNRPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                    txtVBNRFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                End If
                If StockCategoryId1 = 6 Then
                    dtData = TotalCalculateStockByCategoryId(StockId, StockCategoryId1)
                    txtSBNUGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                    txtSBNUpdPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                    txtSBNUpdFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                End If
                If StockCategoryId1 = 7 Then
                    dtData = TotalCalculateStockByCategoryId(StockId, StockCategoryId1)
                    txtVBNUpdGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                    txtVBNUpdtPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                    txtVBNUpdtFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                End If
                If StockCategoryId1 = 8 Then
                    dtData = TotalCalculateStockByCategoryId(StockId, StockCategoryId1)
                    txtSBNUsedGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                    txtSBNUsedPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                    txtSBNUsedFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                End If
                If StockCategoryId1 = 9 Then
                    dtData = TotalCalculateStockByCategoryId(StockId, StockCategoryId1)
                    txtVBNUsedGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                    txtVBNUsedPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                    txtVBNUsedFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                End If
                If StockCategoryId1 = 10 Then
                    dtData = TotalCalculateStockByCategoryId(StockId, StockCategoryId1)
                    txtSIHGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                    txtSIHPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                    txtSIHFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                End If
            Next
        Else
        End If
        Me.Total()
        Me.GetSrNo(dgvStockDetails)
    End Sub

    Private Function TotalCalculateStockByCategoryId(ByVal stockId As Integer, ByVal stockCategoryId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchTotalByStockIDCategory", DbType.String))
            .Add(dbManager.CreateParameter("@StockId", stockId, DbType.Int16))
            .Add(dbManager.CreateParameter("@StockCategoryId", stockCategoryId, DbType.Int16))

        End With
        dtData = dbManager.GetDataTable("SP_DailyStock_Select", CommandType.StoredProcedure, parameters.ToArray())
        Return dtData
    End Function
    Private Function fetchAllDetailsUpdate(ByVal StockId As String) As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "TransUnFinalizeStockData", DbType.String))
                .Add(dbManager.CreateParameter("@StockId", Trim(StockId), DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    'Private Sub FetchDetails(StockId)
    '    Dim dtData As DataTable = New DataTable()
    '    Try
    '        Dim parameters = New List(Of SqlParameter)()
    '        parameters.Clear()
    '        With parameters
    '            .Add(dbManager.CreateParameter("@ActionType", "TransStockDetailsByLabour", DbType.String))
    '            .Add(dbManager.CreateParameter("@StockId", StockId, DbType.String))
    '        End With
    '        dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())
    '        If dtData.Rows.Count > 0 Then
    '            cmbTLabour.Text = dtData.Rows(0).Item("LabourName").ToString()
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Error:- " & ex.Message)
    '    Finally
    '    End Try
    'End Sub

    Private Sub txtFineWtSys_TextChanged(sender As Object, e As EventArgs) Handles txtFineWtSys.TextChanged
        If Not cmbMelting.Text.Trim = "" Then
            txtActualFineWt.Text = Format(CDbl(Convert.ToDouble((txtActualMetal.Text) * Convert.ToDouble(cmbMelting.Text) / 100)), "0.00")
            If Not txtActualFineWt.Text = "" And txtFineWtSys.Text = "" Then
                txtFineDiff.Text = Format(CDbl(Convert.ToDouble((txtFineWtSys.Text) - Convert.ToDouble(txtActualFineWt.Text))), "0.00")
            End If
        Else

        End If
    End Sub

    Private Sub txtGRemark_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtGRemark.Validating
        Try
            If btnSave.Text = "&Save" Then

                'If txtHRemark.Text.Trim <> "" And
                If cmbCategoryName.Text.Trim <> "" And cmbMelting.Text.Trim <> "" And cmbBoxName.Text.Trim <> "" And Format(Val(txtWtWithBox.Text.Trim), "0.00") > 0 And Format(Val(txtActualMetal.Text.Trim), "0.00") > 0 Then
                    If dgvStockDetails.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
                        MsgBox("Duplicate Data")
                    Else
                        Me.TotalByCategory()
                        Me.fillGrid()
                        Me.Clear()
                    End If
                Else
                    'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
                    MsgBox("Enter Proper Details")
                End If
            Else
                Me.TotalByCategory()
                Me.fillGrid()
                cmbCategoryName.SelectedIndex = 0
                cmbMelting.Text = ""
                cmbMelting.SelectedIndex = 0
                cmbMelting.Text = ""
                cmbBoxName.Text = ""
                cmbBoxName.SelectedIndex = 0
                txtWtWithBox.Clear()
                txtActualMetal.Clear()
                txtActualFineWt.Clear()
                txtWtAsPerSystem.Clear()
                txtFineWtSys.Clear()
                txtFineDiff.Clear()
                txtGRemark.Clear()
                txtSrNo.Text = 1

            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtWIPGrossWt_TextChanged(sender As Object, e As EventArgs) Handles txtWIPGrossWt.TextChanged

    End Sub

    Private Sub txtWIPFWt_TextChanged(sender As Object, e As EventArgs) Handles txtWIPFWt.TextChanged

    End Sub

    Private Sub dgvStockDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvStockDetails.KeyDown
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
            If e.KeyCode = Keys.F2 Then
                txtSrNo.Clear()
                cmbCategoryName.SelectedIndex = 0
                cmbMelting.SelectedIndex = 0
                cmbMelting.Text = ""
                txtWtWithBox.Clear()
                cmbBoxName.SelectedIndex = 0
                txtActualMetal.Clear()
                txtWtAsPerSystem.Clear()
                txtActualFineWt.Clear()
                txtGRemark.Clear()
            End If
            With dgvStockDetails
                If e.KeyCode = Keys.F12 Then
                    If btnSave.Text = "&Save" Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        Dim StockDetailsdId As Int16 = dgvStockDetails.SelectedRows(0).Cells(14).Value
                        If (MsgBox("Are You Sure To Delete This Record ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                            Try
                                If dgvStockDetails.RowCount > 0 Then
                                    Dim parameters = New List(Of SqlParameter)()
                                    parameters.Clear()
                                    With parameters
                                        .Add(dbManager.CreateParameter("@StockDetailsId", StockDetailsdId, DbType.Int16))
                                    End With
                                    dbManager.Delete("SP_fDailyStock_Delete", CommandType.StoredProcedure, parameters.ToArray())
                                    MessageBox.Show("Stock Delete Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    .Rows.Remove(.CurrentRow)
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Error:- " & ex.Message)
                            End Try
                        End If
                    End If
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If btnSave.Text = "&Save" Then

        Else
            Me.DeleteData()
        End If
    End Sub
    Private Sub DeleteData()
        Dim StockId As Int16 = dgvStockDetails.SelectedRows(0).Cells(12).Value
        If (MsgBox("Are You Sure To Delete This Record ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
            Try
                If dgvStockDetails.RowCount > 0 Then
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()
                    With parameters
                        .Add(dbManager.CreateParameter("@StockId", StockId, DbType.Int16))
                    End With
                    dbManager.Delete("SP_fDailyStock_Delete", CommandType.StoredProcedure, parameters.ToArray())
                    MessageBox.Show("Stock Delete Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvStockDetails.RowCount = 0
                End If
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnFinalize_Click(sender As Object, e As EventArgs) Handles BtnFinalize.Click
        Me.FinaliseStock()
        Me.ClearTotalByCategory()
        Me.FillStockList()

    End Sub

    Private Sub txtWtWithBox_TextChanged(sender As Object, e As EventArgs) Handles txtWtWithBox.TextChanged
        If cmbBoxName.SelectedIndex > 0 Then
            If txtWtWithBox.Text > 0 Then
                Me.BoxActualMetal()
            Else
                txtActualMetal.Text = "0.00"
                txtActualFineWt.Text = "0.00"
            End If
        Else
            If Not cmbBoxName.Text = "---Select---" Then

            Else
                Me.ByBoxActualMetal()
            End If
        End If
    End Sub
    Private Sub FinaliseStock()
        If (MsgBox("Are You Sure To Finalize This Record ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
            Try
                If btnSave.Text = "&Save" And txtHRemark.Tag = "" Then

                    If dgvStockDetails.RowCount > 0 Then
                        Dim parameters = New List(Of SqlParameter)()
                        parameters.Clear()
                        With parameters
                            .Add(dbManager.CreateParameter("@ActionType", "SaveFinalize", DbType.String))
                        End With
                        dbManager.Update("SP_DailyStock_Finalize", CommandType.StoredProcedure, parameters.ToArray())
                        MessageBox.Show("Stock Finalize Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        dgvStockDetails.RowCount = 0
                    End If
                Else
                    Dim StockId As Integer = txtHRemark.Tag
                    Dim parameters = New List(Of SqlParameter)()
                    parameters.Clear()
                    With parameters
                        .Add(dbManager.CreateParameter("@ActionType", "UpdateFinalize", DbType.String))
                        .Add(dbManager.CreateParameter("@StockId", StockId, DbType.Int16))
                    End With
                    dbManager.Update("SP_DailyStock_Finalize", CommandType.StoredProcedure, parameters.ToArray())
                    MessageBox.Show("Stock Finalize Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    dgvStockDetails.DataSource = Nothing
                End If
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.ClearTotalByCategory()
        dgvStockDetails.RowCount = 0
        Me.FillStockList()
    End Sub
    Private Sub ClearTotalByCategory()
        btnSave.Text = "&Save"
        GridDoubleClick = False
        dgvStockDetails.DataSource = Nothing
        txtHRemark.Clear()
        cmbCategoryName.SelectedIndex = 0
        cmbMelting.Text = ""
        cmbMelting.SelectedIndex = 0
        cmbMelting.Text = ""
        cmbBoxName.Text = ""
        cmbBoxName.SelectedIndex = 0
        txtWtWithBox.Clear()
        txtActualMetal.Clear()
        txtActualFineWt.Clear()
        txtWtAsPerSystem.Clear()
        txtFineWtSys.Clear()
        txtFineDiff.Clear()
        txtGRemark.Clear()
        txtSrNo.Text = 1

        lblTotMeltPr.Text = "0.00"
        lblTotWtWithBox.Text = "0.00"
        lblTotActualMetal.Text = "0.00"
        lblTotWtAsPerSys.Text = "0.00"
        lblTotFineWtScale.Text = "0.00"
        lblTotFineWtSys.Text = "0.00"
        lblTotFineDiff.Text = "0.00"

        txtWIPGrossWt.Text = "0.00"
        txtWIPPr.Text = "0.00"
        txtWIPFWt.Text = "0.00"

        txtVMUGrossWt.Text = "0.00"
        txtVMUPr.Text = "0.00"
        txtVMUFWt.Text = "0.00"

        txtBNCGrossWt.Text = "0.00"
        txtBNCPr.Text = "0.00"
        txtBNCFWt.Text = "0.00"

        txtSBNRGrossWt.Text = "0.00"
        txtSBNRPr.Text = "0.00"
        txtSBNRFWt.Text = "0.00"

        txtVBNRGrossWt.Text = "0.00"
        txtVBNRPr.Text = "0.00"
        txtVBNRFWt.Text = "0.00"

        txtSBNUGrossWt.Text = "0.00"
        txtSBNUpdPr.Text = "0.00"
        txtSBNUpdFWt.Text = "0.00"

        txtVBNUpdGrossWt.Text = "0.00"
        txtVBNUpdtPr.Text = "0.00"
        txtVBNUpdtFWt.Text = "0.00"

        txtSBNUsedGrossWt.Text = "0.00"
        txtSBNUsedPr.Text = "0.00"
        txtSBNUsedFWt.Text = "0.00"

        txtVBNUsedGrossWt.Text = "0.00"
        txtVBNUsedPr.Text = "0.00"
        txtVBNUsedFWt.Text = "0.00"

        txtSIHGrossWt.Text = "0.00"
        txtSIHPr.Text = "0.00"
        txtSIHFWt.Text = "0.00"
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Try
            If dgvStockDetails.RowCount > 0 Then
                Me.Cursor = Cursors.WaitCursor
                Me.dgvStockDetails.PrintPreview()
            Else
                MessageBox.Show("No Data to Print")
            End If
        Catch ex As Exception
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmbMelting_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbMelting.SelectedIndexChanged

    End Sub

    Private Sub txtWtAsPerSystem_TextChanged(sender As Object, e As EventArgs) Handles txtWtAsPerSystem.TextChanged
        If Not txtWtAsPerSystem.Text = "" Then
            If Not cmbMelting.Text.Trim = "" Then
                If txtWtAsPerSystem.Text > 0 Then
                    txtFineWtSys.Text = Format(CDbl(Convert.ToDouble((txtWtAsPerSystem.Text) * Convert.ToDouble(cmbMelting.Text) / 100)), "0.00")
                End If
            End If
        End If
        'If cmbCategoryName.SelectedIndex = 1 Then
        '    Me.GetStockForWIP()
        'ElseIf cmbCategoryName.SelectedIndex = 2 Then
        '    Me.GetStockForVoucherMetalUnUsed()
        'ElseIf cmbCategoryName.SelectedIndex = 3 Then
        '    Me.GetStockForBagsNotCreated()
        'ElseIf cmbCategoryName.SelectedIndex = 4 Then
        '    Me.GetStockForScrapBagsNotReceived()
        'ElseIf cmbCategoryName.SelectedIndex = 5 Then
        '    Me.GetStockForVacBagsNotReceived()
        'ElseIf cmbCategoryName.SelectedIndex = 6 Then
        '    Me.GetStockForScrapBagsNotUpdated()
        'ElseIf cmbCategoryName.SelectedIndex = 7 Then
        '    Me.GetStockForVacBagsNotUpdated()
        'ElseIf cmbCategoryName.SelectedIndex = 8 Then
        '    Me.GetStockForScrapBagsNotUsed()
        'ElseIf cmbCategoryName.SelectedIndex = 9 Then
        '    Me.GetStockForVacBagsNotUsed()
        'ElseIf cmbCategoryName.SelectedIndex = 10 Then
        '    Me.GetStockForInHand()
        'End If
    End Sub
    Private Sub BtnStockSummary_Click(sender As Object, e As EventArgs) Handles BtnStockSummary.Click
        Me.Close()
        Dim ObjScrapBagNotUpdate As New frmStockSummary
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub
    Private Sub fillStockCategoryName()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetStockCategory", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbCategoryName.DataSource = dt
            cmbCategoryName.DisplayMember = "stockcategoryName"
            cmbCategoryName.ValueMember = "StockCategoryId"
            cmbCategoryName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbCategoryName.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillMelting()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillMeltingCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            'row(0) = 0
            'row(1) = "---Select---"
            'dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbMelting.DataSource = dt
            cmbMelting.DisplayMember = "MeltingValue"
            cmbMelting.ValueMember = "MeltingId"

            'Newly Added
            cmbMelting.Refresh()
            If cmbMelting.Items.Count > 0 Then cmbMelting.Text = ""

            cmbMelting.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbMelting.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillBoxName()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "GetBoxName", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbBoxName.DataSource = dt
            cmbBoxName.DisplayMember = "BoxName"
            cmbBoxName.ValueMember = "BoxId"

            'Newly Added
            cmbBoxName.Refresh()
            If cmbBoxName.Items.Count > 0 Then cmbBoxName.SelectedIndex = 0

            cmbBoxName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbBoxName.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub

End Class