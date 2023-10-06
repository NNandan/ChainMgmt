Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports JMS.Common_Cls
Public Class frmOpMelting
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
        Try
            If Fr_Mode = FormState.AStateMode Then

                Ep.Clear()
                'If Not errorvalid() Then
                '    Exit Sub
                'End If

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
    Private Sub frmOpMelting_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

            With dgvMelting
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtFineWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtFineWt.Validating
        Try
            If cmbItemType.Text.Trim <> "" And txtRequirePr.Text.Trim <> "" And cmbGItemName.Text.Trim <> "" And Val(txtGrossWt.Text.Trim) > 0 And Val(txtRequirePr.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvMelting.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
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
    Private Sub frmOpMelting_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()
        Me.filltemName()
    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            Ep.Clear()

            txtVocucherNo.Tag = ""
            txtVocucherNo.Clear()
            TransDt.Value = DateTime.Now
            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1

            cmbGItemName.Text = ""
            cmbGItemName.Enabled = True

            txtTotalGrossWt.Clear()
            txtRequirePr.Clear()
            txtGrossWt.Clear()
            txtGrossPr.Clear()

            dgvMelting.RowCount = 0
            '' For Detail Field End

            GridDoubleClick = False

            Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub filltemName()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillItemName", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_ItemMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        Dim dt As DataTable = New DataTable()
        Dim dt1 As DataTable = New DataTable

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbGItemName.DataSource = dt
            cmbGItemName.DisplayMember = "ItemName"
            cmbGItemName.ValueMember = "ItemId"
            cmbGItemName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            cmbGItemName.AutoCompleteDataSource = AutoCompleteSource.ListItems

            cmbItem.BindingContext = New BindingContext()
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
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvMelting.Rows
                If itm.Cells(4).Value = CStr(cmbItem.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists

    End Function
    Private Sub txtGrossWt_TextChanged(sender As Object, e As EventArgs) Handles txtGrossWt.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(txtGrossPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtGrossPr_TextChanged(sender As Object, e As EventArgs) Handles txtGrossPr.TextChanged
        Try
            txtFineWt.Text = Format((Val(txtGrossWt.Text) * Val(txtGrossPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub cmbItem_Enter(sender As Object, e As EventArgs) Handles cmbItem.Enter
        cmbItem.ShowDropDown()
    End Sub
    Private Sub txtTotalGrossWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTotalGrossWt.KeyPress
        numdotkeypress(e, txtTotalGrossWt, Me)
    End Sub
    Private Sub txtRequirePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRequirePr.KeyPress
        numdotkeypress(e, txtRequirePr, Me)
    End Sub
    Private Sub txtGrossWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrossWt.KeyPress
        numdotkeypress(e, txtGrossWt, Me)
    End Sub
    Private Sub txtGrossPr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGrossPr.KeyPress
        numdotkeypress(e, txtGrossPr, Me)
    End Sub
    Private Sub txtGrossWt_Leave(sender As Object, e As EventArgs) Handles txtGrossWt.Leave
        txtGrossWt.Text = Format(Val(txtGrossWt.Text), "0.00")
    End Sub
    Private Sub txtGrossPr_Leave(sender As Object, e As EventArgs) Handles txtGrossPr.Leave
        txtGrossPr.Text = Format(Val(txtGrossPr.Text), "0.00")
    End Sub
    Private Sub txtRequirePr_Leave(sender As Object, e As EventArgs) Handles txtRequirePr.Leave
        txtRequirePr.Text = Format(Val(txtRequirePr.Text), "0.00")
    End Sub
    Private Sub txtTotalGrossWt_Leave(sender As Object, e As EventArgs) Handles txtTotalGrossWt.Leave
        txtTotalGrossWt.Text = Format(Val(txtTotalGrossWt.Text), "0.00")
    End Sub
    Private Sub cmbGItemName_Enter(sender As Object, e As EventArgs) Handles cmbGItemName.Enter
        cmbGItemName.ShowDropDown()
    End Sub
    Private Sub txtVocucherNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtVocucherNo.KeyPress
        '' If certain characters then allow
        If e.KeyChar = vbBack Then Exit Sub
        '' Do not allow the comma character (or any other invalid characters)
        If e.KeyChar = "." Or IsNumeric(e.KeyChar) = False Then e.KeyChar = Chr(0)
    End Sub
    Private Sub txtRequirePr_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRequirePr.Validating
        Try
            If Val(txtRequirePr.Text.Trim < 75 Or txtRequirePr.Text >= 100) Then
                e.Cancel = True
                MsgBox("% in Between 75 to 100", MsgBoxStyle.Critical)
                Exit Sub
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Sub fillGrid()

        If GridDoubleClick = False Then
            dgvMelting.Rows.Add(Val(txtSrNo.Text.Trim),
                                    cmbItemType.Text.Trim(),
                                    txtBagNo.Text.Trim(),
                                    Val(cmbGItemName.SelectedValue),
                                    cmbGItemName.Text.Trim,
                                    Format(Val(txtGrossWt.Text.Trim), "0.00"),
                                    Format(Val(txtGrossPr.Text.Trim), "0.00"),
                                    Format(Val(txtFineWt.Text.Trim), "0.000"))
            GetSrNo(dgvMelting)
        Else
            dgvMelting.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvMelting.Rows(TempRow).Cells(1).Value = cmbItemType.Text.Trim
            dgvMelting.Rows(TempRow).Cells(2).Value = txtBagNo.Text.Trim
            dgvMelting.Rows(TempRow).Cells(3).Value = cmbGItemName.SelectedValue
            dgvMelting.Rows(TempRow).Cells(4).Value = cmbGItemName.Text.Trim
            dgvMelting.Rows(TempRow).Cells(5).Value = Format(Val(txtGrossWt.Text.Trim), "0.00")
            dgvMelting.Rows(TempRow).Cells(6).Value = Format(Val(txtGrossPr.Text.Trim), "0.00")
            dgvMelting.Rows(TempRow).Cells(7).Value = Format(Val(txtFineWt.Text.Trim), "0.000")
            GridDoubleClick = False
        End If

        dgvMelting.TableElement.ScrollToRow(dgvMelting.Rows.Last)

        txtSrNo.Text = dgvMelting.RowCount + 1
        cmbItemType.Text = ""
        txtBagNo.Clear()
        cmbGItemName.SelectedIndex = 0
        txtGrossWt.Clear()
        txtGrossPr.Clear()
        txtFineWt.Clear()

        cmbItemType.Focus()
    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList

        Dim GridSrNo As String = Nothing
        Dim LineNo As String = Nothing
        Dim ItemType As String = Nothing
        Dim SlipBagNo As String = Nothing
        Dim LotNumber As String = Nothing
        Dim ItemId As String = Nothing
        Dim GrossWt As String = Nothing
        Dim ReceivePr As String = Nothing
        Dim FineWt As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbItem.SelectedValue)
        alParaval.Add(txtRequirePr.Text)
        alParaval.Add(txtTotalGrossWt.Text)
        alParaval.Add(UserId)
        alParaval.Add(UserId)

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
                Else
                    GridSrNo = GridSrNo & "|" & Val(row.Cells(0).Value)
                    ItemType = ItemType & "|" & Convert.ToString(row.Cells(1).Value)
                    SlipBagNo = SlipBagNo & "|" & Convert.ToString(row.Cells(2).Value)
                    ItemId = ItemId & "|" & Val(row.Cells(3).Value)
                    GrossWt = GrossWt & "|" & Val(row.Cells(5).Value)
                    ReceivePr = ReceivePr & "|" & Val(row.Cells(6).Value)
                    FineWt = FineWt & "|" & Val(row.Cells(7).Value)
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

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HMeltingDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@HPercent", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HGrossWt", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@HIsOpening", 0, DbType.Boolean))

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
            End With

            dbManager.Insert("SP_Melting_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
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
End Class
