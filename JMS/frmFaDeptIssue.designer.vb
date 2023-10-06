<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFaDeptIssue
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
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvDeptIssue = New Telerik.WinControls.UI.RadGridView()
        Me.BtnPrint = New Telerik.WinControls.UI.RadButton()
        Me.BtnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvDeptIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDeptIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDeptIssue
        '
        Me.dgvDeptIssue.BackColor = System.Drawing.SystemColors.Control
        Me.dgvDeptIssue.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvDeptIssue.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvDeptIssue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDeptIssue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvDeptIssue.Location = New System.Drawing.Point(0, 0)
        '
        '
        '
        Me.dgvDeptIssue.MasterTemplate.AllowAddNewRow = False
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "IssueDt"
        GridViewTextBoxColumn8.HeaderText = "IssueDt"
        GridViewTextBoxColumn8.Name = "colIssueDt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn8.Width = 82
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "VoucherNo"
        GridViewTextBoxColumn9.HeaderText = "VoucherNo"
        GridViewTextBoxColumn9.Name = "colVoucherNo"
        GridViewTextBoxColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn9.Width = 122
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "ItemType"
        GridViewTextBoxColumn10.HeaderText = "ItemType"
        GridViewTextBoxColumn10.Name = "colItemType"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn10.Width = 122
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "SlipBagNo"
        GridViewTextBoxColumn11.HeaderText = "SlipBagNo"
        GridViewTextBoxColumn11.Name = "colSlipBagNo"
        GridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn11.Width = 93
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "IssueWt"
        GridViewTextBoxColumn12.HeaderText = "IssueWt"
        GridViewTextBoxColumn12.Name = "colIssueWt"
        GridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn12.Width = 105
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "IssuePr"
        GridViewTextBoxColumn13.HeaderText = "Issue%"
        GridViewTextBoxColumn13.Name = "colIssuePr"
        GridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn13.Width = 93
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "FineWt"
        GridViewTextBoxColumn14.HeaderText = "FineWt"
        GridViewTextBoxColumn14.Name = "colFineWt"
        GridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn14.Width = 93
        Me.dgvDeptIssue.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14})
        Me.dgvDeptIssue.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvDeptIssue.Name = "dgvDeptIssue"
        Me.dgvDeptIssue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvDeptIssue.Size = New System.Drawing.Size(799, 419)
        Me.dgvDeptIssue.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Location = New System.Drawing.Point(340, 450)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 25)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "&Print"
        '
        'BtnExit
        '
        Me.BtnExit.Location = New System.Drawing.Point(421, 450)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 25)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "E&xit"
        '
        'frmDeptIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 517)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.dgvDeptIssue)
        Me.Name = "frmDeptIssue"
        Me.Text = "frmDeptIssue"
        CType(Me.dgvDeptIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDeptIssue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvDeptIssue As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BtnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnExit As Telerik.WinControls.UI.RadButton
End Class
