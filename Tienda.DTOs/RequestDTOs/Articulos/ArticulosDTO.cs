using System;
using Tienda.DTOs.Clases;

namespace Tienda.DTOs.RequestDTOs.Articulos
{
    public class ArticulosDTO : ResponseBase
    {
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Costo { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> PrecioA { get; set; }
        public Nullable<int> CategoriaId { get; set; }

        public string DescripcionCategoria { get; set; }
    }
}
