﻿Imports MySql.Data.MySqlClient
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
        Dim cmd2 As New MySqlCommand("SELECT nombre FROM usuarios WHERE id = @id", conexion)
        cmd2.Parameters.AddWithValue("@id", usuarioId)
        Dim resultado = cmd2.ExecuteScalar()
        If resultado IsNot Nothing Then
            txtNuevoNombre.Text = resultado.ToString()
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
    Private Sub btnGuardarNombre_Click(sender As Object, e As EventArgs) Handles btnGuardarNombre.Click
        Dim nuevoNombre = txtNuevoNombre.Text.Trim()
        If nuevoNombre = "" Then
            MessageBox.Show("El nombre no puede estar vacío.")
            Return
        End If

        Dim cmd As New MySqlCommand("UPDATE usuarios SET nombre = @nombre WHERE id = @id", conexion)
        cmd.Parameters.AddWithValue("@nombre", nuevoNombre)
        cmd.Parameters.AddWithValue("@id", usuarioId)
        cmd.ExecuteNonQuery()

        MessageBox.Show("Nombre actualizado correctamente.")
        Me.Close()
    End Sub

    Private Sub btnEliminarCuenta_Click(sender As Object, e As EventArgs) Handles btnEliminarCuenta.Click
        Dim confirmacion = MessageBox.Show("¿Estás seguro de que quieres eliminar tu cuenta? Se eliminarán todos tus mensajes y tu perfil.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmacion = DialogResult.Yes Then
            Dim cmd1 As New MySqlCommand("DELETE FROM mensajes WHERE emisor_id = @id OR receptor_id = @id", conexion)
            cmd1.Parameters.AddWithValue("@id", usuarioId)
            cmd1.ExecuteNonQuery()

            Dim cmd2 As New MySqlCommand("DELETE FROM grupo_usuarios WHERE usuario_id = @id", conexion)
            cmd2.Parameters.AddWithValue("@id", usuarioId)
            cmd2.ExecuteNonQuery()

            Dim cmd3 As New MySqlCommand("DELETE FROM usuarios WHERE id = @id", conexion)
            cmd3.Parameters.AddWithValue("@id", usuarioId)
            cmd3.ExecuteNonQuery()

            MessageBox.Show("Cuenta eliminada. Se cerrará la sesión.", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Application.Restart()
        End If
    End Sub

    Private Sub txtNuevoNombre_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class
