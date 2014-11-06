﻿using System.Net;
using System.Web;
using System.Web.Routing;
using BusinessLogic.Models;
using NUnit.Framework;
using Rhino.Mocks;
using System.Linq;
using System.Web.Mvc;

namespace UI.Tests.UnitTests.ControllerTests.PlayerControllerTests
{
    [TestFixture]
    public class SaveHttpPostTests : PlayerControllerTestBase
    {
        [Test]
        public void ItSavesThePlayer()
        {
            var player = new Player()
            {
                Name = "player name"
            };
            
            playerController.Save(player, currentUser);

            playerSaverMock.AssertWasCalled(mock => mock.Save(player, currentUser));
        }

        [Test]
        public void ItReturnsBadRequestWhenTheRequestIsNotAjax()
        {
            var context = MockRepository.GenerateMock<HttpContextBase>();
            context.Expect(x => x.Request)
                .Repeat.Any()
                .Return(asyncRequestMock);
            asyncRequestMock.Headers.Clear();

            playerController.ControllerContext = new ControllerContext(context, new RouteData(), playerController);

            var result = playerController.Save(new Player(), currentUser) as HttpStatusCodeResult;

            Assert.AreEqual((int)HttpStatusCode.BadRequest, result.StatusCode);
        }

        [Test]
        public void ItReturnsANotModifiedStatusIfValidationFails()
        {
            var player = new Player();
            playerController.ModelState.AddModelError("key", "message");

            var result = playerController.Save(player, currentUser) as HttpStatusCodeResult;

            Assert.AreEqual((int)HttpStatusCode.NotModified, result.StatusCode);
        }
    }
}
