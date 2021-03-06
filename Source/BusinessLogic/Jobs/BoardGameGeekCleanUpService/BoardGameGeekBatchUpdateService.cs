using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using BoardGameGeekApiClient.Interfaces;
using BoardGameGeekApiClient.Models;
using BusinessLogic.DataAccess;
using BusinessLogic.Models;
using BusinessLogic.Models.User;
using RollbarSharp;

namespace BusinessLogic.Jobs.BoardGameGeekCleanUpService
{
    public class BoardGameGeekBatchUpdateService : IBoardGameGeekBatchUpdateService
    {
        private const string CleanYearPattern = @"\w*\(\d{4}\)";

        private readonly IDataContext _dataContext;
        private readonly IBoardGameGeekApiClient _boardGameGeekApiClient;
        private readonly IRollbarClient _rollbar;

        public BoardGameGeekBatchUpdateService(IDataContext dataContext, IBoardGameGeekApiClient boardGameGeekApiClient, IRollbarClient rollbar)
        {
            _dataContext = dataContext;
            _boardGameGeekApiClient = boardGameGeekApiClient;
            _rollbar = rollbar;
        }

        public LinkOrphanGamesResult LinkOrphanGames()
        {
            var result = new LinkOrphanGamesResult();
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {


                var orphanGames = GetOrphanGames();
                result.OrphanGames = orphanGames.Count;

                foreach (var game in orphanGames)
                {
                    var gameName = RemoveYear(game.Name);

                    var existingGame = GetExistingBGGGameByName(gameName);
                    if (existingGame != null)
                    {
                        UpdateGameDefinition(game, existingGame.Id, result);
                    }
                    else
                    {
                        var searchResult = _boardGameGeekApiClient.SearchBoardGames(gameName, true);
                        if (searchResult.Any())
                        {
                            var gameToAdd = GetGameToAddFromSearch(searchResult);

                            if (gameToAdd != null)
                            {

                                existingGame = GetExistingBGGGameById(gameToAdd);
                                if (existingGame != null)
                                {
                                    UpdateGameDefinition(game, existingGame.Id, result);
                                }
                                else
                                {
                                    var newRecord = CreateBGGGame(gameToAdd);

                                    UpdateGameDefinition(game, newRecord.Id, result);
                                }
                            }
                        }
                    }

                    if (game.BoardGameGeekGameDefinitionId != null)
                    {
                        _dataContext.CommitAllChanges();
                    }
                    else
                    {
                        result.StillOrphanGames.Add(new LinkOrphanGamesResult.OrphanGame()
                        {
                            Name = game.Name,
                            Id = game.Id,
                            GamingGroupId = game.GamingGroupId
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                _rollbar.SendException(ex);
            }

            stopwatch.Stop();
            result.TimeEllapsed = stopwatch.Elapsed;
            return result;
        }

        private void UpdateGameDefinition(GameDefinition game, int boardGameGeekGameDefinitionId,
            LinkOrphanGamesResult result)
        {
            game.BoardGameGeekGameDefinitionId = boardGameGeekGameDefinitionId;
            result.LinkedGames++;
        }

        private BoardGameGeekGameDefinition CreateBGGGame(GameDetails gameToAdd)
        {
            var newRecord = new BoardGameGeekGameDefinition
            {
                Id = gameToAdd.GameId,
                Name = gameToAdd.Name,
                Thumbnail = gameToAdd.Thumbnail,
                MaxPlayers = gameToAdd.MaxPlayers,
                MinPlayers = gameToAdd.MinPlayers,
                MaxPlayTime = gameToAdd.MaxPlayTime,
                MinPlayTime = gameToAdd.MinPlayTime,
                AverageWeight = gameToAdd.AverageWeight,
                Description = gameToAdd.Description
            };

            _dataContext.Save(newRecord, new ApplicationUser());
            return newRecord;
        }

        private BoardGameGeekGameDefinition GetExistingBGGGameById(GameDetails gameToAdd)
        {
            var existingGame = _dataContext.GetQueryable<BoardGameGeekGameDefinition>()
                .FirstOrDefault(bgg => bgg.Id == gameToAdd.GameId);
            return existingGame;
        }

        private GameDetails GetGameToAddFromSearch(List<SearchBoardGameResult> searchResult)
        {
            var gamesToAdd =
                searchResult.Select(
                    searchBoardGameResult => _boardGameGeekApiClient.GetGameDetails(searchBoardGameResult.BoardGameId))
                    .Where(gameDetails => gameDetails != null)
                    .ToList();

            var gameToAdd =
                gamesToAdd.Where(g => g.Thumbnail != null)
                    .OrderByDescending(g => g.BGGRating)
                    .FirstOrDefault();
            return gameToAdd;
        }

        private BoardGameGeekGameDefinition GetExistingBGGGameByName(string gameName)
        {
            var existingGame =
                _dataContext.GetQueryable<BoardGameGeekGameDefinition>().FirstOrDefault(bgg => bgg.Name.Contains(gameName));
            return existingGame;
        }

        private List<GameDefinition> GetOrphanGames()
        {
            var gamesWithoutBGGLink =
                _dataContext.GetQueryable<GameDefinition>().Where(g => g.BoardGameGeekGameDefinitionId == null).ToList();
            return gamesWithoutBGGLink;
        }

        private string RemoveYear(string name)
        {
            return Regex.Replace(name, CleanYearPattern, "").Trim();
        }

        public int RefreshAllBoardGameGeekData()
        {
            var allExistingBoardGameGeekGameDefinitions = _dataContext.GetQueryable<BoardGameGeekGameDefinition>()
                .OrderBy(x => x.Id)
                .ToList();
            var anonymousUser = new AnonymousApplicationUser();
            int totalGamesUpdated = 0;
            foreach (var existingBoardGameGeekGameDefinition in allExistingBoardGameGeekGameDefinitions)
            {
                //delay between BGG calls to decrease likelyhood of getting blocked by BGG
                Thread.Sleep(400);
                var gameDetails = _boardGameGeekApiClient.GetGameDetails(existingBoardGameGeekGameDefinition.Id);

                if (gameDetails != null)
                {
                    existingBoardGameGeekGameDefinition.AverageWeight = gameDetails.AverageWeight;
                    existingBoardGameGeekGameDefinition.Description = gameDetails.Description;
                    existingBoardGameGeekGameDefinition.MaxPlayTime = gameDetails.MaxPlayTime;
                    existingBoardGameGeekGameDefinition.MinPlayTime = gameDetails.MinPlayTime;
                    existingBoardGameGeekGameDefinition.MaxPlayers = gameDetails.MaxPlayers;
                    existingBoardGameGeekGameDefinition.MinPlayers = gameDetails.MinPlayers;
                    existingBoardGameGeekGameDefinition.Name = gameDetails.Name;
                    existingBoardGameGeekGameDefinition.Thumbnail = gameDetails.Thumbnail;

                    _dataContext.Save(existingBoardGameGeekGameDefinition, anonymousUser);

                    if (totalGamesUpdated++ % 10 == 0)
                    {
                        _dataContext.CommitAllChanges();
                        Debug.WriteLine("{0} BoardGameGeekGameDefinitions updated so far...", totalGamesUpdated);
                    }
                }
            }

            return totalGamesUpdated;
        }
    }
}