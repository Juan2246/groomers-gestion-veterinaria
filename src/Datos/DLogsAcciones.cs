using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DLogsAcciones
    {
        private DBEFEntities bdcontext = new DBEFEntities();
        public void AgregarLog(string usuario, string accion)
        {
            LogsAcciones log = new LogsAcciones
            {
                Usuario = usuario,
                Accion = accion,
                FechaHora = DateTime.Now
            };

            bdcontext.LogsAcciones.Add(log);
            bdcontext.SaveChanges();
        }

        public List<LogsAcciones> ObtenerLogs()
        {
            return bdcontext.LogsAcciones.OrderByDescending(l => l.FechaHora).ToList();
        }
    }
}
