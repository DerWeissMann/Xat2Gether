Imports MySql.Data.MySqlClient

Public Class CrearGrupoForm
    Private idCreador As Integer

    Public Sub New(creadorId As Integer)
        InitializeComponent()
        idCreador = creadorId
    End Sub

    Private Sub CrearGrupoForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmd As New MySqlCommand("SELECT id, nombre FROM usuarios WHERE id <> @yo", conexion)
        cmd.Parameters.AddWithValue("@yo", idCreador)
        Dim reader = cmd.ExecuteReader()

        While reader.Read()
            Dim id = reader("id")
            Dim nombre = reader("nombre").ToString()
            chkUsuarios.Items.Add(nombre & " [id:" & id & "]")
        End While
        reader.Close()
    End Sub

    Private Sub btnCrearGrupo_Click(sender As Object, e As EventArgs) Handles btnCrearGrupo.Click
        Dim nombreGrupo = txtNombreGrupo.Text.Trim()
        If nombreGrupo = "" Or chkUsuarios.CheckedItems.Count = 0 Then
            MessageBox.Show("Introduce un nombre y selecciona al menos un usuario.")
            Exit Sub
        End If

        Dim cmdInsertGrupo As New MySqlCommand("INSERT INTO grupos (nombre, creador_id) VALUES (@nombre, @creador)", conexion)
        cmdInsertGrupo.Parameters.AddWithValue("@nombre", nombreGrupo)
        cmdInsertGrupo.Parameters.AddWithValue("@creador", idCreador)
        cmdInsertGrupo.ExecuteNonQuery()

        Dim idGrupo As Integer = CInt(cmdInsertGrupo.LastInsertedId)

        Dim cmdInsertCreador As New MySqlCommand("INSERT INTO grupo_usuarios (grupo_id, usuario_id) VALUES (@g, @u)", conexion)
        cmdInsertCreador.Parameters.AddWithValue("@g", idGrupo)
        cmdInsertCreador.Parameters.AddWithValue("@u", idCreador)
        cmdInsertCreador.ExecuteNonQuery()

        For Each item In chkUsuarios.CheckedItems
            Dim idExtraido = CInt(item.ToString().Split("[id:")(1).Replace("]", ""))
            Dim cmd As New MySqlCommand("INSERT INTO grupo_usuarios (grupo_id, usuario_id) VALUES (@g, @u)", conexion)
            cmd.Parameters.AddWithValue("@g", idGrupo)
            cmd.Parameters.AddWithValue("@u", idExtraido)
            cmd.ExecuteNonQuery()
        Next

        MessageBox.Show("Grupo creado correctamente.")
        Me.Close()
    End Sub
End Class