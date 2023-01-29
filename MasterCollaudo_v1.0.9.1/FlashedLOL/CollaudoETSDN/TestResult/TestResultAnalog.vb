Public Class TestResultAnalog
    Inherits TestResult

    Dim test_ana5v As Boolean
    Dim test_ana10v As Boolean

    Public Sub New(is_completed As Boolean, is_successfull As Boolean, test_ana5v As Boolean, test_ana10v As Boolean, nameOftest As String, fail As String, sn As String, checked As Boolean)
        MyBase.New(is_completed, is_successfull, nameOftest, fail, sn, checked)
        Me.test_ana5v = test_ana5v
        Me.test_ana10v = test_ana10v
    End Sub

End Class
