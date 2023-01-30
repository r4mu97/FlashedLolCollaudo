Public Class CanCommunication

    Protected tmr As New Stopwatch
    Dim tmr_heartbeat As New Stopwatch
    Protected timeout_heartbeat = 50


    '       Public byteToSend As Byte

    Function InitCanOpen()
        Try
            'timer per la connessione CAN
            tmr.Start()
            'imposto un limite di 5s' per stabilire la connessione
            If tmr.ElapsedMilliseconds < 5000 And Not VarRxFromETSDN.GetIntance.canOpenInizialized Then

                Dim canChannels = getAvailableCanChannels()
                VarRxFromETSDN.GetIntance.canOpenInizialized = False

                If init_CANOPEN(canChannels(0), TPCANOPENBaudrate.PCANOPENBAUD_250K, False) Then
                    'resetto il timer 
                    tmr.Reset()
                    VarRxFromETSDN.GetIntance.canOpenInizialized = True
                End If
            Else
                Dim answer As MsgBoxResult
                answer = MsgBox("Error Can Comunication: Check your comunication with USB Peack", MsgBoxStyle.RetryCancel)

                If answer = MsgBoxResult.Retry Then
                    tmr.Restart()
                    InitCanOpen()
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("Error during init Can")
        End Try


    End Function

    '\\Sub per fornire all'esterno l'inizializzazione del CAN
    Public Function is_Inizialized()
        Return VarRxFromETSDN.GetIntance.canOpenInizialized
    End Function

    '\\creato trhead nel MainETSDN in modo da looppare l'invio del selettore test
    Function heartbeat()

        While True
            tmr_heartbeat.Start()
            If tmr_heartbeat.ElapsedMilliseconds > timeout_heartbeat Then
                Dim canMsg As New TPCANOPENMsg()
                canMsg.ID = &H180
                canMsg.LEN = 8
                canMsg.DATA = New Byte() {0, 0, 0, 0, 0, 0, 0, 0}

                canMsg.DATA(0) = 1
                sendCANMessage(canMsg)
                tmr_heartbeat.Reset()
            End If
        End While
    End Function


    Function SendCmdToEtsdn(bytesToSend As UShort, Optional timeoutmilliseconds As Integer = 50)

        If VarRxFromETSDN.GetIntance.canOpenInizialized Then

            Dim canMsg As New TPCANOPENMsg()

            canMsg.ID = &H380
            canMsg.LEN = 8
            canMsg.DATA = New Byte() {0, 0, 0, 0, 0, 0, 0, 0}

            canMsg.DATA(0) = 0
            canMsg.DATA(1) = Convert.ToByte(bytesToSend And &HFF)
            canMsg.DATA(2) = Convert.ToByte(bytesToSend >> 8)
            sendCANMessage(canMsg)
        End If

    End Function

End Class
