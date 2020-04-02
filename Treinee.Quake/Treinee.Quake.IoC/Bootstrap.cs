using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Treinee.Quake.Domain.Repository;
using Treinee.Quake.Infra.Context;
using Treinee.Quake.Infra.Repository;

namespace Treinee.Quake.IoC
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection servicos, IConfiguration Configuration)
        {
            servicos.AddDbContext<QuakeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            servicos.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            servicos.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            servicos.AddTransient<IRepositoryDeath, RepositoryDeath>();
        }
    }
}
