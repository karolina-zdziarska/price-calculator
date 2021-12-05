using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Entities
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Cost { get; private set; }

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }
        public override string ToString()
        {
            return $"Name: {Name} | Cost: £{Cost:#.00}";
        }
    }
}
