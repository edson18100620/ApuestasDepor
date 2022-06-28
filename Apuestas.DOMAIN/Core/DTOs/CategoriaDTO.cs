using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Core.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }

    }
    public class CategoriaPostDTO
    {
        public string? Descripcion { get; set; }
    }
}
