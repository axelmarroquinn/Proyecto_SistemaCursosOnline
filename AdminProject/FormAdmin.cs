using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdminProject
{
    public partial class FormAdmin : Form
    {
        // Constructor principal del FormAdmin

        #region Constructor FormAdmin
        public FormAdmin()
        {
            InitializeComponent();
            TemaClaro.Aplicar(this);
            CargarCursos();
            CargarEstudiantes();
            CargarCatedraticos();
            CargarRolesUsuario();
            CargarUsuariosExistentes();

            // Vincular los eventos a sus respectivos ComboBox
            cmbCursos.SelectedIndexChanged += cmbCursos_SelectedIndexChanged;
            cmbCursoEstudiante.SelectedIndexChanged += cmbCursoEstudiante_SelectedIndexChanged;
            cmbEstudiantes.SelectedIndexChanged += cmbEstudiantes_SelectedIndexChanged;
            cmbCursoCatedratico.SelectedIndexChanged += cmbCursoCatedratico_SelectedIndexChanged;
            cmbCatedraticos.SelectedIndexChanged += cmbCatedraticos_SelectedIndexChanged;
            cmbUsuariosExistentes.SelectedIndexChanged += cmbUsuariosExistentes_SelectedIndexChanged;


            // Limpiar las selecciones por defecto
            cmbCursos.SelectedIndex = -1;
            cmbCursoEstudiante.SelectedIndex = -1;
            cmbEstudiantes.SelectedIndex = -1;
            cmbCursoCatedratico.SelectedIndex = -1;
            cmbCatedraticos.SelectedIndex = -1;
            cmbUsuariosExistentes.SelectedIndex = -1;


            txtNombreCurso.Clear();
            txtDescripcionCurso.Clear();
        }
        #endregion

        // Métodos utilizados para funcionalidad

        #region CargarCursos
        private void CargarCursos()
        {
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    string query = "SELECT CursoId, NombreCurso FROM Curso";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, cnx);
                    DataTable cursos = new DataTable();
                    adapter.Fill(cursos);

                    // Llenar cmbCursos para la gestión de cursos
                    cmbCursos.DataSource = cursos.Copy();  // Usar una copia independiente de los datos
                    cmbCursos.DisplayMember = "NombreCurso";
                    cmbCursos.ValueMember = "CursoId";

                    // Llenar cmbCursoEstudiante para asignación de estudiantes
                    cmbCursoEstudiante.DataSource = cursos.Copy();  // Usar una copia independiente de los datos
                    cmbCursoEstudiante.DisplayMember = "NombreCurso";
                    cmbCursoEstudiante.ValueMember = "CursoId";

                    // Llenar cmbCursoCatedratico para asignación de catedráticos
                    cmbCursoCatedratico.DataSource = cursos.Copy();  // Usar una copia independiente de los datos
                    cmbCursoCatedratico.DisplayMember = "NombreCurso";
                    cmbCursoCatedratico.ValueMember = "CursoId";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los cursos: " + ex.Message);
                }
            }
        }
        #endregion

        #region CargarEstudiantes
        private void CargarEstudiantes()
        {
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Consulta para seleccionar solo los usuarios con el rol 'Estudiante'
                    string query = "SELECT Id, Nombre + ' ' + Apellido AS NombreCompleto FROM Usuario WHERE Rol = 'Estudiante'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, cnx);
                    DataTable estudiantes = new DataTable();
                    adapter.Fill(estudiantes);

                    // Llenar el ComboBox con los estudiantes
                    cmbEstudiantes.DataSource = estudiantes;
                    cmbEstudiantes.DisplayMember = "NombreCompleto"; // Muestra el nombre completo (Nombre + Apellido)
                    cmbEstudiantes.ValueMember = "Id"; // El valor oculto será el Id del estudiante

                    // Limpiar la selección por defecto
                    cmbEstudiantes.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los estudiantes: " + ex.Message);
                }
            }
        }
        #endregion

        #region CargarCatedraticos
        private void CargarCatedraticos()
        {
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Consulta para seleccionar solo los usuarios con el rol 'Catedratico'
                    string query = "SELECT Id, Nombre + ' ' + Apellido AS NombreCompleto FROM Usuario WHERE Rol = 'Catedratico'";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, cnx);
                    DataTable catedraticos = new DataTable();
                    adapter.Fill(catedraticos);

                    // Llenar el ComboBox con los catedráticos
                    cmbCatedraticos.DataSource = catedraticos;
                    cmbCatedraticos.DisplayMember = "NombreCompleto"; // Muestra el nombre completo (Nombre + Apellido)
                    cmbCatedraticos.ValueMember = "Id"; // El valor oculto será el Id del catedrático

                    // Limpiar la selección por defecto
                    cmbCatedraticos.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los catedráticos: " + ex.Message);
                }
            }
        }
        #endregion

        #region CargarRolesUsuario
        private void CargarRolesUsuario()
        {
            // Limpiar cualquier elemento existente en el ComboBox
            cmbRolUsuario.Items.Clear();

            // Agregar los roles disponibles
            cmbRolUsuario.Items.Add("Administrador");
            cmbRolUsuario.Items.Add("Estudiante");
            cmbRolUsuario.Items.Add("Catedratico");

            // Opcional: establecer el índice por defecto, si deseas que esté vacío al iniciar
            cmbRolUsuario.SelectedIndex = -1;  // Ningún rol seleccionado por defecto
        }
        #endregion

        #region CargarUsuariosExistentes
        private void CargarUsuariosExistentes()
        {
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "SELECT Id, Nombre + ' ' + Apellido AS NombreCompleto FROM Usuario";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, cnx);
                    DataTable usuarios = new DataTable();
                    adapter.Fill(usuarios);

                    // Llenar el ComboBox con los usuarios existentes
                    cmbUsuariosExistentes.DataSource = usuarios;
                    cmbUsuariosExistentes.DisplayMember = "NombreCompleto";
                    cmbUsuariosExistentes.ValueMember = "Id";

                    // Limpiar la selección por defecto
                    cmbUsuariosExistentes.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los usuarios: " + ex.Message);
                }
            }
        }

        #endregion 

        // Interfaz gráfica

        #region Gestion de Cursos
        private void btnCrearCurso_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCurso.Text) || string.IsNullOrWhiteSpace(txtDescripcionCurso.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de crear un curso.");
                return;
            }

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "INSERT INTO Curso (NombreCurso, Descripcion) VALUES (@NombreCurso, @Descripcion)";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", txtNombreCurso.Text);
                        command.Parameters.AddWithValue("@Descripcion", txtDescripcionCurso.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Curso creado exitosamente.");
                        CargarCursos(); // Actualizar la lista de cursos
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el curso: " + ex.Message);
                }
            }
        }

        private void btnModificarCurso_Click(object sender, EventArgs e)
        {
            if (cmbCursos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un curso para modificar.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreCurso.Text) || string.IsNullOrWhiteSpace(txtDescripcionCurso.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de modificar el curso.");
                return;
            }

            int cursoId = (int)cmbCursos.SelectedValue;

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "UPDATE Curso SET NombreCurso = @NombreCurso, Descripcion = @Descripcion WHERE CursoId = @CursoId";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", txtNombreCurso.Text);
                        command.Parameters.AddWithValue("@Descripcion", txtDescripcionCurso.Text);
                        command.Parameters.AddWithValue("@CursoId", cursoId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Curso modificado exitosamente.");
                        CargarCursos(); // Actualizar la lista de cursos
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el curso: " + ex.Message);
                }
            }
        }

        private void btnEliminarCurso_Click(object sender, EventArgs e)
        {
            if (cmbCursos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un curso para eliminar.");
                return;
            }

            int cursoId = (int)cmbCursos.SelectedValue;

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "DELETE FROM Curso WHERE CursoId = @CursoId";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@CursoId", cursoId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Curso eliminado exitosamente.");
                        CargarCursos(); // Actualizar la lista de cursos
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el curso: " + ex.Message);
                }
            }
        }

        private void cmbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCursos.SelectedIndex == -1)
            {
                txtNombreCurso.Clear();
                txtDescripcionCurso.Clear();
                return;
            }

            int cursoId = (int)cmbCursos.SelectedValue;

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "SELECT NombreCurso, Descripcion FROM Curso WHERE CursoId = @CursoId";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@CursoId", cursoId);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            txtNombreCurso.Text = reader["NombreCurso"].ToString();
                            txtDescripcionCurso.Text = reader["Descripcion"].ToString();
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los detalles del curso: " + ex.Message);
                }
            }
        }

        private void btnLimpiarGestionDeCursos_Click(object sender, EventArgs e)
        {
            txtNombreCurso.Clear();
            txtDescripcionCurso.Clear();
            cmbCursos.SelectedIndex = -1;
        }
        #endregion

        #region Asignar Estudiantes a Cursos

        private void cmbCursoEstudiante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCursos.SelectedIndex == -1)
            {
                txtNombreCurso.Clear();
                txtDescripcionCurso.Clear();
                return;
            }

            int cursoId = (int)cmbCursos.SelectedValue;

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "SELECT NombreCurso, Descripcion FROM Curso WHERE CursoId = @CursoId";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@CursoId", cursoId);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            txtNombreCurso.Text = reader["NombreCurso"].ToString();
                            txtDescripcionCurso.Text = reader["Descripcion"].ToString();
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los detalles del curso: " + ex.Message);
                }
            }
        }
        private void cmbEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEstudiantes.SelectedIndex == -1)
            {
                return;
            }
            int estudianteId = (int)cmbEstudiantes.SelectedValue;
            // Obtener el nombre completo del estudiante seleccionado
            string nombreCompleto = cmbEstudiantes.Text;
        }
        private void btnAsignarEstudiante_Click(object sender, EventArgs e)
        {
            // Verificar que ambos ComboBox tengan una selección válida
            if (cmbCursoEstudiante.SelectedIndex == -1 || cmbEstudiantes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un curso y un estudiante antes de asignar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el CursoId del curso seleccionado
            int cursoId = (int)cmbCursoEstudiante.SelectedValue;

            // Obtener el UsuarioId del estudiante seleccionado
            int estudianteId = (int)cmbEstudiantes.SelectedValue;

            // Obtener el nombre del curso y el nombre completo del estudiante (solo para mostrar en el MessageBox)
            string nombreCurso = cmbCursoEstudiante.Text;
            string nombreEstudiante = cmbEstudiantes.Text;

            // Conectar a la base de datos e insertar la asignación en la tabla CursoUsuario
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Verificar si la asignación ya existe (opcional, puedes omitir esto si lo prefieres)
                    string checkQuery = "SELECT COUNT(*) FROM CursoUsuario WHERE CursoId = @CursoId AND UsuarioId = @UsuarioId";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, cnx))
                    {
                        checkCommand.Parameters.AddWithValue("@CursoId", cursoId);
                        checkCommand.Parameters.AddWithValue("@UsuarioId", estudianteId);

                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show($"El estudiante {nombreEstudiante} ya está asignado al curso {nombreCurso}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insertar la asignación en la tabla CursoUsuario
                    string query = "INSERT INTO CursoUsuario (CursoId, UsuarioId) VALUES (@CursoId, @UsuarioId)";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@CursoId", cursoId);
                        command.Parameters.AddWithValue("@UsuarioId", estudianteId);

                        command.ExecuteNonQuery();
                        MessageBox.Show($"Estudiante {nombreEstudiante} asignado al curso {nombreCurso} correctamente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al asignar el estudiante al curso: " + ex.Message);
                }
            }
        }
        private void btnLimpiarAsignarEstudiantesACursos_Click(object sender, EventArgs e)
        {
            cmbCursoEstudiante.SelectedIndex = -1;
            cmbEstudiantes.SelectedIndex = -1;
        }
        #endregion

        #region Asignar Catedraticos a Cursos
        private void cmbCursoCatedratico_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que haya una selección válida en cmbCursoCatedratico
            if (cmbCursoCatedratico.SelectedIndex == -1)
            {
                return;
            }

            // Obtener el CursoId del curso seleccionado en cmbCursoCatedratico
            int cursoId = (int)cmbCursoCatedratico.SelectedValue;

            // Lógica para manejar la selección de cursos para asignar catedráticos sin afectar los TextBox
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "SELECT NombreCurso, Descripcion FROM Curso WHERE CursoId = @CursoId";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@CursoId", cursoId);

                        SqlDataReader reader = command.ExecuteReader();


                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los detalles del curso: " + ex.Message);
                }
            }
        }

        private void cmbCatedraticos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCatedraticos.SelectedIndex == -1)
            {
                return;
            }

            int catedraticoId = (int)cmbCatedraticos.SelectedValue;
            string nombreCatedratico = cmbCatedraticos.Text;


        }
        private void btnAsignarCatedratico_Click(object sender, EventArgs e)
        {
            // Verificar que ambos ComboBox tengan una selección válida
            if (cmbCursoCatedratico.SelectedIndex == -1 || cmbCatedraticos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un curso y un catedrático antes de asignar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener el CursoId del curso seleccionado
            int cursoId = (int)cmbCursoCatedratico.SelectedValue;

            // Obtener el UsuarioId del catedrático seleccionado
            int catedraticoId = (int)cmbCatedraticos.SelectedValue;

            // Obtener el nombre del curso y el nombre completo del catedrático (solo para mostrar en el MessageBox)
            string nombreCurso = cmbCursoCatedratico.Text;
            string nombreCatedratico = cmbCatedraticos.Text;

            // Conectar a la base de datos e insertar la asignación en la tabla CursoUsuario
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Verificar si la asignación ya existe (opcional)
                    string checkQuery = "SELECT COUNT(*) FROM CursoUsuario WHERE CursoId = @CursoId AND UsuarioId = @UsuarioId";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, cnx))
                    {
                        checkCommand.Parameters.AddWithValue("@CursoId", cursoId);
                        checkCommand.Parameters.AddWithValue("@UsuarioId", catedraticoId);

                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show($"El catedrático {nombreCatedratico} ya está asignado al curso {nombreCurso}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insertar la asignación en la tabla CursoUsuario
                    string query = "INSERT INTO CursoUsuario (CursoId, UsuarioId) VALUES (@CursoId, @UsuarioId)";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@CursoId", cursoId);
                        command.Parameters.AddWithValue("@UsuarioId", catedraticoId);

                        command.ExecuteNonQuery();
                        MessageBox.Show($"Catedrático {nombreCatedratico} asignado al curso {nombreCurso} correctamente.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al asignar el catedrático al curso: " + ex.Message);
                }
            }
        }
        private void btnLimpiarAsignarCatedraticosACursos_Click(object sender, EventArgs e)
        {
            cmbCursoCatedratico.SelectedIndex = -1;
            cmbCatedraticos.SelectedIndex = -1;
        }

        #endregion

        #region Gestión de Usuarios
        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtEmailUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseñaUsuario.Text) ||  // Verificar que se haya ingresado una contraseña
                cmbRolUsuario.SelectedIndex == -1)  // Verificar que se haya seleccionado un rol
            {
                MessageBox.Show("Por favor, complete todos los campos y seleccione un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombreUsuario.Text;
            string apellido = txtApellidoUsuario.Text;
            string email = txtEmailUsuario.Text;
            string rol = cmbRolUsuario.SelectedItem.ToString();  // Obtener el rol seleccionado
            string contraseña = txtContraseñaUsuario.Text;  // Obtener la contraseña del TextBox

            // Insertar el usuario en la base de datos
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "INSERT INTO Usuario (Nombre, Apellido, Email, Rol, Contraseña) VALUES (@Nombre, @Apellido, @Email, @Rol, @Contraseña)";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Rol", rol);
                        command.Parameters.AddWithValue("@Contraseña", contraseña);  // Usar la contraseña ingresada

                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario creado exitosamente.");

                        // Actualizar el ComboBox de usuarios existentes
                        CargarUsuariosExistentes();

                        // Limpiar todos los campos de texto después de crear el usuario
                        btnLimpiarGestionDeUsuarios_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el usuario: " + ex.Message);
                }
            }
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            if (cmbUsuariosExistentes.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtEmailUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseñaUsuario.Text) ||  // Verificar que se haya ingresado una contraseña
                cmbRolUsuario.SelectedIndex == -1)  // Verificar que se haya seleccionado un rol
            {
                MessageBox.Show("Por favor, complete todos los campos y seleccione un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int usuarioId = (int)cmbUsuariosExistentes.SelectedValue;  // Obtener el ID del usuario seleccionado
            string nombre = txtNombreUsuario.Text;
            string apellido = txtApellidoUsuario.Text;
            string email = txtEmailUsuario.Text;
            string rol = cmbRolUsuario.SelectedItem.ToString();  // Obtener el rol seleccionado
            string contraseña = txtContraseñaUsuario.Text;  // Obtener la contraseña ingresada

            // Actualizar el usuario en la base de datos
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, Email = @Email, Rol = @Rol, Contraseña = @Contraseña WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Apellido", apellido);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Rol", rol);
                        command.Parameters.AddWithValue("@Contraseña", contraseña);  // Actualizar la contraseña
                        command.Parameters.AddWithValue("@Id", usuarioId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario modificado exitosamente.");

                        // Actualizar el ComboBox de usuarios existentes
                        CargarUsuariosExistentes();

                        // Limpiar todos los campos de texto después de modificar el usuario
                        btnLimpiarGestionDeUsuarios_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el usuario: " + ex.Message);
                }
            }
        }


        private void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            if (cmbUsuariosExistentes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int usuarioId = (int)cmbUsuariosExistentes.SelectedValue;  // Obtener el ID del usuario seleccionado

            // Eliminar el usuario de la base de datos
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "DELETE FROM Usuario WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@Id", usuarioId);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Usuario eliminado exitosamente.");

                        // Actualizar el ComboBox de usuarios existentes
                        CargarUsuariosExistentes();

                        // Limpiar todos los campos de texto después de eliminar el usuario
                        btnLimpiarGestionDeUsuarios_Click(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el usuario: " + ex.Message);
                }
            }
        }
        private void cmbRolUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void cmbUsuariosExistentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar que haya un usuario seleccionado
            if (cmbUsuariosExistentes.SelectedIndex == -1)
            {
                return;
            }

            int usuarioId = (int)cmbUsuariosExistentes.SelectedValue; // Obtener el ID del usuario seleccionado

            // Conectar a la base de datos para cargar los datos del usuario
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = "SELECT Nombre, Apellido, Email, Rol, Contraseña FROM Usuario WHERE Id = @Id";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@Id", usuarioId);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Llenar los TextBox con los datos del usuario
                            txtNombreUsuario.Text = reader["Nombre"].ToString();
                            txtApellidoUsuario.Text = reader["Apellido"].ToString();
                            txtEmailUsuario.Text = reader["Email"].ToString();
                            txtContraseñaUsuario.Text = reader["Contraseña"].ToString(); // Cargar la contraseña
                            cmbRolUsuario.SelectedItem = reader["Rol"].ToString(); // Seleccionar el rol en el ComboBox
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message);
                }
            }
        }
        private void btnLimpiarGestionDeUsuarios_Click(object sender, EventArgs e)
        {
            txtNombreUsuario.Clear();
            txtApellidoUsuario.Clear();
            txtEmailUsuario.Clear();
            txtContraseñaUsuario.Clear();  // Limpiar la contraseña también
            cmbRolUsuario.SelectedIndex = -1;  // Limpiar la selección del ComboBox
            cmbUsuariosExistentes.SelectedIndex = -1;  // Limpiar selección de usuarios existentes
        }
        #endregion

    }
}