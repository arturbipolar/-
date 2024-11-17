﻿using Alfateam.Core;
using Alfateam.Sales.Models.Abstractions.ExtInterations;
using Alfateam.Sales.Models.Abstractions.Tasks;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Sales.Models.Funnel;
using Alfateam.Sales.Models.General.Security;
using Alfateam.Sales.Models.Invoices;
using Alfateam.Sales.Models.Invoices.Kanban;
using Alfateam.Sales.Models.Orders;
using Alfateam.Sales.Models.Plan;
using Alfateam.Sales.Models.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfateam.Sales.Models.General
{
    public class BusinessCompany : AbsModel
    {
        public string Title { get; set; }
        public string LegalAddress { get; set; }
        public string? ActualAddress { get; set; }


        public string? LogoPath { get; set; }



        public Currency MainCurrency { get; set; }
        public int MainCurrencyId { get; set; }




        public List<User> Users { get; set; } = new List<User>();
        public Department Department { get; set; }




        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderStatus> OrderStatuses { get; set; } = new List<OrderStatus>();


        public List<SalesPlanning> SalesPlannings { get; set; } = new List<SalesPlanning>();
        public List<SalesFunnel> SalesFunnels { get; set; } = new List<SalesFunnel>();
        public List<SalesFunnelStageType> SalesFunnelStageTypes { get; set; } = new List<SalesFunnelStageType>();
        public List<SalesScript> SalesScripts { get; set; } = new List<SalesScript>();


        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<CustomerCategory> CustomerCategories { get; set; } = new List<CustomerCategory>();


        public List<BusinessProposalTemplate> BusinessProposalTemplates { get; set; } = new List<BusinessProposalTemplate>();
        public List<BusinessProposalsKanban> BusinessProposalKanbans { get; set; } = new List<BusinessProposalsKanban>();


        public List<InvoiceTemplate> InvoiceTemplates { get; set; } = new List<InvoiceTemplate>();
        public List<InvoicesKanban> InvoicesKanbans { get; set; } = new List<InvoicesKanban>();






        public List<ExternalInteraction> ExternalInteractions { get; set; } = new List<ExternalInteraction>();
        public List<UserTask> UserTasks { get; set; } = new List<UserTask>();
        public List<HistoryAction> HistoryActions { get; set; } = new List<HistoryAction>();




        /// <summary>
        /// Автоматическое поле
        /// </summary>
        public int BusinessId { get; set; }
    }
}