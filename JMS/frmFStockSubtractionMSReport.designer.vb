<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFStockSubtractionMSReport
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
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn17 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn18 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.rdgvMelting = New Telerik.WinControls.UI.RadGridView()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.rdgvMelting, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdgvMelting.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rdgvMelting
        '
        Me.rdgvMelting.BackColor = System.Drawing.SystemColors.Control
        Me.rdgvMelting.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdgvMelting.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rdgvMelting.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdgvMelting.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdgvMelting.Location = New System.Drawing.Point(4, 1)
        '
        '
        '
        Me.rdgvMelting.MasterTemplate.AllowAddNewRow = False
        Me.rdgvMelting.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "MeltingDt"
        GridViewTextBoxColumn10.HeaderText = "Melting Dt"
        GridViewTextBoxColumn10.Name = "colMeltingDt"
        GridViewTextBoxColumn10.Width = 77
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "LotNo"
        GridViewTextBoxColumn11.HeaderText = "Lot Number"
        GridViewTextBoxColumn11.Name = "colLotNumber"
        GridViewTextBoxColumn11.Width = 90
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "RequirePr"
        GridViewTextBoxColumn12.HeaderText = "%"
        GridViewTextBoxColumn12.Name = "colRequirePr"
        GridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn12.Width = 65
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "ConvertToMelting"
        GridViewTextBoxColumn13.HeaderText = "Converted To"
        GridViewTextBoxColumn13.Name = "colConvertToMelting"
        GridViewTextBoxColumn13.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn13.Width = 100
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "GrossWt"
        GridViewTextBoxColumn14.HeaderText = "Issue Wt."
        GridViewTextBoxColumn14.Name = "colIssueWt"
        GridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn14.Width = 80
        GridViewTextBoxColumn15.EnableExpressionEditor = False
        GridViewTextBoxColumn15.FieldName = "FineWt"
        GridViewTextBoxColumn15.HeaderText = "Issue Fine Wt."
        GridViewTextBoxColumn15.Name = "colIssueWtFine"
        GridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn15.Width = 100
        GridViewTextBoxColumn16.EnableExpressionEditor = False
        GridViewTextBoxColumn16.FieldName = "ConvertedPr"
        GridViewTextBoxColumn16.HeaderText = "% Addition"
        GridViewTextBoxColumn16.Name = "colPercentAdd"
        GridViewTextBoxColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn16.Width = 95
        GridViewTextBoxColumn17.EnableExpressionEditor = False
        GridViewTextBoxColumn17.FieldName = "GrossAddition"
        GridViewTextBoxColumn17.HeaderText = "Stock Add Gross"
        GridViewTextBoxColumn17.Name = "colStockAddGross"
        GridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn17.Width = 120
        GridViewTextBoxColumn18.EnableExpressionEditor = False
        GridViewTextBoxColumn18.FieldName = "FineAdd"
        GridViewTextBoxColumn18.HeaderText = "Stock Add Fine"
        GridViewTextBoxColumn18.Name = "colStockAddFine"
        GridViewTextBoxColumn18.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn18.Width = 120
        Me.rdgvMelting.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12, GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewTextBoxColumn16, GridViewTextBoxColumn17, GridViewTextBoxColumn18})
        Me.rdgvMelting.MasterTemplate.ShowRowHeaderColumn = False
        Me.rdgvMelting.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.rdgvMelting.Name = "rdgvMelting"
        Me.rdgvMelting.ReadOnly = True
        Me.rdgvMelting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdgvMelting.Size = New System.Drawing.Size(840, 382)
        Me.rdgvMelting.TabIndex = 60
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(348, 389)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 62
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(425, 389)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 61
        Me.btnExit.Text = "E&xit"
        '
        'frmStockSubtractionMSReport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(849, 417)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.rdgvMelting)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.Name = "frmStockSubtractionMSReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Subtraction Melting"
        CType(Me.rdgvMelting.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdgvMelting, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rdgvMelting As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
