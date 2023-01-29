Public Class TestResultRele
    Inherits TestResult
    Dim rele_single1 As Boolean
    Dim rele_single2 As Boolean
    Dim rele_single3 As Boolean

    Public Sub New(is_completed As Boolean, is_successfull As Boolean, rele_single1 As Boolean,
                   rele_single2 As Boolean, rele_single3 As Boolean, nameOftest As String, fail As String, sn As String, checked As Boolean)
        MyBase.New(is_completed, is_successfull, nameOftest, fail = "", sn, checked)
        Me.rele_single1 = rele_single1
        Me.rele_single2 = rele_single2
        Me.rele_single3 = rele_single3
    End Sub

    Public Overrides Function print_result()

    End Function
End Class
