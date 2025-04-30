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
    public partial class frm_Inventario : Form
    {
        Inventario inventario = new Inventario();

        public frm_Inventario()
        {
            InitializeComponent();
        }
        public void llenarGrid()
        {
            // Llenar el DataGridView con los datos de la base de datos
            inventario.MostrarInventario(dtg_Inventario);
        }
        private void btn_NuevoI_Click(object sender, EventArgs e)
        {
            frm_NuevoProducto frm_NuevoProducto = new frm_NuevoProducto();
            this.Hide();
            frm_NuevoProducto.ShowDialog();
            this.Show();
        }

        private void btn_EliminarI_Click(object sender, EventArgs e)
        {
            frm_EliminarProd frm_EliminarProd = new frm_EliminarProd();
            this.Hide();
            frm_EliminarProd.ShowDialog();
            this.Show();
        }

        private void frm_Inventario_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void txt_BuscarI_TextChanged(object sender, EventArgs e)
        {
            inventario.BuscarPorCodigo(dtg_Inventario, txt_BuscarI.Text.Trim());
        }
    }
}
