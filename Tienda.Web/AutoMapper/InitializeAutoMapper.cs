using AutoMapper;
using Tienda.DTOs.RequestDTOs.Articulos;
using Tienda.DTOs.RequestDTOs.Categorias;
using Tienda.DTOs.RequestDTOs.Clientes;
using Tienda.DTOs.RequestDTOs.FacturaEncabezado;
using Tienda.Entidades.Entorno.Entidades;

namespace Tienda.Web.AutoMapper
{
    public static class InitializeAutoMapper
    {

        public static void InitializarAutomap()
        {
            Mapper.Initialize(map =>
            {
                map.CreateMap<Clientes, ClientesDTO>();
                var mapArticulos = map.CreateMap<Articulos, ArticulosDTO>();
                mapArticulos.ForMember(dto => dto.DescripcionCategoria, mce => mce.MapFrom(exp => exp.Categoria.Descripcion));

                map.CreateMap<Categorias, CategoriasDTO>();
                map.CreateMap<FacturaEncabezado, FacturaEncabezadoDTO>();

            });
        }
    }
}