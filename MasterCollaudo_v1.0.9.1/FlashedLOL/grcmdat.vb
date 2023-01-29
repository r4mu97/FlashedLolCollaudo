Imports System.IO.Ports
Imports System.IO
Imports System.Net.Sockets
Imports System.Text


Partial Public Class Comandi_AT



    Public Enum GR_DEV
        NULL = -1
        MDT = 1
        MDC = 1 << 1
        ETSA1 = 1 << 2
        ETSB1 = 1 << 3
        EPS = 1 << 4
        BEACON = 1 << 5
        ETSDN = 1 << 6
        ETSCARTELLINO = 1 << 7
    End Enum

    Public Property forceQuitCMD As Boolean
        Get
            Return _forceQuitCMD
        End Get
        Set(value As Boolean)
            _forceQuitCMD = value
        End Set
    End Property

    Public CONN_DEV As GR_DEV = GR_DEV.NULL

    Const def_checkSyncStackOverflow As Integer = 5
    Const maxCanErrors As Integer = 2
    Public Const dllVersion As String = "2.10A"
    Public _forceQuitCMD As Boolean = False
    Public deviceFilter As Boolean = False
    Private _devType As Integer
    ''' <summary>
    ''' inserire un GR_DEV (o una maschera di GR_DEV) valido
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property deviceFilterType As Integer
        Get
            Return _devType
        End Get
        Set(value As Integer)
            _devType = value
        End Set
    End Property

    '    Public TORECONNECT As Boolean = False

    '    Public minSupportedVersion As Integer
    '    Public MAXSupportedVersion As Integer
    '    Public minMDCSupportedVersion As Integer

    '    Public SKIPLO As Boolean = False
    '    Public tcon
    '    Dim Tentativi As Integer = 0
    '    Dim networkstream As NetworkStream
    '    Public tcpClient As Socket

    '    Public StopLoad As Boolean = False
    '    Public CBPerSinc As Boolean '= True
    '    Public LavoraChiamataDati As Boolean
    '    Public LavoraCan As Boolean
    '    Public LavoraOffline As Boolean
    '    Public LavoraHTTP As Boolean
    '    Public LavoraRETE_CAN As Boolean
    '    Public usaDefConfig As Boolean
    '    Public PathConfigurazione As String
    '    Public ttx, trx As Integer
    '    Public Ping As Integer
    '    Public SINCERR As Integer
    '    Public ONLYMDC As Boolean
    '    Public BootloaderModePP As Integer
    '    Public SerialNumber As String
    '    Public HW_Info As String
    '    Public HWSetup As String
    '    Public VERSIONECONNESSA As String
    '    Public VersioneFirmware As String

    '    Public logComandi As Boolean = False

    '    Public sending_cmd As Boolean = False
    '    Private checkinSync As Boolean = False

    '    Private checkSyncStackOverflow As Integer = def_checkSyncStackOverflow

    '    Public Shared ss As New StatusStrip
    '    Public wt4CD As New Stopwatch

    '    Public portaMirror As SerialPort = Nothing

    '    Public SaveToFIle As Boolean = False
    '    Public fileName As String = ""

    '    Public SerialPortModem As New SerialPort With {.BaudRate = 115200, .DataBits = 8, .DtrEnable = True, .Handshake = Handshake.RequestToSend, .Parity = Parity.None, .ReadTimeout = 500, .RtsEnable = True}
    '    Public SerialPortUart As New SerialPort With {.BaudRate = 230400, .DataBits = 8, .Handshake = Handshake.None, .Parity = Parity.None, .ReadTimeout = 3000, .StopBits = StopBits.One}


    '    Public trolololololol = 0, trololololololsocket = 0, trololololololcan = 0



    '    Private Sub writelog(ByVal stringa)
    '        Try

    '            If stringa.contains("R00") Then Return
    '            If stringa.contains("R01") Then Return
    '            If stringa.contains("L02") Then Return

    '            Dim namefile As String = Application.StartupPath & "\logComandi.txt"
    '            Dim alltext As String = ""
    '            If Not File.Exists(namefile) Then
    '                Dim a = File.Create(namefile)
    '                a.Close()
    '            End If
    '            Using rd As StreamReader = New StreamReader(namefile)
    '                alltext = rd.ReadToEnd
    '            End Using
    '            Using sw As StreamWriter = New StreamWriter(namefile)

    '                sw.WriteLine(stringa)
    '                sw.WriteLine(alltext)
    '            End Using
    '        Catch ex As Exception

    '        End Try
    '    End Sub

    '    Public ReadOnly Property CheckSyncSupported As Boolean
    '        Get
    '            Dim oldCheck As Boolean = CBPerSinc
    '            CBPerSinc = True
    '            checkinSync = True
    '            Wait(500)
    '            Dim str As String = RDW_Command("R00")
    '            Dim ret As Boolean = (str.Length > 2 AndAlso Not str.Equals("KO") AndAlso Not str.Equals("?"))
    '            CBPerSinc = oldCheck
    '            checkinSync = False
    '            Return ret
    '        End Get
    '    End Property


    '    Public Function RDW_Command(ByVal Comando As String, Optional ByVal Offset As String = "", Optional ByVal Value As String = "",
    '                              Optional ByVal ErrorEnable As Boolean = False, Optional ByVal ReadFloat As Boolean = False, Optional ByVal FIND As String = "",
    '                              Optional ByVal customTimeout As Integer = 3000, Optional ByVal NodoCAN As Integer = -1) As String
    ''        'Dim errore As Integer = 0
    '    '        If StopLoad = True Then Return ""
    '    '        _forceQuitCMD = False
    '    '        Tentativi = 0

    '    '        sending_cmd = True

    '    '        Dim Stringa As String
    '    '        Dim Porta As SerialPort = Nothing
    '    '        Dim MyRnd As New Random
    '    '        Dim CheckRisp As String = ""

    '    '        wt4CD.Reset()




    '    '        If Len(Offset) > 0 Then Offset = " " & Offset
    '    '        If Len(Value) > 0 Then Value = " " & Value
    '    '        If ReadFloat Then Value = Replace(Value, GetSeparator(), ".")
    '    '        Dim Risposta As String = ""
    '    '        If CBPerSinc Then
    '    '            CheckRisp = "~C:" & MyRnd.Next(100)
    '    '        End If

    '    '        'la terminazione di stringa DEVE essere SOLO \r tranne per il bus CAN (gestito nell'apposita funzione)
    '    '        Stringa = "$" & Comando & Offset & Value & CheckRisp & " " & vbCr

    '    '        If NodoCAN >= 0 Then Stringa = "$R0R " & NodoCAN & Stringa

    '    '        If logComandi Then writelog(Stringa)

    '    '        If SaveToFIle Then
    '    '            Try
    '    '                If Stringa.Contains("L02") Or (Comando.StartsWith("R") And Not Comando.StartsWith("R0R")) Then
    '    '                    sending_cmd = False
    '    '                    Return ""
    '    '                End If

    '    '                Dim AllExpFile As String = ""
    '    '                Using sw As StreamReader = New StreamReader(fileName)

    '    '                    AllExpFile = sw.ReadToEnd

    '    '                End Using
    '    '                Using sw As StreamWriter = New StreamWriter(fileName)
    '    '                    If (CheckRisp.Length <> 0) Then
    '    '                        Stringa = Stringa.Replace(CheckRisp, "")
    '    '                    End If
    '    '                    sw.Write(AllExpFile & Stringa & vbLf)
    '    '                End Using
    '    '                '            If Not Value = "" Then If Value.Length > 1 And Value.First = " " Then Risposta = Value.Remove(0, 1) Else Risposta = Value
    '    '                If ReadFloat Then Value = Replace(Value, ".", GetSeparator())
    '    '                sending_cmd = False
    '    '                Return Trim(Value)

    '    '            Catch ex As Exception
    '    '                AggiornaLog(ex)
    '    '            End Try
    '    '            Throw New Exception("Scrittura su file fallita")
    '    '        End If




    '    '        Try

    '    '            If LavoraChiamataDati = True Then
    '    '                Porta = SerialPortModem

    '    '            ElseIf LavoraCan = True Then
    '    '                ' Porta = SerialPortModem
    '    '                Porta = SerialPortUart
    '    '                'ElseIf LavoraOffline = True Then
    '    '                '    Risposta = InterrogaConf(Stringa)

    '    '                '    If Risposta = "Scritto" Then
    '    '                '        sending_cmd = False
    '    '                '        Return Trim(Replace(Value, "" & vbCr & "", ""))
    '    '                '    Else
    '    '                '        sending_cmd = False
    '    '                '        Return Trim(Replace(Risposta, "" & vbCr & "", ""))
    '    '                '    End If

    '    '            ElseIf LavoraHTTP Then
    '    '                Risposta = RDW_Command_Socket(Stringa, , , ErrorEnable, ReadFloat)
    '    '                GoTo DopoRisposta

    '    '            ElseIf LavoraRETE_CAN Then
    '    '                Risposta = RDW_Command_CAN(Stringa, ErrorEnable, ReadFloat, customTimeout, NodoCAN)
    '    '                GoTo DopoRisposta

    '    '            End If

    '    '            portaMirror = Porta

    '    '            ttx = 5
    '    '            If Not IsNothing(Porta) AndAlso Not Porta.IsOpen Then
    '    '                TORECONNECT = True
    '    '                Try
    '    '                    Porta.Open()

    '    '                Catch ' e As Exception
    '    '                    trolololololol = 0

    '    '                    sending_cmd = False
    '    '                    Return "REMOVED"
    '    '                End Try
    '    '            Else
    '    '                If TORECONNECT = True Then
    '    '                    Return "REMOVED"

    '    '                End If
    '    '            End If


    '    '            If IsNothing(Porta) Then
    '    '                Return "KO"
    '    '            End If

    '    '            'Tentativi += 1



    '    '            wt4CD.Start()


    '    '            If Not IsNothing(tcon) Then
    '    '                While tcon.Status = TaskStatus.Running
    '    '                    Application.DoEvents()
    '    '                    System.Threading.Thread.Sleep(1)
    '    '                End While
    '    '            End If
    '    '            Dim t_o As New Stopwatch
    '    '            t_o.Reset()
    '    '            t_o.Start()
    '    '            While trolololololol = 1
    '    '                If t_o.ElapsedMilliseconds > Porta.ReadTimeout Then
    '    '                    sending_cmd = False
    '    '                    Return "Errore-Timeout"
    '    '                End If
    '    '                Application.DoEvents()
    '    '                System.Threading.Thread.Sleep(1)
    '    '            End While

    '    '            trolololololol = 1

    '    '            Porta.DiscardOutBuffer()
    '    '            Porta.DiscardInBuffer()
    '    '            Porta.Write(Stringa)
    '    '            If customTimeout <= 0 Then
    '    '                Porta.ReadTimeout = Ports.SerialPort.InfiniteTimeout
    '    '            Else
    '    '                Porta.ReadTimeout = customTimeout
    '    '            End If


    '    '            tcon = New Task(Of String)(Function()
    '    '                                           Try
    '    '                                               Dim temp As String = ""
    '    '                                               Dim Temp1 As String = ""
    '    '                                               If FIND = "" Then
    '    '                                                   temp = Porta.ReadLine()
    '    '                                               ElseIf FIND = "FPFUNC" Then
    '    '                                                   Porta.ReadTimeout = 500
    '    '                                                   While Not _forceQuitCMD
    '    '                                                       Try
    '    '                                                           If Temp1.Contains(vbCr) Then
    '    '                                                               Exit While
    '    '                                                           End If
    '    '                                                           Temp1 = Porta.ReadLine
    '    '                                                           temp = temp & Temp1
    '    '                                                       Catch
    '    '                                                       End Try
    '    '                                                   End While
    '    '                                                   FIND = ""
    '    '                                                   If _forceQuitCMD Then CBPerSinc = False
    '    '                                               Else
    '    '                                                   Porta.ReadTimeout = 10000
    '    '                                                   While 1
    '    '                                                       Temp1 = Porta.ReadLine
    '    '                                                       temp = temp & Temp1
    '    '                                                       If Temp1.Contains(FIND) Then
    '    '                                                           Exit While
    '    '                                                       End If

    '    '                                                   End While

    '    '                                               End If
    '    '                                               Return temp.ToString

    '    '                                           Catch ex As Exception
    '    '                                               Return "Errore-Timeout"
    '    '                                           End Try

    '    '                                       End Function)


    '    '            'If Porta.BytesToRead > 0 Then
    '    '            '    Porta.DiscardInBuffer()
    '    '            'End If
    '    '            tcon.Start()

    '    '            While (Not tcon.IsCompleted)
    '    '                Application.DoEvents()
    '    '                System.Threading.Thread.Sleep(1)
    '    '            End While
    '    '            trolololololol = 0
    '    '            If tcon.Result = "Errore-Timeout" Then
    '    '                Tentativi += 1
    '    '                trolololololol = 0

    '    '                If Tentativi > 5 Or ErrorEnable Then
    '    '                    sending_cmd = False
    '    '                    Return "KO"
    '    '                Else
    '    '                    sending_cmd = False
    '    '                    Return "KO"
    '    '                End If



    '    '            End If
    '    '            ' tcon.Dispose()
    '    '            trx = 5
    '    '            Risposta = tcon.Result
    '    '            Porta.DiscardOutBuffer()
    '    '            Porta.DiscardInBuffer()
    '    '            wt4CD.Stop()
    '    '            Ping = wt4CD.ElapsedMilliseconds
    '    '            wt4CD.Reset()


    '    'DopoRisposta:
    '    '            If TORECONNECT Then Return ""

    '    '            If CBPerSinc And Risposta <> "KO" And Risposta <> "CAN-KO" And Risposta <> "Errore-Timeout" Then
    '    '                If Not Risposta.Contains(CheckRisp) Then
    '    '                    If checkSyncStackOverflow < 0 Then
    '    '                        trolololololol = 0
    '    '                        Return "KO"
    '    '                    End If
    '    '                    checkSyncStackOverflow -= 1
    '    '                    If checkinSync Then Return ""
    '    '                    Wait(1000)
    '    '                    SINCERR = SINCERR + 1
    '    '                    trolololololol = 0
    '    '                    sending_cmd = False
    '    '                    Return RDW_Command(Comando, Offset, Value, ErrorEnable, ReadFloat)
    '    '                End If
    '    '                checkSyncStackOverflow = def_checkSyncStackOverflow
    '    '                Risposta = Risposta.Replace(CheckRisp, "")

    '    '            End If



    '    '            'Tentativi = 0



    '    '            If FIND = "" Then
    '    '                Risposta = Trim(Replace(Risposta, "" & vbCr & "", ""))
    '    '                If ReadFloat Then Risposta = Replace(Risposta, ".", GetSeparator())

    '    '            End If

    '    '            Tentativi = 0
    '    '        Catch ex As Exception
    '    '            trolololololol = 0
    '    '            sending_cmd = False
    '    '            Return "KO"
    '    '        End Try
    '    '        trolololololol = 0

    '    '        sending_cmd = False
    '    '        Return Risposta


    '    '    End Function

    '    Public Function GetSeparator()
    '        Dim DC As Decimal
    '        Dim Sep As String
    '        DC = 0.5
    '        Sep = Microsoft.VisualBasic.Mid(DC.ToString, 2, 1)

    '        Return Sep

    '    End Function
    '    Private Function RDW_Command_Socket(ByVal Stringa As String, Optional ByVal Offset As String = "", Optional ByVal Value As String = "", Optional _
    '                              ByVal ErrorEnable As Boolean = False, Optional ByVal ReadFloat As Boolean = False) As String

    '        Dim wt4CD As New Stopwatch
    '        wt4CD.Reset()

    '        Dim Risposta As String = ""

    '        'If Not Stringa.EndsWith(vbLf) Then Stringa = Stringa & vbLf
    '        'Console.WriteLine("writing " & Stringa)

    '        Try
    '            Tentativi += 1
    '            wt4CD.Start()
    '            ttx = 5
    '            If Not IsNothing(tcon) Then
    '                While tcon.Status = TaskStatus.Running
    '                    Application.DoEvents()
    '                    System.Threading.Thread.Sleep(1)
    '                End While
    '            End If
    '            While networkstream.DataAvailable
    '                Dim bytesRX(tcpClient.ReceiveBufferSize) As Byte
    '                networkstream.Read(bytesRX, 0, CInt(tcpClient.ReceiveBufferSize))
    '                Risposta = Encoding.ASCII.GetString(bytesRX)
    '            End While

    '            Dim t_o As New Stopwatch
    '            t_o.Reset()
    '            t_o.Start()
    '            While trololololololsocket = 1
    '                If t_o.ElapsedMilliseconds > networkstream.ReadTimeout Then
    '                    sending_cmd = False
    '                    Return "Errore-Timeout"
    '                End If
    '                Application.DoEvents()
    '            End While

    '            trololololololsocket = 1


    '            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(Stringa)
    '            networkstream.Write(sendBytes, 0, sendBytes.Length)
    '            networkstream.ReadTimeout = 15000
    '            tcon = New Task(Of String)(Function()
    '                                           Try
    '                                               Risposta = ""
    '                                               Dim oldLen As Integer = Risposta.Length
    '                                               Dim timeout As New Stopwatch
    '                                               timeout.Reset()
    '                                               timeout.Start()

    '                                               While (Not Risposta.EndsWith(vbCrLf) And timeout.ElapsedMilliseconds < networkstream.ReadTimeout) And Not _forceQuitCMD
    '                                                   Dim bytesRX(tcpClient.ReceiveBufferSize) As Byte
    '                                                   networkstream.Read(bytesRX, 0, CInt(tcpClient.ReceiveBufferSize))

    '                                                   Risposta &= Encoding.ASCII.GetString(bytesRX).Replace(vbNullChar, "")
    '                                                   'Console.WriteLine("read  " & Risposta)
    '                                                   If Risposta.Length > oldLen Then
    '                                                       oldLen = Risposta.Length
    '                                                       timeout.Restart()
    '                                                   End If

    '                                               End While
    '                                               ' Console.WriteLine("exit while")

    '                                               Return String.Format(Risposta)
    '                                           Catch ioex As IOException
    '                                               TORECONNECT = True
    '                                               Return "KO"
    '                                           Catch ex As Exception
    '                                               Return "Timeout"
    '                                           End Try

    '                                       End Function)



    '            tcon.Start()

    '            While (Not tcon.IsCompleted)
    '                Application.DoEvents()
    '                System.Threading.Thread.Sleep(1)
    '            End While
    '            trololololololsocket = 0


    '            If tcon.Result = "Timeout" Then
    '                trololololololsocket = 0
    '                Return "KO"
    '            End If
    '            ' tcon.Dispose()
    '            trx = 5
    '            Risposta = tcon.Result



    '            wt4CD.Stop()
    '            Ping = wt4CD.ElapsedMilliseconds
    '            wt4CD.Reset()
    '            'Tentativi = 0



    '            Dim temp() As String = Split(Risposta, "" & vbCrLf & "")
    '            Risposta = Trim(temp(0))
    '            If ReadFloat Then Risposta = Replace(temp(0), ".", GetSeparator())
    '            Tentativi = 0


    '            ' Console.WriteLine("return  " & Risposta)
    '            Return Risposta
    '        Catch ioex As IOException
    '            trololololololsocket = 0
    '            TORECONNECT = True
    '            Return ""
    '        Catch ex As Exception
    '            trololololololsocket = 0
    '            TORECONNECT = True
    '            Return ""
    '        End Try

    '        trololololololsocket = 0


    '    End Function



    'Public Function RDW_Command_CAN(ByVal Comando As String,
    '                          Optional ByVal ErrorEnable As Boolean = False, Optional ByVal ReadFloat As Boolean = False,
    '                          Optional ByVal customTimeout As Integer = 3000, Optional ByVal NodoCAN As Integer = -1) As String



    '    If Not CAN_INITIALIZED Then
    '        'inizializzazione default
    '        destCanNode = DevicesNodes(0)
    '        If Not init_CAN(PCANBasic.PCAN_USBBUS1, TPCANBaudrate.PCAN_BAUD_500K) Then Return "KO"
    '    End If


    '    If StopLoad = True Then Return ""
    '    Dim Tentativi = 0

    '    Dim MyRnd As New Random
    '    Dim CheckRisp As String = ""
    '    Dim infiniteTimeout As Boolean = (customTimeout <= 0)
    '    Dim risposta As String = "KO"

    '    wt4CD.Reset()


    '    Try

    '        Dim t_o As New Stopwatch
    '        t_o.Reset()
    '        t_o.Start()
    '        While trololololololcan = 1
    '            If t_o.ElapsedMilliseconds > customTimeout Then
    '                sending_cmd = False
    '                Return "Errore-Timeout"
    '            End If
    '            Application.DoEvents()
    '            System.Threading.Thread.Sleep(1)
    '        End While

    '        trololololololcan = 1


    '        If Not IsNothing(tcon) Then
    '            While tcon.Status = TaskStatus.Running
    '                Application.DoEvents()
    '                System.Threading.Thread.Sleep(1)
    '            End While
    '        End If


    '        'Sul bus CAN è necessaria la terminazione \r(già presente) + \n
    '        Comando &= vbLf

    '        tcon = New Task(Of String)(Function()
    '                                       Try

    '                                           Dim msgs As TPCANMsg() = getCANserialMessage(Comando, destCanNode).ToArray()

    '                                           'invio il comando
    '                                           For Each msg In msgs
    '                                               PCANBasic.Write(currentChannel, msg)
    '                                           Next


    '                                           Dim timerOut As New Stopwatch
    '                                           timerOut.Start()
    '                                           Dim risp As String = ""
    '                                           Dim errorCounter As Integer = 0

    '                                           'attendo la risposta
    '                                           While whileCondy(infiniteTimeout, risp, timerOut, customTimeout)

    '                                               Dim gnuMsg As New TPCANMsg
    '                                               Dim rResult = PCANBasic.Read(currentChannel, gnuMsg)

    '                                               If rResult = Peak.Can.Basic.TPCANStatus.PCAN_ERROR_OK AndAlso
    '                                                            Not idRefused(gnuMsg.ID) AndAlso
    '                                                            msgIsForMe(gnuMsg.ID) Then

    '                                                   errorCounter = 0

    '                                                   Dim ciar As Byte = gnuMsg.ID And &HFF
    '                                                   If (ciar < 32 Or ciar > 127) And Not (ciar = Asc(vbCr) Or ciar = Asc(vbLf)) Then Continue While
    '                                                   risp &= Chr(ciar)

    '                                               ElseIf rResult <> Peak.Can.Basic.TPCANStatus.PCAN_ERROR_QRCVEMPTY And
    '                                                                    rResult <> Peak.Can.Basic.TPCANStatus.PCAN_ERROR_QRCVEMPTY And
    '                                                                    rResult <> Peak.Can.Basic.TPCANStatus.PCAN_ERROR_OK Then

    '                                                   'TODO rilevare assenza dispositivo in CAN
    '                                                   '  If errorCounter > maxCanErrors Then
    '                                                   'risp = "CAN-KO"
    '                                                   'Exit While
    '                                                   ' Else
    '                                                   '  errorCounter += 1
    '                                                   ' End If
    '                                               Else
    '                                                   errorCounter = 0
    '                                               End If

    '                                           End While

    '                                           If timerOut.ElapsedMilliseconds >= customTimeout And Not risp.Contains(vbCrLf) Then Throw New Exception("timeout")

    '                                           Return risp.Replace(vbNullChar, "").Replace(vbCr, "").Replace(vbLf, "")


    '                                       Catch ex As Exception
    '                                           Return "KO"
    '                                       End Try

    '                                       Return "KO"
    '                                   End Function)



    '        wt4CD.Start()
    '        tcon.Start()

    '        While (Not tcon.IsCompleted)
    '            Application.DoEvents()
    '            System.Threading.Thread.Sleep(1)
    '        End While
    '        trololololololcan = 0
    '        If tcon.Result = "Errore-Timeout" Then
    '            Tentativi += 1
    '            trololololololcan = 0

    '            If Tentativi > 5 Or ErrorEnable Then
    '                sending_cmd = False
    '                Return "KO"
    '            Else
    '                sending_cmd = False
    '                Return "KO"
    '            End If



    '        End If
    '        tcon.Dispose()
    '        trx = 5
    '        risposta = tcon.Result

    '        wt4CD.Stop()
    '        Ping = wt4CD.ElapsedMilliseconds
    '        wt4CD.Reset()



    '    Catch ex As Exception
    '        sending_cmd = False
    '        Return "KO"
    '    End Try

    '    sending_cmd = False
    '    Return risposta

    'End Function




    'Private Function msgIsForMe(ByVal id As Integer) As Boolean
    '    Try

    '        Dim destAddr As Byte = id >> 8 And &HFF

    '        If destAddr = Comandi_AT.myID Then Return True

    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try
    '    Return False
    'End Function




    'Private Function whileCondy(infiniteTimeout As Boolean, risp As String, timerOut As Stopwatch, customTimeout As Integer) As Boolean
    '    If infiniteTimeout Then
    '        Return Not risp.Contains(vbCrLf)
    '    Else
    '        Return Not risp.Contains(vbCrLf) And (timerOut.ElapsedMilliseconds < customTimeout)
    '    End If
    'End Function





    'Public Function ConnectToMDTvolante(ByVal ip As String, Optional ByVal porta As String = "300")
    '    Try


    '        tcpClient = New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp)
    '        tcpClient.ReceiveTimeout = 10000
    '        tcpClient.Connect(ip, porta)

    '        networkstream = New NetworkStream(tcpClient)

    '        Dim bytesRX(tcpClient.ReceiveBufferSize) As Byte
    '        networkstream.Read(bytesRX, 0, CInt(tcpClient.ReceiveBufferSize))
    '        Dim risposta = Encoding.ASCII.GetString(bytesRX)
    '        If risposta.Contains("HELLO") Then
    '            Return "OK"
    '        Else
    '            networkstream.Close()
    '            tcpClient.Close()

    '            Return "KO"
    '        End If

    '    Catch ex As Exception
    '        AggiornaLog(ex)

    '        tcpClient.Close()
    '        Return "KO"
    '    End Try
    'End Function


    ''Public Function InterrogaConf(ByVal Stringa As String)
    ''    Try
    ''        Dim Path As String
    ''        Dim StringaTrovata As String
    ''        Dim temp(), temp1() As String
    ''        Dim Trovato = False
    ''        Dim corrispondenza As Integer
    ''        Dim alltext As String = ""

    ''        If usaDefConfig Then
    ''            Path = Application.StartupPath & "\Conf\ConfBase.cnf"
    ''        Else
    ''            Path = PathConfigurazione
    ''        End If

    ''        Stringa = Trim(Replace(Stringa, "" & vbCr & "", ""))
    ''        temp = Split(Stringa.TrimEnd(" "), " ")



    ''        If Not SKIPLO Then
    ''            'GESTIONE COMANDI NON PRESENTI NEL FILE CONF
    ''            If Stringa.Contains("$R20") Then
    ''                Return "50|60|60"
    ''            ElseIf Stringa.Contains("$L02") Then
    ''                Return ""
    ''            ElseIf Stringa.Contains("$R40") Then
    ''                Return "NON DISPONIBILE"
    ''            ElseIf Stringa.Contains("R22 1") Then
    ''                Stringa = ""

    ''                For i As Integer = 0 To 59
    ''                    Stringa = Stringa & i & "|" & i + 1 & "|" & InterrogaConf("$R21 1 " & i) & "_"
    ''                Next

    ''                Return Stringa.TrimEnd("_")
    ''            ElseIf Stringa.Contains("R22 3") Then
    ''                Stringa = ""

    ''                For i As Integer = 0 To 59
    ''                    Stringa = Stringa & i & "|" & i + 1 & "|" & InterrogaConf("$R21 3 " & i) & "_"
    ''                Next

    ''                Return Stringa.TrimEnd("_")

    ''            ElseIf Stringa.Contains("R22 0") Then
    ''                Stringa = ""

    ''                For i As Integer = 0 To 59
    ''                    Stringa = Stringa & i & "|" & i + 1 & "|" & InterrogaConf("$R21 0 " & i) & "_"
    ''                Next

    ''                Return Stringa.TrimEnd("_")
    ''            ElseIf Stringa.Contains("O61") Then
    ''                Return "NON DISPONIBILE"
    ''            ElseIf Stringa.Contains("R73") Then
    ''                SKIPLO = True
    ''                Dim tempr73 As String = ""
    ''                For i As Integer = 0 To 8
    ''                    tempr73 = tempr73 & InterrogaConf(Stringa & " " & i) & "*"
    ''                Next
    ''                SKIPLO = False
    ''                Return tempr73
    ''            ElseIf Stringa.Contains("W70") Then
    ''                Using SW As StreamReader = New StreamReader(Path)
    ''                    alltext = SW.ReadToEnd()
    ''                End Using
    ''                Dim tempw70() = Split(Stringa, " ")


    ''                If Not alltext.Contains(tempw70(0) & " " & tempw70(1)) Then
    ''                    Using SW As StreamWriter = New StreamWriter(Path)
    ''                        SW.Write(alltext)
    ''                        SW.WriteLine(Stringa)

    ''                    End Using
    ''                    InterrogaConf(Stringa)
    ''                End If
    ''            ElseIf (temp(0) = "$W08" Or temp(0) = "$W0A" Or temp(0) = "$W0A") And (temp(1) >= 12500 And temp(1) <= 32500) Then

    ''                Using SW As StreamReader = New StreamReader(Path)
    ''                    alltext = SW.ReadToEnd()
    ''                End Using


    ''                If Not alltext.Contains(temp(0) & " " & temp(1)) Then



    ''                    Using SW As StreamReader = New StreamReader(Path)
    ''                        alltext = SW.ReadToEnd()
    ''                    End Using
    ''                    Using SW As StreamWriter = New StreamWriter(Path)
    ''                        SW.Write(alltext)
    ''                        SW.WriteLine(Stringa)
    ''                    End Using
    ''                    InterrogaConf(Stringa)
    ''                End If

    ''            End If

    ''        End If




    ''        If Stringa.Contains("$W") Then



    ''            Using SW As StreamReader = New StreamReader(Path)
    ''                alltext = SW.ReadToEnd()

    ''            End Using
    ''            Dim alltextsplittato = Split(alltext.Replace("" & vbCr & "", ""), vbLf)

    ''            Dim limite As Integer = 0
    ''            Dim MatchRichiesti As Integer = 0

    ''            limite = alltextsplittato.Count - 1


    ''            For b As Integer = 0 To limite Step +1

    ''                temp1 = Split(alltextsplittato(b), " ")
    ''                corrispondenza = 0
    ''                For i As Integer = 0 To Math.Min(temp1.Count, temp.Count) - 1 Step +1
    ''                    If temp(i) = temp1(i) Then
    ''                        corrispondenza += 1
    ''                        If corrispondenza = temp.Count - MatchRichiesti Then

    ''                            alltextsplittato(b) = ""
    ''                            For c As Integer = 0 To temp.Count - 1
    ''                                alltextsplittato(b) = alltextsplittato(b) & " " & temp(c)
    ''                            Next

    ''                            Trovato = True

    ''                        End If
    ''                    Else
    ''                        Exit For
    ''                    End If
    ''                Next

    ''                '  
    ''                If b = limite - 1 And Trovato = False Then
    ''                    limite = alltextsplittato.Count - 1
    ''                    b = -1
    ''                    MatchRichiesti += 1
    ''                    If MatchRichiesti = 2 Then Exit For
    ''                End If
    ''            Next


    ''            Using SW As StreamWriter = New StreamWriter(Path)
    ''                For Each lol In alltextsplittato
    ''                    If lol = "" Then Continue For
    ''                    SW.WriteLine(Trim(lol))
    ''                Next
    ''                If Trovato = False Then

    ''                    SW.WriteLine(Stringa.Replace("$R", "$W"))


    ''                End If
    ''            End Using

    ''            Return mui.Get_String_From_Tag("AT8", "scritto")

    ''        End If

    ''        Stringa = Stringa.Replace("$R", "$W")


    ''        Using SW As StreamReader = New StreamReader(Path)
    ''            Trovato = False
    ''            StringaTrovata = ""
    ''            Do Until SW.EndOfStream

    ''                StringaTrovata = SW.ReadLine

    ''                temp1 = Split(StringaTrovata, " ")
    ''                temp = Split(Stringa, " ")


    ''                corrispondenza = 0

    ''                For i As Integer = 0 To temp.Count - 1 Step +1

    ''                    If temp(i) = temp1(i) Then
    ''                        corrispondenza += 1
    ''                        If corrispondenza = temp.Count Then
    ''                            StringaTrovata = StringaTrovata.Replace(Stringa, "")
    ''                            StringaTrovata = StringaTrovata.Trim
    ''                            Trovato = True
    ''                            Exit Do
    ''                        End If
    ''                    Else : Exit For
    ''                    End If

    ''                Next


    ''            Loop

    ''        End Using
    ''        If Trovato = True Then
    ''            Return StringaTrovata
    ''        Else

    ''            Using SW As StreamReader = New StreamReader(Path)
    ''                alltext = SW.ReadToEnd()
    ''            End Using
    ''            Using SW As StreamWriter = New StreamWriter(Path)
    ''                SW.Write(alltext)
    ''                SW.WriteLine(Stringa)
    ''            End Using

    ''        End If




    ''        If Trovato = False Then
    ''            Return ""
    ''        End If
    ''        Return Stringa

    ''    Catch ex As Exception
    ''        AggiornaLog(ex)
    ''        Return ""
    ''    End Try






    ''End Function



    'Public Sub StatusMessage(messaggio As String, Optional ByVal pic As Image = Nothing, Optional ByVal isError As Boolean = False, Optional ByVal isWarning As Boolean = False, Optional ByVal isOk As Boolean = False)
    '    Try
    '        For i = 0 To ss.Items.Count - 1
    '            ss.Items.Item(i).Visible = False
    '        Next

    '        ss.Items.Item(1).Visible = True
    '        ss.Items.Item(1).Text = messaggio
    '        If pic IsNot Nothing Then
    '            ss.Items.Item(0).Text = Nothing
    '            ss.Items.Item(0).Visible = True
    '            ss.Items.Item(0).Image = pic
    '        ElseIf isError = True Then
    '            Try
    '                ss.Items.Item(0).Text = Nothing
    '                ss.Items.Item(0).Visible = True
    '                ss.Items.Item(0).Image = Image.FromFile(Application.StartupPath & "\icons\error")
    '            Catch ex As Exception
    '                Exit Sub
    '            End Try
    '        ElseIf isOk = True Then
    '            Try
    '                ss.Items.Item(0).Text = Nothing
    '                ss.Items.Item(0).Visible = True
    '                ss.Items.Item(0).Image = Image.FromFile(Application.StartupPath & "\icons\ok")
    '            Catch ex As Exception
    '                Exit Sub
    '            End Try
    '        ElseIf isWarning = True Then
    '            Try
    '                ss.Items.Item(0).Text = Nothing
    '                ss.Items.Item(0).Visible = True
    '                ss.Items.Item(0).Image = Image.FromFile(Application.StartupPath & "\icons\warning_ss")
    '            Catch ex As Exception
    '                Exit Sub
    '            End Try
    '        Else
    '            ss.Items.Item(0).Visible = False
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(messaggio)
    '    End Try
    'End Sub




    'Public Function RicercaCom() As String

    '    '        LavoraCan = True
    '    '        LavoraOffline = False
    '    '        LavoraChiamataDati = False
    '    '        LavoraHTTP = False
    '    '        LavoraRETE_CAN = False

    '    '        Dim modo_hack_1 As Boolean = False
    '    '        Dim ComClass As New System.Management.ManagementClass("Win32_Serialport")
    '    '        Dim ComCollection As System.Management.ManagementObjectCollection = ComClass.GetInstances()
    '    '        Dim Com As System.Management.ManagementObject
    '    '        Dim Porta As String

    '    '        If ComCollection.Count = 0 Then
    '    'loopPort:   modo_hack_1 = True
    '    '            ComClass = New System.Management.ManagementClass("Win32_PnPEntity")
    '    '            ComCollection = ComClass.GetInstances()
    '    '        End If


    '    '        For Each Com In ComCollection
    '    '            Dim comName = "COM1"
    '    '            Porta = Com("PNPDeviceID").ToString

    '    '            If modo_hack_1 Then
    '    '                If InStr(Com("Caption"), "(COM") = 0 Then Continue For

    '    '                Dim tmp_comName = Com("Caption").ToString()
    '    '                tmp_comName = tmp_comName.Substring(tmp_comName.IndexOf("COM"))
    '    '                For i = "COM".Length + 1 To tmp_comName.Length - 1
    '    '                    Dim testChar = tmp_comName.Substring(0, i)
    '    '                    If Not IsNumeric(testChar(testChar.Length - 1)) Then Exit For
    '    '                    comName = tmp_comName.Substring(0, i)
    '    '                Next
    '    '            Else
    '    '                comName = Com("deviceid").ToString()
    '    '            End If

    '    '            If Porta.Contains("10C4") And Porta.Contains("EA60") And Porta.Contains("MDTA1") Then
    '    '                Try
    '    '                    If deviceFilter AndAlso Not CBool(deviceFilterType And GR_DEV.MDT) Then Exit Try

    '    '                    If SerialPortUart.IsOpen Then
    '    '                        SerialPortUart.Close()
    '    '                    End If
    '    '                    Me.SerialPortUart.BaudRate = 115200
    '    '                    Me.SerialPortUart.PortName = comName
    '    '                    Me.SerialPortUart.Open()
    '    '                    CONN_DEV = GR_DEV.MDT
    '    '                    Return (Porta)
    '    '                Catch

    '    '                End Try

    '    '            End If



    '    '            If Porta.Contains("10C4") And Porta.Contains("EA60") And Porta.Contains("MDCA1") Then
    '    '                Try
    '    '                    If deviceFilter AndAlso Not CBool(deviceFilterType And GR_DEV.MDC) Then Exit Try

    '    '                    CONN_DEV = GR_DEV.MDC

    '    '                    If SerialPortUart.IsOpen Then
    '    '                        SerialPortUart.Close()
    '    '                    End If
    '    '                    Me.SerialPortUart.BaudRate = 115200
    '    '                    Me.SerialPortUart.Handshake = Handshake.None
    '    '                    Me.SerialPortUart.PortName = comName
    '    '                    Me.SerialPortUart.Open()
    '    '                    Return (Porta)
    '    '                Catch

    '    '                End Try

    '    '            End If

    '    '            If Porta.Contains("10C4") And Porta.Contains("EA60") And Porta.Contains("ETS") Then
    '    '                Try
    '    '                    If deviceFilter AndAlso Not CBool((CBool(deviceFilterType And GR_DEV.ETSA1)) Or (CBool(deviceFilterType And GR_DEV.ETSB1) And 1)) Then Exit Try

    '    '                    If Porta.Contains("ETSA1") Then 'ets advanced
    '    '                        CONN_DEV = GR_DEV.ETSA1
    '    '                        Me.SerialPortUart.BaudRate = 230400
    '    '                    ElseIf Porta.Contains("ETSB1") Then 'ets basic
    '    '                        CONN_DEV = GR_DEV.ETSB1
    '    '                        Me.SerialPortUart.BaudRate = 230400  'per ETSL nuova versione 2015, per il vecchio settare a 115200
    '    '                    Else
    '    '                        CONN_DEV = GR_DEV.ETSB1
    '    '                        Me.SerialPortUart.BaudRate = 115200
    '    '                    End If

    '    '                    If SerialPortUart.IsOpen Then
    '    '                        SerialPortUart.Close()
    '    '                    End If
    '    '                    Me.SerialPortUart.PortName = comName
    '    '                    Me.SerialPortUart.Open()
    '    '                    Return (Porta)
    '    '                Catch ex As Exception

    '    '                End Try

    '    '            End If

    '    '            If Porta.Contains("10C4") And Porta.Contains("EA60") And Porta.Contains("EPS") Then
    '    '                Try
    '    '                    If deviceFilter AndAlso Not CBool(deviceFilterType And GR_DEV.EPS) Then Exit Try

    '    '                    CONN_DEV = GR_DEV.EPS

    '    '                    If SerialPortUart.IsOpen Then
    '    '                        SerialPortUart.Close()
    '    '                    End If
    '    '                    Me.SerialPortUart.BaudRate = 230400
    '    '                    Me.SerialPortUart.Handshake = Handshake.None
    '    '                    Me.SerialPortUart.PortName = comName
    '    '                    Me.SerialPortUart.Open()
    '    '                    Return (Porta)
    '    '                Catch

    '    '                End Try

    '    '            End If



    '    '            If (Porta.Contains("2458") And Porta.Contains("0001")) Or (Porta.Contains("067B") And Porta.Contains("2303")) Then
    '    '                Try
    '    '                    If deviceFilter AndAlso Not CBool(deviceFilterType And GR_DEV.BEACON) Then Exit Try

    '    '                    CONN_DEV = GR_DEV.BEACON

    '    '                    If SerialPortUart.IsOpen Then
    '    '                        SerialPortUart.Close()
    '    '                    End If
    '    '                    Me.SerialPortUart.BaudRate = 115200
    '    '                    Me.SerialPortUart.Handshake = Handshake.RequestToSend
    '    '                    Me.SerialPortUart.PortName = comName
    '    '                    Me.SerialPortUart.Open()
    '    '                    Return (Porta)
    '    '                Catch

    '    '                End Try

    '    '            End If


    '    '        Next

    '    '        If modo_hack_1 = False Then
    '    '            GoTo loopPort
    '    '        End If

    '    '        Return "KO"

    'End Function






    'Public Function ApriPorta(Optional ByVal comando As String = "") As String
    '    Try

    '        RicercaCom()
    '        If comando.Length > 0 Then Return RDW_Command(comando)

    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try

    '    Return "KO"
    'End Function



    'Public Function Connessione()

    '    If LavoraCan Then
    '        Try
    '            RicercaCom()
    '        Catch ex As Exception
    '            AggiornaLog(ex)
    '        End Try
    '    End If

    '    Try

    '        Dim Versione() As String
    '        Dim stringavercompl As String

    '        stringavercompl = RDW_Command("R00")
    '        Versione = Split(stringavercompl, "|")
    '        SerialPortUart.ReadTimeout = 1000
    '        If Versione.Count = 1 And CONN_DEV = GR_DEV.MDC Then
    '            CONN_DEV = GR_DEV.NULL
    '            Wait(1000)
    '            Versione = Split(RDW_Command("R00"), "|")
    '            If Versione(0).Contains("MDC") Then
    '                CONN_DEV = GR_DEV.MDC
    '                ONLYMDC = True
    '            Else
    '                Return 0
    '            End If

    '        ElseIf Versione.Count = 1 Then
    '            Return "KO"
    '        End If
    '        Return "OK"
    '    Catch ex As Exception

    '        AggiornaLog(ex)
    '        Return "KO"
    '    End Try
    'End Function


    ''Public Sub StartConnection()
    ''    Try



    ''        LavoraCan = True
    ''        LavoraOffline = False
    ''        LavoraChiamataDati = False
    ''        LavoraHTTP = False

    ''        Call RicercaCom()


    ''        If Connessione() = "KO" Then
    ''            MsgBox(mui.Get_String_From_Tag("AT10", "Errore di connessione"))
    ''            DisconnessioneDispositivo()

    ''        End If



    ''    Catch ex As Exception
    ''        LavoraCan = False
    ''        LavoraOffline = False
    ''        LavoraChiamataDati = False

    ''        If (Me.SerialPortUart.IsOpen) Then Me.SerialPortUart.Close()

    ''        AggiornaLog(ex)
    ''        MsgBox(mui.Get_String_From_Tag("AT9", "Errore nella comunicazione con il dispositivo"))
    ''    End Try

    ''End Sub


    'Public Sub DisconnessioneDispositivo()
    '    Try

    '        Try
    '            If LavoraChiamataDati = True Then
    '                Dim RispostaChiusuraModem As String = ""
    '                Dim wt4CD As New Stopwatch

    '                wt4CD.Reset()
    '                wt4CD.Start()



    '                While wt4CD.ElapsedMilliseconds < 2000
    '                    Application.DoEvents()
    '                    System.Threading.Thread.Sleep(1)
    '                End While


    '                Me.SerialPortModem.ReadTimeout = 1000
    '                Me.SerialPortModem.Write("+++")
    '                If RFromModem(1) = "KO" Then
    '                    While wt4CD.ElapsedMilliseconds < 2000
    '                        Application.DoEvents()
    '                        System.Threading.Thread.Sleep(1)
    '                    End While
    '                    Me.SerialPortModem.Write("+++")

    '                End If




    '                While wt4CD.ElapsedMilliseconds < 2000
    '                    Application.DoEvents()
    '                    System.Threading.Thread.Sleep(1)
    '                End While
    '                Me.SerialPortModem.Write("ATH" & vbCrLf)
    '                RispostaChiusuraModem = RFromModem()



    '            End If
    '            If LavoraHTTP Then
    '                tcpClient.Close()
    '            End If
    '        Catch ex As Exception

    '        End Try


    '        If (SerialPortModem.IsOpen) Then SerialPortModem.Close()
    '        If (SerialPortUart.IsOpen) Then SerialPortUart.Close()

    '        CONN_DEV = GR_DEV.NULL

    '        ONLYMDC = False

    '        LavoraCan = False
    '        LavoraOffline = False
    '        LavoraChiamataDati = False
    '        LavoraHTTP = False
    '        LavoraRETE_CAN = False

    '        Using sw As StreamWriter = New StreamWriter(Application.StartupPath & "\TLL\LatLon.xml")
    '            sw.WriteLine("<?xml version=""1.0""?><Dispositivi>")
    '            sw.WriteLine("<Dispositivo Data=""" & Now() & """ GPSLatitudine=""" & 0 & """ GPSLongitudine=""" & 0 & """")
    '            sw.WriteLine(" Pitch=""" & 0 & """ Direzione=""" & 0 & """/>")
    '            sw.WriteLine("</Dispositivi>")
    '        End Using
    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try

    'End Sub


    'Public Function RFromModem(Optional ByVal tipo As Integer = 0) As String
    '    Dim Timewatch = New Stopwatch
    '    Timewatch.Reset()
    '    Timewatch.Start()
    '    Dim lil As String = ""

    '    Wait(1200)

    '    While SerialPortModem.BytesToRead = 0 And Timewatch.ElapsedMilliseconds < 10000
    '        Application.DoEvents()
    '        System.Threading.Thread.Sleep(1)
    '    End While


    '    While SerialPortModem.BytesToRead > 0
    '        lil = SerialPortModem.ReadLine() & lil
    '    End While

    '    If Not lil.Contains("OK") Then
    '        If tipo = 0 Then MsgBox("Error")

    '        Return "KO"
    '    End If


    '    Return lil

    'End Function

    'Sub Wait(ByVal tempo)

    '    Dim WC As New Stopwatch

    '    WC.Reset()
    '    WC.Start()
    '    While WC.ElapsedMilliseconds < tempo
    '        Application.DoEvents()
    '        System.Threading.Thread.Sleep(1)
    '    End While

    'End Sub




















End Class
