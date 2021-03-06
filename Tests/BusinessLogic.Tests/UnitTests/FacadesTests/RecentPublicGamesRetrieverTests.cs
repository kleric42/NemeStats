﻿using System.Collections.Generic;
using BusinessLogic.Facades;
using BusinessLogic.Logic.PlayedGames;
using BusinessLogic.Models.Games;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap.AutoMocking;

namespace BusinessLogic.Tests.UnitTests.FacadesTests
{
    [TestFixture]
    public class RecentPublicGamesRetrieverTests
    {
        private RhinoAutoMocker<RecentPublicGamesRetriever> _autoMocker;

        [SetUp]
        public void SetUp()
        {
            _autoMocker = new RhinoAutoMocker<RecentPublicGamesRetriever>();    
        }

        [Test]
        public void ItPullsFromPlayedGameRetrieverIfTheResultsArentAlreadyInTheCache()
        {
            //--arrange
            int gamesToRetrieve = 1;
            var expectedResults = new List<PublicGameSummary>();
            _autoMocker.Get<IPlayedGameRetriever>().Expect(mock => mock.GetRecentPublicGames(gamesToRetrieve))
              .Return(expectedResults);

            //--act
            var actualResults = _autoMocker.ClassUnderTest.GetFromSource(gamesToRetrieve);

            //--assert
            Assert.That(actualResults, Is.SameAs(expectedResults));
        }

        [Test]
        public void TheCacheExpirationIsOneHour()
        {
            //--act
            var actualResults = _autoMocker.ClassUnderTest.GetCacheExpirationInSeconds();

            //--assert
            Assert.That(actualResults, Is.EqualTo(3600));
        }
    }
}
