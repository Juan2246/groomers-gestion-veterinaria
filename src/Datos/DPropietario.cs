using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DPropietario
    {
        private DBEFEntities bdcontext = new DBEFEntities();

        public List<Propietario> ObtenerTodos()
        {
            return bdcontext.Propietario.Where(p => p.Eliminado == false).ToList();
        }

        public Propietario ObtenerPorDNI(string dni)
        {
            return bdcontext.Propietario.FirstOrDefault(p => p.DNI == dni);
        }

        public bool PropietarioExiste(string dni)
        {
            return bdcontext.Propietario.Any(p => p.DNI == dni && p.Eliminado == false);
        }

        public void Agregar(Propietario propietario)
        {
            propietario.FechaActualizacion = DateTime.Now;
            propietario.UsuarioActualizacion = DUsuario.UsuarioActivo;
            propietario.Eliminado = false;

            bdcontext.Propietario.Add(propietario);
            bdcontext.SaveChanges();
        }

        public void Actualizar(Propietario propietarioActualizado)
        {
            var propietario = ObtenerPorDNI(propietarioActualizado.DNI);
            if (propietario != null && !propietario.Eliminado)
            {
                propietario.Nombre = propietarioActualizado.Nombre;
                propietario.Telefono = propietarioActualizado.Telefono;
                propietario.Email = propietarioActualizado.Email;
                propietario.UsuarioActualizacion = DUsuario.UsuarioActivo;
                propietario.FechaActualizacion = DateTime.Now;

                bdcontext.SaveChanges();
            }
        }

        public void Eliminar(string dni)
        {
            var propietario = ObtenerPorDNI(dni);
            if (propietario != null && !propietario.Eliminado)
            {
                propietario.Eliminado = true;
                propietario.UsuarioActualizacion = DUsuario.UsuarioActivo;
                propietario.FechaActualizacion = DateTime.Now;

                bdcontext.SaveChanges();
            }
        }
    }
}