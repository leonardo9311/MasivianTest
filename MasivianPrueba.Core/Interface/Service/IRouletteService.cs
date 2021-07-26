using MasivianPrueba.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianPrueba.Core.Interface.Service
{
    public interface IRouletteService
    {
        int CreateRoulette();
        bool OpenRoulette(int idRoulette);
        Task BetRoulettte(BetDto betDto);
        List<BetDto> CloseRoulette(int idRoulette);
    }
}
