Imports System.IO
Imports System
Imports System.Runtime.InteropServices
Imports System.IO.Ports
Imports System.Threading.Tasks

Module Library
    'Dim occupato = False
    Dim Tentativi As Integer = 0

    Public tcon
    Public Potenze = New Integer(15) {1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768}
    Public trx, ttx As Integer
    Public m_vertices(8) As Point3D
    Public m_faces(6, 4) As Integer
    Public m_colors(6) As Color
    Public m_brushes(6) As Brush
    Public m_x, m_y, m_z As Integer
    Public RollOld, PitchOld As Integer
    Public GAccel, YAccel As Integer
    Public Pitch, Roll, Inclinazione As String
    Dim Firmwarecompattato(0) As String
    Public totbyte As Integer
    Dim DaStampare As String
    Public ProgrammaFinale(2000) As String
    Dim settori As Integer
    Public CBFirmware(12000)
    Public indice, indicecksm As Integer
    Public bytes() As Byte
    Public Checksum(1000) As Integer
    Public Host, Dir, User, Code, Psw, Port, Apn, UserID, Passw As String
    Public NewFM, NewPR, CurFM, CurPR, NTel As String
    Public NodoCAN As String = ""

    Public SaveToFIle As Boolean = False
    Public fileName As String = Application.StartupPath & "/backup.ets"
    Public setupFileName As String = Application.StartupPath & "/collaudo-setup.ets"
    Public setupFileUtenza As String = Application.StartupPath & "/utenza.ets"
    ' Public file_touch As String = Application.StartupPath & "/utenza.ets"
    Public xVerbose = True


    Public Function GetSecNum(ByVal adr As Long)

        Dim n As Long

        n = adr >> 12                             '  4kB Sector
        If (n >= &H10) Then

            n = &HE + (n >> 3)                      ' 32kB Sector
        End If


        Return (n)                               ' Sector Number

    End Function

    Public Function Intobit(ByVal Numero, ByVal NumeroBit) As Boolean
        Return CBool((Numero \ Potenze(NumeroBit)) And 1)
    End Function
    Sub AggiornaLog(ByVal ex As Exception)
        Try

            Dim Temp As FileStream = Nothing

            Dim LogPath As String = System.Windows.Forms.Application.StartupPath
            Dim Testo As String



            If (Not System.IO.Directory.Exists(LogPath & "\Log")) Then
                System.IO.Directory.CreateDirectory(LogPath & "\Log")
            End If

            If Not File.Exists(LogPath & "\Log\Log.txt") Then
                Temp = File.Create(LogPath & "\Log\Log.txt")
                Temp.Close()
            End If

            Dim info As New FileInfo(LogPath & "\Log\Log.txt")
            If info.Length > 1000000 Then
                File.Delete(LogPath & "\Log\Log.txt")
                Temp = File.Create(LogPath & "\Log\Log.txt")
                Temp.Close()
            End If

            Using Log As StreamReader = New StreamReader(LogPath & "\Log\Log.txt")

                Testo = Log.ReadToEnd()
            End Using

            Using Log As StreamWriter = New StreamWriter(LogPath & "\Log\Log.txt")

                Log.WriteLine(Now() & " " & ex.Message & " " & ex.StackTrace)
                Log.WriteLine(Testo)
            End Using

            If xVerbose Then
                MsgBox(ex.Message)
            End If

        Catch ex1 As Exception
            MsgBox("Errore nella scrittura log")
        End Try
    End Sub

    Dim trolololololol As Integer



    Public Function RDW_Command(ByVal Comando As String, Optional ByVal Offset As String = "", Optional ByVal Value As String = "",
                               Optional ByVal ErrorEnable As Boolean = False, Optional ByVal ReadFloat As Boolean = False, Optional ByVal FIND As String = "",
                               Optional ByVal customTimeout As Integer = 1000, Optional ByRef MiaPorta As SerialPort = Nothing
                               ) As String
        ' Optional ByVal comPort As String


        'Dim errore As Integer = 0



        Tentativi = 0



        Dim Stringa As String
        Dim Porta As SerialPort = Nothing
        Dim MyRnd As New Random
        Dim CheckSinc As Boolean = False
        Dim CheckRisp As String = ""

        If MiaPorta Is Nothing Then
        Else
            Porta = MiaPorta
        End If



        If Len(Offset) > 0 Then Offset = " " & Offset
        If Len(Value) > 0 Then Value = " " & Value
        If ReadFloat Then Value = Replace(Value, ",", ".")
        Dim Risposta As String = ""
        If CheckSinc Then
            CheckRisp = "~C:" & MyRnd.Next(100)
        End If

        Stringa = "$" & Comando & Offset & Value & CheckRisp & IIf(CheckRisp.Length > 0, " ", "") & vbCr


        If NodoCAN.Length > 0 Then Stringa = "$R0R " & NodoCAN & Stringa

        If SaveToFIle Then
            Try
                If Stringa.Contains("L02") Or (Comando.StartsWith("R") And Not Comando.StartsWith("R0R")) Then
                    Return ""
                End If

                Dim AllExpFile As String = ""
                Using sw As StreamReader = New StreamReader(fileName)

                    AllExpFile = sw.ReadToEnd

                End Using
                Using sw As StreamWriter = New StreamWriter(fileName)
                    If (CheckRisp.Length <> 0) Then
                        Stringa = Stringa.Replace(CheckRisp, "")
                    End If
                    sw.Write(AllExpFile & Stringa & vbLf)
                End Using
                '            If Not Value = "" Then If Value.Length > 1 And Value.First = " " Then Risposta = Value.Remove(0, 1) Else Risposta = Value
                If ReadFloat Then Value = Replace(Value, ".", ",")
                Return Trim(Value)

            Catch ex As Exception
                AggiornaLog(ex)
            End Try
            Throw New Exception("Scrittura su file fallita")
        End If

        Try
            ' Porta = SerialPortModem
            If (Porta Is Nothing) Then
                Porta = Main.SerialPort
            End If

            ttx = 5
            If Not Porta.IsOpen Then
                Try
                    Porta.Open()

                Catch
                    trolololololol = 0
                    Return "REMOVED"
                End Try
            End If

            Tentativi += 1


            If Not IsNothing(tcon) Then
                While tcon.Status = TaskStatus.Running
                    Application.DoEvents()
                    System.Threading.Thread.Sleep(1)
                End While
            End If
            Dim t_o As New Stopwatch
            t_o.Reset()
            t_o.Start()
            'While trolololololol = 1
            '    If t_o.ElapsedMilliseconds > Porta.ReadTimeout Then
            '        Return "Errore-Timeout"
            '    End If
            '    Application.DoEvents()
            '    System.Threading.Thread.Sleep(1)
            'End While


            'While trolololololol = 1
            '    If t_o.ElapsedMilliseconds > 50000 Then
            '        'sending_cmd = False
            '        Return "Errore-Timeout"
            '    End If
            '    Application.DoEvents()
            '    System.Threading.Thread.Sleep(1)
            'End While



            trolololololol = 1

            Porta.DiscardOutBuffer()
            Porta.DiscardInBuffer()
            Porta.Write(Stringa)
            If customTimeout <= 0 Then
                Porta.ReadTimeout = Ports.SerialPort.InfiniteTimeout
            Else
                Porta.ReadTimeout = customTimeout
            End If

            ' Porta.ReadTimeout = 10000

            tcon = New Task(Of String)(Function()
                                           Try
                                               Dim temp As String = ""
                                               Dim Temp1 As String = ""
                                               If FIND = "" Then
                                                   temp = Porta.ReadLine()

                                               Else
                                                   Porta.ReadTimeout = 10000
                                                   While 1
                                                       Temp1 = Porta.ReadLine
                                                       temp = temp & Temp1
                                                       If Temp1.Contains(FIND) Then
                                                           Exit While
                                                       End If

                                                   End While

                                               End If
                                               Return temp.ToString

                                           Catch ex As Exception
                                               Return "Errore-Timeout"
                                           End Try

                                       End Function)


            'If Porta.BytesToRead > 0 Then
            '    Porta.DiscardInBuffer()
            'End If
            tcon.Start()



            While (Not tcon.IsCompleted)
                Application.DoEvents()
                System.Threading.Thread.Sleep(1)
            End While

            If tcon.Result = "Errore-Timeout" Then
                Tentativi += 1
                trolololololol = 0

                If Tentativi > 5 Or ErrorEnable Then

                    Return "KO"
                Else

                    Return "KO"
                End If



            End If
            ' tcon.Dispose()
            trx = 5
            Risposta = tcon.Result
            Porta.DiscardOutBuffer()
            Porta.DiscardInBuffer()



