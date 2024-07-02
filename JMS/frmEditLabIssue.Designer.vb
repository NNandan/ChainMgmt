<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEditLabIssue
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
        Dim RadListDataItem1 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem2 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnUpdate = New Telerik.WinControls.UI.RadButton()
        Me.GBoxRptUpdate = New System.Windows.Forms.GroupBox()
        Me.txtTransId = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbLab = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblLabName = New System.Windows.Forms.Label()
        Me.rbReBagSample = New System.Windows.Forms.RadioButton()
        Me.rbReLotSample = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtOperation = New Telerik.WinControls.UI.RadTextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.MskUpdateDt = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtLotNo = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalLossFine = New Telerik.WinControls.UI.RadTextBox()
        Me.txtTotalRecTotal = New Telerik.WinControls.UI.RadTextBox()
        Me.txtSampleGrossTotal = New Telerik.WinControls.UI.RadTextBox()
        Me.txtSampleGrossPr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtSampleFineTotal = New Telerik.WinControls.UI.RadTextBox()
        Me.txtSampleFinePr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtDiff = New Telerik.WinControls.UI.RadTextBox()
        Me.txtTotalLossWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtLabRptPr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtTotalRecWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtSampleGrossRec = New Telerik.WinControls.UI.RadTextBox()
        Me.txtSampleFineRec = New Telerik.WinControls.UI.RadTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFineWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssuePr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssueWt = New Telerik.WinControls.UI.RadTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblReceiveGrossWt = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxRptUpdate.SuspendLayout()
        CType(Me.txtTransId, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.txtOperation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MskUpdateDt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalLossFine, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalRecTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSampleGrossTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSampleGrossPr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSampleFineTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSampleFinePr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDiff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalLossWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLabRptPr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalRecWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSampleGrossRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSampleFineRec, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFineWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(795, 393)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnCancel)
        Me.TabPage3.Controls.Add(Me.btnUpdate)
        Me.TabPage3.Controls.Add(Me.GBoxRptUpdate)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(787, 366)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Edit Lab Issue"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(408, 332)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 143
        Me.btnCancel.Text = "&Cancel"
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnUpdate.Location = New System.Drawing.Point(329, 332)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 25)
        Me.btnUpdate.TabIndex = 142
        Me.btnUpdate.Text = "&Update"
        '
        'GBoxRptUpdate
        '
        Me.GBoxRptUpdate.Controls.Add(Me.txtTransId)
        Me.GBoxRptUpdate.Controls.Add(Me.cmbLab)
        Me.GBoxRptUpdate.Controls.Add(Me.lblLabName)
        Me.GBoxRptUpdate.Controls.Add(Me.rbReBagSample)
        Me.GBoxRptUpdate.Controls.Add(Me.rbReLotSample)
        Me.GBoxRptUpdate.Controls.Add(Me.Label4)
        Me.GBoxRptUpdate.Controls.Add(Me.TransDt)
        Me.GBoxRptUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxRptUpdate.Location = New System.Drawing.Point(5, 5)
        Me.GBoxRptUpdate.Name = "GBoxRptUpdate"
        Me.GBoxRptUpdate.Size = New System.Drawing.Size(775, 50)
        Me.GBoxRptUpdate.TabIndex = 134
        Me.GBoxRptUpdate.TabStop = False
        '
        'txtTransId
        '
        Me.txtTransId.Location = New System.Drawing.Point(179, 18)
        Me.txtTransId.Name = "txtTransId"
        Me.txtTransId.Size = New System.Drawing.Size(7, 20)
        Me.txtTransId.TabIndex = 810
        Me.txtTransId.Visible = False
        '
        'cmbLab
        '
        Me.cmbLab.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbLab.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbLab.Font = New System.Drawing.Font("Tahoma", 9.0!)
        RadListDataItem1.Text = "Admin"
        RadListDataItem2.Text = "User"
        Me.cmbLab.Items.Add(RadListDataItem1)
        Me.cmbLab.Items.Add(RadListDataItem2)
        Me.cmbLab.Location = New System.Drawing.Point(365, 15)
        Me.cmbLab.Name = "cmbLab"
        Me.cmbLab.Size = New System.Drawing.Size(139, 20)
        Me.cmbLab.TabIndex = 809
        '
        'lblLabName
        '
        Me.lblLabName.AutoSize = True
        Me.lblLabName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabName.Location = New System.Drawing.Point(297, 18)
        Me.lblLabName.Name = "lblLabName"
        Me.lblLabName.Size = New System.Drawing.Size(64, 14)
        Me.lblLabName.TabIndex = 808
        Me.lblLabName.Text = "Select Lab"
        '
        'rbReBagSample
        '
        Me.rbReBagSample.AutoSize = True
        Me.rbReBagSample.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rbReBagSample.Location = New System.Drawing.Point(676, 19)
        Me.rbReBagSample.Name = "rbReBagSample"
        Me.rbReBagSample.Size = New System.Drawing.Size(93, 18)
        Me.rbReBagSample.TabIndex = 133
        Me.rbReBagSample.TabStop = True
        Me.rbReBagSample.Text = "Bag Samples"
        Me.rbReBagSample.UseVisualStyleBackColor = True
        '
        'rbReLotSample
        '
        Me.rbReLotSample.AutoSize = True
        Me.rbReLotSample.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rbReLotSample.Location = New System.Drawing.Point(573, 19)
        Me.rbReLotSample.Name = "rbReLotSample"
        Me.rbReLotSample.Size = New System.Drawing.Size(91, 18)
        Me.rbReLotSample.TabIndex = 132
        Me.rbReLotSample.TabStop = True
        Me.rbReLotSample.Text = "Lot Samples"
        Me.rbReLotSample.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 14)
        Me.Label4.TabIndex = 131
        Me.Label4.Text = "Receipt Dt."
        '
        'TransDt
        '
        Me.TransDt.Checked = False
        Me.TransDt.CustomFormat = "mm-dd-yyyy"
        Me.TransDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(86, 17)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(90, 21)
        Me.TransDt.TabIndex = 130
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtOperation)
        Me.GroupBox5.Controls.Add(Me.Label28)
        Me.GroupBox5.Controls.Add(Me.MskUpdateDt)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.txtLotNo)
        Me.GroupBox5.Controls.Add(Me.Label2)
        Me.GroupBox5.Controls.Add(Me.txtTotalLossFine)
        Me.GroupBox5.Controls.Add(Me.txtTotalRecTotal)
        Me.GroupBox5.Controls.Add(Me.txtSampleGrossTotal)
        Me.GroupBox5.Controls.Add(Me.txtSampleGrossPr)
        Me.GroupBox5.Controls.Add(Me.txtSampleFineTotal)
        Me.GroupBox5.Controls.Add(Me.txtSampleFinePr)
        Me.GroupBox5.Controls.Add(Me.txtDiff)
        Me.GroupBox5.Controls.Add(Me.txtTotalLossWt)
        Me.GroupBox5.Controls.Add(Me.txtLabRptPr)
        Me.GroupBox5.Controls.Add(Me.txtTotalRecWt)
        Me.GroupBox5.Controls.Add(Me.txtSampleGrossRec)
        Me.GroupBox5.Controls.Add(Me.txtSampleFineRec)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.txtFineWt)
        Me.GroupBox5.Controls.Add(Me.txtIssuePr)
        Me.GroupBox5.Controls.Add(Me.txtIssueWt)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.lblReceiveGrossWt)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(5, 61)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(775, 263)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'txtOperation
        '
        Me.txtOperation.Location = New System.Drawing.Point(143, 67)
        Me.txtOperation.Name = "txtOperation"
        Me.txtOperation.ReadOnly = True
        Me.txtOperation.Size = New System.Drawing.Size(150, 20)
        Me.txtOperation.TabIndex = 173
        Me.txtOperation.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label28.Location = New System.Drawing.Point(66, 22)
        Me.Label28.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(73, 14)
        Me.Label28.TabIndex = 172
        Me.Label28.Text = "Received Dt"
        '
        'MskUpdateDt
        '
        Me.MskUpdateDt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.MskUpdateDt.Location = New System.Drawing.Point(143, 19)
        Me.MskUpdateDt.Mask = "00/00/0000"
        Me.MskUpdateDt.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.MskUpdateDt.Name = "MskUpdateDt"
        Me.MskUpdateDt.Size = New System.Drawing.Size(72, 20)
        Me.MskUpdateDt.TabIndex = 171
        Me.MskUpdateDt.TabStop = False
        Me.MskUpdateDt.Text = "__/__/____"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(95, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(44, 14)
        Me.Label11.TabIndex = 170
        Me.Label11.Text = "Lot No"
        '
        'txtLotNo
        '
        Me.txtLotNo.Location = New System.Drawing.Point(143, 43)
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.ReadOnly = True
        Me.txtLotNo.Size = New System.Drawing.Size(100, 20)
        Me.txtLotNo.TabIndex = 169
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 14)
        Me.Label2.TabIndex = 168
        Me.Label2.Text = "Operation/Item"
        '
        'txtTotalLossFine
        '
        Me.txtTotalLossFine.Location = New System.Drawing.Point(294, 187)
        Me.txtTotalLossFine.Name = "txtTotalLossFine"
        Me.txtTotalLossFine.ReadOnly = True
        Me.txtTotalLossFine.Size = New System.Drawing.Size(75, 20)
        Me.txtTotalLossFine.TabIndex = 166
        Me.txtTotalLossFine.TabStop = False
        Me.txtTotalLossFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalRecTotal
        '
        Me.txtTotalRecTotal.Location = New System.Drawing.Point(294, 163)
        Me.txtTotalRecTotal.Name = "txtTotalRecTotal"
        Me.txtTotalRecTotal.ReadOnly = True
        Me.txtTotalRecTotal.Size = New System.Drawing.Size(75, 20)
        Me.txtTotalRecTotal.TabIndex = 164
        Me.txtTotalRecTotal.TabStop = False
        Me.txtTotalRecTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleGrossTotal
        '
        Me.txtSampleGrossTotal.Location = New System.Drawing.Point(294, 139)
        Me.txtSampleGrossTotal.Name = "txtSampleGrossTotal"
        Me.txtSampleGrossTotal.ReadOnly = True
        Me.txtSampleGrossTotal.Size = New System.Drawing.Size(75, 20)
        Me.txtSampleGrossTotal.TabIndex = 162
        Me.txtSampleGrossTotal.TabStop = False
        Me.txtSampleGrossTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleGrossPr
        '
        Me.txtSampleGrossPr.Location = New System.Drawing.Point(218, 139)
        Me.txtSampleGrossPr.Name = "txtSampleGrossPr"
        Me.txtSampleGrossPr.ReadOnly = True
        Me.txtSampleGrossPr.Size = New System.Drawing.Size(75, 20)
        Me.txtSampleGrossPr.TabIndex = 161
        Me.txtSampleGrossPr.TabStop = False
        Me.txtSampleGrossPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleFineTotal
        '
        Me.txtSampleFineTotal.Location = New System.Drawing.Point(294, 115)
        Me.txtSampleFineTotal.Name = "txtSampleFineTotal"
        Me.txtSampleFineTotal.ReadOnly = True
        Me.txtSampleFineTotal.Size = New System.Drawing.Size(75, 20)
        Me.txtSampleFineTotal.TabIndex = 160
        Me.txtSampleFineTotal.TabStop = False
        Me.txtSampleFineTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleFinePr
        '
        Me.txtSampleFinePr.Location = New System.Drawing.Point(218, 115)
        Me.txtSampleFinePr.Name = "txtSampleFinePr"
        Me.txtSampleFinePr.ReadOnly = True
        Me.txtSampleFinePr.Size = New System.Drawing.Size(75, 20)
        Me.txtSampleFinePr.TabIndex = 159
        Me.txtSampleFinePr.TabStop = False
        Me.txtSampleFinePr.Text = "100"
        Me.txtSampleFinePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDiff
        '
        Me.txtDiff.Location = New System.Drawing.Point(294, 91)
        Me.txtDiff.Name = "txtDiff"
        Me.txtDiff.ReadOnly = True
        Me.txtDiff.Size = New System.Drawing.Size(75, 20)
        Me.txtDiff.TabIndex = 158
        Me.txtDiff.TabStop = False
        Me.txtDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalLossWt
        '
        Me.txtTotalLossWt.Location = New System.Drawing.Point(143, 187)
        Me.txtTotalLossWt.Name = "txtTotalLossWt"
        Me.txtTotalLossWt.ReadOnly = True
        Me.txtTotalLossWt.Size = New System.Drawing.Size(71, 20)
        Me.txtTotalLossWt.TabIndex = 159
        Me.txtTotalLossWt.TabStop = False
        Me.txtTotalLossWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLabRptPr
        '
        Me.txtLabRptPr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLabRptPr.Location = New System.Drawing.Point(143, 91)
        Me.txtLabRptPr.Name = "txtLabRptPr"
        Me.txtLabRptPr.Size = New System.Drawing.Size(71, 20)
        Me.txtLabRptPr.TabIndex = 0
        Me.txtLabRptPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalRecWt
        '
        Me.txtTotalRecWt.Location = New System.Drawing.Point(143, 163)
        Me.txtTotalRecWt.Name = "txtTotalRecWt"
        Me.txtTotalRecWt.ReadOnly = True
        Me.txtTotalRecWt.Size = New System.Drawing.Size(71, 20)
        Me.txtTotalRecWt.TabIndex = 158
        Me.txtTotalRecWt.TabStop = False
        Me.txtTotalRecWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleGrossRec
        '
        Me.txtSampleGrossRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSampleGrossRec.Location = New System.Drawing.Point(143, 139)
        Me.txtSampleGrossRec.Name = "txtSampleGrossRec"
        Me.txtSampleGrossRec.Size = New System.Drawing.Size(71, 20)
        Me.txtSampleGrossRec.TabIndex = 2
        Me.txtSampleGrossRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleFineRec
        '
        Me.txtSampleFineRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSampleFineRec.Location = New System.Drawing.Point(143, 115)
        Me.txtSampleFineRec.Name = "txtSampleFineRec"
        Me.txtSampleFineRec.Size = New System.Drawing.Size(71, 20)
        Me.txtSampleFineRec.TabIndex = 1
        Me.txtSampleFineRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(84, 190)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 14)
        Me.Label10.TabIndex = 151
        Me.Label10.Text = "Loss Wt."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(52, 167)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 14)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "Total Rec. Wt."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(32, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 14)
        Me.Label8.TabIndex = 149
        Me.Label8.Text = "Sample Gross Rec."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(39, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 14)
        Me.Label7.TabIndex = 148
        Me.Label7.Text = "Sample Fine Rec."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 14)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Lab Report %"
        '
        'txtFineWt
        '
        Me.txtFineWt.Location = New System.Drawing.Point(694, 91)
        Me.txtFineWt.Name = "txtFineWt"
        Me.txtFineWt.ReadOnly = True
        Me.txtFineWt.Size = New System.Drawing.Size(75, 20)
        Me.txtFineWt.TabIndex = 145
        Me.txtFineWt.TabStop = False
        Me.txtFineWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssuePr
        '
        Me.txtIssuePr.Location = New System.Drawing.Point(608, 91)
        Me.txtIssuePr.Name = "txtIssuePr"
        Me.txtIssuePr.ReadOnly = True
        Me.txtIssuePr.Size = New System.Drawing.Size(75, 20)
        Me.txtIssuePr.TabIndex = 144
        Me.txtIssuePr.TabStop = False
        Me.txtIssuePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssueWt
        '
        Me.txtIssueWt.Location = New System.Drawing.Point(522, 91)
        Me.txtIssueWt.Name = "txtIssueWt"
        Me.txtIssueWt.ReadOnly = True
        Me.txtIssueWt.Size = New System.Drawing.Size(75, 20)
        Me.txtIssueWt.TabIndex = 143
        Me.txtIssueWt.TabStop = False
        Me.txtIssueWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(526, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 14)
        Me.Label6.TabIndex = 140
        Me.Label6.Text = "Issue Wt."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(245, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 14)
        Me.Label5.TabIndex = 138
        Me.Label5.Text = "Diff. %"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(698, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 14)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "Fine Wt."
        '
        'lblReceiveGrossWt
        '
        Me.lblReceiveGrossWt.AutoSize = True
        Me.lblReceiveGrossWt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiveGrossWt.Location = New System.Drawing.Point(611, 73)
        Me.lblReceiveGrossWt.Name = "lblReceiveGrossWt"
        Me.lblReceiveGrossWt.Size = New System.Drawing.Size(51, 14)
        Me.lblReceiveGrossWt.TabIndex = 134
        Me.lblReceiveGrossWt.Text = "Issue %"
        '
        'frmEditLabIssue
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(793, 393)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.MaximizeBox = False
        Me.Name = "frmEditLabIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Lab Issue"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxRptUpdate.ResumeLayout(False)
        Me.GBoxRptUpdate.PerformLayout()
        CType(Me.txtTransId, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.txtOperation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MskUpdateDt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalLossFine, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalRecTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSampleGrossTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSampleGrossPr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSampleFineTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSampleFinePr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDiff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalLossWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLabRptPr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalRecWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSampleGrossRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSampleFineRec, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFineWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnUpdate As Telerik.WinControls.UI.RadButton
    Friend WithEvents GBoxRptUpdate As GroupBox
    Friend WithEvents rbReBagSample As RadioButton
    Friend WithEvents rbReLotSample As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtTotalLossFine As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTotalRecTotal As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleGrossTotal As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleGrossPr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleFineTotal As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleFinePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtDiff As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTotalLossWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtLabRptPr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTotalRecWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleGrossRec As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleFineRec As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFineWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssuePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssueWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblReceiveGrossWt As Label
    Friend WithEvents cmbLab As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents lblLabName As Label
    Friend WithEvents txtTransId As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtLotNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents MskUpdateDt As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtOperation As Telerik.WinControls.UI.RadTextBox
End Class
