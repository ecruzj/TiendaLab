using System;
using Tienda.DTOs.Clases;

namespace Tienda.DTOs.RequestDTOs.Clientes
{
    public class ClientesDTO : ResponseBase
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> UltimaVisita { get; set; }
    }
}
