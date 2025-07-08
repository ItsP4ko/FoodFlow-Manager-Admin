using System;
using System.Windows.Forms;
using Controladora.DataGriedView;
using Controladora.Restaurante;
using Controladora.Seguridad;
using Modelo.Models;
using Vista.AdminAdmin;
using Vista.Usuarios.AdminAdmin;

namespace Vista
{
    public partial class Main : Form
    {
        #region Campos Privados
        private readonly ABMRestaurante _controladoraABMRestaurante;
        private readonly ControladoraDGV _controladoraDGV;
        private readonly PasswordCheck _passwordCheck; 
        private int _idRestauranteSeleccionado;
        private int _idPlanSeleccionado;
        public int Opcion = 0;
        public int opcionPlan = 0;
        #endregion

        #region Constructor
        public Main( int idUsuario)
        {
            InitializeComponent();
            _controladoraABMRestaurante = new ABMRestaurante(idUsuario);
            _controladoraDGV = new ControladoraDGV();
            _passwordCheck = new PasswordCheck();  
            
            this.FormClosing += Main_FormClosing;
        }

       
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
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

        #region Metodos Auxiliares
        private void UpdateDataGrid(object dataSource)
        {
            dgvRestaurantes.DataSource = null;
            dgvRestaurantes.DataSource = dataSource;
            dgvRestaurantes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvRestaurantes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void SetAgregarModificarVisibility(bool visible)
        {
            txtDireccion.Visible = visible;

            txtNombre.Visible = visible;
            lblNombre.Visible = visible;
            txtCapacidad.Visible = visible;
            lblCantToDni.Visible = visible;
            lblDirecToApell.Visible = visible;
            btnAgregarModificar.Visible = visible;

        }

        private void LimpiarSelectMenuStrip()
        {
            toolStripTxtUserMail.Clear();
            toolStripTxtBuscarNomRest.Clear();
            toolStripTxtUserRol.Clear();
            toolStripTxtCadete.Clear();
        }

        private void Limpiartxt()
        {
            txtCapacidad.Text = "0";
            txtDireccion.Clear();
            txtNombre.Clear();

        }
        #endregion

        #region Eventos Form
        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateDataGrid(_controladoraDGV.CargarRestaurantes());

        }

        private void dgvRestaurantes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var filaSeleccionada = dgvRestaurantes.Rows[e.RowIndex];

                    // Validamos si existe la columna "IdRestaurante"
                    if (dgvRestaurantes.Columns.Contains("IdRestaurante"))
                    {
                        var valorIdRest = filaSeleccionada.Cells["IdRestaurante"].Value;
                        if (valorIdRest != null && int.TryParse(valorIdRest.ToString(), out int idRest))
                        {
                            _idRestauranteSeleccionado = idRest;
                        }
                        else
                        {
                            _idRestauranteSeleccionado = -1; // O el valor que uses por defecto
                        }
                    }

