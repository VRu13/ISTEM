<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateLoomSettingCariData
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
        Me.txtGreNo = New System.Windows.Forms.TextBox()
        Me.btnCari = New System.Windows.Forms.Button()
        Me.dtpPlanDate = New System.Windows.Forms.DateTimePicker()
        Me.txtLoomNo = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgDetail2 = New System.Windows.Forms.DataGridView()
        Me.txtPlanMonth = New System.Windows.Forms.TextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.dgDetail2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtGreNo
        '
        Me.txtGreNo.Location = New System.Drawing.Point(406, 12)
        Me.txtGreNo.Name = "txtGreNo"
        Me.txtGreNo.Size = New System.Drawing.Size(91, 20)
        Me.txtGreNo.TabIndex = 11
        Me.txtGreNo.Text = "Grey No"
        Me.txtGreNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCari
        '
        Me.btnCari.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCari.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCari.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnCari.Location = New System.Drawing.Point(503, 12)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(51, 20)
        Me.btnCari.TabIndex = 10
        Me.btnCari.Text = "Cari"
        Me.btnCari.UseVisualStyleBackColor = False
        '
        'dtpPlanDate
        '
        Me.dtpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPlanDate.Location = New System.Drawing.Point(164, 12)
        Me.dtpPlanDate.Name = "dtpPlanDate"
        Me.dtpPlanDate.Size = New System.Drawing.Size(102, 20)
        Me.dtpPlanDate.TabIndex = 8
        Me.dtpPlanDate.Value = New Date(2020, 7, 27, 13, 58, 16, 0)
        '
        'txtLoomNo
        '
        Me.txtLoomNo.Location = New System.Drawing.Point(272, 12)
        Me.txtLoomNo.Name = "txtLoomNo"
        Me.txtLoomNo.Size = New System.Drawing.Size(102, 20)
        Me.txtLoomNo.TabIndex = 9
        Me.txtLoomNo.Text = "Loom No"
        Me.txtLoomNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgDetail2)
        Me.Panel1.Location = New System.Drawing.Point(9, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(548, 269)
        Me.Panel1.TabIndex = 6
        '
        'dgDetail2
        '
        Me.dgDetail2.AllowUserToAddRows = False
        Me.dgDetail2.AllowUserToDeleteRows = False
        Me.dgDetail2.BackgroundColor = System.Drawing.SystemColors.Control
        Me.dgDetail2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDetail2.GridColor = System.Drawing.SystemColors.MenuText
        Me.dgDetail2.Location = New System.Drawing.Point(3, 8)
        Me.dgDetail2.Name = "dgDetail2"
        Me.dgDetail2.ReadOnly = True
        Me.dgDetail2.Size = New System.Drawing.Size(542, 258)
        Me.dgDetail2.TabIndex = 0
        '
        'txtPlanMonth
        '
        Me.txtPlanMonth.Location = New System.Drawing.Point(56, 12)
        Me.txtPlanMonth.Name = "txtPlanMonth"
        Me.txtPlanMonth.Size = New System.Drawing.Size(102, 20)
        Me.txtPlanMonth.TabIndex = 7
        Me.txtPlanMonth.Text = "Plant Month"
        Me.txtPlanMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'frmUpdateLoomSettingCariData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 328)
        Me.Controls.Add(Me.txtGreNo)
        Me.Controls.Add(Me.btnCari)
        Me.Controls.Add(Me.dtpPlanDate)
        Me.Controls.Add(Me.txtLoomNo)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtPlanMonth)
        Me.Name = "frmUpdateLoomSettingCariData"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cari Data"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgDetail2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtGreNo As System.Windows.Forms.TextBox
    Friend WithEvents btnCari As System.Windows.Forms.Button
    Friend WithEvents dtpPlanDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtLoomNo As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgDetail2 As System.Windows.Forms.DataGridView
    Friend WithEvents txtPlanMonth As System.Windows.Forms.TextBox
End Class
