<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpStockBagsNotUpdated
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
        Dim GridViewTextBoxColumn31 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn32 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn33 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn34 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn35 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn36 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn37 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn38 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn39 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn40 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition4 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.txtBagNo = New Telerik.WinControls.UI.RadTextBox()
        Me.RadDropDownList1 = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtReportPr = New Telerik.WinControls.UI.RadTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtBagNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadDropDownList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtReportPr, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(829, 467)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(821, 441)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.txtBagNo)
        Me.GBoxMain.Controls.Add(Me.RadDropDownList1)
        Me.GBoxMain.Controls.Add(Me.txtReportPr)
        Me.GBoxMain.Controls.Add(Me.Label1)
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
        Me.GBoxMain.Location = New System.Drawing.Point(5, 6)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(4)
        Me.GBoxMain.Size = New System.Drawing.Size(813, 430)
        Me.GBoxMain.TabIndex = 20
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Bags Not Created Details"
        '
        'txtBagNo
        '
        Me.txtBagNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBagNo.Location = New System.Drawing.Point(368, 33)
        Me.txtBagNo.Name = "txtBagNo"
        Me.txtBagNo.Size = New System.Drawing.Size(84, 20)
        Me.txtBagNo.TabIndex = 153
        '
        'RadDropDownList1
        '
        Me.RadDropDownList1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RadDropDownList1.Location = New System.Drawing.Point(117, 33)
        Me.RadDropDownList1.Name = "RadDropDownList1"
        Me.RadDropDownList1.Size = New System.Drawing.Size(96, 20)
        Me.RadDropDownList1.TabIndex = 152
        '
        'txtReportPr
        '
        Me.txtReportPr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtReportPr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReportPr.Location = New System.Drawing.Point(722, 33)
        Me.txtReportPr.Name = "txtReportPr"
        Me.txtReportPr.Size = New System.Drawing.Size(90, 20)
        Me.txtReportPr.TabIndex = 6
        Me.txtReportPr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(586, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(222, 16)
        Me.Label1.TabIndex = 151
        Me.Label1.Text = "Press  ( F12 )  to delete selected row"
        '
        'TransDt
        '
        Me.TransDt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TransDt.Location = New System.Drawing.Point(39, 33)
        Me.TransDt.Mask = "00/00/0000"
        Me.TransDt.MaskType = Telerik.WinControls.UI.MaskType.Standard
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(76, 20)
        Me.TransDt.TabIndex = 0
        Me.TransDt.TabStop = False
        Me.TransDt.Text = "__/__/____"
        '
        'txtReceiveWt
        '
        Me.txtReceiveWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtReceiveWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtReceiveWt.Location = New System.Drawing.Point(633, 33)
        Me.txtReceiveWt.Name = "txtReceiveWt"
        Me.txtReceiveWt.Size = New System.Drawing.Size(88, 20)
        Me.txtReceiveWt.TabIndex = 5
        Me.txtReceiveWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssuePr
        '
        Me.txtIssuePr.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIssuePr.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssuePr.Location = New System.Drawing.Point(544, 33)
        Me.txtIssuePr.Name = "txtIssuePr"
        Me.txtIssuePr.Size = New System.Drawing.Size(87, 20)
        Me.txtIssuePr.TabIndex = 4
        Me.txtIssuePr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtIssueWt
        '
        Me.txtIssueWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtIssueWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtIssueWt.Location = New System.Drawing.Point(453, 33)
        Me.txtIssueWt.Name = "txtIssueWt"
        Me.txtIssueWt.Size = New System.Drawing.Size(90, 20)
        Me.txtIssueWt.TabIndex = 3
        Me.txtIssueWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbItem
        '
        Me.cmbItem.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbItem.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbItem.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbItem.Location = New System.Drawing.Point(214, 33)
        Me.cmbItem.Name = "cmbItem"
        Me.cmbItem.Size = New System.Drawing.Size(153, 20)
        Me.cmbItem.TabIndex = 2
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
        Me.dgvUsedBags.Location = New System.Drawing.Point(3, 54)
        '
        '
        '
        Me.dgvUsedBags.MasterTemplate.AllowAddNewRow = False
        Me.dgvUsedBags.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn31.EnableExpressionEditor = False
        GridViewTextBoxColumn31.HeaderText = "Sr. "
        GridViewTextBoxColumn31.Name = "colSrNo"
        GridViewTextBoxColumn31.Width = 35
        GridViewTextBoxColumn32.EnableExpressionEditor = False
        GridViewTextBoxColumn32.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn32.Name = "colTransDt"
        GridViewTextBoxColumn32.Width = 80
        GridViewTextBoxColumn33.EnableExpressionEditor = False
        GridViewTextBoxColumn33.FieldName = "BagType"
        GridViewTextBoxColumn33.HeaderText = "Bag Type"
        GridViewTextBoxColumn33.Name = "colBagType"
        GridViewTextBoxColumn33.Width = 100
        GridViewTextBoxColumn34.EnableExpressionEditor = False
        GridViewTextBoxColumn34.HeaderText = "Item Id"
        GridViewTextBoxColumn34.IsVisible = False
        GridViewTextBoxColumn34.Name = "colItemId"
        GridViewTextBoxColumn34.Width = 40
        GridViewTextBoxColumn35.EnableExpressionEditor = False
        GridViewTextBoxColumn35.HeaderText = "Item Name"
        GridViewTextBoxColumn35.Name = "colItemName"
        GridViewTextBoxColumn35.Width = 150
        GridViewTextBoxColumn36.EnableExpressionEditor = False
        GridViewTextBoxColumn36.FieldName = "ItemCode"
        GridViewTextBoxColumn36.HeaderText = "ItemCode"
        GridViewTextBoxColumn36.Name = "colItemCode"
        GridViewTextBoxColumn36.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn36.Width = 90
        GridViewTextBoxColumn37.EnableExpressionEditor = False
        GridViewTextBoxColumn37.FieldName = "BagNo"
        GridViewTextBoxColumn37.HeaderText = "Bag No"
        GridViewTextBoxColumn37.Name = "colBagNo"
        GridViewTextBoxColumn37.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn37.Width = 90
        GridViewTextBoxColumn38.EnableExpressionEditor = False
        GridViewTextBoxColumn38.FieldName = "IssueWt"
        GridViewTextBoxColumn38.HeaderText = "IssueWt"
        GridViewTextBoxColumn38.Name = "colIssueWt"
        GridViewTextBoxColumn38.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn38.Width = 90
        GridViewTextBoxColumn39.EnableExpressionEditor = False
        GridViewTextBoxColumn39.FieldName = "IssuePr"
        GridViewTextBoxColumn39.HeaderText = "Issue %"
        GridViewTextBoxColumn39.Name = "colIssuePr"
        GridViewTextBoxColumn39.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn39.Width = 90
        GridViewTextBoxColumn40.EnableExpressionEditor = False
        GridViewTextBoxColumn40.FieldName = "FineWt"
        GridViewTextBoxColumn40.HeaderText = "Fine Wt"
        GridViewTextBoxColumn40.Name = "colFineWt"
        GridViewTextBoxColumn40.Width = 90
        Me.dgvUsedBags.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn31, GridViewTextBoxColumn32, GridViewTextBoxColumn33, GridViewTextBoxColumn34, GridViewTextBoxColumn35, GridViewTextBoxColumn36, GridViewTextBoxColumn37, GridViewTextBoxColumn38, GridViewTextBoxColumn39, GridViewTextBoxColumn40})
        Me.dgvUsedBags.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvUsedBags.MasterTemplate.ViewDefinition = TableViewDefinition4
        Me.dgvUsedBags.Name = "dgvUsedBags"
        Me.dgvUsedBags.ReadOnly = True
        Me.dgvUsedBags.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvUsedBags.ShowGroupPanel = False
        Me.dgvUsedBags.Size = New System.Drawing.Size(810, 340)
        Me.dgvUsedBags.TabIndex = 8
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(382, 400)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "&Delete"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(459, 400)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(305, 400)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "&Save"
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(880, 441)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'frmOpStockBagsNotUpdated
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(830, 465)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "frmOpStockBagsNotUpdated"
        Me.Text = "frmOpStockBagsNotUpdated"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtBagNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadDropDownList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtReportPr, System.ComponentModel.ISupportInitialize).EndInit()
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

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents txtBagNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents RadDropDownList1 As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtReportPr As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents Label1 As Label
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
End Class
