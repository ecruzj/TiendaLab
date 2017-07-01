using ServiceStack;
using Tienda.DTOs.RequestDTOs.Clientes;
using Tienda.Servicios.AppServices;

namespace Tienda.Web.Api
{
    public class ClientesRestService : IService
    {
        IClientesAppServices _clientesAppServices;

        public ClientesRestService(IClientesAppServices clientesAppServices)
        {
            _clientesAppServices = clientesAppServices;
        }

        public object Get(GetClientes request)
        {
            return _clientesAppServices.Get(request);
        }

        public object Post(PostCliente request)
        {
            return _clientesAppServices.Post(request);
        }

        public object Put(PutCliente request)
        {
            return _clientesAppServices.Put(request);
        }

        public object Delete(DeleteCliente request)
        {
            return _clientesAppServices.Delete(request);
        }
    }
}