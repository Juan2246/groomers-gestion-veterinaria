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
    public partial class FrmGestionPropietarios : Form
    {
        private NPropietario nPropietario = new NPropietario();
        private NLogsAcciones nLogsAcciones = new NLogsAcciones();

        public FrmGestionPropietarios()
        {
            InitializeComponent();
            dgvPropietarios.SelectionChanged += (sender, e) =>
            {
                var p = dgvPropietarios.CurrentRow?.DataBoundItem as Propietario;
                if (p == null) return;
                txtDNI.Text = p.DNI; txtNombrePropietario.Text = p.Nombre;
                txtTelefono.Text = p.Telefono; txtEmail.Text = p.Email;
            };
            MostrarPropietarios();
        }

        private void MostrarPropietarios()
        {
            dgvPropietarios.DataSource = nPropietario.ObtenerTodos();
        }

        private void LimpiarCampos()
        {
            txtDNI.Clear();
            txtNombrePropietario.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
        }

        private void btnAgregarPropietario_Click(object sender, EventArgs e)
        {
            if (!ValidarPropietario()) return;
            Propietario p = new Propietario
            {
                DNI = txtDNI.Text,
                Nombre = txtNombrePropietario.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Eliminado = false,
                FechaActualizacion = DateTime.Now,
                UsuarioActualizacion = DUsuario.UsuarioActivo,
            };

            nPropietario.Agregar(p);
            nLogsAcciones.Registrar("Se agregó un propietario", DUsuario.UsuarioActivo);

            MostrarPropietarios();
            LimpiarCampos();
        }

        private void btnEliminarPropietario_Click(object sender, EventArgs e)
        {
            if (dgvPropietarios.CurrentRow == null) return;

            string dni = dgvPropietarios.CurrentRow.Cells["Dni"].Value.ToString();
            var confirm = MessageBox.Show("¿Estás seguro de eliminar este propietario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                nPropietario.Eliminar(dni);
                nLogsAcciones.Registrar("Se eliminó un propietario", DUsuario.UsuarioActivo);
                MostrarPropietarios();
                LimpiarCampos();
            }
        }

        private void btnModificarPropietario_Click(object sender, EventArgs e)
        {
            if (dgvPropietarios.CurrentRow == null || !ValidarPropietario()) return;

            string dni = dgvPropietarios.CurrentRow.Cells["Dni"].Value.ToString();
            Propietario p = nPropietario.ObtenerPorDNI(dni);
            if (p == null) return;

            p.Nombre = txtNombrePropietario.Text;
            p.Telefono = txtTelefono.Text;
            p.Email = txtEmail.Text;
            p.FechaActualizacion = DateTime.Now;
            p.UsuarioActualizacion = DUsuario.UsuarioActivo;

            nPropietario.Actualizar(p);
            nLogsAcciones.Registrar("Se modificó un propietario", DUsuario.UsuarioActivo);

            MostrarPropietarios();
            LimpiarCampos();
        }

        private bool ValidarPropietario()
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtDNI.Text.Trim(), @"^\d{8}$")
                || !System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text.Trim(), @"^\d{9}$")
                || string.IsNullOrWhiteSpace(txtNombrePropietario.Text) || txtNombrePropietario.Text.Length > 60
                || txtEmail.Text.Length > 100 || !txtEmail.Text.Contains("@"))
            { MessageBox.Show("Revise DNI de 8 dígitos, teléfono de 9 dígitos, nombre y correo."); return false; }
            return true;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
