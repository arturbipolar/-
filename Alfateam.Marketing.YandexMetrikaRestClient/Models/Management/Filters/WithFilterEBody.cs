﻿using Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Goals;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.Management.Filters
{
    public class WithFilterEBody
    {
        [JsonProperty("filter")]
        public FilterE Filter { get; set; }
    }
}