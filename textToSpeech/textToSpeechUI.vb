Public Class textToSpeechUI

    Dim SAPIObject = CreateObject("SAPI.spvoice")


    Private Sub textToSpeechUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TrackBar1.Value = 0
        TrackBar2.Value = 70
        SAPIObject.Volume = TrackBar2.Value

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SAPIObject.Speak(TextBox1.Text, AudioPlayMode.Background)
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        SAPIObject.Rate = TrackBar1.Value
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        SAPIObject.Volume = TrackBar2.Value
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SAPIObject.Pause
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SAPIObject.Resume
    End Sub
End Class
