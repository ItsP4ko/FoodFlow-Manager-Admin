using Controladora.Estilo;
using Controladora.Seguridad;
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
using Vista.UserControls.LogIn;
using Vista.UserControls.Menu;

namespace Vista.LogIn
{
    public partial class LogIn : Form
    {
        #region Atributos

        private readonly Panel_UserControl_Estilos _estilos = new Panel_UserControl_Estilos();

        #endregion

        #region Constructor

        public LogIn()
        {
            InitializeComponent();
            Iniciar();
        }

        #endregion

        #region Métodos

        public void Iniciar()
        {
            if (_estilos.YaEstaMostrado<LoginControl>(pnLog)) return;
            pnLog.Controls.Clear();

            var LogIn = new LoginControl();
            _estilos.MostrarCentrado(pnLog, LogIn);
        }

        #endregion

        #region Eventos

        private void lblRegistro_Click(object sender, EventArgs e)
        {
        }

        #endregion
    }
}
