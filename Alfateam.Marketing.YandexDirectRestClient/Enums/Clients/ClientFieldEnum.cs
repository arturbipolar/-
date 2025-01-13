﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexDirectRestClient.Enums.Clients
{
    public enum ClientFieldEnum
    {
        [Description("AccountQuality")]
        AccountQuality = 1,
        [Description("Archived")]
        Archived = 2,
        [Description("ClientId")]
        ClientId = 3,
        [Description("ClientInfo")]
        ClientInfo = 4,
        [Description("CountryId")]
        CountryId = 5,
        [Description("CreatedAt")]
        CreatedAt = 6,
        [Description("Currency")]
        Currency = 7,
        [Description("Grants")]
        Grants = 8,
        [Description("Bonuses")]
        Bonuses = 9,
        [Description("Login")]
        Login = 10,
        [Description("Notification")]
        Notification = 11,
        [Description("OverdraftSumAvailable")]
        OverdraftSumAvailable = 12,
        [Description("Phone")]
        Phone = 13,
        [Description("Representatives")]
        Representatives = 14,
        [Description("Restrictions")]
        Restrictions = 15,
        [Description("Type")]
        Type = 16,
        [Description("VatRate")]
        VatRate = 17,
        [Description("ForbiddenPlatform")]
        ForbiddenPlatform = 18,
        [Description("AvailableCampaignTypes")]
        AvailableCampaignTypes = 19,
    }
}