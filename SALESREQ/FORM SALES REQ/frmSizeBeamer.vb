Imports System.Data.SqlClient
Imports System.Configuration
Imports System.ComponentModel
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data
Public Class frmSizeBeamer
    Dim CariPlandata, Sql, Sql1, Sql2 As String

    Private Sub BtnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Dim DSP As New DSSizerbeamer 'DSSalesEntry
        Dim objRpt As New CRMainSizeBeamer 'CRSalesReq
        Dim DTPrepMachineS, DTPrepMachineB, DTHeaderPlan As New DataTable
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        BukaPMSizer()
        BukaPMBeamer()
        '
        Sql = "SELECT wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, " & vbCrLf & _
        "wv_prod_plan_detail3.remain_period1_mtr, wv_prod_plan_detail3.month1_period1_pcs, wv_prod_plan_detail3.month1_period1_mtr," & vbCrLf & _
        "wv_prod_plan_detail3.month2_period1_pcs, wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs, wv_prod_plan_header.plan_month AS Expr2," & vbCrLf & _
        "wv_prod_plan_header.month1_work_day, wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day," & vbCrLf & _
        "wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, " & vbCrLf & _
        "wv_prod_plan_header.month1_period1_from, wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, " & vbCrLf & _
        "wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, wv_prod_plan_header.month2_period2_from, " & vbCrLf & _
        "wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, wv_prod_plan_header.month3_period2_to, wv_prod_plan_header.remain_work_day, " & vbCrLf & _
        "wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month1_period2_mtr, " & vbCrLf & _
        "wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, wv_fabric_analysis_master.length_gr, " & vbCrLf & _
        "wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F," & vbCrLf & _
       "CASE WHEN (wv_fabric_analysis_master.sizer_F) = 1 THEN 'S' WHEN (wv_fabric_analysis_master.sizer_F) <> 1 THEN 'B' END AS FlagType " & vbCrLf & _
       "FROM wv_prod_plan_detail3 INNER JOIN wv_prod_plan_header ON wv_prod_plan_detail3.plan_month = wv_prod_plan_header.plan_month INNER JOIN " & vbCrLf & _
       "wv_fabric_analysis_master ON wv_prod_plan_detail3.grey_no = wv_fabric_analysis_master.grey_no CROSS JOIN wv_prep_machine_master " & vbCrLf & _
       "where wv_prod_plan_header.plan_month ='" & (cmbPlanMonthedit.Text) & "'" & vbCrLf & _
     "GROUP BY wv_prod_plan_header.plan_month, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, wv_prod_plan_header.remain_work_day, wv_prod_plan_header.month1_work_day,  " & vbCrLf & _
     "wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day, wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.month1_period1_from, " & vbCrLf & _
     "wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, " & vbCrLf & _
     "wv_prod_plan_header.month2_period2_from, wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, " & vbCrLf & _
     "wv_prod_plan_header.month3_period2_to, wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, wv_prod_plan_detail3.month1_period1_pcs, " & vbCrLf & _
     "wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.remain_period1_mtr, " & vbCrLf & _
     "wv_prod_plan_detail3.month1_period2_mtr, wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, " & vbCrLf & _
     "wv_fabric_analysis_master.length_gr, wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F, wv_prod_plan_detail3.month1_period1_mtr, wv_prod_plan_detail3.month2_period1_pcs, " & vbCrLf & _
     "wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs"
        'Sizer
        With DTPrepMachineS
            .Columns.Add("prep_mc_no")
            .Columns.Add("prep_mc_type")
            .Columns.Add("prep_mc_capacity")
            .Columns.Add("plan_month")
        End With
        'Sizer
        DTPrepMachineS.Rows.Add()
        For Each row As DataGridViewRow In DGVS.Rows
            DTPrepMachineS.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, cmbPlanMonthedit.Text)
            '
        Next
        '
        'Beamer
        With DTPrepMachineB
            .Columns.Add("prep_mc_no")
            .Columns.Add("prep_mc_type")
            .Columns.Add("prep_mc_capacity")
            .Columns.Add("plan_month")
        End With
        '
        DTPrepMachineB.Rows.Add()
        For Each row As DataGridViewRow In DGVB.Rows
            DTPrepMachineB.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, cmbPlanMonthedit.Text)
        Next
        '
        DA = New SqlDataAdapter(Sql, KonCIM)
        DA.Fill(DS, "DTSizerBeamer")
        DT = DS.Tables("DTSizerBeamer")
        KonCIM.Close()
        '
        'Header Plan Month
        With DTHeaderPlan
            .Columns.Add("plan_month")
        End With
        '
        DTHeaderPlan.Rows.Add()
        'For Each row As DataGridViewRow In DGVB.Rows
        DTHeaderPlan.Rows.Add(cmbPlanMonthedit.Text)
        'Next
        '
        objRpt.Database.Tables("DTHeaderPlan").SetDataSource(DTHeaderPlan)
        '
        objRpt.SetDataSource(DS.Tables("DTSizerBeamer"))
        objRpt.Database.Tables("DTPrepMachineS").SetDataSource(DTPrepMachineS)
        objRpt.Database.Tables("DTPrepMachineB").SetDataSource(DTPrepMachineB)
        'objRpt.SetDataSource(DS1.Tables("DSSizer1"))
        '
        frmPrintSizeBeamer.CrystalReportViewer1.ReportSource = objRpt
        frmPrintSizeBeamer.CrystalReportViewer1.Refresh()
        frmPrintSizeBeamer.ShowDialog()
        '
        objRpt.Close()
        objRpt.Dispose()
        KonCIM.Dispose()
        '
        DT.Clear()

        'Catch ex As Exception
        '
    End Sub
    Sub BukadataSizer()
        ' '
        ' KoneksiCIM()
        ' KonCIM.Open()
        ' '
        ' Sql = "Select wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, " & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period1_pcs,wv_prod_plan_detail3.remain_period1_mtr, " & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period1_pcs, wv_prod_plan_detail3.month1_period1_mtr, wv_prod_plan_detail3.month2_period1_pcs, " & vbCrLf & _
        '"wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs, wv_prod_plan_header.plan_month AS Expr2, " & vbCrLf & _
        '"wv_prod_plan_header.month1_work_day, wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day, wv_prod_plan_header.remain_period1_from, " & vbCrLf & _
        ' "wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, wv_prod_plan_header.month1_period1_from, wv_prod_plan_header.month1_period1_to," & vbCrLf & _
        '"wv_prod_plan_header.month1_period2_from, wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, wv_prod_plan_header.month2_period2_from," & vbCrLf & _
        '"wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, wv_prod_plan_header.month3_period2_to," & vbCrLf & _
        ' "wv_prod_plan_header.remain_work_day, wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.month1_period2_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period2_mtr, wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr," & vbCrLf & _
        ' "wv_fabric_analysis_master.length_gr, wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F " & vbCrLf & _
        '"FROM wv_prod_plan_detail3 INNER JOIN " & vbCrLf & _
        '"wv_prod_plan_header ON wv_prod_plan_detail3.plan_month = wv_prod_plan_header.plan_month INNER JOIN" & vbCrLf & _
        '"wv_fabric_analysis_master ON wv_prod_plan_detail3.grey_no = wv_fabric_analysis_master.grey_no  " & vbCrLf & _
        '"where wv_prod_plan_header.plan_month ='" & (cmbPlanMonthedit.Text) & "' AND wv_fabric_analysis_master.sizer_F='1'" & vbCrLf & _
        '"Group BY wv_prod_plan_header.plan_month, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, " & vbCrLf & _
        '"wv_prod_plan_header.remain_work_day, wv_prod_plan_header.month1_work_day, wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day," & vbCrLf & _
        ' "wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to," & vbCrLf & _
        '"wv_prod_plan_header.month1_period1_from, wv_prod_plan_header.month1_period1_to," & vbCrLf & _
        '"wv_prod_plan_header.month1_period2_from, wv_prod_plan_header.month1_period2_to," & vbCrLf & _
        '"wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to," & vbCrLf & _
        '"wv_prod_plan_header.month2_period2_from, wv_prod_plan_header.month2_period2_to," & vbCrLf & _
        '"wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to," & vbCrLf & _
        '"wv_prod_plan_header.month3_period2_from, wv_prod_plan_header.month3_period2_to," & vbCrLf & _
        '"wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model," & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period1_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period1_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period2_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month2_period2_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month3_period2_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month2_period2_mtr," & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period1_mtr," & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period2_mtr," & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period2_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period2_mtr," & vbCrLf & _
        '"wv_prod_plan_detail3.month3_period2_mtr," & vbCrLf & _
        '"wv_prod_plan_detail3.month3_period1_mtr," & vbCrLf & _
        '"wv_fabric_analysis_master.length_gr," & vbCrLf & _
        '"wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F," & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period1_mtr, wv_prod_plan_detail3.month2_period1_pcs, wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs"
        ' DA = New SqlDataAdapter(Sql, KonCIM)
        ' DS = New DataSet
        ' DA.Fill(DS)
        ' '
        ' DGV.DataSource = DS.Tables(0)
        ' KonCIM.Close()
        ' '
    End Sub
    Sub BukadataBeamer()
        ' '
        ' KoneksiCIM()
        ' KonCIM.Open()
        ' '
        ' Sql = "Select wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, " & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period1_pcs,wv_prod_plan_detail3.remain_period1_mtr, " & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period1_pcs, wv_prod_plan_detail3.month1_period1_mtr, wv_prod_plan_detail3.month2_period1_pcs, " & vbCrLf & _
        '"wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs, wv_prod_plan_header.plan_month AS Expr2, " & vbCrLf & _
        '"wv_prod_plan_header.month1_work_day, wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day, wv_prod_plan_header.remain_period1_from, " & vbCrLf & _
        ' "wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, wv_prod_plan_header.month1_period1_from, wv_prod_plan_header.month1_period1_to," & vbCrLf & _
        '"wv_prod_plan_header.month1_period2_from, wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, wv_prod_plan_header.month2_period2_from," & vbCrLf & _
        '"wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, wv_prod_plan_header.month3_period2_to," & vbCrLf & _
        ' "wv_prod_plan_header.remain_work_day, wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.month1_period2_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period2_mtr, wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr," & vbCrLf & _
        ' "wv_fabric_analysis_master.length_gr, wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F " & vbCrLf & _
        '"FROM wv_prod_plan_detail3 INNER JOIN " & vbCrLf & _
        '"wv_prod_plan_header ON wv_prod_plan_detail3.plan_month = wv_prod_plan_header.plan_month INNER JOIN" & vbCrLf & _
        '"wv_fabric_analysis_master ON wv_prod_plan_detail3.grey_no = wv_fabric_analysis_master.grey_no  " & vbCrLf & _
        '"where wv_prod_plan_header.plan_month ='" & (cmbPlanMonthedit.Text) & "' AND wv_fabric_analysis_master.sizer_F<>'1'" & vbCrLf & _
        '"Group BY wv_prod_plan_header.plan_month, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, " & vbCrLf & _
        '"wv_prod_plan_header.remain_work_day, wv_prod_plan_header.month1_work_day, wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day," & vbCrLf & _
        ' "wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to," & vbCrLf & _
        '"wv_prod_plan_header.month1_period1_from, wv_prod_plan_header.month1_period1_to," & vbCrLf & _
        '"wv_prod_plan_header.month1_period2_from, wv_prod_plan_header.month1_period2_to," & vbCrLf & _
        '"wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to," & vbCrLf & _
        '"wv_prod_plan_header.month2_period2_from, wv_prod_plan_header.month2_period2_to," & vbCrLf & _
        '"wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to," & vbCrLf & _
        '"wv_prod_plan_header.month3_period2_from, wv_prod_plan_header.month3_period2_to," & vbCrLf & _
        '"wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model," & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period1_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period1_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period2_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month2_period2_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month3_period2_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.month2_period2_mtr," & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period1_mtr," & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period2_mtr," & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period2_pcs," & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period2_mtr," & vbCrLf & _
        '"wv_prod_plan_detail3.month3_period2_mtr," & vbCrLf & _
        '"wv_prod_plan_detail3.month3_period1_mtr," & vbCrLf & _
        '"wv_fabric_analysis_master.length_gr," & vbCrLf & _
        '"wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F," & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period1_mtr, wv_prod_plan_detail3.month2_period1_pcs, wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs"
        ' DA = New SqlDataAdapter(Sql, KonCIM)
        ' DS = New DataSet
        ' DA.Fill(DS)
        ' '
        ' DGVS.DataSource = DS.Tables(0)
        ' KonCIM.Close()
        '
    End Sub

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
    Private Sub frmSizeBeamer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Buka_DataComboPlan()
    End Sub

    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancel.Click
        DGVS.Refresh()
        DGVB.Refresh()
        DGVS.DataSource = Nothing
        DGVB.DataSource = Nothing
        '
        cmbPlanMonthedit.Text = ""
        DGVS.Rows.Clear()
        DGVB.Rows.Clear()
        '
        Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DSP As New DSSizerbeamer 'DSSizerbeamer 'DSSalesEntry
        Dim objRpt As New CRSizer1 'CRSalesReq
        Dim DTPrepMachine As New DataTable
        '
        KoneksiCIM()
        KonCIM.Open()
        ''
        'DA1 = New SqlDataAdapter("select prep_mc_no,prep_mc_type ,prep_mc_capacity from wv_prep_machine_master where prep_mc_type='S'", KonCIM)
        'DS1 = New DataSet
        ''
        'DA1.Fill(DS1)
        ''
        'DGVS.DataSource = DS1.Tables(0)
        ''
        'KonIstem.Close()
        'DGVS.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' ''
        'DGVS.Columns(0).Width = 50
        'DGVS.Columns(1).Width = 50
        'DGVS.Columns(2).Width = 50
        ''
        'DGVS.ReadOnly = True
        ''
        'With DTPrepMachine
        '    .Columns.Add("prep_mc_no")
        '    .Columns.Add("prep_mc_type")
        '    .Columns.Add("prep_mc_capacity")
        '    .Columns.Add("plan_month")
        'End With
        ''
        'DTPrepMachine.Rows.Add()
        'For Each row As DataGridViewRow In DGVS.Rows
        '    DTPrepMachine.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, cmbPlanMonthedit.Text)
        '    '
        'Next
        'BukaPMSizer()
        '
        Sql = "SELECT wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, " & vbCrLf & _
          "wv_prod_plan_detail3.remain_period1_mtr, wv_prod_plan_detail3.month1_period1_pcs, wv_prod_plan_detail3.month1_period1_mtr," & vbCrLf & _
          "wv_prod_plan_detail3.month2_period1_pcs, wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs, wv_prod_plan_header.plan_month AS Expr2," & vbCrLf & _
        "wv_prod_plan_header.month1_work_day, wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day," & vbCrLf & _
        "wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, " & vbCrLf & _
        "wv_prod_plan_header.month1_period1_from, wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, " & vbCrLf & _
        "wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, wv_prod_plan_header.month2_period2_from, " & vbCrLf & _
        "wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, wv_prod_plan_header.month3_period2_to, wv_prod_plan_header.remain_work_day, " & vbCrLf & _
        "wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month1_period2_mtr, " & vbCrLf & _
        "wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, wv_fabric_analysis_master.length_gr, " & vbCrLf & _
        "wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F," & vbCrLf & _
       "CASE WHEN (wv_fabric_analysis_master.sizer_F) = 1 THEN 'S' WHEN (wv_fabric_analysis_master.sizer_F) <> 1 THEN 'B' END AS FlagType " & vbCrLf & _
       "FROM wv_prod_plan_detail3 INNER JOIN wv_prod_plan_header ON wv_prod_plan_detail3.plan_month = wv_prod_plan_header.plan_month INNER JOIN " & vbCrLf & _
       "wv_fabric_analysis_master ON wv_prod_plan_detail3.grey_no = wv_fabric_analysis_master.grey_no CROSS JOIN wv_prep_machine_master " & vbCrLf & _
       "where wv_prod_plan_header.plan_month ='" & (cmbPlanMonthedit.Text) & "' and wv_fabric_analysis_master.sizer_F='1'" & vbCrLf & _
     "GROUP BY wv_prod_plan_header.plan_month, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, wv_prod_plan_header.remain_work_day, wv_prod_plan_header.month1_work_day,  " & vbCrLf & _
     "wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day, wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.month1_period1_from, " & vbCrLf & _
     "wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, " & vbCrLf & _
     "wv_prod_plan_header.month2_period2_from, wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, " & vbCrLf & _
     "wv_prod_plan_header.month3_period2_to, wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, wv_prod_plan_detail3.month1_period1_pcs, " & vbCrLf & _
     "wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.remain_period1_mtr, " & vbCrLf & _
     "wv_prod_plan_detail3.month1_period2_mtr, wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, " & vbCrLf & _
     "wv_fabric_analysis_master.length_gr, wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F, wv_prod_plan_detail3.month1_period1_mtr, wv_prod_plan_detail3.month2_period1_pcs, " & vbCrLf & _
     "wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs"
        '
        '  '
        DA = New SqlDataAdapter(Sql, KonCIM)
        DA.Fill(DS, "DTSizerBeamer")
        DT = DS.Tables("DTSizerBeamer")
        '
        objRpt.SetDataSource(DS.Tables("DTSizerBeamer"))
        'objRpt.SetDataSource(DS1.Tables("DSSizer1"))
        '
        'DA = New SqlDataAdapter(Sql, KonCIM)
        'DA.Fill(DS, "DSSizer")
        'DT = DS.Tables("DSSizer")
        '
        '
        ' objRpt.SetDataSource(DS.Tables("DSSizer"))
        'objRpt.SetDataSource(DS1.Tables("DTPrepMachine"))
        'objRpt.Database.Tables("DTPrepMachine").SetDataSource(DTPrepMachine)
        '
        frmPrintSizer.CrystalReportViewer1.ReportSource = objRpt
        frmPrintSizer.CrystalReportViewer1.Refresh()
        frmPrintSizer.ShowDialog()
        '
        objRpt.Close()
        objRpt.Dispose()
        KonCIM.Close()
        'Catch ex As Exception
        '
    End Sub
    Sub BukaPMSizer()
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        'DA = New SqlDataAdapter("Select vendor_code,Case when yarn_grey_flag='0' Then 'Yarn' else 'Grey' end As Jenis from sl_deliv_yarn_grey_Header where plan_month= '" & (TxtHasilModif.Text) & "'", KonIstem)
        DA1 = New SqlDataAdapter("select prep_mc_no,prep_mc_type ,prep_mc_capacity from wv_prep_machine_master where prep_mc_type='S'", KonCIM)
        DS1 = New DataSet
        '
        Try
            DA1.Fill(DS1)
            '
            DGVS.DataSource = DS1.Tables(0)
            '
            KonIstem.Close()
            DGVS.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ''
            DGVS.Columns(0).Width = 50
            DGVS.Columns(1).Width = 50
            DGVS.Columns(2).Width = 50
            '
            DGVS.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub BukaPMBeamer()
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        DA2 = New SqlDataAdapter("select prep_mc_no,prep_mc_type ,prep_mc_capacity from wv_prep_machine_master where prep_mc_type='B'", KonCIM)
        DS2 = New DataSet
        '
        Try
            DA2.Fill(DS2)
            '
            DGVB.DataSource = DS2.Tables(0)
            '
            KonIstem.Close()
            DGVB.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            ''
            DGVB.Columns(0).Width = 50
            DGVB.Columns(1).Width = 50
            DGVB.Columns(2).Width = 50
            '
            DGVB.ReadOnly = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'BukadataSizer()
        'BukadataBeamer()
        Dim DSP As New DSSizerbeamer 'DSSalesEntry
        Dim objRpt As New CRBeamer 'CRSalesReq
        Dim DTPrepMachine As New DataTable
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        ''DA = New SqlDataAdapter("Select vendor_code,Case when yarn_grey_flag='0' Then 'Yarn' else 'Grey' end As Jenis from sl_deliv_yarn_grey_Header where plan_month= '" & (TxtHasilModif.Text) & "'", KonIstem)
        'DA1 = New SqlDataAdapter("select prep_mc_no,prep_mc_type ,prep_mc_capacity from wv_prep_machine_master where prep_mc_type='B'", KonCIM)
        'DS1 = New DataSet
        ''
        'DA1.Fill(DS1)
        ''
        'DGVB.DataSource = DS1.Tables(0)
        ''
        'KonIstem.Close()
        'DGVB.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        ' ''
        'DGVB.Columns(0).Width = 50
        'DGVB.Columns(1).Width = 50
        'DGVB.Columns(2).Width = 50
        ''
        'DGVB.ReadOnly = True
        ''
        'With DTPrepMachine
        '    .Columns.Add("prep_mc_no")
        '    .Columns.Add("prep_mc_type")
        '    .Columns.Add("prep_mc_capacity")
        '    .Columns.Add("plan_month")
        'End With
        ''
        'DTPrepMachine.Rows.Add()
        'For Each row As DataGridViewRow In DGVB.Rows
        '    DTPrepMachine.Rows.Add(row.Cells(0).Value, row.Cells(1).Value, row.Cells(2).Value, cmbPlanMonthedit.Text)
        '    '
        'Next
        ''
        'Sql = "SELECT wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, " & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period1_mtr, wv_prod_plan_detail3.month1_period1_pcs, wv_prod_plan_detail3.month1_period1_mtr, " & vbCrLf & _
        '"wv_prod_plan_detail3.month2_period1_pcs, wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs, wv_prod_plan_header.plan_month AS Expr2, " & vbCrLf & _
        '"wv_prod_plan_header.month1_work_day, wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day, " & vbCrLf & _
        ' "wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, " & vbCrLf & _
        '"wv_prod_plan_header.month1_period1_from, wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, " & vbCrLf & _
        '"wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, wv_prod_plan_header.month2_period2_from, " & vbCrLf & _
        '"wv_prod_plan_header.month2_period2_to,wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, wv_prod_plan_header.month3_period2_to, wv_prod_plan_header.remain_work_day, " & vbCrLf & _
        '"wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month1_period2_mtr, " & vbCrLf & _
        '"wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, wv_fabric_analysis_master.length_gr, " & vbCrLf & _
        '" wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F, " & vbCrLf & _
        '"CASE WHEN (wv_fabric_analysis_master.sizer_F) = 1 THEN 'S01' WHEN (wv_fabric_analysis_master.sizer_F) <> 1 THEN 'B01' END AS FlagID, " & vbCrLf & _
        '"CASE WHEN (wv_fabric_analysis_master.sizer_F) = 1 THEN 'S' WHEN (wv_fabric_analysis_master.sizer_F) <> 1 THEN 'B' END AS FlagType, " & vbCrLf & _
        '"wv_prep_machine_master.prep_mc_type, wv_prep_machine_master.prep_mc_capacity" & vbCrLf & _
        '"FROM wv_prod_plan_detail3 INNER JOIN wv_prod_plan_header ON wv_prod_plan_detail3.plan_month = wv_prod_plan_header.plan_month INNER JOIN " & vbCrLf & _
        '"wv_fabric_analysis_master ON wv_prod_plan_detail3.grey_no = wv_fabric_analysis_master.grey_no CROSS JOIN wv_prep_machine_master " & vbCrLf & _
        '"where wv_prod_plan_header.plan_month ='" & (cmbPlanMonthedit.Text) & "'" & vbCrLf & _
        '"GROUP BY wv_prod_plan_header.plan_month, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, wv_prod_plan_header.remain_work_day, wv_prod_plan_header.month1_work_day, " & vbCrLf & _
        '"wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day, wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.month1_period1_from, " & vbCrLf & _
        '"wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to,  " & vbCrLf & _
        '"wv_prod_plan_header.month2_period2_from, wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, " & vbCrLf & _
        '"wv_prod_plan_header.month3_period2_to, wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, wv_prod_plan_detail3.month1_period1_pcs, " & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.remain_period1_mtr, " & vbCrLf & _
        '"wv_prod_plan_detail3.month1_period2_mtr, wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, " & vbCrLf & _
        '"wv_fabric_analysis_master.length_gr, wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F, wv_prod_plan_detail3.month1_period1_mtr, wv_prod_plan_detail3.month2_period1_pcs, " & vbCrLf & _
        '"wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs, wv_prep_machine_master.prep_mc_type, wv_prep_machine_master.prep_mc_capacity "
        ''
        Sql = "SELECT wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, " & vbCrLf & _
         "wv_prod_plan_detail3.remain_period1_mtr, wv_prod_plan_detail3.month1_period1_pcs, wv_prod_plan_detail3.month1_period1_mtr," & vbCrLf & _
         "wv_prod_plan_detail3.month2_period1_pcs, wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs, wv_prod_plan_header.plan_month AS Expr2," & vbCrLf & _
         "wv_prod_plan_header.month1_work_day, wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day," & vbCrLf & _
         "wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, " & vbCrLf & _
         "wv_prod_plan_header.month1_period1_from, wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, " & vbCrLf & _
         "wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, wv_prod_plan_header.month2_period2_from, " & vbCrLf & _
         "wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, wv_prod_plan_header.month3_period2_to, wv_prod_plan_header.remain_work_day, " & vbCrLf & _
         "wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month1_period2_mtr, " & vbCrLf & _
         "wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, wv_fabric_analysis_master.length_gr, " & vbCrLf & _
         "wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F," & vbCrLf & _
        "CASE WHEN (wv_fabric_analysis_master.sizer_F) = 1 THEN 'S' WHEN (wv_fabric_analysis_master.sizer_F) <> 1 THEN 'B' END AS FlagType " & vbCrLf & _
        "FROM wv_prod_plan_detail3 INNER JOIN wv_prod_plan_header ON wv_prod_plan_detail3.plan_month = wv_prod_plan_header.plan_month INNER JOIN " & vbCrLf & _
        "wv_fabric_analysis_master ON wv_prod_plan_detail3.grey_no = wv_fabric_analysis_master.grey_no " & vbCrLf & _
        "where wv_prod_plan_header.plan_month ='" & (cmbPlanMonthedit.Text) & "'AND wv_fabric_analysis_master.sizer_F<>'1'" & vbCrLf & _
        "GROUP BY wv_prod_plan_header.plan_month, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, wv_prod_plan_header.remain_work_day, wv_prod_plan_header.month1_work_day,  " & vbCrLf & _
        "wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day, wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.month1_period1_from, " & vbCrLf & _
        "wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, " & vbCrLf & _
        "wv_prod_plan_header.month2_period2_from, wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, " & vbCrLf & _
        "wv_prod_plan_header.month3_period2_to, wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, wv_prod_plan_detail3.month1_period1_pcs, " & vbCrLf & _
        "wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.remain_period1_mtr, " & vbCrLf & _
        "wv_prod_plan_detail3.month1_period2_mtr, wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, " & vbCrLf & _
        "wv_fabric_analysis_master.length_gr, wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F, wv_prod_plan_detail3.month1_period1_mtr, wv_prod_plan_detail3.month2_period1_pcs, " & vbCrLf & _
        "wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs"
        '
        DA = New SqlDataAdapter(Sql, KonCIM)
        DA.Fill(DS, "DSBeamer1")
        DT = DS.Tables("DSBeamer1")
        KonCIM.Close()
        '
        '
        objRpt.SetDataSource(DS.Tables("DSBeamer1"))
        'objRpt.Database.Tables("DTPrepMachine").SetDataSource(DTPrepMachine)
        '
        frmBeamer.CrystalReportViewer1.ReportSource = objRpt
        frmBeamer.CrystalReportViewer1.Refresh()
        frmBeamer.ShowDialog()
        '
        objRpt.Close()
        objRpt.Dispose()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim DSP As New DSSizerbeamer 'DSSalesEntry
        Dim objRpt As New CRMainSB 'CRSalesReq
        Dim DTPrepMachineS, DTPrepMachineB, DTHeaderPlan As New DataTable
        '
        KoneksiCIM()
        KonCIM.Open()
        '
        BukaPMSizer()
        BukaPMBeamer()
        '
        ''
        'Dim DSP As New DSSizerbeamer 'DSSalesEntry
        'Dim objRpt As New CRMainSB 'CRSalesReq
        ''
        'KoneksiCIM()
        'KonCIM.Open()
        '
        'Sql = "SELECT wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, " & vbCrLf & _
        '  "wv_prod_plan_detail3.remain_period1_mtr, wv_prod_plan_detail3.month1_period1_pcs, wv_prod_plan_detail3.month1_period1_mtr," & vbCrLf & _
        '  "wv_prod_plan_detail3.month2_period1_pcs, wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs, wv_prod_plan_header.plan_month AS Expr2," & vbCrLf & _
        '  "wv_prod_plan_header.month1_work_day, wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day," & vbCrLf & _
        '  "wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, " & vbCrLf & _
        '  "wv_prod_plan_header.month1_period1_from, wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, " & vbCrLf & _
        '  "wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, wv_prod_plan_header.month2_period2_from, " & vbCrLf & _
        '  "wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, wv_prod_plan_header.month3_period2_to, wv_prod_plan_header.remain_work_day, " & vbCrLf & _
        '  "wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month1_period2_mtr, " & vbCrLf & _
        '  "wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, wv_fabric_analysis_master.length_gr, " & vbCrLf & _
        '  "wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F," & vbCrLf & _
        ' "CASE WHEN (wv_fabric_analysis_master.sizer_F) = 1 THEN 'S' WHEN (wv_fabric_analysis_master.sizer_F) <> 1 THEN 'B' END AS FlagType " & vbCrLf & _
        ' "FROM wv_prod_plan_detail3 INNER JOIN wv_prod_plan_header ON wv_prod_plan_detail3.plan_month = wv_prod_plan_header.plan_month INNER JOIN " & vbCrLf & _
        ' "wv_fabric_analysis_master ON wv_prod_plan_detail3.grey_no = wv_fabric_analysis_master.grey_no " & vbCrLf & _
        ' "where wv_prod_plan_header.plan_month ='" & (cmbPlanMonthedit.Text) & "'AND wv_fabric_analysis_master.sizer_F='1'" & vbCrLf & _
        ' "GROUP BY wv_prod_plan_header.plan_month, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, wv_prod_plan_header.remain_work_day, wv_prod_plan_header.month1_work_day,  " & vbCrLf & _
        ' "wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day, wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.month1_period1_from, " & vbCrLf & _
        ' "wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, " & vbCrLf & _
        ' "wv_prod_plan_header.month2_period2_from, wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, " & vbCrLf & _
        ' "wv_prod_plan_header.month3_period2_to, wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, wv_prod_plan_detail3.month1_period1_pcs, " & vbCrLf & _
        ' "wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.remain_period1_mtr, " & vbCrLf & _
        ' "wv_prod_plan_detail3.month1_period2_mtr, wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, " & vbCrLf & _
        ' "wv_fabric_analysis_master.length_gr, wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F, wv_prod_plan_detail3.month1_period1_mtr, wv_prod_plan_detail3.month2_period1_pcs, " & vbCrLf & _
        ' "wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs"
        ''
        'DA = New SqlDataAdapter(Sql, KonCIM)
        'DA.Fill(DS, "DSSizer1")
        'DT = DS.Tables("DSSizer1")
        ''Beamer
        '
        Sql1 = "SELECT wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, " & vbCrLf & _
           "wv_prod_plan_detail3.remain_period1_mtr, wv_prod_plan_detail3.month1_period1_pcs, wv_prod_plan_detail3.month1_period1_mtr," & vbCrLf & _
           "wv_prod_plan_detail3.month2_period1_pcs, wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs, wv_prod_plan_header.plan_month AS Expr2," & vbCrLf & _
           "wv_prod_plan_header.month1_work_day, wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day," & vbCrLf & _
           "wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, " & vbCrLf & _
           "wv_prod_plan_header.month1_period1_from, wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, " & vbCrLf & _
           "wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, wv_prod_plan_header.month2_period2_from, " & vbCrLf & _
           "wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, wv_prod_plan_header.month3_period2_to, wv_prod_plan_header.remain_work_day, " & vbCrLf & _
           "wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month1_period2_mtr, " & vbCrLf & _
           "wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, wv_fabric_analysis_master.length_gr, " & vbCrLf & _
           "wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F," & vbCrLf & _
          "CASE WHEN (wv_fabric_analysis_master.sizer_F) = 1 THEN 'S' WHEN (wv_fabric_analysis_master.sizer_F) <> 1 THEN 'B' END AS FlagType " & vbCrLf & _
          "FROM wv_prod_plan_detail3 INNER JOIN wv_prod_plan_header ON wv_prod_plan_detail3.plan_month = wv_prod_plan_header.plan_month INNER JOIN " & vbCrLf & _
          "wv_fabric_analysis_master ON wv_prod_plan_detail3.grey_no = wv_fabric_analysis_master.grey_no " & vbCrLf & _
          "where wv_prod_plan_header.plan_month ='" & (cmbPlanMonthedit.Text) & "'AND wv_fabric_analysis_master.sizer_F<>'1'" & vbCrLf & _
          "GROUP BY wv_prod_plan_header.plan_month, wv_prod_plan_header.remain_period2_from, wv_prod_plan_header.remain_period2_to, wv_prod_plan_header.remain_work_day, wv_prod_plan_header.month1_work_day,  " & vbCrLf & _
          "wv_prod_plan_header.month2_work_day, wv_prod_plan_header.month3_work_day, wv_prod_plan_header.remain_period1_from, wv_prod_plan_header.remain_period1_to, wv_prod_plan_header.month1_period1_from, " & vbCrLf & _
          "wv_prod_plan_header.month1_period1_to, wv_prod_plan_header.month1_period2_from, wv_prod_plan_header.month1_period2_to, wv_prod_plan_header.month2_period1_from, wv_prod_plan_header.month2_period1_to, " & vbCrLf & _
          "wv_prod_plan_header.month2_period2_from, wv_prod_plan_header.month2_period2_to, wv_prod_plan_header.month3_period1_from, wv_prod_plan_header.month3_period1_to, wv_prod_plan_header.month3_period2_from, " & vbCrLf & _
          "wv_prod_plan_header.month3_period2_to, wv_prod_plan_detail3.grey_no, wv_prod_plan_detail3.loom_model, wv_prod_plan_detail3.remain_period1_pcs, wv_prod_plan_detail3.month1_period1_pcs, " & vbCrLf & _
          "wv_prod_plan_detail3.month1_period2_pcs, wv_prod_plan_detail3.month2_period2_pcs, wv_prod_plan_detail3.month3_period2_pcs, wv_prod_plan_detail3.month2_period2_mtr, wv_prod_plan_detail3.remain_period1_mtr, " & vbCrLf & _
          "wv_prod_plan_detail3.month1_period2_mtr, wv_prod_plan_detail3.remain_period2_pcs, wv_prod_plan_detail3.remain_period2_mtr, wv_prod_plan_detail3.month3_period2_mtr, wv_prod_plan_detail3.month3_period1_mtr, " & vbCrLf & _
          "wv_fabric_analysis_master.length_gr, wv_fabric_analysis_master.warp_ln, wv_fabric_analysis_master.sizer_F, wv_prod_plan_detail3.month1_period1_mtr, wv_prod_plan_detail3.month2_period1_pcs, " & vbCrLf & _
          "wv_prod_plan_detail3.month2_period1_mtr, wv_prod_plan_detail3.month3_period1_pcs"
        '
        DA1 = New SqlDataAdapter(Sql1, KonCIM)
        DA1.Fill(DS1, "DSBeamer1")
        DT1 = DS1.Tables("DSBeamer1")
        '   '
        '   '
        'Header Plan Month
        With DTHeaderPlan
            .Columns.Add("plan_month")
        End With
        '
        DTHeaderPlan.Rows.Add()
        'For Each row As DataGridViewRow In DGVB.Rows
        DTHeaderPlan.Rows.Add(cmbPlanMonthedit.Text)
        'Next
        '
        objRpt.Database.Tables("DTHeaderPlan").SetDataSource(DTHeaderPlan)
        'objRpt.SetDataSource(DS.Tables("DSSizer1"))
        objRpt.SetDataSource(DS.Tables("DSBeamer1"))
        '
        'objRpt.Database.Tables("DTPrepMachineB").SetDataSource(DTPrepMachineB)
        'objRpt.SetDataSource(DS1.Tables("DSSizer1"))
        '
        '
        frmSizerBeameredit.CrystalReportViewer1.ReportSource = objRpt
        frmSizerBeameredit.CrystalReportViewer1.Refresh()
        frmSizerBeameredit.ShowDialog()
        '
        objRpt.Close()
        objRpt.Dispose()
        KonCIM.Dispose()
        '
        DT.Clear()
        '
    End Sub
End Class