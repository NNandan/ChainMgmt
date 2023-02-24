Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports JMS.Common_Cls
Public Class frmOpLabIssue
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim strSQL As String = Nothing
    Dim TempRow As Integer
    Dim GridDoubleClick As Boolean
    Private Sub frmOpLabIssue_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()
        Me.fillLab()
        Me.fillOperation()
    End Sub
    Private Sub fillLab()
        Dim connection As SqlConnection = Nothing
        Dim dt As DataTable = New DataTable()

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FillCombo", DbType.String))

        Dim dr = dbManager.GetDataReader("SP_LabMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)

        dt.Load(dr)

        Try
            'Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbLab.DataSource = dt
            cmbLab.DisplayMember = "LabName"
            cmbLab.ValueMember = "LabId"
            cmbLab.AutoCompleteMode = AutoCompleteMode.Suggest
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub fillOperation()

        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        parameters.Add(dbManager.CreateParameter("@ActionType", "FillOperation", DbType.String))

        Dim dr = dbManager.GetDataReader("SP_OperationMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbOperation.DataSource = dt
            cmbOperation.DisplayMember = "OperationName"
            cmbOperation.ValueMember = "OperationId"

            cmbOperation.AutoCompleteMode = AutoCompleteMode.SuggestAppend ' This is necessary
            cmbOperation.AutoCompleteDataSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
    Private Sub txtToLotNo_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs)
        Try
            If cmbOperation.Text.Trim <> "" And txtIssueWt.Text.Trim <> "" And txtIssuePr.Text.Trim <> "" And Val(txtReportPr.Text.Trim) > 0 And Val(txtRGrossWt.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvLab.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
                    MsgBox("Duplicate Data")
                Else
                    Me.fillGrid()
                End If
            Else
                'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function ChkDuplicate() As Boolean
        Dim exists As Boolean = False

        If GridDoubleClick = False Then
            For Each itm As GridViewRowInfo In dgvLab.Rows
                If itm.Cells(4).Value = CStr(cmbOperation.Text.Trim) Then
                    exists = True
                End If
            Next
        End If

        Return exists

    End Function
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Me.SaveData()
            Me.btnCancel_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Product_Name, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Sub fillGrid()
        If GridDoubleClick = False Then
            dgvLab.Rows.Add(Val(txtSrNo.Text.Trim),
                                    (TransDt.Text),
                                    txtLotNo.Text.Trim(),
                                    cmbOperation.SelectedIndex,
                                    cmbOperation.Text.Trim(),
                                    txtIssueWt.Text.Trim(),
                                    txtIssuePr.Text.Trim(),
                                    Format(Val(txtReportPr.Text.Trim), "0.00"),
                                    Format(Val(txtRGrossWt.Text.Trim), "0.00"),
                                    Format(Val(txtRFineWt.Text.Trim), "0.00"),
                                    Format(Val(txtGLossWt.Text.Trim), "0.00"),
                                    Format(Val(txtGFineWt.Text.Trim), "0.00"))

            GetSrNo(dgvLab)
        Else
            dgvLab.Rows(TempRow).Cells(0).Value = txtSrNo.Text.Trim
            dgvLab.Rows(TempRow).Cells(1).Value = UpdateDt.Text
            dgvLab.Rows(TempRow).Cells(2).Value = txtLotNo.Text.Trim
            dgvLab.Rows(TempRow).Cells(3).Value = cmbOperation.Text.Trim
            dgvLab.Rows(TempRow).Cells(4).Value = Format(CDbl(txtIssueWt.Text.Trim), "0.00")
            dgvLab.Rows(TempRow).Cells(5).Value = Format(CDbl(txtIssuePr.Text.Trim), "0.00")
            dgvLab.Rows(TempRow).Cells(6).Value = Format(CDbl(txtReportPr.Text.Trim), "0.00")
            dgvLab.Rows(TempRow).Cells(7).Value = Format(CDbl(txtRGrossWt.Text.Trim), "0.00")
            dgvLab.Rows(TempRow).Cells(8).Value = Format(CDbl(txtRFineWt.Text.Trim), "0.00")
            dgvLab.Rows(TempRow).Cells(9).Value = Format(CDbl(txtGLossWt.Text.Trim), "0.00")
            dgvLab.Rows(TempRow).Cells(10).Value = Format(CDbl(txtGFineWt.Text.Trim), "0.00")
            GridDoubleClick = False
        End If

        dgvLab.TableElement.ScrollToRow(dgvLab.Rows.Last)

        txtSrNo.Text = dgvLab.RowCount + 1
        UpdateDt.Clear()
        txtLotNo.Clear()
        cmbOperation.SelectedIndex = 0
        txtIssueWt.Clear()
        txtIssuePr.Clear()
        txtReportPr.Clear()
        txtRGrossWt.Clear()
        txtRFineWt.Clear()
        txtGLossWt.Clear()
        txtGFineWt.Clear()
    End Sub
    Sub GetSrNo(ByRef grid As Telerik.WinControls.UI.RadGridView)
        Try
            For Each rowInfo As GridViewRowInfo In dgvLab.Rows
                rowInfo.Cells(0).Value = rowInfo.Index + 1
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList
        Dim GridSrNo As String = ""
        Dim UpdateDt As String = ""
        Dim LotNumber As String = ""
        Dim OperationId As String = ""
        Dim IssueWt As String = ""
        Dim IssuePr As String = ""
        Dim LabReport As String = ""
        Dim ReceiveGrossWt As String = ""
        Dim ReceiveFineWt As String = ""
        Dim GLossWt As String = ""
        Dim FLossWt As String = ""

        Dim IRowCount As Integer = 0
        Dim iValue As Integer = 0

        If Not cmbLab.SelectedIndex > 0 Then
            MessageBox.Show("Select Lab Name !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            cmbLab.Focus()
        Else

            alParaval.Add(TransDt.Value.ToString())
            alParaval.Add(cmbLab.SelectedValue)

            For Each row As GridViewRowInfo In dgvLab.Rows
                If row.Cells(1).Value <> Nothing Then
                    If UpdateDt = "" Then
                        UpdateDt = Convert.ToString(row.Cells(1).Value)
                        LotNumber = Convert.ToString(row.Cells(2).Value)
                        OperationId = Val(row.Cells(3).Value)
                        IssueWt = Val(row.Cells(5).Value)
                        IssuePr = Val(row.Cells(6).Value)
                        LabReport = Val(row.Cells(7).Value)
                        ReceiveGrossWt = Val(row.Cells(8).Value)
                        ReceiveFineWt = Val(row.Cells(9).Value)
                        GLossWt = Val(row.Cells(10).Value)
                        FLossWt = Val(row.Cells(11).Value)
                    Else
                        UpdateDt = UpdateDt & "|" & Convert.ToString(row.Cells(1).Value)
                        LotNumber = LotNumber & "|" & Convert.ToString((row.Cells(2).Value).ToString())
                        OperationId = OperationId & "|" & Val(row.Cells(3).Value)
                        IssueWt = IssueWt & "|" & Val(row.Cells(5).Value)
                        IssuePr = IssuePr & "|" & Val(row.Cells(6).Value)
                        LabReport = LabReport & "|" & Val(row.Cells(7).Value)
                        ReceiveGrossWt = ReceiveGrossWt & "|" & Val(row.Cells(8).Value)
                        ReceiveFineWt = ReceiveFineWt & "|" & Val(row.Cells(9).Value)
                        GLossWt = GLossWt & "|" & Val(row.Cells(10).Value)
                        FLossWt = FLossWt & "|" & Val(row.Cells(11).Value)
                    End If
                End If
                IRowCount += 1
            Next

            alParaval.Add(UpdateDt)
            alParaval.Add(LotNumber)
            alParaval.Add(OperationId)
            alParaval.Add(IssueWt)
            alParaval.Add(IssuePr)
            alParaval.Add(LabReport)
            alParaval.Add(ReceiveGrossWt)
            alParaval.Add(ReceiveFineWt)
            alParaval.Add(GLossWt)
            alParaval.Add(FLossWt)

            Try
                Dim Hparameters = New List(Of SqlParameter)()
                Hparameters.Clear()

                With Hparameters
                    .Add(dbManager.CreateParameter("@HLabIssueDt", alParaval.Item(iValue), DbType.DateTime))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@HLabId", alParaval.Item(iValue), DbType.Int16))
                    iValue += 1

                    .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
                    .Add(dbManager.CreateParameter("@GridCount", IRowCount, DbType.Int16))
                    .Add(dbManager.CreateParameter("@HIsOpening", 0, DbType.Boolean))
                    .Add(dbManager.CreateParameter("@DReceivedBy", UserId, DbType.Int16))

                    .Add(dbManager.CreateParameter("@DUpdateDt", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@DLotNumber", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@DOperationId", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@DIssueWt", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@DIssuePr", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@DLabReport", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@DReceiveGrossWt", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@DReceiveFineWt", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@DGLossWt", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                    .Add(dbManager.CreateParameter("@DFLossWt", alParaval.Item(iValue), DbType.String))
                    iValue += 1
                End With

                dbManager.Insert("SP_OpLabIssue_Save", CommandType.StoredProcedure, Hparameters.ToArray())

                MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally
                'Me.ClearAllData()
            End Try
        End If
    End Sub
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            cmbLab.SelectedIndex = 0
            '' For Header Field End

            '' For Detail Field Start
            txtSrNo.Text = 1

            UpdateDt.Text = "__/__/____"
            UpdateDt.Value = DateTime.Now

            txtLotNo.Tag = ""
            txtLotNo.Clear()

            cmbOperation.Text = ""
            cmbOperation.Enabled = True

            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtReportPr.Clear()
            txtRGrossWt.Clear()
            txtRFineWt.Clear()
            txtGLossWt.Clear()
            txtGFineWt.Clear()

            txtFrKarigar.Tag = CInt(UserId)
            txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)

            dgvLab.RowCount = 0
            '' For Detail Field End

            GridDoubleClick = False

            'Fr_Mode = FormState.AStateMode

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub txtGFineWt_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtGFineWt.Validating
        Try
            If cmbOperation.Text.Trim <> "" And txtIssueWt.Text.Trim <> "" And txtIssuePr.Text.Trim <> "" And Val(txtReportPr.Text.Trim) > 0 And Val(txtRGrossWt.Text.Trim) > 0 Then

                'ErrorProvider1.SetError(txtRequirePr, "")

                If dgvLab.Rows.Count > 0 AndAlso ChkDuplicate() = True Then
                    MsgBox("Duplicate Data")
                Else
                    Me.fillGrid()
                End If
            Else
                'ErrorProvider1.SetError(txtRequirePr, "Enter Required %")
                MsgBox("Enter Proper Details")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtIssueWt_Leave(sender As Object, e As EventArgs) Handles txtIssueWt.Leave
        txtIssueWt.Text = Format(Val(txtIssueWt.Text), "0.00")
    End Sub
    Private Sub txtIssueWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssueWt.KeyPress
        numdotkeypress(e, txtIssueWt, Me)
    End Sub
    Private Sub txtIssuePr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIssuePr.KeyPress
        numdotkeypress(e, txtIssuePr, Me)
    End Sub
    Private Sub txtReportPr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtReportPr.KeyPress
        numdotkeypress(e, txtReportPr, Me)
    End Sub
    Private Sub txtRGrossWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRGrossWt.KeyPress
        numdotkeypress(e, txtRGrossWt, Me)
    End Sub
    Private Sub txtRFineWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRFineWt.KeyPress
        numdotkeypress(e, txtRGrossWt, Me)
    End Sub
    Private Sub txtGLossWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGLossWt.KeyPress
        numdotkeypress(e, txtGLossWt, Me)
    End Sub
    Private Sub txtGFineWt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtGFineWt.KeyPress
        numdotkeypress(e, txtGFineWt, Me)
    End Sub
    Private Sub frmOpLabIssue_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try

            If e.KeyCode = Keys.Tab Then
                Call SendKeyTab()
            End If

            With dgvLab
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With

        Catch ex As Exception

        End Try
    End Sub
    Private Sub cmbOperation_Enter(sender As Object, e As EventArgs) Handles cmbOperation.Enter
        cmbOperation.ShowDropDown()
    End Sub
    Private Sub cmbLab_Enter(sender As Object, e As EventArgs) Handles cmbLab.Enter
        cmbLab.ShowDropDown()
    End Sub
    Private Sub txtLotNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtLotNo.KeyPress
        '' If certain characters then allow
        If e.KeyChar = vbBack Then Exit Sub
        '' Do not allow the comma character (or any other invalid characters)
        If e.KeyChar = "." Or IsNumeric(e.KeyChar) = False Then e.KeyChar = Chr(0)
    End Sub
    Private Sub txtIssuePr_Leave(sender As Object, e As EventArgs) Handles txtIssuePr.Leave
        txtIssuePr.Text = Format(Val(txtIssuePr.Text), "0.00")
    End Sub
    Private Sub txtReportPr_Leave(sender As Object, e As EventArgs) Handles txtReportPr.Leave
        txtReportPr.Text = Format(Val(txtReportPr.Text), "0.00")
    End Sub
    Private Sub txtRGrossWt_Leave(sender As Object, e As EventArgs) Handles txtRGrossWt.Leave
        txtRGrossWt.Text = Format(Val(txtRGrossWt.Text), "0.00")
    End Sub
    Private Sub txtRFineWt_Leave(sender As Object, e As EventArgs) Handles txtRFineWt.Leave
        txtRFineWt.Text = Format(Val(txtRFineWt.Text), "0.00")
    End Sub
    Private Sub txtGLossWt_Leave(sender As Object, e As EventArgs) Handles txtGLossWt.Leave
        txtGLossWt.Text = Format(Val(txtGLossWt.Text), "0.00")
    End Sub
    Private Sub txtGFineWt_Leave(sender As Object, e As EventArgs) Handles txtGFineWt.Leave
        txtGFineWt.Text = Format(Val(txtGFineWt.Text), "0.00")
    End Sub
    Private Sub txtGFineWt_KeyDown(sender As Object, e As KeyEventArgs) Handles txtGFineWt.KeyDown
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

            With dgvLab
                If e.KeyCode = Keys.F12 Then
                    .Rows.Remove(.CurrentRow)
                End If
            End With

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class