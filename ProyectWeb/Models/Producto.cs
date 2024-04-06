using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public Categoria CategoriaId { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public UnidadMedida UnidadMedidaId { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public decimal PrecioCompra { get; set; }

        
    }
}