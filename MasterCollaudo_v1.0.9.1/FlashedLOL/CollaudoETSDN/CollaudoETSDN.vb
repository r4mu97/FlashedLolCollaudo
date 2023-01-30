Imports System.IO
Imports System.IO.Ports
Imports System.Threading
Imports System.Threading.Tasks
Imports Microsoft.VisualBasic.Devices
Imports PdfSharp.Drawing
Imports PdfSharp.Pdf

Public Class MainEtsdn

    Private thread As Thread
    Private AnimatedImage As Image
    Dim canEtsdnVar As New CanCommunication
    Dim varTxEtsdn As New VarTxToETSDN
    Dim resultTest As New ResultTestDoneETSDN
    Dim statoCollaudo As New StatoTestCollaudo
    Dim abortTests = False
    Dim log As New WriteRepor
    Dim reportInfo As New ReportInfoTestEtsdn
    Dim reportstart As New InfoEventTest
    Dim reportPwr As New ReportTestPower
    Dim reportRl As New ReportTestRele
    Dim reportIp As New ReportTestInput
    Dim reportAna As New ReportTestAnalog
    Dim report5V As New ReportTest5V
    Dim reportAcc As New ReportoTestAccelerometer
    Dim stato As New StatoTestCollaudo
    Dim executor As New TestExecutor
    Dim suite As New TestSuite()

    Dim test_power As New TestPowerEtsdn(15000, 10, 600)
    Dim test_rele As New TestReleEtsdn(10000, 0, 450, 510) '450 e510
    Dim test_inputs As New TestInputsEtsdn(10000, 2000, 0)
    Dim test_analog As New TestAnalogEtsdn(15000, 5, 5, 0, 50)
    Dim test_5v As New Test5VsEtsdn(5000, 49, 51)
    Dim test_acc As New TestAccEtsdn(10000, 0, 0.3)

    Dim writeCSV As New CreateCSVfile(Me)
    Dim cloudData As New MongoDBdata

    Public results As List(Of TestResult)

    Public fail As Boolean = False
    Public abortTest As Boolean = False
    Public my_com_port As SerialPort = Nothing
    'Dim ports = System.IO.Ports.SerialPort.GetPortNames.ToList()
    Dim path = Application.StartupPath & "\\log\\Etsdn\\" & "RaccoltaDati.csv"
    Private Declare Sub CopyMemory Lib "kernel32" Alias _
    "RtlMoveMemory" (ByVal Destination As Long, ByVal _
    Source As Long, ByVal Length As Integer)



    Private Sub MainEtsdn_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitializeBasicComponents()
        unInit_CANOPEN()
        SetPopUpInfoTest()
        'controllo inizializzazione CAN 
        Do
            canEtsdnVar.InitCanOpen()
        Loop While Not canEtsdnVar.is_Inizialized()
        canEtsdnVar.data_to_send = 1
        Dim thread_heartbeat = New Thread(AddressOf canEtsdnVar.heartbeat)
        thread_heartbeat.Start()

        'assegno il nome che viene utilizzato nel main per il login alla label 
        LblNameOperator.Text = Main.TextboxPredictionUsername.Text
        my_com_port = New SerialPort()
        pbox_buttonPower.Image = My.Resources.Res.ButtonOff
        'aggiorno la alebl con la data odierna 
        'Try
        '    Dim tm As New Stopwatch
        '    tm.Restart()
        '    Do While tm.ElapsedMilliseconds < 3000 Or canEtsdnVar.canOpenInizialized = False
        '        canEtsdnVar.InitCanOpen()
        '        Console.WriteLine("InitCAN")
        '        If canEtsdnVar.canOpenInizialized Then
        '            Console.WriteLine("InitCAN_Done")
        '            Exit Do
        '        End If
        '    Loop

        'Catch ex As Exception
        '    Console.WriteLine(ex)
        'End Try
        'canEtsdnVar.InitCanOpen()

        ChangeBarColor(BarTestEtsdn, ProgressBarColor.Yellow)

    End Sub
    Private Sub CloseCollETSDN(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        stato.RequestToCloseTest = True
        BarTestEtsdn.Enabled = False
        VarRxFromETSDN.GetIntance.canOpenInizialized = False
        'MyBackgroundThreadETSDN()
    End Sub

    Public Function Setting_Voltage_Power()
        Try
            RDW_CommandCollaudo("VSET1:", cbox_select_voltage.Text)
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function


    Private Sub ResetAllVisibility()

        StatoTestAlimentazione.Image = Nothing
        StatotestRele.Image = Nothing
        StatoTestIngressi.Image = Nothing
        StatoTestAnalog.Image = Nothing
        StatoTest5V.Image = Nothing
        StatoTestAccellerometro.Image = Nothing
        pBox_Etsdn.Image = Nothing
        pBox_IP1.Image = Nothing
        pBox_IP2.Image = Nothing
        pBox_IN1.Image = Nothing
        pBox_IN2.Image = Nothing
        pbox_Ana5v.Image = Nothing
        pbox_Ana10v.Image = Nothing

        'statoCollaudo.OldSerialDevice = ""
        'BarTestEtsdn.Minimum = 0
        'BarTestEtsdn.Maximum = 60
        'BarTestEtsdn.Value = 0
        'ChangeBarColor(BarTestEtsdn, ProgressBarColor.Yellow)
    End Sub

    Public Function CheckPowerSupply()
        Dim status_power As Boolean

        Dim status_of_PowerSup = RDW_CommandCollaudo("STATUS?")

        If status_of_PowerSup = "S" Then
            status_power = True
        Else
            status_power = False
        End If
        Return status_power
    End Function

    Public Sub SetPopUpInfoTest()
        Dim PopUpInfo As New ToolTip()
        PopUpInfo.ShowAlways = True
        PopUpInfo.SetToolTip(pBoxStart,
        "Premere per eseguire il test")
        PopUpInfo.SetToolTip(pnlPower,
        "Viene controllata la corretta erogazione di corrente dal dispositivo.
        WARNING:
        controllare sempre sull'alimentatore possibili corti;
        il test va eseguito a 24V sull'alimentatore altrimenti il test potrebbe fallire.")
        PopUpInfo.SetToolTip(pnlRele,
        "Viene controllato che non ci sia alimentazione con tutti i relè aperti,
        viene effettuato un controllo corrente su ogni relè aprendone uno alla volta.")
        PopUpInfo.SetToolTip(pnlInputs,
        "Viene fornita alimentazione singolarmente ad ogni IP e IN, viene controlalto anche che non ci siano 'corti' tra i vari ingressi.")
        PopUpInfo.SetToolTip(pnl5V,
        "Viene controlalto che il valore erogato dal dispositivo non superi e non scenda sotto i 5,1 e i 4,9")
        PopUpInfo.SetToolTip(pnlAnalog,
        "Gli analogici vengono controllati in base alla loro salita e discesa e che sia la stessa che viene fornita dalla centralina."
)
    End Sub



    Public Sub ErrorTestDevice()
        'If pBoxErrorCan.Visible = True Then
        '    ChangeBarColor(BarTestEtsdn, ProgressBarColor.Red)
        'Else
        '    ChangeBarColor(BarTestEtsdn, ProgressBarColor.Green)
        'End If
    End Sub

    Private Sub pBoxStart_Click(sender As Object, e As EventArgs) Handles pBoxStart.Click
        Try
            thread = New Thread(AddressOf MyBackgroundThreadETSDN)
            thread.Start()
            abortTest = False
            ChangeEnablePbox(pBoxStart, False)
            ChangeEnableCheckBox(ckBox_Tutti, False)
            ChangeEnableCheckBox(ckBox_Pwr, False)
            ChangeEnableCheckBox(ckBox_Rele, False)
            ChangeEnableCheckBox(ckBox_IP, False)
            ChangeEnableCheckBox(ckBox_Ana, False)
            ChangeEnableCheckBox(ckBox_5v, False)
            ChangeEnableCheckBox(ckBox_Acc, False)
            ChangeControlBarValue(BarTestEtsdn, 0)
            ChangeBarColor(BarTestEtsdn, ProgressBarColor.Yellow)
            ChangeControlVisibility(pBoxStart, False)
            ChangeControlVisibility(pBoxStop, True)
            ResetAllLabel()
        Catch ex As Exception
            System.Console.WriteLine("Error during thread start")
        End Try

    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles pBoxStop.Click
        abortTest = True
        ChangeEnablePbox(pBoxStart, True)
        ChangeEnableCheckBox(ckBox_Pwr, True)
        ChangeEnableCheckBox(ckBox_Rele, True)
        ChangeEnableCheckBox(ckBox_IP, True)
        ChangeEnableCheckBox(ckBox_Ana, True)
        ChangeEnableCheckBox(ckBox_5v, True)
        ChangeEnableCheckBox(ckBox_Acc, True)
        ChangeEnableCheckBox(ckBox_Tutti, True)

        ChangeControlVisibility(pBoxStart, True)
        ChangeControlVisibility(pBoxStop, False)
    End Sub


    Public Function ResetAllLabel()
        ChangeControlText(TestingSerial, "")
        ChangeControlText(lblPower, "")
        ChangeControlText(LabelRL1, "")
        ChangeControlText(LabelRL2, "")
        ChangeControlText(LabelRL3, "")
        ChangeControlText(ANAVolt5, "")
        ChangeControlText(lbl5V, "")
        ChangeControlText(accZ, "")
        ChangeControlText(accY, "")
        ChangeControlText(accX, "")
    End Function

    Private Delegate Sub AddRowsDelegate(ctrl As DataGridView, str As String, str1 As String, str2 As String)

    Public Sub AddRow(ByVal ctrl As DataGridView, str As String, Optional str1 As String = "", Optional str2 As String = "")
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New AddRowsDelegate(AddressOf AddRow), New Object() {ctrl, str, str1, str2})
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

            Return
        End If
        ctrl.Rows.Add(str, str1, str2)
    End Sub
    Public Function SlidePanel(panel As Panel, y As Integer)
        Dim x As Integer = 8
        Dim tmrSlidePanel As New Stopwatch

        tmrSlidePanel.Start()
        Do
            If tmrSlidePanel.ElapsedMilliseconds = 10 Then
                x += 1
                ChangeLocationPanel(panel, x, y)
                tmrSlidePanel.Restart()
            End If
        Loop While Not x >= 50
        tmrSlidePanel.Reset()
    End Function

    Private Delegate Sub ChangeControlLocationPanelDelegate(ByVal ctrl As Panel, ByVal x As Integer, y As Integer)
    Public Sub ChangeLocationPanel(ByVal ctrl As Panel, ByVal x As Integer, y As Integer)
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New ChangeControlLocationPanelDelegate(AddressOf ChangeLocationPanel), New Object() {ctrl, x, y})
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

            Return
        End If
        ctrl.Location = New Point(x, y)
    End Sub

    Private Delegate Sub ChangeControlSizePanelDelegate(ByVal ctrl As Panel, ByVal x As Integer, y As Integer)
    Public Sub ChangeSizePanel(ByVal ctrl As Panel, ByVal x As Integer, y As Integer)
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New ChangeControlSizePanelDelegate(AddressOf ChangeSizePanel), New Object() {ctrl, x, y})
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

            Return
        End If
        ctrl.Size = New Size(x, y)
    End Sub

    Private Delegate Sub ChangeControlSizePictureBoxDelegate(ByVal ctrl As PictureBox, ByVal x As Integer, y As Integer)
    Public Sub ChangeSizePbox(ByVal ctrl As PictureBox, ByVal x As Integer, y As Integer)
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New ChangeControlSizePictureBoxDelegate(AddressOf ChangeSizePbox), New Object() {ctrl, x, y})
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

            Return
        End If
        ctrl.Size = New Size(x, y)
    End Sub

    Private Delegate Sub ChangeEnablePictureBoxDelegate(ByVal ctrl As PictureBox, ByVal value As Boolean)
    Public Sub ChangeEnablePbox(ByVal ctrl As PictureBox, ByVal value As Boolean)
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New ChangeEnablePictureBoxDelegate(AddressOf ChangeEnablePbox), New Object() {ctrl, value})
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

            Return
        End If
        ctrl.Enabled = value
    End Sub

    Private Delegate Sub ChangeControlLocationDelegate(ByVal ctrl As PictureBox, ByVal x As Integer, y As Integer)
    Public Sub ChangeLocationPbox(ByVal ctrl As PictureBox, ByVal x As Integer, y As Integer)
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New ChangeControlLocationDelegate(AddressOf ChangeLocationPbox), New Object() {ctrl, x, y})
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

            Return
        End If
        ctrl.Location = New Point(x, y)
    End Sub

    Private Delegate Sub ChangeControlRichTextDelegate(ByVal ctrl As RichTextBox, ByVal text As String, val As String)
    Public Sub ChangeControlRichText(ByVal ctrl As RichTextBox, ByVal text As String, val As String)
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New ChangeControlRichTextDelegate(AddressOf ChangeControlRichText), New Object() {ctrl, text, val})
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

            Return
        End If

        If val = "White" Then
            ctrl.SelectionColor = Color.White
            ctrl.AppendText(text & Environment.NewLine)
        ElseIf val = "Red" Then
            ctrl.SelectionColor = Color.Red
            ctrl.AppendText(text & Environment.NewLine)
        ElseIf val = "Green" Then
            ctrl.SelectionColor = Color.Green
            ctrl.AppendText(text & Environment.NewLine)
        ElseIf val = "Orange" Then
            ctrl.SelectionColor = Color.Orange
            ctrl.AppendText(text & Environment.NewLine)
        ElseIf val = "Blue" Then
            ctrl.SelectionColor = Color.SteelBlue
            ctrl.AppendText(text & Environment.NewLine)
        End If


    End Sub

    Private Delegate Sub ChangeControlSizeRichTextBoxDelegate(ByVal ctrl As RichTextBox, ByVal x As Integer, y As Integer)
    Public Sub ChangeSizeRichText(ByVal ctrl As RichTextBox, ByVal x As Integer, y As Integer)
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New ChangeControlSizeRichTextBoxDelegate(AddressOf ChangeSizeRichText), New Object() {ctrl, x, y})
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

            Return
        End If
        ctrl.Size = New Size(x, y)
    End Sub

    Private Delegate Sub ChangeControlTextDelegate(ByVal ctrl As Control, ByVal text As String)
    Public Sub ChangeControlText(ByVal ctrl As Control, ByVal text As String)
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New ChangeControlTextDelegate(AddressOf ChangeControlText), New Object() {ctrl, text})
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

            Return
        End If
        ctrl.Text = text
    End Sub

    Private Delegate Sub ChangeControlCheckBoxDelegate(ByVal ctrl As CheckBox, ByVal a As Boolean)
    Public Sub ChangeEnableCheckBox(ByVal ctrl As CheckBox, ByVal a As Boolean)
        If Me.InvokeRequired Then
            Try
                Me.Invoke(New ChangeControlCheckBoxDelegate(AddressOf ChangeEnableCheckBox), New Object() {ctrl, a})
            Catch ex As Exception
                Console.WriteLine(ex)
            End Try

            Return
        End If
        ctrl.Enabled = a
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
    Public Sub ChangeControlVisibility(ByVal ctrl As Control, ByVal visible As Boolean)
        If Me.InvokeRequired Then
            Me.Invoke(New ChangeControlVisibilityDelegate(AddressOf ChangeControlVisibility), New Object() {ctrl, visible})
            Return
        End If
        ctrl.Visible = visible

    End Sub

    Private Delegate Sub ChangeControlValueDelegate(ByVal ctrl As ProgressBar, ByVal value As Integer)
    Public Sub ChangeControlBarValue(ByVal ctrl As ProgressBar, ByVal value As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New ChangeControlValueDelegate(AddressOf ChangeControlBarValue), New Object() {ctrl, value})
            Return
        End If
        ctrl.Value = value
    End Sub

    Private Delegate Sub ChangeMaxBarDelegate(ByVal ctrl As ProgressBar, ByVal value As Integer)
    Public Sub ChangeMaxBarValue(ByVal ctrl As ProgressBar, ByVal value As Integer)
        If Me.InvokeRequired Then
            Me.Invoke(New ChangeMaxBarDelegate(AddressOf ChangeMaxBarValue), New Object() {ctrl, value})
            Return
        End If
        ctrl.Maximum = value
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
    Sub Wait(ByVal millisecondi As Integer, Optional showWait As Boolean = False)

        System.Threading.Thread.Sleep(millisecondi)
    End Sub '____________________________________________________TUTTI I CHANGE SONO QUI__________________________________________________________

    Function ResetPanelForm()
        ChangeControlText(lblPower, "")
        ChangeControlText(LabelRL1, "")
        ChangeControlText(LabelRL2, "")
        ChangeControlText(LabelRL3, "")
        ChangeControlText(lbl5V, "")
        ChangeControlText(ANAVolt10, "")
        ChangeControlText(ANAVolt5, "")
        ChangeControlText(accX, "")
        ChangeControlText(accY, "")
        ChangeControlText(accZ, "")
    End Function

    Function SelectTests()
        Try
            suite.ClearListOfTest()
            If ckBox_Pwr.Checked Then
                suite.AddTests(test_power)
            End If
            If ckBox_Rele.Checked Then
                suite.AddTests(test_rele)
            End If

            If ckBox_IP.Checked Then
                suite.AddTests(test_inputs)
            End If
            If ckBox_Ana.Checked Then
                suite.AddTests(test_analog)
            End If
            If ckBox_5v.Checked Then
                suite.AddTests(test_5v)
            End If
            If ckBox_Acc.Checked Then
                suite.AddTests(test_acc)
            End If
            ChangeMaxBarValue(BarTestEtsdn, suite.GetCountTest())

        Catch ex As Exception
            ChangeControlRichText(RichTextBox1, ex.ToString, "Red")
        End Try
    End Function

    '\\Sub per il loop del test
    Sub MyBackgroundThreadETSDN()
        'scrivo sulla richtextbox che è stato premuto il tasto di start e a che ora 
        ChangeControlRichText(RichTextBox1, "Test Start " & Date.Now.ToLongTimeString, "White")
        'resetto alla posizione iniziale i pannelli dei test 
        ResetPanelForm()
        'resetto le immagini dentro ai pannelli dei test
        ResetAllVisibility()
        'aggiungo alla lista i test checcati nel form
        SelectTests()
        'eseguo i test
        results = executor.Execute_test_suite(suite, Me)
        'invio i dati estrapolati dai test e li invio al cloud mongo 
        cloudData.commitDeviceCraft(Me)
        'finiti i test rimetto visibile il tasto di start
        ChangeEnablePbox(pBoxStart, True)
        ChangeControlVisibility(pBoxStop, False)
        ChangeControlVisibility(pBoxStart, True)
        'scrivo sulla richtextbox che il test è finito e a che ora 
        ChangeControlRichText(RichTextBox1, "Test Finished " & Date.Now.ToLongTimeString, "White")
        'cambio colore alla barra in base al risultato di tutti i test
        If fail Then
            ChangeBarColor(BarTestEtsdn, ProgressBarColor.Red)
        Else
            ChangeBarColor(BarTestEtsdn, ProgressBarColor.Green)
        End If
        fail = False
        VarRxFromETSDN.GetIntance.ResetData()
        ChangeEnablePbox(pBoxStart, True)
        ChangeEnableCheckBox(ckBox_Pwr, True)
        ChangeEnableCheckBox(ckBox_Rele, True)
        ChangeEnableCheckBox(ckBox_IP, True)
        ChangeEnableCheckBox(ckBox_Ana, True)
        ChangeEnableCheckBox(ckBox_5v, True)
        ChangeEnableCheckBox(ckBox_Acc, True)
        ChangeEnableCheckBox(ckBox_Tutti, True)

        Console.WriteLine("End test")

    End Sub



    Private Sub BtnOpenLog_Click(sender As Object, e As EventArgs)
        Process.Start(Application.StartupPath + "\\Log\\Etsdn\\LogPDF\\")
    End Sub

    Private Sub pBoxGestioneError_Click(sender As Object, e As EventArgs)
        Process.Start(Application.StartupPath + "\\Log\\gestioneErrori.txt")
    End Sub

    Private Sub BtnErrorView_Click(sender As Object, e As EventArgs)
        Dim readFile As TextReader = New StreamReader(Application.StartupPath + "\\Log\\Etsdn\\LogPDF\\" + VarRxFromETSDN.GetIntance.etsdnSN + ".pdf")
        readFile.Close()
        Process.Start(Application.StartupPath + "\\Log\\Etsdn\\LogPDF\\" + VarRxFromETSDN.GetIntance.etsdnSN + ".pdf")
    End Sub

    Private Sub ckBox_Tutti_CheckedChanged(sender As Object, e As EventArgs) Handles ckBox_Tutti.Click
        Dim b = ckBox_Tutti.Checked

        ckBox_Pwr.Checked = b
        ckBox_Rele.Checked = b
        ckBox_IP.Checked = b
        ckBox_Ana.Checked = b
        ckBox_5v.Checked = b
        ckBox_Acc.Checked = b

    End Sub

    Private Sub pBoxStart_MouseEnter(sender As Object, e As EventArgs) Handles pBoxStart.MouseEnter
        ChangeControlBackgroundColor(pBoxStart, Color.Gainsboro)
    End Sub

    Private Sub pBoxStart_MouseLeave(sender As Object, e As EventArgs) Handles pBoxStart.MouseLeave
        ChangeControlBackgroundColor(pBoxStart, Color.WhiteSmoke)
    End Sub

    Private Sub btnHide_Show_Click(sender As Object, e As EventArgs) Handles btnHide_Show.Click

        If RichTextBox1.Visible Then
            btnHide_Show.Image = My.Resources.Res.btnShow
            btnHide_Show.Refresh()
            ChangeControlVisibility(RichTextBox1, False)
        Else
            btnHide_Show.Image = My.Resources.Res.btnHide
            btnHide_Show.Refresh()
            ChangeControlVisibility(RichTextBox1, True)
        End If
    End Sub

    Private Sub btnHide_Show_MouseEnter(sender As Object, e As EventArgs)
        ChangeControlBackgroundColor(btnHide_Show, Color.Gainsboro)
    End Sub

    Private Sub btnHide_Show_MouseLeave(sender As Object, e As EventArgs)
        ChangeControlBackgroundColor(btnHide_Show, Color.WhiteSmoke)
    End Sub

    Private Sub cbox_listSerialPort_DropDown(sender As Object, e As EventArgs) Handles cbox_listSerialPort.DropDown
        checkAvailablePort()
    End Sub

    Public Delegate Sub checkAvailablePortDelegate()
    Private Sub checkAvailablePort()

        If Me.InvokeRequired Then
            Me.Invoke(New checkAvailablePortDelegate(AddressOf checkAvailablePort), New Object() {})
            Return
        End If

        Dim available_serial_port() As String = SerialPort.GetPortNames()
        cbox_listSerialPort.Items.Clear()

        For Each com_port In available_serial_port
            cbox_listSerialPort.Items.Add(com_port)
        Next

    End Sub
    Private Sub cbox_listSerialPort_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbox_listSerialPort.SelectedValueChanged
        If my_com_port.PortName <> cbox_listSerialPort.Text Then
            my_com_port.PortName = cbox_listSerialPort.Text
            my_com_port.BaudRate = 9600
        End If
        CheckPowerSupply()
    End Sub

    Private Sub btn_set_voltage_Click(sender As Object, e As EventArgs) Handles btn_set_voltage.Click
        If cbox_select_voltage.Text = "" Then
            MsgBox("Imposta voltaggio")
        Else
            If cbox_select_voltage.Text.ToString > 25 Or cbox_select_voltage.Text.ToString < 10 Then
                MsgBox("Valore non valido")
            Else
                Setting_Voltage_Power()
            End If
        End If
    End Sub




    Public Function RDW_CommandCollaudo(Optional Comando As String = "", Optional ByVal Value As String = "", Optional ByVal Offset As String = "",
                               Optional ByVal ErrorEnable As Boolean = False, Optional ByVal ReadFloat As Boolean = False, Optional ByVal FIND As String = "",
                               Optional ByVal customTimeout As Integer = 10000
                               ) As String


        Try
            Dim Tentativi = 0
            Dim str_to_send As String
            Dim MyRnd As New Random
            Dim CheckSinc As Boolean = False
            Dim CheckRisp As String = ""
            Dim str_of_reply As String = ""



            If Not Comando = "STATUS?" Then
                str_to_send = Comando & Value & Offset & CheckRisp & vbCr

                If Not my_com_port.IsOpen Then
                    Dim available_serial_port() As String = SerialPort.GetPortNames()
                    my_com_port.Open()
                    my_com_port.DiscardOutBuffer()
                    my_com_port.DiscardInBuffer()
                End If
                my_com_port.Write(str_to_send)
                my_com_port.Close()
            Else
                str_to_send = Comando & Value & Offset & CheckRisp & vbCr
                If Not my_com_port.IsOpen Then
                    Dim available_serial_port() As String = SerialPort.GetPortNames()
                    my_com_port.Open()
                    my_com_port.DiscardOutBuffer()
                    my_com_port.DiscardInBuffer()
                End If
                my_com_port.Write(str_to_send)
                If customTimeout <= 0 Then
                    my_com_port.ReadTimeout = SerialPort.InfiniteTimeout
                Else
                    my_com_port.ReadTimeout = customTimeout
                End If

                '' Porta.ReadTimeout = 10000


                If FIND = "" Then
                    Try
                        str_of_reply = my_com_port.ReadLine()
                    Catch ex As Exception
                    End Try
                Else
                    my_com_port.ReadTimeout = 10000
                    While 1
                        Console.WriteLine(FIND)
                        Dim Temp1 = my_com_port.ReadLine
                        str_of_reply = str_of_reply & Temp1
                        If Temp1.Contains(FIND) Then
                            Exit While
                        End If

                    End While
                End If
                my_com_port.Close()
            End If
            Console.WriteLine(str_of_reply)
            Return str_of_reply
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        'Try

        '    Dim str_to_send As String
        '    Dim MyRnd As New Random
        '    Dim CheckSinc As Boolean = False
        '    Dim CheckRisp As String = ""
        '    Dim str_of_reply As String


        '    'If Not my_com_port.IsOpen Then
        '    '    my_com_port.Open()
        '    '    my_com_port.DiscardOutBuffer()
        '    '    my_com_port.DiscardInBuffer()
        '    'End If
        '    If Not Comando = "STATUS?" Then
        '        If Not Value = "" Then
        '            If Not Value > 24 And Not Value < 12 Then

        '                str_to_send = Comando & Value & Offset & CheckRisp & IIf(CheckRisp.Length > 0, " ", "") & vbCr

        '                If Not my_com_port.IsOpen Then
        '                    Dim available_serial_port() As String = SerialPort.GetPortNames()
        '                    my_com_port.Open()
        '                    my_com_port.DiscardOutBuffer()
        '                    my_com_port.DiscardInBuffer()
        '                End If
        '                my_com_port.Write(str_to_send)
        '                my_com_port.Close()
        '            End If
        '        End If
        '    Else
        '        str_to_send = Comando & Value & Offset & CheckRisp & IIf(CheckRisp.Length > 0, " ", "") & vbCr
        '        If Not my_com_port.IsOpen Then
        '            Dim available_serial_port() As String = SerialPort.GetPortNames()
        '            my_com_port.Open()
        '            my_com_port.DiscardOutBuffer()
        '            my_com_port.DiscardInBuffer()
        '        End If
        '        my_com_port.Write(str_to_send)
        '        my_com_port.Close()
        '    End If

        '    If Not my_com_port.IsOpen Then
        '        Dim available_serial_port() As String = SerialPort.GetPortNames()
        '        my_com_port.Open()
        '        my_com_port.DiscardOutBuffer()
        '        my_com_port.DiscardInBuffer()
        '    End If



        '    Dim result As String = ""
        '    Try

        '        If customTimeout <= 0 Then
        '            my_com_port.ReadTimeout = SerialPort.InfiniteTimeout
        '        Else
        '            my_com_port.ReadTimeout = customTimeout
        '        End If

        '        Do
        '            Dim incoming_string As String = my_com_port.ReadLine
        '            If incoming_string Is Nothing Then
        '                Exit Do
        '            Else
        '                result &= incoming_string & vbCrLf
        '            End If
        '        Loop
        '    Catch ex As TimeoutException
        '        result = "Error: Serial port read timed out."
        '    Finally
        '        If my_com_port IsNot Nothing Then my_com_port.Close()
        '    End Try

        '    Return result
        'Catch ex As Exception

        'End Try


    End Function

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles pbox_buttonPower.Click
        If Not cbox_listSerialPort.Text = "" Then
            If CheckPowerSupply() Then
                RDW_CommandCollaudo("OUT0")
                pbox_buttonPower.Image = My.Resources.Res.ButtonOff
            Else
                RDW_CommandCollaudo("OUT1")
                pbox_buttonPower.Image = My.Resources.Res.ButtonOn
            End If
        Else
            MsgBox("Prima selezionare la COM")
        End If
    End Sub


