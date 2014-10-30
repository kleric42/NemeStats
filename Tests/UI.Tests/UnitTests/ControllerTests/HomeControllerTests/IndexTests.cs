﻿using BusinessLogic.Logic.Nemeses;
using BusinessLogic.Models.Games;
using BusinessLogic.Models.Players;
using NUnit.Framework;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UI.Controllers;
using UI.Models.Home;
using UI.Models.Nemeses;
using UI.Models.Players;

namespace UI.Tests.UnitTests.ControllerTests.HomeControllerTests
{
    [TestFixture]
    public class IndexTests : HomeControllerTestBase
    {
        private TopPlayerViewModel expectedPlayer;
        private PublicGameSummary expectedPublicGameSummary;
        private List<NemesisChangeViewModel> expectedNemesisChangeViewModels;
        private ViewResult viewResult;
            
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();

            List<TopPlayer> topPlayers = new List<TopPlayer>()
            {
                new TopPlayer()
            };

            playerSummaryBuilderMock.Expect(mock => mock.GetTopPlayers(HomeController.NUMBER_OF_TOP_PLAYERS_TO_SHOW))
                .Return(topPlayers);
            expectedPlayer = new TopPlayerViewModel();
            viewModelBuilderMock.Expect(mock => mock.Build(Arg<TopPlayer>.Is.Anything))
                .Return(expectedPlayer);

            expectedPublicGameSummary = new PublicGameSummary();
            List<PublicGameSummary> publicGameSummaries = new List<PublicGameSummary>()
            {
                expectedPublicGameSummary
            };
            playedGameRetriever.Expect(mock => mock.GetRecentPublicGames(HomeController.NUMBER_OF_RECENT_PUBLIC_GAMES_TO_SHOW))
                .Return(publicGameSummaries);

            List<NemesisChange> expectedNemesisChanges = new List<NemesisChange>();
            nemesisHistoryRetriever.Expect(mock => mock.GetRecentNemesisChanges(HomeController.NUMBER_OF_RECENT_NEMESIS_CHANGES_TO_SHOW))
                                   .Return(expectedNemesisChanges);

            expectedNemesisChangeViewModels = new List<NemesisChangeViewModel>();
            nemesisChangeViewModelBuilder.Expect(mock => mock.Build(expectedNemesisChanges))
                                         .Return(expectedNemesisChangeViewModels);

            HomeIndexViewModel indexViewModel = new HomeIndexViewModel();
            viewResult = homeControllerPartialMock.Index() as ViewResult;
        }

        [Test]
        public void ItReturnsAnIndexView()
        {
            Assert.AreEqual(MVC.Home.Views.Index, viewResult.ViewName);
        }

        [Test]
        public void TheIndexHasTheRecentPlayerSummaries()
        {
            HomeIndexViewModel actualViewModel = (HomeIndexViewModel)viewResult.ViewData.Model;

            Assert.AreSame(expectedPlayer, actualViewModel.TopPlayers[0]);
        }

        [Test]
        public void TheIndexHasRecentPublicGameSummaries()
        {
            HomeIndexViewModel actualViewModel = (HomeIndexViewModel)viewResult.ViewData.Model;

            Assert.AreSame(expectedPublicGameSummary, actualViewModel.RecentPublicGames[0]);
        }

        [Test]
        public void TheIndexHasRecentNemesisChanges()
        {
            HomeIndexViewModel actualViewModel = (HomeIndexViewModel)viewResult.ViewData.Model;
            Assert.AreSame(expectedNemesisChangeViewModels, actualViewModel.RecentNemesisChanges);
        }
    }
}
