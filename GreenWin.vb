Public Class WinPopup
    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles ok_Button.Click
        Form1.freezeboard = False
        Me.Close()
    End Sub
    Private Sub OkButton_Enter(sender As Object, e As EventArgs) Handles ok_Button.MouseEnter
        ok_Button.Image = My.Resources.ok_hover
    End Sub
    Private Sub OkButton_Exit(sender As Object, e As EventArgs) Handles ok_Button.MouseLeave
        ok_Button.Image = My.Resources.ok_button
    End Sub

    Private Sub OkButton_MouseDown(sender As Object, e As EventArgs) Handles ok_Button.MouseDown
        ok_Button.Image = My.Resources.ok_down
    End Sub

    Private Sub OkButton_MouseUp(sender As Object, e As EventArgs) Handles ok_Button.MouseUp
        ok_Button.Image = My.Resources.ok_hover
    End Sub

    Private Sub WinPopup_Load(sender As Object, e As EventArgs) Handles MyBase.Closed
        Form1.freezeboard = False
    End Sub
End Class