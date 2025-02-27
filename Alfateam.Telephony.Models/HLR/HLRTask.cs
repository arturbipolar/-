﻿using Alfateam.Core;
using Alfateam.Telephony.Models.Abstractions;
using Alfateam.Telephony.Models.Enums;
using Alfateam.Telephony.Models.HLR.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Telephony.Models.HLR
{
    public class HLRTask : AbsModel
    {
        public string Title { get; set; }
        public HLRTaskStatus Status { get; set; } = HLRTaskStatus.NotStarted;
        public HLRNumbersToCheck NumbersToCheck { get; set; }
        public List<HLRTaskIteration> Iterations { get; set; } = new List<HLRTaskIteration>();





        public List<HLRTaskIterationResult> Results { get; set; } = new List<HLRTaskIterationResult>();

        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessCompanyId { get; set; }
    }
}
