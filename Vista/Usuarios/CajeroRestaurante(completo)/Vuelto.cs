using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Usuarios.CajeroRestaurante
{
    public partial class Vuelto : Form
    {
        #region Atributos

        private decimal monto_Pagar;

        #endregion

        #region Constructor

        public Vuelto(decimal monto)
        {
            InitializeComponent();
            monto_Pagar = monto;
            lblTotal.Text = $"Total: {monto_Pagar}$";
        }

        #endregion

        #region Eventos

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {
                decimal saldo = decimal.Parse(txtMonto.Text);
                if (saldo > 0 && saldo > monto_Pagar)
                {
                    decimal vuelto = saldo - monto_Pagar;
                    MessageBox.Show($"vuelto: {vuelto}$");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El monto no puede ser negativo");
                    return;
                }
            }
            catch
            {
                // Opcional: Podés agregar un mensaje para entrada inválida
                MessageBox.Show("Ingrese un monto válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
