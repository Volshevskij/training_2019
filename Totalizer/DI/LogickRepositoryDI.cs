using BusinessLogickLayer;
using BusinessLogickLayer.Interfaces;
using Models;
using Unity;

namespace DI
{
    public class LogickRepositoryDI
    {
        protected static IUnityContainer container;

        public static IUnityContainer GetContainer()
        {
            container = new UnityContainer();

            container.RegisterType<ILogickRepository<Bet>, BetConnector>();
            container.RegisterType<ILogickRepository<Country>, CountryConnector>();
            container.RegisterType<ILogickRepository<Event>, EventConnector>();
            container.RegisterType<ILogickRepository<Person>, PersonConnector>();
            container.RegisterType<ILogickRepository<SportType>, SportTypeConnector>();
            container.RegisterType<ILogickRepository<Team>, TeamConnector>();

            return container;
        }
    }
}
