﻿using Alfateam.CRM2_0.Models.Abstractions;
using Alfateam.CRM2_0.Models.Enums.Roles.Compliance.Corruption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Roles.Compliance.Corruption
{
    /// <summary>
    /// Сторона коррупционного инцидента
    /// </summary>
    public class CorruptionCaseSide : AbsModel
    {
        public CorruptionCaseSideType Type { get; set; } = CorruptionCaseSideType.Bribetakers;
        public bool IsInitiator { get; set; }      
        public List<CorruptionCaseParticipant> Participants { get; set; } = new List<CorruptionCaseParticipant>();
    }
}