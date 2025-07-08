using Modelo.Context;
using Servicios.DTOs;
using Servicios.Servicios.ServiciosExtras;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controladora.Reportes
{
    public class ControladoraReporte
    {
        private readonly ReporteService _reporteService;

        public ControladoraReporte()
        {
            var context = new EasyFoodFlowContext();
            _reporteService = new ReporteService(context);
        }

        public async Task<List<ReporteProductoDTO>> ObtenerTopProductos(DateTime inicio, DateTime fin, int topN, int idRestaurante)
        {
            try
            {
                return await _reporteService.ObtenerTopProductosVendidos(inicio, fin, topN, idRestaurante);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener los datos del reporte: " + ex.Message);
                return new List<ReporteProductoDTO>();
            }
        }

        public async Task ExportarTopProductosExcel(DateTime inicio, DateTime fin, int topN, int idRestaurante)
        {
            try
            {
                var excelStream = await _reporteService.GenerarExcelTopProductosVendidos(inicio, fin, topN, idRestaurante);

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Archivos Excel|*.xlsx";
                saveDialog.Title = "Guardar Reporte de Productos Vendidos";
                saveDialog.FileName = $"TopProductos_{DateTime.Now:yyyyMMdd}.xlsx";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var file = File.Create(saveDialog.FileName))
                    {
                        excelStream.CopyTo(file);
                    }
                    MessageBox.Show("Reporte exportado exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar el reporte: " + ex.Message);
            }
        }
    }
}