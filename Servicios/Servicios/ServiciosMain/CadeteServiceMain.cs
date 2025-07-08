using Modelo.Context;
using Modelo.Factory;
using Servicios.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios.ServiciosMain
{
    public class CadeteServiceMain
    {
        private readonly EasyFoodFlowContext _context;

        public CadeteServiceMain(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public bool ExisteCadete(int dni)
        {
            return _context.Cadetes.Any(c => c.Dni == dni);
        }

        public bool CrearCadete(int dni, string nombre, string apellido)
        {
            if (ExisteCadete(dni))
                throw new ArgumentException("Ya existe un cadete con ese DNI.");

            var cadete = CadetesFactory.Crear(nombre, apellido, dni);
            _context.Cadetes.Add(cadete);
            _context.SaveChanges();
            return true;
        }

        public bool EliminarCadete(int dni)
        {
            var cadete = _context.Cadetes.FirstOrDefault(c => c.Dni == dni);
            if (cadete == null) return false;

            _context.Cadetes.Remove(cadete);
            _context.SaveChanges();
            return true;
        }

        public bool ModificarCadete(int dni, string nombre, string apellido)
        {
            var cadete = _context.Cadetes.FirstOrDefault(c => c.Dni == dni);
            if (cadete == null) return false;

            cadete.Nombre = string.IsNullOrWhiteSpace(nombre) ? cadete.Nombre : nombre;
            cadete.Apellido = string.IsNullOrWhiteSpace(apellido) ? cadete.Apellido : apellido;

            _context.SaveChanges();
            return true;
        }

    }
}
