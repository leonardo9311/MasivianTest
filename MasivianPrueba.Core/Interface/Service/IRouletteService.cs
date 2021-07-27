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
        Task<bool> OpenRoulette(int idRoulette);
        bool BetRoulettte(string idUser,BetDto betDto);
        Task<List<BetResultDto>> CloseRoulette(int idRoulette);
    }
}
