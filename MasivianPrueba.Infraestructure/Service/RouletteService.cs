using MasivianPrueba.Core.Dto;
using MasivianPrueba.Core.Interface.Repository;
using MasivianPrueba.Core.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianPrueba.Infraestructure.Service
{
    public class RouletteService : IRouletteService
    {
        private readonly IUnitOfWork _unitOfWork;
        public RouletteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task BetRoulettte(BetDto betDto)
        {
            throw new NotImplementedException();
        }

        public List<BetDto> CloseRoulette(int idRoulette)
        {
            throw new NotImplementedException();
        }

        public int CreateRoulette()
        {
            throw new NotImplementedException();
        }

        public bool OpenRoulette(int idRoulette)
        {
            throw new NotImplementedException();
        }
    }
}
