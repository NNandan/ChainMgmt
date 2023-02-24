Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Public Class frmTransactionStockRpt
    Dim strReportName As String = Nothing
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        dgvTransStock.AutoGenerateColumns = False
        dgvTransStock.DataSource = FetchAllRecords()
        dgvTransStock.EnableFiltering = True
        dgvTransStock.MasterTemplate.ShowHeaderCellButtons = True
        dgvTransStock.MasterTemplate.ShowFilteringRow = False
        dgvTransStock.CurrentRow = Nothing
    End Sub
    Private Function FetchAllRecords() As DataTable

        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "TransactionStock", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockReport_Select", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

        Return dtData

    End Function
    Private Sub SetupGridViewForTransaction(ByRef ObjGrdView As Telerik.WinControls.UI.RadGridView)
        ObjGrdView.AutoGenerateColumns = False
        ObjGrdView.AllowDragToGroup = False
        ObjGrdView.EnableFiltering = True
        ObjGrdView.ShowFilteringRow = False
        ObjGrdView.ShowHeaderCellButtons = True

        ObjGrdView.Columns.Clear()

        Dim ColtransId As New GridViewTextBoxColumn()
        ColtransId.Name = "ColtransId"
        ColtransId.HeaderText = "Tran. Id"
        ColtransId.FieldName = "TransactionId"
        ColtransId.IsVisible = False
        ColtransId.TextAlignment = ContentAlignment.MiddleRight
        ObjGrdView.MasterTemplate.Columns.Add(ColtransId)

        Dim ColtransDt As New GridViewDateTimeColumn()
        ColtransDt.Name = "ColtransDt"
        ColtransDt.HeaderText = "Trans. Dt"
        ColtransDt.FieldName = "TransactionDt"
        ColtransDt.TextAlignment = ContentAlignment.MiddleRight
        ColtransDt.Width = 100
        ColtransDt.FormatString = "{0:dd/MM/yyyy}"
        ColtransDt.ReadOnly = True
        ColtransDt.AllowFiltering = True
        ObjGrdView.MasterTemplate.Columns.Add(ColtransDt)

        Dim ColOperationName As New GridViewTextBoxColumn()
        ColOperationName.Name = "ColOperationName"
        ColOperationName.HeaderText = "Operation Name"
        ColOperationName.FieldName = "OperationName"
        ColOperationName.TextAlignment = ContentAlignment.MiddleRight
        ColOperationName.Width = 120
        ColOperationName.ReadOnly = True
        ColOperationName.AllowFiltering = True
        ObjGrdView.MasterTemplate.Columns.Add(ColOperationName)

        Dim ColLotNo As New GridViewTextBoxColumn()
        ColLotNo.Name = "ColLotNo"
        ColLotNo.HeaderText = "Lot No."
        ColLotNo.FieldName = "LotNumber"
        ColLotNo.TextAlignment = ContentAlignment.MiddleRight
        ColLotNo.Width = 100
        ColLotNo.AllowFiltering = True
        ColLotNo.ReadOnly = True
        ObjGrdView.MasterTemplate.Columns.Add(ColLotNo)

        If cmbBagType.SelectedIndex = 0 Then
            Dim ColBhukaWt As New GridViewTextBoxColumn()
            ColBhukaWt.Name = "ColBhukaWt"
            ColBhukaWt.HeaderText = "Bhuka Wt."
            ColBhukaWt.FieldName = "BhukaWt"
            ColBhukaWt.TextAlignment = ContentAlignment.MiddleRight
            ColBhukaWt.Width = 100
            ColBhukaWt.FormatString = "{0: F2}"
            ColBhukaWt.ReadOnly = True
            ColBhukaWt.AllowFiltering = False
            ObjGrdView.MasterTemplate.Columns.Add(ColBhukaWt)
        End If

        If cmbBagType.SelectedIndex = 1 Then
            Dim ColSampleWt As New GridViewTextBoxColumn()
            ColSampleWt.Name = "ColSampleWt"
            ColSampleWt.HeaderText = "Sample Wt."
            ColSampleWt.FieldName = "SampleWt"
            ColSampleWt.TextAlignment = ContentAlignment.MiddleRight
            ColSampleWt.Width = 100
            ColSampleWt.FormatString = "{0: F2}"
            ColSampleWt.ReadOnly = True
            ColSampleWt.AllowFiltering = False
            ObjGrdView.MasterTemplate.Columns.Add(ColSampleWt)
        End If

        If cmbBagType.SelectedIndex = 2 Then
            Dim ColVacuumWt As New GridViewTextBoxColumn()
            ColVacuumWt.Name = "ColVacuumWt"
            ColVacuumWt.HeaderText = "Vacuum Wt."
            ColVacuumWt.FieldName = "VacuumWt"
            ColVacuumWt.TextAlignment = ContentAlignment.MiddleRight
            ColVacuumWt.Width = 100
            ColVacuumWt.FormatString = "{0: F2}"
            ColVacuumWt.ReadOnly = True
            ColVacuumWt.AllowFiltering = False
            ObjGrdView.MasterTemplate.Columns.Add(ColVacuumWt)
        End If

        Dim ColReceivePr As New GridViewTextBoxColumn()
        ColReceivePr.Name = "ColReceivePr"
        ColReceivePr.HeaderText = "Receive %"
        ColReceivePr.FieldName = "ReceivePr"
        ColReceivePr.TextAlignment = ContentAlignment.MiddleRight
        ColReceivePr.Width = 100
        ColReceivePr.FormatString = "{0: F2}"
        ColReceivePr.ReadOnly = True
        ColReceivePr.AllowFiltering = False
        ObjGrdView.MasterTemplate.Columns.Add(ColReceivePr)

        Dim ColFineWt As New GridViewTextBoxColumn()
        ColFineWt.Name = "ColFineWt"
        ColFineWt.HeaderText = "Fine Wt"
        ColFineWt.FieldName = "FineWt"
        ColFineWt.TextAlignment = ContentAlignment.MiddleRight
        ColFineWt.Width = 100
        ColFineWt.FormatString = "{0: F2}"
        ColFineWt.ReadOnly = True
        ColFineWt.AllowFiltering = False
        ObjGrdView.MasterTemplate.Columns.Add(ColFineWt)
    End Sub
    Private Sub cmbBagType_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) Handles cmbBagType.SelectedIndexChanged
        Me.SetupGridViewForTransaction(dgvTransStock)
        bindIssueGridViewTrans()
    End Sub
    Private Sub bindIssueGridViewTrans()
        Dim dtData As DataTable = New DataTable()

        Try
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            parameters.Add(dbManager.CreateParameter("@ActionType", "FetchLabIssuedDataByTrans", DbType.String))
            dtData = dbManager.GetDataTable("SP_LabData_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                dgvTransStock.DataSource = dtData
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub frmTransactionStockRpt_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Enter Then
                SendKeys.Send("{Tab}")
                SendKeys.Send("{HOME}+{END}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class