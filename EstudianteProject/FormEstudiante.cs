using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EstudianteProject
{
    public partial class FormEstudiante : Form
    {
        // Constructor principal del FormEstudiante

        #region Constructor FormEstudiante

        private int estudianteId;

        public FormEstudiante(int idEstudiante) // Recibe el ID del estudiante
        {
            InitializeComponent();
            TemaClaro.Aplicar(this);

            // Configuración del ListView para tareas del curso
            lstvwTareasCursoEstudiante.Columns.Add("Título", 150);
            lstvwTareasCursoEstudiante.Columns.Add("Descripción", 200);
            lstvwTareasCursoEstudiante.Columns.Add("Estado", 100);
            lstvwTareasCursoEstudiante.Columns.Add("Calificación", 100);
            lstvwTareasCursoEstudiante.View = View.Details;
            lstvwTareasCursoEstudiante.FullRowSelect = true;

            // Configuración del ListView para anuncios del curso
            lstvwAnunciosCurso.Columns.Add("Título", 150);
            lstvwAnunciosCurso.Columns.Add("Contenido", 300);
            lstvwAnunciosCurso.View = View.Details;
            lstvwAnunciosCurso.FullRowSelect = true;

            estudianteId = idEstudiante;

            // Asignar el evento para cuando se seleccione un curso
            cmbSeleccionarCurso.SelectedIndexChanged += cmbSeleccionarCurso_SelectedIndexChanged;

            // Cargar los cursos asignados al estudiante
            CargarCursosAsignados(estudianteId);

            // Llamar al método para ajustar las columnas al cargar el formulario
            AjustarColumnasListView();

            // Suscribirse al evento Resize del formulario para ajustar las columnas dinámicamente
            this.Resize += (s, e) => AjustarColumnasListView();
        }
        #endregion

        // Métodos utilizados para funcionalidad

        #region AjustarColumnasListView
        private void AjustarColumnasListView()
        {
            // Ajustar el tamaño de las columnas del ListView de tareas
            int anchoDisponibleTareas = lstvwTareasCursoEstudiante.ClientSize.Width;
            lstvwTareasCursoEstudiante.Columns[0].Width = (int)(anchoDisponibleTareas * 0.3); // Título
            lstvwTareasCursoEstudiante.Columns[1].Width = (int)(anchoDisponibleTareas * 0.4); // Descripción
            lstvwTareasCursoEstudiante.Columns[2].Width = (int)(anchoDisponibleTareas * 0.15); // Estado
            lstvwTareasCursoEstudiante.Columns[3].Width = (int)(anchoDisponibleTareas * 0.15); // Calificación

            // Ajustar el tamaño de las columnas del ListView de anuncios
            int anchoDisponibleAnuncios = lstvwAnunciosCurso.ClientSize.Width;
            lstvwAnunciosCurso.Columns[0].Width = (int)(anchoDisponibleAnuncios * 0.3); // Título
            lstvwAnunciosCurso.Columns[1].Width = (int)(anchoDisponibleAnuncios * 0.7); // Contenido
        }

        #endregion

        #region CargarCursosAsignados
        private void CargarCursosAsignados(int estudianteId)
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
                    string query = @"SELECT Curso.NombreCurso 
                                     FROM Curso
                                     JOIN CursoUsuario ON Curso.CursoId = CursoUsuario.CursoId
                                     WHERE CursoUsuario.UsuarioId = @EstudianteId";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@EstudianteId", estudianteId);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable cursos = new DataTable();
                        adapter.Fill(cursos);

                        // Llenar el ComboBox con los cursos asignados
                        cmbSeleccionarCurso.DataSource = cursos;
                        cmbSeleccionarCurso.DisplayMember = "NombreCurso";
                        cmbSeleccionarCurso.ValueMember = "NombreCurso";

                        // Limpiar la selección por defecto
                        cmbSeleccionarCurso.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los cursos: " + ex.Message);
                }
            }
        }
        #endregion

        #region CargarTareasPorNombreCurso
        private void CargarTareasPorNombreCurso(string nombreCurso)
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
                    // Consulta para obtener las tareas del curso seleccionado, junto con su estado y calificación
                    string query = @"SELECT Tarea.NombreTarea, Tarea.DescripcionTarea,
                            (SELECT COUNT(*) 
                             FROM TareaCompletada 
                             WHERE TareaCompletada.TareaId = Tarea.TareaId 
                             AND TareaCompletada.UsuarioId = @EstudianteId) AS EstadoEntrega,
                            (SELECT Calificacion 
                             FROM TareaCompletada 
                             WHERE TareaCompletada.TareaId = Tarea.TareaId 
                             AND TareaCompletada.UsuarioId = @EstudianteId) AS Calificacion
                     FROM Tarea
                     JOIN Curso ON Tarea.CursoId = Curso.CursoId
                     WHERE Curso.NombreCurso = @NombreCurso";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", nombreCurso);
                        command.Parameters.AddWithValue("@EstudianteId", estudianteId);  // Usamos el id del estudiante actual

                        SqlDataReader reader = command.ExecuteReader();

                        // Limpiar la lista antes de cargar
                        lstvwTareasCursoEstudiante.Items.Clear();

                        // Variable para acumular puntos totales
                        decimal puntosTotales = 0;

                        // Cargar las tareas en el ListView
                        while (reader.Read())
                        {
                            string nombreTarea = reader["NombreTarea"].ToString();
                            string descripcionTarea = reader["DescripcionTarea"].ToString();
                            int estadoEntrega = (int)reader["EstadoEntrega"];
                            string estado = estadoEntrega > 0 ? "Entregado" : "Pendiente";

                            // Obtener la calificación, si existe, y sumar a los puntos totales
                            decimal calificacion = 0;
                            if (reader["Calificacion"] != DBNull.Value)
                            {
                                calificacion = Convert.ToDecimal(reader["Calificacion"]);
                                puntosTotales += calificacion;
                            }
                            string calificacionTexto = calificacion > 0 ? calificacion.ToString() : "No Calificado";

                            // Crear una nueva fila para el ListView
                            ListViewItem item = new ListViewItem(nombreTarea);
                            item.SubItems.Add(descripcionTarea);
                            item.SubItems.Add(estado);
                            item.SubItems.Add(calificacionTexto);  // Agregar la calificación a la fila

                            // Agregar la fila al ListView
                            lstvwTareasCursoEstudiante.Items.Add(item);
                        }

                        reader.Close();

                        // Actualizar la label con los puntos totales
                        lblPuntosTotalesCurso.Text = $"Puntos Totales: {puntosTotales}";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las tareas: " + ex.Message);
                }
            }
        }


        #endregion

        #region CargarAnunciosPorNombreCurso
        private void CargarAnunciosPorNombreCurso(string nombreCurso)
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
                    string query = @"SELECT Anuncio.Titulo, Anuncio.Contenido 
                                     FROM Anuncio
                                     JOIN Curso ON Anuncio.CursoId = Curso.CursoId
                                     WHERE Curso.NombreCurso = @NombreCurso";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreCurso", nombreCurso);
                        SqlDataReader reader = command.ExecuteReader();

                        lstvwAnunciosCurso.Items.Clear(); // Limpiar ListView antes de cargar

                        while (reader.Read())
                        {
                            ListViewItem item = new ListViewItem(reader["Titulo"].ToString()); // Agregar el título
                            item.SubItems.Add(reader["Contenido"].ToString()); // Agregar el contenido
                            lstvwAnunciosCurso.Items.Add(item); // Añadir el item al ListView
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los anuncios: " + ex.Message);
                }
            }
        }
        #endregion

        // Interfaz gráfica

        #region Verificar Curso
        private void cmbSeleccionarCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeleccionarCurso.SelectedIndex == -1 || cmbSeleccionarCurso.SelectedItem == null)
            {
                lstvwTareasCursoEstudiante.Items.Clear();
                lstvwAnunciosCurso.Items.Clear();
                return;
            }

            string nombreCurso = cmbSeleccionarCurso.Text;

            CargarTareasPorNombreCurso(nombreCurso);
            CargarAnunciosPorNombreCurso(nombreCurso);
        }

        private void btnEntregarTarea_Click(object sender, EventArgs e)
        {
            if (lstvwTareasCursoEstudiante.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una tarea para entregar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreTarea = lstvwTareasCursoEstudiante.SelectedItems[0].Text; // Obtener el título de la tarea seleccionada

            using (SqlConnection cnx = Conexion.conectar())
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Verificar si la tarea ya fue entregada por el estudiante
                    string checkQuery = @"SELECT COUNT(*) 
                                  FROM TareaCompletada 
                                  WHERE TareaId = (SELECT TareaId FROM Tarea WHERE NombreTarea = @NombreTarea) 
                                  AND UsuarioId = @EstudianteId";

                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, cnx))
                    {
                        checkCommand.Parameters.AddWithValue("@NombreTarea", nombreTarea);
                        checkCommand.Parameters.AddWithValue("@EstudianteId", estudianteId);

                        int count = (int)checkCommand.ExecuteScalar();

                        // Si ya existe una entrega para la tarea, mostrar un mensaje de error
                        if (count > 0)
                        {
                            MessageBox.Show("Ya has entregado esta tarea.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Si no fue entregada, proceder a insertar
                    string query = @"INSERT INTO TareaCompletada (TareaId, UsuarioId, FechaEntrega) 
                             VALUES ((SELECT TareaId FROM Tarea WHERE NombreTarea = @NombreTarea), @EstudianteId, GETDATE())";

                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@NombreTarea", nombreTarea);
                        command.Parameters.AddWithValue("@EstudianteId", estudianteId);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Tarea entregada exitosamente.");
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("Error al entregar la tarea: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}