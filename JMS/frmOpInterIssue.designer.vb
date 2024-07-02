<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpInterIssue
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
        Dim RadListDataItem5 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem6 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem7 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem8 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbConversion = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtIssueWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtIssuePr = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbItem = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtBagNo = New Telerik.WinControls.UI.RadTextBox()
        Me.cmbItemType = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtFineWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtSrNo = New Telerik.WinControls.UI.RadTextBox()
        Me.dgvIssue = New Telerik.WinControls.UI.RadGridView()
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
        CType(Me.cmbConversion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBagNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbItemType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFineWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabOpStock.Size = New System.Drawing.Size(702, 462)
        Me.TabOpStock.TabIndex = 2
        '
        'TabStock
        '
        Me.TabStock.Controls.Add(Me.GBoxMain)
        Me.TabStock.Location = New System.Drawing.Point(4, 23)
        Me.TabStock.Name = "TabStock"
        Me.TabStock.Padding = New System.Windows.Forms.Padding(3)
        Me.TabStock.Size = New System.Drawing.Size(694, 435)
        Me.TabStock.TabIndex = 0
        Me.TabStock.Text = "Inter Dept. Issue"
        Me.TabStock.UseVisualStyleBackColor = True
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.Label3)
        Me.GBoxMain.Controls.Add(Me.cmbConversion)
        Me.GBoxMain.Controls.Add(Me.txtIssueWt)
        Me.GBoxMain.Controls.Add(Me.txtIssuePr)
        Me.GBoxMain.Controls.Add(Me.cmbItem)
        Me.GBoxMain.Controls.Add(Me.txtBagNo)
        Me.GBoxMain.Controls.Add(Me.cmbItemType)
        Me.GBoxMain.Controls.Add(Me.txtFineWt)
        Me.GBoxMain.Controls.Add(Me.txtSrNo)
        Me.GBoxMain.Controls.Add(Me.dgvIssue)
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
        Me.GBoxMain.Size = New System.Drawing.Size(686, 428)
        Me.GBoxMain.TabIndex = 19
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Issue Details"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(466, 62)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(215, 14)
        Me.Label3.TabIndex = 153
        Me.Label3.Text = "Press  ( F12 )  to delete selected row"
        '
        'cmbConversion
        '
        Me.cmbConversion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbConversion.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbConversion.Location = New System.Drawing.Point(567, 81)
        Me.cmbConversion.Name = "cmbConversion"
        Me.cmbConversion.Size = New System.Drawing.Size(49, 20)
        Me.cmbConversion.TabIndex = 8
        '
        'txtIssueWt
        '
        Me.txtIssueWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIssueWt.Location = New System.Drawing.Point(434, 81)
        Me.txtIssueWt.Name = "txtIssueWt"
        Me.txtIssueWt.Size = New System.Drawing.Size(65, 20)
        Me.txtIssueWt.TabIndex = 6
        Me.txtIssueWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssuePr
        '
        Me.txtIssuePr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIssuePr.Location = New System.Drawing.Point(500, 81)
        Me.txtIssuePr.Name = "txtIssuePr"
        Me.txtIssuePr.Size = New System.Drawing.Size(66, 20)
        Me.txtIssuePr.TabIndex = 7
        Me.txtIssuePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbItem
        '
        Me.cmbItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbItem.Location = New System.Drawing.Point(245, 81)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(188, 20)
        Me.cmbItem.TabIndex = 5
        '
        'txtBagNo
        '
        Me.txtBagNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBagNo.Location = New System.Drawing.Point(138, 81)
        Me.txtBagNo.Name = "txtBagNo"
        Me.txtBagNo.Size = New System.Drawing.Size(106, 20)
        Me.txtBagNo.TabIndex = 4
        '
        'cmbItemType
        '
        Me.cmbItemType.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        RadListDataItem5.Text = "Bags"
        RadListDataItem6.Text = "Voucher"
        RadListDataItem7.Text = "Finished Lots"
        RadListDataItem8.Text = "Lot Add. Stock"
        Me.cmbItemType.Items.Add(RadListDataItem5)
        Me.cmbItemType.Items.Add(RadListDataItem6)
        Me.cmbItemType.Items.Add(RadListDataItem7)
        Me.cmbItemType.Items.Add(RadListDataItem8)
        Me.cmbItemType.Location = New System.Drawing.Point(38, 81)
        Me.cmbItemType.Name = "cmbItemType"
        Me.cmbItemType.Size = New System.Drawing.Size(99, 20)
        Me.cmbItemType.TabIndex = 3
        '
        'txtFineWt
        '
        Me.txtFineWt.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.txtFineWt.Location = New System.Drawing.Point(617, 81)
        Me.txtFineWt.Name = "txtFineWt"
        Me.txtFineWt.ReadOnly = True
        Me.txtFineWt.Size = New System.Drawing.Size(68, 20)
        Me.txtFineWt.TabIndex = 9
        Me.txtFineWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSrNo
        '
        Me.txtSrNo.Location = New System.Drawing.Point(2, 81)
        Me.txtSrNo.Name = "txtSrNo"
        Me.txtSrNo.ReadOnly = True
        Me.txtSrNo.Size = New System.Drawing.Size(35, 20)
        Me.txtSrNo.TabIndex = 2
        Me.txtSrNo.TabStop = False
        '
        'dgvIssue
        '
        Me.dgvIssue.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvIssue.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvIssue.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvIssue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvIssue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvIssue.Location = New System.Drawing.Point(2, 101)
        '
        '
        '
        Me.dgvIssue.MasterTemplate.AllowAddNewRow = False
        Me.dgvIssue.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.HeaderText = "Sr. "
        GridViewTextBoxColumn10.Name = "colSrNo"
        GridViewTextBoxColumn10.Width = 35
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.HeaderText = "Item Type"
        GridViewTextBoxColumn11.Name = "colItemType"
        GridViewTextBoxColumn11.Width = 100
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.HeaderText = "Bag No"
        GridViewTextBoxColumn12.Name = "colBagNo"
        GridViewTextBoxColumn12.Width = 109
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.HeaderText = "Item Id."
        GridViewTextBoxColumn13.IsVisible = False
        GridViewTextBoxColumn13.Name = "colItemId"
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.HeaderText = "Item Name"
        GridViewTextBoxColumn14.Name = "colItemName"
        GridViewTextBoxColumn14.Width = 190
        GridViewTextBoxColumn15.EnableExpressionEditor = False
        GridViewTextBoxColumn15.HeaderText = "Issue Wt."
        GridViewTextBoxColumn15.Name = "colIssueWt"
        GridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn15.Width = 68
        GridViewTextBoxColumn16.EnableExpressionEditor = False
        GridViewTextBoxColumn16.HeaderText = "Issue %"
        GridViewTextBoxColumn16.Name = "colIssuePr"
        GridViewTextBoxColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn16.Width = 68
        GridViewTextBoxColumn17.EnableExpressionEditor = False
        GridViewTextBoxColumn17.HeaderText = "Conv %"
        GridViewTextBoxColumn17.Name = "colConvPr"
        GridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn18.EnableExpressionEditor = False
        GridViewTextBoxColumn18.HeaderText = "Fine Wt."
        GridViewTextBoxColumn18.Name = "colFineWt"
        GridViewTextBoxColumn18.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn18.Width = 68
        Me.dgvIssue.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewTextBoxColumn16, GridViewTextBoxColumn17, GridViewTextBoxColumn18})
        Me.dgvIssue.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvIssue.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvIssue.Name = "dgvIssue"
        Me.dgvIssue.ReadOnly = True
        Me.dgvIssue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvIssue.ShowGroupPanel = False
        Me.dgvIssue.Size = New System.Drawing.Size(683, 291)
        Me.dgvIssue.TabIndex = 146
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(306, 398)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "&Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(383, 398)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(229, 398)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "&Save"
        '
        'lblTransDt
        '
        Me.lblTransDt.AutoSize = True
        Me.lblTransDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblTransDt.Location = New System.Drawing.Point(50, 25)
        Me.lblTransDt.Name = "lblTransDt"
        Me.lblTransDt.Size = New System.Drawing.Size(56, 14)
        Me.lblTransDt.TabIndex = 11
        Me.lblTransDt.Text = "Issue Dt."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label6.Location = New System.Drawing.Point(26, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 14)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Voucher No."
        '
        'txtVocucherNo
        '
        Me.txtVocucherNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtVocucherNo.Location = New System.Drawing.Point(109, 47)
        Me.txtVocucherNo.Name = "txtVocucherNo"
        Me.txtVocucherNo.Size = New System.Drawing.Size(85, 20)
        Me.txtVocucherNo.TabIndex = 1
        '
        'TransDt
        '
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(109, 22)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(85, 22)
        Me.TransDt.TabIndex = 0
        Me.TransDt.TabStop = False
        '
        'frmOpInterIssue
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(699, 466)
        Me.Controls.Add(Me.TabOpStock)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOpInterIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inter Dept. Issue"
        Me.TabOpStock.ResumeLayout(False)
        Me.TabStock.ResumeLayout(False)
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.cmbConversion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssueWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIssuePr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBagNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbItemType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFineWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvIssue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtVocucherNo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabOpStock As TabControl
    Friend WithEvents TabStock As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents txtFineWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSrNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents dgvIssue As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblTransDt As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtVocucherNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents cmbItemType As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtBagNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbItem As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtIssuePr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtIssueWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents cmbConversion As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents Label3 As Label
End Class
