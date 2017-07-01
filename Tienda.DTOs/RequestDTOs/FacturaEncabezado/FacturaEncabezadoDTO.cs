using System;

namespace Tienda.DTOs.RequestDTOs.FacturaEncabezado
{
    public class FacturaEncabezadoDTO
    {
        public int FacturaId { get; set; }
        public Nullable<System.DateTime> FechaTransaccion { get; set; }
        public Nullable<int> ClienteId { get; set; }

        public string NombreCliente { get; set; }
    }
}
