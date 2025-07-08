using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Controladora.DataGriedView;
using Controladora.Seguridad;
using Microsoft.EntityFrameworkCore;
using Modelo;
using Modelo.Models;

namespace Vista.AdminAdmin
{
    public partial class RolesPermisosVista : Form
    {
        #region Campos Privados

        private readonly ControladoraRolesPermisos _controladoraRolesPermisos;
        private readonly ControladoraDGV _controladoraDGV;
        private int _contador;
        private int _idUsuario;

        #endregion

        #region Constructor

        public RolesPermisosVista(int idUsuario)
        {
            InitializeComponent();
            _controladoraRolesPermisos = new ControladoraRolesPermisos();
            _controladoraDGV = new ControladoraDGV();
            _idUsuario = idUsuario; 
            InitializeCustomComponents();
        }

        #endregion

        #region Métodos de Inicialización

        private void InitializeCustomComponents()
        {
            UpdateDataGridRoles(_controladoraDGV.CargarRoles());
            UpdateDataGridPermisos(_controladoraDGV.CargarPermisos());
            CargarRolesEnComboBox();
        }

        #endregion

        #region Métodos de Actualización de DataGridView

        private void UpdateDataGridRoles(object dataSource)
        {
            dataGridViewRoles.DataSource = null;
            dataGridViewRoles.DataSource = dataSource;
            dataGridViewRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewRoles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void UpdateDataGridPermisos(object dataSource)
        {
            dgvPermisos.DataSource = null;
            dgvPermisos.DataSource = dataSource;
            dgvPermisos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPermisos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        #endregion

        #region Eventos de Menú

        private void crearRolToolStripMenuItem_Click(object sender, EventArgs e) { _contador = 1; MessageBox.Show("Complete el campo nombre y seleccione confirmar.."); }

        private void crearPermisoToolStripMenuItem_Click(object sender, EventArgs e) { _contador = 2; UpdateDataGridPermisos(_controladoraDGV.CargarPermisos()); MessageBox.Show("Complete el campo nombre y seleccione confirmar.."); }

        private void eliminarRolToolStripMenuItem_Click(object sender, EventArgs e) { _contador = 3; MessageBox.Show("Seleccione el rol a eliminar y presione confirmar.."); }

        private void asignarPermisosToolStripMenuItem_Click(object sender, EventArgs e) { _contador = 4; UpdateDataGridPermisos(_controladoraDGV.CargarPermisos()); MessageBox.Show("Seleccione todos los roles a gusto con ctrl + click y presione confirmar.."); }

        private void modificarRolToolStripMenuItem_Click(object sender, EventArgs e) => _contador = 5;

        private void eliminarPermisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _contador = 6;
            if (dataGridViewRoles.SelectedRows.Count > 0)
            {
                int idRol = Convert.ToInt32(dataGridViewRoles.SelectedRows[0].Cells["IdRol"].Value);
                UpdateDataGridPermisos(_controladoraDGV.ObtenerPermisosDeRol(idRol));
            }
            else
            {
                MessageBox.Show("Seleccione un rol para ver sus permisos.");
            }
        }

        private void modificarPermisoToolStripMenuItem_Click(object sender, EventArgs e) { _contador = 7; UpdateDataGridPermisos(_controladoraDGV.CargarPermisos()); }

        #endregion

        #region Evento del Botón Principal

        private void ButtonCreateRole_Click(object sender, EventArgs e)
        {
            int[] valoresExcluidos = { 4, 6, 8 };
            string rolePermisoName = textBoxRoleName.Text;

            try
            {
                if (string.IsNullOrEmpty(rolePermisoName) && !valoresExcluidos.Contains(_contador))
                {
                    MessageBox.Show("Complete el TextBox.");
                    return;
                }

                switch (_contador)
                {
                    case 1: // Crear Rol
                        _controladoraRolesPermisos.CrearRol(rolePermisoName, _idUsuario);
                        UpdateDataGridRoles(_controladoraDGV.CargarRoles());
                        break;

                    case 2: // Crear Permiso
                        _controladoraRolesPermisos.CrearPermiso(rolePermisoName, _idUsuario);
                        UpdateDataGridPermisos(_controladoraDGV.CargarPermisos());
                        MessageBox.Show($"Permiso '{rolePermisoName}' creado exitosamente.");
                        break;

                    case 3: // Eliminar Rol
                        if (dataGridViewRoles.SelectedRows.Count > 0)
                        {
                            int idRol = Convert.ToInt32(dataGridViewRoles.SelectedRows[0].Cells["IdRol"].Value);
                            _controladoraRolesPermisos.EliminarRol(idRol, _idUsuario);
                            UpdateDataGridRoles(_controladoraDGV.CargarRoles());
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un rol.");
                        }
                        break;

                    case 4: // Asignar Permisos a Rol
                        if (dataGridViewRoles.SelectedRows.Count > 0)
                        {
                            int idRol = Convert.ToInt32(dataGridViewRoles.SelectedRows[0].Cells["IdRol"].Value);
                            foreach (DataGridViewRow fila in dgvPermisos.SelectedRows)
                            {
                                int idPermiso = Convert.ToInt32(fila.Cells["IdPermiso"].Value);
                                _controladoraRolesPermisos.AsignarPermisoARol(idRol, idPermiso, _idUsuario);
                            }
                            MessageBox.Show("Permisos asignados correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un rol.");
                        }
                        break;

                    case 5: // Modificar Rol
                        if (dataGridViewRoles.SelectedRows.Count > 0)
                        {
                            int idRol = Convert.ToInt32(dataGridViewRoles.SelectedRows[0].Cells["IdRol"].Value);
                            _controladoraRolesPermisos.ModificarRol(idRol, rolePermisoName, _idUsuario);
                            UpdateDataGridRoles(_controladoraDGV.CargarRoles());
                            MessageBox.Show("Rol Modificado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un rol.");
                        }
                        break;

                    case 6:// Eliminar Permisos de Rol
                        if (dataGridViewRoles.SelectedRows.Count > 0)
                        {
                            int idRol = Convert.ToInt32(dataGridViewRoles.SelectedRows[0].Cells["IdRol"].Value);
                            foreach (DataGridViewRow fila in dgvPermisos.SelectedRows)
                            {
                                int idPermiso = Convert.ToInt32(fila.Cells["IdPermiso"].Value);
                                _controladoraRolesPermisos.EliminarPermisoDeRol(idRol, idPermiso, _idUsuario);
                            }
                            UpdateDataGridPermisos(_controladoraDGV.ObtenerPermisosDeRol(idRol));
                            MessageBox.Show("Permisos quitados correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un rol.");
                        }
                        break;

                    case 7: // Modificar Permiso
                        if (dgvPermisos.SelectedRows.Count > 0)
                        {
                            int idPermiso = Convert.ToInt32(dgvPermisos.SelectedRows[0].Cells["IdPermiso"].Value);
                            _controladoraRolesPermisos.ModificarPermiso(idPermiso, rolePermisoName, _idUsuario);
                            UpdateDataGridPermisos(_controladoraDGV.CargarPermisos());
                            MessageBox.Show("Permiso modificado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Seleccione un rol.");
                        }
                        break;
                    case 8: // Asignar un Rol (source) como hijo de otro Rol (target)
                        if (cbRoles.SelectedItem == null)
                        {
                            MessageBox.Show("Seleccione el rol de origen (el que cederá los permisos) en el ComboBox.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (dataGridViewRoles.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Seleccione el rol de destino (el que recibirá los permisos) en la grilla de Roles.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // ROL hijo
                        Role sourceRole = (Role)cbRoles.SelectedItem;
                        int idSourceRol = sourceRole.IdRol;

                        // ROL padre
                        int idTargetRol = Convert.ToInt32(dataGridViewRoles.SelectedRows[0].Cells["IdRol"].Value);

                        if (idSourceRol == idTargetRol)
                        {
                            MessageBox.Show("No se puede asignar un rol como hijo de sí mismo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        try
                        {
                            _controladoraRolesPermisos.AsignarRolARol(idTargetRol, idSourceRol, _idUsuario); // Notice the order: idRolPadre, idRolHijo
                            MessageBox.Show($"El rol '{sourceRole.Nombre}' ha sido asignado como hijo del rol '{((Role)dataGridViewRoles.SelectedRows[0].DataBoundItem).Nombre}' exitosamente. Ahora el rol padre tiene los permisos del rol hijo.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (UnauthorizedAccessException ex)
                        {
                            MessageBox.Show(ex.Message, "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al asignar rol: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;

                    default:
                        MessageBox.Show("Seleccione una acción válida.");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        #endregion

        #region BUQUEDA 
        private void tsSearchRol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var rolesFiltrados = _controladoraDGV.BuscarRolesPorNombre(tsSearchRol.Text);
                UpdateDataGridRoles(rolesFiltrados);

                if (dataGridViewRoles.Rows.Count > 0)
                {
                    dataGridViewRoles.ClearSelection();
                    dataGridViewRoles.Rows[0].Selected = true;
                }
                else
                {
                    UpdateDataGridPermisos(_controladoraDGV.CargarPermisos()); // Limpiar permisos si no hay roles
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsTextBoxSearchPermiso_TextChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateDataGridPermisos(_controladoraDGV.BuscarPermisosPorNombre(tsTextBoxSearchPermiso.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la grilla: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewRoles_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRoles.SelectedRows.Count > 0 && _contador != 4)
            {
                int idRol = Convert.ToInt32(dataGridViewRoles.SelectedRows[0].Cells["IdRol"].Value);
                UpdateDataGridPermisos(_controladoraDGV.ObtenerPermisosDeRol(idRol));
            }
        }

        #endregion

        private void todosPermisosDeRolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _contador = 8;
            MessageBox.Show("Seleccione el rol de origen en el ComboBox y el rol de destino en la grilla de Roles, luego presione 'Completar'.");

        }
        private void CargarRolesEnComboBox()
        {
            var roles = _controladoraDGV.CargarRoles();
            cbRoles.DataSource = roles;
            cbRoles.DisplayMember = "Nombre";
            cbRoles.ValueMember = "IdRol";
            cbRoles.SelectedIndex = -1;
        }

        private void MenuTool_Click(object sender, EventArgs e)
        {
            UpdateDataGridPermisos(_controladoraDGV.CargarPermisos());
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridPermisos(_controladoraDGV.CargarPermisos());
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridPermisos(_controladoraDGV.CargarPermisos());
        }

        private void verTodosPermisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDataGridPermisos(_controladoraDGV.CargarPermisos());
        }
    }
}
