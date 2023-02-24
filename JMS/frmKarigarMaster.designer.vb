<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmKarigarMaster
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
        Dim GridViewCheckBoxColumn1 As Telerik.WinControls.UI.GridViewCheckBoxColumn = New Telerik.WinControls.UI.GridViewCheckBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.GBoxDetails = New System.Windows.Forms.GroupBox()
        Me.dgvKarigarList = New Telerik.WinControls.UI.RadGridView()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.ChkInHouse = New System.Windows.Forms.CheckBox()
        Me.lblIT = New System.Windows.Forms.Label()
        Me.lblIO = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBoxWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtKarigarName = New Telerik.WinControls.UI.RadTextBox()
        Me.lblKarigarName = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxDetails.SuspendLayout()
        CType(Me.dgvKarigarList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvKarigarList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtBoxWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKarigarName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnExit)
        Me.TabPage1.Controls.Add(Me.btnCancel)
        Me.TabPage1.Controls.Add(Me.btnSave)
        Me.TabPage1.Controls.Add(Me.btnDelete)
        Me.TabPage1.Controls.Add(Me.GBoxDetails)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(704, 475)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(428, 438)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "E&xit"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(357, 438)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(69, 24)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(215, 438)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(69, 24)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(286, 438)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(69, 24)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "&Delete"
        '
        'GBoxDetails
        '
        Me.GBoxDetails.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxDetails.Controls.Add(Me.dgvKarigarList)
        Me.GBoxDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxDetails.Location = New System.Drawing.Point(7, 102)
        Me.GBoxDetails.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxDetails.Name = "GBoxDetails"
        Me.GBoxDetails.Size = New System.Drawing.Size(690, 328)
        Me.GBoxDetails.TabIndex = 22
        Me.GBoxDetails.TabStop = False
        Me.GBoxDetails.Text = "Labour Details"
        '
        'dgvKarigarList
        '
        Me.dgvKarigarList.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvKarigarList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvKarigarList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvKarigarList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvKarigarList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvKarigarList.Location = New System.Drawing.Point(7, 30)
        '
        '
        '
        Me.dgvKarigarList.MasterTemplate.AllowAddNewRow = False
        Me.dgvKarigarList.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "LabourId"
        GridViewTextBoxColumn1.HeaderText = "Labour Id"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "ColLabourId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LabourName"
        GridViewTextBoxColumn2.HeaderText = "Labour Name"
        GridViewTextBoxColumn2.Name = "ColLabourName"
        GridViewTextBoxColumn2.Width = 375
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "BoxWeight"
        GridViewTextBoxColumn3.HeaderText = "Box Wt."
        GridViewTextBoxColumn3.Name = "colBoxWeight"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 100
        GridViewCheckBoxColumn1.EnableExpressionEditor = False
        GridViewCheckBoxColumn1.FieldName = "InHouse"
        GridViewCheckBoxColumn1.HeaderText = "In House"
        GridViewCheckBoxColumn1.MinWidth = 20
        GridViewCheckBoxColumn1.Name = "chkInHouse"
        GridViewCheckBoxColumn1.Width = 90
        Me.dgvKarigarList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewCheckBoxColumn1})
        Me.dgvKarigarList.MasterTemplate.EnableGrouping = False
        Me.dgvKarigarList.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvKarigarList.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvKarigarList.Name = "dgvKarigarList"
        Me.dgvKarigarList.ReadOnly = True
        Me.dgvKarigarList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvKarigarList.Size = New System.Drawing.Size(677, 287)
        Me.dgvKarigarList.TabIndex = 0
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.ChkInHouse)
        Me.GBoxMain.Controls.Add(Me.lblIT)
        Me.GBoxMain.Controls.Add(Me.lblIO)
        Me.GBoxMain.Controls.Add(Me.Label1)
        Me.GBoxMain.Controls.Add(Me.txtBoxWt)
        Me.GBoxMain.Controls.Add(Me.txtKarigarName)
        Me.GBoxMain.Controls.Add(Me.lblKarigarName)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(7, 9)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Size = New System.Drawing.Size(690, 87)
        Me.GBoxMain.TabIndex = 4
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Labour Information"
        '
        'ChkInHouse
        '
        Me.ChkInHouse.AutoSize = True
        Me.ChkInHouse.Checked = True
        Me.ChkInHouse.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkInHouse.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkInHouse.Location = New System.Drawing.Point(599, 55)
        Me.ChkInHouse.Name = "ChkInHouse"
        Me.ChkInHouse.Size = New System.Drawing.Size(75, 18)
        Me.ChkInHouse.TabIndex = 10
        Me.ChkInHouse.Text = "In House"
        Me.ChkInHouse.UseVisualStyleBackColor = True
        '
        'lblIT
        '
        Me.lblIT.AutoSize = True
        Me.lblIT.BackColor = System.Drawing.Color.White
        Me.lblIT.ForeColor = System.Drawing.Color.Maroon
        Me.lblIT.Location = New System.Drawing.Point(211, 55)
        Me.lblIT.Name = "lblIT"
        Me.lblIT.Size = New System.Drawing.Size(15, 14)
        Me.lblIT.TabIndex = 9
        Me.lblIT.Text = "*"
        '
        'lblIO
        '
        Me.lblIO.AutoSize = True
        Me.lblIO.BackColor = System.Drawing.Color.White
        Me.lblIO.ForeColor = System.Drawing.Color.Maroon
        Me.lblIO.Location = New System.Drawing.Point(326, 28)
        Me.lblIO.Name = "lblIO"
        Me.lblIO.Size = New System.Drawing.Size(15, 14)
        Me.lblIO.TabIndex = 8
        Me.lblIO.Text = "*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(52, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Box Wt."
        '
        'txtBoxWt
        '
        Me.txtBoxWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBoxWt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBoxWt.Location = New System.Drawing.Point(108, 52)
        Me.txtBoxWt.Name = "txtBoxWt"
        Me.txtBoxWt.Size = New System.Drawing.Size(100, 19)
        Me.txtBoxWt.TabIndex = 1
        Me.txtBoxWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtKarigarName
        '
        Me.txtKarigarName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtKarigarName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKarigarName.Location = New System.Drawing.Point(108, 25)
        Me.txtKarigarName.Name = "txtKarigarName"
        Me.txtKarigarName.Size = New System.Drawing.Size(215, 19)
        Me.txtKarigarName.TabIndex = 0
        '
        'lblKarigarName
        '
        Me.lblKarigarName.AutoSize = True
        Me.lblKarigarName.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKarigarName.Location = New System.Drawing.Point(25, 28)
        Me.lblKarigarName.Name = "lblKarigarName"
        Me.lblKarigarName.Size = New System.Drawing.Size(79, 14)
        Me.lblKarigarName.TabIndex = 1
        Me.lblKarigarName.Text = "Labour Name"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(712, 502)
        Me.TabControl1.TabIndex = 4
        '
        'frmKarigarMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(712, 502)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmKarigarMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Labour Master"
        Me.TabPage1.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxDetails.ResumeLayout(False)
        CType(Me.dgvKarigarList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvKarigarList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtBoxWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKarigarName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxDetails As GroupBox
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents lblKarigarName As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents dgvKarigarList As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtKarigarName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBoxWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblIT As Label
    Friend WithEvents lblIO As Label
    Friend WithEvents ChkInHouse As CheckBox
End Class
