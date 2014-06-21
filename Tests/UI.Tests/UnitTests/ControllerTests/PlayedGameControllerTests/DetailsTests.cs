﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Rhino.Mocks;
using BusinessLogic.Models;
using UI.Models.PlayedGame;

namespace UI.Tests.UnitTests.ControllerTests.PlayedGameControllerTests
{
    [TestFixture]
    public class DetailsTests : TestBase
    {
        [Test]
        public void ItNeverReturnsNull()
        {
            Assert.NotNull(playedGameController.Details(null));
        }

        [Test]
        public void ItReturnsBadHttpStatusWhenNoPlayedGameIdGiven()
        {
            HttpStatusCodeResult actualResult = playedGameController.Details(null) as HttpStatusCodeResult;

            Assert.AreEqual((int)HttpStatusCode.BadRequest, actualResult.StatusCode);
        }

        [Test]
        public void ItReturns404StatusWhenNoPlayedGameIsFound()
        {
            HttpStatusCodeResult actualResult = playedGameController.Details(-1) as HttpStatusCodeResult;

            Assert.AreEqual((int)HttpStatusCode.NotFound, actualResult.StatusCode);
        }
        
        [Test]
        public void ItRetrievesRequestedPlayedGame()
        {
            int playedGameId = 1351;
            playedGameController.Details(playedGameId);

            playedGameLogicMock.AssertWasCalled(x => x.GetPlayedGameDetails(playedGameId));
        }
        
        [Test]
        public void ItReturnsThePlayedGameDetailsViewWhenThePlayedGameIsFound()
        {
            int playedGameId = 1351;
            playedGameLogicMock.Expect(playedGameLogic => playedGameLogic.GetPlayedGameDetails(playedGameId))
                .Repeat.Once()
                .Return(new PlayedGame());
            ViewResult playedGameDetails = playedGameController.Details(playedGameId) as ViewResult;

            Assert.AreEqual(MVC.PlayedGame.Views.Details, playedGameDetails.ViewName);
        }

        [Test]
        public void ItReturnsThePlayedGameDetailsViewForTheFoundPlayedGame()
        {
            int playedGameId = 13541;

            PlayedGame playedGame = new PlayedGame() { Id = 123 };
            playedGameLogicMock.Expect(x => x.GetPlayedGameDetails(playedGameId))
                .Repeat.Once()
                .Return(playedGame);
            PlayedGameDetails playedGameDetails = new PlayedGameDetails();
            playedGameDetailsBuilder.Expect(builder => builder.Build(playedGame)).Repeat.Once()
                .Return(playedGameDetails);
            ViewResult result = playedGameController.Details(playedGameId) as ViewResult;

            PlayedGameDetails viewModel = (PlayedGameDetails)result.ViewData.Model;
            Assert.AreEqual(playedGameDetails, viewModel);
        }
    }
}
