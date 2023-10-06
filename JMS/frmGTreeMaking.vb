Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmGTreeMaking
    Dim dbManager As New SqlHelper()
    Dim strSQL As String = Nothing
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Objerr As New ErrorProvider()
    Dim GridDoubleClick As Boolean
    Dim TempRow As Integer
    Private Sub frmGTreeMaking_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FillEmployee()
        Me.fillMaterial()
        Me.BindList()
        txtSrNo.Text = 1
        txtSrNo.ReadOnly = True
        lblTreeNo.Visible = False
        txtTreeNo.Visible = False
        btnDelete.Enabled = False
    End Sub
    Private Sub FillEmployee()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillCombo", DbType.String))
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
            cmbEmployee.DataSource = dt
            cmbEmployee.DisplayMember = "LabourName"
            cmbEmployee.ValueMember = "LabourId"
            cmbEmployee.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbEmployee.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub fillMaterial()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillCastingMaterial", DbType.String))
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
            cmbMaterial.DataSource = Odt
            cmbMaterial.DisplayMember = "MaterialName"
            cmbMaterial.ValueMember = "MaterialId"
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = Cdt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            Cdt.Rows.InsertAt(trow, 0)
            cmbMaterial.DataSource = Cdt
            cmbMaterial.DisplayMember = "MaterialName"
            cmbMaterial.ValueMember = "MaterialId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub BindList()
        Dim dtable As DataTable = fetchAllDetails()
        'RadGridView1.Rows.Clear()
        For i As Integer = 0 To dtable.Rows.Count - 1
            DGVTreeMakList.DataSource = dtable
        Next
    End Sub
    Private Function fetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchTreeMakingList", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_TreeMaking_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Function Validate_Fields() As Boolean
        Try
            'If FormState.AStateMode Then
            If cmbEmployee.SelectedIndex = 0 Then
                MessageBox.Show("Select Employee !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbEmployee.Focus()
                Return False
            End If
            If cmbMaterial.SelectedIndex = 0 Then
                MessageBox.Show("Select Material !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbMaterial.Focus()
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim TmpLotNo As String = Nothing
        Try
            If btnSave.Text = "&Save" Then
                If Not Validate_Fields() Then Exit Sub
                Dim Dt As DataTable = Me.SaveData()
                TmpLotNo = Dt.Rows(0).Item(0)
                MessageBoxTimer(TmpLotNo)
                Me.btnCancel_Click(sender, e)
            Else
                If (MsgBox("Are You Sure To Update This Tree Making Details ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                    Try
                        Dim dttable As New DataTable
                        dttable = fetchLabourId(CStr(cmbEmployee.Text.Trim))
                        If dttable.Rows.Count > 0 Then
                            cmbEmployee.Tag = dttable.Rows(0).Item("LabourId").ToString()
                            cmbEmployee.Text = dttable.Rows(0).Item("LabourName").ToString()
                        End If
                        Dim dttableI As New DataTable
                        dttableI = fetchMaterialId(CStr(cmbMaterial.Text.Trim))
                        If dttable.Rows.Count > 0 Then
                            cmbMaterial.Tag = dttableI.Rows(0).Item("MaterialId").ToString()
                            cmbMaterial.Text = dttableI.Rows(0).Item("MaterialName").ToString()
                        End If
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
    Private Sub UpdateData()
        Dim Dt As DataTable = Nothing
        Dim alParaval As New ArrayList
        Dim GridSrNo As String = Nothing
        Dim DieNo As String = Nothing
        Dim Pcs As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0
        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        For Each row As GridViewRowInfo In dgvTreeMaking.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    DieNo = Convert.ToString(row.Cells(1).Value)
                    Pcs = Convert.ToString(row.Cells(2).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    DieNo = DieNo & "|" & Convert.ToString(row.Cells(1).Value)
                    Pcs = Pcs & "|" & Convert.ToString(row.Cells(2).Value)
                End If
            End If
            IRowCount += 1
        Next
        alParaval.Add(DieNo)
        alParaval.Add(Pcs)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@HTreeMakingDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLabourId", cmbEmployee.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@HMaterialId", cmbMaterial.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@HTreeWeight", txtTreeWeight.Text.Trim(), DbType.Int16))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIsOpening", 1, DbType.Boolean))
                .Add(dbManager.CreateParameter("@TId", txtSrNo.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@DieNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@Pcs", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With
            Dt = dbManager.GetDataTable("SP_TreeMaking_Update", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Updated !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Function fetchLabourId(ByVal LName As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchLabourIdByName", DbType.String))
                .Add(dbManager.CreateParameter("@LName", cmbEmployee.Text, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Function fetchMaterialId(ByVal MName As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
                .Add(dbManager.CreateParameter("@MName", cmbMaterial.Text, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_MaterialMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Function SaveData() As DataTable
        Dim Dt As DataTable = Nothing
        Dim alParaval As New ArrayList
        Dim GridSrNo As String = Nothing
        Dim DieNo As String = Nothing
        Dim Pcs As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0
        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        For Each row As GridViewRowInfo In dgvTreeMaking.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    DieNo = Convert.ToString(row.Cells(1).Value)
                    Pcs = Convert.ToString(row.Cells(2).Value)
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    DieNo = DieNo & "|" & Convert.ToString(row.Cells(1).Value)
                    Pcs = Pcs & "|" & Convert.ToString(row.Cells(2).Value)
                End If
            End If
            IRowCount += 1
        Next
        alParaval.Add(DieNo)
        alParaval.Add(Pcs)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@HTreeMakingDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLabourId", cmbEmployee.SelectedValue, DbType.Int16))
                .Add(dbManager.CreateParameter("@HMaterialId", cmbMaterial.SelectedValue, DbType.Int16))
                .Add(dbManager.CreateParameter("@HTreeWeight", txtTreeWeight.Text.Trim(), DbType.Int16))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIsOpening", 1, DbType.Boolean))
                .Add(dbManager.CreateParameter("@DieNo", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@Pcs", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With
            Dt = dbManager.GetDataTable("SP_TreeMaking_Save", CommandType.StoredProcedure, Hparameters.ToArray())
            ' MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
        Return Dt
    End Function
    Sub MessageBoxTimer(ByVal strMsg As String)
        Dim AckTime As Integer, InfoBox As Object
        InfoBox = CreateObject("WScript.Shell")
        'Set the message box to close after 1 seconds
        AckTime = 1
        'Select Case InfoBox.Popup("Click OK (Chain Saved Successfully With New Lot Number = " & strMsg.ToString(),
        'AckTime, "Newly Created Lot Number", 0)
        Select Case InfoBox.Popup("Tree No. " & strMsg.ToString() & " Saved Successfully",
        AckTime, " ", 0)
            Case 1, -1
                Exit Sub
        End Select
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        lblTreeNo.Visible = False
        txtTreeNo.Visible = False
        cmbEmployee.Text = ""
        cmbEmployee.SelectedIndex = 0
        cmbMaterial.Text = ""
        cmbMaterial.SelectedIndex = 0
        txtTreeNo.Text = ""
        txtTreeWeight.Text = ""
        txtSrNo.Text = "1"
        txtDieNo.Text = ""
        txtPcs.Text = ""
        btnSave.Text = "&Save"
        btnDelete.Enabled = False
        lblTotalPcs.Text = "0.00"
        dgvTreeMaking.DataSource = Nothing
        dgvTreeMaking.RowCount = 0
        Me.BindList()
    End Sub
    Private Sub txtPcs_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtPcs.Validating
        Try
            If btnSave.Text = "&Save" Then
                If cmbEmployee.SelectedIndex > 0 And Val(txtTreeWeight.Text.Trim) > 0 Then
                    If Not txtDieNo.Text.Trim = "" Then
                        If Not txtPcs.Text.Trim = "" Then
                            Me.fillGrid()
                            Me.Total()
                        Else
                            MsgBox("Enter Proper Details")
                        End If
                    Else
                        MsgBox("Enter Proper Details")
                    End If
                Else
                    MsgBox("Enter Proper Details")
                End If
            Else
                Me.fillGrid()
                Me.Total()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillGrid()
        If GridDoubleClick = False Then
            dgvTreeMaking.Rows.Add(Val(txtSrNo.Text.Trim),
                                    (txtDieNo.Text.Trim),
                                    (txtPcs.Text.Trim))

            GetSrNo(dgvTreeMaking)
        Else
            dgvTreeMaking.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvTreeMaking.Rows(TempRow).Cells(1).Value = txtDieNo.Text
            dgvTreeMaking.Rows(TempRow).Cells(2).Value = txtPcs.Text.Trim
            GetSrNo(dgvTreeMaking)
            GridDoubleClick = False
        End If
        ' Me.Total()
        dgvTreeMaking.TableElement.ScrollToRow(dgvTreeMaking.Rows.Last)
        txtSrNo.Clear()
        txtSrNo.Text = dgvTreeMaking.RowCount + 1
        txtDieNo.Clear()
        txtPcs.Clear()
        txtDieNo.Focus()
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvTreeMaking.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub Total()
        Try
            lblTotalPcs.Text = 0.00
            For Each row As GridViewRowInfo In dgvTreeMaking.Rows
                lblTotalPcs.Text = Format(Val(lblTotalPcs.Text) + Val(row.Cells(2).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtDieNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDieNo.KeyPress
        e.KeyChar = Char.ToUpper(e.KeyChar)
    End Sub
    Private Sub txtTreeWeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTreeWeight.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtPcs_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPcs.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub frmGTreeMaking_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
                txtDieNo.Clear()
                txtPcs.Clear()
                txtDieNo.Focus()
            End If
            With dgvTreeMaking
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
                'Me.Total()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
    Private Sub fillHeaderFromListView(ByVal TreeMakingId As Integer)
        Dim parameters = New List(Of SqlParameter)()


        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@TId", CInt(TreeMakingId), DbType.Int16))
            .Add(dbManager.CreateParameter("@ActionType", "FetchTreeMakingHeader", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_TreeMaking_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())
        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            TransDt.Tag = dr.Item("TMakingDt").ToString()
            txtSrNo.Tag = dr.Item("TreeMakingId").ToString()
            txtTreeNo.Text = dr.Item("TreeNo").ToString()
            cmbEmployee.Text = dr.Item("LabourName").ToString()
            cmbMaterial.Text = dr.Item("MaterialName").ToString()
            txtTreeWeight.Text = dr.Item("TreeWt").ToString()
        End If
        dr.Close()
        Objcn.Close()
        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub FillDetailsFromListView(ByVal TreeMakingId As Integer)
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@TId", CInt(TreeMakingId), DbType.Int16))
            .Add(dbManager.CreateParameter("@ActionType", "FetchTreeMakingDetails", DbType.String))
        End With

        dtData = dbManager.GetDataTable("SP_TreeMaking_Select", CommandType.StoredProcedure, parameters.ToArray())

        If dtData.Rows.Count < 0 Then
            Exit Sub
        Else
            dgvTreeMaking.DataSource = dtData
        End If

        Exit Sub

    End Sub
    Private Sub DGVTreeMakList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles DGVTreeMakList.CellDoubleClick
        If DGVTreeMakList.Rows.Count > 0 Then
            Try
                'Dim ReceiptId As Integer = GridView1.SelectedItems(0).SubItems(0).Text
                Dim TreeMakingId As Integer = DGVTreeMakList.Rows(e.RowIndex).Cells(0).Value.ToString()
                Me.btnCancel_Click(sender, e)
                btnSave.Text = "&Update"
                Me.TabControl1.SelectedIndex = 0
                btnDelete.Enabled = True
                lblTreeNo.Visible = True
                txtTreeNo.Visible = True
                fillHeaderFromListView(TreeMakingId)
                FillDetailsFromListView(TreeMakingId)
                Me.Total()
                GetSrNo(dgvTreeMaking)
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
    Private Sub dgvTreeMaking_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvTreeMaking.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And dgvTreeMaking.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvTreeMaking.Rows(e.RowIndex).Cells(0).Value.ToString()
                txtDieNo.Text = dgvTreeMaking.Rows(e.RowIndex).Cells(1).Value.ToString()
                txtPcs.Text = dgvTreeMaking.Rows(e.RowIndex).Cells(2).Value.ToString()
                TempRow = e.RowIndex
                txtDieNo.Focus()
            End If
            With dgvTreeMaking
                GridDoubleClick = True
            End With
            'With dgvIssue
            '    .Rows.Remove(.CurrentRow)
            'End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lblTreeNo.Visible = False And txtTreeNo.Visible = False And btnSave.Text = "&Save" Then
            With dgvTreeMaking
                .Rows.Remove(.CurrentRow)
            End With
        Else
            If (MsgBox("Are You Sure To Delete This Tree Making Details ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                Try
                    If dgvTreeMaking.RowCount > 0 Then
                        Dim parameters = New List(Of SqlParameter)()
                        parameters.Clear()
                        With parameters
                            .Add(dbManager.CreateParameter("@TID", txtSrNo.Tag, DbType.String))
                        End With
                        dbManager.Delete("SP_TreeMaking_Delete", CommandType.StoredProcedure, parameters.ToArray())
                        MessageBox.Show("Tree Making Details Delete Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        lblTreeNo.Visible = False
                        txtTreeNo.Visible = False
                        btnCancel_Click(sender, e)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        End If
    End Sub
End Class