using Controladora.DataGriedView;
using Modelo.Models;
using Modelo.Clases_Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.Usuarios.CajeroRestaurante;
using Controladora.Categoria;
using Servicios.DTOs;

namespace Vista.UserControls.Pedidos
{
    public partial class CajeroPedidoAdd : UserControl
    {
        #region Atributos

        public readonly Controladora.Pedidos.ControladoraPedidos _controladoraPedidos;
        public readonly ControladoraDGV _controladoraDGV;
        public int _idRestaurante;
        private int _idLineaSeleccionada;
        public bool _btnEliminar;
        private readonly List<(int IdPlato, List<(int IdAderezo, int Cantidad)> Extras)> _lineasPedido;
        private List<Aderezo> _todosLosAderezos;
        private BindingList<ExtraGridItem> _bindingExtras;
        private readonly List<Plato> _todosLosPlatos;
        private readonly ControladoraCategoria _controladoraCategoria;

        #endregion

        #region Constructor

        public CajeroPedidoAdd(int idRestaurante, bool btnEliminar, int idUsuario)
        {
            InitializeComponent();
            _idRestaurante = idRestaurante;
            _btnEliminar = btnEliminar;
            _controladoraDGV = new ControladoraDGV();
            _controladoraPedidos = new Controladora.Pedidos.ControladoraPedidos(idUsuario);
            _lineasPedido = new List<(int, List<(int, int)>)>();
            _todosLosPlatos = _controladoraDGV
                .CargarPlatosPorRestaurante(idRestaurante)
                .OfType<Plato>()
                .ToList();
            _controladoraCategoria = new ControladoraCategoria(idUsuario);
        }

        #endregion

        #region Eventos de Carga

        private void UserPedidoAdd_Load(object sender, EventArgs e)
        {
            CargarExtrasGrid();
            var listaCategorias = _controladoraCategoria
            .CargarCategoriasPorRestaurante(_idRestaurante)
            .OfType<CategoriaDTO>()
            .ToList();


            listaCategorias.Insert(0, new CategoriaDTO
            {
                IdCategoria = 0,
                Nombre = "Todos"

            });


            cbCategoria.DataSource = listaCategorias;
            cbCategoria.DisplayMember = "Nombre";
            cbCategoria.ValueMember = "IdCategoria";
            cbCategoria.SelectedIndex = 0;
        }

        #endregion

        #region Métodos - Platos

        private void RefrescarGrillasPlato()
        {
            var listaFiltradaPlatos = _controladoraDGV.CargarPlatosPorRestauranteHabilitado(_idRestaurante);
            dgvPlatos.DataSource = null;
            dgvPlatos.DataSource = listaFiltradaPlatos;


            dgvPlatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPlatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            dgvPlatos.ClearSelection();
            dgvPlatos.CurrentCell = null;
        }

        private void RefrescarGrillasPlatoPorPlato(int id, string nombre)
        {
            dgvPlatos.DataSource = null;
            dgvPlatos.DataSource = _controladoraDGV.BuscarPlatosPorNombre(id, nombre);

        }

        #endregion

        #region Métodos - Extras

