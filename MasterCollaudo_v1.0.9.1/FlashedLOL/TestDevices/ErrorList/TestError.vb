Public Class TestError

    Protected index As Integer
    Protected value As String
    Protected str As String
    Public errorResult As String

    Public Function GetError(index As Integer, value As String, Optional val As String = "", Optional val1 As String = "", Optional val2 As String = "")
        Select Case index
            Case 0
                Me.value = value / 10
                If str <> "Alimentazione dispositivo troppo bassa " Then
                    Me.str = "Alimentazione dispositivo troppo bassa "
                    Me.errorResult = str & Me.value & "V"
                End If

            Case 1 'errore generato quando apro tutti i rele ma sul rele1 leggo ancora corrente
                If str <> "Errore apertura rele1: continua ad esserci corrente sul rele = " Then
                    Me.value = value
                    Me.str = "Errore apertura rele1: continua ad esserci corrente sul rele = "
                    Me.errorResult = str & Me.value & "mA" & Environment.NewLine
                End If
            Case 2 'errore generato quando apro tutti i rele ma sul rele1 leggo ancora corrente
                If str <> "Errore apertura rele2: continua ad esserci corrente sul rele = " Then
                    Me.value = value
                    Me.str = "Errore apertura rele2: continua ad esserci corrente sul rele = "
                    Me.errorResult = str & Me.value & "mA" & Environment.NewLine
                End If

            Case 3 'errore generato quando apro tutti i rele ma sul rele1 leggo ancora corrente
                If str <> "Errore apertura rele3: continua ad esserci corrente sul rele = " Then
                    Me.value = value
                    Me.str = "Errore apertura rele3: continua ad esserci corrente sul rele = "
                    Me.errorResult = str & Me.value & "mA" & Environment.NewLine
                End If

            Case 4 'errore generato quando la corrente del rele1 supera la soglia
                If str <> "Range accettabilità Rele1 [min 450, max 510] valore letto = " Then
                    Me.value = value
                    Me.str = "Range accettabilità Rele1 [min 450, max 510] valore letto = "
                    Me.errorResult = str & Me.value & "mA" & Environment.NewLine
                End If

            Case 5 'errore generato quando la corrente del rele2 supera la soglia
                If str <> "Range accettabilità Rele2 [min 450, max 510] valore letto = " Then
                    Me.value = value
                    Me.str = "Range accettabilità Rele2 [min 450, max 510] valore letto = "
                    Me.errorResult = str & Me.value & "mA" & Environment.NewLine
                End If

            Case 6 'errore generato quando la corrente del rele3 supera la soglia
                If str <> "Range accettabilità Rele3 [min 450, max 510] valore letto = " Then
                    Me.value = value
                    Me.str = "Range accettabilità Rele3 [min 450, max 510] valore letto = "
                    Me.errorResult = str & Me.value & "mA" & Environment.NewLine
                End If

            Case 7 'errore generato quando il valore del 5volt supera la soglia 
                If str <> "Range accettabilità 5v [min 4,9, max 5,1] valore letto = " Then
                    Me.value = value
                    Me.str = "Range accettabilità 5v [min 4,9, max 5,1] valore letto = "
                    Me.errorResult = str & Me.value & "V" & Environment.NewLine
                End If

            Case 8 'errore generato quando IP1 non funziona 
                If str <> "Errore IP1 [IP1 deve essere 1, tutti gli altri a zero] valori letti = " Then
                    Me.value = "IP1=" & value & " IP2=" & val & " IN1=" & val1 & " IN2=" & val2
                    Me.str = "Errore IP1 [IP1 deve essere 1, tutti gli altri a zero] valori letti = "
                    Me.errorResult = str & Me.value & Environment.NewLine
                End If

            Case 9 'errore generato quando IP2 non funziona 
                If str <> "Errore IP2 [IP2 deve essere 1, tutti gli altri a zero] valori letti = " Then
                    Me.value = "IP2=" & value & " IP1=" & val & " IN1=" & val1 & " IN2=" & val2
                    Me.str = "Errore IP2 [IP2 deve essere 1, tutti gli altri a zero] valori letti = "
                    Me.errorResult = str & Me.value & Environment.NewLine
                End If

            Case 10 'errore generato quando IN1 non funziona 
                If str <> "Errore IN1 [IN1 deve essere 1, tutti gli altri a zero] valori letti = " Then
                    Me.value = "IN1=" & value & " IP1=" & val & " IP2=" & val1 & " IN2=" & val2
                    Me.str = "Errore IN1 [IN1 deve essere 1, tutti gli altri a zero] valori letti = "
                    Me.errorResult = str & Me.value & Environment.NewLine
                End If

            Case 11 'errore generato quando IN2 non funziona 
                If str <> "Errore IN2 [IN2 deve essere 1, tutti gli altri a zero] valori letti = " Then
                    Me.value = "IN2=" & value & " IP2=" & val & " IN1=" & val1 & " IN1=" & val2
                    Me.str = "Errore IN2 [IN2 deve essere 1, tutti gli altri a zero] valori letti = "
                    Me.errorResult = str & Me.value & Environment.NewLine
                End If

            Case 12 'errore generato dall'analogico 5V
                If str <> "Errore Analog 5V" Then
                    Me.value = value
                    Me.str = "Errore Analog 5V"
                    Me.errorResult = str & Environment.NewLine
                End If

            Case 13 'errore generato dall'analogico 10V
                If str <> "Errore Analog 10V" Then
                    Me.value = value
                    Me.str = "Errore Analog 10V"
                    Me.errorResult = str & Environment.NewLine
                End If

            Case 14 'errore generato dall'accellerometro 
                If str <> "Errore Accellerometro" Then
                    Me.str = "Errore Accellerometro"
                    Me.errorResult = str & Environment.NewLine
                End If
        End Select
        Return errorResult
    End Function







End Class
