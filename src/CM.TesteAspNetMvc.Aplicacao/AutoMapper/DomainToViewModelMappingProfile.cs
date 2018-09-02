using AutoMapper;
using CM.TesteAspNetMvc.Aplicacao.ViewModels;
using CM.TesteAspNetMvc.Dominio.Entidades;

namespace CM.TesteAspNetMvc.Aplicacao.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Usuario, UsuarioDetalhesUsuarioViewModel>().ReverseMap();
            CreateMap<DetalheUsuario, DetalheUsuarioViewModel>().ReverseMap();
            CreateMap<DetalheUsuario, UsuarioDetalhesUsuarioViewModel>().ReverseMap();
        }
    }
}