Public Class TestResult

    Protected is_completed As Boolean
    Protected is_successfull As Boolean
    Protected nameOftest As String
    Protected fail As String
    Protected serial As String
    Protected checked As Boolean

    Public Sub New(is_completed As Boolean, is_successfull As Boolean, nameOftest As String, fail As String, sn As String, checked As Boolean)
        Me.is_completed = is_completed
        Me.is_successfull = is_successfull
        Me.nameOftest = nameOftest
        Me.fail = fail
        Me.serial = sn
        Me.checked = checked
    End Sub

    Public Function GetChecked()
        Return checked
    End Function
    Public Function ErrorType()
        Return fail
    End Function

    Public Function IsSuccesfull()
        Return is_successfull
    End Function

    Public Function NameTest()
        Return nameOftest
    End Function

    Public Function GetSerial()
        Return serial
    End Function
    Public Overridable Function print_result()
    End Function

End Class
