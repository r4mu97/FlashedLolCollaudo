Public Class TestSuite

    Dim tests As List(Of PrototypTest)

    Public Sub New()
        Me.tests = New List(Of PrototypTest)
    End Sub

    Public Function AddTests(test As PrototypTest)
        tests.Add(test)
    End Function
    Public Function GeTests() As List(Of PrototypTest)
        Return tests
    End Function

    Public Function GetCountTest()
        Return Me.tests.Count
    End Function
    Public Function ClearListOfTest()
        tests.Clear()
    End Function

End Class
