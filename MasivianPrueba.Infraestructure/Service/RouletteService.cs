using MasivianPrueba.Core.Contanst;
using MasivianPrueba.Core.Dto;
using MasivianPrueba.Core.Entitiy;
using MasivianPrueba.Core.Exceptions;
using MasivianPrueba.Core.Interface.Repository;
using MasivianPrueba.Core.Interface.Service;
using MasivianPrueba.Core.Utils;
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

        public bool BetRoulettte(string idUser,BetDto betDto)
        {
         
            var parametersAreRight = idUser != string.Empty &&
                betDto.amount <= Constants.maxBetAmountRoulette &&
                Constants.minimunNumberRoulette <= betDto.number &&
                Constants.maximunNumberRoulette >= betDto.number;
            Roulette roulette = _unitOfWork._rouletteRepository.GetAll().FirstOrDefault(r=>r.isOpen);
            bool canBet = parametersAreRight && roulette != null;
            if (canBet)
            {
                Bet bet = new Bet
                {
                    amount = betDto.amount,
                    idRoullette = roulette.Id,
                    idUser = idUser,
                    number = betDto.number
                };
                 _unitOfWork._betRepository.Create(bet);
            }

            return canBet;
        }

        public async Task<List<BetResultDto>> CloseRoulette(int idRoulette)
        {
            Roulette roulette=  _unitOfWork._rouletteRepository.GetById(idRoulette);
            bool canClose= roulette != null;
            if (canClose)
            {
                roulette.isOpen = false;
                await _unitOfWork._rouletteRepository.UpdateAsync(roulette);
                var winnerNumber = BetHelper.RandomNumber();
                var winnerBets= roulette.bets.Where(b=>b.number==winnerNumber).ToList();
                bool isEvenNumber = BetHelper.isEvenNumber(winnerNumber);
                var winners = winnerBets.Select(wb => new BetResultDto
                {
                    amountbet = wb.amount,
                    earnedAmount = wb.amount * (isEvenNumber ? Constants.evenNumberEarnFactor : Constants.oddNumberEarnFactor),
                    idBet=wb.Id,
                    isEvenNumber=isEvenNumber,
                  
                }) ;
            }
            return new List<BetResultDto>();
        }

        public int CreateRoulette()
        {
            Roulette roulette = new Roulette()
            {
                isOpen = false
            };
            _unitOfWork._rouletteRepository.Create(roulette);
            return roulette.Id;
        
        }

       
        public async Task<bool> OpenRoulette(int idRoulette)
        {
            Roulette roulette =  _unitOfWork._rouletteRepository.GetById(idRoulette);
            if (roulette == null)
                throw new EntityNotFoundException(nameof(roulette),idRoulette);
            bool canUpdate;
            canUpdate = !roulette.isOpen;
            if (canUpdate)
            {
                roulette.isOpen = true;
                await _unitOfWork._rouletteRepository.UpdateAsync(roulette);
            }
              

            return canUpdate;
        }
    }
}
