Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Public Class frmSales_Delivery_Entry
    Dim Caribulan As String
    Dim CariTahun, NilaiBulan As String
    Dim CMDSimpan As New SqlCommand
    Dim CMDHapus As New SqlCommand
    Dim TambahDetil As Boolean
    Dim UbahDetil As Boolean
    Dim CariTgl As Date
    '
    Dim SimpanDetil, Ubahdata, CariTanggal As String
    Dim Editdetil As Boolean
    Dim UbahDataDetil, UbahDataHeader As String
    Dim SimpanHeader, Simpandata As String
    Dim TambaheditDetil, UbaheditDetil, CekKodeBrg, Hapusbaris As Boolean
    Dim TR As SqlTransaction
    Dim HapusTanggal As Date
    Dim Tgldv1 As Date
    '
    Dim AngkaBulan As Integer
    Dim CMD As New SqlCommand
    Dim CMDEDIT As New SqlCommand
    Dim CMDHEADER As New SqlCommand
    Dim CMDDETIL As New SqlCommand
    Dim StatusDeliv_unit As String
    Dim SatuanDeliv_unit, I As Integer
    Dim RMD2, Mt1dv, Mt1ip, Mt2dv, Mt2ip, Mt3dv, Mt3ip As Integer
    Dim KodeVendor, NamaVendor, Jenis As String
    Dim KodeItem, Namaitem, Planqty, Planunit, Planunitedit As String
    Dim Kodeedit, Namaitemedit, qtyedit, unitedit, Plandateedit As String
    Dim plandeliv, plandelivedit, TgalDeliv, TgalDelivedit As Date
    Dim KodeItem1, plandelivedit1, Pdvqty1, Jenis1, KodeVendor1, Plunitdt1 As String
    '
    Private Sub BtnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKeluar.Click
        cmbPlanMonth.Text = ""
        Close()
    End Sub

    Private Sub frmSales_Delivery_Entry_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        '
        Buka_DataComboPlan()
        Buka_DataComboPlanedit()
    End Sub
    Private Sub frmSales_Delivery_Entry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '
        For Y = DateTime.Now.Year - 5 To DateTime.Now.Year + 10
            cmbTahun.Items.Add(Y)
            cmbTahun.Text = ""
        Next
        '
        'Buka_DataComboPlan()
        Buka_DataComboSAP()
        '
    End Sub
    Sub Buka_DataComboPlan()
        '
        'Kon = New SqlConnection(ConString)
        'Koncim.Open()
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
    Sub Buka_DataComboPlanedit()
        '
        'Kon = New SqlConnection(ConString)
        'Koncim.Open()
        ' 
        KoneksiISTEM()
        KonIstem.Open()
        'DGV.ReadOnly = True
        DA = New SqlDataAdapter("Select [plan_month] From sl_grey_request", KonIstem)
        DA.Fill(DS, "sl_grey_request")
        '
        CMDEDIT = New SqlCommand(MPlan, KonIstem)
        DR = CMDEDIT.ExecuteReader
        cmbPlanMonthedit.Items.Clear()
        Do While DR.Read
            cmbPlanMonthedit.Items.Add(DR.Item(0))
        Loop
        KonIstem.Close()
    End Sub
    Sub Buka_DataComboSAP()
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
    Sub CariNamaOITM()
        KoneksiSAP()
        KonSAP.Open()
        '
        CMD = New SqlCommand("Select ItemCode,FrgnName From OITM where itemCode= '" & txtKdNameedit.Text & "'", KonSAP)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            txtItmNameedit.Text = DR.Item("FrgnName")
        End If
        '
        KonSAP.Close()
    End Sub
    Sub CariNamaVendor()
        KoneksiSAP()
        KonSAP.Open()
        '
        CMD = New SqlCommand("Select CardCode,CardName from OCRD where CardCode= '" & (KodeVendor) & "'", KonSAP)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            NamaVendor = DR.Item("CardName")
        End If
    End Sub
    Sub CekNamaVendorEdit()
        KoneksiSAP()
        KonSAP.Open()
        '
        CMD = New SqlCommand("Select CardCode,CardName from OCRD where CardCode= '" & (KodeVendor) & "'", KonSAP)
        DR = CMD.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            NamaVendor = DR.Item("CardName")
        End If
    End Sub
    Sub CariNamaItem()
        KoneksiSAP()
        KonSAP.Open()
        '
        CmdCaridata = New SqlCommand("Select Itemcode,Itemname,FrgnName from OITM where Itemcode = '" & (KodeItem) & "'", KonSAP)
        '
        DR = CmdCaridata.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            Namaitem = DR.Item("FrgnName")
        End If
    End Sub
    Sub CariNamaItemEDIT()
        KoneksiSAP()
        KonSAP.Open()
        ''DGVDetiledit.Item(0, I).Value)
        'If Editdetil = False Then
        '    CmdCaridata = New SqlCommand("Select Itemcode,Itemname,FrgnName from OITM where Itemcode = '" & (cmbGreyno.Text) & "'", KonSAP)
        'Else
        'txtKodeVendoredit
        CmdCaridata = New SqlCommand("Select Itemcode,Itemname,FrgnName from OITM where Itemcode = '" & (KodeItem) & "'", KonSAP)
        'End If
        DR = CmdCaridata.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            'If Editdetil = False Then
            '    txtItemName.Text = DR.Item("FrgnName")
            'Else
            Namaitem = DR.Item("FrgnName")
            'End If
        End If
    End Sub
    Sub CariNamaItemAll()
        KoneksiSAP()
        KonSAP.Open()
        ''DGVDetiledit.Item(0, I).Value)
        'If Editdetil = False Then
        '    CmdCaridata = New SqlCommand("Select Itemcode,Itemname,FrgnName from OITM where Itemcode = '" & (cmbGreyno.Text) & "'", KonSAP)
        'Else
        'txtKodeVendoredit
        CmdCaridata = New SqlCommand("Select Itemcode,Itemname,FrgnName from OITM where Itemcode = '" & (KodeItem1) & "'", KonSAP)
        'End If
        DR = CmdCaridata.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            'If Editdetil = False Then
            '    txtItemName.Text = DR.Item("FrgnName")
            'Else
            Namaitem = DR.Item("FrgnName")
            'End If
        End If
    End Sub
    Sub BukaUnitDlv()
        If OptYarn.Checked = True Then
            cmbDlvUnit.Items.Add("KG")
            cmbDlvUnit.Items.Add("LBS")
        End If
        If OptGrey.Checked = True Then
            cmbDlvUnit.Items.Add("MTR")
            cmbDlvUnit.Items.Add("YDS")
        End If
    End Sub
    Sub CariItemYarn()
        KoneksiSAP()
        KonSAP.Open()
        '
        If TambahDetil = True Then
            DA = New SqlDataAdapter("Select Itemcode,FrgnName from OITM where ItmsGrpCod=109 and frozenFor='N'", KonSAP)
            DA.Fill(DS, "OITM")
            '
            CMD = New SqlCommand(MItemYarnSAP, KonSAP)
            DR = CMD.ExecuteReader
            Do While DR.Read
                cmbGreynoedit.Items.Add(DR.Item(0) & "-" & DR.Item(2))
            Loop
        Else
            cmbGreyno.Text = ""
            cmbGreyno.Items.Clear()
            If OptYarn.Checked = True Then
                'DA = New SqlDataAdapter("Select Itemcode,Itemname From OITM", KonSAP)
                DA = New SqlDataAdapter("Select Itemcode,FrgnName from OITM where ItmsGrpCod=109 and frozenFor='N'", KonSAP)
                DA.Fill(DS, "OITM")
                '
                CMD = New SqlCommand(MItemYarnSAP, KonSAP)
                DR = CMD.ExecuteReader
                Do While DR.Read
                    cmbGreyno.Items.Add(DR.Item(0) & "-" & DR.Item(2))
                Loop
            End If
        End If
        KonSAP.Close()
    End Sub
    Sub CariItemYarnedit()
        KoneksiSAP()
        KonSAP.Open()
        '
        'If TambahDetil = True Then
        DA = New SqlDataAdapter("Select Itemcode,FrgnName from OITM where ItmsGrpCod=109 and frozenFor='N'", KonSAP)
        DA.Fill(DS, "OITM")
        '
        CMD = New SqlCommand(MItemYarnSAP, KonSAP)
        DR = CMD.ExecuteReader
        Do While DR.Read
            cmbGreynoedit.Items.Add(DR.Item(0) & "-" & DR.Item(2))
        Loop
        'Else
        'cmbGreyno.Text = ""
        'cmbGreyno.Items.Clear()
        'If OptYarn.Checked = True Then
        '    'DA = New SqlDataAdapter("Select Itemcode,Itemname From OITM", KonSAP)
        '    DA = New SqlDataAdapter("Select Itemcode,FrgnName from OITM where ItmsGrpCod=109 and frozenFor='N'", KonSAP)
        '    DA.Fill(DS, "OITM")
        '    '
        '    CMD = New SqlCommand(MItemYarnSAP, KonSAP)
        '    DR = CMD.ExecuteReader
        '    Do While DR.Read
        '        cmbGreyno.Items.Add(DR.Item(0) & "-" & DR.Item(2))
        '    Loop
        'End If
        ' End If
        KonSAP.Close()
    End Sub
    Sub CariItemGrey()
        KoneksiSAP()
        KonSAP.Open()
        '
        cmbGreyno.Text = ""
        cmbGreyno.Items.Clear()
        If OptGrey.Checked = True Then
            'DA = New SqlDataAdapter("Select Itemcode,Itemname From OITM", KonSAP)
            DA = New SqlDataAdapter("Select Itemcode,Itemname,FrgnName from OITM where ItmsGrpCod=111 and frozenFor='N'", KonSAP)
            DA.Fill(DS, "OITM")
            '
            CMD = New SqlCommand(MItemGreySAP, KonSAP)
            DR = CMD.ExecuteReader
            Do While DR.Read
                'cmbGreyno.Items.Add(DR.Item(0))
                cmbGreynoedit.Items.Add(DR.Item(0) & "-" & DR.Item(2))
            Loop
        End If
        '      
        KonSAP.Close()
    End Sub
    Sub CariItemGreyedit()
        KoneksiSAP()
        KonSAP.Open()
        '
        'cmbGreyno.Text = ""
        'cmbGreyno.Items.Clear()
        'If OptGrey.Checked = True Then
        If txtJenisedit.Text = "Grey" Then
            DA = New SqlDataAdapter("Select Itemcode,Itemname,FrgnName from OITM where ItmsGrpCod=111 and frozenFor='N'", KonSAP)
            DA.Fill(DS, "OITM")
            '
            CMD = New SqlCommand(MItemGreySAP, KonSAP)
            DR = CMD.ExecuteReader
            Do While DR.Read
                'cmbGreyno.Items.Add(DR.Item(0))
                cmbGreynoedit.Items.Add(DR.Item(0) & "-" & DR.Item(2))
            Loop
        End If
        '      
        KonSAP.Close()
    End Sub
    Sub DataDetil()
        '
        TxtHasilModif.Text = cmbPlanMonthedit.Text
        KoneksiISTEM()
        KonIstem.Open()
        DA = New SqlDataAdapter("Select yarn_grey_code as Item_Code,plan_deliv_date as Est_Delivery_Date,plan_deliv_qty as Delivery_Qty,plan_deliv_qty_unit as Delivery_Unit from sl_deliv_yarn_grey_detail where plan_month = '" & (TxtHasilModif.Text) & "' and vendor_code = '" & (txtKodeVendoredit.Text) & "'", KonIstem)
        '
        DS = New DataSet
        'plandeliv,planqty,planunit
        Try 'row.Cells(0).Value.ToString
            DA.Fill(DS)
            '
            DGV_edit.DataSource = DS.Tables(0)
            KonIstem.Close()
            DGV_edit.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '
            DGV_edit.Columns(0).Width = 200
            DGV_edit.Columns(1).Width = 125
            DGV_edit.Columns(2).Width = 90
            DGV_edit.Columns(3).Width = 90
            '
            DGV_edit.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub DataDetil2()
        '
        TxtHasilModif.Text = cmbPlanMonthedit.Text
        KoneksiISTEM()
        KonIstem.Open()
        DA = New SqlDataAdapter("Select yarn_grey_code as Item_Code,plan_deliv_date as Est_Delivery_Date,plan_deliv_qty as Delivery_Qty,plan_deliv_qty_unit as Delivery_Unit,vendor_code as Vendor_code from sl_deliv_yarn_grey_detail where plan_month = '" & (TxtHasilModif.Text) & "'", KonIstem)
        '
        DS = New DataSet
        'plandeliv,planqty,planunit
        Try 'row.Cells(0).Value.ToString
            DA.Fill(DS)
            '
            DGVDTL2.DataSource = DS.Tables(0)
            KonIstem.Close()
            DGVDTL2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '
            DGVDTL2.Columns(0).Width = 200
            DGVDTL2.Columns(1).Width = 125
            DGVDTL2.Columns(2).Width = 90
            DGVDTL2.Columns(3).Width = 90
            DGVDTL2.Columns(4).Width = 90
            '
            DGVDTL2.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub DataHeader()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        DA = New SqlDataAdapter("Select vendor_code,Case when yarn_grey_flag='0' Then 'Yarn' else 'Grey' end As Jenis from sl_deliv_yarn_grey_Header where plan_month= '" & (TxtHasilModif.Text) & "'", KonIstem)
        DS = New DataSet
        '
        Try
            DA.Fill(DS)
            '
            DGVHeader.DataSource = DS.Tables(0)
            lblUpdateV.Text = DGVHeader.Rows.Count

            KonIstem.Close()
            DGVHeader.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '
            DGVHeader.Columns(0).Width = 80
            DGVHeader.Columns(1).Width = 80
            'DGVHeader.Columns(2).Width = 80
            '
            DGVHeader.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub cmbGreyno_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGreyno.SelectedIndexChanged
        Dim S, NM As String
        CekSetPlantHeader()
        '
        pnlEntryHeader.Enabled = False
        CariNamaItem()
        S = Split(cmbGreyno.Text, "-")(0)
        NM = Split(cmbGreyno.Text, "-")(1)
        txtItemName.Text = NM
        txtKodeName.Text = S
    End Sub
    Private Sub txtDlvperiod1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub
    Private Sub BtnAddKlm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddKlm.Click
        '
        If cmbGreyno.Text = "" Or txtItemName.Text = "" Or txtDlvqty.Text = "" Or cmbDlvUnit.Text = "" Then
            MsgBox("Maaf data Tidak boleh dalam keadaan kosong", vbInformation, "Informasi")
            cmbGreyno.Focus()
            Exit Sub
        End If
        Dim baris As Integer = DGV.RowCount - 1
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        KoneksiISTEM()
        KonIstem.Open()
        '      
        'kunci identifikasi klo ada yang ganda di datagrid dengan kode item dan tanggal
        DGV.Rows.Add(txtKodeName.Text & Format(DtpDelivery.Value, "MM/dd/yyyy"))
        '
        For barisatas As Integer = 0 To DGV.RowCount - 1
            For barisbawah As Integer = barisatas + 1 To DGV.RowCount - 1
                If DGV.Rows(barisbawah).Cells(0).Value & DGV.Rows(barisbawah).Cells(2).Value = DGV.Rows(barisatas).Cells(0).Value & DGV.Rows(barisatas).Cells(2).Value Then
                    MsgBox("Barang sudah Ada")
                    DGV.Rows.RemoveAt(barisbawah)
                    Bersihtext()
                    cmbGreyno.Focus()
                    'DGV.Rows.RemoveAt(DGV.CurrentCell.RowIndex)
                    Exit Sub
                End If
            Next
        Next
        '
        DGV(0, DGV.RowCount - 2).Value = txtKodeName.Text
        DGV(1, DGV.RowCount - 2).Value = txtItemName.Text 'txtItmNameedit.Text
        DGV(2, DGV.RowCount - 2).Value = Format(DtpDelivery.Value, "yyyy/MM/dd")
        DGV(3, DGV.RowCount - 2).Value = txtDlvqty.Text
        DGV(4, DGV.RowCount - 2).Value = cmbDlvUnit.Text
        ''
        'CMD = New SqlCommand("Select * from sl_deliv_yarn_grey_detail where plan_month = '" & (cmbPlanMonth.Text) & "' and vendor_code='" & (DGV.Rows(baris).Cells(0).Value) & "'", KonIstem)
        'DR = CMD.ExecuteReader
        'DR.Read()
        'If DR.HasRows Then
        '    MsgBox("Maaf Data barang Sudah ada ", vbInformation, "Informasi")
        '    cmbGreyno.Focus()
        '    Exit Sub
        'End If
        ''
        cmbGreyno.Focus()
        Bersihtext()
        KonIstem.Close()
    End Sub
    Sub Bersihtext()
        cmbGreyno.Text = ""
        txtItemName.Text = ""
        txtDlvqty.Text = ""
        cmbDlvUnit.Text = ""
    End Sub
    Sub BersihisiNew()
        cmbGreyno.Text = ""
        DtpDelivery.Value = ""
        txtDlvqty.Text = ""
    End Sub
    Sub Bersihtextedit()
        cmbGreynoedit.Text = ""
        txtItmNameedit.Text = ""
        txtDlvqtyEdit.Text = ""
        cmbDlvUnitedit.Text = ""
    End Sub
    Sub Bukakunci()
        BtnAdd.Enabled = True
        BtnSave.Enabled = False
        BtnEdit.Enabled = True
        BtnCancel.Enabled = False
        BtnDelete.Enabled = True
        BtnKeluar.Enabled = True
        pnlEntryHeader.Enabled = False
    End Sub
    Sub Kunci()
        BtnAdd.Enabled = False
        BtnSave.Enabled = True
        BtnEdit.Enabled = False
        BtnCancel.Enabled = True
        BtnDelete.Enabled = False
        BtnKeluar.Enabled = False
        pnlEntryHeader.Enabled = True
    End Sub
    Sub KunciDetil()
        BtnTmbhDtl.Enabled = False
        BtnSimpan_dtl.Enabled = True
        BtnUbah_dtl.Enabled = False
        BtnBatal_dtl.Enabled = True
        'BtnDeleteDetil.Enabled = False
        BtnUpdateV.Enabled = False
        'BtnKeluar.Enabled = False
    End Sub
    Sub BukakunciDetil()
        BtnTmbhDtl.Enabled = True
        BtnSimpan_dtl.Enabled = False
        BtnUbah_dtl.Enabled = True
        BtnBatal_dtl.Enabled = False
        'BtnDeleteDetil.Enabled = True
        BtnUpdateV.Enabled = True
        '
        'BtnDelete.Enabled = True
        'BtnKeluar.Enabled = True
    End Sub

    Private Sub BtnDelKlm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnDelKlm.Click
        Dim i As Integer
        ' If OptUbah.Checked = False Then
        i = DGV.RowCount
        If DGV.RowCount <= 1 Then
            Exit Sub
        Else
            DGV.Rows.RemoveAt(DGV.CurrentCell.RowIndex)
        End If
        ' End If
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        '
        txtKdNameedit.Visible = True
        txtItmNameedit.Visible = True
        cmbGreynoedit.Visible = False
        '
        Bukakunci()
        KunciDetil()
        DGV.Rows.Clear()
        BtnAdd.Focus()
        '
        BtnSave.Visible = True
        BtnSave.Enabled = False
        BtnSaveedit.Visible = False
        BtnDeleteDetil.Enabled = True
        '
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim Tanggaldlv, TglUpdate As Date
        'Using KonCIM As New SqlConnection(ConString)
        Using KonIstem As New SqlConnection(ConStringISTEM)
            If MessageBox.Show("Yakin akan di Simpan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                ''
                SimpanHeader = "Insert into sl_deliv_yarn_grey_header(plan_month,vendor_code,yarn_grey_flag,upd_date,user_id,rec_sts,proc_no,upd_time,client_ip)" _
                & "values(@plan_month,@vendor_code,@yarn_grey_flag,@upd_date,@user_id,@rec_sts,@proc_no,@upd_time,@client_ip)"
                Dim CMDHEADER As New SqlCommand(SimpanHeader, KonIstem)
                ' ''
                SimpanDetil = "Insert into sl_deliv_yarn_grey_detail(plan_month,vendor_code,yarn_grey_code,plan_deliv_date,plan_deliv_qty,plan_deliv_qty_unit,rec_sts,proc_no)" _
                & "values(@plan_month,@vendor_code,@yarn_grey_code,@plan_deliv_date,@plan_deliv_qty,@plan_deliv_qty_unit,@rec_sts,@proc_no)"
                Dim CMDDetil As New SqlCommand(SimpanDetil, KonIstem)
                '@rec_sts,@proc_no
                CMDHEADER.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                'CMDHEADER.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
                CMDHEADER.Parameters.Add(New SqlParameter("@vendor_code", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@yarn_grey_flag", SqlDbType.TinyInt))
                CMDHEADER.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                CMDHEADER.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                CMDHEADER.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
                CMDHEADER.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
                CMDHEADER.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
                ''
                CMDDetil.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                'CMDDetil.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
                CMDDetil.Parameters.Add(New SqlParameter("@vendor_code", SqlDbType.VarChar))
                CMDDetil.Parameters.Add(New SqlParameter("@yarn_grey_code", SqlDbType.VarChar))
                CMDDetil.Parameters.Add(New SqlParameter("@plan_deliv_date", SqlDbType.Date))
                CMDDetil.Parameters.Add(New SqlParameter("@plan_deliv_qty", SqlDbType.Int))
                CMDDetil.Parameters.Add(New SqlParameter("@plan_deliv_qty_unit", SqlDbType.TinyInt))
                CMDDetil.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                CMDDetil.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                '
                KonIstem.Open()
                TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
                CMDHEADER.Transaction = TR
                ''
                CMDDetil.Transaction = TR
                '
                Try
                    '
                    TglUpdate = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                    CMDHEADER.Parameters("@plan_month").Value = cmbPlanMonth.Text
                    'CMDHEADER.Parameters("@request_version").Value = "1"
                    CMDHEADER.Parameters("@vendor_code").Value = txtKdVendor.Text
                    'request dari ibu felis pilih yarn =0 klo grey=1
                    Select Case True
                        Case OptYarn.Checked
                            CMDHEADER.Parameters("@yarn_grey_flag").Value = "0"
                        Case OptGrey.Checked
                            CMDHEADER.Parameters("@yarn_grey_flag").Value = "1"
                    End Select
                    '
                    CMDHEADER.Parameters("@rec_sts").Value = "A"
                    CMDHEADER.Parameters("@proc_no").Value = "1"
                    CMDHEADER.Parameters("@upd_date").Value = TglUpdate 'Format(TglUpdate, "yyyy/MM/dd") 'Convert.ToDateTime(Menu_Utama.TSlblTanggal.Text)
                    ' Format(Date.Now, "yyyy/MM/dd")
                    CMDHEADER.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                    CMDHEADER.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                    CMDHEADER.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                    '
                    CMDHEADER.ExecuteNonQuery()
                    '
                    For Each row As DataGridViewRow In DGV.Rows
                        If Not row.IsNewRow Then
                            Tanggaldlv = Convert.ToDateTime(row.Cells(2).Value.ToString)
                            CMDDetil.Parameters("@plan_month").Value = cmbPlanMonth.Text
                            'CMDDetil.Parameters("@request_version").Value = "1"
                            CMDDetil.Parameters("@vendor_code").Value = txtKdVendor.Text
                            CMDDetil.Parameters("@yarn_grey_code").Value = row.Cells(0).Value.ToString
                            CMDDetil.Parameters("@plan_deliv_date").Value = Tanggaldlv 'Convert.ToDateTime(row.Cells(2).Value.ToString)
                            CMDDetil.Parameters("@plan_deliv_qty").Value = (row.Cells(3).Value.ToString)
                            ' Status plan_deliv_qty_unit
                            StatusDeliv_unit = row.Cells(4).Value.ToString
                            '
                            Select Case StatusDeliv_unit
                                Case "KG"
                                    SatuanDeliv_unit = 0
                                Case "LBS"
                                    SatuanDeliv_unit = 1
                                Case "MTR"
                                    SatuanDeliv_unit = 2
                                Case "YDS"
                                    SatuanDeliv_unit = 3
                            End Select
                            '
                            CMDDetil.Parameters("@plan_deliv_qty_unit").Value = SatuanDeliv_unit 'row.Cells(4).Value.ToString
                            CMDDetil.Parameters("@rec_sts").Value = "A"
                            CMDDetil.Parameters("@proc_no").Value = "1"
                            '
                            CMDDetil.ExecuteNonQuery()
                        End If
                    Next
                    TR.Commit()
                    MessageBox.Show("Data Berhasil Disimpan", "Informasi")
                Catch ex As Exception
                    TR.Rollback()
                    MessageBox.Show(ex.Message)
                End Try
                SimpanHistori()
                'SimpanHistoriDetil()
            End If
        End Using
        Bukakunci()
        DGV.Rows.Clear()
        Bukakunci()
        Bersihtext()
        '
        cmbPlanMonth.Text = ""
        cmbVendor.Text = ""
        '
        KonIstem.Close()
    End Sub
    Sub SimpanHistori()
        Dim Tanggaldlv, TglUpdate As Date
        'Using KonCIM As New SqlConnection(ConString)
        Using KonIstem As New SqlConnection(ConStringISTEM)
            'If MessageBox.Show("Yakin akan di Simpan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            ''
            SimpanHeader = "Insert into sl_deliv_yarn_grey_header_hist(plan_month,vendor_code,yarn_grey_flag,upd_date,user_id,rec_sts,proc_no,upd_time,client_ip)" _
            & "values(@plan_month,@vendor_code,@yarn_grey_flag,@upd_date,@user_id,@rec_sts,@proc_no,@upd_time,@client_ip)"
            Dim CMDHEADER As New SqlCommand(SimpanHeader, KonIstem)
            '
            SimpanDetil = "Insert into sl_deliv_yarn_grey_detail_hist(plan_month,vendor_code,yarn_grey_code,plan_deliv_date,plan_deliv_qty,plan_deliv_qty_unit,rec_sts,proc_no)" _
            & "values(@plan_month,@vendor_code,@yarn_grey_code,@plan_deliv_date,@plan_deliv_qty,@plan_deliv_qty_unit,@rec_sts,@proc_no)"
            Dim CMDDetil As New SqlCommand(SimpanDetil, KonIstem)
            '@rec_sts,@proc_no
            CMDHEADER.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            'CMDHEADER.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
            CMDHEADER.Parameters.Add(New SqlParameter("@vendor_code", SqlDbType.VarChar))
            CMDHEADER.Parameters.Add(New SqlParameter("@yarn_grey_flag", SqlDbType.TinyInt))
            CMDHEADER.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            CMDHEADER.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            CMDHEADER.Parameters.Add(New SqlParameter("@upd_date", SqlDbType.Date))
            CMDHEADER.Parameters.Add(New SqlParameter("@upd_time", SqlDbType.VarChar))
            CMDHEADER.Parameters.Add(New SqlParameter("@user_id", SqlDbType.VarChar))
            CMDHEADER.Parameters.Add(New SqlParameter("@client_ip", SqlDbType.VarChar))
            ''
            CMDDetil.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
            'CMDDetil.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
            CMDDetil.Parameters.Add(New SqlParameter("@vendor_code", SqlDbType.VarChar))
            CMDDetil.Parameters.Add(New SqlParameter("@yarn_grey_code", SqlDbType.VarChar))
            CMDDetil.Parameters.Add(New SqlParameter("@plan_deliv_date", SqlDbType.Date))
            CMDDetil.Parameters.Add(New SqlParameter("@plan_deliv_qty", SqlDbType.Int))
            CMDDetil.Parameters.Add(New SqlParameter("@plan_deliv_qty_unit", SqlDbType.TinyInt))
            CMDDetil.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
            CMDDetil.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
            '
            KonIstem.Open()
            TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
            CMDHEADER.Transaction = TR
            ''
            CMDDetil.Transaction = TR
            '
            Try
                '
                TglUpdate = Convert.ToDateTime(frmMenuUtama.TSlblTanggal.Text)
                CMDHEADER.Parameters("@plan_month").Value = cmbPlanMonth.Text
                'CMDHEADER.Parameters("@request_version").Value = "1"
                CMDHEADER.Parameters("@vendor_code").Value = txtKdVendor.Text
                'request dari ibu felis pilih yarn =0 klo grey=1
                Select Case True
                    Case OptYarn.Checked
                        CMDHEADER.Parameters("@yarn_grey_flag").Value = "0"
                    Case OptGrey.Checked
                        CMDHEADER.Parameters("@yarn_grey_flag").Value = "1"
                End Select
                '
                CMDHEADER.Parameters("@rec_sts").Value = "A"
                CMDHEADER.Parameters("@proc_no").Value = "1"
                CMDHEADER.Parameters("@upd_date").Value = TglUpdate 'Format(TglUpdate, "yyyy/MM/dd") 'Convert.ToDateTime(Menu_Utama.TSlblTanggal.Text)
                ' Format(Date.Now, "yyyy/MM/dd")
                CMDHEADER.Parameters("@upd_time").Value = frmMenuUtama.TSlblJam.Text
                CMDHEADER.Parameters("@user_id").Value = frmMenuUtama.tsLabelUser.Text
                CMDHEADER.Parameters("@client_ip").Value = frmMenuUtama.TSlbip.Text
                '
                CMDHEADER.ExecuteNonQuery()
                '
                For Each row As DataGridViewRow In DGV.Rows
                    If Not row.IsNewRow Then
                        Tanggaldlv = Convert.ToDateTime(row.Cells(2).Value.ToString)
                        CMDDetil.Parameters("@plan_month").Value = cmbPlanMonth.Text
                        'CMDDetil.Parameters("@request_version").Value = "1"
                        CMDDetil.Parameters("@vendor_code").Value = txtKdVendor.Text
                        CMDDetil.Parameters("@yarn_grey_code").Value = row.Cells(0).Value.ToString
                        CMDDetil.Parameters("@plan_deliv_date").Value = Tanggaldlv 'Convert.ToDateTime(row.Cells(2).Value.ToString)
                        CMDDetil.Parameters("@plan_deliv_qty").Value = (row.Cells(3).Value.ToString)
                        ' Status plan_deliv_qty_unit
                        StatusDeliv_unit = row.Cells(4).Value.ToString
                        '
                        Select Case StatusDeliv_unit
                            Case "KG"
                                SatuanDeliv_unit = 0
                            Case "LBS"
                                SatuanDeliv_unit = 1
                            Case "MTR"
                                SatuanDeliv_unit = 2
                            Case "YDS"
                                SatuanDeliv_unit = 3
                        End Select
                        '
                        CMDDetil.Parameters("@plan_deliv_qty_unit").Value = SatuanDeliv_unit 'row.Cells(4).Value.ToString
                        CMDDetil.Parameters("@rec_sts").Value = "A"
                        CMDDetil.Parameters("@proc_no").Value = "1"
                        '
                        CMDDetil.ExecuteNonQuery()
                    End If
                Next
                TR.Commit()
                'MessageBox.Show("Data Berhasil Disimpan", "Informasi")
            Catch ex As Exception
                TR.Rollback()
                MessageBox.Show(ex.Message)
            End Try
            ' End If
        End Using
    End Sub


    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        Kunci()
        Bersihtextedit()
        cmbPlanMonth.Focus()
        TabControl1.SelectTab(0)
    End Sub

    Private Sub OptGrey_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptGrey.Click
        cmbDlvUnit.Items.Clear()
        If OptGrey.Checked = True Then
            cmbDlvUnit.Items.Add("MTR")
            cmbDlvUnit.Items.Add("YDS")
        End If
        CariItemGrey()
    End Sub

    Private Sub OptGrey_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptGrey.CheckedChanged
        If OptGrey.Checked = True Then
            CariItemGrey()
        End If
    End Sub

    Private Sub OptYarn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptYarn.CheckedChanged
        If OptYarn.Checked = True Then
            CariItemYarn()
        End If
    End Sub

    Private Sub OptYarn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OptYarn.Click
        cmbDlvUnit.Items.Clear()
        If OptYarn.Checked = True Then
            cmbDlvUnit.Items.Add("KG")
            cmbDlvUnit.Items.Add("LBS")
        End If
        CariItemYarn()
        '
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim S As String
        S = Split(cmbGreyno.Text, "-")(0)
        txtItemName.Text = S
    End Sub

    Private Sub cmbVendor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbVendor.SelectedIndexChanged
        Dim S As String
        CariNamaVendor()
        '
        S = Split(cmbVendor.Text, " ")(0)
        txtKdVendor.Text = S
    End Sub
    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEdit.Click
        TabControl1.SelectTab(1)
        Kunci()
        BukakunciDetil()
        Editdetil = True
        BtnSave.Visible = False
        BtnSaveedit.Visible = True
        BtnDeleteDetil.Enabled = False
    End Sub

    Sub SortPlan()
        '
        TxtHasilModif.Text = cmbPlanMonthedit.Text
        '
        KoneksiISTEM()
        KonIstem.Open()
        '  If OptUbah.Checked = True Then
        CMDHEADER = New SqlCommand("Select * from sl_deliv_yarn_grey_header where plan_month = '" & (TxtHasilModif.Text) & "'", KonIstem)
        DR = CMDHEADER.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            'BukaData()
            'NilaiTglakhirAwal = DR.Item("request_date")
            lblTglAwal.Text = DR.Item("upd_date")
            lblTglAkhir.Text = DR.Item("upd_date")
            txtKdesatuan.Text = DR.Item("yarn_grey_flag")
            txtKodeVendoredit.Text = DR.Item("vendor_code")
            ''
            Select Case txtKdesatuan.Text
                Case "0"
                    OptYrnEdit.Checked = True
                Case "1"
                    OptGryedit.Checked = True
            End Select
            '
            DataDetil()
        Else
            MsgBox("Maaf Data Set Plant Tidak ada ", vbInformation, "Informasi")
            Bukakunci()
            'OptUbah.Checked = False
            Exit Sub
        End If
    End Sub
    Sub CekSetPlantHeader()
        '
        'Kon = New SqlConnection(ConString)
        'Koncim.Open()
        ' cek Data yang sudah diinput
        KoneksiISTEM()
        KonIstem.Open()
        '
        CMDHEADER = New SqlCommand("Select * from sl_deliv_yarn_grey_header where plan_month = '" & (cmbPlanMonth.Text) & "' and vendor_code ='" & (txtKdVendor.Text) & "'", KonIstem)
        DR = CMDHEADER.ExecuteReader
        If DR.HasRows Then
            'SortData()
            MsgBox("Maaf Data Set Planth Sudah ada", MsgBoxStyle.Information, "Informasi")
            'Bersihtext()
            Bukakunci()
            pnlEntryHeader.Enabled = False
            BtnAdd.Focus()
            cmbVendor.Text = ""
            Exit Sub
        Else
            'Bersihtext()
            'PnlEntry.Enabled = True
            cmbVendor.Focus()
        End If
        '
        KonIstem.Close()
    End Sub
    Private Sub DGV_edit_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
        DGV_edit.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub
    Private Sub DGV_edit_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
        '
        Try
            KoneksiISTEM()
            'KonCIM.Open()
            'Kon = New SqlConnection(ConString)
            '
            txtKdNameedit.Text = DGV_edit.Rows(e.RowIndex).Cells(0).Value
            dtpTanggalEdit.Value = DGV_edit.Rows(e.RowIndex).Cells(1).Value
            txtDlvqtyEdit.Text = DGV_edit.Rows(e.RowIndex).Cells(2).Value
            '
            SatuanDeliv_unit = DGV_edit.Rows(e.RowIndex).Cells(3).Value
            Select Case SatuanDeliv_unit
                Case "0"
                    StatusDeliv_unit = "KG"
                Case "1"
                    StatusDeliv_unit = "LBS"
                Case "2"
                    StatusDeliv_unit = "MTR"
                Case "YDS"
                    StatusDeliv_unit = "YDS"""
            End Select
            '
            cmbDlvUnitedit.Text = StatusDeliv_unit 'DGV_edit.Rows(e.RowIndex).Cells(3).Value
            '
            CariNamaOITM()
            'PilihJenisEdit()
            ' TxtHasilModif.Text
            '
            CMD = New SqlCommand("Select * from sl_deliv_yarn_grey_detail where plan_month = '" & (TxtHasilModif.Text) & "' and yarn_grey_code ='" & (DGV_edit.Rows(e.RowIndex).Cells(0).Value) & "'", KonIstem)
            '
            KonIstem.Open()
            DR = CMD.ExecuteReader
            DR.Read()
            '
            If DR.HasRows Then

            End If
            KonIstem.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DGV_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGV.CellFormatting
        DGV.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub
    Private Sub BtnUbah_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUbah_dtl.Click
        KunciDetil()
        'PilihJenisEdit()
        'BukaUnitDlv()
        UbahDetil = True
        TambahDetil = False
    End Sub

    Private Sub BtnCekDetil_Click_1(sender As Object, e As EventArgs) Handles BtnCekDetil.Click
        ''
        'DGVDetiledit.Refresh()
        'DGVDetiledit.Rows.Clear()
        ''
        'For Each row As DataGridViewRow In DGVDetiledit.Rows
        '    If Not row.IsNewRow Then
        '        KodeItem = row.Cells(0).Value.ToString
        '        plandeliv = row.Cells(1).Value.ToString
        '        Planqty = row.Cells(2).Value.ToString
        '        Planunit = row.Cells(3).Value.ToString
        '        '
        '        Select Case Planunit
        '            Case 0
        '                Planunitedit = "KG"
        '            Case 1
        '                Planunitedit = "LBS"
        '            Case 2
        '                Planunitedit = "MTR"
        '            Case 3
        '                Planunitedit = "YDS"
        '        End Select
        '        '
        '        'Cek_NamaVendorSAP()
        '        '
        '        CariNamaVendor()
        '        '
        '        DGVDetiledit.Rows.Add(KodeVendor)
        '        'DA = New SqlDataAdapter("Select yarn_grey_code as Item_Code,plan_deliv_date as Est_Delivery_Date,plan_deliv_qty as Delivery_Qty,plan_deliv_qty_unit as Delivery_Unit from sl_deliv_yarn_grey_detail where plan_month = '" & (TxtHasilModif.Text) & "' and vendor_code = '" & (txtKodeVendoredit.Text) & "'", KonIstem)
        '        '   '
        '        For barisatas As Integer = 0 To DGVDetiledit.RowCount - 1
        '            For barisbawah As Integer = barisatas + 1 To DGVDetiledit.RowCount - 1
        '            Next
        '        Next
        '        '
        '        DGVDetiledit(0, DGVDetiledit.RowCount - 2).Value = KodeItem
        '        DGVDetiledit(1, DGVDetiledit.RowCount - 2).Value = Namaitem
        '        DGVDetiledit(2, DGVDetiledit.RowCount - 2).Value = Format(plandeliv, "dd/MM/yyyy")
        '        DGVDetiledit(3, DGVDetiledit.RowCount - 2).Value = Planqty
        '        DGVDetiledit(4, DGVDetiledit.RowCount - 2).Value = Planunitedit
        '        '
        'End If
        'Next
    End Sub
    Sub Cekdetil()
        '
        DGVDetiledit.Refresh()
        DGVDetiledit.Rows.Clear()
        '
       
        For Each row As DataGridViewRow In DGV_edit.Rows
            If Not row.IsNewRow Then
                KodeItem = row.Cells(0).Value.ToString
                plandeliv = row.Cells(1).Value.ToString
                Planqty = row.Cells(2).Value.ToString
                Planunit = row.Cells(3).Value.ToString
                plandelivedit = row.Cells(1).Value.ToString
                '
                Select Case Planunit
                    Case 0
                        Planunitedit = "KG"
                    Case 1
                        Planunitedit = "LBS"
                    Case 2
                        Planunitedit = "MTR"
                    Case 3
                        Planunitedit = "YDS"
                End Select
                '
                'Cek_NamaVendorSAP()
                '
                CariNamaItem()
                '
                DGVDetiledit.Rows.Add(KodeItem)
                'DA = New SqlDataAdapter("Select yarn_grey_code as Item_Code,plan_deliv_date as Est_Delivery_Date,plan_deliv_qty as Delivery_Qty,plan_deliv_qty_unit as Delivery_Unit from sl_deliv_yarn_grey_detail where plan_month = '" & (TxtHasilModif.Text) & "' and vendor_code = '" & (txtKodeVendoredit.Text) & "'", KonIstem)
                '   '
                For barisatas As Integer = 0 To DGVDetiledit.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To DGVDetiledit.RowCount - 1
                    Next
                Next
                '
                With DGVDetiledit
                    .Columns.Add("KodeItem1", "KodeItem1")
                    .Columns.Add("Namaitem1", "Namaitem1")
                    .Columns.Add("Plandeliv1", "Plandeliv1")
                    .Columns.Add("Planqty1", "Planqty1")
                    .Columns.Add("Planunitedit1", "Planunitedit1")
                    .Columns.Add("Plandelivedit1", "Plandelivedit1")
                    .Columns.Add("Plan_month1", "Plan_month1")
                End With
                '
                DGVDetiledit(0, DGVDetiledit.RowCount - 2).Value = KodeItem
                DGVDetiledit(1, DGVDetiledit.RowCount - 2).Value = Namaitem
                DGVDetiledit(2, DGVDetiledit.RowCount - 2).Value = Format(plandeliv, "dd/MM/yyyy")
                DGVDetiledit(3, DGVDetiledit.RowCount - 2).Value = Planqty
                DGVDetiledit(4, DGVDetiledit.RowCount - 2).Value = Planunitedit
                DGVDetiledit(5, DGVDetiledit.RowCount - 2).Value = plandelivedit
                DGVDetiledit(6, DGVDetiledit.RowCount - 2).Value = cmbPlanMonthedit.Text
                '
                'DGVDetiledit.Columns(1).Visible = False
            End If
        Next
    End Sub
    Private Sub BtnDeleteDetil_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDeleteDetil.Click
        Dim HapusData As String
        Dim y As Integer
        Dim TGL, BLN, THN As String
        Dim TanggalEdit As String
        'Dim CariTgl As Date
        'Dim cariedittanggal As String
        'Dim Tanggallagi As Date
        '
        Dim x As Integer
        KoneksiISTEM()
        KonIstem.Open()
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            If cmbPlanMonthedit.Text = "" Then
                MsgBox("Maaf Data Belum Dipilih", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '
            'lblRemindtoperiod1 = Format((NilaiTglakhirprd1), "MM/dd/yyyy")
            'Hasilfrmperiodawal = Convert.ToDateTime(lblRemindfrmperiodawal)           '
            x = DGVDetiledit.CurrentRow.Index
            '
            If DGVDetiledit.RowCount = 0 Then
                MessageBox.Show("Maaf Data Sedang Kosong")
                Exit Sub
            End If
            '
            CariTanggal = (DGVDetiledit.Item(2, x).Value)
            TGL = Format(Microsoft.VisualBasic.Left((CariTanggal), 2))
            BLN = Format(Microsoft.VisualBasic.Mid((CariTanggal), 4, 2))
            THN = Format(Microsoft.VisualBasic.Right((CariTanggal), 4))
            TanggalEdit = THN + "/" + BLN + "/" + TGL
            HapusTanggal = Convert.ToDateTime(TanggalEdit)
            CariTgl = Format(HapusTanggal, "yyyy/MM/dd")
            CekHapusdata()
            'x = DGVDetiledit.RowCount
            If Hapusbaris = True Then
                If MessageBox.Show("Yakin akan di Hapus...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    HapusData = "delete sl_deliv_yarn_grey_detail where plan_month ='" & (cmbPlanMonthedit.Text) & "' and vendor_code ='" & (txtKodeVendoredit.Text) & "' and yarn_grey_code='" & (DGVDetiledit.Item(0, x).Value) & "' and plan_deliv_date='" & (CariTgl) & "'"
                    'CmdCaridata = New SqlCommand("Select * from sl_deliv_yarn_grey_detail where plan_month ='" & (cmbPlanMonthedit.Text) & "' and vendor_code ='" & (txtKodeVendoredit.Text) & "' and yarn_grey_code='" & (DGVDetiledit.Item(0, x).Value) & "'  and plan_deliv_date = '" & (HapusTanggal) & "'", KonIstem)
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
                        y = DGVDetiledit.RowCount
                        If DGVDetiledit.RowCount <= 1 Then
                            Exit Sub
                        Else
                            DGVDetiledit.Rows.RemoveAt(DGVDetiledit.CurrentCell.RowIndex)
                        End If
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
            Else
                If MessageBox.Show("Yakin akan di Hapus...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    'x = DGVDetiledit.RowCount
                    If DGVDetiledit.RowCount <= 1 Then
                        Exit Sub
                    Else
                        DGVDetiledit.Rows.RemoveAt(DGVDetiledit.CurrentCell.RowIndex)
                    End If
                End If
            End If
        End Using
        '
        SortPlan()
        Kunci()
        Bukakunci()
        'KunciDetil()
        'BukakunciDetil()
        '
        BtnCancel.Enabled = False
        BtnSaveedit.Visible = False
        BtnSave.Visible = True
        'BtnDeleteDetil.Enabled = False
        '
        'BtnDeleteDetil.Enabled = False
        'BtnTmbhDtl.Enabled = False
        'BtnSimpan_dtl.Enabled = False
        'BtnBatal_dtl.Enabled = False
        'BtnUbah_dtl.Enabled = False
        ''
        'BtnSave.Enabled = False
        'BukaData()
        'SortData()
    End Sub
    Sub CekHapusdata()
        Dim x As Integer
        'Dim CariTanggal As Date
        KoneksiISTEM()
        KonIstem.Open()
        '
        x = DGVDetiledit.CurrentRow.Index
        'CariTanggal = Format(HapusTanggal,"MM-dd-yyyy")
        Try
            CmdCaridata = New SqlCommand("Select * from sl_deliv_yarn_grey_detail where plan_month ='" & (cmbPlanMonthedit.Text) & "' and vendor_code ='" & (txtKodeVendoredit.Text) & "' and yarn_grey_code='" & (DGVDetiledit.Item(0, x).Value) & "'  and plan_deliv_date = '" & (HapusTanggal) & "'", KonIstem)
            DREDIT = CmdCaridata.ExecuteReader
            DREDIT.Read()
            'KonIstem.Close()
            If DREDIT.HasRows Then
                Hapusbaris = True
            Else
                Hapusbaris = False
            End If
            '
            KonIstem.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BtnSimpan_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Using Kon As New SqlConnection(ConString)
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            If MessageBox.Show("Yakin akan di Simpan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                KonIstem.Open()
                TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
                '
                If TambahDetil = True Then
                    SimpanDetil = "Insert into sl_deliv_yarn_grey_detail(plan_month,request_version,vendor_code,yarn_grey_code,plan_deliv_date,plan_deliv_qty," _
                        & "plan_deliv_qty_unit,rec_sts,proc_no) " _
                        & " values(@plan_month,@request_version,@vendor_code,@yarn_grey_code,@plan_deliv_date,@plan_deliv_qty,@plan_deliv_qty_unit,@rec_sts,@proc_no)"
                    Dim CMDTambahdtl As New SqlCommand(SimpanDetil, KonIstem)
                    '
                    CMDTambahdtl.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                    CMDTambahdtl.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
                    CMDTambahdtl.Parameters.Add(New SqlParameter("@vendor_code", SqlDbType.VarChar))
                    CMDTambahdtl.Parameters.Add(New SqlParameter("@yarn_grey_code", SqlDbType.VarChar))
                    CMDTambahdtl.Parameters.Add(New SqlParameter("@plan_deliv_date", SqlDbType.Date))
                    CMDTambahdtl.Parameters.Add(New SqlParameter("@plan_deliv_qty", SqlDbType.Int))
                    CMDTambahdtl.Parameters.Add(New SqlParameter("@plan_deliv_qty_unit", SqlDbType.TinyInt))
                    CMDTambahdtl.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                    CMDTambahdtl.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                    '
                    CMDTambahdtl.Transaction = TR
                    Try
                        '
                        CMDTambahdtl.Parameters("@plan_month").Value = TxtHasilModif.Text
                        CMDTambahdtl.Parameters("@request_version").Value = "1"
                        CMDTambahdtl.Parameters("@vendor_code").Value = txtKodeVendoredit.Text
                        CMDTambahdtl.Parameters("@yarn_grey_code").Value = txtKdNameedit.Text
                        CMDTambahdtl.Parameters("@plan_deliv_date").Value = Format(dtpTanggalEdit.Value, "yyyy/MM/dd")
                        CMDTambahdtl.Parameters("@plan_deliv_qty").Value = txtDlvqtyEdit.Text
                        '
                        ' Status plan_deliv_qty_unit
                        StatusDeliv_unit = cmbDlvUnitedit.Text
                        Select Case StatusDeliv_unit
                            Case "KG"
                                SatuanDeliv_unit = 0
                            Case "LBS"
                                SatuanDeliv_unit = 1
                            Case "MTR"
                                SatuanDeliv_unit = 2
                            Case "YDS"
                                SatuanDeliv_unit = 3
                        End Select
                        '
                        CMDTambahdtl.Parameters("@plan_deliv_qty_unit").Value = SatuanDeliv_unit
                        CMDTambahdtl.Parameters("@rec_sts").Value = "A"
                        CMDTambahdtl.Parameters("@proc_no").Value = "1"
                        '
                        CMDTambahdtl.ExecuteNonQuery()
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
                    Ubahdata = "Update sl_deliv_yarn_grey_detail set  plan_month=@plan_month,yarn_grey_code=@yarn_grey_code,plan_deliv_date=@plan_deliv_date," _
                        & " plan_deliv_qty=@plan_deliv_qty,plan_deliv_qty_unit=@plan_deliv_qty_unit,rec_sts=@rec_sts,proc_no=@proc_no where plan_month=@plan_month and yarn_grey_code=@yarn_grey_code"
                    Dim CMDUbahdtl As New SqlCommand(Ubahdata, KonIstem)
                    '
                    CMDUbahdtl.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
                    CMDUbahdtl.Parameters.Add(New SqlParameter("@yarn_grey_code", SqlDbType.VarChar))
                    CMDUbahdtl.Parameters.Add(New SqlParameter("@plan_deliv_date", SqlDbType.Date))
                    CMDUbahdtl.Parameters.Add(New SqlParameter("@plan_deliv_qty", SqlDbType.Int))
                    CMDUbahdtl.Parameters.Add(New SqlParameter("@plan_deliv_qty_unit", SqlDbType.TinyInt))
                    CMDUbahdtl.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
                    CMDUbahdtl.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
                    '
                    CMDUbahdtl.Transaction = TR
                    Try
                        '
                        CMDUbahdtl.Parameters("@plan_month").Value = TxtHasilModif.Text
                        CMDUbahdtl.Parameters("@yarn_grey_code").Value = txtKdNameedit.Text
                        CMDUbahdtl.Parameters("@plan_deliv_date").Value = Format(dtpTanggalEdit.Value, "yyyy/MM/dd")
                        CMDUbahdtl.Parameters("@plan_deliv_qty").Value = txtDlvqtyEdit.Text
                        ' Status plan_deliv_qty_unit
                        StatusDeliv_unit = cmbDlvUnitedit.Text
                        Select Case StatusDeliv_unit
                            Case "KG"
                                SatuanDeliv_unit = 0
                            Case "LBS"
                                SatuanDeliv_unit = 1
                            Case "MTR"
                                SatuanDeliv_unit = 2
                            Case "YDS"
                                SatuanDeliv_unit = 3
                        End Select
                        '
                        CMDUbahdtl.Parameters("@plan_deliv_qty_unit").Value = SatuanDeliv_unit
                        CMDUbahdtl.Parameters("@rec_sts").Value = "T"
                        CMDUbahdtl.Parameters("@proc_no").Value = "2"
                        '
                        CMDUbahdtl.ExecuteNonQuery()
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
        SortPlan()
        '
        txtKdNameedit.Visible = True
        txtItmNameedit.Visible = True
        cmbGreynoedit.Visible = False
        Bukakunci()
        'BukakunciDetil()
        BtnDeleteDetil.Enabled = False
        BtnTmbhDtl.Enabled = False
        BtnSimpan_dtl.Enabled = False
        BtnBatal_dtl.Enabled = False
        BtnUbah_dtl.Enabled = False
        '
        BtnSave.Enabled = False
    End Sub

    Private Sub BtnTambahEditdetil_Click(sender As Object, e As EventArgs) Handles BtnTambahEditdetil.Click
        '
        If cmbGreynoedit.Text = "" Or txtItmNameedit.Text = "" Or txtDlvqtyEdit.Text = "" Or cmbDlvUnitedit.Text = "" Then
            MsgBox("Maaf data Tidak boleh dalam keadaan kosong", vbInformation, "Informasi")
            cmbGreyno.Focus()
            Exit Sub
        End If
        Dim baris As Integer = DGVDetiledit.RowCount - 1
        'Kon = New SqlConnection(ConString)
        'Kon.Open()
        KoneksiISTEM()
        KonIstem.Open()
        '      
        'kunci identifikasi klo ada yang ganda di datagrid dengan kode item dan tanggal
        DGVDetiledit.Rows.Add(txtKdNameedit.Text & Format(dtpTanggalEdit.Value, "MM/dd/yyyy"))
        '
        For barisatas As Integer = 0 To DGVDetiledit.RowCount - 1
            For barisbawah As Integer = barisatas + 1 To DGVDetiledit.RowCount - 1
                If DGVDetiledit.Rows(barisbawah).Cells(0).Value & DGVDetiledit.Rows(barisbawah).Cells(2).Value = DGVDetiledit.Rows(barisatas).Cells(0).Value & DGVDetiledit.Rows(barisatas).Cells(2).Value Then
                    MsgBox("Nomor Grey sudah Ada")
                    DGVDetiledit.Rows.RemoveAt(barisbawah)
                    Bersihtext()
                    cmbGreynoedit.Focus()
                    Exit Sub
                End If
            Next
        Next
        '
        DGVDetiledit(0, DGVDetiledit.RowCount - 2).Value = txtKdNameedit.Text
        DGVDetiledit(1, DGVDetiledit.RowCount - 2).Value = txtItmNameedit.Text
        DGVDetiledit(2, DGVDetiledit.RowCount - 2).Value = Format(dtpTanggalEdit.Value, "yyyy/MM/dd") 'Format(dtpTanggalEdit.Value, "dd/MM/yyyy")
        DGVDetiledit(3, DGVDetiledit.RowCount - 2).Value = txtDlvqtyEdit.Text
        DGVDetiledit(4, DGVDetiledit.RowCount - 2).Value = cmbDlvUnitedit.Text
        DGVDetiledit(5, DGVDetiledit.RowCount - 2).Value = Format(dtpTanggalEdit.Value, "yyyy/MM/dd")
        DGVDetiledit(6, DGVDetiledit.RowCount - 2).Value = cmbPlanMonthedit.Text
        '
        cmbGreynoedit.Focus()
        Bersihtextedit()
        'Bersihtext()
        KonIstem.Close()
    End Sub
    
    Sub UbahHistoriDetil()

    End Sub
    Sub UbahHistoriHeader()

    End Sub

    Private Sub BtnSetPlanedit_Click_1(sender As Object, e As EventArgs) Handles BtnSetPlanedit.Click
        '
        TxtHasilModif.Text = cmbPlanMonthedit.Text
        'Kon = New SqlConnection(ConString)
        'Koncim.Open()
        KoneksiISTEM()
        KonIstem.Open()
        '
        CMDHEADER = New SqlCommand("Select * from sl_deliv_yarn_grey_header where plan_month = '" & (TxtHasilModif.Text) & "'", KonIstem)
        DR = CMDHEADER.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            'BukaData()
            'NilaiTglakhirAwal = DR.Item("request_date")
            lblTglAwal.Text = DR.Item("upd_date")
            lblTglAkhir.Text = DR.Item("upd_date")
            txtKdesatuan.Text = DR.Item("yarn_grey_flag")
            txtKodeVendoredit.Text = DR.Item("vendor_code")
            'lblUpdateV.Text = DR.Item("request_version")
            ''
            Select Case txtKdesatuan.Text
                Case "0"
                    OptYrnEdit.Checked = True
                Case "1"
                    OptGryedit.Checked = True
            End Select
            '
            DataHeader()
            DataDetil()
            DataDetil2()
            '
            BtnCekBrs_Click(sender, New System.EventArgs)
            BtnTmbhDtl_Click(sender, New System.EventArgs)
        Else
            MsgBox("Maaf Data Set Plant Tidak ada ", vbInformation, "Informasi")
            Bukakunci()
            DataHeader()
            DataDetil()
            ''
            DGVHeaderEdit.Refresh()
            DGVHeaderEdit.Rows.Clear()
            DGVDetiledit.Rows.Clear()
            '
            Exit Sub
        End If
        '
        cmbGreynoedit.Visible = True
        cmbGreynoedit.Focus()
        '
        DGVDTL3.Visible = True
        DGVDetiledit.Visible = False
    End Sub
    Private Sub BtnDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnDelete.Click
        Dim Hapusdatadetil, Hapusdataheader As String
        '
        'Using Kon As New SqlConnection(ConString)
        KoneksiISTEM()
        KonIstem.Open()
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            If TxtHasilModif.Text = "" Then
                MsgBox("Maaf Data Belum Dipilih", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '
            If MessageBox.Show("Yakin akan di Hapus semua data di kode Vendor " + (txtKodeVendoredit.Text), "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Hapusdatadetil = "delete sl_deliv_yarn_grey_detail where plan_month ='" & (TxtHasilModif.Text) & "' and vendor_code='" & (txtKodeVendoredit.Text) & "'"
                Hapusdataheader = "delete sl_deliv_yarn_grey_header where plan_month ='" & (TxtHasilModif.Text) & "' and vendor_code='" & (txtKodeVendoredit.Text) & "'"
                Dim CMDHapusheader As New SqlCommand(Hapusdataheader, KonIstem)
                Dim CMDHapusdetil As New SqlCommand(Hapusdatadetil, KonIstem)
                '
                KonIstem.Open()
                TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
                '
                CMDHapusheader.Transaction = TR
                CMDHapusdetil.Transaction = TR
                Try
                    '
                    CMDHapusdetil.ExecuteNonQuery()
                    CMDHapusheader.ExecuteNonQuery()
                    '
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
        'DGV_edit.Rows.Clear()
        'SortPlan()
        DataHeader()
        DataDetil()
    End Sub
    Private Sub cmbGreynoedit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGreynoedit.SelectedIndexChanged
        Dim S, NM As String
        pnlEntryHeader.Enabled = False
        CariNamaItem()
        S = Split(cmbGreynoedit.Text, "-")(0)
        NM = Split(cmbGreynoedit.Text, "-")(1)
        txtItmNameedit.Text = NM
        txtKdNameedit.Text = S
    End Sub
    Private Sub BtnDeleteDetil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim HapusData As String
        Dim HapusTanggal As Date
        KoneksiISTEM()
        KonIstem.Open()
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            'Using Kon As New SqlConnection(ConString)
            '
            HapusTanggal = dtpTanggalEdit.Value
            '
            If TxtHasilModif.Text = "" Then
                MsgBox("Maaf Data Belum Dipilih", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
                Exit Sub
            End If
            '
            If MessageBox.Show("Yakin akan di Hapus...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                HapusData = "delete sl_deliv_yarn_grey_detail where plan_month ='" & (TxtHasilModif.Text) & "' and yarn_grey_code='" & (txtKdNameedit.Text) & "' and plan_deliv_date='" & (HapusTanggal) & "'"
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
            End If
        End Using
        SortPlan()
        Bukakunci()
        KunciDetil()
        '
        BtnDeleteDetil.Enabled = False
        BtnTmbhDtl.Enabled = False
        BtnSimpan_dtl.Enabled = False
        BtnBatal_dtl.Enabled = False
        BtnUbah_dtl.Enabled = False
        '
        BtnSave.Enabled = False
        'BukaData()
        'SortData()
    End Sub
    'Private Sub cmbDlvUnitedit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDlvUnitedit.SelectedIndexChanged
    '    PilihJenisEdit()
    'End Sub

    Private Sub BtnBatal_dtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        '
        txtKdNameedit.Visible = True
        txtItmNameedit.Visible = True
        cmbGreynoedit.Visible = False
        Bukakunci()
        BukakunciDetil()
        '
        SortPlan()
        BtnSave.Enabled = False
        BtnSetPlanedit.Focus()
    End Sub
    Private Sub BtnUpdateV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdateV.Click
        KoneksiISTEM()
        Using KonIstem As New SqlConnection(ConStringISTEM)
            If MessageBox.Show("Yakin akan di Memperbarui Laporan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                UbahDataHeader = "Update sl_deliv_yarn_grey_header set request_version=@request_version where plan_month ='" & (cmbPlanMonthedit.Text) & "' and vendor_code = '" & (txtKodeVendoredit.Text) & "'"
                UbahDataDetil = "Update sl_deliv_yarn_grey_detail set request_version=@request_version where plan_month ='" & (cmbPlanMonthedit.Text) & "' and vendor_code = '" & (txtKodeVendoredit.Text) & "'"
                '
                Dim i As Integer
                If CInt(lblUpdateV.Text) = 1 Then
                    i = CInt(lblUpdateV.Text) + 1
                Else
                    i = CInt(lblUpdateV.Text) + 1
                End If
                Dim CMD As New SqlCommand(UbahDataHeader, KonIstem)
                CMDDETIL = New SqlCommand(UbahDataDetil, KonIstem)
                ''
                CMD.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
                CMDDETIL.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
                '
                KonIstem.Open()
                TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
                CMD.Transaction = TR
                CMDDETIL.Transaction = TR
                Try
                    CMD.Parameters("@request_version").Value = i
                    For Each row As DataGridViewRow In DGV_edit.Rows
                        If Not row.IsNewRow Then
                            CMDDETIL.Parameters("@request_version").Value = i
                        End If
                    Next
                    '
                    CMD.ExecuteNonQuery()
                    CMDDETIL.ExecuteNonQuery()
                    TR.Commit()
                    MessageBox.Show("Laporan Berhasil Di Perbarui", "Informasi")
                Catch ex As Exception
                    Try
                        TR.Rollback()
                        MessageBox.Show(ex.Message)
                    Catch rollBackEx As Exception
                        MessageBox.Show(rollBackEx.Message)
                    End Try
                End Try
            End If
            'SortData()
        End Using
        Bukakunci()
        KunciDetil()
        '
        BtnDeleteDetil.Enabled = False
        BtnTmbhDtl.Enabled = False
        BtnSimpan_dtl.Enabled = False
        BtnBatal_dtl.Enabled = False
        BtnUbah_dtl.Enabled = False
        '
        BtnSave.Enabled = False
    End Sub

    Private Sub BtnCekBrs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'DGVHeaderEdit.Columns(0).Width = 100
        'DGVHeaderEdit.Columns(1).Width = 100
        'DGVHeaderEdit.Columns(2).Width = 100
        '
        DGVHeaderEdit.Refresh()
        DGVHeaderEdit.Rows.Clear()
        '
        For Each row As DataGridViewRow In DGVHeader.Rows
            If Not row.IsNewRow Then
                KodeVendor = row.Cells(0).Value.ToString
                Jenis = row.Cells(1).Value.ToString
                'Cek_NamaVendorSAP()
                '
                CariNamaVendor()
                '
                DGVHeaderEdit.Rows.Add(KodeVendor)
                '
                For barisatas As Integer = 0 To DGVHeaderEdit.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To DGVHeaderEdit.RowCount - 1
                    Next
                Next
                '
                DGVHeaderEdit(0, DGVHeaderEdit.RowCount - 2).Value = KodeVendor
                DGVHeaderEdit(1, DGVHeaderEdit.RowCount - 2).Value = NamaVendor
                DGVHeaderEdit(2, DGVHeaderEdit.RowCount - 2).Value = Jenis
                '
                'NamaVendor = row.Cells(2).Value.ToString
            End If
        Next
        '
    End Sub

    Private Sub DGVHeader_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVHeader.CellFormatting
        DGVHeader.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub DGVHeader_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGVHeader.CellMouseClick
        Try
            'Kon = New SqlConnection(ConString)
            KoneksiISTEM()
            KonIstem.Open()
            txtKodeVendoredit.Text = DGVHeader.Rows(e.RowIndex).Cells(0).Value
            '
            DataDetil()
            'BtnCekDetil_Click_1(sender, New System.EventArgs)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DGVHeaderEdit_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGVHeaderEdit.CellMouseClick
        Dim x As Integer
        '
        KoneksiISTEM()
        KonIstem.Open()
        '
        cmbDlvUnitedit.Items.Clear()
        Try
            txtKodeVendoredit.Text = DGVHeaderEdit.Rows(e.RowIndex).Cells(0).Value
            txtJenisedit.Text = DGVHeaderEdit.Item(2, x).Value             '
            '
            DataDetil()
            Cekdetil()
            '
            If txtJenisedit.Text = "Yarn" Then
                CariItemYarnedit()
                cmbDlvUnitedit.Items.Add("KG")
                cmbDlvUnitedit.Items.Add("LBS")
            Else
                CariItemGreyedit()
                cmbDlvUnitedit.Items.Add("MTR")
                cmbDlvUnitedit.Items.Add("YDS")
            End If
            '
            lblKode.Text = txtKodeVendoredit.Text
            lblJenis.Text = txtJenisedit.Text
            'lblNamakode.Text = DGVHeaderEdit.Item(1, x).Value
            lblNamakode.Text = DGVHeaderEdit.Rows(e.RowIndex).Cells(1).Value
            'BtnCekDetil_Click_1(sender, New System.EventArgs)
            '
            DGVDetiledit.Visible = True
            DGVDTL3.Visible = False
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub BukaDatadetil()
        KoneksiISTEM()
        KonIstem.Open()
        Try
            CMDDETIL = New SqlCommand("Select * from sl_deliv_yarn_grey_detail='" & (txtKodeVendoredit.Text) & "'", KonIstem)
            DR = CMDDETIL.ExecuteReader
            KonIstem.Close()
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub DGVHeaderEdit_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGVHeaderEdit.CellFormatting
        DGVHeaderEdit.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub BtnSAPName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSAPName.Click
        KoneksiSAP()
        KonSAP.Open()
        '
        CmdCaridata = New SqlCommand("Select CardCode,CardName from OCRD where CardCode='" & KodeVendor & "'", KonSAP)
        DR = CmdCaridata.ExecuteReader
        'KodeVendor
        If DR.HasRows Then
            NamaVendor = DR.Item("CardName")
        End If
        KonSAP.Close()
    End Sub

    Private Sub BtnItemName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnItemName.Click
        KoneksiSAP()
        KonSAP.Open()
        'DGVDetiledit.Item(0, I).Value)
        'If Editdetil = False Then
        '    CmdCaridata = New SqlCommand("Select Itemcode,Itemname,FrgnName from OITM where Itemcode = '" & (cmbGreyno.Text) & "'", KonSAP)
        'Else
        'txtKodeVendoredit
        CmdCaridata = New SqlCommand("Select Itemcode,Itemname,FrgnName from OITM where Itemcode = '" & (txtKodeVendoredit.Text) & "'", KonSAP)
        'End If
        DR = CmdCaridata.ExecuteReader
        DR.Read()
        '
        If DR.HasRows Then
            'If Editdetil = False Then
            '    txtItemName.Text = DR.Item("FrgnName")
            'Else
            Namaitem = DR.Item("FrgnName")
            'End If
        End If
    End Sub
    Private Sub cmdSimpanedit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaveedit.Click
        '
        Using KonIstem As New SqlConnection(ConStringISTEM)
            If MessageBox.Show("Yakin akan di Simpan...?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                For Each row As DataGridViewRow In DGVDetiledit.Rows
                    If Not row.IsNewRow Then
                        Kodeedit = row.Cells(0).Value.ToString()
                        Namaitemedit = row.Cells(1).Value.ToString()
                        Plandateedit = row.Cells(2).Value.ToString()
                        plandelivedit1 = row.Cells(5).Value.ToString()
                        qtyedit = row.Cells(3).Value.ToString()
                        unitedit = row.Cells(4).Value.ToString()
                    End If
                    '
                    plandelivedit = Convert.ToDateTime(plandelivedit1)
                    '
                    CekInputData()
                    '
                    If TambaheditDetil = True Then
                        InputDetilBaru()
                        '
                        SimpanHistori()
                    Else
                        'SimpanEditData()
                        KonIstem.Close()
                        UpdateDetil()
                    End If
                Next
                MessageBox.Show("Data Berhasil Disimpan", "Informasi")
            End If
        End Using
        '
        Bukakunci()
        KunciDetil()
        BtnAdd.Focus()
        '
        BtnSave.Visible = True
        BtnSaveedit.Visible = False
        BtnDeleteDetil.Enabled = True
    End Sub
    Sub CekInputData()
        ' Dim TanggalDeliv As Date
        KoneksiISTEM()
        KonIstem.Open()
        '
        'plandelivedit = Format(Plandateedit, "MM/dd/yyyy")
        ' Dim Kodeedit, Namaitemedit, qtyedit, unitedit, Plandateedit As String
        Try 'plan_month,vendor_code,yarn_grey_code,plan_deliv_date,plan_deliv_qty,plan_deliv_qty_unit,rec_sts,proc_no
            CmdCaridata = New SqlCommand("select * from sl_deliv_yarn_grey_detail where plan_month ='" & (cmbPlanMonthedit.Text) & "' and vendor_code ='" & (txtKodeVendoredit.Text) & "' and yarn_grey_code='" & (Kodeedit) & "'  and plan_deliv_date = '" & (plandelivedit) & "'", KonIstem)
            DREDIT = CmdCaridata.ExecuteReader
            DREDIT.Read()
            'KonIstem.Close()
            If DREDIT.HasRows Then
                TambaheditDetil = False
                lblKodeitem.Text = DREDIT.Item("yarn_grey_code")
                lblTgldeliv.Text = DREDIT.Item("plan_deliv_date")
                lblDlvqty.Text = DREDIT.Item("plan_deliv_qty")
                lblDlvunit.Text = DREDIT.Item("plan_deliv_qty_unit")
            Else
                TambaheditDetil = True
            End If
            KonIstem.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub InputDetilBaru()
        '
        Dim Tgledit As Date
        KoneksiISTEM()
        KonIstem.Open()
        '
        SimpanDetil = "Insert into sl_deliv_yarn_grey_detail(plan_month,vendor_code,yarn_grey_code,plan_deliv_date,plan_deliv_qty,plan_deliv_qty_unit,rec_sts,proc_no)" _
               & "values(@plan_month,@vendor_code,@yarn_grey_code,@plan_deliv_date,@plan_deliv_qty,@plan_deliv_qty_unit,@rec_sts,@proc_no)"
        CMDDETIL = New SqlCommand(SimpanDetil, KonIstem)
        '(plan_month,vendor_code,yarn_grey_code,plan_deliv_date,plan_deliv_qty,plan_deliv_qty_unit,rec_sts,proc_no)
        CMDDETIL.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
        'CMDDetil.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
        CMDDETIL.Parameters.Add(New SqlParameter("@vendor_code", SqlDbType.VarChar))
        CMDDETIL.Parameters.Add(New SqlParameter("@yarn_grey_code", SqlDbType.VarChar))
        CMDDETIL.Parameters.Add(New SqlParameter("@plan_deliv_date", SqlDbType.Date))
        CMDDETIL.Parameters.Add(New SqlParameter("@plan_deliv_qty", SqlDbType.Int))
        CMDDETIL.Parameters.Add(New SqlParameter("@plan_deliv_qty_unit", SqlDbType.TinyInt))
        CMDDETIL.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
        CMDDETIL.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
        '
        'KonIstem.Open()
        TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
        CMDDETIL.Transaction = TR
        '                '
        Try
            '
            Tgledit = Plandateedit
            'For Each row As DataGridViewRow In DGVDetiledit.Rows
            'If Not row.IsNewRow Then
            CMDDETIL.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
            'CMDDetil.Parameters("@request_version").Value = "1"
            CMDDETIL.Parameters("@vendor_code").Value = txtKodeVendoredit.Text
            CMDDETIL.Parameters("@yarn_grey_code").Value = Kodeedit   'row.Cells(0).Value.ToString
            CMDDETIL.Parameters("@plan_deliv_date").Value = Tgledit   'Convert.ToDateTime(row.Cells(2).Value.ToString)
            CMDDETIL.Parameters("@plan_deliv_qty").Value = qtyedit   '(row.Cells(3).Value.ToString)
            ' Status plan_deliv_qty_unit
            StatusDeliv_unit = unitedit   'row.Cells(4).Value.ToString
            '
            Select Case StatusDeliv_unit
                Case "KG"
                    SatuanDeliv_unit = 0
                Case "LBS"
                    SatuanDeliv_unit = 1
                Case "MTR"
                    SatuanDeliv_unit = 2
                Case "YDS"
                    SatuanDeliv_unit = 3
            End Select
            '
            CMDDETIL.Parameters("@plan_deliv_qty_unit").Value = SatuanDeliv_unit 'row.Cells(4).Value.ToString
            CMDDETIL.Parameters("@rec_sts").Value = "A"
            CMDDETIL.Parameters("@proc_no").Value = "1"
            '
            CMDDETIL.ExecuteNonQuery()
            TR.Commit()
            '  MessageBox.Show("Data Berhasil Disimpan", "Informasi")
        Catch ex As Exception
            Try
                TR.Rollback()
                MessageBox.Show(ex.Message)
            Catch rollBackEx As Exception
                MessageBox.Show(rollBackEx.Message)
            End Try
        End Try
    End Sub
    Sub UpdateDetil()
        ' ''
        KoneksiISTEM()
        KonIstem.Open()
        '            CmdCaridata = New SqlCommand("select * from sl_deliv_yarn_grey_detail where plan_month ='" & (cmbPlanMonthedit.Text) & "' and vendor_code ='" & (txtKodeVendoredit.Text) & "' and yarn_grey_code='" & (Kodeedit) & "'  and plan_deliv_date = '" & (plandelivedit) & "'", KonIstem)
        Ubahdata = "Update sl_deliv_yarn_grey_detail set  plan_month=@plan_month,vendor_code=@vendor_code,yarn_grey_code=@yarn_grey_code,plan_deliv_date=@plan_deliv_date," _
                       & " plan_deliv_qty=@plan_deliv_qty,plan_deliv_qty_unit=@plan_deliv_qty_unit,rec_sts=@rec_sts,proc_no=@proc_no where plan_month=@plan_month and vendor_code=@vendor_code and yarn_grey_code=@yarn_grey_code and plan_deliv_date=@plan_deliv_date"
        '
        CMDEDIT = New SqlCommand(Ubahdata, KonIstem)
        '
        CMDEDIT.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
        'CMDDetil.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
        CMDEDIT.Parameters.Add(New SqlParameter("@vendor_code", SqlDbType.VarChar))
        CMDEDIT.Parameters.Add(New SqlParameter("@yarn_grey_code", SqlDbType.VarChar))
        CMDEDIT.Parameters.Add(New SqlParameter("@plan_deliv_date", SqlDbType.Date))
        CMDEDIT.Parameters.Add(New SqlParameter("@plan_deliv_qty", SqlDbType.Int))
        CMDEDIT.Parameters.Add(New SqlParameter("@plan_deliv_qty_unit", SqlDbType.TinyInt))
        CMDEDIT.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
        CMDEDIT.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
        '
        'KonIstem.Open()
        TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
        CMDEDIT.Transaction = TR
        '                '
        Try
            'For Each row As DataGridViewRow In DGVDetiledit.Rows
            '    If Not row.IsNewRow Then
            CMDEDIT.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
            'CMDDetil.Parameters("@request_version").Value = "1"
            CMDEDIT.Parameters("@vendor_code").Value = txtKodeVendoredit.Text
            CMDEDIT.Parameters("@yarn_grey_code").Value = Kodeedit  'row.Cells(0).Value.ToString
            CMDEDIT.Parameters("@plan_deliv_date").Value = plandelivedit  'Convert.ToDateTime(row.Cells(2).Value.ToString)
            CMDEDIT.Parameters("@plan_deliv_qty").Value = qtyedit  '(row.Cells(3).Value.ToString)
            ' Status plan_deliv_qty_unit
            StatusDeliv_unit = unitedit  'row.Cells(4).Value.ToString
            '
            Select Case StatusDeliv_unit
                Case "KG"
                    SatuanDeliv_unit = 0
                Case "LBS"
                    SatuanDeliv_unit = 1
                Case "MTR"
                    SatuanDeliv_unit = 2
                Case "YDS"
                    SatuanDeliv_unit = 3
            End Select
            '
            CMDEDIT.Parameters("@plan_deliv_qty_unit").Value = SatuanDeliv_unit 'row.Cells(4).Value.ToString
            CMDEDIT.Parameters("@rec_sts").Value = "T"
            CMDEDIT.Parameters("@proc_no").Value = "2"
            '
            CMDEDIT.ExecuteNonQuery()
            TR.Commit()
            '  MessageBox.Show("Data Berhasil Disimpan", "Informasi")
        Catch ex As Exception
            Try
                TR.Rollback()
                MessageBox.Show(ex.Message)
            Catch rollBackEx As Exception
                MessageBox.Show(rollBackEx.Message)
            End Try
        End Try
    End Sub
    Sub UpdateDetilHistori()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '            CmdCaridata = New SqlCommand("select * from sl_deliv_yarn_grey_detail where plan_month ='" & (cmbPlanMonthedit.Text) & "' and vendor_code ='" & (txtKodeVendoredit.Text) & "' and yarn_grey_code='" & (Kodeedit) & "'  and plan_deliv_date = '" & (plandelivedit) & "'", KonIstem)
        Ubahdata = "Update sl_deliv_yarn_grey_detail_hist set  plan_month=@plan_month,vendor_code=@vendor_code,yarn_grey_code=@yarn_grey_code,plan_deliv_date=@plan_deliv_date," _
                       & " plan_deliv_qty=@plan_deliv_qty,plan_deliv_qty_unit=@plan_deliv_qty_unit,rec_sts=@rec_sts,proc_no=@proc_no where plan_month=@plan_month and vendor_code=@vendor_code and yarn_grey_code=@yarn_grey_code and plan_deliv_date=@plan_deliv_date"
        '
        CMDEDIT = New SqlCommand(Ubahdata, KonIstem)
        '
        CMDEDIT.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
        'CMDDetil.Parameters.Add(New SqlParameter("@request_version", SqlDbType.TinyInt))
        CMDEDIT.Parameters.Add(New SqlParameter("@vendor_code", SqlDbType.VarChar))
        CMDEDIT.Parameters.Add(New SqlParameter("@yarn_grey_code", SqlDbType.VarChar))
        CMDEDIT.Parameters.Add(New SqlParameter("@plan_deliv_date", SqlDbType.Date))
        CMDEDIT.Parameters.Add(New SqlParameter("@plan_deliv_qty", SqlDbType.Int))
        CMDEDIT.Parameters.Add(New SqlParameter("@plan_deliv_qty_unit", SqlDbType.TinyInt))
        CMDEDIT.Parameters.Add(New SqlParameter("@rec_sts", SqlDbType.Char))
        CMDEDIT.Parameters.Add(New SqlParameter("@proc_no", SqlDbType.TinyInt))
        '
        'KonIstem.Open()
        TR = KonIstem.BeginTransaction(IsolationLevel.ReadCommitted)
        CMDEDIT.Transaction = TR
        '
        Try
            'For Each row As DataGridViewRow In DGVDetiledit.Rows
            '    If Not row.IsNewRow Then
            CMDEDIT.Parameters("@plan_month").Value = cmbPlanMonthedit.Text
            'CMDDetil.Parameters("@request_version").Value = "1"
            CMDEDIT.Parameters("@vendor_code").Value = txtKodeVendoredit.Text
            CMDEDIT.Parameters("@yarn_grey_code").Value = Kodeedit  'row.Cells(0).Value.ToString
            CMDEDIT.Parameters("@plan_deliv_date").Value = plandelivedit  'Convert.ToDateTime(row.Cells(2).Value.ToString)
            CMDEDIT.Parameters("@plan_deliv_qty").Value = qtyedit  '(row.Cells(3).Value.ToString)
            ' Status plan_deliv_qty_unit
            StatusDeliv_unit = unitedit  'row.Cells(4).Value.ToString
            '
            Select Case StatusDeliv_unit
                Case "KG"
                    SatuanDeliv_unit = 0
                Case "LBS"
                    SatuanDeliv_unit = 1
                Case "MTR"
                    SatuanDeliv_unit = 2
                Case "YDS"
                    SatuanDeliv_unit = 3
            End Select
            '
            CMDEDIT.Parameters("@plan_deliv_qty_unit").Value = SatuanDeliv_unit 'row.Cells(4).Value.ToString
            CMDEDIT.Parameters("@rec_sts").Value = "T"
            CMDEDIT.Parameters("@proc_no").Value = "2"
            '
            CMDEDIT.ExecuteNonQuery()
            TR.Commit()
            '  MessageBox.Show("Data Berhasil Disimpan", "Informasi")
        Catch ex As Exception
            Try
                TR.Rollback()
                MessageBox.Show(ex.Message)
            Catch rollBackEx As Exception
                MessageBox.Show(rollBackEx.Message)
            End Try
        End Try
    End Sub
    Sub SimpanNewData()
        SimpanDetil = "Insert into sl_deliv_yarn_grey_detail(plan_month,vendor_code,yarn_grey_code,plan_deliv_date,plan_deliv_qty,plan_deliv_qty_unit,rec_sts,proc_no)" _
                & "values(@plan_month,@vendor_code,@yarn_grey_code,@plan_deliv_date,@plan_deliv_qty,@plan_deliv_qty_unit,@rec_sts,@proc_no)"

    End Sub
    Sub SimpanEditData()
        Ubahdata = "Update sl_deliv_yarn_grey_detail set  plan_month=@plan_month,yarn_grey_code=@yarn_grey_code,plan_deliv_date=@plan_deliv_date," _
                        & " plan_deliv_qty=@plan_deliv_qty,plan_deliv_qty_unit=@plan_deliv_qty_unit,rec_sts=@rec_sts,proc_no=@proc_no where plan_month=@plan_month and yarn_grey_code=@yarn_grey_code"
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim DTDetil,DTHeader As New DataTable
        '
        With DTHeader
            .Columns.Add("vendor_code")
            .Columns.Add("vendor_name")
            .Columns.Add("yarn_grey_flag")
            .Columns.Add("plan_month")
        End With
        'DTDetil.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, lblKode.Text)
        With DTDetil
            .Columns.Add("yarn_grey_code")
            .Columns.Add("yarn_grey_name")
            .Columns.Add("plan_deliv_date")
            .Columns.Add("plan_deliv_qty")
            .Columns.Add("plan_deliv_qty_unit")
            .Columns.Add("plan_deliv")
            .Columns.Add("plan_month")
            .Columns.Add("vendor_code")
        End With
        'DGVDetiledit
        Try
            DTDetil.Rows.Add()
            For Each row As DataGridViewRow In DGVDetiledit.Rows
                'row.Cells(0).Value.ToString()
                DTDetil.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, lblKode.Text)
                'DTSap.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value)
            Next
            '
            DTHeader.Rows.Add()
            DTHeader.Rows.Add(lblKode.Text, lblNamakode.Text, lblJenis.Text, cmbPlanMonthedit.Text)
            '
            rptDoc = New CRYarnGrey
            rptDoc.Database.Tables("DT_DELIV_DETAIL").SetDataSource(DTDetil)
            rptDoc.Database.Tables("DT_DELIV_HEADER").SetDataSource(DTHeader)
            '
            'rptDoc.SetDataSource(DTDetil)
            'rptDoc.SetDataSource(DTHeader)
            '
            frmRptPrint.CrystalReportViewer1.ReportSource = rptDoc
            frmRptPrint.ShowDialog()
            ' frmRptPrint.Dispose()
        Catch ex As Exception
            '
        End Try
        '
        'DT.Rows.Add()
    End Sub

    Private Sub BtnView2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BtnView2.Click
        Dim rptDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument
        Dim DTDetil, DTHeader As New DataTable
        '
        With DTHeader
            .Columns.Add("vendor_code")
            .Columns.Add("vendor_name")
            .Columns.Add("yarn_grey_flag")
            .Columns.Add("plan_month")
        End With
        '
        With DTDetil
            .Columns.Add("yarn_grey_code")
            .Columns.Add("yarn_grey_name")
            .Columns.Add("plan_deliv_date")
            .Columns.Add("plan_deliv_qty")
            .Columns.Add("plan_deliv_qty_unit")
            .Columns.Add("plan_deliv")
            .Columns.Add("plan_month")
            .Columns.Add("vendor_code")
        End With
        ''
        Try
            DTDetil.Rows.Add()
            For Each row As DataGridViewRow In DGVDTL3.Rows
                'row.Cells(0).Value.ToString()
                DTDetil.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(2).Value, cmbPlanMonthedit.Text, row.Cells(5).Value)
                'DTDetil.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, row.Cells(3).Value, row.Cells(4).Value, row.Cells(5).Value, row.Cells(6).Value, lblKode.Text)
            Next
            '
            DTHeader.Rows.Add()
            For Each row As DataGridViewRow In DGVHeaderEdit.Rows
                DTHeader.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, cmbPlanMonthedit.Text)
            Next
            ' DTHeader.Rows.Add(lblKode.Text, lblNamakode.Text, lblJenis.Text, cmbPlanMonthedit.Text)
            rptDoc = New CRYarnGrey
            rptDoc.Database.Tables("DT_DELIV_DETAIL").SetDataSource(DTDetil)
            rptDoc.Database.Tables("DT_DELIV_HEADER").SetDataSource(DTHeader)
            '
            'rptDoc.SetDataSource(DTDetil)
            'rptDoc.SetDataSource(DTHeader)
            '
            frmRptPrint.CrystalReportViewer1.ReportSource = rptDoc
            frmRptPrint.ShowDialog()
            ' frmRptPrint.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub BtnCekBrs_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCekBrs.Click
        ''DGVHeaderEdit.Columns(0).Width = 100
        ''DGVHeaderEdit.Columns(1).Width = 100
        ''DGVHeaderEdit.Columns(2).Width = 100
        ''
        'DGVHeaderEdit.Refresh()
        'DGVHeaderEdit.Rows.Clear()
        ''
        'For Each row As DataGridViewRow In DGVHeader.Rows
        '    If Not row.IsNewRow Then
        '        KodeVendor = row.Cells(0).Value.ToString
        '        Jenis = row.Cells(1).Value.ToString
        '        'Cek_NamaVendorSAP()
        '        '
        '        CariNamaVendor()
        '        '
        '        DGVHeaderEdit.Rows.Add(KodeVendor)
        '        '
        '        For barisatas As Integer = 0 To DGVHeaderEdit.RowCount - 1
        '            For barisbawah As Integer = barisatas + 1 To DGVHeaderEdit.RowCount - 1
        '            Next
        '        Next
        '        '
        '        DGVHeaderEdit(0, DGVHeaderEdit.RowCount - 2).Value = KodeVendor
        '        DGVHeaderEdit(1, DGVHeaderEdit.RowCount - 2).Value = NamaVendor
        '        DGVHeaderEdit(2, DGVHeaderEdit.RowCount - 2).Value = Jenis
        '        '
        '        'NamaVendor = row.Cells(2).Value.ToString
        '    End If
        'Next
        ''
    End Sub

    Private Sub BtnTmbhDtl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTmbhDtl.Click
        DGVDTL3.Refresh()
        DGVDTL3.Rows.Clear()
        '("Select yarn_grey_code as Item_Code,plan_deliv_date as Est_Delivery_Date,plan_deliv_qty as Delivery_Qty,plan_deliv_qty_unit as Delivery_Unit,vendor_code as Vendor_code from sl_deliv_yarn_grey_detail where plan_month = '" & (TxtHasilModif.Text) & "'", KonIstem)
        For Each row As DataGridViewRow In DGVDTL2.Rows
            If Not row.IsNewRow Then
                KodeItem1 = row.Cells(0).Value.ToString
                Tgldv1 = Convert.ToDateTime(row.Cells(1).Value.ToString)
                Pdvqty1 = row.Cells(2).Value.ToString
                Jenis1 = row.Cells(3).Value.ToString
                KodeVendor1 = row.Cells(4).Value.ToString
                '
                Select Case Jenis1
                    Case 0
                        Plunitdt1 = "KG"
                    Case 1
                        Plunitdt1 = "LBS"
                    Case 2
                        Plunitdt1 = "MTR"
                    Case 3
                        Plunitdt1 = "YDS"
                End Select
                '
                CariNamaItemAll()
                '
                DGVDTL3.Rows.Add(KodeItem1)
                '
                For barisatas As Integer = 0 To DGVDTL3.RowCount - 1
                    For barisbawah As Integer = barisatas + 1 To DGVDTL3.RowCount - 1
                    Next
                Next
                '
                DGVDTL3(0, DGVDTL3.RowCount - 2).Value = KodeItem1
                DGVDTL3(1, DGVDTL3.RowCount - 2).Value = Namaitem
                DGVDTL3(2, DGVDTL3.RowCount - 2).Value = Format(Tgldv1, "dd/MM/yyyy")
                DGVDTL3(3, DGVDTL3.RowCount - 2).Value = Pdvqty1
                '
                DGVDTL3(4, DGVDTL3.RowCount - 2).Value = Plunitdt1
                DGVDTL3(5, DGVDTL3.RowCount - 2).Value = KodeVendor1
                '
                'NamaVendor = row.Cells(2).Value.ToString
            End If
        Next
        '
    End Sub
End Class