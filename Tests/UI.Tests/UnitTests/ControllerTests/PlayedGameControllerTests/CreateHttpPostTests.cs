﻿using BusinessLogic.DataAccess;
using BusinessLogic.Models;
using BusinessLogic.Models.Games;
using BusinessLogic.Models.User;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using UI.Controllers;

namespace UI.Tests.UnitTests.ControllerTests.PlayedGameControllerTests
{
    [TestFixture]
    public class CreateHttpPostTests : PlayedGameControllerTestBase
    {
        [Test]
        public void ItRemainsOnTheCreatePageIfTheModelIsNotValid()
        {
            ViewResult expectedViewResult = new ViewResult();
            playedGameControllerPartialMock.Expect(controller => controller.Create(currentUser))
                    .Repeat.Once()
                    .Return(expectedViewResult);
            playedGameControllerPartialMock.ModelState.AddModelError("Test error", "this is a test error to make model state invalid");

            ViewResult actualResult = playedGameControllerPartialMock.Create(new NewlyCompletedGame(), currentUser) as ViewResult;

            Assert.AreSame(expectedViewResult, actualResult);
        }

        [Test]
        public void ItAddsAllActivePlayersToTheViewBagIfRemainingOnTheCreatePage()
        {
            int playerId = 1938;
            string playerName = "Herb";
            List<Player> allPlayers = new List<Player>() { new Player() { Id = playerId, Name = playerName } };

            playerRetrieverMock.Expect(x => x.GetAllPlayers(currentUser.CurrentGamingGroupId.Value)).Repeat.Once().Return(allPlayers);
            playedGameController.ModelState.AddModelError("Test error", "this is a test error to make model state invalid");

            playedGameController.Create(new NewlyCompletedGame(), currentUser);

            playerRetrieverMock.VerifyAllExpectations();

            List<SelectListItem> selectListItems = playedGameController.ViewBag.Players;
            Assert.True(selectListItems.All(x => x.Value == playerId.ToString() && x.Text == playerName));
        }

        [Test]
        public void ItRedirectsToTheGamingGroupIndexAndRecentGamesSectionAfterSaving()
        {
            NewlyCompletedGame playedGame = new NewlyCompletedGame()
            {
                GameDefinitionId = 1,
                PlayerRanks = new List<PlayerRank>()
            }; 
            string baseUrl = "base url";
            string expectedUrl = baseUrl + "#" + GamingGroupController.SECTION_ANCHOR_RECENT_GAMES;
            urlHelperMock.Expect(mock => mock.Action(MVC.GamingGroup.ActionNames.Index, MVC.GamingGroup.Name))
                    .Return(baseUrl);
            ApplicationUser user = new ApplicationUser();
            playedGameCreatorMock.Expect(x => x.CreatePlayedGame(Arg<NewlyCompletedGame>.Is.Anything, Arg<ApplicationUser>.Is.Anything)).Repeat.Once();

            RedirectResult redirectResult = playedGameController.Create(playedGame, null) as RedirectResult;

            Assert.AreEqual(expectedUrl, redirectResult.Url);
        }

        [Test]
        public void ItSavesTheNewGame()
        {
            NewlyCompletedGame newlyCompletedGame = new NewlyCompletedGame()
            {
                GameDefinitionId = 1,
                PlayerRanks = new List<PlayerRank>()
            };
            string baseUrl = "base url";
            string expectedUrl = baseUrl + "#" + GamingGroupController.SECTION_ANCHOR_RECENT_GAMES;
            urlHelperMock.Expect(mock => mock.Action(MVC.GamingGroup.ActionNames.Index, MVC.GamingGroup.Name))
                    .Return(baseUrl);

            playedGameController.Create(newlyCompletedGame, null);

            playedGameCreatorMock.AssertWasCalled(mock => mock.CreatePlayedGame(Arg<NewlyCompletedGame>.Is.Equal(newlyCompletedGame), 
                Arg<ApplicationUser>.Is.Anything));
        }

        [Test]
        public void ItMakesTheRequestForTheCurrentUser()
        {
            NewlyCompletedGame newlyCompletedGame = new NewlyCompletedGame()
            {
                GameDefinitionId = 1,
                PlayerRanks = new List<PlayerRank>()
            };

            playedGameController.Create(newlyCompletedGame, currentUser);

            playedGameCreatorMock.AssertWasCalled(logic => logic.CreatePlayedGame(
                Arg<NewlyCompletedGame>.Is.Anything,
                Arg<ApplicationUser>.Is.Equal(currentUser)));
        }
    }
}
