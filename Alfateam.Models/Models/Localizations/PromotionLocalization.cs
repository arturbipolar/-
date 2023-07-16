﻿using Alfateam.Database.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Database.Models.Localizations
{
    public class PromotionLocalization : LocalizationModel
    {
        public string? Caption { get; set; }
        public string? Price { get; set; }
    }
}