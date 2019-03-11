Imports System.Net.Sockets
Imports System.IO



Public Class IPMann

    Dim stream As NetworkStream
    Dim streamw As StreamWriter
    Dim streamr As StreamReader
    Dim client As New TcpClient
    Dim t As New Threading.Thread(AddressOf Listen)

    Sub Listen()
        While client.Connected
            Dim befehl As String = Receive()
            If befehl <> "" Then
                MsgBox(befehl)
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

    End Sub

    Private Sub IPMann_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'test
    End Sub
End Class