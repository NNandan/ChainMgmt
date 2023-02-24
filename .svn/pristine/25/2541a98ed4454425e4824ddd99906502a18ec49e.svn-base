Public Class frmYearMaster
    Dim blnEdit As Boolean
    Dim MyDate As TimeSpan
    Private Sub frmYearMaster_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Try
            'startdate.Value = "01/04/" & Year(Mydate)
            'enddate.Value = "31/03/" & Year(Mydate) + 1
            'If blnEdit = True Then
            '    startdate.Enabled = False
            '    enddate.Enabled = False
            'End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub frmYearMaster_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then SendKeys.Send("{Tab}")
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class