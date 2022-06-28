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

            CreateMap<AudioVisual, AudioVisualDTO>();
            CreateMap<AudioVisualDTO, AudioVisual>();
            CreateMap<AudioVisual, AudioVisualPostDTO>();
            CreateMap<AudioVisualPostDTO, AudioVisual>();

            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<CategoriaDTO, Categoria>();
            CreateMap<Categoria, CategoriaPostDTO>();
            CreateMap<CategoriaPostDTO, Categoria>();

            CreateMap<Equipos, EquiposDTO>();
            CreateMap<EquiposDTO, Equipos>();
            CreateMap<Equipos, EquiposPostDTO>();
            CreateMap<EquiposPostDTO, Equipos>();

            CreateMap<ModalidadPago, ModalidadPagoDTO>();
            CreateMap<ModalidadPagoDTO, ModalidadPago>();
            CreateMap<ModalidadPago, ModalidadPagoPostDTO>();
            CreateMap<ModalidadPagoPostDTO, ModalidadPago>();

            CreateMap<Pais, PaisDTO>();
            CreateMap<PaisDTO, Pais>();
            CreateMap<Pais, PaisPostDTO>();
            CreateMap<PaisPostDTO, Pais>();

            CreateMap<Partido, PartidoDTO>();
            CreateMap<PartidoDTO, Partido>();
            CreateMap<Partido, PartidoPostDTO>();
            CreateMap<PartidoPostDTO, Partido>();

            CreateMap<Problemas, ProblemasDTO>();
            CreateMap<ProblemasDTO, Problemas>();
            CreateMap<Problemas, ProblemasPostDTO>();
            CreateMap<ProblemasPostDTO, Problemas>();

            CreateMap<Promocion, PromocionDTO>();
            CreateMap<PromocionDTO, Promocion>();
            CreateMap<Promocion, PromocionPostDTO>();
            CreateMap<PromocionPostDTO, Promocion>();

            CreateMap<Rol, RolDTO>();
            CreateMap<RolDTO, Rol>();
            CreateMap<Rol, RolPostDTO>();
            CreateMap<RolPostDTO, Rol>();

            CreateMap<Usuario, UsuarioDTO>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuarioPostDTO>();
            CreateMap<UsuarioPostDTO, Usuario>();

            CreateMap<UsuarioRol, UsuarioRolDTO>();
            CreateMap<UsuarioRolDTO, UsuarioRol>();
            CreateMap<UsuarioRol, UsuarioRolPostDTO>();
            CreateMap<UsuarioRolPostDTO, UsuarioRol>();

        }
    }
}
