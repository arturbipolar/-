﻿using Alfateam.Core.Services;
using Alfateam.DB;
using Alfateam.EDM.API.Models;
using Alfateam.Gateways.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Alfateam.EDM.API.Abstractions
{
    [ApiController]
    [Route("[controller]")]
    public abstract class AbsController : ControllerBase
    {
        public readonly EDMDbContext DB;
        public readonly AbsDBService DBService;
        public readonly AbsFilesService FilesService;
        public readonly IWebHostEnvironment AppEnvironment;
        public readonly IMailGateway MailGateway;
        public readonly ISMSGateway SMSGateway;
        public AbsController(ControllerParams @params)
        {
            this.DB = @params.DB;
            this.DBService = @params.DBService;
            this.FilesService = @params.FilesService;
            this.AppEnvironment = @params.AppEnvironment;
            this.MailGateway = @params.MailGateway;
            this.SMSGateway = @params.SMSGateway;
        }
    }
}