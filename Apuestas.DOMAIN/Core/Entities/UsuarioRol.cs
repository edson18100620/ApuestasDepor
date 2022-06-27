using System;
using System.Collections.Generic;

namespace ApuestasDepor.DOMAIN.Core.Entities
{
    public partial class UsuarioRol
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public int? RolId { get; set; }

        public virtual Rol? Rol { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
