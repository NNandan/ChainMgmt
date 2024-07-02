<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFMeltingAlloyReport
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TbMelting = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBoxDetails = New System.Windows.Forms.GroupBox()
        Me.txtFineAdd = New Telerik.WinControls.UI.RadTextBox()
        Me.lblFineAdd = New Telerik.WinControls.UI.RadLabel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtStockAdd = New Telerik.WinControls.UI.RadTextBox()
        Me.GBoxTotal = New System.Windows.Forms.GroupBox()
        Me.lblTmpTotal = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAlloyTotal = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotalFineWt = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblGrossTotal = New System.Windows.Forms.Label()
        Me.dgvMelting = New Telerik.WinControls.UI.RadGridView()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.txtToKarigar = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbLotNo = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtConvertToMelting = New Telerik.WinControls.UI.RadTextBox()
        Me.txtItem = New Telerik.WinControls.UI.RadTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMelting = New Telerik.WinControls.UI.RadTextBox()
        Me.txtFrKarigar = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TbMelting.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBoxDetails.SuspendLayout()
        CType(Me.txtFineAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblFineAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStockAdd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxTotal.SuspendLayout()
        CType(Me.dgvMelting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMelting.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtToKarigar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConvertToMelting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMelting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFrKarigar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TbMelting
        '
        Me.TbMelting.Controls.Add(Me.TabPage1)
        Me.TbMelting.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TbMelting.Location = New System.Drawing.Point(0, 0)
        Me.TbMelting.Margin = New System.Windows.Forms.Padding(8, 9, 8, 9)
        Me.TbMelting.Name = "TbMelting"
        Me.TbMelting.SelectedIndex = 0
        Me.TbMelting.Size = New System.Drawing.Size(815, 540)
        Me.TbMelting.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GBoxDetails)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Size = New System.Drawing.Size(807, 513)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GBoxDetails
        '
        Me.GBoxDetails.Controls.Add(Me.txtFineAdd)
        Me.GBoxDetails.Controls.Add(Me.lblFineAdd)
        Me.GBoxDetails.Controls.Add(Me.Label11)
        Me.GBoxDetails.Controls.Add(Me.txtStockAdd)
        Me.GBoxDetails.Controls.Add(Me.GBoxTotal)
        Me.GBoxDetails.Controls.Add(Me.dgvMelting)
        Me.GBoxDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxDetails.Location = New System.Drawing.Point(7, 125)
        Me.GBoxDetails.Name = "GBoxDetails"
        Me.GBoxDetails.Size = New System.Drawing.Size(790, 377)
        Me.GBoxDetails.TabIndex = 20
        Me.GBoxDetails.TabStop = False
        Me.GBoxDetails.Text = "Melting Details"
        '
        'txtFineAdd
        '
        Me.txtFineAdd.Location = New System.Drawing.Point(122, 346)
        Me.txtFineAdd.Name = "txtFineAdd"
        Me.txtFineAdd.ReadOnly = True
        Me.txtFineAdd.Size = New System.Drawing.Size(100, 20)
        Me.txtFineAdd.TabIndex = 8
        Me.txtFineAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFineAdd
        '
        Me.lblFineAdd.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblFineAdd.Location = New System.Drawing.Point(64, 347)
        Me.lblFineAdd.Name = "lblFineAdd"
        Me.lblFineAdd.Size = New System.Drawing.Size(54, 18)
        Me.lblFineAdd.TabIndex = 806
        Me.lblFineAdd.Text = "Fine Add"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 325)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 14)
        Me.Label11.TabIndex = 803
        Me.Label11.Text = "Melting Stock Add"
        '
        'txtStockAdd
        '
        Me.txtStockAdd.Location = New System.Drawing.Point(122, 322)
        Me.txtStockAdd.Name = "txtStockAdd"
        Me.txtStockAdd.ReadOnly = True
        Me.txtStockAdd.Size = New System.Drawing.Size(100, 20)
        Me.txtStockAdd.TabIndex = 7
        Me.txtStockAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GBoxTotal
        '
        Me.GBoxTotal.Controls.Add(Me.lblTmpTotal)
        Me.GBoxTotal.Controls.Add(Me.lblTotal)
        Me.GBoxTotal.Controls.Add(Me.Label5)
        Me.GBoxTotal.Controls.Add(Me.Label3)
        Me.GBoxTotal.Controls.Add(Me.lblAlloyTotal)
        Me.GBoxTotal.Controls.Add(Me.Label6)
        Me.GBoxTotal.Controls.Add(Me.lblTotalFineWt)
        Me.GBoxTotal.Controls.Add(Me.Label4)
        Me.GBoxTotal.Controls.Add(Me.lblGrossTotal)
        Me.GBoxTotal.Location = New System.Drawing.Point(490, 279)
        Me.GBoxTotal.Name = "GBoxTotal"
        Me.GBoxTotal.Size = New System.Drawing.Size(294, 89)
        Me.GBoxTotal.TabIndex = 801
        Me.GBoxTotal.TabStop = False
        '
        'lblTmpTotal
        '
        Me.lblTmpTotal.AutoSize = True
        Me.lblTmpTotal.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTmpTotal.Location = New System.Drawing.Point(228, 43)
        Me.lblTmpTotal.Name = "lblTmpTotal"
        Me.lblTmpTotal.Size = New System.Drawing.Size(0, 14)
        Me.lblTmpTotal.TabIndex = 785
        Me.lblTmpTotal.Visible = False
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotal.Location = New System.Drawing.Point(85, 18)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(60, 12)
        Me.lblTotal.TabIndex = 784
        Me.lblTotal.Text = "0"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label5.Location = New System.Drawing.Point(43, 18)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 14)
        Me.Label5.TabIndex = 783
        Me.Label5.Text = "Total"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(45, 40)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 14)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Alloy"
        '
        'lblAlloyTotal
        '
        Me.lblAlloyTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblAlloyTotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlloyTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblAlloyTotal.Location = New System.Drawing.Point(85, 41)
        Me.lblAlloyTotal.Name = "lblAlloyTotal"
        Me.lblAlloyTotal.Size = New System.Drawing.Size(60, 12)
        Me.lblAlloyTotal.TabIndex = 779
        Me.lblAlloyTotal.Text = "0"
        Me.lblAlloyTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(165, 18)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 14)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Fine Wt."
        '
        'lblTotalFineWt
        '
        Me.lblTotalFineWt.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalFineWt.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFineWt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblTotalFineWt.Location = New System.Drawing.Point(226, 18)
        Me.lblTotalFineWt.Name = "lblTotalFineWt"
        Me.lblTotalFineWt.Size = New System.Drawing.Size(60, 12)
        Me.lblTotalFineWt.TabIndex = 781
        Me.lblTotalFineWt.Text = "0"
        Me.lblTotalFineWt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label4.Location = New System.Drawing.Point(8, 61)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 14)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Gross Total"
        '
        'lblGrossTotal
        '
        Me.lblGrossTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblGrossTotal.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrossTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblGrossTotal.Location = New System.Drawing.Point(85, 64)
        Me.lblGrossTotal.Name = "lblGrossTotal"
        Me.lblGrossTotal.Size = New System.Drawing.Size(60, 12)
        Me.lblGrossTotal.TabIndex = 782
        Me.lblGrossTotal.Text = "0"
        Me.lblGrossTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvMelting
        '
        Me.dgvMelting.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvMelting.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvMelting.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvMelting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMelting.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvMelting.Location = New System.Drawing.Point(3, 22)
        '
        '
        '
        Me.dgvMelting.MasterTemplate.AllowAddNewRow = False
        Me.dgvMelting.MasterTemplate.AllowColumnReorder = False
        Me.dgvMelting.MasterTemplate.AllowDeleteRow = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.HeaderText = "Sr."
        GridViewTextBoxColumn1.Name = "GSrNo"
        GridViewTextBoxColumn1.ReadOnly = True
        GridViewTextBoxColumn1.Width = 42
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.HeaderText = "Item Type"
        GridViewTextBoxColumn2.Name = "GItemType"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 100
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.HeaderText = "Slip/Bag No. "
        GridViewTextBoxColumn3.Name = "GSlipBagNo"
        GridViewTextBoxColumn3.Width = 150
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.HeaderText = "ItemBagId"
        GridViewTextBoxColumn4.IsVisible = False
        GridViewTextBoxColumn4.Name = "GItemId"
        GridViewTextBoxColumn4.Width = 92
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.HeaderText = "Item Name"
        GridViewTextBoxColumn5.Name = "GItemName"
        GridViewTextBoxColumn5.ReadOnly = True
        GridViewTextBoxColumn5.Width = 275
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.HeaderText = "Gross Wt."
        GridViewTextBoxColumn6.Name = "GGrossWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 75
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.HeaderText = "Percent [%]"
        GridViewTextBoxColumn7.Name = "GRequirePr"
        GridViewTextBoxColumn7.ReadOnly = True
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 73
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.HeaderText = "Fine Wt."
        GridViewTextBoxColumn8.Name = "GFineWt"
        GridViewTextBoxColumn8.ReadOnly = True
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 71
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "IssueId"
        GridViewTextBoxColumn9.HeaderText = "Line No"
        GridViewTextBoxColumn9.IsVisible = False
        GridViewTextBoxColumn9.Name = "GLineNo"
        Me.dgvMelting.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9})
        Me.dgvMelting.MasterTemplate.EnableGrouping = False
        Me.dgvMelting.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvMelting.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvMelting.Name = "dgvMelting"
        Me.dgvMelting.ReadOnly = True
        Me.dgvMelting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMelting.Size = New System.Drawing.Size(783, 257)
        Me.dgvMelting.TabIndex = 788
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.txtToKarigar)
        Me.GBoxMain.Controls.Add(Me.cmbLotNo)
        Me.GBoxMain.Controls.Add(Me.txtConvertToMelting)
        Me.GBoxMain.Controls.Add(Me.txtItem)
        Me.GBoxMain.Controls.Add(Me.Label12)
        Me.GBoxMain.Controls.Add(Me.txtMelting)
        Me.GBoxMain.Controls.Add(Me.txtFrKarigar)
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.Label8)
        Me.GBoxMain.Controls.Add(Me.Label7)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Controls.Add(Me.Label2)
        Me.GBoxMain.Controls.Add(Me.Label26)
        Me.GBoxMain.Controls.Add(Me.Label28)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(7, 10)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(5)
        Me.GBoxMain.Size = New System.Drawing.Size(790, 109)
        Me.GBoxMain.TabIndex = 19
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Melting Information"
        '
        'txtToKarigar
        '
        Me.txtToKarigar.Location = New System.Drawing.Point(648, 53)
        Me.txtToKarigar.Name = "txtToKarigar"
        Me.txtToKarigar.Size = New System.Drawing.Size(128, 20)
        Me.txtToKarigar.TabIndex = 805
        '
        'cmbLotNo
        '
        Me.cmbLotNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbLotNo.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbLotNo.Location = New System.Drawing.Point(89, 28)
        Me.cmbLotNo.Name = "cmbLotNo"
        Me.cmbLotNo.Size = New System.Drawing.Size(100, 20)
        Me.cmbLotNo.TabIndex = 0
        '
        'txtConvertToMelting
        '
        Me.txtConvertToMelting.Location = New System.Drawing.Point(360, 81)
        Me.txtConvertToMelting.Name = "txtConvertToMelting"
        Me.txtConvertToMelting.ReadOnly = True
        Me.txtConvertToMelting.Size = New System.Drawing.Size(100, 20)
        Me.txtConvertToMelting.TabIndex = 4
        Me.txtConvertToMelting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtItem
        '
        Me.txtItem.Location = New System.Drawing.Point(360, 54)
        Me.txtItem.Name = "txtItem"
        Me.txtItem.ReadOnly = True
        Me.txtItem.Size = New System.Drawing.Size(100, 20)
        Me.txtItem.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(248, 84)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 14)
        Me.Label12.TabIndex = 804
        Me.Label12.Text = "Convert to Melting"
        '
        'txtMelting
        '
        Me.txtMelting.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMelting.Location = New System.Drawing.Point(360, 27)
        Me.txtMelting.Name = "txtMelting"
        Me.txtMelting.Size = New System.Drawing.Size(100, 20)
        Me.txtMelting.TabIndex = 2
        Me.txtMelting.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFrKarigar
        '
        Me.txtFrKarigar.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtFrKarigar.Location = New System.Drawing.Point(648, 28)
        Me.txtFrKarigar.Name = "txtFrKarigar"
        Me.txtFrKarigar.ReadOnly = True
        Me.txtFrKarigar.Size = New System.Drawing.Size(128, 20)
        Me.txtFrKarigar.TabIndex = 5
        Me.txtFrKarigar.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(571, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 14)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "Fr Employee" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(566, 55)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 15)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "To Employee"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(295, 29)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Melting %"
        '
        'TransDt
        '
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(89, 56)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(100, 22)
        Me.TransDt.TabIndex = 1
        Me.TransDt.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(289, 57)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 14)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Item Name"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label26.Location = New System.Drawing.Point(41, 32)
        Me.Label26.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 14)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "Lot No"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label28.Location = New System.Drawing.Point(22, 59)
        Me.Label28.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(63, 14)
        Me.Label28.TabIndex = 1
        Me.Label28.Text = "Melting Dt"
        '
        'frmMeltingAlloyReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(814, 541)
        Me.Controls.Add(Me.TbMelting)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMeltingAlloyReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Melting Alloy Report"
        Me.TbMelting.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBoxDetails.ResumeLayout(False)
        Me.GBoxDetails.PerformLayout()
        CType(Me.txtFineAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblFineAdd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStockAdd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxTotal.ResumeLayout(False)
        Me.GBoxTotal.PerformLayout()
        CType(Me.dgvMelting.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMelting, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtToKarigar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConvertToMelting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMelting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFrKarigar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TbMelting As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxDetails As GroupBox
    Friend WithEvents txtFineAdd As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblFineAdd As Telerik.WinControls.UI.RadLabel
    Friend WithEvents Label11 As Label
    Friend WithEvents txtStockAdd As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents GBoxTotal As GroupBox
    Friend WithEvents lblTmpTotal As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblAlloyTotal As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTotalFineWt As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblGrossTotal As Label
    Friend WithEvents dgvMelting As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents cmbLotNo As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtConvertToMelting As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtItem As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtMelting As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtFrKarigar As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents txtToKarigar As Telerik.WinControls.UI.RadTextBox
End Class
