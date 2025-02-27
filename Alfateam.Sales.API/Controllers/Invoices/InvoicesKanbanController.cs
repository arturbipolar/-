﻿using Alfateam.Core.Exceptions;
using Alfateam.Core;
using Alfateam.Sales.API.Abstractions;
using Alfateam.Sales.API.Models;
using Alfateam.Sales.API.Models.DTO.Invoices.Kanban;
using Alfateam.Sales.Models.Invoices.Kanban;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Alfateam.Sales.Models.Invoices;
using Alfateam.Sales.API.Models.Kanban;
using Alfateam.Sales.API.Models.DTO.Invoices;
using Alfateam.Sales.Models.BusinessProposals.Kanban;
using Alfateam.Sales.Models.Enums.Statuses;
using Alfateam.Sales.API.Models.DTO.BusinessProposals.Kanban;

namespace Alfateam.Sales.API.Controllers.Invoices
{
    [Route("Invoices/[controller]")]
    public class InvoicesKanbanController : AbsController
    {
        public InvoicesKanbanController(ControllerParams @params) : base(@params)
        {
        }

        #region Канбаны

        [HttpGet, Route("GetKanbans")]
        public async Task<ItemsWithTotalCount<InvoicesKanbanDTO>> GetKanbans(SearchFilter filter)
        {
            return DBService.GetManyWithTotalCount<InvoicesKanban, InvoicesKanbanDTO>(GetAvailableKanbans(), filter.Offset, filter.Count, (entity) =>
            {
                if (!string.IsNullOrEmpty(filter.Query))
                {
                    return entity.Title.Contains(filter.Query, StringComparison.OrdinalIgnoreCase);
                }
                return true;
            });
        }

        [HttpGet, Route("GetKanban")]
        public async Task<InvoicesKanbanDTO> GetKanban(int id)
        {
            return (InvoicesKanbanDTO)DBService.TryGetOne(GetAvailableKanbans(), id, new InvoicesKanbanDTO());
        }

        [HttpPost, Route("CreateKanban")]
        public async Task<InvoicesKanbanDTO> CreateKanban(InvoicesKanbanDTO model)
        {
            return (InvoicesKanbanDTO)DBService.TryCreateEntity(DB.InvoicesKanbans, model, (entity) =>
            {
                entity.BusinessCompanyId = (int)this.CompanyId;
                AddDefaultKanbanStages(entity);
            },
            afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Добавление канбана для КП", $"Добавлен канбан для КП {entity.Title}");
            });
        }

