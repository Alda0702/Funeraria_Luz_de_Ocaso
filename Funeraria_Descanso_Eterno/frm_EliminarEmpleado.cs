using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funeraria_Descanso_Eterno
{
    public partial class frm_EliminarEmpleado : Form
    {
        public frm_EliminarEmpleado()
        {
            InitializeComponent();
        }

        private void pic_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pic_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbl_ImprimirDoc_Click(object sender, EventArgs e)
        {

        }

        private void pnl_EliminarE_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            EmpleadoDB EMPL = new EmpleadoDB();
            string codigo, nombre;


            if (EMPL.BuscarProducto(txt_Buscar.Text.Trim(), out codigo, out nombre))
            {
                lbl_ImprimirDoc.Text = codigo;
                lbl_ImprimirNom.Text = nombre;
            }
            else
            {
                lbl_ImprimirDoc.Text = "";
                lbl_ImprimirNom.Text = "";
            }
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (lbl_ImprimirDoc.Text != "")
            {
                DialogResult confirm = MessageBox.Show("¿Estás seguro de eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    EmpleadoDB Emp = new EmpleadoDB();
                    bool eliminado = Emp.EliminarEmplPorCodigo(lbl_ImprimirNom.Text);

                    if (eliminado)
                    {
                        MessageBox.Show("Producto eliminado correctamente.");
                        txt_Buscar.Text = "";
                        lbl_ImprimirDoc.Text = "";
                        lbl_ImprimirNom.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el producto.");
                    }
                }

            }
        }
    }
}
