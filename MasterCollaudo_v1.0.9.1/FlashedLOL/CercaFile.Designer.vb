<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CercaFile
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ProgressBarFTP = New System.Windows.Forms.ProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBoxHost = New System.Windows.Forms.TextBox()
        Me.TextBoxUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBoxConfRoot = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ButtonSaveSettings = New System.Windows.Forms.Button()
        Me.ButtonCheckSum = New System.Windows.Forms.Button()
        Me.ButtonDownload = New System.Windows.Forms.Button()
        Me.ButtonAbort = New System.Windows.Forms.Button()
        Me.ProgressBarTotal = New System.Windows.Forms.ProgressBar()
        Me.ProgressBarCurrent = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.LabelFTPFolder = New System.Windows.Forms.Label()
        Me.LabelFTPFile = New System.Windows.Forms.Label()
        Me.LabelFTPScaricati = New System.Windows.Forms.Label()
        Me.GroupBoxFTPStatus = New System.Windows.Forms.GroupBox()
        Me.GroupBoxFTPStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBarFTP
        '
        Me.ProgressBarFTP.Location = New System.Drawing.Point(153, 6)
        Me.ProgressBarFTP.Name = "ProgressBarFTP"
        Me.ProgressBarFTP.Size = New System.Drawing.Size(117, 31)
        Me.ProgressBarFTP.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Host"
        '
        'TextBoxHost
        '
        Me.TextBoxHost.Location = New System.Drawing.Point(65, 6)
        Me.TextBoxHost.Name = "TextBoxHost"
        Me.TextBoxHost.Size = New System.Drawing.Size(82, 20)
        Me.TextBoxHost.TabIndex = 2
        '
        'TextBoxUser
        '
        Me.TextBoxUser.Location = New System.Drawing.Point(65, 32)
        Me.TextBoxUser.Name = "TextBoxUser"
        Me.TextBoxUser.Size = New System.Drawing.Size(82, 20)
        Me.TextBoxUser.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Username"
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Location = New System.Drawing.Point(65, 58)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(82, 20)
        Me.TextBoxPassword.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Password"
        '
        'TextBoxConfRoot
        '
        Me.TextBoxConfRoot.Location = New System.Drawing.Point(65, 84)
        Me.TextBoxConfRoot.Name = "TextBoxConfRoot"
        Me.TextBoxConfRoot.Size = New System.Drawing.Size(205, 20)
        Me.TextBoxConfRoot.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 87)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Conf. root"
        '
        'ButtonSaveSettings
        '
        Me.ButtonSaveSettings.BackgroundImage = Global.FlashedLOL.My.Resources.Res.save
        Me.ButtonSaveSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonSaveSettings.Location = New System.Drawing.Point(235, 43)
        Me.ButtonSaveSettings.Name = "ButtonSaveSettings"
        Me.ButtonSaveSettings.Size = New System.Drawing.Size(35, 35)
        Me.ButtonSaveSettings.TabIndex = 11
        Me.ToolTip1.SetToolTip(Me.ButtonSaveSettings, "Salva impostazioni")
        Me.ButtonSaveSettings.UseVisualStyleBackColor = True
        '
        'ButtonCheckSum
        '
        Me.ButtonCheckSum.BackgroundImage = Global.FlashedLOL.My.Resources.Res._316721
        Me.ButtonCheckSum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonCheckSum.Location = New System.Drawing.Point(153, 43)
        Me.ButtonCheckSum.Name = "ButtonCheckSum"
        Me.ButtonCheckSum.Size = New System.Drawing.Size(35, 35)
        Me.ButtonCheckSum.TabIndex = 9
        Me.ToolTip1.SetToolTip(Me.ButtonCheckSum, "Calcola il cheksum di un file")
        Me.ButtonCheckSum.UseVisualStyleBackColor = True
        '
        'ButtonDownload
        '
        Me.ButtonDownload.BackgroundImage = Global.FlashedLOL.My.Resources.Res.download
        Me.ButtonDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonDownload.Location = New System.Drawing.Point(194, 43)
        Me.ButtonDownload.Name = "ButtonDownload"
        Me.ButtonDownload.Size = New System.Drawing.Size(35, 35)
        Me.ButtonDownload.TabIndex = 10
        Me.ToolTip1.SetToolTip(Me.ButtonDownload, "Scarica file")
        Me.ButtonDownload.UseVisualStyleBackColor = True
        '
        'ButtonAbort
        '
        Me.ButtonAbort.BackgroundImage = Global.FlashedLOL.My.Resources.Res.s_top
        Me.ButtonAbort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ButtonAbort.Location = New System.Drawing.Point(194, 43)
        Me.ButtonAbort.Name = "ButtonAbort"
        Me.ButtonAbort.Size = New System.Drawing.Size(35, 35)
        Me.ButtonAbort.TabIndex = 16
        Me.ToolTip1.SetToolTip(Me.ButtonAbort, "Interrompi")
        Me.ButtonAbort.UseVisualStyleBackColor = True
        '
        'ProgressBarTotal
        '
        Me.ProgressBarTotal.Location = New System.Drawing.Point(153, 6)
        Me.ProgressBarTotal.Maximum = 0
        Me.ProgressBarTotal.Name = "ProgressBarTotal"
        Me.ProgressBarTotal.Size = New System.Drawing.Size(117, 14)
        Me.ProgressBarTotal.Step = 1
        Me.ProgressBarTotal.TabIndex = 12
        Me.ProgressBarTotal.Visible = False
        '
        'ProgressBarCurrent
        '
        Me.ProgressBarCurrent.Location = New System.Drawing.Point(153, 26)
        Me.ProgressBarCurrent.Maximum = 0
        Me.ProgressBarCurrent.Name = "ProgressBarCurrent"
        Me.ProgressBarCurrent.Size = New System.Drawing.Size(117, 14)
        Me.ProgressBarCurrent.Step = 1
        Me.ProgressBarCurrent.TabIndex = 13
        Me.ProgressBarCurrent.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Folder:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 48)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "File:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 78)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Size:"
        '
        'LabelFTPFolder
        '
        Me.LabelFTPFolder.AutoSize = True
        Me.LabelFTPFolder.Location = New System.Drawing.Point(43, 21)
        Me.LabelFTPFolder.Name = "LabelFTPFolder"
        Me.LabelFTPFolder.Size = New System.Drawing.Size(39, 13)
        Me.LabelFTPFolder.TabIndex = 15
        Me.LabelFTPFolder.Text = "Label9"
        '
        'LabelFTPFile
        '
        Me.LabelFTPFile.AutoSize = True
        Me.LabelFTPFile.Location = New System.Drawing.Point(29, 48)
        Me.LabelFTPFile.Name = "LabelFTPFile"
        Me.LabelFTPFile.Size = New System.Drawing.Size(39, 13)
        Me.LabelFTPFile.TabIndex = 15
        Me.LabelFTPFile.Text = "Label9"
        '
        'LabelFTPScaricati
        '
        Me.LabelFTPScaricati.AutoSize = True
        Me.LabelFTPScaricati.Location = New System.Drawing.Point(32, 78)
        Me.LabelFTPScaricati.Name = "LabelFTPScaricati"
        Me.LabelFTPScaricati.Size = New System.Drawing.Size(39, 13)
        Me.LabelFTPScaricati.TabIndex = 15
        Me.LabelFTPScaricati.Text = "Label9"
        '
        'GroupBoxFTPStatus
        '
        Me.GroupBoxFTPStatus.Controls.Add(Me.Label5)
        Me.GroupBoxFTPStatus.Controls.Add(Me.LabelFTPScaricati)
        Me.GroupBoxFTPStatus.Controls.Add(Me.Label6)
        Me.GroupBoxFTPStatus.Controls.Add(Me.LabelFTPFile)
        Me.GroupBoxFTPStatus.Controls.Add(Me.Label8)
        Me.GroupBoxFTPStatus.Controls.Add(Me.LabelFTPFolder)
        Me.GroupBoxFTPStatus.Enabled = False
        Me.GroupBoxFTPStatus.Location = New System.Drawing.Point(276, 6)
        Me.GroupBoxFTPStatus.Name = "GroupBoxFTPStatus"
        Me.GroupBoxFTPStatus.Size = New System.Drawing.Size(146, 98)
        Me.GroupBoxFTPStatus.TabIndex = 17
        Me.GroupBoxFTPStatus.TabStop = False
        Me.GroupBoxFTPStatus.Text = "Stato download"
        '
        'CercaFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 111)
        Me.Controls.Add(Me.GroupBoxFTPStatus)
        Me.Controls.Add(Me.ProgressBarCurrent)
        Me.Controls.Add(Me.ProgressBarTotal)
        Me.Controls.Add(Me.ButtonSaveSettings)
        Me.Controls.Add(Me.ButtonCheckSum)
        Me.Controls.Add(Me.TextBoxConfRoot)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxHost)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ProgressBarFTP)
        Me.Controls.Add(Me.ButtonDownload)
        Me.Controls.Add(Me.ButtonAbort)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "CercaFile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aggiorna file da server FTP"
        Me.GroupBoxFTPStatus.ResumeLayout(False)
        Me.GroupBoxFTPStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBarFTP As System.Windows.Forms.ProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxHost As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxUser As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxConfRoot As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonCheckSum As System.Windows.Forms.Button
    Friend WithEvents ButtonDownload As System.Windows.Forms.Button
    Friend WithEvents ButtonSaveSettings As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ProgressBarTotal As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBarCurrent As System.Windows.Forms.ProgressBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LabelFTPFolder As System.Windows.Forms.Label
    Friend WithEvents LabelFTPFile As System.Windows.Forms.Label
    Friend WithEvents LabelFTPScaricati As System.Windows.Forms.Label
    Friend WithEvents ButtonAbort As System.Windows.Forms.Button
    Friend WithEvents GroupBoxFTPStatus As System.Windows.Forms.GroupBox
    Friend WithEvents DGWGestioneUtenti As System.Windows.Forms.DataGridView
End Class
