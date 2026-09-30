using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NCita
    {
        private DCitas dCitas = new DCitas();

        public List<Cita> ObtenerTodos()
        {
            return dCitas.ObtenerTodos();
        }

        public bool CitaExiste(int id)
        {
            return dCitas.CitaExiste(id);
        }

        public Cita ObtenerPorId(int id)
        {
            return dCitas.ObtenerPorId(id);
        }

        public void Agregar(Cita cita)
        {
            dCitas.Agregar(cita);
        }

        public void Actualizar(Cita cita)
        {
            dCitas.Actualizar(cita);
        }

        public void Eliminar(int id)
        {
            dCitas.Eliminar(id);
        }
    }
}
