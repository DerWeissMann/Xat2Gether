Partial Class NuevoChatForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer
    Private lstUsuarios As System.Windows.Forms.ListBox

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lstUsuarios = New ListBox()
        btnIniciarChat = New Button()
        SuspendLayout()

        lstUsuarios.BackColor = Color.FromArgb(163, 225, 201)
        lstUsuarios.ForeColor = Color.Black
        lstUsuarios.BorderStyle = BorderStyle.None
        lstUsuarios.Font = New Font("Segoe UI", 10)
        lstUsuarios.FormattingEnabled = True
        lstUsuarios.ItemHeight = 18
        lstUsuarios.Location = New Point(10, 11)
        lstUsuarios.Name = "lstUsuarios"
        lstUsuarios.Size = New Size(280, 162)
        lstUsuarios.TabIndex = 0

        btnIniciarChat.BackColor = Color.FromArgb(75, 190, 154)
        btnIniciarChat.FlatStyle = FlatStyle.Flat
        btnIniciarChat.ForeColor = Color.White
        btnIniciarChat.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold)
        btnIniciarChat.Location = New Point(9, 186)
        btnIniciarChat.Name = "btnIniciarChat"
        btnIniciarChat.Size = New Size(280, 31)
        btnIniciarChat.TabIndex = 2
        btnIniciarChat.Text = "INICIAR CHAT"
        btnIniciarChat.UseVisualStyleBackColor = False

        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(209, 255, 221)
        ClientSize = New Size(301, 227)
        Controls.Add(btnIniciarChat)
        Controls.Add(lstUsuarios)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "NuevoChatForm"
        StartPosition = FormStartPosition.CenterParent
        Text = "Nuevo chat privado"
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnIniciarChat As Button
End Class
