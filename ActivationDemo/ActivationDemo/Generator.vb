Public Class Generator

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim serial As Long
        If Not Long.TryParse(txtSerial.Text, serial) Then
            MessageBox.Show("Inavlid serial number")
            Exit Sub
        End If

        Dim kg As New KeyGenerator
        Dim key As Long = kg.GenerateKey(serial)
        txtKey.Text = key
    End Sub
End Class