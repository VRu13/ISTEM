<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrMnuUtama
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsLabelUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSlblTanggal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSlblJam = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TSlbip = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsLabelUser, Me.TSlblTanggal, Me.TSlblJam, Me.TSlbip})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 463)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(947, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsLabelUser
        '
        Me.tsLabelUser.AutoSize = False
        Me.tsLabelUser.Name = "tsLabelUser"
        Me.tsLabelUser.Size = New System.Drawing.Size(150, 17)
        Me.tsLabelUser.Text = "USR01"
        '
        'TSlblTanggal
        '
        Me.TSlblTanggal.AutoSize = False
        Me.TSlblTanggal.Name = "TSlblTanggal"
        Me.TSlblTanggal.Size = New System.Drawing.Size(120, 17)
        Me.TSlblTanggal.Text = "-"
        '
        'TSlblJam
        '
        Me.TSlblJam.AutoSize = False
        Me.TSlblJam.Name = "TSlblJam"
        Me.TSlblJam.Size = New System.Drawing.Size(120, 17)
        Me.TSlblJam.Text = "-"
        '
        'TSlbip
        '
        Me.TSlbip.Name = "TSlbip"
        Me.TSlbip.Size = New System.Drawing.Size(82, 17)
        Me.TSlbip.Text = "127.168.21.227"
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(167, 463)
        Me.Panel1.TabIndex = 2
        '
        'Panel2
        '
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(167, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(780, 52)
        Me.Panel2.TabIndex = 3
        '
        'FrMnuUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 485)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrMnuUtama"
        Me.Text = "FrMnuUtama"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsLabelUser As ToolStripStatusLabel
    Friend WithEvents TSlblTanggal As ToolStripStatusLabel
    Friend WithEvents TSlblJam As ToolStripStatusLabel
    Friend WithEvents TSlbip As ToolStripStatusLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
End Class