        private void CargarExtrasGrid()
        {
            _todosLosAderezos = _controladoraPedidos
                .ObtenerTodosLosAderezosDelRestaurante(_idRestaurante)
                .ToList();

            _bindingExtras = new BindingList<ExtraGridItem>(
                _todosLosAderezos
                 .Select(a => new ExtraGridItem
                 {
                     IdAderezo = a.IdAderezo,
                     Aderezo = a,
                     Cantidad = 1,
                     Precio = a.Precio,
                     Seleccionado = false
                 })
                 .ToList()
            );

            dgvExtras.AutoGenerateColumns = false;
            dgvExtras.Columns.Clear();

            dgvExtras.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "colExtra",
                HeaderText = "Extra",
                DataPropertyName = "IdAderezo",
                DataSource = _todosLosAderezos,
                DisplayMember = "Nombre",
                ValueMember = "IdAderezo",
                Width = 150
            });
            dgvExtras.Columns.Add(new DataGridViewComboBoxColumn
            {
                Name = "colCantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad",
                DataSource = Enumerable.Range(1, 10).ToList()
            });
            dgvExtras.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrecio",
                HeaderText = "Precio",
                DataPropertyName = "Precio",
                ReadOnly = true
            });
            dgvExtras.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "colSeleccionar",
                HeaderText = "Seleccionar",
                DataPropertyName = "Seleccionado"
            });

            dgvExtras.DataSource = _bindingExtras;
            dgvExtras.CellValueChanged += DgvExtras_CellValueChanged;
            dgvExtras.CurrentCellDirtyStateChanged += (s, e) =>
            {
                if (dgvExtras.IsCurrentCellDirty)
                    dgvExtras.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }

        private void DgvExtras_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = _bindingExtras[e.RowIndex];
            var extra = _todosLosAderezos
                .First(a => a.IdAderezo == fila.IdAderezo);
            fila.Precio = extra.Precio * fila.Cantidad;
            dgvExtras.InvalidateRow(e.RowIndex);
        }

        #endregion

        #region Métodos - Pedido

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPlatos.CurrentRow is null)
                    return;

                // Obtengo el valor de la columna "IdPlato" en la fila seleccionada
                int idPlato = Convert.ToInt32(dgvPlatos.CurrentRow.Cells["IdPlato"].Value);

                var seleccionados = _bindingExtras
                    .Where(r => r.Seleccionado)
                    .Select(r => (r.IdAderezo, r.Cantidad))
                    .ToList();

                _lineasPedido.Add((idPlato, seleccionados));
                RefrescarGrillaLineas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al asociar el plato: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void RefrescarGrillaLineas()
        {
            var lineas = _lineasPedido.Select((lineaPedido, idx) =>
            {
                int idPlato = lineaPedido.IdPlato;
                var plato = _todosLosPlatos.First(p => p.IdPlato == idPlato);

                var extrasInfo = lineaPedido.Extras
                    .Select(e =>
                    {
                        var ad = _todosLosAderezos.First(a => a.IdAderezo == e.IdAderezo);
                        return (ad, e.Cantidad);
                    })
                    .ToList();

                string parteExtras = extrasInfo.Count == 0
                    ? ""
                    : " + " + string.Join(" + ", extrasInfo.Select(x => $"{x.ad.Nombre} x{x.Cantidad}"));


                decimal precioExtras = extrasInfo.Sum(x => x.ad.Precio * x.Cantidad);

                return new
                {
                    Linea = idx + 1,
                    IdPlato = plato.IdPlato,
                    Descripción = plato.Nombre + parteExtras,
                    Precio = plato.Precio + precioExtras
                };
            })
            .ToList();

            dgvPedido.DataSource = lineas;
        }

        private void btnVerPedido_Click(object sender, EventArgs e)
        {
            RefrescarGrillaLineas();
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtDni.Text, out var dniCliente))
            {
                MessageBox.Show("DNI inválido");
                return;
            }
            string direccion = txtDireccion.Text.Trim();

            var (ok, msg, total) = _controladoraPedidos.CrearPedidoConExtras(dniCliente, _idRestaurante, direccion, _lineasPedido);

            MessageBox.Show(msg, ok ? "Éxito" : "Error", MessageBoxButtons.OK, ok ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (ok)
            {
                _lineasPedido.Clear();
                RefrescarGrillasPlato();
                RefrescarGrillaLineas();
                CargarExtrasGrid();

                Vuelto vuelto = new Vuelto(total);
                vuelto.Show();
            }
        }

        private void btnElimLinea_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPedido.CurrentRow == null)
                {
                    MessageBox.Show("Seleccione una línea para eliminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int lineaSeleccionada = Convert.ToInt32(dgvPedido.CurrentRow.Cells["Linea"].Value) - 1;

                if (lineaSeleccionada >= 0 && lineaSeleccionada < _lineasPedido.Count)
                {
                    _lineasPedido.RemoveAt(lineaSeleccionada);

                    MessageBox.Show("Línea eliminada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefrescarGrillaLineas();
                }
                else
                {
                    MessageBox.Show("Error al eliminar la línea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Error al eliminar la línea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Eventos

        private void txtPlato_TextChanged(object sender, EventArgs e)
        {
            RefrescarGrillasPlatoPorPlato(_idRestaurante, txtPlato.Text);
        }

        private void btnVerPlatos_Click(object sender, EventArgs e)
        {
            RefrescarGrillasPlato();
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int idCat = (int)cbCategoria.SelectedValue;

                if (idCat == 0)
                {

                    RefrescarGrillasPlato();
                }
                else
                {

                    var cat = (CategoriaDTO)cbCategoria.SelectedItem;
                    string nombreCat = cat.Nombre;

                    var listaFiltrada = _controladoraDGV
                        .BuscarPlatosPorCategoria(_idRestaurante, nombreCat);

                    dgvPlatos.DataSource = null;
                    dgvPlatos.DataSource = listaFiltrada;
                    dgvPlatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvPlatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvPlatos.ClearSelection();
                    dgvPlatos.CurrentCell = null;
                }
            }
            catch (Exception ex)
            {  }
        }
        #endregion
    }
}
