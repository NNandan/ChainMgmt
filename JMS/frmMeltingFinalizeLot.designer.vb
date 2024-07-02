<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMeltingFinalizeLot
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
        Dim GridViewTextBoxColumn6 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Dim GridViewTextBoxColumn7 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn8 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition2 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.GboxReceive = New System.Windows.Forms.GroupBox()
        Me.lblRGTotal = New System.Windows.Forms.Label()
        Me.lblRG = New System.Windows.Forms.Label()
        Me.rdgvReceive = New Telerik.WinControls.UI.RadGridView()
        Me.GboxIssue = New System.Windows.Forms.GroupBox()
        Me.lblIGTotal = New System.Windows.Forms.Label()
        Me.lblIG = New System.Windows.Forms.Label()
        Me.rdgvIssue = New Telerik.WinControls.UI.RadGridView()
        Me.btnCancel = New Telerik.WinControls.UI.RadButton()
        Me.btnSave = New Telerik.WinControls.UI.RadButton()
        Me.txtLossWt = New Telerik.WinControls.UI.RadTextBox()
        Me.txtWorkDone = New Telerik.WinControls.UI.RadTextBox()
        Me.lblLoss = New System.Windows.Forms.Label()
        Me.lblWorkDone = New System.Windows.Forms.Label()
        Me.lblRGQty = New System.Windows.Forms.Label()
        Me.lblIGQty = New System.Windows.Forms.Label()
        Me.GboxReceive.SuspendLayout()
        CType(Me.rdgvReceive, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdgvReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GboxIssue.SuspendLayout()
        CType(Me.rdgvIssue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rdgvIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLossWt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtWorkDone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GboxReceive
        '
        Me.GboxReceive.Controls.Add(Me.lblRGQty)
        Me.GboxReceive.Controls.Add(Me.lblRGTotal)
        Me.GboxReceive.Controls.Add(Me.lblRG)
        Me.GboxReceive.Controls.Add(Me.rdgvReceive)
        Me.GboxReceive.Location = New System.Drawing.Point(4, 4)
        Me.GboxReceive.Name = "GboxReceive"
        Me.GboxReceive.Size = New System.Drawing.Size(398, 278)
        Me.GboxReceive.TabIndex = 1
        Me.GboxReceive.TabStop = False
        Me.GboxReceive.Text = "Receive"
        '
        'lblRGTotal
        '
        Me.lblRGTotal.AutoSize = True
        Me.lblRGTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblRGTotal.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblRGTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRGTotal.Location = New System.Drawing.Point(271, 257)
        Me.lblRGTotal.Name = "lblRGTotal"
        Me.lblRGTotal.Size = New System.Drawing.Size(14, 14)
        Me.lblRGTotal.TabIndex = 802
        Me.lblRGTotal.Text = "0"
        Me.lblRGTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRG
        '
        Me.lblRG.AutoSize = True
        Me.lblRG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblRG.Location = New System.Drawing.Point(181, 257)
        Me.lblRG.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblRG.Name = "lblRG"
        Me.lblRG.Size = New System.Drawing.Size(38, 14)
        Me.lblRG.TabIndex = 801
        Me.lblRG.Text = "Total"
        '
        'rdgvReceive
        '
        Me.rdgvReceive.BackColor = System.Drawing.SystemColors.Control
        Me.rdgvReceive.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdgvReceive.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rdgvReceive.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdgvReceive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdgvReceive.Location = New System.Drawing.Point(9, 23)
        '
        '
        '
        Me.rdgvReceive.MasterTemplate.AllowAddNewRow = False
        Me.rdgvReceive.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "MaterialId"
        GridViewTextBoxColumn1.HeaderText = "Material Id."
        GridViewTextBoxColumn1.IsVisible = False
        GridViewTextBoxColumn1.Name = "colMaterialId"
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "MaterialName"
        GridViewTextBoxColumn2.HeaderText = "Material Name"
        GridViewTextBoxColumn2.Name = "colMaterialName"
        GridViewTextBoxColumn2.Width = 110
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemId"
        GridViewTextBoxColumn3.HeaderText = "Item Id."
        GridViewTextBoxColumn3.IsVisible = False
        GridViewTextBoxColumn3.Name = "colItemId"
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ItemName"
        GridViewTextBoxColumn4.HeaderText = "Item Name"
        GridViewTextBoxColumn4.Name = "colItemName"
        GridViewTextBoxColumn4.Width = 115
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ReceiveWt"
        GridViewTextBoxColumn5.HeaderText = "Rec. Wt."
        GridViewTextBoxColumn5.Name = "colReceiveWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 80
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "ReceiveQty"
        GridViewTextBoxColumn6.HeaderText = "Rec. Qty."
        GridViewTextBoxColumn6.Name = "colReceiveQty"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 80
        Me.rdgvReceive.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.rdgvReceive.MasterTemplate.EnableGrouping = False
        Me.rdgvReceive.MasterTemplate.EnableSorting = False
        Me.rdgvReceive.MasterTemplate.ShowRowHeaderColumn = False
        Me.rdgvReceive.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.rdgvReceive.Name = "rdgvReceive"
        Me.rdgvReceive.ReadOnly = True
        Me.rdgvReceive.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdgvReceive.Size = New System.Drawing.Size(383, 229)
        Me.rdgvReceive.TabIndex = 0
        '
        'GboxIssue
        '
        Me.GboxIssue.Controls.Add(Me.lblIGQty)
        Me.GboxIssue.Controls.Add(Me.lblIGTotal)
        Me.GboxIssue.Controls.Add(Me.lblIG)
        Me.GboxIssue.Controls.Add(Me.rdgvIssue)
        Me.GboxIssue.Location = New System.Drawing.Point(408, 4)
        Me.GboxIssue.Name = "GboxIssue"
        Me.GboxIssue.Size = New System.Drawing.Size(398, 278)
        Me.GboxIssue.TabIndex = 2
        Me.GboxIssue.TabStop = False
        Me.GboxIssue.Text = "Issue"
        '
        'lblIGTotal
        '
        Me.lblIGTotal.AutoSize = True
        Me.lblIGTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblIGTotal.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblIGTotal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblIGTotal.Location = New System.Drawing.Point(293, 257)
        Me.lblIGTotal.Name = "lblIGTotal"
        Me.lblIGTotal.Size = New System.Drawing.Size(14, 14)
        Me.lblIGTotal.TabIndex = 804
        Me.lblIGTotal.Text = "0"
        Me.lblIGTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIG
        '
        Me.lblIG.AutoSize = True
        Me.lblIG.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.lblIG.Location = New System.Drawing.Point(174, 257)
        Me.lblIG.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblIG.Name = "lblIG"
        Me.lblIG.Size = New System.Drawing.Size(38, 14)
        Me.lblIG.TabIndex = 803
        Me.lblIG.Text = "Total"
        '
        'rdgvIssue
        '
        Me.rdgvIssue.BackColor = System.Drawing.SystemColors.Control
        Me.rdgvIssue.Cursor = System.Windows.Forms.Cursors.Default
        Me.rdgvIssue.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.rdgvIssue.ForeColor = System.Drawing.SystemColors.ControlText
        Me.rdgvIssue.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.rdgvIssue.Location = New System.Drawing.Point(7, 23)
        '
        '
        '
        Me.rdgvIssue.MasterTemplate.AllowAddNewRow = False
        Me.rdgvIssue.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "MaterialId"
        GridViewTextBoxColumn7.HeaderText = "Material Id."
        GridViewTextBoxColumn7.IsVisible = False
        GridViewTextBoxColumn7.Name = "colMaterialId"
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "MaterialName"
        GridViewTextBoxColumn8.HeaderText = "Material Name"
        GridViewTextBoxColumn8.Name = "colMaterialName"
        GridViewTextBoxColumn8.Width = 110
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.FieldName = "ItemId"
        GridViewTextBoxColumn9.HeaderText = "Item Id."
        GridViewTextBoxColumn9.IsVisible = False
        GridViewTextBoxColumn9.Name = "colItemId"
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.FieldName = "ItemName"
        GridViewTextBoxColumn10.HeaderText = "Item Name"
        GridViewTextBoxColumn10.Name = "colItemName"
        GridViewTextBoxColumn10.Width = 115
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.FieldName = "IssueWt"
        GridViewTextBoxColumn11.HeaderText = "Issue Wt."
        GridViewTextBoxColumn11.Name = "colIssueWt"
        GridViewTextBoxColumn11.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn11.Width = 80
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.FieldName = "IssueQty"
        GridViewTextBoxColumn12.HeaderText = "Issue Qty."
        GridViewTextBoxColumn12.Name = "colIssueQty"
        GridViewTextBoxColumn12.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn12.Width = 80
        Me.rdgvIssue.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn7, GridViewTextBoxColumn8, GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12})
        Me.rdgvIssue.MasterTemplate.EnableGrouping = False
        Me.rdgvIssue.MasterTemplate.ShowRowHeaderColumn = False
        Me.rdgvIssue.MasterTemplate.ViewDefinition = TableViewDefinition2
        Me.rdgvIssue.Name = "rdgvIssue"
        Me.rdgvIssue.ReadOnly = True
        Me.rdgvIssue.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.rdgvIssue.Size = New System.Drawing.Size(383, 229)
        Me.rdgvIssue.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(814, 41)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 25)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(814, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 25)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Save"
        '
        'txtLossWt
        '
        Me.txtLossWt.Location = New System.Drawing.Point(816, 103)
        Me.txtLossWt.Name = "txtLossWt"
        Me.txtLossWt.Size = New System.Drawing.Size(75, 20)
        Me.txtLossWt.TabIndex = 9
        Me.txtLossWt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtWorkDone
        '
        Me.txtWorkDone.BackColor = System.Drawing.SystemColors.Control
        Me.txtWorkDone.Location = New System.Drawing.Point(816, 154)
        Me.txtWorkDone.Name = "txtWorkDone"
        '
        '
        '
        Me.txtWorkDone.RootElement.ControlBounds = New System.Drawing.Rectangle(816, 154, 100, 20)
        Me.txtWorkDone.RootElement.StretchVertically = True
        Me.txtWorkDone.Size = New System.Drawing.Size(75, 20)
        Me.txtWorkDone.TabIndex = 11
        Me.txtWorkDone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLoss
        '
        Me.lblLoss.AutoSize = True
        Me.lblLoss.Location = New System.Drawing.Point(819, 85)
        Me.lblLoss.Name = "lblLoss"
        Me.lblLoss.Size = New System.Drawing.Size(0, 13)
        Me.lblLoss.TabIndex = 12
        '
        'lblWorkDone
        '
        Me.lblWorkDone.AutoSize = True
        Me.lblWorkDone.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWorkDone.Location = New System.Drawing.Point(819, 136)
        Me.lblWorkDone.Name = "lblWorkDone"
        Me.lblWorkDone.Size = New System.Drawing.Size(69, 14)
        Me.lblWorkDone.TabIndex = 13
        Me.lblWorkDone.Text = "Work Done"
        '
        'lblRGQty
        '
        Me.lblRGQty.AutoSize = True
        Me.lblRGQty.BackColor = System.Drawing.Color.Transparent
        Me.lblRGQty.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblRGQty.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRGQty.Location = New System.Drawing.Point(348, 257)
        Me.lblRGQty.Name = "lblRGQty"
        Me.lblRGQty.Size = New System.Drawing.Size(14, 14)
        Me.lblRGQty.TabIndex = 803
        Me.lblRGQty.Text = "0"
        Me.lblRGQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblIGQty
        '
        Me.lblIGQty.AutoSize = True
        Me.lblIGQty.BackColor = System.Drawing.Color.Transparent
        Me.lblIGQty.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lblIGQty.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblIGQty.Location = New System.Drawing.Point(349, 257)
        Me.lblIGQty.Name = "lblIGQty"
        Me.lblIGQty.Size = New System.Drawing.Size(14, 14)
        Me.lblIGQty.TabIndex = 805
        Me.lblIGQty.Text = "0"
        Me.lblIGQty.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMeltingFinalizeLot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(899, 287)
        Me.Controls.Add(Me.lblWorkDone)
        Me.Controls.Add(Me.lblLoss)
        Me.Controls.Add(Me.txtWorkDone)
        Me.Controls.Add(Me.txtLossWt)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GboxIssue)
        Me.Controls.Add(Me.GboxReceive)
        Me.MaximizeBox = False
        Me.Name = "frmMeltingFinalizeLot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Melting Finalize Lot"
        Me.GboxReceive.ResumeLayout(False)
        Me.GboxReceive.PerformLayout()
        CType(Me.rdgvReceive.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdgvReceive, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GboxIssue.ResumeLayout(False)
        Me.GboxIssue.PerformLayout()
        CType(Me.rdgvIssue.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rdgvIssue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnCancel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnSave, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLossWt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtWorkDone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GboxReceive As GroupBox
    Friend WithEvents lblRGTotal As Label
    Friend WithEvents lblRG As Label
    Friend WithEvents rdgvReceive As Telerik.WinControls.UI.RadGridView
    Friend WithEvents GboxIssue As GroupBox
    Friend WithEvents lblIGTotal As Label
    Friend WithEvents lblIG As Label
    Friend WithEvents rdgvIssue As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnCancel As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnSave As Telerik.WinControls.UI.RadButton
    Friend WithEvents txtLossWt As Telerik.WinControls.UI.RadTextBox
    Private WithEvents txtWorkDone As Telerik.WinControls.UI.RadTextBox
    Friend WithEvents lblLoss As Label
    Friend WithEvents lblWorkDone As Label
    Friend WithEvents lblRGQty As Label
    Friend WithEvents lblIGQty As Label
End Class
