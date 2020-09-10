Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Public Class frmEntryReqYarn
    Dim Tglreq, Bulan1, Bulan2, Bulan3 As Date
    Dim SimpanHeader, UbahHeader As String
    Dim sql As String
    Dim StatusUbah As Boolean
    Dim KodeItem, Namaitem As String
    Dim TR As SqlTransaction

    Sub Buka_DataComboPlan()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '      
        'DGV.ReadOnly = True
        DA = New SqlDataAdapter("Select [plan_month] From sl_grey_request", KonIstem)
        DA.Fill(DS, "sl_grey_request")
        'CMD = New SqlCommand(MItemYarnSAP, KonSAP)
        CMD = New SqlCommand(MPlan, KonIstem)
        DR = CMD.ExecuteReader
        cmbPlanMonth.Items.Clear()
        Do While DR.Read
            cmbPlanMonth.Items.Add(DR.Item(0))
        Loop
        KonIstem.Close()
    End Sub
    Sub Buka_DataComboOITM()
        '
        KoneksiSAP()
        KonSAP.Open()
        '
        DA = New SqlDataAdapter("Select Itemcode,FrgnName from OITM where ItmsGrpCod=109 and frozenFor='N'", KonSAP)
        DA.Fill(DS, "OITM")
        '"Select * from OITM where ItmsGrpCod=109 and frozenFor='N'"
        CMD = New SqlCommand(MItemYarnSAP, KonSAP)
        DR = CMD.ExecuteReader
        cmbOITM.Items.Clear()
        Do While DR.Read
            cmbOITM.Items.Add(DR.Item(0) & "-" & DR.Item(2))
        Loop
        '
        KonSAP.Close()
    End Sub
    Sub Buka_DataComboOCRD()
        '
        KoneksiSAP()
        KonSAP.Open()
        '      
        DA = New SqlDataAdapter("Select * From OCRD", KonSAP)
        DA.Fill(DS, "OCRD")
        '
        CMD = New SqlCommand(MVendorSAP, KonSAP)
        DR = CMD.ExecuteReader
        cmbVendor.Items.Clear()
        Do While DR.Read
            cmbVendor.Items.Add(DR.Item(0) & " " & DR.Item(1))
        Loop
        KonSAP.Close()
    End Sub
    Sub BukadataPurch()
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("select * from wv_purch_yarn_request where plan_month='" & (cmbPlanMonth.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            txtMonth1qty.Text = DR.Item("month1_request_qty")
            txtMonth2qty.Text = DR.Item("month2_request_qty")
            txtMonth3qty.Text = DR.Item("month3_request_qty")
            txtKodeitem.Text = DR.Item("yarn_code")
            txtKodeVdr.Text = DR.Item("vendor_code")
            CariNamaOITM()
            CariNamaVendor()
            cmbOITM.Text = txtKodeitem.Text & "-" & txtNamaitem.Text
            cmbVendor.Text = txtKodeVdr.Text & " " & txtNamaVdr.Text
            StatusUbah = True
        Else
            txtMonth1qty.Text = ""
            txtMonth2qty.Text = ""
            txtMonth3qty.Text = ""
            cmbOITM.Text = ""
            cmbVendor.Text = ""
            StatusUbah = False
        End If
        '
    End Sub
    Sub BukaGreyreq()
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        CmdCaridata = New SqlCommand("Select * from wv_prod_plan_header where plan_month = '" & (cmbPlanMonth.Text) & "'", KonCIM)
        DR = CmdCaridata.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            Bulan1 = DR.Item("month1_period1_to")
            Bulan2 = DR.Item("month2_period1_to")
            Bulan3 = DR.Item("month3_period1_to")
        End If
        '
        txtMonth1.Text = Format(Bulan1, "dd/MM/yyyy")
        txtMonth2.Text = Format(Bulan2, "dd/MM/yyyy")
        txtMonth3.Text = Format(Bulan3, "dd/MM/yyyy")
        KonCIM.Close()
    End Sub
    Sub BukaTgalGreyReq()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        CmdCaridata = New SqlCommand("Select * from sl_grey_request where plan_month = '" & (cmbPlanMonth.Text) & "'", KonIstem)
        DR = CmdCaridata.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            Tglreq = DR.Item("request_date")
        End If
        '
        'txtTanggal.Text = Format(Tglreq, "dd/MM/yyyy")
        KonIstem.Close()
    End Sub
    Sub CariNamaVendor()
        KoneksiSAP()
        KonSAP.Open()
        '
        CMD = New SqlCommand("Select CardCode,CardName from OCRD where CardCode= '" & (txtKodeVdr.Text) & "'", KonSAP)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            txtNamaVdr.Text = DR.Item("CardName")
        End If
    End Sub
    Sub Caridata()
        KoneksiCIM()
        KonCIM.Open()
        '
        CMD = New SqlCommand("Select* from wv_purch_yarn_request where plan_month= '" & (cmbPlanMonth.Text) & "' and yarn_code='" & (cmbOITM.Text) & "' and vendor_code='" & (cmbVendor.Text) & "'", KonCIM)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            'txtNamaVdr.Text = DR.Item("CardName")
            txtMonth1qty.Text = DR.Item("month1_request_qty")
            txtMonth2qty.Text = DR.Item("month2_request_qty")
            txtMonth3qty.Text = DR.Item("month3_request_qty")
        End If
    End Sub
    Sub QuerySAP()
        Dim Tglhitung, HasilTgl As Date
        '
        KoneksiSAP()
        KonSAP.Open()
        '
        Tglhitung = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text) 'frmMenuUtama.TSlblTanggal.Text
        'Hasil Rapat dengan weaving dikurangi 1 hari dari hari berjalan
        HasilTgl = (DateAdd(DateInterval.Day, -1, Tglhitung)) 'Tglhitung
        sql = "select tt0.ItemCode,tt0.ItemName,tt0.ItmsGrpCod,tt0.ItmsGrpNam,tt0.InvntryUoM, tt0.Dept," & vbCrLf & _
               "sum( tt0.InQty  - tt0.OutQty) as Qty" & vbCrLf & _
               "from (select t0.TransType,t0.DocDate, t0.ItemCode,t15.ItemName,t15.ItmsGrpCod, t15.InvntryUoM,t16.ItmsGrpNam, " & vbCrLf & _
                "case when t0.TransType=20 then t2.U_Department" & vbCrLf & _
                "when t0.TransType=21 then t4.U_Department" & vbCrLf & _
                "when t0.TransType=18 then t6.U_Department" & vbCrLf & _
                "when t0.TransType=19 then LEFT(t8.U_GR_No, 3)" & vbCrLf & _
                "when t0.TransType=19 then t8.U_Department" & vbCrLf & _
                "when t0.TransType=60 then t10.U_Department" & vbCrLf & _
                "when t0.TransType=59 then t12.U_Department" & vbCrLf & _
                "when t0.TransType=67 and t0.InQty > 0 then t14.U_Dep_Req" & vbCrLf & _
                "when t0.TransType=67 and t0.OutQty > 0 then t14.U_Department" & vbCrLf & _
                "when t0.TransType=69 then (select top 1 A.U_Department FROM OPDN A INNER JOIN PDN1 B ON A.DocEntry = B.DocEntry" & vbCrLf & _
                "WHERE A.DocEntry = (SELECT TOP 1 CASE WHEN t17.BaseType=69 THEN T17.Reference" & vbCrLf & _
                "ELSE t17.BaseEntry END AS DOCeNTRY)) else case when t0.TransType=162 then t19.OcrCode else '' end" & vbCrLf & _
                "end as Dept," & vbCrLf & _
                "case when t0.TransType=69 then t0.CalcPrice else t0.InQty end as InQty," & vbCrLf & _
                "t0.OutQty,t0.TransValue,0 as AdjAmount from OINM t0" & vbCrLf & _
                "left join PDN1 t1 on t0.TransType=t1.ObjType and t0.CreatedBy=t1.DocEntry and t0.DocLineNum=t1.LineNum" & vbCrLf & _
                 "left join OPDN t2 on t1.DocEntry=t2.DocEntry" & vbCrLf & _
                 "left join RPD1 t3 on t0.TransType=t3.ObjType and t0.CreatedBy=t3.DocEntry and t0.DocLineNum=t3.LineNum" & vbCrLf & _
                 "left join ORPD t4 on t3.DocEntry=t4.DocEntry" & vbCrLf & _
                 "left join PCH1 t5 on t0.TransType=t5.ObjType and t0.CreatedBy=t5.DocEntry and t0.DocLineNum=t5.LineNum" & vbCrLf & _
                 "left join OPCH t6 on t5.DocEntry=t6.DocEntry" & vbCrLf & _
                 "left join RPC1 t7 on t0.TransType=t7.ObjType and t0.CreatedBy=t7.DocEntry and t0.DocLineNum=t7.LineNum" & vbCrLf & _
                 "left join ORPC t8 on t7.DocEntry=t8.DocEntry" & vbCrLf & _
                 "left join IGE1 t9 on t0.TransType=t9.ObjType and t0.CreatedBy=t9.DocEntry and t0.DocLineNum=t9.LineNum" & vbCrLf & _
                 "left join OIGE t10 on t9.DocEntry=t10.DocEntry" & vbCrLf & _
                 "left join IGN1 t11 on t0.TransType=t11.ObjType and t0.CreatedBy=t11.DocEntry and t0.DocLineNum=t11.LineNum" & vbCrLf & _
                 "left join OIGN t12 on t11.DocEntry=t12.DocEntry" & vbCrLf & _
                 "left join WTR1 t13 on t0.TransType=t13.ObjType and t0.CreatedBy=t13.DocEntry and t0.DocLineNum=t13.LineNum" & vbCrLf & _
                 "left join IPF1 t17 on t0.TransType=69 and t0.CreatedBy=t17.DocEntry and t0.DocLineNum=t17.LineNum" & vbCrLf & _
                 "left join OIPF t18 on t17.DocEntry=t18.DocEntry" & vbCrLf & _
                 "left join MRV1 t19 on t0.TransType=162 and t0.CreatedBy=t19.DocEntry and t0.DocLineNum=t19.LineNum" & vbCrLf & _
                 "left join OMRV t20 on t19.DocEntry=t20.DocEntry" & vbCrLf & _
                 "left join OWTR t14 on t13.DocEntry=t14.DocEntry" & vbCrLf & _
                 "left join OITM t15 on t0.ItemCode=t15.ItemCode" & vbCrLf & _
                 "left join OITB t16 on t15.ItmsGrpCod=t16.ItmsGrpCod" & vbCrLf & _
                 "where t0.DocDate <= '" & (HasilTgl) & "' and t0.ItemCode = '" & (txtKodeitem.Text) & "'" & vbCrLf & _
                  ") tt0 where tt0.Dept ='400'" & vbCrLf & _
                  "group by tt0.ItemCode,tt0.ItemName,tt0.ItmsGrpCod,tt0.ItmsGrpNam,tt0.InvntryUoM, tt0.Dept"
        CMD = New SqlCommand(sql, KonSAP)
        '
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            'txtNamaitem.Text = DR.Item("FrgnName")
            txtYarnStok.Text = DR.Item("Qty")
        End If
        '
    End Sub
    Sub CariNamaOITM()
        KoneksiSAP()
        KonSAP.Open()
        '
        CmdCaridata = New SqlCommand("Select Itemcode,Itemname,FrgnName from OITM where Itemcode = '" & (txtKodeitem.Text) & "'", KonSAP)
        '
        DR = CmdCaridata.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            txtNamaitem.Text = DR.Item("FrgnName")
        End If
    End Sub
    Private Sub frmEntryReqYarn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTanggal.Text = Menu_Utama.TSlblTanggal.Text
        Buka_DataComboPlan()
        Buka_DataComboOITM()
        Buka_DataComboOCRD()
    End Sub
    Private Sub cmbPlanMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlanMonth.SelectedIndexChanged
        BukaGreyreq()
        BukaTgalGreyReq()
        BukadataPurch()
    End Sub
    Private Sub cmbOITM_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOITM.SelectedIndexChanged
        Dim S, NM As String
        '
        If StatusUbah = False Then
            S = Split(cmbOITM.Text, "-")(0)
            NM = Split(cmbOITM.Text, "-")(1)
            txtNamaitem.Text = NM
            txtKodeitem.Text = S
            CariNamaOITM()
            'txtYarnStok.Text = ""
            BtnShow_Click(sender, New System.EventArgs)
        Else
            S = Split(cmbOITM.Text, "-")(0)
            NM = Split(cmbOITM.Text, "-")(1)
            txtNamaitem.Text = NM
            txtKodeitem.Text = S
            CariNamaOITM()
            QuerySAP()
            'BtnShow_Click(sender, New System.EventArgs)
        End If
        'CariNamaItem()
        'CariNamaOITM()
    End Sub
    Private Sub cmbVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVendor.SelectedIndexChanged
        Dim S As String
        '
        If StatusUbah = False Then
            S = Split(cmbVendor.Text, " ")(0)
            txtKodeVdr.Text = S
            CariNamaVendor()
            Caridata()
        Else
            S = Split(cmbVendor.Text, " ")(0)
            txtKodeVdr.Text = S
            CariNamaVendor()
            'Caridata()
            'BtnShow_Click(sender, New System.EventArgs)
            'QuerySAP()
        End If
        '
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        'KoneksiCIM()
        'KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            If MessageBox.Show("Yakin akan di Simpan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                SimpanHeader = "Insert into wv_purch_yarn_request (plan_month,yarn_code,vendor_code,month1_est_deliv_date,month1_request_qty,month2_est_deliv_date,month2_request_qty,month3_est_deliv_date,month3_request_qty,user_id,rec_sts,proc_no,upd_date,upd_time,client_ip)" _
                & "values(@plan_month,@yarn_code,@vendor_code,@month1_est_deliv_date,@month1_request_qty,@month2_est_deliv_date,@month2_request_qty,@month3_est_deliv_date,@month3_request_qty,@user_id,@rec_sts,@proc_no,@upd_date,@upd_time,@client_ip)"
                Dim CMDHEADER As New SqlCommand(SimpanHeader, KonCIM)
                '
                CMDHEADER.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@yarn_code", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@vendor_code", SqlDbType.VarChar))
                '
                CMDHEADER.Parameters.Add(New SqlParameter("@month1_est_deliv_date", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month1_request_qty", SqlDbType.Float))
                CMDHEADER.Parameters.Add(New SqlParameter("@month2_est_deliv_date", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month2_request_qty", SqlDbType.Float))
                CMDHEADER.Parameters.Add(New SqlParameter("@month3_est_deliv_date", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month3_request_qty", SqlDbType.Float))
                '
                CMDHEADER.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                CMDHEADER.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                CMDHEADER.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
                ''
                KonCIM.Open()
                TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
                CMDHEADER.Transaction = TR
                '
                Try
                    '
                    CMDHEADER.Parameters("@plan_month").Value = cmbPlanMonth.Text
                    CMDHEADER.Parameters("@vendor_code").Value = txtKodeVdr.Text 'cmbVendor.Text
                    CMDHEADER.Parameters("@yarn_code").Value = txtKodeitem.Text 'cmbOITM.Text
                    '
                    CMDHEADER.Parameters("@month1_est_deliv_date").Value = Bulan1
                    CMDHEADER.Parameters("@month1_request_qty").Value = txtMonth1qty.Text
                    CMDHEADER.Parameters("@month2_est_deliv_date").Value = Bulan2
                    CMDHEADER.Parameters("@month2_request_qty").Value = txtMonth2qty.Text
                    CMDHEADER.Parameters("@month3_est_deliv_date").Value = Bulan3
                    CMDHEADER.Parameters("@month3_request_qty").Value = txtMonth3qty.Text
                    '
                    CMDHEADER.Parameters("@rec_sts").Value = "A"
                    CMDHEADER.Parameters("@proc_no").Value = "1"
                    CMDHEADER.Parameters("@upd_date").Value = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                    ' Format(Date.Now, "yyyy/MM/dd")
                    CMDHEADER.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                    CMDHEADER.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                    CMDHEADER.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                    '
                    CMDHEADER.ExecuteNonQuery()
                    TR.Commit()
                    MessageBox.Show("Data Berhasil Disimpan", "Informasi")
                Catch ex As Exception
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                End Try
                '
            End If
        End Using
        Bersihtext()
        cmbPlanMonth.Focus()
        KonCIM.Close()
    End Sub
    Private Sub BtnUbah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbah.Click
        BtnSimpan.Visible = False
        BtnSimpanedit.Visible = True
        'cmbPlanMonth.Focus()
    End Sub
    Sub Bersihtext()
        cmbPlanMonth.Text = ""
        cmbOITM.Text = ""
        cmbVendor.Text = ""
        txtMonth1.Text = ""
        txtMonth1qty.Text = ""
        txtMonth2.Text = ""
        txtMonth2qty.Text = ""
        txtMonth3.Text = ""
        txtMonth3qty.Text = ""
        txtNamaitem.Text = ""
        txtNamaVdr.Text = ""
        txtYarnStok.Text = ""
    End Sub
    Private Sub BtnSimpanedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpanedit.Click
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            If MessageBox.Show("Yakin akan di Ubah...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                UbahHeader = "Update wv_purch_yarn_request set plan_month=@plan_month,yarn_code=@yarn_code,vendor_code=@vendor_code,month1_est_deliv_date=@month1_est_deliv_date,month1_request_qty=@month1_request_qty,month2_est_deliv_date=@month2_est_deliv_date,month2_request_qty=@month2_request_qty,month3_est_deliv_date=@month3_est_deliv_date,month3_request_qty=@month3_request_qty,rec_sts=@rec_sts,proc_no=@proc_no where plan_month=@plan_month"
                '
                Dim CMDHEADER As New SqlCommand(UbahHeader, KonCIM)
                '
                CMDHEADER.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@yarn_code", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@vendor_code", SqlDbType.VarChar))
                '
                CMDHEADER.Parameters.Add(New SqlParameter("@month1_est_deliv_date", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month1_request_qty", SqlDbType.Float))
                CMDHEADER.Parameters.Add(New SqlParameter("@month2_est_deliv_date", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month2_request_qty", SqlDbType.Float))
                CMDHEADER.Parameters.Add(New SqlParameter("@month3_est_deliv_date", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@month3_request_qty", SqlDbType.Float))
                '
                CMDHEADER.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                CMDHEADER.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                ' ''
                KonCIM.Open()
                TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
                CMDHEADER.Transaction = TR
                ''
                Try
                    CMDHEADER.Parameters("@plan_month").Value = cmbPlanMonth.Text
                    CMDHEADER.Parameters("@vendor_code").Value = txtKodeVdr.Text 'cmbVendor.Text
                    CMDHEADER.Parameters("@yarn_code").Value = txtKodeitem.Text 'cmbOITM.Text
                    CMDHEADER.Parameters("@month1_est_deliv_date").Value = Bulan1
                    CMDHEADER.Parameters("@month1_request_qty").Value = txtMonth1qty.Text
                    CMDHEADER.Parameters("@month2_est_deliv_date").Value = Bulan2
                    CMDHEADER.Parameters("@month2_request_qty").Value = txtMonth2qty.Text
                    CMDHEADER.Parameters("@month3_est_deliv_date").Value = Bulan3
                    CMDHEADER.Parameters("@month3_request_qty").Value = txtMonth3qty.Text
                    CMDHEADER.Parameters("@rec_sts").Value = "T"
                    CMDHEADER.Parameters("@proc_no").Value = "2"
                    '
                    CMDHEADER.ExecuteNonQuery()
                    TR.Commit()
                    MessageBox.Show("Data Berhasil Disimpan", "Informasi")
                    '
                Catch ex As Exception
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                End Try
                '
            End If
        End Using
        '
        BtnSimpan.Visible = True
        BtnSimpanedit.Visible = False
        'Bersihtext()
        'cmbPlanMonth.Focus()
        KonCIM.Close()
    End Sub

    Private Sub BtnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHapus.Click
        Dim Hapusdataheader As String
        '
        'Using Kon As New SqlConnection(ConString)
        KoneksiCIM()
        KonCIM.Open()
        '
        Using KonCIM As New SqlConnection(ConStringCIM)
            If cmbPlanMonth.Text = "" Or cmbOITM.Text = "" Or cmbVendor.Text = "" Then
                MsgBox("Maaf Data Belum Dipilih", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '
            If MessageBox.Show("Yakin akan di Hapus...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                'Hapusdatadetil = "delete sl_deliv_yarn_grey_detail where plan_month ='" & (TxtHasilModif.Text) & "' and vendor_code='" & (txtKodeVendoredit.Text) & "'"
                Hapusdataheader = "delete wv_purch_yarn_request where plan_month ='" & (cmbPlanMonth.Text) & "' and vendor_code='" & (cmbVendor.Text) & "' and yarn_code='" & (cmbOITM.Text) & "'"
                Dim CMDHapusheader As New SqlCommand(Hapusdataheader, KonCIM)
                '
                KonCIM.Open()
                TR = KonCIM.BeginTransaction(IsolationLevel.ReadCommitted)
                '
                CMDHapusheader.Transaction = TR
                Try
                    '
                    CMDHapusheader.ExecuteNonQuery()
                    'CMDHapusdetil.Dispose()
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
        Bersihtext()
        cmbPlanMonth.Focus()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Bersihtext()
        Me.Close()
    End Sub

    Private Sub BtnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        QuerySAP()
    End Sub
End Class