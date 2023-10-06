Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmCoreAdditionReceiveNew
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim GridDoubleClick As Boolean

    Dim TempRow As Integer

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub frmCoreAdditionReceiveNew_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Clear_Form()
        Me.fillLabour()
        Me.fillLotNo()
        'Me.bindDataGridView()
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
    Private Sub Clear_Form()
        Try
            '' For Header Field Start
            Me.TransDt.CustomFormat = "dd/MM/yyyy"
            Me.TransDt.Value = DateTime.Now

            cmbLotNo.SelectedIndex = 0

            txtFrKarigar.Tag = ""
            txtFrKarigar.Clear()
            cmbTLabour.SelectedIndex = 0
            ''For Header Field End

            ''For Detail Field Start
            'txtSrNo.Text = 1
            'cmbItemType.Text = ""

            'txtItemName.Clear()
            'txtIssueWt.Clear()
            'txtIssuePr.Clear()
            'txtFineWt.Clear()
            'txtRemarks.Clear()

            'dgvCore.DataSource = Nothing

            '' For Detail Field End

            GridDoubleClick = False

            txtGoldWt.Clear()
            txtKDMWt.Clear()
            txtCoreWt.Clear()
            txtTotalWt.Clear()

            txtGoldPr.Clear()
            txtKDMPr.Clear()
            txtCorePr.Clear()
            txtTotalPr.Clear()

            txtGoldFt.Clear()
            txtKDMFt.Clear()
            'txtCoreFt.Clear()
            'txtTotalFt.Clear()

            'Me.bindDataGridView()

            btnSave.Text = "&Save"

            Fr_Mode = FormState.AStateMode

            btnSave.Enabled = True
            btnDelete.Enabled = False

            txtFrKarigar.Tag = CInt(UserId)
            txtFrKarigar.Text = Convert.ToString(KarigarName.Trim)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoForCoreAdditionReceive", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Transaction_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
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
            cmbLotNo.ValueMember = "TransactionId"

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            dbManager.CloseConnection(connection)
        End Try
    End Sub

End Class