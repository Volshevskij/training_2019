using BusinessLogickLayer;
using BusinessLogickLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Microsoft.Owin.Security.OAuth;
using Models;
using System.Web.Http;
using Totalizer.Dependensy_Injection;
using Unity;
using Unity.Lifetime;

namespace Totalizer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API

            var container = new UnityContainer();

            container.RegisterType<IRepository<Bet>, SqlServerBetModelAccess>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Country>, SqlServerCountryModelAccess>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Event>, SqlServerEventModelAccess>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Person>, SqlServerPersonModelAccess>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<SportType>, SqlServerSportTypeModelAccess>(new HierarchicalLifetimeManager());
            container.RegisterType<IRepository<Team>, SqlServerTeamModelAccess>(new HierarchicalLifetimeManager());

            container.RegisterType<ILogickRepository<Bet>, BetConnector>(new HierarchicalLifetimeManager());
            container.RegisterType<ILogickRepository<Country>, CountryConnector>(new HierarchicalLifetimeManager());
            container.RegisterType<ILogickRepository<Event>, EventConnector>(new HierarchicalLifetimeManager());
            container.RegisterType<ILogickRepository<Person>, PersonConnector>(new HierarchicalLifetimeManager());
            container.RegisterType<ILogickRepository<SportType>, SportTypeConnector>(new HierarchicalLifetimeManager());
            container.RegisterType<ILogickRepository<Team>, TeamConnector>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityResolver(container);

            //IContainer container = IoC.Initialize();
            //StructureMapDependencyScope = new StructureMapDependencyScope(container);
            //DependencyResolver.SetResolver(StructureMapDependencyScope);
            //DynamicModuleUtility.RegisterModule(typeof(StructureMapScopeModule));

            config.EnableCors();
            // Настройка Web API для использования только проверки подлинности посредством маркера-носителя.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Маршруты Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
