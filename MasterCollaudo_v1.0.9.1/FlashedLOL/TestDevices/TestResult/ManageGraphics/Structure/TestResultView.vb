Public Class TestResultView
    Inherits MainEtsdn

    Protected test_loading As Boolean
    Protected test_passed As Boolean
    Protected test_error As Boolean

    Public Sub New(test_loading, test_passed, test_error)
        Me.test_loading = test_loading
        Me.test_passed = test_passed
        Me.test_error = test_error
    End Sub
    Public Overridable Function ChangeGraphics()

    End Function

End Class
