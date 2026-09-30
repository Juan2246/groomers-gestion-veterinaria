using Datos;
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

namespace Presentacion
{
    public partial class FrmGestionVeterinarios : Form
    {
        private NVeterinario nVeterinario = new NVeterinario();
        private NLogsAcciones nLogsAcciones = new NLogsAcciones();

        private int veterinarioSeleccionadoId = 0;

        public FrmGestionVeterinarios()
        {
            InitializeComponent();
            dgvVeterinarios.SelectionChanged += (sender, e) =>
            {
                var vet = dgvVeterinarios.CurrentRow?.DataBoundItem as Veterinario;
                if (vet == null) { veterinarioSeleccionadoId = 0; return; }
                veterinarioSeleccionadoId = vet.VeterinarioId;
                txtNombre.Text = vet.Nombre;
                txtTelefono.Text = vet.Telefono;
                cmbEspecialidad.Text = vet.Especialidad;
            };
        }

        private void FrmGestionVeterinarios_Load(object sender, EventArgs e)
        {
            MostrarVeterinarios(nVeterinario.ObtenerTodos());
        }

        private void MostrarVeterinarios(List<Veterinario> veterinarios)
        {
            dgvVeterinarios.DataSource = null;
            dgvVeterinarios.DataSource = veterinarios;

            dgvVeterinarios.Columns["Eliminado"].Visible = false;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            cmbEspecialidad.SelectedItem = null;
            txtTelefono.Clear();

            txtNombre.Focus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarVeterinario())
            {
                Veterinario veterinario = new Veterinario
                {
                    Nombre = txtNombre.Text.Trim(),
                    Especialidad = cmbEspecialidad.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim()
                };

                nVeterinario.Agregar(veterinario);
                nLogsAcciones.Registrar("Agregó un veterinario", DUsuario.UsuarioActivo);

                MessageBox.Show("Veterinario registrado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarVeterinarios(nVeterinario.ObtenerTodos());
                LimpiarCampos();
            }
            else
                MessageBox.Show("Llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (veterinarioSeleccionadoId == 0)
            {
                MessageBox.Show("Selecciona un veterinario para eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirmacion = MessageBox.Show("¿Deseas eliminar este veterinario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                nVeterinario.Eliminar(veterinarioSeleccionadoId);
                nLogsAcciones.Registrar("Eliminó un veterinario", DUsuario.UsuarioActivo);

                MessageBox.Show("Veterinario eliminado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarVeterinarios(nVeterinario.ObtenerTodos());
                LimpiarCampos();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (veterinarioSeleccionadoId == 0)
            {
                MessageBox.Show("Selecciona un veterinario para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ValidarVeterinario())
            {
                Veterinario veterinario = new Veterinario
                {
                    VeterinarioId = veterinarioSeleccionadoId,
                    Nombre = txtNombre.Text.Trim(),
                    Especialidad = cmbEspecialidad.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim()
                };

                nVeterinario.Actualizar(veterinario);
                nLogsAcciones.Registrar("Actualizó un veterinario", DUsuario.UsuarioActivo);

                MessageBox.Show("Veterinario modificado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarVeterinarios(nVeterinario.ObtenerTodos());
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarVeterinario()
        {
            return !string.IsNullOrWhiteSpace(txtNombre.Text) && txtNombre.Text.Trim().Length <= 60
                && cmbEspecialidad.SelectedItem != null
                && System.Text.RegularExpressions.Regex.IsMatch(txtTelefono.Text.Trim(), @"^\d{9}$");
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
