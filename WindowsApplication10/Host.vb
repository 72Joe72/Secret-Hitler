Imports System.Net.Sockets
Imports System.IO
Imports System.ComponentModel

Public Class Host

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function





    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Server Starten Button

        Panel1.Visible = False



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

        Game.Show()
        Hauptmenü.NAM1 = TextBox4.Text


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
    'Ist Client X Verbunden Ja oder Nein


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
    'Name

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
                        'Schicke Fehlermeldung Das das spiel nich für so vile speier vorgesehen ist
                        streamw.Write("CONA:P7:F2" + vbCrLf)
                        streamw.Flush()
                    End If
                End If
                If Connect(1) = "P8" Then
                    If SpielerAnzahlStatus >= 2 Then
                        If CONP8 = False Then
                            CONP8 = True
                            'Den Aktuellen SaveStateSenden WIP 
                            streamw.Write("CONA:P8:A" + vbCrLf)
                            streamw.Flush()
                        Else
                            'Schicke Fehlermeldung das Spieler 8 Bereits vergeben ist
                            streamw.Write("CONA:P8:F1" + vbCrLf)
                            streamw.Flush()
                        End If
                    Else
                        'Schicke Fehlermeldung Das das spiel nich für so vile speier vorgesehen ist
                        streamw.Write("CONA:P8:F2" + vbCrLf)
                        streamw.Flush()
                    End If
                End If

                If Connect(1) = "P9" Then
                    If SpielerAnzahlStatus >= 2 Then
                        If CONP9 = False Then
                            CONP9 = True
                            'Den Aktuellen SaveStateSenden WIP 
                            streamw.Write("CONA:P9:A" + vbCrLf)
                            streamw.Flush()
                        Else
                            'Schicke Fehlermeldung das Spieler 9 Bereits vergeben ist
                            streamw.Write("CONA:P9:F1" + vbCrLf)
                            streamw.Flush()
                        End If
                    Else
                        'Schicke Fehlermeldung Das das spiel nich für so vile speier vorgesehen ist
                        streamw.Write("CONA:P9:F2" + vbCrLf)
                        streamw.Flush()
                    End If
                End If
                If Connect(1) = "P10" Then
                    If SpielerAnzahlStatus >= 2 Then
                        If CONP10 = False Then
                            CONP10 = True
                            'Den Aktuellen SaveStateSenden WIP 
                            streamw.Write("CONA:P10:A" + vbCrLf)
                            streamw.Flush()
                        Else
                            'Schicke Fehlermeldung das Spieler 8 Bereits vergeben ist
                            streamw.Write("CONA:P10:F1" + vbCrLf)
                            streamw.Flush()
                        End If
                    Else
                        'Schicke Fehlermeldung Das das spiel nich für so vile speier vorgesehen ist
                        streamw.Write("CONA:P10:F2" + vbCrLf)
                        streamw.Flush()
                    End If
                End If



            End If
        Catch ex As Exception
        End Try

        'Name
        Try
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

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label1.Text = "1. " + Hauptmenü.NAM1
        Label3.Text = "2. " + Hauptmenü.NAM2
        Label4.Text = "3. " + Hauptmenü.NAM3
        Label5.Text = "4. " + Hauptmenü.NAM4
        Label6.Text = "5. " + Hauptmenü.NAM5
        Label7.Text = "6. " + Hauptmenü.NAM6
        Label9.Text = "7. " + Hauptmenü.NAM7
        Label10.Text = "8. " + Hauptmenü.NAM8
        Label11.Text = "9. " + Hauptmenü.NAM9
        Label12.Text = "10. " + Hauptmenü.NAM10



        'Erstellen des Save States
        Dim SN1 As String 'SpielerName
        Dim SN2 As String 'SpielerName
        Dim SN3 As String 'SpielerName
        Dim SN4 As String 'SpielerName
        Dim SN5 As String 'SpielerName
        Dim SN6 As String 'SpielerName
        Dim SN7 As String 'SpielerName
        Dim SN8 As String 'SpielerName
        Dim SN9 As String 'SpielerName
        Dim SN10 As String 'SpielerName
        Dim SS1 As String 'Spieler Status
        Dim SS2 As String 'Spieler Status
        Dim SS3 As String 'Spieler Status
        Dim SS4 As String 'Spieler Status
        Dim SS5 As String 'Spieler Status
        Dim SS6 As String 'Spieler Status
        Dim SS7 As String 'Spieler Status
        Dim SS8 As String 'Spieler Status
        Dim SS9 As String 'Spieler Status
        Dim SS10 As String 'Spieler Status







        SN1 = "SN1:" + Hauptmenü.NAM1 + ":"
        SN2 = "SN2:" + Hauptmenü.NAM2 + ":"
        SN3 = "SN3:" + Hauptmenü.NAM3 + ":"
        SN4 = "SN4:" + Hauptmenü.NAM4 + ":"
        SN5 = "SN5:" + Hauptmenü.NAM5 + ":"
        SN6 = "SN6:" + Hauptmenü.NAM6 + ":"
        SN7 = "SN7:" + Hauptmenü.NAM7 + ":"
        SN8 = "SN8:" + Hauptmenü.NAM8 + ":"
        SN9 = "SN9:" + Hauptmenü.NAM9 + ":"
        SN10 = "SN10:" + Hauptmenü.NAM10 + ":"
        SS1 = "SS1:" + Hauptmenü.SPS1 + ":"
        SS2 = "SS2:" + Hauptmenü.SPS2 + ":"
        SS3 = "SS3:" + Hauptmenü.SPS3 + ":"
        SS4 = "SS4:" + Hauptmenü.SPS4 + ":"
        SS5 = "SS5:" + Hauptmenü.SPS5 + ":"
        SS6 = "SS6:" + Hauptmenü.SPS6 + ":"
        SS7 = "SS7:" + Hauptmenü.SPS7 + ":"
        SS8 = "SS8:" + Hauptmenü.SPS8 + ":"
        SS9 = "SS9:" + Hauptmenü.SPS9 + ":"
        SS10 = "SS20:" + Hauptmenü.SPS10 + ":"

        Hauptmenü.SaveState = "SSB:" + SN1 + SN2 + SN3 + SN4 + SN5 + SN6 + SN7 + SN8 + SN9 + SN10 + SS1 + SS2 + SS3 + SS4 + SS5 + SS6 + SS7 + SS8 + SS9 + SS10



















    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim a As String
        a = MsgBox("Willst du " + Hauptmenü.NAM2 + " Kicken", vbYesNo)
        If a = vbNo Then Exit Sub Else
        streamw.Write("KICK:P2" + vbCrLf)
        streamw.Flush()
        Hauptmenü.NAM2 = ""
        CONP2 = False


    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim a As String
        a = MsgBox("Willst du " + Hauptmenü.NAM3 + " Kicken", vbYesNo)
        If a = vbNo Then Exit Sub Else
        streamw.Write("KICK:P3" + vbCrLf)
        streamw.Flush()
        Hauptmenü.NAM3 = ""
        CONP2 = False

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim a As String
        a = MsgBox("Willst du " + Hauptmenü.NAM4 + " Kicken", vbYesNo)
        If a = vbNo Then Exit Sub Else
        streamw.Write("KICK:P4" + vbCrLf)
        streamw.Flush()
        Hauptmenü.NAM4 = ""
        CONP4 = False
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim a As String
        a = MsgBox("Willst du " + Hauptmenü.NAM5 + " Kicken", vbYesNo)
        If a = vbNo Then Exit Sub Else
        streamw.Write("KICK:P5" + vbCrLf)
        streamw.Flush()
        Hauptmenü.NAM5 = ""
        CONP5 = False
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim a As String
        a = MsgBox("Willst du " + Hauptmenü.NAM6 + " Kicken", vbYesNo)
        If a = vbNo Then Exit Sub Else
        streamw.Write("KICK:P6" + vbCrLf)
        streamw.Flush()
        Hauptmenü.NAM6 = ""
        CONP6 = False
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim a As String
        a = MsgBox("Willst du " + Hauptmenü.NAM7 + " Kicken", vbYesNo)
        If a = vbNo Then Exit Sub Else
        streamw.Write("KICK:P7" + vbCrLf)
        streamw.Flush()
        Hauptmenü.NAM7 = ""
        CONP7 = False
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim a As String
        a = MsgBox("Willst du " + Hauptmenü.NAM8 + " Kicken", vbYesNo)
        If a = vbNo Then Exit Sub Else
        streamw.Write("KICK:P8" + vbCrLf)
        streamw.Flush()
        Hauptmenü.NAM8 = ""
        CONP8 = False
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim a As String
        a = MsgBox("Willst du " + Hauptmenü.NAM9 + " Kicken", vbYesNo)
        If a = vbNo Then Exit Sub Else
        streamw.Write("KICK:P9" + vbCrLf)
        streamw.Flush()
        Hauptmenü.NAM9 = ""
        CONP9 = False
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim a As String
        a = MsgBox("Willst du " + Hauptmenü.NAM10 + " Kicken", vbYesNo)
        If a = vbNo Then Exit Sub Else
        streamw.Write("KICK:P10" + vbCrLf)
        streamw.Flush()
        Hauptmenü.NAM10 = ""
        CONP10 = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        MsgBox(Hauptmenü.SaveState)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click


        Dim AError As Integer = 1
        Dim BError As Boolean = True

        Dim a As String
        a = MsgBox("Wenn du das Spiel Jetzt startest kann keine Weitere Person hinzugefügt werden!!" + vbCrLf + "Willst du das Spiel Starten ?", vbYesNo)
        If a = vbNo Then Exit Sub Else
        MsgBox("WIP")

        If CONP2 = True Then
            AError = AError + 1
        End If
        If CONP3 = True Then
            AError = AError + 1
        End If
        If CONP4 = True Then
            AError = AError + 1
        End If
        If CONP5 = True Then
            AError = AError + 1
        End If
        If CONP6 = True Then
            AError = AError + 1
        End If
        If CONP7 = True Then
            AError = AError + 1
        End If
        If CONP8 = True Then
            AError = AError + 1
        End If
        If CONP9 = True Then
            AError = AError + 1
        End If
        If CONP10 = True Then
            AError = AError + 1
        End If

        If SpielerAnzahlStatus = 1 Then
            If Not AError >= 5 Then
                BError = False
            End If
        End If
        If SpielerAnzahlStatus = 2 Then
            If Not AError >= 7 Then
                BError = False
            End If
        End If
        If SpielerAnzahlStatus = 3 Then
            If Not AError >= 9 Then
                BError = False
            End If
        End If

        MsgBox(AError)
        MsgBox(BError)


        'Ab hier wirds cancer



        If BError = True Then


            Dim SS1 As Integer = GetRandom(1, AError + 1)
            Dim SS2 As Integer = 0
            Dim SS3 As Integer = 0
            Dim SS4 As Integer = 0
            Dim SS5 As Integer = 0
            Dim SS6 As Integer = 0
            Dim SS7 As Integer = 0
            Dim SS8 As Integer = 0
            Dim SS9 As Integer = 0
            Dim SS10 As Integer = 0




            While True
                SS2 = GetRandom(1, AError + 1)
                If Not SS1 = SS2 Then
                    Exit While
                End If
            End While
            While True
                'If Not SS1 Or SS2 = SS3 Then
                'Exit While
                'End If
                SS3 = GetRandom(1, AError + 1)
                If Not SS1 = SS3 Then
                    If Not SS2 = SS3 Then
                        Exit While
                    End If
                End If
            End While

            While True
                SS4 = GetRandom(1, AError + 1)
                If Not SS1 = SS4 Then
                    If Not SS2 = SS4 Then
                        If Not SS3 = SS4 Then
                            Exit While
                        End If
                    End If
                End If
            End While

            While True
                SS5 = GetRandom(1, AError + 1)
                If Not SS1 = SS5 Then
                    If Not SS2 = SS5 Then
                        If Not SS3 = SS5 Then
                            If Not SS4 = SS5 Then
                                Exit While
                            End If
                        End If
                    End If
                End If
            End While

            If AError >= 6 Then
                While True
                    SS6 = GetRandom(1, AError + 1)
                    If Not SS1 = SS6 Then
                        If Not SS2 = SS6 Then
                            If Not SS3 = SS6 Then
                                If Not SS4 = SS6 Then
                                    If Not SS5 = SS6 Then
                                        Exit While
                                    End If
                                End If
                            End If
                        End If
                    End If
                End While

            End If
            If AError >= 7 Then
                While True
                    SS7 = GetRandom(1, AError + 1)
                    If Not SS1 = SS7 Then
                        If Not SS2 = SS7 Then
                            If Not SS3 = SS7 Then
                                If Not SS4 = SS7 Then
                                    If Not SS5 = SS7 Then
                                        If Not SS6 = SS7 Then
                                            Exit While
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End While
            End If
            If AError >= 8 Then
                While True
                    SS8 = GetRandom(1, AError + 1)
                    If Not SS1 = SS8 Then
                        If Not SS2 = SS8 Then
                            If Not SS3 = SS8 Then
                                If Not SS4 = SS8 Then
                                    If Not SS5 = SS8 Then
                                        If Not SS6 = SS8 Then
                                            If Not SS7 = SS8 Then
                                                Exit While
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End While
            End If
            If AError >= 9 Then
                While True
                    SS9 = GetRandom(1, AError + 1)
                    If Not SS1 = SS9 Then
                        If Not SS2 = SS9 Then
                            If Not SS3 = SS9 Then
                                If Not SS4 = SS9 Then
                                    If Not SS5 = SS9 Then
                                        If Not SS6 = SS9 Then
                                            If Not SS7 = SS9 Then
                                                If Not SS8 = SS9 Then
                                                    Exit While
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End While
            End If
            If AError >= 10 Then
                While True
                    SS10 = GetRandom(1, AError + 1)
                    If Not SS1 = SS10 Then
                        If Not SS2 = SS10 Then
                            If Not SS3 = SS10 Then
                                If Not SS4 = SS10 Then
                                    If Not SS5 = SS10 Then
                                        If Not SS6 = SS10 Then
                                            If Not SS7 = SS10 Then
                                                If Not SS8 = SS10 Then
                                                    If Not SS9 = SS10 Then
                                                        Exit While
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End While
            End If

            MsgBox(SS1.ToString + vbCrLf + SS2.ToString + vbCrLf + SS3.ToString + vbCrLf + SS4.ToString + vbCrLf + SS5.ToString + vbCrLf + SS6.ToString + vbCrLf + SS7.ToString + vbCrLf + SS8.ToString + vbCrLf + SS9.ToString + vbCrLf + SS10.ToString + vbCrLf)

            'Rollen Verteilung

            If AError = 5 Then
                If SS1 = 1 Then
                    Hauptmenü.SPS1 = 1
                End If
                If SS1 = 2 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 3 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 4 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 5 Then
                    Hauptmenü.SPS1 = 3
                End If

                If SS2 = 1 Then
                    Hauptmenü.SPS2 = 1
                End If
                If SS2 = 2 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 3 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 4 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 5 Then
                    Hauptmenü.SPS2 = 3
                End If

                If SS3 = 1 Then
                    Hauptmenü.SPS3 = 1
                End If
                If SS3 = 2 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 3 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 4 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 5 Then
                    Hauptmenü.SPS3 = 3
                End If

                If SS4 = 1 Then
                    Hauptmenü.SPS4 = 1
                End If
                If SS4 = 2 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 3 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 4 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 5 Then
                    Hauptmenü.SPS4 = 3
                End If

                If SS5 = 1 Then
                    Hauptmenü.SPS5 = 1
                End If
                If SS5 = 2 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 3 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 4 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 5 Then
                    Hauptmenü.SPS5 = 3
                End If


            End If

            If AError = 6 Then
                If SS1 = 1 Then
                    Hauptmenü.SPS1 = 1
                End If
                If SS1 = 2 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 3 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 4 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 5 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 6 Then
                    Hauptmenü.SPS1 = 3
                End If

                If SS2 = 1 Then
                    Hauptmenü.SPS2 = 1
                End If
                If SS2 = 2 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 3 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 4 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 5 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 6 Then
                    Hauptmenü.SPS2 = 3
                End If

                If SS3 = 1 Then
                    Hauptmenü.SPS3 = 1
                End If
                If SS3 = 2 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 3 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 4 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 5 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 6 Then
                    Hauptmenü.SPS3 = 3
                End If

                If SS4 = 1 Then
                    Hauptmenü.SPS4 = 1
                End If
                If SS4 = 2 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 3 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 4 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 5 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 6 Then
                    Hauptmenü.SPS4 = 3
                End If

                If SS5 = 1 Then
                    Hauptmenü.SPS5 = 1
                End If
                If SS5 = 2 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 3 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 4 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 5 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 6 Then
                    Hauptmenü.SPS5 = 3
                End If

                If SS6 = 1 Then
                    Hauptmenü.SPS6 = 1
                End If
                If SS6 = 2 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 3 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 4 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 5 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 6 Then
                    Hauptmenü.SPS6 = 3
                End If


            End If

            If AError = 7 Then
                If SS1 = 1 Then
                    Hauptmenü.SPS1 = 1
                End If
                If SS1 = 2 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 3 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 4 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 5 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 6 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 7 Then
                    Hauptmenü.SPS1 = 3
                End If

                If SS2 = 1 Then
                    Hauptmenü.SPS2 = 1
                End If
                If SS2 = 2 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 3 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 4 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 5 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 6 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 7 Then
                    Hauptmenü.SPS2 = 3
                End If

                If SS3 = 1 Then
                    Hauptmenü.SPS3 = 1
                End If
                If SS3 = 2 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 3 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 4 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 5 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 6 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 7 Then
                    Hauptmenü.SPS3 = 3
                End If

                If SS4 = 1 Then
                    Hauptmenü.SPS4 = 1
                End If
                If SS4 = 2 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 3 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 4 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 5 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 6 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 7 Then
                    Hauptmenü.SPS4 = 3
                End If

                If SS5 = 1 Then
                    Hauptmenü.SPS5 = 1
                End If
                If SS5 = 2 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 3 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 4 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 5 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 6 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 7 Then
                    Hauptmenü.SPS5 = 3
                End If

                If SS6 = 1 Then
                    Hauptmenü.SPS6 = 1
                End If
                If SS6 = 2 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 3 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 4 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 5 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 6 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 7 Then
                    Hauptmenü.SPS6 = 3
                End If

                If SS7 = 1 Then
                    Hauptmenü.SPS7 = 1
                End If
                If SS7 = 2 Then
                    Hauptmenü.SPS7 = 2
                End If
                If SS7 = 3 Then
                    Hauptmenü.SPS7 = 2
                End If
                If SS7 = 4 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 5 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 6 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 7 Then
                    Hauptmenü.SPS7 = 3
                End If


            End If

            If AError = 8 Then
                If SS1 = 1 Then
                    Hauptmenü.SPS1 = 1
                End If
                If SS1 = 2 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 3 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 4 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 5 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 6 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 7 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 8 Then
                    Hauptmenü.SPS1 = 3
                End If

                If SS2 = 1 Then
                    Hauptmenü.SPS2 = 1
                End If
                If SS2 = 2 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 3 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 4 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 5 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 6 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 7 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 8 Then
                    Hauptmenü.SPS2 = 3
                End If

                If SS3 = 1 Then
                    Hauptmenü.SPS3 = 1
                End If
                If SS3 = 2 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 3 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 4 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 5 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 6 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 7 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 8 Then
                    Hauptmenü.SPS3 = 3
                End If


                If SS4 = 1 Then
                    Hauptmenü.SPS4 = 1
                End If
                If SS4 = 2 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 3 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 4 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 5 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 6 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 7 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 8 Then
                    Hauptmenü.SPS4 = 3
                End If


                If SS5 = 1 Then
                    Hauptmenü.SPS5 = 1
                End If
                If SS5 = 2 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 3 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 4 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 5 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 6 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 7 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 8 Then
                    Hauptmenü.SPS5 = 3
                End If


                If SS6 = 1 Then
                    Hauptmenü.SPS6 = 1
                End If
                If SS6 = 2 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 3 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 4 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 5 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 6 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 7 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 8 Then
                    Hauptmenü.SPS6 = 3
                End If


                If SS7 = 1 Then
                    Hauptmenü.SPS7 = 1
                End If
                If SS7 = 2 Then
                    Hauptmenü.SPS7 = 2
                End If
                If SS7 = 3 Then
                    Hauptmenü.SPS7 = 2
                End If
                If SS7 = 4 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 5 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 6 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 7 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 8 Then
                    Hauptmenü.SPS7 = 3
                End If


                If SS8 = 1 Then
                    Hauptmenü.SPS8 = 1
                End If
                If SS8 = 2 Then
                    Hauptmenü.SPS8 = 2
                End If
                If SS8 = 3 Then
                    Hauptmenü.SPS8 = 2
                End If
                If SS8 = 4 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 5 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 6 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 7 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 8 Then
                    Hauptmenü.SPS8 = 3
                End If
            End If

            If AError = 9 Then
                If SS1 = 1 Then
                    Hauptmenü.SPS1 = 1
                End If
                If SS1 = 2 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 3 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 4 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 5 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 6 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 7 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 8 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 9 Then
                    Hauptmenü.SPS1 = 3
                End If


                If SS2 = 1 Then
                    Hauptmenü.SPS2 = 1
                End If
                If SS2 = 2 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 3 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 4 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 5 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 6 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 7 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 8 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 9 Then
                    Hauptmenü.SPS2 = 3
                End If


                If SS3 = 1 Then
                    Hauptmenü.SPS3 = 1
                End If
                If SS3 = 2 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 3 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 4 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 5 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 6 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 7 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 8 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 9 Then
                    Hauptmenü.SPS3 = 3
                End If


                If SS4 = 1 Then
                    Hauptmenü.SPS4 = 1
                End If
                If SS4 = 2 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 3 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 4 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 5 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 6 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 7 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 8 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 9 Then
                    Hauptmenü.SPS4 = 3
                End If


                If SS5 = 1 Then
                    Hauptmenü.SPS5 = 1
                End If
                If SS5 = 2 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 3 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 4 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 5 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 6 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 7 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 8 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 9 Then
                    Hauptmenü.SPS5 = 3
                End If


                If SS6 = 1 Then
                    Hauptmenü.SPS6 = 1
                End If
                If SS6 = 2 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 3 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 4 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 5 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 6 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 7 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 8 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 9 Then
                    Hauptmenü.SPS6 = 3
                End If

                If SS7 = 1 Then
                    Hauptmenü.SPS7 = 1
                End If
                If SS7 = 2 Then
                    Hauptmenü.SPS7 = 2
                End If
                If SS7 = 3 Then
                    Hauptmenü.SPS7 = 2
                End If
                If SS7 = 4 Then
                    Hauptmenü.SPS7 = 2
                End If
                If SS7 = 5 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 6 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 7 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 8 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 9 Then
                    Hauptmenü.SPS7 = 3
                End If


                If SS8 = 1 Then
                    Hauptmenü.SPS8 = 1
                End If
                If SS8 = 2 Then
                    Hauptmenü.SPS8 = 2
                End If
                If SS8 = 3 Then
                    Hauptmenü.SPS8 = 2
                End If
                If SS8 = 4 Then
                    Hauptmenü.SPS8 = 2
                End If
                If SS8 = 5 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 6 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 7 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 8 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 9 Then
                    Hauptmenü.SPS8 = 3
                End If


                If SS9 = 1 Then
                    Hauptmenü.SPS9 = 1
                End If
                If SS9 = 2 Then
                    Hauptmenü.SPS9 = 2
                End If
                If SS9 = 3 Then
                    Hauptmenü.SPS9 = 2
                End If
                If SS9 = 4 Then
                    Hauptmenü.SPS9 = 2
                End If
                If SS9 = 5 Then
                    Hauptmenü.SPS9 = 3
                End If
                If SS9 = 6 Then
                    Hauptmenü.SPS9 = 3
                End If
                If SS9 = 7 Then
                    Hauptmenü.SPS9 = 3
                End If
                If SS9 = 8 Then
                    Hauptmenü.SPS9 = 3
                End If
                If SS9 = 9 Then
                    Hauptmenü.SPS9 = 3
                End If
            End If

            If AError = 10 Then
                If SS1 = 1 Then
                    Hauptmenü.SPS1 = 1
                End If
                If SS1 = 2 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 3 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 4 Then
                    Hauptmenü.SPS1 = 2
                End If
                If SS1 = 5 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 6 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 7 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 8 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 9 Then
                    Hauptmenü.SPS1 = 3
                End If
                If SS1 = 10 Then
                    Hauptmenü.SPS1 = 3
                End If

                If SS2 = 1 Then
                    Hauptmenü.SPS2 = 1
                End If
                If SS2 = 2 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 3 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 4 Then
                    Hauptmenü.SPS2 = 2
                End If
                If SS2 = 5 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 6 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 7 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 8 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 9 Then
                    Hauptmenü.SPS2 = 3
                End If
                If SS2 = 10 Then
                    Hauptmenü.SPS2 = 3
                End If

                If SS3 = 1 Then
                    Hauptmenü.SPS3 = 1
                End If
                If SS3 = 2 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 3 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 4 Then
                    Hauptmenü.SPS3 = 2
                End If
                If SS3 = 5 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 6 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 7 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 8 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 9 Then
                    Hauptmenü.SPS3 = 3
                End If
                If SS3 = 10 Then
                    Hauptmenü.SPS3 = 3
                End If

                If SS4 = 1 Then
                    Hauptmenü.SPS4 = 1
                End If
                If SS4 = 2 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 3 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 4 Then
                    Hauptmenü.SPS4 = 2
                End If
                If SS4 = 5 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 6 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 7 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 8 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 9 Then
                    Hauptmenü.SPS4 = 3
                End If
                If SS4 = 10 Then
                    Hauptmenü.SPS4 = 3
                End If

                If SS5 = 1 Then
                    Hauptmenü.SPS5 = 1
                End If
                If SS5 = 2 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 3 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 4 Then
                    Hauptmenü.SPS5 = 2
                End If
                If SS5 = 5 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 6 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 7 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 8 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 9 Then
                    Hauptmenü.SPS5 = 3
                End If
                If SS5 = 10 Then
                    Hauptmenü.SPS5 = 3
                End If

                If SS6 = 1 Then
                    Hauptmenü.SPS6 = 1
                End If
                If SS6 = 2 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 3 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 4 Then
                    Hauptmenü.SPS6 = 2
                End If
                If SS6 = 5 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 6 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 7 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 8 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 9 Then
                    Hauptmenü.SPS6 = 3
                End If
                If SS6 = 10 Then
                    Hauptmenü.SPS6 = 3
                End If

                If SS7 = 1 Then
                    Hauptmenü.SPS7 = 1
                End If
                If SS7 = 2 Then
                    Hauptmenü.SPS7 = 2
                End If
                If SS7 = 3 Then
                    Hauptmenü.SPS7 = 2
                End If
                If SS7 = 4 Then
                    Hauptmenü.SPS7 = 2
                End If
                If SS7 = 5 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 6 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 7 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 8 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 9 Then
                    Hauptmenü.SPS7 = 3
                End If
                If SS7 = 10 Then
                    Hauptmenü.SPS7 = 3
                End If

                If SS8 = 1 Then
                    Hauptmenü.SPS8 = 1
                End If
                If SS8 = 2 Then
                    Hauptmenü.SPS8 = 2
                End If
                If SS8 = 3 Then
                    Hauptmenü.SPS8 = 2
                End If
                If SS8 = 4 Then
                    Hauptmenü.SPS8 = 2
                End If
                If SS8 = 5 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 6 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 7 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 8 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 9 Then
                    Hauptmenü.SPS8 = 3
                End If
                If SS8 = 10 Then
                    Hauptmenü.SPS8 = 3
                End If

                If SS9 = 1 Then
                    Hauptmenü.SPS9 = 1
                End If
                If SS9 = 2 Then
                    Hauptmenü.SPS9 = 2
                End If
                If SS9 = 3 Then
                    Hauptmenü.SPS9 = 2
                End If
                If SS9 = 4 Then
                    Hauptmenü.SPS9 = 2
                End If
                If SS9 = 5 Then
                    Hauptmenü.SPS9 = 3
                End If
                If SS9 = 6 Then
                    Hauptmenü.SPS9 = 3
                End If
                If SS9 = 7 Then
                    Hauptmenü.SPS9 = 3
                End If
                If SS9 = 8 Then
                    Hauptmenü.SPS9 = 3
                End If
                If SS9 = 9 Then
                    Hauptmenü.SPS9 = 3
                End If
                If SS9 = 10 Then
                    Hauptmenü.SPS9 = 3
                End If

                If SS10 = 1 Then
                    Hauptmenü.SPS10 = 1
                End If
                If SS10 = 2 Then
                    Hauptmenü.SPS10 = 2
                End If
                If SS10 = 3 Then
                    Hauptmenü.SPS10 = 2
                End If
                If SS10 = 4 Then
                    Hauptmenü.SPS10 = 2
                End If
                If SS10 = 5 Then
                    Hauptmenü.SPS10 = 3
                End If
                If SS10 = 6 Then
                    Hauptmenü.SPS10 = 3
                End If
                If SS10 = 7 Then
                    Hauptmenü.SPS10 = 3
                End If
                If SS10 = 8 Then
                    Hauptmenü.SPS10 = 3
                End If
                If SS10 = 9 Then
                    Hauptmenü.SPS10 = 3
                End If
                If SS10 = 10 Then
                    Hauptmenü.SPS10 = 3
                End If


            End If

        Else
            MsgBox("Es sind Nicht genug spieler Verbunden um das Spiel zu starten !!!")
        End If

    End Sub















    'Senden Skript
    'streamw.Write("Text" + vbCrLf)
    'streamw.Flush()




End Class