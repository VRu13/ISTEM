Imports System.Data.SqlClient
Public Class frmLayoutMachineMaster

    Public param_plan_month As String
    Public param_plan_date As String
    Public param_loom_no As String
    Public param_shift_time As String
    Public param_Grey_No As String
    Dim datatampil As DataTable
    Dim query, loom, param As String

    Sub setActionhandler(ByVal txt As System.Object)

        Dim nomormesin, grey_no As String
        Dim parts() As String

        param_plan_month = ""
        param_plan_date = ""
        param_loom_no = ""
        param_Grey_No = ""

        parts = Split(txt.Text, vbCrLf)

        Select Case parts.Length
            Case Is = 1
                nomormesin = Trim(parts(0))
            Case Is = 2
                nomormesin = Trim(parts(0))
                grey_no = Trim(parts(1))
            Case Is = 0
                nomormesin = ""
                grey_no = ""
        End Select

        param_plan_month = CBMachineMaster.SelectedItem
        param_plan_date = Format(DTMachineMaster.Value, "yyyy-MM-dd")
        param_loom_no = nomormesin
        param_Grey_No = grey_no

        frmLayoutMachineMasterInfo.ShowDialog()

    End Sub

    Sub ambil_data(ByVal par As String)

        If par = "LOAD" Then

            If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
            KoneksiCIM()
            KonCIM.Open()

            For Each c As TextBox In Me.Panel1.Controls.OfType(Of TextBox)()
                c.Text = ""
            Next
            query = "select grey_no, plan_month, plan_date, loom_no, shift_time from wv_prod_plan_detail2 " & _
                        "where plan_month = '" & IIf(param = "Update Loom Setting", param_plan_month, CBMachineMaster.Text) & "' and " & _
                        "plan_date = '" & IIf(param = "Update Loom Setting", param_plan_date, Format(DTMachineMaster.Value, "yyyy-MM-dd")) & "'"
            datatampil = ExecuteQuery(query)

            For Each ctrl As TextBox In Me.Panel1.Controls.OfType(Of TextBox)()
                loom = ctrl.Name

                Dim results As DataRow = datatampil.Select("loom_no = '" & loom & "' AND shift_time = '2'").FirstOrDefault()
                If Not results Is Nothing Then
                    ctrl.Text = loom & Environment.NewLine & results.Item("grey_no")
                Else
                    ctrl.Text = loom
                End If

            Next

            datatampil = Nothing
            KonCIM.Close()
            param = ""

        End If

        If par = "CLOSE" Then

            For Each c As TextBox In Me.Panel1.Controls.OfType(Of TextBox)()
                c.Text = ""
            Next

            For Each c As TextBox In Me.Panel1.Controls.OfType(Of TextBox)()
                c.Text = c.Name
            Next

        End If
    End Sub
    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        Me.Cursor = Cursors.WaitCursor
        param = ""

        Dim c As New TextBox
        c.Name = param_loom_no
        If param_loom_no <> "" Then Me.Panel1.Controls(c.Name).BackColor = Control.DefaultBackColor


        ambil_data("LOAD")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmLayoutMachineMaster_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        If KonCIM.State = ConnectionState.Open Then KonCIM.Close()
        datatampil = Nothing
        ambil_data("CLOSE")

        Dim c As New TextBox
        c.Name = param_loom_no
        If param_loom_no <> "" Then Me.Panel1.Controls(c.Name).BackColor = Control.DefaultBackColor

    End Sub

    Private Sub frmLayoutMachineMaster_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

        param = ""
        lblPlan_Month.Text = "PLAN MONTH " & CBMachineMaster.SelectedItem

    End Sub

    Private Sub frmLayoutMachineMaster_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim str As String
        Dim strArr() As String

        str = frmUpdateLoomSetting.par_MachineMasterGrey
        strArr = str.Split("/")
        param = strArr(0)
        param_plan_month = strArr(1)
        param_plan_date = strArr(2)
        param_loom_no = strArr(3)

        If param = "Update Loom Setting" Then

            ambil_data("LOAD")
            SetComboBox("Select distinct plan_month from wv_prod_plan_detail2", "frmLayoutMachineMaster")
            CBMachineMaster.Text = param_plan_month
            DTMachineMaster.Value = param_plan_date
            lblPlan_Month.Text = "PLAN MONTH " & param_plan_month

            Dim c As New TextBox
            c.Name = param_loom_no
            If param_loom_no <> "" Then Me.Panel1.Controls(c.Name).BackColor = Color.Yellow

        Else
            SetComboBox("Select distinct plan_month from wv_prod_plan_detail2", "frmLayoutMachineMaster")
        End If

    End Sub

    Private Sub E563_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles E563.Click, E562.Click, E561.Click, E560.Click,
        E553.Click, E552.Click, E551.Click, E550.Click,
        E543.Click, E542.Click, E541.Click, E540.Click,
        E533.Click, E532.Click, E531.Click, E530.Click,
        E523.Click, E522.Click, E521.Click, E520.Click,
        E513.Click, E512.Click, E511.Click, E510.Click

        Dim loom_no As TextBox = DirectCast(sender, TextBox)
        setActionhandler(loom_no)

    End Sub

    Private Sub C367_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles C367.Click, C366.Click, C365.Click, C364.Click, C363.Click, C362.Click, C361.Click, C360.Click,
        C357.Click, C356.Click, C355.Click, C354.Click, C353.Click, C352.Click, C351.Click, C350.Click,
        C347.Click, C346.Click, C345.Click, C344.Click, C343.Click, C342.Click, C341.Click, C340.Click,
        C336.Click, C335.Click, C334.Click, C333.Click, C332.Click, C331.Click, C330.Click,
        C326.Click, C325.Click, C324.Click, C323.Click, C322.Click, C321.Click, C320.Click,
        C316.Click, C315.Click, C314.Click, C313.Click, C312.Click, C311.Click, C310.Click

        Dim loom_no As TextBox = DirectCast(sender, TextBox)
        setActionhandler(loom_no)

    End Sub

    Private Sub B266_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles B266.Click,
        B265.Click, B264.Click, B263.Click, B262.Click, B261.Click, B260.Click,
        B256.Click, B255.Click, B254.Click, B253.Click, B252.Click, B251.Click, B250.Click,
        B246.Click, B245.Click, B244.Click, B243.Click, B242.Click, B241.Click, B240.Click,
        B236.Click, B235.Click, B234.Click, B233.Click, B232.Click, B231.Click, B230.Click,
        B226.Click, B225.Click, B224.Click, B223.Click, B222.Click, B221.Click, B220.Click,
        B216.Click, B215.Click, B214.Click, B213.Click, B212.Click, B211.Click, B210.Click

        Dim loom_no As TextBox = DirectCast(sender, TextBox)
        setActionhandler(loom_no)

    End Sub


    Private Sub D464_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles D464.Click, D463.Click, D463.Click, D462.Click, D461.Click, D460.Click,
        D454.Click, D453.Click, D452.Click, D451.Click, D450.Click,
        D444.Click, D443.Click, D442.Click, D441.Click, D440.Click,
        D434.Click, D433.Click, D432.Click, D431.Click, D430.Click,
        D424.Click, D423.Click, D422.Click, D421.Click, D420.Click,
        D414.Click, D413.Click, D412.Click, D411.Click, D410.Click

        Dim loom_no As TextBox = DirectCast(sender, TextBox)
        setActionhandler(loom_no)

    End Sub
End Class