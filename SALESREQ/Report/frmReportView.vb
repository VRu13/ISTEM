Imports System.Data.SqlClient
Imports System.Configuration
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports Excel = Microsoft.Office.Interop.Excel

Public Class frmReportView

    'Dim konek As New ClsKoneksi
    Dim tgl_request As DateTime
    Dim data As DataTable
    Dim kue As String
    Dim perintah As New SqlCommand


    Sub buat_data()

        Select Case par_form
            Case "DAILY LOOM SETING"

                data = ExecuteQuery("select top 1 request_date as tgl from sl_grey_request where plan_month = '" & frmDailyLoomSet.par_plan_month & "' ")
                If data.Rows.Count > 0 Then
                    tgl_request = data.Rows(0).Item("tgl")
                Else
                    tgl_request = Now
                    MsgBox("Tanggal Request Date untuk Plan Month " + " " & frmDailyLoomSet.par_plan_month & " Tidak Ada/Belum Dibuat")
                End If

                KoneksiCIM()
                KonCIM.Open()

                perintah = New SqlCommand("EXEC wppc.sp_Rpt_Daily_Loom_setting @plan_month =  '" & frmDailyLoomSet.par_plan_month & "', @tgl_req = '" & tgl_request & "' ", KonCIM)
                DA = New SqlDataAdapter
                DA.SelectCommand = perintah

                DS = New DataSet
                DA.Fill(DS, "Daily_loom_setting")

            Case "Update Loom Setting"

                data = ExecuteQuery("select top 1 request_date as tgl from sl_grey_request where plan_month = '" & frmUpdateLoomSetting.txtPlanMonth.Text & "' ")
                If data.Rows.Count > 0 Then
                    tgl_request = data.Rows(0).Item("tgl")
                Else
                    tgl_request = Now
                    MsgBox("Tanggal Request Date untuk Plan Month " + " " & frmUpdateLoomSetting.txtPlanMonth.Text & " Tidak Ada/Belum Dibuat")
                End If

                KoneksiCIM()
                KonCIM.Open()

                perintah = New SqlCommand("EXEC wppc.sp_Rpt_Daily_Loom_setting @plan_month =  '" & frmUpdateLoomSetting.txtPlanMonth.Text & "', @tgl_req = '" & tgl_request & "' ", KonCIM)
                DA = New SqlDataAdapter
                DA.SelectCommand = perintah

                DS = New DataSet
                DA.Fill(DS, "Daily_loom_setting")

            Case "PRODUCTION BALANCE"
                KoneksiCIM()
                KonCIM.Open()

                perintah = New SqlCommand("EXEC wppc.sp_Rpt_Production_Balance @plan_month = '" & frmProductionBalance.par_plan_month_prod_bal & "' ", KonCIM)
                DA = New SqlDataAdapter
                DA.SelectCommand = perintah

                DS = New DataSet
                DA.Fill(DS, "Production_balance")

                'Case "PLAN VS ACTUAL"
                'KoneksiCIM()
                'KonCIM.Open()

                'perintah = New SqlCommand("wppc.sp_Rpt_Plan_VS_Actual '01-09-2020' ", KonCIM)
                'DA = New SqlDataAdapter
                'DA.SelectCommand = perintah

                'DS = New DataSet
                'DA.Fill(DS, "PLANVSACTUAL")
                'data = New Data.DataTable("PLANVSACTUAL")
                ''data = DS.Tables("PLANVSACTUAL")
                'Call BuatTampilanExcel(data)

        End Select

    End Sub

   

    Sub tampil_report()

        Select Case par_form
            Case "DAILY LOOM SETING"
                Dim Report As New WPPC_ReportLoomSetting
                Report.SetDataSource(DS)
                CrReport.ReportSource = Report
                CrReport.Refresh()
                CrReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                CrReport.Zoom(80)

            Case "Update Loom Setting"
                Dim Report As New WPPC_ReportLoomSetting
                Report.SetDataSource(DS)
                CrReport.ReportSource = Report
                CrReport.Refresh()
                CrReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                CrReport.Zoom(80)

            Case "PRODUCTION BALANCE"
                Dim Report As New WPPC_ReportProdBalance
                Report.SetDataSource(DS)
                CrReport.ReportSource = Report
                CrReport.Refresh()
                CrReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
                CrReport.Zoom(75)
        End Select


    End Sub

    Private Sub frmReportView_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        par_form = ""
        KonCIM.Close()
    End Sub

    Private Sub frmReportView_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Call buat_data()
        Call tampil_report()
        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub
End Class