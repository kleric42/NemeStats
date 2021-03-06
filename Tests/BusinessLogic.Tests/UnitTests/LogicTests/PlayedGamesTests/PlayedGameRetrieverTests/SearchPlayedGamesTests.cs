﻿using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.DataAccess;
using BusinessLogic.Logic.PlayedGames;
using BusinessLogic.Models;
using BusinessLogic.Models.PlayedGames;
using NUnit.Framework;
using Rhino.Mocks;
using StructureMap.AutoMocking;
using BusinessLogic.Exceptions;

namespace BusinessLogic.Tests.UnitTests.LogicTests.PlayedGamesTests.PlayedGameRetrieverTests
{
    [TestFixture]
    public class SearchPlayedGamesTests
    {
        private RhinoAutoMocker<PlayedGameRetriever> autoMocker;
        private List<PlayedGame> playedGames;
        private const int PLAYED_GAME_ID_FOR_GAME_RECORDED_IN_MARCH = 1;
        private const int PLAYED_GAME_ID_FOR_GAME_RECORDED_IN_APRIL = 2;
        private const int EXPECTED_GAMING_GROUP_ID = 30;
        private const int EXPECTED_GAME_DEFINITION_ID = 51;
        private const int EXPECTED_PLAYER_ID = 62;
        private readonly DateTime DATE_MARCH = new DateTime(2015, 3, 1, 4, 4, 4);
        private readonly DateTime DATE_APRIL = new DateTime(2015, 4, 1, 4, 4, 4);

        [SetUp]
        public void SetUp()
        {
            autoMocker = new RhinoAutoMocker<PlayedGameRetriever>();

            playedGames = new List<PlayedGame>
            {
                new PlayedGame
                {
                    Id = PLAYED_GAME_ID_FOR_GAME_RECORDED_IN_MARCH,
                    DateCreated = DATE_MARCH,
                    DatePlayed = DATE_MARCH,
                    PlayerGameResults = new List<PlayerGameResult>(),
                    GameDefinition = new GameDefinition(),
                    GamingGroup = new GamingGroup(),
                    GamingGroupId = EXPECTED_GAMING_GROUP_ID,
                    GameDefinitionId = EXPECTED_GAME_DEFINITION_ID
                },
                new PlayedGame
                {
                    Id = PLAYED_GAME_ID_FOR_GAME_RECORDED_IN_APRIL,
                    DateCreated = DATE_APRIL,
                    DatePlayed = DATE_APRIL,
                    PlayerGameResults = new List<PlayerGameResult>
                    {
                        new PlayerGameResult
                        {
                            PlayerId = EXPECTED_PLAYER_ID,
                            Player = new Player
                            {
                                Name = "player name",
                                Active = true
                            },
                            PlayedGame = new PlayedGame
                            {
                                GameDefinition = new GameDefinition()
                            }
                        }
                    },
                    GameDefinition = new GameDefinition(),
                    GamingGroup = new GamingGroup(),
                    GamingGroupId = 135353
                }
            };

            autoMocker.Get<IDataContext>().Expect(mock => mock.GetQueryable<PlayedGame>()).Return(playedGames.AsQueryable());
        }

