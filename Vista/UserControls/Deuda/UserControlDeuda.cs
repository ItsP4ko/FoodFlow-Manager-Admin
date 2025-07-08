using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.UserControls.Deuda
{
    public partial class UserControlDeuda : UserControl
    {
        private readonly Controladora.Deuda.ControladoraDeuda _controladoraDeuda;
        private int _idRestaurante;
        public UserControlDeuda(int idRestaurante, int idUsuario)
        {
            InitializeComponent();
            _controladoraDeuda = new Controladora.Deuda.ControladoraDeuda(idUsuario);
            _idRestaurante = idRestaurante;
        }

        #region Botones
        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal total = decimal.Parse(txtSaldo.Text);
                if (total <= 0)
                {
                    MessageBox.Show("El monto a pagar debe ser mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool ok = await _controladoraDeuda.PagarDeudaAsync(_idRestaurante, total);
                if (ok)
                {
                    lblDeuda.Text = $"Deuda: ${_controladoraDeuda.RecuperarDeudaAsync(_idRestaurante)}";
                }
                else
                {
                    MessageBox.Show("Error al pagar la deuda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Error al pagar la deuda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        #endregion

        #region Load
        private async void UserControlDeuda_Load(object sender, EventArgs e)
        {
            try
            {
                lblDeuda.Text = $"Deuda: ${await _controladoraDeuda.RecuperarDeudaAsync(_idRestaurante)}";

            }
            catch
            {
                lblDeuda.Text = $"Deuda: $Error Al recuperar Deuda";
            }
        }

        #endregion
    }
}
