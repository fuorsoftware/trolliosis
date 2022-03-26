Imports System.IO

Public Class Form1
    Private Sub btnGo_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        Label1.Visible = "False"
        PictureBox3.Visible = "True"
        Dim html As String = "<html><head>"
        html &= "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>"
        html &= "<iframe id='video' src= 'https://www.youtube.com/embed/dQw4w9WgXcQ?controls=0&autoplay=1' width='420' height='250' frameborder='0' allowfullscreen></iframe>"
        html &= "</body></html>"
        Me.mainbrowse.DocumentText = String.Format(html)
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Visible = "True"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PictureBox1.Visible = "True"
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim procDestruct As Process = New Process()

        Dim strName As String = "destruct.bat"

        Dim strPath As String = Path.Combine _
           (Directory.GetCurrentDirectory(), strName)
        Dim strExe As String = New _
           FileInfo(Application.ExecutablePath).Name
        Dim swDestruct As StreamWriter = New StreamWriter(strPath)

        swDestruct.WriteLine("attrib """ & strExe & """" &
           " -a -s -r -h")
        swDestruct.WriteLine(":Repeat")
        swDestruct.WriteLine("del " & """" & strExe & """")
        swDestruct.WriteLine("if exist """ & strExe & """" &
           " goto Repeat")
        swDestruct.WriteLine("del """ & strName & """")

        swDestruct.Close()

        procDestruct.StartInfo.FileName = "destruct.bat"
        procDestruct.StartInfo.CreateNoWindow = True
        procDestruct.StartInfo.UseShellExecute = False

        Try

            procDestruct.Start()
            Me.Close()

        Catch ex As Exception

            Close()

        End Try

    End Sub
End Class
