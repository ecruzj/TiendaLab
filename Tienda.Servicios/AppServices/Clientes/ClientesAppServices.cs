using System.Collections.Generic;
using System.Linq;
using Tienda.DTOs.RequestDTOs.Clientes;
using Tienda.Entidades.Core.Specification;
using Tienda.Entidades.Entorno;
using Tienda.Entidades.Entorno.Entidades;
using Tienda.Entidades.Especificaciones;
using Tienda.Servicios.Helpers;

namespace Tienda.Servicios.AppServices
{
    public class ClientesAppServices : IClientesAppServices
    {
        TiendaNContext _unitOfWork;

        public ClientesAppServices(TiendaNContext unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public ClientesBusquedaDTO Get(GetClientes request)
        {
            var pagina = request.PaginaActual == 0 ? 1 : request.PaginaActual;
            var clientSpecification = ClientesEspecificaciones.ClientesBusqueda(request.Filtro);
            List<Clientes> datosCliente = _unitOfWork.Clientes.Where(clientSpecification.EvalFunc).OrderBy(n => n.Nombre).ToList();
            var datosPaginados = datosCliente.Paginar(pagina, request.CantidadRegistros);

            var datosDto =
                AutomapperTypeAdapter.ProyectarColeccionComo<IEnumerable<Clientes>, IEnumerable<ClientesDTO>>(datosPaginados.Items as IEnumerable<Clientes>);

            var dto = new ClientesBusquedaDTO
            {
                PaginaActual = pagina,
                TotalPagina = datosPaginados.TotalPagina,
                TotalRegistros = datosPaginados.TotalRegistros,
                ListaClientes = new List<ClientesDTO>(datosDto)
            };

            return dto;
        }

        public ClientesDTO Post(PostCliente request)
        {
            var cliente = _unitOfWork.Clientes.Find(request.Cliente.ClienteId);

            if (cliente != null)
            {
                return new ClientesDTO
                {
                    ValidationErrorMessage = "ClienteId YA existe!"
                };
            }

            cliente = new Clientes(request.Cliente.Nombre);

            var mensajeValidacion = cliente.GetValidationErrors();

            if (mensajeValidacion.Any())
            {
                return new ClientesDTO
                {
                    ValidationErrorMessage = mensajeValidacion.FirstOrDefault()
                };
            }

            _unitOfWork.Clientes.Add(cliente);
            _unitOfWork.SaveChanges();

            return new ClientesDTO();
        }

        public ClientesDTO Put(PutCliente request)
        {
            var cliente = _unitOfWork.Clientes.Find(request.Cliente.ClienteId);

            if (cliente == null)
            {
                return new ClientesDTO
                {
                    ValidationErrorMessage = "ClienteId NO existe!"
                };
            }

            cliente.ActualizarCliente(request.Cliente.Nombre, request.Cliente.UltimaVisita);

            var mensajeValidacion = cliente.GetValidationErrors();

            if (mensajeValidacion.Any())
            {
                return new ClientesDTO
                {
                    ValidationErrorMessage = mensajeValidacion.FirstOrDefault()
                };
            }

            _unitOfWork.SaveChanges();

            return new ClientesDTO();
        }

        public ClientesDTO Delete(DeleteCliente request)
        {
            var cliente = _unitOfWork.Clientes.Find(request.ClienteId);

            if (cliente == null)
            {
                return new ClientesDTO
                {
                    ValidationErrorMessage = "ClienteId NO existe!"
                };
            }

            var mensajeValidacion = cliente.GetValidationErrorsDelete();

            if (mensajeValidacion.Any())
            {
                return new ClientesDTO
                {
                    ValidationErrorMessage = mensajeValidacion.FirstOrDefault()
                };
            }

            _unitOfWork.Clientes.Remove(cliente);
            _unitOfWork.SaveChanges();            

            return new ClientesDTO();
        }
    }
}
