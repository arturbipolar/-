﻿using Alfateam2._0.Models.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Localization.Items.Events
{
    public class EventLocalization : LocalizableModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }


        public string? EventOrganizer { get; set; }
        public string? EventMembers { get; set; }


        /// <summary>
        /// Автоматическое поле
        /// Указывает на главный объект (Событие)
        /// </summary>
        public int EventId { get; set; }
    }
}