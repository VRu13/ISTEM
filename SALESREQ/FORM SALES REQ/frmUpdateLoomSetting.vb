Public Class frmUpdateLoomSetting
    Dim query, loom_model As String
    Dim datatampil As DataTable
    Public par_MachineMasterGrey As String
    Public par_query As String
    Public par_save As String = ""

    Sub SetParameterMachineMaster()
        par_save = "Update Loom Setting"
    End Sub

    Sub SettingUpdateDailyLoomSetting(ByVal Z As String)

        Select Case Z
            Case "Kunci"
                txtPlanMonth.Enabled = False
                dtpPlanDate.Enabled = False
                txtLoomNo.Enabled = False
                txtGreyNO1.Enabled = False
                txtGreyNo2.Enabled = False

                btnCariDetail.Enabled = False
                btnCariDetail2.Enabled = False
                btnCancel.Enabled = False
                btnSave.Enabled = False
                btnDailyLoom.Enabled = False
                ceboxDrawIn.Enabled = False
                btnUpdateGrey.Enabled = False

            Case "Button Modify"

                txtPlanMonth.Enabled = True
                dtpPlanDate.Enabled = True
                txtLoomNo.Enabled = True
                txtGreyNO1.Enabled = True
                txtGreyNo2.Enabled = True

                btnCariDetail.Enabled = True
                btnCariDetail2.Enabled = True
                btnCancel.Enabled = True
                btnSave.Enabled = True
                btnMachineLayout.Enabled = True
                ceboxDrawIn.Enabled = True
                btnDailyLoom.Enabled = False
                btnUpdateGrey.Enabled = False

                txtPlanMonth.Text = ""
                txtLoomNo.Text = ""
                txtGreyNO1.Text = ""
                txtGreyNo2.Text = ""
                DGUpdateLoom.DataSource = Nothing

            Case "Button Cancel"
                txtPlanMonth.Text = ""
                txtLoomNo.Text = ""
                txtGreyNO1.Text = ""
                txtGreyNo2.Text = ""

                ceboxDrawIn.Checked = False
                DGUpdateLoom.DataSource = Nothing
                par_form = ""

            Case "Button Save"
                btnUpdateGrey.Enabled = True
                btnDailyLoom.Enabled = True
                btnSave.Enabled = False
                btnCancel.Enabled = False

        End Select

    End Sub

    Sub SetDataGridUpdateLoomSetting()

        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        KoneksiCIM()
        KonCIM.Open()

        query = "select " & _
                    "plan_month, " & _
                    "Plan_date, " & _
                    "loom_no, " & _
                    "grey_no, " & _
                    "shift_time " & _
                "from " & _
                    "wv_prod_plan_detail2 " & _
                "where " & _
                    "plan_month = '" & txtPlanMonth.Text & "' and " & _
                    "grey_no = '" & txtGreyNo2.Text & "' and " & _
                    "loom_no = '" & txtLoomNo.Text & "' and " & _
                    "plan_date >= '" & Format(dtpPlanDate.Value, "yyyy-MM-dd") & "' " & _
                "order by " & _
                    "plan_date, loom_no, grey_no "

        datatampil = ExecuteQuery(query)
        DGUpdateLoom.DataSource = datatampil

        datatampil = Nothing
        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()

    End Sub
    Sub SaveData()
        'LOGIC SAVE
        '1. Insert data ke history untuk pengecekan sebelum update
        '2. update wv_prod_plan_detail2 sesuai yang di input
        '3. Update wv_prod_plan header rev + 1
        '4. Delete wv_prod_plan_detail3 berdasarkan plan month
        '5. Generate Plan Sub 5 (itung ulang average mesin per hari)
        '6. Cek grey baru di wv_loom-eff apabila belum ada Insert data kosong grey baru ke wv_loom_eff kemudian tampilkan form update grey setting , kalau sudah ada ada lanjut ke step 7
        '7. Munculkan form update grey setting agar user bisa langsung update mesin spec

        Dim query1, query2, query3, query4, query5 As String


        '1. insert into ke history data dari tanggal dtpPlanDate sampai kedepan dengan patokan nomor mesin, grey_no, loom_no, Plan_month dan cek ke prod
        'pla header untuk cari tanggal terakhir nya (month3_period2_to)
        query1 = "Insert Into wv_prod_plan_detail2_hist " & _
                "   (plan_month, plan_date, grey_no, shift_time, loom_no, draw_in_flag, rec_sts, proc_no ) " & _
                "Select                                                                         " & _
                "   plan_month,                                                                 " & _
                "   plan_date,                                                                  " & _
                "   grey_no,                                                                    " & _
                "   shift_time,                                                                 " & _
                "   loom_no, 1,'T',1                                                            " & _
                "   from wv_prod_plan_detail2                                                   " & _
                "where                                                                          " & _
                "   plan_month = '" & txtPlanMonth.Text & "' and                                " & _
                "   plan_date between  '" & dtpPlanDate.Value.ToString("yyyy-MM-dd") & "' and   " & _
                "       ( select                                                                " & _
                "           month3_period2_to                                                   " & _
                "         from                                                                  " & _
                "           wv_prod_plan_header                                                 " & _
                "         where                                                                 " & _
                "           plan_month = '" & txtPlanMonth.Text & "'                            " & _
                "        ) and                                                                  " & _
                "   grey_no = '" & txtGreyNO1.Text & "' and                                     " & _
                "   loom_no = '" & txtLoomNo.Text & "' "

        '2.
        query2 = "update                                                                         " & _
                 "  wv_prod_plan_detail2                                                         " & _
                 "Set                                                                            " & _
                 "   grey_no = '" & txtGreyNo2.Text & "',                                        " & _
                 "   draw_in_flag = '" & IIf(ceboxDrawIn.Checked = True, 1, vbNull) & "'         " & _
                 "where                                                                          " & _
                 "   plan_month = '" & txtPlanMonth.Text & "' and                                " & _
                 "   plan_date between  '" & dtpPlanDate.Value.ToString("yyyy-MM-dd") & "' and   " & _
                 "       ( select                                                                " & _
                 "           month3_period2_to                                                   " & _
                 "         from                                                                  " & _
                 "           wv_prod_plan_header                                                 " & _
                 "         where                                                                 " & _
                 "           plan_month = '" & txtPlanMonth.Text & "'                            " & _
                 "        )  and                                                                 " & _
                 "   grey_no = '" & txtGreyNO1.Text & "' and                                     " & _
                 "   loom_no = '" & txtLoomNo.Text & "' "

        '3.
        query3 = "Update wv_prod_plan_header " & _
                 "Set " & _
                 "  plan_rev_no  = plan_rev_no + 1 " & _
                 "where " & _
                 "  plan_month  = '" & txtPlanMonth.Text & "' "

        '4.
        query4 = "Delete from wv_prod_plan_detail3 where plan_month  = '" & txtPlanMonth.Text & "' "

        '5.
        query5 = "Exec wppc.sp_AverageMesinPerHari '" & txtPlanMonth.Text & "' "

        ExecuteNonQuery(query1, query2, query3, query4, query5)

        '6. cek di wv loom eff
        If ErrorQuery = True Then
            GoTo keluar
        Else
            CekGreyNo()
        End If

