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
using Vista.AdminRestaurante.UserControls;
using Vista.AdminRestaurante.UserControls.Platos;
using Vista.UserControls.CategoriasRestaurantes;
using Vista.UserControls.Extras;
using Vista.UserControls.Platos;

namespace Vista.Usuarios.AdminCocina
{
    public partial class AdminCocina : Form
    {
        #region Atributos

        private readonly int _idRestaurante;
        private readonly int _idUsuario; 
        private readonly Panel_UserControl_Estilos _estilos;
        private readonly Controladora.Ayuda.ControladoraAyuda _controladoraAyuda;
        private readonly PasswordCheck _passwordCheck; 

        private PlatosControlAdd _platosAdd;
        private PlatosControlDGV _platosDGV;
        private ExtrasControlAgregar _ExtraAdd;
        private CategoriaAddControl _categoriaAdd;
        private CategoriaDGVControl _categoriaDgv;

        #endregion

        #region Constructor

        public AdminCocina(int idRestaurante, int idUsuario)
        {
            InitializeComponent();
            _idRestaurante = idRestaurante;
            _idUsuario = idUsuario;
            _passwordCheck = new PasswordCheck(); 
            _estilos = new Panel_UserControl_Estilos();
            _platosAdd = new PlatosControlAdd(_idRestaurante, idUsuario);
            _ExtraAdd = new ExtrasControlAgregar(_idRestaurante, idUsuario);
            _controladoraAyuda = new Controladora.Ayuda.ControladoraAyuda(idUsuario);          

            this.FormClosing += AdminCocina_FormClosing;
        }

        private void AdminCocina_FormClosing(object sender, FormClosingEventArgs e)
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

        #region Eventos Principales

        private void AdminCocina_Load(object sender, EventArgs e) { }

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

        #region Menú - Platos

        private void agregraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _platosAdd = new PlatosControlAdd(_idRestaurante, _idUsuario);
            _platosDGV = new PlatosControlDGV(_idRestaurante, 1);

            _platosAdd.PlatoAgregado += (s, ev) =>
            {
                _platosDGV?.InitializeComponentAdicionales(_idRestaurante);
            };

            if (!_estilos.YaEstaMostrado<PlatosControlAdd>(pnlBotones))
            {
                _estilos.Mostrarizquierda(pnlBotones, _platosAdd);
            }

            _estilos.MostrarCentrado(pnlContenido, _platosDGV);
        }

        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            _platosDGV = new PlatosControlDGV(_idRestaurante, 1);
            _estilos.MostrarCentrado(pnlContenido, _platosDGV);

            var modificarControlPlato = new PlatoControlMod(_idRestaurante, _idUsuario, _platosDGV);

            modificarControlPlato.PlatoModificado += (s, ev) =>
            {
                _platosDGV?.InitializeComponentAdicionales(_idRestaurante);
            };

