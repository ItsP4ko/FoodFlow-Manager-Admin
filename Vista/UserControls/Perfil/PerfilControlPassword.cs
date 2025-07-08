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

namespace Vista.AdminRestaurante
{
    public partial class PerfilControlPassword : UserControl
    {
        #region Atributos Privados

        private readonly PasswordCheck _controladoraPasswordCheck;
        private readonly ControladoraPerfil _controladoraPerfil;
        private int _idRestaurante;

        #endregion

        #region Constructor

        public PerfilControlPassword(int idUsuario, int IdRestaurante)
        {
            InitializeComponent();
            _controladoraPasswordCheck = new PasswordCheck();
            _idRestaurante = IdRestaurante;
            _controladoraPerfil = new ControladoraPerfil(IdRestaurante, idUsuario);
        }

        #endregion

        #region Eventos

        private void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            string contrasenaVieja = txtPassword.Text;
            string contrasenaNueva = txtNewPassword.Text;
            string validacion = txtNewPassword2.Text;

            if (cbRol.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccioná un usuario del listado.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idUsuarioSeleccionado = (int)cbRol.SelectedValue;

            var resultado = _controladoraPasswordCheck.CambiarContrasenaAsync(idUsuarioSeleccionado, contrasenaVieja, contrasenaNueva, validacion);

            if (resultado.Result.Exito)
            {
                MessageBox.Show(resultado.Result.Mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtPassword.Clear();
                txtNewPassword.Clear();
                txtNewPassword2.Clear();
                this.Parent.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show(resultado.Result.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion

        private void PerfilControlPassword_Load(object sender, EventArgs e)
        {
            var listaUsuarios = _controladoraPerfil.CargarUsuarios(_idRestaurante);

            cbRol.DataSource = listaUsuarios;
            cbRol.DisplayMember = "NombreRol";
            cbRol.ValueMember = "IdRol";
            cbRol.SelectedIndex = -1;
        }
    }
}
