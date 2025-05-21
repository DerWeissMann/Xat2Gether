Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class CryptoService

    Public Shared Function GenerarClaveAES(id1 As Integer, id2 As Integer) As Byte()
        Dim menor = Math.Min(id1, id2)
        Dim mayor = Math.Max(id1, id2)
        Dim baseStr = $"clavechat_{menor}_{mayor}"
        Dim sha256 As SHA256 = SHA256.Create()
        Return sha256.ComputeHash(Encoding.UTF8.GetBytes(baseStr)).Take(32).ToArray()
    End Function

    Public Shared Function GenerarClaveGrupo(grupoId As Integer) As Byte()
        Dim baseStr = $"clavegrupo_{grupoId}"
        Dim sha256 As SHA256 = SHA256.Create()
        Return sha256.ComputeHash(Encoding.UTF8.GetBytes(baseStr)).Take(32).ToArray()
    End Function

    Public Shared Function Encriptar(textoPlano As String, clave As Byte()) As String
        Using aes As Aes = Aes.Create()
            aes.Key = clave
            aes.GenerateIV()
            Dim iv As Byte() = aes.IV
            Dim encryptor = aes.CreateEncryptor()
            Using ms As New MemoryStream()
                ms.Write(iv, 0, iv.Length)
                Using cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                    Dim bytesTexto = Encoding.UTF8.GetBytes(textoPlano)
                    cs.Write(bytesTexto, 0, bytesTexto.Length)
                    cs.FlushFinalBlock()
                End Using
                Return Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
    End Function

    Public Shared Function Desencriptar(textoEncriptado As String, clave As Byte()) As String
        Try
            Dim datosCifrados = Convert.FromBase64String(textoEncriptado)
            Using aes As Aes = Aes.Create()
                aes.Key = clave
                Dim iv = datosCifrados.Take(16).ToArray()
                aes.IV = iv
                Dim cifrado = datosCifrados.Skip(16).ToArray()
                Dim decryptor = aes.CreateDecryptor()
                Using ms As New MemoryStream(cifrado)
                    Using cs As New CryptoStream(ms, decryptor, CryptoStreamMode.Read)
                        Using sr As New StreamReader(cs)
                            Return sr.ReadToEnd()
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return "[ERROR al desencriptar]"
        End Try
    End Function

End Class