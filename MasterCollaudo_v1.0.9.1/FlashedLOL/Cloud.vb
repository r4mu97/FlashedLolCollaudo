Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports Newtonsoft.Json

Public Class Cloud

    Private myLoginUser As String = ""
    Private myLoginPaw As String = ""
    Private loginAddress

    Public cloudConnected As Boolean = False
    Private loginRefused As Boolean = False
    Dim logincookie As CookieContainer
    Public WithEvents cloudWebClient As New CookieAwareWebClient(30 * 1000)
    Private mui = New muistub()
    Private cloudSrv As String


    Delegate Function loginResultValid(risp As String) As Boolean
    Dim loginResultCallback As loginResultValid

    Delegate Function getLoginParameters() As Specialized.NameValueCollection
    Dim getLoginParametersCb As getLoginParameters


    Sub New()
    End Sub
    Sub New(loginAddress As String, un As String, pw As String, loginResultCallback As [Delegate], getLoginParams As [Delegate])
        Me.loginAddress = loginAddress
        myLoginUser = un
        myLoginPaw = pw
        Me.loginResultCallback = loginResultCallback
        getLoginParametersCb = getLoginParams
    End Sub


    Enum LOGIN_RESULT
        SUCCED
        FAIL
        USER_REFUSED
        NO_INTERNET
    End Enum

    Sub Wait(ByVal tempo)

        Dim WC As New Stopwatch

        WC.Reset()
        WC.Start()
        While WC.ElapsedMilliseconds < tempo
            Application.DoEvents()
            System.Threading.Thread.Sleep(1)
        End While


    End Sub

    Private Class muistub
        Public Function Get_String_From_Tag(a, b)
            Return b
        End Function
    End Class


    Function internetAvailable() As Boolean
        Try
            Dim test As New Task(Of Boolean)(Function() As Boolean
                                                 Dim req As WebRequest = WebRequest.Create("http://www.google.com/")
                                                 req.Timeout = 30 * 1000
                                                 Dim resp As WebResponse
                                                 Try
                                                     resp = req.GetResponse()
                                                     resp.Close()
                                                     req = Nothing
                                                     Return True
                                                 Catch ex As Exception
                                                     req = Nothing
                                                     Return False
                                                 End Try
                                             End Function)
            test.Start()
            While Not test.IsCompleted And Not test.IsFaulted
                Wait(100)
            End While
            Return test.Result
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return False
    End Function




    ''' <summary>
    ''' esegue la procedura di login solo se non è attivo un login
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function login(Optional ByVal shouldDisposeWait As Boolean = True) As LOGIN_RESULT
        Try
            If loginRefused Then
                cloudConnected = False
                If shouldDisposeWait Then disposeWait(, True)
                Return LOGIN_RESULT.USER_REFUSED
                'Exit Try
            End If

            If Not cloudConnected Then
                showWait(mui.Get_String_From_Tag("TAG289", "Login in corso..."), abortable:=False)


                If Not internetAvailable() Then
                    ' MessageBox.Show(mui.Get_String_From_Tag("TAG298", "Nessuna connessione internet!"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    cloudConnected = False
                    'Exit Try
                    If shouldDisposeWait Then disposeWait(, True)
                    Return LOGIN_RESULT.NO_INTERNET
                End If

                If Not loginRefused And (myLoginUser.Length > 0 And
                                             myLoginPaw.Length > 0) Then
                    If _internCloudLogin() = LOGIN_RESULT.SUCCED Then
                        If shouldDisposeWait Then disposeWait(, True)
                        Return LOGIN_RESULT.SUCCED
                    End If
                End If

                '  While Not cloudConnected And Not loginRefused And Not pwfStopLoading

                'Select Case loginForm.ShowDialog()
                'Case Windows.Forms.DialogResult.OK

                If _internCloudLogin() = LOGIN_RESULT.SUCCED Then
                    cloudConnected = True
                Else
                    cloudConnected = False
                End If

                'Case Else 'Windows.Forms.DialogResult.Abort
                '    cloudWebClient.Dispose()
                '    cloudConnected = False
                '    loginRefused = True
                '    If shouldDisposeWait Then disposeWait(, True)
                '    Return LOGIN_RESULT.USER_REFUSED
                'End Select
                'loginForm.LabelLoginStatus.ForeColor = Red
                'loginForm.LabelLoginStatus.Text = mui.Get_String_From_Tag("TAG303", "Login fallito, fchecre le credenziali!")
                '   End While
            End If


        Catch ex As Exception
            AggiornaLog(ex)
            logout()
        End Try

        'loginForm.LabelLoginStatus.ForeColor = White
        'loginForm.LabelLoginStatus.Text = ""

        If shouldDisposeWait Then disposeWait(, True)
        If cloudConnected Then
            'StatusMsg(cloudSrv & " - " & mui.Get_String_From_Tag("TAG290", "Login effettuato come") & " " & myLoginUser, , , , True)
            Return LOGIN_RESULT.SUCCED
        Else
            'StatusMsg(mui.Get_String_From_Tag("TAG291", "Login fallito"), , True)
            Return LOGIN_RESULT.FAIL
        End If
        ' Return LOGIN_RESULT.EPIC_FAIL
    End Function

    Function _internCloudLogin() As LOGIN_RESULT
        Dim user As String = myLoginUser
        Dim password As String = myLoginPaw

        Dim login As New Thread(Sub()
                                    Try
                                        If IsNothing(cloudWebClient) Then cloudWebClient = New CookieAwareWebClient(10 * 1000)

                                        Dim reqparm = getLoginParametersCb.Invoke()
                                        '  reqparm.Add("ck", 1)
                                        Dim responsebytes = cloudWebClient.UploadValues(loginAddress, "POST", reqparm)
                                        Dim risp = System.Text.Encoding.UTF8.GetString(responsebytes)
                                        Try
                                            Dim jsonResulttodict = JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(risp)
                                            Dim firstItem = jsonResulttodict.Item("connected")
                                            If firstItem = True Then
                                                risp = "CONNECTED"
                                            End If
                                        Catch ex As Exception
                                        End Try
                                        cloudConnected = loginResultCallback.Invoke(risp)

                                    Catch wex As WebException
                                        If TypeOf wex.Response Is HttpWebResponse Then
                                            MsgBox(DirectCast(wex.Response, HttpWebResponse).StatusCode)
                                        End If
                                        logout()
                                    Catch ex As Exception
                                        AggiornaLog(ex)
                                    End Try
                                End Sub)

        login.Start()
        Dim tio As New Stopwatch
        tio.Start()
        While login.ThreadState = ThreadState.Running And tio.ElapsedMilliseconds < cloudWebClient.Timeout
            Wait(100)
        End While
        If tio.ElapsedMilliseconds > cloudWebClient.Timeout Then
            login.Abort()
            If internetAvailable() Then
                Throw New Exception("Error in web request")
            Else
                MessageBox.Show(mui.Get_String_From_Tag("TAG298", "Nessuna connessione internet!"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                logout()
                Throw New Exception("Error in web request: no internet")
            End If
        End If
        If cloudConnected Then
            Return LOGIN_RESULT.SUCCED
        Else
            Return LOGIN_RESULT.FAIL
        End If
    End Function




    Dim rand As New Random()
    Public Function doPostRequest(reqUrl As String, reqparams As Specialized.NameValueCollection) As String
        Dim post As New Task(Of String)(Function()
                                            Try
                                                If IsNothing(cloudWebClient) Then cloudWebClient = New CookieAwareWebClient(10 * 1000)

                                                reqparams.Add("rand", rand.NextDouble())
                                                Dim responsebytes = cloudWebClient.UploadValues(reqUrl, "POST", reqparams)
                                                Dim risp = System.Text.Encoding.UTF8.GetString(responsebytes)

                                                Return risp
                                            Catch wex As WebException
                                                If TypeOf wex.Response Is HttpWebResponse Then
                                                    MsgBox(DirectCast(wex.Response, HttpWebResponse).StatusCode)
                                                End If
                                            Catch ex As Exception
                                                AggiornaLog(ex)
                                            End Try
                                            Return "KO"
                                        End Function)
        post.Start()
        Dim tio As New Stopwatch
        tio.Start()
        While post.Status = TaskStatus.Running And tio.ElapsedMilliseconds < cloudWebClient.Timeout
            Wait(100)
        End While
        If tio.ElapsedMilliseconds > cloudWebClient.Timeout Then
            If internetAvailable() Then
                Throw New Exception("Error in web request")
            Else
                MessageBox.Show(mui.Get_String_From_Tag("TAG298", "Nessuna connessione internet!"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Throw New Exception("Error in web request: no internet")
            End If
        End If
        Return post.Result
    End Function





    Public Function doGetRequest(reqUrl As String) As String
        Dim post As New Task(Of String)(Function()
                                            Try
                                                If IsNothing(cloudWebClient) Then cloudWebClient = New CookieAwareWebClient(10 * 1000)

                                                Dim risp = cloudWebClient.DownloadString(reqUrl)
                                                Return risp
                                            Catch wex As WebException
                                                If TypeOf wex.Response Is HttpWebResponse Then
                                                    MsgBox(DirectCast(wex.Response, HttpWebResponse).StatusCode)
                                                End If
                                            Catch ex As Exception
                                                AggiornaLog(ex)
                                            End Try
                                            Return "KO"
                                        End Function)
        post.Start()
        Dim tio As New Stopwatch
        tio.Start()
        While post.Status = TaskStatus.Running And tio.ElapsedMilliseconds < cloudWebClient.Timeout
            Wait(100)
        End While
        If tio.ElapsedMilliseconds > cloudWebClient.Timeout Then
            If internetAvailable() Then
                Throw New Exception("Error in web request")
            Else
                MessageBox.Show(mui.Get_String_From_Tag("TAG298", "Nessuna connessione internet!"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Throw New Exception("Error in web request: no internet")
            End If
        End If
        Return post.Result
    End Function

    Public Function doPostJSonRequest(url As String, ByVal dictData As Dictionary(Of String, Object)) As String
        Dim webClient = New CookieAwareWebClient(10 * 1000)
        Dim resByte As Byte()
        Dim resString As String
        Dim reqString() As Byte

        Try
            webClient.Headers("content-type") = "application/json"
            reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))
            resByte = webClient.UploadData(url, "post", reqString)

            resString = Encoding.Default.GetString(resByte)
            webClient.Dispose()
            Return resString
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function

    Public Function doPutJSonRequest(url As String, ByVal dictData As Dictionary(Of String, Object), sessionId As String) As String
        Dim webClient = New CookieAwareWebClient(10 * 1000)
        Dim resByte As Byte()
        Dim resString As String
        Dim reqString() As Byte

        Try
            webClient.Headers("content-type") = "application/json"
            webClient.Headers("Authorization") = "bearer " & sessionId
            reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.None))
            resByte = webClient.UploadData(url, "PUT", reqString)

            resString = Encoding.Default.GetString(resByte)
            webClient.Dispose()
            Return resString
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return False
    End Function


    ''' <summary>
    ''' esegue il logout dal cloud
    ''' </summary>
    ''' <remarks></remarks>
    Public Function logout()
        Try
            'If Not internetAvailable() Then
            '    MessageBox.Show(mui.Get_String_From_Tag("TAG298", "Nessuna connessione internet!"), "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    cloudConnected = False
            '    Exit Try
            'End If

            'If Not IsNothing(cloudSrv) Then Console.Write(cloudWebClient.DownloadString("http://" & cloudSrv & "/index.php?log=out"))

            myLoginPaw = ""
            myLoginUser = ""
            cloudWebClient.Dispose()
            loginRefused = False
            cloudConnected = False
            Return True
            'StatusMsg(mui.Get_String_From_Tag("TAG292", "Logout effettuato"), , , True)
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return False
    End Function


End Class
