Imports System.Net.Sockets
Imports System.IO





Public Class IPMann

    Public Senden As String = ""
    Public Empfang As String = ""

    Dim stream As NetworkStream
    Dim streamw As StreamWriter
    Dim streamr As StreamReader
    Dim client As New TcpClient
    Dim t As New Threading.Thread(AddressOf Listen)

    Sub Listen()
        While client.Connected
            Dim x As String
            If x <> "" Then
                TextBox4.Text = TextBox1.Text + x + vbCrLf
                x = ""
            End If
        End While
    End Sub

    Sub Send(ByVal stext As String)
        streamw.WriteLine(stext)
        streamw.Flush()
    End Sub
    Function Receive() As String
        Try
            Return streamr.ReadLine
        Catch
            Return ""
        End Try
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Host_Client.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            client.Connect(TextBox1.Text, TextBox2.Text)
            If client.Connected Then
                stream = client.GetStream
                streamw = New StreamWriter(stream)
                streamr = New StreamReader(stream)
                t.Start()
            Else
                MessageBox.Show("Verbindung mit " & TextBox1.Text & " nicht möglich!")
            End If
        Catch
            MessageBox.Show("Verbindung mit " & TextBox1.Text & " nicht möglich!")
        End Try

    End Sub

    Private Sub IPMann_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'test
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim befehl As String = TextBox3.Text
        TextBox3.Clear()
        Send(befehl)
    End Sub
End Class