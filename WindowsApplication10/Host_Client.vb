Public Class Host_Client
    Private Sub Host_Client_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Hauptmenü.Show()
    End Sub

    Private Sub Host_Client_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Hauptmenü.Show()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()
        IPMann.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Host.Show()
    End Sub
End Class