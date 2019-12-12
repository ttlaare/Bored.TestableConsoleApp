using ConsoleApp.OrderItems;
using ConsoleApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public class Order
    {
        private readonly IConsole console;
        private readonly IOrderItemRepository repository;
        private readonly List<OrderItem> placedOrderItems = new List<OrderItem>();
        public Order(IConsole console, IOrderItemRepository repository)
        {
            this.console = console;
            this.repository = repository;
        }

        public void PlaceOrder(OrderItemType type)
        {
            console.WriteLine("What would you like to order?");
            var orderableItems = repository.OrderItems.Where(o => o.Type == type);
            for (int i = 0; i < orderableItems.Count(); i++)
            {
                console.WriteLine($"Press {i+1} for a {orderableItems.ElementAt(i).Name.ToLower()}. Price: {orderableItems.ElementAt(i).Price}.");
            }

            bool orderCompleted = false;
            string consoleInput;
            int consoleOrder;
            while (!orderCompleted)
            {
                consoleInput = console.ReadLine();

                if (!int.TryParse(consoleInput, out consoleOrder))
                {
                    console.WriteLine("Invalid input: input is not numeric.");
                    continue;
                }
                if (consoleOrder > orderableItems.Count())
                {
                    console.WriteLine($"Invalid input: input is out of range. Please choose a number between 0 and {orderableItems.Count()}.");
                    continue;
                }

                placedOrderItems.Add(orderableItems.ElementAt(consoleOrder - 1));
                orderCompleted = true;
            }
        }
        
        public double CalculateTotalPrice()
        {
            var result = placedOrderItems.Select(o => o.Price).Sum();
            console.WriteLine($"Total price is: {result.ToString("F")}");
            return result;
        }
    }
}
