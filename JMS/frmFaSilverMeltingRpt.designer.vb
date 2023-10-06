<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFaSilverMeltingRpt
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
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.grpBoxMain = New System.Windows.Forms.GroupBox()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.dgvSilverRpt = New Telerik.WinControls.UI.RadGridView()
        Me.grpBoxMain.SuspendLayout()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSilverRpt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSilverRpt.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBoxMain
        '
        Me.grpBoxMain.Controls.Add(Me.btnExit)
        Me.grpBoxMain.Controls.Add(Me.btnPrint)
        Me.grpBoxMain.Controls.Add(Me.dgvSilverRpt)
        Me.grpBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpBoxMain.Location = New System.Drawing.Point(3, 3)
        Me.grpBoxMain.Name = "grpBoxMain"
        Me.grpBoxMain.Size = New System.Drawing.Size(738, 433)
        Me.grpBoxMain.TabIndex = 1
        Me.grpBoxMain.TabStop = False
        Me.grpBoxMain.Text = "Silver Melting Report"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(371, 404)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 28
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(294, 404)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 27
        Me.btnPrint.Text = "&Print"
        '
        'dgvSilverRpt
        '
        Me.dgvSilverRpt.BackColor = System.Drawing.SystemColors.Control
        Me.dgvSilverRpt.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvSilverRpt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvSilverRpt.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvSilverRpt.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvSilverRpt.Location = New System.Drawing.Point(4, 18)
        '
        '
        '
        Me.dgvSilverRpt.MasterTemplate.AllowAddNewRow = False
        Me.dgvSilverRpt.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "TransactionDt"
        GridViewTextBoxColumn9.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn9.Name = "colTransactionDt"
        GridViewTextBoxColumn9.Width = 90
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "LotNo"
        GridViewTextBoxColumn10.HeaderText = "Lot No"
        GridViewTextBoxColumn10.Name = "colLotNo"
        GridViewTextBoxColumn10.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn10.Width = 100
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "MeltingPr"
        GridViewTextBoxColumn11.HeaderText = "Melting %"
        GridViewTextBoxColumn11.Name = "colMeltingPr"
        GridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn11.Width = 100
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "GrossWt"
        GridViewTextBoxColumn12.HeaderText = "Gross Wt."
        GridViewTextBoxColumn12.Name = "colGrossWt"
        GridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn12.Width = 90
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "FineWt"
        GridViewTextBoxColumn13.HeaderText = "Fine Wt."
        GridViewTextBoxColumn13.Name = "colFineWt"
        GridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn13.Width = 90
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "AlloyWt"
        GridViewTextBoxColumn14.HeaderText = "Alloy Wt."
        GridViewTextBoxColumn14.Name = "colAlloyWt"
        GridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn14.Width = 90
        GridViewTextBoxColumn15.EnableExpressionEditor = False
        GridViewTextBoxColumn15.FieldName = "SilverPr"
        GridViewTextBoxColumn15.HeaderText = "Silver %"
        GridViewTextBoxColumn15.Name = "colSilverPr"
        GridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn15.Width = 90
        GridViewTextBoxColumn16.EnableExpressionEditor = False
        GridViewTextBoxColumn16.FieldName = "SilverWt"
        GridViewTextBoxColumn16.HeaderText = "Silver Wt."
        GridViewTextBoxColumn16.Name = "colSilverWt"
        GridViewTextBoxColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn16.Width = 90
        Me.dgvSilverRpt.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewTextBoxColumn16})
        Me.dgvSilverRpt.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvSilverRpt.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvSilverRpt.Name = "dgvSilverRpt"
        Me.dgvSilverRpt.ReadOnly = True
        Me.dgvSilverRpt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvSilverRpt.Size = New System.Drawing.Size(734, 377)
        Me.dgvSilverRpt.TabIndex = 1
        '
        'frmSilverMeltingRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(743, 438)
        Me.Controls.Add(Me.grpBoxMain)
        Me.MaximizeBox = False
        Me.Name = "frmSilverMeltingRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Silver Melting Report"
        Me.grpBoxMain.ResumeLayout(False)
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSilverRpt.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSilverRpt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpBoxMain As GroupBox
    Friend WithEvents dgvSilverRpt As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
End Class
