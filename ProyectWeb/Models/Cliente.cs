using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectWeb.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Display(Name = "Cliente Id")]
        public int ClienteId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombres { get; set; }

        [Required]
        [MaxLength(50)]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "Grupo Descuento Id")]
        public int GrupoDescuentoId { get; set; }

        [ForeignKey("GrupoDescuentoId")]
        public GrupoDescuento GrupoDescuento { get; set; }

        [Display(Name = "Condicion Pago Id")]
        public int CondicionPagoId { get; set; }

        [ForeignKey("CondicionPagoId")]
        public CondicionPago CondicionPago { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }
    }
}