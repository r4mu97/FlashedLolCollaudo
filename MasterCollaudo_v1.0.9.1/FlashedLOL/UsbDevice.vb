Imports System.Management


Public Class UsbDevice
    'serve a selezionare la usb con cui deve comunicare

    Private Watcher_DeviceChangeEvent As ManagementEventWatcher
    Public DeviceAlreadyConnected As Boolean
    Dim stopmsg As Boolean

    Public Function isConnected()
        Return StartReceiveEvents()

    End Function
    Public Function stopJlink()
        Return StopReceiveEvents()
    End Function

    Private Function StartReceiveEvents()

        '-- primo controllo

        '-- con il codice seguente associo un gestore all'evento DeviceChangeEvent
        '-- in questo modo sarò avvisato quando una periferica usb verrà connessa
        '-- o disconnessa
        Try
            Dim query As New WqlEventQuery(
                    "SELECT * FROM Win32_DeviceChangeEvent")
            Watcher_DeviceChangeEvent = New ManagementEventWatcher(query)
            AddHandler Watcher_DeviceChangeEvent.EventArrived, AddressOf Win32_DeviceChangeEvent
            Watcher_DeviceChangeEvent.Start()
            'CheckDevice()
        Catch ex As ManagementException
            Debug.WriteLine(ex.Message)
        End Try
    End Function

    Private Sub Win32_DeviceChangeEvent(ByVal sender As Object, ByVal e As EventArrivedEventArgs)
        Try
            '-- con il seguente codice recupero il TIPO di evento
            '-- questo esempio si limita a gestire gli inserimenti
            '-- e le rimozioni di periferiche
            Dim MBO As ManagementBaseObject = e.NewEvent
            Dim EventType As Integer

            If Integer.TryParse(MBO.Properties("EventType").Value, EventType) Then
                Select Case EventType

                    Case 1 '-- Configuration Changed

                    Case 2 '-- Device Arrival

                        DeviceArrival()

                    Case 3 '-- Device Removal

                        DeviceRemoval()

                    Case 4 '-- Docking

                End Select
            End If

        Catch ex As ManagementException
            Debug.WriteLine(ex.Message)
        End Try

    End Sub

    'Public Function CheckDevice()

    '    If DeviceConnected() Then
    '        If stopmsg = False Then
    '            stopmsg = True
    '            DeviceAlreadyConnected = True
    '            MsgBox("jlink sisir")
    '            StopReceiveEvents()
    '        End If
    '    Else
    '        DeviceAlreadyConnected = False
    '        MsgBox("jlink NOrir")
    '        '   Me.Invoke(New Action(Of String)(AddressOf SetText), "")
    '    End If

    '    Return DeviceAlreadyConnected
    'End Function

    Private Sub DeviceArrival()
        If Not DeviceAlreadyConnected AndAlso DeviceConnected() Then
            DeviceAlreadyConnected = True
            'Me.Invoke(New Action(Of String)(AddressOf SetText), "jlink ok")
            ' levare il commento se dovremmo mettere uncontrollo su usb device 
            'Me.Invoke(New Action(Of String)(AddressOf SetText), "Periferica Connessa")
        End If
    End Sub

    Private Sub DeviceRemoval()
        If DeviceAlreadyConnected AndAlso Not DeviceConnected() Then
            'Me.Invoke(New Action(Of String)(AddressOf SetText), "jlink NO!!")
            '
            'Me.Invoke(New Action(Of String)(AddressOf SetText), "Periferica Disconnessa")
            DeviceAlreadyConnected = False
        End If
    End Sub



    Private Function DeviceConnected() As Boolean
        Try
            Dim Found As Boolean
            '-- con il codice che segue verifico se il mio HardwareID
            '-- è presente all'interno dell'elenco delle periferiche Plug and Play
            '-- attualmente connesse al sistema
            Using searcher As New ManagementObjectSearcher(
                    "root\CIMV2",
                    "SELECT * FROM Win32_PnPEntity")

                For Each queryObj As ManagementObject In searcher.Get()

                    If queryObj("HardwareID") IsNot Nothing Then
                        Dim arrHardwareID As String() = queryObj("HardwareID")
                        If arrHardwareID.Contains("USB\VID_1366&PID_0102&REV_0100") Then
                            Found = True
                            Exit For
                        End If
                    End If
                Next
            End Using
            Return Found
        Catch ex As ManagementException
            MessageBox.Show("An error occurred while querying for WMI data: " & ex.Message)
            Return False
        End Try
    End Function

    Private Function StopReceiveEvents()
        Try
            If Watcher_DeviceChangeEvent IsNot Nothing Then
                Watcher_DeviceChangeEvent.Stop()
                Watcher_DeviceChangeEvent.Dispose()
            End If
        Catch ex As Exception
            Debug.WriteLine(ex.Message)
        End Try
    End Function


End Class
