Imports System.Data.OleDb
Imports System.IO
Imports ADOX

Public Class Interfaccia_dbTraduzioni

    Public Const DLLver As String = "2.11C"
    'questa lingua viene considerata come source. 
    'se esiste una lingua che contiene "source" nel nome però, quest'ultima ha la precedenza
    Public Const sourceLangName As String = "Italiano"

    '  variables  
    Dim con As New OleDbConnection
    Dim cmd As New OleDbCommand
    Dim openFileDialogGetSdf As New OpenFileDialog()
    Dim langNum As Integer = 1
    Dim splitArray = New String(1) {Nothing, Nothing}
    Dim PleaseWaitForm As New PleaseWaitForm

    Private defaultLang_ID As Integer = -1
    Private Language_ID As Integer = 0
    Private LangList As New List(Of Language)
    Private notFoundList As New List(Of String)
    Private notTaggedList As New List(Of String)
    Private traduzioni As New List(Of stringhella)

    Public ECHOLOG As Boolean = False

    Public updateSource As Boolean = False

    Public skipEvents As Boolean

    Class stringhella
        Public stringa As String
        Public tag As String
        Public langID As String
        Public idTrad As String
        Public Tradotto As Integer
    End Class


    Public Sub assign_tips(source As Control)
        Dim tt As New ToolTip
        tt.SetToolTip(source, "(" & source.Tag & ")" & source.Text)

        For Each child As Control In source.Controls
            assign_tips(child)
        Next
    End Sub

    Public Sub closeCon()
        con.Close()
    End Sub

    Public Function IndexzOf(ByVal valore, ByVal array)
        Dim counter As Integer = 0
        For Each lol As String In array

            If lol = valore Then Return counter
            counter += 1
        Next
        Return -1
    End Function


    Public Function Init_andGet_Language_List(DB_Path As String, DB_filename As String) As List(Of Language)

        If Not Directory.Exists(DB_Path) Then Directory.CreateDirectory(DB_Path)
        If Not File.Exists(DB_Path & "\" & DB_filename) Then createDB(DB_Path & "\" & DB_filename)

        Try

            If con.State = ConnectionState.Open Then con.Close()
            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DB_Path & "\" & DB_filename



            'con.Open()
            'Dim cmdz As New OleDbCommand("UPDATE TB_TRAD SET STRINGA=@newstr WHERE TRADOTTO=@id", con)
            'cmdz.Parameters.AddWithValue("@newstr", "ciccioprova")
            'cmdz.Parameters.AddWithValue("@id", -1)
            'cmdz.ExecuteNonQuery()
            'cmdz.Dispose()
            'con.Close()




            'get language list
            cmd = New OleDbCommand("SELECT ID_LANG, DESCR FROM TB_LANG", con)
            If con.State = ConnectionState.Closed Then con.Open()
            LangList.Clear()
            Dim i As Integer = 0
            Dim srcId As Integer = -1
            Dim defId As Integer = -1
            Dim reader As OleDbDataReader = cmd.ExecuteReader
            While reader.Read
                LangList.Add(New Language)
                LangList(i).Init_Lingua(reader(0), reader(1))
                If reader(1).ToString.Contains("source") Then srcId = reader(0)
                If reader(1).ToString.Equals(sourceLangName) Then defId = reader(0)
                i += 1
            End While
            If srcId > 0 Then
                defaultLang_ID = srcId
            Else
                defaultLang_ID = defId
            End If

            cmd.Dispose()

            If LangList.Count = 0 Or defaultLang_ID = -1 Then
                cmd = New OleDbCommand("INSERT INTO TB_LANG (DESCR, DATA, OEM) " &
                       "VALUES ('source', @data, -1)", con)
                cmd.Parameters.AddWithValue("@data", Now.Date.ToString)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                Return Init_andGet_Language_List(DB_Path, DB_filename)
            End If

            con.Close()


        Catch ex As Exception
            AggiornaLog(ex)
            con.Close()
        End Try

        Return LangList
    End Function

    Public Sub Load_Traduzioni(ByVal sourceControl As Control, ByVal requestLanguage_ID As Integer,
                               Optional ByVal PrivateShowTags As Boolean = False)
        Try

            'PleaseWaitForm.show_wait("Loading translations from local DB" & vbCrLf & vbCrLf & "                 Please wait...")

            Language_ID = requestLanguage_ID

            For i = 0 To LangList.Count - 1
                If requestLanguage_ID = LangList(i).getID Then
                    Exit For
                End If
                If i = LangList.Count - 1 Then
                    Language_ID = defaultLang_ID
                End If
            Next


            cmd = New OleDbCommand("SELECT T1.STRINGA, T1.ID_TAG, T1.ID_TRAD, T1.TRADOTTO " &
                                   "FROM (SELECT STRINGA, ID_TAG, ID_TRAD, TRADOTTO FROM TB_TRAD) AS T1 " &
                                   "INNER JOIN (SELECT ID_TRAD FROM TB_TRALA WHERE ID_LANG = @idlang) AS T2 " &
                                   "ON T2.ID_TRAD =  T1.ID_TRAD", con)

            cmd.Parameters.AddWithValue("@idlang", Language_ID)

            traduzioni.Clear()
            If con.State = ConnectionState.Closed Then con.Open()
            Dim reader As OleDbDataReader = cmd.ExecuteReader

            While reader.Read
                traduzioni.Add(New stringhella With {.stringa = reader(0), .tag = reader(1),
                                                     .langID = Language_ID, .idTrad = reader(2),
                                                     .Tradotto = reader(3)})       'carico le traduzioni
            End While
            reader.Close()
            cmd.Dispose()

            Go_Deep(sourceControl, traduzioni)

            If PrivateShowTags Then
                'Go_Deep4Tags(sourceControl)
                assign_tips(sourceControl)
            End If

            If notFoundList.Count > 0 Then
                PleaseWaitForm.dispose_wait()
                MessageBox.Show("Not found in " & sourceControl.Name & vbCrLf & Join(notFoundList.ToArray(), ", "))
            End If

            If notTaggedList.Count > 0 Then
                PleaseWaitForm.dispose_wait()
                MessageBox.Show("Not tagged controls in " & sourceControl.Name & vbCrLf & Join(notTaggedList.ToArray(), vbCrLf))
            End If


            ' PleaseWaitForm.dispose_wait()
            notFoundList.Clear()
            notTaggedList.Clear()
            con.Close()

        Catch exx As Exception
            AggiornaLog(exx)
            con.Close()
        End Try
    End Sub



    Function estrapolaDatiPersonali(s As Object) As String()
        Dim ret(2) As String
        Try

            If IsNothing(s) Then
setNull:
                ret(0) = "nulla"
                ret(1) = "nulla"
                ret(2) = "nulla"
                Exit Try
            End If

            If TypeOf s Is Control Then
                ret(0) = godeep43(s, "") & s.name

                ret(1) = godeep4location(s, s.location.x.ToString & "," & s.location.y.ToString)

                ret(2) = s.size.width & "," & s.size.height

            Else
                GoTo setNull
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try

        Return ret
    End Function


    Function godeep43(source As Control, ByRef tree As String) As String
        Try

            If Not IsNothing(source.Parent) Then
                tree = source.Parent.Name & "->" & tree
                godeep43(source.Parent, tree)
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return tree
    End Function

    Function godeep4location(source As Control, ByRef XY As String) As String
        Dim X, Y As Integer
        Try

            X = Split(XY, ",")(0)
            Y = Split(XY, ",")(1)

            If Not IsNothing(source.Parent) Then
                X += source.Parent.Location.X
                Y += source.Parent.Location.Y
                godeep4location(source.Parent, X.ToString & "," & Y.ToString)
            End If


        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return X.ToString & "," & Y.ToString
    End Function



    Function findTag(tag As String, str As String, Trad_List As List(Of stringhella), Optional sender As Object = Nothing) As String

        Try
            Dim found As stringhella = Nothing

            For Each strHella As stringhella In Trad_List
                If strHella.langID = Language_ID AndAlso strHella.tag = tag Then
                    found = strHella
                End If
            Next

            If IsNothing(found) Then


                Try

                    Dim datiPers() As String

                    datiPers = estrapolaDatiPersonali(sender)

                    tag = insertGetTag(tag, datiPers(0), datiPers(1), datiPers(2))



                    For Each lang As Language In LangList

                        Dim idTrad As String = ""

                        'select
                        Dim query As New OleDbCommand("SELECT T1.ID_TRAD, T2.ID " &
                                       "FROM (SELECT STRINGA, ID_TAG, ID_TRAD FROM TB_TRAD) AS T1 " &
                                       "INNER JOIN (SELECT ID_TRAD, ID FROM TB_TRALA WHERE ID_LANG = @idlang) AS T2 " &
                                       "ON (T2.ID_TRAD = T1.ID_TRAD AND T1.ID_TAG=@tag)", con)

                        query.Parameters.AddWithValue("@idlang", lang.getID)
                        query.Parameters.AddWithValue("@tag", tag)
                        Dim reader As OleDbDataReader = query.ExecuteReader()

                        Dim idTrala As String = ""

                        While reader.Read
                            Try
                                idTrad = reader(0)
                                idTrala = reader(1)
                            Catch ex As Exception
                            End Try
                        End While
                        reader.Close()
                        query.Dispose()


                        Dim tradotto As Integer = 0
                        If lang.getID = defaultLang_ID Then tradotto = -1


                        If idTrad <> "" And idTrala = "" Then

                            idTrala = insertGetTrala(idTrad, lang.getID)


                        ElseIf idTrad = "" And idTrala = "" Then

                            idTrad = insertGetTraduzione(str, tag, 0)
                            idTrala = insertGetTrala(idTrad, lang.getID)

                        End If

                        If lang.getID = Language_ID Then
                            Trad_List.Add(New stringhella With {.langID = Language_ID, .stringa = str, .tag = tag,
                                                                .idTrad = idTrad})
                            found = Trad_List(Trad_List.Count - 1)
                        End If

                    Next


                Catch ex As Exception
                    AggiornaLog(ex)
                End Try



            Else



                If updateSource AndAlso found.stringa <> str Then

                    If Language_ID <> defaultLang_ID Then Exit Try


                    'Dim trado As Integer = 0
                    'If Language_ID = defaultLang_ID Then trado = -1


                    If con.State = ConnectionState.Closed Then con.Open()

                    Dim cmdz As New OleDbCommand("SELECT ID_TRAD FROM TB_TRAD WHERE ID_TAG=@tag", con)
                    cmdz.Parameters.AddWithValue("@tag", found.tag)
                    Dim ids As New List(Of String)
                    Dim reader As OleDbDataReader = cmdz.ExecuteReader()
                    While reader.Read
                        ids.Add(reader(0))
                    End While
                    reader.Close()
                    cmdz.Dispose()



                    cmdz = New OleDbCommand("DELETE FROM TB_TRAD WHERE ID_TRAD IN " &
                                            "(SELECT ID_TRAD FROM TB_TRAD WHERE ID_TAG=@tag)", con)
                    cmdz.Parameters.AddWithValue("@tag", found.tag)
                    cmdz.ExecuteNonQuery()
                    cmdz.Dispose()



                    cmdz = New OleDbCommand("INSERT INTO TB_TRAD (ID_TAG,STRINGA,TRADOTTO) VALUES(@tag,@newstr,@trado)", con)
                    cmdz.Parameters.AddWithValue("@tag", found.tag)
                    cmdz.Parameters.AddWithValue("@newstr", str)
                    cmdz.Parameters.AddWithValue("@trado", 0)
                    cmdz.ExecuteNonQuery()
                    cmdz.Dispose()


                    Dim idtrad As String = mysql_insert_id("TB_TRAD", "ID_TRAD")



                    For Each id In ids

                        cmdz = New OleDbCommand("UPDATE TB_TRALA SET ID_TRAD=@newID WHERE ID_TRAD=@oldID", con)

                        cmdz.Parameters.AddWithValue("@newID", idtrad)
                        cmdz.Parameters.AddWithValue("@oldID", id)
                        cmdz.ExecuteNonQuery()
                        cmdz.Dispose()

                    Next



                    found.stringa = str
                    found.Tradotto = 0

                End If


            End If

            If IsNothing(found) Then
                Return str
            Else
                Return found.stringa
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return ""
    End Function


    Function insertGetTag(tag As String, Optional FamTree As String = "nulla", Optional AbsLoc As String = "nulla", Optional size As String = "nulla") As String
        Try
            If con.State = ConnectionState.Closed AndAlso con.ConnectionString.Length > 0 Then
                con.Open()
            ElseIf con.State = ConnectionState.Closed AndAlso con.ConnectionString.Length = 0 Then
                Return tag
            End If


            Dim coomando As New OleDbCommand("SELECT ID_TAG FROM TB_TAG WHERE ID_TAG=@idtag", con)
            coomando.Parameters.AddWithValue("@idtag", tag)
            Dim reeead As OleDbDataReader = coomando.ExecuteReader
            Dim idTag As String = ""

            While reeead.Read()
                idTag = reeead(0)
            End While
            reeead.Close()
            coomando.Dispose()


            If idTag <> "" Then

                Dim comma As New OleDbCommand("UPDATE TB_TAG SET ID_TAG=@tag, FAMTREE=@tree, ABSLOC=@loc, SIZ=@size " &
                                              "WHERE ID_TAG=@tag", con)

                comma.Parameters.AddWithValue("@tag", tag)
                comma.Parameters.AddWithValue("@tree", FamTree)
                comma.Parameters.AddWithValue("@loc", AbsLoc)
                comma.Parameters.AddWithValue("@size", size)

                comma.ExecuteNonQuery()
                comma.Dispose()

            Else


                coomando = New OleDbCommand("INSERT INTO TB_TAG (ID_TAG, FAMTREE, ABSLOC, SIZ) " &
                                            "VALUES (@idtag, @tree, @loc, @size)", con)

                coomando.Parameters.AddWithValue("@idtag", tag)
                coomando.Parameters.AddWithValue("@tree", FamTree)
                coomando.Parameters.AddWithValue("@loc", AbsLoc)
                coomando.Parameters.AddWithValue("@size", size)
                coomando.ExecuteNonQuery()
                coomando.Dispose()

            End If



        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return tag
    End Function



    Function insertGetTrala(idTrad As String, languageID As String) As String
        Dim id As String = ""
        Try
            If con.State = ConnectionState.Closed AndAlso con.ConnectionString.Length > 0 Then
                con.Open()
            ElseIf con.State = ConnectionState.Closed AndAlso con.ConnectionString.Length = 0 Then
                Return id
            End If

            Dim cmdz As OleDbCommand = New OleDbCommand("SELECT ID FROM TB_TRALA " &
                                                       "WHERE (ID_TRAD=@idtrad AND ID_LANG=@langid)", con)
            cmdz.Parameters.AddWithValue("@idtrad", idTrad)
            cmdz.Parameters.AddWithValue("@langid", languageID)

            Dim lettore As OleDbDataReader = cmdz.ExecuteReader

            While lettore.Read
                id = lettore(0)
            End While
            lettore.Close()
            cmdz.Dispose()


            If id = "" Then

                cmdz = New OleDbCommand("INSERT INTO TB_TRALA (ID_TRAD,ID_LANG) " &
                                            "VALUES(@idTrad,@idLang)", con)


                cmdz.Parameters.AddWithValue("@idTrad", idTrad)
                cmdz.Parameters.AddWithValue("@idLang", languageID)
                cmdz.ExecuteNonQuery()
                cmdz.Dispose()
                id = mysql_insert_id("TB_TRALA", "ID")
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try

        Return id

    End Function


    Function insertGetTraduzione(stringa As String, tag As String, tradotto As Integer) As String
        Dim id As String = ""

        Try
            If con.State = ConnectionState.Closed AndAlso con.ConnectionString.Length > 0 Then
                con.Open()
            ElseIf con.State = ConnectionState.Closed AndAlso con.ConnectionString.Length = 0 Then
                Return id
            End If

            Dim cmdz As OleDbCommand = New OleDbCommand("SELECT ID_TRAD FROM TB_TRAD " &
                                                        "WHERE (STRINGA=@str AND ID_TAG=@tag)", con)
            cmdz.Parameters.AddWithValue("@str", stringa)
            cmdz.Parameters.AddWithValue("@tag", tag)

            Dim lettore As OleDbDataReader = cmdz.ExecuteReader

            While lettore.Read
                id = lettore(0)
            End While
            lettore.Close()
            cmdz.Dispose()


            If id = "" Then
                cmdz = New OleDbCommand("INSERT INTO TB_TRAD (STRINGA,ID_TAG, TRADOTTO) " &
                                                             "VALUES(@str,@tag,@trad)", con)

                cmdz.Parameters.AddWithValue("@str", stringa)
                cmdz.Parameters.AddWithValue("@tag", tag)
                cmdz.Parameters.AddWithValue("@trad", tradotto)
                cmdz.ExecuteNonQuery()
                cmdz.Dispose()
                id = mysql_insert_id("TB_TRAD", "ID_TRAD")
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try

        Return id
    End Function



    Function mysql_insert_id(table As String, column As String) As String
        Dim ret As String = ""

        Try
            If con.State = ConnectionState.Closed Then con.Open() 'open up a connection to the database
            cmd = New OleDb.OleDbCommand("select max(" & column & ") from " & table, con)
            Dim reader As OleDb.OleDbDataReader = cmd.ExecuteReader()

            While reader.Read
                ret = reader.GetValue(0)
            End While

            reader.Close()
            cmd.Dispose()

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return ret
    End Function

    Public Sub Go_Deep(source As Control, Trad_List As List(Of stringhella))
        Dim temp As String = Nothing
        Try
            Application.DoEvents()


            Try
                If source.Tag = "" Then
                    addNonTaggato(source)
                    GoTo skip
                End If
                temp = source.Text
            Catch
                GoTo skip
            End Try

            If TypeOf source Is ComboBox Or TypeOf source Is ListBox Then
                Try
                    Go_Deep_ComboBox(source, Trad_List)
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try

            ElseIf TypeOf source Is DataGridView Then
                Try
                    Go_Deep_DataGridView(source, Trad_List)
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try

            ElseIf TypeOf source Is TreeView Then
                Try
                    Go_Deep_TreeView(source, Trad_List)
                Catch ex As Exception
                    AggiornaLog(ex)
                End Try

            ElseIf TypeOf source Is ToolStrip Then
                If Not source.ToString.Contains("StatusStrip") Then
                    Try
                        Go_Deep_ToolStrip(source, Trad_List)
                    Catch ex As Exception
                        AggiornaLog(ex)
                    End Try
                End If


            Else

                Try
                    If source.Tag.ToString.ToUpper = "DONTLOAD" Then GoTo skip
                Catch
                    GoTo skip
                End Try

                source.Text = findTag(source.Tag, temp, Trad_List, source)


            End If




            If source.Text = "" Then source.Text = temp '"(" & source.Tag & ")" & temp


skip:

            If source.HasChildren And Not TypeOf source Is DataGridView Then
                For Each child In source.Controls
                    Go_Deep(child, Trad_List)
                Next
            End If

            Exit Try


        Catch ex As Exception
            AggiornaLog(ex)
        End Try


    End Sub


    Sub addNonTaggato(source As Object)
        Try
            If source.Tag = "" Then
                notTaggedList.Add(godeep43(source, "") & source.Name)
            End If
        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Public Sub Go_Deep_TreeView(source As TreeView, Trad_List As List(Of stringhella))

        Try
            For Each node As TreeNode In source.Nodes
                traduciNodes(node, Trad_List)
            Next

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Public Sub traduciNodes(source As TreeNode, Trad_List As List(Of stringhella))

        Try

            Try
                If Not source.Tag.ToString.ToUpper = "DONTLOAD" Then
                    source.Text = findTag(source.Tag, source.Text, Trad_List, source)
                End If
            Catch
            End Try

            If source.Nodes.Count > 0 Then
                For Each childNode As TreeNode In source.Nodes
                    traduciNodes(childNode, Trad_List)
                Next
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Public Sub Go_Deep_ToolStrip(source As ToolStrip, Trad_List As List(Of stringhella))
        For Each itm As ToolStripMenuItem In source.Items
            traduci_ToolStrip(itm, Trad_List)
        Next
    End Sub

    Public Sub traduci_ToolStrip(source As ToolStripMenuItem, Trad_List As List(Of stringhella))

        Try

            Try
                If Not source.Tag.ToString.ToUpper = "DONTLOAD" Then
                    source.Text = findTag(source.Tag, source.Text, Trad_List, source)
                End If
            Catch
            End Try

            If source.DropDownItems.Count > 0 Then
                For Each child As ToolStripDropDownItem In source.DropDownItems
                    traduci_ToolStrip(child, Trad_List)
                Next
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Public Sub Go_Deep_ComboBox(source As Object, Trad_List As List(Of stringhella))

        Try
            Try
                If source.Tag.ToString.ToUpper = "DONTLOAD" Then GoTo skipp
            Catch
                GoTo skipp
            End Try

            Dim strr As String = Nothing
            For Each item In source.Items
                strr += item & "|"
            Next
            If Not IsNothing(strr) Then strr = strr.Remove(strr.Length - 1, 1)

            Dim risposta As String = findTag(source.Tag, strr, Trad_List, source)

            If risposta.Contains("|") Then
                source.Items.Clear()
                Dim itmCol() As String
                itmCol = Split(risposta, "|")
                For ii = 0 To itmCol.Count - 1
                    source.Items.Add(itmCol(ii))
                Next
            End If

skipp:
            If TypeOf source Is ComboBox And source.Items.Count > 0 Then
                skipEvents = True
                source.SelectedIndex = 0
                skipEvents = False
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Public Sub Go_Deep_DataGridView(source As DataGridView, Trad_List As List(Of stringhella))


        Try

            Try
                If source.Tag.ToString.ToUpper = "DONTLOAD" Then Exit Sub
            Catch
                Exit Sub
            End Try

            Dim strr As String = Nothing
            For Each column As DataGridViewColumn In source.Columns
                strr += column.HeaderText & "|"
            Next
            If Not IsNothing(strr) Then strr = strr.Remove(strr.Length - 1, 1)

            Dim risposta As String = findTag(source.Tag, strr, Trad_List, source)

            If risposta.Contains("|") Then
                Dim itmCol() As String
                itmCol = Split(risposta, "|")
                For ii = 0 To itmCol.Length - 1
                    source.Columns(ii).HeaderText = itmCol(ii)
                Next
            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
    End Sub

    Public Sub Go_Deep4Tags(source As Control)
        If TypeOf source Is Form Or TypeOf source Is TextBox Or TypeOf source Is Label Or TypeOf source Is Button Or TypeOf source Is DataGridView _
           Or TypeOf source Is ListBox Or TypeOf source Is ComboBox Or TypeOf source Is RadioButton Or TypeOf source Is CheckBox Or TypeOf source Is TextBox _
           Or TypeOf source Is PictureBox Or TypeOf source Is ListView Or TypeOf source Is GroupBox Or TypeOf source Is Panel Then
            source.Text = "(" & source.Tag & ")" & source.Text
            For Each child In source.Controls

                If source.HasChildren Then Go_Deep4Tags(child)
            Next
        End If
    End Sub

    Public Function Get_String_From_Tag(tag As String, defString As String) As String
        Dim retStr As String = ""
        Try

            retStr = findTag(tag, defString, traduzioni)

            If retStr = "" Then
                retStr = defString
            End If

        Catch ex As Exception
            AggiornaLog(ex)
            retStr = defString
        End Try
        Return retStr
    End Function

    Public Function decidi_se_uppare(tagg As String, stringaa As String) As String

        Try
            If stringaa = "" Or tagg = "" Or tagg = "DONTLOAD" Or defaultLang_ID = 0 Then Return ""

            If con.State = ConnectionState.Closed Then con.Open()


            Dim trad As stringhella = traduzioni.Find(Function(x) x.langID = Language_ID AndAlso x.tag = tagg)

            If Not IsNothing(trad) Then

                If Language_ID = defaultLang_ID AndAlso trad.stringa <> stringaa Then

                    cmd = New OleDbCommand("UPDATE TB_TRADUZIONI SET " &
                                     "STRING=@strnew WHERE TAG=@tag AND STRING=@strold AND LANGUAGE_ID=@id", con)

                    cmd.Parameters.AddWithValue("@strnew", stringaa)
                    cmd.Parameters.AddWithValue("@tag", trad.tag)
                    cmd.Parameters.AddWithValue("@strold", trad.stringa)
                    cmd.Parameters.AddWithValue("@id", defaultLang_ID)

                    cmd.ExecuteNonQuery()

                    trad.stringa = stringaa

                    Return stringaa

                End If

            Else

                'insert 

                cmd = New OleDbCommand("INSERT INTO TB_TRADUZIONI (STRING,TAG,LANGUAGE_ID) " &
                                       "VALUES(@str,@tag,@id)", con)

                If Language_ID <> defaultLang_ID Then
                    stringaa = "*" & stringaa
                End If

                cmd.Parameters.AddWithValue("@str", stringaa)
                cmd.Parameters.AddWithValue("@tag", tagg)
                cmd.Parameters.AddWithValue("@id", Language_ID)

                cmd.ExecuteNonQuery()

                traduzioni.Add(New stringhella With {.tag = tagg, .stringa = stringaa, .langID = Language_ID})

            End If

        Catch ex As Exception
            AggiornaLog(ex)
        End Try
        Return stringaa
    End Function

    Public Sub createDB(path As String)

        Try

            con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path
            Dim cat As Catalog = New Catalog()
            cat.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & path & ";Jet OLEDB:Engine Type=5")

            If con.State = ConnectionState.Closed Then con.Open()

            cmd = New OleDbCommand("CREATE TABLE [TB_TAG]" &
                                   "([ID_TAG] NVARCHAR(10) NOT NULL PRIMARY KEY, " &
                                   "[FAMTREE] NTEXT NULL, " &
                                   "[ABSLOC] NVARCHAR(10) NULL, " &
                                   "[SIZ] NVARCHAR(10) NULL)", con)
            cmd.ExecuteNonQuery()
            cmd.Dispose()


            cmd = New OleDbCommand("CREATE TABLE [TB_TRAD]" &
                                   "([ID_TRAD] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " &
                                   "[ID_TAG] NVARCHAR(10) NOT NULL, " &
                                   "[STRINGA] NTEXT NOT NULL, " &
                                   "[TRADOTTO] BIT NOT NULL DEFAULT 0)", con)
            cmd.ExecuteNonQuery()
            cmd.Dispose()


            cmd = New OleDbCommand("CREATE TABLE [TB_TRALA]" &
                                   "([ID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " &
                                   "[ID_TRAD] INT NOT NULL, " &
                                   "[ID_LANG] INT NOT NULL)", con)
            cmd.ExecuteNonQuery()
            cmd.Dispose()


            cmd = New OleDbCommand("CREATE TABLE [TB_LANG]" &
                                   "([ID_LANG] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " &
                                   "[DESCR] NVARCHAR(50) NOT NULL, " &
                                   "[DATA] DATETIME NOT NULL, " &
                                   "[OEM] BIT NOT NULL DEFAULT 0)", con)
            cmd.ExecuteNonQuery()
            cmd.Dispose()


        Catch ex As Exception
            AggiornaLog(ex)
        End Try

        con.Close()

    End Sub


    Sub AggiornaLog(ByVal ex As Exception)
        Try


            If ECHOLOG Then MessageBox.Show(ex.Message)
            Dim Temp As FileStream = Nothing

            Dim LogPath As String = System.Windows.Forms.Application.StartupPath
            Dim Testo As String



            If (Not System.IO.Directory.Exists(LogPath & "\Log")) Then
                System.IO.Directory.CreateDirectory(LogPath & "\Log")
            End If


            If Not File.Exists(LogPath & "\Log\Log.txt") Then
                Temp = File.Create(LogPath & "\Log\Log.txt")
                Temp.Close()
            End If

            Dim info As New FileInfo(LogPath & "\Log\Log.txt")
            If info.Length > 1048576 Then
                File.Delete(LogPath & "\Log\Log.txt")
                Temp = File.Create(LogPath & "\Log\Log.txt")
                Temp.Close()
            End If

            Using Log As StreamReader = New StreamReader(LogPath & "\Log\Log.txt")

                Testo = Log.ReadToEnd()
                Log.Close()
            End Using

            Using Log As StreamWriter = New StreamWriter(LogPath & "\Log\Log.txt")

                Log.WriteLine(Now() & " " & ex.Message & " " & ex.StackTrace)


                Log.WriteLine(Testo)
            End Using

        Catch ex1 As Exception

        End Try
    End Sub
