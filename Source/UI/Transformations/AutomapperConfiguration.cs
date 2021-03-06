﻿#region LICENSE
// NemeStats is a free website for tracking the results of board games.
//     Copyright (C) 2015 Jacob Gordon
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>
#endregion

using AutoMapper;
using BusinessLogic.Logic.BoardGameGeek;
using BusinessLogic.Logic.GameDefinitions;
using BusinessLogic.Logic.GamingGroups;
using BusinessLogic.Logic.Players;
using BusinessLogic.Models;
using BusinessLogic.Models.Games;
using BusinessLogic.Models.GamingGroups;
using BusinessLogic.Models.PlayedGames;
using BusinessLogic.Models.Players;
using BusinessLogic.Models.Points;
using BusinessLogic.Models.User;
using UI.Areas.Api.Models;
using UI.Models;
using UI.Models.GameDefinitionModels;
using UI.Models.GamingGroup;
using UI.Models.PlayedGame;
using UI.Models.Players;
using UI.Models.Points;

namespace UI.Transformations
{
    public class AutomapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<TopGamingGroupSummary, TopGamingGroupSummaryViewModel>(MemberList.Source);
            Mapper.CreateMap<VotableFeature, VotableFeatureViewModel>(MemberList.Destination);
            Mapper.CreateMap<NewUserMessage, NewUser>(MemberList.Source);
            Mapper.CreateMap<NewlyRegisteredUser, NewlyRegisteredUserMessage>(MemberList.Source);
            Mapper.CreateMap<PlayedGameSearchResult, PlayedGameSearchResultMessage>(MemberList.Destination)
                  .ForSourceMember(x => x.PlayerGameResults, opt => opt.Ignore())
                  .ForMember(x => x.DateLastUpdated, opt => opt.MapFrom(src => src.DateLastUpdated.ToString("yyyy-MM-dd")))
                  .ForMember(x => x.DatePlayed, opt => opt.MapFrom(src => src.DatePlayed.ToString("yyyy-MM-dd")));
            Mapper.CreateMap<PlayerResult, PlayerGameResultMessage>(MemberList.Destination)
                  .ForMember(x => x.TotalNemeStatsPointsAwarded, opt => opt.MapFrom(src => src.TotalPoints));
            Mapper.CreateMap<PlayerGameSummary, PlayerGameSummaryViewModel>(MemberList.Source);
            Mapper.CreateMap<PlayerInfoForUser, PlayerInfoForUserMessage>(MemberList.Destination);
            Mapper.CreateMap<GamingGroupInfoForUser, GamingGroupInfoForUserMessage>(MemberList.Destination);
            Mapper.CreateMap<UserInformation, UserInformationMessage>(MemberList.Destination);
            Mapper.CreateMap<PlayerWinRecord, PlayerSummaryViewModel>(MemberList.Destination)
                  .ForMember(x => x.SpecialBadgeTypes, opt => opt.MapFrom(src => src.MapSpecialBadges()))
                  .ForMember(x => x.PlayerName, opt => opt.MapFrom(src => PlayerNameBuilder.BuildPlayerName(src.PlayerName, src.PlayerActive)));
            Mapper.CreateMap<PlayerWinRecord, GameDefinitionPlayerSummaryViewModel>(MemberList.Destination)
                  .ForMember(x => x.SpecialBadgeTypes, opt => opt.MapFrom(src => src.MapSpecialBadges()))
                  .ForMember(x => x.PlayerName, opt => opt.MapFrom(src => PlayerNameBuilder.BuildPlayerName(src.PlayerName, src.PlayerActive)));
            Mapper.CreateMap<GameDefinitionTotal, GameDefinitionTotalMessage>(MemberList.Destination);
            Mapper.CreateMap<GameDefinitionTotals, GameDefinitionTotalsMessage>(MemberList.Destination);
            Mapper.CreateMap<GameDefinition, GameDefinitionEditViewModel>(MemberList.Destination)
                                  .ForMember(x => x.GameDefinitionId, opt => opt.MapFrom(src => src.Id));
            Mapper.CreateMap<GameDefinitionEditViewModel, GameDefinitionUpdateRequest>(MemberList.Destination);
            Mapper.CreateMap<CreateGameDefinitionViewModel, CreateGameDefinitionRequest>(MemberList.Destination)
                  //for now, GamingGroupId is optional and only passed from the API
                  .ForMember(x => x.GamingGroupId, opt => opt.Ignore());
            Mapper.CreateMap<PlayerStatistics, PlayerStatisticsMessage>(MemberList.Destination)
                  .ForMember(x => x.BaseNemePoints, opt => opt.MapFrom(src => src.NemePointsSummary.BaseNemePoints))
                  .ForMember(x => x.GameDurationBonusNemePoints, opt => opt.MapFrom(src => src.NemePointsSummary.GameDurationBonusNemePoints))
                  .ForMember(x => x.WeightBonusNemePoints, opt => opt.MapFrom(src => src.NemePointsSummary.WeightBonusNemePoints))
                  .ForMember(x => x.TotalPoints, opt => opt.MapFrom(src => src.NemePointsSummary.TotalPoints));
            Mapper.CreateMap<PlayerQuickStats, PlayerQuickStatsViewModel>(MemberList.Destination);
            Mapper.CreateMap<NemePointsSummary, NemePointsSummaryViewModel>(MemberList.Destination)
                  .ConstructUsing(x => new NemePointsSummaryViewModel(x.BaseNemePoints, x.GameDurationBonusNemePoints, x.WeightBonusNemePoints));
            Mapper.CreateMap<TrendingGame, TrendingGameViewModel>(MemberList.Destination);
            Mapper.CreateMap<BoardGameGeekGameDefinition, BoardGameGeekGameDefinitionViewModel>()
                .ForMember(m => m.BoardGameGeekUri,
                    opt => opt.MapFrom(src => BoardGameGeekUriBuilder.BuildBoardGameGeekGameUri(src.Id)))
                .ForMember(m => m.WeightDescription,
                    opt => opt.Ignore());
            Mapper.CreateMap<PlayedGameQuickStats, PlayedGameQuickStatsViewModel>(MemberList.Destination);
        }
    }
}