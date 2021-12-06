using PriceCalculator.Entities;
using PriceCalculator.Services;
using PriceCalculator.Tests.BasketServiceTests;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceCalculator.Tests.ShoppingServiceTests
{
    public class ListAvailableProductsTests
    {
        [Fact]
        public void ListAvailableProducts_ShouldCorrectlyListAllProducts()
        {
            var basket = new Basket();
            var shoppingService = new ShoppingService(TestDataProvider.Discounts, TestDataProvider.AvailableProducts, basket);

            var listedProducts = shoppingService.ListAvailableProducts();

            Assert.Equal("Name: Milk | Cost: £1.15\r\n" +
                "Name: Butter | Cost: £0.80\r\n" +
                "Name: Bread | Cost: £1.00", listedProducts);
        }
    }
}
