Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class LoginForm
    Private Sub txtMensaje_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContrasena.KeyDown, txtUsuario.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnLogin.PerformClick()
        End If
    End Sub
    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim id As Integer = 0
        Dim nombre As String = ""

    End Sub


    Private Function HashSHA256(texto As String) As String
        Dim sha256 As SHA256 = SHA256.Create()
        Dim bytesTexto As Byte() = Encoding.UTF8.GetBytes(texto)
        Dim hashBytes As Byte() = sha256.ComputeHash(bytesTexto)
        Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
    End Function

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim usuario = txtUsuario.Text.Trim()
        Dim contrasena = HashSHA256(txtContrasena.Text.Trim())

        Dim cmd As New MySqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario AND contrasena_hash = @contrasena", conexion)
        cmd.Parameters.AddWithValue("@usuario", usuario)
        cmd.Parameters.AddWithValue("@contrasena", contrasena)

        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        If reader.HasRows Then
            reader.Read()
            Dim id As Integer = CInt(reader("id"))
            Dim nombre As String = reader("nombre").ToString()
            reader.Close()
            Program.GuardarSesionCifrada(id, usuario, txtContrasena.Text.Trim())
            Application.Restart()

        Else
            reader.Close()
            MessageBox.Show("Usuario o contraseña incorrectos.")
        End If
    End Sub


    Private Sub btnRegistrar_Click(sender As Object, e As EventArgs) Handles btnRegistrar.Click
        Dim nombre = InputBox("Introduce tu nombre completo")
        Dim usuario = txtUsuario.Text.Trim()
        Dim contrasena = HashSHA256(txtContrasena.Text.Trim())

        Dim cmd As New MySqlCommand("INSERT INTO usuarios (nombre, usuario, contrasena_hash) VALUES (@nombre, @usuario, @contrasena)", conexion)
        cmd.Parameters.AddWithValue("@nombre", nombre)
        cmd.Parameters.AddWithValue("@usuario", usuario)
        cmd.Parameters.AddWithValue("@contrasena", contrasena)

        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Usuario registrado correctamente.")
        Catch ex As Exception
            MessageBox.Show("Error al registrar: " & ex.Message)
        End Try
    End Sub
End Class