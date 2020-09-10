<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSizeBeamer
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
        Me.cmbPlanMonthedit = New System.Windows.Forms.ComboBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnView = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DGVS = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.DGVB = New System.Windows.Forms.DataGridView()
        CType(Me.DGVS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbPlanMonthedit
        '
        Me.cmbPlanMonthedit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPlanMonthedit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPlanMonthedit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlanMonthedit.FormattingEnabled = True
        Me.cmbPlanMonthedit.Location = New System.Drawing.Point(163, 22)
        Me.cmbPlanMonthedit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPlanMonthedit.Name = "cmbPlanMonthedit"
        Me.cmbPlanMonthedit.Size = New System.Drawing.Size(139, 24)
        Me.cmbPlanMonthedit.TabIndex = 235
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(16, 61)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(130, 34)
        Me.BtnCancel.TabIndex = 234
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 233
        Me.Label6.Text = "Plan Month"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(163, 61)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(139, 34)
        Me.BtnView.TabIndex = 232
        Me.BtnView.Text = "View"
        Me.BtnView.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(16, 101)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(130, 34)
        Me.Button1.TabIndex = 236
        Me.Button1.Text = "View Sizer"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(16, 141)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(130, 34)
        Me.Button2.TabIndex = 237
        Me.Button2.Text = "View Beamer"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'DGVS
        '
        Me.DGVS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVS.Location = New System.Drawing.Point(308, -6)
        Me.DGVS.Name = "DGVS"
        Me.DGVS.Size = New System.Drawing.Size(389, 101)
        Me.DGVS.TabIndex = 239
        Me.DGVS.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(163, 101)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(139, 34)
        Me.Button3.TabIndex = 240
        Me.Button3.Text = "View Gabungan"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'DGVB
        '
        Me.DGVB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVB.Location = New System.Drawing.Point(308, 102)
        Me.DGVB.Name = "DGVB"
        Me.DGVB.Size = New System.Drawing.Size(375, 102)
        Me.DGVB.TabIndex = 241
        Me.DGVB.Visible = False
        '
        'frmSizeBeamer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(308, 120)
        Me.Controls.Add(Me.DGVB)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DGVS)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmbPlanMonthedit)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnView)
        Me.MaximizeBox = False
        Me.Name = "frmSizeBeamer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Print Size & Beamer"
        CType(Me.DGVS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbPlanMonthedit As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnView As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DGVS As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DGVB As System.Windows.Forms.DataGridView
End Class
