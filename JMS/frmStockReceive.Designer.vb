<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStockReceive
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridViewTextBoxColumn21 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn22 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn23 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn24 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn25 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn26 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn27 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn28 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn29 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn30 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.tbStockReceive = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBoxDetails = New System.Windows.Forms.GroupBox()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.dgvReceive = New Telerik.WinControls.UI.RadGridView()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.cmbVoucherNo = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtTransNo = New Telerik.WinControls.UI.RadTextBox()
        Me.txtFrKarigar = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbTLabour = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmbtDepartment = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmbfDepartment = New Telerik.WinControls.UI.RadDropDownList()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblVoucherNo = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lstReceive = New System.Windows.Forms.ListView()
        Me.CIReceiptId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CIReceiptDt = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CfDeptId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CfDepartment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CtDeptId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CtDepartment = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CReceiptNo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CCreatedBy = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.tbStockReceive.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBoxDetails.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.cmbVoucherNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTransNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFrKarigar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbTLabour, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbtDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbfDepartment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbStockReceive
        '
        Me.tbStockReceive.Controls.Add(Me.TabPage1)
        Me.tbStockReceive.Controls.Add(Me.TabPage2)
        Me.tbStockReceive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbStockReceive.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.tbStockReceive.Location = New System.Drawing.Point(0, 0)
        Me.tbStockReceive.Margin = New System.Windows.Forms.Padding(5)
        Me.tbStockReceive.Name = "tbStockReceive"
        Me.tbStockReceive.SelectedIndex = 0
        Me.tbStockReceive.Size = New System.Drawing.Size(722, 537)
        Me.tbStockReceive.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.GBoxDetails)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Size = New System.Drawing.Size(714, 510)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        '
        'GBoxDetails
        '
        Me.GBoxDetails.Controls.Add(Me.btnExit)
        Me.GBoxDetails.Controls.Add(Me.btnCancel)
        Me.GBoxDetails.Controls.Add(Me.btnSave)
        Me.GBoxDetails.Controls.Add(Me.btnDelete)
        Me.GBoxDetails.Controls.Add(Me.dgvReceive)
        Me.GBoxDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxDetails.Location = New System.Drawing.Point(6, 108)
        Me.GBoxDetails.Name = "GBoxDetails"
        Me.GBoxDetails.Size = New System.Drawing.Size(706, 398)
        Me.GBoxDetails.TabIndex = 23
        Me.GBoxDetails.TabStop = False
        Me.GBoxDetails.Text = "Receipt Details"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(441, 370)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "E&xit"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(363, 370)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(207, 370)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(285, 370)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "&Delete"
        '
        'dgvReceive
        '
        Me.dgvReceive.BackColor = System.Drawing.Color.White
        Me.dgvReceive.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvReceive.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvReceive.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvReceive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvReceive.Location = New System.Drawing.Point(7, 25)
        '
        '
        '
        Me.dgvReceive.MasterTemplate.AllowAddNewRow = False
        Me.dgvReceive.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn21.EnableExpressionEditor = False
        GridViewTextBoxColumn21.HeaderText = "Sr."
        GridViewTextBoxColumn21.Name = "colSrNo"
        GridViewTextBoxColumn21.Width = 42
        GridViewTextBoxColumn22.EnableExpressionEditor = False
        GridViewTextBoxColumn22.FieldName = "ItemType"
        GridViewTextBoxColumn22.HeaderText = "Item Type"
        GridViewTextBoxColumn22.Name = "colItemType"
        GridViewTextBoxColumn22.Width = 80
        GridViewTextBoxColumn23.EnableExpressionEditor = False
        GridViewTextBoxColumn23.FieldName = "SlipBagNo"
        GridViewTextBoxColumn23.HeaderText = "Slip/Bag No"
        GridViewTextBoxColumn23.Name = "colSlipBagNo"
        GridViewTextBoxColumn23.Width = 80
        GridViewTextBoxColumn24.EnableExpressionEditor = False
        GridViewTextBoxColumn24.FieldName = "ItemId"
        GridViewTextBoxColumn24.FormatString = "{0:F2}"
        GridViewTextBoxColumn24.HeaderText = "Item Id"
        GridViewTextBoxColumn24.IsVisible = False
        GridViewTextBoxColumn24.Name = "colItemId"
        GridViewTextBoxColumn24.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn24.Width = 75
        GridViewTextBoxColumn25.EnableExpressionEditor = False
        GridViewTextBoxColumn25.FieldName = "ItemName"
        GridViewTextBoxColumn25.FormatString = "{0:F2}"
        GridViewTextBoxColumn25.HeaderText = "Item Name"
        GridViewTextBoxColumn25.Name = "colItemName"
        GridViewTextBoxColumn25.Width = 185
        GridViewTextBoxColumn26.EnableExpressionEditor = False
        GridViewTextBoxColumn26.FieldName = "IssueWt"
        GridViewTextBoxColumn26.FormatString = "{0:F2}"
        GridViewTextBoxColumn26.HeaderText = "Receive Wt."
        GridViewTextBoxColumn26.Name = "colReceiveWt"
        GridViewTextBoxColumn26.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn26.Width = 80
        GridViewTextBoxColumn27.EnableExpressionEditor = False
        GridViewTextBoxColumn27.FieldName = "IssuePr"
        GridViewTextBoxColumn27.HeaderText = "Receive %"
        GridViewTextBoxColumn27.Name = "colReceivePr"
        GridViewTextBoxColumn27.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn27.Width = 80
        GridViewTextBoxColumn28.EnableExpressionEditor = False
        GridViewTextBoxColumn28.FieldName = "ConvPr"
        GridViewTextBoxColumn28.HeaderText = "Conv %"
        GridViewTextBoxColumn28.Name = "colConvPr"
        GridViewTextBoxColumn28.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn28.Width = 70
        GridViewTextBoxColumn29.EnableExpressionEditor = False
        GridViewTextBoxColumn29.FieldName = "FineWt"
        GridViewTextBoxColumn29.HeaderText = "Fine Wt."
        GridViewTextBoxColumn29.Name = "colFineWt"
        GridViewTextBoxColumn29.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn29.Width = 80
        GridViewTextBoxColumn30.EnableExpressionEditor = False
        GridViewTextBoxColumn30.FieldName = "StockAdd"
        GridViewTextBoxColumn30.HeaderText = "Stock Add"
        GridViewTextBoxColumn30.IsVisible = False
        GridViewTextBoxColumn30.Name = "colStockAdd"
        GridViewTextBoxColumn30.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn30.Width = 80
        Me.dgvReceive.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn21, GridViewTextBoxColumn22, GridViewTextBoxColumn23, GridViewTextBoxColumn24, GridViewTextBoxColumn25, GridViewTextBoxColumn26, GridViewTextBoxColumn27, GridViewTextBoxColumn28, GridViewTextBoxColumn29, GridViewTextBoxColumn30})
        Me.dgvReceive.MasterTemplate.EnableGrouping = False
        Me.dgvReceive.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvReceive.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.dgvReceive.Name = "dgvReceive"
        Me.dgvReceive.ReadOnly = True
        Me.dgvReceive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvReceive.Size = New System.Drawing.Size(694, 338)
        Me.dgvReceive.TabIndex = 0
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.cmbVoucherNo)
        Me.GBoxMain.Controls.Add(Me.txtTransNo)
        Me.GBoxMain.Controls.Add(Me.txtFrKarigar)
        Me.GBoxMain.Controls.Add(Me.cmbTLabour)
        Me.GBoxMain.Controls.Add(Me.cmbtDepartment)
        Me.GBoxMain.Controls.Add(Me.cmbfDepartment)
        Me.GBoxMain.Controls.Add(Me.Label2)
        Me.GBoxMain.Controls.Add(Me.Label4)
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.Label7)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Controls.Add(Me.Label26)
        Me.GBoxMain.Controls.Add(Me.lblVoucherNo)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxMain.Location = New System.Drawing.Point(6, 4)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Size = New System.Drawing.Size(704, 100)
        Me.GBoxMain.TabIndex = 21
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Stock Receive"
        '
        'cmbVoucherNo
        '
        Me.cmbVoucherNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbVoucherNo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbVoucherNo.Location = New System.Drawing.Point(106, 56)
        Me.cmbVoucherNo.Name = "cmbVoucherNo"
        Me.cmbVoucherNo.Size = New System.Drawing.Size(85, 20)
        Me.cmbVoucherNo.TabIndex = 46
        '
        'txtTransNo
        '
        Me.txtTransNo.Location = New System.Drawing.Point(193, 27)
        Me.txtTransNo.Name = "txtTransNo"
        Me.txtTransNo.Size = New System.Drawing.Size(12, 20)
        Me.txtTransNo.TabIndex = 45
        Me.txtTransNo.Visible = False
        '
        'txtFrKarigar
        '
        Me.txtFrKarigar.Location = New System.Drawing.Point(573, 30)
        Me.txtFrKarigar.Name = "txtFrKarigar"
        Me.txtFrKarigar.ReadOnly = True
        Me.txtFrKarigar.Size = New System.Drawing.Size(125, 20)
        Me.txtFrKarigar.TabIndex = 4
        '
        'cmbTLabour
        '
        Me.cmbTLabour.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbTLabour.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbTLabour.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbTLabour.Location = New System.Drawing.Point(573, 59)
        Me.cmbTLabour.Name = "cmbTLabour"
        Me.cmbTLabour.Size = New System.Drawing.Size(125, 20)
        Me.cmbTLabour.TabIndex = 5
        '
        'cmbtDepartment
        '
        Me.cmbtDepartment.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbtDepartment.Location = New System.Drawing.Point(324, 56)
        Me.cmbtDepartment.Name = "cmbtDepartment"
        Me.cmbtDepartment.Size = New System.Drawing.Size(125, 20)
        Me.cmbtDepartment.TabIndex = 3
        '
        'cmbfDepartment
        '
        Me.cmbfDepartment.Location = New System.Drawing.Point(324, 27)
        Me.cmbfDepartment.Name = "cmbfDepartment"
        Me.cmbfDepartment.Size = New System.Drawing.Size(125, 20)
        Me.cmbfDepartment.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(487, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 14)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "To. Employee"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(492, 33)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 14)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Fr. Employee"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(264, 59)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 14)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "To. Dept"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(269, 30)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 14)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Fr. Dept"
        '
        'TransDt
        '
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(106, 27)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(85, 22)
        Me.TransDt.TabIndex = 0
        Me.TransDt.TabStop = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label26.Location = New System.Drawing.Point(32, 30)
        Me.Label26.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(69, 14)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "Receipt Dt."
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblVoucherNo.Location = New System.Drawing.Point(11, 59)
        Me.lblVoucherNo.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(91, 14)
        Me.lblVoucherNo.TabIndex = 1
        Me.lblVoucherNo.Text = "Select Voucher"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstReceive)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(714, 510)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstReceive
        '
        Me.lstReceive.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CIReceiptId, Me.CIReceiptDt, Me.CfDeptId, Me.CfDepartment, Me.CtDeptId, Me.CtDepartment, Me.CReceiptNo, Me.CCreatedBy})
        Me.lstReceive.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstReceive.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstReceive.FullRowSelect = True
        Me.lstReceive.GridLines = True
        Me.lstReceive.Location = New System.Drawing.Point(0, 0)
        Me.lstReceive.Name = "lstReceive"
        Me.lstReceive.Size = New System.Drawing.Size(714, 510)
        Me.lstReceive.TabIndex = 0
        Me.lstReceive.UseCompatibleStateImageBehavior = False
        Me.lstReceive.View = System.Windows.Forms.View.Details
        '
        'CIReceiptId
        '
        Me.CIReceiptId.Text = "Receipt Id"
        Me.CIReceiptId.Width = 80
        '
        'CIReceiptDt
        '
        Me.CIReceiptDt.Text = "Receipt Dt."
        Me.CIReceiptDt.Width = 80
        '
        'CfDeptId
        '
        Me.CfDeptId.Text = "Dept Id"
        Me.CfDeptId.Width = 0
        '
        'CfDepartment
        '
        Me.CfDepartment.Text = "Fr Dept."
        Me.CfDepartment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CfDepartment.Width = 125
        '
        'CtDeptId
        '
        Me.CtDeptId.Width = 0
        '
        'CtDepartment
        '
        Me.CtDepartment.Text = "To Dept."
        Me.CtDepartment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CtDepartment.Width = 125
        '
        'CReceiptNo
        '
        Me.CReceiptNo.Text = "Voucher No"
        Me.CReceiptNo.Width = 110
        '
        'CCreatedBy
        '
        Me.CCreatedBy.Text = "Created By"
        Me.CCreatedBy.Width = 203
        '
        'frmStockReceive
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(722, 537)
        Me.Controls.Add(Me.tbStockReceive)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "frmStockReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Receive"
        Me.tbStockReceive.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBoxDetails.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.cmbVoucherNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTransNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFrKarigar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbTLabour, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbtDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbfDepartment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tbStockReceive As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxDetails As GroupBox
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents dgvReceive As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents txtFrKarigar As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbTLabour As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmbtDepartment As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents cmbfDepartment As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents Label26 As Label
    Friend WithEvents lblVoucherNo As Label
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents lstReceive As ListView
    Friend WithEvents CIReceiptId As ColumnHeader
    Friend WithEvents CIReceiptDt As ColumnHeader
    Friend WithEvents CfDeptId As ColumnHeader
    Friend WithEvents CfDepartment As ColumnHeader
    Friend WithEvents CtDeptId As ColumnHeader
    Friend WithEvents CtDepartment As ColumnHeader
    Friend WithEvents CReceiptNo As ColumnHeader
    Friend WithEvents CCreatedBy As ColumnHeader
    Friend WithEvents txtTransNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbVoucherNo As Telerik.WinControls.UI.RadDropDownList
End Class
