using Modelo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Interfacez
{
    public interface IEstadoPedido
    {
        void Manejar(Pedido pedido);

        string ObtenerNombreEstado();
    }
}
