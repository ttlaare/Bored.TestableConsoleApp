using ConsoleApp.OrderItems;
using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    public class Order
    {
        private readonly IOrderItemRepository repository;
        private readonly List<OrderItem> placedOrderItems = new List<OrderItem>();

        public Order(IOrderItemRepository repository)
        {
            this.repository = repository;
        }

        public void PlaceOrder(OrderItemType type)
        {
            const string Message = "What would you like to order?";
            Console.WriteLine(Message);
            var orderableItems = repository.OrderItems.Where(o => o.Type == type);
            for (int i = 0; i < orderableItems.Count(); i++)
                Console.WriteLine($"Press {i + 1} for a {orderableItems.ElementAt(i).Name.ToLower()}. " +
                    $"Price: {orderableItems.ElementAt(i).Price}.");

            int consoleInput;
            while (true)
            {
                try
                {
                    consoleInput = int.Parse(Console.ReadLine());
                    placedOrderItems.Add(orderableItems.ElementAt(consoleInput - 1));
                    break;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Invalid input: input is out of range. Please choose a number between 1 and {orderableItems.Count()}.");
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Invalid input: input is not numeric. Please choose a number between 1 and {orderableItems.Count()}.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Sorry. Something unexpected happened. Exception message:{e.Message}");
                    throw;
                }
            }
            //while (true)
            //{
            //    consoleInput = console.ReadLine();

            //    if (!int.TryParse(consoleInput, out var consoleOrder))
            //    {
            //        console.WriteLine("Invalid input: input is not numeric.");
            //        continue;
            //    }
            //    if (consoleOrder > orderableItems.Count())
            //    {
            //        console.WriteLine($"Invalid input: input is out of range. Please choose a number between 0 and {orderableItems.Count() + 1}.");
            //        continue;
            //    }

            //    placedOrderItems.Add(orderableItems.ElementAt(consoleOrder - 1));
            //    break;
            //}
        }

        public void GetOrderedList()
        {
            if (!placedOrderItems.Any())
            {
                Console.WriteLine("You haven't placed an order yet");
                return;
            }

            Console.WriteLine("You ordered:");
            foreach (var item in placedOrderItems)
            {
                Console.WriteLine(item.Name);
            }
        }

        public double CalculateTotalPrice()
        {
            var result = placedOrderItems.Select(o => o.Price).Sum();
            Console.WriteLine($"Total price is: {result.ToString("F")}");
            return result;
        }
    }
}
