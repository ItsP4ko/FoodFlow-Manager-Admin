using Controladora.Restaurante;
using Servicios.Servicios.ServiciosExtras;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Ayuda
{
    public class ControladoraAyuda
    {
        private readonly AyudaService _ayudaService;
        private readonly ABMRestaurante _abmRestaurante;

        public ControladoraAyuda()
        {
            _ayudaService = new AyudaService();
            _abmRestaurante = new ABMRestaurante();
        }

        public void AyudaGmail(int idRestaurante)
        {
            string restaurante = _abmRestaurante.BuscarRestaurante(idRestaurante);
            string url = _ayudaService.GenerarUrlGmail(restaurante);
            _ayudaService.AbrirUrl(url);
        }

        public void AyudaWPP(int idRestaurante)
        {
            string restaurante = _abmRestaurante.BuscarRestaurante(idRestaurante);
            string url = _ayudaService.GenerarUrlWhatsApp(restaurante);
            _ayudaService.AbrirUrl(url);
        }
    }
}
