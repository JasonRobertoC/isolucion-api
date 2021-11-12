using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServicioAPI.Models.DTOs
{
    public class ItemsDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Valor { get; set; }
    }
}