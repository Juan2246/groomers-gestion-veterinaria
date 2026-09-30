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
    public partial class FrmLogin : Form
    {
        private NUsuario nUsuario = new NUsuario();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnRegistarNuevoUsuario_Click(object sender, EventArgs e)
        {
            FrmRegistrarNuevoUsuario frmRegistrar = new FrmRegistrarNuevoUsuario();
            frmRegistrar.ShowDialog();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsuario.Text) && !string.IsNullOrEmpty(txtContra.Text))
            {
                string usuarioID = txtUsuario.Text.Trim();
                string contra = txtContra.Text;

                if (nUsuario.ValidarUsuario(usuarioID, contra))
                {
                    FrmMenu menu = new FrmMenu();
                    this.Hide(); 
                    menu.ShowDialog();
                    DUsuario.UsuarioActivo = null;
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtUsuario.Clear();
            txtContra.Clear();
            txtUsuario.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
