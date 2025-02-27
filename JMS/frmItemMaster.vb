﻿Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmItemMaster
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState
    Dim dbManager As New SqlHelper()
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
    Private Sub frmItemMaster_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Clear_Form()

        'If dtUserRights.Rows.Count > 0 Then
        '    Dim DTROW() As DataRow = dtUserRights.Select("FormName = 'Item Master'")
        '    USERADD = DTROW(0).Item(3)
        '    USEREDIT = DTROW(0).Item(4)
        '    USERVIEW = DTROW(0).Item(5)
        '    USERDELETE = DTROW(0).Item(6)

        '    If USEREDIT = False And USERDELETE = False Then
        '        MsgBox("Insufficient Rights")
        '        btnDelete.Enabled = False
        '    End If
        'End If

        txtItemName.Focus()
        txtItemName.Select()

        Me.fillCategory()
        Me.fillFamily()
        Me.fillItemType()
        Me.fillMaterial()

        dgvItemList.AutoGenerateColumns = False
        dgvItemList.DataSource = FetchAllDetails()
        dgvItemList.EnableFiltering = True
        dgvItemList.MasterTemplate.ShowHeaderCellButtons = True
        dgvItemList.MasterTemplate.ShowFilteringRow = False
        dgvItemList.CurrentRow = Nothing

    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtItemName.Text) Then

            Try
                Dim parameters = New List(Of SqlParameter)()
                parameters.Clear()

                With parameters
                    .Add(dbManager.CreateParameter("@IId", Convert.ToInt16(txtItemName.Tag), DbType.Int16))
                End With

                dbManager.Delete("SP_ItemMaster_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Clear_Form()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Fancy !!!")
        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Not Validate_Fields() Then Exit Sub

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                If Fr_Mode = FormState.AStateMode Then

                    If IsExists() = False Then
                        MessageBox.Show(String.Format("Item Name {0} already exists.", Me.txtItemName.Text.Trim))
                        Me.txtItemName.Focus()
                        Exit Sub
                    End If

                    If cmbType.SelectedIndex = -1 Then
                        cmbType.SelectedIndex = 1
                    End If

                    If cmbMaterial.SelectedIndex = -1 Then
                        cmbMaterial.SelectedIndex = 1
                    End If

                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@IName", txtItemName.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@ICode", txtItemCode.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@IWeight", txtItemWt.Text, DbType.String))

                    .Add(dbManager.CreateParameter("@ICategoryId ", cmbCategory.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@IFamilyId", cmbFamily.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@ITypeIid", cmbType.SelectedIndex, DbType.Int16))
                    .Add(dbManager.CreateParameter("@IMaterialId", cmbMaterial.SelectedIndex, DbType.Int16))

                    .Add(dbManager.CreateParameter("@ItemForCH", chkChain.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@ItemForFA", chkFancy.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@ItemForCA", chkCasting.Checked, DbType.Boolean))

                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                Else
                    .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                    .Add(dbManager.CreateParameter("@IId", txtItemName.Tag, DbType.Int16))
                    .Add(dbManager.CreateParameter("@IName", txtItemName.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@ICode", txtItemCode.Text, DbType.String))
                    .Add(dbManager.CreateParameter("@IWeight", txtItemWt.Text, DbType.String))

                    .Add(dbManager.CreateParameter("@ICategoryId ", cmbCategory.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@IFamilyId", cmbFamily.SelectedValue, DbType.Int16))
                    .Add(dbManager.CreateParameter("@ITypeIid", cmbType.SelectedIndex, DbType.Int16))
                    .Add(dbManager.CreateParameter("@IMaterialId", cmbMaterial.SelectedIndex, DbType.Int16))

                    .Add(dbManager.CreateParameter("@ItemForCH", chkChain.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@ItemForFA", chkFancy.Checked, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@ItemForCA", chkCasting.Checked, DbType.Boolean))

                    .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                End If
            End With

            dbManager.Insert("SP_ItemMaster_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.btnCancel_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Function FetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub fillCategory()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_CategoryMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbCategory.DataSource = dt
            cmbCategory.DisplayMember = "CategoryName"
            cmbCategory.ValueMember = "CategoryId"

            'Newly Added
            cmbCategory.Refresh()
            If cmbCategory.Items.Count > 0 Then cmbCategory.SelectedIndex = 0

            'Set AutoCompleteMode.
            cmbCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbCategory.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillFamily()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_FamilyMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbFamily.DataSource = dt
            cmbFamily.DisplayMember = "FamilyName"
            cmbFamily.ValueMember = "FamilyId"

            'Newly Added
            cmbFamily.Refresh()
            If cmbFamily.Items.Count > 0 Then cmbFamily.SelectedIndex = 0

            'Set AutoCompleteMode.
            cmbFamily.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbFamily.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillItemType()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_ItemType_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbType.DataSource = dt
            cmbType.DisplayMember = "ItemType"
            cmbType.ValueMember = "ItemTypeId"

            'Newly Added
            cmbType.Refresh()
            If cmbType.Items.Count > 0 Then cmbType.SelectedIndex = 0

            'Set AutoCompleteMode.
            cmbType.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbType.AutoCompleteDataSource = AutoCompleteSource.ListItems
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
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FillMaterialCmb", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_MaterialMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbMaterial.DataSource = dt
            cmbMaterial.DisplayMember = "MaterialName"
            cmbMaterial.ValueMember = "MaterialId"

            'Newly Added
            cmbMaterial.Refresh()
            If cmbMaterial.Items.Count > 0 Then cmbMaterial.SelectedIndex = 0

            'Set AutoCompleteMode.
            cmbMaterial.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbMaterial.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub txtItemName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItemName.KeyPress
        e.Handled = e.KeyChar <> ChrW(Keys.Back) And Not Char.IsSeparator(e.KeyChar) And Not Char.IsLetter(e.KeyChar) And Not Char.IsDigit(e.KeyChar)
    End Sub
    Private Sub txtItemWeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItemWt.KeyPress
        numdotkeypress(e, txtItemWt, Me)
    End Sub
    Private Sub frmItemMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
                btnSave().PerformClick()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvItemList_CellDoubleClick(sender As Object, e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles dgvItemList.CellDoubleClick
        If e.RowIndex >= 0 Then
            Fr_Mode = FormState.EStateMode
            txtItemName.Tag = dgvItemList.Rows(e.RowIndex).Cells(0).Value.ToString()
            txtItemName.Text = dgvItemList.Rows(e.RowIndex).Cells(1).Value.ToString()
            txtItemCode.Text = dgvItemList.Rows(e.RowIndex).Cells(2).Value.ToString()

            txtItemWt.Text = dgvItemList.Rows(e.RowIndex).Cells(3).Value.ToString()

            cmbCategory.SelectedIndex = dgvItemList.Rows(e.RowIndex).Cells(4).Value.ToString()
            cmbCategory.Text = dgvItemList.Rows(e.RowIndex).Cells(5).Value.ToString()

            cmbFamily.SelectedIndex = dgvItemList.Rows(e.RowIndex).Cells(6).Value.ToString()
            cmbFamily.Text = dgvItemList.Rows(e.RowIndex).Cells(7).Value.ToString()

            cmbType.SelectedIndex = dgvItemList.Rows(e.RowIndex).Cells(8).Value.ToString()
            cmbType.Text = dgvItemList.Rows(e.RowIndex).Cells(9).Value.ToString()

            cmbMaterial.SelectedIndex = dgvItemList.Rows(e.RowIndex).Cells(10).Value.ToString()
            cmbMaterial.Text = dgvItemList.Rows(e.RowIndex).Cells(11).Value.ToString()
        Else
            Me.Clear_Form()
        End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub txtItemName_Leave(sender As Object, e As EventArgs) Handles txtItemName.Leave
        txtItemName.Text = ToProper(txtItemName.Text)
    End Sub
    Private Sub cmbType_Enter(sender As Object, e As EventArgs) Handles cmbType.Enter
        cmbType.ShowDropDown()
    End Sub
    Private Sub Clear_Form()
        Try
            btnSave.Text = "&Save"
            txtItemName.Clear()
            txtItemCode.Clear()
            txtItemWt.Clear()

            cmbCategory.SelectedIndex = 0
            cmbFamily.SelectedIndex = 0
            cmbType.SelectedIndex = 0
            cmbMaterial.SelectedIndex = 0

            chkChain.Checked = False
            chkFancy.Checked = False
            chkCasting.Checked = False

            dgvItemList.DataSource = FetchAllDetails()

            Fr_Mode = FormState.AStateMode

            btnSave.Enabled = True
            btnDelete.Enabled = False

            txtItemName.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub txtItemCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtItemCode.KeyPress
        If Not Char.IsLetter(e.KeyChar) And Not e.KeyChar = Chr(Keys.Delete) And Not e.KeyChar = Chr(Keys.Back) And Not Char.IsNumber(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If Fr_Mode <> FormState.AStateMode Then
                If txtItemName.Tag.Trim = "" Then
                    MessageBox.Show("Select Item ID !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtItemName.Focus()
                    Return False
                End If
            End If

            'Assigning Default values
            If txtItemName.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Item Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtItemName.Focus()
                Return False
            End If

            If txtItemCode.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Item Code !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtItemCode.Focus()
                Return False
            End If

            If txtItemWt.Text.Trim.Length = 0 Then
                MessageBox.Show("Enter Item Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                txtItemWt.Focus()
                Return False
            End If

            If Val(cmbCategory.SelectedIndex) = -1 Or Val(cmbCategory.SelectedIndex) = 0 Then
                MessageBox.Show("Select Item Category !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbCategory.Focus()
                Return False
            End If

            If Val(cmbFamily.SelectedIndex) = -1 Or Val(cmbFamily.SelectedIndex) = 0 Then
                MessageBox.Show("Select Family !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbFamily.Focus()
                Return False
            End If

            'If Val(cmbType.SelectedIndex) = -1 Or Val(cmbType.SelectedIndex) = 0 Then
            '    MessageBox.Show("Select Item Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            '    cmbType.Focus()
            '    Return False
            'End If

            'If Val(cmbMaterial.SelectedIndex) = -1 Or Val(cmbMaterial.SelectedIndex) = 0 Then
            '    MessageBox.Show("Select Material Type !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            '    cmbMaterial.Focus()
            '    Return False
            'End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Function IsExists() As Boolean
        Try

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@IName", CStr(txtItemName.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
            End With

            Dim strName As Object = dbManager.GetScalarValue("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

            If Not IsNothing(strName) Then
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Function
    Private Sub txtItemWt_Leave(sender As Object, e As EventArgs) Handles txtItemWt.Leave
        txtItemWt.Text = Format(Val(txtItemWt.Text), "0.00")
    End Sub
    Private Sub txtItemCode_Leave(sender As Object, e As EventArgs) Handles txtItemCode.Leave
        txtItemCode.Text = txtItemCode.Text.ToUpper()
    End Sub
    Function adjInput(ByVal Min As Decimal, ByVal Max As Decimal, ByVal Input As String) As String
        Dim Value As Decimal
        If Not Decimal.TryParse(Input, Value) Then Return "0"
        If Value > Max Then Value = Max : ShowMessage1()
        If Value < Min Then Value = Min : ShowMessage1()
        Return Math.Round(Value, 4).ToString
    End Function
    Sub ShowMessage1()
        MessageBox.Show("Your value was not within range!(0-1000)", "Input value adjusted!", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub
    Private Sub txtItemWeight_LostFocus(sender As Object, e As EventArgs) Handles txtItemWt.LostFocus
        Dim Adjusted As String = adjInput(0, 1000, txtItemWt.Text)
        txtItemWt.Text = Adjusted
        txtItemWt.SelectionStart = txtItemWt.Text.Length - 1
        txtItemWt.SelectionLength = 0
    End Sub
End Class