using BusinessLogickLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Totalizer.Controllers;

namespace Totalizer.Tests.Controllers
{
    [TestClass]
    class BetControllerTest
    {
        [TestMethod]
        public void GetReturnsBetById()
        {
            // Arrange
            var mockService = new Mock<IBetService>();
            mockService.Setup(x => x.GetItemById(42))
                .Returns(new Bet { Id = 42 });

            var controller = new BetController(mockService.Object);

            // Act
            Bet res = controller.GetBetByID(42);

            // Assert
            Assert.IsNotNull(res);
            Assert.AreEqual(42, res.Id);
        }

        [TestMethod]
        public void GetReturnsBetsList()
        {
            // Arrange
            var mockService = new Mock<IBetService>();
            mockService.Setup(x => x.GetItemsList())
                .Returns(new List<Bet>());

            var controller = new BetController(mockService.Object);

            // Act
            IEnumerable<Bet> res = controller.GetBetsList();

            // Assert
            Assert.IsNotNull(res);
            Assert.AreNotEqual(-1, res.Count());
        }

        [TestMethod]
        public void Deleting()
        {
            // Arrange
            var mockService = new Mock<IBetService>();
            mockService.Setup(x => x.GetItemsList()).Returns(new List<Bet>());
            var controller = new BetController(mockService.Object);

            // Act
            int firstCount = controller.GetBetsList().Count();
            Bet target = controller.GetBetByID(1);

            controller.DeleteBet(1);
            int secondCount = controller.GetBetsList().Count();
            IEnumerable<Bet> bets = controller.GetBetsList();

            // Assert
            Assert.IsNotNull(bets);
            Assert.AreNotEqual(firstCount, secondCount);
            Assert.IsFalse(bets.Contains(target));
        }

        [TestMethod]
        public void CreateItem()
        {
            // Arrange
            var mockService = new Mock<IBetService>();
            mockService.Setup(x => x.GetItemsList()).Returns(new List<Bet>());
            var controller = new BetController(mockService.Object);

            // Act
            int firstCount = controller.GetBetsList().Count();
            controller.CreateBet(new Bet());

            controller.DeleteBet(1);
            int secondCount = controller.GetBetsList().Count();
            IEnumerable<Bet> bets = controller.GetBetsList();

            // Assert
            Assert.IsNotNull(bets);
            Assert.AreNotEqual(firstCount, secondCount);
        }
    }
}
