﻿using PriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculator.Discounts
{
    public class ProductBasedDiscount : IDiscount
    {
        private string triggerName;
        private int triggerAmount;
        private string discountedProductName;
        private int discountPercentage;

        public ProductBasedDiscount(string triggerName, int triggerAmount, string discountedProductName, int discountPercentage)
        {
            this.triggerName = triggerName;
            this.triggerAmount = triggerAmount;
            this.discountedProductName = discountedProductName;
            this.discountPercentage = discountPercentage;
        }

        public decimal GetDiscountValue(IList<BasketEntry> basketEntries)
        {
            var triggerEntry = basketEntries.FirstOrDefault(e => string.Equals(e.Product.Name, triggerName, StringComparison.OrdinalIgnoreCase));
            if(triggerEntry == null || triggerEntry.Quantity < triggerAmount)
            {
                return 0;
            }
            var discountEntry = basketEntries.FirstOrDefault(e => string.Equals(e.Product.Name, discountedProductName, StringComparison.OrdinalIgnoreCase));
            if(discountEntry == null)
            {
                return 0;
            }
            var productToDiscount = discountEntry.Product;
            var discountMultiplier = triggerEntry.Quantity / triggerAmount;
            if(discountMultiplier > discountEntry.Quantity)
            {
                discountMultiplier = discountEntry.Quantity;
            }
            return -(productToDiscount.Cost * discountPercentage / 100) * discountMultiplier;
        }
    }
}
