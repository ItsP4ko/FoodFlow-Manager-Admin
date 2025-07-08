using Controladora.Pedidos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Usuarios.AdminCocina
{
    public partial class PedidosAdminCocina : Form
    {
        private int _idRestaurante;
        private readonly Controladora.DataGriedView.ControladoraDGV _controladoraDGV;
        private readonly ControladoraPedidos _controladoraPedidos;

        private readonly List<string> _estadosPermitidos = new()
{
    "En Preparacion",
    "Listo para entregar",
    "Listo para retiro en local"
};

        public PedidosAdminCocina(int idUsuario, int idRestaurante)
        {
            InitializeComponent();
            _idRestaurante = idRestaurante;
            _controladoraDGV = new Controladora.DataGriedView.ControladoraDGV();
            _controladoraPedidos = new ControladoraPedidos(idUsuario);
        }

        private void LoadPedidos()
        {
            DGVPedidosAdminCocina.Columns.Clear();
            DGVPedidosAdminCocina.AutoGenerateColumns = true;
            DGVPedidosAdminCocina.DataSource =
               _controladoraDGV.CargarPedidosPorEstado(_idRestaurante, "En Preparacion");

            
            InicializarComboEstado();

            
            DGVPedidosAdminCocina.Columns["EstadoCombo"].DisplayIndex = 0;
        }

        private void LoadPedidosAtributoExtra(object atributo)
        {
            DGVPedidosAdminCocina.Columns.Clear();
            DGVPedidosAdminCocina.AutoGenerateColumns = true;
            DGVPedidosAdminCocina.DataSource = atributo;
               


            InicializarComboEstado();


            DGVPedidosAdminCocina.Columns["EstadoCombo"].DisplayIndex = 0;
        }
        private void LoadLineas(int idPedido)
        {
            DGVPedidosAdminCocina.Columns.Clear();
            DGVPedidosAdminCocina.AutoGenerateColumns = true;
            DGVPedidosAdminCocina.DataSource =
               _controladoraDGV.cargarLineaPorIDPedido(idPedido); 
        }

        private void InicializarComboEstado()
        {
            if (DGVPedidosAdminCocina.Columns.Contains("EstadoCombo"))
                return;

            var combo = new DataGridViewComboBoxColumn
            {
                HeaderText = "Estado",
                Name = "EstadoCombo",
                DataPropertyName = "Estado",
                DataSource = _estadosPermitidos,
                DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = false,
                DefaultCellStyle = new DataGridViewCellStyle { NullValue = "En Preparacion" }
            };

            DGVPedidosAdminCocina.Columns.Insert(0, combo);
            DGVPedidosAdminCocina.AutoResizeColumn(
                combo.Index,
                DataGridViewAutoSizeColumnMode.AllCells);
        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PedidosAdminCocina_Load(object sender, EventArgs e)
        {
            DGVPedidosAdminCocina.EditMode = DataGridViewEditMode.EditOnEnter;
            DGVPedidosAdminCocina.CellClick += DGVPedidosAdminCocina_CellClick;
            LoadPedidos();

        }

        private void btnEntrarDGV_Click(object sender, EventArgs e)
        {
            try
            {
                if (DGVPedidosAdminCocina.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccioná primero un pedido.");
                    return;
                }
                int idPedido = Convert.ToInt32(
                    DGVPedidosAdminCocina.SelectedRows[0].Cells["IdPedido"].Value);

                LoadLineas(idPedido);

            }
            catch
            {
                MessageBox.Show("Error al cargar las lineas del pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnVolverDGV_Click(object sender, EventArgs e)
        {
            LoadPedidos();
             
        }

        private void DGVPedidosAdminCocina_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                var col = DGVPedidosAdminCocina.Columns[e.ColumnIndex];
                if (col.Name != "EstadoCombo") return;

                // Empiezo edición en esa celda
                DGVPedidosAdminCocina.CurrentCell =
                    DGVPedidosAdminCocina.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DGVPedidosAdminCocina.BeginEdit(true);

                // Si el control en edición es el ComboBox, lo abro
                if (DGVPedidosAdminCocina.EditingControl
                        is DataGridViewComboBoxEditingControl combo)
                {
                    combo.DroppedDown = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                var errores = new List<int>();
                foreach (DataGridViewRow row in DGVPedidosAdminCocina.Rows)
                {
                    if (row.IsNewRow) continue; // Siempre ignorar la fila nueva

                    // Obtener el nuevo estado del combobox primero
                    string nuevoEstado = Convert.ToString(row.Cells["EstadoCombo"].Value);

                    
                    if (nuevoEstado == "En Preparacion")
                    {
                        continue;
                    }

                   
                    int idPedido = Convert.ToInt32(row.Cells["IdPedido"].Value);

                    bool ok = _controladoraPedidos.ActualizarEstadoPedido(idPedido, nuevoEstado);
                    if (!ok)
                    {
                        errores.Add(idPedido);
                    }
                }

                if (errores.Count == 0)
                {
                    MessageBox.Show("Todos los estados se actualizaron correctamente.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(
                      $"Falló la actualización de los pedidos: {string.Join(", ", errores)}",
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Recarga la grilla
                LoadPedidos();
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error al actualizar los estados de los pedidos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripTxtUsuario_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPedidosAtributoExtra(_controladoraDGV.CargarPedidosPorEstadoYUsuario(_idRestaurante, "En Preparacion", int.Parse(toolStripTxtUsuario.Text)));
            }
            catch
            {
                MessageBox.Show("Error al cargar los pedidos por usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripTxtIdPedido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadPedidosAtributoExtra(_controladoraDGV.CargarPedidosPorEstadoYIdPedido(_idRestaurante, "En Preparacion", int.Parse(toolStripTxtIdPedido.Text)));
            }
            catch
            {
                MessageBox.Show("Error al cargar los pedidos por usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
