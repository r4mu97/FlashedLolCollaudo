Public Class Test5VsEtsdn
    Inherits PrototypTest
    Public report5V As New ReportTest5V
    Dim result5V
    Dim value5V As String
    'soglie impostate nel mainEtsdn 
    Dim tmrTest_threshold As Integer
    Dim minimum_threshold As Integer
    Dim maximum_threshold As Integer


    Public Overrides Function Execute(gui As MainEtsdn) As TestResult
        'value5V = varRxETSDN.plc5V.ToString / 10
        'timer generale test del 
        nameOftest = "Test 5V" 'dichiaro il nome del test 
        testSuccess = False    'setto a false per i successivi test 
        testCompleted = False  'setto a false per i successivi test 

        'gui.ChangeLocationPanel(gui.Panel5V, 8, 475) 'setto la posizione del panel test sulla form 
        'gui.ChangeControlLocation(gui.StatoTest5V, 197, 0)
        gui.StatoTest5V.Image = My.Resources.Res.load 'setto l'immagine di loading del test 

        'creo l'oggetto per la gestione degli errori a schermo
        Dim errorResult As New TestError

        'starto il timer del test 
        tmrTest.Restart()

        Do
            'scannerizzo nuovi messaggi ricevuti dal can 
            VarRxFromETSDN.GetIntance.ScanParseMsg()
            'aggiorno il valore del 5v sulla label nel form 
            gui.ChangeControlText(gui.lbl5V, VarRxFromETSDN.GetIntance.plc5V / 10)
            'controllo con le soglie impostate 
            If Not VarRxFromETSDN.GetIntance.plc5V > maximum_threshold And Not VarRxFromETSDN.GetIntance.plc5V < minimum_threshold Then
                '\\test passato
                testCompleted = True
                testSuccess = True
                'carico l'immagine "test passato" sul form per l'utente 
                gui.StatoTest5V.Image = My.Resources.Correct
                'report5V.SetResult5V(result5V, value:=VarRxFromETSDN.GetIntance.plc5V.ToString / 10)
                Exit Do
            End If
            canEtsdnVar.SendCmdToEtsdn(varTxEtsdn.MsgComposer(), 20)
        Loop While tmrTest.ElapsedMilliseconds <= tmrTest_threshold And Not gui.abortTest

        If Not testSuccess Then
            'carico l'immagine errore sul form 
            gui.StatoTest5V.Image = My.Resources.Res.error_FILL
            viewError = errorResult.GetError(7, VarRxFromETSDN.GetIntance.plc5V / 10)
        End If
        tmrTest.Reset()
        Dim result As New TestResult5v(testCompleted, testSuccess, nameOftest, viewError, VarRxFromETSDN.GetIntance.etsdnSN, gui.ckBox_5v.Checked)
        Return result

    End Function



    Public Sub New(tmrTest_threshold As Integer, minimum_threshold As Integer, maximum_threshold As Integer)
        MyBase.New()
        Me.tmrTest = tmrTest
        Me.tmrTest_threshold = tmrTest_threshold
        Me.maximum_threshold = maximum_threshold
        Me.minimum_threshold = minimum_threshold
    End Sub
End Class


'
'.plc5V > 51
'varRxETSDN.plc5V < 49 