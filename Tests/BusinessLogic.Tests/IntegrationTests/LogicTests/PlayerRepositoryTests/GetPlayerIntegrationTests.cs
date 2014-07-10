﻿using BusinessLogic.DataAccess;
using BusinessLogic.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests.IntegrationTests.LogicTests.PlayerRepositoryTests
{
    [TestFixture]
    public class GetPlayerIntegrationTests : IntegrationTestBase
    {
        private NemeStatsDbContext dbContext;
        private PlayerRepository playerRepository;

        [TestFixtureSetUp]
        public void SetUp()
        {
            dbContext = new NemeStatsDbContext();
        }

        [SetUp]
        public void TestSetUp()
        {
            playerRepository = new BusinessLogic.Models.PlayerRepository(dbContext);
        }

        [Test]
        public void ItReturnsNullIfThePlayerDoesntExist()
        {
            Player player = playerRepository.GetPlayer(-1, testUserContextForUserWithDefaultGamingGroup);

            Assert.Null(player);
        }

        [Test]
        public void ItReturnsNullIfThePlayersGamingGroupIdDoesntMatchTheUserContext()
        {
            Player player = playerRepository.GetPlayer(testPlayer1.Id, testUserContextForUserWithOtherGamingGroup);

            Assert.Null(player);
        }

        [Test]
        public void ItReturnsTheSpecifiedPlayer()
        {
            Player player = playerRepository.GetPlayer(testPlayer1.Id, testUserContextForUserWithDefaultGamingGroup);

            Assert.AreEqual(testPlayer1.Id, player.Id);
        }

        [TestFixtureTearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
