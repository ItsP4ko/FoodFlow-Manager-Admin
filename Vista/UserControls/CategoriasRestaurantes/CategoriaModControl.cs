using Controladora.Categoria;
using Controladora.Platos;
using DocumentFormat.OpenXml.Wordprocessing;
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

namespace Vista.UserControls.CategoriasRestaurantes
{
    public partial class CategoriaModControl : UserControl
    {
        private readonly CategoriaDGVControl _dgv;
        private readonly ControladoraCategoria _controladoraCategoria;
        private int _idCategoria;
        public EventHandler CategoriaModificado;
        public CategoriaModControl(int idUsuario, CategoriaDGVControl dgv)
        {
            InitializeComponent();
            _dgv = dgv;

            _dgv.IdCategoriaSeleccionado += (s, e) =>
            {
                _idCategoria = _dgv.IdCategoria;
            };
            _controladoraCategoria = new ControladoraCategoria(idUsuario);
        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            try
            {
                string nom = txtNombre.Text.Trim();

                // Verifica que se haya seleccionado un estado en el ComboBox
                if (cbEstado.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione un estado.", "Estado requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool valorEstado = (bool)cbEstado.SelectedValue;

                // Llamamos al método que modifica la categoría
                bool operacionExitosa = _controladoraCategoria.ModificarCategoria(_idCategoria, nom, valorEstado);

                if (operacionExitosa)
                {
                    MessageBox.Show("Operación realizada exitosamente.");
                    CategoriaModificado?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("No se realizaron cambios o la categoría no existe.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CategoriaModControl_Load_1(object sender, EventArgs e)
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
    }
}
