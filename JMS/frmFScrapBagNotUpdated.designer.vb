<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFScrapBagNotUpdated
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
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.DgvScrapNotUBag = New Telerik.WinControls.UI.RadGridView()
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        Me.BtnPrnt = New Telerik.WinControls.UI.RadButton()
        Me.BtnClose = New Telerik.WinControls.UI.RadButton()
        CType(Me.DgvScrapNotUBag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvScrapNotUBag.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnPrnt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BtnClose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DgvScrapNotUBag
        '
        Me.DgvScrapNotUBag.BackColor = System.Drawing.SystemColors.Control
        Me.DgvScrapNotUBag.Cursor = System.Windows.Forms.Cursors.Default
        Me.DgvScrapNotUBag.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DgvScrapNotUBag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvScrapNotUBag.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DgvScrapNotUBag.Location = New System.Drawing.Point(0, 1)
        '
        '
        '
        Me.DgvScrapNotUBag.MasterTemplate.AllowAddNewRow = False
        Me.DgvScrapNotUBag.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "TransactionDt"
        GridViewTextBoxColumn1.HeaderText = "Trans Dt."
        GridViewTextBoxColumn1.MinWidth = 6
        GridViewTextBoxColumn1.Name = "colTransDt"
        GridViewTextBoxColumn1.Width = 90
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "BagSrNo"
        GridViewTextBoxColumn2.HeaderText = "Bag No."
        GridViewTextBoxColumn2.MinWidth = 6
        GridViewTextBoxColumn2.Name = "colScrapBagNo"
        GridViewTextBoxColumn2.Width = 120
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemName"
        GridViewTextBoxColumn3.HeaderText = "Item Name"
        GridViewTextBoxColumn3.MinWidth = 6
        GridViewTextBoxColumn3.Name = "colItemName"
        GridViewTextBoxColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn3.Width = 150
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.FieldName = "ReceiveWt"
        GridViewTextBoxColumn4.HeaderText = "Scrap Wt"
        GridViewTextBoxColumn4.MinWidth = 6
        GridViewTextBoxColumn4.Name = "colScrapWt"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 90
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ReceivePr"
        GridViewTextBoxColumn5.HeaderText = "Receive [%]"
        GridViewTextBoxColumn5.MinWidth = 6
        GridViewTextBoxColumn5.Name = "colReceivePr"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn5.Width = 90
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "FineWt"
        GridViewTextBoxColumn6.HeaderText = "Fine Wt"
        GridViewTextBoxColumn6.MinWidth = 6
        GridViewTextBoxColumn6.Name = "colFineWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter
        GridViewTextBoxColumn6.Width = 90
        Me.DgvScrapNotUBag.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.DgvScrapNotUBag.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgvScrapNotUBag.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.DgvScrapNotUBag.Name = "DgvScrapNotUBag"
        Me.DgvScrapNotUBag.ReadOnly = True
        Me.DgvScrapNotUBag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvScrapNotUBag.Size = New System.Drawing.Size(627, 353)
        Me.DgvScrapNotUBag.TabIndex = 0
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(325, 426)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 56
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(401, 426)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 55
        Me.btnExit.Text = "E&xit"
        '
        'BtnPrnt
        '
        Me.BtnPrnt.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnPrnt.Location = New System.Drawing.Point(240, 359)
        Me.BtnPrnt.Name = "BtnPrnt"
        Me.BtnPrnt.Size = New System.Drawing.Size(75, 25)
        Me.BtnPrnt.TabIndex = 1
        Me.BtnPrnt.Text = "&Print"
        '
        'BtnClose
        '
        Me.BtnClose.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.BtnClose.Location = New System.Drawing.Point(316, 359)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 25)
        Me.BtnClose.TabIndex = 2
        Me.BtnClose.Text = "E&xit"
        '
        'frmFScrapBagNotUpdated
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(629, 388)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.BtnPrnt)
        Me.Controls.Add(Me.DgvScrapNotUBag)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.Name = "frmFScrapBagNotUpdated"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Scrap Bag Not Updated"
        CType(Me.DgvScrapNotUBag.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvScrapNotUBag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnPrnt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BtnClose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DgvScrapNotUBag As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnPrnt As Telerik.WinControls.UI.RadButton
    Friend WithEvents BtnClose As Telerik.WinControls.UI.RadButton
End Class
