Imports System.IO
Imports Newtonsoft.Json

Public Class FileService
    Private Shared carpetaChats As String = Path.Combine(Application.StartupPath, "Chats")

    Public Shared Sub GuardarChatLocal(nombreArchivo As String, mensajes As List(Of String))
        If Not Directory.Exists(carpetaChats) Then
            Directory.CreateDirectory(carpetaChats)
        End If

        Dim ruta = Path.Combine(carpetaChats, nombreArchivo)
        Dim json = JsonConvert.SerializeObject(mensajes, Formatting.Indented)
        File.WriteAllText(ruta, json)
    End Sub

    Public Shared Function LeerChatLocal(nombreArchivo As String) As List(Of String)
        Dim ruta = Path.Combine(carpetaChats, nombreArchivo)
        If File.Exists(ruta) Then
            Dim contenido = File.ReadAllText(ruta)
            Return JsonConvert.DeserializeObject(Of List(Of String))(contenido)
        End If
        Return New List(Of String)()
    End Function

    Public Shared Sub ExportarChat(nombreArchivo As String, tipo As String)
        Dim ruta = Path.Combine(carpetaChats, nombreArchivo)
        If Not File.Exists(ruta) Then Exit Sub

        Dim contenido = File.ReadAllText(ruta)
        Dim mensajes = JsonConvert.DeserializeObject(Of List(Of String))(contenido)

        Dim rutaExport = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Export_" & Path.GetFileNameWithoutExtension(nombreArchivo))

        If tipo = "txt" Then
            File.WriteAllLines(rutaExport & ".txt", mensajes)
        ElseIf tipo = "json" Then
            Dim json = JsonConvert.SerializeObject(mensajes, Formatting.Indented)
            File.WriteAllText(rutaExport & ".json", json)
        End If
    End Sub
End Class