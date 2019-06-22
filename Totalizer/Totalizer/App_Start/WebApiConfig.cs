using BusinessLogickLayer;
using BusinessLogickLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using Totalizer.Dependensy_Injection;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Totalizer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API

            var container = new UnityContainer();

            container.RegisterType<IBetRepository, BetRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICountryRepository, CountryRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IEventRepository, EventRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IPersonRepository, PersonRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISportTypeRepository, SportTypeRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITeamRepository, TeamRepository>(new HierarchicalLifetimeManager());

            container.RegisterType<IBetService, BetService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<IBetRepository>()));
            container.RegisterType<ICountryService, CountryService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ICountryRepository>()));
            container.RegisterType<IEventService, EventService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<IEventRepository>()));
            container.RegisterType<IPersonService, PersonService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<IPersonRepository>()));
            container.RegisterType<ISportTypeService, SportTypeService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ISportTypeRepository>()));
            container.RegisterType<ITeamService, TeamService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ITeamRepository>()));

            config.DependencyResolver = new UnityResolver(container);

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
