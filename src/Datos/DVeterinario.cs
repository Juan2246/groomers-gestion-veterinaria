using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DVeterinario
    {
        private DBEFEntities bdcontext = new DBEFEntities();

        public List<Veterinario> ObtenerTodos()
        {
            return bdcontext.Veterinario.Where(v => !v.Eliminado).ToList();
        }

        public bool VeterinarioExiste(int id)
        {
            return bdcontext.Veterinario.Any(v => v.VeterinarioId == id && !v.Eliminado);
        }

        public Veterinario ObtenerPorId(int id)
        {
            return bdcontext.Veterinario.FirstOrDefault(v => v.VeterinarioId == id && !v.Eliminado);
        }

        public List<Veterinario> ListarVeterinariosPorEspecialidad(string especialidad)
        {
            return bdcontext.Veterinario
                .Where(v => v.Especialidad.ToLower() == especialidad.ToLower() && !v.Eliminado)
                .ToList();
        }

        public void Agregar(Veterinario veterinario)
        {
            veterinario.UsuarioActualizacion = DUsuario.UsuarioActivo;
            veterinario.FechaActualizacion = DateTime.Now;
            veterinario.Eliminado = false;

            bdcontext.Veterinario.Add(veterinario);
            bdcontext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var veterinario = bdcontext.Veterinario.Find(id);
            if (veterinario != null)
            {
                veterinario.Eliminado = true;
                veterinario.UsuarioActualizacion = DUsuario.UsuarioActivo;
                veterinario.FechaActualizacion = DateTime.Now;
                bdcontext.SaveChanges();
            }
        }

        public void Actualizar(Veterinario veterinarioActualizado)
        {
            var veterinario = bdcontext.Veterinario.Find(veterinarioActualizado.VeterinarioId);
            if (veterinario != null)
            {
                veterinario.Nombre = veterinarioActualizado.Nombre;
                veterinario.Especialidad = veterinarioActualizado.Especialidad;
                veterinario.Telefono = veterinarioActualizado.Telefono;
                veterinario.UsuarioActualizacion = DUsuario.UsuarioActivo;
                veterinario.FechaActualizacion = DateTime.Now;

                bdcontext.SaveChanges();
            }
        }
    }
}
