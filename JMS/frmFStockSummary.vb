Imports System.Data.SqlClient
Imports DataAccessHandler
Public Class frmFStockSummary
    Dim strSQL As String = Nothing
    Dim iRowCnt As Integer = 0
    Dim dbManager As New SqlHelper()
    Dim Objcn As SqlConnection = New SqlConnection()
    Private Sub frmStockSummaryRuntime_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Me.ExpandCollaps()
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.GetWIPLots()
            Me.GetVacuumBagNotCreated()
            Me.GetScrapBagCreated()
            Me.GetVacuumBagCreated()
            Me.GetScrapBagNotUpdated()
            Me.GetVaccumeBagNotUpdated()
            Me.GetScrapBagNotUsed()
            Me.GetVaccumBagNotUsed()
            Me.GetVoucherMetalUnused()
            Me.GetLessMetalIssued()
            Me.GetMeltingStockAddition()
            Me.GetVoucherStockAddition()
            Me.GetIssueStockAddition()
            Me.GetMeltingStockRemoval()
            Me.GetVoucherStockRemoval()
            Me.GetIssueStockRemoval()
            Me.GetLossBag()
            Me.GetLossTransaction()
            Me.GetMetalReceipt()

            txtOpeningStockWt.Text = Format(OpGrossWt, "0.00")

            If Val(OpGrossPr) > 0 Then
                txtOpeningStockPr.Text = Format(OpGrossPr, "0.00")
            Else
                txtOpeningStockPr.Text = Format(0, "0.00")
            End If

            txtOpeningStockFw.Text = Format(OpGrossFw, "0.00")
            AddTotStockPr.Text = "0.00"
            RemovalTotStockPr.Text = "0.00"
            Me.TotalBagsNotReceive()
            Me.TotalBagsNotUpdated()
            Me.TotalBagsNotUsed()
            Me.TotalBagsLoss()
            Me.TotalSummary()
            Me.StockAddition()
            Me.StockSubtraction()

            lblGrossWt.Text = Format(0, "0.00")
            lblGrossFw.Text = Format(0, "0.00")
            lblGrossPr.Text = Format(0, "0.00")

            lblGrossWt.Text = Format((CDbl(WipLGrossWt.Text) + CDbl(VoucherMetalWt.Text) + CDbl(VacuumBagNCWt.Text) + CDbl(txtScrapVaccumeWt.Text) + CDbl(BNUTotalWt.Text) + CDbl(txtNUScrapVaccumeWt.Text) + CDbl(txtLScrapVaccumeWt.Text)), "0.00")
            lblGrossFw.Text = Format((CDbl(WipLGrossFw.Text) + CDbl(VoucherMetalFw.Text) + CDbl(VacuumBagNCFw.Text) + CDbl(txtScrapVaccumeFWt.Text) + CDbl(BNUTotalFWt.Text) + CDbl(txtNUScrapVaccumeFWt.Text) + CDbl(txtLScrapVaccumeFWt.Text)), "0.00")
            lblGrossPr.Text = Format((CDbl(lblGrossFw.Text) / CDbl(lblGrossWt.Text) * 100), "0.00")

            If (lblGrossPr.Text = "NaN") Then
                lblGrossPr.Text = "0.00"
            End If

            Me.ClearTotalByCategory()
            Me.TotalStockByCategory()
            lblTotalGrossByCategory.Text = "0.00"
            lblTotalFWtByCategory.Text = "0.00"
            lblTotalPrByCategory.Text = "0.00"

            lblTotalGrossByCategory.Text = Format(((txtWIPGrossWt.Text) + (txtVMUGrossWt.Text) + (txtBNCGrossWt.Text) + (txtSBNRGrossWt.Text) + (txtVBNRGrossWt.Text) + (txtSBNUGrossWt.Text) + (txtVBNUpdGrossWt.Text) + (txtSBNUsedGrossWt.Text) + (txtVBNUsedGrossWt.Text) + (txtSIHGrossWt.Text)), "0.00")
            lblTotalFWtByCategory.Text = Format(((txtWIPFWt.Text) + (txtVMUFWt.Text) + (txtBNCFWt.Text) + (txtSBNRFWt.Text) + (txtVBNRFWt.Text) + (txtSBNUpdFWt.Text) + (txtVBNUpdtFWt.Text) + (txtSBNUsedFWt.Text) + (txtVBNUsedFWt.Text) + (txtSIHFWt.Text)), "0.00")
            lblTotalPrByCategory.Text = Format((CDbl(lblTotalFWtByCategory.Text) / CDbl(lblTotalGrossByCategory.Text) * 100), "0.00")

            If lblTotalPrByCategory.Text = "NaN" Then
                lblTotalPrByCategory.Text = "0.00"
            End If

            Me.TotalDiff()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub TotalDiff()
        lblTotalDiffCatgr.Text = Format((CDbl(txtWIPDiff.Text) + CDbl(txtVMUDiff.Text) + CDbl(txtBNCDiff.Text) + CDbl(txtSBNRDiff.Text) + CDbl(txtVBNRDiff.Text) + CDbl(txtSBNUPDTDiff.Text) + CDbl(txtVBNUPDTDiff.Text) + CDbl(txtSBNUSEDDiff.Text) + CDbl(txtVBNUSEDDiff.Text) + CDbl(txtSIHDiff.Text)), "0.00")
    End Sub
    Private Sub ClearTotalByCategory()
        txtWIPGrossWt.Text = "0.00"
        txtWIPPr.Text = "0.00"
        txtWIPFWt.Text = "0.00"
        txtWIPDiff.Text = "0.00"

        txtVMUGrossWt.Text = "0.00"
        txtVMUPr.Text = "0.00"
        txtVMUFWt.Text = "0.00"
        txtVMUDiff.Text = "0.00"

        txtBNCGrossWt.Text = "0.00"
        txtBNCPr.Text = "0.00"
        txtBNCFWt.Text = "0.00"
        txtBNCDiff.Text = "0.00"

        txtSBNRGrossWt.Text = "0.00"
        txtSBNRPr.Text = "0.00"
        txtSBNRFWt.Text = "0.00"
        txtSBNRDiff.Text = "0.00"

        txtVBNRGrossWt.Text = "0.00"
        txtVBNRPr.Text = "0.00"
        txtVBNRFWt.Text = "0.00"
        txtVBNRDiff.Text = "0.00"

        txtSBNUGrossWt.Text = "0.00"
        txtSBNUpdPr.Text = "0.00"
        txtSBNUpdFWt.Text = "0.00"
        txtSBNUPDTDiff.Text = "0.00"

        txtVBNUpdGrossWt.Text = "0.00"
        txtVBNUpdtPr.Text = "0.00"
        txtVBNUpdtFWt.Text = "0.00"
        txtVBNUPDTDiff.Text = "0.00"

        txtSBNUsedGrossWt.Text = "0.00"
        txtSBNUsedPr.Text = "0.00"
        txtSBNUsedFWt.Text = "0.00"
        txtSBNUSEDDiff.Text = "0.00"

        txtVBNUsedGrossWt.Text = "0.00"
        txtVBNUsedPr.Text = "0.00"
        txtVBNUsedFWt.Text = "0.00"
        txtVBNUSEDDiff.Text = "0.00"

        txtSIHGrossWt.Text = "0.00"
        txtSIHPr.Text = "0.00"
        txtSIHFWt.Text = "0.00"
        txtSIHDiff.Text = "0.00"
    End Sub

    Private Sub TotalStockByCategory()
        Dim dtData As New DataTable
        Dim StockCategoryId1 As Integer = 1
        If StockCategoryId1 = 1 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId1)
            If dtData.Rows.Count > 0 Then
                txtWIPGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtWIPPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtWIPFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtWIPDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId2 As Integer = 2
        If StockCategoryId2 = 2 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId2)
            If dtData.Rows.Count > 0 Then
                txtVMUGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtVMUPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtVMUFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtVMUDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId3 As Integer = 3
        If StockCategoryId3 = 3 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId3)
            If dtData.Rows.Count > 0 Then
                txtBNCGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtBNCPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtBNCFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtBNCDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId4 As Integer = 4
        If StockCategoryId4 = 4 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId4)
            If dtData.Rows.Count > 0 Then
                txtSBNRGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSBNRPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSBNRFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSBNRDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId5 As Integer = 5
        If StockCategoryId5 = 5 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId5)
            If dtData.Rows.Count > 0 Then
                txtVBNRGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtVBNRPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtVBNRFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtVBNRDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId6 As Integer = 6
        If StockCategoryId6 = 6 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId6)
            If dtData.Rows.Count > 0 Then
                txtSBNUGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSBNUpdPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSBNUpdFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSBNUPDTDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId7 As Integer = 7
        If StockCategoryId7 = 7 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId7)
            If dtData.Rows.Count > 0 Then
                txtVBNUpdGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtVBNUpdtPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtVBNUpdtFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtVBNUPDTDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId8 As Integer = 8
        If StockCategoryId8 = 8 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId8)
            If dtData.Rows.Count > 0 Then
                txtSBNUsedGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSBNUsedPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSBNUsedFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSBNUSEDDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId9 As Integer = 9
        If StockCategoryId9 = 9 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId9)
            If dtData.Rows.Count > 0 Then
                txtVBNUsedGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtVBNUsedPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtVBNUsedFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtVBNUSEDDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId10 As Integer = 10
        If StockCategoryId10 = 10 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId10)
            If dtData.Rows.Count > 0 Then
                txtSIHGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSIHPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSIHFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSIHDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
    End Sub
    Private Function TotalCalculateStockByCategoryId(ByVal stockCategoryId As Integer) As DataTable
        Dim dtData As DataTable = New DataTable()
        Dim parameters = New List(Of SqlParameter)()
        parameters.Clear()
        With parameters
            .Add(dbManager.CreateParameter("@ActionType", "FetchTotalStockByScale", DbType.String))
            .Add(dbManager.CreateParameter("@StockCategoryId", stockCategoryId, DbType.Int16))
        End With
        dtData = dbManager.GetDataTable("SP_fDailyStock_Select", CommandType.StoredProcedure, parameters.ToArray())
        Return dtData
    End Function
    Private Sub TotalBagsNotReceive()
        txtScrapVaccumeWt.Text = Format(CDbl(Convert.ToDouble((BhukaBagCWt.Text) + Convert.ToDouble(VacuumBagWt.Text))), "0.00")
        txtScrapVaccumeFWt.Text = Format(CDbl(Convert.ToDouble((BhukaBagCFw.Text) + Convert.ToDouble(VacuumBagFw.Text))), "0.00")
        txtScrapVaccumePerc.Text = Format(CDbl(Convert.ToDouble((txtScrapVaccumeFWt.Text) / Convert.ToDouble(txtScrapVaccumeWt.Text) * 100)), "0.00")
        If txtScrapVaccumePerc.Text = "NaN" Then
            txtScrapVaccumePerc.Text = "0.00"
        End If
    End Sub
    Private Sub TotalBagsNotUpdated()
        BNUTotalWt.Text = Format(CDbl(Convert.ToDouble((txtSBNUWt.Text) + Convert.ToDouble(txtVBNUWt.Text))), "0.00")
        BNUTotalFWt.Text = Format(CDbl(Convert.ToDouble((txtSBNUFWt.Text) + Convert.ToDouble(txtVBNUFWt.Text))), "0.00")
        BNUTotalPr.Text = Format(CDbl(Convert.ToDouble((BNUTotalFWt.Text) / Convert.ToDouble(BNUTotalWt.Text) * 100)), "0.00")
        If BNUTotalPr.Text = "NaN" Then
            BNUTotalPr.Text = "0.00"
        End If
    End Sub
    Private Sub TotalBagsNotUsed()
        txtNUScrapVaccumeWt.Text = Format(CDbl(Convert.ToDouble((BhukaBagUWt.Text) + Convert.ToDouble(VacuumBagUWt.Text))), "0.00")
        txtNUScrapVaccumeFWt.Text = Format(CDbl(Convert.ToDouble((BhukaBagUFw.Text) + Convert.ToDouble(VacuumBagUFw.Text))), "0.00")
        txtNUScrapVaccumePerc.Text = Format(CDbl(Convert.ToDouble((txtNUScrapVaccumeFWt.Text) / Convert.ToDouble(txtNUScrapVaccumeWt.Text) * 100)), "0.00")
        If txtNUScrapVaccumePerc.Text = "NaN" Then
            txtNUScrapVaccumePerc.Text = "0.00"
        End If
    End Sub
    Private Sub TotalBagsLoss()
        txtLScrapVaccumeWt.Text = Format(CDbl(Convert.ToDouble((LossBagsWt.Text) + Convert.ToDouble(LossTransWt.Text))), "0.00")
        txtLScrapVaccumeFWt.Text = Format(CDbl(Convert.ToDouble((LossBagsFw.Text) + Convert.ToDouble(LossTransFw.Text))), "0.00")
        txtLScrapVaccumePerc.Text = Format(CDbl(Convert.ToDouble((txtLScrapVaccumeFWt.Text) / Convert.ToDouble(txtLScrapVaccumeWt.Text) * 100)), "0.00")
        If txtLScrapVaccumePerc.Text = "NaN" Then
            txtLScrapVaccumePerc.Text = "0.00"
        End If
    End Sub
    Private Sub TotalSummary()
        SumWt.Text = Format(CDbl(Convert.ToDouble((txtOpeningStockWt.Text) + Convert.ToDouble(ReceiptGrossWt.Text) + Convert.ToDouble(IssueGrossWt.Text))), "0.00")
        SumFW.Text = Format(CDbl(Convert.ToDouble((txtOpeningStockFw.Text) + Convert.ToDouble(ReceiptGrossFw.Text) + Convert.ToDouble(IssueGrossFw.Text))), "0.00")
        SumPr.Text = Format(CDbl(Convert.ToDouble((SumFW.Text) / Convert.ToDouble(SumWt.Text) * 100)), "0.00")
        If SumPr.Text = "NaN" Then
            SumPr.Text = "0.00"
        End If

    End Sub
    Private Sub StockAddition()
        AddTotStockWt.Text = Format(CDbl(Convert.ToDouble((AddMStockWt.Text) + Convert.ToDouble(AddVStockWt.Text) + Convert.ToDouble(AddIStockWt.Text))), "0.00")
        AddTotStockFw.Text = Format(CDbl(Convert.ToDouble((AddMStockFw.Text) + Convert.ToDouble(AddVStockFw.Text) + Convert.ToDouble(AddIStockFw.Text))), "0.00")
        AddTotStockPr.Text = Format(CDbl(Convert.ToDouble((AddTotStockFw.Text) / Convert.ToDouble(AddTotStockWt.Text) * 100)), "0.00")
        If AddTotStockPr.Text = "NaN" Then
            AddTotStockPr.Text = "0.00"
        End If
    End Sub
    Private Sub StockSubtraction()
        RemovalTotStockWt.Text = Format(CDbl(Convert.ToDouble((RemovalMStockWt.Text) + Convert.ToDouble(RemovalVStockWt.Text) + Convert.ToDouble(RemovalIStockWt.Text))), "0.00")
        RemovalTotStockFw.Text = Format(CDbl(Convert.ToDouble((RemovalMStockFw.Text) + Convert.ToDouble(RemovalVStockFw.Text) + Convert.ToDouble(RemovalIStockFw.Text))), "0.00")
        RemovalTotStockPr.Text = Format(CDbl(Convert.ToDouble((RemovalTotStockFw.Text) / Convert.ToDouble(RemovalTotStockWt.Text) * 100)), "0.00")
        If RemovalTotStockPr.Text = "NaN" Then
            RemovalTotStockPr.Text = "0.00"
        End If
    End Sub

    Private Sub ExpandCollaps()
        colpsSummary.IsExpanded = True
        colpsStockAddition.IsExpanded = True
        colpsStockSubtraction.IsExpanded = True
        colpsBagsCreate.IsExpanded = False
        colpsBagNotUsed.IsExpanded = False
        colpsLoss.IsExpanded = False
        colpsBagNotUpdate.IsExpanded = False
    End Sub
    Private Sub CreateGroupBoxForWIPLots()
        Dim groupBox1 As GroupBox = New GroupBox()
        groupBox1.SetBounds(460, 5, 320, 120)
        groupBox1.Text = "WIP (Work In Process)"
        Me.Controls.Add(groupBox1)

        Dim lblWipLots As New Label
        lblWipLots.Name = "lblWipLots"
        lblWipLots.Text = "Wip Lots"
        lblWipLots.AutoSize = True
        lblWipLots.Location = New Point(65, 26)
        groupBox1.Controls.Add(lblWipLots)

        Dim WipLGrossWt As New TextBox
        WipLGrossWt.Name = "WipLGrossWt"
        WipLGrossWt.Size = New Size(55, 20)
        WipLGrossWt.Location = New Point(121, 22)
        groupBox1.Controls.Add(WipLGrossWt)

        Dim WipLGrossPr As New TextBox
        WipLGrossPr.Name = "WipLGrossPr"
        WipLGrossPr.Size = New Size(55, 20)
        WipLGrossPr.Location = New Point(178, 22)
        groupBox1.Controls.Add(WipLGrossPr)

        Dim WipLGrossFw As New TextBox
        WipLGrossFw.Name = "WipLGrossFw"
        WipLGrossFw.Size = New Size(55, 20)
        WipLGrossFw.Location = New Point(235, 22)
        groupBox1.Controls.Add(WipLGrossFw)

        Dim lblWipMelting As New Label
        lblWipMelting.Name = "WIPMelting"
        lblWipMelting.Text = "WIP Melting"
        lblWipMelting.AutoSize = True
        lblWipMelting.Location = New Point(45, 46)
        groupBox1.Controls.Add(lblWipMelting)

        Dim WipMGrossWt As New TextBox
        WipMGrossWt.Name = "WipMGrossWt"
        WipMGrossWt.Size = New Size(55, 20)
        WipMGrossWt.Location = New Point(121, 43)
        groupBox1.Controls.Add(WipMGrossWt)

        Dim WipMGrossPr As New TextBox
        WipMGrossPr.Name = "WipMGrossPr"
        WipMGrossPr.Size = New Size(55, 20)
        WipMGrossPr.Location = New Point(178, 43)
        groupBox1.Controls.Add(WipMGrossPr)

        Dim WipMGrossFine As New TextBox
        WipMGrossFine.Name = "WipMGrossFine"
        WipMGrossFine.Size = New Size(55, 20)
        WipMGrossFine.Location = New Point(235, 43)
        groupBox1.Controls.Add(WipMGrossFine)

        Dim lblWipLotTransferred As New Label
        lblWipLotTransferred.Name = "lblWipLotTransferred"
        lblWipLotTransferred.Text = "WIP Lots Transferred"
        lblWipLotTransferred.AutoSize = True
        lblWipLotTransferred.Location = New Point(7, 68)
        groupBox1.Controls.Add(lblWipLotTransferred)

    End Sub
    Private Sub GetWIPLots()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "WIPLotsGoldDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("BalanceWt")) Then
                            sRWtTotal += Single.Parse(row("BalanceWt"))
                        End If

                        'sRPrTotal = Single.Parse(row("ReceivePr"))
                        If sRWtTotal = 0 Then
                            sFWtTotal = 0
                        Else
                            If Not IsDBNull(row("FineWt")) Then
                                sFWtTotal += Single.Parse(row("FineWt"))
                            End If
                        End If
                    End If
                Next
            End If
            If Not sFWtTotal = 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If
            WipLGrossWt.Text = Format(sRWtTotal, "0.00")
            WipLGrossPr.Text = Format(sRPrTotal, "0.00")
            WipLGrossFw.Text = Format(sFWtTotal, "0.00")
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetMeltingStockAddition()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchStockAdditionMelting", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockAdditionReport_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("StockAddGross")) Then
                        sRWtTotal += Single.Parse(row("StockAddGross"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("StockAddFine")) Then
                        sFWtTotal += Single.Parse(row("StockAddFine"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            AddMStockWt.Text = Format(sRWtTotal, "0.00")
            AddMStockPr.Text = Format(sRPrTotal, "0.00")
            AddMStockFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVoucherStockAddition()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchStockAdditionVoucher", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockAdditionReport_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("StockAddGross")) Then
                        sRWtTotal += Single.Parse(row("StockAddGross"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("StockAddFine")) Then
                        sFWtTotal += Single.Parse(row("StockAddFine"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            AddVStockWt.Text = Format(sRWtTotal, "0.00")
            AddVStockPr.Text = Format(sRPrTotal, "0.00")
            AddVStockFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetIssueStockAddition()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchStockAdditionIssueReceive", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockAdditionReport_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("StockAddGross")) Then
                        sRWtTotal += Single.Parse(row("StockAddGross"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("StockAddFine")) Then
                        sFWtTotal += Single.Parse(row("StockAddFine"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            AddIStockWt.Text = Format(sRWtTotal, "0.00")
            AddIStockPr.Text = Format(sRPrTotal, "0.00")
            AddIStockFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetMeltingStockRemoval()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchStockSubtractionMelting", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockAdditionReport_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("StockAddGross")) Then
                        sRWtTotal += Single.Parse(row("StockAddGross"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("StockAddFine")) Then
                        sFWtTotal += Single.Parse(row("StockAddFine"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            RemovalMStockWt.Text = Format(sRWtTotal, "0.00")
            RemovalMStockPr.Text = Format(sRPrTotal, "0.00")
            RemovalMStockFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVoucherStockRemoval()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchStockSubtractionVoucher", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockAdditionReport_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("StockAddGross")) Then
                        sRWtTotal += Single.Parse(row("StockAddGross"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("StockAddFine")) Then
                        sFWtTotal += Single.Parse(row("StockAddFine"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            RemovalVStockWt.Text = Format(sRWtTotal, "0.00")
            RemovalVStockPr.Text = Format(sRPrTotal, "0.00")
            RemovalVStockFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetIssueStockRemoval()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchStockSubtractionIssueReceive", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockAdditionReport_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("StockAddGross")) Then
                        sRWtTotal += Single.Parse(row("StockAddGross"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("StockAddFine")) Then
                        sFWtTotal += Single.Parse(row("StockAddFine"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            RemovalIStockWt.Text = Format(sRWtTotal, "0.00")
            RemovalIStockPr.Text = Format(sRPrTotal, "0.00")
            RemovalIStockFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetBhukaBagNotCreated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "BhukaBagNotCreatedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If Not sFWtTotal = 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            'BhukaBagNCWt.Text = Format(sRWtTotal, "0.00")
            'BhukaBagNCPr.Text = Format(sRPrTotal, "0.00")
            'BhukaBagNCFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error: - " & ex.Message)
        End Try
    End Sub
    Private Sub GetVacuumBagNotCreated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VacuumBagNotCreatedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("VaccumeWt")) Then
                        sRWtTotal += Single.Parse(row("VaccumeWt"))
                    End If

                    'If Not IsDBNull(dtData.Rows(0)("ReceivePr")) Then
                    '    sRPrTotal += Single.Parse(row("ReceivePr"))
                    'End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            VacuumBagNCWt.Text = Format(sRWtTotal, "0.00")
            VacuumBagNCPr.Text = Format(sRPrTotal, "0.00")
            VacuumBagNCFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetScrapBagCreated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "ScrapBagCreatedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            BhukaBagCWt.Text = Format(sRWtTotal, "0.00")
            BhukaBagCPr.Text = Format(sRPrTotal, "0.00")
            BhukaBagCFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetScrapBagNotUpdated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "ScrapBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            txtSBNUWt.Text = Format(sRWtTotal, "0.00")
            txtSBNUPr.Text = Format(sRPrTotal, "0.00")
            txtSBNUFWt.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVaccumeBagNotUpdated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumeBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            txtVBNUWt.Text = Format(sRWtTotal, "0.00")
            txtBNUPr.Text = Format(sRPrTotal, "0.00")
            txtVBNUFWt.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVacuumBagCreated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumBagCreatedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            VacuumBagWt.Text = Format(sRWtTotal, "0.00")
            VacuumBagPr.Text = Format(sRPrTotal, "0.00")
            VacuumBagFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetScrapBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "ScrapBagsNotUsedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            BhukaBagUWt.Text = Format(sRWtTotal, "0.00")
            BhukaBagUPr.Text = Format(sRPrTotal, "0.00")
            BhukaBagUFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVaccumBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VacuumBagsNotUsedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            VacuumBagUWt.Text = Format(sRWtTotal, "0.00")
            VacuumBagUPr.Text = Format(sRPrTotal, "0.00")
            VacuumBagUFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetSampleBagCreated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SampleBagCreatedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetBhukaBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sBRWtTotal As Single = 0
        Dim sBRPrTotal As Single = 0
        Dim sBFWtTotal As Single = 0

        Dim sSRWtTotal As Single = 0
        Dim sSRPrTotal As Single = 0
        Dim sSFWtTotal As Single = 0

        Dim sLRWtTotal As Single = 0
        Dim sLRPrTotal As Single = 0
        Dim sLFWtTotal As Single = 0

        Dim sVRWtTotal As Single = 0
        Dim sVRPrTotal As Single = 0
        Dim sVFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "BagsNotUsedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            Dim dataView As DataView = dtData.DefaultView

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows

                    ''For Bhuka Bags
                    If row("ItemType").ToString() = 1 Then
                        If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                            sBRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sBFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If

                    ''For Sample Bags
                    If row("ItemType").ToString() = 2 Then
                        If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                            sSRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sSFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If

                    ''For Lotfail Bags
                    If row("ItemType").ToString() = 3 Then
                        If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                            sLRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sLFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If

                    ''For Vaccum Bags
                    If row("ItemType").ToString() = 4 Then
                        If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                            sVRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sVFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next
            End If

            ''Bhuka Wt
            If sBFWtTotal > 0 Then
                sBRPrTotal = Format((Val(sBFWtTotal) / Val(sBRWtTotal)) * 100, "0.00")
            End If

            ''Sample Wt
            If sSFWtTotal > 0 Then
                sSRPrTotal = Format((Val(sSFWtTotal) / Val(sSRWtTotal)) * 100, "0.00")
            End If

            ''LotFail Wt
            If sLFWtTotal > 0 Then
                sLRPrTotal = Format((Val(sLFWtTotal) / Val(sLRWtTotal)) * 100, "0.00")
            End If

            ''Vaccum Wt
            If sVFWtTotal > 0 Then
                sVRPrTotal = Format((Val(sVFWtTotal) / Val(sVRWtTotal)) * 100, "0.00")
            End If

            ''Bhuka Wt
            BhukaBagUWt.Text = Format(sBRWtTotal, "0.00")
            BhukaBagUPr.Text = Format(sBRPrTotal, "0.00")
            BhukaBagUFw.Text = Format(sBFWtTotal, "0.00")

            ''Sample Wt
            'SampleBagUWt.Text = Format(sSRWtTotal, "0.00")
            'SampleBagUPr.Text = Format(sSRPrTotal, "0.00")
            'SampleBagUFw.Text = Format(sSFWtTotal, "0.00")

            ''LotFail Wt
            'LotFailBagUWt.Text = Format(sLRWtTotal, "0.00")
            'LotFailBagUPr.Text = Format(sLRPrTotal, "0.00")
            'LotFailBagUFw.Text = Format(sLFWtTotal, "0.00")

            ''vacuum Wt
            VacuumBagUWt.Text = Format(sVRWtTotal, "0.00")
            VacuumBagUPr.Text = Format(sVRPrTotal, "0.00")
            VacuumBagUFw.Text = Format(sVFWtTotal, "0.00")
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLossLab()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LossLabsDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    'If Not IsDBNull(dtData.Rows(0)("ReceivePr")) Then
                    '    sRPrTotal += Single.Parse(row("ReceivePr"))
                    'End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            'LabReceiveWt.Text = Format(sRWtTotal, "0.00")
            'LabReceivePr.Text = Format(sRPrTotal, "0.00")
            'LabReceiveFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetMetalReceipt()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LossDeptReceiptDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    'If Not IsDBNull(dtData.Rows(0)("ReceivePr")) Then
                    '    sRPrTotal += Single.Parse(row("ReceivePr"))
                    'End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            ReceiptGrossWt.Text = Format(sRWtTotal, "0.00")
            ReceiptGrossPr.Text = Format(sRPrTotal, "0.00")
            ReceiptGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVoucherMetalUnused()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VoucherMetalUnusedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("BalanceWt")) Then
                        sRWtTotal += Single.Parse(row("BalanceWt"))
                    End If


                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            VoucherMetalWt.Text = Format(sRWtTotal, "0.00")
            VoucherMetalPr.Text = Format(sRPrTotal, "0.00")
            VoucherMetalFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLossBag()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LossBagsDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("GrossWt")) Then
                        sRWtTotal += Single.Parse(row("GrossWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            LossBagsWt.Text = Format(sRWtTotal, "0.00")
            LossBagsPr.Text = Format(sRPrTotal, "0.00")
            LossBagsFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLossTransaction()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LossTransactionDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            LossTransWt.Text = Format(sRWtTotal, "0.00")
            LossTransPr.Text = Format(sRPrTotal, "0.00")
            LossTransFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLessMetalIssued()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FetchTouchConversionData", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_fIssue_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("IssueWt")) Then
                        sRWtTotal += Single.Parse(row("IssueWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            End If

            IssueGrossWt.Text = Format(sRWtTotal, "0.00")
            IssueGrossPr.Text = Format(sRPrTotal, "0.00")
            IssueGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnVBagNotCreated_Click(sender As Object, e As EventArgs) Handles btnVBagNotCreated.Click
        Dim ObjVaccumBagNotCreated As New frmStockVaccumBagNotCreated
        ObjVaccumBagNotCreated.ShowDialog()
    End Sub
    Private Sub btnBBagCreated_Click(sender As Object, e As EventArgs) Handles btnBBagCreated.Click
        Dim ObjStockBhukaBagCreated As New frmStockBhukaBagCreated
        ObjStockBhukaBagCreated.ShowDialog()
    End Sub
    Private Sub frmStockSummary_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.Escape) Then   'for Exit
                If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then Me.Close()
            ElseIf e.KeyCode = Keys.Tab Then
                SendKeys.Send("{Tab}")
                SendKeys.Send("{HOME}+{END}")
            ElseIf e.KeyCode = Keys.OemQuotes Or e.KeyCode = Keys.OemPipe Then
                e.SuppressKeyPress = True
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Function GetValue(ByVal text As String) As Double
        If String.IsNullOrEmpty(text) Then Return 0
        Dim value As Double
        If Double.TryParse(text, value) Then Return value
        Return 0
    End Function
    Private Sub btnShow_Click(sender As Object, e As EventArgs)
        Dim dfinalWt As Double = 0
        Dim dFinalFw As Double = 0

        Double.TryParse(lblClosingStockWt.Text, dfinalWt)

        Double.TryParse(lblClosingStockFw.Text, dFinalFw)

        If dfinalWt > 0 And dFinalFw > 0 Then
            'lblDiffFw.Text = Val(txtClosingStockFw.Text - lblGrossFw.Text)
        End If
    End Sub
    Private Sub btnVBagCreated_Click(sender As Object, e As EventArgs) Handles btnVBagCreated.Click
        Dim ObjVacuumBagCreated As New frmStockVacuumBagCreated
        ObjVacuumBagCreated.ShowDialog()
    End Sub
    Private Sub btnStockAddition_Click(sender As Object, e As EventArgs)
        Dim ObjStockAdditionReport As New frmFStockAdditionMReport
        ObjStockAdditionReport.ShowDialog()
    End Sub
    Private Sub btnStockRemoval_Click(sender As Object, e As EventArgs)
        Dim ObjStockRemovalReport As New frmFStockSubtractionMSReport
        ObjStockRemovalReport.ShowDialog()
    End Sub
    Private Sub btnLossTransaction_Click(sender As Object, e As EventArgs) Handles btnLossTransaction.Click
        Dim ObjLossTransaction As New frmStockLossTransaction
        ObjLossTransaction.ShowDialog()
    End Sub
    Private Sub btnBBagNotUsed_Click(sender As Object, e As EventArgs) Handles btnBBagNotUsed.Click
        Dim ObjStockScrapBagNotUsed As New frmFBalancePendingBags
        ObjStockScrapBagNotUsed.ShowDialog()
    End Sub
    Private Sub btnVBagNotUsed_Click(sender As Object, e As EventArgs) Handles btnVBagNotUsed.Click
        Dim ObjStockVacuumBagNotUsed As New frmFStockVacuumBagNotUsed
        ObjStockVacuumBagNotUsed.ShowDialog()
    End Sub
    Private Sub btnDeptReceive_Click(sender As Object, e As EventArgs)
        Dim ObjStockLossMetalReceived As New frmStockLossMetalReceived
        ObjStockLossMetalReceived.ShowDialog()
    End Sub
    Private Sub btnVoucherMetalUnused_Click(sender As Object, e As EventArgs) Handles btnVoucherMetalUnused.Click
        Dim ObjStockMetalUnused As New frmStockMetalUnused
        ObjStockMetalUnused.ShowDialog()
    End Sub
    Private Sub btnLossBags_Click(sender As Object, e As EventArgs) Handles btnLossBags.Click
        Dim ObjStockLossBags As New frmStockLossBags
        ObjStockLossBags.ShowDialog()
    End Sub
    Private Sub btnVStockAddition_Click(sender As Object, e As EventArgs)
        Dim ObjStockAdditionReport As New frmFStockAdditionVReport
        ObjStockAdditionReport.ShowDialog()
    End Sub
    Private Sub btnIStockAddition_Click(sender As Object, e As EventArgs)
        Dim ObjStockAdditionReport As New frmFStockAdditionIReport
        ObjStockAdditionReport.ShowDialog()
    End Sub
    Private Sub btnVStockRemoval_Click(sender As Object, e As EventArgs)
        Dim ObjStockRemovalReport As New frmFStockSubtractionVSReport
        ObjStockRemovalReport.ShowDialog()
    End Sub
    Private Sub btnIStockRemoval_Click(sender As Object, e As EventArgs)
        Dim ObjStockRemovalReport As New frmFStockSubtractionISReport
        ObjStockRemovalReport.ShowDialog()
    End Sub
    Private Sub btnDeptIssue_Click(sender As Object, e As EventArgs)
        Dim ObjLessMetalIssued As New frmFInterDeptIssueRpt
        ObjLessMetalIssued.ShowDialog()
    End Sub
    Private Sub AddMStockWt_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(AddMStockWt.Text) OrElse String.IsNullOrEmpty(AddVStockWt.Text) OrElse String.IsNullOrEmpty(AddIStockWt.Text) Then Exit Sub
        If Not IsNumeric(AddMStockWt.Text) OrElse Not IsNumeric(AddVStockWt.Text) OrElse Not IsNumeric(AddIStockWt.Text) Then Exit Sub

        AddTotStockWt.Text = CDbl(AddMStockWt.Text) + CDbl(AddVStockWt.Text) + CDbl(AddIStockWt.Text)
    End Sub
    Private Sub AddVStockWt_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(AddMStockWt.Text) OrElse String.IsNullOrEmpty(AddVStockWt.Text) OrElse String.IsNullOrEmpty(AddIStockWt.Text) Then Exit Sub
        If Not IsNumeric(AddMStockWt.Text) OrElse Not IsNumeric(AddVStockWt.Text) OrElse Not IsNumeric(AddIStockWt.Text) Then Exit Sub

        AddTotStockWt.Text = CDbl(AddMStockWt.Text) + CDbl(AddVStockWt.Text) + CDbl(AddIStockWt.Text)
    End Sub
    Private Sub AddIStockWt_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(AddMStockWt.Text) OrElse String.IsNullOrEmpty(AddVStockWt.Text) OrElse String.IsNullOrEmpty(AddIStockWt.Text) Then Exit Sub
        If Not IsNumeric(AddMStockWt.Text) OrElse Not IsNumeric(AddVStockWt.Text) OrElse Not IsNumeric(AddIStockWt.Text) Then Exit Sub

        AddTotStockWt.Text = CDbl(AddMStockWt.Text) + CDbl(AddVStockWt.Text) + CDbl(AddIStockWt.Text)
    End Sub
    Private Sub AddMStockFw_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(AddMStockFw.Text) OrElse String.IsNullOrEmpty(AddVStockFw.Text) OrElse String.IsNullOrEmpty(AddIStockFw.Text) Then Exit Sub
        If Not IsNumeric(AddMStockFw.Text) OrElse Not IsNumeric(AddVStockFw.Text) OrElse Not IsNumeric(AddIStockFw.Text) Then Exit Sub

        AddTotStockFw.Text = CDbl(AddMStockFw.Text) + CDbl(AddVStockFw.Text) + CDbl(AddIStockFw.Text)
    End Sub
    Private Sub AddVStockFw_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(AddMStockFw.Text) OrElse String.IsNullOrEmpty(AddVStockFw.Text) OrElse String.IsNullOrEmpty(AddIStockFw.Text) Then Exit Sub
        If Not IsNumeric(AddMStockFw.Text) OrElse Not IsNumeric(AddVStockFw.Text) OrElse Not IsNumeric(AddIStockFw.Text) Then Exit Sub

        AddTotStockFw.Text = CDbl(AddMStockFw.Text) + CDbl(AddVStockFw.Text) + CDbl(AddIStockFw.Text)
    End Sub
    Private Sub AddIStockFw_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(AddMStockFw.Text) OrElse String.IsNullOrEmpty(AddVStockFw.Text) OrElse String.IsNullOrEmpty(AddIStockFw.Text) Then Exit Sub
        If Not IsNumeric(AddMStockFw.Text) OrElse Not IsNumeric(AddVStockFw.Text) OrElse Not IsNumeric(AddIStockFw.Text) Then Exit Sub

        AddTotStockFw.Text = CDbl(AddMStockFw.Text) + CDbl(AddVStockFw.Text) + CDbl(AddIStockFw.Text)
    End Sub
    Private Sub AddTotStockWt_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(AddTotStockFw.Text) OrElse String.IsNullOrEmpty(AddTotStockWt.Text) Then Exit Sub
        If Not IsNumeric(AddTotStockFw.Text) OrElse Not IsNumeric(AddTotStockWt.Text) Then Exit Sub

        If AddTotStockFw.Text.Trim.Length > 0 Or AddTotStockWt.Text.Trim.Length > 0 Then
            AddTotStockPr.Text = Format(CDbl(AddTotStockFw.Text / AddTotStockWt.Text) * 100, "0.00")
        End If

        If String.IsNullOrEmpty(ReceiptGrossWt.Text) OrElse String.IsNullOrEmpty(IssueGrossWt.Text) OrElse String.IsNullOrEmpty(AddTotStockWt.Text) OrElse String.IsNullOrEmpty(AddTotStockWt.Text) Then Exit Sub
        If Not IsNumeric(ReceiptGrossWt.Text) OrElse Not IsNumeric(IssueGrossWt.Text) OrElse Not IsNumeric(AddTotStockWt.Text) OrElse Not IsNumeric(RemovalTotStockWt.Text) Then Exit Sub

        lblClosingStockWt.Text = CDbl(ReceiptGrossWt.Text) + CDbl(IssueGrossWt.Text) + CDbl(AddTotStockWt.Text) + CDbl(RemovalTotStockWt.Text)
    End Sub
    Private Sub AddTotStockFw_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(AddTotStockFw.Text) OrElse String.IsNullOrEmpty(AddTotStockWt.Text) Then Exit Sub
        If Not IsNumeric(AddTotStockFw.Text) OrElse Not IsNumeric(AddTotStockWt.Text) Then Exit Sub

        AddTotStockPr.Text = Format(CDbl(AddTotStockFw.Text / AddTotStockWt.Text) * 100, "0.00")

        If String.IsNullOrEmpty(ReceiptGrossFw.Text) OrElse String.IsNullOrEmpty(IssueGrossFw.Text) OrElse String.IsNullOrEmpty(AddTotStockFw.Text) OrElse String.IsNullOrEmpty(RemovalTotStockFw.Text) Then Exit Sub

        If Not IsNumeric(ReceiptGrossFw.Text) OrElse Not IsNumeric(IssueGrossFw.Text) OrElse Not IsNumeric(AddTotStockFw.Text) OrElse Not IsNumeric(RemovalTotStockFw.Text) Then Exit Sub

        lblClosingStockFw.Text = CDbl(ReceiptGrossFw.Text) + CDbl(IssueGrossFw.Text) + CDbl(AddTotStockFw.Text) + CDbl(RemovalTotStockFw.Text)
    End Sub
    Private Sub RemovalMStockWt_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(RemovalMStockWt.Text) OrElse String.IsNullOrEmpty(RemovalVStockWt.Text) OrElse String.IsNullOrEmpty(RemovalIStockWt.Text) Then Exit Sub
        If Not IsNumeric(RemovalMStockWt.Text) OrElse Not IsNumeric(RemovalVStockWt.Text) OrElse Not IsNumeric(RemovalIStockWt.Text) Then Exit Sub

        RemovalTotStockWt.Text = CDbl(RemovalMStockWt.Text) + CDbl(RemovalVStockWt.Text) + CDbl(RemovalIStockWt.Text)
    End Sub
    Private Sub RemovalVStockWt_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(RemovalMStockWt.Text) OrElse String.IsNullOrEmpty(RemovalVStockWt.Text) OrElse String.IsNullOrEmpty(RemovalIStockWt.Text) Then Exit Sub
        If Not IsNumeric(RemovalMStockWt.Text) OrElse Not IsNumeric(RemovalVStockWt.Text) OrElse Not IsNumeric(RemovalIStockWt.Text) Then Exit Sub

        RemovalTotStockWt.Text = CDbl(RemovalMStockWt.Text) + CDbl(RemovalVStockWt.Text) + CDbl(RemovalIStockWt.Text)
    End Sub
    Private Sub RemovalIStockWt_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(RemovalMStockWt.Text) OrElse String.IsNullOrEmpty(RemovalVStockWt.Text) OrElse String.IsNullOrEmpty(RemovalIStockWt.Text) Then Exit Sub
        If Not IsNumeric(RemovalMStockWt.Text) OrElse Not IsNumeric(RemovalVStockWt.Text) OrElse Not IsNumeric(RemovalIStockWt.Text) Then Exit Sub

        RemovalTotStockWt.Text = CDbl(RemovalMStockWt.Text) + CDbl(RemovalVStockWt.Text) + CDbl(RemovalIStockWt.Text)
    End Sub
    Private Sub RemovalMStockFw_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(RemovalMStockFw.Text) OrElse String.IsNullOrEmpty(RemovalVStockFw.Text) OrElse String.IsNullOrEmpty(RemovalIStockFw.Text) Then Exit Sub
        If Not IsNumeric(RemovalMStockFw.Text) OrElse Not IsNumeric(RemovalVStockFw.Text) OrElse Not IsNumeric(RemovalIStockFw.Text) Then Exit Sub

        RemovalTotStockFw.Text = CDbl(RemovalMStockFw.Text) + CDbl(RemovalVStockFw.Text) + CDbl(RemovalIStockFw.Text)
    End Sub
    Private Sub RemovalVStockFw_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(RemovalMStockFw.Text) OrElse String.IsNullOrEmpty(RemovalVStockFw.Text) OrElse String.IsNullOrEmpty(RemovalIStockFw.Text) Then Exit Sub
        If Not IsNumeric(RemovalMStockFw.Text) OrElse Not IsNumeric(RemovalVStockFw.Text) OrElse Not IsNumeric(RemovalIStockFw.Text) Then Exit Sub

        RemovalTotStockFw.Text = CDbl(RemovalMStockFw.Text) + CDbl(RemovalVStockFw.Text) + CDbl(RemovalIStockFw.Text)
    End Sub
    Private Sub RemovalIStockFw_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(RemovalMStockFw.Text) OrElse String.IsNullOrEmpty(RemovalVStockFw.Text) OrElse String.IsNullOrEmpty(RemovalIStockFw.Text) Then Exit Sub
        If Not IsNumeric(RemovalMStockFw.Text) OrElse Not IsNumeric(RemovalVStockFw.Text) OrElse Not IsNumeric(RemovalIStockFw.Text) Then Exit Sub

        RemovalTotStockFw.Text = CDbl(RemovalMStockFw.Text) + CDbl(RemovalVStockFw.Text) + CDbl(RemovalIStockFw.Text)
    End Sub
    Private Sub RemovalTotStockFw_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(RemovalTotStockFw.Text) OrElse String.IsNullOrEmpty(RemovalTotStockWt.Text) Then Exit Sub
        If Not IsNumeric(RemovalTotStockFw.Text) OrElse Not IsNumeric(AddTotStockWt.Text) Then Exit Sub

        RemovalTotStockPr.Text = Format(CDbl(RemovalTotStockFw.Text / RemovalTotStockWt.Text) * 100, "0.00")

        If String.IsNullOrEmpty(ReceiptGrossFw.Text) OrElse String.IsNullOrEmpty(IssueGrossFw.Text) OrElse String.IsNullOrEmpty(AddTotStockFw.Text) OrElse String.IsNullOrEmpty(RemovalTotStockFw.Text) Then Exit Sub

        If Not IsNumeric(ReceiptGrossFw.Text) OrElse Not IsNumeric(IssueGrossFw.Text) OrElse Not IsNumeric(AddTotStockFw.Text) OrElse Not IsNumeric(RemovalTotStockFw.Text) Then Exit Sub

        lblClosingStockFw.Text = CDbl(ReceiptGrossFw.Text) + CDbl(IssueGrossFw.Text) + CDbl(AddTotStockFw.Text) + CDbl(RemovalTotStockFw.Text)
    End Sub
    Private Sub RemovalTotStockWt_TextChanged(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(RemovalTotStockFw.Text) OrElse String.IsNullOrEmpty(RemovalTotStockWt.Text) Then Exit Sub
        If Not IsNumeric(RemovalTotStockFw.Text) OrElse Not IsNumeric(RemovalTotStockWt.Text) Then Exit Sub

        RemovalTotStockPr.Text = Format(CDbl(RemovalTotStockFw.Text / RemovalTotStockWt.Text) * 100, "0.00")

        If String.IsNullOrEmpty(ReceiptGrossWt.Text) OrElse String.IsNullOrEmpty(IssueGrossWt.Text) OrElse String.IsNullOrEmpty(AddTotStockWt.Text) OrElse String.IsNullOrEmpty(AddTotStockWt.Text) Then Exit Sub
        If Not IsNumeric(ReceiptGrossWt.Text) OrElse Not IsNumeric(IssueGrossWt.Text) OrElse Not IsNumeric(AddTotStockWt.Text) OrElse Not IsNumeric(RemovalTotStockWt.Text) Then Exit Sub

        lblClosingStockWt.Text = CDbl(ReceiptGrossWt.Text) + CDbl(IssueGrossWt.Text) + CDbl(AddTotStockWt.Text) + CDbl(RemovalTotStockWt.Text)
    End Sub
    Private Sub WipLGrossWt_TextChanged(sender As Object, e As EventArgs)
        '    If String.IsNullOrEmpty(WipLGrossWt.Text) OrElse String.IsNullOrEmpty(VacuumBagNCWt.Text) OrElse String.IsNullOrEmpty(BhukaBagCWt.Text) OrElse String.IsNullOrEmpty(VacuumBagWt.Text) OrElse String.IsNullOrEmpty(BhukaBagUWt.Text) OrElse String.IsNullOrEmpty(VacuumBagUWt.Text) OrElse String.IsNullOrEmpty(VoucherMetalWt.Text) OrElse String.IsNullOrEmpty(LossBagsWt.Text) OrElse String.IsNullOrEmpty(LossTransWt.Text) Then Exit Sub
        '    If Not IsNumeric(WipLGrossWt.Text) OrElse Not IsNumeric(VacuumBagNCWt.Text) OrElse Not IsNumeric(BhukaBagCWt.Text) OrElse Not IsNumeric(VacuumBagWt.Text) OrElse Not IsNumeric(BhukaBagUWt.Text) OrElse Not IsNumeric(VacuumBagUWt.Text) OrElse Not IsNumeric(VoucherMetalWt.Text) OrElse Not IsNumeric(LossBagsWt.Text) OrElse Not IsNumeric(LossTransWt.Text) Then Exit Sub

        '    lblGrossWt.Text = CDbl(WipLGrossWt.Text) + CDbl(VacuumBagNCWt.Text) + CDbl(BhukaBagCWt.Text) + CDbl(VacuumBagWt.Text) + CDbl(BhukaBagUWt.Text) + CDbl(VacuumBagUWt.Text) + CDbl(VoucherMetalWt.Text) + CDbl(LossBagsWt.Text) + CDbl(LossTransWt.Text)
    End Sub
    Private Sub VacuumBagNCWt_TextChanged(sender As Object, e As EventArgs) Handles VacuumBagNCWt.TextChanged
        '    If String.IsNullOrEmpty(WipLGrossWt.Text) OrElse String.IsNullOrEmpty(VacuumBagNCWt.Text) OrElse String.IsNullOrEmpty(BhukaBagCWt.Text) OrElse String.IsNullOrEmpty(VacuumBagWt.Text) OrElse String.IsNullOrEmpty(BhukaBagUWt.Text) OrElse String.IsNullOrEmpty(VacuumBagUWt.Text) OrElse String.IsNullOrEmpty(VoucherMetalWt.Text) OrElse String.IsNullOrEmpty(LossBagsWt.Text) OrElse String.IsNullOrEmpty(LossTransWt.Text) Then Exit Sub
        '    If Not IsNumeric(WipLGrossWt.Text) OrElse Not IsNumeric(VacuumBagNCWt.Text) OrElse Not IsNumeric(BhukaBagCWt.Text) OrElse Not IsNumeric(VacuumBagWt.Text) OrElse Not IsNumeric(BhukaBagUWt.Text) OrElse Not IsNumeric(VacuumBagUWt.Text) OrElse Not IsNumeric(VoucherMetalWt.Text) OrElse Not IsNumeric(LossBagsWt.Text) OrElse Not IsNumeric(LossTransWt.Text) Then Exit Sub

        '    lblGrossWt.Text = CDbl(WipLGrossWt.Text) + CDbl(VacuumBagNCWt.Text) + CDbl(BhukaBagCWt.Text) + CDbl(VacuumBagWt.Text) + CDbl(BhukaBagUWt.Text) + CDbl(VacuumBagUWt.Text) + CDbl(VoucherMetalWt.Text) + CDbl(LossBagsWt.Text) + CDbl(LossTransWt.Text)
    End Sub
    Private Sub BhukaBagCWt_TextChanged(sender As Object, e As EventArgs) Handles BhukaBagCWt.TextChanged
        'If String.IsNullOrEmpty(WipLGrossWt.Text) OrElse String.IsNullOrEmpty(VacuumBagNCWt.Text) OrElse String.IsNullOrEmpty(BhukaBagCWt.Text) OrElse String.IsNullOrEmpty(VacuumBagWt.Text) OrElse String.IsNullOrEmpty(BhukaBagUWt.Text) OrElse String.IsNullOrEmpty(VacuumBagUWt.Text) OrElse String.IsNullOrEmpty(VoucherMetalWt.Text) OrElse String.IsNullOrEmpty(LossBagsWt.Text) OrElse String.IsNullOrEmpty(LossTransWt.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossWt.Text) OrElse Not IsNumeric(VacuumBagNCWt.Text) OrElse Not IsNumeric(BhukaBagCWt.Text) OrElse Not IsNumeric(VacuumBagWt.Text) OrElse Not IsNumeric(BhukaBagUWt.Text) OrElse Not IsNumeric(VacuumBagUWt.Text) OrElse Not IsNumeric(VoucherMetalWt.Text) OrElse Not IsNumeric(LossBagsWt.Text) OrElse Not IsNumeric(LossTransWt.Text) Then Exit Sub

        'lblGrossWt.Text = CDbl(WipLGrossWt.Text) + CDbl(VacuumBagNCWt.Text) + CDbl(BhukaBagCWt.Text) + CDbl(VacuumBagWt.Text) + CDbl(BhukaBagUWt.Text) + CDbl(VacuumBagUWt.Text) + CDbl(VoucherMetalWt.Text) + CDbl(LossBagsWt.Text) + CDbl(LossTransWt.Text)
    End Sub
    Private Sub VacuumBagWt_TextChanged(sender As Object, e As EventArgs) Handles VacuumBagWt.TextChanged
        'If String.IsNullOrEmpty(WipLGrossWt.Text) OrElse String.IsNullOrEmpty(VacuumBagNCWt.Text) OrElse String.IsNullOrEmpty(BhukaBagCWt.Text) OrElse String.IsNullOrEmpty(VacuumBagWt.Text) OrElse String.IsNullOrEmpty(BhukaBagUWt.Text) OrElse String.IsNullOrEmpty(VacuumBagUWt.Text) OrElse String.IsNullOrEmpty(VoucherMetalWt.Text) OrElse String.IsNullOrEmpty(LossBagsWt.Text) OrElse String.IsNullOrEmpty(LossTransWt.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossWt.Text) OrElse Not IsNumeric(VacuumBagNCWt.Text) OrElse Not IsNumeric(BhukaBagCWt.Text) OrElse Not IsNumeric(VacuumBagWt.Text) OrElse Not IsNumeric(BhukaBagUWt.Text) OrElse Not IsNumeric(VacuumBagUWt.Text) OrElse Not IsNumeric(VoucherMetalWt.Text) OrElse Not IsNumeric(LossBagsWt.Text) OrElse Not IsNumeric(LossTransWt.Text) Then Exit Sub

        'lblGrossWt.Text = CDbl(WipLGrossWt.Text) + CDbl(VacuumBagNCWt.Text) + CDbl(BhukaBagCWt.Text) + CDbl(VacuumBagWt.Text) + CDbl(BhukaBagUWt.Text) + CDbl(VacuumBagUWt.Text) + CDbl(VoucherMetalWt.Text) + CDbl(LossBagsWt.Text) + CDbl(LossTransWt.Text)
    End Sub
    Private Sub BhukaBagUWt_TextChanged(sender As Object, e As EventArgs) Handles BhukaBagUWt.TextChanged
        'If String.IsNullOrEmpty(WipLGrossWt.Text) OrElse String.IsNullOrEmpty(VacuumBagNCWt.Text) OrElse String.IsNullOrEmpty(BhukaBagCWt.Text) OrElse String.IsNullOrEmpty(VacuumBagWt.Text) OrElse String.IsNullOrEmpty(BhukaBagUWt.Text) OrElse String.IsNullOrEmpty(VacuumBagUWt.Text) OrElse String.IsNullOrEmpty(VoucherMetalWt.Text) OrElse String.IsNullOrEmpty(LossBagsWt.Text) OrElse String.IsNullOrEmpty(LossTransWt.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossWt.Text) OrElse Not IsNumeric(VacuumBagNCWt.Text) OrElse Not IsNumeric(BhukaBagCWt.Text) OrElse Not IsNumeric(VacuumBagWt.Text) OrElse Not IsNumeric(BhukaBagUWt.Text) OrElse Not IsNumeric(VacuumBagUWt.Text) OrElse Not IsNumeric(VoucherMetalWt.Text) OrElse Not IsNumeric(LossBagsWt.Text) OrElse Not IsNumeric(LossTransWt.Text) Then Exit Sub

        'lblGrossWt.Text = CDbl(WipLGrossWt.Text) + CDbl(VacuumBagNCWt.Text) + CDbl(BhukaBagCWt.Text) + CDbl(VacuumBagWt.Text) + CDbl(BhukaBagUWt.Text) + CDbl(VacuumBagUWt.Text) + CDbl(VoucherMetalWt.Text) + CDbl(LossBagsWt.Text) + CDbl(LossTransWt.Text)
    End Sub
    Private Sub VacuumBagUWt_TextChanged(sender As Object, e As EventArgs) Handles VacuumBagUWt.TextChanged
        'If String.IsNullOrEmpty(WipLGrossWt.Text) OrElse String.IsNullOrEmpty(VacuumBagNCWt.Text) OrElse String.IsNullOrEmpty(BhukaBagCWt.Text) OrElse String.IsNullOrEmpty(VacuumBagWt.Text) OrElse String.IsNullOrEmpty(BhukaBagUWt.Text) OrElse String.IsNullOrEmpty(VacuumBagUWt.Text) OrElse String.IsNullOrEmpty(VoucherMetalWt.Text) OrElse String.IsNullOrEmpty(LossBagsWt.Text) OrElse String.IsNullOrEmpty(LossTransWt.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossWt.Text) OrElse Not IsNumeric(VacuumBagNCWt.Text) OrElse Not IsNumeric(BhukaBagCWt.Text) OrElse Not IsNumeric(VacuumBagWt.Text) OrElse Not IsNumeric(BhukaBagUWt.Text) OrElse Not IsNumeric(VacuumBagUWt.Text) OrElse Not IsNumeric(VoucherMetalWt.Text) OrElse Not IsNumeric(LossBagsWt.Text) OrElse Not IsNumeric(LossTransWt.Text) Then Exit Sub

        'lblGrossWt.Text = CDbl(WipLGrossWt.Text) + CDbl(VacuumBagNCWt.Text) + CDbl(BhukaBagCWt.Text) + CDbl(VacuumBagWt.Text) + CDbl(BhukaBagUWt.Text) + CDbl(VacuumBagUWt.Text) + CDbl(VoucherMetalWt.Text) + CDbl(LossBagsWt.Text) + CDbl(LossTransWt.Text)
    End Sub
    Private Sub VoucherMetalWt_TextChanged(sender As Object, e As EventArgs) Handles VoucherMetalWt.TextChanged
        'If String.IsNullOrEmpty(WipLGrossWt.Text) OrElse String.IsNullOrEmpty(VacuumBagNCWt.Text) OrElse String.IsNullOrEmpty(BhukaBagCWt.Text) OrElse String.IsNullOrEmpty(VacuumBagWt.Text) OrElse String.IsNullOrEmpty(BhukaBagUWt.Text) OrElse String.IsNullOrEmpty(VacuumBagUWt.Text) OrElse String.IsNullOrEmpty(VoucherMetalWt.Text) OrElse String.IsNullOrEmpty(LossBagsWt.Text) OrElse String.IsNullOrEmpty(LossTransWt.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossWt.Text) OrElse Not IsNumeric(VacuumBagNCWt.Text) OrElse Not IsNumeric(BhukaBagCWt.Text) OrElse Not IsNumeric(VacuumBagWt.Text) OrElse Not IsNumeric(BhukaBagUWt.Text) OrElse Not IsNumeric(VacuumBagUWt.Text) OrElse Not IsNumeric(VoucherMetalWt.Text) OrElse Not IsNumeric(LossBagsWt.Text) OrElse Not IsNumeric(LossTransWt.Text) Then Exit Sub

        'lblGrossWt.Text = CDbl(WipLGrossWt.Text) + CDbl(VacuumBagNCWt.Text) + CDbl(BhukaBagCWt.Text) + CDbl(VacuumBagWt.Text) + CDbl(BhukaBagUWt.Text) + CDbl(VacuumBagUWt.Text) + CDbl(VoucherMetalWt.Text) + CDbl(LossBagsWt.Text) + CDbl(LossTransWt.Text)
    End Sub
    Private Sub LossBagsWt_TextChanged(sender As Object, e As EventArgs) Handles LossBagsWt.TextChanged
        'If String.IsNullOrEmpty(WipLGrossWt.Text) OrElse String.IsNullOrEmpty(VacuumBagNCWt.Text) OrElse String.IsNullOrEmpty(BhukaBagCWt.Text) OrElse String.IsNullOrEmpty(VacuumBagWt.Text) OrElse String.IsNullOrEmpty(BhukaBagUWt.Text) OrElse String.IsNullOrEmpty(VacuumBagUWt.Text) OrElse String.IsNullOrEmpty(VoucherMetalWt.Text) OrElse String.IsNullOrEmpty(LossBagsWt.Text) OrElse String.IsNullOrEmpty(LossTransWt.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossWt.Text) OrElse Not IsNumeric(VacuumBagNCWt.Text) OrElse Not IsNumeric(BhukaBagCWt.Text) OrElse Not IsNumeric(VacuumBagWt.Text) OrElse Not IsNumeric(BhukaBagUWt.Text) OrElse Not IsNumeric(VacuumBagUWt.Text) OrElse Not IsNumeric(VoucherMetalWt.Text) OrElse Not IsNumeric(LossBagsWt.Text) OrElse Not IsNumeric(LossTransWt.Text) Then Exit Sub

        'lblGrossWt.Text = CDbl(WipLGrossWt.Text) + CDbl(VacuumBagNCWt.Text) + CDbl(BhukaBagCWt.Text) + CDbl(VacuumBagWt.Text) + CDbl(BhukaBagUWt.Text) + CDbl(VacuumBagUWt.Text) + CDbl(VoucherMetalWt.Text) + CDbl(LossBagsWt.Text) + CDbl(LossTransWt.Text)
    End Sub
    Private Sub LossTransWt_TextChanged(sender As Object, e As EventArgs) Handles LossTransWt.TextChanged
        'If String.IsNullOrEmpty(WipLGrossWt.Text) OrElse String.IsNullOrEmpty(VacuumBagNCWt.Text) OrElse String.IsNullOrEmpty(BhukaBagCWt.Text) OrElse String.IsNullOrEmpty(VacuumBagWt.Text) OrElse String.IsNullOrEmpty(BhukaBagUWt.Text) OrElse String.IsNullOrEmpty(VacuumBagUWt.Text) OrElse String.IsNullOrEmpty(VoucherMetalWt.Text) OrElse String.IsNullOrEmpty(LossBagsWt.Text) OrElse String.IsNullOrEmpty(LossTransWt.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossWt.Text) OrElse Not IsNumeric(VacuumBagNCWt.Text) OrElse Not IsNumeric(BhukaBagCWt.Text) OrElse Not IsNumeric(VacuumBagWt.Text) OrElse Not IsNumeric(BhukaBagUWt.Text) OrElse Not IsNumeric(VacuumBagUWt.Text) OrElse Not IsNumeric(VoucherMetalWt.Text) OrElse Not IsNumeric(LossBagsWt.Text) OrElse Not IsNumeric(LossTransWt.Text) Then Exit Sub

        'lblGrossWt.Text = CDbl(WipLGrossWt.Text) + CDbl(VacuumBagNCWt.Text) + CDbl(BhukaBagCWt.Text) + CDbl(VacuumBagWt.Text) + CDbl(BhukaBagUWt.Text) + CDbl(VacuumBagUWt.Text) + CDbl(VoucherMetalWt.Text) + CDbl(LossBagsWt.Text) + CDbl(LossTransWt.Text)
    End Sub
    Private Sub WipLGrossFw_TextChanged(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(WipLGrossFw.Text) OrElse String.IsNullOrEmpty(VacuumBagNCFw.Text) OrElse String.IsNullOrEmpty(BhukaBagCFw.Text) OrElse String.IsNullOrEmpty(VacuumBagFw.Text) OrElse String.IsNullOrEmpty(BhukaBagUFw.Text) OrElse String.IsNullOrEmpty(VacuumBagUFw.Text) OrElse String.IsNullOrEmpty(VoucherMetalFw.Text) OrElse String.IsNullOrEmpty(LossBagsFw.Text) OrElse String.IsNullOrEmpty(LossTransFw.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossFw.Text) OrElse Not IsNumeric(VacuumBagNCFw.Text) OrElse Not IsNumeric(BhukaBagCFw.Text) OrElse Not IsNumeric(VacuumBagFw.Text) OrElse Not IsNumeric(BhukaBagUFw.Text) OrElse Not IsNumeric(VacuumBagUFw.Text) OrElse Not IsNumeric(VoucherMetalFw.Text) OrElse Not IsNumeric(LossBagsFw.Text) OrElse Not IsNumeric(LossTransFw.Text) Then Exit Sub

        'lblGrossFw.Text = CDbl(WipLGrossFw.Text) + CDbl(VacuumBagNCFw.Text) + CDbl(BhukaBagCFw.Text) + CDbl(VacuumBagFw.Text) + CDbl(BhukaBagUFw.Text) + CDbl(VacuumBagUFw.Text) + CDbl(VoucherMetalFw.Text) + CDbl(LossBagsFw.Text) + CDbl(LossTransFw.Text)
    End Sub
    Private Sub VacuumBagNCFw_TextChanged(sender As Object, e As EventArgs) Handles VacuumBagNCFw.TextChanged
        'If String.IsNullOrEmpty(WipLGrossFw.Text) OrElse String.IsNullOrEmpty(VacuumBagNCFw.Text) OrElse String.IsNullOrEmpty(BhukaBagCFw.Text) OrElse String.IsNullOrEmpty(VacuumBagFw.Text) OrElse String.IsNullOrEmpty(BhukaBagUFw.Text) OrElse String.IsNullOrEmpty(VacuumBagUFw.Text) OrElse String.IsNullOrEmpty(VoucherMetalFw.Text) OrElse String.IsNullOrEmpty(LossBagsFw.Text) OrElse String.IsNullOrEmpty(LossTransFw.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossFw.Text) OrElse Not IsNumeric(VacuumBagNCFw.Text) OrElse Not IsNumeric(BhukaBagCFw.Text) OrElse Not IsNumeric(VacuumBagFw.Text) OrElse Not IsNumeric(BhukaBagUFw.Text) OrElse Not IsNumeric(VacuumBagUFw.Text) OrElse Not IsNumeric(VoucherMetalFw.Text) OrElse Not IsNumeric(LossBagsFw.Text) OrElse Not IsNumeric(LossTransFw.Text) Then Exit Sub

        'lblGrossFw.Text = CDbl(WipLGrossFw.Text) + CDbl(VacuumBagNCFw.Text) + CDbl(BhukaBagCFw.Text) + CDbl(VacuumBagFw.Text) + CDbl(BhukaBagUFw.Text) + CDbl(VacuumBagUFw.Text) + CDbl(VoucherMetalFw.Text) + CDbl(LossBagsFw.Text) + CDbl(LossTransFw.Text)
    End Sub
    Private Sub BhukaBagCFw_TextChanged(sender As Object, e As EventArgs) Handles BhukaBagCFw.TextChanged
        'If String.IsNullOrEmpty(WipLGrossFw.Text) OrElse String.IsNullOrEmpty(VacuumBagNCFw.Text) OrElse String.IsNullOrEmpty(BhukaBagCFw.Text) OrElse String.IsNullOrEmpty(VacuumBagFw.Text) OrElse String.IsNullOrEmpty(BhukaBagUFw.Text) OrElse String.IsNullOrEmpty(VacuumBagUFw.Text) OrElse String.IsNullOrEmpty(VoucherMetalFw.Text) OrElse String.IsNullOrEmpty(LossBagsFw.Text) OrElse String.IsNullOrEmpty(LossTransFw.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossFw.Text) OrElse Not IsNumeric(VacuumBagNCFw.Text) OrElse Not IsNumeric(BhukaBagCFw.Text) OrElse Not IsNumeric(VacuumBagFw.Text) OrElse Not IsNumeric(BhukaBagUFw.Text) OrElse Not IsNumeric(VacuumBagUFw.Text) OrElse Not IsNumeric(VoucherMetalFw.Text) OrElse Not IsNumeric(LossBagsFw.Text) OrElse Not IsNumeric(LossTransFw.Text) Then Exit Sub

        'lblGrossFw.Text = CDbl(WipLGrossFw.Text) + CDbl(VacuumBagNCFw.Text) + CDbl(BhukaBagCFw.Text) + CDbl(VacuumBagFw.Text) + CDbl(BhukaBagUFw.Text) + CDbl(VacuumBagUFw.Text) + CDbl(VoucherMetalFw.Text) + CDbl(LossBagsFw.Text) + CDbl(LossTransFw.Text)
    End Sub
    Private Sub VacuumBagFw_TextChanged(sender As Object, e As EventArgs) Handles VacuumBagFw.TextChanged
        'If String.IsNullOrEmpty(WipLGrossFw.Text) OrElse String.IsNullOrEmpty(VacuumBagNCFw.Text) OrElse String.IsNullOrEmpty(BhukaBagCFw.Text) OrElse String.IsNullOrEmpty(VacuumBagFw.Text) OrElse String.IsNullOrEmpty(BhukaBagUFw.Text) OrElse String.IsNullOrEmpty(VacuumBagUFw.Text) OrElse String.IsNullOrEmpty(VoucherMetalFw.Text) OrElse String.IsNullOrEmpty(LossBagsFw.Text) OrElse String.IsNullOrEmpty(LossTransFw.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossFw.Text) OrElse Not IsNumeric(VacuumBagNCFw.Text) OrElse Not IsNumeric(BhukaBagCFw.Text) OrElse Not IsNumeric(VacuumBagFw.Text) OrElse Not IsNumeric(BhukaBagUFw.Text) OrElse Not IsNumeric(VacuumBagUFw.Text) OrElse Not IsNumeric(VoucherMetalFw.Text) OrElse Not IsNumeric(LossBagsFw.Text) OrElse Not IsNumeric(LossTransFw.Text) Then Exit Sub

        'lblGrossFw.Text = CDbl(WipLGrossFw.Text) + CDbl(VacuumBagNCFw.Text) + CDbl(BhukaBagCFw.Text) + CDbl(VacuumBagFw.Text) + CDbl(BhukaBagUFw.Text) + CDbl(VacuumBagUFw.Text) + CDbl(VoucherMetalFw.Text) + CDbl(LossBagsFw.Text) + CDbl(LossTransFw.Text)
    End Sub
    Private Sub BhukaBagUFw_TextChanged(sender As Object, e As EventArgs) Handles BhukaBagUFw.TextChanged
        'If String.IsNullOrEmpty(WipLGrossFw.Text) OrElse String.IsNullOrEmpty(VacuumBagNCFw.Text) OrElse String.IsNullOrEmpty(BhukaBagCFw.Text) OrElse String.IsNullOrEmpty(VacuumBagFw.Text) OrElse String.IsNullOrEmpty(BhukaBagUFw.Text) OrElse String.IsNullOrEmpty(VacuumBagUFw.Text) OrElse String.IsNullOrEmpty(VoucherMetalFw.Text) OrElse String.IsNullOrEmpty(LossBagsFw.Text) OrElse String.IsNullOrEmpty(LossTransFw.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossFw.Text) OrElse Not IsNumeric(VacuumBagNCFw.Text) OrElse Not IsNumeric(BhukaBagCFw.Text) OrElse Not IsNumeric(VacuumBagFw.Text) OrElse Not IsNumeric(BhukaBagUFw.Text) OrElse Not IsNumeric(VacuumBagUFw.Text) OrElse Not IsNumeric(VoucherMetalFw.Text) OrElse Not IsNumeric(LossBagsFw.Text) OrElse Not IsNumeric(LossTransFw.Text) Then Exit Sub

        'lblGrossFw.Text = CDbl(WipLGrossFw.Text) + CDbl(VacuumBagNCFw.Text) + CDbl(BhukaBagCFw.Text) + CDbl(VacuumBagFw.Text) + CDbl(BhukaBagUFw.Text) + CDbl(VacuumBagUFw.Text) + CDbl(VoucherMetalFw.Text) + CDbl(LossBagsFw.Text) + CDbl(LossTransFw.Text)
    End Sub
    Private Sub VacuumBagUFw_TextChanged(sender As Object, e As EventArgs) Handles VacuumBagUFw.TextChanged
        'If String.IsNullOrEmpty(WipLGrossFw.Text) OrElse String.IsNullOrEmpty(VacuumBagNCFw.Text) OrElse String.IsNullOrEmpty(BhukaBagCFw.Text) OrElse String.IsNullOrEmpty(VacuumBagFw.Text) OrElse String.IsNullOrEmpty(BhukaBagUFw.Text) OrElse String.IsNullOrEmpty(VacuumBagUFw.Text) OrElse String.IsNullOrEmpty(VoucherMetalFw.Text) OrElse String.IsNullOrEmpty(LossBagsFw.Text) OrElse String.IsNullOrEmpty(LossTransFw.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossFw.Text) OrElse Not IsNumeric(VacuumBagNCFw.Text) OrElse Not IsNumeric(BhukaBagCFw.Text) OrElse Not IsNumeric(VacuumBagFw.Text) OrElse Not IsNumeric(BhukaBagUFw.Text) OrElse Not IsNumeric(VacuumBagUFw.Text) OrElse Not IsNumeric(VoucherMetalFw.Text) OrElse Not IsNumeric(LossBagsFw.Text) OrElse Not IsNumeric(LossTransFw.Text) Then Exit Sub

        'lblGrossFw.Text = CDbl(WipLGrossFw.Text) + CDbl(VacuumBagNCFw.Text) + CDbl(BhukaBagCFw.Text) + CDbl(VacuumBagFw.Text) + CDbl(BhukaBagUFw.Text) + CDbl(VacuumBagUFw.Text) + CDbl(VoucherMetalFw.Text) + CDbl(LossBagsFw.Text) + CDbl(LossTransFw.Text)
    End Sub
    Private Sub VoucherMetalFw_TextChanged(sender As Object, e As EventArgs) Handles VoucherMetalFw.TextChanged
        'If String.IsNullOrEmpty(WipLGrossFw.Text) OrElse String.IsNullOrEmpty(VacuumBagNCFw.Text) OrElse String.IsNullOrEmpty(BhukaBagCFw.Text) OrElse String.IsNullOrEmpty(VacuumBagFw.Text) OrElse String.IsNullOrEmpty(BhukaBagUFw.Text) OrElse String.IsNullOrEmpty(VacuumBagUFw.Text) OrElse String.IsNullOrEmpty(VoucherMetalFw.Text) OrElse String.IsNullOrEmpty(LossBagsFw.Text) OrElse String.IsNullOrEmpty(LossTransFw.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossFw.Text) OrElse Not IsNumeric(VacuumBagNCFw.Text) OrElse Not IsNumeric(BhukaBagCFw.Text) OrElse Not IsNumeric(VacuumBagFw.Text) OrElse Not IsNumeric(BhukaBagUFw.Text) OrElse Not IsNumeric(VacuumBagUFw.Text) OrElse Not IsNumeric(VoucherMetalFw.Text) OrElse Not IsNumeric(LossBagsFw.Text) OrElse Not IsNumeric(LossTransFw.Text) Then Exit Sub

        'lblGrossFw.Text = CDbl(WipLGrossFw.Text) + CDbl(VacuumBagNCFw.Text) + CDbl(BhukaBagCFw.Text) + CDbl(VacuumBagFw.Text) + CDbl(BhukaBagUFw.Text) + CDbl(VacuumBagUFw.Text) + CDbl(VoucherMetalFw.Text) + CDbl(LossBagsFw.Text) + CDbl(LossTransFw.Text)
    End Sub
    Private Sub LossBagsFw_TextChanged(sender As Object, e As EventArgs) Handles LossBagsFw.TextChanged
        'If String.IsNullOrEmpty(WipLGrossFw.Text) OrElse String.IsNullOrEmpty(VacuumBagNCFw.Text) OrElse String.IsNullOrEmpty(BhukaBagCFw.Text) OrElse String.IsNullOrEmpty(VacuumBagFw.Text) OrElse String.IsNullOrEmpty(BhukaBagUFw.Text) OrElse String.IsNullOrEmpty(VacuumBagUFw.Text) OrElse String.IsNullOrEmpty(VoucherMetalFw.Text) OrElse String.IsNullOrEmpty(LossBagsFw.Text) OrElse String.IsNullOrEmpty(LossTransFw.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossFw.Text) OrElse Not IsNumeric(VacuumBagNCFw.Text) OrElse Not IsNumeric(BhukaBagCFw.Text) OrElse Not IsNumeric(VacuumBagFw.Text) OrElse Not IsNumeric(BhukaBagUFw.Text) OrElse Not IsNumeric(VacuumBagUFw.Text) OrElse Not IsNumeric(VoucherMetalFw.Text) OrElse Not IsNumeric(LossBagsFw.Text) OrElse Not IsNumeric(LossTransFw.Text) Then Exit Sub

        'lblGrossFw.Text = CDbl(WipLGrossFw.Text) + CDbl(VacuumBagNCFw.Text) + CDbl(BhukaBagCFw.Text) + CDbl(VacuumBagFw.Text) + CDbl(BhukaBagUFw.Text) + CDbl(VacuumBagUFw.Text) + CDbl(VoucherMetalFw.Text) + CDbl(LossBagsFw.Text) + CDbl(LossTransFw.Text)
    End Sub
    Private Sub LossTransFw_TextChanged(sender As Object, e As EventArgs) Handles LossTransFw.TextChanged
        'If String.IsNullOrEmpty(WipLGrossFw.Text) OrElse String.IsNullOrEmpty(VacuumBagNCFw.Text) OrElse String.IsNullOrEmpty(BhukaBagCFw.Text) OrElse String.IsNullOrEmpty(VacuumBagFw.Text) OrElse String.IsNullOrEmpty(BhukaBagUFw.Text) OrElse String.IsNullOrEmpty(VacuumBagUFw.Text) OrElse String.IsNullOrEmpty(VoucherMetalFw.Text) OrElse String.IsNullOrEmpty(LossBagsFw.Text) OrElse String.IsNullOrEmpty(LossTransFw.Text) Then Exit Sub
        'If Not IsNumeric(WipLGrossFw.Text) OrElse Not IsNumeric(VacuumBagNCFw.Text) OrElse Not IsNumeric(BhukaBagCFw.Text) OrElse Not IsNumeric(VacuumBagFw.Text) OrElse Not IsNumeric(BhukaBagUFw.Text) OrElse Not IsNumeric(VacuumBagUFw.Text) OrElse Not IsNumeric(VoucherMetalFw.Text) OrElse Not IsNumeric(LossBagsFw.Text) OrElse Not IsNumeric(LossTransFw.Text) Then Exit Sub

        'lblGrossFw.Text = CDbl(WipLGrossFw.Text) + CDbl(VacuumBagNCFw.Text) + CDbl(BhukaBagCFw.Text) + CDbl(VacuumBagFw.Text) + CDbl(BhukaBagUFw.Text) + CDbl(VacuumBagUFw.Text) + CDbl(VoucherMetalFw.Text) + CDbl(LossBagsFw.Text) + CDbl(LossTransFw.Text)
    End Sub
    Private Sub lblGrossFw_TextChanged(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(lblGrossFw.Text) OrElse String.IsNullOrEmpty(lblGrossWt.Text) Then Exit Sub
        'If Not IsNumeric(lblGrossFw.Text) OrElse Not IsNumeric(lblGrossWt.Text) Then Exit Sub

        'lblGrossPr.Text = Format(CDbl(lblGrossFw.Text / lblGrossWt.Text) * 100, "0.00")
    End Sub
    Private Sub lblGrossWt_TextChanged(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(lblGrossFw.Text) OrElse String.IsNullOrEmpty(lblGrossWt.Text) Then Exit Sub
        'If Not IsNumeric(lblGrossFw.Text) OrElse Not IsNumeric(lblGrossWt.Text) Then Exit Sub

        'lblGrossPr.Text = Format(CDbl(lblGrossFw.Text / lblGrossWt.Text) * 100, "0.00")
    End Sub
    Private Sub ReceiptGrossWt_TextChanged(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(ReceiptGrossWt.Text) OrElse String.IsNullOrEmpty(IssueGrossWt.Text) OrElse String.IsNullOrEmpty(AddTotStockWt.Text) OrElse String.IsNullOrEmpty(AddTotStockWt.Text) Then Exit Sub
        'If Not IsNumeric(ReceiptGrossWt.Text) OrElse Not IsNumeric(IssueGrossWt.Text) OrElse Not IsNumeric(AddTotStockWt.Text) OrElse Not IsNumeric(RemovalTotStockWt.Text) Then Exit Sub

        'lblClosingStockWt.Text = CDbl(ReceiptGrossWt.Text) + CDbl(IssueGrossWt.Text) + CDbl(AddTotStockWt.Text) + CDbl(RemovalTotStockWt.Text)
    End Sub
    Private Sub IssueGrossWt_TextChanged(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(ReceiptGrossWt.Text) OrElse String.IsNullOrEmpty(IssueGrossWt.Text) OrElse String.IsNullOrEmpty(AddTotStockWt.Text) OrElse String.IsNullOrEmpty(AddTotStockWt.Text) Then Exit Sub
        'If Not IsNumeric(ReceiptGrossWt.Text) OrElse Not IsNumeric(IssueGrossWt.Text) OrElse Not IsNumeric(AddTotStockWt.Text) OrElse Not IsNumeric(RemovalTotStockWt.Text) Then Exit Sub

        'lblClosingStockWt.Text = CDbl(ReceiptGrossWt.Text) + CDbl(IssueGrossWt.Text) + CDbl(AddTotStockWt.Text) + CDbl(RemovalTotStockWt.Text)
    End Sub
    Private Sub ReceiptGrossFw_TextChanged(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(ReceiptGrossFw.Text) OrElse String.IsNullOrEmpty(IssueGrossFw.Text) OrElse String.IsNullOrEmpty(AddTotStockFw.Text) OrElse String.IsNullOrEmpty(RemovalTotStockFw.Text) Then Exit Sub

        'If Not IsNumeric(ReceiptGrossFw.Text) OrElse Not IsNumeric(IssueGrossFw.Text) OrElse Not IsNumeric(AddTotStockFw.Text) OrElse Not IsNumeric(RemovalTotStockFw.Text) Then Exit Sub

        'lblClosingStockFw.Text = CDbl(ReceiptGrossFw.Text) + CDbl(IssueGrossFw.Text) + CDbl(AddTotStockFw.Text) + CDbl(RemovalTotStockFw.Text)
    End Sub
    Private Sub IssueGrossFw_TextChanged(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(ReceiptGrossFw.Text) OrElse String.IsNullOrEmpty(IssueGrossFw.Text) OrElse String.IsNullOrEmpty(AddTotStockFw.Text) OrElse String.IsNullOrEmpty(RemovalTotStockFw.Text) Then Exit Sub

        'If Not IsNumeric(ReceiptGrossFw.Text) OrElse Not IsNumeric(IssueGrossFw.Text) OrElse Not IsNumeric(AddTotStockFw.Text) OrElse Not IsNumeric(RemovalTotStockFw.Text) Then Exit Sub

        'lblClosingStockFw.Text = CDbl(ReceiptGrossFw.Text) + CDbl(IssueGrossFw.Text) + CDbl(AddTotStockFw.Text) + CDbl(RemovalTotStockFw.Text)
    End Sub
    Private Sub lblClosingStockFw_TextChanged(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(lblClosingStockFw.Text) OrElse String.IsNullOrEmpty(lblClosingStockWt.Text) Then Exit Sub
        'If Not IsNumeric(lblClosingStockFw.Text) OrElse Not IsNumeric(lblClosingStockWt.Text) Then Exit Sub

        'lblClosingStockPr.Text = Format(CDbl(lblClosingStockFw.Text / lblClosingStockWt.Text) * 100, "0.00")
    End Sub
    Private Sub lblClosingStockWt_TextChanged(sender As Object, e As EventArgs)
        'If String.IsNullOrEmpty(lblClosingStockFw.Text) OrElse String.IsNullOrEmpty(lblClosingStockWt.Text) Then Exit Sub
        'If Not IsNumeric(lblClosingStockFw.Text) OrElse Not IsNumeric(lblClosingStockWt.Text) Then Exit Sub

        'lblClosingStockPr.Text = Format(CDbl(lblClosingStockFw.Text / lblClosingStockWt.Text) * 100, "0.00")
    End Sub
    Private Sub btnWIPLots_Click(sender As Object, e As EventArgs) Handles btnWIPLots.Click
        Dim ObjWIPLotDetails As New frmWIPLotDetails
        ObjWIPLotDetails.ShowDialog()
    End Sub

    Private Sub btnScrapBagNotUpdate_Click(sender As Object, e As EventArgs) Handles btnScrapBagNotUpdate.Click
        Dim ObjScrapBagNotUpdate As New frmFScrapBagNotUpdated
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub

    Private Sub btnVacBagNotUpdate_Click(sender As Object, e As EventArgs) Handles btnVacBagNotUpdate.Click
        Dim ObjScrapBagNotUpdate As New frmFVacBagNotUpdated
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub
    'Private Sub btnOpStock_Click(sender As Object, e As EventArgs) Handles btnOpStock.Click
    '    Dim ObjScrapBagNotUpdate As New frmOpStock
    '    ObjScrapBagNotUpdate.ShowDialog()
    'End Sub

    Private Sub btnDeptReceive_Click_1(sender As Object, e As EventArgs) Handles btnDeptReceive.Click
        Dim ObjScrapBagNotUpdate As New frmFDeptReceive
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub

    Private Sub btnDeptIssue_Click_1(sender As Object, e As EventArgs) Handles btnDeptIssue.Click
        Dim ObjScrapBagNotUpdate As New frmFDeptIssue
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub
    Private Sub btnMStockAddition_Click(sender As Object, e As EventArgs) Handles btnMStockAddition.Click
        Dim ObjScrapBagNotUpdate As New frmFMStockAddition
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub
    Private Sub btnVStockAddition_Click_1(sender As Object, e As EventArgs) Handles btnVStockAddition.Click
        Dim ObjScrapBagNotUpdate As New frmVStockAddition
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub
    Private Sub btnIStockAddition_Click_1(sender As Object, e As EventArgs) Handles btnIStockAddition.Click
        Dim ObjScrapBagNotUpdate As New frmFIStockAddition
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub

    Private Sub btnMStockRemoval_Click(sender As Object, e As EventArgs) Handles btnMStockRemoval.Click
        Dim ObjScrapBagNotUpdate As New frmFMStockRemoval
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub

    Private Sub btnVStockRemoval_Click_1(sender As Object, e As EventArgs) Handles btnVStockRemoval.Click
        Dim ObjScrapBagNotUpdate As New frmFVStockRemoval
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub

    Private Sub btnIStockRemoval_Click_1(sender As Object, e As EventArgs) Handles btnIStockRemoval.Click
        Dim ObjScrapBagNotUpdate As New frmFIStockRemoval
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub

    Private Sub BtnDailyStock_Click(sender As Object, e As EventArgs) Handles BtnDailyStock.Click
        Me.SaveData()
        Me.Close()
        Dim ObjScrapBagNotUpdate As New frmFStockLogin
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub
    Private Sub SaveData()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                '.Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))

                .Add(dbManager.CreateParameter("@DStockForWIP", WipLGrossWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DStockForVoucherMetalUnUsed", VoucherMetalWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DStockForBagsNotCreated", VacuumBagNCWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DStockForScrapBagsNotReceived", BhukaBagCWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DStockForVacBagsNotReceived", VacuumBagWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DStockForScrapBagsNotUpdated", txtSBNUWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DStockForVacBagsNotUpdated", txtVBNUWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DStockForScrapBagsNotUsed", BhukaBagUWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DStockForVacBagsNotUsed", VacuumBagUWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DStockInHand", lblGrossWt.Text.Trim, DbType.String))
                '.Add(dbManager.CreateParameter("@DStockForLoss", txtLScrapVaccumeWt.Text.Trim, DbType.String))
                '.Add(dbManager.CreateParameter("@DSStockForSummary", SumWt.Text.Trim, DbType.String))
                '.Add(dbManager.CreateParameter("@DStockForAddition", AddTotStockWt.Text.Trim, DbType.String))
                '.Add(dbManager.CreateParameter("@DStockForSubstraction", RemovalTotStockWt.Text.Trim, DbType.String))
            End With

            dbManager.Insert("SP_fDailyStock_Save", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        BtnPrint.Visible = False
        BtnDailyStock.Visible = False
        Me.ExpandCollaps()
        Me.PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = True
        Me.PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
        Me.PrintForm1.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.CompatibleModeFullWindow)
        Me.PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        'PrintForm1.PrintAction = Printing.PrintAction.PrintToPrinter
        PrintForm1.Print()
    End Sub

    Private Sub GrpBBCreated_Enter(sender As Object, e As EventArgs) Handles GrpBBCreated.Enter

    End Sub

    Private Sub Label51_Click(sender As Object, e As EventArgs) Handles Label51.Click

    End Sub

    Private Sub Label47_Click(sender As Object, e As EventArgs) Handles Label47.Click

    End Sub

    Private Sub Label55_Click(sender As Object, e As EventArgs) Handles Label55.Click

    End Sub

    Private Sub FlowLayoutPanel3_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel3.Paint

    End Sub

    Private Sub RadPanel2_Paint(sender As Object, e As PaintEventArgs) Handles RadPanel2.Paint

    End Sub
End Class