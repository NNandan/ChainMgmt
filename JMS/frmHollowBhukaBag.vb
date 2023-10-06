Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmHollowBhukaBag
    Dim USERADD, USEREDIT, USERVIEW, USERDELETE As Boolean      'USED FOR RIGHT MANAGEMAENT

    Private mFr_State As FormState

    Dim strSQL As String = Nothing

    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()

    Private Sub tbBhukaBag_Click(sender As Object, e As EventArgs) Handles tbBhukaBag.Click
        If tbBhukaBag.SelectedIndex = 0 Then     ''for Create Bhuka Bag
            Me.fillBagType()
            Me.Clear_CForm()
        ElseIf tbBhukaBag.SelectedIndex = 1 Then ''for Receive Bhuka Bag
            'Me.fillRecBagNo()
            Me.Clear_RForm()
        ElseIf tbBhukaBag.SelectedIndex = 2 Then ''for Update Bhuka Bag
            'Me.fillUpdBagNo()
            Me.Clear_UForm()
        ElseIf tbBhukaBag.SelectedIndex = 3 Then ''for Grid Fill
            'Me.FillUpdatedData()
        End If
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
    Private Sub frmHollowBhukaBag_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillBagType()
    End Sub
    Private Sub fillBagType()
        Dim connection As SqlConnection = Nothing

        Dim parameters = New List(Of SqlParameter)()

        With parameters
            .Clear()
            .Add(dbManager.CreateParameter("@ActionType", "FetchHollowBhukaBag", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_BagMaster_Select", CommandType.StoredProcedure, parameters.ToArray(), connection)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        If tbBhukaBag.SelectedIndex = 0 Then

            Try
                'Insert the Default Item to DataTable.
                Dim row As DataRow = dt.NewRow()
                row(0) = 0
                row(1) = "---Select---"
                dt.Rows.InsertAt(row, 0)

                'Assign DataTable as DataSource.
                cmbCBagtype.DataSource = dt
                cmbCBagtype.DisplayMember = "ItemName"
                cmbCBagtype.ValueMember = "ItemId"
            Catch ex As Exception
                MessageBox.Show("Error:- " & ex.Message)
            Finally

            End Try

        End If
    End Sub

    Private Sub Clear_CForm()
        Try
            Me.RTransDt.CustomFormat = "dd/MM/yyyy"
            Me.RTransDt.Value = DateTime.Now

            cmbCBagtype.Enabled = True
            cmbCBagtype.SelectedIndex = 0

            lblMaxNo.Visible = False
            txtMaxNo.Visible = False

            lblBhukaTotal.Text = "0.00"
            lblReceivePrTotal.Text = "0.00"
            lblFineTotal.Text = "0.00"

            If btnSave.Text = "&Save" Then
                dgvCBhukaBag.DataSource = Nothing
            Else
                dgvCBhukaBag.RowCount = 0
                cmbCBagtype.Text = ""
            End If

            btnSave.Text = "&Save"
            btnREdit.Enabled = True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_RForm()
        Try
            Me.RTransDt.CustomFormat = "dd/MM/yyyy"
            Me.RTransDt.Value = DateTime.Now

            cmbRBagNo.Enabled = True
            cmbRBagNo.Text = ""
            txtRIssueWt.Clear()
            txtRIssuePr.Clear()
            txtRBagName.Clear()
            txtRWtOnScale.Clear()
            txtRRecieveWt.Clear()

            txtRSample.Clear()
            txtRTotalWt.Clear()

            txtRCarbon.Clear()
            txtRGrossLoss.Clear()
            txtRBagName.Clear()

            dgvRBhukaBag.DataSource = Nothing

            btnRSave.Text = "&Save"
            btnREdit.Enabled = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_UForm()
        Try
            Me.UTransDt.CustomFormat = "dd/MM/yyyy"
            Me.UTransDt.Value = DateTime.Now

            cmbUpdBagNo.Enabled = True
            cmbUpdBagNo.SelectedIndex = 0

            txtUBagName.Clear()
            'txtUReceivePr.Clear()
            'txtUReceiveWt.Clear()
            'txtUreceiveFineWt.Clear()
            'txtUGrossLoss.Clear()
            'txtUpdLossFine.Clear()
            'txtUIssuePr.Clear()
            'txtUIssueWt.Clear()
            'txtUIssueFineWt.Clear()
            'txtUWtOnScale.Clear()
            'txtUcarbonReceive.Clear()
            'txtUGrossLoss.Text = ""
            'txtUpdLossFine.Text = ""

            btnUSave.Text = "&Save"
            btnUpdEdit.Enabled = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Chain", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class