Imports System.Globalization
Imports System.Threading
Imports System.Xml

Public Class GRSatTest
    Inherits Cloud

    Dim rand As New Random()

    Sub New(srv, un, pw)
        MyBase.New(
            srv & "androcon.php",
                   un,
                   pw,
                   New loginResultValid(Function(risp As String)
                                            'MsgBox(risp)

                                            Return risp.Equals("CONNECTED")
                                        End Function),
            New getLoginParameters(Function()
                                       Dim reqparm As New Specialized.NameValueCollection
                                       reqparm.Add("un", un)
                                       reqparm.Add("pw", pw)
                                       Return reqparm
                                   End Function))

    End Sub

End Class
