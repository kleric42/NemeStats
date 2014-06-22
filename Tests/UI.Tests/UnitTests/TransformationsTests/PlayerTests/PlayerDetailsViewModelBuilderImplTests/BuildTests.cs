﻿using BusinessLogic.Models;
using BusinessLogic.Models.Players;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Models.Players;
using UI.Transformations.Player;

namespace UI.Tests.UnitTests.TransformationsTests.PlayerTests.PlayerDetailsViewModelBuilderImplTests
{
    [TestFixture]
    public class BuildTests
    {
        private PlayerDetails playerDetails;
        private PlayerDetailsViewModel playerDetailsViewModel;

        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            List<PlayerGameResult> playerGameResults = new List<PlayerGameResult>()
            {
                new PlayerGameResult(){ PlayedGameId = 1513 },
                new PlayerGameResult(){ PlayedGameId = 1111 }
            };

            playerDetails = new PlayerDetails()
            {
                Id = 134,
                Active = true,
                Name = "Skipper",
                PlayerGameResults = playerGameResults
            };

            IndividualPlayerGameSummaryViewModelBuilder playerGameSummaryBuilder 
                = MockRepository.GenerateMock<IndividualPlayerGameSummaryViewModelBuilder>();
            playerGameSummaryBuilder.Expect(summaryBuilder => summaryBuilder.Build(playerGameResults[0]))
                .Repeat
                .Once()
                .Return(new Models.PlayedGame.IndividualPlayerGameSummaryViewModel() { PlayedGameId = playerGameResults[0].PlayedGameId });
            playerGameSummaryBuilder.Expect(summaryBuilder => summaryBuilder.Build(playerGameResults[1]))
                .Repeat
                .Once()
                .Return(new Models.PlayedGame.IndividualPlayerGameSummaryViewModel() { PlayedGameId = playerGameResults[1].PlayedGameId });
            PlayerDetailsViewModelBuilderImpl builder = new PlayerDetailsViewModelBuilderImpl(playerGameSummaryBuilder);

            playerDetailsViewModel = builder.Build(playerDetails);
        }

        [Test]
        public void PlayerDetailsCannotBeNull()
        {
            PlayerDetailsViewModelBuilderImpl builder = new PlayerDetailsViewModelBuilderImpl(null);

            var exception = Assert.Throws<ArgumentNullException>(() =>
                    builder.Build(null));

            Assert.AreEqual("playerDetails", exception.ParamName);
        }

        [Test]
        public void ItRequiresPlayerGameResults()
        {
            PlayerDetailsViewModelBuilderImpl builder = new PlayerDetailsViewModelBuilderImpl(null);

            var exception = Assert.Throws<ArgumentException>(() =>
                    builder.Build(new PlayerDetails()));

            Assert.AreEqual(PlayerDetailsViewModelBuilderImpl.EXCEPTION_PLAYER_GAME_RESULTS_CANNOT_BE_NULL, exception.Message);
        }

        [Test]
        public void ItCopiesThePlayerId()
        {
            Assert.AreEqual(playerDetails.Id, playerDetailsViewModel.PlayerId);
        }

        [Test]
        public void ItCopiesThePlayerName()
        {
            Assert.AreEqual(playerDetails.Name, playerDetailsViewModel.PlayerName);
        }

        [Test]
        public void ItCopiesTheActiveFlag()
        {
            Assert.AreEqual(playerDetails.Active, playerDetailsViewModel.Active);
        }

        [Test]
        public void ItPopulatesThePlayerGameSummaries()
        {
            int numberOfPlayerGameResults = playerDetails.PlayerGameResults.Count();
            for(int i = 0; i < numberOfPlayerGameResults; i++)
            {
                Assert.AreEqual(playerDetails.PlayerGameResults[i].PlayedGameId,
                    playerDetailsViewModel.PlayerGameSummaries[i].PlayedGameId);
            }
        }
    }
}