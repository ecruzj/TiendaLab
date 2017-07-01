using ServiceStack;
using Tienda.DTOs.Clases;

namespace Tienda.DTOs.RequestDTOs.Articulos
{
    [Route("/articulos/{articuloId}", "GET")]
    public class GetArticuloId : RequestBase, IReturn<ArticulosDTO>
    {
        public int ArticuloId { get; set; }
    }

    [Route("/articulos/", "POST")]
    public class PostArticulo : RequestBase, IReturn<ArticulosDTO>
    {
        public ArticulosDTO Articulo { get; set; }
    }

    [Route("/articulos/", "PUT")]
    public class PutArticulo : RequestBase, IReturn<ArticulosDTO>
    {
        public ArticulosDTO Articulo { get; set; }
    }

    [Route("/articulos/eliminar", "DELETE")]
    public class DeleteArticulo : RequestBase, IReturn<ArticulosDTO>
    {
        public int ArticuloId { get; set; }
    }
}
