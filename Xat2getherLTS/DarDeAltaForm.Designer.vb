<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DarDeAltaForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtServidor = New System.Windows.Forms.TextBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtContrasena = New System.Windows.Forms.TextBox()
        Me.txtBaseDeDatos = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtServidor
        '
        Me.txtServidor.Location = New System.Drawing.Point(30, 30)
        Me.txtServidor.Name = "txtServidor"
        Me.txtServidor.PlaceholderText = "Servidor"
        Me.txtServidor.Size = New System.Drawing.Size(240, 23)
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(30, 70)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.PlaceholderText = "Usuario"
        Me.txtUsuario.Size = New System.Drawing.Size(240, 23)
        '
        'txtContrasena
        '
        Me.txtContrasena.Location = New System.Drawing.Point(30, 110)
        Me.txtContrasena.Name = "txtContrasena"
        Me.txtContrasena.PlaceholderText = "Contraseña"
        Me.txtContrasena.UseSystemPasswordChar = True
        Me.txtContrasena.Size = New System.Drawing.Size(240, 23)
        '
        'txtBaseDeDatos
        '
        Me.txtBaseDeDatos.Location = New System.Drawing.Point(30, 150)
        Me.txtBaseDeDatos.Name = "txtBaseDeDatos"
        Me.txtBaseDeDatos.PlaceholderText = "Base de Datos"
        Me.txtBaseDeDatos.Size = New System.Drawing.Size(240, 23)
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(30, 190)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(240, 30)
        Me.btnGuardar.Text = "Guardar configuración"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'DarDeAltaForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(300, 250)
        Me.Controls.Add(Me.txtServidor)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.txtContrasena)
        Me.Controls.Add(Me.txtBaseDeDatos)
        Me.Controls.Add(Me.btnGuardar)
        Me.Name = "DarDeAltaForm"
        Me.Text = "Alta configuración BD"
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents txtServidor As TextBox
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents txtBaseDeDatos As TextBox
    Friend WithEvents btnGuardar As Button
End Class
