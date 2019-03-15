
Public Class Hauptmenü
    Public SPS1 As String ' Spieler Status
    Public SPS2 As String
    Public SPS3 As String
    Public SPS4 As String
    Public SPS5 As String
    Public SPS6 As String
    Public SPS7 As String
    Public SPS8 As String
    Public SPS9 As String
    Public SPS10 As String
    Public NAM1 As String ' Spieler Name
    Public NAM2 As String
    Public NAM3 As String
    Public NAM4 As String
    Public NAM5 As String
    Public NAM6 As String
    Public NAM7 As String
    Public NAM8 As String
    Public NAM9 As String
    Public NAM10 As String
    Public SaveState As String = ""


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Host_Client.Show()
        Me.Hide()




    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load








    End Sub
End Class
