using AutoMapper;
using ApiUsuarios.DTOs;
using ApiUsuarios.Models;

namespace ApiUsuarios.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.NombreCompleto,
                    opt => opt.MapFrom(src => src.Nombre + " " + src.Apellido));

            CreateMap<UsuarioCreateDto, Usuario>();
            CreateMap<UsuarioUpdateDto, Usuario>();
        }
    }
}