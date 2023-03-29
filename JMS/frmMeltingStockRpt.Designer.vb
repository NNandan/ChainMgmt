<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMeltingStockRpt
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
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.TelerikMetroTheme1 = New Telerik.WinControls.Themes.TelerikMetroTheme()
        Me.lblMeltingStock = New System.Windows.Forms.Label()
        Me.dgvMeltingStock = New Telerik.WinControls.UI.RadGridView()
        Me.btnShow = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvMeltingStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMeltingStock.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnShow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMeltingStock
        '
        Me.lblMeltingStock.AutoSize = True
        Me.lblMeltingStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeltingStock.Location = New System.Drawing.Point(288, 3)
        Me.lblMeltingStock.Name = "lblMeltingStock"
        Me.lblMeltingStock.Size = New System.Drawing.Size(158, 20)
        Me.lblMeltingStock.TabIndex = 2
        Me.lblMeltingStock.Text = "Melting Stock Report"
        '
        'dgvMeltingStock
        '
        Me.dgvMeltingStock.BackColor = System.Drawing.SystemColors.Control
        Me.dgvMeltingStock.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvMeltingStock.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.dgvMeltingStock.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvMeltingStock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvMeltingStock.Location = New System.Drawing.Point(6, 33)
        '
        '
        '
        Me.dgvMeltingStock.MasterTemplate.AllowAddNewRow = False
        Me.dgvMeltingStock.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "MeltingId"
        GridViewTextBoxColumn1.HeaderText = "Melting Id."
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "colMeltingId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "MeltingDt"
        GridViewTextBoxColumn2.FormatString = "{0:dd/MM/yyyy}"
        GridViewTextBoxColumn2.HeaderText = "Melting Dt."
        GridViewTextBoxColumn2.Name = "colMeltingDt"
        GridViewTextBoxColumn2.Width = 90
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemName"
        GridViewTextBoxColumn3.HeaderText = "ItemName"
        GridViewTextBoxColumn3.Name = "colItemName"
        GridViewTextBoxColumn3.Width = 140
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "LotNumber"
        GridViewTextBoxColumn4.HeaderText = "Lot No."
        GridViewTextBoxColumn4.Name = "colLotNumber"
        GridViewTextBoxColumn4.Width = 90
        GridViewTextBoxColumn5.AllowGroup = False
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ItemType"
        GridViewTextBoxColumn5.HeaderText = "Item Type"
        GridViewTextBoxColumn5.Name = "colItemType"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 120
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "RequirePr"
        GridViewTextBoxColumn6.HeaderText = "Require [%]"
        GridViewTextBoxColumn6.Name = "colRequirePr"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 90
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "GrossWt"
        GridViewTextBoxColumn7.HeaderText = "Gross Wt."
        GridViewTextBoxColumn7.Name = "colGrossWt"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 90
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "ReceiveWt"
        GridViewTextBoxColumn8.HeaderText = "Receive Wt."
        GridViewTextBoxColumn8.Name = "colReceiveWt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 90
        Me.dgvMeltingStock.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8})
        Me.dgvMeltingStock.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvMeltingStock.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvMeltingStock.Name = "dgvMeltingStock"
        Me.dgvMeltingStock.ReadOnly = True
        Me.dgvMeltingStock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMeltingStock.ShowGroupPanel = False
        Me.dgvMeltingStock.Size = New System.Drawing.Size(707, 228)
        Me.dgvMeltingStock.TabIndex = 3
        '
        'btnShow
        '
        Me.btnShow.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnShow.Location = New System.Drawing.Point(325, 265)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 25)
        Me.btnShow.TabIndex = 4
        Me.btnShow.Text = "&Show"
        '
        'frmMeltingStockRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(719, 292)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.dgvMeltingStock)
        Me.Controls.Add(Me.lblMeltingStock)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMeltingStockRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.dgvMeltingStock.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMeltingStock, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnShow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TelerikMetroTheme1 As Telerik.WinControls.Themes.TelerikMetroTheme
    Friend WithEvents lblMeltingStock As Label
    Friend WithEvents dgvMeltingStock As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnShow As Telerik.WinControls.UI.RadButton
End Class
