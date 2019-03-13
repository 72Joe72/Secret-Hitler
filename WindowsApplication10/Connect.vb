Imports System.Net.Sockets
Imports System.IO
Imports System.ComponentModel


Public Class Connect
    Private stream As NetworkStream
    Private streamw As StreamWriter
    Private streamr As StreamReader
    Private client As New TcpClient
    Public t As New Threading.Thread(AddressOf Listen)
    Private Delegate Sub DAddItem(ByVal s As String)
    Public IP As String
    Public Port As String



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        IP = TextBox1.Text
        Port = TextBox2.Text


        Try
            client.Connect(IP, Port) ' hier die ip des servers eintragen. 

            If client.Connected Then
                stream = client.GetStream
                streamw = New StreamWriter(stream)
                streamr = New StreamReader(stream)
                'streamw.WriteLine(nick) ' das ist optional.
                streamw.Flush()
                t.Start()

            End If
        Catch ex As Exception
            MsgBox("Fail")
            Try
                t.Interrupt()
                t.Abort()
            Catch exx As Exception
                MsgBox("KURWA")
            End Try




            Close()

        End Try


        Dim joinM As String
        joinM = "CON:P" + NumericUpDown1.Text
        streamw.Write(joinM + vbCrLf)
        streamw.Flush()
        TextBox3.Clear()

        'HIER Geht es bald Weiter ....
    End Sub

    Private Sub Listen()
        While client.Connected
            Try
                Me.Invoke(New DAddItem(AddressOf AddItem), streamr.ReadLine)
            Catch ex As Exception
                MsgBox("Fail")
                t.Interrupt()
                t.Abort()
                Close()
            End Try
        End While
    End Sub

    Private Sub AddItem(ByVal s As String)


        'Connect Antwort des Servers
        Try
            Dim Antwort() As String = s.Split(":")
            If Antwort(0) = 
                End If


        Catch ex As Exception

        End Try






    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Host_Client.Show()
        Me.Close()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Environment.Exit(Environment.ExitCode)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        streamw.Write(TextBox3.Text + vbCrLf)
        streamw.Flush()
        TextBox3.Clear()
    End Sub
End Class