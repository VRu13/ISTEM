<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUploadWIP3
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
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFile = New System.Windows.Forms.TextBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lblPlanMonth = New System.Windows.Forms.Label()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.DtpPickerawal = New System.Windows.Forms.DateTimePicker()
        Me.BtnSort = New System.Windows.Forms.Button()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnUpload
        '
        Me.BtnUpload.Location = New System.Drawing.Point(457, 24)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(96, 37)
        Me.BtnUpload.TabIndex = 301
        Me.BtnUpload.Text = "Upload WIP3"
        Me.BtnUpload.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 23)
        Me.Label1.TabIndex = 302
        Me.Label1.Text = "File Location"
        Me.Label1.Visible = False
        '
        'txtFile
        '
        Me.txtFile.Location = New System.Drawing.Point(131, 28)
        Me.txtFile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFile.Multiline = True
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(320, 34)
        Me.txtFile.TabIndex = 303
        Me.txtFile.Visible = False
        '
        'DGV
        '
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(16, 78)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(435, 189)
        Me.DGV.TabIndex = 304
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lblPlanMonth
        '
        Me.lblPlanMonth.AutoSize = True
        Me.lblPlanMonth.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlanMonth.Location = New System.Drawing.Point(134, 4)
        Me.lblPlanMonth.Name = "lblPlanMonth"
        Me.lblPlanMonth.Size = New System.Drawing.Size(17, 23)
        Me.lblPlanMonth.TabIndex = 305
        Me.lblPlanMonth.Text = "-"
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoSize = True
        Me.lblTanggal.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTanggal.Location = New System.Drawing.Point(255, 0)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(17, 23)
        Me.lblTanggal.TabIndex = 306
        Me.lblTanggal.Text = "-"
        '
        'DtpPickerawal
        '
        Me.DtpPickerawal.CustomFormat = "dd/MM/yyyy"
        Me.DtpPickerawal.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpPickerawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpPickerawal.Location = New System.Drawing.Point(457, 78)
        Me.DtpPickerawal.Name = "DtpPickerawal"
        Me.DtpPickerawal.Size = New System.Drawing.Size(161, 36)
        Me.DtpPickerawal.TabIndex = 307
        '
        'BtnSort
        '
        Me.BtnSort.Location = New System.Drawing.Point(522, 120)
        Me.BtnSort.Name = "BtnSort"
        Me.BtnSort.Size = New System.Drawing.Size(96, 37)
        Me.BtnSort.TabIndex = 308
        Me.BtnSort.Text = "Sort Data"
        Me.BtnSort.UseVisualStyleBackColor = True
        '
        'frmUploadWIP3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(635, 292)
        Me.Controls.Add(Me.BtnSort)
        Me.Controls.Add(Me.DtpPickerawal)
        Me.Controls.Add(Me.lblTanggal)
        Me.Controls.Add(Me.lblPlanMonth)
        Me.Controls.Add(Me.DGV)
        Me.Controls.Add(Me.txtFile)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BtnUpload)
        Me.MaximizeBox = False
        Me.Name = "frmUploadWIP3"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Upload WIP3"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnUpload As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFile As System.Windows.Forms.TextBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblPlanMonth As System.Windows.Forms.Label
    Friend WithEvents lblTanggal As System.Windows.Forms.Label
    Friend WithEvents DtpPickerawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSort As System.Windows.Forms.Button
End Class