                    // Validamos si existe la columna "IdPlan"
                    if (dgvRestaurantes.Columns.Contains("IdPlan"))
                    {
                        var valorIdPlan = filaSeleccionada.Cells["IdPlan"].Value;
                        if (valorIdPlan != null && int.TryParse(valorIdPlan.ToString(), out int idPlan))
                        {
                            _idPlanSeleccionado = idPlan;
                        }
                        else
                        {
                            _idPlanSeleccionado = -1; // O el valor que uses por defecto
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener el ID seleccionado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Eventos ToolStrip
        private void restauranteToolStripMenuItem_Click(object sender, EventArgs e) => UpdateDataGrid(_controladoraDGV.CargarRestaurantes());
        private void cadeteToolStrip_Click(object sender, EventArgs e) => UpdateDataGrid(_controladoraDGV.CargarCadetes());
        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e) => UpdateDataGrid(_controladoraDGV.CargarUsuarios());
        private void planToolStripMenuItem_Click(object sender, EventArgs e) => UpdateDataGrid(_controladoraDGV.CargarRoles());
        private void mailToolStripMenuItem_Click(object sender, EventArgs e) => LimpiarSelectMenuStrip();
        private void rolToolStripMenuItem_Click(object sender, EventArgs e) => LimpiarSelectMenuStrip();
        private void menuStrip1_MenuDeactivate(object sender, EventArgs e)
        {
            LimpiarSelectMenuStrip();
            UpdateDataGrid(_controladoraDGV.CargarRestaurantes());
        }
        #endregion

        #region Busquedas ToolStrip
        private void toolStripTxtBuscarNomRest_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filtro = toolStripTxtBuscarNomRest.Text;
                UpdateDataGrid(string.IsNullOrWhiteSpace(filtro)
                    ? _controladoraDGV.CargarRestaurantes()
                    : _controladoraDGV.CargarRestaurantesPorNombre(filtro));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripTxtUserRol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateDataGrid(_controladoraDGV.BuscarUsuariosPorRol(toolStripTxtUserRol.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripTxtUserMail_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateDataGrid(_controladoraDGV.BuscarUsuariosPorMail(toolStripTxtUserMail.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ABM Restaurante
        private void MenuAgregarModificarR_Click(object sender, EventArgs e)
        {
            SetAgregarModificarVisibility(true);
            Limpiartxt();
            btnAgregarModificar.Text = "Agregar";
            menuStrip1.Refresh();
            Opcion = 1;
        }

        private void MenuModificarR_Click(object sender, EventArgs e)
        {
            SetAgregarModificarVisibility(true);
            Limpiartxt();
            btnAgregarModificar.Text = "Modificar";
            menuStrip1.Refresh();
            Opcion = 2;
        }

        private void MenuEliminarR_Click(object sender, EventArgs e)
        {
            SetAgregarModificarVisibility(false);
            btnAgregarModificar.Visible = true;
            btnAgregarModificar.Text = "Eliminar";
            menuStrip1.Refresh();
            Opcion = 3;
        }

        private void btnAgregarModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtCapacidad.Text, out int capacidad))
                {
                    MessageBox.Show("Capacidad debe ser un numero valido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string nom = txtNombre.Text;
                string direc = txtDireccion.Text;
                bool operacionExitosa = false;


                switch (Opcion)
                {
                    case 1:
                        operacionExitosa = _controladoraABMRestaurante.AgregarRestaurante(nom, direc, capacidad, 1,1,1);
                        break;
                    case 2:
                        operacionExitosa = _controladoraABMRestaurante.ModificarRestaurante(_idRestauranteSeleccionado, nom, direc, capacidad);
                        break;
                    case 3:
                        operacionExitosa = _controladoraABMRestaurante.EliminarRestaurante(_idRestauranteSeleccionado);
                        break;
                    default:
                        MessageBox.Show("Seleccione una opcion antes de continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }

                if (operacionExitosa)
                    MessageBox.Show("Operaci�n realizada exitosamente.");

                SetAgregarModificarVisibility(false);
                Limpiartxt();
                UpdateDataGrid(_controladoraDGV.CargarRestaurantes());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la operaci�n: {ex.Message}");
            }
        }
        #endregion

        #region ABM Plan
        private void agregarPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtNombre.Visible = true;
            opcionPlan = 1;

        }

        private void modificarPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGrid(_controladoraDGV.CargarRoles());
            txtNombre.Visible = true;
            opcionPlan = 2;
        }

        private void eliminarPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGrid(_controladoraDGV.CargarRoles());
            txtNombre.Visible = true;
            opcionPlan = 3;
        }

        #endregion

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RolesPermisosVista rolesPermiso = new RolesPermisosVista(_idUsuario);
            rolesPermiso.Show();
        }

        private void cadetesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadetes_abm_Form cadeteForm = new Cadetes_abm_Form(_idUsuario);
            cadeteForm.Show();
        }
    }
}
