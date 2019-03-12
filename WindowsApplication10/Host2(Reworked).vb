Imports System.Net.Sockets
Imports System.IO
Imports System.Net


Public Class Host2_Reworked_

    Private server As TcpListener
    Private client As New TcpClient
    Private ipendpoint As IPEndPoint = New IPEndPoint(IPAddress.Any, 8888) ' eingestellt ist port 8000. dieser muss ggf. freigegeben sein!
    Private list As New List(Of Connection)

    Private Structure Connection
        Dim stream As NetworkStream
        Dim streamw As StreamWriter
        Dim streamr As StreamReader
        'Dim nick As String ' natürlich optional, aber für die identifikation des clients empfehlenswert.
    End Structure


    Private Sub SendToAllClients(ByVal s As String)
        For Each c As Connection In list ' an alle clients weitersenden.
            Try
                c.streamw.WriteLine(s)
                c.streamw.Flush()
            Catch
            End Try
        Next
    End Sub



    Private Sub ListenToConnection(ByVal con As Connection)
        Do
            Try
                Dim tmp As String = con.streamr.ReadLine ' warten, bis etwas empfangen wird...
                TextBox1.Text = TextBox1.Text + tmp + vbCrLf 'con.nick & ": " & 
                SendToAllClients(tmp) ' an alle clients weitersenden. 'con.nick & ": " & 
            Catch ' die aktuelle überwachte verbindung hat sich wohl verabschiedet.
                list.Remove(con)
                TextBox1.Text = TextBox1.Text + "Client has exit." + vbCrLf 'con.nick & 
                Exit Do
            End Try
        Loop
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = TextBox1.Text + "Der Server läuft!" + vbCrLf
        MsgBox("xd1")
        server = New TcpListener(ipendpoint)
        MsgBox("xd2")
        server.Start()
        MsgBox("xd3")

        While True ' wir warten auf eine neue verbindung...
            client = server.AcceptTcpClient
            Dim c As New Connection ' und erstellen für die neue verbindung eine neue connection...
            c.stream = client.GetStream
            c.streamr = New StreamReader(c.stream)
            c.streamw = New StreamWriter(c.stream)
            'c.nick = c.streamr.ReadLine ' falls das mit dem nick nicht gewünscht, auch diese zeile entfernen.
            list.Add(c) ' und fügen sie der liste der clients hinzu.
            'Console.WriteLine(c.nick & " has joined.")
            ' falls alle anderen das auch lesen sollen können, an alle clients weiterleiten. siehe SendToAllClients

            Dim t As New Threading.Thread(AddressOf ListenToConnection)
            t.Start(c)
        End While
    End Sub
End Class