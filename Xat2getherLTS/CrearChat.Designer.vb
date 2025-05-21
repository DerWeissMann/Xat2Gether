<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CrearChat
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
        btnCrearChat = New Button()
        SuspendLayout()
        ' 
        ' chkUsuarios
        ' 
        chkUsuarios.BackColor = Color.FromArgb(CByte(163), CByte(225), CByte(201))
        chkUsuarios.BorderStyle = BorderStyle.None
        chkUsuarios.Font = New Font("Segoe UI", 10F)
        chkUsuarios.ForeColor = Color.Black
        chkUsuarios.FormattingEnabled = True
        chkUsuarios.Location = New Point(12, 12)
        chkUsuarios.Name = "chkUsuarios"
        chkUsuarios.Size = New Size(776, 380)
        chkUsuarios.TabIndex = 0
        ' 
        ' txtNombreGrupo
        ' 
        txtNombreGrupo.BackColor = Color.FromArgb(CByte(209), CByte(255), CByte(221))
        txtNombreGrupo.BorderStyle = BorderStyle.FixedSingle
        txtNombreGrupo.Font = New Font("Segoe UI", 10F)
        txtNombreGrupo.ForeColor = Color.Black
        txtNombreGrupo.Location = New Point(12, 400)
        txtNombreGrupo.Name = "txtNombreGrupo"
        txtNombreGrupo.Size = New Size(618, 25)
        txtNombreGrupo.TabIndex = 1
        txtNombreGrupo.Text = "TITULO"
        ' 
        ' btnCrearChat
        ' 
        btnCrearChat.BackColor = Color.FromArgb(CByte(75), CByte(190), CByte(154))
        btnCrearChat.FlatStyle = FlatStyle.Flat
        btnCrearChat.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        btnCrearChat.ForeColor = Color.White
        btnCrearChat.Location = New Point(633, 400)
        btnCrearChat.Name = "btnCrearChat"
        btnCrearChat.Size = New Size(155, 25)
        btnCrearChat.TabIndex = 2
        btnCrearChat.Text = "CREAR GRUPO"
        btnCrearChat.UseVisualStyleBackColor = False
        ' 
        ' CrearChat
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(209), CByte(255), CByte(221))
        ClientSize = New Size(800, 433)
        Controls.Add(btnCrearChat)
        Controls.Add(txtNombreGrupo)
        Controls.Add(chkUsuarios)
        MaximizeBox = False
        MinimizeBox = False
        Name = "CrearChat"
        ShowIcon = False
        Text = "Nuevo Grupo"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents chkUsuarios As CheckedListBox
    Friend WithEvents txtNombreGrupo As TextBox
    Friend WithEvents btnCrearChat As Button
End Class
