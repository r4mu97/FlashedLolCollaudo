Imports System.IO
Imports System.Net
Imports System.Threading.Tasks
Imports System.Data.OleDb
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Globalization
Imports FTP
Imports System.Threading

Public Class CercaFile

    Public tmpDownDir As String = Application.StartupPath & "\tmpdownload"
    Private FTP_conf As String = Application.StartupPath & "\FTP_conf.txt"

    Dim mpbtmax, mpbtval As Integer

    Private Sub CercaFile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Icon = Main.Icon

        Catch ex As Exception
            FTP.AggiornaLog(ex)
        End Try
    End Sub

    Sub Enable_FTP(enable As Boolean)
        Try
            ButtonDownload.Enabled = enable
            ButtonSaveSettings.Enabled = enable
            ButtonCheckSum.Enabled = enable
            ButtonDownload.Visible = enable
            ButtonAbort.Visible = Not enable

            GroupBoxFTPStatus.Enabled = Not enable

            TextBoxHost.Enabled = enable
            TextBoxUser.Enabled = enable
            TextBoxPassword.Enabled = enable
            TextBoxConfRoot.Enabled = enable

        Catch ex As Exception
            FTP.AggiornaLog(ex)
        End Try
    End Sub

    Private Sub ButtonProvaConnessione_Click(sender As Object, e As EventArgs) Handles ButtonCheckSum.Click
        'checkFilesIntegrity()
        Try
            Dim op As New OpenFileDialog
            If op.ShowDialog() = DialogResult.OK Then
                If Not File.Exists(op.FileName) Then MessageBox.Show("Il file selezionato non esiste")

                Dim check = (getChecksum(op.FileName))
                Clipboard.SetText(check)
                MessageBox.Show("Checksum copiato negli appunti " & check)

            End If
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub


    Private Sub checkFilesIntegrity()
        Try

            Dim failed As New List(Of String)
            Dim succeded As New List(Of String)
            Dim unknown As New List(Of String)

            For Each Dire In Directory.GetDirectories(Application.StartupPath & "\Bootloader")

                If File.Exists(Dire & "\bootchecksum.txt") AndAlso File.Exists(Dire & "\boot.bin") Then
                    Using sr As New StreamReader(Dire & "\bootchecksum.txt")
                        If checkaChecksum(Dire & "\boot.bin", sr.ReadLine()) = True Then
                            succeded.Add(Dire & "\boot.bin")
                        Else
                            failed.Add(Dire & "\boot.bin")
                        End If
                    End Using
                ElseIf File.Exists(Dire & "\boot.bin") Then
                    unknown.Add(Dire & "\boot.bin")
                End If

                If File.Exists(Dire & "\mainchecksum.txt") AndAlso File.Exists(Dire & "\main.bin") Then
                    Using sr As New StreamReader(Dire & "\mainchecksum.txt")
                        If checkaChecksum(Dire & "\main.bin", sr.ReadLine()) = True Then
                            succeded.Add(Dire & "\main.bin")
                        Else
                            failed.Add(Dire & "\main.bin")
                        End If
                    End Using
                ElseIf File.Exists(Dire & "\main.bin") Then
                    unknown.Add(Dire & "\main.bin")
                End If

            Next

            If Not Directory.Exists(Application.StartupPath & "\ChecksumReports") Then
                Directory.CreateDirectory(Application.StartupPath & "\ChecksumReports")
            End If

            Dim report As String = Application.StartupPath & "\ChecksumReports" &
                        "\ChecksumReport-" & (DateTime.Now.ToShortDateString & "-" & DateTime.Now.ToLongTimeString).Replace("/", "").Replace(":", "") & ".txt"
            Dim a = File.Create(report)
            a.Close()

            Using sw As New StreamWriter(report)
                sw.WriteLine("Checksums failed: =(" & vbCrLf)
                While failed.Count > 0
                    sw.WriteLine(failed(failed.Count - 1))
                    failed.RemoveAt(failed.Count - 1)
                End While
                sw.WriteLine("********************************************" & vbCrLf)
                sw.WriteLine("********************************************" & vbCrLf)

                sw.WriteLine("Checksum unknown: =\" & vbCrLf)
                While unknown.Count > 0
                    sw.WriteLine(unknown(unknown.Count - 1))
                    unknown.RemoveAt(unknown.Count - 1)
                End While
                sw.WriteLine("********************************************" & vbCrLf)
                sw.WriteLine("********************************************" & vbCrLf)

                sw.WriteLine("Checksum succeded: =)" & vbCrLf)
                While succeded.Count > 0
                    sw.WriteLine(succeded(succeded.Count - 1))
                    succeded.RemoveAt(succeded.Count - 1)
                End While
                sw.WriteLine("********************************************" & vbCrLf)
                sw.WriteLine("********************************************" & vbCrLf)
            End Using


            Process.Start(report)

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Private Sub ButtonSaveSettings_Click(sender As Object, e As EventArgs) Handles ButtonSaveSettings.Click
        Try
            abort = False
            Enable_FTP(False)
            If MessageBox.Show("Salvare questi dati nel file di configurazione?", "Conferma", MessageBoxButtons.YesNo) <> Windows.Forms.DialogResult.Yes Then Exit Sub

            If File.Exists(FTP_conf) Then
                File.Delete(FTP_conf)
            End If
            Dim a = File.Create(FTP_conf)
            a.Close()

            Using sw As New StreamWriter(FTP_conf)

                sw.WriteLine(TextBoxHost.Text)
                sw.WriteLine(TextBoxUser.Text)
                sw.WriteLine(TextBoxPassword.Text)
                sw.WriteLine(TextBoxConfRoot.Text)

            End Using

            CercaFile_Shown(Nothing, Nothing)

        Catch ex As Exception
            FTP.AggiornaLog(ex)
        End Try
        Enable_FTP(True)
    End Sub

    Public Sub CercaFile_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            If File.Exists(FTP_conf) Then

                Using sr As New StreamReader(FTP_conf)

                    TextBoxHost.Text = sr.ReadLine()
                    TextBoxUser.Text = sr.ReadLine()
                    TextBoxPassword.Text = sr.ReadLine()
                    TextBoxConfRoot.Text = sr.ReadLine()

                End Using


                FTP.HOST = TextBoxHost.Text
                FTP.USERNAME = TextBoxUser.Text
                FTP.PASSWORD = TextBoxPassword.Text
                FTP.HOST_BASE_PATH = TextBoxConfRoot.Text
                FTP.LOCAL_BASE_PATH = Application.StartupPath & "\Bootloader"
                FTP.Timeout = 60000

                'ButtonDownload_Click(Nothing, Nothing)

            End If
        Catch ex As Exception
            FTP.AggiornaLog(ex)
        End Try
    End Sub

    Private Sub ButtonDownload_Click(sender As Object, e As EventArgs) Handles ButtonDownload.Click
        Try
            abort = False
            Enable_FTP(False)

            ' If FTP_test() = "OK" Then
            ProgressBarFTP.Visible = False
            ProgressBarCurrent.Visible = True
            ProgressBarTotal.Visible = True

            'pbtval = 0
            'pbtmax = 0
            'FTPFolder = 0
            'FTPFile = 0
            'FTPScaricati = 0
            'FTPFIleSize = 0

            Dim FDF As New Task(AddressOf download)
            Dim tmpDowned As Double
            Dim tmpFileSize As Double
            Dim um1 As String = " KB"
            Dim um2 As String = " KB"
            FDF.Start()
            While Not FDF.IsCompleted
                Try
                    Application.DoEvents()

                    LabelFTPFolder.Text = FTPFolder
                    If LabelFTPFolder.Text <> "" Then
                        LabelFTPFile.Text = FTPFile
                    Else
                        LabelFTPFile.Text = ""
                        LabelFTPFolder.Text = FTPFile
                    End If


                    If LabelFTPFolder.Text = "0" Then

                        ProgressBarTotal.Visible = False
                        ProgressBarCurrent.Visible = False
                        ProgressBarFTP.Style = ProgressBarStyle.Marquee
                        ProgressBarFTP.Visible = True

                    Else

                        ProgressBarTotal.Visible = True
                        ProgressBarCurrent.Visible = True
                        ProgressBarFTP.Visible = False
                        ProgressBarFTP.Style = ProgressBarStyle.Blocks
                        ProgressBarTotal.Maximum = mpbtmax
                        ProgressBarCurrent.Maximum = FTPFIleSize
                        If mpbtval <= ProgressBarTotal.Maximum Then
                            ProgressBarTotal.Value = mpbtval
                        End If
                        If FTPScaricati <= ProgressBarCurrent.Maximum Then
                            ProgressBarCurrent.Value = FTPScaricati
                        End If
                    End If

                    tmpDowned = Math.Round(FTPScaricati / 1024, 2)
                    tmpFileSize = Math.Round(FTPFIleSize / 1024, 2)

                    If tmpDowned > 1024 Then
                        tmpDowned = Math.Round(FTPScaricati / 1048576, 2)
                        um1 = " MB"
                    Else
                        um1 = " KB"
                    End If

                    If tmpFileSize > 1024 Then
                        tmpFileSize = Math.Round(FTPFIleSize / 1048576, 2)
                        um2 = " MB"
                    Else
                        um2 = " KB"
                    End If

                    LabelFTPScaricati.Text = tmpDowned & um1 & " / " & tmpFileSize & um2

                Catch
                End Try

            End While


            MessageBox.Show("Finito!")

            ProgressBarTotal.Value = 0
            ProgressBarTotal.Maximum = 1
            ProgressBarCurrent.Maximum = 1
            ProgressBarCurrent.Value = 0
            LabelFTPFolder.Text = "/"
            LabelFTPFile.Text = "/"
            LabelFTPScaricati.Text = 0


            ProgressBarFTP.Visible = True
            ProgressBarCurrent.Visible = False
            ProgressBarTotal.Visible = False


        Catch ex As Exception
            FTP.AggiornaLog(ex)
        End Try
        Enable_FTP(True)
    End Sub

   



    Function download()
        Try
            FTP.rst_status()
            Dim flist = FTP.Get_FileList("")
            mpbtmax = flist.Count()
            mpbtval = 0
            Return "OK".Equals(downloadFolder(flist, "", "", Application.StartupPath & "\Bootloader"))
            ' FTP.DownloadFolder("", , True)
        Catch ex As Exception
            FTP.AggiornaLog(ex)
        End Try
        Return Nothing
    End Function


    Private Function downloadFolder(ByRef filelist As FTP_File(),
                                    ByVal remoteFolderPath As String,
                                    ByVal remoteTargetFolder As String, ByVal localDirectory As String,
                                    Optional ByRef filesDownloaded As Boolean = Nothing) As String
        If Not IsNothing(filesDownloaded) Then filesDownloaded = False
        For Each File In filelist
            mpbtval += 1
            Try
                If abort Then
                    'silent = False
                    'silentDowning = False
                    Return "ABORT"
                End If
                If filelist.Count() < 2 Or File.name = "" Or File.name = "." Or File.name = ".." Or File.name = "timestamp.txt" Then Continue For
                If File.isDirectory Then 'AndAlso File.name = remoteTargetFolder Then
                    remoteTargetFolder = File.name
                    Dim target_docLoc As String = localDirectory
                    If Not Directory.Exists(target_docLoc) Then
                        Directory.CreateDirectory(target_docLoc)
                    End If

                    Dim docFileList = Get_FileList(remoteFolderPath & "/" & File.name, target_docLoc)

                    rst_status()

                    If Not Directory.Exists(target_docLoc & "\" & File.name) Then Directory.CreateDirectory(target_docLoc & "\" & File.name)
                    LOCAL_BASE_PATH = target_docLoc & "\" & File.name

                    For Each docFile In docFileList
                        If filelist.Count < 2 Or
                            docFile.name = "" Or
                            docFile.name = "." Or
                            docFile.name = ".." Or
                            docFile.name = "timestamp.txt" Then Continue For

                        Dim esito As String

                        If docFile.isDirectory Then
                            esito = downloadFolder(docFileList, remoteFolderPath & "/" & remoteTargetFolder, docFile.name, LOCAL_BASE_PATH)
                            If "OK".Equals(esito) Then Continue For
                        Else
                            'If IO.File.Exists(target_docLoc & "\" & docFile.name) And docFile.isNewer = 0 Then Continue For
                            If docFile.isNewer <> 1 Then Continue For
                            esito = downloadFile(docFile.name, "/" & remoteFolderPath & "/" & remoteTargetFolder)
                        End If


                        Select Case esito
                            Case "KO"
                                Throw New Exception("KO: /" & docFile.name)
                            Case "TIMEOUT"
                                Throw New Exception("TIMEOUT: /" & docFile.name)
                            Case "ABORT"
                                'silent = False
                                'silentDowning = False
                                Return "ABORT"
                            Case "OK"
                                'If Not IsNothing(filesDownloaded) Then filesDownloaded = True
                                'For Each fil In Directory.GetFiles(tmpDownDir & "\" & remoteFolderPath & "\" & remoteTargetFolder)
                                '    If IO.File.Exists(target_docLoc & "\" & docFile.name) Then IO.File.Delete(target_docLoc & "\" & docFile.name)
                                '    IO.File.Move(fil, target_docLoc & "\" & docFile.name)
                                'Next
                        End Select

                    Next



                End If

            Catch ex As Exception
                AggiornaLog(ex)
            End Try
        Next
        Return "OK"
    End Function



    Private Sub ButtonAbort_Click(sender As Object, e As EventArgs) Handles ButtonAbort.Click
        Try
            FTP.abort = True
        Catch ex As Exception
            FTP.AggiornaLog(ex)
        End Try
    End Sub


    Private Sub CercaFile_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            Main.Main_Load(Nothing, Nothing)
        Catch ex As Exception
            FTP.AggiornaLog(ex)
        End Try
    End Sub
End Class


