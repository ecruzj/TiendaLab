using System;

namespace Tienda.Entidades.Entorno.Entidades
{
    public partial class FacturaEncabezado
    {
        public int FacturaId { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public Nullable<int> ClienteId { get; set; }
        public virtual Clientes Cliente { get; set; }
    }
}
