using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Core.DTOs
{
    public class EquiposDTO
    {
        public int Id { get; set; }
        public int? PaisId { get; set; }
        public string? Nombre { get; set; }
    }
    public class EquiposPostDTO
    {
        public int? PaisId { get; set; }
        public string? Nombre { get; set; }
    }
}
