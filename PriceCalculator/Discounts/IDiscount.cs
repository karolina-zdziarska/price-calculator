using PriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Discounts
{
    public interface IDiscount
    {
        string Description { get; set; }
        decimal GetDiscountValue(IList<BasketEntry> basketEntries);
    }
}
