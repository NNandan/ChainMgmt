<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOpStockBags
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
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn17 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn18 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabOpStock = New System.Windows.Forms.TabControl()
        Me.TabStock = New System.Windows.Forms.TabPage()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBagNo = New Telerik.WinControls.UI.RadTextBox()
        Me.TransDt = New Telerik.WinControls.UI.RadMaskedEditBox()
        Me.txtReceiveWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssuePr = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssueWt = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbItem = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtSrNo = New Telerik.WinControls.UI.RadTextBox()
        Me.dgvUsedBags = New Telerik.WinControls.UI.RadGridView()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.TabOpStock.SuspendLayout()
        Me.TabStock.SuspendLayout()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtBagNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransDt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReceiveWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUsedBags, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUsedBags.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabOpStock
        '
        Me.TabOpStock.Controls.Add(Me.TabStock)
        Me.TabOpStock.Location = New System.Drawing.Point(-1, 2)
        Me.TabOpStock.Name = "TabOpStock"
        Me.TabOpStock.SelectedIndex = 0
        Me.TabOpStock.Size = New System.Drawing.Size(605, 462)
        Me.TabOpStock.TabIndex = 2
        '
        'TabStock
        '
        Me.TabStock.Controls.Add(Me.GBoxMain)
        Me.TabStock.Location = New System.Drawing.Point(4, 22)
        Me.TabStock.Name = "TabStock"
        Me.TabStock.Padding = New System.Windows.Forms.Padding(3)
        Me.TabStock.Size = New System.Drawing.Size(597, 436)
        Me.TabStock.TabIndex = 0
        Me.TabStock.Text = "Used Bags"
        Me.TabStock.UseVisualStyleBackColor = True
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.txtBagNo)
        Me.GBoxMain.Controls.Add(Me.TransDt)
        Me.GBoxMain.Controls.Add(Me.txtReceiveWt)
        Me.GBoxMain.Controls.Add(Me.txtIssuePr)
        Me.GBoxMain.Controls.Add(Me.txtIssueWt)
        Me.GBoxMain.Controls.Add(Me.cmbItem)
        Me.GBoxMain.Controls.Add(Me.txtSrNo)
        Me.GBoxMain.Controls.Add(Me.dgvUsedBags)
        Me.GBoxMain.Controls.Add(Me.btnDelete)
        Me.GBoxMain.Controls.Add(Me.btnCancel)
        Me.GBoxMain.Controls.Add(Me.btnSave)
        Me.GBoxMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.GBoxMain.Location = New System.Drawing.Point(4, 3)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(4)
        Me.GBoxMain.Size = New System.Drawing.Size(589, 428)
        Me.GBoxMain.TabIndex = 19
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Bags Not Created Details"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(358, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 16)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "Press  ( F12 )  to delete selected row"
        '
        'txtBagNo
        '
        Me.txtBagNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBagNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtBagNo.Location = New System.Drawing.Point(112, 33)
        Me.txtBagNo.Name = "txtBagNo"
        Me.txtBagNo.Size = New System.Drawing.Size(75, 20)
        Me.txtBagNo.TabIndex = 2
        '
        'TransDt
        '
        Me.TransDt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TransDt.Location = New System.Drawing.Point(39, 33)
        Me.TransDt.Mask = "00/00/0000"
        Me.TransDt.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(72, 20)
        Me.TransDt.TabIndex = 1
        Me.TransDt.TabStop = False
        Me.TransDt.Text = "__/__/____"
        '
        'txtReceiveWt
        '
        Me.txtReceiveWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtReceiveWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveWt.Location = New System.Drawing.Point(509, 33)
        Me.txtReceiveWt.Name = "txtReceiveWt"
        Me.txtReceiveWt.Size = New System.Drawing.Size(79, 20)
        Me.txtReceiveWt.TabIndex = 6
        Me.txtReceiveWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssuePr
        '
        Me.txtIssuePr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIssuePr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssuePr.Location = New System.Drawing.Point(431, 33)
        Me.txtIssuePr.Name = "txtIssuePr"
        Me.txtIssuePr.Size = New System.Drawing.Size(77, 20)
        Me.txtIssuePr.TabIndex = 5
        Me.txtIssuePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssueWt
        '
        Me.txtIssueWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIssueWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssueWt.Location = New System.Drawing.Point(352, 33)
        Me.txtIssueWt.Name = "txtIssueWt"
        Me.txtIssueWt.Size = New System.Drawing.Size(78, 20)
        Me.txtIssueWt.TabIndex = 4
        Me.txtIssueWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbItem
        '
        Me.cmbItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbItem.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbItem.Location = New System.Drawing.Point(188, 33)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(163, 20)
        Me.cmbItem.TabIndex = 3
        '
        'txtSrNo
        '
        Me.txtSrNo.Location = New System.Drawing.Point(3, 33)
        Me.txtSrNo.Name = "txtSrNo"
        Me.txtSrNo.ReadOnly = True
        Me.txtSrNo.Size = New System.Drawing.Size(35, 20)
        Me.txtSrNo.TabIndex = 0
        Me.txtSrNo.TabStop = False
        '
        'dgvUsedBags
        '
        Me.dgvUsedBags.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvUsedBags.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvUsedBags.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvUsedBags.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvUsedBags.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvUsedBags.Location = New System.Drawing.Point(2, 54)
        '
        '
        '
        Me.dgvUsedBags.MasterTemplate.AllowAddNewRow = False
        Me.dgvUsedBags.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.HeaderText = "Sr. "
        GridViewTextBoxColumn10.Name = "colSrNo"
        GridViewTextBoxColumn10.Width = 35
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn11.Name = "colTransDt"
        GridViewTextBoxColumn11.Width = 75
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.HeaderText = "Bag No."
        GridViewTextBoxColumn12.Name = "colBagNo"
        GridViewTextBoxColumn12.Width = 76
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.HeaderText = "Item Id"
        GridViewTextBoxColumn13.IsVisible = False
        GridViewTextBoxColumn13.Name = "colItemId"
        GridViewTextBoxColumn13.Width = 40
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.HeaderText = "Item Name"
        GridViewTextBoxColumn14.Name = "colItemName"
        GridViewTextBoxColumn14.Width = 165
        GridViewTextBoxColumn15.EnableExpressionEditor = False
        GridViewTextBoxColumn15.HeaderText = "Issue Wt."
        GridViewTextBoxColumn15.Name = "colIssueWt"
        GridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn15.Width = 80
        GridViewTextBoxColumn16.EnableExpressionEditor = False
        GridViewTextBoxColumn16.HeaderText = "Issue %"
        GridViewTextBoxColumn16.Name = "colIssuePr"
        GridViewTextBoxColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn16.Width = 80
        GridViewTextBoxColumn17.EnableExpressionEditor = False
        GridViewTextBoxColumn17.HeaderText = "Receive Wt."
        GridViewTextBoxColumn17.Name = "colReceiveWt"
        GridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn17.Width = 79
        GridViewTextBoxColumn18.EnableExpressionEditor = False
        GridViewTextBoxColumn18.HeaderText = "Report %"
        GridViewTextBoxColumn18.IsVisible = False
        GridViewTextBoxColumn18.Name = "colReportPr"
        GridViewTextBoxColumn18.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn18.Width = 80
        Me.dgvUsedBags.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewTextBoxColumn16, GridViewTextBoxColumn17, GridViewTextBoxColumn18})
        Me.dgvUsedBags.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvUsedBags.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvUsedBags.Name = "dgvUsedBags"
        Me.dgvUsedBags.ReadOnly = True
        Me.dgvUsedBags.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvUsedBags.ShowGroupPanel = False
        Me.dgvUsedBags.Size = New System.Drawing.Size(586, 338)
        Me.dgvUsedBags.TabIndex = 8
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(282, 398)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "&Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(359, 398)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 9
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(205, 398)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "&Save"
        '
        'frmOpStockBags
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(606, 467)
        Me.Controls.Add(Me.TabOpStock)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOpStockBags"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Used Bags"
        Me.TabOpStock.ResumeLayout(False)
        Me.TabStock.ResumeLayout(False)
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtBagNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransDt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReceiveWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUsedBags.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUsedBags, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabOpStock As TabControl
    Friend WithEvents TabStock As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents txtBagNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TransDt As Telerik.WinControls.UI.RadMaskedEditBox
    Friend WithEvents txtReceiveWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssuePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssueWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbItem As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtSrNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents dgvUsedBags As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label1 As Label
End Class
