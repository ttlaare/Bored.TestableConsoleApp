using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new ConsoleWrapper();
            var order = new Order(console);
            order.PlaceFoodOrder();
            order.PlaceDrinkOrder();
            order.CalculateTotalPrice();
        }
    }
}
