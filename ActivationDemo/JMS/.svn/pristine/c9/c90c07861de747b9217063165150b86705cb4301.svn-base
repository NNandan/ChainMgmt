Imports System.Configuration
Imports System.Data.SqlClient
Imports DataAccessHandler
Imports Telerik.WinControls.UI
Imports Telerik.WinControls.Data
Public Class frmMeltingRpt
    Dim dbManager As New SqlHelper(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Dim Objcn As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("ConString").ToString())
    Private Sub frmMeltingRpt_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.fillLotNo()
        'Me.SetupGridView()
    End Sub
    Private Sub fillLotNo()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchLotNoForReport", DbType.String))
        End With

        Dim dr = dbManager.GetDataReader("SP_Melting_Select", CommandType.StoredProcedure, parameters.ToArray(), Objcn)
        Dim dt As DataTable = New DataTable()

        dt.Load(dr)

        Try
            ''Insert the Default Item to DataTable.
            Dim row As DataRow = dt.NewRow()
            row(0) = 0
            row(1) = "---Select---"
            dt.Rows.InsertAt(row, 0)

            'Assign DataTable as DataSource.
            cmbLotNo.DataSource = dt
            cmbLotNo.DisplayMember = "LotNumber"
            cmbLotNo.ValueMember = "MeltingId"
            cmbLotNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            dr.Close()
            Objcn.Close()
        End Try
    End Sub
    Private Sub SetupGridView()

        ObjGrdView.AutoGenerateColumns = False
        ObjGrdView.EnableFiltering = False
        ObjGrdView.MasterTemplate.ShowHeaderCellButtons = True
        ObjGrdView.MasterTemplate.ShowFilteringRow = False
        ObjGrdView.CurrentRow = Nothing
        ObjGrdView.Columns.Clear()

        Dim ColtSrNo As GridViewTextBoxColumn = New GridViewTextBoxColumn("ColtSrNo")
        ColtSrNo.HeaderText = "Sr.No"
        ColtSrNo.TextAlignment = ContentAlignment.BottomRight
        ColtSrNo.Width = 25
        ObjGrdView.MasterTemplate.Columns.Add(ColtSrNo)

        Dim ColItemType As GridViewTextBoxColumn = New GridViewTextBoxColumn("ColItemType")
        ColItemType.HeaderText = "Item Type"
        ColItemType.FieldName = "ItemType"
        ColItemType.TextAlignment = ContentAlignment.MiddleLeft
        ColItemType.Width = 25
        Me.ObjGrdView.Columns.Add(ColItemType)

        Dim ColLotNo As GridViewTextBoxColumn = New GridViewTextBoxColumn("ColLotNo")
        ColLotNo.HeaderText = "Slip/Bag No"
        ColLotNo.FieldName = "SlipBagNo"
        Me.ObjGrdView.Columns.Add(ColLotNo)

        Dim ColItemName As GridViewTextBoxColumn = New GridViewTextBoxColumn("ColItemName")
        ColItemName.HeaderText = "ItemName"
        ColItemName.FieldName = "ItemName"
        Me.ObjGrdView.Columns.Add(ColItemName)

        Dim ColGrossWt As GridViewDecimalColumn = New GridViewDecimalColumn("ColGrossWt")
        ColGrossWt.HeaderText = "Gross Wt."
        ColGrossWt.FieldName = "GrossWt"
        ColGrossWt.DecimalPlaces = 2
        Me.ObjGrdView.Columns.Add(ColGrossWt)

        Dim ColGrossPr As GridViewDecimalColumn = New GridViewDecimalColumn("ColGrossPr")
        ColGrossPr.HeaderText = "Gross %"
        ColGrossPr.FieldName = "GrossPr"
        ColGrossPr.DecimalPlaces = 2
        ColGrossPr.FormatString = "{0:N2}"
        Me.ObjGrdView.Columns.Add(ColGrossPr)

        Dim ColFineWt As GridViewDecimalColumn = New GridViewDecimalColumn("ColFineTotal")
        ColFineWt.HeaderText = "Fine Total"
        ColFineWt.FieldName = "FineWt"
        ColFineWt.DecimalPlaces = 3
        ColFineWt.FormatString = "{0:N2}"
        Me.ObjGrdView.Columns.Add(ColFineWt)

        Dim totalNameItem As GridViewSummaryItem = New GridViewSummaryItem("ColItemName", "Total", GridAggregateFunction.Count)
        Dim totalItemGWt As GridViewSummaryItem = New GridViewSummaryItem("ColGrossWt", "{0}", GridAggregateFunction.Sum)
        Dim totalItemGFt As GridViewSummaryItem = New GridViewSummaryItem("ColFineWt", "{0}", GridAggregateFunction.Sum)

        Dim totalItemGPr As GridViewSummaryItem = New GridViewSummaryItem("ColGrossPr", "{0: 0.00}", GridAggregateFunction.None)
        totalItemGPr.AggregateExpression = "(Sum(colFineWt) / Sum(ColGrossWt)  * 100)"

        Dim totalRow As GridViewSummaryRowItem = New GridViewSummaryRowItem(New GridViewSummaryItem() {totalNameItem, totalItemGWt, totalItemGFt, totalItemGPr})
        Me.ObjGrdView.SummaryRowsBottom.Add(totalRow)

    End Sub

    Private Sub cmbLotNo_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbLotNo.SelectionChangeCommitted
        Dim dtData As DataTable = New DataTable()

        If cmbLotNo.SelectedIndex > 0 Then
            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                .Add(dbManager.CreateParameter("@ActionType", "FetchMeltingReport", DbType.String))
                .Add(dbManager.CreateParameter("@MId", cmbLotNo.SelectedValue, DbType.Int16))
            End With

            dtData = dbManager.GetDataTable("SP_Melting_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then

                ObjGrdView.DataSource = dtData
            Else
                MessageBox.Show("No Data to Print")
            End If

        End If
    End Sub

    Private Sub fillHeaderFromListView(ByVal intMeltingId As Integer)

        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()

        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchHeaderRecord", DbType.String))
            .Add(dbManager.CreateParameter("@MId", CInt(intMeltingId), DbType.Int16))
        End With

        Dim dr As SqlDataReader = dbManager.GetDataReader("SP_Melting_Select", CommandType.StoredProcedure, Objcn, parameters.ToArray())

        If dr.HasRows = False Then
            Exit Sub
        Else
            dr.Read()
            'TransDt.Text = dr.Item("MeltingDt").ToString
            'cmbItem.SelectedIndex = dr.Item("ItemId").ToString
            'txtRequirePr.Text = dr.Item("RequirePr").ToString()
            'lblAlloyTotal.Text = dr.Item("GrossWt").ToString
            'txtFrKarigar.Tag = dr.Item("FrKarigarId").ToString
            'txtFrKarigar.Text = dr.Item("FrKarigar").ToString
            'cmbTLabour.SelectedIndex = dr.Item("ToKarigarId").ToString
        End If

        dr.Close()
        Objcn.Close()

        Exit Sub
ErrHandler:
        MsgBox(Err.Description, MsgBoxStyle.Critical)
    End Sub
    Private Sub ObjGrdView_CellValueChanged(sender As Object, e As GridViewCellEventArgs) Handles ObjGrdView.CellValueChanged
        Me.ObjGrdView.MasterView.SummaryRows(0).InvalidateRow()
    End Sub
End Class