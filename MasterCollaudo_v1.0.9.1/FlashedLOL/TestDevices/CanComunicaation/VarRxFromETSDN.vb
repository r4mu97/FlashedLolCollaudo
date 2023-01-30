Imports FlashedLOL.Peak.Can.Basic

Public Class VarRxFromETSDN
    Public vTensione As Single
    Public xStatoRL1, xStatoRL2, xStatoRL3 As Boolean
    Public xStatoIP1, xStatoIP2, xStatoIN1, xStatoIN2 As Single
    Public rANA5, rANA10, r5V, rSupplyANA10v, rSupplyANA5v As Single
    Public axisX, axisY, axisZ As Single
    Public plcEcuK15, plcPowerCurr, plc5V As Double
    Public vCurrentRL1, vCurrentRL2, vCurrentRL3 As Single
    Public rSupplyVoltageEtsdn As UInteger = 0
    Public MsgCanPLC As Single
    Public etsdnOnline As Boolean
    Public etsdnSN As String = ""
    Public canOpenInizialized As Boolean
    Public timerComunicationCan As New Stopwatch
    Public end_test_5v As Byte = 0, end_test_10v As Byte = 0
    Public result_test_5v As Byte = 0, result_test_10v As Byte = 0
    Private Sub New()
    End Sub

    Public Shared ReadOnly Property GetIntance As VarRxFromETSDN

        Get
            Static varETSDN As New VarRxFromETSDN
            Return varETSDN

        End Get
    End Property



    Public Sub ParsingMSG(ID, Data)

        Static Dim etsdnSN01 As String
        Static Dim etsdnSN02 As String
        Static Dim etsdnSN03 As String
        timerComunicationCan.Start()
        Try


            Select Case (ID)
                Case &H10000
                    xStatoRL1 = Data(0) And &B1
                    xStatoRL2 = Data(0) And &B10
                    xStatoRL3 = Data(0) And &B100
                    etsdnOnline = Data(1)
                    timerComunicationCan.Reset()
                Case &H10001
                    plcEcuK15 = Convert.ToSingle(Data(0)) + (Convert.ToSingle(Data(1)) << 8)
                    plcPowerCurr = Convert.ToSingle(Data(2)) + (Convert.ToSingle(Data(3)) << 8)
                    plc5V = Data(4) + (CType(Data(5), UShort) << 8)

                Case &H10002
                    vCurrentRL1 = Data(0) + (CType(Data(1), UShort) << 8)
                    vCurrentRL2 = Data(2) + (CType(Data(3), UShort) << 8)
                    vCurrentRL3 = Data(4) + (CType(Data(5), UShort) << 8)


                Case &H20001
                    xStatoIP1 = (Data(0) >> 0) And &B1
                    xStatoIP2 = (Data(0) >> 1) And &B1
                    xStatoIN1 = (Data(0) >> 2) And &B1
                    xStatoIN2 = (Data(0) >> 3) And &B1

                    rSupplyVoltageEtsdn = Data(4) + (CType(Data(5), UInteger) << 8)

                Case &H20002
                    rANA10 = Convert.ToSingle(Data(0)) + (Convert.ToSingle(Data(1)) << 8)
                    rANA5 = Convert.ToSingle(Data(2)) + (Convert.ToSingle(Data(3)) << 8)
                    rSupplyANA10v = Convert.ToSingle(Data(4)) + (Convert.ToSingle(Data(5)) << 8)
                    rSupplyANA5v = Convert.ToSingle(Data(6)) + (Convert.ToSingle(Data(7)) << 8)

                Case &H20003
                    Dim tempB0, tempB1 As Int16
                    tempB0 = tempB1 = 0

                    tempB0 = Data(0)
                    tempB1 = Data(1)

                    axisY = (Convert.ToSingle(tempB0 + ((tempB1) << 8))) * 0.000244140625

                    tempB0 = Data(2)
                    tempB1 = Data(3)
                    axisX = (Convert.ToSingle(tempB0 + ((tempB1) << 8))) * 0.000244140625

                    tempB0 = Data(6)
                    tempB1 = Data(7)
                    axisZ = (Convert.ToSingle(tempB0 + ((tempB1) << 8))) * 0.000244140625

                Case &H101
                    etsdnSN01 = Chr(Data(0)) & Chr(Data(1)) & Chr(Data(2)) & Chr(Data(3)) &
                              Chr(Data(4)) & Chr(Data(5)) & Chr(Data(6)) & Chr(Data(7))
                Case &H102
                    etsdnSN02 = Chr(Data(0)) & Chr(Data(1)) & Chr(Data(2)) & Chr(Data(3)) &
                              Chr(Data(4)) & Chr(Data(5)) & Chr(Data(6)) & Chr(Data(7))
                Case &H103
                    etsdnSN03 = Chr(Data(0)) & Chr(Data(1)) & Chr(Data(2)) & Chr(Data(3)) &
                            Chr(Data(4)) & Chr(Data(5)) & Chr(Data(6)) & Chr(Data(7))

                    etsdnSN = etsdnSN01 & etsdnSN02 & etsdnSN03
                    Try
                        If Not etsdnSN = Nothing Then
                            Dim pos = InStr(etsdnSN, vbCrLf)
                            etsdnSN = etsdnSN.Substring(0, pos - 1)
                            etsdnSN = Replace(etsdnSN, "|", "_")
                            etsdnSN = Replace(etsdnSN, ".", "-")
                        End If
                    Catch ex As Exception

                    End Try
                Case &H105
                    end_test_5v = Data(0)
                    result_test_5v = Data(1)
                    end_test_10v = Data(2)
                    result_test_10v = Data(3)

            End Select


        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Sub

    Public Function ScanParseMsg(Optional timeoutmilliseconds As Integer = 100)

        Dim raw_msg As New TPCANMsg()
        Dim sw As New Stopwatch

        sw.Restart()

        While sw.ElapsedMilliseconds <= timeoutmilliseconds

            If receiveCANMessage(raw_msg) Then
                Dim ID = raw_msg.ID
                Dim DATA = raw_msg.DATA
            End If

            ParsingMSG(raw_msg.ID, raw_msg.DATA)
        End While
    End Function

    Public Function ResetData()
        vTensione = 0
        xStatoRL1 = 0
        xStatoRL2 = 0
        xStatoRL3 = 0
        xStatoIP1 = 0
        xStatoIP2 = 0
        xStatoIN1 = 0
        xStatoIN2 = 0
        rANA5 = 0
        rANA10 = 0
        r5V = 0
        rSupplyANA10v = 0
        rSupplyANA5v = 0
        axisX = 0
        axisY = 0
        axisZ = 0
        plcEcuK15 = 0
        plcPowerCurr = 0
        plc5V = 0
        vCurrentRL1 = 0
        vCurrentRL2 = 0
        vCurrentRL3 = 0
        rSupplyVoltageEtsdn = 0
        MsgCanPLC = 0
        etsdnSN = ""
    End Function

End Class
