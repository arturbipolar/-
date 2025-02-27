﻿using Alfateam.Marketing.API.Models.DTO.Abstractions;
using Alfateam.SharedModels.Abstractions.Gateways;
using Alfateam.SharedModels.DTO.Abstractions.Gateways;

namespace Alfateam.Marketing.API.Models.DTO.Lettering
{
    public class SMSLetteringCampaignDTO : LetteringCampaignDTO
    {
        public SMSGatewaySettingsDTO Gateway { get; set; }
    }
}
