<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpLotTransfer
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
        Dim GridViewTextBoxColumn45 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn46 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn47 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn48 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn49 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn50 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn51 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn52 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn53 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn54 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn55 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition5 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabOpStock = New System.Windows.Forms.TabControl()
        Me.TabStock = New System.Windows.Forms.TabPage()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMainLotNo = New Telerik.WinControls.UI.RadTextBox()
        Me.txtToLotNo = New Telerik.WinControls.UI.RadTextBox()
        Me.txtFrLotNo = New Telerik.WinControls.UI.RadTextBox()
        Me.txtTransferPr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtTransferWt = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbOperation = New Telerik.WinControls.UI.RadDropDownList()
        Me.TransDt = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.cmbItem = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtSrNo = New Telerik.WinControls.UI.RadTextBox()
        Me.dgvLotTransfer = New Telerik.WinControls.UI.RadGridView()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.TabOpStock.SuspendLayout()
        Me.TabStock.SuspendLayout()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtMainLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtToLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFrLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTransferPr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTransferWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbOperation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransDt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotTransfer, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotTransfer.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabOpStock
        '
        Me.TabOpStock.Controls.Add(Me.TabStock)
        Me.TabOpStock.Location = New System.Drawing.Point(-2, 2)
        Me.TabOpStock.Name = "TabOpStock"
        Me.TabOpStock.SelectedIndex = 0
        Me.TabOpStock.Size = New System.Drawing.Size(758, 462)
        Me.TabOpStock.TabIndex = 3
        '
        'TabStock
        '
        Me.TabStock.Controls.Add(Me.GBoxMain)
        Me.TabStock.Location = New System.Drawing.Point(4, 22)
        Me.TabStock.Name = "TabStock"
        Me.TabStock.Padding = New System.Windows.Forms.Padding(3)
        Me.TabStock.Size = New System.Drawing.Size(750, 436)
        Me.TabStock.TabIndex = 0
        Me.TabStock.Text = "Lot Transfer"
        Me.TabStock.UseVisualStyleBackColor = True
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.Label3)
        Me.GBoxMain.Controls.Add(Me.txtMainLotNo)
        Me.GBoxMain.Controls.Add(Me.txtToLotNo)
        Me.GBoxMain.Controls.Add(Me.txtFrLotNo)
        Me.GBoxMain.Controls.Add(Me.txtTransferPr)
        Me.GBoxMain.Controls.Add(Me.txtTransferWt)
        Me.GBoxMain.Controls.Add(Me.cmbOperation)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Controls.Add(Me.cmbItem)
        Me.GBoxMain.Controls.Add(Me.txtSrNo)
        Me.GBoxMain.Controls.Add(Me.dgvLotTransfer)
        Me.GBoxMain.Controls.Add(Me.btnDelete)
        Me.GBoxMain.Controls.Add(Me.btnCancel)
        Me.GBoxMain.Controls.Add(Me.btnSave)
        Me.GBoxMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GBoxMain.Location = New System.Drawing.Point(4, 3)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(4)
        Me.GBoxMain.Size = New System.Drawing.Size(742, 428)
        Me.GBoxMain.TabIndex = 19
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Lot Transfer Details"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(513, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(222, 16)
        Me.Label3.TabIndex = 153
        Me.Label3.Text = "Press  ( F12 )  to delete selected row"
        '
        'txtMainLotNo
        '
        Me.txtMainLotNo.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtMainLotNo.Location = New System.Drawing.Point(669, 33)
        Me.txtMainLotNo.Name = "txtMainLotNo"
        Me.txtMainLotNo.Size = New System.Drawing.Size(70, 20)
        Me.txtMainLotNo.TabIndex = 8
        Me.txtMainLotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtToLotNo
        '
        Me.txtToLotNo.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtToLotNo.Location = New System.Drawing.Point(601, 33)
        Me.txtToLotNo.Name = "txtToLotNo"
        Me.txtToLotNo.Size = New System.Drawing.Size(67, 20)
        Me.txtToLotNo.TabIndex = 7
        Me.txtToLotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtFrLotNo
        '
        Me.txtFrLotNo.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtFrLotNo.Location = New System.Drawing.Point(532, 33)
        Me.txtFrLotNo.Name = "txtFrLotNo"
        Me.txtFrLotNo.Size = New System.Drawing.Size(68, 20)
        Me.txtFrLotNo.TabIndex = 6
        Me.txtFrLotNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTransferPr
        '
        Me.txtTransferPr.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtTransferPr.Location = New System.Drawing.Point(463, 33)
        Me.txtTransferPr.Name = "txtTransferPr"
        Me.txtTransferPr.Size = New System.Drawing.Size(68, 20)
        Me.txtTransferPr.TabIndex = 5
        Me.txtTransferPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTransferWt
        '
        Me.txtTransferWt.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtTransferWt.Location = New System.Drawing.Point(395, 33)
        Me.txtTransferWt.Name = "txtTransferWt"
        Me.txtTransferWt.Size = New System.Drawing.Size(67, 20)
        Me.txtTransferWt.TabIndex = 4
        Me.txtTransferWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbOperation
        '
        Me.cmbOperation.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbOperation.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbOperation.Location = New System.Drawing.Point(253, 33)
        Me.cmbOperation.Name = "cmbOperation"
        Me.cmbOperation.Size = New System.Drawing.Size(141, 20)
        Me.cmbOperation.TabIndex = 3
        '
        'TransDt
        '
        Me.TransDt.BackColor = System.Drawing.Color.LemonChiffon
        Me.TransDt.Location = New System.Drawing.Point(39, 33)
        Me.TransDt.Mask = "00/00/0000"
        Me.TransDt.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(72, 20)
        Me.TransDt.TabIndex = 1
        Me.TransDt.TabStop = False
        Me.TransDt.Text = "__/__/____"
        '
        'cmbItem
        '
        Me.cmbItem.BackColor = System.Drawing.Color.LemonChiffon
        Me.cmbItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbItem.Location = New System.Drawing.Point(112, 33)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(140, 20)
        Me.cmbItem.TabIndex = 2
        '
        'txtSrNo
        '
        Me.txtSrNo.Location = New System.Drawing.Point(3, 33)
        Me.txtSrNo.Name = "txtSrNo"
        Me.txtSrNo.ReadOnly = True
        Me.txtSrNo.Size = New System.Drawing.Size(35, 20)
        Me.txtSrNo.TabIndex = 0
        '
        'dgvLotTransfer
        '
        Me.dgvLotTransfer.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvLotTransfer.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLotTransfer.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvLotTransfer.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLotTransfer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLotTransfer.Location = New System.Drawing.Point(2, 54)
        '
        '
        '
        Me.dgvLotTransfer.MasterTemplate.AllowAddNewRow = False
        Me.dgvLotTransfer.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn45.EnableExpressionEditor = False
        GridViewTextBoxColumn45.HeaderText = "Sr. "
        GridViewTextBoxColumn45.Name = "colSrNo"
        GridViewTextBoxColumn45.Width = 35
        GridViewTextBoxColumn46.EnableExpressionEditor = False
        GridViewTextBoxColumn46.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn46.Name = "colTransDt"
        GridViewTextBoxColumn46.Width = 75
        GridViewTextBoxColumn47.EnableExpressionEditor = False
        GridViewTextBoxColumn47.HeaderText = "Item Id"
        GridViewTextBoxColumn47.IsVisible = False
        GridViewTextBoxColumn47.Name = "colItemId"
        GridViewTextBoxColumn47.Width = 40
        GridViewTextBoxColumn48.EnableExpressionEditor = False
        GridViewTextBoxColumn48.HeaderText = "Item Name"
        GridViewTextBoxColumn48.Name = "colItemName"
        GridViewTextBoxColumn48.Width = 142
        GridViewTextBoxColumn49.EnableExpressionEditor = False
        GridViewTextBoxColumn49.HeaderText = "Operation Id"
        GridViewTextBoxColumn49.IsVisible = False
        GridViewTextBoxColumn49.Name = "colOperationId"
        GridViewTextBoxColumn49.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn49.Width = 40
        GridViewTextBoxColumn50.EnableExpressionEditor = False
        GridViewTextBoxColumn50.HeaderText = "Operation"
        GridViewTextBoxColumn50.Name = "colOperationName"
        GridViewTextBoxColumn50.Width = 142
        GridViewTextBoxColumn51.EnableExpressionEditor = False
        GridViewTextBoxColumn51.HeaderText = "Transfer Wt."
        GridViewTextBoxColumn51.Name = "colTransferWt"
        GridViewTextBoxColumn51.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn51.Width = 70
        GridViewTextBoxColumn52.EnableExpressionEditor = False
        GridViewTextBoxColumn52.HeaderText = "Transfer %"
        GridViewTextBoxColumn52.Name = "colTransferPr"
        GridViewTextBoxColumn52.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn52.Width = 70
        GridViewTextBoxColumn53.EnableExpressionEditor = False
        GridViewTextBoxColumn53.HeaderText = "Fr Lot No"
        GridViewTextBoxColumn53.Name = "colFrLotNumber"
        GridViewTextBoxColumn53.Width = 70
        GridViewTextBoxColumn54.EnableExpressionEditor = False
        GridViewTextBoxColumn54.HeaderText = "To Lot No"
        GridViewTextBoxColumn54.Name = "colToLotNumber"
        GridViewTextBoxColumn54.Width = 70
        GridViewTextBoxColumn55.EnableExpressionEditor = False
        GridViewTextBoxColumn55.HeaderText = "Main Lot No"
        GridViewTextBoxColumn55.Name = "colMainLotNumber"
        GridViewTextBoxColumn55.Width = 70
        Me.dgvLotTransfer.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn45, GridViewTextBoxColumn46, GridViewTextBoxColumn47, GridViewTextBoxColumn48, GridViewTextBoxColumn49, GridViewTextBoxColumn50, GridViewTextBoxColumn51, GridViewTextBoxColumn52, GridViewTextBoxColumn53, GridViewTextBoxColumn54, GridViewTextBoxColumn55})
        Me.dgvLotTransfer.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvLotTransfer.MasterTemplate.ViewDefinition = TableViewDefinition5
        Me.dgvLotTransfer.Name = "dgvLotTransfer"
        Me.dgvLotTransfer.ReadOnly = True
        Me.dgvLotTransfer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLotTransfer.ShowGroupPanel = False
        Me.dgvLotTransfer.Size = New System.Drawing.Size(738, 340)
        Me.dgvLotTransfer.TabIndex = 8
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(354, 400)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(431, 400)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(277, 400)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        '
        'frmOpLotTransfer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(757, 467)
        Me.Controls.Add(Me.TabOpStock)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOpLotTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lot Transfer"
        Me.TabOpStock.ResumeLayout(False)
        Me.TabStock.ResumeLayout(False)
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtMainLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtToLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFrLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTransferPr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTransferWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbOperation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransDt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotTransfer.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotTransfer, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabOpStock As TabControl
    Friend WithEvents TabStock As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents TransDt As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents cmbItem As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtSrNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents dgvLotTransfer As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents cmbOperation As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtTransferWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtTransferPr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtFrLotNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtToLotNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtMainLotNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label3 As Label
End Class
