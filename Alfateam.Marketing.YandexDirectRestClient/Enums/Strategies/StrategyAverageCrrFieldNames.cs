﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Strategies
{
    public enum StrategyAverageCrrFieldNames
    {
        [Description("Crr")]
        Crr = 1,
        [Description("GoalId")]
        GoalId = 2,
        [Description("WeeklySpendLimit")]
        WeeklySpendLimit = 3,
        [Description("ExplorationBudget")]
        ExplorationBudget = 4,
        [Description("CustomPeriodBudget")]
        CustomPeriodBudget = 5,
        [Description("BudgetType")]
        BudgetType = 6,
    }
}