using System.Data.Entity.ModelConfiguration;
using Tienda.Entidades.Entorno.Entidades;

namespace Tienda.Entidades.Entorno.Mapeos
{
    public class CategoriasMap : EntityTypeConfiguration<Categorias>
    {
        public CategoriasMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoriaId);

            // Properties
            this.Property(t => t.Descripcion)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Categorias");
            this.Property(t => t.CategoriaId).HasColumnName("CategoriaId");
            this.Property(t => t.Descripcion).HasColumnName("Descripcion");
        }
    }
}
