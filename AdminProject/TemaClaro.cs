using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdminProject
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

                // Cambiar el color de texto de los GroupBoxes
                if (control is GroupBox)
                {
                    control.ForeColor = Color.Black;  // Texto negro para los títulos de los GroupBoxes
                    control.BackColor = Color.Transparent;  // Fondo transparente para los GroupBoxes
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
                // Aplicar el tema solo a los Labels y GroupBoxes
                if (control is Label)
                {
                    control.ForeColor = Color.Black;  // Texto negro
                    control.BackColor = Color.Transparent;  // Fondo transparente
                }
                else if (control is GroupBox)
                {
                    control.ForeColor = Color.Black;  // Texto negro para los títulos de los GroupBoxes
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