End Class


Public Class Language
    Private ID As Integer
    Private Name As String

    Public Sub Init_Lingua(id As Integer, nome As String)
        Me.ID = id
        Me.Name = nome
    End Sub

    Public Function getID()
        Return Me.ID
    End Function

    Public Function getName()
        Return Me.Name
    End Function
End Class

Public Class PleaseWaitForm

    Private formz As Form
    Private lbl As Label
    Private prgBar As ProgressBar
    Private prgBar2 As ProgressBar
    Private abortBtn As Button
    Public parent As Object
    Public esc As Boolean = False
    Public Flocation As Point = Nothing

    Public Event keyDown_deviato(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    Sub New(Optional parente As Object = Nothing)
        init(parente)
    End Sub

    Sub init(Optional par As Object = Nothing)
        parent = par

        formz = New Form With {.ShowInTaskbar = False, .TopMost = True, .ControlBox = False, .Cursor = Cursors.WaitCursor,
                               .Width = 250, .Height = 80, .FormBorderStyle = FormBorderStyle.FixedToolWindow,
                               .StartPosition = FormStartPosition.CenterScreen, .KeyPreview = True}

        lbl = New Label With {.AutoSize = True, .Cursor = Cursors.WaitCursor, .Text = "Loading, please wait", .Parent = formz, _
                                   .Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                                    Or System.Windows.Forms.AnchorStyles.Left) _
                                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles),
                              .BackColor = Color.Transparent}


        prgBar = New ProgressBar With {.Parent = formz, .Size = New Size(formz.Size.Width, 15)}

        prgBar2 = New ProgressBar With {.Parent = formz, .Size = New Size(formz.Size.Width, 15), .Visible = False}

        abortBtn = New Button With {.Parent = formz, .Size = New Size(45, 20), .Location = New Point(formz.Size.Width - 46, 0), .Text = "STOP"}

        AddHandler abortBtn.Click, AddressOf abort
        AddHandler formz.KeyDown, AddressOf deviaKeyDown

        If Not IsNothing(parent) Then
            Flocation = CentraControlloInBounds(formz, parent)
        End If

    End Sub


    'Sub formzLostFocus(sender As Object, e As EventArgs)
    '    If Not esc Then formz.Focus()
    'End Sub
    Sub Wait(ByVal tempo)
        Try
            Dim WC As New Stopwatch

            WC.Reset()
            WC.Start()
            While WC.ElapsedMilliseconds < tempo
                Application.DoEvents()
            End While

        Catch
        End Try
    End Sub
    Sub deviaKeyDown(sender As Object, e As KeyEventArgs)
        Try
            ' esc = True
            RaiseEvent keyDown_deviato(sender, e)
        Catch
        End Try
    End Sub

    Sub abort()
        Try
            ' esc = True
            RaiseEvent keyDown_deviato(Nothing, Nothing)
        Catch
        End Try
    End Sub

    Public Sub show_wait(text As String,
                         Optional ByVal current_value As Integer = -1, Optional ByVal maximum_value As Integer = -1,
                         Optional ByVal current_value2 As Integer = -1, Optional ByVal maximum_value2 As Integer = -1,
                         Optional ByVal abortable As Boolean = False)

        Try
            If Not IsNothing(parent) AndAlso Flocation = Nothing Then
                Flocation = CentraControlloInBounds(formz, parent)
            End If

            lbl.Text = text
            lbl.Location = New Point With {.X = (formz.Size.Width / 2 - lbl.Size.Width / 2), .Y = (formz.Size.Height / 2 - lbl.Size.Height / 2) - prgBar.Height}
            prgBar.Location = New Point With {.X = 0, .Y = formz.Size.Height - prgBar.Size.Height}


            If current_value = -1 Then
                prgBar.Style = ProgressBarStyle.Marquee
            Else
                prgBar.Style = ProgressBarStyle.Continuous
                prgBar.Maximum = maximum_value
                prgBar.Value = current_value
            End If

            If current_value2 = -1 Then
                prgBar2.Visible = False
            Else
                prgBar2.Visible = True
                prgBar2.Location = New Point With {.X = prgBar.Location.X, .Y = prgBar.Location.Y - prgBar.Size.Height}
                prgBar2.Maximum = maximum_value2
                prgBar2.Value = current_value2
            End If

            If abortable Then
                abortBtn.Visible = True
            Else
                abortBtn.Visible = False
            End If


            If formz.IsDisposed OrElse Not formz.IsHandleCreated OrElse Not formz.Visible Then
                init(parent)
            End If


            If Not Flocation = Nothing Then
                formz.Location = Flocation
            Else
                Flocation = New Point(My.Computer.Screen.WorkingArea.Width / 2 - formz.Size.Height / 2, My.Computer.Screen.WorkingArea.Height / 2 - formz.Size.Width / 2)
                formz.Location = Flocation
            End If
            formz.Show()
            Application.DoEvents()

        Catch ex As Exception

        End Try
    End Sub

    Public Sub dispose_wait()
        esc = False
        formz.Hide()
        prgBar2.Visible = False
        'Try
        '    'parent.focus()
        'Catch ex As Exception
        'End Try
    End Sub

    Function CentraControlloInBounds(ctrl As Control, src As Form) As Point
        Dim x, y As Integer
        Dim loc As New Point
        Try

            'If src.Visible = False Then Return loc

            x = src.Location.X + (src.Width - ctrl.Width) / 2
            y = src.Location.Y + (src.Height - ctrl.Height) / 2
            loc = New Point(x, y)

            ctrl.Location = loc
        Catch ex As Exception

        End Try
        Return loc
    End Function
