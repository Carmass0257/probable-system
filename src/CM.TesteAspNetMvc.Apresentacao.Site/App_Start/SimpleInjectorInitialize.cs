using System.Reflection;
using System.Web.Mvc;
using CM.TesteAspNetMvc.Apresentacao.Site.App_Start;
using CM.TesteAspNetMvc.Infra.Transversal;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using WebActivator;

[assembly: PostApplicationStartMethod(typeof(SimpleInjectorInitialize), "Initialize")]

namespace CM.TesteAspNetMvc.Apresentacao.Site.App_Start
{
    public static class SimpleInjectorInitialize
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle=new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }

        private static void InitializeContainer(Container container)
        {
            SimpleInjectorBootStrapper.Register(container);
        }
    }
}