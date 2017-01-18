using InvestorBrowser.Repo.Repositories;

[assembly: WebActivator.PostApplicationStartMethod(typeof(InvestorBrowser.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace InvestorBrowser.App_Start
{
    using System.Reflection;
    using System.Web.Mvc;
    using Repo.EntityFramework;
    using SimpleInjector;
    using SimpleInjector.Extensions;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using AutoMapper;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            
            container.Verify();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
     
        private static void InitializeContainer(Container container)
        {
            // repositories
            container.Register<IInvestorRepository, InvestorRepository>(Lifestyle.Scoped);

            // db context
            container.Register<InvestorBrowserContext>(Lifestyle.Singleton);

            // automapper
            container.Register(() => new MapperConfiguration(AutoMapperConfig.Configure).CreateMapper(), Lifestyle.Singleton);
        }
    }
}