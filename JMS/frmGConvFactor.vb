Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmGConvFactor
    Dim dbManager As New SqlHelper()
    Dim strSQL As String = Nothing
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Objerr As New ErrorProvider()
    Dim GridDoubleClick As Boolean
    Dim TempRow As Integer
    Private Sub frmGConvFactor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtCreatedBy.Tag = CInt(UserId)
        txtCreatedBy.Text = Convert.ToString(KarigarName.Trim)
        txtSrNo.Text = "1"
        BtnDelete.Enabled = False
        FillMeltingCmb()
        FillMaterialCmb()
        Me.BindList()
    End Sub
    Private Sub BindList()
        Dim dtable As DataTable = fetchAllDetails()
        'RadGridView1.Rows.Clear()
        For i As Integer = 0 To dtable.Rows.Count - 1
            dgvConvFactorList.DataSource = dtable
        Next
    End Sub
    Private Function fetchAllDetails() As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchFactorList", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ConvPerFactor_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub FillMeltingCmb()
        Dim connection As SqlConnection = Nothing
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchData", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
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
            cmbMelting.DataSource = Odt
            cmbMelting.DisplayMember = "MeltingValue"
            cmbMelting.ValueMember = "MeltingId"
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = Cdt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            Cdt.Rows.InsertAt(trow, 0)
            cmbMelting.DataSource = Cdt
            cmbMelting.DisplayMember = "MeltingValue"
            cmbMelting.ValueMember = "MeltingId"
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub FillMaterialCmb()
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
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        txtSrNo.Text = "1"
        cmbMelting.Text = ""
        cmbMelting.SelectedIndex = 0
        cmbMaterial.Text = ""
        cmbMaterial.SelectedIndex = 0
        txtConvPerFactor.Text = ""
        dgvConvFactor.DataSource = Nothing
        dgvConvFactor.RowCount = 0
        BtnDelete.Enabled = False
        Me.BindList()
    End Sub
    Private Sub txtConvPerFactor_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtConvPerFactor.Validating
        Try
            If BtnSave.Text = "&Save" Then
                If cmbMelting.SelectedValue > -1 And cmbMaterial.SelectedValue > -1 And Val(txtConvPerFactor.Text.Trim) > 0 Then
                    Me.fillGrid()
                Else
                    MsgBox("Enter Proper Details")
                End If
            Else
                Me.FetchMeltingId()
                Me.FetchMaterialId()
                Me.fillGrid()
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FetchMeltingId()
        Dim dttable As New DataTable
        dttable = FetchMeltingId(CStr(cmbMelting.Text.Trim))
        If dttable.Rows.Count > 0 Then
            cmbMelting.Tag = dttable.Rows(0).Item("MeltingId").ToString()
            cmbMelting.Text = dttable.Rows(0).Item("MeltingValue").ToString()
        End If
    End Sub
    Private Function fetchMeltingId(ByVal MName As String) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SearchDuplicate", DbType.String))
                .Add(dbManager.CreateParameter("@MValue", cmbMelting.Text, DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_MeltingMaster_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function
    Private Sub FetchMaterialId()
        Dim dttable As New DataTable
        dttable = fetchMaterialId(CStr(cmbMaterial.Text.Trim))
        If dttable.Rows.Count > 0 Then
            cmbMaterial.Tag = dttable.Rows(0).Item("MaterialId").ToString()
            cmbMaterial.Text = dttable.Rows(0).Item("MaterialName").ToString()
        End If
    End Sub
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
    Sub fillGrid()
        If GridDoubleClick = False Then
            dgvConvFactor.Rows.Add(Val(txtSrNo.Text.Trim),
                                    (cmbMelting.SelectedValue),
                                   (cmbMelting.Text.Trim),
                                    (cmbMaterial.SelectedValue),
                                    (cmbMaterial.Text.Trim),
                                   (txtConvPerFactor.Text.Trim))
            GetSrNo(dgvConvFactor)
        Else
            dgvConvFactor.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvConvFactor.Rows(TempRow).Cells(1).Value = cmbMelting.Tag
            dgvConvFactor.Rows(TempRow).Cells(2).Value = cmbMelting.Text.ToString
            dgvConvFactor.Rows(TempRow).Cells(3).Value = cmbMaterial.Tag
            dgvConvFactor.Rows(TempRow).Cells(4).Value = cmbMaterial.Text.ToString
            dgvConvFactor.Rows(TempRow).Cells(5).Value = txtConvPerFactor.Text.Trim
            GetSrNo(dgvConvFactor)
            GridDoubleClick = False
        End If
        ' Me.Total()
        dgvConvFactor.TableElement.ScrollToRow(dgvConvFactor.Rows.Last)
        txtSrNo.Clear()
        txtSrNo.Text = dgvConvFactor.RowCount + 1
        cmbMelting.Text = ""
        cmbMelting.SelectedIndex = 0
        cmbMaterial.Text = ""
        cmbMaterial.SelectedIndex = 0
        txtConvPerFactor.Clear()
        cmbMelting.Focus()
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvConvFactor.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub dgvConvFactor_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvConvFactor.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub
            If e.RowIndex >= 0 And dgvConvFactor.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvConvFactor.Rows(e.RowIndex).Cells(0).Value.ToString()
                cmbMelting.Tag = dgvConvFactor.Rows(e.RowIndex).Cells(1).Value.ToString()
                cmbMelting.Text = dgvConvFactor.Rows(e.RowIndex).Cells(2).Value.ToString()
                cmbMaterial.Tag = dgvConvFactor.Rows(e.RowIndex).Cells(3).Value.ToString()
                cmbMaterial.Text = dgvConvFactor.Rows(e.RowIndex).Cells(4).Value.ToString()
                txtConvPerFactor.Text = dgvConvFactor.Rows(e.RowIndex).Cells(5).Value.ToString()
                TempRow = e.RowIndex
                cmbMelting.Focus()
            End If
            With dgvConvFactor
                GridDoubleClick = True
            End With
            'With dgvIssue
            '    .Rows.Remove(.CurrentRow)
            'End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub frmGConvFactor_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
                cmbMelting.Text = ""
                cmbMelting.SelectedIndex = 0
                cmbMaterial.Text = ""
                cmbMaterial.SelectedIndex = 0
                txtConvPerFactor.Clear()
                cmbMelting.Focus()
            End If
            With dgvConvFactor
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
                'Me.Total()
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Try
            If BtnSave.Text = "&Save" Then
                If dgvConvFactor.RowCount > 0 Then
                    'If Not Validate_Fields() Then Exit Sub
                    Me.SaveData()
                Else
                    MessageBox.Show("Please Insert The Data..!")
                End If
                Me.BtnCancel_Click(sender, e)
            Else
                If (MsgBox("Are You Sure To Update This Tree Making Details ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                    Try
                        Me.UpdateData()
                        Me.BtnCancel_Click(sender, e)
                        BtnSave.Text = "&Save"
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
        Dim MeltingId As String = Nothing
        Dim MaterialId As String = Nothing
        Dim ConvPerFactor As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0
        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        For Each row As GridViewRowInfo In dgvConvFactor.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    MeltingId = Val(row.Cells(1).Value)
                    MaterialId = Val(row.Cells(3).Value)
                    ConvPerFactor = Convert.ToString(row.Cells(5).Value)

                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    MeltingId = MeltingId & "|" & Convert.ToString(row.Cells(1).Value)
                    MaterialId = MaterialId & "|" & Convert.ToString(row.Cells(3).Value)
                    ConvPerFactor = ConvPerFactor & "|" & Convert.ToString(row.Cells(5).Value)
                End If
            End If
            IRowCount += 1
        Next
        alParaval.Add(MeltingId)
        alParaval.Add(MaterialId)
        alParaval.Add(ConvPerFactor)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@HCreatedDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@DFId", txtCreatedBy.Tag, DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@DMeltingId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DMaterialId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DConvPerFactor", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With
            dbManager.Insert("SP_ConvPerFactor_Update", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Update !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub SaveData()
        Dim Dt As DataTable = Nothing
        Dim alParaval As New ArrayList
        Dim GridSrNo As String = Nothing
        Dim MeltingId As String = Nothing
        Dim MaterialId As String = Nothing
        Dim ConvPerFactor As String = Nothing
        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0
        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        For Each row As GridViewRowInfo In dgvConvFactor.Rows
            If row.Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = Val(row.Cells(0).Value)
                    MeltingId = Val(row.Cells(1).Value)
                    MaterialId = Val(row.Cells(3).Value)
                    ConvPerFactor = Convert.ToString(row.Cells(5).Value)

                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    MeltingId = MeltingId & "|" & Convert.ToString(row.Cells(1).Value)
                    MaterialId = MaterialId & "|" & Convert.ToString(row.Cells(3).Value)
                    ConvPerFactor = ConvPerFactor & "|" & Convert.ToString(row.Cells(5).Value)
                End If
            End If
            IRowCount += 1
        Next
        alParaval.Add(MeltingId)
        alParaval.Add(MaterialId)
        alParaval.Add(ConvPerFactor)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()
            With Hparameters
                .Add(dbManager.CreateParameter("@HCreatedDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@DMeltingId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DMaterialId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DConvPerFactor", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With
            dbManager.Insert("SP_ConvPerFactor_Save", CommandType.StoredProcedure, Hparameters.ToArray())
            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub

    Private Sub dgvConvFactorList_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvConvFactorList.CellDoubleClick
        If dgvConvFactorList.Rows.Count > 0 Then
            Try
                'Dim ReceiptId As Integer = GridView1.SelectedItems(0).SubItems(0).Text
                Dim ConvFactorId As Integer = dgvConvFactorList.Rows(e.RowIndex).Cells(0).Value.ToString()
                Me.BtnCancel_Click(sender, e)
                BtnSave.Text = "&Update"
                Me.TabControl1.SelectedIndex = 0
                BtnDelete.Enabled = True
                fillDetailsFromListView(ConvFactorId)
                txtCreatedBy.Tag = ConvFactorId
                GetSrNo(dgvConvFactor)
            Catch ex As Exception
                Throw ex
            End Try
        End If
    End Sub
    Private Sub fillDetailsFromListView(ByVal ConvFactorId As Integer)
        Dim dttable As New DataTable
        dttable = fetchAllFancys(CInt(ConvFactorId))
        For Each ROW As DataRow In dttable.Rows
            dgvConvFactor.DataSource = Nothing
            ' dgvReceipt.Rows.Add(Val(ROW("ReceiptDetailsId")), Val(ROW("ReceiptId")), CStr(ROW("IssueId")), Val(ROW("ItemId")), CStr(ROW("ItemName")), Format(Val(ROW("ReceiveWt")), "0.00"), Format(Val(ROW("ReceivePr")), "0.00"), Format(Val(ROW("ConvPr")), "0.00"), Format(Val(ROW("FineWt")), "0.00"), Convert.ToBoolean(ROW("ForMelting")), Format(Val(ROW("StockAdd")), "0.00"))
            dgvConvFactor.DataSource = dttable
        Next
        Me.GetSrNo(dgvConvFactor)
        'Me.Total()
        dgvConvFactor.ReadOnly = True
    End Sub
    Private Function fetchAllFancys(ByVal ConvFactorId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()
        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()
            With parameters
                .Add(dbManager.CreateParameter("@FId", CInt(ConvFactorId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchConvFactorDetailsByID", DbType.String))
            End With
            dtData = dbManager.GetDataTable("SP_ConvPerFactor_Select", CommandType.StoredProcedure, parameters.ToArray())
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
        Return dtData
    End Function

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        If BtnSave.Text = "&Save" Then
            With dgvConvFactor
                .Rows.Remove(.CurrentRow)
            End With
        Else
            If (MsgBox("Are You Sure To Delete This Tree Making Details ?", vbYesNo + vbDefaultButton2 + vbQuestion, "User : " + UserName.Trim()) = vbYes) Then
                Try
                    If dgvConvFactor.RowCount > 0 Then
                        Dim parameters = New List(Of SqlParameter)()
                        parameters.Clear()
                        With parameters
                            .Add(dbManager.CreateParameter("@DFId", txtCreatedBy.Tag, DbType.String))
                        End With
                        dbManager.Delete("SP_ConvPerFactor_Delete", CommandType.StoredProcedure, parameters.ToArray())
                        MessageBox.Show("Delete Succesfully..!!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        BtnCancel_Click(sender, e)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error:- " & ex.Message)
                End Try
            End If
        End If
    End Sub
    'Private Function Validate_Fields() As Boolean
    '    Try
    '        'If FormState.AStateMode Then
    '        If cmbMelting.SelectedIndex = 0 Then
    '            MessageBox.Show("Select Melting % !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    '            cmbMelting.Focus()
    '            Return False
    '        End If
    '        If cmbMaterial.SelectedIndex = 0 Then
    '            MessageBox.Show("Select Material !", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    '            cmbMaterial.Focus()
    '            Return False
    '        End If
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '        MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Function

End Class