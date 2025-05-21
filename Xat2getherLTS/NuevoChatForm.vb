Imports MySql.Data.MySqlClient

Public Class NuevoChatForm
    Private idActual As Integer

    Public Sub New(usuarioId As Integer)
        InitializeComponent()
        idActual = usuarioId
    End Sub

    Private Sub NuevoChatForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New MySqlCommand("SELECT id, nombre FROM usuarios WHERE id <> @yo", conexion)
        cmd.Parameters.AddWithValue("@yo", idActual)
        Dim reader = cmd.ExecuteReader()

        While reader.Read()
            Dim id = reader("id")
            Dim nombre = reader("nombre").ToString()
            lstUsuarios.Items.Add(nombre & " [id:" & id & "]")
        End While
        reader.Close()
    End Sub

    Private Sub btnIniciarChat_Click(sender As Object, e As EventArgs) Handles btnIniciarChat.Click
        If lstUsuarios.SelectedItem Is Nothing Then Exit Sub

        Dim texto = lstUsuarios.SelectedItem.ToString()
        Dim idOtro = CInt(texto.Split("[id:")(1).Replace("]", ""))

        Dim clave = CryptoService.GenerarClaveAES(idActual, idOtro)
        Dim mensajeInicial = CryptoService.Encriptar("(chat iniciado)", clave)

        Dim cmd As New MySqlCommand("INSERT INTO mensajes (emisor_id, receptor_id, mensaje_encriptado, sincronizado) VALUES (@emisor, @receptor, @mensaje, TRUE)", conexion)
        cmd.Parameters.AddWithValue("@emisor", idActual)
        cmd.Parameters.AddWithValue("@receptor", idOtro)
        cmd.Parameters.AddWithValue("@mensaje", mensajeInicial)
        cmd.ExecuteNonQuery()

        MessageBox.Show("Chat iniciado.")
        Me.Close()
    End Sub
End Class
