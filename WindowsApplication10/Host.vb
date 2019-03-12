Imports System.Net.Sockets
Imports System.IO
Imports System.Net


Public Class Host

    Dim stream As NetworkStream
    Dim streamw As StreamWriter
    Dim streamr As StreamReader
    Dim server As TcpListener
    Dim client As New TcpClient
    Dim ipendpoint As IPEndPoint = New IPEndPoint(IPAddress.Any, 8888)
    Dim t As New Threading.Thread(AddressOf Main)



    Sub Main()
        Try
            server = New TcpListener(ipendpoint)
            server.Start()
            client = server.AcceptTcpClient
            stream = client.GetStream
            streamr = New StreamReader(stream)
            streamw = New StreamWriter(stream)
            While True
                Select Case streamr.ReadLine
                    Case "Hallo"
                        MessageBox.Show("Auch hallo!")

                End Select
            End While
        Catch
            MessageBox.Show("Socket-Fehler.")
            Button1.Text = "Start"
        End Try
    End Sub

    Private Sub Host_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            t.Start()
        Catch ex As Exception
            MsgBox("Starten des Servers gerade nicht möglich!")
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class