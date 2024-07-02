Imports System.Data.SqlClient
Imports System.IO
Imports DataAccessHandler
Public Class frmStockSummary
    Dim rs As New ClsResizer
    Dim strSQL As String = Nothing
    Dim iRowCnt As Integer = 0

    Dim dbManager As New SqlHelper()
    Private connectionString As String = File.ReadAllText(System.IO.Path.Combine("D:\", "DBConn.txt"))
    Private bulider1 As SqlConnectionStringBuilder = Nothing
    Private Sub frmStockSummaryRuntime_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.GetWIPLots()
            Me.GetWIPMelting()
            Me.GetWIPLotTransfered()
            Me.GetFinishedLots()

            Me.TotalWIPTotal()

            '' Bags Started
            '' Bags Not Created
            Me.GetBhukaBagNotCreated()
            Me.GetVacuumBagNotCreated()
            Me.GetSampleBagNotCreated()

            Me.TotalBagNotCreated()

            '' Bags Not Received
            Me.GetBhukaBagNotReceived()
            Me.GetVacuumBagNotReceived()
            Me.GetSampleBagNotReceived()
            Me.GetLotFailBagNotReceived()

            Me.TotalBagNotReceived()

            '' Bags Not Updated
            Me.GetBhukaBagNotUpdated()
            Me.GetVaccumBagNotUpdated()
            Me.GetSampleBagNotUpdated()
            Me.GetLotFailBagNotUpdated()

            Me.TotalBagNotUpdated()

            ''Bags Not Used
            Me.GetBhukaBagNotUsed()
            Me.GetVaccumBagNotUsed()
            Me.GetSampleBagNotUsed()
            Me.GetLotFailBagNotUsed()
            '' Bags Ended

            Me.TotalBagNotUsed()

            Me.GetVoucherMetalUnused()

            Me.GetLotAdditionStock()

            Me.GetBagLoss()
            Me.GetLossTransaction()
            Me.GetLossLab()

            Me.TotalLosswt()

            Me.GetMetalReceipt()
            Me.GetMetalIssue()

            Me.GetTxtTotal()
            ExpandClose()

            ''Setting OpStock Value Start

            txtOpeningStockWt.Text = Format(OpGrossWt, "0.00")

            If Val(OpGrossPr) > 0 Then
                txtOpeningStockPr.Text = Format(OpGrossPr, "0.00")
            Else
                txtOpeningStockPr.Text = Format(0, "0.00")
            End If

            txtOpeningStockFw.Text = Format(OpGrossFw, "0.00")
            ''Setting OpStock Value End
            ''Daily Stock By Category Total Functionality
            Me.ClearTotalByCategory()
            Me.TotalStockByCategory()
            lblTotalGrossByCategory.Text = "0.00"
            lblTotalFWtByCategory.Text = "0.00"
            lblTotalPrByCategory.Text = "0.00"

            lblTotalGrossByCategory.Text = Format(((txtVMUGrossWt.Text) + (txtLASGWt.Text) + (txtWIPLGWt.Text) + (txtWIPMGWt.Text) + (txtWIPTGWt.Text) + (txtFLGWt.Text) + (txtSBNCGWt.Text) + (txtVBNCGWt.Text) + (txtSMBNCGWt.Text) + (txtSBNRGWt.Text) + (txtVBNRGWt.Text) + (txtSMBNRGWt.Text) + (txtLFBNRGWt.Text) + (txtSBNUGWt.Text) + (txtVBNUGWt.Text) + (txtSMBNUGWt.Text) + (txtLFBNUGWt.Text) + (txtSBNUsGWt.Text) + (txtVBNUsGWt.Text) + (txtSMBNUsGWt.Text) + (txtLFBNUsGWt.Text) + (txtXSBNUsGWt.Text) + (txtSIHGWt.Text)), "0.00")
            lblTotalFWtByCategory.Text = Format(((txtVMUFWt.Text) + (txtLASFWt.Text) + (txtWIPLFWt.Text) + (txtWIPMFWt.Text) + (txtWIPTFWt.Text) + (txtFLFWt.Text) + (txtSBNCFWt.Text) + (txtVBNCFWt.Text) + (txtSMBNCFWt.Text) + (txtSBNRFWt.Text) + (txtVBNRFWt.Text) + (txtSMBNRFWt.Text) + (txtLFBNRFWt.Text) + (txtSBNUFWt.Text) + (txtVBNUFWt.Text) + (txtSMBNUFWt.Text) + (txtLFBNUFWt.Text) + (txtSBNUsFWt.Text) + (txtVBNUsFWt.Text) + (txtSMBNUsFWt.Text) + (txtLFBNUsFWt.Text) + (txtXSBNUsFWt.Text) + (txtSIHFWt.Text)), "0.00")
            lblTotalPrByCategory.Text = Format((CDbl(lblTotalFWtByCategory.Text) / CDbl(lblTotalGrossByCategory.Text) * 100), "0.00")
            If lblTotalPrByCategory.Text = "NaN" Then
                lblTotalPrByCategory.Text = "0.00"
            End If
            Me.TotalDiff()

        Catch ex As Exception

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub TotalDiff()
        lblTotalDiffCatgr.Text = Format((CDbl(txtVMUDiff.Text) + CDbl(txtLASDiff.Text) + CDbl(txtWIPLDiff.Text) + CDbl(txtWIPMDiff.Text) + CDbl(txtWIPTDiff.Text) + CDbl(txtFLDiff.Text) + CDbl(txtSBNCDiff.Text) + CDbl(txtVBNCDiff.Text) + CDbl(txtSMBNCDiff.Text) + CDbl(txtSBNRDiff.Text) + CDbl(txtVBNRDiff.Text) + CDbl(txtSMBNRDiff.Text) + CDbl(txtLFBNRDiff.Text) + CDbl(txtSBNUDiff.Text) + CDbl(txtVBNUDiff.Text) + CDbl(txtSMBNUDiff.Text) + CDbl(txtLFBNUDiff.Text) + CDbl(txtSBNUsDiff.Text) + CDbl(txtVBNUsDiff.Text) + CDbl(txtSMBNUsDiff.Text) + CDbl(txtLFBNUsDiff.Text) + CDbl(txtXSBNUsDiff.Text) + CDbl(txtSIHDiff.Text)), "0.00")
    End Sub
    Private Sub ClearTotalByCategory()
        txtVMUGrossWt.Text = "0.00"
        txtVMUPr.Text = "0.00"
        txtVMUFWt.Text = "0.00"

        txtVMUDiff.Text = "0.00"

        txtLASGWt.Text = "0.00"
        txtLASPr.Text = "0.00"
        txtLASFWt.Text = "0.00"

        txtLASDiff.Text = "0.00"

        txtWIPLGWt.Text = "0.00"
        txtWIPLPr.Text = "0.00"
        txtWIPLFWt.Text = "0.00"

        txtWIPLDiff.Text = "0.00"

        txtWIPMGWt.Text = "0.00"
        txtWIPMPr.Text = "0.00"
        txtWIPMFWt.Text = "0.00"

        txtWIPMDiff.Text = "0.00"

        txtWIPTGWt.Text = "0.00"
        txtWIPTPr.Text = "0.00"
        txtWIPTFWt.Text = "0.00"

        txtWIPTDiff.Text = "0.00"

        txtFLGWt.Text = "0.00"
        txtFLPr.Text = "0.00"
        txtFLFWt.Text = "0.00"

        txtFLDiff.Text = "0.00"

        txtSBNCGWt.Text = "0.00"
        txtSBNCPr.Text = "0.00"
        txtSBNCFWt.Text = "0.00"

        txtSBNCDiff.Text = "0.00"

        txtVBNCGWt.Text = "0.00"
        txtVBNCPr.Text = "0.00"
        txtVBNCFWt.Text = "0.00"

        txtVBNCDiff.Text = "0.00"

        txtSMBNCGWt.Text = "0.00"
        txtSMBNCPr.Text = "0.00"
        txtSMBNCFWt.Text = "0.00"

        txtSMBNCDiff.Text = "0.00"

        txtSBNRGWt.Text = "0.00"
        txtSBNRPr.Text = "0.00"
        txtSBNRFWt.Text = "0.00"

        txtSBNRDiff.Text = "0.00"

        txtVBNRGWt.Text = "0.00"
        txtVBNRPr.Text = "0.00"
        txtVBNRFWt.Text = "0.00"

        txtVBNRDiff.Text = "0.00"

        txtSMBNRGWt.Text = "0.00"
        txtSMBNRPr.Text = "0.00"
        txtSMBNRFWt.Text = "0.00"

        txtSMBNRDiff.Text = "0.00"

        txtLFBNRGWt.Text = "0.00"
        txtLFBNRPr.Text = "0.00"
        txtLFBNRFWt.Text = "0.00"

        txtLFBNRDiff.Text = "0.00"

        txtSBNUGWt.Text = "0.00"
        txtSBNUPr.Text = "0.00"
        txtSBNUFWt.Text = "0.00"

        txtSBNUsDiff.Text = "0.00"

        txtVBNUsGWt.Text = "0.00"
        txtVBNUsPr.Text = "0.00"
        txtVBNUsFWt.Text = "0.00"

        txtVBNUsDiff.Text = "0.00"

        txtSMBNUsGWt.Text = "0.00"
        txtSMBNUsPr.Text = "0.00"
        txtSMBNUsFWt.Text = "0.00"

        txtSMBNUsDiff.Text = "0.00"

        txtLFBNUsGWt.Text = "0.00"
        txtLFBNUsPr.Text = "0.00"
        txtLFBNUsFWt.Text = "0.00"

        txtLFBNUsDiff.Text = "0.00"

        txtXSBNUsGWt.Text = "0.00"
        txtXSBNUsPr.Text = "0.00"
        txtXSBNUsFWt.Text = "0.00"

        txtXSBNUsDiff.Text = "0.00"

        txtSIHGWt.Text = "0.00"
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
                txtVMUGrossWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtVMUPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtVMUFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtVMUDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId2 As Integer = 2
        If StockCategoryId2 = 2 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId2)
            If dtData.Rows.Count > 0 Then
                txtLASGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtLASPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtLASFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtLASDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId3 As Integer = 3
        If StockCategoryId3 = 3 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId3)
            If dtData.Rows.Count > 0 Then
                txtWIPLGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtWIPLPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtWIPLFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtWIPLDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId4 As Integer = 4
        If StockCategoryId4 = 4 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId4)
            If dtData.Rows.Count > 0 Then
                txtWIPMGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtWIPMPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtWIPMFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtWIPMDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId5 As Integer = 5
        If StockCategoryId5 = 5 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId5)
            If dtData.Rows.Count > 0 Then
                txtWIPTGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtWIPTPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtWIPTFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtWIPTDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId6 As Integer = 6
        If StockCategoryId6 = 6 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId6)
            If dtData.Rows.Count > 0 Then
                txtFLGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtFLPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtFLFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtFLDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId7 As Integer = 7
        If StockCategoryId7 = 7 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId7)
            If dtData.Rows.Count > 0 Then
                txtSBNCGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSBNCPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSBNCFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSBNCDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId8 As Integer = 8
        If StockCategoryId8 = 8 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId8)
            If dtData.Rows.Count > 0 Then
                txtVBNCGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtVBNCPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtVBNCFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtVBNCDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId9 As Integer = 9
        If StockCategoryId9 = 9 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId9)
            If dtData.Rows.Count > 0 Then
                txtSMBNCGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSMBNCPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSMBNCFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSMBNCDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId10 As Integer = 10
        If StockCategoryId10 = 10 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId10)
            If dtData.Rows.Count > 0 Then
                txtSBNRGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSBNRPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSBNRFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSBNRDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId11 As Integer = 11
        If StockCategoryId11 = 11 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId11)
            If dtData.Rows.Count > 0 Then
                txtVBNRGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtVBNRPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtVBNRFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtVBNRDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId12 As Integer = 12
        If StockCategoryId12 = 12 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId12)
            If dtData.Rows.Count > 0 Then
                txtSMBNRGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSMBNRPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSMBNRFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSMBNRDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId13 As Integer = 13
        If StockCategoryId13 = 13 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId13)
            If dtData.Rows.Count > 0 Then
                txtLFBNRGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtLFBNRPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtLFBNRFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtLFBNRDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId14 As Integer = 14
        If StockCategoryId14 = 14 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId14)
            If dtData.Rows.Count > 0 Then
                txtSBNUGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSBNUPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSBNUFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSBNUDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId15 As Integer = 15
        If StockCategoryId15 = 15 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId15)
            If dtData.Rows.Count > 0 Then
                txtVBNUGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtVBNUPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtVBNUFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtVBNUDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId16 As Integer = 16
        If StockCategoryId16 = 16 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId16)
            If dtData.Rows.Count > 0 Then
                txtSMBNUGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSMBNUPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSMBNUFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSMBNUDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId17 As Integer = 17
        If StockCategoryId17 = 17 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId17)
            If dtData.Rows.Count > 0 Then
                txtLFBNUGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtLFBNUPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtLFBNUFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtLFBNUDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId18 As Integer = 18
        If StockCategoryId18 = 18 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId18)
            If dtData.Rows.Count > 0 Then
                txtSBNUsGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSBNUsPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSBNUsFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSBNUsDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId19 As Integer = 19
        If StockCategoryId19 = 19 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId19)
            If dtData.Rows.Count > 0 Then
                txtVBNUsGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtVBNUsPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtVBNUsFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtVBNUsDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId20 As Integer = 20
        If StockCategoryId20 = 20 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId20)
            If dtData.Rows.Count > 0 Then
                txtSMBNUsGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtSMBNUsPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtSMBNUsFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtSMBNUsDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId21 As Integer = 21
        If StockCategoryId21 = 21 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId21)
            If dtData.Rows.Count > 0 Then
                txtLFBNUsGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtLFBNUsPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtLFBNUsFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtLFBNUsDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId22 As Integer = 22
        If StockCategoryId22 = 22 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId22)
            If dtData.Rows.Count > 0 Then
                txtXSBNUsGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
                txtXSBNUsPr.Text = dtData.Rows(0).Item("MeltingPr").ToString()
                txtXSBNUsFWt.Text = dtData.Rows(0).Item("TotalFineWtScale").ToString()
                txtXSBNUsDiff.Text = dtData.Rows(0).Item("FineDiff").ToString()
            End If
        End If
        Dim StockCategoryId23 As Integer = 23
        If StockCategoryId23 = 23 Then
            dtData = TotalCalculateStockByCategoryId(StockCategoryId23)
            If dtData.Rows.Count > 0 Then
                txtSIHGWt.Text = dtData.Rows(0).Item("TotalActualMetalWt").ToString()
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
        dtData = dbManager.GetDataTable("SP_DailyStock_Select", CommandType.StoredProcedure, parameters.ToArray())
        Return dtData
    End Function
    Private Sub ExpandCLose()
        RadCollapsiblePanel1.IsExpanded = False
        RadCollapsiblePanel2.IsExpanded = False
        RadCollapsiblePanel3.IsExpanded = False
        RadCollapsiblePanel4.IsExpanded = False
        RadCollapsiblePanel5.IsExpanded = False
        RadCollapsiblePanel6.IsExpanded = False
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
                .Add(dbManager.CreateParameter("@ActionType", "WIPLotsDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If row.RowState <> DataRowState.Deleted Then
                        If Not IsDBNull(row("ReceiveWt")) Then
                            sRWtTotal += Single.Parse(row("ReceiveWt"))
                        End If

                        If Not IsDBNull(row("FineWt")) Then
                            sFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next

                If sFWtTotal > 0 Then
                    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
                End If

                WipLGrossWt.Text = Format(sRWtTotal, "0.00")
                WipLGrossPr.Text = Format(sRPrTotal, "0.00")
                WipLGrossFw.Text = Format(sFWtTotal, "0.00")
            End If

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetWIPMelting()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "WIPMeltingDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(row("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(row("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            WipMGrossWt.Text = Format(sRWtTotal, "0.00")
            WipMGrossPr.Text = Format(sRPrTotal, "0.00")
            WipMGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetWIPLotTransfered()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "WIPLotTransferedDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("TransferWt")) Then
                        sRWtTotal += Single.Parse(row("TransferWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            If sFWtTotal > 0 Then
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            WipTGrossWt.Text = Format(sRWtTotal, "0.00")
            WipTGrossPr.Text = Format(sRPrTotal, "0.00")
            WipTGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetFinishedLots()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "FinishedLotsDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            WipFGrossWt.Text = Format(sRWtTotal, "0.00")
            WipFGrossPr.Text = Format(sRPrTotal, "0.00")
            WipFGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLotAdditionStock()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LotAdditionStockDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            LotAddStockWt.Text = Format(sRWtTotal, "0.00")
            LotAddStockPr.Text = Format(sRPrTotal, "0.00")
            LotAddStockFw.Text = Format(sFWtTotal, "0.00")

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
                .Add(dbManager.CreateParameter("@ActionType", "BhukaBagNotCreated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            BhukaBagNCWt.Text = Format(sRWtTotal, "0.00")
            BhukaBagNCPr.Text = Format(sRPrTotal, "0.00")
            BhukaBagNCFw.Text = Format(sFWtTotal, "0.00")

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
                .Add(dbManager.CreateParameter("@ActionType", "VacuumBagNotCreated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("ReceivePr")) Then
                        sRPrTotal += Single.Parse(row("ReceivePr"))
                    End If

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
        Finally
        End Try
    End Sub
    Private Sub GetSampleBagNotCreated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SampleBagNotCreated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            SampleBagNCWt.Text = Format(sRWtTotal, "0.00")
            SampleBagNCPr.Text = Format(sRPrTotal, "0.00")
            SampleBagNCFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetBhukaBagNotReceived()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "BhukaBagNotReceived", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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

            BhukaBagNrWt.Text = Format(sRWtTotal, "0.00")
            BhukaBagNrPr.Text = Format(sRPrTotal, "0.00")
            BhukaBagNrFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVacuumBagNotReceived()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumBagNotReceived", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
    Private Sub GetSampleBagNotReceived()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SampleBagNotReceived", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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

            SampleBagWt.Text = Format(sRWtTotal, "0.00")
            SampleBagPr.Text = Format(sRPrTotal, "0.00")
            SampleBagFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetBhukaBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sBRWtTotal As Single = 0
        Dim sBRPrTotal As Single = 0
        Dim sBFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "ScrapBagNotUsed", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            Dim dataView As DataView = dtData.DefaultView

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows

                    ''For Bhuka Bags
                    If row("ItemTypeId").ToString() = 2 Then
                        If Not IsDBNull(dtData.Rows(0)("BalanceWt")) Then
                            sBRWtTotal += Single.Parse(row("BalanceWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sBFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If

                Next
            End If

            ''Bhuka Wt
            If sBFWtTotal > 0 Then
                sBRPrTotal = Format((Val(sBFWtTotal) / Val(sBRWtTotal)) * 100, "0.00")
            End If

            ''Bhuka Wt
            BhukaBagUWt.Text = Format(sBRWtTotal, "0.00")
            BhukaBagUPr.Text = Format(sBRPrTotal, "0.00")
            BhukaBagUFw.Text = Format(sBFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVaccumBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sVRWtTotal As Single = 0
        Dim sVRPrTotal As Single = 0
        Dim sVFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumBagNotUsed", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            Dim dataView As DataView = dtData.DefaultView

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows

                    ''For Vaccum Bags
                    If row("ItemTypeId").ToString() = 5 Then
                        If Not IsDBNull(dtData.Rows(0)("BalanceWt")) Then
                            sVRWtTotal += Single.Parse(row("BalanceWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sVFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next
            End If

            ''Vaccum Wt
            If sVFWtTotal > 0 Then
                sVRPrTotal = Format((Val(sVFWtTotal) / Val(sVRWtTotal)) * 100, "0.00")
            End If

            ''vacuum Wt
            VacuumBagUWt.Text = Format(sVRWtTotal, "0.00")
            VacuumBagUPr.Text = Format(sVRPrTotal, "0.00")
            VacuumBagUFw.Text = Format(sVFWtTotal, "0.00")
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetSampleBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sSRWtTotal As Single = 0
        Dim sSRPrTotal As Single = 0
        Dim sSFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SampleBagNotUsed", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            Dim dataView As DataView = dtData.DefaultView

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    ''For Sample Bags
                    If row("ItemTypeId").ToString() = 2 Then
                        If Not IsDBNull(dtData.Rows(0)("BalanceWt")) Then
                            sSRWtTotal += Single.Parse(row("BalanceWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sSFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next
            End If

            ''Sample Wt
            If sSFWtTotal > 0 Then
                sSRPrTotal = Format((Val(sSFWtTotal) / Val(sSRWtTotal)) * 100, "0.00")
            End If

            ''Sample Wt
            SampleBagUWt.Text = Format(sSRWtTotal, "0.00")
            SampleBagUPr.Text = Format(sSRPrTotal, "0.00")
            SampleBagUFw.Text = Format(sSFWtTotal, "0.00")
        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLotFailBagNotUsed()
        Dim dtData As DataTable = New DataTable()

        Dim sLRWtTotal As Single = 0
        Dim sLRPrTotal As Single = 0
        Dim sLFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LotFailBagNotUsed", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            Dim dataView As DataView = dtData.DefaultView

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows

                    ''For Lotfail Bags
                    If row("ItemTypeId").ToString() = 4 Then
                        If Not IsDBNull(dtData.Rows(0)("BalanceWt")) Then
                            sLRWtTotal += Single.Parse(row("BalanceWt"))
                        End If

                        If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                            sLFWtTotal += Single.Parse(row("FineWt"))
                        End If
                    End If
                Next
            End If

            ''LotFail Wt
            If sLFWtTotal > 0 Then
                sLRPrTotal = Format((Val(sLFWtTotal) / Val(sLRWtTotal)) * 100, "0.00")
            End If

            ''LotFail Wt
            LotFailBagUWt.Text = Format(sLRWtTotal, "0.00")
            LotFailBagUPr.Text = Format(sLRPrTotal, "0.00")
            LotFailBagUFw.Text = Format(sLFWtTotal, "0.00")
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

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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

            VoucherMetalWt.Text = Format(sRWtTotal, "0.00")
            VoucherMetalPr.Text = Format(sRPrTotal, "0.00")
            VoucherMetalFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetBagLoss()
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

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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

            LabReceiveWt.Text = Format(sRWtTotal, "0.00")
            LabReceivePr.Text = Format(sRPrTotal, "0.00")
            LabReceiveFw.Text = Format(sFWtTotal, "0.00")

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

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("ReceiveWt")) Then
                        sRWtTotal += Single.Parse(row("ReceiveWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("ReceivePr")) Then
                        sRPrTotal += Single.Parse(row("ReceivePr"))
                    End If

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
    Private Sub GetMetalIssue()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LossDeptIssueDetails", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

            If dtData.Rows.Count > 0 Then
                For Each row As DataRow In dtData.Rows
                    If Not IsDBNull(dtData.Rows(0)("IssueWt")) Then
                        sRWtTotal += Single.Parse(row("IssueWt"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("IssuePr")) Then
                        sRPrTotal += Single.Parse(row("IssuePr"))
                    End If

                    If Not IsDBNull(dtData.Rows(0)("FineWt")) Then
                        sFWtTotal += Single.Parse(row("FineWt"))
                    End If
                Next
            End If

            'If sFWtTotal > 0 Then
            '    sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.00")
            'End If

            IssueGrossWt.Text = Format(sRWtTotal, "0.00")
            IssueGrossPr.Text = Format(sRPrTotal, "0.00")
            IssueGrossFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLotFailBagNotReceived()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LotFailBagNotReceived", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            LotFailBagWt.Text = Format(sRWtTotal, "0.00")
            LotFailBagPr.Text = Format(sRPrTotal, "0.00")
            LotFailBagFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetBhukaBagNotUpdated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "BhukaBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            BhukaBagNuWt.Text = Format(sRWtTotal, "0.00")
            BhukaBagNuPr.Text = Format(sRPrTotal, "0.00")
            BhukaBagNuFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetVaccumBagNotUpdated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "VaccumBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            VacuumBagNuWt.Text = Format(sRWtTotal, "0.00")
            VacuumBagNuPr.Text = Format(sRWtTotal, "0.00")
            VacuumBagNuFw.Text = Format(sRWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetSampleBagNotUpdated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "SampleBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            SampleBagNuWt.Text = Format(sRWtTotal, "0.00")
            SampleBagNuPr.Text = Format(sRPrTotal, "0.00")
            SampleBagNuFw.Text = Format(sFWtTotal, "0.00")

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub GetLotFailBagNotUpdated()
        Dim dtData As DataTable = New DataTable()

        Dim sRWtTotal As Single = 0
        Dim sRPrTotal As Single = 0
        Dim sFWtTotal As Single = 0

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@ActionType", "LotFailBagNotUpdated", DbType.String))
            End With

            dtData = dbManager.GetDataTable("SP_BagsStockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
                sRPrTotal = Format((Val(sFWtTotal) / Val(sRWtTotal)) * 100, "0.000")
            End If

            LotFailBagNuWt.Text = Format(sRWtTotal, "0.00")
            LotFailBagNuPr.Text = Format(sRPrTotal, "0.00")
            LotFailBagNuFw.Text = Format(sFWtTotal, "0.00")

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

            dtData = dbManager.GetDataTable("SP_StockDetails_Select", CommandType.StoredProcedure, parameters.ToArray())

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
    Private Sub btnWIPLots_Click(sender As Object, e As EventArgs) Handles btnWIPLots.Click
        Dim ObjStockWipMelting As New frmStockWipLots
        ObjStockWipMelting.ShowDialog()
    End Sub
    Private Sub btnMeltingDetails_Click(sender As Object, e As EventArgs) Handles btnMeltingDetails.Click
        Dim ObjStockWipMelting As New frmStockWipMelting
        ObjStockWipMelting.ShowDialog()
    End Sub
    Private Sub btnWipLotTransferred_Click(sender As Object, e As EventArgs) Handles btnWipLotTransferred.Click
        Dim ObjStockFinishedLots As New frmStockWipLotTransferred
        ObjStockFinishedLots.ShowDialog()
    End Sub
    Private Sub btnWipFinishLots_Click(sender As Object, e As EventArgs) Handles btnWipFinishLots.Click
        Dim ObjStockFinishedLots As New frmStockFinishedLots
        ObjStockFinishedLots.ShowDialog()
    End Sub
    Private Sub btnBBagNotCreated_Click(sender As Object, e As EventArgs) Handles btnBBagNotCreated.Click
        Dim ObjStockBhukaBagNotCreated As New frmStockBhukaBagNotCreated
        ObjStockBhukaBagNotCreated.ShowDialog()
    End Sub
    Private Sub btnVBagNotCreated_Click(sender As Object, e As EventArgs) Handles btnVBagNotCreated.Click
        Dim ObjStockWipMelting As New frmStockVaccumBagNotCreated
        ObjStockWipMelting.ShowDialog()
    End Sub
    Private Sub btnSBagNotCreated_Click(sender As Object, e As EventArgs) Handles btnSBagNotCreated.Click
        Dim ObjStockSampleBagNotCreated As New frmStockSampleBagNotCreated
        ObjStockSampleBagNotCreated.ShowDialog()
    End Sub
    Private Sub btnBBagCreated_Click(sender As Object, e As EventArgs) Handles btnBBagCreated.Click
        Dim ObjStockBhukaBagCreated As New frmStockBhukaBagCreated
        ObjStockBhukaBagCreated.ShowDialog()
    End Sub
    Private Sub btnVBagCreated_Click(sender As Object, e As EventArgs) Handles btnVBagCreated.Click
        Dim ObjStockVacuumBagCreated As New frmStockVacuumBagCreated
        ObjStockVacuumBagCreated.ShowDialog()
    End Sub
    Private Sub btnSBagCreated_Click(sender As Object, e As EventArgs) Handles btnSBagCreated.Click
        Dim ObjStockSampleBagCreated As New frmStockSampleBagCreated
        ObjStockSampleBagCreated.ShowDialog()
    End Sub
    Private Sub btnVoucherMetalUnused_Click(sender As Object, e As EventArgs) Handles btnVoucherMetalUnused.Click
        Dim ObjStockMetalUnused As New frmStockMetalUnused
        ObjStockMetalUnused.ShowDialog()
    End Sub
    Private Sub btnLotAdditionStock_Click(sender As Object, e As EventArgs) Handles btnLotAdditionStock.Click
        Dim ObjStockLotAddition As New frmStockLotAddition
        ObjStockLotAddition.ShowDialog()
    End Sub
    Private Sub btnLossBags_Click(sender As Object, e As EventArgs) Handles btnLossBags.Click
        Dim ObjStockLossBags As New frmStockLossBags
        ObjStockLossBags.ShowDialog()
    End Sub
    Private Sub btnLossTransaction_Click(sender As Object, e As EventArgs) Handles btnLossTransaction.Click
        Dim ObjStockLossTransaction As New frmStockLossTransaction
        ObjStockLossTransaction.ShowDialog()
    End Sub
    Private Sub BtnLossLabs_Click(sender As Object, e As EventArgs) Handles BtnLossLabs.Click
        Dim ObjStockLossLabs As New frmStockLossLabs
        ObjStockLossLabs.ShowDialog()
    End Sub
    Private Sub btnLBagCreated_Click(sender As Object, e As EventArgs) Handles btnLBagCreated.Click
        Dim ObjStockLotFailBags As New frmStockLotFailBags
        ObjStockLotFailBags.ShowDialog()
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
    Private Sub btnBBagNotUsed_Click(sender As Object, e As EventArgs) Handles btnBBagNotUsed.Click
        Dim ObjStockBagsNotUsed As New frmStockBagsNotUsed
        ObjStockBagsNotUsed.ShowDialog()
    End Sub
    Private Sub btnDeptReceive_Click(sender As Object, e As EventArgs) Handles btnDeptReceive.Click
        Dim ObjStockLossMetalReceived As New frmStockLossMetalReceived
        ObjStockLossMetalReceived.ShowDialog()
    End Sub
    Private Sub GetTxtTotal()
        Dim dTotalWt As Double = 0
        Dim dTotalFw As Double = 0

        dTotalWt =
    GetValue(VoucherMetalWt.Text.Trim) +
    GetValue(LotAddStockWt.Text.Trim) +
    GetValue(txtTotalWWt.Text.Trim) +
    GetValue(txtTotalBncWt.Text.Trim) +
    GetValue(txtTotalBnrWt.Text.Trim) +
    GetValue(txtTotalBnuWt.Text.Trim) +
    GetValue(txtTotalBnusWt.Text.Trim)
        '    +
        'GetValue(txtTotalLossWt.Text.Trim)

        dTotalFw =
    GetValue(VoucherMetalFw.Text.Trim) +
    GetValue(LotAddStockFw.Text.Trim) +
    GetValue(txtTotalWFw.Text.Trim) +
    GetValue(txtTotalBncFw.Text.Trim) +
    GetValue(txtTotalBnrFw.Text.Trim) +
    GetValue(txtTotalBnuFw.Text.Trim) +
    GetValue(txtTotalBnusFw.Text.Trim)
        '    +
        'GetValue(txtTotalLossFw.Text.Trim)

        lblStockInHandGWt.Text = Format(dTotalWt, "0.00")

        lblStockInHandPr.Text = Format((Val(dTotalFw) / Val(dTotalWt)) * 100, "0.00")

        lblStockInHandFWt.Text = Format(dTotalFw, "0.00")
    End Sub
    Private Function GetValue(ByVal text As String) As Double
        If String.IsNullOrEmpty(text) Then Return 0
        Dim value As Double
        If Double.TryParse(text, value) Then Return value
        Return 0
    End Function
    Private Sub txtOpeningStockWt_TextChanged(sender As Object, e As EventArgs) Handles txtOpeningStockWt.TextChanged
        GetFinalTxtTotal()
    End Sub
    Private Sub GetFinalTxtTotal()
        Dim dTotalWt As Double = 0
        Dim dTotalFw As Double = 0
        Dim dTotalPr As Double = 0

        dTotalWt =
    GetValue(txtOpeningStockWt.Text.Trim) +
    GetValue(ReceiptGrossWt.Text.Trim) -
    GetValue(IssueGrossWt.Text.Trim)

        dTotalFw =
    GetValue(txtOpeningStockFw.Text.Trim) +
    GetValue(ReceiptGrossFw.Text.Trim) -
    GetValue(IssueGrossFw.Text.Trim)

        txtClosingStockWt.Text = Format(dTotalWt, "0.00")

        dTotalPr = Format((Val(dTotalFw) / Val(dTotalWt)) * 100, "0.00")

        txtClosingStockPr.Text = Format(dTotalPr, "0.00")

        txtClosingStockFw.Text = Format(dTotalFw, "0.00")
    End Sub
    Private Sub btnDeptIssue_Click(sender As Object, e As EventArgs) Handles btnDeptIssue.Click
        Dim ObjLessMetalIssued As New frmLessMetalIssued
        ObjLessMetalIssued.ShowDialog()
    End Sub
    Private Sub txtClosingStockWt_TextChanged(sender As Object, e As EventArgs)
        'Dim dfinalWt As Double = 0
        'Dim dFinalFw As Double = 0

        'Double.TryParse(txtClosingStockWt.Text, dfinalWt)

        'Double.TryParse(txtClosingStockFw.Text, dFinalFw)

        'If dfinalWt > 0 And dFinalFw > 0 Then
        '    lblDiffWt.Text = Val(txtClosingStockWt.Text - lblGrossWt.Text)
        '    lblDiffFw.Text = Val(txtClosingStockFw.Text - lblGrossFw.Text)
        'End If

    End Sub
    Private Sub btnShow_Click(sender As Object, e As EventArgs)
        Dim dfinalWt As Double = 0
        Dim dFinalFw As Double = 0

        Double.TryParse(txtClosingStockWt.Text, dfinalWt)

        Double.TryParse(txtClosingStockFw.Text, dFinalFw)

        'If dfinalWt > 0 And dFinalFw > 0 Then
        '    lblDiffFw.Text = Val(txtClosingStockFw.Text - lblGrossFw.Text)
        'End If
    End Sub
    Private Sub btnOpStock_Click(sender As Object, e As EventArgs) Handles btnOpStock.Click
        Dim ObjAccountOpening As New frmChAccountOpening
        ObjAccountOpening.ShowDialog()
    End Sub
    Private Sub btnLBagNotUsed_Click(sender As Object, e As EventArgs) Handles btnLBagNotUsed.Click
        Dim ObjLotFailBagNotUsed As New frmLotFailBagNotUsed
        ObjLotFailBagNotUsed.ShowDialog()
    End Sub
    Private Sub btnAccountClosing_Click(sender As Object, e As EventArgs)
        Dim strCopyDatabase As String = Nothing
        Dim strDatabaseName As String = Nothing

        'sp_post_new_database
        Dim dtData As DataTable = New DataTable()

        Try
            dtData = dbManager.GetDataTable("SP_CurrentDB_Select", CommandType.StoredProcedure)

            If dtData.Rows.Count > 0 Then
                strCopyDatabase = dtData.Rows(0).Item("CurrentDatabase")
            End If

            strDatabaseName = strCopyDatabase + Now.Month().ToString().PadLeft(2, "0")

        Catch ex As Exception
            Throw ex
        End Try

        Try
            Dim parameters = New List(Of SqlParameter)()

            With parameters
                .Clear()
                .Add(dbManager.CreateParameter("@CopyDatabase", strCopyDatabase, DbType.String))
                .Add(dbManager.CreateParameter("@DatabaseName", strDatabaseName, DbType.String))
            End With

            dbManager.GetScalarValue("SP_Post_New_Database", CommandType.StoredProcedure, parameters.ToArray())

            MessageBox.Show("New Database Created")

            Me.DeleteStock()

            Me.UpdateStock()

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try

    End Sub
    Private Sub xProcess()
        '     Dim xSql As String


        '     '==== =================Stock Clubing Process=======================================

        '     '== Swapping Process===

        '     DB.Execute "Delete TmpStockStonesDetail.* From TmpStockStonesDetail"

        ' '== Keeping Data To Temperary Table===

        '     xSql = " Insert Into TmpStockStonesDetail( Stock_ID,Category_ID,Location_ID,Item_TagNo,Packet_ID,Packet_Initial,Packet_Quantity,Packet_Weight,Packet_RateOn,Packet_Rate,Packet_Value,Packet_SalRate,Packet_SalValue,Packet_Quality,Packet_Seive,Packet_Color,Stone_ID,Quality_ID,Shape_ID) " &
        '       " SELECT StockStonesDetail.Stock_ID As Stock_ID, StockStonesDetail.Category_ID As Category_ID, StockStonesDetail.Location_ID As Location_ID , StockStonesDetail.Item_TagNo As Item_TagNo , StonesPacketMaster.Packet_ID As Packet_ID , StonesPacketMaster.Packet_Initial As Packet_Initial, Sum(StockStonesDetail.Packet_Quantity) AS Packet_Quantity, Sum(StockStonesDetail.Packet_Weight) AS Packet_Weight, StockStonesDetail.Packet_RateOn, Avg(StockStonesDetail.Packet_Rate) AS Packet_Rate, (Packet_Weight*Packet_Rate) As Packet_Value , StockStonesDetail.Packet_SalRate, StockStonesDetail.Packet_SalValue, StockStonesDetail.Packet_Quality, StockStonesDetail.Packet_Seive, StockStonesDetail.Packet_Color, StockStonesDetail.Stone_ID, StockStonesDetail.Quality_ID, StockStonesDetail.Shape_ID " &
        '       " FROM StonesPacketMaster INNER JOIN (StockStonesDetail INNER JOIN StonesPacketMaster01 ON StockStonesDetail.Packet_ID = StonesPacketMaster01.Packet_ID) ON StonesPacketMaster.Packet_ID = StonesPacketMaster01.TransferID Where StonesPacketMaster01.TransferID= " & Val(StoneTransfer.Columns("ID").value) & " " &
        '       " GROUP BY StockStonesDetail.Stock_ID, StockStonesDetail.Category_ID, StockStonesDetail.Location_ID, StockStonesDetail.Item_TagNo, StonesPacketMaster.Packet_ID, StonesPacketMaster.Packet_Initial, StockStonesDetail.Packet_RateOn, StockStonesDetail.Packet_SalRate, StockStonesDetail.Packet_SalValue, StockStonesDetail.Packet_Quality, StockStonesDetail.Packet_Seive, StockStonesDetail.Packet_Color, StockStonesDetail.Stone_ID, StockStonesDetail.Quality_ID, StockStonesDetail.Shape_ID"

        '     DB.Execute xSql

        ' '== Removing Data From Real Table==

        '     xSql = " DELETE StockStonesDetail.*, StonesPacketMaster01.TransferID" &
        '        " FROM StockStonesDetail INNER JOIN StonesPacketMaster01 ON StockStonesDetail.Packet_ID = StonesPacketMaster01.Packet_ID " &
        '        " WHERE (((StonesPacketMaster01.TransferID)=" & Val(StoneTransfer.Columns("ID").value) & "   ))"

        '     DB.Execute xSql

        ' '=== Transfering Data From Temperary Table To Real Table===

        '     xSql = " insert into StockStonesDetail(Stock_ID,Category_ID,Location_ID,Item_TagNo,Packet_ID,Packet_Initial,Packet_Description,Packet_Units,Packet_Type,Packet_Quantity,Packet_Weight,Packet_RateOn,Packet_Purchase,Packet_PurRate,Commission_Rate,Commission_Value,Packet_NetAmount, Packet_Rate,Packet_Value,Packet_SalRate, Packet_SalValue,Packet_Quality,Packet_Seive,Packet_Color,Stone_ID,Quality_ID,Sieve_ID) " &
        '        " SELECT TmpStockStonesDetail.Stock_ID, TmpStockStonesDetail.Category_ID, TmpStockStonesDetail.Location_ID, TmpStockStonesDetail.Item_TagNo, TmpStockStonesDetail.Packet_ID, TmpStockStonesDetail.Packet_Initial, TmpStockStonesDetail.Packet_Description, TmpStockStonesDetail.Packet_Units, TmpStockStonesDetail.Packet_Type, TmpStockStonesDetail.Packet_Quantity, TmpStockStonesDetail.Packet_Weight, TmpStockStonesDetail.Packet_RateOn, TmpStockStonesDetail.Packet_Purchase, TmpStockStonesDetail.Packet_PurRate, TmpStockStonesDetail.Commission_Rate, TmpStockStonesDetail.Commission_Value, TmpStockStonesDetail.Packet_NetAmount, TmpStockStonesDetail.Packet_Rate, " &
        '        " TmpStockStonesDetail.Packet_Value, TmpStockStonesDetail.Packet_SalRate, TmpStockStonesDetail.Packet_SalValue, TmpStockStonesDetail.Packet_Quality, TmpStockStonesDetail.Packet_Seive, TmpStockStonesDetail.Packet_Color, TmpStockStonesDetail.Stone_ID, TmpStockStonesDetail.Quality_ID, TmpStockStonesDetail.Sieve_ID " &
        '        " FROM TmpStockStonesDetail"

        '     DB.Execute xSql

        ' '========================Loose Stones Purchase Clubing Process====================


        '     DB.Execute "Delete TmpStoneTransactionDetails.* From TmpStoneTransactionDetails"

        ' '== Keeping Data To Temperary Table===

        '     xSql = " Insert Into TmpStoneTransactionDetails( Voucher_Type,Voucher_No,Voucher_Date,Account_ID,Packet_ID,Packet_Initial,Packet_Pcs,Packet_Weight,Packet_Rate,Packet_Value,Packet_NetValue) " &
        '           " SELECT StoneTransactionDetails.Voucher_Type As Voucher_Type, " &
        '           " StoneTransactionDetails.Voucher_No As Voucher_No, StoneTransactionDetails.Voucher_Date As Voucher_Date , StoneTransactionDetails.Account_ID As Account_ID , " &
        '           " StonesPacketMaster.Packet_ID As Packet_ID , StonesPacketMaster.Packet_Initial As Packet_Initial, Sum(StoneTransactionDetails.Packet_Pcs) AS Packet_Pcs, Sum(StoneTransactionDetails.Packet_Weight) AS Packet_Weight, " &
        '           " Avg(StoneTransactionDetails.Packet_Rate) AS Packet_Rate, (Packet_Weight*Packet_Rate) As Packet_Value , (Packet_Weight*Packet_Rate) As Packet_NetValue  FROM StonesPacketMaster INNER JOIN (StoneTransactionDetails INNER JOIN StonesPacketMaster01 ON StoneTransactionDetails.Packet_ID = StonesPacketMaster01.Packet_ID) ON StonesPacketMaster.Packet_ID = StonesPacketMaster01.TransferID Where StonesPacketMaster01.TransferID= " & Val(StoneTransfer.Columns("ID").value) & " GROUP BY StoneTransactionDetails.Voucher_Type, StoneTransactionDetails.Voucher_No, StoneTransactionDetails.Voucher_Date,StoneTransactionDetails.Account_ID," &
        '           " StonesPacketMaster.Packet_ID , StonesPacketMaster.Packet_Initial"


        '     DB.Execute xSql

        ' '== Removing Data From Real Table==

        '     xSql = " DELETE StoneTransactionDetails.*, StonesPacketMaster01.TransferID" &
        '        " FROM StoneTransactionDetails INNER JOIN StonesPacketMaster01 ON StoneTransactionDetails.Packet_ID = StonesPacketMaster01.Packet_ID " &
        '        " WHERE (((StonesPacketMaster01.TransferID)=" & Val(StoneTransfer.Columns("ID").value) & "   ))"

        '     DB.Execute xSql


        ' '=== Transfering Data From Temperary Table To Real Table===

        '     xSql = " Insert Into StoneTransactionDetails( Voucher_Type,Voucher_No,Voucher_Date,Account_ID,Packet_ID,Packet_Initial,Packet_Pcs, " &
        '         " Packet_Weight,Packet_Rate,Packet_Value,Packet_NetValue)" &
        '         " SELECT TmpStoneTransactionDetails.Voucher_Type As Voucher_Type, TmpStoneTransactionDetails.Voucher_No As Voucher_No, TmpStoneTransactionDetails.Voucher_Date As Voucher_Date ,TmpStoneTransactionDetails.Account_ID As Account_ID , TmpStoneTransactionDetails.Packet_ID As Packet_ID , TmpStoneTransactionDetails.Packet_Initial As Packet_Initial,TmpStoneTransactionDetails.Packet_Pcs AS Packet_Pcs, TmpStoneTransactionDetails.Packet_Weight AS Packet_Weight,TmpStoneTransactionDetails.Packet_Rate  AS Packet_Rate,TmpStoneTransactionDetails.Packet_Value  As Packet_Value ,TmpStoneTransactionDetails.Packet_NetValue As Packet_NetValue  From TmpStoneTransactiondetails "

        '     DB.Execute xSql

        ' '=========================== Setting Stones Details=====================

        '     '== Swapping Process===

        '     DB.Execute "Delete TmpSettingStoneDetail.* From TmpSettingStoneDetail"

        ' '== Keeping Data To Temperary Table===

        '     xSql = " Insert Into TmpSettingStoneDetail( Setting_Type,SEntry_ID,Item_ID,Item_TagNo,Item_Serial,Item_Date,Emp_ID,Entry_Type,Issue_Type,Packet_ID,Packet_Initial,Packet_Pcs,Packet_Weight,Packet_Rate,Packet_Amount,Packet_Count) " &
        '       " SELECT SettingStoneDetails.Setting_Type As Setting_Type,SettingStoneDetails.SEntry_ID As SEntry_ID, SettingStoneDetails.Item_ID As Item_ID , SettingStoneDetails.Item_TagNo As Item_TagNo ,SettingStoneDetails.Item_Serial As Item_Serial,SettingStoneDetails.Item_Date,SettingStoneDetails.Emp_ID As Emp_ID ,SettingStoneDetails.Entry_Type As Entry_Type,SettingStoneDetails.Issue_Type As Issue_Type, StonesPacketMaster.Packet_ID As Packet_ID , StonesPacketMaster.Packet_Initial As Packet_Initial, Sum(SettingStoneDetails.Packet_Pcs) AS Packet_Pcs, Sum(SettingStoneDetails.Packet_Weight) AS Packet_Weight, Avg(SettingStoneDetails.Packet_Rate) AS Packet_Rate, (Packet_Weight*Packet_Rate) As Packet_Amount , SettingStoneDetails.Packet_Count " &
        '       " FROM StonesPacketMaster INNER JOIN (SettingStoneDetails INNER JOIN StonesPacketMaster01 ON SettingStoneDetails.Packet_ID = StonesPacketMaster01.Packet_ID) ON StonesPacketMaster.Packet_ID = StonesPacketMaster01.TransferID Where StonesPacketMaster01.TransferID= " & Val(StoneTransfer.Columns("ID").value) & " " &
        '       " GROUP BY SettingStoneDetails.Setting_Type, SettingStoneDetails.SEntry_ID, SettingStoneDetails.Item_ID, SettingStoneDetails.Item_TagNo,SettingStoneDetails.Item_Serial,SettingStoneDetails.Item_Date,SettingStoneDetails.Emp_ID,SettingStoneDetails.Entry_Type,SettingStoneDetails.Issue_Type,StonesPacketMaster.Packet_ID, StonesPacketMaster.Packet_Initial,SettingStoneDetails.Packet_Count"

        '     DB.Execute xSql

        ' '== Removing Data From Real Table==

        '     xSql = " DELETE SettingStoneDetails.*, StonesPacketMaster01.TransferID" &
        '        " FROM SettingStoneDetails INNER JOIN StonesPacketMaster01 ON SettingStoneDetails.Packet_ID = StonesPacketMaster01.Packet_ID " &
        '        " WHERE (((StonesPacketMaster01.TransferID)=" & Val(StoneTransfer.Columns("ID").value) & "   ))"

        '     DB.Execute xSql

        ' '=== Transfering Data From Temperary Table To Real Table===

        '     xSql = " insert into SettingStoneDetails(Setting_Type,SEntry_ID,Item_ID,Item_TagNo,Item_Serial,Item_Date,Emp_ID,Entry_Type,Issue_Type,Packet_ID,Packet_Initial,Packet_Pcs,Packet_Weight,Packet_Rate,Packet_Amount,Packet_Count) " &
        '        " SELECT TmpSettingStoneDetail.Setting_Type, TmpSettingStoneDetail.SEntry_ID, TmpSettingStoneDetail.Item_ID, TmpSettingStoneDetail.Item_TagNo,TmpSettingStoneDetail.Item_Serial,TmpSettingStoneDetail.Item_Date,TmpSettingStoneDetail.Emp_ID,TmpSettingStoneDetail.Entry_Type,TmpSettingStoneDetail.Issue_Type,TmpSettingStoneDetail.Packet_ID, TmpSettingStoneDetail.Packet_Initial,TmpSettingStoneDetail.Packet_Pcs, TmpSettingStoneDetail.Packet_Weight,TmpSettingStoneDetail.Packet_Rate,TmpSettingStoneDetail.Packet_Amount, " &
        '        " TmpSettingStoneDetail.Packet_Count " &
        '        " FROM TmpSettingStoneDetail"

        '     DB.Execute xSql


        ''========================== SetterDetails========================

        '     '== Swapping Process===

        '     DB.Execute "Delete TmpSettersDetails.* From TmpSettersDetails"

        ' '== Keeping Data To Temperary Table===

        '     xSql = " Insert Into TmpSettersDetails( SEntry_ID,Emp_ID,Item_Date,Item_Id,Item_TagNo,Packet_ID,Packet_Initial,Packet_Pcs,Packet_Weight,Packet_CreditPcs) " &
        '       " SELECT SettersDetails.SEntry_ID As SEntry_ID,SettersDetails.Emp_ID As Emp_ID, SettersDetails.Item_Date As Item_Date, SettersDetails.Item_Id As Item_Id , SettersDetails.Item_TagNo As Item_TagNo , StonesPacketMaster.Packet_ID As Packet_ID , StonesPacketMaster.Packet_Initial As Packet_Initial, " &
        '       " Sum(SettersDetails.Packet_Pcs) AS Packet_Pcs, Sum(SettersDetails.Packet_Weight) AS Packet_Weight, Sum(SettersDetails.Packet_CreditPcs) As Packet_CreditPcs " &
        '       " FROM StonesPacketMaster INNER JOIN (SettersDetails INNER JOIN StonesPacketMaster01 ON SettersDetails.Packet_ID = StonesPacketMaster01.Packet_ID) ON StonesPacketMaster.Packet_ID = StonesPacketMaster01.TransferID Where StonesPacketMaster01.TransferID= " & Val(StoneTransfer.Columns("ID").value) & " " &
        '       " GROUP BY SettersDetails.SEntry_ID ,SettersDetails.Emp_ID, SettersDetails.Item_Date , SettersDetails.Item_Id , SettersDetails.Item_TagNo , StonesPacketMaster.Packet_ID , StonesPacketMaster.Packet_Initial "

        '     DB.Execute xSql

        ' '== Removing Data From Real Table==

        '     xSql = " DELETE SettersDetails.*, StonesPacketMaster01.TransferID" &
        '        " FROM SettersDetails INNER JOIN StonesPacketMaster01 ON SettersDetails.Packet_ID = StonesPacketMaster01.Packet_ID " &
        '        " WHERE (((StonesPacketMaster01.TransferID)=" & Val(StoneTransfer.Columns("ID").value) & "   ))"

        '     DB.Execute xSql

        ' '=== Transfering Data From Temperary Table To Real Table===

        '     xSql = " insert into SettersDetails(SEntry_ID,Emp_ID,Item_Date,Item_Id,Item_TagNo,Packet_ID,Packet_Initial,Packet_Pcs,Packet_Weight,Packet_CreditPcs) " &
        '        " SELECT TmpSettersDetails.SEntry_ID, TmpSettersDetails.Emp_ID, TmpSettersDetails.Item_Date, TmpSettersDetails.Item_Id,TmpSettersDetails.Item_TagNo,TmpSettersDetails.Packet_ID, TmpSettersDetails.Packet_Initial, " &
        '        " TmpSettersDetails.Packet_Pcs, TmpSettersDetails.Packet_Weight, TmpSettersDetails.Packet_CreditPcs " &
        '        " FROM TmpSettersDetails"

        '     DB.Execute xSql

    End Sub
    Private Sub DeleteStock()
        Try

            dbManager.Delete("SP_StockDetails_Delete", CommandType.StoredProcedure)

            MessageBox.Show("Data Deleted !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub UpdateStock()
        Try

            dbManager.Delete("SP_StockDetails_Update", CommandType.StoredProcedure)

            MessageBox.Show("Data Updated !!!", "Chain", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        End Try
    End Sub
    Private Sub btnLBagNotUpdated_Click(sender As Object, e As EventArgs) Handles btnLBagNotUpdated.Click
        Dim ObjLotFailBagNotUpdated As New frmLotFailBagNotUpdated
        ObjLotFailBagNotUpdated.ShowDialog()
    End Sub
    Private Sub btnBBagNotUpdated_Click(sender As Object, e As EventArgs) Handles btnBBagNotUpdated.Click
        Dim ObjBhukaBagNotUpdated As New frmBhukaBagNotUpdated
        ObjBhukaBagNotUpdated.ShowDialog()
    End Sub
    Private Sub TotalWIPTotal()
        txtTotalWWt.Text = Format(Val(WipLGrossWt.Text.Trim) + Val(WipMGrossWt.Text.Trim) + Val(WipTGrossWt.Text.Trim) + Val(WipFGrossWt.Text.Trim), "0.00")
        txtTotalWFw.Text = Format(Val((WipLGrossFw.Text.Trim) + Val(WipMGrossFw.Text.Trim) + Val(WipTGrossFw.Text.Trim) + Val(WipFGrossFw.Text.Trim)), "0.00")

        If Val(txtTotalWFw.Text) > 0 Then
            txtTotalWPr.Text = Format(CDbl((txtTotalWFw.Text.Trim) / (txtTotalWWt.Text.Trim) * 100), "0.00")
        Else
            txtTotalWPr.Text = "0.00"
        End If
    End Sub
    Private Sub TotalBagNotCreated()
        txtTotalBncWt.Text = Format(Val(BhukaBagNCWt.Text.Trim) + Val(VacuumBagNCWt.Text.Trim) + Val(SampleBagNCWt.Text.Trim), "0.00")
        txtTotalBncFw.Text = Format(Val(BhukaBagNCFw.Text.Trim) + Val(VacuumBagNCFw.Text.Trim) + Val(SampleBagNCFw.Text.Trim), "0.00")

        If Val(txtTotalBncFw.Text) > 0 Then
            txtTotalBncPr.Text = Format(CDbl((txtTotalBncFw.Text.Trim) / (txtTotalBncWt.Text.Trim) * 100), "0.00")
        Else
            txtTotalBncPr.Text = "0.00"
        End If
    End Sub
    Private Sub TotalBagNotReceived()
        txtTotalBnrWt.Text = Format(Val(BhukaBagNrWt.Text.Trim) + Val(VacuumBagWt.Text.Trim) + Val(SampleBagWt.Text.Trim) + Val(LotFailBagWt.Text.Trim), "0.00")
        txtTotalBnrFw.Text = Format(Val(BhukaBagNrFw.Text.Trim) + Val(VacuumBagFw.Text.Trim) + Val(SampleBagFw.Text.Trim) + Val(LotFailBagFw.Text.Trim), "0.00")

        If Val(txtTotalBnrFw.Text) > 0 Then
            txtTotalBnrPr.Text = Format(CDbl((txtTotalBnrFw.Text.Trim) / (txtTotalBnrWt.Text.Trim) * 100), "0.00")
        Else
            txtTotalBnrPr.Text = "0.00"
        End If
    End Sub
    Private Sub TotalBagNotUpdated()
        txtTotalBnuWt.Text = Format(Val(BhukaBagNuWt.Text.Trim) + Val(VacuumBagNuWt.Text.Trim) + Val(SampleBagNuWt.Text.Trim) + Val(LotFailBagNuWt.Text.Trim), "0.00")
        txtTotalBnuFw.Text = Format(Val(BhukaBagNuFw.Text.Trim) + Val(VacuumBagNuFw.Text.Trim) + Val(SampleBagNuFw.Text.Trim) + Val(LotFailBagNuFw.Text.Trim), "0.00")

        If Val(txtTotalBnuFw.Text) > 0 Then
            txtTotalBnuPr.Text = Format(CDbl((txtTotalBnuFw.Text.Trim) / (txtTotalBnuWt.Text.Trim) * 100), "0.00")
        Else
            txtTotalBnuPr.Text = "0.00"
        End If
    End Sub

    Private Sub TotalBagNotUsed()
        txtTotalBnusWt.Text = Format(Val(BhukaBagUWt.Text.Trim) + Val(VacuumBagUWt.Text.Trim) + Val(SampleBagUWt.Text.Trim) + Val(LotFailBagUWt.Text.Trim), "0.00")
        txtTotalBnusFw.Text = Format(Val(BhukaBagUFw.Text.Trim) + Val(VacuumBagUFw.Text.Trim) + Val(SampleBagUFw.Text.Trim) + Val(LotFailBagUFw.Text.Trim), "0.00")

        If Val(txtTotalBnuFw.Text) > 0 Then
            txtTotalBnusPr.Text = Format(CDbl((txtTotalBnusFw.Text.Trim) / (txtTotalBnusWt.Text.Trim) * 100), "0.00")
        Else
            txtTotalBnusPr.Text = "0.00"
        End If
    End Sub
    Private Sub TotalLosswt()
        txtTotalLossWt.Text = Format(Val(LossBagsWt.Text.Trim) + Val(LossTransWt.Text.Trim) + Val(LabReceiveWt.Text.Trim), "0.00")
        txtTotalLossFw.Text = Format(Val(LossBagsFw.Text.Trim) + Val(LossTransFw.Text.Trim) + Val(LabReceiveFw.Text.Trim), "0.00")

        If Val(txtTotalBnuFw.Text) > 0 Then
            txtTotalLossPr.Text = Format(CDbl((txtTotalLossFw.Text.Trim) / (txtTotalLossWt.Text.Trim) * 100), "0.00")
        Else
            txtTotalLossPr.Text = "0.00"
        End If

    End Sub
    Private Sub BtnCDailyStock_Click(sender As Object, e As EventArgs) Handles BtnCDailyStock.Click
        Me.SaveData()
        Me.Close()
        Dim ObjScrapBagNotUpdate As New frmCStockLogin
        ObjScrapBagNotUpdate.ShowDialog()
    End Sub
    Private Sub SaveData()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim parameters = New List(Of SqlParameter)()
            parameters.Clear()

            With parameters
                '.Add(dbManager.CreateParameter("@ActionType", "SaveData", DbType.String))

                .Add(dbManager.CreateParameter("@DVoucherMetalUnUsed", VoucherMetalWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DLotAdditionStock", LotAddStockWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DWIPLots", WipLGrossWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DWIPMelting", WipMGrossWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DWIPLotsTransfered", WipTGrossWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DFinishedLots", WipFGrossWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DScrapBagNotCreated", BhukaBagNCWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DVacuumBagNotCreated", VacuumBagNCWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DSampleBagNotCreated", SampleBagNCWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DScrapBagNotReceived", BhukaBagNrWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DExtraScrapBagNotReceived", VacuumBagWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DVacuumBagNotReceived", VacuumBagWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DSampleBagNotReceived", SampleBagWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DLotFailBagNotReceived", LotFailBagWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DScrapBagNotUpdated", BhukaBagNuWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DVacuumBagNotUpdated", VacuumBagNuWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DSampleBagNotUpdated", SampleBagNuWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DLotFailBagNotUpdated", LotFailBagNuWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DScrapBagNotUsed", BhukaBagUWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DVacuumBagNotUsed", VacuumBagUWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DSampleBagNotUsed", SampleBagUWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DLotFailBagNotUsed", LotFailBagUWt.Text.Trim, DbType.String))
                .Add(dbManager.CreateParameter("@DStockInHand", lblStockInHandGWt.Text.Trim, DbType.String))
            End With

            dbManager.Insert("SP_DailyStock_Save", CommandType.StoredProcedure, parameters.ToArray())

        Catch ex As Exception
            MessageBox.Show("Error:- " & ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub

    Private Sub btnVBagNotUpdated_Click(sender As Object, e As EventArgs) Handles btnVBagNotUpdated.Click

    End Sub
End Class