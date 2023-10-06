<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStockWipMelting
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
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn17 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn18 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvWipLotNo = New Telerik.WinControls.UI.RadGridView()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvWipLotNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvWipLotNo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvWipLotNo
        '
        Me.dgvWipLotNo.BackColor = System.Drawing.SystemColors.Control
        Me.dgvWipLotNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvWipLotNo.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvWipLotNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvWipLotNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvWipLotNo.Location = New System.Drawing.Point(3, 2)
        '
        '
        '
        Me.dgvWipLotNo.MasterTemplate.AllowAddNewRow = False
        Me.dgvWipLotNo.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "MeltingDt"
        GridViewTextBoxColumn13.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn13.MinWidth = 6
        GridViewTextBoxColumn13.Name = "colTransDt"
        GridViewTextBoxColumn13.Width = 82
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "LotNo"
        GridViewTextBoxColumn14.HeaderText = "Lot No"
        GridViewTextBoxColumn14.MinWidth = 6
        GridViewTextBoxColumn14.Name = "colLotNumber"
        GridViewTextBoxColumn14.Width = 110
        GridViewTextBoxColumn15.EnableExpressionEditor = False
        GridViewTextBoxColumn15.FieldName = "ItemName"
        GridViewTextBoxColumn15.HeaderText = "Item Name"
        GridViewTextBoxColumn15.MinWidth = 6
        GridViewTextBoxColumn15.Name = "colItemName"
        GridViewTextBoxColumn15.Width = 240
        GridViewTextBoxColumn16.EnableExpressionEditor = False
        GridViewTextBoxColumn16.FieldName = "ReceiveWt"
        GridViewTextBoxColumn16.HeaderText = "Receive Wt."
        GridViewTextBoxColumn16.MinWidth = 6
        GridViewTextBoxColumn16.Name = "colReceiveWt"
        GridViewTextBoxColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn16.Width = 90
        GridViewTextBoxColumn17.EnableExpressionEditor = False
        GridViewTextBoxColumn17.FieldName = "ReceivePr"
        GridViewTextBoxColumn17.HeaderText = "Receive %"
        GridViewTextBoxColumn17.MinWidth = 6
        GridViewTextBoxColumn17.Name = "colReceivePr"
        GridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn17.Width = 90
        GridViewTextBoxColumn18.EnableExpressionEditor = False
        GridViewTextBoxColumn18.FieldName = "FineWt"
        GridViewTextBoxColumn18.HeaderText = "Fine Wt."
        GridViewTextBoxColumn18.MinWidth = 6
        GridViewTextBoxColumn18.Name = "colFineWt"
        GridViewTextBoxColumn18.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn18.Width = 90
        Me.dgvWipLotNo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewTextBoxColumn16, GridViewTextBoxColumn17, GridViewTextBoxColumn18})
        Me.dgvWipLotNo.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvWipLotNo.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.dgvWipLotNo.Name = "dgvWipLotNo"
        Me.dgvWipLotNo.ReadOnly = True
        Me.dgvWipLotNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvWipLotNo.Size = New System.Drawing.Size(700, 420)
        Me.dgvWipLotNo.TabIndex = 4
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(372, 427)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 45
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(295, 427)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 44
        Me.btnPrint.Text = "&Print"
        '
        'frmStockWipMelting
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(704, 457)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvWipLotNo)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.Name = "frmStockWipMelting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "WIP Melting"
        CType(Me.dgvWipLotNo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvWipLotNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvWipLotNo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
End Class
