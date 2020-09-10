Public Class frmUpdateLoomSettingCariData

    Dim Plan_Month As String
    Dim Plan_date As Date
    Dim loom_no As String
    Dim data As DataTable
    Dim str As String

    Sub Caridata()

        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        KoneksiCIM()
        KonCIM.Open()

        Select Case frmUpdateLoomSetting.par_query
            Case "Query Fabric"
                str = "select grey_no from wv_fabric_analysis_master where grey_no like '" & txtGreNo.Text & "%' "
                data = ExecuteQuery(str)
                dgDetail2.DataSource = Data
                dgDetail2.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
            Case "Query Detil2"
                str = "select plan_month, loom_no, plan_date, shift_time, Grey_no from wv_prod_plan_detail2 where plan_month like  '" & Plan_Month & "%' and plan_date = '" & Plan_date & "' and loom_no like '" & loom_no & "%' "
                data = ExecuteQuery(str)
                dgDetail2.DataSource = Data
                dgDetail2.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro
        End Select

    End Sub

    Private Sub dtpPlanDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpPlanDate.Leave


        Select Case frmUpdateLoomSetting.par_query
            Case "Query Fabric"

            Case "Query Detil2"
                Plan_date = dtpPlanDate.Value.ToString("yyyy-MM-dd")
        End Select


    End Sub

    Private Sub frmUpdateLoomSettingCariData_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        dgDetail2.DataSource = Nothing
        KonCIM.Close()
    End Sub

    Private Sub frmUpdateLoomSettingCariData_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Select Case frmUpdateLoomSetting.par_query
            Case "Query Fabric"
                txtPlanMonth.Visible = False
                dtpPlanDate.Visible = False
                txtLoomNo.Visible = False
                txtGreNo.Visible = True
                txtGreNo.Focus()
            Case "Query Detil2"
                dtpPlanDate.Value = Date.Today
                txtPlanMonth.Visible = True
                dtpPlanDate.Visible = True
                txtLoomNo.Visible = True
                txtGreNo.Visible = False
        End Select
    End Sub

    Private Sub btnCari_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCari.Click
        Caridata()
    End Sub

    Private Sub txtPlanMonth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlanMonth.Click

        Select Case frmUpdateLoomSetting.par_query
            Case "Query Fabric"

            Case "Query Detil2"
                txtPlanMonth.Text = ""
        End Select

    End Sub

    Private Sub txtPlanMonth_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPlanMonth.Leave

        Select Case frmUpdateLoomSetting.par_query
            Case "Query Fabric"

            Case "Query Detil2"
                Plan_Month = txtPlanMonth.Text
        End Select
    End Sub

    Private Sub dgDetail2_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail2.CellClick
        dgDetail2.ClearSelection()
    End Sub


    Private Sub dgDetail2_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail2.CellContentClick
        dgDetail2.ClearSelection()

    End Sub

    Private Sub dgDetail2_CellContentDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail2.CellContentDoubleClick
        dgDetail2.ClearSelection()
    End Sub

    Private Sub dgDetail2_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDetail2.CellDoubleClick
        dgDetail2.ClearSelection()

    End Sub

    Private Sub dgDetail2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgDetail2.DoubleClick

        Select Case frmUpdateLoomSetting.par_query
            Case "Query Fabric"
                Try
                    If dgDetail2.RowCount > 0 Then
                        frmUpdateLoomSetting.txtGreyNo2.Text = dgDetail2.SelectedRows.Item(0).Cells(0).Value
                    End If
                    Me.Dispose()
                    data = Nothing
                Catch ex As Exception
                    dgDetail2.ClearSelection()
                    'MessageBox.Show(ex.Message)
                End Try
            Case "Query Detil2"
                Try

                    If dgDetail2.RowCount > 0 Then
                        frmUpdateLoomSetting.txtGreyNO1.Text = dgDetail2.SelectedRows.Item(0).Cells("grey_no").Value
                        frmUpdateLoomSetting.txtPlanMonth.Text = dgDetail2.SelectedRows.Item(0).Cells("plan_month").Value
                        frmUpdateLoomSetting.txtLoomNo.Text = dgDetail2.SelectedRows.Item(0).Cells("loom_no").Value
                        frmUpdateLoomSetting.dtpPlanDate.Value = CDate(dgDetail2.SelectedRows.Item(0).Cells("plan_date").Value.ToString)
                    End If

                    Me.Dispose()
                    data = Nothing
                Catch ex As Exception
                    dgDetail2.ClearSelection()
                End Try
        End Select
    End Sub

    Private Sub txtGreNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGreNo.Click
        Select Case frmUpdateLoomSetting.par_query
            Case "Query Fabric"
                txtGreNo.Text = ""
            Case "Query Detil2"

        End Select
    End Sub

    Private Sub txtGreNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGreNo.TextChanged
        Caridata()
    End Sub


    Private Sub dgDetail2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dgDetail2.KeyPress
        Select Case frmUpdateLoomSetting.par_query
            Case "Query Fabric"
                If e.KeyChar = ChrW(Keys.Enter) Then
                    frmUpdateLoomSetting.txtGreyNo2.Text = dgDetail2.SelectedRows.Item(0).Cells(0).Value
                End If

        End Select
    End Sub

    Private Sub txtLoomNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLoomNo.Leave
        Select Case frmUpdateLoomSetting.par_query
            Case "Query Fabric"

            Case "Query Detil2"
                loom_no = txtLoomNo.Text
        End Select
    End Sub

    Private Sub txtLoomNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLoomNo.Click
        Select Case frmUpdateLoomSetting.par_query
            Case "Query Fabric"

            Case "Query Detil2"
                txtLoomNo.Text = ""
        End Select
    End Sub
End Class