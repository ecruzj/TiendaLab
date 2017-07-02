using ServiceStack.ServiceHost;
using Tienda.DTOs.RequestDTOs.Categorias;
using Tienda.Servicios.AppServices;

namespace Tienda.Web.Api
{
    public class CategoriasRestService : IService
    {
        ICategoriasAppServices _categoriasAppServices;

        public CategoriasRestService(ICategoriasAppServices categoriasAppServices)
        {
            _categoriasAppServices = categoriasAppServices;
        }

        public object Get(GetAllCategorias request)
        {
            return _categoriasAppServices.Get(request);
        }
    }
}