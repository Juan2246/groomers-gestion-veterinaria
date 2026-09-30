using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NMascota
    {
        private DMascota dMascota = new DMascota();

        public void RegistrarMascota(Mascota mascota)
        {
            dMascota.Agregar(mascota);
        }
        public List<Mascota> ObtenerTodos()
        {
            return dMascota.ObtenerTodos();
        }

        public Mascota BuscarPorId(int id)
        {
            return dMascota.ObtenerPorId(id);
        }

        public void EliminarMascota(int id)
        {
            dMascota.Eliminar(id);
        }

        public void ActualizarMascota(Mascota mascota)
        {
            dMascota.Actualizar(mascota);
        }
    }
}