DopoRisposta:



            'Tentativi = 0



            If FIND = "" Then
                Risposta = Trim(Replace(Risposta, "" & vbCr & "", ""))
                If ReadFloat Then Risposta = Replace(Risposta, ".", ",")

            End If

            Tentativi = 0
        Catch ex As Exception
            trolololololol = 0
            Return "KO"
        End Try
        trolololololol = 0

        Return Risposta


    End Function

    Public Function FormattaGiorno(ByRef giorno As String, ByRef mese As String, ByRef anno As String)
        Try


            If giorno.Length = 1 Then giorno = "0" & giorno
            If mese.Length = 1 Then mese = "0" & mese

            Return giorno & "/" & mese & "/" & anno
        Catch ex As Exception
            AggiornaLog(ex)
            Return ""
        End Try
    End Function
    Public Function FormattaOra(ByRef ora As String, ByRef minuti As String, ByRef secondi As String)
        Try


            If ora.Length = 1 Then ora = "0" & ora
            If minuti.Length = 1 Then minuti = "0" & minuti
            If secondi.Length = 1 Then secondi = "0" & secondi


            Return ora & ":" & minuti & ":" & secondi
        Catch ex As Exception
            AggiornaLog(ex)
            Return ""
        End Try
    End Function
    Public Function VerificaCollegamento()
        Return RDW_Command("R01", , , , )

    End Function

    Public Function CaricaIO()
        Try

            Pitch = ets.Accelerometro.Pitch
            Roll = ets.Accelerometro.Roll


            If Pitch <> PitchOld Or Roll <> RollOld Then

                m_x = Pitch
                m_y = 0
                m_z = Roll
                ' Main.PperPos.Invalidate()
                PitchOld = Pitch
                RollOld = Roll

            End If
            Tentativi = 0
            Return "OK"


        Catch ex As Exception
            AggiornaLog(ex)
            Tentativi += 1
            If Tentativi > 10 Then Return "KO"
            Return "OK"



        End Try
    End Function


    Sub LeggiFirmware(ByVal Filename As String)
        Dim input As FileStream = Nothing
        Try

            For i As Integer = 0 To CBFirmware.Length - 1 Step +1
                CBFirmware(i) = ""

            Next
            For i As Integer = 0 To Checksum.Length - 1 Step +1

                Checksum(i) = 0

            Next



            input = New FileStream(Filename, FileMode.Open)
            Dim reader As New BinaryReader(input)


            Dim crc As Long

            bytes = reader.ReadBytes(CInt(input.Length))


            indice = 0
            indicecksm = 0


            For i As Integer = 0 To 4 Step +1
                bytes(28 + i) = 0
            Next


            For i As Integer = 0 To (4 * 8) Step +4
                crc += bytes(i)
                crc += bytes(i + 1) * 256
                crc += bytes(i + 2) * 65536
                crc += bytes(i + 3) * 16777216
            Next

            crc = CInt(0 - crc)



            bytes(31) = (crc And 4278190080) / 16777216
            bytes(30) = (crc And 16711680) / 65536
            bytes(29) = (crc And 65280) / 256
            bytes(28) = (crc And 255) / 1


            For i As Integer = 0 To bytes.Count - 1 Step +3







                If i + 1 >= bytes.Count Then
                    CBFirmware(indice) = CBFirmware(indice) & ConvertToUU(bytes(i), 0, 0)
                    Checksum(indicecksm) += CInt(bytes(i))

                ElseIf i + 2 >= bytes.Count Then


                    CBFirmware(indice) = CBFirmware(indice) & ConvertToUU(bytes(i), bytes(i + 1), 0)
                    Checksum(indicecksm) += CInt(bytes(i)) + CInt(bytes(i + 1))

                Else
                    CBFirmware(indice) = CBFirmware(indice) & ConvertToUU(bytes(i), bytes(i + 1), bytes(i + 2))
                    Checksum(indicecksm) += CInt(bytes(i)) + CInt(bytes(i + 1)) + CInt(bytes(i + 2))

                End If


                If CBFirmware(indice).ToString.Length = 60 Then
                    'CBFirmware(indice) = Replace(CBFirmware(indice), " ", "'")
                    indice += 1

                    Continue For
                End If


                If (indice + 1) Mod 12 = 0 And indice > 10 Then

                    If CBFirmware(indice).ToString.Length = 20 Then
                        CBFirmware(indice) = CBFirmware(indice) & ConvertToUU(bytes(i + 3), bytes(i + 4), 0)
                        Checksum(indicecksm) += CInt(bytes(i + 3)) + CInt(bytes(i + 4))
                        i += 2
                        'CBFirmware(indice) = Replace(CBFirmware(indice), " ", "`")
                        indice += 1

                        indicecksm += 1




                        Continue For
                    End If


                End If




            Next


            'Da verificare
            If (indice + 1 Mod 12) = 0 Then


                While CBFirmware(indice).ToString.Length <= 24
                    CBFirmware(indice) = CBFirmware(indice) & " "
                End While


            End If


            While CBFirmware(indice).ToString.Length <= 60
                CBFirmware(indice) = CBFirmware(indice) & " "
            End While


            While (indice + 2) Mod 12
                indice += 1
                CBFirmware(indice) = " "
                While CBFirmware(indice).ToString.Length <= 60
                    CBFirmware(indice) = CBFirmware(indice) & " "
                End While

            End While
            indice += 1
            CBFirmware(indice) = " "
            While CBFirmware(indice).ToString.Length <= 24
                CBFirmware(indice) = CBFirmware(indice) & " "
            End While


        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        If Not IsNothing(input) Then input.Close()
    End Sub
    Public Function ConvertToUU(ByVal Primo, ByVal Secondo, ByVal Terzo) As String

        Dim lil As Long = Primo * 65536 + Secondo * 256 + Terzo



        Dim stringa As String
        stringa = Convert.ToChar(((lil And 16515072) \ 262144) + 32)
        stringa = stringa & Convert.ToChar(((lil And 258048) \ 4096) + 32)
        stringa = stringa & Convert.ToChar(((lil And 4032) \ 64) + 32)
        stringa = stringa & Convert.ToChar(((lil And 63)) + 32)


        Return stringa

    End Function


    Public Function DeConvertToUU(ByVal Primo, ByVal Secondo, ByVal Terzo, ByVal Quarto) As String

       


        Primo = Asc(Primo) - 32
        Secondo = Asc(Secondo) - 32
        Terzo = Asc(Terzo) - 32
        Quarto = Asc(Quarto) - 32

        Dim lil As Long = Primo * 262144 + Secondo * 4096 + Terzo * 64 + Quarto



        Dim stringa As String
        stringa = CInt((lil And 16711680) \ 65536) & "-"
        stringa = stringa & CInt((lil And 65280) \ 256) & "-"
        stringa = stringa & CInt((lil And 255) \ 64)



        Return stringa

    End Function


    Sub LeggiProgramma(ByVal Filename As String)
        Dim input As New FileStream(Filename, FileMode.Open)
        Try


            Dim reader As New BinaryReader(input)
            Dim bytes2() As Byte
            For i As Integer = 0 To ProgrammaFinale.Length - 1 Step +1
                ProgrammaFinale(i) = ""
            Next
            bytes2 = reader.ReadBytes(CInt(input.Length))
            Dim lil As String
            totbyte = -1
            For lol As Integer = 0 To bytes2.Count - 1 Step +1
                If lol Mod 256 = 0 Then
                    totbyte += 1
                End If
                lil = Hex(bytes2(lol))
                If lil.Length = 1 Then lil = "0" & lil
                ProgrammaFinale(totbyte) = ProgrammaFinale(totbyte) & lil
            Next


            If ProgrammaFinale(totbyte).Length <> 512 Then
                While ProgrammaFinale(totbyte).Length < 512
                    ProgrammaFinale(totbyte) = ProgrammaFinale(totbyte) & "0"
                End While

            End If



        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        input.Close()
    End Sub


    'accelerometro
    Sub RAccelerometro()
        Try
            Dim temp() As String

            temp = Split(RDW_Command("R11"), "|")
            GAccel = temp(0)
            YAccel = temp(1)


        Catch ex As Exception
            AggiornaLog(ex)
        End Try



    End Sub
    Sub WAccelerometro(ByVal modo As Integer)
        Try


            Dim temp(2) As String



            Select Case modo
                Case 0
                    temp(0) = RDW_Command("Z100")
                Case 1
                    temp(0) = RDW_Command("Z101")
                Case 2
                    temp(0) = RDW_Command("Z102")
                Case 3
                    temp(0) = RDW_Command("Z103")
                Case 4
                    temp = Split(RDW_Command("W11", GAccel & "|" & YAccel), "|")
                    GAccel = temp(0)
                    YAccel = temp(1)

            End Select
            RDW_Command("L02")
        Catch ex As Exception
            AggiornaLog(ex)
        End Try

    End Sub
    Sub RAdvanced()
        Try
          

            NewFM = RDW_Command("R0B", 14)
            NewPR = RDW_Command("R0B", 15)
            CurFM = RDW_Command("R0B", 16)
            CurPR = RDW_Command("R0B", 17)
            NTel = RDW_Command("R0B", 18)




        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub
    Sub WAdvanced()
        Try
          

            NewFM = RDW_Command("W0B", 14, NewFM)
            NewPR = RDW_Command("W0B", 15, NewPR)
            CurFM = RDW_Command("W0B", 16, CurFM)
            CurPR = RDW_Command("W0B", 17, CurPR)
            NTel = RDW_Command("W0B", 18, NTel)

            RDW_Command("L02")



        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub



    Sub MDTRConnessione()
        Try

     
            Host = RDW_Command("R0B", 0)

            Dir = RDW_Command("R0B", 1)

            User = RDW_Command("R0B", 2)

            Code = RDW_Command("R0B", 3)

            Psw = RDW_Command("R0B", 4)

            Port = RDW_Command("R08", "1395")





        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub
    Sub MDTWConnessione()
        Try



            Host = RDW_Command("W0B", 0, Host) '0

            Dir = RDW_Command("W0B", 1, Dir) '1

            User = RDW_Command("W0B", 2, User) '2

            Code = RDW_Command("W0B", 3, Code) '3

            Psw = RDW_Command("W0B", 4, Psw) '4

            Port = RDW_Command("W08", "1395", Port)



            RDW_Command("L02")


        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub
End Module
