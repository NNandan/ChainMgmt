<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLabIssue
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim RadListDataItem1 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem2 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim GridViewCheckBoxColumn2 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition4 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnIEdit = New Telerik.WinControls.UI.RadButton()
        Me.btnCopy = New Telerik.WinControls.UI.RadButton()
        Me.btnICancel = New Telerik.WinControls.UI.RadButton()
        Me.btnISave = New Telerik.WinControls.UI.RadButton()
        Me.dgvDataSave = New Telerik.WinControls.UI.RadGridView()
        Me.dgvLabIssue = New Telerik.WinControls.UI.RadGridView()
        Me.GBoxFilter = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.dtFr = New System.Windows.Forms.DateTimePicker()
        Me.lblFr = New System.Windows.Forms.Label()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.cmbLab = New Telerik.WinControls.UI.RadDropDownList()
        Me.grpMain1 = New System.Windows.Forms.GroupBox()
        Me.rbBagSample = New System.Windows.Forms.RadioButton()
        Me.rbLotSample = New System.Windows.Forms.RadioButton()
        Me.lblIssueDt = New System.Windows.Forms.Label()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.lblLabName = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvLabReceipt = New Telerik.WinControls.UI.RadGridView()
        Me.btnRCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnRSave = New Telerik.WinControls.UI.RadButton()
        Me.GBoxLabReceipt = New System.Windows.Forms.GroupBox()
        Me.rbRBagSample = New System.Windows.Forms.RadioButton()
        Me.rbRLotSample = New System.Windows.Forms.RadioButton()
        Me.lblReceiptDt = New System.Windows.Forms.Label()
        Me.chkRAll = New System.Windows.Forms.CheckBox()
        Me.ReceiptDt = New System.Windows.Forms.DateTimePicker()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvLabReport = New Telerik.WinControls.UI.RadGridView()
        Me.btnUCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnUSave = New Telerik.WinControls.UI.RadButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
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
        Me.txtFineRptWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssuePr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssueWt = New Telerik.WinControls.UI.RadTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblReceiveGrossWt = New System.Windows.Forms.Label()
        Me.GBoxRptUpdate = New System.Windows.Forms.GroupBox()
        Me.rbReBagSample = New System.Windows.Forms.RadioButton()
        Me.rbReLotSample = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RptUpdateDt = New System.Windows.Forms.DateTimePicker()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnIEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnICancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnISave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDataSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDataSave.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLabIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLabIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxFilter.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GBoxMain.SuspendLayout()
        CType(Me.cmbLab, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMain1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvLabReceipt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLabReceipt.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnRSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxLabReceipt.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvLabReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLabReport.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnUSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
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
        CType(Me.txtFineRptWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxRptUpdate.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(810, 600)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnExit)
        Me.TabPage1.Controls.Add(Me.btnIEdit)
        Me.TabPage1.Controls.Add(Me.btnCopy)
        Me.TabPage1.Controls.Add(Me.btnICancel)
        Me.TabPage1.Controls.Add(Me.btnISave)
        Me.TabPage1.Controls.Add(Me.dgvDataSave)
        Me.TabPage1.Controls.Add(Me.dgvLabIssue)
        Me.TabPage1.Controls.Add(Me.GBoxFilter)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(802, 573)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Lab Issue"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(506, 542)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 799
        Me.btnExit.Text = "E&xit"
        '
        'btnIEdit
        '
        Me.btnIEdit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnIEdit.Location = New System.Drawing.Point(352, 542)
        Me.btnIEdit.Name = "btnIEdit"
        Me.btnIEdit.Size = New System.Drawing.Size(75, 25)
        Me.btnIEdit.TabIndex = 144
        Me.btnIEdit.Text = "Edit"
        '
        'btnCopy
        '
        Me.btnCopy.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCopy.Location = New System.Drawing.Point(693, 79)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 25)
        Me.btnCopy.TabIndex = 143
        Me.btnCopy.Text = "Copy"
        '
        'btnICancel
        '
        Me.btnICancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnICancel.Location = New System.Drawing.Point(429, 542)
        Me.btnICancel.Name = "btnICancel"
        Me.btnICancel.Size = New System.Drawing.Size(75, 25)
        Me.btnICancel.TabIndex = 142
        Me.btnICancel.Text = "&Cancel"
        '
        'btnISave
        '
        Me.btnISave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnISave.Location = New System.Drawing.Point(275, 542)
        Me.btnISave.Name = "btnISave"
        Me.btnISave.Size = New System.Drawing.Size(75, 25)
        Me.btnISave.TabIndex = 141
        Me.btnISave.Text = "&Save"
        '
        'dgvDataSave
        '
        Me.dgvDataSave.BackColor = System.Drawing.Color.Transparent
        Me.dgvDataSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvDataSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvDataSave.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDataSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvDataSave.Location = New System.Drawing.Point(8, 362)
        '
        '
        '
        Me.dgvDataSave.MasterTemplate.AllowAddNewRow = False
        Me.dgvDataSave.MasterTemplate.AllowColumnReorder = False
        Me.dgvDataSave.MasterTemplate.EnableGrouping = False
        Me.dgvDataSave.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvDataSave.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvDataSave.Name = "dgvDataSave"
        Me.dgvDataSave.ReadOnly = True
        Me.dgvDataSave.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvDataSave.ShowGroupPanel = False
        Me.dgvDataSave.Size = New System.Drawing.Size(785, 175)
        Me.dgvDataSave.TabIndex = 140
        '
        'dgvLabIssue
        '
        Me.dgvLabIssue.BackColor = System.Drawing.Color.Transparent
        Me.dgvLabIssue.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLabIssue.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvLabIssue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLabIssue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLabIssue.Location = New System.Drawing.Point(8, 163)
        '
        '
        '
        Me.dgvLabIssue.MasterTemplate.AllowAddNewRow = False
        Me.dgvLabIssue.MasterTemplate.AllowColumnReorder = False
        Me.dgvLabIssue.MasterTemplate.EnableFiltering = True
        Me.dgvLabIssue.MasterTemplate.EnableGrouping = False
        Me.dgvLabIssue.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvLabIssue.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvLabIssue.Name = "dgvLabIssue"
        Me.dgvLabIssue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLabIssue.Size = New System.Drawing.Size(785, 190)
        Me.dgvLabIssue.TabIndex = 139
        '
        'GBoxFilter
        '
        Me.GBoxFilter.Controls.Add(Me.GroupBox3)
        Me.GBoxFilter.Location = New System.Drawing.Point(330, 8)
        Me.GBoxFilter.Name = "GBoxFilter"
        Me.GBoxFilter.Size = New System.Drawing.Size(316, 150)
        Me.GBoxFilter.TabIndex = 134
        Me.GBoxFilter.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.dtTo)
        Me.GroupBox3.Controls.Add(Me.lblTo)
        Me.GroupBox3.Controls.Add(Me.dtFr)
        Me.GroupBox3.Controls.Add(Me.lblFr)
        Me.GroupBox3.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(290, 50)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Filter By Date"
        '
        'dtTo
        '
        Me.dtTo.Checked = False
        Me.dtTo.CustomFormat = "mm-dd-yyyy"
        Me.dtTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtTo.Location = New System.Drawing.Point(169, 19)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(90, 21)
        Me.dtTo.TabIndex = 130
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTo.Location = New System.Drawing.Point(133, 22)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(30, 14)
        Me.lblTo.TabIndex = 129
        Me.lblTo.Text = "To :"
        '
        'dtFr
        '
        Me.dtFr.Checked = False
        Me.dtFr.CustomFormat = "mm-dd-yyyy"
        Me.dtFr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFr.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFr.Location = New System.Drawing.Point(39, 19)
        Me.dtFr.Name = "dtFr"
        Me.dtFr.Size = New System.Drawing.Size(90, 21)
        Me.dtFr.TabIndex = 128
        '
        'lblFr
        '
        Me.lblFr.AutoSize = True
        Me.lblFr.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFr.Location = New System.Drawing.Point(9, 22)
        Me.lblFr.Name = "lblFr"
        Me.lblFr.Size = New System.Drawing.Size(25, 14)
        Me.lblFr.TabIndex = 127
        Me.lblFr.Text = "Fr :"
        '
        'GBoxMain
        '
        Me.GBoxMain.Controls.Add(Me.cmbLab)
        Me.GBoxMain.Controls.Add(Me.grpMain1)
        Me.GBoxMain.Controls.Add(Me.lblIssueDt)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Controls.Add(Me.lblLabName)
        Me.GBoxMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(8, 8)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Size = New System.Drawing.Size(316, 150)
        Me.GBoxMain.TabIndex = 1
        Me.GBoxMain.TabStop = False
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
        Me.cmbLab.Location = New System.Drawing.Point(92, 47)
        Me.cmbLab.Name = "cmbLab"
        Me.cmbLab.Size = New System.Drawing.Size(139, 20)
        Me.cmbLab.TabIndex = 807
        '
        'grpMain1
        '
        Me.grpMain1.Controls.Add(Me.rbBagSample)
        Me.grpMain1.Controls.Add(Me.rbLotSample)
        Me.grpMain1.Location = New System.Drawing.Point(92, 71)
        Me.grpMain1.Name = "grpMain1"
        Me.grpMain1.Size = New System.Drawing.Size(139, 73)
        Me.grpMain1.TabIndex = 132
        Me.grpMain1.TabStop = False
        '
        'rbBagSample
        '
        Me.rbBagSample.AutoSize = True
        Me.rbBagSample.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rbBagSample.Location = New System.Drawing.Point(6, 44)
        Me.rbBagSample.Name = "rbBagSample"
        Me.rbBagSample.Size = New System.Drawing.Size(93, 18)
        Me.rbBagSample.TabIndex = 1
        Me.rbBagSample.TabStop = True
        Me.rbBagSample.Text = "Bag Samples"
        Me.rbBagSample.UseVisualStyleBackColor = True
        '
        'rbLotSample
        '
        Me.rbLotSample.AutoSize = True
        Me.rbLotSample.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rbLotSample.Location = New System.Drawing.Point(6, 13)
        Me.rbLotSample.Name = "rbLotSample"
        Me.rbLotSample.Size = New System.Drawing.Size(91, 18)
        Me.rbLotSample.TabIndex = 0
        Me.rbLotSample.TabStop = True
        Me.rbLotSample.Text = "Lot Samples"
        Me.rbLotSample.UseVisualStyleBackColor = True
        '
        'lblIssueDt
        '
        Me.lblIssueDt.AutoSize = True
        Me.lblIssueDt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIssueDt.Location = New System.Drawing.Point(32, 20)
        Me.lblIssueDt.Name = "lblIssueDt"
        Me.lblIssueDt.Size = New System.Drawing.Size(56, 14)
        Me.lblIssueDt.TabIndex = 131
        Me.lblIssueDt.Text = "Issue Dt."
        '
        'TransDt
        '
        Me.TransDt.Checked = False
        Me.TransDt.CustomFormat = "mm-dd-yyyy"
        Me.TransDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(92, 17)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(100, 21)
        Me.TransDt.TabIndex = 130
        '
        'lblLabName
        '
        Me.lblLabName.AutoSize = True
        Me.lblLabName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabName.Location = New System.Drawing.Point(24, 50)
        Me.lblLabName.Name = "lblLabName"
        Me.lblLabName.Size = New System.Drawing.Size(64, 14)
        Me.lblLabName.TabIndex = 128
        Me.lblLabName.Text = "Select Lab"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvLabReceipt)
        Me.TabPage2.Controls.Add(Me.btnRCancel)
        Me.TabPage2.Controls.Add(Me.btnRSave)
        Me.TabPage2.Controls.Add(Me.GBoxLabReceipt)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(802, 573)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Lab Receipt"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvLabReceipt
        '
        Me.dgvLabReceipt.BackColor = System.Drawing.Color.Transparent
        Me.dgvLabReceipt.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLabReceipt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvLabReceipt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLabReceipt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLabReceipt.Location = New System.Drawing.Point(5, 60)
        '
        '
        '
        Me.dgvLabReceipt.MasterTemplate.AllowAddNewRow = False
        Me.dgvLabReceipt.MasterTemplate.AllowColumnReorder = False
        GridViewCheckBoxColumn1.EnableExpressionEditor = False
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "colChkBox"
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "TransactionId"
        GridViewTextBoxColumn1.HeaderText = "Trans Id."
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "colTransactionId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "Lot No."
        GridViewTextBoxColumn2.Name = "colLotNumber"
        GridViewTextBoxColumn2.Width = 100
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "OperationId"
        GridViewTextBoxColumn3.HeaderText = "Operation Id."
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.Name = "colOperationId"
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "OperationName"
        GridViewTextBoxColumn4.HeaderText = "Operation"
        GridViewTextBoxColumn4.Name = "colOperation Name"
        GridViewTextBoxColumn4.Width = 345
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "IssueWt"
        GridViewTextBoxColumn5.HeaderText = "Issue Wt."
        GridViewTextBoxColumn5.Name = "colIssueWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 95
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "IssuePr"
        GridViewTextBoxColumn6.HeaderText = "Issue %"
        GridViewTextBoxColumn6.Name = "colIssuePr"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 95
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "FineWt"
        GridViewTextBoxColumn7.HeaderText = "Fine Wt,"
        GridViewTextBoxColumn7.Name = "colFineWt"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 95
        Me.dgvLabReceipt.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn1, GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7})
        Me.dgvLabReceipt.MasterTemplate.EnableGrouping = False
        Me.dgvLabReceipt.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvLabReceipt.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.dgvLabReceipt.Name = "dgvLabReceipt"
        Me.dgvLabReceipt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLabReceipt.Size = New System.Drawing.Size(793, 470)
        Me.dgvLabReceipt.TabIndex = 143
        '
        'btnRCancel
        '
        Me.btnRCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnRCancel.Location = New System.Drawing.Point(418, 539)
        Me.btnRCancel.Name = "btnRCancel"
        Me.btnRCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnRCancel.TabIndex = 142
        Me.btnRCancel.Text = "&Cancel"
        '
        'btnRSave
        '
        Me.btnRSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnRSave.Location = New System.Drawing.Point(339, 539)
        Me.btnRSave.Name = "btnRSave"
        Me.btnRSave.Size = New System.Drawing.Size(75, 25)
        Me.btnRSave.TabIndex = 141
        Me.btnRSave.Text = "&Save"
        '
        'GBoxLabReceipt
        '
        Me.GBoxLabReceipt.Controls.Add(Me.rbRBagSample)
        Me.GBoxLabReceipt.Controls.Add(Me.rbRLotSample)
        Me.GBoxLabReceipt.Controls.Add(Me.lblReceiptDt)
        Me.GBoxLabReceipt.Controls.Add(Me.chkRAll)
        Me.GBoxLabReceipt.Controls.Add(Me.ReceiptDt)
        Me.GBoxLabReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxLabReceipt.Location = New System.Drawing.Point(5, 5)
        Me.GBoxLabReceipt.Name = "GBoxLabReceipt"
        Me.GBoxLabReceipt.Size = New System.Drawing.Size(792, 50)
        Me.GBoxLabReceipt.TabIndex = 2
        Me.GBoxLabReceipt.TabStop = False
        '
        'rbRBagSample
        '
        Me.rbRBagSample.AutoSize = True
        Me.rbRBagSample.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rbRBagSample.Location = New System.Drawing.Point(440, 20)
        Me.rbRBagSample.Name = "rbRBagSample"
        Me.rbRBagSample.Size = New System.Drawing.Size(93, 18)
        Me.rbRBagSample.TabIndex = 133
        Me.rbRBagSample.TabStop = True
        Me.rbRBagSample.Text = "Bag Samples"
        Me.rbRBagSample.UseVisualStyleBackColor = True
        '
        'rbRLotSample
        '
        Me.rbRLotSample.AutoSize = True
        Me.rbRLotSample.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rbRLotSample.Location = New System.Drawing.Point(335, 20)
        Me.rbRLotSample.Name = "rbRLotSample"
        Me.rbRLotSample.Size = New System.Drawing.Size(91, 18)
        Me.rbRLotSample.TabIndex = 132
        Me.rbRLotSample.TabStop = True
        Me.rbRLotSample.Text = "Lot Samples"
        Me.rbRLotSample.UseVisualStyleBackColor = True
        '
        'lblReceiptDt
        '
        Me.lblReceiptDt.AutoSize = True
        Me.lblReceiptDt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiptDt.Location = New System.Drawing.Point(13, 20)
        Me.lblReceiptDt.Name = "lblReceiptDt"
        Me.lblReceiptDt.Size = New System.Drawing.Size(69, 14)
        Me.lblReceiptDt.TabIndex = 131
        Me.lblReceiptDt.Text = "Receipt Dt."
        '
        'chkRAll
        '
        Me.chkRAll.AutoSize = True
        Me.chkRAll.Enabled = False
        Me.chkRAll.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.chkRAll.Location = New System.Drawing.Point(706, 17)
        Me.chkRAll.Name = "chkRAll"
        Me.chkRAll.Size = New System.Drawing.Size(75, 18)
        Me.chkRAll.TabIndex = 91
        Me.chkRAll.Text = "Check All"
        Me.chkRAll.UseVisualStyleBackColor = True
        '
        'ReceiptDt
        '
        Me.ReceiptDt.CalendarMonthBackground = System.Drawing.Color.LemonChiffon
        Me.ReceiptDt.Checked = False
        Me.ReceiptDt.CustomFormat = "mm-dd-yyyy"
        Me.ReceiptDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReceiptDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ReceiptDt.Location = New System.Drawing.Point(86, 17)
        Me.ReceiptDt.Name = "ReceiptDt"
        Me.ReceiptDt.Size = New System.Drawing.Size(90, 21)
        Me.ReceiptDt.TabIndex = 130
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvLabReport)
        Me.TabPage3.Controls.Add(Me.btnUCancel)
        Me.TabPage3.Controls.Add(Me.btnUSave)
        Me.TabPage3.Controls.Add(Me.GroupBox5)
        Me.TabPage3.Controls.Add(Me.GBoxRptUpdate)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(802, 573)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Report Update"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvLabReport
        '
        Me.dgvLabReport.BackColor = System.Drawing.Color.Transparent
        Me.dgvLabReport.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLabReport.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvLabReport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLabReport.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLabReport.Location = New System.Drawing.Point(5, 60)
        '
        '
        '
        Me.dgvLabReport.MasterTemplate.AllowAddNewRow = False
        Me.dgvLabReport.MasterTemplate.AllowColumnReorder = False
        GridViewCheckBoxColumn2.EnableExpressionEditor = False
        GridViewCheckBoxColumn2.EnableHeaderCheckBox = True
        GridViewCheckBoxColumn2.MinWidth = 20
        GridViewCheckBoxColumn2.Name = "colChkBox"
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "TransactionId"
        GridViewTextBoxColumn8.HeaderText = "Trans. Id."
        GridViewTextBoxColumn8.IsVisible = False
        GridViewTextBoxColumn8.Name = "ColTransactionId"
        GridViewTextBoxColumn8.Width = 10
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "LotNo"
        GridViewTextBoxColumn9.HeaderText = "Lot No."
        GridViewTextBoxColumn9.Name = "colLotNumber"
        GridViewTextBoxColumn9.Width = 100
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "OperationId"
        GridViewTextBoxColumn10.HeaderText = "Operation Id."
        GridViewTextBoxColumn10.IsVisible = False
        GridViewTextBoxColumn10.Name = "colOperationId"
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "OperationName"
        GridViewTextBoxColumn11.HeaderText = "Operation"
        GridViewTextBoxColumn11.Name = "colOperationName"
        GridViewTextBoxColumn11.Width = 345
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "IssueWt"
        GridViewTextBoxColumn12.HeaderText = "Issue Wt."
        GridViewTextBoxColumn12.Name = "colIssueWt"
        GridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn12.Width = 95
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "IssuePr"
        GridViewTextBoxColumn13.HeaderText = "Issue %"
        GridViewTextBoxColumn13.Name = "colIssuePr"
        GridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn13.Width = 95
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "FineWt"
        GridViewTextBoxColumn14.HeaderText = "Fine Wt."
        GridViewTextBoxColumn14.Name = "colFineWt"
        GridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn14.Width = 95
        Me.dgvLabReport.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewCheckBoxColumn2, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14})
        Me.dgvLabReport.MasterTemplate.EnableGrouping = False
        Me.dgvLabReport.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvLabReport.MasterTemplate.ViewDefinition = TableViewDefinition4
        Me.dgvLabReport.Name = "dgvLabReport"
        Me.dgvLabReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLabReport.Size = New System.Drawing.Size(793, 327)
        Me.dgvLabReport.TabIndex = 144
        '
        'btnUCancel
        '
        Me.btnUCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnUCancel.Location = New System.Drawing.Point(406, 540)
        Me.btnUCancel.Name = "btnUCancel"
        Me.btnUCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnUCancel.TabIndex = 143
        Me.btnUCancel.Text = "&Cancel"
        '
        'btnUSave
        '
        Me.btnUSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnUSave.Location = New System.Drawing.Point(327, 540)
        Me.btnUSave.Name = "btnUSave"
        Me.btnUSave.Size = New System.Drawing.Size(75, 25)
        Me.btnUSave.TabIndex = 142
        Me.btnUSave.Text = "&Save"
        '
        'GroupBox5
        '
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
        Me.GroupBox5.Controls.Add(Me.txtFineRptWt)
        Me.GroupBox5.Controls.Add(Me.txtIssuePr)
        Me.GroupBox5.Controls.Add(Me.txtIssueWt)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.Label3)
        Me.GroupBox5.Controls.Add(Me.lblReceiveGrossWt)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(4, 386)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(792, 146)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'txtTotalLossFine
        '
        Me.txtTotalLossFine.Location = New System.Drawing.Point(279, 116)
        Me.txtTotalLossFine.Name = "txtTotalLossFine"
        Me.txtTotalLossFine.ReadOnly = True
        Me.txtTotalLossFine.Size = New System.Drawing.Size(75, 20)
        Me.txtTotalLossFine.TabIndex = 166
        Me.txtTotalLossFine.TabStop = False
        Me.txtTotalLossFine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalRecTotal
        '
        Me.txtTotalRecTotal.Location = New System.Drawing.Point(279, 92)
        Me.txtTotalRecTotal.Name = "txtTotalRecTotal"
        Me.txtTotalRecTotal.ReadOnly = True
        Me.txtTotalRecTotal.Size = New System.Drawing.Size(75, 20)
        Me.txtTotalRecTotal.TabIndex = 164
        Me.txtTotalRecTotal.TabStop = False
        Me.txtTotalRecTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleGrossTotal
        '
        Me.txtSampleGrossTotal.Location = New System.Drawing.Point(279, 68)
        Me.txtSampleGrossTotal.Name = "txtSampleGrossTotal"
        Me.txtSampleGrossTotal.ReadOnly = True
        Me.txtSampleGrossTotal.Size = New System.Drawing.Size(75, 20)
        Me.txtSampleGrossTotal.TabIndex = 162
        Me.txtSampleGrossTotal.TabStop = False
        Me.txtSampleGrossTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleGrossPr
        '
        Me.txtSampleGrossPr.Location = New System.Drawing.Point(200, 67)
        Me.txtSampleGrossPr.Name = "txtSampleGrossPr"
        Me.txtSampleGrossPr.ReadOnly = True
        Me.txtSampleGrossPr.Size = New System.Drawing.Size(75, 20)
        Me.txtSampleGrossPr.TabIndex = 161
        Me.txtSampleGrossPr.TabStop = False
        Me.txtSampleGrossPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleFineTotal
        '
        Me.txtSampleFineTotal.Location = New System.Drawing.Point(279, 44)
        Me.txtSampleFineTotal.Name = "txtSampleFineTotal"
        Me.txtSampleFineTotal.ReadOnly = True
        Me.txtSampleFineTotal.Size = New System.Drawing.Size(75, 20)
        Me.txtSampleFineTotal.TabIndex = 160
        Me.txtSampleFineTotal.TabStop = False
        Me.txtSampleFineTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleFinePr
        '
        Me.txtSampleFinePr.Location = New System.Drawing.Point(200, 43)
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
        Me.txtDiff.Location = New System.Drawing.Point(279, 20)
        Me.txtDiff.Name = "txtDiff"
        Me.txtDiff.ReadOnly = True
        Me.txtDiff.Size = New System.Drawing.Size(75, 20)
        Me.txtDiff.TabIndex = 158
        Me.txtDiff.TabStop = False
        Me.txtDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalLossWt
        '
        Me.txtTotalLossWt.Location = New System.Drawing.Point(125, 115)
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
        Me.txtLabRptPr.Location = New System.Drawing.Point(125, 19)
        Me.txtLabRptPr.Name = "txtLabRptPr"
        Me.txtLabRptPr.Size = New System.Drawing.Size(71, 20)
        Me.txtLabRptPr.TabIndex = 0
        Me.txtLabRptPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalRecWt
        '
        Me.txtTotalRecWt.Location = New System.Drawing.Point(125, 91)
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
        Me.txtSampleGrossRec.Location = New System.Drawing.Point(125, 67)
        Me.txtSampleGrossRec.Name = "txtSampleGrossRec"
        Me.txtSampleGrossRec.Size = New System.Drawing.Size(71, 20)
        Me.txtSampleGrossRec.TabIndex = 2
        Me.txtSampleGrossRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSampleFineRec
        '
        Me.txtSampleFineRec.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtSampleFineRec.Location = New System.Drawing.Point(125, 43)
        Me.txtSampleFineRec.Name = "txtSampleFineRec"
        Me.txtSampleFineRec.Size = New System.Drawing.Size(71, 20)
        Me.txtSampleFineRec.TabIndex = 1
        Me.txtSampleFineRec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(65, 117)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 14)
        Me.Label10.TabIndex = 151
        Me.Label10.Text = "Loss Wt."
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(32, 93)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 14)
        Me.Label9.TabIndex = 150
        Me.Label9.Text = "Total Rec. Wt."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 14)
        Me.Label8.TabIndex = 149
        Me.Label8.Text = "Sample Gross Rec."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 14)
        Me.Label7.TabIndex = 148
        Me.Label7.Text = "Sample Fine Rec."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 14)
        Me.Label1.TabIndex = 147
        Me.Label1.Text = "Lab Report %"
        '
        'txtFineRptWt
        '
        Me.txtFineRptWt.Location = New System.Drawing.Point(699, 44)
        Me.txtFineRptWt.Name = "txtFineRptWt"
        Me.txtFineRptWt.ReadOnly = True
        Me.txtFineRptWt.Size = New System.Drawing.Size(75, 20)
        Me.txtFineRptWt.TabIndex = 145
        Me.txtFineRptWt.TabStop = False
        Me.txtFineRptWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssuePr
        '
        Me.txtIssuePr.Location = New System.Drawing.Point(612, 44)
        Me.txtIssuePr.Name = "txtIssuePr"
        Me.txtIssuePr.ReadOnly = True
        Me.txtIssuePr.Size = New System.Drawing.Size(75, 20)
        Me.txtIssuePr.TabIndex = 144
        Me.txtIssuePr.TabStop = False
        Me.txtIssuePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssueWt
        '
        Me.txtIssueWt.Location = New System.Drawing.Point(526, 44)
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
        Me.Label6.Location = New System.Drawing.Point(533, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(60, 14)
        Me.Label6.TabIndex = 140
        Me.Label6.Text = "Issue Wt."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(230, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 14)
        Me.Label5.TabIndex = 138
        Me.Label5.Text = "Diff. %"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(710, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 14)
        Me.Label3.TabIndex = 136
        Me.Label3.Text = "Fine Wt."
        '
        'lblReceiveGrossWt
        '
        Me.lblReceiveGrossWt.AutoSize = True
        Me.lblReceiveGrossWt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReceiveGrossWt.Location = New System.Drawing.Point(623, 25)
        Me.lblReceiveGrossWt.Name = "lblReceiveGrossWt"
        Me.lblReceiveGrossWt.Size = New System.Drawing.Size(51, 14)
        Me.lblReceiveGrossWt.TabIndex = 134
        Me.lblReceiveGrossWt.Text = "Issue %"
        '
        'GBoxRptUpdate
        '
        Me.GBoxRptUpdate.Controls.Add(Me.rbReBagSample)
        Me.GBoxRptUpdate.Controls.Add(Me.rbReLotSample)
        Me.GBoxRptUpdate.Controls.Add(Me.Label4)
        Me.GBoxRptUpdate.Controls.Add(Me.RptUpdateDt)
        Me.GBoxRptUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxRptUpdate.Location = New System.Drawing.Point(5, 5)
        Me.GBoxRptUpdate.Name = "GBoxRptUpdate"
        Me.GBoxRptUpdate.Size = New System.Drawing.Size(792, 50)
        Me.GBoxRptUpdate.TabIndex = 134
        Me.GBoxRptUpdate.TabStop = False
        '
        'rbReBagSample
        '
        Me.rbReBagSample.AutoSize = True
        Me.rbReBagSample.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rbReBagSample.Location = New System.Drawing.Point(440, 17)
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
        Me.rbReLotSample.Location = New System.Drawing.Point(335, 17)
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
        'RptUpdateDt
        '
        Me.RptUpdateDt.Checked = False
        Me.RptUpdateDt.CustomFormat = "mm-dd-yyyy"
        Me.RptUpdateDt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RptUpdateDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.RptUpdateDt.Location = New System.Drawing.Point(86, 17)
        Me.RptUpdateDt.Name = "RptUpdateDt"
        Me.RptUpdateDt.Size = New System.Drawing.Size(90, 21)
        Me.RptUpdateDt.TabIndex = 130
        '
        'frmLabIssue
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(809, 601)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmLabIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lab Issue"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnIEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCopy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnICancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnISave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDataSave.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDataSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLabIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLabIssue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxFilter.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.cmbLab, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMain1.ResumeLayout(False)
        Me.grpMain1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvLabReceipt.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLabReceipt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnRSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxLabReceipt.ResumeLayout(False)
        Me.GBoxLabReceipt.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvLabReport.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLabReport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnUSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
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
        CType(Me.txtFineRptWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxRptUpdate.ResumeLayout(False)
        Me.GBoxRptUpdate.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents lblLabName As Label
    Friend WithEvents lblIssueDt As Label
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GBoxLabReceipt As GroupBox
    Friend WithEvents lblReceiptDt As Label
    Friend WithEvents ReceiptDt As DateTimePicker
    Friend WithEvents txtLabPr As TextBox
    Friend WithEvents txtReceivePr As TextBox
    Friend WithEvents txtFineWt As TextBox
    Friend WithEvents GBoxFilter As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtTo As DateTimePicker
    Friend WithEvents lblTo As Label
    Friend WithEvents dtFr As DateTimePicker
    Friend WithEvents lblFr As Label
    Friend WithEvents grpMain1 As GroupBox
    Friend WithEvents rbBagSample As RadioButton
    Friend WithEvents rbLotSample As RadioButton
    Friend WithEvents rbRLotSample As RadioButton
    Friend WithEvents rbRBagSample As RadioButton
    Friend WithEvents Button1 As Button
    Friend WithEvents btnLabReport As Button
    Friend WithEvents GBoxRptUpdate As GroupBox
    Friend WithEvents rbReBagSample As RadioButton
    Friend WithEvents rbReLotSample As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents RptUpdateDt As DateTimePicker
    Friend WithEvents cmbLab As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents dgvDataSave As Telerik.WinControls.UI.RadGridView
    Friend WithEvents dgvLabIssue As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnRSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnRCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnICancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnISave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCopy As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnUCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnUSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtFineRptWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssuePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssueWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblReceiveGrossWt As Label
    Friend WithEvents dgvLabReport As Telerik.WinControls.UI.RadGridView
    Friend WithEvents dgvLabReceipt As Telerik.WinControls.UI.RadGridView
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTotalLossWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtLabRptPr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTotalRecWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleGrossRec As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleFineRec As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTotalLossFine As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTotalRecTotal As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleGrossTotal As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleGrossPr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleFineTotal As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSampleFinePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtDiff As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents chkRAll As CheckBox
    Friend WithEvents btnIEdit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
