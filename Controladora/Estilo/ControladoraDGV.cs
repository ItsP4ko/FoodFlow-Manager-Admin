using DocumentFormat.OpenXml.InkML;
using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using Modelo.Models;
using Servicios.DTOs;
using Servicios.Services;
using Servicios.Servicios.DGVServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.DataGriedView
{
    public class ControladoraDGV
    {
        private readonly RestauranteService _restauranteService;
        private readonly RoleService _roleService;
        private readonly PermisoService _permisoService;
        private readonly UsuarioService _usuarioService;
        private readonly PlatoService _platoService;
        private readonly AderezoService _aderezoService;
        private readonly CategoriaService _categoriaService;
        private readonly PedidoService _pedidoService;
        private readonly CadeteService _cadeteService;

        public ControladoraDGV()
        {
            var context = new EasyFoodFlowContext();

            _restauranteService = new RestauranteService(context);
            _roleService = new RoleService(context);
            _permisoService = new PermisoService(context);
            _usuarioService = new UsuarioService(context);
            _platoService = new PlatoService(context);
            _aderezoService = new AderezoService(context);
            _categoriaService = new CategoriaService(context);
            _pedidoService = new PedidoService(context);
            _cadeteService = new CadeteService(context);
        }

        // ------------------------- RESTAURANTES -------------------------

        public List<RestauranteDTO> CargarRestaurantes() => _restauranteService.ObtenerTodos();
        public List<RestauranteDTO> CargarRestaurantesPorNombre(string nombre) => _restauranteService.BuscarPorNombre(nombre);

        // ------------------------- ROLES -------------------------

        public List<RoleDTO> CargarRoles() => _roleService.ObtenerTodos();
        public List<RoleDTO> BuscarRolesPorNombre(string nombre) => _roleService.BuscarPorNombre(nombre);

        // ------------------------- PERMISOS -------------------------

        public List<PermisoDTO> CargarPermisos() => _permisoService.ObtenerTodos();
        public List<PermisoDTO> BuscarPermisosPorNombre(string nombre) => _permisoService.BuscarPorNombre(nombre);
        public List<PermisoDTO> ObtenerPermisosDeRol(int idRol) => _permisoService.ObtenerPorRol(idRol);

        // ------------------------- USUARIOS -------------------------

        public List<UsuarioDTO> CargarUsuarios() => _usuarioService.ObtenerTodos();
        public List<UsuarioDTO> BuscarUsuariosPorNombre(string nombre) => _usuarioService.BuscarPorNombre(nombre);
        public List<UsuarioDTO> BuscarUsuariosPorRol(string rol) => _usuarioService.BuscarPorRol(rol);
        public List<UsuarioDTO> BuscarUsuariosPorMail(string mail) => _usuarioService.BuscarPorMail(mail);

        // ------------------------- PLATOS -------------------------

        public List<PlatoDTO> CargarPlatosPorRestaurante(int idRestaurante) => _platoService.ObtenerPorRestaurante(idRestaurante);
        public List<PlatoDTO> CargarPlatosPorRestauranteHabilitado(int idRestaurante) => _platoService.ObtenerPorRestauranteHabilitado(idRestaurante);
        public List<PlatoDTO> BuscarPlatosPorNombre(int idRestaurante, string nombre) => _platoService.BuscarPorNombre(idRestaurante, nombre);
        public List<PlatoDTO> BuscarPlatosPorCategoria(int idRestaurante, string categoriaNombre) => _platoService.BuscarPorNombreCategoria(idRestaurante, categoriaNombre);

        // ------------------------- CATEGORIAS -------------------------

        public List<CategoriaDTO> CargarCategoriasPorRestaurante(int idRestaurante) => _categoriaService.ObtenerPorRestaurante(idRestaurante);

        // ------------------------- ADEREZOS -------------------------

        public List<AderezoDTO> CargarAderezosPorRestaurante(int idRestaurante) => _aderezoService.ObtenerPorRestaurante(idRestaurante);
        public List<AderezoDTO> BuscarAderezosPorNombre(int idRestaurante, string aderezoNombre) => _aderezoService.BuscarPorNombre(idRestaurante, aderezoNombre);

        // ------------------------- PEDIDOS -------------------------

        public List<PedidoDTO> CargarPedidosPorRestaurante(int idRestaurante) => _pedidoService.ObtenerPorRestaurante(idRestaurante);
        public List<PedidoDTO> CargarPedidosPorEstado(int idRestaurante, string estado) => _pedidoService.ObtenerPorEstado(idRestaurante, estado);
        public List<PedidoDTO> CargarPedidosPorUsuario(int idRestaurante, int usuario) => _pedidoService.ObtenerPorUsuario(idRestaurante, usuario);
        public List<PedidoDTO> CargarPedidosPorEstadoYUsuario(int idRestaurante, string estado, int usuario) => _pedidoService.ObtenerPorEstadoYUsuario(idRestaurante, estado, usuario);
        public List<PedidoDTO> CargarPedidosPorId(int idRestaurante, int id) => _pedidoService.ObtenerPorId(idRestaurante, id);
        public List<PedidoDTO> CargarPedidosPorEstadoYIdPedido(int idRestaurante, string estado, int id) => _pedidoService.ObtenerPorEstadoYIdPedido(idRestaurante, estado, id);

        public List<LineaDTO> cargarLineaPorIDPedido(int idPedido) => _pedidoService.CargarLineaPorIDPedido(idPedido);

        // ------------------------- CADETES -------------------------

        public List<CadeteDTO> CargarCadetes() => _cadeteService.ObtenerTodos();
    }
}
