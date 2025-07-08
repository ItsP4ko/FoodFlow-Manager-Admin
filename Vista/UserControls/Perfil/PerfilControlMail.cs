using Controladora.DataGriedView;
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

namespace Vista.AdminRestaurante.UserControls
{
    public partial class PerfilControlMail : UserControl
    {
        #region Atributos Privados

        private readonly PasswordCheck _controladoraPasswordCheck;
        private readonly ControladoraPerfil _controladoraPerfil;
        private int _idRestaurante;
        private int _idUsuario;
        #endregion

        #region Constructor

        public PerfilControlMail(int idUsuario, int IdRestaurante)
        {
            InitializeComponent();
            _controladoraPasswordCheck = new PasswordCheck();
            
            _idRestaurante = IdRestaurante;
            _idUsuario = idUsuario;
            _controladoraPerfil = new ControladoraPerfil(_idRestaurante, idUsuario);
        }

        #endregion

        #region Eventos

        private void btnCambiarMail_Click(object sender, EventArgs e)
        {
            string NuevoMail = txtMail.Text;
            if (cbRol.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccioná un usuario del listado.",
                                "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) Recupero el IdUsuario del usuario elegido
            int idUsuarioSeleccionado = (int)cbRol.SelectedValue;

            var resultado = _controladoraPasswordCheck.CambiarMail(_idUsuario,idUsuarioSeleccionado, _idRestaurante, NuevoMail);

            if (resultado.Result.Exito)
            {
                MessageBox.Show(resultado.Result.Mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtMail.Clear();
                this.Parent.Controls.Remove(this);
            }
            else
            {
                MessageBox.Show(resultado.Result.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void PerfilControlMail_Load(object sender, EventArgs e)
        {           
            var listaUsuarios = _controladoraPerfil.CargarUsuarios(_idRestaurante);
            
            cbRol.DataSource = listaUsuarios;
            cbRol.DisplayMember = "NombreRol";  
            cbRol.ValueMember = "IdRol";   
            cbRol.SelectedIndex = -1;                     
        }

    }
}
