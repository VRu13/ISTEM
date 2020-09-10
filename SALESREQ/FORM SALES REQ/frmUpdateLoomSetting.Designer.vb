<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdateLoomSetting
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtPlanMonth = New System.Windows.Forms.TextBox()
        Me.txtLoomNo = New System.Windows.Forms.TextBox()
        Me.txtGreyNo2 = New System.Windows.Forms.TextBox()
        Me.btnCariDetail2 = New System.Windows.Forms.Button()
        Me.btnCariDetail = New System.Windows.Forms.Button()
        Me.ceboxDrawIn = New System.Windows.Forms.CheckBox()
        Me.txtGreyNO1 = New System.Windows.Forms.TextBox()
        Me.dtpPlanDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnDailyLoom = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnMachineLayout = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DGUpdateLoom = New System.Windows.Forms.DataGridView()
        Me.btnUpdateGrey = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DGUpdateLoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtPlanMonth)
        Me.Panel1.Controls.Add(Me.txtLoomNo)
        Me.Panel1.Controls.Add(Me.txtGreyNo2)
        Me.Panel1.Controls.Add(Me.btnCariDetail2)
        Me.Panel1.Controls.Add(Me.btnCariDetail)
        Me.Panel1.Controls.Add(Me.ceboxDrawIn)
        Me.Panel1.Controls.Add(Me.txtGreyNO1)
        Me.Panel1.Controls.Add(Me.dtpPlanDate)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(10, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(380, 170)
        Me.Panel1.TabIndex = 0
        '
        'txtPlanMonth
        '
        Me.txtPlanMonth.Location = New System.Drawing.Point(150, 16)
        Me.txtPlanMonth.Name = "txtPlanMonth"
        Me.txtPlanMonth.Size = New System.Drawing.Size(125, 20)
        Me.txtPlanMonth.TabIndex = 46
        '
        'txtLoomNo
        '
        Me.txtLoomNo.Location = New System.Drawing.Point(150, 75)
        Me.txtLoomNo.Name = "txtLoomNo"
        Me.txtLoomNo.Size = New System.Drawing.Size(125, 20)
        Me.txtLoomNo.TabIndex = 45
        '
        'txtGreyNo2
        '
        Me.txtGreyNo2.Location = New System.Drawing.Point(150, 142)
        Me.txtGreyNo2.Name = "txtGreyNo2"
        Me.txtGreyNo2.Size = New System.Drawing.Size(125, 20)
        Me.txtGreyNo2.TabIndex = 44
        '
        'btnCariDetail2
        '
        Me.btnCariDetail2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCariDetail2.Location = New System.Drawing.Point(277, 144)
        Me.btnCariDetail2.Name = "btnCariDetail2"
        Me.btnCariDetail2.Size = New System.Drawing.Size(33, 18)
        Me.btnCariDetail2.TabIndex = 43
        Me.btnCariDetail2.Text = "Cari"
        Me.btnCariDetail2.UseVisualStyleBackColor = True
        '
        'btnCariDetail
        '
        Me.btnCariDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCariDetail.Location = New System.Drawing.Point(277, 18)
        Me.btnCariDetail.Name = "btnCariDetail"
        Me.btnCariDetail.Size = New System.Drawing.Size(33, 18)
        Me.btnCariDetail.TabIndex = 42
        Me.btnCariDetail.Text = "Cari"
        Me.btnCariDetail.UseVisualStyleBackColor = True
        '
        'ceboxDrawIn
        '
        Me.ceboxDrawIn.AutoSize = True
        Me.ceboxDrawIn.Location = New System.Drawing.Point(316, 144)
        Me.ceboxDrawIn.Name = "ceboxDrawIn"
        Me.ceboxDrawIn.Size = New System.Drawing.Size(63, 17)
        Me.ceboxDrawIn.TabIndex = 41
        Me.ceboxDrawIn.Text = "Draw In"
        Me.ceboxDrawIn.UseVisualStyleBackColor = True
        '
        'txtGreyNO1
        '
        Me.txtGreyNO1.Location = New System.Drawing.Point(150, 108)
        Me.txtGreyNO1.Name = "txtGreyNO1"
        Me.txtGreyNO1.Size = New System.Drawing.Size(125, 20)
        Me.txtGreyNO1.TabIndex = 35
        '
        'dtpPlanDate
        '
        Me.dtpPlanDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpPlanDate.Location = New System.Drawing.Point(150, 45)
        Me.dtpPlanDate.Name = "dtpPlanDate"
        Me.dtpPlanDate.Size = New System.Drawing.Size(125, 20)
        Me.dtpPlanDate.TabIndex = 34
        Me.dtpPlanDate.Value = New Date(2020, 7, 24, 0, 0, 0, 0)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 148)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Change Grey No"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 110)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 13)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Current Grey No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 75)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 13)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Loom No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 13)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Plan Date"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Plan Month"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnUpdateGrey)
        Me.Panel2.Controls.Add(Me.btnDailyLoom)
        Me.Panel2.Controls.Add(Me.btnCancel)
        Me.Panel2.Controls.Add(Me.btnSave)
        Me.Panel2.Controls.Add(Me.btnModify)
        Me.Panel2.Controls.Add(Me.btnMachineLayout)
        Me.Panel2.Location = New System.Drawing.Point(10, 188)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(379, 80)
        Me.Panel2.TabIndex = 1
        '
        'btnDailyLoom
        '
        Me.btnDailyLoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDailyLoom.Location = New System.Drawing.Point(239, 42)
        Me.btnDailyLoom.Name = "btnDailyLoom"
        Me.btnDailyLoom.Size = New System.Drawing.Size(73, 32)
        Me.btnDailyLoom.TabIndex = 24
        Me.btnDailyLoom.Text = "Daily Loom"
        Me.btnDailyLoom.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(239, 5)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(73, 32)
        Me.btnCancel.TabIndex = 23
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(160, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(73, 32)
        Me.btnSave.TabIndex = 22
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnModify
        '
        Me.btnModify.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModify.Location = New System.Drawing.Point(81, 5)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(73, 32)
        Me.btnModify.TabIndex = 26
        Me.btnModify.Text = "Modify"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnMachineLayout
        '
        Me.btnMachineLayout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMachineLayout.Location = New System.Drawing.Point(81, 41)
        Me.btnMachineLayout.Name = "btnMachineLayout"
        Me.btnMachineLayout.Size = New System.Drawing.Size(73, 32)
        Me.btnMachineLayout.TabIndex = 25
        Me.btnMachineLayout.Text = "M/C Layout"
        Me.btnMachineLayout.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.DGUpdateLoom)
        Me.Panel3.Location = New System.Drawing.Point(10, 274)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(380, 143)
        Me.Panel3.TabIndex = 2
        '
        'DGUpdateLoom
        '
        Me.DGUpdateLoom.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DGUpdateLoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGUpdateLoom.Location = New System.Drawing.Point(6, 5)
        Me.DGUpdateLoom.Name = "DGUpdateLoom"
        Me.DGUpdateLoom.ReadOnly = True
        Me.DGUpdateLoom.Size = New System.Drawing.Size(367, 127)
        Me.DGUpdateLoom.TabIndex = 3
        '
        'btnUpdateGrey
        '
        Me.btnUpdateGrey.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateGrey.Location = New System.Drawing.Point(160, 41)
        Me.btnUpdateGrey.Name = "btnUpdateGrey"
        Me.btnUpdateGrey.Size = New System.Drawing.Size(73, 32)
        Me.btnUpdateGrey.TabIndex = 27
        Me.btnUpdateGrey.Text = "Upd. Grey"
        Me.btnUpdateGrey.UseVisualStyleBackColor = True
        '
        'frmUpdateLoomSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 417)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmUpdateLoomSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Update Loom Setting"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.DGUpdateLoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtPlanMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtLoomNo As System.Windows.Forms.TextBox
    Friend WithEvents txtGreyNo2 As System.Windows.Forms.TextBox
    Friend WithEvents btnCariDetail2 As System.Windows.Forms.Button
    Friend WithEvents btnCariDetail As System.Windows.Forms.Button
    Friend WithEvents ceboxDrawIn As System.Windows.Forms.CheckBox
    Friend WithEvents txtGreyNO1 As System.Windows.Forms.TextBox
    Friend WithEvents dtpPlanDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnDailyLoom As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnModify As System.Windows.Forms.Button
    Friend WithEvents btnMachineLayout As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DGUpdateLoom As System.Windows.Forms.DataGridView
    Friend WithEvents btnUpdateGrey As System.Windows.Forms.Button
End Class
