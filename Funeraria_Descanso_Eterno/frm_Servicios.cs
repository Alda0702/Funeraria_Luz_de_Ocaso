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
    public partial class frm_Servicios : Form
    {
        servicios servi = new servicios();

        public void llenarGrid()
        {
            // Llenar el DataGridView con los datos de la base de datos
            servi.mostrardata(dtg_Servicios);
        }

        public frm_Servicios()
        {
            InitializeComponent();
            // Cargar los servicios al iniciar el formulario
                

        }

        private void btn_NuevoS_Click(object sender, EventArgs e)
        {
            frm_NuevoServicio frmNServicio = new frm_NuevoServicio();
            this.Hide();
            frmNServicio.Show();
            this.Show();
        }

        private void frm_Servicios_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void btn_EliminarS_Click(object sender, EventArgs e)
        {
            frm_EliminarServ frm_EliminarServ = new frm_EliminarServ();
            this.Hide();
            frm_EliminarServ.Show();
            this.Show();
        }

        private void frm_Servicios_Activated(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }
}
