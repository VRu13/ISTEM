Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Imports System.IO
Imports System.Data.OleDb
Imports System.Net
Imports System.Net.Sockets


Public Class frmLogin

    Private Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        Dim User As String
        KoneksiISTEM()
        KonIstem.Open()
        '
        CMD = New SqlCommand("Select * from sales_user where user_name = '" & (txtUser.Text) & "' and user_password ='" & (txtPass.Text) & "'", KonIstem)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            'SortData()
            'DR.Item("upd_date")
            User = DR.Item("user_id")
            MsgBox("Berhasil Login", MsgBoxStyle.Information, "Informasi")
            frmMenuUtama.BtnLogin.Text = "LogOut"
            frmMenuUtama.tsLabelUser.Text = User
            frmMenuUtama.TSlbip.Text = lblIp.Text
            frmMenuUtama.BtnHome.Enabled = True
            frmMenuUtama.BtnReport.Enabled = True
            frmMenuUtama.BtnWvgEntry.Enabled = True
            frmMenuUtama.BtnSlsEntry.Enabled = True

            'frmMenuUtama.ShowDialog()
            Me.Close()
        Else
            MsgBox("Invalid User...!!! Please Check user name and password", MsgBoxStyle.Information, "Informasi")
            txtPass.Clear()
            txtUser.Clear()
            'Bersihtext()
            'PnlEntry.Enabled = True
            'cmbVendor.Focus()
        End If
        '
        KonIstem.Close()
    End Sub
    Sub GetIp()
        Dim StrHost As String
        Dim StrIP As String
        '
        StrHost = System.Net.Dns.GetHostName
        StrIP = System.Net.Dns.GetHostByName(StrHost).AddressList(0).ToString
        '
        lblIp.Text = StrIP
        '
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        Close()
    End Sub

    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetIp()
    End Sub
End Class