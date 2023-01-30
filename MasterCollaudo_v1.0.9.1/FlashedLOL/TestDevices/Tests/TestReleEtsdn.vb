Public Class TestReleEtsdn
    Inherits PrototypTest
    Dim reportRl As New ReportTestRele
    'Soglie impostate nel mainEtsnd
    Dim tmrRele As Stopwatch
    Dim StepRele As Integer
    Dim resultR1 As Boolean, resultR2 As Boolean, resultR3 As Boolean
    Dim valueR1 As String, valueR2 As String, valueR3 As String
    Dim tmrTest_threshold As Integer
    Dim minimum_threshold As Integer
    Dim maximum_threshold As Integer
    Dim enable_test12v As Boolean = False

    Public Overrides Function Execute(gui As MainEtsdn) As TestResult

        nameOftest = "Test Rele" 'dichiaro il nome del test 
        testSuccess = False      'setto a false per i successivi test
        testCompleted = False    'setto a false per i successivi test
        StepRele = 0
        enable_test12v = False
        minimum_threshold = 450
        maximum_threshold = 510
        'gui.ChangeControlLocation(gui.StatotestRele, 197, 0)
        gui.StatotestRele.Image = My.Resources.Res.load
        Dim errorResult As New TestError
        'timer generale del test 
        tmrTest.Restart()
        Do
            'scannerizzo nuovi messaggi dal can 
            VarRxFromETSDN.GetIntance.ScanParseMsg()
            gui.ChangeControlText(gui.LabelRL2, VarRxFromETSDN.GetIntance.vCurrentRL2 / 1000 & " Amps") '|
            gui.ChangeControlText(gui.LabelRL3, VarRxFromETSDN.GetIntance.vCurrentRL3 / 1000 & " Amps") '|-> aggiorno le label con il valore della corrente dei relè
            gui.ChangeControlText(gui.LabelRL1, VarRxFromETSDN.GetIntance.vCurrentRL1 / 1000 & " Amps") '|

            Select Case StepRele
           'step dove setto il timer, apro i rele e gli alimento
                Case 0
                    'apro i rele 
                    varTxEtsdn.SetStateAllRl(0)
                    'alimento tutti i relè per il controllo nello step successivo 
                    varTxEtsdn.SetAllPwrRL(1)
                    StepRele += 1
                    tmrRele.Restart()
                Case 1
                    'primo controllo che tutti i rele siano aperti e che non ci sia corrente
                    If Not VarRxFromETSDN.GetIntance.vCurrentRL1 > 10 And Not VarRxFromETSDN.GetIntance.vCurrentRL2 > 15 And Not VarRxFromETSDN.GetIntance.vCurrentRL3 > 10 Then
                        StepRele += 1
                        'chiudo il primo rele
                        varTxEtsdn.SetStateRL1(1)
                    Else
                        If VarRxFromETSDN.GetIntance.vCurrentRL1 > 10 Then
                            viewError &= errorResult.GetError(1, VarRxFromETSDN.GetIntance.vCurrentRL1)
                        ElseIf VarRxFromETSDN.GetIntance.vCurrentRL2 > 15 Then
                            viewError &= errorResult.GetError(2, VarRxFromETSDN.GetIntance.vCurrentRL2)
                        ElseIf VarRxFromETSDN.GetIntance.vCurrentRL3 > 10 Then
                            viewError &= errorResult.GetError(3, VarRxFromETSDN.GetIntance.vCurrentRL3)
                        End If
                    End If
                Case 2
                    'controllo del primo rele che rimanga nei range della soglia impostata 
                    If VarRxFromETSDN.GetIntance.vCurrentRL1 > minimum_threshold And VarRxFromETSDN.GetIntance.vCurrentRL1 < maximum_threshold Then 'da modificare in base alla resistenza 
                        resultR1 = True
                        'apro il rele 1 
                        varTxEtsdn.SetStateRL1(0)
                        'chiudo il rele 2 
                        varTxEtsdn.SetStateRL2(1)
                        StepRele += 1
                        tmrRele.Restart()
                        reportRl.SetResultRL1(pass:=True)
                        'se il test del rele1 scade vado a vanti lo stesso e vado sul prossimo step
                    ElseIf tmrRele.ElapsedMilliseconds >= 2000 Then
                        resultR1 = False
                        varTxEtsdn.SetStateRL1(0)
                        varTxEtsdn.SetStateRL2(1)
                        StepRele += 1
                        tmrRele.Restart()
                        viewError &= errorResult.GetError(4, VarRxFromETSDN.GetIntance.vCurrentRL1)
                        reportRl.SetResultRL1(pass:=False, value:=VarRxFromETSDN.GetIntance.vCurrentRL1, comment:="  (Must be > 450 and < 510)")
                    End If

                Case 3
                    'controllo del secondo rele che rimanga nei range della soglia impostata 
                    If VarRxFromETSDN.GetIntance.vCurrentRL2 > minimum_threshold And VarRxFromETSDN.GetIntance.vCurrentRL2 < maximum_threshold Then
                        resultR2 = True
                        'apro rele 2
                        varTxEtsdn.SetStateRL2(0)
                        'chiudo rele 3
                        varTxEtsdn.SetStateRL3(1)
                        StepRele += 1
                        tmrRele.Restart()
                        reportRl.SetResultRL2(pass:=True)
                        'se il tmr del test rele2 scade vado avanti sul prossimo step 
                    ElseIf tmrRele.ElapsedMilliseconds >= 2000 Then
                        resultR2 = False
                        'apro rele2 
                        varTxEtsdn.SetStateRL2(0)
                        'chiudo rele3
                        varTxEtsdn.SetStateRL3(1)
                        StepRele += 1
                        tmrRele.Restart()
                        viewError &= errorResult.GetError(5, VarRxFromETSDN.GetIntance.vCurrentRL2)
                        reportRl.SetResultRL2(pass:=False, value:=VarRxFromETSDN.GetIntance.vCurrentRL2, comment:="  (Must be > 450 and < 510)")
                    End If

                Case 4
                    'controlo del terzo rele che rimanga nei range della soglia impostata  
                    If VarRxFromETSDN.GetIntance.vCurrentRL3 > minimum_threshold And VarRxFromETSDN.GetIntance.vCurrentRL3 < maximum_threshold Then
                        resultR3 = True
                        'apro rele3 
                        varTxEtsdn.SetStateRL3(0)
                        StepRele += 1
                        tmrRele.Restart()
                        reportRl.SetResultRL3(pass:=True)
                        'se il tmr del test rele3 scade vado sul prossimo step che fa ricominciare il test 
                    ElseIf tmrRele.ElapsedMilliseconds >= 2000 Then
                        resultR3 = False
                        varTxEtsdn.SetStateRL3(0)
                        StepRele += 1
                        tmrRele.Restart()
                        viewError &= errorResult.GetError(6, VarRxFromETSDN.GetIntance.vCurrentRL3)
                        reportRl.SetResultRL3(pass:=False, value:=VarRxFromETSDN.GetIntance.vCurrentRL3, comment:="  (Must be > 450 and < 510)")
                    End If

                Case 5
                    If resultR1 And resultR2 And resultR3 Then
                        If enable_test12v = False Then
                            minimum_threshold = 175
                            maximum_threshold = 300
                            resultR1 = False
                            resultR2 = False
                            resultR3 = False
                            enable_test12v = True
                            StepRele = 0
                            gui.RDW_CommandCollaudo("VSET1:", "10")
                        Else
                            If resultR1 And resultR2 And resultR3 Then
                                StepRele = 0
                                testCompleted = True
                                testSuccess = True
                                'gui.ChangeControlLocation(gui.StatotestRele, 197, 0)
                                gui.StatotestRele.Image = My.Resources.Correct
                                varTxEtsdn.SetAllPwrRL(0)
                                varTxEtsdn.SetStateAllRl(0)
                                viewError = ""
                                Exit Do
                                'altrimenti ricomincio il test non rifacendo quelli che hanno avuto successo 
                            Else
                                StepRele = 2
                                varTxEtsdn.SetStateAllRl(0)
                                varTxEtsdn.SetStateRL1(1)
                            End If
                        End If
                    Else
                        'controllo che tutti i test singoli dei rele siano passati 
                        If resultR1 And resultR2 And resultR3 Then
                            StepRele = 0
                            testCompleted = True
                            testSuccess = True
                            'gui.ChangeControlLocation(gui.StatotestRele, 197, 0)
                            gui.StatotestRele.Image = My.Resources.Correct
                            varTxEtsdn.SetAllPwrRL(0)
                            varTxEtsdn.SetStateAllRl(0)
                            viewError = ""
                            Exit Do
                            'altrimenti ricomincio il test non rifacendo quelli che hanno avuto successo 
                        Else
                            StepRele = 2
                            varTxEtsdn.SetStateAllRl(0)
                            varTxEtsdn.SetStateRL1(1)
                        End If
                    End If
            End Select
            'invio i messaggi settati durante il test 
            canEtsdnVar.SendCmdToEtsdn(varTxEtsdn.MsgComposer(), 20)
        Loop While tmrTest.ElapsedMilliseconds <= tmrTest_threshold And Not gui.abortTest

        'se il loop fininsce e il test non è passato aggiorno la grafica con l'immagine di errore 
        If Not testSuccess Then
            'gui.ChangeControlLocation(gui.StatotestRele, 0, 42)
            gui.StatotestRele.Image = My.Resources.Res.error_FILL
        End If
        'resetto il timer del test 
        StepRele = 0
        tmrTest.Reset()
        varTxEtsdn.SetAllPwrRL(0)
        varTxEtsdn.SetStateAllRl(0)
        canEtsdnVar.SendCmdToEtsdn(varTxEtsdn.MsgComposer(), 20)
        gui.RDW_CommandCollaudo("VSET1:", "24")
        'creo l'oggetto del risultato del test passandogli il completamento e l'esito 
        Dim result As New TestResultRele(viewError, testCompleted, testSuccess, resultR1, resultR2, resultR3, nameOftest, VarRxFromETSDN.GetIntance.etsdnSN, gui.ckBox_Rele.Checked)
        'ritorno il valore che verrà gestito all'esterno
        Return result

    End Function

    Public Sub New(tmrTest_threshold As Integer, stepRele As Integer, minimum_threshold As Integer,
                   maximum_threshold As Integer)
        MyBase.New()
        Me.tmrRele = New Stopwatch
        Me.StepRele = stepRele
        Me.tmrTest_threshold = tmrTest_threshold
        Me.minimum_threshold = minimum_threshold
        Me.maximum_threshold = maximum_threshold
    End Sub
End Class

'minimum 450
'maximum 510