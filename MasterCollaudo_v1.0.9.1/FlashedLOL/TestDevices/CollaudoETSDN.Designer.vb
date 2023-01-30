<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainEtsdn
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
        Me.lblPower = New System.Windows.Forms.Label()
        Me.ckBox_Pwr = New System.Windows.Forms.CheckBox()
        Me.ckBox_Rele = New System.Windows.Forms.CheckBox()
        Me.LabelRL3 = New System.Windows.Forms.Label()
        Me.LabelRL2 = New System.Windows.Forms.Label()
        Me.LabelRL1 = New System.Windows.Forms.Label()
        Me.ckBox_IP = New System.Windows.Forms.CheckBox()
        Me.ANAVolt10 = New System.Windows.Forms.Label()
        Me.ANAVolt5 = New System.Windows.Forms.Label()
        Me.ckBox_5v = New System.Windows.Forms.CheckBox()
        Me.lbl5V = New System.Windows.Forms.Label()
        Me.ckBox_Acc = New System.Windows.Forms.CheckBox()
        Me.accX = New System.Windows.Forms.Label()
        Me.accY = New System.Windows.Forms.Label()
        Me.accZ = New System.Windows.Forms.Label()
        Me.MsgTestAcc = New System.Windows.Forms.Label()
        Me.TestingSerial = New System.Windows.Forms.Label()
        Me.BarTestEtsdn = New System.Windows.Forms.ProgressBar()
        Me.ckBox_Ana = New System.Windows.Forms.CheckBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ckBox_Tutti = New System.Windows.Forms.CheckBox()
        Me.LblNameOperator = New System.Windows.Forms.Label()
        Me.cbox_listSerialPort = New System.Windows.Forms.ComboBox()
        Me.cbox_select_voltage = New System.Windows.Forms.ComboBox()
        Me.pbox_buttonPower = New System.Windows.Forms.PictureBox()
        Me.pBox_IN2 = New System.Windows.Forms.PictureBox()
        Me.pBox_IN1 = New System.Windows.Forms.PictureBox()
        Me.pBox_IP2 = New System.Windows.Forms.PictureBox()
        Me.pBox_IP1 = New System.Windows.Forms.PictureBox()
        Me.btnHide_Show = New System.Windows.Forms.PictureBox()
        Me.pBox_Etsdn = New System.Windows.Forms.PictureBox()
        Me.StatoTestAnalog = New System.Windows.Forms.PictureBox()
        Me.StatoTestAccellerometro = New System.Windows.Forms.PictureBox()
        Me.StatoTest5V = New System.Windows.Forms.PictureBox()
        Me.pnlAcc = New System.Windows.Forms.PictureBox()
        Me.pnl5V = New System.Windows.Forms.PictureBox()
        Me.pnlAnalog = New System.Windows.Forms.PictureBox()
        Me.StatoTestIngressi = New System.Windows.Forms.PictureBox()
        Me.pnlInputs = New System.Windows.Forms.PictureBox()
        Me.StatotestRele = New System.Windows.Forms.PictureBox()
        Me.StatoTestAlimentazione = New System.Windows.Forms.PictureBox()
        Me.pnlRele = New System.Windows.Forms.PictureBox()
        Me.pnlPower = New System.Windows.Forms.PictureBox()
        Me.pBoxStart = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pBoxStop = New System.Windows.Forms.PictureBox()
        Me.btn_set_voltage = New System.Windows.Forms.Button()
        Me.pbox_Ana5v = New System.Windows.Forms.PictureBox()
        Me.pbox_Ana10v = New System.Windows.Forms.PictureBox()
        CType(Me.pbox_buttonPower, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBox_IN2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBox_IN1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBox_IP2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBox_IP1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.btnHide_Show, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBox_Etsdn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatoTestAnalog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatoTestAccellerometro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatoTest5V, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlAcc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnl5V, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlAnalog, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatoTestIngressi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlInputs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatotestRele, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StatoTestAlimentazione, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlRele, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pnlPower, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBoxStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBoxStop, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbox_Ana5v, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbox_Ana10v, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPower
        '
        Me.lblPower.AutoSize = True
        Me.lblPower.BackColor = System.Drawing.Color.White
        Me.lblPower.Location = New System.Drawing.Point(111, 185)
        Me.lblPower.MinimumSize = New System.Drawing.Size(45, 15)
        Me.lblPower.Name = "lblPower"
        Me.lblPower.Size = New System.Drawing.Size(45, 15)
        Me.lblPower.TabIndex = 22
        '
        'ckBox_Pwr
        '
        Me.ckBox_Pwr.AutoSize = True
        Me.ckBox_Pwr.BackColor = System.Drawing.Color.Transparent
        Me.ckBox_Pwr.Checked = True
        Me.ckBox_Pwr.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckBox_Pwr.Location = New System.Drawing.Point(21, 126)
        Me.ckBox_Pwr.Name = "ckBox_Pwr"
        Me.ckBox_Pwr.Size = New System.Drawing.Size(15, 14)
        Me.ckBox_Pwr.TabIndex = 157
        Me.ckBox_Pwr.UseVisualStyleBackColor = False
        '
        'ckBox_Rele
        '
        Me.ckBox_Rele.AutoSize = True
        Me.ckBox_Rele.Checked = True
        Me.ckBox_Rele.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckBox_Rele.Location = New System.Drawing.Point(280, 126)
        Me.ckBox_Rele.Name = "ckBox_Rele"
        Me.ckBox_Rele.Size = New System.Drawing.Size(15, 14)
        Me.ckBox_Rele.TabIndex = 156
        Me.ckBox_Rele.UseVisualStyleBackColor = True
        '
        'LabelRL3
        '
        Me.LabelRL3.AutoSize = True
        Me.LabelRL3.BackColor = System.Drawing.Color.White
        Me.LabelRL3.Location = New System.Drawing.Point(382, 202)
        Me.LabelRL3.MinimumSize = New System.Drawing.Size(45, 15)
        Me.LabelRL3.Name = "LabelRL3"
        Me.LabelRL3.Size = New System.Drawing.Size(45, 15)
        Me.LabelRL3.TabIndex = 120
        '
        'LabelRL2
        '
        Me.LabelRL2.AutoSize = True
        Me.LabelRL2.BackColor = System.Drawing.Color.White
        Me.LabelRL2.Location = New System.Drawing.Point(381, 178)
        Me.LabelRL2.MinimumSize = New System.Drawing.Size(45, 15)
        Me.LabelRL2.Name = "LabelRL2"
        Me.LabelRL2.Size = New System.Drawing.Size(45, 15)
        Me.LabelRL2.TabIndex = 119
        '
        'LabelRL1
        '
        Me.LabelRL1.AutoSize = True
        Me.LabelRL1.BackColor = System.Drawing.Color.White
        Me.LabelRL1.Location = New System.Drawing.Point(382, 156)
        Me.LabelRL1.MinimumSize = New System.Drawing.Size(45, 15)
        Me.LabelRL1.Name = "LabelRL1"
        Me.LabelRL1.Size = New System.Drawing.Size(45, 15)
        Me.LabelRL1.TabIndex = 116
        '
        'ckBox_IP
        '
        Me.ckBox_IP.AutoSize = True
        Me.ckBox_IP.Checked = True
        Me.ckBox_IP.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckBox_IP.Location = New System.Drawing.Point(534, 126)
        Me.ckBox_IP.Name = "ckBox_IP"
        Me.ckBox_IP.Size = New System.Drawing.Size(15, 14)
        Me.ckBox_IP.TabIndex = 155
        Me.ckBox_IP.UseVisualStyleBackColor = True
        '
        'ANAVolt10
        '
        Me.ANAVolt10.AutoSize = True
        Me.ANAVolt10.BackColor = System.Drawing.Color.White
        Me.ANAVolt10.Location = New System.Drawing.Point(144, 325)
        Me.ANAVolt10.MinimumSize = New System.Drawing.Size(45, 15)
        Me.ANAVolt10.Name = "ANAVolt10"
        Me.ANAVolt10.Size = New System.Drawing.Size(45, 15)
        Me.ANAVolt10.TabIndex = 111
        '
        'ANAVolt5
        '
        Me.ANAVolt5.AutoSize = True
        Me.ANAVolt5.BackColor = System.Drawing.Color.White
        Me.ANAVolt5.Location = New System.Drawing.Point(144, 288)
        Me.ANAVolt5.MinimumSize = New System.Drawing.Size(45, 15)
        Me.ANAVolt5.Name = "ANAVolt5"
        Me.ANAVolt5.Size = New System.Drawing.Size(45, 15)
        Me.ANAVolt5.TabIndex = 109
        '
        'ckBox_5v
        '
        Me.ckBox_5v.AutoSize = True
        Me.ckBox_5v.Checked = True
        Me.ckBox_5v.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckBox_5v.Location = New System.Drawing.Point(280, 254)
        Me.ckBox_5v.Name = "ckBox_5v"
        Me.ckBox_5v.Size = New System.Drawing.Size(15, 14)
        Me.ckBox_5v.TabIndex = 153
        Me.ckBox_5v.UseVisualStyleBackColor = True
        '
        'lbl5V
        '
        Me.lbl5V.AutoSize = True
        Me.lbl5V.BackColor = System.Drawing.Color.White
        Me.lbl5V.Location = New System.Drawing.Point(381, 306)
        Me.lbl5V.MinimumSize = New System.Drawing.Size(45, 15)
        Me.lbl5V.Name = "lbl5V"
        Me.lbl5V.Size = New System.Drawing.Size(45, 15)
        Me.lbl5V.TabIndex = 109
        '
        'ckBox_Acc
        '
        Me.ckBox_Acc.AutoSize = True
        Me.ckBox_Acc.Checked = True
        Me.ckBox_Acc.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckBox_Acc.Location = New System.Drawing.Point(531, 254)
        Me.ckBox_Acc.Name = "ckBox_Acc"
        Me.ckBox_Acc.Size = New System.Drawing.Size(15, 14)
        Me.ckBox_Acc.TabIndex = 152
        Me.ckBox_Acc.UseVisualStyleBackColor = True
        '
        'accX
        '
        Me.accX.BackColor = System.Drawing.Color.White
        Me.accX.Location = New System.Drawing.Point(607, 336)
        Me.accX.MinimumSize = New System.Drawing.Size(45, 15)
        Me.accX.Name = "accX"
        Me.accX.Size = New System.Drawing.Size(55, 15)
        Me.accX.TabIndex = 117
        '
        'accY
        '
        Me.accY.BackColor = System.Drawing.Color.White
        Me.accY.Location = New System.Drawing.Point(607, 308)
        Me.accY.MinimumSize = New System.Drawing.Size(45, 15)
        Me.accY.Name = "accY"
        Me.accY.Size = New System.Drawing.Size(55, 15)
        Me.accY.TabIndex = 116
        '
        'accZ
        '
        Me.accZ.BackColor = System.Drawing.Color.White
        Me.accZ.Location = New System.Drawing.Point(607, 281)
        Me.accZ.MinimumSize = New System.Drawing.Size(45, 15)
        Me.accZ.Name = "accZ"
        Me.accZ.Size = New System.Drawing.Size(55, 15)
        Me.accZ.TabIndex = 115
        '
        'MsgTestAcc
        '
        Me.MsgTestAcc.AutoSize = True
        Me.MsgTestAcc.BackColor = System.Drawing.Color.White
        Me.MsgTestAcc.ForeColor = System.Drawing.Color.Red
        Me.MsgTestAcc.Location = New System.Drawing.Point(551, 353)
        Me.MsgTestAcc.Name = "MsgTestAcc"
        Me.MsgTestAcc.Size = New System.Drawing.Size(16, 13)
        Me.MsgTestAcc.TabIndex = 130
        Me.MsgTestAcc.Text = "..."
        '
        'TestingSerial
        '
        Me.TestingSerial.BackColor = System.Drawing.Color.White
        Me.TestingSerial.Location = New System.Drawing.Point(168, 25)
        Me.TestingSerial.Name = "TestingSerial"
        Me.TestingSerial.Size = New System.Drawing.Size(170, 24)
        Me.TestingSerial.TabIndex = 137
        '
        'BarTestEtsdn
        '
        Me.BarTestEtsdn.BackColor = System.Drawing.SystemColors.ControlText
        Me.BarTestEtsdn.Enabled = False
        Me.BarTestEtsdn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BarTestEtsdn.Location = New System.Drawing.Point(8, 99)
        Me.BarTestEtsdn.Margin = New System.Windows.Forms.Padding(2)
        Me.BarTestEtsdn.Maximum = 70
        Me.BarTestEtsdn.Name = "BarTestEtsdn"
        Me.BarTestEtsdn.Size = New System.Drawing.Size(768, 11)
        Me.BarTestEtsdn.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.BarTestEtsdn.TabIndex = 139
        '
        'ckBox_Ana
        '
        Me.ckBox_Ana.AutoSize = True
        Me.ckBox_Ana.Checked = True
        Me.ckBox_Ana.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckBox_Ana.Location = New System.Drawing.Point(21, 254)
        Me.ckBox_Ana.Name = "ckBox_Ana"
        Me.ckBox_Ana.Size = New System.Drawing.Size(15, 14)
        Me.ckBox_Ana.TabIndex = 154
        Me.ckBox_Ana.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.ForeColor = System.Drawing.SystemColors.InfoText
        Me.RichTextBox1.Location = New System.Drawing.Point(8, 413)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(802, 152)
        Me.RichTextBox1.TabIndex = 151
        Me.RichTextBox1.Text = ""
        '
        'ckBox_Tutti
        '
        Me.ckBox_Tutti.AutoSize = True
        Me.ckBox_Tutti.Checked = True
        Me.ckBox_Tutti.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckBox_Tutti.Location = New System.Drawing.Point(8, 65)
        Me.ckBox_Tutti.Name = "ckBox_Tutti"
        Me.ckBox_Tutti.Size = New System.Drawing.Size(81, 17)
        Me.ckBox_Tutti.TabIndex = 152
        Me.ckBox_Tutti.Text = "Check Tutti"
        Me.ckBox_Tutti.UseVisualStyleBackColor = True
        '
        'LblNameOperator
        '
        Me.LblNameOperator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LblNameOperator.Location = New System.Drawing.Point(503, 40)
        Me.LblNameOperator.Name = "LblNameOperator"
        Me.LblNameOperator.Size = New System.Drawing.Size(158, 16)
        Me.LblNameOperator.TabIndex = 154
        Me.LblNameOperator.Visible = False
        '
        'cbox_listSerialPort
        '
        Me.cbox_listSerialPort.FormattingEnabled = True
        Me.cbox_listSerialPort.Location = New System.Drawing.Point(658, 3)
        Me.cbox_listSerialPort.Name = "cbox_listSerialPort"
        Me.cbox_listSerialPort.Size = New System.Drawing.Size(63, 21)
        Me.cbox_listSerialPort.TabIndex = 171
        '
        'cbox_select_voltage
        '
        Me.cbox_select_voltage.FormattingEnabled = True
        Me.cbox_select_voltage.Items.AddRange(New Object() {"12", "24"})
        Me.cbox_select_voltage.Location = New System.Drawing.Point(748, 51)
        Me.cbox_select_voltage.Name = "cbox_select_voltage"
        Me.cbox_select_voltage.Size = New System.Drawing.Size(45, 21)
        Me.cbox_select_voltage.TabIndex = 172
        '
        'pbox_buttonPower
        '
        Me.pbox_buttonPower.Location = New System.Drawing.Point(748, 3)
        Me.pbox_buttonPower.Name = "pbox_buttonPower"
        Me.pbox_buttonPower.Size = New System.Drawing.Size(45, 42)
        Me.pbox_buttonPower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbox_buttonPower.TabIndex = 173
        Me.pbox_buttonPower.TabStop = False
        '
        'pBox_IN2
        '
        Me.pBox_IN2.BackColor = System.Drawing.Color.White
        Me.pBox_IN2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pBox_IN2.Location = New System.Drawing.Point(698, 191)
        Me.pBox_IN2.Name = "pBox_IN2"
        Me.pBox_IN2.Size = New System.Drawing.Size(16, 17)
        Me.pBox_IN2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pBox_IN2.TabIndex = 168
        Me.pBox_IN2.TabStop = False
        '
        'pBox_IN1
        '
        Me.pBox_IN1.BackColor = System.Drawing.Color.White
        Me.pBox_IN1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pBox_IN1.Location = New System.Drawing.Point(698, 156)
        Me.pBox_IN1.Name = "pBox_IN1"
        Me.pBox_IN1.Size = New System.Drawing.Size(16, 17)
        Me.pBox_IN1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pBox_IN1.TabIndex = 167
        Me.pBox_IN1.TabStop = False
        '
        'pBox_IP2
        '
        Me.pBox_IP2.BackColor = System.Drawing.Color.White
        Me.pBox_IP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pBox_IP2.Location = New System.Drawing.Point(600, 191)
        Me.pBox_IP2.Name = "pBox_IP2"
        Me.pBox_IP2.Size = New System.Drawing.Size(16, 17)
        Me.pBox_IP2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pBox_IP2.TabIndex = 166
        Me.pBox_IP2.TabStop = False
        '
        'pBox_IP1
        '
        Me.pBox_IP1.BackColor = System.Drawing.Color.White
        Me.pBox_IP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pBox_IP1.Location = New System.Drawing.Point(600, 156)
        Me.pBox_IP1.Name = "pBox_IP1"
        Me.pBox_IP1.Size = New System.Drawing.Size(16, 17)
        Me.pBox_IP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pBox_IP1.TabIndex = 165
        Me.pBox_IP1.TabStop = False
        '
        'btnHide_Show
        '
        Me.btnHide_Show.BackColor = System.Drawing.Color.DimGray
        Me.btnHide_Show.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnHide_Show.Image = Global.FlashedLOL.My.Resources.Res.btnHide
        Me.btnHide_Show.Location = New System.Drawing.Point(714, 382)
        Me.btnHide_Show.Name = "btnHide_Show"
        Me.btnHide_Show.Size = New System.Drawing.Size(76, 29)
        Me.btnHide_Show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.btnHide_Show.TabIndex = 164
        Me.btnHide_Show.TabStop = False
        '
        'pBox_Etsdn
        '
        Me.pBox_Etsdn.BackColor = System.Drawing.Color.White
        Me.pBox_Etsdn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pBox_Etsdn.Location = New System.Drawing.Point(748, 279)
        Me.pBox_Etsdn.Name = "pBox_Etsdn"
        Me.pBox_Etsdn.Size = New System.Drawing.Size(139, 85)
        Me.pBox_Etsdn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pBox_Etsdn.TabIndex = 149
        Me.pBox_Etsdn.TabStop = False
        Me.pBox_Etsdn.Visible = False
        '
        'StatoTestAnalog
        '
        Me.StatoTestAnalog.BackColor = System.Drawing.Color.White
        Me.StatoTestAnalog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.StatoTestAnalog.Location = New System.Drawing.Point(222, 250)
        Me.StatoTestAnalog.Name = "StatoTestAnalog"
        Me.StatoTestAnalog.Size = New System.Drawing.Size(21, 21)
        Me.StatoTestAnalog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.StatoTestAnalog.TabIndex = 154
        Me.StatoTestAnalog.TabStop = False
        '
        'StatoTestAccellerometro
        '
        Me.StatoTestAccellerometro.BackColor = System.Drawing.Color.White
        Me.StatoTestAccellerometro.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.StatoTestAccellerometro.Location = New System.Drawing.Point(738, 248)
        Me.StatoTestAccellerometro.Name = "StatoTestAccellerometro"
        Me.StatoTestAccellerometro.Size = New System.Drawing.Size(21, 21)
        Me.StatoTestAccellerometro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.StatoTestAccellerometro.TabIndex = 19
        Me.StatoTestAccellerometro.TabStop = False
        '
        'StatoTest5V
        '
        Me.StatoTest5V.BackColor = System.Drawing.Color.White
        Me.StatoTest5V.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.StatoTest5V.Location = New System.Drawing.Point(480, 250)
        Me.StatoTest5V.Name = "StatoTest5V"
        Me.StatoTest5V.Size = New System.Drawing.Size(21, 21)
        Me.StatoTest5V.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.StatoTest5V.TabIndex = 15
        Me.StatoTest5V.TabStop = False
        '
        'pnlAcc
        '
        Me.pnlAcc.Image = Global.FlashedLOL.My.Resources.Res.panelAcc
        Me.pnlAcc.Location = New System.Drawing.Point(520, 244)
        Me.pnlAcc.Name = "pnlAcc"
        Me.pnlAcc.Size = New System.Drawing.Size(256, 123)
        Me.pnlAcc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pnlAcc.TabIndex = 162
        Me.pnlAcc.TabStop = False
        '
        'pnl5V
        '
        Me.pnl5V.Image = Global.FlashedLOL.My.Resources.Res.panel5V
        Me.pnl5V.Location = New System.Drawing.Point(264, 244)
        Me.pnl5V.Name = "pnl5V"
        Me.pnl5V.Size = New System.Drawing.Size(256, 123)
        Me.pnl5V.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pnl5V.TabIndex = 161
        Me.pnl5V.TabStop = False
        '
        'pnlAnalog
        '
        Me.pnlAnalog.Image = Global.FlashedLOL.My.Resources.Res.panelAnalog
        Me.pnlAnalog.Location = New System.Drawing.Point(8, 244)
        Me.pnlAnalog.Name = "pnlAnalog"
        Me.pnlAnalog.Size = New System.Drawing.Size(256, 123)
        Me.pnlAnalog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pnlAnalog.TabIndex = 160
        Me.pnlAnalog.TabStop = False
        '
        'StatoTestIngressi
        '
        Me.StatoTestIngressi.BackColor = System.Drawing.Color.White
        Me.StatoTestIngressi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.StatoTestIngressi.Location = New System.Drawing.Point(736, 119)
        Me.StatoTestIngressi.Name = "StatoTestIngressi"
        Me.StatoTestIngressi.Size = New System.Drawing.Size(21, 21)
        Me.StatoTestIngressi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.StatoTestIngressi.TabIndex = 19
        Me.StatoTestIngressi.TabStop = False
        '
        'pnlInputs
        '
        Me.pnlInputs.Image = Global.FlashedLOL.My.Resources.Res.panelInputs
        Me.pnlInputs.Location = New System.Drawing.Point(520, 115)
        Me.pnlInputs.Name = "pnlInputs"
        Me.pnlInputs.Size = New System.Drawing.Size(256, 123)
        Me.pnlInputs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pnlInputs.TabIndex = 159
        Me.pnlInputs.TabStop = False
        '
        'StatotestRele
        '
        Me.StatotestRele.BackColor = System.Drawing.Color.White
        Me.StatotestRele.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.StatotestRele.Location = New System.Drawing.Point(480, 119)
        Me.StatotestRele.Name = "StatotestRele"
        Me.StatotestRele.Size = New System.Drawing.Size(21, 21)
        Me.StatotestRele.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.StatotestRele.TabIndex = 18
        Me.StatotestRele.TabStop = False
        '
        'StatoTestAlimentazione
        '
        Me.StatoTestAlimentazione.BackColor = System.Drawing.Color.White
        Me.StatoTestAlimentazione.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.StatoTestAlimentazione.Location = New System.Drawing.Point(218, 119)
        Me.StatoTestAlimentazione.Name = "StatoTestAlimentazione"
        Me.StatoTestAlimentazione.Size = New System.Drawing.Size(21, 21)
        Me.StatoTestAlimentazione.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.StatoTestAlimentazione.TabIndex = 16
        Me.StatoTestAlimentazione.TabStop = False
        '
        'pnlRele
        '
        Me.pnlRele.Image = Global.FlashedLOL.My.Resources.Res.panelRele
        Me.pnlRele.Location = New System.Drawing.Point(264, 115)
        Me.pnlRele.Name = "pnlRele"
        Me.pnlRele.Size = New System.Drawing.Size(256, 123)
        Me.pnlRele.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pnlRele.TabIndex = 158
        Me.pnlRele.TabStop = False
        '
        'pnlPower
        '
        Me.pnlPower.Image = Global.FlashedLOL.My.Resources.Res.pannelloPower2
        Me.pnlPower.Location = New System.Drawing.Point(8, 115)
        Me.pnlPower.Name = "pnlPower"
        Me.pnlPower.Size = New System.Drawing.Size(256, 123)
        Me.pnlPower.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pnlPower.TabIndex = 156
        Me.pnlPower.TabStop = False
        '
        'pBoxStart
        '
        Me.pBoxStart.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pBoxStart.Image = Global.FlashedLOL.My.Resources.Res.BtnStart
        Me.pBoxStart.Location = New System.Drawing.Point(4, 12)
        Me.pBoxStart.Name = "pBoxStart"
        Me.pBoxStart.Size = New System.Drawing.Size(152, 47)
        Me.pBoxStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pBoxStart.TabIndex = 146
        Me.pBoxStart.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox1.Image = Global.FlashedLOL.My.Resources.Res.panelSerial
        Me.PictureBox1.Location = New System.Drawing.Point(159, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(190, 31)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 163
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Image = Global.FlashedLOL.My.Resources.Res.cornice
        Me.PictureBox2.Location = New System.Drawing.Point(8, 378)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(802, 41)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 169
        Me.PictureBox2.TabStop = False
        '
        'pBoxStop
        '
        Me.pBoxStop.Image = Global.FlashedLOL.My.Resources.Res.btnStop
        Me.pBoxStop.Location = New System.Drawing.Point(4, 12)
        Me.pBoxStop.Name = "pBoxStop"
        Me.pBoxStop.Size = New System.Drawing.Size(152, 47)
        Me.pBoxStop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pBoxStop.TabIndex = 170
        Me.pBoxStop.TabStop = False
        '
        'btn_set_voltage
        '
        Me.btn_set_voltage.Location = New System.Drawing.Point(748, 71)
        Me.btn_set_voltage.Name = "btn_set_voltage"
        Me.btn_set_voltage.Size = New System.Drawing.Size(45, 23)
        Me.btn_set_voltage.TabIndex = 174
        Me.btn_set_voltage.Text = "Set"
        Me.btn_set_voltage.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btn_set_voltage.UseVisualStyleBackColor = True
        '
        'pbox_Ana5v
        '
        Me.pbox_Ana5v.BackColor = System.Drawing.Color.White
        Me.pbox_Ana5v.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbox_Ana5v.Location = New System.Drawing.Point(223, 286)
        Me.pbox_Ana5v.Name = "pbox_Ana5v"
        Me.pbox_Ana5v.Size = New System.Drawing.Size(16, 17)
        Me.pbox_Ana5v.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbox_Ana5v.TabIndex = 175
        Me.pbox_Ana5v.TabStop = False
        '
        'pbox_Ana10v
        '
        Me.pbox_Ana10v.BackColor = System.Drawing.Color.White
        Me.pbox_Ana10v.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbox_Ana10v.Location = New System.Drawing.Point(223, 325)
        Me.pbox_Ana10v.Name = "pbox_Ana10v"
        Me.pbox_Ana10v.Size = New System.Drawing.Size(16, 17)
        Me.pbox_Ana10v.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pbox_Ana10v.TabIndex = 176
        Me.pbox_Ana10v.TabStop = False
        '
        'MainEtsdn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(814, 570)
        Me.Controls.Add(Me.pbox_Ana10v)
        Me.Controls.Add(Me.pbox_Ana5v)
        Me.Controls.Add(Me.btn_set_voltage)
        Me.Controls.Add(Me.pbox_buttonPower)
        Me.Controls.Add(Me.cbox_select_voltage)
        Me.Controls.Add(Me.cbox_listSerialPort)
        Me.Controls.Add(Me.MsgTestAcc)
        Me.Controls.Add(Me.pBox_IN2)
        Me.Controls.Add(Me.pBox_IN1)
        Me.Controls.Add(Me.pBox_IP2)
        Me.Controls.Add(Me.pBox_IP1)
        Me.Controls.Add(Me.btnHide_Show)
        Me.Controls.Add(Me.TestingSerial)
        Me.Controls.Add(Me.pBox_Etsdn)
        Me.Controls.Add(Me.StatoTestAnalog)
        Me.Controls.Add(Me.StatoTestAccellerometro)
        Me.Controls.Add(Me.StatoTest5V)
        Me.Controls.Add(Me.ckBox_IP)
        Me.Controls.Add(Me.ckBox_Rele)
        Me.Controls.Add(Me.ckBox_5v)
        Me.Controls.Add(Me.ckBox_Acc)
        Me.Controls.Add(Me.ckBox_Ana)
        Me.Controls.Add(Me.accX)
        Me.Controls.Add(Me.accY)
        Me.Controls.Add(Me.accZ)
        Me.Controls.Add(Me.lblPower)
        Me.Controls.Add(Me.lbl5V)
        Me.Controls.Add(Me.LabelRL3)
        Me.Controls.Add(Me.LabelRL2)
        Me.Controls.Add(Me.LabelRL1)
        Me.Controls.Add(Me.ANAVolt10)
        Me.Controls.Add(Me.ANAVolt5)
        Me.Controls.Add(Me.pnlAcc)
        Me.Controls.Add(Me.pnl5V)
        Me.Controls.Add(Me.pnlAnalog)
        Me.Controls.Add(Me.StatoTestIngressi)
        Me.Controls.Add(Me.pnlInputs)
        Me.Controls.Add(Me.StatotestRele)
        Me.Controls.Add(Me.StatoTestAlimentazione)
        Me.Controls.Add(Me.pnlRele)
        Me.Controls.Add(Me.ckBox_Pwr)
        Me.Controls.Add(Me.pnlPower)
        Me.Controls.Add(Me.LblNameOperator)
        Me.Controls.Add(Me.ckBox_Tutti)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.BarTestEtsdn)
        Me.Controls.Add(Me.pBoxStart)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.pBoxStop)
        Me.DoubleBuffered = True
        Me.Name = "MainEtsdn"
        Me.RightToLeftLayout = True
        CType(Me.pbox_buttonPower, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBox_IN2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBox_IN1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBox_IP2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBox_IP1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.btnHide_Show, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBox_Etsdn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatoTestAnalog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatoTestAccellerometro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatoTest5V, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlAcc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnl5V, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlAnalog, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatoTestIngressi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlInputs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatotestRele, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StatoTestAlimentazione, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlRele, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pnlPower, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBoxStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBoxStop, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbox_Ana5v, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbox_Ana10v, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatoTest5V As PictureBox
    Friend WithEvents StatoTestAlimentazione As PictureBox
    Friend WithEvents StatotestRele As PictureBox
    Friend WithEvents StatoTestIngressi As PictureBox
    Friend WithEvents lblPower As Label
    Friend WithEvents lbl5V As Label
    Friend WithEvents ANAVolt10 As Label
    Friend WithEvents ANAVolt5 As Label
    Friend WithEvents StatoTestAccellerometro As PictureBox
    Friend WithEvents accZ As Label
    Friend WithEvents accX As Label
    Friend WithEvents accY As Label
    Friend WithEvents MsgTestAcc As Label
    Friend WithEvents TestingSerial As Label
    Friend WithEvents BarTestEtsdn As ProgressBar
    Friend WithEvents LabelRL3 As Label
    Friend WithEvents LabelRL2 As Label
    Friend WithEvents LabelRL1 As Label
    Friend WithEvents pBoxStart As PictureBox
    Friend WithEvents StatoTestAnalog As PictureBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents pBox_Etsdn As PictureBox
    Friend WithEvents ckBox_5v As CheckBox
    Friend WithEvents ckBox_Acc As CheckBox
    Friend WithEvents ckBox_Pwr As CheckBox
    Friend WithEvents ckBox_Rele As CheckBox
    Friend WithEvents ckBox_IP As CheckBox
    Friend WithEvents ckBox_Ana As CheckBox
    Friend WithEvents ckBox_Tutti As CheckBox
    Friend WithEvents LblNameOperator As Label
    Friend WithEvents pnlPower As PictureBox
    Friend WithEvents pnlRele As PictureBox
    Friend WithEvents pnlInputs As PictureBox
    Friend WithEvents pnlAnalog As PictureBox
    Friend WithEvents pnl5V As PictureBox
    Friend WithEvents pnlAcc As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnHide_Show As PictureBox
    Friend WithEvents pBox_IP1 As PictureBox
    Friend WithEvents pBox_IP2 As PictureBox
    Friend WithEvents pBox_IN2 As PictureBox
    Friend WithEvents pBox_IN1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents pBoxStop As PictureBox
    Friend WithEvents cbox_listSerialPort As ComboBox
    Friend WithEvents cbox_select_voltage As ComboBox
    Friend WithEvents pbox_buttonPower As PictureBox
    Friend WithEvents btn_set_voltage As Button
    Friend WithEvents pbox_Ana5v As PictureBox
    Friend WithEvents pbox_Ana10v As PictureBox
End Class
