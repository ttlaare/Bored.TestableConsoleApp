using ConsoleApp.Shared.OrderItem;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    public static class OrderPlacerHelper
    {
        public static void WriteOrderableItems(List<OrderItem> orderableItems, ResourceManager resource)
        {
            Console.WriteLine(resource.GetString("ConsoleApp_Order_OrderMessage", CultureInfo.CurrentCulture));
            for (int i = 0; i < orderableItems.Count(); i++)
            {
                Console.WriteLine($"Press {i + 1} for a {orderableItems.ElementAt(i).Name.ToLower(CultureInfo.InvariantCulture)}. " +
                    $"Price: {orderableItems.ElementAt(i).Price.ToString("F", CultureInfo.CurrentCulture)}.");
            }
        }

        public static OrderItem AddOrderByUser(string input, List<OrderItem> orderableItems)
        {
            var index = int.Parse(input) - 1;
            return orderableItems.ElementAt(index);
        }
    }
}
