Public Class frmLayoutMachineMasterInfo
    Dim data As DataTable
    Dim eff As String
    Dim rpm As Decimal

    Sub ambilrecord(ByVal a As String, ByVal b As String)

        If frmLayoutMachineMaster.param_plan_month <> "" Then
 
            If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
            KoneksiCIM()
            KonCIM.Open()

            data = ExecuteQuery("select top 1 rpm, eff from wv_loom_eff where plan_month = '" & a & "'  and grey_no = '" & b & "' ")

            If data.Rows.Count > 0 Then
                eff = data.Rows(0).Item("eff")
                rpm = data.Rows(0).Item("rpm")
            Else
                eff = 0
                rpm = 0
            End If

        End If

    End Sub

    Private Sub frmLayoutMachineMasterInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ambilrecord(frmLayoutMachineMaster.param_plan_month, frmLayoutMachineMaster.param_Grey_No)
        txtPlanMonth.Text = frmLayoutMachineMaster.param_plan_month
        txtGreyNo.Text = frmLayoutMachineMaster.param_Grey_No
        txtLoomNo.Text = frmLayoutMachineMaster.param_loom_no
        txtRPM.Text = rpm
        txtEFF.Text = eff + " %"

        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        data = Nothing

    End Sub
End Class