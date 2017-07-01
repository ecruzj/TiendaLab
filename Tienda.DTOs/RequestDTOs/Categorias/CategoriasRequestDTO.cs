using ServiceStack;
using System.Collections.Generic;
using Tienda.DTOs.Clases;

namespace Tienda.DTOs.RequestDTOs.Categorias
{
    [Route("/categorias/", "GET")]
    public class GetAllCategorias : RequestBase, IReturn<List<CategoriasDTO>>
    {
    }
}
