using MasivianPrueba.Core.Entitiy;
using MasivianPrueba.Core.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianPrueba.Infraestructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Roulette> _rouletteRepository { get; }

        public IRepository<Bet> _betRepository { get; }

        public UnitOfWork(IRepository<Roulette> rouletteRepository, IRepository<Bet> betRepository)
        {
            _rouletteRepository = rouletteRepository;
            _betRepository = betRepository;
        }
    }
}
