using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectWeb.Models
{
    [Table("PedidoDetalle")]

    public class PedidoDetalle
    {
        [Display(Name = "Pedido Detalle Id")]
        public int PedidoDetalleId { get; set; }

        [Display(Name = "Pedido Id")]
        public int PedidoId { get; set; }
        [ForeignKey("PedidoId")]
        public Pedido Pedido { get; set; }

        [Display(Name = "Fecha Creacion")]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Producto Id")]
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]

        public Producto Producto { get; set; }

        public decimal Precio { get; set; }

        public decimal Total { get; set; }

        [Display(Name = "Sub Total")]
        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }
    }

}