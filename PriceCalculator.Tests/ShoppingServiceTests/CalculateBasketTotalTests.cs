using PriceCalculator.Entities;
using PriceCalculator.Services;
using Xunit;

namespace PriceCalculator.Tests.BasketServiceTests
{
    public class CalculateBasketTotalTests
    {
        [Fact]
        public void CalculateBasketTotal_BasketHasNoItems_ShouldReturnZero()
        {
            var basket = new Basket();
            var shoppingService = new ShoppingService(TestDataProvider.Discounts, TestDataProvider.AvailableProducts, basket);

            var basketTotal = shoppingService.CalculateBasketTotal();
            Assert.Equal(0, basketTotal);
        }

        [Fact]
        public void CalculateBasketTotal_NoDiscountsApply_ShouldReturnBasketTotal()
        {
            var basket = new Basket();
            basket.Items.Add(new BasketEntry()
            {
                Product = TestDataProvider.Milk,
                Quantity = 1
            });
            basket.Items.Add(new BasketEntry()
            {
                Product = TestDataProvider.Bread,
                Quantity = 1
            });
            basket.Items.Add(new BasketEntry()
            {
                Product = TestDataProvider.Butter,
                Quantity = 1
            });
            var shoppingService = new ShoppingService(TestDataProvider.Discounts, TestDataProvider.AvailableProducts, basket);

            var basketTotal = shoppingService.CalculateBasketTotal();
            Assert.Equal(2.95m, basketTotal);
        }

        [Fact]
        public void CalculateBasketTotal_OneDiscountApplies_ShouldReturnBasketTotalMinusDiscount()
        {
            var basket = new Basket();
            basket.Items.Add(new BasketEntry()
            {
                Product = TestDataProvider.Bread,
                Quantity = 2
            });
            basket.Items.Add(new BasketEntry()
            {
                Product = TestDataProvider.Butter,
                Quantity = 2
            });
            var shoppingService = new ShoppingService(TestDataProvider.Discounts, TestDataProvider.AvailableProducts, basket);

            var basketTotal = shoppingService.CalculateBasketTotal();
            Assert.Equal(3.1m, basketTotal);
        }


        [Fact]
        public void CalculateBasketTotal_SameProductDiscountApplies_ShouldReturnBasketTotalMinusDiscount()
        {
            var basket = new Basket();
            basket.Items.Add(new BasketEntry()
            {
                Product = TestDataProvider.Milk,
                Quantity = 4
            });
            var shoppingService = new ShoppingService(TestDataProvider.Discounts, TestDataProvider.AvailableProducts, basket);

            var basketTotal = shoppingService.CalculateBasketTotal();
            Assert.Equal(3.45m, basketTotal);
        }

        [Fact]
        public void CalculateBasketTotal_TwoDiscountsApply_ShoulrReturnBasketTotalMinusBothDiscounts()
        {
            var basket = new Basket();
            basket.Items.Add(new BasketEntry()
            {
                Product = TestDataProvider.Milk,
                Quantity = 8
            });
            basket.Items.Add(new BasketEntry()
            {
                Product = TestDataProvider.Bread,
                Quantity = 1
            });
            basket.Items.Add(new BasketEntry()
            {
                Product = TestDataProvider.Butter,
                Quantity = 2
            });
            var shoppingService = new ShoppingService(TestDataProvider.Discounts, TestDataProvider.AvailableProducts, basket);

            var basketTotal = shoppingService.CalculateBasketTotal();
            Assert.Equal(9, basketTotal);
        }
    }
}
