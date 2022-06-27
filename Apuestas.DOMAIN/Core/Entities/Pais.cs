using System;
using System.Collections.Generic;

namespace ApuestasDepor.DOMAIN.Core.Entities
{
    public partial class Pais
    {
        public Pais()
        {
            Equipos = new HashSet<Equipos>();
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int? CodPostal { get; set; }

        public virtual ICollection<Equipos> Equipos { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }
    }
}
