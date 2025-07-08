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

namespace Vista.UserControls.Pedidos
{
    public partial class PedidosUserControlAdminR : UserControl
    {
        private int _idRestaurante;
        private string _texto;
        private readonly Controladora.DataGriedView.ControladoraDGV _controladoraDGV;
        private readonly ControladoraPedidos _controladoraPedidos;
        public PedidosUserControlAdminR(int idRestaurante, int idUsuario)
        {
            InitializeComponent();
            _idRestaurante = idRestaurante;
            _controladoraDGV = new Controladora.DataGriedView.ControladoraDGV();
            _controladoraPedidos = new ControladoraPedidos(idUsuario);

        }

        private void LoadPedidos()
        {
            dgvPedidos.Columns.Clear();
            dgvPedidos.AutoGenerateColumns = true;
            dgvPedidos.DataSource =
               _controladoraDGV.CargarPedidosPorRestaurante(_idRestaurante);

        }

        private void LoadPedidosBusqueda(object atributo)
        {
            dgvPedidos.Columns.Clear();
            dgvPedidos.AutoGenerateColumns = true;
            dgvPedidos.DataSource = atributo;
        }

        private void LoadLineas(int idPedido)
        {
            dgvPedidos.Columns.Clear();
            dgvPedidos.AutoGenerateColumns = true;
            dgvPedidos.DataSource =
               _controladoraDGV.cargarLineaPorIDPedido(idPedido);
        }

        private void PedidosUserControlAdminR_Load(object sender, EventArgs e)
        {
            LoadPedidos();
        }

        private void dgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // capaz eliminar
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (dgvPedidos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná primero un pedido.");
                return;
            }
            int idPedido = Convert.ToInt32(
                dgvPedidos.SelectedRows[0].Cells["IdPedido"].Value);

            LoadLineas(idPedido);
        }

        private void btnVollver_Click(object sender, EventArgs e)
        {
            LoadPedidos();
        }

        private void txtBuscraDni_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int dni = int.Parse(txtBuscraDni.Text);
                LoadPedidosBusqueda(
               _controladoraDGV.CargarPedidosPorUsuario(_idRestaurante, dni));
            }
            catch
            {

            }
        }

        private void txtBuscarId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtBuscarId.Text);
                LoadPedidosBusqueda(
               _controladoraDGV.CargarPedidosPorId(_idRestaurante, id));
            }
            catch
            {

            }
        }
    }
}
