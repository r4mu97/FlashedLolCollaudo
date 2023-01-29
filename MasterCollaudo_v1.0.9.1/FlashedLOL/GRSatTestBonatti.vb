Imports System.Globalization
Imports System.Threading
Imports System.Xml

Public Class GRSatTestBonatti
    Inherits GRSatTest

    Dim rand As New Random()

    Sub New(srv, un, pw)
        MyBase.New("http://localhost:3000", "", "")
    End Sub

End Class