End Class



Class StatoTestCollaudo

    Public fsmTest = 0

    Public RequestToCloseTest = False
    Public requestToStoptest = False
    Public requestToStartTest = False

    Public IPstato = 0
    Public StepRele = 0
    Public testPWRsuccess = False
    Public testRLsuccess = False
    Public testIPsuccess = False
    Public testANAsucces = False
    Public test5Vsuccess = False
    Public testCANsuccess = False
    Public testACCsuccess = False
    Public MsgCanPLC = 0
    Public testPWRcompleted = False
    Public testRLcompleted = False
    Public testIPcompleted = False
    Public testIngressiCompleted = False
    Public testIngressiSuccess = False
    Public test5Vcompleted = False
    Public testCANcompleted = False
    Public testACCcompleted = False
    Public stepAcc = 0
    Public stepIP = 0
    Public cFailANA10 = 0
    Public cFailANA5 = 0
    Public rAccTolerance = 0.3
    Public asseY = False
    Public asseZ = False
    Public OldSerialDevice As String
    Public timerRele As New Stopwatch
    Public timerIP As New Stopwatch
    Public timerANA As New Stopwatch
    Public timerIn5V As New Stopwatch
    Public NameOperator = ""
    Public CheckCanCom As Boolean
End Class
Public Class ResultTestDoneETSDN

    Public nameOperator As String = "", dateNow As String, serialDevice As String = ""
    Public nameTest As String = "", checked As String = "", resultTest As String = "", comment As String = ""
    Public startTest As String = "", stoptest As String = ""

    'Public Function SetResultTest(name As String, check As Boolean, result As Boolean)
    '    nameTest = name
    '    checked = " Checked: " & check
    '    resultTest = " Result test: " & result.ToString
    'End Function

