Public Class frmDailyLoomSet
    Public par_plan_month As String

    Private Sub frmDailyLoomSetvb_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        SetComboBox("Select distinct plan_month from wv_prod_plan_detail2", "frmDailyLoomSet")

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        par_form = "DAILY LOOM SETING"
        frmReportView.ShowDialog()
    End Sub

    Private Sub cb_plan_month_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_plan_month.SelectedIndexChanged
        par_plan_month = cb_plan_month.SelectedItem
    End Sub
End Class