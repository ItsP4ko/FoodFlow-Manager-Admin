using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using Servicios.DTOs;


namespace Servicios.Servicios.ServiciosExtras
{
    public class ReporteService
    {
        private readonly EasyFoodFlowContext _context;

        public ReporteService(EasyFoodFlowContext context)
        {
            _context = context;
        }

        public async Task<List<ReporteProductoDTO>> ObtenerTopProductosVendidos(DateTime fechaInicio, DateTime fechaFin, int topN, int idRestaurante)
        {
            fechaFin = fechaFin.Date.AddDays(1).AddTicks(-1);

            var topProductos = await _context.PedidoPlatos
                .Include(pp => pp.Plato)
                .Include(pp => pp.Pedido).ThenInclude(p => p.Tiempos)
                .Where(pp => pp.Pedido.IdRestaurante == idRestaurante)
                .Where(pp => pp.Pedido.Tiempos.Any())
                .Where(pp =>
                    pp.Pedido.Tiempos.Min(t => t.Inicio) >= fechaInicio &&
                    pp.Pedido.Tiempos.Min(t => t.Fin) <= fechaFin)
                .GroupBy(pp => new { pp.IdPlato, pp.Plato.Nombre, pp.Plato.Precio })
                .Select(g => new ReporteProductoDTO
                {
                    NombrePlato = g.Key.Nombre,
                    CantidadVendida = g.Count(),
                    PrecioUnitario = g.Key.Precio,
                    Total = g.Count() * g.Key.Precio
                })
                .OrderByDescending(x => x.CantidadVendida)
                .Take(topN)
                .ToListAsync();

            return topProductos;
        }

        public async Task<MemoryStream> GenerarExcelTopProductosVendidos(DateTime fechaInicio, DateTime fechaFin, int topN, int idRestaurante)
        {
            var productos = await ObtenerTopProductosVendidos(fechaInicio, fechaFin, topN, idRestaurante);

            var stream = new MemoryStream();
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Top Productos");

                if (!productos.Any())
                {
                    ws.Cell(1, 1).Value = "No se encontraron productos vendidos en ese rango.";
                }
                else
                {
                    ws.Cell(1, 1).Value = "Nombre Producto";
                    ws.Cell(1, 2).Value = "Cantidad Vendida";
                    ws.Cell(1, 3).Value = "Precio Unitario";
                    ws.Cell(1, 4).Value = "Total";

                    var headerRange = ws.Range("A1:D1");
                    headerRange.Style.Font.Bold = true;
                    headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                    headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    int fila = 2;
                    foreach (var p in productos)
                    {
                        ws.Cell(fila, 1).Value = p.NombrePlato;
                        ws.Cell(fila, 2).Value = p.CantidadVendida;
                        ws.Cell(fila, 3).Value = p.PrecioUnitario;
                        ws.Cell(fila, 4).Value = p.Total;
                        fila++;
                    }
                    ws.Columns().AdjustToContents();
                }

                workbook.SaveAs(stream);
            }

            stream.Position = 0;
            return stream;
        }
    }
}