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
        [Display(Name = "Factura Id")]
        public int FacturaId { get; set; }

        [Display(Name = "Cliente Id")]
        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Display(Name = "Pedido Id")]
        public int PedidoId { get; set; }

        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }
        [Display(Name = "Fecha Factura")]
        public DateTime FechaFactura { get; set; }

        public bool Estado { get; set; }

        public decimal Total { get; set; }
        [Display(Name = "Sub Total")]
        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

    }
}