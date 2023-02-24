Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports JMS.Common_Cls
Public Class frmOpInterReceipt
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer
    Dim GridDoubleClick As Boolean

    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Sub frmOpInterReceipt_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()
        Me.filltemName()
    End Sub
    Private Sub filltemName()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FillItemName", DbType.String))
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
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                    CType(Me.ParentForm, frmMain).FormMode.Text = "New Record"
                    Me.btnSave.Enabled = True
                    Me.btnSave.Text = "Save"
                    Me.btnDelete.Enabled = False
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit Record"
                    Me.btnSave.Text = "Update"
                    Me.btnDelete.Enabled = True
            End Select
        End Set
    End Property
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        'If Not Validate_Fields() Then Exit Sub
        Try
            If Fr_Mode = FormState.AStateMode Then
                Me.SaveData()
                Me.btnCancel_Click(sender, e)
            Else
                'Me.UpdateData()
                Me.btnCancel_Click(sender, e)
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub txtNarration_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        'Try
        '    If cmbItem.Text.Trim <> "" And Val(txtReceiveWt.Text.Trim) > 0 And Val(txtReceivePr.Text.Trim) > 0 Then

        '        'ErrorProvider1.SetError(txtRequirePr, "")

        '        If dgvStockReceipt.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
        '            MsgBox("Duplicate Data")
        '        Else
        '            Me.fillGrid()
        '            'Me.Total()
        '        End If
        '    Else
        '        'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
        '        MsgBox("Enter Proper Details")
        '    End If
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim IssueId As String = ""
        Dim ItemId As String = ""
        Dim ReceivePr As String = ""
        Dim ReceiveWt As String = ""
        Dim FineWt As String = ""

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(1)
        alParaval.Add(4)
        alParaval.Add(txtVocucherNo.Text.Trim())
        alParaval.Add(100)
        alParaval.Add(100)

        For Each row As GridViewRowInfo In dgvStockReceipt.Rows
            If row.Cells(0).Value <> Nothing Then
                If IssueId = "" Then
                    ItemId = Val(row.Cells(1).Value)
                    ReceiveWt = Val(row.Cells(3).Value)
                    ReceivePr = Val(row.Cells(4).Value)
                    FineWt = Val(row.Cells(5).Value)
                Else
                    ItemId = ItemId & "|" & Val(row.Cells(1).Value)
                    ReceiveWt = ReceiveWt & "|" & row.Cells(3).Value
                    ReceivePr = ReceivePr & "|" & row.Cells(4).Value
                    FineWt = FineWt & "|" & row.Cells(5).Value
                End If
            End If
            IRowCount += 1
        Next

        'alParaval.Add(IssueId)
        alParaval.Add(ItemId)
        alParaval.Add(ReceiveWt)
        alParaval.Add(ReceivePr)
        alParaval.Add(FineWt)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HReceiptDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HfDeptId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HtDeptId ", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HVoucherNo", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIsOpening", 0, DbType.Boolean))

                '.Add(dbManager.CreateParameter("@DLotNo", alParaval.Item(iValue), DbType.String))
                'iValue += 1
                .Add(dbManager.CreateParameter("@DItemId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiveWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceivePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_Receipt_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Product_Name", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Sub fillGrid()

        If GridDoubleClick = False Then
            dgvStockReceipt.Rows.Add(Val(txtSrNo.Text.Trim),
                                    Val(cmbItem.SelectedValue),
                                    cmbItem.Text.Trim(),
                                    Format(Val(txtReceiveWt.Text.Trim), "0.00"),
                                    Format(Val(txtReceivePr.Text.Trim), "0.00"),
                                    Format(Val(txtFineWt.Text.Trim), "0.000"))
            GetSrNo(dgvStockReceipt)
        Else
            dgvStockReceipt.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvStockReceipt.Rows(TempRow).Cells(5).Value = Format(Val(txtReceiveWt.Text.Trim), "0.00")
            dgvStockReceipt.Rows(TempRow).Cells(6).Value = Format(Val(txtReceivePr.Text.Trim), "0.00")
            dgvStockReceipt.Rows(TempRow).Cells(7).Value = Format(Val(txtFineWt.Text.Trim), "0.000")
            dgvStockReceipt.Rows(TempRow).Cells(8).Value = Val(txtFineWt.Tag.Trim)
            GridDoubleClick = False
        End If

        dgvStockReceipt.TableElement.ScrollToRow(dgvStockReceipt.Rows.Last)

        txtSrNo.Text = dgvStockReceipt.RowCount + 1
        cmbItem.SelectedIndex = 0
        txtReceiveWt.Clear()
        txtReceivePr.Clear()
        txtFineWt.Clear()
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvStockReceipt.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceiveWt_TextChanged(sender As Object, e As EventArgs) Handles txtReceiveWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtReceiveWt.Text) * Val(txtReceivePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceivePr_TextChanged(sender As Object, e As EventArgs) Handles txtReceivePr.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtReceiveWt.Text) * Val(txtReceivePr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtReceiveWt_Leave(sender As Object, e As EventArgs) Handles txtReceiveWt.Leave
        txtReceiveWt.Text = Format(Val(txtReceiveWt.Text), "0.00")
    End Sub
    Private Sub Btn_Find_Click(sender As Object, e As EventArgs) Handles Btn_Find.Click
        If Me.dgvStockReceipt.SelectedRows.Count > 0 Then
            Dim rows As GridViewDataRowInfo() = New GridViewDataRowInfo(Me.dgvStockReceipt.SelectedRows.Count - 1) {}
            Me.dgvStockReceipt.SelectedRows.CopyTo(rows, 0)

            Me.dgvStockReceipt.BeginUpdate()

            For i As Integer = 0 To rows.Length - 1
                Me.dgvStockReceipt.Rows.Remove(rows(i))
            Next

            Me.dgvStockReceipt.EndUpdate()
        End If
    End Sub
    Private Sub cmbItem_Enter(sender As Object, e As EventArgs) Handles cmbItem.Enter
        cmbItem.ShowDropDown()
    End Sub
    Private Sub txtReceiveWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReceiveWt.KeyPress
        numdotkeypress(e, txtReceiveWt, Me)
    End Sub
    Private Sub txtReceivePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReceivePr.KeyPress
        numdotkeypress(e, txtReceivePr, Me)
    End Sub
    Private Sub txtReceivePr_Leave(sender As Object, e As EventArgs) Handles txtReceivePr.Leave
        txtReceivePr.Text = Format(Val(txtReceivePr.Text), "0.00")
    End Sub
    Private Sub txtFineWt_Leave(sender As Object, e As EventArgs) Handles txtFineWt.Leave
        txtFineWt.Text = Format(Val(txtFineWt.Text), "0.00")
    End Sub

    Private Sub txtFineWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFineWt.Validating
        Try
            If cmbItem.Text.Trim <> "" And Val(txtReceiveWt.Text.Trim) > 0 And Val(txtReceivePr.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvStockReceipt.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
                    MsgBox("Duplicate Data")
                Else
                    Me.fillGrid()
                    'Me.Total()
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
            '' For Header Field Start
            txtVocucherNo.Tag = ""
            txtVocucherNo.Clear()
            TransDt.Value = DateTime.Now
            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1

            cmbItem.Text = ""
            cmbItem.Enabled = True

            txtReceiveWt.Clear()
            txtReceivePr.Clear()
            txtFineWt.Clear()

            dgvStockReceipt.RowCount = 0
            '' For Detail Field End

            GridDoubleClick = False

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvStockReceipt.Rows
                If itm.Cells(4).Value = CStr(cmbItem.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists

    End Function
    Private Sub frmOpInterReceipt_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CType(Me.ParentForm, frmMain).FormMode.Text = ""
                    Me.Close()
                End If
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If

            With dgvStockReceipt
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class