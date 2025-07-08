using Controladora.Estilo;
using Controladora.Seguridad;
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
using Vista.UserControls.Pedidos;

namespace Vista.CajeroRestaurante
{
    public partial class CajeroRestaurante : Form
    {
        #region Atributos

        private int _idRestaurante;
        private int _idUsuario; 
        private readonly Panel_UserControl_Estilos _estilos;
        private readonly PasswordCheck _passwordCheck; 

        #endregion

        #region Constructor

        public CajeroRestaurante(int IdRestaurante, int idUsuario)
        {
            InitializeComponent();
            _idRestaurante = IdRestaurante;
            _idUsuario = idUsuario; 
            _passwordCheck = new PasswordCheck(); 
            _estilos = new Panel_UserControl_Estilos();
            
            // 🔥 ADD: Evento para logout automático al cerrar
            this.FormClosing += CajeroRestaurante_FormClosing;
        }

        // 🔥 ADD: Evento FormClosing con logout
        private void CajeroRestaurante_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_idUsuario > 0)
                {
                    _passwordCheck.Logout(_idUsuario);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cerrar sesión: {ex.Message}", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Eventos de Carga

        private void CajeroRestaurante_Load(object sender, EventArgs e)
        {
            if (_estilos.YaEstaMostrado<CajeroPedidoAdd>(panelCajero)) return;
            panelCajero.Controls.Clear();

            var pedidoAdd = new CajeroPedidoAdd(_idRestaurante, false, _idUsuario);
            _estilos.MostrarCentrado(panelCajero, pedidoAdd);
        }

        #endregion

        #region Menú - Opciones de Pedido

        private void realizarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_estilos.YaEstaMostrado<CajeroPedidoAdd>(panelCajero)) return;
            panelCajero.Controls.Clear();

            var pedidoAdd = new CajeroPedidoAdd(_idRestaurante, false, _idUsuario);
            _estilos.MostrarCentrado(panelCajero, pedidoAdd);
        }

        private void modificarPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_estilos.YaEstaMostrado<CajeroControlPedidoModificar>(panelCajero)) return;
            panelCajero.Controls.Clear();

            var pedidoMod = new CajeroControlPedidoModificar(_idRestaurante, _idUsuario, true);
            _estilos.MostrarCentrado(panelCajero, pedidoMod);
        }

        #endregion
    }
}
