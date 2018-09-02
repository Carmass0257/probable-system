using AutoMapper;

namespace CM.TesteAspNetMvc.Aplicacao.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x => { x.AddProfile<DomainToViewModelMappingProfile>(); });
        }
    }
}