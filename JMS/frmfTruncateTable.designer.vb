<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmfTruncateTable
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
        Me.BtnDeleteTrans = New Telerik.WinControls.UI.RadButton()
        Me.RadLabel1 = New Telerik.WinControls.UI.RadLabel()
        CType(Me.BtnDeleteTrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnDeleteTrans
        '
        Me.BtnDeleteTrans.Location = New System.Drawing.Point(43, 83)
        Me.BtnDeleteTrans.Name = "BtnDeleteTrans"
        Me.BtnDeleteTrans.Size = New System.Drawing.Size(110, 24)
        Me.BtnDeleteTrans.TabIndex = 0
        Me.BtnDeleteTrans.Text = "Delete Transaction"
        '
        'RadLabel1
        '
        Me.RadLabel1.Location = New System.Drawing.Point(23, 31)
        Me.RadLabel1.Name = "RadLabel1"
        Me.RadLabel1.Size = New System.Drawing.Size(130, 18)
        Me.RadLabel1.TabIndex = 1
        Me.RadLabel1.Text = "This Click Delete All Data"
        '
        'frmfTruncateTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(189, 115)
        Me.Controls.Add(Me.RadLabel1)
        Me.Controls.Add(Me.BtnDeleteTrans)
        Me.MaximizeBox = False
        Me.Name = "frmfTruncateTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmDeleteTransactions"
        CType(Me.BtnDeleteTrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadLabel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnDeleteTrans As Telerik.WinControls.UI.RadButton
    Friend WithEvents RadLabel1 As Telerik.WinControls.UI.RadLabel
End Class
