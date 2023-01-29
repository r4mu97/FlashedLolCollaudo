Imports System.IO
Imports System.Xml
Imports FlashedLOL
Imports System.Web.Script.Serialization
Imports System.Convert

Public Class Prediction
    Inherits Cloud

    ' FIXME
    Shared address As String = "http://erp.kiwitron.it"

    Private allGRSat As New List(Of GRSat)

    Shared sessionId As String = ""

    Public Sub New(loginAddress As String, un As String, pw As String, Optional type As Integer = 1)
        MyBase.New(address & "/Mod_Login/LoadXML.php", un, pw,
 _
                   New loginResultValid(Function(risp As String)
                                            Try
                                                Dim m_xmld As New XmlDocument
                                                m_xmld.InnerXml = risp
                                                sessionId = m_xmld.SelectSingleNode("dati/dato").Attributes.GetNamedItem("D6").Value
                                                Return m_xmld.SelectSingleNode("dati/dato").Attributes.GetNamedItem("D0").Value.Equals("1")
                                            Catch ex As Exception
                                                AggiornaLog(ex)
                                            End Try
                                            Return False
                                        End Function),
 _
                   New getLoginParameters(Function()
                                              Dim reqparm As New Specialized.NameValueCollection
                                              reqparm.Add("un", un)
                                              reqparm.Add("pw", pw)
                                              reqparm.Add("Tipo", "1")
                                              reqparm.Add("modo", "1")
                                              Return reqparm
                                          End Function))
    End Sub

    Public ReadOnly Property allGRSatNames
        Get
            Dim names As New List(Of String)
            For Each cloud In allGRSat
                names.Add(cloud.friendlyName)
            Next
            Return names.ToArray()
        End Get
    End Property

    Public Sub refreshGRSatList(callback As [Delegate])
        Try
            allGRSat.Clear()
            If Not File.Exists(Application.StartupPath & "\grsats.xml") Then
                MsgBox("File grsats.xml non trovato")
                Return
            End If

            Dim m_xmld As New XmlDocument
            m_xmld.Load(Application.StartupPath & "\grsats.xml")

            For Each node As XmlNode In m_xmld.SelectNodes("dati/dato")
                If IsNothing(node) Then Continue For
                Try
                    If node.Attributes.GetNamedItem("D4").Value.ToLower().Contains("bonatti") Then
                        allGRSat.Add(New GRSatBonatti(
                             node.Attributes.GetNamedItem("D0").Value,
                             node.Attributes.GetNamedItem("D1").Value,
                             node.Attributes.GetNamedItem("D2").Value,
                             node.Attributes.GetNamedItem("D3").Value,
                             node.Attributes.GetNamedItem("D4").Value,
                             node.Attributes.GetNamedItem("D5").Value,
                             node.Attributes.GetNamedItem("D6").Value,
                             node.Attributes.GetNamedItem("D7").Value,
                             node.Attributes.GetNamedItem("D8").Value))
                    Else
                        allGRSat.Add(New GRSat(
                             node.Attributes.GetNamedItem("D0").Value,
                             node.Attributes.GetNamedItem("D1").Value,
                             node.Attributes.GetNamedItem("D2").Value,
                             node.Attributes.GetNamedItem("D3").Value,
                             node.Attributes.GetNamedItem("D4").Value,
                             node.Attributes.GetNamedItem("D5").Value,
                             node.Attributes.GetNamedItem("D6").Value,
                             node.Attributes.GetNamedItem("D7").Value,
                             node.Attributes.GetNamedItem("D8").Value))
                    End If

                Catch ex As Exception
                    AggiornaLog(ex)
                End Try

            Next


            If Not IsNothing(callback) Then callback.DynamicInvoke()

        Catch ex As Exception
            AggiornaLog(ex)
        End Try

    End Sub

    Friend Function getGRSatByName(name As String) As GRSat
        For Each cloud In allGRSat
            If cloud.friendlyName.Equals(name) Then Return cloud
        Next
        Return Nothing
    End Function

    Public Function createDeviceSerial(deviceType As String) As Dictionary(Of String, String)
        Dim risp
        Dim dict As Dictionary(Of String, String) = Nothing

        risp = doGetRequest(address & "/api_v2/device_serial/reserve.php?type=" & deviceType)
        Try
            Dim jsonDecoder As New JavaScriptSerializer()
            dict = jsonDecoder.Deserialize(Of Dictionary(Of String, String))(risp)
            Return dict

        Catch ex As Exception
            Throw New Exception("Invalid ERP response: " + risp)
        End Try

    End Function

    Public Function salvaAssocSeriali(serialeETS As String, serialeETSDN As String, override As String) As Dictionary(Of String, String)
        Dim risp
        Dim dict As Dictionary(Of String, String) = Nothing

        Dim requestParams As New Specialized.NameValueCollection From {
            {"ets_serial", serialeETS},
            {"etsdn_serial", serialeETSDN},
            {"override", override}
        }

        risp = doPostRequest(address & "/api_v2/utilities/insert_rel_ets_etsdn.php", requestParams)
        Try
            Dim jsonDecoder As New JavaScriptSerializer()
            dict = jsonDecoder.Deserialize(Of Dictionary(Of String, String))(risp)

            If (ToBoolean(dict("status"))) Then
                confermaAssemblaggio(serialeETS)
                confermaAssemblaggio(serialeETSDN)
            End If
            Return dict
        Catch ex As Exception
            Throw New Exception("Invalid ERP response: " + risp)
        End Try

    End Function

    Public Function confermaAssemblaggio(seriale As String) As Boolean
        Dim risp
        Dim req As Dictionary(Of String, Object) = New Dictionary(Of String, Object) From {
            {"toUpdate", New Dictionary(Of String, String) From {{"PMI_ASSEMBLED", "1"}}},
            {"where", New Dictionary(Of String, Object) From {{"fields", New Dictionary(Of String, String) From {{"PMI_SERIAL", "200703591"}}}}}
        }

        risp = doPutJSonRequest(address & "/api_v2/articoli/put.php?", req, sessionId)
        Console.WriteLine(risp)
        Return Nothing

    End Function
End Class
