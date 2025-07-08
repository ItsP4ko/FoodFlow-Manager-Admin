using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using Servicios.DTOs;

public class PedidoService
{
    private readonly EasyFoodFlowContext _context;

    public PedidoService(EasyFoodFlowContext context)
    {
        _context = context;
    }

    public List<PedidoDTO> ObtenerPorRestaurante(int idRestaurante)
    {
        return _context.Pedidos
            .Where(p => p.IdRestaurante == idRestaurante)
            .Select(p => new PedidoDTO
            {
                IdPedido = p.IdPedido,
                DniCliente = p.DniCliente,
                Total = p.Total,
                DireccionEntrega = p.DireccionEntrega
            }).ToList();
    }

    public List<PedidoDTO> ObtenerPorEstado(int idRestaurante, string estado)
    {
        return _context.Pedidos
            .Where(p => p.IdRestaurante == idRestaurante && p.Estado == estado)
            .Select(p => new PedidoDTO
            {
                IdPedido = p.IdPedido,
                DniCliente = p.DniCliente,
                Total = p.Total,
                DireccionEntrega = p.DireccionEntrega
            }).ToList();
    }

    public List<PedidoDTO> ObtenerPorUsuario(int idRestaurante, int usuario)
    {
        return _context.Pedidos
            .Where(p => p.IdRestaurante == idRestaurante && p.DniCliente.ToString().StartsWith(usuario.ToString()))
            .Select(p => new PedidoDTO
            {
                IdPedido = p.IdPedido,
                DniCliente = p.DniCliente,
                Total = p.Total,
                DireccionEntrega = p.DireccionEntrega
            }).ToList();
    }

    public List<PedidoDTO> ObtenerPorEstadoYUsuario(int idRestaurante, string estado, int usuario)
    {
        return _context.Pedidos
            .Where(p => p.IdRestaurante == idRestaurante && p.Estado == estado && p.DniCliente.ToString().StartsWith(usuario.ToString()))
            .Select(p => new PedidoDTO
            {
                IdPedido = p.IdPedido,
                DniCliente = p.DniCliente,
                Total = p.Total,
                DireccionEntrega = p.DireccionEntrega
            }).ToList();
    }

    public List<PedidoDTO> ObtenerPorEstadoYIdPedido(int idRestaurante, string estado, int id)
    {
        return _context.Pedidos
            .Where(p => p.IdRestaurante == idRestaurante && p.Estado == estado && p.IdPedido.ToString().Contains(id.ToString()))
            .Select(p => new PedidoDTO
            {
                IdPedido = p.IdPedido,
                DniCliente = p.DniCliente,
                Total = p.Total,
                DireccionEntrega = p.DireccionEntrega
            }).ToList();
    }

    public List<PedidoDTO> ObtenerPorId(int idRestaurante, int id)
    {
        return _context.Pedidos
            .Where(p => p.IdRestaurante == idRestaurante && p.IdPedido == id)
            .Select(p => new PedidoDTO
            {
                IdPedido = p.IdPedido,
                DniCliente = p.DniCliente,
                Total = p.Total,
                DireccionEntrega = p.DireccionEntrega
            }).ToList();
    }

    public List<LineaDTO> CargarLineaPorIDPedido(int idPedido)
    {
        return _context.PedidoPlatos
            .Include(pp => pp.IdPlatoNavigation)
            .Include(pp => pp.AderezoPedidoPlatos)
                .ThenInclude(ap => ap.IdAderezoNavigation)
            .Where(pp => pp.IdPedido == idPedido)
            .OrderBy(pp => pp.IdPedidoPlato)
            .Select(linea => new LineaDTO
            {
                IdPedidoPlato = linea.IdPedidoPlato,
                Cantidad = linea.Cantidad,
                PrecioMomento = linea.PrecioMomento,
                Observaciones = linea.Observaciones,
                NombrePlato = linea.IdPlatoNavigation.Nombre,
                DescripcionPlato = linea.IdPlatoNavigation.Descripcion,
                Aderezos = linea.AderezoPedidoPlatos.Select(ap => new AderezoLineaDTO
                {
                    IdAderezoPedidoPlato = ap.IdAderezoPedidoPlato,
                    NombreAderezo = ap.IdAderezoNavigation.Nombre,
                    Cantidad = ap.Cantidad,
                    PrecioMomento = ap.PrecioMomento
                }).ToList(),
                TotalLinea = (linea.PrecioMomento * linea.Cantidad) +
                            linea.AderezoPedidoPlatos.Sum(ap => ap.PrecioMomento * ap.Cantidad)
            }).ToList();
    }

}
