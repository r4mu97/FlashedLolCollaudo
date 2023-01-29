Imports System.Text.RegularExpressions
Imports FlashedLOL.Peak.Can.Basic
Imports TPCANHandle = System.UInt16

Module Gestione_device



    Public Function sendCANMessage(msg As TPCANMsg) As Boolean
        Dim result
        result = (PCANBasic.Write(currentChannel, msg) = Peak.Can.Basic.TPCANStatus.PCAN_ERROR_OK)

        Return result
    End Function

    Public Function sendCANMessage(msg As TPCANOPENMsg) As Boolean
        Dim result
        result = (PCANBasic.Write(currentChannel, msg) = Peak.Can.Basic.TPCANStatus.PCAN_ERROR_OK)

        Return result
    End Function


    Public Function receiveCANMessage(ByRef targetMsg As TPCANMsg) As Boolean
        Dim result
        result = (PCANBasic.Read(currentChannel, targetMsg) = Peak.Can.Basic.TPCANStatus.PCAN_ERROR_OK)
        Return result
    End Function




End Module

Module Module1

    Sub Main()
        While True
            Console.WriteLine("Please choose whether to convert:")
            Console.WriteLine("1.) Decimal to Binary")
            Console.WriteLine("2.) Binary to Decimal")
            Dim userChoice As String = Console.ReadLine()
            If userChoice = 1 Then
                Console.WriteLine("Converting from Decimal to Binary.")
                Console.Write("Please enter a Decimal number: ")
                Dim decimalNumber = Console.ReadLine()
                Console.WriteLine(String.Format("Binary representation of {0} in Decimal is {1}.", decimalNumber, ToBinary(decimalNumber)))
            ElseIf userChoice = 2 Then
                Console.WriteLine("Converting from Binary to Decimal.")
                Console.Write("Please enter a Binary number: ")
                Dim binaryNumber = Console.ReadLine()
                Console.WriteLine(String.Format("Decimal representation of {0} in Binary is {1}.", binaryNumber, ToDecimal(binaryNumber)))
            Else
                Console.WriteLine("Please enter a correct value.")
            End If
            Console.WriteLine(Environment.NewLine + "-------------------------------" + Environment.NewLine)
        End While
    End Sub

    Function ToBinary(input As String) As String
        Return Convert.ToString(Int64.Parse(input), 2)
    End Function

    Function ToDecimal(input As String) As String
        Return Convert.ToString(Int64.Parse(input), 10)
    End Function

End Module