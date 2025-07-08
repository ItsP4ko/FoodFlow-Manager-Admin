using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora.Estilo
{
    public class Panel_UserControl_Estilos
    {

        public void MostrarCentrado(Panel contenedor, UserControl vista)
        {
            contenedor.Controls.Clear();
            vista.Dock = DockStyle.None;
            vista.Anchor = AnchorStyles.None;

            // Calcular la posición centrada
            int x = (contenedor.Width - vista.Width) / 2;
            int y = (contenedor.Height - vista.Height) / 2;
            vista.Location = new Point(Math.Max(0, x), Math.Max(0, y));

            contenedor.Controls.Add(vista);
        }

        public void MostrarDerecha(Panel contenedor, UserControl vista)
        {
            contenedor.Controls.Clear();

            vista.Dock = DockStyle.None;
            vista.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            int x = contenedor.Width - vista.Width - 20; // 20 --> Margen (pixeles)
            int y = (contenedor.Height - vista.Height) / 2;

            vista.Location = new Point(Math.Max(0, x), Math.Max(0, y));

            contenedor.Controls.Add(vista);
        }

        public void Mostrarizquierda(Panel contenedor, UserControl vista)
        {
            contenedor.Controls.Clear();

            vista.Dock = DockStyle.None;
            vista.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            int x = contenedor.Width - vista.Width - 5; // 20 --> Margen (pixeles)
            int y = (contenedor.Height - vista.Height) / 2;

            vista.Location = new Point(Math.Max(0, x), Math.Max(0, y));

            contenedor.Controls.Add(vista);
        }

        public bool YaEstaMostrado<T>(Panel contenedor) where T : UserControl
        {
            return contenedor.Controls.Count > 0 && contenedor.Controls[0] is T;
        }

    }
}
