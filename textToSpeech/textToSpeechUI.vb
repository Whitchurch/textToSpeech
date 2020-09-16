Public Class textToSpeechUI

    Dim SAPIObject = CreateObject("SAPI.spvoice")


    Private Sub textToSpeechUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = "The number of voices installed is " & SAPIObject.getvoices.count + 1
        TrackBar1.Value = 0
        TrackBar2.Value = 70
        SAPIObject.Volume = TrackBar2.Value

        For i = 0 To SAPIObject.getvoices.count
            Try
                SAPIObject.Voice = SAPIObject.getvoices.item(i)
                SAPIObject.Speak("")
                ListBox1.Items.Add("Voice #" & i & " " & SAPIObject.Voice.GetDescription)
            Catch ex As Exception
                ListBox2.Items.Add("Voice #" & i & " " & SAPIObject.Voice.GetDescription)
            End Try
        Next


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

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        SAPIObject.Voice = SAPIObject.getvoices.Item(Microsoft.VisualBasic.Val(ListBox1.SelectedItem.Substring(7, 2)))
        SAPIObject.Speak("You have selected " & ListBox1.SelectedItem.ToString)
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        'SAPIObject.Voice = SAPIObject.getvoices.Item(Microsoft.VisualBasic.Val(ListBox2.SelectedItem.Substring(7, 2)))
        ListBox2.ClearSelected()
        SAPIObject.Speak("You have selected a voice that is disabled")

    End Sub
End Class
