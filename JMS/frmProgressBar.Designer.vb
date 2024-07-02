<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgressBar
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
        Me.components = New System.ComponentModel.Container()
        Me.bar = New System.Windows.Forms.ProgressBar()
        Me.lbl = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'bar
        '
        Me.bar.Location = New System.Drawing.Point(1, 1)
        Me.bar.Name = "bar"
        Me.bar.Size = New System.Drawing.Size(429, 23)
        Me.bar.TabIndex = 0
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.Font = New System.Drawing.Font("Tahoma", 9.0!)
        Me.lbl.Location = New System.Drawing.Point(4, 29)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(0, 14)
        Me.lbl.TabIndex = 1
        '
        'Timer1
        '
        '
        'frmProgressBar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(431, 55)
        Me.Controls.Add(Me.lbl)
        Me.Controls.Add(Me.bar)
        Me.MaximizeBox = False
        Me.Name = "frmProgressBar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bar As ProgressBar
    Friend WithEvents lbl As Label
    Friend WithEvents Timer1 As Timer
End Class
