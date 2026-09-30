using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            FrmGestionPacientes frmGestionPacientes = new FrmGestionPacientes();
            frmGestionPacientes.ShowDialog();
        }

        private void btnVeterinarios_Click(object sender, EventArgs e)
        {
            FrmGestionVeterinarios frmGestionVeterinarios = new FrmGestionVeterinarios();
            frmGestionVeterinarios.ShowDialog();
        }

        private void btnMedicamentos_Click(object sender, EventArgs e)
        {
            FrmGestionMedicamentos frmGestionMedicamentos = new FrmGestionMedicamentos();
            frmGestionMedicamentos.ShowDialog();
        }

        private void btnCitas_Click(object sender, EventArgs e)
        {
            FrmGestionCitas frmGestionCitas = new FrmGestionCitas();
            frmGestionCitas.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmReportes frmReportes = new FrmReportes();
            frmReportes.ShowDialog();
        }

        private void btnMostrarAcciones_Click(object sender, EventArgs e)
        {
            FrmMostrarAcciones frmMostrarAcciones = new FrmMostrarAcciones();
            frmMostrarAcciones.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
