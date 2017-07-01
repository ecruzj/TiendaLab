using System.Collections.Generic;

namespace Tienda.Entidades.Entorno.Entidades
{
    public partial class Categorias
    {
        public Categorias()
        {
            this.Articulos = new List<Articulos>();
        }

        public int CategoriaId { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<Articulos> Articulos { get; set; }
    }
}
