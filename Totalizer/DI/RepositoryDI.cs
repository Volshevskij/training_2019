using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;
using Unity;

namespace DI
{
    public class RepositoryDI
    {
        protected static IUnityContainer container;

        public static IUnityContainer GetContainer()
        {
            container = new UnityContainer();

            container.RegisterType<IRepository<Bet>, BetRepository>();
            container.RegisterType<IRepository<Country>, CountryRepository>();
            container.RegisterType<IRepository<Event>, EventRepository>();
            container.RegisterType<IRepository<Person>, PersonRepository>();
            container.RegisterType<IRepository<SportType>, SportTypeRepository>();
            container.RegisterType<IRepository<Team>, TeamRepository>();

            return container;
        }
    }
}
