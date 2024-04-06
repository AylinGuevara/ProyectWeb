using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectWeb.Models
{
    [Table("Factura")]

    public class Factura
    {
        [Key]

        public int FacturaId { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        public int PedidoId { get; set; }

        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaFactura { get; set; }

        public bool Estado { get; set; }

        public decimal Total { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

    }
}