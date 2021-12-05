using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Entities
{
    public class BasketEntry
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
