using Controladora.DataGriedView;
using Controladora.Estilo;
using Controladora.Menu;
using Controladora.Restaurante;
using Controladora.Seguridad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.AdminRestaurante.UserControls;
using Vista.AdminRestaurante.UserControls.Platos;
using Vista.UserControls.Deuda;
using Vista.UserControls.Menu;
using Vista.UserControls.Pedidos;
using Vista.UserControls.Platos;
using Vista.Usuarios.AdminRestaurante;

namespace Vista.AdminRestaurante
{
    public partial class MainRestaurate : Form
    {
        #region Campos Privados

        private readonly ABMRestaurante _controladoraABMRestaurante;
        private readonly Controladora.Ayuda.ControladoraAyuda _controladoraAyuda;
        private readonly ControladoraDGV _controladoraDGV;
        private Panel_UserControl_Estilos _estilos = new Panel_UserControl_Estilos();
        private readonly ControladoraMenu _controladoraMenu;
        private readonly PasswordCheck _passwordCheck; 
        private int _idRestaurante;
        private int _idUsuario; 

        #endregion

        #region Constructor

        public MainRestaurate(int IdRestaurante, int idUsuario)
        {
            _controladoraABMRestaurante = new ABMRestaurante();
            _controladoraDGV = new ControladoraDGV();
            _controladoraMenu = new ControladoraMenu(idUsuario);
            _controladoraAyuda = new Controladora.Ayuda.ControladoraAyuda();
            _passwordCheck = new PasswordCheck(); 
            _idRestaurante = IdRestaurante;
            _idUsuario = idUsuario;
            InitializeComponent();
            
            // 🔥 ADD: Evento para logout automático al cerrar
            this.FormClosing += MainRestaurate_FormClosing;
        }

        // 🔥 ADD: Evento FormClosing con logout
        private void MainRestaurate_FormClosing(object sender, FormClosingEventArgs e)
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

        #region Eventos de Layout

        private void pnlContenido_Resize(object sender, EventArgs e)
        {
            if (pnlContenido.Controls.Count > 0)
            {
                var control = pnlContenido.Controls[0];
                int x = (pnlContenido.Width - control.Width) / 2;
                int y = (pnlContenido.Height - control.Height) / 2;
                control.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            }
        }

        #endregion

        #region Perfil - Modificaciones

        private void modificarContrasenaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_estilos.YaEstaMostrado<PerfilControlPassword>(pnlContenido)) return;
            pnlBotones.Controls.Clear();

            var cambiarPassControl = new PerfilControlPassword(_idUsuario, _idRestaurante);
            _estilos.MostrarCentrado(pnlContenido, cambiarPassControl);
        }

        private void modificarMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_estilos.YaEstaMostrado<PerfilControlMail>(pnlContenido)) return;
            pnlBotones.Controls.Clear();

            var cambiarMailControl = new PerfilControlMail(_idUsuario, _idRestaurante);
            _estilos.MostrarCentrado(pnlContenido, cambiarMailControl);
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            pnlBotones.Controls.Clear();
            pnlContenido.BringToFront();
        }

        #endregion

        #region Menú

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_estilos.YaEstaMostrado<MenuControlAdd>(pnlBotones)) return;
            pnlBotones.Controls.Clear();
            pnlContenido.Controls.Clear();

            var menuAgregarControl = new MenuControlAdd(_idRestaurante, _idUsuario);
            _estilos.Mostrarizquierda(pnlBotones, menuAgregarControl);
        }

        private void EliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (_estilos.YaEstaMostrado<MenuControlEliminar>(pnlBotones)) return;
            pnlBotones.Controls.Clear(); pnlContenido.Controls.Clear();

            var menuEliminarControl = new MenuControlEliminar(_idRestaurante, _idUsuario);
            _estilos.Mostrarizquierda(pnlBotones, menuEliminarControl);
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlContenido.Controls.Clear();
            pnlBotones.Controls.Clear();
            pnlBotones.BringToFront();

        }

        private void menuPlatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controladoraMenu.VerMenu(_idRestaurante, "Platos");
        }

        private void menuTragosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controladoraMenu.VerMenu(_idRestaurante, "Tragos");
        }

        private void pagarDeudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_estilos.YaEstaMostrado<UserControlDeuda>(pnlBotones)) return;
            pnlBotones.Controls.Clear();
            pnlContenido.Controls.Clear();

            var DeduaControl = new UserControlDeuda(_idRestaurante, _idUsuario);
            _estilos.Mostrarizquierda(pnlBotones, DeduaControl);

            pnlBotones.BringToFront();
        }

        #endregion

        #region Pedidos

        private void verPedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_estilos.YaEstaMostrado<PedidosUserControlAdminR>(pnlBotones)) return;

            pnlBotones.Controls.Clear();
            pnlContenido.Controls.Clear();

            var VerPedido = new PedidosUserControlAdminR(_idRestaurante, _idUsuario);
            _estilos.MostrarCentrado(pnlContenido, VerPedido);

            // Traer el panel al frente
            pnlContenido.BringToFront();
        }

        #endregion

        #region Ayuda

        private void gmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controladoraAyuda.AyudaGmail(_idRestaurante);
        }

        private void whatsAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controladoraAyuda.AyudaWPP(_idRestaurante);
        }

        #endregion

        #region Salida

        private void btnSalir_Click(object sender, EventArgs e)
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
            finally
            {
                Application.Exit();
            }
        }

        #endregion


        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportesFormRestaurantes reportesFormRestaurantes = new ReportesFormRestaurantes(_idRestaurante);
            reportesFormRestaurantes.Show();
        }
    }
}
