using Microsoft.EntityFrameworkCore;
using Modelo.Context;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.UserControls
{
    public partial class reporteControl : UserControl
    {
        private readonly int _idRestaurante;
        private readonly Controladora.Reportes.ControladoraReporte _reporte;

        public reporteControl(int idRestaurante)
        {
            InitializeComponent();
            _idRestaurante = idRestaurante;
            _reporte = new Controladora.Reportes.ControladoraReporte();
        }

        private async void BtnGenerarReporte_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = DateTimePickerInicio.Value;
            DateTime fechaFin = DateTimePickerFin.Value;
            int topN = (int)NumericUpDownTopN.Value;
            int idRestaurante = _idRestaurante;

            if (idRestaurante <= 0)
            {
                MessageBox.Show("Por favor, selecciona un restaurante.", "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                await _reporte.ExportarTopProductosExcel(fechaInicio, fechaFin, topN, _idRestaurante); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte:\n{ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
