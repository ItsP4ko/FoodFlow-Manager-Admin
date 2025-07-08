using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Models
{
    public partial class CajeroRestaurante : Persona
    {
        [ForeignKey("Restaurante")]
        public int? IdRestaurante { get; set; }

        public virtual Restaurante? Restaurante { get; set; }
    }
}
