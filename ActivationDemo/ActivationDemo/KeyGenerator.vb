Public Class KeyGenerator
    Public Function GenerateKey(ByVal serial As Long) As Long
        Dim x As Long = serial
        Return x * x + 53 / x + 113 * (x / 4)
    End Function
End Class
