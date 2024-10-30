namespace CatedraticoProject
{
    partial class FormCatedratico
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpCursosAsignados = new System.Windows.Forms.GroupBox();
            this.lblPuntosEstudianteSeleccionado = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSeleccionarCurso = new System.Windows.Forms.Label();
            this.lstEstudiantes = new System.Windows.Forms.ListBox();
            this.cmbSeleccionarCurso = new System.Windows.Forms.ComboBox();
            this.grpGestionDeTareas = new System.Windows.Forms.GroupBox();
            this.btnEliminarTarea = new System.Windows.Forms.Button();
            this.lblTareasExistentes = new System.Windows.Forms.Label();
            this.btnModificarTarea = new System.Windows.Forms.Button();
            this.cmbTareasExistentes = new System.Windows.Forms.ComboBox();
            this.btnCrearTarea = new System.Windows.Forms.Button();
            this.txtDescripcionTarea = new System.Windows.Forms.TextBox();
            this.txtNombreTarea = new System.Windows.Forms.TextBox();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.dateFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.lblDescripcionTarea = new System.Windows.Forms.Label();
            this.lblNombreTarea = new System.Windows.Forms.Label();
            this.grpTareasEntregadas = new System.Windows.Forms.GroupBox();
            this.btnAsignarCalificacionTarea = new System.Windows.Forms.Button();
            this.txtCalificacionTarea = new System.Windows.Forms.TextBox();
            this.lblCalificarTareaSeleccionada = new System.Windows.Forms.Label();
            this.lstTareasEntregadas = new System.Windows.Forms.ListBox();
            this.grpGestionDeAnuncios = new System.Windows.Forms.GroupBox();
            this.cmbAnunciosExistentes = new System.Windows.Forms.ComboBox();
            this.txtContenidoAnuncio = new System.Windows.Forms.TextBox();
            this.txtTituloAnuncio = new System.Windows.Forms.TextBox();
            this.lblAnunciosExistentes = new System.Windows.Forms.Label();
            this.btnEliminarAnuncio = new System.Windows.Forms.Button();
            this.btnModificarAnuncio = new System.Windows.Forms.Button();
            this.btnCrearAnuncio = new System.Windows.Forms.Button();
            this.lblContenidoAnuncio = new System.Windows.Forms.Label();
            this.lblTituloAnuncio = new System.Windows.Forms.Label();
            this.grpCursosAsignados.SuspendLayout();
            this.grpGestionDeTareas.SuspendLayout();
            this.grpTareasEntregadas.SuspendLayout();
            this.grpGestionDeAnuncios.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCursosAsignados
            // 
            this.grpCursosAsignados.Controls.Add(this.lblPuntosEstudianteSeleccionado);
            this.grpCursosAsignados.Controls.Add(this.label1);
            this.grpCursosAsignados.Controls.Add(this.lblSeleccionarCurso);
            this.grpCursosAsignados.Controls.Add(this.lstEstudiantes);
            this.grpCursosAsignados.Controls.Add(this.cmbSeleccionarCurso);
            this.grpCursosAsignados.Location = new System.Drawing.Point(12, 12);
            this.grpCursosAsignados.Name = "grpCursosAsignados";
            this.grpCursosAsignados.Size = new System.Drawing.Size(359, 145);
            this.grpCursosAsignados.TabIndex = 0;
            this.grpCursosAsignados.TabStop = false;
            this.grpCursosAsignados.Text = "Cursos Asignados";
            // 
            // lblPuntosEstudianteSeleccionado
            // 
            this.lblPuntosEstudianteSeleccionado.AutoSize = true;
            this.lblPuntosEstudianteSeleccionado.Location = new System.Drawing.Point(78, 123);
            this.lblPuntosEstudianteSeleccionado.Name = "lblPuntosEstudianteSeleccionado";
            this.lblPuntosEstudianteSeleccionado.Size = new System.Drawing.Size(89, 13);
            this.lblPuntosEstudianteSeleccionado.TabIndex = 6;
            this.lblPuntosEstudianteSeleccionado.Text = "No Seleccionado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Estudiantes";
            // 
            // lblSeleccionarCurso
            // 
            this.lblSeleccionarCurso.AutoSize = true;
            this.lblSeleccionarCurso.Location = new System.Drawing.Point(6, 20);
            this.lblSeleccionarCurso.Name = "lblSeleccionarCurso";
            this.lblSeleccionarCurso.Size = new System.Drawing.Size(93, 13);
            this.lblSeleccionarCurso.TabIndex = 3;
            this.lblSeleccionarCurso.Text = "Seleccionar Curso";
            // 
            // lstEstudiantes
            // 
            this.lstEstudiantes.FormattingEnabled = true;
            this.lstEstudiantes.Location = new System.Drawing.Point(81, 63);
            this.lstEstudiantes.Name = "lstEstudiantes";
            this.lstEstudiantes.Size = new System.Drawing.Size(271, 56);
            this.lstEstudiantes.TabIndex = 1;
            this.lstEstudiantes.SelectedIndexChanged += new System.EventHandler(this.lstEstudiantes_SelectedIndexChanged);
            // 
            // cmbSeleccionarCurso
            // 
            this.cmbSeleccionarCurso.FormattingEnabled = true;
            this.cmbSeleccionarCurso.Location = new System.Drawing.Point(6, 36);
            this.cmbSeleccionarCurso.Name = "cmbSeleccionarCurso";
            this.cmbSeleccionarCurso.Size = new System.Drawing.Size(347, 21);
            this.cmbSeleccionarCurso.TabIndex = 1;
            this.cmbSeleccionarCurso.SelectedIndexChanged += new System.EventHandler(this.cmbSeleccionarCurso_SelectedIndexChanged);
            // 
            // grpGestionDeTareas
            // 
            this.grpGestionDeTareas.Controls.Add(this.btnEliminarTarea);
            this.grpGestionDeTareas.Controls.Add(this.lblTareasExistentes);
            this.grpGestionDeTareas.Controls.Add(this.btnModificarTarea);
            this.grpGestionDeTareas.Controls.Add(this.cmbTareasExistentes);
            this.grpGestionDeTareas.Controls.Add(this.btnCrearTarea);
            this.grpGestionDeTareas.Controls.Add(this.txtDescripcionTarea);
            this.grpGestionDeTareas.Controls.Add(this.txtNombreTarea);
            this.grpGestionDeTareas.Controls.Add(this.lblFechaLimite);
            this.grpGestionDeTareas.Controls.Add(this.dateFechaLimite);
            this.grpGestionDeTareas.Controls.Add(this.lblDescripcionTarea);
            this.grpGestionDeTareas.Controls.Add(this.lblNombreTarea);
            this.grpGestionDeTareas.Location = new System.Drawing.Point(12, 163);
            this.grpGestionDeTareas.Name = "grpGestionDeTareas";
            this.grpGestionDeTareas.Size = new System.Drawing.Size(353, 198);
            this.grpGestionDeTareas.TabIndex = 1;
            this.grpGestionDeTareas.TabStop = false;
            this.grpGestionDeTareas.Text = "Gestion de Tareas";
            // 
            // btnEliminarTarea
            // 
            this.btnEliminarTarea.Location = new System.Drawing.Point(240, 127);
            this.btnEliminarTarea.Name = "btnEliminarTarea";
            this.btnEliminarTarea.Size = new System.Drawing.Size(107, 23);
            this.btnEliminarTarea.TabIndex = 11;
            this.btnEliminarTarea.Text = "Eliminar Tarea";
            this.btnEliminarTarea.UseVisualStyleBackColor = true;
            this.btnEliminarTarea.Click += new System.EventHandler(this.btnEliminarTarea_Click);
            // 
            // lblTareasExistentes
            // 
            this.lblTareasExistentes.AutoSize = true;
            this.lblTareasExistentes.Location = new System.Drawing.Point(9, 167);
            this.lblTareasExistentes.Name = "lblTareasExistentes";
            this.lblTareasExistentes.Size = new System.Drawing.Size(91, 13);
            this.lblTareasExistentes.TabIndex = 10;
            this.lblTareasExistentes.Text = "Tareas Existentes";
            // 
            // btnModificarTarea
            // 
            this.btnModificarTarea.Location = new System.Drawing.Point(122, 127);
            this.btnModificarTarea.Name = "btnModificarTarea";
            this.btnModificarTarea.Size = new System.Drawing.Size(107, 23);
            this.btnModificarTarea.TabIndex = 9;
            this.btnModificarTarea.Text = "Modificar Tarea";
            this.btnModificarTarea.UseVisualStyleBackColor = true;
            this.btnModificarTarea.Click += new System.EventHandler(this.btnModificarTarea_Click);
            // 
            // cmbTareasExistentes
            // 
            this.cmbTareasExistentes.FormattingEnabled = true;
            this.cmbTareasExistentes.Location = new System.Drawing.Point(108, 164);
            this.cmbTareasExistentes.Name = "cmbTareasExistentes";
            this.cmbTareasExistentes.Size = new System.Drawing.Size(239, 21);
            this.cmbTareasExistentes.TabIndex = 8;
            this.cmbTareasExistentes.SelectedIndexChanged += new System.EventHandler(this.cmbTareasExistentes_SelectedIndexChanged);
            // 
            // btnCrearTarea
            // 
            this.btnCrearTarea.Location = new System.Drawing.Point(6, 127);
            this.btnCrearTarea.Name = "btnCrearTarea";
            this.btnCrearTarea.Size = new System.Drawing.Size(107, 23);
            this.btnCrearTarea.TabIndex = 2;
            this.btnCrearTarea.Text = "Crear Tarea";
            this.btnCrearTarea.UseVisualStyleBackColor = true;
            this.btnCrearTarea.Click += new System.EventHandler(this.btnCrearTarea_Click);
            // 
            // txtDescripcionTarea
            // 
            this.txtDescripcionTarea.Location = new System.Drawing.Point(120, 48);
            this.txtDescripcionTarea.Multiline = true;
            this.txtDescripcionTarea.Name = "txtDescripcionTarea";
            this.txtDescripcionTarea.Size = new System.Drawing.Size(227, 42);
            this.txtDescripcionTarea.TabIndex = 7;
            // 
            // txtNombreTarea
            // 
            this.txtNombreTarea.Location = new System.Drawing.Point(120, 22);
            this.txtNombreTarea.Name = "txtNombreTarea";
            this.txtNombreTarea.Size = new System.Drawing.Size(227, 20);
            this.txtNombreTarea.TabIndex = 6;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Location = new System.Drawing.Point(9, 106);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(67, 13);
            this.lblFechaLimite.TabIndex = 5;
            this.lblFechaLimite.Text = "Fecha Limite";
            // 
            // dateFechaLimite
            // 
            this.dateFechaLimite.Location = new System.Drawing.Point(108, 99);
            this.dateFechaLimite.Name = "dateFechaLimite";
            this.dateFechaLimite.Size = new System.Drawing.Size(239, 20);
            this.dateFechaLimite.TabIndex = 4;
            // 
            // lblDescripcionTarea
            // 
            this.lblDescripcionTarea.AutoSize = true;
            this.lblDescripcionTarea.Location = new System.Drawing.Point(6, 51);
            this.lblDescripcionTarea.Name = "lblDescripcionTarea";
            this.lblDescripcionTarea.Size = new System.Drawing.Size(94, 13);
            this.lblDescripcionTarea.TabIndex = 3;
            this.lblDescripcionTarea.Text = "Descripcion Tarea";
            // 
            // lblNombreTarea
            // 
            this.lblNombreTarea.AutoSize = true;
            this.lblNombreTarea.Location = new System.Drawing.Point(6, 25);
            this.lblNombreTarea.Name = "lblNombreTarea";
            this.lblNombreTarea.Size = new System.Drawing.Size(75, 13);
            this.lblNombreTarea.TabIndex = 2;
            this.lblNombreTarea.Text = "Nombre Tarea";
            // 
            // grpTareasEntregadas
            // 
            this.grpTareasEntregadas.Controls.Add(this.btnAsignarCalificacionTarea);
            this.grpTareasEntregadas.Controls.Add(this.txtCalificacionTarea);
            this.grpTareasEntregadas.Controls.Add(this.lblCalificarTareaSeleccionada);
            this.grpTareasEntregadas.Controls.Add(this.lstTareasEntregadas);
            this.grpTareasEntregadas.Location = new System.Drawing.Point(377, 12);
            this.grpTareasEntregadas.Name = "grpTareasEntregadas";
            this.grpTareasEntregadas.Size = new System.Drawing.Size(200, 349);
            this.grpTareasEntregadas.TabIndex = 2;
            this.grpTareasEntregadas.TabStop = false;
            this.grpTareasEntregadas.Text = "Tareas Entregadas";
            // 
            // btnAsignarCalificacionTarea
            // 
            this.btnAsignarCalificacionTarea.Location = new System.Drawing.Point(31, 218);
            this.btnAsignarCalificacionTarea.Name = "btnAsignarCalificacionTarea";
            this.btnAsignarCalificacionTarea.Size = new System.Drawing.Size(133, 23);
            this.btnAsignarCalificacionTarea.TabIndex = 3;
            this.btnAsignarCalificacionTarea.Text = "Asignar Calificacion";
            this.btnAsignarCalificacionTarea.UseVisualStyleBackColor = true;
            this.btnAsignarCalificacionTarea.Click += new System.EventHandler(this.btnAsignarCalificacionTarea_Click);
            // 
            // txtCalificacionTarea
            // 
            this.txtCalificacionTarea.Location = new System.Drawing.Point(6, 188);
            this.txtCalificacionTarea.Name = "txtCalificacionTarea";
            this.txtCalificacionTarea.Size = new System.Drawing.Size(188, 20);
            this.txtCalificacionTarea.TabIndex = 2;
            this.txtCalificacionTarea.TextChanged += new System.EventHandler(this.txtCalificacionTarea_TextChanged);
            // 
            // lblCalificarTareaSeleccionada
            // 
            this.lblCalificarTareaSeleccionada.AutoSize = true;
            this.lblCalificarTareaSeleccionada.Location = new System.Drawing.Point(6, 172);
            this.lblCalificarTareaSeleccionada.Name = "lblCalificarTareaSeleccionada";
            this.lblCalificarTareaSeleccionada.Size = new System.Drawing.Size(143, 13);
            this.lblCalificarTareaSeleccionada.TabIndex = 1;
            this.lblCalificarTareaSeleccionada.Text = "Calificar Tarea Seleccionada";
            // 
            // lstTareasEntregadas
            // 
            this.lstTareasEntregadas.FormattingEnabled = true;
            this.lstTareasEntregadas.Location = new System.Drawing.Point(6, 19);
            this.lstTareasEntregadas.Name = "lstTareasEntregadas";
            this.lstTareasEntregadas.Size = new System.Drawing.Size(188, 147);
            this.lstTareasEntregadas.TabIndex = 0;
            this.lstTareasEntregadas.SelectedIndexChanged += new System.EventHandler(this.lstTareasEntregadas_SelectedIndexChanged);
            // 
            // grpGestionDeAnuncios
            // 
            this.grpGestionDeAnuncios.Controls.Add(this.cmbAnunciosExistentes);
            this.grpGestionDeAnuncios.Controls.Add(this.txtContenidoAnuncio);
            this.grpGestionDeAnuncios.Controls.Add(this.txtTituloAnuncio);
            this.grpGestionDeAnuncios.Controls.Add(this.lblAnunciosExistentes);
            this.grpGestionDeAnuncios.Controls.Add(this.btnEliminarAnuncio);
            this.grpGestionDeAnuncios.Controls.Add(this.btnModificarAnuncio);
            this.grpGestionDeAnuncios.Controls.Add(this.btnCrearAnuncio);
            this.grpGestionDeAnuncios.Controls.Add(this.lblContenidoAnuncio);
            this.grpGestionDeAnuncios.Controls.Add(this.lblTituloAnuncio);
            this.grpGestionDeAnuncios.Location = new System.Drawing.Point(594, 12);
            this.grpGestionDeAnuncios.Name = "grpGestionDeAnuncios";
            this.grpGestionDeAnuncios.Size = new System.Drawing.Size(224, 346);
            this.grpGestionDeAnuncios.TabIndex = 4;
            this.grpGestionDeAnuncios.TabStop = false;
            this.grpGestionDeAnuncios.Text = "Gestion de Anuncios";
            // 
            // cmbAnunciosExistentes
            // 
            this.cmbAnunciosExistentes.FormattingEnabled = true;
            this.cmbAnunciosExistentes.Location = new System.Drawing.Point(9, 198);
            this.cmbAnunciosExistentes.Name = "cmbAnunciosExistentes";
            this.cmbAnunciosExistentes.Size = new System.Drawing.Size(203, 21);
            this.cmbAnunciosExistentes.TabIndex = 11;
            this.cmbAnunciosExistentes.SelectedIndexChanged += new System.EventHandler(this.cmbAnunciosExistentes_SelectedIndexChanged);
            // 
            // txtContenidoAnuncio
            // 
            this.txtContenidoAnuncio.Location = new System.Drawing.Point(127, 45);
            this.txtContenidoAnuncio.Multiline = true;
            this.txtContenidoAnuncio.Name = "txtContenidoAnuncio";
            this.txtContenidoAnuncio.Size = new System.Drawing.Size(85, 112);
            this.txtContenidoAnuncio.TabIndex = 10;
            // 
            // txtTituloAnuncio
            // 
            this.txtTituloAnuncio.Location = new System.Drawing.Point(87, 16);
            this.txtTituloAnuncio.Name = "txtTituloAnuncio";
            this.txtTituloAnuncio.Size = new System.Drawing.Size(125, 20);
            this.txtTituloAnuncio.TabIndex = 5;
            // 
            // lblAnunciosExistentes
            // 
            this.lblAnunciosExistentes.AutoSize = true;
            this.lblAnunciosExistentes.Location = new System.Drawing.Point(14, 176);
            this.lblAnunciosExistentes.Name = "lblAnunciosExistentes";
            this.lblAnunciosExistentes.Size = new System.Drawing.Size(102, 13);
            this.lblAnunciosExistentes.TabIndex = 9;
            this.lblAnunciosExistentes.Text = "Anuncios Existentes";
            // 
            // btnEliminarAnuncio
            // 
            this.btnEliminarAnuncio.Location = new System.Drawing.Point(9, 134);
            this.btnEliminarAnuncio.Name = "btnEliminarAnuncio";
            this.btnEliminarAnuncio.Size = new System.Drawing.Size(107, 23);
            this.btnEliminarAnuncio.TabIndex = 8;
            this.btnEliminarAnuncio.Text = "Eliminar Anuncio";
            this.btnEliminarAnuncio.UseVisualStyleBackColor = true;
            this.btnEliminarAnuncio.Click += new System.EventHandler(this.btnEliminarAnuncio_Click);
            // 
            // btnModificarAnuncio
            // 
            this.btnModificarAnuncio.Location = new System.Drawing.Point(9, 105);
            this.btnModificarAnuncio.Name = "btnModificarAnuncio";
            this.btnModificarAnuncio.Size = new System.Drawing.Size(107, 23);
            this.btnModificarAnuncio.TabIndex = 7;
            this.btnModificarAnuncio.Text = "Modificar Anuncio";
            this.btnModificarAnuncio.UseVisualStyleBackColor = true;
            this.btnModificarAnuncio.Click += new System.EventHandler(this.btnModificarAnuncio_Click);
            // 
            // btnCrearAnuncio
            // 
            this.btnCrearAnuncio.Location = new System.Drawing.Point(9, 76);
            this.btnCrearAnuncio.Name = "btnCrearAnuncio";
            this.btnCrearAnuncio.Size = new System.Drawing.Size(107, 23);
            this.btnCrearAnuncio.TabIndex = 5;
            this.btnCrearAnuncio.Text = "Crear Anuncio";
            this.btnCrearAnuncio.UseVisualStyleBackColor = true;
            this.btnCrearAnuncio.Click += new System.EventHandler(this.btnCrearAnuncio_Click);
            // 
            // lblContenidoAnuncio
            // 
            this.lblContenidoAnuncio.AutoSize = true;
            this.lblContenidoAnuncio.Location = new System.Drawing.Point(19, 48);
            this.lblContenidoAnuncio.Name = "lblContenidoAnuncio";
            this.lblContenidoAnuncio.Size = new System.Drawing.Size(97, 13);
            this.lblContenidoAnuncio.TabIndex = 6;
            this.lblContenidoAnuncio.Text = "Contenido Anuncio";
            // 
            // lblTituloAnuncio
            // 
            this.lblTituloAnuncio.AutoSize = true;
            this.lblTituloAnuncio.Location = new System.Drawing.Point(6, 21);
            this.lblTituloAnuncio.Name = "lblTituloAnuncio";
            this.lblTituloAnuncio.Size = new System.Drawing.Size(75, 13);
            this.lblTituloAnuncio.TabIndex = 5;
            this.lblTituloAnuncio.Text = "Titulo Anuncio";
            // 
            // FormCatedratico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 373);
            this.Controls.Add(this.grpGestionDeAnuncios);
            this.Controls.Add(this.grpTareasEntregadas);
            this.Controls.Add(this.grpGestionDeTareas);
            this.Controls.Add(this.grpCursosAsignados);
            this.Name = "FormCatedratico";
            this.Text = "FormCatedratico";
            this.grpCursosAsignados.ResumeLayout(false);
            this.grpCursosAsignados.PerformLayout();
            this.grpGestionDeTareas.ResumeLayout(false);
            this.grpGestionDeTareas.PerformLayout();
            this.grpTareasEntregadas.ResumeLayout(false);
            this.grpTareasEntregadas.PerformLayout();
            this.grpGestionDeAnuncios.ResumeLayout(false);
            this.grpGestionDeAnuncios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpCursosAsignados;
        private System.Windows.Forms.ListBox lstEstudiantes;
        private System.Windows.Forms.ComboBox cmbSeleccionarCurso;
        private System.Windows.Forms.Label lblSeleccionarCurso;
        private System.Windows.Forms.GroupBox grpGestionDeTareas;
        private System.Windows.Forms.Button btnCrearTarea;
        private System.Windows.Forms.TextBox txtDescripcionTarea;
        private System.Windows.Forms.TextBox txtNombreTarea;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.DateTimePicker dateFechaLimite;
        private System.Windows.Forms.Label lblDescripcionTarea;
        private System.Windows.Forms.Label lblNombreTarea;
        private System.Windows.Forms.GroupBox grpTareasEntregadas;
        private System.Windows.Forms.Button btnAsignarCalificacionTarea;
        private System.Windows.Forms.TextBox txtCalificacionTarea;
        private System.Windows.Forms.Label lblCalificarTareaSeleccionada;
        private System.Windows.Forms.ListBox lstTareasEntregadas;
        private System.Windows.Forms.Label lblTareasExistentes;
        private System.Windows.Forms.Button btnModificarTarea;
        private System.Windows.Forms.ComboBox cmbTareasExistentes;
        private System.Windows.Forms.GroupBox grpGestionDeAnuncios;
        private System.Windows.Forms.Label lblAnunciosExistentes;
        private System.Windows.Forms.Button btnEliminarAnuncio;
        private System.Windows.Forms.Button btnModificarAnuncio;
        private System.Windows.Forms.Button btnCrearAnuncio;
        private System.Windows.Forms.Label lblContenidoAnuncio;
        private System.Windows.Forms.Label lblTituloAnuncio;
        private System.Windows.Forms.TextBox txtContenidoAnuncio;
        private System.Windows.Forms.TextBox txtTituloAnuncio;
        private System.Windows.Forms.ComboBox cmbAnunciosExistentes;
        private System.Windows.Forms.Button btnEliminarTarea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblPuntosEstudianteSeleccionado;
    }
}

