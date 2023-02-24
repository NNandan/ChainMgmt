<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScrapReceiveRpt
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
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn3 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn4 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn5 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn6 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn7 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewDecimalColumn8 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim GridViewTextBoxColumn13 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn14 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn15 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn9 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn16 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition4 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.tbScrapReport = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvAll = New Telerik.WinControls.UI.RadGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvAgainstSpecificLot = New Telerik.WinControls.UI.RadGridView()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.dgvAgainstSpecificOpMLot = New Telerik.WinControls.UI.RadGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.dgvAgainstMOp = New Telerik.WinControls.UI.RadGridView()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.tbScrapReport.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAll.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvAgainstSpecificLot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAgainstSpecificLot.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvAgainstSpecificOpMLot, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAgainstSpecificOpMLot.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.dgvAgainstMOp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAgainstMOp.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbScrapReport
        '
        Me.tbScrapReport.Controls.Add(Me.TabPage1)
        Me.tbScrapReport.Controls.Add(Me.TabPage2)
        Me.tbScrapReport.Controls.Add(Me.TabPage3)
        Me.tbScrapReport.Controls.Add(Me.TabPage4)
        Me.tbScrapReport.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.tbScrapReport.Location = New System.Drawing.Point(0, 0)
        Me.tbScrapReport.Margin = New System.Windows.Forms.Padding(5)
        Me.tbScrapReport.Name = "tbScrapReport"
        Me.tbScrapReport.SelectedIndex = 0
        Me.tbScrapReport.Size = New System.Drawing.Size(778, 410)
        Me.tbScrapReport.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.dgvAll)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Size = New System.Drawing.Size(770, 383)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "All"
        '
        'dgvAll
        '
        Me.dgvAll.BackColor = System.Drawing.SystemColors.Control
        Me.dgvAll.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvAll.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvAll.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvAll.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvAll.Location = New System.Drawing.Point(0, 3)
        '
        '
        '
        Me.dgvAll.MasterTemplate.AllowAddNewRow = False
        Me.dgvAll.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "ExtraScrapDt"
        GridViewTextBoxColumn1.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn1.HeaderText = "Trans Dt."
        GridViewTextBoxColumn1.Name = "colTransactionDt"
        GridViewTextBoxColumn1.Width = 100
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "Lot No"
        GridViewTextBoxColumn2.Name = "colLotNumber"
        GridViewTextBoxColumn2.Width = 88
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "OperationName"
        GridViewTextBoxColumn3.HeaderText = "Operation Name"
        GridViewTextBoxColumn3.Name = "colOperationName"
        GridViewTextBoxColumn3.Width = 225
        GridViewDecimalColumn1.AllowFiltering = False
        GridViewDecimalColumn1.AllowGroup = False
        GridViewDecimalColumn1.EnableExpressionEditor = False
        GridViewDecimalColumn1.FieldName = "GrossWt"
        GridViewDecimalColumn1.FormatString = "{0:F2}"
        GridViewDecimalColumn1.HeaderText = "Gross Wt"
        GridViewDecimalColumn1.Name = "colGrossWt"
        GridViewDecimalColumn1.Width = 94
        GridViewDecimalColumn2.AllowFiltering = False
        GridViewDecimalColumn2.AllowGroup = False
        GridViewDecimalColumn2.EnableExpressionEditor = False
        GridViewDecimalColumn2.FieldName = "GrossPr"
        GridViewDecimalColumn2.FormatString = "{0:F2}"
        GridViewDecimalColumn2.HeaderText = "Gross %"
        GridViewDecimalColumn2.Name = "colGrossPr"
        GridViewDecimalColumn2.Width = 77
        GridViewDecimalColumn3.AllowFiltering = False
        GridViewDecimalColumn3.AllowGroup = False
        GridViewDecimalColumn3.EnableExpressionEditor = False
        GridViewDecimalColumn3.FieldName = "FineWt"
        GridViewDecimalColumn3.FormatString = "{0:F2}"
        GridViewDecimalColumn3.HeaderText = "Fine Wt."
        GridViewDecimalColumn3.Name = "colFineWt"
        GridViewDecimalColumn3.Width = 85
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "LabourName"
        GridViewTextBoxColumn4.HeaderText = "Labour Name"
        GridViewTextBoxColumn4.Name = "colKarigarName"
        GridViewTextBoxColumn4.Width = 100
        Me.dgvAll.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewDecimalColumn1, GridViewDecimalColumn2, GridViewDecimalColumn3, GridViewTextBoxColumn4})
        Me.dgvAll.MasterTemplate.EnableGrouping = False
        Me.dgvAll.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvAll.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvAll.Name = "dgvAll"
        Me.dgvAll.ReadOnly = True
        Me.dgvAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvAll.Size = New System.Drawing.Size(770, 382)
        Me.dgvAll.TabIndex = 5
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvAgainstSpecificLot)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(770, 383)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Against Specific Lot"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvAgainstSpecificLot
        '
        Me.dgvAgainstSpecificLot.BackColor = System.Drawing.SystemColors.Control
        Me.dgvAgainstSpecificLot.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvAgainstSpecificLot.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvAgainstSpecificLot.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvAgainstSpecificLot.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvAgainstSpecificLot.Location = New System.Drawing.Point(0, 3)
        '
        '
        '
        Me.dgvAgainstSpecificLot.MasterTemplate.AllowAddNewRow = False
        Me.dgvAgainstSpecificLot.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ExtraScrapDt"
        GridViewTextBoxColumn5.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn5.HeaderText = "Trans Dt."
        GridViewTextBoxColumn5.Name = "colTransactionDt"
        GridViewTextBoxColumn5.Width = 100
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "OperationName"
        GridViewTextBoxColumn6.HeaderText = "Operation Name"
        GridViewTextBoxColumn6.Name = "colOperationName"
        GridViewTextBoxColumn6.Width = 158
        GridViewDecimalColumn4.AllowFiltering = False
        GridViewDecimalColumn4.AllowGroup = False
        GridViewDecimalColumn4.EnableExpressionEditor = False
        GridViewDecimalColumn4.FieldName = "LotNo"
        GridViewDecimalColumn4.FormatString = "{0:F2}"
        GridViewDecimalColumn4.HeaderText = "Lot No"
        GridViewDecimalColumn4.Name = "colLotNo"
        GridViewDecimalColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft
        GridViewDecimalColumn4.Width = 94
        GridViewDecimalColumn5.AllowFiltering = False
        GridViewDecimalColumn5.AllowGroup = False
        GridViewDecimalColumn5.EnableExpressionEditor = False
        GridViewDecimalColumn5.FieldName = "GrossWt"
        GridViewDecimalColumn5.FormatString = "{0:F2}"
        GridViewDecimalColumn5.HeaderText = "Gross Wt"
        GridViewDecimalColumn5.Name = "colGrossWt"
        GridViewDecimalColumn5.Width = 77
        GridViewDecimalColumn6.AllowFiltering = False
        GridViewDecimalColumn6.AllowGroup = False
        GridViewDecimalColumn6.EnableExpressionEditor = False
        GridViewDecimalColumn6.FieldName = "GrossPr"
        GridViewDecimalColumn6.FormatString = "{0:F2}"
        GridViewDecimalColumn6.HeaderText = "Gross %"
        GridViewDecimalColumn6.Name = "colGrossPr"
        GridViewDecimalColumn6.Width = 81
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "FineWt"
        GridViewTextBoxColumn7.HeaderText = "Fine Wt."
        GridViewTextBoxColumn7.Name = "colFineWt"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 80
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "LabourName"
        GridViewTextBoxColumn8.HeaderText = "Labour Name"
        GridViewTextBoxColumn8.Name = "colKarigarName"
        GridViewTextBoxColumn8.Width = 100
        Me.dgvAgainstSpecificLot.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewDecimalColumn4, GridViewDecimalColumn5, GridViewDecimalColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8})
        Me.dgvAgainstSpecificLot.MasterTemplate.EnableGrouping = False
        Me.dgvAgainstSpecificLot.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvAgainstSpecificLot.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.dgvAgainstSpecificLot.Name = "dgvAgainstSpecificLot"
        Me.dgvAgainstSpecificLot.ReadOnly = True
        Me.dgvAgainstSpecificLot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvAgainstSpecificLot.Size = New System.Drawing.Size(770, 382)
        Me.dgvAgainstSpecificLot.TabIndex = 6
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.dgvAgainstSpecificOpMLot)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(770, 383)
        Me.TabPage3.TabIndex = 3
        Me.TabPage3.Text = "Against Specific Operation Multiple Lots"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'dgvAgainstSpecificOpMLot
        '
        Me.dgvAgainstSpecificOpMLot.BackColor = System.Drawing.SystemColors.Control
        Me.dgvAgainstSpecificOpMLot.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvAgainstSpecificOpMLot.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvAgainstSpecificOpMLot.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvAgainstSpecificOpMLot.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvAgainstSpecificOpMLot.Location = New System.Drawing.Point(0, 3)
        '
        '
        '
        Me.dgvAgainstSpecificOpMLot.MasterTemplate.AllowAddNewRow = False
        Me.dgvAgainstSpecificOpMLot.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "ExtraScrapDt"
        GridViewTextBoxColumn9.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn9.HeaderText = "Trans Dt."
        GridViewTextBoxColumn9.Name = "colTransactionDt"
        GridViewTextBoxColumn9.Width = 110
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "OperationName"
        GridViewTextBoxColumn10.HeaderText = "Operation Name"
        GridViewTextBoxColumn10.Name = "colOperationName"
        GridViewTextBoxColumn10.Width = 120
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "GrossWt"
        GridViewTextBoxColumn11.HeaderText = "Gross Wt."
        GridViewTextBoxColumn11.Name = "colGrossWt"
        GridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn11.Width = 90
        GridViewDecimalColumn7.AllowFiltering = False
        GridViewDecimalColumn7.AllowGroup = False
        GridViewDecimalColumn7.EnableExpressionEditor = False
        GridViewDecimalColumn7.FieldName = "GrossPr"
        GridViewDecimalColumn7.FormatString = "{0:F2}"
        GridViewDecimalColumn7.HeaderText = "Gross %"
        GridViewDecimalColumn7.Name = "colGrossPr"
        GridViewDecimalColumn7.Width = 90
        GridViewDecimalColumn8.AllowFiltering = False
        GridViewDecimalColumn8.AllowGroup = False
        GridViewDecimalColumn8.EnableExpressionEditor = False
        GridViewDecimalColumn8.FieldName = "FineWt"
        GridViewDecimalColumn8.FormatString = "{0:F2}"
        GridViewDecimalColumn8.HeaderText = "Fine Wt."
        GridViewDecimalColumn8.Name = "colFineWt"
        GridViewDecimalColumn8.Width = 90
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "LabourName"
        GridViewTextBoxColumn12.HeaderText = "Labour Name"
        GridViewTextBoxColumn12.Name = "colLabourName"
        GridViewTextBoxColumn12.Width = 120
        Me.dgvAgainstSpecificOpMLot.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewDecimalColumn7, GridViewDecimalColumn8, GridViewTextBoxColumn12})
        Me.dgvAgainstSpecificOpMLot.MasterTemplate.EnableGrouping = False
        Me.dgvAgainstSpecificOpMLot.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvAgainstSpecificOpMLot.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.dgvAgainstSpecificOpMLot.Name = "dgvAgainstSpecificOpMLot"
        Me.dgvAgainstSpecificOpMLot.ReadOnly = True
        Me.dgvAgainstSpecificOpMLot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvAgainstSpecificOpMLot.Size = New System.Drawing.Size(770, 383)
        Me.dgvAgainstSpecificOpMLot.TabIndex = 5
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.dgvAgainstMOp)
        Me.TabPage4.Location = New System.Drawing.Point(4, 23)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(770, 383)
        Me.TabPage4.TabIndex = 2
        Me.TabPage4.Text = "Against Multiple Operations"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'dgvAgainstMOp
        '
        Me.dgvAgainstMOp.BackColor = System.Drawing.SystemColors.Control
        Me.dgvAgainstMOp.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvAgainstMOp.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvAgainstMOp.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvAgainstMOp.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvAgainstMOp.Location = New System.Drawing.Point(0, 3)
        '
        '
        '
        Me.dgvAgainstMOp.MasterTemplate.AllowAddNewRow = False
        Me.dgvAgainstMOp.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn13.EnableExpressionEditor = False
        GridViewTextBoxColumn13.FieldName = "ExtraScrapDt"
        GridViewTextBoxColumn13.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn13.HeaderText = "Trans Dt."
        GridViewTextBoxColumn13.Name = "colTransactionDt"
        GridViewTextBoxColumn13.Width = 125
        GridViewTextBoxColumn14.EnableExpressionEditor = False
        GridViewTextBoxColumn14.FieldName = "GrossWt"
        GridViewTextBoxColumn14.HeaderText = "Gross Wt."
        GridViewTextBoxColumn14.Name = "colGrossWt"
        GridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn14.Width = 90
        GridViewTextBoxColumn15.EnableExpressionEditor = False
        GridViewTextBoxColumn15.FieldName = "GrossPr"
        GridViewTextBoxColumn15.HeaderText = "Gross %"
        GridViewTextBoxColumn15.Name = "colGrossPr"
        GridViewTextBoxColumn15.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn15.Width = 90
        GridViewDecimalColumn9.AllowFiltering = False
        GridViewDecimalColumn9.AllowGroup = False
        GridViewDecimalColumn9.EnableExpressionEditor = False
        GridViewDecimalColumn9.FieldName = "FineWt"
        GridViewDecimalColumn9.FormatString = "{0:F2}"
        GridViewDecimalColumn9.HeaderText = "Fine Wt"
        GridViewDecimalColumn9.Name = "colFineWt"
        GridViewDecimalColumn9.Width = 90
        GridViewTextBoxColumn16.EnableExpressionEditor = False
        GridViewTextBoxColumn16.FieldName = "LabourName"
        GridViewTextBoxColumn16.HeaderText = "Labour Name"
        GridViewTextBoxColumn16.Name = "colLabourName"
        GridViewTextBoxColumn16.Width = 120
        Me.dgvAgainstMOp.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn13, GridViewTextBoxColumn14, GridViewTextBoxColumn15, GridViewDecimalColumn9, GridViewTextBoxColumn16})
        Me.dgvAgainstMOp.MasterTemplate.EnableGrouping = False
        Me.dgvAgainstMOp.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvAgainstMOp.MasterTemplate.ViewDefinition = TableViewDefinition4
        Me.dgvAgainstMOp.Name = "dgvAgainstMOp"
        Me.dgvAgainstMOp.ReadOnly = True
        Me.dgvAgainstMOp.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvAgainstMOp.Size = New System.Drawing.Size(770, 383)
        Me.dgvAgainstMOp.TabIndex = 5
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(390, 415)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 28
        Me.btnExit.Text = "E&xit"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(313, 415)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 27
        Me.btnPrint.Text = "&Print"
        '
        'frmScrapReceiveRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(778, 443)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.tbScrapReport)
        Me.Font = New System.Drawing.Font("Tahoma", 14.25!)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.Name = "frmScrapReceiveRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Extra Scrap Receive Report"
        Me.tbScrapReport.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvAll.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvAgainstSpecificLot.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAgainstSpecificLot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.dgvAgainstSpecificOpMLot.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAgainstSpecificOpMLot, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.dgvAgainstMOp.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAgainstMOp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tbScrapReport As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvAll As Telerik.WinControls.UI.RadGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvAgainstSpecificLot As Telerik.WinControls.UI.RadGridView
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents dgvAgainstMOp As Telerik.WinControls.UI.RadGridView
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents dgvAgainstSpecificOpMLot As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
End Class
