<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFVacBagNotUpdated
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
        Me.btnPrint = New Telerik.WinControls.UI.RadButton()
        Me.DgvVacNotUBag = New Telerik.WinControls.UI.RadGridView()
        Me.btnExit = New Telerik.WinControls.UI.RadButton()
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvVacNotUBag, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvVacNotUBag.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnPrint.Location = New System.Drawing.Point(237, 517)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 25)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "&Print"
        '
        'DgvVacNotUBag
        '
        Me.DgvVacNotUBag.BackColor = System.Drawing.SystemColors.Control
        Me.DgvVacNotUBag.Cursor = System.Windows.Forms.Cursors.Default
        Me.DgvVacNotUBag.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.DgvVacNotUBag.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DgvVacNotUBag.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DgvVacNotUBag.Location = New System.Drawing.Point(2, 2)
        '
        '
        '
        Me.DgvVacNotUBag.MasterTemplate.AllowAddNewRow = False
        Me.DgvVacNotUBag.MasterTemplate.AllowColumnReorder = False
        GridViewTextBoxColumn1.EnableExpressionEditor = False
        GridViewTextBoxColumn1.FieldName = "TransactionDt"
        GridViewTextBoxColumn1.HeaderText = "Trans Dt."
        GridViewTextBoxColumn1.MinWidth = 6
        GridViewTextBoxColumn1.Name = "colTransactionDt"
        GridViewTextBoxColumn1.Width = 90
        GridViewTextBoxColumn2.EnableExpressionEditor = False
        GridViewTextBoxColumn2.FieldName = "BagSrNo"
        GridViewTextBoxColumn2.HeaderText = "Bag No"
        GridViewTextBoxColumn2.MinWidth = 6
        GridViewTextBoxColumn2.Name = "colBagSrNo"
        GridViewTextBoxColumn2.Width = 100
        GridViewTextBoxColumn3.EnableExpressionEditor = False
        GridViewTextBoxColumn3.FieldName = "ItemName"
        GridViewTextBoxColumn3.HeaderText = "Item Name"
        GridViewTextBoxColumn3.MinWidth = 6
        GridViewTextBoxColumn3.Name = "colItemName"
        GridViewTextBoxColumn3.Width = 150
        GridViewTextBoxColumn4.EnableExpressionEditor = False
        GridViewTextBoxColumn4.HeaderText = "Receive Wt."
        GridViewTextBoxColumn4.MinWidth = 6
        GridViewTextBoxColumn4.Name = "colReceiveWt"
        GridViewTextBoxColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn4.Width = 90
        GridViewTextBoxColumn5.EnableExpressionEditor = False
        GridViewTextBoxColumn5.FieldName = "ReceivePr"
        GridViewTextBoxColumn5.HeaderText = "Receive [%]"
        GridViewTextBoxColumn5.MinWidth = 6
        GridViewTextBoxColumn5.Name = "colReceivePr"
        GridViewTextBoxColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn5.Width = 90
        GridViewTextBoxColumn6.EnableExpressionEditor = False
        GridViewTextBoxColumn6.FieldName = "FineWt"
        GridViewTextBoxColumn6.HeaderText = "Fine Wt."
        GridViewTextBoxColumn6.MinWidth = 6
        GridViewTextBoxColumn6.Name = "colFineWt"
        GridViewTextBoxColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleRight
        GridViewTextBoxColumn6.Width = 90
        Me.DgvVacNotUBag.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn1, GridViewTextBoxColumn2, GridViewTextBoxColumn3, GridViewTextBoxColumn4, GridViewTextBoxColumn5, GridViewTextBoxColumn6})
        Me.DgvVacNotUBag.MasterTemplate.ShowRowHeaderColumn = False
        Me.DgvVacNotUBag.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.DgvVacNotUBag.Name = "DgvVacNotUBag"
        Me.DgvVacNotUBag.ReadOnly = True
        Me.DgvVacNotUBag.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DgvVacNotUBag.Size = New System.Drawing.Size(608, 509)
        Me.DgvVacNotUBag.TabIndex = 7
        '
        'btnExit
        '
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnExit.Location = New System.Drawing.Point(313, 517)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 25)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "E&xit"
        '
        'frmFVacBagNotUpdated
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(612, 546)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.DgvVacNotUBag)
        Me.Controls.Add(Me.btnPrint)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.Name = "frmFVacBagNotUpdated"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vaccum Bag Not Updated"
        CType(Me.btnPrint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvVacNotUBag.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvVacNotUBag, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnExit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnPrint As Telerik.WinControls.UI.RadButton
    Friend WithEvents DgvVacNotUBag As Telerik.WinControls.UI.RadGridView
    Friend WithEvents btnExit As Telerik.WinControls.UI.RadButton
End Class
