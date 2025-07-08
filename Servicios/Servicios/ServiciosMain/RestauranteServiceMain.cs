using Modelo.Context;
using Modelo.Factory.Personas;
using Modelo.Models;
using Seguirdad_Modulo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios.Servicios
{
    public class RestauranteServiceMain
    {
        private readonly EasyFoodFlowContext _context;
        private readonly Helpers _helper = new Helpers();

        public RestauranteServiceMain(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public Restaurante? ObtenerPorId(int id)
        {
            var restaurante = _context.Restaurantes.FirstOrDefault(r => r.IdRestaurante == id);
            if (restaurante == null)
            {
                return null; // o podés lanzar una excepción o manejarlo distinto
            }

            return restaurante;
        }

        public bool YaExiste(string nombre)
        {
            return _context.Restaurantes.Any(r => r.Nombre == nombre);
        }

        public Restaurante Crear(string nombre, string direccion, int capacidad)
        {
            var restaurante = new Restaurante
            {
                Nombre = nombre,
                Direccion = direccion,
                Deuda = 0
            };

            _context.Restaurantes.Add(restaurante);
            return restaurante;
        }

        public (AdminRestaurante, AdminCocina, CajeroRestaurante) CrearTiposUsuarios(int idRestaurante, int dniAdmin, int dniCocinero, int dniCajero)
        {
            // Define los nombres de los roles y otros atributos necesarios
            string Nom = "Admin";
            string Cajero = "Cajero";
            string Restaurante = "Restaurante";

            var admin = AdminRestauranteFactory.Crear(dniAdmin, idRestaurante, Nom, Restaurante);

            var cocinero = AdminCocinaFactory.Crear(dniCocinero, idRestaurante, "Cocina", Restaurante);

            var cajero = CajeroRestauranteFactory.Crear(dniCajero, idRestaurante, Cajero, Restaurante);

            if (admin == null || cocinero == null || cajero == null)
                throw new Exception("Error al crear los tipos de usuarios.");

            _context.Personas.AddRange(admin, cocinero, cajero);
            _context.SaveChanges();

            return (admin, cocinero, cajero);
        }

        public (Usuario, Usuario, Usuario) RegistrarUsuariosRestaurante(int idRestaurante, int dniAdmin, int dniCocinero, int dniCajero)
        {
            var rolAdmin = _context.Roles.FirstOrDefault(r => r.Nombre == "adminRestaurante");
            var rolCocina = _context.Roles.FirstOrDefault(r => r.Nombre == "adminCocina");
            var rolCaja = _context.Roles.FirstOrDefault(r => r.Nombre == "cajeroRestaurante");
            string PasswordDefault = "123";


            if (rolAdmin == null || rolCocina == null || rolCaja == null)
                throw new Exception("Uno o más roles no fueron encontrados.");


            var usuarioAdmin = UsuarioFactory.Crear($"adminRestaurante_{idRestaurante}", dniAdmin, rolAdmin.IdRol, _helper.HashearContrasena(PasswordDefault));

            var usuarioCocinero = UsuarioFactory.Crear($"adminCocina_{idRestaurante}", dniCocinero, rolCocina.IdRol, _helper.HashearContrasena(PasswordDefault));

            var usuarioCajero = UsuarioFactory.Crear($"cajaRestaurante_{idRestaurante}", dniCajero, rolCaja.IdRol, _helper.HashearContrasena(PasswordDefault));

            _context.Usuarios.AddRange(usuarioAdmin, usuarioCocinero, usuarioCajero);
            _context.SaveChanges();

            return (usuarioAdmin, usuarioCocinero, usuarioCajero);
        }

        public void Eliminar(Restaurante restaurante)
        {
            _context.Restaurantes.Remove(restaurante);
        }

        public void Modificar(Restaurante restaurante, string nombre, string direccion, int capacidad)
        {
            restaurante.Nombre = nombre;
            restaurante.Direccion = direccion;
            //  restaurante.Capacidad = capacidad;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
