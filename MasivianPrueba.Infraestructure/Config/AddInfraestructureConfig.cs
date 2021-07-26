using MasivianPrueba.Core.Entitiy;
using MasivianPrueba.Core.Interface.Repository;
using MasivianPrueba.Core.Interface.Service;
using MasivianPrueba.Infraestructure.Data;
using MasivianPrueba.Infraestructure.Repository;
using MasivianPrueba.Infraestructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MasivianPrueba.Infraestructure.Config
{
    public static class AddInfraestructureConfig
    {
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration Configuration)
        {
            #region dbContext
            services.AddDbContext<AppDbContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("MasivianConnection"),
                       b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
            #endregion dbContext
            #region Data
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepository<Roulette>, Repository<Roulette>>();
            services.AddTransient<IRepository<Bet>, Repository<Bet>>();

            #endregion Data
            #region Services
            services.AddTransient<IRouletteService, RouletteService>();
            #endregion Service
        }
    }
}
