using AdminProject;
using CatedraticoProject;
using EstudianteProject;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginProject
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            TemaClaro.Aplicar(this);
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtContraseña.Text;

            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingrese su correo y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Conectar a la base de datos y validar credenciales
            using (SqlConnection cnx = Conexion.conectar())  // Usamos el método estático conectar()
            {
                if (cnx == null)
                {
                    MessageBox.Show("No se pudo establecer la conexión con la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    // Consulta para verificar el correo y la contraseña, ahora también obtenemos el ID del usuario
                    string query = "SELECT Id, Rol FROM Usuario WHERE Email = @Email AND Contraseña = @Contraseña";
                    using (SqlCommand command = new SqlCommand(query, cnx))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@Contraseña", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int userId = reader.GetInt32(0);  // Obtenemos el Id del usuario
                                string rol = reader.GetString(1);  // Obtenemos el rol

                                // Verificar el rol del usuario y redirigir
                                switch (rol)
                                {
                                    case "Administrador":
                                        FormAdmin formAdmin = new FormAdmin();  // El admin no necesita ID
                                        formAdmin.Show();
                                        this.Hide();
                                        break;

                                    case "Catedratico":
                                        FormCatedratico formCatedratico = new FormCatedratico(userId);  // Pasa el Id dinámico
                                        formCatedratico.Show();
                                        this.Hide();
                                        break;

                                    case "Estudiante":
                                        FormEstudiante formEstudiante = new FormEstudiante(userId);  // Pasa el Id dinámico
                                        formEstudiante.Show();
                                        this.Hide();
                                        break;

                                    default:
                                        MessageBox.Show("Rol desconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Correo o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar a la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}