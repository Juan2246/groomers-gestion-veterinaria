using Negocio;
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
using Microsoft.VisualBasic;

namespace Presentacion
{
    public partial class FrmRegistrarNuevoUsuario : Form
    {
        private NUsuario nUsuario = new NUsuario();

        public FrmRegistrarNuevoUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "" && txtContra.Text != "" && txtRepetirContra.Text != "")
            {
                if (txtContra.Text != txtRepetirContra.Text)
                {
                    MessageBox.Show("Las contraseñas deben ser iguales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtContra.Text.Length < 12 || txtContra.Text.Length > 128 || txtUsuario.Text.Trim().Length > 50 || string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    MessageBox.Show("Use un usuario de hasta 50 caracteres y una contraseña de 12 a 128 caracteres.");
                    return;
                }

                string claveAdmin = Interaction.InputBox("Ingrese la clave del usuario administrador para continuar", "Clave de administrador", "");

                if (!nUsuario.ValidarContraAdmin(claveAdmin))
                {
                    MessageBox.Show("La contraseña es incorrecta. No se puede registrar un nuevo usuario.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!nUsuario.UsuarioExiste(txtUsuario.Text.Trim()))
                {
                    string usuarioID = txtUsuario.Text.Trim();
                    string contra = txtContra.Text;

                    nUsuario.RegistrarUsuario(usuarioID, contra);
                    MessageBox.Show("Usuario registrado correctamente", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("El usuario ya existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            txtUsuario.Clear();
            txtContra.Clear();
            txtRepetirContra.Clear();
            txtUsuario.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
