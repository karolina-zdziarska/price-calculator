using PriceCalculator.Entities;
using Xunit;

namespace PriceCalculator.Tests.ProductTests
{
    public class ClearBasketTests
    {
        [Fact]
        public void ClearBasket_ShouldRemoveAllBasketEntries()
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

            basket.ClearBasket();
            Assert.Empty(basket.Items);
        }
    }
}
