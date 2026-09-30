using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DMascota
    {
        private DBEFEntities bdcontext = new DBEFEntities();

        public void Agregar(Mascota mascota)
        {
            mascota.UsuarioActualizacion = DUsuario.UsuarioActivo;
            mascota.FechaActualizacion = DateTime.Now;
            mascota.Eliminado = false;

            bdcontext.Mascota.Add(mascota);
            bdcontext.SaveChanges();
        }

        public List<Mascota> ObtenerTodos()
        {
            return bdcontext.Mascota.Where(m => m.Eliminado == false).ToList();
        }

        public Mascota ObtenerPorId(int id)
        {
            return bdcontext.Mascota
                .FirstOrDefault(m => m.MascotaId == id && m.Eliminado == false);
        }

        public void Eliminar(int id)
        {
            var mascota = bdcontext.Mascota.FirstOrDefault(m => m.MascotaId == id);
            if (mascota != null)
            {
                mascota.Eliminado = true;
                mascota.UsuarioActualizacion = DUsuario.UsuarioActivo;
                mascota.FechaActualizacion = DateTime.Now;

                bdcontext.SaveChanges();
            }
        }

        public void Actualizar(Mascota mascotaActualizada)
        {
            var mascota = bdcontext.Mascota.FirstOrDefault(m => m.MascotaId == mascotaActualizada.MascotaId);
            if (mascota != null)
            {
                mascota.Nombre = mascotaActualizada.Nombre;
                mascota.Especie = mascotaActualizada.Especie;
                mascota.Raza = mascotaActualizada.Raza;
                mascota.Edad = mascotaActualizada.Edad;
                mascota.Peso = mascotaActualizada.Peso;
                mascota.Sexo = mascotaActualizada.Sexo;
                mascota.CodigoPropietario = mascotaActualizada.CodigoPropietario;
                mascota.UsuarioActualizacion = DUsuario.UsuarioActivo;
                mascota.FechaActualizacion = DateTime.Now;

                bdcontext.SaveChanges();
            }
        }
    }
}
