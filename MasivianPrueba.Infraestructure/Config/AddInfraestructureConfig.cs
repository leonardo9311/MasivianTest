using MasivianPrueba.Core.Entitiy;
using MasivianPrueba.Core.Interface.Repository;
using MasivianPrueba.Core.Interface.Service;
using MasivianPrueba.Infraestructure.Repository;
using MasivianPrueba.Infraestructure.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianPrueba.Infraestructure.Config
{
    public static class AddInfraestructureConfig
    {
        public static void AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Data
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IRepository<Roulette>, IRepository<Roulette>>();
            services.AddTransient<IRepository<Bet>, IRepository<Bet>>();

            #endregion Data
            #region Services
            services.AddTransient<IRouletteService, RouletteService>();
            #endregion Service
        }
    }
}
