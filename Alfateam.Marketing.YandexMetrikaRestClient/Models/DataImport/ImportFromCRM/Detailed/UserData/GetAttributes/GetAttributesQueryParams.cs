﻿using Alfateam.Marketing.YandexMetrikaRestClient.Enums.DataImport;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.ImportFromCRM.Detailed.UserData.GetAttributes
{
    public class GetAttributesQueryParams
    {
        [JsonProperty("entity_type")]
        public AttributeEntityType EntityType { get; set; }
    }
}