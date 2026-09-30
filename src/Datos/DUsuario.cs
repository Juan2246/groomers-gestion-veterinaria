using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DUsuario
    {
        private DBEFEntities bdcontext = new DBEFEntities();

        public static string UsuarioActivo = null;

        public void RegistrarUsuario(string usuarioID, string contra)
        {
            Usuario usuario = new Usuario
            {
                UsuarioID = usuarioID,
                Contraseña = PasswordHasher.Hash(contra),
            };

            bdcontext.Usuario.Add(usuario);
            bdcontext.SaveChanges();
        }

        public bool ValidarUsuario(string usuarioID, string contra)
        {
            UsuarioActivo = null;
            var usuario = bdcontext.Usuario.FirstOrDefault(u => u.UsuarioID == usuarioID);

            if (usuario != null && PasswordHasher.Verify(contra, usuario.Contraseña))
            {
                UsuarioActivo = usuario.UsuarioID;
                return true;
            }

            return false;
        }

        public bool UsuarioExiste(string usuarioID)
        {
            return bdcontext.Usuario.Any(u => u.UsuarioID == usuarioID);
        }

        public bool ValidarContraAdmin(string contra)
        {
            var admin = bdcontext.Usuario.FirstOrDefault(u => u.UsuarioID == "admin");
            return admin != null && PasswordHasher.Verify(contra, admin.Contraseña);
        }
    }
}
