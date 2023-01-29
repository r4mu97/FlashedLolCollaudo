Public Class TestInputsEtsdn
    Inherits PrototypTest
    Public reportIp As New ReportTestInput
    Public reportAna As New ReportTestAnalog

    Dim stepIP As Integer
    Dim resultIP1 As Boolean, resultIP2 As Boolean, resultIN1 As Boolean, resultIN2 As Boolean
    Dim tmrtestIp As Stopwatch
    Dim tmrTest_threshold As Integer
    Dim tmrTestIp_threshold As Integer

    Public Overrides Function Execute(gui As MainEtsdn) As TestResult


        nameOftest = "Test Inputs"  'dichiaro il nome del test 
        testSuccess = False     'imposto a false per i test successivi 
        testCompleted = False   'imposto a false per i test successivi 
        tmrTest.Restart()         'starto il timer del test generale 
        tmrtestIp.Restart()       'starto il timer dei test interni degli ingressi 
        stepIP = 0              'setto a zero per i test successvi 

        gui.pBox_IP1.Image = Nothing '|
        gui.pBox_IP2.Image = Nothing '|-> resetto le immagine dalle picture box 
        gui.pBox_IN1.Image = Nothing '|
        gui.pBox_IN2.Image = Nothing '|

        gui.StatoTestIngressi.Image = My.Resources.Res.load       'carico l'immagine del loading nella pBox
        Dim errorResult As New TestError
        'loop controllo
        Do
            'scannerizzo nuovi messaggi sul can 
            VarRxFromETSDN.GetIntance.ScanParseMsg()
            Select Case stepIP
                Case 0
                    varTxEtsdn.SetStateIP1(1)
                    tmrtestIp.Restart()
                    stepIP += 1
                Case 1
                    'controllo IP1
                    If VarRxFromETSDN.GetIntance.xStatoIP1 = 1 And VarRxFromETSDN.GetIntance.xStatoIP2 = 0 And
                       VarRxFromETSDN.GetIntance.xStatoIN1 = 0 And VarRxFromETSDN.GetIntance.xStatoIN2 = 0 Then
                        stepIP += 1
                        resultIP1 = True
                        tmrtestIp.Restart()
                        varTxEtsdn.SetStateIP2(1)
                        varTxEtsdn.SetStateIP1(0)
                        gui.pBox_IP1.Image = My.Resources.Correct
                    ElseIf tmrtestIp.ElapsedMilliseconds >= tmrTestIp_threshold Then
                        stepIP += 1
                        resultIP1 = False
                        tmrtestIp.Restart()
                        varTxEtsdn.SetStateIP2(1)
                        varTxEtsdn.SetStateIP1(0)
                        gui.pBox_IP1.Image = My.Resources.Res.error_FILL
                        viewError &= errorResult.GetError(8, VarRxFromETSDN.GetIntance.xStatoIP1, VarRxFromETSDN.GetIntance.xStatoIP2,
                                                             VarRxFromETSDN.GetIntance.xStatoIN1, VarRxFromETSDN.GetIntance.xStatoIN2)
                    End If
                Case 2
                    'controllo IP2
                    If VarRxFromETSDN.GetIntance.xStatoIP2 = 1 And VarRxFromETSDN.GetIntance.xStatoIP1 = 0 And
                        VarRxFromETSDN.GetIntance.xStatoIN1 = 0 And VarRxFromETSDN.GetIntance.xStatoIN2 = 0 Then
                        stepIP += 1
                        resultIP2 = True
                        tmrtestIp.Restart()
                        varTxEtsdn.SetStateIN1(1)
                        varTxEtsdn.SetStateIP2(0)
                        gui.pBox_IP2.Image = My.Resources.Correct
                    ElseIf tmrtestIp.ElapsedMilliseconds >= tmrTestIp_threshold Then
                        stepIP += 1
                        resultIP2 = False
                        tmrtestIp.Restart()
                        varTxEtsdn.SetStateIN1(1)
                        varTxEtsdn.SetStateIP2(0)
                        gui.pBox_IP2.Image = My.Resources.Res.error_FILL
                        viewError &= errorResult.GetError(9, VarRxFromETSDN.GetIntance.xStatoIP2, VarRxFromETSDN.GetIntance.xStatoIP1,
                                                            VarRxFromETSDN.GetIntance.xStatoIN1, VarRxFromETSDN.GetIntance.xStatoIN2)
                    End If
                Case 3
                    'controllo IN1
                    If VarRxFromETSDN.GetIntance.xStatoIN1 = 1 And VarRxFromETSDN.GetIntance.xStatoIP1 = 0 And
                        VarRxFromETSDN.GetIntance.xStatoIP2 = 0 And VarRxFromETSDN.GetIntance.xStatoIN2 = 0 Then
                        stepIP += 1
                        resultIN1 = True
                        tmrtestIp.Restart()
                        varTxEtsdn.SetStateIN2(1)
                        varTxEtsdn.SetStateIN1(0)
                        gui.pBox_IN1.Image = My.Resources.Correct
                    ElseIf tmrtestIp.ElapsedMilliseconds >= tmrTestIp_threshold Then
                        stepIP += 1
                        resultIN1 = False
                        tmrtestIp.Restart()
                        varTxEtsdn.SetStateIN2(1)
                        varTxEtsdn.SetStateIN1(0)
                        gui.pBox_IN1.Image = My.Resources.Res.error_FILL
                        viewError &= errorResult.GetError(10, VarRxFromETSDN.GetIntance.xStatoIN1, VarRxFromETSDN.GetIntance.xStatoIP1,
                                                              VarRxFromETSDN.GetIntance.xStatoIP2, VarRxFromETSDN.GetIntance.xStatoIN2)
                    End If
                Case 4
                    'controllo IN2
                    If VarRxFromETSDN.GetIntance.xStatoIN2 = 1 And VarRxFromETSDN.GetIntance.xStatoIP1 = 0 And
                        VarRxFromETSDN.GetIntance.xStatoIP2 = 0 And VarRxFromETSDN.GetIntance.xStatoIN1 = 0 Then
                        stepIP += 1
                        resultIN2 = True
                        tmrtestIp.Restart()
                        varTxEtsdn.SetStateIN2(0)
                        gui.pBox_IN2.Image = My.Resources.Correct
                    ElseIf tmrTest.ElapsedMilliseconds >= tmrTestIp_threshold Then
                        stepIP += 1
                        resultIN2 = False
                        tmrtestIp.Restart()
                        varTxEtsdn.SetStateIN2(0)
                        gui.pBox_IN2.Image = My.Resources.Res.error_FILL
                        viewError &= errorResult.GetError(11, VarRxFromETSDN.GetIntance.xStatoIN2, VarRxFromETSDN.GetIntance.xStatoIP1,
                                                             VarRxFromETSDN.GetIntance.xStatoIP2, VarRxFromETSDN.GetIntance.xStatoIN1)
                    End If
                Case 5
                    'controllo che tutti gli  inputs siano andati a buon fine
                    If resultIP1 And resultIP2 And resultIN1 And resultIN2 Then
                        tmrTest.Reset()
                        tmrtestIp.Reset()
                        testSuccess = True
                        testCompleted = True
                        gui.StatoTestIngressi.Image = My.Resources.Correct
                        Exit Do
                    Else
                        stepIP = 0
                        tmrtestIp.Restart()
                    End If
            End Select
            'invio dei messaggi settati
            canEtsdnVar.SendCmdToEtsdn(varTxEtsdn.MsgComposer(), 20)
        Loop While tmrTest.ElapsedMilliseconds <= tmrTest_threshold And Not gui.abortTest

        If Not testSuccess Then
            'carico l'immagine di errore 
            gui.StatoTestIngressi.Image = My.Resources.Res.error_FILL
            'spsoto la pBox nella posizione di errore
            'gui.ChangeControlLocation(gui.StatoTestIngressi, 0, 42)
        End If
        tmrTest.Reset()
        Dim result As New TestResultInputs(testCompleted, testSuccess, resultIP1, resultIP2, resultIN1, resultIN2, nameOftest, viewError, VarRxFromETSDN.GetIntance.etsdnSN, gui.ckBox_IP.Checked)
        Return result

    End Function


    Public Sub New(tmrTest_threshold As Integer, tmrTestIp_threshold As Integer, stepIP As Integer)
        MyBase.New()
        Me.tmrtestIp = New Stopwatch
        Me.stepIP = stepIP
        Me.tmrTest_threshold = tmrTest_threshold
        Me.tmrTestIp_threshold = tmrTestIp_threshold

    End Sub
End Class
