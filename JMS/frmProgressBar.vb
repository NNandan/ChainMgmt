Public Class frmProgressBar
    Private Sub frmProgressBar_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            bar.Step = 1

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            If bar.Value <= 20 Then
                Timer1.Interval = 1000
                lbl.Text = "Creating Database....."
            ElseIf bar.Value <= 50 Then
                Timer1.Interval = 200
                lbl.Text = "Importing Books....."
            ElseIf bar.Value <= 80 Then
                Timer1.Interval = 100
                lbl.Text = "Importing Masters....."
            Else
                lbl.Text = "Please Wait....."
            End If

            If bar.Value = 100 Then
                Me.Close()
            End If
            bar.PerformStep()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class