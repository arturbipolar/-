﻿using Alfateam.Core;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.BusinessProposals;
using Alfateam.Sales.API.Models.DTO.Invoices;
using Alfateam.Sales.API.Models.SearchFilters;
using Alfateam.Sales.Models.BusinessProposals;
using Alfateam.Sales.Models.Invoices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Alfateam.Sales.API.Controllers.Invoices
{
    public class InvoicesController : AbsController
    {
        public InvoicesController(ControllerParams @params) : base(@params)
        {
        }



        #region Счета на оплату клиентам

        [HttpGet, Route("GetInvoices")]
        public async Task<ItemsWithTotalCount<InvoiceDTO>> GetInvoices(InvoicesSearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<Invoice, InvoiceDTO>(GetAvailableInvoices(), filter.Offset, filter.Count, (entity) =>
            {
                bool condition = true;

                if (!string.IsNullOrEmpty(filter.Query))
                {
                    condition &= entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                if (filter.CustomerId != null)
                {
                    condition &= entity.CustomerId == filter.CustomerId;
                }
                return condition;
            });
        }

        [HttpGet, Route("GetInvoice")]
        public async Task<InvoiceDTO> GetInvoice(int id)
        {
            return (InvoiceDTO)DBService.TryGetOne(GetAvailableInvoices(), id, new InvoiceDTO());
        }




        [HttpPost, Route("CreateInvoice")]
        public async Task<InvoiceDTO> CreateInvoice(InvoiceDTO model)
        {
            return (InvoiceDTO)DBService.TryCreateEntity(DB.Invoices, model, afterSuccessCallback: (entity) =>
            {
                entity.CreatedById = this.AuthorizedUser.Id;

                var customer = DB.Customers.FirstOrDefault(o => o.Id == model.CustomerId);
                this.AddHistoryAction("Выставление счета на оплату клиенту", $"Выставлен счет на оплату {entity.Title} клиенту {customer.FIO}");
            });
        }

        [HttpPut, Route("UpdateInvoice")]
        public async Task<InvoiceDTO> UpdateInvoice(InvoiceDTO model)
        {
            var item = GetAvailableInvoices().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (InvoiceDTO)DBService.TryUpdateEntity(DB.Invoices, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование счета на оплату клиенту", $"Отредактирован счет на оплату с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteInvoice")]
        public async Task DeleteInvoice(int id)
        {
            var item = GetAvailableInvoices().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.Invoices, item);

            this.AddHistoryAction("Удаление счета на оплату клиенту", $"Удален счет на оплату {item.Title} клиенту {item.Customer.FIO} с id={id}");
        }

        #endregion








        #region Private methods

        private IEnumerable<Invoice> GetAvailableInvoices()
        {
            return DB.Invoices.Include(o => o.Customer)
                              .Include(o => o.CreatedBy)
                              .Include(o => o.RejectedInfo)
                              .Include(o => o.PaidInfo)
                              .Include(o => o.Items)
                              .Where(o => !o.IsDeleted && o.Customer.BusinessCompanyId == this.CompanyId);
        }


        #endregion
    }
}