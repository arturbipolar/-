﻿using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Documents.Meta.Structure;
using Alfateam.EDM.Models.Documents;
using Alfateam.EDM.Models.Documents.Meta.Structure;
using Alfateam.EDM.Models.Enums;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.EDM.API.Models.DTO.Documents
{
    public class DocumentTypeDTO : DTOModelAbs<DocumentType>
    {
        public DocumentTypePurpose Purpose { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public int? MinRequiredDocumentSides { get; set; }
        public int? MaxRequiredDocumentSides { get; set; }
        public DocTypeMetadataStructureDTO MetadataStructure { get; set; }



        /// <summary>
        /// Является ли документ для внутреннего пользования. Если да, то нельзя отсылать документ контрагентам
        /// </summary>
        public bool IsInternalDocument { get; set; }



        /// <summary>
        /// Вшит ли тип документа в систему. Если false, то тип кастомный, создан пользователем
        /// </summary>
        [ForClientOnly]
        public bool IsDefaultType { get; set; }
    }
}
