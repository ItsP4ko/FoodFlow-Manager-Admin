using Controladora.Categoria;
using Controladora.DataGriedView;
using Controladora.Platos;
using DocumentFormat.OpenXml.Wordprocessing;
using Modelo.Estado;
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

namespace Vista.AdminRestaurante.UserControls.Platos
{
    public partial class PlatosControlAdd : UserControl
    {
        #region Atributos

        private int _idRestaurante;
        private readonly ABMPlatos _ABMPlatos;
        private readonly ControladoraCategoria _ControladoraCategoria;

        #endregion

        #region Eventos Públicos

        public event EventHandler PlatoAgregado;

        #endregion

        #region Constructor

        public PlatosControlAdd(int idrestaurante, int idUsuario)
        {
            InitializeComponent();
            _idRestaurante = idrestaurante;
            _ABMPlatos = new ABMPlatos(idUsuario);
            _ControladoraCategoria = new ControladoraCategoria(idUsuario);
        }

        #endregion

        #region Eventos

        private void PlatosControlAdd_Load(object sender, EventArgs e)
        {
            var estados = new List<EstadoItem>
            {
                new EstadoItem("Habilitado", true),
                new EstadoItem("Deshabilitado", false)
            };

            cbEstado.DataSource = estados;
            var listaCategorias = _ControladoraCategoria.CargarCategoriasPorRestaurante(_idRestaurante);
            cbCategoria.DataSource = listaCategorias;
            cbCategoria.DisplayMember = "Nombre";      
            cbCategoria.ValueMember = "IdCategoria";
            cbCategoria.SelectedIndex = -1;         
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            var estadoSeleccionado = (EstadoItem)cbEstado.SelectedItem;
            bool valorEstado = estadoSeleccionado.Valor;
            int categoria =  (int)cbCategoria.SelectedValue;

            decimal precio = decimal.Parse(txtPrecio.Text);

            bool operacionExitosa = _ABMPlatos.AgregarPlato(nombre, valorEstado, precio, _idRestaurante, categoria);

            if (operacionExitosa)
            {
                MessageBox.Show("Operación realizada exitosamente.");
                PlatoAgregado?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}
