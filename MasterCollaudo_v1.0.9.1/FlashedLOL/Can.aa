Imports TPCANHandle = System.UInt16
Imports TPCANBitrateFD = System.String
Imports TPCANTimestampFD = System.UInt64
Imports System.Text
Imports FlashedLOL.Peak.Can.Basic

Module CAN_BUS

    Public refusedIDs As Integer() = New Integer() {&H20000, &H20001, &H20002, &H20003,
                                                    &HB0000, &HB0001}

    Public DevicesNames As String() = New String() {"ETSA", "ETSB", "ETSDN"}
    Public DevicesNodes As Byte() = New Byte() {&H3, &H3, &H4}
    'Public Shared DevicesTypes As GR_DEV() = New GR_DEV() {GR_DEV.ETSA1, GR_DEV.ETSB1, GR_DEV.ETSDN}

    Public destCanNode As Byte = DevicesNodes(0)

    Public Const myID As Byte = &H77
    Public CAN_INITIALIZED As Boolean = False


    ' FIXME : presi da Gestione_device.vb del LECU
    Public currentChannel As TPCANHandle = 0
    Public currentBaudrate As TPCANBaudrate = TPCANBaudrate.PCAN_BAUD_500K
    ' FIXME : Presi da LECU_CAN_COMM.vb del LECU
    Public Const PROT_MSG_ID As UInteger = &H7F7



#Region "Delegates"
    ''' <summary>
    ''' Read-Delegate Handler
    ''' </summary>
    Private Delegate Sub ReadDelegateHandler()
#End Region

#Region "Members"
    ''' <summary>
    ''' Saves the desired connection mode
    ''' </summary>
    Private m_IsFD As Boolean
    ''' <summary>
    ''' Saves the handle of a PCAN hardware
    ''' </summary>
    Private m_PcanHandle As TPCANHandle
    ''' <summary>
    ''' Saves the baudrate register for a conenction
    ''' </summary>
    Private m_Baudrate As TPCANBaudrate
    ''' <summary>
    ''' Saves the type of a non-plug-and-play hardware
    ''' </summary>
    Private m_HwType As TPCANType
    ''' <summary>
    ''' Stores the status of received messages for its display
    ''' </summary>
    Private m_LastMsgsList As System.Collections.ArrayList

    ''' <summary>
    ''' Read Delegate for calling the function "ReadMessages"
    ''' </summary>
    Private m_ReadDelegate As ReadDelegateHandler
    ''' <summary>
    ''' Receive-Event
    ''' </summary>
    Private m_ReceiveEvent As System.Threading.AutoResetEvent
    ''' <summary>
    ''' Thread for message reading (using events)
    ''' </summary>
    Private m_ReadThread As System.Threading.Thread
    ''' <summary>
    ''' Handles of the current available PCAN-Hardware
    ''' </summary>
    Private m_HandlesArray As TPCANHandle()
#End Region

