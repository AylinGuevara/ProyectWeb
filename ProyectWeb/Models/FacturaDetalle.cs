using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectWeb.Models
{
    [Table("FacturaDetalle")]

    public class FacturaDetalle
    {
        [Display(Name = "Factura Detalle Id")]
        public int FacturaDetalleId { get; set; }

        [Display(Name = "Factura Id")]
        public int FacturaId { get; set; }
        [ForeignKey("FacturaId")]
        public Factura Factura { get; set; }

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