Partial Class ConfiguracionForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Private WithEvents cmbColores As System.Windows.Forms.ComboBox
    Private WithEvents pnlPreview As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.cmbColores = New System.Windows.Forms.ComboBox()
        Me.pnlPreview = New System.Windows.Forms.Panel()
        Me.SuspendLayout()

        Me.cmbColores.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbColores.FormattingEnabled = True
        Me.cmbColores.Location = New System.Drawing.Point(30, 30)
        Me.cmbColores.Name = "cmbColores"
        Me.cmbColores.Size = New System.Drawing.Size(200, 24)
        Me.cmbColores.TabIndex = 0
        Me.cmbColores.BackColor = Color.FromArgb(209, 255, 221)
        Me.cmbColores.ForeColor = Color.Black
        Me.cmbColores.FlatStyle = FlatStyle.Flat

        Me.pnlPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlPreview.Location = New System.Drawing.Point(250, 30)
        Me.pnlPreview.Name = "pnlPreview"
        Me.pnlPreview.Size = New System.Drawing.Size(60, 24)
        Me.pnlPreview.TabIndex = 1
        Me.pnlPreview.BackColor = Color.FromArgb(75, 190, 154)

        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = Color.FromArgb(163, 225, 201)
        Me.ClientSize = New System.Drawing.Size(340, 90)
        Me.Controls.Add(Me.pnlPreview)
        Me.Controls.Add(Me.cmbColores)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ConfiguracionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Configuración de Color"
        Me.ResumeLayout(False)
    End Sub
End Class
