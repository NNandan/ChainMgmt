<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMaterialMaster
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim RadListDataItem1 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem2 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.dgvMaterialList = New Telerik.WinControls.UI.RadGridView()
        Me.lblRowCount = New System.Windows.Forms.Label()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblIO = New System.Windows.Forms.Label()
        Me.cmbType = New Telerik.WinControls.UI.RadDropDownList()
        Me.lblMaterialType = New System.Windows.Forms.Label()
        Me.txtMaterialName = New Telerik.WinControls.UI.RadTextBox()
        Me.lblCategoryName = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMaterialList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMaterialList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.cmbType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMaterialName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(713, 502)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage1.Size = New System.Drawing.Size(705, 475)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.dgvMaterialList)
        Me.GroupBox1.Controls.Add(Me.lblRowCount)
        Me.GroupBox1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 137)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(690, 330)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Material Details"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(435, 297)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "E&xit"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(358, 297)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(204, 297)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(281, 297)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "&Delete"
        '
        'dgvMaterialList
        '
        Me.dgvMaterialList.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvMaterialList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvMaterialList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvMaterialList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMaterialList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvMaterialList.Location = New System.Drawing.Point(4, 26)
        '
        '
        '
        Me.dgvMaterialList.MasterTemplate.AllowAddNewRow = False
        Me.dgvMaterialList.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "MaterialId"
        GridViewTextBoxColumn1.HeaderText = "Material Id"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "ColMaterialId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "MaterialName"
        GridViewTextBoxColumn2.HeaderText = "Material Name"
        GridViewTextBoxColumn2.Name = "ColMaterialName"
        GridViewTextBoxColumn2.Width = 500
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "MaterialTypeId"
        GridViewTextBoxColumn3.HeaderText = "Material Type"
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.Name = "ColMaterialTypeId"
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "MaterialType"
        GridViewTextBoxColumn4.HeaderText = "Material Type"
        GridViewTextBoxColumn4.Name = "ColMaterialType"
        GridViewTextBoxColumn4.Width = 100
        Me.dgvMaterialList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4})
        Me.dgvMaterialList.MasterTemplate.EnableGrouping = False
        Me.dgvMaterialList.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvMaterialList.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvMaterialList.Name = "dgvMaterialList"
        Me.dgvMaterialList.ReadOnly = True
        Me.dgvMaterialList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMaterialList.Size = New System.Drawing.Size(683, 265)
        Me.dgvMaterialList.TabIndex = 18
        '
        'lblRowCount
        '
        Me.lblRowCount.AutoSize = True
        Me.lblRowCount.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRowCount.Location = New System.Drawing.Point(10, 20)
        Me.lblRowCount.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblRowCount.Name = "lblRowCount"
        Me.lblRowCount.Size = New System.Drawing.Size(0, 15)
        Me.lblRowCount.TabIndex = 8
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.lblIO)
        Me.GBoxMain.Controls.Add(Me.cmbType)
        Me.GBoxMain.Controls.Add(Me.lblMaterialType)
        Me.GBoxMain.Controls.Add(Me.txtMaterialName)
        Me.GBoxMain.Controls.Add(Me.lblCategoryName)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(8, 11)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GBoxMain.Size = New System.Drawing.Size(690, 120)
        Me.GBoxMain.TabIndex = 18
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Material Information"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(259, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(15, 14)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "*"
        '
        'lblIO
        '
        Me.lblIO.AutoSize = True
        Me.lblIO.BackColor = System.Drawing.Color.White
        Me.lblIO.ForeColor = System.Drawing.Color.Maroon
        Me.lblIO.Location = New System.Drawing.Point(366, 44)
        Me.lblIO.Name = "lblIO"
        Me.lblIO.Size = New System.Drawing.Size(15, 14)
        Me.lblIO.TabIndex = 23
        Me.lblIO.Text = "*"
        '
        'cmbType
        '
        Me.cmbType.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        Me.cmbType.Font = New System.Drawing.Font("Tahoma", 8.25!)
        RadListDataItem1.Text = "Others"
        RadListDataItem2.Text = "Gold"
        Me.cmbType.Items.Add(RadListDataItem1)
        Me.cmbType.Items.Add(RadListDataItem2)
        Me.cmbType.Location = New System.Drawing.Point(126, 66)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(130, 19)
        Me.cmbType.TabIndex = 1
        '
        'lblMaterialType
        '
        Me.lblMaterialType.AutoSize = True
        Me.lblMaterialType.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblMaterialType.Location = New System.Drawing.Point(43, 68)
        Me.lblMaterialType.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblMaterialType.Name = "lblMaterialType"
        Me.lblMaterialType.Size = New System.Drawing.Size(80, 14)
        Me.lblMaterialType.TabIndex = 3
        Me.lblMaterialType.Text = "Material Type"
        '
        'txtMaterialName
        '
        Me.txtMaterialName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMaterialName.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtMaterialName.Location = New System.Drawing.Point(126, 35)
        Me.txtMaterialName.Name = "txtMaterialName"
        Me.txtMaterialName.Size = New System.Drawing.Size(237, 19)
        Me.txtMaterialName.TabIndex = 0
        '
        'lblCategoryName
        '
        Me.lblCategoryName.AutoSize = True
        Me.lblCategoryName.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblCategoryName.Location = New System.Drawing.Point(40, 37)
        Me.lblCategoryName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCategoryName.Name = "lblCategoryName"
        Me.lblCategoryName.Size = New System.Drawing.Size(83, 14)
        Me.lblCategoryName.TabIndex = 1
        Me.lblCategoryName.Text = "Material Name"
        '
        'frmMaterialMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(713, 502)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.MaximizeBox = False
        Me.Name = "frmMaterialMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Material Master"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMaterialList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMaterialList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.cmbType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMaterialName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents dgvMaterialList As Telerik.WinControls.UI.RadGridView
    Friend WithEvents lblRowCount As Label
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents txtMaterialName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblCategoryName As Label
    Friend WithEvents cmbType As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents lblMaterialType As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents lblIO As Label
End Class
