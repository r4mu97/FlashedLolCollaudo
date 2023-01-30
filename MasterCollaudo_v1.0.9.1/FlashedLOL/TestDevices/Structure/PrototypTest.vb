
Imports FlashedLOL.MainEtsdn

Public Class PrototypTest
    Protected tmrTest As Stopwatch
    Protected testSuccess As Boolean
    Protected testCompleted As Boolean
    Protected nameOftest As String
    Protected viewError As String
    Protected varTxEtsdn As New VarTxToETSDN
    Protected canEtsdnVar As New CanCommunication
    Protected tmrSlidePanel As Stopwatch

    Public Sub New()
        Me.tmrTest = New Stopwatch
        Me.varTxEtsdn = New VarTxToETSDN
        Me.canEtsdnVar = New CanCommunication
        Me.testSuccess = False
        Me.testCompleted = False
        Me.tmrSlidePanel = New Stopwatch
    End Sub


    Public Overridable Function Execute(gui As MainEtsdn) As TestResult
        Return Nothing
    End Function

    Sub Wait(ByVal tempo)
        Dim WC As New Stopwatch

        WC.Reset()
        WC.Start()
        While WC.ElapsedMilliseconds < tempo
            Application.DoEvents()
            System.Threading.Thread.Sleep(1)
        End While
    End Sub
End Class
