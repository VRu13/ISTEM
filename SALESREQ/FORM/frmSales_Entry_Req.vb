Imports System.Data.SqlClient
Imports System.Configuration

Public Class frmSales_Entry_Req
    Dim Tanggalawal, Bulanawal, Tahunawal As Integer
    Dim Bulansatu, Tahunsatu As Integer
    Dim NilaiBulansatu, NilaiBulandua, NilaiBulantiga As String
    '
    Dim Remindtoperiod1, Remindtoperiod2, Remindtoperiod3 As Date
    Dim lblRemindtoperiodawal, lblRemindtoperiod1, lblRemindtoperiod2, lblRemindtoperiod3 As String
    Dim Remindfrmperiod1, Remindfrmperiod2, Remindfrmperiod3 As Date
    Dim lblRemindfrmperiodawal, lblRemindfrmperiod1, lblRemindfrmperiod2, lblRemindfrmperiod3 As String
    '
    Dim Bulanprd1, Bulanprd2, Bulanprd3, Tahunprd2 As Date
    Dim NilaiTglakhirAwal, NilaiTglakhirprd1, NilaiTglakhirprd2, NilaiTglakhirprd3 As Date
    Dim Tanggalakhir1 As String
    '
    Dim Kon As New SqlConnection
    Dim ConString As String = ConfigurationManager.ConnectionStrings("ISTEM").ConnectionString
    Dim CMD As New SqlCommand
    Dim DA As New SqlDataAdapter
    Dim DS As New DataSet
    Dim DT As New DataTable
    Dim DR As SqlDataReader
    Dim TR As SqlTransaction

    Private Sub BtnSetPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSetPlan.Click
        Dtpickerbulan1.Value = DtpPickerawal.Value
        Dtpickerbulan2.Value = DtpPickerawal.Value
        Dtpickerbulan3.Value = DtpPickerawal.Value
        '
        NilaiBulansatu = Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "MMMM-yyyy")
        Bulanprd1 = Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "MM/yyyy")
        NilaiTglakhirprd1 = DateSerial(Year(Bulanprd1), Month(Bulanprd1) + 1, 0)
        lblRemindfrmperiod1 = "01" & "/" & Format(DateAdd(DateInterval.Month, 1, Dtpickerbulan1.Value), "MM/yyyy")
        '
        NilaiBulandua = Format(DateAdd(DateInterval.Month, 2, Dtpickerbulan2.Value), "MMMM-yyyy")
        Bulanprd2 = Format(DateAdd(DateInterval.Month, 2, Dtpickerbulan2.Value), "MM/yyyy")
        NilaiTglakhirprd2 = DateSerial(Year(Bulanprd2), Month(Bulanprd2) + 1, 0)
        lblRemindfrmperiod2 = "01" & "/" & Format(DateAdd(DateInterval.Month, 2, Dtpickerbulan2.Value), "MM/yyyy")
        '
        NilaiBulantiga = Format(DateAdd(DateInterval.Month, 3, Dtpickerbulan3.Value), "MMMM-yyyy")
        Bulanprd3 = Format(DateAdd(DateInterval.Month, 3, Dtpickerbulan3.Value), "MM/yyyy")
        NilaiTglakhirprd3 = DateSerial(Year(Bulanprd3), Month(Bulanprd3) + 1, 0)
        lblRemindfrmperiod3 = "01" & "/" & Format(DateAdd(DateInterval.Month, 3, Dtpickerbulan3.Value), "MM/yyyy")
        '
        Tanggalawal = Format(DtpPickerawal.Value, "dd")
        Tahunawal = Format(DtpPickerawal.Value.Year)
        Bulanawal = Format(DtpPickerawal.Value.Month)
        '
        If Bulanawal <= 10 Then
            lblBulanAwal.Text = ("0" & (Bulanawal))
        End If
        '
        lblPlantMonth.Text = (Tahunawal) & "-" & (lblBulanAwal.Text)
        NilaiTglakhirAwal = DateSerial(Year(DtpPickerawal.Value), Month(DtpPickerawal.Value) + 1, 0)
        '
        lblRemindtoperiodawal = Format((DtpPickerawal.Value), "dd/MM/yyy")
        lblRemindfrmperiodawal = Format((NilaiTglakhirAwal), "dd/MM/yyyy")
        '
        lblRemindtoperiod1 = Format((NilaiTglakhirprd1), "dd/MM/yyyy")
        lblRemindtoperiod2 = Format((NilaiTglakhirprd2), "dd/MM/yyyy")
        lblRemindtoperiod3 = Format((NilaiTglakhirprd3), "dd/MM/yyyy")
        Tanggalakhir1 = NilaiTglakhirAwal.Day & "-" & Format(DtpPickerawal.Value, "MMMM") & "-" & (Tahunawal)
        '
        BtnperiodAwal.Text = Tanggalawal & "-" & Tanggalakhir1
        Btnperiod1.Text = NilaiBulansatu
        Btnperiod2.Text = NilaiBulandua
        Btnperiod3.Text = NilaiBulantiga
        '
        Panel2.Enabled = True
        cmbGreyno.Focus()
        '
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Kon = New SqlConnection(ConString)
        Kon.Open()
        DA = New SqlDataAdapter("Select * From sl_grey_request", kon)
        DA.Fill(DS, "sl_grey_request")
        '
        CMD = New SqlCommand("Select [grey_no] FROM tmp_wv_fabric_analysis_master", Kon)
        DR = CMD.ExecuteReader
        Do While DR.Read
            cmbGreyno.Items.Add(DR.Item(0))
        Loop
        '
        Kon.Close()
        '
        DataGridView1.DataSource = DS.Tables("sl_grey_request")
    End Sub
    Private Sub BtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        DtpPickerawal.Focus()
    End Sub

    Private Sub txtInputAwal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInputAwal.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtInpperiod1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInpperiod1.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDlvperiod1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDlvperiod1.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtInpperiod2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInpperiod2.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDlvperiod2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDlvperiod2.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtInpperiod3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInpperiod3.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtDlvperiod3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDlvperiod3.KeyPress
        If Not (e.KeyChar >= "0" And e.KeyChar <= "9" Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnAddData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAddData.Click
        TR = Kon.BeginTransaction
        Try
            Kon = New SqlConnection(ConString)
            Kon.Open()
            Dim Simpan As String = "Insert into sl_grey_request values ('" & cmbGreyno.Text & "','" & txtInputAwal.Text & "','" & txtInpperiod1.Text & "','" & txtDlvperiod1.Text & "','" & txtInpperiod2.Text & "','" & txtDlvperiod2.Text & "','" & txtInpperiod3.Text & "','" & txtDlvperiod3.Text & "')"
            CMD = New SqlCommand(Simpan, Kon)
            '
        Catch ex As Exception

        End Try
    End Sub
    Public Sub Execurquery(ByVal Query As String)
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        Dim cmd As New SqlCommand(Query, Kon)
        '
        cmd.Parameters.AddWithValue("@plan_month", DataGridView1.Item(0, i).Value)
        cmd.Parameters.AddWithValue("@request_date", DataGridView1.Item(1, i).Value)
        cmd.Parameters.AddWithValue("@grey_no", DataGridView1.Item(2, i).Value)
        cmd.Parameters.AddWithValue("@remain_date_from", DataGridView1.Item(0, i).Value)
        cmd.Parameters.AddWithValue("@remain_date_to", DataGridView1.Item(1, i).Value)
        cmd.Parameters.AddWithValue("@remain_input_qty", DataGridView1.Item(2, i).Value)
        '
        cmd.Parameters.AddWithValue("@month1_from", DataGridView1.Item(0, i).Value)
        cmd.Parameters.AddWithValue("@month1_to", DataGridView1.Item(1, i).Value)
        cmd.Parameters.AddWithValue("@month1_deliv_qty", DataGridView1.Item(2, i).Value)
        cmd.Parameters.AddWithValue("@month1_input_qty", DataGridView1.Item(1, i).Value)
        '
        cmd.Parameters.AddWithValue("@month2_from", DataGridView1.Item(2, i).Value)
        cmd.Parameters.AddWithValue("@month2_to", DataGridView1.Item(0, i).Value)
        cmd.Parameters.AddWithValue("@month2_deliv_qty", DataGridView1.Item(1, i).Value)
        cmd.Parameters.AddWithValue("@month2_input_qty", DataGridView1.Item(2, i).Value)
        '
        cmd.Parameters.AddWithValue("@month3_from", DataGridView1.Item(2, i).Value)
        cmd.Parameters.AddWithValue("@month3_to", DataGridView1.Item(0, i).Value)
        cmd.Parameters.AddWithValue("@month3_deliv_qty", DataGridView1.Item(1, i).Value)
        cmd.Parameters.AddWithValue("@month3_input_qty", DataGridView1.Item(2, i).Value)
        '
        cmd.Parameters.AddWithValue("@rec_sts", DataGridView1.Item(2, i).Value)
        cmd.Parameters.AddWithValue("@proc_no", DataGridView1.Item(0, i).Value)
        cmd.Parameters.AddWithValue("@upd_date", DataGridView1.Item(1, i).Value)
        cmd.Parameters.AddWithValue("@upd_time", DataGridView1.Item(2, i).Value)
        cmd.Parameters.AddWithValue("@user_id", DataGridView1.Item(1, i).Value)
        cmd.Parameters.AddWithValue("@client_ip", DataGridView1.Item(2, i).Value)
        '
        Kon.Open()
        cmd.ExecuteNonQuery()
        Kon.Close()
    End Sub
End Class
