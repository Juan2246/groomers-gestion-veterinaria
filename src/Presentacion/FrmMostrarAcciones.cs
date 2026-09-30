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
    public partial class FrmMostrarAcciones : Form
    {
        private NLogsAcciones nLogsAcciones = new NLogsAcciones();
        public FrmMostrarAcciones()
        {
            InitializeComponent();
        }

        private void frmMostrarAcciones_Load(object sender, EventArgs e)
        {
            dgvLogs.DataSource = null;
            dgvLogs.DataSource = nLogsAcciones.ObtenerLogs()
                .Select(l => new
                {
                    Usuario = l.Usuario,
                    Acción = l.Accion,
                    Fecha = l.FechaHora.ToString()
                })
                .ToList();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
