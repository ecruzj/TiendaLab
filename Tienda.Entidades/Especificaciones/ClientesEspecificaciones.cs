using Tienda.Entidades.Core.Specification;
using Tienda.Entidades.Entorno.Entidades;

namespace Tienda.Entidades.Especificaciones
{
    public class ClientesEspecificaciones
    {
        public static Specification<Clientes> ClientesBusqueda(string valorBusqueda)
        {
            var specification = new Specification<Clientes>(c => c.ClienteId > 0);
            var valorBuscar = !string.IsNullOrWhiteSpace(valorBusqueda) ? valorBusqueda.ToUpper() : string.Empty;

            if (!string.IsNullOrWhiteSpace(valorBusqueda))
            {
                var valorBusquedaSpecification = new Specification<Clientes>(c => c.Nombre.ToUpper().Contains(valorBuscar));
                specification &= valorBusquedaSpecification;
            }

            return specification;
        }
    }
}
