﻿using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models.Games
{
    public class NewlyCompletedGame
    {
        [Required]
        public int? GameDefinitionId { get; set; }

        //TODO google custom validation attribute, check out common MVC
        public List<PlayerRank> PlayerRanks { get; set; }
    }
}