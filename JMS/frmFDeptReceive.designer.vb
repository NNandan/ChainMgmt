<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFDeptReceive
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvDeptReceive = New Telerik.WinControls.UI.RadGridView()
        Me.BtnPrint = New Telerik.WinControls.UI.RadButton()
        Me.BtnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvDeptReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDeptReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDeptReceive
        '
        Me.dgvDeptReceive.BackColor = System.Drawing.SystemColors.Control
        Me.dgvDeptReceive.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvDeptReceive.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvDeptReceive.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvDeptReceive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvDeptReceive.Location = New System.Drawing.Point(1, 0)
        '
        '
        '
        Me.dgvDeptReceive.MasterTemplate.AllowAddNewRow = False
        Me.dgvDeptReceive.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "TransDt"
        GridViewTextBoxColumn1.HeaderText = "Trans Dt."
        GridViewTextBoxColumn1.MinWidth = 6
        GridViewTextBoxColumn1.Name = "colTransactionDt"
        GridViewTextBoxColumn1.Width = 90
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "VoucherNo"
        GridViewTextBoxColumn2.HeaderText = "VoucherNo"
        GridViewTextBoxColumn2.MinWidth = 6
        GridViewTextBoxColumn2.Name = "colVoucherNo"
        GridViewTextBoxColumn2.Width = 100
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemName"
        GridViewTextBoxColumn3.HeaderText = "ItemName"
        GridViewTextBoxColumn3.MinWidth = 6
        GridViewTextBoxColumn3.Name = "colItemName"
        GridViewTextBoxColumn3.Width = 150
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ReceiveWt"
        GridViewTextBoxColumn4.HeaderText = "ReceiveWt"
        GridViewTextBoxColumn4.MinWidth = 6
        GridViewTextBoxColumn4.Name = "colReceiveWt"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 90
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ReceivePr"
        GridViewTextBoxColumn5.HeaderText = "Receive [%]"
        GridViewTextBoxColumn5.MinWidth = 6
        GridViewTextBoxColumn5.Name = "colReceivePr"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 90
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "FineWt"
        GridViewTextBoxColumn6.HeaderText = "FineWt"
        GridViewTextBoxColumn6.MinWidth = 6
        GridViewTextBoxColumn6.Name = "colFineWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 90
        Me.dgvDeptReceive.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.dgvDeptReceive.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvDeptReceive.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvDeptReceive.Name = "dgvDeptReceive"
        Me.dgvDeptReceive.ReadOnly = True
        Me.dgvDeptReceive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvDeptReceive.Size = New System.Drawing.Size(609, 380)
        Me.dgvDeptReceive.TabIndex = 0
        '
        'BtnPrint
        '
        Me.BtnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnPrint.Location = New System.Drawing.Point(240, 383)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(75, 25)
        Me.BtnPrint.TabIndex = 1
        Me.BtnPrint.Text = "&Print"
        '
        'BtnExit
        '
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnExit.Location = New System.Drawing.Point(316, 383)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 25)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "E&xit"
        '
        'frmFDeptReceive
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(611, 411)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnPrint)
        Me.Controls.Add(Me.dgvDeptReceive)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.Name = "frmFDeptReceive"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDeptReceive"
        CType(Me.dgvDeptReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDeptReceive, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvDeptReceive As Telerik.WinControls.UI.RadGridView
    Friend WithEvents BtnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnExit As Telerik.WinControls.UI.RadButton
End Class
