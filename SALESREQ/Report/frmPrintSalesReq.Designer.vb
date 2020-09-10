<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintSalesReq
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.CRSalesReqEntry2 = New WindowsApplication1.CRSalesReqEntry()
        Me.CRSalesReqEntry1 = New WindowsApplication1.CRSalesReqEntry()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.DisplayStatusBar = False
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(887, 307)
        Me.CrystalReportViewer1.TabIndex = 0
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmPrintSalesReq
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 307)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "frmPrintSalesReq"
        Me.Text = "Menu Print Sales Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    'Friend WithEvents CRSalesReq1 As WindowsApplication1.CRSalesReq
    Friend WithEvents CRSalesReqEntry2 As WindowsApplication1.CRSalesReqEntry
    Friend WithEvents CRSalesReqEntry1 As WindowsApplication1.CRSalesReqEntry
    'Friend WithEvents CRSalesEntry1 As WindowsApplication1.CRSalesEntry
    'Friend WithEvents CrystalReport31 As WindowsApplication1.CrystalReport3
    'Friend WithEvents CRSalesEntry2 As WindowsApplication1.CRSalesEntry
    'Friend WithEvents CRSalesEntry4 As WindowsApplication1.CRSalesEntry
    'Friend WithEvents CRSalesEntry3 As WindowsApplication1.CRSalesEntry
End Class
