<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CrearGrupoForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
        chkUsuarios = New CheckedListBox()
        txtNombreGrupo = New TextBox()
        btnCrearGrupo = New Button()
        SuspendLayout()

        chkUsuarios.BackColor = Color.FromArgb(163, 225, 201)
        chkUsuarios.ForeColor = Color.Black
        chkUsuarios.BorderStyle = BorderStyle.None
        chkUsuarios.Font = New Font("Segoe UI", 10)
        chkUsuarios.FormattingEnabled = True
        chkUsuarios.Location = New Point(12, 12)
        chkUsuarios.Name = "chkUsuarios"
        chkUsuarios.Size = New Size(776, 382)
        chkUsuarios.TabIndex = 0

        txtNombreGrupo.BackColor = Color.FromArgb(209, 255, 221)
        txtNombreGrupo.ForeColor = Color.Black
        txtNombreGrupo.BorderStyle = BorderStyle.FixedSingle
        txtNombreGrupo.Font = New Font("Segoe UI", 10)
        txtNombreGrupo.Location = New Point(12, 400)
        txtNombreGrupo.Name = "txtNombreGrupo"
        txtNombreGrupo.Size = New Size(618, 25)
        txtNombreGrupo.TabIndex = 1
        txtNombreGrupo.Text = "TITULO"

        btnCrearGrupo.BackColor = Color.FromArgb(75, 190, 154)
        btnCrearGrupo.FlatStyle = FlatStyle.Flat
        btnCrearGrupo.ForeColor = Color.White
        btnCrearGrupo.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnCrearGrupo.Location = New Point(633, 400)
        btnCrearGrupo.Name = "btnCrearGrupo"
        btnCrearGrupo.Size = New Size(155, 25)
        btnCrearGrupo.TabIndex = 2
        btnCrearGrupo.Text = "CREAR GRUPO"
        btnCrearGrupo.UseVisualStyleBackColor = False

        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(209, 255, 221)
        ClientSize = New Size(800, 433)
        Controls.Add(btnCrearGrupo)
        Controls.Add(txtNombreGrupo)
        Controls.Add(chkUsuarios)
        Name = "CrearGrupoForm"
        Text = "Nuevo Grupo"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents chkUsuarios As CheckedListBox
    Friend WithEvents txtNombreGrupo As TextBox
    Friend WithEvents btnCrearGrupo As Button
End Class
