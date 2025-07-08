using Controladora.Platos;
using Modelo.Estado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.UserControls.Extras
{
    public partial class ExtrasControlAgregar : UserControl
    {
        #region Atributos

        private int _idRestaurante;
        private readonly Controladora.Aderezos.ABMAderezos _ABMAderezos;

        #endregion

        #region Eventos Públicos

        public event EventHandler AderezoAgregado;

        #endregion

        #region Constructor

        public ExtrasControlAgregar(int idRestaurante, int idUsuario)
        {
            InitializeComponent();
            _idRestaurante = idRestaurante;
            _ABMAderezos = new Controladora.Aderezos.ABMAderezos(idUsuario);
        }

        #endregion

        #region Eventos

        private void ExtrasControlAgregar_Load(object sender, EventArgs e)
        {
            var estados = new List<EstadoItem>
            {
                new EstadoItem("Habilitado", true),
                new EstadoItem("Deshabilitado", false)
            };

            cbEstado.DataSource = estados;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;

                var estadoSeleccionado = (EstadoItem)cbEstado.SelectedItem;
                bool valorEstado = estadoSeleccionado.Valor;

                decimal precio = decimal.Parse(txtPrecio.Text);

                bool operacionExitosa = _ABMAderezos.AgregarAderezo(nombre, valorEstado, precio, _idRestaurante);

                if (operacionExitosa)
                {
                    MessageBox.Show("Operación realizada exitosamente.");
                    AderezoAgregado?.Invoke(this, EventArgs.Empty);
                }
            }
            catch
            {
            }
        }

        #endregion
    }
}
