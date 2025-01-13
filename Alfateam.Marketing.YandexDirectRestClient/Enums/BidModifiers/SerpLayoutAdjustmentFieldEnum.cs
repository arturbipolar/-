﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.BidModifiers
{
    public enum SerpLayoutAdjustmentFieldEnum
    {
        [Description("SerpLayout")]
        SerpLayout = 1,
        [Description("BidModifier")]
        BidModifier = 2,
        [Description("Enabled")]
        Enabled = 3,
    }
}