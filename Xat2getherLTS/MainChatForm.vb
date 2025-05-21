Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class MainChatForm
    Private usuarioId As Integer
    Private nombreUsuario As String
    Private chatActivoId As Integer
    Private ultimaFechaMensaje As DateTime = DateTime.MinValue
    Private colorUsuarioCache As New Dictionary(Of Integer, String)
    Private Function ObtenerCadenaConexionDesdeConfig() As String
        Dim ruta As String = Path.Combine(Application.StartupPath, "config.txt")

        If Not File.Exists(ruta) Then
            MessageBox.Show("No se encontró el archivo config.txt junto al ejecutable.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End If

        Try
            Dim contenidoCifrado = File.ReadAllText(ruta)
            Dim datosPlano = ConexionBD.DesencriptarAES(Convert.FromBase64String(contenidoCifrado))

            Dim servidor As String = ""
            Dim usuario As String = ""
            Dim contrasena As String = ""
            Dim baseDeDatos As String = ""

            For Each linea In datosPlano.Split({Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                If linea.StartsWith("servidor=") Then
                    servidor = linea.Replace("servidor=", "").Trim()
                ElseIf linea.StartsWith("usuario=") Then
                    usuario = linea.Replace("usuario=", "").Trim()
                ElseIf linea.StartsWith("contrasena=") Then
                    contrasena = linea.Replace("contrasena=", "").Trim()
                ElseIf linea.StartsWith("basededatos=") Then
                    baseDeDatos = linea.Replace("basededatos=", "").Trim()
                End If
            Next

            If servidor = "" OrElse usuario = "" OrElse contrasena = "" OrElse baseDeDatos = "" Then
                MessageBox.Show("El archivo config.txt está incompleto o mal formado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If

            Return $"Server={servidor};Database={baseDeDatos};Uid={usuario};Pwd={contrasena};SslMode=none;"
        Catch ex As Exception
            MessageBox.Show("Error al leer o desencriptar el archivo config.txt: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Function


    Private Function ObtenerColorUsuario(id As Integer) As String
        If colorUsuarioCache.ContainsKey(id) Then
            Return colorUsuarioCache(id)
        End If

        Dim color As String = "LightGreen"
        Dim cadenaConexion As String = ObtenerCadenaConexionDesdeConfig()
        Using conexionAux As New MySqlConnection(cadenaConexion)
            conexionAux.Open()
            Using cmd As New MySqlCommand("SELECT color_mensaje FROM usuarios WHERE id = @id", conexionAux)
                cmd.Parameters.AddWithValue("@id", id)
                Using reader = cmd.ExecuteReader()
                    If reader.Read() Then
                        color = reader("color_mensaje").ToString()
                    End If
                End Using
            End Using
        End Using

        colorUsuarioCache(id) = color
        Return color
    End Function

    Public Sub New(id As Integer, nombre As String)
        InitializeComponent()
        usuarioId = id
        nombreUsuario = nombre
        AddHandler lblChatTitulo.Click, AddressOf AbrirGestionGrupo
        AddHandler txtMensaje.KeyDown, AddressOf txtMensaje_KeyDown
        scrollContenedor.BackColor = Me.BackColor
        pnlMensajes.BackColor = Me.BackColor
    End Sub

    Private Sub MainChatForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarChats()
        tmrActualizacion.Interval = 5000
        tmrActualizacion.Start()
    End Sub
    Private Sub AbrirGestionGrupo(sender As Object, e As EventArgs)
        If chatActivoId <> 0 Then
            Dim gestionForm As New GestionGrupoForm(chatActivoId)
            gestionForm.ShowDialog()
            CargarMensajes(chatActivoId)
        End If
    End Sub

    Private Sub tmrActualizacion_Tick(sender As Object, e As EventArgs) Handles tmrActualizacion.Tick
        If chatActivoId = 0 Then Exit Sub

        Dim cmd As New MySqlCommand("SELECT MAX(fecha) FROM mensajes WHERE grupo_id = @id", conexion)
        cmd.Parameters.AddWithValue("@id", chatActivoId)

        Dim resultado = cmd.ExecuteScalar()
        If resultado IsNot DBNull.Value AndAlso Convert.ToDateTime(resultado) > ultimaFechaMensaje Then
            CargarMensajes(chatActivoId)
        End If
    End Sub


    Private Sub txtMensaje_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnEnviar.PerformClick()
        End If
    End Sub

    Private Sub ScrollAlFinal()
        If pnlMensajes.Controls.Count > 0 Then
            pnlMensajes.ScrollControlIntoView(pnlMensajes.Controls(pnlMensajes.Controls.Count - 1))
        End If
    End Sub

    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        Dim texto = txtMensaje.Text.Trim()
        If texto = "" Then Exit Sub

        Dim clave As Byte() = CryptoService.GenerarClaveGrupo(chatActivoId)
        Dim mensajeEncriptado = CryptoService.Encriptar(texto, clave)

        Dim cmd As New MySqlCommand("INSERT INTO mensajes (emisor_id, receptor_id, grupo_id, mensaje_encriptado) VALUES (@emisor, NULL, @grupo, @mensaje)", conexion)
        cmd.Parameters.AddWithValue("@emisor", usuarioId)
        cmd.Parameters.AddWithValue("@grupo", chatActivoId)
        cmd.Parameters.AddWithValue("@mensaje", mensajeEncriptado)
        cmd.ExecuteNonQuery()

        txtMensaje.Clear()
        CargarMensajes(chatActivoId)
    End Sub

    Private Sub lstChats_DrawItem(sender As Object, e As DrawItemEventArgs) Handles lstChats.DrawItem
        If e.Index < 0 Then Return

        Dim itemTexto As String = lstChats.Items(e.Index).ToString()
        Dim isNuevo As Boolean = itemTexto.Contains("[NUEVO]")
        e.DrawBackground()

        Dim bgColor As Color = If(isNuevo, Color.FromArgb(42, 157, 124), lstChats.BackColor)
        Dim textColor As Color = If(isNuevo, Color.White, lstChats.ForeColor)

        Using b As New SolidBrush(bgColor)
            e.Graphics.FillRectangle(b, e.Bounds)
        End Using

        Using f As New Font("Segoe UI", 10, FontStyle.Regular)
            Using brush As New SolidBrush(textColor)
                Dim cleanTexto = itemTexto
                e.Graphics.DrawString(cleanTexto, f, brush, e.Bounds.X + 5, e.Bounds.Y + 2)
            End Using
        End Using

        e.DrawFocusRectangle()
    End Sub

    Private Sub CargarChats()
        lstChats.Items.Clear()
        lstChats.DrawMode = DrawMode.OwnerDrawFixed
        Dim cmd As New MySqlCommand("
        SELECT g.id, g.nombre,
        (SELECT COUNT(*) FROM mensajes WHERE grupo_id = g.id AND sincronizado = FALSE AND emisor_id <> @yo) AS nuevos
        FROM grupo_usuarios gu
        JOIN grupos g ON gu.grupo_id = g.id
        WHERE gu.usuario_id = @yo", conexion)
        cmd.Parameters.AddWithValue("@yo", usuarioId)
        Dim reader = cmd.ExecuteReader()

        While reader.Read()
            Dim id As Integer = reader("id")
            Dim nombre As String = reader("nombre").ToString()
            Dim tieneNuevo As Boolean = Convert.ToInt32(reader("nuevos")) > 0
            Dim textoFormateado As String = nombre & If(tieneNuevo, " •", "") & $" [id:{id}]"

            lstChats.Items.Add(textoFormateado)
        End While
        reader.Close()
    End Sub


    Private Sub lstChats_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstChats.SelectedIndexChanged
        If lstChats.SelectedItem Is Nothing Then Exit Sub

        Dim texto = lstChats.SelectedItem.ToString()
        chatActivoId = CInt(texto.Split("[id:")(1).Replace("]", ""))

        lblChatTitulo.Text = texto.Replace("[id:" & chatActivoId & "]", "").Trim()
        CargarMensajes(chatActivoId)
    End Sub

    Private Sub CargarMensajes(grupoId As Integer)
        pnlMensajes.Controls.Clear()

        Dim clave = CryptoService.GenerarClaveGrupo(grupoId)
        Dim cmd As New MySqlCommand("SELECT m.*, u.nombre FROM mensajes m JOIN usuarios u ON m.emisor_id = u.id WHERE grupo_id = @grupo ORDER BY fecha", conexion)
        cmd.Parameters.AddWithValue("@grupo", grupoId)
        Dim reader = cmd.ExecuteReader()

        While reader.Read()
            Dim mensajeTexto As String = CryptoService.Desencriptar(reader("mensaje_encriptado").ToString(), clave)
            Dim emisorId = Convert.ToInt32(reader("emisor_id"))
            Dim nombre = reader("nombre").ToString()
            Dim colorHex = ObtenerColorUsuario(emisorId)

            Dim panelMsg As New Panel()
            panelMsg.Tag = reader("id")
            panelMsg.Padding = New Padding(10)
            panelMsg.AutoSize = True
            panelMsg.AutoSizeMode = AutoSizeMode.GrowAndShrink
            panelMsg.Margin = New Padding(5)


            If mensajeTexto.StartsWith("<img>") AndAlso mensajeTexto.EndsWith("</img>") Then
                Dim url As String = mensajeTexto.Replace("<img>", "").Replace("</img>", "").Trim()
                Dim pic As New PictureBox()
                pic.SizeMode = PictureBoxSizeMode.Zoom
                pic.Width = 200
                pic.Height = 150
                pic.ImageLocation = url
                panelMsg.Controls.Add(pic)
            Else
                Dim lbl As New Label()
                lbl.Text = If(emisorId = usuarioId, mensajeTexto, nombre & ": " & mensajeTexto)
                lbl.Text = CambiarTextos(lbl.Text)
                lbl.ForeColor = Color.Black
                lbl.Font = New Font("Segoe UI", 10)
                lbl.MaximumSize = New Size(400, 0)
                lbl.AutoSize = True
                panelMsg.Controls.Add(lbl)
            End If

            Try
                panelMsg.BackColor = Color.FromName(colorHex)
            Catch
                panelMsg.BackColor = Color.LightGray
            End Try

            pnlMensajes.Controls.Add(panelMsg)
            Dim menu As New ContextMenuStrip()
            Dim asignarItem As New ToolStripMenuItem("Asignar tarea")
            AddHandler asignarItem.Click, Sub(s, e)
                                              Dim mensajeId As Integer = CInt(panelMsg.Tag)
                                              Dim textoOriginal As String = ObtenerTextoMensaje(panelMsg)
                                              Dim nombreAsignado As String = ObtenerNombreDe(panelMsg)

                                              Dim f As New AsignarTareaForm(chatActivoId, mensajeId, nombreAsignado, textoOriginal, usuarioId)
                                              f.ShowDialog()
                                          End Sub
            menu.Items.Add(asignarItem)
            panelMsg.ContextMenuStrip = menu

        End While

        reader.Close()
        ultimaFechaMensaje = DateTime.Now

        Dim cmdSync As New MySqlCommand("UPDATE mensajes SET sincronizado = TRUE WHERE grupo_id = @grupo AND emisor_id <> @yo", conexion)
        cmdSync.Parameters.AddWithValue("@grupo", grupoId)
        cmdSync.Parameters.AddWithValue("@yo", usuarioId)
        cmdSync.ExecuteNonQuery()

        CargarChats()
        If pnlMensajes.Controls.Count > 0 Then
            pnlMensajes.ScrollControlIntoView(pnlMensajes.Controls(pnlMensajes.Controls.Count - 1))
        End If
    End Sub
    Private Function ObtenerNombreDe(panelMsg As Panel) As String
        If panelMsg.Controls.Count = 0 Then Return ""
        Dim lbl = TryCast(panelMsg.Controls(0), Label)
        If lbl Is Nothing Then Return ""

        Dim texto = lbl.Text
        If texto.Contains(":") Then
            Return texto.Split(":"c)(0).Trim()
        End If
        Return nombreUsuario
    End Function

    Private Function ObtenerTextoMensaje(panelMsg As Panel) As String
        If panelMsg.Controls.Count = 0 Then Return ""
        Dim lbl = TryCast(panelMsg.Controls(0), Label)
        If lbl Is Nothing Then Return ""

        Dim texto = lbl.Text
        If texto.Contains(":") Then
            Return texto.Substring(texto.IndexOf(":"c) + 1).Trim()
        End If
        Return texto
    End Function


    Public Sub RefrescarChatActivo()
        If chatActivoId = 0 Then Exit Sub
        CargarMensajes(chatActivoId)
    End Sub

    Private Function CambiarTextos(texto As String) As String
        Dim reemplazos As New Dictionary(Of String, String) From {
        {":)", "😊"},
        {":D", "😄"},
        {";)", "😉"},
        {":(", "☹️"},
        {";(", "😢"},
        {":P", "😋"},
        {"<3", "❤️"},
        {":o", "😮"},
        {":O", "😮"},
        {":|", "😐"},
        {":'(", "😭"},
        {":*", "😘"},
        {"q", "que"},
        {"xq", "porque"},
        {"xk", "porque"},
        {"d", "de"},
        {"t", "te"},
        {"k", "que"},
        {"bn", "bien"},
        {"tb", "también"},
        {"x", "por"},
        {"tqm", "te quiero mucho"},
        {"tmb", "también"},
        {"ntp", "no te preocupes"},
        {"pq", "porque"},
        {"xd", "😂"},
        {"lol", "😂"},
        {"omg", "¡madre mía!"},
        {"mierda", "💩"}
    }

        Dim palabras = texto.Split(" "c).ToList()

        For i = 0 To palabras.Count - 1
            Dim palabra = palabras(i).ToLower()
            If reemplazos.ContainsKey(palabra) Then
                palabras(i) = reemplazos(palabra)
            End If
        Next

        Return String.Join(" ", palabras)
    End Function


    Private Sub MostrarMensajesLocales(mensajes As List(Of String))
        pnlMensajes.Controls.Clear()
        Dim y As Integer = 10

        For Each msg In mensajes
            Dim lbl As New Label()
            lbl.Text = CambiarTextos(msg)
            lbl.AutoSize = True
            lbl.Top = y
            lbl.Left = 10
            pnlMensajes.Controls.Add(lbl)
            y += 30
        Next
    End Sub

    Private Sub btnCrearGrupo_Click(sender As Object, e As EventArgs) Handles btnCrearGrupo.Click
        Dim f As New CrearChat(usuarioId)
        f.ShowDialog()
        CargarChats()
    End Sub

    Private Sub btnTareas_Click(sender As Object, e As EventArgs) Handles btnTareas.Click
        Dim f As New VerTareasForm(usuarioId)
        f.ShowDialog()
    End Sub

    Private Sub btnConfiguracion_Click(sender As Object, e As EventArgs) Handles btnConfiguracion.Click
        Dim confFrm As New ConfiguracionForm(usuarioId)
        AddHandler confFrm.FormClosed, AddressOf ConfigFormClosed
        confFrm.Show()
    End Sub
    Private Sub ConfigFormClosed(sender As Object, e As FormClosedEventArgs)
        If chatActivoId = 0 Then Exit Sub
        CargarMensajes(chatActivoId)
    End Sub
    Public Sub LimpiarCacheColores()
        colorUsuarioCache.Clear()
    End Sub
    Private Sub btnImagen_Click(sender As Object, e As EventArgs) Handles btnImagen.Click
        Dim url As String = InputBox("Introduce la URL de la imagen:", "Insertar Imagen")

        If Not String.IsNullOrWhiteSpace(url) AndAlso (url.StartsWith("http://") OrElse url.StartsWith("https://")) Then
            Dim texto = $"<img>{url}</img>"
            Dim clave As Byte() = CryptoService.GenerarClaveGrupo(chatActivoId)
            Dim mensajeEncriptado = CryptoService.Encriptar(texto, clave)

            Dim cmd As New MySqlCommand("INSERT INTO mensajes (emisor_id, receptor_id, grupo_id, mensaje_encriptado) VALUES (@emisor, NULL, @grupo, @mensaje)", conexion)
            cmd.Parameters.AddWithValue("@emisor", usuarioId)
            cmd.Parameters.AddWithValue("@grupo", chatActivoId)
            cmd.Parameters.AddWithValue("@mensaje", mensajeEncriptado)
            cmd.ExecuteNonQuery()

            CargarMensajes(chatActivoId)
        Else
            MessageBox.Show("La URL no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub



    Private Sub btnCerrarSesion_Click(sender As Object, e As EventArgs) Handles btnCerrarSesion.Click
        BorrarSesion()
        Application.Restart()
        End
    End Sub

    Public Sub BorrarSesion()
        Dim ruta = Path.Combine(Application.StartupPath, "account.txt")
        If File.Exists(ruta) Then File.Delete(ruta)
    End Sub
End Class
