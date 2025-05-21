Imports MySql.Data.MySqlClient
Imports System.IO

Public Module ConexionBD
    Public conexion As MySqlConnection

    Public Function Conectar() As Boolean
        Try
            Dim rutaConfig As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt")
            If Not File.Exists(rutaConfig) Then
                MessageBox.Show("No se encontró el archivo de configuración.")
                Return False
            End If
            Dim parametros = File.ReadAllLines(rutaConfig)
            Dim config = New Dictionary(Of String, String)

            For Each linea In parametros
                Dim partes = linea.Split("="c)
                If partes.Length = 2 Then
                    config(partes(0).Trim().ToLower()) = partes(1).Trim()
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
End Module
