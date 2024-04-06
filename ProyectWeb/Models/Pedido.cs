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
        public int PedidoId { get; set; }

        public int ClienteId { get; set; }
       
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public DateTime FechaCreacion{ get; set; }

        public DateTime FechaPedido { get; set; }

        [Required]
        public bool Estado { get; set; }

        public decimal Total { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }
    }
}