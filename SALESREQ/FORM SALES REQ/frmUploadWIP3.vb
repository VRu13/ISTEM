Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Imports System.IO
Imports System.Data.OleDb
Public Class frmUploadWIP3
    '
    Dim KonEx As OleDbConnection
    Dim ContEx As OleDbDataAdapter
    Dim CMDEx As OleDbCommand
    Dim DAex As OleDbDataAdapter
    Dim DSex As DataSet
    Private Sub BtnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpload.Click
        MsgBox("Invalid User...!!! Please Check user name and password", MsgBoxStyle.Information, "Informasi")
        'Dim FileEx As OpenFileDialog = New OpenFileDialog
        ''
        'OpenFileDialog1.FileName = ""
        'OpenFileDialog1.Filter = "(*.xls)|*.xls|(*.xlsx)|*.xlsx"
        'OpenFileDialog1.ShowDialog()
        ''
        'txtFile.Text = OpenFileDialog1.FileName
        'KoneksiExcel()
        ''
        'DAex = New OleDbDataAdapter("select * from [sheet1$]", KonEx)
        'DSex = New DataSet
        ''
        'DAex.Fill(DS)
        'DGV.DataSource = DS.Tables(0)
        'DGV.ReadOnly = True
        '
    End Sub

    Sub KoneksiExcel()
        KonEx = New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" &
                    "data source='" & OpenFileDialog1.FileName & "';Extended Properties=Excel 8.0;")
    End Sub

    Private Sub BtnSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSort.Click
        Dim DataTanggal As Date
        KoneksiISTEM()
        KonIstem.Open()
        '
        DataTanggal = Format(DtpPickerawal.Value, "yyyy/MM/dd")
        DA = New SqlDataAdapter("Select * from sl_deliv_yarn_grey_detail where plan_deliv_date='" & (DataTanggal) & "'", KonIstem)
        '
        DS = New DataSet
        'plandeliv,planqty,planunit
        Try 'row.Cells(0).Value.ToString
            DA.Fill(DS)
            '
            DGV.DataSource = DS.Tables(0)
            KonIstem.Close()
            DGV.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '
            DGV.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class