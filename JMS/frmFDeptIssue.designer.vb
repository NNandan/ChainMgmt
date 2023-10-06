<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFDeptIssue
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
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
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
        Me.dgvDeptIssue.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvDeptIssue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDeptIssue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvDeptIssue.Location = New System.Drawing.Point(2, 1)
        '
        '
        '
        Me.dgvDeptIssue.MasterTemplate.AllowAddNewRow = False
        Me.dgvDeptIssue.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "IssueDt"
        GridViewTextBoxColumn1.HeaderText = "IssueDt"
        GridViewTextBoxColumn1.MinWidth = 6
        GridViewTextBoxColumn1.Name = "colIssueDt"
        GridViewTextBoxColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn1.Width = 100
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "VoucherNo"
        GridViewTextBoxColumn2.HeaderText = "VoucherNo"
        GridViewTextBoxColumn2.MinWidth = 6
        GridViewTextBoxColumn2.Name = "colVoucherNo"
        GridViewTextBoxColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn2.Width = 110
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemType"
        GridViewTextBoxColumn3.HeaderText = "ItemType"
        GridViewTextBoxColumn3.MinWidth = 6
        GridViewTextBoxColumn3.Name = "colItemType"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn3.Width = 120
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "SlipBagNo"
        GridViewTextBoxColumn4.HeaderText = "Slip Bag No"
        GridViewTextBoxColumn4.MinWidth = 6
        GridViewTextBoxColumn4.Name = "colSlipBagNo"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn4.Width = 110
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "IssueWt"
        GridViewTextBoxColumn5.HeaderText = "IssueWt"
        GridViewTextBoxColumn5.MinWidth = 6
        GridViewTextBoxColumn5.Name = "colIssueWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 90
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "IssuePr"
        GridViewTextBoxColumn6.HeaderText = "Issue [%]"
        GridViewTextBoxColumn6.MinWidth = 6
        GridViewTextBoxColumn6.Name = "colIssuePr"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn6.Width = 90
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "FineWt"
        GridViewTextBoxColumn7.HeaderText = "FineWt"
        GridViewTextBoxColumn7.MinWidth = 6
        GridViewTextBoxColumn7.Name = "colFineWt"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn7.Width = 90
        Me.dgvDeptIssue.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7})
        Me.dgvDeptIssue.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvDeptIssue.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvDeptIssue.Name = "dgvDeptIssue"
        Me.dgvDeptIssue.ReadOnly = True
        Me.dgvDeptIssue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvDeptIssue.Size = New System.Drawing.Size(706, 451)
        Me.dgvDeptIssue.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnPrint.Location = New System.Drawing.Point(283, 458)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 25)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "&Print"
        '
        'BtnExit
        '
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnExit.Location = New System.Drawing.Point(360, 458)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 25)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "E&xit"
        '
        'frmFDeptIssue
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(709, 487)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.dgvDeptIssue)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.Name = "frmFDeptIssue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
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
