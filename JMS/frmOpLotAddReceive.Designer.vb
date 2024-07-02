<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpLotAddReceive
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
        Dim GridViewTextBoxColumn1 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn2 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn3 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabOpStock = New System.Windows.Forms.TabControl()
        Me.TabStock = New System.Windows.Forms.TabPage()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.txtRemarks = New Telerik.WinControls.UI.RadTextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cmbOperation = New Telerik.WinControls.UI.RadDropDownList()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtLotAddNo = New Telerik.WinControls.UI.RadTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbItem = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtReceiveWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtReceivePr = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbGItem = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtFineWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtSrNo = New Telerik.WinControls.UI.RadTextBox()
        Me.dgvLotReceive = New Telerik.WinControls.UI.RadGridView()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.lblTransDt = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtLotNo = New Telerik.WinControls.UI.RadTextBox()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.TabOpStock.SuspendLayout()
        Me.TabStock.SuspendLayout()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOperation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLotAddNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReceiveWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReceivePr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbGItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFineWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabOpStock
        '
        Me.TabOpStock.Controls.Add(Me.TabStock)
        Me.TabOpStock.Location = New System.Drawing.Point(-2, 2)
        Me.TabOpStock.Name = "TabOpStock"
        Me.TabOpStock.SelectedIndex = 0
        Me.TabOpStock.Size = New System.Drawing.Size(650, 462)
        Me.TabOpStock.TabIndex = 4
        '
        'TabStock
        '
        Me.TabStock.Controls.Add(Me.GBoxMain)
        Me.TabStock.Location = New System.Drawing.Point(4, 22)
        Me.TabStock.Name = "TabStock"
        Me.TabStock.Padding = New System.Windows.Forms.Padding(3)
        Me.TabStock.Size = New System.Drawing.Size(642, 436)
        Me.TabStock.TabIndex = 0
        Me.TabStock.Text = "Lot Add. Receive"
        Me.TabStock.UseVisualStyleBackColor = True
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.txtRemarks)
        Me.GBoxMain.Controls.Add(Me.Label21)
        Me.GBoxMain.Controls.Add(Me.cmbOperation)
        Me.GBoxMain.Controls.Add(Me.Label3)
        Me.GBoxMain.Controls.Add(Me.txtLotAddNo)
        Me.GBoxMain.Controls.Add(Me.Label7)
        Me.GBoxMain.Controls.Add(Me.cmbItem)
        Me.GBoxMain.Controls.Add(Me.txtReceiveWt)
        Me.GBoxMain.Controls.Add(Me.txtReceivePr)
        Me.GBoxMain.Controls.Add(Me.cmbGItem)
        Me.GBoxMain.Controls.Add(Me.txtFineWt)
        Me.GBoxMain.Controls.Add(Me.txtSrNo)
        Me.GBoxMain.Controls.Add(Me.dgvLotReceive)
        Me.GBoxMain.Controls.Add(Me.btnDelete)
        Me.GBoxMain.Controls.Add(Me.btnCancel)
        Me.GBoxMain.Controls.Add(Me.btnSave)
        Me.GBoxMain.Controls.Add(Me.lblTransDt)
        Me.GBoxMain.Controls.Add(Me.Label6)
        Me.GBoxMain.Controls.Add(Me.txtLotNo)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxMain.Location = New System.Drawing.Point(4, 3)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(4)
        Me.GBoxMain.Size = New System.Drawing.Size(637, 428)
        Me.GBoxMain.TabIndex = 19
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Receive Details"
        '
        'txtRemarks
        '
        Me.txtRemarks.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtRemarks.Location = New System.Drawing.Point(401, 81)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(231, 20)
        Me.txtRemarks.TabIndex = 10
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(433, 27)
        Me.Label21.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(61, 14)
        Me.Label21.TabIndex = 814
        Me.Label21.Text = "Opreation"
        '
        'cmbOperation
        '
        Me.cmbOperation.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbOperation.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbOperation.Location = New System.Drawing.Point(497, 24)
        Me.cmbOperation.Name = "cmbOperation"
        Me.cmbOperation.Size = New System.Drawing.Size(135, 20)
        Me.cmbOperation.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(216, 50)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 14)
        Me.Label3.TabIndex = 812
        Me.Label3.Text = "Lot Add No."
        '
        'txtLotAddNo
        '
        Me.txtLotAddNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLotAddNo.Location = New System.Drawing.Point(293, 47)
        Me.txtLotAddNo.Name = "txtLotAddNo"
        Me.txtLotAddNo.Size = New System.Drawing.Size(116, 20)
        Me.txtLotAddNo.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(222, 25)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 14)
        Me.Label7.TabIndex = 148
        Me.Label7.Text = "Item Name"
        '
        'cmbItem
        '
        Me.cmbItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbItem.Location = New System.Drawing.Point(293, 22)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(116, 20)
        Me.cmbItem.TabIndex = 2
        '
        'txtReceiveWt
        '
        Me.txtReceiveWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtReceiveWt.Location = New System.Drawing.Point(181, 81)
        Me.txtReceiveWt.Name = "txtReceiveWt"
        Me.txtReceiveWt.Size = New System.Drawing.Size(74, 20)
        Me.txtReceiveWt.TabIndex = 7
        Me.txtReceiveWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtReceivePr
        '
        Me.txtReceivePr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtReceivePr.Location = New System.Drawing.Point(255, 81)
        Me.txtReceivePr.Name = "txtReceivePr"
        Me.txtReceivePr.Size = New System.Drawing.Size(72, 20)
        Me.txtReceivePr.TabIndex = 8
        Me.txtReceivePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbGItem
        '
        Me.cmbGItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbGItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbGItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbGItem.Location = New System.Drawing.Point(38, 81)
        Me.cmbGItem.Name = "cmbGItem"
        Me.cmbGItem.Size = New System.Drawing.Size(142, 20)
        Me.cmbGItem.TabIndex = 6
        '
        'txtFineWt
        '
        Me.txtFineWt.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtFineWt.Location = New System.Drawing.Point(328, 81)
        Me.txtFineWt.Name = "txtFineWt"
        Me.txtFineWt.Size = New System.Drawing.Size(72, 20)
        Me.txtFineWt.TabIndex = 9
        Me.txtFineWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSrNo
        '
        Me.txtSrNo.Location = New System.Drawing.Point(2, 81)
        Me.txtSrNo.Name = "txtSrNo"
        Me.txtSrNo.ReadOnly = True
        Me.txtSrNo.Size = New System.Drawing.Size(35, 20)
        Me.txtSrNo.TabIndex = 5
        Me.txtSrNo.TabStop = False
        '
        'dgvLotReceive
        '
        Me.dgvLotReceive.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvLotReceive.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLotReceive.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvLotReceive.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLotReceive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLotReceive.Location = New System.Drawing.Point(2, 101)
        '
        '
        '
        Me.dgvLotReceive.MasterTemplate.AllowAddNewRow = False
        Me.dgvLotReceive.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.HeaderText = "Sr. "
        GridViewTextBoxColumn1.Name = "colSrNo"
        GridViewTextBoxColumn1.Width = 34
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.HeaderText = "Item Id."
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.Name = "colItemId"
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.HeaderText = "Item Name"
        GridViewTextBoxColumn3.Name = "colItemName"
        GridViewTextBoxColumn3.Width = 143
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.HeaderText = "Receive Wt."
        GridViewTextBoxColumn4.Name = "colReceiveWt"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 75
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.HeaderText = "Receive %"
        GridViewTextBoxColumn5.Name = "colReceivePr"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 75
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.HeaderText = "Fine Wt."
        GridViewTextBoxColumn6.Name = "colFineWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 75
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.HeaderText = "Remarks"
        GridViewTextBoxColumn7.Name = "colRemarks"
        GridViewTextBoxColumn7.Width = 230
        Me.dgvLotReceive.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7})
        Me.dgvLotReceive.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvLotReceive.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvLotReceive.Name = "dgvLotReceive"
        Me.dgvLotReceive.ReadOnly = True
        Me.dgvLotReceive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLotReceive.ShowGroupPanel = False
        Me.dgvLotReceive.Size = New System.Drawing.Size(631, 292)
        Me.dgvLotReceive.TabIndex = 146
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(295, 398)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "&Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(372, 398)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(218, 398)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "&Save"
        '
        'lblTransDt
        '
        Me.lblTransDt.AutoSize = True
        Me.lblTransDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblTransDt.Location = New System.Drawing.Point(22, 25)
        Me.lblTransDt.Name = "lblTransDt"
        Me.lblTransDt.Size = New System.Drawing.Size(70, 14)
        Me.lblTransDt.TabIndex = 11
        Me.lblTransDt.Text = "Receive Dt."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(43, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Lot No."
        '
        'txtLotNo
        '
        Me.txtLotNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLotNo.Location = New System.Drawing.Point(95, 47)
        Me.txtLotNo.Name = "txtLotNo"
        Me.txtLotNo.Size = New System.Drawing.Size(85, 20)
        Me.txtLotNo.TabIndex = 1
        '
        'TransDt
        '
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(95, 22)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(85, 22)
        Me.TransDt.TabIndex = 0
        Me.TransDt.TabStop = False
        '
        'frmOpLotAddReceive
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(648, 466)
        Me.Controls.Add(Me.TabOpStock)
        Me.MaximizeBox = False
        Me.Name = "frmOpLotAddReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Op Lot Stock Receive"
        Me.TabOpStock.ResumeLayout(False)
        Me.TabStock.ResumeLayout(False)
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOperation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLotAddNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReceiveWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReceivePr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbGItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFineWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabOpStock As TabControl
    Friend WithEvents TabStock As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents Label21 As Label
    Friend WithEvents cmbOperation As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents Label3 As Label
    Friend WithEvents txtLotAddNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbItem As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtReceiveWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtReceivePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbGItem As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtFineWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSrNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblTransDt As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtLotNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents dgvLotReceive As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtRemarks As Telerik.WinControls.UI.RadTextBox
End Class
