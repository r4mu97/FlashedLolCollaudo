Imports System.Web

Public Class TestAccEtsdn
    Inherits PrototypTest
    Public reportAcc As New ReportoTestAccelerometer

    Dim valueZ, valueY, valueX
    Dim firstPos, secondPos
    Dim guideTest As String
    Dim tmrTest_threshold As Integer
    Dim stepAcc As Integer
    Dim rAccTolerance As Double
    Public Overrides Function Execute(gui As MainEtsdn) As TestResult

        nameOftest = "TestAcc"  'dichiaro il nome del test
        testSuccess = False     'inizializzo per il test successivo 
        testCompleted = False   'inizializzo per il test successivo 
        stepAcc = 0
        gui.ChangeControlText(gui.MsgTestAcc, "")
        'gui.ChangeControlLocation(gui.StatoTestAccellerometro, 393, 0)
        gui.StatoTestAccellerometro.Image = My.Resources.Res.load
        'cambio la foto più grande del pannello per la gif del test
        gui.pnlAcc.Image = My.Resources.Res.panelAccLungodrawio
        gui.ChangeSizePbox(gui.pnlAcc, 420, 129)
        gui.ChangeLocationPbox(gui.pnlAcc, 526, 244)
        gui.ChangeControlVisibility(gui.pBox_Etsdn, True)
        'creo l'oggetto per la gestione dell'errore
        Dim errroResult As New TestError

        'setto il timer del test 
        tmrTest.Restart()

        Do
            'scannerizzo nuovi messaggi ricevuti dal can
            VarRxFromETSDN.GetIntance.ScanParseMsg()
            gui.ChangeControlText(gui.accZ, Math.Round(VarRxFromETSDN.GetIntance.axisZ, 3, MidpointRounding.AwayFromZero))
            gui.ChangeControlText(gui.accY, Math.Round(VarRxFromETSDN.GetIntance.axisY, 3, MidpointRounding.AwayFromZero))
            gui.ChangeControlText(gui.accX, Math.Round(VarRxFromETSDN.GetIntance.axisX, 3, MidpointRounding.AwayFromZero))
            Select Case stepAcc
                Case 0
                    'inizializzo una posizione zero del dispositivo 
                    gui.ChangeControlText(gui.MsgTestAcc, "Posizionare ETSDN come in figura")
                    gui.pBox_Etsdn.Image = My.Resources.ETSDN_statico1
                    stepAcc += 1

                Case 1
                    'controllo che il dispositivo sia nella poszione giusta 
                    If (VarRxFromETSDN.GetIntance.axisZ > 1 - rAccTolerance And VarRxFromETSDN.GetIntance.axisZ < 1 + rAccTolerance) And
                       (VarRxFromETSDN.GetIntance.axisY > -rAccTolerance And VarRxFromETSDN.GetIntance.axisY < rAccTolerance) And
                       (VarRxFromETSDN.GetIntance.axisX > -rAccTolerance And VarRxFromETSDN.GetIntance.axisX < rAccTolerance) Then
                        stepAcc += 1
                    End If

                Case 2
                    'controllo che il dispositivo faccia il movimento 
                    gui.ChangeControlText(gui.MsgTestAcc, "Inclina ETSDN come in figura")
                    gui.pBox_Etsdn.Image = My.Resources.Etsdn_Gif_gif
                    stepAcc += 1

                Case 3
                    If (VarRxFromETSDN.GetIntance.axisY > -1 - rAccTolerance And VarRxFromETSDN.GetIntance.axisY < -1 + rAccTolerance) And
                       (VarRxFromETSDN.GetIntance.axisZ > -rAccTolerance And VarRxFromETSDN.GetIntance.axisZ < rAccTolerance) And
                       (VarRxFromETSDN.GetIntance.axisX > -rAccTolerance And VarRxFromETSDN.GetIntance.axisX < rAccTolerance) Then
                        stepAcc += 1
                    End If

                Case 4
                    gui.ChangeControlText(gui.MsgTestAcc, "")
                    tmrTest.Reset()
                    testSuccess = True
                    testCompleted = True
                    viewError = ""
                    gui.StatoTestAccellerometro.Image = My.Resources.Correct
                    'gui.ChangeControlLocation(gui.StatoTestAccellerometro, 197, 0)
                    Exit Do
            End Select
            canEtsdnVar.SendCmdToEtsdn(varTxEtsdn.MsgComposer(), 20)
        Loop While tmrTest.ElapsedMilliseconds <= tmrTest_threshold And Not gui.abortTest

        gui.pBox_Etsdn.Image = Nothing
        gui.ChangeControlText(gui.MsgTestAcc, "")
        gui.ChangeControlVisibility(gui.pBox_Etsdn, False)
        gui.pnlAcc.Image = My.Resources.Res.panelAcc
        gui.ChangeSizePbox(gui.pnlAcc, 256, 123)
        gui.ChangeLocationPbox(gui.pnlAcc, 520, 244)

        If Not testSuccess Then
            'gui.ChangeControlLocation(gui.StatoTestAccellerometro, 0, 42)
            gui.StatoTestAccellerometro.Image = My.Resources.Res.error_FILL
            viewError = errroResult.GetError(14, 0)
        End If

        tmrTest.Reset()
        Dim result As New TestResultAcc(testCompleted, testSuccess, nameOftest, viewError, VarRxFromETSDN.GetIntance.etsdnSN, gui.ckBox_Acc.Checked)
        Return result

    End Function


    Public Sub New(tmrTest_threshold As Integer, stepAcc As Integer, rAccTolerance As Double)
        MyBase.New()
        Me.stepAcc = stepAcc
        Me.rAccTolerance = rAccTolerance
        Me.tmrTest_threshold = tmrTest_threshold
    End Sub
End Class
