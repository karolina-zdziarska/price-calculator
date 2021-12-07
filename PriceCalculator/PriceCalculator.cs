using PriceCalculator.Discounts;
using PriceCalculator.Entities;
using PriceCalculator.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
            new ProductBasedDiscount("Butter", 2, "Bread", 50) { Description = "Buy 2 Butter and get a Bread at 50% off" },
            new ProductBasedDiscount("Milk", 4, "Milk", 100) { Description = "Buy 3 Milk and get the 4th milk for free"}
        };

        private static readonly IShoppingService shoppingService = new ShoppingService(discounts, availableProducts, new Basket());


        private static Dictionary<string, Action> commands = new Dictionary<string, Action>(StringComparer.InvariantCultureIgnoreCase)
        {
            { "help", ListCommands },
            { "exit", Exit },
            { "products", ListProducts},
            { "total",  BasketTotal},
            { "basket",  BasketProducts},
            { "add", AddProduct },
            { "remove", RemoveProduct },
            { "clear", ClearBasket },
            { "discounts",  ListDiscounts}
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
            Console.WriteLine(shoppingService.ListAvailableProducts());
        }

        private static void BasketTotal()
        {
            Console.WriteLine($"Your basket total is: {shoppingService.CalculateBasketTotal():0.00}");
        }

        private static void BasketProducts()
        {
            Console.WriteLine(shoppingService.ListBasketProducts());
        }

        private static void AddProduct()
        {
            while (true)
            {
                Console.WriteLine("You are adding products. Type a product name you want to add. Type CANCEL to return to main menu.");
                var userInput = Console.ReadLine();
                if (string.Equals(userInput, "cancel", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("You are no longer adding products.");
                    return;
                }
                var product = shoppingService.GetProductByName(userInput);
                if (product == null)
                {
                    Console.WriteLine($"Unrecognized product: {userInput}. Please try again.");
                    continue;
                }
                Console.WriteLine("Enter desired quantity:");
                var quantityUserInput = Console.ReadLine();
                if (!int.TryParse(quantityUserInput, out int quantity))
                {
                    Console.WriteLine($"Invalid numeric value: {quantityUserInput}");
                    continue;
                }
                shoppingService.AddProduct(product, quantity);
                Console.WriteLine($"You have added {quantity} {product.Name}.");
            }
        }

        private static void ClearBasket()
        {
            shoppingService.ClearBasket();
            Console.WriteLine("You have cleared your basket.");
        }

        private static void ListDiscounts()
        {
            Console.WriteLine("Below are available discounts:");
            Console.WriteLine(string.Join("\r\n", discounts.Select(d => d.Description)));
        }

        private static void RemoveProduct()
        {
            Console.WriteLine("Type a product name you want to remove from your basket.");
            var userInput = Console.ReadLine();
            var product = shoppingService.GetProductByName(userInput);
            if (product == null)
            {
                Console.WriteLine($"Unrecognized product: {userInput}.");
            }
            shoppingService.RemoveProduct(product);
            Console.WriteLine($"You have removed all entries of {product.Name} from your basket.");
        }
    }
}
