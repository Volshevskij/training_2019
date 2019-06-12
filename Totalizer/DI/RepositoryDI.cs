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

            container.RegisterType<IRepository<Bet>, SqlServerBetModelAccess>();
            container.RegisterType<IRepository<Country>, SqlServerCountryModelAccess>();
            container.RegisterType<IRepository<Event>, SqlServerEventModelAccess>();
            container.RegisterType<IRepository<Person>, SqlServerPersonModelAccess>();
            container.RegisterType<IRepository<SportType>, SqlServerSportTypeModelAccess>();
            container.RegisterType<IRepository<Team>, SqlServerTeamModelAccess>();

            return container;
        }
    }
}
