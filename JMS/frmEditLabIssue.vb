Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls
Imports Telerik.WinControls.UI
Imports JMS.Common_Cls
Public Class frmEditLabIssue
    Private mFr_State As FormState

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim iLabIssueId As Integer
    Public Sub New(ByVal iLabId As Integer)
        InitializeComponent()
        iLabIssueId = iLabId
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
                    Me.btnUpdate.Enabled = True
                    Me.btnUpdate.Text = "Update"
                Case FormState.EStateMode
                    CType(Me.ParentForm, frmMain).FormMode.Text = "Edit Record"
                    Me.btnUpdate.Text = "Update"
            End Select
        End Set
    End Property
    Private Sub frmEditLabIssue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.fillLab()
        Me.fillHeader(iLabIssueId)
        Me.fillDetails(iLabIssueId)
    End Sub
    Private Sub fillHeader(ByVal iLabIssueId As Integer)

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@TId", CInt(iLabIssueId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_LabIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtTransId.Text = dr.Item("LabIssueId").ToString
            TransDt.Text = dr.Item("LabIssueDt").ToString
            cmbLab.SelectedIndex = dr.Item("LabId").ToString

            If dr.Item("TableType") = "T" Then
                rbReLotSample.Checked = True
                rbReLotSample.Enabled = False
            Else
                rbReBagSample.Checked = True
                rbReBagSample.Enabled = False
            End If
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub fillDetails(ByVal iLabIssueId As Integer)
        Dim dt As New DataTable

        dt = fetchAllRecords(CInt(iLabIssueId))

        If dt.Rows.Count = 0 Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If
        Try
            MskUpdateDt.Text = dt.Rows(0).Item("UpdateDt").ToString
            txtTransId.Tag = dt.Rows(0).Item("TransactionId").ToString
            txtLotNo.Text = dt.Rows(0).Item("LotNo").ToString
            txtOperation.Tag = dt.Rows(0).Item("IOId").ToString
            txtOperation.Text = dt.Rows(0).Item("OperationName").ToString
            txtIssueWt.Text = dt.Rows(0).Item("IssueWt").ToString
            txtIssuePr.Text = dt.Rows(0).Item("IssuePr").ToString
            txtFineWt.Text = dt.Rows(0).Item("FineWt").ToString
            txtLabRptPr.Text = dt.Rows(0).Item("LabReport").ToString()
            txtSampleFineRec.Text = dt.Rows(0).Item("ReceiveGrossWt").ToString()
            txtSampleGrossRec.Text = dt.Rows(0).Item("ReceiveFineWt").ToString()
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

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

    Private Function fetchAllRecords(ByVal intMeltingId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@TId", CInt(intMeltingId), DbType.Int16))
                .Add(dbManager.CreateParameter("@ActionType", "FetchDetailRecord", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_LabIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData
    End Function
    Private Sub dgvLabReport_CellValueChanged(sender As Object, e As GridViewCellEventArgs)
        Dim columnIndex = 0

        If e.ColumnIndex = columnIndex Then
            'Dim isChecked = CBool(dgvLabReport.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            'If isChecked Then
            '    For Each row As GridViewRowInfo In dgvLabReport.Rows
            '        If row.Index <> e.RowIndex Then
            '            row.Cells(columnIndex).Value = Not isChecked
            '        End If
            '    Next
            'End If
        End If
    End Sub
    Private Sub dgvLabReport_ValueChanged(sender As Object, e As EventArgs)
        'If dgvLabReport.CurrentColumn.Name = "colChkBox" Then
        '    dgvLabReport.EndEdit()
        'End If

        Me.CalculateTotal()
    End Sub
    Private Sub CalculateTotal()
        Dim sReceiveWt As Single = 0
        Dim sReceivePr As Single = 0
        Dim sFinePr As Single = 0

        'For Each row As GridViewRowInfo In dgvLabReport.Rows
        '    If CBool(row.Cells()(0).Value) = True Then
        '        sReceiveWt += Single.Parse(row.Cells(5).Value)
        '        sReceivePr += Single.Parse(row.Cells(6).Value)
        '        sFinePr += Single.Parse(row.Cells(7).Value)
        '    End If
        'Next

        txtIssueWt.Text = Format(sReceiveWt, "0.00")
        txtIssuePr.Text = Format(sReceivePr, "0.00")
        txtFineWt.Text = Format(sFinePr, "0.00")

    End Sub
    Private Sub txtLabRptPr_TextChanged(sender As Object, e As EventArgs) Handles txtLabRptPr.TextChanged
        Try
            txtDiff.Text = Format((Val(txtLabRptPr.Text) - Val(txtIssuePr.Text)), "0.00")
            txtSampleGrossPr.Text = Format(Val(txtLabRptPr.Text.Trim()), "0.00")

            txtTotalLossFine.Text = Format((Val(txtSampleGrossRec.Text) * Val(txtSampleGrossPr.Text)) / 100 - (Val(txtTotalRecTotal.Text)), "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtSampleFineRec_TextChanged(sender As Object, e As EventArgs) Handles txtSampleFineRec.TextChanged
        Try
            txtTotalRecWt.Text = Format(Val(txtSampleFineRec.Text) + Val(txtSampleGrossRec.Text), "0.00")

            txtSampleFineTotal.Text = Format((Val(txtSampleFineRec.Text) * Val(txtSampleFinePr.Text)) / 100, "0.00")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtSampleGrossRec_TextChanged(sender As Object, e As EventArgs) Handles txtSampleGrossRec.TextChanged
        Try
            txtTotalRecWt.Text = Format(Val(txtSampleFineRec.Text) + Val(txtSampleGrossRec.Text), "0.00")

            txtSampleGrossTotal.Text = Format((Val(txtSampleGrossRec.Text) * Val(txtSampleGrossPr.Text)) / 100, "0.000")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub txtSampleFineTotal_TextChanged(sender As Object, e As EventArgs) Handles txtSampleFineTotal.TextChanged
        txtTotalRecTotal.Text = Format(Val(txtSampleFineTotal.Text) + Val(txtSampleGrossTotal.Text), "0.000")
    End Sub
    Private Sub txtSampleGrossTotal_TextChanged(sender As Object, e As EventArgs) Handles txtSampleGrossTotal.TextChanged
        txtTotalRecTotal.Text = Format(Val(txtSampleFineTotal.Text) + Val(txtSampleGrossTotal.Text), "0.000")
    End Sub
    Private Sub txtTotalRecTotal_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRecTotal.TextChanged
        txtTotalLossFine.Text = Format((Val(txtFineWt.Text) - Val(txtTotalRecTotal.Text)), "0.00")
    End Sub
    Private Sub txtTotalRecWt_TextChanged(sender As Object, e As EventArgs) Handles txtTotalRecWt.TextChanged
        txtTotalLossWt.Text = Format((Val(txtIssueWt.Text) - Val(txtTotalRecWt.Text)), "0.00")
    End Sub
    Private Sub txtLabRptPr_Leave(sender As Object, e As EventArgs) Handles txtLabRptPr.Leave
        txtLabRptPr.Text = Format(Val(txtLabRptPr.Text), "0.00")
    End Sub
    Private Sub txtSampleFineRec_Leave(sender As Object, e As EventArgs) Handles txtSampleFineRec.Leave
        txtSampleFineRec.Text = Format(Val(txtSampleFineRec.Text), "0.00")
    End Sub
    Private Sub txtSampleGrossRec_Leave(sender As Object, e As EventArgs) Handles txtSampleGrossRec.Leave
        txtSampleGrossRec.Text = Format(Val(txtSampleGrossRec.Text), "0.00")
    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        'If Not Validate_Fields() Then Exit Sub

        Try
            Me.SaveData()
            Me.btnCancel_Click(sender, e)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub SaveData()
        Dim alParaval As New ArrayList
        Dim TableType As String = ""

        Dim iValue As Integer = 0

        If rbReLotSample.Checked = True Then
            TableType = "T"
        Else
            TableType = "B"
        End If

        ''For Master
        alParaval.Add(TransDt.Value.ToString())
        alParaval.Add(cmbLab.SelectedValue)

        ''For Details
        alParaval.Add(MskUpdateDt.Text.Trim)
        alParaval.Add(txtTransId.Tag)
        alParaval.Add(txtLotNo.Text)
        alParaval.Add(txtOperation.Tag)
        alParaval.Add(TableType)
        alParaval.Add(txtIssueWt.Text)
        alParaval.Add(txtIssuePr.Text)

        alParaval.Add(txtLabRptPr.Text)
        alParaval.Add(txtSampleFineRec.Text)
        alParaval.Add(txtSampleGrossRec.Text)
        alParaval.Add(txtTotalLossWt.Text)
        alParaval.Add(txtTotalLossFine.Text.Trim)
        alParaval.Add(Val(UserId))

        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@HLabIssueDt", alParaval.Item(iValue), DbType.DateTime))
                iValue += 1
                .Add(dbManager.CreateParameter("@HLabId", alParaval.Item(iValue), DbType.Int16))
                iValue += 1

                .Add(dbManager.CreateParameter("@LId", iLabIssueId, DbType.Int16))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))

                .Add(dbManager.CreateParameter("@DUpdateDt", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DTransactionId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DLotNumber", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DOperationId", alParaval.Item(iValue), DbType.String))
                iValue += 1
                .Add(dbManager.CreateParameter("@DTableType", alParaval.Item(iValue), DbType.String))
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
                .Add(dbManager.CreateParameter("@DReceivedBy", alParaval.Item(iValue), DbType.String))
                iValue += 1
            End With

            dbManager.Insert("SP_LabIssue_Edit", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub Clear_Form()
        Try

            '' For Header Field Start
            TransDt.Value = DateTime.Now
            cmbLab.SelectedIndex = 0

            rbReBagSample.Enabled = False
            rbReLotSample.Enabled = False
            '' For Header Field End

            '' For Detail Field Start
            MskUpdateDt.Text = Format(Now, "dd/MM/yyyy")
            txtLotNo.Clear()
            txtOperation.Clear()
            txtLabRptPr.Clear()
            txtSampleFineRec.Clear()
            txtSampleGrossRec.Clear()
            txtTotalRecWt.Clear()
            txtTotalLossWt.Clear()

            txtDiff.Clear()
            txtSampleFineTotal.Clear()
            txtSampleGrossTotal.Clear()
            txtTotalRecTotal.Clear()
            txtTotalLossFine.Clear()

            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtFineWt.Clear()

            btnUpdate.Text = "&Update"

            btnUpdate.Enabled = True

            TransDt.Focus()
            TransDt.Select()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Call Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Function CheckForAlphaCharacters(ByVal StringToCheck As String)

        For i = 0 To StringToCheck.Length - 1
            If Char.IsLetter(StringToCheck.Chars(i)) Then
                Return True
            End If
        Next

        Return False

    End Function

    Private Sub txtLotNo_TextChanged(sender As Object, e As EventArgs) Handles txtLotNo.TextChanged
        If CheckForAlphaCharacters(txtLotNo.Text.Trim) Then
            rbReBagSample.Checked = True
        Else
            rbReLotSample.Checked = True
        End If
    End Sub
End Class