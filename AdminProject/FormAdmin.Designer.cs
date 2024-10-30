namespace AdminProject
{
    partial class FormAdmin
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
            this.grpGestionDeCursos = new System.Windows.Forms.GroupBox();
            this.btnEliminarCurso = new System.Windows.Forms.Button();
            this.btnLimpiarGestionDeCursos = new System.Windows.Forms.Button();
            this.btnModificarCurso = new System.Windows.Forms.Button();
            this.btnCrearCurso = new System.Windows.Forms.Button();
            this.lblCursosExistentes = new System.Windows.Forms.Label();
            this.cmbCursos = new System.Windows.Forms.ComboBox();
            this.txtDescripcionCurso = new System.Windows.Forms.TextBox();
            this.lblDescripcionCurso = new System.Windows.Forms.Label();
            this.txtNombreCurso = new System.Windows.Forms.TextBox();
            this.lblNombreCurso = new System.Windows.Forms.Label();
            this.grpAsignarEstudiantesACursos = new System.Windows.Forms.GroupBox();
            this.btnLimpiarAsignarEstudiantesACursos = new System.Windows.Forms.Button();
            this.btnAsignarEstudiante = new System.Windows.Forms.Button();
            this.cmbEstudiantes = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarEstudiante = new System.Windows.Forms.Label();
            this.cmbCursoEstudiante = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarCursoEstudiante = new System.Windows.Forms.Label();
            this.grpAsignarCatedraticosACursos = new System.Windows.Forms.GroupBox();
            this.btnLimpiarAsignarCatedraticosACursos = new System.Windows.Forms.Button();
            this.btnAsignarCatedratico = new System.Windows.Forms.Button();
            this.cmbCatedraticos = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarCatedratico = new System.Windows.Forms.Label();
            this.cmbCursoCatedratico = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarCursoCatedratico = new System.Windows.Forms.Label();
            this.grpGestionDeUsuarios = new System.Windows.Forms.GroupBox();
            this.cmbUsuariosExistentes = new System.Windows.Forms.ComboBox();
            this.lblUsuariosExistentes = new System.Windows.Forms.Label();
            this.btnLimpiarGestionDeUsuarios = new System.Windows.Forms.Button();
            this.btnEliminarUsuario = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.btnCrearUsuario = new System.Windows.Forms.Button();
            this.cmbRolUsuario = new System.Windows.Forms.ComboBox();
            this.lblRolUsuario = new System.Windows.Forms.Label();
            this.txtEmailUsuario = new System.Windows.Forms.TextBox();
            this.lblEmailUsuario = new System.Windows.Forms.Label();
            this.txtApellidoUsuario = new System.Windows.Forms.TextBox();
            this.lblApellidoUsuario = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.lblNombreUsuario = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContraseñaUsuario = new System.Windows.Forms.TextBox();
            this.grpGestionDeCursos.SuspendLayout();
            this.grpAsignarEstudiantesACursos.SuspendLayout();
            this.grpAsignarCatedraticosACursos.SuspendLayout();
            this.grpGestionDeUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpGestionDeCursos
            // 
            this.grpGestionDeCursos.Controls.Add(this.btnEliminarCurso);
            this.grpGestionDeCursos.Controls.Add(this.btnLimpiarGestionDeCursos);
            this.grpGestionDeCursos.Controls.Add(this.btnModificarCurso);
            this.grpGestionDeCursos.Controls.Add(this.btnCrearCurso);
            this.grpGestionDeCursos.Controls.Add(this.lblCursosExistentes);
            this.grpGestionDeCursos.Controls.Add(this.cmbCursos);
            this.grpGestionDeCursos.Controls.Add(this.txtDescripcionCurso);
            this.grpGestionDeCursos.Controls.Add(this.lblDescripcionCurso);
            this.grpGestionDeCursos.Controls.Add(this.txtNombreCurso);
            this.grpGestionDeCursos.Controls.Add(this.lblNombreCurso);
            this.grpGestionDeCursos.Location = new System.Drawing.Point(12, 14);
            this.grpGestionDeCursos.Name = "grpGestionDeCursos";
            this.grpGestionDeCursos.Size = new System.Drawing.Size(316, 181);
            this.grpGestionDeCursos.TabIndex = 0;
            this.grpGestionDeCursos.TabStop = false;
            this.grpGestionDeCursos.Text = "Gestion de Cursos";
            // 
            // btnEliminarCurso
            // 
            this.btnEliminarCurso.Location = new System.Drawing.Point(139, 143);
            this.btnEliminarCurso.Name = "btnEliminarCurso";
            this.btnEliminarCurso.Size = new System.Drawing.Size(68, 23);
            this.btnEliminarCurso.TabIndex = 7;
            this.btnEliminarCurso.Text = "Eliminar";
            this.btnEliminarCurso.UseVisualStyleBackColor = true;
            this.btnEliminarCurso.Click += new System.EventHandler(this.btnEliminarCurso_Click);
            // 
            // btnLimpiarGestionDeCursos
            // 
            this.btnLimpiarGestionDeCursos.Location = new System.Drawing.Point(224, 143);
            this.btnLimpiarGestionDeCursos.Name = "btnLimpiarGestionDeCursos";
            this.btnLimpiarGestionDeCursos.Size = new System.Drawing.Size(73, 23);
            this.btnLimpiarGestionDeCursos.TabIndex = 8;
            this.btnLimpiarGestionDeCursos.Text = "Limpiar";
            this.btnLimpiarGestionDeCursos.UseVisualStyleBackColor = true;
            this.btnLimpiarGestionDeCursos.Click += new System.EventHandler(this.btnLimpiarGestionDeCursos_Click);
            // 
            // btnModificarCurso
            // 
            this.btnModificarCurso.Location = new System.Drawing.Point(66, 143);
            this.btnModificarCurso.Name = "btnModificarCurso";
            this.btnModificarCurso.Size = new System.Drawing.Size(68, 23);
            this.btnModificarCurso.TabIndex = 6;
            this.btnModificarCurso.Text = "Modificar";
            this.btnModificarCurso.UseVisualStyleBackColor = true;
            this.btnModificarCurso.Click += new System.EventHandler(this.btnModificarCurso_Click);
            // 
            // btnCrearCurso
            // 
            this.btnCrearCurso.Location = new System.Drawing.Point(9, 143);
            this.btnCrearCurso.Name = "btnCrearCurso";
            this.btnCrearCurso.Size = new System.Drawing.Size(51, 23);
            this.btnCrearCurso.TabIndex = 5;
            this.btnCrearCurso.Text = "Crear";
            this.btnCrearCurso.UseVisualStyleBackColor = true;
            this.btnCrearCurso.Click += new System.EventHandler(this.btnCrearCurso_Click);
            // 
            // lblCursosExistentes
            // 
            this.lblCursosExistentes.AutoSize = true;
            this.lblCursosExistentes.Location = new System.Drawing.Point(6, 99);
            this.lblCursosExistentes.Name = "lblCursosExistentes";
            this.lblCursosExistentes.Size = new System.Drawing.Size(90, 13);
            this.lblCursosExistentes.TabIndex = 4;
            this.lblCursosExistentes.Text = "Cursos Existentes";
            // 
            // cmbCursos
            // 
            this.cmbCursos.FormattingEnabled = true;
            this.cmbCursos.Location = new System.Drawing.Point(105, 96);
            this.cmbCursos.Name = "cmbCursos";
            this.cmbCursos.Size = new System.Drawing.Size(132, 21);
            this.cmbCursos.TabIndex = 1;
            // 
            // txtDescripcionCurso
            // 
            this.txtDescripcionCurso.Location = new System.Drawing.Point(105, 57);
            this.txtDescripcionCurso.Name = "txtDescripcionCurso";
            this.txtDescripcionCurso.Size = new System.Drawing.Size(132, 20);
            this.txtDescripcionCurso.TabIndex = 3;
            // 
            // lblDescripcionCurso
            // 
            this.lblDescripcionCurso.AutoSize = true;
            this.lblDescripcionCurso.Location = new System.Drawing.Point(6, 60);
            this.lblDescripcionCurso.Name = "lblDescripcionCurso";
            this.lblDescripcionCurso.Size = new System.Drawing.Size(93, 13);
            this.lblDescripcionCurso.TabIndex = 2;
            this.lblDescripcionCurso.Text = "Descripcion Curso";
            // 
            // txtNombreCurso
            // 
            this.txtNombreCurso.Location = new System.Drawing.Point(86, 19);
            this.txtNombreCurso.Name = "txtNombreCurso";
            this.txtNombreCurso.Size = new System.Drawing.Size(151, 20);
            this.txtNombreCurso.TabIndex = 1;
            // 
            // lblNombreCurso
            // 
            this.lblNombreCurso.AutoSize = true;
            this.lblNombreCurso.Location = new System.Drawing.Point(6, 22);
            this.lblNombreCurso.Name = "lblNombreCurso";
            this.lblNombreCurso.Size = new System.Drawing.Size(74, 13);
            this.lblNombreCurso.TabIndex = 0;
            this.lblNombreCurso.Text = "Nombre Curso";
            // 
            // grpAsignarEstudiantesACursos
            // 
            this.grpAsignarEstudiantesACursos.Controls.Add(this.btnLimpiarAsignarEstudiantesACursos);
            this.grpAsignarEstudiantesACursos.Controls.Add(this.btnAsignarEstudiante);
            this.grpAsignarEstudiantesACursos.Controls.Add(this.cmbEstudiantes);
            this.grpAsignarEstudiantesACursos.Controls.Add(this.lblSeleccionarEstudiante);
            this.grpAsignarEstudiantesACursos.Controls.Add(this.cmbCursoEstudiante);
            this.grpAsignarEstudiantesACursos.Controls.Add(this.lblSeleccionarCursoEstudiante);
            this.grpAsignarEstudiantesACursos.Location = new System.Drawing.Point(334, 14);
            this.grpAsignarEstudiantesACursos.Name = "grpAsignarEstudiantesACursos";
            this.grpAsignarEstudiantesACursos.Size = new System.Drawing.Size(247, 181);
            this.grpAsignarEstudiantesACursos.TabIndex = 1;
            this.grpAsignarEstudiantesACursos.TabStop = false;
            this.grpAsignarEstudiantesACursos.Text = "Asignar Estudiantes a Cursos";
            // 
            // btnLimpiarAsignarEstudiantesACursos
            // 
            this.btnLimpiarAsignarEstudiantesACursos.Location = new System.Drawing.Point(83, 134);
            this.btnLimpiarAsignarEstudiantesACursos.Name = "btnLimpiarAsignarEstudiantesACursos";
            this.btnLimpiarAsignarEstudiantesACursos.Size = new System.Drawing.Size(73, 23);
            this.btnLimpiarAsignarEstudiantesACursos.TabIndex = 9;
            this.btnLimpiarAsignarEstudiantesACursos.Text = "Limpiar";
            this.btnLimpiarAsignarEstudiantesACursos.UseVisualStyleBackColor = true;
            this.btnLimpiarAsignarEstudiantesACursos.Click += new System.EventHandler(this.btnLimpiarAsignarEstudiantesACursos_Click);
            // 
            // btnAsignarEstudiante
            // 
            this.btnAsignarEstudiante.Location = new System.Drawing.Point(66, 93);
            this.btnAsignarEstudiante.Name = "btnAsignarEstudiante";
            this.btnAsignarEstudiante.Size = new System.Drawing.Size(108, 23);
            this.btnAsignarEstudiante.TabIndex = 10;
            this.btnAsignarEstudiante.Text = "Asignar Estudiante";
            this.btnAsignarEstudiante.UseVisualStyleBackColor = true;
            this.btnAsignarEstudiante.Click += new System.EventHandler(this.btnAsignarEstudiante_Click);
            // 
            // cmbEstudiantes
            // 
            this.cmbEstudiantes.FormattingEnabled = true;
            this.cmbEstudiantes.Location = new System.Drawing.Point(128, 55);
            this.cmbEstudiantes.Name = "cmbEstudiantes";
            this.cmbEstudiantes.Size = new System.Drawing.Size(110, 21);
            this.cmbEstudiantes.TabIndex = 9;
            this.cmbEstudiantes.SelectedIndexChanged += new System.EventHandler(this.cmbEstudiantes_SelectedIndexChanged);
            // 
            // lblSeleccionarEstudiante
            // 
            this.lblSeleccionarEstudiante.AutoSize = true;
            this.lblSeleccionarEstudiante.Location = new System.Drawing.Point(6, 59);
            this.lblSeleccionarEstudiante.Name = "lblSeleccionarEstudiante";
            this.lblSeleccionarEstudiante.Size = new System.Drawing.Size(116, 13);
            this.lblSeleccionarEstudiante.TabIndex = 8;
            this.lblSeleccionarEstudiante.Text = "Seleccionar Estudiante";
            // 
            // cmbCursoEstudiante
            // 
            this.cmbCursoEstudiante.FormattingEnabled = true;
            this.cmbCursoEstudiante.Location = new System.Drawing.Point(105, 17);
            this.cmbCursoEstudiante.Name = "cmbCursoEstudiante";
            this.cmbCursoEstudiante.Size = new System.Drawing.Size(133, 21);
            this.cmbCursoEstudiante.TabIndex = 8;
            this.cmbCursoEstudiante.SelectedIndexChanged += new System.EventHandler(this.cmbCursoEstudiante_SelectedIndexChanged);
            // 
            // lblSeleccionarCursoEstudiante
            // 
            this.lblSeleccionarCursoEstudiante.AutoSize = true;
            this.lblSeleccionarCursoEstudiante.Location = new System.Drawing.Point(6, 22);
            this.lblSeleccionarCursoEstudiante.Name = "lblSeleccionarCursoEstudiante";
            this.lblSeleccionarCursoEstudiante.Size = new System.Drawing.Size(93, 13);
            this.lblSeleccionarCursoEstudiante.TabIndex = 8;
            this.lblSeleccionarCursoEstudiante.Text = "Seleccionar Curso";
            // 
            // grpAsignarCatedraticosACursos
            // 
            this.grpAsignarCatedraticosACursos.Controls.Add(this.btnLimpiarAsignarCatedraticosACursos);
            this.grpAsignarCatedraticosACursos.Controls.Add(this.btnAsignarCatedratico);
            this.grpAsignarCatedraticosACursos.Controls.Add(this.cmbCatedraticos);
            this.grpAsignarCatedraticosACursos.Controls.Add(this.lblSeleccionarCatedratico);
            this.grpAsignarCatedraticosACursos.Controls.Add(this.cmbCursoCatedratico);
            this.grpAsignarCatedraticosACursos.Controls.Add(this.lblSeleccionarCursoCatedratico);
            this.grpAsignarCatedraticosACursos.Location = new System.Drawing.Point(587, 14);
            this.grpAsignarCatedraticosACursos.Name = "grpAsignarCatedraticosACursos";
            this.grpAsignarCatedraticosACursos.Size = new System.Drawing.Size(244, 181);
            this.grpAsignarCatedraticosACursos.TabIndex = 11;
            this.grpAsignarCatedraticosACursos.TabStop = false;
            this.grpAsignarCatedraticosACursos.Text = "Asignar Catedraticos a Cursos";
            // 
            // btnLimpiarAsignarCatedraticosACursos
            // 
            this.btnLimpiarAsignarCatedraticosACursos.Location = new System.Drawing.Point(84, 134);
            this.btnLimpiarAsignarCatedraticosACursos.Name = "btnLimpiarAsignarCatedraticosACursos";
            this.btnLimpiarAsignarCatedraticosACursos.Size = new System.Drawing.Size(73, 23);
            this.btnLimpiarAsignarCatedraticosACursos.TabIndex = 11;
            this.btnLimpiarAsignarCatedraticosACursos.Text = "Limpiar";
            this.btnLimpiarAsignarCatedraticosACursos.UseVisualStyleBackColor = true;
            this.btnLimpiarAsignarCatedraticosACursos.Click += new System.EventHandler(this.btnLimpiarAsignarCatedraticosACursos_Click);
            // 
            // btnAsignarCatedratico
            // 
            this.btnAsignarCatedratico.Location = new System.Drawing.Point(66, 93);
            this.btnAsignarCatedratico.Name = "btnAsignarCatedratico";
            this.btnAsignarCatedratico.Size = new System.Drawing.Size(108, 23);
            this.btnAsignarCatedratico.TabIndex = 10;
            this.btnAsignarCatedratico.Text = "Asignar Catedratico";
            this.btnAsignarCatedratico.UseVisualStyleBackColor = true;
            this.btnAsignarCatedratico.Click += new System.EventHandler(this.btnAsignarCatedratico_Click);
            // 
            // cmbCatedraticos
            // 
            this.cmbCatedraticos.FormattingEnabled = true;
            this.cmbCatedraticos.Location = new System.Drawing.Point(128, 55);
            this.cmbCatedraticos.Name = "cmbCatedraticos";
            this.cmbCatedraticos.Size = new System.Drawing.Size(110, 21);
            this.cmbCatedraticos.TabIndex = 9;
            // 
            // lblSeleccionarCatedratico
            // 
            this.lblSeleccionarCatedratico.AutoSize = true;
            this.lblSeleccionarCatedratico.Location = new System.Drawing.Point(6, 59);
            this.lblSeleccionarCatedratico.Name = "lblSeleccionarCatedratico";
            this.lblSeleccionarCatedratico.Size = new System.Drawing.Size(120, 13);
            this.lblSeleccionarCatedratico.TabIndex = 8;
            this.lblSeleccionarCatedratico.Text = "Seleccionar Catedratico";
            // 
            // cmbCursoCatedratico
            // 
            this.cmbCursoCatedratico.FormattingEnabled = true;
            this.cmbCursoCatedratico.Location = new System.Drawing.Point(105, 17);
            this.cmbCursoCatedratico.Name = "cmbCursoCatedratico";
            this.cmbCursoCatedratico.Size = new System.Drawing.Size(133, 21);
            this.cmbCursoCatedratico.TabIndex = 8;
            this.cmbCursoCatedratico.SelectedIndexChanged += new System.EventHandler(this.cmbCursoCatedratico_SelectedIndexChanged);
            // 
            // lblSeleccionarCursoCatedratico
            // 
            this.lblSeleccionarCursoCatedratico.AutoSize = true;
            this.lblSeleccionarCursoCatedratico.Location = new System.Drawing.Point(6, 22);
            this.lblSeleccionarCursoCatedratico.Name = "lblSeleccionarCursoCatedratico";
            this.lblSeleccionarCursoCatedratico.Size = new System.Drawing.Size(93, 13);
            this.lblSeleccionarCursoCatedratico.TabIndex = 8;
            this.lblSeleccionarCursoCatedratico.Text = "Seleccionar Curso";
            // 
            // grpGestionDeUsuarios
            // 
            this.grpGestionDeUsuarios.Controls.Add(this.txtContraseñaUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.label1);
            this.grpGestionDeUsuarios.Controls.Add(this.cmbUsuariosExistentes);
            this.grpGestionDeUsuarios.Controls.Add(this.lblUsuariosExistentes);
            this.grpGestionDeUsuarios.Controls.Add(this.btnLimpiarGestionDeUsuarios);
            this.grpGestionDeUsuarios.Controls.Add(this.btnEliminarUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.btnModificarUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.btnCrearUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.cmbRolUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.lblRolUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.txtEmailUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.lblEmailUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.txtApellidoUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.lblApellidoUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.txtNombreUsuario);
            this.grpGestionDeUsuarios.Controls.Add(this.lblNombreUsuario);
            this.grpGestionDeUsuarios.Location = new System.Drawing.Point(12, 213);
            this.grpGestionDeUsuarios.Name = "grpGestionDeUsuarios";
            this.grpGestionDeUsuarios.Size = new System.Drawing.Size(604, 141);
            this.grpGestionDeUsuarios.TabIndex = 12;
            this.grpGestionDeUsuarios.TabStop = false;
            this.grpGestionDeUsuarios.Text = "Gestion de Usuarios";
            // 
            // cmbUsuariosExistentes
            // 
            this.cmbUsuariosExistentes.FormattingEnabled = true;
            this.cmbUsuariosExistentes.Location = new System.Drawing.Point(463, 61);
            this.cmbUsuariosExistentes.Name = "cmbUsuariosExistentes";
            this.cmbUsuariosExistentes.Size = new System.Drawing.Size(120, 21);
            this.cmbUsuariosExistentes.TabIndex = 23;
            this.cmbUsuariosExistentes.SelectedIndexChanged += new System.EventHandler(this.cmbUsuariosExistentes_SelectedIndexChanged);
            // 
            // lblUsuariosExistentes
            // 
            this.lblUsuariosExistentes.AutoSize = true;
            this.lblUsuariosExistentes.Location = new System.Drawing.Point(358, 64);
            this.lblUsuariosExistentes.Name = "lblUsuariosExistentes";
            this.lblUsuariosExistentes.Size = new System.Drawing.Size(99, 13);
            this.lblUsuariosExistentes.TabIndex = 22;
            this.lblUsuariosExistentes.Text = "Usuarios Existentes";
            // 
            // btnLimpiarGestionDeUsuarios
            // 
            this.btnLimpiarGestionDeUsuarios.Location = new System.Drawing.Point(324, 102);
            this.btnLimpiarGestionDeUsuarios.Name = "btnLimpiarGestionDeUsuarios";
            this.btnLimpiarGestionDeUsuarios.Size = new System.Drawing.Size(73, 23);
            this.btnLimpiarGestionDeUsuarios.TabIndex = 11;
            this.btnLimpiarGestionDeUsuarios.Text = "Limpiar";
            this.btnLimpiarGestionDeUsuarios.UseVisualStyleBackColor = true;
            this.btnLimpiarGestionDeUsuarios.Click += new System.EventHandler(this.btnLimpiarGestionDeUsuarios_Click);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.Location = new System.Drawing.Point(219, 102);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.Size = new System.Drawing.Size(99, 23);
            this.btnEliminarUsuario.TabIndex = 21;
            this.btnEliminarUsuario.Text = "Eliminar Usuario";
            this.btnEliminarUsuario.UseVisualStyleBackColor = true;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.Location = new System.Drawing.Point(114, 102);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(99, 23);
            this.btnModificarUsuario.TabIndex = 20;
            this.btnModificarUsuario.Text = "Modificar Usuario";
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);
            // 
            // btnCrearUsuario
            // 
            this.btnCrearUsuario.Location = new System.Drawing.Point(9, 102);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new System.Drawing.Size(99, 23);
            this.btnCrearUsuario.TabIndex = 13;
            this.btnCrearUsuario.Text = "Crear Usuario";
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            // 
            // cmbRolUsuario
            // 
            this.cmbRolUsuario.FormattingEnabled = true;
            this.cmbRolUsuario.Location = new System.Drawing.Point(234, 64);
            this.cmbRolUsuario.Name = "cmbRolUsuario";
            this.cmbRolUsuario.Size = new System.Drawing.Size(100, 21);
            this.cmbRolUsuario.TabIndex = 8;
            this.cmbRolUsuario.SelectedIndexChanged += new System.EventHandler(this.cmbRolUsuario_SelectedIndexChanged);
            // 
            // lblRolUsuario
            // 
            this.lblRolUsuario.AutoSize = true;
            this.lblRolUsuario.Location = new System.Drawing.Point(184, 67);
            this.lblRolUsuario.Name = "lblRolUsuario";
            this.lblRolUsuario.Size = new System.Drawing.Size(23, 13);
            this.lblRolUsuario.TabIndex = 19;
            this.lblRolUsuario.Text = "Rol";
            // 
            // txtEmailUsuario
            // 
            this.txtEmailUsuario.Location = new System.Drawing.Point(234, 23);
            this.txtEmailUsuario.Name = "txtEmailUsuario";
            this.txtEmailUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtEmailUsuario.TabIndex = 18;
            // 
            // lblEmailUsuario
            // 
            this.lblEmailUsuario.AutoSize = true;
            this.lblEmailUsuario.Location = new System.Drawing.Point(184, 26);
            this.lblEmailUsuario.Name = "lblEmailUsuario";
            this.lblEmailUsuario.Size = new System.Drawing.Size(32, 13);
            this.lblEmailUsuario.TabIndex = 17;
            this.lblEmailUsuario.Text = "Email";
            // 
            // txtApellidoUsuario
            // 
            this.txtApellidoUsuario.Location = new System.Drawing.Point(62, 64);
            this.txtApellidoUsuario.Name = "txtApellidoUsuario";
            this.txtApellidoUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtApellidoUsuario.TabIndex = 16;
            // 
            // lblApellidoUsuario
            // 
            this.lblApellidoUsuario.AutoSize = true;
            this.lblApellidoUsuario.Location = new System.Drawing.Point(12, 67);
            this.lblApellidoUsuario.Name = "lblApellidoUsuario";
            this.lblApellidoUsuario.Size = new System.Drawing.Size(44, 13);
            this.lblApellidoUsuario.TabIndex = 15;
            this.lblApellidoUsuario.Text = "Apellido";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(62, 23);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtNombreUsuario.TabIndex = 14;
            // 
            // lblNombreUsuario
            // 
            this.lblNombreUsuario.AutoSize = true;
            this.lblNombreUsuario.Location = new System.Drawing.Point(12, 26);
            this.lblNombreUsuario.Name = "lblNombreUsuario";
            this.lblNombreUsuario.Size = new System.Drawing.Size(44, 13);
            this.lblNombreUsuario.TabIndex = 13;
            this.lblNombreUsuario.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(360, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Contraseña";
            // 
            // txtContraseñaUsuario
            // 
            this.txtContraseñaUsuario.Location = new System.Drawing.Point(432, 23);
            this.txtContraseñaUsuario.Name = "txtContraseñaUsuario";
            this.txtContraseñaUsuario.Size = new System.Drawing.Size(151, 20);
            this.txtContraseñaUsuario.TabIndex = 25;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 366);
            this.Controls.Add(this.grpGestionDeUsuarios);
            this.Controls.Add(this.grpAsignarCatedraticosACursos);
            this.Controls.Add(this.grpAsignarEstudiantesACursos);
            this.Controls.Add(this.grpGestionDeCursos);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.grpGestionDeCursos.ResumeLayout(false);
            this.grpGestionDeCursos.PerformLayout();
            this.grpAsignarEstudiantesACursos.ResumeLayout(false);
            this.grpAsignarEstudiantesACursos.PerformLayout();
            this.grpAsignarCatedraticosACursos.ResumeLayout(false);
            this.grpAsignarCatedraticosACursos.PerformLayout();
            this.grpGestionDeUsuarios.ResumeLayout(false);
            this.grpGestionDeUsuarios.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpGestionDeCursos;
        private System.Windows.Forms.Button btnEliminarCurso;
        private System.Windows.Forms.Button btnModificarCurso;
        private System.Windows.Forms.Button btnCrearCurso;
        private System.Windows.Forms.Label lblCursosExistentes;
        private System.Windows.Forms.ComboBox cmbCursos;
        private System.Windows.Forms.TextBox txtDescripcionCurso;
        private System.Windows.Forms.Label lblDescripcionCurso;
        private System.Windows.Forms.TextBox txtNombreCurso;
        private System.Windows.Forms.Label lblNombreCurso;
        private System.Windows.Forms.GroupBox grpAsignarEstudiantesACursos;
        private System.Windows.Forms.Label lblSeleccionarEstudiante;
        private System.Windows.Forms.ComboBox cmbCursoEstudiante;
        private System.Windows.Forms.Label lblSeleccionarCursoEstudiante;
        private System.Windows.Forms.ComboBox cmbEstudiantes;
        private System.Windows.Forms.Button btnAsignarEstudiante;
        private System.Windows.Forms.GroupBox grpAsignarCatedraticosACursos;
        private System.Windows.Forms.Button btnAsignarCatedratico;
        private System.Windows.Forms.ComboBox cmbCatedraticos;
        private System.Windows.Forms.Label lblSeleccionarCatedratico;
        private System.Windows.Forms.ComboBox cmbCursoCatedratico;
        private System.Windows.Forms.Label lblSeleccionarCursoCatedratico;
        private System.Windows.Forms.GroupBox grpGestionDeUsuarios;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label lblNombreUsuario;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Button btnCrearUsuario;
        private System.Windows.Forms.ComboBox cmbRolUsuario;
        private System.Windows.Forms.Label lblRolUsuario;
        private System.Windows.Forms.TextBox txtEmailUsuario;
        private System.Windows.Forms.Label lblEmailUsuario;
        private System.Windows.Forms.TextBox txtApellidoUsuario;
        private System.Windows.Forms.Label lblApellidoUsuario;
        private System.Windows.Forms.Button btnLimpiarGestionDeCursos;
        private System.Windows.Forms.Button btnLimpiarAsignarEstudiantesACursos;
        private System.Windows.Forms.Button btnLimpiarAsignarCatedraticosACursos;
        private System.Windows.Forms.Button btnLimpiarGestionDeUsuarios;
        private System.Windows.Forms.ComboBox cmbUsuariosExistentes;
        private System.Windows.Forms.Label lblUsuariosExistentes;
        private System.Windows.Forms.TextBox txtContraseñaUsuario;
        private System.Windows.Forms.Label label1;
    }
}

