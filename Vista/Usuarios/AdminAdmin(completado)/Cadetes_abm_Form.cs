using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista.Usuarios.AdminAdmin
{
    public partial class Cadetes_abm_Form : Form
    {
        private readonly Controladora.Cadeteria.ABMCadetes _abmCadetes;
        public Cadetes_abm_Form(int idUsuario)
        {
            InitializeComponent();
            _abmCadetes = new Controladora.Cadeteria.ABMCadetes(idUsuario);
        }

        private void volverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void dgvCadetes_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Cadetes_abm_Form_Load(object sender, EventArgs e)
        {
            _abmCadetes.CargarCadetes(dgvCadetes);
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!int.TryParse(txtDni.Text, out int dni))
            {
                MessageBox.Show("Ingrese un DNI válido.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _abmCadetes.AgregarCadete(dni, txtNombre.Text.Trim(), txtApellido.Text.Trim());

            _abmCadetes.CargarCadetes(dgvCadetes);
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvCadetes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione primero el cadete a modificar.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            int dni = Convert.ToInt32(dgvCadetes.CurrentRow.Cells["DNI"].Value);


            string nuevoNombre = txtNombre.Text.Trim();
            string nuevoApellido = txtApellido.Text.Trim();

            // Llamar al método de modificación
            _abmCadetes.ModificarCadete(dni, nuevoNombre, nuevoApellido);

            // Refrescar y limpiar
            _abmCadetes.CargarCadetes(dgvCadetes);
            txtNombre.Clear();
            txtApellido.Clear();
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Asegurarse de que haya una fila seleccionada
            if (dgvCadetes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione primero el cadete a eliminar.", "Atención",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Confirmación
            var resp = MessageBox.Show("¿Está seguro de eliminar este cadete?", "Confirmar",
                                       MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resp != DialogResult.Yes) return;


            int dni = Convert.ToInt32(dgvCadetes.CurrentRow.Cells["DNI"].Value);
            _abmCadetes.EliminarCadete(dni);

            // Refrescar la grilla
            _abmCadetes.CargarCadetes(dgvCadetes);

        }

        private void txtDniSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int dni = int.Parse(txtDniSearch.Text);
                _abmCadetes.BuscarCadetexDni(dgvCadetes, dni);
            }catch(FormatException)
            {
                
                _abmCadetes.CargarCadetes(dgvCadetes);
            }
        }
            
    }
}
