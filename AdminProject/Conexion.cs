using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AdminProject
{
    public class Conexion
    {
        public SqlConnection cnx;

        public Conexion()
        {
            try
            {
                cnx = new SqlConnection("Data Source=amcomputer\\SQLEXPRESS;Initial Catalog=SistemaCursosOnline;User ID=sa;Password=1234");
                cnx.Open();
                MessageBox.Show("Conexión exitosa.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Método estático para facilitar la conexión
        public static SqlConnection conectar()
        {
            try
            {
                SqlConnection cnx = new SqlConnection("Data Source=amcomputer\\SQLEXPRESS;Initial Catalog=SistemaCursosOnline;User ID=sa;Password=1234");
                cnx.Open();
                return cnx;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }
        }
    }
}