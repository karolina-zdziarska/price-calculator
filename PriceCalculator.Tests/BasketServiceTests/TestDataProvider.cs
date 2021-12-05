using PriceCalculator.Discounts;
using PriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Tests.BasketServiceTests
{
    public static class TestDataProvider
    {
        public static Product Milk = new Product("Milk", 1.15m);
        public static Product Butter = new Product("Butter", 0.8m);
        public static Product Bread = new Product("Bread", 1);

        public static List<Product> AvailableProducts = new List<Product>()
        {
            Milk, Butter, Bread
        };

        public static ProductBasedDiscount BreadDiscount = new ProductBasedDiscount("Butter", 2, "Bread", 50);
        public static ProductBasedDiscount MilkDiscount = new ProductBasedDiscount("Milk", 4, "Milk", 100);

        public static List<IDiscount> Discounts = new List<IDiscount>()
        {
            BreadDiscount, MilkDiscount
        };
    }
}
