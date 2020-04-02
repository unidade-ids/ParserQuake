using Amazon.OpsWorks.Model;
using Microsoft.EntityFrameworkCore;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Treinee.Quake.Domain.Repository;
using Treinee.Quake.Infra.Context;
using Treinee.Quake.Infra.Repository;

namespace Trainee.Feed.Config
{
    public class Factory
    {
        public static Container Container;
        public static void Start()
        {
            Container = new Container();

            Container.Options.DefaultLifestyle = new ThreadScopedLifestyle();

            Container.Register(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            Container.Register<IRepositorioPlayer, RepositorioPlayer>();
            Container.Register<IRepositorioGamePlayer, RepositorioGamePlayer>();


            Container.Register<IUnitOfWork, UnitOfWork>();

            Container.Verify();
        }
    }
}
