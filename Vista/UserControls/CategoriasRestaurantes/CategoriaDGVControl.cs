using Controladora.DataGriedView;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.UserControls.CategoriasRestaurantes
{
    public partial class CategoriaDGVControl : UserControl
    {
        private int _idRestaurante;
        private readonly ControladoraDGV _controladoraDGV;
        public event EventHandler IdCategoriaSeleccionado;
        public CategoriaDGVControl(int IdRestaurante)
        {
            InitializeComponent();  
            _idRestaurante = IdRestaurante;
            _controladoraDGV = new ControladoraDGV();
            UpdateDataGrid(_controladoraDGV.CargarCategoriasPorRestaurante(_idRestaurante));
        }

        private void UpdateDataGrid(object dataSource)
        {
            try
            {
                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = dataSource;
                dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvCategorias.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando el DGV: " + ex.Message);
            }
        }

        public int IdCategoria
        {
            get
            {
                if (dgvCategorias.SelectedRows.Count == 0) return 0;
                var celda = dgvCategorias.SelectedRows[0].Cells["IdCategoria"].Value;
                return celda is int i ? i : Convert.ToInt32(celda);
            }
        }

        public void InitializeComponentCategorias(int id)
        {
            UpdateDataGrid(_controladoraDGV.CargarCategoriasPorRestaurante(id));
        }
    }
}