            _estilos.Mostrarizquierda(pnlBotones, modificarControlPlato);
        }

        #endregion

        #region Menú - Aderezos (Extras)

        private void agregarToolStripExtra_Click(object sender, EventArgs e)
        {
            _ExtraAdd = new ExtrasControlAgregar(_idRestaurante, _idUsuario);
            _platosDGV = new PlatosControlDGV(_idRestaurante, 2);

            _ExtraAdd.AderezoAgregado += (s, ev) =>
            {
                _platosDGV?.CargarAderezos(_idRestaurante);
            };

            if (!_estilos.YaEstaMostrado<ExtrasControlAgregar>(pnlBotones))
            {
                _estilos.Mostrarizquierda(pnlBotones, _ExtraAdd);
            }

            _estilos.MostrarCentrado(pnlContenido, _platosDGV);
        }

        private void modificarToolStripExtra_Click(object sender, EventArgs e)
        {
            _platosDGV = new PlatosControlDGV(_idRestaurante, 2);
            _estilos.MostrarCentrado(pnlContenido, _platosDGV);

            var modificarControl = new ExtrasControlModificar(_idRestaurante, _idUsuario, _platosDGV);

            modificarControl.AderezoModificado += (s, ev) =>
            {
                _platosDGV?.CargarAderezos(_idRestaurante);
            };

            _estilos.Mostrarizquierda(pnlBotones, modificarControl);
        }

        #endregion

        #region Menú - Pedidos

        private void pedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Pedidos = new PedidosAdminCocina(_idUsuario, _idRestaurante);
            Pedidos.Show();
        }

        #endregion

        #region Filtros - Buscadores

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (_platosDGV == null)
            {
                _platosDGV = new PlatosControlDGV( _idRestaurante, 2);
                _estilos.MostrarCentrado(pnlContenido, _platosDGV);

                var modificarControl = new ExtrasControlModificar(_idRestaurante, _idUsuario, _platosDGV);
                if (!_estilos.YaEstaMostrado<ExtrasControlAgregar>(pnlBotones))
                    _estilos.Mostrarizquierda(pnlBotones, modificarControl);

                modificarControl.AderezoModificado += (s, ev) =>
                {
                    _platosDGV?.CargarAderezosPorNombre(_idRestaurante, toolStripTextBox1.Text);
                };
            }

            _platosDGV?.CargarAderezosPorNombre(_idRestaurante, toolStripTextBox1.Text);
        }

        private void toolStripTxtPlato_TextChanged(object sender, EventArgs e)
        {
            if (_platosDGV == null)
            {
                _platosDGV = new PlatosControlDGV( _idRestaurante, 1);
                _estilos.MostrarCentrado(pnlContenido, _platosDGV);

                var modificarControl = new PlatoControlMod(_idRestaurante, _idUsuario, _platosDGV);
                if (!_estilos.YaEstaMostrado<PlatoControlMod>(pnlBotones))
                    _estilos.Mostrarizquierda(pnlBotones, modificarControl);

                modificarControl.PlatoModificado += (s, ev) =>
                {
                    _platosDGV?.CargarPlatoPorNombre(_idRestaurante, toolStripTxtPlato.Text);
                };
            }

            _platosDGV?.CargarPlatoPorNombre(_idRestaurante, toolStripTxtPlato.Text);
        }

        private void toolStripTxtCategoria_TextChanged(object sender, EventArgs e)
        {
            if (_platosDGV == null)
            {
                _platosDGV = new PlatosControlDGV( _idRestaurante, 1);
                _estilos.MostrarCentrado(pnlContenido, _platosDGV);

                var modificarControl = new PlatoControlMod(_idRestaurante, _idUsuario, _platosDGV);
                if (!_estilos.YaEstaMostrado<PlatoControlMod>(pnlBotones))
                    _estilos.Mostrarizquierda(pnlBotones, modificarControl);

                modificarControl.PlatoModificado += (s, ev) =>
                {
                    _platosDGV?.CargarPlatoPorCategoriaPorNombree(_idRestaurante, toolStripTxtPlato.Text);
                };
            }

            _platosDGV?.CargarPlatoPorCategoriaPorNombree(_idRestaurante, toolStripTxtPlato.Text);
        }

        #endregion

        #region Menú - Ayuda

        private void gmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controladoraAyuda.AyudaGmail(_idRestaurante);
        }

        private void whatsAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _controladoraAyuda.AyudaWPP(_idRestaurante);
        }

        #endregion

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _categoriaAdd = new CategoriaAddControl(_idUsuario, _idRestaurante);
            _categoriaDgv = new CategoriaDGVControl(_idRestaurante);

            _categoriaAdd.CategoriaAgregada += (s, ev) =>
            {
                _categoriaDgv?.InitializeComponentCategorias(_idRestaurante);
            };

            if (!_estilos.YaEstaMostrado<CategoriaAddControl>(pnlBotones))
            {
                _estilos.Mostrarizquierda(pnlBotones, _categoriaAdd);
            }

            _estilos.MostrarCentrado(pnlContenido, _categoriaDgv);
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _categoriaDgv = new CategoriaDGVControl(_idRestaurante);
            _estilos.MostrarCentrado(pnlContenido, _categoriaDgv);

            var ModCategoriaControl = new CategoriaModControl(_idUsuario, _categoriaDgv);

            ModCategoriaControl.CategoriaModificado += (s, ev) =>
            {
                _categoriaDgv?.InitializeComponentCategorias(_idRestaurante);
            };

            _estilos.Mostrarizquierda(pnlBotones, ModCategoriaControl);
        }
    }
}
