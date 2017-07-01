using System.Data.Entity.ModelConfiguration;
using Tienda.Entidades.Entorno.Entidades;

namespace Tienda.Entidades.Entorno.Mapeos
{
    public class FacturaEncabezadoMap : EntityTypeConfiguration<FacturaEncabezado>
    {
        public FacturaEncabezadoMap()
        {
            // Primary Key
            this.HasKey(t => t.FacturaId);

            // Properties
            // Table & Column Mappings
            this.ToTable("FacturaEncabezado");
            this.Property(t => t.FacturaId).HasColumnName("FacturaId");
            this.Property(t => t.FechaTransaccion).HasColumnName("FechaTransaccion");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");

            // Relationships
            this.HasOptional(t => t.Cliente)
                .WithMany(t => t.FacturasEncabezado)
                .HasForeignKey(d => d.ClienteId);

        }
    }
}
