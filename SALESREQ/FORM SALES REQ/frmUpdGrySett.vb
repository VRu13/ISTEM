Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Public Class frmUpdGrySett
    Dim SimpanData, Ubahdata As String
    Dim TR As SqlTransaction

    Dim param, param_plan_month, param_grey_no, param_loom_model As String
    Dim strArr() As String

    Sub ParsingDarifrmUpdateLoomSetting()
        strArr = par_form.Split("/")
        param = strArr(0)
        param_plan_month = strArr(1)
        param_grey_no = strArr(2)
        param_loom_model = strArr(3)
    End Sub

    Sub setvalue(ByVal x As String)
        Select Case x
            Case Is = "LOAD"
                cmbPlanMonthedit.Text = param_plan_month
            Case Is = "GREYNO"
                cmbGreyno.Text = param_grey_no
            Case Is = "LOOMMODEL"
                cmbLoom.Text = param_loom_model
        End Select

    End Sub

    Sub Buka_ProdHeader()
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select plan_month,plan_rev_no from wv_prod_plan_header where plan_month='" & (cmbPlanMonthedit.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            lblRevno.Text = DR.Item("plan_rev_no")
        End If
        KonCIM.Close()
    End Sub
    Sub UbahPlanRevno()
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            'If MessageBox.Show("Yakin akan di kirim datanya ...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Ubahdata = "Update wv_prod_plan_header set plan_rev_no=@plan_rev_no where plan_month ='" & (cmbPlanMonthedit.Text) & "'"
            Dim i As Integer
            If CInt(lblRevno.Text) = 1 Then
                i = CInt(lblRevno.Text) + 1
            Else
                i = CInt(lblRevno.Text) + 1
            End If
            '
            Dim CMD As New SqlCommand(Ubahdata, KonCIM)
            'CMD.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            CMD.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
            KonCIM.Open()
            TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Transaction = TR
            Try
                ' CMD.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
                CMD.Parameters("@plan_rev_no").Value = CInt(i)
                '
                CMD.ExecuteNonQuery()
                TR.Commit()
                'MessageBox.Show("Data Berhasil", "Informasi")
            Catch ex As Exception
                Try
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                Catch rollBackEx As Exception
                    MessageBox.Show(rollBackEx.Message)
                End Try
            End Try
            'End If
        End Using
        KonCIM.Close()
    End Sub
    Sub Buka_DataComboPlan()
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select distinct(plan_month) from sl_grey_request", KonCIM)
        DR = CMD.ExecuteReader
        cmbPlanMonthedit.Items.Clear()
        Do While DR.Read
            cmbPlanMonthedit.Items.Add(DR.Item(0))
        Loop
        KonCIM.Close()
    End Sub
    Sub Buka_DataGreyPlan()
        '
        KoneksiCIM()
        KonCIM.Open()
        '      
        CMD = New SqlCommand("Select distinct(grey_no) from wv_loom_eff where plan_month='" & (cmbPlanMonthedit.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        cmbGreyno.Items.Clear()
        Do While DR.Read
            cmbGreyno.Items.Add(DR.Item(0))
        Loop
        KonCIM.Close()
    End Sub
    Sub Buka_DataAll()
        '
        KoneksiCIM()
        KonCIM.Open()
        '      
        CMD = New SqlCommand("Select prod_day_pcs,prod_day_mtr,density,rpm,Eff from wv_loom_eff where plan_month='" & (cmbPlanMonthedit.Text) & "' and grey_no ='" & (cmbGreyno.Text) & "' and loom_model='" & (cmbLoom.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            txtPrPCS.Text = DR.Item("prod_day_pcs")
            txtPrMtr.Text = DR.Item("prod_day_mtr")
            txtPrDen.Text = DR.Item("density")
            txtRpm.Text = DR.Item("rpm")
            txtPrEff.Text = DR.Item("Eff")
        End If
        KonCIM.Close()
    End Sub
    Sub Buka_DataLoom()
        '
        KoneksiCIM()
        KonCIM.Open()
        '      
        CMD = New SqlCommand("Select loom_model from wv_loom_eff where plan_month='" & (cmbPlanMonthedit.Text) & "' and grey_no ='" & (cmbGreyno.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        cmbLoom.Items.Clear()
        If DR.HasRows Then
            Do While DR.Read
                cmbLoom.Items.Add(DR.Item(0))
            Loop
        End If
        KonCIM.Close()
    End Sub
    Private Sub frmUpdGrySett_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Buka_DataComboPlan()
        If par_form.Contains("frmUpdateLoomSetting") = True Then
            ParsingDarifrmUpdateLoomSetting()
            setvalue("LOAD")
        End If

    End Sub

    Private Sub cmbPlanMonthedit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlanMonthedit.SelectedIndexChanged
        Buka_DataGreyPlan()
        Buka_ProdHeader()
        txtPrPCS.Text = ""
        txtPrMtr.Text = ""
        txtPrDen.Text = ""
        txtRpm.Text = ""
        txtPrEff.Text = ""
        cmbGreyno.Text = ""
        cmbLoom.Text = ""


        If par_form.Contains("frmUpdateLoomSetting") = True Then
            setvalue("GREYNO")
        End If

    End Sub

    Private Sub cmbGreyno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGreyno.SelectedIndexChanged
        Buka_DataLoom()
        BukaDataFabbricAnalys()
        txtPrPCS.Text = ""
        txtPrMtr.Text = ""
        txtPrDen.Text = ""
        txtRpm.Text = ""
        txtPrEff.Text = ""
        cmbLoom.Text = ""

        If par_form.Contains("frmUpdateLoomSetting") = True Then
            setvalue("LOOMMODEL")
        End If

    End Sub
    Sub HitungJumlahProdDay()
        Dim y, z As Double
        '(rpm*2.54*60*24*eff/100)/density*100
        'If txtPrMtr.Text = "" Then
        y = (CDbl(txtPrEff.Text) / 100) / (CDbl(txtPrDen.Text) * 100)
        z = (CDbl(txtRpm.Text) * 2.54 * 60 * 24 * y)
        txtPrMtr.Text = Math.Round(z, 2)
        'End If
    End Sub
    Sub HitungJumlahProdDayPCS()
        Dim x, y As Decimal
        '(rpm*2.54*60*24*eff/100)/density/100*length_gr
        'x = (CDbl(lblRata.Text) * 2.54 * 60 * 24 * CDbl(lbleff.Text) / 100) / CDbl(lblwef.Text) / 100 * CDbl(lbllength_grey.Text)
        'If txtPrPCS.Text = "" Then
        y = (CDbl(txtPrDen.Text) * 100 * CDbl(lblLength.Text))
        x = ((CDbl(txtRpm.Text) * 2.54 * 60 * 24 * (CDbl(txtPrEff.Text) / 100)) / y)
        txtPrPCS.Text = Math.Round(x, 2)
        'End If
    End Sub
    Sub BukaDataFabbricAnalys()
        KoneksiCIM()
        KonCIM.Open()
        '      
        CMD = New SqlCommand("Select grey_no, weft_gr,length_gr, eff_loom from wv_fabric_analysis_master where grey_no ='" & (cmbGreyno.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            lblLength.Text = DR.Item("length_gr")
            'lbleff.Text = DR.Item("eff_loom")
            'lblwef.Text = DR.Item("weft_gr")
            'Menambahkan length Untuk prodday_pcs
            'lblJmlGrey.Text = Str(DR.Item("Jumlah"))
        Else
            lblLength.Text = "0"
            'lblwef.Text = "0"
        End If
        KonCIM.Close()
    End Sub
  
    Private Sub cmbLoom_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLoom.SelectedIndexChanged
        Buka_DataAll()
    End Sub

    Private Sub BtnSett_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSett.Click
        If cmbPlanMonthedit.Text = "" Or cmbGreyno.Text = "" Or cmbLoom.Text = "" Then
            MessageBox.Show("Maaf Data ada yang kosong")
            Exit Sub
        End If
        HitungJumlahProdDay()
        HitungJumlahProdDayPCS()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        KoneksiCIM()
        KonCIM.Open()
        '
        If cmbPlanMonthedit.Text = "" Or cmbGreyno.Text = "" Or cmbLoom.Text = "" Then
            MessageBox.Show("Maaf Data ada yang kosong")
            Exit Sub
        End If
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            If MessageBox.Show("Yakin akan di Simpan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Ubahdata = "Update wv_loom_eff set plan_month=@plan_month,grey_no=@grey_no,loom_model=@loom_model,rpm=@rpm,density=@density,eff=@eff,prod_day_mtr=@prod_day_mtr," _
                    & "prod_day_pcs=@prod_day_pcs,rec_sts=@rec_sts,proc_no=@proc_no,upd_date=@upd_date,upd_time=@upd_time,user_id=@user_id,client_ip=@client_ip where plan_month=@plan_month and grey_no=@grey_no and loom_model=@loom_model"
                Dim CMDSimpan As New SqlCommand(Ubahdata, KonCIM) '@plan_version,@plan_date
                'where plan_month=@plan_month and grey_no=@grey_no
                'plan_rev_no=@plan_rev_no,request_date=@request_date ada
                'Ubahdata = "Update sl_grey_request set plan_month=@plan_month,item_category=@item_category,garment_flag=@garment_flag,grey_no=@grey_no,plan_rev_no=@plan_rev_no,request_date=@request_date,remain_input_qty=@remain_input_qty," _
                '                       & "month1_input_qty=@month1_input_qty,month1_deliv_qty=@month1_deliv_qty,month2_input_qty=@month2_input_qty," _
                '                       & "month2_deliv_qty=@month2_deliv_qty,month3_input_qty=@month3_input_qty,month3_deliv_qty=@month3_deliv_qty,rec_sts=@rec_sts,user_id=@user_id,proc_no=@proc_no,upd_date=@upd_date,upd_time=@upd_time,client_ip=@client_ip where plan_month=@plan_month and grey_no=@grey_no"
                CMDSimpan.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                CMDSimpan.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
                CMDSimpan.Parameters.Add(New SqlParameter("@loom_model", SqlDbType.VarChar))
                CMDSimpan.Parameters.Add(New SqlParameter("@rpm", SqlDbType.Int))
                CMDSimpan.Parameters.Add(New SqlParameter("@density", SqlDbType.Int))
                CMDSimpan.Parameters.Add(New SqlParameter("@eff", SqlDbType.VarChar))
                CMDSimpan.Parameters.Add(New SqlParameter("@prod_day_mtr", SqlDbType.Float))
                CMDSimpan.Parameters.Add(New SqlParameter("@prod_day_pcs", SqlDbType.Float))
                CMDSimpan.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.VarChar))
                CMDSimpan.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                'prod_day_pcs
                CMDSimpan.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
                CMDSimpan.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
                CMDSimpan.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
                CMDSimpan.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
                ''
                KonCIM.Open()
                TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
                CMDSimpan.Transaction = TR
                '
                Try
                    CMDSimpan.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
                    CMDSimpan.Parameters("@grey_no").Value = cmbGreyno.Text 'Convert.ToDateTime(lblRemindfrmperiodawal)
                    CMDSimpan.Parameters("@loom_model").Value = cmbLoom.Text 'HasilPlantmonth
                    CMDSimpan.Parameters("@rpm").Value = txtRpm.Text 'Convert.ToDateTime(lblRemindfrmperiodawal)CMDSimpan.Parameters("@plan_month").Value = "" 'HasilPlantmonth
                    CMDSimpan.Parameters("@density").Value = txtPrDen.Text 'Convert.ToDateTime(lblRemindfrmperiodawal)CMDSimpan.Parameters("@plan_month").Value = "" 'HasilPlantmonth
                    CMDSimpan.Parameters("@eff").Value = txtPrEff.Text 'Convert.ToDateTime(lblRemindfrmperiodawal)CMDSimpan.Parameters("@plan_month").Value = "" 'HasilPlantmonth
                    CMDSimpan.Parameters("@prod_day_mtr").Value = txtPrMtr.Text 'Convert.ToDateTime(lblRemindfrmperiodawal)CMDSimpan.Parameters("@plan_month").Value = "" 'HasilPlantmonth
                    CMDSimpan.Parameters("@prod_day_pcs").Value = txtPrPCS.Text 'Convert.ToDateTime(lblRemindfrmperiodawal)CMDSimpan.Parameters("@plan_month").Value = "" 'HasilPlantmonth
                    CMDSimpan.Parameters("@rec_sts").Value = "T" 'Convert.ToDateTime(lblRemindfrmperiodawal)CMDSimpan.Parameters("@plan_month").Value = "" 'HasilPlantmonth
                    CMDSimpan.Parameters("@proc_no").Value = "2" 'Convert.ToDateTime(lblRemindfrmperiodawal)CMDSimpan.Parameters("@plan_month").Value = "" 'HasilPlantmonth
                    CMDSimpan.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text) 'Convert.ToDateTime(lblRemindfrmperiodawal)
                    CMDSimpan.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text 'HasilPlantmonth
                    CMDSimpan.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text 'Convert.ToDateTime(lblRemindfrmperiodawal)
                    CMDSimpan.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text 'HasilPlantmonth
                    '
                    CMDSimpan.ExecuteNonQuery()
                    TR.Commit()
                    MessageBox.Show("Data Berhasil Di Simpan", "Informasi")
                Catch ex As Exception
                    Try
                        TR.Rollback()
                        MessageBox.Show(ex.Message)
                    Catch rollBackEx As Exception
                        MessageBox.Show(rollBackEx.Message)
                    End Try
                End Try
                UbahPlanRevno()
            End If
        End Using
        Bersih()
    End Sub
    Sub Bersih()
        cmbPlanMonthedit.Text = ""
        cmbGreyno.Text = ""
        cmbLoom.Text = ""
        txtPrDen.Text = ""
        txtPrEff.Text = ""
        txtPrMtr.Text = ""
        txtPrPCS.Text = ""
        txtRpm.Text = ""
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Bersih()
        Me.Close()
    End Sub
End Class