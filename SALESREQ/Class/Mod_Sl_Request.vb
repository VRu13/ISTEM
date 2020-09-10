Imports System.Data.SqlClient
Imports System.Configuration
Module Mod_Sl_Request
    Dim SimpanData, Ubahdata, HapusData As String
    Dim CMDSimpan As New SqlCommand
    Dim CMDHapus As New SqlCommand
    Public CMD As New SqlCommand
    Public CmdCaridata As New SqlCommand

    Sub CmdSimpanNewData() 'plan_month,plan_rev_no,request_date,plan_rev_date,send_date
        CMDSimpan.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
        'CMDSimpan.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
        '
        CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
        CMDSimpan.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
        CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))
        CMDSimpan.Parameters.Add(New SqlParameter("@send_date", SqlDbType.Date))
        '
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
    End Sub
    Sub CmdSimpanEditData()
        CMDSimpan.Parameters.Add(New SqlParameter("@plan_month", SqlDbType.VarChar))
        ' CMDSimpan.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
        '
        CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_no", SqlDbType.TinyInt))
        CMDSimpan.Parameters.Add(New SqlParameter("@request_date", SqlDbType.Date))
        CMDSimpan.Parameters.Add(New SqlParameter("@plan_rev_date", SqlDbType.Date))
        CMDSimpan.Parameters.Add(New SqlParameter("@send_date", SqlDbType.Date))
        '
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
    End Sub
   
End Module
