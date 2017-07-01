using System.Collections;

namespace Tienda.Entidades.Core.Modelos
{
    public class Busqueda
    {
        public int PaginaActual { get; set; }

        public int TotalPagina { get; set; }

        public int TotalRegistros { get; set; }

        public IEnumerable Items { get; set; }
    }
}
