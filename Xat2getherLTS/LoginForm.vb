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

            GuardarSesionCifrada(id, nombre)
            Dim ventanaChat As New MainChatForm(id, nombre)
            Me.Close()
            ventanaChat.Show()

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

    Private claveAES As Byte() = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("clave-xat2gether"))

    Public Sub GuardarSesionCifrada(id As Integer, nombre As String)
        Dim datos = $"id={id};nombre={nombre}"
        Dim cifrado = Convert.ToBase64String(EncriptarAES(datos))
        File.WriteAllText(Path.Combine(Application.StartupPath, "account.txt"), cifrado)
    End Sub

    Public Function CargarSesionCifrada(ByRef id As Integer, ByRef nombre As String) As Boolean
        Dim ruta = Path.Combine(Application.StartupPath, "account.txt")
        If Not File.Exists(ruta) Then Return False

        Try
            Dim contenidoCifrado = File.ReadAllText(ruta)
            Dim textoPlano = DesencriptarAES(Convert.FromBase64String(contenidoCifrado))
            Dim partes = textoPlano.Split(";"c)

            For Each parte In partes
                If parte.StartsWith("id=") Then id = CInt(parte.Replace("id=", "").Trim())
                If parte.StartsWith("nombre=") Then nombre = parte.Replace("nombre=", "").Trim()
            Next

            Return id > 0 AndAlso nombre <> ""
        Catch
            Return False
        End Try
    End Function

    Public Sub BorrarSesion()
        Dim ruta = Path.Combine(Application.StartupPath, "account.txt")
        If File.Exists(ruta) Then File.Delete(ruta)
    End Sub

    Private Function EncriptarAES(texto As String) As Byte()
        Using aes As Aes = Aes.Create()
            aes.Key = claveAES
            aes.GenerateIV()
            Using ms As New MemoryStream()
                ms.Write(aes.IV, 0, aes.IV.Length)
                Using cs As New CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)
                    Dim bytes = Encoding.UTF8.GetBytes(texto)
                    cs.Write(bytes, 0, bytes.Length)
                    cs.FlushFinalBlock()
                End Using
                Return ms.ToArray()
            End Using
        End Using
    End Function

    Private Function DesencriptarAES(datos As Byte()) As String
        Using aes As Aes = Aes.Create()
            aes.Key = claveAES
            Dim iv = datos.Take(16).ToArray()
            Dim cifrado = datos.Skip(16).ToArray()
            aes.IV = iv
            Using ms As New MemoryStream(cifrado)
                Using cs As New CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read)
                    Using sr As New StreamReader(cs)
                        Return sr.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
    End Function
End Class