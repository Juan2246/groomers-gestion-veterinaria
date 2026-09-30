using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NVeterinario
    {
        private DVeterinario dVeterinario = new DVeterinario();

        public List<Veterinario> ObtenerTodos()
        {
            return dVeterinario.ObtenerTodos();
        }

        public bool VeterinarioExiste(int id)
        {
            return dVeterinario.VeterinarioExiste(id);
        }

        public Veterinario BuscarPorId(int id)
        {
            return dVeterinario.ObtenerPorId(id);
        }

        public List<Veterinario> ListarPorEspecialidad(string especialidad)
        {
            return dVeterinario.ListarVeterinariosPorEspecialidad(especialidad);
        }

        public void Agregar(Veterinario veterinario)
        {
            dVeterinario.Agregar(veterinario);
        }

        public void Actualizar(Veterinario veterinario)
        {
            dVeterinario.Actualizar(veterinario);
        }

        public void Eliminar(int id)
        {
            dVeterinario.Eliminar(id);
        }
    }
}
