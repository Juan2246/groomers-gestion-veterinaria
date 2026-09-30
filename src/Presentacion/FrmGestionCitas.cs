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
    public partial class FrmGestionCitas : Form
    {
        private NCita nCita = new NCita();
        private NVeterinario nVet = new NVeterinario();
        private NMascota nMascota = new NMascota();
        private NMedicamento nMedicamento = new NMedicamento();

        public FrmGestionCitas()
        {
            InitializeComponent();
            txtId.ReadOnly = true;
            txtCostoTotal.ReadOnly = true;
        }

        private void FrmGestionCitas_Load(object sender, EventArgs e)
        {
            CargarComboMedicamentos();
            CargarComboMascotas();
            CargarComboVeterinarios();
            MostrarCitas();
        }

        private void MostrarCitas()
        {
            var citas = nCita.ObtenerTodos();
            dgvCitas.DataSource = null;

            if (citas.Count > 0)
            {
                dgvCitas.DataSource = citas.Select(c => new
                {
                    c.CitaId,
                    c.CodigoMascota,
                    c.CodigoVeterinario,
                    c.CodigoMedicamento,
                    c.Dosis,
                    Fecha = c.FechaHora.ToString(),
                    c.Especialidad,
                    Mascota = c.Mascota.Nombre,
                    Veterinario = c.Veterinario.Nombre,
                    Medicamento = c.Medicamento.Nombre,
                    c.CostoCita,
                    c.CostoTotal,
                    c.Notas,
                    c.UsuarioActualizacion,
                    FechaActualizacion = c.FechaActualizacion?.ToString()
                }).ToList();
                foreach (string columna in new[] { "CodigoMascota", "CodigoVeterinario", "CodigoMedicamento" })
                    dgvCitas.Columns[columna].Visible = false;
                dgvCitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvCitas.ReadOnly = true;
                dgvCitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void CargarComboMedicamentos()
        {
            var medicamentos = nMedicamento.ObtenerTodos();
            cmbMedicamento.DataSource = medicamentos;
            cmbMedicamento.DisplayMember = "Nombre";
            cmbMedicamento.ValueMember = "MedicamentoId";
        }

        private void CargarComboMascotas()
        {
            var mascotas = nMascota.ObtenerTodos();
            cmbMascotas.DataSource = mascotas;
            cmbMascotas.DisplayMember = "Nombre";
            cmbMascotas.ValueMember = "MascotaId";
        }

        private void CargarComboVeterinarios(string especialidad = "")
        {
            var veterinarios = string.IsNullOrEmpty(especialidad)
                ? nVet.ObtenerTodos()
                : nVet.ListarPorEspecialidad(especialidad);

            cmbVeterinarios.DataSource = veterinarios;
            cmbVeterinarios.DisplayMember = "Nombre";
            cmbVeterinarios.ValueMember = "VeterinarioId";
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtCostoCita.Text) ||
                cmbMascotas.SelectedItem == null || cmbEspecialidad.SelectedItem == null ||
                cmbVeterinarios.SelectedItem == null || cmbMedicamento.SelectedItem == null)
            {
                MessageBox.Show("Completa todos los campos obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!decimal.TryParse(txtCostoCita.Text, out decimal costo) || costo < 0 || costo > 99999999.99m
                || txtDosis.Text.Length > 30 || txtNotas.Text.Length > 120)
            {
                MessageBox.Show("Use un costo no negativo, dosis de hasta 30 caracteres y notas de hasta 120 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtDosis.Clear();
            txtNotas.Clear();
            txtCostoCita.Clear();
            txtCostoTotal.Clear();
            cmbEspecialidad.SelectedItem = null;
            cmbMascotas.SelectedItem = null;
            cmbVeterinarios.SelectedItem = null;
            cmbMedicamento.SelectedItem = null;
            dtpFechaHora.Value = DateTime.Now;
        }
        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEspecialidad.SelectedItem != null)
            {
                CargarComboVeterinarios(cmbEspecialidad.Text);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var cita = ObtenerDatosFormulario();
                nCita.Agregar(cita);

                MessageBox.Show("Cita registrada exitosamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarCitas();
                LimpiarCampos();
            }
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int seleccion) || !nCita.CitaExiste(seleccion))
            {
                MessageBox.Show("Seleccione una cita existente.");
                return;
            }
            if (ValidarCampos())
            {
                var cita = ObtenerDatosFormulario();
                nCita.Actualizar(cita);

                MessageBox.Show("Cita modificada correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarCitas();
                LimpiarCampos();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCitas.CurrentRow != null)
            {
                int id = (int)dgvCitas.CurrentRow.Cells["CitaId"].Value;
                var confirmacion = MessageBox.Show("¿Deseas eliminar esta cita?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmacion == DialogResult.Yes)
                {
                    nCita.Eliminar(id);
                    MessageBox.Show("Cita eliminada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarCitas();
                    LimpiarCampos();
                }
            }
        }

        private Cita ObtenerDatosFormulario()
        {
            var costoCita = decimal.Parse(txtCostoCita.Text);
            var medicamento = (Medicamento)cmbMedicamento.SelectedItem;

            return new Cita
            {
                CitaId = int.TryParse(txtId.Text, out int seleccion) ? seleccion : 0,
                CodigoMascota = (int)cmbMascotas.SelectedValue,
                Especialidad = cmbEspecialidad.Text,
                Dosis = txtDosis.Text,
                Notas = txtNotas.Text,
                FechaHora = dtpFechaHora.Value,
                CodigoVeterinario = (int)cmbVeterinarios.SelectedValue,
                CodigoMedicamento = medicamento.MedicamentoId,
                CostoCita = costoCita,
                CostoTotal = costoCita + medicamento.Precio,
                UsuarioActualizacion = DUsuario.UsuarioActivo,
                FechaActualizacion = DateTime.Now
            };
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvCitas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var fila = dgvCitas.Rows[e.RowIndex];

                txtId.Text = fila.Cells["CitaId"].Value.ToString();
                cmbEspecialidad.Text = fila.Cells["Especialidad"].Value.ToString();
                cmbMascotas.SelectedValue = fila.Cells["CodigoMascota"].Value;
                cmbVeterinarios.SelectedValue = fila.Cells["CodigoVeterinario"].Value;
                cmbMedicamento.SelectedValue = fila.Cells["CodigoMedicamento"].Value;
                txtDosis.Text = fila.Cells["Dosis"].Value?.ToString();
                txtNotas.Text = fila.Cells["Notas"].Value.ToString();
                txtCostoCita.Text = fila.Cells["CostoCita"].Value.ToString();
                txtCostoTotal.Text = fila.Cells["CostoTotal"].Value.ToString();
                dtpFechaHora.Value = DateTime.Parse(fila.Cells["Fecha"].Value.ToString());
            }
        }
    }
}
