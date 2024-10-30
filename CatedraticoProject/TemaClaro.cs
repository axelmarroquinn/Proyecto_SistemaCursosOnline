using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CatedraticoProject
{
    internal class TemaClaro
    {
        // Método para aplicar el tema claro al formulario y a todos sus controles
        public static void Aplicar(Form form)
        {
            // Cambiar el fondo del formulario a un color claro (gris suave)
            form.BackColor = ColorTranslator.FromHtml("#f0f4f8");  // Fondo claro

            // Iterar sobre todos los controles del formulario
            foreach (Control control in form.Controls)
            {
                // Cambiar el color de texto y fondo de Labels y GroupBoxes a un tono oscuro para contraste
                if (control is Label || control is GroupBox)
                {
                    control.ForeColor = ColorTranslator.FromHtml("#333333");  // Texto gris oscuro
                    control.BackColor = ColorTranslator.FromHtml("#f0f4f8");  // Fondo claro
                }

                // No modificar los botones, manteniendo el estilo por defecto del sistema
                // Simplemente no hacemos nada para los botones en esta parte del código.

                // Si el control tiene hijos (como un Panel o GroupBox), aplicar recursivamente el tema
                if (control.HasChildren)
                {
                    AplicarTemaAControles(control);
                }
            }
        }

        // Método auxiliar para aplicar el tema personalizado a los Labels, GroupBox y otros dentro de un contenedor (Panel, GroupBox, etc.)
        private static void AplicarTemaAControles(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                // Aplicar el tema a Labels y GroupBox
                if (control is Label || control is GroupBox)
                {
                    control.ForeColor = ColorTranslator.FromHtml("#333333");  // Texto gris oscuro
                    control.BackColor = ColorTranslator.FromHtml("#f0f4f8");  // Fondo claro
                }

                // No modificar los botones, dejando el color por defecto

                // Aplicar recursivamente a controles dentro de contenedores
                if (control.HasChildren)
                {
                    AplicarTemaAControles(control);
                }
            }
        }
    }
}