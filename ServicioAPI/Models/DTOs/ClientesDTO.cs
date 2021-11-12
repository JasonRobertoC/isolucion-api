using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAPI.Models.DTOs
{
    public class ClientesDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string email { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public double? Facturacion { get; set; }
    }
}