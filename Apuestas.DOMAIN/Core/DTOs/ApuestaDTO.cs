using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Core.DTOs
{
    public class ApuestaDTO
    {
        public int Id { get; set; }
        public int? PartidoId { get; set; }
        public int? EquipoId { get; set; }
        public int? UsuarioId { get; set; }
        public int? ModalidadId { get; set; }
        public string? Detalle { get; set; }
        public decimal? Monto { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaApuesta { get; set; }
    }
    public class ApuestaPostDTO
    {
        public int? PartidoId { get; set; }
        public int? EquipoId { get; set; }
        public int? UsuarioId { get; set; }
        public int? ModalidadId { get; set; }
        public string? Detalle { get; set; }
        public decimal? Monto { get; set; }
        public bool? Estado { get; set; }
        public DateTime? FechaApuesta { get; set; }
    }
}
