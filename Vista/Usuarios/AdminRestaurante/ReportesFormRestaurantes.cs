using Controladora.Estilo;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.UserControls;
using Vista.UserControls.LogIn;

namespace Vista.Usuarios.AdminRestaurante
{
    public partial class ReportesFormRestaurantes : Form
    {
        private int _idRestaurante;
        private readonly Panel_UserControl_Estilos _panelEstilos;
        public ReportesFormRestaurantes(int idRestaurante)
        {
            InitializeComponent();
            _idRestaurante = idRestaurante;
            _panelEstilos = new Panel_UserControl_Estilos();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_panelEstilos.YaEstaMostrado<reporteControl>(panel)) return;
            panel.Controls.Clear();

            var reporteProductos = new reporteControl(_idRestaurante);
            _panelEstilos.MostrarCentrado(panel, reporteProductos);
        }
    }
}
