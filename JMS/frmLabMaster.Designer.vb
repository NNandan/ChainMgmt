<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLabMaster
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
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim SortDescriptor1 As Telerik.WinControls.Data.SortDescriptor = New Telerik.WinControls.Data.SortDescriptor()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GBoxDetails = New System.Windows.Forms.GroupBox()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnDelete = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.dgvLabList = New Telerik.WinControls.UI.RadGridView()
        Me.GBoxMain = New System.Windows.Forms.GroupBox()
        Me.txtLossWt = New Telerik.WinControls.UI.RadTextBox()
        Me.lblLossWt = New System.Windows.Forms.Label()
        Me.txtLabRate = New Telerik.WinControls.UI.RadTextBox()
        Me.txtLabName = New Telerik.WinControls.UI.RadTextBox()
        Me.lblCalculate = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GBoxDetails.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLabList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLabList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBoxMain.SuspendLayout()
        CType(Me.txtLossWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLabRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLabName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(715, 502)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GBoxDetails)
        Me.TabPage1.Controls.Add(Me.GBoxMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(707, 475)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GBoxDetails
        '
        Me.GBoxDetails.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxDetails.Controls.Add(Me.btnExit)
        Me.GBoxDetails.Controls.Add(Me.btnCancel)
        Me.GBoxDetails.Controls.Add(Me.btnDelete)
        Me.GBoxDetails.Controls.Add(Me.btnSave)
        Me.GBoxDetails.Controls.Add(Me.dgvLabList)
        Me.GBoxDetails.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxDetails.Location = New System.Drawing.Point(8, 151)
        Me.GBoxDetails.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxDetails.Name = "GBoxDetails"
        Me.GBoxDetails.Size = New System.Drawing.Size(690, 314)
        Me.GBoxDetails.TabIndex = 22
        Me.GBoxDetails.TabStop = False
        Me.GBoxDetails.Text = "Lab Details"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(437, 279)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 800
        Me.btnExit.Text = "E&xit"
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnCancel.Location = New System.Drawing.Point(359, 279)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "&Cancel"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnDelete.Location = New System.Drawing.Point(281, 279)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 25)
        Me.btnDelete.TabIndex = 21
        Me.btnDelete.Text = "&Delete"
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnSave.Location = New System.Drawing.Point(204, 279)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 20
        Me.btnSave.Text = "&Save"
        '
        'dgvLabList
        '
        Me.dgvLabList.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.dgvLabList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLabList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvLabList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLabList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLabList.Location = New System.Drawing.Point(6, 30)
        '
        '
        '
        Me.dgvLabList.MasterTemplate.AllowAddNewRow = False
        Me.dgvLabList.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "LabId"
        GridViewTextBoxColumn1.HeaderText = "Lab Id."
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "ColLabId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LabName"
        GridViewTextBoxColumn2.HeaderText = "Lab Name"
        GridViewTextBoxColumn2.Name = "ColLabName"
        GridViewTextBoxColumn2.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending
        GridViewTextBoxColumn2.Width = 471
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "LabRate"
        GridViewTextBoxColumn3.HeaderText = "Lab Rate"
        GridViewTextBoxColumn3.Name = "ColLabRate"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 80
        GridViewDecimalColumn1.EnableExpressionEditor = False
        GridViewDecimalColumn1.FieldName = "LossWt"
        GridViewDecimalColumn1.HeaderText = "Loss Wt."
        GridViewDecimalColumn1.Name = "ColLossWt"
        GridViewDecimalColumn1.Width = 80
        Me.dgvLabList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewDecimalColumn1})
        Me.dgvLabList.MasterTemplate.EnableGrouping = False
        Me.dgvLabList.MasterTemplate.ShowRowHeaderColumn = False
        SortDescriptor1.PropertyName = "ColLabName"
        Me.dgvLabList.MasterTemplate.SortDescriptors.AddRange(New Telerik.WinControls.Data.SortDescriptor() {SortDescriptor1})
        Me.dgvLabList.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvLabList.Name = "dgvLabList"
        Me.dgvLabList.ReadOnly = True
        Me.dgvLabList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLabList.Size = New System.Drawing.Size(678, 240)
        Me.dgvLabList.TabIndex = 18
        '
        'GBoxMain
        '
        Me.GBoxMain.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.GBoxMain.Controls.Add(Me.txtLossWt)
        Me.GBoxMain.Controls.Add(Me.lblLossWt)
        Me.GBoxMain.Controls.Add(Me.txtLabRate)
        Me.GBoxMain.Controls.Add(Me.txtLabName)
        Me.GBoxMain.Controls.Add(Me.lblCalculate)
        Me.GBoxMain.Controls.Add(Me.Label28)
        Me.GBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.GBoxMain.Location = New System.Drawing.Point(8, 10)
        Me.GBoxMain.Margin = New System.Windows.Forms.Padding(5, 3, 3, 3)
        Me.GBoxMain.Name = "GBoxMain"
        Me.GBoxMain.Size = New System.Drawing.Size(690, 137)
        Me.GBoxMain.TabIndex = 18
        Me.GBoxMain.TabStop = False
        Me.GBoxMain.Text = "Lab Information"
        '
        'txtLossWt
        '
        Me.txtLossWt.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLossWt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtLossWt.Location = New System.Drawing.Point(115, 99)
        Me.txtLossWt.Name = "txtLossWt"
        Me.txtLossWt.Size = New System.Drawing.Size(63, 20)
        Me.txtLossWt.TabIndex = 7
        Me.txtLossWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLossWt
        '
        Me.lblLossWt.AutoSize = True
        Me.lblLossWt.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLossWt.Location = New System.Drawing.Point(56, 101)
        Me.lblLossWt.Name = "lblLossWt"
        Me.lblLossWt.Size = New System.Drawing.Size(55, 14)
        Me.lblLossWt.TabIndex = 6
        Me.lblLossWt.Text = "Loss Wt."
        '
        'txtLabRate
        '
        Me.txtLabRate.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLabRate.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtLabRate.Location = New System.Drawing.Point(115, 74)
        Me.txtLabRate.Name = "txtLabRate"
        Me.txtLabRate.Size = New System.Drawing.Size(63, 20)
        Me.txtLabRate.TabIndex = 5
        Me.txtLabRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtLabName
        '
        Me.txtLabName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtLabName.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtLabName.Location = New System.Drawing.Point(115, 49)
        Me.txtLabName.Name = "txtLabName"
        Me.txtLabName.Size = New System.Drawing.Size(364, 20)
        Me.txtLabName.TabIndex = 4
        '
        'lblCalculate
        '
        Me.lblCalculate.AutoSize = True
        Me.lblCalculate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalculate.Location = New System.Drawing.Point(56, 77)
        Me.lblCalculate.Name = "lblCalculate"
        Me.lblCalculate.Size = New System.Drawing.Size(55, 14)
        Me.lblCalculate.TabIndex = 3
        Me.lblCalculate.Text = "Lab Rate"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(50, 52)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(61, 14)
        Me.Label28.TabIndex = 1
        Me.Label28.Text = "Lab Name"
        '
        'frmLabMaster
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(715, 502)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmLabMaster"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lab Master"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GBoxDetails.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLabList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLabList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBoxMain.ResumeLayout(False)
        Me.GBoxMain.PerformLayout()
        CType(Me.txtLossWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLabRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLabName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents GBoxDetails As GroupBox
    Friend WithEvents GBoxMain As GroupBox
    Friend WithEvents lblCalculate As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents dgvLabList As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtLabRate As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtLabName As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtLossWt As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblLossWt As Label
End Class
