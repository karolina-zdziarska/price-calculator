using PriceCalculator.Entities;
using Xunit;

namespace PriceCalculator.Tests.ProductTests
{
    public class ToStringTests
    {
        [Fact]
        public void ToString_PriceWithNoDecimalPlaces_ShouldReturnCorrectString()
        {
            var product = new Product("Milk", 2);
            var productAsString = product.ToString();

            Assert.Equal("Name: Milk | Cost: £2.00", productAsString);
        }

        [Fact]
        public void ToString_PriceWithOneDecimalPlace_ShouldReturnCorrectString()
        {
            var product = new Product("Butter", 2.5m);
            var productAsString = product.ToString();

            Assert.Equal("Name: Butter | Cost: £2.50", productAsString);
        }

        [Fact]
        public void ToString_PriceWithTwoDecimalPlaces_ShouldReturnCorrectString()
        {
            var product = new Product("Water", 2.59m);
            var productAsString = product.ToString();

            Assert.Equal("Name: Water | Cost: £2.59", productAsString);
        }
    }
}
