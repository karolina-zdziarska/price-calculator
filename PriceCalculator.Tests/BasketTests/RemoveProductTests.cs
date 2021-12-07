using PriceCalculator.Entities;
using Xunit;

namespace PriceCalculator.Tests.BasketTests
{
    public class RemoveProductTests
    {
        [Fact]
        public void RemoveProduct_ProductInBasket_ShouldRemoveProduct()
        {
            var basket = new Basket();
            var milk = new Product("Milk", 1.15m);
            basket.Items.Add(new BasketEntry()
            {
                Product = milk,
                Quantity = 2
            });

            basket.RemoveProduct(milk);

            Assert.Empty(basket.Items);
        }

        [Fact]
        public void RemoveProduct_ProductNotInBasket_ShouldDoNothing()
        {
            var basket = new Basket();
            var milk = new Product("Milk", 1.15m);
            var butter = new Product("Butter", 1);
            basket.Items.Add(new BasketEntry()
            {
                Product = milk,
                Quantity = 2
            });

            basket.RemoveProduct(butter);

            Assert.Single(basket.Items);
        }
    }
}
