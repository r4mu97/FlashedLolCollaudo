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
Imports FlashedLOL.Peak.Can.Basic

Partial Class FrmPeak
    'Private Sub FrmPeak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    Iniializza()
    '    ComboBox2.DisplayMember = "Text"
    '    ComboBox2.Items.Add(New With {.Text = "Nodo 0", .Value = 0})
    '    ComboBox2.Items.Add(New With {.Text = "Nodo 1", .Value = 1})
    '    ComboBox2.Items.Add(New With {.Text = "Nodo 2", .Value = 10})
    '    ComboBox2.Items.Add(New With {.Text = "Nodo 3", .Value = 11})
    '    ComboBox2.Items.Add(New With {.Text = "Nodo 4", .Value = 100})
    '    ComboBox2.Items.Add(New With {.Text = "Nodo 5", .Value = 101})
    '    ComboBox2.Items.Add(New With {.Text = "Nodo 6", .Value = 110})
    '    ComboBox2.Items.Add(New With {.Text = "Nodo 7", .Value = 111})
    '    ComboBox2.Items.Add(New With {.Text = "Nodo 8", .Value = 1000})
    '    ComboBox2.Items.Add(New With {.Text = "Nodo 9", .Value = 1001})

    '    ComboBox1.DisplayMember = "Text"
    '    ComboBox1.Items.Add(New With {.Text = "250 kb/s", .Value = TPCANOPENBaudrate.PCANOPENBAUD_250K})
    '    ComboBox1.Items.Add(New With {.Text = "500 kb/s", .Value = TPCANOPENBaudrate.PCANOPENBAUD_500K})
    '    ComboBox1.Items.Add(New With {.Text = "1000 kb/s", .Value = TPCANOPENBaudrate.PCANOPENBAUD_100K})


    '    ComboBox3.DisplayMember = "text"
    '    ComboBox3.Items.Add(New With {.Text = "SDO", .Value = &B1011})
    '    ComboBox3.Items.Add(New With {.Text = "PDO", .Value = &B11
    '    })


    'End Sub



    Private Sub DropdownComPorts_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub



    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    '    TestRunning.Show()

    '    InitializeBasicComponents()
    '    Dim canChannels = getAvailableCanChannels()

    '    If init_CANOPEN(canChannels(0), ComboBox1.SelectedItem.value, False) Then

    '        Dim canMsg As New TPCANOPENMsg()

    '        Dim tpCanOpen As New TPCANOPEN()

    '        tpCanOpen.node_ID = ComboBox2.SelectedItem.value
    '        tpCanOpen.funcion_ID = ComboBox3.SelectedItem.value


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
    '        canMsg.DATA = New Byte() {1, 2, 3, 4, 5, 6, 7, 8}

    '        sendCANMessage(canMsg)

    '        Dim List As List(Of TPCANMsg)
    '        List = ScanCANMessage(10000)

    '    End If



    'End Sub



    Public Function ScanCANMessage(Optional timeoutMilliseconds As Integer = 100) As List(Of TPCANMsg)

        Dim raw_msg As New TPCANMsg()
        Dim foundNodes As New List(Of TPCANMsg)



        Dim sw As New Stopwatch
        sw.Restart()

        While sw.ElapsedMilliseconds <= timeoutMilliseconds


            If receiveCANMessage(raw_msg) Then
                Dim iCOpenId = raw_msg.ID - &H5
                Dim mio = Convert.ToString(Int64.Parse(raw_msg.ID.ToString()), 2)

                MsgBox("ricevuto ID " & raw_msg.ID)

                If iCOpenId >= 0 And iCOpenId <= &HF Then
                    'If Not foundNodes.Contains(iCOpenId) Then
                    foundNodes.Add(raw_msg)
                    'End If


                    MsgBox("ricevuto IDghghg " & raw_msg.ID)
                End If
            End If
        End While

        Return foundNodes










        unInit_CANOPEN()

    End Function



    Public Sub Iniializza()

    End Sub

End Class




