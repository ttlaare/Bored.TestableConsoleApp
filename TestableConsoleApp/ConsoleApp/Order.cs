﻿using ConsoleApp.OrderItems;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Order
    {
        private readonly IConsole console;
        private readonly List<OrderItem> orderItems = new List<OrderItem>();
        public Order (IConsole console)
        {
            this.console = console;
        }

        public void PlaceFoodOrder()
        {
            console.WriteLine("What would you like to eat?");
            console.WriteLine("Press 1 for a hamburger. Price: 2,95.");
            console.WriteLine("Press 2 for a grilled sandwich. Price: 2,45.");

            bool orderCompleted = false;
            string consoleOrder;
            while (!orderCompleted)
            {
                consoleOrder = console.ReadLine();
                switch (consoleOrder)
                {
                    case "1":
                        orderItems.Add(new OrderItem() { Name = OrderItemType.Hamburger, Price = 2.95 });
                        orderCompleted = true;
                        break;
                    case "2":
                        orderItems.Add(new OrderItem() { Name = OrderItemType.GrilledSandwich, Price = 2.45 });
                        orderCompleted = true;
                        break;
                    default:
                        console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        public void PlaceDrinkOrder()
        {
            console.WriteLine("What would you like to drink?");
            console.WriteLine("Press 1 for a Cola. Price: 1,45.");
            console.WriteLine("Press 2 for juice. Price: 1,95.");

            bool orderCompleted = false;
            string consoleOrder;
            while (!orderCompleted)
            {
                consoleOrder = console.ReadLine();
                switch (consoleOrder)
                {
                    case "1":
                        orderItems.Add(new OrderItem() { Name = OrderItemType.Cola, Price = 1.45 });
                        orderCompleted = true;
                        break;
                    case "2":
                        orderItems.Add(new OrderItem() { Name = OrderItemType.Juice, Price = 1.95 });
                        orderCompleted = true;
                        break;
                    default:
                        console.WriteLine("Invalid input");
                        break;
                }
            }
        }
        public double CalculateTotalPrice()
        {
            double result = 0;
            foreach (var orderItem in orderItems)
            {
                result += orderItem.Price;
            }
            console.WriteLine($"Total price is: {result.ToString("F")}");
            return result;
        }
    }
}
