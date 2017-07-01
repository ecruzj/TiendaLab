using ServiceStack;
using System.Collections.Generic;
using Tienda.DTOs.Clases;

namespace Tienda.DTOs.RequestDTOs.Clientes
{
    [Route("/clientes/valor-busqueda", "GET")]
    public class GetClientes : BusquedaRequestBase, IReturn<ClientesBusquedaDTO>
    {
    }

    [Route("/clientes/", "POST")]
    public class PostCliente : RequestBase, IReturn<ClientesDTO>
    {
        public ClientesDTO Cliente { get; set; }
    }

    [Route("/clientes/", "PUT")]
    public class PutCliente : RequestBase, IReturn<ClientesDTO>
    {
        public ClientesDTO Cliente { get; set; }
    }

    [Route("/clientes/eliminar", "DELETE")]
    public class DeleteCliente : RequestBase, IReturn<ClientesDTO>
    {
        public int ClienteId { get; set; }
    }
}
