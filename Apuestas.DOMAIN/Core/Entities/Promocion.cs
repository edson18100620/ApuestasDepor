using ApuestasDepor.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;

namespace ApuestasDepor.DOMAIN.Core.Entities
{
    public partial class Promocion
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Detalle { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public int? CodUsuario { get; set; }
        public int? CodAudioVisual { get; set; }

        public virtual AudioVisual? CodAudioVisualNavigation { get; set; }
        public virtual Usuario? CodUsuarioNavigation { get; set; }
    }
}
