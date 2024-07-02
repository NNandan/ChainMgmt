Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmIssueHollow
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Dim iItemId As Int16 = 0
    Private Sub frmIssueHollow_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Clear_Form()

        Me.bindDataGridView()

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

            cmbtKarigar.Text = ""
            cmbtKarigar.SelectedIndex = -1

            cmbItemType.Text = ""
            cmbLotNo.Text = ""
            txtCoreAddNo.Text = ""
            txtItemName.Text = ""
            txtItemName.Text = ""

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
    Private Sub cmbItemType_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbItemType.SelectedIndexChanged
        If cmbItemType.SelectedIndex = 0 Then

        Else
            Me.fillLotNo()
        End If
    End Sub
    Private Sub SaveData()
        Dim iOperationTypeId As Integer = 15 ''Operation Id for Hollow Issue

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
                .Add(dbManager.CreateParameter("@HItemBagId", txtItemName.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@HIssueWt", txtIssueWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@HIssuePr", txtIssuePr.Text, DbType.String))
                .Add(dbManager.CreateParameter("@HFineWt", txtFineWt.Text.Trim(), DbType.String))
                .Add(dbManager.CreateParameter("@HFrKarigar", txtFrKarigar.Tag, DbType.Int16))
                .Add(dbManager.CreateParameter("@HToKarigar", cmbtKarigar.SelectedValue, DbType.String))
                .Add(dbManager.CreateParameter("@HCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_HollowIssue_Save", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub cmbLotNo_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbLotNo.SelectedIndexChanged
        If cmbLotNo.SelectedIndex > -1 Then
            bindIssueHeaderView()
        End If
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
                .Add(dbManager.CreateParameter("@HItemType", cmbItemType.Text, DbType.String))
                .Add(dbManager.CreateParameter("@HSlipBagNo", cmbLotNo, DbType.String))
                .Add(dbManager.CreateParameter("@HCoreAddNo", txtCoreAddNo.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@HItemBagId", txtItemName.Tag, DbType.Int16))
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
    Private Sub fillLotNo()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNo", DbType.String))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_HollowIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            MessageBox.Show("No Data Exists !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Exit Sub
        End If

        Try
            While dr.Read
                If Not IsDBNull(dr.Item("LotNo")) Then
                    cmbLotNo.Items.Add(dr.Item("LotNo"))
                End If
            End While

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try

    End Sub
    Private Sub dgvHollowIssue_CellDoubleClick(sender As Object, e As GridViewCellEventArgs) Handles dgvHollowIssue.CellDoubleClick
        If dgvHollowIssue.SelectedRows.Count = 0 Then Exit Sub

        If dgvHollowIssue.Rows.Count > 0 Then

            Dim MeltingId As Int16 = Me.dgvHollowIssue.SelectedRows(0).Cells(0).Value

            Me.Clear_Form()

            Fr_Mode = FormState.EStateMode

            Me.fillHeaderFromGridView(MeltingId)

            Me.TblHollowIssue.SelectedIndex = 0
        End If
    End Sub
    Private Sub bindIssueHeaderView()
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoDetails", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", Convert.ToString(cmbLotNo.Text.Trim), DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_HollowIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

            txtTransNo.Text = dtData.Rows(0).Item(0)
            txtCoreAddNo.Text = dtData.Rows(0).Item(1)
            txtItemName.Tag = dtData.Rows(0).Item(2)
            txtItemName.Text = dtData.Rows(0).Item(3)
            txtIssueWt.Text = dtData.Rows(0).Item(4)
            txtIssuePr.Text = dtData.Rows(0).Item(5)
            txtFineWt.Text = dtData.Rows(0).Item(6)
            txtFrKarigar.Tag = dtData.Rows(0).Item(7)
            txtFrKarigar.Text = dtData.Rows(0).Item(8)
            cmbtKarigar.Tag = dtData.Rows(0).Item(9)
            cmbtKarigar.Text = dtData.Rows(0).Item(10)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
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

            dtData = dbManager.GetDataTable("SP_HollowIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub bindDataGridView()
        Dim dtdata As DataTable = fetchAllRecords()

        Try
            dgvHollowIssue.DataSource = dtdata
            dgvHollowIssue.EnableFiltering = True
            dgvHollowIssue.MasterTemplate.ShowFilteringRow = False
            dgvHollowIssue.MasterTemplate.ShowHeaderCellButtons = True
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
        End Try
    End Sub
    Private Sub fillHeaderFromGridView(ByVal intMeltingId As Integer)
        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@HId", CInt(intMeltingId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_HollowIssue_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            txtTransNo.Text = dr.Item("HollowIssueId").ToString
            TransDt.Text = dr.Item("HollowIssueDt").ToString
            cmbItemType.Text = dr.Item("ItemType").ToString
            cmbLotNo.Text = dr.Item("SlipBagNo").ToString
            txtCoreAddNo.Text = dr.Item("CoreAddNo").ToString
            iItemId = dr.Item("ItemId").ToString
            txtItemName.Text = dr.Item("ItemName").ToString
            txtIssueWt.Text = dr.Item("IssueWt").ToString
            txtIssuePr.Text = dr.Item("IssuePr").ToString
            txtFineWt.Text = dr.Item("FineWt").ToString
            txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            cmbtKarigar.Tag = dr.Item("ToKarigarId").ToString
            cmbtKarigar.Text = dr.Item("toKarigarName").ToString
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
End Class