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
    public partial class FrmReportes : Form
    {
        private static NMascota nMascota = new NMascota();
        private static NVeterinario nVeterinario = new NVeterinario();

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            CargarComboVeterinarios();
        }

        private void CargarComboVeterinarios()
        {
            var lista = nVeterinario.ObtenerTodos();
            if (lista.Count > 0)
            {
                cmbVeterinario.DataSource = null;
                cmbVeterinario.DataSource = lista;
                cmbVeterinario.DisplayMember = "Nombre";
                cmbVeterinario.ValueMember = "VeterinarioId";
            }
            else
            {
                cmbVeterinario.DataSource = null;
                MessageBox.Show("No hay veterinarios registrados.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (cmbTipoReporte.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un Reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tipoReporte = cmbTipoReporte.SelectedItem.ToString();
            var listaMascotas = nMascota.ObtenerTodos();

            switch (tipoReporte)
            {
                case "Obtener citas por un rango de fecha seleccionado":
                    if (dtpFechaFin.Value.Date < dtpFechaInicio.Value.Date)
                    {
                        MessageBox.Show("La fecha final debe ser igual o posterior a la inicial.");
                        return;
                    }
                    dgvReporte.DataSource = null;
                    dgvReporte.Columns.Clear();
                    DateTime inicio = dtpFechaInicio.Value.Date;
                    DateTime fin = dtpFechaFin.Value.Date;
                    var citas = NReportes.ObtenerCitasPorRango(inicio, fin);
                    dgvReporte.DataSource = citas
                        .Select(c => new
                        {
                            Fecha = c.FechaHora.ToString("dd/MM/yyyy HH:mm"),
                            Mascota = listaMascotas.FirstOrDefault(m => m.MascotaId == c.CodigoMascota)?.Nombre ?? "Mascota archivada"
                        }).ToList();
                    break;

                case "Cantidad de mascotas registradas por especie":
                    dgvReporte.DataSource = null;
                    dgvReporte.Columns.Clear();
                    dgvReporte.Rows.Clear();

                    var mascotas = nMascota.ObtenerTodos();
                    var especies = mascotas.Select(m => m.Especie).Distinct(StringComparer.OrdinalIgnoreCase);

                    dgvReporte.Columns.Add("Especie", "Especie");
                    dgvReporte.Columns.Add("Cantidad", "Cantidad");

                    foreach (var especie in especies)
                    {
                        int cantidad = NReportes.ContarMascotasPorEspecie(especie);
                        dgvReporte.Rows.Add(especie, cantidad);
                    }

                    break;

                case "Obtener citas por Veterinario Especifico":
                    dgvReporte.DataSource = null;
                    dgvReporte.Columns.Clear();
                    dgvReporte.Rows.Clear();

                    if (cmbVeterinario.SelectedValue != null && int.TryParse(cmbVeterinario.SelectedValue.ToString(), out int idVet))
                    {
                        var citasVet = NReportes.ObtenerCitasPorVeterinario(idVet);
                        dgvReporte.DataSource = citasVet
                            .Select(c => new
                            {
                                Fecha = c.FechaHora.ToString("dd/MM/yyyy HH:mm"),
                                Mascota = listaMascotas.FirstOrDefault(m => m.MascotaId == c.CodigoMascota)?.Nombre ?? "Mascota archivada",
                            }).ToList();
                    }
                    else
                    {
                        MessageBox.Show("Seleccione un veterinario válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case "Cantidad Total de citas del sistema":
                    dgvReporte.DataSource = null;
                    dgvReporte.Columns.Clear();
                    dgvReporte.Rows.Clear();

                    int totalCitas = NReportes.ContarTotalCitas();

                    dgvReporte.Columns.Add("Descripción", "Descripción");
                    dgvReporte.Columns.Add("Cantidad", "Cantidad");

                    dgvReporte.Rows.Add("Total de citas registradas", totalCitas);
                    break;

                case "Ganancias del día":
                    dgvReporte.DataSource = null;
                    dgvReporte.Columns.Clear();

                    var citasHoy = NReportes.ObtenerGananciasDelDia(out decimal ganancias);

                    if (citasHoy.Count == 0)
                    {
                        MessageBox.Show("No hay citas registradas para hoy.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    dgvReporte.DataSource = citasHoy
                        .Select(c => new
                        {
                            Fecha = c.FechaHora.ToString(),
                            Veterinario = c.CodigoVeterinario,
                            Mascota = c.CodigoMascota,
                            Especialidad = c.Especialidad,
                            Monto = c.CostoTotal
                        }).ToList();

                    MessageBox.Show($"Importe de citas de hoy: S/ {ganancias}", "Ganancias del día", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                default:
                    MessageBox.Show("Seleccione una opción válida de reporte.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvReporte.ReadOnly = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
