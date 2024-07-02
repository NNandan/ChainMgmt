<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMeltingMaster
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
        Me.dgvAccountList = New Telerik.WinControls.UI.RadGridView()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.lblIO = New System.Windows.Forms.Label()
        Me.lblAccountName = New Telerik.WinControls.UI.RadLabel()
        Me.txtMeltingValue = New Telerik.WinControls.UI.RadTextBox()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBoxDetails.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAccountList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAccountList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.lblAccountName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMeltingValue, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TabControl1.TabIndex = 5
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
        Me.GBoxDetails.Controls.Add(Me.dgvAccountList)
        Me.GBoxDetails.Controls.Add(Me.btnCancel)
        Me.GBoxDetails.Controls.Add(Me.btnSave)
        Me.GBoxDetails.Controls.Add(Me.btnDelete)
        Me.GBoxDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxDetails.Location = New System.Drawing.Point(8, 141)
        Me.GBoxDetails.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxDetails.Name = "GBoxDetails"
        Me.GBoxDetails.Size = New System.Drawing.Size(690, 328)
        Me.GBoxDetails.TabIndex = 22
        Me.GBoxDetails.TabStop = False
        Me.GBoxDetails.Text = "Melting Details"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(431, 298)
        Me.btnExit.Name = "btnExit"
        '
        '
        '
        Me.btnExit.RootElement.ControlBounds = New System.Drawing.Rectangle(431, 298, 110, 24)
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 798
        Me.btnExit.Text = "E&xit"
        '
        'dgvAccountList
        '
        Me.dgvAccountList.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvAccountList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvAccountList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvAccountList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvAccountList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvAccountList.Location = New System.Drawing.Point(6, 23)
        '
        '
        '
        Me.dgvAccountList.MasterTemplate.AllowAddNewRow = False
        Me.dgvAccountList.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "MeltingId"
        GridViewTextBoxColumn1.HeaderText = "Account Id"
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "colMeltingId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "MeltingValue"
        GridViewTextBoxColumn2.HeaderText = "Melting"
        GridViewTextBoxColumn2.Name = "colMeltingValue"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn2.Width = 498
        Me.dgvAccountList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2})
        Me.dgvAccountList.MasterTemplate.EnableGrouping = False
        Me.dgvAccountList.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvAccountList.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvAccountList.Name = "dgvAccountList"
        Me.dgvAccountList.ReadOnly = True
        Me.dgvAccountList.RightToLeft = System.Windows.Forms.RightToLeft.No
        '
        '
        '
        Me.dgvAccountList.RootElement.ControlBounds = New System.Drawing.Rectangle(6, 23, 240, 150)
        Me.dgvAccountList.Size = New System.Drawing.Size(681, 270)
        Me.dgvAccountList.TabIndex = 24
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(354, 298)
        Me.btnCancel.Name = "btnCancel"
        '
        '
        '
        Me.btnCancel.RootElement.ControlBounds = New System.Drawing.Rectangle(354, 298, 110, 24)
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "&Cancel"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(200, 298)
        Me.btnSave.Name = "btnSave"
        '
        '
        '
        Me.btnSave.RootElement.ControlBounds = New System.Drawing.Rectangle(200, 298, 110, 24)
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(277, 298)
        Me.btnDelete.Name = "btnDelete"
        '
        '
        '
        Me.btnDelete.RootElement.ControlBounds = New System.Drawing.Rectangle(277, 298, 110, 24)
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 21
        Me.btnDelete.Text = "&Delete"
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.lblIO)
        Me.GBoxMain.Controls.Add(Me.lblAccountName)
        Me.GBoxMain.Controls.Add(Me.txtMeltingValue)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxMain.Location = New System.Drawing.Point(10, 10)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Size = New System.Drawing.Size(690, 126)
        Me.GBoxMain.TabIndex = 18
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Melting Information"
        '
        'lblIO
        '
        Me.lblIO.AutoSize = True
        Me.lblIO.BackColor = System.Drawing.Color.White
        Me.lblIO.ForeColor = System.Drawing.Color.Maroon
        Me.lblIO.Location = New System.Drawing.Point(209, 43)
        Me.lblIO.Name = "lblIO"
        Me.lblIO.Size = New System.Drawing.Size(15, 14)
        Me.lblIO.TabIndex = 7
        Me.lblIO.Text = "*"
        '
        'lblAccountName
        '
        Me.lblAccountName.AutoSize = False
        Me.lblAccountName.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblAccountName.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblAccountName.Location = New System.Drawing.Point(71, 41)
        Me.lblAccountName.Name = "lblAccountName"
        '
        '
        '
        Me.lblAccountName.RootElement.ControlBounds = New System.Drawing.Rectangle(71, 41, 100, 18)
        Me.lblAccountName.Size = New System.Drawing.Size(50, 18)
        Me.lblAccountName.TabIndex = 6
        Me.lblAccountName.Text = "Melting"
        Me.lblAccountName.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMeltingValue
        '
        Me.txtMeltingValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtMeltingValue.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeltingValue.Location = New System.Drawing.Point(126, 40)
        Me.txtMeltingValue.Name = "txtMeltingValue"
        '
        '
        '
        Me.txtMeltingValue.RootElement.ControlBounds = New System.Drawing.Rectangle(126, 40, 100, 20)
        Me.txtMeltingValue.RootElement.StretchVertically = True
        Me.txtMeltingValue.Size = New System.Drawing.Size(80, 20)
        Me.txtMeltingValue.TabIndex = 0
        Me.txtMeltingValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmMeltingMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(719, 502)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMeltingMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Melting Master"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBoxDetails.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAccountList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAccountList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.lblAccountName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMeltingValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxDetails As GroupBox
    Friend WithEvents GBoxMain As GroupBox
    Private WithEvents lblAccountName As Telerik.WinControls.UI.RadLabel
    Private WithEvents txtMeltingValue As Telerik.WinControls.UI.RadTextBox
    Private WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Private WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Private WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Private WithEvents dgvAccountList As Telerik.WinControls.UI.RadGridView
    Private WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents lblIO As Label
End Class
