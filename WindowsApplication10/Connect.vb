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
        If Not TextBox4.Text = "" Then

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


            'HIER Geht es bald Weiter ....

        Else
            MsgBox("Gib dienen Namen in das Spielernamensfeld ein !!!")


        End If


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

    Public Connected As Boolean = False


    Public NAM1 As String
    Public NAM2 As String
    Public NAM3 As String
    Public NAM4 As String
    Public NAM5 As String
    Public NAM6 As String
    Public NAM7 As String
    Public NAM8 As String
    Public NAM9 As String
    Public NAM10 As String

    Private Sub AddItem(ByVal s As String)


        'Connect Antwort des Servers
        Dim Antwort() As String = s.Split(":")
        If Antwort(0) = "CONA" Then

            If Antwort(1) = "P" + NumericUpDown1.Text Then

                If Antwort(2) = "A" Then

                    Connected = True

                    Dim Namex As String
                    Namex = "NAM:P" + NumericUpDown1.Text + ":" + TextBox4.Text
                    streamw.Write(Namex + vbCrLf)
                    streamw.Flush()


                    Game.Show()
                    Me.Hide()
                End If
                If Antwort(2) = "F1" Then
                    MsgBox("Spieler " + NumericUpDown1.Text + " Ist bereits im Spiel")
                End If
                If Antwort(2) = "F2" Then
                    MsgBox("Nehme Eine niedrigere Spieler Nummer")
                End If
            End If
        End If

        'Namens Änderung
        'Name
        Dim Name() As String = s.Split(":")
        If Name(0) = "NAM" Then
            If Name(1) = "P2" Then
                Hauptmenü.NAM2 = Name(2)
            End If
            If Name(1) = "P3" Then
                Hauptmenü.NAM3 = Name(2)
            End If
            If Name(1) = "P4" Then
                Hauptmenü.NAM4 = Name(2)
            End If
            If Name(1) = "P5" Then
                Hauptmenü.NAM5 = Name(2)
            End If
            If Name(1) = "P6" Then
                Hauptmenü.NAM6 = Name(2)
            End If
            If Name(1) = "P7" Then
                Hauptmenü.NAM7 = Name(2)
            End If
            If Name(1) = "P8" Then
                Hauptmenü.NAM8 = Name(2)
            End If
            If Name(1) = "P9" Then
                Hauptmenü.NAM9 = Name(2)
            End If
            If Name(1) = "P10" Then
                Hauptmenü.NAM10 = Name(2)
            End If
        End If

        'Kick 
        Dim Kick() As String = s.Split(":")
        If Kick(0) = "KICK" Then
            If Kick(1) = "P" + NumericUpDown1.Text Then
                MsgBox("Du wurdest vom Host des Spieles Aus dem Spiel entfernt ...")
                MsgBox("Das Programm wird sich nun terminieren")
                Me.Close()

            End If
        End If








    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Host_Client.Show()
        Me.Close()
    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Environment.Exit(Environment.ExitCode)
    End Sub


End Class