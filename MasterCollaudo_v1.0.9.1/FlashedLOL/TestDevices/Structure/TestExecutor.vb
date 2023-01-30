Imports System.Threading

Public Class TestExecutor

    Dim varTxEtsdn As New VarTxToETSDN
    Dim canEtsdnVar As New CanCommunication
    Public Function Execute_test_suite(suite As TestSuite, gui As MainEtsdn)
        Dim nTestDone As Integer = 0
        'creo la lista dei risultati ogni volta che chiamo la fuznione(ogni volta che lancio il collaudo di un dispositivo)
        Dim results As New List(Of TestResult)
        Try
            'creo ciclo for per ogni test all'interno della lista che restituisce la funzione "GetTests"
            For Each test In suite.GeTests()

                If Not gui.abortTest Then
                    gui.ChangeControlText(gui.TestingSerial, VarRxFromETSDN.GetIntance.etsdnSN)

                    'creo la variabile che si prende in memoria ogni risultato del test 
                    'chiamo la funzione di esecuzione del test tramite l'assegnazione alla variabile che prende come ingresso il risultato del test 
                    Dim testresult As TestResult = test.Execute(gui)
                    'aggiungo ad una lista ogni risultato di ogni test 
                    results.Add(testresult)
                    nTestDone += 1
                    gui.ChangeControlBarValue(gui.BarTestEtsdn, nTestDone)
                    testresult.print_result()

                    If testresult.IsSuccesfull Then
                        gui.ChangeControlRichText(gui.RichTextBox1, testresult.NameTest() & " OK!", "Green")
                    Else
                        gui.ChangeControlRichText(gui.RichTextBox1, testresult.NameTest() & " FAIL!", "Orange")
                        gui.ChangeControlRichText(gui.RichTextBox1, testresult.ErrorType(), "Red")
                        gui.fail = True
                    End If
                Else
                    Exit For
                End If
            Next
            suite.ClearListOfTest()
            Return results

        Catch ex As Exception
            gui.ChangeControlRichText(gui.RichTextBox1, ex.ToString, "Red")
        End Try
    End Function

End Class
