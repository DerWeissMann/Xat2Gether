Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Module ConexionBD
    Public conexion As MySqlConnection

    Public ReadOnly claveAES As Byte() = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(Program.ClaveEncriptado))

    Public Function Conectar() As Boolean
        Try
            Dim rutaConfig As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt")
            If Not File.Exists(rutaConfig) Then
                MessageBox.Show("No se encontró el archivo de configuración cifrado.")
                Return False
            End If

            Dim contenidoCifrado = File.ReadAllText(rutaConfig)
            Dim textoPlano = DesencriptarAES(Convert.FromBase64String(contenidoCifrado))

            Dim parametros = textoPlano.Split({vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)
            Dim config = New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)

            For Each linea In parametros
                Dim partes = linea.Split("="c)
                If partes.Length = 2 Then
                    config(partes(0).Trim()) = partes(1).Trim()
                End If
            Next

            If Not config.ContainsKey("servidor") OrElse Not config.ContainsKey("usuario") OrElse
               Not config.ContainsKey("contrasena") OrElse Not config.ContainsKey("basededatos") Then
                MessageBox.Show("Faltan parámetros en el archivo de configuración.")
                Return False
            End If

            Dim cadenaConexion As String = $"server={config("servidor")};user={config("usuario")};password={config("contrasena")};database={config("basededatos")};"
            conexion = New MySqlConnection(cadenaConexion)
            conexion.Open()
            Return True

        Catch ex As Exception
            MessageBox.Show("Error al conectar con la base de datos: " & ex.Message)
            Return False
        End Try
    End Function
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

    Public Function DesencriptarAES(datos As Byte()) As String
        Using aes As Aes = Aes.Create()
            aes.Key = claveAES
            Dim iv = datos.Take(16).ToArray()
            aes.IV = iv
            Dim contenido = datos.Skip(16).ToArray()
            Using ms As New MemoryStream(contenido)
                Using cs As New CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read)
                    Using sr As New StreamReader(cs)
                        Return sr.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
    End Function

End Module
