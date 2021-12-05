using PriceCalculator.Discounts;
using PriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PriceCalculator.Tests.ProductBasedDiscountTests
{
    public class GetDiscountValueTests
    {
        private readonly Product butter = new Product("Butter", 0.8m);
        private readonly Product milk = new Product("Milk", 1.15m);
        private readonly Product bread = new Product("Bread", 1);

        private readonly ProductBasedDiscount twoButterBreadHalfOff = new ProductBasedDiscount("Butter", 2, "Bread", 50);
        private readonly ProductBasedDiscount threeMilkFourthMilkFree = new ProductBasedDiscount("Milk", 3, "Milk", 100);

        [Fact]
        public void GetDiscountValue_DiscountDoesNotApply_ShouldReturnZero()
        {
            var items = new List<BasketEntry>()
            {
                new BasketEntry()
                {
                    Product = bread,
                    Quantity = 1
                },
                new BasketEntry()
                {
                    Product = butter,
                    Quantity = 1
                },
                new BasketEntry()
                {
                    Product = milk,
                    Quantity = 1
                }
            };

            var discount = twoButterBreadHalfOff.GetDiscountValue(items);
            Assert.Equal(0, discount);
        }

        [Fact]
        public void GetDiscountValue_DiscountAppliesButNoDiscountProduct_ShouldReturnZero()
        {
            var items = new List<BasketEntry>()
            {
                new BasketEntry()
                {
                    Product = butter,
                    Quantity = 2
                }
            };

            var discount = twoButterBreadHalfOff.GetDiscountValue(items);
            Assert.Equal(0, discount);
        }

        [Fact]
        public void GetDiscountValue_DiscountAppliesOnce_ShouldReturnCorrectDiscount()
        {
            var items = new List<BasketEntry>()
            {
                new BasketEntry()
                {
                    Product = bread,
                    Quantity = 2
                },
                new BasketEntry()
                {
                    Product = butter,
                    Quantity = 2
                }
            };

            var discount = twoButterBreadHalfOff.GetDiscountValue(items);
            Assert.Equal(-0.5m, discount);
        }

        [Fact]
        public void GetDiscountValue_DiscountAppliesTwice_ShouldReturnCorrectDiscount()
        {
            var items = new List<BasketEntry>()
            {
                new BasketEntry()
                {
                    Product = milk,
                    Quantity = 8
                }
            };

            var discount = threeMilkFourthMilkFree.GetDiscountValue(items);
            Assert.Equal(-2.30m, discount);
        }

        [Fact]
        public void GetDiscountValue_DiscountAppliesTwiceButOnlyOneProductToDiscount_ShouldReturnCorrectDiscount()
        {
            var items = new List<BasketEntry>()
            {
                new BasketEntry()
                {
                    Product = bread,
                    Quantity = 1
                },
                new BasketEntry()
                {
                    Product = butter,
                    Quantity = 4
                }
            };

            var discount = twoButterBreadHalfOff.GetDiscountValue(items);
            Assert.Equal(-0.5m, discount);
        }
    }
}
