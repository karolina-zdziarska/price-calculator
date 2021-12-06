using PriceCalculator.Discounts;
using PriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculator.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly List<IDiscount> _discounts;
        private readonly List<Product> _availableProducts;
        private readonly Basket _basket;

        public ShoppingService(List<IDiscount> discounts, List<Product> availableProducts, Basket basket)
        {
            _discounts = discounts;
            _availableProducts = availableProducts;
            _basket = basket;
        }

        public void AddProduct(Product product, int quantity)
        {
            _basket.AddProduct(product, quantity);
        }

        public void RemoveProduct(Product product)
        {
            _basket.RemoveProduct(product);
        }

        public decimal CalculateBasketTotal()
        {
            decimal discountValue = 0;
            if (_discounts.Any())
            {
                _discounts.ForEach(d => discountValue += d.GetDiscountValue(_basket.Items));
            }
            return _basket.CalculateTotalPrice() + discountValue;
        }

        public void ClearBasket()
        {
            _basket.ClearBasket();
        }

        public Product GetProductByName(string name)
        {
            return _availableProducts.FirstOrDefault(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public string ListAvailableProducts()
        {
            return string.Join("\r\n", _availableProducts.Select(p => p.ToString()));
        }

        public string ListBasketProducts()
        {
            return "Products in basket: \r\n" + _basket.ListProducts();
        }
    }
}
