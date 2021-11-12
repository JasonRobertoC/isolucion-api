using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAPI.Models.DTOs
{
    public class ItemsFacturaDTO
    {
        public int Id { get; set; }
        public int Factura { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public int ValorUnidad { get; set; }
        public int Total { get; set; }
    }
}