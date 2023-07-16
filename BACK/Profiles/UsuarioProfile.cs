using AutoMapper;
using QuadroKanban.Data.DTO;
using QuadroKanban.Model;

namespace QuadroKanban.Profiles;

public class UsuarioProfile: Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Login));
    }
}
