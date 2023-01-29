<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Collaudo
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla mediante l'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.testComunicazioneMessage = New System.Windows.Forms.Label()
        Me.TimerTest = New System.Windows.Forms.Timer(Me.components)
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.TimerIconAndCubo = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.TimerRDWCommandR01 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerInserimetoParam = New System.Windows.Forms.Timer(Me.components)
        Me.TimerRichiestaParametri = New System.Windows.Forms.Timer(Me.components)
        Me.TabControlCollaudoBase = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ErrorInfo = New System.Windows.Forms.Button()
        Me.PanelEventUSB = New System.Windows.Forms.Panel()
        Me.LabelErrorUSB = New System.Windows.Forms.Label()
        Me.PictureUSBscollegato = New System.Windows.Forms.PictureBox()
        Me.PictureErrorUSB = New System.Windows.Forms.PictureBox()
        Me.UpdateIP = New System.Windows.Forms.Button()
        Me.ButtonErrorView = New System.Windows.Forms.Button()
        Me.OpenLog = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBoxApn = New System.Windows.Forms.ComboBox()
        Me.BarcodeReader = New System.Windows.Forms.PictureBox()
        Me.LabelIp = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.InfoRS232 = New System.Windows.Forms.PictureBox()
        Me.ErrorRS232 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBConfRS232 = New System.Windows.Forms.ComboBox()
        Me.LeggiCodRS232 = New System.Windows.Forms.Button()
        Me.LabelCodRS232 = New System.Windows.Forms.Label()
        Me.CheckRS232 = New System.Windows.Forms.CheckBox()
        Me.ResetP90 = New System.Windows.Forms.Button()
        Me.ButtonSync = New System.Windows.Forms.Button()
        Me.PanelPortale = New System.Windows.Forms.Panel()
        Me.InfoPORT = New System.Windows.Forms.PictureBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.testComunicazioneStatus = New System.Windows.Forms.PictureBox()
        Me.PictureBoxDevice = New System.Windows.Forms.PictureBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LabelSpacePOrtale = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.PictureBoxComunicazione = New System.Windows.Forms.PictureBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LoadingPortale = New System.Windows.Forms.PictureBox()
        Me.CheckBoxPortale = New System.Windows.Forms.CheckBox()
        Me.ButtonStartTest = New System.Windows.Forms.Button()
        Me.LabelMongostatus = New System.Windows.Forms.Label()
        Me.ProgressBarTest = New System.Windows.Forms.ProgressBar()
        Me.ButtonMongoCollaudo = New System.Windows.Forms.Button()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.CollaudoScheda = New System.Windows.Forms.CheckBox()
        Me.PanelCAN = New System.Windows.Forms.Panel()
        Me.InfoCAN = New System.Windows.Forms.PictureBox()
        Me.CAN2_NOT = New System.Windows.Forms.PictureBox()
        Me.CAN1_NOT = New System.Windows.Forms.PictureBox()
        Me.ErrorTestCAN = New System.Windows.Forms.PictureBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.CAN2_OK = New System.Windows.Forms.PictureBox()
        Me.CAN1_OK = New System.Windows.Forms.PictureBox()
        Me.TestCANMessage = New System.Windows.Forms.Label()
        Me.TestCANStatus = New System.Windows.Forms.PictureBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.LoadingCAN = New System.Windows.Forms.PictureBox()
        Me.CheckBoxCAN = New System.Windows.Forms.CheckBox()
        Me.PanelIngressi = New System.Windows.Forms.Panel()
        Me.IP2_NOT = New System.Windows.Forms.PictureBox()
        Me.IP2_0K = New System.Windows.Forms.PictureBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.InfoIP = New System.Windows.Forms.PictureBox()
        Me.IP4_NOT = New System.Windows.Forms.PictureBox()
        Me.IP3_NOT = New System.Windows.Forms.PictureBox()
        Me.IP1_NOT = New System.Windows.Forms.PictureBox()
        Me.ErrorTestIP = New System.Windows.Forms.PictureBox()
        Me.AnalogicIP4 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.IP4_OK = New System.Windows.Forms.PictureBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.TestIngressiMessage = New System.Windows.Forms.Label()
        Me.IP3_OK = New System.Windows.Forms.PictureBox()
        Me.IP3 = New System.Windows.Forms.Label()
        Me.testIngressiStatus = New System.Windows.Forms.PictureBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.IP1_OK = New System.Windows.Forms.PictureBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.LoadingIP = New System.Windows.Forms.PictureBox()
        Me.CheckBoxIngressi = New System.Windows.Forms.CheckBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.CheckBoxSelezionaTutti = New System.Windows.Forms.CheckBox()
        Me.Panel5V = New System.Windows.Forms.Panel()
        Me.Info5V = New System.Windows.Forms.PictureBox()
        Me.V5_NOT = New System.Windows.Forms.PictureBox()
        Me.ErrorTest5V = New System.Windows.Forms.PictureBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.V5_OK = New System.Windows.Forms.PictureBox()
        Me.Valore5V = New System.Windows.Forms.Label()
        Me.Test5VMessage = New System.Windows.Forms.Label()
        Me.test5Vstatus = New System.Windows.Forms.PictureBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Loading5V = New System.Windows.Forms.PictureBox()
        Me.CheckBox5V = New System.Windows.Forms.CheckBox()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.PanelRelè = New System.Windows.Forms.Panel()
        Me.vCurrent2 = New System.Windows.Forms.Label()
        Me.vCurrent1 = New System.Windows.Forms.Label()
        Me.InfoRL = New System.Windows.Forms.PictureBox()
        Me.TestReleStatus = New System.Windows.Forms.PictureBox()
        Me.ErrorTestRL = New System.Windows.Forms.PictureBox()
        Me.RL2_NOT = New System.Windows.Forms.PictureBox()
        Me.RL1_NOT = New System.Windows.Forms.PictureBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.RL1_OK = New System.Windows.Forms.PictureBox()
        Me.RL2_OK = New System.Windows.Forms.PictureBox()
        Me.LoadingRL = New System.Windows.Forms.PictureBox()
        Me.TestReleMessage = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.CheckBoxRele = New System.Windows.Forms.CheckBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.PanelAlimentazione = New System.Windows.Forms.Panel()
        Me.TensioneEsterna = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.InfoPWR = New System.Windows.Forms.PictureBox()
        Me.PWR_NOT = New System.Windows.Forms.PictureBox()
        Me.PWR_OK = New System.Windows.Forms.PictureBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ErrorTestPWR = New System.Windows.Forms.PictureBox()
        Me.TestAlimentazioneStatus = New System.Windows.Forms.PictureBox()
        Me.LoadingPWR = New System.Windows.Forms.PictureBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.testAlimentazioneMessage = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.CheckBoxAlimentazione = New System.Windows.Forms.CheckBox()
        Me.LabelORA = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.testETS_ETSDNStatus = New System.Windows.Forms.PictureBox()
        Me.CheckBoxETSDN = New System.Windows.Forms.CheckBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.CheckBoxOverrideETSDN = New System.Windows.Forms.CheckBox()
        Me.LabelRespFromAssocETSDN = New System.Windows.Forms.Label()
        Me.labelOverride = New System.Windows.Forms.Label()
        Me.TextBoxSerialeETSDN = New System.Windows.Forms.TextBox()
        Me.ButtonAssocETSDN = New System.Windows.Forms.Button()
        Me.LabelSerialeETSDN = New System.Windows.Forms.Label()
        Me.LabelDATA = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.testUtenzaMessage = New System.Windows.Forms.Label()
        Me.testUtenzaStatus = New System.Windows.Forms.PictureBox()
        Me.CheckBoxUtenza = New System.Windows.Forms.CheckBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.labelSerialNumber = New System.Windows.Forms.Label()
        Me.LabelCom = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.PanelSync = New System.Windows.Forms.Panel()
        Me.InfoMemory = New System.Windows.Forms.PictureBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.testMemsyncMessage = New System.Windows.Forms.Label()
        Me.testMemsyncExportPercentage = New System.Windows.Forms.Label()
        Me.testMemsyncStatus = New System.Windows.Forms.PictureBox()
        Me.PictureBox1ImpotaMemoria = New System.Windows.Forms.PictureBox()
        Me.PictureBox1EsportaMemoria = New System.Windows.Forms.PictureBox()
        Me.PictureBox1Sync = New System.Windows.Forms.PictureBox()
        Me.PictureBox2L03Peso = New System.Windows.Forms.PictureBox()
        Me.PictureBox1formattazione = New System.Windows.Forms.PictureBox()
        Me.LoadingSync = New System.Windows.Forms.PictureBox()
        Me.CheckBoxMemoria = New System.Windows.Forms.CheckBox()
        Me.Label28Portale = New System.Windows.Forms.Label()
        Me.PanelBadge = New System.Windows.Forms.Panel()
        Me.testBadgeStatus = New System.Windows.Forms.PictureBox()
        Me.testBadgeMessage = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.LabelUidBadge = New System.Windows.Forms.Label()
        Me.LoadingBadge = New System.Windows.Forms.PictureBox()
        Me.CheckBoxBadge = New System.Windows.Forms.CheckBox()
        Me.PanelWifi = New System.Windows.Forms.Panel()
        Me.InfoWIFI = New System.Windows.Forms.PictureBox()
        Me.testWifiMessage = New System.Windows.Forms.Label()
        Me.testWifiStatus = New System.Windows.Forms.PictureBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LabelMacAddress = New System.Windows.Forms.Label()
        Me.LoadingWIFI = New System.Windows.Forms.PictureBox()
        Me.CheckBoxWifFi = New System.Windows.Forms.CheckBox()
        Me.PanelSD = New System.Windows.Forms.Panel()
        Me.InfoSD = New System.Windows.Forms.PictureBox()
        Me.testSDStatus = New System.Windows.Forms.PictureBox()
        Me.testSDMessage = New System.Windows.Forms.Label()
        Me.PictureBoxSD1 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxSD2 = New System.Windows.Forms.PictureBox()
        Me.LabelSD2 = New System.Windows.Forms.Label()
        Me.LabelSD1 = New System.Windows.Forms.Label()
        Me.LoadingSD = New System.Windows.Forms.PictureBox()
        Me.CheckBoxSD = New System.Windows.Forms.CheckBox()
        Me.PanelBatteria = New System.Windows.Forms.Panel()
        Me.InfoBAT = New System.Windows.Forms.PictureBox()
        Me.testBatteryStatusCode = New System.Windows.Forms.Label()
        Me.testBatteryMessage = New System.Windows.Forms.Label()
        Me.testBatteryStatus = New System.Windows.Forms.PictureBox()
        Me.LabelSpaceTensione = New System.Windows.Forms.Label()
        Me.PictureBox1Battery = New System.Windows.Forms.PictureBox()
        Me.PictureBox2Battery = New System.Windows.Forms.PictureBox()
        Me.LabelBattery2 = New System.Windows.Forms.Label()
        Me.LabelBattery1 = New System.Windows.Forms.Label()
        Me.LoadingBattery = New System.Windows.Forms.PictureBox()
        Me.CheckBoxBatteria = New System.Windows.Forms.CheckBox()
        Me.PanelAccelerometro = New System.Windows.Forms.Panel()
        Me.InfoACC = New System.Windows.Forms.PictureBox()
        Me.testAccelerometerMessage = New System.Windows.Forms.Label()
        Me.testAccelerometerStatus = New System.Windows.Forms.PictureBox()
        Me.LabelGradiInclinazione = New System.Windows.Forms.Label()
        Me.LabelInclinazione = New System.Windows.Forms.Label()
        Me.PictureBoxAzzeramento = New System.Windows.Forms.PictureBox()
        Me.LabelAccelerometro2 = New System.Windows.Forms.Label()
        Me.PictureBox1Accelerometro = New System.Windows.Forms.PictureBox()
        Me.LabelAccelerometro1 = New System.Windows.Forms.Label()
        Me.GifAcc = New System.Windows.Forms.PictureBox()
        Me.LoadingAcc = New System.Windows.Forms.PictureBox()
        Me.CheckBoxAccelerometro = New System.Windows.Forms.CheckBox()
        Me.PanelSim = New System.Windows.Forms.Panel()
        Me.InfoSIM = New System.Windows.Forms.PictureBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.testSIMMessage = New System.Windows.Forms.Label()
        Me.testSIMStatus = New System.Windows.Forms.PictureBox()
        Me.LabelSim2 = New System.Windows.Forms.Label()
        Me.PictureBoxSim1 = New System.Windows.Forms.PictureBox()
        Me.PictureBoxSim2 = New System.Windows.Forms.PictureBox()
        Me.LabelSim1 = New System.Windows.Forms.Label()
        Me.LoadingSIM = New System.Windows.Forms.PictureBox()
        Me.CheckBoxSim = New System.Windows.Forms.CheckBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.TabControlCollaudoBase.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PanelEventUSB.SuspendLayout()
        CType(Me.PictureUSBscollegato, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureErrorUSB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarcodeReader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.InfoRS232, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorRS232, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPortale.SuspendLayout()
        CType(Me.InfoPORT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testComunicazioneStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxDevice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxComunicazione, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingPortale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelCAN.SuspendLayout()
        CType(Me.InfoCAN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAN2_NOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAN1_NOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorTestCAN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAN2_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAN1_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestCANStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingCAN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelIngressi.SuspendLayout()
        CType(Me.IP2_NOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IP2_0K, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InfoIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IP4_NOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IP3_NOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IP1_NOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorTestIP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IP4_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IP3_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testIngressiStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IP1_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingIP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5V.SuspendLayout()
        CType(Me.Info5V, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.V5_NOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorTest5V, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.V5_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.test5Vstatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Loading5V, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelRelè.SuspendLayout()
        CType(Me.InfoRL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestReleStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorTestRL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RL2_NOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RL1_NOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RL1_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RL2_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingRL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAlimentazione.SuspendLayout()
        CType(Me.InfoPWR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PWR_NOT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PWR_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorTestPWR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TestAlimentazioneStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingPWR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.testETS_ETSDNStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.testUtenzaStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSync.SuspendLayout()
        CType(Me.InfoMemory, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testMemsyncStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1ImpotaMemoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1EsportaMemoria, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1Sync, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2L03Peso, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1formattazione, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingSync, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBadge.SuspendLayout()
        CType(Me.testBadgeStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingBadge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelWifi.SuspendLayout()
        CType(Me.InfoWIFI, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testWifiStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingWIFI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSD.SuspendLayout()
        CType(Me.InfoSD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testSDStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxSD1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxSD2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingSD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBatteria.SuspendLayout()
        CType(Me.InfoBAT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testBatteryStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1Battery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2Battery, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingBattery, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelAccelerometro.SuspendLayout()
        CType(Me.InfoACC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testAccelerometerStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxAzzeramento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1Accelerometro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GifAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelSim.SuspendLayout()
        CType(Me.InfoSIM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.testSIMStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxSim1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxSim2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LoadingSIM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'testComunicazioneMessage
        '
        Me.testComunicazioneMessage.AutoSize = True
        Me.testComunicazioneMessage.ForeColor = System.Drawing.Color.Red
        Me.testComunicazioneMessage.Location = New System.Drawing.Point(3, 129)
        Me.testComunicazioneMessage.Name = "testComunicazioneMessage"
        Me.testComunicazioneMessage.Size = New System.Drawing.Size(16, 13)
        Me.testComunicazioneMessage.TabIndex = 24
        Me.testComunicazioneMessage.Text = "..."
        '
        'TimerTest
        '
        Me.TimerTest.Interval = 500
        '
        'OFD
        '
        Me.OFD.FileName = "OFD"
        '
        'TimerRDWCommandR01
        '
        Me.TimerRDWCommandR01.Interval = 1000
        '
        'TimerInserimetoParam
        '
        Me.TimerInserimetoParam.Interval = 1000
        '
        'TimerRichiestaParametri
        '
        Me.TimerRichiestaParametri.Interval = 1000
        Me.TimerRichiestaParametri.Tag = ""
        '
        'TabControlCollaudoBase
        '
        Me.TabControlCollaudoBase.Controls.Add(Me.TabPage1)
        Me.TabControlCollaudoBase.Location = New System.Drawing.Point(-5, -28)
        Me.TabControlCollaudoBase.Name = "TabControlCollaudoBase"
        Me.TabControlCollaudoBase.SelectedIndex = 0
        Me.TabControlCollaudoBase.Size = New System.Drawing.Size(1186, 797)
        Me.TabControlCollaudoBase.TabIndex = 76
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.TabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.TabPage1.Controls.Add(Me.ErrorInfo)
        Me.TabPage1.Controls.Add(Me.PanelEventUSB)
        Me.TabPage1.Controls.Add(Me.UpdateIP)
        Me.TabPage1.Controls.Add(Me.ButtonErrorView)
        Me.TabPage1.Controls.Add(Me.OpenLog)
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.ComboBoxApn)
        Me.TabPage1.Controls.Add(Me.BarcodeReader)
        Me.TabPage1.Controls.Add(Me.LabelIp)
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Controls.Add(Me.ResetP90)
        Me.TabPage1.Controls.Add(Me.ButtonSync)
        Me.TabPage1.Controls.Add(Me.PanelPortale)
        Me.TabPage1.Controls.Add(Me.ButtonStartTest)
        Me.TabPage1.Controls.Add(Me.LabelMongostatus)
        Me.TabPage1.Controls.Add(Me.ProgressBarTest)
        Me.TabPage1.Controls.Add(Me.ButtonMongoCollaudo)
        Me.TabPage1.Controls.Add(Me.Label54)
        Me.TabPage1.Controls.Add(Me.CollaudoScheda)
        Me.TabPage1.Controls.Add(Me.PanelCAN)
        Me.TabPage1.Controls.Add(Me.PanelIngressi)
        Me.TabPage1.Controls.Add(Me.LinkLabel1)
        Me.TabPage1.Controls.Add(Me.CheckBoxSelezionaTutti)
        Me.TabPage1.Controls.Add(Me.Panel5V)
        Me.TabPage1.Controls.Add(Me.ButtonStop)
        Me.TabPage1.Controls.Add(Me.Label32)
        Me.TabPage1.Controls.Add(Me.PanelRelè)
        Me.TabPage1.Controls.Add(Me.Label31)
        Me.TabPage1.Controls.Add(Me.PanelAlimentazione)
        Me.TabPage1.Controls.Add(Me.LabelORA)
        Me.TabPage1.Controls.Add(Me.Panel2)
        Me.TabPage1.Controls.Add(Me.LabelDATA)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.Label38)
        Me.TabPage1.Controls.Add(Me.labelSerialNumber)
        Me.TabPage1.Controls.Add(Me.LabelCom)
        Me.TabPage1.Controls.Add(Me.Label30)
        Me.TabPage1.Controls.Add(Me.Label28)
        Me.TabPage1.Controls.Add(Me.PanelSync)
        Me.TabPage1.Controls.Add(Me.Label28Portale)
        Me.TabPage1.Controls.Add(Me.PanelBadge)
        Me.TabPage1.Controls.Add(Me.PanelWifi)
        Me.TabPage1.Controls.Add(Me.PanelSD)
        Me.TabPage1.Controls.Add(Me.PanelBatteria)
        Me.TabPage1.Controls.Add(Me.PanelAccelerometro)
        Me.TabPage1.Controls.Add(Me.PanelSim)
        Me.TabPage1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1178, 771)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "Collaudo"
        '
        'ErrorInfo
        '
        Me.ErrorInfo.BackColor = System.Drawing.Color.Transparent
        Me.ErrorInfo.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.ErrorInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ErrorInfo.Location = New System.Drawing.Point(984, 6)
        Me.ErrorInfo.Name = "ErrorInfo"
        Me.ErrorInfo.Size = New System.Drawing.Size(48, 47)
        Me.ErrorInfo.TabIndex = 147
        Me.ErrorInfo.UseVisualStyleBackColor = False
        '
        'PanelEventUSB
        '
        Me.PanelEventUSB.Controls.Add(Me.LabelErrorUSB)
        Me.PanelEventUSB.Controls.Add(Me.PictureUSBscollegato)
        Me.PanelEventUSB.Controls.Add(Me.PictureErrorUSB)
        Me.PanelEventUSB.Location = New System.Drawing.Point(11, 588)
        Me.PanelEventUSB.Name = "PanelEventUSB"
        Me.PanelEventUSB.Size = New System.Drawing.Size(192, 132)
        Me.PanelEventUSB.TabIndex = 146
        '
        'LabelErrorUSB
        '
        Me.LabelErrorUSB.AutoSize = True
        Me.LabelErrorUSB.Location = New System.Drawing.Point(74, 112)
        Me.LabelErrorUSB.Name = "LabelErrorUSB"
        Me.LabelErrorUSB.Size = New System.Drawing.Size(16, 13)
        Me.LabelErrorUSB.TabIndex = 147
        Me.LabelErrorUSB.Text = "..."
        '
        'PictureUSBscollegato
        '
        Me.PictureUSBscollegato.Image = Global.FlashedLOL.My.Resources.Res.USBscollegato1
        Me.PictureUSBscollegato.Location = New System.Drawing.Point(97, 16)
        Me.PictureUSBscollegato.Name = "PictureUSBscollegato"
        Me.PictureUSBscollegato.Size = New System.Drawing.Size(92, 93)
        Me.PictureUSBscollegato.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureUSBscollegato.TabIndex = 148
        Me.PictureUSBscollegato.TabStop = False
        '
        'PictureErrorUSB
        '
        Me.PictureErrorUSB.Image = Global.FlashedLOL.My.Resources.Res.USB
        Me.PictureErrorUSB.Location = New System.Drawing.Point(5, 16)
        Me.PictureErrorUSB.Name = "PictureErrorUSB"
        Me.PictureErrorUSB.Size = New System.Drawing.Size(92, 93)
        Me.PictureErrorUSB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureErrorUSB.TabIndex = 147
        Me.PictureErrorUSB.TabStop = False
        '
        'UpdateIP
        '
        Me.UpdateIP.BackColor = System.Drawing.Color.Transparent
        Me.UpdateIP.CausesValidation = False
        Me.UpdateIP.Cursor = System.Windows.Forms.Cursors.Default
        Me.UpdateIP.Enabled = False
        Me.UpdateIP.Font = New System.Drawing.Font("Microsoft JhengHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpdateIP.Location = New System.Drawing.Point(844, 137)
        Me.UpdateIP.Name = "UpdateIP"
        Me.UpdateIP.Size = New System.Drawing.Size(42, 28)
        Me.UpdateIP.TabIndex = 126
        Me.UpdateIP.Text = "IP"
        Me.UpdateIP.UseVisualStyleBackColor = False
        '
        'ButtonErrorView
        '
        Me.ButtonErrorView.BackColor = System.Drawing.Color.Red
        Me.ButtonErrorView.Location = New System.Drawing.Point(844, 53)
        Me.ButtonErrorView.Name = "ButtonErrorView"
        Me.ButtonErrorView.Size = New System.Drawing.Size(96, 32)
        Me.ButtonErrorView.TabIndex = 145
        Me.ButtonErrorView.Text = "Visualizza Errori"
        Me.ButtonErrorView.UseVisualStyleBackColor = False
        Me.ButtonErrorView.Visible = False
        '
        'OpenLog
        '
        Me.OpenLog.BackColor = System.Drawing.Color.Orange
        Me.OpenLog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.OpenLog.Cursor = System.Windows.Forms.Cursors.Default
        Me.OpenLog.Location = New System.Drawing.Point(946, 54)
        Me.OpenLog.Name = "OpenLog"
        Me.OpenLog.Size = New System.Drawing.Size(86, 31)
        Me.OpenLog.TabIndex = 128
        Me.OpenLog.Text = "OpenLog"
        Me.OpenLog.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.CausesValidation = False
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.Enabled = False
        Me.Button1.Font = New System.Drawing.Font("Microsoft JhengHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(844, 108)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(101, 24)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "CAMBIA APN"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ComboBoxApn
        '
        Me.ComboBoxApn.FormattingEnabled = True
        Me.ComboBoxApn.Location = New System.Drawing.Point(951, 111)
        Me.ComboBoxApn.Name = "ComboBoxApn"
        Me.ComboBoxApn.Size = New System.Drawing.Size(81, 21)
        Me.ComboBoxApn.TabIndex = 58
        '
        'BarcodeReader
        '
        Me.BarcodeReader.BackColor = System.Drawing.Color.Transparent
        Me.BarcodeReader.BackgroundImage = Global.FlashedLOL.My.Resources.Res.image1
        Me.BarcodeReader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.BarcodeReader.Enabled = False
        Me.BarcodeReader.Location = New System.Drawing.Point(219, 571)
        Me.BarcodeReader.Name = "BarcodeReader"
        Me.BarcodeReader.Size = New System.Drawing.Size(465, 116)
        Me.BarcodeReader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.BarcodeReader.TabIndex = 125
        Me.BarcodeReader.TabStop = False
        Me.BarcodeReader.Visible = False
        '
        'LabelIp
        '
        Me.LabelIp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelIp.Location = New System.Drawing.Point(892, 142)
        Me.LabelIp.MinimumSize = New System.Drawing.Size(120, 15)
        Me.LabelIp.Name = "LabelIp"
        Me.LabelIp.Size = New System.Drawing.Size(140, 20)
        Me.LabelIp.TabIndex = 60
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.White
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.InfoRS232)
        Me.Panel3.Controls.Add(Me.ErrorRS232)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.CBConfRS232)
        Me.Panel3.Controls.Add(Me.LeggiCodRS232)
        Me.Panel3.Controls.Add(Me.LabelCodRS232)
        Me.Panel3.Controls.Add(Me.CheckRS232)
        Me.Panel3.Location = New System.Drawing.Point(631, 427)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(195, 138)
        Me.Panel3.TabIndex = 124
        '
        'InfoRS232
        '
        Me.InfoRS232.BackColor = System.Drawing.Color.Transparent
        Me.InfoRS232.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoRS232.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoRS232.Location = New System.Drawing.Point(57, 1)
        Me.InfoRS232.Name = "InfoRS232"
        Me.InfoRS232.Size = New System.Drawing.Size(20, 24)
        Me.InfoRS232.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoRS232.TabIndex = 157
        Me.InfoRS232.TabStop = False
        '
        'ErrorRS232
        '
        Me.ErrorRS232.BackColor = System.Drawing.Color.Transparent
        Me.ErrorRS232.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ErrorRS232.Image = Global.FlashedLOL.My.Resources.Res.Triangolo_giallo
        Me.ErrorRS232.Location = New System.Drawing.Point(116, 40)
        Me.ErrorRS232.Name = "ErrorRS232"
        Me.ErrorRS232.Size = New System.Drawing.Size(71, 58)
        Me.ErrorRS232.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ErrorRS232.TabIndex = 120
        Me.ErrorRS232.TabStop = False
        Me.ErrorRS232.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 5)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "RS232"
        '
        'CBConfRS232
        '
        Me.CBConfRS232.FormattingEnabled = True
        Me.CBConfRS232.Items.AddRange(New Object() {"AEZ MC3", "COELMO LEXYS", "LMI 002 (MD83)", "iButton", "Barcode Reader"})
        Me.CBConfRS232.Location = New System.Drawing.Point(78, 5)
        Me.CBConfRS232.Name = "CBConfRS232"
        Me.CBConfRS232.Size = New System.Drawing.Size(109, 21)
        Me.CBConfRS232.TabIndex = 126
        Me.CBConfRS232.Tag = "COSP2"
        '
        'LeggiCodRS232
        '
        Me.LeggiCodRS232.BackColor = System.Drawing.Color.Transparent
        Me.LeggiCodRS232.Location = New System.Drawing.Point(10, 75)
        Me.LeggiCodRS232.Name = "LeggiCodRS232"
        Me.LeggiCodRS232.Size = New System.Drawing.Size(89, 23)
        Me.LeggiCodRS232.TabIndex = 125
        Me.LeggiCodRS232.Text = "Leggi "
        Me.LeggiCodRS232.UseVisualStyleBackColor = False
        '
        'LabelCodRS232
        '
        Me.LabelCodRS232.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCodRS232.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCodRS232.Location = New System.Drawing.Point(10, 101)
        Me.LabelCodRS232.Name = "LabelCodRS232"
        Me.LabelCodRS232.Size = New System.Drawing.Size(174, 21)
        Me.LabelCodRS232.TabIndex = 19
        '
        'CheckRS232
        '
        Me.CheckRS232.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckRS232.Checked = True
        Me.CheckRS232.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckRS232.Location = New System.Drawing.Point(2, 3)
        Me.CheckRS232.Name = "CheckRS232"
        Me.CheckRS232.Size = New System.Drawing.Size(70, 33)
        Me.CheckRS232.TabIndex = 121
        Me.CheckRS232.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckRS232.UseVisualStyleBackColor = True
        '
        'ResetP90
        '
        Me.ResetP90.BackColor = System.Drawing.Color.LimeGreen
        Me.ResetP90.ForeColor = System.Drawing.Color.Black
        Me.ResetP90.Location = New System.Drawing.Point(172, 46)
        Me.ResetP90.Name = "ResetP90"
        Me.ResetP90.Size = New System.Drawing.Size(112, 29)
        Me.ResetP90.TabIndex = 123
        Me.ResetP90.Text = "Reset Dispositivo "
        Me.ResetP90.UseVisualStyleBackColor = False
        '
        'ButtonSync
        '
        Me.ButtonSync.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonSync.CausesValidation = False
        Me.ButtonSync.Cursor = System.Windows.Forms.Cursors.Default
        Me.ButtonSync.Font = New System.Drawing.Font("Microsoft JhengHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSync.Location = New System.Drawing.Point(172, 12)
        Me.ButtonSync.Name = "ButtonSync"
        Me.ButtonSync.Size = New System.Drawing.Size(67, 28)
        Me.ButtonSync.TabIndex = 65
        Me.ButtonSync.Text = "SYNC"
        Me.ButtonSync.UseVisualStyleBackColor = False
        '
        'PanelPortale
        '
        Me.PanelPortale.BackColor = System.Drawing.Color.White
        Me.PanelPortale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelPortale.Controls.Add(Me.InfoPORT)
        Me.PanelPortale.Controls.Add(Me.Label59)
        Me.PanelPortale.Controls.Add(Me.testComunicazioneStatus)
        Me.PanelPortale.Controls.Add(Me.PictureBoxDevice)
        Me.PanelPortale.Controls.Add(Me.Label14)
        Me.PanelPortale.Controls.Add(Me.LabelSpacePOrtale)
        Me.PanelPortale.Controls.Add(Me.Label13)
        Me.PanelPortale.Controls.Add(Me.PictureBoxComunicazione)
        Me.PanelPortale.Controls.Add(Me.Label12)
        Me.PanelPortale.Controls.Add(Me.LoadingPortale)
        Me.PanelPortale.Controls.Add(Me.CheckBoxPortale)
        Me.PanelPortale.Location = New System.Drawing.Point(213, 310)
        Me.PanelPortale.Name = "PanelPortale"
        Me.PanelPortale.Size = New System.Drawing.Size(195, 94)
        Me.PanelPortale.TabIndex = 102
        '
        'InfoPORT
        '
        Me.InfoPORT.BackColor = System.Drawing.Color.Transparent
        Me.InfoPORT.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoPORT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoPORT.Location = New System.Drawing.Point(107, -1)
        Me.InfoPORT.Name = "InfoPORT"
        Me.InfoPORT.Size = New System.Drawing.Size(20, 24)
        Me.InfoPORT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoPORT.TabIndex = 154
        Me.InfoPORT.TabStop = False
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.ForeColor = System.Drawing.Color.Red
        Me.Label59.Location = New System.Drawing.Point(9, 88)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(16, 13)
        Me.Label59.TabIndex = 25
        Me.Label59.Text = "..."
        '
        'testComunicazioneStatus
        '
        Me.testComunicazioneStatus.BackColor = System.Drawing.Color.Transparent
        Me.testComunicazioneStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.testComunicazioneStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.testComunicazioneStatus.Location = New System.Drawing.Point(158, -1)
        Me.testComunicazioneStatus.Name = "testComunicazioneStatus"
        Me.testComunicazioneStatus.Size = New System.Drawing.Size(34, 39)
        Me.testComunicazioneStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testComunicazioneStatus.TabIndex = 24
        Me.testComunicazioneStatus.TabStop = False
        Me.testComunicazioneStatus.Visible = False
        '
        'PictureBoxDevice
        '
        Me.PictureBoxDevice.Location = New System.Drawing.Point(93, 34)
        Me.PictureBoxDevice.Name = "PictureBoxDevice"
        Me.PictureBoxDevice.Size = New System.Drawing.Size(14, 13)
        Me.PictureBoxDevice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxDevice.TabIndex = 13
        Me.PictureBoxDevice.TabStop = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(84, 15)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Device Trovato"
        '
        'LabelSpacePOrtale
        '
        Me.LabelSpacePOrtale.AutoSize = True
        Me.LabelSpacePOrtale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSpacePOrtale.Location = New System.Drawing.Point(39, 73)
        Me.LabelSpacePOrtale.MinimumSize = New System.Drawing.Size(120, 15)
        Me.LabelSpacePOrtale.Name = "LabelSpacePOrtale"
        Me.LabelSpacePOrtale.Size = New System.Drawing.Size(120, 15)
        Me.LabelSpacePOrtale.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 73)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 15)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Con:"
        '
        'PictureBoxComunicazione
        '
        Me.PictureBoxComunicazione.Location = New System.Drawing.Point(93, 53)
        Me.PictureBoxComunicazione.Name = "PictureBoxComunicazione"
        Me.PictureBoxComunicazione.Size = New System.Drawing.Size(14, 13)
        Me.PictureBoxComunicazione.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxComunicazione.TabIndex = 8
        Me.PictureBoxComunicazione.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 15)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Comunico"
        '
        'LoadingPortale
        '
        Me.LoadingPortale.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingPortale.Location = New System.Drawing.Point(159, -1)
        Me.LoadingPortale.Name = "LoadingPortale"
        Me.LoadingPortale.Size = New System.Drawing.Size(34, 41)
        Me.LoadingPortale.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingPortale.TabIndex = 125
        Me.LoadingPortale.TabStop = False
        Me.LoadingPortale.Visible = False
        '
        'CheckBoxPortale
        '
        Me.CheckBoxPortale.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxPortale.Checked = True
        Me.CheckBoxPortale.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxPortale.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxPortale.Location = New System.Drawing.Point(6, 6)
        Me.CheckBoxPortale.Name = "CheckBoxPortale"
        Me.CheckBoxPortale.Size = New System.Drawing.Size(184, 83)
        Me.CheckBoxPortale.TabIndex = 14
        Me.CheckBoxPortale.Text = "Test Com.Portale"
        Me.CheckBoxPortale.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxPortale.UseVisualStyleBackColor = True
        '
        'ButtonStartTest
        '
        Me.ButtonStartTest.BackColor = System.Drawing.Color.Transparent
        Me.ButtonStartTest.BackgroundImage = Global.FlashedLOL.My.Resources.Res.ButtonStart
        Me.ButtonStartTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonStartTest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStartTest.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonStartTest.Font = New System.Drawing.Font("Microsoft JhengHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStartTest.Location = New System.Drawing.Point(6, 6)
        Me.ButtonStartTest.Name = "ButtonStartTest"
        Me.ButtonStartTest.Size = New System.Drawing.Size(160, 69)
        Me.ButtonStartTest.TabIndex = 0
        Me.ButtonStartTest.Text = "Start Test"
        Me.ButtonStartTest.UseVisualStyleBackColor = False
        '
        'LabelMongostatus
        '
        Me.LabelMongostatus.AutoSize = True
        Me.LabelMongostatus.Location = New System.Drawing.Point(875, 532)
        Me.LabelMongostatus.Name = "LabelMongostatus"
        Me.LabelMongostatus.Size = New System.Drawing.Size(117, 13)
        Me.LabelMongostatus.TabIndex = 97
        Me.LabelMongostatus.Text = "Invio Dati Su Database"
        '
        'ProgressBarTest
        '
        Me.ProgressBarTest.Location = New System.Drawing.Point(5, 91)
        Me.ProgressBarTest.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBarTest.Name = "ProgressBarTest"
        Me.ProgressBarTest.Size = New System.Drawing.Size(821, 11)
        Me.ProgressBarTest.TabIndex = 122
        '
        'ButtonMongoCollaudo
        '
        Me.ButtonMongoCollaudo.BackColor = System.Drawing.Color.Aqua
        Me.ButtonMongoCollaudo.BackgroundImage = Global.FlashedLOL.My.Resources.Res.cloud_down
        Me.ButtonMongoCollaudo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonMongoCollaudo.FlatAppearance.BorderColor = System.Drawing.Color.Cyan
        Me.ButtonMongoCollaudo.FlatAppearance.BorderSize = 10
        Me.ButtonMongoCollaudo.Location = New System.Drawing.Point(900, 493)
        Me.ButtonMongoCollaudo.Name = "ButtonMongoCollaudo"
        Me.ButtonMongoCollaudo.Size = New System.Drawing.Size(64, 38)
        Me.ButtonMongoCollaudo.TabIndex = 96
        Me.ButtonMongoCollaudo.UseVisualStyleBackColor = False
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(852, 558)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(180, 13)
        Me.Label54.TabIndex = 100
        Me.Label54.Text = "For any problem or bug conctact me "
        '
        'CollaudoScheda
        '
        Me.CollaudoScheda.AutoSize = True
        Me.CollaudoScheda.Checked = True
        Me.CollaudoScheda.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CollaudoScheda.Location = New System.Drawing.Point(59, 74)
        Me.CollaudoScheda.Name = "CollaudoScheda"
        Me.CollaudoScheda.Size = New System.Drawing.Size(107, 17)
        Me.CollaudoScheda.TabIndex = 92
        Me.CollaudoScheda.Text = "Collaudo Scheda"
        Me.CollaudoScheda.UseVisualStyleBackColor = True
        '
        'PanelCAN
        '
        Me.PanelCAN.BackColor = System.Drawing.Color.White
        Me.PanelCAN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelCAN.Controls.Add(Me.InfoCAN)
        Me.PanelCAN.Controls.Add(Me.CAN2_NOT)
        Me.PanelCAN.Controls.Add(Me.CAN1_NOT)
        Me.PanelCAN.Controls.Add(Me.ErrorTestCAN)
        Me.PanelCAN.Controls.Add(Me.Label49)
        Me.PanelCAN.Controls.Add(Me.Label42)
        Me.PanelCAN.Controls.Add(Me.CAN2_OK)
        Me.PanelCAN.Controls.Add(Me.CAN1_OK)
        Me.PanelCAN.Controls.Add(Me.TestCANMessage)
        Me.PanelCAN.Controls.Add(Me.TestCANStatus)
        Me.PanelCAN.Controls.Add(Me.Label47)
        Me.PanelCAN.Controls.Add(Me.LoadingCAN)
        Me.PanelCAN.Controls.Add(Me.CheckBoxCAN)
        Me.PanelCAN.Location = New System.Drawing.Point(5, 208)
        Me.PanelCAN.Name = "PanelCAN"
        Me.PanelCAN.Size = New System.Drawing.Size(195, 96)
        Me.PanelCAN.TabIndex = 91
        '
        'InfoCAN
        '
        Me.InfoCAN.BackColor = System.Drawing.Color.Transparent
        Me.InfoCAN.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoCAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoCAN.Location = New System.Drawing.Point(81, -2)
        Me.InfoCAN.Name = "InfoCAN"
        Me.InfoCAN.Size = New System.Drawing.Size(20, 24)
        Me.InfoCAN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoCAN.TabIndex = 149
        Me.InfoCAN.TabStop = False
        '
        'CAN2_NOT
        '
        Me.CAN2_NOT.BackColor = System.Drawing.Color.Transparent
        Me.CAN2_NOT.BackgroundImage = Global.FlashedLOL.My.Resources.Res._Error
        Me.CAN2_NOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CAN2_NOT.Location = New System.Drawing.Point(48, 44)
        Me.CAN2_NOT.Name = "CAN2_NOT"
        Me.CAN2_NOT.Size = New System.Drawing.Size(17, 15)
        Me.CAN2_NOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CAN2_NOT.TabIndex = 121
        Me.CAN2_NOT.TabStop = False
        Me.CAN2_NOT.Visible = False
        '
        'CAN1_NOT
        '
        Me.CAN1_NOT.BackColor = System.Drawing.Color.Transparent
        Me.CAN1_NOT.BackgroundImage = Global.FlashedLOL.My.Resources.Res._Error
        Me.CAN1_NOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CAN1_NOT.Location = New System.Drawing.Point(48, 24)
        Me.CAN1_NOT.Name = "CAN1_NOT"
        Me.CAN1_NOT.Size = New System.Drawing.Size(17, 15)
        Me.CAN1_NOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.CAN1_NOT.TabIndex = 120
        Me.CAN1_NOT.TabStop = False
        Me.CAN1_NOT.Visible = False
        '
        'ErrorTestCAN
        '
        Me.ErrorTestCAN.BackColor = System.Drawing.Color.Transparent
        Me.ErrorTestCAN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ErrorTestCAN.Image = Global.FlashedLOL.My.Resources.Res.R
        Me.ErrorTestCAN.Location = New System.Drawing.Point(153, 56)
        Me.ErrorTestCAN.Name = "ErrorTestCAN"
        Me.ErrorTestCAN.Size = New System.Drawing.Size(40, 39)
        Me.ErrorTestCAN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ErrorTestCAN.TabIndex = 103
        Me.ErrorTestCAN.TabStop = False
        Me.ErrorTestCAN.Visible = False
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(12, 46)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(40, 15)
        Me.Label49.TabIndex = 96
        Me.Label49.Text = "CAN 2"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(12, 24)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(40, 15)
        Me.Label42.TabIndex = 95
        Me.Label42.Text = "CAN 1"
        '
        'CAN2_OK
        '
        Me.CAN2_OK.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.CAN2_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CAN2_OK.Location = New System.Drawing.Point(64, 45)
        Me.CAN2_OK.Name = "CAN2_OK"
        Me.CAN2_OK.Size = New System.Drawing.Size(14, 13)
        Me.CAN2_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CAN2_OK.TabIndex = 94
        Me.CAN2_OK.TabStop = False
        Me.CAN2_OK.Visible = False
        '
        'CAN1_OK
        '
        Me.CAN1_OK.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.CAN1_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.CAN1_OK.Location = New System.Drawing.Point(64, 24)
        Me.CAN1_OK.Name = "CAN1_OK"
        Me.CAN1_OK.Size = New System.Drawing.Size(14, 13)
        Me.CAN1_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.CAN1_OK.TabIndex = 93
        Me.CAN1_OK.TabStop = False
        Me.CAN1_OK.Visible = False
        '
        'TestCANMessage
        '
        Me.TestCANMessage.AutoSize = True
        Me.TestCANMessage.ForeColor = System.Drawing.Color.Red
        Me.TestCANMessage.Location = New System.Drawing.Point(4, 53)
        Me.TestCANMessage.Name = "TestCANMessage"
        Me.TestCANMessage.Size = New System.Drawing.Size(16, 13)
        Me.TestCANMessage.TabIndex = 90
        Me.TestCANMessage.Text = "..."
        '
        'TestCANStatus
        '
        Me.TestCANStatus.BackColor = System.Drawing.Color.Transparent
        Me.TestCANStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.TestCANStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TestCANStatus.Location = New System.Drawing.Point(157, -2)
        Me.TestCANStatus.Name = "TestCANStatus"
        Me.TestCANStatus.Size = New System.Drawing.Size(36, 35)
        Me.TestCANStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TestCANStatus.TabIndex = 10
        Me.TestCANStatus.TabStop = False
        Me.TestCANStatus.Visible = False
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.ForeColor = System.Drawing.Color.Red
        Me.Label47.Location = New System.Drawing.Point(3, 108)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(16, 13)
        Me.Label47.TabIndex = 9
        Me.Label47.Text = "..."
        '
        'LoadingCAN
        '
        Me.LoadingCAN.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingCAN.Location = New System.Drawing.Point(153, -1)
        Me.LoadingCAN.Name = "LoadingCAN"
        Me.LoadingCAN.Size = New System.Drawing.Size(41, 37)
        Me.LoadingCAN.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingCAN.TabIndex = 104
        Me.LoadingCAN.TabStop = False
        Me.LoadingCAN.Visible = False
        '
        'CheckBoxCAN
        '
        Me.CheckBoxCAN.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxCAN.Checked = True
        Me.CheckBoxCAN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCAN.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxCAN.Location = New System.Drawing.Point(12, 4)
        Me.CheckBoxCAN.Name = "CheckBoxCAN"
        Me.CheckBoxCAN.Size = New System.Drawing.Size(178, 87)
        Me.CheckBoxCAN.TabIndex = 8
        Me.CheckBoxCAN.Text = "Test CAN"
        Me.CheckBoxCAN.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxCAN.UseVisualStyleBackColor = True
        '
        'PanelIngressi
        '
        Me.PanelIngressi.BackColor = System.Drawing.Color.White
        Me.PanelIngressi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelIngressi.Controls.Add(Me.IP2_NOT)
        Me.PanelIngressi.Controls.Add(Me.IP2_0K)
        Me.PanelIngressi.Controls.Add(Me.Label37)
        Me.PanelIngressi.Controls.Add(Me.InfoIP)
        Me.PanelIngressi.Controls.Add(Me.IP4_NOT)
        Me.PanelIngressi.Controls.Add(Me.IP3_NOT)
        Me.PanelIngressi.Controls.Add(Me.IP1_NOT)
        Me.PanelIngressi.Controls.Add(Me.ErrorTestIP)
        Me.PanelIngressi.Controls.Add(Me.AnalogicIP4)
        Me.PanelIngressi.Controls.Add(Me.Label45)
        Me.PanelIngressi.Controls.Add(Me.IP4_OK)
        Me.PanelIngressi.Controls.Add(Me.Label46)
        Me.PanelIngressi.Controls.Add(Me.TestIngressiMessage)
        Me.PanelIngressi.Controls.Add(Me.IP3_OK)
        Me.PanelIngressi.Controls.Add(Me.IP3)
        Me.PanelIngressi.Controls.Add(Me.testIngressiStatus)
        Me.PanelIngressi.Controls.Add(Me.Label36)
        Me.PanelIngressi.Controls.Add(Me.IP1_OK)
        Me.PanelIngressi.Controls.Add(Me.Label40)
        Me.PanelIngressi.Controls.Add(Me.Label41)
        Me.PanelIngressi.Controls.Add(Me.LoadingIP)
        Me.PanelIngressi.Controls.Add(Me.CheckBoxIngressi)
        Me.PanelIngressi.Location = New System.Drawing.Point(631, 105)
        Me.PanelIngressi.Name = "PanelIngressi"
        Me.PanelIngressi.Size = New System.Drawing.Size(195, 99)
        Me.PanelIngressi.TabIndex = 84
        '
        'IP2_NOT
        '
        Me.IP2_NOT.BackColor = System.Drawing.Color.Transparent
        Me.IP2_NOT.BackgroundImage = Global.FlashedLOL.My.Resources.Res._Error
        Me.IP2_NOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IP2_NOT.Location = New System.Drawing.Point(102, 22)
        Me.IP2_NOT.Name = "IP2_NOT"
        Me.IP2_NOT.Size = New System.Drawing.Size(17, 15)
        Me.IP2_NOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.IP2_NOT.TabIndex = 121
        Me.IP2_NOT.TabStop = False
        Me.IP2_NOT.Visible = False
        '
        'IP2_0K
        '
        Me.IP2_0K.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.IP2_0K.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IP2_0K.Location = New System.Drawing.Point(119, 22)
        Me.IP2_0K.Name = "IP2_0K"
        Me.IP2_0K.Size = New System.Drawing.Size(14, 13)
        Me.IP2_0K.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IP2_0K.TabIndex = 6
        Me.IP2_0K.TabStop = False
        Me.IP2_0K.Visible = False
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(84, 22)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(23, 15)
        Me.Label37.TabIndex = 3
        Me.Label37.Text = "IP2"
        '
        'InfoIP
        '
        Me.InfoIP.BackColor = System.Drawing.Color.Transparent
        Me.InfoIP.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoIP.Location = New System.Drawing.Point(93, 1)
        Me.InfoIP.Name = "InfoIP"
        Me.InfoIP.Size = New System.Drawing.Size(20, 24)
        Me.InfoIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoIP.TabIndex = 150
        Me.InfoIP.TabStop = False
        '
        'IP4_NOT
        '
        Me.IP4_NOT.BackColor = System.Drawing.Color.Transparent
        Me.IP4_NOT.Image = Global.FlashedLOL.My.Resources.Res._Error
        Me.IP4_NOT.Location = New System.Drawing.Point(30, 65)
        Me.IP4_NOT.Name = "IP4_NOT"
        Me.IP4_NOT.Size = New System.Drawing.Size(17, 15)
        Me.IP4_NOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.IP4_NOT.TabIndex = 123
        Me.IP4_NOT.TabStop = False
        Me.IP4_NOT.Visible = False
        '
        'IP3_NOT
        '
        Me.IP3_NOT.BackColor = System.Drawing.Color.Transparent
        Me.IP3_NOT.Image = Global.FlashedLOL.My.Resources.Res._Error
        Me.IP3_NOT.Location = New System.Drawing.Point(72, 40)
        Me.IP3_NOT.Name = "IP3_NOT"
        Me.IP3_NOT.Size = New System.Drawing.Size(17, 15)
        Me.IP3_NOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.IP3_NOT.TabIndex = 122
        Me.IP3_NOT.TabStop = False
        Me.IP3_NOT.Visible = False
        '
        'IP1_NOT
        '
        Me.IP1_NOT.BackColor = System.Drawing.Color.Transparent
        Me.IP1_NOT.BackgroundImage = Global.FlashedLOL.My.Resources.Res._Error
        Me.IP1_NOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IP1_NOT.Location = New System.Drawing.Point(32, 23)
        Me.IP1_NOT.Name = "IP1_NOT"
        Me.IP1_NOT.Size = New System.Drawing.Size(17, 15)
        Me.IP1_NOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.IP1_NOT.TabIndex = 120
        Me.IP1_NOT.TabStop = False
        Me.IP1_NOT.Visible = False
        '
        'ErrorTestIP
        '
        Me.ErrorTestIP.BackColor = System.Drawing.Color.Transparent
        Me.ErrorTestIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ErrorTestIP.Image = Global.FlashedLOL.My.Resources.Res.R
        Me.ErrorTestIP.Location = New System.Drawing.Point(152, 60)
        Me.ErrorTestIP.Name = "ErrorTestIP"
        Me.ErrorTestIP.Size = New System.Drawing.Size(42, 37)
        Me.ErrorTestIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ErrorTestIP.TabIndex = 103
        Me.ErrorTestIP.TabStop = False
        Me.ErrorTestIP.Visible = False
        '
        'AnalogicIP4
        '
        Me.AnalogicIP4.AutoSize = True
        Me.AnalogicIP4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.AnalogicIP4.Location = New System.Drawing.Point(72, 64)
        Me.AnalogicIP4.MinimumSize = New System.Drawing.Size(45, 15)
        Me.AnalogicIP4.Name = "AnalogicIP4"
        Me.AnalogicIP4.Size = New System.Drawing.Size(45, 15)
        Me.AnalogicIP4.TabIndex = 91
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(118, 64)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(25, 13)
        Me.Label45.TabIndex = 94
        Me.Label45.Text = "Volt"
        '
        'IP4_OK
        '
        Me.IP4_OK.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.IP4_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IP4_OK.Location = New System.Drawing.Point(47, 65)
        Me.IP4_OK.Name = "IP4_OK"
        Me.IP4_OK.Size = New System.Drawing.Size(14, 13)
        Me.IP4_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IP4_OK.TabIndex = 93
        Me.IP4_OK.TabStop = False
        Me.IP4_OK.Visible = False
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(12, 65)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(23, 15)
        Me.Label46.TabIndex = 92
        Me.Label46.Text = "IP4"
        '
        'TestIngressiMessage
        '
        Me.TestIngressiMessage.AutoSize = True
        Me.TestIngressiMessage.ForeColor = System.Drawing.Color.Red
        Me.TestIngressiMessage.Location = New System.Drawing.Point(7, 84)
        Me.TestIngressiMessage.Name = "TestIngressiMessage"
        Me.TestIngressiMessage.Size = New System.Drawing.Size(16, 13)
        Me.TestIngressiMessage.TabIndex = 90
        Me.TestIngressiMessage.Text = "..."
        '
        'IP3_OK
        '
        Me.IP3_OK.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.IP3_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IP3_OK.Location = New System.Drawing.Point(89, 40)
        Me.IP3_OK.Name = "IP3_OK"
        Me.IP3_OK.Size = New System.Drawing.Size(14, 13)
        Me.IP3_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IP3_OK.TabIndex = 85
        Me.IP3_OK.TabStop = False
        Me.IP3_OK.Visible = False
        '
        'IP3
        '
        Me.IP3.AutoSize = True
        Me.IP3.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.IP3.Location = New System.Drawing.Point(54, 40)
        Me.IP3.Name = "IP3"
        Me.IP3.Size = New System.Drawing.Size(23, 15)
        Me.IP3.TabIndex = 85
        Me.IP3.Text = "IP3"
        '
        'testIngressiStatus
        '
        Me.testIngressiStatus.BackColor = System.Drawing.Color.Transparent
        Me.testIngressiStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.testIngressiStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.testIngressiStatus.Location = New System.Drawing.Point(158, -1)
        Me.testIngressiStatus.Name = "testIngressiStatus"
        Me.testIngressiStatus.Size = New System.Drawing.Size(36, 37)
        Me.testIngressiStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testIngressiStatus.TabIndex = 10
        Me.testIngressiStatus.TabStop = False
        Me.testIngressiStatus.Visible = False
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(3, 108)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(16, 13)
        Me.Label36.TabIndex = 9
        Me.Label36.Text = "..."
        '
        'IP1_OK
        '
        Me.IP1_OK.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.IP1_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.IP1_OK.Location = New System.Drawing.Point(49, 23)
        Me.IP1_OK.Name = "IP1_OK"
        Me.IP1_OK.Size = New System.Drawing.Size(14, 13)
        Me.IP1_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.IP1_OK.TabIndex = 7
        Me.IP1_OK.TabStop = False
        Me.IP1_OK.Visible = False
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(14, 21)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(23, 15)
        Me.Label40.TabIndex = 2
        Me.Label40.Text = "IP1"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(38, 2)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(0, 15)
        Me.Label41.TabIndex = 1
        '
        'LoadingIP
        '
        Me.LoadingIP.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingIP.Location = New System.Drawing.Point(158, -2)
        Me.LoadingIP.Name = "LoadingIP"
        Me.LoadingIP.Size = New System.Drawing.Size(36, 39)
        Me.LoadingIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingIP.TabIndex = 103
        Me.LoadingIP.TabStop = False
        Me.LoadingIP.Visible = False
        '
        'CheckBoxIngressi
        '
        Me.CheckBoxIngressi.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxIngressi.Checked = True
        Me.CheckBoxIngressi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxIngressi.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxIngressi.Location = New System.Drawing.Point(12, 4)
        Me.CheckBoxIngressi.Name = "CheckBoxIngressi"
        Me.CheckBoxIngressi.Size = New System.Drawing.Size(172, 89)
        Me.CheckBoxIngressi.TabIndex = 8
        Me.CheckBoxIngressi.Text = "Test Ingressi"
        Me.CheckBoxIngressi.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxIngressi.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(875, 571)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(127, 13)
        Me.LinkLabel1.TabIndex = 99
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "https://chat.google.com/"
        '
        'CheckBoxSelezionaTutti
        '
        Me.CheckBoxSelezionaTutti.AutoSize = True
        Me.CheckBoxSelezionaTutti.Checked = True
        Me.CheckBoxSelezionaTutti.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSelezionaTutti.Location = New System.Drawing.Point(8, 74)
        Me.CheckBoxSelezionaTutti.Name = "CheckBoxSelezionaTutti"
        Me.CheckBoxSelezionaTutti.Size = New System.Drawing.Size(47, 17)
        Me.CheckBoxSelezionaTutti.TabIndex = 75
        Me.CheckBoxSelezionaTutti.Text = "Tutti"
        Me.CheckBoxSelezionaTutti.UseVisualStyleBackColor = True
        '
        'Panel5V
        '
        Me.Panel5V.BackColor = System.Drawing.Color.White
        Me.Panel5V.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5V.Controls.Add(Me.Info5V)
        Me.Panel5V.Controls.Add(Me.V5_NOT)
        Me.Panel5V.Controls.Add(Me.ErrorTest5V)
        Me.Panel5V.Controls.Add(Me.Label44)
        Me.Panel5V.Controls.Add(Me.Label51)
        Me.Panel5V.Controls.Add(Me.V5_OK)
        Me.Panel5V.Controls.Add(Me.Valore5V)
        Me.Panel5V.Controls.Add(Me.Test5VMessage)
        Me.Panel5V.Controls.Add(Me.test5Vstatus)
        Me.Panel5V.Controls.Add(Me.Label35)
        Me.Panel5V.Controls.Add(Me.Loading5V)
        Me.Panel5V.Controls.Add(Me.CheckBox5V)
        Me.Panel5V.Location = New System.Drawing.Point(213, 106)
        Me.Panel5V.Name = "Panel5V"
        Me.Panel5V.Size = New System.Drawing.Size(195, 99)
        Me.Panel5V.TabIndex = 83
        '
        'Info5V
        '
        Me.Info5V.BackColor = System.Drawing.Color.Transparent
        Me.Info5V.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.Info5V.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Info5V.Location = New System.Drawing.Point(66, 0)
        Me.Info5V.Name = "Info5V"
        Me.Info5V.Size = New System.Drawing.Size(20, 24)
        Me.Info5V.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Info5V.TabIndex = 149
        Me.Info5V.TabStop = False
        '
        'V5_NOT
        '
        Me.V5_NOT.BackColor = System.Drawing.Color.Transparent
        Me.V5_NOT.BackgroundImage = Global.FlashedLOL.My.Resources.Res._Error
        Me.V5_NOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.V5_NOT.Location = New System.Drawing.Point(56, 42)
        Me.V5_NOT.Name = "V5_NOT"
        Me.V5_NOT.Size = New System.Drawing.Size(17, 15)
        Me.V5_NOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.V5_NOT.TabIndex = 120
        Me.V5_NOT.TabStop = False
        Me.V5_NOT.Visible = False
        '
        'ErrorTest5V
        '
        Me.ErrorTest5V.BackColor = System.Drawing.Color.Transparent
        Me.ErrorTest5V.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ErrorTest5V.Image = Global.FlashedLOL.My.Resources.Res.R
        Me.ErrorTest5V.Location = New System.Drawing.Point(158, 61)
        Me.ErrorTest5V.Name = "ErrorTest5V"
        Me.ErrorTest5V.Size = New System.Drawing.Size(35, 37)
        Me.ErrorTest5V.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ErrorTest5V.TabIndex = 103
        Me.ErrorTest5V.TabStop = False
        Me.ErrorTest5V.Visible = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(150, 43)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(25, 13)
        Me.Label44.TabIndex = 94
        Me.Label44.Text = "Volt"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(24, 41)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(20, 15)
        Me.Label51.TabIndex = 93
        Me.Label51.Text = "5V"
        '
        'V5_OK
        '
        Me.V5_OK.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.V5_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.V5_OK.Location = New System.Drawing.Point(72, 42)
        Me.V5_OK.Name = "V5_OK"
        Me.V5_OK.Size = New System.Drawing.Size(14, 13)
        Me.V5_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.V5_OK.TabIndex = 92
        Me.V5_OK.TabStop = False
        Me.V5_OK.Visible = False
        '
        'Valore5V
        '
        Me.Valore5V.AutoSize = True
        Me.Valore5V.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Valore5V.Location = New System.Drawing.Point(99, 41)
        Me.Valore5V.MinimumSize = New System.Drawing.Size(45, 15)
        Me.Valore5V.Name = "Valore5V"
        Me.Valore5V.Size = New System.Drawing.Size(45, 15)
        Me.Valore5V.TabIndex = 91
        '
        'Test5VMessage
        '
        Me.Test5VMessage.AutoSize = True
        Me.Test5VMessage.ForeColor = System.Drawing.Color.Red
        Me.Test5VMessage.Location = New System.Drawing.Point(4, 63)
        Me.Test5VMessage.Name = "Test5VMessage"
        Me.Test5VMessage.Size = New System.Drawing.Size(16, 13)
        Me.Test5VMessage.TabIndex = 90
        Me.Test5VMessage.Text = "..."
        '
        'test5Vstatus
        '
        Me.test5Vstatus.BackColor = System.Drawing.Color.Transparent
        Me.test5Vstatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.test5Vstatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.test5Vstatus.Location = New System.Drawing.Point(152, -2)
        Me.test5Vstatus.Name = "test5Vstatus"
        Me.test5Vstatus.Size = New System.Drawing.Size(41, 37)
        Me.test5Vstatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.test5Vstatus.TabIndex = 10
        Me.test5Vstatus.TabStop = False
        Me.test5Vstatus.Visible = False
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.ForeColor = System.Drawing.Color.Red
        Me.Label35.Location = New System.Drawing.Point(3, 108)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(16, 13)
        Me.Label35.TabIndex = 9
        Me.Label35.Text = "..."
        '
        'Loading5V
        '
        Me.Loading5V.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.Loading5V.Location = New System.Drawing.Point(152, -2)
        Me.Loading5V.Name = "Loading5V"
        Me.Loading5V.Size = New System.Drawing.Size(41, 39)
        Me.Loading5V.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Loading5V.TabIndex = 103
        Me.Loading5V.TabStop = False
        Me.Loading5V.Visible = False
        '
        'CheckBox5V
        '
        Me.CheckBox5V.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBox5V.Checked = True
        Me.CheckBox5V.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox5V.Location = New System.Drawing.Point(5, 4)
        Me.CheckBox5V.Name = "CheckBox5V"
        Me.CheckBox5V.Size = New System.Drawing.Size(185, 92)
        Me.CheckBox5V.TabIndex = 8
        Me.CheckBox5V.Text = "Test 5V"
        Me.CheckBox5V.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBox5V.UseVisualStyleBackColor = True
        '
        'ButtonStop
        '
        Me.ButtonStop.BackColor = System.Drawing.Color.Transparent
        Me.ButtonStop.BackgroundImage = Global.FlashedLOL.My.Resources.Res.ButtonStop
        Me.ButtonStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStop.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonStop.Font = New System.Drawing.Font("Microsoft JhengHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStop.Location = New System.Drawing.Point(6, 7)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(160, 69)
        Me.ButtonStop.TabIndex = 127
        Me.ButtonStop.Text = "Stop Test"
        Me.ButtonStop.UseVisualStyleBackColor = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(922, 189)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(30, 13)
        Me.Label32.TabIndex = 67
        Me.Label32.Text = "ORA"
        '
        'PanelRelè
        '
        Me.PanelRelè.BackColor = System.Drawing.Color.White
        Me.PanelRelè.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelRelè.Controls.Add(Me.vCurrent2)
        Me.PanelRelè.Controls.Add(Me.vCurrent1)
        Me.PanelRelè.Controls.Add(Me.InfoRL)
        Me.PanelRelè.Controls.Add(Me.TestReleStatus)
        Me.PanelRelè.Controls.Add(Me.ErrorTestRL)
        Me.PanelRelè.Controls.Add(Me.RL2_NOT)
        Me.PanelRelè.Controls.Add(Me.RL1_NOT)
        Me.PanelRelè.Controls.Add(Me.Label57)
        Me.PanelRelè.Controls.Add(Me.Label56)
        Me.PanelRelè.Controls.Add(Me.RL1_OK)
        Me.PanelRelè.Controls.Add(Me.RL2_OK)
        Me.PanelRelè.Controls.Add(Me.LoadingRL)
        Me.PanelRelè.Controls.Add(Me.TestReleMessage)
        Me.PanelRelè.Controls.Add(Me.Label21)
        Me.PanelRelè.Controls.Add(Me.Label26)
        Me.PanelRelè.Controls.Add(Me.Label33)
        Me.PanelRelè.Controls.Add(Me.CheckBoxRele)
        Me.PanelRelè.Location = New System.Drawing.Point(422, 106)
        Me.PanelRelè.Name = "PanelRelè"
        Me.PanelRelè.Size = New System.Drawing.Size(195, 99)
        Me.PanelRelè.TabIndex = 82
        '
        'vCurrent2
        '
        Me.vCurrent2.AutoSize = True
        Me.vCurrent2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.vCurrent2.Location = New System.Drawing.Point(49, 57)
        Me.vCurrent2.MinimumSize = New System.Drawing.Size(45, 15)
        Me.vCurrent2.Name = "vCurrent2"
        Me.vCurrent2.Size = New System.Drawing.Size(45, 15)
        Me.vCurrent2.TabIndex = 152
        '
        'vCurrent1
        '
        Me.vCurrent1.AutoSize = True
        Me.vCurrent1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.vCurrent1.Location = New System.Drawing.Point(49, 25)
        Me.vCurrent1.MinimumSize = New System.Drawing.Size(45, 15)
        Me.vCurrent1.Name = "vCurrent1"
        Me.vCurrent1.Size = New System.Drawing.Size(45, 15)
        Me.vCurrent1.TabIndex = 151
        '
        'InfoRL
        '
        Me.InfoRL.BackColor = System.Drawing.Color.Transparent
        Me.InfoRL.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoRL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoRL.Location = New System.Drawing.Point(79, 0)
        Me.InfoRL.Name = "InfoRL"
        Me.InfoRL.Size = New System.Drawing.Size(20, 24)
        Me.InfoRL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoRL.TabIndex = 149
        Me.InfoRL.TabStop = False
        '
        'TestReleStatus
        '
        Me.TestReleStatus.BackColor = System.Drawing.Color.Transparent
        Me.TestReleStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.TestReleStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TestReleStatus.Location = New System.Drawing.Point(160, -1)
        Me.TestReleStatus.Name = "TestReleStatus"
        Me.TestReleStatus.Size = New System.Drawing.Size(34, 35)
        Me.TestReleStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TestReleStatus.TabIndex = 103
        Me.TestReleStatus.TabStop = False
        Me.TestReleStatus.Visible = False
        '
        'ErrorTestRL
        '
        Me.ErrorTestRL.BackColor = System.Drawing.Color.Transparent
        Me.ErrorTestRL.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ErrorTestRL.Image = Global.FlashedLOL.My.Resources.Res.R
        Me.ErrorTestRL.Location = New System.Drawing.Point(153, 61)
        Me.ErrorTestRL.Name = "ErrorTestRL"
        Me.ErrorTestRL.Size = New System.Drawing.Size(41, 37)
        Me.ErrorTestRL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ErrorTestRL.TabIndex = 103
        Me.ErrorTestRL.TabStop = False
        Me.ErrorTestRL.Visible = False
        '
        'RL2_NOT
        '
        Me.RL2_NOT.BackColor = System.Drawing.Color.Transparent
        Me.RL2_NOT.BackgroundImage = Global.FlashedLOL.My.Resources.Res._Error
        Me.RL2_NOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RL2_NOT.Location = New System.Drawing.Point(120, 52)
        Me.RL2_NOT.Name = "RL2_NOT"
        Me.RL2_NOT.Size = New System.Drawing.Size(17, 15)
        Me.RL2_NOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.RL2_NOT.TabIndex = 119
        Me.RL2_NOT.TabStop = False
        Me.RL2_NOT.Visible = False
        '
        'RL1_NOT
        '
        Me.RL1_NOT.BackColor = System.Drawing.Color.Transparent
        Me.RL1_NOT.BackgroundImage = Global.FlashedLOL.My.Resources.Res._Error
        Me.RL1_NOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RL1_NOT.Location = New System.Drawing.Point(120, 23)
        Me.RL1_NOT.Name = "RL1_NOT"
        Me.RL1_NOT.Size = New System.Drawing.Size(17, 15)
        Me.RL1_NOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.RL1_NOT.TabIndex = 118
        Me.RL1_NOT.TabStop = False
        Me.RL1_NOT.Visible = False
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(92, 55)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(16, 13)
        Me.Label57.TabIndex = 94
        Me.Label57.Text = "..."
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(92, 24)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(16, 13)
        Me.Label56.TabIndex = 93
        Me.Label56.Text = "..."
        '
        'RL1_OK
        '
        Me.RL1_OK.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.RL1_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RL1_OK.Location = New System.Drawing.Point(136, 23)
        Me.RL1_OK.Name = "RL1_OK"
        Me.RL1_OK.Size = New System.Drawing.Size(14, 13)
        Me.RL1_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RL1_OK.TabIndex = 7
        Me.RL1_OK.TabStop = False
        Me.RL1_OK.Visible = False
        '
        'RL2_OK
        '
        Me.RL2_OK.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.RL2_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.RL2_OK.Location = New System.Drawing.Point(136, 52)
        Me.RL2_OK.Name = "RL2_OK"
        Me.RL2_OK.Size = New System.Drawing.Size(14, 15)
        Me.RL2_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.RL2_OK.TabIndex = 6
        Me.RL2_OK.TabStop = False
        Me.RL2_OK.Visible = False
        '
        'LoadingRL
        '
        Me.LoadingRL.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingRL.Location = New System.Drawing.Point(159, -3)
        Me.LoadingRL.Name = "LoadingRL"
        Me.LoadingRL.Size = New System.Drawing.Size(35, 38)
        Me.LoadingRL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingRL.TabIndex = 104
        Me.LoadingRL.TabStop = False
        Me.LoadingRL.Visible = False
        '
        'TestReleMessage
        '
        Me.TestReleMessage.AutoSize = True
        Me.TestReleMessage.ForeColor = System.Drawing.Color.Red
        Me.TestReleMessage.Location = New System.Drawing.Point(3, 76)
        Me.TestReleMessage.Name = "TestReleMessage"
        Me.TestReleMessage.Size = New System.Drawing.Size(16, 13)
        Me.TestReleMessage.TabIndex = 90
        Me.TestReleMessage.Text = "..."
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.ForeColor = System.Drawing.Color.Red
        Me.Label21.Location = New System.Drawing.Point(3, 108)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(16, 13)
        Me.Label21.TabIndex = 9
        Me.Label21.Text = "..."
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(14, 57)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(38, 15)
        Me.Label26.TabIndex = 3
        Me.Label26.Text = "Relè 2"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(14, 24)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(38, 15)
        Me.Label33.TabIndex = 2
        Me.Label33.Text = "Relè 1"
        '
        'CheckBoxRele
        '
        Me.CheckBoxRele.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxRele.Checked = True
        Me.CheckBoxRele.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxRele.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxRele.Location = New System.Drawing.Point(12, 4)
        Me.CheckBoxRele.Name = "CheckBoxRele"
        Me.CheckBoxRele.Size = New System.Drawing.Size(178, 90)
        Me.CheckBoxRele.TabIndex = 8
        Me.CheckBoxRele.Text = "Test Rele"
        Me.CheckBoxRele.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxRele.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(919, 250)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(36, 13)
        Me.Label31.TabIndex = 66
        Me.Label31.Text = "DATA"
        '
        'PanelAlimentazione
        '
        Me.PanelAlimentazione.BackColor = System.Drawing.Color.White
        Me.PanelAlimentazione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelAlimentazione.Controls.Add(Me.TensioneEsterna)
        Me.PanelAlimentazione.Controls.Add(Me.Label2)
        Me.PanelAlimentazione.Controls.Add(Me.InfoPWR)
        Me.PanelAlimentazione.Controls.Add(Me.PWR_NOT)
        Me.PanelAlimentazione.Controls.Add(Me.PWR_OK)
        Me.PanelAlimentazione.Controls.Add(Me.Label23)
        Me.PanelAlimentazione.Controls.Add(Me.ErrorTestPWR)
        Me.PanelAlimentazione.Controls.Add(Me.TestAlimentazioneStatus)
        Me.PanelAlimentazione.Controls.Add(Me.LoadingPWR)
        Me.PanelAlimentazione.Controls.Add(Me.Label25)
        Me.PanelAlimentazione.Controls.Add(Me.testAlimentazioneMessage)
        Me.PanelAlimentazione.Controls.Add(Me.Label22)
        Me.PanelAlimentazione.Controls.Add(Me.CheckBoxAlimentazione)
        Me.PanelAlimentazione.Location = New System.Drawing.Point(5, 107)
        Me.PanelAlimentazione.Name = "PanelAlimentazione"
        Me.PanelAlimentazione.Size = New System.Drawing.Size(195, 96)
        Me.PanelAlimentazione.TabIndex = 81
        '
        'TensioneEsterna
        '
        Me.TensioneEsterna.AutoSize = True
        Me.TensioneEsterna.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.TensioneEsterna.Location = New System.Drawing.Point(91, 37)
        Me.TensioneEsterna.MinimumSize = New System.Drawing.Size(45, 15)
        Me.TensioneEsterna.Name = "TensioneEsterna"
        Me.TensioneEsterna.Size = New System.Drawing.Size(45, 15)
        Me.TensioneEsterna.TabIndex = 150
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 149
        Me.Label2.Text = "Tensione Esterna "
        '
        'InfoPWR
        '
        Me.InfoPWR.BackColor = System.Drawing.Color.Transparent
        Me.InfoPWR.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoPWR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoPWR.Location = New System.Drawing.Point(116, 0)
        Me.InfoPWR.Name = "InfoPWR"
        Me.InfoPWR.Size = New System.Drawing.Size(20, 24)
        Me.InfoPWR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoPWR.TabIndex = 148
        Me.InfoPWR.TabStop = False
        '
        'PWR_NOT
        '
        Me.PWR_NOT.BackColor = System.Drawing.Color.Transparent
        Me.PWR_NOT.Image = Global.FlashedLOL.My.Resources.Res._Error
        Me.PWR_NOT.Location = New System.Drawing.Point(83, 58)
        Me.PWR_NOT.Name = "PWR_NOT"
        Me.PWR_NOT.Size = New System.Drawing.Size(17, 15)
        Me.PWR_NOT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PWR_NOT.TabIndex = 120
        Me.PWR_NOT.TabStop = False
        Me.PWR_NOT.Visible = False
        '
        'PWR_OK
        '
        Me.PWR_OK.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.PWR_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PWR_OK.Location = New System.Drawing.Point(99, 58)
        Me.PWR_OK.Name = "PWR_OK"
        Me.PWR_OK.Size = New System.Drawing.Size(14, 13)
        Me.PWR_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PWR_OK.TabIndex = 90
        Me.PWR_OK.TabStop = False
        Me.PWR_OK.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Location = New System.Drawing.Point(113, 57)
        Me.Label23.MinimumSize = New System.Drawing.Size(45, 15)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(45, 15)
        Me.Label23.TabIndex = 10
        '
        'ErrorTestPWR
        '
        Me.ErrorTestPWR.BackColor = System.Drawing.Color.Transparent
        Me.ErrorTestPWR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ErrorTestPWR.Image = Global.FlashedLOL.My.Resources.Res.R
        Me.ErrorTestPWR.Location = New System.Drawing.Point(157, 58)
        Me.ErrorTestPWR.Name = "ErrorTestPWR"
        Me.ErrorTestPWR.Size = New System.Drawing.Size(37, 37)
        Me.ErrorTestPWR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ErrorTestPWR.TabIndex = 103
        Me.ErrorTestPWR.TabStop = False
        Me.ErrorTestPWR.Visible = False
        '
        'TestAlimentazioneStatus
        '
        Me.TestAlimentazioneStatus.BackColor = System.Drawing.Color.Transparent
        Me.TestAlimentazioneStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.TestAlimentazioneStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TestAlimentazioneStatus.Location = New System.Drawing.Point(159, -2)
        Me.TestAlimentazioneStatus.Name = "TestAlimentazioneStatus"
        Me.TestAlimentazioneStatus.Size = New System.Drawing.Size(34, 35)
        Me.TestAlimentazioneStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.TestAlimentazioneStatus.TabIndex = 11
        Me.TestAlimentazioneStatus.TabStop = False
        Me.TestAlimentazioneStatus.Visible = False
        '
        'LoadingPWR
        '
        Me.LoadingPWR.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingPWR.Location = New System.Drawing.Point(157, -1)
        Me.LoadingPWR.Name = "LoadingPWR"
        Me.LoadingPWR.Size = New System.Drawing.Size(36, 36)
        Me.LoadingPWR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingPWR.TabIndex = 103
        Me.LoadingPWR.TabStop = False
        Me.LoadingPWR.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(3, 58)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(89, 13)
        Me.Label25.TabIndex = 3
        Me.Label25.Text = "Corrente Esterna "
        '
        'testAlimentazioneMessage
        '
        Me.testAlimentazioneMessage.AutoSize = True
        Me.testAlimentazioneMessage.ForeColor = System.Drawing.Color.Red
        Me.testAlimentazioneMessage.Location = New System.Drawing.Point(3, 63)
        Me.testAlimentazioneMessage.Name = "testAlimentazioneMessage"
        Me.testAlimentazioneMessage.Size = New System.Drawing.Size(16, 13)
        Me.testAlimentazioneMessage.TabIndex = 12
        Me.testAlimentazioneMessage.Text = "..."
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.ForeColor = System.Drawing.Color.Red
        Me.Label22.Location = New System.Drawing.Point(3, 108)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(16, 13)
        Me.Label22.TabIndex = 11
        Me.Label22.Text = "..."
        '
        'CheckBoxAlimentazione
        '
        Me.CheckBoxAlimentazione.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxAlimentazione.Checked = True
        Me.CheckBoxAlimentazione.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAlimentazione.Cursor = System.Windows.Forms.Cursors.AppStarting
        Me.CheckBoxAlimentazione.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxAlimentazione.Location = New System.Drawing.Point(7, 5)
        Me.CheckBoxAlimentazione.Name = "CheckBoxAlimentazione"
        Me.CheckBoxAlimentazione.Size = New System.Drawing.Size(183, 86)
        Me.CheckBoxAlimentazione.TabIndex = 11
        Me.CheckBoxAlimentazione.Text = "Test Alimentazione"
        Me.CheckBoxAlimentazione.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxAlimentazione.UseVisualStyleBackColor = True
        '
        'LabelORA
        '
        Me.LabelORA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelORA.Location = New System.Drawing.Point(867, 207)
        Me.LabelORA.MinimumSize = New System.Drawing.Size(120, 15)
        Me.LabelORA.Name = "LabelORA"
        Me.LabelORA.Size = New System.Drawing.Size(140, 20)
        Me.LabelORA.TabIndex = 64
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.testETS_ETSDNStatus)
        Me.Panel2.Controls.Add(Me.CheckBoxETSDN)
        Me.Panel2.Controls.Add(Me.Label20)
        Me.Panel2.Controls.Add(Me.CheckBoxOverrideETSDN)
        Me.Panel2.Controls.Add(Me.LabelRespFromAssocETSDN)
        Me.Panel2.Controls.Add(Me.labelOverride)
        Me.Panel2.Controls.Add(Me.TextBoxSerialeETSDN)
        Me.Panel2.Controls.Add(Me.ButtonAssocETSDN)
        Me.Panel2.Controls.Add(Me.LabelSerialeETSDN)
        Me.Panel2.Location = New System.Drawing.Point(5, 419)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(192, 146)
        Me.Panel2.TabIndex = 80
        '
        'testETS_ETSDNStatus
        '
        Me.testETS_ETSDNStatus.BackColor = System.Drawing.Color.Gray
        Me.testETS_ETSDNStatus.Location = New System.Drawing.Point(170, -1)
        Me.testETS_ETSDNStatus.Name = "testETS_ETSDNStatus"
        Me.testETS_ETSDNStatus.Size = New System.Drawing.Size(24, 24)
        Me.testETS_ETSDNStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testETS_ETSDNStatus.TabIndex = 82
        Me.testETS_ETSDNStatus.TabStop = False
        '
        'CheckBoxETSDN
        '
        Me.CheckBoxETSDN.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxETSDN.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxETSDN.Location = New System.Drawing.Point(6, 5)
        Me.CheckBoxETSDN.Name = "CheckBoxETSDN"
        Me.CheckBoxETSDN.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxETSDN.TabIndex = 81
        Me.CheckBoxETSDN.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(7, 55)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 15)
        Me.Label20.TabIndex = 80
        Me.Label20.Text = "Sn. ETSDN"
        '
        'CheckBoxOverrideETSDN
        '
        Me.CheckBoxOverrideETSDN.AutoSize = True
        Me.CheckBoxOverrideETSDN.Location = New System.Drawing.Point(158, 33)
        Me.CheckBoxOverrideETSDN.Name = "CheckBoxOverrideETSDN"
        Me.CheckBoxOverrideETSDN.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxOverrideETSDN.TabIndex = 79
        Me.CheckBoxOverrideETSDN.UseVisualStyleBackColor = True
        '
        'LabelRespFromAssocETSDN
        '
        Me.LabelRespFromAssocETSDN.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRespFromAssocETSDN.Location = New System.Drawing.Point(7, 124)
        Me.LabelRespFromAssocETSDN.Name = "LabelRespFromAssocETSDN"
        Me.LabelRespFromAssocETSDN.Size = New System.Drawing.Size(20, 21)
        Me.LabelRespFromAssocETSDN.TabIndex = 79
        Me.LabelRespFromAssocETSDN.Text = "..."
        '
        'labelOverride
        '
        Me.labelOverride.AutoSize = True
        Me.labelOverride.Font = New System.Drawing.Font("Microsoft JhengHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelOverride.Location = New System.Drawing.Point(7, 33)
        Me.labelOverride.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.labelOverride.Name = "labelOverride"
        Me.labelOverride.Size = New System.Drawing.Size(129, 14)
        Me.labelOverride.TabIndex = 78
        Me.labelOverride.Text = "Sovrascrivi Assoc. in DB"
        '
        'TextBoxSerialeETSDN
        '
        Me.TextBoxSerialeETSDN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxSerialeETSDN.Location = New System.Drawing.Point(85, 52)
        Me.TextBoxSerialeETSDN.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBoxSerialeETSDN.Name = "TextBoxSerialeETSDN"
        Me.TextBoxSerialeETSDN.Size = New System.Drawing.Size(88, 20)
        Me.TextBoxSerialeETSDN.TabIndex = 76
        '
        'ButtonAssocETSDN
        '
        Me.ButtonAssocETSDN.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonAssocETSDN.Font = New System.Drawing.Font("Microsoft JhengHei UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ButtonAssocETSDN.Location = New System.Drawing.Point(6, 73)
        Me.ButtonAssocETSDN.Name = "ButtonAssocETSDN"
        Me.ButtonAssocETSDN.Size = New System.Drawing.Size(79, 28)
        Me.ButtonAssocETSDN.TabIndex = 78
        Me.ButtonAssocETSDN.Text = "ASSOCIA"
        Me.ButtonAssocETSDN.UseVisualStyleBackColor = False
        '
        'LabelSerialeETSDN
        '
        Me.LabelSerialeETSDN.AutoSize = True
        Me.LabelSerialeETSDN.Font = New System.Drawing.Font("Microsoft JhengHei UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSerialeETSDN.Location = New System.Drawing.Point(26, 5)
        Me.LabelSerialeETSDN.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelSerialeETSDN.Name = "LabelSerialeETSDN"
        Me.LabelSerialeETSDN.Size = New System.Drawing.Size(79, 14)
        Me.LabelSerialeETSDN.TabIndex = 77
        Me.LabelSerialeETSDN.Text = "Seriale ETSDN"
        '
        'LabelDATA
        '
        Me.LabelDATA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelDATA.Location = New System.Drawing.Point(867, 268)
        Me.LabelDATA.MinimumSize = New System.Drawing.Size(120, 15)
        Me.LabelDATA.Name = "LabelDATA"
        Me.LabelDATA.Size = New System.Drawing.Size(140, 20)
        Me.LabelDATA.TabIndex = 63
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.testUtenzaMessage)
        Me.Panel1.Controls.Add(Me.testUtenzaStatus)
        Me.Panel1.Controls.Add(Me.CheckBoxUtenza)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Location = New System.Drawing.Point(213, 419)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(195, 146)
        Me.Panel1.TabIndex = 23
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Inserire il PIN 75319"
        '
        'testUtenzaMessage
        '
        Me.testUtenzaMessage.AutoSize = True
        Me.testUtenzaMessage.ForeColor = System.Drawing.Color.Red
        Me.testUtenzaMessage.Location = New System.Drawing.Point(3, 129)
        Me.testUtenzaMessage.Name = "testUtenzaMessage"
        Me.testUtenzaMessage.Size = New System.Drawing.Size(16, 13)
        Me.testUtenzaMessage.TabIndex = 22
        Me.testUtenzaMessage.Text = "..."
        '
        'testUtenzaStatus
        '
        Me.testUtenzaStatus.BackColor = System.Drawing.Color.Gray
        Me.testUtenzaStatus.Location = New System.Drawing.Point(173, -1)
        Me.testUtenzaStatus.Name = "testUtenzaStatus"
        Me.testUtenzaStatus.Size = New System.Drawing.Size(24, 24)
        Me.testUtenzaStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testUtenzaStatus.TabIndex = 22
        Me.testUtenzaStatus.TabStop = False
        '
        'CheckBoxUtenza
        '
        Me.CheckBoxUtenza.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxUtenza.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxUtenza.Location = New System.Drawing.Point(10, 4)
        Me.CheckBoxUtenza.Name = "CheckBoxUtenza"
        Me.CheckBoxUtenza.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxUtenza.TabIndex = 18
        Me.CheckBoxUtenza.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(53, 4)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(76, 15)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Check utenza"
        '
        'Label38
        '
        Me.Label38.Font = New System.Drawing.Font("Microsoft JhengHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.Firebrick
        Me.Label38.Location = New System.Drawing.Point(921, 297)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(34, 16)
        Me.Label38.TabIndex = 14
        Me.Label38.Text = "S/N"
        '
        'labelSerialNumber
        '
        Me.labelSerialNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelSerialNumber.Location = New System.Drawing.Point(844, 319)
        Me.labelSerialNumber.MinimumSize = New System.Drawing.Size(150, 20)
        Me.labelSerialNumber.Name = "labelSerialNumber"
        Me.labelSerialNumber.Size = New System.Drawing.Size(188, 23)
        Me.labelSerialNumber.TabIndex = 13
        '
        'LabelCom
        '
        Me.LabelCom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelCom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelCom.Location = New System.Drawing.Point(844, 440)
        Me.LabelCom.MinimumSize = New System.Drawing.Size(150, 20)
        Me.LabelCom.Name = "LabelCom"
        Me.LabelCom.Size = New System.Drawing.Size(188, 24)
        Me.LabelCom.TabIndex = 28
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft JhengHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.Firebrick
        Me.Label30.Location = New System.Drawing.Point(910, 420)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(58, 20)
        Me.Label30.TabIndex = 27
        Me.Label30.Text = "P. COM"
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft JhengHei", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Firebrick
        Me.Label28.Location = New System.Drawing.Point(910, 359)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(54, 15)
        Me.Label28.TabIndex = 17
        Me.Label28.Text = "Portale"
        '
        'PanelSync
        '
        Me.PanelSync.BackColor = System.Drawing.Color.White
        Me.PanelSync.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSync.Controls.Add(Me.InfoMemory)
        Me.PanelSync.Controls.Add(Me.Label19)
        Me.PanelSync.Controls.Add(Me.Label17)
        Me.PanelSync.Controls.Add(Me.Label18)
        Me.PanelSync.Controls.Add(Me.Label15)
        Me.PanelSync.Controls.Add(Me.Label16)
        Me.PanelSync.Controls.Add(Me.testMemsyncMessage)
        Me.PanelSync.Controls.Add(Me.testMemsyncExportPercentage)
        Me.PanelSync.Controls.Add(Me.testMemsyncStatus)
        Me.PanelSync.Controls.Add(Me.PictureBox1ImpotaMemoria)
        Me.PanelSync.Controls.Add(Me.PictureBox1EsportaMemoria)
        Me.PanelSync.Controls.Add(Me.PictureBox1Sync)
        Me.PanelSync.Controls.Add(Me.PictureBox2L03Peso)
        Me.PanelSync.Controls.Add(Me.PictureBox1formattazione)
        Me.PanelSync.Controls.Add(Me.LoadingSync)
        Me.PanelSync.Controls.Add(Me.CheckBoxMemoria)
        Me.PanelSync.Location = New System.Drawing.Point(631, 307)
        Me.PanelSync.Name = "PanelSync"
        Me.PanelSync.Size = New System.Drawing.Size(195, 118)
        Me.PanelSync.TabIndex = 2
        '
        'InfoMemory
        '
        Me.InfoMemory.BackColor = System.Drawing.Color.Transparent
        Me.InfoMemory.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoMemory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoMemory.Location = New System.Drawing.Point(119, 2)
        Me.InfoMemory.Name = "InfoMemory"
        Me.InfoMemory.Size = New System.Drawing.Size(20, 24)
        Me.InfoMemory.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoMemory.TabIndex = 156
        Me.InfoMemory.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(-1, 80)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 15)
        Me.Label19.TabIndex = 14
        Me.Label19.Text = "Importa su portale"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(-1, 62)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 15)
        Me.Label17.TabIndex = 13
        Me.Label17.Text = "Esporta Memoria"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(-1, 102)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(86, 15)
        Me.Label18.TabIndex = 11
        Me.Label18.Text = "Controllo Sync "
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(-1, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(102, 15)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Formattazione SD "
        Me.Label15.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(-1, 40)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(148, 15)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "Comando L03 peso del file "
        Me.Label16.Visible = False
        '
        'testMemsyncMessage
        '
        Me.testMemsyncMessage.AutoSize = True
        Me.testMemsyncMessage.ForeColor = System.Drawing.Color.Red
        Me.testMemsyncMessage.Location = New System.Drawing.Point(9, 146)
        Me.testMemsyncMessage.Name = "testMemsyncMessage"
        Me.testMemsyncMessage.Size = New System.Drawing.Size(16, 13)
        Me.testMemsyncMessage.TabIndex = 27
        Me.testMemsyncMessage.Text = "..."
        '
        'testMemsyncExportPercentage
        '
        Me.testMemsyncExportPercentage.AutoSize = True
        Me.testMemsyncExportPercentage.Location = New System.Drawing.Point(163, 83)
        Me.testMemsyncExportPercentage.Name = "testMemsyncExportPercentage"
        Me.testMemsyncExportPercentage.Size = New System.Drawing.Size(19, 13)
        Me.testMemsyncExportPercentage.TabIndex = 26
        Me.testMemsyncExportPercentage.Text = "(0)"
        '
        'testMemsyncStatus
        '
        Me.testMemsyncStatus.BackColor = System.Drawing.Color.Transparent
        Me.testMemsyncStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.testMemsyncStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.testMemsyncStatus.Location = New System.Drawing.Point(158, -1)
        Me.testMemsyncStatus.Name = "testMemsyncStatus"
        Me.testMemsyncStatus.Size = New System.Drawing.Size(34, 39)
        Me.testMemsyncStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testMemsyncStatus.TabIndex = 25
        Me.testMemsyncStatus.TabStop = False
        Me.testMemsyncStatus.Visible = False
        '
        'PictureBox1ImpotaMemoria
        '
        Me.PictureBox1ImpotaMemoria.Location = New System.Drawing.Point(147, 83)
        Me.PictureBox1ImpotaMemoria.Name = "PictureBox1ImpotaMemoria"
        Me.PictureBox1ImpotaMemoria.Size = New System.Drawing.Size(14, 13)
        Me.PictureBox1ImpotaMemoria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1ImpotaMemoria.TabIndex = 16
        Me.PictureBox1ImpotaMemoria.TabStop = False
        '
        'PictureBox1EsportaMemoria
        '
        Me.PictureBox1EsportaMemoria.Location = New System.Drawing.Point(147, 62)
        Me.PictureBox1EsportaMemoria.Name = "PictureBox1EsportaMemoria"
        Me.PictureBox1EsportaMemoria.Size = New System.Drawing.Size(14, 13)
        Me.PictureBox1EsportaMemoria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1EsportaMemoria.TabIndex = 15
        Me.PictureBox1EsportaMemoria.TabStop = False
        '
        'PictureBox1Sync
        '
        Me.PictureBox1Sync.Location = New System.Drawing.Point(147, 102)
        Me.PictureBox1Sync.Name = "PictureBox1Sync"
        Me.PictureBox1Sync.Size = New System.Drawing.Size(14, 13)
        Me.PictureBox1Sync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1Sync.TabIndex = 12
        Me.PictureBox1Sync.TabStop = False
        '
        'PictureBox2L03Peso
        '
        Me.PictureBox2L03Peso.Location = New System.Drawing.Point(147, 41)
        Me.PictureBox2L03Peso.Name = "PictureBox2L03Peso"
        Me.PictureBox2L03Peso.Size = New System.Drawing.Size(14, 13)
        Me.PictureBox2L03Peso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2L03Peso.TabIndex = 9
        Me.PictureBox2L03Peso.TabStop = False
        Me.PictureBox2L03Peso.Visible = False
        '
        'PictureBox1formattazione
        '
        Me.PictureBox1formattazione.Location = New System.Drawing.Point(147, 21)
        Me.PictureBox1formattazione.Name = "PictureBox1formattazione"
        Me.PictureBox1formattazione.Size = New System.Drawing.Size(14, 13)
        Me.PictureBox1formattazione.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1formattazione.TabIndex = 8
        Me.PictureBox1formattazione.TabStop = False
        Me.PictureBox1formattazione.Visible = False
        '
        'LoadingSync
        '
        Me.LoadingSync.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingSync.Location = New System.Drawing.Point(158, -1)
        Me.LoadingSync.Name = "LoadingSync"
        Me.LoadingSync.Size = New System.Drawing.Size(36, 41)
        Me.LoadingSync.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingSync.TabIndex = 126
        Me.LoadingSync.TabStop = False
        Me.LoadingSync.Visible = False
        '
        'CheckBoxMemoria
        '
        Me.CheckBoxMemoria.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxMemoria.Checked = True
        Me.CheckBoxMemoria.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxMemoria.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxMemoria.Location = New System.Drawing.Point(7, 5)
        Me.CheckBoxMemoria.Name = "CheckBoxMemoria"
        Me.CheckBoxMemoria.Size = New System.Drawing.Size(183, 108)
        Me.CheckBoxMemoria.TabIndex = 18
        Me.CheckBoxMemoria.Text = "Test Sync Memoria"
        Me.CheckBoxMemoria.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxMemoria.UseVisualStyleBackColor = True
        '
        'Label28Portale
        '
        Me.Label28Portale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label28Portale.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28Portale.Location = New System.Drawing.Point(844, 381)
        Me.Label28Portale.MinimumSize = New System.Drawing.Size(150, 20)
        Me.Label28Portale.Name = "Label28Portale"
        Me.Label28Portale.Size = New System.Drawing.Size(188, 21)
        Me.Label28Portale.TabIndex = 16
        '
        'PanelBadge
        '
        Me.PanelBadge.BackColor = System.Drawing.Color.White
        Me.PanelBadge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBadge.Controls.Add(Me.testBadgeStatus)
        Me.PanelBadge.Controls.Add(Me.testBadgeMessage)
        Me.PanelBadge.Controls.Add(Me.Label11)
        Me.PanelBadge.Controls.Add(Me.LabelUidBadge)
        Me.PanelBadge.Controls.Add(Me.LoadingBadge)
        Me.PanelBadge.Controls.Add(Me.CheckBoxBadge)
        Me.PanelBadge.Location = New System.Drawing.Point(422, 417)
        Me.PanelBadge.Name = "PanelBadge"
        Me.PanelBadge.Size = New System.Drawing.Size(195, 148)
        Me.PanelBadge.TabIndex = 1
        '
        'testBadgeStatus
        '
        Me.testBadgeStatus.BackColor = System.Drawing.Color.Transparent
        Me.testBadgeStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.testBadgeStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.testBadgeStatus.Location = New System.Drawing.Point(159, -1)
        Me.testBadgeStatus.Name = "testBadgeStatus"
        Me.testBadgeStatus.Size = New System.Drawing.Size(34, 39)
        Me.testBadgeStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testBadgeStatus.TabIndex = 11
        Me.testBadgeStatus.TabStop = False
        Me.testBadgeStatus.Visible = False
        '
        'testBadgeMessage
        '
        Me.testBadgeMessage.AutoSize = True
        Me.testBadgeMessage.BackColor = System.Drawing.Color.LightGray
        Me.testBadgeMessage.ForeColor = System.Drawing.Color.Red
        Me.testBadgeMessage.Location = New System.Drawing.Point(7, 126)
        Me.testBadgeMessage.Name = "testBadgeMessage"
        Me.testBadgeMessage.Size = New System.Drawing.Size(16, 13)
        Me.testBadgeMessage.TabIndex = 21
        Me.testBadgeMessage.Text = "..."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(78, 74)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "UID"
        '
        'LabelUidBadge
        '
        Me.LabelUidBadge.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelUidBadge.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelUidBadge.Location = New System.Drawing.Point(27, 96)
        Me.LabelUidBadge.Name = "LabelUidBadge"
        Me.LabelUidBadge.Size = New System.Drawing.Size(134, 23)
        Me.LabelUidBadge.TabIndex = 18
        '
        'LoadingBadge
        '
        Me.LoadingBadge.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingBadge.Location = New System.Drawing.Point(158, -1)
        Me.LoadingBadge.Name = "LoadingBadge"
        Me.LoadingBadge.Size = New System.Drawing.Size(36, 39)
        Me.LoadingBadge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingBadge.TabIndex = 124
        Me.LoadingBadge.TabStop = False
        Me.LoadingBadge.Visible = False
        '
        'CheckBoxBadge
        '
        Me.CheckBoxBadge.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxBadge.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxBadge.Location = New System.Drawing.Point(10, 4)
        Me.CheckBoxBadge.Name = "CheckBoxBadge"
        Me.CheckBoxBadge.Size = New System.Drawing.Size(180, 139)
        Me.CheckBoxBadge.TabIndex = 20
        Me.CheckBoxBadge.Text = "Test Badge"
        Me.CheckBoxBadge.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxBadge.UseVisualStyleBackColor = True
        '
        'PanelWifi
        '
        Me.PanelWifi.BackColor = System.Drawing.Color.White
        Me.PanelWifi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelWifi.Controls.Add(Me.InfoWIFI)
        Me.PanelWifi.Controls.Add(Me.testWifiMessage)
        Me.PanelWifi.Controls.Add(Me.testWifiStatus)
        Me.PanelWifi.Controls.Add(Me.Label10)
        Me.PanelWifi.Controls.Add(Me.LabelMacAddress)
        Me.PanelWifi.Controls.Add(Me.LoadingWIFI)
        Me.PanelWifi.Controls.Add(Me.CheckBoxWifFi)
        Me.PanelWifi.Location = New System.Drawing.Point(422, 310)
        Me.PanelWifi.Name = "PanelWifi"
        Me.PanelWifi.Size = New System.Drawing.Size(195, 94)
        Me.PanelWifi.TabIndex = 2
        '
        'InfoWIFI
        '
        Me.InfoWIFI.BackColor = System.Drawing.Color.Transparent
        Me.InfoWIFI.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoWIFI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoWIFI.Location = New System.Drawing.Point(84, -1)
        Me.InfoWIFI.Name = "InfoWIFI"
        Me.InfoWIFI.Size = New System.Drawing.Size(20, 24)
        Me.InfoWIFI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoWIFI.TabIndex = 155
        Me.InfoWIFI.TabStop = False
        '
        'testWifiMessage
        '
        Me.testWifiMessage.AutoSize = True
        Me.testWifiMessage.ForeColor = System.Drawing.Color.Red
        Me.testWifiMessage.Location = New System.Drawing.Point(3, 129)
        Me.testWifiMessage.Name = "testWifiMessage"
        Me.testWifiMessage.Size = New System.Drawing.Size(16, 13)
        Me.testWifiMessage.TabIndex = 23
        Me.testWifiMessage.Text = "..."
        '
        'testWifiStatus
        '
        Me.testWifiStatus.BackColor = System.Drawing.Color.Transparent
        Me.testWifiStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.testWifiStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.testWifiStatus.Location = New System.Drawing.Point(158, -1)
        Me.testWifiStatus.Name = "testWifiStatus"
        Me.testWifiStatus.Size = New System.Drawing.Size(34, 39)
        Me.testWifiStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testWifiStatus.TabIndex = 23
        Me.testWifiStatus.TabStop = False
        Me.testWifiStatus.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(46, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 13)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "MAC ADDRESS"
        '
        'LabelMacAddress
        '
        Me.LabelMacAddress.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelMacAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMacAddress.Location = New System.Drawing.Point(28, 42)
        Me.LabelMacAddress.Name = "LabelMacAddress"
        Me.LabelMacAddress.Size = New System.Drawing.Size(144, 23)
        Me.LabelMacAddress.TabIndex = 19
        '
        'LoadingWIFI
        '
        Me.LoadingWIFI.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingWIFI.Location = New System.Drawing.Point(158, -1)
        Me.LoadingWIFI.Name = "LoadingWIFI"
        Me.LoadingWIFI.Size = New System.Drawing.Size(35, 39)
        Me.LoadingWIFI.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingWIFI.TabIndex = 123
        Me.LoadingWIFI.TabStop = False
        Me.LoadingWIFI.Visible = False
        '
        'CheckBoxWifFi
        '
        Me.CheckBoxWifFi.BackColor = System.Drawing.Color.White
        Me.CheckBoxWifFi.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxWifFi.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxWifFi.Location = New System.Drawing.Point(12, 4)
        Me.CheckBoxWifFi.Name = "CheckBoxWifFi"
        Me.CheckBoxWifFi.Size = New System.Drawing.Size(178, 84)
        Me.CheckBoxWifFi.TabIndex = 21
        Me.CheckBoxWifFi.Text = "Test WI-FI"
        Me.CheckBoxWifFi.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxWifFi.UseVisualStyleBackColor = False
        '
        'PanelSD
        '
        Me.PanelSD.BackColor = System.Drawing.Color.White
        Me.PanelSD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSD.Controls.Add(Me.InfoSD)
        Me.PanelSD.Controls.Add(Me.testSDStatus)
        Me.PanelSD.Controls.Add(Me.testSDMessage)
        Me.PanelSD.Controls.Add(Me.PictureBoxSD1)
        Me.PanelSD.Controls.Add(Me.PictureBoxSD2)
        Me.PanelSD.Controls.Add(Me.LabelSD2)
        Me.PanelSD.Controls.Add(Me.LabelSD1)
        Me.PanelSD.Controls.Add(Me.LoadingSD)
        Me.PanelSD.Controls.Add(Me.CheckBoxSD)
        Me.PanelSD.Location = New System.Drawing.Point(422, 208)
        Me.PanelSD.Name = "PanelSD"
        Me.PanelSD.Size = New System.Drawing.Size(195, 96)
        Me.PanelSD.TabIndex = 3
        '
        'InfoSD
        '
        Me.InfoSD.BackColor = System.Drawing.Color.Transparent
        Me.InfoSD.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoSD.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoSD.Location = New System.Drawing.Point(76, 0)
        Me.InfoSD.Name = "InfoSD"
        Me.InfoSD.Size = New System.Drawing.Size(20, 24)
        Me.InfoSD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoSD.TabIndex = 151
        Me.InfoSD.TabStop = False
        '
        'testSDStatus
        '
        Me.testSDStatus.BackColor = System.Drawing.Color.Transparent
        Me.testSDStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.testSDStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.testSDStatus.Location = New System.Drawing.Point(160, -1)
        Me.testSDStatus.Name = "testSDStatus"
        Me.testSDStatus.Size = New System.Drawing.Size(34, 39)
        Me.testSDStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testSDStatus.TabIndex = 10
        Me.testSDStatus.TabStop = False
        Me.testSDStatus.Visible = False
        '
        'testSDMessage
        '
        Me.testSDMessage.AutoSize = True
        Me.testSDMessage.ForeColor = System.Drawing.Color.Red
        Me.testSDMessage.Location = New System.Drawing.Point(3, 56)
        Me.testSDMessage.Name = "testSDMessage"
        Me.testSDMessage.Size = New System.Drawing.Size(16, 13)
        Me.testSDMessage.TabIndex = 9
        Me.testSDMessage.Text = "..."
        '
        'PictureBoxSD1
        '
        Me.PictureBoxSD1.Location = New System.Drawing.Point(92, 21)
        Me.PictureBoxSD1.Name = "PictureBoxSD1"
        Me.PictureBoxSD1.Size = New System.Drawing.Size(14, 13)
        Me.PictureBoxSD1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxSD1.TabIndex = 7
        Me.PictureBoxSD1.TabStop = False
        '
        'PictureBoxSD2
        '
        Me.PictureBoxSD2.Location = New System.Drawing.Point(92, 42)
        Me.PictureBoxSD2.Name = "PictureBoxSD2"
        Me.PictureBoxSD2.Size = New System.Drawing.Size(14, 13)
        Me.PictureBoxSD2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxSD2.TabIndex = 6
        Me.PictureBoxSD2.TabStop = False
        '
        'LabelSD2
        '
        Me.LabelSD2.AutoSize = True
        Me.LabelSD2.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSD2.Location = New System.Drawing.Point(14, 41)
        Me.LabelSD2.Name = "LabelSD2"
        Me.LabelSD2.Size = New System.Drawing.Size(58, 15)
        Me.LabelSD2.TabIndex = 3
        Me.LabelSD2.Text = "Spazio SD"
        '
        'LabelSD1
        '
        Me.LabelSD1.AutoSize = True
        Me.LabelSD1.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSD1.Location = New System.Drawing.Point(14, 21)
        Me.LabelSD1.Name = "LabelSD1"
        Me.LabelSD1.Size = New System.Drawing.Size(72, 15)
        Me.LabelSD1.TabIndex = 2
        Me.LabelSD1.Text = "SD Presente "
        '
        'LoadingSD
        '
        Me.LoadingSD.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingSD.Location = New System.Drawing.Point(160, -1)
        Me.LoadingSD.Name = "LoadingSD"
        Me.LoadingSD.Size = New System.Drawing.Size(34, 40)
        Me.LoadingSD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingSD.TabIndex = 120
        Me.LoadingSD.TabStop = False
        Me.LoadingSD.Visible = False
        '
        'CheckBoxSD
        '
        Me.CheckBoxSD.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxSD.Checked = True
        Me.CheckBoxSD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSD.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxSD.Location = New System.Drawing.Point(12, 4)
        Me.CheckBoxSD.Name = "CheckBoxSD"
        Me.CheckBoxSD.Size = New System.Drawing.Size(178, 87)
        Me.CheckBoxSD.TabIndex = 8
        Me.CheckBoxSD.Text = "Test SD"
        Me.CheckBoxSD.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxSD.UseVisualStyleBackColor = True
        '
        'PanelBatteria
        '
        Me.PanelBatteria.BackColor = System.Drawing.Color.White
        Me.PanelBatteria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBatteria.Controls.Add(Me.InfoBAT)
        Me.PanelBatteria.Controls.Add(Me.testBatteryStatusCode)
        Me.PanelBatteria.Controls.Add(Me.testBatteryMessage)
        Me.PanelBatteria.Controls.Add(Me.testBatteryStatus)
        Me.PanelBatteria.Controls.Add(Me.LabelSpaceTensione)
        Me.PanelBatteria.Controls.Add(Me.PictureBox1Battery)
        Me.PanelBatteria.Controls.Add(Me.PictureBox2Battery)
        Me.PanelBatteria.Controls.Add(Me.LabelBattery2)
        Me.PanelBatteria.Controls.Add(Me.LabelBattery1)
        Me.PanelBatteria.Controls.Add(Me.LoadingBattery)
        Me.PanelBatteria.Controls.Add(Me.CheckBoxBatteria)
        Me.PanelBatteria.Location = New System.Drawing.Point(631, 208)
        Me.PanelBatteria.Name = "PanelBatteria"
        Me.PanelBatteria.Size = New System.Drawing.Size(195, 96)
        Me.PanelBatteria.TabIndex = 2
        '
        'InfoBAT
        '
        Me.InfoBAT.BackColor = System.Drawing.Color.Transparent
        Me.InfoBAT.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoBAT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoBAT.Location = New System.Drawing.Point(85, 0)
        Me.InfoBAT.Name = "InfoBAT"
        Me.InfoBAT.Size = New System.Drawing.Size(20, 24)
        Me.InfoBAT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoBAT.TabIndex = 152
        Me.InfoBAT.TabStop = False
        '
        'testBatteryStatusCode
        '
        Me.testBatteryStatusCode.AutoSize = True
        Me.testBatteryStatusCode.Location = New System.Drawing.Point(81, 24)
        Me.testBatteryStatusCode.Name = "testBatteryStatusCode"
        Me.testBatteryStatusCode.Size = New System.Drawing.Size(22, 13)
        Me.testBatteryStatusCode.TabIndex = 12
        Me.testBatteryStatusCode.Text = "(...)"
        '
        'testBatteryMessage
        '
        Me.testBatteryMessage.AutoSize = True
        Me.testBatteryMessage.ForeColor = System.Drawing.Color.Red
        Me.testBatteryMessage.Location = New System.Drawing.Point(2, 79)
        Me.testBatteryMessage.Name = "testBatteryMessage"
        Me.testBatteryMessage.Size = New System.Drawing.Size(16, 13)
        Me.testBatteryMessage.TabIndex = 11
        Me.testBatteryMessage.Text = "..."
        '
        'testBatteryStatus
        '
        Me.testBatteryStatus.BackColor = System.Drawing.Color.Transparent
        Me.testBatteryStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.testBatteryStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.testBatteryStatus.Location = New System.Drawing.Point(158, -1)
        Me.testBatteryStatus.Name = "testBatteryStatus"
        Me.testBatteryStatus.Size = New System.Drawing.Size(34, 39)
        Me.testBatteryStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testBatteryStatus.TabIndex = 11
        Me.testBatteryStatus.TabStop = False
        Me.testBatteryStatus.Visible = False
        '
        'LabelSpaceTensione
        '
        Me.LabelSpaceTensione.AutoSize = True
        Me.LabelSpaceTensione.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelSpaceTensione.Location = New System.Drawing.Point(58, 58)
        Me.LabelSpaceTensione.MinimumSize = New System.Drawing.Size(45, 15)
        Me.LabelSpaceTensione.Name = "LabelSpaceTensione"
        Me.LabelSpaceTensione.Size = New System.Drawing.Size(45, 15)
        Me.LabelSpaceTensione.TabIndex = 10
        '
        'PictureBox1Battery
        '
        Me.PictureBox1Battery.Location = New System.Drawing.Point(113, 24)
        Me.PictureBox1Battery.Name = "PictureBox1Battery"
        Me.PictureBox1Battery.Size = New System.Drawing.Size(14, 13)
        Me.PictureBox1Battery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1Battery.TabIndex = 9
        Me.PictureBox1Battery.TabStop = False
        '
        'PictureBox2Battery
        '
        Me.PictureBox2Battery.Location = New System.Drawing.Point(113, 44)
        Me.PictureBox2Battery.Name = "PictureBox2Battery"
        Me.PictureBox2Battery.Size = New System.Drawing.Size(14, 13)
        Me.PictureBox2Battery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2Battery.TabIndex = 8
        Me.PictureBox2Battery.TabStop = False
        '
        'LabelBattery2
        '
        Me.LabelBattery2.AutoSize = True
        Me.LabelBattery2.Location = New System.Drawing.Point(-1, 44)
        Me.LabelBattery2.Name = "LabelBattery2"
        Me.LabelBattery2.Size = New System.Drawing.Size(90, 13)
        Me.LabelBattery2.TabIndex = 3
        Me.LabelBattery2.Text = "Tensione Interna "
        '
        'LabelBattery1
        '
        Me.LabelBattery1.AutoSize = True
        Me.LabelBattery1.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelBattery1.Location = New System.Drawing.Point(2, 24)
        Me.LabelBattery1.Name = "LabelBattery1"
        Me.LabelBattery1.Size = New System.Drawing.Size(77, 15)
        Me.LabelBattery1.TabIndex = 2
        Me.LabelBattery1.Text = "Stato Batteria"
        '
        'LoadingBattery
        '
        Me.LoadingBattery.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingBattery.Location = New System.Drawing.Point(158, 0)
        Me.LoadingBattery.Name = "LoadingBattery"
        Me.LoadingBattery.Size = New System.Drawing.Size(36, 38)
        Me.LoadingBattery.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingBattery.TabIndex = 121
        Me.LoadingBattery.TabStop = False
        Me.LoadingBattery.Visible = False
        '
        'CheckBoxBatteria
        '
        Me.CheckBoxBatteria.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxBatteria.Checked = True
        Me.CheckBoxBatteria.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxBatteria.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxBatteria.Location = New System.Drawing.Point(7, 5)
        Me.CheckBoxBatteria.Name = "CheckBoxBatteria"
        Me.CheckBoxBatteria.Size = New System.Drawing.Size(183, 90)
        Me.CheckBoxBatteria.TabIndex = 11
        Me.CheckBoxBatteria.Text = "Test Battery"
        Me.CheckBoxBatteria.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxBatteria.UseVisualStyleBackColor = True
        '
        'PanelAccelerometro
        '
        Me.PanelAccelerometro.BackColor = System.Drawing.Color.White
        Me.PanelAccelerometro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelAccelerometro.Controls.Add(Me.InfoACC)
        Me.PanelAccelerometro.Controls.Add(Me.testAccelerometerMessage)
        Me.PanelAccelerometro.Controls.Add(Me.testAccelerometerStatus)
        Me.PanelAccelerometro.Controls.Add(Me.LabelGradiInclinazione)
        Me.PanelAccelerometro.Controls.Add(Me.LabelInclinazione)
        Me.PanelAccelerometro.Controls.Add(Me.PictureBoxAzzeramento)
        Me.PanelAccelerometro.Controls.Add(Me.LabelAccelerometro2)
        Me.PanelAccelerometro.Controls.Add(Me.PictureBox1Accelerometro)
        Me.PanelAccelerometro.Controls.Add(Me.LabelAccelerometro1)
        Me.PanelAccelerometro.Controls.Add(Me.GifAcc)
        Me.PanelAccelerometro.Controls.Add(Me.LoadingAcc)
        Me.PanelAccelerometro.Controls.Add(Me.CheckBoxAccelerometro)
        Me.PanelAccelerometro.Location = New System.Drawing.Point(213, 208)
        Me.PanelAccelerometro.Name = "PanelAccelerometro"
        Me.PanelAccelerometro.Size = New System.Drawing.Size(195, 96)
        Me.PanelAccelerometro.TabIndex = 4
        '
        'InfoACC
        '
        Me.InfoACC.BackColor = System.Drawing.Color.Transparent
        Me.InfoACC.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoACC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoACC.Location = New System.Drawing.Point(99, 0)
        Me.InfoACC.Name = "InfoACC"
        Me.InfoACC.Size = New System.Drawing.Size(20, 24)
        Me.InfoACC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoACC.TabIndex = 150
        Me.InfoACC.TabStop = False
        '
        'testAccelerometerMessage
        '
        Me.testAccelerometerMessage.AutoSize = True
        Me.testAccelerometerMessage.ForeColor = System.Drawing.Color.Red
        Me.testAccelerometerMessage.Location = New System.Drawing.Point(3, 129)
        Me.testAccelerometerMessage.Name = "testAccelerometerMessage"
        Me.testAccelerometerMessage.Size = New System.Drawing.Size(16, 13)
        Me.testAccelerometerMessage.TabIndex = 22
        Me.testAccelerometerMessage.Text = "..."
        '
        'testAccelerometerStatus
        '
        Me.testAccelerometerStatus.BackColor = System.Drawing.Color.Transparent
        Me.testAccelerometerStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.testAccelerometerStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.testAccelerometerStatus.Location = New System.Drawing.Point(159, -2)
        Me.testAccelerometerStatus.Name = "testAccelerometerStatus"
        Me.testAccelerometerStatus.Size = New System.Drawing.Size(34, 39)
        Me.testAccelerometerStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testAccelerometerStatus.TabIndex = 22
        Me.testAccelerometerStatus.TabStop = False
        Me.testAccelerometerStatus.Visible = False
        '
        'LabelGradiInclinazione
        '
        Me.LabelGradiInclinazione.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelGradiInclinazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGradiInclinazione.Location = New System.Drawing.Point(76, 58)
        Me.LabelGradiInclinazione.Name = "LabelGradiInclinazione"
        Me.LabelGradiInclinazione.Size = New System.Drawing.Size(47, 23)
        Me.LabelGradiInclinazione.TabIndex = 17
        '
        'LabelInclinazione
        '
        Me.LabelInclinazione.AutoSize = True
        Me.LabelInclinazione.Location = New System.Drawing.Point(-1, 61)
        Me.LabelInclinazione.Name = "LabelInclinazione"
        Me.LabelInclinazione.Size = New System.Drawing.Size(63, 13)
        Me.LabelInclinazione.TabIndex = 16
        Me.LabelInclinazione.Text = "Inclinazione"
        '
        'PictureBoxAzzeramento
        '
        Me.PictureBoxAzzeramento.Location = New System.Drawing.Point(88, 42)
        Me.PictureBoxAzzeramento.Name = "PictureBoxAzzeramento"
        Me.PictureBoxAzzeramento.Size = New System.Drawing.Size(14, 13)
        Me.PictureBoxAzzeramento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxAzzeramento.TabIndex = 15
        Me.PictureBoxAzzeramento.TabStop = False
        '
        'LabelAccelerometro2
        '
        Me.LabelAccelerometro2.AutoSize = True
        Me.LabelAccelerometro2.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAccelerometro2.Location = New System.Drawing.Point(2, 40)
        Me.LabelAccelerometro2.Name = "LabelAccelerometro2"
        Me.LabelAccelerometro2.Size = New System.Drawing.Size(75, 15)
        Me.LabelAccelerometro2.TabIndex = 13
        Me.LabelAccelerometro2.Text = "Azzeramento"
        '
        'PictureBox1Accelerometro
        '
        Me.PictureBox1Accelerometro.Location = New System.Drawing.Point(88, 24)
        Me.PictureBox1Accelerometro.Name = "PictureBox1Accelerometro"
        Me.PictureBox1Accelerometro.Size = New System.Drawing.Size(14, 13)
        Me.PictureBox1Accelerometro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1Accelerometro.TabIndex = 12
        Me.PictureBox1Accelerometro.TabStop = False
        '
        'LabelAccelerometro1
        '
        Me.LabelAccelerometro1.AutoSize = True
        Me.LabelAccelerometro1.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelAccelerometro1.Location = New System.Drawing.Point(6, 24)
        Me.LabelAccelerometro1.Name = "LabelAccelerometro1"
        Me.LabelAccelerometro1.Size = New System.Drawing.Size(61, 15)
        Me.LabelAccelerometro1.TabIndex = 2
        Me.LabelAccelerometro1.Text = "Setup Test"
        '
        'GifAcc
        '
        Me.GifAcc.BackColor = System.Drawing.Color.Transparent
        Me.GifAcc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GifAcc.Image = Global.FlashedLOL.My.Resources.Res.MDT_Assembly_v8
        Me.GifAcc.Location = New System.Drawing.Point(107, 40)
        Me.GifAcc.Name = "GifAcc"
        Me.GifAcc.Size = New System.Drawing.Size(109, 55)
        Me.GifAcc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.GifAcc.TabIndex = 127
        Me.GifAcc.TabStop = False
        Me.GifAcc.Visible = False
        '
        'LoadingAcc
        '
        Me.LoadingAcc.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingAcc.Location = New System.Drawing.Point(160, -2)
        Me.LoadingAcc.Name = "LoadingAcc"
        Me.LoadingAcc.Size = New System.Drawing.Size(33, 41)
        Me.LoadingAcc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingAcc.TabIndex = 122
        Me.LoadingAcc.TabStop = False
        Me.LoadingAcc.Visible = False
        '
        'CheckBoxAccelerometro
        '
        Me.CheckBoxAccelerometro.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxAccelerometro.Checked = True
        Me.CheckBoxAccelerometro.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAccelerometro.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxAccelerometro.Location = New System.Drawing.Point(10, 4)
        Me.CheckBoxAccelerometro.Name = "CheckBoxAccelerometro"
        Me.CheckBoxAccelerometro.Size = New System.Drawing.Size(180, 87)
        Me.CheckBoxAccelerometro.TabIndex = 18
        Me.CheckBoxAccelerometro.Text = "Accelerometro"
        Me.CheckBoxAccelerometro.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxAccelerometro.UseVisualStyleBackColor = True
        '
        'PanelSim
        '
        Me.PanelSim.BackColor = System.Drawing.Color.White
        Me.PanelSim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelSim.Controls.Add(Me.InfoSIM)
        Me.PanelSim.Controls.Add(Me.Label58)
        Me.PanelSim.Controls.Add(Me.testSIMMessage)
        Me.PanelSim.Controls.Add(Me.testSIMStatus)
        Me.PanelSim.Controls.Add(Me.LabelSim2)
        Me.PanelSim.Controls.Add(Me.PictureBoxSim1)
        Me.PanelSim.Controls.Add(Me.PictureBoxSim2)
        Me.PanelSim.Controls.Add(Me.LabelSim1)
        Me.PanelSim.Controls.Add(Me.LoadingSIM)
        Me.PanelSim.Controls.Add(Me.CheckBoxSim)
        Me.PanelSim.Location = New System.Drawing.Point(5, 310)
        Me.PanelSim.Name = "PanelSim"
        Me.PanelSim.Size = New System.Drawing.Size(195, 94)
        Me.PanelSim.TabIndex = 2
        '
        'InfoSIM
        '
        Me.InfoSIM.BackColor = System.Drawing.Color.Transparent
        Me.InfoSIM.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Info
        Me.InfoSIM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.InfoSIM.Location = New System.Drawing.Point(73, -1)
        Me.InfoSIM.Name = "InfoSIM"
        Me.InfoSIM.Size = New System.Drawing.Size(20, 24)
        Me.InfoSIM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.InfoSIM.TabIndex = 153
        Me.InfoSIM.TabStop = False
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label58.Location = New System.Drawing.Point(109, 69)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(13, 13)
        Me.Label58.TabIndex = 78
        Me.Label58.Text = ".."
        '
        'testSIMMessage
        '
        Me.testSIMMessage.AutoSize = True
        Me.testSIMMessage.ForeColor = System.Drawing.Color.Red
        Me.testSIMMessage.Location = New System.Drawing.Point(3, 64)
        Me.testSIMMessage.Name = "testSIMMessage"
        Me.testSIMMessage.Size = New System.Drawing.Size(16, 13)
        Me.testSIMMessage.TabIndex = 12
        Me.testSIMMessage.Text = "..."
        '
        'testSIMStatus
        '
        Me.testSIMStatus.BackColor = System.Drawing.Color.Transparent
        Me.testSIMStatus.BackgroundImage = Global.FlashedLOL.My.Resources.Res.Correct
        Me.testSIMStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.testSIMStatus.Location = New System.Drawing.Point(160, -1)
        Me.testSIMStatus.Name = "testSIMStatus"
        Me.testSIMStatus.Size = New System.Drawing.Size(34, 39)
        Me.testSIMStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.testSIMStatus.TabIndex = 12
        Me.testSIMStatus.TabStop = False
        Me.testSIMStatus.Visible = False
        '
        'LabelSim2
        '
        Me.LabelSim2.AutoSize = True
        Me.LabelSim2.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSim2.Location = New System.Drawing.Point(17, 47)
        Me.LabelSim2.Name = "LabelSim2"
        Me.LabelSim2.Size = New System.Drawing.Size(48, 15)
        Me.LabelSim2.TabIndex = 10
        Me.LabelSim2.Text = "Segnale"
        '
        'PictureBoxSim1
        '
        Me.PictureBoxSim1.Location = New System.Drawing.Point(120, 32)
        Me.PictureBoxSim1.Name = "PictureBoxSim1"
        Me.PictureBoxSim1.Size = New System.Drawing.Size(14, 13)
        Me.PictureBoxSim1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxSim1.TabIndex = 9
        Me.PictureBoxSim1.TabStop = False
        '
        'PictureBoxSim2
        '
        Me.PictureBoxSim2.Location = New System.Drawing.Point(120, 51)
        Me.PictureBoxSim2.Name = "PictureBoxSim2"
        Me.PictureBoxSim2.Size = New System.Drawing.Size(14, 13)
        Me.PictureBoxSim2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxSim2.TabIndex = 8
        Me.PictureBoxSim2.TabStop = False
        '
        'LabelSim1
        '
        Me.LabelSim1.AutoSize = True
        Me.LabelSim1.Font = New System.Drawing.Font("Microsoft JhengHei", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSim1.Location = New System.Drawing.Point(17, 32)
        Me.LabelSim1.Name = "LabelSim1"
        Me.LabelSim1.Size = New System.Drawing.Size(78, 15)
        Me.LabelSim1.TabIndex = 2
        Me.LabelSim1.Text = "SIM Presente "
        '
        'LoadingSIM
        '
        Me.LoadingSIM.Image = Global.FlashedLOL.My.Resources.Res.Loading
        Me.LoadingSIM.Location = New System.Drawing.Point(160, -1)
        Me.LoadingSIM.Name = "LoadingSIM"
        Me.LoadingSIM.Size = New System.Drawing.Size(33, 39)
        Me.LoadingSIM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.LoadingSIM.TabIndex = 122
        Me.LoadingSIM.TabStop = False
        Me.LoadingSIM.Visible = False
        '
        'CheckBoxSim
        '
        Me.CheckBoxSim.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxSim.Checked = True
        Me.CheckBoxSim.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSim.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxSim.Location = New System.Drawing.Point(7, 4)
        Me.CheckBoxSim.Name = "CheckBoxSim"
        Me.CheckBoxSim.Size = New System.Drawing.Size(183, 84)
        Me.CheckBoxSim.TabIndex = 11
        Me.CheckBoxSim.Text = "Test SIM"
        Me.CheckBoxSim.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.CheckBoxSim.UseVisualStyleBackColor = True
        '
        'Collaudo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(1169, 744)
        Me.Controls.Add(Me.TabControlCollaudoBase)
        Me.KeyPreview = True
        Me.Name = "Collaudo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.TabControlCollaudoBase.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.PanelEventUSB.ResumeLayout(False)
        Me.PanelEventUSB.PerformLayout()
        CType(Me.PictureUSBscollegato, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureErrorUSB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarcodeReader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.InfoRS232, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorRS232, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPortale.ResumeLayout(False)
        Me.PanelPortale.PerformLayout()
        CType(Me.InfoPORT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testComunicazioneStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxDevice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxComunicazione, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingPortale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelCAN.ResumeLayout(False)
        Me.PanelCAN.PerformLayout()
        CType(Me.InfoCAN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAN2_NOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAN1_NOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorTestCAN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAN2_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAN1_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestCANStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingCAN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelIngressi.ResumeLayout(False)
        Me.PanelIngressi.PerformLayout()
        CType(Me.IP2_NOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IP2_0K, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InfoIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IP4_NOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IP3_NOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IP1_NOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorTestIP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IP4_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IP3_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testIngressiStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IP1_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingIP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5V.ResumeLayout(False)
        Me.Panel5V.PerformLayout()
        CType(Me.Info5V, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.V5_NOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorTest5V, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.V5_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.test5Vstatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Loading5V, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelRelè.ResumeLayout(False)
        Me.PanelRelè.PerformLayout()
        CType(Me.InfoRL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestReleStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorTestRL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RL2_NOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RL1_NOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RL1_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RL2_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingRL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAlimentazione.ResumeLayout(False)
        Me.PanelAlimentazione.PerformLayout()
        CType(Me.InfoPWR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PWR_NOT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PWR_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorTestPWR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TestAlimentazioneStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingPWR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.testETS_ETSDNStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.testUtenzaStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSync.ResumeLayout(False)
        Me.PanelSync.PerformLayout()
        CType(Me.InfoMemory, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testMemsyncStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1ImpotaMemoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1EsportaMemoria, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1Sync, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2L03Peso, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1formattazione, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingSync, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBadge.ResumeLayout(False)
        Me.PanelBadge.PerformLayout()
        CType(Me.testBadgeStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingBadge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelWifi.ResumeLayout(False)
        Me.PanelWifi.PerformLayout()
        CType(Me.InfoWIFI, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testWifiStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingWIFI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSD.ResumeLayout(False)
        Me.PanelSD.PerformLayout()
        CType(Me.InfoSD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testSDStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxSD1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxSD2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingSD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBatteria.ResumeLayout(False)
        Me.PanelBatteria.PerformLayout()
        CType(Me.InfoBAT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testBatteryStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1Battery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2Battery, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingBattery, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelAccelerometro.ResumeLayout(False)
        Me.PanelAccelerometro.PerformLayout()
        CType(Me.InfoACC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testAccelerometerStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxAzzeramento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1Accelerometro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GifAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingAcc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelSim.ResumeLayout(False)
        Me.PanelSim.PerformLayout()
        CType(Me.InfoSIM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.testSIMStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxSim1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxSim2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LoadingSIM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub



    Friend WithEvents TimerTest As Timer
    Friend WithEvents OFD As OpenFileDialog
    Friend WithEvents TimerIconAndCubo As Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TimerRDWCommandR01 As Timer
    Friend WithEvents TimerInserimetoParam As Timer
    Friend WithEvents TimerRichiestaParametri As Timer
    Friend WithEvents TabControlCollaudoBase As TabControl
    Friend WithEvents testComunicazioneMessage As Label

    Friend WithEvents TestRelèStatus As PictureBox
    'Friend WithEvents Label21 As Label
    Friend WithEvents CheckBoxRelè As CheckBox
    Friend WithEvents PictureBoxRelè1 As PictureBox
    Friend WithEvents PictureBoxRelè2 As PictureBox

    Friend WithEvents ComboBoxNodeID As ComboBox
    Friend WithEvents ComboBoxFunctionID As ComboBox
    'Friend WithEvents Label44 As Label
    'Friend WithEvents Label45 As Label
    'Friend WithEvents Button2 As Button
    'Friend WithEvents TestIngressiMessage As Label
    'Friend WithEvents Test5VMessage As Label
    Friend WithEvents TestRelèMessage As Label
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents UpdateIP As Button
    Friend WithEvents BarcodeReader As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents CBConfRS232 As ComboBox
    Friend WithEvents LeggiCodRS232 As Button
    Friend WithEvents LabelCodRS232 As Label
    Friend WithEvents ResetP90 As Button
    Friend WithEvents ProgressBarTest As ProgressBar
    Friend WithEvents PanelPortale As Panel
    Friend WithEvents Label59 As Label
    Friend WithEvents testComunicazioneStatus As PictureBox
    Friend WithEvents CheckBoxPortale As CheckBox
    Friend WithEvents PictureBoxDevice As PictureBox
    Friend WithEvents Label14 As Label
    Friend WithEvents LabelSpacePOrtale As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents PictureBoxComunicazione As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents LoadingPortale As PictureBox
    Friend WithEvents Label54 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents LabelMongostatus As Label
    Friend WithEvents ButtonMongoCollaudo As Button
    Friend WithEvents CollaudoScheda As CheckBox
    Friend WithEvents PanelCAN As Panel
    Friend WithEvents CAN2_NOT As PictureBox
    Friend WithEvents CAN1_NOT As PictureBox
    Friend WithEvents ErrorTestCAN As PictureBox
    Friend WithEvents Label49 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents CAN2_OK As PictureBox
    Friend WithEvents CAN1_OK As PictureBox
    Friend WithEvents TestCANMessage As Label
    Friend WithEvents TestCANStatus As PictureBox
    Friend WithEvents Label47 As Label
    Friend WithEvents CheckBoxCAN As CheckBox
    Friend WithEvents LoadingCAN As PictureBox
    Friend WithEvents PanelIngressi As Panel
    Friend WithEvents IP4_NOT As PictureBox
    Friend WithEvents IP3_NOT As PictureBox
    Friend WithEvents IP2_NOT As PictureBox
    Friend WithEvents IP1_NOT As PictureBox
    Friend WithEvents ErrorTestIP As PictureBox
    Friend WithEvents AnalogicIP4 As Label
    Friend WithEvents Label45 As Label
    Friend WithEvents IP4_OK As PictureBox
    Friend WithEvents Label46 As Label
    Friend WithEvents TestIngressiMessage As Label
    Friend WithEvents IP3_OK As PictureBox
    Friend WithEvents IP3 As Label
    Friend WithEvents testIngressiStatus As PictureBox
    Friend WithEvents Label36 As Label
    Friend WithEvents CheckBoxIngressi As CheckBox
    Friend WithEvents IP1_OK As PictureBox
    Friend WithEvents IP2_0K As PictureBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents LoadingIP As PictureBox
    Friend WithEvents Panel5V As Panel
    Friend WithEvents V5_NOT As PictureBox
    Friend WithEvents ErrorTest5V As PictureBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents V5_OK As PictureBox
    Friend WithEvents Valore5V As Label
    Friend WithEvents Test5VMessage As Label
    Friend WithEvents test5Vstatus As PictureBox
    Friend WithEvents Label35 As Label
    Friend WithEvents CheckBox5V As CheckBox
    Friend WithEvents Loading5V As PictureBox
    Friend WithEvents PanelRelè As Panel
    Friend WithEvents TestReleStatus As PictureBox
    Friend WithEvents ErrorTestRL As PictureBox
    Friend WithEvents RL2_NOT As PictureBox
    Friend WithEvents RL1_NOT As PictureBox
    Friend WithEvents Label57 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents RL1_OK As PictureBox
    Friend WithEvents RL2_OK As PictureBox
    Friend WithEvents LoadingRL As PictureBox
    Friend WithEvents TestReleMessage As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents CheckBoxRele As CheckBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents PanelAlimentazione As Panel
    Friend WithEvents PWR_NOT As PictureBox
    Friend WithEvents PWR_OK As PictureBox
    Friend WithEvents Label23 As Label
    Friend WithEvents ErrorTestPWR As PictureBox
    Friend WithEvents TestAlimentazioneStatus As PictureBox
    Friend WithEvents LoadingPWR As PictureBox
    Friend WithEvents Label25 As Label
    Friend WithEvents testAlimentazioneMessage As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents CheckBoxAlimentazione As CheckBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents testETS_ETSDNStatus As PictureBox
    Friend WithEvents CheckBoxETSDN As CheckBox
    Friend WithEvents Label20 As Label
    Friend WithEvents CheckBoxOverrideETSDN As CheckBox
    Friend WithEvents LabelRespFromAssocETSDN As Label
    Friend WithEvents labelOverride As Label
    Friend WithEvents TextBoxSerialeETSDN As TextBox
    Friend WithEvents ButtonAssocETSDN As Button
    Friend WithEvents LabelSerialeETSDN As Label
    Friend WithEvents CheckBoxSelezionaTutti As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents testUtenzaMessage As Label
    Friend WithEvents testUtenzaStatus As PictureBox
    Friend WithEvents CheckBoxUtenza As CheckBox
    Friend WithEvents Label24 As Label
    Friend WithEvents ButtonStartTest As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents LabelDATA As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents LabelORA As Label
    Friend WithEvents labelSerialNumber As Label
    Friend WithEvents ButtonSync As Button
    Friend WithEvents Label31 As Label
    Friend WithEvents LabelCom As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents ComboBoxApn As ComboBox
    Friend WithEvents Label32 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents PanelSync As Panel
    Friend WithEvents Label19 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents testMemsyncMessage As Label
    Friend WithEvents testMemsyncExportPercentage As Label
    Friend WithEvents testMemsyncStatus As PictureBox
    Friend WithEvents CheckBoxMemoria As CheckBox
    Friend WithEvents PictureBox1ImpotaMemoria As PictureBox
    Friend WithEvents PictureBox1EsportaMemoria As PictureBox
    Friend WithEvents PictureBox1Sync As PictureBox
    Friend WithEvents PictureBox2L03Peso As PictureBox
    Friend WithEvents PictureBox1formattazione As PictureBox
    Friend WithEvents LoadingSync As PictureBox
    Friend WithEvents Label28Portale As Label
    Friend WithEvents PanelBadge As Panel
    Friend WithEvents testBadgeStatus As PictureBox
    Friend WithEvents testBadgeMessage As Label
    Friend WithEvents CheckBoxBadge As CheckBox
    Friend WithEvents Label11 As Label
    Friend WithEvents LabelUidBadge As Label
    Friend WithEvents LoadingBadge As PictureBox
    Friend WithEvents PanelWifi As Panel
    Friend WithEvents testWifiMessage As Label
    Friend WithEvents testWifiStatus As PictureBox
    Friend WithEvents CheckBoxWifFi As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents LabelMacAddress As Label
    Friend WithEvents LoadingWIFI As PictureBox
    Friend WithEvents PanelSD As Panel
    Friend WithEvents testSDStatus As PictureBox
    Friend WithEvents testSDMessage As Label
    Friend WithEvents CheckBoxSD As CheckBox
    Friend WithEvents PictureBoxSD1 As PictureBox
    Friend WithEvents PictureBoxSD2 As PictureBox
    Friend WithEvents LabelSD2 As Label
    Friend WithEvents LabelSD1 As Label
    Friend WithEvents LoadingSD As PictureBox
    Friend WithEvents PanelBatteria As Panel
    Friend WithEvents testBatteryStatusCode As Label
    Friend WithEvents testBatteryMessage As Label
    Friend WithEvents testBatteryStatus As PictureBox
    Friend WithEvents CheckBoxBatteria As CheckBox
    Friend WithEvents LabelSpaceTensione As Label
    Friend WithEvents PictureBox1Battery As PictureBox
    Friend WithEvents PictureBox2Battery As PictureBox
    Friend WithEvents LabelBattery2 As Label
    Friend WithEvents LabelBattery1 As Label
    Friend WithEvents LoadingBattery As PictureBox
    Friend WithEvents LabelIp As Label
    Friend WithEvents PanelAccelerometro As Panel
    Friend WithEvents testAccelerometerMessage As Label
    Friend WithEvents testAccelerometerStatus As PictureBox
    Friend WithEvents CheckBoxAccelerometro As CheckBox
    Friend WithEvents LabelGradiInclinazione As Label
    Friend WithEvents LabelInclinazione As Label
    Friend WithEvents PictureBoxAzzeramento As PictureBox
    Friend WithEvents LabelAccelerometro2 As Label
    Friend WithEvents PictureBox1Accelerometro As PictureBox
    Friend WithEvents LabelAccelerometro1 As Label
    Friend WithEvents GifAcc As PictureBox
    Friend WithEvents LoadingAcc As PictureBox
    Friend WithEvents PanelSim As Panel
    Friend WithEvents Label58 As Label
    Friend WithEvents testSIMMessage As Label
    Friend WithEvents testSIMStatus As PictureBox
    Friend WithEvents CheckBoxSim As CheckBox
    Friend WithEvents LabelSim2 As Label
    Friend WithEvents PictureBoxSim1 As PictureBox
    Friend WithEvents PictureBoxSim2 As PictureBox
    Friend WithEvents LabelSim1 As Label
    Friend WithEvents LoadingSIM As PictureBox
    Friend WithEvents ButtonStop As Button
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents OpenLog As Button
    Friend WithEvents CheckRS232 As CheckBox
    Friend WithEvents ErrorRS232 As PictureBox
    Friend WithEvents ButtonErrorView As Button
    Friend WithEvents PanelEventUSB As Panel
    Friend WithEvents LabelErrorUSB As Label
    Friend WithEvents PictureUSBscollegato As PictureBox
    Friend WithEvents PictureErrorUSB As PictureBox
    Friend WithEvents ErrorInfo As Button
    Friend WithEvents InfoCAN As PictureBox
    Friend WithEvents InfoIP As PictureBox
    Friend WithEvents Info5V As PictureBox
    Friend WithEvents InfoRL As PictureBox
    Friend WithEvents InfoPWR As PictureBox
    Friend WithEvents InfoACC As PictureBox
    Friend WithEvents InfoRS232 As PictureBox
    Friend WithEvents InfoPORT As PictureBox
    Friend WithEvents InfoMemory As PictureBox
    Friend WithEvents InfoWIFI As PictureBox
    Friend WithEvents InfoSD As PictureBox
    Friend WithEvents InfoBAT As PictureBox
    Friend WithEvents InfoSIM As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TensioneEsterna As Label
    Friend WithEvents vCurrent2 As Label
    Friend WithEvents vCurrent1 As Label
    'Friend WithEvents testAlimentazioneMessage As Label

End Class
