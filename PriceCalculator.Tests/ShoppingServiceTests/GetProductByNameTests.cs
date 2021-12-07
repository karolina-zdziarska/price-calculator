using PriceCalculator.Entities;
using PriceCalculator.Services;
using PriceCalculator.Tests.BasketServiceTests;
using Xunit;

namespace PriceCalculator.Tests.ShoppingServiceTests
{
    public class GetProductByNameTests
    {
        [Fact]
        public void GetProductByName_ProductFound_ShouldReturnCorrectProduct()
        {
            var basket = new Basket();
            var shoppingService = new ShoppingService(TestDataProvider.Discounts, TestDataProvider.AvailableProducts, basket);

            var foundProduct = shoppingService.GetProductByName("milk");
            Assert.NotNull(foundProduct);
            Assert.StrictEqual(TestDataProvider.Milk, foundProduct);
        }

        [Fact]
        public void GetProductByName_ProductNotFound_ShouldReturnNull()
        {
            var basket = new Basket();
            var shoppingService = new ShoppingService(TestDataProvider.Discounts, TestDataProvider.AvailableProducts, basket);

            var foundProduct = shoppingService.GetProductByName("flour");

            Assert.Null(foundProduct);
        }
    }
}
