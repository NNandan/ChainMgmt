Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmMeltingFinalizeLot
    Dim strLotNo As String = Nothing
    Dim intOpId As Int16 = 0
    Dim dbManager As New SqlHelper()
    Public Sub New(ByVal sLotNo As String)
        InitializeComponent()
        ''For Center
        Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)

        ''For Right Bottom Corner Screen
        'Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width, Screen.PrimaryScreen.WorkingArea.Height - Me.Height)

        strLotNo = Convert.ToString(sLotNo)
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.UpdateLossData(strLotNo)

        Me.btnCancel_Click(sender, e)

        Me.Close()

    End Sub
    Private Sub UpdateLossData(ByVal sLotNo As String)
        Try
            Dim Hparameters = New List(Of SqlParameter)()
            Hparameters.Clear()

            With Hparameters
                .Add(dbManager.CreateParameter("@ActionType", "UpdateLossWt", DbType.String))
                .Add(dbManager.CreateParameter("@NewLotNo", sLotNo, DbType.String))
                .Add(dbManager.CreateParameter("@LossWt", Convert.ToString(txtLossWt.Text.Trim), DbType.String))
                .Add(dbManager.CreateParameter("@OpId", 43, DbType.Int16))
                .Add(dbManager.CreateParameter("@NCreatedBy", UserName.Trim(), DbType.String))
            End With

            dbManager.Insert("SP_NewLotNo_Update", CommandType.StoredProcedure, Hparameters.ToArray())

            MessageBox.Show("Data Saved !!!", "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Me.Clear_Form()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Clear_Form()
        Try
            rdgvReceive.DataSource = Nothing
            rdgvIssue.DataSource = Nothing


            txtLossWt.Clear()
            txtWorkDone.Clear()

            lblRGTotal.Text = 0.0
            lblIGTotal.Text = 0.0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Fancy", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub frmMeltingFinalizeLot_Load(sender As Object, e As EventArgs) Handles Me.Load
        ''For Receive Gold
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

        Me.CalculateTotal()
        Me.FetchWorkDoneData()
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
        lblRGQty.Text = 0.00

        Try
            For Each row As GridViewRowInfo In rdgvReceive.Rows
                lblRGTotal.Text = Format(Val(lblRGTotal.Text) + Val(row.Cells(4).Value), "0.00")
                lblRGQty.Text = Format(Val(lblRGQty.Text) + Val(row.Cells(5).Value), "0.00")
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
        lblIGQty.Text = 0.00

        Try
            For Each row As GridViewRowInfo In rdgvIssue.Rows
                lblIGTotal.Text = Format(Val(lblIGTotal.Text) + Val(row.Cells(4).Value), "0.00")
                lblIGQty.Text = Format(Val(lblIGQty.Text) + Val(row.Cells(5).Value), "0.00")
            Next
        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Private Sub CalculateTotal()
        Dim dRTotal As Double = 0
        Dim dITotal As Double = 0

        Dim dGTotal As Double = 0

        dRTotal = Val(lblRGTotal.Text.Trim)

        dITotal = Val(lblIGTotal.Text.Trim)

        lblLoss.Text = "Loss Wt."
        txtLossWt.Text = Format(Val(dITotal - dRTotal), "0.00")

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

End Class