using AutoMapper;

namespace Tienda.Servicios.Helpers
{
    public static class AutomapperTypeAdapter
    {
        public static TTarget ProyectarComo<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class, new()
        {
            try
            {
                var projection = Mapper.Map<TSource, TTarget>(source);
                return projection;
            }
            catch
            {
                return Mapper.Map<TSource, TTarget>(source);
            }
        }

        public static TTarget ProyectarColeccionComo<TSource, TTarget>(TSource source)
            where TSource : class
            where TTarget : class
        {
            try
            {
                var projection = Mapper.Map<TSource, TTarget>(source);
                return projection;
            }
            catch
            {
                return Mapper.Map<TSource, TTarget>(source);
            }
        }
    }
}
