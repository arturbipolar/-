﻿using Alfateam.Core.Attributes.DTO;
using Alfateam.EDM.API.Models.DTO.Abstractions.ApprovalRoutes;
using Alfateam.EDM.API.Models.DTO.General;
using Alfateam.EDM.Models.General;

namespace Alfateam.EDM.API.Models.DTO.ApprovalRoutes.AfterDocSigning
{
    public class AfterDocSigningNotifyUsersDTO : AfterDocSigningActionDTO
    {
        public List<UserDTO> Users { get; set; } = new List<UserDTO>();
        [DTOFieldBindWith(typeof(User))]
        public List<int> UsersIds { get; set; } = new List<int>();
    }
}
