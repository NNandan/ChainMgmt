Imports System.Windows.Forms
Imports JMS.Common_Cls
Public Class frmMain
    Private Sub LabourMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LabourMasterToolStripMenuItem.Click
        Try
            Dim ObjLabour As New frmKarigarMaster
            ObjLabour.MdiParent = Me
            ObjLabour.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub AccountMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountMasterToolStripMenuItem.Click
        Try
            Dim ObjAccount As New frmAccountMaster
            ObjAccount.MdiParent = Me
            ObjAccount.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CategoryMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoryMasterToolStripMenuItem.Click
        Try
            Dim ObjCategory As New frmCategoryMaster
            ObjCategory.MdiParent = Me
            ObjCategory.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OperationMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChOperationMasterToolStripMenuItem.Click
        Try
            Dim ObjOperation As New frmChOperationMaster
            ObjOperation.MdiParent = Me
            ObjOperation.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ItemMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemMasterToolStripMenuItem.Click
        Try
            Dim ObjItem As New frmItemMaster
            ObjItem.MdiParent = Me
            ObjItem.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub MeltingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChMeltingToolStripMenuItem.Click
        Try
            Dim ObjMelting As New frmMelting
            ObjMelting.MdiParent = Me
            ObjMelting.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FamilyMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FamilyMasterToolStripMenuItem.Click
        Try
            Dim ObjFamily As New frmFamilyMaster
            ObjFamily.MdiParent = Me
            ObjFamily.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LotNoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotNoToolStripMenuItem.Click
        Try
            Dim ObjLotNo As New frmLotNo
            ObjLotNo.MdiParent = Me
            ObjLotNo.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub MainToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MainToolStripMenuItem.Click
        Try
            Dim ObjMainChart As New frmMainChart
            ObjMainChart.MdiParent = Me
            ObjMainChart.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LotTransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotTransferToolStripMenuItem.Click
        Try
            Dim ObjILotTransfer As New frmILotTransfer
            ObjILotTransfer.MdiParent = Me
            ObjILotTransfer.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UsedLotTransferedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsedLotTransferedToolStripMenuItem.Click
        Try
            Dim ObjRLotTransfer As New frmRLotTransfer
            ObjRLotTransfer.MdiParent = Me
            ObjRLotTransfer.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CreateBhukaBagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChScrapBagsToolStripMenuItem.Click
        Try
            Dim ObjbukaBag As New frmBhukaBag
            ObjbukaBag.MdiParent = Me
            ObjbukaBag.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LabIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LabIssueToolStripMenuItem.Click
        Try
            Dim ObjLabIssue As New frmLabIssue
            ObjLabIssue.MdiParent = Me
            ObjLabIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LabMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LabMasterToolStripMenuItem.Click
        Try
            Dim ObjLabMaster As New frmLabMaster
            ObjLabMaster.MdiParent = Me
            ObjLabMaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        For Each ctl As Control In Me.Controls
            Try
                Dim Mdi As System.Windows.Forms.Control = CType(ctl, MdiClient)
                Mdi.BackColor = System.Drawing.Color.White
            Catch a As Exception
            End Try
        Next

        Me.Width = Screen.PrimaryScreen.WorkingArea.Width
        Me.Height = Screen.PrimaryScreen.WorkingArea.Height

        Left = Top = 0
    End Sub
    Private Sub User_Grant()
        'If User_Level = 2 Then
        '    Mnu_Mast.Enabled = False
        '    Mnu_Util_HouseKeeping.Enabled = False
        'End If
    End Sub
    Private Sub LotFailBagToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotFailBagToolStripMenuItem.Click
        Try
            Dim ObjLotFail As New frmLotFailBag
            ObjLotFail.MdiParent = Me
            ObjLotFail.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub UserMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserMasterToolStripMenuItem.Click
        Try
            Dim ObjUserMaster As New frmUserMaster
            ObjUserMaster.MdiParent = Me
            ObjUserMaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub VaccumeBagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChVacuumBagsToolStripMenuItem.Click
        Try
            Dim ObjVaccumeBag As New frmVaccumBag
            ObjVaccumeBag.MdiParent = Me
            ObjVaccumeBag.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DepartmentReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartmentReceiptToolStripMenuItem.Click
        Try
            Dim ObjInterDeptReceipt As New frmInterDeptReceipt
            ObjInterDeptReceipt.MdiParent = Me
            ObjInterDeptReceipt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub DepartmentIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepartmentIssueToolStripMenuItem.Click
        Try
            Dim ObjInterDeptIssue As New frmInterDeptIssue
            ObjInterDeptIssue.MdiParent = Me
            ObjInterDeptIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SampleBagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SampleBagsToolStripMenuItem.Click
        Try
            Dim ObjSampleBag As New frmSampleBag
            ObjSampleBag.MdiParent = Me
            ObjSampleBag.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ReportByBagNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportByBagNumberToolStripMenuItem.Click
        Try
            Dim ObjRptBhukaBagByNumber As New frmBhukaBagByNumber
            ObjRptBhukaBagByNumber.MdiParent = Me
            ObjRptBhukaBagByNumber.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LotAdditionReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotAdditionReceiptToolStripMenuItem.Click
        Try
            Dim ObjLotAdditionReceive As New frmLotAdditionReceive
            ObjLotAdditionReceive.MdiParent = Me
            ObjLotAdditionReceive.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LotAdditionIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotAdditionIssueToolStripMenuItem.Click
        Try
            Dim ObjLotAdditionIssue As New frmLotAdditionIssue
            ObjLotAdditionIssue.MdiParent = Me
            ObjLotAdditionIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LotAdditionCreateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotAdditionCreateToolStripMenuItem.Click
        Try
            Dim ObjNewLotAddition As New frmLotAdditionNew
            ObjNewLotAddition.MdiParent = Me
            ObjNewLotAddition.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportToolStripMenuItem.Click
        Try
            Dim ObjMetalUsedReport As New frmMetalUsedReport
            ObjMetalUsedReport.MdiParent = Me
            ObjMetalUsedReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LotTransferReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotTransferReportToolStripMenuItem.Click
        Try
            Dim ObjRptLotTransfer As New frmRptLotTransfer
            ObjRptLotTransfer.MdiParent = Me
            ObjRptLotTransfer.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OfficeIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OfficeIssueToolStripMenuItem.Click
        Try
            Dim ObjRptOfficeIssue As New frmRptIssueDept
            ObjRptOfficeIssue.MdiParent = Me
            ObjRptOfficeIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OfficeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OfficeToolStripMenuItem.Click
        Try
            Dim ObjRptOfficeReceive As New frmRptReceiveDept
            ObjRptOfficeReceive.MdiParent = Me
            ObjRptOfficeReceive.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LotFailReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotFailReportToolStripMenuItem.Click
        Try
            Dim ObjRptLotFail As New frmRptLotFail
            ObjRptLotFail.MdiParent = Me
            ObjRptLotFail.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SampleReportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim ObjRptSample As New frmSamplesRpt
            ObjRptSample.MdiParent = Me
            ObjRptSample.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub HelpMenu_Click(sender As Object, e As EventArgs)
        End
    End Sub
    Private Sub WIPLotNoWiseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WIPLotNoWiseToolStripMenuItem.Click
        Try
            Dim ObjWIPLotNoWise As New frmWIPLotNoWise
            ObjWIPLotNoWise.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub PartyMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PartyMasterToolStripMenuItem.Click
        Try
            Dim ObjPartyMaster As New frmPartyMaster
            ObjPartyMaster.MdiParent = Me
            ObjPartyMaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub MeltingStockReportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim ObjMeltingStockRpt As New frmMeltingStockRpt
            ObjMeltingStockRpt.MdiParent = Me
            ObjMeltingStockRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub RegisterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegisterToolStripMenuItem.Click
        'Try
        '    Dim ObjSerialKey As New frmSerialKey
        '    ObjSerialKey.MdiParent = Me
        '    ObjSerialKey.Show()
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
    Private Sub TransactionStockReportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Try
            Dim ObjTransactionStockRpt As New frmTransactionStockRpt
            ObjTransactionStockRpt.MdiParent = Me
            ObjTransactionStockRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ChangeUserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeUserToolStripMenuItem.Click
        Try
            'close all child forms
            Dim frm As Form
            For Each frm In MdiChildren
                frm.Close()
            Next

            Me.Dispose()
            frmLogin.Show()

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub VaccumBagByNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VaccumBagByNumberToolStripMenuItem.Click
        Try
            Dim ObjTransactionStockRpt As New frmVaccumBagByNumber
            ObjTransactionStockRpt.MdiParent = Me
            ObjTransactionStockRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub StockSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockSummaryToolStripMenuItem.Click
        Try
            Dim ObjStockSummary As New frmStockSummary
            ObjStockSummary.MdiParent = Me
            ObjStockSummary.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub StockIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockIssueToolStripMenuItem.Click
        Try
            Dim ObjStockIssue As New frmStockIssue
            ObjStockIssue.MdiParent = Me
            ObjStockIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub MetalUsedByBagNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MetalUsedByBagNumberToolStripMenuItem.Click
        Try
            Dim ObjMetalUsedInBag As New frmMetalUsedInBag
            ObjMetalUsedInBag.MdiParent = Me
            ObjMetalUsedInBag.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LotAdditionFinalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotAdditionFinalToolStripMenuItem.Click
        Try
            Dim ObjLotAdditionFinal As New frmLotAdditionFinal
            ObjLotAdditionFinal.MdiParent = Me
            ObjLotAdditionFinal.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LotAdditionReportToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LotAdditionReportToolStripMenuItem1.Click
        Try
            Dim ObjfrmLotAdditionRpt As New frmLotAdditionRpt
            ObjfrmLotAdditionRpt.MdiParent = Me
            ObjfrmLotAdditionRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub AllBhukaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AllBhukaToolStripMenuItem.Click
        Try
            Dim ObjAllBhukaBagReport As New frmAllBhukaBagRpt
            ObjAllBhukaBagReport.MdiParent = Me
            ObjAllBhukaBagReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub WIPLotsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WIPLotsToolStripMenuItem.Click
        'Try
        '    Dim ObjStockSummaryRuntime As New frmStockSummary
        '    ObjStockSummaryRuntime.MdiParent = Me
        '    ObjStockSummaryRuntime.Show()
        'Catch ex As Exception
        '    Throw ex
        'End Try
    End Sub
    Public Sub Childfrm_Load(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            Dim Cl_Frm As Form = DirectCast(sender, Form)
            Dim Frmname As String = ""
            '--------------------------------------------------------------------------
            Frmname = Replace(Cl_Frm.Name, "_Frm", "")
            Frmname = Replace(Frmname, "_", " ")

            '--------------------------------------------------------------------------
            Dim Childformexists As Boolean = False
            Dim btnSomething As New ToolStripButton
            Dim m As New System.Windows.Forms.Padding
            '--------------------------------------------------------------------------
            m.All = 1
            With btnSomething
                .Text = Frmname
                .Tag = Cl_Frm.Name
                .Name = Val(Cl_Frm.Tag)
                .ForeColor = Color.Cyan
                .DisplayStyle = ToolStripItemDisplayStyle.Text
                .Margin = m
            End With

        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmMain_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate
        Try
            For Each ChildForm As Form In Me.MdiChildren
                AddHandler ChildForm.FormClosed, AddressOf Me.Childfrm_Closed
                AddHandler ChildForm.Load, AddressOf Me.Childfrm_Load
            Next
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Childfrm_Closed(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Try
                'If Me.TlStrp_menuHistoryutility.Items.Count <= 5 Then Exit Sub

                'Dim Cl_Frm As Form = DirectCast(sender, Form)
                'For Each TlStrpBtn As ToolStripButton In Me.TlStrp_menuHistoryutility.Items
                '    If Cl_Frm.Name = TlStrpBtn.Tag Then
                '        Me.TlStrp_menuHistoryutility.Items.Remove(TlStrpBtn)
                '        Exit Sub
                '    End If
                'Next
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub
    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Wish To Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
            e.Cancel = True
        Else
            End
        End If
    End Sub
    Private Sub AccountOpeningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountOpeningToolStripMenuItem.Click
        'Try
        '    Dim ObjAccountOpening As New frmAccountOpening
        '    ObjAccountOpening.MdiParent = Me
        '    ObjAccountOpening.Show()
        'Catch ex As Exception

        'End Try
    End Sub
    Private Sub EditBagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditBagsToolStripMenuItem.Click
        Try
            Dim ObjEditBags As New frmEditBags
            ObjEditBags.MdiParent = Me
            ObjEditBags.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LossReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LossReportToolStripMenuItem.Click
        Try
            Dim ObjRptKarigarwiseLoss As New frmRptKarigarwiseLoss
            ObjRptKarigarwiseLoss.MdiParent = Me
            ObjRptKarigarwiseLoss.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LotAdditionOpStockToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotAdditionOpStockToolStripMenuItem.Click
        Try
            Dim ObjRptLotAdditionOpStock As New frmRptLotAdditionOpStock
            ObjRptLotAdditionOpStock.MdiParent = Me
            ObjRptLotAdditionOpStock.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub LossReportToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LossReportToolStripMenuItem1.Click
        Try
            Dim ObjLotHistory As New frmLotHistory
            ObjLotHistory.MdiParent = Me
            ObjLotHistory.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub NewSamplesReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewSamplesReportToolStripMenuItem.Click
        Try
            Dim ObjNewSamplesReport As New frmSamplesRpt
            ObjNewSamplesReport.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub TouchConversionReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TouchConversionReportToolStripMenuItem.Click
        Try
            Dim ObjTouchConversionReport As New frmTouchConversionRpt
            ObjTouchConversionReport.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ScrapReceiveReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScrapReceiveReportToolStripMenuItem.Click
        Try
            Dim objScrapReceiveReport As New frmScrapReceiveRpt
            objScrapReceiveReport.MdiParent = Me
            objScrapReceiveReport.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CarbonReceiveReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CarbonReceiveReportToolStripMenuItem.Click
        Try
            Dim objCarbonReceiveReport As New frmCarbonReceiveRpt
            objCarbonReceiveReport.MdiParent = Me
            objCarbonReceiveReport.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub NewLabIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewLabIssueToolStripMenuItem.Click
        Try
            Dim ObjLabIssue As New frmLabIssue
            ObjLabIssue.MdiParent = Me
            ObjLabIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub EditLabIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditLabIssueToolStripMenuItem.Click
        Try
            Dim ObjEditELabIssue As New frmListLabIssue
            ObjEditELabIssue.MdiParent = Me
            ObjEditELabIssue.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        End
    End Sub
    Private Sub StockReceiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockReceiveToolStripMenuItem.Click
        Try
            Dim ObjStockReceive As New frmStockReceive
            ObjStockReceive.MdiParent = Me
            ObjStockReceive.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub MeltingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MeltingReportToolStripMenuItem.Click
        Try
            Dim ObjMeltingRpt As New frmMeltingRpt
            ObjMeltingRpt.MdiParent = Me
            ObjMeltingRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ExtraScrapReceiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExtraScrapReceiveToolStripMenuItem.Click
        Try
            Dim ObjScrapReceive As New frmScrapReceive
            ObjScrapReceive.MdiParent = Me
            ObjScrapReceive.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub StockAdditionReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockAdditionReportToolStripMenuItem.Click
        Try
            Dim ObjRptStockAddition As New frmStockAdditionRpt
            ObjRptStockAddition.MdiParent = Me
            ObjRptStockAddition.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Try
            Dim ObjRptCoreAddition As New frmCoreAdditionRpt
            ObjRptCoreAddition.MdiParent = Me
            ObjRptCoreAddition.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub BalancePendingInBagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BalancePendingInBagsToolStripMenuItem.Click
        Try
            Dim ObjPendingVoucherRpt As New frmPendingBags
            ObjPendingVoucherRpt.MdiParent = Me
            ObjPendingVoucherRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub BalancePendingInVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BalancePendingInVoucherToolStripMenuItem.Click
        Try
            Dim ObjPendingVoucher As New frmPendingVoucher
            ObjPendingVoucher.MdiParent = Me
            ObjPendingVoucher.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub StampMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StampMasterToolStripMenuItem.Click
        Try
            Dim ObjStampMaster As New frmStampMaster
            ObjStampMaster.MdiParent = Me
            ObjStampMaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub MaterialMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MaterialMasterToolStripMenuItem.Click
        Try
            Dim ObjMaterialMaster As New frmMaterialMaster
            ObjMaterialMaster.MdiParent = Me
            ObjMaterialMaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TruncateDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TruncateDataToolStripMenuItem.Click
        Try
            Dim ObjTruncateTable As New frmTruncateTable
            ObjTruncateTable.MdiParent = Me
            ObjTruncateTable.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LabReportAgainstLotNoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LabReportAgainstLotNoToolStripMenuItem.Click
        Try
            Dim ObjLabRptAgainstLotNo As New frmLabRptAgainstLotNo
            ObjLabRptAgainstLotNo.MdiParent = Me
            ObjLabRptAgainstLotNo.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TestDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestDataToolStripMenuItem.Click
        Try
            Dim ObjLabRptAgainstLotNo As New frmTest
            ObjLabRptAgainstLotNo.MdiParent = Me
            ObjLabRptAgainstLotNo.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub HollowIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HollowIssueToolStripMenuItem.Click
        Try
            Dim ObjIssueHollow As New frmIssueHollow
            ObjIssueHollow.MdiParent = Me
            ObjIssueHollow.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub HollowReceiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HollowReceiveToolStripMenuItem.Click
        Try
            Dim ObjReceiveHollow As New frmReceiveHollow
            ObjReceiveHollow.MdiParent = Me
            ObjReceiveHollow.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CoreAdditionIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoreAdditionIssueToolStripMenuItem.Click
        Try
            Dim ObjCoreAdditionIssue As New frmCoreAdditionIssueNew
            ObjCoreAdditionIssue.MdiParent = Me
            ObjCoreAdditionIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub CoreAdditionReceiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CoreAdditionReceiveToolStripMenuItem.Click
        Try
            Dim ObjCoreAdditionReceive As New frmCoreAdditionReceiveNew
            ObjCoreAdditionReceive.MdiParent = Me
            ObjCoreAdditionReceive.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub MeltingMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MeltingMasterToolStripMenuItem.Click
        Try
            Dim ObjMeltingMaster As New frmMeltingMaster
            ObjMeltingMaster.MdiParent = Me
            ObjMeltingMaster.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaOperationMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaOperationMasterToolStripMenuItem.Click
        Try
            Dim ObjFaOperation As New frmFaOperationMaster
            ObjFaOperation.MdiParent = Me
            ObjFaOperation.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FancyAccountClosingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FancyAccountClosingToolStripMenuItem.Click
        Try
            Dim ObjFaAccountOpening As New frmFaAccountClosing
            ObjFaAccountOpening.MdiParent = Me
            ObjFaAccountOpening.Show()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ChainAccountOpeningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChainAccountOpeningToolStripMenuItem.Click
        Try
            Dim ObjChAccountOpening As New frmChAccountOpening
            ObjChAccountOpening.MdiParent = Me
            ObjChAccountOpening.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FancyAccountOpeningToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FancyAccountOpeningToolStripMenuItem.Click
        Try
            Dim ObjFaAccountOpening As New frmFaAccountOpening
            ObjFaAccountOpening.MdiParent = Me
            ObjFaAccountOpening.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CreateNewLotToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreateNewLotToolStripMenuItem.Click
        Try
            Dim ObjNewLotNo As New frmNewLotNo
            ObjNewLotNo.MdiParent = Me
            ObjNewLotNo.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FDepartmentIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FDepartmentIssueToolStripMenuItem.Click
        Try
            Dim ObjFaInterDeptIssue As New frmFaInterDeptIssue
            ObjFaInterDeptIssue.MdiParent = Me
            ObjFaInterDeptIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FDepartmentReceiptToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FDepartmentReceiptToolStripMenuItem.Click
        Try
            Dim ObjFaInterDeptIssue As New frmFaInterDeptReceipt
            ObjFaInterDeptIssue.MdiParent = Me
            ObjFaInterDeptIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaMeltingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaMeltingToolStripMenuItem.Click
        Try
            Dim ObjFaMelting As New frmFaMelting
            ObjFaMelting.MdiParent = Me
            ObjFaMelting.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub EditMeltingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditMeltingToolStripMenuItem.Click
        Try
            Dim ObjEditMelting As New RdfrmEditMelting
            ObjEditMelting.MdiParent = Me
            ObjEditMelting.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaLabIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaLabIssueToolStripMenuItem.Click
        Try
            Dim ObjLabIssue As New frmFaLabIssue
            ObjLabIssue.MdiParent = Me
            ObjLabIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaOtherSampleLabToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaOtherSampleLabToolStripMenuItem.Click
        Try
            Dim ObjOLabIssue As New frmOLabIssue
            ObjOLabIssue.MdiParent = Me
            ObjOLabIssue.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaScrapBagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaScrapBagsToolStripMenuItem.Click
        Try
            Dim ObjBhukaBag As New frmFaBhukaBag
            ObjBhukaBag.MdiParent = Me
            ObjBhukaBag.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaVacuumBagsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaVacuumBagsToolStripMenuItem.Click
        Try
            Dim ObjVaccumBag As New frmFaVaccumBag
            ObjVaccumBag.MdiParent = Me
            ObjVaccumBag.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaStockSummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaStockSummaryToolStripMenuItem.Click
        Try
            Dim ObjStockSummary As New frmFaStockSummary
            ObjStockSummary.MdiParent = Me
            ObjStockSummary.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaWIPToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaWIPToolStripMenuItem.Click
        Try
            Dim ObjWIPSummaryRpt As New frmWIPSummaryRpt
            ObjWIPSummaryRpt.MdiParent = Me
            ObjWIPSummaryRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaWIPDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaWIPDetailsToolStripMenuItem.Click
        Try
            Dim ObjWIPLotDetails As New frmWIPLotDetails
            ObjWIPLotDetails.MdiParent = Me
            ObjWIPLotDetails.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaVaccumBagNotCreatedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaVaccumBagNotCreatedToolStripMenuItem.Click
        Try
            Dim ObjVaccumBagNotCreated As New frmStockVaccumBagNotCreated
            ObjVaccumBagNotCreated.MdiParent = Me
            ObjVaccumBagNotCreated.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FaVaccumBagsCreatedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaVaccumBagsCreatedToolStripMenuItem.Click
        Try
            Dim ObjVaccumBagRpt As New frmFaVaccumBagRpt
            ObjVaccumBagRpt.MdiParent = Me
            ObjVaccumBagRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaScrapBagsCreatedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaScrapBagsCreatedToolStripMenuItem.Click
        Try
            Dim ObjStockBhukaBagCreated As New frmFaStockBhukaBagCreated
            ObjStockBhukaBagCreated.MdiParent = Me
            ObjStockBhukaBagCreated.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaBalancePendingInVoucherToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FaBalancePendingInVoucherToolStripMenuItem1.Click
        Try
            Dim ObjPendingBagRpt As New frmFaPendingVoucherRpt
            ObjPendingBagRpt.MdiParent = Me
            ObjPendingBagRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaBalancePendingInBagsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FaBalancePendingInBagsToolStripMenuItem1.Click
        Try
            Dim ObjBalancePendingBags As New frmFaBalancePendingBags
            ObjBalancePendingBags.MdiParent = Me
            ObjBalancePendingBags.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaVoucherNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaVoucherNumberToolStripMenuItem.Click
        Try
            Dim ObjMetalUsedReport As New frmFaMetalUsedReport
            ObjMetalUsedReport.MdiParent = Me
            ObjMetalUsedReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaBagNumberToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaBagNumberToolStripMenuItem.Click
        Try
            Dim ObjMetalUsedInBag As New frmFaMetalUsedInBag
            ObjMetalUsedInBag.MdiParent = Me
            ObjMetalUsedInBag.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaStockAddMeltingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaStockAddMeltingToolStripMenuItem.Click
        Try
            Dim ObjStockAdditionReport As New frmFaStockAdditionMReport
            ObjStockAdditionReport.MdiParent = Me
            ObjStockAdditionReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaStockAddVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaStockAddVoucherToolStripMenuItem.Click
        Try
            Dim ObjStockAdditionReport As New frmFaStockAdditionVReport
            ObjStockAdditionReport.MdiParent = Me
            ObjStockAdditionReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaStockAddIssueReceiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaStockAddIssueReceiveToolStripMenuItem.Click
        Try
            Dim ObjStockAdditionReport As New frmFaStockAdditionIReport
            ObjStockAdditionReport.MdiParent = Me
            ObjStockAdditionReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaStockSubMeltingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FaStockSubMeltingToolStripMenuItem1.Click
        Try
            Dim ObjStockAdditionReport As New frmFaStockSubtractionMSReport
            ObjStockAdditionReport.MdiParent = Me
            ObjStockAdditionReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaStockSubVoucherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaStockSubVoucherToolStripMenuItem.Click
        Try
            Dim ObjStocksubtractionReport As New frmFaStockSubtractionVSReport
            ObjStocksubtractionReport.MdiParent = Me
            ObjStocksubtractionReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaStockSubIssueReceiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaStockSubIssueReceiveToolStripMenuItem.Click
        Try
            Dim ObjStocksubtractionReport As New frmFaStockSubtractionISReport
            ObjStocksubtractionReport.MdiParent = Me
            ObjStocksubtractionReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaInterDeptIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaInterDeptIssueToolStripMenuItem.Click
        Try
            Dim ObjInterDeptIssueRpt As New frmFaInterDeptIssueRpt
            ObjInterDeptIssueRpt.MdiParent = Me
            ObjInterDeptIssueRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaInterDeptReceiveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaInterDeptReceiveToolStripMenuItem.Click
        Try
            Dim ObjStockLossMetalReceived As New frmFaStockLossMetalReceived
            ObjStockLossMetalReceived.MdiParent = Me
            ObjStockLossMetalReceived.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LabourwiseLossToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LabourwiseLossToolStripMenuItem.Click
        Try
            Dim ObjKarigarwiseLossRpt As New frmFaKarigarwiseLossRpt
            ObjKarigarwiseLossRpt.MdiParent = Me
            ObjKarigarwiseLossRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub MeltingwiseLossToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MeltingwiseLossToolStripMenuItem.Click
        Try
            Dim ObjMeltingwiseLossRpt As New frmFaMeltingwiseLossRpt
            ObjMeltingwiseLossRpt.MdiParent = Me
            ObjMeltingwiseLossRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OperationWiseLossToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperationWiseLossToolStripMenuItem.Click
        Try
            Dim ObjOperationwiseLossRpt As New frmFaOperationwiseLossRpt
            ObjOperationwiseLossRpt.MdiParent = Me
            ObjOperationwiseLossRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LotNowiseLossToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LotNowiseLossToolStripMenuItem.Click
        Try
            Dim ObjLotNowiseLossRpt As New frmFaLotNowiseLossRpt
            ObjLotNowiseLossRpt.MdiParent = Me
            ObjLotNowiseLossRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaLotHistoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaLotHistoryToolStripMenuItem.Click
        Try
            Dim ObjLotHistoryRpt As New frmFaLotHistoryRpt
            ObjLotHistoryRpt.MdiParent = Me
            ObjLotHistoryRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaDetailsOfAllLotsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaDetailsOfAllLotsToolStripMenuItem.Click
        Try
            Dim ObjAllLotsRpt As New frmFaAllLotsRpt
            ObjAllLotsRpt.MdiParent = Me
            ObjAllLotsRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FaMeltingReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaMeltingReportToolStripMenuItem.Click
        Try
            Dim ObjMeltingRpt As New frmFaMeltingRpt
            ObjMeltingRpt.MdiParent = Me
            ObjMeltingRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaMeltingAlloyReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaMeltingAlloyReportToolStripMenuItem.Click
        Try
            Dim ObjMeltingAlloyReport As New frmFaMeltingAlloyReport
            ObjMeltingAlloyReport.MdiParent = Me
            ObjMeltingAlloyReport.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaWorkDoneReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaWorkDoneReportToolStripMenuItem.Click
        Try
            Dim ObjWorkDoneRpt As New frmFaWorkDoneRpt
            ObjWorkDoneRpt.MdiParent = Me
            ObjWorkDoneRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub FaMeltingSilverReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FaMeltingSilverReportToolStripMenuItem.Click
        Try
            Dim ObjSilverMeltingRpt As New frmFaSilverMeltingRpt
            ObjSilverMeltingRpt.MdiParent = Me
            ObjSilverMeltingRpt.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub IssueReceiveHandmadeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IssueReceiveHandmadeToolStripMenuItem.Click
        Try
            Dim ObjIssueReceive As New frmFaIssueReceive
            ObjIssueReceive.MdiParent = Me
            ObjIssueReceive.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub FancyStockIssueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FancyStockIssueToolStripMenuItem.Click
        Try
            Dim ObjIssueReceive As New frmFaStockIssue
            ObjIssueReceive.MdiParent = Me
            ObjIssueReceive.Show()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TreeMakingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TreeMakingToolStripMenuItem.Click
        Try
            Dim ObjBackup As New frmGTreeMaking
            ObjBackup.MdiParent = Me
            ObjBackup.Show()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ConvFactorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConvFactorToolStripMenuItem.Click
        Try
            Dim ObjBackup As New frmGConvFactor
            ObjBackup.MdiParent = Me
            ObjBackup.Show()
        Catch ex As Exception

        End Try
    End Sub
End Class
