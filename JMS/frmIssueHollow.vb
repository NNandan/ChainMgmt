Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmIssueHollow
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub frmIssueHollow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()

        Me.fillLabour()
    End Sub
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
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If Not String.IsNullOrEmpty(txtTransNo.Text) Then

            Try
                Dim parameters = New List(Of SqlParameter)()

                With parameters
                    .Clear()
                    .Add(dbManager.CreateParameter("@HId", Val(txtTransNo.Text), DbType.Int16))
                End With

                dbManager.Delete("SP_HollowIssue_Delete", CommandType.StoredProcedure, parameters.ToArray())

                MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

                Me.Clear_Form()

            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            End Try
        Else
            MessageBox.Show("Please Select A Record !!!")
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not Validate_Fields() Then Exit Sub

        Try
            If Fr_Mode = FormState.AStateMode Then
                Me.SaveData()
                Me.btnCancel_Click(sender, e)
            Else
                Me.UpdateData()
                Me.btnCancel_Click(sender, e)
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub Clear_Form()
        Try
            txtTransNo.Tag = ""
            txtTransNo.Clear()

            Me.TransDt.CustomFormat = "dd/MM/yyyy"
            Me.TransDt.Value = DateTime.Now

            cmbItemType.SelectedIndex = -1
            cmbtKarigar.SelectedIndex = -1

            txtIssueWt.Clear()
            txtIssuePr.Clear()
            txtFineWt.Clear()

            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()

            Fr_Mode = FormState.AStateMode

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
            MessageBox.Show(ex.Message, "Testing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Function Validate_Fields() As Boolean
        Try
            If String.IsNullOrWhiteSpace(cmbtKarigar.Text.Trim()) Or Convert.ToInt32(cmbtKarigar.SelectedIndex) = -1 Then
                MessageBox.Show("Select Labour !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                cmbtKarigar.Focus()
                Return False
            End If

            If Fr_Mode <> FormState.AStateMode AndAlso String.IsNullOrEmpty(txtTransNo.Text.Trim()) Then
                'If FormState.EStateMode AndAlso String.IsNullOrEmpty(txtTransNo.Text.Trim()) Then
                MessageBox.Show("Select Id !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            Return True
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Function
    Private Sub SaveData()
        Dim iOperationTypeId As Integer = 13 ''Operation Id for Hollow Issue

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                .Add(dbManager.CreateParameter("@HollowIssueDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@HOperationTypeId", iOperationTypeId, DbType.Int16))
                .Add(dbManager.CreateParameter("@HItemType", cmbItemType.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@HSlipBagNo", cmbLotNo.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@HCoreAddNo", txtCoreAddNo.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@HItemBagId", 1, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIssueWt", txtIssueWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@HIssuePr", txtIssuePr.Text, DbType.String))
                .Add(dbManager.CreateParameter("@HFineWt", txtFineWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@HFrKarigar", 1, DbType.Int16))
                .Add(dbManager.CreateParameter("@HToKarigar", cmbtKarigar.SelectedIndex, DbType.String))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_HollowIssue_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateData()
        Dim iOperationTypeId As Integer = 13 ''Operation Id for Hollow Issue

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))
                .Add(dbManager.CreateParameter("@HollowIssueDt", TransDt.Value.ToString(), DbType.DateTime))
                .Add(dbManager.CreateParameter("@OperationTypeId", iOperationTypeId, DbType.Int16))
                .Add(dbManager.CreateParameter("@HItemType", iOperationTypeId, DbType.String))
                .Add(dbManager.CreateParameter("@HSlipBagNo", iOperationTypeId, DbType.String))
                .Add(dbManager.CreateParameter("@HCoreAddNo", iOperationTypeId, DbType.String))
                .Add(dbManager.CreateParameter("@HItemBagId", iOperationTypeId, DbType.Int16))
                .Add(dbManager.CreateParameter("@FrKarigar", txtFrKarigar.Text.Trim(), DbType.Int16))
                .Add(dbManager.CreateParameter("@ToKarigar", cmbtKarigar.SelectedIndex, DbType.String))
                .Add(dbManager.CreateParameter("@CreatedBy", UserName.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@HId", txtTransNo.Text, DbType.Int16))
            End With

            dbManager.Insert("SP_HollowIssue_Update", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Record", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
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

            cmbtKarigar.DataSource = dt
            cmbtKarigar.DisplayMember = "LabourName"
            cmbtKarigar.ValueMember = "LabourId"

            cmbtKarigar.AutoCompleteMode = AutoCompleteMode.SuggestAppend ' This is necessary
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub
End Class