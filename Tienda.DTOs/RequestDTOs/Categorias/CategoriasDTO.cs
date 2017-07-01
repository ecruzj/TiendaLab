using Tienda.DTOs.Clases;

namespace Tienda.DTOs.RequestDTOs.Categorias
{
    public class CategoriasDTO : ResponseBase
    {
        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
    }
}
