using System;
using System.Collections.Generic;
using System.Linq;
using Tienda.Entidades.Entorno.ValidacionEntidades;
using Tienda.Entidades.Recursos;

namespace Tienda.Entidades.Entorno.Entidades
{
    public partial class Clientes : IValidacionEntidades
    {
        public Clientes(string nombre)
        {
            this.Nombre = nombre;
            this.UltimaVisita = DateTime.Now;

            this.FacturasEncabezado = new List<FacturaEncabezado>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> UltimaVisita { get; set; }
        public virtual ICollection<FacturaEncabezado> FacturasEncabezado { get; set; }

        public void ActualizarCliente(string nombre, DateTime? ultimaVisita)
        {
            this.Nombre = nombre;
            this.UltimaVisita = ultimaVisita;
        }

        private string ValidarEliminarCliente()
        {
            if (FacturasEncabezado.Any())
            {
                return "El Cliente tiene Facturas registradas";
            }

            return string.Empty;
        } 

        public IEnumerable<string> GetValidationErrors()
        {
            var listaErrores = new List<string>();

            if (string.IsNullOrWhiteSpace(Nombre))
            {
                var mensaje = string.Format(EntityValidations.Campo_Requerido, "Nombre Cliente");
                listaErrores.Add(mensaje);
            }

            return listaErrores;
        }

        public IEnumerable<string> GetValidationErrorsDelete()
        {
            var listaErrores = new List<string>();

            var validarCliente = ValidarEliminarCliente();

            if (!string.IsNullOrWhiteSpace(validarCliente))
            {
                listaErrores.Add(validarCliente);
            }

            return listaErrores;
        }


    }
}
