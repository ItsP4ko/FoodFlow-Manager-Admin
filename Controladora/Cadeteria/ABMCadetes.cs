using Controladora.Seguridad;
using Modelo.Context;
using Servicios;
using Servicios.Servicios.DGVServicio;
using Servicios.Servicios.ServiciosMain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controladora.Cadeteria
{
    public class ABMCadetes
    {
        private readonly CadeteServiceMain _cadeteService;
        private readonly CadeteService _cadeteDGV;
        private readonly PasswordCheck _passwordCheck;
        private readonly int _idUsuario;

        public ABMCadetes(int idUsuario)
        {
            var context = new EasyFoodFlowContext();
            _cadeteService = new CadeteServiceMain(context);
            _cadeteDGV = new CadeteService(context);
            _passwordCheck = new PasswordCheck();
            _idUsuario = idUsuario;
        }

        public void AgregarCadete(int dni, string nombre, string apellido)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionAdminAdmin"))
            {
                MessageBox.Show("No tienes permiso.");
                return;
            }

            try
            {
                _cadeteService.CrearCadete(dni, nombre, apellido);
                MessageBox.Show("Cadete creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void EliminarCadete(int dni)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionAdminAdmin"))
            {
                MessageBox.Show("No tienes permiso.");
                return;
            }

            try
            {
                bool eliminado = _cadeteService.EliminarCadete(dni);
                if (!eliminado)
                {
                    MessageBox.Show("No se encontró el cadete con ese DNI.");
                    return;
                }
                MessageBox.Show("Cadete eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cadete: " + ex.Message);
            }
        }

        public void ModificarCadete(int dni, string nombre, string apellido)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionAdminAdmin"))
            {
                MessageBox.Show("No tienes permiso.");
                return;
            }

            try
            {
                bool modificado = _cadeteService.ModificarCadete(dni, nombre, apellido);
                if (!modificado)
                {
                    MessageBox.Show("No se encontró el cadete para modificar.");
                    return;
                }
                MessageBox.Show("Cadete modificado exitosamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el cadete: " + ex.Message);
            }
        }

        public void CargarCadetes(DataGridView dgv)
        {
            var lista = _cadeteDGV.ObtenerTodos();
            dgv.DataSource = lista.Select(c => new { c.Dni, NombreCompleto = c.NombreCompleto }).ToList();
            dgv.Columns["Dni"].HeaderText = "DNI";
            dgv.Columns["NombreCompleto"].HeaderText = "Nombre y Apellido";
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
        }

        public void BuscarCadetexDni(DataGridView dgv, int dni)
        {
            var lista = _cadeteDGV.BuscarPorDniParcial(dni);
            dgv.DataSource = lista.Select(c => new { c.Dni, NombreCompleto = c.NombreCompleto }).ToList();
            dgv.Columns["Dni"].HeaderText = "DNI";
            dgv.Columns["NombreCompleto"].HeaderText = "Nombre y Apellido";
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
        }
    }
}