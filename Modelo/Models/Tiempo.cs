using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Models
{
    public partial class Tiempo
    {
        [Key]
        public int IdTiempo { get; set; }

        [Required]
        [ForeignKey("Pedido")]
        public int IdPedido { get; set; }

        [Required]
        public DateTime Inicio { get; set; }

        public DateTime? Fin { get; set; }

        [Required]
        [MaxLength(50)]
        public string Fase { get; set; } = null!;

        public virtual Pedido Pedido { get; set; } = null!;
    }
}
