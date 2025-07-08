using Modelo.Context;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguirdad.Seguirdad;
using Seguirdad_Modulo.Helpers;

namespace Controladora.Seguridad
{
    public class ControladoraPerfil
    {
        private readonly PasswordCheck _passwordCheck;
        private readonly SeguridadServiceConCache _servicioSeguridad;

        private int _idRestaurante;
        private int _idUsuario;


        public ControladoraPerfil(int idRestaurante, int idUsuario)
        {
            _servicioSeguridad = new SeguridadServiceConCache();
            _passwordCheck = new PasswordCheck();
            _idRestaurante = idRestaurante;
            _idUsuario = idUsuario;
        }

        public List<Usuario> CargarUsuarios(int idRestaurante)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionRestaurante"))
            {
                MessageBox.Show("No tienes permiso para consultar usuarios.",
                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<Usuario>();
            }

            var Resutlado =  _servicioSeguridad.ObtenerUsuariosPorRestauranteAsync(idRestaurante);
            return Resutlado.Result.Data;
        }


    }
}
