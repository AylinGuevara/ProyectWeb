using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectWeb.Models
{
    [Table("UnidadMedida")]
    public class UnidadMedida

    {
        [Key]
        public int UnidadMedidaId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }
        
        [Required]
        public bool Estado  { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }
    }
}