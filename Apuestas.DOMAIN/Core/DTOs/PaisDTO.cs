using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Core.DTOs
{
    public class PaisDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? CodPostal { get; set; }
    }
    public class PaisPostDTO
    {
        public string? Nombre { get; set; }
        public int? CodPostal { get; set; }
    }
}
