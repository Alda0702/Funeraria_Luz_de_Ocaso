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
    public partial class frm_EliminarProd : Form
    {
        public frm_EliminarProd()
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

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
             if (lbl_ImprimirCod.Text != "")
    {
        DialogResult confirm = MessageBox.Show("¿Estás seguro de eliminar este producto?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

        if (confirm == DialogResult.Yes)
        {
            Inventario inv = new Inventario();
            bool eliminado = inv.EliminarProductoPorCodigo(lbl_ImprimirCod.Text);

            if (eliminado)
            {
                MessageBox.Show("Producto eliminado correctamente.");
                txt_Buscar.Text = "";
                lbl_ImprimirCod.Text = "";
                lbl_ImprimirNom.Text = "";
            }
            else
            {
                MessageBox.Show("No se pudo eliminar el producto.");
            }
        }
    }
    else
    {
        MessageBox.Show("No hay producto seleccionado.");
    }
        }

        private void txt_Buscar_TextChanged(object sender, EventArgs e)
        {
            Inventario inv = new Inventario();
            string codigo, nombre;

            if (inv.BuscarProducto(txt_Buscar.Text.Trim(), out codigo, out nombre))
            {
                lbl_ImprimirCod.Text = codigo;
                lbl_ImprimirNom.Text = nombre;
            }
            else
            {
                lbl_ImprimirCod.Text = "";
                lbl_ImprimirNom.Text = "";
            }
        }
    }
}
