using System;
using System.Drawing;
using System.Windows.Forms;

namespace EstudianteProject
{
    internal class TemaClaro
    {
        // Método para aplicar el tema personalizado solo a los Labels y el fondo del formulario
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
                    control.ForeColor = Color.Black;  // Texto negro para mejor legibilidad
                    control.BackColor = Color.Transparent;  // Fondo transparente para los Labels
                }

                // Si el control tiene hijos (como un Panel o GroupBox), aplicar recursivamente el tema
                if (control.HasChildren)
                {
                    AplicarTemaAControles(control);
                }
            }
        }

        // Método auxiliar para aplicar el tema personalizado a los Labels dentro de un contenedor (Panel, GroupBox, etc.)
        private static void AplicarTemaAControles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Aplicar el tema solo a los Labels
                if (control is Label)
                {
                    control.ForeColor = Color.Black;  // Texto negro
                    control.BackColor = Color.Transparent;  // Fondo transparente
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
