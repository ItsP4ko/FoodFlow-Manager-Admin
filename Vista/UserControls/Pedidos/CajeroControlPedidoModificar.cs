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

namespace Vista.UserControls.Pedidos
{
    public partial class CajeroControlPedidoModificar : UserControl
    {
        #region Atributos

        public readonly Controladora.Pedidos.ControladoraPedidos _controladoraPedidos;
        public readonly ControladoraDGV _controladoraDGV;
        public int _idRestaurante;
        private int _idPedidoSeleccionado;
        private int _idLineaSeleccionada;
        public bool _btnEliminar;
        private readonly List<(int IdPlato, List<(int IdAderezo, int Cantidad)> Extras)> _lineasPedido;
        private List<Aderezo> _todosLosAderezos;
        private BindingList<ExtraGridItem> _bindingExtras;
        private readonly List<Plato> _todosLosPlatos;

        #endregion

        #region Constructor

        public CajeroControlPedidoModificar(int idRestaurante, int idUsuario, bool opcion)
        {
            InitializeComponent();
            _idRestaurante = idRestaurante;
            _btnEliminar = opcion;
            _controladoraDGV = new ControladoraDGV();
            _controladoraPedidos = new Controladora.Pedidos.ControladoraPedidos(idUsuario);
            _lineasPedido = new List<(int, List<(int, int)>)>();
            _todosLosPlatos = _controladoraDGV
                .CargarPlatosPorRestaurante(idRestaurante)
                .OfType<Plato>()
                .ToList();
        }

        #endregion

        #region Eventos de Carga

        private void CajeroControlPedidoModificar_Load(object sender, EventArgs e)
        {
            LoadPedidos();
        }

        #endregion

        #region Métodos de Carga

        private void LoadPedidos()
        {
            dgvPedido.Columns.Clear();
            dgvPedido.AutoGenerateColumns = true;
            dgvPedido.DataSource = _controladoraDGV.CargarPedidosPorRestaurante(_idRestaurante);
        }

        public void LoadLineasPedido(int idPedido)
        {
            dgvLineas.Columns.Clear();
            dgvLineas.AutoGenerateColumns = true;
            dgvLineas.DataSource = _controladoraDGV.cargarLineaPorIDPedido(idPedido);
        }

        private void LoadPedidosAtributoExtra(object atributo)
        {
            dgvPedido.Columns.Clear();
            dgvPedido.AutoGenerateColumns = true;
            dgvPedido.DataSource = atributo;
        }

        #endregion

        #region Eventos de Interacción con DGV

        private void dgvPedido_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // 1. Verificar si la fila actual es válida
                if (dgvPedido.CurrentRow == null)
                {
                    MessageBox.Show("No hay ninguna fila seleccionada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Salir del método
                }

                object valorCelda = dgvPedido.CurrentRow.Cells["IdPedido"].Value;

                if (valorCelda != null && valorCelda != DBNull.Value)
                {
                    _idPedidoSeleccionado = Convert.ToInt32(valorCelda);
                    LoadLineasPedido(_idPedidoSeleccionado);
                }
                else
                {
                    MessageBox.Show("El IdPedido de la fila seleccionada no es válido o está vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException fex)
            {
                // Se produce si el valor de la celda no se puede convertir a un entero (ej. texto no numérico)
                MessageBox.Show($"Error de formato al seleccionar el pedido. Asegúrate de que el ID sea un número: {fex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidCastException icex)
            {
               
                MessageBox.Show($"Error de conversión al seleccionar el pedido. Tipo de dato inesperado: {icex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException nrex)
            {
               
                MessageBox.Show($"Error de referencia nula. La columna 'IdPedido' podría no existir o no hay fila seleccionada: {nrex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción inesperada
                MessageBox.Show($"Ocurrió un error inesperado al seleccionar el pedido: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvLineas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _idLineaSeleccionada = (int)dgvLineas.CurrentRow.Cells["IdPedidoPlato"].Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la línea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Botones de Acción

        private void btnEliminarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = _controladoraPedidos.EliminarPedido(_idPedidoSeleccionado);
                if (ok)
                {
                    MessageBox.Show("Pedido eliminado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPedidos();
                    dgvLineas.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Error al eliminar el pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el pedido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLineaEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                bool ok = _controladoraPedidos.EliminarLineaPedido(_idLineaSeleccionada);
                if (ok)
                {
                    MessageBox.Show("Línea eliminada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLineasPedido(_idPedidoSeleccionado);
                    LoadPedidos();
                    dgvLineas.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Error al eliminar la línea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la línea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Filtros por Texto

        private void txtDni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDni.Text))
                {
                    LoadPedidos();
                    return;
                }
                LoadPedidosAtributoExtra(_controladoraDGV.CargarPedidosPorUsuario(_idRestaurante, int.Parse(txtDni.Text)));
            }
            catch
            {
                
            }
        }

        private void txtPlato_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtIdPedido.Text))
                {
                    LoadPedidos();
                    return;
                }
                LoadPedidosAtributoExtra(_controladoraDGV.CargarPedidosPorId(_idRestaurante, int.Parse(txtIdPedido.Text)));
            }
            catch
            {
                
            }
        }

        #endregion
    }
}
