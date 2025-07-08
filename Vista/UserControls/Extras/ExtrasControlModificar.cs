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
using Vista.AdminRestaurante.UserControls;

namespace Vista.UserControls.Extras
{
    public partial class ExtrasControlModificar : UserControl
    {
        #region Atributos

        private readonly PlatosControlDGV _dgv;
        private int _idRestaurante;
        private int _idAderezo;
        private readonly Controladora.Aderezos.ABMAderezos _ABMAderezos;

        #endregion

        #region Eventos Públicos

        public event EventHandler AderezoModificado;

        #endregion

        #region Constructor

        public ExtrasControlModificar(int idrestaurante, int idUsuario, PlatosControlDGV dgv)
        {
            InitializeComponent();
            _idRestaurante = idrestaurante;
            _dgv = dgv;

            _dgv.AderezoSelectionChanged += (s, e) =>
            {
                _idAderezo = _dgv.IdAderezoSeleccionado;
            };
            _ABMAderezos = new Controladora.Aderezos.ABMAderezos(idUsuario);
        }

        #endregion

        #region Eventos

        private void ExtrasControlModificar_Load(object sender, EventArgs e)
        {
            var mapa = new Dictionary<bool, string>
            {
                [true] = "Habilitado",
                [false] = "Deshabilitado"
            };

            cbEstado.DataSource = new BindingSource(mapa, null);
            cbEstado.DisplayMember = "Value";
            cbEstado.ValueMember = "Key";
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = txtNombre.Text.Trim();
                bool valorEstado = (bool)cbEstado.SelectedValue;
                decimal precio = decimal.Parse(txtPrecio.Text.Trim());

                bool operacionExitosa = _ABMAderezos.ModificarAderezo(_idAderezo, precio, valorEstado, nom);

                if (operacionExitosa)
                {
                    MessageBox.Show("Operación realizada exitosamente.");
                    AderezoModificado?.Invoke(this, EventArgs.Empty);
                    txtPrecio.Text = "0";
                }
            }
            catch
            {
                
            }
        }

        #endregion
    }
}
