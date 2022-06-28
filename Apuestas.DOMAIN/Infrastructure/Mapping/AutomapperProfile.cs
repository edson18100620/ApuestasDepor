using ApuestasDepor.DOMAIN.Core.DTOs;
using ApuestasDepor.DOMAIN.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestasDepor.DOMAIN.Infrastructure.Mapping
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Apuesta,ApuestaDTO>();
            CreateMap<ApuestaDTO, Apuesta>();
            CreateMap<Apuesta,ApuestaPostDTO>();
            CreateMap<ApuestaPostDTO, Apuesta>();
        }
    }
}
