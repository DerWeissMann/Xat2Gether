Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class DarDeAltaForm
    Private Sub DarDeAltaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.FromArgb(209, 255, 221)
        btnGuardar.BackColor = Color.FromArgb(42, 157, 124)
        btnGuardar.ForeColor = Color.White
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Dim servidor = txtServidor.Text.Trim()
        Dim usuario = txtUsuario.Text.Trim()
        Dim contrasena = txtContrasena.Text.Trim()
        Dim baseDeDatos = txtBaseDeDatos.Text.Trim()

        If servidor = "" OrElse usuario = "" OrElse contrasena = "" OrElse baseDeDatos = "" Then
            MessageBox.Show("Rellena todos los campos.")
            Exit Sub
        End If

        Dim texto As String =
            $"servidor={servidor}" & vbCrLf &
            $"usuario={usuario}" & vbCrLf &
            $"contrasena={contrasena}" & vbCrLf &
            $"basededatos={baseDeDatos}"

        Using aes As Aes = Aes.Create()
            aes.Key = ConexionBD.claveAES
            aes.GenerateIV()
            Using ms As New MemoryStream()
                ms.Write(aes.IV, 0, aes.IV.Length)
                Using cs As New CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write)
                    Dim datos = Encoding.UTF8.GetBytes(texto)
                    cs.Write(datos, 0, datos.Length)
                    cs.FlushFinalBlock()
                End Using
                Dim cifradoBase64 = Convert.ToBase64String(ms.ToArray())
                File.WriteAllText("config.txt", cifradoBase64)
                MessageBox.Show("Configuración guardada correctamente.")
                Me.Close()
            End Using
        End Using
    End Sub
End Class
