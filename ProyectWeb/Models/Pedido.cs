using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectWeb.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [Display(Name = "Pedido Id")]
        public int PedidoId { get; set; }

        [Display(Name = "Cliente Id")]
        public int ClienteId { get; set; }
       
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Display(Name = "Fecha Creacion")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        [DataType(DataType.Date)]
        public DateTime FechaCreacion{ get; set; }

        [Display(Name = "Fecha Pedido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        [DataType(DataType.Date)]
        public DateTime FechaPedido { get; set; }

        [Required]
        public bool Estado { get; set; }

        public decimal Total { get; set; }

        [Display(Name = "Sub Total")]
        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }
    }
}