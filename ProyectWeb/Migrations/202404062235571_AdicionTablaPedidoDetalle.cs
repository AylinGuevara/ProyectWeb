namespace ProyectWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionTablaPedidoDetalle : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PedidoDetalle",
                c => new
                    {
                        PedidoDetalleId = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PedidoDetalleId)
                .ForeignKey("dbo.Pedido", t => t.PedidoId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => t.PedidoId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PedidoDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.PedidoDetalle", "PedidoId", "dbo.Pedido");
            DropIndex("dbo.PedidoDetalle", new[] { "ProductoId" });
            DropIndex("dbo.PedidoDetalle", new[] { "PedidoId" });
            DropTable("dbo.PedidoDetalle");
        }
    }
}
