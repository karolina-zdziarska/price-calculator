using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculator.Entities
{
    public class Basket
    {
        public List<BasketEntry> Items { get; private set; }
        public Basket()
        {
            Items = new List<BasketEntry>();
        }

        public void AddProduct(Product product, int quantity)
        {
            var existingEntry = Items.FirstOrDefault(e => e.Product == product);
            if (existingEntry == null)
            {
                Items.Add(new BasketEntry()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                existingEntry.Quantity += quantity;
            }
        }

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public string ListProducts()
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotalPrice()
        {
            return Items.Sum(i => i.Product.Cost * i.Quantity);
        }
    }
}
