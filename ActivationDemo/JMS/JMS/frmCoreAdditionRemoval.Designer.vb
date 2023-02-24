<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmCoreAdditionRemoval
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.cmbTLabour = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmbLotNo = New Telerik.WinControls.UI.RadDropDownList()
        Me.PnlDetails = New System.Windows.Forms.Panel()
        Me.txtLossWt = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCoreRemains = New System.Windows.Forms.TextBox()
        Me.txtTargetGoldWeight = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtMeltingPr = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtReceiveTotalFine = New System.Windows.Forms.TextBox()
        Me.txtReceiveTotalPr = New System.Windows.Forms.TextBox()
        Me.txtReceiveTotalGross = New System.Windows.Forms.TextBox()
        Me.txtReceiveSampleFine = New System.Windows.Forms.TextBox()
        Me.txtReceiveSamplePr = New System.Windows.Forms.TextBox()
        Me.txtSampleReceiveWt = New System.Windows.Forms.TextBox()
        Me.txtReceiveBhukaFine = New System.Windows.Forms.TextBox()
        Me.txtReceiveBhukaPr = New System.Windows.Forms.TextBox()
        Me.txtBhukaReceiveWt = New System.Windows.Forms.TextBox()
        Me.txtReceiveFine = New System.Windows.Forms.TextBox()
        Me.txtReceivePr = New System.Windows.Forms.TextBox()
        Me.txtChainReceiveWt = New System.Windows.Forms.TextBox()
        Me.txtIssueFine = New System.Windows.Forms.TextBox()
        Me.txtIssuePercent = New System.Windows.Forms.TextBox()
        Me.txtIssueWeight = New System.Windows.Forms.TextBox()
        Me.lblTotalIssue = New System.Windows.Forms.Label()
        Me.txtFrKarigar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.txtTransNo = New System.Windows.Forms.TextBox()
        Me.LblLotADate = New System.Windows.Forms.Label()
        Me.lblLotNo = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstCoreAddition = New System.Windows.Forms.ListView()
        Me.cCoreAdditionId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cCoreAdditionDt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cIssueWt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cIssuePr = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cCoreIssueWt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cLotNumber = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cFrKarigar = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cfrKarigarName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cToKarigar = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ctoKarigarName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.cmbTLabour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlDetails.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(551, 366)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.btnExit)
        Me.TabPage1.Controls.Add(Me.btnCancel)
        Me.TabPage1.Controls.Add(Me.btnSave)
        Me.TabPage1.Controls.Add(Me.btnDelete)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Size = New System.Drawing.Size(543, 339)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(352, 306)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 933
        Me.btnExit.Text = "E&xit"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(275, 306)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(121, 306)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(198, 306)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 31
        Me.btnDelete.Text = "&Delete"
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.cmbTLabour)
        Me.GBoxMain.Controls.Add(Me.cmbLotNo)
        Me.GBoxMain.Controls.Add(Me.PnlDetails)
        Me.GBoxMain.Controls.Add(Me.txtFrKarigar)
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.Label2)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Controls.Add(Me.txtTransNo)
        Me.GBoxMain.Controls.Add(Me.LblLotADate)
        Me.GBoxMain.Controls.Add(Me.lblLotNo)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxMain.Location = New System.Drawing.Point(5, 8)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Size = New System.Drawing.Size(531, 293)
        Me.GBoxMain.TabIndex = 18
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Core Addition Information"
        '
        'cmbTLabour
        '
        Me.cmbTLabour.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbTLabour.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbTLabour.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbTLabour.Location = New System.Drawing.Point(393, 43)
        Me.cmbTLabour.Name = "cmbTLabour"
        Me.cmbTLabour.Size = New System.Drawing.Size(128, 20)
        Me.cmbTLabour.TabIndex = 3
        '
        'cmbLotNo
        '
        Me.cmbLotNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbLotNo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbLotNo.Location = New System.Drawing.Point(78, 49)
        Me.cmbLotNo.Name = "cmbLotNo"
        Me.cmbLotNo.Size = New System.Drawing.Size(90, 20)
        Me.cmbLotNo.TabIndex = 1
        '
        'PnlDetails
        '
        Me.PnlDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlDetails.Controls.Add(Me.txtLossWt)
        Me.PnlDetails.Controls.Add(Me.Label10)
        Me.PnlDetails.Controls.Add(Me.Label9)
        Me.PnlDetails.Controls.Add(Me.txtCoreRemains)
        Me.PnlDetails.Controls.Add(Me.txtTargetGoldWeight)
        Me.PnlDetails.Controls.Add(Me.Label8)
        Me.PnlDetails.Controls.Add(Me.txtMeltingPr)
        Me.PnlDetails.Controls.Add(Me.Label7)
        Me.PnlDetails.Controls.Add(Me.Label6)
        Me.PnlDetails.Controls.Add(Me.Label5)
        Me.PnlDetails.Controls.Add(Me.Label4)
        Me.PnlDetails.Controls.Add(Me.Label3)
        Me.PnlDetails.Controls.Add(Me.txtReceiveTotalFine)
        Me.PnlDetails.Controls.Add(Me.txtReceiveTotalPr)
        Me.PnlDetails.Controls.Add(Me.txtReceiveTotalGross)
        Me.PnlDetails.Controls.Add(Me.txtReceiveSampleFine)
        Me.PnlDetails.Controls.Add(Me.txtReceiveSamplePr)
        Me.PnlDetails.Controls.Add(Me.txtSampleReceiveWt)
        Me.PnlDetails.Controls.Add(Me.txtReceiveBhukaFine)
        Me.PnlDetails.Controls.Add(Me.txtReceiveBhukaPr)
        Me.PnlDetails.Controls.Add(Me.txtBhukaReceiveWt)
        Me.PnlDetails.Controls.Add(Me.txtReceiveFine)
        Me.PnlDetails.Controls.Add(Me.txtReceivePr)
        Me.PnlDetails.Controls.Add(Me.txtChainReceiveWt)
        Me.PnlDetails.Controls.Add(Me.txtIssueFine)
        Me.PnlDetails.Controls.Add(Me.txtIssuePercent)
        Me.PnlDetails.Controls.Add(Me.txtIssueWeight)
        Me.PnlDetails.Controls.Add(Me.lblTotalIssue)
        Me.PnlDetails.Font = New System.Drawing.Font("Palatino Linotype", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PnlDetails.Location = New System.Drawing.Point(5, 81)
        Me.PnlDetails.Name = "PnlDetails"
        Me.PnlDetails.Size = New System.Drawing.Size(519, 205)
        Me.PnlDetails.TabIndex = 4
        '
        'txtLossWt
        '
        Me.txtLossWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtLossWt.Location = New System.Drawing.Point(450, 146)
        Me.txtLossWt.Name = "txtLossWt"
        Me.txtLossWt.ReadOnly = True
        Me.txtLossWt.Size = New System.Drawing.Size(53, 22)
        Me.txtLossWt.TabIndex = 830
        Me.txtLossWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(416, 149)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 14)
        Me.Label10.TabIndex = 829
        Me.Label10.Text = "Loss"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(366, 124)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 14)
        Me.Label9.TabIndex = 828
        Me.Label9.Text = "Core Remains"
        '
        'txtCoreRemains
        '
        Me.txtCoreRemains.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtCoreRemains.Location = New System.Drawing.Point(450, 119)
        Me.txtCoreRemains.Name = "txtCoreRemains"
        Me.txtCoreRemains.ReadOnly = True
        Me.txtCoreRemains.Size = New System.Drawing.Size(53, 22)
        Me.txtCoreRemains.TabIndex = 827
        Me.txtCoreRemains.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTargetGoldWeight
        '
        Me.txtTargetGoldWeight.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtTargetGoldWeight.Location = New System.Drawing.Point(450, 91)
        Me.txtTargetGoldWeight.Name = "txtTargetGoldWeight"
        Me.txtTargetGoldWeight.ReadOnly = True
        Me.txtTargetGoldWeight.Size = New System.Drawing.Size(53, 22)
        Me.txtTargetGoldWeight.TabIndex = 826
        Me.txtTargetGoldWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(349, 95)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 14)
        Me.Label8.TabIndex = 825
        Me.Label8.Text = "Target Gold Wt."
        '
        'txtMeltingPr
        '
        Me.txtMeltingPr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtMeltingPr.Location = New System.Drawing.Point(450, 63)
        Me.txtMeltingPr.Name = "txtMeltingPr"
        Me.txtMeltingPr.ReadOnly = True
        Me.txtMeltingPr.Size = New System.Drawing.Size(53, 22)
        Me.txtMeltingPr.TabIndex = 824
        Me.txtMeltingPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(384, 68)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 14)
        Me.Label7.TabIndex = 823
        Me.Label7.Text = "Melting %"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(79, 150)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 14)
        Me.Label6.TabIndex = 822
        Me.Label6.Text = "Total Recv."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(69, 121)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 14)
        Me.Label5.TabIndex = 821
        Me.Label5.Text = "Sample Recv."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(75, 92)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 14)
        Me.Label4.TabIndex = 820
        Me.Label4.Text = "Bhuka Recv."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(79, 62)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 14)
        Me.Label3.TabIndex = 819
        Me.Label3.Text = "Chain Recv."
        '
        'txtReceiveTotalFine
        '
        Me.txtReceiveTotalFine.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveTotalFine.Location = New System.Drawing.Point(271, 149)
        Me.txtReceiveTotalFine.Name = "txtReceiveTotalFine"
        Me.txtReceiveTotalFine.ReadOnly = True
        Me.txtReceiveTotalFine.Size = New System.Drawing.Size(53, 22)
        Me.txtReceiveTotalFine.TabIndex = 14
        Me.txtReceiveTotalFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceiveTotalPr
        '
        Me.txtReceiveTotalPr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveTotalPr.Location = New System.Drawing.Point(212, 149)
        Me.txtReceiveTotalPr.Name = "txtReceiveTotalPr"
        Me.txtReceiveTotalPr.ReadOnly = True
        Me.txtReceiveTotalPr.Size = New System.Drawing.Size(53, 22)
        Me.txtReceiveTotalPr.TabIndex = 13
        Me.txtReceiveTotalPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceiveTotalGross
        '
        Me.txtReceiveTotalGross.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveTotalGross.Location = New System.Drawing.Point(153, 147)
        Me.txtReceiveTotalGross.Name = "txtReceiveTotalGross"
        Me.txtReceiveTotalGross.Size = New System.Drawing.Size(53, 22)
        Me.txtReceiveTotalGross.TabIndex = 12
        Me.txtReceiveTotalGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceiveSampleFine
        '
        Me.txtReceiveSampleFine.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveSampleFine.Location = New System.Drawing.Point(271, 119)
        Me.txtReceiveSampleFine.Name = "txtReceiveSampleFine"
        Me.txtReceiveSampleFine.ReadOnly = True
        Me.txtReceiveSampleFine.Size = New System.Drawing.Size(53, 22)
        Me.txtReceiveSampleFine.TabIndex = 11
        Me.txtReceiveSampleFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceiveSamplePr
        '
        Me.txtReceiveSamplePr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveSamplePr.Location = New System.Drawing.Point(212, 119)
        Me.txtReceiveSamplePr.Name = "txtReceiveSamplePr"
        Me.txtReceiveSamplePr.ReadOnly = True
        Me.txtReceiveSamplePr.Size = New System.Drawing.Size(53, 22)
        Me.txtReceiveSamplePr.TabIndex = 10
        Me.txtReceiveSamplePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleReceiveWt
        '
        Me.txtSampleReceiveWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSampleReceiveWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtSampleReceiveWt.Location = New System.Drawing.Point(153, 118)
        Me.txtSampleReceiveWt.Name = "txtSampleReceiveWt"
        Me.txtSampleReceiveWt.Size = New System.Drawing.Size(53, 22)
        Me.txtSampleReceiveWt.TabIndex = 9
        Me.txtSampleReceiveWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceiveBhukaFine
        '
        Me.txtReceiveBhukaFine.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveBhukaFine.Location = New System.Drawing.Point(271, 89)
        Me.txtReceiveBhukaFine.Name = "txtReceiveBhukaFine"
        Me.txtReceiveBhukaFine.ReadOnly = True
        Me.txtReceiveBhukaFine.Size = New System.Drawing.Size(53, 22)
        Me.txtReceiveBhukaFine.TabIndex = 8
        Me.txtReceiveBhukaFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceiveBhukaPr
        '
        Me.txtReceiveBhukaPr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveBhukaPr.Location = New System.Drawing.Point(212, 89)
        Me.txtReceiveBhukaPr.Name = "txtReceiveBhukaPr"
        Me.txtReceiveBhukaPr.ReadOnly = True
        Me.txtReceiveBhukaPr.Size = New System.Drawing.Size(53, 22)
        Me.txtReceiveBhukaPr.TabIndex = 7
        Me.txtReceiveBhukaPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBhukaReceiveWt
        '
        Me.txtBhukaReceiveWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBhukaReceiveWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtBhukaReceiveWt.Location = New System.Drawing.Point(153, 89)
        Me.txtBhukaReceiveWt.Name = "txtBhukaReceiveWt"
        Me.txtBhukaReceiveWt.Size = New System.Drawing.Size(53, 22)
        Me.txtBhukaReceiveWt.TabIndex = 6
        Me.txtBhukaReceiveWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceiveFine
        '
        Me.txtReceiveFine.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveFine.Location = New System.Drawing.Point(271, 59)
        Me.txtReceiveFine.Name = "txtReceiveFine"
        Me.txtReceiveFine.ReadOnly = True
        Me.txtReceiveFine.Size = New System.Drawing.Size(53, 22)
        Me.txtReceiveFine.TabIndex = 5
        Me.txtReceiveFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceivePr
        '
        Me.txtReceivePr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceivePr.Location = New System.Drawing.Point(212, 59)
        Me.txtReceivePr.Name = "txtReceivePr"
        Me.txtReceivePr.ReadOnly = True
        Me.txtReceivePr.Size = New System.Drawing.Size(53, 22)
        Me.txtReceivePr.TabIndex = 4
        Me.txtReceivePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtChainReceiveWt
        '
        Me.txtChainReceiveWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtChainReceiveWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtChainReceiveWt.Location = New System.Drawing.Point(153, 59)
        Me.txtChainReceiveWt.Name = "txtChainReceiveWt"
        Me.txtChainReceiveWt.Size = New System.Drawing.Size(53, 22)
        Me.txtChainReceiveWt.TabIndex = 3
        Me.txtChainReceiveWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssueFine
        '
        Me.txtIssueFine.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssueFine.Location = New System.Drawing.Point(267, 11)
        Me.txtIssueFine.Name = "txtIssueFine"
        Me.txtIssueFine.ReadOnly = True
        Me.txtIssueFine.Size = New System.Drawing.Size(53, 22)
        Me.txtIssueFine.TabIndex = 2
        Me.txtIssueFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssuePercent
        '
        Me.txtIssuePercent.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssuePercent.Location = New System.Drawing.Point(210, 11)
        Me.txtIssuePercent.Name = "txtIssuePercent"
        Me.txtIssuePercent.ReadOnly = True
        Me.txtIssuePercent.Size = New System.Drawing.Size(53, 22)
        Me.txtIssuePercent.TabIndex = 1
        Me.txtIssuePercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssueWeight
        '
        Me.txtIssueWeight.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssueWeight.Location = New System.Drawing.Point(153, 11)
        Me.txtIssueWeight.Name = "txtIssueWeight"
        Me.txtIssueWeight.ReadOnly = True
        Me.txtIssueWeight.Size = New System.Drawing.Size(53, 22)
        Me.txtIssueWeight.TabIndex = 0
        Me.txtIssueWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalIssue
        '
        Me.lblTotalIssue.AutoSize = True
        Me.lblTotalIssue.Font = New System.Drawing.Font("Times New Roman", 9.75!)
        Me.lblTotalIssue.Location = New System.Drawing.Point(23, 14)
        Me.lblTotalIssue.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTotalIssue.Name = "lblTotalIssue"
        Me.lblTotalIssue.Size = New System.Drawing.Size(125, 15)
        Me.lblTotalIssue.TabIndex = 803
        Me.lblTotalIssue.Text = "Issue Gold + Core Wt."
        '
        'txtFrKarigar
        '
        Me.txtFrKarigar.BackColor = System.Drawing.Color.White
        Me.txtFrKarigar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFrKarigar.Location = New System.Drawing.Point(393, 16)
        Me.txtFrKarigar.Margin = New System.Windows.Forms.Padding(5)
        Me.txtFrKarigar.Name = "txtFrKarigar"
        Me.txtFrKarigar.ReadOnly = True
        Me.txtFrKarigar.Size = New System.Drawing.Size(128, 22)
        Me.txtFrKarigar.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(315, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 14)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Fr Employee"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(310, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 14)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "To Employee"
        '
        'TransDt
        '
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(80, 23)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(90, 22)
        Me.TransDt.TabIndex = 0
        '
        'txtTransNo
        '
        Me.txtTransNo.BackColor = System.Drawing.Color.White
        Me.txtTransNo.Location = New System.Drawing.Point(173, 23)
        Me.txtTransNo.Margin = New System.Windows.Forms.Padding(5)
        Me.txtTransNo.Name = "txtTransNo"
        Me.txtTransNo.ReadOnly = True
        Me.txtTransNo.Size = New System.Drawing.Size(10, 22)
        Me.txtTransNo.TabIndex = 0
        Me.txtTransNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTransNo.Visible = False
        '
        'LblLotADate
        '
        Me.LblLotADate.AutoSize = True
        Me.LblLotADate.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.LblLotADate.Location = New System.Drawing.Point(21, 26)
        Me.LblLotADate.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LblLotADate.Name = "LblLotADate"
        Me.LblLotADate.Size = New System.Drawing.Size(54, 14)
        Me.LblLotADate.TabIndex = 1
        Me.LblLotADate.Text = "Trans Dt"
        '
        'lblLotNo
        '
        Me.lblLotNo.AutoSize = True
        Me.lblLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblLotNo.Location = New System.Drawing.Point(26, 52)
        Me.lblLotNo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblLotNo.Name = "lblLotNo"
        Me.lblLotNo.Size = New System.Drawing.Size(48, 14)
        Me.lblLotNo.TabIndex = 1
        Me.lblLotNo.Text = "Lot  No"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstCoreAddition)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(543, 339)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstCoreAddition
        '
        Me.lstCoreAddition.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.cCoreAdditionId, Me.cCoreAdditionDt, Me.cIssueWt, Me.cIssuePr, Me.cCoreIssueWt, Me.cLotNumber, Me.cFrKarigar, Me.cfrKarigarName, Me.cToKarigar, Me.ctoKarigarName})
        Me.lstCoreAddition.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstCoreAddition.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCoreAddition.FullRowSelect = True
        Me.lstCoreAddition.GridLines = True
        Me.lstCoreAddition.Location = New System.Drawing.Point(0, 0)
        Me.lstCoreAddition.Name = "lstCoreAddition"
        Me.lstCoreAddition.Size = New System.Drawing.Size(543, 339)
        Me.lstCoreAddition.TabIndex = 0
        Me.lstCoreAddition.UseCompatibleStateImageBehavior = False
        Me.lstCoreAddition.View = System.Windows.Forms.View.Details
        '
        'cCoreAdditionId
        '
        Me.cCoreAdditionId.Text = "Trans No"
        Me.cCoreAdditionId.Width = 0
        '
        'cCoreAdditionDt
        '
        Me.cCoreAdditionDt.Text = "Trans Dt"
        Me.cCoreAdditionDt.Width = 65
        '
        'cIssueWt
        '
        Me.cIssueWt.Text = "Issue Wt."
        Me.cIssueWt.Width = 65
        '
        'cIssuePr
        '
        Me.cIssuePr.Text = "Issue %"
        Me.cIssuePr.Width = 65
        '
        'cCoreIssueWt
        '
        Me.cCoreIssueWt.Text = "Core Wt."
        Me.cCoreIssueWt.Width = 65
        '
        'cLotNumber
        '
        Me.cLotNumber.Text = "Lot No"
        Me.cLotNumber.Width = 65
        '
        'cFrKarigar
        '
        Me.cFrKarigar.Text = "FrKarigar"
        Me.cFrKarigar.Width = 0
        '
        'cfrKarigarName
        '
        Me.cfrKarigarName.Text = "Fr Karigar"
        Me.cfrKarigarName.Width = 105
        '
        'cToKarigar
        '
        Me.cToKarigar.Text = "KarigarName"
        Me.cToKarigar.Width = 0
        '
        'ctoKarigarName
        '
        Me.ctoKarigarName.Text = "To Karigar"
        Me.ctoKarigarName.Width = 105
        '
        'frmCoreAdditionRemoval
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(551, 366)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCoreAdditionRemoval"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Core Addition Removal"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.cmbTLabour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlDetails.ResumeLayout(False)
        Me.PnlDetails.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lstCoreAddition As ListView
    Friend WithEvents cCoreAdditionId As ColumnHeader
    Friend WithEvents cCoreAdditionDt As ColumnHeader
    Friend WithEvents cIssueWt As ColumnHeader
    Friend WithEvents cIssuePr As ColumnHeader
    Friend WithEvents cCoreIssueWt As ColumnHeader
    Friend WithEvents cLotNumber As ColumnHeader
    Friend WithEvents cFrKarigar As ColumnHeader
    Friend WithEvents cfrKarigarName As ColumnHeader
    Friend WithEvents cToKarigar As ColumnHeader
    Friend WithEvents ctoKarigarName As ColumnHeader
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents PnlDetails As Panel
    Friend WithEvents txtFrKarigar As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents txtTransNo As TextBox
    Friend WithEvents LblLotADate As Label
    Friend WithEvents lblLotNo As Label
    Friend WithEvents lblTotalIssue As Label
    Friend WithEvents txtIssueFine As TextBox
    Friend WithEvents txtIssuePercent As TextBox
    Friend WithEvents txtIssueWeight As TextBox
    Friend WithEvents txtReceiveSampleFine As TextBox
    Friend WithEvents txtReceiveSamplePr As TextBox
    Friend WithEvents txtSampleReceiveWt As TextBox
    Friend WithEvents txtReceiveBhukaFine As TextBox
    Friend WithEvents txtReceiveBhukaPr As TextBox
    Friend WithEvents txtReceiveFine As TextBox
    Friend WithEvents txtReceivePr As TextBox
    Friend WithEvents txtReceiveTotalFine As TextBox
    Friend WithEvents txtReceiveTotalPr As TextBox
    Friend WithEvents txtReceiveTotalGross As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBhukaReceiveWt As TextBox
    Friend WithEvents txtChainReceiveWt As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCoreRemains As TextBox
    Friend WithEvents txtTargetGoldWeight As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtMeltingPr As TextBox
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmbLotNo As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmbTLabour As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents Label10 As Label
    Friend WithEvents txtLossWt As TextBox
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
