<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdGrySett
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
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.txtRpm = New System.Windows.Forms.TextBox()
        Me.txtPrMtr = New System.Windows.Forms.TextBox()
        Me.txtPrPCS = New System.Windows.Forms.TextBox()
        Me.txtPrEff = New System.Windows.Forms.TextBox()
        Me.txtPrDen = New System.Windows.Forms.TextBox()
        Me.cmbGreyno = New System.Windows.Forms.ComboBox()
        Me.cmbLoom = New System.Windows.Forms.ComboBox()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.BtnGenerate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPlanMonthedit = New System.Windows.Forms.ComboBox()
        Me.lblLength = New System.Windows.Forms.Label()
        Me.BtnSett = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblRevno = New System.Windows.Forms.Label()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 10)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 187
        Me.Label6.Text = "Plan Month"
        '
        'BtnSave
        '
        Me.BtnSave.Location = New System.Drawing.Point(4, 222)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(115, 34)
        Me.BtnSave.TabIndex = 186
        Me.BtnSave.Text = "Simpan"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'txtRpm
        '
        Me.txtRpm.Location = New System.Drawing.Point(126, 88)
        Me.txtRpm.Name = "txtRpm"
        Me.txtRpm.Size = New System.Drawing.Size(80, 20)
        Me.txtRpm.TabIndex = 191
        '
        'txtPrMtr
        '
        Me.txtPrMtr.Location = New System.Drawing.Point(126, 130)
        Me.txtPrMtr.Name = "txtPrMtr"
        Me.txtPrMtr.ReadOnly = True
        Me.txtPrMtr.Size = New System.Drawing.Size(80, 20)
        Me.txtPrMtr.TabIndex = 192
        '
        'txtPrPCS
        '
        Me.txtPrPCS.Location = New System.Drawing.Point(126, 165)
        Me.txtPrPCS.Name = "txtPrPCS"
        Me.txtPrPCS.ReadOnly = True
        Me.txtPrPCS.Size = New System.Drawing.Size(80, 20)
        Me.txtPrPCS.TabIndex = 193
        '
        'txtPrEff
        '
        Me.txtPrEff.Location = New System.Drawing.Point(380, 91)
        Me.txtPrEff.Name = "txtPrEff"
        Me.txtPrEff.Size = New System.Drawing.Size(57, 20)
        Me.txtPrEff.TabIndex = 194
        '
        'txtPrDen
        '
        Me.txtPrDen.Location = New System.Drawing.Point(380, 133)
        Me.txtPrDen.Name = "txtPrDen"
        Me.txtPrDen.ReadOnly = True
        Me.txtPrDen.Size = New System.Drawing.Size(90, 20)
        Me.txtPrDen.TabIndex = 195
        '
        'cmbGreyno
        '
        Me.cmbGreyno.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbGreyno.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbGreyno.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGreyno.FormattingEnabled = True
        Me.cmbGreyno.Location = New System.Drawing.Point(126, 51)
        Me.cmbGreyno.Name = "cmbGreyno"
        Me.cmbGreyno.Size = New System.Drawing.Size(114, 24)
        Me.cmbGreyno.TabIndex = 196
        '
        'cmbLoom
        '
        Me.cmbLoom.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbLoom.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbLoom.FormattingEnabled = True
        Me.cmbLoom.Location = New System.Drawing.Point(380, 56)
        Me.cmbLoom.Name = "cmbLoom"
        Me.cmbLoom.Size = New System.Drawing.Size(90, 21)
        Me.cmbLoom.TabIndex = 197
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(144, 222)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(115, 34)
        Me.BtnCancel.TabIndex = 198
        Me.BtnCancel.Text = "Batal"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'BtnGenerate
        '
        Me.BtnGenerate.Location = New System.Drawing.Point(295, 182)
        Me.BtnGenerate.Name = "BtnGenerate"
        Me.BtnGenerate.Size = New System.Drawing.Size(173, 34)
        Me.BtnGenerate.TabIndex = 199
        Me.BtnGenerate.Text = "Re Generate"
        Me.BtnGenerate.UseVisualStyleBackColor = True
        Me.BtnGenerate.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(291, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 23)
        Me.Label2.TabIndex = 200
        Me.Label2.Text = "Loom"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(291, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 23)
        Me.Label4.TabIndex = 202
        Me.Label4.Text = "Density"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(291, 88)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 23)
        Me.Label5.TabIndex = 203
        Me.Label5.Text = "Eficiency"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(224, 130)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 23)
        Me.Label7.TabIndex = 204
        Me.Label7.Text = "Meter"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 125)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 23)
        Me.Label9.TabIndex = 206
        Me.Label9.Text = "Prod Day"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(7, 85)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 23)
        Me.Label10.TabIndex = 207
        Me.Label10.Text = "RPM"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(7, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(78, 23)
        Me.Label11.TabIndex = 208
        Me.Label11.Text = "Grey No"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(224, 170)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(42, 23)
        Me.Label12.TabIndex = 209
        Me.Label12.Text = "PCS"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 269)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(498, 22)
        Me.StatusStrip1.TabIndex = 210
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(480, 16)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(439, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 23)
        Me.Label1.TabIndex = 211
        Me.Label1.Text = "%"
        '
        'cmbPlanMonthedit
        '
        Me.cmbPlanMonthedit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPlanMonthedit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPlanMonthedit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlanMonthedit.FormattingEnabled = True
        Me.cmbPlanMonthedit.Location = New System.Drawing.Point(126, 13)
        Me.cmbPlanMonthedit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPlanMonthedit.Name = "cmbPlanMonthedit"
        Me.cmbPlanMonthedit.Size = New System.Drawing.Size(111, 24)
        Me.cmbPlanMonthedit.TabIndex = 227
        '
        'lblLength
        '
        Me.lblLength.AutoSize = True
        Me.lblLength.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLength.Location = New System.Drawing.Point(376, 16)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(20, 23)
        Me.lblLength.TabIndex = 228
        Me.lblLength.Text = "0"
        Me.lblLength.Visible = False
        '
        'BtnSett
        '
        Me.BtnSett.Location = New System.Drawing.Point(295, 222)
        Me.BtnSett.Name = "BtnSett"
        Me.BtnSett.Size = New System.Drawing.Size(175, 34)
        Me.BtnSett.TabIndex = 229
        Me.BtnSett.Text = "Re-Calculate"
        Me.BtnSett.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(291, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 23)
        Me.Label3.TabIndex = 230
        Me.Label3.Text = "Length"
        Me.Label3.Visible = False
        '
        'lblRevno
        '
        Me.lblRevno.AutoSize = True
        Me.lblRevno.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRevno.Location = New System.Drawing.Point(402, 16)
        Me.lblRevno.Name = "lblRevno"
        Me.lblRevno.Size = New System.Drawing.Size(20, 23)
        Me.lblRevno.TabIndex = 231
        Me.lblRevno.Text = "0"
        Me.lblRevno.Visible = False
        '
        'frmUpdGrySett
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 291)
        Me.Controls.Add(Me.lblRevno)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnSett)
        Me.Controls.Add(Me.lblLength)
        Me.Controls.Add(Me.cmbPlanMonthedit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.BtnGenerate)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.cmbLoom)
        Me.Controls.Add(Me.cmbGreyno)
        Me.Controls.Add(Me.txtPrDen)
        Me.Controls.Add(Me.txtPrEff)
        Me.Controls.Add(Me.txtPrPCS)
        Me.Controls.Add(Me.txtPrMtr)
        Me.Controls.Add(Me.txtRpm)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmUpdGrySett"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Update Grey Setting"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents txtRpm As System.Windows.Forms.TextBox
    Friend WithEvents txtPrMtr As System.Windows.Forms.TextBox
    Friend WithEvents txtPrPCS As System.Windows.Forms.TextBox
    Friend WithEvents txtPrEff As System.Windows.Forms.TextBox
    Friend WithEvents txtPrDen As System.Windows.Forms.TextBox
    Friend WithEvents cmbGreyno As System.Windows.Forms.ComboBox
    Friend WithEvents cmbLoom As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnGenerate As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripProgressBar1 As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPlanMonthedit As System.Windows.Forms.ComboBox
    Friend WithEvents lblLength As System.Windows.Forms.Label
    Friend WithEvents BtnSett As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblRevno As System.Windows.Forms.Label
End Class