        [HttpPut, Route("UpdateKanban")]
        public async Task<InvoicesKanbanDTO> UpdateKanban(InvoicesKanbanDTO model)
        {
            var item = GetAvailableKanbans().FirstOrDefault(o => o.Id == model.Id && !o.IsDeleted);
            return (InvoicesKanbanDTO)DBService.TryUpdateEntity(DB.InvoicesKanbans, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование канбана для КП", $"Отредактирован канбан для КП с id={entity.Id}");
            });
        }




        [HttpDelete, Route("DeleteKanban")]
        public async Task DeleteKanban(int id)
        {
            var item = GetAvailableKanbans().FirstOrDefault(o => o.Id == id && !o.IsDeleted);
            DBService.TryDeleteEntity(DB.InvoicesKanbans, item);

            this.AddHistoryAction("Удаление канбана для КП", $"Удален канбан для КП {item.Title} с id={id}");
        }

        #endregion

        #region Этапы (колонки) канбанов

        [HttpPost, Route("CreateKanbanStage")]
        public async Task<InvoicesKanbanStageDTO> CreateKanbanStage(int kanbanId, int stageAfterId, InvoicesKanbanStageDTO model)
        {
            var kanban = TryGetKanban(kanbanId);
            if (TryGetKanbanStage(stageAfterId).InvoicesKanbanId != kanbanId)
            {
                throw new Exception403("Этап не принадлежит текущему канбану");
            }
            else if(!model.IsValid())
            {
                throw new Exception400("Проверьте корректность заполнения полей");
            }

            var stageEntity = model.CreateDBModelFromDTO();
            kanban.InsertStage(stageAfterId, stageEntity);
            DBService.UpdateEntity(DB.InvoicesKanbans, kanban);

            this.AddHistoryAction("Добавление этапа (колонки) для канбана", $"Добавлен этап (колонка) для канбана {stageEntity.Title}");
            return (InvoicesKanbanStageDTO)new InvoicesKanbanStageDTO().CreateDTO(stageEntity);
        }

        [HttpPut, Route("UpdateKanbanStage")]
        public async Task<InvoicesKanbanStageDTO> UpdateKanbanStage(InvoicesKanbanStageDTO model)
        {
            var item = TryGetKanbanStage(model.Id);
            return (InvoicesKanbanStageDTO)DBService.TryUpdateEntity(DB.InvoicesKanbanStages, model, item, afterSuccessCallback: (entity) =>
            {
                this.AddHistoryAction("Редактирование этапа (колонки) для канбана", $"Отредактирован этап (колонка) для канбана с id={entity.Id}");
            });
        }

        [HttpDelete, Route("DeleteKanbanStage")]
        public async Task DeleteKanbanStage(int id)
        {
            var item = TryGetKanbanStage(id);

            if (item.IsSystemStage)
            {
                throw new Exception403("Невозможно удалить системную стадию");
            }
            else if (GetAvailableInvoices(item.InvoicesKanbanId).Where(o => o.KanbanData.StageId == id).Any())
            {
                throw new Exception400("Этап (колонка) для счетов на оплату не пустой");
            }

            DBService.TryDeleteEntity(DB.InvoicesKanbanStages, item);
            this.AddHistoryAction("Удаление этапа (колонки) для канбана", $"Удален этап (колонка) для канбана {item.Title} с id={id}");
        }

        #endregion

        #region Карточки в канбане

        [HttpGet, Route("GetKanbanItems")]
        public async Task<KanbanClientModel<InvoiceDTO>> GetKanbanItems(int kanbanId)
        {
            var kanban = DBService.TryGetOne(GetAvailableKanbans(), kanbanId);
            var invoices = GetAvailableInvoices(kanbanId);


            var clientModel = new KanbanClientModel<InvoiceDTO>();

            foreach (var stage in kanban.Stages)
            {
                var items = invoices.Where(o => o.KanbanData.StageId == stage.Id);

                clientModel.Stages.Add(new KanbanStageClientModel<InvoiceDTO>
                {
                    StageId = stage.Id,
                    Items = new InvoiceDTO().CreateDTOs(items).Cast<InvoiceDTO>()
                });
            }

            return clientModel;
        }

        [HttpPut, Route("SetKanbanItemStage")]
        public async Task SetKanbanItemStage(int invoiceId, int stageId)
        {
            var invoice = DBService.TryGetOne(GetAvailableInvoices(), invoiceId);
            TryGetKanbanStage(stageId);

            invoice.KanbanData.StageId = stageId;
            DBService.UpdateEntity(DB.Invoices, invoice);
        }

        #endregion









        #region Private kanban methods
        private IEnumerable<InvoicesKanban> GetAvailableKanbans()
        {
            return DB.InvoicesKanbans.Include(o => o.Stages)
                                     .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }

        private void AddDefaultKanbanStages(InvoicesKanban entity)
        {
            entity.Stages.Add(new InvoicesKanbanStage
            {
                Status = InvoiceKanbanStageStatus.NewInvoice,
                Title = "Новый",
                TextHexColor = "#07141C",
                BGHexColor = "#39A8EF",
                IsSystemStage = true,
            });
            entity.Stages.Add(new InvoicesKanbanStage
            {
                Status = InvoiceKanbanStageStatus.InWork,
                Title = "Отправлен клиенту",
                TextHexColor = "#07141C",
                BGHexColor = "#2FC6F6",
                IsSystemStage = false,
            });





            entity.Stages.Add(new InvoicesKanbanStage
            {
                Status = InvoiceKanbanStageStatus.Rejected,
                Title = "Не оплачен",
                TextHexColor = "#FFFFFF",
                BGHexColor = "#FF5752",
                IsSystemStage = true,
            });
            entity.Stages.Add(new InvoicesKanbanStage
            {
                Status = InvoiceKanbanStageStatus.Paid,
                Title = "Оплачен",
                TextHexColor = "#07141C",
                BGHexColor = "#7BD500",
                IsSystemStage = true,
            });
        }


        private InvoicesKanban TryGetKanban(int kanbanId)
        {
            return DBService.TryGetOne(GetAvailableKanbans(), kanbanId);
        }
        private void ThrowIfKanbanDontExist(int kanbanId)
        {
            DBService.TryGetOne(GetAvailableKanbans(), kanbanId);
        }
        private InvoicesKanbanStage TryGetKanbanStage(int stageId)
        {
            var stage = DBService.TryGetOne(DB.InvoicesKanbanStages, stageId);
            if (!GetAvailableKanbans().Any(o => o.Id == stage.InvoicesKanbanId))
            {
                throw new Exception403("Нет доступа к данной сущности");
            }
            return stage;
        }

        #endregion

        #region Private invoice methods


        private IEnumerable<Invoice> GetAvailableInvoices()
        {
            return DB.Invoices.Include(o => o.PersonContact)
                              .Include(o => o.Company)
                              .Include(o => o.CreatedBy)
                              .Include(o => o.RejectedInfo)
                              .Include(o => o.PaidInfo)
                              .Include(o => o.Items)
                              .Include(o => o.KanbanData)
                              .Where(o => !o.IsDeleted && o.BusinessCompanyId == this.CompanyId);
        }
        private IEnumerable<Invoice> GetAvailableInvoices(int kanbanId)
        {
            return GetAvailableInvoices().Where(o => o.KanbanData.KanbanId == kanbanId);
        }


        #endregion
    }
}
