﻿using Alfateam.Models.Helpers;
using Alfateam.Website.API.Abstractions;
using Alfateam2._0.Models.Abstractions;
using Alfateam2._0.Models.Shop;

namespace Alfateam.Website.API.Models.DTO.Shop
{
    public class ShopProductCategoryDTO : DTOModel<ShopProductCategory>
    {
        public string Title { get; set; }
        public string Slug => SlugHelper.GetLatynSlug(Title);


        public int MainLanguageId { get; set; }
    }
}