using MasivianPrueba.Core.Entitiy;
using MasivianPrueba.Core.Interface.Repository;
using MasivianPrueba.Infraestructure.Service;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MasivianPrueba.UnitTest.Service.RouletteTest
{
    [TestFixture]
    public class OpenRouletteTest
    {
     
        
        [Test]
        public async Task OpenRouletteIsAlreadyOpen()
        {
            //Arrange
            var rouletteId = 1;

            var roulette = new Roulette() { Id = rouletteId, isOpen = true };
          
            var rouletteRepositoryMock = new Mock<IRepository<Roulette>>();

            rouletteRepositoryMock.Setup(m => m.GetById(rouletteId)).Returns(roulette).Verifiable();
          
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m._rouletteRepository).Returns(rouletteRepositoryMock.Object);

            RouletteService sut = new RouletteService(unitOfWorkMock.Object);
            //Act
            var performOperation = await sut.OpenRoulette(rouletteId);

            //Assert
            rouletteRepositoryMock.Verify();
            Assert.IsTrue(!performOperation);
           
        }
        [Test]
        public async Task OpenRouletteIsCosed()
        {   
            //Arrange
            var rouletteId = 1;

            var roulette = new Roulette() { Id = rouletteId, isOpen = false };

            var rouletteRepositoryMock = new Mock<IRepository<Roulette>>();

            rouletteRepositoryMock.Setup(m => m.GetById(rouletteId)).Returns(roulette).Verifiable();
            
            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m._rouletteRepository).Returns(rouletteRepositoryMock.Object);

            RouletteService sut = new RouletteService(unitOfWorkMock.Object);
            //Act
            var performOperation = await sut.OpenRoulette(rouletteId);

            //Assert
            rouletteRepositoryMock.Verify();
            Assert.IsTrue(performOperation);

        }
    }
}
