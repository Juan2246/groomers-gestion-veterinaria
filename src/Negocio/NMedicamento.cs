using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NMedicamento
    {
        private DMedicamento dMedicamento = new DMedicamento();

        public List<Medicamento> ObtenerTodos()
        {
            return dMedicamento.ObtenerTodos();
        }

        public Medicamento ObtenerPorId(int id)
        {
            return dMedicamento.ObtenerPorId(id);
        }

        public void Agregar(Medicamento medicamento)
        {
            dMedicamento.Agregar(medicamento);
        }

        public void Actualizar(Medicamento medicamento)
        {
            dMedicamento.Actualizar(medicamento);
        }

        public void Eliminar(int id)
        {
            dMedicamento.Eliminar(id);
        }

        public bool MedicamentoExiste(int id)
        {
            return dMedicamento.MedicamentoExiste(id);
        }
    }
}
