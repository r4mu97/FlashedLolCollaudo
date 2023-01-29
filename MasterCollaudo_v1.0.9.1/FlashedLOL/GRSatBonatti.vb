Imports System.Globalization
Imports System.Threading
Imports System.Web.Script.Serialization
Imports System.Xml

Public Class GRSatBonatti
    Inherits GRSat

    Sub New(id, srv, un, pw, friendlyName, ftpS, ftpU, ftpP, httpS)
        MyBase.New(id, srv, un, pw, friendlyName, ftpS, ftpU, ftpP, httpS)
    End Sub

    Public Overloads Function login() As LOGIN_RESULT
        Return LOGIN_RESULT.SUCCED
    End Function

    Public Overloads Function creaDevice(serial As String, nome As String, cloudCode As String, password As String) As Integer
        Dim risp = ""
        Dim data = New Dictionary(Of String, Object)
        data.Add("deviceCode", serial)

        Dim url = _srv & "api/Devices"
        risp = doPostJSonRequest("http://ithq01dck1:32101/api/Devices", data)
        Return Convert.ToInt32(serial)
    End Function


    Public Overloads Function getSheets() As List(Of String)
        Dim ret = New List(Of String)
        Return ret
    End Function



    Public Overloads Function getSensorsForSheet(sheetID) As List(Of String)
        Dim ret = New List(Of String)
        Return ret
    End Function


    Public Overloads Function getUnits() As List(Of String)
        Dim ret = New List(Of String)
        Return ret
    End Function

    Public Overloads Function creaAsset(deviceID As Integer, Description As String, Brand As String, Serial As String, Model As String, Plate As String,
                              Unit As String, Sheet As String, Profile As Integer, GPS As Integer, RSSI As Integer,
                              meter1 As Integer, meter2 As Integer, Alarm As Integer, Map As Integer, Inspector As Integer, Uses As Integer,
                              Charts As Integer, Routes As Integer, Dummy As Integer, meter1spn As String, meter2spn As String) As Integer
        Return deviceID
    End Function

    Public Overloads Function testInvio(assetID As Integer, minutesTolerance As Integer) As Boolean
        Try
            Dim stato As String() = New String() {}
            Dim tentativi As Integer = 10
            showWait("Attendo che il modem sia pronto...")
            While (stato.Length < 2 OrElse stato(0).Equals("1"))
                stato = RDW_Command("R82").Split("|")

                If stato.Length < 2 OrElse stato(0).Equals("1") Then
                    If tentativi > 0 Then
                        tentativi -= 1
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
                Dim risp = doGetRequest("http://ithq01dck1:32101" & "/api/Logs/LastLog?deviceCode=" & assetID)
                'Dim m_xmld As New XmlDocument
                'm_xmld.InnerXml = risp
                'Dim str = m_xmld.SelectSingleNode("dati/dato").Attributes.GetNamedItem("D0").Value
                'lastTrans = Date.ParseExact(str, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)

                Dim jss As New JavaScriptSerializer()
                Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(risp)

                If dict.ContainsKey("TimeStamp") Then
                    lastTrans = Date.ParseExact(dict("TimeStamp"), "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)
                End If
            End While

            disposeWait()
            Return True
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        disposeWait()
        Return False
    End Function

    Friend Overloads Function creaUnit(nam As String) As Integer
        Return -1
    End Function
End Class
