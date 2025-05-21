Imports System.Drawing.Drawing2D

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainChatForm
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
        components = New ComponentModel.Container()
        lstChats = New ListBox()
        txtMensaje = New TextBox()
        btnEnviar = New Button()
        btnCrearGrupo = New Button()
        lblChatTitulo = New Label()
        btnNuevoChat = New Button()
        tmrActualizacion = New Timer(components)
        btnExportar = New Button()
        btnConfiguracion = New Button()
        btnSuperReaccion = New Button()
        scrollContenedor = New NoScrollPanel()
        pnlMensajes = New FlowLayoutPanel()
        scrollContenedor.SuspendLayout()
        SuspendLayout()
        ' 
        ' lstChats
        ' 
        lstChats.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        lstChats.BackColor = Color.FromArgb(CByte(163), CByte(225), CByte(201))
        lstChats.BorderStyle = BorderStyle.None
        lstChats.Font = New Font("Segoe UI", 10.0F)
        lstChats.ForeColor = Color.Black
        lstChats.FormattingEnabled = True
        lstChats.ItemHeight = 17
        lstChats.Location = New Point(12, 42)
        lstChats.Name = "lstChats"
        lstChats.Size = New Size(411, 680)
        lstChats.TabIndex = 0
        ' 
        ' txtMensaje
        ' 
        txtMensaje.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtMensaje.Location = New Point(429, 699)
        txtMensaje.Name = "txtMensaje"
        txtMensaje.Size = New Size(820, 23)
        txtMensaje.TabIndex = 2
        ' 
        ' btnEnviar
        ' 
        btnEnviar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnEnviar.BackColor = Color.FromArgb(CByte(42), CByte(157), CByte(124))
        btnEnviar.FlatStyle = FlatStyle.Flat
        btnEnviar.ForeColor = Color.White
        btnEnviar.Location = New Point(1290, 699)
        btnEnviar.Name = "btnEnviar"
        btnEnviar.Size = New Size(105, 23)
        btnEnviar.TabIndex = 3
        btnEnviar.Text = "ENVIAR"
        btnEnviar.UseVisualStyleBackColor = False
        ' 
        ' btnCrearGrupo
        ' 
        btnCrearGrupo.BackColor = Color.FromArgb(CByte(128), CByte(214), CByte(177))
        btnCrearGrupo.FlatStyle = FlatStyle.Flat
        btnCrearGrupo.ForeColor = Color.Black
        btnCrearGrupo.Location = New Point(11, 7)
        btnCrearGrupo.Name = "btnCrearGrupo"
        btnCrearGrupo.Size = New Size(109, 29)
        btnCrearGrupo.TabIndex = 4
        btnCrearGrupo.Text = "NUEVO XAT"
        btnCrearGrupo.UseVisualStyleBackColor = False
        ' 
        ' lblChatTitulo
        ' 
        lblChatTitulo.Anchor = AnchorStyles.Top
        lblChatTitulo.AutoSize = True
        lblChatTitulo.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblChatTitulo.ForeColor = Color.FromArgb(CByte(42), CByte(157), CByte(124))
        lblChatTitulo.Location = New Point(863, 4)
        lblChatTitulo.Name = "lblChatTitulo"
        lblChatTitulo.Size = New Size(0, 32)
        lblChatTitulo.TabIndex = 5
        ' 
        ' btnNuevoChat
        ' 
        btnNuevoChat.BackColor = Color.FromArgb(CByte(128), CByte(214), CByte(177))
        btnNuevoChat.FlatStyle = FlatStyle.Flat
        btnNuevoChat.ForeColor = Color.Black
        btnNuevoChat.Location = New Point(126, 7)
        btnNuevoChat.Name = "btnNuevoChat"
        btnNuevoChat.Size = New Size(108, 29)
        btnNuevoChat.TabIndex = 6
        btnNuevoChat.Text = "CERRAR SESIÓN"
        btnNuevoChat.UseVisualStyleBackColor = False
        ' 
        ' tmrActualizacion
        ' 
        ' 
        ' btnExportar
        ' 
        btnExportar.BackColor = Color.FromArgb(CByte(128), CByte(214), CByte(177))
        btnExportar.FlatStyle = FlatStyle.Flat
        btnExportar.ForeColor = Color.Black
        btnExportar.Location = New Point(240, 7)
        btnExportar.Name = "btnExportar"
        btnExportar.Size = New Size(108, 29)
        btnExportar.TabIndex = 7
        btnExportar.Text = "EXPORTAR"
        btnExportar.UseVisualStyleBackColor = False
        ' 
        ' btnConfiguracion
        ' 
        btnConfiguracion.BackColor = Color.FromArgb(CByte(128), CByte(214), CByte(177))
        btnConfiguracion.FlatStyle = FlatStyle.Flat
        btnConfiguracion.ForeColor = Color.Black
        btnConfiguracion.Location = New Point(358, 7)
        btnConfiguracion.Name = "btnConfiguracion"
        btnConfiguracion.Size = New Size(65, 29)
        btnConfiguracion.TabIndex = 8
        btnConfiguracion.Text = "⚙"
        btnConfiguracion.UseVisualStyleBackColor = False
        ' 
        ' btnSuperReaccion
        ' 
        btnSuperReaccion.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnSuperReaccion.BackColor = Color.FromArgb(CByte(75), CByte(190), CByte(154))
        btnSuperReaccion.FlatStyle = FlatStyle.Flat
        btnSuperReaccion.ForeColor = Color.White
        btnSuperReaccion.Location = New Point(1255, 699)
        btnSuperReaccion.Name = "btnSuperReaccion"
        btnSuperReaccion.Size = New Size(29, 23)
        btnSuperReaccion.TabIndex = 9
        btnSuperReaccion.Text = "🎯"
        btnSuperReaccion.UseVisualStyleBackColor = False
        ' 
        ' scrollContenedor
        ' 
        scrollContenedor.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        scrollContenedor.AutoScroll = True
        scrollContenedor.BackColor = Color.FromArgb(CByte(209), CByte(255), CByte(221))
        scrollContenedor.Controls.Add(pnlMensajes)
        scrollContenedor.Location = New Point(429, 43)
        scrollContenedor.Name = "scrollContenedor"
        scrollContenedor.Size = New Size(967, 649)
        scrollContenedor.TabIndex = 10
        ' 
        ' pnlMensajes
        ' 
        pnlMensajes.AutoScroll = True
        pnlMensajes.BackColor = Color.FromArgb(CByte(209), CByte(255), CByte(221))
        pnlMensajes.Dock = DockStyle.Fill
        pnlMensajes.FlowDirection = FlowDirection.TopDown
        pnlMensajes.Location = New Point(0, 0)
        pnlMensajes.Name = "pnlMensajes"
        pnlMensajes.Size = New Size(967, 649)
        pnlMensajes.TabIndex = 0
        pnlMensajes.WrapContents = False
        ' 
        ' MainChatForm
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(209), CByte(255), CByte(221))
        ClientSize = New Size(1408, 733)
        Controls.Add(btnSuperReaccion)
        Controls.Add(btnConfiguracion)
        Controls.Add(btnExportar)
        Controls.Add(btnNuevoChat)
        Controls.Add(lblChatTitulo)
        Controls.Add(btnCrearGrupo)
        Controls.Add(btnEnviar)
        Controls.Add(txtMensaje)
        Controls.Add(scrollContenedor)
        Controls.Add(lstChats)
        Name = "MainChatForm"
        Text = "Xat2gether"
        scrollContenedor.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Private Sub ApplyRoundedCorners(control As Control, radius As Integer)
        Dim path As New GraphicsPath()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(control.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, control.Height - radius, radius, radius, 90, 90)
        path.CloseAllFigures()
        control.Region = New Region(path)
    End Sub

    Friend WithEvents lstChats As ListBox
    Friend WithEvents txtMensaje As TextBox
    Friend WithEvents btnEnviar As Button
    Friend WithEvents btnCrearGrupo As Button
    Friend WithEvents lblChatTitulo As Label
    Friend WithEvents btnNuevoChat As Button
    Friend WithEvents tmrActualizacion As Timer
    Friend WithEvents btnExportar As Button
    Friend WithEvents btnConfiguracion As Button
    Friend WithEvents btnSuperReaccion As Button
    Private scrollContenedor As NoScrollPanel
    Private pnlMensajes As FlowLayoutPanel
End Class
