using Controladora.Menu;
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

namespace Vista.UserControls.Menu
{
    public partial class MenuControlEliminar : UserControl
    {
        #region Atributos

        private int _idRestaurante;
        private readonly ControladoraMenu _controladoraMenu;

        #endregion

        #region Constructor

        public MenuControlEliminar(int idRestaurante, int idUsuario)
        {
            InitializeComponent();
            _idRestaurante = idRestaurante;
            _controladoraMenu = new ControladoraMenu(idUsuario);
        }

        #endregion

        #region Eventos

        private void MenuControlEliminar_Load(object sender, EventArgs e)
        {
            cbCategoria.Items.Add("Platos");
            cbCategoria.Items.Add("Tragos");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string Categoria = cbCategoria.Text;

            if (string.IsNullOrEmpty(Categoria))
            {
                MessageBox.Show("Por favor, ingrese una categoría.");
                return;
            }

            _controladoraMenu.EliminarMenu(_idRestaurante, Categoria);
            this.Parent.Controls.Remove(this);
        }

        #endregion
    }
}
