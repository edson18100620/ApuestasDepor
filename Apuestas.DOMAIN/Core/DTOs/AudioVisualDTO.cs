using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Core.DTOs
{
    public class AudioVisualDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
    public class AudioVisualPostDTO
    {
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
