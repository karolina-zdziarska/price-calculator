# price-calculator
This is a solution for the price calculation exercise. It's a simple .NET Core console application. Unit test project is included, with 31 tests writen using Xunit.

The application has a very basic command line interface to allow for manual testing.

Below is the list of allowed commands:
- HELP - lists all commands in a console
- EXIT - exits the app
- PRODUCTS - lists all the products that the user can add to the basket
- TOTAL - calculates the basket total (current items minus applicable discounts)
- ADD - add a product to the basket. The user can then provide a product name and quantity.
- REMOVE - remove all entries of a specific product from the basket.
- CLEAR - clears all items from the basket
- DISCOUNTS - lists all available discounts

# Design decisions and justifications

## Basket, Product and BasketEntry
To follow the single responsibility principle, I decided to extract the Basket class, which only has one job: managing the customer's products. It can only add, delete and list products, as well as return a sum of all of the products' cost, but it is not required required for the basket to 'know' what products are available in the store, since in real-life scenario this information would come from the database. The basket is also not responsible for any discount logic - this is managed in a separate component described below. This way, if there's any change to the discount logic, the basket remains intact.

The Product class represents a product that can be added to the basket. I decided to encapsulate the Name and Cost properties and give them private setters, so that they cannot be modified after the object is initialized. I also included a ToString override to help with printing the basket contents out to the console.

The BasketEntry is a class that contains information about the product added to the basket. I decided that it's better to store a Product along with quantity, rather than having multiple instances of the same product, because it drastically reduces the size of the Items list (for example, if someone adds a 100 milk, it would still be stored in one entry). It also simulates the relationship that Basket and Product would have in a relational database; there could be a table that stores basket ID, product ID and quantity.

## Discount logic: IDiscount and ProductBasedDiscount
My main goal when programming the discount logic was to ensure that the discount feature is extendable. This means that new offers can be added, which are triggered by different conditions and might have different calculation logic, but ultimately do the same thing: subtract from the basket total. Real life shops add to and modify their offers very often, which is why I decided it's important to start the design with that goal in mind. I included the IDiscount interface, which contains the GetDiscountValue method, returning a calculated discount value based on the products and their quantity. Each discount also has an optional description. 

For this task, I included only one implementation of this interface - ProductBasedDiscount - as this was the only discount type I identified from the requirements. The two offers seem very different at first glance, but they both boil down to the following:

- Each discount has a *trigger* product and the *discount* product. They can be the same, as in the case of milk discount.
- There is *trigger amount*, which stands for the amount of trigger product that needs to be in the basket in order for the discount to be applicable.
- *Discount percentage* is the percentage subtracted from the original price of the discounted product. In case of Buy-x-get-y-free discounts, the discount percentage will be 100.

As per requirements, these kinds of discounts can be applied multiple times, therefore a multiplier needs to be calculated (i.e. if someone buys 8 milk, they need to get 2 milks for free). 

It would be possible to add other implementations of this interface, such as order based discount, which would subtract the certain percentage of basket total, regardless of type of products (e.g. as a part of a customer royalty scheme), or shipping discount, which would offer free shipping to the customers that spend more than X amount in their order.

The discounts could be also configurable in other ways: for example, it would be possible to include a boolean value in the interface, which would allow to specify whether the discount can be stacked with other discounts.

I believe that this design decision is in accordance to the open-close principle, as it allows for extending the app by adding new discounts, but does not require modifying an existing implementation. It also follows the Liskov Substitution Principle, as including a different discount implementation would not force any changes to ShoppingService logic - it would still return a decimal value based on the basket items.

# ShoppingService
As I mentioned in the previous sections, my goal was to separate the basket logic and the discount logic, as well as available products. To bring it all together, I created a ShoppingService. This service recieves the three aforementioned entities as dependencies in a constructor, and it has methods that allow for the price calculator to work according to the requirements. I made sure that no methods in ShoppingService print out to the console, as this would prevent the implementation to be reused outside of the console app (for example, in an API). Instead, they output values and PriceCalculator is responsible for showing them to the user.

# PriceCalculator
This class is responsible for handling the user input and firing off a correct function based on that input. The commands do not directly call the ShoppingService functions. Instead, there are static methods that handle any output from ShoppingService, print it out to the console, and gather more user input if required (for example, when adding products).

# Limitations
Since the main goal of this task was to demonstrate the idea of TDD, OOP and SOLID principles without providing a complex solution, there are certain limitations to this application. These are conscious decisions that I made in order not to overcomplicate the code.

- Since the application uses no database, all of the data is hard coded inside the PriceCalculator.
- Because it's a console application that requires user text input to work, I decided to use product name as an identifier. Normally it's not a good practice, as a numeric ID or a GUID would be used instead (since name does not need to be unique), but this project does not use any database, and this decision allowed me to simplify the code.
- ShoppingService accepts a list of discounts and list of products. This is because that data is hard coded and I decided that there is no need to include separate services just to return it. If this was an API, this service would most likely accept a product service and a discount service, which would make calls to the database to retrieve required data.
- ShoppingService is static and it's instatiated inside the PriceCalculator. Normally a responsible class (in case of an API: a controller) would accept it in a constructor instead, and it would be resolved by dependency injection. I made this decision, because the usage of static class and static methods allowed me to simplify the way the command line interface works.


