using System.Collections.Generic;
using Tienda.DTOs.RequestDTOs.Clientes;

namespace Tienda.Servicios.AppServices
{
    public interface IClientesAppServices
    {
        ClientesBusquedaDTO Get(GetClientes request);
        ClientesDTO Post(PostCliente request);
        ClientesDTO Put(PutCliente request);
        ClientesDTO Delete(DeleteCliente request);
    }
}
