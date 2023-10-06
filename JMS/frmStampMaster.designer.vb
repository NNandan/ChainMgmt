<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStampMaster
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBoxDetails = New System.Windows.Forms.GroupBox()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.dgvStampList = New Telerik.WinControls.UI.RadGridView()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.lblIO = New System.Windows.Forms.Label()
        Me.lblStampName = New Telerik.WinControls.UI.RadLabel()
        Me.txtStampName = New Telerik.WinControls.UI.RadTextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBoxDetails.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStampList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStampList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.lblStampName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStampName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(719, 502)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GBoxDetails)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(711, 475)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GBoxDetails
        '
        Me.GBoxDetails.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxDetails.Controls.Add(Me.btnExit)
        Me.GBoxDetails.Controls.Add(Me.dgvStampList)
        Me.GBoxDetails.Controls.Add(Me.btnCancel)
        Me.GBoxDetails.Controls.Add(Me.btnSave)
        Me.GBoxDetails.Controls.Add(Me.btnDelete)
        Me.GBoxDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxDetails.Location = New System.Drawing.Point(8, 141)
        Me.GBoxDetails.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxDetails.Name = "GBoxDetails"
        Me.GBoxDetails.Size = New System.Drawing.Size(690, 324)
        Me.GBoxDetails.TabIndex = 22
        Me.GBoxDetails.TabStop = False
        Me.GBoxDetails.Text = "Stamp Details"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(432, 290)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 800
        Me.btnExit.Text = "E&xit"
        '
        'dgvStampList
        '
        Me.dgvStampList.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvStampList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvStampList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvStampList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvStampList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvStampList.Location = New System.Drawing.Point(6, 26)
        '
        '
        '
        Me.dgvStampList.MasterTemplate.AllowAddNewRow = False
        Me.dgvStampList.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "StampId"
        GridViewTextBoxColumn1.HeaderText = "Stamp Id"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "colStampId"
        GridViewTextBoxColumn2.AllowGroup = False
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "StampName"
        GridViewTextBoxColumn2.HeaderText = "Stamp Name"
        GridViewTextBoxColumn2.Name = "colStampName"
        GridViewTextBoxColumn2.Width = 498
        Me.dgvStampList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2})
        Me.dgvStampList.MasterTemplate.EnableGrouping = False
        Me.dgvStampList.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvStampList.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvStampList.Name = "dgvStampList"
        Me.dgvStampList.ReadOnly = True
        Me.dgvStampList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvStampList.Size = New System.Drawing.Size(678, 257)
        Me.dgvStampList.TabIndex = 24
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(355, 290)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(201, 290)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "&Save"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(278, 290)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 21
        Me.btnDelete.Text = "&Delete"
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.lblIO)
        Me.GBoxMain.Controls.Add(Me.lblStampName)
        Me.GBoxMain.Controls.Add(Me.txtStampName)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(10, 10)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Size = New System.Drawing.Size(690, 126)
        Me.GBoxMain.TabIndex = 18
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Stamp Information"
        '
        'lblIO
        '
        Me.lblIO.AutoSize = True
        Me.lblIO.BackColor = System.Drawing.Color.White
        Me.lblIO.ForeColor = System.Drawing.Color.Maroon
        Me.lblIO.Location = New System.Drawing.Point(348, 43)
        Me.lblIO.Name = "lblIO"
        Me.lblIO.Size = New System.Drawing.Size(15, 14)
        Me.lblIO.TabIndex = 32
        Me.lblIO.Text = "*"
        '
        'lblStampName
        '
        Me.lblStampName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblStampName.Location = New System.Drawing.Point(37, 41)
        Me.lblStampName.Name = "lblStampName"
        Me.lblStampName.Size = New System.Drawing.Size(85, 18)
        Me.lblStampName.TabIndex = 6
        Me.lblStampName.Text = "Stamp Name"
        '
        'txtStampName
        '
        Me.txtStampName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtStampName.Location = New System.Drawing.Point(125, 40)
        Me.txtStampName.Name = "txtStampName"
        Me.txtStampName.Size = New System.Drawing.Size(220, 20)
        Me.txtStampName.TabIndex = 4
        '
        'frmStampMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(719, 502)
        Me.Controls.Add(Me.TabControl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmStampMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stamp Master"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBoxDetails.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStampList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStampList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.lblStampName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStampName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxDetails As GroupBox
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents dgvStampList As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents lblStampName As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtStampName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblIO As Label
End Class
