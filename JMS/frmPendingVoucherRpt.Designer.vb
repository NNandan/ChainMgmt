<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendingBags
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
        Dim GridViewDecimalColumn1 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewDecimalColumn2 As Telerik.WinControls.UI.GridViewDecimalColumn = New Telerik.WinControls.UI.GridViewDecimalColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvMeltingBagList = New Telerik.WinControls.UI.RadGridView()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvMeltingBagList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMeltingBagList.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMeltingBagList
        '
        Me.dgvMeltingBagList.BackColor = System.Drawing.SystemColors.Control
        Me.dgvMeltingBagList.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvMeltingBagList.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvMeltingBagList.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMeltingBagList.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvMeltingBagList.Location = New System.Drawing.Point(4, 0)
        '
        '
        '
        Me.dgvMeltingBagList.MasterTemplate.AllowAddNewRow = False
        Me.dgvMeltingBagList.MasterTemplate.AllowColumnReorder = False
        Me.dgvMeltingBagList.MasterTemplate.AllowDeleteRow = False
        Me.dgvMeltingBagList.MasterTemplate.AllowEditRow = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "UsedBagDt"
        GridViewTextBoxColumn1.HeaderText = "Used Bag Dt."
        GridViewTextBoxColumn1.Name = "colUsedBagDt"
        GridViewTextBoxColumn1.Width = 100
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "BagSrNo"
        GridViewTextBoxColumn2.HeaderText = "Bag Sr#"
        GridViewTextBoxColumn2.Name = "colBagSrNo"
        GridViewTextBoxColumn2.Width = 110
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemName"
        GridViewTextBoxColumn3.HeaderText = "Item Name"
        GridViewTextBoxColumn3.Name = "colItemName"
        GridViewTextBoxColumn3.Width = 160
        GridViewDecimalColumn1.AllowFiltering = False
        GridViewDecimalColumn1.AllowGroup = False
        GridViewDecimalColumn1.EnableExpressionEditor = False
        GridViewDecimalColumn1.FieldName = "LotNumber"
        GridViewDecimalColumn1.FormatString = "{0:F2}"
        GridViewDecimalColumn1.HeaderText = "Lot No."
        GridViewDecimalColumn1.IsVisible = False
        GridViewDecimalColumn1.Name = "colUsedInLotNo"
        GridViewDecimalColumn1.Width = 120
        GridViewTextBoxColumn4.AllowFiltering = False
        GridViewTextBoxColumn4.AllowGroup = False
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ReceiveWt"
        GridViewTextBoxColumn4.FormatString = "{0:F2}"
        GridViewTextBoxColumn4.HeaderText = "Recieve Wt."
        GridViewTextBoxColumn4.Name = "colRecieveWt"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 100
        GridViewDecimalColumn2.AllowFiltering = False
        GridViewDecimalColumn2.AllowGroup = False
        GridViewDecimalColumn2.EnableExpressionEditor = False
        GridViewDecimalColumn2.FieldName = "ReportPr"
        GridViewDecimalColumn2.FormatString = "{0:F2}"
        GridViewDecimalColumn2.HeaderText = "Receive [%]"
        GridViewDecimalColumn2.Name = "colReportPr"
        GridViewDecimalColumn2.Width = 100
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "BalanceWt"
        GridViewTextBoxColumn5.HeaderText = "Balance Wt."
        GridViewTextBoxColumn5.Name = "colBalanceWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 100
        Me.dgvMeltingBagList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewDecimalColumn1, GridViewTextBoxColumn4, GridViewDecimalColumn2, GridViewTextBoxColumn5})
        Me.dgvMeltingBagList.MasterTemplate.EnableGrouping = False
        Me.dgvMeltingBagList.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvMeltingBagList.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvMeltingBagList.Name = "dgvMeltingBagList"
        Me.dgvMeltingBagList.ReadOnly = True
        Me.dgvMeltingBagList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMeltingBagList.Size = New System.Drawing.Size(667, 302)
        Me.dgvMeltingBagList.TabIndex = 19
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(271, 307)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 20
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(348, 307)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 28
        Me.btnExit.Text = "E&xit"
        '
        'frmPendingBags
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(672, 337)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvMeltingBagList)
        Me.Font = New System.Drawing.Font("Tahoma", 11.25!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPendingBags"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending Bags"
        CType(Me.dgvMeltingBagList.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMeltingBagList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvMeltingBagList As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
