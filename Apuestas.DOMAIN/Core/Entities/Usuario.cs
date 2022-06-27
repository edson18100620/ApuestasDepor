using ApuestasDepor.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;

namespace ApuestasDepor.DOMAIN.Core.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            Apuesta = new HashSet<Apuesta>();
            Promocion = new HashSet<Promocion>();
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public int Id { get; set; }
        public int? PaisId { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Genero { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Correo { get; set; }

        public virtual Pais? Pais { get; set; }
        public virtual ICollection<Apuesta> Apuesta { get; set; }
        public virtual ICollection<Promocion> Promocion { get; set; }
        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
