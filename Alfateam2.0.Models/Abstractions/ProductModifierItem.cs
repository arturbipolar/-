﻿using Alfateam.Core;
using Alfateam2._0.Models.ContentItems;
using Alfateam2._0.Models.General;
using Alfateam2._0.Models.Localization.Items.Shop.Modifiers;
using Alfateam2._0.Models.Shop.Modifiers.Items;
using JsonKnownTypes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam2._0.Models.Abstractions
{

    [JsonConverter(typeof(JsonKnownTypesConverter<ProductModifierItem>))]
    [JsonDiscriminator(Name = "discriminator")]
    [JsonKnownType(typeof(ColorModifierItem), "ColorModifierItem")]
    [JsonKnownType(typeof(SimpleModifierItem), "SimpleModifierItem")]
    /// <summary>
    /// Сущность варианта выбора модификатора товара
    /// </summary>
    public class ProductModifierItem : AbsModel
    {
        public string Title { get; set; }
        public PricingMatrix Pricing { get; set; }


        [JsonProperty("discriminator")]
        public string Discriminator { get; set; }


        public Language MainLanguage { get; set; }
        public int MainLanguageId { get; set; }
        public List<ProductModifierItemLocalization> Localizations { get; set; } = new List<ProductModifierItemLocalization>();


        /// <summary>
        /// Автоматическое поле
        /// Указывает на главную сущность(модификатор)
        /// </summary>
        public int ProductModifierId { get; set; }


        
    }
}
