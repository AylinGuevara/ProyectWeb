using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectWeb.Models
{
    [Table("GrupoDescuento")]
    public class GrupoDescuento
    {
        [Key]
        public int GrupoDescuentoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public int Porcentaje { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}