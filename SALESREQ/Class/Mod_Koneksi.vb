Imports System.Data.SqlClient
Imports System.Configuration
Module Mod_Koneksi
    '
    Public Kon As New SqlConnection
    Public KonSAP As New SqlConnection
    Public KonCIM As New SqlConnection
    Public KonIstem As New SqlConnection
    ' Public ConString As String = ConfigurationManager.ConnectionStrings("ISTEM").ConnectionString
    Public ContStrPSAP As String
    Public ConStringISTEM As String
    Public ConStringCIM As String
    'Public CMD As New SqlCommand
    Public DA As New SqlDataAdapter
    Public DA1 As New SqlDataAdapter
    Public DA2 As New SqlDataAdapter
    Public DS As New DataSet
    Public DS1 As New DataSet
    Public DS2 As New DataSet
    Public DT As New DataTable
    Public DT1 As New DataTable
    Public DT2 As New DataTable
    Public DR As SqlDataReader
    Public DRM1 As SqlDataReader
    Public DRM2 As SqlDataReader
    Public DRM3 As SqlDataReader
    Public DREDIT As SqlDataReader
    '
    Public WVMaster As String = "Select [grey_no],item_category FROM wv_fabric_analysis_master WHERE item_category IN ('TR', 'SP')"
    Public WVMasterTR As String = "Select [grey_no],item_category FROM  wv_fabric_analysis_master where item_category='TR'"
    Public WVMasterSP As String = "Select [grey_no],item_category FROM wv_fabric_analysis_master where item_category='SP'"
    '
    'select * from wv_fabric_analysis_master where act_rec='A' and chop_no<>'TEST' and grey_no<>'TEST'

    Public MPlan As String = "Select distinct [plan_month] FROM sl_grey_request"
    Public MCIMRPM As String = "Select * from wv_ajl_efficiency_detail"
    Public MVendorSAP As String = "Select * from OCRD where CardType='S' and frozenFor='N' and QRYgroup8='Y'"
    'Public MNamaVendorSAP As String = "Select * from OCRD where CardType='S' and frozenFor='N' and QRYgroup8='Y'"
    Public MItemYarnSAP As String = "Select * from OITM where ItmsGrpCod=109 and frozenFor='N'"
    Public MItemGreySAP As String = "Select * from OITM where ItmsGrpCod=111 and frozenFor='N'"
    'tambahan by fahrul
    Public par_form As String = ""
    Public ErrorQuery As Boolean = False

    Sub KoneksiSAP()
        ContStrPSAP = ConfigurationManager.ConnectionStrings("SAP").ConnectionString
        KonSAP = New SqlConnection(ContStrPSAP)
    End Sub
    Sub KoneksiISTEM()
        ConStringISTEM = ConfigurationManager.ConnectionStrings("ISTEM").ConnectionString
        KonIstem = New SqlConnection(ConStringISTEM)
    End Sub
    Sub KoneksiCIM()
        ConStringCIM = ConfigurationManager.ConnectionStrings("CIM").ConnectionString
        KonCIM = New SqlConnection(ConStringCIM)
    End Sub
    'Sub WVMTR()
    '    WVMasterTR = "Select [grey_no],item_category where item_category='TR' FROM wv_fabric_analysis_master"
    ''End Sub
    'Sub WVMSP()
    '    WVMasterSP = "Select [grey_no],item_category where item_category='SP' FROM wv_fabric_analysis_master"
    'End Sub
    'Sub WVMALL()
    '    WVMaster = "Select [grey_no],item_category where item_category= 'SP', FROM wv_fabric_analysis_master"
    'End Sub

    Public Function ExecuteQuery(ByVal a As String) As DataTable

        Dim perintah As New SqlCommand
        Dim DT As New DataTable

        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        KoneksiCIM()
        KonCIM.Open()

        perintah = New SqlCommand(a, KonCIM)

        DA = New SqlDataAdapter
        DA.SelectCommand = perintah

        DS = New DataSet
        DA.Fill(DS)

        DT = DS.Tables(0)

        Return DT

        DT = Nothing
        DS = Nothing
        DA = Nothing
        perintah = Nothing

        KonCIM.Close()

    End Function

    Sub SetComboBox(ByVal query As String, ByVal NamaForm As String)
        Dim data As DataTable

        Data = ExecuteQuery(query)

        Select Case NamaForm
            Case Is = "frmDailyLoomSet"
                frmDailyLoomSet.cb_plan_month.Items.Clear()
            Case Is = "frmProductionBalance"
                frmProductionBalance.cb_plan_month.Items.Clear()
            Case Is = "frmLayoutMachineMaster"
                frmLayoutMachineMaster.CBMachineMaster.Items.Clear()
        End Select

        With data.Columns(0)
            For a = 0 To data.Rows.Count - 1
                If NamaForm = "frmDailyLoomSet" Then frmDailyLoomSet.cb_plan_month.Items.Add(.Table.Rows(a).Item(0))
                If NamaForm = "frmProductionBalance" Then frmProductionBalance.cb_plan_month.Items.Add(.Table.Rows(a).Item(0))
                If NamaForm = "frmLayoutMachineMaster" Then frmLayoutMachineMaster.CBMachineMaster.Items.Add(.Table.Rows(a).Item(0))
            Next a
        End With

        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        data = Nothing
    End Sub

    Public Sub ExecuteNonQuery(ByVal Query1 As String, ByVal Query2 As String, ByVal Query3 As String, ByVal Query4 As String, ByVal Query5 As String)

        Dim query(5) As String 'array
        Dim perintah As New SqlCommand
        Dim transaksi As SqlTransaction
        Try
            If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
            KoneksiCIM()
            KonCIM.Open()

            query(0) = Query1 : query(1) = Query2 : query(2) = Query3 : query(3) = Query4 : query(4) = Query5


            perintah.Connection = KonCIM
            transaksi = KonCIM.BeginTransaction
            perintah.Transaction = transaksi
            perintah.CommandType = CommandType.Text

            For i = 0 To 4
                perintah.CommandTimeout = 10000
                perintah.CommandText = query(i)
                If query(i) <> "" Then perintah.ExecuteNonQuery()
            Next i

            transaksi.Commit()
            ErrorQuery = False

        Catch ex As Exception
            transaksi.Rollback()
            ErrorQuery = True
            MessageBox.Show(ex.Message)
            If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        Finally
            If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        End Try

    End Sub
End Module
