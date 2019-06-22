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

            //container.RegisterType<ILogickRepository<Bet>, BetService>();
            //container.RegisterType<ILogickRepository<Country>, CountryService>();
            //container.RegisterType<ILogickRepository<Event>, EventService>();
            //container.RegisterType<ILogickRepository<Person>, PersonService>();
            //container.RegisterType<ILogickRepository<SportType>, SportTypeService>();
            //container.RegisterType<ILogickRepository<Team>, TeamService>();

            return container;
        }
    }
}