End Class


Public Class Assegnatore_TAG_GR
    Dim FRi As Integer = 0  'form
    Dim TXi As Integer = 0  'textbox
    Dim LBi As Integer = 0  'label
    Dim BTi As Integer = 0  'button
    Dim LTi As Integer = 0  'list box
    Dim COi As Integer = 0  'combobox
    Dim RBi As Integer = 0  'radio buttonm
    Dim CHi As Integer = 0  'checkbox
    Dim PIi As Integer = 0  'picturebox
    'Dim LVi As Integer = 0  'list view
    Dim GDi As Integer = 0  'datagrudview
    Dim GRi As Integer = 0  'group box
    Dim TVi As Integer = 0  'TreeView
    Dim NUD_UDBtns As Integer = 0 'NumericUpDownButtons


    Public Sub assign_TAGs(source As Control, siglaForm As String)
        FRi = 0
        TXi = 0
        LBi = 0
        BTi = 0
        LTi = 0
        COi = 0
        RBi = 0
        CHi = 0
        PIi = 0
        GDi = 0
        'LVi = 0
        GRi = 0
        TVi = 0
        NUD_UDBtns = 0

        Go_Deep_Assign_TAGs(source, siglaForm)

    End Sub

    Private Sub Go_Deep_Assign_TAGs(source As Control, siglaForm As String)
        Select Case source.GetType.ToString
            Case "System.Windows.Forms.Form"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    FRi += 1
                    Exit Select
                End If
                source.Tag = "FR" & siglaForm & FRi
                FRi += 1
                Exit Select
            Case "System.Windows.Forms.TextBox"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    TXi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "TX" & siglaForm & TXi
                TXi += 1
                Exit Select
            Case "System.Windows.Forms.Label"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    LBi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "LB" & siglaForm & LBi
                LBi += 1
                Exit Select
            Case "System.Windows.Forms.Button"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    BTi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "BT" & siglaForm & BTi
                BTi += 1
                Exit Select
            Case "System.Windows.Forms.ListBox"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    LTi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "LTI" & siglaForm & LTi
                LTi += 1
                Exit Select
            Case "System.Windows.Forms.ComboBox"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    COi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "CO" & siglaForm & COi
                COi += 1
                Exit Select
            Case "System.Windows.Forms.RadioButton"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    RBi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "RB" & siglaForm & RBi
                RBi += 1
                Exit Select
            Case "System.Windows.Forms.CheckBox"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    CHi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "CH" & siglaForm & CHi
                CHi += 1
                Exit Select
            Case "System.Windows.Forms.PictureBox"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    PIi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "PI" & siglaForm & PIi
                PIi += 1
                Exit Select
                'Case "System.Windows.Forms.ListView"
                '    If Not (source.Tag = Nothing Or source.Tag = "") Then
                '        LVi += 1
                '        Exit Select
                '    ElseIf source.Text = Nothing Or source.Text = " " Then
                '        source.Tag = "DONTLOAD"
                '        Exit Select
                '    End If
                '    source.Tag = "LV" & siglaForm & LVi
                '    LVi += 1
                '    Exit Select
            Case "System.Windows.Forms.GroupBox"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    GRi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "GR" & siglaForm & GRi
                GRi += 1
                Exit Select
            Case "System.Windows.Forms.DataGridView"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    GDi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "GD" & siglaForm & GDi
                GDi += 1
                Exit Select
            Case "System.Windows.Forms.TreeView"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    TVi += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "LV" & siglaForm & TVi
                TVi += 1
                Exit Select

            Case "System.Windows.Forms.TreeView"
                If Not (source.Tag = Nothing Or source.Tag = "") Then
                    NUD_UDBtns += 1
                    Exit Select
                ElseIf source.Text = Nothing Or source.Text = " " Then
                    source.Tag = "DONTLOAD"
                    Exit Select
                End If
                source.Tag = "NUD" & siglaForm & NUD_UDBtns
                NUD_UDBtns += 1
                Exit Select


                'MessageBox.ShowDialog(source.GetType.ToString & vbCrLf & "controllo non gestito")
        End Select
        For Each child In source.Controls
            Go_Deep_Assign_TAGs(child, siglaForm)
        Next
    End Sub


End Class