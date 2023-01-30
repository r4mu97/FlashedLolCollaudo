Public Class pBoxPower
    Inherits TestResultView

    Public Sub New(test_loading As Boolean, test_passed As Boolean, test_error As Boolean)
        MyBase.New(test_loading, test_passed, test_error)
    End Sub
    Public Overrides Function ChangeGraphics()
    End Function
End Class
