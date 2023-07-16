﻿using Alfateam.CRM2_0.Models.Enums.Roles.Marketing;
using Alfateam.CRM2_0.Models.Roles.Marketing.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.CRM2_0.Models.Abstractions.Roles.Marketing
{
    /// <summary>
    /// Базовая модель задачи пункта рекламной кампании
    /// </summary>
    public abstract class BaseAdCampaignItemTask : AbsModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AdCampaignItemTaskStatus Status { get; set; } = AdCampaignItemTaskStatus.NotStarted;




        public List<SimpleAdCampaignItemTask> SubTasks { get; set; } = new List<SimpleAdCampaignItemTask>();
    }
}