#Region "Enumerations"
    ''' <summary>
    ''' Represents a PCAN status/error code
    ''' </summary>
    <Flags()>
    Public Enum TPCANStatus As UInt32
        ''' <summary>
        ''' No error
        ''' </summary>
        PCAN_ERROR_OK = &H0
        ''' <summary>
        ''' Transmit buffer in CAN controller is full
        ''' </summary>
        PCAN_ERROR_XMTFULL = &H1
        ''' <summary>
        ''' CAN controller was read too late
        ''' </summary>
        PCAN_ERROR_OVERRUN = &H2
        ''' <summary>
        ''' Bus error: an error counter reached the 'light' limit
        ''' </summary>
        PCAN_ERROR_BUSLIGHT = &H4
        ''' <summary>
        ''' Bus error: an error counter reached the 'heavy' limit
        ''' </summary>
        PCAN_ERROR_BUSHEAVY = &H8
        ''' <summary>
        ''' Bus error: an error counter reached the 'warning' limit
        ''' </summary>
        PCAN_ERROR_BUSWARNING = PCAN_ERROR_BUSHEAVY
        ''' <summary>
        ''' Bus error: the CAN controller is error passive
        ''' </summary>
        PCAN_ERROR_BUSPASSIVE = &H40000
        ''' <summary>
        ''' Bus error: the CAN controller is in bus-off state
        ''' </summary>
        PCAN_ERROR_BUSOFF = &H10
        ''' <summary>
        ''' Mask for all bus errors
        ''' </summary>
        PCAN_ERROR_ANYBUSERR = (PCAN_ERROR_BUSWARNING Or PCAN_ERROR_BUSLIGHT Or PCAN_ERROR_BUSHEAVY Or PCAN_ERROR_BUSOFF Or PCAN_ERROR_BUSPASSIVE)
        ''' <summary>
        ''' Receive queue is empty
        ''' </summary>
        PCAN_ERROR_QRCVEMPTY = &H20
        ''' <summary>
        ''' Receive queue was read too late
        ''' </summary>
        PCAN_ERROR_QOVERRUN = &H40
        ''' <summary>
        ''' Transmit queue is full
        ''' </summary>
        PCAN_ERROR_QXMTFULL = &H80
        ''' <summary>
        ''' Test of the CAN controller hardware registers failed (no hardware found)
        ''' </summary>
        PCAN_ERROR_REGTEST = &H100
        ''' <summary>
        ''' Driver not loaded
        ''' </summary>
        PCAN_ERROR_NODRIVER = &H200
        ''' <summary>
        ''' Hardware already in use by a Net
        ''' </summary>
        PCAN_ERROR_HWINUSE = &H400
        ''' <summary>
        ''' A Client is already connected to the Net
        ''' </summary>
        PCAN_ERROR_NETINUSE = &H800
        ''' <summary>
        ''' Hardware handle is invalid
        ''' </summary>
        PCAN_ERROR_ILLHW = &H1400
        ''' <summary>
        ''' Net handle is invalid
        ''' </summary>
        PCAN_ERROR_ILLNET = &H1800
        ''' <summary>
        ''' Client handle is invalid
        ''' </summary>
        PCAN_ERROR_ILLCLIENT = &H1C00
        ''' <summary>
        ''' Mask for all handle errors
        ''' </summary>
        PCAN_ERROR_ILLHANDLE = (PCAN_ERROR_ILLHW Or PCAN_ERROR_ILLNET Or PCAN_ERROR_ILLCLIENT)
        ''' <summary>
        ''' Resource (FIFO, Client, timeout) cannot be created
        ''' </summary>
        PCAN_ERROR_RESOURCE = &H2000
        ''' <summary>
        ''' Invalid parameter
        ''' </summary>
        PCAN_ERROR_ILLPARAMTYPE = &H4000
        ''' <summary>
        ''' Invalid parameter value
        ''' </summary>
        PCAN_ERROR_ILLPARAMVAL = &H8000
        ''' <summary>
        ''' Unknown error
        ''' </summary>
        PCAN_ERROR_UNKNOWN = &H10000
        ''' <summary>
        ''' Invalid data, function, or action.
        ''' </summary>
        PCAN_ERROR_ILLDATA = &H20000
        ''' <summary>
        ''' An operation was successfully carried out, however, irregularities were registered
        ''' </summary>
        PCAN_ERROR_CAUTION = &H2000000
        ''' <summary>
        ''' Channel is not initialized
        ''' <remarks>Value was changed from 0x40000 to 0x4000000</remarks>
        ''' </summary>
        PCAN_ERROR_INITIALIZE = &H4000000
        ''' <summary>
        ''' Invalid operation
        ''' <remarks>Value was changed from 0x80000 to 0x8000000</remarks>
        ''' </summary>
        PCAN_ERROR_ILLOPERATION = &H8000000
    End Enum

    ''' <summary>
    ''' Represents a PCAN device
    ''' </summary>
    Public Enum TPCANDevice As Byte
        ''' <summary>
        ''' Undefined, unknown or not selected PCAN device value
        ''' </summary>
        PCAN_NONE = 0
        ''' <summary>
        ''' PCAN Non-Plug And Play devices. NOT USED WITHIN PCAN-Basic API
        ''' </summary>        
        PCAN_PEAKCAN = 1
        ''' <summary>
        ''' PCAN-ISA, PCAN-PC/104, and PCAN-PC/104-Plus
        ''' </summary>
        PCAN_ISA = 2
        ''' <summary>
        ''' PCAN-Dongle
        ''' </summary>
        PCAN_DNG = 3
        ''' <summary>
        ''' PCAN-PCI, PCAN-cPCI, PCAN-miniPCI, and PCAN-PCI Express
        ''' </summary>
        PCAN_PCI = 4
        ''' <summary>
        ''' PCAN-USB and PCAN-USB Pro
        ''' </summary>
        PCAN_USB = 5
        ''' <summary>
        ''' PCAN-PC Card
        ''' </summary>
        PCAN_PCC = 6
        ''' <summary>
        ''' PCAN Virtual hardware. NOT USED WITHIN PCAN-Basic API
        ''' </summary>
        PCAN_VIRTUAL = 7
        ''' <summary>
        ''' PCAN Gateway devices
        ''' </summary>
        PCAN_LAN = 8
    End Enum

    ''' <summary>
    ''' Represents a PCAN parameter to be read or set
    ''' </summary>
    Public Enum TPCANParameter As Byte
        ''' <summary>
        ''' PCAN-USB device number parameter
        ''' </summary>
        PCAN_DEVICE_NUMBER = 1
        ''' <summary>
        ''' PCAN-PC Card 5-Volt power parameter
        ''' </summary>
        PCAN_5VOLTS_POWER = 2
        ''' <summary>
        ''' PCAN receive event handler parameter
        ''' </summary>
        PCAN_RECEIVE_EVENT = 3
        ''' <summary>
        ''' PCAN message filter parameter
        ''' </summary>
        PCAN_MESSAGE_FILTER = 4
        ''' <summary>
        ''' PCAN-Basic API version parameter
        ''' </summary>
        PCAN_API_VERSION = 5
        ''' <summary>
        ''' PCAN device channel version parameter
        ''' </summary>
        PCAN_CHANNEL_VERSION = 6
        ''' <summary>
        ''' PCAN Reset-On-Busoff parameter
        ''' </summary>
        PCAN_BUSOFF_AUTORESET = 7
        ''' <summary>
        ''' PCAN Listen-Only parameter
        ''' </summary>
        PCAN_LISTEN_ONLY = 8
        ''' <summary>
        ''' Directory path for log files
        ''' </summary>
        PCAN_LOG_LOCATION = 9
        ''' <summary>
        ''' Debug-Log activation status
        ''' </summary>
        PCAN_LOG_STATUS = 10
        ''' <summary>
        ''' Configuration of the debugged information (LOG_FUNCTION_***)
        ''' </summary>
        PCAN_LOG_CONFIGURE = 11
        ''' <summary>
        ''' Custom insertion of text into the log file
        ''' </summary>
        PCAN_LOG_TEXT = 12
        ''' <summary>
        ''' Availability status of a PCAN-Channel
        ''' </summary>
        PCAN_CHANNEL_CONDITION = 13
        ''' <summary>
        ''' PCAN hardware name parameter
        ''' </summary>
        PCAN_HARDWARE_NAME = 14
        ''' <summary>
        ''' Message reception status of a PCAN-Channel
        ''' </summary>
        PCAN_RECEIVE_STATUS = 15
        ''' <summary>
        ''' CAN-Controller number of a PCAN-Channel
        ''' </summary>
        PCAN_CONTROLLER_NUMBER = 16
        ''' <summary>
        ''' Directory path for PCAN trace files
        ''' </summary>
        PCAN_TRACE_LOCATION = 17
        ''' <summary>
        ''' CAN tracing activation status
        ''' </summary>
        PCAN_TRACE_STATUS = 18
        ''' <summary>
        ''' Configuration of the maximum file size of a CAN trace
        ''' </summary>
        PCAN_TRACE_SIZE = 19
        ''' <summary>
        ''' Configuration of the trace file storing mode (TRACE_FILE_***)
        ''' </summary>
        PCAN_TRACE_CONFIGURE = 20
        ''' <summary>
        ''' Physical identification of a USB based PCAN-Channel by blinking its associated LED
        ''' </summary>
        PCAN_CHANNEL_IDENTIFYING = 21
        ''' <summary>
        ''' Capabilities of a PCAN device (FEATURE_***)
        ''' </summary>
        PCAN_CHANNEL_FEATURES = 22
        ''' <summary>
        ''' Using of an existing bit rate (PCAN-View connected to a channel)
        ''' </summary>
        PCAN_BITRATE_ADAPTING = 23
        ''' <summary>
        ''' Configured bit rate as Btr0Btr1 value
        ''' </summary>
        PCAN_BITRATE_INFO = 24
        ''' <summary>
        ''' Configured bit rate as TPCANBitrateFD string
        ''' </summary>
        PCAN_BITRATE_INFO_FD = 25
        ''' <summary>
        ''' Configured nominal CAN Bus speed as Bits per seconds
        ''' </summary>
        PCAN_BUSSPEED_NOMINAL = 26
        ''' <summary>
        ''' Configured CAN data speed as Bits per seconds
        ''' </summary>
        PCAN_BUSSPEED_DATA = 27
        ''' <summary>
        ''' Remote address of a LAN channel as string in IPv4 format
        ''' </summary>
        PCAN_IP_ADDRESS = 28
    End Enum

    ''' <summary>
    ''' Represents the type of a PCAN message
    ''' </summary>
    <Flags()>
    Public Enum TPCANMessageType As Byte
        ''' <summary>
        ''' The PCAN message is a CAN Standard Frame (11-bit identifier)
        ''' </summary>
        PCAN_MESSAGE_STANDARD = &H0
        ''' <summary>
        ''' The PCAN message is a CAN Remote-Transfer-Request Frame
        ''' </summary>
        PCAN_MESSAGE_RTR = &H1
        ''' <summary>
        ''' The PCAN message is a CAN Extended Frame (29-bit identifier)
        ''' </summary>
        PCAN_MESSAGE_EXTENDED = &H2
        ''' <summary>
        ''' The PCAN message represents a FD frame in terms of CiA Specs
        ''' </summary>
        PCAN_MESSAGE_FD = &H4
        ''' <summary>
        ''' The PCAN message represents a FD bit rate switch (CAN data at a higher bit rate)
        ''' </summary>
        PCAN_MESSAGE_BRS = &H8
        ''' <summary>
        ''' The PCAN message represents a FD error state indicator(CAN FD transmitter was error active)
        ''' </summary>
        PCAN_MESSAGE_ESI = &H10
        ''' <summary>
        ''' The PCAN message represents a PCAN status message
        ''' </summary>
        PCAN_MESSAGE_STATUS = &H80
    End Enum

    ''' <summary>
    ''' Represents a PCAN filter mode
    ''' </summary>
    Public Enum TPCANMode As Byte
        ''' <summary>
        ''' Mode is Standard (11-bit identifier)
        ''' </summary>
        PCAN_MODE_STANDARD = TPCANMessageType.PCAN_MESSAGE_STANDARD
        ''' <summary>
        ''' Mode is Extended (29-bit identifier)
        ''' </summary>
        PCAN_MODE_EXTENDED = TPCANMessageType.PCAN_MESSAGE_EXTENDED
    End Enum

    ''' <summary>
    ''' Represents a PCAN Baud rate register value
    ''' </summary>
    Public Enum TPCANBaudrate As UInt16
        ''' <summary>
        ''' 1 MBit/s
        ''' </summary>
        PCAN_BAUD_1M = &H14
        ''' <summary>
        ''' 800 kBit/s
        ''' </summary>
        PCAN_BAUD_800K = &H16
        ''' <summary>
        ''' 500 kBit/s
        ''' </summary>
        PCAN_BAUD_500K = &H1C
        ''' <summary>
        ''' 250 kBit/s
        ''' </summary>
        PCAN_BAUD_250K = &H11C
        ''' <summary>
        ''' 125 kBit/s
        ''' </summary>
        PCAN_BAUD_125K = &H31C
        ''' <summary>
        ''' 100 kBit/s
        ''' </summary>
        PCAN_BAUD_100K = &H432F
        ''' <summary>
        ''' 95,238 kBit/s
        ''' </summary>
        PCAN_BAUD_95K = &HC34E
        ''' <summary>
        ''' 83,333 kBit/s
        ''' </summary>
        PCAN_BAUD_83K = &H852B
        ''' <summary>
        ''' 50 kBit/s
        ''' </summary>
        PCAN_BAUD_50K = &H472F
        ''' <summary>
        ''' 47,619 kBit/s
        ''' </summary>
        PCAN_BAUD_47K = &H1414
        ''' <summary>
        ''' 33,333 kBit/s
        ''' </summary>
        PCAN_BAUD_33K = &H8B2F
        ''' <summary>
        ''' 20 kBit/s
        ''' </summary>
        PCAN_BAUD_20K = &H532F
        ''' <summary>
        ''' 10 kBit/s
        ''' </summary>
        PCAN_BAUD_10K = &H672F
        ''' <summary>
        ''' 5 kBit/s
        ''' </summary>
        PCAN_BAUD_5K = &H7F7F
    End Enum

    ''' <summary>
    ''' Represents the type of PCAN (non plug and play) hardware to be initialized
    ''' </summary>
    Public Enum TPCANType As Byte
        ''' <summary>
        ''' PCAN-ISA 82C200
        ''' </summary>
        PCAN_TYPE_ISA = &H1
        ''' <summary>
        ''' PCAN-ISA SJA1000
        ''' </summary>
        PCAN_TYPE_ISA_SJA = &H9
        ''' <summary>
        ''' PHYTEC ISA 
        ''' </summary>
        PCAN_TYPE_ISA_PHYTEC = &H4
        ''' <summary>
        ''' PCAN-Dongle 82C200
        ''' </summary>
        PCAN_TYPE_DNG = &H2
        ''' <summary>
        ''' PCAN-Dongle EPP 82C200
        ''' </summary>
        PCAN_TYPE_DNG_EPP = &H3
        ''' <summary>
        ''' PCAN-Dongle SJA1000
        ''' </summary>
        PCAN_TYPE_DNG_SJA = &H5
        ''' <summary>
        ''' PCAN-Dongle EPP SJA1000
        ''' </summary>
        PCAN_TYPE_DNG_SJA_EPP = &H6
    End Enum
