<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlanVsActual
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
        Me.tgl_input = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.rbReguler = New System.Windows.Forms.RadioButton()
        Me.rbGarment = New System.Windows.Forms.RadioButton()
        Me.rbAll = New System.Windows.Forms.RadioButton()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.tgl_input)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.rbReguler)
        Me.Panel1.Controls.Add(Me.rbGarment)
        Me.Panel1.Controls.Add(Me.rbAll)
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Location = New System.Drawing.Point(4, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(342, 223)
        Me.Panel1.TabIndex = 22
        '
        'tgl_input
        '
        Me.tgl_input.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.tgl_input.Location = New System.Drawing.Point(128, 36)
        Me.tgl_input.MaxDate = New Date(2109, 12, 31, 0, 0, 0, 0)
        Me.tgl_input.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.tgl_input.Name = "tgl_input"
        Me.tgl_input.Size = New System.Drawing.Size(100, 20)
        Me.tgl_input.TabIndex = 29
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(78, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Grade :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(78, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Date :"
        '
        'rbReguler
        '
        Me.rbReguler.AutoSize = True
        Me.rbReguler.Location = New System.Drawing.Point(133, 122)
        Me.rbReguler.Name = "rbReguler"
        Me.rbReguler.Size = New System.Drawing.Size(62, 17)
        Me.rbReguler.TabIndex = 26
        Me.rbReguler.Text = "Reguler"
        Me.rbReguler.UseVisualStyleBackColor = True
        '
        'rbGarment
        '
        Me.rbGarment.AutoSize = True
        Me.rbGarment.Location = New System.Drawing.Point(133, 98)
        Me.rbGarment.Name = "rbGarment"
        Me.rbGarment.Size = New System.Drawing.Size(65, 17)
        Me.rbGarment.TabIndex = 25
        Me.rbGarment.Text = "Garment"
        Me.rbGarment.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(133, 75)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(36, 17)
        Me.rbAll.TabIndex = 24
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(103, 165)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(111, 43)
        Me.btnPrint.TabIndex = 23
        Me.btnPrint.Text = "To Excell"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'frmPlanVsActual
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 236)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmPlanVsActual"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WPPC- Plan vs Actual"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents tgl_input As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rbReguler As System.Windows.Forms.RadioButton
    Friend WithEvents rbGarment As System.Windows.Forms.RadioButton
    Friend WithEvents rbAll As System.Windows.Forms.RadioButton
End Class
