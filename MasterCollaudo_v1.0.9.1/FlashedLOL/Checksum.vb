Imports System.IO

Public Module Checksummer
    Public echo As Boolean = True
    Public Function checkaChecksum(ByVal fileName As String, ByVal goodChecksum As String) As Boolean
        Try

            Dim calcu As String = getChecksum(fileName)
            Dim goodCalcu As String = Hex(Convert.ToInt32(goodChecksum, 16))

            If calcu.Equals(goodCalcu) Then
                Return True
            End If

            MessageBox.Show("Good checksum: " & goodChecksum &
                            " (converted: " & goodCalcu & ")" &
                            "Calculated checksum: " & calcu)

        Catch ex As Exception
            aggiornaLog(ex)
        End Try
        Return False
    End Function




    Public Function getChecksum(ByVal fileName As String) As String
        Try

            Dim bytes() As Byte = File.ReadAllBytes(fileName)
            Dim sum As Integer = 0

            For Each b In bytes
                sum += b
            Next

            Return Hex(sum)

        Catch ex As Exception
            aggiornaLog(ex)
        End Try
        Return "0"
    End Function


    Public Function StrToHex(ByRef Data As String) As String
        Dim sVal As String
        Dim sHex As String = ""
        While Data.Length > 0
            sVal = Conversion.Hex(Strings.Asc(Data.Substring(0, 1).ToString()))
            Data = Data.Substring(1, Data.Length - 1)
            sHex = sHex & sVal
        End While
        Return sHex
    End Function



    Private Sub aggiornaLog(ex As Exception)
        Try
            If echo Then
                MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
            End If
        Catch ex1 As Exception
            MessageBox.Show(ex1.ToString)
        End Try
    End Sub

End Module
