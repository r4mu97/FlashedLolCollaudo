
Imports Microsoft.VisualBasic.FileIO
Public Class CreateCSVfile

    'Protected generateData As New System.IO.StreamWriter(Application.StartupPath & "\\log\\Etsdn\\RaccoltaDati.csv")
    Public Sub New(gui As MainEtsdn)
        'generateData = IO.File.AppendText(path)
    End Sub

    'Public Function WriteCSVfile(gui As MainEtsdn)
    '    Dim generateData As New System.IO.StreamWriter(Application.StartupPath & "\\log\\Etsdn\\RaccoltaDati.csv")
    '    Dim i As Integer
    '    Dim j As Integer
    '    Dim text As String
    '    For i = 0 To gui.DataGridView1.Rows.Count - 2

    '        text = ""
    '        For j = 0 To 2
    '            text = text & gui.DataGridView1.Rows(i).Cells(j).Value & ";"
    '        Next
    '        generateData.WriteLine(text)
    '    Next
    '    generateData.Close()
    'End Function
    'Public Function WriteDate(today As String)
    '    generateData.Write(today)
    'End Function
    'Public Function WriteStructure(nameOfTest As String)
    '    generateData.Write(nameOfTest)
    'End Function

    'Public Function WriteSerialDevice(serial As String)
    '    generateData.Write(serial & ";")
    'End Function

    'Public Function WriteResult(result As String)
    '    generateData.Write(result & ";")
    'End Function

    'Public Function WriteError(errorInfo As String)
    '    generateData.Write(errorInfo & ";")
    'End Function

    'Public Function OpenCSVfile()
    '    'generateData = IO.File.AppendText(path)
    'End Function

    'Public Function CloseCSVfile()
    '    generateData.Close()
    'End Function

End Class
