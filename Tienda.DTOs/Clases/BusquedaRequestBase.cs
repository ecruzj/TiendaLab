namespace Tienda.DTOs.Clases
{
    public class BusquedaRequestBase : RequestBase
    {
        public int CantidadRegistros { get; set; }
        public int PaginaActual { get; set; }
        public string Filtro { get; set; }
    }
}
