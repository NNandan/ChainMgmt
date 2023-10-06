<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGConvFactor
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
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbMaterial = New Telerik.WinControls.UI.RadDropDownList()
        Me.cmbMelting = New Telerik.WinControls.UI.RadDropDownList()
        Me.txtSrNo = New Telerik.WinControls.UI.RadTextBox()
        Me.txtConvPerFactor = New Telerik.WinControls.UI.RadTextBox()
        Me.dgvConvFactor = New Telerik.WinControls.UI.RadGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCreatedBy = New Telerik.WinControls.UI.RadTextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.TransDt = New System.Windows.Forms.DateTimePicker()
        Me.lblCreatedBy = New System.Windows.Forms.Label()
        Me.BtnExit = New Telerik.WinControls.UI.RadButton()
        Me.BtnCancel = New Telerik.WinControls.UI.RadButton()
        Me.BtnDelete = New Telerik.WinControls.UI.RadButton()
        Me.BtnSave = New Telerik.WinControls.UI.RadButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvConvFactorList = New Telerik.WinControls.UI.RadGridView()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.cmbMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbMelting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtConvPerFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConvFactor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConvFactor.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtCreatedBy, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnDelete, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvConvFactorList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConvFactorList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(613, 388)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.BtnExit)
        Me.TabPage1.Controls.Add(Me.BtnCancel)
        Me.TabPage1.Controls.Add(Me.BtnDelete)
        Me.TabPage1.Controls.Add(Me.BtnSave)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(605, 362)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Information"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbMaterial)
        Me.GroupBox2.Controls.Add(Me.cmbMelting)
        Me.GroupBox2.Controls.Add(Me.txtSrNo)
        Me.GroupBox2.Controls.Add(Me.txtConvPerFactor)
        Me.GroupBox2.Controls.Add(Me.dgvConvFactor)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(3, 110)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(522, 196)
        Me.GroupBox2.TabIndex = 47
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Conv % Factor Details"
        '
        'cmbMaterial
        '
        Me.cmbMaterial.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbMaterial.Location = New System.Drawing.Point(209, 19)
        Me.cmbMaterial.Name = "cmbMaterial"
        Me.cmbMaterial.Size = New System.Drawing.Size(143, 20)
        Me.cmbMaterial.TabIndex = 33
        '
        'cmbMelting
        '
        Me.cmbMelting.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmbMelting.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.cmbMelting.Location = New System.Drawing.Point(55, 19)
        Me.cmbMelting.Name = "cmbMelting"
        Me.cmbMelting.Size = New System.Drawing.Size(151, 20)
        Me.cmbMelting.TabIndex = 32
        '
        'txtSrNo
        '
        Me.txtSrNo.Location = New System.Drawing.Point(5, 19)
        Me.txtSrNo.Name = "txtSrNo"
        Me.txtSrNo.Size = New System.Drawing.Size(47, 20)
        Me.txtSrNo.TabIndex = 40
        '
        'txtConvPerFactor
        '
        Me.txtConvPerFactor.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtConvPerFactor.Location = New System.Drawing.Point(354, 19)
        Me.txtConvPerFactor.Name = "txtConvPerFactor"
        Me.txtConvPerFactor.Size = New System.Drawing.Size(151, 20)
        Me.txtConvPerFactor.TabIndex = 41
        '
        'dgvConvFactor
        '
        Me.dgvConvFactor.BackColor = System.Drawing.Color.Transparent
        Me.dgvConvFactor.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvConvFactor.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvConvFactor.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvConvFactor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConvFactor.Location = New System.Drawing.Point(5, 42)
        '
        '
        '
        Me.dgvConvFactor.MasterTemplate.AllowAddNewRow = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "ConvFactorID"
        GridViewTextBoxColumn1.HeaderText = "Sr.No"
        GridViewTextBoxColumn1.Name = "colConvFactorID"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "MeltingId"
        GridViewTextBoxColumn2.HeaderText = "MeltingId"
        GridViewTextBoxColumn2.IsVisible = False
        GridViewTextBoxColumn2.Name = "colMeltingId"
        GridViewTextBoxColumn2.Width = 100
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "MeltingValue"
        GridViewTextBoxColumn3.HeaderText = "Melting %"
        GridViewTextBoxColumn3.Name = "colMeltingName"
        GridViewTextBoxColumn3.Width = 151
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "MaterialId"
        GridViewTextBoxColumn4.HeaderText = "MaterialId"
        GridViewTextBoxColumn4.IsVisible = False
        GridViewTextBoxColumn4.Name = "colMaterialId"
        GridViewTextBoxColumn4.Width = 100
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "MaterialName"
        GridViewTextBoxColumn5.HeaderText = "Material Name"
        GridViewTextBoxColumn5.Name = "colMaterialName"
        GridViewTextBoxColumn5.Width = 150
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "ConvPerFactor"
        GridViewTextBoxColumn6.HeaderText = "Conv % Factor"
        GridViewTextBoxColumn6.Name = "colConvPerFactor"
        GridViewTextBoxColumn6.Width = 150
        Me.dgvConvFactor.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.dgvConvFactor.MasterTemplate.EnableGrouping = False
        Me.dgvConvFactor.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvConvFactor.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvConvFactor.Name = "dgvConvFactor"
        Me.dgvConvFactor.ReadOnly = True
        Me.dgvConvFactor.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvConvFactor.Size = New System.Drawing.Size(500, 145)
        Me.dgvConvFactor.TabIndex = 42
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtCreatedBy)
        Me.GroupBox1.Controls.Add(Me.lblDate)
        Me.GroupBox1.Controls.Add(Me.TransDt)
        Me.GroupBox1.Controls.Add(Me.lblCreatedBy)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(522, 98)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Conv % Factor"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(294, 67)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(224, 14)
        Me.Label9.TabIndex = 157
        Me.Label9.Text = "Press  ( F12 )  To Delete Selected Row"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label10.Location = New System.Drawing.Point(6, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(251, 14)
        Me.Label10.TabIndex = 156
        Me.Label10.Text = "Press  ( F2 )  To Clear Conv % Factor Details"
        '
        'txtCreatedBy
        '
        Me.txtCreatedBy.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.txtCreatedBy.Location = New System.Drawing.Point(380, 19)
        Me.txtCreatedBy.Name = "txtCreatedBy"
        Me.txtCreatedBy.ReadOnly = True
        Me.txtCreatedBy.Size = New System.Drawing.Size(125, 20)
        Me.txtCreatedBy.TabIndex = 38
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblDate.Location = New System.Drawing.Point(32, 24)
        Me.lblDate.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(67, 14)
        Me.lblDate.TabIndex = 36
        Me.lblDate.Text = "Created Dt"
        '
        'TransDt
        '
        Me.TransDt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.TransDt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TransDt.Location = New System.Drawing.Point(115, 19)
        Me.TransDt.Name = "TransDt"
        Me.TransDt.Size = New System.Drawing.Size(114, 22)
        Me.TransDt.TabIndex = 35
        Me.TransDt.TabStop = False
        '
        'lblCreatedBy
        '
        Me.lblCreatedBy.AutoSize = True
        Me.lblCreatedBy.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblCreatedBy.Location = New System.Drawing.Point(298, 22)
        Me.lblCreatedBy.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCreatedBy.Name = "lblCreatedBy"
        Me.lblCreatedBy.Size = New System.Drawing.Size(67, 14)
        Me.lblCreatedBy.TabIndex = 39
        Me.lblCreatedBy.Text = "Created By"
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(353, 312)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 25)
        Me.BtnExit.TabIndex = 46
        Me.BtnExit.Text = "E&xit"
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(272, 312)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(75, 25)
        Me.BtnCancel.TabIndex = 45
        Me.BtnCancel.Text = "&Cancel"
        '
        'BtnDelete
        '
        Me.BtnDelete.Location = New System.Drawing.Point(191, 312)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(75, 25)
        Me.BtnDelete.TabIndex = 44
        Me.BtnDelete.Text = "&Delete"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(110, 312)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 25)
        Me.BtnSave.TabIndex = 43
        Me.BtnSave.Text = "&Save"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvConvFactorList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(605, 362)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Edit Data"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvConvFactorList
        '
        Me.dgvConvFactorList.BackColor = System.Drawing.Color.Transparent
        Me.dgvConvFactorList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvConvFactorList.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvConvFactorList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvConvFactorList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConvFactorList.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.dgvConvFactorList.MasterTemplate.AllowAddNewRow = False
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "ConvFactorID"
        GridViewTextBoxColumn7.HeaderText = "ConvFactorID"
        GridViewTextBoxColumn7.IsVisible = False
        GridViewTextBoxColumn7.Name = "colConvFactorID"
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "CreatedDt"
        GridViewTextBoxColumn8.HeaderText = "CreatedDt"
        GridViewTextBoxColumn8.Name = "colCreatedDt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn8.Width = 120
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "MeltingId"
        GridViewTextBoxColumn9.HeaderText = "MeltingId"
        GridViewTextBoxColumn9.IsVisible = False
        GridViewTextBoxColumn9.Name = "colMeltingId"
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "MeltingValue"
        GridViewTextBoxColumn10.HeaderText = "Melting Value"
        GridViewTextBoxColumn10.Name = "colMeltingValue"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn10.Width = 120
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "MaterialId"
        GridViewTextBoxColumn11.HeaderText = "MaterialId"
        GridViewTextBoxColumn11.IsVisible = False
        GridViewTextBoxColumn11.Name = "colMaterialId"
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "MaterialName"
        GridViewTextBoxColumn12.HeaderText = "Material Name"
        GridViewTextBoxColumn12.Name = "colMaterialName"
        GridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn12.Width = 120
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "ConvPerFactor"
        GridViewTextBoxColumn13.HeaderText = "ConvPerFactor"
        GridViewTextBoxColumn13.Name = "colConvPerFactor"
        GridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn13.Width = 120
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "CreatedBy"
        GridViewTextBoxColumn14.HeaderText = "CreatedBy"
        GridViewTextBoxColumn14.Name = "colCreatedBy"
        GridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn14.Width = 122
        Me.dgvConvFactorList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14})
        Me.dgvConvFactorList.MasterTemplate.EnableGrouping = False
        Me.dgvConvFactorList.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvConvFactorList.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvConvFactorList.Name = "dgvConvFactorList"
        Me.dgvConvFactorList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvConvFactorList.Size = New System.Drawing.Size(601, 356)
        Me.dgvConvFactorList.TabIndex = 0
        '
        'frmGConvFactor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(612, 391)
        Me.Controls.Add(Me.TabControl1)
        Me.KeyPreview = True
        Me.Name = "frmGConvFactor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Conv % Factor"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.cmbMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbMelting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSrNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtConvPerFactor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConvFactor.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConvFactor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtCreatedBy, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnDelete, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnSave, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvConvFactorList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConvFactorList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents cmbMelting As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents TransDt As DateTimePicker
    Friend WithEvents lblDate As Label
    Friend WithEvents cmbMaterial As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents txtCreatedBy As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblCreatedBy As Label
    Friend WithEvents BtnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnDelete As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents dgvConvFactor As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtConvPerFactor As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents txtSrNo As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents dgvConvFactorList As Telerik.WinControls.UI.RadGridView
End Class
