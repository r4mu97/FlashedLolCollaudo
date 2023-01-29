Public Class ETSAT

    Public Shared AT As Comandi_AT
    Public Shared Property CONN_DEV As Comandi_AT.GR_DEV
        Get
            If IsNothing(AT) Then Return Comandi_AT.GR_DEV.NULL
            Return AT.CONN_DEV
        End Get
        Set(value As Comandi_AT.GR_DEV)
            AT.CONN_DEV = value
        End Set
    End Property

End Class



Public Module ets
    Public Settings As New settingz
    Public impAccelerometro = New setupAccelerometro()
    Public APN As New apnclass
    Public _ComandiIcone As New ComandiIcone

    Public Accelerometro As accelerometer
    Public Class reteWifi
        Public netNumber As Integer
        Public MAC As String
        Public SSID As String
        Public DHCP As Boolean
        Public IP As String
        Public Subnet As String
        Public Gateway As String
        Public Autenticazione As Integer
        Public Password As String
        Public Broadcast As String
        Public RSSI As String
    End Class

    Public Function ScanReti(MaxTentativi As Integer, Version As String) As List(Of reteWifi)
        Dim RETI() As String = Nothing
        Dim totreti As String = 0
        Dim starcount As Integer = 0
        Dim Tempreti() As String
        Dim RSSI As String
        Dim retiScannate As New List(Of reteWifi)
        Try
            Dim is5Ghz As Boolean = (Version >> 20) And 1
            If is5Ghz = True Then

                RETI = Split(RDW_Command("RW0"), "~")
                If RETI.Equals("KO") Or RETI.Equals("modem_busy!") Then
                    Return Nothing
                End If
                retiScannate.Clear()

                For i As Integer = 0 To RETI.Count - 1
                    Tempreti = Split(RETI(i), "|")
                    If Tempreti.Length < 6 Then Continue For
                    RSSI = Tempreti(2) & " dBm"
                    retiScannate.Add(New reteWifi With {.MAC = Tempreti(5), .SSID = Tempreti(4), .Autenticazione = (CInt(Tempreti(1))), .RSSI = RSSI})
                Next

            Else

                For tentativi As Integer = 0 To MaxTentativi
                    RETI = Split(RDW_Command("RW0", , , , , "END"), "" & vbCr & "")
                    If Not RETI(0) = "KO" Then

                        For i As Integer = 0 To RETI.Count - 1
                            If RETI(i).Contains("SCAN:Found ") Then
                                totreti = RETI(i).Replace("SCAN:Found ", "")
                                starcount = i
                                Exit For
                            End If


                        Next

                    End If



                    If totreti <> 0 Then Exit For
                    Dim WC As New Stopwatch

                    WC.Reset()
                    WC.Start()
                    While WC.ElapsedMilliseconds < 1000
                        System.Threading.Thread.Sleep(1)
                        Application.DoEvents()
                        End While

                Next

                If starcount = 0 Or totreti = 0 Then
                    Return Nothing ' MessageBox.Show(noNetStr)
                Else
                    retiScannate.Clear()

                    For i As Integer = starcount + 1 To starcount + totreti
                        Tempreti = Split(RETI(i), ",")

                        RSSI = Tempreti(2) & " dBm"

                        retiScannate.Add(New reteWifi With {.MAC = Tempreti(7), .SSID = Tempreti(8), .Autenticazione = (CInt(Tempreti(3))), .RSSI = RSSI})
                    Next
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return retiScannate
    End Function

    Structure accelerometer
        Private _Inclinazione As Integer
        Private _Accelerazione As Single
        Private _Pitch As Integer
        Private _Roll As Integer
        Private _X As Single
        Private _Y As Single
        Private _Z As Single
        Private _Mov As Boolean
        Private _Acc As Boolean


        Private Shared _GestisciInvioComandi As Boolean = False
        Shared errezerouno As String = Nothing
        ReadOnly Property Inclinazione As Integer
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = RDW_Command("R01") Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1

                        StatoNE(i) = Stato(i)
                    Next
                    _Inclinazione = CInt(StatoNE(6))
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _Inclinazione
            End Get
        End Property
        ReadOnly Property Pitch As Integer
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"

                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1

                        StatoNE(i) = Stato(i)
                    Next
                    _Pitch = CInt(StatoNE(4))
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _Pitch
            End Get
        End Property
        ReadOnly Property Roll As Integer
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1

                        StatoNE(i) = Stato(i)
                    Next
                    _Roll = CInt(StatoNE(5))
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _Roll
            End Get
        End Property
        ReadOnly Property X As Single
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1

                        StatoNE(i) = Stato(i)
                    Next
                    _X = CSng(StatoNE(41) / 100)
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _X
            End Get
        End Property
        ReadOnly Property Y As Single
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1

                        StatoNE(i) = Stato(i)
                    Next
                    _Y = CSng(StatoNE(42) / 100)
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _Y
            End Get
        End Property
        ReadOnly Property Z As Single
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1

                        StatoNE(i) = Stato(i)
                    Next
                    _Z = CSng(StatoNE(43) / 100)
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _Z
            End Get
        End Property
    End Structure
    Public Class setupAccelerometro
            Private _source As Integer
            Private _direzioneGravita As Integer
            Private _direzioneAnteriore As Integer
            Private _sensibilita As Single
            Private _ritardoDisattivazione As Integer

            Public Sub loadParametri()
                Dim tmp = Me.source
                tmp = Me.DirezioneGravita
                tmp = Me.DirezioneAnteriore
                tmp = Me.Sensibilita
                tmp = Me.RitardoDisattivazione
            End Sub

            Public Sub saveParametri()
                Me.source = _source
                Me.DirezioneGravita = _direzioneGravita
                Me.DirezioneAnteriore = _direzioneAnteriore
                Me.Sensibilita = _sensibilita
                Me.RitardoDisattivazione = _ritardoDisattivazione
            End Sub


            Public Property source As Integer
                Get
                    Try
                        _source = CInt(RDW_Command("R07", 32))
                        Return _source
                    Catch ex As Exception
                        AggiornaLog(ex)
                        Return Nothing
                    End Try
                End Get
                Set(value As Integer)
                    Try
                        _source = RDW_Command("W07", 32, value)

                        RDW_Command("L02")
                    Catch ex As Exception

                        AggiornaLog(ex)
                    End Try
                End Set
            End Property

            Public Property DirezioneGravita As Integer
                Get
                    Try
                        _direzioneGravita = CInt(Split(RDW_Command("R11"), "|")(0))

                        Return _direzioneGravita
                    Catch ex As Exception
                        AggiornaLog(ex)
                        Return Nothing
                    End Try
                End Get
                Set(value As Integer)
                    Try
                        Dim a = Split(RDW_Command("W11", , value & "|" & _direzioneAnteriore), "|")
                        _direzioneGravita = CInt(a(0))

                    Catch ex As Exception

                        AggiornaLog(ex)
                    End Try
                End Set
            End Property

            Public Property DirezioneAnteriore As Integer
                Get
                    Try
                        _direzioneAnteriore = CInt(Split(RDW_Command("R11"), "|")(1))

                        Return _direzioneAnteriore
                    Catch ex As Exception
                        AggiornaLog(ex)
                        Return Nothing
                    End Try
                End Get
                Set(value As Integer)
                    Try
                        _direzioneAnteriore = CInt(Split(RDW_Command("W11", , _direzioneGravita & "|" & value), "|")(1))

                        RDW_Command("L02")
                    Catch ex As Exception

                        AggiornaLog(ex)
                    End Try
                End Set
            End Property

            Public Property Sensibilita As Single
                Get
                    Try
                        _sensibilita = Math.Round(CSng(RDW_Command("R09", 92, , , True)), 2)
                        Return _sensibilita
                    Catch ex As Exception
                        AggiornaLog(ex)
                        Return Nothing
                    End Try
                End Get
                Set(value As Single)
                    Try
                        _sensibilita = Math.Round(CSng(RDW_Command("W09", 92, value, , True)), 2)

                        RDW_Command("L02")
                    Catch ex As Exception

                        AggiornaLog(ex)
                    End Try
                End Set
            End Property

            Public Property RitardoDisattivazione As Integer
                Get
                    Try
                        _ritardoDisattivazione = RDW_Command("R08", 33) / 1000
                        Return _ritardoDisattivazione
                    Catch ex As Exception
                        AggiornaLog(ex)
                        Return Nothing
                    End Try
                End Get
                Set(value As Integer)
                    Try
                        _ritardoDisattivazione = RDW_Command("W08", 33, value * 1000, , True) / 1000
                        RDW_Command("L02")
                    Catch ex As Exception

                        AggiornaLog(ex)
                    End Try
                End Set
            End Property

            Public Sub OffsetX()
                RDW_Command("Z100")
            End Sub
            Public Sub OffsetY()
                RDW_Command("Z101")
            End Sub
            Public Sub OffsetZ()
                RDW_Command("Z102")
            End Sub
            ''' <summary>
            ''' serve $L02 dopo!
            ''' </summary>
            ''' <remarks></remarks>
            Public Sub ZeroAccelerometro()
                RDW_Command("Z103")
                RDW_Command("Z104")
            End Sub

        End Class


        Public Function computeImportPage(ByVal comando As String) As String
        If Not comando.StartsWith("W06 ") Or Not comando.Split(" ").Length > 2 Then Return comando

        Dim cmd As String() = comando.Split(" ")

        If Not cmd(2).Contains("K") Then Return comando

        Dim realPage As String = RDW_Command(cmd(0).Replace("W", "R"), cmd(1))

        For i = 0 To cmd(2).Length - 1
            If cmd(2)(i).ToString().ToUpper().Equals("K") Then
                Mid(cmd(2), i + 1, 1) = realPage(i)
            End If
        Next

        Return cmd(0) & " " & cmd(1) & " " & cmd(2)

    End Function

    Public Class apn1
        Private _Nome As String
        Private _UserId As String
        Private _Password As String

        Public Property Nome As String
            Get
                Try
                    _Nome = RDW_Command("R0B", 1149)
                    Return _Nome
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                Try
                    _Nome = RDW_Command("W0B", 1149, value)
                    If _Nome <> value Then
                        _Nome = RDW_Command("W0B", 1149, value)
                        If _Nome <> value Then Throw New Exception("W0B failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
        Public Property UserID As String
            Get
                Try
                    _UserId = RDW_Command("R0B", 1199)
                    Return _UserId
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                Try
                    _UserId = RDW_Command("W0B", 1199, value)
                    If _UserId <> value Then
                        _UserId = RDW_Command("W0B", 1199, value)
                        If _UserId <> value Then Throw New Exception("W0B failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
        Public Property Password As String
            Get
                Try
                    _Password = RDW_Command("R0B", 1224)
                    Return _Password
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                Try
                    _Password = RDW_Command("W0B", 1224, value)
                    If _Password <> value Then
                        _Password = RDW_Command("W0B", 1224, value)
                        If _Password <> value Then Throw New Exception("W0B failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
    End Class
    Public Class apn2
        Private _Nome As String
        Private _UserId As String
        Private _Password As String

        Public Property Nome As String
            Get
                Try
                    _Nome = RDW_Command("R0B", 1763)
                    Return _Nome
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                Try
                    _Nome = RDW_Command("W0B", 1763, value)
                    If _Nome <> value Then
                        _Nome = RDW_Command("W0B", 1763, value)
                        If _Nome <> value Then Throw New Exception("W0B failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
        Public Property UserID As String
            Get
                Try
                    _UserId = RDW_Command("R0B", 1813)
                    Return _UserId
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                Try
                    _UserId = RDW_Command("W0B", 1813, value)
                    If _UserId <> value Then
                        _UserId = RDW_Command("W0B", 1813, value)
                        If _UserId <> value Then Throw New Exception("W0B failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
        Public Property Password As String
            Get
                Try
                    _Password = RDW_Command("R0B", 1838)
                    Return _Password
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                Try
                    _Password = RDW_Command("W0B", 1838, value)
                    If _Password <> value Then
                        _Password = RDW_Command("W0B", 1838, value)
                        If _Password <> value Then Throw New Exception("W0B failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
    End Class
    Public Class apn3
        Private _Nome As String
        Private _UserId As String
        Private _Password As String

        Public Property Nome As String
            Get
                Try
                    _Nome = RDW_Command("R0B", 1863)
                    Return _Nome
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                Try
                    _Nome = RDW_Command("W0B", 1863, value)
                    If _Nome <> value Then
                        _Nome = RDW_Command("W0B", 1863, value)
                        If _Nome <> value Then Throw New Exception("W0B failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
        Public Property UserID As String
            Get
                Try
                    _UserId = RDW_Command("R0B", 1913)
                    Return _UserId
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                Try
                    _UserId = RDW_Command("W0B", 1913, value)
                    If _UserId <> value Then
                        _UserId = RDW_Command("W0B", 1913, value)
                        If _UserId <> value Then Throw New Exception("W0B failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
        Public Property Password As String
            Get
                Try
                    _Password = RDW_Command("R0B", 1938)
                    Return _Password
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As String)
                Try
                    _Password = RDW_Command("W0B", 1938, value)
                    If _Password <> value Then
                        _Password = RDW_Command("W0B", 1938, value)
                        If _Password <> value Then Throw New Exception("W0B failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
    End Class
    Public Class apnclass

        Private _CambioAutomatico As Boolean
        Private _Utilizzato As Integer
        Public APN_1 As New apn1
        Public APN_2 As New apn2
        Public APN_3 As New apn3

        Public Property CambioAutomatico As Boolean
            Get
                Try
                    _CambioAutomatico = CBool(RDW_Command("R07", 87))
                    Return _CambioAutomatico
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As Boolean)
                Try
                    Dim temp = Math.Abs(CInt(value))
                    _CambioAutomatico = CBool(RDW_Command("W07", 87, Math.Abs(CInt(value))))

                    If _CambioAutomatico <> CBool(temp) Then
                        _CambioAutomatico = CBool(RDW_Command("W07", 87, Math.Abs(CInt(value))))
                        If _CambioAutomatico <> CBool(temp) Then Throw New Exception("W07 failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
        Public Property DefaultAPN As Integer
            Get
                Try
                    _Utilizzato = CInt(RDW_Command("R07", 86))
                    Return _Utilizzato
                Catch ex As Exception
                    AggiornaLog(ex)
                    Return Nothing
                End Try
            End Get
            Set(value As Integer)
                Try
                    _Utilizzato = RDW_Command("W07", 86, value)
                    If _Utilizzato <> value Then
                        _Utilizzato = RDW_Command("W07", 86, value)
                        If _Utilizzato <> value Then Throw New Exception("W07 failed")
                    End If
                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Set
        End Property
    End Class

    'Private iUType As Integer
    '' Public Shared _totUtenti As Integer
    'Public _oldTotUtenti As Integer
    'Public UsrList As New List(Of utenteGenerico)
    'Private userpage As String = "F"

    'Public Class users

    '    Public Sub AggiungiUtente() 'Optional ByVal dontInit As Boolean = False, Optional ByVal dontSave As Boolean = False)
    '        '  NumeroUtenti = _totUtenti + 1
    '        'If Not dontSave Then
    '        '    Dim a = NumeroUtenti
    '        'Else

    '        UsrList.Add(New utenteGenerico(iUType) With {.utenteNumero = UsrList.Count,
    '                                             .NomeUtente = "user" & UsrList.Count,
    '                                             .edited = True})
    '        '  End If
    '        'If Not dontInit Then UsrList(UsrList.Count - 1).init(Not dontSave)
    '    End Sub
    'End Class

    'Public Class utenteGenerico

    '    Public utenteNumero As Integer
    '    Public edited As Boolean = False
    '    Private _NomeUtente As String

    '    Sub New(iType As Integer)
    '        iUType = iType
    '        userpage = "F"
    '        While userpage.Length < (pos(iUType)("U_LEN") * 2)
    '            userpage &= "F"
    '        End While
    '    End Sub

    '    Public Shared pos As Dictionary(Of String, Integer)() = {
    '       New Dictionary(Of String, Integer) From {
    '           {"MAX_USERS", 500}, {"U_LEN", 256}, {"UID", 0}, {"NAME", 4}, {"C_DAY", 29}, {"OPZ", 30}, {"C_PROF", 31}, {"T_START", 32}, {"T_STOP", 36}, {"D_START", 40}, {"D_STOP", 44}, {"UID_125", 48}, {"PIN", 63}, {"WEB_ID", 252}, {"TAG_UID", 73}    ' DEFAULT_USERS
    '       },
    '       New Dictionary(Of String, Integer) From {
    '           {"MAX_USERS", 1500}, {"U_LEN", 85}, {"UID", 0}, {"NAME", 4}, {"C_DAY", 29}, {"OPZ", 30}, {"C_PROF", 31}, {"T_START", 32}, {"T_STOP", 36}, {"D_START", 40}, {"D_STOP", 44}, {"UID_125", 48}, {"PIN", 63}, {"WEB_ID", 81}, {"TAG_UID", 73}    ' SHORT_USERS
    '       }
    '   }

    '    Public Property NomeUtente As String
    '        Get
    '            Return _NomeUtente
    '        End Get
    '        Set(value As String)
    '            value = System.Text.RegularExpressions.Regex.Replace(value, "[^a-zA-Z0-9 -]", "?")
    '            If value.Length > 24 Then
    '                _NomeUtente = value.Substring(0, 25)
    '            Else
    '                _NomeUtente = value
    '            End If
    '        End Set
    '    End Property
    'End Class




    Public Class ComandiIcone
        Private Shared _GestisciInvioComandi As Boolean = False
        Shared errezerouno As String = Nothing
        Private _GPRSactive As Boolean
        Private _SimStatus As Integer
        Private _PINfound As Integer
        Private _ModemStatus As Integer
        Private _ReteGsmStatus As Integer
        Private _ReteGprsStatus As Integer
        Private _Ip As String
        Private _SocketStatus As Integer
        Private _SignalStrenght As Integer
        Private _TRAFFIC_BLOCK As Boolean

        ReadOnly Property GPRSactive As Boolean
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1

                        StatoNE(i) = Stato(i)
                    Next
                    _GPRSactive = CBool(CInt(StatoNE(34)))
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _GPRSactive
            End Get
        End Property


        ReadOnly Property SimStatus As Integer
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1
                        StatoNE(i) = Stato(i)
                    Next
                    _SimStatus = CInt(StatoNE(28))
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _SimStatus
            End Get
        End Property

        ReadOnly Property PINfound As Integer
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1
                        StatoNE(i) = Stato(i)
                    Next
                    _PINfound = CInt(StatoNE(72))
                Catch ex As Exception
                    _PINfound = False
                    AggiornaLog(ex)
                End Try
                Return _PINfound
            End Get
        End Property
        ReadOnly Property ModemStatus As Integer
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1
                        StatoNE(i) = Stato(i)
                    Next
                    _ModemStatus = CInt(StatoNE(22))
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _ModemStatus
            End Get
        End Property

        ReadOnly Property SignalStrenght As Integer
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1
                        StatoNE(i) = Stato(i)
                    Next
                    _SignalStrenght = CInt(StatoNE(2))
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _SignalStrenght
            End Get
        End Property

        ReadOnly Property ReteGsmStatus As Integer
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1
                        StatoNE(i) = Stato(i)
                    Next
                    _ReteGsmStatus = CInt(StatoNE(24))
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _ReteGsmStatus
            End Get
        End Property
        ReadOnly Property ReteGprsStatus As Integer
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1
                        StatoNE(i) = Stato(i)
                    Next
                    _ReteGprsStatus = CInt(StatoNE(25))
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Return _ReteGprsStatus
            End Get
        End Property


        ReadOnly Property Ip As String
            Get
                Try
                    Dim Stato() As String
                    Dim StatoNE(100) As String

                    Dim check As String = "KO"
                    If Not _GestisciInvioComandi Then check = Main.instance.collaudoIstance._RDWcommR01 Else check = errezerouno
                    If check = "KO" Then Return "KO"
                    Stato = Split(check, "|")
                    For i As Integer = 0 To Stato.Length - 1
                        StatoNE(i) = Stato(i)
                    Next
                    _Ip = Replace(StatoNE(33), ",", ".")
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                If _Ip Is Nothing Then _Ip = " "
                Return _Ip
            End Get
        End Property

    End Class
    Public Class settingz
        Public RTC As New rtcsetup
        Public Class rtcsetup

            Private _data As DateTime

            Public ReadOnly Property Data As DateTime
                Get
                    Try

                        Dim coccode() As String = Split(RDW_Command("R30"), "|")

                        _data = FormattaDataOra((coccode(0) And 255), ((coccode(0) \ 256) And 255), ((coccode(0) \ (65536)) And 65535),
                                                 ((coccode(1) \ 65536) And 255), ((coccode(1) \ 256) And 255), (coccode(1) And 255), True)

                        Return _data
                    Catch ex As Exception
                        AggiornaLog(ex)
                        Return Nothing
                    End Try
                End Get
            End Property

            Public Sub SincronizzaRTC()
                Try
                    Dim data = Now.Year * 65536 + Now.Month * 256 + Now.Day
                    Dim ora = Now.Hour * 65536 + Now.Minute * 256 + Now.Second

                    RDW_Command("W30", , data & "|" & ora & "|" & Now.DayOfWeek & "|" & Now.DayOfYear)

                    RDW_Command("L02")
                Catch ex As Exception

                    AggiornaLog(ex)
                End Try
            End Sub
            Public Shared Function FormattaDataOra(ByRef giorno As String, ByRef mese As String, ByRef anno As String,
                                               ByRef ora As String, ByRef minuti As String, ByRef secondi As String,
                                               Optional isRTCdate As Boolean = False) As DateTime
                Try


                    If giorno.Length = 1 Then giorno = "0" & giorno
                    If mese.Length = 1 Then mese = "0" & mese

                    If ora.Length = 1 Then ora = "0" & ora
                    If minuti.Length = 1 Then minuti = "0" & minuti
                    If secondi.Length = 1 Then secondi = "0" & secondi

                    If giorno < 1 Or giorno > 31 Then giorno = 1
                    If mese < 1 Or mese > 12 Then mese = 1
                    If ora < 1 Or ora > 23 Then ora = 1
                    If minuti < 1 Or minuti > 59 Then minuti = 0
                    If secondi < 1 Or secondi > 59 Then secondi = 0

                    If Not isRTCdate Then anno += 2000

                    If anno > 9998 Then anno = 9998

                    Return New DateTime(anno, mese, giorno, ora, minuti, secondi) '//Becomes December 31, 2005 11:59:59 PM

                Catch ex As Exception
                    AggiornaLog(ex)
                    Return ""
                End Try
            End Function
        End Class
    End Class


End Module




