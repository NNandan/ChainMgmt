<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFMetalUsedInBag
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
        Me.dgvMeltingBagList.Location = New System.Drawing.Point(4, 4)
        '
        '
        '
        Me.dgvMeltingBagList.MasterTemplate.AllowAddNewRow = False
        Me.dgvMeltingBagList.MasterTemplate.AllowColumnReorder = False
        Me.dgvMeltingBagList.MasterTemplate.AllowDeleteRow = False
        Me.dgvMeltingBagList.MasterTemplate.AllowEditRow = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "BagSrNo"
        GridViewTextBoxColumn1.HeaderText = "Bag No."
        GridViewTextBoxColumn1.Name = "colBagNo"
        GridViewTextBoxColumn1.Width = 75
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "LotNo"
        GridViewTextBoxColumn2.HeaderText = "Lot No"
        GridViewTextBoxColumn2.Name = "colVoucherNo"
        GridViewTextBoxColumn2.Width = 80
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemName"
        GridViewTextBoxColumn3.HeaderText = "Bag Name"
        GridViewTextBoxColumn3.Name = "colItemName"
        GridViewTextBoxColumn3.Width = 125
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "Used In"
        GridViewTextBoxColumn4.HeaderText = "Used In"
        GridViewTextBoxColumn4.Name = "colUsedIn"
        GridViewTextBoxColumn4.Width = 120
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "RecieveWt"
        GridViewTextBoxColumn5.HeaderText = "Recieve Wt."
        GridViewTextBoxColumn5.Name = "colRecieveWt"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 80
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "IssueWt"
        GridViewTextBoxColumn6.HeaderText = "Issue Wt."
        GridViewTextBoxColumn6.Name = "colIssueWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 75
        GridViewTextBoxColumn7.EnableExpressionEditor = False
        GridViewTextBoxColumn7.FieldName = "IssuePr"
        GridViewTextBoxColumn7.HeaderText = "Issue [%]"
        GridViewTextBoxColumn7.Name = "colIssuePr"
        GridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn7.Width = 75
        GridViewTextBoxColumn8.EnableExpressionEditor = False
        GridViewTextBoxColumn8.FieldName = "FineWt"
        GridViewTextBoxColumn8.HeaderText = "Fine Wt."
        GridViewTextBoxColumn8.Name = "colFineWt"
        GridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn8.Width = 75
        Me.dgvMeltingBagList.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6, GridViewTextBoxColumn7, GridViewTextBoxColumn8})
        Me.dgvMeltingBagList.MasterTemplate.EnableGrouping = False
        Me.dgvMeltingBagList.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvMeltingBagList.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvMeltingBagList.Name = "dgvMeltingBagList"
        Me.dgvMeltingBagList.ReadOnly = True
        Me.dgvMeltingBagList.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvMeltingBagList.Size = New System.Drawing.Size(703, 365)
        Me.dgvMeltingBagList.TabIndex = 19
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(287, 374)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 20
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(364, 374)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 28
        Me.btnExit.Text = "E&xit"
        '
        'frmFaMetalUsedInBag
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(711, 401)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.dgvMeltingBagList)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmFaMetalUsedInBag"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Metal Used By Bag Number"
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
