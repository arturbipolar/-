﻿using Alfateam.Core.Attributes.DTO;
using Alfateam.Sales.API.Models.DTO.General;
using Alfateam.Sales.Models.Orders;
using Alfateam.Website.API.Abstractions;

namespace Alfateam.Sales.API.Models.DTO.Orders
{
    public class OrderDTO : DTOModelAbs<Order>
    {
        [ForClientOnly]
        public CustomerDTO Customer { get; set; }
        [HiddenFromClient]
        public int CustomerId { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }


        [ForClientOnly]
        public CurrencyDTO Currency { get; set; }
        [HiddenFromClient]
        public int CurrencyId { get; set; }


        public double Sum { get; set; }



        [ForClientOnly]
        public OrderStatusDTO Status { get; set; }
        [HiddenFromClient]
        public int StatusId { get; set; }


        [ForClientOnly]
        public OrderSaleInfoDTO SaleInfo { get; set; }
    }
}