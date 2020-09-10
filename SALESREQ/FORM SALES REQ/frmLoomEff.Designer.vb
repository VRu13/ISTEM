<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoomeff
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
        Me.SuspendLayout()
        '
        'cmbPlanMonthedit
        '
        Me.cmbPlanMonthedit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbPlanMonthedit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbPlanMonthedit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPlanMonthedit.FormattingEnabled = True
        Me.cmbPlanMonthedit.Location = New System.Drawing.Point(163, 42)
        Me.cmbPlanMonthedit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPlanMonthedit.Name = "cmbPlanMonthedit"
        Me.cmbPlanMonthedit.Size = New System.Drawing.Size(139, 24)
        Me.cmbPlanMonthedit.TabIndex = 231
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(163, 101)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(139, 34)
        Me.BtnCancel.TabIndex = 230
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 23)
        Me.Label6.TabIndex = 229
        Me.Label6.Text = "Plan Month"
        '
        'BtnView
        '
        Me.BtnView.Location = New System.Drawing.Point(12, 101)
        Me.BtnView.Name = "BtnView"
        Me.BtnView.Size = New System.Drawing.Size(115, 34)
        Me.BtnView.TabIndex = 228
        Me.BtnView.Text = "View"
        Me.BtnView.UseVisualStyleBackColor = True
        '
        'frmLoomeff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(324, 172)
        Me.Controls.Add(Me.cmbPlanMonthedit)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnView)
        Me.MaximizeBox = False
        Me.Name = "frmLoomeff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Report Loom Efficency"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbPlanMonthedit As System.Windows.Forms.ComboBox
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents BtnView As System.Windows.Forms.Button
End Class
