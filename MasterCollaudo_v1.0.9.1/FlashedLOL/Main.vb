Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Net.Sockets
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Globalization
Imports System.Management
Imports System.Management.Instrumentation
Imports ADOX
Imports System.Data.OleDb
Imports Newtonsoft.Json
Imports System.Xml
Imports System.Timers
Imports System.Web.Script.Serialization
Imports MongoDB.Driver
Imports MongoDB.Bson
Imports FlashedLOL.Peak.Can.Basic


' CAN con Peak: 
'   - Aggiunta libreria CANBasic
'   - Aggiunto file CAN.vb
'   - Da LECU vedere in CAN.vb riga 691: init_CAN

Public Class Main
    Public Nomecollauder As String
    Public Shared APP_VERSION As String = "2021.10.12.003"

    Public collaudoIstance As Collaudo = Nothing
    Private Shared collaudoOpened = False
    Private Shared collaudoETSDNopened = False

    Private myUID As String = Now.Ticks

    Public prediction As Prediction
    Public selectedGRSat As GRSat
    Public Shared instance As Main
    Private newSerialUnsaved As Boolean = False
    'Private Shared processOutput As StringBuilder = Nothing
    Public Const GRCONF As Integer = 129792
    'Public Const RemoteLOLPort As Integer = 7007

    Private serialPortsCheckTimer As System.Timers.Timer
    Private soundTimer As System.Timers.Timer
    Dim availableSerialPorts As String() = {}

    Public connectedDeviceInfo As DeviceInfo = Nothing

    Shared inCP210Action = False


    Private Declare Auto Function CP210x_GetNumDevices Lib "CP210xManufacturing.dll" (ByRef lpdwNumDevices As UInteger) As Short
    Private Declare Auto Function CP210x_GetProductString Lib "CP210xManufacturing.dll" (ByVal dwDeviceNum As UInteger, ByVal lpvDeviceString() As Byte, ByVal dwFlags As UInteger) As Integer
    Private Declare Auto Function CP210x_GetPartNumber Lib "CP210xManufacturing.dll" (ByVal cyHandle As UInt32, ByRef lpbPartNum As Byte) As Integer
    Private Declare Auto Function CP210x_GetDeviceProductString Lib "CP210xManufacturing.dll" (ByVal cyHandle As Long, ByRef lpProduct As Byte, ByRef bLength As Long) As Integer
    Private Declare Auto Function CP210x_Open Lib "CP210xManufacturing.dll" (ByVal dwDevice As UInteger, ByRef cyHandle As UInteger) As Integer
    Private Declare Auto Function CP210x_GetDeviceSerialNumber Lib "CP210xManufacturing.dll" (ByVal Handle As UInteger, ByVal SerialNumber() As Byte, ByRef Length As Byte, ByVal ConvertToASCII As Boolean) As Integer
    Private Declare Auto Function CP210x_GetDeviceProductString Lib "CP210xManufacturing.dll" (ByVal Handle As UInteger, ByVal SerialNumber() As Byte, ByRef Length As Byte, ByVal ConvertToASCII As Boolean) As Integer
    Private Declare Auto Function CP210x_Close Lib "CP210xManufacturing.dll" (ByVal Handle As UInteger) As Integer
    Private Declare Auto Function CP210x_Reset Lib "CP210xManufacturing.dll" (ByVal Handle As UInteger) As Integer

    Private Declare Auto Function CP210x_SetProductString Lib "CP210xManufacturing.dll" (ByVal Handle As UInteger, ByRef SerialNumber As Byte, ByVal Length As UInt32, ByVal ConvertToASCII As Boolean) As Integer
    Private Declare Auto Function CP210x_SetSerialNumber Lib "CP210xManufacturing.dll" (ByVal Handle As UInteger, ByRef Product As Byte, ByVal Length As UInt32, ByVal ConvertToASCII As Boolean) As Integer



    Dim STOPALL As Boolean = False, errorFlashing As Boolean = False


    Public cloudCodeLocation As Integer = -1
    Public cloudPswLocation As Integer = -1
    Public anagraficaSerialLocation As Integer = -1

    Dim Messaggio As TPCANMsg
    Dim serialnumber As String
    Public MDTTensioneInterna, MDTTensioneEsterna, Pitch, Roll, Accelerazione, Inclinazione, Direzione As Double
    Public SegnaleGPRS, MDTRpm As Integer
    Public MDTIO(12) As String
    Public SD_FREE, MODEM_ST, CURRENT_PROFILE, GSM_ST, GPRS_SE, GPSS, FIXS, SIM_ST, ACC_ST As String
    Public FixsAccel As Boolean
    Dim formload As Boolean = False
    Dim mdtTimeout As Long

    Dim serialiDaRecuperare As New List(Of String)

    'Private remoteLOListener As UDPListener = Nothing
    Private systemStatus As String = "Starting up", freshSerial As String = ""
    Private iNeedFreshSerial As Boolean = False

    Private confirmed_device As String = "", confirmed_HW As String = "", confirmed_Serial As String = ""
    Private currentLabelData As String = "", current_usb_vid As String = "", current_usb_pid As String = ""

    Dim s As New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
    'Dim ep As New IPEndPoint(IPAddress.Broadcast, RemoteLOLPort)

    Dim form_opening As Boolean = True
    Dim forceAutoNext As Boolean = False

    Private bufferEtichette As New List(Of etichetta)
    Dim item = 0
    Dim comunicazioneCheked = False
    Dim cmd_cloudCfg_httphost As String = ""
    Dim cmd_cloudCfg_ftphost As String = ""
    Dim cmd_cloudCfg_ftpuser As String = ""
    Dim cmd_cloudCfg_ftppasw As String = ""

    Dim boot_speed = 115200
    Public main_speed = 115200
    Dim _CP210xSerial = "not_set"

    Dim current_fwbt_version = ""
    Dim current_fwmain_version = ""
    Dim current_config_stock = ""
    Dim current_config_otg = ""
    Dim current_anagrafica_cmd = ""
    Dim current_test_result As New Specialized.NameValueCollection
    Dim current_mongo_id As String = ""
    Dim istanzaDevice = New UsbDevice
    Dim passmig As String
    Dim usermig As String
    Dim hostmig As String
    Dim trovaPortale = 0
    ' Dim tendinaUntouched = True
    Dim kiwisat As GRSat 'Test
    Dim loginok = False
    Dim riscriviSerial = 0
    Dim AggiornamentoScritturaSeriali
    Dim deviceProfiles = New ArrayList()
    Dim programmingPort = ""
    Dim programminginProgress = False

    Class etichetta
        Public MODEL_NAME As String
        Public MODEL_CODE As String
        Public MODEL_DESC As String
        Public SERIAL As String
        Public DC_IN As String
        Public mA_IN As String
        Public CE_YEAR As String
    End Class

    Enum MCU
        NXP1759
        NXP1754
    End Enum

    Private Delegate Sub UI_UpdateAvailableSerialPortsDelegate()
    Private Sub UI_UpdateAvailableSerialPorts()
        If Me.InvokeRequired Then
            Me.Invoke(New UI_UpdateAvailableSerialPortsDelegate(AddressOf UI_UpdateAvailableSerialPorts), New Object() {})
            Return
        End If

        DropdownComPorts.Items.Clear()
        If Not DropdownDevicesProfiles.Text = "-- Non selezionato --" And Not DropdownDevicesProfiles.Text = "ETSDN" Then

            For Each port As String In availableSerialPorts
                DropdownComPorts.Items.Add(port)

                If availableSerialPorts.Count > 1 Then
                    DropdownComPorts.Font = New Font(DropdownComPorts.Font, FontStyle.Bold)
                    DropdownComPorts.ForeColor = Color.Red
                Else
                    DropdownComPorts.Font = New Font(DropdownComPorts.Font, FontStyle.Regular)
                    DropdownComPorts.ForeColor = Color.Black
                End If
            Next

        End If

    End Sub

    Private Delegate Sub UI_UpdateCBVidPidSNDelegate(ps As String())
    Private Sub UI_UpdateCBVidPidSND(ps As String())
        If Me.InvokeRequired Then
            Me.Invoke(New UI_UpdateCBVidPidSNDelegate(AddressOf UI_UpdateCBVidPidSND), New Object() {ps})
            Return
        End If

        CBVidPidSN.Items.Clear()
        For Each s As String In ps
            CBVidPidSN.Items.Add(s)
        Next
    End Sub

    Private Delegate Sub UI_UpdateSerialPortInUseDelegate(port As String)
    Private Sub UI_UpdateSerialPortInUse(port As String)
        If Me.InvokeRequired Then
            Me.Invoke(New UI_UpdateSerialPortInUseDelegate(AddressOf UI_UpdateSerialPortInUse), New Object() {port})
            Return
        End If

        DropdownComPorts.SelectedItem = port
    End Sub

    Private Delegate Sub UI_UpdateCBVidPidSNSelectedDelegate(val As String)
    Private Sub UI_UpdateCBVidPidSNSelected(val As String)
        If Me.InvokeRequired Then
            Me.Invoke(New UI_UpdateCBVidPidSNSelectedDelegate(AddressOf UI_UpdateCBVidPidSNSelected), New Object() {val})
            Return
        End If

        CBVidPidSN.SelectedItem = val
    End Sub

    Private Delegate Sub UI_UpdateDeviceSerialDelegate(serial As String)
    Private Sub UI_UpdateDeviceSerial(serial As String)
        If Me.InvokeRequired Then
            Me.Invoke(New UI_UpdateDeviceSerialDelegate(AddressOf UI_UpdateDeviceSerial), New Object() {serial})
            Return
        End If

        'If serial Is Nothing Or serial.Equals("") Then serial = "0"

        TextboxSerialNumber.Text = serial
    End Sub

    Private Delegate Sub UI_ChangeControlTextDelegate(ByVal ctrl As Control, ByVal text As String)
    Private Sub UI_ChangeControlText(ByVal ctrl As Control, ByVal text As String)
        If Me.InvokeRequired Then
            Me.Invoke(New UI_ChangeControlTextDelegate(AddressOf UI_ChangeControlText), New Object() {ctrl, text})
            Return
        End If
        ctrl.Text = text
    End Sub

    Private Delegate Sub UI_ChangeControlCBSelectedDelegate(ByVal ctrl As ComboBox, ByVal text As String)
    Private Sub UI_ChangeControlCBSelected(ByVal ctrl As ComboBox, ByVal text As String)
        If Me.InvokeRequired Then
            Me.Invoke(New UI_ChangeControlCBSelectedDelegate(AddressOf UI_ChangeControlCBSelected), New Object() {ctrl, text})
            Return
        End If

        If text Is Nothing OrElse Not ctrl.Items.Contains(text) Then
            ctrl.SelectedIndex = 0
        Else
            ctrl.SelectedItem = text
        End If
    End Sub

    Private Delegate Sub UI_ChangeControlEnabledDelegate(ByVal ctrl As Control, ByVal enabled As Boolean)
    Private Sub UI_ChangeControlEnabled(ByVal ctrl As Control, enabled As Boolean)
        If Me.InvokeRequired Then
            Me.Invoke(New UI_ChangeControlEnabledDelegate(AddressOf UI_ChangeControlEnabled), New Object() {ctrl, enabled})
            Return
        End If

        ctrl.Enabled = enabled
    End Sub

    Private Delegate Sub UI_ChangeDeviceProfilesSelectedDelegate(ByVal text As String)
    Private Sub UI_ChangeDeviceProfilesSelected(ByVal text As String)
        If Me.InvokeRequired Then
            Me.Invoke(New UI_ChangeDeviceProfilesSelectedDelegate(AddressOf UI_ChangeDeviceProfilesSelected), New Object() {text})
            Return
        End If

        Try
            If text Is Nothing OrElse Not DropdownDevicesProfiles.Items.Contains(text) Then
                If DropdownDevicesProfiles.SelectedIndex = 0 Then
                    SetupConnectedDevice()
                Else
                    DropdownDevicesProfiles.SelectedIndex = 0
                End If
            Else
                If DropdownDevicesProfiles.SelectedItem = text Then
                    SetupConnectedDevice()
                Else
                    DropdownDevicesProfiles.SelectedItem = text
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Function getConnectedDeviceInfo()
        ' Deve essere chiamata da DropdownDevicesProfiles_SelectedIndexChanged in modo 
        ' tale da avere già caricato le config del profilo device selzionato

        Dim deviceInfo As DeviceInfo = Nothing

        If SerialPort.BaudRate <> main_speed Then
            If SerialPort.IsOpen Then
                SerialPort.Close()
            End If
        End If

        SerialPort.BaudRate = main_speed

        Dim counter As Integer = 0

        While counter < 2
            counter += 1

            Dim resp = RDW_Command("R00", MiaPorta:=SerialPort)
            If resp.StartsWith("Synchronized") Then
                'Device not programmed yet
                Return Nothing
            End If

            If resp.Contains("|") Then
                deviceInfo = New DeviceInfo()
                Dim respTokens = resp.Split("|")
                deviceInfo.serial = respTokens(2)
            End If

            Dim cc = RDW_Command("R0B " & cloudCodeLocation, MiaPorta:=SerialPort)
            If cc.StartsWith("Synchronized") Then
                'Device not programmed yet
                Return Nothing
            End If
            If Not cc.Equals("KO") Then
                If deviceInfo Is Nothing Then
                    deviceInfo = New DeviceInfo()
                End If

                deviceInfo.cloudCode = cc
                Exit While
            End If

            Wait(3000)
        End While

        ' Rimettere ?
        'If deviceInfo IsNot Nothing And Not TextboxCPProductString.Text.Equals("") Then
        '    If Not TextboxCPProductString.Text.EndsWith("|" & deviceInfo.serial) Then
        '        MsgBox("Attenzione!!!! Il seriale nel product string e in memoria sono differenti. Verificare prima di procedere con la programmazione")
        '    End If
        'End If

        SerialPort.Close()
        Return deviceInfo
    End Function

    Private Sub serialPortsCheckEvent(source As Object, e As ElapsedEventArgs)
        serialPortsCheckTimer.Stop()

        Try
            'If inCP210Action Then
            '    serialPortsCheckTimer.Start()
            '    Return
            'End If

            'Dim p = IO.Ports.SerialPort.GetPortNames.ToList()
            'p.Sort()
            'Dim p_array = p.ToArray

            'If SerialPort.PortName <> "UNDEF" And Not p_array.Contains(SerialPort.PortName) Then
            '    If SerialPort.IsOpen Then
            '        Console.WriteLine("Closing serial port " + SerialPort.PortName + " for device disconnected")
            '        SerialPort.Close()
            '    End If

            '    SerialPort.PortName = "UNDEF"
            '    UI_Reset()
            'End If

            'If p_array.Count <> availableSerialPorts.Count Or
            '    availableSerialPorts.Except(p_array).Count > 0 Or
            '    p_array.Except(availableSerialPorts).Count > 0 Then
            '    Console.WriteLine("Available COM ports changed: " + String.Join(",", p_array))

            '    availableSerialPorts = p_array
            '    UI_UpdateAvailableSerialPorts()

            '    If SerialPort.PortName = "UNDEF" And p_array.Count = 1 Then
            '        UI_ChangeControlEnabled(Me, False)

            '        Console.WriteLine("One found, connecting to " + p_array(0))
            '        SerialPort.PortName = p_array(0)
            '        UI_UpdateSerialPortInUse(SerialPort.PortName)

            '        Dim deviceInfo As DeviceInfo = FillCP()
            '        UI_ChangeDeviceProfilesSelected(deviceInfo.type)
            '        setSerialNumberInUI(deviceInfo.serial)
            '    End If

            'End If


            Dim p = System.IO.Ports.SerialPort.GetPortNames.ToList()
            p.Sort()
            Dim p_array = p.ToArray

            availableSerialPorts = p_array
            UI_UpdateAvailableSerialPorts()
            Wait(1000)

            If SerialPort.PortName = "UNDEF" And p_array.Count = 1 Then
                UI_UpdateSerialPortInUse(p_array(0))
                SerialPort.PortName = p_array(0)
            End If

        Catch ex As Exception
        Finally
            UI_ChangeControlEnabled(Me, True)
            serialPortsCheckTimer.Start()
        End Try
    End Sub

    Private Sub soundTimerEvent(source As Object, e As ElapsedEventArgs)
        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Exclamation)
    End Sub

    Private Delegate Sub UI_ResetDelegate()
    Private Sub UI_Reset()
        If Me.InvokeRequired Then
            Me.Invoke(New UI_ResetDelegate(AddressOf UI_Reset), New Object() {})
            Return
        End If

        If programminginProgress Then
            Return
        End If

        If soundTimer IsNot Nothing Then
            soundTimer.Stop()
        End If

        If SerialPort.IsOpen() Then
            SerialPort.Close()
        End If

        connectedDeviceInfo = Nothing

        setSerialNumberInUI("")
        TextboxCloudCode.Text = ""
        CBVidPidSN.Text = ""
        TextboxCPSerialNumber.Text = ""
        TextboxCPProductString.Text = ""
        LabelFlasingFw.Text = ""
        PBF.Value = 0
        PBFU.Value = 0
        PBConf.Value = 0
        PBSincDataOra.Value = 0

        PBAcclrmtr.Value = 0
        PBCalibrazione.Value = 0
        PBConf.Value = 0
        PBF.Value = 0
        PBFU.Value = 0
        PBHR.Value = 0

        PBGPS.Value = 0
        PBSincDataOra.Value = 0
        LInvioHR.Text = "Test completato"
        LAccelerometro.Text = "Test completato"
        LTestGPS.Text = "Test completato"
        LSincDataOra.Text = "Test completato"
        LInvioHR.Visible = False
        LAccelerometro.Visible = False
        LTestGPS.Visible = False
        LSincDataOra.Visible = False
        serialnumber = ""
        LNomeNuovoFirmware.Text = ""

        ButtonGenerateSerialNumber.Enabled = False

        TextboxSerialNumber.Select()
    End Sub

    Sub Wait(ByVal tempo)
        Dim WC As New Stopwatch

        WC.Reset()
        WC.Start()
        While WC.ElapsedMilliseconds < tempo
            Application.DoEvents()
            System.Threading.Thread.Sleep(1)
        End While
    End Sub

    Private Sub TCicloSistema_Tick(sender As System.Object, e As System.EventArgs) Handles TCicloSistema.Tick
        If (trx) Then
            PBRX.BackgroundImage = My.Resources.Res.pallina_verde
            trx -= 1
        Else
            PBRX.BackgroundImage = My.Resources.Res.pallina_grigia
        End If

        If (ttx) Then
            PBTX.BackgroundImage = My.Resources.Res.pallina_rossa
            ttx -= 1
        Else
            PBTX.BackgroundImage = My.Resources.Res.pallina_grigia
        End If
    End Sub

    Public Sub Main_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        instance = Me

        Text = "FlashedLOL                                                                                             v:" + APP_VERSION

        SerialPort.PortName = "UNDEF"
        'CheckUpdateAsync()
        Start()

        'Dim deviceInfo As DeviceInfo = FillCP()
        'setSerialNumberInUI(deviceInfo.serial)

        'SerialPort.BaudRate = 230400
        'SerialPort.PortName = "COM5"
        'SerialPort.Open()

        'InitModem()
        'setupDeviceProfile("ETSA1")

        'SerialPort.BaudRate = 115200 ' costante per tutti i device
        'SerialPort.PortName = "COM5"
        'SerialPort.Open()

        'PrepareSector(MCU.NXP1759)
        'EraseSector(MCU.NXP1759)
        'WriteSector("ETSA1", MCU.NXP1759)

        'If SerialPort.BaudRate <> boot_speed Then
        '    If SerialPort.IsOpen Then
        '        SerialPort.Close()
        '        SerialPort.BaudRate = boot_speed
        '    End If

        '    If Not SerialPort.IsOpen Then
        '        SerialPort.Open()
        '    End If
        'End If

        'DoFlashMainFirmware("ETSA1")
    End Sub


    Public Function CheckUpdateAsync()
        Dim webClient As New System.Net.WebClient
        AddHandler webClient.DownloadStringCompleted, AddressOf Downloaded
        webClient.DownloadStringAsync(New Uri("http://erp.kiwitron.it/FlashedLOL/Manifest.json"))
    End Function

    Private Function Downloaded(sender As System.Object, e As DownloadStringCompletedEventArgs)
        If e.Error Is Nothing Then
            Dim jss As New JavaScriptSerializer()
            Dim dict As Dictionary(Of String, String) = jss.Deserialize(Of Dictionary(Of String, String))(e.Result)

            If APP_VERSION >= dict("version") Then
                Start()
            Else
                Try
                    Dim p As New ProcessStartInfo
                    p.FileName = "FlahedLOLUpdater.exe"
                    p.Arguments = ""
                    Process.Start(p)
                    System.Environment.Exit(0)
                Catch ex As Exception
                    MsgBox("Impossibile effettuare l'aggiornamento: " & ex.Message)
                End Try
            End If
        Else
            MsgBox("Impossibile verificare aggiornamenti: " & e.Error.ToString())
            Start()
        End If
    End Function

    Public Sub Start()
        Try
            If My.Settings.UpdateRequired Then
                My.Settings.Upgrade()
                My.Settings.UpdateRequired = False
                My.Settings.Save()
            End If

            s.EnableBroadcast = True
            'TextBoxRemoteLOLID.Text = My.Settings.RemoteLOLID
            TextboxPredictionHost.Text = My.Settings.PredHost
            'TextboxPredictionHost.Text = "erp.local"
            TextboxPredictionUsername.Text = My.Settings.PredUn
            TextboxPredictionPassword.Text = My.Settings.PredPw
            Nomecollauder = My.Settings.PredUn

            initPWP()
            InitCube()

            If Not Directory.Exists(Application.StartupPath & "\Bootloader") Then
                Directory.CreateDirectory(Application.StartupPath & "\Bootloader")
            End If

            Dim lol = Directory.GetDirectories(Application.StartupPath & "\Bootloader")
            DropdownDevicesProfiles.Items.Clear()
            DropdownDevicesProfiles.Items.Add("-- Non selezionato --")
            For Each lil In lol
                Dim name = lil.Replace(Application.StartupPath & "\Bootloader\", "")
                DropdownDevicesProfiles.Items.Add(name)
                deviceProfiles.Add(name)

            Next
            'Dim PortaTrovata As String = "COM4"
            '  Dim fh As IntPtr = Connetti(PortaTrovata)
            If DropdownDevicesProfiles.Items.Count > 0 Then DropdownDevicesProfiles.SelectedIndex = 0

            ' Dim ret = CAN_Init(CAN_BAUD_250K, CAN_INIT_TYPE_EX)
            'Call FillCP()

            'CBCom_Click(Nothing, Nothing)

            'TBserialnumber.Value = New String(Now.Year.ToString().Substring(2, 2) & Formatta00(Now.Month) & "00001")
            'downloadSerialNumber()

            'FIXME:      serve?
            'DropdownDevicesProfiles.Select()

            'startLoLIstener()

            TextBoxTelitGPRS_Vok.Text = My.Settings.Telit_GPRS_vOk
            TextBoxTelitGPS_Vok.Text = My.Settings.Telit_GPS_vOk

            serialPortsCheckTimer = New System.Timers.Timer(1000)
            AddHandler serialPortsCheckTimer.Elapsed, AddressOf serialPortsCheckEvent
            serialPortsCheckTimer.AutoReset = False
            serialPortsCheckTimer.Enabled = True

            soundTimer = New System.Timers.Timer(3000)
            AddHandler soundTimer.Elapsed, AddressOf soundTimerEvent
            soundTimer.AutoReset = True
            soundTimer.Stop()

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            systemStatus = "Idle"
        End Try
    End Sub

    Private Sub DropdownComPorts_SelectedValueChanged(sender As System.Object, e As System.EventArgs) Handles DropdownComPorts.SelectedValueChanged
        If SerialPort.PortName = DropdownComPorts.SelectedItem Then
            Return
        End If

        SerialPort.PortName = DropdownComPorts.SelectedItem

        'UI_Reset()

        'If SerialPort.PortName <> "UNDEF" Then
        '    If SerialPort.IsOpen Then
        '        Console.WriteLine("Closing serial port " + SerialPort.PortName + " for port changed")
        '        SerialPort.Close()
        '    End If
        'End If

        'If DropdownComPorts.SelectedItem IsNot Nothing Then
        '    SerialPort.PortName = DropdownComPorts.SelectedItem
        '    Dim deviceInfo As DeviceInfo = FillCP()

        '    UI_ChangeDeviceProfilesSelected(deviceInfo.type)
        '    setSerialNumberInUI(deviceInfo.serial)
        'End If
    End Sub

    Private Sub BStart_Click(sender As System.Object, e As System.EventArgs) Handles ButtonStart.Click
        STOPALL = False
        ButtonStart.Enabled = False
        programminginProgress = True
        Dim assetId As Integer = -1

        setGRSatAssetDataUI()
        Wait(1000)

        If CheckboxWriteSerialNumber.Checked Then
            If TextboxSerialNumber.Text.Equals("") Or TextboxSerialNumber.Text.ToString().Length <> 9 Then
                MsgBox("Attenzione, inserire un numero di serie corretto")
                Return
            End If
        End If

        If CheckboxWriteCloudCode.Checked Then
            If TextboxCloudCode.Text.Length <> 5 And Not TextboxCloudCode.Text.Equals(TextboxSerialNumber.Text) Then
                MsgBox("Attenzione, inserire un cloud code corretto")
                Return
            End If
        End If

        Try
            programmingPort = SerialPort.PortName
            assetId = StartProgramming(DropdownDevicesProfiles.SelectedItem.ToString)

            AvviaTestAutomatici(assetId)
            AvviaFunzioneDivina()

            soundTimer.Start()
            MsgBox("Programmazione terminata")

        Catch ex As Exception
            MsgBox(ex.ToString())
        Finally
            ButtonStart.Enabled = True
            programminginProgress = False
        End Try
    End Sub

    Private Function StartProgramming(deviceProfile As String) As Integer
        LabelRFIDTestStatus.Text = "UID Letto: -STOP-"
        CheckboxConfigureDeviceOnGRSat.ForeColor = Color.Black
        CheckBoxTestInvioCloud.ForeColor = Color.Black
        LabelHwSetup.Text = ""
        current_test_result.Clear()

        If File.Exists(Application.StartupPath & "\loggedlog.txt") Then
            File.Delete(Application.StartupPath & "\loggedlog.txt")
        End If

        LabelStatus.Text = ""

        ButtonUpdateFile.Enabled = False

        If CheckBoxCAN.Enabled And CheckBoxCAN.Checked Then
            NodoCAN = TextBoxNodoCAN.Text
        Else
            NodoCAN = ""
        End If

        TCicloSistema.Start()

        If CheckboxWriteProductString.Enabled And CheckboxWriteProductString.Checked Then
            DoWriteManufacturingInfo(deviceProfile)
        End If

        If SerialPort.BaudRate <> 115200 Then
            If SerialPort.IsOpen Then
                SerialPort.Close()
            End If

            SerialPort.BaudRate = 115200
        End If

        If Not SerialPort.IsOpen Then
            SerialPort.Open()
        End If

        If CheckboxFlashBootloader.Enabled And CheckboxFlashBootloader.Checked Then
            DoFlashBootloader(deviceProfile)
        End If

        If SerialPort.BaudRate <> boot_speed Then
            If SerialPort.IsOpen Then
                SerialPort.Close()
                SerialPort.BaudRate = boot_speed
            End If
        End If

        If SerialPort.IsOpen Then
            SerialPort.Close()
        End If

        SerialPort.Open()

        If CheckboxFlashFirmware.Checked Then
            DoFlashMainFirmware(deviceProfile)
        End If

        SerialPort.Close()
        SerialPort.BaudRate = main_speed
        SerialPort.Open()

        checkMDTReady()

        If CheckBoxInitETS.Visible And CheckBoxInitETS.Enabled And CheckBoxInitETS.Checked Then
            DoInitETS()
        End If

        If CheckboxHWSetup.Visible And CheckboxHWSetup.Enabled And CheckboxHWSetup.Checked Then
            DoHwSetup()
        End If

        If CheckboxFlashFirmware.Checked Then
            If DropdownDevicesProfiles.SelectedItem.ToString.Contains("KiwiCall") Then
                RDW_Command("W0B", 4, DateTime.UtcNow.ToString("MMddyyyy"))
            End If
        End If

        If CheckboxCA.Enabled And CheckboxCA.Checked Then
            Dim cfg = Application.StartupPath & "\Bootloader\" & deviceProfile & "\" & ComboBoxConf.SelectedItem.ToString()
            Call LoadParametri(cfg, PBConf)
            current_config_stock = File.ReadAllText(cfg)
        End If

        If CBOTG.Checked And RBOTGNOW.Checked And File.Exists(TextBoxOTGPAth.Text) Then
            Call LoadParametri(TextBoxOTGPAth.Text, ProgressBarOTG)
            current_config_otg = File.ReadAllText(TextBoxOTGPAth.Text)
        End If

        If CheckboxWriteSerialNumber.Enabled And CheckboxWriteSerialNumber.Checked Then
            DoWriteSerialNumber()
        End If

        If CheckboxWriteCloudCode.Enabled And CheckboxWriteCloudCode.Checked Then
            DoWriteCloudCode()
        End If

        If CheckboxWriteGpsVersion.Enabled And CheckboxWriteGpsVersion.Checked And TBGPSVersion.Text.Length > 0 Then
            DoWriteGpsVersion()
        End If

        If CheckboxWriteHardwareCode.Enabled And CheckboxWriteHardwareCode.Checked And TextboxHardwareCode.Text.Length > 0 Then
            DoWriteHardwareCode()
        End If

        If CheckboxSyncDatetime.Enabled And CheckboxSyncDatetime.Checked Then
            DoSyncDatetime()
        End If

        If CheckboxFormatSD.Enabled And CheckboxFormatSD.Checked Then
            DoFormatSD()
        End If

        Dim id As Integer = -1
        If CheckboxConfigureDeviceOnGRSat.Enabled And CheckboxConfigureDeviceOnGRSat.Checked Then
            id = DoConfigureCloud()
        End If

        Return id
    End Function

    Private Sub DoWriteManufacturingInfo(deviceProfile As String)
        inCP210Action = True

        Call FillCP()

        Dim sn = TextboxCPSerialNumber.Text
        Dim prodString = TextboxCPProductString.Text

        If TextboxSerialNumber.Text.Length > 0 And TextboxHardwareCode.Text.Length > 0 Then
            If (deviceProfile.Contains("BT1") Or deviceProfile.Contains("BT2")) And TextboxSerialNumber.Text.ToString().Length > 3 Then
                prodString = "BT" & TextboxSerialNumber.Text.ToString().Substring(0, 3) & "." & TextboxHardwareCode.Text & "|" & TextboxSerialNumber.Text
                LprodString.Text = "BT" & TextboxSerialNumber.Text.ToString().Substring(0, 3) & "." & TextboxHardwareCode.Text & "|" & TextboxSerialNumber.Text

            Else
                prodString = "X000" & TextboxHardwareCode.Text & "|" & TextboxSerialNumber.Text
                LprodString.Text = "Prod: " & "X000" & TextboxHardwareCode.Text & "|" & TextboxSerialNumber.Text
            End If

        Else
            errorFlashing = True
            MsgBox("Attenzione, inserire numero di serie e versione HW corretta")
            Return
        End If

        Dim cpId As IntPtr = WriteManufacturingInfo(sn, prodString)

        CP210x_Reset(cpId)
        Wait(1500)
        CP210x_Close(cpId)
        Call FillCP()
        Wait(1000)

        If FindComWithDeviceConnected(TextboxSerialNumber.Text) Is Nothing Then
            Throw New Exception("Impossibile riconnettersi al dispositivo")
        End If

        inCP210Action = False
    End Sub

    Private Sub DoFlashBootloader(deviceProfile As String)
        Dim bootFile As String = Application.StartupPath & "\Bootloader\" & deviceProfile & "\boot.bin"
        Dim bootChecksum As String

        Try
            Using sr As StreamReader = New StreamReader(Application.StartupPath & "\Bootloader\" & deviceProfile & "\bootchecksum.txt")
                bootChecksum = sr.ReadLine()
            End Using
        Catch
            bootChecksum = ""
        End Try

        ' FIXME
        ' If Not checkaSum(bootChecksum, bootFile) Then Return

        If CheckBoxJlink.Enabled And CheckBoxJlink.Checked Then
            Dim a = DropdownDevicesProfiles.SelectedItem.ToString

            Dim loadBootloaderJLinkScript As String = Application.StartupPath & "\Bootloader\" & deviceProfile & "\load_bootloader_jlink_script.txt"

            Dim args = ""
            If deviceProfile.Contains("KiwiCall") Then
                args = " -device ATSAMR34J18 -if SWD -speed 4000 -autoconnect 1 -CommanderScript """ & loadBootloaderJLinkScript & """" ' KiwiCall
            Else
                args = " -device LPC1754 -if SWD -speed 4000 -autoconnect 1 -CommanderScript """ & loadBootloaderJLinkScript & """"
            End If

            Dim p As New System.Diagnostics.Process()
            With p.StartInfo
                .FileName = "C:\Program Files (x86)\SEGGER\JLink\JLink.exe"
                .Arguments = args
                .UseShellExecute = False
                .RedirectStandardOutput = True
                .RedirectStandardError = True
                .CreateNoWindow = False
                .WorkingDirectory = Application.StartupPath & "\Bootloader\" & deviceProfile
            End With

            p.Start()

            Dim output As String = p.StandardOutput.ReadToEnd()
            p.WaitForExit()
            If p.ExitCode <> 0 Then
                MsgBox(output)
                Throw New Exception("Errore JLink")
            End If
        Else
            If current_fwbt_version = "" Then
                current_fwbt_version = analyzeFw(File.ReadAllBytes(bootFile))
            End If

            Dim currMCU As MCU = MCU.NXP1759
            If deviceProfile.Contains("ETSDN") Or
                deviceProfile.Contains("UWB_ancora") Or
                deviceProfile.Contains("MEA") Or
                deviceProfile.Contains("MDCL") Or
                deviceProfile.Contains("LMPCL") Then
                currMCU = MCU.NXP1754
                SerialPort.Close()
            End If

            Try
                ' Try init modem: required for MDT, not required for ETS
                If Not DropdownDevicesProfiles.Text = "ETSDN" Then
                    Call InitModem()
                End If

            Catch ex As Exception
            End Try

            PrepareSector(currMCU)
            EraseSector(currMCU)
            WriteSector(deviceProfile, currMCU)
        End If
    End Sub

    Private Sub DoFlashMainFirmware(deviceProfile As String)
        Dim checksumstr As String
        Dim mainfile = Application.StartupPath & "\Bootloader\" & deviceProfile & "\Main.bin"

        Try
            Using sr As New StreamReader(Application.StartupPath & "\Bootloader\" & deviceProfile & "\mainchecksum.txt")
                checksumstr = sr.ReadLine()
            End Using
        Catch
            checksumstr = ""
        End Try

        If Not checkaSum(checksumstr, mainfile) Then
            Throw New Exception("Main firmwre checksum mismatch")
        End If

        If current_fwmain_version = "" Then
            current_fwmain_version = analyzeFw(File.ReadAllBytes(mainfile))
        End If

        Call LoadMainProgram(deviceProfile, current_fwmain_version)
    End Sub

    Private Sub DoInitETS()
        Dim success As Boolean = False
        Dim tent As Integer = 0
        While (Not success)
            Dim init_cmd = "R95"
            If DropdownDevicesProfiles.SelectedItem.ToString.Contains("ETSB") Then
                init_cmd = "R02"
            End If
            Dim risp As String = RDW_Command(init_cmd, , , , , , 5000)
            If risp.Equals("") Then
                risp = RDW_Command("P90", , 0)
                tent = 0
                If risp.Equals("GTB") Then
                    Wait(3000)
                Else
                    If tent > 4 Then
                        If MessageBox.Show("Parametri inizializzati ma riavvio fallito (P90 0 => " & risp & ")", "", MessageBoxButtons.RetryCancel) = DialogResult.Retry Then
                            success = False
                            tent = 0
                            Continue While
                        Else
                            errorFlashing = True
                        End If
                    Else
                        tent += 1
                        success = False
                        Continue While
                    End If
                End If
            Else
                If tent > 4 Then
                    If MessageBox.Show("Errore nell'inizializzazione dei parametri (" & init_cmd & " => " & risp & ")", "", MessageBoxButtons.RetryCancel) = DialogResult.Retry Then
                        success = False
                        tent = 0
                        Continue While
                    Else
                        errorFlashing = True
                    End If
                Else
                    tent += 1
                    success = False
                    Continue While
                End If
            End If
            success = True
        End While
    End Sub

    Private Sub DoHwSetup()
        Dim hwset As Integer = 0

        hwset = Math.Abs(CInt(CheckboxHwEnableSD.Checked))
        hwset = hwset Or (Math.Abs(CInt(CheckboxHwEnableGPS.Checked)) << 1)
        hwset = hwset Or (Math.Abs(CInt(CheckboxHwEnableGPRS.Checked)) << 2)
        hwset = hwset Or (Math.Abs(CInt(CheckboxHwEnableWifi.Checked)) << 3)
        hwset = hwset Or (Math.Abs(CInt(CheckboxHwEnableCartellino.Checked)) << 4)

        LabelHwSetup.Text = RDW_Command("W08", IIf(CheckBoxHWSetupMoved.Checked, GRCONF + 8, 88), hwset)
    End Sub

    Private Sub DoWriteSerialNumber()
        Dim counter As Integer = 0

WSerial:
        counter += 1
        serialnumber = TextboxSerialNumber.Text

        If serialnumber = "" Then
            serialnumber = InputBox("Inserire il serial number")
        Else
            serialnumber = TextboxSerialNumber.Text
        End If

        Dim Wserialnumber = ""
        Dim Wserialnumber2 = ""

        If DropdownDevicesProfiles.SelectedItem.ToString.Contains("EPS") Then
            Wserialnumber = RDW_Command("W06", 62140, serialnumber)
            Wserialnumber2 = Wserialnumber
        Else
            Wserialnumber = RDW_Command("W08", 1, serialnumber)
            Wserialnumber2 = RDW_Command("W08", GRCONF + 0, serialnumber)
        End If

        If CheckBoxSerialAnagrafica.Enabled And CheckBoxSerialAnagrafica.Checked Then
            If anagraficaSerialLocation > -1 Then
                Dim tri = RDW_Command("W0B", anagraficaSerialLocation, TextBoxAnalPrefix.Text & serialnumber)
                If (Not tri.ToLower().Equals("ok")) AndAlso (Not tri.Equals(TextBoxAnalPrefix.Text & serialnumber)) Then
                    MessageBox.Show("Impossibile impostare il seriale in anagrafica: W0B " & TextBoxAnalPrefix.Text & anagraficaSerialLocation & " " & serialnumber)
                    current_anagrafica_cmd = "errore - "
                End If
                current_anagrafica_cmd &= "W0B " & TextBoxAnalPrefix.Text & anagraficaSerialLocation & " " & serialnumber
            Else
                MessageBox.Show("Impossibile impostare il seriale In anagrafica, non è impostato l'offset di memoria")
                current_anagrafica_cmd = "errore - posizione di memoria non impostata"
            End If

            If CheckboxHwEnableWifi.Checked Then
                Dim tri = RDW_Command("W0B", 49075, TextBoxAnalPrefix.Text & serialnumber)
                If Not tri.Equals(TextBoxAnalPrefix.Text & serialnumber) Then
                    MessageBox.Show("Impossibile impostare il la wifi string: W0B " & TextBoxAnalPrefix.Text & anagraficaSerialLocation & " " & serialnumber)
                End If
            End If
        End If

        If (Not Wserialnumber.ToLower().Equals("ok")) AndAlso (Wserialnumber <> serialnumber Or (Wserialnumber <> Wserialnumber2)) Then
            If counter < 3 Then GoTo WSerial
            MessageBox.Show("Non sono risucito a impostare il seriale =(")
            errorFlashing = True
            ListBoxSeriali.Items.Add(serialnumber & " - Errore")
            ListBoxSeriali.TopIndex = ListBoxSeriali.Items.Count - 1
            Return
        Else
            If Not Wserialnumber.ToLower().Equals("ok") Then
                serialnumber = Wserialnumber
            End If
        End If

        If CheckBoxAutoUploadSerial.Checked Then
            ListBoxSeriali.Items.Add(serialnumber)
        Else
            ListBoxSeriali.Items.Add(serialnumber)
            newSerialUnsaved = True
        End If
        ListBoxSeriali.TopIndex = ListBoxSeriali.Items.Count - 1
    End Sub

    Private Sub DoWriteCloudCode()
        If CheckboxCreateDeviceOnGRSat.Enabled And CheckboxCreateDeviceOnGRSat.Checked Then
            writeAValue(cmd_cloudCfg_httphost, selectedGRSat.HTTPServer)
            writeAValue(cmd_cloudCfg_ftphost, selectedGRSat.FTPSrv)
            writeAValue(cmd_cloudCfg_ftpuser, selectedGRSat.FTPUser)
            writeAValue(cmd_cloudCfg_ftppasw, selectedGRSat.FTPPsw)
        End If

        writeAValue("W0B " & cloudCodeLocation, TextboxCloudCode.Text)
        writeAValue("W0B " & cloudPswLocation, TextBoxCloudPw.Text)

        Dim deviceProfileString As String = DropdownDevicesProfiles.SelectedItem.ToString()
        If CheckboxHWSetup.Checked Then
            deviceProfileString &= " X" & LabelHwSetup.Text
        End If
        Dim saveCloudCode As String = deviceProfileString & " - " & TextboxCloudCode.Text & " - "
        If Not IsNothing(selectedGRSat) Then
            saveCloudCode &= selectedGRSat.friendlyName
        End If
        If CheckboxWriteSerialNumber.Checked Then
            saveCloudCode &= " - " & TextboxSerialNumber.Text.ToString()
        End If
        ListBoxCodiciCloud.Items.Add(saveCloudCode)
    End Sub

    Private Sub DoWriteGpsVersion()
        If DropdownDevicesProfiles.SelectedItem.ToString.Contains("X19") Then
            RDW_Command("W0B", 35, TBGPSVersion.Text)
        ElseIf DropdownDevicesProfiles.SelectedItem.ToString.Contains("MDT") Then
            RDW_Command("W0B", 28, TBGPSVersion.Text)
        ElseIf DropdownDevicesProfiles.SelectedItem.ToString.Contains("ETS") Then
            RDW_Command("W0B", 131057, TBGPSVersion.Text)
        End If

        RDW_Command("L02")
    End Sub

    Private Sub DoWriteHardwareCode()
        Dim HWversion As Integer = TextboxHardwareCode.Text

        HWversion = HWversion Or (Math.Abs(CInt(CheckboxFwEnableKbd.Checked Or CheckboxFwEnableModGps.Checked)) << 16)
        HWversion = HWversion Or (Math.Abs(CInt(CheckboxFwEnableFps.Checked Or CheckboxFwEnableModSD.Checked)) << 17)
        HWversion = HWversion Or (Math.Abs(CInt(CheckboxFwEnableGPSUblox.Checked)) << 18)
        HWversion = HWversion Or (Math.Abs(CInt(CheckboxFwEnableTouch.Checked) << 18))
        HWversion = HWversion Or (Math.Abs(CInt(CheckboxFwEnable125Khz.Checked) << 19))
        HWversion = HWversion Or (Math.Abs(CInt(CheckboxFwEnable5Gh.Checked) << 20))

        RDW_Command("W08", 129796, HWversion)
        RDW_Command("L02")
        LBVersioneHW.Text = RDW_Command("R08", 129796)
    End Sub

    Private Sub DoSyncDatetime()
        Dim Data, Ora As Long
        Data = Now.Year * 65536 + Now.Month * 256 + Now.Day
        Ora = Now.Hour * 65536 + Now.Minute * 256 + Now.Second

        RDW_Command("W30", , Data & "|" & Ora & "|" & Now.DayOfWeek & "|" & Now.DayOfYear)
        PBSincDataOra.Value += 1
        LSincDataOra.Visible = True
    End Sub

    Private Sub DoFormatSD()
        Dim success As Boolean = False
        Dim tent As Integer = 0
        While (Not success) And Not STOPALL
            Dim risp = RDW_Command("F60").Split("|")
            If Not IsNothing(risp) AndAlso risp.Length > 1 AndAlso risp(1) <> 1 Then
                If tent > 4 Then
                    If MessageBox.Show("Formattazione della SD fallita", "", MessageBoxButtons.RetryCancel) = DialogResult.Retry Then
                        success = False
                        tent = 0
                        Continue While
                    Else
                        errorFlashing = True
                    End If
                Else
                    tent += 1
                    success = False
                    Wait(250)
                    Continue While
                End If
            End If
            success = True
        End While
    End Sub

    Private Function DoConfigureCloud() As Integer
        Dim id As Integer = creaAsset()

        Return id
    End Function

    Private Sub AvviaTestAutomatici(assetId As Integer)
        If CBTestHR.Checked Then
            Call CheckHR()
        End If

        If CBTestGPS.Checked Then
            Call TestGPS()
        End If

        If CBTestAccel.Checked Then
            Call TestAccelerometro()
        End If

        If CBCalibrazione.Checked And Not STOPALL Then
            Call CalibrazioneAutomatica()
        End If

        If CheckBoxClearAllarmi.Checked And CheckBoxClearAllarmi.Enabled Then
            CancellaAllarmi()
        End If

        RDW_Command("L02")
        Wait(100)
        Dim risposta = RDW_Command("R00")

        If CheckboxHwEnableWifi.Checked And CheckboxHwEnableWifi.Enabled And CheckboxHwEnableWifi.Visible Then
            Dim _moduleVers = RDW_Command("RW3")
        End If

        If CBOTG.Checked And RBOTGLAST.Checked And File.Exists(TextBoxOTGPAth.Text) And Not STOPALL Then
            Call LoadParametri(TextBoxOTGPAth.Text, ProgressBarOTG)
        End If

        If CheckBoxTestInvioCloud.Enabled And CheckBoxTestInvioCloud.Checked Then
            If assetId < 0 Then
                assetId = "0" & InputBox("Inserire l'assetId")
            End If
            If assetId >= 0 Then
                Dim canceltest As Boolean = False

                If TypeOf selectedGRSat Is GRSatBonatti Then
                    While Not CType(selectedGRSat, GRSatBonatti).testInvio(assetId, 10)
                        CheckBoxTestInvioCloud.ForeColor = Color.Red
                        If MessageBox.Show("Test di invio a web fallito", "Invio a web", MessageBoxButtons.RetryCancel) = DialogResult.Cancel Then
                            canceltest = True
                            Exit While
                        End If
                        CheckBoxTestInvioCloud.ForeColor = Color.Yellow
                    End While
                    If Not canceltest Then
                        CheckBoxTestInvioCloud.ForeColor = Color.Green
                    End If
                Else
                    While Not selectedGRSat.testInvio(assetId, 10)
                        CheckBoxTestInvioCloud.ForeColor = Color.Red
                        If MessageBox.Show("Test di invio a web fallito", "Invio a web", MessageBoxButtons.RetryCancel) = DialogResult.Cancel Then
                            canceltest = True
                            Exit While
                        End If
                        CheckBoxTestInvioCloud.ForeColor = Color.Yellow
                    End While
                    If Not canceltest Then
                        CheckBoxTestInvioCloud.ForeColor = Color.Green
                    End If
                End If

            End If
        End If

        If CheckBoxRFIDTest.Checked And GroupBoxRFIDTest.Enabled Then
            TabControlMigrazione.SelectedTab = TabPageTestAutomatici
            current_test_result.Add("RFID", performRFIDTest())
        End If

        If CheckBoxLEDTest.Checked And GroupBoxLEDTest.Enabled Then
            TabControlMigrazione.SelectedTab = TabPageTestAutomatici
            current_test_result.Add("LEDS", doLedTest())
        End If

        If CheckBoxGPRSTest.Checked And GroupBoxGPRSTest.Enabled Then
            TabControlMigrazione.SelectedTab = TabPageTestAutomatici
            current_test_result.Add("GPRS", performGPRSTest())
        End If

        If CheckBoxTelitVTest.Checked And Not STOPALL Then
            TabControlMigrazione.SelectedTab = TabPageTestAutomatici
            current_test_result.Add("TELIT", performTelitTest())
        End If

        If CheckBoxSendMongo.Checked Then
            If Not commitDeviceCraft() Then
                mongoError()
            End If
        End If

        LabelStatus.Text = risposta
    End Sub

    Private Sub AvviaFunzioneDivina()
        If NumericUpDownValoriCount.Value > 0 And Not STOPALL Then
            For i = 0 To FlowLayoutPanelComando.Controls.Count - 1
                Try
                    If STOPALL Then Exit For
                    Dim comando = FlowLayoutPanelComando.Controls.Find("TBCMD_" & i.ToString(), False)(0).Text
                    Dim offset = FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & i.ToString(), False)(0).Text
                    Dim valueTB As TextBox = FlowLayoutPanelValue.Controls.Find("TBVAL_" & i.ToString(), False)(0)
                    Dim value = valueTB.Text
                    Dim valueOk As Boolean

                    If value.Equals("$GET_UID$") Then
                        value = "00000000"
                        valueTB.ForeColor = Color.Purple
                        TabControlMigrazione.SelectedTab = TabPage2
                        While (Not STOPALL) And (value.Equals("00000000") Or value.Equals("ERROR"))
                            valueTB.Text = "Passare un badge..."
                            value = getCurrentUID()
                            Wait(500)
                        End While
                        valueOk = Not (value.Equals("00000000") Or value.Equals("ERROR"))
                        If valueOk Then
                            value = Convert.ToInt64(value, 16)
                            Dim write = RDW_Command(comando, offset, value)
                            valueOk = write.Equals(value)
                        End If
                        valueTB.Text = "$GET_UID$"
                    Else
                        valueTB.Text = RDW_Command(comando, offset, value)
                        valueOk = (valueTB.Text = value)
                    End If

                    If valueOk Then
                        valueTB.ForeColor = Color.Green
                    Else
                        valueTB.ForeColor = Color.Red
                    End If

                Catch ex As Exception
                    errorFlashing = True
                    MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
                End Try
            Next
        End If
    End Sub

    Private Sub addEtichettaFromCurrentSerial()
        Dim data = currentLabelData.Split("~")
        If data.Length >= 6 Then
            addEtichettaRaw(data(0), data(2), data(1), TextboxSerialNumber.Text, data(3), data(4), data(5))
        End If
    End Sub


    Private Sub writeAValue(cmd As String, value As String)
        Dim success As Boolean = False
        Dim tent As Integer = 0
        While (Not success) And Not STOPALL
            cmd = cmd.TrimStart("$")
            Dim pisp = RDW_Command(cmd, value)
            If Not pisp = value Then
                If tent < 10 Then
                    success = False
                    tent += 1
                    Wait(500)
                    Continue While
                Else
                    If MessageBox.Show("Errore nello scrivere la configurazione cloud" & vbCrLf & cmd & " " & value, "", MessageBoxButtons.RetryCancel) = DialogResult.Retry Then
                        tent = 0
                        success = False
                        Continue While
                    Else
                        errorFlashing = True
                    End If
                End If
            End If
            success = True
        End While
    End Sub

    Sub clearFunzioneDivinaColors()
        For i = 0 To FlowLayoutPanelComando.Controls.Count - 1
            Try
                Dim valueTB As TextBox = FlowLayoutPanelValue.Controls.Find("TBVAL_" & i.ToString(), False)(0)
                valueTB.ForeColor = Color.Black
            Catch ex As Exception
                MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
            End Try
        Next
    End Sub

    Dim startnext As Boolean = False
    Private Sub InitModem()
        Dim risposta As String = ""
        Dim i = 0

        While True
            i = i + 1

            Try
                SerialPort.WriteLine("?")
                risposta = SerialPort.ReadLine

                If risposta.EndsWith("Synchronized" & vbCr & "") Then
                    Exit While
                ElseIf i > 2 Then
                    Throw New Exception("Errore risposta al comando '?' in InitModem")
                End If
            Catch ex As Exception
                If i > 2 Then
                    Throw New Exception("Errore risposta al comando '?' in InitModem")
                End If
            End Try

            Wait(2000)
        End While

        SerialPort.WriteLine("Synchronized")

        risposta = SerialPort.ReadLine

        risposta = SerialPort.ReadLine
        If risposta <> "OK" & vbCr & "" Then
            Throw New Exception("Impossibile sincronizzarsi con il dispositivo")
        End If

        Do
            SerialPort.Write("A 0" & vbCrLf)
            SerialPort.Write("A 0" & vbCrLf)
            risposta = SerialPort.ReadLine
            If risposta = "0" & vbCr & "" And SerialPort.BytesToRead <> 0 Then Exit Do

        Loop While SerialPort.BytesToRead

        SerialPort.Write("B 115200 1" & vbCrLf)


        risposta = SerialPort.ReadLine

        Wait(100)

    End Sub

    Private Sub PrepareSector(MCU As MCU)
        Dim risposta As String
        SerialPort.Write("U 23130" & vbCrLf)
        risposta = SerialPort.ReadLine()

        Select Case (MCU)
            Case MCU.NXP1759
                SerialPort.Write("P 0 29" & vbCrLf)
            Case MCU.NXP1754
                SerialPort.Write("P 0 17" & vbCrLf)
        End Select
        risposta = SerialPort.ReadLine()

        Wait(100)
    End Sub

    Private Sub EraseSector(MCU As MCU)
        Dim risposta As String

        Select Case (MCU)
            Case MCU.NXP1759
                SerialPort.Write("E 0 29" & vbCrLf)
            Case MCU.NXP1754
                SerialPort.Write("E 0 17" & vbCrLf)
        End Select

        risposta = SerialPort.ReadLine
        SerialPort.Write("U 23130" & vbCrLf)
        risposta = SerialPort.ReadLine
        Wait(100)
    End Sub


    Public Sub CancellaAllarmi()
        RDW_Command("W74")
        RDW_Command("L02")
    End Sub


    Private Sub WriteSector(deviceProfile As String, MCU As MCU)
        Try


            Call LeggiFirmware(Application.StartupPath & "\Bootloader\" & deviceProfile & "\Boot.bin")



            Dim tosend As String = ""




            SerialPort.DiscardInBuffer()
            Dim Pagina As Integer = 0
            Dim risposta As String
            Dim righe As String = ""
            Dim totrighe As Integer = 0
            Dim stringa As String = ""
            Dim divisore As Integer = 0
            Dim ncks As Integer = 0


            PBF.Maximum = indice / 24 + 1
            Wait(200)
            For i As Integer = 0 To indice - 1 Step +24
                PBF.Value += 1
                SerialPort.DiscardInBuffer()

                SerialPort.WriteLine("W " & 268435968 & " 512")
                risposta = SerialPort.ReadLine()
                Wait(100)
                If Not risposta.Contains("0") Then
                    MsgBox("Errore flash")
                End If
Resend1:
                SerialPort.DiscardInBuffer()
                SerialPort.Write("M" & CBFirmware(i) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 1) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 2) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 3) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 4) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 5) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 6) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 7) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 8) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 9) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 10) & vbCr)
                SerialPort.Write("1" & CBFirmware(i + 11) & vbCr)

                SerialPort.Write(Checksum(ncks) & vbCr)


                risposta = SerialPort.ReadLine()
                If Not risposta.Contains("OK") Then
                    GoTo Resend1
                End If
                ncks += 1



                If CBFirmware(i + 12) = Nothing Then
                    SerialPort.Write("P " & 0 & " " & 29 & vbCr)

                    risposta = SerialPort.ReadLine()

                    SerialPort.Write("C " & Pagina * 1024 & " " & 268435968 & " " & 512 & vbCr)

                    risposta = SerialPort.ReadLine()
                    Pagina += 1
                    Exit For
                End If

                SerialPort.WriteLine("W " & 268436480 & " 512")
                risposta = SerialPort.ReadLine()
                If Not risposta.Contains("0") Then
                    MsgBox("Errore flash")
                End If
                Wait(100)

Resend2:

                SerialPort.DiscardInBuffer()
                SerialPort.Write("M" & CBFirmware(i + 12) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 13) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 14) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 15) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 16) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 17) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 18) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 19) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 20) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 21) & vbCr)
                SerialPort.Write("M" & CBFirmware(i + 22) & vbCr)
                SerialPort.Write("1" & CBFirmware(i + 23) & vbCr)

                SerialPort.Write(Checksum(ncks) & vbCr)


                risposta = SerialPort.ReadLine()

                If Not risposta.Contains("OK") Then
                    GoTo Resend2
                End If
                ncks += 1

                Select Case MCU
                    Case MCU.NXP1759
                        SerialPort.Write("P " & 0 & " " & 29 & vbCr)
                    Case MCU.NXP1754
                        SerialPort.Write("P " & 0 & " " & 17 & vbCr)
                End Select

                risposta = SerialPort.ReadLine()

                SerialPort.Write("C " & Pagina * 1024 & " " & 268435968 & " " & 1024 & vbCr)

                risposta = SerialPort.ReadLine()
                Pagina += 1
            Next

            PBF.Value = PBF.Maximum



            SerialPort.Write("U 23130" & vbCrLf)
            risposta = SerialPort.ReadLine
            SerialPort.Write("G " & 0 & " T" & vbCrLf)
            risposta = SerialPort.ReadLine()
        Catch ex As Exception
            errorFlashing = True
            AggiornaLog(ex)
        End Try
    End Sub
    Private Sub LoadMainProgram(deviceProfile As String, current_fwmain_version As String)
        Dim Risposta As String
        Dim WC As New Stopwatch

        WC.Reset()
        WC.Start()

        While WC.ElapsedMilliseconds < 6000
            Application.DoEvents()
        End While

        Risposta = RDW_Command("R00")

        If (Not Risposta.Contains("BT") And Not CheckBoxHack.Checked) And Risposta.Length > 2 Then

            RDW_Command("P90 1")
            Wait(2000)
            Risposta = RDW_Command("R00")
            If Not Risposta.Contains("BT") Then
                Throw New Exception("Errore aggiornamento firmware")
            End If

        ElseIf (Not Risposta.Contains("BT") And CheckBoxHack.Checked) Then

        ElseIf (Risposta.Contains("BT") Or CheckBoxHack.Checked) And Risposta.Length > 2 Then

        Else
            Throw New Exception("Errore aggiornamento firmware")
        End If


        LeggiProgramma(Application.StartupPath & "\Bootloader\" & deviceProfile & "\Main.bin")
        CaricaFirmware()


        If deviceProfile.Contains("MDT") Then
            If current_fwmain_version.Length > 0 Then
                Dim ver = current_fwmain_version.ToString().Split(" ")(1)

                If ver.StartsWith("021") Then
                    Dim val = 0

                    If ver.CompareTo("0218B") >= 0 Then
                        val = 36
                    ElseIf ver.CompareTo("0218A") >= 0 Then
                        val = 35
                    ElseIf ver.CompareTo("0217J") >= 0 Then
                        val = 34
                    ElseIf ver.CompareTo("0217I") >= 0 Then
                        val = 33
                    ElseIf ver.CompareTo("0217H") >= 0 Then
                        val = 32
                    ElseIf ver.CompareTo("0217A") >= 0 Then
                        val = 25
                    ElseIf ver.CompareTo("0216A") >= 0 Then
                        val = 20
                    ElseIf ver.CompareTo("0215G") >= 0 Then
                        val = 7
                    ElseIf ver.CompareTo("0215E") >= 0 Then
                        val = 5
                    ElseIf ver.CompareTo("0215D") >= 0 Then
                        val = 4
                    ElseIf ver.CompareTo("0215C") >= 0 Then
                        val = 3
                    ElseIf ver.CompareTo("0215B") >= 0 Then
                        val = 2
                    ElseIf ver.CompareTo("0215A") >= 0 Then
                        val = 1
                    End If

                    If val > 0 Then
                        Dim PreconfMsg = RDW_Command("W07", 129804, val)
                        If PreconfMsg.Contains("?") Then MsgBox("errore nel comando preconf")

                        PreconfMsg = RDW_Command("W07", 129805, 0)
                        If PreconfMsg.Contains("?") Then MsgBox("errore nel comando preconf")

                        PreconfMsg = RDW_Command("W07", 129806, 0)
                        If PreconfMsg.Contains("?") Then MsgBox("errore nel comando preconf")

                        PreconfMsg = RDW_Command("W07", 129807, 0)
                        If PreconfMsg.Contains("?") Then MsgBox("errore nel comando preconf")
                    End If
                End If
            End If
        End If

        RDW_Command("P80")
        Wait(10000)
        Risposta = RDW_Command("R00")
        LNomeNuovoFirmware.Text = Risposta
    End Sub

    Public Function CaricaFirmware()
        Dim riprovato As Integer = 5
        Dim Ok As String
        PBFU.Visible = True
        PBFU.Value = 0
        PBFU.Maximum = totbyte + 1

        For lil As Integer = 1 To totbyte Step +1
            PBFU.Value += 1
            Ok = ""
            If CheckBoxHack.Checked Then
                Ok = RDW_Command("F92", ProgrammaFinale(lil), lil, True)
            Else
                Ok = RDW_Command("F91", ProgrammaFinale(lil), lil, True)
            End If

            If Ok = "?" Or Ok = "KO" Then

                If riprovato > 0 Then
                    lil -= 1
                    PBFU.Value -= 1
                    riprovato -= 1
                    Wait(1000)
                Else

                    Dim lal = MsgBox("Errore nell'aggiornamento del firmware all'allocazione: " & lil * 256, MsgBoxStyle.AbortRetryIgnore)
                    If lal = vbAbort Then
                        MsgBox("Aggiornamento firmware compromesso! Si prega di aggiornarlo nuovamente")
                        Exit For
                    ElseIf lal = vbRetry Then
                        lil -= 1
                        PBFU.Value -= 1
                    ElseIf lal = vbIgnore Then
                        Continue For
                    End If
                End If
            End If
        Next

        Ok = RDW_Command("F91", ProgrammaFinale(0), 0, True)

        Return "OK"
    End Function



    Function checkaSum(checksumStr As String, filename As String) As Boolean
        If checksumStr = "" Then
            If MessageBox.Show("Impossibile controllare il checksum del file " & filename & "; è possibile proseguire ma è altamente sconsigliato e pericoloso: si rischia di causare danni imprevedibili ed irreparabili alle apparecchiature. Se non si è sicuri NON PROSEGUIRE ed eliminare il file. Eseguire comunque l'aggiornamento?", "", MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes Then
                Return False
            End If
        Else
            If Not checkaChecksum(filename, checksumStr) Then
                MessageBox.Show("Il file " & filename & " non ha superato il test del checksum")
                Return False
            End If
        End If

        Return True
    End Function



    Private Sub LoadParametri(filepatftftftftft As String, pbconf As ProgressBar)
        Dim risposta As String
        Dim tentativi As Integer = 5
        Dim alltext()
        Dim redText As String
        Dim splitChar As String = vbCrLf

        Using sw As StreamReader = New StreamReader(filepatftftftftft)
            redText = sw.ReadToEnd()
        End Using

        If redText.Contains(vbCrLf) Then
            splitChar = vbCrLf
        ElseIf redText.Contains(vbCr) And Not redText.Contains(vbLf) Then
            splitChar = vbCr
        ElseIf redText.Contains(vbLf) And Not redText.Contains(vbCr) Then
            splitChar = vbLf
        End If
        alltext = Split(redText, splitChar)

        Dim OLD As Integer = SerialPort.ReadTimeout
        SerialPort.ReadTimeout = 10000

        pbconf.Maximum = alltext.Count

        Dim silentRetry As Integer = 0

        For i = 0 To alltext.Count - 1
            Try
                Dim cmd = alltext(i)
                If cmd = "" Or Not cmd.ToString().StartsWith("$") Then Continue For
                If STOPALL Then Exit For
                Wait(25)

                cmd = cmd.TrimStart("$")
                cmd = cmd.TrimStart(vbCr)
                cmd = cmd.TrimStart(vbLf)

                If cmd.StartsWith("W06 ") AndAlso cmd.Split(" ").Length > 2 AndAlso cmd.Split(" ")(2).Contains("K") Then
                    cmd = computeImportPage(cmd)
                End If

                risposta = RDW_Command(Trim(cmd))
                If (risposta = "?" Or risposta = "KO") AndAlso (silentRetry < 3 OrElse MessageBox.Show("Errore nell'aggiornamento del parametro" & ": " & cmd, "", MessageBoxButtons.RetryCancel) = Windows.Forms.DialogResult.Retry) Then
                    silentRetry += 1
                    i -= 1
                    Continue For
                End If
                silentRetry = 0

                pbconf.Value += 1

            Catch ex As Exception
                AggiornaLog(ex)
            End Try
        Next
        pbconf.Value = pbconf.Maximum

        pbconf.Value = 0
        RDW_Command("L02")
        SerialPort.ReadTimeout = OLD
    End Sub

    Private Sub checkMDTReady()
        If mdtTimeout < 1 Then Return
        Dim mdtReady As String = ""
        Dim stw As New Stopwatch
        Dim alt As Boolean = False
        stw.Reset()
        stw.Start()
        While ((mdtReady = "" Or mdtReady = "?" Or mdtReady = "KO") And stw.ElapsedMilliseconds < mdtTimeout)
            If STOPALL Then Exit While
            LabelWaitForMDT.Text = "Waiting for device to ripigliarsi... " & Math.Round(stw.Elapsed.TotalSeconds, 1)
            If alt Then
                LabelWaitForMDT.ForeColor = Color.Red
                mdtReady = RDW_Command("R00")
            Else
                LabelWaitForMDT.ForeColor = Color.Green
            End If
            alt = Not alt
            Wait(250)
        End While
        LabelWaitForMDT.Text = ""
        stw.Stop()
        stw = Nothing
    End Sub

    Private Sub CheckHR()
        Dim HRTW As New Stopwatch
        Dim HRForzato As Boolean = False
        Dim ModemHRS As Boolean = False
        Dim HRGenerato As Boolean = False
        HRTW.Reset()
        HRTW.Start()
        Dim Risposta As String = ""
        PBHR.Maximum = 240000
        Dim comando As String

        Wait(200)

        If SIM_ST = 0 Then MsgBox("Inserire sim per continuare i test")

        serialnumber = RDW_Command("R08", 1)
        If serialnumber = "" Then serialnumber = InputBox("Inserire il serialnumber!")
        serialnumber = RDW_Command("W08", 1, serialnumber)

        If File.Exists(Application.StartupPath & "\Bootloader\" & DropdownDevicesProfiles.SelectedItem.ToString & "\HRConfP.cnf") Then
            Using sw As StreamReader = New StreamReader(Application.StartupPath & "\Bootloader\" & DropdownDevicesProfiles.SelectedItem.ToString & "\HRConf.cnf")
                Do Until sw.EndOfStream
                    Try
                        If Not STOPALL Then Exit Sub

                        comando = sw.ReadLine
                        comando = comando.TrimStart("$")
                        Risposta = RDW_Command(comando)
                        If Risposta.Contains("?") Then MsgBox("errore nel comando $" & comando)

                    Catch ex As Exception
                    End Try
                Loop
            End Using

            RDW_Command("L02")
        End If

        While HRTW.ElapsedMilliseconds < 240000
            If Not STOPALL Then Exit Sub

            Try
                Application.DoEvents()
                If CBTestHR.Checked = False Then Exit Sub
                PBHR.Value = HRTW.ElapsedMilliseconds
                If GPRS_SE = 1 And GSM_ST = 1 And MODEM_ST = 1 And HRForzato = False Then
                    If HRGenerato = False Then
                        Risposta = RDW_Command("Q404")
                        If Risposta.Count > 2 Then HRGenerato = True
                    End If

                    Wait(200)
                    Risposta = RDW_Command("Q401")
                    If Risposta.Length > 2 Then

                        RDW_Command("Q407")
                        Application.DoEvents()
                        HRForzato = True
                        Wait(1000)
                        Continue While
                    End If

                End If
                If ModemHRS = False And MODEM_ST = 2 Then
                    ModemHRS = True
                End If

                If ModemHRS = True And HRForzato = True And MODEM_ST = 1 Then
                    PBHR.Value = 240000
                    Exit While
                End If

            Catch ex As Exception

            End Try
        End While

        Dim up As New Net.WebClient
        up.Credentials = New NetworkCredential("webgrit", "q8x3z43yVN")
        up.DownloadFile("http://grlabgps.webgr.it/Payload.txt", Application.StartupPath & "\Bootloader\" & DropdownDevicesProfiles.SelectedItem.ToString & "\Payload.txt")
        Dim alltext As String
        Using sw As StreamReader = New StreamReader(Application.StartupPath & "\Bootloader\" & DropdownDevicesProfiles.SelectedItem.ToString & "\Payload.txt")
            alltext = sw.ReadToEnd
        End Using

        If File.Exists(Application.StartupPath & "\Bootloader\" & DropdownDevicesProfiles.SelectedItem.ToString & "\HRConf.cnf") Then
            Using sw As StreamReader = New StreamReader(Application.StartupPath & "\Bootloader\" & DropdownDevicesProfiles.SelectedItem.ToString & "\Conf2.cnf")
                Do Until sw.EndOfStream
                    Try
                        If Not STOPALL Then Exit Sub

                        comando = sw.ReadLine
                        comando = comando.TrimStart("$")
                        Risposta = RDW_Command(comando)
                        If Risposta.Contains("?") Then MsgBox("errore nel comando $" & comando)

                    Catch ex As Exception
                    End Try
                Loop
            End Using

            RDW_Command("L02")
        End If

        If alltext.Contains(serialnumber) Then
            LInvioHR.Visible = True
        Else
            LInvioHR.Visible = True
            LInvioHR.Text = "Test fallito"
        End If
    End Sub

    Private Sub TestGPS()
        Dim HRTW As New Stopwatch
        HRTW.Reset()
        HRTW.Start()

        PBGPS.Maximum = 60000

        FIXS = 0

        While FIXS = 0 And HRTW.ElapsedMilliseconds < 60000
            If CBTestGPS.Checked = False Then Exit Sub
            If HRTW.ElapsedMilliseconds < 60000 Then PBGPS.Value = HRTW.ElapsedMilliseconds
            If FIXS Then Exit While
            Application.DoEvents()
        End While

        PBGPS.Value = PBGPS.Maximum

        If FIXS = 0 Then
            LTestGPS.Text = "Test fallito"
        End If
        LTestGPS.Visible = True
    End Sub

    Public Function MDTRStato()
        Try
            Dim Stato(31) As String
            Dim StatoNE(50) As String

            Dim check As String
            check = RDW_Command("R01", , , , True)
            If check = "KO" Then Return "KO"
            Stato = Split(check, "|")

            For i As Integer = 0 To Stato.Length - 1
                StatoNE(i) = Stato(i)
            Next

            MDTTensioneInterna = StatoNE(0) / 10
            MDTTensioneEsterna = StatoNE(1) / 10
            SegnaleGPRS = StatoNE(2)
            MDTRpm = StatoNE(3)
            Pitch = StatoNE(4)
            Roll = StatoNE(5)
            Inclinazione = StatoNE(6)
            Accelerazione = StatoNE(7) / 10
            Direzione = StatoNE(9)

            MDTIO(0) = StatoNE(10)
            MDTIO(1) = StatoNE(11)
            MDTIO(2) = StatoNE(12)
            MDTIO(3) = StatoNE(13)
            MDTIO(4) = StatoNE(14)
            MDTIO(5) = StatoNE(15)
            MDTIO(6) = StatoNE(16)
            MDTIO(7) = StatoNE(17)
            MDTIO(8) = StatoNE(18)
            MDTIO(9) = StatoNE(19)
            MDTIO(10) = StatoNE(20)

            SD_FREE = StatoNE(21)  'Spazio SD
            MODEM_ST = StatoNE(22) '0=non inizializzato,1=libero,2=Connessione HTTP,3=Chiamata dati,4=Connessione FTP
            CURRENT_PROFILE = StatoNE(23) 'Profilo 1-2-3-4
            GSM_ST = StatoNE(24) '0=non registrato,1=registrato,3=ricerca,4=non definito,5=roaming
            GPRS_SE = StatoNE(25) '0=non registrato,1=registrato,3=ricerca,4=non definito,5=roaming
            GPSS = StatoNE(26) '
            FIXS = StatoNE(27) '
            SIM_ST = StatoNE(28) '
            ACC_ST = StatoNE(29)

        Catch ex As Exception

        End Try
        Return "OK"
    End Function


    Public Sub PperPos_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim t(8) As Point3D
        Dim f(4) As Integer
        Dim v As Point3D
        Dim avgZ(6) As Double
        Dim order(6) As Integer
        Dim tmp As Double
        Dim iMax As Integer

        For i = 0 To 7
            v = m_vertices(i)
            t(i) = v.RotateX(m_x).RotateY(m_y).RotateZ(m_z)
        Next

        t(0) = t(0).Project(145, 110, 100, 4)
        t(1) = t(1).Project(145, 110, 100, 4)
        t(2) = t(2).Project(145, 110, 100, 4)
        t(3) = t(3).Project(145, 110, 100, 4)

        t(4) = t(4).Project(145, 110, 100, 4)
        t(5) = t(5).Project(145, 110, 100, 4)
        t(6) = t(6).Project(145, 110, 100, 4)
        t(7) = t(7).Project(145, 110, 100, 4)

        ' Compute the average Z value of each face.
        For i = 0 To 5
            avgZ(i) = (t(m_faces(i, 0)).Z + t(m_faces(i, 1)).Z + t(m_faces(i, 2)).Z + t(m_faces(i, 3)).Z) / 4.0
            order(i) = i
        Next

        ' Next we sort the faces in descending order based on the Z value.
        ' The objective is to draw distant faces first. This is called 
        ' the PAINTERS ALGORITHM. So, the visible faces will hide the invisible ones.
        ' The sorting algorithm used is the SELECTION SORT.
        For i = 0 To 4
            iMax = i
            For j = i + 1 To 5
                If avgZ(j) > avgZ(iMax) Then
                    iMax = j
                End If
            Next
            If iMax <> i Then
                tmp = avgZ(i)
                avgZ(i) = avgZ(iMax)
                avgZ(iMax) = tmp

                tmp = order(i)
                order(i) = order(iMax)
                order(iMax) = tmp
            End If
        Next

        ' Draw the faces using the PAINTERS ALGORITHM (distant faces first, closer faces last).
        For i = 0 To 5
            Dim points() As Point
            Dim index As Integer = order(i)
            points = New Point() {
            New Point(CInt(t(m_faces(index, 0)).X), CInt(t(m_faces(index, 0)).Y)),
            New Point(CInt(t(m_faces(index, 1)).X), CInt(t(m_faces(index, 1)).Y)),
            New Point(CInt(t(m_faces(index, 2)).X), CInt(t(m_faces(index, 2)).Y)),
            New Point(CInt(t(m_faces(index, 3)).X), CInt(t(m_faces(index, 3)).Y))
        }
            e.Graphics.FillPolygon(m_brushes(index), points)
        Next
    End Sub

    Private Sub TestAccelerometro()
        Dim HRTW As New Stopwatch
        HRTW.Reset()
        HRTW.Start()

        PBAcclrmtr.Maximum = 60000
        FixsAccel = False

        While FixsAccel = 0 And HRTW.ElapsedMilliseconds < 60000
            If CBTestAccel.Checked = False Then Exit Sub
            If HRTW.ElapsedMilliseconds <= PBAcclrmtr.Maximum Then PBAcclrmtr.Value = HRTW.ElapsedMilliseconds

            Application.DoEvents()
        End While

        PBAcclrmtr.Value = PBAcclrmtr.Maximum

        If FixsAccel = 0 Then
            LAccelerometro.Text = "Test fallito"
        End If
        LAccelerometro.Visible = True
    End Sub

    Function analyzeFw(bytes As Byte()) As String
        If form_opening Then Return ""
        Dim fwVersion = ""

        For i As Integer = 0 To bytes.Length - 1
            If i < bytes.Length + 10 Then
                If (i Mod 1000) = 0 Then
                    Application.DoEvents()
                End If
                Try
                    If Chr(bytes(i)).ToString.Contains("X") And Chr(bytes(i + 1)).ToString.Contains("1") And Chr(bytes(i + 2)).ToString.Contains("9") And Chr(bytes(i + 3)).ToString.Contains("A") And Chr(bytes(i + 4)).ToString.Contains("1") And Chr(bytes(i + 5)).ToString.Contains("|") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & " " & Chr(bytes(i + 6)) & Chr(bytes(i + 7)) & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("B") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("X") And Chr(bytes(i + 3)).ToString.Contains("1") And Chr(bytes(i + 4)).ToString.Contains("9") And Chr(bytes(i + 5)).ToString.Contains("A") And Chr(bytes(i + 6)).ToString.Contains("1") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & Chr(bytes(i + 5)) & Chr(bytes(i + 6)) & " " & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10)) & Chr(bytes(i + 11))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("M") And Chr(bytes(i + 1)).ToString.Contains("D") And Chr(bytes(i + 2)).ToString.Contains("T") And Chr(bytes(i + 3)).ToString.Contains("A") And Chr(bytes(i + 4)).ToString.Contains("1") And Chr(bytes(i + 5)).ToString.Contains("|") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & " " & Chr(bytes(i + 6)) & Chr(bytes(i + 7)) & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("B") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("M") And Chr(bytes(i + 3)).ToString.Contains("D") And Chr(bytes(i + 4)).ToString.Contains("T") And Chr(bytes(i + 5)).ToString.Contains("A") And Chr(bytes(i + 6)).ToString.Contains("1") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & Chr(bytes(i + 5)) & Chr(bytes(i + 6)) & " " & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10)) & Chr(bytes(i + 11))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("E") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("S") And Chr(bytes(i + 3)).ToString.Contains("A") And Chr(bytes(i + 4)).ToString.Contains("1") And Chr(bytes(i + 5)).ToString.Contains("|") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & " " & Chr(bytes(i + 6)) & Chr(bytes(i + 7)) & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10))
                        'Return 1 'main ETSA1
                    End If
                    If Chr(bytes(i)).ToString.Contains("B") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("E") And Chr(bytes(i + 3)).ToString.Contains("T") And Chr(bytes(i + 4)).ToString.Contains("S") And Chr(bytes(i + 5)).ToString.Contains("A") And Chr(bytes(i + 6)).ToString.Contains("1") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & Chr(bytes(i + 5)) & Chr(bytes(i + 6)) & " " & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10)) & Chr(bytes(i + 11))
                        ' Return 3 'boot etsDev
                    End If
                    If Chr(bytes(i)).ToString.Contains("E") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("S") And Chr(bytes(i + 3)).ToString.Contains("D") And Chr(bytes(i + 4)).ToString.Contains("N") And Chr(bytes(i + 5)).ToString.Contains("|") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & " " & Chr(bytes(i + 6)) & Chr(bytes(i + 7)) & Chr(bytes(i + 8)) & Chr(bytes(i + 9))
                        'Return 2 'main ETSDN
                    End If
                    If Chr(bytes(i)).ToString.Contains("B") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("E") And Chr(bytes(i + 3)).ToString.Contains("T") And Chr(bytes(i + 4)).ToString.Contains("S") And Chr(bytes(i + 5)).ToString.Contains("D") And Chr(bytes(i + 6)).ToString.Contains("N") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & Chr(bytes(i + 5)) & Chr(bytes(i + 6)) & " " & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10)) & Chr(bytes(i + 11))
                        'Return 4 'boot ETSDN
                    End If
                    If Chr(bytes(i)).ToString.Contains("E") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("S") And Chr(bytes(i + 3)).ToString.Contains("B") And Chr(bytes(i + 4)).ToString.Contains("1") And Chr(bytes(i + 5)).ToString.Contains("|") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & " " & Chr(bytes(i + 6)) & Chr(bytes(i + 7)) & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10))
                        'Return 5 'main ETSB1
                    End If
                    If Chr(bytes(i)).ToString.Contains("B") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("E") And Chr(bytes(i + 3)).ToString.Contains("T") And Chr(bytes(i + 4)).ToString.Contains("S") And Chr(bytes(i + 5)).ToString.Contains("B") And Chr(bytes(i + 6)).ToString.Contains("1") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & Chr(bytes(i + 5)) & Chr(bytes(i + 6)) & " " & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10)) & Chr(bytes(i + 11))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("S") And Chr(bytes(i + 1)).ToString.Contains("I") And Chr(bytes(i + 2)).ToString.Contains("R") And Chr(bytes(i + 3)).ToString.Contains("F") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("G") And Chr(bytes(i + 1)).ToString.Contains("E") And Chr(bytes(i + 2)).ToString.Contains("8") And Chr(bytes(i + 3)).ToString.Contains("6") And Chr(bytes(i + 4)).ToString.Contains("4") And Chr(bytes(i + 5)).ToString.Contains("-") And Chr(bytes(i + 6)).ToString.Contains("G") And Chr(bytes(i + 7)).ToString.Contains("P") And Chr(bytes(i + 8)).ToString.Contains("S") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & Chr(bytes(i + 5)) & Chr(bytes(i + 6)) & Chr(bytes(i + 7)) & Chr(bytes(i + 8))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("G") And Chr(bytes(i + 1)).ToString.Contains("E") And Chr(bytes(i + 2)).ToString.Contains("8") And Chr(bytes(i + 3)).ToString.Contains("6") And Chr(bytes(i + 4)).ToString.Contains("4") And Chr(bytes(i + 5)).ToString.Contains("-") And Chr(bytes(i + 6)).ToString.Contains("V") And Chr(bytes(i + 7)).ToString.Contains("2") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & Chr(bytes(i + 5)) & Chr(bytes(i + 6)) & Chr(bytes(i + 7))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("M") And Chr(bytes(i + 1)).ToString.Contains("D") And Chr(bytes(i + 2)).ToString.Contains("C") And Chr(bytes(i + 3)).ToString.Contains("A") And Chr(bytes(i + 4)).ToString.Contains("1") And Chr(bytes(i + 5)).ToString.Contains("|") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & " " & Chr(bytes(i + 6)) & Chr(bytes(i + 7)) & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("B") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("M") And Chr(bytes(i + 3)).ToString.Contains("D") And Chr(bytes(i + 4)).ToString.Contains("C") And Chr(bytes(i + 5)).ToString.Contains("A") And Chr(bytes(i + 6)).ToString.Contains("1") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & Chr(bytes(i + 5)) & Chr(bytes(i + 6)) & " " & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10)) & Chr(bytes(i + 11))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("M") And Chr(bytes(i + 1)).ToString.Contains("D") And Chr(bytes(i + 2)).ToString.Contains("C") And Chr(bytes(i + 3)).ToString.Contains("L") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & " " & Chr(bytes(i + 5)) & Chr(bytes(i + 7)) & Chr(bytes(i + 8))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("B") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("M") And Chr(bytes(i + 3)).ToString.Contains("D") And Chr(bytes(i + 4)).ToString.Contains("C") And Chr(bytes(i + 5)).ToString.Contains("L") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & " " & Chr(bytes(i + 5)) & Chr(bytes(i + 7)) & Chr(bytes(i + 8))
                        Exit For
                    End If
                    If Chr(bytes(i)).ToString.Contains("B") And Chr(bytes(i + 1)).ToString.Contains("P") And Chr(bytes(i + 2)).ToString.Contains("S") And Chr(bytes(i + 3)).ToString.Contains("A") And Chr(bytes(i + 4)).ToString.Contains("1") And Chr(bytes(i + 5)).ToString.Contains("|") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & " " & Chr(bytes(i + 6)) & Chr(bytes(i + 7)) & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10))
                        Exit For 'main BPSA1 
                    End If
                    If Chr(bytes(i)).ToString.Contains("B") And Chr(bytes(i + 1)).ToString.Contains("T") And Chr(bytes(i + 2)).ToString.Contains("B") And Chr(bytes(i + 3)).ToString.Contains("P") And Chr(bytes(i + 4)).ToString.Contains("S") And Chr(bytes(i + 5)).ToString.Contains("A") And Chr(bytes(i + 6)).ToString.Contains("1") Then
                        fwVersion = Chr(bytes(i)) & Chr(bytes(i + 1)) & Chr(bytes(i + 2)) & Chr(bytes(i + 3)) & Chr(bytes(i + 4)) & Chr(bytes(i + 5)) & Chr(bytes(i + 6)) & " " & Chr(bytes(i + 8)) & Chr(bytes(i + 9)) & Chr(bytes(i + 10)) & Chr(bytes(i + 11))
                        Exit For 'main BTBPSA1 
                    End If
                Catch
                End Try

            End If
        Next

        Return fwVersion
    End Function

    Private Sub DropdownDevicesProfiles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DropdownDevicesProfiles.SelectedIndexChanged
        If DropdownDevicesProfiles.SelectedIndex = 0 Then
            UI_Reset()
            Return
        End If

        UI_ChangeControlEnabled(Me, False)

        Try
            setupDeviceProfile(DropdownDevicesProfiles.SelectedItem.ToString())
        Finally
            UI_ChangeControlEnabled(Me, True)
        End Try
    End Sub

    Private Delegate Sub setupDeviceProfileDelegate(profile As String)
    Public Sub setupDeviceProfile(profile As String)
        If Me.InvokeRequired Then
            Me.Invoke(New setupDeviceProfileDelegate(AddressOf setupDeviceProfile), New Object() {profile})
            Return
        End If

        Dim mainIsEnabled = Me.Enabled
        Me.Enabled = True

        current_fwbt_version = ""
        current_fwmain_version = ""
        cloudCodeLocation = -1
        cloudPswLocation = -1
        anagraficaSerialLocation = -1

        If File.Exists(Application.StartupPath & "\Bootloader\" & profile.ToString & "\Configurazione.txt") Then
            Using sw As StreamReader = New StreamReader(Application.StartupPath & "\Bootloader\" & profile.ToString & "\Configurazione.txt", System.Text.Encoding.ASCII)
                CheckboxFlashBootloader.Enabled = sw.ReadLine()
                CheckboxFlashFirmware.Enabled = sw.ReadLine
                CheckboxCA.Enabled = sw.ReadLine
                CBTestAccel.Enabled = sw.ReadLine
                CBTestGPS.Enabled = sw.ReadLine
                CBTestHR.Enabled = sw.ReadLine
                CheckboxSyncDatetime.Enabled = sw.ReadLine
                CBCalibrazione.Enabled = sw.ReadLine
                If Not sw.EndOfStream Then
                    Integer.TryParse(sw.ReadLine(), cloudCodeLocation)
                End If
                If Not sw.EndOfStream Then
                    Integer.TryParse(sw.ReadLine(), cloudPswLocation)
                End If
                If Not sw.EndOfStream Then
                    Integer.TryParse(sw.ReadLine(), anagraficaSerialLocation)
                End If
                If Not sw.EndOfStream Then
                    If Integer.TryParse(sw.ReadLine(), mdtTimeout) Then
                        mdtTimeout *= 1000
                    Else
                        mdtTimeout = 0
                    End If
                End If
            End Using
        End If

        loadBaudrateConf(profile)

        TextboxCPSerialNumber.Text = _CP210xSerial

        LabelFlasingFw.Text = ""

        CheckboxWriteCloudCode.Checked = cloudCodeLocation > 0 And cloudPswLocation > 0

        CheckBoxSerialAnagrafica.Enabled = anagraficaSerialLocation > 0

        CheckboxFlashBootloader.Checked = CheckboxFlashBootloader.Enabled
        CheckboxFlashFirmware.Checked = CheckboxFlashFirmware.Enabled
        CheckboxCA.Checked = CheckboxCA.Enabled
        '    CBTestAccel.Checked = CBTestAccel.Enabled
        '  CBTestGPS.Checked = CBTestGPS.Enabled
        ' CBTestHR.Checked = CBTestHR.Enabled
        CheckboxSyncDatetime.Checked = CheckboxSyncDatetime.Enabled
        ' CBCalibrazione.Checked = CBCalibrazione.Enabled

        CheckboxFwEnableKbd.Visible = False
        CheckboxFwEnableTouch.Visible = False
        CheckboxFwEnable125Khz.Visible = False
        CheckboxFwEnableFps.Visible = False
        CheckboxFwEnableKbd.Enabled = False
        CheckboxFwEnableFps.Enabled = False
        CheckboxFwEnableTouch.Enabled = False
        CheckboxFwEnable125Khz.Enabled = False
        CheckboxFwEnableModGps.Visible = False
        CheckboxFwEnableModSD.Visible = False
        CheckboxFwEnableModGps.Enabled = False
        CheckboxFwEnableGPSUblox.Enabled = False
        CheckboxFwEnableGPSUblox.Enabled = False
        CheckboxFwEnableModSD.Enabled = False
        CheckboxHwEnableWifi.Enabled = False
        CheckboxHwEnableGPRS.Enabled = False
        CheckboxHwEnableGPS.Enabled = False
        CheckboxHwEnableCartellino.Enabled = False
        CheckboxHwEnableSD.Enabled = False
        CheckboxHWSetup.Checked = False
        CheckboxHWSetup.Enabled = False
        CheckBoxHWSetupMoved.Enabled = False
        LabelHwSetup.Enabled = False
        CheckBoxInitETS.Visible = False
        CheckboxFormatSD.Enabled = False
        CheckBoxClearAllarmi.Enabled = False
        ButtonReadWiFly.Visible = False
        ButtonUpdateWiFly.Visible = False
        ButtonBLESETId.Visible = False
        ButtonDivineETSCANBaudSet.Visible = False
        ButtonDivineETSDNAssoc.Visible = False
        ButtonBLERP0.Visible = False
        ButtonDivineETSSetUser.Visible = False
        While NumericUpDownValoriCount.Value > 0
            NumericUpDownValoriCount.DownButton()
        End While
        GroupBoxRFIDTest.Enabled = False
        GroupBoxLEDTest.Enabled = False
        GroupBoxGPRSTest.Enabled = False
        GroupBoxTelitTest.Enabled = False

        TextBoxAnalPrefix.Text = "ETS_"
        CheckBoxJlink.Checked = False
        CheckboxWriteSerialNumber.Checked = True
        CheckboxWriteSerialNumber.Enabled = True

        If profile.ToString.Contains("X19") Or profile.ToString.Contains("MDT_NEW") Or profile.ToString.Contains("MDT") Then

            If profile.ToString.Contains("X19") Then
                TextboxHardwareCode.Text = "424"
                CheckboxFwEnableGPSUblox.Visible = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModGps.Visible = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModSD.Visible = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModGps.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModSD.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableGPSUblox.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFormatSD.Enabled = True
                CheckBoxClearAllarmi.Enabled = True
                ButtonDivineETSDNAssoc.Visible = True
                CheckboxWriteCloudCode.Enabled = CheckboxWriteCloudCode.Checked
            End If

            If profile.ToString.Contains("MDT_NEW") Then
                TextboxHardwareCode.Text = "425"
                CheckboxFwEnableGPSUblox.Visible = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModGps.Visible = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModSD.Visible = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModGps.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModSD.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableGPSUblox.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFormatSD.Enabled = True
                CheckBoxClearAllarmi.Enabled = True
                ButtonDivineETSDNAssoc.Visible = True
                CheckboxWriteCloudCode.Enabled = CheckboxWriteCloudCode.Checked
            End If

            If profile.ToString.Contains("MDT") Then
                TextboxHardwareCode.Text = "425"
                CheckboxFwEnableGPSUblox.Visible = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModGps.Visible = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModSD.Visible = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModGps.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModSD.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableGPSUblox.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFormatSD.Enabled = True
                CheckBoxClearAllarmi.Enabled = True
                ButtonDivineETSDNAssoc.Visible = True
                CheckboxWriteCloudCode.Enabled = CheckboxWriteCloudCode.Checked
            End If
        ElseIf profile.Contains("ETSDN") Then
            TextboxHardwareCode.Text = "512"

        ElseIf profile.Equals("MIA") Then
            TextboxHardwareCode.Text = "401"

        ElseIf profile.ToString.Contains("ETSB") Then
            TextboxHardwareCode.Text = "523"
            CheckboxHWSetup.Enabled = True
            CheckBoxHWSetupMoved.Enabled = True
            CheckboxHwEnableWifi.Enabled = False
            CheckboxHwEnableWifi.Checked = False
            CheckboxHwEnableGPRS.Enabled = False
            CheckboxHwEnableGPRS.Checked = False
            CheckboxHwEnableGPS.Enabled = False
            CheckboxHwEnableGPS.Checked = False
            CheckboxHwEnableSD.Enabled = False
            CheckboxHwEnableSD.Checked = False
            CheckboxHWSetup.Checked = False
            CheckboxHWSetup.Enabled = False
            LabelHwSetup.Enabled = True
            CheckboxFormatSD.Enabled = True
            CheckboxFwEnableKbd.Visible = True
            CheckboxFwEnableTouch.Visible = True
            CheckboxFwEnableFps.Visible = True
            CheckboxFwEnable125Khz.Visible = True
            CheckboxFwEnableKbd.Enabled = True
            CheckboxFwEnableTouch.Enabled = True
            CheckboxFwEnableFps.Enabled = True
            CheckboxFwEnable125Khz.Enabled = True
            CheckBoxInitETS.Visible = True
            CheckboxHwEnableCartellino.Enabled = True
            CheckBoxClearAllarmi.Enabled = True
            ButtonReadWiFly.Visible = True
            ButtonUpdateWiFly.Visible = True
            ButtonDivineETSCANBaudSet.Visible = True
            GroupBoxRFIDTest.Enabled = True
            GroupBoxLEDTest.Enabled = True
            GroupBoxGPRSTest.Enabled = True
            GroupBoxTelitTest.Enabled = True
            ButtonDivineETSSetUser.Visible = True
        ElseIf profile.ToString.Contains("ETS") Then
            ButtonDivineETSDNAssoc.Visible = True
            If Not profile.ToString.Contains("ETSL") Then
                TextboxHardwareCode.Text = "523"
                CheckboxHWSetup.Enabled = True
                CheckBoxHWSetupMoved.Enabled = True
                CheckboxHWSetup.Checked = True
                CheckboxHwEnableWifi.Enabled = True
                CheckboxHwEnableWifi.Checked = True
                CheckboxHwEnableGPRS.Enabled = True
                CheckboxHwEnableGPRS.Checked = True
                CheckboxHwEnableGPS.Enabled = True
                CheckboxHwEnableGPS.Checked = True
                CheckboxHwEnableSD.Enabled = True
                LabelHwSetup.Enabled = True
                CheckboxFormatSD.Enabled = True
                CheckboxFwEnableKbd.Visible = True
                CheckboxFwEnableTouch.Visible = True
                CheckboxFwEnableFps.Visible = True
                CheckboxFwEnable125Khz.Visible = True
                CheckboxFwEnableKbd.Enabled = True
                CheckboxFwEnableTouch.Enabled = True
                CheckboxFwEnableFps.Enabled = True
                CheckboxFwEnable125Khz.Enabled = True
                CheckBoxInitETS.Visible = True
                CheckboxHwEnableCartellino.Enabled = True
                CheckBoxClearAllarmi.Enabled = True
                ButtonReadWiFly.Visible = True
                ButtonUpdateWiFly.Visible = True
                ButtonDivineETSCANBaudSet.Visible = True
                GroupBoxRFIDTest.Enabled = True
                GroupBoxLEDTest.Enabled = True
                GroupBoxGPRSTest.Enabled = True
                GroupBoxTelitTest.Enabled = True
                ButtonDivineETSSetUser.Visible = True
            End If

        ElseIf profile.ToString.Contains("UWB_ancora") Then
            TextboxHardwareCode.Text = "523"
            CheckboxHWSetup.Enabled = True
            CheckBoxHWSetupMoved.Enabled = True
            CheckboxHWSetup.Checked = True
            CheckboxHwEnableWifi.Enabled = True
            CheckboxHwEnableGPRS.Enabled = True
            CheckboxHwEnableGPS.Enabled = True
            CheckboxHwEnableSD.Enabled = True
            LabelHwSetup.Enabled = True
            CheckboxFormatSD.Enabled = True
            CheckboxFwEnableKbd.Visible = True
            CheckboxFwEnableTouch.Visible = True
            CheckboxFwEnableFps.Visible = True
            CheckboxFwEnable125Khz.Visible = True
            CheckboxFwEnableKbd.Enabled = True
            CheckboxFwEnableTouch.Enabled = True
            CheckboxFwEnableFps.Enabled = True
            CheckboxFwEnable125Khz.Enabled = True
            CheckBoxInitETS.Visible = True
            CheckboxHwEnableCartellino.Enabled = True
            CheckBoxClearAllarmi.Enabled = True
            ButtonReadWiFly.Visible = True
            ButtonUpdateWiFly.Visible = True
            ButtonDivineETSCANBaudSet.Visible = True
            GroupBoxRFIDTest.Enabled = True
            GroupBoxLEDTest.Enabled = True
            GroupBoxGPRSTest.Enabled = True
            GroupBoxTelitTest.Enabled = True
            ButtonDivineETSSetUser.Visible = True

        ElseIf profile.ToString.Contains("BT1") Then
            TextboxHardwareCode.Text = "424"
            CheckBoxClearAllarmi.Enabled = True

        ElseIf profile.ToString.Contains("BT2") Then
            TextboxHardwareCode.Text = "411"
            CheckBoxClearAllarmi.Enabled = True

        ElseIf profile.ToString.Contains("KiwiZonePlus") Then
            TextboxHardwareCode.Text = "832"
            ButtonBLESETId.Visible = True
            ButtonBLESETId_Click(Nothing, Nothing)
            ButtonBLERP0.Visible = True

        ElseIf profile.ToString.Contains("KiwiCall") Then
            TextBoxAnalPrefix.Text = ""
            CheckboxHWSetup.Enabled = False
            CheckBoxHWSetupMoved.Enabled = False
            CheckboxHWSetup.Checked = False
            CheckboxHwEnableWifi.Enabled = False
            CheckboxHwEnableGPRS.Enabled = False
            CheckboxHwEnableGPS.Enabled = False
            CheckboxHwEnableSD.Enabled = False
            LabelHwSetup.Enabled = False
            CheckboxFormatSD.Enabled = False
            CheckboxFwEnableKbd.Visible = False
            CheckboxFwEnableTouch.Visible = False
            CheckboxFwEnableFps.Visible = False
            CheckboxFwEnable125Khz.Visible = False
            CheckboxFwEnableKbd.Enabled = False
            CheckboxFwEnableTouch.Enabled = False
            CheckboxFwEnableFps.Enabled = False
            CheckboxFwEnable125Khz.Enabled = False
            CheckBoxInitETS.Visible = False
            CheckboxHwEnableCartellino.Enabled = False
            CheckBoxClearAllarmi.Enabled = False
            ButtonReadWiFly.Visible = False
            ButtonUpdateWiFly.Visible = False
            ButtonDivineETSCANBaudSet.Visible = False
            GroupBoxRFIDTest.Enabled = False
            GroupBoxLEDTest.Enabled = False
            GroupBoxGPRSTest.Enabled = False
            GroupBoxTelitTest.Enabled = False
            ButtonDivineETSSetUser.Visible = False
            CheckboxWriteHardwareCode.Checked = False
            CheckboxWriteHardwareCode.Enabled = False
            CheckboxWriteCloudCode.Checked = False
            CheckboxWriteCloudCode.Enabled = False

            If profile.ToString.Contains("Pulsante") Then
                TextboxHardwareCode.Text = "A001571"
            ElseIf profile.ToString.Contains("Carrello") Then
                TextboxHardwareCode.Text = "A001572"
            ElseIf profile.ToString.Contains("Boot") Then
                CheckBoxJlink.Checked = True
                CheckboxWriteSerialNumber.Checked = False
                CheckboxWriteSerialNumber.Enabled = False
            End If

            'ElseIf profile.ToString.Contains("Carrello_Ancora") Or
            '    profile.ToString.Contains("Carrello_Tag") Or
            '    profile.ToString.Contains("Dista-Safe") Or
            '    profile.ToString.Contains("Tag") Then
            '    CheckBoxJlink.Checked = True
            '    CheckBoxJlink.Enabled = True
            '    CheckboxWriteSerialNumber.Checked = False
            '    CheckBoxAutoUploadSerial.Checked = False
            '    CheckboxWriteHardwareCode.Checked = False

            '    If istanzaDevice.isConnected() = True Then
            '        DropdownComPorts.Items.Add("jlink")
            '        MsgBox("jlink ok ")
            '        istanzaDevice.stopJlink()

            '    ElseIf istanzaDevice.isConnected = False Then
            '        MsgBox("jlink NOti ")
            '    End If
        End If

        CheckBoxHWSetupMoved.Checked = profile.ToString.Contains("ETSA")

        ComboBoxConf.Items.Clear()
        ComboBoxLabelType.Items.Clear()
        For Each Fail As String In Directory.GetFiles(Application.StartupPath & "\Bootloader\" & profile.ToString & "\")
            Dim percorso As String() = Fail.Split("\")
            If Fail.EndsWith(".cnf") Or Fail.EndsWith(".ets") Or Fail.EndsWith(".blpa") Or Fail.EndsWith(".mdt") Or Fail.EndsWith(".etsbak") Or Fail.EndsWith(".mdtbak") Then
                ComboBoxConf.Items.Add(percorso(percorso.Length - 1))
            End If

            If Fail.ToLower.EndsWith(".ld") Then
                ComboBoxLabelType.Items.Add(percorso(percorso.Length - 1))
            End If
        Next

        If ComboBoxConf.Items.Count > 0 Then
            ComboBoxConf.SelectedIndex = 0
            CheckboxCA.Checked = True
        Else
            ComboBoxConf.Text = ""
            CheckboxCA.Checked = False
        End If

        Me.Enabled = mainIsEnabled

        If SerialPort.PortName.StartsWith("COM") Then
            If SerialPort.BaudRate <> main_speed Then
                If SerialPort.IsOpen Then
                    SerialPort.Close()
                End If

                SerialPort.BaudRate = main_speed
            End If

            'If Not SerialPort.IsOpen Then
            '    SerialPort.Open()
            'End If

            Try
                If Not DropdownDevicesProfiles.Text = "ETSDN" Then
                    InitModem()
                    SetupConnectedDevice()
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub SetupConnectedDevice()
        If Not SerialPort.IsOpen Then
            SerialPort.Open()
        End If

        Dim deviceInfo As DeviceInfo = getConnectedDeviceInfo()

        If deviceInfo IsNot Nothing Then
            If deviceInfo.serial IsNot Nothing Then setSerialNumberInUI(deviceInfo.serial)
            If deviceInfo.cloudCode IsNot Nothing Then UI_ChangeControlText(TextboxCloudCode, deviceInfo.cloudCode)
        Else
            If TextboxSerialNumber.Text.Equals("") Then setSerialNumberInUI("")
            If TextboxCloudCode.Text.Length = 0 Then UI_ChangeControlText(TextboxCloudCode, "")
        End If
    End Sub

    'Public Sub Jlink() 'si apre jlink e si connette automaticamente e invia i comandi per mettere il fw 
    '    If DropdownDevicesProfiles.SelectedItem.ToString.Contains("Carrello_Ancora") Or DropdownDevicesProfiles.SelectedItem.ToString.Contains("Carrello_Tag") Or DropdownDevicesProfiles.SelectedItem.ToString.Contains("Tag") Then
    '    End If
    'End Sub

    Private Sub loadBaudrateConf(deviceProfile As String)
        If (File.Exists(Application.StartupPath & "\Bootloader\" & deviceProfile & "\spconf.txt")) Then
            Using sw As StreamReader = New StreamReader(Application.StartupPath & "\Bootloader\" & deviceProfile & "\spconf.txt")
                Dim speed = sw.ReadLine().Split(":")
                boot_speed = speed(0)
                If speed.Length > 1 Then
                    main_speed = speed(1)
                Else
                    main_speed = boot_speed
                End If
                If Not sw.EndOfStream Then _CP210xSerial = sw.ReadLine()
            End Using
        End If
    End Sub

    Private Function FindComWithDeviceConnected(serial As String) As String
        Dim ports = System.IO.Ports.SerialPort.GetPortNames
        If ports.Length = 0 Then
            Throw New Exception("Impossibile riconnettersi con il dispositivo")
        End If

        If Not ports.Contains(programmingPort) Then
            Throw New Exception("Impossibile riconnettersi con il dispositivo")
        End If

        'inCP210Action = True

        'If SerialPort.IsOpen Then
        '    SerialPort.Close()
        'End If

        'For Each p In ports
        '    SerialPort.PortName = p
        '    SerialPort.Open()

        '    Dim deviceInfo = RDW_Command("R00", MiaPorta:=SerialPort)
        '    If deviceInfo <> "Synchronized" And Not deviceInfo.Contains("|") Then
        '        Continue For
        '    End If

        '    SerialPort.Close()

        '    If Not deviceInfo.Equals("Synchronized") Then
        '        Dim responseTokens = deviceInfo.Split("|")
        '        Dim connSerial = responseTokens(2)
        '        If connSerial.Equals(serial) Then
        '            'UI_UpdateSerialPortInUse(p)
        '            inCP210Action = False
        '            Wait(1000)
        '            Return p
        '        End If
        '    Else
        '        'UI_UpdateSerialPortInUse(p)
        '        inCP210Action = False
        '        Wait(1000)
        '        Return p
        '    End If
        'Next

        'inCP210Action = False
        'Return ports(0)

        Return programmingPort
    End Function

    Private Sub BSNPS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSNPS.Click
        Try
            Dim cpConnId = WriteManufacturingInfo(TextboxCPSerialNumber.Text, TextboxCPProductString.Text)

            If FindComWithDeviceConnected(TextboxSerialNumber.Text) Is Nothing Then
                Throw New Exception("Impossibile riconnettersi con il dispositivo")
            End If
        Catch ex As Exception
            errorFlashing = True
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function WriteManufacturingInfo(sn As String, prodString As String) As IntPtr
        Dim DispositivoConnesso As IntPtr = 0

        systemStatus = "Writing CP210x"
        Dim oldst = systemStatus
        Try
            current_usb_vid = ""
            current_usb_pid = ""
            Dim encoding As New System.Text.UTF8Encoding()
            Dim SNString() As Byte
            Dim PRString() As Byte

            Dim SI_STATUS As Short

            inCP210Action = True
            If SerialPort.IsOpen Then
                SerialPort.Close()
            End If

            SNString = encoding.GetBytes(sn)
            PRString = encoding.GetBytes(prodString)

            CP210x_Open(CBVidPidSN.SelectedIndex, DispositivoConnesso)

            SI_STATUS = CP210x_SetSerialNumber(DispositivoConnesso, SNString(0), sn.Length, True)
            SI_STATUS = CP210x_SetProductString(DispositivoConnesso, PRString(0), prodString.Length, True)

            current_usb_vid = sn
            current_usb_pid = prodString

        Finally
            systemStatus = oldst
            inCP210Action = False
        End Try

        Return DispositivoConnesso
    End Function

    Private Sub CBVidPidSN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBVidPidSN.SelectedIndexChanged
        'If CBVidPidSN.Items.Count > 0 Then
        '    Dim SI_STATUS As Short
        '    Dim DispositivoConnesso As IntPtr = 0
        '    Dim Lenght As Byte
        '    Dim DevStr(255) As Byte
        '    Dim encoding As New System.Text.UTF8Encoding()
        '    CP210x_Open(CBVidPidSN.SelectedIndex, DispositivoConnesso)

        '    CP210x_GetDeviceSerialNumber(DispositivoConnesso, DevStr, Lenght, True)
        '    TBSN.Text = encoding.GetString(DevStr, 0, 4)
        '    CP210x_GetDeviceProductString(DispositivoConnesso, DevStr, Lenght, True)
        '    TBPS.Text = encoding.GetString(DevStr, 0, 4)
        '    SI_STATUS = CP210x_Close(DispositivoConnesso)
        '    SI_STATUS = SI_STATUS
        'End If

        'CPChanged(CBVidPidSN.SelectedIndex)
    End Sub

    Public Function ComboBoxPortale_Loading(sender As Object, e As EventArgs)

        Try
            ComboBox1.Items.Clear()
            prediction.refreshGRSatList(Sub()
                                            ComboBox1.Items.AddRange(prediction.allGRSatNames)
                                            If ComboBox1.Items.Count > 0 Then
                                                ComboBox1.SelectedIndex = 0
                                            End If
                                        End Sub)



        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Function
    Public Function ComboBoxUnit_Loading(sender As Object, e As EventArgs)

        Try
            ComboBox3.Items.Clear()
            prediction.refreshGRSatList(Sub()
                                            ComboBox3.Items.AddRange(prediction.allGRSatNames)
                                            If ComboBox3.Items.Count > 0 Then
                                                ComboBox3.SelectedIndex = 0
                                            End If
                                        End Sub)



        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Function

    Private Function FillCP()
        Dim deviceInfo As DeviceInfo = Nothing
        inCP210Action = True

        Try
            Dim cnt As ULong = 0
            Dim DevStr(255) As Byte
            Dim encoding As New System.Text.UTF8Encoding()
            Dim SI_STATUS As Short

            If SerialPort.IsOpen Then
                SerialPort.Close()
            End If

            SI_STATUS = CP210x_GetNumDevices(cnt)

            Dim items = New List(Of String)
            For i As Integer = 0 To cnt - 1
                CP210x_GetProductString(i, DevStr, 2)
                items.Add(encoding.GetString(DevStr))
            Next

            UI_UpdateCBVidPidSND(items.ToArray())

            If items.Count > 0 Or istanzaDevice.isconnected() = True Then
                UI_UpdateCBVidPidSNSelected(items(0))

                deviceInfo = CPChanged(0)
            Else
                Return Nothing
            End If

            formload = True
        Finally
            inCP210Action = False
        End Try

        Return deviceInfo
    End Function

    Private Function CPChanged(index As Integer) As DeviceInfo
        Dim SI_STATUS As Short
        Dim deviceInfo As DeviceInfo = Nothing
        Dim DispositivoConnesso As IntPtr = 0
        Dim DevStr(255) As Byte
        Dim encoding As New System.Text.UTF8Encoding()

        Try
            SI_STATUS = CP210x_Open(index, DispositivoConnesso)
            Dim Lenght As Byte
            SI_STATUS = CP210x_GetDeviceSerialNumber(DispositivoConnesso, DevStr, Lenght, True)
            Dim sn = encoding.GetString(DevStr, 0, Lenght)
            If sn <> "0001" Then
                deviceInfo = New DeviceInfo()
                UI_ChangeControlText(TextboxCPSerialNumber, sn)

                If sn = "MDTA1" Then
                    sn = "MDT_NEW"
                End If

                deviceInfo.type = sn
            ElseIf TextboxCPSerialNumber.Text = "" Then
                UI_ChangeControlText(TextboxCPSerialNumber, _CP210xSerial)
            End If

            SI_STATUS = CP210x_GetDeviceProductString(DispositivoConnesso, DevStr, Lenght, True)
            Dim prod = encoding.GetString(DevStr, 0, Lenght)
            UI_ChangeControlText(TextboxCPProductString, prod)
            If prod.Contains("|") Then
                Dim tokens = prod.Split("|")
                If tokens.Length > 1 Then
                    If deviceInfo Is Nothing Then
                        deviceInfo = New DeviceInfo()
                    End If

                    deviceInfo.serial = tokens(1)
                End If
            End If
        Finally
            If DispositivoConnesso <> 0 Then
                CP210x_Close(DispositivoConnesso)
            End If
        End Try

        Return deviceInfo
    End Function

    Public Function Formatta00(ByVal valore As String) As String
        If valore.Length = 1 Then
            Return "0" & valore
        End If
        Return valore
    End Function

    Private Sub InitCube()
        ' Create the cube vertices.
        m_vertices = New Point3D() {
                 New Point3D(-1, 1, -1),
                 New Point3D(1, 1, -1),
                 New Point3D(1, -1, -1),
                 New Point3D(-1, -1, -1),
                 New Point3D(-1, 1, 1),
                 New Point3D(1, 1, 1),
                 New Point3D(1, -1, 1),
                 New Point3D(-1, -1, 1)}

        ' Create an array representing the 6 faces of a cube. Each face is composed by indices to the vertex array
        ' above.
        m_faces = New Integer(,) {{0, 1, 2, 3}, {1, 5, 6, 2}, {5, 4, 7, 6}, {4, 0, 3, 7}, {0, 4, 5, 1}, {3, 2, 6, 7}}

        ' Define the colors of each face.
        m_colors = New Color() {Color.BlueViolet, Color.Cyan, Color.Green, Color.Yellow, Color.Violet, Color.LightSkyBlue}

        ' Create the brushes to draw each face. Brushes are used to draw filled polygons.
        For i = 0 To 5
            m_brushes(i) = New SolidBrush(m_colors(i))
        Next

    End Sub

    Private Sub BOffsetX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Call WAccelerometro(0)

            MsgBox("Calibrato")
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub MOffsetY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call WAccelerometro(1)

            MsgBox("Calibrato")
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub BOffseZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Call WAccelerometro(2)

            MsgBox("Calibrato")
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub CBOTG_CheckedChanged(sender As Object, e As EventArgs) Handles CBOTG.CheckedChanged
        If CBOTG.Checked Then
            If OFD.ShowDialog() = DialogResult.OK Then
                If File.Exists(OFD.FileName) Then
                    TextBoxOTGPAth.Text = OFD.FileName
                    CBOTG.Checked = True
                    Return
                End If
            End If
            CBOTG.Checked = False
        Else
            TextBoxOTGPAth.Text = ""
        End If
    End Sub

    Private Sub ButtonOTGBrowse_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NumericUpDownValoriCount_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDownValoriCount.ValueChanged
        Try
            With FlowLayoutPanelOffset.Controls
                While .Count < NumericUpDownValoriCount.Value
                    Dim newNUD As New NumericUpDown With {.Name = "NUDOFS_" & FlowLayoutPanelOffset.Controls.Count.ToString(),
                                                      .Size = New Size(98, 20),
                                                      .Minimum = 0,
                                                      .Maximum = Integer.MaxValue,
                                                      .Visible = True}
                    .Add(newNUD)
                    FlowLayoutPanelValue.Controls.Add(New TextBox With {.Name = "TBVAL_" & FlowLayoutPanelOffset.Controls.Count - 1.ToString(), .Size = New Size(98, 20)})
                    FlowLayoutPanelComando.Controls.Add(New TextBox With {.Name = "TBCMD_" & FlowLayoutPanelOffset.Controls.Count - 1.ToString(), .Size = New Size(98, 20)})
                    FlowLayoutPanelSerializza.Controls.Add(New CheckBox With {.Name = "CBSER_" & FlowLayoutPanelOffset.Controls.Count - 1.ToString(), .Text = "Serializza", .Size = New Size(98, 20)})
                    newNUD.Value = .Count - 1
                End While

                While .Count > NumericUpDownValoriCount.Value
                    .RemoveAt(.Count - 1)
                    With FlowLayoutPanelValue.Controls
                        .RemoveAt(.Count - 1)
                    End With
                    With FlowLayoutPanelComando.Controls
                        .RemoveAt(.Count - 1)
                    End With
                    With FlowLayoutPanelSerializza.Controls
                        .RemoveAt(.Count - 1)
                    End With
                End While
            End With

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub CBSerialNumber_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxWriteSerialNumber.CheckedChanged
        CheckBoxSerialAnagrafica.Checked = sender.checked
    End Sub

    Dim HotKeyAT As Boolean = False

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        STOPALL = True
        If Not checkSerialErrors() Or Not checkSerialUnsaved() Then
            e.Cancel = True
            Return
        End If
        'My.Settings.RemoteLOLID = TextBoxRemoteLOLID.Text
        My.Settings.Save()
    End Sub

    Private Function checkSerialUnsaved() As Boolean
        If Not CheckBoxAutoUploadSerial.Checked AndAlso newSerialUnsaved Then
            Return (MessageBox.Show("Sono stati assegnati uno o più nuovi seriali, ma non li hai registrati sul server. Davvero vuoi continuare?", "", MessageBoxButtons.YesNo) = DialogResult.Yes)
        End If
        Return True
    End Function

    Private Function checkSerialErrors() As Boolean
        For Each serial In ListBoxSeriali.Items
            If serial.ToString().ToLower().Contains("upload") Then
                Return (MessageBox.Show("Sono stati registrati errori di upload di uno o più seriali. Davvero vuoi continuare?", "", MessageBoxButtons.YesNo) = DialogResult.Yes)
            End If
        Next
        Return True
    End Function

    'Sub sendHeartLOL()
    '    Dim sendbuf As Byte() = Encoding.ASCII.GetBytes(prepareHeartLOL())
    '    s.SendTo(sendbuf, ep)
    'End Sub


    'Sub sendMiniHR()

    '    Dim sendbuf As Byte() = Encoding.ASCII.GetBytes("HelloFL|" & myUID & "|" & Environment.MachineName & "|" & Environment.UserName)
    '    s.SendTo(sendbuf, ep)
    'End Sub

    Sub parseMiniHR(hrData As String())
        Try
            Dim clean As New List(Of DataGridViewRow)
            If hrData.Length < 3 Then Return

            Dim found = False
            For Each row As DataGridViewRow In DataGridViewRemoteLolMinHR.Rows
                If row.Cells(0).Value Is Nothing Then Continue For

                Dim oldness = DateTime.Now.Subtract(DateTime.Parse(Now.ToShortDateString() & " " & row.Cells(3).Value)).Seconds

                If oldness > 15 Then
                    clean.Add(row)
                ElseIf oldness > 10 Then
                    row.DefaultCellStyle.BackColor = Color.Orange
                ElseIf oldness > 1 Then
                    row.DefaultCellStyle.BackColor = Color.White
                Else
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                End If

                If row.Cells(0).Value.Equals(hrData(2)) Then
                    'è già in lista
                    found = True
                    row.Cells(1).Value = hrData(3)
                    row.Cells(2).Value = hrData(4)
                    row.Cells(3).Value = Now.ToLongTimeString()
                    Continue For
                End If
            Next

            If hrData(2).Equals(myUID) Then Exit Try ' il messaggio arriva da me, ignora

            'If Not found Then
            '    DataGridViewRemoteLolMinHR.Rows.Add(hrData(2), hrData(3), hrData(4), Now.ToLongTimeString())
            '    MessageBox.Show("Una nuova istanza di FlashedLOL è stata avviata da " & hrData(4) & " sul PC " & hrData(3), "ACHTUNG!!!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'End If


        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub


    'Function prepareHeartLOL() As String

    '    Dim HL As String = ""
    '    HL &= instance.TextBoxRemoteLOLID.Text & "|"
    '    HL &= IIf(CheckBoxRemoteLolMaster.Checked, "1", "0") & "|"
    '    HL &= systemStatus & "|"
    '    HL &= confirmed_device & "|"
    '    HL &= confirmed_HW & "|"
    '    HL &= confirmed_Serial & "|"
    '    HL &= TBserialnumber.Value.ToString() & "|"
    '    HL &= IIf(iNeedFreshSerial, "1", "0") & "|"
    '    HL &= currentLabelData.Replace("®", "$") & "|"
    '    Return HL
    'End Function


    'Private Sub startLoLIstener()
    '    If remoteLOListener IsNot Nothing Then Return
    '    remoteLOListener = New UDPListener()
    'End Sub


    'Private Sub stopLoListener()
    '    remoteLOListener.dispose()
    '    remoteLOListener = Nothing
    'End Sub

    Private Sub mngF5Button(bAlt As Boolean)
        If bAlt Then
            If ButtonStop.Enabled And ButtonStop.Visible Then
                ButtonStop.PerformClick()
            End If
        Else
            ButtonStart.PerformClick()
        End If
    End Sub

    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Windows.Forms.Keys.F5 Then
                mngF5Button(e.Alt)
            End If

            If e.Control And e.Alt And e.KeyCode = Windows.Forms.Keys.KeyCode.A Then HotKeyAT = True

            If e.Control And e.Alt And e.KeyCode = Windows.Forms.Keys.KeyCode.T Then
                'loadBaudrateConf()
                Dim use_speed = 115200
                If boot_speed <> main_speed Then
                    If MessageBox.Show("Premere SI se il disp. è nel boot, altrimenti NO", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                        use_speed = boot_speed
                    Else
                        use_speed = main_speed
                    End If
                Else
                    use_speed = boot_speed
                End If
                Dim closedoor = openCOMPort(use_speed)

                MessageBox.Show(RDW_Command(InputBox("Inserire comando AT")))
                If SerialPort.IsOpen And closedoor Then SerialPort.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        End Try
    End Sub


    Function openCOMPort(port_speed) As Boolean
        Dim closeDoor As Boolean
        Try
            If SerialPort.IsOpen Then
                closeDoor = False
            Else
                closeDoor = True
                SerialPort.BaudRate = port_speed
                'SerialPort.PortName = CBCom.SelectedItem.ToString()
                SerialPort.Open()
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return closeDoor
    End Function

    Private Sub BZAccelerometro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            Call WAccelerometro(3)

            MsgBox("Calibrato")
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub CalibrazioneAutomatica()

        MsgBox("Calibrazione asse X")
        Call WAccelerometro(0)
        PBCalibrazione.Value += 1
        MsgBox("Calibrazione asse Y")
        Call WAccelerometro(1)
        PBCalibrazione.Value += 1
        MsgBox("Calibrazione asse Z")
        Call WAccelerometro(2)
        PBCalibrazione.Value += 1
        MsgBox("0 Accelerometro")
        Call WAccelerometro(3)
        PBCalibrazione.Value += 1


    End Sub


    'Private Sub TimerHeartRate_Tick(sender As Object, e As EventArgs) Handles TimerHeartRate.Tick
    '    If collaudoOpened Then
    '        Return
    '    End If

    '    sender.stop()

    '    Try
    '        sendMiniHR()

    '        'If CheckBoxDivineSync.Checked Then

    '        '    checkIDUniquity()

    '        '    If CheckBoxRemoteLolMaster.Checked Then
    '        '        checkMasterUniquity()
    '        '        'mng_remoteSerialRqs()
    '        '    End If
    '        '    sendHeartLOL()
    '        'End If

    '        Me.Text = "FlashedLOL - " & systemStatus
    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try
    '    sender.start()
    'End Sub

    'Private Sub checkIDUniquity()
    '    If DataGridViewRemoteLol.Rows.Count = 0 Then Return
    '    Try
    '        Dim duplicato As Boolean = True
    '        While duplicato

    '            For Each row As DataGridViewRow In DataGridViewRemoteLol.Rows
    '                If row.Cells(ID.Index).Value.Equals(TextBoxRemoteLOLID.Text) Then
    '                    duplicato = True
    '                    Exit For
    '                Else
    '                    duplicato = False
    '                End If
    '            Next

    '            If duplicato Then
    '                TextBoxRemoteLOLID.Text &= "_copy"
    '            End If

    '        End While
    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try
    'End Sub

    'Private Sub checkMasterUniquity()
    '    Try
    '        For Each row As DataGridViewRow In DataGridViewRemoteLol.Rows
    '            If row.Cells(IsMaster.Index).Value.Equals("1") Then
    '                CheckBoxRemoteLolMaster.Checked = False
    '                Exit Try
    '            End If
    '        Next
    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try
    'End Sub

    'Private Sub ButtonCreateCSV_Click(sender As Object, e As EventArgs) Handles ButtonCreateCSV.Click
    '    Try
    '        Dim sfd As New SaveFileDialog()
    '        sfd.Title = "Crea file etichette"
    '        sfd.Filter = "File csv|.csv"
    '        sfd.CheckPathExists = True
    '        sfd.FileName = "Etichette_produzione_" & Now.Day & "-" & Now.Month & "-" & Now.Year & "_" & Now.ToShortTimeString().Replace(":", "-") & ".csv"
    '        If sfd.ShowDialog() = DialogResult.OK Then
    '            If Not sfd.FileName.EndsWith(".csv") Then sfd.FileName &= ".csv"
    '            If File.Exists(sfd.FileName) Then File.Delete(sfd.FileName)

    '            Using sw As New StreamWriter(sfd.FileName, FileMode.CreateNew, Encoding.Default)
    '                'sw.WriteLine("sep=,")
    '                For Each eti As etichetta In bufferEtichette
    '                    With eti
    '                        sw.WriteLine(
    '                                .MODEL_CODE & "," &
    '                                .MODEL_NAME & "," &
    '                                .MODEL_DESC & "," &
    '                                .SERIAL & "," &
    '                                .DC_IN & "," &
    '                                .mA_IN & ",") ' &
    '                        '.CE_YEAR)
    '                    End With
    '                Next
    '            End Using
    '        End If

    '        Process.Start("explorer.exe", "/select," & sfd.FileName)

    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try
    'End Sub


    Private Sub ButtonCreateCSV_Click(sender As Object, e As EventArgs) Handles ButtonCreateCSV.Click
        Try
            Dim sfd As New SaveFileDialog()
            sfd.Title = "Crea file etichette"
            sfd.Filter = "Database mdb|.mdb"
            sfd.CheckPathExists = True
            sfd.FileName = "Etichette_produzione_" & Now.Day & "-" & Now.Month & "-" & Now.Year & "_" & Now.ToShortTimeString().Replace(":", "-") & ".mdb"
            If sfd.ShowDialog() = DialogResult.OK Then
                createDB(sfd.FileName)
                For Each eti As etichetta In bufferEtichette
                    With eti
                        query_run("INSERT INTO TEtichette (MODEL_CODE, MODEL_NAME, MODEL_DESC, SERIAL, DC_IN, mA_IN)" &
                              " VALUES(@code, @model, @desc, @serial, @dc, @ma)",
                              New String()() {
                              New String(1) {"@code", .MODEL_CODE},
                              New String(1) {"@model", .MODEL_NAME},
                              New String(1) {"@desc", .SERIAL},
                              New String(1) {"@serial", .SERIAL},
                              New String(1) {"@dc", .DC_IN},
                              New String(1) {"@ma", .mA_IN}
                              })
                    End With
                Next
            End If


            MsgBox("Esportazione completata")
            Process.Start(sfd.FileName.Substring(0, sfd.FileName.LastIndexOf("\")))

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub


    Public con As New OleDbConnection
    Public cmd As New OleDbCommand
    Public Sub createDB(path As String)
        Try

            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path
            Dim cat As Catalog = New Catalog()
            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path & ";Jet OLEDB:Engine Type=5")

            If con.State = ConnectionState.Closed Then con.Open()


            query_run("CREATE TABLE [TEtichette]" &
                               "(" &
                               "[MODEL_CODE] NTEXT NOT NULL, " &
                               "[MODEL_NAME] NTEXT, " &
                               "[MODEL_DESC] NTEXT, " &
                               "[SERIAL] NTEXT, " &
                               "[DC_IN] NTEXT, " &
                               "[mA_IN] NTEXT)")


        Catch ex As Exception
            AggiornaLog(ex)
        End Try

        con.Close()

    End Sub


    Public Sub query_run(query As String, Optional key_value As String()() = Nothing, Optional runs As Integer = 1, Optional prgBar As ProgressBar = Nothing)
        If con.State = ConnectionState.Closed Then con.Open()
        cmd = New OleDbCommand(query, con)
        If Not IsNothing(key_value) Then
            For Each hash In key_value
                If hash.Length >= 2 Then
                    cmd.Parameters.AddWithValue(hash(0), hash(1))
                End If
            Next
        End If
        If Not IsNothing(prgBar) Then
            prgBar.Value = 0
            prgBar.Maximum = runs
            prgBar.Step = 1
        End If

        For i = 0 To runs - 1
            If Not IsNothing(prgBar) Then prgBar.PerformStep()
            cmd.ExecuteNonQuery()
        Next
        cmd.Dispose()
        con.Close()
    End Sub


    'Private Sub mng_remoteSerialRqs()
    '    Try
    '        Dim currentConfirmed As New List(Of String)

    '        For Each row As DataGridViewRow In DataGridViewRemoteLol.Rows
    '            If row.Cells(NeedsNewSerial.Index).Value IsNot Nothing AndAlso row.Cells(NeedsNewSerial.Index).Value.Equals("1") Then
    '                sendFreshSerial(row.Cells(ID.Index).Value, row)
    '            End If

    '            If row.Cells(ConfirmedSerial.Index).Value IsNot Nothing And row.Cells(ConfirmedSerial.Index).Value.ToString.Length > 1 Then
    '                currentConfirmed.Add(row.Cells(ConfirmedSerial.Index).Value)
    '                addEtichetta(row)
    '            End If
    '        Next

    '        For Each conf In currentConfirmed

    '            If Not ListBoxSeriali.Items.Contains(conf) And Not ListBoxSeriali.Items.Contains(conf & " - confermato") Then
    '                ListBoxSeriali.Items.Add(conf & " - confermato")
    '                Continue For
    '            End If

    '            Dim find = ListBoxSeriali.Items.IndexOf(conf)
    '            If find >= 0 Then
    '                ListBoxSeriali.Items(find) = conf & " - confermato"
    '                Exit For
    '            End If
    '        Next

    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try
    'End Sub

    'Private Sub CheckBoxRemoteLolMaster_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRemoteLolMaster.CheckedChanged
    '    If CheckBoxRemoteLolMaster.Checked Then
    '        MsgBox("Hai impostato questo PC come Master!" & vbCrLf & "RICORDA che il PC Master NON deve avere dispositivi collegati!")
    '        TBserialnumber.Value = New String(Now.Year.ToString().Substring(2, 2) & Formatta00(Now.Month) & "00001")
    '    End If
    'End Sub

    Private Sub ListBoxSeriali_DoubleClick(sender As Object, e As EventArgs) Handles ListBoxSeriali.DoubleClick
        If ListBoxSeriali.SelectedIndex >= 0 AndAlso ListBoxSeriali.SelectedItem IsNot Nothing Then
            If MessageBox.Show("Recuperare il seriale " & ListBoxSeriali.SelectedItem.ToString.Split("-")(0).ToString().Trim() & "?", "", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                serialiDaRecuperare.Add(ListBoxSeriali.SelectedItem.ToString.Split("-")(0).ToString().Trim())
                ListBoxSeriali.Items.RemoveAt(ListBoxSeriali.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub ComboBoxLabelType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxLabelType.SelectedIndexChanged
        If ComboBoxLabelType.SelectedItem IsNot Nothing AndAlso ComboBoxLabelType.SelectedItem.ToString.Length < 1 Then Exit Sub
        Try
            Using sr As New StreamReader(Application.StartupPath & "\Bootloader\" & DropdownDevicesProfiles.SelectedItem.ToString() & "\" & ComboBoxLabelType.SelectedItem.ToString(), Encoding.UTF8)
                currentLabelData = sr.ReadLine()
            End Using

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonReadWiFly.Click
        NumericUpDownValoriCount.Value += 1
        Try
            FlowLayoutPanelComando.Controls.Find("TBCMD_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "RW3"
            FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "0"
            FlowLayoutPanelValue.Controls.Find("TBVAL_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = ""
            Dim a As CheckBox = (FlowLayoutPanelSerializza.Controls.Find("CBSER_" & NumericUpDownValoriCount.Value - 1, False)(0))
            a.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles ButtonUpdateWiFly.Click
        NumericUpDownValoriCount.Value += 1
        Try
            FlowLayoutPanelComando.Controls.Find("TBCMD_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "WW3"
            FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "0"
            FlowLayoutPanelValue.Controls.Find("TBVAL_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = ""
            Dim a As CheckBox = (FlowLayoutPanelSerializza.Controls.Find("CBSER_" & NumericUpDownValoriCount.Value - 1, False)(0))
            a.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub Main_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        form_opening = False
    End Sub

    Private Sub ButtonBLESETId_Click(sender As Object, e As EventArgs) Handles ButtonBLESETId.Click
        NumericUpDownValoriCount.Value += 1
        Try
            FlowLayoutPanelComando.Controls.Find("TBCMD_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "W08"
            FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "55001"
            FlowLayoutPanelValue.Controls.Find("TBVAL_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "1"
            Dim a As CheckBox = (FlowLayoutPanelSerializza.Controls.Find("CBSER_" & NumericUpDownValoriCount.Value - 1, False)(0))
            a.Checked = True
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        End Try
    End Sub

    Sub addEtichetta(row As DataGridViewRow)
        Try
            Dim dati = row.Cells(ConfirmedEtichettaData.Index).Value.ToString().Split("~")
            If dati.Length >= 6 Then 'Throw New Exception("La stringa LabelData ricevuta non è valida")
                addEtichettaRaw(dati(0), dati(2), dati(1), row.Cells(ConfirmedSerial.Index).Value, dati(3), dati(4), dati(5))
            End If
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Select Case CInt(item.Tag)

            Case 0
                Dim count As Integer = "0" & InputBox("Quante etichette vuoi generare?" & vbCrLf & "Inserire 0 per annullare", 0)
                If count = 0 Then Return
                If MessageBox.Show("Verranno create " & count & " etichette" & vbCrLf & "Seriali dal " & TextboxSerialNumber.Text & " al " & TextboxSerialNumber.Text + count - 1, "Conferma", MessageBoxButtons.OKCancel) = DialogResult.OK Then
                    While count > 0
                        addEtichettaFromCurrentSerial()
                        ListBoxSeriali.Items.Add(TextboxSerialNumber.Text)

                        Dim int = Convert.ToInt32(TextboxSerialNumber.Text)
                        int += 1

                        TextboxSerialNumber.Text = int.ToString()
                        count -= 1
                    End While

                    'askSerialUpload()

                End If


            Case 1
                ButtonGenerateSerialNumber.Enabled = True

            Case 2
                'askSerialUpload()

        End Select
    End Sub

    'Sub askSerialUpload()
    '    If MessageBox.Show("Salvare sul server questo seriale come libero?", "MegaFunc!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
    '        uploadSerialNumber()
    '    End If
    'End Sub


    'Sub downloadSerialNumber()
    '    showWait("Download seriale libero in corso...")
    '    Dim oldLocal = FTP.LOCAL_BASE_PATH
    '    Try
    '        TBserialnumber.Value = _downloadSerial()
    '        If TBserialnumber.Value.ToString() > 8 Then
    '            Dim yy = TBserialnumber.Value.ToString().Substring(0, 2)
    '            Dim mm = TBserialnumber.Value.ToString().Substring(2, 2)
    '            If mm <> Formatta00(Now.Month) OrElse yy <> Now.Year.ToString().Substring(2, 2) Then
    '                MsgBox("Attenzione, il seriale impostato non rappresenta la data corrente")
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Errore! Riprova, dai" & vbCrLf & ex.Message)
    '    Finally
    '        FTP.LOCAL_BASE_PATH = oldLocal
    '        disposeWait()
    '    End Try
    'End Sub


    Function _downloadSerial() As Integer
        CercaFile.CercaFile_Shown(Nothing, Nothing)
        Try
            If File.Exists(Application.StartupPath & "\tmpSerial.txt") Then File.Delete(Application.StartupPath & "\tmpSerial.txt")
            FTP.LOCAL_BASE_PATH = Application.StartupPath
            For Each fil In FTP.Get_FileList("")
                If fil.name.Equals("tmpSerial.txt") Then
                    If FTP.downloadFile(fil.name, "") = "KO" Then Throw New Exception
                    Using sr As New StreamReader(Application.StartupPath & "\tmpSerial.txt")
                        Dim red As String = sr.ReadToEnd
                        If Not IsNumeric(red) Then
                            MsgBox("Contenuto del file corrotto")
                        Else
                            Return red
                        End If
                    End Using
                    Exit For
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return -1
    End Function

    'Function uploadSerialNumber(Optional setBusy As Boolean = False) As Boolean
    '    Dim result = False
    '    showWait("Comunicazione con il server in corso...")
    '    Dim oldLocal = FTP.LOCAL_BASE_PATH
    '    Dim currSerial = TBserialnumber.Value
    '    If setBusy Then currSerial += 1
    '    Try
    '        Dim srvSerial = _downloadSerial()
    '        If srvSerial >= currSerial Then
    '            If MessageBox.Show("!! ACHTUNG !!" &
    '                           vbCrLf &
    '                           "Il seriale corrente potrebbe essere già utilizzato!" &
    '                           vbCrLf &
    '                           "Secondo il server, " & srvSerial - 1 & " è l'ultimo seriale utilizzato" & vbCrLf & "Continuare l'upload comunque?",
    '                           "!! ACHTUNG !!",
    '                           MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) <> DialogResult.Yes Then
    '                Exit Try
    '            End If
    '        End If
    '        CercaFile.CercaFile_Shown(Nothing, Nothing)
    '        FTP.LOCAL_BASE_PATH = Application.StartupPath
    '        File.WriteAllText(Application.StartupPath & "\tmpSerial.txt", currSerial.ToString())
    '        If FTP.uploadFile(Application.StartupPath, "tmpSerial.txt", "") = "OK" Then
    '            'MsgBox("Upload completato =)")
    '            result = True
    '            newSerialUnsaved = False
    '        Else
    '            Throw New Exception()
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Errore! Impossibile impostare il seriale. Prima di riprovare verifica il file sul server!" & vbCrLf & ex.Message)
    '    Finally
    '        FTP.LOCAL_BASE_PATH = oldLocal
    '        disposeWait()
    '    End Try
    '    Return result
    'End Function

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As MouseEventArgs) Handles LinkLabel1.Click
        Dim cms = New ContextMenuStrip
        Dim item0 = cms.Items.Add("Genera etichetta")
        item0.Tag = 0
        AddHandler item0.Click, AddressOf menuChoice

        Dim item1 = cms.Items.Add("Genera nuovo seriale")
        item1.Tag = 1
        AddHandler item1.Click, AddressOf menuChoice

        'Dim item2 = cms.Items.Add("Salva S/N libero")
        'item2.Tag = 2
        'AddHandler item2.Click, AddressOf menuChoice

        cms.Show(sender, e.Location)
    End Sub

    'Private Sub ButtonForceAutoNext_Click(sender As Object, e As EventArgs) Handles ButtonForceAutoNext.Click
    '    forceAutoNext = True
    'End Sub

    Private Sub ButtonPredictionLogin_Click(sender As Object, e As EventArgs) Handles ButtonPredictionLogin.Click
        If TextboxPredictionHost.Text.Length < 3 Or TextboxPredictionUsername.Text.Length < 3 Or TextboxPredictionPassword.Text.Length < 3 Then
            LabelPredictionLoginStatus.Text = "Formato credenziali invalido"
            MsgBox("Formato credenziali invalido")
            Return
        End If

        Try
            showWait("Tentativo di login")
            prediction = New Prediction(TextboxPredictionHost.Text, TextboxPredictionUsername.Text, TextboxPredictionPassword.Text)

            Dim result = checkPrediction()
            LabelPredictionLoginStatus.Text = [Enum].GetName(GetType(Cloud.LOGIN_RESULT), result)
            GroupBoxGRSatLogin.Enabled = (result = Cloud.LOGIN_RESULT.SUCCED)
            If GroupBoxGRSatLogin.Enabled Then
                LinkLabelUpdateGRSatList_LinkClicked(Nothing, Nothing)
            End If

            CheckboxConfigureDeviceOnGRSat.Checked = CheckboxWriteCloudCode.Checked
            CheckboxCreateDeviceOnGRSat.Checked = CheckboxWriteCloudCode.Checked

            GroupBox7.Enabled = CheckboxWriteCloudCode.Checked
            CheckBoxAutoFillAssetData.Checked = CheckboxWriteCloudCode.Checked
        Catch ex As Exception
            LabelPredictionLoginStatus.Text = "Login fallito"
            AggiornaLog(ex)
        End Try
        disposeWait()
    End Sub


    Public Function checkPrediction() As Cloud.LOGIN_RESULT
        If prediction Is Nothing Then
            ButtonPredictionLogin_Click(Nothing, Nothing)
        End If
        Return prediction.login()
    End Function


    Private Sub LinkLabelUpdateGRSatList_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelUpdateGRSatList.LinkClicked
        Try
            DropdownGRSatSelection.Items.Clear()
            prediction.refreshGRSatList(Sub()
                                            DropdownGRSatSelection.Items.AddRange(prediction.allGRSatNames)
                                            If DropdownGRSatSelection.Items.Count > 0 Then
                                                DropdownGRSatSelection.SelectedIndex = 0
                                            End If
                                        End Sub)

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub


    Public Sub ButtonPWP_stop_Click(sender As Object, e As EventArgs) Handles ButtonPWP_stop.Click
        'elaborando = False
        pwfStopLoading = True
        'StopLookingforSD = True
        'If allowATstop Then
        'etsDev.forceQuitATcmd = True
        ' End If
    End Sub


    Private Sub ButtonStorePredictionLogin_Click(sender As Object, e As EventArgs) Handles ButtonStorePredictionLogin.Click
        My.Settings.PredHost = TextboxPredictionHost.Text
        My.Settings.PredUn = TextboxPredictionUsername.Text
        My.Settings.PredPw = TextboxPredictionPassword.Text
        My.Settings.Save()
        MsgBox("Credenziali salvate")
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles ButtonGRSatLogin.Click
        Try

            If IsNothing(selectedGRSat) Then
                MsgBox("Nessun portale selezionato")
                Return
            End If
            showWait("Tentativo di login a " & selectedGRSat.friendlyName)

            Dim result = Nothing
            ' Ack per problemi ereditarietà
            If TypeOf selectedGRSat Is GRSatBonatti Then
                result = CType(selectedGRSat, GRSatBonatti).login()
            Else
                result = selectedGRSat.login()
            End If

            LabelGRSatLoginStatus.Text = [Enum].GetName(GetType(Cloud.LOGIN_RESULT), result)

            GroupBox7.Enabled = result = Cloud.LOGIN_RESULT.SUCCED

            If GroupBox7.Enabled Then
                LinkLabelAssetLoadSheets_LinkClicked(Nothing, Nothing)
                loadUnits()
            End If

            CheckBoxCloudCfg_CheckedChanged(CheckboxWriteCloudCode, Nothing)

        Catch ex As Exception
            LabelGRSatLoginStatus.Text = "Login fallito"
            AggiornaLog(ex)
        End Try
        disposeWait()
    End Sub

    Private Sub ComboBoxGRSatList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropdownGRSatSelection.SelectedIndexChanged
        selectedGRSat = Nothing
        CheckboxCreateDeviceOnGRSat.Text = CheckboxCreateDeviceOnGRSat.Tag & "[CHOOSE ONE!]"
        CheckboxConfigureDeviceOnGRSat.Text = CheckboxConfigureDeviceOnGRSat.Tag & "[CHOOSE ONE!]"

        If Not IsNothing(DropdownGRSatSelection.SelectedItem) AndAlso DropdownGRSatSelection.SelectedItem.ToString().Length > 0 Then
            CheckboxCreateDeviceOnGRSat.Text = CheckboxCreateDeviceOnGRSat.Tag & DropdownGRSatSelection.SelectedItem.ToString
            CheckboxConfigureDeviceOnGRSat.Text = CheckboxConfigureDeviceOnGRSat.Tag & DropdownGRSatSelection.SelectedItem.ToString
            selectedGRSat = prediction.getGRSatByName(DropdownGRSatSelection.SelectedItem)
        End If

        LabelGRSatLoginStatus.Text = "Undefined"
        GroupBox7.Enabled = False
    End Sub

    Private Sub CheckBoxCloudCfgAutomatic_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxConfigureDeviceOnGRSat.CheckedChanged
        CheckBoxTestInvioCloud.Enabled = CheckboxCreateDeviceOnGRSat.Enabled And CheckboxCreateDeviceOnGRSat.Checked
        ButtonAssetCreate.Enabled = Not sender.checked

        If CheckboxCreateDeviceOnGRSat.Enabled <> CheckboxConfigureDeviceOnGRSat.Checked Then
            CheckboxCreateDeviceOnGRSat.Enabled = CheckboxConfigureDeviceOnGRSat.Checked
        End If

        Try
            cmd_cloudCfg_httphost = ""
            cmd_cloudCfg_ftphost = ""
            cmd_cloudCfg_ftpuser = ""
            cmd_cloudCfg_ftppasw = ""

            If CheckboxConfigureDeviceOnGRSat.Checked Then

                Using sr As New StreamReader(Application.StartupPath & "\Bootloader\" & DropdownDevicesProfiles.SelectedItem.ToString & "\cloudcfg.txt")
                    While Not sr.EndOfStream
                        Dim line = sr.ReadLine().Trim()
                        If Not line.StartsWith("$") Then Continue While

                        If cmd_cloudCfg_httphost.Equals("") Then
                            cmd_cloudCfg_httphost = line
                            Continue While
                        End If

                        If cmd_cloudCfg_ftphost.Equals("") Then
                            cmd_cloudCfg_ftphost = line
                            Continue While
                        End If

                        If cmd_cloudCfg_ftpuser.Equals("") Then
                            cmd_cloudCfg_ftpuser = line
                            Continue While
                        End If

                        If cmd_cloudCfg_ftppasw.Equals("") Then
                            cmd_cloudCfg_ftppasw = line
                            Continue While
                        End If

                    End While
                End Using

                If Not cmd_cloudCfg_httphost.Equals("") And Not cmd_cloudCfg_ftphost.Equals("") And Not cmd_cloudCfg_ftpuser.Equals("") And Not cmd_cloudCfg_ftppasw.Equals("") Then
                    CheckboxConfigureDeviceOnGRSat.ForeColor = Color.Green
                Else
                    CheckboxConfigureDeviceOnGRSat.ForeColor = Color.Red
                End If

            Else
                CheckboxConfigureDeviceOnGRSat.ForeColor = Color.Black
            End If

        Catch ex As Exception
            AggiornaLog(ex)
            sender.checked = False
            CheckboxConfigureDeviceOnGRSat.ForeColor = Color.Red
            cmd_cloudCfg_httphost = ""
            cmd_cloudCfg_ftphost = ""
            cmd_cloudCfg_ftpuser = ""
            cmd_cloudCfg_ftppasw = ""
        End Try
    End Sub

    Private Sub CheckBoxCloudCfg_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxWriteCloudCode.CheckedChanged
        CheckboxConfigureDeviceOnGRSat.Enabled = CheckboxWriteCloudCode.Checked
        CheckboxCreateDeviceOnGRSat.Enabled = CheckboxConfigureDeviceOnGRSat.Enabled And CheckboxConfigureDeviceOnGRSat.Checked

        If GroupBoxGRSatLogin.Enabled And DropdownDevicesProfiles.SelectedIndex > 0 Then
            CheckboxConfigureDeviceOnGRSat.Checked = CheckboxWriteCloudCode.Checked
            CheckboxCreateDeviceOnGRSat.Checked = CheckboxWriteCloudCode.Checked

            GroupBox7.Enabled = CheckboxWriteCloudCode.Checked
            CheckBoxAutoFillAssetData.Checked = CheckboxWriteCloudCode.Checked
        End If
    End Sub

    Private Sub LinkLabelAssetLoadUnits_Clicked(sender As Object, e As MouseEventArgs) Handles LinkLabelAssetLoadUnits.Click
        Dim cms = New ContextMenuStrip
        Dim item1 = cms.Items.Add("Nuova unit")
        item1.Tag = 2
        AddHandler item1.Click, AddressOf unitChoice
        Dim item2 = cms.Items.Add("Ricarica lista")
        item2.Tag = 1
        AddHandler item2.Click, AddressOf unitChoice
        cms.Show(sender, e.Location)

    End Sub

    Sub loadUnits()
        CBAssetUnit.Items.Clear()

        If TypeOf selectedGRSat Is GRSatBonatti Then
            CBAssetUnit.Items.AddRange(CType(selectedGRSat, GRSatBonatti).getUnits().ToArray())
        Else
            CBAssetUnit.Items.AddRange(selectedGRSat.getUnits().ToArray())
        End If

        If CBAssetUnit.Items.Count > 0 Then CBAssetUnit.SelectedIndex = 0
    End Sub


    Private Sub unitChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Select Case CInt(item.Tag)

            Case 1
                loadUnits()

            Case 2
                Dim nam = InputBox("Aggiungi una unit al portale " & selectedGRSat.friendlyName, "MegaFunc!", "New unit")
                Dim uid = -1

                If nam.Length > 0 Then
                    If TypeOf selectedGRSat Is GRSatBonatti Then
                        uid = CType(selectedGRSat, GRSatBonatti).creaUnit(nam)
                    Else
                        uid = selectedGRSat.creaUnit(nam)
                    End If

                    If uid <= 0 Then MsgBox("Errore nella creazione della unit")
                Else
                    MsgBox("Nome unit non valido")
                End If
                loadUnits()
                For i = 0 To CBAssetUnit.Items.Count - 1
                    If CBAssetUnit.Items(i).ToString.Split("-")(0).Trim.Equals(uid.ToString) Then
                        CBAssetUnit.SelectedIndex = i
                        Exit For
                    End If
                Next


        End Select
    End Sub



    Private Sub LinkLabelAssetLoadSheets_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelAssetLoadSheets.LinkClicked
        CBAssetSheet.Items.Clear()
        If TypeOf selectedGRSat Is GRSatBonatti Then
            CBAssetSheet.Items.AddRange(CType(selectedGRSat, GRSatBonatti).getSheets().ToArray())
        Else
            CBAssetSheet.Items.AddRange(selectedGRSat.getSheets().ToArray())
        End If
        If CBAssetSheet.Items.Count > 0 Then CBAssetSheet.SelectedIndex = 0
    End Sub

    Private Sub ButtonAssetCreate_Click(sender As Object, e As EventArgs) Handles ButtonAssetCreate.Click
        creaAsset(sender)
    End Sub

    Function creaAsset(Optional sender As Object = Nothing) As Integer
        Dim resultID As Integer = -1
        Try
            If Not GroupBox7.Enabled Then Return -1
            showWait("Creazione asset in corso")

            If TypeOf selectedGRSat Is GRSatBonatti Then
                Dim g = CType(selectedGRSat, GRSatBonatti)
                'CType(selectedGRSat, GRSatBonatti).creaDevice(TextboxSerialNumber.Text, DropdownDevicesProfiles.SelectedItem & "_" & TextboxSerialNumber.Text, TextboxCloudCode.Text, TextBoxCloudPw.Text),
                resultID = g.creaAsset(
                    CType(selectedGRSat, GRSatBonatti).creaDevice(TextboxSerialNumber.Text, DropdownDevicesProfiles.SelectedItem & "_" & TextboxSerialNumber.Text, TextboxCloudCode.Text, TextBoxCloudPw.Text),
                    "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "")
                'TBAssetDesc.Text, TBAssetBrand.Text, TBAssetSerial.Text, TBAssetModel.Text, TBAssetPlate.Text,
                '        IIf(CBAssetUnit.SelectedItem IsNot Nothing, CBAssetUnit.SelectedItem.split("-")(0).ToString().Trim(), Nothing),
                '        IIf(CBAssetSheet.SelectedItem IsNot Nothing, CBAssetSheet.SelectedItem.split("-")(0).ToString().Trim(), Nothing),
                '        IIf(CBAssetProfile.Checked, 1, 0),
                '        IIf(CBAssetGPS.Checked, 1, 0),
                '        IIf(CBAssetRSSI.Checked, 1, 0),
                '        IIf(CBAssetMeter1.Checked, 1, 0),
                '        IIf(CBAssetMeter2.Checked, 1, 0),
                '        IIf(CBAssetAlarm.Checked, 1, 0),
                '        IIf(CBAssetMap.Checked, 1, 0),
                '        IIf(CBAssetInspector.Checked, 1, 0),
                '        IIf(CBAssetUses.Checked, 1, 0),
                '        IIf(CBAssetChart.Checked, 1, 0),
                '        IIf(CBAssetRoutes.Checked, 1, 0),
                '        IIf(CBAssetDummy.Checked, 1, 0),
                '        IIf(CBAssetMeter1Spn.SelectedItem IsNot Nothing, CBAssetMeter1Spn.SelectedItem.split("-")(0).ToString().Trim(), Nothing),
                '        IIf(CBAssetMeter2Spn.SelectedItem IsNot Nothing, CBAssetMeter2Spn.SelectedItem.split("-")(0).ToString().Trim(), Nothing))
            Else
                resultID = selectedGRSat.creaAsset(
                        selectedGRSat.creaDevice(TextboxSerialNumber.Text, DropdownDevicesProfiles.SelectedItem & "_" & TextboxSerialNumber.Text, TextboxCloudCode.Text, TextBoxCloudPw.Text),
                        TBAssetDesc.Text, TBAssetBrand.Text, TBAssetSerial.Text, TBAssetModel.Text, TBAssetPlate.Text,
                        CBAssetUnit.SelectedItem.split("-")(0).ToString().Trim(),
                        CBAssetSheet.SelectedItem.split("-")(0).ToString().Trim(),
                        IIf(CBAssetProfile.Checked, 1, 0),
                        IIf(CBAssetGPS.Checked, 1, 0),
                        IIf(CBAssetRSSI.Checked, 1, 0),
                        IIf(CBAssetMeter1.Checked, 1, 0),
                        IIf(CBAssetMeter2.Checked, 1, 0),
                        IIf(CBAssetAlarm.Checked, 1, 0),
                        IIf(CBAssetMap.Checked, 1, 0),
                        IIf(CBAssetInspector.Checked, 1, 0),
                        IIf(CBAssetUses.Checked, 1, 0),
                        IIf(CBAssetChart.Checked, 1, 0),
                        IIf(CBAssetRoutes.Checked, 1, 0),
                        IIf(CBAssetDummy.Checked, 1, 0),
                         CBAssetMeter1Spn.SelectedItem.split("-")(0).ToString().Trim(),
                         CBAssetMeter2Spn.SelectedItem.split("-")(0).ToString().Trim())
            End If

            Dim result As Boolean = resultID >= 0

            If Not IsNothing(sender) Then
                If result Then MsgBox("Creazione ok!")
            End If

            If Not result Then MsgBox("Creazione fallita =(")

        Catch ex As Exception
            AggiornaLog(ex)
            MsgBox("Creazione fallita =(")
        End Try
        disposeWait()
        Return resultID
    End Function

    Function getETSDeviceString() As String
        Dim hwadjustStr As String = ""

        If CheckboxFwEnable125Khz.Checked Then
            hwadjustStr &= "125KHz"
        End If
        If CheckboxFwEnableKbd.Checked Then
            hwadjustStr &= "+KBD" 'keyboard
        End If
        If CheckboxFwEnableFps.Checked Then
            hwadjustStr &= "+FPS" 'fingerprint scanner
        End If
        If CheckboxFwEnableTouch.Checked Then
            hwadjustStr &= "+TOUCH" 'touch screen
        End If

        Dim hwset = Math.Abs(CInt(CheckboxHwEnableSD.Checked))
        hwset = hwset Or (Math.Abs(CInt(CheckboxHwEnableGPS.Checked)) << 1)
        hwset = hwset Or (Math.Abs(CInt(CheckboxHwEnableGPRS.Checked)) << 2)
        hwset = hwset Or (Math.Abs(CInt(CheckboxHwEnableWifi.Checked)) << 3)
        hwset = hwset Or (Math.Abs(CInt(CheckboxHwEnableCartellino.Checked)) << 4)

        If DropdownDevicesProfiles.SelectedItem = "MDT" Then
            Dim txt As String = DropdownDevicesProfiles.SelectedItem
            Return txt
        ElseIf Not DropdownDevicesProfiles.SelectedItem = "MDT" Then
            Dim msg As String = DropdownDevicesProfiles.SelectedItem & " X" &
            Hex(hwset) & " " & hwadjustStr
            Return msg
        End If

    End Function

    Private Sub CheckBoxAutoFillAssetData_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAutoFillAssetData.CheckedChanged
        setGRSatAssetDataUI(Not sender.checked)
    End Sub

    Private Delegate Sub setGRSatAssetDataUIDelegate(empty As Boolean)
    Sub setGRSatAssetDataUI(Optional empty As Boolean = False)
        If Me.InvokeRequired Then
            Me.Invoke(New setGRSatAssetDataUIDelegate(AddressOf setGRSatAssetDataUI), New Object() {empty})
            Return
        End If

        Dim serial = TextboxSerialNumber.Text.ToString()
        If serial.Equals("0") Then
            serial = ""
        End If

        If Not empty Then
            If CheckBoxAutoFillAssetData.Enabled And CheckBoxAutoFillAssetData.Checked Then
                TBAssetDesc.Text = DropdownDevicesProfiles.SelectedItem & "_" & serial
                TBAssetBrand.Text = DropdownDevicesProfiles.SelectedItem
                TBAssetSerial.Text = serial
                TBAssetModel.Text = getETSDeviceString()
            End If
        Else
            TBAssetDesc.Text = ""
            TBAssetBrand.Text = ""
            TBAssetSerial.Text = ""
            TBAssetModel.Text = ""
        End If
    End Sub

    Private Sub CheckBoxGPS_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxHwEnableGPS.CheckedChanged
        CBAssetGPS.Checked = sender.checked
        CBAssetMap.Checked = CheckboxHwEnableGPRS.Checked Or CheckboxHwEnableGPS.Checked
        CBAssetRoutes.Checked = sender.checked
    End Sub

    Private Sub CheckBoxGPRS_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxHwEnableGPRS.CheckedChanged
        CBAssetRSSI.Checked = CheckboxHwEnableGPRS.Checked
        CBAssetMap.Checked = CheckboxHwEnableGPRS.Checked Or CheckboxHwEnableGPS.Checked
    End Sub

    Private Sub CBAssetMeter1_CheckedChanged(sender As Object, e As EventArgs) Handles CBAssetMeter1.CheckedChanged
        CBAssetMeter1Spn.Enabled = CBAssetMeter1.Checked
    End Sub
    Private Sub CBAssetMeter2_CheckedChanged(sender As Object, e As EventArgs) Handles CBAssetMeter2.CheckedChanged
        CBAssetMeter2Spn.Enabled = CBAssetMeter2.Checked
    End Sub

    Private Sub CBAssetSheet_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBAssetSheet.SelectedIndexChanged
        Try
            CBAssetMeter1Spn.Items.Clear()
            CBAssetMeter2Spn.Items.Clear()

            Dim spns As String()
            If TypeOf selectedGRSat Is GRSatBonatti Then
                spns = CType(selectedGRSat, GRSatBonatti).getSensorsForSheet(CBAssetSheet.SelectedItem.split("-")(0).ToString().Trim()).ToArray()
            Else
                spns = selectedGRSat.getSensorsForSheet(CBAssetSheet.SelectedItem.split("-")(0).ToString().Trim()).ToArray()
            End If


            CBAssetMeter1Spn.Items.AddRange(spns)
            CBAssetMeter2Spn.Items.AddRange(spns)

            If CBAssetMeter1Spn.SelectedIndex < 0 And CBAssetMeter1Spn.Items.Count > 0 Then CBAssetMeter1Spn.SelectedIndex = 0
            If CBAssetMeter2Spn.SelectedIndex < 0 And CBAssetMeter2Spn.Items.Count > 0 Then CBAssetMeter2Spn.SelectedIndex = 0

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub LinkLabelGoToGRsat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelGoToGRsat.LinkClicked
        If Not IsNothing(selectedGRSat) Then
            Dim srv = selectedGRSat.HTTPServer
            If Not srv.StartsWith("http://") Or Not srv.StartsWith("https://") Then
                srv = "http://" & srv
            End If
            Process.Start(srv)
        End If
    End Sub

    Private Sub ButtonsStartRFIDTest_Click(sender As Object, e As EventArgs) Handles ButtonsStartRFIDTest.Click
        If rfidreading Then
            stopRFIDTest()
        Else
            ButtonsStartRFIDTest.Text = "Stop"
            performRFIDTest()
        End If
    End Sub

    Dim rfidreading As Boolean = False
    Sub stopRFIDTest()
        rfidreading = False
        ButtonsStartRFIDTest.Text = "Avvia test"
        GroupBoxRFIDTest.BackColor = Color.Black
        TextBoxRFIDTestTarget1.ForeColor = Color.Black
        TextBoxRFIDTestTarget2.ForeColor = Color.Black
    End Sub


    Dim gprstesting As Boolean = False
    Sub stopGPRSTest()
        gprstesting = False
        ButtonsStartGPRSTest.Text = "Avvia test"
        GroupBoxGPRSTest.BackColor = Color.Black
    End Sub

    Sub stopledTest()
        GroupBoxLEDTest.BackColor = Color.Black
    End Sub
    Sub startLedTest()
        GroupBoxLEDTest.BackColor = Color.DimGray
    End Sub


    Sub stopTelitVTest()
        GroupBoxTelitTest.BackColor = Color.Black
    End Sub
    Sub startTelitVTest()
        LabelTelitSTestStatus.Text = "Test-todo"
        GroupBoxTelitTest.BackColor = Color.DimGray
    End Sub


    Function performRFIDTest() As Boolean
        Dim result = False
        Dim closedoor = openCOMPort(main_speed)
        Try
            GroupBoxRFIDTest.BackColor = Color.DimGray
            Dim rUID As String
            rfidreading = True

            While rfidreading And (
            TextBoxRFIDTestTarget1.ForeColor <> Color.Green Or
            TextBoxRFIDTestTarget2.ForeColor <> Color.Green
            )

                rUID = getCurrentUID()
                If rUID.Equals("ERROR") AndAlso MessageBox.Show("Errore durante il test RFID", "x_x", MessageBoxButtons.RetryCancel) = DialogResult.Cancel Then
                    rfidreading = False
                End If

                LabelRFIDTestStatus.Text = "UID letto: " & rUID

                If rUID.Equals(TextBoxRFIDTestTarget1.Text) Then
                    TextBoxRFIDTestTarget1.ForeColor = Color.Green
                End If

                If rUID.Equals(TextBoxRFIDTestTarget2.Text) Then
                    TextBoxRFIDTestTarget2.ForeColor = Color.Green
                End If

                Wait(100)
                Application.DoEvents()

            End While

            result = rfidreading

        Catch ex As Exception
            AggiornaLog(ex)
        Finally
            If closedoor Then SerialPort.Close()
            stopRFIDTest()
            If result Then
                LabelRFIDTestStatus.Text = "Test superato =)"
            Else
                LabelRFIDTestStatus.Text = "Test interrotto x_x"
            End If

        End Try

        Return result
    End Function


    Function preparaModemPerTEST(ByRef settingsChanged) As Integer
        Dim result = 0
        Try

            Dim statoModemGPRS As Integer = -1
            Dim TRAFFIC_BLOCK = False
            Dim modemoccupato = False
            Dim pinstatus = -1
            Dim GPRS = False
            Dim statoReteGSM = -1
            Dim Stato = Split(RDW_Command("R01"), "|")

            statoModemGPRS = CInt(Stato(22))
            statoReteGSM = CInt(Stato(24))
            Dim SimStatus = CBool(CInt(Stato(28)))
            GPRS = CBool(CInt(Stato(34)))
            If Stato.Length > 76 Then TRAFFIC_BLOCK = CBool(CInt(Stato(76)))
            If Stato.Length > 76 Then pinstatus = CInt(Stato(72))


            If statoModemGPRS > 0 And SimStatus = True Then
                Select Case pinstatus
                    Case 2
                        If TextBoxGPRSTestPin.Text.Length <> 4 OrElse Not IsNumeric(TextBoxGPRSTestPin.Text) Then
                            MessageBox.Show("Immettere un codice PIN valido nell'apposita casella", "Test GPRS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            result = 0
                            Exit Try
                        End If
                        settingsChanged = True
                        RDW_Command("W0B", 129954, TextBoxGPRSTestPin.Text)
                        RDW_Command("W07", 129959, 1)
                        RDW_Command("L02")
                        If RDW_Command("F96").Equals("?") Then
                            result = 0
                            Exit Try
                        End If
                        Wait(3000)
                        result = -1
                        Exit Try
                    Case 3
                        MessageBox.Show("Pin errato!", "Test GPRS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        result = 0
                        Exit Try
                    Case 4
                        MessageBox.Show("Pin errato! Attezione è rimasto solo un tentativo prima di bloccare la SIM", "Test GPRS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        result = 0
                        Exit Try
                    Case 5
                        MessageBox.Show("La SIM card è bloccata. Occore usare un cellulare ed inserire il codice PUK", "Test GPRS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        result = 0
                        Exit Try
                End Select
            End If

            If statoModemGPRS = 2 Or statoModemGPRS = 3 Or statoModemGPRS = 4 Or statoModemGPRS = 9 Or statoModemGPRS = 10 Or statoModemGPRS = 11 Or statoModemGPRS = 12 Or statoModemGPRS = 13 Or statoModemGPRS = 14 Then
                showWait("Il modem GPRS risulta occupato, proviamo ad attendere qualche secondo...", abortable:=True)
                Wait(3000)
                result = -1
                Exit Try
            Else
                modemoccupato = False
            End If

            If statoModemGPRS > 0 And TRAFFIC_BLOCK Then
                MessageBox.Show("La soglia di consumo dati giornaliera è stata raggiunta, il traffico è stato bloccato", "Test GPRS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                result = 0
                Exit Try

            ElseIf statoModemGPRS > 0 And SimStatus = False Then
                showWait("Inserire una SIM card", abortable:=True)
                Wait(1000)
                result = -1
                Exit Try


            ElseIf statoModemGPRS > 0 And SimStatus = True And GPRS = False Then
                If statoReteGSM = 0 Or statoReteGSM = 2 Then
                    showWait("In attesa di registrazione GSM...", abortable:=True)
                    Wait(3000)
                    result = -1
                    Exit Try

                ElseIf statoReteGSM = 1 Then
                    showWait("In attesa di registrazione GPRS..." & vbCrLf & "Se questa fase si prolunga, verificare che l'APN impostato sia corretto", abortable:=True)
                    Wait(2000)
                    result = -1
                    Exit Try

                ElseIf statoReteGSM = 4 Then
                    showWait("Il modem GPRS è in uno stato indefinito, proviamo ad attendere qualche secondo...", abortable:=True)
                    Wait(3000)
                    result = -1
                    Exit Try

                ElseIf statoReteGSM = 3 Then
                    MessageBox.Show("Registrazione GSM fallita", "Test GPRS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    result = 0
                    Exit Try

                ElseIf statoReteGSM = 5 Then
                    If MessageBox.Show("Attenzione il modem GPRS è in roaming! Si vuole continuare?", "Test GPRS", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                        result = 0
                        Exit Try
                    End If
                End If


            ElseIf statoModemGPRS > 0 And SimStatus = True And GPRS = True Then
                result = 1
                Exit Try

            Else
                showWait("Il modem GPRS è in uno stato di errore, proviamo ad attendere qualche secondo...", abortable:=True)
                Wait(3000)
                result = -1
                Exit Try
            End If
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return result
    End Function


    Function performGPRSTest() As Boolean
        Dim result = False
        pwfStopLoading = False
        Dim closedoor = openCOMPort(main_speed)
        Dim Bresult = False
        Dim checkModem = -1

        Dim settingsChanged As Boolean = False
        Dim oldPinCode = "0000"
        Dim oldPinEnable = 0
        Dim oldAPN = "myinternet.wind"
        Dim oldAPNUser = ""
        Dim oldAPNPw = ""
        Dim oldAPNSelect = 0
        Dim oldAPNAutoChange = 0

        Try
            GroupBoxGPRSTest.BackColor = Color.DimGray
            gprstesting = True
            Dim stato As String() = New String() {}
            Dim tentativi As Integer = 10

            showWait("Preparo il dispositivo...", abortable:=True)


            'salvo la configurazione attuale
            oldPinCode = RDW_Command("R0B", 129954)
            oldPinEnable = RDW_Command("R07", 129959)
            oldAPNSelect = RDW_Command("R07", 86)
            oldAPN = RDW_Command("R0B", 1149)
            oldAPNUser = RDW_Command("R0B", 1199)
            oldAPNPw = RDW_Command("R0B", 1224)
            oldAPNAutoChange = RDW_Command("R07", 87)

            'Imposto APN di test
            RDW_Command("W0B", 1149, TextBoxGPRSTestAPN.Text)
            RDW_Command("W0B", 1199, "")
            RDW_Command("W0B", 1224, "")
            RDW_Command("W07", 87, 0)
            RDW_Command("W07", 86, 0)
            RDW_Command("L02")


            While checkModem < 0 And Not pwfStopLoading
                checkModem = preparaModemPerTEST(settingsChanged)
                If checkModem = 0 AndAlso MessageBox.Show("Test fallito, riprovare?", "Test GPRS", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    checkModem = -1
                End If
                Wait(100)
            End While
            If checkModem = 0 Or pwfStopLoading Then
                Bresult = False
            Else
                Bresult = (checkModem = 1)
            End If

            If Not Bresult Then Return False

            'Fine preparazione, Inizio del test

            While (stato.Length < 2 OrElse stato(0).Equals("1"))
                stato = RDW_Command("R82").Split("|")

                If stato.Length < 2 OrElse stato(0).Equals("1") Then
                    If tentativi > 0 Then
                        tentativi -= 1
                        Wait(500)
                    Else
                        Exit Try
                    End If
                End If
            End While

            RDW_Command("W82")
            Wait(500)

            stato = RDW_Command("R82").Split("|")

            If stato.Length < 2 OrElse Not stato(0).Equals("1") Then
                Exit Try
            End If

            pwfStopLoading = False
            showWait("Test in corso...", abortable:=True)

            While ((stato.Length < 2 OrElse stato(0).Equals("1")) And Not pwfStopLoading And gprstesting)
                Wait(250)
                stato = RDW_Command("R82").Split("|")
            End While

            If pwfStopLoading Then Exit Try
            disposeWait()
            If stato(1).Equals("1") Then
                result = True
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        Finally
            If Bresult <> -1 And settingsChanged Then
                showWait("Rispristino la configurazione precedente...", abortable:=True)
                RDW_Command("W0B", 129954, oldPinCode)
                RDW_Command("W07", 129959, oldPinEnable)
            End If
            RDW_Command("W0B", 1149, oldAPN)
            RDW_Command("W0B", 1199, oldAPNUser)
            RDW_Command("W0B", 1224, oldAPNPw)
            RDW_Command("W07", 87, oldAPNAutoChange)
            RDW_Command("W07", 86, oldAPNSelect)
            RDW_Command("L02")
            If closedoor Then SerialPort.Close()
            stopGPRSTest()
            If result Then
                LabelGPRSTestStatus.Text = "Test superato =)"
            Else
                LabelGPRSTestStatus.Text = "Test interrotto x_x"
            End If
        End Try
        disposeWait()
        Return result
    End Function

    Function getCurrentUID() As String
        Dim closedoor = openCOMPort(main_speed)
        Try
            Dim statone = RDW_Command("R01").Split("|")
            Dim rUID = statone(50)
            Dim rUID125 = statone(81)
            If Not IsNothing(rUID125) AndAlso rUID125.Length > 0 Then rUID = rUID125
            Return rUID
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        If closedoor Then SerialPort.Close()
        Return "ERROR"
    End Function

    Private Sub LinkLabelRFIDTestSetTarget1_Click(sender As Object, e As EventArgs) Handles LinkLabelRFIDTestSetTarget1.Click
        Try
            TextBoxRFIDTestTarget1.Text = getCurrentUID()
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub
    Private Sub LinkLabelRFIDTestSetTarget2_Click(sender As Object, e As EventArgs) Handles LinkLabelRFIDTestSetTarget2.Click
        Try
            TextBoxRFIDTestTarget2.Text = getCurrentUID()
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub CheckBoxRFIDTest_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxRFIDTest.CheckedChanged
        ButtonsStartRFIDTest.Enabled = sender.checked
    End Sub


    Private Sub CheckBoxTestInvioCloud_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxTestInvioCloud.CheckedChanged

    End Sub

    Private Sub ButtonsStartLEDTest_Click(sender As Object, e As EventArgs) Handles ButtonsStartLEDTest.Click
        doLedTest()
    End Sub

    Function doLedTest()
        startLedTest()
        Dim closedoor = openCOMPort(main_speed)
        Dim exitresult = False
        Try
test:
            RDW_Command("P90", 0)
            RDW_Command("R00", , , , , , 3000)
            RDW_Command("R00")
            RDW_Command("R00")
            Dim result = MessageBox.Show("Verificare anche il led centrale durante la lettura del badge!" & vbCrLf & vbCrLf & "Tutti i led funzionano?", "Test LED", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                If MessageBox.Show("Test led fallito", "Test LED", MessageBoxButtons.RetryCancel) = DialogResult.Retry Then
                    GoTo test
                End If
                exitresult = False
            Else
                exitresult = True
            End If
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        If SerialPort.IsOpen And closedoor Then SerialPort.Close()
        stopledTest()
        Return exitresult
    End Function

    Private Sub CheckBoxLEDTest_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxLEDTest.CheckedChanged
        ButtonsStartLEDTest.Enabled = sender.checked
    End Sub

    Private Sub ButtonsStartGPRSTest_Click(sender As Object, e As EventArgs) Handles ButtonsStartGPRSTest.Click
        performGPRSTest()
    End Sub

    Private Sub ButtonBLERP0_Click(sender As Object, e As EventArgs) Handles ButtonBLERP0.Click
        NumericUpDownValoriCount.Value += 1
        Try
            FlowLayoutPanelComando.Controls.Find("TBCMD_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "RP0"
            FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = ""
            FlowLayoutPanelValue.Controls.Find("TBVAL_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = ""
            Dim a As CheckBox = (FlowLayoutPanelSerializza.Controls.Find("CBSER_" & NumericUpDownValoriCount.Value - 1, False)(0))
            a.Checked = True
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        If File.Exists(Application.StartupPath & "\Bootloader\" & DropdownDevicesProfiles.SelectedItem.ToString() & "\main.bin") Then
            Dim baites As Byte() = File.ReadAllBytes(Application.StartupPath & "\Bootloader\" & DropdownDevicesProfiles.SelectedItem.ToString() & "\main.bin")
            LabelFlasingFw.Text = analyzeFw(baites)
        Else
            LabelFlasingFw.Text = ""
        End If
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Dim newval = InputBox("Inserisci il nuovo valore da salvare", My.Settings.Telit_GPRS_vOk, My.Settings.Telit_GPRS_vOk)
        If newval.Length > 0 Then
            My.Settings.Telit_GPRS_vOk = newval
            My.Settings.Save()
            TextBoxTelitGPRS_Vok.Text = My.Settings.Telit_GPRS_vOk
        End If
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Dim newval = InputBox("Inserisci il nuovo valore da salvare", My.Settings.Telit_GPS_vOk, My.Settings.Telit_GPS_vOk)
        If newval.Length > 0 Then
            My.Settings.Telit_GPS_vOk = newval
            My.Settings.Save()
            TextBoxTelitGPS_Vok.Text = My.Settings.Telit_GPS_vOk
        End If
    End Sub

    Private Sub ButtonsStarTelitVTest_Click(sender As Object, e As EventArgs) Handles ButtonsStarTelitVTest.Click
        performTelitTest()
    End Sub


    Function performTelitTest() As String
        startTelitVTest()
        Dim telitv = ""
        Dim closedoor = openCOMPort(main_speed)
        Try

            'C1=12345|TD7077|12345|150517094109|ETSA1|0311C|77777777|0303A|||352054055185046||0,0|GSD4E_4.1.2|10.00.027|523|0|13|8
            'C1=12345|TD7077|12345|150517094929|ETSA1|0311C|77777777|0303A|||***************||0,0|GSD4E_4.1.2||523|0|1|8

            Dim hr = RDW_Command("Q404").Split("|")
            If hr.Length < 14 Then
                MessageBox.Show("Errore nel payload; test fallito")
                Exit Try
            End If

            telitv = hr(14)
            If telitv = "" AndAlso (CheckboxHwEnableGPS.Checked Or CheckboxHwEnableGPRS.Checked) Then
                MessageBox.Show("Attenzione! Non risulta alcun modulo Telit installato x_x")
                LabelTelitSTestStatus.Text = "FAIL X_X"
                Exit Try
            End If

            Dim result = (telitv.Equals(TextBoxTelitGPRS_Vok.Text) AndAlso (CheckboxHwEnableGPRS.Checked And Not CheckboxHwEnableGPS.Checked)) Or
                        (telitv.Equals(TextBoxTelitGPS_Vok.Text) AndAlso (CheckboxHwEnableGPS.Checked))

            If result Then
                LabelTelitSTestStatus.Text = "SUCCESSO"
            Else
                LabelTelitSTestStatus.Text = telitv
                MessageBox.Show("Il modem Telit è da aggiornare oppure la configurazione HW non corrisponde al modulo installato!!!!")
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        If SerialPort.IsOpen And closedoor Then SerialPort.Close()
        stopTelitVTest()
        Return telitv
    End Function

    Private Sub ButtonMongo_Click(sender As Object, e As EventArgs) Handles ButtonMongo.Click
        If commitDeviceCraft() Then
            MsgBox("Statistiche inviate")
        Else
            mongoError()
        End If
    End Sub

    Sub mongoError(Optional reason = Nothing)
        MsgBox("Impossibile inviare le statistiche di produzione a Prediction")
        setMongoId("")
    End Sub

    Sub setMongoId(currid As String)
        current_mongo_id = currid
        LinkLabelCancelMongo.Enabled = current_mongo_id.Length > 0
    End Sub


    Function commitDeviceCraft() As Boolean
        Try
            LabelMongoStatus.Text = "Invio in corso..."
            showWait(LabelMongoStatus.Text)

            Dim params = populateCraftParameters()
            'Dim postData As New Specialized.NameValueCollection()
            'Dim jsonstring = JsonConvert.SerializeObject(params, Xml.Formatting.Indented)
            'postData.Add("key", "E7543A35924F46B5FC7BB124884EC")
            'postData.Add("data", JsonConvert.SerializeObject(params))

            'If checkPrediction() <> Cloud.LOGIN_RESULT.SUCCED Then
            '    Exit Try
            'End If
            'Dim risp = prediction.doPostRequest("http://" & TextboxPredictionHost.Text & "/FlashedLOL/dev_craft.php", postData)
            'If risp.StartsWith("_id") AndAlso risp.Length > "_id".Length Then
            '    setMongoId(risp.Replace("_id", ""))
            '    LabelMongoStatus.Text = params.Item("dispositivo").Item("serial") & " - Fatto" & vbCrLf & risp
            '    disposeWait()
            '    Return True
            'ElseIf risp = "session not valid" Then
            '    MsgBox("Eseguire il login a Prediction")
            'Else
            '    MsgBox("Errore sconosciuto: " & vbCrLf & risp)
            'End If


            Dim client = New MongoClient("mongodb://root:R8HFKaPfZ6Ar@ec2-18-156-33-51.eu-central-1.compute.amazonaws.com:27017")
            Dim db = client.GetDatabase("super_mongo_db")
            Dim collection = db.GetCollection(Of BsonDocument)("FL_devices")

            collection.InsertOne(params.ToBsonDocument())
            ' TODO setMongoId(risp.Replace("_id", ""))
            LabelMongoStatus.Text = params.GetElement("dispositivo").Value.AsBsonDocument().GetElement("serial").Value.ToString() & " - Fatto"
            disposeWait()
            Return True

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        LabelMongoStatus.Text = "errore"
        disposeWait()
        Return False
    End Function


    Function populateCraftParameters() As BsonDocument
        Dim par As New BsonDocument()
        Try
            Dim timestamp As New BsonDocument()
            Dim operatore As New BsonDocument()
            Dim dispositivo As New BsonDocument()
            Dim etichetta As New BsonDocument()
            Dim firmware As New BsonDocument()
            Dim configurazione As New BsonDocument()
            Dim test_effettuati As New BsonDocument()
            Dim flash_additional As New BsonDocument()
            Dim testAlimentazione As New BsonDocument()
            Dim ciao = Date.Now()



            timestamp.Add("DateTime", ciao.ToString)
            operatore.Add("MachineName", Environment.MachineName)
            operatore.Add("OSVersion", Environment.OSVersion.ToString())
            operatore.Add("UserDomainName", Environment.UserDomainName)
            operatore.Add("UserName", TextboxPredictionUsername.Text)

            Dim framework_version As New BsonDocument()
            framework_version.Add("Major", Environment.Version.Major)
            framework_version.Add("MajorRevision", Environment.Version.MajorRevision)
            framework_version.Add("Minor", Environment.Version.Minor)
            framework_version.Add("MinorRevision", Environment.Version.MinorRevision)
            framework_version.Add("Revision", Environment.Version.Revision)
            framework_version.Add("Build", Environment.Version.Build)


            Dim software_version As New BsonDocument()
            software_version.Add("Major", My.Application.Info.Version.Major)
            software_version.Add("MajorRevision", My.Application.Info.Version.MajorRevision)
            software_version.Add("Minor", My.Application.Info.Version.Minor)
            software_version.Add("MinorRevision", My.Application.Info.Version.MinorRevision)
            software_version.Add("Revision", My.Application.Info.Version.Revision)
            software_version.Add("Build", My.Application.Info.Version.Build)


            operatore.Add("framework_version", framework_version)
            operatore.Add("software_version", software_version)

            dispositivo.Add("descrizione", DropdownDevicesProfiles.SelectedItem.ToString())    ' Descrizione device
            dispositivo.Add("usb_vid", current_usb_vid)                 ' USB VID
            dispositivo.Add("usb_pid", current_usb_pid)                 ' USB PID
            dispositivo.Add("R00", RDW_Command("R00"))                  ' Read info

            Dim data = currentLabelData.Split("~")
            If data.Length >= 6 Then
                etichetta.Add("code", data(0))                          ' Codice device
                etichetta.Add("desc", data(2))                          ' Descrizione device
                etichetta.Add("name", data(1))                          ' Descrizione modello
                etichetta.Add("raw_label", currentLabelData)            ' Stringa etichetta
            End If


            Dim Power As New BsonDocument()

            'If TestCollaudo.testAlimentazioneStatusSuccess = False Then


            '    Power.Add("TestPower", TestCollaudo.testAlimentazioneStatusSuccess.ToString)
            'End If


            If CheckboxWriteSerialNumber.Checked Then
                dispositivo.Add("serial", TextboxSerialNumber.Text)         ' Matricola
            Else
                dispositivo.Add("serial", "Not set")
            End If

            If CheckBoxClearAllarmi.Enabled Then
                flash_additional.Add("clear_allarmi", CheckBoxClearAllarmi.Checked)
            End If
            If CheckboxSyncDatetime.Enabled Then
                flash_additional.Add("sync_rtc", CheckboxSyncDatetime.Checked)
            End If
            If CheckboxFormatSD.Enabled Then
                flash_additional.Add("format_sd", CheckboxFormatSD.Checked)
            End If


            firmware.Add("hw_ver", LBVersioneHW.Text)                   ' Versione hardware
            firmware.Add("hw_setup", LabelHwSetup.Text)                 ' Configurazione hardware
            firmware.Add("fw_boot", current_fwbt_version.ToString())               ' Versione firmware bootloader
            firmware.Add("fw_main", current_fwmain_version.ToString())             ' Versione firmware main
            configurazione.Add("stock_cfg", current_config_stock.ToString())       ' File di configurazione base
            If CheckboxWriteCloudCode.Checked Then
                configurazione.Add("cloud_code", TextboxCloudCode.Text)            ' Cloud code
                configurazione.Add("cloud_pass", TextBoxCloudPw.Text)              ' Cloud psw
            End If
            If CheckboxWriteGpsVersion.Checked Then
                configurazione.Add("gps_version", TBGPSVersion.Text)  ' versione GPS
            End If
            If CheckBoxInitETS.Enabled Then
                configurazione.Add("init_parametri", CheckBoxInitETS.Checked)
            End If

            'TODO testare cosa succede se non c'è l'item?!
            'For Each k In current_test_result.AllKeys()
            '    Try
            '        test_effettuati.Add("test_" & k, current_test_result.Item(k))
            '    Catch
            '    End Try
            'Next






            Dim parametri_aggiuntivi As New BsonDocument()
            If current_anagrafica_cmd.length > 0 Then
                parametri_aggiuntivi.Add("anagrafica", current_anagrafica_cmd)      ' anagrafica dispositivo
            End If
            For i = 0 To NumericUpDownValoriCount.Value - 1
                Dim comando = FlowLayoutPanelComando.Controls.Find("TBCMD_" & i, False)(0).Text
                Dim indirizzo = FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & i, False)(0).Text
                Dim valore = FlowLayoutPanelValue.Controls.Find("TBVAL_" & i, False)(0).Text
                parametri_aggiuntivi.Add(i, comando & " " & indirizzo & " " & valore)     ' parametri della funzione divina
            Next
            configurazione.Add("parametri_aggiuntivi", parametri_aggiuntivi)

            Dim hack_applicati As New BsonDocument()
            hack_applicati.Add("hw_conf->GRCONF+8", CheckBoxHWSetupMoved.Checked)
            hack_applicati.Add("non_mandare_nel_boot", CheckBoxHack.Checked)
            If CBOTG.Checked Then
                Dim parametri_otg As New BsonDocument()
                parametri_otg.Add("caricati", IIf(RBOTGNOW.Checked, "dopo_parametri_stock", "a_fine_flash"))
                parametri_otg.Add("otg_cfg", current_config_otg)
                hack_applicati.Add("parametri_otg", parametri_otg)
            End If
            configurazione.Add("hack_applicati", hack_applicati)


            par.Add("timestamp", timestamp)
            par.Add("operatore", operatore)
            par.Add("dispositivo", dispositivo)
            par.Add("etichetta", etichetta)
            par.Add("firmware", firmware)
            par.Add("configurazione", configurazione)
            par.Add("test_effettuati", test_effettuati)
            par.Add("flash_additional", flash_additional)

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return par
    End Function

    Private Sub CheckBoxSendMongo_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSendMongo.CheckedChanged
        ButtonMongo.Enabled = Not sender.checked
    End Sub

    Private Sub LinkLabelCancelMongo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelCancelMongo.LinkClicked
        If current_mongo_id.Length > 0 Then
            If checkPrediction() <> Cloud.LOGIN_RESULT.SUCCED Then Return

            Dim postData As New Specialized.NameValueCollection()
            postData.Add("key", "EUuj7Urky5DnnxvF7h8FnCHwyYk4T2")
            postData.Add("_id", current_mongo_id)
            If prediction.doPostRequest("http://" & TextboxPredictionHost.Text & "/FlashedLOL/dev_craft.php", postData) = "1" Then
                MsgBox("Statistiche annullate")
                setMongoId("")
            Else
                MsgBox("Errore nel tentativo di annullare l'operazione")
            End If
        End If
    End Sub

    Private Sub ButtonCLearOldCodiciCloud_Click(sender As Object, e As EventArgs) Handles ButtonCLearOldCodiciCloud.Click
        ListBoxCodiciCloud.Items.Clear()
    End Sub

    Private Sub ButtonExportCodiciCloud_Click(sender As Object, e As EventArgs) Handles ButtonExportCodiciCloud.Click
        Try
            If ListBoxCodiciCloud.Items.Count = 0 Then
                MsgBox("Nessun codice da esportare!")
                Exit Try
            End If

            Dim sfd As New SaveFileDialog With {.Title = "Esportazione codici cloud", .AddExtension = True, .FileName = "codici_cloud_" & Now.ToFileTime() & ".csv"}
            If sfd.ShowDialog() <> DialogResult.OK Then
                MsgBox("Esportazione annullata")
                Exit Try
            End If
            If File.Exists(sfd.FileName) Then File.Delete(sfd.FileName)

            Dim cliente = InputBox("Inserisci il cliente" & vbCrLf & "Puoi lasciare vuoto questo campo se lo desideri")
            Dim personalizzazione = InputBox("Inserisci la personalizzazione" & vbCrLf & "Puoi lasciare vuoto questo campo se lo desideri")
            Dim oggi = Now.ToShortDateString()

            Using sw As New StreamWriter(sfd.FileName)

                sw.WriteLine("sep=,")
                sw.WriteLine("Cliente, Codice, Seriale, Personalizzazione, Data, Tipo Disp., Portale")

                For Each itm As String In ListBoxCodiciCloud.Items
                    Dim data = itm.Split("-")
                    Dim device = data(0).Trim(" ")
                    Dim code = data(1).Trim(" ")
                    Dim portale = data(2).Trim(" ")
                    Dim serial = ""
                    If data.Length > 3 Then
                        serial = data(3).Trim(" ")
                    End If

                    sw.WriteLine(cliente & "," & code & "," & serial & "," & personalizzazione & "," & oggi & "," & device & "," & portale)
                Next
            End Using

            Process.Start(sfd.FileName)

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub ButtonDivineETSDNAssoc_Click(sender As Object, e As EventArgs) Handles ButtonDivineETSDNAssoc.Click
        NumericUpDownValoriCount.Value += 1
        Try
            FlowLayoutPanelComando.Controls.Find("TBCMD_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "R72"
            FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = ""
            FlowLayoutPanelValue.Controls.Find("TBVAL_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = ""
            Dim a As CheckBox = (FlowLayoutPanelSerializza.Controls.Find("CBSER_" & NumericUpDownValoriCount.Value - 1, False)(0))
            a.Checked = False
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        End Try
    End Sub

    'Private Sub CheckBoxDivineSync_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxDivineSync.CheckedChanged
    '    If sender.checked Then
    '        RadioButtonAutoNextRemote.Checked = True
    '        MsgBox("Hai attivato la funzione! Ricorda che hai bisogno di un master in rete." & vbCrLf &
    '           "In questa modalità hai bisogno di un PC master e quanti PC slave desideri. Configura i PC slave attivando questa spunta e assicurandoti che vedano tutti il PC Master e predisponendo le spunte di produzione come di consueto; poi clicca start. In questa modalità i PC slave attendono una comunicazione da parte del PC master.")
    '    End If
    'End Sub

    Private Sub ButtonDivineETSSetUser_Click(sender As Object, e As EventArgs) Handles ButtonDivineETSSetUser.Click
        If MsgBox("Usando questa funzione sovrascriverai eventuali utenti già salvati sul dispositivo, vuoi continuare?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Return

        Try
            ' Numero utenti
            NumericUpDownValoriCount.Value += 1
            FlowLayoutPanelComando.Controls.Find("TBCMD_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "W08"
            FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = 600
            FlowLayoutPanelValue.Controls.Find("TBVAL_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "1"
            Dim a As CheckBox = (FlowLayoutPanelSerializza.Controls.Find("CBSER_" & NumericUpDownValoriCount.Value - 1, False)(0))
            a.Checked = False

            ' UID (stringa speciale che scatena una lettura realtime)
            NumericUpDownValoriCount.Value += 1
            FlowLayoutPanelComando.Controls.Find("TBCMD_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "W08"
            FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = 131072
            FlowLayoutPanelValue.Controls.Find("TBVAL_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "$GET_UID$"
            a = (FlowLayoutPanelSerializza.Controls.Find("CBSER_" & NumericUpDownValoriCount.Value - 1, False)(0))
            a.Checked = False

            ' Nome utente
            NumericUpDownValoriCount.Value += 1
            FlowLayoutPanelComando.Controls.Find("TBCMD_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "W0B"
            FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = 131076
            FlowLayoutPanelValue.Controls.Find("TBVAL_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "Tessera base"
            a = (FlowLayoutPanelSerializza.Controls.Find("CBSER_" & NumericUpDownValoriCount.Value - 1, False)(0))
            a.Checked = False

            ' Profilo relè
            NumericUpDownValoriCount.Value += 1
            FlowLayoutPanelComando.Controls.Find("TBCMD_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "W07"
            FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = 131103
            FlowLayoutPanelValue.Controls.Find("TBVAL_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "1"
            a = (FlowLayoutPanelSerializza.Controls.Find("CBSER_" & NumericUpDownValoriCount.Value - 1, False)(0))
            a.Checked = False

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles ButtonCollaudo.Click
        If Not DropdownDevicesProfiles.Text = "ETSDN" Then
            If DropdownDevicesProfiles.SelectedIndex = 0 Then
                MsgBox("Selezionare il tipo di dispositivo da collaudare")
                Return
            End If
            'Or DropdownDevicesProfiles.Text = "MDT"
            TimerHeartRate.Stop()

            Dim log = checkPrediction()
            'Dim errCom = CBCom.SelectedItem Is Nothing
            'DropdownDevicesProfiles.SelectedItem = "ETSA1"
            If log = Not Cloud.LOGIN_RESULT.SUCCED Then
                MsgBox(" RIFARE IL LOGIN O NON PUOI USARE I PORTALI ")
            End If

            'If errCom Then
            'MsgBox(" Imposta la porta com")
            'Return
            'End If

            collaudoOpened = True
            collaudoIstance = New Collaudo(prediction, CheckboxFwEnableTouch.Checked)
            collaudoIstance.Show()
        Else
            collaudoETSDNopened = True
            MainEtsdn.Show()

        End If

    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles ButtonGenerateCloudCode.Click
        If prediction Is Nothing Then
            If TextboxPredictionUsername.Text.Length > 0 And TextboxPredictionPassword.Text.Length > 0 Then
                checkPrediction()
            Else
                MsgBox("Inserire le credenziali per l'accesso a Prediction")
                Return
            End If
        End If

        Dim serialData = prediction.createDeviceSerial("cloud_code")

        UI_ChangeControlText(TextboxCloudCode, serialData("serial"))
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

        Dim m_xmld As New XmlDocument
        m_xmld.Load(Application.StartupPath & "\grsats.xml")

        For Each nodo As XmlNode In m_xmld.SelectNodes("dati/dato")
            ComboBox1.Items.Add(nodo)
            If ComboBox1.SelectedItem = nodo.Attributes.GetNamedItem("D4").Value Then

                usermig = nodo.Attributes.GetNamedItem("D2").Value
                passmig = nodo.Attributes.GetNamedItem("D3").Value
                hostmig = nodo.Attributes.GetNamedItem("D8").Value
                trovaPortale += 1
            End If

        Next
    End Sub

    'Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

    '    ComboBoxPortale_Loading(Nothing, Nothing)
    'End Sub

    Private Sub ButtonLoginVecchioPortaleMig_Click(sender As Object, e As EventArgs) Handles ButtonLoginVecchioPortaleMig.Click
        If hostmig.Contains("http://") = False Then
            hostmig = "http://" & hostmig

            If hostmig.EndsWith("/") = False Then
                hostmig = hostmig & "/"
            End If

        End If
        'kiwisat = New GRSatTest(hostmig, usermig, passmig)
        kiwisat = selectedGRSat

        Try

            If kiwisat.login() = Cloud.LOGIN_RESULT.SUCCED Then
                MsgBox("Il login è avvenuto al vecchio portale è avvenuto")
                loginok = True

                Dim response = kiwisat.doGetRequest(hostmig & "/Mod_AssetMgmt//LoadXML.php?Tipo=1&modo=1&rand=")
                Dim xmlDoc As New XmlDocument
                xmlDoc.InnerXml = response
                For Each listanodi As XmlNode In xmlDoc.SelectNodes("dati/dato")
                    Dim units = listanodi.Attributes.GetNamedItem("D1").Value
                    'MsgBox(units)
                    ComboBox3.Items.Add(units)
                Next


            End If

        Catch ex As Exception
            MsgBox("errore login " & ex.Message)

        End Try

    End Sub



    Private Sub Button2_Click_3(sender As Object, e As EventArgs) Handles Button2.Click
        InitializeBasicComponents()
        Dim canChannels = getAvailableCanChannels()


        Dim abArray() As Byte
        ' ...
        ReDim abArray(11)


        For i = LBound(abArray) To UBound(abArray)
            abArray(i) = 1
        Next

        Dim data(7) As UInt32

        data = {2, 0, 1, 0, 1, 0, 1}

        Dim addr As UInt16 = data(0) Or (data(1) << 8)

        Dim mio As Byte = addr >> 0





        If init_CANOPEN(canChannels(0), TPCANOPENBaudrate.PCANOPENBAUD_500K, False) Then

            Dim canMsg As New TPCANOPENMsg()

            Dim tpCanOpen As New TPCANOPEN()

            tpCanOpen.node_ID = &B101
            tpCanOpen.funcion_ID = &B1011


            'Dim test As String = tpCanOpen.node_ID.ToString() & "_" & tpCanOpen.funcion_ID.ToString()

            ' accensione alimentazione device
            'canMsg.ID = (tpCanOpen.node_ID)_(tpCanOpen.funcion_ID)

            'canMsg.ID = &B10110000101

            Dim mask As Integer = &B1011_0000101

            Dim prova = (tpCanOpen.funcion_ID << 7 And &H780)
            Dim PROVA2 = (tpCanOpen.node_ID And &H7F)

            Dim prova3 = prova Or PROVA2

            canMsg.ID = prova3

            canMsg.LEN = 8
            canMsg.DATA = New Byte() {255, 255, 255, 255, 255, 255, 255, 255}

            sendCANMessage(canMsg)


            Dim raw_msg As New TPCANMsg
            While Not receiveCANMessage(raw_msg)

            End While

            MsgBox("ricevuto ID " & raw_msg.ID)

        End If

        unInit_CANOPEN()



    End Sub

    Private Sub ComboBox3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox3.TextChanged
        If loginok = True Then
            Dim response = kiwisat.doGetRequest(hostmig & "/Mod_AssetMgmt/LoadXML.php?Tipo=1&modo=2")
            System.Console.WriteLine(response)
        End If
    End Sub

    Private Sub GroupBox10_Enter(sender As Object, e As EventArgs) Handles GroupBox10.Enter
        ComboBoxPortale_Loading(Nothing, Nothing)
    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles ButtonCercaDispostivi.Click

        Dim SerialiS = Trim(TextBox1.Text)
        Dim SerialiScritti = SerialiS.Split(vbCrLf)
        Dim i = 0

        For Each Seriale As String In SerialiScritti
            If Not Seriale.Contains(vbLf) Then


                Dim SerialiScrittiMano = Seriale.Replace(vbLf, "")
                Dim response = kiwisat.doGetRequest(hostmig & "/Mod_AssetMgmt/LoadXML.php?Tipo=1&modo=2&seriale=" & SerialiScrittiMano)
                MsgBox(response)
                'System.Console.WriteLine(response)
            End If
        Next

        'For Each SerialiScrittiMano As String In SerialiScritti
        '    Select Case riscriviSerial
        '        Case 0
        '            If SerialiScrittiMano.StartsWith("") Then
        '                SerialiScritti(i) = "ETSA1_" & SerialiScrittiMano


        '                riscriviSerial += 1
        '            End If
        '        Case 1

        '            If SerialiScrittiMano.StartsWith("") And SerialiScrittiMano.StartsWith(vbLf) Then
        '                Dim abidu = SerialiScrittiMano.Replace(vbLf, "")
        '                SerialiScritti(i) = "ETSA1_" & abidu


        '            End If

        '    End Select
        '    i += 1
        'Next


        '
        'prendere ogni seriale e metterlo dentro variabile seriale 
        'in fine fare la chiamata
        'For Each 
        'Dim response = kiwisat.doGetRequest(Host & "/Mod_AssetMgmt/LoadXML.php?Tipo=1&modo=2&seriale=" & seriale)  ' questa è la chiamata,

    End Sub

    Private Sub setSerialNumberInUI(serial As String)
        Dim s = serial
        'If serial Is Nothing OrElse serial.Equals("") Then
        '    s = ""
        'End If

        UI_UpdateDeviceSerial(s)
        setGRSatAssetDataUI(serial = "")
    End Sub

    Private Sub generateSerialButton_Click(sender As Object, e As EventArgs) Handles ButtonGenerateSerialNumber.Click
        If prediction Is Nothing Then
            If TextboxPredictionUsername.Text.Length > 0 And TextboxPredictionPassword.Text.Length > 0 Then
                checkPrediction()
            Else
                MsgBox("Inserire le credenziali per l'accesso a Prediction")
                Return
            End If
        End If

        Dim prod As String = "default"
        'If DropdownDevicesProfiles.Text.Contains("MDT") Then
        '    prod = "mdt"
        'ElseIf DropdownDevicesProfiles.Text.Contains("X19") Then
        '    prod = "x19"
        'ElseIf DropdownDevicesProfiles.Text.Contains("ETSDN") Then
        '    prod = ""
        'ElseIf DropdownDevicesProfiles.Text.Contains("ETS") Then
        '    prod = "ets"
        'End If

        If prod Is Nothing Then
            MsgBox("Impossibile generare un seriale per " + connectedDeviceInfo.type)
            Return
        End If

        Dim serialData = prediction.createDeviceSerial(prod)

        setSerialNumberInUI(serialData("serial"))

        'If serialData.ContainsKey("cloud_code") And serialData("cloud_code") IsNot Nothing Then
        '    If serialData("cloud_code").Length > 0 Then
        '        UI_ChangeControlText(TextboxCloudCode, serialData("cloud_code"))
        '    End If
        'End If
    End Sub

    Private Sub ComboBoxConf_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxConf.SelectedIndexChanged
        current_config_stock = ""
    End Sub

    Private Sub ButtonDivineETSCANBaudSet_Click(sender As Object, e As EventArgs) Handles ButtonDivineETSCANBaudSet.Click
        NumericUpDownValoriCount.Value += 1
        Try
            FlowLayoutPanelComando.Controls.Find("TBCMD_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "W07"
            FlowLayoutPanelOffset.Controls.Find("NUDOFS_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = GRCONF + 50
            FlowLayoutPanelValue.Controls.Find("TBVAL_" & NumericUpDownValoriCount.Value - 1, False)(0).Text = "1"
            Dim a As CheckBox = (FlowLayoutPanelSerializza.Controls.Find("CBSER_" & NumericUpDownValoriCount.Value - 1, False)(0))
            a.Checked = True
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        End Try
    End Sub

    Sub addEtichettaRaw(model_code, model_desc, model_name, serial, dc_in, ma_in, ce_year)
        Try
            Dim find = bufferEtichette.Find(Function(x) x.SERIAL.Equals(serial))
            If find Is Nothing Then find = New etichetta

            With find
                .MODEL_CODE = model_code
                .MODEL_DESC = model_desc
                .MODEL_NAME = model_name
                .SERIAL = serial
                .DC_IN = dc_in
                .mA_IN = ma_in
                .CE_YEAR = ce_year
            End With

            Dim found As Boolean = False
            For Each etk In bufferEtichette
                If etk.SERIAL.Equals(find.SERIAL) Then
                    found = True
                    Exit For
                End If
            Next
            If Not found Then bufferEtichette.Add(find)

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    'Private Sub RadioButtonAutoNextRemote_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonAutoNextRemote.CheckedChanged

    '    If CheckBoxRemoteLolMaster.Checked Then
    '        TBserialnumber.Value = New String(Now.Year.ToString().Substring(2, 2) & Formatta00(Now.Month) & "00001")
    '    Else
    '        TBserialnumber.Value = 0
    '    End If

    '    CheckBoxDivineSync.Checked = RadioButtonAutoNextRemote.Checked
    'End Sub

    'Sub sendFreshSerial(destinationID As String, row As DataGridViewRow)
    '    Try
    '        Dim freshSerial As String = TBserialnumber.Value.ToString()

    '        If serialiDaRecuperare.Count > 0 Then
    '            serialiDaRecuperare.OrderBy(Function(x) x)
    '            freshSerial = serialiDaRecuperare(0)
    '            serialiDaRecuperare.RemoveAt(0)
    '        Else
    '            While ListBoxSeriali.Items.Contains(freshSerial) Or ListBoxSeriali.Items.Contains(freshSerial & " - confermato")
    '                freshSerial += 1
    '            End While
    '        End If


    '        ListBoxSeriali.Items.Add(freshSerial)
    '        Application.DoEvents()

    '        Dim sw As New Stopwatch()
    '        Dim timeout As Boolean = False
    '        sw.Reset()
    '        sw.Start()
    '        While Not row.Cells(CurrentSerial.Index).Value.Equals(freshSerial) And Not timeout
    '            Wait(250)
    '            Dim sendbuf As Byte() = Encoding.ASCII.GetBytes("FRESH-SERIAL|" & TextBoxRemoteLOLID.Text & "|" & destinationID & "|" & freshSerial)
    '            s.SendTo(sendbuf, ep)
    '            timeout = sw.ElapsedMilliseconds > 10000
    '        End While

    '        If timeout Then
    '            ListBoxSeriali.Items.Remove(freshSerial)
    '            serialiDaRecuperare.Add(freshSerial)
    '            Exit Try
    '        End If

    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try
    '    LabelSerialiDaRecuperare.Text = serialiDaRecuperare.Count & " da recuperare"
    'End Sub



    'Private Sub BAggiornaCP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BAggiornaCP.Click
    '    Call FillCP()
    'End Sub

    Private Sub BStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStop.Click
        STOPALL = True
        UI_Reset()

        TCicloSistema.Stop()

        If SerialPort.IsOpen AndAlso Not IsNothing(sender) Then SerialPort.Close()

        stoppa()
        avanzaDivine()
        clearFunzioneDivinaColors()

        confirmed_device = ""
        confirmed_HW = ""
        confirmed_Serial = ""
        current_usb_vid = ""
        current_usb_pid = ""
        current_config_otg = ""
        current_anagrafica_cmd = ""

        If soundTimer IsNot Nothing Then
            soundTimer.Stop()
        End If

        TextboxSerialNumber.Text = ""
        TextboxSerialNumber.Select()

        CheckboxConfigureDeviceOnGRSat.ForeColor = Color.Black
        CheckBoxTestInvioCloud.ForeColor = Color.Black
        disposeWait()

    End Sub


    Sub stoppa()
        ButtonUpdateFile.Enabled = True


        PBAcclrmtr.Value = 0
        PBCalibrazione.Value = 0
        PBConf.Value = 0
        PBF.Value = 0
        PBFU.Value = 0
        PBHR.Value = 0

        PBGPS.Value = 0
        PBSincDataOra.Value = 0
        LInvioHR.Text = "Test completato"
        LAccelerometro.Text = "Test completato"
        LTestGPS.Text = "Test completato"
        LSincDataOra.Text = "Test completato"
        LInvioHR.Visible = False
        LAccelerometro.Visible = False
        LTestGPS.Visible = False
        LSincDataOra.Visible = False

        LNomeNuovoFirmware.Text = ""

        'While ListBoxSeriali.Items.Contains(TBserialnumber.Value.ToString())
        '    TBserialnumber.Value += 1
        'End While

        Dim found = True
        While found
            found = False
            For Each itm As String In ListBoxCodiciCloud.Items
                If itm.Split("-")(1).ToString().Contains(TextboxCloudCode.Text) Then
                    found = True
                    If CheckboxWriteCloudCode.Checked AndAlso TextboxCloudCode.Text.Length > 2 AndAlso IsNumeric(TextboxCloudCode.Text.Substring(2)) Then
                        TextboxCloudCode.Text = TextboxCloudCode.Text.Substring(0, 2) & (TextboxCloudCode.Text.Substring(2) + 1).ToString().PadLeft(3, "0")
                        If CheckboxCreateDeviceOnGRSat.Enabled And CheckboxCreateDeviceOnGRSat.Checked And CheckBoxAutoFillAssetData.Checked And CheckBoxAutoFillAssetData.Enabled Then
                            setGRSatAssetDataUI(True)
                        End If
                    Else
                        found = False
                    End If
                    Exit For
                End If
            Next
        End While

        'If RadioButtonAutoNextRemote.Checked Then
        '    TBserialnumber.Value = 0
        'End If

        ButtonStart.Enabled = True
    End Sub


    Sub avanzaDivine()
        Try

            For i = 0 To FlowLayoutPanelComando.Controls.Count - 1
                Try
                    Dim valueTB As TextBox = FlowLayoutPanelValue.Controls.Find("TBVAL_" & i.ToString(), False)(0)
                    Dim serializza As CheckBox = FlowLayoutPanelSerializza.Controls.Find("CBSER_" & i.ToString(), False)(0)

                    If valueTB.ForeColor = Color.Green Then
                        If serializza.Checked AndAlso IsNumeric(valueTB.Text) Then
                            valueTB.Text += 1
                        End If
                    End If

                Catch ex As Exception
                    MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
                End Try
            Next
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub


    Sub AggiornaLog(ex As Exception)
        Try
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        Catch ex1 As Exception
            MessageBox.Show(ex.Message & vbLf & vbLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub ButtonUpdateFile_Click(sender As Object, e As EventArgs) Handles ButtonUpdateFile.Click
        systemStatus = "Downloading files"
        Try
            CercaFile.ShowDialog()
        Catch ex As Exception
            AggiornaLog(ex)
        Finally
            systemStatus = "Idle"
        End Try
    End Sub

    Private Sub CheckBoxAutoUSB_SET_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxAutoUSB_SET.CheckedChanged
        Try

            BSNPS.Enabled = Not sender.checked
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonCLearOldSerial_Click(sender As Object, e As EventArgs) Handles ButtonCLearOldSerial.Click
        Try
            If Not checkSerialErrors() Then Return
            If Not checkSerialUnsaved() Then Return
            ListBoxSeriali.Items.Clear()
            ListBoxCodiciCloud.Items.Clear()
            serialiDaRecuperare.Clear()
            bufferEtichette.Clear()
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub CheckBoxHWSetup_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxHWSetup.CheckedChanged
        Try
            GroupBoxHWSetup.Enabled = sender.checked
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CBVersioneHW_CheckedChanged(sender As Object, e As EventArgs) Handles CheckboxWriteHardwareCode.CheckedChanged
        Try

            CheckboxWriteProductString.Enabled = CheckboxWriteHardwareCode.Checked

            If Not IsNothing(DropdownDevicesProfiles.SelectedItem) AndAlso DropdownDevicesProfiles.SelectedItem.ToString.Contains("X19") Then
                CheckboxFwEnableModGps.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableModSD.Enabled = CheckboxWriteHardwareCode.Checked
                CheckboxFwEnableGPSUblox.Enabled = CheckboxWriteHardwareCode.Checked
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxCAN_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCAN.CheckedChanged

        TextBoxNodoCAN.Enabled = CheckBoxCAN.Checked
    End Sub

    Public Function computeImportPage(ByVal comando As String) As String
        If Not comando.StartsWith("W06 ") Or Not comando.Split(" ").Length > 2 Then Return comando

        Dim cmd As String() = comando.Split(" ")

        If Not cmd(2).Contains("K") Then Return comando

        Dim realPage As String = RDW_Command(cmd(0).Replace("W", "R"), cmd(1))

        For i = 0 To cmd(2).Length - 1
            If cmd(2)(i).ToString().ToUpper().Equals("K") Then
                Mid(cmd(2), i + 1, 1) = realPage(i)
            End If
        Next

        Return cmd(0) & " " & cmd(1) & " " & cmd(2)

    End Function


    'Public Delegate Sub updateRemoteLoListDelegate(data As String)
    'Public Sub updateRemoteLoList(data As String)
    '    Dim clean As New List(Of DataGridViewRow)
    '    Try
    '        If Me.InvokeRequired Then
    '            Me.Invoke(New updateRemoteLoListDelegate(AddressOf updateRemoteLoList), {data})
    '        Else

    '            Dim zzz = data.Split("|")

    '            If zzz(1).EndsWith("FL") Then ' il messaggio è un miniHR
    '                parseMiniHR(zzz)

    '            ElseIf zzz(1).Equals("FRESH-SERIAL") Then ' il messaggio è un invio di seriale libero dal master
    '                If CheckBoxRemoteLolMaster.Checked Then Exit Try ' io sono il master, ho inviato io questo messaggio

    '                Dim sendingID As String = zzz(2)
    '                Dim destinationID As String = zzz(3)

    '                If sendingID.Equals(TextBoxRemoteLOLID.Text) Then Exit Try ' il messaggio arriva da me, ignora
    '                If Not destinationID.Equals(TextBoxRemoteLOLID.Text) Then Exit Try ' il messaggio non è per questo slave

    '                For Each row As DataGridViewRow In DataGridViewRemoteLol.Rows
    '                    If sendingID.Equals(row.Cells(ID.Index).Value) Then ' il master che ha inviato il messaggio esiste davvero
    '                        If Not IsNumeric(zzz(4)) Then
    '                            LabelStatus.Text = "Errore di ricezione dal master x_x"
    '                            Exit Try
    '                        End If
    '                        freshSerial = zzz(4)
    '                        Exit For
    '                    End If
    '                Next

    '            Else
    '                Dim found = False
    '                For Each row As DataGridViewRow In DataGridViewRemoteLol.Rows
    '                    If row.Cells(0).Value Is Nothing Then Continue For

    '                    Dim oldness = DateTime.Now.Subtract(DateTime.Parse(Now.ToShortDateString() & " " & row.Cells(LastSeen.Index).Value)).Seconds

    '                    If oldness > 15 Then
    '                        clean.Add(row)
    '                    ElseIf oldness > 10 Then
    '                        row.DefaultCellStyle.BackColor = Color.Orange
    '                    ElseIf oldness > 2 Then
    '                        row.DefaultCellStyle.BackColor = Color.White
    '                    Else
    '                        row.DefaultCellStyle.BackColor = Color.LightGreen
    '                    End If

    '                    If row.Cells(0).Value.Equals(zzz(1)) Then
    '                        'è già in lista
    '                        found = True
    '                        fillRemoteLolData(row, data)
    '                        Continue For
    '                    End If
    '                Next

    '                If zzz(1).Equals(TextBoxRemoteLOLID.Text) Then Exit Try ' il messaggio arriva da me, ignora

    '                If Not found Then
    '                    DataGridViewRemoteLol.Rows.Add(zzz(1))
    '                    fillRemoteLolData(DataGridViewRemoteLol.Rows(DataGridViewRemoteLol.Rows.Count - 1), data)
    '                End If

    '            End If
    '        End If

    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    Finally
    '        For Each r In clean
    '            DataGridViewRemoteLol.Rows.Remove(r)
    '        Next
    '    End Try
    'End Sub


    'Private Sub fillRemoteLolData(row As DataGridViewRow, data As String)
    '    Try
    '        Dim dataz As String() = data.Split("|")


    '        row.Cells(1).Value = dataz(0)
    '        row.Cells(DataGridViewRemoteLol.Columns.Count - 1).Value = Now.ToLongTimeString()

    '        For i = 2 To dataz.Length - 1
    '            If i > DataGridViewRemoteLol.Columns.Count - 2 Then Exit For
    '            row.Cells(i).Value = dataz(i).Replace("$", "®")
    '        Next

    '    Catch ex As Exception
    '        AggiornaLog(ex)
    '    End Try
    'End Sub


    'Public Class UDPListener
    '    Private Const listenPort As Integer = RemoteLOLPort
    '    Shared t As Threading.Tasks.Task

    '    Dim listener As UdpClient
    '    Dim groupEP As IPEndPoint

    '    Dim tokenSource2 As New CancellationTokenSource()
    '    Dim ct As CancellationToken = tokenSource2.Token


    '    Private Sub StartListener()
    '        If t IsNot Nothing Then
    '            Return
    '        End If

    '        t = Task.Factory.StartNew(Sub()
    '                                      ' Were we already canceled?
    '                                      ct.ThrowIfCancellationRequested()

    '                                      Try
    '                                          runn()
    '                                      Catch e As Exception
    '                                          If e.Message.Equals("Lol") Then
    '                                              ct.ThrowIfCancellationRequested()
    '                                              Return
    '                                          End If
    '                                          instance.AggiornaLog(e)
    '                                      End Try
    '                                  End Sub _
    '                              , tokenSource2.Token)


    '    End Sub 'StartListener

    '    Sub runn()
    '        While instance.remoteLOListener IsNot Nothing

    '            If ct.IsCancellationRequested Then
    '                Throw New Exception("Lol")
    '            End If

    '            Dim bytes As Byte() = listener.Receive(groupEP)
    '            instance.updateRemoteLoList(groupEP.ToString().Split(":")(0) & "|" &
    '        Encoding.ASCII.GetString(bytes, 0, bytes.Length))

    '        End While
    '    End Sub

    '    Sub New()
    '        listener = New UdpClient()
    '        listener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, True)
    '        groupEP = New IPEndPoint(IPAddress.Any, listenPort)
    '        listener.Client.Bind(groupEP)
    '        StartListener()
    '    End Sub

    '    Sub dispose()
    '        If listener IsNot Nothing Then listener.Close()
    '        If Not t.IsCompleted Then tokenSource2.Cancel()
    '        t = Nothing
    '    End Sub

    'End Class 'UDPListener
End Class

Public Class DeviceInfo
    Public type As String = Nothing
    Public serial As String = Nothing
    Public cloudCode As String = Nothing

End Class

