using System;

namespace Tienda.Entidades.Entorno.Entidades
{
    public partial class Articulos
    {
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> Costo { get; set; }
        public Nullable<decimal> Precio { get; set; }
        public Nullable<decimal> PrecioA { get; set; }
        public Nullable<int> CategoriaId { get; set; }
        public virtual Categorias Categoria { get; set; }
    }
}
