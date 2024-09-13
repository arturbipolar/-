﻿using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam.Website.API.Attributes.DTO;
using Alfateam2._0.Models.Events;

namespace Alfateam.Website.API.Models.DTO.Events
{
    public class EventCategoryDTO : DTOModel<EventCategory>
    {
        public string Title { get; set; }
        public string? Description { get; set; }


        [HiddenFromClient]
        public int MainLanguageId { get; set; }


        public string Slug => SlugHelper.GetLatynSlug(Title);
    }
}