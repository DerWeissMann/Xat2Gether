<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        txtUsuario = New TextBox()
        txtContrasena = New TextBox()
        btnLogin = New Button()
        btnRegistrar = New Button()
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.ForeColor = Color.FromArgb(CByte(42), CByte(157), CByte(124))
        Label1.Location = New Point(311, 121)
        Label1.Name = "Label1"
        Label1.Size = New Size(77, 21)
        Label1.TabIndex = 1
        Label1.Text = "USUARIO"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F)
        Label2.ForeColor = Color.FromArgb(CByte(42), CByte(157), CByte(124))
        Label2.Location = New Point(294, 202)
        Label2.Name = "Label2"
        Label2.Size = New Size(111, 21)
        Label2.TabIndex = 2
        Label2.Text = "CONTRASEÑA"
        ' 
        ' txtUsuario
        ' 
        txtUsuario.BackColor = Color.FromArgb(CByte(209), CByte(255), CByte(221))
        txtUsuario.BorderStyle = BorderStyle.FixedSingle
        txtUsuario.ForeColor = Color.Black
        txtUsuario.Location = New Point(137, 160)
        txtUsuario.Name = "txtUsuario"
        txtUsuario.Size = New Size(439, 23)
        txtUsuario.TabIndex = 3
        ' 
        ' txtContrasena
        ' 
        txtContrasena.BackColor = Color.FromArgb(CByte(209), CByte(255), CByte(221))
        txtContrasena.BorderStyle = BorderStyle.FixedSingle
        txtContrasena.ForeColor = Color.Black
        txtContrasena.Location = New Point(137, 240)
        txtContrasena.Name = "txtContrasena"
        txtContrasena.Size = New Size(439, 23)
        txtContrasena.TabIndex = 4
        ' 
        ' btnLogin
        ' 
        btnLogin.BackColor = Color.FromArgb(CByte(75), CByte(190), CByte(154))
        btnLogin.FlatStyle = FlatStyle.Flat
        btnLogin.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnLogin.ForeColor = Color.White
        btnLogin.Location = New Point(137, 316)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(439, 80)
        btnLogin.TabIndex = 5
        btnLogin.Text = "INICIAR SESIÓN"
        btnLogin.UseVisualStyleBackColor = False
        ' 
        ' btnRegistrar
        ' 
        btnRegistrar.BackColor = Color.FromArgb(CByte(128), CByte(214), CByte(177))
        btnRegistrar.FlatStyle = FlatStyle.Flat
        btnRegistrar.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        btnRegistrar.ForeColor = Color.White
        btnRegistrar.Location = New Point(137, 434)
        btnRegistrar.Name = "btnRegistrar"
        btnRegistrar.Size = New Size(439, 41)
        btnRegistrar.TabIndex = 6
        btnRegistrar.Text = "REGISTRARSE"
        btnRegistrar.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.logo
        PictureBox1.Location = New Point(294, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(111, 91)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' LoginForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(163), CByte(225), CByte(201))
        ClientSize = New Size(700, 537)
        Controls.Add(PictureBox1)
        Controls.Add(btnRegistrar)
        Controls.Add(btnLogin)
        Controls.Add(txtContrasena)
        Controls.Add(txtUsuario)
        Controls.Add(Label2)
        Controls.Add(Label1)
        ForeColor = Color.Black
        Margin = New Padding(3, 2, 3, 2)
        MaximizeBox = False
        MinimizeBox = False
        Name = "LoginForm"
        ShowIcon = False
        Text = "Xat2gether - Iniciar sesión"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents titulolbl As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents txtContrasena As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnRegistrar As Button
    Friend WithEvents PictureBox1 As PictureBox

End Class
