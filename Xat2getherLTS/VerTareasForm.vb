Imports MySql.Data.MySqlClient

Public Class VerTareasForm
    Private usuarioId As Integer

    Public Sub New(uid As Integer)
        InitializeComponent()
        usuarioId = uid
        CargarTareas()
    End Sub

    Private Sub CargarTareas()
        dgvPendientes.Columns.Clear()
        dgvCompletadas.Columns.Clear()

        Dim cmd As New MySqlCommand("SELECT id, descripcion, completado FROM tareas WHERE asignado_id = @id ORDER BY completado, fecha_asignacion", conexion)
        cmd.Parameters.AddWithValue("@id", usuarioId)
        Dim reader = cmd.ExecuteReader()

        Dim pendientes As New DataTable()
        Dim completadas As New DataTable()

        pendientes.Columns.Add("ID", GetType(Integer))
        pendientes.Columns.Add("Descripción", GetType(String))
        pendientes.Columns.Add("Acción", GetType(String))

        completadas.Columns.Add("ID", GetType(Integer))
        completadas.Columns.Add("Descripción", GetType(String))
        completadas.Columns.Add("Completado", GetType(Boolean))

        While reader.Read()
            Dim id As Integer = reader.GetInt32("id")
            Dim desc As String = reader.GetString("descripcion")
            Dim comp As Boolean = reader.GetBoolean("completado")

            If comp Then
                completadas.Rows.Add(id, desc, comp)
            Else
                pendientes.Rows.Add(id, desc, "Marcar como hecha")
            End If
        End While
        reader.Close()

        dgvPendientes.DataSource = pendientes
        dgvCompletadas.DataSource = completadas

        If dgvPendientes.Columns.Contains("Acción") Then
            Dim btnCol As New DataGridViewButtonColumn()
            btnCol.Name = "Acción"
            btnCol.Text = "Marcar como hecha"
            btnCol.UseColumnTextForButtonValue = True
            dgvPendientes.Columns("Acción").DisplayIndex = dgvPendientes.Columns.Count - 1
        End If
    End Sub

    Private Sub dgvPendientes_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPendientes.CellContentClick
        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso dgvPendientes.Columns(e.ColumnIndex).Name = "Acción" Then
            Dim idTarea = CInt(dgvPendientes.Rows(e.RowIndex).Cells("ID").Value)
            Dim cmd As New MySqlCommand("UPDATE tareas SET completado = TRUE, fecha_completado = NOW() WHERE id = @id", conexion)
            cmd.Parameters.AddWithValue("@id", idTarea)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Tarea completada correctamente.")
            CargarTareas()
        End If
    End Sub
End Class