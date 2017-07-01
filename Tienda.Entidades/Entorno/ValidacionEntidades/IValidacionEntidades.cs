using System.Collections.Generic;

namespace Tienda.Entidades.Entorno.ValidacionEntidades
{
    public interface IValidacionEntidades
    {
        IEnumerable<string> GetValidationErrors();
        IEnumerable<string> GetValidationErrorsDelete();
    }
}
