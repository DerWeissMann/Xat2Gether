<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class VerTareasForm
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.dgvPendientes = New System.Windows.Forms.DataGridView()
        Me.dgvCompletadas = New System.Windows.Forms.DataGridView()
        CType(Me.dgvPendientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvCompletadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPendientes
        '
        Me.dgvPendientes.AllowUserToAddRows = False
        Me.dgvPendientes.AllowUserToDeleteRows = False
        Me.dgvPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPendientes.BackgroundColor = System.Drawing.Color.FromArgb(209, 255, 221)
        Me.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPendientes.Location = New System.Drawing.Point(10, 10)
        Me.dgvPendientes.Name = "dgvPendientes"
        Me.dgvPendientes.ReadOnly = True
        Me.dgvPendientes.RowTemplate.Height = 25
        Me.dgvPendientes.Size = New System.Drawing.Size(760, 200)
        '
        'dgvCompletadas
        '
        Me.dgvCompletadas.AllowUserToAddRows = False
        Me.dgvCompletadas.AllowUserToDeleteRows = False
        Me.dgvCompletadas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCompletadas.BackgroundColor = System.Drawing.Color.FromArgb(209, 255, 221)
        Me.dgvCompletadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompletadas.Location = New System.Drawing.Point(10, 230)
        Me.dgvCompletadas.Name = "dgvCompletadas"
        Me.dgvCompletadas.ReadOnly = True
        Me.dgvCompletadas.RowTemplate.Height = 25
        Me.dgvCompletadas.Size = New System.Drawing.Size(760, 200)
        '
        'VerTareasForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(209, 255, 221)
        Me.ClientSize = New System.Drawing.Size(784, 450)
        Me.Controls.Add(Me.dgvPendientes)
        Me.Controls.Add(Me.dgvCompletadas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "VerTareasForm"
        Me.Text = "Mis Tareas"
        CType(Me.dgvPendientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvCompletadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
    End Sub

    Friend WithEvents dgvPendientes As DataGridView
    Friend WithEvents dgvCompletadas As DataGridView
End Class