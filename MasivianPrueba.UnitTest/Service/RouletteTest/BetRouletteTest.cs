using MasivianPrueba.Core.Dto;
using MasivianPrueba.Core.Entitiy;
using MasivianPrueba.Core.Interface.Repository;
using MasivianPrueba.Infraestructure.Service;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasivianPrueba.UnitTest.Service.RouletteTest
{
    [TestFixture]
    public class BetRouletteTest
    {
        [Test]
        
        public void MakeBetTestWhenAreRouletteOpenend()
        {
            var rouletteId = 1;
            string idUser = "20";
            var bet = new Bet() { Id = rouletteId };
            List<Roulette> roulettes = new List<Roulette>
            {
                new Roulette(){ Id=1,isOpen=true}
            };
            BetDto betDto = new BetDto()
            {
                 amount=100,
                  number=10
            };
            var betRepositoryMock = new Mock<IRepository<Bet>>();
            var rouletteRepositoryRepositoryMock = new Mock<IRepository<Roulette>>();
            rouletteRepositoryRepositoryMock.Setup(m => m.GetAll()).Returns(roulettes.AsQueryable()).Verifiable();
            betRepositoryMock.Setup(m=>m.Create(bet)).Returns(bet);
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m._rouletteRepository).Returns(rouletteRepositoryRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m._betRepository).Returns(betRepositoryMock.Object);
           
            RouletteService sut = new RouletteService(unitOfWorkMock.Object);
            //Act
            var performOperation =  sut.BetRoulettte(idUser, betDto);

            //Assert
            rouletteRepositoryRepositoryMock.Verify();
            betRepositoryMock.Verify();
            Assert.IsTrue(performOperation);
        }
        [Test]

        public void MakeBetTestWhenNotAreRoulleteOpened()
        {
            var rouletteId = 1;
            string idUser = "20";
            var bet = new Bet() { Id = rouletteId };
            List<Roulette> roulettes = new List<Roulette>
            {
                new Roulette(){ Id=1,isOpen=false}
            };
            BetDto betDto = new BetDto()
            {
                amount = 100,
                number = 10
            };
            var betRepositoryMock = new Mock<IRepository<Bet>>();
            var rouletteRepositoryRepositoryMock = new Mock<IRepository<Roulette>>();
            rouletteRepositoryRepositoryMock.Setup(m => m.GetAll()).Returns(roulettes.AsQueryable()).Verifiable();
            betRepositoryMock.Setup(m => m.Create(bet)).Returns(bet);
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m._rouletteRepository).Returns(rouletteRepositoryRepositoryMock.Object);
            unitOfWorkMock.Setup(m => m._betRepository).Returns(betRepositoryMock.Object);

            RouletteService sut = new RouletteService(unitOfWorkMock.Object);
            //Act
            var performOperation =  sut.BetRoulettte(idUser, betDto);

            //Assert
            rouletteRepositoryRepositoryMock.Verify();
            betRepositoryMock.Verify();
            Assert.IsTrue(!performOperation);
        }
    }
}
