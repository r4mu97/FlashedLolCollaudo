Imports MongoDB.Bson
Imports MongoDB.Driver

Public Class MongoDBdata
    Function commitDeviceCraft(gui As MainEtsdn) As Boolean
        Try
            If Not gui.abortTest Then
                gui.ChangeControlRichText(gui.RichTextBox1, "Progress data on cloud", "Blue")
                'LabelMongostatus.Text = "Invio in corso..."
                'showWait(LabelMongostatus.Text)

                Dim params = populateCraftParameters(gui)

                Dim client = New MongoDB.Driver.MongoClient("mongodb://root:R8HFKaPfZ6Ar@ec2-18-156-33-51.eu-central-1.compute.amazonaws.com:27017")
                Dim db = client.GetDatabase("production_data_prod")
                Dim collection = db.GetCollection(Of MongoDB.Bson.BsonDocument)("Log_ETSDN")
                'Dim ciao = collection.DeleteOne(params.ToBsonDocument())
                collection.InsertOne(params.ToBsonDocument())
                'TODO setMongoId(risp.Replace("_id", ""))

                gui.ChangeControlRichText(gui.RichTextBox1, params.GetElement("Device").Value.AsBsonDocument().GetElement("serial").Value.ToString() & " - Completato", "Green")
                Return True
            End If

        Catch ex As Exception
            gui.ChangeControlRichText(gui.RichTextBox1, "error submit data on cloud", "Red")
            'gui.ChangeControlRichText(gui.RichTextBox1, ex.ToString, 1)
            Return False
        End Try

    End Function

    Function populateCraftParameters(gui As MainEtsdn) As BsonDocument

        Dim par As New BsonDocument()
        Dim tempSerial As String = ""

        Try

            Dim test_effettuati As New BsonDocument()
            Dim userData As New BsonDocument()
            Dim device As New BsonDocument()
            Dim NumTest As New BsonDocument()

            userData.Add("DateTime", DateTime.Now)
            userData.Add("NomeUtente", gui.LblNameOperator.Text)
            userData.Add("UserName", Environment.UserName)
            userData.Add("MachineName", Environment.MachineName)
            userData.Add("UserDomainName", Environment.UserDomainName)


            For Each result In gui.results

                tempSerial = result.GetSerial()
                If result.IsSuccesfull Then
                    test_effettuati.Add(result.NameTest.ToString, "Pass")
                Else
                    test_effettuati.Add(result.NameTest.ToString, "Not Pass")
                    test_effettuati.Add("Error" & result.NameTest.ToString, result.ErrorType.ToString)
                End If

            Next
            If tempSerial = "?" Or tempSerial = "" Then
                tempSerial = InputBox("Insert serial device", " ")
                device.Add("serial", tempSerial.ToString)
            Else
                device.Add("serial", tempSerial.ToString)
            End If


            'faccio aggiungere tutti i dati popolati al documento dichiarato in testa alla funzione che verrà passata alla funzione chiamante
            par.Add("User Data", userData)
            par.Add("Device", device)
            par.Add("Test", test_effettuati)

        Catch ex As Exception
            gui.ChangeControlRichText(gui.RichTextBox1, "Populate Data Error", "Orange")
            'gui.ChangeControlRichText(gui.RichTextBox1, ex.ToString, 1)
        End Try
        Return par

    End Function

End Class
