<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpInterReceipt
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpInterReceipt))
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabOpStock = New System.Windows.Forms.TabControl()
        Me.TabStock = New System.Windows.Forms.TabPage()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFineWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtReceivePr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtReceiveWt = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbItem = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtSrNo = New Telerik.WinControls.UI.RadTextBox()
        Me.Btn_Find = New System.Windows.Forms.Button()
        Me.dgvStockReceipt = New Telerik.WinControls.UI.RadGridView()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.lblTransDt = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVocucherNo = New Telerik.WinControls.UI.RadTextBox()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.TabOpStock.SuspendLayout()
        Me.TabStock.SuspendLayout()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtFineWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReceivePr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReceiveWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStockReceipt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStockReceipt.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtVocucherNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabOpStock
        '
        Me.TabOpStock.Controls.Add(Me.TabStock)
        Me.TabOpStock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TabOpStock.Location = New System.Drawing.Point(-1, 2)
        Me.TabOpStock.Name = "TabOpStock"
        Me.TabOpStock.SelectedIndex = 0
        Me.TabOpStock.Size = New System.Drawing.Size(707, 462)
        Me.TabOpStock.TabIndex = 1
        '
        'TabStock
        '
        Me.TabStock.Controls.Add(Me.GBoxMain)
        Me.TabStock.Location = New System.Drawing.Point(4, 23)
        Me.TabStock.Name = "TabStock"
        Me.TabStock.Padding = New System.Windows.Forms.Padding(3)
        Me.TabStock.Size = New System.Drawing.Size(699, 435)
        Me.TabStock.TabIndex = 0
        Me.TabStock.Text = "Stock Receipt"
        Me.TabStock.UseVisualStyleBackColor = True
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.txtFineWt)
        Me.GBoxMain.Controls.Add(Me.txtReceivePr)
        Me.GBoxMain.Controls.Add(Me.txtReceiveWt)
        Me.GBoxMain.Controls.Add(Me.cmbItem)
        Me.GBoxMain.Controls.Add(Me.txtSrNo)
        Me.GBoxMain.Controls.Add(Me.Btn_Find)
        Me.GBoxMain.Controls.Add(Me.dgvStockReceipt)
        Me.GBoxMain.Controls.Add(Me.btnDelete)
        Me.GBoxMain.Controls.Add(Me.btnCancel)
        Me.GBoxMain.Controls.Add(Me.btnSave)
        Me.GBoxMain.Controls.Add(Me.lblTransDt)
        Me.GBoxMain.Controls.Add(Me.Label6)
        Me.GBoxMain.Controls.Add(Me.txtVocucherNo)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(4, 3)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(4)
        Me.GBoxMain.Size = New System.Drawing.Size(691, 428)
        Me.GBoxMain.TabIndex = 19
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Receipt Details"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(466, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 14)
        Me.Label1.TabIndex = 157
        Me.Label1.Text = "Press  ( F12 )  to delete selected row"
        '
        'txtFineWt
        '
        Me.txtFineWt.BackColor = System.Drawing.Color.White
        Me.txtFineWt.Location = New System.Drawing.Point(600, 80)
        Me.txtFineWt.Name = "txtFineWt"
        Me.txtFineWt.ReadOnly = True
        Me.txtFineWt.Size = New System.Drawing.Size(84, 20)
        Me.txtFineWt.TabIndex = 6
        Me.txtFineWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceivePr
        '
        Me.txtReceivePr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtReceivePr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceivePr.Location = New System.Drawing.Point(517, 80)
        Me.txtReceivePr.Name = "txtReceivePr"
        Me.txtReceivePr.Size = New System.Drawing.Size(82, 20)
        Me.txtReceivePr.TabIndex = 5
        Me.txtReceivePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceiveWt
        '
        Me.txtReceiveWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtReceiveWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveWt.Location = New System.Drawing.Point(433, 80)
        Me.txtReceiveWt.Name = "txtReceiveWt"
        Me.txtReceiveWt.Size = New System.Drawing.Size(83, 20)
        Me.txtReceiveWt.TabIndex = 4
        Me.txtReceiveWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbItem
        '
        Me.cmbItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbItem.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbItem.Location = New System.Drawing.Point(48, 80)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(384, 20)
        Me.cmbItem.TabIndex = 3
        '
        'txtSrNo
        '
        Me.txtSrNo.Location = New System.Drawing.Point(2, 80)
        Me.txtSrNo.Name = "txtSrNo"
        Me.txtSrNo.ReadOnly = True
        Me.txtSrNo.Size = New System.Drawing.Size(45, 20)
        Me.txtSrNo.TabIndex = 2
        Me.txtSrNo.TabStop = False
        '
        'Btn_Find
        '
        Me.Btn_Find.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Btn_Find.BackgroundImage = CType(resources.GetObject("Btn_Find.BackgroundImage"), System.Drawing.Image)
        Me.Btn_Find.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Btn_Find.ForeColor = System.Drawing.Color.White
        Me.Btn_Find.Location = New System.Drawing.Point(195, 47)
        Me.Btn_Find.Name = "Btn_Find"
        Me.Btn_Find.Size = New System.Drawing.Size(36, 20)
        Me.Btn_Find.TabIndex = 147
        Me.Btn_Find.TabStop = False
        Me.Btn_Find.Text = "F2"
        Me.Btn_Find.UseVisualStyleBackColor = False
        '
        'dgvStockReceipt
        '
        Me.dgvStockReceipt.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvStockReceipt.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvStockReceipt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvStockReceipt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvStockReceipt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvStockReceipt.Location = New System.Drawing.Point(2, 101)
        '
        '
        '
        Me.dgvStockReceipt.MasterTemplate.AllowAddNewRow = False
        Me.dgvStockReceipt.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.HeaderText = "Sr. "
        GridViewTextBoxColumn1.Name = "colSrNo"
        GridViewTextBoxColumn1.Width = 45
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.HeaderText = "Item Id"
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.Name = "colItemId"
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.HeaderText = "Item Name"
        GridViewTextBoxColumn3.Name = "colItemName"
        GridViewTextBoxColumn3.Width = 385
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.HeaderText = "Receive Wt."
        GridViewTextBoxColumn4.Name = "colReceiveWt"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 85
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.HeaderText = "Receive %"
        GridViewTextBoxColumn5.Name = "colReceivePr"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 85
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.HeaderText = "Fine Wt."
        GridViewTextBoxColumn6.Name = "colFineWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 85
        Me.dgvStockReceipt.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.dgvStockReceipt.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvStockReceipt.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvStockReceipt.Name = "dgvStockReceipt"
        Me.dgvStockReceipt.ReadOnly = True
        Me.dgvStockReceipt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvStockReceipt.ShowGroupPanel = False
        Me.dgvStockReceipt.Size = New System.Drawing.Size(684, 294)
        Me.dgvStockReceipt.TabIndex = 146
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(319, 400)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "&Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(396, 400)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(242, 400)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "&Save"
        '
        'lblTransDt
        '
        Me.lblTransDt.AutoSize = True
        Me.lblTransDt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransDt.Location = New System.Drawing.Point(49, 25)
        Me.lblTransDt.Name = "lblTransDt"
        Me.lblTransDt.Size = New System.Drawing.Size(56, 14)
        Me.lblTransDt.TabIndex = 11
        Me.lblTransDt.Text = "Issue Dt."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(30, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Voucher No."
        '
        'txtVocucherNo
        '
        Me.txtVocucherNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtVocucherNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtVocucherNo.Location = New System.Drawing.Point(109, 47)
        Me.txtVocucherNo.Name = "txtVocucherNo"
        Me.txtVocucherNo.Size = New System.Drawing.Size(85, 20)
        Me.txtVocucherNo.TabIndex = 1
        '
        'TransDt
        '
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(109, 22)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(85, 22)
        Me.TransDt.TabIndex = 0
        Me.TransDt.TabStop = False
        '
        'frmOpInterReceipt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(704, 467)
        Me.Controls.Add(Me.TabOpStock)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOpInterReceipt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inter Dept. Receipt"
        Me.TabOpStock.ResumeLayout(False)
        Me.TabStock.ResumeLayout(False)
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtFineWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReceivePr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReceiveWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStockReceipt.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStockReceipt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVocucherNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabOpStock As TabControl
    Friend WithEvents TabStock As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents Btn_Find As Button
    Friend WithEvents dgvStockReceipt As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblTransDt As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtVocucherNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents txtSrNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbItem As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtReceiveWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtReceivePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtFineWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As Label
End Class
