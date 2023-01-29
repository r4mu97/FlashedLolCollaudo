<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.SerialPort = New System.IO.Ports.SerialPort(Me.components)
        Me.LPing = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TCicloSistema = New System.Windows.Forms.Timer(Me.components)
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.DropdownComPorts = New System.Windows.Forms.ComboBox()
        Me.LCom = New System.Windows.Forms.Label()
        Me.ButtonStart = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PBF = New System.Windows.Forms.ProgressBar()
        Me.PBFU = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PBConf = New System.Windows.Forms.ProgressBar()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PBHR = New System.Windows.Forms.ProgressBar()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.LFlashingBootloader = New System.Windows.Forms.Label()
        Me.LConfigurazioneAutomatica = New System.Windows.Forms.Label()
        Me.LInvioHR = New System.Windows.Forms.Label()
        Me.PBGPS = New System.Windows.Forms.ProgressBar()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.LTestGPS = New System.Windows.Forms.Label()
        Me.PBAcclrmtr = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LAccelerometro = New System.Windows.Forms.Label()
        Me.CheckboxFlashBootloader = New System.Windows.Forms.CheckBox()
        Me.CheckboxFlashFirmware = New System.Windows.Forms.CheckBox()
        Me.CheckboxCA = New System.Windows.Forms.CheckBox()
        Me.CBTestHR = New System.Windows.Forms.CheckBox()
        Me.CBTestGPS = New System.Windows.Forms.CheckBox()
        Me.CBTestAccel = New System.Windows.Forms.CheckBox()
        Me.LNomeNuovoFirmware = New System.Windows.Forms.Label()
        Me.DropdownDevicesProfiles = New System.Windows.Forms.ComboBox()
        Me.CBVidPidSN = New System.Windows.Forms.ComboBox()
        Me.TextboxCPSerialNumber = New System.Windows.Forms.TextBox()
        Me.TextboxCPProductString = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.BSNPS = New System.Windows.Forms.Button()
        Me.PBCalibrazione = New System.Windows.Forms.ProgressBar()
        Me.CBCalibrazione = New System.Windows.Forms.CheckBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.LCalibrazione = New System.Windows.Forms.Label()
        Me.CheckboxSyncDatetime = New System.Windows.Forms.CheckBox()
        Me.LSincDataOra = New System.Windows.Forms.Label()
        Me.BAggiornaCP = New System.Windows.Forms.Button()
        Me.ButtonStop = New System.Windows.Forms.Button()
        Me.CheckboxWriteSerialNumber = New System.Windows.Forms.CheckBox()
        Me.CheckboxWriteHardwareCode = New System.Windows.Forms.CheckBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TextboxHardwareCode = New System.Windows.Forms.TextBox()
        Me.CheckboxWriteGpsVersion = New System.Windows.Forms.CheckBox()
        Me.TBGPSVersion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LprodString = New System.Windows.Forms.Label()
        Me.CheckboxWriteProductString = New System.Windows.Forms.CheckBox()
        Me.CheckboxFwEnableModGps = New System.Windows.Forms.CheckBox()
        Me.CheckboxFwEnableModSD = New System.Windows.Forms.CheckBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ButtonUpdateFile = New System.Windows.Forms.Button()
        Me.CheckBoxAutoUSB_SET = New System.Windows.Forms.CheckBox()
        Me.ListBoxSeriali = New System.Windows.Forms.ListBox()
        Me.ButtonCLearOldSerial = New System.Windows.Forms.Button()
        Me.CheckboxHwEnableWifi = New System.Windows.Forms.CheckBox()
        Me.CheckboxHwEnableGPRS = New System.Windows.Forms.CheckBox()
        Me.CheckboxHwEnableGPS = New System.Windows.Forms.CheckBox()
        Me.CheckboxHwEnableSD = New System.Windows.Forms.CheckBox()
        Me.GroupBoxHWSetup = New System.Windows.Forms.GroupBox()
        Me.CheckboxHwEnableCartellino = New System.Windows.Forms.CheckBox()
        Me.LabelHwSetup = New System.Windows.Forms.Label()
        Me.CheckboxHWSetup = New System.Windows.Forms.CheckBox()
        Me.CheckBoxHWSetupMoved = New System.Windows.Forms.CheckBox()
        Me.CheckboxFwEnableKbd = New System.Windows.Forms.CheckBox()
        Me.CheckboxFwEnableFps = New System.Windows.Forms.CheckBox()
        Me.LabelStatus = New System.Windows.Forms.Label()
        Me.LabelAction = New System.Windows.Forms.Label()
        Me.CheckBoxCAN = New System.Windows.Forms.CheckBox()
        Me.TextBoxNodoCAN = New System.Windows.Forms.TextBox()
        Me.LBVersioneHW = New System.Windows.Forms.Label()
        Me.CBOTG = New System.Windows.Forms.CheckBox()
        Me.ProgressBarOTG = New System.Windows.Forms.ProgressBar()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBoxOTGPAth = New System.Windows.Forms.TextBox()
        Me.ComboBoxConf = New System.Windows.Forms.ComboBox()
        Me.CheckBoxInitETS = New System.Windows.Forms.CheckBox()
        Me.PBSincDataOra = New System.Windows.Forms.ProgressBar()
        Me.CheckboxFormatSD = New System.Windows.Forms.CheckBox()
        Me.CheckboxWriteCloudCode = New System.Windows.Forms.CheckBox()
        Me.TextboxCloudCode = New System.Windows.Forms.TextBox()
        Me.TextBoxCloudPw = New System.Windows.Forms.TextBox()
        Me.CheckBoxSerialAnagrafica = New System.Windows.Forms.CheckBox()
        Me.GroupBoxNewValues = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanelSerializza = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanelComando = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanelValue = New System.Windows.Forms.FlowLayoutPanel()
        Me.FlowLayoutPanelOffset = New System.Windows.Forms.FlowLayoutPanel()
        Me.Labelquest = New System.Windows.Forms.Label()
        Me.NumericUpDownValoriCount = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.ButtonDivineETSSetUser = New System.Windows.Forms.Button()
        Me.ButtonDivineETSDNAssoc = New System.Windows.Forms.Button()
        Me.ButtonDivineETSCANBaudSet = New System.Windows.Forms.Button()
        Me.ButtonBLERP0 = New System.Windows.Forms.Button()
        Me.ButtonBLESETId = New System.Windows.Forms.Button()
        Me.ButtonUpdateWiFly = New System.Windows.Forms.Button()
        Me.ButtonReadWiFly = New System.Windows.Forms.Button()
        Me.TextBoxAnalPrefix = New System.Windows.Forms.TextBox()
        Me.LabelFwVersions = New System.Windows.Forms.Label()
        Me.LabelWaitForMDT = New System.Windows.Forms.Label()
        Me.CheckboxFwEnableTouch = New System.Windows.Forms.CheckBox()
        Me.CheckBoxHack = New System.Windows.Forms.CheckBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.DataGridViewRemoteLol = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsMaster = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfirmedDevice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfirmedHW = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfirmedSerial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrentSerial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NeedsNewSerial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ConfirmedEtichettaData = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastSeen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.DataGridViewRemoteLolMinHR = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckBoxDivineSync = New System.Windows.Forms.CheckBox()
        Me.PBRX = New System.Windows.Forms.PictureBox()
        Me.PBTX = New System.Windows.Forms.PictureBox()
        Me.TextBoxRemoteLOLID = New System.Windows.Forms.TextBox()
        Me.TimerHeartRate = New System.Windows.Forms.Timer(Me.components)
        Me.CheckBoxRemoteLolMaster = New System.Windows.Forms.CheckBox()
        Me.LabelSerialiDaRecuperare = New System.Windows.Forms.Label()
        Me.ButtonCreateCSV = New System.Windows.Forms.Button()
        Me.ComboBoxLabelType = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CheckBoxClearAllarmi = New System.Windows.Forms.CheckBox()
        Me.LabelFlasingFw = New System.Windows.Forms.Label()
        Me.TabControlMigrazione = New System.Windows.Forms.TabControl()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBoxGRSatLogin = New System.Windows.Forms.GroupBox()
        Me.CheckboxConfigureDeviceOnGRSat = New System.Windows.Forms.CheckBox()
        Me.LinkLabelGoToGRsat = New System.Windows.Forms.LinkLabel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.ButtonAssetCreate = New System.Windows.Forms.Button()
        Me.LinkLabelAssetLoadSheets = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelAssetLoadUnits = New System.Windows.Forms.LinkLabel()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.CBAssetMeter2Spn = New System.Windows.Forms.ComboBox()
        Me.CBAssetMeter2 = New System.Windows.Forms.CheckBox()
        Me.CBAssetMeter1Spn = New System.Windows.Forms.ComboBox()
        Me.CBAssetMeter1 = New System.Windows.Forms.CheckBox()
        Me.CBAssetUses = New System.Windows.Forms.CheckBox()
        Me.CBAssetRSSI = New System.Windows.Forms.CheckBox()
        Me.CBAssetChart = New System.Windows.Forms.CheckBox()
        Me.CBAssetAlarm = New System.Windows.Forms.CheckBox()
        Me.CBAssetDummy = New System.Windows.Forms.CheckBox()
        Me.CBAssetInspector = New System.Windows.Forms.CheckBox()
        Me.CBAssetGPS = New System.Windows.Forms.CheckBox()
        Me.CBAssetRoutes = New System.Windows.Forms.CheckBox()
        Me.CBAssetMap = New System.Windows.Forms.CheckBox()
        Me.CBAssetProfile = New System.Windows.Forms.CheckBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.CheckBoxAutoFillAssetData = New System.Windows.Forms.CheckBox()
        Me.TBAssetDesc = New System.Windows.Forms.TextBox()
        Me.TBAssetBrand = New System.Windows.Forms.TextBox()
        Me.TBAssetSerial = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TBAssetModel = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TBAssetPlate = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CBAssetSheet = New System.Windows.Forms.ComboBox()
        Me.CBAssetUnit = New System.Windows.Forms.ComboBox()
        Me.CheckBoxTestInvioCloud = New System.Windows.Forms.CheckBox()
        Me.LinkLabelUpdateGRSatList = New System.Windows.Forms.LinkLabel()
        Me.CheckboxCreateDeviceOnGRSat = New System.Windows.Forms.CheckBox()
        Me.DropdownGRSatSelection = New System.Windows.Forms.ComboBox()
        Me.LabelGRSatLoginStatus = New System.Windows.Forms.Label()
        Me.ButtonGRSatLogin = New System.Windows.Forms.Button()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ButtonStorePredictionLogin = New System.Windows.Forms.Button()
        Me.LabelPredictionLoginStatus = New System.Windows.Forms.Label()
        Me.ButtonPredictionLogin = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextboxPredictionPassword = New System.Windows.Forms.TextBox()
        Me.TextboxPredictionHost = New System.Windows.Forms.TextBox()
        Me.TextboxPredictionUsername = New System.Windows.Forms.TextBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.ButtonMongo = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.RBOTGLAST = New System.Windows.Forms.RadioButton()
        Me.RBOTGNOW = New System.Windows.Forms.RadioButton()
        Me.CheckBoxSendMongo = New System.Windows.Forms.CheckBox()
        Me.TabPageTestAutomatici = New System.Windows.Forms.TabPage()
        Me.GroupBoxTelitTest = New System.Windows.Forms.GroupBox()
        Me.LabelTelitSTestStatus = New System.Windows.Forms.Label()
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel()
        Me.TextBoxTelitGPS_Vok = New System.Windows.Forms.TextBox()
        Me.LinkLabel4 = New System.Windows.Forms.LinkLabel()
        Me.TextBoxTelitGPRS_Vok = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.ButtonsStarTelitVTest = New System.Windows.Forms.Button()
        Me.CheckBoxTelitVTest = New System.Windows.Forms.CheckBox()
        Me.GroupBoxGPRSTest = New System.Windows.Forms.GroupBox()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.TextBoxGPRSTestAPN = New System.Windows.Forms.TextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.LabelGPRSTestStatus = New System.Windows.Forms.Label()
        Me.ButtonsStartGPRSTest = New System.Windows.Forms.Button()
        Me.CheckBoxGPRSTest = New System.Windows.Forms.CheckBox()
        Me.TextBoxGPRSTestPin = New System.Windows.Forms.TextBox()
        Me.GroupBoxLEDTest = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ButtonsStartLEDTest = New System.Windows.Forms.Button()
        Me.CheckBoxLEDTest = New System.Windows.Forms.CheckBox()
        Me.GroupBoxRFIDTest = New System.Windows.Forms.GroupBox()
        Me.LinkLabelRFIDTestSetTarget2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabelRFIDTestSetTarget1 = New System.Windows.Forms.LinkLabel()
        Me.LabelRFIDTestStatus = New System.Windows.Forms.Label()
        Me.ButtonsStartRFIDTest = New System.Windows.Forms.Button()
        Me.TextBoxRFIDTestTarget2 = New System.Windows.Forms.TextBox()
        Me.CheckBoxRFIDTest = New System.Windows.Forms.CheckBox()
        Me.TextBoxRFIDTestTarget1 = New System.Windows.Forms.TextBox()
        Me.TabPage9 = New System.Windows.Forms.TabPage()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ButtonCercaDispostivi = New System.Windows.Forms.Button()
        Me.ButtonLoginVecchioPortaleMig = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CheckboxFwEnable125Khz = New System.Windows.Forms.CheckBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PanelPWP = New System.Windows.Forms.Panel()
        Me.LabelPWP_msg = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonPWP_stop = New System.Windows.Forms.Button()
        Me.ProgressBarPWP_total = New System.Windows.Forms.ProgressBar()
        Me.ProgressBarPWP_current = New System.Windows.Forms.ProgressBar()
        Me.CheckBoxAutoUploadSerial = New System.Windows.Forms.CheckBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.ButtonGenerateCloudCode = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.CheckboxFwEnable5Gh = New System.Windows.Forms.CheckBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.LabelMongoStatus = New System.Windows.Forms.Label()
        Me.LinkLabelCancelMongo = New System.Windows.Forms.LinkLabel()
        Me.TabControl3 = New System.Windows.Forms.TabControl()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.ButtonExportCodiciCloud = New System.Windows.Forms.Button()
        Me.ListBoxCodiciCloud = New System.Windows.Forms.ListBox()
        Me.ButtonCLearOldCodiciCloud = New System.Windows.Forms.Button()
        Me.ButtonCollaudo = New System.Windows.Forms.Button()
        Me.CheckboxFwEnableGPSUblox = New System.Windows.Forms.CheckBox()
        Me.CheckBoxJlink = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ButtonGenerateSerialNumber = New System.Windows.Forms.Button()
        Me.ButtonForceAutoNext = New System.Windows.Forms.Button()
        Me.TextboxSerialNumber = New System.Windows.Forms.TextBox()
        Me.CheckBoxPEAK = New System.Windows.Forms.CheckBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBoxHWSetup.SuspendLayout()
        Me.GroupBoxNewValues.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NumericUpDownValoriCount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.DataGridViewRemoteLol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.DataGridViewRemoteLolMinHR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBRX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PBTX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlMigrazione.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBoxGRSatLogin.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.TabPageTestAutomatici.SuspendLayout()
        Me.GroupBoxTelitTest.SuspendLayout()
        Me.GroupBoxGPRSTest.SuspendLayout()
        Me.GroupBoxLEDTest.SuspendLayout()
        Me.GroupBoxRFIDTest.SuspendLayout()
        Me.TabPage9.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.PanelPWP.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.TabControl3.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        Me.SuspendLayout()
        '
        'SerialPort
        '
        Me.SerialPort.BaudRate = 115200
        Me.SerialPort.ReadBufferSize = 8192
        Me.SerialPort.ReadTimeout = 250
        '
        'LPing
        '
        Me.LPing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LPing.AutoSize = True
        Me.LPing.Location = New System.Drawing.Point(44, 454)
        Me.LPing.Name = "LPing"
        Me.LPing.Size = New System.Drawing.Size(0, 13)
        Me.LPing.TabIndex = 67
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(35, 588)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 13)
        Me.Label9.TabIndex = 65
        Me.Label9.Text = "TX"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(87, 588)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(22, 13)
        Me.Label8.TabIndex = 64
        Me.Label8.Text = "RX"
        '
        'TCicloSistema
        '
        Me.TCicloSistema.Interval = 1
        '
        'DropdownComPorts
        '
        Me.DropdownComPorts.FormattingEnabled = True
        Me.DropdownComPorts.Location = New System.Drawing.Point(251, 6)
        Me.DropdownComPorts.Name = "DropdownComPorts"
        Me.DropdownComPorts.Size = New System.Drawing.Size(76, 21)
        Me.DropdownComPorts.TabIndex = 73
        '
        'LCom
        '
        Me.LCom.AutoSize = True
        Me.LCom.Location = New System.Drawing.Point(186, 10)
        Me.LCom.Name = "LCom"
        Me.LCom.Size = New System.Drawing.Size(59, 13)
        Me.LCom.TabIndex = 71
        Me.LCom.Text = "Porta COM"
        '
        'ButtonStart
        '
        Me.ButtonStart.Location = New System.Drawing.Point(12, 36)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(81, 23)
        Me.ButtonStart.TabIndex = 74
        Me.ButtonStart.Text = "Start (F5)"
        Me.ButtonStart.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(422, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "Flashing Bootloader"
        '
        'PBF
        '
        Me.PBF.Location = New System.Drawing.Point(38, 219)
        Me.PBF.Name = "PBF"
        Me.PBF.Size = New System.Drawing.Size(378, 23)
        Me.PBF.TabIndex = 81
        '
        'PBFU
        '
        Me.PBFU.Location = New System.Drawing.Point(181, 248)
        Me.PBFU.Name = "PBFU"
        Me.PBFU.Size = New System.Drawing.Size(235, 23)
        Me.PBFU.TabIndex = 90
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(422, 251)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(65, 13)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Installazione"
        '
        'PBConf
        '
        Me.PBConf.Location = New System.Drawing.Point(181, 277)
        Me.PBConf.Name = "PBConf"
        Me.PBConf.Size = New System.Drawing.Size(234, 23)
        Me.PBConf.TabIndex = 97
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(422, 280)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(133, 13)
        Me.Label11.TabIndex = 98
        Me.Label11.Text = "Configurazione Automatica"
        '
        'PBHR
        '
        Me.PBHR.Location = New System.Drawing.Point(1076, 143)
        Me.PBHR.Name = "PBHR"
        Me.PBHR.Size = New System.Drawing.Size(378, 23)
        Me.PBHR.TabIndex = 99
        Me.PBHR.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(1460, 153)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 100
        Me.Label12.Text = "Test invio HR"
        '
        'LFlashingBootloader
        '
        Me.LFlashingBootloader.AutoSize = True
        Me.LFlashingBootloader.Location = New System.Drawing.Point(560, 222)
        Me.LFlashingBootloader.Name = "LFlashingBootloader"
        Me.LFlashingBootloader.Size = New System.Drawing.Size(83, 13)
        Me.LFlashingBootloader.TabIndex = 102
        Me.LFlashingBootloader.Text = "Test completato"
        Me.LFlashingBootloader.Visible = False
        '
        'LConfigurazioneAutomatica
        '
        Me.LConfigurazioneAutomatica.AutoSize = True
        Me.LConfigurazioneAutomatica.Location = New System.Drawing.Point(560, 280)
        Me.LConfigurazioneAutomatica.Name = "LConfigurazioneAutomatica"
        Me.LConfigurazioneAutomatica.Size = New System.Drawing.Size(83, 13)
        Me.LConfigurazioneAutomatica.TabIndex = 102
        Me.LConfigurazioneAutomatica.Text = "Test completato"
        Me.LConfigurazioneAutomatica.Visible = False
        '
        'LInvioHR
        '
        Me.LInvioHR.AutoSize = True
        Me.LInvioHR.Location = New System.Drawing.Point(1598, 153)
        Me.LInvioHR.Name = "LInvioHR"
        Me.LInvioHR.Size = New System.Drawing.Size(83, 13)
        Me.LInvioHR.TabIndex = 102
        Me.LInvioHR.Text = "Test completato"
        Me.LInvioHR.Visible = False
        '
        'PBGPS
        '
        Me.PBGPS.Location = New System.Drawing.Point(1076, 172)
        Me.PBGPS.Maximum = 4
        Me.PBGPS.Name = "PBGPS"
        Me.PBGPS.Size = New System.Drawing.Size(378, 23)
        Me.PBGPS.TabIndex = 103
        Me.PBGPS.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1460, 182)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 13)
        Me.Label13.TabIndex = 104
        Me.Label13.Text = "Test GPS"
        '
        'LTestGPS
        '
        Me.LTestGPS.AutoSize = True
        Me.LTestGPS.Location = New System.Drawing.Point(1598, 182)
        Me.LTestGPS.Name = "LTestGPS"
        Me.LTestGPS.Size = New System.Drawing.Size(83, 13)
        Me.LTestGPS.TabIndex = 105
        Me.LTestGPS.Text = "Test completato"
        Me.LTestGPS.Visible = False
        '
        'PBAcclrmtr
        '
        Me.PBAcclrmtr.Location = New System.Drawing.Point(1076, 199)
        Me.PBAcclrmtr.Name = "PBAcclrmtr"
        Me.PBAcclrmtr.Size = New System.Drawing.Size(378, 23)
        Me.PBAcclrmtr.TabIndex = 110
        Me.PBAcclrmtr.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1460, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 111
        Me.Label2.Text = "Test Accelerometro"
        '
        'LAccelerometro
        '
        Me.LAccelerometro.AutoSize = True
        Me.LAccelerometro.Location = New System.Drawing.Point(1598, 209)
        Me.LAccelerometro.Name = "LAccelerometro"
        Me.LAccelerometro.Size = New System.Drawing.Size(83, 13)
        Me.LAccelerometro.TabIndex = 112
        Me.LAccelerometro.Text = "Test completato"
        Me.LAccelerometro.Visible = False
        '
        'CheckboxFlashBootloader
        '
        Me.CheckboxFlashBootloader.AutoSize = True
        Me.CheckboxFlashBootloader.Checked = True
        Me.CheckboxFlashBootloader.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxFlashBootloader.Location = New System.Drawing.Point(12, 223)
        Me.CheckboxFlashBootloader.Name = "CheckboxFlashBootloader"
        Me.CheckboxFlashBootloader.Size = New System.Drawing.Size(15, 14)
        Me.CheckboxFlashBootloader.TabIndex = 115
        Me.CheckboxFlashBootloader.UseVisualStyleBackColor = True
        '
        'CheckboxFlashFirmware
        '
        Me.CheckboxFlashFirmware.AutoSize = True
        Me.CheckboxFlashFirmware.Checked = True
        Me.CheckboxFlashFirmware.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxFlashFirmware.Location = New System.Drawing.Point(12, 252)
        Me.CheckboxFlashFirmware.Name = "CheckboxFlashFirmware"
        Me.CheckboxFlashFirmware.Size = New System.Drawing.Size(15, 14)
        Me.CheckboxFlashFirmware.TabIndex = 120
        Me.CheckboxFlashFirmware.UseVisualStyleBackColor = True
        '
        'CheckboxCA
        '
        Me.CheckboxCA.AutoSize = True
        Me.CheckboxCA.Checked = True
        Me.CheckboxCA.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxCA.Location = New System.Drawing.Point(12, 281)
        Me.CheckboxCA.Name = "CheckboxCA"
        Me.CheckboxCA.Size = New System.Drawing.Size(15, 14)
        Me.CheckboxCA.TabIndex = 121
        Me.CheckboxCA.UseVisualStyleBackColor = True
        '
        'CBTestHR
        '
        Me.CBTestHR.AutoSize = True
        Me.CBTestHR.Location = New System.Drawing.Point(1050, 153)
        Me.CBTestHR.Name = "CBTestHR"
        Me.CBTestHR.Size = New System.Drawing.Size(15, 14)
        Me.CBTestHR.TabIndex = 122
        Me.CBTestHR.UseVisualStyleBackColor = True
        Me.CBTestHR.Visible = False
        '
        'CBTestGPS
        '
        Me.CBTestGPS.AutoSize = True
        Me.CBTestGPS.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.CBTestGPS.Location = New System.Drawing.Point(1050, 182)
        Me.CBTestGPS.Name = "CBTestGPS"
        Me.CBTestGPS.Size = New System.Drawing.Size(15, 14)
        Me.CBTestGPS.TabIndex = 123
        Me.CBTestGPS.UseVisualStyleBackColor = True
        Me.CBTestGPS.Visible = False
        '
        'CBTestAccel
        '
        Me.CBTestAccel.AutoSize = True
        Me.CBTestAccel.Location = New System.Drawing.Point(1050, 209)
        Me.CBTestAccel.Name = "CBTestAccel"
        Me.CBTestAccel.Size = New System.Drawing.Size(15, 14)
        Me.CBTestAccel.TabIndex = 124
        Me.CBTestAccel.UseVisualStyleBackColor = True
        Me.CBTestAccel.Visible = False
        '
        'LNomeNuovoFirmware
        '
        Me.LNomeNuovoFirmware.AutoSize = True
        Me.LNomeNuovoFirmware.Location = New System.Drawing.Point(44, 254)
        Me.LNomeNuovoFirmware.Name = "LNomeNuovoFirmware"
        Me.LNomeNuovoFirmware.Size = New System.Drawing.Size(0, 13)
        Me.LNomeNuovoFirmware.TabIndex = 126
        '
        'DropdownDevicesProfiles
        '
        Me.DropdownDevicesProfiles.FormattingEnabled = True
        Me.DropdownDevicesProfiles.Items.AddRange(New Object() {"MDT", "MDC"})
        Me.DropdownDevicesProfiles.Location = New System.Drawing.Point(12, 6)
        Me.DropdownDevicesProfiles.Name = "DropdownDevicesProfiles"
        Me.DropdownDevicesProfiles.Size = New System.Drawing.Size(168, 21)
        Me.DropdownDevicesProfiles.TabIndex = 128
        '
        'CBVidPidSN
        '
        Me.CBVidPidSN.FormattingEnabled = True
        Me.CBVidPidSN.Location = New System.Drawing.Point(369, 6)
        Me.CBVidPidSN.Name = "CBVidPidSN"
        Me.CBVidPidSN.Size = New System.Drawing.Size(334, 21)
        Me.CBVidPidSN.TabIndex = 131
        '
        'TextboxCPSerialNumber
        '
        Me.TextboxCPSerialNumber.Location = New System.Drawing.Point(369, 46)
        Me.TextboxCPSerialNumber.Name = "TextboxCPSerialNumber"
        Me.TextboxCPSerialNumber.Size = New System.Drawing.Size(145, 20)
        Me.TextboxCPSerialNumber.TabIndex = 132
        '
        'TextboxCPProductString
        '
        Me.TextboxCPProductString.Location = New System.Drawing.Point(520, 46)
        Me.TextboxCPProductString.Name = "TextboxCPProductString"
        Me.TextboxCPProductString.Size = New System.Drawing.Size(183, 20)
        Me.TextboxCPProductString.TabIndex = 133
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(366, 30)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(90, 13)
        Me.Label21.TabIndex = 134
        Me.Label21.Text = "CP Serial Number"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(517, 30)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(74, 13)
        Me.Label22.TabIndex = 135
        Me.Label22.Text = "Product String"
        '
        'BSNPS
        '
        Me.BSNPS.Location = New System.Drawing.Point(709, 45)
        Me.BSNPS.Name = "BSNPS"
        Me.BSNPS.Size = New System.Drawing.Size(75, 22)
        Me.BSNPS.TabIndex = 136
        Me.BSNPS.Text = "Save"
        Me.BSNPS.UseVisualStyleBackColor = True
        '
        'PBCalibrazione
        '
        Me.PBCalibrazione.Location = New System.Drawing.Point(1076, 257)
        Me.PBCalibrazione.Maximum = 4
        Me.PBCalibrazione.Name = "PBCalibrazione"
        Me.PBCalibrazione.Size = New System.Drawing.Size(378, 23)
        Me.PBCalibrazione.TabIndex = 137
        Me.PBCalibrazione.Visible = False
        '
        'CBCalibrazione
        '
        Me.CBCalibrazione.AutoSize = True
        Me.CBCalibrazione.Location = New System.Drawing.Point(1050, 265)
        Me.CBCalibrazione.Name = "CBCalibrazione"
        Me.CBCalibrazione.Size = New System.Drawing.Size(15, 14)
        Me.CBCalibrazione.TabIndex = 138
        Me.CBCalibrazione.UseVisualStyleBackColor = True
        Me.CBCalibrazione.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(1460, 266)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(64, 13)
        Me.Label23.TabIndex = 139
        Me.Label23.Text = "Calibrazione"
        '
        'LCalibrazione
        '
        Me.LCalibrazione.AutoSize = True
        Me.LCalibrazione.Location = New System.Drawing.Point(1598, 267)
        Me.LCalibrazione.Name = "LCalibrazione"
        Me.LCalibrazione.Size = New System.Drawing.Size(83, 13)
        Me.LCalibrazione.TabIndex = 140
        Me.LCalibrazione.Text = "Test completato"
        Me.LCalibrazione.Visible = False
        '
        'CheckboxSyncDatetime
        '
        Me.CheckboxSyncDatetime.AutoSize = True
        Me.CheckboxSyncDatetime.Checked = True
        Me.CheckboxSyncDatetime.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxSyncDatetime.Location = New System.Drawing.Point(12, 310)
        Me.CheckboxSyncDatetime.Name = "CheckboxSyncDatetime"
        Me.CheckboxSyncDatetime.Size = New System.Drawing.Size(72, 17)
        Me.CheckboxSyncDatetime.TabIndex = 145
        Me.CheckboxSyncDatetime.Text = "Sinc RTC"
        Me.CheckboxSyncDatetime.UseVisualStyleBackColor = True
        '
        'LSincDataOra
        '
        Me.LSincDataOra.AutoSize = True
        Me.LSincDataOra.Location = New System.Drawing.Point(560, 309)
        Me.LSincDataOra.Name = "LSincDataOra"
        Me.LSincDataOra.Size = New System.Drawing.Size(83, 13)
        Me.LSincDataOra.TabIndex = 147
        Me.LSincDataOra.Text = "Test completato"
        Me.LSincDataOra.Visible = False
        '
        'BAggiornaCP
        '
        Me.BAggiornaCP.Enabled = False
        Me.BAggiornaCP.Location = New System.Drawing.Point(709, 5)
        Me.BAggiornaCP.Name = "BAggiornaCP"
        Me.BAggiornaCP.Size = New System.Drawing.Size(75, 23)
        Me.BAggiornaCP.TabIndex = 148
        Me.BAggiornaCP.Text = "Aggiorna"
        Me.BAggiornaCP.UseVisualStyleBackColor = True
        '
        'ButtonStop
        '
        Me.ButtonStop.Location = New System.Drawing.Point(99, 36)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(95, 23)
        Me.ButtonStop.TabIndex = 149
        Me.ButtonStop.Text = "Stop (Alt+F5)"
        Me.ButtonStop.UseVisualStyleBackColor = True
        '
        'CheckboxWriteSerialNumber
        '
        Me.CheckboxWriteSerialNumber.AutoSize = True
        Me.CheckboxWriteSerialNumber.Checked = True
        Me.CheckboxWriteSerialNumber.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxWriteSerialNumber.Location = New System.Drawing.Point(12, 71)
        Me.CheckboxWriteSerialNumber.Name = "CheckboxWriteSerialNumber"
        Me.CheckboxWriteSerialNumber.Size = New System.Drawing.Size(15, 14)
        Me.CheckboxWriteSerialNumber.TabIndex = 151
        Me.CheckboxWriteSerialNumber.UseVisualStyleBackColor = True
        '
        'CheckboxWriteHardwareCode
        '
        Me.CheckboxWriteHardwareCode.AutoSize = True
        Me.CheckboxWriteHardwareCode.Checked = True
        Me.CheckboxWriteHardwareCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxWriteHardwareCode.Location = New System.Drawing.Point(12, 150)
        Me.CheckboxWriteHardwareCode.Name = "CheckboxWriteHardwareCode"
        Me.CheckboxWriteHardwareCode.Size = New System.Drawing.Size(15, 14)
        Me.CheckboxWriteHardwareCode.TabIndex = 152
        Me.CheckboxWriteHardwareCode.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(145, 150)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(74, 13)
        Me.Label31.TabIndex = 154
        Me.Label31.Text = "Hardware ver."
        '
        'TextboxHardwareCode
        '
        Me.TextboxHardwareCode.Location = New System.Drawing.Point(34, 149)
        Me.TextboxHardwareCode.Name = "TextboxHardwareCode"
        Me.TextboxHardwareCode.Size = New System.Drawing.Size(100, 20)
        Me.TextboxHardwareCode.TabIndex = 153
        '
        'CheckboxWriteGpsVersion
        '
        Me.CheckboxWriteGpsVersion.AutoSize = True
        Me.CheckboxWriteGpsVersion.Location = New System.Drawing.Point(12, 196)
        Me.CheckboxWriteGpsVersion.Name = "CheckboxWriteGpsVersion"
        Me.CheckboxWriteGpsVersion.Size = New System.Drawing.Size(15, 14)
        Me.CheckboxWriteGpsVersion.TabIndex = 155
        Me.CheckboxWriteGpsVersion.UseVisualStyleBackColor = True
        '
        'TBGPSVersion
        '
        Me.TBGPSVersion.Location = New System.Drawing.Point(38, 193)
        Me.TBGPSVersion.Name = "TBGPSVersion"
        Me.TBGPSVersion.Size = New System.Drawing.Size(100, 20)
        Me.TBGPSVersion.TabIndex = 156
        Me.TBGPSVersion.Text = "GSD4E_4.1.2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(145, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 157
        Me.Label3.Text = "Versione GPS"
        '
        'LprodString
        '
        Me.LprodString.AutoSize = True
        Me.LprodString.Location = New System.Drawing.Point(182, 174)
        Me.LprodString.Name = "LprodString"
        Me.LprodString.Size = New System.Drawing.Size(59, 13)
        Me.LprodString.TabIndex = 160
        Me.LprodString.Text = "ProdString:"
        '
        'CheckboxWriteProductString
        '
        Me.CheckboxWriteProductString.AutoSize = True
        Me.CheckboxWriteProductString.Checked = True
        Me.CheckboxWriteProductString.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxWriteProductString.Location = New System.Drawing.Point(12, 174)
        Me.CheckboxWriteProductString.Name = "CheckboxWriteProductString"
        Me.CheckboxWriteProductString.Size = New System.Drawing.Size(168, 17)
        Me.CheckboxWriteProductString.TabIndex = 158
        Me.CheckboxWriteProductString.Text = "Scrivi Prod string con SN/HW"
        Me.CheckboxWriteProductString.UseVisualStyleBackColor = True
        '
        'CheckboxFwEnableModGps
        '
        Me.CheckboxFwEnableModGps.AutoSize = True
        Me.CheckboxFwEnableModGps.Location = New System.Drawing.Point(489, 174)
        Me.CheckboxFwEnableModGps.Name = "CheckboxFwEnableModGps"
        Me.CheckboxFwEnableModGps.Size = New System.Drawing.Size(74, 17)
        Me.CheckboxFwEnableModGps.TabIndex = 161
        Me.CheckboxFwEnableModGps.Text = "GPS mod."
        Me.CheckboxFwEnableModGps.UseVisualStyleBackColor = True
        '
        'CheckboxFwEnableModSD
        '
        Me.CheckboxFwEnableModSD.AutoSize = True
        Me.CheckboxFwEnableModSD.Location = New System.Drawing.Point(327, 168)
        Me.CheckboxFwEnableModSD.Name = "CheckboxFwEnableModSD"
        Me.CheckboxFwEnableModSD.Size = New System.Drawing.Size(67, 17)
        Me.CheckboxFwEnableModSD.TabIndex = 161
        Me.CheckboxFwEnableModSD.Text = "SD mod."
        Me.CheckboxFwEnableModSD.UseVisualStyleBackColor = True
        '
        'ButtonUpdateFile
        '
        Me.ButtonUpdateFile.BackgroundImage = Global.FlashedLOL.My.Resources.Res.cloud_down
        Me.ButtonUpdateFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ButtonUpdateFile.Location = New System.Drawing.Point(624, 590)
        Me.ButtonUpdateFile.Name = "ButtonUpdateFile"
        Me.ButtonUpdateFile.Size = New System.Drawing.Size(40, 26)
        Me.ButtonUpdateFile.TabIndex = 162
        Me.ToolTip.SetToolTip(Me.ButtonUpdateFile, "Cerca file aggiornati sul server")
        Me.ButtonUpdateFile.UseVisualStyleBackColor = True
        Me.ButtonUpdateFile.Visible = False
        '
        'CheckBoxAutoUSB_SET
        '
        Me.CheckBoxAutoUSB_SET.AutoSize = True
        Me.CheckBoxAutoUSB_SET.Location = New System.Drawing.Point(587, 596)
        Me.CheckBoxAutoUSB_SET.Name = "CheckBoxAutoUSB_SET"
        Me.CheckBoxAutoUSB_SET.Size = New System.Drawing.Size(15, 14)
        Me.CheckBoxAutoUSB_SET.TabIndex = 163
        Me.CheckBoxAutoUSB_SET.UseVisualStyleBackColor = True
        Me.CheckBoxAutoUSB_SET.Visible = False
        '
        'ListBoxSeriali
        '
        Me.ListBoxSeriali.FormattingEnabled = True
        Me.ListBoxSeriali.Location = New System.Drawing.Point(1, 3)
        Me.ListBoxSeriali.Name = "ListBoxSeriali"
        Me.ListBoxSeriali.Size = New System.Drawing.Size(132, 108)
        Me.ListBoxSeriali.TabIndex = 164
        '
        'ButtonCLearOldSerial
        '
        Me.ButtonCLearOldSerial.Location = New System.Drawing.Point(139, 3)
        Me.ButtonCLearOldSerial.Name = "ButtonCLearOldSerial"
        Me.ButtonCLearOldSerial.Size = New System.Drawing.Size(71, 37)
        Me.ButtonCLearOldSerial.TabIndex = 167
        Me.ButtonCLearOldSerial.Text = "<--Cancella"
        Me.ButtonCLearOldSerial.UseVisualStyleBackColor = True
        '
        'CheckboxHwEnableWifi
        '
        Me.CheckboxHwEnableWifi.AutoSize = True
        Me.CheckboxHwEnableWifi.Location = New System.Drawing.Point(184, 22)
        Me.CheckboxHwEnableWifi.Name = "CheckboxHwEnableWifi"
        Me.CheckboxHwEnableWifi.Size = New System.Drawing.Size(47, 17)
        Me.CheckboxHwEnableWifi.TabIndex = 169
        Me.CheckboxHwEnableWifi.Text = "WiFi"
        Me.CheckboxHwEnableWifi.UseVisualStyleBackColor = True
        '
        'CheckboxHwEnableGPRS
        '
        Me.CheckboxHwEnableGPRS.AutoSize = True
        Me.CheckboxHwEnableGPRS.Checked = True
        Me.CheckboxHwEnableGPRS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxHwEnableGPRS.Location = New System.Drawing.Point(56, 22)
        Me.CheckboxHwEnableGPRS.Name = "CheckboxHwEnableGPRS"
        Me.CheckboxHwEnableGPRS.Size = New System.Drawing.Size(56, 17)
        Me.CheckboxHwEnableGPRS.TabIndex = 169
        Me.CheckboxHwEnableGPRS.Text = "GPRS"
        Me.CheckboxHwEnableGPRS.UseVisualStyleBackColor = True
        '
        'CheckboxHwEnableGPS
        '
        Me.CheckboxHwEnableGPS.AutoSize = True
        Me.CheckboxHwEnableGPS.Location = New System.Drawing.Point(124, 22)
        Me.CheckboxHwEnableGPS.Name = "CheckboxHwEnableGPS"
        Me.CheckboxHwEnableGPS.Size = New System.Drawing.Size(48, 17)
        Me.CheckboxHwEnableGPS.TabIndex = 169
        Me.CheckboxHwEnableGPS.Text = "GPS"
        Me.CheckboxHwEnableGPS.UseVisualStyleBackColor = True
        '
        'CheckboxHwEnableSD
        '
        Me.CheckboxHwEnableSD.AutoSize = True
        Me.CheckboxHwEnableSD.Checked = True
        Me.CheckboxHwEnableSD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxHwEnableSD.Location = New System.Drawing.Point(6, 22)
        Me.CheckboxHwEnableSD.Name = "CheckboxHwEnableSD"
        Me.CheckboxHwEnableSD.Size = New System.Drawing.Size(41, 17)
        Me.CheckboxHwEnableSD.TabIndex = 169
        Me.CheckboxHwEnableSD.Text = "SD"
        Me.CheckboxHwEnableSD.UseVisualStyleBackColor = True
        '
        'GroupBoxHWSetup
        '
        Me.GroupBoxHWSetup.Controls.Add(Me.CheckboxHwEnableCartellino)
        Me.GroupBoxHWSetup.Controls.Add(Me.CheckboxHwEnableSD)
        Me.GroupBoxHWSetup.Controls.Add(Me.CheckboxHwEnableWifi)
        Me.GroupBoxHWSetup.Controls.Add(Me.CheckboxHwEnableGPS)
        Me.GroupBoxHWSetup.Controls.Add(Me.CheckboxHwEnableGPRS)
        Me.GroupBoxHWSetup.Controls.Add(Me.LabelHwSetup)
        Me.GroupBoxHWSetup.Controls.Add(Me.CheckboxHWSetup)
        Me.GroupBoxHWSetup.Location = New System.Drawing.Point(433, 97)
        Me.GroupBoxHWSetup.Name = "GroupBoxHWSetup"
        Me.GroupBoxHWSetup.Size = New System.Drawing.Size(351, 49)
        Me.GroupBoxHWSetup.TabIndex = 170
        Me.GroupBoxHWSetup.TabStop = False
        Me.GroupBoxHWSetup.Text = "HW Setup"
        '
        'CheckboxHwEnableCartellino
        '
        Me.CheckboxHwEnableCartellino.AutoSize = True
        Me.CheckboxHwEnableCartellino.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckboxHwEnableCartellino.Location = New System.Drawing.Point(244, 21)
        Me.CheckboxHwEnableCartellino.Name = "CheckboxHwEnableCartellino"
        Me.CheckboxHwEnableCartellino.Size = New System.Drawing.Size(79, 17)
        Me.CheckboxHwEnableCartellino.TabIndex = 179
        Me.CheckboxHwEnableCartellino.Text = "Cartellino"
        Me.CheckboxHwEnableCartellino.UseVisualStyleBackColor = True
        '
        'LabelHwSetup
        '
        Me.LabelHwSetup.AutoSize = True
        Me.LabelHwSetup.Location = New System.Drawing.Point(90, 1)
        Me.LabelHwSetup.Name = "LabelHwSetup"
        Me.LabelHwSetup.Size = New System.Drawing.Size(25, 13)
        Me.LabelHwSetup.TabIndex = 172
        Me.LabelHwSetup.Text = "???"
        '
        'CheckboxHWSetup
        '
        Me.CheckboxHWSetup.AutoSize = True
        Me.CheckboxHWSetup.Location = New System.Drawing.Point(69, 0)
        Me.CheckboxHWSetup.Name = "CheckboxHWSetup"
        Me.CheckboxHWSetup.Size = New System.Drawing.Size(15, 14)
        Me.CheckboxHWSetup.TabIndex = 171
        Me.CheckboxHWSetup.UseVisualStyleBackColor = True
        '
        'CheckBoxHWSetupMoved
        '
        Me.CheckBoxHWSetupMoved.AutoSize = True
        Me.CheckBoxHWSetupMoved.Checked = True
        Me.CheckBoxHWSetupMoved.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxHWSetupMoved.Location = New System.Drawing.Point(6, 14)
        Me.CheckBoxHWSetupMoved.Name = "CheckBoxHWSetupMoved"
        Me.CheckBoxHWSetupMoved.Size = New System.Drawing.Size(140, 17)
        Me.CheckBoxHWSetupMoved.TabIndex = 178
        Me.CheckBoxHWSetupMoved.Text = "Versione ETS >= 0309A"
        Me.CheckBoxHWSetupMoved.UseVisualStyleBackColor = True
        '
        'CheckboxFwEnableKbd
        '
        Me.CheckboxFwEnableKbd.AutoSize = True
        Me.CheckboxFwEnableKbd.Location = New System.Drawing.Point(617, 150)
        Me.CheckboxFwEnableKbd.Name = "CheckboxFwEnableKbd"
        Me.CheckboxFwEnableKbd.Size = New System.Drawing.Size(48, 17)
        Me.CheckboxFwEnableKbd.TabIndex = 169
        Me.CheckboxFwEnableKbd.Text = "KBD"
        Me.CheckboxFwEnableKbd.UseVisualStyleBackColor = True
        '
        'CheckboxFwEnableFps
        '
        Me.CheckboxFwEnableFps.AutoSize = True
        Me.CheckboxFwEnableFps.Location = New System.Drawing.Point(617, 174)
        Me.CheckboxFwEnableFps.Name = "CheckboxFwEnableFps"
        Me.CheckboxFwEnableFps.Size = New System.Drawing.Size(46, 17)
        Me.CheckboxFwEnableFps.TabIndex = 169
        Me.CheckboxFwEnableFps.Text = "FPS"
        Me.CheckboxFwEnableFps.UseVisualStyleBackColor = True
        '
        'LabelStatus
        '
        Me.LabelStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Location = New System.Drawing.Point(220, 476)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(0, 13)
        Me.LabelStatus.TabIndex = 174
        '
        'LabelAction
        '
        Me.LabelAction.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelAction.AutoSize = True
        Me.LabelAction.Location = New System.Drawing.Point(220, 454)
        Me.LabelAction.Name = "LabelAction"
        Me.LabelAction.Size = New System.Drawing.Size(0, 13)
        Me.LabelAction.TabIndex = 175
        '
        'CheckBoxCAN
        '
        Me.CheckBoxCAN.AutoSize = True
        Me.CheckBoxCAN.Location = New System.Drawing.Point(251, 29)
        Me.CheckBoxCAN.Name = "CheckBoxCAN"
        Me.CheckBoxCAN.Size = New System.Drawing.Size(48, 17)
        Me.CheckBoxCAN.TabIndex = 176
        Me.CheckBoxCAN.Text = "CAN"
        Me.CheckBoxCAN.UseVisualStyleBackColor = True
        '
        'TextBoxNodoCAN
        '
        Me.TextBoxNodoCAN.Enabled = False
        Me.TextBoxNodoCAN.Location = New System.Drawing.Point(299, 27)
        Me.TextBoxNodoCAN.Name = "TextBoxNodoCAN"
        Me.TextBoxNodoCAN.Size = New System.Drawing.Size(28, 20)
        Me.TextBoxNodoCAN.TabIndex = 177
        '
        'LBVersioneHW
        '
        Me.LBVersioneHW.AutoSize = True
        Me.LBVersioneHW.Location = New System.Drawing.Point(220, 150)
        Me.LBVersioneHW.Name = "LBVersioneHW"
        Me.LBVersioneHW.Size = New System.Drawing.Size(49, 13)
        Me.LBVersioneHW.TabIndex = 172
        Me.LBVersioneHW.Text = "???????"
        '
        'CBOTG
        '
        Me.CBOTG.AutoSize = True
        Me.CBOTG.Location = New System.Drawing.Point(6, 19)
        Me.CBOTG.Name = "CBOTG"
        Me.CBOTG.Size = New System.Drawing.Size(15, 14)
        Me.CBOTG.TabIndex = 178
        Me.CBOTG.UseVisualStyleBackColor = True
        '
        'ProgressBarOTG
        '
        Me.ProgressBarOTG.Location = New System.Drawing.Point(6, 42)
        Me.ProgressBarOTG.Maximum = 1
        Me.ProgressBarOTG.Name = "ProgressBarOTG"
        Me.ProgressBarOTG.Size = New System.Drawing.Size(162, 23)
        Me.ProgressBarOTG.TabIndex = 179
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(479, 590)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(98, 13)
        Me.Label6.TabIndex = 180
        Me.Label6.Text = "Add parametri OTG"
        Me.Label6.Visible = False
        '
        'TextBoxOTGPAth
        '
        Me.TextBoxOTGPAth.Location = New System.Drawing.Point(32, 16)
        Me.TextBoxOTGPAth.Name = "TextBoxOTGPAth"
        Me.TextBoxOTGPAth.Size = New System.Drawing.Size(136, 20)
        Me.TextBoxOTGPAth.TabIndex = 181
        '
        'ComboBoxConf
        '
        Me.ComboBoxConf.FormattingEnabled = True
        Me.ComboBoxConf.Items.AddRange(New Object() {"MDT", "MDC"})
        Me.ComboBoxConf.Location = New System.Drawing.Point(38, 277)
        Me.ComboBoxConf.Name = "ComboBoxConf"
        Me.ComboBoxConf.Size = New System.Drawing.Size(136, 21)
        Me.ComboBoxConf.TabIndex = 182
        '
        'CheckBoxInitETS
        '
        Me.CheckBoxInitETS.AutoSize = True
        Me.CheckBoxInitETS.Checked = True
        Me.CheckBoxInitETS.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxInitETS.Location = New System.Drawing.Point(493, 249)
        Me.CheckBoxInitETS.Name = "CheckBoxInitETS"
        Me.CheckBoxInitETS.Size = New System.Drawing.Size(116, 17)
        Me.CheckBoxInitETS.TabIndex = 183
        Me.CheckBoxInitETS.Text = "Inizializza parametri"
        Me.CheckBoxInitETS.UseVisualStyleBackColor = True
        '
        'PBSincDataOra
        '
        Me.PBSincDataOra.Location = New System.Drawing.Point(181, 306)
        Me.PBSincDataOra.Maximum = 1
        Me.PBSincDataOra.Name = "PBSincDataOra"
        Me.PBSincDataOra.Size = New System.Drawing.Size(234, 23)
        Me.PBSincDataOra.TabIndex = 144
        '
        'CheckboxFormatSD
        '
        Me.CheckboxFormatSD.AutoSize = True
        Me.CheckboxFormatSD.Checked = True
        Me.CheckboxFormatSD.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxFormatSD.Location = New System.Drawing.Point(90, 310)
        Me.CheckboxFormatSD.Name = "CheckboxFormatSD"
        Me.CheckboxFormatSD.Size = New System.Drawing.Size(76, 17)
        Me.CheckboxFormatSD.TabIndex = 184
        Me.CheckboxFormatSD.Text = "Format SD"
        Me.CheckboxFormatSD.UseVisualStyleBackColor = True
        '
        'CheckboxWriteCloudCode
        '
        Me.CheckboxWriteCloudCode.AutoSize = True
        Me.CheckboxWriteCloudCode.Checked = True
        Me.CheckboxWriteCloudCode.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckboxWriteCloudCode.Location = New System.Drawing.Point(5, 12)
        Me.CheckboxWriteCloudCode.Name = "CheckboxWriteCloudCode"
        Me.CheckboxWriteCloudCode.Size = New System.Drawing.Size(100, 17)
        Me.CheckboxWriteCloudCode.TabIndex = 185
        Me.CheckboxWriteCloudCode.Text = "Cloud code-pw:"
        Me.CheckboxWriteCloudCode.UseVisualStyleBackColor = True
        '
        'TextboxCloudCode
        '
        Me.TextboxCloudCode.Location = New System.Drawing.Point(109, 12)
        Me.TextboxCloudCode.Name = "TextboxCloudCode"
        Me.TextboxCloudCode.Size = New System.Drawing.Size(75, 20)
        Me.TextboxCloudCode.TabIndex = 186
        '
        'TextBoxCloudPw
        '
        Me.TextBoxCloudPw.Location = New System.Drawing.Point(188, 12)
        Me.TextBoxCloudPw.Name = "TextBoxCloudPw"
        Me.TextBoxCloudPw.Size = New System.Drawing.Size(46, 20)
        Me.TextBoxCloudPw.TabIndex = 187
        Me.TextBoxCloudPw.Text = "12345"
        '
        'CheckBoxSerialAnagrafica
        '
        Me.CheckBoxSerialAnagrafica.AutoSize = True
        Me.CheckBoxSerialAnagrafica.Checked = True
        Me.CheckBoxSerialAnagrafica.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxSerialAnagrafica.Location = New System.Drawing.Point(429, 70)
        Me.CheckBoxSerialAnagrafica.Name = "CheckBoxSerialAnagrafica"
        Me.CheckBoxSerialAnagrafica.Size = New System.Drawing.Size(140, 17)
        Me.CheckBoxSerialAnagrafica.TabIndex = 188
        Me.CheckBoxSerialAnagrafica.Text = "Anagrafica con prefisso:"
        Me.CheckBoxSerialAnagrafica.UseVisualStyleBackColor = True
        '
        'GroupBoxNewValues
        '
        Me.GroupBoxNewValues.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBoxNewValues.Controls.Add(Me.Panel1)
        Me.GroupBoxNewValues.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBoxNewValues.Location = New System.Drawing.Point(6, 49)
        Me.GroupBoxNewValues.Name = "GroupBoxNewValues"
        Me.GroupBoxNewValues.Size = New System.Drawing.Size(980, 134)
        Me.GroupBoxNewValues.TabIndex = 191
        Me.GroupBoxNewValues.TabStop = False
        Me.GroupBoxNewValues.Text = "COMANDO -- OFFSET -- VALORE"
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.FlowLayoutPanelSerializza)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanelComando)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanelValue)
        Me.Panel1.Controls.Add(Me.FlowLayoutPanelOffset)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(974, 115)
        Me.Panel1.TabIndex = 11
        '
        'FlowLayoutPanelSerializza
        '
        Me.FlowLayoutPanelSerializza.AutoSize = True
        Me.FlowLayoutPanelSerializza.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanelSerializza.Location = New System.Drawing.Point(317, 0)
        Me.FlowLayoutPanelSerializza.Name = "FlowLayoutPanelSerializza"
        Me.FlowLayoutPanelSerializza.Size = New System.Drawing.Size(106, 105)
        Me.FlowLayoutPanelSerializza.TabIndex = 3
        Me.FlowLayoutPanelSerializza.WrapContents = False
        '
        'FlowLayoutPanelComando
        '
        Me.FlowLayoutPanelComando.AutoSize = True
        Me.FlowLayoutPanelComando.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanelComando.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanelComando.Name = "FlowLayoutPanelComando"
        Me.FlowLayoutPanelComando.Size = New System.Drawing.Size(106, 105)
        Me.FlowLayoutPanelComando.TabIndex = 2
        Me.FlowLayoutPanelComando.WrapContents = False
        '
        'FlowLayoutPanelValue
        '
        Me.FlowLayoutPanelValue.AutoSize = True
        Me.FlowLayoutPanelValue.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanelValue.Location = New System.Drawing.Point(211, 0)
        Me.FlowLayoutPanelValue.Name = "FlowLayoutPanelValue"
        Me.FlowLayoutPanelValue.Size = New System.Drawing.Size(106, 105)
        Me.FlowLayoutPanelValue.TabIndex = 1
        Me.FlowLayoutPanelValue.WrapContents = False
        '
        'FlowLayoutPanelOffset
        '
        Me.FlowLayoutPanelOffset.AutoSize = True
        Me.FlowLayoutPanelOffset.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanelOffset.Location = New System.Drawing.Point(106, 0)
        Me.FlowLayoutPanelOffset.Name = "FlowLayoutPanelOffset"
        Me.FlowLayoutPanelOffset.Size = New System.Drawing.Size(105, 105)
        Me.FlowLayoutPanelOffset.TabIndex = 0
        Me.FlowLayoutPanelOffset.WrapContents = False
        '
        'Labelquest
        '
        Me.Labelquest.AutoSize = True
        Me.Labelquest.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Labelquest.Location = New System.Drawing.Point(44, 23)
        Me.Labelquest.Name = "Labelquest"
        Me.Labelquest.Size = New System.Drawing.Size(90, 13)
        Me.Labelquest.TabIndex = 190
        Me.Labelquest.Text = "Quanti parametri?"
        '
        'NumericUpDownValoriCount
        '
        Me.NumericUpDownValoriCount.Location = New System.Drawing.Point(140, 19)
        Me.NumericUpDownValoriCount.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.NumericUpDownValoriCount.Name = "NumericUpDownValoriCount"
        Me.NumericUpDownValoriCount.Size = New System.Drawing.Size(40, 20)
        Me.NumericUpDownValoriCount.TabIndex = 189
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonDivineETSSetUser)
        Me.GroupBox1.Controls.Add(Me.ButtonDivineETSDNAssoc)
        Me.GroupBox1.Controls.Add(Me.ButtonDivineETSCANBaudSet)
        Me.GroupBox1.Controls.Add(Me.ButtonBLERP0)
        Me.GroupBox1.Controls.Add(Me.ButtonBLESETId)
        Me.GroupBox1.Controls.Add(Me.ButtonUpdateWiFly)
        Me.GroupBox1.Controls.Add(Me.ButtonReadWiFly)
        Me.GroupBox1.Controls.Add(Me.Labelquest)
        Me.GroupBox1.Controls.Add(Me.GroupBoxNewValues)
        Me.GroupBox1.Controls.Add(Me.NumericUpDownValoriCount)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(986, 189)
        Me.GroupBox1.TabIndex = 192
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FUNZIONE DIVINA"
        '
        'ButtonDivineETSSetUser
        '
        Me.ButtonDivineETSSetUser.Location = New System.Drawing.Point(834, 9)
        Me.ButtonDivineETSSetUser.Name = "ButtonDivineETSSetUser"
        Me.ButtonDivineETSSetUser.Size = New System.Drawing.Size(103, 23)
        Me.ButtonDivineETSSetUser.TabIndex = 197
        Me.ButtonDivineETSSetUser.Text = "Aggiungi utente"
        Me.ButtonDivineETSSetUser.UseVisualStyleBackColor = True
        '
        'ButtonDivineETSDNAssoc
        '
        Me.ButtonDivineETSDNAssoc.Location = New System.Drawing.Point(724, 29)
        Me.ButtonDivineETSDNAssoc.Name = "ButtonDivineETSDNAssoc"
        Me.ButtonDivineETSDNAssoc.Size = New System.Drawing.Size(103, 23)
        Me.ButtonDivineETSDNAssoc.TabIndex = 196
        Me.ButtonDivineETSDNAssoc.Text = "Associa ETSDN"
        Me.ButtonDivineETSDNAssoc.UseVisualStyleBackColor = True
        '
        'ButtonDivineETSCANBaudSet
        '
        Me.ButtonDivineETSCANBaudSet.Location = New System.Drawing.Point(724, 9)
        Me.ButtonDivineETSCANBaudSet.Name = "ButtonDivineETSCANBaudSet"
        Me.ButtonDivineETSCANBaudSet.Size = New System.Drawing.Size(103, 23)
        Me.ButtonDivineETSCANBaudSet.TabIndex = 196
        Me.ButtonDivineETSCANBaudSet.Text = "Set CAN baud"
        Me.ButtonDivineETSCANBaudSet.UseVisualStyleBackColor = True
        '
        'ButtonBLERP0
        '
        Me.ButtonBLERP0.Location = New System.Drawing.Point(615, 29)
        Me.ButtonBLERP0.Name = "ButtonBLERP0"
        Me.ButtonBLERP0.Size = New System.Drawing.Size(103, 23)
        Me.ButtonBLERP0.TabIndex = 195
        Me.ButtonBLERP0.Text = "Termina conf."
        Me.ButtonBLERP0.UseVisualStyleBackColor = True
        '
        'ButtonBLESETId
        '
        Me.ButtonBLESETId.Location = New System.Drawing.Point(615, 9)
        Me.ButtonBLESETId.Name = "ButtonBLESETId"
        Me.ButtonBLESETId.Size = New System.Drawing.Size(103, 23)
        Me.ButtonBLESETId.TabIndex = 194
        Me.ButtonBLESETId.Text = "Set ID"
        Me.ButtonBLESETId.UseVisualStyleBackColor = True
        '
        'ButtonUpdateWiFly
        '
        Me.ButtonUpdateWiFly.Location = New System.Drawing.Point(506, 29)
        Me.ButtonUpdateWiFly.Name = "ButtonUpdateWiFly"
        Me.ButtonUpdateWiFly.Size = New System.Drawing.Size(103, 23)
        Me.ButtonUpdateWiFly.TabIndex = 193
        Me.ButtonUpdateWiFly.Text = "Update WiFly"
        Me.ButtonUpdateWiFly.UseVisualStyleBackColor = True
        '
        'ButtonReadWiFly
        '
        Me.ButtonReadWiFly.Location = New System.Drawing.Point(506, 9)
        Me.ButtonReadWiFly.Name = "ButtonReadWiFly"
        Me.ButtonReadWiFly.Size = New System.Drawing.Size(103, 23)
        Me.ButtonReadWiFly.TabIndex = 192
        Me.ButtonReadWiFly.Text = "Get WiFly ver."
        Me.ButtonReadWiFly.UseVisualStyleBackColor = True
        '
        'TextBoxAnalPrefix
        '
        Me.TextBoxAnalPrefix.Location = New System.Drawing.Point(359, 68)
        Me.TextBoxAnalPrefix.Name = "TextBoxAnalPrefix"
        Me.TextBoxAnalPrefix.Size = New System.Drawing.Size(64, 20)
        Me.TextBoxAnalPrefix.TabIndex = 193
        Me.TextBoxAnalPrefix.Text = "ETS_"
        '
        'LabelFwVersions
        '
        Me.LabelFwVersions.AutoSize = True
        Me.LabelFwVersions.Location = New System.Drawing.Point(250, 147)
        Me.LabelFwVersions.Name = "LabelFwVersions"
        Me.LabelFwVersions.Size = New System.Drawing.Size(0, 13)
        Me.LabelFwVersions.TabIndex = 194
        '
        'LabelWaitForMDT
        '
        Me.LabelWaitForMDT.AutoSize = True
        Me.LabelWaitForMDT.ForeColor = System.Drawing.Color.Red
        Me.LabelWaitForMDT.Location = New System.Drawing.Point(663, 266)
        Me.LabelWaitForMDT.Name = "LabelWaitForMDT"
        Me.LabelWaitForMDT.Size = New System.Drawing.Size(0, 13)
        Me.LabelWaitForMDT.TabIndex = 195
        '
        'CheckboxFwEnableTouch
        '
        Me.CheckboxFwEnableTouch.AutoSize = True
        Me.CheckboxFwEnableTouch.Location = New System.Drawing.Point(327, 93)
        Me.CheckboxFwEnableTouch.Name = "CheckboxFwEnableTouch"
        Me.CheckboxFwEnableTouch.Size = New System.Drawing.Size(57, 17)
        Me.CheckboxFwEnableTouch.TabIndex = 196
        Me.CheckboxFwEnableTouch.Text = "Touch"
        Me.CheckboxFwEnableTouch.UseVisualStyleBackColor = True
        '
        'CheckBoxHack
        '
        Me.CheckBoxHack.AutoSize = True
        Me.CheckBoxHack.Location = New System.Drawing.Point(6, 37)
        Me.CheckBoxHack.Name = "CheckBoxHack"
        Me.CheckBoxHack.Size = New System.Drawing.Size(230, 17)
        Me.CheckBoxHack.TabIndex = 197
        Me.CheckBoxHack.Text = "Non mandare nel boot durante installazione"
        Me.CheckBoxHack.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.TabControl2)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(986, 186)
        Me.GroupBox2.TabIndex = 198
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "REMOTE LOL"
        '
        'TabControl2
        '
        Me.TabControl2.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.TabControl2.Controls.Add(Me.TabPage5)
        Me.TabControl2.Controls.Add(Me.TabPage6)
        Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl2.Location = New System.Drawing.Point(3, 16)
        Me.TabControl2.Multiline = True
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(980, 167)
        Me.TabControl2.TabIndex = 217
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.DataGridViewRemoteLol)
        Me.TabPage5.Location = New System.Drawing.Point(4, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(972, 141)
        Me.TabPage5.TabIndex = 0
        Me.TabPage5.Text = "Istanze remote in vista"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'DataGridViewRemoteLol
        '
        Me.DataGridViewRemoteLol.AllowUserToAddRows = False
        Me.DataGridViewRemoteLol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridViewRemoteLol.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewRemoteLol.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewRemoteLol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewRemoteLol.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.IP, Me.IsMaster, Me.Status, Me.ConfirmedDevice, Me.ConfirmedHW, Me.ConfirmedSerial, Me.CurrentSerial, Me.NeedsNewSerial, Me.ConfirmedEtichettaData, Me.LastSeen})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRemoteLol.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewRemoteLol.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewRemoteLol.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewRemoteLol.Name = "DataGridViewRemoteLol"
        Me.DataGridViewRemoteLol.RowHeadersVisible = False
        Me.DataGridViewRemoteLol.RowHeadersWidth = 51
        Me.DataGridViewRemoteLol.Size = New System.Drawing.Size(966, 135)
        Me.DataGridViewRemoteLol.TabIndex = 201
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.MinimumWidth = 6
        Me.ID.Name = "ID"
        Me.ID.Width = 43
        '
        'IP
        '
        Me.IP.HeaderText = "IP"
        Me.IP.MinimumWidth = 6
        Me.IP.Name = "IP"
        Me.IP.Visible = False
        Me.IP.Width = 42
        '
        'IsMaster
        '
        Me.IsMaster.HeaderText = "Master"
        Me.IsMaster.MinimumWidth = 6
        Me.IsMaster.Name = "IsMaster"
        Me.IsMaster.Width = 64
        '
        'Status
        '
        Me.Status.HeaderText = "Status"
        Me.Status.MinimumWidth = 6
        Me.Status.Name = "Status"
        Me.Status.Width = 62
        '
        'ConfirmedDevice
        '
        Me.ConfirmedDevice.HeaderText = "Confirmed Device"
        Me.ConfirmedDevice.MinimumWidth = 6
        Me.ConfirmedDevice.Name = "ConfirmedDevice"
        Me.ConfirmedDevice.Width = 106
        '
        'ConfirmedHW
        '
        Me.ConfirmedHW.HeaderText = "Confirmed HW"
        Me.ConfirmedHW.MinimumWidth = 6
        Me.ConfirmedHW.Name = "ConfirmedHW"
        Me.ConfirmedHW.Width = 93
        '
        'ConfirmedSerial
        '
        Me.ConfirmedSerial.HeaderText = "Confirmed Serial"
        Me.ConfirmedSerial.MinimumWidth = 6
        Me.ConfirmedSerial.Name = "ConfirmedSerial"
        Me.ConfirmedSerial.Width = 99
        '
        'CurrentSerial
        '
        Me.CurrentSerial.HeaderText = "Current serial"
        Me.CurrentSerial.MinimumWidth = 6
        Me.CurrentSerial.Name = "CurrentSerial"
        Me.CurrentSerial.Visible = False
        Me.CurrentSerial.Width = 86
        '
        'NeedsNewSerial
        '
        Me.NeedsNewSerial.HeaderText = "Wants new serial"
        Me.NeedsNewSerial.MinimumWidth = 6
        Me.NeedsNewSerial.Name = "NeedsNewSerial"
        Me.NeedsNewSerial.Width = 82
        '
        'ConfirmedEtichettaData
        '
        Me.ConfirmedEtichettaData.HeaderText = "Label data"
        Me.ConfirmedEtichettaData.MinimumWidth = 6
        Me.ConfirmedEtichettaData.Name = "ConfirmedEtichettaData"
        Me.ConfirmedEtichettaData.Visible = False
        Me.ConfirmedEtichettaData.Width = 76
        '
        'LastSeen
        '
        Me.LastSeen.HeaderText = "Last seen"
        Me.LastSeen.MinimumWidth = 6
        Me.LastSeen.Name = "LastSeen"
        Me.LastSeen.Visible = False
        Me.LastSeen.Width = 72
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.DataGridViewRemoteLolMinHR)
        Me.TabPage6.Location = New System.Drawing.Point(4, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(972, 141)
        Me.TabPage6.TabIndex = 1
        Me.TabPage6.Text = "Mini Heart Rate"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'DataGridViewRemoteLolMinHR
        '
        Me.DataGridViewRemoteLolMinHR.AllowUserToAddRows = False
        Me.DataGridViewRemoteLolMinHR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.DataGridViewRemoteLolMinHR.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewRemoteLolMinHR.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewRemoteLolMinHR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewRemoteLolMinHR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn11, Me.Column1, Me.Column2})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewRemoteLolMinHR.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewRemoteLolMinHR.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewRemoteLolMinHR.Location = New System.Drawing.Point(3, 3)
        Me.DataGridViewRemoteLolMinHR.Name = "DataGridViewRemoteLolMinHR"
        Me.DataGridViewRemoteLolMinHR.RowHeadersVisible = False
        Me.DataGridViewRemoteLolMinHR.RowHeadersWidth = 51
        Me.DataGridViewRemoteLolMinHR.Size = New System.Drawing.Size(966, 135)
        Me.DataGridViewRemoteLolMinHR.TabIndex = 202
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 43
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.HeaderText = "PC"
        Me.DataGridViewTextBoxColumn11.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Width = 46
        '
        'Column1
        '
        Me.Column1.HeaderText = "Utente"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 64
        '
        'Column2
        '
        Me.Column2.HeaderText = "Last seen"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 78
        '
        'CheckBoxDivineSync
        '
        Me.CheckBoxDivineSync.AutoSize = True
        Me.CheckBoxDivineSync.Location = New System.Drawing.Point(9, 6)
        Me.CheckBoxDivineSync.Name = "CheckBoxDivineSync"
        Me.CheckBoxDivineSync.Size = New System.Drawing.Size(96, 17)
        Me.CheckBoxDivineSync.TabIndex = 199
        Me.CheckBoxDivineSync.Text = "Attiva funzione"
        Me.CheckBoxDivineSync.UseVisualStyleBackColor = True
        '
        'PBRX
        '
        Me.PBRX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PBRX.BackgroundImage = Global.FlashedLOL.My.Resources.Res.pallina_grigia
        Me.PBRX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PBRX.Location = New System.Drawing.Point(64, 583)
        Me.PBRX.Name = "PBRX"
        Me.PBRX.Size = New System.Drawing.Size(20, 20)
        Me.PBRX.TabIndex = 168
        Me.PBRX.TabStop = False
        '
        'PBTX
        '
        Me.PBTX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PBTX.BackgroundImage = Global.FlashedLOL.My.Resources.Res.pallina_grigia
        Me.PBTX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PBTX.Location = New System.Drawing.Point(13, 583)
        Me.PBTX.Name = "PBTX"
        Me.PBTX.Size = New System.Drawing.Size(20, 20)
        Me.PBTX.TabIndex = 168
        Me.PBTX.TabStop = False
        '
        'TextBoxRemoteLOLID
        '
        Me.TextBoxRemoteLOLID.Location = New System.Drawing.Point(111, 3)
        Me.TextBoxRemoteLOLID.Name = "TextBoxRemoteLOLID"
        Me.TextBoxRemoteLOLID.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxRemoteLOLID.TabIndex = 199
        Me.TextBoxRemoteLOLID.Text = "insert ID"
        '
        'TimerHeartRate
        '
        Me.TimerHeartRate.Interval = 500
        '
        'CheckBoxRemoteLolMaster
        '
        Me.CheckBoxRemoteLolMaster.AutoSize = True
        Me.CheckBoxRemoteLolMaster.Location = New System.Drawing.Point(217, 6)
        Me.CheckBoxRemoteLolMaster.Name = "CheckBoxRemoteLolMaster"
        Me.CheckBoxRemoteLolMaster.Size = New System.Drawing.Size(91, 17)
        Me.CheckBoxRemoteLolMaster.TabIndex = 203
        Me.CheckBoxRemoteLolMaster.Text = "I'm da master!"
        Me.CheckBoxRemoteLolMaster.UseVisualStyleBackColor = True
        '
        'LabelSerialiDaRecuperare
        '
        Me.LabelSerialiDaRecuperare.Location = New System.Drawing.Point(0, 215)
        Me.LabelSerialiDaRecuperare.Name = "LabelSerialiDaRecuperare"
        Me.LabelSerialiDaRecuperare.Size = New System.Drawing.Size(132, 27)
        Me.LabelSerialiDaRecuperare.TabIndex = 204
        Me.LabelSerialiDaRecuperare.Text = "0 da recuperare"
        Me.LabelSerialiDaRecuperare.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ButtonCreateCSV
        '
        Me.ButtonCreateCSV.Location = New System.Drawing.Point(139, 43)
        Me.ButtonCreateCSV.Name = "ButtonCreateCSV"
        Me.ButtonCreateCSV.Size = New System.Drawing.Size(71, 28)
        Me.ButtonCreateCSV.TabIndex = 205
        Me.ButtonCreateCSV.Text = "Genera etichette"
        Me.ButtonCreateCSV.UseVisualStyleBackColor = True
        '
        'ComboBoxLabelType
        '
        Me.ComboBoxLabelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.ComboBoxLabelType.FormattingEnabled = True
        Me.ComboBoxLabelType.Location = New System.Drawing.Point(662, 173)
        Me.ComboBoxLabelType.Name = "ComboBoxLabelType"
        Me.ComboBoxLabelType.Size = New System.Drawing.Size(141, 72)
        Me.ComboBoxLabelType.TabIndex = 206
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(662, 158)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 27)
        Me.Label7.TabIndex = 207
        Me.Label7.Text = "Tipo di etichetta"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CheckBoxClearAllarmi
        '
        Me.CheckBoxClearAllarmi.AutoSize = True
        Me.CheckBoxClearAllarmi.Checked = True
        Me.CheckBoxClearAllarmi.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxClearAllarmi.Location = New System.Drawing.Point(615, 249)
        Me.CheckBoxClearAllarmi.Name = "CheckBoxClearAllarmi"
        Me.CheckBoxClearAllarmi.Size = New System.Drawing.Size(82, 17)
        Me.CheckBoxClearAllarmi.TabIndex = 208
        Me.CheckBoxClearAllarmi.Text = "Clear allarmi"
        Me.CheckBoxClearAllarmi.UseVisualStyleBackColor = True
        '
        'LabelFlasingFw
        '
        Me.LabelFlasingFw.AutoSize = True
        Me.LabelFlasingFw.Location = New System.Drawing.Point(285, 253)
        Me.LabelFlasingFw.Name = "LabelFlasingFw"
        Me.LabelFlasingFw.Size = New System.Drawing.Size(0, 13)
        Me.LabelFlasingFw.TabIndex = 209
        '
        'TabControlMigrazione
        '
        Me.TabControlMigrazione.Controls.Add(Me.TabPage3)
        Me.TabControlMigrazione.Controls.Add(Me.TabPage2)
        Me.TabControlMigrazione.Controls.Add(Me.TabPage1)
        Me.TabControlMigrazione.Controls.Add(Me.TabPage4)
        Me.TabControlMigrazione.Controls.Add(Me.TabPageTestAutomatici)
        Me.TabControlMigrazione.Controls.Add(Me.TabPage9)
        Me.TabControlMigrazione.Location = New System.Drawing.Point(12, 362)
        Me.TabControlMigrazione.Name = "TabControlMigrazione"
        Me.TabControlMigrazione.SelectedIndex = 0
        Me.TabControlMigrazione.Size = New System.Drawing.Size(1000, 221)
        Me.TabControlMigrazione.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlMigrazione.TabIndex = 210
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBoxGRSatLogin)
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(992, 195)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Gestione login"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBoxGRSatLogin
        '
        Me.GroupBoxGRSatLogin.BackColor = System.Drawing.Color.Pink
        Me.GroupBoxGRSatLogin.Controls.Add(Me.CheckboxConfigureDeviceOnGRSat)
        Me.GroupBoxGRSatLogin.Controls.Add(Me.LinkLabelGoToGRsat)
        Me.GroupBoxGRSatLogin.Controls.Add(Me.GroupBox7)
        Me.GroupBoxGRSatLogin.Controls.Add(Me.CheckBoxTestInvioCloud)
        Me.GroupBoxGRSatLogin.Controls.Add(Me.LinkLabelUpdateGRSatList)
        Me.GroupBoxGRSatLogin.Controls.Add(Me.CheckboxCreateDeviceOnGRSat)
        Me.GroupBoxGRSatLogin.Controls.Add(Me.DropdownGRSatSelection)
        Me.GroupBoxGRSatLogin.Controls.Add(Me.LabelGRSatLoginStatus)
        Me.GroupBoxGRSatLogin.Controls.Add(Me.ButtonGRSatLogin)
        Me.GroupBoxGRSatLogin.Enabled = False
        Me.GroupBoxGRSatLogin.Location = New System.Drawing.Point(207, 6)
        Me.GroupBoxGRSatLogin.Name = "GroupBoxGRSatLogin"
        Me.GroupBoxGRSatLogin.Size = New System.Drawing.Size(779, 203)
        Me.GroupBoxGRSatLogin.TabIndex = 2
        Me.GroupBoxGRSatLogin.TabStop = False
        Me.GroupBoxGRSatLogin.Text = "GRSat Cloud"
        '
        'CheckboxConfigureDeviceOnGRSat
        '
        Me.CheckboxConfigureDeviceOnGRSat.AutoSize = True
        Me.CheckboxConfigureDeviceOnGRSat.Enabled = False
        Me.CheckboxConfigureDeviceOnGRSat.Location = New System.Drawing.Point(9, 78)
        Me.CheckboxConfigureDeviceOnGRSat.Name = "CheckboxConfigureDeviceOnGRSat"
        Me.CheckboxConfigureDeviceOnGRSat.Size = New System.Drawing.Size(207, 17)
        Me.CheckboxConfigureDeviceOnGRSat.TabIndex = 219
        Me.CheckboxConfigureDeviceOnGRSat.Tag = "Configura device per:"
        Me.CheckboxConfigureDeviceOnGRSat.Text = "Configura device per: [CHOOSE ONE]"
        Me.CheckboxConfigureDeviceOnGRSat.UseVisualStyleBackColor = True
        '
        'LinkLabelGoToGRsat
        '
        Me.LinkLabelGoToGRsat.AutoSize = True
        Me.LinkLabelGoToGRsat.Location = New System.Drawing.Point(6, 139)
        Me.LinkLabelGoToGRsat.Name = "LinkLabelGoToGRsat"
        Me.LinkLabelGoToGRsat.Size = New System.Drawing.Size(52, 13)
        Me.LinkLabelGoToGRsat.TabIndex = 218
        Me.LinkLabelGoToGRsat.TabStop = True
        Me.LinkLabelGoToGRsat.Text = "Vai al sito"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.PapayaWhip
        Me.GroupBox7.Controls.Add(Me.ButtonAssetCreate)
        Me.GroupBox7.Controls.Add(Me.LinkLabelAssetLoadSheets)
        Me.GroupBox7.Controls.Add(Me.LinkLabelAssetLoadUnits)
        Me.GroupBox7.Controls.Add(Me.GroupBox9)
        Me.GroupBox7.Controls.Add(Me.GroupBox8)
        Me.GroupBox7.Controls.Add(Me.CBAssetSheet)
        Me.GroupBox7.Controls.Add(Me.CBAssetUnit)
        Me.GroupBox7.Enabled = False
        Me.GroupBox7.Location = New System.Drawing.Point(229, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(544, 185)
        Me.GroupBox7.TabIndex = 217
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Creazione asset"
        '
        'ButtonAssetCreate
        '
        Me.ButtonAssetCreate.Location = New System.Drawing.Point(463, 11)
        Me.ButtonAssetCreate.Name = "ButtonAssetCreate"
        Me.ButtonAssetCreate.Size = New System.Drawing.Size(75, 23)
        Me.ButtonAssetCreate.TabIndex = 10
        Me.ButtonAssetCreate.Text = "Crea asset"
        Me.ButtonAssetCreate.UseVisualStyleBackColor = True
        '
        'LinkLabelAssetLoadSheets
        '
        Me.LinkLabelAssetLoadSheets.AutoSize = True
        Me.LinkLabelAssetLoadSheets.Location = New System.Drawing.Point(418, 46)
        Me.LinkLabelAssetLoadSheets.Name = "LinkLabelAssetLoadSheets"
        Me.LinkLabelAssetLoadSheets.Size = New System.Drawing.Size(69, 13)
        Me.LinkLabelAssetLoadSheets.TabIndex = 9
        Me.LinkLabelAssetLoadSheets.TabStop = True
        Me.LinkLabelAssetLoadSheets.Text = "Sensor sheet"
        '
        'LinkLabelAssetLoadUnits
        '
        Me.LinkLabelAssetLoadUnits.AutoSize = True
        Me.LinkLabelAssetLoadUnits.Location = New System.Drawing.Point(418, 21)
        Me.LinkLabelAssetLoadUnits.Name = "LinkLabelAssetLoadUnits"
        Me.LinkLabelAssetLoadUnits.Size = New System.Drawing.Size(26, 13)
        Me.LinkLabelAssetLoadUnits.TabIndex = 8
        Me.LinkLabelAssetLoadUnits.TabStop = True
        Me.LinkLabelAssetLoadUnits.Text = "Unit"
        '
        'GroupBox9
        '
        Me.GroupBox9.BackColor = System.Drawing.Color.MistyRose
        Me.GroupBox9.Controls.Add(Me.CBAssetMeter2Spn)
        Me.GroupBox9.Controls.Add(Me.CBAssetMeter2)
        Me.GroupBox9.Controls.Add(Me.CBAssetMeter1Spn)
        Me.GroupBox9.Controls.Add(Me.CBAssetMeter1)
        Me.GroupBox9.Controls.Add(Me.CBAssetUses)
        Me.GroupBox9.Controls.Add(Me.CBAssetRSSI)
        Me.GroupBox9.Controls.Add(Me.CBAssetChart)
        Me.GroupBox9.Controls.Add(Me.CBAssetAlarm)
        Me.GroupBox9.Controls.Add(Me.CBAssetDummy)
        Me.GroupBox9.Controls.Add(Me.CBAssetInspector)
        Me.GroupBox9.Controls.Add(Me.CBAssetGPS)
        Me.GroupBox9.Controls.Add(Me.CBAssetRoutes)
        Me.GroupBox9.Controls.Add(Me.CBAssetMap)
        Me.GroupBox9.Controls.Add(Me.CBAssetProfile)
        Me.GroupBox9.Location = New System.Drawing.Point(197, 68)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(341, 111)
        Me.GroupBox9.TabIndex = 6
        Me.GroupBox9.TabStop = False
        '
        'CBAssetMeter2Spn
        '
        Me.CBAssetMeter2Spn.FormattingEnabled = True
        Me.CBAssetMeter2Spn.Location = New System.Drawing.Point(173, 77)
        Me.CBAssetMeter2Spn.Name = "CBAssetMeter2Spn"
        Me.CBAssetMeter2Spn.Size = New System.Drawing.Size(162, 21)
        Me.CBAssetMeter2Spn.TabIndex = 13
        '
        'CBAssetMeter2
        '
        Me.CBAssetMeter2.AutoSize = True
        Me.CBAssetMeter2.Checked = True
        Me.CBAssetMeter2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBAssetMeter2.Location = New System.Drawing.Point(156, 58)
        Me.CBAssetMeter2.Name = "CBAssetMeter2"
        Me.CBAssetMeter2.Size = New System.Drawing.Size(62, 17)
        Me.CBAssetMeter2.TabIndex = 12
        Me.CBAssetMeter2.Text = "Meter 2"
        Me.CBAssetMeter2.UseVisualStyleBackColor = True
        '
        'CBAssetMeter1Spn
        '
        Me.CBAssetMeter1Spn.FormattingEnabled = True
        Me.CBAssetMeter1Spn.Location = New System.Drawing.Point(173, 31)
        Me.CBAssetMeter1Spn.Name = "CBAssetMeter1Spn"
        Me.CBAssetMeter1Spn.Size = New System.Drawing.Size(162, 21)
        Me.CBAssetMeter1Spn.TabIndex = 11
        '
        'CBAssetMeter1
        '
        Me.CBAssetMeter1.AutoSize = True
        Me.CBAssetMeter1.Checked = True
        Me.CBAssetMeter1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBAssetMeter1.Location = New System.Drawing.Point(156, 12)
        Me.CBAssetMeter1.Name = "CBAssetMeter1"
        Me.CBAssetMeter1.Size = New System.Drawing.Size(62, 17)
        Me.CBAssetMeter1.TabIndex = 5
        Me.CBAssetMeter1.Text = "Meter 1"
        Me.CBAssetMeter1.UseVisualStyleBackColor = True
        '
        'CBAssetUses
        '
        Me.CBAssetUses.AutoSize = True
        Me.CBAssetUses.Checked = True
        Me.CBAssetUses.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBAssetUses.Location = New System.Drawing.Point(67, 33)
        Me.CBAssetUses.Name = "CBAssetUses"
        Me.CBAssetUses.Size = New System.Drawing.Size(50, 17)
        Me.CBAssetUses.TabIndex = 5
        Me.CBAssetUses.Text = "Uses"
        Me.CBAssetUses.UseVisualStyleBackColor = True
        '
        'CBAssetRSSI
        '
        Me.CBAssetRSSI.AutoSize = True
        Me.CBAssetRSSI.Location = New System.Drawing.Point(6, 54)
        Me.CBAssetRSSI.Name = "CBAssetRSSI"
        Me.CBAssetRSSI.Size = New System.Drawing.Size(51, 17)
        Me.CBAssetRSSI.TabIndex = 5
        Me.CBAssetRSSI.Text = "RSSI"
        Me.CBAssetRSSI.UseVisualStyleBackColor = True
        '
        'CBAssetChart
        '
        Me.CBAssetChart.AutoSize = True
        Me.CBAssetChart.Checked = True
        Me.CBAssetChart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBAssetChart.Location = New System.Drawing.Point(67, 54)
        Me.CBAssetChart.Name = "CBAssetChart"
        Me.CBAssetChart.Size = New System.Drawing.Size(56, 17)
        Me.CBAssetChart.TabIndex = 5
        Me.CBAssetChart.Text = "Charts"
        Me.CBAssetChart.UseVisualStyleBackColor = True
        '
        'CBAssetAlarm
        '
        Me.CBAssetAlarm.AutoSize = True
        Me.CBAssetAlarm.Checked = True
        Me.CBAssetAlarm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBAssetAlarm.Location = New System.Drawing.Point(6, 73)
        Me.CBAssetAlarm.Name = "CBAssetAlarm"
        Me.CBAssetAlarm.Size = New System.Drawing.Size(52, 17)
        Me.CBAssetAlarm.TabIndex = 5
        Me.CBAssetAlarm.Text = "Alarm"
        Me.CBAssetAlarm.UseVisualStyleBackColor = True
        '
        'CBAssetDummy
        '
        Me.CBAssetDummy.AutoSize = True
        Me.CBAssetDummy.Location = New System.Drawing.Point(67, 94)
        Me.CBAssetDummy.Name = "CBAssetDummy"
        Me.CBAssetDummy.Size = New System.Drawing.Size(61, 17)
        Me.CBAssetDummy.TabIndex = 5
        Me.CBAssetDummy.Text = "Dummy"
        Me.CBAssetDummy.UseVisualStyleBackColor = True
        '
        'CBAssetInspector
        '
        Me.CBAssetInspector.AutoSize = True
        Me.CBAssetInspector.Checked = True
        Me.CBAssetInspector.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBAssetInspector.Location = New System.Drawing.Point(67, 12)
        Me.CBAssetInspector.Name = "CBAssetInspector"
        Me.CBAssetInspector.Size = New System.Drawing.Size(70, 17)
        Me.CBAssetInspector.TabIndex = 5
        Me.CBAssetInspector.Text = "Inspector"
        Me.CBAssetInspector.UseVisualStyleBackColor = True
        '
        'CBAssetGPS
        '
        Me.CBAssetGPS.AutoSize = True
        Me.CBAssetGPS.Location = New System.Drawing.Point(6, 33)
        Me.CBAssetGPS.Name = "CBAssetGPS"
        Me.CBAssetGPS.Size = New System.Drawing.Size(48, 17)
        Me.CBAssetGPS.TabIndex = 5
        Me.CBAssetGPS.Text = "GPS"
        Me.CBAssetGPS.UseVisualStyleBackColor = True
        '
        'CBAssetRoutes
        '
        Me.CBAssetRoutes.AutoSize = True
        Me.CBAssetRoutes.Location = New System.Drawing.Point(67, 73)
        Me.CBAssetRoutes.Name = "CBAssetRoutes"
        Me.CBAssetRoutes.Size = New System.Drawing.Size(60, 17)
        Me.CBAssetRoutes.TabIndex = 5
        Me.CBAssetRoutes.Text = "Routes"
        Me.CBAssetRoutes.UseVisualStyleBackColor = True
        '
        'CBAssetMap
        '
        Me.CBAssetMap.AutoSize = True
        Me.CBAssetMap.Location = New System.Drawing.Point(6, 94)
        Me.CBAssetMap.Name = "CBAssetMap"
        Me.CBAssetMap.Size = New System.Drawing.Size(47, 17)
        Me.CBAssetMap.TabIndex = 5
        Me.CBAssetMap.Text = "Map"
        Me.CBAssetMap.UseVisualStyleBackColor = True
        '
        'CBAssetProfile
        '
        Me.CBAssetProfile.AutoSize = True
        Me.CBAssetProfile.Checked = True
        Me.CBAssetProfile.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBAssetProfile.Location = New System.Drawing.Point(6, 12)
        Me.CBAssetProfile.Name = "CBAssetProfile"
        Me.CBAssetProfile.Size = New System.Drawing.Size(55, 17)
        Me.CBAssetProfile.TabIndex = 5
        Me.CBAssetProfile.Text = "Profile"
        Me.CBAssetProfile.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Ivory
        Me.GroupBox8.Controls.Add(Me.CheckBoxAutoFillAssetData)
        Me.GroupBox8.Controls.Add(Me.TBAssetDesc)
        Me.GroupBox8.Controls.Add(Me.TBAssetBrand)
        Me.GroupBox8.Controls.Add(Me.TBAssetSerial)
        Me.GroupBox8.Controls.Add(Me.Label20)
        Me.GroupBox8.Controls.Add(Me.TBAssetModel)
        Me.GroupBox8.Controls.Add(Me.Label19)
        Me.GroupBox8.Controls.Add(Me.TBAssetPlate)
        Me.GroupBox8.Controls.Add(Me.Label18)
        Me.GroupBox8.Controls.Add(Me.Label16)
        Me.GroupBox8.Controls.Add(Me.Label17)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 14)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(185, 165)
        Me.GroupBox8.TabIndex = 4
        Me.GroupBox8.TabStop = False
        '
        'CheckBoxAutoFillAssetData
        '
        Me.CheckBoxAutoFillAssetData.AutoSize = True
        Me.CheckBoxAutoFillAssetData.Location = New System.Drawing.Point(6, 11)
        Me.CheckBoxAutoFillAssetData.Name = "CheckBoxAutoFillAssetData"
        Me.CheckBoxAutoFillAssetData.Size = New System.Drawing.Size(79, 17)
        Me.CheckBoxAutoFillAssetData.TabIndex = 2
        Me.CheckBoxAutoFillAssetData.Text = "Automatico"
        Me.CheckBoxAutoFillAssetData.UseVisualStyleBackColor = True
        '
        'TBAssetDesc
        '
        Me.TBAssetDesc.Location = New System.Drawing.Point(6, 30)
        Me.TBAssetDesc.Name = "TBAssetDesc"
        Me.TBAssetDesc.Size = New System.Drawing.Size(100, 20)
        Me.TBAssetDesc.TabIndex = 0
        '
        'TBAssetBrand
        '
        Me.TBAssetBrand.Location = New System.Drawing.Point(24, 56)
        Me.TBAssetBrand.Name = "TBAssetBrand"
        Me.TBAssetBrand.Size = New System.Drawing.Size(100, 20)
        Me.TBAssetBrand.TabIndex = 0
        '
        'TBAssetSerial
        '
        Me.TBAssetSerial.Location = New System.Drawing.Point(24, 82)
        Me.TBAssetSerial.Name = "TBAssetSerial"
        Me.TBAssetSerial.Size = New System.Drawing.Size(100, 20)
        Me.TBAssetSerial.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(126, 137)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(31, 13)
        Me.Label20.TabIndex = 1
        Me.Label20.Text = "Plate"
        '
        'TBAssetModel
        '
        Me.TBAssetModel.Location = New System.Drawing.Point(24, 108)
        Me.TBAssetModel.Name = "TBAssetModel"
        Me.TBAssetModel.Size = New System.Drawing.Size(100, 20)
        Me.TBAssetModel.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(126, 111)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(36, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Model"
        '
        'TBAssetPlate
        '
        Me.TBAssetPlate.Location = New System.Drawing.Point(24, 134)
        Me.TBAssetPlate.Name = "TBAssetPlate"
        Me.TBAssetPlate.Size = New System.Drawing.Size(100, 20)
        Me.TBAssetPlate.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(126, 85)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(33, 13)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Serial"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(108, 33)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 1
        Me.Label16.Text = "Description"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(126, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 13)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Brand"
        '
        'CBAssetSheet
        '
        Me.CBAssetSheet.FormattingEnabled = True
        Me.CBAssetSheet.Location = New System.Drawing.Point(197, 43)
        Me.CBAssetSheet.Name = "CBAssetSheet"
        Me.CBAssetSheet.Size = New System.Drawing.Size(215, 21)
        Me.CBAssetSheet.TabIndex = 2
        '
        'CBAssetUnit
        '
        Me.CBAssetUnit.FormattingEnabled = True
        Me.CBAssetUnit.Location = New System.Drawing.Point(197, 17)
        Me.CBAssetUnit.Name = "CBAssetUnit"
        Me.CBAssetUnit.Size = New System.Drawing.Size(215, 21)
        Me.CBAssetUnit.TabIndex = 2
        '
        'CheckBoxTestInvioCloud
        '
        Me.CheckBoxTestInvioCloud.AutoSize = True
        Me.CheckBoxTestInvioCloud.Enabled = False
        Me.CheckBoxTestInvioCloud.Location = New System.Drawing.Point(9, 115)
        Me.CheckBoxTestInvioCloud.Name = "CheckBoxTestInvioCloud"
        Me.CheckBoxTestInvioCloud.Size = New System.Drawing.Size(72, 17)
        Me.CheckBoxTestInvioCloud.TabIndex = 188
        Me.CheckBoxTestInvioCloud.Text = "Test invio"
        Me.CheckBoxTestInvioCloud.UseVisualStyleBackColor = True
        '
        'LinkLabelUpdateGRSatList
        '
        Me.LinkLabelUpdateGRSatList.AutoSize = True
        Me.LinkLabelUpdateGRSatList.Location = New System.Drawing.Point(136, 22)
        Me.LinkLabelUpdateGRSatList.Name = "LinkLabelUpdateGRSatList"
        Me.LinkLabelUpdateGRSatList.Size = New System.Drawing.Size(49, 13)
        Me.LinkLabelUpdateGRSatList.TabIndex = 7
        Me.LinkLabelUpdateGRSatList.TabStop = True
        Me.LinkLabelUpdateGRSatList.Text = "Aggiorna"
        '
        'CheckboxCreateDeviceOnGRSat
        '
        Me.CheckboxCreateDeviceOnGRSat.AutoSize = True
        Me.CheckboxCreateDeviceOnGRSat.Enabled = False
        Me.CheckboxCreateDeviceOnGRSat.Location = New System.Drawing.Point(9, 97)
        Me.CheckboxCreateDeviceOnGRSat.Name = "CheckboxCreateDeviceOnGRSat"
        Me.CheckboxCreateDeviceOnGRSat.Size = New System.Drawing.Size(199, 17)
        Me.CheckboxCreateDeviceOnGRSat.TabIndex = 188
        Me.CheckboxCreateDeviceOnGRSat.Tag = "Crea ed associa su: "
        Me.CheckboxCreateDeviceOnGRSat.Text = "Crea ed associa su: [CHOOSE ONE]"
        Me.CheckboxCreateDeviceOnGRSat.UseVisualStyleBackColor = True
        '
        'DropdownGRSatSelection
        '
        Me.DropdownGRSatSelection.FormattingEnabled = True
        Me.DropdownGRSatSelection.Location = New System.Drawing.Point(9, 18)
        Me.DropdownGRSatSelection.Name = "DropdownGRSatSelection"
        Me.DropdownGRSatSelection.Size = New System.Drawing.Size(121, 21)
        Me.DropdownGRSatSelection.TabIndex = 6
        '
        'LabelGRSatLoginStatus
        '
        Me.LabelGRSatLoginStatus.AutoSize = True
        Me.LabelGRSatLoginStatus.Location = New System.Drawing.Point(90, 49)
        Me.LabelGRSatLoginStatus.Name = "LabelGRSatLoginStatus"
        Me.LabelGRSatLoginStatus.Size = New System.Drawing.Size(63, 13)
        Me.LabelGRSatLoginStatus.TabIndex = 3
        Me.LabelGRSatLoginStatus.Text = "Uninitialized"
        '
        'ButtonGRSatLogin
        '
        Me.ButtonGRSatLogin.Location = New System.Drawing.Point(9, 44)
        Me.ButtonGRSatLogin.Name = "ButtonGRSatLogin"
        Me.ButtonGRSatLogin.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGRSatLogin.TabIndex = 2
        Me.ButtonGRSatLogin.Text = "Login"
        Me.ButtonGRSatLogin.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.MediumSpringGreen
        Me.GroupBox4.Controls.Add(Me.ButtonStorePredictionLogin)
        Me.GroupBox4.Controls.Add(Me.LabelPredictionLoginStatus)
        Me.GroupBox4.Controls.Add(Me.ButtonPredictionLogin)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.Label25)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.TextboxPredictionPassword)
        Me.GroupBox4.Controls.Add(Me.TextboxPredictionHost)
        Me.GroupBox4.Controls.Add(Me.TextboxPredictionUsername)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(195, 155)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Prediction super gestionale"
        '
        'ButtonStorePredictionLogin
        '
        Me.ButtonStorePredictionLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonStorePredictionLogin.Location = New System.Drawing.Point(87, 104)
        Me.ButtonStorePredictionLogin.Name = "ButtonStorePredictionLogin"
        Me.ButtonStorePredictionLogin.Size = New System.Drawing.Size(102, 23)
        Me.ButtonStorePredictionLogin.TabIndex = 4
        Me.ButtonStorePredictionLogin.Text = "Salva credenziali"
        Me.ButtonStorePredictionLogin.UseVisualStyleBackColor = True
        '
        'LabelPredictionLoginStatus
        '
        Me.LabelPredictionLoginStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelPredictionLoginStatus.AutoSize = True
        Me.LabelPredictionLoginStatus.Location = New System.Drawing.Point(9, 132)
        Me.LabelPredictionLoginStatus.Name = "LabelPredictionLoginStatus"
        Me.LabelPredictionLoginStatus.Size = New System.Drawing.Size(63, 13)
        Me.LabelPredictionLoginStatus.TabIndex = 3
        Me.LabelPredictionLoginStatus.Text = "Uninitialized"
        '
        'ButtonPredictionLogin
        '
        Me.ButtonPredictionLogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonPredictionLogin.Location = New System.Drawing.Point(6, 104)
        Me.ButtonPredictionLogin.Name = "ButtonPredictionLogin"
        Me.ButtonPredictionLogin.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPredictionLogin.TabIndex = 2
        Me.ButtonPredictionLogin.Text = "Login"
        Me.ButtonPredictionLogin.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(113, 82)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Password"
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(113, 30)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(29, 13)
        Me.Label25.TabIndex = 1
        Me.Label25.Text = "Host"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(113, 56)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(55, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Username"
        '
        'TextboxPredictionPassword
        '
        Me.TextboxPredictionPassword.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextboxPredictionPassword.Location = New System.Drawing.Point(6, 78)
        Me.TextboxPredictionPassword.Name = "TextboxPredictionPassword"
        Me.TextboxPredictionPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9836)
        Me.TextboxPredictionPassword.Size = New System.Drawing.Size(100, 20)
        Me.TextboxPredictionPassword.TabIndex = 0
        Me.TextboxPredictionPassword.Text = "loool"
        '
        'TextboxPredictionHost
        '
        Me.TextboxPredictionHost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextboxPredictionHost.Enabled = False
        Me.TextboxPredictionHost.Location = New System.Drawing.Point(6, 26)
        Me.TextboxPredictionHost.Name = "TextboxPredictionHost"
        Me.TextboxPredictionHost.Size = New System.Drawing.Size(100, 20)
        Me.TextboxPredictionHost.TabIndex = 0
        Me.TextboxPredictionHost.Text = "erp.kiwitron.it"
        '
        'TextboxPredictionUsername
        '
        Me.TextboxPredictionUsername.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextboxPredictionUsername.Location = New System.Drawing.Point(6, 52)
        Me.TextboxPredictionUsername.Name = "TextboxPredictionUsername"
        Me.TextboxPredictionUsername.Size = New System.Drawing.Size(100, 20)
        Me.TextboxPredictionUsername.TabIndex = 0
        Me.TextboxPredictionUsername.Text = "prediction.master"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(992, 195)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Funzione divina"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.TextBoxRemoteLOLID)
        Me.TabPage1.Controls.Add(Me.CheckBoxDivineSync)
        Me.TabPage1.Controls.Add(Me.CheckBoxRemoteLolMaster)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(992, 195)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "RemoteLOL"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.ButtonMongo)
        Me.TabPage4.Controls.Add(Me.GroupBox5)
        Me.TabPage4.Controls.Add(Me.CheckBoxHack)
        Me.TabPage4.Controls.Add(Me.CheckBoxHWSetupMoved)
        Me.TabPage4.Controls.Add(Me.CheckBoxSendMongo)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(992, 195)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Hack tab"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'ButtonMongo
        '
        Me.ButtonMongo.Enabled = False
        Me.ButtonMongo.Location = New System.Drawing.Point(409, 37)
        Me.ButtonMongo.Name = "ButtonMongo"
        Me.ButtonMongo.Size = New System.Drawing.Size(108, 23)
        Me.ButtonMongo.TabIndex = 219
        Me.ButtonMongo.Text = "Invia statistica ora"
        Me.ButtonMongo.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.RBOTGLAST)
        Me.GroupBox5.Controls.Add(Me.RBOTGNOW)
        Me.GroupBox5.Controls.Add(Me.CBOTG)
        Me.GroupBox5.Controls.Add(Me.ProgressBarOTG)
        Me.GroupBox5.Controls.Add(Me.TextBoxOTGPAth)
        Me.GroupBox5.Location = New System.Drawing.Point(6, 60)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(228, 119)
        Me.GroupBox5.TabIndex = 198
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Parametri OTG"
        '
        'RBOTGLAST
        '
        Me.RBOTGLAST.AutoSize = True
        Me.RBOTGLAST.Location = New System.Drawing.Point(6, 94)
        Me.RBOTGLAST.Name = "RBOTGLAST"
        Me.RBOTGLAST.Size = New System.Drawing.Size(96, 17)
        Me.RBOTGLAST.TabIndex = 182
        Me.RBOTGLAST.Text = "Esegui alla fine"
        Me.RBOTGLAST.UseVisualStyleBackColor = True
        '
        'RBOTGNOW
        '
        Me.RBOTGNOW.AutoSize = True
        Me.RBOTGNOW.Checked = True
        Me.RBOTGNOW.Location = New System.Drawing.Point(6, 71)
        Me.RBOTGNOW.Name = "RBOTGNOW"
        Me.RBOTGNOW.Size = New System.Drawing.Size(188, 17)
        Me.RBOTGNOW.TabIndex = 182
        Me.RBOTGNOW.TabStop = True
        Me.RBOTGNOW.Text = "Esegui subito dopo conf. parametri"
        Me.RBOTGNOW.UseVisualStyleBackColor = True
        '
        'CheckBoxSendMongo
        '
        Me.CheckBoxSendMongo.AutoSize = True
        Me.CheckBoxSendMongo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxSendMongo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBoxSendMongo.Location = New System.Drawing.Point(409, 14)
        Me.CheckBoxSendMongo.Name = "CheckBoxSendMongo"
        Me.CheckBoxSendMongo.Size = New System.Drawing.Size(212, 17)
        Me.CheckBoxSendMongo.TabIndex = 220
        Me.CheckBoxSendMongo.Text = "Invia dati a Prediction automaticamente"
        Me.CheckBoxSendMongo.UseVisualStyleBackColor = True
        '
        'TabPageTestAutomatici
        '
        Me.TabPageTestAutomatici.BackColor = System.Drawing.Color.Black
        Me.TabPageTestAutomatici.BackgroundImage = Global.FlashedLOL.My.Resources.Resources._7e540581135fb11bf49681164fbc7927
        Me.TabPageTestAutomatici.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.TabPageTestAutomatici.Controls.Add(Me.GroupBoxTelitTest)
        Me.TabPageTestAutomatici.Controls.Add(Me.GroupBoxGPRSTest)
        Me.TabPageTestAutomatici.Controls.Add(Me.GroupBoxLEDTest)
        Me.TabPageTestAutomatici.Controls.Add(Me.GroupBoxRFIDTest)
        Me.TabPageTestAutomatici.ForeColor = System.Drawing.Color.White
        Me.TabPageTestAutomatici.Location = New System.Drawing.Point(4, 22)
        Me.TabPageTestAutomatici.Name = "TabPageTestAutomatici"
        Me.TabPageTestAutomatici.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageTestAutomatici.Size = New System.Drawing.Size(992, 195)
        Me.TabPageTestAutomatici.TabIndex = 4
        Me.TabPageTestAutomatici.Text = "Test automagici"
        '
        'GroupBoxTelitTest
        '
        Me.GroupBoxTelitTest.BackColor = System.Drawing.Color.Black
        Me.GroupBoxTelitTest.Controls.Add(Me.LabelTelitSTestStatus)
        Me.GroupBoxTelitTest.Controls.Add(Me.LinkLabel5)
        Me.GroupBoxTelitTest.Controls.Add(Me.TextBoxTelitGPS_Vok)
        Me.GroupBoxTelitTest.Controls.Add(Me.LinkLabel4)
        Me.GroupBoxTelitTest.Controls.Add(Me.TextBoxTelitGPRS_Vok)
        Me.GroupBoxTelitTest.Controls.Add(Me.Label24)
        Me.GroupBoxTelitTest.Controls.Add(Me.ButtonsStarTelitVTest)
        Me.GroupBoxTelitTest.Controls.Add(Me.CheckBoxTelitVTest)
        Me.GroupBoxTelitTest.Location = New System.Drawing.Point(764, 6)
        Me.GroupBoxTelitTest.Name = "GroupBoxTelitTest"
        Me.GroupBoxTelitTest.Size = New System.Drawing.Size(222, 111)
        Me.GroupBoxTelitTest.TabIndex = 163
        Me.GroupBoxTelitTest.TabStop = False
        '
        'LabelTelitSTestStatus
        '
        Me.LabelTelitSTestStatus.AutoSize = True
        Me.LabelTelitSTestStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTelitSTestStatus.Location = New System.Drawing.Point(113, 83)
        Me.LabelTelitSTestStatus.Name = "LabelTelitSTestStatus"
        Me.LabelTelitSTestStatus.Size = New System.Drawing.Size(70, 15)
        Me.LabelTelitSTestStatus.TabIndex = 166
        Me.LabelTelitSTestStatus.Text = "Test: todo"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.AutoSize = True
        Me.LinkLabel5.LinkColor = System.Drawing.Color.White
        Me.LinkLabel5.Location = New System.Drawing.Point(118, 52)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(47, 13)
        Me.LinkLabel5.TabIndex = 164
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Modifica"
        '
        'TextBoxTelitGPS_Vok
        '
        Me.TextBoxTelitGPS_Vok.Location = New System.Drawing.Point(12, 49)
        Me.TextBoxTelitGPS_Vok.Name = "TextBoxTelitGPS_Vok"
        Me.TextBoxTelitGPS_Vok.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxTelitGPS_Vok.TabIndex = 165
        '
        'LinkLabel4
        '
        Me.LinkLabel4.AutoSize = True
        Me.LinkLabel4.LinkColor = System.Drawing.Color.White
        Me.LinkLabel4.Location = New System.Drawing.Point(118, 26)
        Me.LinkLabel4.Name = "LinkLabel4"
        Me.LinkLabel4.Size = New System.Drawing.Size(47, 13)
        Me.LinkLabel4.TabIndex = 163
        Me.LinkLabel4.TabStop = True
        Me.LinkLabel4.Text = "Modifica"
        '
        'TextBoxTelitGPRS_Vok
        '
        Me.TextBoxTelitGPRS_Vok.Location = New System.Drawing.Point(12, 23)
        Me.TextBoxTelitGPRS_Vok.Name = "TextBoxTelitGPRS_Vok"
        Me.TextBoxTelitGPRS_Vok.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxTelitGPRS_Vok.TabIndex = 163
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(9, 17)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(188, 55)
        Me.Label24.TabIndex = 160
        '
        'ButtonsStarTelitVTest
        '
        Me.ButtonsStarTelitVTest.ForeColor = System.Drawing.Color.Black
        Me.ButtonsStarTelitVTest.Location = New System.Drawing.Point(7, 75)
        Me.ButtonsStarTelitVTest.Name = "ButtonsStarTelitVTest"
        Me.ButtonsStarTelitVTest.Size = New System.Drawing.Size(100, 23)
        Me.ButtonsStarTelitVTest.TabIndex = 159
        Me.ButtonsStarTelitVTest.Text = "Avvia test"
        Me.ButtonsStarTelitVTest.UseVisualStyleBackColor = True
        '
        'CheckBoxTelitVTest
        '
        Me.CheckBoxTelitVTest.AutoSize = True
        Me.CheckBoxTelitVTest.Location = New System.Drawing.Point(7, 0)
        Me.CheckBoxTelitVTest.Name = "CheckBoxTelitVTest"
        Me.CheckBoxTelitVTest.Size = New System.Drawing.Size(117, 17)
        Me.CheckBoxTelitVTest.TabIndex = 154
        Me.CheckBoxTelitVTest.Text = "Check Telit version"
        Me.CheckBoxTelitVTest.UseVisualStyleBackColor = True
        '
        'GroupBoxGPRSTest
        '
        Me.GroupBoxGPRSTest.BackColor = System.Drawing.Color.Black
        Me.GroupBoxGPRSTest.Controls.Add(Me.LinkLabel2)
        Me.GroupBoxGPRSTest.Controls.Add(Me.TextBoxGPRSTestAPN)
        Me.GroupBoxGPRSTest.Controls.Add(Me.LinkLabel3)
        Me.GroupBoxGPRSTest.Controls.Add(Me.LabelGPRSTestStatus)
        Me.GroupBoxGPRSTest.Controls.Add(Me.ButtonsStartGPRSTest)
        Me.GroupBoxGPRSTest.Controls.Add(Me.CheckBoxGPRSTest)
        Me.GroupBoxGPRSTest.Controls.Add(Me.TextBoxGPRSTestPin)
        Me.GroupBoxGPRSTest.Location = New System.Drawing.Point(504, 6)
        Me.GroupBoxGPRSTest.Name = "GroupBoxGPRSTest"
        Me.GroupBoxGPRSTest.Size = New System.Drawing.Size(253, 111)
        Me.GroupBoxGPRSTest.TabIndex = 162
        Me.GroupBoxGPRSTest.TabStop = False
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.LinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Location = New System.Drawing.Point(113, 52)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(29, 13)
        Me.LinkLabel2.TabIndex = 162
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "APN"
        '
        'TextBoxGPRSTestAPN
        '
        Me.TextBoxGPRSTestAPN.Location = New System.Drawing.Point(7, 49)
        Me.TextBoxGPRSTestAPN.Name = "TextBoxGPRSTestAPN"
        Me.TextBoxGPRSTestAPN.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxGPRSTestAPN.TabIndex = 161
        Me.TextBoxGPRSTestAPN.Text = "myinternet.wind"
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.LinkColor = System.Drawing.Color.White
        Me.LinkLabel3.Location = New System.Drawing.Point(113, 26)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(115, 13)
        Me.LinkLabel3.TabIndex = 157
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "PIN SIM ( vuoto se off)"
        '
        'LabelGPRSTestStatus
        '
        Me.LabelGPRSTestStatus.AutoSize = True
        Me.LabelGPRSTestStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelGPRSTestStatus.Location = New System.Drawing.Point(113, 78)
        Me.LabelGPRSTestStatus.Name = "LabelGPRSTestStatus"
        Me.LabelGPRSTestStatus.Size = New System.Drawing.Size(130, 15)
        Me.LabelGPRSTestStatus.TabIndex = 160
        Me.LabelGPRSTestStatus.Text = "Test GPRS: -STOP-"
        '
        'ButtonsStartGPRSTest
        '
        Me.ButtonsStartGPRSTest.ForeColor = System.Drawing.Color.Black
        Me.ButtonsStartGPRSTest.Location = New System.Drawing.Point(7, 75)
        Me.ButtonsStartGPRSTest.Name = "ButtonsStartGPRSTest"
        Me.ButtonsStartGPRSTest.Size = New System.Drawing.Size(100, 23)
        Me.ButtonsStartGPRSTest.TabIndex = 159
        Me.ButtonsStartGPRSTest.Text = "Avvia test"
        Me.ButtonsStartGPRSTest.UseVisualStyleBackColor = True
        '
        'CheckBoxGPRSTest
        '
        Me.CheckBoxGPRSTest.AutoSize = True
        Me.CheckBoxGPRSTest.Location = New System.Drawing.Point(7, 0)
        Me.CheckBoxGPRSTest.Name = "CheckBoxGPRSTest"
        Me.CheckBoxGPRSTest.Size = New System.Drawing.Size(105, 17)
        Me.CheckBoxGPRSTest.TabIndex = 154
        Me.CheckBoxGPRSTest.Text = "Test invio GPRS"
        Me.CheckBoxGPRSTest.UseVisualStyleBackColor = True
        '
        'TextBoxGPRSTestPin
        '
        Me.TextBoxGPRSTestPin.Location = New System.Drawing.Point(7, 23)
        Me.TextBoxGPRSTestPin.Name = "TextBoxGPRSTestPin"
        Me.TextBoxGPRSTestPin.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxGPRSTestPin.TabIndex = 155
        '
        'GroupBoxLEDTest
        '
        Me.GroupBoxLEDTest.BackColor = System.Drawing.Color.Black
        Me.GroupBoxLEDTest.Controls.Add(Me.Label1)
        Me.GroupBoxLEDTest.Controls.Add(Me.ButtonsStartLEDTest)
        Me.GroupBoxLEDTest.Controls.Add(Me.CheckBoxLEDTest)
        Me.GroupBoxLEDTest.Location = New System.Drawing.Point(265, 6)
        Me.GroupBoxLEDTest.Name = "GroupBoxLEDTest"
        Me.GroupBoxLEDTest.Size = New System.Drawing.Size(233, 111)
        Me.GroupBoxLEDTest.TabIndex = 162
        Me.GroupBoxLEDTest.TabStop = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(215, 55)
        Me.Label1.TabIndex = 160
        Me.Label1.Text = "Durante il test i tre led superiori si accenderanno per un istante, mentre il LED" &
    " centrale si accenderà fisso poco dopo. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Cliccare il tasto per avviare il test"
        '
        'ButtonsStartLEDTest
        '
        Me.ButtonsStartLEDTest.ForeColor = System.Drawing.Color.Black
        Me.ButtonsStartLEDTest.Location = New System.Drawing.Point(7, 75)
        Me.ButtonsStartLEDTest.Name = "ButtonsStartLEDTest"
        Me.ButtonsStartLEDTest.Size = New System.Drawing.Size(100, 23)
        Me.ButtonsStartLEDTest.TabIndex = 159
        Me.ButtonsStartLEDTest.Text = "Avvia test"
        Me.ButtonsStartLEDTest.UseVisualStyleBackColor = True
        '
        'CheckBoxLEDTest
        '
        Me.CheckBoxLEDTest.AutoSize = True
        Me.CheckBoxLEDTest.Location = New System.Drawing.Point(7, 0)
        Me.CheckBoxLEDTest.Name = "CheckBoxLEDTest"
        Me.CheckBoxLEDTest.Size = New System.Drawing.Size(110, 17)
        Me.CheckBoxLEDTest.TabIndex = 154
        Me.CheckBoxLEDTest.Text = "Test LED ETSUP"
        Me.CheckBoxLEDTest.UseVisualStyleBackColor = True
        '
        'GroupBoxRFIDTest
        '
        Me.GroupBoxRFIDTest.BackColor = System.Drawing.Color.Black
        Me.GroupBoxRFIDTest.Controls.Add(Me.LinkLabelRFIDTestSetTarget2)
        Me.GroupBoxRFIDTest.Controls.Add(Me.LinkLabelRFIDTestSetTarget1)
        Me.GroupBoxRFIDTest.Controls.Add(Me.LabelRFIDTestStatus)
        Me.GroupBoxRFIDTest.Controls.Add(Me.ButtonsStartRFIDTest)
        Me.GroupBoxRFIDTest.Controls.Add(Me.TextBoxRFIDTestTarget2)
        Me.GroupBoxRFIDTest.Controls.Add(Me.CheckBoxRFIDTest)
        Me.GroupBoxRFIDTest.Controls.Add(Me.TextBoxRFIDTestTarget1)
        Me.GroupBoxRFIDTest.Location = New System.Drawing.Point(6, 6)
        Me.GroupBoxRFIDTest.Name = "GroupBoxRFIDTest"
        Me.GroupBoxRFIDTest.Size = New System.Drawing.Size(253, 111)
        Me.GroupBoxRFIDTest.TabIndex = 156
        Me.GroupBoxRFIDTest.TabStop = False
        '
        'LinkLabelRFIDTestSetTarget2
        '
        Me.LinkLabelRFIDTestSetTarget2.AutoSize = True
        Me.LinkLabelRFIDTestSetTarget2.LinkColor = System.Drawing.Color.White
        Me.LinkLabelRFIDTestSetTarget2.Location = New System.Drawing.Point(113, 52)
        Me.LinkLabelRFIDTestSetTarget2.Name = "LinkLabelRFIDTestSetTarget2"
        Me.LinkLabelRFIDTestSetTarget2.Size = New System.Drawing.Size(132, 13)
        Me.LinkLabelRFIDTestSetTarget2.TabIndex = 161
        Me.LinkLabelRFIDTestSetTarget2.TabStop = True
        Me.LinkLabelRFIDTestSetTarget2.Text = "UID target 2 (click to read)"
        '
        'LinkLabelRFIDTestSetTarget1
        '
        Me.LinkLabelRFIDTestSetTarget1.AutoSize = True
        Me.LinkLabelRFIDTestSetTarget1.LinkColor = System.Drawing.Color.White
        Me.LinkLabelRFIDTestSetTarget1.Location = New System.Drawing.Point(113, 26)
        Me.LinkLabelRFIDTestSetTarget1.Name = "LinkLabelRFIDTestSetTarget1"
        Me.LinkLabelRFIDTestSetTarget1.Size = New System.Drawing.Size(132, 13)
        Me.LinkLabelRFIDTestSetTarget1.TabIndex = 157
        Me.LinkLabelRFIDTestSetTarget1.TabStop = True
        Me.LinkLabelRFIDTestSetTarget1.Text = "UID target 1 (click to read)"
        '
        'LabelRFIDTestStatus
        '
        Me.LabelRFIDTestStatus.AutoSize = True
        Me.LabelRFIDTestStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelRFIDTestStatus.Location = New System.Drawing.Point(113, 78)
        Me.LabelRFIDTestStatus.Name = "LabelRFIDTestStatus"
        Me.LabelRFIDTestStatus.Size = New System.Drawing.Size(117, 15)
        Me.LabelRFIDTestStatus.TabIndex = 160
        Me.LabelRFIDTestStatus.Text = "UID letto: -STOP-"
        '
        'ButtonsStartRFIDTest
        '
        Me.ButtonsStartRFIDTest.ForeColor = System.Drawing.Color.Black
        Me.ButtonsStartRFIDTest.Location = New System.Drawing.Point(7, 75)
        Me.ButtonsStartRFIDTest.Name = "ButtonsStartRFIDTest"
        Me.ButtonsStartRFIDTest.Size = New System.Drawing.Size(100, 23)
        Me.ButtonsStartRFIDTest.TabIndex = 159
        Me.ButtonsStartRFIDTest.Text = "Avvia test"
        Me.ButtonsStartRFIDTest.UseVisualStyleBackColor = True
        '
        'TextBoxRFIDTestTarget2
        '
        Me.TextBoxRFIDTestTarget2.Location = New System.Drawing.Point(7, 49)
        Me.TextBoxRFIDTestTarget2.Name = "TextBoxRFIDTestTarget2"
        Me.TextBoxRFIDTestTarget2.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxRFIDTestTarget2.TabIndex = 157
        '
        'CheckBoxRFIDTest
        '
        Me.CheckBoxRFIDTest.AutoSize = True
        Me.CheckBoxRFIDTest.Location = New System.Drawing.Point(7, 0)
        Me.CheckBoxRFIDTest.Name = "CheckBoxRFIDTest"
        Me.CheckBoxRFIDTest.Size = New System.Drawing.Size(75, 17)
        Me.CheckBoxRFIDTest.TabIndex = 154
        Me.CheckBoxRFIDTest.Text = "Test RFID"
        Me.CheckBoxRFIDTest.UseVisualStyleBackColor = True
        '
        'TextBoxRFIDTestTarget1
        '
        Me.TextBoxRFIDTestTarget1.Location = New System.Drawing.Point(7, 23)
        Me.TextBoxRFIDTestTarget1.Name = "TextBoxRFIDTestTarget1"
        Me.TextBoxRFIDTestTarget1.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxRFIDTestTarget1.TabIndex = 155
        '
        'TabPage9
        '
        Me.TabPage9.Controls.Add(Me.GroupBox11)
        Me.TabPage9.Controls.Add(Me.GroupBox10)
        Me.TabPage9.Location = New System.Drawing.Point(4, 22)
        Me.TabPage9.Name = "TabPage9"
        Me.TabPage9.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage9.Size = New System.Drawing.Size(992, 195)
        Me.TabPage9.TabIndex = 5
        Me.TabPage9.Text = "Migrazione Mezzi"
        Me.TabPage9.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.ComboBox6)
        Me.GroupBox11.Controls.Add(Me.ComboBox5)
        Me.GroupBox11.Controls.Add(Me.Button6)
        Me.GroupBox11.Controls.Add(Me.Button7)
        Me.GroupBox11.Controls.Add(Me.Label32)
        Me.GroupBox11.Controls.Add(Me.Label33)
        Me.GroupBox11.Controls.Add(Me.Label34)
        Me.GroupBox11.Controls.Add(Me.Label35)
        Me.GroupBox11.Controls.Add(Me.Button8)
        Me.GroupBox11.Controls.Add(Me.Label36)
        Me.GroupBox11.Controls.Add(Me.ComboBox2)
        Me.GroupBox11.Location = New System.Drawing.Point(522, 6)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(464, 186)
        Me.GroupBox11.TabIndex = 1
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Nuovo Portale "
        '
        'ComboBox6
        '
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(68, 128)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox6.TabIndex = 11
        '
        'ComboBox5
        '
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(58, 98)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox5.TabIndex = 10
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(350, 29)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "IMPORT"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(82, 155)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 7
        Me.Button7.Text = "CERCA"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(7, 160)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(66, 13)
        Me.Label32.TabIndex = 6
        Me.Label32.Text = "4) RICERCA"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(7, 131)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(55, 13)
        Me.Label33.TabIndex = 5
        Me.Label33.Text = "3) SHEET"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(241, 34)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(103, 13)
        Me.Label34.TabIndex = 4
        Me.Label34.Text = "5) ESPORTAZIONE"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(7, 101)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(45, 13)
        Me.Label35.TabIndex = 3
        Me.Label35.Text = "2) UNIT"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(6, 60)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 2
        Me.Button8.Text = "Login"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(7, 29)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(69, 13)
        Me.Label36.TabIndex = 1
        Me.Label36.Text = "1) PORTALE"
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(82, 26)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox2.TabIndex = 0
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.TextBox1)
        Me.GroupBox10.Controls.Add(Me.ComboBox3)
        Me.GroupBox10.Controls.Add(Me.Button5)
        Me.GroupBox10.Controls.Add(Me.ButtonCercaDispostivi)
        Me.GroupBox10.Controls.Add(Me.ButtonLoginVecchioPortaleMig)
        Me.GroupBox10.Controls.Add(Me.ComboBox1)
        Me.GroupBox10.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(468, 186)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Vecchio Portale "
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(264, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(182, 161)
        Me.TextBox1.TabIndex = 12
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(6, 51)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox3.TabIndex = 9
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(6, 123)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(129, 26)
        Me.Button5.TabIndex = 8
        Me.Button5.Text = "EXPORT esportazione"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ButtonCercaDispostivi
        '
        Me.ButtonCercaDispostivi.Location = New System.Drawing.Point(6, 94)
        Me.ButtonCercaDispostivi.Name = "ButtonCercaDispostivi"
        Me.ButtonCercaDispostivi.Size = New System.Drawing.Size(103, 23)
        Me.ButtonCercaDispostivi.TabIndex = 7
        Me.ButtonCercaDispostivi.Text = "CERCA dispositivi"
        Me.ButtonCercaDispostivi.UseVisualStyleBackColor = True
        '
        'ButtonLoginVecchioPortaleMig
        '
        Me.ButtonLoginVecchioPortaleMig.Location = New System.Drawing.Point(133, 22)
        Me.ButtonLoginVecchioPortaleMig.Name = "ButtonLoginVecchioPortaleMig"
        Me.ButtonLoginVecchioPortaleMig.Size = New System.Drawing.Size(75, 23)
        Me.ButtonLoginVecchioPortaleMig.TabIndex = 2
        Me.ButtonLoginVecchioPortaleMig.Text = "Login"
        Me.ButtonLoginVecchioPortaleMig.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(6, 24)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'CheckboxFwEnable125Khz
        '
        Me.CheckboxFwEnable125Khz.AutoSize = True
        Me.CheckboxFwEnable125Khz.Location = New System.Drawing.Point(327, 139)
        Me.CheckboxFwEnable125Khz.Name = "CheckboxFwEnable125Khz"
        Me.CheckboxFwEnable125Khz.Size = New System.Drawing.Size(97, 17)
        Me.CheckboxFwEnable125Khz.TabIndex = 211
        Me.CheckboxFwEnable125Khz.Text = "125KHz reader"
        Me.CheckboxFwEnable125Khz.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(244, 81)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(73, 13)
        Me.LinkLabel1.TabIndex = 212
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Serial Number"
        '
        'PanelPWP
        '
        Me.PanelPWP.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PanelPWP.BackColor = System.Drawing.Color.White
        Me.PanelPWP.BackgroundImage = CType(resources.GetObject("PanelPWP.BackgroundImage"), System.Drawing.Image)
        Me.PanelPWP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PanelPWP.Controls.Add(Me.LabelPWP_msg)
        Me.PanelPWP.Controls.Add(Me.PictureBox2)
        Me.PanelPWP.Controls.Add(Me.PictureBox1)
        Me.PanelPWP.Controls.Add(Me.ButtonPWP_stop)
        Me.PanelPWP.Controls.Add(Me.ProgressBarPWP_total)
        Me.PanelPWP.Controls.Add(Me.ProgressBarPWP_current)
        Me.PanelPWP.Location = New System.Drawing.Point(662, 275)
        Me.PanelPWP.Name = "PanelPWP"
        Me.PanelPWP.Size = New System.Drawing.Size(350, 86)
        Me.PanelPWP.TabIndex = 214
        Me.PanelPWP.Tag = "DONTLOAD"
        Me.PanelPWP.Visible = False
        '
        'LabelPWP_msg
        '
        Me.LabelPWP_msg.BackColor = System.Drawing.Color.Transparent
        Me.LabelPWP_msg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelPWP_msg.Location = New System.Drawing.Point(30, 21)
        Me.LabelPWP_msg.Name = "LabelPWP_msg"
        Me.LabelPWP_msg.Size = New System.Drawing.Size(290, 45)
        Me.LabelPWP_msg.TabIndex = 2
        Me.LabelPWP_msg.Tag = "DONTLOAD"
        Me.LabelPWP_msg.Text = "Label123"
        Me.LabelPWP_msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(320, 21)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(30, 45)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 5
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Tag = "DONTLOAD"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Tag = "DONTLOAD"
        '
        'ButtonPWP_stop
        '
        Me.ButtonPWP_stop.BackColor = System.Drawing.Color.Transparent
        Me.ButtonPWP_stop.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonPWP_stop.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.ButtonPWP_stop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon
        Me.ButtonPWP_stop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red
        Me.ButtonPWP_stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPWP_stop.Location = New System.Drawing.Point(0, 0)
        Me.ButtonPWP_stop.Name = "ButtonPWP_stop"
        Me.ButtonPWP_stop.Size = New System.Drawing.Size(350, 21)
        Me.ButtonPWP_stop.TabIndex = 3
        Me.ButtonPWP_stop.Tag = "DONTLOAD"
        Me.ButtonPWP_stop.Text = "STOP"
        Me.ButtonPWP_stop.UseVisualStyleBackColor = False
        '
        'ProgressBarPWP_total
        '
        Me.ProgressBarPWP_total.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBarPWP_total.Location = New System.Drawing.Point(0, 66)
        Me.ProgressBarPWP_total.Name = "ProgressBarPWP_total"
        Me.ProgressBarPWP_total.Size = New System.Drawing.Size(350, 10)
        Me.ProgressBarPWP_total.TabIndex = 1
        Me.ProgressBarPWP_total.Tag = "DONTLOAD"
        '
        'ProgressBarPWP_current
        '
        Me.ProgressBarPWP_current.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBarPWP_current.Location = New System.Drawing.Point(0, 76)
        Me.ProgressBarPWP_current.Name = "ProgressBarPWP_current"
        Me.ProgressBarPWP_current.Size = New System.Drawing.Size(350, 10)
        Me.ProgressBarPWP_current.TabIndex = 0
        Me.ProgressBarPWP_current.Tag = "DONTLOAD"
        '
        'CheckBoxAutoUploadSerial
        '
        Me.CheckBoxAutoUploadSerial.AutoSize = True
        Me.CheckBoxAutoUploadSerial.Checked = True
        Me.CheckBoxAutoUploadSerial.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxAutoUploadSerial.Location = New System.Drawing.Point(362, 587)
        Me.CheckBoxAutoUploadSerial.Name = "CheckBoxAutoUploadSerial"
        Me.CheckBoxAutoUploadSerial.Size = New System.Drawing.Size(80, 17)
        Me.CheckBoxAutoUploadSerial.TabIndex = 215
        Me.CheckBoxAutoUploadSerial.Text = "Autoupload"
        Me.CheckBoxAutoUploadSerial.UseVisualStyleBackColor = True
        Me.CheckBoxAutoUploadSerial.Visible = False
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.ButtonGenerateCloudCode)
        Me.GroupBox6.Controls.Add(Me.Label26)
        Me.GroupBox6.Controls.Add(Me.CheckboxWriteCloudCode)
        Me.GroupBox6.Controls.Add(Me.TextboxCloudCode)
        Me.GroupBox6.Controls.Add(Me.TextBoxCloudPw)
        Me.GroupBox6.Location = New System.Drawing.Point(7, 93)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(314, 50)
        Me.GroupBox6.TabIndex = 216
        Me.GroupBox6.TabStop = False
        '
        'ButtonGenerateCloudCode
        '
        Me.ButtonGenerateCloudCode.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonGenerateCloudCode.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonGenerateCloudCode.Location = New System.Drawing.Point(239, 9)
        Me.ButtonGenerateCloudCode.Name = "ButtonGenerateCloudCode"
        Me.ButtonGenerateCloudCode.Size = New System.Drawing.Size(68, 24)
        Me.ButtonGenerateCloudCode.TabIndex = 227
        Me.ButtonGenerateCloudCode.Text = "Genera cc"
        Me.ButtonGenerateCloudCode.UseVisualStyleBackColor = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(24, 33)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(150, 13)
        Me.Label26.TabIndex = 188
        Me.Label26.Text = "Formato: 2 caratteri + 3 numeri"
        '
        'CheckboxFwEnable5Gh
        '
        Me.CheckboxFwEnable5Gh.AutoSize = True
        Me.CheckboxFwEnable5Gh.Location = New System.Drawing.Point(327, 114)
        Me.CheckboxFwEnable5Gh.Name = "CheckboxFwEnable5Gh"
        Me.CheckboxFwEnable5Gh.Size = New System.Drawing.Size(77, 17)
        Me.CheckboxFwEnable5Gh.TabIndex = 217
        Me.CheckboxFwEnable5Gh.Text = "WiFi 5GHz"
        Me.CheckboxFwEnable5Gh.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(38, 248)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(136, 23)
        Me.Button3.TabIndex = 218
        Me.Button3.Text = "Leggi versione firmware"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'LabelMongoStatus
        '
        Me.LabelMongoStatus.Location = New System.Drawing.Point(709, 587)
        Me.LabelMongoStatus.Name = "LabelMongoStatus"
        Me.LabelMongoStatus.Size = New System.Drawing.Size(299, 13)
        Me.LabelMongoStatus.TabIndex = 221
        Me.LabelMongoStatus.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'LinkLabelCancelMongo
        '
        Me.LinkLabelCancelMongo.Enabled = False
        Me.LinkLabelCancelMongo.LinkColor = System.Drawing.Color.Red
        Me.LinkLabelCancelMongo.Location = New System.Drawing.Point(709, 582)
        Me.LinkLabelCancelMongo.Name = "LinkLabelCancelMongo"
        Me.LinkLabelCancelMongo.Size = New System.Drawing.Size(299, 15)
        Me.LinkLabelCancelMongo.TabIndex = 222
        Me.LinkLabelCancelMongo.TabStop = True
        Me.LinkLabelCancelMongo.Text = "Annulla l'ultima statistica"
        Me.LinkLabelCancelMongo.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.LinkLabelCancelMongo.VisitedLinkColor = System.Drawing.Color.Red
        '
        'TabControl3
        '
        Me.TabControl3.Controls.Add(Me.TabPage7)
        Me.TabControl3.Controls.Add(Me.TabPage8)
        Me.TabControl3.Location = New System.Drawing.Point(804, 3)
        Me.TabControl3.Multiline = True
        Me.TabControl3.Name = "TabControl3"
        Me.TabControl3.SelectedIndex = 0
        Me.TabControl3.Size = New System.Drawing.Size(219, 139)
        Me.TabControl3.TabIndex = 223
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.ListBoxSeriali)
        Me.TabPage7.Controls.Add(Me.LabelSerialiDaRecuperare)
        Me.TabPage7.Controls.Add(Me.ButtonCLearOldSerial)
        Me.TabPage7.Controls.Add(Me.ButtonCreateCSV)
        Me.TabPage7.Location = New System.Drawing.Point(4, 22)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage7.Size = New System.Drawing.Size(211, 113)
        Me.TabPage7.TabIndex = 0
        Me.TabPage7.Text = "Seriali"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.ButtonExportCodiciCloud)
        Me.TabPage8.Controls.Add(Me.ListBoxCodiciCloud)
        Me.TabPage8.Controls.Add(Me.ButtonCLearOldCodiciCloud)
        Me.TabPage8.Location = New System.Drawing.Point(4, 22)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage8.Size = New System.Drawing.Size(211, 113)
        Me.TabPage8.TabIndex = 1
        Me.TabPage8.Text = "Codici cloud"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'ButtonExportCodiciCloud
        '
        Me.ButtonExportCodiciCloud.Location = New System.Drawing.Point(139, 143)
        Me.ButtonExportCodiciCloud.Name = "ButtonExportCodiciCloud"
        Me.ButtonExportCodiciCloud.Size = New System.Drawing.Size(71, 59)
        Me.ButtonExportCodiciCloud.TabIndex = 206
        Me.ButtonExportCodiciCloud.Text = "Esporta in Excel"
        Me.ButtonExportCodiciCloud.UseVisualStyleBackColor = True
        '
        'ListBoxCodiciCloud
        '
        Me.ListBoxCodiciCloud.FormattingEnabled = True
        Me.ListBoxCodiciCloud.Location = New System.Drawing.Point(1, 3)
        Me.ListBoxCodiciCloud.Name = "ListBoxCodiciCloud"
        Me.ListBoxCodiciCloud.Size = New System.Drawing.Size(132, 199)
        Me.ListBoxCodiciCloud.TabIndex = 168
        '
        'ButtonCLearOldCodiciCloud
        '
        Me.ButtonCLearOldCodiciCloud.Location = New System.Drawing.Point(139, 3)
        Me.ButtonCLearOldCodiciCloud.Name = "ButtonCLearOldCodiciCloud"
        Me.ButtonCLearOldCodiciCloud.Size = New System.Drawing.Size(71, 135)
        Me.ButtonCLearOldCodiciCloud.TabIndex = 169
        Me.ButtonCLearOldCodiciCloud.Text = "<--Cancella"
        Me.ButtonCLearOldCodiciCloud.UseVisualStyleBackColor = True
        '
        'ButtonCollaudo
        '
        Me.ButtonCollaudo.BackColor = System.Drawing.Color.SkyBlue
        Me.ButtonCollaudo.Location = New System.Drawing.Point(12, 336)
        Me.ButtonCollaudo.Name = "ButtonCollaudo"
        Me.ButtonCollaudo.Size = New System.Drawing.Size(273, 23)
        Me.ButtonCollaudo.TabIndex = 3
        Me.ButtonCollaudo.Text = "Collaudo"
        Me.ButtonCollaudo.UseVisualStyleBackColor = False
        '
        'CheckboxFwEnableGPSUblox
        '
        Me.CheckboxFwEnableGPSUblox.AutoSize = True
        Me.CheckboxFwEnableGPSUblox.Location = New System.Drawing.Point(489, 149)
        Me.CheckboxFwEnableGPSUblox.Name = "CheckboxFwEnableGPSUblox"
        Me.CheckboxFwEnableGPSUblox.Size = New System.Drawing.Size(78, 17)
        Me.CheckboxFwEnableGPSUblox.TabIndex = 224
        Me.CheckboxFwEnableGPSUblox.Text = "GPS Ublox"
        Me.CheckboxFwEnableGPSUblox.UseVisualStyleBackColor = True
        Me.CheckboxFwEnableGPSUblox.Visible = False
        '
        'CheckBoxJlink
        '
        Me.CheckBoxJlink.AutoSize = True
        Me.CheckBoxJlink.Location = New System.Drawing.Point(251, 48)
        Me.CheckBoxJlink.Name = "CheckBoxJlink"
        Me.CheckBoxJlink.Size = New System.Drawing.Size(55, 17)
        Me.CheckBoxJlink.TabIndex = 225
        Me.CheckBoxJlink.Text = "JLINK"
        Me.CheckBoxJlink.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(61, 4)
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(61, 4)
        '
        'ButtonGenerateSerialNumber
        '
        Me.ButtonGenerateSerialNumber.BackColor = System.Drawing.SystemColors.Highlight
        Me.ButtonGenerateSerialNumber.Enabled = False
        Me.ButtonGenerateSerialNumber.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.ButtonGenerateSerialNumber.Location = New System.Drawing.Point(139, 66)
        Me.ButtonGenerateSerialNumber.Name = "ButtonGenerateSerialNumber"
        Me.ButtonGenerateSerialNumber.Size = New System.Drawing.Size(94, 24)
        Me.ButtonGenerateSerialNumber.TabIndex = 226
        Me.ButtonGenerateSerialNumber.Text = "Genera seriale"
        Me.ButtonGenerateSerialNumber.UseVisualStyleBackColor = False
        '
        'ButtonForceAutoNext
        '
        Me.ButtonForceAutoNext.BackColor = System.Drawing.Color.DodgerBlue
        Me.ButtonForceAutoNext.Enabled = False
        Me.ButtonForceAutoNext.ForeColor = System.Drawing.Color.White
        Me.ButtonForceAutoNext.Location = New System.Drawing.Point(276, 585)
        Me.ButtonForceAutoNext.Name = "ButtonForceAutoNext"
        Me.ButtonForceAutoNext.Size = New System.Drawing.Size(75, 23)
        Me.ButtonForceAutoNext.TabIndex = 213
        Me.ButtonForceAutoNext.Text = "Next (F5)"
        Me.ButtonForceAutoNext.UseVisualStyleBackColor = False
        Me.ButtonForceAutoNext.Visible = False
        '
        'TextboxSerialNumber
        '
        Me.TextboxSerialNumber.Location = New System.Drawing.Point(33, 68)
        Me.TextboxSerialNumber.Name = "TextboxSerialNumber"
        Me.TextboxSerialNumber.Size = New System.Drawing.Size(100, 20)
        Me.TextboxSerialNumber.TabIndex = 227
        '
        'CheckBoxPEAK
        '
        Me.CheckBoxPEAK.AutoSize = True
        Me.CheckBoxPEAK.Location = New System.Drawing.Point(251, 67)
        Me.CheckBoxPEAK.Name = "CheckBoxPEAK"
        Me.CheckBoxPEAK.Size = New System.Drawing.Size(54, 17)
        Me.CheckBoxPEAK.TabIndex = 228
        Me.CheckBoxPEAK.Text = "PEAK"
        Me.CheckBoxPEAK.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(852, 188)
        Me.Button2.Margin = New System.Windows.Forms.Padding(2)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 19)
        Me.Button2.TabIndex = 229
        Me.Button2.Text = "PEAK POC"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(319, 333)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 230
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 615)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CheckBoxPEAK)
        Me.Controls.Add(Me.TextboxSerialNumber)
        Me.Controls.Add(Me.ButtonGenerateSerialNumber)
        Me.Controls.Add(Me.CheckBoxJlink)
        Me.Controls.Add(Me.CheckboxFwEnableGPSUblox)
        Me.Controls.Add(Me.ButtonCollaudo)
        Me.Controls.Add(Me.TabControl3)
        Me.Controls.Add(Me.LinkLabelCancelMongo)
        Me.Controls.Add(Me.LabelMongoStatus)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CheckboxFwEnable5Gh)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.PanelPWP)
        Me.Controls.Add(Me.CheckBoxAutoUploadSerial)
        Me.Controls.Add(Me.ButtonForceAutoNext)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.CheckboxFwEnable125Khz)
        Me.Controls.Add(Me.LabelFlasingFw)
        Me.Controls.Add(Me.CheckBoxClearAllarmi)
        Me.Controls.Add(Me.ComboBoxLabelType)
        Me.Controls.Add(Me.CheckboxFwEnableTouch)
        Me.Controls.Add(Me.LabelWaitForMDT)
        Me.Controls.Add(Me.LabelFwVersions)
        Me.Controls.Add(Me.TextBoxAnalPrefix)
        Me.Controls.Add(Me.CheckBoxSerialAnagrafica)
        Me.Controls.Add(Me.CheckboxFormatSD)
        Me.Controls.Add(Me.CheckBoxInitETS)
        Me.Controls.Add(Me.ComboBoxConf)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CheckboxFwEnableKbd)
        Me.Controls.Add(Me.TextBoxNodoCAN)
        Me.Controls.Add(Me.CheckBoxCAN)
        Me.Controls.Add(Me.CheckboxFwEnableFps)
        Me.Controls.Add(Me.LabelAction)
        Me.Controls.Add(Me.LabelStatus)
        Me.Controls.Add(Me.LBVersioneHW)
        Me.Controls.Add(Me.GroupBoxHWSetup)
        Me.Controls.Add(Me.PBRX)
        Me.Controls.Add(Me.PBTX)
        Me.Controls.Add(Me.CheckBoxAutoUSB_SET)
        Me.Controls.Add(Me.ButtonUpdateFile)
        Me.Controls.Add(Me.CheckboxFwEnableModSD)
        Me.Controls.Add(Me.CheckboxFwEnableModGps)
        Me.Controls.Add(Me.LprodString)
        Me.Controls.Add(Me.CheckboxWriteProductString)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TBGPSVersion)
        Me.Controls.Add(Me.CheckboxWriteGpsVersion)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TextboxHardwareCode)
        Me.Controls.Add(Me.CheckboxWriteHardwareCode)
        Me.Controls.Add(Me.CheckboxWriteSerialNumber)
        Me.Controls.Add(Me.ButtonStop)
        Me.Controls.Add(Me.BAggiornaCP)
        Me.Controls.Add(Me.LSincDataOra)
        Me.Controls.Add(Me.CheckboxSyncDatetime)
        Me.Controls.Add(Me.PBSincDataOra)
        Me.Controls.Add(Me.LCalibrazione)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.CBCalibrazione)
        Me.Controls.Add(Me.PBCalibrazione)
        Me.Controls.Add(Me.BSNPS)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TextboxCPProductString)
        Me.Controls.Add(Me.TextboxCPSerialNumber)
        Me.Controls.Add(Me.CBVidPidSN)
        Me.Controls.Add(Me.DropdownDevicesProfiles)
        Me.Controls.Add(Me.LNomeNuovoFirmware)
        Me.Controls.Add(Me.CBTestAccel)
        Me.Controls.Add(Me.CBTestGPS)
        Me.Controls.Add(Me.CBTestHR)
        Me.Controls.Add(Me.CheckboxCA)
        Me.Controls.Add(Me.CheckboxFlashFirmware)
        Me.Controls.Add(Me.CheckboxFlashBootloader)
        Me.Controls.Add(Me.LAccelerometro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PBAcclrmtr)
        Me.Controls.Add(Me.LTestGPS)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PBGPS)
        Me.Controls.Add(Me.LInvioHR)
        Me.Controls.Add(Me.LConfigurazioneAutomatica)
        Me.Controls.Add(Me.LFlashingBootloader)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PBHR)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.PBConf)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.PBF)
        Me.Controls.Add(Me.ButtonStart)
        Me.Controls.Add(Me.DropdownComPorts)
        Me.Controls.Add(Me.LCom)
        Me.Controls.Add(Me.LPing)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.PBFU)
        Me.Controls.Add(Me.TabControlMigrazione)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Main"
        Me.Text = "Testing MDT!"
        Me.GroupBoxHWSetup.ResumeLayout(False)
        Me.GroupBoxHWSetup.PerformLayout()
        Me.GroupBoxNewValues.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NumericUpDownValoriCount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage5.ResumeLayout(False)
        CType(Me.DataGridViewRemoteLol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.DataGridViewRemoteLolMinHR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBRX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PBTX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlMigrazione.ResumeLayout(False)
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBoxGRSatLogin.ResumeLayout(False)
        Me.GroupBoxGRSatLogin.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.TabPageTestAutomatici.ResumeLayout(False)
        Me.GroupBoxTelitTest.ResumeLayout(False)
        Me.GroupBoxTelitTest.PerformLayout()
        Me.GroupBoxGPRSTest.ResumeLayout(False)
        Me.GroupBoxGPRSTest.PerformLayout()
        Me.GroupBoxLEDTest.ResumeLayout(False)
        Me.GroupBoxLEDTest.PerformLayout()
        Me.GroupBoxRFIDTest.ResumeLayout(False)
        Me.GroupBoxRFIDTest.PerformLayout()
        Me.TabPage9.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.PanelPWP.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabControl3.ResumeLayout(False)
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage8.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SerialPort As System.IO.Ports.SerialPort
    Friend WithEvents LPing As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TCicloSistema As System.Windows.Forms.Timer
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents DropdownComPorts As System.Windows.Forms.ComboBox
    Friend WithEvents LCom As System.Windows.Forms.Label
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PBF As System.Windows.Forms.ProgressBar
    Friend WithEvents PBFU As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PBConf As System.Windows.Forms.ProgressBar
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PBHR As System.Windows.Forms.ProgressBar
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LFlashingBootloader As System.Windows.Forms.Label
    Friend WithEvents LConfigurazioneAutomatica As System.Windows.Forms.Label
    Friend WithEvents LInvioHR As System.Windows.Forms.Label
    Friend WithEvents PBGPS As System.Windows.Forms.ProgressBar
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LTestGPS As System.Windows.Forms.Label
    Friend WithEvents PBAcclrmtr As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LAccelerometro As System.Windows.Forms.Label
    Friend WithEvents CheckboxFlashBootloader As System.Windows.Forms.CheckBox
    Friend WithEvents CheckboxFlashFirmware As System.Windows.Forms.CheckBox
    Friend WithEvents CheckboxCA As System.Windows.Forms.CheckBox
    Friend WithEvents CBTestHR As System.Windows.Forms.CheckBox
    Friend WithEvents CBTestGPS As System.Windows.Forms.CheckBox
    Friend WithEvents CBTestAccel As System.Windows.Forms.CheckBox
    Friend WithEvents LNomeNuovoFirmware As System.Windows.Forms.Label
    Friend WithEvents DropdownDevicesProfiles As System.Windows.Forms.ComboBox
    Friend WithEvents CBVidPidSN As System.Windows.Forms.ComboBox
    Friend WithEvents TextboxCPSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents TextboxCPProductString As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents BSNPS As System.Windows.Forms.Button
    Friend WithEvents PBCalibrazione As System.Windows.Forms.ProgressBar
    Friend WithEvents CBCalibrazione As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents LCalibrazione As System.Windows.Forms.Label
    Friend WithEvents CheckboxSyncDatetime As System.Windows.Forms.CheckBox
    Friend WithEvents LSincDataOra As System.Windows.Forms.Label
    Friend WithEvents BAggiornaCP As System.Windows.Forms.Button
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents CheckboxWriteSerialNumber As System.Windows.Forms.CheckBox
    Friend WithEvents CheckboxWriteHardwareCode As System.Windows.Forms.CheckBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TextboxHardwareCode As System.Windows.Forms.TextBox
    Friend WithEvents CheckboxWriteGpsVersion As System.Windows.Forms.CheckBox
    Friend WithEvents TBGPSVersion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LprodString As System.Windows.Forms.Label
    Friend WithEvents CheckboxWriteProductString As System.Windows.Forms.CheckBox
    Friend WithEvents CheckboxFwEnableModGps As System.Windows.Forms.CheckBox
    Friend WithEvents CheckboxFwEnableModSD As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonUpdateFile As System.Windows.Forms.Button
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents CheckBoxAutoUSB_SET As System.Windows.Forms.CheckBox
    Friend WithEvents ListBoxSeriali As System.Windows.Forms.ListBox
    Friend WithEvents ButtonCLearOldSerial As System.Windows.Forms.Button
    Friend WithEvents PBTX As System.Windows.Forms.PictureBox
    Friend WithEvents PBRX As System.Windows.Forms.PictureBox
    Friend WithEvents CheckboxHwEnableWifi As System.Windows.Forms.CheckBox
    Friend WithEvents CheckboxHwEnableGPRS As System.Windows.Forms.CheckBox
    Friend WithEvents CheckboxHwEnableGPS As System.Windows.Forms.CheckBox
    Friend WithEvents CheckboxHwEnableSD As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxHWSetup As System.Windows.Forms.GroupBox
    Friend WithEvents CheckboxHWSetup As System.Windows.Forms.CheckBox
    Friend WithEvents LabelHwSetup As System.Windows.Forms.Label
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents LabelAction As System.Windows.Forms.Label
    Friend WithEvents CheckBoxCAN As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxNodoCAN As System.Windows.Forms.TextBox
    Friend WithEvents CheckboxFwEnableKbd As System.Windows.Forms.CheckBox
    Friend WithEvents CheckboxFwEnableFps As System.Windows.Forms.CheckBox
    Friend WithEvents LBVersioneHW As System.Windows.Forms.Label
    Friend WithEvents CheckBoxHWSetupMoved As System.Windows.Forms.CheckBox
    Friend WithEvents CBOTG As CheckBox
    Friend WithEvents ProgressBarOTG As ProgressBar
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBoxOTGPAth As TextBox
    Friend WithEvents ComboBoxConf As ComboBox
    Friend WithEvents CheckBoxInitETS As CheckBox
    Friend WithEvents PBSincDataOra As ProgressBar
    Friend WithEvents CheckboxFormatSD As CheckBox
    Friend WithEvents CheckboxWriteCloudCode As CheckBox
    Friend WithEvents TextboxCloudCode As TextBox
    Friend WithEvents TextBoxCloudPw As TextBox
    Friend WithEvents CheckBoxSerialAnagrafica As CheckBox
    Friend WithEvents GroupBoxNewValues As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FlowLayoutPanelValue As FlowLayoutPanel
    Friend WithEvents FlowLayoutPanelOffset As FlowLayoutPanel
    Friend WithEvents Labelquest As Label
    Friend WithEvents NumericUpDownValoriCount As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents FlowLayoutPanelComando As FlowLayoutPanel
    Friend WithEvents TextBoxAnalPrefix As TextBox
    Friend WithEvents LabelFwVersions As Label
    Friend WithEvents LabelWaitForMDT As Label
    Friend WithEvents CheckboxHwEnableCartellino As CheckBox
    Friend WithEvents CheckboxFwEnableTouch As CheckBox
    Friend WithEvents CheckBoxHack As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CheckBoxDivineSync As CheckBox
    Friend WithEvents DataGridViewRemoteLol As DataGridView
    Friend WithEvents TextBoxRemoteLOLID As TextBox
    Friend WithEvents TimerHeartRate As Timer
    Friend WithEvents CheckBoxRemoteLolMaster As CheckBox
    Friend WithEvents LabelSerialiDaRecuperare As Label
    Friend WithEvents ButtonCreateCSV As Button
    Friend WithEvents ComboBoxLabelType As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents ID As DataGridViewTextBoxColumn
    Friend WithEvents IP As DataGridViewTextBoxColumn
    Friend WithEvents IsMaster As DataGridViewTextBoxColumn
    Friend WithEvents Status As DataGridViewTextBoxColumn
    Friend WithEvents ConfirmedDevice As DataGridViewTextBoxColumn
    Friend WithEvents ConfirmedHW As DataGridViewTextBoxColumn
    Friend WithEvents ConfirmedSerial As DataGridViewTextBoxColumn
    Friend WithEvents CurrentSerial As DataGridViewTextBoxColumn
    Friend WithEvents NeedsNewSerial As DataGridViewTextBoxColumn
    Friend WithEvents ConfirmedEtichettaData As DataGridViewTextBoxColumn
    Friend WithEvents LastSeen As DataGridViewTextBoxColumn
    Friend WithEvents CheckBoxClearAllarmi As CheckBox
    Friend WithEvents ButtonUpdateWiFly As Button
    Friend WithEvents ButtonReadWiFly As Button
    Friend WithEvents LabelFlasingFw As Label
    Friend WithEvents FlowLayoutPanelSerializza As FlowLayoutPanel
    Friend WithEvents TabControlMigrazione As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents ButtonBLESETId As Button
    Friend WithEvents CheckboxFwEnable125Khz As CheckBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents GroupBoxGRSatLogin As GroupBox
    Friend WithEvents LabelGRSatLoginStatus As Label
    Friend WithEvents ButtonGRSatLogin As Button
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents LabelPredictionLoginStatus As Label
    Friend WithEvents ButtonPredictionLogin As Button
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TextboxPredictionPassword As TextBox
    Friend WithEvents TextboxPredictionUsername As TextBox
    Friend WithEvents ButtonStorePredictionLogin As Button
    Friend WithEvents PanelPWP As Panel
    Friend WithEvents LabelPWP_msg As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ButtonPWP_stop As Button
    Friend WithEvents ProgressBarPWP_total As ProgressBar
    Friend WithEvents ProgressBarPWP_current As ProgressBar
    Friend WithEvents LinkLabelUpdateGRSatList As LinkLabel
    Friend WithEvents DropdownGRSatSelection As ComboBox
    Friend WithEvents CheckBoxAutoUploadSerial As CheckBox
    Friend WithEvents TabPage4 As TabPage
    'Friend WithEvents TabPageMigrazoneMezzi As TabPage
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents CheckboxCreateDeviceOnGRSat As CheckBox
    Friend WithEvents CheckBoxTestInvioCloud As CheckBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents LinkLabelAssetLoadSheets As LinkLabel
    Friend WithEvents LinkLabelAssetLoadUnits As LinkLabel
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents CBAssetUses As CheckBox
    Friend WithEvents CBAssetRSSI As CheckBox
    Friend WithEvents CBAssetChart As CheckBox
    Friend WithEvents CBAssetAlarm As CheckBox
    Friend WithEvents CBAssetDummy As CheckBox
    Friend WithEvents CBAssetInspector As CheckBox
    Friend WithEvents CBAssetGPS As CheckBox
    Friend WithEvents CBAssetRoutes As CheckBox
    Friend WithEvents CBAssetMap As CheckBox
    Friend WithEvents CBAssetProfile As CheckBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents TBAssetDesc As TextBox
    Friend WithEvents TBAssetBrand As TextBox
    Friend WithEvents TBAssetSerial As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents TBAssetModel As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents TBAssetPlate As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents CBAssetSheet As ComboBox
    Friend WithEvents CBAssetUnit As ComboBox
    Friend WithEvents ButtonAssetCreate As Button
    Friend WithEvents CheckBoxAutoFillAssetData As CheckBox
    Friend WithEvents CBAssetMeter2Spn As ComboBox
    Friend WithEvents CBAssetMeter2 As CheckBox
    Friend WithEvents CBAssetMeter1Spn As ComboBox
    Friend WithEvents CBAssetMeter1 As CheckBox
    Friend WithEvents LinkLabelGoToGRsat As LinkLabel
    Friend WithEvents RBOTGLAST As RadioButton
    Friend WithEvents RBOTGNOW As RadioButton
    Friend WithEvents TabPageTestAutomatici As TabPage
    Friend WithEvents GroupBoxRFIDTest As GroupBox
    Friend WithEvents TextBoxRFIDTestTarget1 As TextBox
    Friend WithEvents CheckBoxRFIDTest As CheckBox
    Friend WithEvents LabelRFIDTestStatus As Label
    Friend WithEvents ButtonsStartRFIDTest As Button
    Friend WithEvents TextBoxRFIDTestTarget2 As TextBox
    Friend WithEvents LinkLabelRFIDTestSetTarget2 As LinkLabel
    Friend WithEvents LinkLabelRFIDTestSetTarget1 As LinkLabel
    Friend WithEvents TabControl2 As TabControl
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents DataGridViewRemoteLolMinHR As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents CheckboxFwEnable5Gh As CheckBox
    Friend WithEvents GroupBoxLEDTest As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonsStartLEDTest As Button
    Friend WithEvents CheckBoxLEDTest As CheckBox
    Friend WithEvents GroupBoxGPRSTest As GroupBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LabelGPRSTestStatus As Label
    Friend WithEvents ButtonsStartGPRSTest As Button
    Friend WithEvents CheckBoxGPRSTest As CheckBox
    Friend WithEvents TextBoxGPRSTestPin As TextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents TextBoxGPRSTestAPN As TextBox
    Friend WithEvents ButtonBLERP0 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents GroupBoxTelitTest As GroupBox
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents TextBoxTelitGPS_Vok As TextBox
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents TextBoxTelitGPRS_Vok As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents ButtonsStarTelitVTest As Button
    Friend WithEvents CheckBoxTelitVTest As CheckBox
    Friend WithEvents LabelTelitSTestStatus As Label
    Friend WithEvents ButtonMongo As Button
    Friend WithEvents CheckBoxSendMongo As CheckBox
    Friend WithEvents ButtonDivineETSCANBaudSet As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents TextboxPredictionHost As TextBox
    Friend WithEvents LabelMongoStatus As Label
    Friend WithEvents LinkLabelCancelMongo As LinkLabel
    Friend WithEvents TabControl3 As TabControl
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents ListBoxCodiciCloud As ListBox
    Friend WithEvents ButtonCLearOldCodiciCloud As Button
    Friend WithEvents ButtonExportCodiciCloud As Button
    Friend WithEvents CheckboxConfigureDeviceOnGRSat As CheckBox
    Friend WithEvents ButtonDivineETSDNAssoc As Button
    Friend WithEvents ButtonDivineETSSetUser As Button
    Friend WithEvents Label26 As Label
    Friend WithEvents ButtonCollaudo As Button
    Friend WithEvents CheckboxFwEnableGPSUblox As CheckBox
    Friend WithEvents CheckBoxJlink As CheckBox
    Friend WithEvents TabPage9 As TabPage
    Friend WithEvents GroupBox10 As GroupBox
    Friend WithEvents ButtonLoginVecchioPortaleMig As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip2 As ContextMenuStrip
    Friend WithEvents ContextMenuStrip3 As ContextMenuStrip
    Friend WithEvents Button5 As Button
    Friend WithEvents ButtonCercaDispostivi As Button
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Label32 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents Label36 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox6 As ComboBox
    Friend WithEvents ComboBox5 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ButtonGenerateSerialNumber As Button
    Friend WithEvents ButtonForceAutoNext As Button
    Friend WithEvents ButtonGenerateCloudCode As Button
    Friend WithEvents TextboxSerialNumber As TextBox
    Friend WithEvents CheckBoxPEAK As CheckBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
End Class
