using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NPropietario
    {
        private DPropietario dPropietario = new DPropietario();

        public List<Propietario> ObtenerTodos()
        {
            return dPropietario.ObtenerTodos();
        }

        public Propietario ObtenerPorDNI(string dni)
        {
            return dPropietario.ObtenerPorDNI(dni);
        }

        public bool PropietarioExiste(string dni)
        {
            return dPropietario.PropietarioExiste(dni);
        }

        public void Agregar(Propietario propietario)
        {
            dPropietario.Agregar(propietario);
        }

        public void Actualizar(Propietario propietario)
        {
            dPropietario.Actualizar(propietario);
        }

        public void Eliminar(string dni)
        {
            dPropietario.Eliminar(dni);
        }
    }
}
