using CM.TesteAspNetMvc.Aplicacao.Interfaces;
using CM.TesteAspNetMvc.Aplicacao.Services;
using CM.TesteAspNetMvc.Dominio.Interfaces.Repositorio;
using CM.TesteAspNetMvc.Dominio.Interfaces.Serviço;
using CM.TesteAspNetMvc.Dominio.Servicos;
using CM.TesteAspNetMvc.Infra.Dados.Contexto;
using CM.TesteAspNetMvc.Infra.Dados.Interfaces;
using CM.TesteAspNetMvc.Infra.Dados.Repositorio;
using CM.TesteAspNetMvc.Infra.Dados.UoW;
using SimpleInjector;

namespace CM.TesteAspNetMvc.Infra.Transversal
{
    public class SimpleInjectorBootStrapper
    {
        public static void Register(Container container)
        {
            //Aplicação
            container.Register<IDetalheUsuarioAppService, DetalheUsuarioAppService>(Lifestyle.Scoped);
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);

            //Dominio
            container.Register<IUsuarioServico, UsuarioServico>(Lifestyle.Scoped);
            container.Register<IDetalheServico, DetalheUsuarioServico>(Lifestyle.Scoped);

            //Infraestrutura
            container.Register<IUsuarioRepositorio,UsuarioRepositorio>(Lifestyle.Scoped);
            container.Register<IDetalheRepositorio, DetalheUsuarioRepositorio>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<TesteAspNetMvcContexto>(Lifestyle.Scoped);
        }
    }
}