keluar:
    End Sub

    Sub CekGreyNo()
        Try
            Dim query As String
            Dim density As Decimal

            If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
            KoneksiCIM()
            KonCIM.Open()

            query = "select loom_model from machine_master where block + loom_no = '" & txtLoomNo.Text & "' "
            datatampil = ExecuteQuery(query)
            loom_model = datatampil.Columns(0).Table.Rows(0).Item(0)
            datatampil = Nothing
            KonCIM.Close()

            KoneksiCIM()
            KonCIM.Open()
            query = "select weft_gr from wv_fabric_analysis_master where grey_no = '" & txtGreyNo2.Text & "' "
            datatampil = ExecuteQuery(query)
            density = datatampil.Columns(0).Table.Rows(0).Item(0)
            datatampil = Nothing
            KonCIM.Close()

            KoneksiCIM()
            KonCIM.Open()

            query = "select grey_no from wv_loom_eff where plan_month = '" & txtPlanMonth.Text & "' and grey_no = '" & txtGreyNo2.Text & "' and loom_model = '" & loom_model & "' "
            datatampil = ExecuteQuery(query)

            
            If datatampil.Rows.Count > 0 Then
                par_form = "frmUpdateLoomSetting" & "/" & txtPlanMonth.Text & "/" & txtGreyNo2.Text & "/" & loom_model
                frmUpdGrySett.ShowDialog() 'tampilkan update grey setting
                Me.Cursor = Cursors.Default
            Else
                Dim query1 As String
                query1 = "Insert into wv_loom_eff(plan_month, grey_no, loom_model, density) values ('" & txtPlanMonth.Text & "', '" & txtGreyNo2.Text & "', '" & loom_model & "', '" & density & "')"
                ExecuteNonQuery(query1, "", "", "", "")
                par_form = "frmUpdateLoomSetting" & "/" & txtPlanMonth.Text & "/" & txtGreyNo2.Text & "/" & loom_model
                frmUpdGrySett.ShowDialog() 'tampilkan update grey setting
                Me.Cursor = Cursors.Default

            End If

            datatampil = Nothing
            KonCIM.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Me.Cursor = Cursors.WaitCursor
        SaveData()
        SetDataGridUpdateLoomSetting()
        SetParameterMachineMaster()
        SettingUpdateDailyLoomSetting("Button Save")

    End Sub

    Private Sub frmUpdateLoomSetting_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SettingUpdateDailyLoomSetting("Kunci")
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        SettingUpdateDailyLoomSetting("Button Modify")
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        SettingUpdateDailyLoomSetting("Button Cancel")
    End Sub

    Private Sub btnMachineLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMachineLayout.Click
        par_MachineMasterGrey = par_save & "/" & txtPlanMonth.Text & "/" & Format(dtpPlanDate.Value, "yyyy-MM-dd") & "/" & txtLoomNo.Text
        frmLayoutMachineMaster.ShowDialog()
    End Sub

    Private Sub btnCariDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCariDetail.Click
        par_query = "Query Detil2"
        frmUpdateLoomSettingCariData.ShowDialog()

    End Sub

    Private Sub btnCariDetail2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCariDetail2.Click
        par_query = "Query Fabric"
        frmUpdateLoomSettingCariData.ShowDialog()
    End Sub

    Private Sub btnDailyLoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDailyLoom.Click
        par_form = "Update Loom Setting"
        frmReportView.Show()

    End Sub

    Private Sub btnUpdateGrey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdateGrey.Click
        par_form = "frmUpdateLoomSetting" & "/" & txtPlanMonth.Text & "/" & txtGreyNo2.Text & "/" & loom_model
        frmUpdGrySett.ShowDialog()
    End Sub
End Class