Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Namespace My
    ' The following events are available for MyApplication:
    ' Startup: Raised when the application starts, before the startup form is created.
    ' Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
    ' UnhandledException: Raised if the application encounters an unhandled exception.
    ' StartupNextInstance: Raised when launching a single-instance application and the application is already active. 
    ' NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.

    ' **NEW** ApplyApplicationDefaults: Raised when the application queries default values to be set for the application.

    ' Example:
    ' Private Sub MyApplication_ApplyApplicationDefaults(sender As Object, e As ApplyApplicationDefaultsEventArgs) Handles Me.ApplyApplicationDefaults
    '
    '   ' Setting the application-wide default Font:
    '   e.Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Regular)
    '
    '   ' Setting the HighDpiMode for the Application:
    '   e.HighDpiMode = HighDpiMode.PerMonitorV2
    '
    '   ' If a splash dialog is used, this sets the minimum display time:
    '   e.MinimumSplashScreenDisplayTime = 4000
    ' End Sub

    Partial Friend Class MyApplication
        Dim id As Integer
        Dim nombre As String
        Private Sub Main(sender As Object, e As ApplicationServices.StartupEventArgs) Handles Me.Startup
            If Not Conectar() Then
                MessageBox.Show("No se pudo conectar a la base de datos")
            End If
            If CargarSesionCifrada(id, nombre) Then
                Dim ventanaChat As New MainChatForm(id, nombre)
                ventanaChat.Show()
                Exit Sub
            Else
                Dim ventanalogin As New LoginForm
                ventanalogin.Show()
            End If
        End Sub
        Public Function CargarSesionCifrada(ByRef id As Integer, ByRef nombre As String) As Boolean
            Dim ruta = Path.Combine(System.Windows.Forms.Application.StartupPath, "account.txt")
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
        Private claveAES As Byte() = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes("clave-xat2gether"))

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


End Namespace
