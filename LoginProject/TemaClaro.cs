using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginProject
{
    internal class TemaClaro
    {
        // Método para aplicar el tema personalizado al formulario y a todos sus controles
        public static void Aplicar(Form form)
        {
            // Cambiar el fondo del formulario a un gris claro
            form.BackColor = ColorTranslator.FromHtml("#ecf0f1");  // Fondo gris claro

            // Iterar sobre todos los controles del formulario
            foreach (Control control in form.Controls)
            {
                // Cambiar el color de texto solo de los Labels
                if (control is Label)
                {
                    control.ForeColor = Color.Black;  // Texto negro
                    control.BackColor = Color.Transparent;  // Fondo transparente
                }

                // Cambiar el color de texto y fondo de los TextBoxes y ComboBoxes
                if (control is TextBox || control is ComboBox)
                {
                    control.ForeColor = Color.Black;  // Texto negro
                    control.BackColor = Color.White;  // Fondo blanco para los campos de entrada
                }

                // Si el control tiene hijos (como un Panel o GroupBox), aplicar recursivamente el tema
                if (control.HasChildren)
                {
                    AplicarTemaAControles(control);
                }
            }
        }

        // Método auxiliar para aplicar el tema a los controles dentro de un contenedor (Panel, GroupBox, etc.)
        private static void AplicarTemaAControles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Aplicar el tema a Labels
                if (control is Label)
                {
                    control.ForeColor = Color.Black;  // Texto negro
                    control.BackColor = Color.Transparent;  // Fondo transparente
                }
                // Aplicar el tema a TextBox y ComboBox
                else if (control is TextBox || control is ComboBox)
                {
                    control.ForeColor = Color.Black;  // Texto negro
                    control.BackColor = Color.White;  // Fondo blanco
                }

                // Aplicar recursivamente a controles dentro de contenedores
                if (control.HasChildren)
                {
                    AplicarTemaAControles(control);
                }
            }
        }
    }
}
