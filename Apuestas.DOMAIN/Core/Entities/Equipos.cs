using ApuestasDepor.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;

namespace ApuestasDepor.DOMAIN.Core.Entities
{
    public partial class Equipos
    {
        public Equipos()
        {
            Apuesta = new HashSet<Apuesta>();
            PartidoEquipoLoc = new HashSet<Partido>();
            PartidoEquipoVis = new HashSet<Partido>();
        }

        public int Id { get; set; }
        public int? PaisId { get; set; }
        public string? Nombre { get; set; }

        public virtual Pais? Pais { get; set; }
        public virtual ICollection<Apuesta> Apuesta { get; set; }
        public virtual ICollection<Partido> PartidoEquipoLoc { get; set; }
        public virtual ICollection<Partido> PartidoEquipoVis { get; set; }
    }
}
