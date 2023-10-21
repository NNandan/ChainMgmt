Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmCoreAdditionReceive
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing
    Dim TempRow As Integer
    Dim GridDoubleClick As Boolean

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

    Dim dbltmpWt As Double = 0
    Dim dbltmpPr As Double = 0
    Dim dbltmpFw As Double = 0
    Dim iItemId As Int16 = 0
    Private Sub frmCoreAdditionReceiveNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Clear_Form()
        Me.fillLabour()
        Me.fillLotNo()

        Me.bindDataGridView()
        Me.BindIDataGridView()
    End Sub
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
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Telerik.WinControls.UI.Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.SelectedIndex > 0 Then
            Me.bindIssueview()

            bindIssueHeaderView()
            bindIssueDetailsView()

            If dgvIssue.RowCount > 0 Then
                SumOfITotal()
            End If

            If dgvRecevie.RowCount > 0 Then
                SumOfITotal()
            End If
        End If
    End Sub
    Private Sub fillLabour()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FillLabour", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_LabourMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim trow As DataRow = dt.NewRow()
            trow(0) = 0
            trow(1) = "---Select---"
            dt.Rows.InsertAt(trow, 0)

            cmbTLabour.DataSource = dt
            cmbTLabour.DisplayMember = "LabourName"
            cmbTLabour.ValueMember = "LabourId"

            cmbTLabour.AutoCompleteMode = AutoCompleteMode.SuggestAppend ' This is necessary
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillLotNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_CoreAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim frow As DataRow = dt.NewRow()
            frow(0) = 0
            frow(1) = "---Select---"
            dt.Rows.InsertAt(frow, 0)

            cmbLotNo.DataSource = dt
            cmbLotNo.DisplayMember = "LotNo"
            cmbLotNo.ValueMember = "CoreAdditionId"

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub txtKDMFw_TextChanged(sender As Object, e As EventArgs)
        'If Not String.IsNullOrWhiteSpace(txtGoldFw.Text) Or Not IsNumeric(txtKDMFw.Text) Then
        '    txtTotalFw.Text = Format((Val(txtGoldFw.Text) + Val(txtKDMFw.Text) + Val(txtCoreFw.Text)), "0.000")
        'End If
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

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
    Private Sub bindIssueview()
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchRecord", DbType.String))
            .Add(dbManager.CreateParameter("@LotNo", cmbLotNo.Text.Trim, DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        Try
            If dr.Read = False Then
                Exit Sub
            Else
                txtTransNo.Text = Val(dr("CoreAdditionId"))
                txtFrKarigar.Tag = Val(dr("FrKarigarId"))
                txtFrKarigar.Text = Convert.ToString(dr("frKarigarName"))
                cmbTLabour.SelectedIndex = Val(dr("ToKarigarId"))
            End If
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub bindIssueHeaderView()
        Dim GoldWt As Double = 0.00
        Dim GoldPr As Double = 0.00
        Dim GoldFw As Double = 0.00

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
                .Add(dbManager.CreateParameter("@CId", txtTransNo.Text.Trim, DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

            iItemId = dtData.Rows(0).Item(3)

            GoldWt = dtData.Rows(0).Item(4)
            GoldPr = dtData.Rows(0).Item(5)
            GoldFw = dtData.Rows(0).Item(6)

            Me.dgvIssue.Rows(0).Cells(3).Value = Format(GoldWt, "0.00")
            Me.dgvIssue.Rows(0).Cells(4).Value = Format(GoldPr, "0.00")
            Me.dgvIssue.Rows(0).Cells(5).Value = Format(GoldFw, "0.000")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub bindIssueDetailsView()
        Dim KdmWt As Double = 0.00
        Dim CoreWt As Double = 0.00

        Dim FineWt As Double = 0.00

        Dim IssuePr As Double = 0.00
        Dim TotalPr As Double = 0.00

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchdRecord", DbType.String))
                .Add(dbManager.CreateParameter("@CId", txtTransNo.Text.Trim, DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_CoreAdditionIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

            For Each dr As DataRow In dtData.Rows
                If dr.Item("ItemName").ToString = "Kdm" Then
                    KdmWt += Convert.ToInt32(dr("IssueWt"))
                ElseIf dr.Item("ItemName").ToString = "Core" Then
                    CoreWt += Convert.ToInt32(dr("IssueWt"))
                End If
                IssuePr += Convert.ToInt32(dr("IssuePr"))
                FineWt += Convert.ToInt32(dr("FineWt"))
            Next

            Me.dgvIssue.Rows(1).Cells(3).Value = Format(KdmWt, "0.00")
            Me.dgvIssue.Rows(1).Cells(4).Value = Format(IssuePr, "0.00")
            Me.dgvIssue.Rows(1).Cells(5).Value = Format(FineWt, "0.000")

            Me.dgvIssue.Rows(2).Cells(3).Value = Format(CoreWt, "0.00")
            Me.dgvIssue.Rows(2).Cells(4).Value = "0.00"
            Me.dgvIssue.Rows(2).Cells(5).Value = "0.000"

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Function Validate_Fields() As Boolean
        Try

            If Not dgvRecevie.RowCount > 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
                Exit Function
            End If

            If Val(dgvRecevie.Rows(4).Cells(3).Value) <> Val(dgvIssue.Rows(3).Cells(3).Value) Then
                MessageBox.Show("Receive Wt. should be Equal to Issue Wt. !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub SaveData()
        Dim iOperationTypeId As Int16 = 14 ''Operation Id for Core Addition Receive

        Dim alParaval As New ArrayList

        Dim GridSrNo As String = Nothing
        Dim ItemName As String = Nothing
        Dim IssueWt As String = Nothing
        Dim IssuePr As String = Nothing
        Dim FineWt As String = Nothing

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(iOperationTypeId)
        alParaval.Add(cmbLotNo.Text)

        alParaval.Add(iItemId)                                  ''Item Id
        alParaval.Add(dgvIssue.Rows(3).Cells(3).Value)          ''Issue Wt
        alParaval.Add(dgvIssue.Rows(3).Cells(4).Value)          ''Issue Pr

        alParaval.Add(dgvRecevie.Rows(2).Cells(3).Value)        ''Rec Wt
        alParaval.Add(dgvRecevie.Rows(3).Cells(4).Value)        ''Rec Pr
        alParaval.Add(dgvRecevie.Rows(3).Cells(3).Value)        ''Bhuka Wt

        alParaval.Add(txtFrKarigar.Tag)
        alParaval.Add(cmbTLabour.SelectedValue)

        'For Details
        For i As Integer = 0 To dgvRecevie.RowCount - 2
            If dgvRecevie.Rows(i).Cells(0).Value <> Nothing Then
                If GridSrNo = "" Then
                    GridSrNo = dgvRecevie.Rows(i).Cells(0).Value
                    ItemName = Convert.ToString(dgvRecevie.Rows(i).Cells(2).Value)
                    IssueWt = dgvRecevie.Rows(i).Cells(3).Value
                    IssuePr = dgvRecevie.Rows(i).Cells(4).Value
                    FineWt = dgvRecevie.Rows(i).Cells(5).Value
                Else
                    GridSrNo = GridSrNo & "|" & Val(dgvRecevie.Rows(i).Cells(0).Value)
                    ItemName = ItemName & "|" & Convert.ToString(dgvRecevie.Rows(i).Cells(2).Value)
                    IssueWt = IssueWt & "|" & dgvRecevie.Rows(i).Cells(3).Value
                    IssuePr = IssuePr & "|" & dgvRecevie.Rows(i).Cells(4).Value
                    FineWt = FineWt & "|" & dgvRecevie.Rows(i).Cells(5).Value
                End If
            End If
            IRowCount += 1
        Next

        alParaval.Add(ItemName)
        alParaval.Add(IssueWt)
        alParaval.Add(IssuePr)
        alParaval.Add(FineWt)

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HCoreRDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HOperationTypeId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLotNo", alParaval.Item(iValue), DbType.String))
                iValue += 1

                ''For Transaction Receive Start
                .Add(dbManager.CreateParameter("@TItemId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1
                .Add(dbManager.CreateParameter("@TIssueWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@TIssuePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@TRecWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@TRecPr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@TBhukaWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                ''For Transaction Receive End

                .Add(dbManager.CreateParameter("@HFrKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@HToKarigarId", alParaval.Item(iValue), DbType.String))
                iValue += 1

                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))

                ''Details Start
                .Add(dbManager.CreateParameter("@DItemName", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceiveWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DReceivePr", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DFineWt", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_CoreAdditionReceive_Save", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor.Current = Cursors.Default
        End Try

    End Sub
    Private Sub BindIDataGridView()
        dgvIssue.RowCount = 4
        dgvIssue.ColumnCount = 6

        Me.dgvIssue.TableElement.BeginUpdate()
        Me.dgvIssue.Rows(0).Cells(0).Value = "1"
        Me.dgvIssue.Rows(1).Cells(0).Value = "2"
        Me.dgvIssue.Rows(2).Cells(0).Value = "3"
        Me.dgvIssue.Rows(3).Cells(0).Value = "4"

        Me.dgvIssue.Rows(0).Cells(2).Value = "Gold"
        Me.dgvIssue.Rows(1).Cells(2).Value = "KDM"
        Me.dgvIssue.Rows(2).Cells(2).Value = "Core"
        Me.dgvIssue.Rows(3).Cells(2).Value = "Total"
        Me.dgvIssue.TableElement.EndUpdate()

    End Sub
    Private Sub txtRFineWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtRFineWt.Validating
        Try
            If cmbItemName.Text.Trim <> "" And Val(txtRRecWt.Text.Trim) > 0 Then
                Me.fillGrid()
            Else
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SumOfRTotal()
        Dim dblRecWt As Double = 0
        Dim dblRecFw As Double = 0
        Dim dblRecPr As Double = 0

        For i As Integer = 0 To dgvRecevie.RowCount - 1
            dblRecWt += Convert.ToDouble(dgvRecevie.Rows(i).Cells(3).Value)
            dblRecFw += Convert.ToDouble(dgvRecevie.Rows(i).Cells(5).Value)
        Next

        dblRecPr = (dblRecFw / dblRecWt) * 100

        Me.dgvRecevie.Rows(4).Cells(2).Value = "Total"
        Me.dgvRecevie.Rows(4).Cells(3).Value = Format(dblRecWt, "0.00")
        Me.dgvRecevie.Rows(4).Cells(4).Value = Format(dblRecPr, "0.00")
        Me.dgvRecevie.Rows(4).Cells(5).Value = Format(dblRecFw, "0.000")

    End Sub
    Private Sub SumOfRETotal()
        Dim dblRecWt As Double = 0
        Dim dblRecFw As Double = 0
        Dim dblRecPr As Double = 0

        For i As Integer = 0 To 3
            dblRecWt += Convert.ToDouble(dgvRecevie.Rows(i).Cells(3).Value)
            dblRecFw += Convert.ToDouble(dgvRecevie.Rows(i).Cells(5).Value)
        Next

        dblRecPr = (dblRecFw / dblRecWt) * 100

        Me.dgvRecevie.Rows(4).Cells(2).Value = "Total"
        Me.dgvRecevie.Rows(4).Cells(3).Value = Format(dblRecWt, "0.00")
        Me.dgvRecevie.Rows(4).Cells(4).Value = Format(dblRecPr, "0.00")
        Me.dgvRecevie.Rows(4).Cells(5).Value = Format(dblRecFw, "0.000")

    End Sub
    Private Sub SumOfITotal()
        Dim dblIssueWt As Double = 0
        Dim dblIssueFw As Double = 0
        Dim dblIssuePr As Double = 0

        For i As Integer = 0 To dgvIssue.RowCount - 2
            dblIssueWt += Val(dgvIssue.Rows(i).Cells(3).Value)
            dblIssueFw += Val(dgvIssue.Rows(i).Cells(5).Value)
        Next

        dblIssuePr = (dblIssueFw / dblIssueWt) * 100

        Me.dgvIssue.Rows(3).Cells(3).Value = Format(dblIssueWt, "0.00")
        Me.dgvIssue.Rows(3).Cells(4).Value = Format(dblIssuePr, "0.00")
        Me.dgvIssue.Rows(3).Cells(5).Value = Format(dblIssueFw, "0.000")

    End Sub
    Private Sub txtRRecWt_TextChanged(sender As Object, e As EventArgs) Handles txtRRecWt.TextChanged
        Try
            txtRFineWt.Text = Format((Val(txtRRecWt.Text) * Val(txtRRecPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SumOfKdmCoreScrap()
        Dim dbltmpReceiveWt As Double = 0
        Dim dbltmpReceiveFw As Double = 0

        Dim dblIssueWt As Double = 0
        Dim dblIssuePr As Double = 0
        Dim dblIssueFw As Double = 0

        For i As Integer = 0 To 1
            dbltmpReceiveWt += Val(dgvRecevie.Rows(i).Cells(3).Value)
            dbltmpReceiveFw += Val(dgvRecevie.Rows(i).Cells(5).Value)
        Next

        dblIssueWt = Me.dgvIssue.Rows(3).Cells(3).Value
        dblIssueFw = Me.dgvIssue.Rows(3).Cells(5).Value

        dbltmpWt = dblIssueWt - dbltmpReceiveWt
        dbltmpFw = dblIssueFw - dbltmpReceiveFw

        dbltmpPr = (dbltmpFw / dbltmpWt) * 100

        txtRRecPr.Text = Format(dbltmpPr, "0.00")
    End Sub
    Private Sub txtRRecPr_TextChanged(sender As Object, e As EventArgs) Handles txtRRecPr.TextChanged
        Try
            txtRFineWt.Text = Format((Val(txtRRecWt.Text) * Val(txtRRecPr.Text)) / 100, "0.000")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub txtRRecWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRRecWt.KeyPress
        numdotkeypress(e, txtRRecWt, Me)
    End Sub
    Private Sub txtRRecPr_Leave(sender As Object, e As EventArgs) Handles txtRRecPr.Leave
        txtRRecPr.Text = Format(Val(txtRRecPr.Text), "0.00")
    End Sub
    Private Sub txtRFineWt_Leave(sender As Object, e As EventArgs) Handles txtRFineWt.Leave
        txtRFineWt.Text = Format(Val(txtRFineWt.Text), "0.00")
    End Sub
    Sub fillGrid()

        If GridDoubleClick = False Then

            For item As Integer = 0 To dgvRecevie.Rows.Count - 1
                If cmbItemName.Text = dgvRecevie.Rows(item).Cells(2).Value.ToString Then
                    MessageBox.Show("Duplicate Item")
                    Return
                End If
            Next

            dgvRecevie.Rows.Add(Val(txtSrNo.Text.Trim),
                                    1,
                                    cmbItemName.Text.Trim(),
                                    Format(Val(txtRRecWt.Text.Trim), "0.00"),
                                    Format(Val(txtRRecPr.Text.Trim), "0.00"),
                                    Format(Val(txtRFineWt.Text.Trim), "0.000"))

            GetSrNo(dgvRecevie)
        Else
            dgvRecevie.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvRecevie.Rows(TempRow).Cells(1).Value = 1
            dgvRecevie.Rows(TempRow).Cells(2).Value = cmbItemName.Text.Trim
            dgvRecevie.Rows(TempRow).Cells(3).Value = Format(CDbl(txtRRecWt.Text.Trim), "0.00")
            dgvRecevie.Rows(TempRow).Cells(4).Value = Format(CDbl(txtRRecPr.Text.Trim), "0.00")
            dgvRecevie.Rows(TempRow).Cells(5).Value = Format(CDbl(txtRFineWt.Text.Trim), "0.000")
            GridDoubleClick = False

            SumOfRETotal()
        End If

        If dgvRecevie.RowCount > 3 And GridDoubleClick = False Then
            dgvRecevie.Rows.AddNew()
            Me.SumOfRTotal()
            txtSrNo.Clear()
        Else
            dgvRecevie.TableElement.ScrollToRow(dgvRecevie.Rows.Last)

            txtSrNo.Text = dgvRecevie.RowCount + 1
            'Me.SumOfRTotal()
        End If

        cmbItemName.Text = ""
        txtRRecWt.Clear()
        txtRRecPr.Clear()
        txtRFineWt.Clear()

        cmbItemName.Focus()
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvRecevie.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvFillReceive_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvFillReceive.CellDoubleClick
        If dgvFillReceive.SelectedRows.Count = 0 Then Exit Sub

        If dgvFillReceive.Rows.Count > 0 Then

            Dim MeltingId As Int16 = Me.dgvFillReceive.SelectedRows(0).Cells(0).Value

            Me.Clear_Form()

            Fr_Mode = FormState.EStateMode

            Me.fillHeaderFromGridView(MeltingId)

            Me.fillDetailsFromGridView(MeltingId)

            Me.TbCoreReceive.SelectedIndex = 0
        End If
    End Sub
    Private Sub frmCoreAdditionReceive_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

            If e.KeyCode = Keys.F2 Then
                cmbItemName.Text = ""
                txtRRecWt.Clear()
                txtRRecPr.Clear()
                txtRFineWt.Clear()
                cmbItemName.Focus()
            End If

            With dgvRecevie
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
                'Me.Total()
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub txtRRecWt_LostFocus(sender As Object, e As EventArgs) Handles txtRRecWt.LostFocus

        If cmbItemName.Text = "KDM" Then
            txtRRecPr.Text = Val(Me.dgvIssue.Rows(1).Cells(4).Value)
        ElseIf cmbItemName.Text = "Core Scrap" Then
            txtRRecPr.Text = Val(Me.dgvIssue.Rows(2).Cells(4).Value)
        Else
            If dgvRecevie.RowCount >= 2 Then
                SumOfKdmCoreScrap()
            End If
        End If

    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start

            txtTransNo.Tag = ""
            txtTransNo.Clear()
            TransDt.Value = DateTime.Now

            cmbLotNo.SelectedIndex = 0

            txtFrKarigar.Tag = ""
            txtFrKarigar.Text = ""
            cmbTLabour.SelectedIndex = 0
            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1
            cmbItemName.Text = ""
            txtRRecWt.Clear()
            txtRRecWt.Clear()
            txtRFineWt.Clear()
            dgvRecevie.RowCount = 0

            dgvIssue.RowCount = 0

            '' For Detail Field End

            GridDoubleClick = False

            Me.bindDataGridView()

            btnSave.Text = "&Save"

            Fr_Mode = FormState.AStateMode

            btnSave.Enabled = True
            btnDelete.Enabled = False

            txtFrKarigar.Tag = CInt(UserId)
            txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)

            cmbLotNo.Focus()
            cmbLotNo.Select()

            Me.BindIDataGridView()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtTransNo.Text) Then

            If (MsgBox("[DELETION] Are You Sure To Delete This Entry ?", vbYesNo + vbDefaultButton2 + vbQuestion, "Attn : " + UserName.Trim()) = vbYes) Then

                Try
                    Dim parameters = New List(Of SqlParameter)()

                    With parameters
                        .Clear()
                        .Add(dbManager.CreateParameter("@CId", txtTransNo.Text, DbType.Int16))
                    End With

                    dbManager.Delete("SP_CoreReceive_Delete", CommandType.StoredProcedure, parameters.ToArray())

                    MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Me.Clear_Form()

                Catch ex As Exception
                    MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub fillHeaderFromGridView(ByVal intCoreId As Integer)
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@CId", CInt(intCoreId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_CoreAdditionReceive_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtTransNo.Text = dr.Item("CoreReceiveId").ToString()
            TransDt.Text = dr.Item("CoreReceiveDt").ToString
            cmbLotNo.Text = dr.Item("LotNo").ToString
            iItemId = dr.Item("ItemId").ToString
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            cmbTLabour.SelectedIndex = dr.Item("ToKarigarId").ToString
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillDetailsFromGridView(ByVal CoreId As Integer)
        Dim dttable As New DataTable

        dttable = fetchAllRecords(CInt(CoreId))

        For Each ROW As DataRow In dttable.Rows
            dgvRecevie.Rows.Add(1, Val(ROW("CoreReceiveDetailsId")), CStr(ROW("ItemName")), Format(Val(ROW("ReceiveWt")), "0.00"), Format(Val(ROW("ReceivePr")), "0.00"), Format(Val(ROW("FineWt"))))
        Next

        Me.GetSrNo(dgvRecevie)
        dgvRecevie.Rows.AddNew()
        Me.SumOfRTotal()

        dgvRecevie.ReadOnly = True
    End Sub
    Private Sub dgvRecevie_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvRecevie.CellDoubleClick
        Try
            If e.RowIndex = -1 Then Exit Sub

            If e.RowIndex >= 0 And dgvRecevie.Rows(e.RowIndex).Cells(0).Value <> Nothing Then
                GridDoubleClick = True
                txtSrNo.Text = dgvRecevie.Rows(e.RowIndex).Cells(0).Value.ToString()
                cmbItemName.Tag = dgvRecevie.Rows(e.RowIndex).Cells(1).Value.ToString()
                cmbItemName.Text = dgvRecevie.Rows(e.RowIndex).Cells(2).Value.ToString()
                txtRRecWt.Text = CStr(dgvRecevie.Rows(e.RowIndex).Cells(3).Value)
                txtRRecPr.Text = CInt(dgvRecevie.Rows(e.RowIndex).Cells(4).Value)
                txtRFineWt.Text = dgvRecevie.Rows(e.RowIndex).Cells(5).Value.ToString()
                TempRow = e.RowIndex
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            dtData = dbManager.GetDataTable("SP_CoreAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtData
    End Function
    Private Function fetchAllRecords(ByVal intCoreId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
                .Add(dbManager.CreateParameter("@CId", CInt(intCoreId), DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_CoreAdditionReceive_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dtData
    End Function
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()

        Try
            dgvFillReceive.DataSource = dtdata
            dgvFillReceive.EnableFiltering = True
            dgvFillReceive.MasterTemplate.ShowFilteringRow = False
            dgvFillReceive.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
        End Try
    End Sub
End Class