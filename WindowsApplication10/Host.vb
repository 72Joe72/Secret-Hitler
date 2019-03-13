Imports System.Net.Sockets
Imports System.IO
Imports System.ComponentModel

Public Class Host

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Server Starten Button

        Panel1.Visible = False
        Panel2.Visible = True


        Try
            My.Computer.FileSystem.WriteAllBytes(My.Computer.FileSystem.SpecialDirectories.Temp & "\Server_P8888Hidden.exe", My.Resources.Server_P8888Hidden, False)
            Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp & "\Server_P8888Hidden.exe")
        Catch ex As Exception
            MsgBox("Es Läuft Bereits Eine Anwendung mit Port 8888")
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
            MsgBox("Verbindung zu Server Unterbrochenb")
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
        MsgBox("Noch Nicht In betrieb xd")
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


    Public SpielerAnzahlStatus As Integer
    '1 = 5-6
    '2 = 7-8
    '3 = 9-10

    Public CONP2 As Boolean
    Public CONP3 As Boolean
    Public CONP4 As Boolean
    Public CONP5 As Boolean
    Public CONP6 As Boolean
    Public CONP7 As Boolean
    Public CONP8 As Boolean
    Public CONP9 As Boolean
    Public CONP10 As Boolean
    'Überprüfung ob Der Spieler Bereits existiert oder nicht







    Private Sub AddItem(ByVal s As String)
        'Dim Empfangen() As String = s.Split("0")

        'Connect
        Try
            Dim Connect() As String = s.Split(":")

            If Connect(0) = "CON" Then

                If Connect(1) = "P2" Then
                    If CONP2 = False Then
                        CONP2 = True
                        'Den Aktuellen SaveStateSenden WIP 
                        streamw.Write("CONA:P2:A" + vbCrLf)
                        streamw.Flush()
                    Else
                        'Schicke Fehlermeldung das Spieler 2 Bereits vergeben ist
                        streamw.Write("CONA:P2:F1" + vbCrLf)
                        streamw.Flush()
                    End If
                End If


                If Connect(1) = "P3" Then
                    If CONP3 = False Then
                        CONP3 = True
                        'Den Aktuellen SaveStateSenden WIP 
                        streamw.Write("CONA:P3:A" + vbCrLf)
                        streamw.Flush()
                    Else
                        'Schicke Fehlermeldung das Spieler 3 Bereits vergeben ist
                        streamw.Write("CONA:P3:F1" + vbCrLf)
                        streamw.Flush()
                    End If
                End If
                If Connect(1) = "P4" Then
                    If CONP4 = False Then
                        CONP4 = True
                        'Den Aktuellen SaveStateSenden WIP 
                        streamw.Write("CONA:P4:A" + vbCrLf)
                        streamw.Flush()
                    Else
                        'Schicke Fehlermeldung das Spieler 4 Bereits vergeben ist
                        streamw.Write("CONA:P4:F1" + vbCrLf)
                        streamw.Flush()
                    End If
                End If
                If Connect(1) = "P5" Then
                    If CONP5 = False Then
                        CONP5 = True
                        'Den Aktuellen SaveStateSenden WIP 
                        streamw.Write("CONA:P5:A" + vbCrLf)
                        streamw.Flush()
                    Else
                        'Schicke Fehlermeldung das Spieler 5 Bereits vergeben ist
                        streamw.Write("CONA:P5:F1" + vbCrLf)
                        streamw.Flush()
                    End If
                End If
                If Connect(1) = "P6" Then
                    If CONP6 = False Then
                        CONP6 = True
                        'Den Aktuellen SaveStateSenden WIP 
                        streamw.Write("CONA:P6:A" + vbCrLf)
                        streamw.Flush()
                    Else
                        'Schicke Fehlermeldung das Spieler 6 Bereits vergeben ist
                        streamw.Write("CONA:P6:F1" + vbCrLf)
                        streamw.Flush()
                    End If
                End If

                If Connect(1) = "P7" Then
                    If SpielerAnzahlStatus >= 2 Then
                        If CONP7 = False Then
                            CONP7 = True
                            'Den Aktuellen SaveStateSenden WIP 
                            streamw.Write("CONA:P7:A" + vbCrLf)
                            streamw.Flush()
                        Else
                            'Schicke Fehlermeldung das Spieler 7 Bereits vergeben ist
                            streamw.Write("CONA:P7:F1" + vbCrLf)
                            streamw.Flush()
                        End If
                    Else
                        'Schicke Fehlermeldung das Spiler 7 Bereits vergeben ist
                        streamw.Write("CONA:P7:F2" + vbCrLf)
                        streamw.Flush()
                    End If
                End If
                If Connect(1) = "P8" Then
                    If SpielerAnzahlStatus >= 2 Then

                    Else
                        'Errormeldung senden
                    End If
                End If

                If Connect(1) = "P9" Then
                    If SpielerAnzahlStatus >= 3 Then

                    Else
                        'Errormeldung senden
                    End If
                End If
                If Connect(1) = "P10" Then
                    If SpielerAnzahlStatus >= 3 Then

                    Else
                        'Errormeldung senden
                    End If
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

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        '5-6 Spieler Button
        Button2.Enabled = False
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        SpielerAnzahlStatus = 1


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        '7-8 Spieler Button
        Button3.Enabled = False
        Button2.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        SpielerAnzahlStatus = 2

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        '9-10 Spieler Button
        Button4.Enabled = False
        Button3.Enabled = True
        Button2.Enabled = True
        Button5.Enabled = True
        SpielerAnzahlStatus = 3

    End Sub







    'Senden Skript
    'streamw.Write("Text" + vbCrLf)
    'streamw.Flush()




End Class