using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectWeb.Models
{
    [Table("FacturaDetalle")]

    public class FacturaDetalle
    {
        public int FacturaDetalleId { get; set; }

        public int FacturaId { get; set; }
        [ForeignKey("FacturaId")]
        public Factura Factura { get; set; }

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