End Class

Public Class ReportTestPower
    Inherits ResultTestDoneETSDN

    Public testPwr As String = "", currentPlc As String = ""
    Public errorPwr As String = ""
    Public Sub SetResultPwr(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional value As Double = 0, Optional valueplc As Double = 0)

        If pass Then
            testPwr = " testPOWER: " + pass.ToString
        Else
            testPwr = " testPOWER: " + pass.ToString
            currentPlc = "  PlcCurrent: " + valueplc.ToString + " (must not be < 10 and > 600)"
            errorPwr = currentPlc + Environment.NewLine + "  PowerETSDN: " + value.ToString + comment
        End If
    End Sub
End Class

Public Class ReportTestRele
    Inherits ResultTestDoneETSDN
    Public testR1 As String = "", testR2 As String = "", testR3 As String = ""
    Public CurrentR1 As String = "", CurrentR2 As String = "", CurrentR3 As String = ""
    Public errorR1 As String = "", errorR2 As String = "", errorR3 As String = ""

    Public Sub SetResultRL1(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional value As Double = 0)
        If pass Then
            testR1 = " testR1: " + pass.ToString
        Else
            CurrentR1 = value
            testR1 = " testR1: " + pass.ToString
            errorR1 = "  Erorr value: " + CurrentR1 + comment
        End If
    End Sub
    Public Sub SetResultRL2(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional value As Double = 0)
        If pass Then
            testR2 = " testR2: " + pass.ToString
        Else
            CurrentR2 = value
            testR2 = " testR2: " + pass.ToString
            errorR2 = "  Erorr value: " + CurrentR2 + comment
        End If
    End Sub
    Public Sub SetResultRL3(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional value As Double = 0)
        If pass Then
            testR3 = " testR3: " + pass.ToString
        Else
            CurrentR3 = value
            testR3 = " testR3: " + pass.ToString
            errorR3 = "  Erorr value: " + CurrentR3 + comment
        End If
    End Sub
