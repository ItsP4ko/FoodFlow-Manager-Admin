using Controladora.Seguridad;
using Modelo.Context;
using Servicios;
using Servicios.DTOs;
using Servicios.Services;
using Servicios.Servicios.ServiciosMain;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Controladora.Categoria
{
    public class ControladoraCategoria
    {
        private readonly CategoriaServiceMain _categoriaService;
        private readonly CategoriaService _categoriaDGV;
        private readonly PasswordCheck _passwordCheck;
        private readonly int _idUsuario;

        public ControladoraCategoria(int idUsuario)
        {
            var context = new EasyFoodFlowContext();
            _categoriaService = new CategoriaServiceMain(context);
            _categoriaDGV = new CategoriaService(context);
            _passwordCheck = new PasswordCheck();
            _idUsuario = idUsuario;
        }

        public bool AgregarCategoria(string nombre, int idRestaurante, bool estado)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCocina"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.");
                return false;
            }

            if (_categoriaService.YaExiste(nombre, idRestaurante))
            {
                MessageBox.Show("Ya existe una categoría con ese nombre en este restaurante.");
                return false;
            }

            try
            {
                _categoriaService.CrearCategoria(nombre, idRestaurante, estado);
                MessageBox.Show("Categoría creada exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al crear la categoría: " + ex.Message);
                return false;
            }
        }

        public bool ModificarCategoria(int idCategoria, string nombre, bool estado)
        {
            if (!_passwordCheck.TienePermiso(_idUsuario, "GestionCocina"))
            {
                MessageBox.Show("No tienes permiso");
                return false;
            }

            try
            {
                bool modificado = _categoriaService.ModificarCategoria(idCategoria, nombre, estado);
                if (!modificado)
                {
                    MessageBox.Show("No se realizó ninguna modificación.");
                    return false;
                }
                MessageBox.Show("Categoría modificada exitosamente.");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar la categoría: " + ex.Message);
                return false;
            }
        }

        public List<CategoriaDTO> CargarCategoriasPorRestaurante(int idRestaurante)
        {
            try
            {
                return _categoriaDGV.ObtenerPorRestaurante(idRestaurante);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message);
                return new List<CategoriaDTO>();
            }
        }
    }
}
