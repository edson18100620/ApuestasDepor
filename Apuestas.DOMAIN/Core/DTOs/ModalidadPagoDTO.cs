using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Core.DTOs
{
    public class ModalidadPagoDTO
    {
        public int Id { get; set; }
        public string? Detalle { get; set; }

    }
    public class ModalidadPagoPostDTO
    {
        public string? Detalle { get; set; }
    }
}
