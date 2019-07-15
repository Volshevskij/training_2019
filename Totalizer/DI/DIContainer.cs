using BusinessLogickLayer;
using BusinessLogickLayer.Cacher;
using BusinessLogickLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Helpers;
using DataAccessLayer.Interfaces;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace DI
{
    public class DIContainer
    {
        public static UnityContainer UpdateContainer(UnityContainer container)
        {
            container.RegisterType<ISqlHelper, SqlHelper>(new HierarchicalLifetimeManager());
            container.RegisterType<IMemoryCacher, MemoryCacher>(new HierarchicalLifetimeManager());

            container.RegisterType<IBetRepository, BetRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ISqlHelper>()));
            container.RegisterType<ICountryRepository, CountryRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ISqlHelper>()));
            container.RegisterType<IEventRepository, EventRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ISqlHelper>()));
            container.RegisterType<IPersonRepository, PersonRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ISqlHelper>()));
            container.RegisterType<ISportTypeRepository, SportTypeRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ISqlHelper>()));
            container.RegisterType<ITeamRepository, TeamRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ISqlHelper>()));
            container.RegisterType<IRoleRepository, RoleRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ISqlHelper>()));

            container.RegisterType<IBetService, BetService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<IBetRepository>()));
            container.RegisterType<ICountryService, CountryService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ICountryRepository>(), container.Resolve<IMemoryCacher>()));
            container.RegisterType<IEventService, EventService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<IEventRepository>()));
            container.RegisterType<IPersonService, PersonService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<IPersonRepository>()));
            container.RegisterType<ISportTypeService, SportTypeService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ISportTypeRepository>(), container.Resolve<IMemoryCacher>()));
            container.RegisterType<ITeamService, TeamService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<ITeamRepository>(), container.Resolve<IMemoryCacher>()));
            container.RegisterType<IRoleService, RoleService>(new HierarchicalLifetimeManager(), new InjectionConstructor(container.Resolve<IRoleRepository>(), container.Resolve<IMemoryCacher>()));

            return container;
        }
    }
}
