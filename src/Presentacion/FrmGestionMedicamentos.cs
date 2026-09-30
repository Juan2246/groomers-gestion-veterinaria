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
    public partial class FrmGestionMedicamentos : Form
    {
        private NMedicamento nMedicamento = new NMedicamento();
        private NLogsAcciones nLogsAcciones = new NLogsAcciones();

        public FrmGestionMedicamentos()
        {
            InitializeComponent();
            dgvMedicamentos.SelectionChanged += (sender, e) =>
            {
                var m = dgvMedicamentos.CurrentRow?.DataBoundItem as Medicamento;
                if (m == null) return;
                txtNombre.Text = m.Nombre; txtDescripcion.Text = m.Descripcion;
                txtStock.Text = m.Stock.ToString(); txtPrecio.Text = m.Precio.ToString(); dtpFechaCaducidad.Value = m.FechaCaducidad;
            };
        }

        private void FrmGestionMedicamentos_Load(object sender, EventArgs e)
        {
            MostrarMedicamentos(nMedicamento.ObtenerTodos());
        }

        private void MostrarMedicamentos(List<Medicamento> medicamentos)
        {
            dgvMedicamentos.DataSource = null;
            if (medicamentos.Count > 0)
                dgvMedicamentos.DataSource = medicamentos;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtStock.Clear();
            txtPrecio.Clear();
            dtpFechaCaducidad.Value = DateTime.Today;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && txtNombre.Text.Length <= 60 && txtDescripcion.Text.Length <= 60 && txtDescripcion.Text != "" &&
        txtStock.Text != "" && txtPrecio.Text != "")
            {
                if (!int.TryParse(txtStock.Text.Trim(), out int stock) || stock < 0)
                {
                    MessageBox.Show("El Stock debe ser un número entero válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0 || precio > 99999999.99m)
                {
                    MessageBox.Show("El precio debe ser un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Medicamento medicamento = new Medicamento
                {
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Stock = stock,
                    Precio = precio,
                    FechaCaducidad = dtpFechaCaducidad.Value,
                    UsuarioActualizacion = DUsuario.UsuarioActivo,
                    FechaActualizacion = DateTime.Now
                };

                nMedicamento.Agregar(medicamento);
                nLogsAcciones.Registrar("Agregó un medicamento", DUsuario.UsuarioActivo);

                MessageBox.Show("Medicamento agregado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarMedicamentos(nMedicamento.ObtenerTodos());
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.CurrentRow != null)
            {
                int id = (int)dgvMedicamentos.CurrentRow.Cells["MedicamentoId"].Value;

                var confirmacion = MessageBox.Show("¿Eliminar medicamento seleccionado?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.Yes)
                {
                    nMedicamento.Eliminar(id);
                    nLogsAcciones.Registrar("Eliminó un medicamento", DUsuario.UsuarioActivo);

                    MessageBox.Show("Medicamento eliminado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MostrarMedicamentos(nMedicamento.ObtenerTodos());
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un medicamento para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvMedicamentos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un medicamento para modificar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && txtNombre.Text.Length <= 60 && txtDescripcion.Text.Length <= 60 && txtDescripcion.Text != "" &&
                txtStock.Text != "" && txtPrecio.Text != "")
            {
                if (!int.TryParse(txtStock.Text.Trim(), out int stock) || stock < 0)
                {
                    MessageBox.Show("El Stock debe ser un número entero válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio) || precio < 0 || precio > 99999999.99m)
                {
                    MessageBox.Show("El precio debe ser un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int id = (int)dgvMedicamentos.CurrentRow.Cells["MedicamentoId"].Value;

                Medicamento medicamento = new Medicamento
                {
                    MedicamentoId = id,
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = txtDescripcion.Text.Trim(),
                    Stock = stock,
                    Precio = precio,
                    FechaCaducidad = dtpFechaCaducidad.Value,
                    UsuarioActualizacion = DUsuario.UsuarioActivo,
                    FechaActualizacion = DateTime.Now
                };

                nMedicamento.Actualizar(medicamento);
                nLogsAcciones.Registrar("Modificó un medicamento", DUsuario.UsuarioActivo);

                MessageBox.Show("Medicamento actualizado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarMedicamentos(nMedicamento.ObtenerTodos());
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos para modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
