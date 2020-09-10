Public Class Menuweaving
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        frmGenerate_Plan.ShowDialog()
    End Sub
 
    Private Sub PictureBox3_MouseHover1(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseHover
        PictureBox3.Image = My.Resources.Purple2_edit_
    End Sub

    Private Sub PictureBox3_MouseLeave1(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Image = My.Resources.Purple1_edit_
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        frmUpdGrySett.ShowDialog()
    End Sub
    Private Sub PictureBox4_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseHover
        PictureBox4.Image = My.Resources.Red2_edit_
    End Sub

    Private Sub PictureBox4_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox4.MouseLeave
        PictureBox4.Image = My.Resources.Red1_edit_
    End Sub
    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox5.Click
        frmLoomeff.ShowDialog()
    End Sub
    Private Sub PictureBox5_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseHover
        PictureBox5.Image = My.Resources.Blue2_edit_
    End Sub
    Private Sub PictureBox5_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox5.MouseLeave
        PictureBox5.Image = My.Resources.Blue1_edit_
    End Sub
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox6.Click
        frmEntryReqYarn.ShowDialog()
    End Sub

    Private Sub PictureBox6_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseHover
        PictureBox6.Image = My.Resources.Brown2_edit_
    End Sub

    Private Sub PictureBox6_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox6.MouseLeave
        PictureBox6.Image = My.Resources.Brown1_edit_
    End Sub

    Private Sub btnUpdateLoomSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateLoomSetting.Click
        frmUpdateLoomSetting.ShowDialog()
    End Sub
End Class