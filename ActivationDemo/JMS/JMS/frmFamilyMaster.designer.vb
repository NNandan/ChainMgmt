<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFamilyMaster
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBoxDetails = New System.Windows.Forms.GroupBox()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.dgvFamilyList = New Telerik.WinControls.UI.RadGridView()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.lblIO = New System.Windows.Forms.Label()
        Me.lblAccountName = New Telerik.WinControls.UI.RadLabel()
        Me.txtFamilyName = New Telerik.WinControls.UI.RadTextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBoxDetails.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFamilyList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFamilyList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.lblAccountName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFamilyName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TabControl1.Location = New System.Drawing.Point(1, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(532, 457)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GBoxDetails)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(524, 430)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GBoxDetails
        '
        Me.GBoxDetails.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxDetails.Controls.Add(Me.btnExit)
        Me.GBoxDetails.Controls.Add(Me.dgvFamilyList)
        Me.GBoxDetails.Controls.Add(Me.btnCancel)
        Me.GBoxDetails.Controls.Add(Me.btnSave)
        Me.GBoxDetails.Controls.Add(Me.btnDelete)
        Me.GBoxDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxDetails.Location = New System.Drawing.Point(5, 84)
        Me.GBoxDetails.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxDetails.Name = "GBoxDetails"
        Me.GBoxDetails.Size = New System.Drawing.Size(514, 341)
        Me.GBoxDetails.TabIndex = 23
        Me.GBoxDetails.TabStop = False
        Me.GBoxDetails.Text = "Family Details"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(352, 306)
        Me.btnExit.Name = "btnExit"
        '
        '
        '
        Me.btnExit.RootElement.ControlBounds = New System.Drawing.Rectangle(352, 306, 110, 24)
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 798
        Me.btnExit.Text = "E&xit"
        '
        'dgvFamilyList
        '
        Me.dgvFamilyList.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvFamilyList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvFamilyList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvFamilyList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvFamilyList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvFamilyList.Location = New System.Drawing.Point(6, 23)
        '
        '
        '
        Me.dgvFamilyList.MasterTemplate.AllowAddNewRow = False
        Me.dgvFamilyList.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "FamilyId"
        GridViewTextBoxColumn1.HeaderText = "Family Id"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "colFamilyId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "FamilyName"
        GridViewTextBoxColumn2.HeaderText = "Family"
        GridViewTextBoxColumn2.Name = "colFamilyName"
        GridViewTextBoxColumn2.Width = 498
        Me.dgvFamilyList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2})
        Me.dgvFamilyList.MasterTemplate.EnableGrouping = False
        Me.dgvFamilyList.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvFamilyList.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvFamilyList.Name = "dgvFamilyList"
        Me.dgvFamilyList.ReadOnly = True
        Me.dgvFamilyList.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.dgvFamilyList.RootElement.ControlBounds = New System.Drawing.Rectangle(6, 23, 240, 150)
        Me.dgvFamilyList.Size = New System.Drawing.Size(500, 270)
        Me.dgvFamilyList.TabIndex = 24
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(275, 306)
        Me.btnCancel.Name = "btnCancel"
        '
        '
        '
        Me.btnCancel.RootElement.ControlBounds = New System.Drawing.Rectangle(275, 306, 110, 24)
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(121, 306)
        Me.btnSave.Name = "btnSave"
        '
        '
        '
        Me.btnSave.RootElement.ControlBounds = New System.Drawing.Rectangle(121, 306, 110, 24)
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(198, 306)
        Me.btnDelete.Name = "btnDelete"
        '
        '
        '
        Me.btnDelete.RootElement.ControlBounds = New System.Drawing.Rectangle(198, 306, 110, 24)
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 21
        Me.btnDelete.Text = "&Delete"
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.lblIO)
        Me.GBoxMain.Controls.Add(Me.lblAccountName)
        Me.GBoxMain.Controls.Add(Me.txtFamilyName)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(5, 5)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Size = New System.Drawing.Size(514, 73)
        Me.GBoxMain.TabIndex = 19
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Family Information"
        '
        'lblIO
        '
        Me.lblIO.AutoSize = True
        Me.lblIO.BackColor = System.Drawing.Color.White
        Me.lblIO.ForeColor = System.Drawing.Color.Maroon
        Me.lblIO.Location = New System.Drawing.Point(348, 34)
        Me.lblIO.Name = "lblIO"
        Me.lblIO.Size = New System.Drawing.Size(15, 14)
        Me.lblIO.TabIndex = 22
        Me.lblIO.Text = "*"
        '
        'lblAccountName
        '
        Me.lblAccountName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblAccountName.Location = New System.Drawing.Point(35, 32)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(86, 18)
        Me.lblAccountName.TabIndex = 6
        Me.lblAccountName.Text = "Family Name"
        '
        'txtFamilyName
        '
        Me.txtFamilyName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtFamilyName.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtFamilyName.Location = New System.Drawing.Point(125, 31)
        Me.txtFamilyName.Name = "txtFamilyName"
        Me.txtFamilyName.Size = New System.Drawing.Size(220, 19)
        Me.txtFamilyName.TabIndex = 4
        '
        'frmFamilyMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(534, 460)
        Me.Controls.Add(Me.TabControl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmFamilyMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Family Master"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBoxDetails.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFamilyList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFamilyList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.lblAccountName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFamilyName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents lblIO As Label
    Friend WithEvents lblAccountName As Telerik.WinControls.UI.RadLabel
    Friend WithEvents txtFamilyName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents GBoxDetails As GroupBox
    Private WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Private WithEvents dgvFamilyList As Telerik.WinControls.UI.RadGridView
    Private WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Private WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Private WithEvents btnDelete As Telerik.WinControls.UI.RadButton
End Class
