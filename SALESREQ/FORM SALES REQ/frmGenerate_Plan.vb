Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Imports System.IO
Imports System.Data.OleDb

Public Class frmGenerate_Plan
    '
    Dim KurangTgl, Ulangdata As Boolean
    Dim SimpanData, UpdateV, Jumlahrec As String
    Dim sql, Updatereport, GreyEdit As String
    '
    Dim TPCS, TMTR, TLGT As Double
    Dim Remindfromawal, Remindfrom1, Remindtoawal, Remindtoperiod1, Remindtoperiod2, Remindtoperiod3 As Date
    Dim NilaiBulan, lblRemindtoperiodawal, lblRemindtoperiod1, lblRemindtoperiod2, lblRemindtoperiod3 As String
    Dim Nilaifrmperiod1, Nilaifrmperiod2, Nilaifrmperiod3, Tglrequest, TglUpdate As Date
    '
    Dim NilaiM1per1to, NilaiM1per1frm, NilaiM2per1to, NilaiM2per1frm, NilaiM3per1to, NilaiM3per1frm As Date
    Dim NilaiM1per2to, NilaiM1per2frm, NilaiM2per2to, NilaiM2per2frm, NilaiM3per2to, NilaiM3per2frm As Date
    '
    Dim Nilaitoperiod1, Nilaitoperiod2, Nilaitoperiod3, Nilaitoperiodfrm, NilaiRmdfrm As Date
    Dim Remindfrmperiod1, Remindfrmperiod2, Remindfrmperiod3 As Date
    Dim HasilperiodTo, NilaiRequestdate, Hasilfrmperiodawal, Hasilfrmperiod1, Hasilfrmperiod2, Hasilfrmperiod3 As Date
    Dim HasilRemindawalfrm, HasilRemindawalto, HasilRm1 As Date
    Dim HasilM2Period1frm, HasilM3Period1frm, HasilM2Period1to, HasilM3Period1to As Date
    Dim HasilM2Period2frm, HasilM3Period2frm, HasilM2Period2to, HasilM3Period2to As Date
    Dim HasilM1frmperiod2, HasilM2frmperiod2, HasilM3frmperiod2 As Date
    Dim HasilM1per1frm, HasilM2per1frm, HasilM3per1frm As Date
    Dim HasilToPeriod1, HasilToPeriod2, HasilToPeriod3 As Date
    Dim lblRemindfrmperiodawal, lblRemindfrmperiod1, lblRemindfrmperiod2, lblRemindfrmperiod3 As String
    
    Dim HasilReminWD, HasilM1, HasilM2, HasilM3 As Integer
    Dim NilaiTanggal As Date
    Dim Statusgen3 As Boolean
    'Variabel baru
    Dim lblRemdP1from, lblRemdP1to As String
    Dim HasilRemP1from, HasilRemP1to, HasilRemP2from, HasilRemP2to As Date
    Dim lblRemdP2from, lblRemdP2to As String
    Dim NilaiRemP1from, NilaiRemP1to, NilaiawalRem As Date
    Dim NilaiRemP2from, NilaiRemP2to As Date
    Dim GreyNo, GreyNoedit, Gflag, Planmonthedit, LoomModel As String
    Dim NilaiPCS, JWip3 As Double
    ' Dim lblRemindtoperiodawal, lblRemindtoperiod1, lblRemindtoperiod2, lblRemindtoperiod3 As String
    '
    Dim CMD As New SqlCommand
    Dim CMDCARI As New SqlCommand
    Dim CMDEDIT As New SqlCommand
    Dim CMDHEADER As New SqlCommand
    Dim CMDDETIL1 As New SqlCommand
    Dim CMDDETIL2 As New SqlCommand
    Dim CMDDETIL3 As New SqlCommand
    '
    Dim KonEx As OleDbConnection
    Dim ContEx As OleDbDataAdapter
    Dim CMDEx As OleDbCommand
    Dim DAex As OleDbDataAdapter
    Dim DSex As DataSet
    '
    Dim NTga, NTgb, NTgc, NTgd As Date
    Dim i, Hrawal, Hr1, Hr2, Hr3, Nilaiawal, Nilai1, Nilai2, Nilai3 As Integer
    Dim Bulanprdawal, Bulanprd1, Bulanprd2, Bulanprd3 As Date
    Dim Hasilawal, Hasil1, Hasil2, Hasil3 As Date
    Dim NilaiTglawal, NilaiTgl1, NilaiTgl2, NilaiTgl3 As String
    Dim NilaiBulansatu, NilaiTglakhirprd1, NilaiTglakhirprd2, NilaiTglakhirprd3, Tglawal, Tgl1, Tgl2, Tgl3 As Date
    Dim NilaiTanggalawal, NilaiTanggal1, NilaiTanggal2, NilaiTanggal3 As Date
    Dim EditWip3 As Boolean
    Dim StatusHeader, StatusUpload As Boolean
    '
    Dim Tgljadi As Date
    Dim Harilibur As Boolean
    '
    Dim Length3 As Double
    Dim Greyp3 As String
    Dim b, y, z As Integer
    Dim iMax As Integer = 6
    Dim CMDM1, CMDM2, CMDM3 As New SqlCommand
    Dim TanggalHitung As Date
    Dim TR As SqlTransaction
    Dim HasilTgl, HasilTgl1, HasilTgl2, HasilTgl3, HasilTgl3frm As String

    Private Sub BgdWkr1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BgdWkr1.DoWork
        Dim b As Integer
        z = 0
        y = 0
        PrgBar1.Maximum = iMax
        For b = 1 To iMax
            If BgdWkr1.CancellationPending Then
                e.Cancel = True
                Exit For
            Else
                PrgBar1.Value = y
                y = y + 1
                ' Masukan Rumus Perhitungan diini
                Select Case y
                    Case "1"
                        ' z = 1
                        BtnProses1_Click(sender, New System.EventArgs)
                    Case "2"
                        '    z = 2
                        If StatusHeader = False Then
                            BtnProses2_Click(sender, New System.EventArgs)
                        End If
                    Case "3"
                        '    'z = 3
                        If StatusHeader = False Then
                            BtnProses3_Click(sender, New System.EventArgs)
                        End If
                    Case "4"
                        ' z = 4
                        If StatusHeader = False Then
                            BtnProses47_Click(sender, New System.EventArgs)
                        End If
                        'BtnGen5_Click(sender, New System.EventArgs)
                        'BtnProses4_Click(sender, New System.EventArgs)
                    Case "5"
                        If StatusHeader = False Then
                            BtnProses51_Click(sender, New System.EventArgs)
                        End If
                        'BtnProses41_Click(sender, New System.EventArgs)
                    Case "6"
                        If StatusHeader = False Then
                            BtnGen5_Click(sender, New System.EventArgs)
                        End If
                        '    'BtnProses43_Click(sender, New System.EventArgs)
                        '    'BtnProses42_Click(sender, New System.EventArgs)
                        'Case "7"
                        '    'BtnProses44_Click(sender, New System.EventArgs)
                        '    'BtnProses42_Click(sender, New System.EventArgs)
                        'Case "8"
                        '    'BtnProses45_Click(sender, New System.EventArgs)
                        '    'BtnProses42_Click(sender, New System.EventArgs)
                        'Case "9"
                        '    'BtnProses46_Click(sender, New System.EventArgs)
                        '    'BtnProses42_Click(sender, New System.EventArgs)
                        'Case "10"
                        '    'BtnProses42_Click(sender, New System.EventArgs)
                End Select
                '
                BgdWkr1.ReportProgress(y)
                System.Threading.Thread.Sleep(1000)
            End If
            If PrgBar1.Maximum = y Then
                PrgBar1.Value = 0
                y = 0
            End If
            'b = 1
        Next b
        '
        MessageBox.Show("Proses Telah Selesai")
        '
        txtFile.Text = ""
        BtnGenAll.Enabled = True
        BtnKeluar.Enabled = True
    End Sub

    Private Sub BgdWkr1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BgdWkr1.ProgressChanged
        Me.PrgBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BgdWkr1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BgdWkr1.RunWorkerCompleted
        If e.Cancelled Then
            ' Me.Status.Text = "Dibatalkan"
            PrgBar1.Value = 0
            Me.BtnGenAll.Enabled = True
            Me.BtnKeluar.Enabled = True
        End If
    End Sub
    Private Sub BtnGenAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnGenAll.Click
        '
        If cmbPlanMonthedit.Text = "" Then
            MessageBox.Show("Maaf Data Plan Month belum dipilih")
            Exit Sub
        End If
        'BukadataGreyStok2()
        ' jika sudah ada di wv_prod_plan_header berarti tidak perlu di upload lagi excelnya
        CekProdPlanHeader()
        'CekLoomEff()
        '
        If StatusHeader = False Then
            BtnUpload_Click(sender, New System.EventArgs)
        End If
        '
        If StatusHeader = True And StatusUpload = True Then
            Me.BtnGenAll.Enabled = False
            Me.BtnKeluar.Enabled = False
            '
            BgdWkr1.RunWorkerAsync()
        ElseIf StatusHeader = True And StatusUpload = False Then
            Me.BtnGenAll.Enabled = False
            Me.BtnKeluar.Enabled = False
            '
            BgdWkr1.RunWorkerAsync()
        ElseIf StatusHeader = False And StatusUpload = True Then
            Me.BtnGenAll.Enabled = False
            Me.BtnKeluar.Enabled = False
            '
            BgdWkr1.RunWorkerAsync()
        Else
            Exit Sub
        End If
        ''
    End Sub
    Sub CekProdPlanHeader()
        '
        KoneksiCIM()
        KonCIM.Open()
        '      
        CMD = New SqlCommand("Select * from wv_prod_plan_header where plan_month='" & (cmbPlanMonthedit.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            StatusHeader = True
        End If
    End Sub
    Sub CekLoomEff()
        '
        KoneksiCIM()
        KonCIM.Open()
        '      
        CMDCARI = New SqlCommand("Select * from wv_loom_eff where plan_month='" & (cmbPlanMonthedit.Text) & "'", KonCIM)
        DR = CMDCARI.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            StatusHeader = True
        End If

    End Sub

    Sub Buka_DataComboPlan()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        Try
            'DGV.ReadOnly = True
            DA = New SqlDataAdapter("Select distinct[plan_month] From sl_grey_request", KonIstem)
            DA.Fill(DS, "sl_grey_request")
            '
            CMD = New SqlCommand(MPlan, KonIstem)
            DR = CMD.ExecuteReader
            cmbPlanMonthedit.Items.Clear()
            Do While DR.Read
                cmbPlanMonthedit.Items.Add(DR.Item(0))
            Loop
            KonIstem.Close()
            DR.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Sub BukaDataFabbricAnalys()
        KoneksiCIM()
        KonCIM.Open()
        '      
        CMD = New SqlCommand("Select grey_no, weft_gr,length_gr, eff_loom from wv_fabric_analysis_master where grey_no ='" & (txtGreyno.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            lbleff.Text = DR.Item("eff_loom")
            lblwef.Text = DR.Item("weft_gr")
            'Menambahkan length Untuk prodday_pcs
            lbllength_grey.Text = DR.Item("length_gr")
            'lblJmlGrey.Text = Str(DR.Item("Jumlah"))
        Else
            lbleff.Text = "0"
            lblwef.Text = "0"
        End If
        KonCIM.Close()
    End Sub
  
    'Sub DataWVInput()
    '    KoneksiCIM()
    '    KonCIM.Open()
    '    '      
    '    CMD = New SqlCommand("Select plan_version from wv_loom_eff where plan_month ='" & (cmbPlanMonthedit.Text) & "'", KonCIM)
    '    DR = CMD.ExecuteReader
    '    DR.Read()
    '    '
    '    If DR.HasRows Then
    '        Updatereport = DR.Item("plan_version")
    '        'lblJmlGrey.Text = Str(DR.Item("Jumlah"))
    '    Else
    '        Updatereport = "1"
    '    End If
    '    '
    '    CMDEDIT = New SqlCommand("Select count(plan_version)as Jumlah from wv_loom_eff where plan_month ='" & (cmbPlanMonthedit.Text) & "'", KonCIM)
    '    DREDIT = CMDEDIT.ExecuteReader
    '    DREDIT.Read()
    '    '
    '    If DREDIT.HasRows Then
    '        Jumlahrec = DREDIT.Item("Jumlah")
    '    Else
    '        Jumlahrec = "1"
    '    End If
    '    '
    '    KonCIM.Close()
    'End Sub
    Sub CekdataShift()
        ' fungsi buat di bagian data
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select * from wv_ajl_shift_detail where Prod_Date = '" & (Tgljadi) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        Try
            If DR.HasRows Then
                lblTimeShift.Text = DR.Item("Shift_Time")
                'DtpTanggal.Value = DR.Item("request_date")
            End If
            '
            TanggalHitung = DtpTanggal.Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub BukaDataSalesGrey()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        CMD = New SqlCommand("Select grey_no as Grey_No,request_date from sl_grey_request where plan_month = '" & (cmbPlanMonthedit.Text) & "'", KonIstem)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        Try
            If DR.HasRows Then
                DtpTanggal.Value = DR.Item("request_date")
            End If
            '
            TanggalHitung = DtpTanggal.Value
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    'Sub BukaDataProses()
    '    KoneksiCIM()
    '    KonCIM.Open()
    '    ''      
    '    DA = New SqlDataAdapter("Select grey_no,loom_model,rpm,density,eff,prod_day_mtr from wv_loom_eff where plan_month = '" & (cmbPlanMonthedit.Text) & "' ", KonCIM)
    '    DS = New DataSet
    '    Try
    '        DA.Fill(DS)
    '        '
    '        DGVView.DataSource = DS.Tables(0)
    '        KonCIM.Close()
    '        DGVView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        '
    '        DGVView.ReadOnly = True
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Sub
    Sub BukaDataWV()
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select Loom_No from wv_ajl_efficiency_detail where grey_no ='" & (txtGreyno.Text) & "' and (Production_Date) = '" & (DtpTanggal.Value) & "' ORDER BY Production_Date DESC", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            lblLoomNo.Text = DR.Item("Loom_No")
        End If
        'TextBox3.Text = Microsoft.VisualBasic.Mid(nilaiawal, 3, 6)
        lblKodeLm.Text = Microsoft.VisualBasic.Left(lblLoomNo.Text, 1)
        lblNoLm.Text = Microsoft.VisualBasic.Right(lblLoomNo.Text, 3)
        KonCIM.Close()
        '
    End Sub
    Sub BukaMesinMaster()
        'Dim klm1, klm2 As String
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select loom_model from machine_master where block ='" & (lblKodeLm.Text) & "' and (loom_no) = '" & (lblNoLm.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            lblLmModel.Text = DR.Item("loom_model")
        End If
        KonCIM.Close()
        '
    End Sub
    Sub HitungDataGrey()
        KoneksiCIM()
        KonCIM.Open()
        '
        'CMD = New SqlCommand("Select COUNT(Grey_No)as Jumlah from wv_ajl_efficiency_detail where grey_no ='" & (txtGreyno.Text) & "' and (Production_Date) = '" & (DtpTanggal.Value) & "'", KonCIM)
        sql = "Select COUNT(t0.RPM) AS Jumlah from wv_ajl_efficiency_detail " & vbCrLf & _
              "t0 left join machine_master t1 on t0.Loom_No=t1.block+t1.loom_no where Production_Date='" & (DtpTanggal.Value) & "' AND t0.Grey_No='" & (txtGreyno.Text) & "' and t1.loom_model='" & (LoomModel) & "' and t0.rpm >0"
        CMD = New SqlCommand(sql, KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            lblJmlGrey.Text = Str(DR.Item("Jumlah"))
        Else
            lblJmlGrey.Text = "0"
        End If
        '
        If lblJmlGrey.Text = "Null" Then
            lblJmlGrey.Text = "0"
        End If
        KonCIM.Close()
    End Sub
    Sub HitungRPM()
        KoneksiCIM()
        KonCIM.Open()
        ''      
        'CMD = New SqlCommand("Select SUM(RPM) as JumlahRPM from wv_ajl_efficiency_detail where grey_no ='" & (txtGreyno.Text) & "' and (Production_Date) = '" & (DtpTanggal.Value) & "'", KonCIM)
        'sql = "Select Sum(t0.RPM) AS JumlahRPM from wv_ajl_efficiency_detail t0 left join machine_master t1 on t0.Loom_No=t1.block+t1.loom_no " & vbCrLf & _
        '    "where Production_Date= '" & (DtpTanggal.Value) & "' and t0.Grey_No='" & (txtGreyno.Text) & "' and t1.loom_model='" & (LoomModel) & "' and t0.rpm >0"
        sql = "Select Sum(t0.RPM) AS JumlahRPM from wv_ajl_efficiency_detail " & vbCrLf & _
              "t0 left join machine_master t1 on t0.Loom_No=t1.block+t1.loom_no where Production_Date='" & (DtpTanggal.Value) & "' AND t0.Grey_No='" & (txtGreyno.Text) & "' and t1.loom_model='" & (LoomModel) & "' and t0.rpm >0"
        CMD = New SqlCommand(sql, KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            lbljml.Text = Str(DR.Item("JumlahRPM"))
        Else
            lbljml.Text = "0"
        End If
        '
        If lbljml.Text = "Null" Then
            lbljml.Text = "0"
        End If
        KonCIM.Close()
        '
    End Sub
    Sub HitungRataRPM()
        Dim i, x As Integer
        If lbljml.Text = "Null" Then
            i = 0
        Else
            i = lbljml.Text
        End If
        '
        If lblJmlGrey.Text = "Null" Then
            x = 0
        Else
            x = lblJmlGrey.Text
        End If
        '
        lblRata.Text = CDbl(i) / CDbl(x)
        If lblRata.Text = "NaN" Then
            lblRata.Text = "0"
        End If
    End Sub
    Sub CekDataWV()
        ' Dim text As String
        KoneksiCIM()
        KonCIM.Open()
        '
        'DtpTanggal.Value = 
        '
        If KurangTgl = True Then
            TanggalHitung = HasilTgl
        Else
            TanggalHitung = DtpTanggal.Value
        End If
        '
        CMD = New SqlCommand("Select * from wv_ajl_efficiency_detail where (Production_Date) = '" & (TanggalHitung) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        Try
            If DR.HasRows = False Then
                'If MessageBox.Show("Maaf Data pada tanggal ini kosong apakah ingin lanjut dengan mengurangi 1 hari dari tanggal" + " " + Format(TanggalHitung, "dd/MM/yyyy"), "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                If KurangTgl = False Then
                    HasilTgl = (DateAdd(DateInterval.Day, -1, DtpTanggal.Value))
                Else
                    HasilTgl = (DateAdd(DateInterval.Day, -1, TanggalHitung))
                End If
                KurangTgl = True
                CekDataWV()
                'Else
                '    Ulangdata = True
                '    Exit Sub
                'End If
            Else
                Exit Sub
            End If
            DR.Close()
            KonCIM.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '
    End Sub
    Sub CekDataProses()
        ' Dim text As String
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select plan_month from wv_loom_eff where plan_month = '" & (cmbPlanMonthedit.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        Try
            If DR.HasRows Then
                'If MessageBox.Show("Maaf Data pada Plan Month ini sudah ada apakah ingin lanjut Proses....?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                HapusDataProses()
                Ulangdata = False
                'End If
            End If
            '
            DR.Close()
            KonCIM.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '
    End Sub
    Sub CekDataProses2()
        ' Dim text As String
        'KoneksiISTEM()
        'Kon.Open()
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select plan_month from wv_prod_plan_header where plan_month = '" & (cmbPlanMonthedit.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        Try
            If DR.HasRows Then
                'If MessageBox.Show("Maaf Data pada Plan Month ini sudah ada apakah ingin lanjut Proses....?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                HapusDataProses4()
                HapusDataProses3()
                HapusDataProses2()
                Ulangdata = False
                'End If
            End If
            '
            DR.Close()
            KonCIM.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '
    End Sub
    Sub CekDataProses3()
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select plan_month from wv_prod_plan_detail1 where plan_month = '" & (cmbPlanMonthedit.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        Try
            If DR.HasRows Then
                ' If MessageBox.Show("Maaf Data pada Plan Month ini sudah ada apakah ingin lanjut Proses....?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                HapusDataProses3()
                Ulangdata = False
                'End If
            End If
            '
            DR.Close()
            KonCIM.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '
    End Sub
    Sub CekDataProses4()
        ' Dim text As String
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select plan_month from wv_prod_plan_detail2 where plan_month = '" & (cmbPlanMonthedit.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        Try
            If DR.HasRows Then
                If MessageBox.Show("Maaf Data pada Plan Month ini sudah ada apakah ingin lanjut Proses....?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    'HapusDataProses3()
                    HapusDataProses4()
                    Ulangdata = False
                End If
            End If
            '
            DR.Close()
            KonCIM.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '
    End Sub
    Sub HitungJumlahProdDay()
        Dim y, z As Double
        '(rpm*2.54*60*24*eff/100)/density*100
        y = (CDbl(lbleff.Text) / 100) / (CDbl(lblwef.Text) * 100)
        z = (CDbl(lblRata.Text) * 2.54 * 60 * 24 * y)
        lblProd.Text = Math.Round(z, 2)
    End Sub
    Sub HitungJumlahProdDayPCS()
        Dim x, y As Double
        '(rpm*2.54*60*24*eff/100)/density/100*length_gr
        'x = (CDbl(lblRata.Text) * 2.54 * 60 * 24 * CDbl(lbleff.Text) / 100) / CDbl(lblwef.Text) / 100 * CDbl(lbllength_grey.Text)
        y = (CDbl(lblwef.Text) * 100 * CDbl(lbllength_grey.Text))
        x = ((CDbl(lblRata.Text) * 2.54 * 60 * 24 * (CDbl(lbleff.Text) / 100)) / y)
        lblProdPCS.Text = Math.Round(x, 2)
    End Sub
    Private Sub frmGenerate_Plan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        Buka_DataComboPlan()
        '
        Control.CheckForIllegalCrossThreadCalls = False
        With BgdWkr1
            .WorkerReportsProgress = True
            .WorkerSupportsCancellation = True
        End With
    End Sub
    Private Sub BtnSetPlanedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        HitungJumlahProdDay()
    End Sub
    Sub HapusDataProses()
        Dim Hapusdata As String
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            Hapusdata = "delete wv_loom_eff where plan_month ='" & (cmbPlanMonthedit.Text) & "'"
            Dim CMDHapus As New SqlCommand(Hapusdata, KonCIM)
            '
            KonCIM.Open()
            TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
            '
            CMDHapus.Transaction = TR
            '
            Try
                CMDHapus.ExecuteNonQuery()
                TR.Commit()
                'MessageBox.Show("Data Berhasil Dihapus", "Informasi")
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            End Try
        End Using
        '   
    End Sub
    Sub HapusDataProses2()
        Dim Hapusdata As String
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            Hapusdata = "delete wv_prod_plan_header where plan_month ='" & (cmbPlanMonthedit.Text) & "'"
            Dim CMDHapus As New SqlCommand(Hapusdata, KonCIM)
            '
            KonCIM.Open()
            TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
            '
            CMDHapus.Transaction = TR
            '
            Try
                CMDHapus.ExecuteNonQuery()
                TR.Commit()
                'MessageBox.Show("Data Berhasil Dihapus", "Informasi")
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            End Try
        End Using
        '   
    End Sub
    Sub HapusDataProses3()
        Dim Hapusdata As String
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            Hapusdata = "delete wv_prod_plan_detail1 where plan_month ='" & (cmbPlanMonthedit.Text) & "'"
            Dim CMDHapus As New SqlCommand(Hapusdata, KonCIM)
            '
            KonCIM.Open()
            TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
            '
            CMDHapus.Transaction = TR
            '
            Try
                CMDHapus.ExecuteNonQuery()
                TR.Commit()
                'MessageBox.Show("Data Berhasil Dihapus", "Informasi")
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            End Try
        End Using
        '   
    End Sub
    Sub HapusDataProses4()
        Dim Hapusdata As String
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            Hapusdata = "delete wv_prod_plan_detail2 where plan_month ='" & (cmbPlanMonthedit.Text) & "'"
            Dim CMDHapus As New SqlCommand(Hapusdata, KonCIM)
            '
            KonCIM.Open()
            TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
            '
            CMDHapus.Transaction = TR
            '
            Try
                CMDHapus.ExecuteNonQuery()
                TR.Commit()
                'MessageBox.Show("Data Berhasil Dihapus", "Informasi")
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            End Try
        End Using
        '   
    End Sub
    Sub BukadataGrey()
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            'DA = New SqlDataAdapter("Select grey_no as Grey_No,request_date from sl_grey_request where plan_month = '" & (cmbPlanMonthedit.Text) & "'", Kon)
            DA = New SqlDataAdapter("Select t0.Production_Date,t0.Shift_Group_Time, t0.Loom_No, t0.Grey_No, t0.RPM, t1.loom_model from wv_ajl_efficiency_detail t0 left join machine_master t1 on t0.Loom_No=t1.block+t1.loom_no where Production_Date='" & (DtpTanggal.Value) & "' and t0.rpm >0 order by t0.Grey_No+t1.loom_model", KonCIM)
            DS = New DataSet
            '
            Try
                DA.Fill(DS)
                '
                DGV.DataSource = DS.Tables(0)
                KonCIM.Close()
                DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '
                DGV.Columns(0).Width = 130
                DGV.Columns(1).Width = 100
                DGV.Columns(2).Width = 50
                DGV.Columns(3).Width = 50
                DGV.Columns(4).Width = 50
                DGV.Columns(5).Width = 50
                ''
                'TanggalHitung = DGV(1, DGV.RowCount - 2).Value
                'DtpTanggal.Value = TanggalHitung
                ''
                'lbleff.Text = DGV.Rows.Count
                DGV.ReadOnly = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
        '
    End Sub
    Sub BukadataGreySkt()
        Dim Tglcari As Date
        KoneksiCIM()
        KonCIM.Open()
        '
        Tglcari = Format(DtpTanggal.Value, "yyyy/MM/dd")
        '
        'NilaiTanggal = DtpTanggal.Value
        Using KonCIM As New SqlConnection(ConStringCIM)
            'DA = New ("Select t0.Production_Date,t0.Shift_Group_Time, t0.Loom_No, t0.Grey_No, t0.RPM, t1.loom_model from wv_ajl_efficiency_detail t0 left join machine_master t1 on t0.Loom_No=t1.block+t1.loom_no where Production_Date='" & (DtpTanggal.Value) & "' and t0.rpm >0 order by t0.Grey_No+t1.loom_model", KonCIM)
            DA = New SqlDataAdapter("Select distinct(Grey_No),Production_Date from wv_ajl_efficiency_detail where Production_Date='" & (DtpTanggal.Value) & "' and rpm >0 order by Grey_No asc", KonCIM)
            DS = New DataSet
            '
            Try
                DA.Fill(DS)
                '
                DGV1.DataSource = DS.Tables(0)
                KonCIM.Close()
                DGV1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '
                DGV1.Columns(0).Width = 130
                DGV1.Columns(1).Width = 100
                'DGV.Columns(3).Width = 50
                'DGV.Columns(4).Width = 50
                'DGV.Columns(5).Width = 50
                ''
                'lbleff.Text = DGV.Rows.Count
                DGV1.ReadOnly = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
        '
    End Sub
    Sub BukadataGreyEffdtl()
        Dim Tgl As Date
        KoneksiCIM()
        KonCIM.Open()
        '
        Tgl = Format(DtpTanggal.Value, "yyyy/MM/dd")
        Using KonCIM As New SqlConnection(ConStringCIM)
            'DA = New ("Select t0.Production_Date,t0.Shift_Group_Time, t0.Loom_No, t0.Grey_No, t0.RPM, t1.loom_model from wv_ajl_efficiency_detail t0 left join machine_master t1 on t0.Loom_No=t1.block+t1.loom_no where Production_Date='" & (DtpTanggal.Value) & "' and t0.rpm >0 order by t0.Grey_No+t1.loom_model", KonCIM)
            ' DA = New SqlDataAdapter("Select distinct(Grey_No),Production_Date from wv_ajl_efficiency_detail where Production_Date='" & (DtpTanggal.Value) & "' and rpm >0 order by Grey_No asc", KonCIM)
            sql = "Select t0.Production_Date,t0.Shift_Group_Time, t0.Loom_No, t0.Grey_No, t0.RPM, t1.loom_model" & vbCrLf & _
                    "from wv_ajl_efficiency_detail t0 left join machine_master t1 on t0.Loom_No=t1.block+t1.loom_no" & vbCrLf & _
                    "where Production_Date='" & (Tgl) & "' and t0.rpm >0 order by t0.Grey_No+t1.loom_model"
            DA = New SqlDataAdapter(sql, KonCIM)
            DS = New DataSet
            '
            Try
                DA.Fill(DS)
                '
                DGV0.DataSource = DS.Tables(0)
                KonCIM.Close()
                DGV0.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '
                DGV0.Columns(0).Width = 50
                DGV0.Columns(1).Width = 50
                DGV0.Columns(2).Width = 50
                DGV0.Columns(3).Width = 50
                DGV0.Columns(4).Width = 50
                DGV0.Columns(5).Width = 50
                ''
                'TanggalHitung = DGV(1, DGV.RowCount - 2).Value
                'DtpTanggal.Value = TanggalHitung
                ''
                'lbleff.Text = DGV.Rows.Count
                DGV0.ReadOnly = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
        '
    End Sub
    Sub AmbildataGreyEffdtl()
        Dim KodeGrey As String
        Dim NamaModel As String
        'Dim Ulang As Boolean
        ' Dim IntI, IntJ As Integer
        '
        For Each row As DataGridViewRow In DGV0.Rows
            If Not row.IsNewRow Then
                KodeGrey = UCase(row.Cells(3).Value)
                NamaModel = row.Cells(5).Value
                DGV.Rows.Add(KodeGrey & NamaModel)
                '
                DGV(0, DGV.RowCount - 2).Value = cmbPlanMonthedit.Text
                DGV(1, DGV.RowCount - 2).Value = KodeGrey
                DGV(2, DGV.RowCount - 2).Value = NamaModel
                '
            End If
            '
            For barisatas As Integer = 0 To DGV.RowCount - 1
                For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                    If DGV.Rows(barisbawah).Cells(1).Value & DGV.Rows(barisbawah).Cells(2).Value = DGV.Rows(barisatas).Cells(1).Value & DGV.Rows(barisatas).Cells(2).Value Then
                        'MsgBox("Barang sudah Ada")
                        DGV.Rows.RemoveAt(barisbawah)
                        Exit For
                    End If
                Next
            Next
        Next
        '
    End Sub
    Private Sub BtnProses1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses1.Click
        KurangTgl = False
        '
        'BukaDataSalesGrey()
        '
        CekDataProses()
        CekDataWV()
        'BukadataGrey()
        BukadataGreySkt()
        BukadataGreyEffdtl()
        AmbildataGreyEffdtl()
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        LblWarning.Text = " Proses Pertama sedang berjalan Silahkan Tunggu....!!"
        ''
        Using KonCIM As New SqlConnection(ConStringCIM)
            '
            If Ulangdata = False Then 'plan_version,plan_date
                SimpanData = "Insert into wv_loom_eff (plan_month,grey_no,loom_model,rpm,density,eff,prod_day_mtr,prod_day_pcs,rec_sts,proc_no,upd_date,upd_time,user_id,client_ip)" _
                & "values(@plan_month,@grey_no,@loom_model,@rpm,@density,@eff,@prod_day_mtr,@prod_day_pcs,@rec_sts,@proc_no,@upd_date,@upd_time,@user_id,@client_ip)"
                Dim CMDSimpan As New SqlCommand(SimpanData, KonCIM) '@plan_version,@plan_date
                '
                CMDSimpan.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                'CMDSimpan.Parameters.Add(New SqlParameter("@plan_version", SqlDbType.VarChar))
                'CMDSimpan.Parameters.Add(New SqlParameter("@plan_date", SqlDbType.Date))
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
                TglUpdate = Format(Date.Now, "yyyy/MM/dd")
                Try
                    For Each row As DataGridViewRow In DGV.Rows
                        If Not row.IsNewRow Then
                            txtGreyno.Text = row.Cells(1).Value.ToString
                            LoomModel = row.Cells(2).Value.ToString
                            'DGV(2, DGV.RowCount - 2).Value
                            BukaDataFabbricAnalys()
                            HitungDataGrey()
                            HitungRPM()
                            HitungRataRPM()
                            HitungJumlahProdDay()
                            HitungJumlahProdDayPCS()
                            '
                            BukaDataWV()
                            BukaMesinMaster()
                            '
                            CMDSimpan.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
                            'CMDSimpan.Parameters("@plan_version").Value = "1"
                            'CMDSimpan.Parameters("@plan_date").Value = TanggalHitung
                            CMDSimpan.Parameters("@grey_no").Value = row.Cells(1).Value.ToString
                            CMDSimpan.Parameters("@loom_model").Value = row.Cells(2).Value.ToString 'lblLmModel.Text 'row.Cells(5).Value.ToString
                            CMDSimpan.Parameters("@rpm").Value = CDbl(lblRata.Text)
                            CMDSimpan.Parameters("@density").Value = CDbl(lblwef.Text)
                            CMDSimpan.Parameters("@eff").Value = CDbl(lbleff.Text)
                            CMDSimpan.Parameters("@prod_day_mtr").Value = CDbl(lblProd.Text)
                            CMDSimpan.Parameters("@prod_day_pcs").Value = CDbl(lblProdPCS.Text)
                            CMDSimpan.Parameters("@rec_sts").Value = "A"
                            CMDSimpan.Parameters("@proc_no").Value = "1"
                            'TglUpdate = Format(Date.Now, "yyyy-mm-dd")
                            CMDSimpan.Parameters("@upd_date").Value = TglUpdate 'Convert.ToDateTime(Menu_Utama.TSlblTanggal.Text.ToString)
                            CMDSimpan.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                            CMDSimpan.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                            CMDSimpan.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                            ' ''
                            CMDSimpan.ExecuteNonQuery()
                        End If
                    Next
                    TR.Commit()
                    'MessageBox.Show("Data Berhasil Disimpan Tahap 1", "Informasi")
                    LblWarning.Text = " Proses Pertama sudah dilakukan Silahkan Lanjut ke proses berikutnya"
                Catch ex As Exception
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                End Try
                '
                KonCIM.Close()
                'BukaDataProses()
                'TabControl1.SelectTab(1)
            End If
        End Using

        'DGV.Refresh()
        'DGV.RefreshEdit()
    End Sub

    Private Sub DGV_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        Try
            txtGreyno.Text = DGV.Rows(e.RowIndex).Cells(0).Value
            BukaDataFabbricAnalys()
            HitungDataGrey()
            HitungRPM()
            HitungRataRPM()
            HitungJumlahProdDay()
            BukaDataWV()
            BukaMesinMaster()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub cmdUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKeluar.Click
        '
        DGV.Refresh()
        DGV0.Refresh()
        DGV3.Refresh()
        DGV4.Refresh()
        DGVGS.Refresh()
        'DGVView.Refresh()
        DGVEX.Refresh()
        '
        DGV.DataSource = Nothing
        DGV0.DataSource = Nothing
        DGV3.DataSource = Nothing
        DGV4.DataSource = Nothing
        DGVGS.DataSource = Nothing
        'DGVView.DataSource = Nothing
        DGVEX.DataSource = Nothing
        '
        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        Close()
    End Sub
    Sub CekDataMonth1frm1()
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where Month(Shift_Date) = '" & Month(Nilaifrmperiod1) & "' and year(Shift_date)= '" & Year(Nilaifrmperiod1) & "' order by Shift_date asc", KonCIM)
            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where (prod_date) = '" & (Nilaifrmperiod1) & "' order by prod_date asc", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                'Hasilfrmperiod1 = DR.Item("shift_date")
                HasilM1per1frm = DR.Item("prod_date")
            End If
            '
            '
            If DR.HasRows Then
                HasilM1per1frm = Nilaifrmperiod1
            Else
                HasilM1per1frm = (DateAdd(DateInterval.Day, 1, Nilaifrmperiod1))
                Nilaifrmperiod1 = HasilM1per1frm
                Ulangdata = True
                CekDataMonth1frm1()
            End If
            '
            'lblMont1P1From.Text = HasilM1per1frm
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ' End Using
    End Sub
    Sub CekdataRemind()
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        Try
            CMDEDIT = New SqlCommand("select count(distinct(prod_date)) as HasilRM from wv_ajl_shift_detail where prod_date >= '" & (Remindfromawal) & "' and prod_date <='" & (Remindtoawal) & "'", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            'Remindfromawal
            If DR.HasRows Then
                HasilReminWD = DR.Item("HasilRM")
                'Hasilfrmperiod1 = DR.Item("shift_date")
                'Hasilfrmperiod1 = DR.Item("prod_date")
            Else
                'Hasilfrmperiod1 = Nilaifrmperiod1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekDataRemindSalesEntry()
        'KoneksiCIM()
        'KonCIM.Open()
        ''
        'Try
        '    CMD = New SqlCommand("Select * from sl_grey_request where remain_date_from='" & (DtpTanggal.Value) & "'", KonCIM)
        '    DR = CMD.ExecuteReader
        '    '
        '    If DR.HasRows Then

        '    End If
        '    '
        'Catch ex As Exception
        'End Try
        ''
    End Sub
    Sub CekdataRemindFrom()
        KoneksiCIM()
        KonCIM.Open()
        Try
            'If Ulangdata = False Then
            '    lblRemindfrmperiod1 = Format(Nilaifrmperiod1, "MM") & "/" & "16" & "/" & Format(Nilaifrmperiod1, "yyyy")
            '    Nilaifrmperiod1 = lblRemindfrmperiod1

            'End If
            If Format(Remindfromawal, "dd") <= "16" Then
                HasilRemindawalfrm = Remindfromawal
            Else
                HasilRemindawalfrm = Format(Remindfromawal, "MM") & "/" & "1" & "/" & Format(Remindfromawal, "yyyy")
            End If
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekdataRemindTO()
        KoneksiCIM()
        KonCIM.Open()
        '
        Try
            NilaiRemP1to = Remindfromawal
            '
            If Ulangdata = False Then
                lblRemdP1to = Format(NilaiRemP1to, "MM") & "/" & "16" & "/" & Format(NilaiRemP1to, "yyyy")
                NilaiRemP1to = lblRemdP1to
                HasilRemP1to = lblRemdP1to
            End If
            'NilaiRemP1from
            CMD = New SqlCommand("Select * from wv_ajl_shift_detail where (prod_Date) = '" & (NilaiRemP1to) & "'", KonCIM)                '
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                HasilRemP1to = DR.Item("prod_Date")
            Else
                HasilRm1 = (DateAdd(DateInterval.Day, -1, HasilRemP1to))
                Ulangdata = True
                CekdataRemindTO()
            End If
            '
            'lblMonth1to.Text = Hasilfrmperiod1
            lblRemindtoawal.Text = HasilRemP1to
            Ulangdata = False
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekdataRemind2From()
        KoneksiCIM()
        KonCIM.Open()
        NilaiawalRem = Remindfromawal
        Try
            If Format(NilaiawalRem, "dd") > "16" Then
                HasilRemP2from = NilaiawalRem
            Else
                If Ulangdata = False Then
                    HasilRemP2from = Format(NilaiawalRem, "MM") & "/" & "17" & "/" & Format(NilaiawalRem, "yyyy")
                End If
                '
                CMDCARI = New SqlCommand("Select * from wv_ajl_shift_detail where (prod_Date) = '" & (HasilRemP2from) & "'", KonCIM)                '
                DR = CMDCARI.ExecuteReader
                DR.Read()
                '
                If DR.HasRows Then
                    HasilRemP2from = DR.Item("prod_Date")
                Else
                    NilaiRemP2from = (DateAdd(DateInterval.Day, 1, HasilRemP2from))
                    'HasilRm1 = (DateAdd(DateInterval.Day, -1, HasilRemP1to))
                    Ulangdata = True
                    CekdataRemind2From()
                End If
            End If
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
  
    Sub CekdataTotalMonth1()
        KoneksiCIM()
        KonCIM.Open()
        Try
               CMDEDIT = New SqlCommand("select count(distinct(prod_date)) as HasilM1 from wv_ajl_shift_detail where prod_date >= '" & (Nilaifrmperiod1) & "' and prod_date <='" & (Nilaitoperiod1) & "'", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM1 = DR.Item("HasilM1")
                'Hasilfrmperiod1 = DR.Item("shift_date")
                'Hasilfrmperiod1 = DR.Item("prod_date")
            Else
                'Hasilfrmperiod1 = Nilaifrmperiod1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekdataTotalMonth2()

        'Using KonCIM As New SqlConnection(ConStringCIM)
        KoneksiCIM()
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where Month(Shift_Date) = '" & Month(Nilaifrmperiod1) & "' and year(Shift_date)= '" & Year(Nilaifrmperiod1) & "' order by Shift_date asc", KonCIM)
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where prod_date = '" & Month(Nilaifrmperiod1) & "' and year(prod_date)= '" & Year(Nilaifrmperiod1) & "' order by prod_date asc", KonCIM)
            CMDEDIT = New SqlCommand("select count(distinct(prod_date)) as HasilM2 from wv_ajl_shift_detail where prod_date >= '" & (Nilaifrmperiod2) & "' and prod_date <='" & (Nilaitoperiod2) & "'", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM2 = DR.Item("HasilM2")
                'Hasilfrmperiod1 = DR.Item("shift_date")
                'Hasilfrmperiod1 = DR.Item("prod_date")
            Else
                'Hasilfrmperiod1 = Nilaifrmperiod1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekdataTotalMonth3()
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where Month(Shift_Date) = '" & Month(Nilaifrmperiod1) & "' and year(Shift_date)= '" & Year(Nilaifrmperiod1) & "' order by Shift_date asc", KonCIM)
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where prod_date = '" & Month(Nilaifrmperiod1) & "' and year(prod_date)= '" & Year(Nilaifrmperiod1) & "' order by prod_date asc", KonCIM)
            CMDEDIT = New SqlCommand("select count(distinct(prod_date)) as HasilM3 from wv_ajl_shift_detail where prod_date >= '" & (Nilaifrmperiod3) & "' and prod_date <='" & (Nilaitoperiod3) & "'", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM3 = DR.Item("HasilM3")
                'Hasilfrmperiod1 = DR.Item("shift_date")
                'Hasilfrmperiod1 = DR.Item("prod_date")
            Else
                'Hasilfrmperiod1 = Nilaifrmperiod1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekDataMonth1per1to()

        KoneksiCIM()
        KonCIM.Open()
        Try
            If Ulangdata = False Then
                lblRemindfrmperiod1 = Format(Nilaifrmperiod1, "MM") & "/" & "16" & "/" & Format(Nilaifrmperiod1, "yyyy")
                Nilaifrmperiod1 = lblRemindfrmperiod1
            End If
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where (Shift_Date) = '" & (Nilaifrmperiod1) & "'", KonCIM)                '
            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where (prod_Date) = '" & (Nilaifrmperiod1) & "'", KonCIM)                '
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                'Hasilfrmperiod1 = DR.Item("shift_date")
                Hasilfrmperiod1 = DR.Item("prod_Date")
            Else
                HasilTgl1 = (DateAdd(DateInterval.Day, -1, Nilaifrmperiod1))
                Nilaifrmperiod1 = HasilTgl1
                ' lblhasil.Text = I
                Ulangdata = True
                CekDataMonth1per1to()
                'End If
            End If
            '
            lblMonth1to.Text = Hasilfrmperiod1
            Ulangdata = False
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekDataMonth1per2from()
        ' Dim I As Integer
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try
            If Ulangdata = False Then
                lblRemindtoperiod1 = Format(Nilaifrmperiod1, "MM") & "/" & "17" & "/" & Format(Nilaifrmperiod1, "yyyy")
                Nilaifrmperiod1 = lblRemindtoperiod1
                'Nilaifrmperiod2
            End If
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where (Shift_Date) = '" & (Nilaifrmperiod1) & "'", KonCIM)
            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where (prod_Date) = '" & (Nilaifrmperiod1) & "'", KonCIM)
            '
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                'Hasilfrmperiod1 = DR.Item("shift_date")
                HasilM1frmperiod2 = DR.Item("prod_date")
            Else
                HasilTgl1 = (DateAdd(DateInterval.Day, 1, Nilaifrmperiod1))
                Nilaifrmperiod1 = HasilTgl1
                'lblhasil.Text = I
                Ulangdata = True
                CekDataMonth1per2from()
                'End If
            End If
            lblMont1P1From.Text = HasilM1frmperiod2
            Ulangdata = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekDataMonth2Per1frm()
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try

            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where prod_date = '" & (Nilaifrmperiod2) & "' order by prod_date asc", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM2per1frm = DR.Item("prod_date")
            End If
            '
            If DR.HasRows Then
                HasilM2per1frm = Nilaifrmperiod2
            Else
                HasilM2per1frm = (DateAdd(DateInterval.Day, 1, Nilaifrmperiod2))
                Nilaifrmperiod2 = HasilM2per1frm
                Ulangdata = True
                CekDataMonth2Per1frm()
            End If
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekDataMonth2Per1to()
        KoneksiCIM()
        KonCIM.Open()
        Try
            '
            If Ulangdata = False Then
                lblRemindtoperiod2 = Format(Nilaifrmperiod2, "MM") & "/" & "16" & "/" & Format(Nilaifrmperiod2, "yyyy")
                Nilaifrmperiod2 = lblRemindtoperiod2
            End If
            '
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where Shift_date = '" & (Nilaifrmperiod2) & "'", Kon)
            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where prod_date= '" & (Nilaifrmperiod2) & "'", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM2Period1to = Nilaifrmperiod2
            Else
                HasilTgl2 = (DateAdd(DateInterval.Day, -1, Nilaifrmperiod2))
                Nilaifrmperiod2 = HasilTgl2
                Ulangdata = True
                CekDataMonth2Per1to()
            End If
            '
            lblMont2P1to.Text = HasilM2Period1to
            Ulangdata = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekDataMonth2Per2frm()
        Dim lblMont2p2frm As String
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try
            '
            If Ulangdata = False Then
                lblMont2p2frm = Format(Nilaifrmperiod2, "MM") & "/" & "17" & "/" & Format(Nilaifrmperiod2, "yyyy")
                Nilaifrmperiod2 = lblMont2p2frm
            End If
            '
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where Shift_date = '" & (Nilaifrmperiod2) & "'", Koncim)
            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where prod_date = '" & (Nilaifrmperiod2) & "'", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM2Period2frm = Nilaifrmperiod2
            Else
                HasilTgl2 = (DateAdd(DateInterval.Day, 1, Nilaifrmperiod2))
                Nilaifrmperiod2 = HasilTgl2
                Ulangdata = True
                CekDataMonth2Per2frm()
            End If
            lblMont2P2from.Text = HasilM2Period2frm
            Ulangdata = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekDataMonth2Per2to()
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where Shift_date = '" & (Nilaitoperiod2) & "' ORDER BY Shift_date DESC", Koncim)
            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where prod_date = '" & (Nilaitoperiod2) & "'ORDER BY prod_date DESC", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM2Period2to = DR.Item("prod_date")
            End If
            lblMont2P2to.Text = HasilM2Period2to
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekDataMonth3P1frm()
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try
            ' CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where Shift_date = '" & (Nilaifrmperiod3) & "'", Koncim)
            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where prod_date= '" & (Nilaifrmperiod3) & "' order by prod_date desc", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM3per1frm = DR.Item("prod_date")
            End If
            '
            If DR.HasRows Then
                HasilM3per1frm = Nilaifrmperiod3
            Else
                HasilM3per1frm = (DateAdd(DateInterval.Day, 1, NilaiM3per1frm))
                Nilaifrmperiod3 = HasilM3per1frm
                Ulangdata = True
                CekDataMonth3P1frm()
            End If
            '
            lblMont3P1from.Text = HasilM3per1frm
            'lblMont3P1to.Text = HasilM3Period1to
            '
            Ulangdata = False
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        ' End Using
    End Sub
    Sub CekDataMonth3P1to()
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try
            '
            If Ulangdata = False Then
                lblRemindtoperiod3 = Format(NilaiM3per1frm, "MM") & "/" & "16" & "/" & Format(NilaiM3per1frm, "yyyy")
                NilaiM3per1frm = lblRemindtoperiod3
            End If
            '
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where Shift_date = '" & (Nilaifrmperiod3) & "'", Koncim)
            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where prod_date= '" & (NilaiM3per1frm) & "'", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM3Period1to = NilaiM3per1frm
            Else
                HasilTgl3 = (DateAdd(DateInterval.Day, -1, NilaiM3per1frm))
                NilaiM3per1frm = HasilTgl3
                Ulangdata = True
                CekDataMonth3P1to()
            End If
            '
            lblMont3P1to.Text = HasilM3Period1to
            '
            Ulangdata = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub

    Sub CekDataMonth3P2from()
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try
            '
            If Ulangdata = False Then
                lblRemindtoperiod3 = Format(NilaiM3per2frm, "MM") & "/" & "17" & "/" & Format(NilaiM3per2frm, "yyyy")
                NilaiM3per2frm = lblRemindtoperiod3
            End If
            '
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where Shift_date = '" & (Nilaifrmperiod2) & "'", Koncim)
            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where prod_date = '" & (NilaiM3per2frm) & "'", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM3Period2frm = NilaiM3per2frm
            Else
                HasilTgl3 = (DateAdd(DateInterval.Day, 1, NilaiM3per2frm))
                NilaiM3per2frm = HasilTgl3
                Ulangdata = True
                CekDataMonth3P2from()
            End If
            lblMont3P2from.Text = HasilM3Period2frm
            Ulangdata = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekDataMonth3P2to()
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        Try
            'CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where Shift_date = '" & (Nilaitoperiod2) & "' ORDER BY Shift_date DESC", Koncim)
            CMDEDIT = New SqlCommand("Select * from wv_ajl_shift_detail where prod_date = '" & (Nilaitoperiod3) & "'ORDER BY prod_date DESC", KonCIM)
            DR = CMDEDIT.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                HasilM3Period2to = DR.Item("prod_date")
            End If
            '
            lblMont3P2to.Text = HasilM3Period2to
            Ulangdata = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub BukaDataSalesReq()
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        '
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        CMD = New SqlCommand("Select * from  sl_grey_request where plan_month = '" & (cmbPlanMonthedit.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            Remindfromawal = DR.Item("request_date")
            Remindtoawal = DR.Item("remain_date_to")
            Remindfrom1 = DR.Item("remain_date_from")
            Nilaifrmperiod1 = DR.Item("month1_from")
            Nilaifrmperiod2 = DR.Item("month2_from")
            Nilaifrmperiod3 = DR.Item("month3_from")
            Nilaitoperiod1 = DR.Item("month1_to")
            Nilaitoperiod2 = DR.Item("month2_to")
            Nilaitoperiod3 = DR.Item("month3_to")
            '
            NilaiM1per1frm = DR.Item("month1_from")
            NilaiM2per1frm = DR.Item("month2_from")
            NilaiM3per1frm = DR.Item("month3_from")
            '
            NilaiM1per1to = DR.Item("month1_to")
            NilaiM2per1to = DR.Item("month2_to")
            NilaiM3per1to = DR.Item("month3_to")
            '
            NilaiM1per2frm = DR.Item("month1_from")
            NilaiM2per2frm = DR.Item("month2_from")
            NilaiM3per2frm = DR.Item("month3_from")
            '
            NilaiM1per2to = DR.Item("month1_to")
            NilaiM2per2to = DR.Item("month2_to")
            NilaiM3per2to = DR.Item("month3_to")
            '
        Else
            MsgBox("Maaf Data Set Plant Tidak ada ", vbInformation, "Informasi")
            Exit Sub
        End If
    End Sub
    Sub CekAllMonth()
        '
        KoneksiCIM()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        KonCIM.Open()
        '
        CMDM1 = New SqlCommand("Select * from sl_grey_request where plan_month = '" & (cmbPlanMonthedit.Text) & "'", KonCIM)
        DRM1 = CMDM1.ExecuteReader
        DRM1.Read()
        ''
        'CekDataMonth1frm1()
        'CekDataMonth1to1()
    End Sub
    Private Sub BtnProses2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses2.Click
        '
        Dim TglReqHeader As Date
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        CekDataProses2()
        BukaDataSalesReq()
        '
        'LblWarning.Text = " Proses Kedua sedang berjalan Silahkan Tunggu....!!"
        ''
        CekdataRemind()
        ''baru tambah remind
        CekdataRemindFrom()
        CekdataRemindTO()
        CekdataRemind2From()
        '
        CekdataTotalMonth1()
        CekdataTotalMonth2()
        CekdataTotalMonth3()
        '
        CekDataMonth1frm1()
        CekDataMonth1per1to()
        CekDataMonth1per2from()
        ''
        CekDataMonth2Per1frm()
        CekDataMonth2Per1to()
        ''
        CekDataMonth2Per2frm()
        CekDataMonth2Per2to()
        ''
        CekDataMonth3P1frm()
        CekDataMonth3P1to()
        ''
        CekDataMonth3P2from()
        CekDataMonth3P2to()
        '
        ''

        TglUpdate = Format(Date.Now, "yyyy/MM/dd")
        Using KonCIM As New SqlConnection(ConStringCIM)
            Try
                SimpanData = "insert into wv_prod_plan_header(plan_month,plan_rev_no,grey_stock_date,remain_work_day,remain_period1_from,remain_period1_to,month1_work_day,month2_work_day,month3_work_day,remain_period2_from,remain_period2_to,month1_period1_from,month1_period1_to,month1_period2_from,month1_period2_to,month2_period1_from,month2_period1_to,month2_period2_from,month2_period2_to,month3_period1_from,month3_period1_to,month3_period2_from,month3_period2_to,rec_sts,proc_no,upd_date,upd_time,user_id,client_ip)" _
                    & "Values (@plan_month,@plan_rev_no,@grey_stock_date,@remain_work_day,@remain_period1_from,@remain_period1_to,@month1_work_day,@month2_work_day,@month3_work_day,@remain_period2_from,@remain_period2_to,@month1_period1_from,@month1_period1_to,@month1_period2_from,@month1_period2_to,@month2_period1_from,@month2_period1_to,@month2_period2_from,@month2_period2_to,@month3_period1_from,@month3_period1_to,@month3_period2_from,@month3_period2_to,@rec_sts,@proc_no,@upd_date,@upd_time,@user_id,@client_ip)"
                '
                CMDHEADER = New SqlCommand(SimpanData, KonCIM)
                '
                CMDHEADER.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
                'CMDHEADER.Parameters.Add(New SqlParameter("@remain_work_day", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@grey_stock_date", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@remain_work_day", SqlDbType.Int))
                CMDHEADER.Parameters.Add(New SqlParameter("@month1_work_day", SqlDbType.Int))
                CMDHEADER.Parameters.Add(New SqlParameter("@month2_work_day", SqlDbType.Int))
                CMDHEADER.Parameters.Add(New SqlParameter("@month3_work_day", SqlDbType.Int))
                CMDHEADER.Parameters.Add(New SqlParameter("@remain_period2_from", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@remain_period2_to", SqlDbType.Date))
                '
                CMDHEADER.Parameters.Add(New SqlParameter("@remain_period1_to", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@remain_period1_from", SqlDbType.Date))
                '
                CMDHEADER.Parameters.Add(New SqlParameter("@month1_period1_from", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month1_period1_to", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month1_period2_from", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month1_period2_to", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month2_period1_from", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month2_period1_to", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month2_period2_from", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month2_period2_to", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month3_period1_from", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month3_period1_to", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month3_period2_from", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month3_period2_to", SqlDbType.Date))
                '
                CMDHEADER.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
                '
                KonCIM.Open()
                TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
                CMDHEADER.Transaction = TR
                TglReqHeader = (DateAdd(DateInterval.Day, -1, Date.Now))
                '
                CMDHEADER.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
                CMDHEADER.Parameters("@plan_rev_no").Value = "1"
                'CMDHEADER.Parameters("@remain_work_day").Value = DtpTanggal.Value 'Format(TglReqHeader, "yyyy/MM/dd")
                '
                CMDHEADER.Parameters("@grey_stock_date").Value = Format(TglReqHeader, "yyyy/MM/dd") 'Menu_Utama.TSlblTanggal.Text
                CMDHEADER.Parameters("@remain_work_day").Value = HasilReminWD
                CMDHEADER.Parameters("@month1_work_day").Value = HasilM1
                CMDHEADER.Parameters("@month2_work_day").Value = HasilM2
                CMDHEADER.Parameters("@month3_work_day").Value = HasilM3
                '
                CMDHEADER.Parameters("@remain_period1_from").Value = HasilRemindawalfrm
                CMDHEADER.Parameters("@remain_period1_to").Value = HasilRemP1to
                '
                CMDHEADER.Parameters("@remain_period2_from").Value = HasilRemP2from 'Remindfromawal
                CMDHEADER.Parameters("@remain_period2_to").Value = Remindtoawal
                '
                CMDHEADER.Parameters("@month1_period1_from").Value = HasilM1per1frm
                CMDHEADER.Parameters("@month1_period1_to").Value = Hasilfrmperiod1
                CMDHEADER.Parameters("@month1_period2_from").Value = HasilM1frmperiod2
                CMDHEADER.Parameters("@month1_period2_to").Value = Nilaitoperiod1
                '
                CMDHEADER.Parameters("@month2_period1_from").Value = HasilM2per1frm
                CMDHEADER.Parameters("@month2_period1_to").Value = HasilM2Period1to
                CMDHEADER.Parameters("@month2_period2_from").Value = HasilM2Period2frm
                CMDHEADER.Parameters("@month2_period2_to").Value = HasilM2Period2to
                '
                CMDHEADER.Parameters("@month3_period1_from").Value = HasilM3per1frm
                CMDHEADER.Parameters("@month3_period1_to").Value = HasilM3Period1to
                CMDHEADER.Parameters("@month3_period2_from").Value = HasilM3Period2frm
                CMDHEADER.Parameters("@month3_period2_to").Value = HasilM3Period2to
                '
                CMDHEADER.Parameters("@rec_sts").Value = "A"
                CMDHEADER.Parameters("@proc_no").Value = "1"
                CMDHEADER.Parameters("@upd_date").Value = TglUpdate 'Convert.ToDateTime(Menu_Utama.TSlblTanggal.Text)
                CMDHEADER.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                CMDHEADER.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                CMDHEADER.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                  CMDHEADER.ExecuteNonQuery()
                ' LblWarning.Text = " Proses Kedua sudah dilakukan Silahkan Lanjut ke proses berikutnya"
                TR.Commit()
                '
                ' MessageBox.Show("Data Berhasil Disimpan", "Informasi")
                ' LblWarning.Text = " Proses Kedua sudah dilakukan Silahkan Lanjut ke proses berikutnya"
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            End Try
            '
            KonCIM.Close()
        End Using
    End Sub
    Private Sub BtnProses3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses3.Click
        'Tglrequest = DtpTanggal.Value
        KoneksiCIM()
        CekDataProses3()
        'DataBackGreystok()
        'BukadataGreyStok()
        BukadataGreyStok2()
        BukadataGreyLength()
        '
        LblWarning.Text = " Proses Ketiga sedang Berjalan Silahkan Tunggu"
        BtnProses31_Click(sender, New System.EventArgs)
        BtnProses32_Click(sender, New System.EventArgs)
        '
        'TGL Request berdasarkan tabel dy_grey_stok namun tabel grey stok yang terisi menggunakan data berjalan pada hari ini
        'tidak ada historikal tanggal kemarin atau tanggal kebelakang sehingga pada penyimpanan terdapat relasi antara tabel
        'wv_prod_plan_header dengan wv_prod_plan_detail1
        'dimana ada 3 kunci yang harus sama yaitu "Plant_month,Plan_version,request_date"
        'nah untuk request_date jikalau megacu pada dy_greystok maka proses plant tidak bisa dijalankan untuk data kebelakang
        'hanya untuk data berjalan tanggalnya
        'Proses menggunakan data request date dari tabel dy_grey_stok yang artinnya pada tabel wv_prod_plan_header menggunakan
        'rumus uyntuk request date hari ini dikurangi 1 hari agar bisa menyesuaikan dengan tabel dy_grey_stok agar bisa tersimpan
        'datanya di proses generate 3 di tabel wv_prod_plan_detail1
    End Sub
    
    Private Sub BtnProses4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses4.Click
        KoneksiCIM()
        '
        CekDataProses4()
        CekdataProdHeader()
        'CekdataEffdetail()
        '
        CekdataEffdetail2()
        CekDataEffdetailEdit()
        '
        '  LblWarning.Text = " Proses Keempat sedang Berjalan Silahkan Tunggu"
    End Sub
    Sub DataBackGreystok()
        Dim TglGreystok As Date
        TglGreystok = (DateAdd(DateInterval.Day, -1, DtpTanggal.Value))
        'HasilTgl = (DateAdd(DateInterval.Day, -1, DtpTanggal.Value))
        sql = "Select R.grey_no, fam.chop_no, (case when R.roll_sts='1' then 'R' else '' end) as grey_sts, max(fam.length_gr) as std_length, " & vbCrLf & _
        "cast(sum(Case When R.grade='NI' and R.normal='N' and R.status_pcs in ('L','S') then R.pcs else 0 end) as decimal(10,2)) as ni_grd_pcs," & vbCrLf & _
        "cast(sum(Case When R.grade='NI' and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as ni_grd_length," & vbCrLf & _
        "cast(sum(Case When R.grade='A3' and R.normal='N' and R.status_pcs in ('L','S') then R.pcs else 0 end) as decimal(10,2)) as a3_grd_pcs," & vbCrLf & _
        "cast(sum(Case When R.grade='A3' and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as a3_grd_length," & vbCrLf & _
        "cast(sum(Case When R.grade='A2' and R.normal='N' and R.status_pcs in ('L','S') then R.pcs else 0 end) as decimal(10,2)) as a2_grd_pcs," & vbCrLf & _
        "cast(sum(Case When R.grade='A2' and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as a2_grd_length," & vbCrLf & _
        "cast(sum(Case When R.grade='A' and R.normal='N' and R.status_pcs in ('L','S') then R.pcs else 0 end) as decimal(10,2)) as a_grd_pcs," & vbCrLf & _
        "cast(sum(Case When R.grade='A' and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as a_grd_length," & vbCrLf & _
        "cast(sum(Case When R.grade='B' and R.normal='N' and R.status_pcs in ('L','S') then R.pcs else 0 end) as decimal(10,2)) as b_grd_pcs," & vbCrLf & _
        "cast(sum(Case When R.grade='B' and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as b_grd_length," & vbCrLf & _
        "cast(sum(Case When R.grade in ('NI','A3','A2','A','B') and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as length " & vbCrLf & _
        "from (select h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts," & vbCrLf & _
        "COUNT(d.piece_no) as pcs, cast(sum(h.piece_length) as decimal(10,2)) as length from wv_wh_detail d" & vbCrLf & _
        "left join (select *,length/tot_pcs as piece_length from wv_wh_header) h on (h.barcode=d.barcode) " & vbCrLf & _
        "where h.whs_date<>'' and h.rec_type<>'D' and h.rec_sts<>'C' and h.tot_pcs<>0 " & vbCrLf & _
        "and h.whs_date<='" & (TglGreystok) & "'" & vbCrLf & _
        "group by h.whs_date, h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts" & vbCrLf & _
        "union(all) select h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts," & vbCrLf & _
        "COUNT(d.piece_no) as pcs, cast(sum(h.piece_length) as decimal(10,2)) as length" & vbCrLf & _
        "from wv_wh_detail d " & vbCrLf & _
        "left join (select *,length/tot_pcs as piece_length from wv_wh_header) h on (h.barcode=d.barcode)" & vbCrLf & _
        "where d.rec_type='D' and d.rec_sts<>'C' " & vbCrLf & _
        "and h.whs_date <='" & (TglGreystok) & "' and h.proc_date >'" & (TglGreystok) & "'" & vbCrLf & _
        "group by h.whs_date, h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts " & vbCrLf & _
        "union(all) select h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts," & vbCrLf & _
        "COUNT(d.piece_no) as pcs, cast(sum(h.piece_length) as decimal(10,2)) as length" & vbCrLf & _
        "from wv_wh_cancel_detail d " & vbCrLf & _
        "left join (select *,length/tot_pcs as piece_length from wv_wh_cancel) h on (h.barcode=d.barcode)" & vbCrLf & _
        "where d.rec_type='C' and d.rec_sts='C'" & vbCrLf & _
        "and h.whs_date <='2020-08-23' and h.proc_date >'2020-08-23'" & vbCrLf & _
        "group by h.whs_date, h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts" & vbCrLf & _
        ")R " & vbCrLf & _
        "left join wv_fabric_analysis_master fam on ( fam.grey_no=R.grey_no)" & vbCrLf & _
        "group by fam.chop_no, R.grey_no, R.roll_sts"
    End Sub
    Sub BukaDatagrigall()
        'KoneksiCIM()
        'KonCIM.Open()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        '    '
        '    Try
        '        DA = New SqlDataAdapter("select * from wv_prod_plan_detail2 order by plan_date,loom_no, (case shift_time when '3' then 1 when '1' then 2 when '2' then 3 end)", KonCIM)
        '        DS = New DataSet
        '        DA.Fill(DS)
        '        'a3_grd_pcs,a2_grd_pcs,a_grd_pcs,b_grd_pcs,ni_grd_pcs
        '        '--> a3_grd_pcs+a2_grd_pcs =G
        '        'kalau garment_flag <> "G", maka semua grade ditotal
        '        ' --> a3_grd_pcs+a2_grd_pcs+a_grd_pcs+b_grd_pcs+ni_grd_pcs
        '        DGV6.DataSource = DS.Tables(0)
        '        KonCIM.Close()
        '        'DGVGS.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        '        ''
        '        'DGVGS.Columns(0).Width = 90
        '        'DGVGS.Columns(1).Width = 90
        '        'DGVGS.Columns(2).Width = 90
        '        ''
        '        'DGVGS.Columns(3).Width = 80
        '        'DGVGS.Columns(4).Width = 80
        '        'DGVGS.Columns(5).Width = 80
        '        'DGVGS.Columns(6).Width = 80
        '        'DGVGS.Columns(7).Width = 80
        '        ''
        '        'DGVGS.Columns(8).Width = 80
        '        'DGVGS.Columns(9).Width = 80
        '        'DGVGS.Columns(10).Width = 80
        '        'DGVGS.Columns(11).Width = 80
        '        'DGVGS.Columns(12).Width = 80
        '        '
        '        DGV6.ReadOnly = True
        '        ''
        '        'NilaiTanggal = DGVGS.Item(0, 1).Value
        '        'lblJmlGryStk.Text = DGVGS.Rows.Count
        '        ''
        '        KonCIM.Close()
        '    Catch ex As Exception
        '        MessageBox.Show(ex.Message)
        '    End Try
        'End Using
    End Sub

    Private Sub BtnProses42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses42.Click
        KoneksiCIM()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            SimpanData = "insert into wv_prod_plan_detail2(plan_month,plan_date,shift_time,grey_no,loom_no,rec_sts,proc_no)" _
           & "Values (@plan_month,@plan_date,@shift_time,@grey_no,@loom_no,@rec_sts,@proc_no)"
            '
            CMDDETIL2 = New SqlCommand(SimpanData, KonCIM)
            '
            CMDDETIL2.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            'CMDDETIL2.Parameters.Add(New SqlParameter("@plan_version", SqlDbType.TinyInt))
            CMDDETIL2.Parameters.Add(New SqlParameter("@plan_date", SqlDbType.Date))
            CMDDETIL2.Parameters.Add(New SqlParameter("@shift_time", SqlDbType.TinyInt))
            CMDDETIL2.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
            CMDDETIL2.Parameters.Add(New SqlParameter("@loom_no", SqlDbType.VarChar))
            CMDDETIL2.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            CMDDETIL2.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            '
            KonCIM.Open()
            TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
            CMDDETIL2.Transaction = TR
            '
            Try
                For Each row As DataGridViewRow In DGV5.Rows
                    If Not row.IsNewRow Then
                        '
                        CMDDETIL2.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
                        CMDDETIL2.Parameters("@plan_date").Value = row.Cells(0).Value.ToString
                        CMDDETIL2.Parameters("@shift_time").Value = row.Cells(1).Value.ToString
                        CMDDETIL2.Parameters("@grey_no").Value = row.Cells(3).Value.ToString
                        CMDDETIL2.Parameters("@loom_no").Value = row.Cells(2).Value.ToString
                        CMDDETIL2.Parameters("@rec_sts").Value = "A"
                        CMDDETIL2.Parameters("@proc_no").Value = "1"
                        '
                        CMDDETIL2.ExecuteNonQuery()
                    End If
                Next
                '
                TR.Commit()
                'MessageBox.Show("Data Berhasil Disimpan TAHAP4", "Informasi")
                LblWarning.Text = " Data Proses Selesai"
                '
                DGV5.Refresh()
                DGV5.Rows.Clear()
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub
    Private Sub BtnProses41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses41.Click
        ' '' sudah disiapkan namun menggunakan rumus dari fahrul
        'Try
        '    For Each row As DataGridViewRow In DGV4.Rows
        '        If Not row.IsNewRow Then
        '            '
        '            Planmonthedit = cmbPlanMonthedit.Text
        '            'CMDDETIL2.Parameters("@plan_date").Value = row.Cells(0).Value.ToString
        '            GreyNoedit = row.Cells(3).Value.ToString
        '        End If
        '        CekdataGen3()
        '    Next
        '    '
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    'Sub CekdataGen3()
    '    'Dim StatusGen3 As Boolean
    '    KoneksiCIM()
    '    KonCIM.Open()
    '    '
    '    Try
    '        CMD = New SqlCommand("Select * from wv_prod_plan_detail1 where plan_month='" & (cmbPlanMonthedit.Text) & "' and grey_no='" & (GreyNoedit) & "'", KonCIM)
    '        DREDIT = CMD.ExecuteReader
    '        DREDIT.Read()
    '        '
    '        If DREDIT.HasRows = False Then
    '            InputGen3edit()
    '        End If
    '        KonCIM.Close()
    '        '
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    '    '
    'End Sub
    Sub CekdataGreyStok()
        KoneksiCIM()
        Using KonCIM As New SqlConnection(ConStringCIM)
            KonCIM.Open()
            Try
                CMDCARI = New SqlCommand("Select grey_date,grey_no,length from dy_grey_stock", KonCIM)
                DR = CMDCARI.ExecuteReader
                DR.Read()
                '
                If DR.HasRows Then
                    Greyp3 = DR.Item("grey_no")
                    Length3 = DR.Item("length")
                End If
                '
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub
    Sub CekdataGreyStlg2()
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        'Using KonCIM As New SqlConnection(ConStringCIM)
        Try
            CMD = New SqlCommand("Select grey_date,grey_no,length from dy_grey_stock where grey_no='" & (lblGryno.Text) & "'", KonCIM)
            'CMD = New SqlCommand("SELECT r.grey_no as [GREY NO],SUM(r.total_pcs) as [TOTAL PCS],SUM(r.total_length) as [TOTAL MTR] FROM (SELECT a.grey_no, a.grade, a.normal, a.status_pcs,SUM(CASE WHEN a.status_pcs in ('L','S') then 1 ELSE (CASE WHEN a.status_pcs='H' THEN 0.5 ELSE (CASE WHEN a.status_pcs='Q' THEN 0.25 ELSE 0 END) END) END) as total_pcs, SUM(a.pcs_length) as total_length FROM ( SELECT a.grey_no, a.cloth_roll_no, a.piece_no, a.grade, a.pcs_length, a.status_pcs, a.normal FROM wv_grey_insp_detail_prod a left join wv_cloth_roll_registration b on (a.cloth_roll_no=b.cloth_roll_no) WHERE a.rec_type<>'W' and prod_date<= '" & (DtpTanggal.Value) & "' and a.grey_no = '" & (lblGryno.Text) & "')a GROUP BY a.grey_no, a.grade, a.normal, a.status_pcs )r GROUP BY r.grey_no ", KonCIM)
            DR = CMD.ExecuteReader
            DR.Read()
            '
            If DR.HasRows = False Then
                'TPCS = DR.Item("TOTAL PCS")
                TLGT = "0"
                Statusgen3 = True
            Else
                Statusgen3 = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub CekdataPlanHeader()
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            Try
                'PENCARIAN BERDASARKAN TGL REQUESTDATE DAN DATA GREY STOK TABEL DY_GREYSTOK 
                CMD = New SqlCommand("SELECT * from wv_prod_plan_header where plant_month ='" & (cmbPlanMonthedit.Text) & "'", KonCIM)
                DR = CMD.ExecuteReader
                DR.Read()
                '
                If DR.HasRows Then
                    Remindfrmperiod2 = DR.Item("remain_period2_from")
                    Remindtoperiod3 = DR.Item("month3_period2_to")
                End If
                '
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub
    Sub CekdataEffdetail()
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            Try
                'PENCARIAN BERDASARKAN TGL REQUESTDATE DAN DATA GREY STOK TABEL DY_GREYSTOK 
                'CMD = New SqlCommand("SELECT * from wv_ajl_efficiency_detail where Production_Date >='" & (Remindfrmperiod2) & "' and Production_Date <='" & (Remindtoperiod3) & "'", KonCIM)
                DA = New SqlDataAdapter("SELECT Production_Date,Shift_Group_Time,Loom_No,Grey_No from wv_ajl_efficiency_detail where Production_Date >='" & (Remindfrmperiod2) & "' and Production_Date <='" & (Remindtoperiod3) & "'", KonCIM)
                DS = New DataSet
                DA.Fill(DS)
                '
                DGV4.DataSource = DS.Tables(0)
                KonCIM.Close()
                DGV4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                DGV4.Columns(0).Width = 100
                DGV4.Columns(1).Width = 100
                DGV4.Columns(2).Width = 90
                DGV4.Columns(3).Width = 90
                '
                DGV4.ReadOnly = True
                '
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub
    Sub CekdataEffdetail2()
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            Try
                DA = New SqlDataAdapter("SELECT Production_Date,Shift_Group_Time,Loom_No,Grey_No from wv_ajl_efficiency_detail where Production_Date ='" & (Remindfrmperiod2) & "'", KonCIM)
                DS = New DataSet
                DA.Fill(DS)
                '
                DGV4.DataSource = DS.Tables(0)
                KonCIM.Close()
                DGV4.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '
                DGV4.Columns(0).Width = 100
                DGV4.Columns(1).Width = 100
                DGV4.Columns(2).Width = 90
                DGV4.Columns(3).Width = 90
                '
                DGV4.ReadOnly = True
                '
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub
    Sub CekDataEffdetailEdit()
        NTga = Format(DtpTanggal.Value, "yyyy/MM/dd")
        NTgb = Format(DtpTanggal.Value, "yyyy/MM/dd")
        NTgc = Format(DtpTanggal.Value, "yyyy/MM/dd")
        NTgd = Format(DtpTanggal.Value, "yyyy/MM/dd")
        '
        Nilaiawal = Format(DtpTanggal.Value, "dd")
        'Bulanprdawal = Format(DateAdd(DateInterval.Month, 1, NTga), "MM/yyyy")
        NilaiBulansatu = DateSerial(Year(Bulanprdawal), Month(Bulanprdawal), 0)
        NilaiTglawal = Format(NilaiBulansatu, "yyyy/MM/dd")
        Tglawal = Convert.ToDateTime(NilaiTglawal)
        Hrawal = Hasil(Year(NTga), Month(NTga))
        '
        Bulanprd1 = Format(DateAdd(DateInterval.Month, 1, NTgb), "MM/yyyy")
        NilaiTglakhirprd1 = DateSerial(Year(Bulanprd1), Month(Bulanprd1) + 1, 0)
        NilaiTgl1 = Format(NilaiTglakhirprd1, "yyyy/MM/dd")
        Tgl1 = Convert.ToDateTime(NilaiTgl1)
        Hr1 = Hasil(Year(Tgl1), Month(Tgl1))
        '
        Bulanprd2 = Format(DateAdd(DateInterval.Month, 1, NTgc), "MM/yyyy")
        NilaiTglakhirprd2 = DateSerial(Year(Bulanprd2), Month(Bulanprd2) + 2, 0)
        NilaiTgl2 = Format(NilaiTglakhirprd2, "yyyy/MM/dd")
        Tgl2 = Convert.ToDateTime(NilaiTgl2)
        Hr2 = Hasil(Year(Tgl2), Month(Tgl2))
        '
        Bulanprd3 = Format(DateAdd(DateInterval.Month, 1, NTgd), "MM/yyyy")
        NilaiTglakhirprd3 = DateSerial(Year(Bulanprd3), Month(Bulanprd3) + 3, 0)
        NilaiTgl3 = Format((NilaiTglakhirprd3), "yyyy/MM/dd")
        Tgl3 = Convert.ToDateTime(NilaiTgl3)
        Hr3 = Hasil(Year(Tgl3), Month(Tgl3))
        '
        'Bulanawal()
        'Bulan1()
        'Bulan2()
        'Bulan3()
    End Sub
    Function Hasil(ByVal MyYear As Integer, ByVal MyMonth As Integer) As Integer
        Return DateTime.DaysInMonth(MyYear, MyMonth)
    End Function
    Sub Bulanawal()
        'Dim Ulang As Boolean
        'Dim Tgla As Date
        'Dim Tgljadi As Date
        'Dim Tglawal As String
        ''
        'Tgla = Format(NTga, "yyyy/MM/dd")
        'Tgljadi = Tgla
        ''
        'Try
        '    For x = Nilaiawal To Hrawal - 1
        '        Hasilawal = (DateAdd(DateInterval.Day, 1, Tgljadi))
        '        Tgljadi = Hasilawal
        '        Tglawal = Format(Hasilawal, "yyyy/MM/dd")
        '        '
        '        For Each row As DataGridViewRow In DGV4.Rows
        '            If Not row.IsNewRow Then
        '                DGV5.Rows.Add()
        '                '
        '                For barisatas As Integer = 0 To DGV5.RowCount - 1
        '                    For barisbawah As Integer = barisatas + 1 To DGV5.RowCount - 1
        '                    Next
        '                Next
        '                '
        '                DGV5(0, DGV5.RowCount - 2).Value = Tglawal 'Format(Tgljadi, "yyyy/MM/dd")
        '                DGV5(1, DGV5.RowCount - 2).Value = row.Cells(1).Value.ToString
        '                DGV5(2, DGV5.RowCount - 2).Value = row.Cells(2).Value.ToString
        '                DGV5(3, DGV5.RowCount - 2).Value = row.Cells(3).Value.ToString
        '                '
        '            End If
        '        Next
        '    Next x
        '    '
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try
    End Sub
    Sub Bulan1()
        'Dim Tgl1, Bln1, Thn1 As String
        'Dim Tgljadi As Date
        'Dim H As Integer
        ''
        ''Hasil1 = NTgb
        'Bln1 = Format(NilaiTglakhirprd1, "MM")
        'Thn1 = Format(NilaiTglakhirprd1, "yyyy")
        ''Tgl1 = Format(NTgb, "yyyy/MM/dd")
        'Try
        '    For H = 1 To Hr1
        '        'Hasil1 = (DateAdd(DateInterval.Day, 1, NTgb))
        '        Tgl1 = Thn1 & "/" & Bln1 & "/" & H
        '        Tgljadi = Convert.ToDateTime(Tgl1)
        '        '
        '        For Each row As DataGridViewRow In DGV4.Rows
        '            If Not row.IsNewRow Then
        '                DGV5.Rows.Add()
        '                '
        '                For barisatas As Integer = 0 To DGV5.RowCount - 1
        '                    For barisbawah As Integer = barisatas + 1 To DGV5.RowCount - 1
        '                    Next
        '                Next
        '                '
        '                DGV5(0, DGV5.RowCount - 2).Value = Tgl1 'Format(Tgljadi, "yyyy/MM/dd")
        '                DGV5(1, DGV5.RowCount - 2).Value = row.Cells(1).Value.ToString
        '                DGV5(2, DGV5.RowCount - 2).Value = row.Cells(2).Value.ToString
        '                DGV5(3, DGV5.RowCount - 2).Value = row.Cells(3).Value.ToString
        '                '
        '            End If
        '        Next
        '        '
        '    Next H
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try

    End Sub
    Sub Bulan2()
        'Dim Tgl2, Bln2, Thn2 As String
        'Dim Tgljadi As Date
        'Dim J As Integer
        ''
        'Bln2 = Format(NilaiTglakhirprd2, "MM")
        'Thn2 = Format(NilaiTglakhirprd2, "yyyy")
        'For J = 1 To Hr2
        '    'Hasil2 = (DateAdd(DateInterval.Day, 1, NTgc))
        '    Tgl2 = Thn2 & "/" & Bln2 & "/" & J
        '    Tgljadi = Convert.ToDateTime(Tgl2)
        '    '        '
        '    For Each row As DataGridViewRow In DGV4.Rows
        '        If Not row.IsNewRow Then
        '            DGV5.Rows.Add()
        '            '
        '            For barisatas As Integer = 0 To DGV5.RowCount - 1
        '                For barisbawah As Integer = barisatas + 1 To DGV5.RowCount - 1
        '                Next
        '            Next
        '            '
        '            DGV5(0, DGV5.RowCount - 2).Value = Tgl2 'Format(Tgljadi, "yyyy/MM/dd")
        '            DGV5(1, DGV5.RowCount - 2).Value = row.Cells(1).Value.ToString
        '            DGV5(2, DGV5.RowCount - 2).Value = row.Cells(2).Value.ToString
        '            DGV5(3, DGV5.RowCount - 2).Value = row.Cells(3).Value.ToString
        '            '
        '        End If
        '    Next
        'Next J
    End Sub
    Sub Bulan3()
        'Dim Tgl3, Bln3, Thn3 As String
        'Dim Tgljadi As Date
        ''
        ''Hasil3 = NTgd
        'Bln3 = Format(NilaiTglakhirprd3, "MM")
        'Thn3 = Format(NilaiTglakhirprd3, "yyyy")
        'For x = 1 To Hr3
        '    'Hasil2 = (DateAdd(DateInterval.Day, 1, NTgd))
        '    Tgl3 = Thn3 & "/" & Bln3 & "/" & x
        '    Tgljadi = Convert.ToDateTime(Tgl3)

        'Next x
    End Sub

    Sub CekdataProdHeader()
        KoneksiCIM()
        KonCIM.Open()
        '
        ' Using KonCIM As New SqlConnection(ConStringCIM)
        Try
            'PENCARIAN PROD_WV_PLAN_HEADER BERDASARKAN PLAN_MONTH 
            CMDCARI = New SqlCommand("SELECT * from wv_prod_plan_header where plan_month='" & (cmbPlanMonthedit.Text) & "'", KonCIM)
            DR = CMDCARI.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                Remindfrmperiod2 = DR.Item("remain_period2_from")
                Remindtoperiod3 = DR.Item("month3_period2_to")
            End If
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub

    Sub CekdataGreyLength()
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        'Using KonCIM As New SqlConnection(ConStringCIM)
        Try
            'PENCARIAN BERDASAARKAN TGL REQUESTDATE DAN DATA GREY STOK TABEL DY_GREYSTOK 
            CMD = New SqlCommand("SELECT r.grey_no as [GREY NO],SUM(r.total_pcs) as [TOTAL PCS],SUM(r.total_length) as [TOTAL MTR] FROM (SELECT a.grey_no, a.grade, a.normal, a.status_pcs,SUM(CASE WHEN a.status_pcs in ('L','S') then 1 ELSE (CASE WHEN a.status_pcs='H' THEN 0.5 ELSE (CASE WHEN a.status_pcs='Q' THEN 0.25 ELSE 0 END) END) END) as total_pcs, SUM(a.pcs_length) as total_length FROM ( SELECT a.grey_no, a.cloth_roll_no, a.piece_no, a.grade, a.pcs_length, a.status_pcs, a.normal FROM wv_grey_insp_detail_prod a left join wv_cloth_roll_registration b on (a.cloth_roll_no=b.cloth_roll_no) WHERE a.rec_type<>'W' and prod_date<= '" & (NilaiTanggal) & "' and a.grey_no = '" & (lblGryno.Text) & "')a GROUP BY a.grey_no, a.grade, a.normal, a.status_pcs )r GROUP BY r.grey_no ", KonCIM)
            DR = CMD.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then
                TPCS = DR.Item("TOTAL PCS")
                TMTR = DR.Item("TOTAL MTR")
                'GreyNo = DR.Item("GREY NO")
            Else
                TPCS = "0"
                TMTR = "0"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'End Using
    End Sub
    Sub BukadataGreyLength()
        '
        'Dim TPCS, TMTR As Integer
        ''
        'NilaiTanggal = DtpTanggal.Value
        KoneksiCIM()
        KonCIM.Open()
        Using KonCIM As New SqlConnection(ConStringCIM)
            '
            Try
                'DA = New SqlDataAdapter("SELECT r.grey_no as [GREY NO],SUM(r.total_pcs) as [TOTAL PCS],SUM(r.total_length) as [TOTAL MTR] FROM (SELECT a.grey_no, a.grade, a.normal, a.status_pcs,SUM(CASE WHEN a.status_pcs in ('L','S') then 1 ELSE (CASE WHEN a.status_pcs='H' THEN 0.5 ELSE (CASE WHEN a.status_pcs='Q' THEN 0.25 ELSE 0 END) END) END) as total_pcs, SUM(a.pcs_length) as total_length FROM ( SELECT a.grey_no, a.cloth_roll_no, a.piece_no, a.grade, a.pcs_length, a.status_pcs, a.normal FROM wv_grey_insp_detail_prod a left join wv_cloth_roll_registration b on (a.cloth_roll_no=b.cloth_roll_no) WHERE a.rec_type<>'W' and prod_date<='2020-01-02')a GROUP BY a.grey_no, a.grade, a.normal, a.status_pcs )r GROUP BY r.grey_no", KonCIM)
                DA = New SqlDataAdapter("SELECT r.grey_no as [GREY NO],SUM(r.total_pcs) as [TOTAL PCS],SUM(r.total_length) as [TOTAL MTR] FROM (SELECT a.grey_no, a.grade, a.normal, a.status_pcs,SUM(CASE WHEN a.status_pcs in ('L','S') then 1 ELSE (CASE WHEN a.status_pcs='H' THEN 0.5 ELSE (CASE WHEN a.status_pcs='Q' THEN 0.25 ELSE 0 END) END) END) as total_pcs, SUM(a.pcs_length) as total_length FROM ( SELECT a.grey_no, a.cloth_roll_no, a.piece_no, a.grade, a.pcs_length, a.status_pcs, a.normal FROM wv_grey_insp_detail_prod a left join wv_cloth_roll_registration b on (a.cloth_roll_no=b.cloth_roll_no) WHERE a.rec_type<>'W' and prod_date <= '" & (NilaiTanggal) & "')a GROUP BY a.grey_no, a.grade, a.normal, a.status_pcs )r GROUP BY r.grey_no", KonCIM)
                DS = New DataSet
                DA.Fill(DS)
                '
                DGV3.DataSource = DS.Tables(0)
                KonCIM.Close()
                DGV3.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '
                DGV3.Columns(0).Width = 130
                DGV3.Columns(1).Width = 100 'tpcs
                DGV3.Columns(2).Width = 100 'tmtr
                '
                DGV3.ReadOnly = True
                '
                lblJmlGryGbg.Text = DGV3.Rows.Count
                '
                KonCIM.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub
    Sub BukadataGreyStok2()
        Dim TglGreystok As Date
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            Try
                TglGreystok = (DateAdd(DateInterval.Day, -1, DtpTanggal.Value))
                '
                sql = "Select R.grey_no, fam.chop_no, (case when R.roll_sts='1' then 'R' else '' end) as grey_sts, max(fam.length_gr) as std_length, " & vbCrLf & _
                "cast(sum(Case When R.grade='NI' and R.normal='N' and R.status_pcs in ('L','S') then R.pcs else 0 end) as decimal(10,2)) as ni_grd_pcs," & vbCrLf & _
                "cast(sum(Case When R.grade='NI' and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as ni_grd_length," & vbCrLf & _
                "cast(sum(Case When R.grade='A3' and R.normal='N' and R.status_pcs in ('L','S') then R.pcs else 0 end) as decimal(10,2)) as a3_grd_pcs," & vbCrLf & _
                "cast(sum(Case When R.grade='A3' and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as a3_grd_length," & vbCrLf & _
                "cast(sum(Case When R.grade='A2' and R.normal='N' and R.status_pcs in ('L','S') then R.pcs else 0 end) as decimal(10,2)) as a2_grd_pcs," & vbCrLf & _
                "cast(sum(Case When R.grade='A2' and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as a2_grd_length," & vbCrLf & _
                "cast(sum(Case When R.grade='A' and R.normal='N' and R.status_pcs in ('L','S') then R.pcs else 0 end) as decimal(10,2)) as a_grd_pcs," & vbCrLf & _
                "cast(sum(Case When R.grade='A' and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as a_grd_length," & vbCrLf & _
                "cast(sum(Case When R.grade='B' and R.normal='N' and R.status_pcs in ('L','S') then R.pcs else 0 end) as decimal(10,2)) as b_grd_pcs," & vbCrLf & _
                "cast(sum(Case When R.grade='B' and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as b_grd_length," & vbCrLf & _
                "cast(sum(Case When R.grade in ('NI','A3','A2','A','B') and R.normal='N' and R.status_pcs in ('L','S') then R.length else 0 end) as decimal(10,2)) as length " & vbCrLf & _
                "from (select h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts," & vbCrLf & _
                "COUNT(d.piece_no) as pcs, cast(sum(h.piece_length) as decimal(10,2)) as length from wv_wh_detail d" & vbCrLf & _
                "left join (select *,length/tot_pcs as piece_length from wv_wh_header) h on (h.barcode=d.barcode) " & vbCrLf & _
                "where h.whs_date<>'' and h.rec_type<>'D' and h.rec_sts<>'C' and h.tot_pcs<>0 " & vbCrLf & _
                "and h.whs_date<='" & (TglGreystok) & "'" & vbCrLf & _
                "group by h.whs_date, h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts" & vbCrLf & _
                "union all select h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts," & vbCrLf & _
                "COUNT(d.piece_no) as pcs, cast(sum(h.piece_length) as decimal(10,2)) as length" & vbCrLf & _
                "from wv_wh_detail d " & vbCrLf & _
                "left join (select *,length/tot_pcs as piece_length from wv_wh_header) h on (h.barcode=d.barcode)" & vbCrLf & _
                "where d.rec_type='D' and d.rec_sts<>'C' " & vbCrLf & _
                "and h.whs_date <='" & (TglGreystok) & "' and h.proc_date >'" & (TglGreystok) & "'" & vbCrLf & _
                "group by h.whs_date, h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts " & vbCrLf & _
                "union all select h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts," & vbCrLf & _
                "COUNT(d.piece_no) as pcs, cast(sum(h.piece_length) as decimal(10,2)) as length" & vbCrLf & _
                "from wv_wh_cancel_detail d " & vbCrLf & _
                "left join (select *,length/tot_pcs as piece_length from wv_wh_cancel) h on (h.barcode=d.barcode)" & vbCrLf & _
                "where d.rec_type='C' and d.rec_sts='C'" & vbCrLf & _
                "and h.whs_date <='" & (TglGreystok) & "' and h.proc_date >'" & (TglGreystok) & "'" & vbCrLf & _
                "group by h.whs_date, h.grey_no, d.grade, h.normal, h.status_pcs, h.roll_sts" & vbCrLf & _
                ")R " & vbCrLf & _
                "left join wv_fabric_analysis_master fam on ( fam.grey_no=R.grey_no)" & vbCrLf & _
                "group by fam.chop_no, R.grey_no, R.roll_sts"
                DA = New SqlDataAdapter(sql, KonCIM)
                '
                DS = New DataSet
                DA.Fill(DS)
                '
                DGVGS.DataSource = DS.Tables(0)
                KonCIM.Close()
                DGVGS.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '
                DGVGS.Columns(0).Width = 90
                DGVGS.Columns(1).Width = 90
                DGVGS.Columns(2).Width = 90
                '
                DGVGS.Columns(3).Width = 80
                DGVGS.Columns(4).Width = 80
                DGVGS.Columns(5).Width = 80
                DGVGS.Columns(6).Width = 80
                DGVGS.Columns(7).Width = 80
                '
                DGVGS.Columns(8).Width = 80
                DGVGS.Columns(9).Width = 80
                DGVGS.Columns(10).Width = 80
                DGVGS.Columns(11).Width = 80
                DGVGS.Columns(12).Width = 80
                DGVGS.Columns(13).Width = 80
                DGVGS.Columns(14).Width = 80
                '
                NilaiTanggal = Format(TglGreystok, "yyyy/MM/dd") 'DGVGS.Item(0, 1).Value
                lblJmlGryStk.Text = DGVGS.Rows.Count
                '
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub
    Sub BukadataGreyStok()
        KoneksiCIM()
        KonCIM.Open()
        Using KonCIM As New SqlConnection(ConStringCIM)
            '
            Try
                DA = New SqlDataAdapter("Select grey_date,grey_no,length,a3_grd_length,2_grd_length,a_grd_length,b_grd_length,ni_grd_length,a3_grd_pcs,a2_grd_pcs,a_grd_pcs,b_grd_pcs,ni_grd_pcs from dy_grey_stock", KonCIM)
                '
                DS = New DataSet
                DA.Fill(DS)
                'a3_grd_pcs,a2_grd_pcs,a_grd_pcs,b_grd_pcs,ni_grd_pcs
                '--> a3_grd_pcs+a2_grd_pcs =G
                'kalau garment_flag <> "G", maka semua grade ditotal
                ' --> a3_grd_pcs+a2_grd_pcs+a_grd_pcs+b_grd_pcs+ni_grd_pcs
                DGVGS.DataSource = DS.Tables(0)
                KonCIM.Close()
                DGVGS.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                '
                DGVGS.Columns(0).Width = 90
                DGVGS.Columns(1).Width = 90
                DGVGS.Columns(2).Width = 90
                '
                DGVGS.Columns(3).Width = 80
                DGVGS.Columns(4).Width = 80
                DGVGS.Columns(5).Width = 80
                DGVGS.Columns(6).Width = 80
                DGVGS.Columns(7).Width = 80
                '
                DGVGS.Columns(8).Width = 80
                DGVGS.Columns(9).Width = 80
                DGVGS.Columns(10).Width = 80
                DGVGS.Columns(11).Width = 80
                DGVGS.Columns(12).Width = 80
                '
                DGVGS.ReadOnly = True
                '
                NilaiTanggal = DGVGS.Item(0, 1).Value
                lblJmlGryStk.Text = DGVGS.Rows.Count
                '
                KonCIM.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub

    Private Sub BtnProses31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses31.Click
        '
        Dim Grystok, GrystokPCS As Double
        'LblWarning.Text = " Proses Ketiga sedang berjalan Silahkan Tunggu....!!"
        Using KonCIM As New SqlConnection(ConStringCIM)
            '
            SimpanData = "insert into wv_prod_plan_detail1(plan_month,grey_no,grey_stock_qty,grey_stock_qty_pcs,wip3_qty,wip3_qty_pcs,rec_sts,proc_no)" _
                & "Values (@plan_month,@grey_no,@grey_stock_qty,@grey_stock_qty_pcs,@wip3_qty,@wip3_qty_pcs,@rec_sts,@proc_no)"
            '
            CMDDETIL1 = New SqlCommand(SimpanData, KonCIM)
            '
            CMDDETIL1.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            'CMDDETIL1.Parameters.Add(New SqlParameter("@plan_version", SqlDbType.VarChar))
            'CMDDETIL1.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
            CMDDETIL1.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
            CMDDETIL1.Parameters.Add(New SqlParameter("@grey_stock_qty", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@grey_stock_qty_pcs", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@wip3_qty", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@wip3_qty_pcs", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            CMDDETIL1.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            '
            KonCIM.Open()
            TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
            CMDDETIL1.Transaction = TR
            ''
            Try
                For Each row As DataGridViewRow In DGVGS.Rows
                    If Not row.IsNewRow Then
                        '
                        Tglrequest = Convert.ToDateTime(HasilTgl) 'Convert.ToDateTime(row.Cells(0).Value.ToString)
                        '
                        CekDataGreySalesEntry()
                        CekdataGreyLength()
                        lblGryno.Text = row.Cells(0).Value.ToString
                        'row.Cells(1).Value.ToString
                        'a3_grd_length+,2_grd_length
                        'a3_grd_length+a2_grd_length+a_grd_length+b_grd_length+ni_grd_length
                        'Stock Qty
                        If Gflag = "G" Then
                            'Grystok = CDbl(row.Cells(4).Value.ToString) + CDbl(row.Cells(5).Value.ToString)
                            Grystok = CDbl(row.Cells(7).Value.ToString) + CDbl(row.Cells(9).Value.ToString)
                        Else
                            'Grystok = CDbl(row.Cells(4).Value.ToString) + CDbl(row.Cells(5).Value.ToString) + CDbl(row.Cells(6).Value.ToString) + CDbl(row.Cells(7).Value.ToString) + CDbl(row.Cells(8).Value.ToString)
                            Grystok = CDbl(row.Cells(7).Value.ToString) + CDbl(row.Cells(9).Value.ToString) + CDbl(row.Cells(11).Value.ToString) + CDbl(row.Cells(13).Value.ToString) + CDbl(row.Cells(5).Value.ToString)
                        End If
                        'Stock PCS
                        If Gflag = "G" Then
                            GrystokPCS = CDbl(row.Cells(6).Value.ToString) + CDbl(row.Cells(8).Value.ToString)
                        Else
                            GrystokPCS = CDbl(row.Cells(6).Value.ToString) + CDbl(row.Cells(8).Value.ToString) + CDbl(row.Cells(10).Value.ToString) + CDbl(row.Cells(12).Value.ToString) + CDbl(row.Cells(4).Value.ToString)
                        End If
                        '
                        CMDDETIL1.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
                        'CMDDETIL1.Parameters("@plan_version").Value = "1"
                        'CMDDETIL1.Parameters("@request_date").Value = DtpTanggal.Value
                        CMDDETIL1.Parameters("@grey_no").Value = row.Cells(0).Value.ToString
                        'row.Cells(1).Value.ToString()
                        CMDDETIL1.Parameters("@grey_stock_qty").Value = Grystok
                        CMDDETIL1.Parameters("@grey_stock_qty_pcs").Value = GrystokPCS
                        CMDDETIL1.Parameters("@wip3_qty").Value = TMTR
                        CMDDETIL1.Parameters("@wip3_qty_pcs").Value = TPCS
                        'TPCS
                        CMDDETIL1.Parameters("@rec_sts").Value = "A"
                        CMDDETIL1.Parameters("@proc_no").Value = "1"
                        '
                        CMDDETIL1.ExecuteNonQuery()
                    End If
                Next
                TR.Commit()
                ' MessageBox.Show("Data Berhasil Disimpan", "Informasi")
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub

    Private Sub BtnProses32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses32.Click
        ' Dim Grystok, GrystokPCS As Double
        Using KonCIM As New SqlConnection(ConStringCIM)
            'SimpanData = "insert into wv_prod_plan_detail1(plan_month,grey_no,grey_stock_qty,wip3_qty,rec_sts,proc_no)" _
            '    & "Values (@plan_month,@grey_no,@grey_stock_qty,@wip3_qty,@rec_sts,@proc_no)"
            SimpanData = "insert into wv_prod_plan_detail1(plan_month,grey_no,grey_stock_qty,grey_stock_qty_pcs,wip3_qty,wip3_qty_pcs,rec_sts,proc_no)" _
                & "Values (@plan_month,@grey_no,@grey_stock_qty,@grey_stock_qty_pcs,@wip3_qty,@wip3_qty_pcs,@rec_sts,@proc_no)"
            '
            CMDDETIL1 = New SqlCommand(SimpanData, KonCIM)
            '
            CMDDETIL1.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            'CMDDETIL1.Parameters.Add(New SqlParameter("@plan_version", SqlDbType.VarChar))
            'CMDDETIL1.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
            CMDDETIL1.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
            CMDDETIL1.Parameters.Add(New SqlParameter("@grey_stock_qty", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@grey_stock_qty_pcs", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@wip3_qty", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@wip3_qty_pcs", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            CMDDETIL1.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            '
            KonCIM.Open()
            TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
            CMDDETIL1.Transaction = TR
            '
            ' dari perulangan dari tabel wv_rumus untuk wip3_qty dimana untuk menyimpan data yang tidak cocok dengan data dy_grey_stok
            Try
                For Each row As DataGridViewRow In DGV3.Rows
                    If Not row.IsNewRow Then
                        '
                        lblGryno.Text = row.Cells(0).Value.ToString
                        CekdataGreyStlg2()
                        '
                        If Statusgen3 = True Then
                            CMDDETIL1.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
                            CMDDETIL1.Parameters("@grey_no").Value = row.Cells(0).Value.ToString
                            CMDDETIL1.Parameters("@grey_stock_qty").Value = TLGT
                            CMDDETIL1.Parameters("@grey_stock_qty_pcs").Value = "0" 'TPCS
                            CMDDETIL1.Parameters("@wip3_qty").Value = CDbl(row.Cells(2).Value.ToString) 'TOTAL MTR D
                            CMDDETIL1.Parameters("@wip3_qty_pcs").Value = CDbl(row.Cells(1).Value.ToString)
                            CMDDETIL1.Parameters("@rec_sts").Value = "A"
                            CMDDETIL1.Parameters("@proc_no").Value = "1"
                            '
                            CMDDETIL1.ExecuteNonQuery()
                        End If
                    End If
                Next
                '
                'LblWarning.Text = " Proses Ketiga sudah dilakukan"
                TR.Commit()
                '  MessageBox.Show("Data Berhasil Disimpan Sampai Tahap 3", "Informasi")
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            End Try
        End Using
    End Sub
    Sub CekDataGreySalesEntry()
        KoneksiISTEM()
        KonIstem.Open()
        '
        CMDCARI = New SqlCommand("Select plan_month,grey_no,remain_input_qty,garment_flag from sl_grey_request where plan_month = '" & (cmbPlanMonthedit.Text) & "' and grey_no = '" & (txtGreyno.Text) & "'", KonIstem)
        '
        DREDIT = CMDCARI.ExecuteReader
        DREDIT.Read()
        '
        If DREDIT.HasRows Then
            GreyNo = DREDIT.Item("grey_no")
            Gflag = DREDIT.Item("garment_flag")
        End If
    End Sub
    Sub InputGen3edit()
        KoneksiCIM()
        KonCIM.Open()
        'Using KonCIM As New SqlConnection(ConStringCIM)
        Try
            '
            SimpanData = "insert into wv_prod_plan_detail1(plan_month,grey_no,grey_stock_qty,grey_stock_qty_pcs,wip3_qty,wip3_qty_pcs,rec_sts,proc_no)" _
                & "Values (@plan_month,@grey_no,@grey_stock_qty,@grey_stock_qty_pcs,@wip3_qty,@wip3_qty_pcs,@rec_sts,@proc_no)"
            '
            KonCIM.Close()
            '
            CMDDETIL1 = New SqlCommand(SimpanData, KonCIM)
            '
            CMDDETIL1.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            CMDDETIL1.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
            CMDDETIL1.Parameters.Add(New SqlParameter("@grey_stock_qty", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@grey_stock_qty_pcs", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@wip3_qty", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@wip3_qty_pcs", SqlDbType.Float))
            CMDDETIL1.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            CMDDETIL1.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            '
            KonCIM.Open()
            TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
            CMDDETIL1.Transaction = TR
            '
            CMDDETIL1.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
            CMDDETIL1.Parameters("@grey_no").Value = GreyNoedit
            CMDDETIL1.Parameters("@grey_stock_qty").Value = "0"
            CMDDETIL1.Parameters("@grey_stock_qty_pcs").Value = "0" 'TPCS
            CMDDETIL1.Parameters("@wip3_qty").Value = "0"
            CMDDETIL1.Parameters("@wip3_qty_pcs").Value = "0"
            CMDDETIL1.Parameters("@rec_sts").Value = "A"
            CMDDETIL1.Parameters("@proc_no").Value = "1"
            '
            CMDDETIL1.ExecuteNonQuery()
            TR.Commit()
        Catch ex As Exception
            Try
                TR.Rollback()
                MessageBox.Show(ex.Message)
            Catch rollBackEx As Exception
                MessageBox.Show(rollBackEx.Message)
            End Try
        End Try
        KonCIM.Close()
        'End Using
    End Sub
    Private Sub cmbPlanMonthedit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlanMonthedit.SelectedIndexChanged
        BukaDataSalesGrey()
    End Sub

    Private Sub BtnProses43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses43.Click
        Dim Tgla As Date
        'Dim Tgljadi As Date
        Dim Tglawal As String
        ' Dim Harilibur As Boolean
        Dim Lanjut As Boolean
        '
        Tgla = Format(NTga, "yyyy/MM/dd")
        Tgljadi = Tgla
        '
        Try
            For x = Nilaiawal To Hrawal
                If Lanjut = True Then
                    Hasilawal = (DateAdd(DateInterval.Day, 1, Tgljadi))
                Else
                    Hasilawal = Tgljadi
                End If
                'Hari Sabtu dan Minggu jatuhnya dianggap tidak ada produksi
                'dibaikan terlebih dahulu karena ceknya melalui Wv_shift_detail saja
                'If Weekday(Hasilawal) = 1 Or Weekday(Hasilawal) = 7 Then
                '    Harilibur = True
                'Else
                '    Harilibur = False
                'End If
                ''
                Tgljadi = Hasilawal
                Tglawal = Format(Hasilawal, "yyyy/MM/dd")
                '
                CekdataShift()
                If Harilibur = False Then
                    For Each row As DataGridViewRow In DGV4.Rows
                        If Not row.IsNewRow Then
                            DGV5.Rows.Add()
                            '
                            For barisatas As Integer = 0 To DGV5.RowCount - 1
                                For barisbawah As Integer = barisatas + 1 To DGV5.RowCount - 1
                                Next
                            Next
                            '
                            DGV5(0, DGV5.RowCount - 2).Value = Tglawal 'Format(Tgljadi, "yyyy/MM/dd")
                            DGV5(1, DGV5.RowCount - 2).Value = row.Cells(1).Value.ToString
                            DGV5(2, DGV5.RowCount - 2).Value = row.Cells(2).Value.ToString
                            DGV5(3, DGV5.RowCount - 2).Value = row.Cells(3).Value.ToString
                            '
                        End If
                    Next
                End If
                Lanjut = True
            Next x
            '
            'Harilibur = False
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnProses44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses44.Click
        Dim Tgl1, Bln1, Thn1 As String
        ' Dim Tgljadi As Date
        Dim H As Integer
        'Dim Harilibur As Boolean
        '
        'Hasil1 = NTgb
        Bln1 = Format(NilaiTglakhirprd1, "MM")
        Thn1 = Format(NilaiTglakhirprd1, "yyyy")
        'Tgl1 = Format(NTgb, "yyyy/MM/dd")
        Try

            For H = 1 To Hr1
                'Hasil1 = (DateAdd(DateInterval.Day, 1, NTgb))
                Tgl1 = Thn1 & "/" & Bln1 & "/" & H
                Tgljadi = Convert.ToDateTime(Tgl1)
                '
                'Hari Sabtu dan Minggu jatuhnya dianggap tidak ada produksi
                'If Weekday(Tgljadi) = 1 Or Weekday(Tgljadi) = 7 Then
                '    Harilibur = True
                'Else
                '    Harilibur = False
                'End If
                '
                CekdataShift()
                If Harilibur = False Then
                    For Each row As DataGridViewRow In DGV4.Rows
                        If Not row.IsNewRow Then
                            DGV5.Rows.Add()
                            '
                            For barisatas As Integer = 0 To DGV5.RowCount - 1
                                For barisbawah As Integer = barisatas + 1 To DGV5.RowCount - 1
                                Next
                            Next
                            '
                            DGV5(0, DGV5.RowCount - 2).Value = Tgl1 'Format(Tgljadi, "yyyy/MM/dd")
                            DGV5(1, DGV5.RowCount - 2).Value = row.Cells(1).Value.ToString
                            DGV5(2, DGV5.RowCount - 2).Value = row.Cells(2).Value.ToString
                            DGV5(3, DGV5.RowCount - 2).Value = row.Cells(3).Value.ToString
                            '
                        End If
                    Next
                    '
                End If
            Next H
            Harilibur = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnProses45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses45.Click
        Dim Tgl2, Bln2, Thn2 As String
        '  Dim Tgljadi As Date
        Dim J As Integer
        '  Dim Harilibur As Boolean
        Bln2 = Format(NilaiTglakhirprd2, "MM")
        Thn2 = Format(NilaiTglakhirprd2, "yyyy")
        Try
            For J = 1 To Hr2
                'Hasil2 = (DateAdd(DateInterval.Day, 1, NTgc))
                Tgl2 = Thn2 & "/" & Bln2 & "/" & J
                Tgljadi = Convert.ToDateTime(Tgl2)
                '
                'Hari Sabtu dan Minggu jatuhnya dianggap tidak ada produksi
                'If Weekday(Tgljadi) = 1 Or Weekday(Tgljadi) = 7 Then
                '    Harilibur = True
                'Else
                '    Harilibur = False
                'End If
                '
                If Harilibur = False Then
                    For Each row As DataGridViewRow In DGV4.Rows
                        If Not row.IsNewRow Then
                            DGV5.Rows.Add()
                            '
                            For barisatas As Integer = 0 To DGV5.RowCount - 1
                                For barisbawah As Integer = barisatas + 1 To DGV5.RowCount - 1
                                Next
                            Next
                            '
                            DGV5(0, DGV5.RowCount - 2).Value = Tgl2 'Format(Tgljadi, "yyyy/MM/dd")
                            DGV5(1, DGV5.RowCount - 2).Value = row.Cells(1).Value.ToString
                            DGV5(2, DGV5.RowCount - 2).Value = row.Cells(2).Value.ToString
                            DGV5(3, DGV5.RowCount - 2).Value = row.Cells(3).Value.ToString
                            '
                        End If
                    Next
                End If
            Next J
            Harilibur = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub BtnProses46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses46.Click
        Dim Tgl3, Bln3, Thn3 As String
        'Dim Tgljadi As Date
        Dim K As Integer
        ' Dim Harilibur As Boolean
        '
        'Hasil3 = NTgd
        Bln3 = Format(NilaiTglakhirprd3, "MM")
        Thn3 = Format(NilaiTglakhirprd3, "yyyy")
        Try
            For K = 1 To Hr3
                'Hasil2 = (DateAdd(DateInterval.Day, 1, NTgd))
                Tgl3 = Thn3 & "/" & Bln3 & "/" & K
                Tgljadi = Convert.ToDateTime(Tgl3)
                'Hari Sabtu dan Minggu jatuhnya dianggap tidak ada produksi
                'If Weekday(Tgljadi) = 1 Or Weekday(Tgljadi) = 7 Then
                '    Harilibur = True
                'Else
                '    Harilibur = False
                'End If
                '
                If Harilibur = False Then
                    For Each row As DataGridViewRow In DGV4.Rows
                        If Not row.IsNewRow Then
                            DGV5.Rows.Add()
                            '
                            For barisatas As Integer = 0 To DGV5.RowCount - 1
                                For barisbawah As Integer = barisatas + 1 To DGV5.RowCount - 1
                                Next
                            Next
                            '
                            DGV5(0, DGV5.RowCount - 2).Value = Tgl3 'Format(Tgljadi, "yyyy/MM/dd")
                            DGV5(1, DGV5.RowCount - 2).Value = row.Cells(1).Value.ToString
                            DGV5(2, DGV5.RowCount - 2).Value = row.Cells(2).Value.ToString
                            DGV5(3, DGV5.RowCount - 2).Value = row.Cells(3).Value.ToString
                            '
                        End If
                    Next
                End If
            Next K
            Harilibur = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub KoneksiExcel()
        KonEx = New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; Data Source='" & OpenFileDialog1.FileName & "';Extended Properties=Excel 8.0;")
    End Sub
    Private Sub BtnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpload.Click
        Dim FileEx As OpenFileDialog = New OpenFileDialog
        '
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "(*.xls)|*.xls"
        OpenFileDialog1.ShowDialog()
        '
        If OpenFileDialog1.FileName <> "" Then
            txtFile.Text = OpenFileDialog1.FileName
            KoneksiExcel()
            '
            DAex = New OleDbDataAdapter("select * from [Sheet1$] ", KonEx)
            DSex = New DataSet
            '
            DAex.Fill(DS)
            DGVEX.DataSource = DS.Tables(1)
            DGVEX.ReadOnly = True
            '
            StatusUpload = True
            MessageBox.Show("Data Berhasil Di Tampung", "Informasi")
        Else
            StatusUpload = False
            MessageBox.Show("Data Belum Diupload", "Informasi")
        End If
        '
        'frmUploadWIP3.lblPlanMonth.Text = cmbPlanMonthedit.Text
        'frmUploadWIP3.lblTanggal.Text = Format(DtpTanggal.Value, "yyyy/MM/dd")
        'frmUploadWIP3.ShowDialog()
        '
    End Sub
    Sub CekProdPlan1()
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select * from wv_fabric_analysis_master where grey_no = '" & (GreyNoedit) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            lbllength_grey.Text = DR.Item("length_gr")
            lblProdPCS.Text = CDbl(NilaiPCS * lbllength_grey.Text)
            EditWip3 = True
        Else
            EditWip3 = False
        End If
        'DREDIT.Item("grey_no")
    End Sub
    Sub UpdatePlan1()
        Dim Ubahdata, InputData As String
        KoneksiCIM()
        KonCIM.Open()
        '
        If EditWip3 = True Then
            Ubahdata = "Update wv_prod_plan_detail1 set plan_month=@plan_month,wip3_qty=@wip3_qty where plan_month=@plan_month and grey_no=@grey_no"
            Try
                Dim CMDUbahplan1 As New SqlCommand(Ubahdata, KonCIM)
                '
                CMDUbahplan1.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                CMDUbahplan1.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
                CMDUbahplan1.Parameters.Add(New SqlParameter("@wip3_qty", SqlDbType.Float))
                '
                'KonCIM.Open()
                TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
                CMDUbahplan1.Transaction = TR
                '
                CMDUbahplan1.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
                CMDUbahplan1.Parameters("@grey_no").Value = GreyNoedit
                CMDUbahplan1.Parameters("@wip3_qty").Value = lblProdPCS.Text
                '
                CMDUbahplan1.ExecuteNonQuery()
                TR.Commit()
                '
            Catch ex As Exception
                Try
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                Catch rollBackEx As Exception
                    MessageBox.Show(rollBackEx.Message)
                End Try
            End Try
        Else
            InputData = "Insert Into wv_prod_plan_detail1 plan_month,grey_no,grey_stok_qty,grey_stok_pcs,wip3_qty,wip3_qty_pcs,rec_sts,proc_no" _
                & "values(@plan_month,@grey_no,@grey_stok_qty,@grey_stok_pcs,@wip3_qty,@wip3_qty_pcs,@rec_sts,@proc_no)"
            Try
                Dim CMDInputplan1 As New SqlCommand(InputData, KonCIM)
                '
                CMDInputplan1.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                CMDInputplan1.Parameters.Add(New SqlParameter("@grey_no", SqlDbType.VarChar))
                CMDInputplan1.Parameters.Add(New SqlParameter("@grey_stock_qty", SqlDbType.Float))
                CMDInputplan1.Parameters.Add(New SqlParameter("@grey_stock_qty_pcs", SqlDbType.Float))
                CMDInputplan1.Parameters.Add(New SqlParameter("@wip3_qty", SqlDbType.Float))
                CMDInputplan1.Parameters.Add(New SqlParameter("@wip3_qty_pcs", SqlDbType.Float))
                CMDInputplan1.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                CMDInputplan1.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                'KonCIM.Open()
                TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
                CMDInputplan1.Transaction = TR
                '
                CMDInputplan1.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
                CMDInputplan1.Parameters("@grey_no").Value = GreyNoedit
                CMDInputplan1.Parameters("@wip3_qty").Value = lblProdPCS.Text
                CMDInputplan1.Parameters("@wip3_qty_pcs").Value = "0"
                CMDInputplan1.Parameters("@grey_stock_qty").Value = "0"
                CMDInputplan1.Parameters("@wip3_qty_pcs").Value = "0"
                CMDInputplan1.Parameters("@rec_sts").Value = "A"
                CMDInputplan1.Parameters("@proc_no").Value = "1"
                '
                CMDInputplan1.ExecuteNonQuery()
                TR.Commit()
                '
            Catch ex As Exception
                Try
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                Catch rollBackEx As Exception
                    MessageBox.Show(rollBackEx.Message)
                End Try
            End Try
        End If
        KonCIM.Close()
    End Sub
    Private Sub BtnGen5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGen5.Click
        Using KonCIM As New SqlConnection(ConStringCIM)
            For Each row As DataGridViewRow In DGVEX.Rows
                If Not row.IsNewRow Then
                    'DGVEX.Rows.Add()
                    GreyNoedit = row.Cells(0).Value.ToString
                    NilaiPCS = row.Cells(1).Value.ToString
                    '
                    CekProdPlan1()
                    UpdatePlan1()
                    '
                End If
            Next
        End Using
        'MessageBox.Show("Data Berhasil Disimpan", "Informasi")
    End Sub

    Private Sub BtnProses47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses47.Click
        Dim query As String
        Dim Tanggal As Date
        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        KoneksiCIM()
        KonCIM.Open()

        If cmbPlanMonthedit.Text = "" Then
            MessageBox.Show("Plan month kosong")
            cmbPlanMonthedit.Focus()
            GoTo keluar
        End If
        '
        query = "select plan_month from wv_prod_plan_detail2 where plan_month  = '" & cmbPlanMonthedit.Text & "' "
        CMD = New SqlCommand(query, KonCIM)
        DA = New SqlDataAdapter
        DA.SelectCommand = CMD
        '
        DS = New DataSet
        DA.Fill(DS)
        KonCIM.Close()
        Tanggal = Format(DtpTanggal.Value, "yyyy-MM-dd")
        If DS.Tables(0).Rows.Count > 0 Then
            DA = Nothing
            CMD = Nothing
            DS = Nothing
            '
            'If MessageBox.Show("Maaf Data pada Plan Month ini sudah ada di detail2, apakah ingin lanjut Proses....?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                KonCIM.Open()
                CMD = New SqlCommand
                CMD.Connection = KonCIM
                CMD.CommandTimeout = 10000
                TR = KonCIM.BeginTransaction
                CMD.Transaction = TR
                '
                CMD.CommandType = CommandType.Text
                query = "delete from wv_prod_plan_detail2 where plan_month  = '" & cmbPlanMonthedit.Text & "' "
                CMD.CommandText = query
                CMD.ExecuteNonQuery()
                '
                CMD.Connection = KonCIM
                CMD.CommandType = CommandType.Text
                'query = "exec sp_Generate_Plan_Sub4 @plan_month= '" & (cmbPlanMonthedit.Text) & "', @tgl_req = '" & DtpTanggal.Value.ToString("yyyy-MM-dd") & "' "
                query = "exec wppc.sp_Generate_Plan_Sub4 @plan_month= '" & (cmbPlanMonthedit.Text) & "', @tgl_req = '" & (Tanggal) & "'"
                CMD.CommandText = query
                CMD.ExecuteNonQuery()
                TR.Commit()
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            Finally
                DA = Nothing
                CMD = Nothing
                DS = Nothing
                KonCIM.Close()
            End Try
            'Else
            '    GoTo keluar
            'End If
        Else
            Try
                KonCIM.Open()
                CMD = New SqlCommand
                CMD.Connection = KonCIM
                CMD.CommandTimeout = 10000
                TR = KonCIM.BeginTransaction
                CMD.Transaction = TR
                '
                CMD.Connection = KonCIM
                CMD.CommandType = CommandType.Text
                'query = "exec sp_Generate_Plan_Sub4 @plan_month= '" & (cmbPlanMonthedit.Text) & "', @tgl_req = '" & DtpTanggal.Value.ToString("yyyy-MM-dd") & "' "
                query = "exec wppc.sp_Generate_Plan_Sub4 @plan_month= '" & (cmbPlanMonthedit.Text) & "', @tgl_req = '" & (Tanggal) & "'"
                CMD.CommandText = query
                CMD.ExecuteNonQuery()
                TR.Commit()
                '
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            Finally
                DA = Nothing
                CMD = Nothing
                DS = Nothing
                KonCIM.Close()
            End Try
        End If
keluar:
        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
    End Sub

    Private Sub BtnProses51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProses51.Click
        Dim query As String
        '
        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        KoneksiCIM()
        KonCIM.Open()
        '
        If cmbPlanMonthedit.Text = "" Then
            MessageBox.Show("Plan month kosong")
            cmbPlanMonthedit.Focus()
            GoTo keluar
        End If
        '
        query = "select plan_month from wv_prod_plan_detail3 where plan_month  = '" & cmbPlanMonthedit.Text & "' "
        CMD = New SqlCommand(query, KonCIM)
        DA = New SqlDataAdapter
        DA.SelectCommand = CMD
        '
        DS = New DataSet
        DA.Fill(DS)
        KonCIM.Close()
        '
        If DS.Tables(0).Rows.Count > 0 Then
            DA = Nothing
            CMD = Nothing
            DS = Nothing
            '
            'If MessageBox.Show("Maaf Data pada Plan Month ini sudah ada di detail3, apakah ingin lanjut Proses....?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                KonCIM.Open()
                CMD = New SqlCommand
                CMD.Connection = KonCIM
                TR = KonCIM.BeginTransaction
                CMD.Transaction = TR
                '
                CMD.CommandType = CommandType.Text
                query = "delete from wv_prod_plan_detail3 where plan_month  = '" & cmbPlanMonthedit.Text & "' "
                CMD.CommandText = query
                CMD.ExecuteNonQuery()

                CMD.Connection = KonCIM
                CMD.CommandType = CommandType.Text
                query = "exec wppc.sp_AverageMesinPerHari @plan_month= '" & (cmbPlanMonthedit.Text) & "' "
                CMD.CommandText = query
                CMD.ExecuteNonQuery()
                TR.Commit()
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            Finally
                DA = Nothing
                CMD = Nothing
                DS = Nothing
                KonCIM.Close()
            End Try
            'Else
            '    GoTo keluar
            'End If
        Else
        Try
            KonCIM.Open()
            CMD = New SqlCommand
            CMD.Connection = KonCIM
            TR = KonCIM.BeginTransaction
            CMD.Transaction = TR
            '
            CMD.Connection = KonCIM
            CMD.CommandType = CommandType.Text
                query = "exec wppc.sp_AverageMesinPerHari @plan_month= '" & (cmbPlanMonthedit.Text) & "' "
            CMD.CommandText = query
            CMD.ExecuteNonQuery()
            TR.Commit()
                '
        Catch ex As Exception
            TR.Rollback()
            MessageBox.Show(ex.Message)
        Finally
            DA = Nothing
            CMD = Nothing
            DS = Nothing
            KonCIM.Close()
        End Try
        End If
keluar:
        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
    End Sub
End Class