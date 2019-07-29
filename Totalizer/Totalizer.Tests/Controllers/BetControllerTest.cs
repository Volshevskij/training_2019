using BusinessLogickLayer.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Totalizer.Controllers;

namespace Totalizer.Tests.Controllers
{
    class BetControllerTest
    {
        IBetService service;

        public BetControllerTest(IBetService _service)
        {
            service = _service;
        }

        [TestMethod]
        public void GetReturnsBetById()
        {
            // Arrange
            var controller = new BetController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var bet = controller.GetBetByID(1);

            // Assert
            Assert.AreEqual(1, bet.Id);
        }

        [TestMethod]
        public void GetReturnsBetsList()
        {
            // Arrange
            var controller = new BetController(service);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            // Act
            var bets = controller.GetBetsList();

            // Assert
            Assert.IsFalse(bets == null|| bets.Count() < 0);
        }
    }
}
