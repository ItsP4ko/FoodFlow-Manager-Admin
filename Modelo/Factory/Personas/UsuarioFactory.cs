using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Factory.Personas
{
    public class UsuarioFactory
    {
        public static Usuario Crear(string nombreUsuario, int dni, int Rol,string password)
        {
            return new Usuario
            {
                NombreUsuario = nombreUsuario,
                Dni = dni,
                IdRol = Rol,
                Password = password,
                
            };
        }


    }

}
