
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GestionGrupoForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lstUsuariosGrupo = New ListBox()
        lstUsuariosDisponibles = New ListBox()
        btnAgregar = New Button()
        btnExpulsar = New Button()
        lblMiembros = New Label()
        lblDisponibles = New Label()
        txtNuevoNombre = New TextBox()
        btnCambiarNombre = New Button()
        SuspendLayout()
        ' 
        ' lstUsuariosGrupo
        ' 
        lstUsuariosGrupo.BackColor = Color.FromArgb(CByte(163), CByte(225), CByte(201))
        lstUsuariosGrupo.Font = New Font("Segoe UI", 10F)
        lstUsuariosGrupo.ForeColor = Color.Black
        lstUsuariosGrupo.FormattingEnabled = True
        lstUsuariosGrupo.ItemHeight = 17
        lstUsuariosGrupo.Location = New Point(30, 50)
        lstUsuariosGrupo.Name = "lstUsuariosGrupo"
        lstUsuariosGrupo.Size = New Size(300, 310)
        lstUsuariosGrupo.TabIndex = 0
        ' 
        ' lstUsuariosDisponibles
        ' 
        lstUsuariosDisponibles.BackColor = Color.FromArgb(CByte(209), CByte(255), CByte(221))
        lstUsuariosDisponibles.Font = New Font("Segoe UI", 10F)
        lstUsuariosDisponibles.ForeColor = Color.Black
        lstUsuariosDisponibles.FormattingEnabled = True
        lstUsuariosDisponibles.ItemHeight = 17
        lstUsuariosDisponibles.Location = New Point(370, 50)
        lstUsuariosDisponibles.Name = "lstUsuariosDisponibles"
        lstUsuariosDisponibles.Size = New Size(300, 310)
        lstUsuariosDisponibles.TabIndex = 1
        ' 
        ' btnAgregar
        ' 
        btnAgregar.BackColor = Color.FromArgb(CByte(42), CByte(157), CByte(124))
        btnAgregar.FlatStyle = FlatStyle.Flat
        btnAgregar.Font = New Font("Segoe UI", 10F)
        btnAgregar.ForeColor = Color.White
        btnAgregar.Location = New Point(370, 375)
        btnAgregar.Name = "btnAgregar"
        btnAgregar.Size = New Size(75, 30)
        btnAgregar.TabIndex = 2
        btnAgregar.Text = "→"
        btnAgregar.UseVisualStyleBackColor = False
        ' 
        ' btnExpulsar
        ' 
        btnExpulsar.BackColor = Color.FromArgb(CByte(75), CByte(190), CByte(154))
        btnExpulsar.FlatStyle = FlatStyle.Flat
        btnExpulsar.Font = New Font("Segoe UI", 10F)
        btnExpulsar.ForeColor = Color.White
        btnExpulsar.Location = New Point(255, 375)
        btnExpulsar.Name = "btnExpulsar"
        btnExpulsar.Size = New Size(75, 30)
        btnExpulsar.TabIndex = 3
        btnExpulsar.Text = "←"
        btnExpulsar.UseVisualStyleBackColor = False
        ' 
        ' lblMiembros
        ' 
        lblMiembros.AutoSize = True
        lblMiembros.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblMiembros.ForeColor = Color.FromArgb(CByte(42), CByte(157), CByte(124))
        lblMiembros.Location = New Point(30, 25)
        lblMiembros.Name = "lblMiembros"
        lblMiembros.Size = New Size(151, 19)
        lblMiembros.TabIndex = 4
        lblMiembros.Text = "Miembros del grupo:"
        ' 
        ' lblDisponibles
        ' 
        lblDisponibles.AutoSize = True
        lblDisponibles.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        lblDisponibles.ForeColor = Color.FromArgb(CByte(42), CByte(157), CByte(124))
        lblDisponibles.Location = New Point(370, 25)
        lblDisponibles.Name = "lblDisponibles"
        lblDisponibles.Size = New Size(150, 19)
        lblDisponibles.TabIndex = 5
        lblDisponibles.Text = "Usuarios disponibles:"
        ' 
        ' txtNuevoNombre
        ' 
        txtNuevoNombre.BackColor = Color.WhiteSmoke
        txtNuevoNombre.BorderStyle = BorderStyle.FixedSingle
        txtNuevoNombre.ForeColor = Color.Black
        txtNuevoNombre.Location = New Point(12, 424)
        txtNuevoNombre.Name = "txtNuevoNombre"
        txtNuevoNombre.PlaceholderText = "Nuevo nombre del grupo"
        txtNuevoNombre.Size = New Size(502, 23)
        txtNuevoNombre.TabIndex = 0
        ' 
        ' btnCambiarNombre
        ' 
        btnCambiarNombre.BackColor = Color.FromArgb(CByte(75), CByte(190), CByte(154))
        btnCambiarNombre.FlatStyle = FlatStyle.Flat
        btnCambiarNombre.ForeColor = Color.White
        btnCambiarNombre.Location = New Point(520, 422)
        btnCambiarNombre.Name = "btnCambiarNombre"
        btnCambiarNombre.Size = New Size(150, 23)
        btnCambiarNombre.TabIndex = 1
        btnCambiarNombre.Text = "Cambiar nombre"
        btnCambiarNombre.UseVisualStyleBackColor = False
        ' 
        ' GestionGrupoForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(209), CByte(255), CByte(221))
        ClientSize = New Size(700, 461)
        Controls.Add(txtNuevoNombre)
        Controls.Add(btnCambiarNombre)
        Controls.Add(lblDisponibles)
        Controls.Add(lblMiembros)
        Controls.Add(btnExpulsar)
        Controls.Add(btnAgregar)
        Controls.Add(lstUsuariosDisponibles)
        Controls.Add(lstUsuariosGrupo)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "GestionGrupoForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Gestión de Grupo"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lstUsuariosGrupo As ListBox
    Friend WithEvents lstUsuariosDisponibles As ListBox
    Friend WithEvents btnAgregar As Button
    Friend WithEvents btnExpulsar As Button
    Friend WithEvents lblMiembros As Label
    Friend WithEvents lblDisponibles As Label
    Friend WithEvents txtNuevoNombre As TextBox
    Friend WithEvents btnCambiarNombre As Button

End Class
