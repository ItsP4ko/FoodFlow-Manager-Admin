using Controladora.Seguridad;
using Seguirdad_Modulo.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vista.AdminRestaurante;
using Vista.Usuarios.AdminCocina;

namespace Vista.UserControls.LogIn
{
    public partial class LoginControl : UserControl
    {
        #region Atributos

        private readonly PasswordCheck _controladoraPasswordCheck;

        #endregion

        #region Constructor

        public LoginControl()
        {
            InitializeComponent();
            _controladoraPasswordCheck = new PasswordCheck();
        }

        #endregion

        #region Eventos

        private async void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, complete ambos campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuarioEncontrado = await _controladoraPasswordCheck.VerificarLoginAsync(usuario, password);

            if (usuarioEncontrado == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var cacheUsuario = CacheHelper.ObtenerCache(usuarioEncontrado.IdUsuario);
            if (cacheUsuario == null)
            {
                MessageBox.Show("Error al cargar datos del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var loginForm = this.FindForm();

            string nombreRol = cacheUsuario.NombreRol;
            int idUsuario = cacheUsuario.IdUsuario;
            int? idRestaurante = cacheUsuario.IdRestaurante;

            switch (nombreRol.ToUpper())
            {
                case "ADMINGENERAL":
                case "ADMINISTRADORGENERAL":
                    if (TienePermisoParaAcceder(idUsuario, "GestionAdminAdmin"))
                    {
                        MessageBox.Show($"Bienvenido {cacheUsuario.NombreRol}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Main form1 = new Main(idUsuario);
                        form1.Show();
                        loginForm?.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No tiene permisos de administración general.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                case "ADMINCOCINA":
                case "ADMINISTRADORCOCINA":
                    if (ValidarAccesoRestaurante(idUsuario, idRestaurante, "GestionCocina"))
                    {
                        MessageBox.Show($"Bienvenido {cacheUsuario.NombreRol} - {cacheUsuario.NombreRestaurante}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var mainC = new AdminCocina(idRestaurante.Value, idUsuario);
                        mainC.Show();
                        loginForm?.Hide();
                    }
                    break;

                case "ADMINRESTAURANTE":
                case "ADMINISTRADORRESTAURANTE":
                    if (ValidarAccesoRestaurante(idUsuario, idRestaurante, "GestionRestaurante"))
                    {
                        MessageBox.Show($"Bienvenido {cacheUsuario.NombreRol} - {cacheUsuario.NombreRestaurante}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var mainR = new MainRestaurate(idRestaurante.Value, idUsuario);
                        mainR.Show();
                        loginForm?.Hide();
                    }
                    break;

                case "CAJERO":
                case "CAJERORESTAURANTE":
                    if (ValidarAccesoRestaurante(idUsuario, idRestaurante, "GestionCaja"))
                    {
                        MessageBox.Show($"Bienvenido {cacheUsuario.NombreRol} - {cacheUsuario.NombreRestaurante}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        var cajeroR = new CajeroRestaurante.CajeroRestaurante(idRestaurante.Value, idUsuario);
                        cajeroR.Show();
                        loginForm?.Hide();
                    }
                    break;

                case "CADETE":
                    if (TienePermisoParaAcceder(idUsuario, "GestionDelivery"))
                    {
                        MessageBox.Show($"Bienvenido {cacheUsuario.NombreRol}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Interfaz de Cadete en desarrollo.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No tiene permisos de delivery.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                case "CLIENTE":
                    if (TienePermisoParaAcceder(idUsuario, "RealizarPedidos"))
                    {
                        MessageBox.Show($"Bienvenido Cliente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Interfaz de Cliente en desarrollo.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No tiene permisos para realizar pedidos.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;

                default:
                    MessageBox.Show($"Rol '{nombreRol}' no tiene interfaz configurada.", "Rol No Configurado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        #endregion

        #region Métodos de Validación con Cache

        private bool TienePermisoParaAcceder(int idUsuario, string permiso)
        {
            return _controladoraPasswordCheck.TienePermiso(idUsuario, permiso);
        }

        private bool ValidarAccesoRestaurante(int idUsuario, int? idRestaurante, string permisoRequerido)
        {
            if (!TienePermisoParaAcceder(idUsuario, permisoRequerido))
            {
                MessageBox.Show($"No tiene permisos de {permisoRequerido}.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (idRestaurante == null || idRestaurante == 0)
            {
                MessageBox.Show("Este usuario no tiene un restaurante asignado. Contacte al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #endregion

        #region Métodos Adicionales

        public void RealizarLogout(int idUsuario)
        {
            try
            {
                _controladoraPasswordCheck.Logout(idUsuario);
                MessageBox.Show("Sesión cerrada correctamente.", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cerrar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}