Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class ConfiguracionForm
    Private usuarioId As Integer

    Public Sub New(id As Integer)
        InitializeComponent()
        usuarioId = id
    End Sub

    Private Sub ConfiguracionForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbColores.Items.AddRange(New String() {"LightGreen", "LightBlue", "LightCoral", "Khaki", "Lavender", "LightSalmon", "MistyRose", "LightPink", "LightYellow"})
        Dim cmd As New MySqlCommand("SELECT color_mensaje FROM usuarios WHERE id = @id", conexion)
        cmd.Parameters.AddWithValue("@id", usuarioId)
        Dim color = cmd.ExecuteScalar()?.ToString()
        If Not String.IsNullOrEmpty(color) Then
            cmbColores.SelectedItem = color
            pnlPreview.BackColor = System.Drawing.Color.FromName(color)
        End If
    End Sub

    Private Sub cmbColores_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbColores.SelectedIndexChanged
        Dim colorSeleccionado = cmbColores.SelectedItem.ToString()
        pnlPreview.BackColor = Color.FromName(colorSeleccionado)
        Dim cmd As New MySqlCommand("UPDATE usuarios SET color_mensaje = @color WHERE id = @id", conexion)
        cmd.Parameters.AddWithValue("@color", colorSeleccionado)
        cmd.Parameters.AddWithValue("@id", usuarioId)
        cmd.ExecuteNonQuery()
        If Owner IsNot Nothing AndAlso TypeOf Owner Is MainChatForm Then
            CType(Owner, MainChatForm).LimpiarCacheColores()
            CType(Owner, MainChatForm).RefrescarChatActivo()
        End If
    End Sub
End Class
