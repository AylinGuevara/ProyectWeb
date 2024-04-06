namespace ProyectWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaFacturaDetalle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FacturaDetalle",
                c => new
                    {
                        FacturaDetalleId = c.Int(nullable: false, identity: true),
                        FacturaId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FacturaDetalleId)
                .ForeignKey("dbo.Factura", t => t.FacturaId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => t.FacturaId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FacturaDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.FacturaDetalle", "FacturaId", "dbo.Factura");
            DropIndex("dbo.FacturaDetalle", new[] { "ProductoId" });
            DropIndex("dbo.FacturaDetalle", new[] { "FacturaId" });
            DropTable("dbo.FacturaDetalle");
        }
    }
}
