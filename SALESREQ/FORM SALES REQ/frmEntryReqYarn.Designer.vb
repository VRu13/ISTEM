<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntryReqYarn
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbPlanMonth = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtYarnStok = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtMonth1 = New System.Windows.Forms.TextBox()
        Me.txtMonth2 = New System.Windows.Forms.TextBox()
        Me.txtMonth3 = New System.Windows.Forms.TextBox()
        Me.txtMonth3qty = New System.Windows.Forms.TextBox()
        Me.txtMonth2qty = New System.Windows.Forms.TextBox()
        Me.txtMonth1qty = New System.Windows.Forms.TextBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.txtNamaVdr = New System.Windows.Forms.TextBox()
        Me.txtNamaitem = New System.Windows.Forms.TextBox()
        Me.BtnSimpan = New System.Windows.Forms.Button()
        Me.cmbOITM = New System.Windows.Forms.ComboBox()
        Me.cmbVendor = New System.Windows.Forms.ComboBox()
        Me.BtnHapus = New System.Windows.Forms.Button()
        Me.BtnUbah = New System.Windows.Forms.Button()
        Me.BtnSimpanedit = New System.Windows.Forms.Button()
        Me.txtKodeitem = New System.Windows.Forms.TextBox()
        Me.txtKodeVdr = New System.Windows.Forms.TextBox()
        Me.lblTanggal = New System.Windows.Forms.Label()
        Me.BtnShow = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 23)
        Me.Label4.TabIndex = 229
        Me.Label4.Text = "Plan Month"
        '
        'cmbPlanMonth
        '
        Me.cmbPlanMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPlanMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPlanMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlanMonth.FormattingEnabled = True
        Me.cmbPlanMonth.Location = New System.Drawing.Point(145, 8)
        Me.cmbPlanMonth.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPlanMonth.Name = "cmbPlanMonth"
        Me.cmbPlanMonth.Size = New System.Drawing.Size(165, 24)
        Me.cmbPlanMonth.TabIndex = 233
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 23)
        Me.Label2.TabIndex = 235
        Me.Label2.Text = "Kode Vendor"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 23)
        Me.Label3.TabIndex = 236
        Me.Label3.Text = "Kode Item"
        '
        'txtYarnStok
        '
        Me.txtYarnStok.Location = New System.Drawing.Point(145, 104)
        Me.txtYarnStok.Name = "txtYarnStok"
        Me.txtYarnStok.Size = New System.Drawing.Size(165, 20)
        Me.txtYarnStok.TabIndex = 241
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(100, 23)
        Me.Label7.TabIndex = 240
        Me.Label7.Text = "Yarn Stock"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(420, 101)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(81, 28)
        Me.TextBox3.TabIndex = 243
        Me.TextBox3.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(316, 101)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 23)
        Me.Label8.TabIndex = 244
        Me.Label8.Text = "KG"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 135)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(152, 23)
        Me.Label9.TabIndex = 245
        Me.Label9.Text = "Est.Delivery Date"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(175, 135)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(112, 23)
        Me.Label10.TabIndex = 246
        Me.Label10.Text = "Request Qty"
        '
        'txtMonth1
        '
        Me.txtMonth1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtMonth1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth1.Location = New System.Drawing.Point(16, 175)
        Me.txtMonth1.Name = "txtMonth1"
        Me.txtMonth1.ReadOnly = True
        Me.txtMonth1.Size = New System.Drawing.Size(130, 24)
        Me.txtMonth1.TabIndex = 247
        '
        'txtMonth2
        '
        Me.txtMonth2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtMonth2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth2.Location = New System.Drawing.Point(16, 201)
        Me.txtMonth2.Name = "txtMonth2"
        Me.txtMonth2.ReadOnly = True
        Me.txtMonth2.Size = New System.Drawing.Size(130, 24)
        Me.txtMonth2.TabIndex = 248
        '
        'txtMonth3
        '
        Me.txtMonth3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtMonth3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth3.Location = New System.Drawing.Point(16, 227)
        Me.txtMonth3.Name = "txtMonth3"
        Me.txtMonth3.ReadOnly = True
        Me.txtMonth3.Size = New System.Drawing.Size(130, 24)
        Me.txtMonth3.TabIndex = 249
        '
        'txtMonth3qty
        '
        Me.txtMonth3qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth3qty.Location = New System.Drawing.Point(174, 228)
        Me.txtMonth3qty.Name = "txtMonth3qty"
        Me.txtMonth3qty.Size = New System.Drawing.Size(113, 24)
        Me.txtMonth3qty.TabIndex = 252
        '
        'txtMonth2qty
        '
        Me.txtMonth2qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth2qty.Location = New System.Drawing.Point(174, 201)
        Me.txtMonth2qty.Name = "txtMonth2qty"
        Me.txtMonth2qty.Size = New System.Drawing.Size(113, 24)
        Me.txtMonth2qty.TabIndex = 251
        '
        'txtMonth1qty
        '
        Me.txtMonth1qty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth1qty.Location = New System.Drawing.Point(174, 175)
        Me.txtMonth1qty.Name = "txtMonth1qty"
        Me.txtMonth1qty.Size = New System.Drawing.Size(113, 24)
        Me.txtMonth1qty.TabIndex = 250
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(316, 215)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(310, 34)
        Me.BtnCancel.TabIndex = 253
        Me.BtnCancel.Text = "Keluar"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'txtNamaVdr
        '
        Me.txtNamaVdr.Location = New System.Drawing.Point(462, 75)
        Me.txtNamaVdr.Multiline = True
        Me.txtNamaVdr.Name = "txtNamaVdr"
        Me.txtNamaVdr.Size = New System.Drawing.Size(164, 20)
        Me.txtNamaVdr.TabIndex = 255
        '
        'txtNamaitem
        '
        Me.txtNamaitem.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtNamaitem.Location = New System.Drawing.Point(405, 39)
        Me.txtNamaitem.Name = "txtNamaitem"
        Me.txtNamaitem.ReadOnly = True
        Me.txtNamaitem.Size = New System.Drawing.Size(164, 20)
        Me.txtNamaitem.TabIndex = 254
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Location = New System.Drawing.Point(315, 166)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(100, 34)
        Me.BtnSimpan.TabIndex = 256
        Me.BtnSimpan.Text = "Save"
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'cmbOITM
        '
        Me.cmbOITM.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbOITM.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOITM.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOITM.FormattingEnabled = True
        Me.cmbOITM.Location = New System.Drawing.Point(145, 39)
        Me.cmbOITM.Name = "cmbOITM"
        Me.cmbOITM.Size = New System.Drawing.Size(481, 22)
        Me.cmbOITM.TabIndex = 257
        '
        'cmbVendor
        '
        Me.cmbVendor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbVendor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVendor.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVendor.FormattingEnabled = True
        Me.cmbVendor.Location = New System.Drawing.Point(145, 73)
        Me.cmbVendor.Name = "cmbVendor"
        Me.cmbVendor.Size = New System.Drawing.Size(481, 22)
        Me.cmbVendor.TabIndex = 258
        '
        'BtnHapus
        '
        Me.BtnHapus.Location = New System.Drawing.Point(526, 167)
        Me.BtnHapus.Name = "BtnHapus"
        Me.BtnHapus.Size = New System.Drawing.Size(100, 34)
        Me.BtnHapus.TabIndex = 259
        Me.BtnHapus.Text = "Delete"
        Me.BtnHapus.UseVisualStyleBackColor = True
        '
        'BtnUbah
        '
        Me.BtnUbah.Location = New System.Drawing.Point(420, 167)
        Me.BtnUbah.Name = "BtnUbah"
        Me.BtnUbah.Size = New System.Drawing.Size(100, 34)
        Me.BtnUbah.TabIndex = 260
        Me.BtnUbah.Text = "Modify"
        Me.BtnUbah.UseVisualStyleBackColor = True
        '
        'BtnSimpanedit
        '
        Me.BtnSimpanedit.Location = New System.Drawing.Point(316, 167)
        Me.BtnSimpanedit.Name = "BtnSimpanedit"
        Me.BtnSimpanedit.Size = New System.Drawing.Size(100, 34)
        Me.BtnSimpanedit.TabIndex = 261
        Me.BtnSimpanedit.Text = "Save"
        Me.BtnSimpanedit.UseVisualStyleBackColor = True
        Me.BtnSimpanedit.Visible = False
        '
        'txtKodeitem
        '
        Me.txtKodeitem.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtKodeitem.Location = New System.Drawing.Point(257, 39)
        Me.txtKodeitem.Name = "txtKodeitem"
        Me.txtKodeitem.ReadOnly = True
        Me.txtKodeitem.Size = New System.Drawing.Size(119, 20)
        Me.txtKodeitem.TabIndex = 262
        '
        'txtKodeVdr
        '
        Me.txtKodeVdr.Location = New System.Drawing.Point(316, 73)
        Me.txtKodeVdr.Multiline = True
        Me.txtKodeVdr.Name = "txtKodeVdr"
        Me.txtKodeVdr.Size = New System.Drawing.Size(140, 20)
        Me.txtKodeVdr.TabIndex = 263
        '
        'lblTanggal
        '
        Me.lblTanggal.AutoSize = True
        Me.lblTanggal.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTanggal.Location = New System.Drawing.Point(507, 101)
        Me.lblTanggal.Name = "lblTanggal"
        Me.lblTanggal.Size = New System.Drawing.Size(17, 23)
        Me.lblTanggal.TabIndex = 264
        Me.lblTanggal.Text = "-"
        Me.lblTanggal.Visible = False
        '
        'BtnShow
        '
        Me.BtnShow.Location = New System.Drawing.Point(356, 101)
        Me.BtnShow.Name = "BtnShow"
        Me.BtnShow.Size = New System.Drawing.Size(60, 28)
        Me.BtnShow.TabIndex = 265
        Me.BtnShow.Text = "....."
        Me.BtnShow.UseVisualStyleBackColor = True
        Me.BtnShow.Visible = False
        '
        'frmEntryReqYarn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 260)
        Me.Controls.Add(Me.BtnShow)
        Me.Controls.Add(Me.lblTanggal)
        Me.Controls.Add(Me.BtnUbah)
        Me.Controls.Add(Me.BtnHapus)
        Me.Controls.Add(Me.cmbVendor)
        Me.Controls.Add(Me.cmbOITM)
        Me.Controls.Add(Me.BtnSimpan)
        Me.Controls.Add(Me.txtNamaVdr)
        Me.Controls.Add(Me.txtNamaitem)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.txtMonth3qty)
        Me.Controls.Add(Me.txtMonth2qty)
        Me.Controls.Add(Me.txtMonth1qty)
        Me.Controls.Add(Me.txtMonth3)
        Me.Controls.Add(Me.txtMonth2)
        Me.Controls.Add(Me.txtMonth1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.txtYarnStok)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbPlanMonth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnSimpanedit)
        Me.Controls.Add(Me.txtKodeitem)
        Me.Controls.Add(Me.txtKodeVdr)
        Me.MaximizeBox = False
        Me.Name = "frmEntryReqYarn"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Entry Request Yarn"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbPlanMonth As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtYarnStok As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMonth1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth2 As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth3 As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth3qty As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth2qty As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth1qty As System.Windows.Forms.TextBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents txtNamaVdr As System.Windows.Forms.TextBox
    Friend WithEvents txtNamaitem As System.Windows.Forms.TextBox
    Friend WithEvents BtnSimpan As System.Windows.Forms.Button
    Friend WithEvents cmbOITM As System.Windows.Forms.ComboBox
    Friend WithEvents cmbVendor As System.Windows.Forms.ComboBox
    Friend WithEvents BtnHapus As System.Windows.Forms.Button
    Friend WithEvents BtnUbah As System.Windows.Forms.Button
    Friend WithEvents BtnSimpanedit As System.Windows.Forms.Button
    Friend WithEvents txtKodeitem As System.Windows.Forms.TextBox
    Friend WithEvents txtKodeVdr As System.Windows.Forms.TextBox
    Friend WithEvents lblTanggal As System.Windows.Forms.Label
    Friend WithEvents BtnShow As System.Windows.Forms.Button
End Class
