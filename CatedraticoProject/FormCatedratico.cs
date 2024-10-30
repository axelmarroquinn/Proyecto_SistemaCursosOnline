using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CatedraticoProject
{
    public partial class FormCatedratico : Form
    {
        // Constructor Principal del FormCatedratico

        #region Constructor FormCatedratico
        private int catedraticoId;
        private bool isInitializing = true; // Controla si estamos inicializando el formulario.

        public FormCatedratico(int idCatedratico)  // Recibe el ID del catedrático
        {
            InitializeComponent();
            TemaClaro.Aplicar(this);
            catedraticoId = idCatedratico;  // Almacenar el ID recibido

            // Asignar los eventos correspondientes
            cmbSeleccionarCurso.SelectedIndexChanged += cmbSeleccionarCurso_SelectedIndexChanged;
            cmbAnunciosExistentes.SelectedIndexChanged += cmbAnunciosExistentes_SelectedIndexChanged;

            // Cargar los cursos asignados al catedrático
            CargarCursosAsignados(catedraticoId);
        }
        #endregion

        // Métodos utilizados para funcionalidad

        #region MostrarPuntosEstudianteSeleccionado
        private void MostrarPuntosEstudianteSeleccionado(string estudianteNombre, string nombreCurso)
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
                    // Consulta SQL para obtener la suma total de puntos para el estudiante seleccionado usando su nombre completo
                    string query = @"SELECT SUM(TareaCompletada.Calificacion) AS TotalPuntos
                             FROM TareaCompletada
                             JOIN Usuario ON Usuario.Id = TareaCompletada.UsuarioId
                             JOIN Tarea ON Tarea.TareaId = TareaCompletada.TareaId
                             JOIN Curso ON Tarea.CursoId = Curso.CursoId
                             WHERE Usuario.Nombre + ' ' + Usuario.Apellido = @EstudianteNombre
                             AND Curso.NombreCurso = @NombreCurso";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@EstudianteNombre", estudianteNombre);
                        command.Parameters.AddWithValue("@NombreCurso", nombreCurso);
                        object resultado = command.ExecuteScalar();

                        // Si no hay calificaciones, mostrar 0 puntos
                        decimal puntosTotales = resultado != DBNull.Value ? Convert.ToDecimal(resultado) : 0;

                        // Actualizar el Label con los puntos totales
                        lblPuntosEstudianteSeleccionado.Text = $"Puntos acumulados: {puntosTotales}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los puntos del estudiante: " + ex.Message);
                }
            }
        }


        #endregion

        #region CargarCursosAsignados
        private void CargarCursosAsignados(int catedraticoId)
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
                    // Consulta SQL para obtener los cursos asignados al catedrático
                    string query = @"SELECT Curso.NombreCurso 
                             FROM Curso 
                             JOIN CursoUsuario ON Curso.CursoId = CursoUsuario.CursoId
                             WHERE CursoUsuario.UsuarioId = @CatedraticoId";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@CatedraticoId", catedraticoId);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable cursos = new DataTable();
                        adapter.Fill(cursos);

                        // Llenar el ComboBox con los cursos asignados
                        cmbSeleccionarCurso.DataSource = cursos;
                        cmbSeleccionarCurso.DisplayMember = "NombreCurso";
                        cmbSeleccionarCurso.ValueMember = "NombreCurso";  // Ahora usamos NombreCurso

                        // Limpiar la selección por defecto
                        cmbSeleccionarCurso.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los cursos: " + ex.Message);
                }
            }

            // Finaliza la inicialización
            isInitializing = false;
        }
        #endregion

        #region CargarEstudiantesPorNombreCurso
        private void CargarEstudiantesPorNombreCurso(string nombreCurso)
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
                    // Consulta SQL para obtener estudiantes asignados al curso usando el nombre del curso
                    string query = @"SELECT Usuario.Nombre + ' ' + Usuario.Apellido AS NombreCompleto 
                             FROM Usuario 
                             JOIN CursoUsuario ON Usuario.Id = CursoUsuario.UsuarioId 
                             JOIN Curso ON Curso.CursoId = CursoUsuario.CursoId
                             WHERE Curso.NombreCurso = @NombreCurso AND Usuario.Rol = 'Estudiante'";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", nombreCurso);
                        SqlDataReader reader = command.ExecuteReader();

                        // Limpiar la lista antes de cargar
                        lstEstudiantes.Items.Clear();

                        // Cargar cada estudiante en la lista
                        while (reader.Read())
                        {
                            lstEstudiantes.Items.Add(reader["NombreCompleto"].ToString());
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los estudiantes: " + ex.Message);
                }
            }
        }
        #endregion

        #region CargarTareasPorNombreCurso
        private void CargarTareasPorNombreCurso(string nombreCurso)
        {
            if (string.IsNullOrEmpty(nombreCurso))
            {
                // No hacer nada si no se ha seleccionado un curso
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
                    // Consulta SQL para obtener tareas del curso usando el nombre del curso
                    string query = @"SELECT Tarea.TareaId, Tarea.NombreTarea 
                             FROM Tarea
                             JOIN Curso ON Tarea.CursoId = Curso.CursoId
                             WHERE Curso.NombreCurso = @NombreCurso";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", nombreCurso);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable tareas = new DataTable();
                        adapter.Fill(tareas);

                        // Verificar si hay tareas para el curso, y solo mostrar el mensaje si no estamos inicializando
                        if (tareas.Rows.Count == 0 && !isInitializing)
                        {
                            MessageBox.Show("No hay tareas para este curso.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        // Llenar el ComboBox con las tareas del curso
                        cmbTareasExistentes.DataSource = tareas;
                        cmbTareasExistentes.DisplayMember = "NombreTarea";
                        cmbTareasExistentes.ValueMember = "TareaId";

                        // Limpiar la selección por defecto
                        cmbTareasExistentes.SelectedIndex = -1;
                    }
                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show("Error de conversión al cargar las tareas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las tareas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region CargarTareaSeleccionada
        private void CargarTareaSeleccionada(int tareaId)
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
                    // Consulta SQL para obtener los detalles de la tarea seleccionada
                    string query = @"SELECT NombreTarea, DescripcionTarea, FechaLimite 
                             FROM Tarea 
                             WHERE TareaId = @TareaId";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@TareaId", tareaId);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Llenar los campos con los datos de la tarea seleccionada
                            txtNombreTarea.Text = reader["NombreTarea"].ToString();
                            txtDescripcionTarea.Text = reader["DescripcionTarea"].ToString();
                            dateFechaLimite.Value = Convert.ToDateTime(reader["FechaLimite"]);
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los detalles de la tarea: " + ex.Message);
                }
            }
        }
        #endregion

        #region CargarTareasEntregadasPorNombreCurso
        private void CargarTareasEntregadasPorNombreCurso(string nombreCurso)
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
                    // Consulta SQL para obtener las tareas entregadas por los estudiantes
                    string query = @"SELECT Usuario.Nombre + ' ' + Usuario.Apellido AS NombreCompleto, 
                                    Tarea.NombreTarea, 
                                    TareaCompletada.Calificacion
                             FROM TareaCompletada
                             JOIN Usuario ON Usuario.Id = TareaCompletada.UsuarioId
                             JOIN Tarea ON Tarea.TareaId = TareaCompletada.TareaId
                             JOIN Curso ON Tarea.CursoId = Curso.CursoId
                             WHERE Curso.NombreCurso = @NombreCurso";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", nombreCurso);
                        SqlDataReader reader = command.ExecuteReader();

                        // Limpiar la lista antes de cargar
                        lstTareasEntregadas.Items.Clear();

                        // Cargar cada tarea entregada en la lista
                        while (reader.Read())
                        {
                            string estudiante = reader["NombreCompleto"].ToString();
                            string tarea = reader["NombreTarea"].ToString();

                            // Manejar el posible valor NULL de la calificación
                            string calificacion;
                            if (reader["Calificacion"] != DBNull.Value)
                            {
                                calificacion = reader["Calificacion"].ToString();
                            }
                            else
                            {
                                calificacion = "Sin Calificar";
                            }

                            lstTareasEntregadas.Items.Add($"{estudiante} - {tarea} (Calificación: {calificacion})");
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las tareas entregadas: " + ex.Message);
                }
            }
        }
        #endregion

        #region CargarTareasEntregadas
        private void CargarTareasEntregadas(string nombreCurso)
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
                    string query = @"SELECT Usuario.Nombre + ' ' + Usuario.Apellido AS NombreCompleto, 
                                    Tarea.NombreTarea, 
                                    TareaCompletada.Calificacion
                             FROM TareaCompletada
                             JOIN Usuario ON Usuario.Id = TareaCompletada.UsuarioId
                             JOIN Tarea ON Tarea.TareaId = TareaCompletada.TareaId
                             JOIN Curso ON Tarea.CursoId = Curso.CursoId
                             WHERE Curso.NombreCurso = @NombreCurso";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", nombreCurso);
                        SqlDataReader reader = command.ExecuteReader();

                        // Limpiar la lista antes de cargar
                        lstTareasEntregadas.Items.Clear();

                        // Cargar cada tarea entregada en la lista
                        while (reader.Read())
                        {
                            string estudiante = reader["NombreCompleto"].ToString();
                            string tarea = reader["NombreTarea"].ToString();
                            string calificacion = reader["Calificacion"] != DBNull.Value ? reader["Calificacion"].ToString() : "Sin Calificar";

                            lstTareasEntregadas.Items.Add($"{estudiante} - {tarea} (Calificación: {calificacion})");
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las tareas entregadas: " + ex.Message);
                }
            }
        }

        #endregion

        #region CargarAnunciosPorCurso
        public void CargarAnunciosPorCurso(string nombreCurso)
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
                    string query = @"SELECT AnuncioId, Titulo 
                             FROM Anuncio
                             JOIN Curso ON Anuncio.CursoId = Curso.CursoId
                             WHERE Curso.NombreCurso = @NombreCurso";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", nombreCurso);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable anuncios = new DataTable();
                        adapter.Fill(anuncios);

                        // Llenar el ComboBox con los anuncios del curso
                        cmbAnunciosExistentes.DataSource = anuncios;
                        cmbAnunciosExistentes.DisplayMember = "Titulo"; // Muestra el título del anuncio
                        cmbAnunciosExistentes.ValueMember = "AnuncioId"; // AnuncioId para referencia

                        // Limpiar la selección por defecto
                        cmbAnunciosExistentes.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los anuncios: " + ex.Message);
                }
            }
        }

        #endregion

        #region ObtenerUsuarioId
        private int obtenerUsuarioId(string nombreCompleto)
        {
            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;  // Valor de error si no se encuentra conexión
                }

                try
                {
                    // Consulta SQL para obtener el UsuarioId basado en el nombre completo
                    string query = @"SELECT Id 
                             FROM Usuario
                             WHERE Nombre + ' ' + Apellido = @NombreCompleto";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);

                        object resultado = command.ExecuteScalar();

                        if (resultado != null && resultado != DBNull.Value)
                        {
                            return Convert.ToInt32(resultado);  // Retorna el UsuarioId
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el estudiante.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;  // Valor de error si no se encuentra el estudiante
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener el ID del estudiante: " + ex.Message);
                    return -1;  // Valor de error en caso de excepción
                }
            }
        }
        #endregion

        // Interfaz gráfica

        #region CursosAsignados
        private void cmbSeleccionarCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Validar que se haya seleccionado un curso y que no esté en un estado inicial sin selección
            if (cmbSeleccionarCurso.SelectedIndex == -1 || cmbSeleccionarCurso.SelectedItem == null)
            {
                // Limpiar la lista de estudiantes y tareas si no hay curso seleccionado
                lstEstudiantes.Items.Clear();
                cmbTareasExistentes.DataSource = null;
                lstTareasEntregadas.Items.Clear(); // También limpiar la lista de tareas entregadas

                // Limpiar los anuncios existentes
                cmbAnunciosExistentes.DataSource = null;
                LimpiarGestionAnuncios();
                return;
            }

            // Obtener el nombre del curso seleccionado
            string nombreCurso = cmbSeleccionarCurso.Text;

            // Usa el nombre del curso para realizar las consultas
            CargarEstudiantesPorNombreCurso(nombreCurso);
            CargarTareasPorNombreCurso(nombreCurso);
            CargarTareasEntregadasPorNombreCurso(nombreCurso);

            // Cargar los anuncios del curso
            CargarAnunciosPorCurso(nombreCurso);
        }

        private void lstEstudiantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEstudiantes.SelectedIndex == -1)
            {
                lblPuntosEstudianteSeleccionado.Text = "Puntos acumulados: 0";  // Limpiar el Label cuando no se selecciona un estudiante
                return;
            }

            // Obtener el nombre del estudiante seleccionado
            string estudianteSeleccionado = lstEstudiantes.SelectedItem.ToString().Trim();

            // Obtener el nombre del curso seleccionado
            string nombreCurso = cmbSeleccionarCurso.Text;

            // Mostrar los puntos acumulados del estudiante seleccionado
            MostrarPuntosEstudianteSeleccionado(estudianteSeleccionado, nombreCurso);
        }



        #endregion

        #region GestionDeTareas

        private void btnCrearTarea_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreTarea.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcionTarea.Text) ||
                dateFechaLimite.Value == null)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreCurso = cmbSeleccionarCurso.Text;  // Usar nombre del curso en vez de cursoId
            string nombreTarea = txtNombreTarea.Text;
            string descripcionTarea = txtDescripcionTarea.Text;
            DateTime fechaLimite = dateFechaLimite.Value;

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Insertar la nueva tarea en la base de datos
                    string query = @"INSERT INTO Tarea (CursoId, NombreTarea, DescripcionTarea, FechaLimite) 
                                     VALUES ((SELECT CursoId FROM Curso WHERE NombreCurso = @NombreCurso), @NombreTarea, @DescripcionTarea, @FechaLimite)";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", nombreCurso);
                        command.Parameters.AddWithValue("@NombreTarea", nombreTarea);
                        command.Parameters.AddWithValue("@DescripcionTarea", descripcionTarea);
                        command.Parameters.AddWithValue("@FechaLimite", fechaLimite);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Tarea creada exitosamente.");

                        // Actualizar el ComboBox de tareas
                        CargarTareasPorNombreCurso(nombreCurso);

                        LimpiarGestionTareas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear la tarea: " + ex.Message);
                }
            }
        }

        private void btnModificarTarea_Click(object sender, EventArgs e)
        {
            if (cmbTareasExistentes.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtNombreTarea.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcionTarea.Text) ||
                dateFechaLimite.Value == null)
            {
                MessageBox.Show("Por favor, seleccione una tarea y complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tareaId = (int)cmbTareasExistentes.SelectedValue;
            string nombreTarea = txtNombreTarea.Text;
            string descripcionTarea = txtDescripcionTarea.Text;
            DateTime fechaLimite = dateFechaLimite.Value;

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Modificar la tarea en la base de datos
                    string query = @"UPDATE Tarea 
                             SET NombreTarea = @NombreTarea, DescripcionTarea = @DescripcionTarea, FechaLimite = @FechaLimite 
                             WHERE TareaId = @TareaId";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreTarea", nombreTarea);
                        command.Parameters.AddWithValue("@DescripcionTarea", descripcionTarea);
                        command.Parameters.AddWithValue("@FechaLimite", fechaLimite);
                        command.Parameters.AddWithValue("@TareaId", tareaId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Tarea modificada exitosamente.");

                        // Actualizar el ComboBox de tareas
                        CargarTareasPorNombreCurso(cmbSeleccionarCurso.Text);
                        LimpiarGestionTareas();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar la tarea: " + ex.Message);
                }
            }
        }

        private void btnEliminarTarea_Click(object sender, EventArgs e)
        {
            if (cmbTareasExistentes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una tarea para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tareaId = (int)cmbTareasExistentes.SelectedValue;

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Eliminar la tarea de la base de datos
                    string query = @"DELETE FROM Tarea WHERE TareaId = @TareaId";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@TareaId", tareaId);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Tarea eliminada exitosamente.");

                        // Actualizar el ComboBox de tareas
                        CargarTareasPorNombreCurso(cmbSeleccionarCurso.Text);

                        // Limpiar los campos después de eliminar la tarea
                        LimpiarGestionTareas();

                        // Limpiar la selección del ComboBox de tareas
                        cmbTareasExistentes.SelectedIndex = -1;
                        cmbTareasExistentes.Text = string.Empty; // Limpiar el texto visible en el ComboBox
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar la tarea: " + ex.Message);
                }
            }
        }

        private void LimpiarGestionTareas()
        {
            txtNombreTarea.Clear();
            txtDescripcionTarea.Clear();
            dateFechaLimite.Value = DateTime.Now;
            cmbTareasExistentes.SelectedIndex = -1;
        }

        private void cmbTareasExistentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTareasExistentes.SelectedIndex == -1)
            {
                LimpiarGestionTareas();
                return;
            }

            // Obtener el ID de la tarea seleccionada y cargar los detalles
            int tareaId = (int)cmbTareasExistentes.SelectedValue;
            CargarTareaSeleccionada(tareaId);
        }
        #endregion

        #region TareasEntregadas
        private void lstTareasEntregadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTareasEntregadas.SelectedIndex == -1)
            {
                return;
            }

            string[] detallesTarea = lstTareasEntregadas.SelectedItem.ToString().Split('-');
            string estudianteNombre = detallesTarea[0].Trim();
            string nombreTarea = detallesTarea[1].Trim().Split('(')[0].Trim(); // Extrae el nombre de la tarea

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = @"SELECT TareaCompletada.Calificacion
                             FROM TareaCompletada
                             JOIN Usuario ON Usuario.Id = TareaCompletada.UsuarioId
                             JOIN Tarea ON Tarea.TareaId = TareaCompletada.TareaId
                             WHERE Usuario.Nombre + ' ' + Usuario.Apellido = @EstudianteNombre
                             AND Tarea.NombreTarea = @NombreTarea";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@EstudianteNombre", estudianteNombre);
                        command.Parameters.AddWithValue("@NombreTarea", nombreTarea);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            // Cargar la calificación si existe, o dejar vacío si no tiene calificación
                            if (reader["Calificacion"] != DBNull.Value)
                            {
                                txtCalificacionTarea.Text = reader["Calificacion"].ToString();
                            }
                            else
                            {
                                txtCalificacionTarea.Clear(); // Si no hay calificación, limpiar el campo
                            }
                        }
                        else
                        {
                            txtCalificacionTarea.Clear(); // Si no encuentra la tarea, limpiar el campo
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la calificación: " + ex.Message);
                }
            }
        }



        private void btnAsignarCalificacionTarea_Click(object sender, EventArgs e)
        {
            if (lstTareasEntregadas.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una tarea entregada para calificar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] detallesTarea = lstTareasEntregadas.SelectedItem.ToString().Split('-');
            string estudianteNombre = detallesTarea[0].Trim();
            string nombreTarea = detallesTarea[1].Trim().Split('(')[0].Trim(); // Extrae el nombre de la tarea

            if (!decimal.TryParse(txtCalificacionTarea.Text, out decimal calificacion) || calificacion < 0 || calificacion > 100)
            {
                MessageBox.Show("Por favor, ingrese una calificación válida entre 0 y 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = @"UPDATE TareaCompletada
                             SET Calificacion = @Calificacion
                             WHERE UsuarioId = (SELECT Id FROM Usuario WHERE Nombre + ' ' + Apellido = @EstudianteNombre)
                             AND TareaId = (SELECT TareaId FROM Tarea WHERE NombreTarea = @NombreTarea)";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@Calificacion", calificacion);
                        command.Parameters.AddWithValue("@EstudianteNombre", estudianteNombre);
                        command.Parameters.AddWithValue("@NombreTarea", nombreTarea);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Calificación asignada exitosamente.");
                            CargarTareasEntregadas(cmbSeleccionarCurso.Text); // Recargar la lista de tareas entregadas

                            // Limpiar el campo de calificación después de asignarla
                            txtCalificacionTarea.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar la tarea o estudiante seleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al asignar la calificación: " + ex.Message);
                }
            }
        }


        private void txtCalificacionTarea_TextChanged(object sender, EventArgs e)
        {
            if (isCalificacionModificada)
            {
                // Resetear la variable de control después de limpiar el TextBox
                isCalificacionModificada = false;
                return;
            }

            // Aquí podrías agregar lógica adicional si es necesario cuando se cambia la calificación
        }


        private bool isCalificacionModificada = false; // Variable para controlar la limpieza

        private void btnModificarCalificacion_Click(object sender, EventArgs e)
        {
            if (lstTareasEntregadas.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione una tarea entregada para modificar la calificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] detallesTarea = lstTareasEntregadas.SelectedItem.ToString().Split('-');
            string estudianteNombre = detallesTarea[0].Trim();
            string nombreTarea = detallesTarea[1].Trim().Split('(')[0].Trim(); // Extrae el nombre de la tarea

            if (!decimal.TryParse(txtCalificacionTarea.Text, out decimal calificacion) || calificacion < 0 || calificacion > 100)
            {
                MessageBox.Show("Por favor, ingrese una calificación válida entre 0 y 100.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    string query = @"UPDATE TareaCompletada
                             SET Calificacion = @Calificacion
                             WHERE UsuarioId = (SELECT Id FROM Usuario WHERE Nombre + ' ' + Apellido = @EstudianteNombre)
                             AND TareaId = (SELECT TareaId FROM Tarea WHERE NombreTarea = @NombreTarea)";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@Calificacion", calificacion);
                        command.Parameters.AddWithValue("@EstudianteNombre", estudianteNombre);
                        command.Parameters.AddWithValue("@NombreTarea", nombreTarea);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Calificación modificada exitosamente.");
                            CargarTareasEntregadas(cmbSeleccionarCurso.Text); // Recargar la lista de tareas entregadas

                            // Limpiar el campo de calificación después de modificarla
                            isCalificacionModificada = true;  // Establecer el indicador para evitar la validación
                            txtCalificacionTarea.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo encontrar la tarea o estudiante seleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar la calificación: " + ex.Message);
                }
            }
        }
        #endregion

        #region GestionDeAnuncios
        private void btnCrearAnuncio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTituloAnuncio.Text) || string.IsNullOrWhiteSpace(txtContenidoAnuncio.Text))
            {
                MessageBox.Show("Por favor, complete el título y contenido del anuncio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string titulo = txtTituloAnuncio.Text;
            string contenido = txtContenidoAnuncio.Text;
            string cursoNombre = cmbSeleccionarCurso.Text;  // Usar el nombre del curso seleccionado

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Insertar el anuncio en la tabla
                    string query = @"INSERT INTO Anuncio (CursoId, Titulo, Contenido) 
                             VALUES ((SELECT CursoId FROM Curso WHERE NombreCurso = @NombreCurso), @Titulo, @Contenido)";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", cursoNombre);
                        command.Parameters.AddWithValue("@Titulo", titulo);
                        command.Parameters.AddWithValue("@Contenido", contenido);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Anuncio creado exitosamente.");
                        CargarAnunciosPorCurso(cursoNombre);  // Actualiza el ComboBox de anuncios
                        LimpiarGestionAnuncios();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el anuncio: " + ex.Message);
                }
            }
        }

        private void btnModificarAnuncio_Click(object sender, EventArgs e)
        {
            if (cmbAnunciosExistentes.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtTituloAnuncio.Text) || string.IsNullOrWhiteSpace(txtContenidoAnuncio.Text))
            {
                MessageBox.Show("Por favor, seleccione un anuncio y complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int anuncioId = (int)cmbAnunciosExistentes.SelectedValue;
            string titulo = txtTituloAnuncio.Text;
            string contenido = txtContenidoAnuncio.Text;
            string cursoNombre = cmbSeleccionarCurso.Text;  // Usar el nombre del curso seleccionado

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = @"UPDATE Anuncio 
                             SET Titulo = @Titulo, Contenido = @Contenido 
                             WHERE AnuncioId = @AnuncioId";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@Titulo", titulo);
                        command.Parameters.AddWithValue("@Contenido", contenido);
                        command.Parameters.AddWithValue("@AnuncioId", anuncioId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Anuncio modificado exitosamente.");
                        CargarAnunciosPorCurso(cursoNombre);  // Actualiza el ComboBox de anuncios
                        LimpiarGestionAnuncios();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el anuncio: " + ex.Message);
                }
            }
        }

        private void btnEliminarAnuncio_Click(object sender, EventArgs e)
        {
            if (cmbAnunciosExistentes.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un anuncio para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int anuncioId = (int)cmbAnunciosExistentes.SelectedValue;
            string cursoNombre = cmbSeleccionarCurso.Text;  // Usar el nombre del curso seleccionado

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = @"DELETE FROM Anuncio WHERE AnuncioId = @AnuncioId";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@AnuncioId", anuncioId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Anuncio eliminado exitosamente.");
                        CargarAnunciosPorCurso(cursoNombre);  // Actualiza el ComboBox de anuncios
                        LimpiarGestionAnuncios();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el anuncio: " + ex.Message);
                }
            }
        }

        private void LimpiarGestionAnuncios()
        {
            txtTituloAnuncio.Clear();
            txtContenidoAnuncio.Clear();
            cmbAnunciosExistentes.SelectedIndex = -1;
        }

        private void cmbAnunciosExistentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAnunciosExistentes.SelectedIndex == -1)
            {
                LimpiarGestionAnuncios();
                return;
            }

            int anuncioId = (int)cmbAnunciosExistentes.SelectedValue; // Obtener el ID del anuncio seleccionado

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    string query = @"SELECT Titulo, Contenido
                             FROM Anuncio
                             WHERE AnuncioId = @AnuncioId";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@AnuncioId", anuncioId);
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Cargar el título y contenido del anuncio en los controles
                            txtTituloAnuncio.Text = reader["Titulo"].ToString();
                            txtContenidoAnuncio.Text = reader["Contenido"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el anuncio: " + ex.Message);
                }
            }
        }
        #endregion
    }
}