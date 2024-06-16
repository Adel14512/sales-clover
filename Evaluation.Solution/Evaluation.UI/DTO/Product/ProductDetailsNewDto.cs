﻿using System;

namespace Evaluation.UI.DTO.Product
{
    public class ProductDetailsNewDto
    {
        public int ProductId { get; set; }
        public int ClassId { get; set; }
        public decimal AmlAmount { get; set; }
        public decimal CostPolicy { get; set; }
        public decimal AdminFees { get; set; }
        public decimal FirstYearDiscount { get; set; }
        public decimal Commision { get; set; }
    }
}