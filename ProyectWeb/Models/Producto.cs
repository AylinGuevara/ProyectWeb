using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectWeb.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public int UnidadMedidaId { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public decimal PrecioCompra { get; set; }

        
    }
}