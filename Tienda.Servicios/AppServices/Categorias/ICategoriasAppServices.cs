using System.Collections.Generic;
using Tienda.DTOs.RequestDTOs.Categorias;

namespace Tienda.Servicios.AppServices
{
    public interface ICategoriasAppServices
    {
        List<CategoriasDTO> Get(GetAllCategorias request);
    }
}
