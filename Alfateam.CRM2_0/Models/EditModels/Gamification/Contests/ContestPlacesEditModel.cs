﻿using Alfateam.CRM2_0.Abstractions;
using Alfateam.CRM2_0.Models.Gamification.Contests;

namespace Alfateam.CRM2_0.Models.EditModels.Gamification.Contests
{
    public class ContestPlacesEditModel : EditModel<ContestPlaces>
    {
        /// <summary>
        /// Первое значение места. Если SecondValue == null, то нет диапазона и имеется единственное место
        /// Если есть - значит есть диапазон мест. Например: с 5 по 10 место
        /// </summary>
        public int FirstValue { get; set; }
        public int? SecondValue { get; set; }


        public ContestPrizeEditModel Prize { get; set; }
        public double Coins { get; set; }
        public double Rating { get; set; }
    }
}