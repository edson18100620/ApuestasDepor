using System;
using System.Collections.Generic;

namespace ApuestasDepor.DOMAIN.Core.Entities
{
    public partial class Rol
    {
        public Rol()
        {
            UsuarioRol = new HashSet<UsuarioRol>();
        }

        public int Id { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<UsuarioRol> UsuarioRol { get; set; }
    }
}
