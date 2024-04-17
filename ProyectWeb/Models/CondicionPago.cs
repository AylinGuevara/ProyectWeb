using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectWeb.Models
{
    [Table("CondicionPago")]
    public class CondicionPago
    {
        [Key]
        [Display(Name = "Condicion Pago Id")]
        public int CondicionPagoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public int Dias { get; set; }

        [Required]
        [Display(Name = "Fecha Creacion")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
    }
}