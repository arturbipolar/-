﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Marketing.YandexMetrikaRestClient.Models.DataImport.Calls.UploadCalls
{
    public class UploadCallsResponse
    {
        [JsonProperty("uploading")]
        public OfflineCallsUploading Uploading { get; set; }
    }
}