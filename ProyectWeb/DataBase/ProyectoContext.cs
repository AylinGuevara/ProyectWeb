using ProyectWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProyectWeb.DataBase
{
    public class ProyectoContext:DbContext
    {
        public ProyectoContext():base("name=Proyecto")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

        }
        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<CondicionPago> CondicionPago { get; set; }

        public DbSet<GrupoDescuento> GrupoDescuento { get; set; }
        public DbSet<UnidadMedida> UnidadMedida { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
    }
}