        [Test]
        public void ItSetsAllTheFields()
        {
            autoMocker = new RhinoAutoMocker<PlayedGameRetriever>();

            var playedGame = new PlayedGame
            {
                Id = 1,
                DateCreated = new DateTime(2015, 11, 1, 2, 2, 2),
                DatePlayed = new DateTime(2015, 10, 1, 3, 3, 3),
                GameDefinitionId = 2,
                GamingGroupId = 3,
                Notes = "some notes",
                GamingGroup = new GamingGroup
                {
                    Name = "some gaming group name"
                },
                GameDefinition = new GameDefinition
                {
                    Name = "some game definition name",
                    BoardGameGeekGameDefinitionId = 4
                }
            };

            var playerGameResult = new PlayerGameResult
            {
                GameRank = 1,
                PlayerId = 2,
                PointsScored = 50,
                Player = new Player
                {
                    Id = 100,
                    Name = "some player name"
                },
                PlayedGame = playedGame,
                NemeStatsPointsAwarded = 1,
                GameWeightBonusPoints = 2,
                GameDurationBonusPoints = 3
            };

            var playerGameResults = new List<PlayerGameResult>
            {
               playerGameResult
            };

            playedGame.PlayerGameResults = playerGameResults;

            playedGames = new List<PlayedGame>
            {
                playedGame
            };
            autoMocker.Get<IDataContext>().Expect(mock => mock.GetQueryable<PlayedGame>()).Return(playedGames.AsQueryable());

            var results = autoMocker.ClassUnderTest.SearchPlayedGames(new PlayedGameFilter()).First();

            Assert.That(results.PlayedGameId, Is.EqualTo(playedGame.Id));
            Assert.That(results.GameDefinitionName, Is.EqualTo(playedGame.GameDefinition.Name));
            Assert.That(results.GameDefinitionId, Is.EqualTo(playedGame.GameDefinitionId));
            Assert.That(results.DateLastUpdated, Is.EqualTo(playedGame.DateCreated));
            Assert.That(results.DatePlayed, Is.EqualTo(playedGame.DatePlayed));
            Assert.That(results.GamingGroupId, Is.EqualTo(playedGame.GamingGroupId));
            Assert.That(results.GamingGroupName, Is.EqualTo(playedGame.GamingGroup.Name));
            Assert.That(results.Notes, Is.EqualTo(playedGame.Notes));
            var actualPlayerResult = results.PlayerGameResults[0];
            var expectedPlayerGameResult = playedGame.PlayerGameResults[0];
            Assert.That(actualPlayerResult.GameRank, Is.EqualTo(expectedPlayerGameResult.GameRank));
            Assert.That(actualPlayerResult.NemeStatsPointsAwarded, Is.EqualTo(expectedPlayerGameResult.NemeStatsPointsAwarded));
            Assert.That(actualPlayerResult.GameDurationBonusNemePoints, Is.EqualTo(expectedPlayerGameResult.GameDurationBonusPoints));
            Assert.That(actualPlayerResult.GameWeightBonusNemePoints, Is.EqualTo(expectedPlayerGameResult.GameWeightBonusPoints));
            var expectedTotalPoints = expectedPlayerGameResult.NemeStatsPointsAwarded
                                      + expectedPlayerGameResult.GameDurationBonusPoints
                                      + expectedPlayerGameResult.GameWeightBonusPoints;
            Assert.That(actualPlayerResult.TotalPoints, Is.EqualTo(expectedTotalPoints));
            Assert.That(actualPlayerResult.PlayerId, Is.EqualTo(expectedPlayerGameResult.PlayerId));
            Assert.That(actualPlayerResult.PlayerName, Is.EqualTo(expectedPlayerGameResult.Player.Name));
            Assert.That(actualPlayerResult.PlayerActive, Is.EqualTo(expectedPlayerGameResult.Player.Active));
            Assert.That(actualPlayerResult.PointsScored, Is.EqualTo(expectedPlayerGameResult.PointsScored));
            Assert.That(actualPlayerResult.PlayedGameId, Is.EqualTo(expectedPlayerGameResult.PlayedGameId));
            Assert.That(actualPlayerResult.DatePlayed, Is.EqualTo(expectedPlayerGameResult.PlayedGame.DatePlayed));
            Assert.That(actualPlayerResult.GameName, Is.EqualTo(expectedPlayerGameResult.PlayedGame.GameDefinition.Name));
            Assert.That(actualPlayerResult.GameDefinitionId, Is.EqualTo(expectedPlayerGameResult.PlayedGame.GameDefinitionId));
        }

        [Test]
        public void ItReturnsAnEmptyListIfThereAreNoSearchResults()
        {
            autoMocker = new RhinoAutoMocker<PlayedGameRetriever>();
            autoMocker.Get<IDataContext>().Expect(mock => mock.GetQueryable<PlayedGame>()).Return(new List<PlayedGame>().AsQueryable());
            var results = autoMocker.ClassUnderTest.SearchPlayedGames(new PlayedGameFilter());

            Assert.That(results.Count, Is.EqualTo(0));
        }

        [Test]
        public void ItFiltersOnStartDateGameLastUpdated()
        {
            var filter = new PlayedGameFilter
            {
                StartDateGameLastUpdated = DATE_APRIL.ToString("yyyy-MM-dd")
            };

            var results = autoMocker.ClassUnderTest.SearchPlayedGames(filter);

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.True(results.All(x => x.DateLastUpdated >= new DateTime(2015, 4, 1)));
        }

