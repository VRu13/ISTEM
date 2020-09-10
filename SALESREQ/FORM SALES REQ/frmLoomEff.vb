Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data

Public Class frmLoomeff
    Dim CariPlandata, Sql, Sql1 As String
    Sub Buka_DataComboPlan()
        '
        KoneksiISTEM()
        KonIstem.Open()
        '      
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
    End Sub

    Private Sub frmRptLoomeff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Buka_DataComboPlan()
    End Sub

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Dim DSP As New DSLoomEff1 'DSSalesEntry
        Dim objRpt As New CRPrintLoomEff1 'CRPrintLoomEff 'CRSalesReq
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        Sql = "SELECT wv_loom_eff.plan_month, wv_loom_eff.grey_no, wv_fabric_analysis_master.length_gr, wv_loom_eff.loom_model, wv_loom_eff.rpm, wv_loom_eff.density, wv_loom_eff.eff, wv_loom_eff.prod_day_mtr, wv_loom_eff.prod_day_pcs,wv_fabric_analysis_master.item_category FROM wv_loom_eff INNER JOIN wv_fabric_analysis_master ON wv_loom_eff.grey_no = wv_fabric_analysis_master.grey_no where wv_loom_eff.plan_month='" & (cmbPlanMonthedit.Text) & "'  order by wv_fabric_analysis_master.item_category desc,LEFT(wv_loom_eff.grey_no,2) asc"
        '
        '
        DA = New SqlDataAdapter(Sql, KonCIM)
        DA.Fill(DS, "DTLoomEFF")
        DT = DS.Tables("DTLoomEFF")
        '
        'objRpt.SetDataSource(DS.Tables("wv_fabric_analysis_master"))
        objRpt.SetDataSource(DS.Tables("DTLoomEFF"))
        '
        frmPrintLoomEff.CrystalReportViewer1.ReportSource = objRpt
        frmPrintLoomEff.CrystalReportViewer1.Refresh()
        frmPrintLoomEff.ShowDialog()
        objRpt.Close()
        objRpt.Dispose()
        'Catch ex As Exception
        '
        'End Try
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        cmbPlanMonthedit.Text = ""
        Me.Close()

    End Sub
End Class