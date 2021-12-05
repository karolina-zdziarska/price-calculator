using PriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PriceCalculator.Tests.BasketTests
{
    public class AddProductTests
    {
        [Fact]
        public void AddProduct_ProductNotInBasket_ShouldAddProduct()
        {
            var basket = new Basket();
            var product = new Product("Milk", 2.5m);
            basket.AddProduct(product, 2);

            var basketEntry = basket.Items.FirstOrDefault(i => i.Product == product);
            Assert.NotNull(basketEntry);
            Assert.Equal(2, basketEntry.Quantity);
        }

        [Fact]
        public void AddProduct_ProductAlreadyInBasket_ShouldIncreaseQuantity()
        {
            var basket = new Basket();
            var product = new Product("Butter", 2.5m);
            basket.Items.Add(new BasketEntry() {
                Product = product,
                Quantity = 3
            });

            basket.AddProduct(product, 2);
            var basketEntry = basket.Items.Where(i => i.Product == product);
            Assert.Single(basketEntry);
            Assert.Equal(5, basketEntry.First().Quantity);
        }
    }
}
