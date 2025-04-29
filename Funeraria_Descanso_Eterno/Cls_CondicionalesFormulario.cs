using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funeraria_Descanso_Eterno
{
    public class Cls_CondicionalesFormulario
    {
        public static void SoloNumero(KeyPressEventArgs e, Control siguienteControl)
        {
            if (e.KeyChar == 13)
            {
                siguienteControl.Focus(); // Cambia el foco al siguiente campo
                return; // Evita bloquear Enter en la validación de abajo
            }

            // Permitir solo números (0-9) y retroceso
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8)
            {
                // Permitido
            }
            else
            {
                e.KeyChar = '\0'; // Bloquea cualquier otra tecla
            }

            //El metodo se llama de la siguiente manera: "Cls_CondicionalesFormulario.SoloNumero(e, Nombre_TextBox_Siguiente);" 
        }

        public static void SoloLetra(KeyPressEventArgs e, Control siguienteControl)
        {
            if (e.KeyChar == 13)
            {
                siguienteControl.Focus();
                return;
            }
            if (e.KeyChar >= 97 && e.KeyChar <= 122 || e.KeyChar == 8 || e.KeyChar == 32)
            {

            }
            else
            {
                e.KeyChar = '\0';
            }
            //El metodo se llama de la siguiente manera: "Cls_CondicionalesFormulario.SoloLetra(e, Nombre_TextBox_Siguiente);" 

        }
    }
}
