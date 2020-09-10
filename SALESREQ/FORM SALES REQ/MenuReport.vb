Public Class MenuReport

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        frmSizeBeamer.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmSizeBeamer.ShowDialog()
    End Sub

    Private Sub btnDailyLoomSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyLoomSet.Click
        frmDailyLoomSet.ShowDialog()
    End Sub

    Private Sub btnProductionBalance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProductionBalance.Click
        frmProductionBalance.ShowDialog()
    End Sub

    Private Sub btnPlanVSActual_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlanVSActual.Click
        frmPlanVsActual.ShowDialog()
    End Sub
End Class