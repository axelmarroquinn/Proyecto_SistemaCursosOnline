namespace EstudianteProject
{
    partial class FormEstudiante
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
            this.lblSeleccionarCurso = new System.Windows.Forms.Label();
            this.cmbSeleccionarCurso = new System.Windows.Forms.ComboBox();
            this.lblTareasDelCurso = new System.Windows.Forms.Label();
            this.btnEntregarTarea = new System.Windows.Forms.Button();
            this.lblAnunciosDelCurso = new System.Windows.Forms.Label();
            this.lstvwAnunciosCurso = new System.Windows.Forms.ListView();
            this.lstvwTareasCursoEstudiante = new System.Windows.Forms.ListView();
            this.lblPuntosTotalesCurso = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblSeleccionarCurso
            // 
            this.lblSeleccionarCurso.AutoSize = true;
            this.lblSeleccionarCurso.Location = new System.Drawing.Point(12, 14);
            this.lblSeleccionarCurso.Name = "lblSeleccionarCurso";
            this.lblSeleccionarCurso.Size = new System.Drawing.Size(93, 13);
            this.lblSeleccionarCurso.TabIndex = 0;
            this.lblSeleccionarCurso.Text = "Seleccionar Curso";
            // 
            // cmbSeleccionarCurso
            // 
            this.cmbSeleccionarCurso.FormattingEnabled = true;
            this.cmbSeleccionarCurso.Location = new System.Drawing.Point(111, 10);
            this.cmbSeleccionarCurso.Name = "cmbSeleccionarCurso";
            this.cmbSeleccionarCurso.Size = new System.Drawing.Size(205, 21);
            this.cmbSeleccionarCurso.TabIndex = 1;
            this.cmbSeleccionarCurso.SelectedIndexChanged += new System.EventHandler(this.cmbSeleccionarCurso_SelectedIndexChanged);
            // 
            // lblTareasDelCurso
            // 
            this.lblTareasDelCurso.AutoSize = true;
            this.lblTareasDelCurso.Location = new System.Drawing.Point(12, 48);
            this.lblTareasDelCurso.Name = "lblTareasDelCurso";
            this.lblTareasDelCurso.Size = new System.Drawing.Size(238, 13);
            this.lblTareasDelCurso.TabIndex = 3;
            this.lblTareasDelCurso.Text = "Tareas Del Curso (Selecciona la tarea a manejar)";
            // 
            // btnEntregarTarea
            // 
            this.btnEntregarTarea.Location = new System.Drawing.Point(12, 234);
            this.btnEntregarTarea.Name = "btnEntregarTarea";
            this.btnEntregarTarea.Size = new System.Drawing.Size(109, 23);
            this.btnEntregarTarea.TabIndex = 4;
            this.btnEntregarTarea.Text = "Entregar Tarea";
            this.btnEntregarTarea.UseVisualStyleBackColor = true;
            this.btnEntregarTarea.Click += new System.EventHandler(this.btnEntregarTarea_Click);
            // 
            // lblAnunciosDelCurso
            // 
            this.lblAnunciosDelCurso.AutoSize = true;
            this.lblAnunciosDelCurso.Location = new System.Drawing.Point(508, 13);
            this.lblAnunciosDelCurso.Name = "lblAnunciosDelCurso";
            this.lblAnunciosDelCurso.Size = new System.Drawing.Size(100, 13);
            this.lblAnunciosDelCurso.TabIndex = 5;
            this.lblAnunciosDelCurso.Text = "Anuncios Del Curso";
            // 
            // lstvwAnunciosCurso
            // 
            this.lstvwAnunciosCurso.HideSelection = false;
            this.lstvwAnunciosCurso.Location = new System.Drawing.Point(511, 29);
            this.lstvwAnunciosCurso.Name = "lstvwAnunciosCurso";
            this.lstvwAnunciosCurso.Size = new System.Drawing.Size(292, 199);
            this.lstvwAnunciosCurso.TabIndex = 6;
            this.lstvwAnunciosCurso.UseCompatibleStateImageBehavior = false;
            // 
            // lstvwTareasCursoEstudiante
            // 
            this.lstvwTareasCursoEstudiante.HideSelection = false;
            this.lstvwTareasCursoEstudiante.Location = new System.Drawing.Point(12, 64);
            this.lstvwTareasCursoEstudiante.Name = "lstvwTareasCursoEstudiante";
            this.lstvwTareasCursoEstudiante.Size = new System.Drawing.Size(485, 164);
            this.lstvwTareasCursoEstudiante.TabIndex = 7;
            this.lstvwTareasCursoEstudiante.UseCompatibleStateImageBehavior = false;
            // 
            // lblPuntosTotalesCurso
            // 
            this.lblPuntosTotalesCurso.AutoSize = true;
            this.lblPuntosTotalesCurso.Location = new System.Drawing.Point(214, 239);
            this.lblPuntosTotalesCurso.Name = "lblPuntosTotalesCurso";
            this.lblPuntosTotalesCurso.Size = new System.Drawing.Size(81, 13);
            this.lblPuntosTotalesCurso.TabIndex = 8;
            this.lblPuntosTotalesCurso.Text = "Puntos Totales:";
            // 
            // FormEstudiante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 266);
            this.Controls.Add(this.lblPuntosTotalesCurso);
            this.Controls.Add(this.lstvwTareasCursoEstudiante);
            this.Controls.Add(this.lstvwAnunciosCurso);
            this.Controls.Add(this.lblAnunciosDelCurso);
            this.Controls.Add(this.btnEntregarTarea);
            this.Controls.Add(this.lblTareasDelCurso);
            this.Controls.Add(this.cmbSeleccionarCurso);
            this.Controls.Add(this.lblSeleccionarCurso);
            this.Name = "FormEstudiante";
            this.RightToLeftLayout = true;
            this.Text = "FormEstudiante";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSeleccionarCurso;
        private System.Windows.Forms.ComboBox cmbSeleccionarCurso;
        private System.Windows.Forms.Label lblTareasDelCurso;
        private System.Windows.Forms.Button btnEntregarTarea;
        private System.Windows.Forms.Label lblAnunciosDelCurso;
        private System.Windows.Forms.ListView lstvwAnunciosCurso;
        private System.Windows.Forms.ListView lstvwTareasCursoEstudiante;
        private System.Windows.Forms.Label lblPuntosTotalesCurso;
    }
}

