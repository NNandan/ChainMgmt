Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFaBhukaBag
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer

    Dim GridDoubleClick As Boolean

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
                    '    Me.Lbl_Tran_Mode.Text = "NEW MODE"
                    '    Me.txtAccountName.BackColor = Color.LemonChiffon
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "&Save"
                Case FormState.EStateMode
                    'Me.Lbl_Tran_Mode.Text = "EDIT MODE"
                    'Me.txtAccountName.BackColor = Color.LemonChiffon
                    Me.btnSave.Text = "&Update"
            End Select
        End Set
    End Property
    Private Sub frmBhukaBag_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FillItemScrapBag()
        Me.filltemName()
        Me.fillAccounting()
        'cmbRBagNo.SelectedIndex = -1
        Me.FillRcmbRBagNo()
        'cmbUBagNo.SelectedIndex = -1
        Me.FillUcmbRBagNo()
        Me.FillUpdatedData()
        Me.Clear_Form()

        'Me.GetMaxBagNo()
    End Sub
    Private Sub FillUpdatedData()
        Dim dtable As DataTable = fetchAllDetails()
        For i As Integer = 0 To dtable.Rows.Count - 1
            If dtable.Rows.Count > 0 Then
                dgvFinalUpdate.DataSource = dtable
                dgvFinalUpdate.ReadOnly = True
            Else
                MessageBox.Show("Data Not Available To Update")
            End If
        Next
    End Sub
    Private Function fetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchSUsedUBagData", DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_fUsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub FillItemScrapBag()
        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillScrapBagItem", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_fOperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        dt.Load(dr)
        Try
            cmbItemScrapBag.DataSource = Nothing
            cmbItemScrapBag.Items.Clear()

            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbItemScrapBag.DataSource = dt
            cmbItemScrapBag.DisplayMember = "ItemName"
            cmbItemScrapBag.ValueMember = "ItemId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub filltemName()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillItemCmb", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

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
    Private Sub txtGrossWt_TextChanged(sender As Object, e As EventArgs) Handles txtGrossWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(cmbMelting.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbMelting_TextChanged(sender As Object, e As EventArgs) Handles cmbMelting.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(cmbMelting.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub fillAccounting()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillMeltingCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbMelting.DataSource = dt
            cmbMelting.DisplayMember = "MeltingValue"
            cmbMelting.ValueMember = "MeltingId"
            cmbMelting.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbMelting.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub txtFineWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFineWt.Validating
        Try
            If cmbItem.Text.Trim <> "---Select---" And txtGrossWt.Text.Trim <> "" And Val(cmbMelting.Text.Trim) > 0 And Val(txtFineWt.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvBhuka.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
                    MsgBox("Duplicate Data")
                Else
                    Me.fillGrid()
                    Me.CreateTotal()
                End If
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
            txtMaxNo.Clear()
            TransDt.Value = DateTime.Now
            txtSrNo.Text = 1
            cmbItem.SelectedIndex = 0
            cmbItemScrapBag.SelectedIndex = 0
            txtGrossWt.Tag = ""
            txtGrossWt.Clear()
            cmbMelting.SelectedIndex = 0
            cmbMelting.Text = ""
            txtFineWt.Clear()
            dgvBhuka.RowCount = 0
            txtRBagName.Text = ""
            txtRIssueWt.Text = ""
            txtRIssuePr.Text = ""
            GridDoubleClick = False
            lblTotalWt.Text = 0.0
            lblTotalPr.Text = 0.0
            lblFineWt.Text = 0.0
            btnSave.Text = "&Save"
            Fr_Mode = FormState.AStateMode
            btnSave.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_CFields() Then Exit Sub
        Try
            If lblMaxNo.Visible = False And txtMaxNo.Visible = False And btnSave.Text = "&Save" Then

                If Fr_Mode = FormState.AStateMode Then
                    'Me.SaveData()
                    Dim Dt As DataTable = Me.SaveData()

                    Me.btnCancel_Click(sender, e)
                Else
                    Me.UpdateData()
                    Me.btnCancel_Click(sender, e)
                End If

            Else
                If (MsgBox("Are You Sure To Update This Update Bag ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                    Try
                        Me.UpdateData()
                        Me.btnCancel_Click(sender, e)
                        btnSave.Text = "&Save"
                    Catch
                    End Try
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Function SaveData() As DataTable
        Dim Dt As DataTable = Nothing
        Dim alParaval As New ArrayList
        Dim GSrNo As String = Nothing
        Dim ItemId As String = Nothing
        Dim ItemName As String = Nothing
        Dim GrossWt As String = Nothing
        Dim Percent As String = Nothing
        Dim FineWt As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0
        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        'alParaval.Add(cmbfDepartment.SelectedValue)
        'alParaval.Add(cmbtDepartment.SelectedIndex)
        'alParaval.Add(txtVocucherNo.Text)
        'alParaval.Add(txtFrKarigar.Tag)
        'alParaval.Add(cmbtKarigar.SelectedValue)
        ''For Details
        For Each row As GridViewRowInfo In dgvBhuka.Rows
            If row.Cells(0).Value <> Nothing Then
                If GSrNo = "" Then
                    GSrNo = Val(row.Cells(0).Value)
                    ItemId = Val(row.Cells(1).Value)
                    GrossWt = Val(row.Cells(3).Value)
                    Percent = Val(row.Cells(4).Value)
                    FineWt = Convert.ToDouble(row.Cells(5).Value)
                Else
                    GSrNo = GSrNo & "|" & Val(row.Cells(0).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(1).Value)
                    GrossWt = GrossWt & "|" & Val(row.Cells(3).Value)
                    Percent = Percent & "|" & Val(row.Cells(4).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(5).Value)
                End If
            End If
            IRowCount += 1
        Next
        alParaval.Add(GSrNo)
        alParaval.Add(ItemId)
        alParaval.Add(GrossWt)
        alParaval.Add(Percent)
        alParaval.Add(FineWt)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@NScrapBagdt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@ActionType", "UpdateScrapData", DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@BId", cmbItemScrapBag.SelectedValue, DbType.Int16))
                'iValue += 1
                .Add(dbManager.CreateParameter("@BagType", "B", DbType.String))
                'iValue += 1
                .Add(dbManager.CreateParameter("@NItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@NGrossWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@NGrossPr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@NFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@NCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@NIsCreated", 1, DbType.Boolean))
                'iValue += 1
                .Add(dbManager.CreateParameter("@NIsActive", 1, DbType.Boolean))
                'iValue += 1
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                'iValue += 1
            End With

            Dt = dbManager.GetDataTable("SP_ScrapBags_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            Try
                Dim icurValue As Integer = 0
                Dim sresult As String = String.Empty
                strSQL = Nothing
                Dim ScrapItemId As String
                ScrapItemId = cmbItemScrapBag.SelectedValue
                strSQL = "Select Max(BagSrNo) from tblfScrapBags where BagID=(select Distinct ItemCode from tblfItemMaster where ItemId=" + ScrapItemId + ")"
                Try
                    sresult = Convert.ToString(dbManager.GetScalarValue(strSQL, CommandType.Text))
                    Int32.TryParse(sresult, icurValue)
                    Dim ScrapBagNo = sresult
                    MessageBox.Show("ScrapBag " + ScrapBagNo + " Created !!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            Catch ex As Exception
            End Try
            'MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
        Return Dt
    End Function
    Private Sub UpdateData()
        Me.DeleteByBagNo()
        Dim alParaval As New ArrayList
        Dim GSrNo As String = Nothing
        Dim ItemId As String = Nothing
        Dim ItemName As String = Nothing
        Dim GrossWt As String = Nothing
        Dim Percent As String = Nothing
        Dim FineWt As String = Nothing
        Dim ScrapDetailsId As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0
        ''For Master
        'alParaval.Add(TransDt.Value.ToString())
        'alParaval.Add(cmbfDepartment.SelectedValue)
        'alParaval.Add(cmbtDepartment.SelectedIndex)
        'alParaval.Add(txtVocucherNo.Text)
        'alParaval.Add(txtFrKarigar.Tag)
        'alParaval.Add(cmbtKarigar.SelectedValue)
        ''For Details
        For Each row As GridViewRowInfo In dgvBhuka.Rows
            If row.Cells(0).Value <> Nothing Then
                If GSrNo = "" Then
                    GSrNo = Val(row.Cells(0).Value)
                    ItemId = Val(row.Cells(1).Value)
                    GrossWt = Val(row.Cells(3).Value)
                    Percent = Val(row.Cells(4).Value)
                    FineWt = Convert.ToDouble(row.Cells(5).Value)
                    ScrapDetailsId = Convert.ToDouble(row.Cells(6).Value)
                Else
                    GSrNo = GSrNo & "|" & Val(row.Cells(0).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(1).Value)
                    GrossWt = GrossWt & "|" & Val(row.Cells(3).Value)
                    Percent = Percent & "|" & Val(row.Cells(4).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(5).Value)
                    ScrapDetailsId = ScrapDetailsId & "|" & Val(row.Cells(6).Value)
                End If
            End If
            IRowCount += 1
        Next
        ' alParaval.Add(GSrNo)
        alParaval.Add(ItemId)
        alParaval.Add(GrossWt)
        alParaval.Add(Percent)
        alParaval.Add(FineWt)
        alParaval.Add(ScrapDetailsId)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                '.Add(dbManager.CreateParameter("@NScrapBagdt", alParaval.Item(iValue), DbType.DateTime))
                'iValue += 1
                .Add(dbManager.CreateParameter("@NItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@NGrossWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@NGrossPr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@NFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@NScrapBagNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@NCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@NIsCreated", 1, DbType.Boolean))
                'iValue += 1
                .Add(dbManager.CreateParameter("@NIsActive", 1, DbType.Boolean))
                'iValue += 1
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
            End With
            dbManager.Update("SP_ScrapBags_Update", CommandType.StoredProcedure, Hparameters.ToArray())
            Dim BagName As String = Nothing
            BagName = txtMaxNo.Text.ToString()

            MessageBox.Show("Scrap Bag " + BagName + " Updated")
            lblMaxNo.Visible = False
            txtMaxNo.Visible = False
            'Try
            '    Dim icurValue As Integer = 0
            '    Dim sresult As String = String.Empty
            '    strSQL = Nothing
            '    Dim ScrapItemId As String
            '    ScrapItemId = cmbItemScrapBag.SelectedValue
            '    strSQL = "Select Max(BagSrNo) from tblfScrapBags where BagID=(Select Distinct ItemCode from tblfItemMaster where ItemId=" + ScrapItemId + ")"
            '    Try
            '        sresult = Convert.ToString(dbManager.GetScalarValue(strSQL, CommandType.Text))
            '        Int32.TryParse(sresult, icurValue)
            '        Dim ScrapBagNo = sresult
            '        MessageBox.Show("ScrapBag " + ScrapBagNo + " Created !!!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Catch ex As Exception
            '        MessageBox.Show("Error:- " & ex.Message)
            '    End Try
            'Catch ex As Exception
            '    End Try
            '    'MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Sub DeleteByBagNo()

    End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvBhuka.Rows
                If itm.Cells(2).Value = CStr(cmbItem.Text.Trim) And itm.Cells(4).Value = CStr(cmbMelting.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists

    End Function
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillGrid()

        If lblMaxNo.Visible = False And txtMaxNo.Visible = False And btnSave.Text = "&Save" Then
            If GridDoubleClick = False Then
                dgvBhuka.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbItem.SelectedValue,
                                    CStr(cmbItem.Text.Trim),
                                    Format(Val(txtGrossWt.Text.Trim), "0.00"),
                                    Format(Val(cmbMelting.Text.Trim), "0.00"),
                                    Format(Val(txtFineWt.Text.Trim), "0.000"))
                GetSrNo(dgvBhuka)
            Else
                dgvBhuka.Rows.Add(Val(txtSrNo.Text.Trim),
                                   cmbItem.SelectedValue,
                                   CStr(cmbItem.Text.Trim),
                                   Format(Val(txtGrossWt.Text.Trim), "0.00"),
                                   Format(Val(cmbMelting.Text.Trim), "0.00"),
                                   Format(Val(txtFineWt.Text.Trim), "0.000"))
                GetSrNo(dgvBhuka)
            End If
            Me.ReceiveTotal()

            'dgvBhuka.TableElement.ScrollToRow(dgvBhuka.Rows.Last) Then

            txtSrNo.Text = dgvBhuka.RowCount + 1
            cmbItem.Text = ""
            cmbItem.SelectedIndex = 0
            txtGrossWt.Clear()
            cmbMelting.Text = ""
            cmbMelting.SelectedIndex = 0
            txtFineWt.Clear()
            cmbItem.Focus()
        Else
            'If cmbItem.SelectedIndex > 0 Then
            If GridDoubleClick = False Then
                dgvBhuka.Rows.Add(Val(txtSrNo.Text.Trim),
                                        cmbItem.Tag,
                                        CStr(cmbItem.Text.Trim),
                                        Format(Val(txtGrossWt.Text.Trim), "0.00"),
                                        Format(Val(cmbMelting.Text.Trim), "0.00"),
                                        Format(Val(txtFineWt.Text.Trim), "0.000"),
                                        Format(Val(txtFineWt.Tag.Trim), "0.000"))

                GetSrNo(dgvBhuka)
            Else
                dgvBhuka.Rows.Add(Val(txtSrNo.Text.Trim),
                                       cmbItem.Tag,
                                       CStr(cmbItem.Text.Trim),
                                       Format(Val(txtGrossWt.Text.Trim), "0.00"),
                                       Format(Val(cmbMelting.Text.Trim), "0.00"),
                                       Format(Val(txtFineWt.Text.Trim), "0.000"),
                                        Format(Val(txtFineWt.Tag.Trim), "0.000"))

                GetSrNo(dgvBhuka)
            End If
            'Else
            'MessageBox.Show("Please Confirm Item...")
            'cmbItem.Focus()
            'End If

            Me.ReceiveTotal()
            'dgvBhuka.TableElement.ScrollToRow(dgvBhuka.Rows.Last) Then
            txtSrNo.Text = dgvBhuka.RowCount + 1
            cmbItem.SelectedIndex = 0
            txtGrossWt.Clear()
            cmbMelting.SelectedIndex = 0
            txtFineWt.Clear()
            cmbItem.Focus()
        End If
    End Sub
    Private Sub tbBhukaBag_Click(sender As Object, e As EventArgs) Handles tbBhukaBag.Click
        'If tbBhukaBag.SelectedIndex = 1 Then
        '    Me.FillRcmbRBagNo()
        'ElseIf tbBhukaBag.SelectedIndex = 2 Then
        '    Me.FillUcmbRBagNo()
        'End If
        If tbBhukaBag.SelectedIndex = 0 Then
            btnCancel_Click(sender, e)
        ElseIf tbBhukaBag.SelectedIndex = 1 Then
            btnRCancel_Click(sender, e)
        ElseIf tbBhukaBag.SelectedIndex = 2 Then
            btnUCancel_Click(sender, e)
        ElseIf tbBhukaBag.SelectedIndex = 3 Then
            Me.FillUpdatedData()
        End If
    End Sub
    Private Sub FillRcmbRBagNo()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillRScrapCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_fScrapBags_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim newBlankRow As DataRow = dt.NewRow()
            dt.Rows.InsertAt(newBlankRow, 0)
            'Assign DataTable as DataSource.
            cmbRBagNo.DataSource = dt
            Me.cmbRBagNo.AutoFilter = True
            cmbRBagNo.DisplayMember = "BagSrNo"
            cmbRBagNo.ValueMember = "BagSrNo"
            cmbRBagNo.Text = ""
            cmbRBagNo.Refresh()
            cmbRBagNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbRBagNo.BestFitColumns(True, False)
            cmbRBagNo.Columns(0).IsVisible = False
            cmbRBagNo.Columns(2).Width = 250
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
    Private Sub FillUcmbRBagNo()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "fillUBhukaBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_fUsedBags_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
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
            cmbUBagNo.Columns(0).IsVisible = False
            cmbUBagNo.Columns(2).Width = 250
            cmbUBagNo.Columns(2).TextAlignment = ContentAlignment.MiddleRight

            Me.cmbUBagNo.MultiColumnComboBoxElement.DropDownWidth = 300
            Me.BackColor = Color.White
        Catch ex As Exception
            ' MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvBhuka.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DisableBtn()
        'btnShow.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Private Sub txtRRecieveWt_TextChanged(sender As Object, e As EventArgs) Handles txtRRecieveWt.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRRecieveWt.Text) + Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtRSample_TextChanged(sender As Object, e As EventArgs) Handles txtRSample.TextChanged
        Try
            txtRTotalWt.Text = Format(Val(txtRRecieveWt.Text) + Val(txtRSample.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtRTotalWt_TextChanged(sender As Object, e As EventArgs) Handles txtRTotalWt.TextChanged
        Try
            txtRGrossLoss.Text = Format(Val(txtRIssueWt.Text) - Val(txtRTotalWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtUreceivePr.TextChanged
        Try
            txtUreceiveFineWt.Text = Format((Val(txtUreceiveWt.Text) * Val(txtUreceivePr.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtUreceiveWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUIssueWt.Text) - Val(txtUreceiveWt.Tag), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceiveFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUreceiveFineWt.TextChanged
        Try
            txtUpdLossFine.Text = Format(Val(txtUIssueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUIssueWt_TextChanged(sender As Object, e As EventArgs) Handles txtUIssueWt.TextChanged
        Try
            txtUGrossLoss.Text = Format(Val(txtUIssueWt.Text) - Val(txtUreceiveWt.Tag), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUIssueFineWt_TextChanged(sender As Object, e As EventArgs) Handles txtUIssueFineWt.TextChanged
        Try
            txtUpdLossFine.Text = Format(Val(txtUIssueFineWt.Text) - Val(txtUreceiveFineWt.Text), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnUSave_Click(sender As Object, e As EventArgs) Handles btnUSave.Click

        If Not Validate_UFields() Then Exit Sub

        Try
            Dim parameters = New List(Of SqlParameter)()

            If btnUSave.Text = "&Save" Then

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                    .Add(dbManager.CreateParameter("@TId", Val(txtUpdTransId.Text.Trim()), DbType.Int16))
                    .Add(dbManager.CreateParameter("@ReportPr", Convert.ToDecimal(txtUreceivePr.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@LossWt", Convert.ToDecimal(txtUpdLossFine.Text.Trim()), DbType.Decimal))
                    .Add(dbManager.CreateParameter("@BagSrNo", (cmbUBagNo.Text), DbType.String))
                End With

                dbManager.Update("SP_fUsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Try
                    Dim parameters1 = New List(Of SqlParameter)()
                    parameters1.Clear()

                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@ActionType", "UpdateReportPr", DbType.String))
                        .Add(dbManager.CreateParameter("@TId", Val(txtUpdTransId.Text.Trim()), DbType.Int16))
                        .Add(dbManager.CreateParameter("@ReportPr", Convert.ToDecimal(txtUreceivePr.Text.Trim()), DbType.Decimal))
                        .Add(dbManager.CreateParameter("@LossWt", Convert.ToDecimal(txtUpdLossFine.Text.Trim()), DbType.Decimal))
                        .Add(dbManager.CreateParameter("@BagSrNo", (cmbUBagNo.Text), DbType.String))
                    End With

                    dbManager.Update("SP_fUsedBagNo_Update", CommandType.StoredProcedure, parameters.ToArray())
                    MessageBox.Show("Data Updated..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnUSave.Text = "&Save"
                    BtnRecvEdit.Enabled = True
                Catch ex As Exception

                End Try
            End If
            Me.btnUCancel_Click(sender, e)
            Me.FillUcmbRBagNo()
            Me.FillUpdatedData()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnUExit_Click(sender As Object, e As EventArgs) Handles btnUExit.Click
        Me.Close()
    End Sub
    Private Sub btnUCancel_Click(sender As Object, e As EventArgs) Handles btnUCancel.Click
        Me.clearUpdateAllData()
    End Sub
    Private Sub bindVacuumBagWt()

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FillRScrapDetails", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Convert.ToString(cmbRBagNo.Text), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ScrapBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                dgvReceiveBhuka.DataSource = Nothing
                dgvReceiveBhuka.DataSource = dtData
                Me.ReceiveTotal()
                Try
                    Dim sresult As String = String.Empty
                    strSQL = Nothing
                    strSQL = "select tblfItemMaster.ItemName from tblfScrapBags inner join tblfItemMaster ON tblfItemMaster.ItemCode=tblfScrapBags.BagId where tblfScrapBags.BagSrNo='" + Convert.ToString(cmbRBagNo.Text) + "'"
                    sresult = Convert.ToString(dbManager.GetScalarValue(strSQL, CommandType.Text))
                    Dim VaccumeBagName = sresult
                    txtRBagName.Text = VaccumeBagName
                Catch ex As Exception

                End Try
            Else
                'MessageBox.Show("No Data Found !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            'MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

    End Sub
    Private Sub btnRCancel_Click(sender As Object, e As EventArgs) Handles btnRCancel.Click
        Me.clearReceiveAllData()
    End Sub
    Sub CreateTotal()
        lblTotalWt.Text = 0.00
        lblTotalPr.Text = 0.00
        lblFineWt.Text = 0.00

        Try
            For Each row As GridViewRowInfo In dgvBhuka.Rows
                lblTotalWt.Text = Format(Val(lblTotalWt.Text) + Val(row.Cells(3).Value), "0.00")
                'lblFineWt.Text = Format(Val(lblTotalWt.Text * lblTotalPr.Text) / 100, "0.000")
                lblFineWt.Text = Format(Val(lblFineWt.Text) + Val(row.Cells(5).Value), "0.000")
            Next

            lblTotalPr.Text = Format((Val(lblFineWt.Text) / Val(lblTotalWt.Text)) * 100, "0.00")

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Sub ReceiveTotal()

        Dim dReceiveWTotal As Double = 0
        Dim dReceivePTotal As Double = 0
        Dim dReceiveFTotal As Double = 0

        Try

            For Each row As GridViewRowInfo In dgvReceiveBhuka.Rows
                dReceiveWTotal += Double.Parse(row.Cells(4).Value)
                dReceiveFTotal += Double.Parse(row.Cells(6).Value)
            Next

            dReceivePTotal = Format((Val(dReceiveFTotal) / Val(dReceiveWTotal)) * 100, "0.00")

            If dReceivePTotal > 0 Then
                txtRIssueWt.Text = Format(dReceiveWTotal, "0.00")
                txtRIssuePr.Text = Format(dReceivePTotal, "0.00")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtUreceivePr_Leave(sender As Object, e As EventArgs) Handles txtUreceivePr.Leave
        txtUreceivePr.Text = Format(Val(txtUreceivePr.Text), "0.00")
    End Sub
    Private Sub txtUreceivePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUreceivePr.KeyPress
        numdotkeypress(e, txtUreceivePr, Me)
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
    Private Sub txtRWtOnScale_Leave(sender As Object, e As EventArgs) Handles txtRWtOnScale.Leave
        txtRWtOnScale.Text = Format(Val(txtRWtOnScale.Text), "0.00")
    End Sub
    Private Sub txtRRecieveWt_Leave(sender As Object, e As EventArgs) Handles txtRRecieveWt.Leave
        txtRRecieveWt.Text = Format(Val(txtRRecieveWt.Text), "0.00")
    End Sub
    Private Sub txtRCarbon_Leave(sender As Object, e As EventArgs) Handles txtRCarbon.Leave
        txtRCarbon.Text = Format(Val(txtRCarbon.Text), "0.00")
    End Sub
    Private Sub txtRSample_Leave(sender As Object, e As EventArgs) Handles txtRSample.Leave
        txtRSample.Text = Format(Val(txtRSample.Text), "0.00")
    End Sub
    Private Sub clearUpdateAllData()
        txtUpdTransId.Tag = ""
        txtUpdTransId.Clear()

        cmbUBagNo.Text = ""
        txtUBagName.Text = ""
        txtUBagName.Clear()
        txtUreceivePr.Clear()
        txtUreceiveWt.Clear()
        txtUreceiveFineWt.Clear()

        txtUIssuePr.Clear()
        txtUIssueWt.Clear()
        txtUIssueFineWt.Clear()

        txtUWtOnScale.Clear()
        txtUcarbonReceive.Clear()

        txtUGrossLoss.Clear()
        txtUpdLossFine.Clear()
        Me.FillUcmbRBagNo()
    End Sub
    Private Sub btnRExit_Click(sender As Object, e As EventArgs) Handles btnRExit.Click
        Me.Close()
    End Sub
    Private Sub clearReceiveAllData()
        'cmbRBagtype.SelectedIndex = 0
        cmbRBagNo.Text = ""
        txtRBagName.Clear()
        txtRIssueWt.Clear()
        txtRIssuePr.Clear()

        txtRWtOnScale.Clear()
        txtRRecieveWt.Clear()

        txtRSample.Clear()
        txtRTotalWt.Clear()

        txtRCarbon.Clear()
        txtRGrossLoss.Clear()

        dgvReceiveBhuka.DataSource = Nothing
        Me.FillRcmbRBagNo()
    End Sub
    Private Sub btnRSave_Click(sender As Object, e As EventArgs) Handles btnRSave.Click
        If Not Validate_RFields() Then Exit Sub

        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If btnRSave.Text = "&Save" Then
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "SaveScrapBagData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RBhukaTransDt.Value.ToString(), DbType.DateTime))
                    ' .Add(dbManager.CreateParameter("@UItemId", Val(cmbRBagtype.SelectedValue), DbType.Int16))
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
            End If
            Me.btnRCancel_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub fetchUpdateBhukaBag()

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "SearchByBagNo", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", (cmbUBagNo.Text), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtUpdTransId.Text = dtData.Rows(0).Item("UsedBagId").ToString()
                UTransDt.Text = dtData.Rows(0).Item("UsedBagDt").ToString()
                txtUreceiveWt.Tag = dtData.Rows(0).Item("GrossReceive").ToString()
                txtUreceiveWt.Text = dtData.Rows(0).Item("RecieveWt").ToString()

                txtUreceivePr.Text = dtData.Rows(0).Item("ReportPr").ToString()
                txtUreceiveFineWt.Text = dtData.Rows(0).Item("RecieveFineWt").ToString()

                txtUIssueWt.Text = dtData.Rows(0).Item("IssueWt").ToString()
                txtUIssuePr.Text = dtData.Rows(0).Item("IssuePr").ToString()
                txtUIssueFineWt.Text = dtData.Rows(0).Item("IssueFineWt").ToString()

                txtUWtOnScale.Text = dtData.Rows(0).Item("WtOnScale").ToString()
                txtUcarbonReceive.Text = dtData.Rows(0).Item("CarbonRecieve").ToString()
                Try
                    Dim sresult As String = String.Empty
                    strSQL = Nothing
                    strSQL = "select tblfItemMaster.ItemName from tblfUsedBags inner join tblfItemMaster ON tblfItemMaster.ItemCode=tblfUsedBags.BagId where tblfUsedBags.BagSrNo='" + Convert.ToString(cmbUBagNo.Text) + "'"
                    sresult = Convert.ToString(dbManager.GetScalarValue(strSQL, CommandType.Text))
                    Dim VaccumeBagName = sresult
                    txtUBagName.Text = VaccumeBagName
                Catch ex As Exception

                End Try
            Else
                MessageBox.Show("No Data Found !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally

        End Try

    End Sub

    Private Function Validate_CFields() As Boolean
        Try
            If Not dgvBhuka.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If
            If Not cmbItemScrapBag.SelectedIndex > 0 Then
                MessageBox.Show("Please Select Bag!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
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
                MessageBox.Show("Enter Receive Wt...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
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

    Private Sub cmbRBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRBagNo.SelectedIndexChanged
        If cmbRBagNo.SelectedIndex <> -1 Then
            With dgvReceiveBhuka
                dgvReceiveBhuka.DataSource = Nothing
            End With
        End If
        If cmbRBagNo.SelectedIndex > 0 Then
            Me.bindVacuumBagWt()
            Me.DisableBtn()
        End If
    End Sub

    Private Sub cmbUBagNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUBagNo.SelectedIndexChanged
        If cmbUBagNo.SelectedIndex > 0 Then
            Me.fetchUpdateBhukaBag()
        End If
    End Sub

    Private Sub dgvBhuka_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvBhuka.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And dgvBhuka.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvBhuka.Rows(e.RowIndex).Cells(0).Value.ToString()
                cmbItem.Tag = dgvBhuka.Rows(e.RowIndex).Cells(1).Value.ToString()
                cmbItem.Text = dgvBhuka.Rows(e.RowIndex).Cells(2).Value.ToString()
                txtGrossWt.Text = dgvBhuka.Rows(e.RowIndex).Cells(3).Value.ToString()
                cmbMelting.Text = dgvBhuka.Rows(e.RowIndex).Cells(4).Value.ToString()
                txtFineWt.Text = dgvBhuka.Rows(e.RowIndex).Cells(5).Value.ToString()
                If btnSave.Text = "Update" Then
                    txtFineWt.Tag = dgvBhuka.Rows(e.RowIndex).Cells(6).Value.ToString()
                Else
                End If
                TempRow = e.RowIndex
            End If
            With dgvBhuka
                If GridDoubleClick = False Then
                    With dgvBhuka
                        .SelectedRows.Contains(.CurrentRow)
                    End With
                Else
                    .Rows.Remove(.CurrentRow)
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Me.Clear_Form()
        If btnEdit.Text = "Edit" Then
            If dgvReceiveBhuka.Rows.Count <= 0 And cmbRBagNo.SelectedIndex <= 0 Then
                MessageBox.Show("Please Select Bag No To Edit Records")
            Else
                lblMaxNo.Visible = True
                txtMaxNo.Visible = True
                ' cmbItemScrapBag.SelectedItem.Text = txtRBagName.Text.ToString()
                cmbItemScrapBag.SelectedIndex = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value
                btnSave.Text = "Update"
                txtMaxNo.Tag = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value
                txtMaxNo.Text = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(1).Value
                ' txtMaxNo.Text = Convert.ToString(cmbRBagNo.Text.Trim)
                Me.FillGridR(cmbRBagNo.Text.Trim)
                tbBhukaBag.SelectedIndex = 0
            End If
        Else
            'MessageBox.Show("Update Mode Activate")
            Me.UpdateReceiveData()
            Me.ClearRecvUpdateBag_Form()
            btnEdit.Text = "Edit"
            btnRSave.Enabled = True
            Me.btnUCancel_Click(sender, e)
        End If
    End Sub
    Private Sub ClearRecvUpdateBag_Form()
        cmbRBagNo.Text = ""
        txtRBagName.Text = ""
        txtRIssueWt.Text = ""
        txtRIssuePr.Text = ""
        dgvReceiveBhuka.DataSource = Nothing
        txtRWtOnScale.Text = ""
        txtRRecieveWt.Text = ""
        txtRSample.Text = ""
        txtRTotalWt.Text = ""
        txtRCarbon.Text = ""
        txtRGrossLoss.Text = ""
    End Sub
    Private Sub UpdateReceiveData()
        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            If btnEdit.Text = "Update" Then
                With parameters
                    .Add(dbManager.CreateParameter("@ActionType", "UpdateRScrapBagData", DbType.String))
                    .Add(dbManager.CreateParameter("@UBagDt", RBhukaTransDt.Value.ToString(), DbType.DateTime))
                    .Add(dbManager.CreateParameter("@UBagSrNo", Convert.ToString(cmbRBagNo.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UWtOnScale", Val(txtRWtOnScale.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@URecieveWt", Val(txtRRecieveWt.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UTFSample", Val(txtRSample.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCarbonRecieve", Val(txtRCarbon.Text), DbType.String))
                    .Add(dbManager.CreateParameter("@UCreatedBy", UserName.Trim(), DbType.String))
                End With
                dbManager.Update("SP_UsedBags_UPDATE", CommandType.StoredProcedure, parameters.ToArray())
                MessageBox.Show("Scrap Bag Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub FillGridR(ByVal sRBagNo As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetails(CStr(sRBagNo))

        For Each ROW As DataRow In dttable.Rows
            dgvBhuka.Rows.Add(1, Val(ROW("ItemId")), CStr(ROW("ItemName")), Format(Val(ROW("GrossWt")), "0.00"), Format(Val(ROW("GrossPr")), "0.00"), Format(Val(ROW("FineWt")), "0.000"), Val(ROW("ScrapDetailsId")))
        Next

        Me.GetSrNo(dgvBhuka)
    End Sub
    Private Sub FillGridU(ByVal sUBagNo As String)
        Dim dttable As New DataTable
        dttable = fetchAllDetailsRUpdate(CStr(sUBagNo))
        dgvReceiveBhuka.DataSource = Nothing
        dgvReceiveBhuka.DataSource = dttable
        Me.ReceiveTotal()
        Me.FetchUsedBagsDetails(sUBagNo)
        Me.GetSrNo(dgvReceiveBhuka)
    End Sub
    Private Sub FetchUsedBagsDetails(sUBagNo)
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchReceivedScrap", DbType.String))
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
    Private Function Validate_UFields() As Boolean
        Try
            If String.IsNullOrWhiteSpace(cmbUBagNo.Text.Trim()) Then
                MessageBox.Show("Select Lot No...!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbRBagNo.Focus()
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function

    Private Sub BatnDelete_Click(sender As Object, e As EventArgs) Handles BatnDelete.Click
        If lblMaxNo.Visible = False And txtMaxNo.Visible = False And btnSave.Text = "&Save" Then
            With dgvBhuka
                .Rows.Remove(.CurrentRow)
            End With
        Else
            If (MsgBox("Are You Sure To Delete This ScrapBag ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                Try
                    If dgvBhuka.RowCount > 0 Then
                        Dim parameters = New List(Of SqlParameter)()
                        parameters.Clear()
                        With parameters
                            .Add(dbManager.CreateParameter("@SBagSrNo", txtMaxNo.Text, DbType.String))
                        End With
                        dbManager.Delete("SP_ScrapBag_Delete", CommandType.StoredProcedure, parameters.ToArray())
                        MessageBox.Show("Scrap Bag Delete Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        lblMaxNo.Visible = False
                        txtMaxNo.Visible = False
                        Me.Clear_Form()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub BtnRecvEdit_Click(sender As Object, e As EventArgs) Handles BtnRecvEdit.Click
        Me.Clear_Form()
        If cmbUBagNo.SelectedIndex <= 0 Then
            MessageBox.Show("Please Select Bag No To Edit Records")
        Else
            'cmbItemScrapBag.SelectedIndex = Me.cmbRBagNo.EditorControl.CurrentRow.Cells(0).Value
            cmbRBagNo.Text = Me.cmbUBagNo.EditorControl.CurrentRow.Cells(1).Value
            ' cmbRBagNo.SelectedIndex = Me.cmbUBagNo.EditorControl.CurrentRow.Cells(0).Value
            btnEdit.Text = "Update"
            btnRSave.Enabled = False
            Me.FillGridU(cmbUBagNo.Text.Trim)
            tbBhukaBag.SelectedIndex = 1
        End If
    End Sub

    Private Sub cmbMelting_GotFocus(sender As Object, e As EventArgs) Handles cmbMelting.GotFocus
        cmbMelting.ShowDropDown()
    End Sub
    Private Sub dgvFinalUpdate_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvFinalUpdate.CellDoubleClick
        If dgvFinalUpdate.Rows.Count > 0 Then
            Dim UsedDetailsId As Integer = dgvFinalUpdate.Rows(e.RowIndex).Cells(0).Value.ToString()
            Me.Clear_Form()
            fillDetailsFromListView(UsedDetailsId)
            btnUSave.Text = "Update"
            BtnRecvEdit.Enabled = False
            tbBhukaBag.SelectedIndex = 2
        End If
    End Sub
    Private Sub fillDetailsFromListView(ByVal UsedDetailsId As Integer)
        Dim dttable As New DataTable
        dttable = fetchAllDetails(CInt(UsedDetailsId))
        If dttable.Rows.Count > 0 Then
            cmbUBagNo.Text = dttable.Rows(0).Item("BagSrNo").ToString()
            txtUBagName.Text = dttable.Rows(0).Item("BagName").ToString()
            txtUpdTransId.Text = dttable.Rows(0).Item("UsedBagId").ToString()
            UTransDt.Text = dttable.Rows(0).Item("UsedBagDt").ToString()

            txtUreceiveWt.Text = dttable.Rows(0).Item("RecieveWt").ToString()

            txtUreceivePr.Text = dttable.Rows(0).Item("ReportPr").ToString()
            txtUreceiveFineWt.Text = dttable.Rows(0).Item("RecieveFineWt").ToString()

            txtUIssueWt.Text = dttable.Rows(0).Item("IssueWt").ToString()
            txtUIssuePr.Text = dttable.Rows(0).Item("IssuePr").ToString()
            txtUIssueFineWt.Text = dttable.Rows(0).Item("IssueFineWt").ToString()

            txtUWtOnScale.Text = dttable.Rows(0).Item("WtOnScale").ToString()
            txtUcarbonReceive.Text = dttable.Rows(0).Item("CarbonRecieve").ToString()
        End If
        dgvFinalUpdate.ReadOnly = True
        tbBhukaBag.SelectedIndex = 2
    End Sub

    Private Function fetchAllDetails(ByVal UsedDetailsId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchUpdatedBagDataById", DbType.String))
                .Add(dbManager.CreateParameter("@BId", CInt(UsedDetailsId), DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_UsedBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function

    Private Sub cmbItemScrapBag_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbItemScrapBag.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtGrossWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrossWt.KeyPress
        If Not Char.IsNumber(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub frmBhukaBag_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
                cmbItem.SelectedIndex = 0
                cmbMelting.SelectedIndex = 0
                txtGrossWt.Clear()
                txtFineWt.Clear()
                cmbItem.Focus()
            End If
            With dgvBhuka
                If e.KeyCode = Keys.F12 Then
                    If btnSave.Text = "&Save" Then
                        .Rows.Remove(.CurrentRow)
                    Else
                        Dim ScrapDetailedId As Int16 = dgvBhuka.SelectedRows(0).Cells(6).Value
                        If (MsgBox("Are You Sure To Delete This Record ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                            Try
                                If dgvBhuka.RowCount > 0 Then
                                    Dim parameters = New List(Of SqlParameter)()
                                    parameters.Clear()
                                    With parameters
                                        .Add(dbManager.CreateParameter("@ScrapDetailsId", ScrapDetailedId, DbType.Int16))
                                    End With
                                    dbManager.Delete("SP_ScrapBag_DeleteByID", CommandType.StoredProcedure, parameters.ToArray())
                                    MessageBox.Show("Scrap Bag Record Delete Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    .Rows.Remove(.CurrentRow)
                                    'lblMaxNo.Visible = False
                                    'txtMaxNo.Visible = False
                                    'Me.Clear_Form()
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
    Private Function fetchAllDetails(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FillRScrapDetails", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Trim(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ScrapBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Function fetchAllDetailsRUpdate(ByVal sBagNo As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FillRScrapDetailsUpdate", DbType.String))
                .Add(dbManager.CreateParameter("@BagSrNo", Trim(sBagNo), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ScrapBags_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function

End Class