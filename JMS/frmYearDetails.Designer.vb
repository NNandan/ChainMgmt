<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmYearDetails
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
        Dim GridViewDateTimeColumn1 As Telerik.WinControls.UI.GridViewDateTimeColumn = New Telerik.WinControls.UI.GridViewDateTimeColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvYear = New Telerik.WinControls.UI.RadGridView()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        CType(Me.dgvYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvYear.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Calibri", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(210, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 24)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "Select Period"
        '
        'dgvYear
        '
        Me.dgvYear.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.dgvYear.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvYear.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvYear.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvYear.Location = New System.Drawing.Point(4, 32)
        '
        '
        '
        Me.dgvYear.MasterTemplate.AllowAddNewRow = False
        Me.dgvYear.MasterTemplate.AllowColumnReorder = False
        Me.dgvYear.MasterTemplate.AllowDeleteRow = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "Year_Id"
        GridViewTextBoxColumn1.HeaderText = "Sr."
        GridViewTextBoxColumn1.Name = "GSrNo"
        GridViewTextBoxColumn1.ReadOnly = True
        GridViewTextBoxColumn1.Width = 42
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "FinancialYear"
        GridViewTextBoxColumn2.HeaderText = "Financial Period"
        GridViewTextBoxColumn2.Name = "GAccountYear"
        GridViewTextBoxColumn2.ReadOnly = True
        GridViewTextBoxColumn2.Width = 290
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "Year_StartDt"
        GridViewTextBoxColumn3.HeaderText = "Start Date"
        GridViewTextBoxColumn3.Name = "GStartDt"
        GridViewTextBoxColumn3.Width = 100
        GridViewDateTimeColumn1.EnableExpressionEditor = False
        GridViewDateTimeColumn1.FieldName = "Year_EndDt"
        GridViewDateTimeColumn1.HeaderText = "End Date"
        GridViewDateTimeColumn1.Name = "GEndDt"
        GridViewDateTimeColumn1.Width = 100
        Me.dgvYear.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewDateTimeColumn1})
        Me.dgvYear.MasterTemplate.EnableGrouping = False
        Me.dgvYear.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvYear.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvYear.Name = "dgvYear"
        Me.dgvYear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvYear.Size = New System.Drawing.Size(527, 252)
        Me.dgvYear.TabIndex = 789
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(270, 287)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(104, 71)
        Me.btnBack.TabIndex = 793
        Me.btnBack.Text = "&Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(380, 287)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(104, 71)
        Me.btnDelete.TabIndex = 792
        Me.btnDelete.Text = "&Delete Existing Year"
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpen.Location = New System.Drawing.Point(160, 287)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(104, 71)
        Me.btnOpen.TabIndex = 791
        Me.btnOpen.Text = "&Open Acounting Year"
        Me.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'btnCreate
        '
        Me.btnCreate.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreate.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCreate.Location = New System.Drawing.Point(50, 287)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(104, 71)
        Me.btnCreate.TabIndex = 790
        Me.btnCreate.Text = "Create &New Accounting Year"
        Me.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnCreate.UseVisualStyleBackColor = True
        '
        'frmYearDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 361)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.dgvYear)
        Me.Controls.Add(Me.Label2)
        Me.MaximizeBox = False
        Me.Name = "frmYearDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvYear.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents dgvYear As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnBack As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnOpen As Button
    Friend WithEvents btnCreate As Button
End Class
