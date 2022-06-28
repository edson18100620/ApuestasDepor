using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Core.DTOs
{
    public class PromocionDTO
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Detalle { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodAudioVisual { get; set; }
    }
    public class PromocionPostDTO
    {
        public string? Titulo { get; set; }
        public string? Detalle { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodAudioVisual { get; set; }
    }
}
}
