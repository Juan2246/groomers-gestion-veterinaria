using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DCitas
    {
        private DBEFEntities bdcontext = new DBEFEntities();

        public List<Cita> ObtenerTodos()
        {
            return bdcontext.Cita.Where(c => c.Eliminado == false).ToList();
        }

        public bool CitaExiste(int id)
        {
            return bdcontext.Cita.Any(c => c.CitaId == id && c.Eliminado == false);
        }

        public Cita ObtenerPorId(int id)
        {
            return bdcontext.Cita.FirstOrDefault(c => c.CitaId == id && c.Eliminado == false);
        }

        public void Agregar(Cita cita)
        {
            ValidarDisponibilidad(cita);
            cita.UsuarioActualizacion = DUsuario.UsuarioActivo;
            cita.FechaActualizacion = DateTime.Now;
            cita.Eliminado = false;

            bdcontext.Cita.Add(cita);
            RegistrarAccion("Registró una cita");
            bdcontext.SaveChanges();
        }

        public void Actualizar(Cita citaActualizada)
        {
            ValidarDisponibilidad(citaActualizada);
            var cita = bdcontext.Cita.FirstOrDefault(c => c.CitaId == citaActualizada.CitaId && c.Eliminado == false);

            if (cita != null)
            {
                cita.Especialidad = citaActualizada.Especialidad;
                cita.Dosis = citaActualizada.Dosis;
                cita.Notas = citaActualizada.Notas;
                cita.FechaHora = citaActualizada.FechaHora;
                cita.CostoCita = citaActualizada.CostoCita;
                cita.CostoTotal = citaActualizada.CostoTotal;
                cita.CodigoMascota = citaActualizada.CodigoMascota;
                cita.CodigoVeterinario = citaActualizada.CodigoVeterinario;
                cita.CodigoMedicamento = citaActualizada.CodigoMedicamento;
                RegistrarAccion("Modificó una cita");
                cita.UsuarioActualizacion = DUsuario.UsuarioActivo;
                cita.FechaActualizacion = DateTime.Now;

                bdcontext.SaveChanges();
            }
        }

        public void Eliminar(int id) {
            var cita = bdcontext.Cita.FirstOrDefault(c => c.CitaId == id && c.Eliminado == false);

            if (cita != null)
            {
                cita.Eliminado = true;
                RegistrarAccion("Archivó una cita");
                cita.FechaActualizacion = DateTime.Now;
                cita.UsuarioActualizacion = DUsuario.UsuarioActivo;

                bdcontext.SaveChanges();
            }
        }

        private void RegistrarAccion(string accion)
        {
            if (!string.IsNullOrEmpty(DUsuario.UsuarioActivo))
                bdcontext.LogsAcciones.Add(new LogsAcciones { Usuario = DUsuario.UsuarioActivo, Accion = accion, FechaHora = DateTime.Now });
        }
        private void ValidarDisponibilidad(Cita cita)
        {
            if (bdcontext.Cita.Any(c => !c.Eliminado && c.CitaId != cita.CitaId
                && c.FechaHora == cita.FechaHora
                && (c.CodigoVeterinario == cita.CodigoVeterinario || c.CodigoMascota == cita.CodigoMascota)))
                throw new ArgumentException("El veterinario o la mascota ya tiene una cita en ese horario.");
            if (!bdcontext.Mascota.Any(m => m.MascotaId == cita.CodigoMascota && !m.Eliminado)
                || !bdcontext.Veterinario.Any(v => v.VeterinarioId == cita.CodigoVeterinario && !v.Eliminado)
                || !bdcontext.Medicamento.Any(m => m.MedicamentoId == cita.CodigoMedicamento && !m.Eliminado))
                throw new ArgumentException("Seleccione una mascota, veterinario y medicamento vigentes.");
            if (cita.CostoCita < 0 || cita.CostoTotal < cita.CostoCita)
                throw new ArgumentException("Revise los costos de la cita.");
        }
    }
}
