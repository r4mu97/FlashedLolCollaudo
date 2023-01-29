Public Class TestAnalogEtsdn
    Inherits PrototypTest

    Dim resultAna5v As Boolean
    Dim resultAna10v As Boolean
    Dim cFailANA5 As Integer = 0
    Dim cFailANA10 As Integer = 0
    'soglie impostate nel mainEtsdn
    Dim tmrTest_threshold As Integer
    Dim minimum_threshold_gap As Integer
    Dim maximum_threshold_gap As Integer
    Dim minimum_threshold_fail As Integer
    Dim maximum_threshold_fail As Integer



    Public Overrides Function Execute(gui As MainEtsdn) As TestResult

        nameOftest = "Test Analog"
        testSuccess = False
        testCompleted = False
        varTxEtsdn.SetState10V(1)
        varTxEtsdn.SetState5V(1)
        'gui.ChangeControlLocation(gui.StatoTestAnalog, 197, 0)
        gui.pbox_Ana5v.Image = Nothing
        gui.pbox_Ana10v.Image = Nothing
        gui.StatoTestAnalog.Image = My.Resources.Res.load

        Dim errorResult As New TestError

        'timer test analog
        tmrTest.Restart()
        'timer durata test 
        Do
            gui.ChangeControlText(gui.ANAVolt5, VarRxFromETSDN.GetIntance.rANA5 / 1000 & "V")
            gui.ChangeControlText(gui.ANAVolt10, VarRxFromETSDN.GetIntance.rANA10 / 1000 & "V")
            'scannerrizzo se ci sono nuovi messaggi dal can 
            VarRxFromETSDN.GetIntance.ScanParseMsg()
            'controllo fail deve stare sotto la soglia impostata 

            If VarRxFromETSDN.GetIntance.end_test_5v Then
                If VarRxFromETSDN.GetIntance.result_test_5v Then
                    gui.pbox_Ana5v.Image = My.Resources.Correct
                Else
                    gui.pbox_Ana5v.Image = My.Resources.Res.error_FILL
                End If
            End If

            If VarRxFromETSDN.GetIntance.end_test_10v Then
                If VarRxFromETSDN.GetIntance.result_test_10v Then
                    gui.pbox_Ana10v.Image = My.Resources.Correct
                Else
                    gui.pbox_Ana10v.Image = My.Resources.Res.error_FILL
                End If
            End If

            If VarRxFromETSDN.GetIntance.end_test_5v And VarRxFromETSDN.GetIntance.end_test_10v Then
                testCompleted = True
            End If
            If VarRxFromETSDN.GetIntance.result_test_5v And VarRxFromETSDN.GetIntance.result_test_10v Then
                testSuccess = True
            End If
            canEtsdnVar.SendCmdToEtsdn(varTxEtsdn.MsgComposer(), 20)
        Loop While testCompleted = False And Not gui.abortTest

        If Not VarRxFromETSDN.GetIntance.result_test_5v Then
            viewError &= errorResult.GetError(12, VarRxFromETSDN.GetIntance.rANA5)
        End If

        If Not VarRxFromETSDN.GetIntance.result_test_10v Then
            viewError &= errorResult.GetError(13, VarRxFromETSDN.GetIntance.rANA10)
        End If

        If Not testSuccess Then
            gui.StatoTestAnalog.Image = My.Resources.Res.error_FILL
            'gui.ChangeControlLocation(gui.StatoTestAnalog, 0, 42)
        End If
        tmrTest.Reset()
        varTxEtsdn.SetState10V(0)
        varTxEtsdn.SetState5V(0)

        Dim result As New TestResultAnalog(testCompleted, testSuccess, resultAna5v, resultAna10v, nameOftest, viewError, VarRxFromETSDN.GetIntance.etsdnSN, gui.ckBox_Ana.Checked)
        Return result

    End Function


    Public Sub New(tmrTest_threshold As Integer, minimum_threshold_gap As Integer, maximum_threshold_gap As Integer,
                   minimum_threshold_fail As Integer, maximum_threshold_fail As Integer)
        MyBase.New()
        Me.tmrTest_threshold = tmrTest_threshold
        Me.minimum_threshold_gap = minimum_threshold_gap
        Me.maximum_threshold_gap = maximum_threshold_gap
        Me.minimum_threshold_fail = minimum_threshold_fail
        Me.maximum_threshold_fail = maximum_threshold_fail
    End Sub
End Class

'max gap 10 min 10 
'max fail 50 min 0
'ana10 min -2 max 50
'