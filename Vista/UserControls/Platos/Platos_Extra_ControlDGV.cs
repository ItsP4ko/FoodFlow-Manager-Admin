using Controladora.DataGriedView;
using Modelo.Clases_Auxiliares;
using Modelo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.AdminRestaurante.UserControls
{
    public partial class PlatosControlDGV : UserControl
    {
        #region Atributos

        private readonly ControladoraDGV _controladoraDGV;
        private int _idRestaurante;

        #endregion

        #region Eventos Públicos

        public event EventHandler AderezoSelectionChanged;
        public event EventHandler PlatoSelectionChanged;

        #endregion

        #region Constructor

        public PlatosControlDGV(int IdRestaurante, int opcion)
        {
            InitializeComponent();
            _controladoraDGV = new ControladoraDGV();
            _idRestaurante = IdRestaurante;

            if (opcion == 1) // PLATOS
            {
                UpdateDataGrid(_controladoraDGV.CargarPlatosPorRestaurante(_idRestaurante));
                dgvPlatos.ClearSelection();
                dgvPlatos.CurrentCell = null;
                dgvPlatos.SelectionChanged += (s, e) =>
               PlatoSelectionChanged?.Invoke(this, EventArgs.Empty);
            }
            else if (opcion == 2) // ADEREZOS
            {
                UpdateDataGrid(_controladoraDGV.CargarAderezosPorRestaurante(_idRestaurante));
                dgvPlatos.ClearSelection();
                dgvPlatos.CurrentCell = null;
                dgvPlatos.SelectionChanged += (s, e) =>
                AderezoSelectionChanged?.Invoke(this, EventArgs.Empty);

            }
            else // OPCIÓN NO VÁLIDA
            {
                MessageBox.Show("Opción no válida para el control de DGV de Platos/Aderezos.");
                return;
            }

            dgvPlatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlatos.MultiSelect = false;

        }

        #endregion

        #region Métodos Privados

        private void UpdateDataGrid(object dataSource)
        {
            try
            {
                dgvPlatos.DataSource = null;
                dgvPlatos.DataSource = dataSource;
                
                dgvPlatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvPlatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

                dgvPlatos.ClearSelection();
                dgvPlatos.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando el DGV: " + ex.Message);
            }
        }

        #endregion

        #region Propiedades Públicas

        public int IdPlatoSeleccionado
        {
            get
            {
                if (dgvPlatos.SelectedRows.Count == 0) return 0;
                var celda = dgvPlatos.SelectedRows[0].Cells["IdPlato"].Value;
                return celda is int i ? i : Convert.ToInt32(celda);
            }
        }

        public int IdAderezoSeleccionado
        {
            get
            {
                if (dgvPlatos.SelectedRows.Count == 0) return 0;
                var celda = dgvPlatos.SelectedRows[0].Cells["IdAderezo"].Value;
                return celda is int i ? i : Convert.ToInt32(celda);
            }
        }

        #endregion

        #region Métodos Públicos

        public void InitializeComponentAdicionales(int id)
        {
            UpdateDataGrid(_controladoraDGV.CargarPlatosPorRestaurante(id));
        }

        public void CargarAderezos(int id)
        {
            UpdateDataGrid(_controladoraDGV.CargarAderezosPorRestaurante(id));
        }

        public void CargarAderezosPorNombre(int idestaurante, string aderezo)
        {
            UpdateDataGrid(_controladoraDGV.BuscarAderezosPorNombre(idestaurante, aderezo));
        }

        public void CargarPlatoPorNombre(int idestaurante, string plato)
        {
            UpdateDataGrid(_controladoraDGV.BuscarPlatosPorNombre(idestaurante, plato));
        }
        public void CargarPlatoPorCategoriaPorNombree(int idRestaurante, string categoria)
        {
            UpdateDataGrid(_controladoraDGV.BuscarPlatosPorCategoria(idRestaurante, categoria));
        }

        #endregion
    }
}
