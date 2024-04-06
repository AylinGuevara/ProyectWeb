using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectWeb.Models
{
    [Table("PedidoDetalle")]

    public class PedidoDetalle
    {
        public int PedidoDetalleId { get; set; }

        public int PedidoId { get; set; }
        [ForeignKey("PedidoId")]

        public Pedido Pedido { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]

        public Producto Producto { get; set; }

        public decimal Precio { get; set; }

        public decimal Total { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }
    }

}