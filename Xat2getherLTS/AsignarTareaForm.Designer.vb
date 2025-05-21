<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AsignarTareaForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtTarea = New System.Windows.Forms.TextBox()
        Me.cmbIntegrantes = New System.Windows.Forms.ComboBox()
        Me.btnAsignar = New System.Windows.Forms.Button()
        Me.SuspendLayout()

        ' txtTarea
        Me.txtTarea.Location = New System.Drawing.Point(30, 80)
        Me.txtTarea.Multiline = True
        Me.txtTarea.Name = "txtTarea"
        Me.txtTarea.PlaceholderText = "Escribe la tarea a asignar..."
        Me.txtTarea.Size = New System.Drawing.Size(300, 80)
        Me.txtTarea.BackColor = Color.FromArgb(209, 255, 221)
        Me.txtTarea.Font = New Font("Segoe UI", 10)

        ' cmbIntegrantes
        Me.cmbIntegrantes.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cmbIntegrantes.Location = New System.Drawing.Point(30, 30)
        Me.cmbIntegrantes.Name = "cmbIntegrantes"
        Me.cmbIntegrantes.Size = New System.Drawing.Size(300, 23)
        Me.cmbIntegrantes.BackColor = Color.FromArgb(163, 225, 201)
        Me.cmbIntegrantes.Font = New Font("Segoe UI", 10)

        ' btnAsignar
        Me.btnAsignar.Location = New System.Drawing.Point(30, 180)
        Me.btnAsignar.Name = "btnAsignar"
        Me.btnAsignar.Size = New System.Drawing.Size(300, 35)
        Me.btnAsignar.Text = "Asignar tarea"
        Me.btnAsignar.BackColor = Color.FromArgb(42, 157, 124)
        Me.btnAsignar.ForeColor = Color.White
        Me.btnAsignar.FlatStyle = FlatStyle.Flat

        ' Form
        Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        Me.ClientSize = New System.Drawing.Size(370, 240)
        Me.Controls.Add(Me.txtTarea)
        Me.Controls.Add(Me.cmbIntegrantes)
        Me.Controls.Add(Me.btnAsignar)
        Me.Name = "AsignarTareaForm"
        Me.Text = "Asignar Tarea"
        Me.BackColor = Color.FromArgb(209, 255, 221)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents txtTarea As TextBox
    Friend WithEvents cmbIntegrantes As ComboBox
    Friend WithEvents btnAsignar As Button
End Class
