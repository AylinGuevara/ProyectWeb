using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectWeb.Models
{
    [Table("GrupoDescuento")]
    public class GrupoDescuento
    {
        [Key]
        [Display(Name = "Grupo Descuento Id")]
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
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }
    }
}