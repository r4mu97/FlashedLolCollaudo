Public Class TestResultAcc
    Inherits TestResult

    Public Sub New(is_completed As Boolean, is_successfull As Boolean, nameOftest As String, fail As String, sn As String, checked As Boolean)
        MyBase.New(is_completed, is_successfull, nameOftest, fail, sn, checked)
    End Sub

    Public Overrides Function print_result() As Object

    End Function

End Class
