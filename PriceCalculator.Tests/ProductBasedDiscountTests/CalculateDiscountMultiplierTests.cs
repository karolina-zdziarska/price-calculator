using PriceCalculator.Discounts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceCalculator.Tests.ProductBasedDiscountTests
{
    public class CalculateDiscountMultiplierTests
    {
        [Fact]
        public void CalculateDiscountMultiplier_TwoProductsTwoNeededToTrigger_ShouldReturnOne()
        {
            var multiplier = ProductBasedDiscount.CalculateDiscountMultiplier(2, 2, 1);
            Assert.Equal(1, multiplier);
        }

        [Fact]
        public void CalculateDiscountMultiplier_ThreeProductsTwoNeededToTrigger_ShouldReturnOne()
        {
            var multiplier = ProductBasedDiscount.CalculateDiscountMultiplier(3, 2, 1);
            Assert.Equal(1, multiplier);
        }

        [Fact]
        public void CalculateDiscountMultiplier_FourProductsButNotEnoughToDiscount_ShouldReturnOne()
        {
            var multiplier = ProductBasedDiscount.CalculateDiscountMultiplier(4, 2, 1);
            Assert.Equal(1, multiplier);
        }

        [Fact]
        public void CalculateDiscountMultiplier_FourProductsTwoToDiscount_ShouldReturnTwo()
        {
            var multiplier = ProductBasedDiscount.CalculateDiscountMultiplier(4, 2, 2);
            Assert.Equal(2, multiplier);
        }
    }
}
