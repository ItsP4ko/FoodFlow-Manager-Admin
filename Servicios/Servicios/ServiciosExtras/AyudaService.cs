using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Servicios.ServiciosExtras
{
    public class AyudaService
    {
        public string GenerarUrlGmail(string restauranteNombre, string destinatario = "paco.semino@gmail.com")
        {
            string asunto = Uri.EscapeDataString("Ayuda");
            string cuerpo = Uri.EscapeDataString($"¡Hola somos de {restauranteNombre}!\r\n\r\nLes escribo para...");

            return $"https://mail.google.com/mail/?view=cm&fs=1&to={destinatario}&su={asunto}&body={cuerpo}";
        }

        public string GenerarUrlWhatsApp(string restauranteNombre, string telefono = "5493416412391")
        {
            string texto = Uri.EscapeDataString($"¡Hola somos {restauranteNombre}!");
            return $"https://api.whatsapp.com/send?phone={telefono}&text={texto}";
        }

        public void AbrirUrl(string url)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}
