
using ConsoleApp.OrderItems;
using ConsoleApp.Repositories;
using System;
using System.Collections.Generic;
using ConsoleApp.Helpers;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var repository = Factory.BuildOrderItemRepository();
            var console = new ConsoleWrapper();
            var order = new Order(console, repository);

            order.PlaceOrder(OrderItemType.Food);
            order.PlaceOrder(OrderItemType.Drink);
            order.CalculateTotalPrice();
        }
    }
}
