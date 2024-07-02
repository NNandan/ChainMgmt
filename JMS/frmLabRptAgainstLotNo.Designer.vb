<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLabRptAgainstLotNo
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
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvLabReport = New Telerik.WinControls.UI.RadGridView()
        CType(Me.dgvLabReport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLabReport.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLabReport
        '
        Me.dgvLabReport.BackColor = System.Drawing.SystemColors.Control
        Me.dgvLabReport.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLabReport.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvLabReport.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLabReport.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLabReport.Location = New System.Drawing.Point(2, 1)
        '
        '
        '
        Me.dgvLabReport.MasterTemplate.AllowAddNewRow = False
        Me.dgvLabReport.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "LabName"
        GridViewTextBoxColumn1.HeaderText = "Lab Name"
        GridViewTextBoxColumn1.MinWidth = 6
        GridViewTextBoxColumn1.Name = "colLabName"
        GridViewTextBoxColumn1.Width = 190
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "Lot No"
        GridViewTextBoxColumn2.MinWidth = 6
        GridViewTextBoxColumn2.Name = "colLotNo"
        GridViewTextBoxColumn2.Width = 105
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "LabourName"
        GridViewTextBoxColumn3.HeaderText = "Labour Name"
        GridViewTextBoxColumn3.MinWidth = 6
        GridViewTextBoxColumn3.Name = "colLabourName"
        GridViewTextBoxColumn3.Width = 157
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "OperationName"
        GridViewTextBoxColumn4.HeaderText = "Operation"
        GridViewTextBoxColumn4.MinWidth = 6
        GridViewTextBoxColumn4.Name = "colOperationName"
        GridViewTextBoxColumn4.Width = 128
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ReceivePr"
        GridViewTextBoxColumn5.HeaderText = "Receive [%]"
        GridViewTextBoxColumn5.MinWidth = 6
        GridViewTextBoxColumn5.Name = "colReceivePr"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 105
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "LabReport"
        GridViewTextBoxColumn6.HeaderText = "Lab Report"
        GridViewTextBoxColumn6.MinWidth = 6
        GridViewTextBoxColumn6.Name = "colLabReport"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 105
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "SampleWt"
        GridViewTextBoxColumn7.HeaderText = "Sample Wt."
        GridViewTextBoxColumn7.MinWidth = 6
        GridViewTextBoxColumn7.Name = "colSampleWt"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 105
        Me.dgvLabReport.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7})
        Me.dgvLabReport.MasterTemplate.EnableGrouping = False
        Me.dgvLabReport.MasterTemplate.EnableSorting = False
        Me.dgvLabReport.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvLabReport.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvLabReport.Name = "dgvLabReport"
        Me.dgvLabReport.ReadOnly = True
        Me.dgvLabReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLabReport.Size = New System.Drawing.Size(892, 353)
        Me.dgvLabReport.TabIndex = 0
        '
        'frmLabRptAgainstLotNo
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(897, 353)
        Me.Controls.Add(Me.dgvLabReport)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmLabRptAgainstLotNo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lab Report Against Lot No."
        CType(Me.dgvLabReport.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLabReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvLabReport As Telerik.WinControls.UI.RadGridView
    Friend WithEvents MasterTemplate As Telerik.WinControls.UI.RadGridView
End Class
