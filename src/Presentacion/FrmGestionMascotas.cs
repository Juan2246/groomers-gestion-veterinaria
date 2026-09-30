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
    public partial class FrmGestionMascotas : Form
    {
        private NMascota nMascota = new NMascota();
        private NPropietario nPropietario = new NPropietario();
        private NLogsAcciones nLogsAcciones = new NLogsAcciones();

        public FrmGestionMascotas()
        {
            InitializeComponent();
            MostrarMascotas();
            CargarPropietariosEnCombo();
        }

        private void MostrarMascotas()
        {
            dgvMascotas.DataSource = nMascota.ObtenerTodos();
        }

        private void CargarPropietariosEnCombo()
        {
            cmbPropietarios.DataSource = nPropietario.ObtenerTodos();
            cmbPropietarios.DisplayMember = "Nombre";
            cmbPropietarios.ValueMember = "DNI";
        }

        private void LimpiarCampos()
        {
            txtNombreMascota.Clear();
            cmbSexo.SelectedIndex = -1;
            txtRaza.Clear();
            txtEdad.Clear();
            txtPeso.Clear();
            cmbEspecie.SelectedIndex = -1;
            cmbPropietarios.SelectedIndex = -1;
        }

        private void dgvMascotas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMascotas.CurrentRow == null) return;

            txtNombreMascota.Text = dgvMascotas.CurrentRow.Cells["Nombre"].Value.ToString();
            cmbSexo.Text = dgvMascotas.CurrentRow.Cells["Sexo"].Value.ToString();
            cmbEspecie.Text = dgvMascotas.CurrentRow.Cells["Especie"].Value.ToString();
            txtRaza.Text = dgvMascotas.CurrentRow.Cells["Raza"].Value.ToString();
            txtEdad.Text = dgvMascotas.CurrentRow.Cells["Edad"].Value.ToString();
            txtPeso.Text = dgvMascotas.CurrentRow.Cells["Peso"].Value.ToString();
            cmbPropietarios.SelectedValue = dgvMascotas.CurrentRow.Cells["CodigoPropietario"].Value.ToString();
        }

        private void btnAgregarMascota_Click(object sender, EventArgs e)
        {
            if (!ValidarMascota()) return;
            Mascota m = new Mascota
            {
                Nombre = txtNombreMascota.Text.Trim(),
                Sexo = cmbSexo.Text,
                Especie = cmbEspecie.Text,
                Raza = txtRaza.Text,
                Edad = int.Parse(txtEdad.Text),
                Peso = decimal.Parse(txtPeso.Text),
                CodigoPropietario = cmbPropietarios.SelectedValue.ToString(),
                Eliminado = false,
                FechaActualizacion = DateTime.Now,
                UsuarioActualizacion = DUsuario.UsuarioActivo,
            };

            nMascota.RegistrarMascota(m);
            nLogsAcciones.Registrar("Se agregó una mascota", DUsuario.UsuarioActivo);

            MostrarMascotas();
            LimpiarCampos();
        }

        private void btnEliminarMascota_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["MascotaId"].Value);
            var confirm = MessageBox.Show("¿Estás seguro de eliminar esta mascota?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                nMascota.EliminarMascota(id);
                nLogsAcciones.Registrar("Se eliminó una mascota", DUsuario.UsuarioActivo);
                MostrarMascotas();
                LimpiarCampos();
            }
        }

        private void btnModificarMascota_Click(object sender, EventArgs e)
        {
            if (dgvMascotas.CurrentRow == null || !ValidarMascota()) return;

            int id = Convert.ToInt32(dgvMascotas.CurrentRow.Cells["MascotaId"].Value);
            Mascota m = nMascota.BuscarPorId(id);
            if (m == null) return;

            m.Nombre = txtNombreMascota.Text;
            m.Especie = cmbEspecie.Text;
            m.Sexo = cmbSexo.Text;
            m.Raza = txtRaza.Text;
            m.Edad = int.Parse(txtEdad.Text);
            m.Peso = decimal.Parse(txtPeso.Text);
            m.CodigoPropietario = cmbPropietarios.SelectedValue.ToString();
            m.FechaActualizacion = DateTime.Now;
            m.UsuarioActualizacion = DUsuario.UsuarioActivo;

            nMascota.ActualizarMascota(m);
            nLogsAcciones.Registrar("Se modificó una mascota", DUsuario.UsuarioActivo);

            MostrarMascotas();
            LimpiarCampos();
        }

        private bool ValidarMascota()
        {
            int edad; decimal peso;
            if (string.IsNullOrWhiteSpace(txtNombreMascota.Text) || txtNombreMascota.Text.Length > 60
                || string.IsNullOrWhiteSpace(txtRaza.Text) || txtRaza.Text.Length > 30
                || cmbSexo.SelectedItem == null || cmbEspecie.SelectedItem == null || cmbPropietarios.SelectedValue == null
                || !int.TryParse(txtEdad.Text, out edad) || edad < 0
                || !decimal.TryParse(txtPeso.Text, out peso) || peso <= 0 || peso > 99.99m)
            {
                MessageBox.Show("Complete los campos. Use edad no negativa y peso mayor que 0 y hasta 99,99 kg.");
                return false;
            }
            return true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
