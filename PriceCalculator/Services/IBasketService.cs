using PriceCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Services
{
    public interface IBasketService
    {
        void AddProduct(Product product, int quantity);
        Product GetProductByName(string name);
        string ListBasketProducts();
        string ListAvailableProducts();
        decimal CalculateBasketTotal();
        void ClearBasket();
    }
}
