using PriceCalculator.Entities;
using System.Collections.Generic;

namespace PriceCalculator.Discounts
{
    public interface IDiscount
    {
        string Description { get; set; }
        decimal GetDiscountValue(IList<BasketEntry> basketEntries);
    }
}