End Class

Public Class ReportTestInput
    Inherits ResultTestDoneETSDN
    Public testIP1 As String = "", testIP2 As String = "", testIN1 As String = "", testIN2 As String = ""
    Public errorIP1 As String = "", errorIP2 As String = "", errorIN1 As String = "", errorIN2 As String = ""

    Public Sub SetResultIP1(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional valIp1 As String = "",
                            Optional valIp2 As String = "", Optional valIn1 As String = "", Optional valIn2 As String = "")
        If pass Then
            testIP1 = " testIP1: " + pass.ToString
        Else
            testIP1 = " testIP1: " + pass.ToString
            errorIP1 = "  Error value: " & Environment.NewLine &
                        "  IP1=" & valIp1 + Environment.NewLine +
                        "  IP2=" + valIp2 + Environment.NewLine +
                        "  IN1=" + valIn1 + Environment.NewLine +
                        "  IN2=" + valIn2 + Environment.NewLine + comment
        End If
    End Sub

    Public Sub SetResultIP2(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional valIp1 As String = "",
                            Optional valIp2 As String = "", Optional valIn1 As String = "", Optional valIn2 As String = "")
        If pass Then
            testIP2 = " testIP2: " + pass.ToString
        Else
            testIP2 = " testIP2: " + pass.ToString
            errorIP2 = "  Error value: " + Environment.NewLine +
                        "  IP2=" + valIp2 + Environment.NewLine +
                        "  IP1=" + valIp1 + Environment.NewLine +
                        "  IN1=" + valIn1 + Environment.NewLine +
                        "  IN2=" + valIn2 + Environment.NewLine + comment

        End If
    End Sub
    Public Sub SetResultIN1(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional valIp1 As String = "",
                            Optional valIp2 As String = "", Optional valIn1 As String = "", Optional valIn2 As String = "")
        If pass Then
            testIN1 = " testIN1: " + pass.ToString
        Else
            testIN1 = " testIN1: " + pass.ToString
            errorIN1 = "  Error value: " + Environment.NewLine +
                       "  IN1=" + valIn1 + Environment.NewLine +
                       "  IP1=" + valIp1 + Environment.NewLine +
                       "  IP2=" + valIp2 + Environment.NewLine +
                       "  IN2=" + valIn2 + Environment.NewLine + comment
        End If
    End Sub
    Public Sub SetResultIN2(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional valIp1 As String = "",
                            Optional valIp2 As String = "", Optional valIn1 As String = "", Optional valIn2 As String = "")
        If pass Then
            testIN2 = " testIN2: " + pass.ToString
        Else
            testIN2 = " testIN2: " + pass.ToString
            errorIN2 = "  Error value: " + Environment.NewLine +
                      "  IN2=" + valIn2 + Environment.NewLine +
                      "  IP1=" + valIp1 + Environment.NewLine +
                      "  IP2=" + valIp2 + Environment.NewLine +
                      "  IN1=" + valIn1 + Environment.NewLine + comment
        End If
    End Sub


