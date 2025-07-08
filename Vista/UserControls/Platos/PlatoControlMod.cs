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
using Vista.AdminRestaurante.UserControls;

namespace Vista.UserControls.Platos
{
    public partial class PlatoControlMod : UserControl
    {
        #region Atributos

        private readonly PlatosControlDGV _dgv;
        private int _idRestaurante;
        private int _idPlato;
        private readonly ABMPlatos _ABMPlatos;

        #endregion

        #region Eventos Públicos

        public event EventHandler PlatoModificado;

        #endregion

        #region Constructor

        public PlatoControlMod(int idrestaurante, int idUsuario, PlatosControlDGV dgv)
        {
            InitializeComponent();
            _idRestaurante = idrestaurante;
            _ABMPlatos = new ABMPlatos(idUsuario);
            _dgv = dgv;

            _dgv.PlatoSelectionChanged += (s, e) =>
            {
                _idPlato = _dgv.IdPlatoSeleccionado;
            };
        }

        #endregion

        #region Eventos

        private void PlatoControlMod_Load(object sender, EventArgs e)
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
                if (_idPlato <= 0)
                {
                    MessageBox.Show("No se ha seleccionado un plato válido para modificar.",
                                    "Atención",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                bool valorEstado = (bool)cbEstado.SelectedValue;

                bool operacionExitosa = _ABMPlatos.ModificarPlato(
                    idPlato: _idPlato,
                    estado: valorEstado,
                    idRestaurante: _idRestaurante
                    );

                if (operacionExitosa)
                {
                    MessageBox.Show("Operación realizada exitosamente.", "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    PlatoModificado?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception ex) { }
        }

        #endregion
    }
}
