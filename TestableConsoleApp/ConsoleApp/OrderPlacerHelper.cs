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
        public static void WriteOrderItems(List<OrderItem> orderableItems, ResourceManager resource)
        {
            Console.WriteLine(resource.GetString("ConsoleApp_Order_OrderMessage", Thread.CurrentThread.CurrentCulture));
            for (int i = 0; i < orderableItems.Count(); i++)
            {
                Console.WriteLine($"Press {i + 1} for a {orderableItems.ElementAt(i).Name.ToLower(CultureInfo.InvariantCulture)}. " +
                    $"Price: {orderableItems.ElementAt(i).Price.ToString("F", CultureInfo.CurrentCulture)}.");
            }
        }
    }
}
