Public Class TestResultInputs
    Inherits TestResult

    Dim test_ip1 As Boolean
    Dim test_ip2 As Boolean
    Dim test_in1 As Boolean
    Dim test_in2 As Boolean

    Public Sub New(is_completed As Boolean, is_successfull As Boolean, test_ip1 As Boolean, test_ip2 As Boolean, test_in1 As Boolean, test_in2 As Boolean,
                   nameOftest As String, fail As String, sn As String, checked As Boolean)
        MyBase.New(is_completed, is_successfull, nameOftest, fail, sn, checked)
        Me.test_ip1 = test_ip1
        Me.test_ip2 = test_ip2
        Me.test_in1 = test_in1
        Me.test_in2 = test_in2
    End Sub

    Public Overrides Function print_result() As Object

    End Function

End Class
