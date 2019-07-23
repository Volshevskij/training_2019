using DI;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Totalizer.Dependensy_Injection;
using Totalizer.Logger;
using Unity;

namespace Totalizer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы Web API

            var container = new UnityContainer();

            DIContainer.UpdateContainer(container);

            config.DependencyResolver = new UnityResolver(container);

            config.Services.Replace(typeof(IExceptionLogger), new UnhandledExceptionLogger());

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
