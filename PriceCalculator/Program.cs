using System;

namespace PriceCalculator
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Price Calculator. Type PRODUCTS to see the list of available products. Type HELP to see the list of all available commands.");
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("You are currently in the main menu. Awaiting your input...");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                PriceCalculator.ParseCommand(userInput);
            }
        }
    }
}
