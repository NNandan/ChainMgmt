<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLotFailBagNotUsed
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
        Dim GridViewTextBoxColumn4 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn5 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.dgvLotFailBagNo = New Telerik.WinControls.UI.RadGridView()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.dgvLotFailBagNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvLotFailBagNo.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvLotFailBagNo
        '
        Me.dgvLotFailBagNo.BackColor = System.Drawing.SystemColors.Control
        Me.dgvLotFailBagNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvLotFailBagNo.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvLotFailBagNo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvLotFailBagNo.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvLotFailBagNo.Location = New System.Drawing.Point(3, 12)
        '
        '
        '
        Me.dgvLotFailBagNo.MasterTemplate.AllowAddNewRow = False
        Me.dgvLotFailBagNo.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "UsedBagDt"
        GridViewTextBoxColumn1.HeaderText = "Trans. Dt"
        GridViewTextBoxColumn1.Name = "colTransDt"
        GridViewTextBoxColumn1.Width = 70
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "BagSrNo"
        GridViewTextBoxColumn2.HeaderText = "Bag Sr No"
        GridViewTextBoxColumn2.Name = "colItemName"
        GridViewTextBoxColumn2.Width = 240
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ReceiveWt"
        GridViewTextBoxColumn3.HeaderText = "Receive Wt."
        GridViewTextBoxColumn3.Name = "colReceiveWt"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 80
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ReportPr"
        GridViewTextBoxColumn4.HeaderText = "Receive %"
        GridViewTextBoxColumn4.Name = "colReceivePr"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 90
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "FineWt"
        GridViewTextBoxColumn5.HeaderText = "Fine Wt."
        GridViewTextBoxColumn5.Name = "colFineWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 80
        Me.dgvLotFailBagNo.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5})
        Me.dgvLotFailBagNo.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvLotFailBagNo.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvLotFailBagNo.Name = "dgvLotFailBagNo"
        Me.dgvLotFailBagNo.ReadOnly = True
        Me.dgvLotFailBagNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvLotFailBagNo.Size = New System.Drawing.Size(663, 376)
        Me.dgvLotFailBagNo.TabIndex = 7
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(249, 392)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 8
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnExit.Location = New System.Drawing.Point(325, 392)
        Me.btnExit.Name = "btnExit"
        '
        '
        '
        Me.btnExit.RootElement.ControlBounds = New System.Drawing.Rectangle(325, 392, 110, 24)
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 799
        Me.btnExit.Text = "E&xit"
        '
        'frmLotFailBagNotUsed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 419)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvLotFailBagNo)
        Me.MaximizeBox = False
        Me.Name = "frmLotFailBagNotUsed"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "LotFail Bag Not Used"
        CType(Me.dgvLotFailBagNo.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvLotFailBagNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvLotFailBagNo As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Private WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
