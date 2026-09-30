using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{

    public class NReportes
    {
        public static List<Cita> ObtenerCitasPorRango(DateTime fechaInicio, DateTime fechaFin)
        {
            if (fechaFin.Date < fechaInicio.Date) throw new ArgumentException("La fecha final debe ser igual o posterior a la inicial.");
            var dcita = new DCitas();
            DateTime finExclusivo = fechaFin.Date.AddDays(1);
            return dcita.ObtenerTodos()
                        .Where(c => c.FechaHora >= fechaInicio.Date && c.FechaHora < finExclusivo)
                        .ToList();
        }

        public static int ContarMascotasPorEspecie(string especie)
        {
            var dmascota = new DMascota();
            return dmascota.ObtenerTodos()
                           .Count(m => string.Equals(m.Especie, especie, StringComparison.OrdinalIgnoreCase));
        }

        public static List<Cita> ObtenerCitasPorVeterinario(int veterinarioId)
        {
            var dcita = new DCitas();
            return dcita.ObtenerTodos()
                        .Where(c => c.CodigoVeterinario == veterinarioId)
                        .ToList();
        }

        public static int ContarTotalCitas()
        {
            var dcita = new DCitas();
            return dcita.ObtenerTodos().Count;
        }

        public static List<Cita> ObtenerGananciasDelDia(out decimal total)
        {
            var dcita = new DCitas();
            DateTime hoy = DateTime.Today;

            var citasDelDia = dcita.ObtenerTodos()
                                   .Where(c => c.FechaHora.Date == hoy)
                                   .ToList();

            total = citasDelDia.Sum(c => c.CostoTotal);
            return citasDelDia;
        }
    }
}
