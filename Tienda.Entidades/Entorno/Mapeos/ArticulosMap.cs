using System.Data.Entity.ModelConfiguration;
using Tienda.Entidades.Entorno.Entidades;

namespace Tienda.Entidades.Entorno.Mapeos
{
    public class ArticulosMap : EntityTypeConfiguration<Articulos>
    {
        public ArticulosMap()
        {
            // Primary Key
            this.HasKey(t => t.ArticuloId);

            // Properties
            this.Property(t => t.Descripcion)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Articulos");
            this.Property(t => t.ArticuloId).HasColumnName("ArticuloId");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
            this.Property(t => t.Costo).HasColumnName("Costo");
            this.Property(t => t.Precio).HasColumnName("Precio");
            this.Property(t => t.PrecioA).HasColumnName("PrecioA");
            this.Property(t => t.CategoriaId).HasColumnName("CategoriaId");

            // Relationships
            this.HasOptional(t => t.Categoria)
                .WithMany(t => t.Articulos)
                .HasForeignKey(d => d.CategoriaId);

        }
    }
}
