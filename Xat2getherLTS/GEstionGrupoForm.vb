Imports MySql.Data.MySqlClient

Public Class GestionGrupoForm
    Private grupoId As Integer

    Public Sub New(idGrupo As Integer)
        InitializeComponent()
        grupoId = idGrupo
        CargarUsuarios()
    End Sub
    Private Sub btnCambiarNombre_Click(sender As Object, e As EventArgs) Handles btnCambiarNombre.Click
        Dim nuevoNombre As String = txtNuevoNombre.Text.Trim()

        If nuevoNombre = "" Then
            MessageBox.Show("El nombre no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim cmd As New MySqlCommand("UPDATE grupos SET nombre = @nombre WHERE id = @id", conexion)
        cmd.Parameters.AddWithValue("@nombre", nuevoNombre)
        cmd.Parameters.AddWithValue("@id", grupoId)

        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Nombre actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If Application.OpenForms().OfType(Of MainChatForm).Any() Then
                Dim form As MainChatForm = Application.OpenForms().OfType(Of MainChatForm).First()
                If form IsNot Nothing Then
                    form.RefrescarChatActivo()
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error al actualizar nombre: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CargarUsuarios()
        lstUsuariosGrupo.Items.Clear()
        lstUsuariosDisponibles.Items.Clear()
        Dim cmd1 As New MySqlCommand("SELECT u.id, u.nombre FROM grupo_usuarios gu JOIN usuarios u ON gu.usuario_id = u.id WHERE gu.grupo_id = @grupo", conexion)
        cmd1.Parameters.AddWithValue("@grupo", grupoId)
        Dim reader1 = cmd1.ExecuteReader()
        While reader1.Read()
            lstUsuariosGrupo.Items.Add($"{reader1("nombre")} [id:{reader1("id")}]")
        End While
        reader1.Close()

        ' Usuarios fuera del grupo
        Dim cmd2 As New MySqlCommand("SELECT id, nombre FROM usuarios WHERE id NOT IN (SELECT usuario_id FROM grupo_usuarios WHERE grupo_id = @grupo)", conexion)
        cmd2.Parameters.AddWithValue("@grupo", grupoId)
        Dim reader2 = cmd2.ExecuteReader()
        While reader2.Read()
            lstUsuariosDisponibles.Items.Add($"{reader2("nombre")} [id:{reader2("id")}]")
        End While
        reader2.Close()
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If lstUsuariosDisponibles.SelectedItem Is Nothing Then Exit Sub
        Dim id = ObtenerIdDesdeTexto(lstUsuariosDisponibles.SelectedItem.ToString())
        Dim cmd As New MySqlCommand("INSERT INTO grupo_usuarios (grupo_id, usuario_id) VALUES (@grupo, @usuario)", conexion)
        cmd.Parameters.AddWithValue("@grupo", grupoId)
        cmd.Parameters.AddWithValue("@usuario", id)
        cmd.ExecuteNonQuery()
        CargarUsuarios()
    End Sub

    Private Sub btnExpulsar_Click(sender As Object, e As EventArgs) Handles btnExpulsar.Click
        If lstUsuariosGrupo.SelectedItem Is Nothing Then Exit Sub
        Dim id = ObtenerIdDesdeTexto(lstUsuariosGrupo.SelectedItem.ToString())
        Dim cmd As New MySqlCommand("DELETE FROM grupo_usuarios WHERE grupo_id = @grupo AND usuario_id = @usuario", conexion)
        cmd.Parameters.AddWithValue("@grupo", grupoId)
        cmd.Parameters.AddWithValue("@usuario", id)
        cmd.ExecuteNonQuery()
        CargarUsuarios()
    End Sub

    Private Function ObtenerIdDesdeTexto(texto As String) As Integer
        Dim partes = texto.Split("[id:")
        Return CInt(partes(1).Replace("]", "").Trim())
    End Function

    Private Sub GestionGrupoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
