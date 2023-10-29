﻿using DataModels;

namespace Contracts.SearchModels
{
    public class PaymentSearchModel
    {
        public double Sum { get; set; }
        public int CarByPurchaseId { get; set; }
        public int Id { get; set; }
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}