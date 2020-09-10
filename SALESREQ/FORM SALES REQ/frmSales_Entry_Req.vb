Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Public Class frmSales_Entry_Req
    Dim SimpanData, SimpanDataHist, Ubahdata, HapusData As String
    Dim Tanggalawal, AngkaBulan, Bulanawal, Tahunawal As Integer
    Dim TambahDetil, UbahDetil, CekKodeBrg, Hapusbaris As Boolean
    Dim Bulansatu, Tahunsatu As Integer
    Dim NilaiBulansatu, NilaiBulandua, NilaiBulantiga As String
    Dim Caribulan As String
    Dim CariTahun As String
    Dim CMDSimpan As New SqlCommand
    Dim CMDHapus As New SqlCommand

    Dim CariPlandata, Sql As String
    Dim DS As New DataSet
    '
    Dim Remindfromawal, Remindtoperiod1, Remindtoperiod2, Remindtoperiod3 As Date
    Dim NilaiBulan, lblRemindtoperiodawal, lblRemindtoperiod1, lblRemindtoperiod2, lblRemindtoperiod3 As String
    Dim Remindfrmperiod1, Remindfrmperiod2, Remindfrmperiod3 As Date
    Dim HasilPlantmonth, lblRemindfrmperiodawal, lblRemindfrmperiod1, lblRemindfrmperiod2, lblRemindfrmperiod3 As String
    Dim HasilperiodTo, NilaiRequestdate, Hasilfrmperiodawal, Hasilfrmperiod1, Hasilfrmperiod2, Hasilfrmperiod3 As Date
    Dim NilaiSdate As String
    Dim StatusSend As Boolean
    ' Dim HasilRemindtoperiodawal, HasilRemindtoperiod1, HasilRemindtoperiod2, HasilRemindtoperiod3 As Date
    'BUAT DGVEDIT2
    Dim RMD2, Mt1dv, Mt1ip, Mt2dv, Mt2ip, Mt3dv, Mt3ip As Integer
    Dim greynoedit, StsGf, Ktgri As String
    '
    Dim TR As SqlTransaction
    Dim TRHist As SqlTransaction
    Dim Tanggalakhir1 As String
    Dim KLM1, KLM2, KLM3 As String
    Dim Planawal As String
    Dim Bulanprd1, Bulanprd2, Bulanprd3, Tahunprd2 As Date
    Dim NilaiTglakhirAwal, NilaiTglakhirprd1, NilaiTglakhirprd2, NilaiTglakhirprd3 As Date

    Private Property CRSalesEntry As Object

    Sub Bukakunci()
        BtnAdd.Enabled = True
        BtnSave.Enabled = False
        BtnCancel.Enabled = False
        BtnEdit.Enabled = True
        BtnDeleteAll.Enabled = True
        BtnKeluar.Enabled = True
    End Sub
    Private Sub BtnSet_Planm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSet_Planm.Click
        '
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        KoneksiISTEM()
        KonIstem.Open()
        '
        If OptUbah.Checked = True Then
            CMD = New SqlCommand("Select * from sl_grey_request where plan_month = '" & (HasilPlantmonth) & "'", KonIstem)
            DR = CMD.ExecuteReader
            PnlPlandate.Visible = False
            If DR.HasRows Then
                '
                SetplanRequest()
                SortData()
                GrpCtrDetil.Enabled = True
                TabControl1.SelectTab(1)
            Else
                MsgBox("Maaf Data Set Plant Tidak ada ", vbInformation, "Informasi")
                Exit Sub
            End If
            Bukakunci()
        Else
            PnlPlandate.Visible = False
            SetplanRequest()
            CekSetPlant()
            cmbGreyno.Focus()
        End If
        cmbGreyno.Focus()
        KonIstem.Close()
    End Sub
    Private Sub BtnDelKlm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDelKlm.Click
        Dim i As Integer
        If OptUbah.Checked = False Then
            i = DGV.RowCount
            If DGV.RowCount <= 1 Then
                Exit Sub
            Else
                DGV.Rows.RemoveAt(DGV.CurrentCell.RowIndex)
            End If
        End If
    End Sub
    Private Sub BtnAddKlm_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnAddKlm.Click
        'Dim CariTgl As Date
        Dim baris As Integer = DGV.RowCount - 1
        '
        'If cmbGreyno.Text = "" Or txtInputAwal.Text = "" Or txtInpperiod1.Text = "" Or txtInpperiod2.Text = "" Or txtInpperiod3.Text = "" Or txtDlvperiod1.Text = "" Or txtDlvperiod2.Text = "" Or txtDlvperiod2.Text = "" Or txtDlvperiod3.Text = "" Then
        If cmbGreyno.Text = "" Then
            MsgBox("Maaf Greyno Tidak Boleh Dalam Keadaan Kosong", vbInformation, "Informasi")
            cmbGreyno.Focus()
            Exit Sub
        End If
        '
        Select Case True
            Case OptTR.Checked
                lblKategori.Text = "TR"
                'lblStatusGrey.Text = "G"
            Case OptSp.Checked
                lblKategori.Text = "SP"
                'lblStatusGrey.Text = ""
            Case OptAll.Checked
                lblKategori.Text = "GS"
        End Select
        '
        Select Case cmbStatusBrg.Text
            Case "Garment"
                lblStatusGrey.Text = "G"
            Case "Non Garment"
                lblStatusGrey.Text = ""
        End Select
        '
        KoneksiISTEM()
        KonIstem.Open()
        '  DGV.Rows.Add(txtKodeName.Text & Format(DtpDelivery.Value, "MM/dd/yyyy"))
        DGV.Rows.Add(lblKategori.Text & cmbGreyno.Text)
        '
        For barisatas As Integer = 0 To DGV.RowCount - 1
            For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                If DGV.Rows(barisbawah).Cells(0).Value & DGV.Rows(barisbawah).Cells(1).Value = DGV.Rows(barisatas).Cells(0).Value & DGV.Rows(barisatas).Cells(1).Value Then
                    ' If DGV.Rows(barisbawah).Cells(0).Value & DGV.Rows(barisbawah).Cells(2).Value = DGV.Rows(barisatas).Cells(0).Value & DGV.Rows(barisatas).Cells(2).Value Then
                    MsgBox("Barang sudah Ada")
                    DGV.Rows.RemoveAt(barisbawah)
                    Bersihtext()
                    cmbGreyno.Focus()
                    Exit Sub
                End If
            Next
        Next
        '
        DGV(0, DGV.RowCount - 2).Value = lblKategori.Text
        DGV(1, DGV.RowCount - 2).Value = UCase(cmbGreyno.Text)
        DGV(2, DGV.RowCount - 2).Value = lblStatusGrey.Text
        '
        If txtInputAwal.Text = "" Then
            DGV(3, DGV.RowCount - 2).Value = "0"
        Else
            DGV(3, DGV.RowCount - 2).Value = txtInputAwal.Text 'txtInpperiod1.Text
        End If
        If txtDlvperiod1.Text = "" Then
            DGV(4, DGV.RowCount - 2).Value = "0"
        Else
            DGV(4, DGV.RowCount - 2).Value = txtDlvperiod1.Text 'txtDlvperiod1.Text
        End If
        If txtInpperiod1.Text = "" Then
            DGV(5, DGV.RowCount - 2).Value = "0"
        Else
            DGV(5, DGV.RowCount - 2).Value = txtInpperiod1.Text 'txtInpperiod2.Text
        End If
        'txtDlvperiod1
        If txtDlvperiod2.Text = "" Then
            DGV(6, DGV.RowCount - 2).Value = "0"
        Else
            DGV(6, DGV.RowCount - 2).Value = txtDlvperiod2.Text 'txtDlvperiod2.Text
        End If
        If txtDlvperiod2.Text = "" Then
            DGV(7, DGV.RowCount - 2).Value = "0"
        Else
            DGV(7, DGV.RowCount - 2).Value = txtInpperiod2.Text 'txtInpperiod3.Text
        End If
        'txtDlvperiod2
        If txtDlvperiod3.Text = "" Then
            DGV(8, DGV.RowCount - 2).Value = "0"
        Else
            DGV(8, DGV.RowCount - 2).Value = txtDlvperiod3.Text 'txtDlvperiod3.Text
        End If
        If txtInpperiod3.Text = "" Then
            DGV(9, DGV.RowCount - 2).Value = "0"
        Else
            DGV(9, DGV.RowCount - 2).Value = txtInpperiod3.Text 'txtDlvperiod3.Text
        End If
        '
        'CariTgl = Format(DtpPickerawal.Value, "yyyy/MM/dd")
        'CariTgl = Format(DtpPickerawal.Value, "MM/dd/yyyy")
        '
        'CMD = New SqlCommand("Select * from sl_grey_request where plan_month = '" & (HasilPlantmonth) & "' and request_date ='" & (CariTgl) & "' and grey_no='" & (DGV.Rows(baris).Cells(0).Value) & "'", KonIstem)
        'DR = CMD.ExecuteReader
        'DR.Read()
        'If DR.HasRows Then
        '    MsgBox("Maaf Data barang Sudah ada ", vbInformation, "Informasi")
        '    Exit Sub
        'End If
        '
        Bersihtext()
        cmbGreyno.Focus()
        KonIstem.Close()
    End Sub
    Private Sub BtnKeluar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnKeluar.Click
        Bukakunci()
        BersihHeader()
        Bersihtext()
        Bersihtextdetil()
        '
        BtnTmbhDtl.Enabled = False
        BtnUbah_dtl.Enabled = False
        BtnDelete.Enabled = False
        BtnUpdateV.Enabled = False
        PnlPlandate.Visible = False
        '
        txtinp_awalTtl.Text = ""
        txtdlvdt1ttl.Text = ""
        txtinp_pr1dtTtl.Text = ""
        txtdlvdt2Ttl.Text = ""
        txtinp_pr2dtTtl.Text = ""
        txtdlvdt3Ttl.Text = ""
        txtinp_pr3dtTtl.Text = ""
        '
        txtRequestdate.Text = ""
        txtPlanMonth.Text = ""
        txtReqEdit.Text = ""
        cmbPlanMonth.Text = ""
        '
        Close()
    End Sub
    Private Sub BtnEditDetil_Click(ByVal sender As Object, ByVal e As EventArgs)
        frmGenerate_Plan.ShowDialog()
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnEdit.Click
        '
        StatusGrey()
        OptUbah.Checked = True
        GrpCtrDetil.Enabled = True
        TabControl1.SelectTab(1)
        Kunci()
        '
        BukaKunciDetil()
        StatusGrey()
        'KUNCI TAMBAHAN
        'BtnSave.Enabled = False
        BtnDeleteAll.Enabled = False
        cmbGreynoedit.Visible = True
        '
        BtnSave.Visible = False
        BtnSaveEdit.Visible = True
        '
        BtnSave.Visible = False
        BtnSaveEdit.Visible = True
        'BtnSave.Enabled = True
        '
        BtnSaveEdit.Enabled = True
        '
        DGV_edit2.ReadOnly = False
        'DGV_edit2.Columns(0).ReadOnly = True
        'DGV_edit2.Columns(1).ReadOnly = True
        'DGV_edit2.Columns(2).ReadOnly = True
        'DGV_edit2.Columns(3).ReadOnly = False
        'DGV_edit2.Columns(4).ReadOnly = False
        'DGV_edit2.Columns(5).ReadOnly = False
        'DGV_edit2.Columns(6).ReadOnly = False
        'DGV_edit2.Columns(7).ReadOnly = False
        'DGV_edit2.Columns(8).ReadOnly = False
        '
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnCancel.Click
        OptUbah.Checked = False
        Bersihtext()
        DGV.Rows.Clear()
        Bukakunci()
        BukaKunciDetil()
        '
        BtnTmbhDtl.Enabled = False
        BtnUbah_dtl.Enabled = False
        BtnDelete.Enabled = False
        BtnUpdateV.Enabled = False
        PnlPlandate.Visible = False
        '
        PnlEntry.Enabled = False
        BersihHeader()
        GrpCtrDetil.Enabled = False
        '
        BtnSetMdf_Click(sender, New System.EventArgs)
        '
        BtnSave.Visible = True
        BtnSave.Enabled = False
        BtnSaveEdit.Visible = False
        '
        DGV_edit2.ReadOnly = True
    End Sub

    Sub SimpanNewData()
        ' send_date dihilangkan,
        SimpanData = "Insert into sl_grey_request(plan_month,plan_rev_no,request_date,garment_flag,plan_rev_date,grey_no,item_category,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_input_qty,month1_deliv_qty,month2_from," _
                                & "month2_to,month2_input_qty,month2_deliv_qty,month3_from,month3_to,month3_input_qty,month3_deliv_qty,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
                                & "values(@plan_month,@plan_rev_no,@request_date,@garment_flag,@plan_rev_date,@grey_no,@item_category,@remain_date_from,@remain_date_to,@remain_input_qty,@month1_from,@month1_to,@month1_input_qty," _
                                & "@month1_deliv_qty,@month2_from,@month2_to,@month2_input_qty,@month2_deliv_qty,@month3_from,@month3_to,@month3_input_qty,@month3_deliv_qty,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"
    End Sub
    Sub SimpanEditData()
        'send date, hilang
        'plan_rev_no=@plan_rev_no,request_date=@request_date ada
        Ubahdata = "Update sl_grey_request set plan_month=@plan_month,item_category=@item_category,garment_flag=@garment_flag,grey_no=@grey_no,plan_rev_no=@plan_rev_no,request_date=@request_date,remain_input_qty=@remain_input_qty," _
                               & "month1_input_qty=@month1_input_qty,month1_deliv_qty=@month1_deliv_qty,month2_input_qty=@month2_input_qty," _
                               & "month2_deliv_qty=@month2_deliv_qty,month3_input_qty=@month3_input_qty,month3_deliv_qty=@month3_deliv_qty,rec_sts=@rec_sts,user_id=@user_id,proc_no=@proc_no,upd_date=@upd_date,upd_time=@upd_time,client_ip=@client_ip where plan_month=@plan_month and grey_no=@grey_no"
    End Sub
    Sub UbahHistori()
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            'SimpanDataHist = "Insert into sl_grey_request_hist(plan_month,plan_rev_no,request_date,item_category,garment_flag,plan_rev_date,grey_no,item_category,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_input_qty,month1_deliv_qty,month2_from," _
            '                      & "month2_to,month2_input_qty,month2_deliv_qty,month3_from,month3_to,month3_input_qty,month3_deliv_qty,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
            '                      & "values(@plan_month,@plan_rev_no,@request_date,@send_date,@garment_flag,@plan_rev_date,@grey_no,@item_category,@remain_date_from,@remain_date_to,@remain_input_qty,@month1_from,@month1_to,@month1_input_qty," _
            '                      & "@month1_deliv_qty,@month2_from,@month2_to,@month2_input_qty,@month2_deliv_qty,@month3_from,@month3_to,@month3_input_qty,@month3_deliv_qty,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"
            '
            SimpanDataHist = "Insert into sl_grey_request_hist(plan_month,plan_rev_no,request_date,garment_flag,plan_rev_date,grey_no,item_category,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_input_qty,month1_deliv_qty,month2_from," _
                               & "month2_to,month2_input_qty,month2_deliv_qty,month3_from,month3_to,month3_input_qty,month3_deliv_qty,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
                               & "values(@plan_month,@plan_rev_no,@request_date,@garment_flag,@plan_rev_date,@grey_no,@item_category,@remain_date_from,@remain_date_to,@remain_input_qty,@month1_from,@month1_to,@month1_input_qty," _
                               & "@month1_deliv_qty,@month2_from,@month2_to,@month2_input_qty,@month2_deliv_qty,@month3_from,@month3_to,@month3_input_qty,@month3_deliv_qty,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"
            'SimpanNewData()
            Dim CMDHistori As New SqlCommand(SimpanDataHist, KonIstem)
            Dim i As Integer
            i = DGV_edit2.CurrentRow.Index
            '
            CMDHistori.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
            CMDHistori.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@item_category", SqlDbType.Char))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@garment_flag", SqlDbType.Char))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
            'CMDHistori.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            CMDHistori.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
            '
            KonIstem.Open()
            TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
            CMDHistori.Transaction = TR
            '
            Try
                'For Each row As DataGridViewRow In DGV.Rows
                'If Not row.IsNewRow Then
                ' lblTglAwal.Text
                CMDHistori.Parameters("@plan_month").Value = HasilPlantmonth
                CMDHistori.Parameters("@request_date").Value = Convert.ToDateTime(lblRemindfrmperiodawal)
                '
                CMDHistori.Parameters("@item_category").Value = DGV_edit2.Item(0, i).Value 'row.Cells(0).Value.ToString
                CMDHistori.Parameters("@grey_no").Value = DGV_edit2.Item(1, i).Value 'DGV.Rows(i).Cells(0).FormattedValue
                CMDHistori.Parameters("@garment_flag").Value = DGV_edit2.Item(2, i).Value 'DGV.Rows(i).Cells(0).FormattedValue
                CMDHistori.Parameters("@remain_input_qty").Value = DGV_edit2.Item(3, i).Value 'row.Cells(3).Value.ToString 'DGV.Rows(i).Cells(1).FormattedValue
                CMDHistori.Parameters("@remain_date_from").Value = Convert.ToDateTime(lblRemindfrmperiodawal)
                CMDHistori.Parameters("@remain_date_to").Value = Convert.ToDateTime(lblRemindtoperiodawal)
                ''
                CMDHistori.Parameters("@month1_from").Value = Convert.ToDateTime(lblRemindfrmperiod1)
                CMDHistori.Parameters("@month1_to").Value = Convert.ToDateTime(lblRemindtoperiod1)
                CMDHistori.Parameters("@month1_deliv_qty").Value = DGV_edit2.Item(4, i).Value 'DGV.Rows(i).Cells(2).FormattedValue
                CMDHistori.Parameters("@month1_input_qty").Value = DGV_edit2.Item(5, i).Value 'DGV.Rows(i).Cells(3).FormattedValue
                '
                CMDHistori.Parameters("@month2_from").Value = Convert.ToDateTime(lblRemindfrmperiod2)
                CMDHistori.Parameters("@month2_to").Value = Convert.ToDateTime(lblRemindtoperiod2)
                CMDHistori.Parameters("@month2_deliv_qty").Value = DGV_edit2.Item(6, i).Value 'DGV.Rows(i).Cells(4).FormattedValue
                CMDHistori.Parameters("@month2_input_qty").Value = DGV_edit2.Item(7, i).Value 'DGV.Rows(i).Cells(5).FormattedValue
                '
                CMDHistori.Parameters("@month3_from").Value = Convert.ToDateTime(lblRemindfrmperiod3)
                CMDHistori.Parameters("@month3_to").Value = Convert.ToDateTime(lblRemindtoperiod3)
                CMDHistori.Parameters("@month3_deliv_qty").Value = DGV_edit2.Item(8, i).Value 'DGV.Rows(i).Cells(6).FormattedValue
                CMDHistori.Parameters("@month3_input_qty").Value = DGV_edit2.Item(9, i).Value 'DGV.Rows(i).Cells(7).FormattedValue
                '
                CMDHistori.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                CMDHistori.Parameters("@rec_sts").Value = "T"
                '
                CMDHistori.Parameters("@plan_rev_no").Value = "0"
                CMDHistori.Parameters("@plan_rev_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                ' CMDSimpan.Parameters("@send_date").Value = Convert.ToDateTime("")
                '
                CMDHistori.Parameters("@proc_no").Value = "2"
                CMDHistori.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                CMDHistori.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                CMDHistori.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                '
                CMDHistori.ExecuteNonQuery()
                TR.Commit()
                'MessageBox.Show("Data Berhasil Di Simpan", "Informasi")
                '
                'End If
                'Next
            Catch ex As Exception
                Try
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                Catch rollBackEx As Exception
                    MessageBox.Show(rollBackEx.Message)
                End Try
            End Try
        End Using
    End Sub
    Sub HapusHistori1()
        Dim x As Integer
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            'SimpanDataHist = "Insert into sl_grey_request_hist(plan_month,plan_rev_no,request_date,garment_flag,plan_rev_date,grey_no,item_category,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_input_qty,month1_deliv_qty,month2_from," _
            '                    & "month2_to,month2_input_qty,month2_deliv_qty,month3_from,month3_to,month3_input_qty,month3_deliv_qty,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
            '                    & "values(@plan_month,@plan_rev_no,@request_date,@garment_flag,@plan_rev_date,@grey_no,@item_category,@remain_date_from,@remain_date_to,@remain_input_qty,@month1_from,@month1_to,@month1_input_qty," _
            '                    & "@month1_deliv_qty,@month2_from,@month2_to,@month2_input_qty,@month2_deliv_qty,@month3_from,@month3_to,@month3_input_qty,@month3_deliv_qty,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"
            SimpanDataHist = "Insert into sl_grey_request_hist(plan_month,plan_rev_no,request_date,garment_flag,plan_rev_date,grey_no,item_category,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_input_qty,month1_deliv_qty,month2_from," _
                              & "month2_to,month2_input_qty,month2_deliv_qty,month3_from,month3_to,month3_input_qty,month3_deliv_qty,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
                              & "values(@plan_month,@plan_rev_no,@request_date,@garment_flag,@plan_rev_date,@grey_no,@item_category,@remain_date_from,@remain_date_to,@remain_input_qty,@month1_from,@month1_to,@month1_input_qty," _
                              & "@month1_deliv_qty,@month2_from,@month2_to,@month2_input_qty,@month2_deliv_qty,@month3_from,@month3_to,@month3_input_qty,@month3_deliv_qty,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"

            'item_category
            Dim CMDHistori As New SqlCommand(SimpanDataHist, KonIstem)
            x = DGV_edit2.CurrentRow.Index
            CMDHistori.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
            CMDHistori.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@item_category", SqlDbType.Char))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@garment_flag", SqlDbType.Char))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
            ''
            CMDHistori.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
            ''
            CMDHistori.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
            'CMDHistori.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            CMDHistori.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
            '
            KonIstem.Open()
            TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
            CMDHistori.Transaction = TR
            '
            Try
                'For Each row As DataGridViewRow In DGV.Rows
                '    If Not row.IsNewRow Then
                ' For i = 0 To 2
                ' lblTglAwal.Text
                CMDHistori.Parameters("@plan_month").Value = HasilPlantmonth
                CMDHistori.Parameters("@request_date").Value = Convert.ToDateTime(lblRemindfrmperiodawal)
                '
                CMDHistori.Parameters("@item_category").Value = DGV_edit2.Item(0, x).Value 'row.Cells(0).Value.ToString
                CMDHistori.Parameters("@grey_no").Value = DGV_edit2.Item(1, x).Value 'row.Cells(1).Value.ToString 'DGV.Rows(i).Cells(0).FormattedValue
                CMDHistori.Parameters("@garment_flag").Value = DGV_edit2.Item(2, x).Value 'row.Cells(2).Value.ToString 'DGV.Rows(i).Cells(0).FormattedValue
                CMDHistori.Parameters("@remain_input_qty").Value = DGV_edit2.Item(3, x).Value 'row.Cells(3).Value.ToString 'DGV.Rows(i).Cells(1).FormattedValue
                CMDHistori.Parameters("@remain_date_from").Value = Convert.ToDateTime(lblRemindfrmperiodawal)
                CMDHistori.Parameters("@remain_date_to").Value = Convert.ToDateTime(lblRemindtoperiodawal)
                ''
                CMDHistori.Parameters("@month1_from").Value = Convert.ToDateTime(lblRemindfrmperiod1)
                CMDHistori.Parameters("@month1_to").Value = Convert.ToDateTime(lblRemindtoperiod1)
                CMDHistori.Parameters("@month1_deliv_qty").Value = DGV_edit2.Item(4, x).Value 'row.Cells(4).Value.ToString 'DGV.Rows(i).Cells(2).FormattedValue
                CMDHistori.Parameters("@month1_input_qty").Value = DGV_edit2.Item(5, x).Value 'row.Cells(5).Value.ToString 'DGV.Rows(i).Cells(3).FormattedValue
                '
                CMDHistori.Parameters("@month2_from").Value = Convert.ToDateTime(lblRemindfrmperiod2)
                CMDHistori.Parameters("@month2_to").Value = Convert.ToDateTime(lblRemindtoperiod2)
                CMDHistori.Parameters("@month2_deliv_qty").Value = DGV_edit2.Item(6, x).Value 'row.Cells(6).Value.ToString 'DGV.Rows(i).Cells(4).FormattedValue
                CMDHistori.Parameters("@month2_input_qty").Value = DGV_edit2.Item(7, x).Value 'row.Cells(7).Value.ToString 'DGV.Rows(i).Cells(5).FormattedValue
                '
                CMDHistori.Parameters("@month3_from").Value = Convert.ToDateTime(lblRemindfrmperiod3)
                CMDHistori.Parameters("@month3_to").Value = Convert.ToDateTime(lblRemindtoperiod3)
                CMDHistori.Parameters("@month3_deliv_qty").Value = DGV_edit2.Item(8, x).Value 'row.Cells(8).Value.ToString 'DGV.Rows(i).Cells(6).FormattedValue
                CMDHistori.Parameters("@month3_input_qty").Value = DGV_edit2.Item(9, x).Value 'row.Cells(9).Value.ToString 'DGV.Rows(i).Cells(7).FormattedValue
                '
                CMDHistori.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                'If i = 1 Then
                CMDHistori.Parameters("@rec_sts").Value = "T"
                'Else
                'CMDHistori.Parameters("@rec_sts").Value = "C"
                'End If
                '
                CMDHistori.Parameters("@plan_rev_no").Value = "0"
                CMDHistori.Parameters("@plan_rev_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                'CMDSimpan.Parameters("@send_date").Value = Convert.ToDateTime("")
                '
                'If i = 1 Then
                CMDHistori.Parameters("@proc_no").Value = "2"
                'Else
                'CMDHistori.Parameters("@proc_no").Value = "3"
                'End If
                '
                CMDHistori.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                CMDHistori.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                CMDHistori.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                '
                CMDHistori.ExecuteNonQuery()
                TR.Commit()
                'Next
                '
            Catch ex As Exception
                Try
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                Catch rollBackEx As Exception
                    MessageBox.Show(rollBackEx.Message)
                End Try
            End Try
        End Using
    End Sub
    Sub HapusHistori2()
        Dim x As Integer
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            'SimpanDataHist = "Insert into sl_grey_request_hist(plan_month,plan_rev_no,request_date,garment_flag,plan_rev_date,grey_no,item_category,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_input_qty,month1_deliv_qty,month2_from," _
            '                    & "month2_to,month2_input_qty,month2_deliv_qty,month3_from,month3_to,month3_input_qty,month3_deliv_qty,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
            '                    & "values(@plan_month,@plan_rev_no,@request_date,@garment_flag,@plan_rev_date,@grey_no,@item_category,@remain_date_from,@remain_date_to,@remain_input_qty,@month1_from,@month1_to,@month1_input_qty," _
            '                    & "@month1_deliv_qty,@month2_from,@month2_to,@month2_input_qty,@month2_deliv_qty,@month3_from,@month3_to,@month3_input_qty,@month3_deliv_qty,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"
            SimpanDataHist = "Insert into sl_grey_request_hist(plan_month,plan_rev_no,request_date,garment_flag,plan_rev_date,grey_no,item_category,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_input_qty,month1_deliv_qty,month2_from," _
                              & "month2_to,month2_input_qty,month2_deliv_qty,month3_from,month3_to,month3_input_qty,month3_deliv_qty,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
                              & "values(@plan_month,@plan_rev_no,@request_date,@garment_flag,@plan_rev_date,@grey_no,@item_category,@remain_date_from,@remain_date_to,@remain_input_qty,@month1_from,@month1_to,@month1_input_qty," _
                              & "@month1_deliv_qty,@month2_from,@month2_to,@month2_input_qty,@month2_deliv_qty,@month3_from,@month3_to,@month3_input_qty,@month3_deliv_qty,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"

            'item_category
            Dim CMDHistori As New SqlCommand(SimpanDataHist, KonIstem)
            x = DGV_edit2.CurrentRow.Index
            CMDHistori.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
            CMDHistori.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@item_category", SqlDbType.Char))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@garment_flag", SqlDbType.Char))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
            ''
            CMDHistori.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
            ''
            CMDHistori.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
            'CMDHistori.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            CMDHistori.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
            '
            KonIstem.Open()
            TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
            CMDHistori.Transaction = TR
            '
            Try
                'For Each row As DataGridViewRow In DGV.Rows
                '    If Not row.IsNewRow Then
                'For i = 0 To 2
                ' lblTglAwal.Text
                CMDHistori.Parameters("@plan_month").Value = HasilPlantmonth
                CMDHistori.Parameters("@request_date").Value = Convert.ToDateTime(lblRemindfrmperiodawal)
                '
                CMDHistori.Parameters("@item_category").Value = DGV_edit2.Item(0, x).Value 'row.Cells(0).Value.ToString
                CMDHistori.Parameters("@grey_no").Value = DGV_edit2.Item(1, x).Value 'row.Cells(1).Value.ToString 'DGV.Rows(i).Cells(0).FormattedValue
                CMDHistori.Parameters("@garment_flag").Value = DGV_edit2.Item(2, x).Value 'row.Cells(2).Value.ToString 'DGV.Rows(i).Cells(0).FormattedValue
                CMDHistori.Parameters("@remain_input_qty").Value = DGV_edit2.Item(3, x).Value 'row.Cells(3).Value.ToString 'DGV.Rows(i).Cells(1).FormattedValue
                CMDHistori.Parameters("@remain_date_from").Value = Convert.ToDateTime(lblRemindfrmperiodawal)
                CMDHistori.Parameters("@remain_date_to").Value = Convert.ToDateTime(lblRemindtoperiodawal)
                ''
                CMDHistori.Parameters("@month1_from").Value = Convert.ToDateTime(lblRemindfrmperiod1)
                CMDHistori.Parameters("@month1_to").Value = Convert.ToDateTime(lblRemindtoperiod1)
                CMDHistori.Parameters("@month1_deliv_qty").Value = DGV_edit2.Item(4, x).Value 'row.Cells(4).Value.ToString 'DGV.Rows(i).Cells(2).FormattedValue
                CMDHistori.Parameters("@month1_input_qty").Value = DGV_edit2.Item(5, x).Value 'row.Cells(5).Value.ToString 'DGV.Rows(i).Cells(3).FormattedValue
                '
                CMDHistori.Parameters("@month2_from").Value = Convert.ToDateTime(lblRemindfrmperiod2)
                CMDHistori.Parameters("@month2_to").Value = Convert.ToDateTime(lblRemindtoperiod2)
                CMDHistori.Parameters("@month2_deliv_qty").Value = DGV_edit2.Item(6, x).Value 'row.Cells(6).Value.ToString 'DGV.Rows(i).Cells(4).FormattedValue
                CMDHistori.Parameters("@month2_input_qty").Value = DGV_edit2.Item(7, x).Value 'row.Cells(7).Value.ToString 'DGV.Rows(i).Cells(5).FormattedValue
                '
                CMDHistori.Parameters("@month3_from").Value = Convert.ToDateTime(lblRemindfrmperiod3)
                CMDHistori.Parameters("@month3_to").Value = Convert.ToDateTime(lblRemindtoperiod3)
                CMDHistori.Parameters("@month3_deliv_qty").Value = DGV_edit2.Item(8, x).Value 'row.Cells(8).Value.ToString 'DGV.Rows(i).Cells(6).FormattedValue
                CMDHistori.Parameters("@month3_input_qty").Value = DGV_edit2.Item(9, x).Value 'row.Cells(9).Value.ToString 'DGV.Rows(i).Cells(7).FormattedValue
                '
                CMDHistori.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                'If i = 1 Then
                '    CMDHistori.Parameters("@rec_sts").Value = "T"
                'Else
                CMDHistori.Parameters("@rec_sts").Value = "C"
                'End If
                '
                CMDHistori.Parameters("@plan_rev_no").Value = "0"
                CMDHistori.Parameters("@plan_rev_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                'CMDSimpan.Parameters("@send_date").Value = Convert.ToDateTime("")
                '
                'If i = 1 Then
                '    CMDHistori.Parameters("@proc_no").Value = "2"
                'Else
                CMDHistori.Parameters("@proc_no").Value = "3"
                'End If
                '
                CMDHistori.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                CMDHistori.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                CMDHistori.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                '
                CMDHistori.ExecuteNonQuery()
                TR.Commit()
                'Next
                '
            Catch ex As Exception
                Try
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                Catch rollBackEx As Exception
                    MessageBox.Show(rollBackEx.Message)
                End Try
            End Try
        End Using
    End Sub
    Sub SimpanHistori()
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            'SimpanDataHist = "Insert into sl_grey_request_hist(plan_month,plan_rev_no,request_date,garment_flag,plan_rev_date,grey_no,item_category,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_input_qty,month1_deliv_qty,month2_from," _
            '            & "month2_to,month2_input_qty,month2_deliv_qty,month3_from,month3_to,month3_input_qty,month3_deliv_qty,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
            '            & "values(@plan_month,@plan_rev_no,@request_date,@garment_flag,@plan_rev_date,@grey_no,@item_category,@remain_date_from,@remain_date_to,@remain_input_qty,@month1_from,@month1_to,@month1_input_qty," _
            '            & "@month1_deliv_qty,@month2_from,@month2_to,@month2_input_qty,@month2_deliv_qty,@month3_from,@month3_to,@month3_input_qty,@month3_deliv_qty,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"
            '
            SimpanDataHist = "Insert into sl_grey_request_hist(plan_month,plan_rev_no,request_date,garment_flag,plan_rev_date,grey_no,item_category,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_input_qty,month1_deliv_qty,month2_from," _
                               & "month2_to,month2_input_qty,month2_deliv_qty,month3_from,month3_to,month3_input_qty,month3_deliv_qty,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
                               & "values(@plan_month,@plan_rev_no,@request_date,@garment_flag,@plan_rev_date,@grey_no,@item_category,@remain_date_from,@remain_date_to,@remain_input_qty,@month1_from,@month1_to,@month1_input_qty," _
                               & "@month1_deliv_qty,@month2_from,@month2_to,@month2_input_qty,@month2_deliv_qty,@month3_from,@month3_to,@month3_input_qty,@month3_deliv_qty,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"

            Dim CMDHistori As New SqlCommand(SimpanDataHist, KonIstem)
            'item_category
            CMDHistori.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
            CMDHistori.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@item_category", SqlDbType.Char))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@garment_flag", SqlDbType.Char))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
            ''
            CMDHistori.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
            ''
            CMDHistori.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
            CMDHistori.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
            'CMDHistori.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            '
            CMDHistori.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            CMDHistori.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
            CMDHistori.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
            CMDHistori.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
            '
            KonIstem.Open()
            TRHist = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
            CMDHistori.Transaction = TRHist
            '
            Try
                For Each row As DataGridViewRow In DGV.Rows
                    If Not row.IsNewRow Then
                        CMDHistori.Parameters("@plan_month").Value = HasilPlantmonth
                        CMDHistori.Parameters("@request_date").Value = Convert.ToDateTime(lblRemindfrmperiodawal)
                        '
                        CMDHistori.Parameters("@item_category").Value = row.Cells(0).Value.ToString
                        CMDHistori.Parameters("@grey_no").Value = row.Cells(1).Value.ToString 'DGV.Rows(i).Cells(0).FormattedValue
                        CMDHistori.Parameters("@garment_flag").Value = row.Cells(2).Value.ToString 'DGV.Rows(i).Cells(0).FormattedValue
                        CMDHistori.Parameters("@remain_input_qty").Value = row.Cells(3).Value.ToString 'DGV.Rows(i).Cells(1).FormattedValue
                        CMDHistori.Parameters("@remain_date_from").Value = Convert.ToDateTime(lblRemindfrmperiodawal)
                        CMDHistori.Parameters("@remain_date_to").Value = Convert.ToDateTime(lblRemindtoperiodawal)
                        ''
                        CMDHistori.Parameters("@month1_from").Value = Convert.ToDateTime(lblRemindfrmperiod1)
                        CMDHistori.Parameters("@month1_to").Value = Convert.ToDateTime(lblRemindtoperiod1)
                        CMDHistori.Parameters("@month1_deliv_qty").Value = row.Cells(4).Value.ToString 'DGV.Rows(i).Cells(2).FormattedValue
                        CMDHistori.Parameters("@month1_input_qty").Value = row.Cells(5).Value.ToString 'DGV.Rows(i).Cells(3).FormattedValue
                        '
                        CMDHistori.Parameters("@month2_from").Value = Convert.ToDateTime(lblRemindfrmperiod2)
                        CMDHistori.Parameters("@month2_to").Value = Convert.ToDateTime(lblRemindtoperiod2)
                        CMDHistori.Parameters("@month2_deliv_qty").Value = row.Cells(6).Value.ToString 'DGV.Rows(i).Cells(4).FormattedValue
                        CMDHistori.Parameters("@month2_input_qty").Value = row.Cells(7).Value.ToString 'DGV.Rows(i).Cells(5).FormattedValue
                        '
                        CMDHistori.Parameters("@month3_from").Value = Convert.ToDateTime(lblRemindfrmperiod3)
                        CMDHistori.Parameters("@month3_to").Value = Convert.ToDateTime(lblRemindtoperiod3)
                        CMDHistori.Parameters("@month3_deliv_qty").Value = row.Cells(8).Value.ToString 'DGV.Rows(i).Cells(6).FormattedValue
                        CMDHistori.Parameters("@month3_input_qty").Value = row.Cells(9).Value.ToString 'DGV.Rows(i).Cells(7).FormattedValue
                        '
                        CMDHistori.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                        CMDHistori.Parameters("@rec_sts").Value = "A"
                        '
                        CMDHistori.Parameters("@plan_rev_no").Value = "0"
                        CMDHistori.Parameters("@plan_rev_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                        ' CMDSimpan.Parameters("@send_date").Value = Convert.ToDateTime("")
                        '
                        CMDHistori.Parameters("@proc_no").Value = "1"
                        CMDHistori.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                        CMDHistori.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                        CMDHistori.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                        CMDHistori.ExecuteNonQuery()
                        'TRHist.Commit()
                    End If
                Next
                TRHist.Commit()
            Catch ex As Exception
                Try
                    TRHist.Rollback()
                    MessageBox.Show(ex.Message)
                Catch rollBackEx As Exception
                    MessageBox.Show(rollBackEx.Message)
                End Try
            End Try
        End Using
    End Sub
    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnSave.Click
        Dim Mfrawal, Mtoawal, MfrMt1, MtoMt1, MfrMt2, MtoMt2, MfrMt3, MtoMt3 As Date
        'lblRemindfrmperiodawal,lblRemindtoperiodawal,lblRemindfrmperiod1,lblRemindfrmperiod1,lblRemindfrmperiod2,lblRemindtoperiod2,lblRemindfrmperiod3,lblRemindtoperiod3

        Using KonIstem As New SqlConnection(ConStringISTEM)
            If MessageBox.Show("Yakin akan di Simpan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                If OptUbah.Checked = False Then
                    SimpanNewData()
                    Dim CMDSimpan As New SqlCommand(SimpanData, KonIstem)
                    '
                    lblUpdateV.Text = HasilPlantmonth
                    'CmdSimpanNewData()
                    '
                    CMDSimpan.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                    CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
                    CMDSimpan.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@item_category", SqlDbType.Char))
                    '
                    CMDSimpan.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
                    CMDSimpan.Parameters.Add(New SqlParameter("@garment_flag", SqlDbType.Char))
                    CMDSimpan.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
                    CMDSimpan.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
                    ''
                    CMDSimpan.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
                    '
                    CMDSimpan.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
                    ''
                    CMDSimpan.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
                    'CMDSimpan.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
                    '
                    CMDSimpan.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
                    CMDSimpan.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                    '
                    CMDSimpan.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                    CMDSimpan.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
                    CMDSimpan.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
                    '
                    KonIstem.Open()
                    TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
                    CMDSimpan.Transaction = TR
                    'lblRemindfrmperiodawal,lblRemindfrmperiodawal,lblRemindtoperiodawal,lblRemindfrmperiod1,lblRemindfrmperiod1,lblRemindfrmperiod2,lblRemindtoperiod2,lblRemindfrmperiod3,lblRemindtoperiod3
                    '
                    'Mfrawal, Mtoawal, MfrMt1, MtoMt1, MfrMt2, MtoMt2, MfrMt3, MtoMt3 As Date
                    Mfrawal = lblRemindfrmperiodawal
                    Mtoawal = lblRemindtoperiodawal
                    MfrMt1 = lblRemindfrmperiod1
                    MtoMt1 = lblRemindtoperiod1
                    MfrMt2 = lblRemindfrmperiod2
                    MtoMt2 = lblRemindtoperiod2
                    MfrMt3 = lblRemindfrmperiod3
                    MtoMt3 = lblRemindtoperiod3
                    '
                    Try
                        For Each row As DataGridViewRow In DGV.Rows
                            If Not row.IsNewRow Then
                                ' lblTglAwal.Text,
                                CMDSimpan.Parameters("@plan_month").Value = HasilPlantmonth
                                CMDSimpan.Parameters("@request_date").Value = Mfrawal 'Convert.ToDateTime(lblRemindfrmperiodawal)
                                '
                                CMDSimpan.Parameters("@item_category").Value = row.Cells(0).Value.ToString
                                CMDSimpan.Parameters("@grey_no").Value = row.Cells(1).Value.ToString 'DGV.Rows(i).Cells(0).FormattedValue
                                CMDSimpan.Parameters("@garment_flag").Value = row.Cells(2).Value.ToString 'DGV.Rows(i).Cells(0).FormattedValue
                                CMDSimpan.Parameters("@remain_input_qty").Value = row.Cells(3).Value.ToString 'DGV.Rows(i).Cells(1).FormattedValue
                                CMDSimpan.Parameters("@remain_date_from").Value = Mfrawal 'Convert.ToDateTime(lblRemindfrmperiodawal)
                                CMDSimpan.Parameters("@remain_date_to").Value = Mtoawal 'Convert.ToDateTime(lblRemindtoperiodawal)
                                ''
                                CMDSimpan.Parameters("@month1_from").Value = MfrMt1 'Convert.ToDateTime(lblRemindfrmperiod1)
                                CMDSimpan.Parameters("@month1_to").Value = MtoMt1 'Convert.ToDateTime(lblRemindtoperiod1)
                                CMDSimpan.Parameters("@month1_deliv_qty").Value = row.Cells(4).Value.ToString 'DGV.Rows(i).Cells(2).FormattedValue
                                CMDSimpan.Parameters("@month1_input_qty").Value = row.Cells(5).Value.ToString 'DGV.Rows(i).Cells(3).FormattedValue
                                '
                                CMDSimpan.Parameters("@month2_from").Value = MfrMt2 'Convert.ToDateTime(lblRemindfrmperiod2)
                                CMDSimpan.Parameters("@month2_to").Value = MtoMt2 'Convert.ToDateTime(lblRemindtoperiod2)
                                CMDSimpan.Parameters("@month2_deliv_qty").Value = row.Cells(6).Value.ToString 'DGV.Rows(i).Cells(4).FormattedValue
                                CMDSimpan.Parameters("@month2_input_qty").Value = row.Cells(7).Value.ToString 'DGV.Rows(i).Cells(5).FormattedValue
                                '
                                CMDSimpan.Parameters("@month3_from").Value = MfrMt3 'Convert.ToDateTime(lblRemindfrmperiod3)
                                CMDSimpan.Parameters("@month3_to").Value = MtoMt3 'Convert.ToDateTime(lblRemindtoperiod3)
                                CMDSimpan.Parameters("@month3_deliv_qty").Value = row.Cells(8).Value.ToString 'DGV.Rows(i).Cells(6).FormattedValue
                                CMDSimpan.Parameters("@month3_input_qty").Value = row.Cells(9).Value.ToString 'DGV.Rows(i).Cells(7).FormattedValue
                                '
                                CMDSimpan.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                                CMDSimpan.Parameters("@rec_sts").Value = "A"
                                '
                                CMDSimpan.Parameters("@plan_rev_no").Value = "0"
                                CMDSimpan.Parameters("@plan_rev_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                                ' CMDSimpan.Parameters("@send_date").Value = Convert.ToDateTime("")
                                '
                                CMDSimpan.Parameters("@proc_no").Value = "1"
                                CMDSimpan.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                                CMDSimpan.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                                CMDSimpan.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                                '
                                CMDSimpan.ExecuteNonQuery()
                                'TR.Commit()
                            End If
                        Next
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
                    SimpanHistori()
                End If
            End If
        End Using
        '
        SortData()
        DGV.Rows.Clear()
        BersihHeader()
        Bukakunci()
        BukaKunciDetil()
        Bersihtext()
        '
        BtnTmbhDtl.Enabled = False
        BtnUbah_dtl.Enabled = False
        BtnDelete.Enabled = False
        BtnUpdateV.Enabled = False
        PnlPlandate.Visible = False
        '
    End Sub
    Private Sub BtnSaveEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveEdit.Click
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            If MessageBox.Show("Yakin akan di Simpan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                For Each row As DataGridViewRow In DGV_edit2.Rows
                    If Not row.IsNewRow Then
                        '
                        Ktgri = row.Cells(0).Value.ToString()
                        txtGreyNo.Text = row.Cells(1).Value.ToString
                        StsGf = row.Cells(2).Value.ToString
                        RMD2 = row.Cells(3).Value.ToString()
                        Mt1dv = row.Cells(4).Value.ToString()
                        Mt1ip = row.Cells(5).Value.ToString()
                        Mt2dv = row.Cells(6).Value.ToString()
                        Mt2ip = row.Cells(7).Value.ToString()
                        Mt3dv = row.Cells(8).Value.ToString()
                        Mt3ip = row.Cells(9).Value.ToString()
                    End If
                    '
                    CekInputData()
                    '
                    If TambahDetil = True Then
                        BtnTambahEdit_Click(sender, New System.EventArgs)
                    Else 'Ubah
                        SimpanEditData()
                        KonIstem.Close()
                        BtnUbahEdit_Click(sender, New System.EventArgs)
                    End If
                Next
                MessageBox.Show("Data Berhasil Disimpan", "Informasi")
            End If
            KonIstem.Close()
        End Using
        '
        SortData()
        BersihHeader()
        Bukakunci()
        BukaKunciDetil()
        Bersihtext()
        '
        BtnSave.Visible = True
        BtnSave.Enabled = False
        '
        BtnSaveEdit.Visible = False
        BtnSaveEdit.Enabled = False
        '
        BtnTmbhDtl.Enabled = False
        BtnUbah_dtl.Enabled = False
        BtnDelete.Enabled = False
        BtnUpdateV.Enabled = False
        PnlPlandate.Visible = False
        '
        DGV_edit2.ReadOnly = True
    End Sub
    Sub CekInputData()
        KoneksiISTEM()
        KonIstem.Open()
        '
        TxtHasilModif.Text = cmbPlanMonth.Text
        HasilPlantmonth = cmbPlanMonth.Text
        Try
            CmdCaridata = New SqlCommand("Select plan_month,send_date,grey_no,remain_input_qty,month1_deliv_qty,month1_input_qty,month2_deliv_qty,month2_input_qty,month3_deliv_qty,month3_input_qty from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "' and grey_no = '" & (txtGreyNo.Text) & "'", KonIstem)
            DREDIT = CmdCaridata.ExecuteReader
            DREDIT.Read()
            'KonIstem.Close()
            'send_date
            If DREDIT.HasRows Then
                TambahDetil = False
                lblip1edit.Text = DREDIT.Item("remain_input_qty")
                lblMont1dvedit.Text = DREDIT.Item("month1_deliv_qty")
                lblMont1ipedit.Text = DREDIT.Item("month1_input_qty")
                lblMont2dvedit.Text = DREDIT.Item("month2_deliv_qty")
                lblMont2dvip.Text = DREDIT.Item("month2_input_qty")
                lblMont3dvedit.Text = DREDIT.Item("month3_deliv_qty")
                lblMont3ipedit.Text = DREDIT.Item("month3_input_qty")
                lblStatusSend.Text = DREDIT.Item("send_date")
            Else
                TambahDetil = True
            End If
            KonIstem.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CekHapusbaris()
        Dim x As Integer
        KoneksiISTEM()
        KonIstem.Open()
        '
        TxtHasilModif.Text = cmbPlanMonth.Text
        HasilPlantmonth = cmbPlanMonth.Text
        x = DGV_edit2.CurrentRow.Index
        Try
            CmdCaridata = New SqlCommand("Select plan_month,grey_no,remain_input_qty,month1_deliv_qty,month1_input_qty,month2_deliv_qty,month2_input_qty,month3_deliv_qty,month3_input_qty from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "' and grey_no = '" & DGV_edit2.Item(1, x).Value & "'", KonIstem)
            DREDIT = CmdCaridata.ExecuteReader
            DREDIT.Read()
            'KonIstem.Close()
            If DREDIT.HasRows Then
                Hapusbaris = False
            Else
                Hapusbaris = True
            End If
            KonIstem.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CekStatusDetil()
        'Dim StsRm, StM1dv, StM1ip, StM2dv, StM2ip, StM3dv, StM3ip As String
        ''If lblip1edit.Text = DGV_edit2 Then
        'If CInt(lblip1edit.Text) <> RMD2 Then
        '    StsRm = "T"
        '    TambahDetil = False
        '    UbahDetil = True
        'End If
        ''
        'If CInt(lblMont1dvedit.Text) <> Mt1dv Then
        '    StM1dv = "T"
        '    TambahDetil = False
        '    UbahDetil = True
        'End If
        ''
        'If CInt(lblMont1ipedit.Text) <> Mt1ip Then
        '    StM1ip = "T"
        '    TambahDetil = False
        '    UbahDetil = True
        'End If
        ''
        'If CInt(lblMont2dvedit.Text) <> Mt2dv Then
        '    StM2dv = "T"
        '    TambahDetil = False
        '    UbahDetil = True
        'End If
        'If CInt(lblMont2dvip.Text) <> Mt2ip Then
        '    StM2ip = "T"
        '    TambahDetil = False
        '    UbahDetil = True
        'End If
        'If CInt(lblMont3dvedit.Text) <> Mt3dv Then
        '    StM3dv = "T"
        '    TambahDetil = False
        '    UbahDetil = True
        'End If
        'If CInt(lblMont3ipedit.Text) <> Mt3ip Then
        '    StM3ip = "T"
        '    TambahDetil = False
        '    UbahDetil = True
        'End If
    End Sub
    Sub WVMTR()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        If OptUbah.Checked = False Then
            cmbGreyno.Items.Clear()
            CMD = New SqlCommand(WVMasterTR, KonIstem)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cmbGreyno.Items.Add(DR.Item(0))
            Loop
        Else
            cmbGreynoedit.Items.Clear()
            CMD = New SqlCommand(WVMasterTR, KonIstem)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cmbGreynoedit.Items.Add(DR.Item(0))
            Loop
        End If
        KonIstem.Close()
    End Sub
    Sub WVMSP()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        If OptUbah.Checked = False Then
            cmbGreyno.Items.Clear()
            ' WVMasterSP = "Select [grey_no],item_category where item_category='SP' FROM wv_fabric_analysis_master"
            CMD = New SqlCommand(WVMasterSP, KonIstem)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cmbGreyno.Items.Add(DR.Item(0))
            Loop
        Else
            cmbGreynoedit.Items.Clear()
            ' WVMasterSP = "Select [grey_no],item_category where item_category='SP' FROM wv_fabric_analysis_master"
            CMD = New SqlCommand(WVMasterSP, KonIstem)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cmbGreynoedit.Items.Add(DR.Item(0))
            Loop
        End If
        KonIstem.Close()
    End Sub
    Sub WVMALL()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        If OptUbah.Checked = False Then
            cmbGreyno.Items.Clear()
            'WVMaster = "Select [grey_no],item_category where item_category= 'SP', FROM wv_fabric_analysis_master"
            CMD = New SqlCommand(WVMaster, KonIstem)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cmbGreyno.Items.Add(DR.Item(0))
            Loop
        Else
            cmbGreynoedit.Items.Clear()
            'WVMaster = "Select [grey_no],item_category where item_category= 'SP', FROM wv_fabric_analysis_master"
            CMD = New SqlCommand(WVMaster, KonIstem)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cmbGreynoedit.Items.Add(DR.Item(0))
            Loop
        End If
        KonIstem.Close()
    End Sub
    Private Sub OptTR_CheckedChanged(sender As Object, e As EventArgs) Handles OptTR.CheckedChanged
        If OptTR.Checked = True Then
            WVMTR()
        End If
    End Sub
    Private Sub OptTRedit_CheckedChanged(sender As Object, e As EventArgs) Handles OptTRedit.CheckedChanged
        If OptTRedit.Checked = True Then
            WVMTR()
        End If
    End Sub
    Private Sub OptTRedit_Click(sender As Object, e As EventArgs) Handles OptTRedit.Click
        Dim JmlRm, JmM1D, JmM2D, JmM3D As Integer
        Dim JmM1I, JmM2I, JmM3I As Integer
        '
        If OptTRedit.Checked = True Then
            WVMTR()
            SortDataTR()
            BtnTmbhBrs_Click(sender, New System.EventArgs)
            '
            JmlRm = 0 'row.Cells(3).Value.ToString
            JmM1D = 0 'row.Cells(4).Value.ToString
            JmM2D = 0
            JmM3D = 0
            '
            JmM1I = 0
            JmM2I = 0
            JmM3I = 0
            For Each row As DataGridViewRow In DGV_edit2.Rows
                If Not row.IsNewRow Then
                    lblRmd.Text = row.Cells(3).Value.ToString '(DGV_edit2.Item(3, z).Value)
                    lblM1Dv.Text = row.Cells(4).Value.ToString '(DGV_edit2.Item(4, z).Value)
                    lblM1Inp.Text = row.Cells(5).Value.ToString '(DGV_edit2.Item(5, z).Value)
                    lblM2Dv.Text = row.Cells(6).Value.ToString '(DGV_edit2.Item(6, z).Value)
                    lblM2Inp.Text = row.Cells(7).Value.ToString '(DGV_edit2.Item(7, z).Value)
                    lblM3Dv.Text = row.Cells(8).Value.ToString '(DGV_edit2.Item(8, z).Value)
                    lblM3Inp.Text = row.Cells(9).Value.ToString '(DGV_edit2.Item(9, z).Value)
                    '
                    JmlRm = (CDbl(lblRmd.Text) + CDbl(JmlRm))
                    JmM1D = (CDbl(lblM1Dv.Text) + CDbl(JmM1D))
                    JmM1I = (CDbl(lblM1Inp.Text) + CDbl(JmM1I))
                    JmM2D = (CDbl(lblM2Dv.Text) + CDbl(JmM2D))
                    JmM2I = (CDbl(lblM2Inp.Text) + CDbl(JmM2I))
                    JmM3D = (CDbl(lblM3Dv.Text) + CDbl(JmM3D))
                    JmM3I = (CDbl(lblM3Inp.Text) + CDbl(JmM3I))
                End If
            Next
        End If
        txtinp_awalTtl.Text = JmlRm
        txtdlvdt1ttl.Text = JmM1D
        txtinp_pr1dtTtl.Text= JmM1I
        txtdlvdt2Ttl.Text = JmM2D
        txtinp_pr2dtTtl.Text = JmM2I
        txtdlvdt3Ttl.Text = JmM3D
        txtinp_pr3dtTtl.Text = JmM3I
    End Sub
    Private Sub OptTR_Click(sender As Object, e As EventArgs) Handles OptTR.Click
        If OptTR.Checked = True Then
            WVMTR()
        End If
        '
    End Sub
    Private Sub OptSp_CheckedChanged(sender As Object, e As EventArgs) Handles OptSp.CheckedChanged
        If OptSp.Checked = True Then
            WVMSP()
        End If
    End Sub

    Private Sub OptSp_Click(sender As Object, e As EventArgs) Handles OptSp.Click
        If OptSp.Checked = True Then
            WVMSP()
        End If
    End Sub
    Private Sub OptSpedit_CheckedChanged(sender As Object, e As EventArgs) Handles OptSpedit.CheckedChanged
        '
        If OptSpedit.Checked = True Then
            WVMSP()
            SortDataSP()
        End If
    End Sub
    Private Sub OptSpedit_Click(sender As Object, e As EventArgs) Handles OptSpedit.Click
        Dim JmlRm, JmM1D, JmM2D, JmM3D As Integer
        Dim JmM1I, JmM2I, JmM3I As Integer
        If OptSpedit.Checked = True Then
            WVMSP()
            '
            SortDataSP()
            BtnTmbhBrs_Click(sender, New System.EventArgs)
            JmlRm = 0 'row.Cells(3).Value.ToString
            JmM1D = 0 'row.Cells(4).Value.ToString
            JmM2D = 0
            JmM3D = 0
            '
            JmM1I = 0
            JmM2I = 0
            JmM3I = 0
            For Each row As DataGridViewRow In DGV_edit2.Rows
                If Not row.IsNewRow Then
                    lblRmd.Text = row.Cells(3).Value.ToString '(DGV_edit2.Item(3, z).Value)
                    lblM1Dv.Text = row.Cells(4).Value.ToString '(DGV_edit2.Item(4, z).Value)
                    lblM1Inp.Text = row.Cells(5).Value.ToString '(DGV_edit2.Item(5, z).Value)
                    lblM2Dv.Text = row.Cells(6).Value.ToString '(DGV_edit2.Item(6, z).Value)
                    lblM2Inp.Text = row.Cells(7).Value.ToString '(DGV_edit2.Item(7, z).Value)
                    lblM3Dv.Text = row.Cells(8).Value.ToString '(DGV_edit2.Item(8, z).Value)
                    lblM3Inp.Text = row.Cells(9).Value.ToString '(DGV_edit2.Item(9, z).Value)
                    '
                    JmlRm = (CDbl(lblRmd.Text) + CDbl(JmlRm))
                    JmM1D = (CDbl(lblM1Dv.Text) + CDbl(JmM1D))
                    JmM1I = (CDbl(lblM1Inp.Text) + CDbl(JmM1I))
                    JmM2D = (CDbl(lblM2Dv.Text) + CDbl(JmM2D))
                    JmM2I = (CDbl(lblM2Inp.Text) + CDbl(JmM2I))
                    JmM3D = (CDbl(lblM3Dv.Text) + CDbl(JmM3D))
                    JmM3I = (CDbl(lblM3Inp.Text) + CDbl(JmM3I))
                End If
            Next
        End If
        txtinp_awalTtl.Text = JmlRm
        txtdlvdt1ttl.Text = JmM1D
        txtinp_pr1dtTtl.Text = JmM1I
        txtdlvdt2Ttl.Text = JmM2D
        txtinp_pr2dtTtl.Text = JmM2I
        txtdlvdt3Ttl.Text = JmM3D
        txtinp_pr3dtTtl.Text = JmM3I
    End Sub
    Private Sub OptAll_CheckedChanged(sender As Object, e As EventArgs) Handles OptAll.CheckedChanged
        If OptAll.Checked = True Then
            WVMALL()
        End If
    End Sub
    Private Sub OptAll_Click(sender As Object, e As EventArgs) Handles OptAll.Click
   
        If OptAll.Checked = True Then
            WVMALL()
        End If
    End Sub

    Private Sub OptAllEdit_CheckedChanged(sender As Object, e As EventArgs) Handles OptAllEdit.CheckedChanged
        If OptAllEdit.Checked = True Then
            WVMALL()
            SortDataGS()
        End If

    End Sub
    Private Sub OptAllEdit_Click(sender As Object, e As EventArgs) Handles OptAllEdit.Click
        Dim JmlRm, JmM1D, JmM2D, JmM3D As Integer
        Dim JmM1I, JmM2I, JmM3I As Integer
        If OptAllEdit.Checked = True Then
            WVMALL()
            SortDataGS()
           BtnTmbhBrs_Click(sender, New System.EventArgs)
            JmlRm = 0 'row.Cells(3).Value.ToString
            JmM1D = 0 'row.Cells(4).Value.ToString
            JmM2D = 0
            JmM3D = 0
            '
            JmM1I = 0
            JmM2I = 0
            JmM3I = 0
            For Each row As DataGridViewRow In DGV_edit2.Rows
                If Not row.IsNewRow Then
                    lblRmd.Text = row.Cells(3).Value.ToString '(DGV_edit2.Item(3, z).Value)
                    lblM1Dv.Text = row.Cells(4).Value.ToString '(DGV_edit2.Item(4, z).Value)
                    lblM1Inp.Text = row.Cells(5).Value.ToString '(DGV_edit2.Item(5, z).Value)
                    lblM2Dv.Text = row.Cells(6).Value.ToString '(DGV_edit2.Item(6, z).Value)
                    lblM2Inp.Text = row.Cells(7).Value.ToString '(DGV_edit2.Item(7, z).Value)
                    lblM3Dv.Text = row.Cells(8).Value.ToString '(DGV_edit2.Item(8, z).Value)
                    lblM3Inp.Text = row.Cells(9).Value.ToString '(DGV_edit2.Item(9, z).Value)
                    '
                    JmlRm = (CDbl(lblRmd.Text) + CDbl(JmlRm))
                    JmM1D = (CDbl(lblM1Dv.Text) + CDbl(JmM1D))
                    JmM1I = (CDbl(lblM1Inp.Text) + CDbl(JmM1I))
                    JmM2D = (CDbl(lblM2Dv.Text) + CDbl(JmM2D))
                    JmM2I = (CDbl(lblM2Inp.Text) + CDbl(JmM2I))
                    JmM3D = (CDbl(lblM3Dv.Text) + CDbl(JmM3D))
                    JmM3I = (CDbl(lblM3Inp.Text) + CDbl(JmM3I))
                End If
            Next
        End If
        txtinp_awalTtl.Text = JmlRm
        txtdlvdt1ttl.Text = JmM1D
        txtinp_pr1dtTtl.Text = JmM1I
        txtdlvdt2Ttl.Text = JmM2D
        txtinp_pr2dtTtl.Text = JmM2I
        txtdlvdt3Ttl.Text = JmM3D
        txtinp_pr3dtTtl.Text = JmM3I
    End Sub
    Sub Buka_DataComboedit()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        'DGV.ReadOnly = True
        DA = New SqlDataAdapter("Select * From sl_grey_request", KonIstem)
        DA.Fill(DS, "sl_grey_request")
        '
        CMD = New SqlCommand(WVMaster, KonIstem)
        DR = CMD.ExecuteReader
        '
        Do While DR.Read
            cmbGreynoedit.Items.Add(DR.Item(0))
        Loop
        ''
        KonIstem.Close()
    End Sub
    Sub Buka_DataComboPlan()
        ''
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        'DGV.ReadOnly = True
        DA = New SqlDataAdapter("Select [plan_month] From sl_grey_request", KonIstem)
        DA.Fill(DS, "sl_grey_request")
        '
        CMD = New SqlCommand(MPlan, KonIstem)
        DR = CMD.ExecuteReader
        cmbPlanMonth.Items.Clear()
        Do While DR.Read
            cmbPlanMonth.Items.Add(DR.Item(0))
        Loop
        KonIstem.Close()
    End Sub
    Sub StatusGrey()
        If OptUbah.Checked = False Then
            cmbStatusBrg.Items.Clear()
            cmbStatusBrg.Items.Add("Garment")
            cmbStatusBrg.Items.Add("Non Garment")
        Else
            cmbStatusBrgedit.Items.Clear()
            cmbStatusBrgedit.Items.Add("Garment")
            cmbStatusBrgedit.Items.Add("Non Garment")
        End If
    End Sub
    Private Sub frmSales_Entry_Req_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Buka_DataComboPlan()
    End Sub

    Private Sub frmSales_Entry_Req_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Bukakunci()
        BersihHeader()
        Bersihtext()
        Bersihtextdetil()
        '
        BtnTmbhDtl.Enabled = False
        BtnUbah_dtl.Enabled = False
        BtnDelete.Enabled = False
        BtnUpdateV.Enabled = False
        PnlPlandate.Visible = False
        '
        txtinp_awalTtl.Text = ""
        txtdlvdt1ttl.Text = ""
        txtinp_pr1dtTtl.Text = ""
        txtdlvdt2Ttl.Text = ""
        txtinp_pr2dtTtl.Text = ""
        txtdlvdt3Ttl.Text = ""
        txtinp_pr3dtTtl.Text = ""
        '
        txtRequestdate.Text = ""
        txtPlanMonth.Text = ""
        txtReqEdit.Text = ""
        cmbPlanMonth.Text = ""
        '
        '
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ''
        StatusGrey()
        'Buka_DataCombo()
        'Buka_DataComboedit()
        Buka_DataComboPlan()
        '
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        OptUbah.Checked = False
        TabControl1.SelectTab(0)
        '
        PnlPlandate.Visible = True
        DtpPickerawal.Focus()
        Kunci()
    End Sub
    Public Sub SetplanRequest()
        Dtpickerbulan1.Value = DtpPickerawal.Value
        Dtpickerbulan2.Value = DtpPickerawal.Value
        Dtpickerbulan3.Value = DtpPickerawal.Value
        '
        NilaiBulansatu = Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "MMMM-yyyy")
        Bulanprd1 = Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "MM/yyyy")
        NilaiTglakhirprd1 = DateSerial(Year(Bulanprd1), Month(Bulanprd1) + 1, 0)
        'lblRemindfrmperiod1 = Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "MM") & "/" & "01" & "/" & Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "yyyy")
        lblRemindfrmperiod1 = Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "yyyy") & "/" & Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "MM") & "/" & "01"

        'Hasilfrmperiod1 = Format((Dtpickerbulan1), "MM/dd/yyyy")
        '
        NilaiBulandua = Format(DateAdd(DateInterval.Month, 2, Dtpickerbulan2.Value), "MMMM-yyyy")
        Bulanprd2 = Format(DateAdd(DateInterval.Month, 2, Dtpickerbulan2.Value), "MM/yyyy")
        NilaiTglakhirprd2 = DateSerial(Year(Bulanprd2), Month(Bulanprd2) + 1, 0)
        'lblRemindfrmperiod1 = Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "MM") & "/" & "01" & "/" & Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "yyyy")
        'lblRemindfrmperiod2 = Format(DateAdd(DateInterval.Month, 2, Dtpickerbulan2.Value), "MM") & "/" & "01" & "/" & Format(DateAdd(DateInterval.Month, 2, Dtpickerbulan2.Value), "yyyy")
        lblRemindfrmperiod2 = Format(DateAdd(DateInterval.Month, 2, Dtpickerbulan2.Value), "yyyy") & "/" & Format(DateAdd(DateInterval.Month, 2, Dtpickerbulan2.Value), "MM") & "/" & "01"
        'Hasilfrmperiod2 = lblRemindfrmperiod2
        '
        NilaiBulantiga = Format(DateAdd(DateInterval.Month, 3, Dtpickerbulan3.Value), "MMMM-yyyy")
        Bulanprd3 = Format(DateAdd(DateInterval.Month, 3, Dtpickerbulan3.Value), "MM/yyyy")
        NilaiTglakhirprd3 = DateSerial(Year(Bulanprd3), Month(Bulanprd3) + 1, 0)
        'lblRemindfrmperiod1 = Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "MM") & "/" & "01" & "/" & Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "yyyy")
        'lblRemindfrmperiod3 = Format(DateAdd(DateInterval.Month, 3, Dtpickerbulan3.Value), "MM") & "/" & "01" & "/" & Format(DateAdd(DateInterval.Month, 3, Dtpickerbulan3.Value), "yyyy")
        lblRemindfrmperiod3 = Format(DateAdd(DateInterval.Month, 3, Dtpickerbulan3.Value), "yyyy") & "/" & Format(DateAdd(DateInterval.Month, 3, Dtpickerbulan3.Value), "MM") & "/" & "01"
        'Hasilfrmperiod3 = lblRemindfrmperiod3
        '
        Tanggalawal = Format(DtpPickerawal.Value, "dd")
        Tahunawal = Format(DtpPickerawal.Value.Year)
        Bulanawal = Format(DtpPickerawal.Value.Month)
        '
        If Bulanawal <= 10 Then
            'Dari ibu felis request bulan ditambah 1
            lblBulanAwal.Text = ("0" & (Bulanawal) + 1)
        Else
            'Dari ibu felis request bulan ditambah 1 
            lblBulanAwal.Text = Bulanawal + 1
        End If
        '
        lblPlantMonth.Text = (Tahunawal) & "-" & (lblBulanAwal.Text)
        '
        HasilPlantmonth = lblPlantMonth.Text
        '
        NilaiTglakhirAwal = DateSerial(Year(DtpPickerawal.Value), Month(DtpPickerawal.Value) + 1, 0)
        '
        'lblRemindtoperiodawal = Format((NilaiTglakhirAwal), "MM/dd/yyyy")
        'lblRemindfrmperiodawal = (Format((DtpPickerawal.Value), "MM/dd/yyy"))
        'lblRemindtoperiod1 = Format((NilaiTglakhirprd1), "MM/dd/yyyy")
        'lblRemindtoperiod2 = Format((NilaiTglakhirprd2), "MM/dd/yyyy")
        'lblRemindtoperiod3 = Format((NilaiTglakhirprd3), "MM/dd/yyyy")
        '
        lblRemindtoperiodawal = Format((NilaiTglakhirAwal), "yyyy/MM/dd")
        lblRemindfrmperiodawal = (Format((DtpPickerawal.Value), "yyyy/MM/dd"))
        '
        lblRemindtoperiod1 = Format((NilaiTglakhirprd1), "yyyy/MM/dd")
        lblRemindtoperiod2 = Format((NilaiTglakhirprd2), "yyyy/MM/dd")
        lblRemindtoperiod3 = Format((NilaiTglakhirprd3), "yyyy/MM/dd")
        '
        Tanggalakhir1 = NilaiTglakhirAwal.Day & "-" & Format(DtpPickerawal.Value, "MMMM") & "-" & (Tahunawal)
        Hasilfrmperiodawal = Convert.ToDateTime(lblRemindfrmperiodawal)
        lblTanggalawal.Text = lblRemindfrmperiodawal
        BtnperiodAwal.Text = Tanggalawal & "-" & Tanggalakhir1
        Btnperiod1.Text = NilaiBulansatu
        Btnperiod2.Text = NilaiBulandua
        Btnperiod3.Text = NilaiBulantiga
        '
        BtnperiodAwalDtl.Text = Tanggalawal & "-" & Tanggalakhir1
        Btnperiod1Dtl.Text = NilaiBulansatu
        Btnperiod2Dtl.Text = NilaiBulandua
        Btnperiod3Dtl.Text = NilaiBulantiga
        ''
    End Sub
    Sub SetPlantReqInisial()
        '
        Dim HasilTglAwal, HasilTglAkhir As String
        'Dim Remindfromawal, Remindtoperiod1, Remindtoperiod2, Remindtoperiod3 As Date
        '
        Remindfromawal = lblTglAwal.Text
        HasilperiodTo = lblTglAkhir.Text
        HasilTglAwal = (Format(Remindfromawal, "dd"))
        HasilTglAkhir = Format(HasilperiodTo, "dd-MMMM-yyyy")
        BtnInpAwal.Text = Trim(HasilTglAwal) & "-" & Trim(HasilTglAkhir)
        BtnInpAwalEdit.Text = Trim(HasilTglAwal) & "-" & Trim(HasilTglAkhir)
        '
        NilaiBulansatu = Format(DateAdd(DateInterval.Month, 1, Remindfromawal), "MMMM-yyyy")
        NilaiBulandua = Format(DateAdd(DateInterval.Month, 2, Remindfromawal), "MMMM-yyyy")
        NilaiBulantiga = Format(DateAdd(DateInterval.Month, 3, Remindfromawal), "MMMM-yyyy")
        'HasilTglAwal = Format(NilaiTglakhirAwal, "dd-MMMM-yyyy")
        ''Bulanprd1 = Format(DateAdd(DateInterval.Month, 1, DtpSortData.Value), "MM/yyyy")
        'NilaiTglakhirprd1 = DateSerial(Year(Bulanprd1), Month(Bulanprd1) + 1, 0)
        BtnPrd1.Text = NilaiBulansatu
        BtnPrd2.Text = NilaiBulandua
        BtnPrd3.Text = NilaiBulantiga
        '
        BtnPrd1edit.Text = NilaiBulansatu
        BtnPrd2edit.Text = NilaiBulandua
        BtnPrd3edit.Text = NilaiBulantiga

    End Sub
    Sub Bersihtext()
        cmbGreyno.Text = ""
        txtInputAwal.Text = ""
        txtInpperiod1.Text = ""
        txtDlvperiod1.Text = ""
        txtInpperiod2.Text = ""
        txtDlvperiod2.Text = ""
        txtInpperiod3.Text = ""
        txtDlvperiod3.Text = ""
    End Sub
    Sub Bersihtextdetil()
        cmbGreynoedit.Text = ""
        txtinp_awaldt.Text = ""
        txtinp_pr1dt.Text = ""
        txtinp_pr2dt.Text = ""
        txtinp_pr3dt.Text = ""
        txtdlvdt1.Text = ""
        txtdlvdt2.Text = ""
        txtdlvdt3.Text = ""
    End Sub
    Sub Kunci()
        BtnAdd.Enabled = False
        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnCancel.Enabled = True
        BtnDeleteAll.Enabled = False
        BtnKeluar.Enabled = False
    End Sub
    Sub KunciDetil()

        txtinp_pr1dt.ReadOnly = False
        txtinp_awaldt.ReadOnly = False
        txtinp_pr2dt.ReadOnly = False
        txtinp_pr3dt.ReadOnly = False
        '
        txtdlvdt1.ReadOnly = False
        txtdlvdt2.ReadOnly = False
        txtdlvdt3.ReadOnly = False
        '
        BtnTmbhDtl.Enabled = False
        BtnSimpan_dtl.Enabled = True
        BtnUbah_dtl.Enabled = False
        BtnBatal_dtl.Enabled = True
        BtnDelete.Enabled = False
        BtnUpdateV.Enabled = False
    End Sub
    '
    Sub KunciDetilAll()
        '
        BtnTmbhDtl.Enabled = False
        BtnSimpan_dtl.Enabled = False
        BtnUbah_dtl.Enabled = False
        BtnBatal_dtl.Enabled = False
        BtnDelete.Enabled = False
        BtnUpdateV.Enabled = False
    End Sub
    Sub BukaKunciDetil()
        '
        'txtinp_pr1dt.ReadOnly = True
        'txtinp_awaldt.ReadOnly = True
        'txtinp_pr2dt.ReadOnly = True
        'txtinp_pr3dt.ReadOnly = True
        ''
        'txtdlvdt1.ReadOnly = True
        'txtdlvdt2.ReadOnly = True
        'txtdlvdt3.ReadOnly = True
        '
        BtnTmbhDtl.Enabled = True
        BtnSimpan_dtl.Enabled = False
        BtnUbah_dtl.Enabled = True
        BtnBatal_dtl.Enabled = False
        BtnDelete.Enabled = True
        BtnUpdateV.Enabled = True
    End Sub
    Sub BersihHeader()
        '
        BtnperiodAwal.Text = ""
        Btnperiod1.Text = ""
        Btnperiod2.Text = ""
        Btnperiod3.Text = ""
        '
        BtnperiodAwalDtl.Text = ""
        Btnperiod1Dtl.Text = ""
        Btnperiod2Dtl.Text = ""
        Btnperiod3Dtl.Text = ""
    End Sub

    Private Sub BtnUpdateV_Click(sender As Object, e As EventArgs) Handles BtnUpdateV.Click
        'KoneksiISTEM()
        'KonIstem.Open()

        ''Using Kon As New SqlConnection(ConString)
        'Using KonIstem As New SqlConnection(ConStringISTEM)
        '    If MessageBox.Show("Yakin akan di Memperbarui Laporan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
        '        Ubahdata = "Update sl_grey_request set request_version=@request_version where plan_month ='" & (TxtHasilModif.Text) & "'"
        '        Dim i As Integer
        '        If CInt(lblUpdateV.Text) = 1 Then
        '            i = CInt(lblUpdateV.Text) + 1
        '        Else
        '            i = CInt(lblUpdateV.Text) + 1
        '        End If
        '        Dim CMD As New SqlCommand(Ubahdata, KonIstem)
        '        ''
        '        CMD.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
        '        '
        '        KonIstem.Open()
        '        TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
        '        CMD.Transaction = TR
        '        Try
        '            For Each row As DataGridViewRow In DGV_edit.Rows
        '                If Not row.IsNewRow Then
        '                    CMD.Parameters("@request_version").Value = i
        '                End If
        '            Next
        '            '
        '            CMD.ExecuteNonQuery()
        '            TR.Commit()
        '            MessageBox.Show("Laporan Berhasil Di Perbarui", "Informasi")
        '        Catch ex As Exception
        '            Try
        '                TR.Rollback()
        '                MessageBox.Show(ex.Message)
        '            Catch rollBackEx As Exception
        '                MessageBox.Show(rollBackEx.Message)
        '            End Try
        '        End Try
        '    End If
        '    SortData()
        'End Using
        ''Kunci()
        'Bukakunci()
        'BukaKunciDetil()
        ''
        ''
        'BtnTmbhDtl.Enabled = False
        'BtnSimpan_dtl.Enabled = False
        'BtnUbah_dtl.Enabled = False
        'BtnBatal_dtl.Enabled = False
        'BtnDelete.Enabled = False
        'BtnUpdateV.Enabled = False
        ''
    End Sub

  
    Private Sub BtnTambahEdit_Click(sender As Object, e As EventArgs) Handles BtnTambahEdit.Click
        'Dim Mfrawal, Mtoawal, MfrMt1, MtoMt1, MfrMt2, MtoMt2, MfrMt3, MtoMt3 As Date
        KoneksiISTEM()
        KonIstem.Open()
        'If TambahDetil = True Then
        SimpanNewData()
        KonIstem.Close()
            Dim CMDSimpan As New SqlCommand(SimpanData, KonIstem)
            '
            CMDSimpan.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            '
            CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
            CMDSimpan.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
            CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))
        'CMDSimpan.Parameters.Add(New SqlParameter("@send_date", SqlDbType.Date))
            '
            CMDSimpan.Parameters.Add(New SqlParameter("@item_category", SqlDbType.Char))
            CMDSimpan.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
            CMDSimpan.Parameters.Add(New SqlParameter("@garment_flag", SqlDbType.Char))
            CMDSimpan.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
            CMDSimpan.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
            CMDSimpan.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
            ''
            CMDSimpan.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
            CMDSimpan.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
            CMDSimpan.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
            CMDSimpan.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
            '
            CMDSimpan.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
            CMDSimpan.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
            CMDSimpan.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
            CMDSimpan.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
            ''
            CMDSimpan.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
            CMDSimpan.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
            CMDSimpan.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
            CMDSimpan.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
            'CMDSimpan.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
            '
            CMDSimpan.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
            CMDSimpan.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            '
            CMDSimpan.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            CMDSimpan.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
            CMDSimpan.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
            CMDSimpan.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
            '
            KonIstem.Open()
            TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
        CMDSimpan.Transaction = TR
        ' Dim Mfrawal, Mtoawal, MfrMt1, MtoMt1, MfrMt2, MtoMt2, MfrMt3, MtoMt3 As Date
            Try
                '
                'plan_rev_no,plan_rev_date
                CMDSimpan.Parameters("@plan_month").Value = TxtHasilModif.Text
                CMDSimpan.Parameters("@grey_no").Value = txtGreyNo.Text 'Row.Cells(0).Value.ToString 'txtGreyNo.Text 'hasilgreyno
                '
                CMDSimpan.Parameters("@request_date").Value = Convert.ToDateTime(lblTglAwal.Text)
            CMDSimpan.Parameters("@plan_rev_no").Value = "0"
                CMDSimpan.Parameters("@plan_rev_date").Value = Convert.ToDateTime(lblTglAwal.Text)
                CMDSimpan.Parameters("@garment_flag").Value = StsGf 'Row.Cells(1).Value.ToString
                '
                CMDSimpan.Parameters("@remain_input_qty").Value = RMD2 'Row.Cells(2).Value.ToString
                CMDSimpan.Parameters("@remain_date_from").Value = Hasilfrmperiodawal
                CMDSimpan.Parameters("@remain_date_to").Value = HasilperiodTo
                ''
                CMDSimpan.Parameters("@month1_from").Value = Convert.ToDateTime(lblMonth1_from.Text)
                CMDSimpan.Parameters("@month1_to").Value = Convert.ToDateTime(lblMonth1_to.Text)
                CMDSimpan.Parameters("@month1_deliv_qty").Value = Mt1dv 'Row.Cells(3).Value.ToString 'DGV.Rows(i).Cells(2).FormattedValue
                CMDSimpan.Parameters("@month1_input_qty").Value = Mt1ip 'Row.Cells(4).Value.ToString 'DGV.Rows(i).Cells(3).FormattedValue
                '
                CMDSimpan.Parameters("@month2_from").Value = Convert.ToDateTime(lblMonth2_from.Text)
                CMDSimpan.Parameters("@month2_to").Value = Convert.ToDateTime(lblMonth2_to.Text)
                CMDSimpan.Parameters("@month2_deliv_qty").Value = Mt2dv 'Row.Cells(5).Value.ToString 'DGV.Rows(i).Cells(4).FormattedValue
                CMDSimpan.Parameters("@month2_input_qty").Value = Mt2ip 'Row.Cells(6).Value.ToString 'DGV.Rows(i).Cells(5).FormattedValue
                ''
                CMDSimpan.Parameters("@month3_from").Value = Convert.ToDateTime(lblMonth3_from.Text)
                CMDSimpan.Parameters("@month3_to").Value = Convert.ToDateTime(lblMonth3_to.Text)
                CMDSimpan.Parameters("@month3_deliv_qty").Value = Mt3dv 'Row.Cells(7).Value.ToString 'DGV.Rows(i).Cells(6).FormattedValue
                CMDSimpan.Parameters("@month3_input_qty").Value = Mt3ip 'Row.Cells(8).Value.ToString 'DGV.Rows(i).Cells(7).FormattedValue
                CMDSimpan.Parameters("@item_category").Value = Ktgri  'Row.Cells(9).Value.ToString
                ' CMDSimpan.Parameters("@request_version").Value = "1"
                '
            CMDSimpan.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
            CMDSimpan.Parameters("@rec_sts").Value = "A"
            CMDSimpan.Parameters("@proc_no").Value = "1"
            CMDSimpan.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
            CMDSimpan.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
            CMDSimpan.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                '
                CMDSimpan.ExecuteNonQuery()
                TR.Commit()
            Catch ex As Exception
                Try
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                Catch rollBackEx As Exception
                    MessageBox.Show(rollBackEx.Message)
                End Try
        End Try
        SimpanHistori()
        '
        KonIstem.Close()
    End Sub

    Private Sub BtnUbahEdit_Click(sender As Object, e As EventArgs) Handles BtnUbahEdit.Click

        Dim CMDUbahdetil As New SqlCommand(Ubahdata, KonIstem)
        '
        CMDUbahdetil.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
        '
        CMDUbahdetil.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))
        'CMDSimpan.Parameters.Add(New SqlParameter("@send_date", SqlDbType.Date))
        '
        CMDUbahdetil.Parameters.Add(New SqlParameter("@item_category", SqlDbType.Char))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@garment_flag", SqlDbType.Char))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
        ''
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
        '
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
        ''
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
        '
        CMDUbahdetil.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
        '
        CMDUbahdetil.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
        CMDUbahdetil.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
        '
        KonIstem.Open()
        TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
        CMDUbahdetil.Transaction = TR
        '
        Try
            CMDUbahdetil.Parameters("@plan_month").Value = TxtHasilModif.Text
            'CMDSimpan.Parameters("@request_date").Value = Convert.ToDateTime(lblTglAwal.Text)
            CMDUbahdetil.Parameters("@grey_no").Value = txtGreyNo.Text 'row.Cells(0).Value.ToString 'txtGreyNo.Text 'hasilgreyno
            '
            CMDUbahdetil.Parameters("@request_date").Value = Convert.ToDateTime(lblTglAwal.Text)
            '
            'If lblStatusSend.Text <> "1900-01-01" Then
            'CMDUbahdetil.Parameters("@plan_rev_no").Value = "1"
            'Else
            CMDUbahdetil.Parameters("@plan_rev_no").Value = "0"
            ' End If
            '
            CMDUbahdetil.Parameters("@plan_rev_date").Value = Convert.ToDateTime(lblTglAwal.Text)
            '
            CMDUbahdetil.Parameters("@garment_flag").Value = StsGf 'Row.Cells(1).Value.ToString
            '
            CMDUbahdetil.Parameters("@remain_input_qty").Value = RMD2 'Row.Cells(2).Value.ToString
            CMDUbahdetil.Parameters("@remain_date_from").Value = Hasilfrmperiodawal
            CMDUbahdetil.Parameters("@remain_date_to").Value = HasilperiodTo
            ''
            CMDUbahdetil.Parameters("@month1_from").Value = Convert.ToDateTime(lblMonth1_from.Text)
            CMDUbahdetil.Parameters("@month1_to").Value = Convert.ToDateTime(lblMonth1_to.Text)
            CMDUbahdetil.Parameters("@month1_deliv_qty").Value = Mt1dv 'Row.Cells(3).Value.ToString 'DGV.Rows(i).Cells(2).FormattedValue
            CMDUbahdetil.Parameters("@month1_input_qty").Value = Mt1ip 'Row.Cells(4).Value.ToString 'DGV.Rows(i).Cells(3).FormattedValue
            '
            CMDUbahdetil.Parameters("@month2_from").Value = Convert.ToDateTime(lblMonth2_from.Text)
            CMDUbahdetil.Parameters("@month2_to").Value = Convert.ToDateTime(lblMonth2_to.Text)
            CMDUbahdetil.Parameters("@month2_deliv_qty").Value = Mt2dv 'Row.Cells(5).Value.ToString 'DGV.Rows(i).Cells(4).FormattedValue
            CMDUbahdetil.Parameters("@month2_input_qty").Value = Mt2ip 'Row.Cells(6).Value.ToString 'DGV.Rows(i).Cells(5).FormattedValue
            ''
            CMDUbahdetil.Parameters("@month3_from").Value = Convert.ToDateTime(lblMonth3_from.Text)
            CMDUbahdetil.Parameters("@month3_to").Value = Convert.ToDateTime(lblMonth3_to.Text)
            CMDUbahdetil.Parameters("@month3_deliv_qty").Value = Mt3dv 'Row.Cells(7).Value.ToString 'DGV.Rows(i).Cells(6).FormattedValue
            CMDUbahdetil.Parameters("@month3_input_qty").Value = Mt3ip 'Row.Cells(8).Value.ToString 'DGV.Rows(i).Cells(7).FormattedValue
            CMDUbahdetil.Parameters("@item_category").Value = Ktgri 'Row.Cells(9).Value.ToString                            ' CMDSimpan.Parameters("@request_version").Value = "1"
            '
            CMDUbahdetil.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
            CMDUbahdetil.Parameters("@rec_sts").Value = "T"
            '
            CMDUbahdetil.Parameters("@proc_no").Value = "2"
            CMDUbahdetil.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
            CMDUbahdetil.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
            CMDUbahdetil.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
            '
            CMDUbahdetil.ExecuteNonQuery()
            TR.Commit()
        Catch ex As Exception
            Try
                TR.Rollback()
                MessageBox.Show(ex.Message)
            Catch rollBackEx As Exception
                MessageBox.Show(rollBackEx.Message)
            End Try
        End Try
        UbahHistori()
    End Sub
    Sub CekSetPlant()
        '
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        KoneksiISTEM()
        KonIstem.Open()
        '
        Caribulan = Format(DtpPickerawal.Value, "MMMM")
        CariTahun = Format(DtpPickerawal.Value, "yyyy")
        '
        'bulan sekarang ditambah 1 bulan dari setplan request date
        'lbl5.Text = Format(DateAdd(DateInterval.Month, 2, dtpTanggal.Value), "dd-MMMM-yyyy")
        CariPlandata = Format(DtpPickerawal.Value, "yyyy") + "-" + Format(DateAdd(DateInterval.Month, 1, DtpPickerawal.Value), "MM")
        '
        txtPlanMonth.Text = CariPlandata
        txtRequestdate.Text = Format(DtpPickerawal.Value, "dd-MMMM-yyyy")
        '
        'TxtHasilModif.Text = Format(DtpPickerawal.Value, "yyyy") + "-" + Format(DtpPickerawal.Value, "MM")
        'Data yang diperlukan adalah hasil Planth Month 
        CMD = New SqlCommand("Select * from sl_grey_request where plan_month = '" & (CariPlandata) & "'", KonIstem)
        DR = CMD.ExecuteReader
        If DR.HasRows Then
            'MsgBox("Maaf Data Set Plant Sudah ada di bulan " + (Caribulan) + " " + (CariTahun), MsgBoxStyle.Information, "Informasi")
            MsgBox("Maaf Data Set Plant Sudah", MsgBoxStyle.Information, "Informasi")
            Bersihtext()
            Bukakunci()
            BersihHeader()
            PnlEntry.Enabled = False
        Else
            PnlEntry.Enabled = True
        End If
        '
        KonIstem.Close()
    End Sub
    Sub CekDataGrey()
        Dim KodeBrg As String
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        HasilPlantmonth = TxtHasilModif.Text
        KodeBrg = cmbGreynoedit.Text
        CMD = New SqlCommand("Select * from sl_grey_request where plan_month = '" & (HasilPlantmonth) & "' and grey_no='" & (KodeBrg) & "'", KonIstem)
        DR = CMD.ExecuteReader
        If DR.HasRows Then
            'SortData()
            CekKodeBrg = True
            MsgBox("Maaf Data Barang Sudah ada di bulan plan ini", MsgBoxStyle.Information, "Informasi")
            Exit Sub
        Else
            CekKodeBrg = False
        End If
        '
        KonIstem.Close()
    End Sub
    'Sub CekDataAll()
    '    '
    '    KoneksiISTEM()
    '    KonIstem.Open()
    '    '
    '    ' HasilPlantmonth = TxtHasilModif.Text
    '    'KodeBrg = cmbGreynoedit.Text
    '    CMD = New SqlCommand("select COUNT(plan_month) from sl_grey_request", KonIstem)
    '    DR = CMD.ExecuteReader
    '    If DR.HasRows Then
    '        'SortData()
    '        CekKodeBrg = True
    '        MsgBox("Maaf Data Barang Sudah ada di bulan plan ini", MsgBoxStyle.Information, "Informasi")
    '        Exit Sub
    '    Else
    '        CekKodeBrg = False
    '    End If
    '    '
    '    KonIstem.Close()
    'End Sub


    Private Sub BtnDeleteAll_Click(sender As Object, e As EventArgs) Handles BtnDeleteAll.Click
        Dim HapusDataAll As String
        '
        ' Using Kon As New SqlConnection(ConString)
        Using KonIstem As New SqlConnection(ConStringISTEM)
            TxtHasilModif.Text = cmbPlanMonth.Text
            HasilPlantmonth = cmbPlanMonth.Text
            '
            If TxtHasilModif.Text = "" Then
                MsgBox("Maaf Data Belum Dipilih", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '
            If MessageBox.Show("Yakin akan di Hapus semuanya...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                HapusDataAll = "delete sl_grey_request where plan_month ='" & (TxtHasilModif.Text) & "'"
                Dim CMDHapusAll As New SqlCommand(HapusDataAll, KonIstem)
                '
                KonIstem.Open()
                TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
                CMDHapusAll.Transaction = TR
                Try
                    '
                    CMDHapusAll.ExecuteNonQuery()
                    CMDHapusAll.Dispose()
                    TR.Commit()
                    MessageBox.Show("Data Berhasil Dihapus", "Informasi")
                Catch ex As Exception
                    Try
                        TR.Rollback()
                        MessageBox.Show(ex.Message)
                    Catch rollBackEx As Exception
                        MessageBox.Show(rollBackEx.Message)
                    End Try
                End Try
            End If
        End Using
        BersihHeader()
        Bersihtextdetil()
        SortData()
        OptUbah.Checked = False
        '
        cmbPlanMonth.Text = ""
        DGV_edit2.Refresh()
        DGV_edit2.Rows.Clear()
    End Sub

    Private Sub DGV_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles DGV.CellFormatting
        DGV.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub txtInputAwal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInputAwal.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtInpperiod1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInpperiod1.KeyPress
        Try
            If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
                e.Handled = True
            End If
        Catch ex As Exception
            ' MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtDlvperiod1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDlvperiod1.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtInpperiod2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInpperiod2.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDlvperiod2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDlvperiod2.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtInpperiod3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtInpperiod3.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDlvperiod3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDlvperiod3.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub
   
    Private Sub BtnSortPlant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSortPlant.Click
        Dim CariPlanth As String
        '
        DateTimePicker1.Value = DtpSortData1.Value
        Caribulan = (Format(DateTimePicker1.Value, "MM"))
        CariTahun = Format(DateTimePicker1.Value, "yyyy")
        'SortTgl = Format(DateTimePicker2.Value, "yyyy-MM")
        CariPlanth = (CariTahun) + "-" + (Caribulan)
        '
        'SetPlantReqInisial()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        DA = New SqlDataAdapter("Select grey_no,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_deliv_qty,month1_input_qty,month2_from,month2_to,month2_deliv_qty,month2_input_qty,month3_from,month3_to,month3_deliv_qty,month3_input_qty from sl_grey_request where plan_month = '" & (CariPlanth) & "'", KonIstem)
        DS = New DataSet
        '
        Try
            DA.Fill(DS)
            '
            DGV_edit.DataSource = DS.Tables(0)
            KonIstem.Close()
            DGV_edit.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub SortData()
        Dim CariPlanth As String
        '
        DateTimePicker1.Value = DtpSortData1.Value
        Caribulan = (Format(DateTimePicker1.Value, "MM"))
        CariTahun = Format(DateTimePicker1.Value, "yyyy")
        CariPlanth = (CariTahun) + "-" + (Caribulan)
        '
        If OptUbah.Checked = True Then
            SetPlantReqInisial()
        End If
        ''
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        'DA = New SqlDataAdapter("Select grey_no,remain_input_qty,month1_input_qty,month1_deliv_qty,month2_input_qty,month2_deliv_qty,month3_input_qty,month3_deliv_qty from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "'", Koncim)
        DA = New SqlDataAdapter("Select item_category,grey_no,garment_flag,remain_input_qty,month1_deliv_qty,month1_input_qty," _
                 & "month2_deliv_qty,month2_input_qty,month3_deliv_qty,month3_input_qty from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "'", KonIstem)
        DS = New DataSet
        Try
            DA.Fill(DS)
            '
            DGV_edit.DataSource = DS.Tables(0)
            KonIstem.Close()
            DGV_edit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' ''
            DGV_edit.Columns(0).Width = 80
            DGV_edit.Columns(1).Width = 80
            DGV_edit.Columns(2).Width = 80
            DGV_edit.Columns(3).Width = 110
            DGV_edit.Columns(4).Width = 90
            DGV_edit.Columns(5).Width = 85
            DGV_edit.Columns(6).Width = 85
            DGV_edit.Columns(7).Width = 90
            DGV_edit.Columns(8).Width = 85
            DGV_edit.Columns(9).Width = 90
            ' 
            DGV_edit.Columns(0).ReadOnly = True
            DGV_edit.Columns(1).ReadOnly = True
            'DGV_edit.Columns(9).Visible = False
            '
            'DGV_edit.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        DA.Dispose()
    End Sub
    Sub SortDataTR()
        Dim CariPlanth As String
        '
        DGV_edit2.Refresh()
        DGV_edit2.RefreshEdit()
        DGV_edit2.Rows.Clear()
        '
        DateTimePicker1.Value = DtpSortData1.Value
        Caribulan = (Format(DateTimePicker1.Value, "MM"))
        CariTahun = Format(DateTimePicker1.Value, "yyyy")
        CariPlanth = (CariTahun) + "-" + (Caribulan)
        '
        If OptUbah.Checked = True Then
            SetPlantReqInisial()
        End If
        ''
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        'DA = New SqlDataAdapter("Select grey_no,remain_input_qty,month1_input_qty,month1_deliv_qty,month2_input_qty,month2_deliv_qty,month3_input_qty,month3_deliv_qty from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "'", Koncim)
        DA = New SqlDataAdapter("Select item_category,grey_no,garment_flag,remain_input_qty,month1_deliv_qty,month1_input_qty," _
                 & "month2_deliv_qty,month2_input_qty,month3_deliv_qty,month3_input_qty from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "' and item_category = 'TR'", KonIstem)
        DS = New DataSet
        Try
            DA.Fill(DS)
            '
            DGV_edit.DataSource = DS.Tables(0)
            KonIstem.Close()
            DGV_edit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' ''
            DGV_edit.Columns(0).Width = 80
            DGV_edit.Columns(1).Width = 80
            DGV_edit.Columns(2).Width = 80
            DGV_edit.Columns(3).Width = 110
            DGV_edit.Columns(4).Width = 90
            DGV_edit.Columns(5).Width = 85
            DGV_edit.Columns(6).Width = 85
            DGV_edit.Columns(7).Width = 90
            DGV_edit.Columns(8).Width = 85
            DGV_edit.Columns(9).Width = 90
            ' 
            DGV_edit.Columns(0).ReadOnly = True
            DGV_edit.Columns(1).ReadOnly = True
            'DGV_edit.Columns(9).Visible = False
            '
            'DGV_edit.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        DA.Dispose()
    End Sub
    Sub SortDataSP()
        Dim CariPlanth As String
        '
        '
        DGV_edit2.Refresh()
        DGV_edit2.RefreshEdit()
        DGV_edit2.Rows.Clear()
        '
        DateTimePicker1.Value = DtpSortData1.Value
        Caribulan = (Format(DateTimePicker1.Value, "MM"))
        CariTahun = Format(DateTimePicker1.Value, "yyyy")
        CariPlanth = (CariTahun) + "-" + (Caribulan)
        '
        If OptUbah.Checked = True Then
            SetPlantReqInisial()
        End If
        ''
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        'DA = New SqlDataAdapter("Select grey_no,remain_input_qty,month1_input_qty,month1_deliv_qty,month2_input_qty,month2_deliv_qty,month3_input_qty,month3_deliv_qty from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "'", Koncim)
        DA = New SqlDataAdapter("Select item_category,grey_no,garment_flag,remain_input_qty,month1_deliv_qty,month1_input_qty," _
                 & "month2_deliv_qty,month2_input_qty,month3_deliv_qty,month3_input_qty from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "' and item_category='SP'", KonIstem)
        DS = New DataSet
        Try
            DA.Fill(DS)
            '
            DGV_edit.DataSource = DS.Tables(0)
            KonIstem.Close()
            DGV_edit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' ''
            DGV_edit.Columns(0).Width = 80
            DGV_edit.Columns(1).Width = 80
            DGV_edit.Columns(2).Width = 80
            DGV_edit.Columns(3).Width = 110
            DGV_edit.Columns(4).Width = 90
            DGV_edit.Columns(5).Width = 85
            DGV_edit.Columns(6).Width = 85
            DGV_edit.Columns(7).Width = 90
            DGV_edit.Columns(8).Width = 85
            DGV_edit.Columns(9).Width = 90
            ' 
            DGV_edit.Columns(0).ReadOnly = True
            DGV_edit.Columns(1).ReadOnly = True
            'DGV_edit.Columns(9).Visible = False
            '
            'DGV_edit.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        DA.Dispose()
    End Sub
    Sub SortDataGS()
        Dim CariPlanth As String
        '
        DGV_edit2.Refresh()
        DGV_edit2.RefreshEdit()
        DGV_edit2.Rows.Clear()
        '
        DateTimePicker1.Value = DtpSortData1.Value
        Caribulan = (Format(DateTimePicker1.Value, "MM"))
        CariTahun = Format(DateTimePicker1.Value, "yyyy")
        CariPlanth = (CariTahun) + "-" + (Caribulan)
        '
        If OptUbah.Checked = True Then
            SetPlantReqInisial()
        End If
        ''
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        'DA = New SqlDataAdapter("Select grey_no,remain_input_qty,month1_input_qty,month1_deliv_qty,month2_input_qty,month2_deliv_qty,month3_input_qty,month3_deliv_qty from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "'", Koncim)
        DA = New SqlDataAdapter("Select item_category,grey_no,garment_flag,remain_input_qty,month1_deliv_qty,month1_input_qty," _
                 & "month2_deliv_qty,month2_input_qty,month3_deliv_qty,month3_input_qty from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "' and item_category='GS'", KonIstem)
        DS = New DataSet
        Try
            DA.Fill(DS)
            '
            DGV_edit.DataSource = DS.Tables(0)
            KonIstem.Close()
            DGV_edit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ' ''
            DGV_edit.Columns(0).Width = 80
            DGV_edit.Columns(1).Width = 80
            DGV_edit.Columns(2).Width = 80
            DGV_edit.Columns(3).Width = 110
            DGV_edit.Columns(4).Width = 90
            DGV_edit.Columns(5).Width = 85
            DGV_edit.Columns(6).Width = 85
            DGV_edit.Columns(7).Width = 90
            DGV_edit.Columns(8).Width = 85
            DGV_edit.Columns(9).Width = 90
            ' 
            DGV_edit.Columns(0).ReadOnly = True
            DGV_edit.Columns(1).ReadOnly = True
            'DGV_edit.Columns(9).Visible = False
            '
            'DGV_edit.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        DA.Dispose()
    End Sub
    Private Sub DGV_edit_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        DGV_edit.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub
    Private Sub DGV_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellEndEdit
        Try
            '
            'If DGV.Rows(e.RowIndex).Cells(2).Value < DGV.Rows(e.RowIndex).Cells(3).Value Then
            If CDbl(DGV.Rows(e.RowIndex).Cells(5).Value) < CDbl(DGV.Rows(e.RowIndex).Cells(4).Value) Then
                MsgBox("Data Input Tidak Boleh lebih Kecil Dari Delivery")
                Exit Sub
            End If
            If CDbl(DGV.Rows(e.RowIndex).Cells(7).Value) < CDbl(DGV.Rows(e.RowIndex).Cells(6).Value) Then
                MsgBox("Data Input Tidak Boleh lebih Kecil Dari Delivery")
                Exit Sub
            End If
            If CDbl(DGV.Rows(e.RowIndex).Cells(9).Value) < CDbl(DGV.Rows(e.RowIndex).Cells(8).Value) Then
                MsgBox("Data Input Tidak Boleh lebih Kecil Dari Delivery")
                Exit Sub
            End If
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnUbah_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbah_dtl.Click
        'BukaKunciDetil()
        If lblHasilplant_edit.Text = "" Then
            MsgBox("Maaf Datagrid harus Dipilih dahulu")
            Exit Sub
        End If
        KunciDetil()
        txtinp_awaldt.Focus()
        TambahDetil = False
    End Sub

    Private Sub BtnTmbhDtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTmbhDtl.Click
        Dim baris As Integer = DGV.RowCount - 1
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        Try

       
        ' If cmbGreynoedit.Text = "" Or txtinp_awaldt.Text = "" Or txtdlvdt1.Text = "" Or txtinp_pr1dt.Text = "" Or txtdlvdt2.Text = "" Or txtinp_pr2dt.Text = "" Or txtdlvdt3.Text = "" Or txtinp_pr3dt.Text = "" Or cmbStatusBrgedit.Text = "" Then
        If cmbGreynoedit.Text = "" Then
            MsgBox("Maaf Greyno Tidak Boleh Dalam Keadaan Kosong", vbInformation, "Informasi")
            cmbGreynoedit.Focus()
            Exit Sub
        End If

        DGV_edit2.Rows.Add(cmbGreynoedit.Text)
        '
        For barisatas As Integer = 0 To DGV_edit2.RowCount - 1
            For barisbawah As Integer = barisatas + 1 To DGV_edit2.RowCount - 1
                If DGV_edit2.Rows(barisbawah).Cells(0).Value & DGV_edit2.Rows(barisbawah).Cells(1).Value = DGV_edit2.Rows(barisatas).Cells(0).Value & DGV_edit2.Rows(barisatas).Cells(1).Value Then
                    ' If DGV.Rows(barisbawah).Cells(0).Value & DGV.Rows(barisbawah).Cells(2).Value = DGV.Rows(barisatas).Cells(0).Value & DGV.Rows(barisatas).Cells(2).Value Then
                    MsgBox("Barang sudah Ada")
                    DGV_edit2.Rows.RemoveAt(barisbawah)
                    'Bersihtextdetil()
                    cmbGreynoedit.Focus()
                    Exit Sub
                End If
            Next
        Next
        Select Case cmbStatusBrgedit.Text
            Case "Garment"
                lblStatusGrey.Text = "G"
            Case "Non Garment"
                lblStatusGrey.Text = ""
        End Select
        '
        Select Case True
            Case OptTRedit.Checked
                lblKategori.Text = "TR"
                'lblStatusGrey.Text = "G"
            Case OptSpedit.Checked
                lblKategori.Text = "SP"
                'lblStatusGrey.Text = ""
            Case OptAllEdit.Checked
                lblKategori.Text = "GS"
        End Select
        '
        '
        DGV_edit2(0, DGV_edit2.RowCount - 2).Value = lblKategori.Text
            'Menggunakan Huruf besar pada kode greyno
            DGV_edit2(1, DGV_edit2.RowCount - 2).Value = UCase(cmbGreynoedit.Text)
        DGV_edit2(2, DGV_edit2.RowCount - 2).Value = lblStatusGrey.Text
        '
        If txtinp_awaldt.Text = "" Then
            DGV_edit2(3, DGV_edit2.RowCount - 2).Value = "0"
        Else
            DGV_edit2(3, DGV_edit2.RowCount - 2).Value = txtinp_awaldt.Text 'txtInpperiod1.Text
        End If
        '
        If txtdlvdt1.Text = "" Then
            DGV_edit2(4, DGV_edit2.RowCount - 2).Value = "0"
        Else
            DGV_edit2(4, DGV_edit2.RowCount - 2).Value = txtdlvdt1.Text 'txtDlvperiod1.Text
        End If
        '
        'txtDlvperiod1
        If txtinp_pr1dt.Text = "" Then
            DGV_edit2(5, DGV_edit2.RowCount - 2).Value = "0"
        Else
            DGV_edit2(5, DGV_edit2.RowCount - 2).Value = txtinp_pr1dt.Text 'txtInpperiod2.Text
        End If
        '
        If txtdlvdt2.Text = "" Then
            DGV_edit2(6, DGV_edit2.RowCount - 2).Value = "0"
        Else
            DGV_edit2(6, DGV_edit2.RowCount - 2).Value = txtdlvdt2.Text 'txtDlvperiod2.Text
        End If
        '
        If txtinp_pr2dt.Text = "" Then
            DGV_edit2(7, DGV_edit2.RowCount - 2).Value = "0"
        Else
            DGV_edit2(7, DGV_edit2.RowCount - 2).Value = txtinp_pr2dt.Text 'txtInpperiod3.Text
        End If
        'txtDlvperiod2
        If txtdlvdt3.Text = "" Then
            DGV_edit2(8, DGV_edit2.RowCount - 2).Value = "0"
        Else
            DGV_edit2(8, DGV_edit2.RowCount - 2).Value = txtdlvdt3.Text 'txtDlvperiod3.Text
        End If
        If txtinp_pr3dt.Text = "" Then
            DGV_edit2(9, DGV_edit2.RowCount - 2).Value = "0"
        Else
            DGV_edit2(9, DGV_edit2.RowCount - 2).Value = txtinp_pr3dt.Text
        End If
        KonIstem.Close()
        '
        cmbGreynoedit.Text = ""
        txtinp_awaldt.Text = ""
        txtdlvdt1.Text = ""
        txtinp_pr1dt.Text = ""
        txtdlvdt2.Text = ""
        txtinp_pr2dt.Text = ""
        txtdlvdt3.Text = ""
        txtinp_pr3dt.Text = ""
        cmbStatusBrgedit.Text = ""
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnBatal_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatal_dtl.Click
        BukaKunciDetil()
        cmbGreynoedit.Visible = False
        txtGreyNo.Visible = True
    End Sub

    Private Sub BtnSimpan_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan_dtl.Click
        Dim HasilGreyno As String
        'Using Kon As New SqlConnection(ConString)
        Using KonIstem As New SqlConnection(ConStringISTEM)
            '
            HasilPlantmonth = TxtHasilModif.Text
            Hasilfrmperiodawal = lblremain_date_from.Text
            HasilperiodTo = lblRemain_date_to.Text
            NilaiRequestdate = lblRequestdate.Text
            Remindfrmperiod1 = lblMonth1_from.Text
            Remindtoperiod1 = lblMonth1_to.Text
            Remindfrmperiod2 = lblMonth2_from.Text
            Remindtoperiod2 = lblMonth2_to.Text
            Remindfrmperiod3 = lblMonth3_from.Text
            Remindtoperiod3 = lblMonth3_to.Text
            HasilGreyno = cmbGreynoedit.Text
            'fUNGSI UNTUK cek data disini ya
            CekDataGrey()
            '
            If CekKodeBrg = True Then
                cmbGreynoedit.Focus()
                Exit Sub
            End If
            ' 
            If MessageBox.Show("Yakin akan di Simpan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                KonIstem.Open()
                TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
                If TambahDetil = True Then
                    '
                    SimpanData = "Insert into sl_grey_request(plan_month,grey_no,request_date,remain_date_from,remain_date_to,remain_input_qty,month1_from,month1_to,month1_input_qty,month1_deliv_qty,month2_from," _
                                & "month2_to,month2_input_qty,month2_deliv_qty,month3_from,month3_to,month3_input_qty,month3_deliv_qty,request_version,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
                                & "values(@plan_month,@grey_no,@request_date,@remain_date_from,@remain_date_to,@remain_input_qty,@month1_from,@month1_to,@month1_input_qty," _
                                & "@month1_deliv_qty,@month2_from,@month2_to,@month2_input_qty,@month2_deliv_qty,@month3_from,@month3_to,@month3_input_qty,@month3_deliv_qty,@request_version,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"

                    Dim CMDSimpan As New SqlCommand(SimpanData, KonIstem)
                    '
                    CMDSimpan.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                    CMDSimpan.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
                    CMDSimpan.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
                    CMDSimpan.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
                    ''
                    CMDSimpan.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
                    '
                    CMDSimpan.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
                    ''
                    CMDSimpan.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
                    CMDSimpan.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
                    CMDSimpan.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
                    '
                    CMDSimpan.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                    CMDSimpan.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
                    '
                    CMDSimpan.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                    CMDSimpan.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
                    CMDSimpan.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
                    CMDSimpan.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
                    '
                    CMDSimpan.Transaction = TR
                    Try
                        'For i As Integer = 0 To DGV.Rows.Count - 2
                        '
                        CMDSimpan.Parameters("@plan_month").Value = TxtHasilModif.Text
                        CMDSimpan.Parameters("@request_date").Value = NilaiRequestdate
                        CMDSimpan.Parameters("@grey_no").Value = HasilGreyno
                        CMDSimpan.Parameters("@remain_input_qty").Value = txtinp_awaldt.Text
                        CMDSimpan.Parameters("@remain_date_from").Value = Hasilfrmperiodawal
                        CMDSimpan.Parameters("@remain_date_to").Value = HasilperiodTo
                        ''
                        CMDSimpan.Parameters("@month1_from").Value = Remindfrmperiod1
                        CMDSimpan.Parameters("@month1_to").Value = Remindtoperiod1
                        CMDSimpan.Parameters("@month1_input_qty").Value = txtinp_pr1dt.Text
                        CMDSimpan.Parameters("@month1_deliv_qty").Value = txtdlvdt1.Text
                        '
                        CMDSimpan.Parameters("@month2_from").Value = Remindfrmperiod2
                        CMDSimpan.Parameters("@month2_to").Value = Remindtoperiod2
                        CMDSimpan.Parameters("@month2_input_qty").Value = txtinp_pr2dt.Text
                        CMDSimpan.Parameters("@month2_deliv_qty").Value = txtdlvdt2.Text
                        ''
                        CMDSimpan.Parameters("@month3_from").Value = Remindfrmperiod3
                        CMDSimpan.Parameters("@month3_to").Value = Remindtoperiod3
                        CMDSimpan.Parameters("@month3_input_qty").Value = txtinp_pr3dt.Text
                        CMDSimpan.Parameters("@month3_deliv_qty").Value = txtdlvdt3.Text
                        CMDSimpan.Parameters("@request_version").Value = "1"
                        '
                        CMDSimpan.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                        CMDSimpan.Parameters("@rec_sts").Value = "A"
                        '
                        CMDSimpan.Parameters("@proc_no").Value = "1"
                        CMDSimpan.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                        CMDSimpan.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                        CMDSimpan.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                        '
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
                Else
                    HasilPlantmonth = TxtHasilModif.Text
                    HasilGreyno = txtGreyNo.Text
                    'Ubahdata = "Update sl_grey_request set request_date=@request_date,remain_date_from=@remain_date_from,remain_date_to=@remain_date_to,remain_input_qty=@remain_input_qty,month1_from=@month1_from,month1_to=@month1_to,month1_deliv_qty=@month1_deliv_qty,month1_input_qty=@month1_input_qty,month2_from=@month2_from, month2_to=@month2_to,month2_deliv_qty=@month2_deliv_qty,month2_input_qty=@month2_input_qty,month3_from=@month3_from,month3_to=@month3_to,month3_deliv_qty=@month3_deliv_qty,month3_input_qty=@month3_input_qty Where plan_month=@plan_month and grey_no=@grey_no"
                    Ubahdata = "Update sl_grey_request set  plan_month=@plan_month,grey_no=@grey_no,remain_input_qty=@remain_input_qty," _
                                & "month1_input_qty=@month1_input_qty,month1_deliv_qty=@month1_deliv_qty,month2_input_qty=@month2_input_qty," _
                                & "month2_deliv_qty=@month2_deliv_qty,month3_input_qty=@month3_input_qty,month3_deliv_qty=@month3_deliv_qty,rec_sts=@rec_sts,user_id=@user_id,proc_no=@proc_no,upd_date=@upd_date,upd_time=@upd_time,client_ip=@client_ip where plan_month=@plan_month and grey_no=@grey_no"
                    Dim CMD As New SqlCommand(Ubahdata, KonIstem)
                    '
                    CMD.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                    CMD.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
                    CMD.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
                    CMD.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
                    CMD.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
                    CMD.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
                    ''
                    CMD.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
                    CMD.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
                    CMD.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
                    CMD.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
                    '
                    CMD.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
                    CMD.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
                    CMD.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
                    CMD.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
                    ''
                    CMD.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
                    CMD.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
                    CMD.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
                    CMD.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
                    '
                    CMD.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                    CMD.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
                    CMD.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                    CMD.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
                    CMD.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
                    CMD.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
                    '
                    'Kon.Open()
                    'TR = Kon.BeginTransaction(IsolationLevel.ReadCommitted)
                    CMD.Transaction = TR
                    Try
                        '
                        CMD.Parameters("@plan_month").Value = HasilPlantmonth
                        CMD.Parameters("@request_date").Value = NilaiRequestdate
                        CMD.Parameters("@grey_no").Value = HasilGreyno
                        CMD.Parameters("@remain_input_qty").Value = txtinp_awaldt.Text
                        CMD.Parameters("@remain_date_from").Value = Hasilfrmperiodawal
                        CMD.Parameters("@remain_date_to").Value = HasilperiodTo
                        ''
                        CMD.Parameters("@month1_from").Value = Remindfrmperiod1
                        CMD.Parameters("@month1_to").Value = Remindtoperiod1
                        'txtdlvdt1

                        CMD.Parameters("@month1_deliv_qty").Value = txtdlvdt1.Text
                        CMD.Parameters("@month1_input_qty").Value = txtinp_pr1dt.Text
                        '
                        CMD.Parameters("@month2_from").Value = Remindfrmperiod2
                        CMD.Parameters("@month2_to").Value = Remindtoperiod2
                        CMD.Parameters("@month2_deliv_qty").Value = txtdlvdt2.Text
                        CMD.Parameters("@month2_input_qty").Value = txtinp_pr2dt.Text
                        ''
                        CMD.Parameters("@month3_from").Value = Remindfrmperiod3
                        CMD.Parameters("@month3_to").Value = Remindtoperiod3
                        CMD.Parameters("@month3_deliv_qty").Value = txtdlvdt3.Text
                        CMD.Parameters("@month3_input_qty").Value = txtinp_pr3dt.Text
                        '
                        CMD.Parameters("@rec_sts").Value = "T"
                        CMD.Parameters("@proc_no").Value = "2"
                        CMD.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                        CMD.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                        CMD.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                        CMD.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                        '
                        CMD.ExecuteNonQuery()
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
                End If
            End If
        End Using
        SortData()
        Bukakunci()
        BukaKunciDetil()
        txtGreyNo.Visible = True
        cmbGreynoedit.Visible = False
        BersihHeader()
        BtnAdd.Focus()
        BtnSave.Enabled = False
        '
        BtnTmbhDtl.Enabled = False
        BtnSimpan_dtl.Enabled = False
        BtnUbah_dtl.Enabled = False
        BtnBatal_dtl.Enabled = False
        BtnDelete.Enabled = False
        BtnUpdateV.Enabled = False
        '
    End Sub
    Private Sub BtnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelete.Click
        'Using Kon As New SqlConnection(ConString)
        '
        TxtHasilModif.Text = cmbPlanMonth.Text
        HasilPlantmonth = cmbPlanMonth.Text
        KoneksiISTEM()
        'KonCIM.Open()
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            Dim I As Integer
            If TxtHasilModif.Text = "" Then
                MsgBox("Maaf Data Belum Dipilih", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '
            CekHapusbaris()
            ' data ada 
            If Hapusbaris = False Then
                I = DGV_edit2.CurrentRow.Index
                If MessageBox.Show("Yakin akan di Hapus...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    HapusData = "delete sl_grey_request where plan_month ='" & (TxtHasilModif.Text) & "' and grey_no='" & (DGV_edit2.Item(1, I).Value) & "' and item_category ='" & (DGV_edit2.Item(0, I).Value) & "'"
                    Dim CMDHapus As New SqlCommand(HapusData, KonIstem)
                    '
                    KonIstem.Open()
                    TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
                    CMDHapus.Transaction = TR
                    Try
                        '
                        CMDHapus.ExecuteNonQuery()
                        CMDHapus.Dispose()
                        'Next i
                        TR.Commit()
                        MessageBox.Show("Data Berhasil Dihapus", "Informasi")
                    Catch ex As Exception
                        Try
                            TR.Rollback()
                            MessageBox.Show(ex.Message)
                        Catch rollBackEx As Exception
                            MessageBox.Show(rollBackEx.Message)
                        End Try
                    End Try
                    HapusHistori1()
                    HapusHistori2()
                End If
                BtnSave.Visible = True
                BtnSaveEdit.Visible = False
                BtnSave.Enabled = True
                BtnSaveEdit.Enabled = False
                'data tidak ada 
            Else
                If MessageBox.Show("Yakin akan di Hapus...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    I = DGV_edit2.RowCount
                    If DGV_edit2.RowCount <= 1 Then
                        Exit Sub
                    Else
                        DGV_edit2.Rows.RemoveAt(DGV_edit2.CurrentCell.RowIndex)
                    End If
                End If
            End If
            '
            BtnSave.Visible = True
            BtnSaveEdit.Visible = False
            '
            BtnSave.Enabled = False
            BtnSaveEdit.Enabled = False
            '
            '
        End Using
        '
        
        'HapusHistori()
        '
        'SortData()
        'BtnSetMdf
        BtnSetMdf_Click(sender, New System.EventArgs)
        '
        Bukakunci()
        BukaKunciDetil()
        BersihHeader()
        '
        'BtnAdd.Focus()
        '
        'BtnTmbhDtl.Enabled = False
        'BtnUbah_dtl.Enabled = False
        'BtnBatal_dtl.Enabled = False
        'txtGreyNo.Visible = True
        'cmbGreynoedit.Visible = False
        'txtGreyNo.Visible = True
        'cmbGreynoedit.Visible = False
        'BtnSimpan_dtl.Enabled = False
        'BtnDelete.Enabled = False
        'BtnUpdateV.Enabled = False
        'BtnSave.Enabled = False
        '

    End Sub
   
    Private Sub txtdlvdt1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdlvdt1.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtdlvdt1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdlvdt1.LostFocus
        'If CInt(txtdlvdt1.Text) > CInt(txtinp_pr1dt.Text) Then
        '    MsgBox("Angka Delivery tidak boleh lebih besar dari Angka Input", vbInformation, "Informasi")
        '    txtdlvdt1.Focus()
        'End If
    End Sub

    Private Sub txtdlvdt2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdlvdt2.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtdlvdt2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdlvdt2.LostFocus
        'If CInt(txtdlvdt2.Text) > CInt(txtinp_pr2dt.Text) Then
        '    MsgBox("Angka Delivery tidak boleh lebih besar dari Angka Input", vbInformation, "Informasi")
        '    txtdlvdt2.Focus()
        'End If
    End Sub

    Private Sub txtdlvdt3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdlvdt3.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtdlvdt3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdlvdt3.LostFocus
        'If CInt(txtdlvdt3.Text) > CInt(txtinp_pr3dt.Text) Then
        '    MsgBox("Angka Delivery tidak boleh lebih besar dari Angka Input", vbInformation, "Informasi")
        '    txtdlvdt3.Focus()
        'End If
    End Sub
    Private Sub DGV_edit_CellFormatting1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        DGV_edit.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub
    Private Sub DGV_edit_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
        KoneksiISTEM()
        'KonCIM.Open()
        Try
            KoneksiISTEM()
            ' Kon = New SqlConnection(ConString)
            'lblHasilplant_edit.Text = DGV_edit.Rows(e.RowIndex).Cells(0).Value
            '
            txtGreyNo.Text = DGV_edit.Rows(e.RowIndex).Cells(0).Value
            txtinp_awaldt.Text = DGV_edit.Rows(e.RowIndex).Cells(1).Value
            txtdlvdt1.Text = DGV_edit.Rows(e.RowIndex).Cells(2).Value
            txtinp_pr1dt.Text = DGV_edit.Rows(e.RowIndex).Cells(3).Value
            txtdlvdt2.Text = DGV_edit.Rows(e.RowIndex).Cells(4).Value
            txtinp_pr2dt.Text = DGV_edit.Rows(e.RowIndex).Cells(5).Value
            txtdlvdt3.Text = DGV_edit.Rows(e.RowIndex).Cells(6).Value
            txtinp_pr3dt.Text = DGV_edit.Rows(e.RowIndex).Cells(7).Value
            '
            ' TxtHasilModif.Text
            CMD = New SqlCommand("Select * from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "' and grey_no ='" & (cmbGreynoedit.Text) & "'", KonIstem)
            '
            KonIstem.Open()
            DR = CMD.ExecuteReader
            DR.Read()

            If DR.HasRows Then
            End If
            KonIstem.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BtnSetMdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetMdf.Click
        Dim Tglreq As Date
        TxtHasilModif.Text = cmbPlanMonth.Text
        HasilPlantmonth = cmbPlanMonth.Text
        '
        DGV_edit2.Refresh()
        DGV_edit2.Rows.Clear()
        '
        KoneksiISTEM()
        KonIstem.Open()
        SetplanRequest()
        '
        '  If OptUbah.Checked = True Then
        CMD = New SqlCommand("Select * from sl_grey_request where plan_month = '" & (TxtHasilModif.Text) & "'", KonIstem)
        DR = CMD.ExecuteReader
        DR.Read()
        PnlModif.Visible = False
        '
        If DR.HasRows Then
            lblTglAwal.Text = DR.Item("request_date")
            lblTglAkhir.Text = DR.Item("remain_date_to")
            lblRequestdate.Text = DR.Item("request_date")
            lblremain_date_from.Text = DR.Item("remain_date_from")
            lblRemain_date_to.Text = DR.Item("remain_date_to")
            lblMonth1_from.Text = DR.Item("month1_from")
            lblMonth1_to.Text = DR.Item("month1_to")
            lblMonth2_from.Text = DR.Item("month2_from")
            lblMonth2_to.Text = DR.Item("month2_to")
            lblMonth3_from.Text = DR.Item("month3_from")
            lblMonth3_to.Text = DR.Item("Month3_to")
            txtReqEdit.Text = DR.Item("request_date")
            lblUpdateV.Text = DR.Item("plan_rev_no")
            '
            SortData()
            GrpCtrDetil.Enabled = True
            TabControl1.SelectTab(1)
            SetPlantReqInisial()
        Else
            MsgBox("Maaf Data Set Plant Tidak ada ", vbInformation, "Informasi")
            Bukakunci()
            OptUbah.Checked = False
            Exit Sub
        End If
        '
        Tglreq = lblTglAwal.Text
        txtReqEdit.Text = Format(Tglreq, "dd/MMMM/yyyy")
        KonIstem.Close()
        BtnTmbhBrs_Click(sender, New System.EventArgs)
        '
        txtinp_awalTtl.Text = ""
        txtdlvdt1ttl.Text = ""
        txtinp_pr1dtTtl.Text = ""
        txtdlvdt2Ttl.Text = ""
        txtinp_pr2dtTtl.Text = ""
        txtdlvdt3Ttl.Text = ""
        txtinp_pr3dtTtl.Text = ""
        '
        DGV_edit2.ReadOnly = True
    End Sub
    Private Sub txtInpperiod1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles txtInpperiod1.LostFocus
        Try
          
            If CInt(txtInpperiod1.Text) < CInt(txtDlvperiod1.Text) Then
                MsgBox("Angka Input tidak boleh lebih kecil dari Angka Delivery", vbInformation, "Informasi")
                txtInpperiod1.Focus()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtInpperiod2_LostFocus(sender As Object, e As EventArgs) Handles txtInpperiod2.LostFocus
        Try
            If CInt(txtInpperiod2.Text) < CInt(txtDlvperiod2.Text) Then
                MsgBox("Angka Input tidak boleh lebih kecil dari Angka Delivery", vbInformation, "Informasi")
                txtInpperiod2.Focus()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtInpperiod3_LostFocus(sender As Object, e As EventArgs) Handles txtInpperiod3.LostFocus
        Try
            If CInt(txtInpperiod3.Text) < CInt(txtDlvperiod3.Text) Then
                MsgBox("Angka Input tidak boleh lebih besar dari Angka Delivery", vbInformation, "Informasi")
                txtInpperiod3.Focus()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtinp_pr1dt_LostFocus(sender As Object, e As EventArgs) Handles txtinp_pr1dt.LostFocus
        Try
            If CInt(txtinp_pr1dt.Text) < CInt(txtdlvdt1.Text) Then
                MsgBox("Angka Input tidak boleh lebih Kecil dari Angka Delivery", vbInformation, "Informasi")
                txtinp_pr1dt.Focus()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub txtinp_pr2dt_LostFocus(sender As Object, e As EventArgs) Handles txtinp_pr2dt.LostFocus
        Try
            If CInt(txtinp_pr2dt.Text) < CInt(txtdlvdt2.Text) Then
                MsgBox("Angka Input tidak boleh lebih Kecil dari Angka Delivery", vbInformation, "Informasi")
                txtinp_pr2dt.Focus()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
     
    End Sub

    Private Sub txtinp_pr3dt_LostFocus(sender As Object, e As EventArgs) Handles txtinp_pr3dt.LostFocus
        'KunciDetil
        Try
            If CInt(txtinp_pr3dt.Text) < CInt(txtdlvdt3.Text) Then
                MsgBox("Angka Input tidak boleh lebih Kecil dari Angka Delivery", vbInformation, "Informasi")
                txtinp_pr3dt.Focus()
            End If
        Catch ex As Exception
            'MessageBox.Show(ex.Message)
        End Try
    End Sub
         
    Private Sub BtnTmbhBrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTmbhBrs.Click
        ' Dim i As Integer
        '
        DGV_edit2.Columns(0).Width = 80
        DGV_edit2.Columns(1).Width = 80
        DGV_edit2.Columns(2).Width = 80
        DGV_edit2.Columns(3).Width = 110
        DGV_edit2.Columns(4).Width = 90
        DGV_edit2.Columns(5).Width = 85
        DGV_edit2.Columns(6).Width = 85
        DGV_edit2.Columns(7).Width = 90
        DGV_edit2.Columns(8).Width = 85
        DGV_edit2.Columns(9).Width = 90
        ' 
        DGV_edit2.Columns(0).ReadOnly = True
        DGV_edit2.Columns(1).ReadOnly = True
        'DGV_edit2.Columns(9).Visible = False
        'Rmdfrm, M1dv, M1ip, M2dv, M2ip, M3dv, M3ip,
        For Each row As DataGridViewRow In DGV_edit.Rows
            If Not row.IsNewRow Then
                '
                Ktgri = row.Cells(0).Value.ToString
                greynoedit = row.Cells(1).Value.ToString
                StsGf = row.Cells(2).Value.ToString
                RMD2 = row.Cells(3).Value.ToString
                Mt1dv = row.Cells(4).Value.ToString
                Mt1ip = row.Cells(5).Value.ToString
                Mt2dv = row.Cells(6).Value.ToString
                Mt2ip = row.Cells(7).Value.ToString
                Mt3dv = row.Cells(8).Value.ToString
                Mt3ip = row.Cells(9).Value.ToString
                '
                DGV_edit2.Rows.Add(greynoedit)
                '   '
                For barisatas As Integer = 0 To DGV_edit2.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To DGV_edit2.RowCount - 1
                    Next
                Next
                '
                DGV_edit2(0, DGV_edit2.RowCount - 2).Value = Ktgri
                DGV_edit2(1, DGV_edit2.RowCount - 2).Value = greynoedit
                DGV_edit2(2, DGV_edit2.RowCount - 2).Value = StsGf
                '
                DGV_edit2(3, DGV_edit2.RowCount - 2).Value = RMD2 'txtInpperiod1.Text
                DGV_edit2(4, DGV_edit2.RowCount - 2).Value = Mt1dv 'txtDlvperiod1.Text
                'txtDlvperiod1
                DGV_edit2(5, DGV_edit2.RowCount - 2).Value = Mt1ip 'txtInpperiod2.Text
                DGV_edit2(6, DGV_edit2.RowCount - 2).Value = Mt2dv 'txtDlvperiod2.Text
                'txtDlvperiod2
                DGV_edit2(7, DGV_edit2.RowCount - 2).Value = Mt2ip 'txtInpperiod3.Text
                DGV_edit2(8, DGV_edit2.RowCount - 2).Value = Mt3dv 'txtDlvperiod3.Text
                DGV_edit2(9, DGV_edit2.RowCount - 2).Value = Mt3ip 'txtDlvperiod3.Text
            End If
        Next
    End Sub
    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        For Each row As DataGridViewRow In DGV_edit2.Rows
            If Not row.IsNewRow Then
                '
                Ktgri = row.Cells(0).Value.ToString
                greynoedit = row.Cells(1).Value.ToString
                StsGf = row.Cells(2).Value.ToString
                RMD2 = row.Cells(3).Value.ToString
                Mt1dv = row.Cells(4).Value.ToString
                Mt1ip = row.Cells(5).Value.ToString
                Mt2dv = row.Cells(6).Value.ToString
                Mt2ip = row.Cells(7).Value.ToString
                Mt3dv = row.Cells(8).Value.ToString
                Mt3ip = row.Cells(9).Value.ToString
                '
                CekInputData()
                'DGV_edit2.Rows.Add(greynoedit)
                '   '
            End If
        Next
    End Sub

    Private Sub BtnSimpanBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpanBaru.Click
        Using KonIstem As New SqlConnection(ConStringISTEM)
            Try
                SimpanNewData()
                Dim CMDSimpan As New SqlCommand(SimpanData, KonIstem)
                '
                CMDSimpan.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                '
                CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
                CMDSimpan.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
                CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))

                'CMDSimpan.Parameters.Add(New SqlParameter("@send_date", SqlDbType.Date))
                '
                CMDSimpan.Parameters.Add(New SqlParameter("@item_category", SqlDbType.Char))
                CMDSimpan.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
                CMDSimpan.Parameters.Add(New SqlParameter("@garment_flag", SqlDbType.Char))
                CMDSimpan.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
                CMDSimpan.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
                CMDSimpan.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
                ''
                CMDSimpan.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
                CMDSimpan.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
                CMDSimpan.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
                CMDSimpan.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
                '
                CMDSimpan.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
                CMDSimpan.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
                CMDSimpan.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
                CMDSimpan.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
                ''
                CMDSimpan.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
                CMDSimpan.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
                CMDSimpan.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
                CMDSimpan.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
                'CMDSimpan.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
                '
                CMDSimpan.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
                CMDSimpan.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                '
                CMDSimpan.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                CMDSimpan.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
                CMDSimpan.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
                CMDSimpan.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
                '
                KonIstem.Open()
                TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
                CMDSimpan.Transaction = TR
                'plan_rev_no,plan_rev_date
                CMDSimpan.Parameters("@plan_month").Value = TxtHasilModif.Text
                CMDSimpan.Parameters("@request_date").Value = Convert.ToDateTime(lblTglAwal.Text)
                CMDSimpan.Parameters("@grey_no").Value = greynoedit  'row.Cells(0).Value.ToString 'txtGreyNo.Text 'hasilgreyno
                '
                CMDSimpan.Parameters("@plan_rev_no").Value = "1"
                CMDSimpan.Parameters("@plan_rev_date").Value = Convert.ToDateTime(lblTglAwal.Text)
                CMDSimpan.Parameters("@garment_flag").Value = StsGf  'row.Cells(1).Value.ToString
                '
                CMDSimpan.Parameters("@remain_input_qty").Value = RMD2 'row.Cells(2).Value.ToString
                CMDSimpan.Parameters("@remain_date_from").Value = Hasilfrmperiodawal
                CMDSimpan.Parameters("@remain_date_to").Value = HasilperiodTo
                ''
                CMDSimpan.Parameters("@month1_from").Value = Convert.ToDateTime(lblMonth1_from.Text)
                CMDSimpan.Parameters("@month1_to").Value = Convert.ToDateTime(lblMonth1_to.Text)
                CMDSimpan.Parameters("@month1_deliv_qty").Value = Mt1dv   'row.Cells(3).Value.ToString 'DGV.Rows(i).Cells(2).FormattedValue
                CMDSimpan.Parameters("@month1_input_qty").Value = Mt1ip   'row.Cells(4).Value.ToString 'DGV.Rows(i).Cells(3).FormattedValue
                '
                CMDSimpan.Parameters("@month2_from").Value = Convert.ToDateTime(lblMonth2_from.Text)
                CMDSimpan.Parameters("@month2_to").Value = Convert.ToDateTime(lblMonth2_to.Text)
                CMDSimpan.Parameters("@month2_deliv_qty").Value = Mt2dv  'row.Cells(5).Value.ToString 'DGV.Rows(i).Cells(4).FormattedValue
                CMDSimpan.Parameters("@month2_input_qty").Value = Mt2ip  'row.Cells(6).Value.ToString 'DGV.Rows(i).Cells(5).FormattedValue
                ''
                CMDSimpan.Parameters("@month3_from").Value = Convert.ToDateTime(lblMonth3_from.Text)
                CMDSimpan.Parameters("@month3_to").Value = Convert.ToDateTime(lblMonth3_to.Text)
                CMDSimpan.Parameters("@month3_deliv_qty").Value = Mt3dv  'row.Cells(7).Value.ToString 'DGV.Rows(i).Cells(6).FormattedValue
                CMDSimpan.Parameters("@month3_input_qty").Value = Mt3ip  'row.Cells(8).Value.ToString 'DGV.Rows(i).Cells(7).FormattedValue
                CMDSimpan.Parameters("@item_category").Value = Ktgri  'row.Cells(9).Value.ToString
                ' CMDSimpan.Parameters("@request_version").Value = "1"
                '
                CMDSimpan.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                CMDSimpan.Parameters("@rec_sts").Value = "A"
                CMDSimpan.Parameters("@proc_no").Value = "1"
                CMDSimpan.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                CMDSimpan.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                CMDSimpan.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                '
                CMDSimpan.ExecuteNonQuery()
                TR.Commit()
            Catch ex As Exception
                Try
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                Catch rollBackEx As Exception
                    MessageBox.Show(rollBackEx.Message)
                End Try
            End Try
        End Using
    End Sub

    Private Sub BtnSimpanUbah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpanUbah.Click
        Try
            SimpanEditData()
            Dim CMDUbahdetil As New SqlCommand(Ubahdata, KonIstem)
            '
            CMDUbahdetil.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            '
            'CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
            'CMDSimpan.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
            'CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))

            'CMDSimpan.Parameters.Add(New SqlParameter("@send_date", SqlDbType.Date))
            '
            CMDUbahdetil.Parameters.Add(New SqlParameter("@item_category", SqlDbType.Char))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@garment_flag", SqlDbType.Char))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@remain_input_qty", SqlDbType.Int))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@remain_date_from", SqlDbType.Date))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@remain_date_to", SqlDbType.Date))
            ''
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month1_from", SqlDbType.Date))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month1_to", SqlDbType.Date))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month1_input_qty", SqlDbType.Int))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month1_deliv_qty", SqlDbType.Int))
            '
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month2_from", SqlDbType.Date))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month2_to", SqlDbType.Date))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month2_input_qty", SqlDbType.Int))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month2_deliv_qty", SqlDbType.Int))
            ''
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month3_from", SqlDbType.Date))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month3_to", SqlDbType.Date))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month3_input_qty", SqlDbType.Int))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@month3_deliv_qty", SqlDbType.Int))
            'CMDSimpan.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
            '
            CMDUbahdetil.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            '
            CMDUbahdetil.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
            CMDUbahdetil.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
            '
            KonIstem.Open()
            TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
            CMDUbahdetil.Transaction = TR
            '
            CMDUbahdetil.Parameters("@plan_month").Value = TxtHasilModif.Text
            'CMDSimpan.Parameters("@request_date").Value = Convert.ToDateTime(lblTglAwal.Text)
            CMDUbahdetil.Parameters("@grey_no").Value = txtGreyNo.Text 'row.Cells(0).Value.ToString 'txtGreyNo.Text 'hasilgreyno
            '
            CMDUbahdetil.Parameters("@garment_flag").Value = StsGf 'row.Cells(1).Value.ToString
            '
            CMDUbahdetil.Parameters("@remain_input_qty").Value = RMD2 'row.Cells(2).Value.ToString
            CMDUbahdetil.Parameters("@remain_date_from").Value = Hasilfrmperiodawal
            CMDUbahdetil.Parameters("@remain_date_to").Value = HasilperiodTo
            ''
            CMDUbahdetil.Parameters("@month1_from").Value = Convert.ToDateTime(lblMonth1_from.Text)
            CMDUbahdetil.Parameters("@month1_to").Value = Convert.ToDateTime(lblMonth1_to.Text)
            CMDUbahdetil.Parameters("@month1_deliv_qty").Value = Mt1dv  'row.Cells(3).Value.ToString 'DGV.Rows(i).Cells(2).FormattedValue
            CMDUbahdetil.Parameters("@month1_input_qty").Value = Mt1ip  ' row.Cells(4).Value.ToString 'DGV.Rows(i).Cells(3).FormattedValue
            '
            CMDUbahdetil.Parameters("@month2_from").Value = Convert.ToDateTime(lblMonth2_from.Text)
            CMDUbahdetil.Parameters("@month2_to").Value = Convert.ToDateTime(lblMonth2_to.Text)
            CMDUbahdetil.Parameters("@month2_deliv_qty").Value = Mt2dv 'row.Cells(5).Value.ToString 'DGV.Rows(i).Cells(4).FormattedValue
            CMDUbahdetil.Parameters("@month2_input_qty").Value = Mt2ip 'row.Cells(6).Value.ToString 'DGV.Rows(i).Cells(5).FormattedValue
            ''
            CMDUbahdetil.Parameters("@month3_from").Value = Convert.ToDateTime(lblMonth3_from.Text)
            CMDUbahdetil.Parameters("@month3_to").Value = Convert.ToDateTime(lblMonth3_to.Text)
            CMDUbahdetil.Parameters("@month3_deliv_qty").Value = Mt3dv 'row.Cells(7).Value.ToString 'DGV.Rows(i).Cells(6).FormattedValue
            CMDUbahdetil.Parameters("@month3_input_qty").Value = Mt3ip  'row.Cells(8).Value.ToString 'DGV.Rows(i).Cells(7).FormattedValue
            CMDUbahdetil.Parameters("@item_category").Value = Ktgri 'row.Cells(9).Value.ToString                            ' CMDSimpan.Parameters("@request_version").Value = "1"
            '
            CMDUbahdetil.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
            CMDUbahdetil.Parameters("@rec_sts").Value = "T"
            '
            CMDUbahdetil.Parameters("@proc_no").Value = "2"
            CMDUbahdetil.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
            CMDUbahdetil.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
            CMDUbahdetil.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
            '
            CMDUbahdetil.ExecuteNonQuery()
            '
            TR.Commit()
        Catch ex As Exception
            Try
                TR.Rollback()
                MessageBox.Show(ex.Message)
            Catch rollBackEx As Exception
                MessageBox.Show(rollBackEx.Message)
            End Try
        End Try
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        Dim Dt As New DataTable
        '
        With Dt
            .Columns.Add("grey_no")
            .Columns.Add("item_category")
            .Columns.Add("remain_input_qty")
            .Columns.Add("month1_deliv_qty")
            .Columns.Add("month1_input_qty")
            .Columns.Add("month2_deliv_qty")
            .Columns.Add("month2_input_qty")
            .Columns.Add("month3_deliv_qty")
            .Columns.Add("month3_input_qty")
            .Columns.Add("garment_flag")
        End With
        Try
            For Each row As DataGridViewRow In DGV_edit2.Rows
                Dt.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, row.Cells(7).Value, row.Cells(8).Value, row.Cells(9).Value)
            Next
            '
            'Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
            'rptDoc = New CRSalesReq
            ' rptDoc.SetDataSource(Dt)
            '
            'frmRptPrint.CrystalReportViewer1.ReportSource = rptDoc
            '.ReportSource = rptDoc
            frmRptPrint.ShowDialog()
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '
    End Sub

    Private Sub DGV_edit2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_edit2.CellFormatting
        DGV_edit2.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub DGV_edit2_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_edit2.CellEndEdit
        Try
            '
            'If DGV.Rows(e.RowIndex).Cells(2).Value < DGV.Rows(e.RowIndex).Cells(3).Value Then
            If CDbl(DGV_edit2.Rows(e.RowIndex).Cells(3).Value) < CDbl(DGV_edit2.Rows(e.RowIndex).Cells(4).Value) Then
                MsgBox("Data Input Tidak Boleh lebih Kecil Dari Delivery")
                Exit Sub
            End If
            If CDbl(DGV_edit2.Rows(e.RowIndex).Cells(5).Value) < CDbl(DGV_edit2.Rows(e.RowIndex).Cells(6).Value) Then
                MsgBox("Data Input Tidak Boleh lebih Kecil Dari Delivery")
                Exit Sub
            End If
            If CDbl(DGV_edit2.Rows(e.RowIndex).Cells(9).Value) < CDbl(DGV_edit2.Rows(e.RowIndex).Cells(8).Value) Then
                MsgBox("Data Input Tidak Boleh lebih Kecil Dari Delivery")
                Exit Sub
            End If
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BtnView2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView2.Click
        Dim DSP As New DSReqSalesEntry 'DSSalesEntry
        Dim objRpt As New CRSalesReqEntry 'CRSalesReq
        '
        KoneksiISTEM()
        KonIstem.Open()
        ' order by item_category desc,LEFT(grey_no,2) asc
        Try
            Sql = "Select * from sl_grey_request where plan_month='" & (cmbPlanMonth.Text) & "' order by item_category desc,LEFT(grey_no,2) asc"
            DA = New SqlDataAdapter(Sql, KonIstem)
            DA.Fill(DS, "sl_grey_request")
            DT = DS.Tables("sl_grey_request")
            KonIstem.Close()
            '
            objRpt.SetDataSource(DS.Tables(1))
            frmPrintSalesReq.CrystalReportViewer1.ReportSource = objRpt
            frmPrintSalesReq.CrystalReportViewer1.Refresh()
            'frmPrintSalesReq.CrystalReportViewer1.ShowCopyButton = False
            'frmPrintSalesReq.CrystalReportViewer1.ShowGroupTreeButton = False
            'frmPrintSalesReq.CrystalReportViewer1.ShowParameterPanelButton = False
            frmPrintSalesReq.ShowDialog()
            objRpt.Close()
            objRpt.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub CekdataSendWV()
        KoneksiISTEM()
        'KonIstem.Close()
        KonIstem.Open()
        ''
        'KonIstem.Open()
        CmdCaridata = New SqlCommand("Select* from sl_grey_request where plan_month= '" & (cmbPlanMonth.Text) & "'", KonIstem)
        DR = CmdCaridata.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            NilaiSdate = DR.Item("send_date")
        End If
        '
        If NilaiSdate = "1/1/1900" Then
            StatusSend = False
        Else
            StatusSend = True
        End If
        '
        'KonIstem.Close()
    End Sub
    Private Sub BtnSendWV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSendWV.Click
        KoneksiISTEM()
        KonIstem.Open()
        '
        If cmbPlanMonth.Text = "" Then
            MessageBox.Show("Maaf Data Plan Month Dalam Keadaan Kosong")
            Exit Sub
        End If
        '
        CekdataSendWV()
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            If MessageBox.Show("Yakin akan di update datanya ...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                If StatusSend = False Then
                    Ubahdata = "Update sl_grey_request set send_date=@send_date,plan_rev_no=@plan_rev_no where plan_month ='" & (cmbPlanMonth.Text) & "'"
                Else
                    Ubahdata = "Update sl_grey_request set plan_rev_no=@plan_rev_no where plan_month ='" & (cmbPlanMonth.Text) & "'"
                End If
                '
                Dim i As Integer
                If CInt(lblUpdateV.Text) = 1 Then
                    i = CInt(lblUpdateV.Text) + 1
                Else
                    i = CInt(lblUpdateV.Text) + 1
                End If
                Dim CMD As New SqlCommand(Ubahdata, KonIstem)
                'Convert.ToDateTime(Menu_Utama.TSlblTanggal.Text)
                If StatusSend = False Then
                    CMD.Parameters.Add(New SqlParameter("@send_date", SqlDbType.Date))
                    CMD.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
                Else
                    CMD.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
                End If
                KonIstem.Open()
                '
                TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
                CMD.Transaction = TR
                Try
                    If StatusSend = False Then
                        CMD.Parameters("@send_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                        CMD.Parameters("@plan_rev_no").Value = i
                    Else
                        CMD.Parameters("@plan_rev_no").Value = i
                    End If
                    '
                    CMD.ExecuteNonQuery()
                    TR.Commit()
                    MessageBox.Show("Data Berhasil", "Informasi")
                Catch ex As Exception
                    Try
                        TR.Rollback()
                        MessageBox.Show(ex.Message)
                    Catch rollBackEx As Exception
                        MessageBox.Show(rollBackEx.Message)
                    End Try
                End Try
            End If
            SortData()
        End Using
        KonIstem.Close()
        ''Kunci()
        'Bukakunci()
        'BukaKunciDetil()
        'BtnTmbhDtl.Enabled = False
        'BtnSimpan_dtl.Enabled = False
        'BtnUbah_dtl.Enabled = False
        'BtnBatal_dtl.Enabled = False
        'BtnDelete.Enabled = False
        'BtnUpdateV.Enabled = False
    End Sub

End Class
