using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Core.DTOs
{
    public class PartidoDTO
    {
        public int Id { get; set; }
        public int? EquipoLocId { get; set; }
        public int? EquipoVisId { get; set; }
        public int? CategoriaId { get; set; }
        public double? CuotaLoc { get; set; }
        public double? CuotaVis { get; set; }

    }
    public class PartidoPostDTO
    {
        public int? EquipoLocId { get; set; }
        public int? EquipoVisId { get; set; }
        public int? CategoriaId { get; set; }
        public double? CuotaLoc { get; set; }
        public double? CuotaVis { get; set; }
    }
}