        [Test]
        public void ItFiltersOnEndDateGameLastUpdated()
        {
            var filter = new PlayedGameFilter
            {
                EndDateGameLastUpdated = DATE_MARCH.ToString("yyyy-MM-dd")
            };

            var results = autoMocker.ClassUnderTest.SearchPlayedGames(filter);

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.True(results.All(x => x.DateLastUpdated.Date <= new DateTime(2015, 3, 1)));
        }

        [Test]
        public void ItFiltersOnDatePlayedFrom()
        {
            var filter = new PlayedGameFilter
            {
                DatePlayedFrom = DATE_APRIL.ToString("yyyy-MM-dd")
            };

            var results = autoMocker.ClassUnderTest.SearchPlayedGames(filter);

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.True(results.All(x => x.DatePlayed >= DATE_APRIL));
        }

        [Test]
        public void ItFiltersOnDatePlayedTo()
        {
            var filter = new PlayedGameFilter
            {
                DatePlayedTo = DATE_MARCH.ToString("yyyy-MM-dd")
            };

            var results = autoMocker.ClassUnderTest.SearchPlayedGames(filter);

            Assert.That(results.Count, Is.EqualTo(1));
            Assert.True(results.All(x => x.DatePlayed <= DATE_MARCH));
        }

        [Test]
        public void ItThrowsAnInvalidDateFormatExceptionIfTheStartDateGameLastUpdatedIsntYYYYMMDD()
        {
            var filter = new PlayedGameFilter
            {
                StartDateGameLastUpdated = "2015-3-1"
            };
            var expectedExceptionMessage = new InvalidDateFormatException(filter.StartDateGameLastUpdated).Message;

            var actualException = Assert.Throws<InvalidDateFormatException>(() => autoMocker.ClassUnderTest.SearchPlayedGames(filter));

            Assert.That(actualException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void ItThrowsAnInvalidDateFormatExceptionIfTheEndDateGameLastUpdatedIsntYYYYMMDD()
        {
            var filter = new PlayedGameFilter
            {
                EndDateGameLastUpdated = "2015-3-1"
            };
            var expectedExceptionMessage = new InvalidDateFormatException(filter.EndDateGameLastUpdated).Message;

            var actualException = Assert.Throws<InvalidDateFormatException>(() => autoMocker.ClassUnderTest.SearchPlayedGames(filter));

            Assert.That(actualException.Message, Is.EqualTo(expectedExceptionMessage));
        }

        [Test]
        public void ItLimitsSearchResultsToTheMaximumSpecified()
        {
            const int MAX_RESULTS = 1;
            var filter = new PlayedGameFilter
            {
                MaximumNumberOfResults = MAX_RESULTS
            };

            var results = autoMocker.ClassUnderTest.SearchPlayedGames(filter);

            Assert.That(results.Count, Is.EqualTo(MAX_RESULTS));
        }

        [Test]
        public void ItFiltersOnTheGamingGroupId()
        {
            var filter = new PlayedGameFilter
            {
                GamingGroupId = EXPECTED_GAMING_GROUP_ID
            };

            var results = autoMocker.ClassUnderTest.SearchPlayedGames(filter);

            Assert.True(results.All(result => result.GamingGroupId == filter.GamingGroupId));
        }

        [Test]
        public void ItFiltersOnTheGameDefinitionId()
        {
            var filter = new PlayedGameFilter
            {
                GameDefinitionId = EXPECTED_GAME_DEFINITION_ID
            };

            var results = autoMocker.ClassUnderTest.SearchPlayedGames(filter);

            Assert.True(results.All(result => result.GameDefinitionId == filter.GameDefinitionId));
        }

        [Test]
        public void ItFiltersOnThePlayerId()
        {
            var filter = new PlayedGameFilter
            {
                PlayerId = EXPECTED_PLAYER_ID
            };

            var results = autoMocker.ClassUnderTest.SearchPlayedGames(filter);

            Assert.True(results.All(result => result.PlayerGameResults.Any(x => x.PlayerId == filter.PlayerId)));
        }
    }
}