#End Region





    ''' <summary>
    ''' Initialization of PCAN-Basic components
    ''' </summary>
    Public Sub InitializeBasicComponents()
        ' Creates the list for received messages
        '
        'm_LastMsgsList = New System.Collections.ArrayList()
        ' Creates the delegate used for message reading
        '
        'm_ReadDelegate = New ReadDelegateHandler(AddressOf ReadMessages)
        ' Creates the event used for signalize incomming messages 
        '
        'm_ReceiveEvent = New System.Threading.AutoResetEvent(False)
        ' Creates an array with all possible PCAN-Channels
        '
        m_HandlesArray = New TPCANHandle() {PCANBasic.PCAN_ISABUS1, PCANBasic.PCAN_ISABUS2, PCANBasic.PCAN_ISABUS3, PCANBasic.PCAN_ISABUS4, PCANBasic.PCAN_ISABUS5, PCANBasic.PCAN_ISABUS6,
         PCANBasic.PCAN_ISABUS7, PCANBasic.PCAN_ISABUS8, PCANBasic.PCAN_DNGBUS1, PCANBasic.PCAN_PCIBUS1, PCANBasic.PCAN_PCIBUS2, PCANBasic.PCAN_PCIBUS3,
         PCANBasic.PCAN_PCIBUS4, PCANBasic.PCAN_PCIBUS5, PCANBasic.PCAN_PCIBUS6, PCANBasic.PCAN_PCIBUS7, PCANBasic.PCAN_PCIBUS8, PCANBasic.PCAN_PCIBUS9,
         PCANBasic.PCAN_PCIBUS10, PCANBasic.PCAN_PCIBUS11, PCANBasic.PCAN_PCIBUS12, PCANBasic.PCAN_PCIBUS13, PCANBasic.PCAN_PCIBUS14, PCANBasic.PCAN_PCIBUS15,
         PCANBasic.PCAN_USBBUS1, PCANBasic.PCAN_USBBUS2, PCANBasic.PCAN_USBBUS3, PCANBasic.PCAN_USBBUS4, PCANBasic.PCAN_USBBUS5, PCANBasic.PCAN_USBBUS6,
         PCANBasic.PCAN_USBBUS7, PCANBasic.PCAN_USBBUS8, PCANBasic.PCAN_USBBUS9, PCANBasic.PCAN_USBBUS10, PCANBasic.PCAN_USBBUS11, PCANBasic.PCAN_USBBUS12,
         PCANBasic.PCAN_USBBUS13, PCANBasic.PCAN_USBBUS14, PCANBasic.PCAN_USBBUS15, PCANBasic.PCAN_USBBUS16, PCANBasic.PCAN_PCCBUS1, PCANBasic.PCAN_PCCBUS2,
         PCANBasic.PCAN_LANBUS1, PCANBasic.PCAN_LANBUS2, PCANBasic.PCAN_LANBUS3, PCANBasic.PCAN_LANBUS4, PCANBasic.PCAN_LANBUS5, PCANBasic.PCAN_LANBUS6,
         PCANBasic.PCAN_LANBUS7, PCANBasic.PCAN_LANBUS8, PCANBasic.PCAN_LANBUS9, PCANBasic.PCAN_LANBUS10, PCANBasic.PCAN_LANBUS11, PCANBasic.PCAN_LANBUS12,
         PCANBasic.PCAN_LANBUS13, PCANBasic.PCAN_LANBUS14, PCANBasic.PCAN_LANBUS15, PCANBasic.PCAN_LANBUS16}

        ' Fills and configures the Data of several comboBox components
        '
        ' FillComboBoxData()

        ' Prepares the PCAN-Basic's debug-Log file
        '
        ' ConfigureLogFile()
    End Sub




    Function idRefused(ByVal id As Integer)

        If id >> 24 <> &H1F Then Return True

        For Each rID As Integer In refusedIDs

            If rID = id Then Return True

        Next

        Return False

    End Function



    ''' <summary>
    ''' Gets the formated text for a CPAN-Basic channel handle
    ''' </summary>
    ''' <param name="handle">PCAN-Basic Handle to format</param>
    ''' <param name="isFD">If the channel is FD capable</param>
    ''' <returns>The formatted text for a channel</returns>
    Public Function FormatChannelName(ByVal handle As TPCANHandle, ByVal isFD As Boolean) As String
        Dim devDevice As TPCANDevice
        Dim byChannel As Byte

        ' Gets the owner device and channel for a 
        ' PCAN-Basic handle
        '
        If CType(handle, UShort) < &H100 Then
            devDevice = DirectCast(CType(handle >> 4, Byte), TPCANDevice)
            byChannel = CByte((handle And &HF))
        Else
            devDevice = DirectCast(CType(handle >> 8, Byte), TPCANDevice)
            byChannel = CByte((handle And &HFF))
        End If

        ' Constructs the PCAN-Basic Channel name and return it
        '
        If (isFD) Then
            Return String.Format("{0}:FD {1} ({2:X2}h)", devDevice, byChannel, handle)
        Else
            Return String.Format("{0} {1} ({2:X2}h)", devDevice, byChannel, handle)
        End If
    End Function


    ''' <summary>
    ''' Gets the formated text for a CPAN-Basic channel handle
    ''' </summary>
    ''' <param name="handle">PCAN-Basic Handle to format</param>
    ''' <returns>The formatted text for a channel</returns>
    Private Function FormatChannelName(ByVal handle As TPCANHandle) As String
        Return FormatChannelName(handle, False)
    End Function
















    Function getCANserialMessage(cmd As String, dest As Byte) As List(Of TPCANMsg)
        Dim ret As New List(Of TPCANMsg)
        Try

            Dim comando As Char() = cmd.ToCharArray()

            Dim sourceAddr As Integer = myID
            sourceAddr <<= 16
            Dim destAddr As Integer = dest
            destAddr <<= 8


            For Each car As Char In cmd

                ret.Add(New TPCANMsg With {
                        .MSGTYPE = Peak.Can.Basic.TPCANMessageType.PCAN_MESSAGE_EXTENDED,
                        .ID = ((&H1F << 24) Or (sourceAddr) Or (destAddr) Or Asc(car))})

            Next


        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return ret
    End Function







    ''' <summary>
    ''' Help Function used to get an error as text
    ''' </summary>
    ''' <param name="error">Error code to be translated</param>
    ''' <returns>A text with the translated error</returns>
    Private Function GetFormatedError([error] As TPCANStatus) As String
        Dim strTemp As StringBuilder

        ' Creates a buffer big enough for a error-text
        '
        strTemp = New StringBuilder(256)
        ' Gets the text using the GetErrorText API function
        ' If the function success, the translated error is returned. If it fails,
        ' a text describing the current error is returned.
        '
        If PCANBasic.GetErrorText([error], 0, strTemp) <> TPCANStatus.PCAN_ERROR_OK Then
            Return String.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", [error])
        Else
            Return strTemp.ToString()
        End If
    End Function




    Public Function getAPIversion() As String
        Dim strTemp As New StringBuilder(256)
        Try
            PCANBasic.GetValue(PCANBasic.PCAN_NONEBUS, Peak.Can.Basic.TPCANParameter.PCAN_API_VERSION, strTemp, 255)
        Catch ex As Exception
            AggiornaLog(ex)
            Return "MISSING"
        End Try
        Return strTemp.ToString()
    End Function












    Public Function init_CAN(channel As TPCANHandle, bitrate As TPCANBaudrate, Optional xFilterMessagesForLECUComm As Boolean = True) As Boolean
        Try

            InitializeBasicComponents()
            ' PCANBasic.Reset(channel)
            currentChannel = channel
            If (PCANBasic.Initialize(channel, bitrate) = TPCANStatus.PCAN_ERROR_OK) Then

                If xFilterMessagesForLECUComm Then PCANBasic.FilterMessages(channel, PROT_MSG_ID, PROT_MSG_ID, Peak.Can.Basic.TPCANMode.PCAN_MODE_STANDARD)

                CAN_INITIALIZED = True
                Return True
            Else
                PCANBasic.Uninitialize(channel)
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return False
    End Function




    Public Function unInit_CAN() As Boolean
        Try

            If (PCANBasic.Uninitialize(currentChannel) = TPCANStatus.PCAN_ERROR_OK) Then
                CAN_INITIALIZED = False
                Return True
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return False
    End Function

    Public Sub resetBus()
        Try
            PCANBasic.Uninitialize(currentChannel)
            PCANBasic.Initialize(currentChannel, currentbaudrate)
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub



    Public Function getBusStatus() As String
        Try
            Dim st = PCANBasic.GetStatus(currentChannel)
            Select Case st
                Case Peak.Can.Basic.TPCANStatus.PCAN_ERROR_OK
                    Return "BUS OK"
                Case Peak.Can.Basic.TPCANStatus.PCAN_ERROR_BUSLIGHT
                    Return "BUS LIGHT"
                Case Peak.Can.Basic.TPCANStatus.PCAN_ERROR_BUSHEAVY
                    Return "BUS HEAVY"
                Case Peak.Can.Basic.TPCANStatus.PCAN_ERROR_BUSOFF
                    Return "BUS OFF"
                Case Peak.Can.Basic.TPCANStatus.PCAN_ERROR_BUSPASSIVE
                    Return "BUS PASSIVE"
                Case Peak.Can.Basic.TPCANStatus.PCAN_ERROR_BUSWARNING
                    Return "BUS WARNING"
                Case Else
                    Return st.ToString()

            End Select
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return "KO"
    End Function



    Public Function getAvailableCanChannels() As TPCANHandle()
        Try
            Dim ret As New List(Of TPCANHandle)
            Dim iBuffer As UInt32
            Dim stsResult As TPCANStatus
            Dim isFD As Boolean

            For i As Integer = 0 To m_HandlesArray.Length - 1

                If (m_HandlesArray(i) > PCANBasic.PCAN_DNGBUS1) Then
                    ' Checks for a Plug&Play Handle and, according with the return value, includes it
                    ' into the list of available hardware channels.
                    '
                    stsResult = PCANBasic.GetValue(m_HandlesArray(i), TPCANParameter.PCAN_CHANNEL_CONDITION, iBuffer, System.Runtime.InteropServices.Marshal.SizeOf(iBuffer))

                    If (stsResult = TPCANStatus.PCAN_ERROR_OK) AndAlso ((iBuffer And PCANBasic.PCAN_CHANNEL_AVAILABLE) = PCANBasic.PCAN_CHANNEL_AVAILABLE) Then

                        stsResult = PCANBasic.GetValue(m_HandlesArray(i), TPCANParameter.PCAN_CHANNEL_FEATURES, iBuffer, System.Runtime.InteropServices.Marshal.SizeOf(iBuffer))
                        isFD = (stsResult = TPCANStatus.PCAN_ERROR_OK) And ((iBuffer And PCANBasic.FEATURE_FD_CAPABLE) = PCANBasic.FEATURE_FD_CAPABLE)
                        ret.Add(m_HandlesArray(i))
                    End If
                End If
            Next

            Return ret.ToArray()

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return New TPCANHandle() {}
    End Function















End Module
