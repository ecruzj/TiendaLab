using System.Data.Entity.ModelConfiguration;
using Tienda.Entidades.Entorno.Entidades;

namespace Tienda.Entidades.Entorno.Mapeos
{
    public class ClientesMap : EntityTypeConfiguration<Clientes>
    {
        public ClientesMap()
        {
            // Primary Key
            this.HasKey(t => t.ClienteId);

            // Properties
            this.Property(t => t.Nombre)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Clientes");
            this.Property(t => t.ClienteId).HasColumnName("ClienteId");
            this.Property(t => t.Nombre).HasColumnName("Nombre");
            this.Property(t => t.UltimaVisita).HasColumnName("UltimaVisita");
        }
    }
}
