Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmFaFinalizeLot
    Dim strLotNo As String
    Dim intOpId As Int16
    Dim dblLossAllowed As Double

    Dim dbManager As New SqlHelper()
    Private sender As Object
    Private e As EventArgs

    Public Sub New(ByVal sLotNo As String, ByVal iOpId As Int16, dLossAllowed As Double)
        Me.Controls.Clear()
        InitializeComponent()
        ''For Center
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)

        ''For Right Bottom Corner Screen
        'Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)

        strLotNo = Convert.ToString(sLotNo)
        intOpId = CInt(iOpId)
        dblLossAllowed = CDbl(dLossAllowed)
    End Sub
    Private Sub frmFinalizeLot_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ''For Receive Gold
        'lblVaccume.Text = "Testing"
        rdgvReceive.AutoGenerateColumns = False
        rdgvReceive.DataSource = FetchRGData()
        rdgvReceive.EnableFiltering = True
        rdgvReceive.MasterTemplate.ShowHeaderCellButtons = True
        rdgvReceive.MasterTemplate.ShowFilteringRow = False
        rdgvReceive.CurrentRow = Nothing
        Me.FetchRGTotal()
        ''For Issue Gold
        rdgvIssue.AutoGenerateColumns = False
        rdgvIssue.DataSource = FetchOGData()
        rdgvIssue.EnableFiltering = True
        rdgvIssue.MasterTemplate.ShowHeaderCellButtons = True
        rdgvIssue.MasterTemplate.ShowFilteringRow = False
        rdgvIssue.CurrentRow = Nothing
        Me.FetchOGTotal()

        rdgvMReceive.AutoGenerateColumns = False
        rdgvMReceive.DataSource = FetchRMData()
        rdgvMReceive.EnableFiltering = True
        rdgvMReceive.MasterTemplate.ShowHeaderCellButtons = True
        rdgvMReceive.MasterTemplate.ShowFilteringRow = False
        rdgvMReceive.CurrentRow = Nothing
        Me.FetchRMTotal()

        rdgvMIssue.AutoGenerateColumns = False
        rdgvMIssue.DataSource = FetchIMData()
        rdgvMIssue.EnableFiltering = True
        rdgvMIssue.MasterTemplate.ShowHeaderCellButtons = True
        rdgvMIssue.MasterTemplate.ShowFilteringRow = False
        rdgvMIssue.CurrentRow = Nothing
        Me.FetchIMTotal()

        Me.CalculateTotal()
        Me.FetchWorkDoneData()
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Close()
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Function FetchRGData() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchGData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", strLotNo, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ReceiveDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub FetchRGTotal()
        lblRGTotal.Text = 0.00
        lblRQty.Text = 0.00

        Try
            For Each row As GridViewRowInfo In rdgvReceive.Rows
                lblRGTotal.Text = Format(Val(lblRGTotal.Text) + Val(row.Cells(4).Value), "0.00")
                lblRQty.Text = Format(Val(lblRQty.Text) + Val(row.Cells(5).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function FetchOGData() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchGData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", strLotNo, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_IssueDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub FetchOGTotal()
        lblIGTotal.Text = 0.00
        lblIGTotal.Text = 0.00

        Try
            For Each row As GridViewRowInfo In rdgvIssue.Rows
                lblIGTotal.Text = Format(Val(lblIGTotal.Text) + Val(row.Cells(4).Value), "0.00")
                lblIGQty.Text = Format(Val(lblIGQty.Text) + Val(row.Cells(5).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function FetchRMData() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchOData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", strLotNo, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ReceiveDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub FetchRMTotal()
        lblRMTotal.Text = 0.00
        lblRMQty.Text = 0.00

        Try
            For Each row As GridViewRowInfo In rdgvMReceive.Rows
                lblRMTotal.Text = Format(Val(lblRMTotal.Text) + Val(row.Cells(4).Value), "0.00")
                lblRMQty.Text = Format(Val(lblRMQty.Text) + Val(row.Cells(5).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Function FetchIMData() As DataTable
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchOData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", strLotNo, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_IssueDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub FetchIMTotal()
        lblIMTotal.Text = 0.00
        lblIMQty.Text = 0.00

        Try
            For Each row As GridViewRowInfo In rdgvMIssue.Rows
                lblIMTotal.Text = Format(Val(lblIMTotal.Text) + Val(row.Cells(4).Value), "0.00")
                lblIMQty.Text = Format(Val(lblIMQty.Text) + Val(row.Cells(5).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub FetchWorkDoneData()
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchWorkDoneData", DbType.String))
                .Add(dbManager.CreateParameter("@LotNo", strLotNo, DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_ReceiveDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                txtWorkDone.Text = dtData.Rows(0).Item("RecWt").ToString()
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub UpdateVaccumData(ByVal sLotNo As String)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@ActionType", "UpdateVaccumWt", DbType.String))
                .Add(dbManager.CreateParameter("@NewLotNo", sLotNo, DbType.String))
                .Add(dbManager.CreateParameter("@VaccumWt", Convert.ToString(txtLossWt.Text.Trim), DbType.String))
                ''.Add(dbManager.CreateParameter("@OpId", Convert.ToInt16(intOpId), DbType.Int16))
                .Add(dbManager.CreateParameter("@NCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_NewLotNo_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateLossData(ByVal sLotNo As String, ByVal iOptype As Int16)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@ActionType", "UpdateLossWt", DbType.String))
                .Add(dbManager.CreateParameter("@NewLotNo", sLotNo, DbType.String))
                .Add(dbManager.CreateParameter("@LossWt", Convert.ToString(txtLossWt.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@OpId", Convert.ToInt16(intOpId), DbType.Int16))
                .Add(dbManager.CreateParameter("@NCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_NewLotNo_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateStockAddData(ByVal sLotNo As String, ByVal iOptype As Int16)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@ActionType", "UpdateStockAdd", DbType.String))
                .Add(dbManager.CreateParameter("@NewLotNo", sLotNo, DbType.String))
                .Add(dbManager.CreateParameter("@StockAWt", Convert.ToString(txtLossWt.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@OpId", Convert.ToInt16(intOpId), DbType.Int16))
                .Add(dbManager.CreateParameter("@NCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_NewLotNo_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateStockRemData(ByVal sLotNo As String, ByVal iOptype As Int16)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@ActionType", "UpdateStockRem", DbType.String))
                .Add(dbManager.CreateParameter("@NewLotNo", sLotNo, DbType.String))
                .Add(dbManager.CreateParameter("@StockRWt", Convert.ToString(txtLossWt.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@OpId", Convert.ToInt16(intOpId), DbType.Int16))
                .Add(dbManager.CreateParameter("@NCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_NewLotNo_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        ''If Not Operation_Validate_Fields(txtLossWt.Text.Trim) Then Exit Sub

        If Not Operation_Validate_Fields() Then Exit Sub

        Select Case intOpId
            Case = 2
                Me.UpdateVaccumData(strLotNo)
            Case = 1
                Me.UpdateLossData(strLotNo, intOpId)
            Case = 3
                Me.UpdateStockAddData(strLotNo, intOpId)
            Case = 4
                Me.UpdateStockRemData(strLotNo, intOpId)
            Case = 8
                Me.UpdateVaccumData(strLotNo)
            Case Else
        End Select
        Me.btnCancel_Click(sender, e)
        'Dim frm1 As New frmIssueReceive()
        'frm1.Close()
        'frm1.Hide()
        Me.Close()
        Dim i = Application.OpenForms.Count - 2
        'While (i > 2)
        Application.OpenForms(i).Close()
        '    i = i - 1
        'End While
        Dim frm As New frmFaIssueReceive()
        frm.ShowDialog()
        frm.BringToFront()
        frm.Focus()
    End Sub
    Private Sub lblLoss_TextChanged(sender As Object, e As EventArgs) Handles lblLoss.TextChanged
        Select Case intOpId
            Case = 1
                lblLoss.Text = "Loss Wt."
            Case = 2
                lblLoss.Text = "Vaccum Wt."
            Case = 3
                lblLoss.Text = "Stock Add. Wt."
            Case = 4
                lblLoss.Text = "Stock Rem. Wt."
            Case = 8
                lblLoss.Text = "Vaccum Add Wt."
            Case Else
        End Select
    End Sub
    'To Check All Validations
    Private Function Operation_Validate_Fields() As Boolean
        Try

            If Not txtLossWt.Text.Trim >= 0 Then
                MessageBox.Show("Loss Wt. Cannot be Less Than 0")
                Return False
            End If
            'Select Case For 3,4,6
            Select Case intOpId
                Case = 3, 4, 6
                    If Not txtTotalLossWt.Text.Trim = 0 Then
                        MessageBox.Show("Total Loss Wt. Should Be Equal To Zero")
                        Return False
                    End If
                Case Else
            End Select
            'To Check Grid Are Filled Or Not

            If rdgvReceive.RowCount = 0 Or rdgvIssue.RowCount = 0 Then
                MessageBox.Show("Cannot Save Without Detail Information!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If

            ''To Check Max Value Allowed Start
            Dim dMaxAllowed As Double = 0

            dMaxAllowed = (txtWorkDone.Text * dblLossAllowed) / 100

            dMaxAllowed = FormatNumber(dMaxAllowed, 2)

            If Val(txtLossWt.Text) > dMaxAllowed Then
                MessageBox.Show("Value cannot be more than Specified in operation Master!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
                Return False
            End If
            ''To Check Max Value Allowed End

            Return True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Private Function IsMaxLossAllow() As Boolean
        Dim dMaxAllowed As Double = 0

        dMaxAllowed = (lblWorkDone.Text * dblLossAllowed) / 100

        If Val(txtLossWt.Text) > dMaxAllowed Then
            Return False
        End If

        Return True

    End Function
    Private Sub CalculateTotal()
        Dim dRTotal As Double = 0
        Dim dITotal As Double = 0

        Dim dGTotal As Double = 0

        dRTotal = Val(lblRGTotal.Text.Trim) + Val(lblRMTotal.Text.Trim)

        dITotal = Val(lblIGTotal.Text.Trim) + Val(lblIMTotal.Text.Trim)

        Select Case intOpId
            Case = 1
                lblLoss.Text = "Loss Wt."
                txtLossWt.Text = Format(Val(lblIGTotal.Text.Trim - lblRGTotal.Text.Trim), "0.00")
                txtLossWt.ReadOnly = True
                txtTotalLossWt.ReadOnly = True
                txtWorkDone.ReadOnly = True
            Case = 2
                lblLoss.Text = "Vaccum Wt."
                txtLossWt.Text = Format(Val(lblIGTotal.Text.Trim - lblRGTotal.Text.Trim), "0.00")
                txtLossWt.ReadOnly = True
                txtTotalLossWt.ReadOnly = True
                txtWorkDone.ReadOnly = True
            Case = 3
                lblLoss.Text = "Stock Add. Wt."
                txtLossWt.Text = Format(Val(lblRGTotal.Text.Trim - lblIGTotal.Text.Trim), "0.00")
                txtTotalLossWt.Text = Format(Val(dITotal - dRTotal), "0.00")
                txtLossWt.ReadOnly = True
                txtTotalLossWt.ReadOnly = True
                txtWorkDone.ReadOnly = True
            Case = 4
                lblLoss.Text = "Stock Rem. Wt."
                txtLossWt.Text = Format(Val(lblIGTotal.Text.Trim - lblRGTotal.Text.Trim), "0.00")
                txtTotalLossWt.Text = Format(Val(dITotal - dRTotal), "0.00")
                txtLossWt.ReadOnly = True
                txtTotalLossWt.ReadOnly = True
                txtWorkDone.ReadOnly = True
            Case = 8
                lblLoss.Text = "Vaccume Stock Add Wt."
                txtLossWt.Text = Format(Val(lblIGTotal.Text.Trim - lblRGTotal.Text.Trim), "0.00")
                txtLossWt.ReadOnly = True
                txtTotalLossWt.ReadOnly = True
                txtWorkDone.ReadOnly = True
        End Select

    End Sub
    Private Sub lblRGTotal_TextChanged(sender As Object, e As EventArgs) Handles lblRGTotal.TextChanged
        lblRGrTot.Text = Format(Val(lblRGTotal.Text) + Val(lblRMTotal.Text), "0.00")
    End Sub
    Private Sub lblRMTotal_TextChanged(sender As Object, e As EventArgs) Handles lblRMTotal.TextChanged
        lblRGrTot.Text = Format(Val(lblRGTotal.Text) + Val(lblRMTotal.Text), "0.00")
    End Sub
    Private Sub lblIGTotal_TextChanged(sender As Object, e As EventArgs) Handles lblIGTotal.TextChanged
        lblIGrTot.Text = Format(Val(lblIGTotal.Text) + Val(lblIMTotal.Text), "0.00")
    End Sub
    Private Sub lblIMTotal_TextChanged(sender As Object, e As EventArgs) Handles lblIMTotal.TextChanged
        lblIGrTot.Text = Format(Val(lblIGTotal.Text) + Val(lblIMTotal.Text), "0.00")
    End Sub
    Private Sub Clear_Form()
        Try
            rdgvReceive.DataSource = Nothing
            rdgvIssue.DataSource = Nothing

            rdgvMReceive.DataSource = Nothing
            rdgvMIssue.DataSource = Nothing

            txtLossWt.Clear()
            txtWorkDone.Clear()

            lblRGTotal.Text = 0.0
            lblIGTotal.Text = 0.0

            lblRMTotal.Text = 0.0
            lblIMTotal.Text = 0.0

            lblRGrTot.Text = 0.0
            lblIGrTot.Text = 0.0

            lblIMTotal.Text = 0.0
            lblIGrTot.Text = 0.0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
End Class