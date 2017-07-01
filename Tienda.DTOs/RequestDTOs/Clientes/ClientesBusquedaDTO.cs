using System.Collections.Generic;
using Tienda.DTOs.Clases;

namespace Tienda.DTOs.RequestDTOs.Clientes
{
    public class ClientesBusquedaDTO : BusquedaResponseBase
    {
        public List<ClientesDTO> ListaClientes { get; set; }
    }
}
