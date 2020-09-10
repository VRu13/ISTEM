Public Class frmMenuUtama

    Private Sub BtnSlsEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSlsEntry.Click
        '
        Switchpanel(Menusales)
        '
        PnlLb1.Visible = True
        PnlLb2.Visible = False
        PnlLb3.Visible = False
        PnlLb4.Visible = False
        '
        'PnlUtama.Visible = False
        'PnlSalesE.Visible = True
        'PnlSalesE.BringToFront()
        'PnlWeavingE.Visible = False
        'PnlReport.Visible = False
    End Sub
   
    Private Sub BtnWvgEntry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnWvgEntry.Click
        'Label1.Visible = True
        'Label2.Visible = False
        'Label3.Visible = False
        '
        Switchpanel(Menuweaving)
        '
        PnlLb1.Visible = False
        PnlLb2.Visible = True
        PnlLb3.Visible = False
        PnlLb4.Visible = False
        '
        'PnlSalesE.Visible = False
        ''PnlSalesE.SendToBack()
        'PnlWeavingE.Visible = True
        ''PnlWeavingE.BringToFront()
        '  PnlReport.Visible = False
    End Sub

    Private Sub BtnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        'Label1.Visible = True
        'Label2.Visible = False
        'Label3.Visible = False
        '
        Switchpanel(MenuReport)
        '
        PnlLb1.Visible = False
        PnlLb2.Visible = False
        PnlLb3.Visible = True
        PnlLb4.Visible = False
        '
        'PnlSalesE.Visible = False
        'PnlWeavingE.Visible = False
        'PnlReport.Visible = True
    End Sub
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
        End
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSales_Entry_Req.ShowDialog()
        frmSales_Entry_Req.TabControl1.SelectTab(0)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSales_Delivery_Entry.ShowDialog()
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmGenerate_Plan.ShowDialog()
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmUpdGrySett.ShowDialog()
    End Sub

    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmLoomeff.ShowDialog()
    End Sub

    Private Sub BtnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHome.Click
        ''
        Panel5.Show()
        Panel5.Controls.Clear()
        '
        'PnlSalesE.Visible = False
        'PnlWeavingE.Visible = False
        'PnlReport.Visible = False
    End Sub
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmEntryReqYarn.ShowDialog()
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TSlblJam.Text = Format(TimeOfDay, "HH:mm")
    End Sub
    Private Sub frmMenuUtama_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TSlblTanggal.Text = Format(Date.Now, "yyyy/MM/dd")
    End Sub
    Private Sub BtnLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogout.Click
        BtnHome.Enabled = False
        BtnReport.Enabled = False
        BtnWvgEntry.Enabled = False
        BtnSlsEntry.Enabled = False
    End Sub

    Private Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        'frmLogin.ShowDialog()
        'BtnLogin.Text = "LogOut"
        If BtnLogin.Text = "LogOut" Then
            BtnHome.Enabled = False
            BtnReport.Enabled = False
            BtnWvgEntry.Enabled = False
            BtnSlsEntry.Enabled = False
            'frmMenuUtama.TSlbip.Text = "-"
            BtnLogin.Text = "LogIn"
            TSlbip.Text = ""
            tsLabelUser.Text = ""
            '
            Panel5.Controls.Clear()
        Else
            'BtnLogin.Text = "LogOut"
            frmLogin.txtPass.Clear()
            frmLogin.txtUser.Clear()
            frmLogin.ShowDialog()
            '
        End If
    End Sub
    Sub Switchpanel(ByVal panel As Form)
        Panel5.Controls.Clear()
        panel.TopLevel = False
        Panel5.Controls.Add(panel)
        panel.Show()
    End Sub
    Sub SwitchOFFpanel(ByVal panel As Form)
        Panel5.Controls.Clear()
        panel.TopLevel = False
        Panel5.Controls.Add(panel)
        'panel.Show()
    End Sub

    Private Sub BtnReportLoomEff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSizeBeamer.ShowDialog()
    End Sub
End Class