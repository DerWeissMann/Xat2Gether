Imports MySql.Data.MySqlClient

Public Class AsignarTareaForm
    Private grupoId As Integer
    Private mensajeId As Integer
    Private asignadorId As Integer

    Public Sub New(idGrupo As Integer, idMensaje As Integer, nombreAsignadoPorDefecto As String, textoMensaje As String, idAsignador As Integer)
        InitializeComponent()
        grupoId = idGrupo
        mensajeId = idMensaje
        asignadorId = idAsignador
        CargarIntegrantes(nombreAsignadoPorDefecto)
        txtTarea.Text = textoMensaje
    End Sub




    Private Sub AsignarTareaForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub CargarIntegrantes(nombrePreseleccionado As String)
        Try
            Dim tabla As New DataTable()
            Dim cmd As New MySqlCommand("SELECT u.id, u.nombre FROM grupo_usuarios gu JOIN usuarios u ON gu.usuario_id = u.id WHERE gu.grupo_id = @grupo", conexion)
            cmd.Parameters.AddWithValue("@grupo", grupoId)
            Dim adapter As New MySqlDataAdapter(cmd)
            adapter.Fill(tabla)

            cmbIntegrantes.DataSource = tabla
            cmbIntegrantes.DisplayMember = "nombre"
            cmbIntegrantes.ValueMember = "id"

            For i As Integer = 0 To cmbIntegrantes.Items.Count - 1
                Dim row = CType(cmbIntegrantes.Items(i), DataRowView)
                If row("nombre").ToString() = nombrePreseleccionado Then
                    cmbIntegrantes.SelectedIndex = i
                    Exit For
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error al cargar integrantes: " & ex.Message)
        End Try
    End Sub


    Private Sub btnAsignar_Click(sender As Object, e As EventArgs) Handles btnAsignar.Click
        If cmbIntegrantes.SelectedIndex = -1 OrElse txtTarea.Text.Trim() = "" Then
            MessageBox.Show("Completa todos los campos.")
            Return
        End If

        Try
            Dim idAsignado As Integer = CInt(cmbIntegrantes.SelectedValue)
            Dim descripcion As String = txtTarea.Text.Trim()

            Dim cmd As New MySqlCommand("
                INSERT INTO tareas (grupo_id, asignador_id, asignado_id, descripcion) 
                VALUES (@grupo, @asignador, @asignado, @desc)", conexion)
            cmd.Parameters.AddWithValue("@grupo", grupoId)
            cmd.Parameters.AddWithValue("@asignador", asignadorId)
            cmd.Parameters.AddWithValue("@asignado", idAsignado)
            cmd.Parameters.AddWithValue("@desc", descripcion)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Tarea asignada correctamente.")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error al asignar tarea: " & ex.Message)
        End Try
    End Sub
End Class
