using MasivianPrueba.Core.Interface.Repository;
using MasivianPrueba.Infraestructure.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasivianPrueba.Core.Entitiy;
using MasivianPrueba.Infraestructure.Service;

namespace MasivianPrueba.UnitTest.Service.RouletteTest
{
    [TestFixture]
    public class CreateRouletteServiceTest
    {

       
     
        [Test]
        public void CreateRoulletteWhenIdExist()
        {
            //Arrange
            var rouletteId = 0;
           
            var roulette = new Roulette() { Id = rouletteId };           
           
           
            var rouletteRepositoryRepositoryMock = new Mock<IRepository<Roulette>>();
            var betRepositoryRepositoryMock = new Mock<IRepository<Bet>>();
           
            rouletteRepositoryRepositoryMock.Setup(m => m.Create(roulette)).Returns(roulette).Verifiable();
            var unitOfWorkMock = new UnitOfWork(rouletteRepositoryRepositoryMock.Object, betRepositoryRepositoryMock.Object);
           
            

            RouletteService sut = new RouletteService(unitOfWorkMock);
            //Act
            var performOperation =  sut.CreateRoulette();

            //Assert
            
            
            Assert.AreEqual(rouletteId, performOperation);
        }


    }
}
