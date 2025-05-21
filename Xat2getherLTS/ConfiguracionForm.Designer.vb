Partial Class ConfiguracionForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Private WithEvents cmbColores As System.Windows.Forms.ComboBox
    Private WithEvents pnlPreview As System.Windows.Forms.Panel
    Private WithEvents txtNuevoNombre As TextBox
    Private WithEvents btnGuardarNombre As Button
    Private WithEvents btnEliminarCuenta As Button


    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        cmbColores = New ComboBox()
        pnlPreview = New Panel()
        txtNuevoNombre = New TextBox()
        btnGuardarNombre = New Button()
        btnEliminarCuenta = New Button()
        SuspendLayout()
        ' 
        ' cmbColores
        ' 
        cmbColores.BackColor = Color.FromArgb(CByte(209), CByte(255), CByte(221))
        cmbColores.DropDownStyle = ComboBoxStyle.DropDownList
        cmbColores.FlatStyle = FlatStyle.Flat
        cmbColores.ForeColor = Color.Black
        cmbColores.FormattingEnabled = True
        cmbColores.Location = New Point(26, 28)
        cmbColores.Name = "cmbColores"
        cmbColores.Size = New Size(176, 23)
        cmbColores.TabIndex = 0
        ' 
        ' pnlPreview
        ' 
        pnlPreview.BackColor = Color.FromArgb(CByte(75), CByte(190), CByte(154))
        pnlPreview.BorderStyle = BorderStyle.FixedSingle
        pnlPreview.Location = New Point(219, 28)
        pnlPreview.Name = "pnlPreview"
        pnlPreview.Size = New Size(53, 23)
        pnlPreview.TabIndex = 1
        ' 
        ' txtNuevoNombre
        ' 
        txtNuevoNombre.BackColor = Color.White
        txtNuevoNombre.ForeColor = Color.Black
        txtNuevoNombre.Location = New Point(26, 66)
        txtNuevoNombre.Name = "txtNuevoNombre"
        txtNuevoNombre.PlaceholderText = "Nuevo nombre"
        txtNuevoNombre.Size = New Size(176, 23)
        txtNuevoNombre.TabIndex = 2
        ' 
        ' btnGuardarNombre
        ' 
        btnGuardarNombre.BackColor = Color.FromArgb(CByte(42), CByte(157), CByte(124))
        btnGuardarNombre.FlatStyle = FlatStyle.Flat
        btnGuardarNombre.ForeColor = Color.White
        btnGuardarNombre.Location = New Point(219, 66)
        btnGuardarNombre.Name = "btnGuardarNombre"
        btnGuardarNombre.Size = New Size(52, 22)
        btnGuardarNombre.TabIndex = 3
        btnGuardarNombre.Text = "Guardar"
        btnGuardarNombre.UseVisualStyleBackColor = False
        ' 
        ' btnEliminarCuenta
        ' 
        btnEliminarCuenta.BackColor = Color.FromArgb(CByte(220), CByte(53), CByte(69))
        btnEliminarCuenta.FlatStyle = FlatStyle.Flat
        btnEliminarCuenta.ForeColor = Color.White
        btnEliminarCuenta.Location = New Point(26, 103)
        btnEliminarCuenta.Name = "btnEliminarCuenta"
        btnEliminarCuenta.Size = New Size(245, 28)
        btnEliminarCuenta.TabIndex = 4
        btnEliminarCuenta.Text = "Eliminar cuenta"
        btnEliminarCuenta.UseVisualStyleBackColor = False
        ' 
        ' ConfiguracionForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(163), CByte(225), CByte(201))
        ClientSize = New Size(298, 159)
        Controls.Add(pnlPreview)
        Controls.Add(cmbColores)
        Controls.Add(txtNuevoNombre)
        Controls.Add(btnGuardarNombre)
        Controls.Add(btnEliminarCuenta)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "ConfiguracionForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Configuración de Color"
        ResumeLayout(False)
        PerformLayout()

    End Sub
End Class
