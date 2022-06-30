using System;
using System.Collections.Generic;

namespace ApuestasDepor.DOMAIN.Core.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            Usuario = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public virtual ICollection<Usuario> Usuario { get; set; }

        //public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
