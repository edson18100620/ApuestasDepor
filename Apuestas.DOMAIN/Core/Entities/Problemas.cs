using ApuestasDepor.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;

namespace ApuestasDepor.DOMAIN.Core.Entities
{
    public partial class Problemas
    {
        public int Id { get; set; }
        public int? CodUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Detalle { get; set; }
        public bool? Estado { get; set; }
        public int? CodAudioVisual { get; set; }

        public virtual AudioVisual? CodAudioVisualNavigation { get; set; }
        public virtual Usuario? CodUsuarioNavigation { get; set; }
    }
}
