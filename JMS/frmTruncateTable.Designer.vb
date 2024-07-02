<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTruncateTable
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
        Me.btnTruncate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnTruncate
        '
        Me.btnTruncate.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTruncate.Location = New System.Drawing.Point(35, 213)
        Me.btnTruncate.Name = "btnTruncate"
        Me.btnTruncate.Size = New System.Drawing.Size(173, 25)
        Me.btnTruncate.TabIndex = 0
        Me.btnTruncate.Text = "Delete Transaction Data"
        Me.btnTruncate.UseVisualStyleBackColor = True
        '
        'frmTruncateTable
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(239, 241)
        Me.Controls.Add(Me.btnTruncate)
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTruncateTable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Truncate Tables"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnTruncate As Button
End Class