End Class

Public Class ReportTestAnalog
    Inherits ResultTestDoneETSDN
    Public testANA1 As String = "", testANA2 As String = ""
    Public errorANA1 As String = "", errorANA2 As String = ""
    Public Sub SetResultANA1(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional value As Double = 0)
        If pass Then
            testANA1 = " testANA1(5V): " + pass.ToString
        Else
            testANA1 = " testANA1(5V): " + pass.ToString
            errorANA1 = "  Error: " + comment
        End If
    End Sub
    Public Sub SetResultANA2(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional value As Double = 0)
        If pass Then
            testANA2 = " testANA2(10V) " + pass.ToString
        Else
            testANA2 = " testANA2(10V) " + pass.ToString
            errorANA2 = "  Error: " + comment
        End If
    End Sub
End Class

Public Class ReportTest5V
    Inherits ResultTestDoneETSDN
    Public test5V As String = "", value5V As String = "", error5V As String = ""

    Public Sub SetResult5V(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional value As String = "")
        If pass Then
            test5V = " test5V: " + pass.ToString
        Else
            test5V = " test5V: " + pass.ToString
            error5V = "  Erorr value: " + comment + value
        End If
    End Sub

End Class

Public Class ReportoTestAccelerometer
    Inherits ResultTestDoneETSDN
    Public testAcc As String = ""
    Public errorAcc As String = ""
    Public Sub SetResulAcc(Optional comment As String = "", Optional pass As Boolean = Nothing, Optional value As String = "")
        If pass Then
            testAcc = " testAccelerometer: " + pass.ToString
        Else
            testAcc = " testAccelerometer: " + pass.ToString
        End If
    End Sub

