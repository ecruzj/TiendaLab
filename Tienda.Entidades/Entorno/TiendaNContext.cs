using System.Data.Entity;
using Tienda.Entidades.Entorno.Entidades;
using Tienda.Entidades.Entorno.Mapeos;

namespace Tienda.Entidades.Entorno
{
    public partial class TiendaNContext : DbContext
    {
        static TiendaNContext()
        {
            Database.SetInitializer<TiendaNContext>(null);
        }

        public TiendaNContext()
            : base("Name=TiendaNContext")
        {
        }

        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<FacturaEncabezado> FacturaEncabezadoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ArticulosMap());
            modelBuilder.Configurations.Add(new CategoriasMap());
            modelBuilder.Configurations.Add(new ClientesMap());
            modelBuilder.Configurations.Add(new FacturaEncabezadoMap());
        }
    }
}
