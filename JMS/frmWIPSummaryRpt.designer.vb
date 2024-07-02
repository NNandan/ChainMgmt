<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmWIPSummaryRpt
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
        Dim GridViewTextBoxColumn19 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn20 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn21 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn22 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn23 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn24 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn25 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn26 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn27 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim SortDescriptor3 As Telerik.WinControls.Data.SortDescriptor = New Telerik.WinControls.Data.SortDescriptor()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.grpBoxMain = New System.Windows.Forms.GroupBox()
        Me.rdgvWipSummary = New Telerik.WinControls.UI.RadGridView()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.grpBoxMain.SuspendLayout()
        CType(Me.rdgvWipSummary, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdgvWipSummary.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBoxMain
        '
        Me.grpBoxMain.Controls.Add(Me.rdgvWipSummary)
        Me.grpBoxMain.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grpBoxMain.Location = New System.Drawing.Point(5, 3)
        Me.grpBoxMain.Name = "grpBoxMain"
        Me.grpBoxMain.Size = New System.Drawing.Size(880, 415)
        Me.grpBoxMain.TabIndex = 0
        Me.grpBoxMain.TabStop = False
        Me.grpBoxMain.Text = "WIP Summary"
        '
        'rdgvWipSummary
        '
        Me.rdgvWipSummary.BackColor = System.Drawing.SystemColors.Control
        Me.rdgvWipSummary.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdgvWipSummary.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.rdgvWipSummary.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdgvWipSummary.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdgvWipSummary.Location = New System.Drawing.Point(5, 24)
        '
        '
        '
        Me.rdgvWipSummary.MasterTemplate.AllowAddNewRow = False
        Me.rdgvWipSummary.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn19.EnableExpressionEditor = False
        GridViewTextBoxColumn19.FieldName = "LotNo"
        GridViewTextBoxColumn19.HeaderText = "Lot No"
        GridViewTextBoxColumn19.Name = "colLotNumber"
        GridViewTextBoxColumn19.Width = 77
        GridViewTextBoxColumn20.EnableExpressionEditor = False
        GridViewTextBoxColumn20.FieldName = "LabourName"
        GridViewTextBoxColumn20.HeaderText = "Labour Name"
        GridViewTextBoxColumn20.Name = "colLabourName"
        GridViewTextBoxColumn20.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending
        GridViewTextBoxColumn20.Width = 140
        GridViewTextBoxColumn21.EnableExpressionEditor = False
        GridViewTextBoxColumn21.FieldName = "MeltingValue"
        GridViewTextBoxColumn21.HeaderText = "Melting %"
        GridViewTextBoxColumn21.Name = "colMeltingValue"
        GridViewTextBoxColumn21.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn21.Width = 80
        GridViewTextBoxColumn22.EnableExpressionEditor = False
        GridViewTextBoxColumn22.FieldName = "OperationName"
        GridViewTextBoxColumn22.HeaderText = "Operation Name"
        GridViewTextBoxColumn22.Name = "colOperationName"
        GridViewTextBoxColumn22.Width = 125
        GridViewTextBoxColumn23.EnableExpressionEditor = False
        GridViewTextBoxColumn23.FieldName = "IssueWt"
        GridViewTextBoxColumn23.HeaderText = "Issue Wt."
        GridViewTextBoxColumn23.Name = "colIssueWt"
        GridViewTextBoxColumn23.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn23.Width = 90
        GridViewTextBoxColumn24.EnableExpressionEditor = False
        GridViewTextBoxColumn24.FieldName = "ReceiveWt"
        GridViewTextBoxColumn24.HeaderText = "Receive Wt."
        GridViewTextBoxColumn24.Name = "colReceiveWt"
        GridViewTextBoxColumn24.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn24.Width = 90
        GridViewTextBoxColumn25.EnableExpressionEditor = False
        GridViewTextBoxColumn25.FieldName = "BalanceWt"
        GridViewTextBoxColumn25.HeaderText = "Balance Wt."
        GridViewTextBoxColumn25.Name = "colBalanceWt"
        GridViewTextBoxColumn25.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn25.Width = 90
        GridViewTextBoxColumn26.EnableExpressionEditor = False
        GridViewTextBoxColumn26.FieldName = "BoxWeight"
        GridViewTextBoxColumn26.HeaderText = "Box Wt."
        GridViewTextBoxColumn26.Name = "colBoxWt"
        GridViewTextBoxColumn26.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn26.Width = 90
        GridViewTextBoxColumn27.EnableExpressionEditor = False
        GridViewTextBoxColumn27.FieldName = "TotalWt"
        GridViewTextBoxColumn27.HeaderText = "Total Wt."
        GridViewTextBoxColumn27.Name = "colTotalWt"
        GridViewTextBoxColumn27.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn27.Width = 90
        Me.rdgvWipSummary.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn19, GridViewTextBoxColumn20, GridViewTextBoxColumn21, GridViewTextBoxColumn22, GridViewTextBoxColumn23, GridViewTextBoxColumn24, GridViewTextBoxColumn25, GridViewTextBoxColumn26, GridViewTextBoxColumn27})
        Me.rdgvWipSummary.MasterTemplate.EnableGrouping = False
        Me.rdgvWipSummary.MasterTemplate.ShowRowHeaderColumn = False
        SortDescriptor3.PropertyName = "colLabourName"
        Me.rdgvWipSummary.MasterTemplate.SortDescriptors.AddRange(New Telerik.WinControls.Data.SortDescriptor() {SortDescriptor3})
        Me.rdgvWipSummary.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.rdgvWipSummary.Name = "rdgvWipSummary"
        Me.rdgvWipSummary.ReadOnly = True
        Me.rdgvWipSummary.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdgvWipSummary.Size = New System.Drawing.Size(874, 381)
        Me.rdgvWipSummary.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(373, 427)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(450, 427)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "E&xit"
        '
        'frmWIPSummaryRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(889, 459)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.grpBoxMain)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmWIPSummaryRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WIP Summary"
        Me.grpBoxMain.ResumeLayout(False)
        CType(Me.rdgvWipSummary.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdgvWipSummary, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents grpBoxMain As GroupBox
    Friend WithEvents rdgvWipSummary As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
