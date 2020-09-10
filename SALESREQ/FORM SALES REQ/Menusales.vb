Public Class Menusales
    'Private Sub PictureBox2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs)
    '    PictureBox2.Image = My.Resources.Black2_edit_1_
    'End Sub

    'Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs)
    '    PictureBox2.Image = My.Resources.Black1_edit_1_
    'End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        frmSales_Entry_Req.ShowDialog()
    End Sub

    Private Sub PictureBox2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseHover
        PictureBox2.Image = My.Resources.Black2_edit_1_
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Image = My.Resources.Black1_edit_1_
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        frmSales_Delivery_Entry.ShowDialog()
    End Sub
    
    Private Sub PictureBox1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseHover
        PictureBox1.Image = My.Resources.Green2_edit_1_
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Image = My.Resources.Green1_edit_1_
    End Sub
End Class