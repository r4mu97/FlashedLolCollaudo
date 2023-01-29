Imports System.Net

Public Class CookieAwareWebClient
    Inherits WebClient

    Private cc As New CookieContainer()
    Private lastPage As String

    Private _Timeout As Integer
    Public Property Timeout() As Integer
        Get
            Return _Timeout
        End Get
        Set(ByVal value As Integer)
            _Timeout = value
        End Set
    End Property

    Sub New(ByVal timeout As UInteger)
        Me.Timeout = timeout
    End Sub


    Protected Overrides Function GetWebRequest(ByVal address As System.Uri) As System.Net.WebRequest
        Dim R = MyBase.GetWebRequest(address)
        If TypeOf R Is HttpWebRequest Then
            With DirectCast(R, HttpWebRequest)
                .CookieContainer = cc
                If Not lastPage Is Nothing Then
                    .Referer = lastPage
                End If
            End With
        End If
        lastPage = address.ToString()
        Return R
    End Function


    Public ReadOnly Property cookieContainer As CookieContainer
        Get
            Return cc
        End Get
    End Property


End Class


