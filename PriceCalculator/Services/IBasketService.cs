using System;
using System.Collections.Generic;
using System.Text;

namespace PriceCalculator.Services
{
    public interface IBasketService
    {
        bool AddProductByName(string name, int quantity);
        string ListBasketProducts();
        string ListAvailableProducts();
        decimal CalculateBasketTotal();
        void ClearBasket();
    }
}
