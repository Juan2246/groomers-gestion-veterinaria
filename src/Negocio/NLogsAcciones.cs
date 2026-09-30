using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NLogsAcciones
    {
        private DLogsAcciones dLogs = new DLogsAcciones();

        public void Registrar(string accion, string usuario)
        {
            dLogs.AgregarLog(usuario, accion);
        }

        public List<LogsAcciones> ObtenerLogs()
        {
            return dLogs.ObtenerLogs();
        }
    }
}
