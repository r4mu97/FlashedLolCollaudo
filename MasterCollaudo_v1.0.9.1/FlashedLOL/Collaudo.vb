Imports System.IO
Imports System.Xml
Imports System.IO.Ports
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Runtime.InteropServices
Imports System.Web.Script.Serialization
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Text
Imports FlashedLOL.Peak.Can.Basic
Imports MongoDB.Bson
Imports System.Web
Imports Microsoft.Win32
Imports PdfSharp
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf


Public Class Collaudo
    Private thread As Thread
    Public mui As New Interfaccia_dbTraduzioni
    Private MySerialPort As System.IO.Ports.SerialPort
    Dim soundw As New Stopwatch
    Dim defaultMemoria = 82000
    Dim kiwisat As GRSat 'Test
    Dim Iniziacoll As Integer
    Dim sogliaErrore = 0.2
    Dim minimoTensione = 3.2
    Dim massimaTensione = 4.8
    Dim memoriaMinima = 70000
    Dim abortTests = False
    Dim CounterTest = 0
    Dim cloudCodeLocation = -1
    Public _RDWcommR01 As String = Nothing
    Private predictionService As Prediction

    Dim canEtsoneVar As New CanEtsone
    Dim statoCollaudoEtsone As New ClasseStatusTest
    Private varRxEtsone As New VarRxFromETSONE
    Dim varTxPlc As New VarTxToPlc
    Dim varSerial As New VarSerialEtsone
    Dim availableSerialPorts As String() = {}
    Dim log As New WriteReporEtsOne
    Dim reportPwr As New ReportTestPowerEtsOne
    Dim reportRl As New ReportTestReleEtsOne
    Dim reportIp As New ReportTestInputEtsOne
    Dim reportAna As New ReportTestAnalogEtsOne
    Dim report5V As New ReportTest5VEtsOne
    Dim reportCan As New ReportTestCanEtsOne
    Dim reportStart As New ReportStartTest
    Dim reportStop As New ReportStopTest
    Dim reportInfo As New ReportInfoTestEtsOne
    Dim reportEnd As New ReportEndTest
    Dim logtemporaneo As System.IO.StreamWriter

    Public Sub New(ByVal prediction As Prediction, ByVal touchChecked As Boolean)
        cloudCodeLocation = Main.cloudCodeLocation

        ' La chiamata è richiesta dalla finestra di progettazione.
        InitializeComponent()

        ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().
        predictionService = prediction
        CheckBoxUtenza.Checked = touchChecked
    End Sub

    Public Class VarRxFromETSONE
        Public plcEcuK15 As Double
        Public vTensione As Single
        Public vCurrentRL1, vCurrentRL2 As Single
        Public r5V, rANAIP4 As Single
        Public xUP As Single

        Public Sub ParsingMSG(ID, Data)

            Select Case (ID)
                Case &H3001
                    xUP = Data(0)
                    plcEcuK15 = Convert.ToSingle(Data(2)) + (Convert.ToSingle(Data(3)) << 8)
                    vTensione = Convert.ToSingle(Data(4)) + (Convert.ToSingle(Data(5)) << 8)
                    rANAIP4 = Convert.ToSingle(Data(6)) + (Convert.ToSingle(Data(7)) << 8)
                Case &H3002
                    vCurrentRL1 = Data(0) + (CType(Data(1), UShort) << 8)
                    vCurrentRL2 = Data(2) + (CType(Data(3), UShort) << 8)
                    r5V = Data(4) + (CType(Data(5), UShort) << 8)
            End Select
        End Sub
    End Class

    Public Class VarTxToPlc
        Dim setPWR, setRL1, setRL2, setIP1, setIP2, setIP3, setIP4, SetCAN_1 As Byte

        Public Sub SetStatePWR(stato)
            setPWR = stato
        End Sub
        Public Sub SetStateRL1(stato)
            setRL1 = stato
        End Sub
        Public Sub SetStateRL2(stato)
            setRL2 = stato
        End Sub
        Public Sub SetAllRL(stato)
            setRL1 = stato
            setRL2 = stato
        End Sub
        Public Sub SetStateIP1(stato)
            setIP1 = stato
        End Sub
        Public Sub SetStateIP2(stato)
            setIP2 = stato
        End Sub
        Public Sub SetStateIP3(stato)
            setIP3 = stato
        End Sub
        Public Sub SetStateIP4(stato)
            setIP4 = stato
        End Sub
        Public Sub SetAllIP(stato)
            setIP1 = stato
            setIP2 = stato
            setIP3 = stato
        End Sub
        Public Sub SetallCAN(stato)
            SetCAN_1 = stato
        End Sub

        Function MsgComposer() As UShort
            Dim VarTempComposer As UShort

            VarTempComposer = 0
            VarTempComposer = VarTempComposer + setIP1
            VarTempComposer = VarTempComposer + (CType(setIP2, UShort) << 1)
            VarTempComposer = VarTempComposer + (CType(setIP3, UShort) << 2)
            VarTempComposer = VarTempComposer + (CType(setRL1, UShort) << 3)
            VarTempComposer = VarTempComposer + (CType(setRL2, UShort) << 4)
            VarTempComposer = VarTempComposer + (CType(setIP4, UShort) << 5)
            VarTempComposer = VarTempComposer + (CType(setPWR, UShort) << 6)
            VarTempComposer = VarTempComposer + (CType(SetCAN_1, UShort) << 7)
            Return VarTempComposer
        End Function

    End Class

    Private Sub CollaudoETSONE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Scrivere in collaudotutto ciò che deve iniziare prima dei test
        System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Main.SerialPort.BaudRate = Main.main_speed

        If Main.SerialPort.IsOpen Then
            Main.SerialPort.Close()
        End If

        MySerialPort = Main.SerialPort
        MySerialPort.Open()
        LabelCom.Text = Main.SerialPort.PortName
        autoHostandLog()
        CaricaApn()
        statoCollaudoEtsone.fsmTest = -1
        statoCollaudoEtsone.CounterTest = -1
        statoCollaudoEtsone.OperatorName = Main.TextboxPredictionUsername.Text
        Try
            thread = New Thread(AddressOf MyBackgroundThread)
            thread.Start()

        Catch ex As Exception
            System.Console.WriteLine("Error during thread start")
        End Try
        '       Init del CAN
        ChangeBarColor(ProgressBarTest, ProgressBarColor.Yellow)
        InitializeBasicComponents()
        unInit_CANOPEN()
        canEtsoneVar.InitCanOpen()
        labelSerialNumber.Text = refreshSN()
        Console.WriteLine(TimeOfDay.ToLongTimeString)
        Console.WriteLine(Date.Now)
    End Sub

    Public Sub SetPopUpInfoTest()
        Dim PopUpInfo As New ToolTip()
        PopUpInfo.ShowAlways = True
        PopUpInfo.SetToolTip(ButtonStartTest,
        "Premere per eseguire il test")
        PopUpInfo.SetToolTip(InfoPWR,
        "Il test va eseguito a 24V sull'alimentatore.
        Il valore della corrente deve rimanere tra 50 e 35 per passare il test.
        Se il valore è molto più alto controllare che la batteria interna del dispositivo non sia collegata e ripetere il test.
        Controllare sempre sull'alimentatore possibili corti.")
        PopUpInfo.SetToolTip(InfoRL,
        "I valori dei due relè devono rimanere tra 200 e 240.
        Il test controlla che non ci siano corti tra i due relè aprendoli singolarmente e misurandone la corrente.")
        PopUpInfo.SetToolTip(InfoIP,
        "Viene fornita alimentazione singolarmente ad ogni IP e IN, viene controlalto anche che non ci siano 'corti' tra i vari ingressi.
        L'analogico viene controllato in base alla sua salita e discesa e che sia la stessa che viene fornita dalla centralina.")
        PopUpInfo.SetToolTip(Info5V,
        "Il valore deve stare tra 5,1 e 4,9")
        PopUpInfo.SetToolTip(InfoCAN,
        "Il controllo viene eseguito serialmente.
        Il test potrebbe fallire non per un malfunzionamneto del dispositivo ma bensì per una configurazione della scheda")
        PopUpInfo.SetToolTip(InfoACC,
        "Viene richiesto all'operatore di posizionare il dispositivo come mostrerà la figura durante il test e successivamente 
        muoverlo sempre seguendo l'illustrazione del test")
        PopUpInfo.SetToolTip(ErrorInfo,
        "Apre la gestione degli errori")
        PopUpInfo.SetToolTip(InfoSD, "
         Viene verificata la presenza dell'SD sulla scheda e se ha lo spazio necessario")
        PopUpInfo.SetToolTip(InfoBAT, "
         Durante il test la batteria interna del dispositvo deve essere collegata.
         Stato batteria = 3 significa che la batteria non è presente
         Stato batteria = 2 significa che la batteria è collegata
         Se lo stato è 2 viene controllata la tensione dell batteria che deve rimanere tra 3.2 e 4.8")
        PopUpInfo.SetToolTip(InfoSIM, "
         Viene verificata la presenza della SIM sull scheda.
         Se è presente bisognerà attendere che il dispositvo comunichi con il portale a lui associato.")
        PopUpInfo.SetToolTip(InfoPORT, "
         Attendere che il test trovi il dispositivo sul proprio portale")
        PopUpInfo.SetToolTip(InfoMemory, "
         Invio della memoria sul portale.
         Attendere che l'importazione della memoria raggiunga come valore 1024")
        PopUpInfo.SetToolTip(InfoRS232, "
         Selezionare il tipo di RS232 del dispositivo.
         Selezionando Barcode viene generata un' immagine da inquadrare con la 'barcode' ")
    End Sub
    Public Class CanEtsone
        Dim canOpenInizialized As Boolean

        '       Public byteToSend As Byte
        Function InitCanOpen()
            Try
                Dim canChannels = getAvailableCanChannels()
                canOpenInizialized = False

                If init_CANOPEN(canChannels(0), TPCANOPENBaudrate.PCANOPENBAUD_250K, False) Then
                    canOpenInizialized = True
                End If

            Catch ex As Exception
                System.Console.WriteLine("Error during init Can")
                MsgBox("Errore Comunicazione CAN", MsgBoxStyle.Critical)
            End Try

        End Function

        Function SendCmdToEtsone(bytesToSend As UShort, Optional timeoutmilliseconds As Integer = 50)


            If canOpenInizialized Then

                Dim canMsg As New TPCANOPENMsg()

                canMsg.ID = &H280
                canMsg.LEN = 8
                canMsg.DATA = New Byte() {0, 0, 0, 0, 0, 0, 0, 0}

                canMsg.DATA(0) = 0
                canMsg.DATA(1) = Convert.ToByte(bytesToSend And &HFF)
                sendCANMessage(canMsg)


                canMsg.ID = &H180
                canMsg.LEN = 8
                canMsg.DATA = New Byte() {2, 0, 0, 0, 0, 0, 0, 0}

                sendCANMessage(canMsg)

            End If
        End Function
    End Class

    Public Function ScanParseMsg(Optional timeoutmilliseconds As Integer = 100)

        Dim raw_msg As New TPCANMsg()
        Dim sw As New Stopwatch

        sw.Restart()

        While sw.ElapsedMilliseconds <= timeoutmilliseconds

            If receiveCANMessage(raw_msg) Then
                Dim ID = raw_msg.ID
                Dim DATA = raw_msg.DATA
            End If

            varRxEtsone.ParsingMSG(raw_msg.ID, raw_msg.DATA)
        End While
    End Function

    Public Class VarSerialEtsone
        Public serialRL1, serialRL2, serialIP1, serialIP2, serialIP3, serialIP4, serialCan1, serialCan2, serialIP, tensEsterna
        Public Function ParsingSerial(data As String)
            Try
                tensEsterna = CInt(Split(data, "|")(0))
                serialRL1 = CInt(Split(data, "|")(14))
                serialRL2 = CInt(Split(data, "|")(15))
                serialIP1 = CInt(Split(data, "|")(10))
                serialIP2 = CInt(Split(data, "|")(11))
                serialIP3 = CInt(Split(data, "|")(12))
                serialIP4 = CInt(Split(data, "|")(68))
                serialCan2 = CInt(Split(data, "|")(18))
                serialCan1 = CInt(Split(data, "|")(63))
                serialIP = Split(data, "|")
                serialIP = Replace(serialIP(33), ",", ".")
            Catch ex As Exception

            End Try
        End Function
    End Class

    Public Function SearchFile(ByVal strFilePath As String, ByVal strSearchTerm As String) As String
        Dim sr As StreamReader = New StreamReader(strFilePath)
        Dim strLine As String = String.Empty

        Try
            Do While sr.Peek() >= 0
                strLine = String.Empty
                strLine = sr.ReadLine
                If strLine.Contains(strSearchTerm) Then
                    sr.Close()
                    Exit Do
                End If
            Loop

            Return strLine
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Sub ButtonStartTest_Click(sender As Object, e As EventArgs) Handles ButtonStartTest.Click
        statoCollaudoEtsone.fsmTest = 0
    End Sub

    Private Sub ButtonStop_Click(sender As Object, e As EventArgs) Handles ButtonStop.Click
        statoCollaudoEtsone.fsmTest = 17
        abortTests = True
        reportStop.SetStopTest(clickstop:=True)
    End Sub


    Private Delegate Sub ChangeControlValueDelegate(ByVal ctrl As ProgressBar, ByVal value As Integer)
    Private Sub ChangeControlBarValue(ByVal ctrl As ProgressBar, ByVal value As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New ChangeControlValueDelegate(AddressOf ChangeControlBarValue), New Object() {ctrl, value})
            Return
        End If
        ctrl.Value = value
    End Sub

    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Enum ProgressBarColor
        Green = &H1
        Red = &H2
        Yellow = &H3
    End Enum

    Private Delegate Sub ChangeProgBarColorDelegate(ByVal ProgressBar_name As Windows.Forms.ProgressBar, ByVal ProgressBar_Color As ProgressBarColor)
    Private Sub ChangeBarColor(ByVal ProgressBar_name As Windows.Forms.ProgressBar, ByVal ProgressBar_Color As ProgressBarColor)
        If Me.InvokeRequired Then
            Me.Invoke(New ChangeProgBarColorDelegate(AddressOf ChangeBarColor), New Object() {ProgressBar_name, ProgressBar_Color})
            Return
        End If
        SendMessage(ProgressBar_name.Handle, &H410, ProgressBar_Color, 0)
    End Sub

    Private Delegate Sub ChangeControlTextDelegate(ByVal ctrl As Control, ByVal text As String)
    Private Sub ChangeControlText(ByVal ctrl As Control, ByVal text As String)
        If Me.InvokeRequired Then
            Me.Invoke(New ChangeControlTextDelegate(AddressOf ChangeControlText), New Object() {ctrl, text})
            Return
        End If
        ctrl.Text = text
    End Sub

    Private Delegate Sub ChangeControlBackgroundColorDelegate(ByVal ctrl As Control, ByVal color As Color)
    Private Sub ChangeControlBackgroundColor(ByVal ctrl As Control, ByVal color As Color)
        If Me.InvokeRequired Then
            Me.Invoke(New ChangeControlBackgroundColorDelegate(AddressOf ChangeControlBackgroundColor), New Object() {ctrl, color})
            Return
        End If
        ctrl.BackColor = color
    End Sub

    Private Delegate Sub ChangeControlVisibilityDelegate(ByVal ctrl As Control, ByVal visible As Boolean)
    Private Sub ChangeControlVisibility(ByVal ctrl As Control, ByVal visible As Boolean)
        Try
            If Me.InvokeRequired Then
                Me.Invoke(New ChangeControlVisibilityDelegate(AddressOf ChangeControlVisibility), New Object() {ctrl, visible})
                Return
            End If
            ctrl.Visible = visible
        Catch ex As Exception

        End Try
    End Sub

    Public Sub ErrorTestDevice()
        If ErrorTestPWR.Visible = True Or ErrorTestRL.Visible = True Or
            ErrorTestIP.Visible = True Or ErrorTest5V.Visible = True Or
            ErrorTestCAN.Visible = True Then
            ChangeControlVisibility(ButtonErrorView, True)
            ChangeBarColor(ProgressBarTest, ProgressBarColor.Red)
            ProgressBarTest.Value = 0
        Else
            ChangeBarColor(ProgressBarTest, ProgressBarColor.Green)
        End If

    End Sub


    Public Function CheckSerialPort()

        Dim port = System.IO.Ports.SerialPort.GetPortNames.ToList()
        port.Sort()
        PanelEventUSB.Location = New Point(289, 208)
        LabelErrorUSB.Location = New Point(310, 50)
        PanelEventUSB.Size = New Size(500, 250)
        PictureErrorUSB.Size = New Size(348, 282)

        If Not statoCollaudoEtsone.fsmTest = 1 Then
            While Not port.Contains(LabelCom.Text)
                ChangeControlVisibility(PanelEventUSB, True)
                ChangeControlVisibility(PictureErrorUSB, True)
                ChangeControlVisibility(PictureUSBscollegato, False)
                ChangeControlText(LabelErrorUSB, "Collegare USB")
                port = System.IO.Ports.SerialPort.GetPortNames.ToList()
                port.Sort()
            End While

            ChangeControlVisibility(PanelEventUSB, False)
            ChangeControlVisibility(PictureErrorUSB, False)
            Return True
        Else

        End If
    End Function

    Private Sub ResetLoadingStop()
        ChangeControlVisibility(LoadingPWR, False)
        ChangeControlVisibility(LoadingRL, False)
        ChangeControlVisibility(Loading5V, False)
        ChangeControlVisibility(LoadingIP, False)
        ChangeControlVisibility(LoadingCAN, False)
        ChangeControlVisibility(LoadingAcc, False)
        ChangeControlVisibility(LoadingSD, False)
        ChangeControlVisibility(LoadingBattery, False)
        ChangeControlVisibility(LoadingSIM, False)
        ChangeControlVisibility(LoadingWIFI, False)
        ChangeControlVisibility(LoadingPortale, False)
        ChangeControlVisibility(LoadingSync, False)
        ChangeControlVisibility(GifAcc, False)
    End Sub
    Private Sub ResetAllGraphichs()
        ProgressBarTest.Minimum = 0
        ProgressBarTest.Maximum = 17
        ProgressBarTest.Value = 0
        ChangeBarColor(ProgressBarTest, ProgressBarColor.Yellow)
        ChangeControlVisibility(testBadgeStatus, False)
        ChangeControlVisibility(testSDStatus, False)
        ChangeControlVisibility(testBatteryStatus, False)
        ChangeControlVisibility(testSIMStatus, False)
        ChangeControlVisibility(testAccelerometerStatus, False)
        ChangeControlVisibility(testWifiStatus, False)
        ChangeControlVisibility(testComunicazioneStatus, False)
        ChangeControlVisibility(testMemsyncStatus, False)
        ChangeControlVisibility(testETS_ETSDNStatus, False)
        ChangeControlVisibility(GifAcc, False)

        ChangeControlVisibility(LoadingAcc, False)
        ChangeControlVisibility(LoadingSD, False)
        ChangeControlVisibility(LoadingBattery, False)
        ChangeControlVisibility(LoadingSIM, False)
        ChangeControlVisibility(LoadingWIFI, False)
        ChangeControlVisibility(LoadingPortale, False)
        ChangeControlVisibility(LoadingSync, False)

        ChangeControlVisibility(TestAlimentazioneStatus, False)
        ChangeControlVisibility(TestReleStatus, False)
        ChangeControlVisibility(test5Vstatus, False)
        ChangeControlVisibility(testIngressiStatus, False)
        ChangeControlVisibility(TestCANStatus, False)

        ChangeControlVisibility(LoadingPWR, False)
        ChangeControlVisibility(LoadingRL, False)
        ChangeControlVisibility(Loading5V, False)
        ChangeControlVisibility(LoadingIP, False)
        ChangeControlVisibility(LoadingCAN, False)

        ChangeControlVisibility(PWR_OK, False)
        ChangeControlVisibility(PWR_NOT, False)
        ChangeControlVisibility(RL1_OK, False)
        ChangeControlVisibility(RL2_OK, False)
        ChangeControlVisibility(RL1_NOT, False)
        ChangeControlVisibility(RL2_NOT, False)
        ChangeControlVisibility(V5_OK, False)
        ChangeControlVisibility(V5_NOT, False)
        ChangeControlVisibility(IP1_OK, False)
        ChangeControlVisibility(IP2_0K, False)
        ChangeControlVisibility(IP3_OK, False)
        ChangeControlVisibility(IP4_OK, False)
        ChangeControlVisibility(IP1_NOT, False)
        ChangeControlVisibility(IP2_NOT, False)
        ChangeControlVisibility(IP3_NOT, False)
        ChangeControlVisibility(IP4_NOT, False)
        ChangeControlVisibility(CAN1_OK, False)
        ChangeControlVisibility(CAN2_OK, False)
        ChangeControlVisibility(CAN1_NOT, False)
        ChangeControlVisibility(CAN2_NOT, False)
        ChangeControlVisibility(ButtonErrorView, False)

        ChangeControlVisibility(ErrorTestPWR, False)
        ChangeControlVisibility(ErrorTestRL, False)
        ChangeControlVisibility(ErrorTestIP, False)
        ChangeControlVisibility(ErrorTest5V, False)
        ChangeControlVisibility(ErrorTestCAN, False)


        ChangeControlText(LabelUidBadge, "")
        ChangeControlText(LabelSpaceTensione, "")
        ChangeControlText(LabelGradiInclinazione, "")
        ChangeControlText(LabelMacAddress, "")
        ChangeControlText(LabelSpacePOrtale, "")

        ChangeControlBackgroundColor(PictureBoxSD1, Color.Gray)
        ChangeControlBackgroundColor(PictureBoxSD2, Color.Gray)
        ChangeControlBackgroundColor(PictureBox1Battery, Color.Gray)
        ChangeControlBackgroundColor(PictureBox2Battery, Color.Gray)
        ChangeControlBackgroundColor(PictureBoxSim1, Color.Gray)
        ChangeControlBackgroundColor(PictureBoxSim2, Color.Gray)
        ChangeControlBackgroundColor(PictureBox1Accelerometro, Color.Gray)
        ChangeControlBackgroundColor(PictureBoxAzzeramento, Color.Gray)
        ChangeControlBackgroundColor(PictureBoxDevice, Color.Gray)
        ChangeControlBackgroundColor(PictureBoxComunicazione, Color.Gray)
        ChangeControlBackgroundColor(PictureBox1formattazione, Color.Gray)
        ChangeControlBackgroundColor(PictureBox1formattazione, Color.Gray)
        ChangeControlBackgroundColor(PictureBox2L03Peso, Color.Gray)
        ChangeControlBackgroundColor(PictureBox1EsportaMemoria, Color.Gray)
        ChangeControlBackgroundColor(PictureBox1ImpotaMemoria, Color.Gray)
        ChangeControlBackgroundColor(PictureBox1Sync, Color.Gray)
        ChangeControlText(testBatteryStatusCode, "")
        ChangeControlText(testMemsyncExportPercentage, "(0)")
        ChangeControlText(testBadgeMessage, "")
        ChangeControlText(testSDMessage, "")
        ChangeControlText(testBatteryMessage, "")
        ChangeControlText(testSIMMessage, "")
        ChangeControlText(testAccelerometerMessage, "")
        ChangeControlText(testWifiMessage, "")
        ChangeControlText(testComunicazioneMessage, "")
        ChangeControlText(testMemsyncMessage, "")
        ChangeControlText(testUtenzaMessage, "")
        ChangeControlText(testAlimentazioneMessage, "")
        ChangeControlText(Test5VMessage, "")
        ChangeControlText(TestIngressiMessage, "")
        ChangeControlText(TestReleMessage, "")
        ChangeControlText(TestCANMessage, "")
        ChangeControlText(TextBoxSerialeETSDN, "")
        ChangeControlText(LabelCodRS232, "")
        ChangeControlText(LabelIp, "")
    End Sub

    Sub MyBackgroundThread()

        Console.WriteLine("MyBackgroundThread started")

        Dim timInfoDevices As New Stopwatch
        Dim FailTest = False
        Dim done = False

        While statoCollaudoEtsone.RequestToStopTest = False
            If Not statoCollaudoEtsone.fsmTest = 1 Then
                CheckSerialPort()
            End If
            If statoCollaudoEtsone.fsmTest > 2 Or statoCollaudoEtsone.fsmTest = -1 Then
                varSerial.ParsingSerial(RDW_CommandCollaudo("R01"))
                ChangeControlText(TensioneEsterna, varSerial.tensEsterna / 10)
                Dim sn As String = refreshSN()
                statoCollaudoEtsone.deviceSerial = sn
                Dim coccode() As String = Split(RDW_CommandCollaudo("R30"), "|")
                Dim data = FormattaDataOra((coccode(0) And 255), ((coccode(0) \ 256) And 255), ((coccode(0) \ (65536)) And 65535),
                                            ((coccode(1) \ 65536) And 255), ((coccode(1) \ 256) And 255), (coccode(1) And 255), True)
                ChangeControlText(LabelDATA, data.Date)
                ChangeControlText(LabelORA, data.ToLongTimeString)
                ChangeControlText(LabelIp, varSerial.serialIP)


            End If

            ScanParseMsg()
            canEtsoneVar.SendCmdToEtsone(varTxPlc.MsgComposer(), 20)

            If statoCollaudoEtsone.fsmTest <> -1 Then
                ChangeControlBarValue(ProgressBarTest, statoCollaudoEtsone.fsmTest)
            End If

            Select Case statoCollaudoEtsone.fsmTest
                Case -1
                    statoCollaudoEtsone.timvalidation.Restart()
                    ResetP90.Enabled = True
                    LeggiCodRS232.Enabled = True
                    statoCollaudoEtsone.ResetTestStatus()
                Case 0
                    Try
                        If Not File.Exists(Application.StartupPath & "\\log\\EtsOne\\" & refreshSN()) Then
                            My.Computer.FileSystem.OpenTextFileWriter(Application.StartupPath & "\\log\\EtsOne\\" & refreshSN(), True)
                            reportInfo.SetInfoTest(serial:=refreshSN, day:=Date.Today.ToLongDateString, title:="<<<<<<ETSONE TEST>>>>>>",
                                                   portal:=Label28Portale.Text, name:=statoCollaudoEtsone.OperatorName)
                        Else
                            reportInfo.SetInfoTest(serial:=refreshSN, day:=Date.Today.ToLongDateString, title:="● New attempt ●",
                                                   portal:=Label28Portale.Text, name:=statoCollaudoEtsone.OperatorName)
                        End If

                        If CheckSerialPort() Then
                            abortTests = False
                            ResetP90.Enabled = False
                            ButtonStop.Visible = True
                            ButtonStartTest.Visible = False
                            statoCollaudoEtsone.CounterTest += 1
                            LeggiCodRS232.Enabled = False
                            statoCollaudoEtsone.fsmTest = 1
                            varTxPlc.SetStatePWR(1)
                            ResetAllGraphichs()
                            reportStart.SetStartTest(clickstart:=True)
                        End If
                    Catch ex As Exception
                    End Try
                Case 1
                    If CheckBoxAlimentazione.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testAlimentazioneStatusSuccess And (statoCollaudoEtsone.timvalidation.ElapsedMilliseconds <= 5000) Then
                            ChangeControlVisibility(LoadingPWR, True)
                            avviaTestAlimentazione()
                            If statoCollaudoEtsone.testAlimentazioneCompleted Then
                                statoCollaudoEtsone.testAlimentazioneStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingPWR, False)
                            If statoCollaudoEtsone.testAlimentazioneStatusSuccess Then
                                ChangeControlVisibility(TestAlimentazioneStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                                Wait(500)
                            Else
                                ChangeControlVisibility(ErrorTestPWR, True)
                                FailTest = True
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                                Wait(500)
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                        statoCollaudoEtsone.timvalidation.Restart()
                    End If
                    reportPwr.SetResultTest("●TEST POWER", CheckBoxAlimentazione.Checked, statoCollaudoEtsone.testAlimentazioneStatusSuccess)

                Case 2
                    If CheckBox5V.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.test5VStatusSuccess And (statoCollaudoEtsone.timvalidation.ElapsedMilliseconds <= 5000) Then
                            ChangeControlVisibility(Loading5V, True)
                            avviaTest5V()
                            If statoCollaudoEtsone.test5VCompleted Then
                                statoCollaudoEtsone.test5VStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(Loading5V, False)
                            If statoCollaudoEtsone.test5VStatusSuccess Then
                                ChangeControlVisibility(test5Vstatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                            Else
                                ChangeControlVisibility(ErrorTest5V, True)
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                                FailTest = True
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                        statoCollaudoEtsone.timvalidation.Restart()
                    End If
                    report5V.SetResultTest("●TEST 5V", CheckBox5V.Checked, statoCollaudoEtsone.test5VStatusSuccess)

                Case 3
                    If CheckBoxRele.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testReleStatusSuccess And (statoCollaudoEtsone.timvalidation.ElapsedMilliseconds <= 12000) Then
                            ChangeControlVisibility(LoadingRL, True)
                            avviaTestRele()
                            If statoCollaudoEtsone.testReleCompleted Then
                                statoCollaudoEtsone.testReleStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingRL, False)
                            If statoCollaudoEtsone.testReleStatusSuccess Then
                                ChangeControlVisibility(TestReleStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                            Else
                                ChangeControlVisibility(ErrorTestRL, True)
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                                varTxPlc.SetAllRL(0)
                                FailTest = True
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                        statoCollaudoEtsone.timvalidation.Restart()
                    End If
                    reportRl.SetResultTest("●TEST RELE", CheckBoxRele.Checked, statoCollaudoEtsone.testReleStatusSuccess)


                Case 4
                    If CheckBoxIngressi.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testIngressiStatusSuccess And (statoCollaudoEtsone.timvalidation.ElapsedMilliseconds <= 12000) Then
                            ChangeControlVisibility(LoadingIP, True)
                            avviaTestIngressi()
                            If statoCollaudoEtsone.testIngressiCompleted Then
                                statoCollaudoEtsone.testIngressiStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingIP, False)
                            If statoCollaudoEtsone.testIngressiStatusSuccess Then
                                ChangeControlVisibility(testIngressiStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                                varTxPlc.SetAllIP(0)
                            Else
                                ChangeControlVisibility(ErrorTestIP, True)
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                                varTxPlc.SetAllIP(0)
                                FailTest = True
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                        statoCollaudoEtsone.timvalidation.Restart()
                    End If
                    reportIp.SetResultTest("●TEST INGRESSI/ANALOGICI", CheckBoxIngressi.Checked, statoCollaudoEtsone.testIngressiStatusSuccess)

                Case 5
                    If CheckBoxCAN.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testCANStatusSuccess And (statoCollaudoEtsone.timvalidation.ElapsedMilliseconds <= 8000) Then
                            ChangeControlVisibility(LoadingCAN, True)
                            avviaTestCAN()
                            If statoCollaudoEtsone.testCANCompleted Then
                                statoCollaudoEtsone.testCANStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingCAN, False)
                            If statoCollaudoEtsone.testCANStatusSuccess Then
                                ChangeControlVisibility(TestCANStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                            Else
                                If CAN1_OK.Visible = False Then
                                    ChangeControlVisibility(CAN1_NOT, True)
                                    reportCan.SetResultCan1(pass:=False, comment:=" Value of CAN1 must be 1", value:=varSerial.serialCan1)
                                End If
                                If CAN2_OK.Visible = False Then
                                    ChangeControlVisibility(CAN2_NOT, True)
                                    reportCan.SetResultCan2(pass:=False, comment:=" Value of CAN2 must be 1", value:=varSerial.serialCan2)
                                End If
                                ChangeControlVisibility(ErrorTestCAN, True)
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                                varTxPlc.SetallCAN(0)
                                FailTest = True
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                        statoCollaudoEtsone.timvalidation.Restart()
                    End If
                    reportCan.SetResultTest("●TEST CAN", CheckBoxCAN.Checked, statoCollaudoEtsone.testCANStatusSuccess)

                        '                                ------------------------------------------SOPRA TEST PER PLC-------------------------------------------------
                Case 6
                    If CheckBoxAccelerometro.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testAccelerometroStatusSuccess And (statoCollaudoEtsone.timvalidation.ElapsedMilliseconds <= 10000) Then
                            ChangeControlVisibility(LoadingAcc, True)
                            avviaTestAccelerometro()
                            If statoCollaudoEtsone.testAccelerometroCompleted Then
                                statoCollaudoEtsone.testAccelerometroStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingAcc, False)
                            If statoCollaudoEtsone.testAccelerometroStatusSuccess Then
                                ChangeControlVisibility(testAccelerometerStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                            Else
                                statoCollaudoEtsone.fsmTest += 1
                                statoCollaudoEtsone.timvalidation.Restart()
                                FailTest = True
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 7
                    If CheckBoxSD.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testSDStatusSuccess Then
                            ChangeControlVisibility(LoadingSD, True)
                            avviaTestSD()
                            If statoCollaudoEtsone.testSDCompleted Then
                                statoCollaudoEtsone.testSDStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingSD, False)
                            If statoCollaudoEtsone.testSDStatusSuccess Then
                                ChangeControlVisibility(testSDStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                            Else
                                statoCollaudoEtsone.fsmTest += 1
                                FailTest = True
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 8
                    If CheckBoxBatteria.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testBatteriaStatusSuccess Then
                            ChangeControlVisibility(LoadingBattery, True)
                            avviaTestBattery()
                            If statoCollaudoEtsone.testBatteriaCompleted Then
                                statoCollaudoEtsone.testBatteriaStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingBattery, False)
                            If statoCollaudoEtsone.testBatteriaStatusSuccess Then
                                ChangeControlVisibility(testBatteryStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                            Else
                                statoCollaudoEtsone.fsmTest += 1
                                FailTest = True
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 9
                    If CheckBoxBadge.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testBadgeStatusSuccess Then
                            ChangeControlVisibility(LoadingBadge, True)
                            avviaTestBadge()
                            If statoCollaudoEtsone.testBadgeCompleted Then
                                statoCollaudoEtsone.testBadgeStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingBadge, False)
                            If statoCollaudoEtsone.testBadgeStatusSuccess Then
                                ChangeControlVisibility(LoadingBadge, False)
                                ChangeControlVisibility(testBadgeStatus, True)
                            Else
                                FailTest = True
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 10
                    If CheckBoxSim.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testSimStatusSuccess Then
                            ChangeControlVisibility(LoadingSIM, True)
                            avviaTestSim()
                            If statoCollaudoEtsone.testSimCompleted Then
                                statoCollaudoEtsone.testSimStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingSIM, False)
                            If statoCollaudoEtsone.testSimStatusSuccess Then
                                ChangeControlVisibility(testSIMStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                            Else
                                FailTest = True
                                statoCollaudoEtsone.fsmTest += 1
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 11
                    If CheckBoxWifFi.Checked And abortTests = False Then
                        If Not statoCollaudoEtsone.testWifiStatusSuccess Then
                            ChangeControlVisibility(LoadingWIFI, True)
                            avviaTestWifi()
                            If statoCollaudoEtsone.testWifiCompleted Then
                                statoCollaudoEtsone.testWifiStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingWIFI, False)
                            If statoCollaudoEtsone.testWifiStatusSuccess Then
                                ChangeControlVisibility(testWifiStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                            Else
                                FailTest = True
                                statoCollaudoEtsone.fsmTest += 1
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 12
                    If CheckBoxPortale.Checked And abortTests = False Then
                        If Not statoCollaudoEtsone.testComunicazioneStatusSuccess Then
                            ChangeControlVisibility(LoadingPortale, True)
                            AvviaTestComunicazione()
                            If statoCollaudoEtsone.testComunicazioneCompleted Then
                                statoCollaudoEtsone.testComunicazioneStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingPortale, False)
                            If statoCollaudoEtsone.testComunicazioneStatusSuccess Then
                                ChangeControlVisibility(testComunicazioneStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                            Else
                                FailTest = True
                                statoCollaudoEtsone.fsmTest += 1
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 13
                    If CheckBoxMemoria.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testSyncStatusSuccess Then
                            ChangeControlVisibility(LoadingSync, True)
                            AvviaTestSync()
                            If statoCollaudoEtsone.testSyncCompleted Then
                                statoCollaudoEtsone.testSyncStatusSuccess = True
                            End If
                        Else
                            ChangeControlVisibility(LoadingSync, False)
                            If statoCollaudoEtsone.testSyncStatusSuccess Then
                                ChangeControlVisibility(testMemsyncStatus, True)
                                statoCollaudoEtsone.fsmTest += 1
                            Else
                                FailTest = True
                                statoCollaudoEtsone.fsmTest += 1
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 14
                    If CheckBoxUtenza.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.testUtenzaStatusSuccess Then
                            ripristina_Sett(setupFileUtenza)
                            AvviaTestUtenza()
                            If statoCollaudoEtsone.testUtenzaCompleted Then
                                statoCollaudoEtsone.testUtenzaStatusSuccess = True
                            End If
                        Else
                            If statoCollaudoEtsone.testUtenzaStatusSuccess Then
                                ChangeControlBackgroundColor(testUtenzaStatus, Color.Green)
                                statoCollaudoEtsone.fsmTest += 1
                            Else
                                ChangeControlBackgroundColor(testUtenzaStatus, Color.Red)
                                statoCollaudoEtsone.fsmTest += 1
                                FailTest = True
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 15
                    If CheckBoxETSDN.Checked And Not abortTests Then
                        If Not statoCollaudoEtsone.associazioneETSDNSuccess Then
                            Dim salvaAssocETSDN = "..."
                            salvaAssocETSDN = SalvaAssocSeriali(TextBoxSerialeETSDN.Text, labelSerialNumber.Text, (CheckBoxOverrideETSDN.Checked).ToString())
                            ChangeControlBackgroundColor(testETS_ETSDNStatus, Color.Yellow)
                            ChangeControlText(LabelRespFromAssocETSDN, salvaAssocETSDN)
                            If statoCollaudoEtsone.associazioneETSDNCompleted Then
                                statoCollaudoEtsone.associazioneETSDNSuccess = True
                            End If
                        Else
                            If statoCollaudoEtsone.associazioneETSDNCompleted And statoCollaudoEtsone.associazioneETSDNSuccess Then
                                ChangeControlBackgroundColor(testETS_ETSDNStatus, Color.Green)
                            Else
                                ChangeControlBackgroundColor(testETS_ETSDNStatus, Color.Red)
                                FailTest = True
                            End If
                        End If
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 16
                    If CheckRS232.Checked And Not abortTests Then
                        If LabelCodRS232.Text = "" Then
                            ChangeControlVisibility(ErrorRS232, True)
                        End If
                        statoCollaudoEtsone.fsmTest += 1
                    Else
                        statoCollaudoEtsone.fsmTest += 1
                    End If

                Case 17

                    ChangeControlVisibility(ButtonStartTest, True)
                    varTxPlc.SetStatePWR(0)
                    statoCollaudoEtsone.ResetTestStatus()
                    ResetLoadingStop()
                    statoCollaudoEtsone.fsmTest = -1
                    ButtonStartTest.Visible = True
                    ButtonStop.Visible = False
                    ErrorTestDevice()

                    Try
                        log.OpenTextFile(reportInfo)
                        log.WriteOnFile(reportInfo)
                        log.WriteOnFile(reportStart)
                        log.WriteOnFile(reportStop)
                        log.WriteOnFile(reportPwr)
                        log.WriteOnFile(report5V)
                        log.WriteOnFile(reportRl)
                        log.WriteOnFile(reportIp, reportAna)
                        log.WriteOnFile(reportCan)
                        log.WriteOnFile(reportEnd)
                        log.CloseTextFile()
                        log.ExportFileData(reportInfo)
                    Catch ex As Exception
                        Console.WriteLine(ex)
                    End Try
            End Select

        End While
        Console.WriteLine("End while")

    End Sub

    Private Function SalvaAssocSeriali(Optional ByVal serialeETSDN = "", Optional ByVal serialeETS = "", Optional ByVal override = "")
        serialeETSDN = If(serialeETSDN = "", TextBoxSerialeETSDN.Text, serialeETSDN)
        serialeETS = If(serialeETS = "", labelSerialNumber.Text, serialeETS)
        override = If(override = "", (CheckBoxOverrideETSDN.Checked).ToString(), override)

        If serialeETSDN = "" Then
            Dim commRes() As String = Split(RDW_CommandCollaudo("R0R 4$R00"), "|")
            If commRes.Length = 3 Then
                ChangeControlText(TextBoxSerialeETSDN, commRes(2))
            End If
        End If

        serialeETSDN = TextBoxSerialeETSDN.Text

        If TextBoxSerialeETSDN.Text.Length > 0 Then
            Try
                If (serialeETS.Trim().Equals("")) Then
                    serialeETS = refreshSN()
                End If

                If (serialeETS IsNot Nothing) And (serialeETSDN <> "") Then
                    Dim index = 0
                    While True
                        index += 1
                        Dim setETSDNSeriale = RDW_CommandCollaudo("W08", 6, serialeETSDN)
                        If serialeETSDN = setETSDNSeriale Then
                            Dim res = predictionService.salvaAssocSeriali(serialeETS, serialeETSDN, override)
                            statoCollaudoEtsone.associazioneETSDNCompleted = True
                            statoCollaudoEtsone.associazioneETSDNSuccess = True
                            Return res("message")
                        Else
                            If index > 3 Then
                                statoCollaudoEtsone.associazioneETSDNCompleted = True
                                statoCollaudoEtsone.associazioneETSDNSuccess = False
                                Return "Errore nell'associazione del seriale ETSDN a ETS"
                            End If

                            Wait(1000)
                        End If
                    End While
                Else
                    statoCollaudoEtsone.associazioneETSDNCompleted = True
                    statoCollaudoEtsone.associazioneETSDNSuccess = False
                    Return "Seriale ETS o ETSDN non rilevato!"
                End If
            Catch ex As Exception

            End Try
        End If
    End Function

    Public Function RDW_CommandCollaudo(ByVal Comando As String, Optional ByVal Offset As String = "", Optional ByVal Value As String = "",
                               Optional ByVal ErrorEnable As Boolean = False, Optional ByVal ReadFloat As Boolean = False, Optional ByVal FIND As String = "",
                               Optional ByVal customTimeout As Integer = 10000, Optional ByRef MiaPorta As SerialPort = Nothing
                               ) As String
        Try
            Dim Tentativi = 0

            Dim Stringa As String
            Dim Porta As SerialPort
            Dim MyRnd As New Random
            Dim CheckSinc As Boolean = False
            Dim CheckRisp As String = ""


            If MiaPorta Is Nothing Then
                Porta = MySerialPort
            Else
                Porta = MiaPorta
            End If

            If Len(Offset) > 0 Then Offset = " " & Offset
            If Len(Value) > 0 Then Value = " " & Value
            If ReadFloat Then Value = Replace(Value, ",", ".")
            Dim Risposta As String = ""
            If CheckSinc Then
                CheckRisp = "~C:" & MyRnd.Next(100)
            End If

            Stringa = "$" & Comando & Offset & Value & CheckRisp & IIf(CheckRisp.Length > 0, " ", "") & vbCr


            If NodoCAN.Length > 0 Then Stringa = "$R0R " & NodoCAN & Stringa

            If SaveToFIle Then
                Try
                    If Stringa.Contains("L02") Or (Comando.StartsWith("R") And Not Comando.StartsWith("R0R")) Then
                        Return ""
                    End If

                    Dim AllExpFile As String = ""
                    Using sw As StreamReader = New StreamReader(fileName)

                        AllExpFile = sw.ReadToEnd

                    End Using
                    Using sw As StreamWriter = New StreamWriter(fileName)
                        If (CheckRisp.Length <> 0) Then
                            Stringa = Stringa.Replace(CheckRisp, "")
                        End If
                        sw.Write(AllExpFile & Stringa & vbLf)
                    End Using
                    '            If Not Value = "" Then If Value.Length > 1 And Value.First = " " Then Risposta = Value.Remove(0, 1) Else Risposta = Value
                    If ReadFloat Then Value = Replace(Value, ".", ",")
                    Return Trim(Value)

                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
                Throw New Exception("Scrittura su file fallita")
            End If

            If (Porta Is Nothing) Then
                Porta = Main.SerialPort
            End If

            ttx = 5
            If Not Porta.IsOpen And Not statoCollaudoEtsone.fsmTest = 1 Then

                Porta.Open()
                Porta.DiscardOutBuffer()
                Porta.DiscardInBuffer()
            End If
            Porta.Write(Stringa)
            If customTimeout <= 0 Then
                Porta.ReadTimeout = Ports.SerialPort.InfiniteTimeout
            Else
                Porta.ReadTimeout = customTimeout
            End If

            '' Porta.ReadTimeout = 10000

            Dim result As String = ""
            If FIND = "" Then
                Try
                    result = Porta.ReadLine()
                Catch ex As Exception
                End Try
            Else
                Porta.ReadTimeout = 10000
                While 1
                    Dim Temp1 = Porta.ReadLine
                    result = result & Temp1
                    If Temp1.Contains(FIND) Then
                        Exit While
                    End If

                End While

            End If

            trx = 5
            Porta.DiscardOutBuffer()
            Porta.DiscardInBuffer()

            If FIND = "" Then
                result = Trim(Replace(result, "" & vbCr & "", ""))
                If ReadFloat Then result = Replace(result, ".", ",")

            End If
            Return result
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try


    End Function

    '------------------------------------------------------------------------   FUNZIONI NEL LOAD   -----------------------------------------------------------------------

    Private Sub autoHostandLog()
        Dim hostTest As String
        Dim addr = 1000

        If Main.DropdownDevicesProfiles.Text.Contains("MDT") Then
            addr = 0
            'Else
            '    PanelAlimentazione.Hide()
            '    PanelRelè.Hide()
            '    Panel5V.Hide()
            '    PanelIngressi.Hide()
            '    PanelCAN.Hide()
            '    CheckBoxAlimentazione.Checked = False
            '    CheckBoxRele.Checked = False
            '    CheckBox5V.Checked = False
            '    CheckBoxIngressi.Checked = False
            '    CheckBoxCAN.Checked = False
        End If
        Dim HostMod = RDW_CommandCollaudo("R0B", addr) ' ETS: 1000, MDT: 0

        System.Console.WriteLine(HostMod)

        If HostMod.Contains("http://") = False And HostMod.Contains("www.") = False Then
            hostTest = "http://" & HostMod
            'FIXME modifica momentanea da rimetterere "https"
        End If

        If HostMod.Contains("www.") = True Then
            hostTest = HostMod.Replace("www.", "https://")
        End If

        If HostMod.EndsWith("/") = False Then
            hostTest = hostTest & "/"
        End If

        Dim m_xmld As New XmlDocument
        m_xmld.Load(Application.StartupPath & "\grsats.xml")

        Dim pass As String = ""
        Dim user As String = ""
        For Each nodo As XmlNode In m_xmld.SelectNodes("dati/dato")
            Dim hostXML = nodo.Attributes.GetNamedItem("D1").Value.Replace("https://", "")
            Dim friendlyName = nodo.Attributes.GetNamedItem("D4").Value
            hostXML = hostXML.Replace("http://", "")
            hostXML = hostXML.Replace("www.", "")

            Dim hostEts = hostTest.Replace("https://", "")
            hostEts = hostEts.Replace("http://", "")
            hostEts = hostEts.Replace("www.", "")

            ' Quick ack per Bonatti per cui programmeremo dalla loro rete locale
            If hostEts.Contains("bonatti") Then
                If friendlyName.Contains("bonatti") Then
                    Dim NomePortale = nodo.Attributes.GetNamedItem("D4").Value
                    user = nodo.Attributes.GetNamedItem("D2").Value
                    pass = nodo.Attributes.GetNamedItem("D3").Value
                    Label28Portale.Text = NomePortale
                    Host = "http://" & hostXML
                End If
            ElseIf hostEts = hostXML Then
                Dim NomePortale = nodo.Attributes.GetNamedItem("D4").Value
                user = nodo.Attributes.GetNamedItem("D2").Value
                pass = nodo.Attributes.GetNamedItem("D3").Value
                Label28Portale.Text = NomePortale
                Host = hostTest
            End If
        Next

        If hostTest.Contains("bonatti") Then
            kiwisat = New GRSatBonatti(0, hostTest, user, pass, Nothing, Nothing, Nothing, Nothing, Nothing)
        Else
            kiwisat = New GRSat(0, hostTest, user, pass, Nothing, Nothing, Nothing, Nothing, Nothing)
        End If

        Try
            If kiwisat.login() = Cloud.LOGIN_RESULT.SUCCED Then
                'MsgBox("Il login al portale è avvenuto")
            End If
        Catch ex As Exception
            MsgBox("errore login " & ex.Message)

        End Try
    End Sub

    Public Sub CaricaApn()

        Dim lol = Directory.GetDirectories(Application.StartupPath & "\SIM")
        ComboBoxApn.Items.Clear()
        For Each lil In lol
            ComboBoxApn.Items.Add(lil.Replace(Application.StartupPath & "\SIM\", ""))
        Next

    End Sub
    Public Sub CaricaUtenza()

        Dim ute = Directory.GetDirectories(Application.StartupPath & "\SIM")
        ComboBoxApn.Items.Clear()
        For Each nza In ute
            ComboBoxApn.Items.Add(nza.Replace(Application.StartupPath & "\SIM\", ""))
        Next

    End Sub

    Private Function refreshSN() As String
        Try
            Dim seria = RDW_CommandCollaudo("R00")
            Dim serialN = seria.Split("|")
            Dim serialNum = serialN(2)

            'labelSerialNumber.Text = serialNum   'tramite la proprietà text 
            ChangeControlText(labelSerialNumber, serialNum)
            Return serialNum
        Catch ex As Exception
            'labelSerialNumber.Text = "ERROR"
            ChangeControlText(labelSerialNumber, "ERROR")
            Return Nothing
        End Try

    End Function

    Private Sub soundFinal()

        soundw.Start()
        If PanelBadge.BackColor = Color.Green And PanelSD.BackColor = Color.Green And PanelBatteria.BackColor = Color.Green And PanelSim.BackColor = Color.Green And PanelAccelerometro.BackColor = Color.Green And PanelWifi.BackColor = Color.Green And PanelPortale.BackColor = Color.Green And PanelSync.BackColor = Color.Green Then
            My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Beep)
            soundw.Restart()
        End If
    End Sub

    '----------------------------------------------------------------------  TEST  ----------------------------------------------------------------------------------------

    Public Sub avviaTestAlimentazione()

        Dim port = System.IO.Ports.SerialPort.GetPortNames.ToList()
        port.Sort()

        If Not port.Contains(LabelCom.Text) Then

            ChangeControlVisibility(PanelEventUSB, False)
            ChangeControlVisibility(PictureUSBscollegato, False)
            varTxPlc.SetStatePWR(1)
            ChangeControlText(Label23, varRxEtsone.vTensione.ToString())

            If varRxEtsone.vTensione < 50 And varRxEtsone.vTensione >= 22 Then
                statoCollaudoEtsone.counterPWR += 1
            Else
                ChangeControlVisibility(PWR_NOT, True)
                ChangeControlVisibility(PWR_OK, False)
                reportPwr.SetResultPwr(pass:=False, value:=varRxEtsone.vTensione, comment:=" Value of power must not be > 50 and < 35")
            End If

            If statoCollaudoEtsone.counterPWR = 18 Then
                ChangeControlVisibility(PWR_OK, True)
                ChangeControlVisibility(PWR_NOT, False)
                reportPwr.SetResultPwr(pass:=True)
                statoCollaudoEtsone.testAlimentazioneCompleted = True
                ChangeControlText(Label23, varRxEtsone.vTensione.ToString())
            End If
        Else
            PanelEventUSB.Location = New Point(289, 208)
            PictureUSBscollegato.Size = New Size(348, 282)
            ChangeControlVisibility(PanelEventUSB, True)
            ChangeControlVisibility(PictureUSBscollegato, True)
            ChangeControlText(LabelErrorUSB, "Scollegare USB")
            statoCollaudoEtsone.timvalidation.Restart()
        End If
    End Sub

    Private Sub avviaTestRele()

        If Not statoCollaudoEtsone.datiOnString.Contains("-Test_Relè") Then
            statoCollaudoEtsone.datiOnString = "-Test_Relè" & Environment.NewLine
        End If
        ChangeControlText(vCurrent1, varRxEtsone.vCurrentRL1)
        ChangeControlText(vCurrent2, varRxEtsone.vCurrentRL2)
        Select Case statoCollaudoEtsone.releTest
            Case 0
                RDW_CommandCollaudo("W08 176 3")
                RDW_CommandCollaudo("L02")
                ChangeControlText(Label56, "Opened")
                ChangeControlText(Label57, "Opened")
                varTxPlc.SetAllRL(1)
                statoCollaudoEtsone.releTest = 1
            Case 1

                If varSerial.serialRL1 = 0 And varSerial.serialRL1 = 0 Then
                    If varRxEtsone.vCurrentRL1 < 5 And varRxEtsone.vCurrentRL2 < 10 Then
                        statoCollaudoEtsone.timerReleTest.Restart()
                        statoCollaudoEtsone.releTest = 2
                    End If
                Else
                    reportRl.SetResultRL1(pass:=False, erorrSerial:=True)
                    reportRl.SetResultRL2(pass:=False, erorrSerial:=True)
                End If

            Case 2
                RDW_CommandCollaudo("W08 176 2")
                RDW_CommandCollaudo("L02")
                ChangeControlText(Label56, "Closed")
                Wait(200)

                If Not statoCollaudoEtsone.timerReleTest.ElapsedMilliseconds > 3000 Then
                    If (varRxEtsone.vCurrentRL1 > 200 And varRxEtsone.vCurrentRL1 < 240) Then
                        statoCollaudoEtsone.releTest = 3
                        ChangeControlVisibility(RL1_OK, True)
                        ChangeControlVisibility(RL1_NOT, False)
                        reportRl.SetResultRL1(pass:=True)

                        If Not varRxEtsone.vCurrentRL2 < 8 Then
                            ChangeControlText(TestReleMessage, " Corto RL2")
                        End If
                        statoCollaudoEtsone.timerReleTest.Restart()
                    End If
                Else
                    statoCollaudoEtsone.releTest = 3
                    statoCollaudoEtsone.timerReleTest.Restart()
                    ChangeControlVisibility(RL1_NOT, True)
                    ChangeControlVisibility(RL1_OK, False)
                    reportRl.SetResultRL1(pass:=False, value:=varRxEtsone.vCurrentRL1, value1:=varRxEtsone.vCurrentRL2,
                                              comment:=" Value of RL1 must not be > 240 and < 200 and value of R2 must be 0")
                End If

            Case 3
                RDW_CommandCollaudo("W08 176 1")
                RDW_CommandCollaudo("L02")
                ChangeControlText(Label57, "Closed")
                Wait(200)

                If Not statoCollaudoEtsone.timerReleTest.ElapsedMilliseconds > 3000 Then
                    If (varRxEtsone.vCurrentRL2 > 200 And varRxEtsone.vCurrentRL2 < 240) Then
                        statoCollaudoEtsone.releTest = 4
                        ChangeControlVisibility(RL2_OK, True)
                        ChangeControlVisibility(RL2_NOT, False)
                        reportRl.SetResultRL2(pass:=True)

                        If Not varRxEtsone.vCurrentRL1 < 5 Then
                            ChangeControlText(TestReleMessage, " Corto RL1")
                        End If
                    End If
                Else
                    statoCollaudoEtsone.releTest = 4
                    ChangeControlVisibility(RL2_NOT, True)
                    ChangeControlVisibility(RL2_OK, False)
                    reportRl.SetResultRL2(pass:=False, value:=varRxEtsone.vCurrentRL2, value1:=varRxEtsone.vCurrentRL1,
                                              comment:=" Value of RL2 must not be > 240 and < 200 and value of RL1 must be 0")
                End If

            Case 4

                If (RL1_OK.Visible And RL2_OK.Visible) And TestReleMessage.Text = "" Then
                    statoCollaudoEtsone.testReleCompleted = True
                    statoCollaudoEtsone.releTest = 0
                    statoCollaudoEtsone.timerReleTest.Reset()
                    varTxPlc.SetAllRL(0)
                Else
                    statoCollaudoEtsone.releTest = 0
                    varTxPlc.SetAllRL(0)
                    ChangeControlText(TestReleMessage, "")
                End If
        End Select

        If abortTests Then
            varTxPlc.SetAllRL(0)
            statoCollaudoEtsone.releTest = 0
        End If
    End Sub

    Private Sub avviaTest5V()

        ChangeControlText(Valore5V, varRxEtsone.r5V.ToString / 1000)
        If varRxEtsone.r5V < 5050 And varRxEtsone.r5V > 4900 Then
            ChangeControlText(Valore5V, varRxEtsone.r5V.ToString / 1000)
            ChangeControlVisibility(V5_OK, True)
            statoCollaudoEtsone.test5VCompleted = True
            report5V.SetResult5V(pass:=True)
        Else
            report5V.SetResult5V(pass:=False, value:=varRxEtsone.r5V, comment:=" Value of 5V must not be > 5050 and < 4900")
        End If
    End Sub

    Private Sub avviaTestIngressi()


        If Not statoCollaudoEtsone.datiOnString.Contains("-Test_Ingressi-Analog") Then
            statoCollaudoEtsone.datiOnString = "-Test_Ingressi-Analog" & Environment.NewLine
        End If

        statoCollaudoEtsone.timerInputTest.Start()
        varTxPlc.SetStateIP4(1)
        varSerial.serialIP4 = varSerial.serialIP4 / 10

        If statoCollaudoEtsone.statoInputest = False Then
            Select Case statoCollaudoEtsone.inputTest

                Case 0
                    statoCollaudoEtsone.timerInputTest.Restart()
                    statoCollaudoEtsone.inputTest += 1
                    varTxPlc.SetStateIP1(1)
                Case 1
                    If statoCollaudoEtsone.timerInputTest.ElapsedMilliseconds < 2000 And Not IP1_OK.Visible = True Then
                        If varSerial.serialIP1 = 1 And (varSerial.serialIP2 = 0 And varSerial.serialIP3 = 0) Then
                            ChangeControlVisibility(IP1_OK, True)
                            ChangeControlVisibility(IP1_NOT, False)
                            statoCollaudoEtsone.inputTest += 1
                            statoCollaudoEtsone.timerInputTest.Restart()
                            varTxPlc.SetStateIP1(0)
                            varTxPlc.SetStateIP2(1)
                            reportIp.SetResultIP1(pass:=True)
                        End If
                    Else
                        varTxPlc.SetStateIP1(0)
                        varTxPlc.SetStateIP2(1)
                        statoCollaudoEtsone.inputTest += 1
                        statoCollaudoEtsone.timerInputTest.Restart()
                        If Not IP1_OK.Visible = True Then
                            ChangeControlVisibility(IP1_NOT, True)
                            reportIp.SetResultIP1(pass:=False, valIp1:=varSerial.serialIP1, valIp2:=varSerial.serialIP2, valIp3:=varSerial.serialIP3,
                                                  comment:=" value of IP1 must be 1 and IP2 & IP3 must be 0")
                        End If
                    End If

                Case 2
                    If statoCollaudoEtsone.timerInputTest.ElapsedMilliseconds < 2000 And Not IP2_0K.Visible = True Then
                        If varSerial.serialIP2 = 1 And (varSerial.serialIP1 = 0 And varSerial.serialIP3 = 0) Then
                            ChangeControlVisibility(IP2_0K, True)
                            ChangeControlVisibility(IP2_NOT, False)
                            statoCollaudoEtsone.inputTest += 1
                            statoCollaudoEtsone.timerInputTest.Restart()
                            varTxPlc.SetStateIP2(0)
                            varTxPlc.SetStateIP3(1)
                            reportIp.SetResultIP2(pass:=True)
                        End If
                    Else
                        varTxPlc.SetStateIP2(0)
                        varTxPlc.SetStateIP3(1)
                        statoCollaudoEtsone.inputTest += 1
                        statoCollaudoEtsone.timerInputTest.Restart()
                        If Not IP2_0K.Visible = True Then
                            ChangeControlVisibility(IP2_NOT, True)
                            reportIp.SetResultIP2(pass:=False, valIp2:=varSerial.serialIP2, valIp1:=varSerial.serialIP1, valIp3:=varSerial.serialIP3,
                                                  comment:=" value of IP2 must be 1 and IP1 & IP3 must be 0")
                        End If
                    End If

                Case 3

                    If statoCollaudoEtsone.timerInputTest.ElapsedMilliseconds < 2000 And Not IP3_OK.Visible = True Then
                        If varSerial.serialIP3 = 1 And (varSerial.serialIP1 = 0 And varSerial.serialIP2 = 0) Then
                            ChangeControlVisibility(IP3_OK, True)
                            ChangeControlVisibility(IP3_NOT, False)
                            statoCollaudoEtsone.inputTest += 1
                            statoCollaudoEtsone.timerInputTest.Restart()
                            reportIp.SetResultIP3(pass:=True)
                        End If
                    Else
                        statoCollaudoEtsone.inputTest += 1
                        statoCollaudoEtsone.timerInputTest.Restart()
                        If Not IP3_OK.Visible = True Then
                            ChangeControlVisibility(IP3_NOT, True)
                            reportIp.SetResultIP3(pass:=False, valIp3:=varSerial.serialIP3, valIp2:=varSerial.serialIP2, valIp1:=varSerial.serialIP1,
                                                  comment:=" value of IP3 must be 1 and IP1 & IP2 must be 0")
                        End If
                    End If

                Case 4
                    If IP1_OK.Visible And IP2_0K.Visible And IP3_OK.Visible Then
                        statoCollaudoEtsone.statoInputest = True
                        statoCollaudoEtsone.inputTest += 1
                        statoCollaudoEtsone.timerInputTest.Reset()
                        statoCollaudoEtsone.timerAnalogTest.Restart()
                        varTxPlc.SetAllIP(0)
                    Else
                        statoCollaudoEtsone.timerAnalogTest.Restart()
                        statoCollaudoEtsone.inputTest = 0
                        varTxPlc.SetAllIP(0)
                    End If
            End Select

        Else

            ChangeControlText(AnalogicIP4, varSerial.serialIP4.ToString / 10)
            Console.WriteLine(statoCollaudoEtsone.counterFailTest.ToString)
            If statoCollaudoEtsone.timerAnalogTest.ElapsedMilliseconds < 7000 Then
                Dim serialdata = varSerial.serialIP4 - varRxEtsone.rANAIP4
                If statoCollaudoEtsone.counterFailTest >= 0 And statoCollaudoEtsone.counterFailTest < 50 Then
                    If Math.Abs(serialdata) > 5 Then
                        statoCollaudoEtsone.counterFailTest += 3
                    Else
                        If statoCollaudoEtsone.counterFailTest > 1 Then
                            statoCollaudoEtsone.counterFailTest -= 2
                            ChangeControlVisibility(IP4_OK, True)
                            ChangeControlVisibility(IP4_NOT, False)
                        End If
                    End If
                Else
                    ChangeControlVisibility(IP4_OK, False)
                    ChangeControlVisibility(IP4_NOT, True)
                    reportAna.SetResultANA1(pass:=False, comment:="Counterfail must be < 30", value:=statoCollaudoEtsone.counterFailTest)
                End If
            Else
                If statoCollaudoEtsone.statoInputest = True And IP4_OK.Visible = True Then
                    statoCollaudoEtsone.testIngressiCompleted = True
                    reportAna.SetResultANA1(pass:=True)
                    varTxPlc.SetStateIP4(0)
                End If
            End If
        End If
    End Sub
    Private Sub avviaTestCAN()

        If Not statoCollaudoEtsone.datiOnString.Contains("-Test_CAN") Then
            statoCollaudoEtsone.datiOnString = "-Test_CAN" & Environment.NewLine
        End If

        varTxPlc.SetallCAN(1)

        If varSerial.serialCan1 = 1 Then
            ChangeControlVisibility(CAN1_OK, True)
            reportCan.SetResultCan1(pass:=True)
        End If

        If varSerial.serialCan2 = 1 Then
            ChangeControlVisibility(CAN2_OK, True)
            reportCan.SetResultCan2(pass:=True)
        End If

        If (CAN1_OK.Visible And CAN2_OK.Visible) = True Then
            statoCollaudoEtsone.testCANCompleted = True
            varTxPlc.SetallCAN(0)
        End If



    End Sub

    Function commitDeviceCraft() As Boolean
        Try
            CounterTest += 1
            LabelMongostatus.Text = "Invio in corso..."
            showWait(LabelMongostatus.Text)

            Dim params = populateCraftParameters()

            Dim client = New MongoDB.Driver.MongoClient("mongodb://root:R8HFKaPfZ6Ar@ec2-18-156-33-51.eu-central-1.compute.amazonaws.com:27017")
            Dim db = client.GetDatabase("super_mongo_db")
            Dim collection = db.GetCollection(Of MongoDB.Bson.BsonDocument)("Devices_tested")
            'Dim ciao = collection.DeleteOne(params.ToBsonDocument())
            collection.InsertOne(params.ToBsonDocument())
            'TODO setMongoId(risp.Replace("_id", ""))
            'LabelMongostatus.Text = params.GetElement("dispositivo").Value.AsBsonDocument().GetElement("serial").Value.ToString() & " - Fatto"
            disposeWait()
            Initialised()
            Return True

        Catch ex As Exception
            LabelMongostatus.Text = "errore"
            disposeWait()
            Return False
        End Try

    End Function

    Function populateCraftParameters() As BsonDocument
        Dim par As New BsonDocument()
        Try
            Dim test_effettuati As New BsonDocument()
            Dim nomeUtente As New BsonDocument()
            Dim dispositivo As New BsonDocument()
            Dim Data = Date.Now()
            Dim NumTest As New BsonDocument()


            nomeUtente.Add("DateTime", Data.ToString)
            nomeUtente.Add("MachineName", Environment.MachineName)
            nomeUtente.Add("UserDomainName", Environment.UserDomainName)


            dispositivo.Add("R00", RDW_CommandCollaudo("R00"))
            dispositivo.Add("R01", RDW_CommandCollaudo("R01"))
            dispositivo.Add("Portale", Label28Portale.Text)
            NumTest.Add("NumTest", CounterTest.ToString)

            If CheckBoxAlimentazione.Checked Then
                test_effettuati.Add("TestPower", statoCollaudoEtsone.testAlimentazioneStatusSuccess.ToString)

            Else
                test_effettuati.Add("TestPower", "0")
            End If


            If CheckBoxRele.Checked Then
                test_effettuati.Add("TestRele", statoCollaudoEtsone.testReleStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestRele", "0")
            End If


            If CheckBox5V.Checked Then
                test_effettuati.Add("Test5V", statoCollaudoEtsone.test5VStatusSuccess.ToString)
            Else
                test_effettuati.Add("Test5V", "0")
            End If


            If CheckBoxIngressi.Checked Then
                test_effettuati.Add("TestIngressi", statoCollaudoEtsone.testIngressiStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestIngressi", "0")
            End If


            If CheckBoxCAN.Checked Then
                test_effettuati.Add("TestCAN", statoCollaudoEtsone.testCANStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestCAN", "0")
            End If

            If CheckBoxAccelerometro.Checked Then
                test_effettuati.Add("TestAccellerometro", statoCollaudoEtsone.testAccelerometroStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestAccelerometro", "0")
            End If

            If CheckBoxSD.Checked Then
                test_effettuati.Add("TestSD", statoCollaudoEtsone.testSDStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestSD", "0")
            End If

            If CheckBoxBatteria.Checked Then
                test_effettuati.Add("TestBattery", statoCollaudoEtsone.testBatteriaStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestBattery", "0")
            End If

            If CheckBoxSim.Checked Then
                test_effettuati.Add("TestSIM", statoCollaudoEtsone.testSimStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestSIM", "0")
            End If

            If CheckBoxWifFi.Checked Then
                test_effettuati.Add("TestWIFI", statoCollaudoEtsone.testWifiStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestWIFI", "0")
            End If

            If CheckBoxBadge.Checked Then
                test_effettuati.Add("TestBadge", statoCollaudoEtsone.testBadgeStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestBadge", "0")
            End If

            If CheckBoxUtenza.Checked Then
                test_effettuati.Add("TestUtenze", statoCollaudoEtsone.testUtenzaStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestUtenze", "0")
            End If

            If CheckBoxMemoria.Checked Then
                test_effettuati.Add("TestSyncMemory", statoCollaudoEtsone.testSyncStatusSuccess.ToString)
            Else
                test_effettuati.Add("TestSyncMemory", "0")
            End If



            par.Add("NomeUtente", nomeUtente)
            par.Add("Dispositivo", dispositivo)
            par.Add("test_effettuati", test_effettuati)
            par.Add("Numtest", NumTest)
        Catch ex As Exception
            AggiornaLog(ex)
        End Try

        Return par

    End Function
    Private Sub ButtonMongo_Click(sender As Object, e As EventArgs)

    End Sub

    Public Sub Initialised()
        LabelMongostatus.Text = "Invio dei Dati"
    End Sub

    Private Function Scancanmessage(Optional timeoutmilliseconds As Integer = 100) As TPCANMsg

        Dim raw_msg As New TPCANMsg()




        Dim sw As New Stopwatch
        sw.Restart()

        While sw.ElapsedMilliseconds <= timeoutmilliseconds



            If receiveCANMessage(raw_msg) Then
                Dim ID = raw_msg.ID
                Dim DATA = raw_msg.DATA
                '    Dim mio = Convert.ToString(Int64.Parse(raw_msg.ID.ToString()), 2)             'converte il messaggio decimale ricevuto in binario 

                '    Dim mio1 = mio.Substring(0, 4)                                                 'legge le prime quattro cifre del messaggio convertito in binario 
                '    Dim mio2dec = Convert.ToInt32(mio1, 2)                                        'le quattro cifre lette vengono convertite in decimale 

                '    If mio2dec = ComboBoxFunctionID.SelectedItem.value Then                        'controlla che il valore decimale appena convertito sia uguale al valore del sdo
                '        Dim mio3 = Convert.ToString(Int64.Parse(raw_msg.ID.ToString()), 2)        'riconverte il numero decimale in binario 
                '        Dim mio4 = mio.Substring(4, 7)                                             'va a leggere dalla posizione 4 alla 7 le cifre del numero binario 



                '        If mio4 = ComboBoxNodeID.SelectedItem.value Then                           'controlla che le cifre appena lette siano uguali al valore del nodo selezionato 
                '            MsgBox("connessione via can stabilita")

                '        Else
                '            MsgBox("connessione can non stabilita, controllare che il nodo sia corretto")
                '        End If






                '        Dim a = "01010010011010101"
                '        Dim b = Convert.ToInt32(a, 2)
                '        Dim c = Convert.ToString(b, 2)


                '        If icopenid >= 0 And icopenid <= &HF Then
                '            'If Not foundnodes.Contains(icopenid) Then
                '            '    foundnodes.Add(raw_msg)
                '            'End If




                '            MsgBox("ricevuto idghghg " & raw_msg.ID)

                '        End If
                '    End If
                'End If

                '------------test alimentazione--------------------
                '        If raw_msg.DATA(0) = 0 Then
                '    MsgBox("TEST ALIMENTAZIONE FALLITO")
                'Else
                '    raw_msg.DATA(0) = 1
                '    MsgBox("TEST COMPLETATO")
            End If

            receiveCANMessage(raw_msg)

        End While

        Return raw_msg


    End Function


    '                                     -----------------------------------SOPRA MODIFICATO DA ME------------------------------
    Private Sub avviaTestBadge()
        Dim dati = RDW_CommandCollaudo("R01")
        If dati = "KO" Then
            Throw New Exception("R1 ha ritornato 'KO'")
        End If
        Dim arrayDati = dati.Split("|")

        If arrayDati.Length < 50 Then
            Throw New Exception("Campi non sufficienti in R01")
        End If

        Dim badgePassato = arrayDati(50)
        If badgePassato IsNot Nothing And Not badgePassato.Contains("00000000") Then
            ChangeControlText(LabelUidBadge, badgePassato)
            statoCollaudoEtsone.testBadgeStatusSuccess = True
            statoCollaudoEtsone.testBadgeCompleted = True
        End If
    End Sub

    Private Sub avviaTestSD()
        Dim dati = RDW_CommandCollaudo("R01")
        If dati = "KO" Then
            Throw New Exception("R1 ha ritornato 'KO'")
        End If

        Dim arrayDati = dati.Split("|")
        If arrayDati.Length < 20 Then
            Throw New Exception("Campi non sufficienti in R01")
        End If

        Dim SDFound = False
        Dim SDSpace = False

        Dim SDstaus = CInt(arrayDati(20))
        If SDstaus = 1 Or SDstaus = 2 Then
            SDFound = True
        End If

        Dim sdFree = CInt(arrayDati(21))
        If sdFree > defaultMemoria Then
            SDSpace = True
        End If

        If SDFound Then
            ChangeControlBackgroundColor(PictureBoxSD1, Color.Green)
        Else
            ChangeControlBackgroundColor(PictureBoxSD1, Color.Red)
        End If

        If SDSpace Then
            ChangeControlBackgroundColor(PictureBoxSD2, Color.Green)
        Else
            ChangeControlBackgroundColor(PictureBoxSD2, Color.Red)
        End If

        If SDFound And SDSpace Then
            statoCollaudoEtsone.testSDCompleted = True
            statoCollaudoEtsone.testSDStatusSuccess = True
        End If
    End Sub

    Private Sub avviaTestBattery()
        While statoCollaudoEtsone.testBatteriaStatusSuccess = False And statoCollaudoEtsone.testBatteriaCompleted = False And abortTests = False
            Try
                CheckSerialPort()
                Dim dati = RDW_CommandCollaudo("R01")
                If dati = "KO" Then
                    Throw New Exception("R1 ha ritornato 'KO'")
                End If

                Dim arrayDati = dati.Split("|")
                If arrayDati.Length < 16 Then
                    Throw New Exception("Campi non sufficienti in R01")
                End If

                Dim batteryStatus = CInt(arrayDati(16))
                Dim tensioneInterna As Single = CSng(arrayDati(1)) / 10

                ChangeControlText(testBatteryStatusCode, "(" + batteryStatus.ToString() + ")")

                Dim status = False
                Dim tensione = False

                If tensioneInterna > minimoTensione And tensioneInterna < massimaTensione Then
                    ChangeControlText(LabelSpaceTensione, tensioneInterna)
                    ChangeControlBackgroundColor(PictureBox2Battery, Color.Green)
                    tensione = True

                    If batteryStatus = 1 Or batteryStatus = 2 Then
                        ChangeControlBackgroundColor(PictureBox1Battery, Color.Green)
                        status = True
                    End If

                    If status Then
                        ChangeControlBackgroundColor(PictureBox1Battery, Color.Green)
                    Else
                        ChangeControlBackgroundColor(PictureBox1Battery, Color.Red)
                    End If

                    If tensione Then
                        ChangeControlBackgroundColor(PictureBox2Battery, Color.Green)
                    Else
                        ChangeControlBackgroundColor(PictureBox2Battery, Color.Red)
                    End If

                    If status And tensione Then
                        statoCollaudoEtsone.testBatteriaStatusSuccess = True
                        statoCollaudoEtsone.testBatteriaCompleted = True
                        statoCollaudoEtsone.testBatteriaMessage = "OK"
                    End If
                End If
            Catch ex As Exception

            End Try
        End While


    End Sub

    Private Sub avviaTestSim()
        While statoCollaudoEtsone.testSimCompleted = False And statoCollaudoEtsone.testSimStatusSuccess = False And abortTests = False

            Try

                CheckSerialPort()
                Dim dati = RDW_CommandCollaudo("R01")
                Dim CodiceSIM = False

                If dati = "KO" Then
                    Throw New Exception("R1 ha ritornato 'KO'")
                End If

                Dim arrayDati = dati.Split("|")

                If arrayDati.Length < 28 Then
                    Throw New Exception("Campi non sufficienti in R01")
                End If

                Dim SIMstatus = CInt(arrayDati(28))
                Dim signalStrenght = CInt(arrayDati(2))

                If SIMstatus = 1 Then
                    ChangeControlBackgroundColor(PictureBoxSim1, Color.Green)
                Else
                    ChangeControlBackgroundColor(PictureBoxSim1, Color.Red)
                End If

                If signalStrenght > 0 Then
                    'controllare meglio il segnale
                    ChangeControlBackgroundColor(PictureBoxSim2, Color.Green)
                Else
                    ChangeControlBackgroundColor(PictureBoxSim2, Color.Red)
                End If


                If SIMstatus = 1 And signalStrenght > 0 Then
                    Dim NumSim = RDW_CommandCollaudo("Q404")
                    Dim boh = NumSim.Split("|")
                    statoCollaudoEtsone.testSimCompleted = True
                    statoCollaudoEtsone.testSimStatusSuccess = True
                End If

            Catch ex As Exception

            End Try
        End While
    End Sub

    Public Sub avviaTestAccelerometro()

        Try


            ChangeControlVisibility(GifAcc, True)
            Dim dati = RDW_CommandCollaudo("R01")
            If dati = "KO" Or dati = "" Then Return
            Dim arrayDati = dati.Split("|")
            If arrayDati.Length < 6 Then
                Throw New Exception("Campi non sufficienti in R01")
            End If

            Dim Gradi = Convert.ToDouble(arrayDati(6))

            'Dim X As Single = CSng(arrayDati(41) / 100)
            'Dim Y As Single = CSng(arrayDati(42) / 100)
            'Dim Z As Single = CSng(arrayDati(43) / 100)

            'Dim acc = False
            Dim azz = False

            Dim init = False
            While Not init And abortTests = False
                CheckSerialPort()
                init = InitAcc()
                If Not init Then
                    System.Threading.Thread.Sleep(1000)
                End If
            End While

            ChangeControlBackgroundColor(PictureBox1Accelerometro, Color.Green)

            Wait(1000)
            InitAzzero()

            ChangeControlText(LabelGradiInclinazione, Gradi)

            While Gradi < 45 And Gradi > -45 And abortTests = False
                CheckSerialPort()
                If abortTests Then
                    Return
                End If

                dati = RDW_CommandCollaudo("R01")
                If dati = "KO" Or dati = "" Then Return
                arrayDati = dati.Split("|")
                If arrayDati.Length < 6 Then
                    Throw New Exception("Campi non sufficienti in R01")
                End If
                Gradi = Convert.ToDouble(arrayDati(6))

                ChangeControlText(LabelGradiInclinazione, Gradi)
            End While

            ripristina_Sett(fileName)
            ChangeControlBackgroundColor(PictureBoxAzzeramento, Color.Green)
            ChangeControlVisibility(GifAcc, False)
            statoCollaudoEtsone.testAccelerometroCompleted = True
            statoCollaudoEtsone.testAccelerometroStatusSuccess = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub avviaTestWifi()
        Try

            CheckSerialPort()
            Dim dati = RDW_CommandCollaudo("R01")
            If dati = "KO" Then
                Throw New Exception("R1 ha ritornato 'KO'")
            End If

            Dim arrayDati = dati.Split("|")
            If arrayDati.Length < 64 Then
                Throw New Exception("Campi non sufficienti in R01")
            End If

            Dim macaddress = arrayDati(64)
            ChangeControlText(LabelMacAddress, macaddress)

            If macaddress <> Nothing And macaddress.Length > 0 Then
                statoCollaudoEtsone.testWifiCompleted = True
                statoCollaudoEtsone.testWifiStatusSuccess = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AvviaTestComunicazione()
        Try

            CheckSerialPort()
            Dim Code = RDW_CommandCollaudo("R0B", cloudCodeLocation) ' ETS: 1125, MDT: 3

            Dim aaa = Main.cloudPswLocation

            NewHR()
            Wait(500)
            NewLog()
            Wait(500)
            ForzaHR()
            Wait(500)
            ForzaLog()
            Wait(1000)

            If TypeOf kiwisat Is GRSatBonatti Then
                Dim response = kiwisat.doGetRequest(Host & "api/Logs/LastLog?deviceCode=" & labelSerialNumber.Text)

                Dim jss As New JavaScriptSerializer()
                ' "{\"timeStamp\": \"2021-02-23T10:25:00\"}"
                Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(response)

                If dict.ContainsKey("timeStamp") Then
                    Dim lastTrans = Date.ParseExact(dict("timeStamp"), "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture)

                    If Date.Now.Subtract(lastTrans).TotalMinutes <= 10 Then
                        ChangeControlBackgroundColor(PictureBoxComunicazione, Color.Green)
                        ChangeControlText(LabelSpacePOrtale, Host)
                        ChangeControlBackgroundColor(testComunicazioneStatus, Color.Green)

                        statoCollaudoEtsone.testComunicazioneCompleted = True
                        statoCollaudoEtsone.testComunicazioneStatusSuccess = True
                    End If
                End If

            Else
                'Host = RDW_CommandCollaudo("R0B", 0)
                Dim response = kiwisat.doGetRequest(Host & "/Mod_AssetMgmt/LoadXML.php?Tipo=1&modo=2&code=" & Code)   ' ritorna solo il dispositivo che stiamo cercando
                If response Is Nothing Or response = "KO" Then
                    Throw New Exception("Dispositivo non trovato")
                End If

                'ChangeControlVisibility(PictureBoxDevice, False)
                ChangeControlBackgroundColor(PictureBoxDevice, Color.Green)

                Dim xmlDoc As New XmlDocument
                xmlDoc.InnerXml = response
                Dim listadinodi = xmlDoc.SelectNodes("dati/dato")
                For Each nodo As XmlNode In listadinodi
                    'Not nodo.Attributes.GetNamedItem("D10").Value.Contains("*")) And DA RIMETTERE SOTTO
                    If ((Not nodo.Attributes.GetNamedItem("D10").Value.Contains("*")) And (Not nodo.Attributes.GetNamedItem("D10").Value = 0) And (Not nodo.Attributes.GetNamedItem("D10").Value = "KO")) Then
                        ' MsgBox("Il device ha comunicato")

                        'ChangeControlVisibility(PictureBoxComunicazione, False)
                        ChangeControlBackgroundColor(PictureBoxComunicazione, Color.Green)
                        ChangeControlText(LabelSpacePOrtale, Host)


                        Dim nomeDevice = nodo.Attributes.GetNamedItem("D1").Value
                        statoCollaudoEtsone.idDevice = nodo.Attributes.GetNamedItem("D0").Value
                        statoCollaudoEtsone.idAsset = nodo.Attributes.GetNamedItem("D20").Value

                        statoCollaudoEtsone.testComunicazioneCompleted = True
                        statoCollaudoEtsone.testComunicazioneStatusSuccess = True

                    ElseIf (Not nodo.Attributes.GetNamedItem("D10").Value.Contains("*")) And (Not nodo.Attributes.GetNamedItem("D10").Value = 0) And (Not nodo.Attributes.GetNamedItem("D10").Value = "KO") Then
                        If LabelIp.Text Is Nothing Then
                            Wait(LabelIp.Text IsNot Nothing)

                        ElseIf LabelIp.Text IsNot Nothing Then
                            NewHR()
                            NewLog()
                            ForzaHR()
                            ForzaLog()
                        End If

                        Throw New Exception("IMEI: " + nodo.Attributes.GetNamedItem("D10").Value)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub AvviaTestSync()
        Try

            CheckSerialPort()
            Dim export = False
            Dim import = False
            Dim sync = False


            If statoCollaudoEtsone.testSyncCurrentStep = 0 Then
                leggiMemoria("mem" & Main.SerialPort.PortName & ".etsbak")
                ' Dim timeStamp As DateTime = DateTime.Now
                'leggiMemoria("Memorie\" & "memoria" & labelSerialNumber.Text & ".etsbak") '& timeStamp)

                'ChangeControlVisibility(PictureBox1EsportaMemoria, False)
                ChangeControlBackgroundColor(PictureBox1EsportaMemoria, Color.Green)
                export = True
                statoCollaudoEtsone.testSyncCurrentStep = 1
            End If

            If TypeOf kiwisat Is GRSatBonatti Then
                If statoCollaudoEtsone.testSyncCurrentStep = 1 Then
                    If Not statoCollaudoEtsone.importaOk Then
                        If ImportaMemoriaSuPortaleBonatti(statoCollaudoEtsone.deviceSerial) Then
                            ChangeControlBackgroundColor(PictureBox1ImpotaMemoria, Color.Green)
                            import = True
                            statoCollaudoEtsone.testSyncCurrentStep = 2
                        End If
                    End If
                End If

                ChangeControlBackgroundColor(PictureBox1ImpotaMemoria, Color.Green)
                ChangeControlBackgroundColor(PictureBox1Sync, Color.Green)

                statoCollaudoEtsone.testSyncCompleted = True
                statoCollaudoEtsone.testSyncStatusSuccess = True

            Else
                If statoCollaudoEtsone.idDevice IsNot "" Then
                    Dim response = kiwisat.doGetRequest(Host & "/script/LoadXML.php?Tipo=1&modo=4&id_mezzo=" + statoCollaudoEtsone.idAsset)

                    Dim xmlDoc As New XmlDocument
                    xmlDoc.InnerXml = response
                    Dim listadinodi = xmlDoc.SelectNodes("dati/dato")
                    Dim idAsset

                    Dim resultLength = 0
                    For Each nodo As XmlNode In listadinodi

                        If nodo.Attributes.GetNamedItem("ID_X19").Value = statoCollaudoEtsone.idDevice Then
                            'MsgBox(nodo.Attributes.GetNamedItem("ID_X19").Value & "l'id device corrisponde a quello che stiamo cercando ")

                            idAsset = nodo.Attributes.GetNamedItem("ID_MEZZO").Value
                            'MsgBox("Trovato , id asset : " & idAsset)

                            resultLength = resultLength + 1
                        End If

                    Next

                    If resultLength = 1 Then
                        If statoCollaudoEtsone.testSyncCurrentStep = 1 Then
                            If Not statoCollaudoEtsone.importaOk Then importaMemoriaSuPortale(idAsset)
                            ChangeControlBackgroundColor(PictureBox1ImpotaMemoria, Color.Green)
                            import = True
                            statoCollaudoEtsone.testSyncCurrentStep = 2
                        End If

                        If statoCollaudoEtsone.testSyncCurrentStep = 2 Then
                            While True
                                CheckSerialPort()

                                If abortTests Then
                                    Return
                                End If

                                Dim perc = controlloMemoria(idAsset)
                                'PictureBox1Sync.Visible = False
                                'PictureBox1ImportaMemoria.Visible = False

                                If perc = "100.00" Then
                                    sync = True
                                    ChangeControlBackgroundColor(PictureBox1ImpotaMemoria, Color.Green)
                                    ChangeControlBackgroundColor(PictureBox1Sync, Color.Green)
                                    Exit While
                                End If
                            End While
                        End If
                    Else
                        'MsgBox("Errore grave, esistono piu asset (" & resultLength & ")  associati allo stesso device . risolvere prima di continuare ")
                        ChangeControlVisibility(PictureBox1EsportaMemoria, False)
                        ChangeControlBackgroundColor(PictureBox1ImpotaMemoria, Color.Red)
                        ChangeControlText(testMemsyncMessage, "Esistono più asset associati allo stesso device")
                        Throw New Exception("Esistono più asset associati allo stesso device")
                    End If

                    'If format And export And import And sync And sizeCheck Then
                    '    collaudoData.testSyncCompleted = True
                    '    collaudoData.testSyncStatusSuccess = True
                    'End If

                    If export And import And sync Then
                        statoCollaudoEtsone.testSyncCompleted = True
                        statoCollaudoEtsone.testSyncStatusSuccess = True
                    End If
                Else
                    ChangeControlBackgroundColor(PictureBox1ImpotaMemoria, Color.Red)
                    ChangeControlText(testMemsyncMessage, "Asset ID non disponibile")
                    Throw New Exception("Asset ID non disponibile")
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub AvviaTestUtenza()
        Try


            Dim a As String = RDW_CommandCollaudo("R05", 131072)
            Dim b As String = RDW_CommandCollaudo("R08", 600)

            If b <> "1" Then
                Throw New Exception("Impossibile create l'utente")
            End If

            Dim done = False
            While Not done
                CheckSerialPort()
                If abortTests Then
                    Return
                End If

                Dim dati = RDW_CommandCollaudo("R01")
                If dati = "KO" Then
                    Throw New Exception("R1 ha ritornato 'KO'")
                End If

                Dim arrayDati = dati.Split("|")
                If arrayDati.Length < 55 Then
                    Throw New Exception("Campi non sufficienti in R01")
                End If

                Dim checkUTENZA = arrayDati(55)

                If checkUTENZA.ToLower().Equals("check utenza") Then
                    done = True
                    statoCollaudoEtsone.testUtenzaStatusSuccess = True
                    statoCollaudoEtsone.testUtenzaCompleted = True
                End If
            End While
        Catch ex As Exception

        End Try
    End Sub

    Private Function InitAcc()
        Try


            ripristina_Sett(setupFileName)

            Dim a As String = RDW_CommandCollaudo("R07", 32)
            'Dim b As String = RDW_CommandCollaudo("R11")
            'And b = "2|0" Or b = "4|3"
            If a = "1" Then
                Return True
            End If

            Return False
        Catch ex As Exception

        End Try
    End Function


    Private Sub InitAzzero()
        Try
            Dim a As String = RDW_CommandCollaudo("Z103")
            Dim b As String = RDW_CommandCollaudo("Z104")
        Catch ex As Exception

        End Try
    End Sub

    Private Function quasiUguale(a As Double, b As Double)

        If (Math.Abs(a - b) < sogliaErrore) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub ripristina_Sett(fn As String)
        Dim callCounter As Integer = 0
        Try

            Dim risposta As String

            Dim progress As Integer = 0



            Dim alltext()
            Using sw As StreamReader = New StreamReader(fn)
                alltext = Split(sw.ReadToEnd, vbCrLf)
            End Using

            Dim stip As Integer = 0
            Dim silentRetry As Integer = 0
            Dim userFormatErrorShown As Boolean = False

            For i = 0 To alltext.Count - 1
                Try
                    Dim cmd = alltext(i)
                    If cmd = "" Or Not cmd.StartsWith("$") Then Continue For
                    If pwfStopLoading Then Exit For
                    Dim formatoUtentiSupportato As Boolean = True
                    Dim cmdSplit = cmd.split(" ")
                    statoCollaudoEtsone.VERSIONECONNESSA = 313
                    If statoCollaudoEtsone.VERSIONECONNESSA >= 313 AndAlso (cmd.ToString().StartsWith("$W06 ") AndAlso cmd.split(" ")(1) >= 512) Then formatoUtentiSupportato = False
                    If statoCollaudoEtsone.VERSIONECONNESSA >= 313 AndAlso (cmd.ToString().StartsWith("$W05 ") AndAlso cmd.split(" ")(1) >= 131072 AndAlso cmd.split(" ")(2) = "256") Then formatoUtentiSupportato = False
                    If statoCollaudoEtsone.VERSIONECONNESSA >= 313 AndAlso (cmd.ToString().StartsWith("$W08 ") AndAlso cmd.split(" ")(1) = 600 AndAlso cmd.split(" ")(2) > 1500) Then formatoUtentiSupportato = False
                    If statoCollaudoEtsone.VERSIONECONNESSA < 313 AndAlso (cmd.ToString().StartsWith("$W05 ") AndAlso cmd.split(" ")(1) >= 131072 AndAlso cmd.split(" ")(2) <> "256") Then formatoUtentiSupportato = False


                    If Not formatoUtentiSupportato Then
                        If Not userFormatErrorShown Then
                            MessageBox.Show("Formato utenti non supportato, non verranno importati")
                            userFormatErrorShown = True
                        End If
                        Continue For
                    End If


                    cmd = cmd.TrimStart("$")
                    If cmd.StartsWith("W06 ") AndAlso cmd.Split(" ").Length > 2 AndAlso cmd.Split(" ")(2).Contains("K") Then
                        cmd = computeImportPage(cmd)
                    End If

                    risposta = RDW_CommandCollaudo(Trim(cmd), , , , , , 3000)
                    If (risposta = "?" Or risposta = "KO") AndAlso (silentRetry < 3 OrElse MessageBox.Show("Errore nell'aggiornamento del parametro" & ": " & cmd, "", MessageBoxButtons.RetryCancel) = Windows.Forms.DialogResult.Retry) Then
                        silentRetry += 1
                        i -= 1
                        Continue For
                    End If
                    silentRetry = 0

                    Dim str As String = ""
                    If stip = 0 Then
                        str = "|    |    |"
                    ElseIf stip = 1 Then
                        str = "/    /    /"
                    ElseIf stip = 2 Then
                        str = "--   --   --"
                    Else
                        str = "\    \    \"
                        stip = 0
                    End If
                    stip += 1

                    progress += 1
                    callCounter = 0
                    ' showWait(str, progress, alltext.Count, , , True)
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try
            Next

            If progress > 0 Then
                RDW_CommandCollaudo("L02")


            End If
        Catch ex As Exception
            AggiornaLog(ex)
        End Try

        pwfStopLoading = False

    End Sub

    Public Function NewHR() As String
        ' Verificare se nella risposta c'è l'ICCID
        Return RDW_CommandCollaudo("Q404")
    End Function
    Public Function NewLog() As String
        Return RDW_CommandCollaudo("Q403")
    End Function
    Public Sub ForzaHR()
        RDW_CommandCollaudo("Q407")
    End Sub
    Public Sub ForzaLog()
        RDW_CommandCollaudo("Q406")
    End Sub

    Sub leggiMemoria(fileToSavePath As String)
        Dim a = File.Create(fileToSavePath)

        a.Close()

        Using sw As New StreamWriter(fileToSavePath)

            For i As Integer = 0 To 1023 Step +1

                Dim map As String = RDW_CommandCollaudo("R06", i)
                If map = "KO" Then
                    Wait(100)
                    i -= 1
                    Continue For
                End If
                If map.Length <> 512 Then
                    Select Case MessageBox.Show("Comando ricevuto troppo corto! Dimensione: " & map.Length & " , Pagina" & " " & i, "", MessageBoxButtons.AbortRetryIgnore)
                        Case Windows.Forms.DialogResult.Retry
                            Wait(100)
                            i -= 1
                            Continue For
                        Case Windows.Forms.DialogResult.Abort
                            Exit For
                    End Select
                End If

                sw.WriteLine("$W06 " & i & " " & map)
                ChangeControlText(testMemsyncExportPercentage, "(" + (i + 1).ToString() + ")")
            Next

        End Using

        'disposeWait()
    End Sub

    Sub importaMemoriaSuPortale(id)
        Dim body As New norvanco.http.MultipartForm(Host & "/DummySystem/LoadXML.php")
        'Application.StartupPath & "\mem.etsbak"
        'Dim br As BinaryReader
        'br = New BinaryReader(File.Open(Application.StartupPath & "\mem.etsbak", FileMode.Open))
        body.setField("Tipo", "26")
        body.setField("modo", "6")
        body.setField("cod", id)
        body.FileContentType = "application/octet-stream"
        body.sendFile(Application.StartupPath & "\mem" & Main.SerialPort.PortName & ".etsbak", kiwisat.cloudWebClient.cookieContainer)

        Dim response = body.ResponseText.ToString()
        'br.Close()

        statoCollaudoEtsone.importaOk = True
    End Sub

    Function ImportaMemoriaSuPortaleBonatti(id As Integer) As Boolean
        Dim reader As StreamReader = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath & "\mem" & Main.SerialPort.PortName & ".etsbak")
        Dim line As String

        Dim n_line As Integer = 0
        Do
            line = reader.ReadLine()
            If line IsNot Nothing Then
                line = line.Split(" "c)(2)

                Dim cs = getChecksum(line)

                Dim data = New Dictionary(Of String, Object)
                data.Add("content", line)
                data.Add("checksum", cs)
                data.Add("page", n_line)
                data.Add("deviceCode", id)

                kiwisat.doPostJSonRequest(Host & "api/MemoryPages", data)

                n_line += 1
            End If

        Loop Until line Is Nothing

        reader.Close()

        statoCollaudoEtsone.importaOk = True
    End Function

    Public Function getChecksum(s As String) As String
        Dim bytes() As Byte = StringToByteArray(s)
        Dim sum As Integer = 0

        For Each b In bytes
            sum += b
        Next

        Return sum.ToString()
    End Function

    Public Shared Function StringToByteArray(s As String) As Byte()
        ' remove any spaces from, e.g. "A0 20 34 34"
        s = s.Replace(" "c, "")
        ' make sure we have an even number of digits
        If (s.Length And 1) = 1 Then
            Throw New FormatException("Odd string length when even string length is required.")
        End If

        ' calculate the length of the byte array and dim an array to that
        Dim nBytes = s.Length \ 2
        Dim a(nBytes - 1) As Byte

        ' pick out every two bytes and convert them from hex representation
        For i = 0 To nBytes - 1
            a(i) = Convert.ToByte(s.Substring(i * 2, 2), 16)
        Next

        Return a

    End Function

    Function controlloMemoria(id)
        Dim response = kiwisat.doGetRequest(Host & "/DummySystem/LoadXML.php?Tipo=29&modo=15&source=" & id)
        Dim Stato = response.Split("|")
        Dim verificaState = Stato(0)

        If verificaState = 0 Then
            Dim memoryStatus = Stato(1)
            'If memoryStatus = "100.00" Then
            'Return True
            'End If
            Return memoryStatus
        End If

        Return "Impossibile leggere percentuale memoria"

    End Function

    Sub Wait(ByVal millisecondi As Integer, Optional showWait As Boolean = False)
        'Try
        '    Dim WC As New Stopwatch

        '    WC.Reset()
        '    WC.Start()
        '    While WC.ElapsedMilliseconds < millisecondi

        '        Application.DoEvents()
        '        System.Threading.Thread.Sleep(1)
        '    End While
        'Catch
        '    Dim a = 0
        'End Try

        'If showWait Then disposeWait(, True)

        System.Threading.Thread.Sleep(millisecondi)
    End Sub



    ''------------------------------------------------------------------ ICON - APN - CUBO ACCELEROMETRO - RTC --------------------------------------------------------------

    'Delegate Sub mng_iconeDelegate()
    'Dim statoSimStringhe = New String(5) {"No Pin", "Pin inserito", "Abilitare inserimento PIN", "Pin errato", "Cliccare qui per inserire manualmente il codice PIN", "Sim card bloccata"}

    'Sub gestisciIcone()
    '    PanelIcone.Visible = True
    '    If Me.InvokeRequired Then
    '        Me.Invoke(New mng_iconeDelegate(AddressOf gestisciIcone))
    '    Else
    '        Try



    '            Select Case batteryStatus
    '                Case 0, 3
    '                    IconBattery.Image = SafeImageFromFile(Application.StartupPath & "\icons\batteria_errore")
    '                    'ToolTip.SetToolTip(IconBattery, mui.Get_String_From_Tag("ST9", "Errore batteria"))
    '                Case 1
    '                    IconBattery.Image = SafeImageFromFile(Application.StartupPath & "\icons\batteria_full")
    '                    'ToolTip.SetToolTip(IconBattery, mui.Get_String_From_Tag("ST31", "Carica completata!"))
    '                Case 2
    '                    IconBattery.Image = SafeImageFromFile(Application.StartupPath & "\icons\batteria_in_carica")
    '                    'ToolTip.SetToolTip(IconBattery, mui.Get_String_From_Tag("ST11", "Batteria in carica..."))
    '            End Select

    '            Dim picPath As String = Application.StartupPath & "\icons\"

    '            If Not IsNothing(StatoWifi) Then
    '                If (StatoWifi(5) = 2 Or StatoWifi(5) = 3 Or StatoWifi(5) = 4 Or StatoWifi(5) = 9 Or StatoWifi(5) = 10) Then
    '                    wifiOccupato = True
    '                Else
    '                    wifiOccupato = False
    '                End If

    '                Dim tipText As String = ""

    '                If StatoWifi(0) = 0 Then
    '                    picPath = picPath & "wifi_connesso_busy"
    '                    'tipText = mui.Get_String_From_Tag("ST285", "Inizializzazione")
    '                ElseIf (StatoWifi(0) >> 3) And 1 Then
    '                    picPath = picPath & "wifi_connesso"
    '                    If wifiOccupato Then
    '                        picPath = picPath & "_busy"
    '                    End If
    '                    'tipText = mui.Get_String_From_Tag("ST6", "WiFi connesso")
    '                ElseIf (StatoWifi(0) >> 2) And 1 Then
    '                    picPath = picPath & "wifi_connesso_busy"
    '                    'tipText = mui.Get_String_From_Tag("ST286", "Ottenimento IP")
    '                ElseIf (StatoWifi(0) >> 1) And 1 Then
    '                    picPath = picPath & "wifi_connesso_busy"
    '                    'tipText = mui.Get_String_From_Tag("ST7", "WiFi in connessione...")
    '                ElseIf (StatoWifi(0) >> 0) And 1 Then
    '                    picPath = picPath & "wifi_connesso_busy" '"wifi_non_connesso"
    '                    'tipText = mui.Get_String_From_Tag("ST287", "Ricerca rete")
    '                ElseIf StatoWifi(4) = 0 Then
    '                    picPath = Application.StartupPath & "\icons\" & "wifi_errore"
    '                    'tipText = mui.Get_String_From_Tag("ST9", "WiFi in Errore, controllare le impostazioni")
    '                End If

    '                If DevWiFi5GHz Then
    '                    If connectionErrorTimer5GHz > 0 Then
    '                        picPath = Application.StartupPath & "\icons\" & "wifi_errore"
    '                        'Dim msga = mui.Get_String_From_Tag("TAG534", "Errore di connessione alla rete, prossimo tentativo in~secondi. Controllare le impostazioni").Split("~")
    '                        'tipText = msga(0) & " " & connectionErrorTimer5GHz & vbCrLf & msga(1)
    '                    End If
    '                End If


    '                'ToolTip.SetToolTip(IconWifi, tipText)
    '                IconWifi.Image = SafeImageFromFile(picPath)
    '            End If


    '            If statoModemGPRS = 2 Or statoModemGPRS = 3 Or statoModemGPRS = 4 Or statoModemGPRS = 9 Or statoModemGPRS = 10 Or statoModemGPRS = 11 Or statoModemGPRS = 12 Or statoModemGPRS = 13 Or statoModemGPRS = 14 Then
    '                modemoccupato = True
    '            Else
    '                modemoccupato = False
    '            End If


    '            picPath = Application.StartupPath & "\icons\"
    '            Dim tempstr As String = ""
    '            If statoSimStringhe.Length > pinStatus Then tempstr = statoSimStringhe(pinStatus)


    '            If statoModemGPRS > 0 And TRAFFIC_BLOCK Then

    '                picPath = picPath & "GSM_error"
    '                If modemoccupato Then picPath = picPath & "_busy"
    '                'ToolTip.SetToolTip(IconGsmGPRS, mui.Get_String_From_Tag("TAG371", "La soglia di consumo dati giornaliera è stata raggiunta, il traffico è stato bloccato"))

    '            ElseIf statoModemGPRS > 0 And simStatus = False Then
    '                picPath = picPath & "NOSIM"
    '                '  If modemoccupato Then picPath = picPath & "_busy"
    '                'ToolTip.SetToolTip(IconGsmGPRS, mui.Get_String_From_Tag("ST50", "Nessuna SIM rilevata"))


    '            ElseIf statoModemGPRS > 0 And simStatus = True And (pinStatus >= 2) Then
    '                picPath = picPath & "PINCODE"
    '                'ToolTip.SetToolTip(IconGsmGPRS, statoSimStringhe(pinStatus))


    '            ElseIf statoModemGPRS > 0 And simStatus = True And GPRS = False Then
    '                If statoReteGSM = 0 Or statoReteGSM = 3 Then
    '                    picPath = picPath & "GSM_error"
    '                ElseIf statoReteGSM = 2 Then
    '                    picPath = picPath & "GSM_ok"
    '                    modemoccupato = True
    '                Else
    '                    picPath = picPath & "GSM_ok"
    '                End If
    '                If modemoccupato Then picPath = picPath & "_busy"
    '                'ToolTip.SetToolTip(IconGsmGPRS, mui.Get_String_From_Tag("ST248", "SIM presente") & vbCrLf & StatiGSM(statoReteGSM) & vbCrLf & tempstr)


    '            ElseIf statoModemGPRS > 0 And simStatus = True And GPRS = True Then

    '                picPath = picPath & "GPRS_ok"
    '                LabelIp.Text = ets._ComandiIcone.Ip
    '                If modemoccupato Then picPath = picPath & "_busy"
    '                'ToolTip.SetToolTip(IconGsmGPRS, mui.Get_String_From_Tag("ST13", "Connessione GPRS OK") & vbCrLf & StatiGPRS(statoReteGPRS) & vbCrLf & tempstr)


    '            Else
    '                picPath = picPath & "GSM_error"
    '                If modemoccupato Then picPath = picPath & "_busy"
    '                'ToolTip.SetToolTip(IconGsmGPRS, mui.Get_String_From_Tag("ST10", "Errore modem GSM, controllare le impostazioni"))
    '            End If

    '            IconGsmGPRS.Image = SafeImageFromFile(picPath)


    '            If sigStr = 0 Then
    '                IconSigStrength.Image = SafeImageFromFile(Application.StartupPath & "\icons\segnale_0")
    '                'ToolTip.SetToolTip(IconSigStrength, mui.Get_String_From_Tag("ST14", "Nessun segnale"))
    '            ElseIf sigStr > 0 And sigStr < 7.75 Then
    '                IconSigStrength.Image = SafeImageFromFile(Application.StartupPath & "\icons\segnale_2")
    '                'ToolTip.SetToolTip(IconSigStrength, mui.Get_String_From_Tag("ST15", "Segnale debole"))
    '            ElseIf sigStr > 7.75 And sigStr < 15.5 Then
    '                IconSigStrength.Image = SafeImageFromFile(Application.StartupPath & "\icons\segnale_3")
    '                ' ToolTip.SetToolTip(IconSigStrength, mui.Get_String_From_Tag("ST16", "Segnale buono"))
    '            ElseIf sigStr > 15.5 And sigStr < 23.25 Then
    '                IconSigStrength.Image = SafeImageFromFile(Application.StartupPath & "\icons\segnale_4")
    '                ' ToolTip.SetToolTip(IconSigStrength, mui.Get_String_From_Tag("ST17", "Segnale molto buono"))
    '            ElseIf sigStr > 23.25 And sigStr < 31 Then
    '                IconSigStrength.Image = SafeImageFromFile(Application.StartupPath & "\icons\segnale_5")
    '                'ToolTip.SetToolTip(IconSigStrength, mui.Get_String_From_Tag("ST18", "Segnale ottimo"))
    '            End If

    '            If Not pwr Then
    '                IconGPS.Image = SafeImageFromFile(Application.StartupPath & "\icons\GPS_OFF")
    '                ' ToolTip.SetToolTip(IconGPS, mui.Get_String_From_Tag("ST19", "GPS disattivato"))
    '            ElseIf pwr And Not fix Then
    '                IconGPS.Image = SafeImageFromFile(Application.StartupPath & "\icons\GPS_PWR")
    '                ' ToolTip.SetToolTip(IconGPS, mui.Get_String_From_Tag("ST20", "GPS attivo ma posizione non rilevata"))
    '            ElseIf pwr And fix Then
    '                IconGPS.Image = SafeImageFromFile(Application.StartupPath & "\icons\GPS_FIX")
    '                ' ToolTip.SetToolTip(IconGPS, mui.Get_String_From_Tag("ST21", "GPS attivo e posizione aggiornata"))
    '            End If

    '            Select Case sdStatus
    '                Case 0
    '                    IconSD.Image = SafeImageFromFile(Application.StartupPath & "\icons\SD_Errore")
    '                  '  ToolTip.SetToolTip(IconSD, mui.Get_String_From_Tag("ST26", "Scheda SD non presente"))
    '                Case 1
    '                    IconSD.Image = SafeImageFromFile(Application.StartupPath & "\icons\SD_ok")
    '                  '  ToolTip.SetToolTip(IconSD, mui.Get_String_From_Tag("ST22", "Scheda SD presente"))
    '                Case 2
    '                    IconSD.Image = SafeImageFromFile(Application.StartupPath & "\icons\SD_warn")
    '                    ' ToolTip.SetToolTip(IconSD, mui.Get_String_From_Tag("ST23", "Scheda SD da formattare"))
    '            End Select





    '        Catch ex As Exception
    '            AggiornaLog(ex)
    '        End Try

    '    End If

    'End Sub

    'Public Function SafeImageFromFile(path As String) As Image
    '    If Not File.Exists(path) Then Return Nothing
    '    Dim xx As Image
    '    Using str As Stream = File.OpenRead(path)
    '        xx = Image.FromStream(str)
    '    End Using
    '    Return xx
    'End Function

    'Enum UI_ICONS
    '    WIFI
    '    GPS
    '    Modem
    '    SD
    '    Batteria
    '    ETSDN

    'End Enum

    ''                                                                    ------------ APN ---------------


    Private Sub ComboBoxApn_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim sr As StreamReader = New StreamReader(Application.StartupPath & "\SIM\" & ComboBoxApn.SelectedItem.ToString & "\set.txt")

        While (sr.Peek() >= 0)
            Dim line = sr.ReadLine()

            If line.StartsWith("$W0B 1149 ") Then
                Dim apn = line.Replace("$W0B 1149 ", "")
                Dim name = RDW_CommandCollaudo("W0B", 1149, apn)
                RDW_CommandCollaudo("W07", 86, 0)
            End If
            If line.StartsWith("$W0B 1763 ") Then
                Dim apn = line.Replace("$W0B 1763 ", "")
                Dim name = RDW_CommandCollaudo("W0B", 1763, apn)
                RDW_CommandCollaudo("W07", 86, 1)
            End If
            If line.StartsWith("$W0B 1863 ") Then
                Dim apn = line.Replace("$W0B 1863 ", "")
                Dim name = RDW_CommandCollaudo("W0B", 1863, apn)
                RDW_CommandCollaudo("W07", 86, 2)
            End If
        End While

    End Sub

    '''                                                                           -------------- CUBO -------------------



    'Private Sub PanelCubo_Paint(sender As Object, e As PaintEventArgs) Handles PanelCubo.Paint
    '    If mui.skipEvents Or skippaEventi Then Exit Sub

    '    Dim t(8) As Point3D
    '    Dim f(4) As Integer
    '    Dim v As Point3D
    '    Dim avgZ(6) As Double
    '    Dim order(6) As Integer
    '    Dim tmp As Double
    '    Dim iMax As Integer
    '    Try
    '        ' Clear the window
    '        CaricaIO()

    '        ' Transform all the points and store them on the "t" array.
    '        For i = 0 To 7
    '            v = m_vertices(i)
    '            t(i) = v.RotateX(m_x).RotateY(m_y).RotateZ(m_z)

    '        Next


    '        t(0) = t(0).Project(145, 110, 100, 4)
    '        t(1) = t(1).Project(145, 110, 100, 4)
    '        t(2) = t(2).Project(145, 110, 100, 4)
    '        t(3) = t(3).Project(145, 110, 100, 4)

    '        t(4) = t(4).Project(145, 110, 100, 4)
    '        t(5) = t(5).Project(145, 110, 100, 4)
    '        t(6) = t(6).Project(145, 110, 100, 4)
    '        t(7) = t(7).Project(145, 110, 100, 4)


    '        ' Compute the average Z value of each face.
    '        For i = 0 To 5
    '            avgZ(i) = (t(m_faces(i, 0)).Z + t(m_faces(i, 1)).Z + t(m_faces(i, 2)).Z + t(m_faces(i, 3)).Z) / 4.0
    '            order(i) = i
    '        Next

    '        ' Next we sort the faces in descending order based on the Z value.
    '        ' The objective is to draw distant faces first. This is called 
    '        ' the PAINTERS ALGORITHM. So, the visible faces will hide the invisible ones.
    '        ' The sorting algorithm used is the SELECTION SORT.
    '        For i = 0 To 4
    '            iMax = i
    '            For j = i + 1 To 5
    '                If avgZ(j) > avgZ(iMax) Then
    '                    iMax = j
    '                End If
    '            Next
    '            If iMax <> i Then
    '                tmp = avgZ(i)
    '                avgZ(i) = avgZ(iMax)
    '                avgZ(iMax) = tmp

    '                tmp = order(i)
    '                order(i) = order(iMax)
    '                order(iMax) = tmp
    '            End If
    '        Next

    '        ' Draw the faces using the PAINTERS ALGORITHM (distant faces first, closer faces last).
    '        For i = 0 To 5
    '            Dim points() As Point
    '            Dim index As Integer = order(i)
    '            points = New Point() {
    '                New Point(CInt(t(m_faces(index, 0)).X), CInt(t(m_faces(index, 0)).Y)),
    '                New Point(CInt(t(m_faces(index, 1)).X), CInt(t(m_faces(index, 1)).Y)),
    '                New Point(CInt(t(m_faces(index, 2)).X), CInt(t(m_faces(index, 2)).Y)),
    '                New Point(CInt(t(m_faces(index, 3)).X), CInt(t(m_faces(index, 3)).Y))
    '            }
    '            e.Graphics.FillPolygon(m_brushes(index), points)
    '        Next

    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try
    'End Sub

    'Private Sub InitCube()
    '    Try
    '        ' Create the cube vertices.
    '        m_vertices = New Point3D() {
    '                     New Point3D(-1, 1, -1),
    '                     New Point3D(1, 1, -1),
    '                     New Point3D(1, -1, -1),
    '                     New Point3D(-1, -1, -1),
    '                     New Point3D(-1, 1, 1),
    '                     New Point3D(1, 1, 1),
    '                     New Point3D(1, -1, 1),
    '                     New Point3D(-1, -1, 1)}

    '        ' Create an array representing the 6 faces of a cube. Each face is composed by indices to the vertex array
    '        ' above.
    '        m_faces = New Integer(,) {{0, 1, 2, 3}, {1, 5, 6, 2}, {5, 4, 7, 6}, {4, 0, 3, 7}, {0, 4, 5, 1}, {3, 2, 6, 7}}

    '        ' Define the colors of each face.
    '        m_colors = New Color() {System.Drawing.Color.BlueViolet, System.Drawing.Color.Cyan, System.Drawing.Color.Green, System.Drawing.Color.Yellow, System.Drawing.Color.Violet, System.Drawing.Color.LightSkyBlue}

    '        ' Create the brushes to draw each face. Brushes are used to draw filled polygons.
    '        For i = 0 To 5
    '            m_brushes(i) = New SolidBrush(m_colors(i))
    '        Next


    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try
    'End Sub





    Sub expError(className As String)
        Try
            Dim blob As String() '= Split(mui.Get_String_From_Tag("TAG237", "Errore nell'esportazione di~"), "~")
            If blob.Count = 1 Then
                Dim blub As List(Of String) = blob.ToList
                blub.Add("")
                blob = blub.ToArray()
            End If
            MessageBox.Show(blob(0) & " " & className & " " & blob(1))
        Catch ex As Exception
            AggiornaLog(ex)
        End Try

    End Sub





    '---------------------------------------------------------------------------- BUTTON -------------------------------------------------------------------------------



    Private Sub ButtonSync_Click(sender As Object, e As EventArgs) Handles ButtonSync.Click
        Try
            If Not IsNothing(sender) Then
                sender.enabled = False
            End If
            ets.Settings.RTC.SincronizzaRTC()
            MessageBox.Show(mui.Get_String_From_Tag("ST55", "Scrittura completata"))
            ButtonRTC_Click(Nothing, Nothing)
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        If Not IsNothing(sender) Then
            sender.enabled = True
        End If

    End Sub

    Private Sub ButtonRTC_Click(sender As Object, e As EventArgs)
        TimerTest.Stop()

        If Not IsNothing(sender) Then
            sender.enabled = False
        End If
        Try
            LabelDATA.Text = ets.Settings.RTC.Data.Date
            LabelORA.Text = ets.Settings.RTC.Data.ToLongTimeString

        Catch ex As Exception
            'If DontAskConferma Then expError(ets.Settings.RTC.GetType.Name)
            AggiornaLog(ex)
        End Try

        If Not IsNothing(sender) Then
            sender.enabled = True
        End If
        TimerTest.Start()

    End Sub

    '                                         ----------------------- BUTTON RIPRISTINA COLLAUDO---------------------


    Sub ripristinaPanelbox()
        PanelBadge.BackColor = Color.Transparent
        PanelSD.BackColor = Color.Transparent
        PanelBatteria.BackColor = Color.Transparent
        PanelSim.BackColor = Color.Transparent
        PanelAccelerometro.BackColor = Color.Transparent
        PanelWifi.BackColor = Color.Transparent
        PanelPortale.BackColor = Color.Transparent
        PanelSync.BackColor = Color.Transparent


    End Sub

    'Private Sub ButtonledGps_Click(sender As Object, e As KeyEventArgs)
    '    If e.KeyCode = Windows.Forms.Keys.F5 Then
    '        ButtonledGps.BackColor = Color.Green

    '    End If
    'End Sub

    Public Function FormattaDataOra(ByRef giorno As String, ByRef mese As String, ByRef anno As String,
                                                   ByRef ora As String, ByRef minuti As String, ByRef secondi As String,
                                                   Optional isRTCdate As Boolean = False) As DateTime
        Try


            If giorno.Length = 1 Then giorno = "0" & giorno
            If mese.Length = 1 Then mese = "0" & mese

            If ora.Length = 1 Then ora = "0" & ora
            If minuti.Length = 1 Then minuti = "0" & minuti
            If secondi.Length = 1 Then secondi = "0" & secondi

            If giorno < 1 Or giorno > 31 Then giorno = 1
            If mese < 1 Or mese > 12 Then mese = 1
            If ora < 1 Or ora > 23 Then ora = 1
            If minuti < 1 Or minuti > 59 Then minuti = 0
            If secondi < 1 Or secondi > 59 Then secondi = 0

            If Not isRTCdate Then anno += 2000

            If anno > 9998 Then anno = 9998

            Return New DateTime(anno, mese, giorno, ora, minuti, secondi) '//Becomes December 31, 2005 11:59:59 PM

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Private Sub CollaudoScheda_CheckedChanged(sender As Object, e As EventArgs) Handles CollaudoScheda.Click, CollaudoScheda.CheckedChanged, CollaudoScheda.CheckedChanged
        Dim b = CollaudoScheda.Checked

        CheckBoxAlimentazione.Checked = b
        CheckBoxRele.Checked = b
        CheckBox5V.Checked = b
        CheckBoxIngressi.Checked = b
        CheckBoxCAN.Checked = b
    End Sub

    Private Sub CheckBoxSelezionaTutti_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSelezionaTutti.CheckedChanged
        Dim b = CheckBoxSelezionaTutti.Checked
        CheckBoxSD.Checked = b
        CheckBoxBatteria.Checked = b
        CheckBoxSim.Checked = b
        CheckBoxAccelerometro.Checked = b
        CheckBoxPortale.Checked = b
        CheckBoxMemoria.Checked = b
        CheckBoxAlimentazione.Checked = b
        CheckBoxRele.Checked = b
        CheckBox5V.Checked = b
        CheckBoxIngressi.Checked = b
        CheckBoxCAN.Checked = b
        CheckRS232.Checked = b
    End Sub
    '                                             ----------------------------COLLAUDO CON PLC------------------------------------







    'Private Sub ComboBox2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Iniializza()
    'ComboBoxNodeID.DisplayMember = "Text"
    '    ComboBoxNodeID.Items.Add(New With {.Text = "Nodo 0", .Value = 0})
    '    ComboBoxNodeID.Items.Add(New With {.Text = "Nodo 1", .Value = 1})
    '    ComboBoxNodeID.Items.Add(New With {.Text = "Nodo 2", .Value = 10})
    '    ComboBoxNodeID.Items.Add(New With {.Text = "Nodo 3", .Value = 11})
    '    ComboBoxNodeID.Items.Add(New With {.Text = "Nodo 4", .Value = 100})
    '    ComboBoxNodeID.Items.Add(New With {.Text = "Nodo 5", .Value = &B101
    '    })
    '    ComboBoxNodeID.Items.Add(New With {.Text = "Nodo 6", .Value = 110})
    '    ComboBoxNodeID.Items.Add(New With {.Text = "Nodo 7", .Value = 111})
    '    ComboBoxNodeID.Items.Add(New With {.Text = "Nodo 8", .Value = 1000})
    '    ComboBoxNodeID.Items.Add(New With {.Text = "Nodo 9", .Value = 1001})


    '    ComboBoxFunctionID.DisplayMember = "text"
    '    ComboBoxFunctionID.Items.Add(New With {.Text = "SDO", .Value = &B1011})
    '    ComboBoxFunctionID.Items.Add(New With {.Text = "PDO", .Value = &B11
    '    })



    'End Sub

    'Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    '    InitializeBasicComponents()

    '    unInit_CANOPEN()
    '    Dim canChannels = getAvailableCanChannels()





    '    If init_CANOPEN(canChannels(0), TPCANOPENBaudrate.PCANOPENBAUD_500K, False) Then


    '        Dim canMsg As New TPCANOPENMsg()

    '        Dim tpCanOpen As New TPCANOPEN()

    '        tpCanOpen.node_ID = &B101
    '        tpCanOpen.funcion_ID = &B1011


    '        'Dim test As String = tpCanOpen.node_ID.ToString() & "_" & tpCanOpen.funcion_ID.ToString()

    '        ' accensione alimentazione device
    '        'canMsg.ID = (tpCanOpen.node_ID)_(tpCanOpen.funcion_ID)

    '        'canMsg.ID = &B10110000101

    '        Dim mask As Integer = &B1011_0000101

    '        Dim prova = (tpCanOpen.funcion_ID << 7 And &H780)
    '        Dim PROVA2 = (tpCanOpen.node_ID And &H7F)

    '        Dim prova3 = prova Or PROVA2

    '        canMsg.ID = prova3

    '        canMsg.LEN = 8
    '        canMsg.DATA = New Byte() {1, 0, 0, 0, 0, 0, 0, 0}

    '        sendCANMessage(canMsg)

    '        Dim List As List(Of TPCANMsg)
    '        List = ScanCANMessage(10000)

    '    Else
    '        MsgBox("Nessuna connessione tramite Peak")


    '    End If



    'End Sub
    Public Sub Iniializza()

    End Sub

    'Public Function ReciveCANMessage(Optional timeoutMilliseconds As Integer = 100) As List(Of TPCANMsg)

    '    Dim raw_msg As New TPCANMsg()
    '    Dim foundNodes As New List(Of TPCANMsg)



    '    Dim sw As New Stopwatch
    '    sw.Restart()

    '    While sw.ElapsedMilliseconds <= timeoutMilliseconds



    '        If receiveCANMessage(raw_msg) Then
    '            Dim iCOpenId = raw_msg.ID - &H5
    '            Dim mio = Convert.ToString(Int64.Parse(raw_msg.ID.ToString()), 2)             'converte il messaggio decimale ricevuto in binario 

    '            Dim mio1 = mio.Substring(0, 4)                                                 'legge le prime quattro cifre del messaggio convertito in binario 
    '            Dim mio2Dec = Convert.ToInt32(mio1, 2)                                        'le quattro cifre lette vengono convertite in decimale 

    '            If mio2Dec = ComboBoxFunctionID.SelectedItem.value Then                        'controlla che il valore decimale appena convertito sia uguale al valore del SDO
    '                Dim mio3 = Convert.ToString(Int64.Parse(raw_msg.ID.ToString()), 2)        'riconverte il numero decimale in binario 
    '                Dim mio4 = mio.Substring(4, 7)                                             'va a leggere dalla posizione 4 alla 7 le cifre del numero binario 



    '                If mio4 = ComboBoxNodeID.SelectedItem.value Then                           'controlla che le cifre appena lette siano uguali al valore del nodo selezionato 
    '                    MsgBox("Connessione via Can stabilita")

    '                Else
    '                    MsgBox("Connessione Can non stabilita, controllare che il nodo sia corretto")
    '                End If






    '                Dim a = "01010010011010101"
    '                Dim b = Convert.ToInt32(a, 2)
    '                Dim c = Convert.ToString(b, 2)


    '                'If iCOpenId >= 0 And iCOpenId <= &HF Then
    '                '    'If Not foundNodes.Contains(iCOpenId) Then
    '                '    foundNodes.Add(raw_msg)
    '                '    'End If




    '                '    MsgBox("ricevuto IDghghg " & raw_msg.ID)

    '                'End If
    '            End If
    '        End If

    '        '                                                  ------------test alimentazione--------------------
    '        If raw_msg.DATA(0) = 0 Then
    '            MsgBox("Test alimentazione fallito")
    '        Else
    '            raw_msg.DATA(0) = 1
    '            MsgBox("Test Completato")


    '        End If
    '    End While

    '    Return foundNodes


    'End Function



    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        System.Diagnostics.Process.Start("https://chat.google.com/")
    End Sub

    Private Sub ResetP90_Click(sender As Object, e As EventArgs) Handles ResetP90.Click

        RDW_CommandCollaudo("P90 0")
        'ChangeControlText(labelSerialNumber, "")
        'ChangeControlText(Label28Portale, "")
        ResetP90.Enabled = False
        Wait(1000)
        ResetP90.Enabled = True


    End Sub
    Private Sub CBConfRS232_SelectedIndexChanged(sender As Object, e As EventArgs)
        If CBConfRS232.SelectedItem = "Barcode Reader" Then

            Dim SOURCE_RS232 = CBConfRS232.SelectedIndex
            RDW_Command("W07", 138, SOURCE_RS232)
            Dim ABRS232 = 1
            RDW_Command("W07", 140, ABRS232)
            RDW_Command("L02")
            ChangeControlVisibility(BarcodeReader, True)
            ChangeControlText(LeggiCodRS232, "Leggi Barcode")

        End If
        If CBConfRS232.SelectedItem = "iButton" Then
            Dim SOURCE_RS232 = CBConfRS232.SelectedIndex
            RDW_Command("W07", 138, SOURCE_RS232)
            Dim ABRS232 = 1
            RDW_Command("W07", 140, ABRS232)
            RDW_Command("L02")
            ChangeControlVisibility(BarcodeReader, False)
            ChangeControlText(LeggiCodRS232, "Leggi UID")
        End If
    End Sub
    Public Sub LeggiCodRS232_Click_1(sender As Object, e As EventArgs)
        ChangeControlVisibility(ErrorRS232, False)

        If CBConfRS232.SelectedItem = "Barcode Reader" Then
            Dim Barcode = RDW_Command("R71", 2)
            ChangeControlText(LabelCodRS232, "(" + Barcode.ToString() + ")")
            If LabelCodRS232.Text = "(00012345)" Then
                ChangeControlVisibility(BarcodeReader, False)
            End If
        End If


        If CBConfRS232.SelectedItem = "iButton" Then
            Dim Ibutton = RDW_Command("R71", 1)
            ChangeControlText(LabelCodRS232, "(" + Ibutton.ToString() + ")")
        End If
    End Sub


    Private Sub CollaudoETSONE_Close(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        statoCollaudoEtsone.RequestToStopTest = True
        ProgressBarTest.Enabled = False
        Wait(100)
    End Sub

    Private Sub OpenLog_Click(sender As Object, e As EventArgs) Handles OpenLog.Click
        Process.Start(Application.StartupPath + "\Log")
    End Sub
    Private Sub ButtonErrorView_Click(sender As Object, e As EventArgs) Handles ButtonErrorView.Click
        Process.Start(Application.StartupPath & "\\log\\EtsOne\\LogPDF\\" & labelSerialNumber.Text & ".pdf")
    End Sub

    Private Sub Collaudo_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Windows.Forms.Keys.Space Then
            ButtonStartTest.PerformClick()
        End If
    End Sub

    Private Sub ErrorInfo_Click(sender As Object, e As EventArgs) Handles ErrorInfo.Click
        Process.Start(Application.StartupPath + "\\Log\\gestioneErrori.txt")
    End Sub

End Class

Class ClasseStatusTest
    Public VERSIONECONNESSA As UInteger
    Public comunicazioneChecked As Boolean = False
    Public idDevice As String = ""
    Public deviceSerial As String = ""
    Public idAsset As String = ""
    Public importaOk = False
    Public accelerometroFatto = False
    Public contolloMemory = False
    Public ABRS232 As String
    Public SOURCE_RS232 As String
    Public touch_checked = False
    Public Barcode As Boolean
    Public Ibutton As Boolean
    Public Counter = 0
    Public RequestToStopTest As Boolean = False

    Public testAlimentazioneCompleted = False
    Public testAlimentazioneStatusSuccess = False
    Public testAlimentazioneMessage = False


    Public testReleCompleted = False
    Public testReleStatusSuccess = False
    Public testReleMessage = False

    Public test5VCompleted = False
    Public test5VStatusSuccess = False
    Public test5VMessage = False

    Public testIP4Status = 0
    Public testIngressiCompleted = False
    Public testIngressiStatusSuccess = False
    Public testIngressiMessage = False

    Public testCANCompleted = False
    Public testCANStatusSuccess = False
    Public testCANMessage = False

    Public OperatorName As String = ""
    Public fsmTest = 0
    Public CloseCOM = False
    Public releTest = 0
    Public inputTest = 0
    Public analogTest = 0
    Public statoInputest = False
    Public counterPWR = 0
    Public MsgUsb = True
    Public oneTick = False
    Public counterFailTest = 0
    Public datiOnString As String
    Public NewDevice = False
    Public SameDevice = False
    Public CounterTest = 0

    Public timvalidation As New Stopwatch
    Public timerReleTest As New Stopwatch
    Public timer5Vtest As New Stopwatch
    Public timerInputTest As New Stopwatch
    Public timerAnalogTest As New Stopwatch


    '                   ----------------------------------------SOPRA MODIFICATO DA ME---------------------------------------
    Public testBadgeCompleted = False
    Public testBadgeStatusSuccess = False
    Public testBadgeMessage = False

    Public testSDCompleted = False
    Public testSDStatusSuccess = False
    Public testSDMessage = False

    Public testBatteriaCompleted = False
    Public testBatteriaStatusSuccess = False
    Public testBatteriaMessage = False

    Public testSimCompleted = False
    Public testSimStatusSuccess = False
    Public testSimMessage = False

    Public testAccelerometroCompleted = False
    Public testAccelerometroStatusSuccess = False
    Public testAccelerometroMessage = False

    Public testWifiCompleted = False
    Public testWifiStatusSuccess = False
    Public testWifiMessage = False

    Public testComunicazioneCompleted = False
    Public testComunicazioneStatusSuccess = False
    Public testComunicazioneMessage = False

    Public testSyncCompleted = False
    Public testSyncStatusSuccess = False
    Public testSyncCurrentStep = 0
    Public testSyncMessage = False

    Public testUtenzaCompleted = False
    Public testUtenzaStatusSuccess = False
    Public testUtenzaMessage = False

    Public associazioneETSDNCompleted = False
    Public associazioneETSDNSuccess = False

    Public Sub ResetTestStatus()
        VERSIONECONNESSA = 0
        comunicazioneChecked = False
        idDevice = ""
        deviceSerial = ""
        idAsset = ""
        importaOk = False
        accelerometroFatto = False
        contolloMemory = False
        ABRS232 = ""
        SOURCE_RS232 = ""
        touch_checked = False
        Barcode = False
        Ibutton = False
        Counter = 0
        datiOnString = ""

        testAlimentazioneCompleted = False
        testAlimentazioneStatusSuccess = False
        testAlimentazioneMessage = False


        testReleCompleted = False
        testReleStatusSuccess = False
        testReleMessage = False

        test5VCompleted = False
        test5VStatusSuccess = False
        test5VMessage = False

        testIP4Status = 0
        testIngressiCompleted = False
        testIngressiStatusSuccess = False
        testIngressiMessage = False

        testCANCompleted = False
        testCANStatusSuccess = False
        testCANMessage = False

        OperatorName = ""
        fsmTest = -1
        CloseCOM = False
        releTest = 0
        inputTest = 0
        analogTest = 0
        counterPWR = 0
        timvalidation.Reset()
        timerReleTest.Reset()
        timer5Vtest.Reset()
        timerInputTest.Reset()
        timerAnalogTest.Reset()
        statoInputest = False
        MsgUsb = True
        oneTick = False
        NewDevice = False
        SameDevice = False
        counterFailTest = 0
        testBadgeCompleted = False
        testBadgeStatusSuccess = False
        testBadgeMessage = False

        testSDCompleted = False
        testSDStatusSuccess = False
        testSDMessage = False

        testBatteriaCompleted = False
        testBatteriaStatusSuccess = False
        testBatteriaMessage = False

        testSimCompleted = False
        testSimStatusSuccess = False
        testSimMessage = False

        testAccelerometroCompleted = False
        testAccelerometroStatusSuccess = False
        testAccelerometroMessage = False

        testWifiCompleted = False
        testWifiStatusSuccess = False
        testWifiMessage = False

        testComunicazioneCompleted = False
        testComunicazioneStatusSuccess = False
        testComunicazioneMessage = False

        testSyncCompleted = False
        testSyncStatusSuccess = False
        testSyncCurrentStep = 0
        testSyncMessage = False

        testUtenzaCompleted = False
        testUtenzaStatusSuccess = False
        testUtenzaMessage = False

        associazioneETSDNCompleted = False
        associazioneETSDNSuccess = False
    End Sub
End Class

Public Class TestNotCompleted
    Inherits Exception

    Public Sub New()
    End Sub

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(message As String, inner As Exception)
        MyBase.New(message, inner)
    End Sub
End Class

Public Class ResultTestDoneEtsOne

    Public dateNow As String = "", serialDevice As String = ""
    Public nameTest As String = "", checked As String = "", resultTest As String = "", comment As String = ""
    Public nameOperator As String = ""

    Public Function SetResultTest(name As String, check As Boolean, result As Boolean)
        nameTest = name
        checked = " Checked: " & check
        resultTest = " Result test: " & result.ToString

    End Function

End Class


Public Class ReportTestPowerEtsOne
    Inherits ResultTestDoneEtsOne

    Public testPwr As String = "", errorPwr As String = ""
    Public Function SetResultPwr(Optional comment As String = "", Optional pass As Boolean = Nothing,
                                 Optional value As Double = 0, Optional valueplc As Double = 0)
        If pass Then
            testPwr = " testPOWER: " + pass.ToString
        Else
            testPwr = " testPOWER: " + pass.ToString
            errorPwr = " Error value = " + value.ToString + Environment.NewLine + comment
        End If
    End Function

    Function resetDataPower()
        testPwr = ""
        errorPwr = ""
    End Function

End Class

Public Class ReportTest5VEtsOne
    Inherits ResultTestDoneEtsOne
    Public test5V As String = "", value5V As String = ""
    Public error5V As String = ""

    Public Sub SetResult5V(Optional notpass As Boolean = Nothing, Optional comment As String = "",
                           Optional pass As Boolean = Nothing, Optional value As String = "")
        If pass Then
            test5V = " test5V: " + pass.ToString
        Else
            test5V = " test5V: " + pass.ToString
            error5V = " Error value: " + value.ToString + Environment.NewLine + comment
        End If
    End Sub

    Function ResetData5v()
        test5V = ""
        value5V = ""
        error5V = ""
    End Function
End Class

Public Class ReportTestReleEtsOne
    Inherits ResultTestDoneEtsOne
    Public testR1 As String = "", testR2 As String = ""
    Public serial As String = ""
    Public errorR1 As String = "", errorR2 As String = ""
    Public Sub SetResultRL1(Optional pass As Boolean = Nothing, Optional comment As String = "", Optional value As Double = 0, Optional value1 As Double = 0,
                            Optional erorrSerial As Boolean = False)
        If pass Then
            testR1 = " testR1: " + pass.ToString
        Else
            If Not erorrSerial Then
                testR1 = "testR1: " + pass.ToString
                errorR1 = " Erorr value: " + " R1= " + value.ToString + " R2= " + value1.ToString + Environment.NewLine + comment
            Else
                testR1 = " testR1: " + pass.ToString
                errorR2 = "Can't open/close rele1"
            End If
        End If
    End Sub
    Public Sub SetResultRL2(Optional pass As Boolean = Nothing, Optional comment As String = "", Optional value As Double = 0, Optional value1 As Double = 0,
                            Optional erorrSerial As Boolean = False)
        If pass Then
            testR2 = " testR2: " + pass.ToString
        Else
            If Not erorrSerial Then
                testR2 = " testR2: " + pass.ToString
                errorR2 = "Erorr value: " + " R2= " + value.ToString + " R1= " + value1.ToString + Environment.NewLine + comment
            Else
                testR2 = " testR2: " + pass.ToString
                errorR2 = "Can't open/close rele2"
            End If
        End If
    End Sub

    Function ResetDataRl()
        testR1 = ""
        serial = ""
        errorR1 = ""
        errorR1 = ""
        errorR2 = ""
    End Function
End Class

Public Class ReportTestInputEtsOne
    Inherits ResultTestDoneEtsOne
    Public testIP1 As String = "", testIP2 As String = "", testIP3 As String = ""
    Public errorIP1 As String = "", errorIP2 As String = "", errorIP3 As String = ""

    Public Sub SetResultIP1(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional valIp1 As String = "",
                            Optional valIp2 As String = "", Optional valIp3 As String = "")
        If pass Then
            testIP1 = " testIP1: " + pass.ToString
        Else
            testIP1 = " testIP1: " + pass.ToString
            errorIP1 = " Error value: " + " IP1= " & valIp1.ToString + " IP2= " + valIp2.ToString + " IP3= " + valIp3.ToString + Environment.NewLine + comment
        End If
    End Sub

    Public Sub SetResultIP2(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional valIp1 As String = "",
                            Optional valIp2 As String = "", Optional valIp3 As String = "")
        If pass Then
            testIP2 = " testIP2: " + pass.ToString
        Else
            testIP2 = " testIP2: " + pass.ToString
            errorIP2 = " Error value: " + " IP2= " + valIp2.ToString + " IP1= " + valIp1.ToString + " IP3= " + valIp3.ToString + Environment.NewLine + comment
        End If
    End Sub
    Public Sub SetResultIP3(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional valIp1 As String = "",
                            Optional valIp2 As String = "", Optional valIp3 As String = "")
        If pass Then
            testIP3 = " testIP3: " + pass.ToString
        Else
            testIP3 = " testIP3: " + pass.ToString
            errorIP3 = " Error value: " + " IP3= " + valIp3.ToString + " IP1=" + valIp1.ToString + " IP2=" + valIp2.ToString + Environment.NewLine + comment
        End If
    End Sub

    Function ResetDataIp()
        testIP1 = ""
        testIP2 = ""
        testIP3 = ""
        errorIP1 = ""
        errorIP2 = ""
        errorIP3 = ""
    End Function
End Class

Public Class ReportTestAnalogEtsOne
    Inherits ResultTestDoneEtsOne
    Public testIP4 As String = "", errorIP4 As String = ""
    Public Sub SetResultANA1(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional value As Double = 0)
        If pass Then
            testIP4 = " testIP4: " + pass.ToString
        Else
            testIP4 = " testIP4: " + pass.ToString
            errorIP4 = " Error value: " + value.ToString + Environment.NewLine + comment
        End If
    End Sub
End Class


Public Class ReportTestCanEtsOne
    Inherits ResultTestDoneEtsOne
    Public testCan1 As String = "", testCan2 As String = ""
    Public errorCan1 As String = "", errorCan2 As String = ""
    Function SetResultCan1(Optional pass As Boolean = Nothing, Optional value As String = "", Optional comment As String = "")
        If pass Then
            testCan1 = " testCAN1: " + pass.ToString
            errorCan1 = ""
        Else
            testCan1 = " testCAN1: " + pass.ToString
            errorCan1 = " Error value: " + "Can1= " + value.ToString + Environment.NewLine + comment
        End If
    End Function

    Function SetResultCan2(Optional pass As Boolean = Nothing, Optional value As String = "", Optional comment As String = "")
        If pass Then
            testCan2 = " testCAN2 = " + pass.ToString
            errorCan2 = ""
        Else
            testCan2 = " testCAN2 = " + pass.ToString
            errorCan2 = " Error value: " + "Can2= " + value.ToString + Environment.NewLine + comment
        End If
    End Function
    Function resetDataCan()
        testCan1 = ""
        testCan2 = ""
        errorCan1 = ""
        errorCan2 = ""
    End Function
End Class


Public Class ReportStartTest
    Public buttonStart As String = ""
    Function SetStartTest(Optional clickstart As String = "", Optional time As String = "", Optional comment As String = "")

        buttonStart = "Button Start: " + clickstart.ToString + " (" + Date.Now.ToLongTimeString + ")" + Environment.NewLine

    End Function

End Class

Public Class ReportStopTest
    Public buttonStop As String = ""
    Function SetStopTest(Optional clickstop As String = "", Optional time As String = "", Optional comment As String = "")

        buttonStop = "Button Stop: " + clickstop.ToString + " (" + Date.Now.ToLongTimeString + ")" + Environment.NewLine

    End Function
End Class

Public Class ReportEndTest
    Public endTest As String = "● ● ● ● ● ● ● ● ● ● ● ● ● ● ● ● End test ● ● ● ● ● ● ● ● ● ● ● ● ● ● ● ●"

End Class

Public Class ReportInfoTestEtsOne
    Public sn As String = "", dayn As String = "", line As String = "", namePortal As String = "", nameOperator As String = ""
    Function SetInfoTest(Optional serial As String = "", Optional day As String = "", Optional title As String = "", Optional portal As String = "",
                         Optional name As String = "")
        sn = serial.ToString
        dayn = day
        line = title.ToString
        namePortal = portal.ToString
        nameOperator = name.ToString
    End Function
End Class
Public Class WriteReporEtsOne
    Inherits ResultTestDoneEtsOne
    Public path = Application.StartupPath & "\\log\\EtsOne\\"
    Public writeText

    Public Function OpenTextFile(a As ReportInfoTestEtsOne)
        Try
            writeText = My.Computer.FileSystem.OpenTextFileWriter(path & a.sn, True)
        Catch ex As Exception

        End Try
    End Function

    Public Function CloseTextFile()
        writeText.close()
    End Function

    Public Function WriteOnFile(a As ReportInfoTestEtsOne)
        Try
            writeText.WriteLine(a.line)
            writeText.WriteLine(a.dayn)
            writeText.WriteLine(a.nameOperator)
            writeText.WriteLine(a.sn)
            writeText.WriteLine(a.namePortal)
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try

    End Function
    Public Function WriteOnFile(a As ReportTestPowerEtsOne)

        Try
            If a.checked.Contains(True) Then
                If a.errorPwr = Nothing Or a.errorPwr = "" Then
                    writeText.WriteLine(a.nameTest & a.checked)
                    writeText.WriteLine(a.testPwr)
                    writeText.WriteLine(a.resultTest & Environment.NewLine)
                Else
                    writeText.WriteLine(a.nameTest & a.checked)
                    writeText.WriteLine(a.testPwr)
                    writeText.WriteLine(a.errorPwr)
                    writeText.WriteLine(a.resultTest & Environment.NewLine)
                End If
            Else
                writeText.WriteLine(a.nameTest & a.checked & Environment.NewLine)
            End If
            a.resetDataPower()
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportTest5VEtsOne)
        Try
            If a.checked.Contains(True) Then
                If a.error5V = Nothing Or a.error5V = "" Then
                    writeText.WriteLine(a.nameTest & a.checked)
                    writeText.WriteLine(a.test5V)
                    writeText.WriteLine(a.resultTest & Environment.NewLine)
                Else
                    writeText.WriteLine(a.nameTest & a.checked)
                    writeText.WriteLine(a.test5V)
                    writeText.WriteLine(a.error5V)
                    writeText.WriteLine(a.resultTest & Environment.NewLine)
                End If
            Else
                writeText.WriteLine(a.nameTest & a.checked & Environment.NewLine)
            End If
            a.ResetData5v()
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportTestReleEtsOne)

        Try

            If a.checked.Contains(True) Then
                writeText.WriteLine(a.nameTest & a.checked)
                writeText.WriteLine(a.testR1)
                writeText.WriteLine(a.errorR1)
                writeText.WriteLine(a.testR2)
                writeText.WriteLine(a.errorR2)
                writeText.WriteLine(a.resultTest & Environment.NewLine)
            Else
                writeText.WriteLine(a.nameTest & a.checked & Environment.NewLine)
            End If
            a.ResetDataRl()
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportTestInputEtsOne, b As ReportTestAnalogEtsOne)
        Try
            If a.checked.Contains(True) Then
                writeText.WriteLine(a.nameTest & a.checked)
                writeText.WriteLine(a.testIP1)
                writeText.WriteLine(a.errorIP1)
                writeText.WriteLine(a.testIP2)
                writeText.WriteLine(a.errorIP2)
                writeText.WriteLine(a.testIP3)
                writeText.WriteLine(a.errorIP3)
                writeText.WriteLine(b.testIP4)
                writeText.WriteLine(b.errorIP4)
                writeText.WriteLine(a.resultTest & Environment.NewLine)
            Else
                writeText.WriteLine(a.nameTest & a.checked & Environment.NewLine)
            End If
            a.ResetDataIp()
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportTestCanEtsOne)

        Try
            If a.checked.Contains(True) Then
                writeText.WriteLine(a.nameTest & a.checked)
                writeText.WriteLine(a.testCan1)
                writeText.WriteLine(a.errorCan1)
                writeText.WriteLine(a.testCan2)
                writeText.WriteLine(a.errorCan2)
                writeText.WriteLine(a.resultTest & Environment.NewLine)
            Else
                writeText.WriteLine(a.nameTest & a.checked & Environment.NewLine)
            End If
            a.resetDataCan()
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportStartTest)
        Try
            writeText.WriteLine(a.buttonStart)
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportStopTest)
        Try
            If a.buttonStop.Contains(True) Then
                writeText.WriteLine(a.buttonStop)
            End If
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportEndTest)
        Try
            writeText.WriteLine(a.endTest & Environment.NewLine)
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function ExportFileData(a As ReportInfoTestEtsOne)

        Try
            Dim line As String
            Dim readFile As TextReader = New StreamReader(Application.StartupPath & "\\log\\EtsOne\\" & a.sn)
            Dim yPoint As Integer = 0
            Dim pdf As PdfDocument = New PdfDocument
            pdf.Info.Title = "Text File to PDF"
            Dim pdfPage As PdfPage = pdf.AddPage()
            Dim graph As XGraphics = XGraphics.FromPdfPage(pdfPage)
            Dim font As XFont = New XFont("Verdana", 10, XFontStyle.Regular)

            While True
                line = readFile.ReadLine
                If line Is Nothing Then
                    Exit While
                Else
                    graph.DrawString(line, font, XBrushes.Black,
                    New XRect(8.27, yPoint, pdfPage.Width.Inch, pdfPage.Height.Inch), XStringFormats.TopLeft)
                    yPoint = yPoint + 11.69
                    If yPoint = 840 Then
                        pdfPage = pdf.AddPage
                        graph = XGraphics.FromPdfPage(pdfPage)
                        yPoint = 0
                    End If
                End If
            End While


            Dim pdfFilename As String = Application.StartupPath & "\\log\\EtsOne\\LogPDF\\" & a.sn & ".pdf"
            pdf.Save(pdfFilename)
            readFile.Close()
            readFile = Nothing
            'Process.Start(pdfFilename)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

End Class



'dimeticatoio 
'tentativo di spegnere l'alimentazione della porta USB su un dispositivo, purtroppo non funzionante 
'4 = disattiva 3 = attiva 

'Dim Str As String = My.Computer.Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Services\USBSTOR").ToString
'Registry.SetValue(Str, "Start", 3)
'Registry.SetValue(Str, "Start", 4)


'Dim OldDate As String = SearchFile(Application.StartupPath & "\\log\\" & refreshSN(), Date.Today.ToLongDateString)
'If OldDate = Date.Today.ToLongDateString Then
'reportInfo.SetInfoTest(serial:=refreshSN, portal:=Label28Portale.Text)
'Else


