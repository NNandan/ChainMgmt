<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransactionStockRpt
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
        Dim RadListDataItem1 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem2 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim RadListDataItem3 As Telerik.WinControls.UI.RadListDataItem = New Telerik.WinControls.UI.RadListDataItem()
        Dim TableViewDefinition1 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.lblMeltingStock = New System.Windows.Forms.Label()
        Me.btnShow = New Telerik.WinControls.UI.RadButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbBagType = New Telerik.WinControls.UI.RadDropDownList()
        Me.dgvTransStock = New Telerik.WinControls.UI.RadGridView()
        CType(Me.btnShow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cmbBagType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransStock, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvTransStock.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMeltingStock
        '
        Me.lblMeltingStock.AutoSize = True
        Me.lblMeltingStock.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMeltingStock.Location = New System.Drawing.Point(280, 7)
        Me.lblMeltingStock.Name = "lblMeltingStock"
        Me.lblMeltingStock.Size = New System.Drawing.Size(190, 20)
        Me.lblMeltingStock.TabIndex = 3
        Me.lblMeltingStock.Text = "Transaction Stock Report"
        '
        'btnShow
        '
        Me.btnShow.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.btnShow.Location = New System.Drawing.Point(325, 318)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(75, 25)
        Me.btnShow.TabIndex = 5
        Me.btnShow.Text = "Show"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(16, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Select Bag Type"
        '
        'cmbBagType
        '
        Me.cmbBagType.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList
        RadListDataItem1.Text = "Bhuka Bag"
        RadListDataItem2.Text = "Sample Bag"
        RadListDataItem3.Text = "Vacuum Bag"
        Me.cmbBagType.Items.Add(RadListDataItem1)
        Me.cmbBagType.Items.Add(RadListDataItem2)
        Me.cmbBagType.Items.Add(RadListDataItem3)
        Me.cmbBagType.Location = New System.Drawing.Point(116, 35)
        Me.cmbBagType.Name = "cmbBagType"
        Me.cmbBagType.Size = New System.Drawing.Size(125, 20)
        Me.cmbBagType.TabIndex = 36
        '
        'dgvTransStock
        '
        Me.dgvTransStock.BackColor = System.Drawing.Color.Transparent
        Me.dgvTransStock.Cursor = System.Windows.Forms.Cursors.Default
        Me.dgvTransStock.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.dgvTransStock.ForeColor = System.Drawing.SystemColors.ControlText
        Me.dgvTransStock.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvTransStock.Location = New System.Drawing.Point(5, 67)
        '
        '
        '
        Me.dgvTransStock.MasterTemplate.AllowAddNewRow = False
        Me.dgvTransStock.MasterTemplate.AllowColumnReorder = False
        Me.dgvTransStock.MasterTemplate.EnableFiltering = True
        Me.dgvTransStock.MasterTemplate.EnableGrouping = False
        Me.dgvTransStock.MasterTemplate.ShowRowHeaderColumn = False
        Me.dgvTransStock.MasterTemplate.ViewDefinition = TableViewDefinition1
        Me.dgvTransStock.Name = "dgvTransStock"
        Me.dgvTransStock.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dgvTransStock.Size = New System.Drawing.Size(709, 246)
        Me.dgvTransStock.TabIndex = 140
        '
        'frmTransactionStockRpt
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(719, 347)
        Me.Controls.Add(Me.dgvTransStock)
        Me.Controls.Add(Me.cmbBagType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.lblMeltingStock)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmTransactionStockRpt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaction Stock Report"
        CType(Me.btnShow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cmbBagType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransStock.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvTransStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblMeltingStock As Label
    Friend WithEvents btnShow As Telerik.WinControls.UI.RadButton
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbBagType As Telerik.WinControls.UI.RadDropDownList
    Friend WithEvents dgvTransStock As Telerik.WinControls.UI.RadGridView
End Class
