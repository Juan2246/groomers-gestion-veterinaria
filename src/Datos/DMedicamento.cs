using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DMedicamento
    {
        private DBEFEntities bdcontext = new DBEFEntities();
        public List<Medicamento> ObtenerTodos()
        {
            return bdcontext.Medicamento
                            .Where(m => m.Eliminado == false)
                            .ToList();
        }

        public bool MedicamentoExiste(int id)
        {
            return bdcontext.Medicamento.Any(m => m.MedicamentoId == id);
        }

        public Medicamento ObtenerPorId(int id)
        {
            return bdcontext.Medicamento.FirstOrDefault(m => m.MedicamentoId == id);
        }

        public void Agregar(Medicamento medicamento)
        {
            medicamento.UsuarioActualizacion = DUsuario.UsuarioActivo;
            medicamento.FechaActualizacion = DateTime.Now;
            medicamento.Eliminado = false;

            bdcontext.Medicamento.Add(medicamento);
            bdcontext.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var medicamento = ObtenerPorId(id);
            if (medicamento != null)
            {
                medicamento.Eliminado = true;
                medicamento.UsuarioActualizacion = DUsuario.UsuarioActivo;
                medicamento.FechaActualizacion = DateTime.Now;
                bdcontext.SaveChanges();
            }
        }

        public void Actualizar(Medicamento medicamentoActualizado)
        {
            var medicamento = ObtenerPorId(medicamentoActualizado.MedicamentoId);
            if (medicamento != null)
            {
                medicamento.Nombre = medicamentoActualizado.Nombre;
                medicamento.Descripcion = medicamentoActualizado.Descripcion;
                medicamento.Stock = medicamentoActualizado.Stock;
                medicamento.FechaCaducidad = medicamentoActualizado.FechaCaducidad;
                medicamento.Precio = medicamentoActualizado.Precio;
                medicamento.UsuarioActualizacion = DUsuario.UsuarioActivo;
                medicamento.FechaActualizacion = DateTime.Now;

                bdcontext.SaveChanges();
            }
        }
    }
}
