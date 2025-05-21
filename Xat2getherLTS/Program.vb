Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient

Module Program
    <STAThread>
    Sub Main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)

        If Not Conectar() Then
            MessageBox.Show("No se pudo conectar a la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Dim configurar As New DarDeAltaForm()
            configurar.ShowDialog()
            If Not Conectar() Then End
        End If

        Dim id As Integer = 0
        Dim usuario As String = ""
        Dim contrasena As String = ""

        If CargarSesionCifrada(id, usuario, contrasena) Then
            Dim cadenaConexion As String = ObtenerCadenaConexionDesdeConfig()
            Using conexionAux2 As New MySqlConnection(cadenaConexion)
                conexionAux2.Open()
                Dim cmd As New MySqlCommand("SELECT * FROM usuarios WHERE usuario = @usuario AND contrasena_hash = @contrasena", conexionAux2)
                cmd.Parameters.AddWithValue("@usuario", usuario)
                Dim contrasenacifrada As String = HashSHA256(contrasena)
                cmd.Parameters.AddWithValue("@contrasena", contrasenacifrada)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.HasRows Then
                    reader.Read()
                    Dim nombre As String = reader("nombre").ToString()
                    Application.Run(New MainChatForm(id, nombre))
                Else
                    BorrarSesion()
                    Application.Run(New LoginForm())
                End If
            End Using
        Else
            Application.Run(New LoginForm())
        End If
    End Sub
    Public Sub GuardarSesionCifrada(id As Integer, usuario As String, contrasena As String)
        Dim datos = $"id={id};usuario={usuario};contrasena={contrasena}"
        Dim cifrado = Convert.ToBase64String(EncriptarAES(datos))
        File.WriteAllText(Path.Combine(Application.StartupPath, "account.txt"), cifrado)
    End Sub
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
    Public Function CargarSesionCifrada(ByRef id As Integer, ByRef usuario As String, ByRef contrasena As String) As Boolean
        Dim ruta = Path.Combine(Application.StartupPath, "account.txt")
        If Not File.Exists(ruta) Then Return False

        Try
            Dim contenidoCifrado = File.ReadAllText(ruta)
            Dim textoPlano = DesencriptarAES(Convert.FromBase64String(contenidoCifrado))
            Dim partes = textoPlano.Split(";"c)

            For Each parte In partes
                If parte.StartsWith("id=") Then id = CInt(parte.Replace("id=", "").Trim())
                If parte.StartsWith("usuario=") Then usuario = parte.Replace("usuario=", "").Trim()
                If parte.StartsWith("contrasena=") Then contrasena = parte.Replace("contrasena=", "").Trim()
            Next

            Return id > 0 AndAlso usuario <> ""
        Catch
            Return False
        End Try
    End Function
    Private Function HashSHA256(texto As String) As String
        Dim sha256 As SHA256 = SHA256.Create()
        Dim bytesTexto As Byte() = Encoding.UTF8.GetBytes(texto)
        Dim hashBytes As Byte() = sha256.ComputeHash(bytesTexto)
        Return BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
    End Function
    Public ClaveEncriptado As String = "Xat2GetherClaveSecreta2025"
    Private claveAES As Byte() = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(ClaveEncriptado))
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
        Using aes As Aes = aes.Create()
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
    Public Sub BorrarSesion()
        Dim ruta = Path.Combine(Application.StartupPath, "account.txt")
        If File.Exists(ruta) Then File.Delete(ruta)
    End Sub
End Module