End Class

Public Class InfoEventTest
    Inherits ResultTestDoneETSDN
    Public buttonStart As String = "", buttonStop As String = ""
    'Function SetStartTest(Optional clickstart As String = "", Optional time As String = "", Optional comment As String = "")

    '    buttonStart = "Button Start: " + clickstart.ToString + " (" + Date.Now.ToLongTimeString + ")" + Environment.NewLine

    'End Function
    'Function SetStopTest(Optional clickstop As String = "", Optional time As String = "", Optional comment As String = "")

    '    buttonStop = "Button Stop: " + clickstop.ToString + " (" + Date.Now.ToLongTimeString + ")" + Environment.NewLine

    'End Function
End Class

Public Class ReportInfoTestEtsdn
    Public sn As String = "", dayn As String = "", line As String = "", namePortal As String = "", nameOperator As String = ""
    'Function SetInfoTest(Optional serial As String = "", Optional day As String = "", Optional title As String = "", Optional portal As String = "",
    '                     Optional name As String = "")
    '    sn = serial.ToString
    '    dayn = day
    '    line = title.ToString
    '    namePortal = portal.ToString
    '    nameOperator = name.ToString
    'End Function
End Class

Public Class WriteRepor
    Public path = Application.StartupPath & "\\log\\Etsdn\\"
    Public serialdevice As String

    Public Function WriteOnFile(a As ReportInfoTestEtsdn)
        Try
            Dim val = My.Computer.FileSystem.OpenTextFileWriter(path & serialdevice, True)
            val.WriteLine(a.line)
            val.WriteLine(a.dayn)
            val.WriteLine(a.sn)
            val.WriteLine(a.nameOperator)
            val.Close()
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try

    End Function

    Public Function WriteOnFile(a As InfoEventTest, b As ReportInfoTestEtsdn)

        Try
            Dim val = My.Computer.FileSystem.OpenTextFileWriter(path & serialdevice, True)

            If a.buttonStart.Contains(True) Then
                val.WriteLine(a.buttonStart)
                val.Close()
            Else
                val.WriteLine(a.buttonStop)
                val.Close()
            End If

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportTestPower, b As ReportInfoTestEtsdn)

        Try
            Dim val = My.Computer.FileSystem.OpenTextFileWriter(path & serialdevice, True)

            If a.checked.Contains(True) Then
                If a.errorPwr = Nothing Or a.errorPwr = "" Then
                    val.WriteLine(a.nameTest, a.checked)
                    val.WriteLine(a.testPwr)
                    val.WriteLine(a.resultTest & Environment.NewLine)
                    val.Close()
                Else
                    val.WriteLine(a.nameTest, a.checked)
                    val.WriteLine(a.testPwr)
                    val.WriteLine(a.errorPwr)
                    val.WriteLine(a.resultTest & Environment.NewLine)
                    val.Close()
                End If
            Else
                val.WriteLine(a.nameTest & a.checked & Environment.NewLine)
                val.Close()
            End If
        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportTestRele, b As ReportInfoTestEtsdn)
        Try
            Dim val = My.Computer.FileSystem.OpenTextFileWriter(path & serialdevice, True)
            If a.checked.Contains(True) Then
                val.WriteLine(a.nameTest, a.checked)
                val.WriteLine(a.testR1)
                val.WriteLine(a.errorR1)
                val.WriteLine(a.testR2)
                val.WriteLine(a.errorR2)
                val.WriteLine(a.testR3)
                val.WriteLine(a.errorR3)
                val.WriteLine(a.resultTest & Environment.NewLine)
                val.Close()
            Else
                val.WriteLine(a.nameTest & a.checked & Environment.NewLine)
                val.Close()
            End If

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportTestInput, b As ReportTestAnalog, c As ReportInfoTestEtsdn)
        Try
            Dim val = My.Computer.FileSystem.OpenTextFileWriter(path & serialdevice, True)
            If a.checked.Contains(True) Then
                val.WriteLine(a.nameTest, a.checked)
                val.WriteLine(a.testIP1)
                val.WriteLine(a.errorIP1)
                val.WriteLine(a.testIP2)
                val.WriteLine(a.errorIP2)
                val.WriteLine(a.testIN1)
                val.WriteLine(a.errorIN1)
                val.WriteLine(a.testIN2)
                val.WriteLine(a.errorIN2)
                val.WriteLine(b.testANA1)
                val.WriteLine(b.testANA2)
                val.WriteLine(a.resultTest & Environment.NewLine)
                val.Close()
            Else
                val.WriteLine(a.nameTest & a.checked & Environment.NewLine)
                val.Close()
            End If

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportTest5V, b As ReportInfoTestEtsdn)
        Try
            Dim val = My.Computer.FileSystem.OpenTextFileWriter(path & serialdevice, True)
            If a.checked.Contains(True) Then
                If a.error5V = Nothing Or a.error5V = "" Then
                    val.WriteLine(a.nameTest, a.checked)
                    val.WriteLine(a.test5V)
                    val.WriteLine(a.resultTest & Environment.NewLine)
                    val.Close()
                Else
                    val.WriteLine(a.nameTest, a.checked)
                    val.WriteLine(a.test5V)
                    val.WriteLine(a.error5V)
                    val.WriteLine(a.resultTest & Environment.NewLine)
                    val.Close()
                End If
            Else
                val.WriteLine(a.nameTest & a.checked & Environment.NewLine)
                val.Close()
            End If

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function WriteOnFile(a As ReportoTestAccelerometer, b As ReportInfoTestEtsdn)
        Try
            Dim val = My.Computer.FileSystem.OpenTextFileWriter(path & serialdevice, True)
            If a.checked.Contains(True) Then
                val.WriteLine(a.nameTest, a.checked)
                val.WriteLine(a.testAcc)
                val.WriteLine(a.resultTest & Environment.NewLine)
                val.Close()
            Else
                val.WriteLine(a.nameTest & a.checked & Environment.NewLine)
                val.Close()
            End If

        Catch ex As Exception
            Console.WriteLine(ex)
        End Try
    End Function

    Public Function ExportFileData()

        Try
            Dim line As String
            Dim readFile As TextReader = New StreamReader(Application.StartupPath & "\\log\\Etsdn\\" & serialdevice)
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

            Dim pdfFilename As String = Application.StartupPath & "\\log\\Etsdn\\LogPDF\\" & serialdevice & ".pdf"
            pdf.Save(pdfFilename)
            readFile.Close()
            readFile = Nothing

            'File.Delete(Application.StartupPath & "\\log\\Etsdn\\" & a.sn)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function



End Class