using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Core.DTOs
{
    public class ProblemasDTO
    {
        public int Id { get; set; }
        public int? CodUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Detalle { get; set; }
        public bool? Estado { get; set; }
        public int? CodAudioVisual { get; set; }

    }
    public class ProblemasPostDTO
    {
        public int? CodUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Detalle { get; set; }
        public bool? Estado { get; set; }
        public int? CodAudioVisual { get; set; }
    }
}
