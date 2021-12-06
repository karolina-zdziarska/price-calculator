using PriceCalculator.Discounts;
using PriceCalculator.Entities;
using PriceCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCalculator
{
    public static class PriceCalculator
    {
        private static List<Product> availableProducts = new List<Product>()
        {
            new Product("Milk", 1.15m),
            new Product("Butter", 0.8m),
            new Product("Bread", 1)
        };
        private static List<IDiscount> discounts = new List<IDiscount>()
        {
            new ProductBasedDiscount("Butter", 2, "Bread", 50),
            new ProductBasedDiscount("Milk", 4, "Milk", 100)
        };

        private static readonly IBasketService basketService = new BasketService(discounts, availableProducts, new Basket());


        private static Dictionary<string, Action> commands = new Dictionary<string, Action>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "help", ListCommands },
            { "exit", Exit },
            { "products", ListProducts}
        };

        public static void ParseCommand(string command)
        {
            if (commands.ContainsKey(command))
            {
                commands[command]();
            }
            else
            {
                Console.WriteLine("Unrecognized command. Please type HELP for a list of available commands.");
            }
        }

        private static void Exit()
        {
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);
        }

        private static void ListCommands()
        {
            Console.WriteLine("Avaliable commands:");
            Console.WriteLine(string.Join("\r\n", commands.Select(c => c.Key)));
        }

        private static void ListProducts()
        {
            Console.WriteLine("Below are the avaliable products. Type ADD to add one to the basket.");
            Console.WriteLine(basketService.ListAvailableProducts());
        }
        
    }
}
