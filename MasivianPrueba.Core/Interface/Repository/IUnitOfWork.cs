using MasivianPrueba.Core.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianPrueba.Core.Interface.Repository
{
    public interface IUnitOfWork 
    {
        IRepository<Roulette> _rouletteRepository { get; }
        IRepository<Bet> _betRepository { get; }
    }
}
