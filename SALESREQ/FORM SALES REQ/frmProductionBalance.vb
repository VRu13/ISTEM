Public Class frmProductionBalance
    Public par_plan_month_prod_bal As String

    Private Sub frmProductionBalance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetComboBox("Select distinct plan_month from wv_prod_plan_detail2", "frmProductionBalance")
    End Sub

    Private Sub cb_plan_month_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cb_plan_month.SelectedIndexChanged
        par_plan_month_prod_bal = cb_plan_month.SelectedItem
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        par_form = "PRODUCTION BALANCE"
        frmReportView.ShowDialog()
    End Sub
End Class