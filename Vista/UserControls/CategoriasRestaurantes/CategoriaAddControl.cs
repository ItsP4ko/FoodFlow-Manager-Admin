using Controladora.Platos;
using Controladora.Seguridad;
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

namespace Vista.UserControls.CategoriasRestaurantes
{
    public partial class CategoriaAddControl : UserControl
    {
        private int _idRestaurante;
        private readonly Controladora.Categoria.ControladoraCategoria _controladoraCategoria;


        public event EventHandler CategoriaAgregada;

        public CategoriaAddControl(int idUsuario, int idRestaurante)
        {
            InitializeComponent();
            _idRestaurante = idRestaurante;
            _controladoraCategoria = new Controladora.Categoria.ControladoraCategoria(idUsuario);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                
                string nombre = txtNombre.Text.Trim();
                var estadoSeleccionado = (EstadoItem)cbEstado.SelectedItem;
                bool valorEstado = estadoSeleccionado.Valor;
                bool operacionExitosa = _controladoraCategoria.AgregarCategoria(nombre, _idRestaurante, valorEstado);

                if (operacionExitosa)
                {
                    MessageBox.Show("Categoría agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CategoriaAgregada?.Invoke(this, EventArgs.Empty); // Dispara el evento para notificar que se agregó una categoría
                    // Limpio campos o recargo lista si es necesario:
                    txtNombre.Clear();
                    cbEstado.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la categoría. Verifique los datos y vuelva a intentarlo.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}",
                        "Excepción", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CategoriaAddControl_Load(object sender, EventArgs e)
        {
            var estados = new List<EstadoItem>
            {
                new EstadoItem("Habilitado", true),
                new EstadoItem("Deshabilitado", false)
            };

            cbEstado.DataSource = estados;
        }
    }
}
