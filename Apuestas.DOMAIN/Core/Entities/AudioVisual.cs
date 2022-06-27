
using System;
using System.Collections.Generic;

namespace ApuestasDepor.DOMAIN.Core.Entities
{
    public partial class AudioVisual
    {
        public AudioVisual()
        {
            Promocion = new HashSet<Promocion>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Promocion> Promocion { get; set; }
    }
}
