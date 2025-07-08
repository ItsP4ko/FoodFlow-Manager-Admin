using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Estado
{
    public class EstadoItem
    {
        public string Texto { get; set; }
        public bool Valor { get; set; }

        public EstadoItem(string texto, bool valor)
        {
            Texto = texto;
            Valor = valor;
        }

        public override string ToString()
        {
            return Texto;
        }
    }

}
