using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Modelo.Context;

namespace Seguirdad_Modulo.Helpers
{
    public class Helpers
    {
        private readonly EasyFoodFlowContext _context;

        public Helpers()
        {
            _context = new EasyFoodFlowContext();
        }

        public string HashearContrasena(string contrasena)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool EsEmailValido(string email)
        {
            try
            {
                MailAddress direccion = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TienePermiso(int idRol, string nombrePermiso)
        {
            try
            {
                var rol = _context.Roles
                    .Include(r => r.IdPermisos)
                    .Include(r => r.RolesHijos)
                    .ThenInclude(rh => rh.IdPermisos)
                    .FirstOrDefault(r => r.IdRol == idRol);

                if (rol == null)
                    return false;

                rol.InicializarDesdeEF();
                return rol.HasPermission(nombrePermiso);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
