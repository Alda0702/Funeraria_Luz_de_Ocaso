using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funeraria_Descanso_Eterno
{
    public partial class frm_Proveedores : Form
    {
        public frm_Proveedores()
        {
            InitializeComponent();
        }

        private void btn_NuevoProv_Click(object sender, EventArgs e)
        {
            frm_NuevoProveedor frm_NuevoProv = new frm_NuevoProveedor();
            this.Hide();
            frm_NuevoProv.ShowDialog();
            this.Show();
        }

        private void btn_EliminarProv_Click(object sender, EventArgs e)
        {
            frm_EliminarProveedor frm_EliminarProv = new frm_EliminarProveedor();
            this.Hide();
            frm_EliminarProv.ShowDialog();
            this.Show();
        }
    }
}
