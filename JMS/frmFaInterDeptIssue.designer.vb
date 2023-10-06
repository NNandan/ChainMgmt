<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFaInterDeptIssue
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
        Dim RadListDataItem1 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem2 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem3 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TbIDeptIssue = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTotalStockAdd = New System.Windows.Forms.Label()
        Me.lblTotalGrossPr = New System.Windows.Forms.Label()
        Me.lblTotalGrossWt = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.txtFineWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssuePr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssueWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtItemName = New Telerik.WinControls.UI.RadTextBox()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.Rmccmb = New Telerik.WinControls.UI.RadMultiColumnComboBox()
        Me.cmbItemType = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtSrNo = New Telerik.WinControls.UI.RadTextBox()
        Me.dgvIssue = New Telerik.WinControls.UI.RadGridView()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblClearRow = New System.Windows.Forms.Label()
        Me.txtFrKarigar = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbTLabour = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmbtDepartment = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmbfDepartment = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtVocucherNo = New Telerik.WinControls.UI.RadTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.lblLotNo = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstIssue = New System.Windows.Forms.ListView()
        Me.CIssueId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CIssueDt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CfDeptId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CfDepartment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CtDeptId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CtDepartment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CIssueNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CCreatedBy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TbIDeptIssue.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFineWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItemName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rmccmb, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rmccmb.EditorControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Rmccmb.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbItemType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtFrKarigar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTLabour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbtDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbfDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVocucherNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TbIDeptIssue
        '
        Me.TbIDeptIssue.Controls.Add(Me.TabPage1)
        Me.TbIDeptIssue.Controls.Add(Me.TabPage2)
        Me.TbIDeptIssue.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TbIDeptIssue.Location = New System.Drawing.Point(0, 0)
        Me.TbIDeptIssue.Name = "TbIDeptIssue"
        Me.TbIDeptIssue.SelectedIndex = 0
        Me.TbIDeptIssue.Size = New System.Drawing.Size(715, 536)
        Me.TbIDeptIssue.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(707, 509)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTotalStockAdd)
        Me.GroupBox1.Controls.Add(Me.lblTotalGrossPr)
        Me.GroupBox1.Controls.Add(Me.lblTotalGrossWt)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.txtFineWt)
        Me.GroupBox1.Controls.Add(Me.txtIssuePr)
        Me.GroupBox1.Controls.Add(Me.txtIssueWt)
        Me.GroupBox1.Controls.Add(Me.txtItemName)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.Rmccmb)
        Me.GroupBox1.Controls.Add(Me.cmbItemType)
        Me.GroupBox1.Controls.Add(Me.txtSrNo)
        Me.GroupBox1.Controls.Add(Me.dgvIssue)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 123)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(689, 380)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Issue Details"
        '
        'lblTotalStockAdd
        '
        Me.lblTotalStockAdd.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalStockAdd.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalStockAdd.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalStockAdd.Location = New System.Drawing.Point(598, 320)
        Me.lblTotalStockAdd.Name = "lblTotalStockAdd"
        Me.lblTotalStockAdd.Size = New System.Drawing.Size(60, 12)
        Me.lblTotalStockAdd.TabIndex = 801
        Me.lblTotalStockAdd.Text = "0"
        Me.lblTotalStockAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalGrossPr
        '
        Me.lblTotalGrossPr.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalGrossPr.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalGrossPr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalGrossPr.Location = New System.Drawing.Point(529, 320)
        Me.lblTotalGrossPr.Name = "lblTotalGrossPr"
        Me.lblTotalGrossPr.Size = New System.Drawing.Size(60, 12)
        Me.lblTotalGrossPr.TabIndex = 800
        Me.lblTotalGrossPr.Text = "0"
        Me.lblTotalGrossPr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalGrossWt
        '
        Me.lblTotalGrossWt.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalGrossWt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalGrossWt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalGrossWt.Location = New System.Drawing.Point(460, 320)
        Me.lblTotalGrossWt.Name = "lblTotalGrossWt"
        Me.lblTotalGrossWt.Size = New System.Drawing.Size(60, 12)
        Me.lblTotalGrossWt.TabIndex = 799
        Me.lblTotalGrossWt.Text = "0"
        Me.lblTotalGrossWt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(295, 320)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 14)
        Me.Label3.TabIndex = 798
        Me.Label3.Text = "Total"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(431, 348)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 797
        Me.btnExit.Text = "E&xit"
        '
        'txtFineWt
        '
        Me.txtFineWt.Location = New System.Drawing.Point(601, 28)
        Me.txtFineWt.Name = "txtFineWt"
        Me.txtFineWt.ReadOnly = True
        Me.txtFineWt.Size = New System.Drawing.Size(71, 20)
        Me.txtFineWt.TabIndex = 6
        Me.txtFineWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssuePr
        '
        Me.txtIssuePr.Location = New System.Drawing.Point(532, 28)
        Me.txtIssuePr.Name = "txtIssuePr"
        Me.txtIssuePr.ReadOnly = True
        Me.txtIssuePr.Size = New System.Drawing.Size(68, 20)
        Me.txtIssuePr.TabIndex = 4
        Me.txtIssuePr.TabStop = False
        Me.txtIssuePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssueWt
        '
        Me.txtIssueWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIssueWt.Location = New System.Drawing.Point(460, 28)
        Me.txtIssueWt.Name = "txtIssueWt"
        Me.txtIssueWt.Size = New System.Drawing.Size(71, 20)
        Me.txtIssueWt.TabIndex = 3
        Me.txtIssueWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(257, 28)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.ReadOnly = True
        Me.txtItemName.Size = New System.Drawing.Size(202, 20)
        Me.txtItemName.TabIndex = 2
        Me.txtItemName.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(354, 348)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 47
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(200, 348)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 46
        Me.btnSave.Text = "&Save"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(277, 348)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 48
        Me.btnDelete.Text = "&Delete"
        '
        'Rmccmb
        '
        Me.Rmccmb.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        '
        'Rmccmb.NestedRadGridView
        '
        Me.Rmccmb.EditorControl.BackColor = System.Drawing.SystemColors.Window
        Me.Rmccmb.EditorControl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rmccmb.EditorControl.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Rmccmb.EditorControl.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.Rmccmb.EditorControl.MasterTemplate.AllowAddNewRow = False
        Me.Rmccmb.EditorControl.MasterTemplate.AllowCellContextMenu = False
        Me.Rmccmb.EditorControl.MasterTemplate.AllowColumnChooser = False
        Me.Rmccmb.EditorControl.MasterTemplate.EnableGrouping = False
        Me.Rmccmb.EditorControl.MasterTemplate.ShowFilteringRow = False
        Me.Rmccmb.EditorControl.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.Rmccmb.EditorControl.Name = "NestedRadGridView"
        Me.Rmccmb.EditorControl.ReadOnly = True
        Me.Rmccmb.EditorControl.ShowGroupPanel = False
        Me.Rmccmb.EditorControl.Size = New System.Drawing.Size(240, 150)
        Me.Rmccmb.EditorControl.TabIndex = 0
        Me.Rmccmb.Location = New System.Drawing.Point(151, 28)
        Me.Rmccmb.Name = "Rmccmb"
        Me.Rmccmb.Size = New System.Drawing.Size(105, 20)
        Me.Rmccmb.TabIndex = 1
        Me.Rmccmb.TabStop = False
        '
        'cmbItemType
        '
        Me.cmbItemType.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        RadListDataItem1.Text = "Bags"
        RadListDataItem2.Text = "Voucher"
        RadListDataItem3.Text = "Finished Lots"
        Me.cmbItemType.Items.Add(RadListDataItem1)
        Me.cmbItemType.Items.Add(RadListDataItem2)
        Me.cmbItemType.Items.Add(RadListDataItem3)
        Me.cmbItemType.Location = New System.Drawing.Point(50, 28)
        Me.cmbItemType.Name = "cmbItemType"
        Me.cmbItemType.Size = New System.Drawing.Size(100, 20)
        Me.cmbItemType.TabIndex = 0
        '
        'txtSrNo
        '
        Me.txtSrNo.Location = New System.Drawing.Point(7, 28)
        Me.txtSrNo.Name = "txtSrNo"
        Me.txtSrNo.Size = New System.Drawing.Size(42, 20)
        Me.txtSrNo.TabIndex = 0
        Me.txtSrNo.TabStop = False
        '
        'dgvIssue
        '
        Me.dgvIssue.BackColor = System.Drawing.Color.White
        Me.dgvIssue.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvIssue.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvIssue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvIssue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvIssue.Location = New System.Drawing.Point(7, 49)
        '
        '
        '
        Me.dgvIssue.MasterTemplate.AllowAddNewRow = False
        Me.dgvIssue.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.HeaderText = "Sr."
        GridViewTextBoxColumn1.Name = "colSrNo"
        GridViewTextBoxColumn1.Width = 42
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.HeaderText = "Item Type"
        GridViewTextBoxColumn2.Name = "colBagType"
        GridViewTextBoxColumn2.Width = 100
        GridViewTextBoxColumn3.AllowGroup = False
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.HeaderText = "SlipBag No"
        GridViewTextBoxColumn3.Name = "colSlipBagNo"
        GridViewTextBoxColumn3.Width = 109
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.HeaderText = "ItemId"
        GridViewTextBoxColumn4.IsVisible = False
        GridViewTextBoxColumn4.Name = "colItemId"
        GridViewTextBoxColumn4.Width = 317
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.HeaderText = "Item Name"
        GridViewTextBoxColumn5.Name = "colItemName"
        GridViewTextBoxColumn5.Width = 205
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.HeaderText = "Issue Wt."
        GridViewTextBoxColumn6.Name = "colIssueWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 71
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.HeaderText = "Issue %"
        GridViewTextBoxColumn7.Name = "colIssuePr"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 71
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.HeaderText = "Fine Wt"
        GridViewTextBoxColumn8.Name = "colFineWt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 71
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "ReceiptId"
        GridViewTextBoxColumn9.HeaderText = "Receipt Id"
        GridViewTextBoxColumn9.IsVisible = False
        GridViewTextBoxColumn9.Name = "colReceiptId"
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "colReceiptDetailId"
        GridViewTextBoxColumn10.HeaderText = "Receipt Detai ld"
        GridViewTextBoxColumn10.IsVisible = False
        GridViewTextBoxColumn10.Name = "colReceiptDetailId"
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "UsedBagId"
        GridViewTextBoxColumn11.HeaderText = "Used Bag Id"
        GridViewTextBoxColumn11.IsVisible = False
        GridViewTextBoxColumn11.Name = "colUsedBagId"
        Me.dgvIssue.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11})
        Me.dgvIssue.MasterTemplate.EnableGrouping = False
        Me.dgvIssue.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvIssue.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvIssue.Name = "dgvIssue"
        Me.dgvIssue.ReadOnly = True
        Me.dgvIssue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvIssue.Size = New System.Drawing.Size(666, 263)
        Me.dgvIssue.TabIndex = 1
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.Label9)
        Me.GBoxMain.Controls.Add(Me.lblClearRow)
        Me.GBoxMain.Controls.Add(Me.txtFrKarigar)
        Me.GBoxMain.Controls.Add(Me.cmbTLabour)
        Me.GBoxMain.Controls.Add(Me.cmbtDepartment)
        Me.GBoxMain.Controls.Add(Me.cmbfDepartment)
        Me.GBoxMain.Controls.Add(Me.txtVocucherNo)
        Me.GBoxMain.Controls.Add(Me.Label2)
        Me.GBoxMain.Controls.Add(Me.Label4)
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.Label7)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Controls.Add(Me.lblLotNo)
        Me.GBoxMain.Controls.Add(Me.Label28)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(7, 8)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Size = New System.Drawing.Size(689, 110)
        Me.GBoxMain.TabIndex = 22
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Inter Dept. Issue"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(471, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(200, 14)
        Me.Label9.TabIndex = 155
        Me.Label9.Text = "Press (F12) to Delete selected row"
        '
        'lblClearRow
        '
        Me.lblClearRow.AutoSize = True
        Me.lblClearRow.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblClearRow.Location = New System.Drawing.Point(9, 86)
        Me.lblClearRow.Name = "lblClearRow"
        Me.lblClearRow.Size = New System.Drawing.Size(179, 14)
        Me.lblClearRow.TabIndex = 154
        Me.lblClearRow.Text = "Press (F2) to Clear Issue Details"
        '
        'txtFrKarigar
        '
        Me.txtFrKarigar.Location = New System.Drawing.Point(534, 28)
        Me.txtFrKarigar.Name = "txtFrKarigar"
        Me.txtFrKarigar.ReadOnly = True
        Me.txtFrKarigar.Size = New System.Drawing.Size(132, 20)
        Me.txtFrKarigar.TabIndex = 4
        '
        'cmbTLabour
        '
        Me.cmbTLabour.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbTLabour.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbTLabour.Location = New System.Drawing.Point(534, 57)
        Me.cmbTLabour.Name = "cmbTLabour"
        Me.cmbTLabour.Size = New System.Drawing.Size(132, 20)
        Me.cmbTLabour.TabIndex = 5
        '
        'cmbtDepartment
        '
        Me.cmbtDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbtDepartment.Location = New System.Drawing.Point(285, 56)
        Me.cmbtDepartment.Name = "cmbtDepartment"
        Me.cmbtDepartment.Size = New System.Drawing.Size(125, 20)
        Me.cmbtDepartment.TabIndex = 3
        '
        'cmbfDepartment
        '
        Me.cmbfDepartment.Location = New System.Drawing.Point(285, 27)
        Me.cmbfDepartment.Name = "cmbfDepartment"
        Me.cmbfDepartment.Size = New System.Drawing.Size(125, 20)
        Me.cmbfDepartment.TabIndex = 2
        '
        'txtVocucherNo
        '
        Me.txtVocucherNo.Location = New System.Drawing.Point(92, 56)
        Me.txtVocucherNo.Name = "txtVocucherNo"
        Me.txtVocucherNo.ReadOnly = True
        Me.txtVocucherNo.Size = New System.Drawing.Size(85, 20)
        Me.txtVocucherNo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(470, 60)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 14)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Carried By"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(456, 31)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 14)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Fr Employee"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(224, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 14)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "To. Dept"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(229, 30)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Fr. Dept"
        '
        'TransDt
        '
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(93, 27)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(85, 22)
        Me.TransDt.TabIndex = 0
        '
        'lblLotNo
        '
        Me.lblLotNo.AutoSize = True
        Me.lblLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblLotNo.Location = New System.Drawing.Point(16, 58)
        Me.lblLotNo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblLotNo.Name = "lblLotNo"
        Me.lblLotNo.Size = New System.Drawing.Size(72, 14)
        Me.lblLotNo.TabIndex = 1
        Me.lblLotNo.Text = "Voucher No"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label28.Location = New System.Drawing.Point(37, 31)
        Me.Label28.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(52, 14)
        Me.Label28.TabIndex = 1
        Me.Label28.Text = "Issue Dt"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstIssue)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(707, 509)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstIssue
        '
        Me.lstIssue.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CIssueId, Me.CIssueDt, Me.CfDeptId, Me.CfDepartment, Me.CtDeptId, Me.CtDepartment, Me.CIssueNo, Me.CCreatedBy})
        Me.lstIssue.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstIssue.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstIssue.FullRowSelect = True
        Me.lstIssue.GridLines = True
        Me.lstIssue.Location = New System.Drawing.Point(3, 3)
        Me.lstIssue.Name = "lstIssue"
        Me.lstIssue.Size = New System.Drawing.Size(701, 503)
        Me.lstIssue.TabIndex = 1
        Me.lstIssue.UseCompatibleStateImageBehavior = False
        Me.lstIssue.View = System.Windows.Forms.View.Details
        '
        'CIssueId
        '
        Me.CIssueId.Text = "Issue Id"
        '
        'CIssueDt
        '
        Me.CIssueDt.Text = "Issue Dt"
        Me.CIssueDt.Width = 125
        '
        'CfDeptId
        '
        Me.CfDeptId.Text = "fDept Id"
        Me.CfDeptId.Width = 0
        '
        'CfDepartment
        '
        Me.CfDepartment.Text = "Fr. Dept"
        Me.CfDepartment.Width = 101
        '
        'CtDeptId
        '
        Me.CtDeptId.Text = "tDept Id"
        Me.CtDeptId.Width = 0
        '
        'CtDepartment
        '
        Me.CtDepartment.Text = "To. Dept"
        Me.CtDepartment.Width = 166
        '
        'CIssueNo
        '
        Me.CIssueNo.Text = "Voucher No"
        Me.CIssueNo.Width = 100
        '
        'CCreatedBy
        '
        Me.CCreatedBy.Text = "Created By"
        Me.CCreatedBy.Width = 171
        '
        'frmFaInterDeptIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(713, 536)
        Me.Controls.Add(Me.TbIDeptIssue)
        Me.Font = New System.Drawing.Font("Tahoma", 14.2!)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "frmFaInterDeptIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inter Dept. Issue Voucer"
        Me.TbIDeptIssue.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFineWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItemName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rmccmb.EditorControl.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rmccmb.EditorControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Rmccmb, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbItemType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtFrKarigar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTLabour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbtDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbfDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVocucherNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TbIDeptIssue As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents txtFrKarigar As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbTLabour As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmbtDepartment As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmbfDepartment As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtVocucherNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents lblLotNo As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dgvIssue As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtSrNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Rmccmb As Telerik.WinControls.UI.RadMultiColumnComboBox
    Friend WithEvents cmbItemType As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents lstIssue As ListView
    Friend WithEvents CIssueId As ColumnHeader
    Friend WithEvents CIssueDt As ColumnHeader
    Friend WithEvents CfDeptId As ColumnHeader
    Friend WithEvents CfDepartment As ColumnHeader
    Friend WithEvents CtDeptId As ColumnHeader
    Friend WithEvents CtDepartment As ColumnHeader
    Friend WithEvents CIssueNo As ColumnHeader
    Friend WithEvents CCreatedBy As ColumnHeader
    Friend WithEvents txtItemName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssueWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssuePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtFineWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblTotalStockAdd As Label
    Friend WithEvents lblTotalGrossPr As Label
    Friend WithEvents lblTotalGrossWt As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblClearRow As Label
    Friend WithEvents Label9 As Label
End Class
