using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Negocio;

namespace Presentacion
{
    public partial class FrmGestionPacientes : Form
    {
        public FrmGestionPacientes()
        {
            InitializeComponent();
        }

        private void btnGestiondePropietarios_Click(object sender, EventArgs e)
        {
            FrmGestionPropietarios frmGestionPropietarios = new FrmGestionPropietarios();
            frmGestionPropietarios.ShowDialog();
        }

        private void btnGestiondeMascotas_Click(object sender, EventArgs e)
        {
            FrmGestionMascotas frmGestionMascotas = new FrmGestionMascotas();
            frmGestionMascotas.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
