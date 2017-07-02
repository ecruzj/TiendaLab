using System.Collections.Generic;
using System.Linq;
using Tienda.DTOs.RequestDTOs.Categorias;
using Tienda.Entidades.Entorno;
using Tienda.Entidades.Entorno.Entidades;
using Tienda.Servicios.Helpers;

namespace Tienda.Servicios.AppServices
{
    public class CategoriasAppServices : ICategoriasAppServices
    {
        TiendaNContext _unitOfWork;

        public CategoriasAppServices(TiendaNContext unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<CategoriasDTO> Get(GetAllCategorias request)
        {
            var categorias = _unitOfWork.Categorias.ToList();
            var categoriasDto = AutomapperTypeAdapter.ProyectarColeccionComo<IEnumerable<Categorias>, IEnumerable<CategoriasDTO>>(categorias);

            return categoriasDto.ToList();
        }
    }
}
