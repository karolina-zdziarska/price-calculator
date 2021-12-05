using PriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceCalculator.Tests.ProductTests
{
    public class CalculateTotalPriceTests
    {
        [Fact]
        public void CalculateTotalPrice_BasketHasNoProducts_ShouldReturnZero()
        {
            var basket = new Basket();
            var basketTotal = basket.CalculateTotalPrice();
            Assert.Equal(0, basketTotal);
        }

        [Fact]
        public void CalculateTotalPrice_BasketHasProductsOneEach_ShouldReturnCorrectSum()
        {
            var basket = new Basket();
            var milk = new Product("Milk", 1.15m);
            var butter = new Product("Butter", 0.8m);
            var bread = new Product("Bread", 1);
            basket.Items.Add(new BasketEntry()
            {
                Product = milk,
                Quantity = 1
            });
            basket.Items.Add(new BasketEntry()
            {
                Product = butter,
                Quantity = 1
            });
            basket.Items.Add(new BasketEntry()
            {
                Product = bread,
                Quantity = 1
            });

            var basketTotal = basket.CalculateTotalPrice();

            Assert.Equal(2.95m, basketTotal);
        }

        [Fact]
        public void CalculateTotalPrice_BasketHasProductsWithVariedQuantites_ShouldReturnCorrectSum()
        {
            var basket = new Basket();
            var milk = new Product("Milk", 1.15m);
            var butter = new Product("Butter", 0.8m);
            basket.Items.Add(new BasketEntry()
            {
                Product = milk,
                Quantity = 2
            });
            basket.Items.Add(new BasketEntry()
            {
                Product = butter,
                Quantity = 3
            });

            var basketTotal = basket.CalculateTotalPrice();

            Assert.Equal(4.7m, basketTotal);
        }
    }
}
