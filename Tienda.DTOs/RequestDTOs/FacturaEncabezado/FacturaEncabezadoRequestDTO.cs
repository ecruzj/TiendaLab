using ServiceStack;
using System.Collections.Generic;
using Tienda.DTOs.Clases;

namespace Tienda.DTOs.RequestDTOs.FacturaEncabezado
{
    [Route("/factura-encabezado/facturas-por-cliente/{clienteId}", "GET")]
    public class GetAllFacturasPorCliente : RequestBase, IReturn<List<FacturaEncabezadoDTO>>
    {
        public int ClienteId { get; set; }
    }

    [Route("/factura-encabezado/", "POST")]
    public class PostFacturaEncabezado : RequestBase, IReturn<FacturaEncabezadoDTO>
    {
        public FacturaEncabezadoDTO FacturaEncabezado { get; set; }
    }

    [Route("/factura-encabezado/", "PUT")]
    public class PutFacturaEncabezado : RequestBase, IReturn<FacturaEncabezadoDTO>
    {
        public FacturaEncabezadoDTO FacturaEncabezado { get; set; }
    }

    [Route("/factura-encabezado/delete", "DELETE")]
    public class DeleteFacturaEncabezado : RequestBase, IReturn<FacturaEncabezadoDTO>
    {
        public int FacturaEncabezadoId { get; set; }
    }
}
