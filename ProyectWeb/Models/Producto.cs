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
        [Display(Name = "Producto Id")]
        public int ProductoId { get; set; }

        [Display(Name = "Categoria Id")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }

        [Display(Name = "Unidad Medida Id")]
        public int UnidadMedidaId { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public UnidadMedida UnidadMedida { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        [Display(Name = "Precio Compra")]
        public decimal PrecioCompra { get; set; }

        
    }
}