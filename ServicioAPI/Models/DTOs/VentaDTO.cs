using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAPI.Models.DTOs
{
    public class VentaDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public double Valor { get; set; }

    }
}