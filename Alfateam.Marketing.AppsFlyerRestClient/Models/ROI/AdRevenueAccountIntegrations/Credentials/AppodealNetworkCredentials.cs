﻿using Alfateam.Marketing.AppsFlyerRestClient.Abstractions.Models.ROI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.AppsFlyerRestClient.Models.ROI.AdRevenueAccountIntegrations.Credentials
{
    public class AppodealNetworkCredentials : AdRevenueAccountIntegrationNetworkCredentials
    {
        [JsonProperty("api_key")]
        public string APIKey { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }

        [JsonProperty("network_app_id")]
        public string NetworkAppId { get; set; }

        [JsonProperty("app_key")]
        public string AppKey { get; set; }
    }
}
