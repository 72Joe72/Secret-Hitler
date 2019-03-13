Imports System.Net.Sockets
Imports System.IO
Imports System.ComponentModel

Public Class Host





    Private Sub Host_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            My.Computer.FileSystem.WriteAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp & "\Server_P8888Hidden.exe", My.Resources.Server_P8888Hidden, False)
            Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp & "\Server_P8888Hidden.exe")
        Catch ex As Exception
            MsgBox("Es Läuft Bereits Eine Anwendung Mit Port 8888")
        End Try


        IP = "127.0.0.1"
        Port = 8888

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


        'HIER Geht es bald Weiter ....

    End Sub

    Private stream As NetworkStream
    Private streamw As StreamWriter
    Private streamr As StreamReader
    Private client As New TcpClient
    Public t As New Threading.Thread(AddressOf Listen)
    Private Delegate Sub DAddItem(ByVal s As String)
    Public IP As String
    Public Port As String


    Private Sub Button2_Click(sender As Object, e As EventArgs)

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
        'Dim Empfangen() As String = s.Split("0")

        'Connect


        Try
            Dim Connect() As String = s.Split(":")
            MsgBox(Connect(0) + Connect(1))

            If Connect(0) = "CON" Then
                MsgBox(s)

                MsgBox(Connect(1))

                If Connect(1) = "P2" Then

                End If


            End If
        Catch ex As Exception
        End Try
        'Weiter...













        'RichTextBox1.Text = RichTextBox1.Text + s + vbCrLf
    End Sub



    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Environment.Exit(Environment.ExitCode)
    End Sub

    'Senden Skript
    'streamw.Write("Text" + vbCrLf)
    'streamw.Flush()




End Class