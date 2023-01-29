Module WaitPanel
    Public PWP
    Private myMe = Main
    Public pwfStopLoading As Boolean = False

    Sub initPWP()
        PWP = New PleaseWaitPanel(Main.PanelPWP)
    End Sub



    Delegate Sub showWaitDelegate(text As String, ByVal current_value As Integer, ByVal maximum_value As Integer,
                                  ByVal current_value2 As Integer, ByVal maximum_value2 As Integer, ByVal abortable As Boolean)

    Sub showWait(text As String,
                        Optional ByVal current_value As Integer = -1, Optional ByVal maximum_value As Integer = -1,
                        Optional ByVal current_value2 As Integer = -1, Optional ByVal maximum_value2 As Integer = -1,
                        Optional ByVal abortable As Boolean = False)
        If myMe.InvokeRequired Then
            myMe.Invoke(New showWaitDelegate(AddressOf showWait), {text, current_value, maximum_value, current_value2, maximum_value2, abortable})
        Else
            Try
                pwfStopLoading = False
                ' If meEnabled Then 
                If PWP IsNot Nothing Then
                    PWP.show_wait(text, current_value, maximum_value, current_value2, maximum_value2, abortable)
                End If
                Application.DoEvents()
            Catch ex As Exception
                AggiornaLog(ex)
            End Try
        End If
    End Sub



    Delegate Sub disposeWaitDelegate(ByVal keepSS As Boolean, ByVal nonriabilitare As Boolean)
    Sub disposeWait(Optional ByVal keepSS As Boolean = False, Optional ByVal nonriabilitare As Boolean = False)
        If myMe.InvokeRequired Then
            myMe.Invoke(New disposeWaitDelegate(AddressOf disposeWait), {keepSS, nonriabilitare})
        Else
            Try
                pwfStopLoading = False
                PWP.dispose_wait()


                '  If Not nonriabilitare Then enableMe(True)



            Catch ex As Exception
                AggiornaLog(ex)
            End Try
        End If
    End Sub


    Public Class PleaseWaitPanel
        Private _panel As Panel
        Private _label As Label
        Private _prgTotal As ProgressBar
        Private _prgCurrent As ProgressBar
        Private _stop As Button
        Public abortable As Boolean
        Sub New(panel As Panel)
            _panel = panel

            For Each ctrl As Control In _panel.Controls
                If ctrl.Name.ToUpper.Equals("LabelPWP_msg".ToUpper) Then
                    _label = ctrl
                ElseIf ctrl.Name.ToUpper.Equals("ProgressBarPWP_current".ToUpper) Then
                    _prgCurrent = ctrl
                ElseIf ctrl.Name.ToUpper.Equals("ProgressBarPWP_total".ToUpper) Then
                    _prgTotal = ctrl
                ElseIf ctrl.Name.ToUpper.Equals("ButtonPWP_stop".ToUpper) Then
                    _stop = ctrl
                End If
            Next

        End Sub


        Public Sub show_wait(text As String,
                        Optional ByVal current_value As Integer = -1, Optional ByVal maximum_value As Integer = -1,
                        Optional ByVal current_value2 As Integer = -1, Optional ByVal maximum_value2 As Integer = -1,
                        Optional ByVal abortable As Boolean = False)

            Try

                centraControlloInParent(_panel)
                _panel.BringToFront()
                _panel.Visible = True
                If _label.Text <> text Then _label.Text = text

                If current_value = -1 Then
                    _prgCurrent.Style = ProgressBarStyle.Marquee
                ElseIf current_value >= 0 And maximum_value > 0 Then
                    _prgCurrent.Style = ProgressBarStyle.Continuous
                    _prgCurrent.Maximum = maximum_value
                    _prgCurrent.Value = current_value
                End If

                _prgTotal.Visible = (current_value2 >= 0)
                If current_value2 >= 0 And maximum_value2 > 0 Then
                    _prgTotal.Maximum = maximum_value2
                    _prgTotal.Value = current_value2
                End If

                _stop.Visible = abortable

            Catch

            End Try
        End Sub


        Public Sub dispose_wait()
            _panel.Visible = False
            _label.Text = ""
            _prgTotal.Visible = False
            _prgCurrent.Value = 0
            _prgCurrent.Style = ProgressBarStyle.Marquee

        End Sub


        Sub centraControlloInParent(ctrl As Control)
            Try
                If IsNothing(ctrl.Parent) Then Return

                Dim cWid = ctrl.Size.Width
                Dim cHei = ctrl.Size.Height
                Dim cIcs = ctrl.Location.X
                Dim cIps = ctrl.Location.Y

                Dim pWid = ctrl.Parent.Width
                Dim pHei = ctrl.Parent.Size.Height

                Dim nIcs = (pWid / 2) - (cWid / 2)
                Dim nIps = (pHei / 2) - (cHei / 2)

                ctrl.Location = New Point(nIcs, nIps)

            Catch

            End Try
        End Sub

    End Class

End Module
