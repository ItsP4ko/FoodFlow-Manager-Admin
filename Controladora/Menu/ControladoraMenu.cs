using Controladora.Seguridad;
using Microsoft.Win32;
using Modelo.Context;
using Servicios.Menu;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Controladora.Menu
{
    public class ControladoraMenu
    {
        private readonly EasyFoodFlowContext _context;
        private readonly MenuServicioMain _menuService;
        private readonly PasswordCheck _passwordCheck;
        private readonly int _idUsuario;

        public ControladoraMenu(int idUsuario)
        {
            _context = new EasyFoodFlowContext();
            _menuService = new MenuServicioMain(_context);
            _passwordCheck = new PasswordCheck();
            _idUsuario = idUsuario;
        }

        public void CargarMenu(int idRestaurante, string categoria)
        {
            try
            {
                if (!_passwordCheck.TienePermiso(_idUsuario, "GestionRestaurante"))
                {
                    MessageBox.Show("No tienes permiso");
                    return;
                }

                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaArchivo = openFileDialog.FileName;
                        byte[] archivoBytes = File.ReadAllBytes(rutaArchivo);

                        _menuService.GuardarMenu(idRestaurante, categoria, archivoBytes);

                        MessageBox.Show("PDF guardado con éxito.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el menú: " + ex.Message);
            }
        }

        public void VerMenu(int idRestaurante, string categoria)
        {
            try
            {
                var pdfBytes = _menuService.ObtenerMenuPdf(idRestaurante, categoria);

                if (pdfBytes != null)
                {
                    string uniqueFileName = $"menu_{Guid.NewGuid()}.pdf";
                    string tempPath = Path.Combine(Path.GetTempPath(), uniqueFileName);

                    File.WriteAllBytes(tempPath, pdfBytes);

                    Process.Start(new ProcessStartInfo(tempPath)
                    {
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("No se encontró ningún PDF en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el menú: " + ex.Message);
            }
        }

        public void EliminarMenu(int idRestaurante, string categoria)
        {
            try
            {
                if (!_passwordCheck.TienePermiso(_idUsuario, "GestionRestaurante"))
                {
                    MessageBox.Show("No tienes permiso");
                    return;
                }

                bool eliminado = _menuService.EliminarMenu(idRestaurante, categoria);

                if (eliminado)
                {
                    MessageBox.Show("PDF eliminado con éxito.");
                }
                else
                {
                    MessageBox.Show("No se encontró ningún PDF en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
