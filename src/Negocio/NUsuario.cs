using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public  class NUsuario
    {
        private DUsuario dUsuario = new DUsuario();

        public void RegistrarUsuario(string usuarioID, string contra)
        {
            dUsuario.RegistrarUsuario(usuarioID, contra);
        }

        public bool ValidarUsuario(string usuarioID, string contra)
        {
            return dUsuario.ValidarUsuario(usuarioID, contra);
        }

        public bool UsuarioExiste(string usuarioID)
        {
            return dUsuario.UsuarioExiste(usuarioID);
        }

        public string ObtenerUsuarioActivo()
        {
            return DUsuario.UsuarioActivo;
        }

        public bool ValidarContraAdmin(string contra)
        {
            return dUsuario.ValidarContraAdmin(contra);
        }
    }
}
