Imports System.Globalization
Imports System.Threading
Imports System.Xml

Public Class GRSat
    Inherits Cloud
    Protected _friendlyName As String
    Protected _id As Integer
    Protected _ftpsrv As String
    Protected _ftpusr As String
    Protected _ftppaw As String
    Protected _httpsrv As String
    Protected _srv As String

    Dim rand As New Random()

    Sub New(id, srv, un, pw, friendlyName, ftpS, ftpU, ftpP, httpS)
        MyBase.New(
            srv & "androcon.php",
                   un,
                   pw,
 _
                   New loginResultValid(Function(risp As String)
                                            Return risp.Equals("CONNECTED")
                                        End Function),
 _
            New getLoginParameters(Function()
                                       Dim reqparm As New Specialized.NameValueCollection
                                       reqparm.Add("un", un)
                                       reqparm.Add("pw", pw)
                                       Return reqparm
                                   End Function))

        _friendlyName = friendlyName
        _id = id
        _ftpsrv = ftpS
        _ftpusr = ftpU
        _ftppaw = ftpP
        _httpsrv = httpS
        _srv = srv
    End Sub

    Public ReadOnly Property Host As String
        Get
            Return _srv
        End Get
    End Property

    Public ReadOnly Property friendlyName As String
        Get
            Return _friendlyName
        End Get
    End Property
    Public ReadOnly Property id As Integer
        Get
            Return _id
        End Get
    End Property
    Public ReadOnly Property FTPSrv As String
        Get
            Return _ftpsrv
        End Get
    End Property
    Public ReadOnly Property FTPUser As String
        Get
            Return _ftpusr
        End Get
    End Property
    Public ReadOnly Property FTPPsw As String
        Get
            Return _ftppaw
        End Get
    End Property
    Public ReadOnly Property HTTPServer As String
        Get
            Return _httpsrv
        End Get
    End Property

    Public Function creaDevice(serial As String, nome As String, codice As String, password As String) As Integer
        Dim risp = ""
        Try
            risp = doGetRequest(_srv & "/Mod_AssetMgmt/LoadXML.php?Tipo=2&modo=2&id=-1&name=" & nome & "&cod=" & codice & "&pass=" & password & "&ntel=&rand=" & rand.NextDouble())
            Return risp
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return -1
    End Function


    Public Overridable Function getSheets() As List(Of String)
        Dim ret As New List(Of String)
        showWait("Ottengo i sensor sheets")
        Try
            Dim risp = doGetRequest(_srv & "/Mod_AssetMgmt/LoadXML.php?Tipo=1&modo=3" & "&rand=" & rand.NextDouble())
            Dim m_xmld As New XmlDocument
            m_xmld.InnerXml = risp

            For Each node In m_xmld.SelectNodes("dati/dato")
                ret.Add(
                node.Attributes.GetNamedItem("D0").Value &
                " - " &
                node.Attributes.GetNamedItem("D1").Value)
            Next

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        disposeWait()
        Return ret
    End Function



    Public Overridable Function getSensorsForSheet(sheetID) As List(Of String)
        Dim ret As New List(Of String)
        showWait("Ottengo i sensor sheets")
        Try
            Dim risp = doGetRequest(_srv & "/Mod_AssetMgmt/LoadXML.php?Tipo=1&modo=4&idsheet=" & sheetID & "&rand=" & rand.NextDouble())
            Dim m_xmld As New XmlDocument
            m_xmld.InnerXml = risp

            For Each node In m_xmld.SelectNodes("dati/dato")
                ret.Add(
                node.Attributes.GetNamedItem("D7").Value &
                " - " &
                node.Attributes.GetNamedItem("D8").Value)
            Next

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        disposeWait()
        Return ret
    End Function


    Public Function getUnits() As List(Of String)
        Dim ret As New List(Of String)
        showWait("Ottengo le units")
        Try
            Dim risp = doGetRequest(_srv & "/Mod_AssetMgmt/LoadXML.php?Tipo=1&modo=1" & "&rand=" & rand.NextDouble())
            Dim m_xmld As New XmlDocument
            m_xmld.InnerXml = risp

            For Each node In m_xmld.SelectNodes("dati/dato")
                ret.Add(
                node.Attributes.GetNamedItem("D0").Value &
                " - " &
                node.Attributes.GetNamedItem("D1").Value)
            Next


        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        disposeWait()
        Return ret
    End Function

    Public Function creaAsset(deviceID As Integer, Description As String, Brand As String, Serial As String, Model As String, Plate As String,
                              Unit As String, Sheet As String, Profile As Integer, GPS As Integer, RSSI As Integer,
                              meter1 As Integer, meter2 As Integer, Alarm As Integer, Map As Integer, Inspector As Integer, Uses As Integer,
                              Charts As Integer, Routes As Integer, Dummy As Integer, meter1spn As String, meter2spn As String) As Integer
        Try
            Dim mainstatus As Integer = 0
            Dim mainfunction As Integer = 0
            mainstatus = mainstatus Or (Profile << 0)
            mainstatus = mainstatus Or (GPS << 1)
            mainstatus = mainstatus Or (RSSI << 2)
            mainstatus = mainstatus Or (meter1 << 3)
            mainstatus = mainstatus Or (meter2 << 4)
            mainstatus = mainstatus Or (0 << 5)
            mainstatus = mainstatus Or (0 << 6)
            mainstatus = mainstatus Or (0 << 7)
            mainstatus = mainstatus Or (0 << 8)

            mainfunction = mainfunction Or (Alarm << 0)
            mainfunction = mainfunction Or (Map << 1)
            mainfunction = mainfunction Or (Inspector << 2)
            mainfunction = mainfunction Or (Uses << 3)
            mainfunction = mainfunction Or (Charts << 4)
            mainfunction = mainfunction Or (Routes << 5)
            mainfunction = mainfunction Or (Dummy << 6)

            Dim reqparm As New Specialized.NameValueCollection
            reqparm.Add("Tipo", 2)
            reqparm.Add("modo", 1)
            reqparm.Add("dataraw", "-1|" & Description & "|" & Brand & "|" & Serial & "|" & Model & "|" & Plate & "|" &
                        Unit & "|" & Sheet & "|" & deviceID & "|imgbase.png|ca.png|ca.png|eq.png|eq.png|offline.png|" &
                        mainstatus & "|" & mainfunction & "|" & meter1spn & "|" & meter2spn & "|0|")
            Dim risp As Integer = doPostRequest(_srv & "/Mod_AssetMgmt/LoadXML.php", reqparm)

            Return risp
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return False
    End Function

    Public Function testInvio(assetID As Integer, minutesTolerance As Integer) As Boolean
        Try
            Dim stato As String() = New String() {}
            Dim tentativi As Integer = 10
            showWait("Attendo che il modem sia pronto...")
            While (stato.Length < 2 OrElse stato(0).Equals("1"))
                stato = RDW_Command("R82").Split("|")

                If stato.Length < 2 OrElse stato(0).Equals("1") Then
                    If Tentativi > 0 Then
                        Tentativi -= 1
                        Wait(500)
                    Else
                        MessageBox.Show("ST38", "Errore")
                        Exit Try
                    End If
                End If
            End While

            showWait("Test in corso...")
            RDW_Command("Q405")
            RDW_Command("Q408")
            Dim lastTrans As New Date(2016, 1, 1)

            While Date.Now.Subtract(lastTrans).TotalMinutes <= minutesTolerance
                Wait(5000)
                Dim risp = doGetRequest(_srv & "/Mod_Asset//LoadXML.php?Tipo=1&modo=1&Source=" & assetID & "&rand=" & rand.NextDouble())
                Dim m_xmld As New XmlDocument
                m_xmld.InnerXml = risp
                Dim str = m_xmld.SelectSingleNode("dati/dato").Attributes.GetNamedItem("D0").Value
                lastTrans = Date.ParseExact(str, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            End While

            disposeWait()
            Return True
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        disposeWait()
        Return False
    End Function

    Friend Function creaUnit(nam As String) As Integer
        Dim risp = ""
        Try
            risp = doGetRequest(_srv & "/Mod_AssetMgmt/LoadXML.php?Tipo=2&modo=8&ID=-1&name=" & nam & "&rand=" & rand.NextDouble())
            Return risp
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return -1
    End Function
End Class
