using PriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceCalculator.Tests.ProductTests
{
    public class ListProductsTests
    {
        [Fact]
        public void ListProducts_BasketHasNoProducts_ShouldReturnCorrectMessage()
        {
            var basket = new Basket();
            var productList = basket.ListProducts();
            Assert.Equal("Your basket is empty.", productList);
        }

        [Fact]
        public void ListProducts_BasketHasOneProduct_ShouldListProductAndQuantity()
        {
            var basket = new Basket();
            var milk = new Product("Milk", 1.15m);
            basket.Items.Add(new BasketEntry()
            {
                Product = milk,
                Quantity = 2
            });

            var productList = basket.ListProducts();
            Assert.Equal("Name: Milk | Cost: £1.15 | Quantity: 2", productList);
        }

        [Fact]
        public void ListProducts_BasketHasMultipleProducts_ShouldListProductAndQuantity()
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

            var productList = basket.ListProducts();

            Assert.Equal("Name: Milk | Cost: £1.15 | Quantity: 2" +
                "\r\nName: Butter | Cost: £0.80 | Quantity: 3", productList);
        }
    }
}
